Imports Entidad
Imports Negocio

Public Class WEditarRegistroCompraDua

#Region "Propietarios"
    Public wRc As New WRegistroCompra
    'Public wsc As New WSeleccionaCompra
#End Region

    Public ent, entD, parEn, ticEn As New SuperEntidad
    Public lista, listaD As New List(Of SuperEntidad)
    Public rc As New RegContabCabeRN
    Public rcd As New RegContabDetaRN
    Public ccte As New CuentaCorrienteRN
    Public par As New ParametroRN
    Public tic As New TipoCambioRN
    Public cam As New CamposEntidad
    Public tab As New TablaRN
    Public vou As New VoucherRN
    Public emp As New EmpresaRN
    Public acc As New Accion
    Public PeriodoActual As String
    Public origen As String
    Public operacion As Integer  '0=agregar , 1=modificar , 2=eliminar , 3=visualizar , 4=Manual , 5=copia'


#Region "Metodos"
    Sub InicializaVentana()
        '/Para los eventos de controles
        acc.listaCtrls = Me.ListaControles
        acc.PasaFoco()
        acc.FomatoDato()
        acc.PasarCursor()
        acc.Teclazo()
        acc.Valida()
        '/Ejecucion en ventana
        Me.Owner.Enabled = False
        '/Traer objeto parametro
        parEn = par.buscarParametroExis(parEn)
        Me.Show()
    End Sub

    Sub PorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.txtNomEmp.Text = SuperEntidad.xRazonSocial
        '/Instanciar Empresa Actual
        Dim obx As SuperEntidad
        'Dim obe As New SuperEntidad
        'obe.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        'obe = emp.buscarEmpresaExisPorCodigo(obe)
        Me.TxtPeri.Text = SuperEntidad.xPeriodoEmpresa
        PeriodoActual = SuperEntidad.xPeriodoEmpresa

        Me.TxtPorIgv.Text = parEn.IgvPar.ToString
        Me.txtCodOri.Text = "4"
        Me.txtNomOri.Text = "Compras"

        ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        ent.AnoVoucher = Me.TxtPeri.Text.Substring(0, 4)

        Me.txtCodFil.Text = Me.origen
        Select Case origen
            Case "410"
                ent.CodigoFile = "410"
                ent.DatoCondicion1 = ent.CodigoEmpresa + ent.AnoVoucher + ent.CodigoFile
                obx = vou.buscarVoucherActPorCodigo(ent)
                Me.txtNomFil.Text = obx.NombreFile
            Case "411"
                ent.CodigoFile = "411"
                ent.DatoCondicion1 = ent.CodigoEmpresa + ent.AnoVoucher + ent.CodigoFile
                obx = vou.buscarVoucherActPorCodigo(ent)
                Me.txtNomFil.Text = obx.NombreFile
            Case "412"
                ent.CodigoFile = "412"
                ent.DatoCondicion1 = ent.CodigoEmpresa + ent.AnoVoucher + ent.CodigoFile
                obx = vou.buscarVoucherActPorCodigo(ent)
                Me.txtNomFil.Text = obx.NombreFile
        End Select
        Me.TraerTipoCambio()
    End Sub

    Sub TraerTipoCambio()
        'traer tipo de cambio
        ticEn.DatoCondicion1 = Me.dtpFecha.Value.Year.ToString + "/" + Me.dtpFecha.Value.Month.ToString + "/" + Me.dtpFecha.Value.Day.ToString
        ticEn = tic.buscarTipoCambioExisPorFecha(ticEn)
        If ticEn.AnoTipoCambio = "" Then
            MsgBox("el tipo de cambio no existe", MsgBoxStyle.Information)
            Me.txtTipCam.Text = "1.000"
            Me.TxtTipCam1.Text = "1.000"
        Else
            Me.txtTipCam.Text = ticEn.VentaTipoCambio.ToString
            Me.TxtTipCam1.Text = ticEn.VentaEurTipoCambio.ToString
        End If
    End Sub

    Sub ventanaAdicionar()
        '//
        Me.InicializaVentana()
        'poner valores defecto en montos
        acc.LimpiarControles()
        'por defecto
        Me.PorDefecto()
        'titulo de la ventana
        Me.Text = "Agregar Registro " + Me.txtNomFil.Text

        Me.ImportesDebeHaber()
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtDia)
        'los controles que deben estar activos
        acc.Nuevo()
        '\\
    End Sub

    Sub ventanaAdicionarManual()
        '//
        Me.InicializaVentana()
        
        'poner valores defecto en montos
        acc.LimpiarControles()
        'por defecto
        Me.PorDefecto()
        'titulo de la ventana
        Me.Text = "Agregar Manual Registro " + Me.txtNomFil.Text
        Me.ImportesDebeHaber()
        'en blanco
        Me.TxtPeri.Text = String.Empty

        'los controles que deben estar activos
        acc.Nuevo()
        Me.TxtPeri.ReadOnly = False
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.TxtPeri)
        
        '\\
    End Sub

    Sub ventanaModificar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        
        'mostrar el registro en pantalla
        Me.obtenerRegCompraEnPantalla(codigo)
        'mostrar el detalle del registro en pantalla
        Me.obtenerRegCompraDetalleEnPantalla(codigo)

        'titulo de la ventana
        'Me.PorDefecto()
        Me.Text = "Modificar Registro " + Me.txtNomFil.Text
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtDia)
        Me.ImportesDebeHaber()
        'los controles que deben estar activos
        acc.Modificar()
        If Me.txtDoc.Text.Trim = "03" Then
            Me.txtEx.ReadOnly = True
        Else
            Me.txtEx.ReadOnly = False
        End If
        
        '\\
    End Sub

    Sub ventanaCopiar(ByRef codigo As String)
        '//
        Me.InicializaVentana()

        'mostrar el registro en pantalla
        Me.obtenerRegCompraEnPantalla(codigo)
        'mostrar el detalle del registro en pantalla
        Me.obtenerRegCompraDetalleEnPantalla(codigo)

        'limpiar el correlativo voucher
        Me.txtNumVau.Text = ""
        ent.ClaveRegContabCabe = ""

        'titulo de la ventana
        'Me.PorDefecto()
        Me.Text = "Copiar Registro " + Me.txtNomFil.Text
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtDia)
        Me.ImportesDebeHaber()

        'los controles que deben estar activos
        acc.Modificar()

        If Me.txtDoc.Text.Trim = "03" Then
            Me.txtEx.ReadOnly = True
        Else
            Me.txtEx.ReadOnly = False
        End If

        '\\
    End Sub

    Sub ventanaEliminar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Eliminar Registro " + Me.txtNomFil.Text
        'mostrar el registro en pantalla
        Me.obtenerRegCompraEnPantalla(codigo)
        'mostrar el detalle del registro en pantalla
        Me.obtenerRegCompraDetalleEnPantalla(codigo)
        Me.btnAceptar.Text = "Eliminar"
        Me.btnAceptar.Focus()
        Me.ImportesDebeHaber()
        'los controles que deben estar activos
        acc.Eliminar()
        '\\
    End Sub


    Sub ventanaVisualizar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Visualizar Registro " + Me.txtNomFil.Text
        'mostrar el registro en pantalla
        Me.obtenerRegCompraEnPantalla(codigo)
        'mostrar el detalle del registro en pantalla
        Me.obtenerRegCompraDetalleEnPantalla(codigo)
        'los controles que deben estar activos
        Me.btnAceptar.Focus()
        Me.ImportesDebeHaber()
        acc.Visualizar()
        '\\
    End Sub

    Sub obtenerRegCompraEnPantalla(ByRef codigo As String)
        '//
        ent.ClaveRegContabCabe = codigo
        ent = rc.buscarRegContabExisPorClave(ent)
        'preguntar si ent tiene el registro
        If ent.ClaveRegContabCabe = "" Then
            Exit Sub
        Else
            '/Pasar Datos a los controles
            Me.TxtCodEmp.Text = ent.CodigoEmpresa
            Me.txtNomEmp.Text = ent.RazonSocialEmpresa
            Me.TxtPeri.Text = ent.PeriodoRegContabCabe
            Me.TxtPorIgv.Text = Varios.numeroConDosDecimal(ent.IgvPar.ToString)
            Me.txtCodOri.Text = ent.CodigoOrigen
            Me.txtNomOri.Text = ent.NombreOrigen
            Me.txtCodFil.Text = ent.CodigoFile
            Me.txtNomFil.Text = ent.NombreFile
            Me.txtNumVau.Text = ent.NumeroVoucherRegContabCabe
            Me.txtDia.Text = ent.DiaVoucherRegContabCabe
            Me.txtFecVau.Text = ent.FechaVoucherRegContabCabe.Date.ToShortDateString
            Me.txtCodAux.Text = ent.CodigoAuxiliar
            Me.txtNomAux.Text = ent.DescripcionAuxiliar
            Me.txtDoc.Text = ent.TipoDocumento
            Me.txtNomDoc.Text = ent.NombreDocumento
            Me.txtSer.Text = ent.SerieDocumento
            Me.txtNum.Text = ent.NumeroDocumento
            Me.dtpFecha.Value = ent.FechaDocumento
            Me.txtTipCam.Text = ent.VentaTipoCambio.ToString
            Me.TxtTipCam1.Text = ent.VentaEurTipoCambio.ToString
            Gb.pasarDato(Me.gbMoneda, ent.MonedaDocumento)
            Me.txtPv.Text = Varios.numeroConDosDecimal(ent.PrecioVtaRegContabCabe.ToString)
            Me.txtEx.Text = Varios.numeroConDosDecimal(ent.ExoneradoRegContabCabe.ToString)
            Me.txtIgv.Text = Varios.numeroConDosDecimal(ent.IgvRegContabCabe.ToString)
            Me.txtVv.Text = Varios.numeroConDosDecimal(ent.ValorVtaRegContabCabe.ToString)
            Me.txtDistr.Text = Me.txtPv.Text
            Me.txtGlosa.Text = ent.GlosaRegContabCabe

        End If
        '\\
    End Sub

    Sub obtenerRegCompraDetalleEnPantalla(ByRef codigo As String)
        '/
        entD.ClaveRegContabCabe = codigo
        listaD = rcd.obtenerDetalleRegContabPorClave(entD)
        ' MsgBox(listaD.Count)
        'preguntamos si la lista no esta vacia
        If listaD.Count <> 0 Then
            For n As Integer = 0 To listaD.Count - 1
                Me.dgvRegCom.Rows.Add()

                Me.dgvRegCom.Rows(n).Cells(0).Value = listaD.Item(n).CodigoCuentaPcge
                Me.dgvRegCom.Rows(n).Cells(1).Value = listaD.Item(n).NombreCuentaPcge
                Me.dgvRegCom.Rows(n).Cells(2).Value = listaD.Item(n).CodigoCentroCosto
                Me.dgvRegCom.Rows(n).Cells(3).Value = listaD.Item(n).NombreCentroCosto
                Me.dgvRegCom.Rows(n).Cells(4).Value = listaD.Item(n).DebeHaberRegContabDeta
                Me.dgvRegCom.Rows(n).Cells(5).Value = Varios.numeroConDosDecimal(listaD.Item(n).ImporteSRegContabDeta.ToString)
                Me.dgvRegCom.Rows(n).Cells(6).Value = Varios.numeroConDosDecimal(listaD.Item(n).ImporteDRegContabDeta.ToString)
                Me.dgvRegCom.Rows(n).Cells(7).Value = listaD.Item(n).GlosaRegContabDeta
                ' Me.dgvRegCom.Rows(n).Cells(8).Value = listaD.Item(n).Cuenta1242
                'Me.dgvRegCom.Rows(n).Cells(9).Value = listaD.Item(n).NombreCuenta1242

            Next

        End If
    End Sub

    Sub GrabarDetalleRegContab()

        If Me.dgvRegCom.Rows.Count <> 1 Then
            For n As Integer = 0 To Me.dgvRegCom.Rows.Count - 2
                'Llenando el detalle

                entD.ClaveRegContabCabe = ent.ClaveRegContabCabe
                entD.CorrelativoRegContabDeta = (n + 1).ToString.PadLeft(4, CType("0", Char))
                entD.CodigoAuxiliar = Me.txtCodAux.Text.Trim
                entD.TipoDocumento = Me.txtDoc.Text
                entD.SerieDocumento = Me.txtSer.Text.Trim.PadLeft(4, CType("0", Char))
                entD.NumeroDocumento = Me.txtNum.Text
                entD.FechaDocumento = Me.dtpFecha.Value
                entD.VentaTipoCambio = CType(Me.txtTipCam.Text, Decimal)
                entD.CodigoCuentaPcge = Me.dgvRegCom.Item(0, n).Value.ToString
                entD.CodigoCentroCosto = Me.dgvRegCom.Item(2, n).Value.ToString
                entD.DebeHaberRegContabDeta = Me.dgvRegCom.Item(4, n).Value.ToString
                entD.ImporteSRegContabDeta = CType(Me.dgvRegCom.Item(5, n).Value.ToString, Decimal)
                entD.ImporteDRegContabDeta = CType(Me.dgvRegCom.Item(6, n).Value.ToString, Decimal)
                entD.GlosaRegContabDeta = Me.dgvRegCom.Item(7, n).Value.ToString
                'defecto
                entD.Cuenta1242 = ""
                entD.CodigoIngEgr = ""
                entD.EstadoRegContabDeta = ""
                entD.ImporteRegContabCabe = 0

                rcd.nuevoRegContabDeta(entD)
            Next
        End If
    End Sub

    Sub Aceptar()
        '//
        If Me.operacion = 1 Or Me.operacion = 2 Then
            'Volver a traer el registro 
            ent.DatoCondicion1 = ent.ClaveRegContabCabe
            ent = rc.buscarRegContabExisPorClave(ent)
        End If

        ent.PeriodoRegContabCabe = Me.TxtPeri.Text
        ent.CodigoEmpresa = Me.TxtCodEmp.Text
        ent.CodigoOrigen = Me.txtCodOri.Text
        ent.CodigoFile = Me.txtCodFil.Text
        ent.NumeroVoucherRegContabCabe = Me.txtNumVau.Text
        ent.DiaVoucherRegContabCabe = Me.txtDia.Text
        ent.FechaVoucherRegContabCabe = CType(Me.txtFecVau.Text, Date)
        ent.CodigoAuxiliar = Me.txtCodAux.Text.Trim
        ent.TipoDocumento = Me.txtDoc.Text
        ent.SerieDocumento = Me.txtSer.Text.Trim.PadLeft(4, CType("0", Char))
        ent.NumeroDocumento = Me.txtNum.Text
        ent.FechaDocumento = Me.dtpFecha.Value
        ent.VentaTipoCambio = CType(Me.txtTipCam.Text, Decimal)
        ent.VentaEurTipoCambio = CType(Me.TxtTipCam1.Text, Decimal)
        'moneda
        ent.MonedaDocumento = Rbt.radioActivo(Me.gbMoneda).Text.ToString.Trim()

        ent.PrecioVtaRegContabCabe = CType(Me.txtPv.Text, Decimal)
        ent.ExoneradoRegContabCabe = CType(Me.txtEx.Text, Decimal)
        ent.IgvRegContabCabe = CType(Me.txtIgv.Text, Decimal)
        ent.ValorVtaRegContabCabe = CType(Me.txtVv.Text, Decimal)
        ent.GlosaRegContabCabe = Me.txtGlosa.Text

        'validar fecha detraccion
        ent.DetraccionRegContabCabe = "0"
        ent.FechaDetraccionRegContabCabe = ""
        ent.NumeroPapeletaRegContabCabe = ""

        ent.ImporteSolRegContabCabe = CType(Me.txtDistr.Text, Decimal)
        ent.SumaDebeRegContabCabe = Varios.ObtieneSumaDebe(Me.dgvRegCom, ent.MonedaDocumento)
        ent.SumaHaberRegContabCabe = Varios.ObtieneSumaHaber(Me.dgvRegCom, ent.MonedaDocumento)
        ent.UltimoCorrelativo = (Me.dgvRegCom.Rows.Count - 1).ToString.PadLeft(4, CType("0", Char))

        'Segun file 407 

        ent.TipoDocumento1 = ""
        ent.SerieDocumento1 = ""
        ent.NumeroDocumento1 = ""
        ent.MonedaDocumento1 = "0"
        ent.CodigoCuentaBanco = ""

        ent.FechaDocumento1 = ""

        ent.FechaVencimiento = Today()

        'defecto para compras
        ent.ImporteRegContabCabe = 0  ''Inicio al grabar varia con otro proceso sino se graba en negocio
        ent.EstadoRegContabCabe = "1"
        ent.CodigoIngEgr = ""
        ent.CodigoModoPago = ""
        ent.RetencionRegContabCabe = ""
        ent.DescripcionRegContabCabe = ""
        ent.CartaRegContabCabe = ""
        ent.VoucherIngresoRegContabCabe = ""
        ent.Exporta = "1"
        ent.EstadoRegistro = "0"
        ent.ModoCompra = "0"

        Select Case Me.operacion

            Case 0        'Nuevo
                'Igv
                ent.IgvPar = parEn.IgvPar
                'numero voucher autogenerado
                Dim aut As New SuperEntidad
                aut.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
                aut.AnoVoucher = ent.PeriodoRegContabCabe.Substring(0, 4)
                aut.CodigoMes = ent.PeriodoRegContabCabe.Substring(4, 2)
                aut.CodigoFile = Me.txtCodFil.Text.Trim

                'MsgBox(aut.CodigoEmpresa + "  " + aut.AnoVoucher + "  " + aut.CodigoMes + "  " + aut.CodigoFile)

                ent.NumeroVoucherRegContabCabe = vou.obtenerVoucherAutogenerado(aut)
                rc.nuevoRegContabCabe(ent)

                'eliminamos el detalle 
                rcd.eliminarRegContabDeta(ent)
                Me.GrabarDetalleRegContab()

                ''Si no hay cuanta 42 en detalla no graba en CtaCte

                If Me.ObtenerCuentaParaCuentaCorriente <> "" Then
                    Me.GrabarCuentaCorriente()
                End If

                MsgBox("Registro Dua ingresado correctamente " + Chr(13) + "Numero de Voucher Generado:" + ent.NumeroVoucherRegContabCabe, MsgBoxStyle.Information)
                'Limpiar la grilla
                Me.dgvRegCom.Rows.Clear()
                acc.LimpiarControles()
                'Me.ImportesSolesDolares()
                Txt.cursorAlUltimo(Me.txtDia)

            Case 4         'Manual
                'Igv
                ent.IgvPar = parEn.IgvPar
                'numero voucher autogenerado
                Dim aut As New SuperEntidad
                aut.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
                aut.PeriodoRegContabCabe = Me.TxtPeri.Text.Trim
                aut.AnoVoucher = aut.PeriodoRegContabCabe.Substring(0, 4)
                aut.CodigoMes = aut.PeriodoRegContabCabe.Substring(4, 2)
                aut.CodigoFile = Me.txtCodFil.Text.Trim

                ent.NumeroVoucherRegContabCabe = vou.obtenerVoucherAutogenerado(aut)

                rc.nuevoRegContabCabe(ent)
                'eliminamos el detalle 
                rcd.eliminarRegContabDeta(ent)
                Me.GrabarDetalleRegContab()
                MsgBox("Registro Dua ingresado correctamente", MsgBoxStyle.Information)
                'Limpiar la grilla
                Me.dgvRegCom.Rows.Clear()
                acc.LimpiarControles()
                'Me.ImportesSolesDolares()
                Txt.cursorAlUltimo(Me.txtCodFil)

            Case 1
                If Me.EsRegistroContableModificable = False Then Exit Sub

                'modificar cabecera
                rc.modificarRegContab(ent)
                'Eliminamos el detalle antiguo
                rcd.eliminarRegContabDeta(ent)
                'grabamos el nuevo detalle
                Me.GrabarDetalleRegContab()
                '' Elimar cuenta corriente
                '' Crear nueva cuenta corriente

                MsgBox("Registro Dua modificado correctamente", MsgBoxStyle.Information)
                Me.Close()

            Case 2
                'eliminar cabecera
                rc.eliminarRegContabFis(ent)
                'Eliminamos el detalle antiguo
                rcd.eliminarRegContabDeta(ent)
                'Eliminamos cuenta corriente 
                Me.eliminarCuentaCorriente()

                MsgBox("Registro Dua Eliminado correctamente", MsgBoxStyle.Information)
                Me.Close()
            Case 5
                'Igv
                ent.IgvPar = parEn.IgvPar
                'numero voucher autogenerado
                Dim aut As New SuperEntidad
                aut.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
                aut.AnoVoucher = ent.PeriodoRegContabCabe.Substring(0, 4)
                aut.CodigoMes = ent.PeriodoRegContabCabe.Substring(4, 2)
                aut.CodigoFile = Me.txtCodFil.Text.Trim

                'MsgBox(aut.CodigoEmpresa + "  " + aut.AnoVoucher + "  " + aut.CodigoMes + "  " + aut.CodigoFile)

                ent.NumeroVoucherRegContabCabe = vou.obtenerVoucherAutogenerado(aut)
                rc.nuevoRegContabCabe(ent)

                'eliminamos el detalle 
                rcd.eliminarRegContabDeta(ent)
                Me.GrabarDetalleRegContab()

                MsgBox("Registro Dua creado correctamente", MsgBoxStyle.Information)
                Me.Close()

        End Select
        '/Actualizar y buscar el registro grabado
        Me.wRc.ActualizarVentana()
        ent.ClaveRegContabCabe = ent.CodigoEmpresa + ent.PeriodoRegContabCabe + ent.CodigoOrigen + ent.CodigoFile + ent.NumeroVoucherRegContabCabe
        Dgv.obtenerCursorActual(Me.wRc.DgvRcom, ent.ClaveRegContabCabe, Me.wRc.lista)
        '\\
    End Sub

    Sub GrabarCuentaCorriente()
        ent.PeriodoRegContabCabe = Me.TxtPeri.Text
        ent.CodigoEmpresa = Me.TxtCodEmp.Text
        ent.CodigoOrigen = Me.txtCodOri.Text
        ent.CodigoFile = Me.txtCodFil.Text
        'ent.NumeroVoucherRegContabCabe = Me.txtNumVau.Text
        ent.CodigoAuxiliar = Me.txtCodAux.Text.Trim
        ent.TipoDocumento = Me.txtDoc.Text
        ent.SerieDocumento = Me.txtSer.Text.Trim.PadLeft(4, CType("0", Char))
        ent.NumeroDocumento = Me.txtNum.Text
        ent.FechaDocumento = Me.dtpFecha.Value
        ent.VentaTipoCambio = CType(Me.txtTipCam.Text, Decimal)
        ent.VentaEurTipoCambio = CType(Me.TxtTipCam1.Text, Decimal)
        ent.CodigoCuentaPcge = Me.ObtenerCuentaParaCuentaCorriente()
        ent.FechaVctoDocumento = ""
        'moneda
        ent.MonedaDocumento = Rbt.radioActivo(Me.gbMoneda).Text.ToString.Trim()

        ent.ImporteOriginalCuentaCorriente = CType(Me.txtPv.Text, Decimal)
        ent.ImportePagadoCuentaCorriente = 0
        ent.SaldoCuentaCorriente = CType(Me.txtPv.Text, Decimal)
        ent.EstadoCuentaCorriente = "1" 'Pendiente de pago 
        ccte.nuevoCuentaCorriente(ent)

    End Sub

    Function EsDocumentoRegistrado() As Boolean
        Dim obj As New SuperEntidad
        obj.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        obj.CodigoAuxiliar = Me.txtCodAux.Text.Trim
        obj.TipoDocumento = Me.txtDoc.Text.Trim
        obj.SerieDocumento = Me.txtSer.Text.Trim
        obj.NumeroDocumento = Me.txtNum.Text.Trim
        If ccte.EsDocumentoRegistrado(obj) = True Then
            MsgBox("Documento ya esta Registrado", MsgBoxStyle.Exclamation, "Documentos")
            Me.txtNum.Focus()
            Return True
        Else
            Return False
        End If

    End Function

    Function EsDocumentoRegistradoEnOtroRegistroC() As Boolean

        Dim obj As New SuperEntidad
        obj.ClaveCuentaCorriente = ent.ClaveRegContabCabe
        obj.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        obj.CodigoAuxiliar = Me.txtCodAux.Text.Trim
        obj.TipoDocumento = Me.txtDoc.Text.Trim
        obj.SerieDocumento = Me.txtSer.Text.Trim
        obj.NumeroDocumento = Me.txtNum.Text.Trim
        If ccte.EsDocumentoRegistradoEnOtroRegistroC(obj) = True Then
            MsgBox("Documento ya esta registrado en otro registro contable", MsgBoxStyle.Exclamation, "Documentos")
            Me.txtNum.Focus()
            Return True
        Else
            Return False
        End If

    End Function


    Function EsDocumentoPagado() As Boolean

        Dim obj As New SuperEntidad
        obj.ClaveCuentaCorriente = ent.ClaveRegContabCabe
        obj = ccte.buscarCuentaCorrienteExisPorClaveCC(obj)

        If obj.ImportePagadoCuentaCorriente <> 0 Then
            MsgBox("Documento ya tiene pagos no puede modificar", MsgBoxStyle.Exclamation, "Honorarios")
            Return True
        Else
            Return False
        End If

    End Function

    Sub eliminarCuentaCorriente()
        Dim obj As New SuperEntidad
        obj.ClaveCuentaCorriente = ent.ClaveRegContabCabe
        ccte.eliminarCuentaCorrienteFis(obj)
    End Sub

    Function EsRegistroContableModificable() As Boolean
        Dim occ As New SuperEntidad
        occ.ClaveCuentaCorriente = ent.ClaveRegContabCabe
        occ = ccte.buscarCuentaCorrienteExisPorClaveCC(occ)
        If occ.ImportePagadoCuentaCorriente = 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Function ObtenerCuentaParaCuentaCorriente() As String
        Dim cta As String = ""

        If Me.dgvRegCom.Rows.Count = 1 Then Return cta

        For n As Integer = 0 To Me.dgvRegCom.RowCount - 1
            If Me.dgvRegCom.Item("DH", n).Value.ToString = "Haber" Then
                cta = Me.dgvRegCom.Item("Cuenta", n).Value.ToString
                Return cta
            End If
        Next
        Return cta
    End Function
