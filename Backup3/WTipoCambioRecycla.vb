Imports Entidad
Imports Negocio
Public Class WTipoCambioRecycla
#Region "Propietarios"
    Public wTipCam As New WTipoCambio
#End Region
    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public tic As New TipoCambioRN
    Public cam As New CamposEntidad
    Public ent As New SuperEntidad

#Region "Metodos"

    Sub NuevaVentana()
        '//
        Me.Show()
        ent.CampoOrden = cam.FecTipCam
        ent.ColumnaBusqueda = "Fecha"
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
        lista = tic.obtenerTiposCambiosEli(ent)
        Dgv.refrescarFuenteDatosGrilla(Me.DgvPer, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvPer, cam.FecTipCam, "Fecha", 120)
        Dgv.asignarColumnaText(Me.DgvPer, cam.ComTipCam, "Compra", 100)
        Dgv.asignarColumnaText(Me.DgvPer, cam.VenTipCam, "Venta", 100)
        'Dgv.asignarColumnaText(Me.DgvPer, cam.NomAre, "Area", 100)
        'Dgv.asignarColumnaText(Me.DgvPer, cam.NomCar, "Cargo", 100)
        'Dgv.asignarColumnaText(Me.DgvPer, cam.FecIngPer, "Fecha Alta", 120)
        '//
    End Sub


    Sub Buscar()
        '//
        Dim win As New WBuscar
        win.wTipCamRec = Me
        Me.AddOwnedForm(win)
        win.ventanaBuscar(ent.ColumnaBusqueda)
        '\\
    End Sub

    Sub Recuperar()
        '//
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvPer, 0)
        cod = CType(cod, Date).Year.ToString + "/" + CType(cod, Date).Month.ToString + "/" + CType(cod, Date).Day.ToString
        Dim rpta As Integer = MsgBox("Deseas Recuperar este Tipo de Cambio", MsgBoxStyle.YesNo)
        If rpta = MsgBoxResult.Yes Then
            'traer el registro
            Dim obj As New SuperEntidad
            obj.DatoCondicion1 = cod
            obj = tic.buscarTipoCambioEliPorFecha(obj)
            'actualizar el registro
            obj.EliminadoRegistro = "1"
            tic.modificarTipoCambio(obj)
            MsgBox("Tipo de cambio Recuperado", MsgBoxStyle.Information)
            Me.ActualizarVentana()
            'actual wpersonal
            Me.wTipCam.ActualizarVentana()
            Dim fecha As String = obj.FechaTipoCambio.Day.ToString + "/" + obj.FechaTipoCambio.Month.ToString + "/" + obj.FechaTipoCambio.Year.ToString
            Dgv.obtenerCursorActual(Me.wTipCam.DgvDis, fecha, Me.wTipCam.lista)
        Else
            Exit Sub
        End If
        '\\
    End Sub

    Sub Eliminar()
        '//
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvPer, 0)
        cod = CType(cod, Date).Year.ToString + "/" + CType(cod, Date).Month.ToString + "/" + CType(cod, Date).Day.ToString
        Dim rpta As Integer = MsgBox("Deseas Eliminar Definitivamente este Tipo de cambio", MsgBoxStyle.YesNo)
        If rpta = MsgBoxResult.Yes Then
            'eliminar el registro
            Dim obj As New SuperEntidad
            obj.FechaTipoCambio = CType(cod, Date)
            tic.eliminarTipoCambioFis(obj)
            MsgBox("Tipo de cambio Eliminado ", MsgBoxStyle.Information)
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