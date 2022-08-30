Option Strict Off
Imports Entidad
Imports Negocio

Public Class WTipoCambio

    Public per As New PermisoRN
    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public tc As New TipoCambioRN
    Public cam As New CamposEntidad
    Public ent As New SuperEntidad

#Region "Metodos"

    Sub NuevaVentana()
        '//
        Me.Show()
        ent.CampoOrden = cam.FecTipCam
        ent.ColumnaBusqueda = "Fecha"
        Me.ActualizarVentana()
        '\\
    End Sub

    Sub permisoVentana()
        Dim nReg As Integer = Me.DgvDis.Rows.Count
        Dim lisPer As New List(Of SuperEntidad)
        Dim oPer As New SuperEntidad
        oPer.CodigoUsuario = SuperEntidad.xCodigoUsuario
        oPer.CodigoVentana = "013"
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
        Me.ActualizarDgvDpm()
        Dgv.actualizarBarraEstado(Me.sst1, Me.DgvDis)
        acc.EstadoBotonesPorGrilla(Me.ListaBotones, Me.DgvDis)
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvDis)
        Dgv.pintarColumnaDgv(Me.DgvDis, ent.CampoOrden)
        Me.permisoVentana()
        '\\
    End Sub

    Sub ActualizarDgvDpm()
        '//
        '/Refrescando el DataSource de DgvUsu
        lista = tc.obtenerTiposCambiosExis(ent)
        Dgv.refrescarFuenteDatosGrilla(Me.DgvDis, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvDis, cam.FecTipCam, "Fecha", 100)
        Dgv.asignarColumnaText(Me.DgvDis, cam.ComTipCam, "Compra US$", 100)
        Dgv.asignarColumnaText(Me.DgvDis, cam.VenTipCam, "Venta US$", 100)
        Dgv.asignarColumnaText(Me.DgvDis, cam.ComEurTipCam, "Compra CAD", 100)
        Dgv.asignarColumnaText(Me.DgvDis, cam.VenEurTipCam, "Venta CAD", 100)
        Dgv.asignarColumnaText(Me.DgvDis, cam.DolEurTipCam, "Dola- Eur", 100)
        '//
    End Sub

    Sub Buscar()
        '//
        Dim win As New WBuscar
        win.wTc = Me
        Me.AddOwnedForm(win)
        win.ventanaBuscar(ent.ColumnaBusqueda)
        '\\
    End Sub

    Sub adicionar()
        '//
        Dim win As New WEditarTipoCambio
        win.wTc = Me
        Me.AddOwnedForm(win)
        win.ventanaAdicionar()
        '\\
    End Sub

    Sub modificar()
        '//
        Dim win As New WEditarTipoCambio
        win.wTc = Me
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvDis, 0)
        cod = CType(cod, Date).Year.ToString + "/" + CType(cod, Date).Month.ToString + "/" + CType(cod, Date).Day.ToString
        win.ventanaModificar(cod)
        '\\
    End Sub

    Sub eliminar()
        '//
        Dim win As New WEditarTipoCambio
        win.wTc = Me
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvDis, 0)
        cod = CType(cod, Date).Year.ToString + "/" + CType(cod, Date).Month.ToString + "/" + CType(cod, Date).Day.ToString
        win.ventanaEliminar(cod)
        '\\
    End Sub

    Sub visualizar()
        '//
        Dim win As New WEditarTipoCambio
        win.wTc = Me
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvDis, 0)
        cod = CType(cod, Date).Year.ToString + "/" + CType(cod, Date).Month.ToString + "/" + CType(cod, Date).Day.ToString
        win.ventanaVisualizar(cod)
        '\\
    End Sub

    Sub imprimir()
        '//
        Dim imp As New WImprimirTipoCambio
        imp.wTc = Me
        Me.AddOwnedForm(imp)
        imp.nuevaVentana()
        '\\
    End Sub

    Sub exportar()
        '//
        'Dim imp As New WRptDiasPorMes
        'imp.ent.CampoOrden = cam.AnoMesDiasxMes
        'imp.Exportar()
        '\\
    End Sub

    Sub recycla()
        Dim win As New WTipoCambioRecycla
        win.wTipCam = Me
        Me.AddOwnedForm(win)
        win.NuevaVentana()
    End Sub

    Sub Estado()
        'Dim win As New WPersonalEstado
        'win.wPer = Me
        'Me.AddOwnedForm(win)
        'Dim codPer As String = Dgv.obtenerValorCelda(Me.DgvPer, 0)
        'win.ventanaModificar(codPer)
    End Sub


#End Region


    Private Sub btnActualizarTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarTabla.Click
        Me.ActualizarVentana()
    End Sub

    Private Sub DgvPer_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvDis.CellEnter
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvDis)
    End Sub

    Private Sub DgvPer_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvDis.ColumnHeaderMouseClick
        ent.CampoOrden = Me.DgvDis.Columns(e.ColumnIndex).Name
        ent.ColumnaBusqueda = Me.DgvDis.Columns(e.ColumnIndex).HeaderText
        Me.ActualizarVentana()
    End Sub

    Private Sub btnDesplaza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrimero.Click, btnAnterior.Click, btnSiguiente.Click, btnUltimo.Click
        Dgv.desplazamientoFila(Me.DgvDis, CType(sender, ToolStripButton))
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

    Private Sub btnEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEstado.Click
        Me.Estado()
    End Sub
End Class