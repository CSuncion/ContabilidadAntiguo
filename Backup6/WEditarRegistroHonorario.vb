Imports Entidad
Imports Negocio


Public Class WEditarRegistroHonorario
#Region "Propietarios"
    Public wRh As New WRegistroHonorario
#End Region

    Public ent, entD, parEn, ticEn, iDsc As New SuperEntidad
    Public lista, listaD As New List(Of SuperEntidad)
    Public rh As New RegContabCabeRN
    Public rhd As New RegContabDetaRN
    Public ccte As New CuentaCorrienteRN
    Public par As New ParametroRN
    Public tic As New TipoCambioRN
    Public cam As New CamposEntidad
    Public tab As New TablaRN
    Public vou As New VoucherRN
    Public emp As New EmpresaRN
    Public acc As New Accion
    Public PeriodoActual As String
    'Public wcuenta As String
    Public operacion As Integer  '0=agregar , 1=modificar , 2=eliminar , 3=visualizar , 4=Manual'
  
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
        'traer objeto parametro
        parEn = par.buscarParametroExis(parEn)
        Me.Show()
    End Sub

    Sub PorDefecto()
        '/
        'prh = parEn.PorRetencionHonorario
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.TxtNomEmp.Text = SuperEntidad.xRazonSocial
        'Me.txtPeri.Text = SuperEntidad.xPeriodoEmpresa
        ''Instanciar Empresa Actual
        Dim obx As New SuperEntidad
        'Dim obe As New SuperEntidad
        'obe.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        'obe = emp.buscarEmpresaExisPorCodigo(obe)
        Me.txtPeri.Text = SuperEntidad.xPeriodoEmpresa
        PeriodoActual = SuperEntidad.xPeriodoEmpresa

        ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        ent.AnoVoucher = Me.txtPeri.Text.Substring(0, 4)

        Me.txtCodOri.Text = "6"
        ent.TipoTabla = "Ori"
        ent.CodigoOrigen = Me.txtCodOri.Text

        ent.DatoCondicion1 = ent.TipoTabla
        ent.DatoCondicion2 = ent.CodigoOrigen
        obx = tab.buscarItemTablaExisActPorTipoTablaYCodigo(ent)
        Me.txtNomOri.Text = obx.NombreItemTabla

        Me.txtCodFil.Text = "601"
        ent.CodigoFile = "601"
        ent.DatoCondicion1 = ent.CodigoEmpresa + ent.AnoVoucher + ent.CodigoFile
        obx = vou.buscarVoucherActPorCodigo(ent)
        Me.txtNomFil.Text = obx.NombreFile

        Me.txtDoc.Text = "02"
        ent.TipoTabla = "Doc"
        ent.TipoDocumento = Me.txtDoc.Text
        ent.DatoCondicion1 = ent.TipoTabla
        ent.DatoCondicion2 = ent.TipoDocumento
        obx = tab.buscarItemTablaExisActPorTipoTablaYCodigo(ent)
        Me.txtNomDoc.Text = obx.NombreItemTabla
        Me.TraerTipoCambio()
        '/
    End Sub

    Sub TraerTipoCambio()
        '/
        ticEn.DatoCondicion1 = Me.dtpFecha.Value.Year.ToString + "/" + Me.dtpFecha.Value.Month.ToString + "/" + Me.dtpFecha.Value.Day.ToString
        ticEn = tic.buscarTipoCambioExisPorFecha(ticEn)
        If ticEn.AnoTipoCambio = "" Then
            MsgBox("el tipo de cambio no existe", MsgBoxStyle.Information)
            Me.txtTipCam.Text = "1.000"
            Me.txtTipCam1.Text = "1.000"
        Else
            Me.txtTipCam.Text = ticEn.VentaTipoCambio.ToString
            Me.txtTipCam1.Text = ticEn.VentaEurTipoCambio.ToString
        End If
        '/
    End Sub

    Sub ventanaAdicionar()
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Agregar Registro Honorario"
        'poner valores defecto en montos
        acc.LimpiarControles()
        'por defecto
        Me.PorDefecto()
        Me.ImportesSolesDolares()
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtDia)
        'los controles que deben estar activos
        acc.Nuevo()
        '\\
    End Sub

    Sub ventanaAdicionarManual()
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Agregar Manual Registro Honorario"
        'poner valores defecto en montos
        acc.LimpiarControles()
        'por defecto
        Me.PorDefecto()
        'en blanco
        Me.txtPeri.Text = String.Empty
        Me.ImportesSolesDolares()
        'los controles que deben estar activos
        acc.Nuevo()
        Me.txtPeri.ReadOnly = False
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtPeri)
        '\\
    End Sub

    Sub ventanaModificar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Modificar Registro Honorario"
        'mostrar el registro en pantalla
        Me.obtenerRegHonorarioEnPantalla(codigo)
        'mostrar el detalle del registro en pantalla
        Me.obtenerRegHonorarioDetalleEnPantalla(codigo)
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtDia)
        Me.ImportesSolesDolares()
        'los controles que deben estar activos
        acc.Modificar()
        '\\
    End Sub

    Sub ventanaCopiar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Copiar Registro Honorario"
        'mostrar el registro en pantalla
        Me.obtenerRegHonorarioEnPantalla(codigo)
        'mostrar el detalle del registro en pantalla
        Me.obtenerRegHonorarioDetalleEnPantalla(codigo)
        'limpiar el correlativo voucher
        Me.txtNumVau.Text = ""
        ent.ClaveRegContabCabe = ""
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtDia)
        Me.ImportesSolesDolares()
        'los controles que deben estar activos
        acc.Modificar()
        '\\
    End Sub

    Sub ventanaEliminar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Eliminar Registro Honorario"
        'mostrar el registro en pantalla
        Me.obtenerRegHonorarioEnPantalla(codigo)
        'mostrar el detalle del registro en pantalla
        Me.obtenerRegHonorarioDetalleEnPantalla(codigo)
        Me.btnAceptar.Text = "Eliminar"
        Me.btnAceptar.Focus()
        Me.ImportesSolesDolares()
        'los controles que deben estar activos
        acc.Eliminar()
        '\\
    End Sub

    Sub ventanaVisualizar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Visualizar Registro Honorario"
        'mostrar el registro en pantalla
        Me.obtenerRegHonorarioEnPantalla(codigo)
        'mostrar el detalle del registro en pantalla
        Me.obtenerRegHonorarioDetalleEnPantalla(codigo)
        'los controles que deben estar activos
        Me.ImportesSolesDolares()
        acc.Visualizar()
        '\\
    End Sub

    Sub obtenerRegHonorarioEnPantalla(ByRef codigo As String)
        '//
        ent.ClaveRegContabCabe = codigo
        ent = rh.buscarRegContabExisPorClave(ent)
        'preguntar si ent tiene el registro
        If ent.ClaveRegContabCabe = "" Then
            Exit Sub
        Else
            '/Pasar Datos a los controles
            Me.TxtCodEmp.Text = ent.CodigoEmpresa
            Me.TxtNomEmp.Text = ent.RazonSocialEmpresa
            Me.txtPeri.Text = ent.PeriodoRegContabCabe
            Me.txtCodOri.Text = ent.CodigoOrigen
            Me.txtNomOri.Text = ent.NombreOrigen
            Me.txtCodFil.Text = ent.CodigoFile
            Me.txtNomFil.Text = ent.NombreFile
            Me.txtNumVau.Text = ent.NumeroVoucherRegContabCabe
            Me.txtDia.Text = ent.DiaVoucherRegContabCabe
            Me.txtFecVau.Text = ent.FechaVoucherRegContabCabe.Date.ToShortDateString
            Me.txtCodAux.Text = ent.CodigoAuxiliar
            Me.txtNomAux.Text = ent.DescripcionAuxiliar
            Me.txtAsigFecAux.Text = ent.FechaInscripcionSnpAuxiliar
            Me.txtDoc.Text = ent.TipoDocumento
            Me.txtNomDoc.Text = ent.NombreDocumento
            Me.txtSer.Text = ent.SerieDocumento
            Me.txtNum.Text = ent.NumeroDocumento
            Me.dtpFecha.Value = ent.FechaDocumento
            Me.txtTipCam.Text = ent.VentaTipoCambio.ToString
            Me.txtTipCam1.Text = ent.VentaEurTipoCambio.ToString
            Gb.pasarDato(Me.gbMoneda, ent.MonedaDocumento)
            Gb.pasarDato(Me.gbDscto, ent.FlagDescuentoRegContabCabe)
            Me.TxtCodAfp.Text = ent.CodigoAfp
            Me.TxtNomAfp.Text = ent.NombreAfp
            Me.TxtDescuento.Text = Varios.numeroConDosDecimal(ent.ImporteDescuentoRegContabCabe.ToString)
            Gb.pasarDato(Me.gbRete, ent.RetencionRegContabCabe)
            Me.txtPv.Text = Varios.numeroConDosDecimal(ent.PrecioVtaRegContabCabe.ToString)
            Me.txtVv.Text = Varios.numeroConDosDecimal(ent.ValorVtaRegContabCabe.ToString)
            Me.txtGlosa.Text = ent.GlosaRegContabCabe
            Me.DtpFechaVcto.Value = ent.FechaVencimiento
            iDsc.DescuentoFondo = ent.DescuentoFondo
            iDsc.DescuentoRemu = ent.DescuentoRemu
            iDsc.DescuentoSalud = ent.DescuentoSalud
        End If
        '\\
    End Sub

    Sub obtenerRegHonorarioDetalleEnPantalla(ByRef codigo As String)
        '/
        entD.ClaveRegContabCabe = codigo
        entD.EstadoRegContabDeta = "0"

        If Me.operacion = 1 Or Me.operacion = 5 Then
            listaD = rhd.obtenerDetalleRegContabXClaveYEstado(entD)
        Else
            entD.CampoOrden = cam.ClaveRCD
            listaD = rhd.obtenerDetalleRegContabXClaveCabe(entD)
        End If

        ' MsgBox(listaD.Count)
        'preguntamos si la lista no esta vacia
        If listaD.Count <> 0 Then
            For n As Integer = 0 To listaD.Count - 1
                Me.dgvRegHon.Rows.Add()
                Me.dgvRegHon.Rows(n).Cells(0).Value = listaD.Item(n).CodigoCuentaPcge
                Me.dgvRegHon.Rows(n).Cells(1).Value = listaD.Item(n).NombreCuentaPcge
                Me.dgvRegHon.Rows(n).Cells(2).Value = listaD.Item(n).CodigoCentroCosto
                Me.dgvRegHon.Rows(n).Cells(3).Value = listaD.Item(n).NombreCentroCosto
                Me.dgvRegHon.Rows(n).Cells(4).Value = listaD.Item(n).DebeHaberRegContabDeta
                Me.dgvRegHon.Rows(n).Cells(5).Value = Varios.numeroConDosDecimal(listaD.Item(n).ImporteSRegContabDeta.ToString)
                Me.dgvRegHon.Rows(n).Cells(6).Value = Varios.numeroConDosDecimal(listaD.Item(n).ImporteDRegContabDeta.ToString)
                Me.dgvRegHon.Rows(n).Cells(7).Value = listaD.Item(n).CodigoIngEgr
                Me.dgvRegHon.Rows(n).Cells(8).Value = listaD.Item(n).NombreIngEgr
                Me.dgvRegHon.Rows(n).Cells(9).Value = listaD.Item(n).GlosaRegContabDeta
                Me.dgvRegHon.Rows(n).Cells(10).Value = listaD.Item(n).CodigoArea
                Me.dgvRegHon.Rows(n).Cells(11).Value = listaD.Item(n).NombreArea
                Me.dgvRegHon.Rows(n).Cells(12).Value = listaD.Item(n).CodigoGastoReparable
                Me.dgvRegHon.Rows(n).Cells(13).Value = listaD.Item(n).NombreGastoReparable

            Next

        End If
    End Sub

    Sub GrabarDetalleRegContab()

        If Me.dgvRegHon.Rows.Count <> 1 Then
            For n As Integer = 0 To Me.dgvRegHon.Rows.Count - 2
                'Llenando el detalle

                entD.ClaveRegContabCabe = ent.ClaveRegContabCabe
                entD.CorrelativoRegContabDeta = (n + 1).ToString.PadLeft(4, CType("0", Char))
                entD.CodigoAuxiliar = Me.txtCodAux.Text.Trim
                entD.TipoDocumento = Me.txtDoc.Text
                entD.SerieDocumento = Me.txtSer.Text
                entD.NumeroDocumento = Me.txtNum.Text
                entD.FechaDocumento = Me.dtpFecha.Value
                entD.VentaTipoCambio = CType(Me.txtTipCam.Text, Decimal)
                entD.CodigoCuentaPcge = Me.dgvRegHon.Item(0, n).Value.ToString
                entD.CodigoCentroCosto = Me.dgvRegHon.Item(2, n).Value.ToString
                entD.DebeHaberRegContabDeta = Me.dgvRegHon.Item(4, n).Value.ToString
                entD.ImporteSRegContabDeta = CType(Me.dgvRegHon.Item(5, n).Value.ToString, Decimal)
                entD.ImporteDRegContabDeta = CType(Me.dgvRegHon.Item(6, n).Value.ToString, Decimal)
                entD.CodigoIngEgr = Me.dgvRegHon.Item(7, n).Value.ToString
                entD.GlosaRegContabDeta = Me.dgvRegHon.Item(9, n).Value.ToString
                entD.CodigoArea = Me.dgvRegHon.Item(10, n).Value.ToString
                '   entD.CodigoGastoReparable = Me.dgvRegHon.Item(12, n).Value.ToString

                '/dEFECTO
                entD.Cuenta1242 = ""
                entD.CodigoFlujoCaja = ""
                entD.EstadoRegContabDeta = "0"
                entD.CodigoGastoReparable = ""

                rhd.nuevoRegContabDeta(entD)
            Next
        End If

    End Sub

    Sub GrabarAsientos()
        'Grabar cuenta de comprobante 4X Importe total del Honorario 
        Dim nreg As Integer = Me.dgvRegHon.Rows.Count - 1

        entD.ClaveRegContabCabe = ent.ClaveRegContabCabe
        entD.CorrelativoRegContabDeta = (nreg + 1).ToString.PadLeft(4, CType("0", Char))
        entD.CodigoAuxiliar = Me.txtCodAux.Text.Trim
        entD.TipoDocumento = Me.txtDoc.Text
        entD.SerieDocumento = Me.txtSer.Text.Trim.PadLeft(4, CType("0", Char))
        entD.NumeroDocumento = Me.txtNum.Text
        entD.FechaDocumento = Me.dtpFecha.Value
        entD.VentaTipoCambio = CType(Me.txtTipCam.Text, Decimal)
        entD.CodigoCuentaPcge = parEn.CuentaHonorarioNeto    '' Cuenta
        entD.CodigoCentroCosto = ""
        entD.CodigoGastoReparable = ""

        entD.DebeHaberRegContabDeta = "0"
        Select Case Rbt.radioActivo(Me.gbMoneda).Text
            Case "S/."
                entD.ImporteSRegContabDeta = CType(Me.txtPv.Text, Decimal) - CType(Me.txtVv.Text, Decimal) - CType(Me.TxtDescuento.Text, Decimal)
                entD.ImporteDRegContabDeta = (CType(Me.txtPv.Text, Decimal) - CType(Me.txtVv.Text, Decimal) - CType(Me.TxtDescuento.Text, Decimal)) / CType(Me.txtTipCam.Text, Decimal)
                entD.ImporteERegContabDeta = 0
            Case "US$"
                entD.ImporteSRegContabDeta = (CType(Me.txtPv.Text, Decimal) - CType(Me.txtVv.Text, Decimal) - CType(Me.TxtDescuento.Text, Decimal)) * CType(Me.txtTipCam.Text, Decimal)
                entD.ImporteDRegContabDeta = CType(Me.txtPv.Text, Decimal) - CType(Me.txtVv.Text, Decimal) - CType(Me.TxtDescuento.Text, Decimal)
                entD.ImporteERegContabDeta = 0
            Case "EUR"
                entD.ImporteSRegContabDeta = 0
                entD.ImporteDRegContabDeta = 0
                entD.ImporteERegContabDeta = CType(Me.txtPv.Text, Decimal)
        End Select

        entD.GlosaRegContabDeta = Me.txtGlosa.Text.Trim

        'defecto
        entD.Cuenta1242 = ""
        entD.CodigoIngEgr = ""
        entD.EstadoRegContabDeta = "1"  ' No se muestran
        rhd.nuevoRegContabDeta(entD)


        'SINO HAY RETENCION ENTONCES NO GRABA ESTA CUENTA
        If Me.txtVv.Text <> "0.00" Then
            'Grabar cuenta de comprobante 4X Retencion 
            entD.CodigoCuentaPcge = parEn.CuentaHonorarioRetencion
            Select Case Rbt.radioActivo(Me.gbMoneda).Text
                Case "S/."
                    entD.ImporteSRegContabDeta = CType(Me.txtVv.Text, Decimal)
                    entD.ImporteDRegContabDeta = CType(Me.txtVv.Text, Decimal) / CType(Me.txtTipCam.Text, Decimal)
                    entD.ImporteERegContabDeta = 0
                Case "US$"
                    entD.ImporteSRegContabDeta = CType(Me.txtVv.Text, Decimal) * CType(Me.txtTipCam.Text, Decimal)
                    entD.ImporteDRegContabDeta = CType(Me.txtVv.Text, Decimal)
                    entD.ImporteERegContabDeta = 0
                Case "EUR"
                    entD.ImporteSRegContabDeta = 0
                    entD.ImporteDRegContabDeta = 0
                    entD.ImporteERegContabDeta = CType(Me.txtVv.Text, Decimal)
            End Select

            entD.DebeHaberRegContabDeta = "0"  ''Haber   
            entD.CorrelativoRegContabDeta = (nreg + 2).ToString.PadLeft(4, CType("0", Char))
            entD.ClaveRegContabDeta = ent.ClaveRegContabCabe + entD.CorrelativoRegContabDeta
            rhd.nuevoRegContabDeta(entD)
        End If

        'SINO HAY DESCUENTO ENTONCES NO GRABA ESTA CUENTA
        If Me.TxtDescuento.Text <> "0.00" Then
            'Grabar cuenta de comprobante 4X Retencion
            If Rbt.radioActivo(Me.gbDscto).Text = "A.F.P." Then
                entD.CodigoCuentaPcge = parEn.CuentaAfp
            Else
                entD.CodigoCuentaPcge = parEn.CuentaSnp
            End If
            'entD.CodigoCuentaPcge = parEn.CuentaAfp   '"4444444" 'VIENE DE PARAMETRO
            Select Case Rbt.radioActivo(Me.gbMoneda).Text
                Case "S/."
                    entD.ImporteSRegContabDeta = CType(Me.TxtDescuento.Text, Decimal)
                    entD.ImporteDRegContabDeta = CType(Me.TxtDescuento.Text, Decimal) / CType(Me.txtTipCam.Text, Decimal)
                    entD.ImporteERegContabDeta = 0
                Case "US$"
                    entD.ImporteSRegContabDeta = CType(Me.TxtDescuento.Text, Decimal) * CType(Me.txtTipCam.Text, Decimal)
                    entD.ImporteDRegContabDeta = CType(Me.TxtDescuento.Text, Decimal)
                    entD.ImporteERegContabDeta = 0
                Case "EUR"
                    entD.ImporteSRegContabDeta = 0
                    entD.ImporteDRegContabDeta = 0
                    entD.ImporteERegContabDeta = CType(Me.TxtDescuento.Text, Decimal)
            End Select

            entD.DebeHaberRegContabDeta = "0"  ''Haber   
            entD.CorrelativoRegContabDeta = (nreg + 3).ToString.PadLeft(4, CType("0", Char))
            entD.ClaveRegContabDeta = ent.ClaveRegContabCabe + entD.CorrelativoRegContabDeta
            rhd.nuevoRegContabDeta(entD)
        End If

    End Sub

    Sub Aceptar()
        '//
        If Me.operacion = 1 Or Me.operacion = 2 Then
            'Volver a traer el registro 
            ent.DatoCondicion1 = ent.ClaveRegContabCabe
            ent = rh.buscarRegContabExisPorClave(ent)
        End If

        ent.PeriodoRegContabCabe = Me.txtPeri.Text
        ent.CodigoEmpresa = Me.TxtCodEmp.Text
        ent.CodigoOrigen = Me.txtCodOri.Text
        ent.CodigoFile = Me.txtCodFil.Text
        '   ent.NumeroVoucherRegContabCabe = Me.txtNumVau.Text
        ent.DiaVoucherRegContabCabe = Me.txtDia.Text
        ent.FechaVoucherRegContabCabe = CType(Me.txtFecVau.Text, Date)
        ent.CodigoAuxiliar = Me.txtCodAux.Text.Trim
        ent.TipoDocumento = Me.txtDoc.Text
        ent.SerieDocumento = Me.txtSer.Text
        ent.NumeroDocumento = Me.txtNum.Text
        ent.FechaDocumento = Me.dtpFecha.Value
        ent.VentaTipoCambio = CType(Me.txtTipCam.Text, Decimal)
        ent.VentaEurTipoCambio = CType(Me.txtTipCam1.Text, Decimal)
        ent.MonedaDocumento = Rbt.radioActivo(Me.gbMoneda).Text.ToString.Trim()
        ent.RetencionRegContabCabe = Rbt.radioActivo(Me.gbRete).Text.ToString.Trim()
        ent.PrecioVtaRegContabCabe = CType(Me.txtPv.Text, Decimal) 'Monto
        ent.ValorVtaRegContabCabe = CType(Me.txtVv.Text, Decimal) 'retencion
        ent.ExoneradoRegContabCabe = 0
        ent.IgvRegContabCabe = ent.PrecioVtaRegContabCabe - ent.ValorVtaRegContabCabe 'Neto
        ent.GlosaRegContabCabe = Me.txtGlosa.Text

        ent.SumaDebeRegContabCabe = ent.PrecioVtaRegContabCabe
        ent.SumaHaberRegContabCabe = ent.PrecioVtaRegContabCabe


        'COMO ESTA PANTALLA NO TE DEJA GRABAR SIN NINGUN DETALLE
        'EL ULTIMO CORRELATIVO  ES:
        Dim iUltCorre As Integer = Me.dgvRegHon.Rows.Count - 1

        'PERO INTERNAMENTE SE PUEDEN GENERAR 2 O 1 ASIENTO ADICIONAL
        'SI NO HAY RETENCION ENTONCES GENERA UN ASIENTO
        If Me.txtVv.Text = "0.00" Then
            'EL CORRELATIVO AUMENTA SOLO EN UNO
            iUltCorre += 1
        Else
            'EL CORRELATIVO AUMENTA EN DOS
            iUltCorre += 2
        End If
        ent.UltimoCorrelativo = (iUltCorre).ToString.PadLeft(4, CType("0", Char))

        'defecto para HONORARIOS 
        ent.FechaDetraccionRegContabCabe = ""
        ent.DetraccionRegContabCabe = ""
        ent.NumeroPapeletaRegContabCabe = ""
        ent.CodigoCuentaBanco = ""
        ent.CodigoModoPago = ""
        ent.ImporteRegContabCabe = 0
        ent.EstadoRegContabCabe = "1"
        ent.DescripcionRegContabCabe = ""
        ent.CartaRegContabCabe = ""
        ent.VoucherIngresoRegContabCabe = ""
        ent.ModoCompra = ""
        'ent.SumaDebeRegContabCabe = Varios.ObtieneSumaDebe(Me.dgvRegHon, ent.MonedaDocumento)
        'ent.SumaHaberRegContabCabe = Varios.ObtieneSumaHaber(Me.dgvRegHon, ent.MonedaDocumento)
        'ent.UltimoCorrelativo = (Me.dgvRegHon.Rows.Count - 1).ToString.PadLeft(4, CType("0", Char))

        'Segun file 407 

        ent.TipoDocumento1 = ""
        ent.SerieDocumento1 = ""
        ent.NumeroDocumento1 = ""
        ent.FechaDocumento1 = ""
        ent.MonedaDocumento1 = ""
        ent.FechaVencimiento = Me.DtpFechaVcto.Value ''Fecha Vencimiento

        ent.FlagDescuentoRegContabCabe = Rbt.radioActivo(Me.gbDscto).Text.Trim
        ent.CodigoAfp = Me.TxtCodAfp.Text.Trim
        ent.ImporteDescuentoRegContabCabe = CType(Me.TxtDescuento.Text, Decimal)
        ent.DescuentoFondo = iDsc.DescuentoFondo
        ent.DescuentoSalud = iDsc.DescuentoSalud
        ent.DescuentoRemu = iDsc.DescuentoRemu

        '/Se graba o0 se modifica?
        Select Case Me.operacion

            Case 0

                'Igv
                ent.IgvPar = parEn.IgvPar
                ''numero voucher autogenerado
                'Dim aut As New SuperEntidad
                'aut.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
                'aut.AnoVoucher = ent.PeriodoRegContabCabe.Substring(0, 4)
                'aut.CodigoMes = ent.PeriodoRegContabCabe.Substring(4, 2)
                'aut.CodigoFile = Me.txtCodFil.Text.Trim
                'ent.NumeroVoucherRegContabCabe = vou.obtenerVoucherAutogenerado(aut)
                ent.EstadoRegistro = "0" 'normal
                rh.nuevoRegContabCabe(ent)

                'eliminamos el detalle 
                rhd.eliminarRegContabDeta(ent)
                Me.GrabarDetalleRegContab()
                Me.eliminarCuentaCorriente()
                Me.GrabarCuentaCorriente()
                Me.GrabarAsientos()
                Me.CuadrarAsientos()

                MsgBox("Registro Honorario ingresado correctamente" + Chr(13) + "En Numero de Comprobante es: " + ent.NumeroVoucherRegContabCabe, MsgBoxStyle.Information)
                'Limpiar la grilla
                Me.dgvRegHon.Rows.Clear()
                acc.LimpiarControles()
                'Me.ImportesSolesDolares()
                Me.txtAsigFecAux.Text = ""
                Txt.cursorAlUltimo(Me.txtDia)

            Case 4
                'Igv
                ent.IgvPar = parEn.IgvPar
                'numero voucher autogenerado
                Dim aut As New SuperEntidad
                aut.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
                aut.PeriodoRegContabCabe = Me.txtPeri.Text.Trim
                aut.AnoVoucher = aut.PeriodoRegContabCabe.Substring(0, 4)
                aut.CodigoMes = aut.PeriodoRegContabCabe.Substring(4, 2)
                aut.CodigoFile = Me.txtCodFil.Text.Trim
                ent.NumeroVoucherRegContabCabe = vou.obtenerVoucherAutogenerado(aut)

                rh.nuevoRegContabCabe(ent)
                'eliminamos el detalle 
                ' rhd.eliminarDetalleRegContab(ent)
                Me.GrabarDetalleRegContab()
                MsgBox("Registro Honorario ingresado correctamente", MsgBoxStyle.Information)
                'Limpiar la grilla
                Me.dgvRegHon.Rows.Clear()
                acc.LimpiarControles()
                'Me.ImportesSolesDolares()
                Txt.cursorAlUltimo(Me.txtDia)

            Case 1
                'modificar cabecera
                rh.modificarRegContab(ent)
                'Eliminamos el detalle antiguo
                rhd.eliminarRegContabDeta(ent)
                'grabamos el nuevo detalle
                Me.GrabarDetalleRegContab()
                ' Preguntamos si el documento existe
                Me.eliminarCuentaCorriente()
                Me.GrabarCuentaCorriente()
                Me.GrabarAsientos()
                Me.CuadrarAsientos()

                MsgBox("Registro Honorario modificado correctamente", MsgBoxStyle.Information)
                Me.Close()

            Case 2
                'eliminar cabecera
                rh.eliminarRegContabFis(ent)
                rhd.eliminarRegContabDeta(ent)
                Me.eliminarCuentaCorriente()
                'Eliminamos el detalle antiguo
                ' pptoDe.eliminarPptoInternoDetalle(ent)
                '//Pregunta  pptoDe.eliminarPptoInternoDetalle(ent)
                'Me.GrabarDetalle()
                MsgBox("Registro Honorario Eliminado correctamente", MsgBoxStyle.Information)
                Me.Close()
            Case 5
                'Igv
                ent.IgvPar = parEn.IgvPar
                'numero voucher autogenerado
                ent.EstadoRegistro = "0" 'normal
                rh.nuevoRegContabCabe(ent)
                'eliminamos el detalle 
                rhd.eliminarRegContabDeta(ent)
                Me.GrabarDetalleRegContab()
                Me.eliminarCuentaCorriente()
                Me.GrabarCuentaCorriente()
                Me.GrabarAsientos()
                Me.CuadrarAsientos()

                MsgBox("Registro Honorario ingresado correctamente" + Chr(13) + "En Numero de Comprobante es: " + ent.NumeroVoucherRegContabCabe, MsgBoxStyle.Information)
                'Limpiar la grilla

                Me.Close()
        End Select
        '/Actualizar y buscar el registro grabado
        Me.wRh.ActualizarVentana()
        ent.ClaveRegContabCabe = ent.CodigoEmpresa + ent.PeriodoRegContabCabe + ent.CodigoOrigen + ent.CodigoFile + ent.NumeroVoucherRegContabCabe
        Dgv.obtenerCursorActual(Me.wRh.DgvHon, ent.ClaveRegContabCabe, Me.wRh.lista)
        '\\
    End Sub

    Function EsNumeroVoucherCorrecto() As Boolean
        Dim aut As New SuperEntidad
        aut.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        aut.AnoVoucher = Me.txtPeri.Text.Trim.Substring(0, 4)
        aut.CodigoMes = Me.txtPeri.Text.Trim.Substring(4, 2)
        aut.CodigoFile = Me.txtCodFil.Text.Trim
        ent.NumeroVoucherRegContabCabe = vou.obtenerVoucherAutogenerado(aut)

        Dim RccRN As New RegContabCabeRN
        Dim RccEN As New SuperEntidad
        RccEN.ClaveRegContabCabe += Me.TxtCodEmp.Text.Trim
        RccEN.ClaveRegContabCabe += Me.txtPeri.Text.Trim
        RccEN.ClaveRegContabCabe += Me.txtCodOri.Text.Trim
        RccEN.ClaveRegContabCabe += Me.txtCodFil.Text.Trim
        RccEN.ClaveRegContabCabe += ent.NumeroVoucherRegContabCabe
        RccEN = RccRN.buscarRegContabExisPorClave(RccEN)
        If RccEN.ClaveRegContabCabe = "" Then
            Return True
        Else
            MsgBox("El correlativo " + ent.NumeroVoucherRegContabCabe + " Ya Existe", MsgBoxStyle.Information, "Honorarios")
            Return False
        End If

    End Function

    Sub CuadrarAsientos()
        Dim sumadebe As Decimal = 0
        Dim sumahaber As Decimal = 0
        Dim iRcd As New SuperEntidad
        iRcd.ClaveRegContabCabe = ent.ClaveRegContabCabe
        Dim iLisRcd As New List(Of SuperEntidad)
        iLisRcd = rhd.obtenerDetalleRegContabPorClave(iRcd)
        For Each xobj As SuperEntidad In iLisRcd
            If xobj.DebeHaberRegContabDeta = "Debe" Then
                sumadebe += xobj.ImporteSRegContabDeta
            Else
                sumahaber += xobj.ImporteSRegContabDeta
            End If
        Next

        Dim iDif As Decimal = sumadebe - sumahaber
        If iDif = 0 Then Exit Sub

        For Each xobj As SuperEntidad In iLisRcd
            If iDif > 0 Then
                If xobj.DebeHaberRegContabDeta = "Haber" Then
                    xobj.ImporteSRegContabDeta += iDif
                    rhd.EliminarRegistroDetalleXClaveDetalle(xobj)
                    rhd.nuevoRegContabDeta(xobj)
                    Exit For
                End If
            Else
                If xobj.DebeHaberRegContabDeta = "Debe" Then
                    xobj.ImporteSRegContabDeta += Math.Abs(iDif)
                    rhd.EliminarRegistroDetalleXClaveDetalle(xobj)
                    rhd.nuevoRegContabDeta(xobj)
                    Exit For
                End If
            End If
        Next
    End Sub

    Sub GrabarCuentaCorriente()
        ent.PeriodoRegContabCabe = Me.txtPeri.Text
        ent.CodigoEmpresa = Me.TxtCodEmp.Text
        ent.CodigoOrigen = Me.txtCodOri.Text
        ent.CodigoFile = Me.txtCodFil.Text
        'ent.NumeroVoucherRegContabCabe = Me.txtNumVau.Text
        ent.CodigoAuxiliar = Me.txtCodAux.Text.Trim
        ent.TipoDocumento = Me.txtDoc.Text
        ent.SerieDocumento = Me.txtSer.Text.Trim
        ent.NumeroDocumento = Me.txtNum.Text
        ent.FechaDocumento = Me.dtpFecha.Value
        ent.VentaTipoCambio = CType(Me.txtTipCam.Text, Decimal)
        ent.VentaEurTipoCambio = CType(Me.txtTipCam1.Text, Decimal)
        ent.VentaTipoCambioOriginal = CType(Me.txtTipCam.Text, Decimal)
        ent.VentaEurTipoCambioOriginal = CType(Me.txtTipCam1.Text, Decimal)
        ent.CodigoCuentaPcge = parEn.CuentaHonorarioNeto
        ' ent.FechaVctoDocumento = ""
        ent.FechaVctoDocumento = Varios.AñoMesDia(Me.DtpFechaVcto.Value.Date)
        'moneda
        ent.MonedaDocumento = Rbt.radioActivo(Me.gbMoneda).Text.ToString.Trim()
        ent.ImporteOriginalCuentaCorriente = CType(Me.txtPv.Text, Decimal) - CType(Me.txtVv.Text, Decimal) - CType(Me.TxtDescuento.Text, Decimal)
        ent.ImportePagadoCuentaCorriente = 0
        ent.SaldoCuentaCorriente = CType(Me.txtPv.Text, Decimal) - CType(Me.txtVv.Text, Decimal) - CType(Me.TxtDescuento.Text, Decimal)
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
        If rh.BuscarRegContabCabeXDoc(obj).ClaveRegContabCabe <> "" Then
            MsgBox("Este documento ya esta Registrado", MsgBoxStyle.Exclamation, "Documentos")
            Me.txtNum.Focus()
            Return True
        Else
            Return False
        End If

    End Function

    Function EsDocumentoRegistradoEnOtroRegistroC() As Boolean
        'DOCUMENTO ACTUAL ANTES DE LA MODIFICACION
        Dim iDocActual As String = ent.CodigoEmpresa + ent.CodigoAuxiliar + ent.TipoDocumento + ent.SerieDocumento + ent.NumeroDocumento
        Dim obj As New SuperEntidad
        obj.ClaveCuentaCorriente = ent.ClaveRegContabCabe
        obj.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        obj.CodigoAuxiliar = Me.txtCodAux.Text.Trim
        obj.TipoDocumento = Me.txtDoc.Text.Trim
        obj.SerieDocumento = Me.txtSer.Text.Trim
        obj.NumeroDocumento = Me.txtNum.Text.Trim
        obj = rh.BuscarRegContabCabeXDoc(obj)
        If obj.ClaveRegContabCabe <> "" Then
            'SI EL DOCUMENTO ACTUAL Y EL NUEVO SON IGUALES ENTONCES PASA
            If iDocActual = obj.CodigoEmpresa + obj.CodigoAuxiliar + obj.TipoDocumento + obj.SerieDocumento + obj.NumeroDocumento Then
                Return False
            Else
                MsgBox("Este documento ya esta registrado en otro registro contable", MsgBoxStyle.Exclamation, "Documentos")
                Me.txtNum.Focus()
                Return True
            End If
        Else
            Return False
        End If
    End Function

    Function EsDocumentoPagado() As Boolean

        Dim obj As New SuperEntidad
        obj.ClaveCuentaCorriente = ent.ClaveRegContabCabe
        obj = ccte.buscarCuentaCorrienteExisPorClaveCC(obj)

        If obj.ImportePagadoCuentaCorriente <> 0 Then
            MsgBox("Documento ya tiene pagos no puede realizar la operacion", MsgBoxStyle.Exclamation, "Honorarios")
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

    Public Function EsAfpValido() As Boolean
        Dim iAfpRN As New AfpRN
        Dim iAfpEN As New SuperEntidad
        'iAreEN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iAfpEN.CodigoAfp = Me.TxtCodAfp.Text.Trim
        iAfpEN = iAfpRN.EsAfpValido(iAfpEN)
        If iAfpEN.EsVerdad = False Then
            MsgBox(iAfpEN.Mensaje, MsgBoxStyle.Exclamation, "Afp")
            Me.TxtCodAfp.Focus()
        End If
        Me.MostarAfp(iAfpEN)
        Return iAfpEN.EsVerdad
    End Function

    Sub MostarAfp(ByRef pAR As SuperEntidad)
        Me.TxtCodAfp.Text = pAR.CodigoAfp
        Me.TxtNomAfp.Text = pAR.NombreAfp
    End Sub


