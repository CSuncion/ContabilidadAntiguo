Option Strict Off
Imports Entidad
Imports Negocio

Public Class WAuxiliar

    Public per As New PermisoRN
    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public aux As New AuxiliarRN
    Public cam As New CamposEntidad
    Public ent As New SuperEntidad
    Public titulo As String = "Cliente - Proveedor - Personal"


#Region "Metodos"

    Sub NuevaVentana()
        '//
        Me.Show()
        ent.CampoOrden = cam.CodAux
        ent.ColumnaBusqueda = "Codigo"
        Me.ActualizarVentana()
        '\\
    End Sub

    Sub permisoVentana()
        Dim nReg As Integer = Me.DgvAux.Rows.Count
        Dim lisPer As New List(Of SuperEntidad)
        Dim oPer As New SuperEntidad
        oPer.CodigoUsuario = SuperEntidad.xCodigoUsuario
        oPer.CodigoVentana = "012"
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
        Me.ActualizarDgvUsu()
        Dgv.actualizarBarraEstado(Me.sst1, Me.DgvAux)
        acc.EstadoBotonesPorGrilla(Me.ListaBotones, Me.DgvAux)
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvAux)
        Dgv.pintarColumnaDgv(Me.DgvAux, ent.CampoOrden)
        Me.permisoVentana()
        '\\
    End Sub

    Sub ActualizarDgvUsu()
        '//
        '/Refrescando el DataSource de DgvUsu
        lista = aux.obtenerAuxiliaresExis(ent)
        '/Refrescando el DataSource de DgvUsu

        Dgv.refrescarFuenteDatosGrilla(Me.DgvAux, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvAux, cam.CodAux, "Codigo", 100)
        Dgv.asignarColumnaText(Me.DgvAux, cam.DesAux, "Razon Social / Nombre", 370)
        Dgv.asignarColumnaText(Me.DgvAux, cam.DirAux, "Direccion", 380)
        Dgv.asignarColumnaText(Me.DgvAux, cam.TipAux, "Tipo", 100)
        Dgv.asignarColumnaText(Me.DgvAux, cam.CorAux, "E-Mail", 150)
        '//
    End Sub

    Sub Buscar()
        '//
        Dim win As New WBuscar
        win.wAux = Me
        Me.AddOwnedForm(win)
        win.ventanaBuscar(ent.ColumnaBusqueda)
        '\\
    End Sub
    Sub adicionar()
        Dim win As New WSelecionaAuxiliar
        win.wAux = Me
        Me.AddOwnedForm(win)
        win.InicializaVentana()
    End Sub

    Sub modificar()
        '/Obtener el codigo de usuario
        Dim obj As New SuperEntidad
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvAux, cam.CodAux)
        obj.CodigoAuxiliar = cod
        obj = aux.buscarAuxiliarExisPorCodigo(obj)

        'MsgBox(obj.TipoAuxiliar, MsgBoxStyle.Critical)

        Select Case obj.TipoAuxiliar.ToUpper

            Case "PERSONAL".ToUpper
                Dim win As New WEditarAuxiliarPer
                win.wAux = Me
                titulo = "Persona Natural"
                win.operacion = 1
                Me.AddOwnedForm(win)
                win.ventanaModificar(cod)

            Case "CLIENTE/PROVEEDOR".ToUpper, "PROVEEDOR".ToUpper, "CLIENTE".ToUpper
                Dim win As New WEditarAuxiliar
                win.wAux = Me
                titulo = "Persona Juridica"
                win.operacion = 1
                Me.AddOwnedForm(win)
                win.ventanaModificar(cod)
        End Select


    End Sub

    Sub eliminar()
        '//
        Dim obj As New SuperEntidad
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvAux, cam.CodAux)
        obj.CodigoAuxiliar = cod

        'If letr.esClienteConLetrasPendientes(obj) = True Then
        '    MsgBox("Este cliente tiene deudas y no se puede eliminar", MsgBoxStyle.Exclamation, Me.titulo)
        '    Exit Sub
        'End If

        obj = aux.buscarAuxiliarExisPorCodigo(obj)

        Select Case obj.TipoAuxiliar.ToUpper
            Case "PERSONAL".ToUpper
                'cliente no tiene deudas entonces se puede eliminar
                Dim win As New WEditarAuxiliarPer
                win.wAux = Me
                titulo = "Persona Natural"
                win.operacion = 2
                Me.AddOwnedForm(win)
                '/Obtener el codigo de usuario
                win.ventanaEliminar(cod)

            Case "CLIENTE/PROVEEDOR".ToUpper, "PROVEEDOR".ToUpper, "CLIENTE".ToUpper
                'cliente no tiene deudas entonces se puede eliminar
                Dim win As New WEditarAuxiliar
                win.wAux = Me
                titulo = "Persona Juridica"
                win.operacion = 2
                Me.AddOwnedForm(win)
                '/Obtener el codigo de usuario
                win.ventanaEliminar(cod)

        End Select

        '\\
    End Sub

    Sub visualizar()

        Dim obj As New SuperEntidad
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvAux, cam.CodAux)
        obj.CodigoAuxiliar = cod
        obj = aux.buscarAuxiliarExisPorCodigo(obj)

        Select Case obj.TipoAuxiliar.ToUpper
            Case "PERSONAL".ToUpper
                Dim win As New WEditarAuxiliarPer
                win.wAux = Me
                titulo = "Persona Natural"
                win.operacion = 3
                Me.AddOwnedForm(win)
                '/Obtener el codigo de usuario
                win.ventanaVisualizar(cod)
            Case "CLIENTE/PROVEEDOR".ToUpper, "PROVEEDOR".ToUpper, "CLIENTE".ToUpper
                Dim win As New WEditarAuxiliar
                win.wAux = Me
                titulo = "Persona Juridica"
                win.operacion = 3
                Me.AddOwnedForm(win)
                '/Obtener el codigo de usuario
                win.ventanaVisualizar(cod)
        End Select
        '\\
    End Sub
    Sub imprimir()
        '//
        Dim imp As New WImpAuxiliar
        imp.wAux = Me
        Me.AddOwnedForm(imp)
        imp.InicializaVentana()
        '\\
    End Sub

    Sub exportar()
        '//
        Dim imp As New WRptAux
        imp.wAux = Me
        imp.ent.CampoOrden = cam.CodAux
        imp.Exportar()
        ''\\
    End Sub

    Sub recycla()
        Dim win As New WAuxiliarRecycla
        win.wAux = Me
        Me.AddOwnedForm(win)
        win.NuevaVentana()
    End Sub

#End Region



    Private Sub btnActualizarTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarTabla.Click
        Me.ActualizarVentana()
    End Sub

    Private Sub DgvAux_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvAux.CellEnter
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvAux)
    End Sub

    Private Sub DgvPer_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvAux.ColumnHeaderMouseClick
        ent.CampoOrden = Me.DgvAux.Columns(e.ColumnIndex).Name
        ent.ColumnaBusqueda = Me.DgvAux.Columns(e.ColumnIndex).HeaderText
        Me.ActualizarVentana()
    End Sub

    Private Sub btnDesplaza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrimero.Click, btnAnterior.Click, btnSiguiente.Click, btnUltimo.Click
        Dgv.desplazamientoFila(Me.DgvAux, CType(sender, ToolStripButton))
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

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Me.visualizar()
    End Sub

    Private Sub btnRecycla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecycla.Click
        Me.recycla()
    End Sub
End Class