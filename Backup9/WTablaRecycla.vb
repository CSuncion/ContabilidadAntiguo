Imports Entidad
Imports Negocio
Public Class WTablaRecycla
#Region "Propietarios"
    Public wTab As New WTabla
#End Region
    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public tab As New TablaRN
    Public cam As New CamposEntidad
    Public ent As New SuperEntidad

#Region "Metodos"

    Sub NuevaVentana()
        '//
        Me.Show()
        Me.Text = "Papelera de " + Me.wTab.Text
        ent.CampoOrden = cam.CodItemTabla
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
        ent.DatoCondicion1 = Me.wTab.tipoTabla
        Select Case Me.wTab.Text
            Case "Contrato Personal"
                ent.DatoFiltro1 = "0201"
                lista = tab.obtenerItemsTablaEliPorTipoTablayFiltroCodigo(ent)
            Case "Contrato Servicio"
                ent.DatoFiltro1 = "0202"
                lista = tab.obtenerItemsTablaEliPorTipoTablayFiltroCodigo(ent)
            Case Else
                lista = tab.obtenerItemsTablaEliPorTipoTabla(ent)
        End Select
        '/Refrescando el DataSource de DgvUsu
        Dgv.refrescarFuenteDatosGrilla(Me.DgvPer, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvPer, cam.CodItemTabla, "Codigo", 120)
        Dgv.asignarColumnaText(Me.DgvPer, cam.NomItemTabla, "Nombre", 220)
 
        '//
    End Sub


    Sub Buscar()
        '//
        Dim win As New WBuscar
        win.wTabRec = Me
        Me.AddOwnedForm(win)
        win.ventanaBuscar(ent.ColumnaBusqueda)
        '\\
    End Sub

    Sub Recuperar()
        '//
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvPer, cam.CodItemTabla)
        Dim rpta As Integer = MsgBox("Deseas Recuperar este Registro", MsgBoxStyle.YesNo)
        If rpta = MsgBoxResult.Yes Then
            'traer el registro
            Dim obj As New SuperEntidad
            obj.DatoCondicion1 = Me.wTab.tipoTabla
            obj.DatoCondicion2 = cod
            obj = tab.buscarItemTablaEliPorTipoTablaYCodigo(obj)
            'actualizar el registro
            If Me.wTab.arg <> "File" Then
                obj.Voucher = "0"
            End If
            obj.EliminadoRegistro = "1"
            tab.modificarItemTabla(obj)
            MsgBox("Regsitro Recuperado", MsgBoxStyle.Information)
            Me.ActualizarVentana()
            'actual wpersonal
            Me.wTab.ActualizarVentana()
            Dgv.obtenerCursorActual(Me.wTab.DgvDis, cod, Me.wTab.lista)
        Else
            Exit Sub
        End If
        '\\
    End Sub

    Sub Eliminar()
        '//
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvPer, 0)
        Dim rpta As Integer = MsgBox("Deseas Eliminar Definitivamente este " + Me.wTab.Text, MsgBoxStyle.YesNo)
        If rpta = MsgBoxResult.Yes Then
            'eliminar el registro
            Dim obj As New SuperEntidad
            obj.CodigoItemTabla = cod
            obj.TipoTabla = Me.wTab.tipoTabla
            tab.eliminarItemTablaFis(obj)
            MsgBox("Registro Eliminado ", MsgBoxStyle.Information)
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