#End Region

    Private Sub WEditarPptoInterno_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Me.Text = "Eliminar Registro Compra Dua" Then
            Me.Aceptar()
            Exit Sub
        End If

        If acc.CamposObligatorios = False Then
            Exit Sub
        Else
            If Me.operacion = 0 Or Me.operacion = 5 Then
                If Me.EsDocumentoRegistrado() = True Then Exit Sub
            Else
                If Me.EsDocumentoRegistradoEnOtroRegistroC() = True Then Exit Sub
            End If

            If Me.ValidarPreEncuadre = False Then Exit Sub

            If Me.ValidaEncuadre = True Then
                Me.Aceptar()
            Else
                Dim rpta As Integer = MsgBox("Deseas grabar el registro sin cuadrar el haber/debe", MsgBoxStyle.YesNo)
                If rpta = MsgBoxResult.Yes Then
                    Me.Aceptar()
                Else
                    Exit Sub
                End If
            End If

        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If Me.operacion = 4 Then
            Me.Close()
        Else
            Dim rpta As Integer = MsgBox("Deseas cancelar la operacion", MsgBoxStyle.YesNo)
            If rpta = MsgBoxResult.Yes Then
                Me.Close()
            Else
                Exit Sub
            End If
        End If
    End Sub

    Private Sub dtpFecha_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpFecha.Validating
        Me.TraerTipoCambio()
        Me.ImportesDebeHaber()
    End Sub

