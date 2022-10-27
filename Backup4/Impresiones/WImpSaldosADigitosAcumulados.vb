Imports CrystalDecisions.CrystalReports.Engine
Imports Entidad
Imports Negocio

Public Class WImpSaldosADigitosAcumulados
    Public ent, entCont, paren As New SuperEntidad
    Public lista, listarsc As New List(Of SuperEntidad)
    Public sc As New SaldoContableRN
    Public rcdc As New MovimientoContableCabeceraRN
    Public rcdm As New MovimientoContableDetalleRN
    Public par As New ParametroRN
    Dim cam As New CamposEntidad
    Dim ds As New DataSet1
    Dim tb As New DataTable
    Dim cr As New CrRptSaldosADigitosAcumulados
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
        Me.PorDefecto()
        Me.Show()
        Me.txtCodMes.Focus()

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

                        NewRow.DebeAcu = obj.DebeS00SaldoContable
                        NewRow.HabeAcu = obj.HabeS00SaldoContable

                    Case "01"
                        NewRow.DebeMes = obj.DebeS01SaldoContable
                        NewRow.HabeMes = obj.HabeS01SaldoContable

                        NewRow.DebeAcu = obj.DebeS00SaldoContable
                        NewRow.HabeAcu = obj.HabeS00SaldoContable

                    Case "02"
                        NewRow.DebeMes = obj.DebeS02SaldoContable
                        NewRow.HabeMes = obj.HabeS02SaldoContable

                        NewRow.DebeAcu = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable
                        NewRow.HabeAcu = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable

                    Case "03"
                        NewRow.DebeMes = obj.DebeS03SaldoContable
                        NewRow.HabeMes = obj.HabeS03SaldoContable

                        NewRow.DebeAcu = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable
                        NewRow.HabeAcu = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable

                    Case "04"
                        NewRow.DebeMes = obj.DebeS04SaldoContable
                        NewRow.HabeMes = obj.HabeS04SaldoContable

                        NewRow.DebeAcu = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable
                        NewRow.HabeAcu = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable

                    Case "05"
                        NewRow.DebeMes = obj.DebeS05SaldoContable
                        NewRow.HabeMes = obj.HabeS05SaldoContable

                        NewRow.DebeAcu = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable
                        NewRow.HabeAcu = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable

                    Case "06"
                        NewRow.DebeMes = obj.DebeS06SaldoContable
                        NewRow.HabeMes = obj.HabeS06SaldoContable

                        NewRow.DebeAcu = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable + obj.DebeS05SaldoContable
                        NewRow.HabeAcu = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable + obj.HabeS05SaldoContable

                    Case "07"
                        NewRow.DebeMes = obj.DebeS07SaldoContable
                        NewRow.HabeMes = obj.HabeS07SaldoContable

                        NewRow.DebeAcu = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable + obj.DebeS05SaldoContable + obj.DebeS06SaldoContable
                        NewRow.HabeAcu = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable + obj.HabeS05SaldoContable + obj.HabeS06SaldoContable

                    Case "08"
                        NewRow.DebeMes = obj.DebeS08SaldoContable
                        NewRow.HabeMes = obj.HabeS08SaldoContable

                        NewRow.DebeAcu = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable + obj.DebeS05SaldoContable + obj.DebeS06SaldoContable + obj.DebeS07SaldoContable
                        NewRow.HabeAcu = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable + obj.HabeS05SaldoContable + obj.HabeS06SaldoContable + obj.HabeS07SaldoContable

                    Case "09"
                        NewRow.DebeMes = obj.DebeS09SaldoContable
                        NewRow.HabeMes = obj.HabeS09SaldoContable

                        NewRow.DebeAcu = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable + obj.DebeS05SaldoContable + obj.DebeS06SaldoContable + obj.DebeS07SaldoContable + obj.DebeS08SaldoContable
                        NewRow.HabeAcu = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable + obj.HabeS05SaldoContable + obj.HabeS06SaldoContable + obj.HabeS07SaldoContable + obj.HabeS08SaldoContable

                    Case "10"
                        NewRow.DebeMes = obj.DebeS10SaldoContable
                        NewRow.HabeMes = obj.HabeS10SaldoContable

                        NewRow.DebeAcu = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable + obj.DebeS05SaldoContable + obj.DebeS06SaldoContable + obj.DebeS07SaldoContable + obj.DebeS08SaldoContable + obj.DebeS09SaldoContable
                        NewRow.HabeAcu = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable + obj.HabeS05SaldoContable + obj.HabeS06SaldoContable + obj.HabeS07SaldoContable + obj.HabeS08SaldoContable + obj.HabeS09SaldoContable

                    Case "11"
                        NewRow.DebeMes = obj.DebeS11SaldoContable
                        NewRow.HabeMes = obj.HabeS11SaldoContable

                        NewRow.DebeAcu = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable + obj.DebeS05SaldoContable + obj.DebeS06SaldoContable + obj.DebeS07SaldoContable + obj.DebeS08SaldoContable + obj.DebeS09SaldoContable + obj.DebeS10SaldoContable
                        NewRow.HabeAcu = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable + obj.HabeS05SaldoContable + obj.HabeS06SaldoContable + obj.HabeS07SaldoContable + obj.HabeS08SaldoContable + obj.HabeS09SaldoContable + obj.HabeS10SaldoContable

                    Case "12"
                        NewRow.DebeMes = obj.DebeS12SaldoContable
                        NewRow.HabeMes = obj.HabeS12SaldoContable

                        NewRow.DebeAcu = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable + obj.DebeS05SaldoContable + obj.DebeS06SaldoContable + obj.DebeS07SaldoContable + obj.DebeS08SaldoContable + obj.DebeS09SaldoContable + obj.DebeS10SaldoContable + obj.DebeS11SaldoContable
                        NewRow.HabeAcu = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable + obj.HabeS05SaldoContable + obj.HabeS06SaldoContable + obj.HabeS07SaldoContable + obj.HabeS08SaldoContable + obj.HabeS09SaldoContable + obj.HabeS10SaldoContable + obj.HabeS11SaldoContable
                    Case "13"
                        NewRow.DebeMes = obj.DebeS13SaldoContable
                        NewRow.HabeMes = obj.HabeS13SaldoContable

                        NewRow.DebeAcu = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable + obj.DebeS05SaldoContable + obj.DebeS06SaldoContable + obj.DebeS07SaldoContable + obj.DebeS08SaldoContable + obj.DebeS09SaldoContable + obj.DebeS10SaldoContable + obj.DebeS11SaldoContable + obj.DebeS12SaldoContable
                        NewRow.HabeAcu = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable + obj.HabeS05SaldoContable + obj.HabeS06SaldoContable + obj.HabeS07SaldoContable + obj.HabeS08SaldoContable + obj.HabeS09SaldoContable + obj.HabeS10SaldoContable + obj.HabeS11SaldoContable + obj.HabeS12SaldoContable
                End Select
                'Suma de saldo anterior + mes actual   
                NewRow.SumaDebe = NewRow.DebeMes + NewRow.DebeAcu
                NewRow.SumaHaber = NewRow.HabeMes + NewRow.HabeAcu

                'AGREGANDO REGISTROS AL DATATABLE
                'LLENANDO EL REGISTRO
                'AÑADIR AL DS
                ds.SaldosADigitos.Rows.Add(NewRow)
            End If

        Next

        cr.SetDataSource(ds)
        'Cargamos en nuestro formulario el cr
        Me.crv1.ReportSource = cr
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