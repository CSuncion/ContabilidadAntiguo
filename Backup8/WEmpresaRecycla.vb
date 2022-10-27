Imports Entidad
Imports Negocio

Public Class WEmpresaRecycla
#Region "Propietarios"
    Public wEmp As New WEmpresa
#End Region


    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public emp As New EmpresaRN
    Public cam As New CamposEntidad
    Public ent As New SuperEntidad


#Region "Metodos"

    Sub NuevaVentana()
        '//
        Me.Show()
        ent.CampoOrden = cam.CodEmp
        ent.ColumnaBusqueda = "Codigo"
        Me.ActualizarVentana()
        Me.Owner.Enabled = False
        '\\
    End Sub

    Sub ActualizarVentana()
        '//
        Me.ActualizarDgvUsu()
        Dgv.actualizarBarraEstado(Me.sst1, Me.DgvEmpRecy)
        acc.EstadoBotonesPorGrilla(Me.ListaBotones, Me.DgvEmpRecy)
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvEmpRecy)
        Dgv.pintarColumnaDgv(Me.DgvEmpRecy, ent.CampoOrden)
        '\\
    End Sub

    Sub ActualizarDgvUsu()
        '//
        '/Refrescando el DataSource de DgvUsu
        lista = emp.obtenerEmpresaEli(ent)
        Dgv.refrescarFuenteDatosGrilla(Me.DgvEmpRecy, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvEmpRecy, cam.CodEmp, "Codigo", 120)
        Dgv.asignarColumnaText(Me.DgvEmpRecy, cam.RazSocEmp, "Descripcion", 250)
        Dgv.asignarColumnaText(Me.DgvEmpRecy, cam.DirEmp, "Direccion", 170)
        '//
    End Sub

    Sub Buscar()
        '//
        Dim win As New WBuscar
        win.wEmpRecy = Me
        Me.AddOwnedForm(win)
        win.ventanaBuscar(ent.ColumnaBusqueda)
        '\\
    End Sub

    Sub Recuperar()
        '//
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvEmpRecy, 0)
        Dim rpta As Integer = MsgBox("Deseas Recuperar Esta Empresa", MsgBoxStyle.YesNo)
        If rpta = MsgBoxResult.Yes Then
            'traer el registro
            Dim obj As New SuperEntidad

            obj.DatoCondicion1 = cod
            obj = emp.buscarEmpresaEliPorCodigo(obj)
            'actualizar el registro
            obj.EliminadoRegistro = "1"
            emp.modificarEmpresa(obj)
            MsgBox("Empresa Recuperada", MsgBoxStyle.Information)
            Me.ActualizarVentana()
            'actual wpersonal
            Me.wEmp.ActualizarVentana()
            Dgv.obtenerCursorActual(Me.wEmp.DgvEmp, obj.DescripcionAuxiliar, Me.wEmp.lista)
        Else
            Exit Sub
        End If
        '\\
    End Sub

    Sub Eliminar()
        '//
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvEmpRecy, 0)
        Dim rpta As Integer = MsgBox("Deseas Eliminar Definitivamente Esta Empresa", MsgBoxStyle.YesNo)
        If rpta = MsgBoxResult.Yes Then
            'eliminar el registro
            Dim obj As New SuperEntidad
            obj.CodigoEmpresa = cod
            emp.eliminarEmpresaFis(obj)
            MsgBox("Empresa Eliminada ", MsgBoxStyle.Information)
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

    Private Sub DgvPer_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvEmpRecy.CellEnter
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvEmpRecy)
    End Sub

    Private Sub DgvPer_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvEmpRecy.ColumnHeaderMouseClick
        ent.CampoOrden = Me.DgvEmpRecy.Columns(e.ColumnIndex).Name
        ent.ColumnaBusqueda = Me.DgvEmpRecy.Columns(e.ColumnIndex).HeaderText
        Me.ActualizarVentana()
    End Sub

    Private Sub btnDesplaza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrimero.Click, btnAnterior.Click, btnSiguiente.Click, btnUltimo.Click
        Dgv.desplazamientoFila(Me.DgvEmpRecy, CType(sender, ToolStripButton))
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