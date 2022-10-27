Imports Entidad
Imports Negocio
Public Class WBloquear
    Private ent As New SuperEntidad
    Private cam As New CamposEntidad
    Private lista As New List(Of SuperEntidad)
    Private usu As New UsuarioRN


    Sub nuevaVentana()
        Me.lblUsu.Text = SuperEntidad.xCodigoUsuario
        Me.ShowDialog()
    End Sub

    Sub AccesoSistema()
        '//
        ent.DatoCondicion1 = SuperEntidad.xCodigoUsuario
        ent.DatoCondicion2 = Varios.encriptar(Me.txtCla.Text.Trim)
        If usu.existeUsuarioExisActPorCodigoYClave(ent) = True Then
            Me.Close()
        Else
            MsgBox("Acceso denegado", MsgBoxStyle.Exclamation)
            Me.txtCla.Text = ""
            Me.txtCla.Focus()
        End If
        '\\
    End Sub




    Private Sub btnIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngresar.Click
        Me.AccesoSistema()
    End Sub

    Private Sub txtCla_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCla.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then : Me.AccesoSistema() : End If
    End Sub

End Class