Imports CrystalDecisions.CrystalReports.Engine
Imports Entidad
Imports Negocio

Public Class WImpSaldosADigitos

    Public ent, entCont, paren As New SuperEntidad
    Public lista, listarsc As New List(Of SuperEntidad)
    Public sc As New SaldoContableRN
    Public rcdc As New MovimientoContableCabeceraRN
    Public rcdm As New MovimientoContableDetalleRN
    Public par As New ParametroRN
    Dim cam As New CamposEntidad
    Dim ds As New DataSet1
    Dim tb As New DataTable
    Dim cr As New CrRptSaldosADigitos
    Dim acc As New Accion
    Dim ano, mes, digito As CrystalDecisions.CrystalReports.Engine.TextObject

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
    End Sub

    Sub Imprimir()

        ds.SaldosADigitos.Clear()
        'Llenar Cabecera()
        digito = CType(Me.cr.Section2.ReportObjects.Item("Digito"), CrystalDecisions.CrystalReports.Engine.TextObject)
        digito.Text = Me.NudNumDig.Text.ToString.Trim

        ano = CType(Me.cr.Section2.ReportObjects.Item("Ano"), CrystalDecisions.CrystalReports.Engine.TextObject)
        ano.Text = Me.txtAno.Text
        mes = CType(Me.cr.Section2.ReportObjects.Item("Mes"), CrystalDecisions.CrystalReports.Engine.TextObject)
        mes.Text = Me.txtDesMes.Text


        'entCont.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        'entCont.AnoContrato = Me.txtAno.Text.Trim
        'entCont.CodigoMes = Me.txtCodMes.Text.Trim
        'lista = con.obtenerContratoExisPorProyectoAnoMes(entCont)


        'Pregunta si existe registros contables para la contabilizacion
        'If Me.ExisenRegContabcabe = False Then Exit Sub

        '' Traer saldos por ano 
        ent.PeriodoRegContabCabe = Me.txtAno.Text.Trim
        ent.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        ent.CampoOrden = cam.CodCtaPcge
        'TRAER MOVIMIENTO DETALLE
        listarsc = sc.obtenerSaldoContableXPeriodo(ent)

        For Each obj As SuperEntidad In listarsc

            If Me.NudNumDig.Value.ToString = obj.NumeroDigitosPcge Then

                Dim NewRow As DataSet1.SaldosADigitosRow
                NewRow = ds.SaldosADigitos.NewSaldosADigitosRow

                NewRow.Cuenta = obj.CodigoCuentaPcge
                NewRow.Descripcion = obj.NombreCuentaPcge

                Select Case Me.txtCodMes.Text.Trim

                    Case "00"
                        NewRow.DebeMes = obj.DebeS00SaldoContable
                        NewRow.HabeMes = obj.HabeS00SaldoContable

                    Case "01"
                        NewRow.DebeMes = obj.DebeS01SaldoContable
                        NewRow.HabeMes = obj.HabeS01SaldoContable

                    Case "02"
                        NewRow.DebeMes = obj.DebeS02SaldoContable
                        NewRow.HabeMes = obj.HabeS02SaldoContable

                    Case "03"
                        NewRow.DebeMes = obj.DebeS03SaldoContable
                        NewRow.HabeMes = obj.HabeS03SaldoContable

                    Case "04"
                        NewRow.DebeMes = obj.DebeS04SaldoContable
                        NewRow.HabeMes = obj.HabeS04SaldoContable

                    Case "05"
                        NewRow.DebeMes = obj.DebeS05SaldoContable
                        NewRow.HabeMes = obj.HabeS05SaldoContable


                    Case "06"
                        NewRow.DebeMes = obj.DebeS06SaldoContable
                        NewRow.HabeMes = obj.HabeS06SaldoContable


                    Case "07"
                        NewRow.DebeMes = obj.DebeS07SaldoContable
                        NewRow.HabeMes = obj.HabeS07SaldoContable


                    Case "08"
                        NewRow.DebeMes = obj.DebeS08SaldoContable
                        NewRow.HabeMes = obj.HabeS08SaldoContable


                    Case "09"
                        NewRow.DebeMes = obj.DebeS09SaldoContable
                        NewRow.HabeMes = obj.HabeS09SaldoContable


                    Case "10"
                        NewRow.DebeMes = obj.DebeS10SaldoContable
                        NewRow.HabeMes = obj.HabeS10SaldoContable


                    Case "11"
                        NewRow.DebeMes = obj.DebeS11SaldoContable
                        NewRow.HabeMes = obj.HabeS11SaldoContable



                    Case "12"
                        NewRow.DebeMes = obj.DebeS12SaldoContable
                        NewRow.HabeMes = obj.HabeS12SaldoContable

                    Case "13"
                        NewRow.DebeMes = obj.DebeS13SaldoContable
                        NewRow.HabeMes = obj.HabeS13SaldoContable


                End Select


                If NewRow.DebeMes <> 0 Or NewRow.HabeMes <> 0 Then
                    'AGREGANDO REGISTROS AL DATATABLE
                    'LLENANDO EL REGISTRO
                    'AÑADIR AL DS
                    ds.SaldosADigitos.Rows.Add(NewRow)
                End If
                'Suma de saldo anterandior + mes actual   
                'NewRow.SumaDebe = NewRow.DebeMes + NewRow.DebeAcu
                'NewRow.SumaHaber = NewRow.HabeMes + NewRow.HabeAcu

                
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

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Dim rpta As Integer = MsgBox("Deseas cancelar la operacion", MsgBoxStyle.YesNo, "Matriz")
        If rpta = MsgBoxResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btnEjecutar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEjecutar.Click

        If acc.CamposObligatorios = False Then
            Exit Sub
        Else
            Me.Imprimir()
        End If

    End Sub
End Class