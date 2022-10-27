Option Strict Off
Imports Entidad
Imports Negocio

Public Class WTabla

    Public per As New PermisoRN
    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public tab As New TablaRN
    Public cam As New CamposEntidad
    Public ent As New SuperEntidad
    Public tipoTabla As String
    Public arg As String

#Region "Metodos"

    Sub NuevaVentana()
        '/
        Me.Show()
        ent.CampoOrden = cam.CodItemTabla
        ent.ColumnaBusqueda = "Codigo"
        Me.ActualizarVentana()
        '/
    End Sub


    Sub permisoVentana()
        Dim nReg As Integer = Me.DgvDis.Rows.Count
        Dim lisPer As New List(Of SuperEntidad)
        Dim oPer As New SuperEntidad
        oPer.CodigoUsuario = SuperEntidad.xCodigoUsuario
        ''SEGUN TIPO TABLA
        Select Case Me.tipoTabla
            Case "Fil" : oPer.CodigoVentana = "002"
            Case "Doc" : oPer.CodigoVentana = "003"
            Case "Cto" : oPer.CodigoVentana = "004"
            Case "Cue" : oPer.CodigoVentana = "005"
            Case "Ies" : oPer.CodigoVentana = "006"
            Case "Mod" : oPer.CodigoVentana = "007"
        End Select

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
                Case "09" : Me.btnRecycla.Enabled = vf
                Case "08" : Me.btnImprimir.Enabled = vf
            End Select
        Next
    End Sub



    Sub ActualizarVentana()
        '/
        Me.ActualizarDgvUsu()
        Dgv.actualizarBarraEstado(Me.sst1, Me.DgvDis)
        acc.EstadoBotonesPorGrilla(Me.ListaBotones, Me.DgvDis)
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvDis)
        Dgv.pintarColumnaDgv(Me.DgvDis, ent.CampoOrden)
        Me.permisoVentana()
        '/
    End Sub

    Sub ActualizarDgvUsu()
        '/
        '/Refrescando el DataSource de DgvUsu
        ent.DatoCondicion1 = Me.tipoTabla
        Select Case Me.Text
            Case "Contrato Personal"
                ent.DatoFiltro1 = "0201"
                lista = tab.obtenerItemsTablaExisPorTipoTablayFiltroCodigo(ent)
            Case "Contrato Servicio"
                ent.DatoFiltro1 = "0202"
                lista = tab.obtenerItemsTablaExisPorTipoTablayFiltroCodigo(ent)
            Case Else
                lista = tab.obtenerItemsTablaExisPorTipoTabla(ent)
        End Select
        '/Refrescando el DataSource de DgvUsu
        Dgv.refrescarFuenteDatosGrilla(Me.DgvDis, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvDis, cam.CodItemTabla, "Codigo", 93)
        Dgv.asignarColumnaText(Me.DgvDis, cam.NomItemTabla, "Nombre", 340)
        'Dgv.asignarColumnaText(Me.DgvDis, cam.EstReg, "Estado", 100)

        '//
    End Sub

    Sub buscar()
        '//
        Dim win As New WBuscar
        win.wTab = Me
        Me.AddOwnedForm(win)
        win.ventanaBuscar(ent.ColumnaBusqueda)
        '\\
    End Sub

    Sub adicionar()
        '//
        Dim win As New WEditarTabla
        win.wtab = Me
        Me.AddOwnedForm(win)
        win.ventanaAdicionar()
        '\\
    End Sub

    Sub modificar()
        '//
        Dim win As New WEditarTabla
        win.wtab = Me
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvDis, 0)
        win.ventanaModificar(cod)
        '\\
    End Sub

    Sub eliminar()
        '//
        Dim win As New WEditarTabla
        win.wtab = Me
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvDis, 0)
        win.ventanaEliminar(cod)
        '\\
    End Sub

    Sub Visualizar()
        '//
        Dim win As New WEditarTabla
        win.wtab = Me
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvDis, 0)
        win.ventanaVisualizar(cod)
        '\\
    End Sub

    Sub imprimir()
        '//
        Dim imp As New WImprimirTablas
        imp.wTab = Me
        Me.AddOwnedForm(imp)
        imp.nuevaVentana()
        '\\
    End Sub

    Sub exportar()
        '//
        Dim imp As New WRptTab
        imp.wTab = Me
        imp.ent.DatoCondicion1 = Me.tipoTabla
        imp.ent.CampoOrden = cam.NomItemTabla
        imp.Exportar()
        '\\
    End Sub

    Sub recycla()
        Dim win As New WTablaRecycla
        win.wTab = Me
        Me.AddOwnedForm(win)
        win.NuevaVentana()
    End Sub

#End Region


    Private Sub btnActualizarTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarTabla.Click
        Me.ActualizarVentana()
    End Sub

    Private Sub DgvDis_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvDis.CellEnter
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvDis)
    End Sub

    Private Sub DgvDis_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvDis.ColumnHeaderMouseClick
        ent.CampoOrden = Me.DgvDis.Columns(e.ColumnIndex).Name
        ent.ColumnaBusqueda = Me.DgvDis.Columns(e.ColumnIndex).HeaderText
        Me.ActualizarVentana()
    End Sub

    Private Sub btnDesplaza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrimero.Click, btnAnterior.Click, btnSiguiente.Click, btnUltimo.Click
        Dgv.desplazamientoFila(Me.DgvDis, CType(sender, ToolStripButton))
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

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Me.Visualizar()
    End Sub

    Private Sub btnRecycla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecycla.Click
        Me.recycla()
    End Sub
End Class