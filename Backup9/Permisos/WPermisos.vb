Imports Entidad
Imports Negocio

Public Class WPermisos
#Region "Propietarios"
    Public wUsu As New WUsuario
#End Region

    Public listaAd, listaPe As New List(Of SuperEntidad)
    Public ven As New VentanaRN
    Public per As New PermisoRN
    Public usu As New UsuarioRN
    Public cam As New CamposEntidad
    Public ent As New SuperEntidad
    'Public titulo As String = "PlanDeCuentas"
    Public codVen As String
    Dim regActual As Integer = 0

#Region "Metodos"

    Sub valoresPorDefecto(ByRef CodUsu As String)
        Dim oUsu As New SuperEntidad
        oUsu.DatoCondicion1 = CodUsu
        oUsu = usu.buscarUsuarioExisPorCodigo(oUsu)
        Me.txtCodUsu.Text = oUsu.CodigoUsuario
        Me.txtNomUsu.Text = oUsu.NombreUsuario
    End Sub

    Sub NuevaVentana(ByVal CodUsu As String)
        '//
        Me.Owner.Enabled = False
        Me.Show()
        'visualiza el formulario
        Me.valoresPorDefecto(CodUsu)
        'MOSTRAR TODAS LAS VENTANAS DE PERMISOS
        Me.ActualizarDgvVen()
        Me.dgvVen.Focus()
        '\\
    End Sub


    Sub ActualizarDgvVen()
        'TRAER TODAS LAS VENTANAS
        Dim iListaVentanas As New List(Of SuperEntidad)
        Dim iVen As New SuperEntidad
        iVen.CampoOrden = cam.NomVen
        iListaVentanas = ven.obtenerVentanaExis(iVen)
        '/Refrescando el DataSource de DgvUsu
        Dgv.refrescarFuenteDatosGrilla(Me.dgvVen, iListaVentanas)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.dgvVen, cam.NomVen, "Ventanas", 300)
        Dgv.asignarColumnaTextVis(Me.dgvVen, cam.CodVen, "CodigoVentana", 250, 0)
    End Sub



    Sub ActualizarDgvAccD(ByVal codVen As String)
        '//
        '/Refrescando el DataSource de DgvUsu
        ent.CodigoUsuario = Me.txtCodUsu.Text.Trim
        ent.CodigoVentana = codVen
        ent.CampoOrden = cam.CodOpc
        listaAd = per.obtenerOpcionesDisponiblesExisXVentana(ent)


        '/Refrescando el DataSource de DgvUsu
        Dgv.refrescarFuenteDatosGrilla(Me.DgvAccD, listaAd)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvAccD, cam.NomOpc, "Acciones Disponibles", 170)
        Dgv.asignarColumnaTextVis(Me.DgvAccD, cam.CodOpc, "Codigo", 10, 0)
        '//
    End Sub

    Sub ActualizarDgvPer(ByVal codVen As String)
        '//
        '/Refrescando el DataSource de DgvUsu
        ent.CodigoUsuario = Me.txtCodUsu.Text.Trim
        ent.CodigoVentana = codVen
        ent.CampoOrden = cam.CodOpc
        listaPe = per.obtenerPermisosExisXVentana(ent)

        '/Refrescando el DataSource de DgvUsu
        Dgv.refrescarFuenteDatosGrilla(Me.dgvPer, listaPe)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.dgvPer, cam.NomOpc, "Permisos", 170)
        Dgv.asignarColumnaTextVis(Me.dgvPer, cam.CodOpc, "Codigo", 10, 0)
        '//
    End Sub


    Sub HabilitarBotonesAgregar()
        Dim nr As Integer = Me.DgvAccD.Rows.Count
        If nr = 0 Then
            Me.btnAgrega.Enabled = False
            Me.btnAgregaTodos.Enabled = False
        Else
            Me.btnAgrega.Enabled = True
            Me.btnAgregaTodos.Enabled = True
        End If
    End Sub

    Sub HabilitarBotonesQuitar()
        Dim nr As Integer = Me.dgvPer.Rows.Count
        If nr = 0 Then
            Me.btnQuita.Enabled = False
            Me.btnQuitarTodos.Enabled = False
        Else
            Me.btnQuita.Enabled = True
            Me.btnQuitarTodos.Enabled = True
        End If
    End Sub


    Sub MantenerIndiceFilaDgv(ByRef wdgv As DataGridView)
        Dim nr As Integer = wdgv.Rows.Count

        If nr <> 0 Then
            If Me.regActual >= nr Then
                wdgv.CurrentCell = wdgv.Item(0, nr - 1)
            Else
                wdgv.CurrentCell = wdgv.Item(0, Me.regActual)
            End If
        End If
    End Sub


    Sub ActualizarVentanaSegunAgregar()
        'Me.regActCG = Me.DgvCueGen.CurrentRow.Index
        Me.ActualizarDgvAccD(Me.codVen)
        Me.MantenerIndiceFilaDgv(Me.DgvAccD)
        Me.ActualizarDgvPer(Me.codVen)
        Dgv.obtenerCursorActual(Me.dgvPer, ent.CodigoOpcion, Me.listaPe)
        Me.HabilitarBotonesAgregar()
        Me.HabilitarBotonesQuitar()
    End Sub

    Sub ActualizarVentanaSegunQuitar()
        'Me.regActCG = Me.DgvCueGen.CurrentRow.Index
        Me.ActualizarDgvPer(Me.codVen)
        Me.MantenerIndiceFilaDgv(Me.dgvPer)
        Me.ActualizarDgvAccD(Me.codVen)
        Dgv.obtenerCursorActual(Me.DgvAccD, ent.CodigoOpcion, Me.listaAd)
        Me.HabilitarBotonesAgregar()
        Me.HabilitarBotonesQuitar()
    End Sub

    Sub ModificarPermiso(ByRef xPer As SuperEntidad, ByRef flag As Integer)
        xPer.CodigoUsuario = Me.txtCodUsu.Text.Trim
        xPer.CodigoVentana = Me.codVen
        xPer = per.buscarPermisoExisPorUsuarioYVentanaYOpcion(xPer)
        'Modificar (le damos el permiso)
        xPer.OpcionPermiso = flag
        per.modificarPermiso(xPer)
    End Sub

    Sub AgregarUno()
        Me.regActual = Me.DgvAccD.CurrentRow.Index
        'Obtener el codigo de la cuenta que se quiere agregar
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvAccD, cam.CodOpc)
        ent.CodigoOpcion = cod
        'OBJETO PARA MODIFICAR SU PERMISO
        Dim oPer As New SuperEntidad
        oPer.CodigoOpcion = cod
        'Modificar (le damos el permiso=1)
        Me.ModificarPermiso(oPer, 1)
        Me.ActualizarVentanaSegunAgregar()
        Me.dgvVen.Focus()
    End Sub

    Sub AgregarTodos()
        Me.regActual = Me.DgvAccD.CurrentRow.Index
        Dim oPer As New SuperEntidad
        'Recorrer cada cuenta para ser agregada
        For n As Integer = 0 To Me.DgvAccD.Rows.Count - 1
            oPer.CodigoOpcion = Me.DgvAccD.Item(cam.CodOpc, n).Value.ToString
            'Modificar (le damos el permiso=1)
            Me.ModificarPermiso(oPer, 1)
        Next
        Me.ActualizarVentanaSegunAgregar()
        Me.dgvVen.Focus()
    End Sub

    Sub QuitarUno()
        Me.regActual = Me.dgvPer.CurrentRow.Index
        'Obtener el codigo de la cuenta que se quiere agregar
        Dim cod As String = Dgv.obtenerValorCelda(Me.dgvPer, cam.CodOpc)
        ent.CodigoOpcion = cod
        'OBJETO PARA MODIFICAR SU PERMISO
        Dim oPer As New SuperEntidad
        oPer.CodigoOpcion = cod
        'Modificar (le quitamos el permiso=0)
        Me.ModificarPermiso(oPer, 0)
        Me.ActualizarVentanaSegunQuitar()
        Me.dgvVen.Focus()
    End Sub

    Sub QuitarTodos()
        Me.regActual = Me.dgvPer.CurrentRow.Index
        Dim oPer As New SuperEntidad
        'Recorrer cada cuenta para ser agregada
        For n As Integer = 0 To Me.dgvPer.Rows.Count - 1
            oPer.CodigoOpcion = Me.dgvPer.Item(cam.CodOpc, n).Value.ToString
            'Modificar (le quitamos el permiso=0)
            Me.ModificarPermiso(oPer, 0)
        Next
        Me.ActualizarVentanaSegunAgregar()
        Me.dgvVen.Focus()
    End Sub

#End Region

    Private Sub WEditarTabla_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
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

    Private Sub dgvVen_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvVen.CellEnter
        Me.lblTitulo.Text = "Dando permisos a la ventana : " + Dgv.obtenerValorCelda(Me.dgvVen, cam.NomVen)
        Me.codVen = Dgv.obtenerValorCelda(Me.dgvVen, cam.CodVen)
        Me.ActualizarDgvAccD(Me.codVen)
        Me.ActualizarDgvPer(Me.codVen)
        Me.HabilitarBotonesAgregar()
        Me.HabilitarBotonesQuitar()
    End Sub
End Class