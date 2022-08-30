Imports Entidad
Imports Negocio
Public Class WAlmacen
    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public alm As New AlmacenRN
    Public cam As New CamposEntidad
    Public ent As New SuperEntidad
    Public titulo As String = "Items"


#Region "Metodos"

    Sub NuevaVentana()
        '//
        Me.Show()
        ent.CampoOrden = cam.CodAlm
        ent.ColumnaBusqueda = "Codigo"
        Me.ActualizarVentana()
        '\\
    End Sub

    Sub permisoVentana()
        'Dim perTabla As New PermisoTablaRN
        'Dim pt As New PermisoEN
        'Dim obj As New SuperEntidad
        'obj.DatoCondicion1 = SuperEntidad.xCodigoGrupo
        'obj.DatoCondicion2 = cam.CliPro
        'pt = perTabla.buscarPermisoTablaExisPorCodigoyTabla(obj)

        'If pt.Agregar = "1" Then
        '    Me.btnAdicionar.Enabled = True
        'Else
        '    Me.btnAdicionar.Enabled = False
        'End If

        'If Me.DgvAlm.RowCount <> 0 Then

        '    If pt.Modificar = "1" Then
        '        Me.btnModificar.Enabled = True
        '    Else
        '        Me.btnModificar.Enabled = False
        '    End If

        '    If pt.Eliminar = "1" Then
        '        Me.btnEliminar.Enabled = True
        '    Else
        '        Me.btnEliminar.Enabled = False
        '    End If

        '    If pt.Consultar = "1" Then
        '        Me.btnVisualizar.Enabled = True
        '    Else
        '        Me.btnVisualizar.Enabled = False
        '    End If

        'End If
    End Sub

    Sub ActualizarVentana()
        '//
        Me.ActualizarDgvUsu()
        Dgv.actualizarBarraEstado(Me.sst1, Me.DgvAlm)
        acc.EstadoBotonesPorGrilla(Me.ListaBotones, Me.DgvAlm)
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvAlm)
        Dgv.pintarColumnaDgv(Me.DgvAlm, ent.CampoOrden)
        'Me.permisoVentana()
        '\\
    End Sub

    Sub ActualizarDgvUsu()
        '//
        '/Refrescando el DataSource de DgvUsu
        lista = alm.obtenerAlmacenExis(ent)
        '/Refrescando el DataSource de DgvUsu

        Dgv.refrescarFuenteDatosGrilla(Me.DgvAlm, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvAlm, cam.CodAlm, "Codigo", 100)
        Dgv.asignarColumnaText(Me.DgvAlm, cam.NomAlm, "Nombre", 250)
        Dgv.asignarColumnaText(Me.DgvAlm, cam.ColAlm, "Color", 120)
        Dgv.asignarColumnaText(Me.DgvAlm, cam.MedAlm, "Medidas", 120)
        Dgv.asignarColumnaText(Me.DgvAlm, cam.SerAlm, "Serie", 120)
        Dgv.asignarColumnaText(Me.DgvAlm, cam.MarAlm, "Marca", 120)
        '//
    End Sub

    Sub Buscar()
        '//
        Dim win As New WBuscar
        win.wAlm = Me
        Me.AddOwnedForm(win)
        win.ventanaBuscar(ent.ColumnaBusqueda)
        '\\
    End Sub
    Sub adicionar()
        Dim win As New WEditarAlmacen
        win.wAlm = Me
        Me.AddOwnedForm(win)
        win.InicializaVentana()
    End Sub

    Sub modificar()
        '/Obtener el codigo de usuario
        '//
        Dim win As New WEditarAlmacen
        win.wAlm = Me
        win.operacion = 1
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvAlm, cam.CodAlm)
        win.ventanaModificar(cod)
        '\\
    End Sub

    Sub eliminar()
        '//
        Dim win As New WEditarAlmacen
        win.wAlm = Me
        win.operacion = 2
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvAlm, cam.CodAlm)
        win.ventanaEliminar(cod)
        '\\
    End Sub

    Sub visualizar()
        '//
        Dim win As New WEditarAlmacen
        win.wAlm = Me
        win.operacion = 3
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvAlm, cam.CodAlm)
        win.ventanaVisualizar(cod)
        '\\
    End Sub

    'Sub imprimir()
    '    '//
    '    Dim imp As New WImpAuxiliar
    '    imp.wAux = Me
    '    Me.AddOwnedForm(imp)
    '    imp.InicializaVentana()
    '    '\\
    'End Sub

    'Sub exportar()
    '    '//
    '    Dim imp As New WRptAux
    '    imp.wAux = Me
    '    imp.ent.CampoOrden = cam.CodAux
    '    imp.Exportar()
    '    ''\\
    'End Sub

    'Sub recycla()
    '    Dim win As New WAuxiliarRecycla
    '    win.wAux = Me
    '    Me.AddOwnedForm(win)
    '    win.NuevaVentana()
    'End Sub

#End Region



    Private Sub btnActualizarTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarTabla.Click
        Me.ActualizarVentana()
    End Sub

    Private Sub DgvAux_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvAlm.CellEnter
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvAlm)
    End Sub

    Private Sub DgvPer_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvAlm.ColumnHeaderMouseClick
        ent.CampoOrden = Me.DgvAlm.Columns(e.ColumnIndex).Name
        ent.ColumnaBusqueda = Me.DgvAlm.Columns(e.ColumnIndex).HeaderText
        Me.ActualizarVentana()
    End Sub

    Private Sub btnDesplaza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrimero.Click, btnAnterior.Click, btnSiguiente.Click, btnUltimo.Click
        Dgv.desplazamientoFila(Me.DgvAlm, CType(sender, ToolStripButton))
    End Sub

    Private Sub btnRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Me.Buscar()
    End Sub

    Private Sub btnAdicionar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdicionar.Click
        Me.adicionar()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Me.modificar()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Me.eliminar()
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        'Me.imprimir()
    End Sub

    Private Sub btnExportar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        'Me.exportar()
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Me.visualizar()
    End Sub

    Private Sub btnRecycla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecycla.Click
        'Me.recycla()
    End Sub
End Class