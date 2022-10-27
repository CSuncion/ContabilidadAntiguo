Option Strict Off
Imports Entidad
Imports Negocio

Public Class WRegistroCompra

    Public per As New PermisoRN
    Public acc As New Accion
    Public lista, lD As New List(Of SuperEntidad)
    Public rc As New RegContabCabeRN
    Public rcd As New RegContabDetaRN
    Public emp As New EmpresaRN
    Public cam As New CamposEntidad
    Public ent, entPar, entDeta As New SuperEntidad
    Public par As New ParametroRN
    Public titulo As String
    Public periodo As String

#Region "Metodos"

    Sub NuevaVentana()
        '//
        Me.Show()
        'periodo actual
        entPar = par.buscarParametroExis(entPar)
        periodo = SuperEntidad.xPeriodoEmpresa

        ent.CampoOrden = cam.ClaveRCC
        ent.ColumnaBusqueda = "Codigo"
        Me.ActualizarVentana()
        '\\
    End Sub

    Sub permisoVentana()
        Dim nReg As Integer = Me.DgvRcom.Rows.Count
        Dim lisPer As New List(Of SuperEntidad)
        Dim oPer As New SuperEntidad
        oPer.CodigoUsuario = SuperEntidad.xCodigoUsuario
        oPer.CodigoVentana = "022"
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
        Me.ActualizarDgvUsu()
        'Me.ActualizarDgvDeta()
        Dgv.actualizarBarraEstado(Me.sst1, Me.DgvRcom)
        acc.EstadoBotonesPorGrilla(Me.ListaBotones, Me.DgvRcom)
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvRcom)
        Dgv.pintarColumnaDgv(Me.DgvRcom, ent.CampoOrden)
        Me.permisoVentana()     ''OJO FALTA VER COMO FUNCIONA
        '\\
    End Sub

    Sub ActualizarDgvUsu()
        '//
        '/Refrescando el DataSource de DgvUsu
        ent.CodigoOrigen = "4"
        ent.PeriodoRegContabCabe = periodo
        ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        lista = rc.obtenerRegContabCabeExisXOrigenYPeriodo(ent)

        Dgv.refrescarFuenteDatosGrilla(Me.DgvRcom, lista)
        '/Creando las columnas

        Dgv.asignarColumnaText(Me.DgvRcom, cam.ClaveRCC, "Clave", 140)
        Dgv.asignarColumnaText(Me.DgvRcom, cam.NomOriRC, "Origen", 80)
        Dgv.asignarColumnaText(Me.DgvRcom, cam.NomFilRC, "File", 180)
        Dgv.asignarColumnaText(Me.DgvRcom, cam.NumVouRCC, "Numero Voucher", 110)
        Dgv.asignarColumnaText(Me.DgvRcom, cam.FecVouRCC, "Fecha Voucher", 110)
        Dgv.asignarColumnaText(Me.DgvRcom, cam.DesAux, "Proveedor", 250)
        Dgv.asignarColumnaText(Me.DgvRcom, cam.NomTipDoc, "Documento", 100)
        Dgv.asignarColumnaText(Me.DgvRcom, cam.SerDoC, "Serie", 60)
        Dgv.asignarColumnaText(Me.DgvRcom, cam.NumDoc, "Numero", 100)
        Dgv.asignarColumnaText(Me.DgvRcom, cam.FecDoc, "Fecha", 100)
        Dgv.AsignarColumnaTextNumerico(Me.DgvRcom, cam.PreVtaRCC, "P.Venta", 100, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvRcom, cam.ValVtaRCC, "V.Venta", 100, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvRcom, cam.IgvRCC, "Igv", 100, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvRcom, cam.IgvPar, "%Igv", 60, 2)

        '//
    End Sub


    Sub Buscar()
        '//
        Dim win As New WBuscar
        win.wRc = Me
        Me.AddOwnedForm(win)
        win.ventanaBuscar(ent.ColumnaBusqueda)
        '\\
    End Sub

    Sub Filtrar()
        Dim win As New WFitrarPeriodo
        win.wRgCompras = Me
        win.TipoRg = "Compras"
        Me.AddOwnedForm(win)
        win.nuevo()
    End Sub

    Sub adicionar()
        '//
        Dim win As New WSeleccionaCompra
        win.wRc = Me
        Me.AddOwnedForm(win)
        win.InicializaVentana()
        '\\
    End Sub

    Sub adicionarManual()
        '//
        Dim win As New WEditarRegistroCompra
        win.wRc = Me
        win.operacion = 4
        Me.AddOwnedForm(win)
        win.ventanaAdicionarManual()
        '\\
    End Sub


    Sub modificar()
        'si el registro esta estornado o es un estorno entonces no se puede modificar
        If Me.EsActoEstornarRegistro = False Then Exit Sub

        '/Obtener el codigo de usuario
        Dim obj As New SuperEntidad
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvRcom, cam.ClaveRCC)
        obj.ClaveRegContabCabe = cod
        obj = rc.buscarRegContabExisPorClave(obj)

        Select Case obj.CodigoFile.ToUpper

            Case "410", "411", "412"
                Dim win As New WEditarRegistroCompraDua
                win.wRc = Me
                titulo = "Registro Compras"
                win.operacion = 1
                Me.AddOwnedForm(win)
                win.ventanaModificar(cod)
            Case Else
                Dim win As New WEditarRegistroCompra
                win.wRc = Me
                titulo = "Registro Compra"
                win.operacion = 1
                Me.AddOwnedForm(win)
                win.ventanaModificar(cod)

        End Select


    End Sub

    Sub Copiar()
        '/Obtener el codigo de usuario
        Dim obj As New SuperEntidad
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvRcom, cam.ClaveRCC)
        obj.ClaveRegContabCabe = cod
        obj = rc.buscarRegContabExisPorClave(obj)

        Select Case obj.CodigoFile.ToUpper

            Case "410", "411", "412"
                Dim win As New WEditarRegistroCompraDua
                win.wRc = Me
                titulo = "Registro Compras"
                win.operacion = 5
                Me.AddOwnedForm(win)
                win.ventanaCopiar(cod)
            Case Else
                Dim win As New WEditarRegistroCompra
                win.wRc = Me
                titulo = "Registro Compra"
                win.operacion = 5
                Me.AddOwnedForm(win)
                win.ventanaCopiar(cod)

        End Select
    End Sub

    Sub DatosDetraccion()
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvRcom, cam.ClaveRCC)
        Dim win As New WEditarDatosDetraccion
        win.wRc = Me
        titulo = "Registro Compra"
        win.operacion = 1
        Me.AddOwnedForm(win)
        win.ventanadatosdetraccion(cod)

    End Sub



    Sub eliminar()
        'si el registro esta estornado o es un estorno entonces no se puede eliminar
        If Me.EsActoEstornarRegistro = False Then Exit Sub

        '/Obtener el codigo de usuario
        Dim obj As New SuperEntidad
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvRcom, cam.ClaveRCC)
        obj.ClaveRegContabCabe = cod
        obj = rc.buscarRegContabExisPorClave(obj)

        Select Case obj.CodigoFile.ToUpper

            Case "410", "411", "412"
                Dim win As New WEditarRegistroCompraDua
                win.wRc = Me
                titulo = "Registro Compras"
                win.operacion = 2
                Me.AddOwnedForm(win)
                win.ventanaEliminar(cod)
            Case Else
                Dim win As New WEditarRegistroCompra
                win.wRc = Me
                titulo = "Registro Compra"
                win.operacion = 2
                Me.AddOwnedForm(win)
                win.ventanaEliminar(cod)

        End Select
    End Sub

    Sub visualizar()
        '//
        Dim obj As New SuperEntidad
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvRcom, cam.ClaveRCC)
        obj.ClaveRegContabCabe = cod
        obj = rc.buscarRegContabExisPorClave(obj)

        Select Case obj.CodigoFile.ToUpper

            Case "410", "411", "412"
                Dim win As New WEditarRegistroCompraDua
                win.wRc = Me
                titulo = "Registro Compras"
                win.operacion = 3
                Me.AddOwnedForm(win)
                win.ventanaVisualizar(cod)
            Case Else
                Dim win As New WEditarRegistroCompra
                win.wRc = Me
                titulo = "Registro Compra"
                win.operacion = 3
                Me.AddOwnedForm(win)
                win.ventanaVisualizar(cod)

        End Select
        '\\
    End Sub

    Sub imprimir()
        '//
        'Dim imp As New WImprimirRegCompras
        'imp.wRegCom = Me
        'Me.AddOwnedForm(imp)
        'imp.nuevaVentana()
        ''\\
    End Sub

    Sub exportar()
        '//
        'Dim imp As New WRptPer
        'imp.ent.CampoOrden = cam.CodPer
        'imp.ent.DatoEstado = ""
        'imp.Exportar()
        '\\
    End Sub

    Sub recycla()
        'Dim win As New wPersonalRecycla
        'win.wPer = Me
        'Me.AddOwnedForm(win)
        'win.NuevaVentana()
    End Sub

    Sub Estado()
        'Dim win As New WPersonalEstado
        'win.wPer = Me
        'Me.AddOwnedForm(win)
        'Dim codPer As String = Dgv.obtenerValorCelda(Me.DgvPer, 0)
        'win.ventanaModificar(codPer)
    End Sub

    Function EsActoEstornarRegistro() As Boolean
        Dim iRccRN As New RegContabCabeRN
        Dim iRccEN As New SuperEntidad
        iRccEN.ClaveRegContabCabe = Dgv.obtenerValorCelda(Me.DgvRcom, cam.ClaveRCC)
        iRccEN = iRccRN.EsActoEstornarRegistro(iRccEN)
        If iRccEN.EsVerdad = False Then
            MsgBox(iRccEN.Mensaje, MsgBoxStyle.Exclamation, "Registro contable")
        End If
        Return iRccEN.EsVerdad
    End Function

    Function EsDocumentoPagado() As Boolean
        Dim pv As Decimal = CType(Dgv.obtenerValorCelda(Me.DgvRcom, cam.PreVtaRCC), Decimal)

        Dim ccte As New CuentaCorrienteRN
        Dim obj As New SuperEntidad
        obj.ClaveCuentaCorriente = Dgv.obtenerValorCelda(Me.DgvRcom, cam.ClaveRCC)
        obj = ccte.buscarCuentaCorrienteExisPorClaveCC(obj)

        If obj.ImportePagadoCuentaCorriente <> 0 Then
            MsgBox("Documento ya tiene pagos no se puede realizar la operacion", MsgBoxStyle.Exclamation, "Honorarios")
            Return True
        Else
            'COMPARAR EL PRECIO VENTA DEL DOCUMENTO ACTUAL ANTES DE LA MODIFICACION
            'CON EL VALOR ORIGINAL EN CUENTA CORRIENTE, SI ESTOS NO COINCIDEN QUIERE
            'DECIR QUE SE LE APLICO UNA NOTA DE CREDITO A ESTE COMPROBANTE
            If pv <> obj.ImporteOriginalCuentaCorriente Then
                MsgBox("Este documento tiene nota de credito aplicados,no se puede realizar la operacion", MsgBoxStyle.Exclamation, "Compras")
                Return True
            Else
                Return False
            End If
        End If

    End Function

    Sub Estornar()
        'preguntar si es acto estornar
        If Me.EsActoEstornarRegistro = False Then Exit Sub

        'ahora preguntar si este documento no ha sido pagado
        ' If Me.EsDocumentoPagado = True Then Exit Sub

        'preguntar si desas realizar la operacion
        Dim rpta As Integer = MsgBox("Deseas estornar este registro", MsgBoxStyle.YesNo, "Registro contable")
        If rpta = MsgBoxResult.No Then Exit Sub

        'sacar la cuenta corriente
        Me.eliminarCuentaCorriente()

        'estornar el registro
        Me.EstornarRegistroContable()

        'mensaje de operacion realizada
        MsgBox("El registro fue estornado", MsgBoxStyle.Information, "Registro contable")

        'actualizar la ventana
        Me.ActualizarVentana()

    End Sub

    Public Sub EstornarRegistroContable()
        Dim iRccRN As New RegContabCabeRN
        Dim iRccEN As New SuperEntidad
        iRccEN.ClaveRegContabCabe = Dgv.obtenerValorCelda(Me.DgvRcom, cam.ClaveRCC)
        iRccRN.EstornarRegistroContable(iRccEN)
    End Sub

    Sub eliminarCuentaCorriente()
        'Dim ccte As New CuentaCorrienteRN
        'Dim obj As New SuperEntidad
        'obj.ClaveCuentaCorriente = Dgv.obtenerValorCelda(Me.DgvRcom, cam.ClaveRCC)
        'ccte.eliminarCuentaCorrienteFis(obj)
        'TRAER EL OBJETO COMPRA
        Dim iComEN As New SuperEntidad
        iComEN.ClaveRegContabCabe = Dgv.obtenerValorCelda(Me.DgvRcom, cam.ClaveRCC)
        iComEN = rc.buscarRegContabExisPorClave(iComEN)

        Dim ccte As New CuentaCorrienteRN
        If ent.CodigoFile = "407" Then
            'TRAER EL DOCUMENTO APLICADO QUE SE ENCUENTRA EN LA CUENTA CORRIENTE
            'PARA DESCONTAR LO QUE SE REBAJO
            Dim iCuCoEN As New SuperEntidad
            iCuCoEN.ClaveDocumentoCuentaCorriente += iComEN.CodigoEmpresa
            iCuCoEN.ClaveDocumentoCuentaCorriente += iComEN.CodigoAuxiliar
            iCuCoEN.ClaveDocumentoCuentaCorriente += iComEN.TipoDocumento1
            iCuCoEN.ClaveDocumentoCuentaCorriente += iComEN.SerieDocumento1
            iCuCoEN.ClaveDocumentoCuentaCorriente += iComEN.NumeroDocumento1
            iCuCoEN = ccte.buscarCuentaCorrienteExisPorClaveDoc(iCuCoEN)
            'VOLVER A SU IMPORTE NORMAL 
            iCuCoEN.ImporteOriginalCuentaCorriente += iComEN.PrecioVtaRegContabCabe
            iCuCoEN.SaldoCuentaCorriente = iCuCoEN.ImporteOriginalCuentaCorriente - iCuCoEN.ImportePagadoCuentaCorriente
            'PREGUNTAR SI ESTE NUEVO IMPORTE ES IGUAL AL PAGADO ENTONCES QUIERE DECIR
            'QUE ESTE DOCUEMNTO YA SE DEBE CANCELAR EN ESTA OPERACION
            If iCuCoEN.SaldoCuentaCorriente = 0 Then
                iCuCoEN.EstadoCuentaCorriente = "0" 'CANCELADO
            Else
                iCuCoEN.EstadoCuentaCorriente = "1" 'PENDIENTE
            End If
            ccte.modificarCuentaCorriente(iCuCoEN)
        Else
            Dim obj As New SuperEntidad
            obj.ClaveCuentaCorriente = Dgv.obtenerValorCelda(Me.DgvRcom, cam.ClaveRCC)
            ccte.eliminarCuentaCorrienteFis(obj)
        End If
    End Sub

