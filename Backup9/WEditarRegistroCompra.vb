Imports Entidad
Imports Negocio

Public Class WEditarRegistroCompra

#Region "Propietarios"
    Public wRc As New WRegistroCompra
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
    Public operacion As Integer  '0=agregar , 1=modificar , 2=eliminar , 3=visualizar , 4=Manual ,5=copia'

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

        Me.TxtPeri.Text = SuperEntidad.xPeriodoEmpresa
        PeriodoActual = SuperEntidad.xPeriodoEmpresa

        Me.TxtPorIgv.Text = parEn.IgvPar.ToString
        Me.txtCodOri.Text = "4"
        Me.txtNomOri.Text = "Compras"
        Me.TraerTipoCambio()
    End Sub

    Sub TraerTipoCambio()
        'traer tipo de cambio
        If Me.txtDoc.Text = "07" Or Me.txtDoc.Text = "08" And Rbt.radioActivo(Me.gbMoneda).Text = "US$" Then
            ticEn.DatoCondicion1 = Me.DtpFecha1.Value.Year.ToString + "/" + Me.DtpFecha1.Value.Month.ToString + "/" + Me.DtpFecha1.Value.Day.ToString
            ticEn = tic.buscarTipoCambioExisPorFecha(ticEn)
        Else
            ticEn.DatoCondicion1 = Me.dtpFecha.Value.Year.ToString + "/" + Me.dtpFecha.Value.Month.ToString + "/" + Me.dtpFecha.Value.Day.ToString
            ticEn = tic.buscarTipoCambioExisPorFecha(ticEn)
        End If

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
        'titulo de la ventana
        Me.Text = "Agregar Registro Compra"
        'poner valores defecto en montos
        acc.LimpiarControles()
        'por defecto
        Me.PorDefecto()
        Me.ImportesSolesDolares()
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtCodFil)
        'los controles que deben estar activos
        acc.Nuevo()
        Me.HabilitarControlesSegunDetraccion()
        Me.HabilitarControlesSegunFile407()
        '\\
    End Sub

    Sub ventanaAdicionarManual()
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Agregar Manual Registro Compra"
        'poner valores defecto en montos
        acc.LimpiarControles()
        'por defecto
        Me.PorDefecto()
        Me.ImportesSolesDolares()
        'en blanco
        Me.TxtPeri.Text = String.Empty

        'los controles que deben estar activos
        acc.Nuevo()
        Me.TxtPeri.ReadOnly = False
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.TxtPeri)
        Me.HabilitarControlesSegunDetraccion()
        Me.HabilitarControlesSegunFile407()
        '\\
    End Sub

    Sub ventanaModificar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Modificar Registro Compra"
        'mostrar el registro en pantalla
        Me.obtenerRegCompraEnPantalla(codigo)
        'mostrar el detalle del registro en pantalla
        Me.obtenerRegCompraDetalleEnPantalla(codigo)
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtDia)
        Me.ImportesSolesDolares()
        'los controles que deben estar activos
        acc.Modificar()
        If Me.txtDoc.Text.Trim = "03" Then
            Me.txtEx.ReadOnly = True
        Else
            Me.txtEx.ReadOnly = False
        End If
        Me.HabilitarControlesSegunDetraccion()
        Me.HabilitarControlesSegunFile407()
        '\\
    End Sub

    Sub ventanaEliminar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Eliminar Registro Compra"
        'mostrar el registro en pantalla
        Me.obtenerRegCompraEnPantalla(codigo)
        'mostrar el detalle del registro en pantalla
        Me.obtenerRegCompraDetalleEnPantalla(codigo)
        Me.btnAceptar.Text = "Eliminar"
        Me.btnAceptar.Focus()
        Me.ImportesSolesDolares()
        'los controles que deben estar activos
        acc.Eliminar()
        Me.HabilitarControlesSegunDetraccion()
        Me.HabilitarControlesSegunFile407()
        '\\
    End Sub

    Sub ventanaVisualizar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Visualizar Registro Compra"
        'mostrar el registro en pantalla
        Me.obtenerRegCompraEnPantalla(codigo)
        'mostrar el detalle del registro en pantalla
        Me.obtenerRegCompraDetalleEnPantalla(codigo)
        'los controles que deben estar activos
        Me.ImportesSolesDolares()
        acc.Visualizar()
        Me.HabilitarControlesSegunDetraccion()
        Me.HabilitarControlesSegunFile407()
        '\\
    End Sub

    Sub ventanaCopiar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Copiar Registro Compra"
        'mostrar el registro en pantalla
        Me.obtenerRegCompraEnPantalla(codigo)
        'mostrar el detalle del registro en pantalla
        Me.obtenerRegCompraDetalleEnPantalla(codigo)

        'limpiar el correlativo voucher
        Me.txtNumVau.Text = ""
        ent.ClaveRegContabCabe = ""

        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtCodFil)
        Me.ImportesSolesDolares()
        'los controles que deben estar activos
        acc.Modificar()

        'habilitar el campo file ya que en el modificar este control esta deshabilitado
        Me.txtCodFil.ReadOnly = False

        If Me.txtDoc.Text.Trim = "03" Then
            Me.txtEx.ReadOnly = True
        Else
            Me.txtEx.ReadOnly = False
        End If
        Me.HabilitarControlesSegunDetraccion()
        Me.HabilitarControlesSegunFile407()

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
            Gb.pasarDato(Me.gbModo, ent.ModoCompra)
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
            'CAMPO APLICA IGV
            Me.ckbAplIgv.Checked = CType(IIf(ent.Exporta = "1", True, False), Boolean)
            Me.txtGlosa.Text = ent.GlosaRegContabCabe
            Gb.pasarDato(Me.gbMovi, ent.DetraccionRegContabCabe)
            Me.txtNumPape.Text = ent.NumeroPapeletaRegContabCabe
            Me.dtpFecDetra.Text = ent.FechaDetraccionRegContabCabe
            Me.DtpFechaVcto.Value = ent.FechaVencimiento
            Me.TxtDoc1.Text = ent.TipoDocumento1
            Me.TxtNomDoc1.Text = ent.NombreDocumento1
            Me.TxtSer1.Text = ent.SerieDocumento1
            Me.TxtNum1.Text = ent.NumeroDocumento1
            Gb.pasarDato(Me.GbMoneda1, ent.MonedaDocumento1)
            Me.DtpFecha1.Text = ent.FechaDocumento1
            Me.TxtCuenta.Text = ent.CodigoCuentaBanco
            Me.TxtNombreCuenta.Text = ent.NombreCuentaPcge
        End If
        '\\
    End Sub

    Sub obtenerRegCompraDetalleEnPantalla(ByRef codigo As String)
        '/
        entD.ClaveRegContabCabe = codigo
        entD.EstadoRegContabDeta = "0" 'loS QUE SE VEN

        If Me.operacion = 1 Or Me.operacion = 5 Then
            listaD = rcd.obtenerDetalleRegContabXClaveYEstado(entD)
        Else
            entD.CampoOrden = cam.ClaveRCD
            listaD = rcd.obtenerDetalleRegContabXClaveCabe(entD)
        End If

        'listaD = rcd.obtenerDetalleRegContabPorClave(entD)
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
                Me.dgvRegCom.Rows(n).Cells(8).Value = listaD.Item(n).CodigoIngEgr
                Me.dgvRegCom.Rows(n).Cells(9).Value = listaD.Item(n).NombreIngEgr
                Me.dgvRegCom.Rows(n).Cells(10).Value = listaD.Item(n).CodigoArea
                Me.dgvRegCom.Rows(n).Cells(11).Value = listaD.Item(n).NombreArea
                Me.dgvRegCom.Rows(n).Cells(12).Value = listaD.Item(n).CodigoGastoReparable
                Me.dgvRegCom.Rows(n).Cells(13).Value = listaD.Item(n).NombreGastoReparable
                Me.dgvRegCom.Rows(n).Cells(14).Value = Varios.numeroConDosDecimal(listaD.Item(n).Cantidad.ToString)

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
                entD.CodigoIngEgr = Me.dgvRegCom.Item(8, n).Value.ToString
                entD.CodigoArea = Me.dgvRegCom.Item(10, n).Value.ToString
                entD.CodigoGastoReparable = Me.dgvRegCom.Item(12, n).Value.ToString
                entD.Cantidad = CType(Me.dgvRegCom.Item(14, n).Value.ToString, Decimal)
                'defecto
                entD.Cuenta1242 = Me.TxtCuenta.Text.Trim
                ' entD.CodigoIngEgr = ""
                entD.EstadoRegContabDeta = "0"
                entD.CodigoFlujoCaja = ""
                entD.ImporteRegContabCabe = 0
                rcd.nuevoRegContabDeta(entD)
            Next
        End If
    End Sub

    Sub GrabarAsientos()
        'Grabar cuenta de comprobante 42 precioventa
        Dim nreg As Integer = Me.dgvRegCom.Rows.Count - 1
        nreg += 1
        entD.ClaveRegContabCabe = ent.ClaveRegContabCabe
        entD.CorrelativoRegContabDeta = (nreg).ToString.PadLeft(4, CType("0", Char))
        entD.CodigoAuxiliar = Me.txtCodAux.Text.Trim
        entD.TipoDocumento = Me.txtDoc.Text
        entD.SerieDocumento = Me.txtSer.Text.Trim.PadLeft(4, CType("0", Char))
        entD.NumeroDocumento = Me.txtNum.Text
        entD.FechaDocumento = Me.dtpFecha.Value
        entD.VentaTipoCambio = CType(Me.txtTipCam.Text, Decimal)
        entD.CodigoCuentaPcge = Me.TxtCuenta.Text.Trim
        entD.CodigoCentroCosto = ""
        entD.CodigoGastoReparable = ""
        If ent.CodigoFile = "407" Then
            entD.DebeHaberRegContabDeta = "1"
        Else
            entD.DebeHaberRegContabDeta = "0"
        End If

        Select Case Rbt.radioActivo(Me.gbMoneda).Text
            Case "S/."
                entD.ImporteSRegContabDeta = CType(Me.txtPv.Text, Decimal)
                entD.ImporteDRegContabDeta = CType(Me.txtPv.Text, Decimal) / CType(Me.txtTipCam.Text, Decimal)
                entD.ImporteERegContabDeta = CType(Me.txtPv.Text, Decimal) / CType(Me.TxtTipCam1.Text, Decimal)
            Case "US$"
                entD.ImporteSRegContabDeta = CType(Me.txtPv.Text, Decimal) * CType(Me.txtTipCam.Text, Decimal)
                entD.ImporteDRegContabDeta = CType(Me.txtPv.Text, Decimal)
                entD.ImporteERegContabDeta = CType(Me.txtPv.Text, Decimal) / CType(Me.TxtTipCam1.Text, Decimal)
            Case "CAD"
                entD.ImporteSRegContabDeta = CType(Me.txtPv.Text, Decimal) * CType(Me.TxtTipCam1.Text, Decimal)
                entD.ImporteDRegContabDeta = CType(Me.txtPv.Text, Decimal) / CType(Me.TxtTipCam1.Text, Decimal)
                entD.ImporteERegContabDeta = CType(Me.txtPv.Text, Decimal)
        End Select

        entD.GlosaRegContabDeta = Me.txtGlosa.Text.Trim

        'defecto
        entD.Cuenta1242 = ""
        entD.CodigoIngEgr = ""
        entD.EstadoRegContabDeta = "1"  ' No se muestran
        rcd.nuevoRegContabDeta(entD)

        'GRABAR ASIENTO EXONERADO SI ESTE ES NEGATIVO
        'SI ES POSITIVO ESTE SE REGISTRA EN EL DETALLE
        Dim iExo As Decimal = CType(Me.txtEx.Text, Decimal)
        If iExo < 0 Then
            entD.CodigoCuentaPcge = Me.dgvRegCom.Item(0, 0).Value.ToString
            entD.CodigoCentroCosto = Me.ObtenerMayorCentroCosto

            'valor absoluto para el exonerado
            iExo = Math.Abs(iExo)
            Select Case Rbt.radioActivo(Me.gbMoneda).Text
                Case "S/."
                    entD.ImporteSRegContabDeta = iExo
                    entD.ImporteDRegContabDeta = iExo / CType(Me.txtTipCam.Text, Decimal)
                    entD.ImporteERegContabDeta = iExo / CType(Me.TxtTipCam1.Text, Decimal)
                Case "US$"
                    entD.ImporteSRegContabDeta = iExo * CType(Me.txtTipCam.Text, Decimal)
                    entD.ImporteDRegContabDeta = iExo
                    entD.ImporteERegContabDeta = iExo / CType(Me.TxtTipCam1.Text, Decimal)
                Case "CAD"
                    entD.ImporteSRegContabDeta = iExo * CType(Me.TxtTipCam1.Text, Decimal)
                    entD.ImporteDRegContabDeta = iExo / CType(Me.TxtTipCam1.Text, Decimal)
                    entD.ImporteERegContabDeta = iExo
            End Select

            nreg += 1
            If ent.CodigoFile = "407" Then
                entD.DebeHaberRegContabDeta = "1" 'No se Muestran
            Else
                entD.DebeHaberRegContabDeta = "0" 'No se Muestran
            End If

            entD.CorrelativoRegContabDeta = (nreg).ToString.PadLeft(4, CType("0", Char))
            entD.ClaveRegContabDeta = ent.ClaveRegContabCabe + entD.CorrelativoRegContabDeta
            rcd.nuevoRegContabDeta(entD)
            nreg = 3
        End If

        'SI ES UNA BOLETA ENTONCES NO HAY ASIENTO DE IGV
        If Me.txtDoc.Text = "03" Then Exit Sub

        'VER SI APLICA O NO IGV
        If Me.ckbAplIgv.Checked = False Then Exit Sub

       

        'SINO ES BOLETA GRABA CUENTA IGV
        entD.CodigoCuentaPcge = parEn.CuentaIgv
        Select Case Rbt.radioActivo(Me.gbMoneda).Text
            Case "S/."
                entD.ImporteSRegContabDeta = CType(Me.txtIgv.Text, Decimal)
                entD.ImporteDRegContabDeta = CType(Me.txtIgv.Text, Decimal) / CType(Me.txtTipCam.Text, Decimal)
                entD.ImporteERegContabDeta = CType(Me.txtIgv.Text, Decimal) / CType(Me.TxtTipCam1.Text, Decimal)
            Case "US$"
                entD.ImporteSRegContabDeta = CType(Me.txtIgv.Text, Decimal) * CType(Me.txtTipCam.Text, Decimal)
                entD.ImporteDRegContabDeta = CType(Me.txtIgv.Text, Decimal)
                entD.ImporteERegContabDeta = CType(Me.txtIgv.Text, Decimal) / CType(Me.TxtTipCam1.Text, Decimal)
            Case "CAD"
                entD.ImporteSRegContabDeta = CType(Me.txtIgv.Text, Decimal) * CType(Me.TxtTipCam1.Text, Decimal)
                entD.ImporteDRegContabDeta = CType(Me.txtIgv.Text, Decimal) / CType(Me.TxtTipCam1.Text, Decimal)
                entD.ImporteERegContabDeta = CType(Me.txtIgv.Text, Decimal)
        End Select

        If ent.CodigoFile = "407" Then
            entD.DebeHaberRegContabDeta = "0"
        Else
            entD.DebeHaberRegContabDeta = "1"
        End If

        nreg += 1
        entD.CorrelativoRegContabDeta = (nreg).ToString.PadLeft(4, CType("0", Char))
        entD.ClaveRegContabDeta = ent.ClaveRegContabCabe + entD.CorrelativoRegContabDeta
        rcd.nuevoRegContabDeta(entD)

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
        ' ent.NumeroVoucherRegContabCabe = Me.txtNumVau.Text
        ent.DiaVoucherRegContabCabe = Me.txtDia.Text
        ent.FechaVoucherRegContabCabe = CType(Me.txtFecVau.Text, Date)
        ent.CodigoAuxiliar = Me.txtCodAux.Text.Trim
        ent.ModoCompra = Rbt.radioActivo(Me.gbModo).Text.ToString.Trim()
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
        'APLICA IGV(EN EL CAMPO Exporta SE GUARDARA EL FLAG DE SI APLICA O NO IGV)
        ent.Exporta = IIf(Me.ckbAplIgv.Checked = True, 1, 0).ToString

        ent.GlosaRegContabCabe = Me.txtGlosa.Text
        ent.DetraccionRegContabCabe = Rbt.radioActivo(Me.gbMovi).Text
        ent.NumeroPapeletaRegContabCabe = Me.txtNumPape.Text.Trim
        'validar fecha detraccion
        If Me.dtpFecDetra.Enabled = True Then
            ent.FechaDetraccionRegContabCabe = Me.dtpFecDetra.Text
        Else
            ent.FechaDetraccionRegContabCabe = ""
        End If
        ent.SumaDebeRegContabCabe = ent.PrecioVtaRegContabCabe
        ent.SumaHaberRegContabCabe = ent.PrecioVtaRegContabCabe

        'COMO ESTA PANTALLA NO TE DEJA GRABAR SIN NINGUN DETALLE
        'EL ULTIMO CORRELATIVO  ES:
        Dim iUltCorre As Integer = Me.dgvRegCom.Rows.Count - 1

        'PERO INTERNAMENTE SE PUEDEN GENERAR 2 O 1 ASIENTE ADICIONAL
        'SI ES UNA BOLETA ENTONCES NO HAY ASIENTO DE IGV
        If Me.txtDoc.Text = "03" Then
            'EL CORRELATIVO AUMENTA SOLO EN UNO
            iUltCorre += 1
        Else
            'EL CORRELATIVO AUMENTA EN DOS
            iUltCorre += 2
        End If
        ent.UltimoCorrelativo = (iUltCorre).ToString.PadLeft(4, CType("0", Char))

        'Segun file 407 

        ent.TipoDocumento1 = Me.TxtDoc1.Text.Trim
        ent.SerieDocumento1 = Me.TxtSer1.Text.Trim
        ent.NumeroDocumento1 = Me.TxtNum1.Text.Trim
        ent.MonedaDocumento1 = Rbt.radioActivo(Me.GbMoneda1).Text.ToString.Trim()
        ent.CodigoCuentaBanco = Me.TxtCuenta.Text.Trim

        If Me.DtpFecha1.Enabled = True Then
            ent.FechaDocumento1 = Me.DtpFecha1.Text
        Else
            ent.FechaDocumento1 = ""
        End If

        ent.FechaVencimiento = Me.DtpFechaVcto.Value

        'defecto para compras
        ent.ImporteRegContabCabe = 0  ''Inicio al grabar varia con otro proceso sino se graba en negocio
        ent.EstadoRegContabCabe = "1"
        ent.CodigoIngEgr = ""
        ent.CodigoModoPago = ""
        ent.RetencionRegContabCabe = ""
        ent.DescripcionRegContabCabe = ""
        ent.CartaRegContabCabe = ""
        ent.VoucherIngresoRegContabCabe = ""

        '/Se graba o0 se modifica?

        Select Case Me.operacion

            Case 0        'Nuevo
                'Igv
                ent.IgvPar = parEn.IgvPar
                'numero voucher autogenerado
                
                ent.EstadoRegistro = "0" 'normal

                rc.nuevoRegContabCabe(ent)
                Me.GrabarCuentaCorriente()
                'eliminamos el detalle 
                'rcd.eliminarRegContabDeta(ent)
                Me.GrabarDetalleRegContab()
                Me.GrabarAsientos()
                Me.CuadrarAsientos()

                MsgBox("Registro Compra ingresado correctamente " + Chr(13) + "Numero de Voucher Generado:" + ent.NumeroVoucherRegContabCabe, MsgBoxStyle.Information)
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
                ' Me.eliminarCuentaCorriente()
                Me.GrabarCuentaCorriente()
                MsgBox("Registro Compra ingresado correctamente", MsgBoxStyle.Information)
                'Limpiar la grilla
                Me.dgvRegCom.Rows.Clear()
                acc.LimpiarControles()
                'Me.ImportesSolesDolares()
                Txt.cursorAlUltimo(Me.txtDia)

            Case 1
                'modificar cabecera
                'MsgBox("1")
                rc.modificarRegContab(ent)
                'Eliminamos el detalle antiguo
                rcd.eliminarRegContabDeta(ent)
                'MsgBox("2")
                'grabamos el nuevo detalle
                Me.GrabarDetalleRegContab()
                '  MsgBox("3")
                Me.GrabarAsientos()
                ' MsgBox("4")
                Me.CuadrarAsientos()
                'Me.eliminarCuentaCorriente()
                '  MsgBox("5")
                Me.GrabarCuentaCorriente()
                MsgBox("Registro Compra modificado correctamente", MsgBoxStyle.Information)
                Me.Close()

            Case 2
                'eliminar cabecera
                rc.eliminarRegContabFis(ent)
                rcd.eliminarRegContabDeta(ent)
                Me.eliminarCuentaCorriente()
                'Eliminamos el detalle antiguo

                MsgBox("Registro Compra Eliminado correctamente", MsgBoxStyle.Information)
                Me.Close()

            Case 5
                'Igv
                'Igv
                ent.IgvPar = parEn.IgvPar
                ent.EstadoRegistro = "0" 'normal

                rc.nuevoRegContabCabe(ent)
                Me.GrabarCuentaCorriente()
                'eliminamos el detalle 
                'rcd.eliminarRegContabDeta(ent)
                Me.GrabarDetalleRegContab()
                Me.GrabarAsientos()
                Me.CuadrarAsientos()

                MsgBox("Registro Compra ingresado correctamente " + Chr(13) + "Numero de Voucher Generado:" + ent.NumeroVoucherRegContabCabe, MsgBoxStyle.Information)
                'Limpiar la grilla

                Me.Close()

        End Select
        '/Actualizar y buscar el registro grabado
        Me.wRc.ActualizarVentana()
        ent.ClaveRegContabCabe = ent.CodigoEmpresa + ent.PeriodoRegContabCabe + ent.CodigoOrigen + ent.CodigoFile + ent.NumeroVoucherRegContabCabe
        Dgv.obtenerCursorActual(Me.wRc.DgvRcom, ent.ClaveRegContabCabe, Me.wRc.lista)
        '\\
    End Sub

    Function EsNumeroVoucherCorrecto() As Boolean
        Dim aut As New SuperEntidad
        aut.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        aut.AnoVoucher = Me.TxtPeri.Text.Trim.Substring(0, 4)
        aut.CodigoMes = Me.TxtPeri.Text.Trim.Substring(4, 2)
        aut.CodigoFile = Me.txtCodFil.Text.Trim
        ent.NumeroVoucherRegContabCabe = vou.obtenerVoucherAutogenerado(aut)

        Dim RccRN As New RegContabCabeRN
        Dim RccEN As New SuperEntidad
        RccEN.ClaveRegContabCabe += Me.TxtCodEmp.Text.Trim
        RccEN.ClaveRegContabCabe += Me.TxtPeri.Text.Trim
        RccEN.ClaveRegContabCabe += Me.txtCodOri.Text.Trim
        RccEN.ClaveRegContabCabe += Me.txtCodFil.Text.Trim
        RccEN.ClaveRegContabCabe += ent.NumeroVoucherRegContabCabe
        RccEN = RccRN.buscarRegContabExisPorClave(RccEN)
        If RccEN.ClaveRegContabCabe = "" Then
            Return True
        Else
            MsgBox("El correlativo " + ent.NumeroVoucherRegContabCabe + " Ya Existe", MsgBoxStyle.Information, "Compras")
            Return False
        End If

    End Function

    Sub CuadrarAsientos()
        Dim sumadebe As Decimal = 0
        Dim sumahaber As Decimal = 0
        Dim iRcd As New SuperEntidad
        iRcd.ClaveRegContabCabe = ent.ClaveRegContabCabe
        Dim iLisRcd As New List(Of SuperEntidad)
        iLisRcd = rcd.obtenerDetalleRegContabPorClave(iRcd)
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
                    rcd.EliminarRegistroDetalleXClaveDetalle(xobj)
                    rcd.nuevoRegContabDeta(xobj)
                    Exit For
                End If
            Else
                If xobj.DebeHaberRegContabDeta = "Debe" Then
                    xobj.ImporteSRegContabDeta += Math.Abs(iDif)
                    rcd.EliminarRegistroDetalleXClaveDetalle(xobj)
                    rcd.nuevoRegContabDeta(xobj)
                    Exit For
                End If
            End If
        Next
    End Sub

    Sub GrabarCuentaCorriente()
        Dim iCuCoEN As New SuperEntidad
        'ANTES DE GRABAR LA CUENTA CORRIENTE DEBEMOS SABER
        'SI ES UNA NOTA DE CREDITO
        If Me.txtCodFil.Text.Trim = "407" Then
            'ES UNA NOTA DE CREDITO POR LO TANTO VA A REBAJAR EL MONTO DEL 
            'DOCUMENTO A APLICAR
            'TRAER EL DOCUMENTO APLICADO QUE SE ENCUENTRA EN LA CUENTA CORRIENTE
            iCuCoEN.ClaveDocumentoCuentaCorriente += Me.TxtCodEmp.Text.Trim
            iCuCoEN.ClaveDocumentoCuentaCorriente += Me.txtCodAux.Text.Trim
            iCuCoEN.ClaveDocumentoCuentaCorriente += Me.TxtDoc1.Text.Trim
            iCuCoEN.ClaveDocumentoCuentaCorriente += Me.TxtSer1.Text.Trim
            iCuCoEN.ClaveDocumentoCuentaCorriente += Me.TxtNum1.Text.Trim
            iCuCoEN = ccte.buscarCuentaCorrienteExisPorClaveDoc(iCuCoEN)

            If iCuCoEN.ClaveCuentaCorriente <> "" Then
                If iCuCoEN.CodigoCuentaPcge = Me.TxtCuenta.Text Then
                    Dim iImporteNota As Decimal = CType(Me.txtPv.Text, Decimal)
                    If iImporteNota > iCuCoEN.SaldoCuentaCorriente Then
                        iCuCoEN.ImporteOriginalCuentaCorriente -= iCuCoEN.SaldoCuentaCorriente

                        'guardando la nota que es mayor al saldo del documento
                        iCuCoEN.ClaveNotaCredito = Me.TxtCodEmp.Text.Trim
                        iCuCoEN.ClaveNotaCredito += Me.txtCodAux.Text.Trim
                        iCuCoEN.ClaveNotaCredito += Me.txtDoc.Text.Trim
                        iCuCoEN.ClaveNotaCredito += Me.txtSer.Text.Trim
                        iCuCoEN.ClaveNotaCredito += Me.txtNum.Text.Trim

                        iCuCoEN.ValorNotaCredito = iCuCoEN.SaldoCuentaCorriente
                        iCuCoEN.SaldoCuentaCorriente = 0
                    Else
                        iCuCoEN.ImporteOriginalCuentaCorriente -= iImporteNota
                        iCuCoEN.SaldoCuentaCorriente = iCuCoEN.ImporteOriginalCuentaCorriente - iCuCoEN.ImportePagadoCuentaCorriente
                    End If

                    'PREGUNTAR SI ESTE NUEVO IMPORTE ES IGUAL AL PAGADO ENTONCES QUIERE DECIR
                    'QUE ESTE DOCUEMNTO YA SE DEBE CANCELAR EN ESTA OPERACION
                    If iCuCoEN.SaldoCuentaCorriente = 0 Then
                        iCuCoEN.EstadoCuentaCorriente = "0" 'CANCELADO
                    Else
                        iCuCoEN.EstadoCuentaCorriente = "1" 'PENDIENTE
                    End If
                    ccte.modificarCuentaCorriente(iCuCoEN)
                End If
            End If

        Else
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
            ent.CodigoCuentaPcge = Me.TxtCuenta.Text.Trim
            ent.FechaVctoDocumento = Varios.AñoMesDia(Me.DtpFechaVcto.Value.Date)
            'moneda
            ent.MonedaDocumento = Rbt.radioActivo(Me.gbMoneda).Text.ToString.Trim()
            ent.ImporteOriginalCuentaCorriente = CType(Me.txtPv.Text, Decimal)
            ent.ImportePagadoCuentaCorriente = 0
            ent.SaldoCuentaCorriente = CType(Me.txtPv.Text, Decimal)
            ent.EstadoCuentaCorriente = "1" 'Pendiente de pago 
            ccte.nuevoCuentaCorriente(ent)
        End If

    End Sub

    Function EsDocumentoRegistrado() As Boolean
        Dim obj As New SuperEntidad
        obj.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        obj.CodigoAuxiliar = Me.txtCodAux.Text.Trim
        obj.TipoDocumento = Me.txtDoc.Text.Trim
        obj.SerieDocumento = Me.txtSer.Text.Trim
        obj.NumeroDocumento = Me.txtNum.Text.Trim
        If rc.BuscarRegContabCabeXDoc(obj).ClaveRegContabCabe <> "" Then
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
        obj = rc.BuscarRegContabCabeXDoc(obj)
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

        If obj.ClaveCuentaCorriente = "" Then
            Return False
        Else
            If obj.ImportePagadoCuentaCorriente <> 0 Then
                MsgBox("Documento ya tiene pagos no se puede realizar la operacion", MsgBoxStyle.Exclamation, "Compras")
                Return True
            Else
                'COMPARAR EL PRECIO VENTA DEL DOCUMENTO ACTUAL ANTES DE LA MODIFICACION
                'CON EL VALOR ORIGINAL EN CUENTA CORRIENTE, SI ESTOS NO COINCIDEN QUIERE
                'DECIR QUE SE LE APLICO UNA NOTA DE CREDITO A ESTE COMPROBANTE
                If ent.PrecioVtaRegContabCabe <> obj.ImporteOriginalCuentaCorriente Then
                    MsgBox("Este documento tiene nota de credito aplicados,no se puede realizar la operacion", MsgBoxStyle.Exclamation, "Compras")
                    Return True
                Else
                    Return False
                End If
            End If
        End If
    End Function

    Sub eliminarCuentaCorriente()
        'SOLO CUANDO SE MODIFICA O ELIMINA
        If Me.operacion = 1 Or Me.operacion = 2 Then
            Dim obj As New SuperEntidad
            Dim iCuCoEN As New SuperEntidad

            If ent.CodigoFile = "407" Then
                'TRAER EL DOCUMENTO APLICADO QUE SE ENCUENTRA EN LA CUENTA CORRIENTE
                'PARA DESCONTAR LO QUE SE REBAJO
                iCuCoEN.ClaveDocumentoCuentaCorriente += ent.CodigoEmpresa
                iCuCoEN.ClaveDocumentoCuentaCorriente += ent.CodigoAuxiliar
                iCuCoEN.ClaveDocumentoCuentaCorriente += ent.TipoDocumento1
                iCuCoEN.ClaveDocumentoCuentaCorriente += ent.SerieDocumento1
                iCuCoEN.ClaveDocumentoCuentaCorriente += ent.NumeroDocumento1
                iCuCoEN = ccte.buscarCuentaCorrienteExisPorClaveDoc(iCuCoEN)

                If iCuCoEN.ClaveCuentaCorriente <> "" Then
                    'VOLVER A SU IMPORTE NORMAL (PREGUNTAR SI LA NOTA FUE DE MAYOR VALOR QUE EL SALDO DEL DOCUMENTO)
                    If iCuCoEN.ClaveNotaCredito = Me.TxtCodEmp.Text + Me.txtCodAux.Text + Me.txtDoc.Text + Me.txtSer.Text + Me.txtNum.Text Then
                        If iCuCoEN.CodigoCuentaPcge = Me.TxtCuenta.Text Then
                            iCuCoEN.ImporteOriginalCuentaCorriente += iCuCoEN.ValorNotaCredito
                            iCuCoEN.SaldoCuentaCorriente = iCuCoEN.ValorNotaCredito
                            iCuCoEN.ClaveNotaCredito = ""
                            iCuCoEN.ValorNotaCredito = 0
                        End If
                    Else
                        iCuCoEN.ImporteOriginalCuentaCorriente += ent.PrecioVtaRegContabCabe
                        iCuCoEN.SaldoCuentaCorriente = iCuCoEN.ImporteOriginalCuentaCorriente - iCuCoEN.ImportePagadoCuentaCorriente
                    End If

                    'PREGUNTAR SI ESTE NUEVO IMPORTE ES IGUAL AL PAGADO ENTONCES QUIERE DECIR
                    'QUE ESTE DOCUEMNTO YA SE DEBE CANCELAR EN ESTA OPERACION
                    If iCuCoEN.SaldoCuentaCorriente = 0 Then
                        iCuCoEN.EstadoCuentaCorriente = "0" 'CANCELADO
                    Else
                        iCuCoEN.EstadoCuentaCorriente = "1" 'PENDIENTE
                    End If
                    ccte.modificarCuentaCorriente(iCuCoEN)
                End If
            Else
                obj.ClaveCuentaCorriente = ent.ClaveRegContabCabe
                ccte.eliminarCuentaCorrienteFis(obj)
            End If

        End If
    End Sub

    Function EsDocumentoReferenciaExistente() As Boolean
        'CUANDO NO SEA NOTA DE CREDITO DEVUELVE TRUE
        If Me.txtCodFil.Text.Trim <> "407" Then
            Return True
        Else
            'A QUI ES UNA NOTA DE CREDITO VER SI EXISTE EN LA COMPRA
            Dim obj As New SuperEntidad
            obj.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
            obj.CodigoAuxiliar = Me.txtCodAux.Text.Trim
            obj.TipoDocumento = Me.TxtDoc1.Text.Trim
            obj.SerieDocumento = Me.TxtSer1.Text.Trim
            obj.NumeroDocumento = Me.TxtNum1.Text.Trim
            obj.PrecioVtaRegContabCabe = CType(Me.txtPv.Text, Decimal)
            obj = ccte.EsDocumentoReferenciaRegistrado(obj)
            If obj.EsVerdad = False Then
                MsgBox(obj.Mensaje, MsgBoxStyle.Exclamation, "Documento referencia")
                Me.TxtNum1.Focus()
                Return False
            Else
                Return True
            End If

        End If
    End Function


