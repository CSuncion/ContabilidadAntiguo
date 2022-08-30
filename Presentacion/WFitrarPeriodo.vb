Imports Entidad
Imports Negocio

Public Class WFitrarPeriodo

#Region "Propietarios"
    Public wRgDiario As New WRegistroDiario
    Public wRgCompras As New WRegistroCompra
    ' Public wRgVentas As New WRegistroVenta
    Public wRgVenta As New WRegistroVenta
    Public wRgCajaBanco As New WRegistroCajaBanco
    Public wRgHonorarios As New WRegistroHonorario
    Public wRgTransfer As New WTransferencia
    Public wRgSaldo As New WSaldoContable
    Public wConMes As New WConsultaVouchers
    Public wConMesT As New WVouchersTodos
#End Region

    Public TipoRg As String = ""

    Sub nuevo()
        Me.Owner.Enabled = False
        Me.Show()
        'Segun tipo de registro contable
        Select Case TipoRg
            Case "Diarios" : Me.txtPeriodo.Text = Me.wRgdiario.periodo
            Case "Compras" : Me.txtPeriodo.Text = Me.wRgCompras.periodo
                '        Case "Ventas" : Me.txtPeriodo.Text = Me.wRgVentas.periodo
            Case "Ventas" : Me.txtPeriodo.Text = Me.wRgVenta.periodo
            Case "CajaBanco" : Me.txtPeriodo.Text = Me.wRgCajaBanco.periodo
            Case "Honorarios" : Me.txtPeriodo.Text = Me.wRgHonorarios.periodo
            Case "Transferencia" : Me.txtPeriodo.Text = Me.wRgTransfer.periodo
            Case "SaldoContable" : Me.txtPeriodo.Text = Me.wRgSaldo.periodo
            Case "ConsultaVouchers" : Me.txtPeriodo.Text = Me.wConMes.periodo
            Case "VouchersTodos" : Me.txtPeriodo.Text = Me.wConMesT.periodo
        End Select

    End Sub

    Private Sub WBuscarUsuario_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Select Case TipoRg
            Case "Diarios" : Me.wRgDiario.periodo = Me.txtPeriodo.Text : Me.wRgDiario.ActualizarVentana()
            Case "Compras" : Me.wRgCompras.periodo = Me.txtPeriodo.Text : Me.wRgCompras.ActualizarVentana()
                'Case "Ventas" : Me.wRgVentas.periodo = Me.txtPeriodo.Text : Me.wRgVentas.ActualizarVentana()
            Case "Ventas" : Me.wRgVenta.periodo = Me.txtPeriodo.Text : Me.wRgVenta.ActualizarVentana()
            Case "CajaBanco" : Me.wRgCajaBanco.periodo = Me.txtPeriodo.Text : Me.wRgCajaBanco.ActualizarVentana()
            Case "Honorarios" : Me.wRgHonorarios.periodo = Me.txtPeriodo.Text : Me.wRgHonorarios.ActualizarVentana()
            Case "Transferencia" : Me.wRgTransfer.periodo = Me.txtPeriodo.Text : Me.wRgTransfer.ActualizarVentana()
            Case "SaldoContable" : Me.wRgSaldo.periodo = Me.txtPeriodo.Text : Me.wRgSaldo.ActualizarVentana()
            Case "ConsultaVouchers" : Me.wConMes.periodo = Me.txtPeriodo.Text : Me.wConMes.ActualizarVentana()
            Case "VouchersTodos" : Me.wConMesT.periodo = Me.txtPeriodo.Text : Me.wConMesT.ActualizarVentana()
                Me.wConMesT.TituloCabecera()
                Me.wConMesT.ActualizarDgvDeta()
        End Select

    End Sub


    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class