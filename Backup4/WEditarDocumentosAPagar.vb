Imports Entidad
Imports Negocio
Public Class WEditarDocumentosAPagar

#Region "Propietarios"
    Public wCtaCte1 As New WDocumentosAPagar
#End Region

    Public ent, ParEn, ticEn, entD As New SuperEntidad
    Public lista As New List(Of SuperEntidad)
    Public tab As New TablaRN
    Public emp As New EmpresaRN
    Public par As New ParametroRN
    Public rcbd As New RegContabDetaRN
    Public tic As New TipoCambioRN
    Public rc As New RegContabCabeRN
    Public rd As New RegContabDetaRN
    Public cc As New CuentaCorrienteRN
    Public vou As New VoucherRN
    Public cam As New CamposEntidad
    Public acc As New Accion
    Public operacion As Integer  '0=agregar , 1=modificar , 2=eliminar , 3=visualizar
    Public PeriodoActual As String
    Public UltimoCorrelativo As Integer = 0
    Public ImporteCuadradoSoles As Decimal = 0

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
        ParEn = par.buscarParametroExis(ParEn)
        Me.Show()
    End Sub

    Sub PorDefecto()
        'CARGAMOS LA GRILLA CON LOS DOCUMENTOS CHEQUEADOS
        'EN LA OTRA PANTALLA
        Me.CargarDocumentos()

        Me.TxtCodEmp.Text = Me.wCtaCte1.TxtCodEmp.Text
        Me.txtNomEmp.Text = Me.wCtaCte1.txtNomEmp.Text
        Me.txtPeri.Text = Me.wCtaCte1.txtPeri.Text
        Me.txtCodOri.Text = Me.wCtaCte1.txtCodOri.Text
        Me.txtNomOri.Text = Me.wCtaCte1.txtNomOri.Text
        Me.txtCodFil.Text = Me.wCtaCte1.txtCodFil.Text
        Me.txtNomFil.Text = Me.wCtaCte1.txtNomFil.Text
        Me.txtDia.Text = Me.wCtaCte1.txtDia.Text
        Me.txtFecVau.Text = Me.wCtaCte1.txtFecVau.Text
        Me.txtTipCam.Text = Me.wCtaCte1.txtTipCam.Text
        Me.TxtTipCam1.Text = Me.wCtaCte1.TxtTipCam1.Text
        Me.txtDolEur.Text = Me.wCtaCte1.txtDolEur.Text
        Me.TxtMontoAPagar.Text = Varios.numeroConDosDecimal(Dgv.SumarColumna(Me.DgvDocPen, cam.MonMon, "").ToString)
        Me.txtCodAux.Text = Me.wCtaCte1.txtCodAux.Text
        Me.txtNomAux.Text = Me.wCtaCte1.txtNomAux.Text
        Me.TxtMoneda.Text = Rbt.radioActivo(Me.wCtaCte1.gbMoneda).Text
        Me.TxtImporte.Text = Me.TxtMontoAPagar.Text
        Me.TxtGirado.Text = Me.txtNomAux.Text

        Me.ValidarImporte()
    End Sub

    Sub ventanaAdicionar()
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Agregar Registro CajaBanco"
        'poner valores defecto en montos
        acc.LimpiarControles()
        'por defecto
        acc.Nuevo()
        Me.PorDefecto()
        '\\
    End Sub

    Sub CargarDocumentos()

        Dgv.refrescarFuenteDatosGrilla(Me.DgvDocPen, Me.wCtaCte1.Lista1)
        '/Creando las columnas

        Dgv.asignarColumnaText(Me.DgvDocPen, cam.CodAux, "RUC", 90)
        Dgv.asignarColumnaText(Me.DgvDocPen, cam.DesAux, "Razon Social", 200)
        Dgv.asignarColumnaText(Me.DgvDocPen, cam.CodTipDoc, "TD", 40)
        Dgv.asignarColumnaText(Me.DgvDocPen, cam.NomTipDoc, "Nombre", 70)
        Dgv.asignarColumnaText(Me.DgvDocPen, cam.SerDoC, "Serie", 40)
        Dgv.asignarColumnaText(Me.DgvDocPen, cam.NumDoc, "Numero", 100)
        Dgv.asignarColumnaText(Me.DgvDocPen, cam.FecDoc, "Fecha", 80)
        Dgv.asignarColumnaText(Me.DgvDocPen, cam.MonDoc, "Moneda", 50)
        Dgv.AsignarColumnaTextNumerico(Me.DgvDocPen, cam.SalCtaCte, "Saldo", 100, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvDocPen, cam.ImpSolRCC, "Saldo S/", 120, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvDocPen, cam.VenTipCam, "TC US$", 120, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvDocPen, cam.VenEurTipCam, "TC EUR", 120, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvDocPen, cam.MonMon, "Monto moneda", 120, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvDocPen, cam.MonSol, "Monto soles", 120, 2)
        Dgv.asignarColumnaText(Me.DgvDocPen, cam.ClaveCtaCte, "Clave", 150)

    End Sub

