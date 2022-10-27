Imports Entidad
Imports Negocio

Public Class WCopiaPermiso
#Region "Propietarios"
    Public wUsu As New WUsuario
#End Region

    Public listaPc, listaPcE As New List(Of SuperEntidad)
    Public usu As New UsuarioRN
    Public per As New PermisoRN
    Public cam As New CamposEntidad
    Public ent As New SuperEntidad
    Public titulo As String = "Permiso"
    Public acc As New Accion

#Region "Metodos"


    Sub NuevaVentana(ByVal CodUsu As String)
        '//
        '/Para los eventos de controles
        acc.listaCtrls = Me.ListaControles
        acc.PasaFoco()
        acc.FomatoDato()
        acc.PasarCursor()
        acc.Teclazo()
        acc.Valida()
        Me.Owner.Enabled = False
        Me.Show()
        'visualiza el formulario
        Me.valoresPorDefecto(CodUsu)
        Me.txtCodUsuC.Focus()
        '\\
    End Sub


    Sub valoresPorDefecto(ByRef CodUsu As String)
        Dim oUsu As New SuperEntidad
        oUsu.DatoCondicion1 = CodUsu
        oUsu = usu.buscarUsuarioExisPorCodigo(oUsu)
        Me.txtCodUsuB.Text = oUsu.CodigoUsuario
        Me.txtNomUsuB.Text = oUsu.NombreUsuario
    End Sub


    Sub ListarUsuarios(ByVal e As System.Windows.Forms.KeyEventArgs)
        If Me.txtCodUsuC.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListaUsuarios
                win.titulo = "Usuarios"
                win.CondicionLista = "UsuariosExistentes"
                win.txt1 = Me.txtCodUsuC
                win.txt2 = Me.txtNomUsuC
                win.ctrlFoco = Me.btnAceptar
                win.NuevaVentana()
            End If
        End If
    End Sub


    Function EsCodigoUsuario() As Boolean
        Dim oUsu As New SuperEntidad
        oUsu.DatoCondicion1 = Me.txtCodUsuC.Text.Trim
        If oUsu.DatoCondicion1 = "" Then
            Me.ObtenerUsuario(oUsu)
            Return True
        Else
            oUsu = usu.buscarUsuarioExisPorCodigo(oUsu)
            If oUsu.CodigoUsuario = "" Then
                MsgBox("El codigo usuario no existe", MsgBoxStyle.Exclamation, Me.titulo)
                Me.ObtenerUsuario(usu.EnBlanco)
                Me.txtCodUsuC.Focus()
                Return False
            Else
                Me.ObtenerUsuario(oUsu)
                Return True
            End If
        End If
    End Function


    Function EsUsuarioDiferente() As Boolean
        Dim eAct As String = Me.txtCodUsuB.Text.Trim
        Dim eCop As String = Me.txtCodUsuC.Text.Trim
        If eCop = "" Then
            Return True
        Else
            If eCop = eAct Then
                MsgBox("No se puede hacer la copia del mismo usuario", MsgBoxStyle.Exclamation, Me.titulo)
                Me.ObtenerUsuario(usu.EnBlanco)
                Me.txtCodUsuC.Focus()
                Return False
            Else
                Return True
            End If
        End If
    End Function


    Function ComprobarUsuarioCopia() As Boolean
        If Me.EsCodigoUsuario = False Then Return False
        If Me.EsUsuarioDiferente = False Then Return False
        'Si todo sale bien
        Return True
    End Function


    Sub ObtenerUsuario(ByVal xUsu As SuperEntidad)
        '/Pasar Datos a los controles
        Me.txtCodUsuC.Text = xUsu.CodigoUsuario
        Me.txtNomUsuC.Text = xUsu.NombreUsuario
    End Sub


    Sub Copia()
        Dim lis As New List(Of SuperEntidad)
        Dim oPer As New SuperEntidad
        oPer.CodigoUsuario = Me.txtCodUsuC.Text.Trim
        oPer.CampoOrden = cam.CodVen
        lis = per.obtenerPermisosExisXUsuario(oPer)
        'Recorrer las cuentas 
        For Each obj As SuperEntidad In lis
            'Solo cambiar por el usuario base
            obj.CodigoUsuario = Me.txtCodUsuB.Text.Trim
            'Grabar
            per.modificarPermiso(obj)
        Next
        MsgBox("La copia se realiza satisfactoriamente", MsgBoxStyle.Information, Me.titulo)
        Me.Close()
    End Sub



    Sub Aceptar()
        'NO DEJAR EN BLANCO CODIGO COPIA
        If Me.txtCodUsuC.Text.Trim = "" Then
            MsgBox("No dejar en blanco el usuario copia", MsgBoxStyle.Critical, Me.titulo)
            Me.txtCodUsuC.Focus()
            Exit Sub
        End If
        'VER LA DISPONIBLIDAD DEL USUARIO PARA HACER LA COPIA
        If Me.ComprobarUsuarioCopia = False Then Exit Sub
        'OK
        Me.Copia()
    End Sub

#End Region


    Private Sub WEditarTabla_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub txtCodUsuC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodUsuC.KeyDown
        Me.ListarUsuarios(e)
    End Sub

    Private Sub txtCodUsuC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodUsuC.Validated
        Me.ComprobarUsuarioCopia()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.Aceptar()
    End Sub

    Private Sub txtCodUsuC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodUsuC.TextChanged

    End Sub
End Class