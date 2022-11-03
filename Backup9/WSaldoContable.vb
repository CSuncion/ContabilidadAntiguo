Imports Entidad
Imports Negocio

Public Class WSaldoContable
    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public sal As New SaldoContableRN
    Public cam As New CamposEntidad
    Public ent, entpar As New SuperEntidad
    Public titulo As String = "SaldoContable"
    Public par As New ParametroRN
    Public periodo As String


#Region "Metodos"

    Sub NuevaVentana()
        '//
        'visualiza el formulario
        Me.Show()
        'orden por defecto
        entpar = par.buscarParametroExis(entpar)
        periodo = SuperEntidad.xPeriodoEmpresa
        ent.CampoOrden = cam.CodCtaPcge
        ent.ColumnaBusqueda = "Cuenta"
        Me.ActualizarVentana()

        '\\
    End Sub

    Sub permisoVentana()
        
    End Sub

    Sub ActualizarVentana()
        '//
        Me.ActualizarDgvTab()
        Dgv.actualizarBarraEstado(Me.sst1, Me.DgvSaldo)
        acc.EstadoBotonesPorGrilla(Me.ListaBotones, Me.DgvSaldo)
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvSaldo)
        Dgv.pintarColumnaDgv(Me.DgvSaldo, ent.CampoOrden)
        'Me.permisoVentana()
        '\\
    End Sub

    Sub ActualizarDgvTab()
        '//

        '/Refrescando el DataSource de DgvUsu
        'ent.ClaveSaldoContable = cod
        ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        'lista = sal.obtenerRegContabCabeExisXOrigenYPeriodo(ent)

        '/Refrescando el DataSource de DgvUsu
        Dgv.refrescarFuenteDatosGrilla(Me.DgvSaldo, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvSaldo, cam.CodCtaPcge, "Cuenta", 100)
        Dgv.asignarColumnaText(Me.DgvSaldo, cam.NomCtaPcge, "Nombre", 130)
        Dgv.asignarColumnaText(Me.DgvSaldo, cam.CodEmp, "Codigo", 80)
        Dgv.asignarColumnaText(Me.DgvSaldo, cam.RazSocEmp, "Razon Social", 200)
        Dgv.asignarColumnaText(Me.DgvSaldo, cam.ClaSalCon, "Clave", 90)
        '//
    End Sub

    Sub buscar()
        '//
        Dim win As New WBuscar
        win.wSal = Me
        win.titulo = Me.titulo
        Me.AddOwnedForm(win)
        win.ventanaBuscar(ent.ColumnaBusqueda)
        '\\
    End Sub

    Sub Filtrar()
        Dim win As New WFitrarPeriodo
        win.wRgSaldo = Me
        win.TipoRg = "SaldoContable"
        Me.AddOwnedForm(win)
        win.nuevo()
    End Sub


    Sub adicionar()
        ''//
        Dim win As New WSaldoContableMensual
        win.wSal = Me
        win.operacion = 0
        Me.AddOwnedForm(win)
        'win.ventanaAdicionar()
        '\\
    End Sub

    Sub modificar()
        '//
        Dim win As New WSaldoContableMensual
        win.wSal = Me
        win.operacion = 1
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvSaldo, cam.ClaSalCon)
        'win.ventanaModificar(cod)
        ''\\
    End Sub

    Sub eliminar()
        '//
        Dim win As New WSaldoContableMensual
        win.wSal = Me
        win.operacion = 2
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvSaldo, cam.ClaveRCC)
        win.ventanaEliminar(cod)
        '\\
    End Sub

    Sub Visualizar()
        '//
        Dim win As New WSaldoContableMensual
        win.wSal = Me
        win.operacion = 3
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvSaldo, cam.ClaveRCC)
        win.ventanaVisualizar(cod)
        '\\
    End Sub

    'Sub imprimir()
    '    '//
    '    Dim imp As New WImpTabla
    '    imp.wTab = Me
    '    Me.AddOwnedForm(imp)
    '    imp.nuevaVentana()
    '    '\\

    'End Sub


    'Sub recycla()
    '    Dim win As New WComprobanterecycla
    '    win.wCom = Me
    '    Me.AddOwnedForm(win)
    '    win.NuevaVentana()
    'End Sub

#End Region

    Private Sub btnActualizarTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarTabla.Click
        Me.ActualizarVentana()
    End Sub

    Private Sub DgvDis_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvSaldo.CellEnter
        'acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvBco)
    End Sub

    Private Sub DgvDis_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvSaldo.ColumnHeaderMouseClick
        ent.CampoOrden = Me.DgvSaldo.Columns(e.ColumnIndex).Name
        ent.ColumnaBusqueda = Me.DgvSaldo.Columns(e.ColumnIndex).HeaderText
        Me.ActualizarVentana()
    End Sub

    Private Sub btnDesplaza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrimero.Click, btnAnterior.Click, btnSiguiente.Click, btnUltimo.Click
        Dgv.desplazamientoFila(Me.DgvSaldo, CType(sender, ToolStripButton))
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

    Private Sub btnRecycla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecycla.Click
        '       Me.recycla()
    End Sub

    Private Sub DgvCom_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvSaldo.CellContentClick

    End Sub

    Private Sub tst1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tst1.ItemClicked

    End Sub

End Class