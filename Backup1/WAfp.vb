Option Strict Off
Imports Entidad
Imports Negocio

Public Class WAfp

    Public per As New PermisoRN
    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public afp As New AfpRN
    Public cam As New CamposEntidad
    Public ent As New SuperEntidad
    Public titulo As String = "Afp"


#Region "Metodos"

    Sub NuevaVentana()
        '//
        Me.Show()
        ent.CampoOrden = cam.CodAfp
        ent.ColumnaBusqueda = "Codigo"
        Me.ActualizarVentana()
        '\\
    End Sub

    Sub permisoVentana()
        Dim nReg As Integer = Me.DgvAfp.Rows.Count
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
        Dgv.actualizarBarraEstado(Me.sst1, Me.DgvAfp)
        acc.EstadoBotonesPorGrilla(Me.ListaBotones, Me.DgvAfp)
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvAfp)
        Dgv.pintarColumnaDgv(Me.DgvAfp, ent.CampoOrden)
        Me.permisoVentana()
        '\\
    End Sub

    Sub ActualizarDgvUsu()
        '//
        '/Refrescando el DataSource de DgvUsu
        lista = afp.obtenerAfpExis(ent)
        '/Refrescando el DataSource de DgvUsu

        Dgv.refrescarFuenteDatosGrilla(Me.DgvAfp, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvAfp, cam.CodAfp, "Codigo Afp", 100)
        Dgv.asignarColumnaText(Me.DgvAfp, cam.NomAfp, "Nombre Afp", 300)
        Dgv.AsignarColumnaTextNumerico(Me.DgvAfp, cam.PorFonAfp, "% Fondo", 100, 3)
        Dgv.AsignarColumnaTextNumerico(Me.DgvAfp, cam.PorSegAfp, "% Seguro", 100, 3)
        Dgv.AsignarColumnaTextNumerico(Me.DgvAfp, cam.PorSobRemAfp, "% Sobre Remuneracion", 150, 3)
        Dgv.AsignarColumnaTextNumerico(Me.DgvAfp, cam.PorEspAfp, "% Especial", 100, 3)
        Dgv.asignarColumnaText(Me.DgvAfp, cam.EstAfp, "Estado Afp", 100)

        '//
    End Sub

    Sub Buscar()
        '//
        Dim win As New WBuscar
        win.wAfps = Me
        Me.AddOwnedForm(win)
        win.ventanaBuscar(ent.ColumnaBusqueda)
        '\\
    End Sub

    Sub adicionar()
        '//
        Dim win As New WEditarAfp
        win.wAfp = Me
        win.operacion = 0
        Me.AddOwnedForm(win)
        win.ventanaAdicionar()
        '\\
    End Sub


    Sub modificar()
        '//
        Dim win As New WEditarAfp
        win.wAfp = Me
        win.operacion = 1
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvAfp, cam.CodAfp)
        win.ventanaModificar(cod)
        '\\
    End Sub

    Sub eliminar()
        '//
        Dim win As New WEditarAfp
        win.wAfp = Me
        win.operacion = 2
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvAfp, cam.CodAfp)
        win.ventanaEliminar(cod)
        '\\
    End Sub

    Sub Visualizar()
        '//
        Dim win As New WEditarAfp
        win.wAfp = Me
        win.operacion = 3
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvAfp, cam.CodAfp)
        win.ventanaVisualizar(cod)
        '\\
    End Sub
    Sub imprimir()
        '//
        'Dim imp As New WImpAuxiliar
        'imp.wAux = Me
        'Me.AddOwnedForm(imp)
        'imp.InicializaVentana()
        '\\
    End Sub

    Sub exportar()
        '//
        'Dim imp As New WRptAux
        'imp.wAux = Me
        'imp.ent.CampoOrden = cam.CodAux
        'imp.Exportar()
        ''\\
    End Sub

    Sub recycla()
        'Dim win As New WAuxiliarRecycla
        'win.wAux = Me
        'Me.AddOwnedForm(win)
        'win.NuevaVentana()
    End Sub

#End Region



    Private Sub btnActualizarTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarTabla.Click
        Me.ActualizarVentana()
    End Sub

    Private Sub DgvAux_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvAfp.CellEnter
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvAfp)
    End Sub

    Private Sub DgvPer_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvAfp.ColumnHeaderMouseClick
        ent.CampoOrden = Me.DgvAfp.Columns(e.ColumnIndex).Name
        ent.ColumnaBusqueda = Me.DgvAfp.Columns(e.ColumnIndex).HeaderText
        Me.ActualizarVentana()
    End Sub

    Private Sub btnDesplaza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrimero.Click, btnAnterior.Click, btnSiguiente.Click, btnUltimo.Click
        Dgv.desplazamientoFila(Me.DgvAfp, CType(sender, ToolStripButton))
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