Option Strict Off
Imports Entidad
Imports Negocio

Public Class WPlanCuentaGe

    Public per As New PermisoRN
    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public pcg As New PlanCuentaGeRN
    Public emp As New EmpresaRN
    Public cam As New CamposEntidad
    Public ent As New SuperEntidad
    Public titulo As String = "Cuenta"
    Public cEmp As String

#Region "Metodos"

#Region "Propietarios"
    Public wEmp As New WEmpresa
#End Region


    Sub NuevaVentana(ByVal codEmp As String)
        '//
        'visualiza el formulario
        Me.Show()
        Me.cEmp = codEmp
        'orden por defecto
        ent.CampoOrden = cam.CodCtaPcge
        ent.ColumnaBusqueda = "Codigo"
        Me.ActualizarVentana()
        Dim entEmp As New SuperEntidad
        entEmp.CodigoEmpresa = cEmp
        entEmp = emp.buscarEmpresaExisPorCodigo(entEmp)
        Me.Text = "Plan de cuentas"
        '\\
    End Sub

    Sub permisoVentana()
        Dim nReg As Integer = Me.DgvPcg.Rows.Count
        Dim lisPer As New List(Of SuperEntidad)
        Dim oPer As New SuperEntidad
        oPer.CodigoUsuario = SuperEntidad.xCodigoUsuario
        oPer.CodigoVentana = "009"
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
        Dgv.actualizarBarraEstado(Me.sst1, Me.DgvPcg)
        acc.EstadoBotonesPorGrilla(Me.ListaBotones, Me.DgvPcg)
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvPcg)
        Dgv.pintarColumnaDgv(Me.DgvPcg, ent.CampoOrden)
        Me.permisoVentana()
        '\\
    End Sub

    Sub ActualizarDgvTab()

        '//
        '/Refrescando el DataSource de DgvUsu
        ent.CodigoEmpresa = Me.cEmp
        lista = pcg.obtenerCuentaExisPorEmpresa(ent)

        '/Refrescando el DataSource de DgvUsu
        Dgv.refrescarFuenteDatosGrilla(Me.DgvPcg, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvPcg, cam.CodCtaPcge, "Codigo", 60)
        Dgv.asignarColumnaText(Me.DgvPcg, cam.NomCtaPcge, "Nombre", 400)
        Dgv.asignarColumnaText(Me.DgvPcg, cam.FlaDocPcge, "FlagDoc", 60)
        Dgv.asignarColumnaText(Me.DgvPcg, cam.FlaAuxPcge, "FlagAuxiliar", 70)
        Dgv.asignarColumnaText(Me.DgvPcg, cam.FlaCtoPcge, "FlagCenCto", 70)
        Dgv.asignarColumnaText(Me.DgvPcg, cam.FlaAlmPcge, "FlagAlmacen", 70)
        Dgv.asignarColumnaText(Me.DgvPcg, cam.FlaAutPcge, "FlagAutoma", 70)
        Dgv.asignarColumnaText(Me.DgvPcg, cam.CtaAut1Pcge, "Cta.Aut1", 70)
        Dgv.asignarColumnaText(Me.DgvPcg, cam.CtaAut2Pcge, "Cta.Aut2", 70)
        Dgv.asignarColumnaText(Me.DgvPcg, cam.NumDigPcge, "N.Dig", 60)
        Dgv.asignarColumnaText(Me.DgvPcg, cam.ClaForCon, "F.Con", 60)
        Dgv.asignarColumnaText(Me.DgvPcg, cam.FlaMonPcge, "Moneda", 80)
        Dgv.asignarColumnaTextVis(Me.DgvPcg, cam.ClaCtaPcge, "Clave", 80, 0)
        '//
    End Sub

    Sub buscar()
        '//
        Dim win As New WBuscar
        win.wPcg = Me
        win.titulo = Me.titulo
        Me.AddOwnedForm(win)
        win.ventanaBuscar(ent.ColumnaBusqueda)
        '\\
    End Sub

    Sub adicionar()
        '//
        Dim win As New WEditarPlanCuentaGe
        win.wpcg = Me
        win.operacion = 0
        Me.AddOwnedForm(win)
        win.ventanaAdicionar()
        '\\
    End Sub


    Sub modificar()
        '//
        Dim win As New WEditarPlanCuentaGe
        win.wpcg = Me
        win.operacion = 1
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvPcg, 0)
        win.ventanaModificar(cod)
        '\\
    End Sub

    Sub eliminar()
        '//
        Dim win As New WEditarPlanCuentaGe
        win.wpcg = Me
        win.operacion = 2
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvPcg, 0)
        win.ventanaEliminar(cod)
        '\\
    End Sub

    Sub Visualizar()
        '//
        Dim win As New WEditarPlanCuentaGe
        win.wpcg = Me
        win.operacion = 3
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvPcg, 0)
        win.ventanaVisualizar(cod)
        '\\
    End Sub

    Sub imprimir()
        '//
        Dim imp As New WImpPcgeEmp
        imp.wpcg = Me
        Me.AddOwnedForm(imp)
        imp.InicializaVentana()
        '\\
    End Sub

    Sub recycla()
        Dim win As New WPlanCuentaGeRecycla
        win.wPcg = Me
        Me.AddOwnedForm(win)
        win.NuevaVentana()
    End Sub

#End Region

    Private Sub WEditarTabla_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub btnActualizarTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarTabla.Click
        Me.ActualizarVentana()
    End Sub

    Private Sub DgvDis_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvPcg.CellEnter
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvPcg)
    End Sub

    Private Sub DgvDis_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvPcg.ColumnHeaderMouseClick
        ent.CampoOrden = Me.DgvPcg.Columns(e.ColumnIndex).Name
        ent.ColumnaBusqueda = Me.DgvPcg.Columns(e.ColumnIndex).HeaderText
        Me.ActualizarVentana()
    End Sub

    Private Sub btnDesplaza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrimero.Click, btnAnterior.Click, btnSiguiente.Click, btnUltimo.Click
        Dgv.desplazamientoFila(Me.DgvPcg, CType(sender, ToolStripButton))
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

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim win As New WCuentaBanco
        win.NuevaVentana()
    End Sub
End Class