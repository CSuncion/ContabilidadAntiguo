Imports Entidad
Imports Negocio
Public Class WCambiarClave
#Region "Controles"
    Function Controles() As List(Of Control)
        Dim l As New List(Of Control)
        l.Add(Me.txtCla)
        l.Add(Me.txtClaN)
        l.Add(Me.txtClaC)
        l.Add(Me.btnCambiar)
        Return l
    End Function
#End Region
    Public ent As New SuperEntidad
    Public lista As New List(Of SuperEntidad)
    Public usu As New UsuarioRN
    Public cam As New CamposEntidad


#Region "Metodos"

    Sub nuevaVentana()
        Me.InicializaVentana()
    End Sub


    Sub InicializaVentana()
        '/Para los eventos de controles
        Dim ope As New Operacion
        ope.ObtenerFoco(Controles)
        ope.PasarCursor_ArribaAbajo(Controles)
        '/Ejecucion en ventana
        Me.Text = "Cambio De Clave"
        Me.Show()
    End Sub


    Function camposObligatorios() As Boolean
        '//
        If Me.txtCla.Text.Trim = "" Then
            MsgBox("no dejar en blanco / Campo: Clave actual", MsgBoxStyle.Critical)
            Me.txtCla.Focus()
            Return False
            Exit Function
        End If

        If Me.txtClaN.Text.Trim = "" Then
            MsgBox("no dejar en blanco / Campo: Clave nueva", MsgBoxStyle.Critical)
            Me.txtClaN.Focus()
            Return False
            Exit Function
        End If

        If Me.txtClaC.Text.Trim = "" Then
            MsgBox("no dejar en blanco / Campo: Clave confirmar", MsgBoxStyle.Critical)
            Me.txtClaC.Focus()
            Return False
            Exit Function
        End If

        Return True
        '\\
    End Function

    Function compararClaves() As Boolean
        '//
        If Me.txtClaN.Text.Trim = Me.txtClaC.Text.Trim Then
            Return True
        Else
            MsgBox("Las claves no coinciden", MsgBoxStyle.Information)
            Me.txtClaN.Text = ""
            Me.txtClaC.Text = ""
            Me.txtClaN.Focus()
            Return False
        End If
        '\\
    End Function

    Sub CambiarClave()
        '//
        ent.DatoCondicion1 = SuperEntidad.xCodigoUsuario
        ent = usu.buscarUsuarioExisActPorCodigo(ent)
        '/Pasando los nuevos cambios
        ent.ClaveUsuario = Varios.encriptar(Me.txtClaN.Text.Trim)
        '/modificar
        usu.modificarUsuario(ent)
        MsgBox("Tu clave ha sido actualizado correctamente")
        Me.Close()
    End Sub

#End Region


#Region "Validating"

    Private Sub txtCla_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCla.Validating
        Dim clave As String = Varios.encriptar(Me.txtCla.Text.Trim)
        ent.DatoCondicion1 = SuperEntidad.xCodigoUsuario
        ent.DatoCondicion2 = clave
        If clave = "" Then
            Exit Sub
        Else
            If usu.existeUsuarioExisActPorCodigoYClave(ent) = False Then
                MsgBox("La clave no existe", MsgBoxStyle.Exclamation)
                Me.txtCla.Text = ""
                Txt.cursorAlUltimo(Me.txtCla)
            Else
                Exit Sub
            End If
        End If

    End Sub


#End Region

#Region "KeyPress"
    Private Sub txtCla_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCla.KeyPress
        Validar.kClave(e)
    End Sub

    Private Sub txtClaN_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtClaN.KeyPress
        Validar.kClave(e)
    End Sub

    Private Sub txtClaC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtClaC.KeyPress
        Validar.kClave(e)
    End Sub
#End Region


    
    Private Sub btnCambiar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCambiar.Click
        If Me.camposObligatorios = False Then
            Exit Sub
        Else
            If Me.compararClaves = False Then
                Exit Sub
            Else
                Me.CambiarClave()

            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
   
        Dim rpta As Integer = MsgBox("Deseas cancelar la operacion", MsgBoxStyle.YesNo)
        If rpta = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub txtClaN_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtClaN.Validating
        If Me.txtClaN.Text.Trim <> "" Then
            Dim claveN As String = Me.txtClaN.Text.Trim
            If Varios.LimiteMinMaxDeCaracteres(claveN, 6, 20) = False Then
                MsgBox("La clave como minimo debe tener 6 caracteres y maximo 20", MsgBoxStyle.Information)
                Me.txtClaN.Text = ""
                Me.txtClaN.Focus()
            End If
        End If
        
    End Sub

    Private Sub txtClaC_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtClaC.Validating
        If Me.txtClaC.Text.Trim <> "" Then
            Dim claveC As String = Me.txtClaC.Text.Trim
            If Varios.LimiteMinMaxDeCaracteres(claveC, 6, 20) = False Then
                MsgBox("La clave como minimo debe tener 6 caracteres y maximo 20", MsgBoxStyle.Information)
                Me.txtClaC.Text = ""
                Me.txtClaC.Focus()
            End If
        End If
       
    End Sub

  
End Class