#Region "Mostrar formulario lista"
    Private Sub txtCodFil_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodFil.KeyDown
        If Me.txtCodFil.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarTabla
                win.tabla = "File"
                win.titulo = "Files"
                win.ent.DatoFiltro1 = "4"
                win.txt1 = Me.txtCodFil
                win.txt2 = Me.txtNomFil
                win.ctrlFoco = Me.txtDia
                win.NuevaVentana()
            End If
        End If

    End Sub

    Private Sub txtCodAux_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodAux.KeyDown
        If Me.txtCodAux.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarAuxiliar
                win.tabla = "Proveedor/ClienteProveedor"
                win.titulo = "AUXILIARES"
                win.txt1 = Me.txtCodAux
                win.txt2 = Me.txtNomAux
                win.ctrlFoco = Me.txtDoc
                win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub txtCodDoc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDoc.KeyDown
        If Me.txtDoc.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarTabla
                win.tabla = "Documento"
                win.titulo = "Documentos"
                win.txt1 = Me.txtDoc
                win.txt2 = Me.txtNomDoc
                win.ctrlFoco = Me.txtSer
                win.NuevaVentana()
            End If
        End If


    End Sub

    'Private Sub txtCuenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If Me.TxtCuenta.ReadOnly = False Then
    '        If e.KeyCode = Keys.F1 Then
    '            Dim win As New WListarPlanCuentaGe
    '            win.tabla = "CuentasAnaliticas4243"    ''va la condicion del case
    '            win.titulo = "Cuentas"
    '            win.txt1 = Me.TxtCuenta
    '            win.txt2 = Me.TxtNombreCuenta
    '            win.ctrlFoco = Me.btnAgregar
    '            win.NuevaVentana()
    '        End If
    '    End If
    'End Sub