#End Region


    Private Sub WEditarPptoInterno_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Me.Text = "Eliminar Registro Compra" Then
            If Me.EsDocumentoPagado = True Then Exit Sub
            Me.Aceptar()
            Exit Sub
        End If

        If acc.CamposObligatorios = False Then
            Exit Sub
        Else

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

                    If Me.EsDocumentoReferenciaExistente = False Then Exit Sub

                    If Me.EsDocumentoPagado = True Then Exit Sub

                    Me.eliminarCuentaCorriente()

                    If Me.operacion = 0 Or Me.operacion = 5 Then
                        'Validadando el correlativo del voucher solo si es nuevo
                        If Me.EsNumeroVoucherCorrecto = False Then Exit Sub
                    End If
                    Me.Aceptar()
                    ent.ClaveRegContabCabe = ""  '' Para mas de un documento del proveedor
                    Me.txtDistr.Text = "0.00"

                Case Is > 0
                    MsgBox("La suma de los importes en el detalle es menor que el importe total en soles")
            End Select

        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If Me.Text = "Visualizar Registro Compra" Then
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
    End Sub

#Region "Mostrar formulario lista"
    Private Sub txtCodFil_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodFil.KeyDown
        If Me.txtCodFil.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListaFiles
                win.titulo = "Files"
                win.CondicionLista = "ListarFilesXOrigen"
                win.ent.CodigoFile = "4"
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
                'win.wEditRegCom = Me
                'Me.AddOwnedForm(win)
                win.tabla = "Proveedor/ClienteProveedorActivos"
                win.titulo = "AUXILIARES"
                win.txt1 = Me.txtCodAux
                win.txt2 = Me.txtNomAux
                win.ctrlFoco = Me.gbModo
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

    Private Sub txtCodDoc1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDoc1.KeyDown
        If Me.TxtDoc1.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarTabla
                win.tabla = "Documento"
                win.titulo = "Documentos"
                win.txt1 = Me.TxtDoc1
                win.txt2 = Me.TxtNomDoc1
                win.ctrlFoco = Me.TxtSer1
                win.NuevaVentana()
            End If
        End If


    End Sub

    Private Sub txtCuenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCuenta.KeyDown
        If Me.TxtCuenta.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarPlanCuentaGe
                win.tabla = "CuentasAnaliticas4247"    ''va la condicion del case
                win.titulo = "Cuentas"
                win.txt1 = Me.TxtCuenta
                win.txt2 = Me.TxtNombreCuenta
                win.ctrlFoco = Me.btnAgregar
                win.NuevaVentana()
            End If
        End If
    End Sub

