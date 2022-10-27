Imports Entidad
Imports Negocio

Public Class WAcceso

    Private ent As New SuperEntidad
    Private cam As New CamposEntidad
    Private lista As New List(Of SuperEntidad)
    Private acc As New Accion

#Region "Metodos"

    Sub nuevaVentana()
        Me.InicializaVentana()
        Me.MostrarPersistencia()
        Me.ShowDialog()
    End Sub


    Sub AccesoSistema()
        '//
        Dim iUsuRN As New UsuarioRN
        If acc.CamposObligatorios = False Then
            Exit Sub
        Else
            'validar que la empresa sea del usuario
            If Me.ValidarEmpresaDeUsuario() = False Then Exit Sub

            'Validar Periodo
            If Me.EsPeriodoValido = False Then
                Return
            End If

            'validar la contraseña
            ent.DatoCondicion1 = Me.txtUsu.Text.Trim
            'ent.DatoCondicion2 = Me.txtCla.Text.Trim
            ent.DatoCondicion2 = Varios.encriptar(Me.txtCla.Text.Trim)
            If iUsuRN.existeUsuarioExisActPorCodigoYClave(ent) = True Then
                '/Traemos el usuario existente
                ent = iUsuRN.buscarUsuarioExisActPorCodigo(ent)
                '/Variables compartidas
                SuperEntidad.xCodigoUsuario = ent.CodigoUsuario
                SuperEntidad.xNombreUsuario = ent.NombreUsuario
                ' SuperEntidad.xCodigoPersonal = ent.CodigoPersonalUsuario
                'pasar la empresa
                SuperEntidad.xCodigoEmpresa = Me.TxtCodEmp.Text.Trim
                SuperEntidad.xRazonSocial = Me.TxtNomEmp.Text.Trim
                SuperEntidad.xPeriodoEmpresa = Me.TxtPerEmp.Text.Trim
                SuperEntidad.xMesPeriodo = Me.TxtNomMes.Text.Trim
                SuperEntidad.xRucEmpresa = Me.TxtCodRuc.Text.Trim

                Me.GuardarPersistencia()
                'Cambiar Periodo
                Me.CambiarPeriodo()

                '/Registrar ingreso al sistema
                'Me.Dispose()
                Me.Close()
            Else
                MsgBox("Acceso denegado", MsgBoxStyle.Exclamation)
                Me.txtCla.Text = ""
                Me.txtCla.Focus()
            End If
        End If

        '\\
    End Sub

    Sub CambiarPeriodo()
        Dim iPermRN As New PermisoEmpresaRN
        Dim iPermEN As New PermisoEmpresaEN
        iPermEN.CodigoUsuario = Me.txtUsu.Text.Trim
        iPermEN.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        iPermEN.PeriodoPermisoEmpresa = Me.TxtPerEmp.Text.Trim
        iPermRN.ModificarPeriodoPermisoEmpresa(iPermEN)
    End Sub

    Sub PreguntaSecreta()
        '//
        Me.txtCla.Text = ""
        Dim win As New WPregunta
        win.wAcc = Me
        Me.AddOwnedForm(win)
        win.NuevaVentana()
        '\\
    End Sub

    Sub InicializaVentana()
        ''/Para los eventos de controles
        acc.listaCtrls = Me.ListaControles
        acc.PasaFoco()
        acc.FomatoDato()
        acc.PasarCursor()
        acc.Teclazo()
        acc.Valida()
    End Sub

    Sub ValidarUsuario(ByRef e As System.ComponentModel.CancelEventArgs)
        Dim usu As New SuperEntidad
        usu.DatoCondicion1 = Me.txtUsu.Text.Trim
        usu.CodigoUsuario = Me.txtUsu.Text.Trim
        If usu.CodigoUsuario = "" Then
            Me.MostrarUsuario(usu)
        Else
            Dim iUsuRN As New UsuarioRN
            usu = iUsuRN.buscarUsuarioExisActPorCodigo(usu)
            Me.MostrarUsuario(usu)
            If usu.CodigoUsuario = "" Then
                MsgBox("Usuario no existe", MsgBoxStyle.Exclamation, "Usuario")
                Me.txtUsu.Focus()
                e.Cancel = True
            End If
        End If
    End Sub

    Sub MostrarUsuario(ByVal usu As SuperEntidad)
        Me.txtUsu.Text = usu.CodigoUsuario
        Me.txtNomUsu.Text = usu.NombreUsuario
    End Sub

    Sub ValidarEmpresa(ByRef e As System.ComponentModel.CancelEventArgs)
        Dim usEmEN As New PermisoEmpresaEN
        Dim usEmRN As New PermisoEmpresaRN
        usEmEN.CodigoUsuario = Me.txtUsu.Text.Trim
        usEmEN.CodigoEmpresa = Me.txtCodEmp.Text.Trim
        If usEmEN.CodigoEmpresa = String.Empty Then
            Me.MostrarEmpresa(usEmRN.UsuarioEmpresaEnBlanco)
        Else
            usEmEN = usEmRN.buscarEmpresaDeUsuario(usEmEN)
            Me.MostrarEmpresa(usEmEN)
            If usEmEN.CodigoEmpresa = String.Empty Then
                MsgBox("Empresa no existe o esta restringida para este usuario", MsgBoxStyle.Exclamation, "Empresa")
                Me.txtCodEmp.Focus()
                e.Cancel = True
            End If
        End If
    End Sub

    Function ValidarEmpresaDeUsuario() As Boolean
        Dim usEmEN As New PermisoEmpresaEN
        Dim usEmRN As New PermisoEmpresaRN
        usEmEN.CodigoUsuario = Me.txtUsu.Text.Trim
        usEmEN.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        usEmEN = usEmRN.buscarEmpresaDeUsuario(usEmEN)
        If usEmEN.CodigoEmpresa = String.Empty Then
            MsgBox("Empresa no existe o esta restringida para este usuario", MsgBoxStyle.Exclamation, "Empresa")
            Me.TxtCodEmp.Focus()
            Return False
        Else
            Return True
        End If
    End Function

    Sub MostrarEmpresa(ByVal usuEmp As PermisoEmpresaEN)
        Me.txtCodEmp.Text = usuEmp.CodigoEmpresa
        Me.TxtNomEmp.Text = usuEmp.RazonSocialEmpresa
        Me.TxtPerEmp.Text = usuEmp.PeriodoPermisoEmpresa
        Me.TxtCodRuc.Text = usuEmp.RucEmpresa
    End Sub

    Sub ListarEmpresasDeUsuario()
        Dim win As New WLisEmp
        Me.AddOwnedForm(win)
        win.tituloVentana = "Empresas"
        win.ctrlValor = Me.txtCodEmp
        win.ctrlFoco = Me.btnIngresar
        win.usEmEN.CodigoUsuario = Me.txtUsu.Text.Trim
        win.condicionLista = WLisEmp.Condicion.EmpresasDeUsuario
        win.NuevaVentana()
    End Sub

    Sub MostrarPersistencia()
        Me.txtNomUsu.Text = My.Settings.GuardarNombreUsuario
        Me.txtUsu.Text = My.Settings.GuardarCodigoUsuario
        Me.txtCla.Text = My.Settings.GuardarClave
        Me.TxtCodEmp.Text = My.Settings.GuardarCodigoEmpresa
        Me.TxtNomEmp.Text = My.Settings.GaurdarNombreEmpresa
        Me.TxtCodRuc.Text = My.Settings.GuardarRucEmpresa
        Me.TxtPerEmp.Text = My.Settings.GuardarPeriodoEmpresa
        Me.TxtNomMes.Text = My.Settings.GuardarMesPeriodo
        Me.ckbUsu.Checked = My.Settings.GuardarCheckUsuario
        Me.ckbCla.Checked = My.Settings.GuardarCheckClave
        Me.ckbEmp.Checked = My.Settings.GuardarCheckEmpresa
    End Sub

    Sub GuardarPersistencia()
        'guardar el check (persistir usuario)
        If Me.ckbUsu.Checked = True Then
            My.Settings.GuardarCheckUsuario = True
            My.Settings.GuardarCodigoUsuario = Me.txtUsu.Text.Trim
            My.Settings.GuardarNombreUsuario = Me.txtNomUsu.Text.Trim
        Else
            My.Settings.GuardarCheckUsuario = False
            My.Settings.GuardarCodigoUsuario = ""
            My.Settings.GuardarNombreUsuario = ""
        End If
        If Me.ckbCla.Checked = True Then
            My.Settings.GuardarCheckClave = True
            My.Settings.GuardarClave = Me.txtCla.Text.Trim
        Else
            My.Settings.GuardarCheckClave = False
            My.Settings.GuardarClave = ""
        End If
        If Me.ckbEmp.Checked = True Then
            My.Settings.GuardarCheckEmpresa = True
            My.Settings.GuardarCodigoEmpresa = Me.TxtCodEmp.Text.Trim
            My.Settings.GaurdarNombreEmpresa = Me.TxtNomEmp.Text.Trim
            My.Settings.GuardarPeriodoEmpresa = Me.TxtPerEmp.Text.Trim
            My.Settings.GuardarMesPeriodo = Me.TxtNomMes.Text.Trim
            My.Settings.GuardarRucEmpresa = Me.TxtCodRuc.Text.Trim
        Else
            My.Settings.GuardarCheckEmpresa = False
            My.Settings.GuardarCodigoEmpresa = ""
            My.Settings.GaurdarNombreEmpresa = ""
            My.Settings.GuardarPeriodoEmpresa = ""
            My.Settings.GuardarMesPeriodo = ""
            My.Settings.GuardarRucEmpresa = ""
        End If
        '    //guardar todos los datos
        My.Settings.Save()
    End Sub

    Public Function EsPeriodoValido() As Boolean
        Dim iPerRN As New PeriodoRN
        Dim iPerEN As New SuperEntidad
        iPerEN.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        iPerEN.CodigoPeriodo = Me.TxtPerEmp.Text.Trim
        iPerEN = iPerRN.EsPeriodoValido(iPerEN)
        If iPerEN.EsVerdad = False Then
            MsgBox(iPerEN.Mensaje, MsgBoxStyle.Exclamation, "Periodo")
            Me.TxtPerEmp.Focus()
        End If
        Me.MostarPeriodo(iPerEN)
        Return iPerEN.EsVerdad
    End Function

    Sub MostarPeriodo(ByRef pPer As SuperEntidad)
        Me.TxtPerEmp.Text = pPer.CodigoPeriodo
        Me.TxtNomMes.Text = pPer.NMesPeriodo
    End Sub



