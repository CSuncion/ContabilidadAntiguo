Imports Entidad
Imports Negocio

Public Class WPlanCuentaGeRecycla
#Region "Propietarios"
    Public wPcg As New WPlanCuentaGe
#End Region

    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public pcg As New PlanCuentaGeRN
    Public cam As New CamposEntidad
    Public ent As New SuperEntidad


#Region "Metodos"

    Sub NuevaVentana()
        '//
        Me.Show()
        ent.CampoOrden = cam.CodCtaPcge
        ent.ColumnaBusqueda = "Clave"
        Me.ActualizarVentana()
        Me.Owner.Enabled = False
        '\\
    End Sub

    Sub ActualizarVentana()
        '//
        Me.ActualizarDgvUsu()
        Dgv.actualizarBarraEstado(Me.sst1, Me.DgvPcgRecy)
        acc.EstadoBotonesPorGrilla(Me.ListaBotones, Me.DgvPcgRecy)
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvPcgRecy)
        Dgv.pintarColumnaDgv(Me.DgvPcgRecy, ent.CampoOrden)
        '\\
    End Sub

    Sub ActualizarDgvUsu()
        '//
        '/Refrescando el DataSource de DgvUsu
        lista = pcg.obtenerCuentaEli(ent)
        Dgv.refrescarFuenteDatosGrilla(Me.DgvPcgRecy, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvPcgRecy, cam.ClaCtaPcge, "Clave", 80)
        Dgv.asignarColumnaText(Me.DgvPcgRecy, cam.CodCtaPcge, "Codigo", 120)
        Dgv.asignarColumnaText(Me.DgvPcgRecy, cam.NomCtaPcge, "Descripcion", 250)

        '//
    End Sub


    Sub Buscar()
        '//
        Dim win As New WBuscar
        win.wPcgRecy = Me
        Me.AddOwnedForm(win)
        win.ventanaBuscar(ent.ColumnaBusqueda)
        '\\
    End Sub

    Sub Recuperar()
        '//
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvPcgRecy, 0)
        Dim rpta As Integer = MsgBox("Deseas Recuperar esta Cuenta", MsgBoxStyle.YesNo)
        If rpta = MsgBoxResult.Yes Then
            'traer el registro
            Dim obj As New SuperEntidad

            obj.DatoCondicion1 = cod

            obj = pcg.buscarCuentaEliPorClave(obj)
            'actualizar el registro
            obj.EliminadoRegistro = "1"
            pcg.modificarCuenta(obj)
            MsgBox("Cuenta Recuperada", MsgBoxStyle.Information)
            Me.ActualizarVentana()
            'actual wpersonal
            Me.wPcg.ActualizarVentana()
            Dgv.obtenerCursorActual(Me.wPcg.DgvPcg, obj.DescripcionAuxiliar, Me.wPcg.lista)
        Else
            Exit Sub
        End If
        '\\
    End Sub

    Sub Eliminar()
        '//
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvPcgRecy, 0)
        Dim rpta As Integer = MsgBox("Deseas Eliminar Definitivamente esta Cuenta", MsgBoxStyle.YesNo)
        If rpta = MsgBoxResult.Yes Then
            'eliminar el registro
            Dim obj As New SuperEntidad
            obj.ClaveCuentaPcge = cod
            pcg.eliminarCuentaFis(obj)
            MsgBox("Cuenta Eliminada ", MsgBoxStyle.Information)
            Me.ActualizarVentana()
        Else
            Exit Sub
        End If
    End Sub

#End Region

    Private Sub WPersonalRecycla_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnActualizarTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarTabla.Click
        Me.ActualizarVentana()
    End Sub

    Private Sub DgvPer_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvPcgRecy.CellEnter
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvPcgRecy)
    End Sub

    Private Sub DgvPer_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvPcgRecy.ColumnHeaderMouseClick
        ent.CampoOrden = Me.DgvPcgRecy.Columns(e.ColumnIndex).Name
        ent.ColumnaBusqueda = Me.DgvPcgRecy.Columns(e.ColumnIndex).HeaderText
        Me.ActualizarVentana()
    End Sub

    Private Sub btnDesplaza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrimero.Click, btnAnterior.Click, btnSiguiente.Click, btnUltimo.Click
        Dgv.desplazamientoFila(Me.DgvPcgRecy, CType(sender, ToolStripButton))
    End Sub

    Private Sub btnRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Me.Buscar()
    End Sub

    Private Sub btnRecuperar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecuperar.Click
        Me.Recuperar()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Me.Eliminar()
    End Sub

End Class