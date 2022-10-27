Option Strict Off
Imports Entidad
Imports Negocio

Public Class WEmpresa

    Public per As New PermisoRN
    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public emp As New EmpresaRN
    Public cam As New CamposEntidad
    Public ent As New SuperEntidad
    Public titulo As String = "Empresa"


#Region "Metodos"

    Sub NuevaVentana()
        '//
        'visualiza el formulario
        Me.Show()
        'orden por defecto
        ent.CampoOrden = cam.CodEmp
        ent.ColumnaBusqueda = "Codigo"
        Me.ActualizarVentana()

        '\\
    End Sub

    Sub permisoVentana()
        Dim nReg As Integer = Me.DgvEmp.Rows.Count
        Dim lisPer As New List(Of SuperEntidad)
        Dim oPer As New SuperEntidad
        oPer.CodigoUsuario = SuperEntidad.xCodigoUsuario
        oPer.CodigoVentana = "011"
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
                Case "06" : Me.BtnAsigCue.Enabled = vf
                Case "07" : Me.btnCopiarCuentas.Enabled = vf
            End Select
        Next
    End Sub

    Sub ActualizarVentana()
        '//
        Me.ActualizarDgvTab()
        Dgv.actualizarBarraEstado(Me.sst1, Me.DgvEmp)
        acc.EstadoBotonesPorGrilla(Me.ListaBotones, Me.DgvEmp)
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvEmp)
        Dgv.pintarColumnaDgv(Me.DgvEmp, ent.CampoOrden)
        Me.permisoVentana()
        '\\
    End Sub

    Sub ActualizarDgvTab()

        '//
        '/Refrescando el DataSource de DgvUsu
        lista = emp.obtenerEmpresaExis(ent)

        '/Refrescando el DataSource de DgvUsu
        Dgv.refrescarFuenteDatosGrilla(Me.DgvEmp, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvEmp, cam.CodEmp, "Codigo", 60)
        Dgv.asignarColumnaText(Me.DgvEmp, cam.RazSocEmp, "Razon Social", 275)
        Dgv.asignarColumnaText(Me.DgvEmp, cam.DirEmp, "Direccion", 250)
        Dgv.asignarColumnaText(Me.DgvEmp, cam.RucEmp, "Ruc", 80)
        Dgv.asignarColumnaText(Me.DgvEmp, cam.EstEmp, "Estado", 80)
        '//
    End Sub

    Sub buscar()
        '//
        Dim win As New WBuscar
        win.wEmp = Me
        Me.AddOwnedForm(win)
        win.ventanaBuscar(ent.ColumnaBusqueda)
        '\\
    End Sub

    Sub adicionar()
        '//
        Dim win As New WEditarEmpresa
        win.wEmp = Me
        win.operacion = 0
        Me.AddOwnedForm(win)
        win.ventanaAdicionar()
        '\\
    End Sub


    Sub modificar()
        '//
        Dim win As New WEditarEmpresa
        win.wEmp = Me
        win.operacion = 1
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvEmp, 0)
        win.ventanaModificar(cod)
        '\\
    End Sub

    Sub eliminar()
        '//
        Dim win As New WEditarEmpresa
        win.wEmp = Me
        win.operacion = 2
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvEmp, 0)
        win.ventanaEliminar(cod)
        '\\
    End Sub

    Sub Visualizar()
        '//
        Dim win As New WEditarEmpresa
        win.wEmp = Me
        win.operacion = 3
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvEmp, 0)
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


    Sub recycla()
        Dim win As New WEmpresaRecycla
        win.wEmp = Me
        Me.AddOwnedForm(win)
        win.NuevaVentana()
    End Sub
    Sub AsignarCuentas()
        Dim win As New WAsignarCuentas
        win.wEmp = Me
        Me.AddOwnedForm(win)
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvEmp, cam.CodEmp)
        win.NuevaVentana(cod)
    End Sub

    Sub PlanCuentas()
        Dim win As New WPlanCuentaGe
        win.wEmp = Me
        Me.AddOwnedForm(win)
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvEmp, cam.CodEmp)
        win.NuevaVentana(cod)
    End Sub

    Sub CopiarCuentas()
        Dim win As New WCopiaPlanCuentas
        win.wEmp = Me
        Me.AddOwnedForm(win)
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvEmp, cam.CodEmp)
        win.NuevaVentana(cod)
    End Sub


    'Sub CambiarPeriodo()
    '    Dim win As New WCambiaPeriodoEmpresa
    '    'win.wEmp = Me
    '    Me.AddOwnedForm(win)
    '    Dim cod As String = Dgv.obtenerValorCelda(Me.DgvEmp, cam.CodEmp)
    '    win.InicializaVentana(cod)
    'End Sub

#End Region

    Private Sub btnActualizarTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarTabla.Click
        Me.ActualizarVentana()
    End Sub

    Private Sub DgvDis_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvEmp.CellEnter
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvEmp)
    End Sub

    Private Sub DgvDis_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvEmp.ColumnHeaderMouseClick
        ent.CampoOrden = Me.DgvEmp.Columns(e.ColumnIndex).Name
        ent.ColumnaBusqueda = Me.DgvEmp.Columns(e.ColumnIndex).HeaderText
        Me.ActualizarVentana()
    End Sub

    Private Sub btnDesplaza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrimero.Click, btnAnterior.Click, btnSiguiente.Click, btnUltimo.Click
        Dgv.desplazamientoFila(Me.DgvEmp, CType(sender, ToolStripButton))
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
        Me.recycla()
    End Sub

    Private Sub DgvCom_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvEmp.CellContentClick

    End Sub

    Private Sub tst1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tst1.ItemClicked

    End Sub

    Private Sub BtnAsigCue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAsigCue.Click
        Me.AsignarCuentas()
    End Sub

    Private Sub btlPlanCuentas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BtlPeriodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Me.CambiarPeriodo()
    End Sub
    Private Sub btnCopiarCuentas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopiarCuentas.Click

        Me.CopiarCuentas()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtlPlanCuentas.Click
        Me.PlanCuentas()
    End Sub
End Class




