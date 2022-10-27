Imports Entidad
Imports Negocio

Public Class WSeleccionaCompra
#Region "Propietarios"
    Public wRc As New WRegistroCompra
#End Region

    Public ent As New SuperEntidad
    Public rc As New RegContabCabeRN
    Public cam As New CamposEntidad
    Public titulo As String


#Region "Metodos"

    Sub InicializaVentana()
        '/Ejecucion en ventana
        Me.Owner.Enabled = False
        Me.Show()
    End Sub

    Sub Aceptar()

        Dim tip As String = Rbt.radioActivo(Me.gbTipoCompra).Text.Trim.ToUpper

        Select Case tip

            Case "COMPRAS"
                Dim win As New WEditarRegistroCompra
                win.wRc = Me.wRc
                Me.wRc.titulo = "Compras "
                win.operacion = 0
                Me.wRc.AddOwnedForm(win)
                win.ventanaAdicionar()
            Case "IMPORTACION"
                Dim win As New WEditarRegistroCompraDua
                win.wRc = Me.wRc
                Me.wRc.titulo = "Compras "
                win.operacion = 0
                win.origen = "410"
                Me.wRc.AddOwnedForm(win)
                win.ventanaAdicionar()
            Case "DUA"
                Dim win As New WEditarRegistroCompraDua
                win.wRc = Me.wRc
                Me.wRc.titulo = "Compras "
                win.operacion = 0
                win.origen = "411"
                Me.wRc.AddOwnedForm(win)
                win.ventanaAdicionar()
            Case "PERCEPCION"
                Dim win As New WEditarRegistroCompraDua
                win.wRc = Me.wRc
                Me.wRc.titulo = "Compras "
                win.operacion = 0
                win.origen = "412"
                Me.wRc.AddOwnedForm(win)
                win.ventanaAdicionar()
        End Select
        Me.Close()
    End Sub

#End Region

    Private Sub WEditarPersonal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Me.Owner.Enabled = True
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.Aceptar()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        '    Dim rpta As Integer = MsgBox("Deseas cancelar la operacion", MsgBoxStyle.YesNo, "Cliente")
        '    If rpta = MsgBoxResult.Yes Then
        '        Me.Owner.Enabled = True
        '        Me.Close()
        '    Else
        '        Exit Sub
        '    End If
        Me.Owner.Enabled = True
        Me.Close()
    End Sub

End Class