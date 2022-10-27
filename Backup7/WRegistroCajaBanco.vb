Option Strict Off
Imports Entidad
Imports Negocio

Public Class WRegistroCajaBanco

    Public per As New PermisoRN
    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public cbco As New RegContabCabeRN
    Public cam As New CamposEntidad
    Public ent, entpar As New SuperEntidad
    Public titulo As String = "CajaBanco"
    Public par As New ParametroRN
    Public periodo As String
    Public ifil As Integer



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
        Dim nReg As Integer = Me.DgvCbco.Rows.Count
        Dim lisPer As New List(Of SuperEntidad)
        Dim oPer As New SuperEntidad
        oPer.CodigoUsuario = SuperEntidad.xCodigoUsuario
        oPer.CodigoVentana = "018"
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
        Dgv.actualizarBarraEstado(Me.sst1, Me.DgvCbco)
        acc.EstadoBotonesPorGrilla(Me.ListaBotones, Me.DgvCbco)
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvCbco)
        Dgv.pintarColumnaDgv(Me.DgvCbco, ent.CampoOrden)
        Me.permisoVentana()
        '\\
    End Sub

    Sub ActualizarDgvTab()
        '//

        ifil = Dgv.ObtenerIndiceFila(Me.DgvCbco)

        '/Refrescando el DataSource de DgvUsu
        ent.PeriodoRegContabCabe = periodo
        ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        ent.EstadoRegContabCabe = "2" 'ESTOS REGISTROS FUERON CREADOS POR AQUI
        'ent.CampoOrden = ent.ClaveRegContabCabe
        lista = cbco.ListarIngresosyEgresosXPeriodoYEmpresaYEstado(ent)

        '/Refrescando el DataSource de DgvUsu
        Dgv.refrescarFuenteDatosGrilla(Me.DgvCbco, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvCbco, cam.ClaveRCC, "Clave", 140)
        Dgv.asignarColumnaText(Me.DgvCbco, cam.CodOriRC, "Origen", 60)
        Dgv.asignarColumnaText(Me.DgvCbco, cam.NomOriRC, "Nombre", 100)
        Dgv.asignarColumnaText(Me.DgvCbco, cam.CodFilRC, "Origen", 60)
        Dgv.asignarColumnaText(Me.DgvCbco, cam.NomFilRC, "File", 192)
        Dgv.asignarColumnaText(Me.DgvCbco, cam.NumVouRCC, "Numero Voucher", 120)
        Dgv.asignarColumnaText(Me.DgvCbco, cam.FecVouRCC, "Fecha Voucher", 125)
        Dgv.AsignarColumnaTextNumerico(Me.DgvCbco, cam.ImpRCC, "Monto", 100, 2)
        Dgv.asignarColumnaText(Me.DgvCbco, cam.CodCtaBco, "Cuenta", 85)
        Dgv.asignarColumnaText(Me.DgvCbco, cam.BcoCtaBco, "Banco", 300)
        Dgv.asignarColumnaText(Me.DgvCbco, cam.AgeCtaBco, "Agencia", 200)
        Dgv.asignarColumnaText(Me.DgvCbco, cam.NumCtaBco, "Numero", 80)
        Dgv.asignarColumnaText(Me.DgvCbco, cam.MonCtaBco, "Moneda", 80)
        '//
    End Sub

    Sub buscar()
        '//
        Dim win As New WBuscar
        win.wCbco = Me
        win.titulo = Me.titulo
        Me.AddOwnedForm(win)
        win.ventanaBuscar(ent.ColumnaBusqueda)
        '\\
    End Sub

    Sub Filtrar()
        Dim win As New WFitrarPeriodo
        win.wRgCajaBanco = Me
        win.TipoRg = "CajaBanco"
        Me.AddOwnedForm(win)
        win.nuevo()
    End Sub


    Sub adicionar()
        '//
        Dim win As New WEditarRegistroCajaBanco
        win.wRcb = Me
        win.operacion = 0
        Me.AddOwnedForm(win)
        win.ventanaAdicionar()
        '\\
    End Sub

    Sub adicionarManual()
        '//
        Dim win As New WEditarRegistroCajaBanco
        win.wRcb = Me
        win.operacion = 4
        Me.AddOwnedForm(win)
        win.ventanaAdicionarManual()
        '\\
    End Sub

    Sub modificar()

        'si el registro esta estornado o es un estorno entonces no se puede modificar
        If Me.EsActoEstornarRegistro = False Then Exit Sub

        '//
        Dim win As New WEditarRegistroCajaBanco
        win.wRcb = Me
        win.operacion = 1
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvCbco, cam.ClaveRCC)
        win.ventanaModificar(cod)
        '\\
    End Sub

    Sub Copiar()
        '//
        Dim win As New WEditarRegistroCajaBanco
        win.wRcb = Me
        win.operacion = 5
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvCbco, cam.ClaveRCC)
        win.ventanaCopiar(cod)
        '\\
    End Sub

    Sub eliminar()
        'si el registro esta estornado o es un estorno entonces no se puede modificar
        If Me.EsActoEstornarRegistro = False Then Exit Sub

        '//
        Dim win As New WEditarRegistroCajaBanco
        win.wRcb = Me
        win.operacion = 2
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvCbco, cam.ClaveRCC)
        win.ventanaEliminar(cod)
        '\\
    End Sub

    Sub Visualizar()
        '//
        Dim win As New WEditarRegistroCajaBanco
        win.wRcb = Me
        win.operacion = 3
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvCbco, cam.ClaveRCC)
        win.ventanaVisualizar(cod)
        '\\
    End Sub

    Function EsActoEstornarRegistro() As Boolean
        Dim iRccRN As New RegContabCabeRN
        Dim iRccEN As New SuperEntidad
        iRccEN.ClaveRegContabCabe = Dgv.obtenerValorCelda(Me.DgvCbco, cam.ClaveRCC)
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

        'sacar la cuenta corriente
        Me.modificarCuentaCorriente()

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
        iRccEN.ClaveRegContabCabe = Dgv.obtenerValorCelda(Me.DgvCbco, cam.ClaveRCC)
        iRccRN.EstornarRegistroContable(iRccEN)
    End Sub


    Sub modificarCuentaCorriente()
        Dim lisRcd As New List(Of SuperEntidad)
        Dim regDet, cueCorr As New SuperEntidad
        Dim rcbd As New RegContabDetaRN
        Dim ccte As New CuentaCorrienteRN

        'OBTENER LA CLAVE
        regDet.ClaveRegContabCabe = Dgv.obtenerValorCelda(Me.DgvCbco, cam.ClaveRCC)

        'LISTAR EL DETALLE DE ESTE REGISTRO
        lisRcd = rcbd.obtenerDetalleRegContabPorClave(regDet)
        For n As Integer = 0 To lisRcd.Count - 1
            regDet = lisRcd.Item(n)
            cueCorr.ClaveDocumentoCuentaCorriente = regDet.CodigoEmpresa + regDet.CodigoAuxiliar + regDet.TipoDocumento + regDet.SerieDocumento + regDet.NumeroDocumento
            cueCorr = ccte.buscarCuentaCorrienteExisPorClaveDoc(cueCorr)
            If cueCorr.ClaveDocumentoCuentaCorriente <> "" Then
                Select Case cueCorr.MonedaDocumento
                    Case "S/."
                        cueCorr.ImportePagadoCuentaCorriente = cueCorr.ImportePagadoCuentaCorriente - regDet.ImporteSRegContabDeta
                        cueCorr.SaldoCuentaCorriente = cueCorr.SaldoCuentaCorriente + regDet.ImporteSRegContabDeta
                    Case "US$"
                        cueCorr.ImportePagadoCuentaCorriente = cueCorr.ImportePagadoCuentaCorriente - regDet.ImporteDRegContabDeta
                        cueCorr.SaldoCuentaCorriente = cueCorr.SaldoCuentaCorriente + regDet.ImporteDRegContabDeta
                    Case "EUR"
                        cueCorr.ImportePagadoCuentaCorriente = cueCorr.ImportePagadoCuentaCorriente - regDet.ImporteERegContabDeta
                        cueCorr.SaldoCuentaCorriente = cueCorr.SaldoCuentaCorriente + regDet.ImporteERegContabDeta
                End Select
                cueCorr.EstadoCuentaCorriente = "1"
                ccte.modificarCuentaCorriente(cueCorr)
            End If
        Next
    End Sub

    Sub Imprimir()
        '/
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvCbco, cam.ClaveRCC)
        Dim ob As New SuperEntidad
        ob.ClaveRegContabCabe = cod
        ob = cbco.buscarRegContabExisPorClave(ob)
        If ob.CodigoOrigen = "2" Then
            Me.wImpVoucher1()
        Else
            Me.wImpVoucher()
        End If

    End Sub

    Sub wImpVoucher()
        '/
        Dim win As New WImpVoucher
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvCbco, cam.ClaveRCC)
        Dim ob As New SuperEntidad
        ob.ClaveRegContabCabe = cod
        win.ent = cbco.buscarRegContabExisPorClave(ob)

        win.NuevaVentanaDesdeVoucher()
    End Sub

    Sub wImpVoucher1()
        '/
        Dim win As New WImpVoucher1
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvCbco, cam.ClaveRCC)
        Dim ob As New SuperEntidad
        ob.ClaveRegContabCabe = cod
        win.ent = cbco.buscarRegContabExisPorClave(ob)
        win.NuevaVentanaDesdeVoucher()
    End Sub


    'Sub imprimir()
    '    '//
    '    Dim imp As New WImpTabla
    '    imp.wTab = Me
    '    Me.AddOwnedForm(imp)
    '    imp.nuevaVentana()
    '    '\\

    'End Sub


    'Sub recycla()
    '    Dim win As New WComprobanterecycla
    '    win.wCom = Me
    '    Me.AddOwnedForm(win)
    '    win.NuevaVentana()
    'End Sub

