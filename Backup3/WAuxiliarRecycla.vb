Imports Entidad
Imports Negocio
Public Class WAuxiliarRecycla
#Region "Propietarios"
    Public wAux As New WAuxiliar
#End Region

    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public aux As New AuxiliarRN
    Public cam As New CamposEntidad
    Public ent As New SuperEntidad

#Region "Metodos"

    Sub NuevaVentana()
        '//
        Me.Show()
        ent.CampoOrden = cam.CodAux
        ent.ColumnaBusqueda = "Codigo"
        Me.ActualizarVentana()
        Me.Owner.Enabled = False
        '\\
    End Sub

    Sub ActualizarVentana()
        '//
        Me.ActualizarDgvUsu()
        Dgv.actualizarBarraEstado(Me.sst1, Me.DgvPer)
        acc.EstadoBotonesPorGrilla(Me.ListaBotones, Me.DgvPer)
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvPer)
        Dgv.pintarColumnaDgv(Me.DgvPer, ent.CampoOrden)
        '\\
    End Sub

    Sub ActualizarDgvUsu()
        '//
        '/Refrescando el DataSource de DgvUsu
        lista = aux.obtenerAuxiliaresEli(ent)
        Dgv.refrescarFuenteDatosGrilla(Me.DgvPer, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvPer, cam.CodAux, "Codigo", 120)
        Dgv.asignarColumnaText(Me.DgvPer, cam.DesAux, "Descripcion", 250)
        Dgv.asignarColumnaText(Me.DgvPer, cam.DirAux, "Direccion", 170)
        'Dgv.asignarColumnaText(Me.DgvPer, cam.NomAre, "Area", 100)
        'Dgv.asignarColumnaText(Me.DgvPer, cam.NomCar, "Cargo", 100)
        'Dgv.asignarColumnaText(Me.DgvPer, cam.FecIngPer, "Fecha Alta", 120)
        '//
    End Sub


    Sub Buscar()
        '//
        Dim win As New WBuscar
        win.wAuxRec = Me
        Me.AddOwnedForm(win)
        win.ventanaBuscar(ent.ColumnaBusqueda)
        '\\
    End Sub

    Sub Recuperar()
        '//
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvPer, 0)
        Dim rpta As Integer = MsgBox("Deseas Recuperar este Cliente - Proveedor", MsgBoxStyle.YesNo)
        If rpta = MsgBoxResult.Yes Then
            'traer el registro
            Dim obj As New SuperEntidad

            obj.DatoCondicion1 = cod
            obj = aux.buscarAuxiliarEliPorCodigo(obj)
            'actualizar el registro
            obj.EliminadoRegistro = "1"
            aux.modificarAuxiliar(obj)
            MsgBox("Cliente - Proveedor Recuperado", MsgBoxStyle.Information)
            Me.ActualizarVentana()
            'actual wpersonal
            Me.wAux.ActualizarVentana()
            Dgv.obtenerCursorActual(Me.wAux.DgvAux, obj.DescripcionAuxiliar, Me.wAux.lista)
        Else
            Exit Sub
        End If
        '\\
    End Sub

    Sub Eliminar()
        '//
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvPer, 0)
        Dim rpta As Integer = MsgBox("Deseas Eliminar Definitivamente este Cliente - Proveedor", MsgBoxStyle.YesNo)
        If rpta = MsgBoxResult.Yes Then
            'eliminar el registro
            Dim obj As New SuperEntidad
            obj.CodigoAuxiliar = cod
            aux.eliminarAuxiliarFis(obj)
            MsgBox("Cliente - Proveedor Eliminado ", MsgBoxStyle.Information)
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

    Private Sub DgvPer_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvPer.CellEnter
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvPer)
    End Sub

    Private Sub DgvPer_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvPer.ColumnHeaderMouseClick
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
        Me.Buscar()
    End Sub

    Private Sub btnRecuperar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecuperar.Click
        Me.Recuperar()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Me.Eliminar()
    End Sub
End Class