#End Region

#Region "Mostrar formulario lista"

    Private Sub txtCodAux_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodAux.KeyDown
        If Me.txtCodAux.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarAuxiliar
                win.wEditRegHon = Me
                Me.AddOwnedForm(win)
                win.tabla = "Todos"
                win.titulo = "Auxiliares"
                win.txt1 = Me.txtCodAux
                win.txt2 = Me.txtNomAux
                win.txt3 = Me.txtAsigFecAux
                win.ctrlFoco = Me.txtSer
                win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub TxtCodAfp_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodAfp.KeyDown
        If Me.txtCodAux.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarAfp
                win.tabla = "Afp"
                win.titulo = "AFP"
                win.txt1 = Me.TxtCodAfp
                win.txt2 = Me.TxtNomAfp
                win.ctrlFoco = Me.gbRete
                win.NuevaVentana()
            End If
        End If
    End Sub

#End Region

#Region "Buscar por codigo"

    Private Sub txtCodAux_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodAux.Validating
        If Me.operacion = 0 Or Me.operacion = 1 Or Me.operacion = 4 Or Me.operacion = 5 Then
            Dim ope As New OperaWin : ope.txt1 = Me.txtCodAux : ope.txt2 = Me.txtNomAux : ope.txt4 = Me.txtAsigFecAux
            'ope.MostrarCodigoDescripcionDeAuxiliar("Personal", "Natural", e)
            ope.MostrarCodigoDescripcionDeAuxiliar("Todos", "Auxiliares", e)
            Me.CalculoDescuento()
        End If

    End Sub

    Private Sub TxtCodAfp_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodAfp.Validating
        Me.EsAfpValido()
        
    End Sub