#End Region

    Private Sub cmbGru_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbGru.SelectionChangeCommitted
        'Me.CargarUsuariosPorGrupo()
    End Sub

    Private Sub btnIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngresar.Click
  
        Me.AccesoSistema()

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        End

    End Sub


    Private Sub llClave_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        If acc.CamposObligatorios = False Then
            Exit Sub
        Else
            Me.PreguntaSecreta()
        End If

    End Sub

    Private Sub txtNomPer_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNomUsu.Enter
        Me.cmbUsu.Focus()
    End Sub

   
#Region "Listar formularios"
    Private Sub txtCodUsu_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUsu.KeyDown
        If Me.txtUsu.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListaUsuarios
                win.titulo = "Usuarios"
                win.CondicionLista = "UsuariosActivos"
                win.txt1 = Me.txtUsu
                win.txt2 = Me.txtNomUsu
                win.txt3 = Me.txtGru
                win.ctrlFoco = Me.txtCla
                win.NuevaVentana()
            End If
        End If
    End Sub
    Private Sub txtCodEmp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodEmp.KeyDown
        If e.KeyCode = Keys.F1 Then
            Me.ListarEmpresasDeUsuario()
        End If
    End Sub
#End Region

#Region "Buscar Por Codigo"

    Private Sub txtCodEmp_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodEmp.Validating
          Me.ValidarEmpresa(e)
    End Sub

#End Region

  


    Private Sub txtUsu_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtUsu.Validating
        Me.ValidarUsuario(e)
    End Sub

    Private Sub TxtPerEmp_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtPerEmp.Validating
        Me.EsPeriodoValido()
    End Sub

    Private Sub TxtPerEmp_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPerEmp.KeyDown
        If Me.TxtPerEmp.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarPeriodos
                win.titulo = "Periodos Activos"
                win.ent.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
                win.tabla = "PeriodosActivos"
                win.txt1 = Me.TxtPerEmp
                win.txt2 = Me.TxtNomMes
                win.ctrlFoco = Me.btnIngresar
                win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub TxtCodEmp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodEmp.TextChanged

    End Sub
End Class

