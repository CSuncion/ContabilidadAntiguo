Imports Entidad
Imports Negocio

Public Class WFormatoContableRecycla
#Region "Propietarios"
    Public wFcon As New WFormatoContable
#End Region
    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public fcon As New FormatoContableRN
    Public cam As New CamposEntidad
    Public ent As New SuperEntidad

#Region "Metodos"

    Sub NuevaVentana()
        '//
        Me.Show()
        ent.CampoOrden = cam.ClaForCon
        ent.ColumnaBusqueda = "Clave"
        Me.ActualizarVentana()
        Me.Owner.Enabled = False
        '\\
    End Sub

    Sub ActualizarVentana()
        '//
        Me.ActualizarDgvUsu()
        Dgv.actualizarBarraEstado(Me.sst1, Me.DgvFconRec)
        acc.EstadoBotonesPorGrilla(Me.ListaBotones, Me.DgvFconRec)
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvFconRec)
        Dgv.pintarColumnaDgv(Me.DgvFconRec, ent.CampoOrden)
        '\\
    End Sub

    Sub ActualizarDgvUsu()
        '//
        '/Refrescando el DataSource de DgvUsu
        lista = fcon.obtenerFormatoContableEli(ent)
        Dgv.refrescarFuenteDatosGrilla(Me.DgvFconRec, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvFconRec, cam.ClaForCon, "Clave", 80)
        Dgv.asignarColumnaText(Me.DgvFconRec, cam.CodForCon, "Codigo", 80)
        Dgv.asignarColumnaText(Me.DgvFconRec, cam.DesForCon, "Descripcion", 150)
        '//
    End Sub

    Sub Buscar()
        '//
        Dim win As New WBuscar
        win.wFconRec = Me
        Me.AddOwnedForm(win)
        win.ventanaBuscar(ent.ColumnaBusqueda)
        '\\
    End Sub

    Sub Recuperar()
        '//
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvFconRec, 0)
        Dim rpta As Integer = MsgBox("Deseas Recuperar este Formato", MsgBoxStyle.YesNo, "Formatos")
        If rpta = MsgBoxResult.Yes Then
            'traer el registro
            Dim obj As New SuperEntidad

            obj.DatoCondicion1 = cod
            obj = fcon.buscarFormatoContableEliPorCodigo(obj)
            'actualizar el registro
            obj.EliminadoRegistro = "1"
            fcon.modificarFormatoContable(obj)
            MsgBox("Formato Recuperado", MsgBoxStyle.Information)
            Me.ActualizarVentana()
            'actual wpersonal
            Me.wFcon.ActualizarVentana()
            'Dim fecha As String = obj.FechaTipoCambio.Day.ToString + "/" + obj.FechaTipoCambio.Month.ToString + "/" + obj.FechaTipoCambio.Year.ToString
            Dgv.obtenerCursorActual(Me.wFcon.DgvFcon, obj.ClaveFormatoContable, Me.wFcon.lista)
        Else
            Exit Sub
        End If
        '\\
    End Sub

    Sub Eliminar()
        '//
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvFconRec, 0)
        'cod = CType(cod, Date).Year.ToString + "/" + CType(cod, Date).Month.ToString + "/" + CType(cod, Date).Day.ToString
        Dim rpta As Integer = MsgBox("Deseas Eliminar Definitivamente este Formato", MsgBoxStyle.YesNo, "Formatos")
        If rpta = MsgBoxResult.Yes Then
            'eliminar el registro
            Dim obj As New SuperEntidad
            obj.ClaveFormatoContable = cod
            fcon.eliminarFormatoContableFis(obj)
            MsgBox("Formato Eliminado ", MsgBoxStyle.Information)
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

    Private Sub DgvPer_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvFconRec.CellEnter
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvFconRec)
    End Sub

    Private Sub DgvPer_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvFconRec.ColumnHeaderMouseClick
        ent.CampoOrden = Me.DgvFconRec.Columns(e.ColumnIndex).Name
        ent.ColumnaBusqueda = Me.DgvFconRec.Columns(e.ColumnIndex).HeaderText
        Me.ActualizarVentana()
    End Sub

    Private Sub btnDesplaza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrimero.Click, btnAnterior.Click, btnSiguiente.Click, btnUltimo.Click
        Dgv.desplazamientoFila(Me.DgvFconRec, CType(sender, ToolStripButton))
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