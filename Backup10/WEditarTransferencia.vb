Imports Entidad
Imports Negocio

Public Class WEditarTransferencia

#Region "Propietarios"
    Public wTran As New WTransferencia
#End Region

    Public ent, entD, parEn, ticEn As New SuperEntidad
    Public lista, listaD As New List(Of SuperEntidad)
    Public rtr As New RegContabCabeRN
    Public rtrd As New RegContabDetaRN
    Public par As New ParametroRN
    Public tic As New TipoCambioRN
    Public cam As New CamposEntidad
    Public tab As New TablaRN
    Public vou As New VoucherRN
    Public emp As New EmpresaRN
    Public acc As New Accion
    Public codigo1 As String
    Public worigen As String
    Public wFile As String
    Public wnumero As String
    Public wDolares As Decimal = 0
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
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.txtNomEmp.Text = SuperEntidad.xRazonSocial
        ''Instanciar Empresa Actual 
        'Dim obe As New SuperEntidad
        'obe.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        'obe = emp.buscarEmpresaExisPorCodigo(obe)
        Me.TxtPeri.Text = SuperEntidad.xPeriodoEmpresa
        Me.txtCodOriSal.Text = "2"
        Me.txtNomOrisal.Text = "EGRESOS"
        Me.TxtCodOriIng.Text = "1"
        Me.TxtNomOriIng.Text = "INGRESOS"
        Me.TxtTipCam.Text = "1.00"
    End Sub


    Sub TraerTipoCambio()
        'traer tipo de cambio
        Dim fecvau As DateTime = CType(Me.txtFecVau.Text, DateTime)  ''Pantalla es como varcher y cambia datetime
        ticEn.DatoCondicion1 = fecvau.Year.ToString + "/" + fecvau.Month.ToString + "/" + fecvau.Day.ToString
        ticEn = tic.buscarTipoCambioExisPorFecha(ticEn)
        If ticEn.AnoTipoCambio = "" Then
            MsgBox("El tipo de cambio no existe", MsgBoxStyle.Information)
            Me.TxtTipCam.Text = "1.000"
        Else
            Me.TxtTipCam.Text = ticEn.VentaTipoCambio.ToString
        End If
    End Sub

    Sub ventanaAdicionar()
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Agregar Registro Transferencia"
        'poner valores defecto en montos
        acc.LimpiarControles()
        'por defecto
        Me.PorDefecto()
        'Me.ImportesDebeHaber()
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtCodFilSal)
        'los controles que deben estar activos
        acc.Nuevo()
        '\\
    End Sub

    Sub ventanaAdicionarManual()
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Agregar Manual Registro Transferencia"
        'poner valores defecto en montos
        acc.LimpiarControles()
        'por defecto
        Me.PorDefecto()
        'en blanco
        Me.txtNomEmp.Text = String.Empty
        'Me.ImportesDebeHaber()
        'los controles que deben estar activos
        acc.Nuevo()
        Me.txtNomEmp.ReadOnly = False
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtNomEmp)
        'Me.HabilitarControlesSegunDetraccion()
        '\\
    End Sub

    Sub ventanaModificar(ByRef codigo As String, ByVal codigo1 As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Modificar Registro Transferencia"
        'mostrar el registro en pantalla
        Me.obtenerTransferenciaEnPantalla(codigo, codigo1)
        'mostrar el detalle del registro en pantalla
        'Me.obtenerRegCajaBancoDetalleEnPantalla(codigo)
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtImporteSal)
        acc.Modificar()
        '\\
    End Sub

    Sub ventanaCopiar(ByRef codigo As String, ByVal codigo1 As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Copiar Registro Transferencia"
        'mostrar el registro en pantalla
        Me.obtenerTransferenciaEnPantalla(codigo, codigo1)
        'limpiar el correlativo voucher
        Me.TxtNumVauIng.Text = ""
        Me.txtNumVauSal.Text = ""
        ent.ClaveRegContabCabe = ""
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtCodFilSal)
        acc.Nuevo()
        '\\
    End Sub

    Sub ventanaEliminar(ByRef codigo As String, ByVal codigo1 As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Eliminar Registro Transferencia"
        'mostrar el registro en pantalla
        Me.obtenerTransferenciaEnPantalla(codigo, codigo1)
        'mostrar el detalle del registro en pantalla
        'Me.obtenerRegCajaBancoDetalleEnPantalla(codigo)
        Me.btnAceptar.Text = "Eliminar"
        Me.btnAceptar.Focus()
        'Me.ImportesDebeHaber()
        'los controles que deben estar activos
        acc.Eliminar()
        'Me.HabilitarControlesSegunDetraccion()
        '\\
    End Sub


    Sub ventanaVisualizar(ByRef codigo As String, ByVal codigo1 As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Visualizar Registro Transfernecia"
        'mostrar el registro en pantalla
        Me.obtenerTransferenciaEnPantalla(codigo, codigo1)
        'mostrar el detalle del registro en pantalla
        'Me.obtenerRegCajaBancoDetalleEnPantalla(codigo)
        'los controles que deben estar activos
        'Me.ImportesDebeHaber()
        acc.Visualizar()
        'Me.HabilitarControlesSegunDetraccion()
        '\\
    End Sub

    Sub obtenerTransferenciaEnPantalla(ByRef codigo As String, ByVal codigo1 As String)
        '//
        ent.ClaveRegContabCabe = codigo
        ent = rtr.buscarRegContabExisPorClave(ent)
        'preguntar si ent tiene el registro
        If ent.ClaveRegContabCabe = "" Then
            Exit Sub
        Else
            '/Pasar Datos a los controles salida
            Me.TxtCodEmp.Text = ent.CodigoEmpresa
            Me.txtNomEmp.Text = ent.RazonSocialEmpresa
            Me.TxtPeri.Text = ent.PeriodoRegContabCabe
            Me.txtCodOriSal.Text = ent.CodigoOrigen
            Me.txtNomOrisal.Text = ent.NombreOrigen
            Me.txtCodFilSal.Text = ent.CodigoFile
            Me.txtNomFilSal.Text = ent.NombreFile
            Me.txtNumVauSal.Text = ent.NumeroVoucherRegContabCabe
            Me.txtDia.Text = ent.DiaVoucherRegContabCabe
            Me.txtFecVau.Text = ent.FechaVoucherRegContabCabe.Date.ToShortDateString
            Gb.pasarDato(Me.gbMonedaSal, ent.MonedaDocumento)
            Me.txtImporteSal.Text = Varios.numeroConDosDecimal(ent.ImporteRegContabCabe.ToString)
            Me.txtCodBcoSal.Text = ent.CodigoCuentaBanco
            Me.txtBcoSal.Text = ent.BancoCuentaBanco
            Me.TxtNumCtaSal.Text = ent.NumeroCuentaBanco
            Me.TxtMonCtaSal.Text = ent.MonedaCuentaBanco
            Me.TxtDocumento1.Text = ent.NumeroDocumento
            Me.txtCarta.Text = ent.CartaRegContabCabe
            Me.TxtGlosaSal.Text = ent.GlosaRegContabCabe
            'voucher ingreso
            Dim obj As New SuperEntidad
            obj.ClaveRegContabCabe = codigo1
            obj = rtr.buscarRegContabExisPorClave(obj)
            Me.TxtCodOriIng.Text = obj.CodigoOrigen
            Me.TxtNomOriIng.Text = obj.NombreOrigen
            Me.TxtCodFilIng.Text = obj.CodigoFile
            Me.TxtNomFilIng.Text = obj.NombreFile
            Me.TxtNumVauIng.Text = obj.NumeroVoucherRegContabCabe
            Gb.pasarDato(Me.GbMonedaIng, obj.MonedaDocumento)
            Me.TxtCodBcoIng.Text = obj.CodigoCuentaBanco
            Me.TxtBcoIng.Text = obj.BancoCuentaBanco
            Me.TxtNumCtaIng.Text = obj.NumeroCuentaBanco
            Me.TxtMonCtaIng.Text = obj.MonedaCuentaBanco
            Me.TxtTipCam.Text = obj.VentaTipoCambio.ToString
            Me.TxtImporteIng.Text = Varios.numeroConDosDecimal(obj.ImporteRegContabCabe.ToString)
            Me.TxtDocumento2.Text = obj.NumeroDocumento
            Me.TxtGlosaIng.Text = obj.GlosaRegContabCabe
        End If
        '\\
    End Sub

    Sub GrabarDetalleRegContabSalida()
        'Grabar El primer detalle salida
        entD.ClaveRegContabCabe = ent.ClaveRegContabCabe
        entD.CorrelativoRegContabDeta = (1).ToString.PadLeft(4, CType("0", Char))
        entD.VentaTipoCambio = CType(Me.TxtTipCam.Text, Decimal)
        entD.VentaEurTipoCambio = CType(Me.TxtTipCam1.Text, Decimal)
        entD.CodigoCuentaPcge = Me.txtCodBcoSal.Text.Trim

        entD.DebeHaberRegContabDeta = "Haber"
        Dim str As String = Rbt.radioActivo(Me.gbMonedaSal).Text.Trim
        Select Case str
            Case "S/."
                entD.ImporteSRegContabDeta = CType(Me.txtImporteSal.Text, Decimal)
                entD.ImporteDRegContabDeta = entD.ImporteSRegContabDeta / CType(Me.TxtTipCam.Text, Decimal)
                entD.ImporteERegContabDeta = entD.ImporteSRegContabDeta / CType(Me.TxtTipCam1.Text, Decimal)

            Case "US$"
                entD.ImporteDRegContabDeta = CType(Me.txtImporteSal.Text, Decimal)
                entD.ImporteSRegContabDeta = entD.ImporteDRegContabDeta * CType(Me.TxtTipCam.Text, Decimal)
                entD.ImporteERegContabDeta = entD.ImporteDRegContabDeta / CType(Me.TxtTipCam2.Text, Decimal)

            Case "EUR"
                entD.ImporteERegContabDeta = CType(Me.txtImporteSal.Text, Decimal)
                entD.ImporteDRegContabDeta = entD.ImporteERegContabDeta * CType(Me.TxtTipCam2.Text, Decimal)
                entD.ImporteSRegContabDeta = entD.ImporteERegContabDeta * CType(Me.TxtTipCam1.Text, Decimal)

        End Select
        'entD.CartaRegContabCabe = Me.txtCarta.Text.Trim
        entD.GlosaRegContabDeta = Me.TxtGlosaSal.Text.Trim
        'defecto
        entD.EstadoRegContabDeta = ""
        entD.CodigoCentroCosto = ""
        entD.Cuenta1242 = ""
        entD.TipoDocumento = ""
        entD.SerieDocumento = ""
        entD.NumeroDocumento = Me.TxtDocumento1.Text.Trim
        entD.MonedaDocumento = ""
        entD.FechaDocumento = Today
        entD.FechaVencimiento = Today
        entD.CodigoIngEgr = ""
        entD.CodigoAuxiliar = ""
        entD.CodigoArea = ""
        entD.CodigoFlujoCaja = ""
        rtrd.nuevoRegContabDeta(entD)

        'Grabar El segundo detalle 
        entD.CorrelativoRegContabDeta = (2).ToString.PadLeft(4, CType("0", Char))
        entD.CodigoCuentaPcge = parEn.CuentaTransferencia
        entD.DebeHaberRegContabDeta = "Debe"
        entD.GlosaRegContabDeta = Me.TxtGlosaSal.Text.Trim
        ' entD.NumeroDocumento = Me.TxtDocumento2.Text.Trim
        rtrd.nuevoRegContabDeta(entD)
    End Sub

    Sub grabarDetalleRegContabIngreso()
        'Grabar El primer detalle ingreso
        entD.ClaveRegContabCabe = ent.ClaveRegContabCabe
        entD.CorrelativoRegContabDeta = (1).ToString.PadLeft(4, CType("0", Char))
        entD.VentaTipoCambio = CType(Me.TxtTipCam.Text, Decimal)
        entD.CodigoCuentaPcge = Me.TxtCodBcoIng.Text.Trim
        entD.DebeHaberRegContabDeta = "Debe"
        Dim str As String = Rbt.radioActivo(Me.GbMonedaIng).Text.Trim
        Select Case str
            Case "S/."
                entD.ImporteSRegContabDeta = CType(Me.TxtImporteIng.Text, Decimal)
                entD.ImporteDRegContabDeta = entD.ImporteSRegContabDeta / CType(Me.TxtTipCam.Text, Decimal)
                entD.ImporteERegContabDeta = entD.ImporteSRegContabDeta / CType(Me.TxtTipCam1.Text, Decimal)

            Case "US$"
                entD.ImporteDRegContabDeta = CType(Me.TxtImporteIng.Text, Decimal)
                entD.ImporteSRegContabDeta = entD.ImporteDRegContabDeta * CType(Me.TxtTipCam.Text, Decimal)
                entD.ImporteERegContabDeta = entD.ImporteDRegContabDeta / CType(Me.TxtTipCam2.Text, Decimal)

            Case "EUR"
                entD.ImporteERegContabDeta = CType(Me.TxtImporteIng.Text, Decimal)
                entD.ImporteDRegContabDeta = entD.ImporteERegContabDeta * CType(Me.TxtTipCam2.Text, Decimal)
                entD.ImporteSRegContabDeta = entD.ImporteERegContabDeta * CType(Me.TxtTipCam1.Text, Decimal)

        End Select
        'entD.CartaRegContabCabe = ""
        entD.GlosaRegContabDeta = Me.TxtGlosaIng.Text.Trim
        'defecto
        entD.EstadoRegContabDeta = ""
        entD.CodigoCentroCosto = ""
        entD.Cuenta1242 = ""
        entD.TipoDocumento = ""
        entD.SerieDocumento = ""
        entD.NumeroDocumento = Me.TxtDocumento2.Text.Trim
        entD.MonedaDocumento = ""
        entD.FechaDocumento = Today()
        entD.FechaVencimiento = Today()
        entD.CodigoIngEgr = ""
        entD.CodigoAuxiliar = ""
        entD.CodigoArea = ""
        entD.CodigoFlujoCaja = ""
        rtrd.nuevoRegContabDeta(entD)

        'Grabar El segundo detalle 

        entD.CorrelativoRegContabDeta = (2).ToString.PadLeft(4, CType("0", Char))
        entD.CodigoCuentaPcge = parEn.CuentaTransferencia
        entD.DebeHaberRegContabDeta = "Haber"
        entD.GlosaRegContabDeta = Me.TxtGlosaIng.Text.Trim
        ' entD.NumeroDocumento = Me.TxtDocumento1.Text.Trim
        rtrd.nuevoRegContabDeta(entD)
    End Sub

    Sub ObtenerImporteIngreso()
        Dim monsal As String = Rbt.radioActivo(Me.gbMonedaSal).Text
        Dim moning As String = Rbt.radioActivo(Me.GbMonedaIng).Text

        ' Dim imping As Decimal = CType(Me.TxtImporteIng.Text, Decimal)
        Dim impsal As Decimal = CType(Me.txtImporteSal.Text, Decimal)
        Dim tc As Decimal = CType(Me.TxtTipCam.Text, Decimal)
        Dim tc1 As Decimal = CType(Me.TxtTipCam1.Text, Decimal)
        Dim tc2 As Decimal = CType(Me.TxtTipCam2.Text, Decimal)




        Select Case monsal
            Case "S/."
                Select Case moning
                    Case "S/." : Me.TxtImporteIng.Text = Varios.numeroConDosDecimal(impsal.ToString)
                    Case "US$"
                        If tc = 0 Then
                            Me.TxtImporteIng.Text = "0.00"
                        Else
                            Me.TxtImporteIng.Text = Varios.numeroConDosDecimal((impsal / tc).ToString)
                        End If
                    Case "EUR"
                        If tc1 = 0 Then
                            Me.TxtImporteIng.Text = "0.00"
                        Else
                            Me.TxtImporteIng.Text = Varios.numeroConDosDecimal((impsal / tc1).ToString)
                        End If

                End Select
            Case "US$"
                Select Case moning
                    Case "S/." : Me.TxtImporteIng.Text = Varios.numeroConDosDecimal((impsal * tc).ToString)
                    Case "US$" : Me.TxtImporteIng.Text = Varios.numeroConDosDecimal(impsal.ToString)
                    Case "EUR"
                        If tc2 = 0 Then
                            Me.TxtImporteIng.Text = "0.00"
                        Else
                            Me.TxtImporteIng.Text = Varios.numeroConDosDecimal((impsal / tc2).ToString)
                        End If

                End Select
            Case "EUR"
                Select Case moning
                    Case "S/." : Me.TxtImporteIng.Text = Varios.numeroConDosDecimal((impsal * tc1).ToString)
                    Case "US$" : Me.TxtImporteIng.Text = Varios.numeroConDosDecimal((impsal * tc2).ToString)
                    Case "EUR" : Me.TxtImporteIng.Text = Varios.numeroConDosDecimal(impsal.ToString)
                End Select

        End Select


    End Sub

    Sub HabilitarTipoCambio()
        '/
        'Dim sr As RadioButton
        Dim monsal As String = ""
        Dim moning As String = ""
        If Me.rbtSolSal.Checked = True Or Me.rbtDolSal.Checked = True Or Me.rbtEurSal.Checked = True Then
            monsal = Rbt.radioActivo(Me.gbMonedaSal).Text
            'Habilitar los campos calculados segun la detraccion
        End If

        If Me.RbtSolIng.Checked = True Or Me.RbtDolIng.Checked = True Or Me.rbtEurIng.Checked = True Then
            moning = Rbt.radioActivo(Me.GbMonedaIng).Text
            'Habilitar los campos calculados segun la detraccion
        End If

        If monsal = moning Then
            Me.TxtTipCam.Text = "1"
            Me.TxtTipCam.ReadOnly = True
            Me.TxtImporteIng.Text = Me.txtImporteSal.Text

        Else
            Dim tipcam As Decimal = 1
            Dim impsal As Decimal = 0
            Me.TxtTipCam.ReadOnly = False
            If Me.txtImporteSal.Text <> "" Then
                impsal = CType(Me.txtImporteSal.Text, Decimal)
            End If

            If Me.TxtTipCam.Text <> "" Then
                tipcam = CType(Me.TxtTipCam.Text, Decimal)
            End If
            If monsal = "S/." Then
                Me.TxtImporteIng.Text = Varios.numeroConDosDecimal((impsal / tipcam).ToString)
            Else
                Me.TxtImporteIng.Text = Varios.numeroConDosDecimal((impsal * tipcam).ToString)
            End If
        End If
        '/

    End Sub

    Sub Aceptar()
        '//
        If Me.operacion = 1 Or Me.operacion = 2 Then
            'Volver a traer el registro 
            ent.DatoCondicion1 = ent.ClaveRegContabCabe
            ent = rtr.buscarRegContabExisPorClave(ent)
        End If
        ent.CodigoEmpresa = Me.TxtCodEmp.Text
        ent.PeriodoRegContabCabe = Me.TxtPeri.Text
        ent.CodigoOrigen = Me.txtCodOriSal.Text
        ent.CodigoFile = Me.txtCodFilSal.Text
        '   ent.NumeroVoucherRegContabCabe = Me.txtNumVauSal.Text
        ent.DiaVoucherRegContabCabe = Me.txtDia.Text
        ent.FechaVoucherRegContabCabe = CType(Me.txtFecVau.Text, Date)
        ent.MonedaVoucherRegContabCabe = Rbt.radioActivo(Me.gbMonedaSal).Text.ToString.Trim()
        ent.MonedaDocumento = Rbt.radioActivo(Me.gbMonedaSal).Text.ToString.Trim()
        ent.VentaTipoCambio = CType(Me.TxtTipCam.Text, Decimal)
        ent.VentaEurTipoCambio = CType(Me.TxtTipCam1.Text, Decimal)
        ent.ImporteRegContabCabe = CType(Me.txtImporteSal.Text, Decimal)
        ''Ver El importe en soles
        If ent.MonedaVoucherRegContabCabe = "0" Then
            ent.ImporteSolRegContabCabe = CType(Me.txtImporteSal.Text, Decimal)
        Else
            wDolares = ent.ImporteRegContabCabe * ent.VentaTipoCambio
            ' ent.ImporteSolRegContabCabe = CType(Me.txtImporteSal.Text, Decimal)
            ent.ImporteSolRegContabCabe = CType(wDolares, Decimal)
        End If
        '  ent.ImporteSolRegContabCabe = CType(Me.txtImporteSal.Text, Decimal)
        ent.CodigoCuentaBanco = Me.txtCodBcoSal.Text
        ent.CartaRegContabCabe = Me.txtCarta.Text
        ent.GlosaRegContabCabe = Me.TxtGlosaSal.Text
        '' Prueba
        worigen = Me.txtCodOriSal.Text
        wFile = Me.txtCodFilSal.Text
        wnumero = Me.txtNumVauSal.Text
        'Defecto 
        ent.EstadoRegContabCabe = "T"  ''Inicio al grabar varia con otro proceso sino se graba en negocio
        ent.RetencionRegContabCabe = ""
        ent.DescripcionRegContabCabe = ""
        ent.CodigoAuxiliar = ""
        ent.TipoDocumento = ""
        ent.SerieDocumento = ""
        ent.NumeroDocumento = Me.TxtDocumento1.Text.Trim
        ' ent.NumeroDocumento = ""
        'ent.MonedaDocumento = ""
        ent.FechaDocumento = CType(Me.txtFecVau.Text, Date)
        ent.DetraccionRegContabCabe = ""
        ent.FechaDetraccionRegContabCabe = ""
        ent.NumeroPapeletaRegContabCabe = ""
        ent.CodigoModoPago = ""

        ent.FechaVencimiento = Today()
        ent.TipoDocumento1 = ""
        ent.SerieDocumento1 = ""
        ent.NumeroDocumento1 = ""
        ent.MonedaDocumento1 = ""
        ent.FechaDocumento1 = ""
        ent.ModoCompra = ""

        ent.UltimoCorrelativo = "0002"

        ent.SumaDebeRegContabCabe = ent.ImporteSolRegContabCabe
        ent.SumaHaberRegContabCabe = ent.ImporteSolRegContabCabe

        Select Case Me.operacion

            Case 0
                'Igv
                ent.IgvPar = parEn.IgvPar
                'numero voucher autogenerado
                '  Dim aut As New SuperEntidad
                Dim wing As String = ""
                Dim wsal As String = ""

                'aut.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
                'aut.AnoVoucher = ent.PeriodoRegContabCabe.Substring(0, 4)
                'aut.CodigoMes = ent.PeriodoRegContabCabe.Substring(4, 2)
                'aut.CodigoFile = Me.txtCodFilSal.Text.Trim
                'ent.NumeroVoucherRegContabCabe = vou.obtenerVoucherAutogenerado(aut)
                'wsal = ent.NumeroVoucherRegContabCabe

                'wnumero = wsal

                '' Generar(VoucherIngreso)
                'aut.CodigoFile = Me.TxtCodFilIng.Text.Trim()
                'Dim numvou As String = vou.obtenerVoucherAutogenerado(aut)
                'ent.VoucherIngresoRegContabCabe = aut.CodigoEmpresa + ent.PeriodoRegContabCabe + Me.TxtCodOriIng.Text + Me.TxtCodFilIng.Text + numvou

                'Me.TxtNumVauIng.Text = numvou
                'wing = numvou

                ent.NumeroVoucherRegContabCabe = Me.txtNumVauSal.Text
                'ent.VoucherIngresoRegContabCabe = Me.TxtNumVauIng.Text
                ent.VoucherIngresoRegContabCabe = Me.TxtCodEmp.Text.Trim + Me.TxtPeri.Text.Trim + Me.TxtCodOriIng.Text.Trim + Me.TxtCodFilIng.Text.Trim + Me.TxtNumVauIng.Text
                wsal = ent.NumeroVoucherRegContabCabe

                ent.EstadoRegistro = "0"
                ' Grabar el voucher cabecera de salida  
                rtr.nuevoRegContabCabe(ent)
                ' Grabar el voucher detalle de salida
                Me.GrabarDetalleRegContabSalida()

                ' Grabar el Voucher cabecera de ingreso
                ent.MonedaDocumento = Rbt.radioActivo(Me.GbMonedaIng).Text.ToString.Trim()
                ent.EstadoRegContabCabe = "T"
                ent.CodigoOrigen = Me.TxtCodOriIng.Text
                ent.CodigoFile = Me.TxtCodFilIng.Text
                ent.NumeroVoucherRegContabCabe = Me.TxtNumVauIng.Text
                wing = ent.NumeroVoucherRegContabCabe
                ent.CodigoCuentaBanco = Me.TxtCodBcoIng.Text
                ent.ImporteRegContabCabe = CType(Me.TxtImporteIng.Text, Decimal)
                If ent.MonedaDocumento = "0" Then
                    ent.ImporteSolRegContabCabe = CType(Me.TxtImporteIng.Text, Decimal)
                Else
                    wDolares = ent.ImporteRegContabCabe * ent.VentaTipoCambio
                    ent.ImporteSolRegContabCabe = CType(wDolares, Decimal)
                End If
                ' ent.ImporteSolRegContabCabe = CType(Me.TxtImporteIng.Text, Decimal)
                ent.SumaDebeRegContabCabe = ent.ImporteSolRegContabCabe
                ent.SumaHaberRegContabCabe = ent.ImporteSolRegContabCabe
                ent.VoucherIngresoRegContabCabe = ""
                ent.GlosaRegContabCabe = Me.TxtGlosaIng.Text
                ent.EstadoRegistro = "0"
                ent.NumeroDocumento = Me.TxtDocumento2.Text.Trim
                rtr.nuevoRegContabCabe(ent)
                ' Grabar el Voucher voucher de ingreso
                Me.grabarDetalleRegContabIngreso()

                MsgBox("Registro de Transfernecia ingresado correctamente" + Chr(13) + "Vouvher de Salida N°. " + wsal + Chr(13) + "Voucher de Ingreso N° " + wing, MsgBoxStyle.Information)
                'Limpiar la grilla
                'Me.DgvRegCbco.Rows.Clear()
                acc.LimpiarControles()
                'Me.ImportesSolesDolares()
                Txt.cursorAlUltimo(Me.txtCodFilSal)

            Case 4
                'Igv
                ent.IgvPar = parEn.IgvPar
                'numero voucher autogenerado
                Dim aut As New SuperEntidad
                aut.PeriodoRegContabCabe = Me.TxtPeri.Text.Trim
                aut.AnoVoucher = aut.PeriodoRegContabCabe.Substring(0, 4)
                aut.CodigoMes = aut.PeriodoRegContabCabe.Substring(4, 2)
                aut.CodigoFile = Me.txtCodFilSal.Text.Trim
                ent.NumeroVoucherRegContabCabe = vou.obtenerVoucherAutogenerado(aut)

                rtr.nuevoRegContabCabe(ent)
                'eliminamos el detalle 
                'rcbd.eliminarRegContabDeta(ent)
                'Me.GrabarDetalleRegContab()
                MsgBox("Registro Transferencia ingresado correctamente", MsgBoxStyle.Information)
                'Limpiar la grilla
                'Me.DgvTrans.Rows.Clear()
                acc.LimpiarControles()
                'Me.ImportesSolesDolares()
                Txt.cursorAlUltimo(Me.txtNomEmp)

            Case 1

                'modificar cabecera
                rtr.modificarRegContab(ent)
                'Eliminamos el detalle antiguo
                rtrd.eliminarRegContabDeta(ent)
                'grabamos el nuevo detalle
                Me.GrabarDetalleRegContabSalida()

                ent.ClaveRegContabCabe = Me.TxtCodEmp.Text + Me.TxtPeri.Text + Me.TxtCodOriIng.Text + Me.TxtCodFilIng.Text + Me.TxtNumVauIng.Text
                ent = rtr.buscarRegContabExisPorClave(ent)
                ent.MonedaDocumento = Rbt.radioActivo(Me.GbMonedaIng).Text.ToString.Trim()
                ent.ImporteRegContabCabe = CType(Me.TxtImporteIng.Text, Decimal)
                If ent.MonedaDocumento = "0" Then
                    ent.ImporteSolRegContabCabe = CType(Me.TxtImporteIng.Text, Decimal)
                Else
                    wDolares = ent.ImporteRegContabCabe * ent.VentaTipoCambio
                    ent.ImporteSolRegContabCabe = CType(wDolares, Decimal)
                End If
                ' ent.ImporteSolRegContabCabe = ent.ImporteRegContabCabe
                ent.SumaDebeRegContabCabe = ent.ImporteSolRegContabCabe
                ent.SumaHaberRegContabCabe = ent.ImporteSolRegContabCabe
                ent.ModoCompra = ""
                ent.GlosaRegContabCabe = Me.TxtGlosaIng.Text.Trim
                ent.NumeroDocumento = Me.TxtDocumento2.Text.Trim
                rtr.modificarRegContab(ent)
                'Eliminamos el detalle antiguo
                rtrd.eliminarRegContabDeta(ent)
                Me.grabarDetalleRegContabIngreso()
                'grabamos el nuevo detalle
                MsgBox("Registro Transfrnecia modificado correctamente", MsgBoxStyle.Information)
                Me.Close()

            Case 2
                'eliminar cabecera salida
                rtr.eliminarRegContabFis(ent)
                'eliminar detalle salida
                rtrd.eliminarRegContabDeta(ent)

                ent.ClaveRegContabCabe = Me.TxtCodEmp.Text + Me.TxtPeri.Text + Me.TxtCodOriIng.Text + Me.TxtCodFilIng.Text + Me.TxtNumVauIng.Text
                ent = rtr.buscarRegContabExisPorClave(ent)
                'eliminar cabecera ingreso
                rtr.eliminarRegContabFis(ent)
                'Eliminamos el detalle ingreo 
                rtrd.eliminarRegContabDeta(ent)

                MsgBox("Registro Transferencia Eliminado correctamente", MsgBoxStyle.Information)
                Me.Close()
            Case 5
                'Igv
                ent.IgvPar = parEn.IgvPar
                'numero voucher autogenerado
                Dim aut As New SuperEntidad
                Dim wing As String = ""
                Dim wsal As String = ""

                aut.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
                aut.AnoVoucher = ent.PeriodoRegContabCabe.Substring(0, 4)
                aut.CodigoMes = ent.PeriodoRegContabCabe.Substring(4, 2)
                aut.CodigoFile = Me.txtCodFilSal.Text.Trim
                ent.NumeroVoucherRegContabCabe = vou.obtenerVoucherAutogenerado(aut)
                wsal = ent.NumeroVoucherRegContabCabe

                wnumero = wsal

                'Generar VoucherIngreso
                aut.CodigoFile = Me.TxtCodFilIng.Text.Trim()
                Dim numvou As String = vou.obtenerVoucherAutogenerado(aut)
                ent.VoucherIngresoRegContabCabe = aut.CodigoEmpresa + ent.PeriodoRegContabCabe + Me.TxtCodOriIng.Text + Me.TxtCodFilIng.Text + numvou

                Me.TxtNumVauIng.Text = numvou
                wing = numvou
                ent.EstadoRegistro = "0"
                ' Grabar el voucher cabecera de salida  
                rtr.nuevoRegContabCabe(ent)
                ' Grabar el voucher detalle de salida
                Me.GrabarDetalleRegContabSalida()

                ' Grabar el Voucher cabecera de ingreso
                ent.MonedaDocumento = Rbt.radioActivo(Me.GbMonedaIng).Text.ToString.Trim()
                ent.EstadoRegContabCabe = "T"
                ent.CodigoOrigen = Me.TxtCodOriIng.Text
                ent.CodigoFile = Me.TxtCodFilIng.Text
                ent.NumeroVoucherRegContabCabe = Me.TxtNumVauIng.Text
                ent.CodigoCuentaBanco = Me.TxtCodBcoIng.Text
                ent.ImporteRegContabCabe = CType(Me.TxtImporteIng.Text, Decimal)
                ent.ImporteSolRegContabCabe = CType(Me.TxtImporteIng.Text, Decimal)
                ent.SumaDebeRegContabCabe = ent.ImporteSolRegContabCabe
                ent.SumaHaberRegContabCabe = ent.ImporteSolRegContabCabe
                ent.VoucherIngresoRegContabCabe = ""
                ent.GlosaRegContabCabe = Me.TxtGlosaIng.Text
                ent.EstadoRegistro = "0"
                rtr.nuevoRegContabCabe(ent)
                ' Grabar el Voucher voucher de ingreso
                Me.grabarDetalleRegContabIngreso()

                MsgBox("Registro de Transfernecia ingresado correctamente" + Chr(13) + "Vouvher de Salida N°. " + wsal + Chr(13) + "Voucher de Ingreso N° " + wing, MsgBoxStyle.Information)
                Me.Close()

        End Select
        '/Actualizar y buscar el registro grabado
        Me.wTran.ActualizarVentana()
        ''ent.ClaveRegContabCabe = ent.CodigoEmpresa + ent.PeriodoRegContabCabe + Me.txtCodOriSal.Text + Me.txtCodFilSal.Text + Me.txtNumVauSal.Text
        ent.ClaveRegContabCabe = ent.CodigoEmpresa + ent.PeriodoRegContabCabe + worigen + wFile + wnumero
        Dgv.obtenerCursorActual(Me.wTran.DgvTrans, ent.ClaveRegContabCabe, Me.wTran.lista)

        'MOSTRAR LA IMPRESION DEL VOUCHER SOLO CUANDO ES NUEVO O MODIFICA
        If Me.operacion = 0 Or Me.operacion = 1 Or Me.operacion = 5 Then
            Me.wTran.wImpVoucher()
        End If

        '\\
    End Sub

    Function EsNumeroVoucherEgresoCorrecto() As Boolean
        Dim aut As New SuperEntidad
        aut.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        aut.AnoVoucher = Me.TxtPeri.Text.Trim.Substring(0, 4)
        aut.CodigoMes = Me.TxtPeri.Text.Trim.Substring(4, 2)
        aut.CodigoFile = Me.txtCodFilSal.Text.Trim
        ent.NumeroVoucherRegContabCabe = vou.obtenerVoucherAutogenerado(aut)

        Dim RccRN As New RegContabCabeRN
        Dim RccEN As New SuperEntidad
        RccEN.ClaveRegContabCabe += Me.TxtCodEmp.Text.Trim
        RccEN.ClaveRegContabCabe += Me.TxtPeri.Text.Trim
        RccEN.ClaveRegContabCabe += Me.txtCodOriSal.Text.Trim
        RccEN.ClaveRegContabCabe += Me.txtCodFilSal.Text.Trim
        RccEN.ClaveRegContabCabe += ent.NumeroVoucherRegContabCabe
        RccEN = RccRN.buscarRegContabExisPorClave(RccEN)
        If RccEN.ClaveRegContabCabe = "" Then
            Me.txtNumVauSal.Text = ent.NumeroVoucherRegContabCabe
            Return True
        Else
            Me.txtNumVauSal.Text = ""
            MsgBox("El correlativo Egreso " + ent.NumeroVoucherRegContabCabe + " Ya Existe", MsgBoxStyle.Information, "Transferencia")
            Return False
        End If

    End Function

    Function EsNumeroVoucherIngresoCorrecto() As Boolean
        Dim aut As New SuperEntidad
        aut.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        aut.AnoVoucher = Me.TxtPeri.Text.Trim.Substring(0, 4)
        aut.CodigoMes = Me.TxtPeri.Text.Trim.Substring(4, 2)
        aut.CodigoFile = Me.TxtCodFilIng.Text.Trim
        ent.NumeroVoucherRegContabCabe = vou.obtenerVoucherAutogenerado(aut)

        Dim RccRN As New RegContabCabeRN
        Dim RccEN As New SuperEntidad
        RccEN.ClaveRegContabCabe += Me.TxtCodEmp.Text.Trim
        RccEN.ClaveRegContabCabe += Me.TxtPeri.Text.Trim
        RccEN.ClaveRegContabCabe += Me.TxtCodOriIng.Text.Trim
        RccEN.ClaveRegContabCabe += Me.TxtCodFilIng.Text.Trim
        RccEN.ClaveRegContabCabe += ent.NumeroVoucherRegContabCabe
        RccEN = RccRN.buscarRegContabExisPorClave(RccEN)
        If RccEN.ClaveRegContabCabe = "" Then
            Me.TxtNumVauIng.Text = ent.NumeroVoucherRegContabCabe
            Return True
        Else
            Me.txtNumVauSal.Text = ""
            Me.TxtNumVauIng.Text = ""
            MsgBox("El correlativo Ingreso" + ent.NumeroVoucherRegContabCabe + " Ya Existe", MsgBoxStyle.Information, "Transferencia")
            Return False
        End If

    End Function

#End Region

#Region "Mostrar formulario lista"

    Private Sub txtCodFilSal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodFilSal.KeyDown
        If Me.txtCodFilSal.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListaFiles
                win.titulo = "Files"
                win.CondicionLista = "ListarFilesXOrigen"
                win.ent.CodigoFile = "2"
                win.txt1 = Me.txtCodFilSal
                win.txt2 = Me.txtNomFilSal
                win.ctrlFoco = Me.txtDia
                win.NuevaVentana()
            End If
        End If

    End Sub

    Private Sub txtCodBcoSal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodBcoSal.KeyDown
        If Me.txtCodBcoSal.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarCuentaBanco
                win.tabla = "PorEmpresaYMoneda"
                win.titulo = "Cuentas Bancos"
                win.ent.MonedaCuentaBanco = Rbt.radioActivo(Me.gbMonedaSal).Text.ToString.Trim       ''Moneda de pantalla
                win.txt1 = Me.txtCodBcoSal
                win.txt2 = Me.txtBcoSal
                win.txt3 = Me.TxtNumCtaSal
                win.txt4 = Me.TxtMonCtaSal
                win.ctrlFoco = Me.TxtDocumento1
                win.NuevaVentana()
            End If
        End If
    End Sub
    '
    Private Sub txtCodFilIng_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodFilIng.KeyDown
        If Me.TxtCodFilIng.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListaFiles
                win.titulo = "Files"
                win.CondicionLista = "ListarFilesXOrigen"
                win.ent.CodigoFile = "1"
                win.txt1 = Me.TxtCodFilIng
                win.txt2 = Me.TxtNomFilIng
                win.ctrlFoco = Me.GbMonedaIng
                win.NuevaVentana()
            End If
        End If

    End Sub

    Private Sub txtCodBcoIng_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodBcoIng.KeyDown
        If Me.TxtCodBcoIng.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarCuentaBanco
                win.tabla = "PorEmpresaYMoneda"
                win.titulo = "Cuentas Bancos"
                win.ent.MonedaCuentaBanco = Rbt.radioActivo(Me.GbMonedaIng).Text.ToString.Trim       ''Moneda de pantalla
                win.txt1 = Me.TxtCodBcoIng
                win.txt2 = Me.TxtBcoIng
                win.txt3 = Me.TxtNumCtaIng
                win.txt4 = Me.TxtMonCtaIng
                win.ctrlFoco = Me.TxtTipCam
                win.NuevaVentana()
            End If
        End If
    End Sub
    '

#End Region

#Region "Buscar por codigo"
    Private Sub txtCodFilSal_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodFilSal.Validating
        If Me.operacion = 0 Or Me.operacion = 4 Or Me.operacion = 5 Then
            If Me.txtCodFilSal.Text.Trim <> "" Then
                Dim codfil As String = Me.txtCodFilSal.Text.Trim.Substring(0, 1)
                If codfil = "1" Or codfil = "2" Then
                    Dim ope As New OperaWin : ope.txt1 = Me.txtCodFilSal : ope.txt2 = Me.txtNomFilSal
                    ope.MostrarCodigoDescripcionDeFile("Files", e)
                Else
                    MsgBox("El Codigo File no existe", MsgBoxStyle.Information)
                    Me.txtCodFilSal.Text = String.Empty
                    Me.txtNomFilSal.Text = String.Empty
                    Me.txtDia.Focus()
                End If
            End If
        End If

    End Sub

    Private Sub txtCodbCoSal_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodBcoSal.Validating
        If Me.operacion = 0 Or Me.operacion = 1 Or Me.operacion = 4 Or Me.operacion = 5 Then
            Dim ope As New OperaWin : ope.txt1 = Me.txtCodBcoSal : ope.txt2 = Me.txtBcoSal : ope.txt3 = Me.TxtNumCtaSal : ope.txt4 = Me.TxtMonCtaSal
            ope.MostrarCodigoDescripcionDeCuentaBanco("PorEmpresaYMoneda", e)
        End If
    End Sub

    Private Sub txtCodFilIng_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodFilIng.Validating
        If Me.operacion = 0 Or Me.operacion = 4 Or Me.operacion = 5 Then
            If Me.TxtCodFilIng.Text.Trim <> "" Then
                Dim codfil As String = Me.TxtCodFilIng.Text.Trim.Substring(0, 1)
                If codfil = "1" Or codfil = "2" Then
                    Dim ope As New OperaWin : ope.txt1 = Me.TxtCodFilIng : ope.txt2 = Me.TxtNomFilIng
                    ope.MostrarCodigoDescripcionDeFile("Files", e)
                Else
                    MsgBox("El Codigo File no existe", MsgBoxStyle.Information)
                    Me.TxtCodFilIng.Text = String.Empty
                    Me.TxtNomFilIng.Text = String.Empty
                    Me.GbMonedaIng.Focus()
                End If
            End If
        End If

    End Sub

    Private Sub txtCodbCoIng_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodBcoIng.Validating
        If Me.operacion = 0 Or Me.operacion = 1 Or Me.operacion = 4 Or Me.operacion = 5 Then
            Dim ope As New OperaWin : ope.txt1 = Me.TxtCodBcoIng : ope.txt2 = Me.TxtBcoIng : ope.txt3 = Me.TxtNumCtaIng : ope.txt4 = Me.TxtMonCtaIng
            ope.MostrarCodigoDescripcionDeCuentaBanco("PorEmpresaYMoneda", e)
        End If
    End Sub

#End Region

    Private Sub WEditarPptoInterno_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If Me.Text = "Visualizar Registro Transferencia" Then
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

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Me.Text = "Eliminar Registro Transferencia" Then
            Me.Aceptar()
            Exit Sub
        End If
        If acc.CamposObligatorios = False Then
            Exit Sub
        Else
            'Validadando el correlativo del voucher
            If Me.operacion = 0 Then
                If Me.EsNumeroVoucherEgresoCorrecto = False Then Exit Sub
                If Me.EsNumeroVoucherIngresoCorrecto = False Then Exit Sub
            End If

            If Me.TxtImporteIng.Text = "0.00" Then
                MsgBox("Importe Ingreso Debe Ser Diferente de Cero (0)", MsgBoxStyle.Exclamation, "Transferencia")
            Else
                Dim tc As Decimal = CType(Me.TxtTipCam.Text, Decimal)
                Dim tc1 As Decimal = CType(Me.TxtTipCam1.Text, Decimal)
                Dim tc2 As Decimal = CType(Me.TxtTipCam2.Text, Decimal)
                If tc = 0 Or tc1 = 0 Or tc2 = 0 Then
                    MsgBox("Los Tipos de Cambios Deben Ser Diferente de Cero (0)", MsgBoxStyle.Exclamation, "Transferencia")
                Else
                    Me.Aceptar()
                End If
            End If
        End If

    End Sub

    Private Sub txtDia_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDia.Validated
        If Me.TxtPeri.Text <> "" Then
            If Me.txtDia.Text.Trim <> "" Then
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
                    Me.TraerTipoCambio()
                Else
                    MsgBox("El dia debe estar entre en 1 y 31", MsgBoxStyle.Information)
                    Me.txtDia.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub rbtDolSal_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles rbtSolSal.Validating, rbtDolSal.Validating, rbtEurSal.Validating, RbtSolIng.Validating, RbtDolIng.Validating, rbtEurIng.Validating, txtImporteSal.Validating, TxtTipCam.Validating, TxtTipCam1.Validating, TxtTipCam2.Validating
        Me.ObtenerImporteIngreso()
    End Sub

    Private Sub Label26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label26.Click

    End Sub

    Private Sub WEditarTransferencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class


