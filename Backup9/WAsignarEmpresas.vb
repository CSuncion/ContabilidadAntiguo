Imports Entidad
Imports Negocio


Public Class WAsignarEmpresas

    Public usEmRN As New PermisoEmpresaRN

    'SIRVE PARA OBTENER EL INDICE DEL REGISTRO
    'EN LA GRILLA ANTES DE ACTUALIZARLA
    Public iFil As Integer

    'SIRVE PARA OBTENER EL CODIGO DE EMPRESA QUE
    ' SE QUIERE QUITAR O  AGREGAR
    Dim codEmp As String


#Region "Propietarios"
    Public wUsu As New WUsuario
#End Region

#Region "Metodos"


    Sub valoresPorDefecto(ByVal objUsu As SuperEntidad)
        Me.txtCodUsu.Text = objUsu.CodigoUsuario
        Me.txtNomUsu.Text = objUsu.NombreUsuario
    End Sub


    Sub NuevaVentana(ByVal objUsu As SuperEntidad)
        '//
        Me.wUsu.Enabled = False
        Me.Show()
        Me.valoresPorDefecto(objUsu)
        Me.ActualizarDgvNoAut()
        Me.ActualizarDgvAsig()
        Me.HabilitarBotonesAgregar()
        Me.HabilitarBotonesQuitar()
        '\\
    End Sub


    Function ListarEmpresasNoAutorizadas() As List(Of PermisoEmpresaEN)
        Dim lisEmp As New List(Of PermisoEmpresaEN)
        Dim usEmEN As New PermisoEmpresaEN
        usEmEN.CodigoUsuario = Me.txtCodUsu.Text.Trim
        usEmEN.CampoOrden = PermisoEmpresaEN.CodEmp
        lisEmp = usEmRN.listarEmpresasNoAutorizadasXUsuario(usEmEN)
        Return lisEmp
    End Function


    Function ListarEmpresasAsignadas() As List(Of PermisoEmpresaEN)
        Dim lisEmp As New List(Of PermisoEmpresaEN)
        Dim usEmEN As New PermisoEmpresaEN
        usEmEN.CodigoUsuario = Me.txtCodUsu.Text.Trim
        usEmEN.CampoOrden = PermisoEmpresaEN.CodEmp
        lisEmp = usEmRN.listarEmpresasAsignadasXUsuario(usEmEN)
        Return lisEmp
    End Function


    Sub ActualizarDgvNoAut()
        'CARGAMOS LA GRILLA
        Dgv.refrescarFuenteDatosGrilla(Me.dgvNoAut, Me.ListarEmpresasNoAutorizadas)
        Dgv.asignarColumnaText(Me.dgvNoAut, PermisoEmpresaEN.CodEmp, "Codigo", 30)
        Dgv.asignarColumnaText(Me.dgvNoAut, PermisoEmpresaEN.NomCorEmp, "Descripcion", 185)
    End Sub


    Sub ActualizarDgvAsig()
        'CARGAMOS LA GRILLA
        Dgv.refrescarFuenteDatosGrilla(Me.dgvAsig, Me.ListarEmpresasAsignadas)
        Dgv.asignarColumnaText(Me.dgvAsig, PermisoEmpresaEN.CodEmp, "Codigo", 30)
        Dgv.asignarColumnaText(Me.dgvAsig, PermisoEmpresaEN.NomCorEmp, "Descripcion", 185)
    End Sub


    Sub HabilitarBotonesAgregar()
        Dim nr As Integer = Me.dgvNoAut.Rows.Count
        If nr = 0 Then
            Me.btnAgrega.Enabled = False
            Me.btnAgregaTodos.Enabled = False
        Else
            Me.btnAgrega.Enabled = True
            Me.btnAgregaTodos.Enabled = True
        End If
    End Sub


    Sub HabilitarBotonesQuitar()
        Dim nr As Integer = Me.dgvAsig.Rows.Count
        If nr = 0 Then
            Me.btnQuita.Enabled = False
            Me.btnQuitarTodos.Enabled = False
        Else
            Me.btnQuita.Enabled = True
            Me.btnQuitarTodos.Enabled = True
        End If
    End Sub


    Sub ActualizarVentanaSegunAgregar()
        Me.ActualizarDgvNoAut()
        Dgv.PonerFranja(Me.dgvNoAut, iFil)
        Me.ActualizarDgvAsig()
        Dgv.Buscar(Me.dgvAsig, PermisoEmpresaEN.CodEmp, codEmp)
        Me.HabilitarBotonesAgregar()
        Me.HabilitarBotonesQuitar()
    End Sub

    Sub ActualizarVentanaSegunQuitar()
        Me.ActualizarDgvAsig()
        Dgv.PonerFranja(Me.dgvAsig, iFil)
        Me.ActualizarDgvNoAut()
        Dgv.Buscar(Me.dgvNoAut, PermisoEmpresaEN.CodEmp, codEmp)
        Me.HabilitarBotonesAgregar()
        Me.HabilitarBotonesQuitar()
    End Sub


    Sub AgregarUno()
        Me.iFil = Me.dgvNoAut.CurrentRow.Index
        'TRAEMOS AL OBJETO USUARIOEMPRESA
        Dim cod As String = Dgv.obtenerValorCelda(Me.dgvNoAut, PermisoEmpresaEN.CodEmp)
        codEmp = cod
        Dim usemEN As New PermisoEmpresaEN
        usemEN.CodigoUsuario = Me.txtCodUsu.Text.Trim
        usemEN.CodigoEmpresa = cod
        usemEN = usEmRN.buscarUsuarioEmpresa(usemEN)

        'OBJETO PARA MODIFICAR SU PERMISO
        usemEN.EstadoPermisoEmpresa = 1
        usEmRN.modificarUsuarioEmpresa(usemEN)

        'ACTUALIZAR VENTANA
        Me.ActualizarVentanaSegunAgregar()
    End Sub


    Sub AgregarTodos()
        Dim lisUsuEmp As List(Of PermisoEmpresaEN) = Me.ListarEmpresasNoAutorizadas
        usEmRN.CambiarPermisoUsuarioEmpresas(1, lisUsuEmp) ' LE DAMOS LOS PERMISOS
        Me.ActualizarDgvNoAut()
        Me.ActualizarDgvAsig()
        Me.HabilitarBotonesAgregar()
        Me.HabilitarBotonesQuitar()
    End Sub


    Sub QuitarUno()
        Me.iFil = Me.dgvAsig.CurrentRow.Index
        'TRAEMOS AL OBJETO USUARIOEMPRESA
        Dim cod As String = Dgv.obtenerValorCelda(Me.dgvAsig, PermisoEmpresaEN.CodEmp)
        codEmp = cod
        Dim usemEN As New PermisoEmpresaEN
        usemEN.CodigoUsuario = Me.txtCodUsu.Text.Trim
        usemEN.CodigoEmpresa = cod
        usemEN = usEmRN.buscarUsuarioEmpresa(usemEN)

        'OBJETO PARA MODIFICAR SU PERMISO
        usemEN.EstadoPermisoEmpresa = 0
        usEmRN.modificarUsuarioEmpresa(usemEN)

        'ACTUALIZAR VENTANA
        Me.ActualizarVentanaSegunQuitar()
    End Sub


    Sub QuitarTodos()
        Dim lisUsuEmp As List(Of PermisoEmpresaEN) = Me.ListarEmpresasAsignadas
        usEmRN.CambiarPermisoUsuarioEmpresas(0, lisUsuEmp) ' LE QUITAMOS LOS PERMISOS
        Me.ActualizarDgvAsig()
        Me.ActualizarDgvNoAut()
        Me.HabilitarBotonesAgregar()
        Me.HabilitarBotonesQuitar()
    End Sub

    Sub CierraVentana()
        Me.Close()
    End Sub

#End Region


    Private Sub WEditarUsuario_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.wUsu.Enabled = True
    End Sub

    Private Sub btnAgrega_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgrega.Click
        Me.AgregarUno()
    End Sub

    Private Sub btnAgregaTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregaTodos.Click
        Me.AgregarTodos()
    End Sub

    Private Sub btnQuita_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuita.Click
        Me.QuitarUno()
    End Sub

    Private Sub btnQuitarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitarTodos.Click
        Me.QuitarTodos()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


End Class