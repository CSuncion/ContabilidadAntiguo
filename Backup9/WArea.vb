Option Strict Off
Imports Entidad
Imports Negocio

Public Class WArea

    Public per As New PermisoRN
    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public emp As New AreaRN
    Public cam As New CamposEntidad
    Public ent As New SuperEntidad
    Public titulo As String = "Areas"


#Region "Metodos"

    Sub NuevaVentana()
        '//
        'visualiza el formulario
        Me.Show()
        'orden por defecto
        ent.CampoOrden = cam.CodAre
        ent.ColumnaBusqueda = "Codigo"
        Me.ActualizarVentana()

        '\\
    End Sub

    Sub permisoVentana()
        Dim nReg As Integer = Me.DgvAre.Rows.Count
        Dim lisPer As New List(Of SuperEntidad)
        Dim oPer As New SuperEntidad
        oPer.CodigoUsuario = SuperEntidad.xCodigoUsuario
        oPer.CodigoVentana = "055"
        oPer.CampoOrden = cam.CodVen
        lisPer = per.obtenerPermisosExisXUsuarioYVentana(oPer)
        'RECORRER CADA PERMISO
        For Each p As SuperEntidad In lisPer
            ' 0 : NO TIENE PERMISO ,  1 : SI TIENE PERMISO
            Dim vf As Boolean = IIf(p.OpcionPermiso = 0, False, True)
            'SOLO PARA EL ADICIONAR
            If p.CodigoOpcion = "01" Then
                Me.btnAdicionar.Enabled = vf
            End If
            'SI LA GRILLA ESTA VACIA LA ACCION QUEDA DESHABILITADA
            If nReg = 0 Then vf = False

            'PASAR vf A LOS BOTONES DE LA VENTANA
            Select Case p.CodigoOpcion
                Case "02" : Me.btnModificar.Enabled = vf
                Case "03" : Me.btnEliminar.Enabled = vf
                Case "04" : Me.btnVisualizar.Enabled = vf
                    'Case "08" : Me.btnImprimir.Enabled = vf
            End Select
        Next
    End Sub

    Sub ActualizarVentana()
        '//
        Me.ActualizarDgvTab()
        Dgv.actualizarBarraEstado(Me.sst1, Me.DgvAre)
        acc.EstadoBotonesPorGrilla(Me.ListaBotones, Me.DgvAre)
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvAre)
        Dgv.pintarColumnaDgv(Me.DgvAre, ent.CampoOrden)
        Me.permisoVentana()
        '\\
    End Sub

    Sub ActualizarDgvTab()

        '//
        '/Refrescando el DataSource de DgvUsu
        ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        lista = emp.obtenerAreaExisXEmpresa(ent)

        '/Refrescando el DataSource de DgvUsu
        Dgv.refrescarFuenteDatosGrilla(Me.DgvAre, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvAre, cam.CodAre, "Codigo", 60)
        Dgv.asignarColumnaText(Me.DgvAre, cam.NomAre, "Nombre", 290)
        Dgv.asignarColumnaText(Me.DgvAre, cam.EstAre, "Estado", 110)
        Dgv.asignarColumnaTextVis(Me.DgvAre, cam.ClaAre, "Clave", 60, 0)
        '//
    End Sub

    Sub buscar()
        '//
        Dim win As New WBuscar
        win.wAre = Me
        Me.AddOwnedForm(win)
        win.ventanaBuscar(ent.ColumnaBusqueda)
        '\\
    End Sub

    Sub adicionar()
        '//
        Dim win As New WEditarArea
        win.wAre = Me
        win.operacion = 0
        Me.AddOwnedForm(win)
        win.ventanaAdicionar()
        '\\
    End Sub


    Sub modificar()
        '//
        Dim win As New WEditarArea
        win.wAre = Me
        win.operacion = 1
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvAre, cam.ClaAre)
        win.ventanaModificar(cod)
        '\\
    End Sub

    Sub eliminar()
        '//
        Dim win As New WEditarArea
        win.wAre = Me
        win.operacion = 2
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvAre, cam.ClaAre)
        win.ventanaEliminar(cod)
        '\\
    End Sub

    Sub Visualizar()
        '//
        Dim win As New WEditarArea
        win.wAre = Me
        win.operacion = 3
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvAre, cam.ClaAre)
        win.ventanaVisualizar(cod)
        '\\
    End Sub

    Sub imprimir()
        '    '//
        '    Dim imp As New WImpTabla
        '    imp.wTab = Me
        '    Me.AddOwnedForm(imp)
        '    imp.nuevaVentana()
        '    '\\

    End Sub


    Sub recycla()
        'Dim win As New WFilesRecycla
        'win.wEmp = Me
        'Me.AddOwnedForm(win)
        'win.NuevaVentana()
    End Sub

#End Region

    Private Sub btnActualizarTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarTabla.Click
        Me.ActualizarVentana()
    End Sub

    Private Sub DgvDis_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvAre.CellEnter
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvAre)
    End Sub

    Private Sub DgvDis_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvAre.ColumnHeaderMouseClick
        ent.CampoOrden = Me.DgvAre.Columns(e.ColumnIndex).Name
        ent.ColumnaBusqueda = Me.DgvAre.Columns(e.ColumnIndex).HeaderText
        Me.ActualizarVentana()
    End Sub

    Private Sub btnDesplaza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrimero.Click, btnAnterior.Click, btnSiguiente.Click, btnUltimo.Click
        Dgv.desplazamientoFila(Me.DgvAre, CType(sender, ToolStripButton))
    End Sub

    Private Sub btnRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Me.buscar()
    End Sub

    Private Sub btnAdicionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdicionar.Click
        Me.adicionar()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Me.modificar()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Me.eliminar()
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        '  Me.imprimir()
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Me.Visualizar()
    End Sub

    Private Sub btnRecycla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Me.recycla()
    End Sub

End Class