#End Region

    Private Sub btnActualizarTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarTabla.Click
        Me.ActualizarVentana()
    End Sub

    Private Sub DgvPpto_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvRcom.CellEnter
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvRcom)
        'Me.ActualizarDgvDeta()
    End Sub

    Private Sub DgvPer_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvRcom.ColumnHeaderMouseClick
        ent.CampoOrden = Me.DgvRcom.Columns(e.ColumnIndex).Name
        ent.ColumnaBusqueda = Me.DgvRcom.Columns(e.ColumnIndex).HeaderText
        Me.ActualizarVentana()
    End Sub

    Private Sub btnDesplaza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrimero.Click, btnAnterior.Click, btnSiguiente.Click, btnUltimo.Click
        Dgv.desplazamientoFila(Me.DgvRcom, CType(sender, ToolStripButton))
    End Sub

    Private Sub btnRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Me.Buscar()
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
        Me.imprimir()
    End Sub

    Private Sub btnExportar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Me.exportar()
    End Sub

    Private Sub WPersonal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.NuevaVentana()
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Me.visualizar()
    End Sub

    Private Sub DgvPpto_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvRcom.CellMouseDoubleClick
        'If e.RowIndex = -1 Then
        '    Exit Sub
        'Else
        '    Me.ImprimirUno()
        'End If
    End Sub

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        Me.Filtrar()
    End Sub

    Private Sub btnAdionarManual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdionarManual.Click
        Me.adicionarManual()
    End Sub

    Private Sub btnEstornar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEstornar.Click
        Me.Estornar()
    End Sub

    Private Sub btnCopiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopiar.Click
        Me.Copiar()
    End Sub

    Private Sub btnDetraccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetraccion.Click
        Me.DatosDetraccion()
    End Sub
End Class