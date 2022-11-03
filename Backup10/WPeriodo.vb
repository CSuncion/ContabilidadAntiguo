Option Strict Off
Imports Entidad
Imports Negocio

Public Class WPeriodo

    Public per As New PermisoRN
    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public peri As New PeriodoRN
    Public cam As New CamposEntidad
    Public ent As New SuperEntidad
    Public titulo As String = "Periodo"


#Region "Metodos"

    Sub NuevaVentana()
        '//
        'visualiza el formulario
        Me.Show()
        'orden por defecto
        ent.CampoOrden = cam.CodPer
        ent.ColumnaBusqueda = "Periodo"
        Me.ActualizarVentana()

        '\\
    End Sub

    Sub permisoVentana()
        Dim nReg As Integer = Me.DgvPer.Rows.Count
        Dim lisPer As New List(Of SuperEntidad)
        Dim oPer As New SuperEntidad
        oPer.CodigoUsuario = SuperEntidad.xCodigoUsuario
        oPer.CodigoVentana = "054"
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
                    'Case "09" : Me.btnRecycla.Enabled = vf

            End Select
        Next
    End Sub

    Sub ActualizarVentana()
        '//
        Me.ActualizarDgvTab()
        Dgv.actualizarBarraEstado(Me.sst1, Me.DgvPer)
        acc.EstadoBotonesPorGrilla(Me.ListaBotones, Me.DgvPer)
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvPer)
        Dgv.pintarColumnaDgv(Me.DgvPer, ent.CampoOrden)
        Me.permisoVentana()
        '\\
    End Sub

    Sub ActualizarDgvTab()

        '//
        '/Refrescando el DataSource de DgvUsu
        ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        lista = peri.ListarPeriodos(ent)

        '/Refrescando el DataSource de DgvUsu
        Dgv.refrescarFuenteDatosGrilla(Me.DgvPer, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvPer, cam.CodPer, "Periodo", 120)
        Dgv.asignarColumnaText(Me.DgvPer, cam.NMesPer, "Mes", 120)
        Dgv.asignarColumnaText(Me.DgvPer, cam.NEstPer, "Estado", 90)
        Dgv.asignarColumnaTextVis(Me.DgvPer, cam.ClaPer, "clave", 90, 0)

        '//
    End Sub

    Sub buscar()
        '//
        Dim win As New WBuscar
        win.wper = Me
        Me.AddOwnedForm(win)
        win.ventanaBuscar(ent.ColumnaBusqueda)
        '\\
    End Sub

    Sub adicionar()
        '//
        Dim win As New WEditarPeriodo
        win.wper = Me
        win.operacion = 0
        Me.AddOwnedForm(win)
        win.ventanaAdicionar()
        '\\
    End Sub


    Sub modificar()
        '//
        Dim win As New WEditarPeriodo
        win.wPer = Me
        win.operacion = 1
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvPer, cam.ClaPer)
        win.ventanaModificar(cod)
        '\\
    End Sub

    Sub eliminar()
        'ES ACTO ELIMINAR EL PERIODO
        If Me.EsActoEliminarPeriodo = False Then Exit Sub

        '//
        Dim win As New WEditarPeriodo
        win.wPer = Me
        win.operacion = 2
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvPer, cam.ClaPer)
        win.ventanaEliminar(cod)
        '\\
    End Sub

    Sub Visualizar()
        '//
        Dim win As New WEditarPeriodo
        win.wPer = Me
        win.operacion = 3
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvPer, cam.ClaPer)
        win.ventanaVisualizar(cod)
        '\\
    End Sub

    Function EsActoEliminarPeriodo() As Boolean

        'PREGUNTAR SI ES ACTO ELIMINAR EL PERIODO
        Dim iPerRN As New PeriodoRN
        Dim iPerEN As New SuperEntidad
        iPerEN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iPerEN.CodigoPeriodo = Dgv.obtenerValorCelda(Me.DgvPer, cam.CodPer)
        iPerEN = iPerRN.EsActoEliminarPeriodo(iPerEN)
        If iPerEN.EsVerdad = False Then
            MsgBox(iPerEN.Mensaje, MsgBoxStyle.Exclamation, "Periodo")
        End If
        Return iPerEN.EsVerdad
    End Function


#End Region

    Private Sub btnActualizarTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarTabla.Click
        Me.ActualizarVentana()
    End Sub

    Private Sub DgvDis_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvPer.CellEnter
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvPer)
    End Sub

    Private Sub DgvDis_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvPer.ColumnHeaderMouseClick
        ent.CampoOrden = Me.DgvPer.Columns(e.ColumnIndex).Name
        ent.ColumnaBusqueda = Me.DgvPer.Columns(e.ColumnIndex).HeaderText
        Me.ActualizarVentana()
    End Sub

    Private Sub btnDesplaza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrimero.Click, btnAnterior.Click, btnSiguiente.Click, btnUltimo.Click
        Dgv.desplazamientoFila(Me.DgvPer, CType(sender, ToolStripButton))
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

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '  Me.imprimir()
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Me.Visualizar()
    End Sub

    Private Sub btnRecycla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecycla.Click
        ' Me.recycla()
    End Sub

    Private Sub BtlPeriodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Me.CambiarPeriodo()
    End Sub
End Class