#End Region

#Region "Buscar por codigo"
    Private Sub txtCodFil_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodFil.Validating
        If Me.Text = "Agregar Registro Compra" Or Me.Text = "Agregar Manual Registro Compra" Then
            If Me.txtCodFil.Text.Trim <> "" Then
                Dim codOri As String = Me.txtCodFil.Text.Trim.Substring(0, 1)
                If codOri = "4" Then
                    Dim ope As New OperaWin : ope.txt1 = Me.txtCodFil : ope.txt2 = Me.txtNomFil
                    ope.MostrarCodigoDescripcionDeTabla("Fil", "File", e)

                Else
                    MsgBox("El Codigo File no existe", MsgBoxStyle.Information)
                    Me.txtCodFil.Text = String.Empty
                    Me.txtNomFil.Text = String.Empty
                    Me.txtCodFil.Focus()
                End If
            End If
        End If

    End Sub

    Private Sub txtCodAux_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodAux.Validating
        If Me.operacion = 0 Or Me.operacion = 1 Or Me.operacion = 4 Then
            Dim ope As New OperaWin : ope.txt1 = Me.txtCodAux : ope.txt2 = Me.txtNomAux
            ope.MostrarCodigoDescripcionDeAuxiliar("Proveedor/ClienteProveedor", "AUXILIARES", e)
        End If
    End Sub

    Private Sub txtDoc_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDoc.Validating
        If Me.operacion = 0 Or Me.operacion = 1 Or Me.operacion = 4 Then
            Dim ope As New OperaWin : ope.txt1 = Me.txtDoc : ope.txt2 = Me.txtNomDoc
            ope.MostrarCodigoDescripcionDeTabla("Doc", "Documento", e)
        End If
    End Sub

    'Private Sub txtCuenta_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)

    '    Dim ope As New OperaWin : ope.txt1 = Me.TxtCuenta : ope.txt2 = Me.TxtNombreCuenta
    '    ope.Condicion = "CuentasAnaliticas42A43"
    '    ope.MostrarCodigoDescripcionDePlancuentas("CuentasAnaliticas 42 o 43", e)

    'End Sub

