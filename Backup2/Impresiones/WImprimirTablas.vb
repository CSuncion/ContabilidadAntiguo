Imports Entidad

Public Class WImprimirTablas

#Region "Propietarios"
    Public wTab As New WTabla

    Public wUsu As New WUsuario
    Public wMes As New WMeses
    Public wAux As New WAuxiliar
#End Region
    Dim cam As New CamposEntidad
#Region "Metodos"

    Sub nuevaVentana()
        '//
        Me.Owner.Enabled = False
        Me.Text = "Imprimir " + wTab.Text
        Me.InicializaVentana()
        Me.Show()
        '\\
    End Sub

    Sub InicializaVentana()

    End Sub

    Sub PorPantalla()
        '//
        Dim win As New WRptTab
        win.wTab = Me.wTab
        win.ent.DatoCondicion1 = Me.wTab.tipoTabla
        win.ent.CampoOrden = cam.NomItemTabla
        win.PorPantalla()
        '\\
    End Sub

    Sub PorImpresora()
        '//
        Dim win As New WRptTab
        win.wTab = Me.wTab
        win.ent.DatoCondicion1 = Me.wTab.tipoTabla
        win.ent.CampoOrden = cam.NomItemTabla
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




    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.EjecutarImpresion()
        Me.Close()
    End Sub


    Private Sub WImprimir_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub WImprimirTablas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class