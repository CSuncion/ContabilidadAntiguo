Imports Entidad
Imports Negocio

Public Class WPlanDeCuentasRecycla

#Region "Propietarios"
    Public wPcta As New WPcge
#End Region

    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public pcta As New PlanDeCuentasRN
    Public cam As New CamposEntidad
    Public ent As New SuperEntidad

#Region "Metodos"

    Sub NuevaVentana()
        '//
        Me.Show()
        ent.CampoOrden = cam.CodCtaPcge
        ent.ColumnaBusqueda = "Cuenta"
        Me.ActualizarVentana()
        Me.Owner.Enabled = False
        '\\
    End Sub

    Sub ActualizarVentana()
        '//
        Me.ActualizarDgvUsu()
        Dgv.actualizarBarraEstado(Me.sst1, Me.DgvCta)
        acc.EstadoBotonesPorGrilla(Me.ListaBotones, Me.DgvCta)
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvCta)
        Dgv.pintarColumnaDgv(Me.DgvCta, ent.CampoOrden)
        '\\
    End Sub

    Sub ActualizarDgvUsu()
        '//
        '/Refrescando el DataSource de DgvUsu
        lista = pcta.obtenerplanDeCuentasEli(ent)
        Dgv.refrescarFuenteDatosGrilla(Me.DgvCta, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvCta, cam.CodCtaPcge, "Cuenta", 80)
        Dgv.asignarColumnaText(Me.DgvCta, cam.NomCtaPcge, "Descripcion Cuenta", 150)
        Dgv.asignarColumnaText(Me.DgvCta, cam.NumDigPcge, "Numero", 80)
        '//
    End Sub


    Sub Buscar()
        '//
        Dim win As New WBuscar
        win.wPctaRec = Me
        Me.AddOwnedForm(win)
        win.ventanaBuscar(ent.ColumnaBusqueda)
        '\\
    End Sub

    Sub Recuperar()
        '//
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvCta, cam.CodCtaPcge)

        Dim rpta As Integer = MsgBox("Deseas Recuperar esta Cuenta", MsgBoxStyle.YesNo, "Cuentas")
        If rpta = MsgBoxResult.Yes Then
            'traer el registro
            Dim obj As New SuperEntidad
            obj.DatoCondicion1 = cod
            obj = pcta.buscarPlanDeCuentasEliPorCodigo(obj)
            'actualizar el registro
            obj.EliminadoRegistro = "1"
            pcta.modificarPlanDeCuentas(obj)
            MsgBox("Cuenta Recuperada", MsgBoxStyle.Information)
            Me.ActualizarVentana()

            'actual wpersonal
            Me.wPcta.ActualizarVentana()
            Dgv.obtenerCursorActual(Me.wPcta.DgvPctaRec, cod, Me.wPcta.lista)
        Else
            Exit Sub
        End If
        '\\
    End Sub

    Sub Eliminar()
        '//
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvCta, cam.CodCtaPcge)

        Dim rpta As Integer = MsgBox("Deseas Eliminar Definitivamente esta Cuenta", MsgBoxStyle.YesNo, "Clientes")
        If rpta = MsgBoxResult.Yes Then
            'eliminar el registro
            Dim obj As New SuperEntidad
            obj.CodigoCuentaPcge = cod
            pcta.eliminarPlanDeCuentasFis(obj)
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

    Private Sub DgvPer_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvCta.CellEnter
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvCta)
    End Sub

    Private Sub DgvPer_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvCta.ColumnHeaderMouseClick
        ent.CampoOrden = Me.DgvCta.Columns(e.ColumnIndex).Name
        ent.ColumnaBusqueda = Me.DgvCta.Columns(e.ColumnIndex).HeaderText
        Me.ActualizarVentana()
    End Sub

    Private Sub btnDesplaza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrimero.Click, btnAnterior.Click, btnSiguiente.Click, btnUltimo.Click
        Dgv.desplazamientoFila(Me.DgvCta, CType(sender, ToolStripButton))
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