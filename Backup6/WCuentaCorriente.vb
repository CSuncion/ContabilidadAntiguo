Imports Entidad
Imports Negocio

Public Class WCuentaCorriente
    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public ccte As New CuentaCorrienteRN
    Public cam As New CamposEntidad
    Public ent As New SuperEntidad
    Public titulo As String = "Cuenta Corriente"


#Region "Metodos"

    Sub NuevaVentana()
        '//
        'visualiza el formulario
        Me.Show()
        'orden por defecto
        ent.CampoOrden = cam.ClaveCtaCte
        ent.ColumnaBusqueda = "Clave"
        Me.ActualizarVentana()

        '\\
    End Sub


    Sub ActualizarVentana()
        '//
        Me.ActualizarDgvTab()
        Dgv.actualizarBarraEstado(Me.sst1, Me.DgvCtaCte)
        acc.EstadoBotonesPorGrilla(Me.ListaBotones, Me.DgvCtaCte)
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvCtaCte)
        Dgv.pintarColumnaDgv(Me.DgvCtaCte, ent.CampoOrden)
        'Me.permisoVentana()
        '\\
    End Sub

    Sub ActualizarDgvTab()

        '//
        '/Refrescando el DataSource de DgvUsu
        ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa

        lista = ccte.obtenerCuentaCorrienteExisXEmpresa(ent)

        '/Refrescando el DataSource de DgvUsu
        Dgv.refrescarFuenteDatosGrilla(Me.DgvCtaCte, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvCtaCte, cam.CodAux, "RUC", 90)
        Dgv.asignarColumnaText(Me.DgvCtaCte, cam.DesAux, "Razon Social", 200)
        Dgv.asignarColumnaText(Me.DgvCtaCte, cam.CodTipDoc, "TD", 40)
        Dgv.asignarColumnaText(Me.DgvCtaCte, cam.NomTipDoc, "Nombre", 70)
        Dgv.asignarColumnaText(Me.DgvCtaCte, cam.SerDoC, "Serie", 40)
        Dgv.asignarColumnaText(Me.DgvCtaCte, cam.NumDoc, "Numero", 100)
        Dgv.asignarColumnaText(Me.DgvCtaCte, cam.FecDoc, "Fecha", 80)
        Dgv.asignarColumnaText(Me.DgvCtaCte, cam.MonDoc, "Moneda", 50)
        Dgv.AsignarColumnaTextNumerico(Me.DgvCtaCte, cam.ImpOriCtaCte, "Importe", 90, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvCtaCte, cam.ImpPagCtaCte, "Pagado", 90, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvCtaCte, cam.SalCtaCte, "Saldo", 90, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvCtaCte, cam.VenTipCamOri, "TC", 50, 3)
        Dgv.asignarColumnaText(Me.DgvCtaCte, cam.ClaveCtaCte, "Clave", 150)
        '//
    End Sub

    Sub buscar()
        '//
        Dim win As New WBuscar
        win.wCtaCte = Me
        win.titulo = Me.titulo
        Me.AddOwnedForm(win)
        win.ventanaBuscar(ent.ColumnaBusqueda)
        '\\
    End Sub

    Sub adicionar()
        '//
        Dim win As New WEditarCuentaCorriente
        win.wCtaCte = Me
        win.operacion = 0
        Me.AddOwnedForm(win)
        win.ventanaAdicionar()
        '\\    
    End Sub


    Sub modificar()
        '    '//
        Dim win As New WEditarCuentaCorriente
        win.wCtaCte = Me
        win.operacion = 1
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvCtaCte, cam.ClaveCtaCte)
        win.ventanaModificar(cod)
        '    '\\
    End Sub

    Sub eliminar()
        '//
        Dim win As New WEditarCuentaCorriente
        win.wCtaCte = Me
        win.operacion = 2
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvCtaCte, cam.ClaveCtaCte)
        win.ventanaEliminar(cod)
        '\\
    End Sub

    Sub Visualizar()
        '//
        Dim win As New WEditarCuentaCorriente
        win.wctacte = Me
        win.operacion = 3
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvCtaCte, cam.ClaveCtaCte)
        win.ventanaVisualizar(cod)
        '\\
    End Sub

    Sub imprimir()
        '//
        Dim imp As New WImpCuentaCorriente
        imp.wCtaCte = Me
        Me.AddOwnedForm(imp)
        imp.InicializaVentana()
        '\\
    End Sub


    'Sub recycla()
    '    Dim win As New WPlanDeCuentasRecycla
    '    win.wPcta = Me
    '    Me.AddOwnedForm(win)
    '    win.NuevaVentana()
    'End Sub

#End Region

    Private Sub btnActualizarTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarTabla.Click
        Me.ActualizarVentana()
    End Sub

    Private Sub DgvDis_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvCtaCte.CellEnter
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvCtaCte)
    End Sub

    Private Sub DgvDis_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvCtaCte.ColumnHeaderMouseClick
        ent.CampoOrden = Me.DgvCtaCte.Columns(e.ColumnIndex).Name
        ent.ColumnaBusqueda = Me.DgvCtaCte.Columns(e.ColumnIndex).HeaderText
        Me.ActualizarVentana()
    End Sub

    Private Sub btnDesplaza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrimero.Click, btnAnterior.Click, btnSiguiente.Click, btnUltimo.Click
        Dgv.desplazamientoFila(Me.DgvCtaCte, CType(sender, ToolStripButton))
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

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Me.Visualizar()
    End Sub

    Private Sub btnRecycla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecycla.Click
        'Me.recycla()
    End Sub
End Class