#End Region

#Region "Buscar por codigo"
    Private Sub txtCodFil_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodFil.Validating
        If Me.operacion = 0 Or Me.operacion = 4 Or Me.operacion = 5 Then
            If Me.txtCodFil.Text.Trim <> "" Then
                Dim codOri As String = Me.txtCodFil.Text.Trim.Substring(0, 1)
                If codOri = "4" Then
                    Dim ope As New OperaWin : ope.txt1 = Me.txtCodFil : ope.txt2 = Me.txtNomFil
                    ope.MostrarCodigoDescripcionDeFile("Files", e)
                    Me.HabilitarControlesSegunFile407()
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
        If Me.operacion = 0 Or Me.operacion = 1 Or Me.operacion = 4 Or Me.operacion = 5 Then
            Dim ope As New OperaWin : ope.txt1 = Me.txtCodAux : ope.txt2 = Me.txtNomAux
            ope.MostrarCodigoDescripcionDeAuxiliar("Proveedor/ClienteProveedorActivo", "AUXILIARES", e)
        End If
    End Sub

    Private Sub txtDoc_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDoc.Validating
        If Me.Text = "Agregar Registro Compra" Or Me.Text = "Modificar Registro Compra" Or Me.Text = "Agregar Manual Registro Compra" Or Me.operacion = 5 Then
            Dim ope As New OperaWin : ope.txt1 = Me.txtDoc : ope.txt2 = Me.txtNomDoc
            ope.MostrarCodigoDescripcionDeTabla("Doc", "Documento", e)
        End If

    End Sub

    Private Sub txtDoc1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtDoc1.Validating
        If Me.Text = "Agregar Registro Compra" Or Me.Text = "Modificar Registro Compra" Or Me.Text = "Agregar Manual Registro Compra" Or Me.operacion = 5 Then
            Dim ope As New OperaWin : ope.txt1 = Me.TxtDoc1 : ope.txt2 = Me.TxtNomDoc1
            ope.MostrarCodigoDescripcionDeTabla("Doc", "Documento", e)
        End If

    End Sub

    Private Sub txtCuenta_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCuenta.Validating

        Dim ope As New OperaWin : ope.txt1 = Me.TxtCuenta : ope.txt2 = Me.TxtNombreCuenta
        ope.Condicion = "CuentasAnaliticas42A47"
        ope.MostrarCodigoDescripcionDePlancuentas("CuentasAnaliticas 42,43 o 47", e)

    End Sub

