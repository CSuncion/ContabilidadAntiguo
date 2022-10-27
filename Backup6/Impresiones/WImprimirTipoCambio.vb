Imports Entidad
Public Class WImprimirTipoCambio
#Region "Propietarios"
    Public wTc As New WTipoCambio
#End Region
    Dim cam As New CamposEntidad

#Region "Metodos"

    Sub nuevaVentana()
        '//
        Me.Owner.Enabled = False
        Me.Text = "Imprimir Tipo Cambio"
        Me.InicializaVentana()
        Me.Show()
        '\\
    End Sub

    Sub InicializaVentana()
        Me.dtpDesde.Value = Today
        Me.dtpHasta.Value = Today
        Me.cmbOrden.SelectedIndex = 0
    End Sub


    Function Orden() As String
        Select Case Me.cmbOrden.Text
            Case "Fecha"
                Return cam.FecTipCam
            Case "Compra"
                Return cam.ComTipCam
            Case "Venta"
                Return cam.VenTipCam
            Case Else
                Return ""
        End Select
    End Function

    Sub PorPantalla()
        '//
        Dim win As New WRptTipCam
        win.ent.Desde = Me.dtpDesde.Value
        win.ent.Hasta = Me.dtpHasta.Value
        win.ent.CampoOrden = Me.Orden
        win.PorPantalla()
        '\\
    End Sub

    Sub PorImpresora()
        '//
        Dim win As New WRptTipCam
        win.ent.Desde = Me.dtpDesde.Value
        win.ent.Hasta = Me.dtpHasta.Value
        win.ent.CampoOrden = Me.Orden
        win.PorImpresora()
        '\\
    End Sub

    Sub EjecutarImpresion()
        If Me.rbtPan.Checked Then
            Me.PorPantalla()
        Else
            Me.PorImpresora()
        End If

    End Sub

#End Region

    Private Sub WImprimir_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.EjecutarImpresion()
        Me.Close()
    End Sub
End Class