#End Region

#Region "Calculos"


    Private Sub txtDia_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDia.Validated
        If Me.TxtPeri.Text <> "" Then
            If Me.txtDia.Text.Trim <> "" Then
                'Dim wmes As String
                Dim periodo As String = Me.TxtPeri.Text.Trim
                Dim dia As String = Me.txtDia.Text.Trim
                If Varios.LimiteMinMaxDeValores(dia, 1, 31) = True Then
                    dia = Varios.FormatoDia(dia)
                    Me.txtDia.Text = dia
                    Me.txtFecVau.Text = dia + "/" + periodo.Substring(4, 2) + "/" + periodo.Substring(0, 4)

                    '' Es Fecha Valida
                    If Varios.ValidaDia(Me.txtFecVau.Text) = False Then
                        Me.txtFecVau.Text = String.Empty
                        Me.txtDia.Focus()
                    End If
                Else
                    MsgBox("El dia debe estar entre en 1 y 31", MsgBoxStyle.Information)
                    Me.txtDia.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub txtDoc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDoc.Validated

        'If Me.txtDoc.Text.Trim = "03" Then
        '    Me.txtEx.ReadOnly = True
        '    Me.txtEx.Text = Me.txtPv.Text.Trim
        'Else
        '    Me.txtEx.ReadOnly = False
        '    Me.txtEx.Text = "0.00"
        'End If

        Dim vIgv As Decimal = 0
        If Me.operacion = 0 Or Me.operacion = 4 Then
            vIgv = parEn.IgvPar
        Else
            vIgv = ent.IgvPar
        End If
        'Me.txtIgv.Text = Varios.CalcularIgvCompras(Me.txtPv.Text, Me.txtEx.Text, vIgv)
        'Me.txtVv.Text = Varios.CalcularValorVentaCompra(Me.txtPv.Text, Me.txtEx.Text, Me.txtIgv.Text)

        Me.txtEx.Text = Varios.numeroConDosDecimal(Me.txtEx.Text)
        Me.txtIgv.Text = Varios.numeroConDosDecimal(Me.txtIgv.Text)
        Me.txtVv.Text = Varios.numeroConDosDecimal(Me.txtVv.Text)

        'calculo distribuir
        Me.txtDistr.Text = Varios.numeroConDosDecimal((CType(Me.txtVv.Text.Trim, Decimal) + CType(Me.txtIgv.Text.Trim, Decimal) + CType(Me.txtEx.Text.Trim, Decimal)).ToString)

        Me.ImportesDebeHaber()
    End Sub

    'Private Sub txtPv_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPv.Validated

    '    If Me.txtDoc.Text.Trim = "03" Then
    '        Me.txtEx.Text = Me.txtPv.Text.Trim
    '    End If
    '    Dim vIgv As Decimal = 0
    '    If Me.Text = "Agregar Registro Compra" Or Me.Text = "Agregar Manual Registro Compra" Then
    '        vIgv = parEn.IgvPar
    '    Else
    '        vIgv = ent.IgvPar
    '    End If
    '    Me.txtIgv.Text = Varios.CalcularIgvCompras(Me.txtPv.Text, Me.txtEx.Text, vIgv)
    '    Me.txtVv.Text = Varios.CalcularValorVentaCompra(Me.txtPv.Text, Me.txtEx.Text, Me.txtIgv.Text)
    '    'calculo distribuir
    '    Me.txtDistr.Text = Varios.numeroConDosDecimal((CType(Me.txtVv.Text.Trim, Decimal) + CType(Me.txtEx.Text.Trim, Decimal)).ToString)
    '    Me.ImportesSolesDolares()
    'End Sub


    Private Sub txtEx_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEx.Validated, txtVv.Validated, txtIgv.Validated
        Dim vIgv As Decimal = 0
        If Me.operacion = 0 Or Me.operacion = 4 Then
            vIgv = parEn.IgvPar
        Else
            vIgv = ent.IgvPar
        End If
        Me.txtEx.Text = Varios.numeroConDosDecimal(Me.txtEx.Text)
        Me.txtVv.Text = Varios.numeroConDosDecimal(Me.txtVv.Text)
        Me.txtIgv.Text = Varios.numeroConDosDecimal(Me.txtIgv.Text)
        'calculo distribuir
        'Me.txtDistr.Text = Varios.numeroConDosDecimal((CType(Me.txtVv.Text.Trim, Decimal) + CType(Me.txtEx.Text.Trim, Decimal)).ToString)
        Me.CalcularPrecioVenta()
        Me.ImportesSoles()
        'Me.ImportesDebeHaber()
    End Sub

    'Private Sub txtser_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSer.Validated, txtCodAux.Validated, txtDoc.Validated, txtNum.Validated
    '    Me.EsDocumentoRegistrado()
    'End Sub

