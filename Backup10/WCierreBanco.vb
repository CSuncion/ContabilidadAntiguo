Imports Entidad
Imports Negocio

Public Class WCierreBanco
    Dim acc As New Accion
    Dim movdet As New RegContabDetaRN
    Dim bco As New CuentaBancoRN

#Region "Propietario"
    'Public wBco As New WCuentaBanco
#End Region

#Region "General"

    Sub InicializaVentana()
        '/Para los eventos de controles
        acc.listaCtrls = Me.ListaControles
        acc.PasaFoco()
        acc.FomatoDato()
        acc.PasarCursor()
        acc.Teclazo()
        acc.Valida()
        Me.Show()
        'Me.Owner.Enabled = False
        Me.PorDefecto()
        Me.btnAceptar.Focus()
        'acc.Nuevo()
    End Sub

    Sub PorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.TxtNomEmp.Text = SuperEntidad.xRazonSocial
        Me.txtAno.Text = SuperEntidad.xPeriodoEmpresa.Substring(0, 4)
        Me.txtCodMes.Text = SuperEntidad.xPeriodoEmpresa.Substring(4, 2)
    End Sub


    Sub SaldosDelMesACero()
        Dim iSalBanRN As New SaldosBancariosRN
        Dim iSalBanEN As New SuperEntidad
        iSalBanEN.AnoCuentaBanco = Me.txtAno.Text.Trim
        iSalBanEN.MesCuentaBanco = Me.txtCodMes.Text.Trim

        Dim iLisSalBan As List(Of SuperEntidad) = iSalBanRN.ObtenerSaldosBancariosExisPorEmpresaXAnoYMes(iSalBanEN)
        For Each xobj As SuperEntidad In iLisSalBan
            xobj.IngresosSolCuentaBanco = 0
            xobj.SalidasSolCuentaBanco = 0
            xobj.IngresosDolCuentaBanco = 0
            xobj.SalidasDolCuentaBanco = 0
            xobj.SaldoMesSolCuentaBanco = 0
            xobj.SaldoMesDolCuentaBanco = 0
            iSalBanRN.modificarSaldosBancarios(xobj)
        Next

    End Sub


    Sub Cierre()
        Dim cie As New SuperEntidad
        cie.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        ' Me.SaldosDelMesACero()
        bco.CierreMensual(cie)
        MsgBox("Realizado Correctamente")
    End Sub
#End Region



#Region "Mostrar Form Lista"

    Private Sub txtCodMes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodMes.KeyDown
        If Me.txtCodMes.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarTabla
                win.tabla = "Mes"
                win.titulo = "Meses"
                win.txt1 = Me.txtCodMes
                win.txt2 = Me.txtDesMes
                win.ctrlFoco = Me.txtCodMes
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

    Private Sub WPersonalRecycla_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Me.Owner.Enabled = True
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.Cierre()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class