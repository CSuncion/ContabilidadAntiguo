Option Strict Off
Imports Entidad
Imports Negocio

Public Class WPcge

    Public per As New PermisoRN
    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public pcta As New PlanDeCuentasRN
    Public cam As New CamposEntidad
    Public ent As New SuperEntidad
    Public titulo As String = "P.c.g.e"

#Region "Metodos"

    Sub NuevaVentana()
        '//
        'visualiza el formulario
        Me.Show()
        'orden por defecto
        ent.CampoOrden = cam.CodCtaPcge
        ent.ColumnaBusqueda = "Codigo"
        Me.ActualizarVentana()

        '\\
    End Sub


    Sub permisoVentana()
        Dim nReg As Integer = Me.DgvPctaRec.Rows.Count
        Dim lisPer As New List(Of SuperEntidad)
        Dim oPer As New SuperEntidad
        oPer.CodigoUsuario = SuperEntidad.xCodigoUsuario
        oPer.CodigoVentana = "008"
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
        '//
        Me.ActualizarDgvTab()
        Dgv.actualizarBarraEstado(Me.sst1, Me.DgvPctaRec)
        acc.EstadoBotonesPorGrilla(Me.ListaBotones, Me.DgvPctaRec)
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvPctaRec)
        Dgv.pintarColumnaDgv(Me.DgvPctaRec, ent.CampoOrden)
        Me.permisoVentana()
        '\\
    End Sub

    Sub ActualizarDgvTab()

        '//
        '/Refrescando el DataSource de DgvUsu
        lista = pcta.obtenerPlanDeCuentasExis(ent)

        '/Refrescando el DataSource de DgvUsu
        Dgv.refrescarFuenteDatosGrilla(Me.DgvPctaRec, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvPctaRec, cam.CodCtaPcge, "Codigo", 80)
        Dgv.asignarColumnaText(Me.DgvPctaRec, cam.NomCtaPcge, "Nombre", 435)
        Dgv.asignarColumnaText(Me.DgvPctaRec, cam.NumDigPcge, "N.DIG", 80)
        '//
    End Sub

    Sub buscar()
        '//
        Dim win As New WBuscar
        win.wPcta = Me
        win.titulo = Me.titulo
        Me.AddOwnedForm(win)
        win.ventanaBuscar(ent.ColumnaBusqueda)
        '\\
    End Sub

    Sub adicionar()
        '//
        Dim win As New WEditarPlanDeCuentas
        win.wpcta = Me
        win.operacion = 0
        Me.AddOwnedForm(win)
        win.ventanaAdicionar()
        '\\
    End Sub


    Sub modificar()
        '//
        Dim win As New WEditarPlanDeCuentas
        win.wpcta = Me
        win.operacion = 1
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvPctaRec, 0)
        win.ventanaModificar(cod)
        '\\
    End Sub

    Sub eliminar()
        '//
        Dim win As New WEditarPlanDeCuentas
        win.wpcta = Me
        win.operacion = 2
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvPctaRec, 0)
        win.ventanaEliminar(cod)
        '\\
    End Sub

    Sub Visualizar()
        '//
        Dim win As New WEditarPlanDeCuentas
        win.wpcta = Me
        win.operacion = 3
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvPctaRec, 0)
        win.ventanaVisualizar(cod)
        '\\
    End Sub

    Sub imprimir()
        '//
        Dim imp As New WImpPlanCuentas

        imp.wpcta = Me
        Me.AddOwnedForm(imp)
        imp.InicializaVentana()
        '\\

    End Sub


    Sub recycla()
        Dim win As New WPlanDeCuentasRecycla
        win.wPcta = Me
        Me.AddOwnedForm(win)
        win.NuevaVentana()
    End Sub

#End Region

    Private Sub btnActualizarTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarTabla.Click
        Me.ActualizarVentana()
    End Sub

    Private Sub DgvDis_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvPctaRec.CellEnter
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvPctaRec)
    End Sub

    Private Sub DgvDis_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvPctaRec.ColumnHeaderMouseClick
        ent.CampoOrden = Me.DgvPctaRec.Columns(e.ColumnIndex).Name
        ent.ColumnaBusqueda = Me.DgvPctaRec.Columns(e.ColumnIndex).HeaderText
        Me.ActualizarVentana()
    End Sub

    Private Sub btnDesplaza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrimero.Click, btnAnterior.Click, btnSiguiente.Click, btnUltimo.Click
        Dgv.desplazamientoFila(Me.DgvPctaRec, CType(sender, ToolStripButton))
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
        Me.recycla()
    End Sub

    Private Sub DgvCom_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvPctaRec.CellContentClick

    End Sub

    Private Sub tst1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tst1.ItemClicked

    End Sub



End Class