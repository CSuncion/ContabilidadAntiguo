Option Strict Off
Imports Entidad
Imports Negocio


Public Class WFormatoContable

    Public per As New PermisoRN
    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public fcon As New FormatoContableRN
    Public cam As New CamposEntidad
    Public ent As New SuperEntidad
    Public titulo As String = "FormatoContable"

#Region "Metodos"

    Sub NuevaVentana()
        '//
        'visualiza el formulario
        Me.Show()
        'orden por defecto
        ent.CampoOrden = cam.ClaForCon
        ent.ColumnaBusqueda = "Clave"
        Me.ActualizarVentana()

        '\\
    End Sub


    Sub permisoVentana()
        Dim nReg As Integer = Me.DgvFcon.Rows.Count
        Dim lisPer As New List(Of SuperEntidad)
        Dim oPer As New SuperEntidad
        oPer.CodigoUsuario = SuperEntidad.xCodigoUsuario
        oPer.CodigoVentana = "015"
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
        Dgv.actualizarBarraEstado(Me.sst1, Me.DgvFcon)
        acc.EstadoBotonesPorGrilla(Me.ListaBotones, Me.DgvFcon)
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvFcon)
        Dgv.pintarColumnaDgv(Me.DgvFcon, ent.CampoOrden)
        Me.permisoVentana()
        '\\
    End Sub

    Sub ActualizarDgvTab()

        '//
        '/Refrescando el DataSource de DgvUsu
        ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        lista = fcon.obtenerFormatoContableExis(ent)

        '/Refrescando el DataSource de DgvUsu
        Dgv.refrescarFuenteDatosGrilla(Me.DgvFcon, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvFcon, cam.ClaForCon, "Clave", 60)
        Dgv.asignarColumnaText(Me.DgvFcon, cam.CodEmp, "Empresa", 60)
        Dgv.asignarColumnaText(Me.DgvFcon, cam.CodForCon, "Codigo", 60)
        Dgv.asignarColumnaText(Me.DgvFcon, cam.DesForCon, "Descripcion", 265)
        Dgv.asignarColumnaText(Me.DgvFcon, cam.GruForCon, "Grupo", 100)
        Dgv.asignarColumnaText(Me.DgvFcon, cam.NatForCon, "Naturaleza", 90)
        Dgv.asignarColumnaText(Me.DgvFcon, cam.EstForCon, "Estado", 100)
        Dgv.asignarColumnaText(Me.DgvFcon, cam.Des1ForCon, "Descripcion Alterna", 265)

        '//
    End Sub

    Sub buscar()
        '//
        Dim win As New WBuscar
        win.wFcon = Me
        win.titulo = Me.titulo
        Me.AddOwnedForm(win)
        win.ventanaBuscar(ent.ColumnaBusqueda)
        '\\
    End Sub

    Sub adicionar()
        '//
        Dim win As New WEditarFormatoContable
        win.wfcon = Me
        win.operacion = 0
        Me.AddOwnedForm(win)
        win.ventanaAdicionar()
        '\\
    End Sub


    Sub modificar()
        '//
        Dim win As New WEditarFormatoContable
        win.wfcon = Me
        win.operacion = 1
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvFcon, cam.ClaForCon)
        win.ventanaModificar(cod)
        '\\
    End Sub

    Sub eliminar()
        '//
        Dim win As New WEditarFormatoContable
        win.wfcon = Me
        win.operacion = 2
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvFcon, cam.ClaForCon)
        win.ventanaEliminar(cod)
        '\\
    End Sub

    Sub Visualizar()
        '//
        Dim win As New WEditarFormatoContable
        win.wfcon = Me
        win.operacion = 3
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvFcon, cam.ClaForCon)
        win.ventanaVisualizar(cod)
        '\\
    End Sub

    Sub imprimir()
        '//
        Dim imp As New WImpFormatos
        imp.wfcon = Me
        Me.AddOwnedForm(imp)
        imp.InicializaVentana()
        '\\
    End Sub

    Sub CopiarFormato()
        Dim win As New WCopiarFormatoContable
        win.wFcon = Me
        Me.AddOwnedForm(win)
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvFcon, cam.CodEmp)
        win.NuevaVentana(cod)
    End Sub


    Sub recycla()
        Dim win As New WFormatoContableRecycla
        win.wFcon = Me
        Me.AddOwnedForm(win)
        win.NuevaVentana()
    End Sub


    Sub exportar()
        '    Dim win As New WComprobanterecycla
        '    win.wCom = Me
        '    Me.AddOwnedForm(win)
        '    win.NuevaVentana()
    End Sub

#End Region

    Private Sub btnActualizarTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarTabla.Click
        Me.ActualizarVentana()
    End Sub

    Private Sub DgvAux_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvFcon.CellEnter
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvFcon)
    End Sub

    Private Sub DgvPer_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvFcon.ColumnHeaderMouseClick
        ent.CampoOrden = Me.DgvFcon.Columns(e.ColumnIndex).Name
        ent.ColumnaBusqueda = Me.DgvFcon.Columns(e.ColumnIndex).HeaderText
        Me.ActualizarVentana()
    End Sub

    Private Sub btnDesplaza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrimero.Click, btnAnterior.Click, btnSiguiente.Click, btnUltimo.Click
        Dgv.desplazamientoFila(Me.DgvFcon, CType(sender, ToolStripButton))
    End Sub

    Private Sub btnRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Me.buscar()
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
        Me.Visualizar()
    End Sub

    Private Sub btnRecycla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecycla.Click
        Me.recycla()
    End Sub

    Private Sub btnCopiarFormato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopiarFormato.Click
        Me.CopiarFormato()
    End Sub
End Class