#End Region

    Private Sub WEditarPptoInterno_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

#Region "Mostrar formulario lista"

    Private Sub txtModo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtModo.KeyDown
        If Me.txtModo.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarTabla
                win.tabla = "ModoPago"
                win.titulo = "Modo de Pago"
                win.txt1 = Me.txtModo
                win.txt2 = Me.txtNomMod
                win.ctrlFoco = Me.txtdoc
                win.NuevaVentana()
            End If
        End If

    End Sub

    Private Sub txtDoc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtdoc.KeyDown
        If Me.txtdoc.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarTabla
                win.tabla = "Documento"
                win.titulo = "Documentos"
                win.txt1 = Me.txtdoc
                win.txt2 = Me.TxtNomDoc
                win.ctrlFoco = Me.TxtNum
                win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub txtCodBc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodCb.KeyDown
        If Me.TxtCodCb.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarCuentaBanco
                win.tabla = "PorEmpresaYMoneda"
                win.titulo = "Cuentas Bancos"
                win.ent.MonedaCuentaBanco = Me.TxtMoneda.Text  ''Moneda de pantalla
                win.txt1 = Me.TxtCodCb
                win.txt2 = Me.TxtNumCb
                win.txt3 = Me.TxtMonCb
                win.ctrlFoco = Me.TxtGirado
                win.NuevaVentana()
            End If
        End If
    End Sub

#End Region

#Region "Buscar por codigo"

    Private Sub txtModo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtModo.Validating
        If Me.operacion = 0 Or Me.operacion = 1 Or Me.operacion = 4 Then
            Dim ope As New OperaWin : ope.txt1 = Me.txtModo : ope.txt2 = Me.txtNomMod
            ope.MostrarCodigoDescripcionDeTabla("Mod", "Modo de Pago", e)
        End If

    End Sub

    Private Sub txtDoc_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtdoc.Validating
        If Me.operacion = 0 Or Me.operacion = 1 Or Me.operacion = 4 Then
            Dim ope As New OperaWin : ope.txt1 = Me.txtdoc : ope.txt2 = Me.TxtNomDoc
            ope.MostrarCodigoDescripcionDeTabla("Doc", "Documento", e)
        End If

    End Sub

    Private Sub txtCodcb_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodCb.Validating
        If Me.operacion = 0 Or Me.operacion = 1 Or Me.operacion = 4 Then
            Dim ope As New OperaWin : ope.txt1 = Me.TxtCodCb : ope.txt2 = Me.TxtNumCb : ope.txt3 = Me.TxtMonCb
            ope.MostrarCodigoDescripcionDeCuentaBanco("PorEmpresaYMoneda", e)
        End If
    End Sub