#End Region

#Region "Para Items"
    Sub NuevoItem()
        Dim win1 As New WDetalleRegComprasDua
        'win1.concepto = Me.concepto
        'win1.titulo = Me.titulo
        win1.wRegCom = Me
        Me.AddOwnedForm(win1)
        win1.NuevaVentana()
    End Sub

    Sub ModificarItem()
        Dim win1 As New WDetalleRegComprasDua
        ' win1.concepto = Me.concepto
        ' win1.titulo = Me.titulo
        win1.wRegCom = Me
        Me.AddOwnedForm(win1)
        win1.ModificarVentana()
    End Sub

    Sub EliminarItem()
        Dim win1 As New WDetalleRegComprasDua
        'win1.concepto = Me.concepto
        'win1.titulo = Me.titulo
        win1.wRegCom = Me
        Me.AddOwnedForm(win1)
        win1.EliminaVentana()

    End Sub

    Sub CalcularPrecioVenta()
        Me.txtPv.Text = Varios.numeroConDosDecimal((CType(Me.txtEx.Text.Trim, Decimal) + CType(Me.txtVv.Text.Trim, Decimal) + CType(Me.txtIgv.Text.Trim, Decimal)).ToString)
    End Sub

    Sub ImportesDebeHaber()
        'indice debe/haber 4
        'indice importe soles 5
        'indice importe dolares 6
        Me.txtHaberS.Text = "0.00"
        Me.txtDebeS.Text = "0.00"
        Me.txtHaberD.Text = "0.00"
        Me.txtDebeD.Text = "0.00"
        Dim numreg As Integer = Me.dgvRegCom.Rows.Count - 2
        Dim deha As String
        Dim impS, impD As Decimal
        For n As Integer = 0 To numreg
            deha = Me.dgvRegCom.Item(4, n).Value.ToString
            impS = CType(Me.dgvRegCom.Item(5, n).Value.ToString, Decimal)
            impD = CType(Me.dgvRegCom.Item(6, n).Value.ToString, Decimal)
            Select Case deha
                Case "Haber"
                    Me.txtHaberS.Text = (CType(Me.txtHaberS.Text, Decimal) + impS).ToString
                    Me.txtHaberD.Text = (CType(Me.txtHaberD.Text, Decimal) + impD).ToString
                Case "Debe"
                    Me.txtDebeS.Text = (CType(Me.txtDebeS.Text, Decimal) + impS).ToString
                    Me.txtDebeD.Text = (CType(Me.txtDebeD.Text, Decimal) + impD).ToString

            End Select
        Next

    End Sub

    Public Function sumaImportes() As Decimal
        Dim sumImp As Decimal = 0
        If Me.dgvRegCom.RowCount = 1 Then
            Return sumImp
        Else

            For n As Integer = 0 To Me.dgvRegCom.RowCount - 2
                Dim valor As String = Me.dgvRegCom.Item(5, n).Value.ToString
                sumImp = sumImp + CType(valor, Decimal)
            Next
            Return sumImp
        End If

    End Function

    Sub ImportesSoles()
        If Me.txtEx.Text <> "" Then
            'Cambiar txtVv por txtDistr

            Dim str As String = Rbt.radioActivo(Me.gbMoneda).Text.ToString.Trim()
            Select Case str
                Case "US$"
                    Me.txtDistr.Text = Varios.numeroConDosDecimal((CType(Me.txtPv.Text, Decimal) * CType(Me.txtTipCam.Text, Decimal)).ToString)
                Case "S/."
                    Me.txtDistr.Text = Me.txtPv.Text
                Case "EUR"
                    Me.txtDistr.Text = Varios.numeroConDosDecimal((CType(Me.txtPv.Text, Decimal) * CType(Me.TxtTipCam1.Text, Decimal)).ToString)
            End Select
        End If

    End Sub


    Function ValidarPreEncuadre() As Boolean
        Dim impsol As Decimal = CType(Me.txtDistr.Text, Decimal)
        Dim debsol As Decimal = CType(Me.txtDebeS.Text, Decimal)
        Dim habsol As Decimal = CType(Me.txtHaberS.Text, Decimal)

        If impsol = debsol And impsol = habsol And debsol = habsol Then
            Return True
        End If

        If impsol < debsol Or impsol < habsol Then
            MsgBox("Importe Soles debe ser mayor o igual" + Chr(13) + "que el importe debe y haber", MsgBoxStyle.Exclamation, "Dua")
            Return False
        Else
            Return True
        End If

    End Function

    Function ValidaEncuadre() As Boolean
        Dim debsol As Decimal = CType(Me.txtDebeS.Text, Decimal)
        Dim habsol As Decimal = CType(Me.txtHaberS.Text, Decimal)
        If debsol = habsol Then
            Return True
        Else
            Return False
        End If
    End Function

