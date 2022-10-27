Option Strict Off
Imports Entidad
Imports Negocio

Public Class WCuentaBanco

    Public per As New PermisoRN
    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public bco As New CuentaBancoRN
    Public cam As New CamposEntidad
    Public ent As New SuperEntidad
    Public titulo As String = "CuentaBancaria"


#Region "Metodos"

    Sub NuevaVentana()
        '//
        'visualiza el formulario
        Me.Show()
        'orden por defecto
        ent.CampoOrden = cam.CodCtaBco
        ent.ColumnaBusqueda = "Codigo"
        Me.ActualizarVentana()

        '\\
    End Sub


    Sub permisoVentana()
        Dim nReg As Integer = Me.DgvBco.Rows.Count
        Dim lisPer As New List(Of SuperEntidad)
        Dim oPer As New SuperEntidad
        oPer.CodigoUsuario = SuperEntidad.xCodigoUsuario
        oPer.CodigoVentana = "010"
        oPer.CampoOrden = cam.CodVen
        lisPer = per.obtenerPermisosExisXUsuarioYVentana(oPer)
        'RECORRER CADA PERMISO
        For Each p As SuperEntidad In lisPer
            ' 0 : NO TIENE PERMISO ,  1 : SI TIENE PERMISO
            Dim vf As Boolean = IIf(p.OpcionPermiso = 0, False, True)
            'SI LA GRILLA ESTA VACIA LA ACCION QUEDA DESHABILITADA
            If nReg = 0 Then vf = False

            'PASAR vf A LOS BOTONES DE LA VENTANA
            Select Case p.CodigoOpcion
                Case "02" : Me.btnModificar.Enabled = vf
                Case "04" : Me.btnVisualizar.Enabled = vf
            End Select
        Next
    End Sub

    Sub ActualizarVentana()
        '//
        Me.ActualizarDgvTab()
        Dgv.actualizarBarraEstado(Me.sst1, Me.DgvBco)
        acc.EstadoBotonesPorGrilla(Me.ListaBotones, Me.DgvBco)
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvBco)
        Dgv.pintarColumnaDgv(Me.DgvBco, ent.CampoOrden)
        Me.permisoVentana()
        '\\
    End Sub

    Sub ActualizarDgvTab()

        '//
        '/Refrescando el DataSource de DgvUsu
        ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        lista = bco.obtenerCuentaBancoExis(ent)

        '/Refrescando el DataSource de DgvUsu
        Dgv.refrescarFuenteDatosGrilla(Me.DgvBco, lista)
        '/Creando las columnas

        Dgv.asignarColumnaText(Me.DgvBco, cam.CodCtaBco, "Codigo", 70)
        Dgv.asignarColumnaText(Me.DgvBco, cam.BcoCtaBco, "Banco", 255)
        Dgv.asignarColumnaText(Me.DgvBco, cam.AgeCtaBco, "Agencia", 170)
        Dgv.asignarColumnaText(Me.DgvBco, cam.NumCtaBco, "Numero", 130)
        Dgv.asignarColumnaText(Me.DgvBco, cam.MonCtaBco, "Moneda", 70)
        Dgv.asignarColumnaText(Me.DgvBco, cam.TipCtaBco, "Tipo", 75)
        Dgv.AsignarColumnaTextNumerico(Me.DgvBco, cam.SalCtaBco, "Saldo", 80, 2)
        Dgv.asignarColumnaText(Me.DgvBco, cam.EstCtaBco, "Estado", 80)
        Dgv.asignarColumnaTextVis(Me.DgvBco, cam.ClaCtaBco, "Clave", 60, 0)
        '//
    End Sub

    Sub buscar()
        '//
        Dim win As New WBuscar
        win.wBco = Me
        win.titulo = Me.titulo
        Me.AddOwnedForm(win)
        win.ventanaBuscar(ent.ColumnaBusqueda)
        '\\
    End Sub

    Sub modificar()
        '//
        Dim win As New WEditarCuentaBanco
        win.wBco = Me
        win.operacion = 1
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvBco, cam.ClaCtaBco)
        win.ventanaModificar(cod)
        '\\
    End Sub

    Sub eliminar()
        '//
        Dim win As New WEditarCuentaBanco
        win.wBco = Me
        win.operacion = 2
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvBco, cam.ClaCtaBco)
        win.ventanaEliminar(cod)
        '\\
    End Sub

    Sub Visualizar()
        '//
        Dim win As New WEditarCuentaBanco
        win.wBco = Me
        win.operacion = 3
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvBco, cam.ClaCtaBco)
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
        Dim win As New WCuentaBancoRecycla
        win.wCbco = Me
        Me.AddOwnedForm(win)
        win.NuevaVentana()
    End Sub
    Sub CierreMensual()
        Dim win As New WCierreBanco
        'win.wBco = Me
        'Me.AddOwnedForm(win)
        win.InicializaVentana()
    End Sub
#End Region

    Private Sub btnActualizarTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarTabla.Click
        Me.ActualizarVentana()
    End Sub

    Private Sub DgvDis_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvBco.CellEnter
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvBco)
    End Sub

    Private Sub DgvDis_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvBco.ColumnHeaderMouseClick
        ent.CampoOrden = Me.DgvBco.Columns(e.ColumnIndex).Name
        ent.ColumnaBusqueda = Me.DgvBco.Columns(e.ColumnIndex).HeaderText
        Me.ActualizarVentana()
    End Sub

    Private Sub btnDesplaza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrimero.Click, btnAnterior.Click, btnSiguiente.Click, btnUltimo.Click
        Dgv.desplazamientoFila(Me.DgvBco, CType(sender, ToolStripButton))
    End Sub

    Private Sub btnRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Me.buscar()
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

    Private Sub btnCierre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.CierreMensual()
    End Sub
End Class