#End Region

#Region "Calculos"

    Sub ImportesSolesDolares()
        If Me.txtEx.Text <> "" Then
            'OBTENER EL VALOR DE EXONERADO
            Dim iExo As Decimal = CType(Me.txtEx.Text.Trim, Decimal)
            'SI ES NEGATIVO SOLO SE DISTRIBUYE EL VALOR VENTA

            'VER SI APLICA IGV
            If Me.ckbAplIgv.Checked = True Then
                If iExo < 0 Then
                    Me.txtDistr.Text = Varios.numeroConDosDecimal((CType(Me.txtVv.Text.Trim, Decimal)).ToString)
                Else
                    Me.txtDistr.Text = Varios.numeroConDosDecimal((CType(Me.txtVv.Text.Trim, Decimal) + CType(Me.txtEx.Text.Trim, Decimal)).ToString)
                End If
            Else
                If iExo < 0 Then
                    Me.txtDistr.Text = Varios.numeroConDosDecimal((CType(Me.txtVv.Text.Trim, Decimal) + CType(Me.txtIgv.Text.Trim, Decimal)).ToString)
                Else
                    Me.txtDistr.Text = Varios.numeroConDosDecimal((CType(Me.txtVv.Text.Trim, Decimal) + CType(Me.txtEx.Text.Trim, Decimal) + CType(Me.txtIgv.Text.Trim, Decimal)).ToString)
                End If

            End If


            'Cambiar txtVv por txtDistr

            Dim str As String = Rbt.radioActivo(Me.gbMoneda).Text.ToString.Trim()
            Select Case str
                Case "US$"
                    Me.txtImpTotSol.Text = Varios.numeroConDosDecimal((CType(Me.txtDistr.Text, Decimal) * CType(Me.txtTipCam.Text, Decimal)).ToString)
                    Me.txtImpTotDol.Text = Me.txtDistr.Text
                    Me.txtSalImpTotSol.Text = Varios.numeroConDosDecimal((CType(Me.txtImpTotSol.Text, Decimal) - Me.sumaImportes).ToString)
                    Me.LblImpMon.Text = "Importe Total US$"
                Case "S/."
                    Me.txtImpTotSol.Text = Me.txtDistr.Text
                    Me.txtImpTotDol.Text = Varios.numeroConDosDecimal((CType(Me.txtDistr.Text, Decimal) / CType(Me.txtTipCam.Text, Decimal)).ToString)
                    Me.txtSalImpTotSol.Text = Varios.numeroConDosDecimal((CType(Me.txtImpTotSol.Text, Decimal) - Me.sumaImportes).ToString)
                    Me.LblImpMon.Text = "Importe Total s/."
                Case "CAD"
                    Me.txtImpTotSol.Text = Varios.numeroConDosDecimal((CType(Me.txtDistr.Text, Decimal) * CType(Me.TxtTipCam1.Text, Decimal)).ToString)
                    Me.txtImpTotDol.Text = Me.txtDistr.Text
                    Me.txtSalImpTotSol.Text = Varios.numeroConDosDecimal((CType(Me.txtImpTotSol.Text, Decimal) - Me.sumaImportes).ToString)
                    Me.LblImpMon.Text = "Importe Total EUR"
            End Select
        End If

        If Me.operacion = 2 Or Me.operacion = 3 Then
            Me.txtSalImpTotSol.Text = "0.00"
        End If

    End Sub

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
                    If Me.operacion = 0 Then
                        Me.dtpFecha.Text = Me.txtFecVau.Text
                    End If

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

        If Me.txtDoc.Text.Trim = "03" Then
            Me.txtEx.ReadOnly = True
            Me.txtEx.Text = Me.txtPv.Text.Trim
        Else
            Me.txtEx.ReadOnly = False
            '  Me.txtEx.Text = "0.00"
        End If

        Dim vIgv As Decimal = 0
        If Me.Text = "Agregar Registro Compra" Or Me.Text = "Agregar Manual Registro Compra" Or Me.operacion = 5 Then
            vIgv = parEn.IgvPar
        Else
            vIgv = ent.IgvPar
        End If
        Me.txtIgv.Text = Varios.CalcularIgvCompras(Me.txtPv.Text, Me.txtEx.Text, vIgv)
        Me.txtVv.Text = Varios.CalcularValorVentaCompra(Me.txtPv.Text, Me.txtEx.Text, Me.txtIgv.Text)
        'calculo distribuir
        Me.txtDistr.Text = Varios.numeroConDosDecimal((CType(Me.txtVv.Text.Trim, Decimal) + CType(Me.txtEx.Text.Trim, Decimal)).ToString)
        Me.ImportesSolesDolares()
    End Sub

    Private Sub txtPv_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPv.Validated

        If Me.txtDoc.Text.Trim = "03" Then
            Me.txtEx.Text = Me.txtPv.Text.Trim
        End If
        Dim vIgv As Decimal = 0
        If Me.Text = "Agregar Registro Compra" Or Me.Text = "Agregar Manual Registro Compra" Or Me.operacion = 5 Then
            vIgv = parEn.IgvPar
        Else
            vIgv = ent.IgvPar
        End If
        Me.txtIgv.Text = Varios.CalcularIgvCompras(Me.txtPv.Text, Me.txtEx.Text, vIgv)
        Me.txtVv.Text = Varios.CalcularValorVentaCompra(Me.txtPv.Text, Me.txtEx.Text, Me.txtIgv.Text)
        'calculo distribuir
        Me.txtDistr.Text = Varios.numeroConDosDecimal((CType(Me.txtVv.Text.Trim, Decimal) + CType(Me.txtEx.Text.Trim, Decimal)).ToString)
        Me.ImportesSolesDolares()
    End Sub


    Private Sub txtEx_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEx.Validated
        Dim vIgv As Decimal = 0
        If Me.Text = "Agregar Registro Compra" Or Me.Text = "Agregar Manual Registro Compra" Or Me.operacion = 5 Then
            vIgv = parEn.IgvPar
        Else
            vIgv = ent.IgvPar
        End If
        Me.txtIgv.Text = Varios.CalcularIgvCompras(Me.txtPv.Text, Me.txtEx.Text, vIgv)
        Me.txtVv.Text = Varios.CalcularValorVentaCompra(Me.txtPv.Text, Me.txtEx.Text, Me.txtIgv.Text)
        'calculo distribuir
        Me.txtDistr.Text = Varios.numeroConDosDecimal((CType(Me.txtVv.Text.Trim, Decimal) + CType(Me.txtEx.Text.Trim, Decimal)).ToString)
        Me.ImportesSolesDolares()
    End Sub


    Sub HabilitarControlesSegunDetraccion()
        '/
        Dim detra As String = Rbt.radioActivo(Me.gbMovi).Text
        'Habilitar los campos calculados segun la detraccion
        Select Case detra
            Case "Si"
                Me.txtNumPape.Enabled = True
                Me.dtpFecDetra.Enabled = True
            Case "No"
                Me.txtNumPape.Enabled = False
                Me.txtNumPape.Text = ""
                Me.dtpFecDetra.Enabled = False
        End Select
        '/
    End Sub

    Sub HabilitarControlesSegunFile407()
        '/
        Dim cf As String = Me.txtCodFil.Text.Trim
        'Habilitar los campos segun radiobutton 
        If cf = "407" Or cf = "408" Then
            Me.TxtDoc1.Enabled = True
            Me.TxtSer1.Enabled = True
            Me.TxtNum1.Enabled = True
            Me.DtpFecha1.Enabled = True

        Else
            Me.TxtDoc1.Enabled = False
            Me.TxtSer1.Enabled = False
            Me.TxtNum1.Enabled = False
            Me.TxtDoc1.Text = ""
            Me.TxtNomDoc1.Text = ""
            Me.TxtSer1.Text = ""
            Me.TxtNum1.Text = ""
            Me.DtpFecha1.Enabled = False
        End If
        '/
    End Sub



