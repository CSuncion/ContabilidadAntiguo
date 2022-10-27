Imports CrystalDecisions.CrystalReports.Engine
Imports Entidad
Imports Negocio

Public Class WImpSaldosBancarios

    Public sb As New SaldosBancariosRN
    Dim cam As New CamposEntidad
    Dim ds As New DataSet1
    Dim acc As New Accion
    Dim mes, ano, empresa As CrystalDecisions.CrystalReports.Engine.TextObject

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
    End Sub

    Sub PorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.txtNomEmp.Text = SuperEntidad.xRazonSocial
        Me.txtAno.Text = SuperEntidad.xPeriodoEmpresa.Substring(0, 4)
    End Sub

    Sub Imprimir()

        ds.SaldoBanco.Clear()

        'Llenar Cabecera()
        empresa = CType(Me.CrSaldoBanco1.Section2.ReportObjects.Item("Empresa"), CrystalDecisions.CrystalReports.Engine.TextObject)
        empresa.Text = Me.txtNomEmp.Text

        mes = CType(Me.CrSaldoBanco1.Section2.ReportObjects.Item("Mes"), CrystalDecisions.CrystalReports.Engine.TextObject)
        mes.Text = Me.txtDesMes.Text

        ano = CType(Me.CrSaldoBanco1.Section2.ReportObjects.Item("Ano"), CrystalDecisions.CrystalReports.Engine.TextObject)
        ano.Text = Me.txtAno.Text

        '' Traer saldos bancarios por mes
        Dim lis As New List(Of SuperEntidad)
        Dim objsal As New SuperEntidad
        objsal.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        objsal.AnoCuentaBanco = Me.txtAno.Text.Trim
        objsal.MesCuentaBanco = Me.txtCodMes.Text.Trim
        lis = sb.ListarSaldosBancariosExisActPorEmpresaXAnoYMes(objsal)

        For Each obj As SuperEntidad In lis

            ' MsgBox(obj.CodigoCuentaBanco)

            Dim NewRow As DataSet1.SaldoBancoRow
            NewRow = ds.SaldoBanco.NewSaldoBancoRow
            NewRow.Codigo = obj.CodigoCuentaBanco
            NewRow.Banco = obj.BancoCuentaBanco
            NewRow.Cuenta = obj.NumeroCuentaBanco
            NewRow.Moneda = obj.MonedaCuentaBanco
            NewRow.TipoCuenta = obj.TipoCuentaBanco
            'segun moneda
            Select Case obj.MonedaCuentaBanco
                Case "Soles" : NewRow.Saldo = obj.SaldoMesSolCuentaBanco
                Case "Dolares" : NewRow.Saldo = obj.SaldoMesDolCuentaBanco
                Case "Euros" : NewRow.Saldo = obj.SaldoMesEurCuentaBanco
            End Select
            ds.SaldoBanco.Rows.Add(NewRow)
        Next

        Me.CrSaldoBanco1.SetDataSource(ds)
        'Cargamos en nuestro formulario el cr
        Me.crv1.ReportSource = Me.CrSaldoBanco1
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
        Me.Close()
    End Sub
  
End Class