#End Region

#Region "Calculos"

    Sub ImportesSolesDolares()
        '/
        If Me.txtPv.Text <> "" Then
            If Me.txtVv.Text <> "" Then
                'Me.txtDist.Text = Varios.numeroConDosDecimal((CType(Me.txtPv.Text.Trim, Decimal) - CType(Me.txtVv.Text.Trim, Decimal)).ToString)
                Me.txtDist.Text = Varios.numeroConDosDecimal(Me.txtPv.Text.Trim)
                Dim str As String = Rbt.radioActivo(Me.gbMoneda).Text.ToString.Trim()
                Select Case str
                    Case "US$"
                        Me.txtImpTotSol.Text = Varios.numeroConDosDecimal((CType(Me.txtDist.Text, Decimal) * CType(Me.txtTipCam.Text, Decimal)).ToString)
                        Me.txtImpTotDol.Text = Me.txtDist.Text
                        Me.txtSalImpTotSol.Text = Varios.numeroConDosDecimal((CType(Me.txtImpTotSol.Text, Decimal) - Me.sumaImportes).ToString)
                    Case "S/."
                        Me.txtImpTotSol.Text = Me.txtDist.Text
                        Me.txtImpTotDol.Text = Varios.numeroConDosDecimal((CType(Me.txtDist.Text, Decimal) / CType(Me.txtTipCam.Text, Decimal)).ToString)
                        Me.txtSalImpTotSol.Text = Varios.numeroConDosDecimal((CType(Me.txtImpTotSol.Text, Decimal) - Me.sumaImportes).ToString)
                End Select
            End If
        End If

        If Me.operacion = 2 Or Me.operacion = 3 Then
            Me.txtSalImpTotSol.Text = "0.00"
        End If

        '/
    End Sub

    Private Sub txtDia_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDia.Validated
        If Me.txtPeri.Text <> "" Then
            If Me.txtDia.Text.Trim <> "" Then
                Dim periodo As String = Me.txtPeri.Text.Trim
                Dim dia As String = Me.txtDia.Text.Trim
                If Varios.LimiteMinMaxDeValores(dia, 1, 31) = True Then
                    dia = Varios.FormatoDia(dia)
                    Me.txtDia.Text = dia
                    Me.txtFecVau.Text = dia + "/" + periodo.Substring(4, 2) + "/" + periodo.Substring(0, 4)
                    If Me.operacion = 0 Then
                        Me.dtpFecha.Text = Me.txtFecVau.Text
                        Me.DtpFechaVcto.Text = Me.txtFecVau.Text
                    End If
                    '' Es Fecha Valida
                    If Varios.ValidaDia(Me.txtFecVau.Text) = False Then
                        Me.txtFecVau.Text = String.Empty
                        Me.txtPeri.Focus()
                    End If
                Else
                    MsgBox("El dia debe estar entre en 1 y 31", MsgBoxStyle.Information)
                    Me.txtDia.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub txtPv_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPv.Validated
        Me.CalculoRetencion()
        Me.CalculoDescuento()
        'calculo distribuir
        Me.ImportesSolesDolares()
    End Sub

    Private Sub txtVv_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtVv.Validated
        'Me.txtDist.Text = Varios.numeroConDosDecimal((CType(Me.txtPv.Text.Trim, Decimal) - CType(Me.txtVv.Text.Trim, Decimal)).ToString)
        ''calculo distribuir
        'Me.ImportesSolesDolares()
    End Sub

    Public Function sumaImportes() As Decimal
        Dim sumImp As Decimal = 0
        If Me.dgvRegHon.RowCount = 1 Then
            Return sumImp
        Else

            For n As Integer = 0 To Me.dgvRegHon.RowCount - 2
                Dim valor As String = Me.dgvRegHon.Item(5, n).Value.ToString
                sumImp = sumImp + CType(valor, Decimal)

                'If valor = "" Then

                'End If

            Next
            Return sumImp
        End If

    End Function

    Sub CalculoRetencion()
        '/
        Dim mon As String = Me.txtPv.Text.Trim
        Dim ret As String = Me.txtVv.Text.Trim
        If mon <> "" Then
            If ret <> "" Then
                Dim rete As String = Rbt.radioActivo(Me.gbRete).Text
                ' calculados segun la retencion
                Select Case rete
                    Case "Si"
                        Me.txtVv.Text = Varios.numeroConDosDecimal((CType(mon, Decimal) * parEn.PorRetencionHonorario / 100).ToString)
                    Case "No"
                        Me.txtVv.Text = "0.00"
                End Select
            End If
        End If
        '/
    End Sub

    Sub CalculoDescuento()
        Dim iRchRN As New RegContabCabeRN
        Dim iRchEN As New SuperEntidad
        iRchEN.PeriodoRegContabCabe = Me.txtPeri.Text.Trim
        iRchEN.NumeroVoucherRegContabCabe = Me.txtNumVau.Text.Trim
        iRchEN.CodigoAuxiliar = Me.txtCodAux.Text.Trim
        'Campo Nuevo
        iRchEN.FechaInscripcionSnpAuxiliar = Varios.AñoMesDia(Me.txtAsigFecAux.Text)
        iRchEN.FlagDescuentoRegContabCabe = Rbt.radioActivo(Me.gbDscto).Text.Trim
        iRchEN.PrecioVtaRegContabCabe = CType(Me.txtPv.Text, Decimal)
        iRchEN.MonedaDocumento = Rbt.radioActivo(Me.gbMoneda).Text.Trim
        iRchEN.CodigoAfp = Me.TxtCodAfp.Text.Trim
        iRchEN.VentaTipoCambio = CType(Me.txtTipCam.Text, Decimal)
        iDsc = iRchRN.ObtenerDescuentoHonorario(iRchEN)
        'SUMAS TODOS LOS DESCUENTOS
        Dim iTotalDscto As Decimal = iDsc.DescuentoFondo + iDsc.DescuentoRemu + iDsc.DescuentoSalud

        'MsgBox(iDsc.DescuentoFondo.ToString, MsgBoxStyle.Exclamation, "Descuento Total1")
        'MsgBox(iDsc.DescuentoRemu.ToString, MsgBoxStyle.Exclamation, "Descuento Total2")
        'MsgBox(iDsc.DescuentoSalud.ToString, MsgBoxStyle.Exclamation, "Descuento Total3")

        Me.TxtDescuento.Text = Varios.numeroConDosDecimal(iTotalDscto.ToString)
    End Sub

    Sub HabilitarControlesSegunDescuento()
        '/
        Dim dscto As String = Rbt.radioActivo(Me.gbDscto).Text
        'Habilitar los campos calculados segun la detraccion
        Select Case dscto
            Case "A.F.P."
                Me.TxtCodAfp.Enabled = True
            Case Else
                Me.TxtCodAfp.Enabled = False
                Me.TxtCodAfp.Text = ""
                Me.TxtNomAfp.Text = ""
        End Select
        '/
    End Sub

    Function ValidarAfp() As Boolean
        If Rbt.radioActivo(Me.gbDscto).Text = "A.F.P." Then
            If Me.TxtCodAfp.Text.Trim = "" Then
                MsgBox("Debes digitar un Afp", MsgBoxStyle.Information, "Afp")
                Me.TxtCodAfp.Focus()
                Return False
            End If
        End If
        Return True
    End Function