#End Region

#Region "Para Items"
    Sub NuevoItem()
        Dim win1 As New WDetalleRegCompras
        'win1.concepto = Me.concepto
        'win1.titulo = Me.titulo
        win1.wRegCom = Me
        Me.AddOwnedForm(win1)
        win1.NuevaVentana()
    End Sub

    Sub ModificarItem()
        Dim win1 As New WDetalleRegCompras
        ' win1.concepto = Me.concepto
        ' win1.titulo = Me.titulo
        win1.wRegCom = Me
        Me.AddOwnedForm(win1)
        win1.ModificarVentana()
    End Sub

    Sub EliminarItem()
        Dim win1 As New WDetalleRegCompras
        'win1.concepto = Me.concepto
        'win1.titulo = Me.titulo
        win1.wRegCom = Me
        Me.AddOwnedForm(win1)
        win1.EliminaVentana()

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


    Function ObtenerMayorCentroCosto() As String
        Dim icc As String = ""
        Dim icc1 As String = ""
        Dim imonto As Decimal = 0
        Dim imonto1 As Decimal = 0
        'Si la grilla esta en blanco
        If Me.dgvRegCom.Rows.Count = 1 Then
            Return ""
        End If

        For n As Integer = 0 To Me.dgvRegCom.Rows.Count - 2
            icc = Me.dgvRegCom.Item("Column3", n).Value.ToString
            imonto = CType(Me.dgvRegCom.Item("IMPORTES", n).Value, Decimal)
            If icc <> "" Then
                If imonto >= imonto1 Then
                    icc1 = icc
                    imonto1 = imonto
                End If
            End If
        Next
        Return icc1
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

    Private Sub rbtSol_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles rbtSol.Validating, RbtEur.Validating
        Me.ImportesSolesDolares()
    End Sub

    Private Sub rbtDol_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles rbtDol.Validating
        Me.ImportesSolesDolares()
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

    Private Sub CambiarDetraccion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtMoSi.CheckedChanged, rbtMoNo.CheckedChanged
        If Me.Text = "Agregar Registro Compra" Or Me.Text = "Modificar Registro Compra" Or Me.Text = "Agregar Manual Registro Compra" Or Me.operacion = 5 Then
            Me.HabilitarControlesSegunDetraccion()
        End If
    End Sub

    Private Sub txtSer_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSer.Validated, txtCodAux.Validated, txtNum.Validated, txtDoc.Validated
        If Me.txtCodAux.Text.Trim = "" Then Exit Sub

        If Me.operacion = 0 Or Me.operacion = 5 Then
            If Me.EsDocumentoRegistrado() = True Then Exit Sub
        Else
            If Me.EsDocumentoRegistradoEnOtroRegistroC() = True Then Exit Sub
        End If

    End Sub

    Private Sub ckbAplIgv_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckbAplIgv.Click
        Me.ImportesSolesDolares()
    End Sub

    Private Sub DtpFecha1_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DtpFecha1.Validating
        Me.TraerTipoCambio()
        Me.ImportesSolesDolares()
    End Sub

    Private Sub RbtSol1_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles RbtSol1.Validating, RbtDol1.Validating
        'Me.TraerTipoCambio()
        'Me.ImportesSolesDolares()
    End Sub

    Private Sub btnAceptar_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles btnAceptar.DragEnter

    End Sub
End Class