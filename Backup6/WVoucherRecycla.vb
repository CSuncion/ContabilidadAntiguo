Imports Entidad
Imports Negocio

Public Class WVoucherRecycla
#Region "Propietarios"
    Public wVou As New WVoucher
#End Region
    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public vou As New VoucherRN
    Public cam As New CamposEntidad
    Public ent As New SuperEntidad


#Region "Metodos"

    Sub NuevaVentana()
        '//
        Me.Show()
        ent.CampoOrden = cam.ClaVou
        ent.ColumnaBusqueda = "Clave"
        Me.ActualizarVentana()
        Me.Owner.Enabled = False
        '\\
    End Sub

    Sub ActualizarVentana()
        '//
        Me.ActualizarDgvUsu()
        Dgv.actualizarBarraEstado(Me.sst1, Me.DgvVouRec)
        acc.EstadoBotonesPorGrilla(Me.ListaBotones, Me.DgvVouRec)
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvVouRec)
        Dgv.pintarColumnaDgv(Me.DgvVouRec, ent.CampoOrden)
        '\\
    End Sub

    Sub ActualizarDgvUsu()
        '//
        '/Refrescando el DataSource de DgvUsu
        lista = vou.obtenerVoucherEli(ent)
        Dgv.refrescarFuenteDatosGrilla(Me.DgvVouRec, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvVouRec, cam.ClaVou, "Clave", 80)
        Dgv.asignarColumnaText(Me.DgvVouRec, cam.CodEmp, "Empresa", 100)
        Dgv.asignarColumnaText(Me.DgvVouRec, cam.CodOriRC, "Origen", 80)
        Dgv.asignarColumnaText(Me.DgvVouRec, cam.CodFilRC, "File", 80)
        'Dgv.asignarColumnaText(Me.DgvVouRec, cam.NumCtaBco, "Numero Cta", 80)
        '//
    End Sub

    Sub Buscar()
        '//
        Dim win As New WBuscar
        win.wVouRec = Me
        Me.AddOwnedForm(win)
        win.ventanaBuscar(ent.ColumnaBusqueda)
        '\\
    End Sub

    Sub Recuperar()
        '//
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvVouRec, 0)
        Dim rpta As Integer = MsgBox("Deseas Recuperar esta Voucher", MsgBoxStyle.YesNo, "Voucher")
        If rpta = MsgBoxResult.Yes Then
            'traer el registro
            Dim obj As New SuperEntidad
            obj.DatoCondicion1 = cod
            'obj.ClaveCuentaBanco = cod
            obj = vou.buscarVoucherEliPorCodigo(obj)
            'actualizar el registro
            obj.EliminadoRegistro = "1"
            vou.modificarVoucher(obj)
            MsgBox("Voucher Recuperado", MsgBoxStyle.Information)
            Me.ActualizarVentana()
            'actual wpersonal
            Me.wVou.ActualizarVentana()
            'Dim fecha As String = obj.FechaTipoCambio.Day.ToString + "/" + obj.FechaTipoCambio.Month.ToString + "/" + obj.FechaTipoCambio.Year.ToString
            Dgv.obtenerCursorActual(Me.wVou.DgvVou, obj.ClaveVoucher, Me.wVou.lista)
        Else
            Exit Sub
        End If
        '\\
    End Sub

    Sub Eliminar()
        '//
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvVouRec, 0)
        'cod = CType(cod, Date).Year.ToString + "/" + CType(cod, Date).Month.ToString + "/" + CType(cod, Date).Day.ToString
        Dim rpta As Integer = MsgBox("Deseas Eliminar Definitivamente este Voucher", MsgBoxStyle.YesNo, "Voucher")
        If rpta = MsgBoxResult.Yes Then
            'eliminar el registro
            Dim obj As New SuperEntidad
            obj.ClaveVoucher = cod
            vou.eliminarVoucherFis(obj)
            MsgBox("Voucher Eliminado ", MsgBoxStyle.Information)
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

    Private Sub DgvPer_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvVouRec.CellEnter
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvVouRec)
    End Sub

    Private Sub DgvPer_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvVouRec.ColumnHeaderMouseClick
        ent.CampoOrden = Me.DgvVouRec.Columns(e.ColumnIndex).Name
        ent.ColumnaBusqueda = Me.DgvVouRec.Columns(e.ColumnIndex).HeaderText
        Me.ActualizarVentana()
    End Sub

    Private Sub btnDesplaza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrimero.Click, btnAnterior.Click, btnSiguiente.Click, btnUltimo.Click
        Dgv.desplazamientoFila(Me.DgvVouRec, CType(sender, ToolStripButton))
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