#End Region

#Region "Para Items"

    Sub NuevoItem()
        Dim win1 As New WDetalleRegHonorario
        'win1.concepto = Me.concepto
        'win1.titulo = Me.titulo
        win1.wRegHon = Me
        Me.AddOwnedForm(win1)
        win1.NuevaVentana()
    End Sub

    Sub ModificarItem()
        Dim win1 As New WDetalleRegHonorario
        ' win1.concepto = Me.concepto
        ' win1.titulo = Me.titulo
        win1.wRegHon = Me
        Me.AddOwnedForm(win1)
        win1.ModificarVentana()
    End Sub

    Sub EliminarItem()
        Dim win1 As New WDetalleRegHonorario
        'win1.concepto = Me.concepto
        'win1.titulo = Me.titulo
        win1.wRegHon = Me
        Me.AddOwnedForm(win1)
        win1.EliminaVentana()

    End Sub


#End Region


    Private Sub rbtSol_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles rbtSol.Validating
        Me.ImportesSolesDolares()
        Me.CalculoDescuento()
    End Sub

    Private Sub rbtDol_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles rbtDol.Validating
        Me.ImportesSolesDolares()
        me.CalculoDescuento
    End Sub

    Private Sub txtPeri_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPeri.Validated
        If Me.Text = "Agregar Manual Registro Honorario" Then
            Dim p As String = Me.txtPeri.Text.Trim
            If p <> "" Then
                If p.Length <> 6 Then
                    MsgBox("No es un periodo valido", MsgBoxStyle.Information, "")
                    Me.txtPeri.Text = ""
                    Me.txtPeri.Focus()
                Else
                    If p >= PeriodoActual Then
                        MsgBox("Solo se puede digitar como maximo el periodo anterior de hoy", MsgBoxStyle.Information, "")
                        Me.txtPeri.Text = ""
                        Me.txtPeri.Focus()
                    Else
                        Dim dia As String = Me.txtDia.Text.Trim
                        If dia <> String.Empty Then
                            dia = Varios.FormatoDia(dia)
                            'Me.txtDia.Text = dia
                            Me.txtFecVau.Text = dia + "/" + Me.txtPeri.Text.Substring(4, 2) + "/" + Me.txtPeri.Text.Substring(0, 4)
                            '' Es Fecha Valida
                            If Varios.ValidaDia(Me.txtFecVau.Text) = False Then
                                Me.txtFecVau.Text = String.Empty
                                Me.txtPeri.Focus()
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub CambiarRetencion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtReSi.CheckedChanged, rbtReNo.CheckedChanged
        If Me.Text = "Agregar Registro Honorario" Or Me.Text = "Modificar Registro Honorario" Or Me.Text = "Agregar Manual Registro Honorario" Or Me.operacion = 5 Then
            Me.CalculoRetencion()
        End If
    End Sub

    Private Sub WEditarPptoInterno_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Me.Text = "Eliminar Registro Honorario" Then
            Me.Aceptar()
            Exit Sub
        End If

        If acc.CamposObligatorios = False Then
            Exit Sub
        Else
            'VALIDAR EL AFP
            If Me.ValidarAfp = False Then Exit Sub

            Dim resta As Decimal = CType(Me.txtImpTotSol.Text, Decimal) - Me.sumaImportes
            Select Case resta
                Case Is < 0
                    MsgBox("La suma de los importes en el detalle ha sobrepasado al importe total en soles")
                Case Is = 0
                    If Me.operacion = 0 Or Me.operacion = 5 Then
                        If Me.EsDocumentoRegistrado() = True Then Exit Sub
                    Else
                        If Me.EsDocumentoRegistradoEnOtroRegistroC() = True Then Exit Sub
                    End If

                    If Me.EsDocumentoPagado = True Then Exit Sub

                    Me.eliminarCuentaCorriente()

                    If Me.operacion = 0 Or Me.operacion = 5 Then
                        'Validadando el correlativo del voucher
                        If Me.EsNumeroVoucherCorrecto = False Then Exit Sub
                    End If
                    Me.Aceptar()
                    ent.ClaveRegContabCabe = ""  '' Para mas de un documento del proveedor
                    Me.txtDist.Text = "0.00"

                Case Is > 0
                    MsgBox("La suma de los importes en el detalle es menor que el importe total en soles")
            End Select

        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If Me.Text = "Visualizar Registro Honorario" Then
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
        Me.ImportesSolesDolares()
        me.CalculoDescuento
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim numReg As Integer = Me.dgvRegHon.Rows.Count
        If numReg = 0 Or numReg = 1 Then
            Exit Sub
        Else
            Dim indFil As Integer = Me.dgvRegHon.CurrentRow.Index
            If indFil = numReg - 1 Then
                Exit Sub
            Else
                Me.EliminarItem()
            End If
        End If
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If Me.txtImpTotSol.Text = "0.00" Then
            MsgBox("No tiene Importe Total en soles")
        Else
            If CType(Me.txtImpTotSol.Text, Decimal) < Me.sumaImportes Then
                MsgBox("La suma de sus importes en el detalle ha sobrepasado al Importe total en soles")
            Else
                If CType(Me.txtImpTotSol.Text, Decimal) = Me.sumaImportes Then
                    MsgBox("La suma de los importes ya estan cuadrados")
                Else
                    Me.NuevoItem()
                End If
            End If
        End If
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Dim numReg As Integer = Me.dgvRegHon.Rows.Count
        If numReg = 0 Or numReg = 1 Then
            Exit Sub
        Else
            Dim indFil As Integer = Me.dgvRegHon.CurrentRow.Index
            If indFil = numReg - 1 Then
                Exit Sub
            Else
                Me.ModificarItem()
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

  
    Private Sub rbtDesAfp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtDesAfp.CheckedChanged, rbtDesSnp.CheckedChanged, rbtDesNo.CheckedChanged
        If Me.operacion = 0 Or Me.operacion = 1 Or Me.operacion = 5 Then
            Me.HabilitarControlesSegunDescuento()
        End If
    End Sub


    Private Sub rbtDesAfp_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles rbtDesAfp.Validating, rbtDesSnp.Validating, rbtDesNo.Validating
        If Me.operacion = 0 Or Me.operacion = 1 Or Me.operacion = 5 Then
            Me.CalculoDescuento()
        End If
    End Sub

    
End Class