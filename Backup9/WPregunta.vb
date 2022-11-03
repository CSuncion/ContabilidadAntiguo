Imports Entidad
Imports Negocio
Public Class WPregunta
    Public wAcc As New WAcceso
    Private ent As New SuperEntidad
    Private cam As New CamposEntidad
    Private usu As New UsuarioRN

#Region "Metodos"

    Sub NuevaVentana()
        '//
        Me.Owner.Enabled = False
        ent.DatoCondicion1 = Me.wAcc.txtUsu.Text.Trim
        'Traer el usuario
        ent = usu.buscarUsuarioExisActPorCodigo(ent)
        Me.Text = "Usuario: " + ent.CodigoUsuario
        Me.lblPregunta.Text = ent.NombrePregunta
        Me.Show()
        '\\
    End Sub

    Sub obtenerClave()
        '//
        Dim rpta As String = Me.txtRpta.Text.Trim
        If rpta = ent.RespuestaUsuario Then
            MsgBox(ent.CodigoUsuario + " Tu clave es :" + Varios.desencriptar(ent.ClaveUsuario), MsgBoxStyle.Information)
            Me.Close()
        Else
            MsgBox("Respuesta incorrecta", MsgBoxStyle.Exclamation)
            Me.txtRpta.Text = ""
            Me.txtRpta.Focus()
        End If
        '\\
    End Sub

#End Region

    Private Sub WPregunta_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
        Me.wAcc.txtCla.Focus()
    End Sub

    Private Sub txtRpta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRpta.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then : Me.obtenerClave() : End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub WPregunta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnIngresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIngresar.Click
        Me.obtenerClave()
    End Sub
End Class