#End Region

    Private Sub btnActualizarTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarTabla.Click
        Me.ActualizarVentana()
    End Sub

    Private Sub DgvDis_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvCbco.ColumnHeaderMouseClick
        ent.CampoOrden = Me.DgvCbco.Columns(e.ColumnIndex).Name
        ent.ColumnaBusqueda = Me.DgvCbco.Columns(e.ColumnIndex).HeaderText
        Me.ActualizarVentana()
    End Sub

    Private Sub btnDesplaza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrimero.Click, btnAnterior.Click, btnSiguiente.Click, btnUltimo.Click
        Dgv.desplazamientoFila(Me.DgvCbco, CType(sender, ToolStripButton))
    End Sub

    Private Sub btnRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Me.buscar()
    End Sub

    Private Sub btnAdicionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdicionar.Click
        Me.adicionar()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Me.modificar()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Me.eliminar()
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        '  Me.imprimir()
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Me.Visualizar()
    End Sub

    Private Sub btnRecycla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecycla.Click
        '       Me.recycla()
    End Sub

    Private Sub btnAdionarManual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdionarManual.Click
        Me.adicionarManual()
    End Sub

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        Me.Filtrar()
    End Sub

    

    Private Sub btnEstornar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEstornar.Click
        Me.Estornar()
    End Sub

    Private Sub btnCopiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopiar.Click
        Me.Copiar()
    End Sub

    Private Sub btnVoucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoucher.Click
        Me.Imprimir()
    End Sub
End Class