#End Region

    Sub GrabarDetalleRegContab()
        'SI HAY UN SOLO DETALLE
        If Me.wCtaCte1.Lista1.Count = 1 Then
            For Each xob As SuperEntidad In Me.wCtaCte1.Lista1
                entD.ClaveRegContabCabe = ent.ClaveRegContabCabe
                entD.CorrelativoRegContabDeta = (1).ToString.PadLeft(4, CType("0", Char))
                entD.CodigoAuxiliar = xob.CodigoAuxiliar
                entD.TipoDocumento = xob.TipoDocumento
                entD.SerieDocumento = xob.SerieDocumento
                entD.NumeroDocumento = xob.NumeroDocumento
                entD.FechaDocumento = xob.FechaDocumento
                entD.VentaTipoCambio = xob.VentaTipoCambio
                entD.VentaEurTipoCambio = xob.VentaEurTipoCambio
                entD.CodigoCuentaPcge = xob.CodigoCuentaPcge
                entD.CodigoCentroCosto = ""
                entD.DebeHaberRegContabDeta = "Debe"
                Select Case xob.MonedaDocumento
                    Case "S/."
                        entD.ImporteSRegContabDeta = xob.ImporteSolRegContabCabe 'CONTIENE EL IMPORTE EN SOLES DEL DOCUMENTO
                        entD.ImporteDRegContabDeta = xob.SaldoCuentaCorriente / xob.VentaTipoCambio
                        entD.ImporteERegContabDeta = xob.SaldoCuentaCorriente / xob.VentaEurTipoCambio
                    Case "US$"
                        entD.ImporteSRegContabDeta = xob.ImporteSolRegContabCabe
                        entD.ImporteDRegContabDeta = xob.SaldoCuentaCorriente
                        entD.ImporteERegContabDeta = 1
                    Case "EUR"
                        entD.ImporteSRegContabDeta = xob.ImporteSolRegContabCabe
                        entD.ImporteDRegContabDeta = 1
                        entD.ImporteERegContabDeta = xob.SaldoCuentaCorriente
                End Select
                entD.GlosaRegContabDeta = Me.TxtConcepto.Text.Trim
                entD.Cuenta1242 = ""
                entD.CodigoArea = ""
                entD.CodigoFlujoCaja = ""
                entD.CodigoIngEgr = ""
                entD.EstadoRegContabDeta = ""
                entD.ImporteRegContabCabe = 0
                entD.MontoMoneda = Dgv.SumarColumna(Me.DgvDocPen, cam.MonMon, "")
                entD.MontoSoles = Dgv.SumarColumna(Me.DgvDocPen, cam.MonSol, "")
                rd.nuevoRegContabDeta(entD)
            Next
        Else
            'SI HAY MAS DE UN DETALLE
            Dim n As Integer = 0
            For Each xob As SuperEntidad In Me.wCtaCte1.Lista1
                entD.ClaveRegContabCabe = ent.ClaveRegContabCabe
                entD.CorrelativoRegContabDeta = (n + 1).ToString.PadLeft(4, CType("0", Char))
                entD.CodigoAuxiliar = xob.CodigoAuxiliar
                entD.TipoDocumento = xob.TipoDocumento
                entD.SerieDocumento = xob.SerieDocumento
                entD.NumeroDocumento = xob.NumeroDocumento
                entD.FechaDocumento = xob.FechaDocumento
                entD.VentaTipoCambio = xob.VentaTipoCambio
                entD.VentaEurTipoCambio = xob.VentaEurTipoCambio
                entD.CodigoCuentaPcge = xob.CodigoCuentaPcge
                entD.CodigoCentroCosto = ""
                entD.DebeHaberRegContabDeta = "Debe"
                Select Case xob.MonedaDocumento
                    Case "S/."
                        entD.ImporteSRegContabDeta = xob.ImporteSolRegContabCabe 'CONTIENE EL IMPORTE EN SOLES DEL DOCUMENTO
                        entD.ImporteDRegContabDeta = xob.SaldoCuentaCorriente / xob.VentaTipoCambio
                        entD.ImporteERegContabDeta = xob.SaldoCuentaCorriente / xob.VentaEurTipoCambio
                    Case "US$"
                        entD.ImporteSRegContabDeta = xob.ImporteSolRegContabCabe
                        entD.ImporteDRegContabDeta = xob.SaldoCuentaCorriente
                        entD.ImporteERegContabDeta = 1
                    Case "EUR"
                        entD.ImporteSRegContabDeta = xob.ImporteSolRegContabCabe
                        entD.ImporteDRegContabDeta = 1
                        entD.ImporteERegContabDeta = xob.SaldoCuentaCorriente
                End Select
                entD.GlosaRegContabDeta = Me.TxtConcepto.Text.Trim
                entD.Cuenta1242 = ""
                entD.CodigoIngEgr = ""
                entD.CodigoArea = ""
                entD.CodigoFlujoCaja = ""
                entD.EstadoRegContabDeta = ""
                entD.ImporteRegContabCabe = 0
                entD.MontoMoneda = xob.MontoMoneda
                entD.MontoSoles = xob.MontoSoles
                rd.nuevoRegContabDeta(entD)
                n += 1
            Next
        End If
    End Sub


    Sub GrabarCuenta10EnDetalle()
        Dim ent10 As New SuperEntidad
        ent10.ClaveRegContabCabe = ent.ClaveRegContabCabe
        ent10.CorrelativoRegContabDeta = (Me.wCtaCte1.Lista1.Count + 1).ToString.PadLeft(4, CType("0", Char))
        ent10.CodigoAuxiliar = ""
        ent10.TipoDocumento = Me.txtdoc.Text.Trim
        ent10.SerieDocumento = ""
        ent10.NumeroDocumento = Me.TxtNum.Text.Trim
        ent10.FechaDocumento = CType(Me.txtFecVau.Text.Trim, Date)
        ent10.VentaTipoCambio = CType(Me.txtTipCam.Text, Decimal)
        ent10.VentaEurTipoCambio = CType(Me.TxtTipCam1.Text, Decimal)
        ent10.CodigoCuentaPcge = Me.TxtCodCb.Text.Trim
        ent10.CodigoCentroCosto = ""
        ent10.DebeHaberRegContabDeta = "Haber"

        Dim iImporteCb As Decimal = CType(Me.TxtImporte.Text, Decimal)
        Dim iMontoSoles As Decimal = Dgv.SumarColumna(Me.DgvDocPen, cam.MonSol, "")
        

        Select Case Me.TxtMoneda.Text
            Case "S/."
                ent10.ImporteSRegContabDeta = iMontoSoles
                ent10.ImporteDRegContabDeta = iImporteCb / CType(Me.txtTipCam.Text, Decimal)
                ent10.ImporteERegContabDeta = iImporteCb / CType(Me.TxtTipCam1.Text, Decimal)
            Case "US$"
                ent10.ImporteSRegContabDeta = iMontoSoles
                ent10.ImporteDRegContabDeta = iImporteCb
                ent10.ImporteERegContabDeta = 1
            Case "EUR"
                ent10.ImporteSRegContabDeta = iMontoSoles
                ent10.ImporteDRegContabDeta = 1
                ent10.ImporteERegContabDeta = iImporteCb
        End Select
        ent10.GlosaRegContabDeta = Me.TxtConcepto.Text.Trim
        ent10.Cuenta1242 = ""
        ent10.CodigoIngEgr = ""
        ent10.CodigoArea = ""
        ent10.CodigoFlujoCaja = Me.TxtCodFluCaj.Text.Trim
        ent10.EstadoRegContabDeta = ""
        ent10.ImporteRegContabCabe = 0
        rd.nuevoRegContabDeta(ent10)
    End Sub


    Sub GrabarCabecera()
        ent.PeriodoRegContabCabe = Me.txtPeri.Text
        ent.CodigoEmpresa = Me.TxtCodEmp.Text
        ent.CodigoOrigen = Me.txtCodOri.Text
        ent.CodigoFile = Me.txtCodFil.Text
        ent.NumeroVoucherRegContabCabe = Me.txtNumVau.Text
        ent.DiaVoucherRegContabCabe = Me.txtDia.Text
        ent.FechaVoucherRegContabCabe = CType(Me.txtFecVau.Text, Date)
        ent.CodigoAuxiliar = Me.txtCodAux.Text.Trim
        ent.TipoDocumento = Me.txtdoc.Text.Trim
        ent.SerieDocumento = ""
        ent.NumeroDocumento = Me.TxtNum.Text.Trim
        ent.FechaDocumento = Today()
        ent.VentaTipoCambio = CType(Me.txtTipCam.Text, Decimal)
        ent.VentaEurTipoCambio = CType(Me.TxtTipCam1.Text, Decimal)
        'moneda
        ent.MonedaDocumento = Me.TxtMoneda.Text
        ent.PrecioVtaRegContabCabe = 0
        ent.ExoneradoRegContabCabe = 0
        ent.IgvRegContabCabe = 0
        ent.ValorVtaRegContabCabe = 0
        ent.GlosaRegContabCabe = Me.TxtConcepto.Text.Trim
        ent.DetraccionRegContabCabe = ""
        ent.NumeroPapeletaRegContabCabe = ""
        'validar fecha detraccion
        ent.FechaDetraccionRegContabCabe = ""


        'COMO ESTA PANTALLA SI TE DEJA GRABAR SIN NINGUN DETALLE
        'EL ULTIMO CORRELATIVO  ES:
        Dim iUltCorre As Integer = Me.DgvDocPen.Rows.Count
        iUltCorre += Me.UltimoCorrelativo + 1
        ent.UltimoCorrelativo = (iUltCorre).ToString.PadLeft(4, CType("0", Char))

        ent.TipoDocumento1 = ""
        ent.SerieDocumento1 = ""
        ent.NumeroDocumento1 = ""
        ent.MonedaDocumento1 = ""
        ent.CodigoCuentaBanco = Me.TxtCodCb.Text.Trim
        ent.FechaDocumento1 = ""
        ent.FechaVencimiento = Today
        'defecto para compras

        ent.ImporteRegContabCabe = CType(Me.TxtImporte.Text, Decimal)
        'ESTOS REGISTROS SIMPRE SE GRABAN CUADRADOS
        ent.ImporteSolRegContabCabe = Me.ImporteCuadradoSoles
        ent.SumaDebeRegContabCabe = Me.ImporteCuadradoSoles
        ent.SumaHaberRegContabCabe = Me.ImporteCuadradoSoles

        ent.EstadoRegContabCabe = "1"
        ent.CodigoIngEgr = ""
        ent.CodigoModoPago = Me.txtModo.Text.Trim
        ent.RetencionRegContabCabe = ""
        ent.DescripcionRegContabCabe = Me.TxtGirado.Text.Trim
        ent.CartaRegContabCabe = ""
        ent.VoucherIngresoRegContabCabe = ""
        ent.ModoCompra = ""
        ent.EstadoRegistro = "0"

        Dim aut As New SuperEntidad
        aut.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        aut.AnoVoucher = ent.PeriodoRegContabCabe.Substring(0, 4)
        aut.CodigoMes = ent.PeriodoRegContabCabe.Substring(4, 2)
        aut.CodigoFile = Me.txtCodFil.Text.Trim
        ent.NumeroVoucherRegContabCabe = vou.obtenerVoucherAutogenerado(aut)
        rc.nuevoRegContabCabe(ent)
    End Sub


    Sub PagarCuentaCorriente()
        Dim monPag As Decimal = CType(Me.TxtMontoAPagar.Text, Decimal)
        Dim impPag As Decimal = CType(Me.TxtImporte.Text, Decimal)
        Dim tcD As Decimal = CType(Me.txtTipCam.Text, Decimal)
        Dim tcE As Decimal = CType(Me.TxtTipCam1.Text, Decimal)
        Dim tcDE As Decimal = CType(Me.txtDolEur.Text, Decimal)
        Dim iSaldoSoles As Decimal = Dgv.SumarColumna(Me.DgvDocPen, cam.ImpSolRCC, "")
        Dim iMontoSoles As Decimal = Dgv.SumarColumna(Me.DgvDocPen, cam.MonSol, "")

        If Me.wCtaCte1.Lista1.Count = 1 Then
            Dim obj As New SuperEntidad
            obj.ClaveCuentaCorriente = Me.wCtaCte1.Lista1.Item(0).ClaveCuentaCorriente
            obj = cc.buscarCuentaCorrienteExisPorClaveCC(obj)
            If Me.TxtImporte.Text = Me.TxtMontoAPagar.Text Then
                obj.SaldoCuentaCorriente = 0
                'SEGUN MONEDA CONVERTIR EL IMPORTE
                Select Case obj.MonedaDocumento
                    Case "S/."
                        Select Case Me.TxtMoneda.Text
                            Case "S/." : obj.ImportePagadoCuentaCorriente = obj.ImportePagadoCuentaCorriente + impPag
                            Case "US$" : obj.ImportePagadoCuentaCorriente = obj.ImportePagadoCuentaCorriente + iMontoSoles
                            Case "EUR" : obj.ImportePagadoCuentaCorriente = obj.ImportePagadoCuentaCorriente + iMontoSoles
                        End Select
                    Case "US$"
                        Select Case Me.TxtMoneda.Text
                            Case "S/." : obj.ImportePagadoCuentaCorriente = obj.ImporteOriginalCuentaCorriente
                            Case "US$" : obj.ImportePagadoCuentaCorriente = obj.ImportePagadoCuentaCorriente + impPag
                            Case "EUR" : obj.ImportePagadoCuentaCorriente = 1
                        End Select
                    Case "EUR"
                        Select Case Me.TxtMoneda.Text
                            Case "S/." : obj.ImportePagadoCuentaCorriente = obj.ImporteOriginalCuentaCorriente
                            Case "US$" : obj.ImportePagadoCuentaCorriente = 1
                            Case "EUR" : obj.ImportePagadoCuentaCorriente = obj.ImportePagadoCuentaCorriente + impPag
                        End Select
                End Select
                obj.EstadoCuentaCorriente = "0"
            Else
                'SEGUN MONEDA CONVERTIR EL IMPORTE
                Select Case obj.MonedaDocumento
                    Case "S/."
                        Select Case Me.TxtMoneda.Text
                            Case "S/."
                                obj.ImportePagadoCuentaCorriente = obj.ImportePagadoCuentaCorriente + impPag
                                obj.SaldoCuentaCorriente = monPag - impPag
                            Case "US$"
                        End Select
                    Case "US$"
                        Select Case Me.TxtMoneda.Text
                            Case "US$"
                                obj.ImportePagadoCuentaCorriente = obj.ImportePagadoCuentaCorriente + impPag
                                obj.SaldoCuentaCorriente = monPag - impPag
                        End Select
                    Case "EUR"
                        Select Case Me.TxtMoneda.Text
                            Case "EUR"
                                obj.ImportePagadoCuentaCorriente = obj.ImportePagadoCuentaCorriente + impPag
                                obj.SaldoCuentaCorriente = (monPag - impPag)
                        End Select
                End Select
                obj.EstadoCuentaCorriente = "1"
            End If
            cc.modificarCuentaCorriente(obj)
        Else
            For Each xob As SuperEntidad In Me.wCtaCte1.Lista1
                xob = cc.buscarCuentaCorrienteExisPorClaveCC(xob)
                'SEGUN MONEDA
                xob.ImportePagadoCuentaCorriente = xob.ImportePagadoCuentaCorriente + xob.SaldoCuentaCorriente
                xob.SaldoCuentaCorriente = 0
                xob.EstadoCuentaCorriente = "0"
                cc.modificarCuentaCorriente(xob)
            Next
        End If
    End Sub

    Sub ValidarImporte()
        If Me.wCtaCte1.Lista1.Count = 1 Then
            'TIENE QUE SER DE LA MISMA MONEDA PARA PODER
            'PAGAR EN PARTES
            If Me.wCtaCte1.Lista1.Item(0).MonedaDocumento = Me.TxtMoneda.Text Then
                Me.TxtImporte.ReadOnly = False
                Me.TxtImporte.Focus()
            Else
                Me.TxtImporte.ReadOnly = True
                Me.txtModo.Focus()
            End If
            
        Else
            Me.TxtImporte.ReadOnly = True
            Me.txtModo.Focus()
        End If
    End Sub

    Function ValidarMontoAPagar() As Boolean

        If Me.wCtaCte1.Lista1.Count = 1 Then
            Dim mp As Decimal = CType(Me.TxtMontoAPagar.Text, Decimal)
            Dim im As Decimal = CType(Me.TxtImporte.Text, Decimal)

            If im > mp Then
                MsgBox("Importe Pagado debe ser" + Chr(13) + "Menor o Igual A Importe a Pagar", MsgBoxStyle.Exclamation, "Pagos")
                Me.TxtImporte.Text = "0"
                Me.TxtImporte.Focus()
                Return False
            End If

        End If


        Return True

    End Function



    Public Function EsFlujoCajaValido() As Boolean
        Dim iFluCRN As New FlujoCajaRN
        Dim iFluCEN As New SuperEntidad
        iFluCEN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iFluCEN.CodigoFlujoCaja = Me.TxtCodFluCaj.Text.Trim
        iFluCEN = iFluCRN.EsFlujoCajaValido(iFluCEN)
        If iFluCEN.EsVerdad = False Then
            MsgBox(iFluCEN.Mensaje, MsgBoxStyle.Exclamation, "FlujoCaja")
            Me.TxtCodFluCaj.Focus()
        End If
        Me.MostarFlujoCaja(iFluCEN)
        Return iFluCEN.EsVerdad
    End Function


    Sub MostarFlujoCaja(ByRef pAR As SuperEntidad)
        Me.TxtCodFluCaj.Text = pAR.CodigoFlujoCaja
        Me.TxtNomFluCaj.Text = pAR.NombreFlujoCaja
    End Sub



    Sub GrabarDiferenciaCambio()

        Dim xdebe As Decimal = 0
        Dim xhaber As Decimal = 0
        Dim xdif As Decimal = 0
        Dim iNumeroRegistros As Integer = Me.DgvDocPen.Rows.Count

        xdebe = Dgv.SumarColumna(Me.DgvDocPen, cam.ImpSolRCC, "")
        xhaber = Dgv.SumarColumna(Me.DgvDocPen, cam.MonSol, "")

        xdif = xhaber - xdebe
        If xdif > 0 Then

            Dim obj As New SuperEntidad
            obj.ClaveRegContabCabe = ent.ClaveRegContabCabe
            obj.CorrelativoRegContabDeta = (iNumeroRegistros + 2).ToString.PadLeft(4, CType("0", Char))
            obj.CodigoCuentaPcge = ParEn.CuentaPerdidaDC
            obj.CodigoAuxiliar = ""
            obj.DebeHaberRegContabDeta = "Debe"
            obj.ImporteSRegContabDeta = xdif
            obj.ImporteDRegContabDeta = 0
            obj.TipoDocumento = ""
            obj.SerieDocumento = ""
            obj.NumeroDocumento = ""
            obj.FechaDocumento = Today()
            obj.CodigoIngEgr = ""
            obj.GlosaRegContabDeta = "Perdida por diferencia de cambio"
            'defecto
            obj.CodigoCentroCosto = ""
            obj.VentaTipoCambio = 1
            obj.VentaEurTipoCambio = 1
            obj.Cuenta1242 = ""
            obj.CodigoArea = ""
            obj.CodigoFlujoCaja = ""
            obj.EstadoRegContabDeta = "1" ' No se en grilla
            rcbd.nuevoRegContabDeta(obj)
        End If

        If xdif < 0 Then

            Dim obj As New SuperEntidad
            obj.ClaveRegContabCabe = ent.ClaveRegContabCabe
            obj.CorrelativoRegContabDeta = (iNumeroRegistros + 2).ToString.PadLeft(4, CType("0", Char))
            obj.CodigoCuentaPcge = ParEn.CuentaPerdidaDC
            obj.CodigoAuxiliar = ""
            obj.DebeHaberRegContabDeta = "Haber"
            obj.ImporteSRegContabDeta = Math.Abs(xdif)
            obj.ImporteDRegContabDeta = 0
            obj.TipoDocumento = ""
            obj.SerieDocumento = ""
            obj.NumeroDocumento = ""
            obj.FechaDocumento = Today()
            obj.CodigoIngEgr = ""
            obj.GlosaRegContabDeta = "Ganancia por diferencia de cambio"
            'defecto
            obj.CodigoCentroCosto = ""
            obj.VentaTipoCambio = 1
            obj.VentaEurTipoCambio = 1
            obj.Cuenta1242 = ""
            obj.CodigoArea = ""
            obj.CodigoFlujoCaja = ""
            obj.EstadoRegContabDeta = "1" ' No se en grilla
            rcbd.nuevoRegContabDeta(obj)
        End If



    End Sub



    Sub PagarEnParte()
        'SOLO SE EJECUTARA SI EL txtImporte SE PUEDE DIGITAR
        If Me.TxtImporte.ReadOnly = False Then
            'SOLO SI HAY UN SOLO DETALLE
            If Me.wCtaCte1.Lista1.Count = 1 Then
                'IR CAMBIANDO LOS VALORES DEL DETALLE
                Me.wCtaCte1.Lista1.Item(0).SaldoCuentaCorriente = CType(Me.TxtImporte.Text, Decimal)
                'OBTENER SALDO EN SOLES,MONTO MONEDA Y MONTO SOLES
                Select Case Me.wCtaCte1.Lista1.Item(0).MonedaDocumento
                    Case "S/."
                        Me.wCtaCte1.Lista1.Item(0).ImporteSolRegContabCabe = Me.wCtaCte1.Lista1.Item(0).SaldoCuentaCorriente
                        Me.wCtaCte1.Lista1.Item(0).MontoMoneda = Me.wCtaCte1.Lista1.Item(0).SaldoCuentaCorriente
                        Me.wCtaCte1.Lista1.Item(0).MontoSoles = Me.wCtaCte1.Lista1.Item(0).SaldoCuentaCorriente

                    Case "US$"
                        Me.wCtaCte1.Lista1.Item(0).ImporteSolRegContabCabe = Me.wCtaCte1.Lista1.Item(0).SaldoCuentaCorriente * Me.wCtaCte1.Lista1.Item(0).VentaTipoCambio
                        Me.wCtaCte1.Lista1.Item(0).MontoMoneda = Me.wCtaCte1.Lista1.Item(0).SaldoCuentaCorriente
                        Me.wCtaCte1.Lista1.Item(0).MontoSoles = Me.wCtaCte1.Lista1.Item(0).SaldoCuentaCorriente * CType(Me.txtTipCam.Text, Decimal)


                    Case "EUR"
                        Me.wCtaCte1.Lista1.Item(0).ImporteSolRegContabCabe = Me.wCtaCte1.Lista1.Item(0).SaldoCuentaCorriente * Me.wCtaCte1.Lista1.Item(0).VentaEurTipoCambio
                        Me.wCtaCte1.Lista1.Item(0).MontoMoneda = Me.wCtaCte1.Lista1.Item(0).SaldoCuentaCorriente
                        Me.wCtaCte1.Lista1.Item(0).MontoSoles = Me.wCtaCte1.Lista1.Item(0).SaldoCuentaCorriente * CType(Me.txtTipCam.Text, Decimal)

                End Select
                Me.CargarDocumentos()
            End If

        End If
    End Sub

    Sub wImpVoucher()
        '/
        Dim win As New WImpVoucher
        '/Obtener el codigo de usuario
        win.ent = rc.buscarRegContabExisPorClave(ent)
        win.NuevaVentanaDesdeVoucher()
    End Sub

    Sub Aceptar()
        '//
        'PREGUNTAR SI HAY DIFERENCIA DE CAMBIO Y ULTIMOCORRELATIVO
        Dim iSaldoSoles As Decimal = Dgv.SumarColumna(Me.DgvDocPen, cam.ImpSolRCC, "")
        Dim iMontoSoles As Decimal = Dgv.SumarColumna(Me.DgvDocPen, cam.MonSol, "")

        If iSaldoSoles = iMontoSoles Then
            Me.UltimoCorrelativo = 0
            Me.ImporteCuadradoSoles = iSaldoSoles
        Else
            Me.UltimoCorrelativo = 1
            'CUADRAR CON EL MAYOR VALOR
            If iSaldoSoles >= iMontoSoles Then
                Me.ImporteCuadradoSoles = iSaldoSoles
            Else
                Me.ImporteCuadradoSoles = iMontoSoles
            End If
        End If

        'GRABAR LA CABECERA
        Me.GrabarCabecera()
        'GRABAR EL DETALLE 
        Me.GrabarDetalleRegContab()
        'GRABAR CUENTA BANCO
        Me.GrabarCuenta10EnDetalle()
        'GRABAR DIFERENCIA DE CAMBIO
        Me.GrabarDiferenciaCambio()
        'PAGAR DOCUMENTOS
        Me.PagarCuentaCorriente()
        MsgBox("Se realizo el pago correctamente Numero Voucher: " + ent.NumeroVoucherRegContabCabe, MsgBoxStyle.Information, "Pago")
        Me.Close()
        Me.wCtaCte1.MostrarDocumentosDelAuxiliar()
        'MOSTRAR IMPRESION DE VOUCHER
        Me.wImpVoucher()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If acc.CamposObligatorios = False Then
            Exit Sub
        Else
            Me.Aceptar()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub TxtImporte_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtImporte.Validated
        If Me.ValidarMontoAPagar() = True Then
            Me.PagarEnParte()
        End If
    End Sub

    
    Private Sub TxtCodFluCaj_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodFluCaj.KeyDown
        If Me.TxtCodFluCaj.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarFlujoCaja
                win.titulo = "Flujos Activos"
                win.tabla = "FlujoCaja"
                win.txt1 = Me.TxtCodFluCaj
                win.txt2 = Me.TxtNomFluCaj
                win.ctrlFoco = Me.btnAceptar
                win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub TxtCodFluCaj_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodFluCaj.Validating
        Me.EsFlujoCajaValido()
    End Sub
End Class