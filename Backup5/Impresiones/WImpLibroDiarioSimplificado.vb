Imports Entidad
Imports Negocio

Public Class WImpLibroDiarioSimplificado
    Public ent, entCont, paren As New SuperEntidad
    Public lista As New List(Of SuperEntidad)
    Public rcdc As New MovimientoContableCabeceraRN
    Public rcdm As New MovimientoContableDetalleRN
    Public par As New ParametroRN
    Dim cam As New CamposEntidad
    Dim ds As New DataSet1
    Dim tb As New DataTable
    Dim cr As New CrRptLibroDiarioSimplificado
    Dim acc As New Accion
    Dim numerodigitos As String
    Dim ano, mes, empresa, periodo, ruc As CrystalDecisions.CrystalReports.Engine.TextObject



    Sub InicializaVentana()
        '/Para los eventos de controles
        acc.listaCtrls = Me.ListaControles
        acc.PasaFoco()
        acc.FomatoDato()
        acc.PasarCursor()
        acc.Teclazo()
        acc.Valida()
        Me.Show()
        Me.PorDefecto()
        Me.txtCodMes.Focus()
        'acc.Nuevo()
    End Sub

    Sub PorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.txtNomEmp.Text = SuperEntidad.xRazonSocial
        Me.txtAno.Text = SuperEntidad.xPeriodoEmpresa.Substring(0, 4)
        paren = par.buscarParametroExis(paren)
        numerodigitos = paren.DigitosCuentaAnalitica
    End Sub

    Sub Imprimir()

        ds.DiarioSimplificado.Clear()
        'Llenar Cabecera()
        periodo = CType(Me.cr.Section2.ReportObjects.Item("Periodo"), CrystalDecisions.CrystalReports.Engine.TextObject)
        periodo.Text = Me.txtAno.Text + Me.txtCodMes.Text

        ruc = CType(Me.cr.Section2.ReportObjects.Item("Ruc"), CrystalDecisions.CrystalReports.Engine.TextObject)
        ruc.Text = SuperEntidad.xRucEmpresa

        empresa = CType(Me.cr.Section2.ReportObjects.Item("Empresa"), CrystalDecisions.CrystalReports.Engine.TextObject)
        empresa.Text = Me.txtNomEmp.Text

        Dim lisD As New List(Of SuperEntidad)
        Dim fec As Date = CType("01/" + Me.txtCodMes.Text.Trim + "/" + Me.txtAno.Text.Trim, Date)
        Dim md As New SuperEntidad
        Dim sal As Decimal = 0
        For n As Integer = 0 To 31
            md.FechaVoucherRegContabCabe = fec.AddDays(n)

            If md.FechaVoucherRegContabCabe.Month = CType(Me.txtCodMes.Text, Integer) Then
                md.CampoOrden = cam.CodCtaPcge
                lisD = rcdm.CuentaSimplificada(md)

                If lisD.Count <> 0 Then

                    Dim NewRow As DataSet1.DiarioSimplificadoRow
                    NewRow = ds.DiarioSimplificado.NewDiarioSimplificadoRow
                    NewRow.Fecha = md.FechaVoucherRegContabCabe.ToShortDateString

                    For Each ob As SuperEntidad In lisD

                        sal = ob.SumaDebeRegContabCabe - ob.SumaHaberRegContabCabe
                        Select Case ob.CodigoCuentaPcge
                            Case "10" : NewRow.Cuenta10 = sal
                            Case "12" : NewRow.Cuenta12 = sal
                            Case "16" : NewRow.Cuenta16 = sal
                            Case "20" : NewRow.Cuenta20 = sal
                            Case "21" : NewRow.Cuenta21 = sal
                            Case "33" : NewRow.Cuenta33 = sal
                            Case "34" : NewRow.Cuenta34 = sal
                            Case "38" : NewRow.Cuenta38 = sal
                            Case "39" : NewRow.Cuenta39 = sal
                            Case "4011"
                                If sal > 0 Then
                                    'NewRow.Cuenta4011C = 0
                                    NewRow.Cuenta4011D = sal
                                Else
                                    NewRow.Cuenta4011C = sal
                                End If

                            Case "4017"
                                If sal > 0 Then
                                    'NewRow.Cuenta4011C = 0
                                    NewRow.Cuenta4017D = sal
                                Else
                                    NewRow.Cuenta4017C = sal
                                End If
                            Case "402" : NewRow.Cuenta402 = sal
                            Case "42" : NewRow.Cuenta42 = sal
                            Case "46" : NewRow.Cuenta46 = sal
                            Case "50" : NewRow.Cuenta50 = sal
                            Case "58" : NewRow.Cuenta58 = sal
                            Case "59" : NewRow.Cuenta59 = sal
                            Case "60" : NewRow.Cuenta60 = sal
                            Case "61" : NewRow.Cuenta61 = sal
                            Case "62" : NewRow.Cuenta62 = sal
                            Case "63" : NewRow.Cuenta63 = sal
                            Case "65" : NewRow.Cuenta65 = sal
                            Case "66" : NewRow.Cuenta66 = sal
                            Case "67" : NewRow.Cuenta67 = sal
                            Case "68" : NewRow.Cuenta68 = sal
                            Case "69" : NewRow.Cuenta69 = sal
                            Case "96" : NewRow.Cuenta96 = sal
                            Case "97" : NewRow.Cuenta97 = sal
                            Case "70" : NewRow.Cuenta70 = sal
                            Case "75" : NewRow.Cuenta75 = sal
                            Case "76" : NewRow.Cuenta76 = sal
                            Case "77" : NewRow.Cuenta77 = sal
                            Case "79" : NewRow.Cuenta79 = sal

                        End Select

                    Next
                    ds.DiarioSimplificado.Rows.Add(NewRow)
                End If
            End If
        Next

        cr.SetDataSource(ds)
        'Cargamos en nuestro formulario el cr
        Me.crv1.ReportSource = cr
        'Dim win As New wImpParaEnvio
        'win.NuevaVentana(ds)
        '/
    End Sub

#Region "Mostrar Form Lista"

    Private Sub txtCodMes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodMes.KeyDown
        If Me.txtCodMes.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarTabla
                win.tabla = "Mes"
                win.titulo = "Meses"
                win.txt1 = Me.txtCodMes
                win.txt2 = Me.txtDesMes
                win.NuevaVentana()
            End If
        End If
    End Sub

#End Region

#Region "Buscar Por Codigo"

    Private Sub txtCodMes_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodMes.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.txtCodMes : ope.txt2 = Me.txtDesMes
        ope.MostrarCodigoDescripcionDeTabla("Mes", "Meses", e)

    End Sub

#End Region

    Private Sub btnEjecutar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEjecutar.Click
        If acc.CamposObligatorios = False Then
            Exit Sub
        Else
            Me.Imprimir()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Dim rpta As Integer = MsgBox("Deseas cancelar la operacion", MsgBoxStyle.YesNo, "Matriz")
        If rpta = MsgBoxResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub




End Class