Imports Entidad
Imports Negocio

Public Class WCuentaBancoRecycla
#Region "Propietarios"
    Public wCbco As New WCuentaBanco
#End Region
    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public cbco As New CuentaBancoRN
    Public cam As New CamposEntidad
    Public ent As New SuperEntidad


#Region "Metodos"

    Sub NuevaVentana()
        '//
        Me.Show()
        ent.CampoOrden = cam.ClaCtaBco
        ent.ColumnaBusqueda = "Clave"
        Me.ActualizarVentana()
        Me.Owner.Enabled = False
        '\\
    End Sub

    Sub ActualizarVentana()
        '//
        Me.ActualizarDgvUsu()
        Dgv.actualizarBarraEstado(Me.sst1, Me.DgvCBcoRec)
        acc.EstadoBotonesPorGrilla(Me.ListaBotones, Me.DgvCBcoRec)
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvCBcoRec)
        Dgv.pintarColumnaDgv(Me.DgvCBcoRec, ent.CampoOrden)
        '\\
    End Sub

    Sub ActualizarDgvUsu()
        '//
        '/Refrescando el DataSource de DgvUsu
        lista = cbco.obtenerCuentaBancoEli(ent)
        Dgv.refrescarFuenteDatosGrilla(Me.DgvCBcoRec, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvCBcoRec, cam.ClaCtaBco, "Clave", 80)
        Dgv.asignarColumnaText(Me.DgvCBcoRec, cam.CodCtaBco, "Cuenta", 80)
        Dgv.asignarColumnaText(Me.DgvCBcoRec, cam.BcoCtaBco, "Banco", 150)
        Dgv.asignarColumnaText(Me.DgvCBcoRec, cam.NumCtaBco, "Numero Cta", 80)
        '//
    End Sub

    Sub Buscar()
        '//
        Dim win As New WBuscar
        win.wBcorec = Me
        Me.AddOwnedForm(win)
        win.ventanaBuscar(ent.ColumnaBusqueda)
        '\\
    End Sub

    Sub Recuperar()
        '//
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvCBcoRec, 0)
        Dim rpta As Integer = MsgBox("Deseas Recuperar esta Cuenta", MsgBoxStyle.YesNo, "Cuentas")
        If rpta = MsgBoxResult.Yes Then
            'traer el registro
            Dim obj As New SuperEntidad
            obj.DatoCondicion1 = cod
            'obj.ClaveCuentaBanco = cod
            obj = cbco.buscarCuentaBancoEliPorCodigo(obj)
            'actualizar el registro
            obj.EliminadoRegistro = "1"
            cbco.modificarCuentaBanco(obj)
            MsgBox("Cuenta Recuperada", MsgBoxStyle.Information)
            Me.ActualizarVentana()
            'actual wpersonal
            Me.wcbco.ActualizarVentana()
            'Dim fecha As String = obj.FechaTipoCambio.Day.ToString + "/" + obj.FechaTipoCambio.Month.ToString + "/" + obj.FechaTipoCambio.Year.ToString
            Dgv.obtenerCursorActual(Me.wCbco.DgvBco, obj.BancoCuentaBanco, Me.wCbco.lista)
        Else
            Exit Sub
        End If
        '\\
    End Sub

    Sub Eliminar()
        '//
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvCBcoRec, 0)
        'cod = CType(cod, Date).Year.ToString + "/" + CType(cod, Date).Month.ToString + "/" + CType(cod, Date).Day.ToString
        Dim rpta As Integer = MsgBox("Deseas Eliminar Definitivamente esta Cuenta", MsgBoxStyle.YesNo, "Clientes")
        If rpta = MsgBoxResult.Yes Then
            'eliminar el registro
            Dim obj As New SuperEntidad
            obj.ClaveCuentaBanco = cod
            cbco.eliminarCuentaBancoFis(obj)
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

    Private Sub DgvPer_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvCBcoRec.CellEnter
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvCBcoRec)
    End Sub

    Private Sub DgvPer_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvCBcoRec.ColumnHeaderMouseClick
        ent.CampoOrden = Me.DgvCBcoRec.Columns(e.ColumnIndex).Name
        ent.ColumnaBusqueda = Me.DgvCBcoRec.Columns(e.ColumnIndex).HeaderText
        Me.ActualizarVentana()
    End Sub

    Private Sub btnDesplaza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrimero.Click, btnAnterior.Click, btnSiguiente.Click, btnUltimo.Click
        Dgv.desplazamientoFila(Me.DgvCBcoRec, CType(sender, ToolStripButton))
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