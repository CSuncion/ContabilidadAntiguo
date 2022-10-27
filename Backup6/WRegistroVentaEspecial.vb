Imports Entidad
Imports Negocio

Public Class WRegistroVentaEspecial

    Public acc As New Accion
    Public lista, lD As New List(Of SuperEntidad)
    Public rv As New RegistroEspecialRN
    Public cam As New CamposEntidad
    Public ent, entPar, entDeta As New SuperEntidad
    Public par As New ParametroRN
    Public periodo As String

#Region "Metodos"

    Sub NuevaVentana()
        '//
        Me.Show()
        'periodo actual
        entPar = par.buscarParametroExis(entPar)
        periodo = SuperEntidad.xPeriodoEmpresa
        ent.CampoOrden = cam.ClaveRCC
        ent.ColumnaBusqueda = "Codigo"
        Me.ActualizarVentana()
        '\\
    End Sub

    Sub permisoVentana()
        
    End Sub


    Sub ActualizarVentana()
        '//
        Me.ActualizarDgvUsu()
        'Me.ActualizarDgvDeta()
        Dgv.actualizarBarraEstado(Me.sst1, Me.DgvRVtaEsp)
        acc.EstadoBotonesPorGrilla(Me.ListaBotones, Me.DgvRVtaEsp)
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvRVtaEsp)
        Dgv.pintarColumnaDgv(Me.DgvRVtaEsp, ent.CampoOrden)
        'Me.permisoVentana()
        '\\
    End Sub

    Sub ActualizarDgvUsu()
        '//
        '/Refrescando el DataSource de DgvUsu
        ent.CodigoOrigen = "5"
        ent.PeriodoRegContabCabe = periodo
        ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        lista = rv.obtenerRegContabCabeExisXOrigenYPeriodo(ent)

        Dgv.refrescarFuenteDatosGrilla(Me.DgvRVtaEsp, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvRVtaEsp, cam.NomOriRC, "Origen", 100)
        Dgv.asignarColumnaText(Me.DgvRVtaEsp, cam.NomFilRC, "File", 130)
        Dgv.asignarColumnaText(Me.DgvRVtaEsp, cam.NumVouRCC, "Numero Voucher", 90)
        Dgv.asignarColumnaText(Me.DgvRVtaEsp, cam.FecVouRCC, "Fecha Voucher", 80)
        Dgv.asignarColumnaText(Me.DgvRVtaEsp, cam.DesAux, "Cliente", 250)
        Dgv.asignarColumnaText(Me.DgvRVtaEsp, cam.NomTipDoc, "Documento", 60)
        Dgv.asignarColumnaText(Me.DgvRVtaEsp, cam.SerDoC, "Serie", 60)
        Dgv.asignarColumnaText(Me.DgvRVtaEsp, cam.NumDoc, "Numero", 100)
        Dgv.asignarColumnaText(Me.DgvRVtaEsp, cam.PreVtaRCC, "P.Venta", 100)
        Dgv.asignarColumnaText(Me.DgvRVtaEsp, cam.IgvRCC, "Igv", 100)
        Dgv.asignarColumnaText(Me.DgvRVtaEsp, cam.IgvPar, "%Igv", 60)
        Dgv.asignarColumnaText(Me.DgvRVtaEsp, cam.ClaveRCC, "Clave", 125)
        '//
    End Sub

    Sub Buscar()
        '//
        Dim win As New WBuscar
        win.wRvEs = Me
        Me.AddOwnedForm(win)
        win.ventanaBuscar(ent.ColumnaBusqueda)
        '\\
    End Sub

    'Sub Filtrar()
    '    Dim win As New WFitrarPeriodo
    '    win.wRgVenta = Me
    '    win.TipoRg = "Ventas"
    '    Me.AddOwnedForm(win)
    '    win.nuevo()
    'End Sub

    Sub adicionar()
        '//
        Dim win As New WEditarRegistroVentaEspecial
        win.wRv = Me
        win.operacion = 0
        Me.AddOwnedForm(win)
        win.ventanaAdicionar()
        '\\
    End Sub

    Sub adicionarManual()
        '//
        Dim win As New WEditarRegistroVentaEspecial
        win.wRv = Me
        win.operacion = 4
        Me.AddOwnedForm(win)
        win.ventanaAdicionarManual()
        '\\
    End Sub

    Sub modificar()
        '//
        Dim win As New WEditarRegistroVentaEspecial
        win.wRv = Me
        win.operacion = 1
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvRVtaEsp, cam.ClaveRCC)
        win.ventanaModificar(cod)
        '\\
    End Sub

    Sub eliminar()
        '//
        Dim win As New WEditarRegistroVentaEspecial
        win.wRv = Me
        win.operacion = 2
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvRVtaEsp, cam.ClaveRCC)
        win.ventanaEliminar(cod)
        '\\
    End Sub

    Sub visualizar()
        '//
        Dim win As New WEditarRegistroVentaEspecial
        win.wRv = Me
        win.operacion = 3
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvRVtaEsp, cam.ClaveRCC)
        win.ventanaVisualizar(cod)
        '\\
    End Sub

    Sub imprimir()
        '//
        Dim imp As New wImpRegistroEspecial
        imp.wRv = Me
        Me.AddOwnedForm(imp)
        imp.InicializaVentana()
        '\\
    End Sub

    Sub exportar()
        '//
        'Dim imp As New WRptPer
        'imp.ent.CampoOrden = cam.CodPer
        'imp.ent.DatoEstado = ""
        'imp.Exportar()
        '\\
    End Sub

    Sub recycla()
        'Dim win As New wPersonalRecycla
        'win.wPer = Me
        'Me.AddOwnedForm(win)
        'win.NuevaVentana()
    End Sub

    Sub Anula()
        '//
        Dim win As New WEditarRegistroVentaEspecial
        win.wRv = Me
        win.operacion = 5
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvRVtaEsp, cam.ClaveRCC)
        win.ventanaAnular(cod)
        '\\
    End Sub

#End Region

    Private Sub btnActualizarTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarTabla.Click
        Me.ActualizarVentana()
    End Sub

    Private Sub DgvPpto_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvRVtaEsp.CellEnter
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvRVtaEsp)
        'Me.ActualizarDgvDeta()
    End Sub

    Private Sub DgvPer_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvRVtaEsp.ColumnHeaderMouseClick
        ent.CampoOrden = Me.DgvRVtaEsp.Columns(e.ColumnIndex).Name
        ent.ColumnaBusqueda = Me.DgvRVtaEsp.Columns(e.ColumnIndex).HeaderText
        Me.ActualizarVentana()
    End Sub

    Private Sub btnDesplaza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrimero.Click, btnAnterior.Click, btnSiguiente.Click, btnUltimo.Click
        Dgv.desplazamientoFila(Me.DgvRVtaEsp, CType(sender, ToolStripButton))
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
        Me.imprimir()
    End Sub

    Private Sub btnExportar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Me.exportar()
    End Sub

    Private Sub WPersonal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.NuevaVentana()
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Me.visualizar()
    End Sub

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        'Me.Filtrar()
    End Sub

    Private Sub btnAdionarManual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdionarManual.Click
        Me.adicionarManual()
    End Sub

    Private Sub btnAnula_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnula.Click
        Me.Anula()
    End Sub
End Class

