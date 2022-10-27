Option Strict Off
Imports Entidad
Imports Negocio

Public Class WTransferencia

    Public per As New PermisoRN
    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public trans As New RegContabCabeRN
    Public cam As New CamposEntidad
    Public ent, entpar As New SuperEntidad
    Public titulo As String = "Transferencia"
    Public par As New ParametroRN
    Public periodo As String

#Region "Metodos"

    Sub NuevaVentana()
        '//
        'visualiza el formulario
        Me.Show()
        'orden por defecto
        entpar = par.buscarParametroExis(entpar)
        periodo = SuperEntidad.xPeriodoEmpresa
        ent.CampoOrden = cam.ClaveRCC
        ent.ColumnaBusqueda = "Clave"
        Me.ActualizarVentana()

        '\\
    End Sub


    Sub permisoVentana()
        Dim nReg As Integer = Me.DgvTrans.Rows.Count
        Dim lisPer As New List(Of SuperEntidad)
        Dim oPer As New SuperEntidad
        oPer.CodigoUsuario = SuperEntidad.xCodigoUsuario
        oPer.CodigoVentana = "020"
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
            End Select
        Next
    End Sub

    Sub ActualizarVentana()
        '//
        Me.ActualizarDgvTab()
        Dgv.actualizarBarraEstado(Me.sst1, Me.DgvTrans)
        acc.EstadoBotonesPorGrilla(Me.ListaBotones, Me.DgvTrans)
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvTrans)
        Dgv.pintarColumnaDgv(Me.DgvTrans, ent.CampoOrden)
        Me.permisoVentana()
        '\\
    End Sub

    Sub ActualizarDgvTab()
        '//
        '/Refrescando el DataSource de DgvUsu
        ent.PeriodoRegContabCabe = periodo
        lista = trans.ListarEgresosTransfereciaXPeriodoYEmpresa(ent)

        '/Refrescando el DataSource de DgvUsu
        Dgv.refrescarFuenteDatosGrilla(Me.DgvTrans, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvTrans, cam.ClaveRCC, "Clave", 134)
        Dgv.asignarColumnaText(Me.DgvTrans, cam.NomOriRC, "Origen", 100)
        Dgv.asignarColumnaText(Me.DgvTrans, cam.NomFilRC, "File", 190)
        Dgv.asignarColumnaText(Me.DgvTrans, cam.NumVouRCC, "Numero Voucher", 120)
        Dgv.asignarColumnaText(Me.DgvTrans, cam.FecVouRCC, "Fecha Voucher", 130)
        Dgv.AsignarColumnaTextNumerico(Me.DgvTrans, cam.ImpRCC, "Importe", 90, 2)
        Dgv.asignarColumnaText(Me.DgvTrans, cam.VouIngRCC, "Voucher Ingreso", 140)
        Dgv.asignarColumnaText(Me.DgvTrans, cam.CodCtaBco, "Cuenta", 70)
        Dgv.asignarColumnaText(Me.DgvTrans, cam.BcoCtaBco, "Banco", 180)
        Dgv.asignarColumnaText(Me.DgvTrans, cam.NumCtaBco, "Numero", 80)
        Dgv.asignarColumnaText(Me.DgvTrans, cam.MonCtaBco, "Moneda", 80)

        '//
    End Sub

    Sub buscar()
        '//
        Dim win As New WBuscar
        win.wTrans = Me
        win.titulo = Me.titulo
        Me.AddOwnedForm(win)
        win.ventanaBuscar(ent.ColumnaBusqueda)
        '\\
    End Sub

    Sub Filtrar()
        Dim win As New WFitrarPeriodo
        win.wRgTransfer = Me
        win.TipoRg = "Transferencia"
        Me.AddOwnedForm(win)
        win.nuevo()
    End Sub


    Sub adicionar()
        '//
        Dim win As New WEditarTransferencia
        win.wTran = Me
        win.operacion = 0
        Me.AddOwnedForm(win)
        win.ventanaAdicionar()
        '\\
    End Sub

    Sub modificar()
        '//
        Dim win As New WEditarTransferencia
        win.wTran = Me
        win.operacion = 1
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvTrans, cam.ClaveRCC)
        Dim cod1 As String = Dgv.obtenerValorCelda(Me.DgvTrans, cam.VouIngRCC)
        win.ventanaModificar(cod, cod1)
        '\\
    End Sub

    Sub Copiar()
        '//
        Dim win As New WEditarTransferencia
        win.wTran = Me
        win.operacion = 5
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvTrans, cam.ClaveRCC)
        Dim cod1 As String = Dgv.obtenerValorCelda(Me.DgvTrans, cam.VouIngRCC)
        win.ventanaCopiar(cod, cod1)
        '\\
    End Sub

    Sub eliminar()
        '//
        Dim win As New WEditarTransferencia
        win.wTran = Me
        win.operacion = 2
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvTrans, cam.ClaveRCC)
        Dim cod1 As String = Dgv.obtenerValorCelda(Me.DgvTrans, cam.VouIngRCC)
        win.ventanaEliminar(cod, cod1)
        '\\
    End Sub

    Sub Visualizar()
        '//
        Dim win As New WEditarTransferencia
        win.wTran = Me
        win.operacion = 3
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvTrans, cam.ClaveRCC)
        Dim cod1 As String = Dgv.obtenerValorCelda(Me.DgvTrans, cam.VouIngRCC)
        win.ventanaVisualizar(cod, cod1)
        '\\
    End Sub

    Function EsActoEstornarRegistro() As Boolean
        Dim iRccRN As New RegContabCabeRN
        Dim iRccEN As New SuperEntidad
        iRccEN.ClaveRegContabCabe = Dgv.obtenerValorCelda(Me.DgvTrans, cam.ClaveRCC)
        iRccEN = iRccRN.EsActoEstornarRegistro(iRccEN)
        If iRccEN.EsVerdad = False Then
            MsgBox(iRccEN.Mensaje, MsgBoxStyle.Exclamation, "Registro contable")
        End If
        Return iRccEN.EsVerdad
    End Function

    Sub Estornar()
        'preguntar si es acto estornar
        If Me.EsActoEstornarRegistro = False Then Exit Sub

        'preguntar si desas realizar la operacion
        Dim rpta As Integer = MsgBox("Deseas estornar este registro", MsgBoxStyle.YesNo, "Registro contable")
        If rpta = MsgBoxResult.No Then Exit Sub

        'estornar el registro
        Me.EstornarRegistroContable()

        'mensaje de operacion realizada
        MsgBox("El registro fue estornado", MsgBoxStyle.Information, "Registro contable")

        'actualizar la ventana
        Me.ActualizarVentana()

    End Sub

    Public Sub EstornarRegistroContable()
        'aqui hay 2 registors contables que hay que estornar
        Dim iRccRN As New RegContabCabeRN
        Dim iRccSalEN As New SuperEntidad
        iRccSalEN.ClaveRegContabCabe = Dgv.obtenerValorCelda(Me.DgvTrans, cam.ClaveRCC)

        'estornando el registro salida
        iRccRN.EstornarRegistroContable(iRccSalEN)

        'estornando el registro ingreso
        Dim iRccIngEN As New SuperEntidad
        iRccIngEN.ClaveRegContabCabe = Dgv.obtenerValorCelda(Me.DgvTrans, cam.VouIngRCC)
        iRccRN.EstornarRegistroContable(iRccIngEN)

    End Sub

    Sub wImpVoucher()
        '/
        Dim win As New WImpVoucherIngresoSalida
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvTrans, cam.ClaveRCC)
        Dim ob As New SuperEntidad
        ob.ClaveRegContabCabe = cod
        win.ent = trans.buscarRegContabExisPorClave(ob)
        win.NuevaVentana()
    End Sub

#End Region

    Private Sub btnRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Me.buscar()
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
        ' Me.imprimir()
    End Sub

    Private Sub btnExportar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        ' Me.exportar()
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Me.Visualizar()
    End Sub

    Private Sub btnRecycla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecycla.Click
        'Me.recycla()
    End Sub

    Private Sub DgvPer_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvTrans.ColumnHeaderMouseClick
        ent.CampoOrden = Me.DgvTrans.Columns(e.ColumnIndex).Name
        ent.ColumnaBusqueda = Me.DgvTrans.Columns(e.ColumnIndex).HeaderText
        Me.ActualizarVentana()
    End Sub

    Private Sub btnDesplaza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrimero.Click, btnAnterior.Click, btnSiguiente.Click, btnUltimo.Click
        Dgv.desplazamientoFila(Me.DgvTrans, CType(sender, ToolStripButton))
    End Sub

    Private Sub btnActualizarTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarTabla.Click
        Me.ActualizarVentana()
    End Sub

    Private Sub btnCopiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopiar.Click
        Me.Copiar()
    End Sub

    Private Sub btnEstornar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEstornar.Click
        Me.Estornar()
    End Sub

    Private Sub btnVoucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoucher.Click
        Me.wImpVoucher()
    End Sub
End Class