Imports Entidad
Imports Negocio
Public Class WMeses
    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public tab As New TablaRN
    Public cam As New CamposEntidad
    Public ent As New SuperEntidad
    Public tabla As String

#Region "Metodos"
    Sub NuevaVentana()
        '//
        Me.Show()
        ' acc.listaTsps = Me.ListaBotones
        ent.CampoOrden = cam.CodItemTabla
        ent.ColumnaBusqueda = "Codigo"
        Me.ActualizarVentana()
        '\\
    End Sub

    Sub ActualizarVentana()
        '//
        Me.ActualizarDgvMes()
        Dgv.actualizarBarraEstado(Me.sst1, Me.DgvMes)
        acc.EstadoBotonesPorGrilla(Me.ListaBotones, Me.DgvMes)
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvMes)
        Dgv.pintarColumnaDgv(Me.DgvMes, ent.CampoOrden)
        '\\
    End Sub


    Sub ActualizarDgvMes()
        '//
        ent.Filtro = tabla
        lista = tab.filtrarItemsTablaPorTabla(ent)
        '/Refrescando el DataSource de DgvUsu
        Dgv.refrescarFuenteDatosGrilla(Me.DgvMes, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvMes, cam.CodItemTabla, "Codigo", 80)
        Dgv.asignarColumnaText(Me.DgvMes, cam.NomItemTabla, "Nombre", 100)
        Dgv.asignarColumnaText(Me.DgvMes, cam.NumDiasItemTabla, "Num Dias", 80)
        Dgv.asignarColumnaText(Me.DgvMes, cam.EstItemTabla, "Estado", 80)
        '//
    End Sub

    Sub buscar()
        '//
        Dim win As New WBuscar
        win.wMes = Me
        Me.AddOwnedForm(win)
        win.ventanaBuscar(ent.ColumnaBusqueda)
        '\\
    End Sub

    Sub adicionar()
        '//
        Dim win As New WEditarMes
        win.wMes = Me
        Me.AddOwnedForm(win)
        win.ventanaAdicionar()
        '\\
    End Sub

    Sub modificar()
        '//
        Dim win As New WEditarMes
        win.wMes = Me
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvMes, 0)
        win.ventanaModificar(cod)
        '\\
    End Sub


    Sub eliminar()
        '//
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvMes, 0)
        Dim rpt As Integer = MsgBox("Deseas eliminar este registro", MsgBoxStyle.YesNo)
        If rpt = MsgBoxResult.Yes Then
            ent.TipoTabla = tabla
            ent.CodigoItemTabla = cod
            tab.eliminarItemTablaLog(ent)
            MsgBox("registro Eliminado", MsgBoxStyle.Information)
            Me.ActualizarVentana()
        Else
            Exit Sub
        End If
        '\\       
    End Sub

    Sub imprimir()
        '//
        Dim imp As New WImprimirTablas
        imp.wMes = Me
        Me.AddOwnedForm(imp)
        imp.nuevaVentana()
        '\\
    End Sub

    Sub exportar()
        '//
        'Dim imp As New WImpDis
        'imp.wTab = Me
        'imp.Exportar()
        '\\
    End Sub



#End Region




    Private Sub btnActualizarTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarTabla.Click
        Me.actualizarVentana()
    End Sub

    Private Sub DgvMes_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvMes.CellEnter
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvMes)
    End Sub

    Private Sub DgvDis_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvMes.ColumnHeaderMouseClick
        ent.CampoOrden = Me.DgvMes.Columns(e.ColumnIndex).Name
        ent.ColumnaBusqueda = Me.DgvMes.Columns(e.ColumnIndex).HeaderText
        Me.ActualizarVentana()
    End Sub

    Private Sub btnDesplaza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrimero.Click, btnAnterior.Click, btnSiguiente.Click, btnUltimo.Click
        Dgv.desplazamientoFila(Me.DgvMes, CType(sender, ToolStripButton))
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
        Me.imprimir()
    End Sub

    Private Sub btnExportar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Me.exportar()
    End Sub


End Class