#End Region

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim numReg As Integer = Me.dgvRegCom.Rows.Count
        If numReg = 0 Or numReg = 1 Then
            Exit Sub
        Else
            Dim indFil As Integer = Me.dgvRegCom.CurrentRow.Index
            If indFil = numReg - 1 Then
                Exit Sub
            Else
                Me.EliminarItem()
            End If
        End If
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click

        Me.NuevoItem()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Dim numReg As Integer = Me.dgvRegCom.Rows.Count
        If numReg = 0 Or numReg = 1 Then
            Exit Sub
        Else
            Dim indFil As Integer = Me.dgvRegCom.CurrentRow.Index
            If indFil = numReg - 1 Then
                Exit Sub
            Else
                Me.ModificarItem()
            End If
        End If
    End Sub

    Private Sub rbtSol_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles rbtSol.Validating, rbtDol.Validating, RbtEur.Validating
        Me.ImportesSoles()
        Me.ImportesDebeHaber()
    End Sub

    Private Sub txtPeri_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPeri.Validated
        If Me.operacion = 4 Then
            Dim p As String = Me.TxtPeri.Text.Trim
            If p <> "" Then
                If p.Length <> 6 Then
                    MsgBox("No es un periodo valido", MsgBoxStyle.Information, "")
                    Me.TxtPeri.Text = ""
                    Me.TxtPeri.Focus()
                Else
                    If p >= PeriodoActual Then
                        MsgBox("Solo se puede digitar como maximo el periodo anterior de hoy", MsgBoxStyle.Information, "")
                        Me.TxtPeri.Text = ""
                        Me.TxtPeri.Focus()
                    Else
                        Dim dia As String = Me.txtDia.Text.Trim
                        If dia <> String.Empty Then
                            dia = Varios.FormatoDia(dia)
                            Me.txtFecVau.Text = dia + "/" + Me.TxtPeri.Text.Substring(4, 2) + "/" + Me.TxtPeri.Text.Substring(0, 4)
                            '' Es Fecha Valida
                            If Varios.ValidaDia(Me.txtFecVau.Text) = False Then
                                Me.txtFecVau.Text = String.Empty
                                Me.TxtPeri.Focus()
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub txtSer_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSer.Validated, txtCodAux.Validated, txtNum.Validated
        If Me.operacion = 0 Or Me.operacion = 5 Then
            If Me.EsDocumentoRegistrado() = True Then Exit Sub
        Else
            If Me.EsDocumentoRegistradoEnOtroRegistroC() = True Then Exit Sub
        End If

    End Sub

End Class