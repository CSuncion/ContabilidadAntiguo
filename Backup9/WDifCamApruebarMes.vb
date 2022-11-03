Imports Entidad
Imports Negocio

Public Class WDifCamApruebarMes
    Dim acc As New Accion
    Dim cam As New CamposEntidad
    Dim iClaveRcc As String
    Dim iCompras As String = "" 'PARA SABER SI HAY COMPRAS PENDIENTES EN CUENTA CORRIENTE
    Dim iVentas As String = "" 'PARA SABER SI HAY VENTAS PENDIENTES EN CUENTA CORRIENTE
    Dim LisVen As New List(Of SuperEntidad) 'solo ventas
    Dim iTipoCambio As DateTime
    Public eVentana As Integer ' 0 : Desaprobar , 1 : Aprobar



#Region "Propietario"
    'Public wBco As New WCuentaBanco
#End Region

#Region "General"

    Sub InicializaVentana()
        '/Para los eventos de controles
        acc.listaCtrls = Me.ListaControles
        acc.PasaFoco()
        acc.FomatoDato()
        acc.PasarCursor()
        acc.Teclazo()
        acc.Valida()
        Me.Show()
        'Me.Owner.Enabled = False
        Me.PorDefecto()
        Me.txtCodMes.Focus()
        'titulo ventana
        If Me.eVentana = 0 Then
            Me.Text = "Desaprobar Diferencia Cambio"
        Else
            Me.Text = "Aprobar Diferencia Cambio"
        End If
        'acc.Nuevo()
    End Sub

    Sub PorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.TxtNomEmp.Text = SuperEntidad.xRazonSocial
        Me.txtAno.Text = SuperEntidad.xPeriodoEmpresa.Substring(0, 4)
    End Sub

    Function EsValidoAprobarMes() As Boolean
        Dim iCchRN As New CuentaCorrienteHistoricoRN
        Dim iCchEN As New SuperEntidad
        iCchEN = iCchRN.EsValidoAprobarMes(Me.ListarCuentaCorrienteHistoricoMes())
        If iCchEN.EsVerdad = False Then
            MsgBox(iCchEN.Mensaje, MsgBoxStyle.Exclamation, "Diferencia cambio")
        End If
        Return iCchEN.EsVerdad
    End Function

    Function EsValidoDesaprobarMes() As Boolean
        Dim iCchRN As New CuentaCorrienteHistoricoRN
        Dim iCchEN As New SuperEntidad
        iCchEN = iCchRN.EsValidoDesaprobarMes(Me.ListarCuentaCorrienteHistoricoMes())
        If iCchEN.EsVerdad = False Then
            MsgBox(iCchEN.Mensaje, MsgBoxStyle.Exclamation, "Diferencia cambio")
        End If
        Return iCchEN.EsVerdad
    End Function

    Function ListarCuentaCorrienteHistoricoMes() As List(Of SuperEntidad)
        Dim iCchRN As New CuentaCorrienteHistoricoRN
        Dim iCchEN As New SuperEntidad
        iCchEN.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        iCchEN.CampoOrden = cam.ClaveCtaCteHis
        Return iCchRN.ListarCuentaCorrienteHistoricoXPeriodo(iCchEN)
    End Function

    Sub GeneraRegistroContableCabecera()
        'TRAER EL ULTIMO DIA DEL MES
        'TRAEMOS EL TIPO DE CAMBIO DEL ULTIMO DIA DEL MES DE PROCESO
        Dim iTipCamRN As New TipoCambioRN
        Dim iTipCamEN As New SuperEntidad
        iTipCamEN.AnoTipoCambio = Me.txtAno.Text.Trim
        iTipCamEN.MesTipoCambio = Me.txtCodMes.Text.Trim
        iTipCamEN = iTipCamRN.ObtenerUltimoDiaDelMes(iTipCamEN)

        Dim iRccRN As New RegContabCabeRN
        Dim iRccEN As New SuperEntidad
        iRccEN.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        iRccEN.CodigoEmpresa = Me.TxtCodEmp.Text
        iRccEN.CodigoOrigen = "3"
        iRccEN.CodigoFile = "399"
        iRccEN.DiaVoucherRegContabCabe = "01"
        iRccEN.FechaVoucherRegContabCabe = iTipCamEN.FechaTipoCambio
        iRccEN.GlosaRegContabCabe = "Diferencia de cambio"
        'defecto
        iRccEN.CodigoAuxiliar = ""
        iRccEN.TipoDocumento = ""
        iRccEN.SerieDocumento = ""
        iRccEN.NumeroDocumento = ""
        iRccEN.FechaDocumento = Today.Date
        iRccEN.VentaTipoCambio = 1
        iRccEN.VentaEurTipoCambio = 1
        iRccEN.CodigoModoPago = ""
        iRccEN.CodigoCuentaBanco = ""
        iRccEN.MonedaDocumento = "S/."
        'Igv
        Dim iParRN As New ParametroRN
        Dim iParEN As New SuperEntidad
        iRccEN.IgvPar = iParRN.buscarParametroExis(iParEN).IgvPar
        iRccEN.PrecioVtaRegContabCabe = 0
        iRccEN.ExoneradoRegContabCabe = 0
        iRccEN.IgvRegContabCabe = 0
        iRccEN.ValorVtaRegContabCabe = 0
        iRccEN.DetraccionRegContabCabe = ""
        iRccEN.NumeroPapeletaRegContabCabe = ""
        iRccEN.FechaDetraccionRegContabCabe = ""
        iRccEN.RetencionRegContabCabe = ""
        iRccEN.EstadoRegContabCabe = ""
        iRccEN.CartaRegContabCabe = ""
        iRccEN.DescripcionRegContabCabe = ""
        iRccEN.VoucherIngresoRegContabCabe = ""
        iRccEN.SumaDebeRegContabCabe = 0
        iRccEN.SumaHaberRegContabCabe = 0
        iRccEN.UltimoCorrelativo = "0000" '(Me.dgvRegDia.Rows.Count - 1).ToString.PadLeft(4, CType("0", Char))
        'Datos por notas de credito
        iRccEN.TipoDocumento1 = ""
        iRccEN.SerieDocumento1 = ""
        iRccEN.NumeroDocumento1 = ""
        iRccEN.MonedaDocumento1 = ""
        iRccEN.FechaDocumento1 = ""
        iRccEN.FechaVencimiento = Today.Date
        iRccEN.ModoCompra = ""
        'Correlativo voucher
        Dim vou As New VoucherRN
        Dim aut As New SuperEntidad
        aut.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        aut.AnoVoucher = iRccEN.PeriodoRegContabCabe.Substring(0, 4)
        aut.CodigoMes = iRccEN.PeriodoRegContabCabe.Substring(4, 2)
        aut.CodigoFile = "399"
        iRccEN.NumeroVoucherRegContabCabe = vou.obtenerVoucherAutogenerado(aut)
        iRccEN.EstadoRegistro = "0" 'normal
        iRccEN.EstadoRegContabCabe = "1"
        iRccRN.nuevoRegContabCabe(iRccEN)
        iClaveRcc = iRccEN.ClaveRegContabCabe
    End Sub

    Sub GenerarRegistrosContablesDetalle()
        Me.iCompras = ""
        Me.iVentas = ""
        LisVen.Clear()

        'TRAEMOS AL OBJETO PARAMETRO PARA SACAR LAS CUENTAS DE PERDIDA Y GANANCIA POR DIFERENCIA DE CAMBIO
        Dim iParRN As New ParametroRN
        Dim iParEN As New SuperEntidad
        iParEN = iParRN.buscarParametroExis(iParEN)

        'TRAEMOS EL TIPO DE CAMBIO DEL ULTIMO DIA DEL MES DE PROCESO
        Dim iTipCamRN As New TipoCambioRN
        Dim iTipCamEN As New SuperEntidad
        iTipCamEN.AnoTipoCambio = Me.txtAno.Text.Trim
        iTipCamEN.MesTipoCambio = Me.txtCodMes.Text.Trim
        iTipCamEN = iTipCamRN.ObtenerUltimoTipoCambioDelMes(iTipCamEN)

        '' Traer EL REPORTE DE DIFERENCIA DE CAMBIO
        Dim iCueCorHisRN As New CuentaCorrienteHistoricoRN
        Dim iCueCorHisEN As New SuperEntidad
        iCueCorHisEN.AnoTipoCambio = Me.txtAno.Text.Trim
        iCueCorHisEN.MesTipoCambio = Me.txtCodMes.Text.Trim
        iCueCorHisEN.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        Dim ilisRes As New List(Of SuperEntidad)
        ilisRes = iCueCorHisRN.ReporteXMesDiferenciaCambio(iCueCorHisEN)

        Dim n As Integer = 0
        'ARMANDO UN ASIENTO POR CADA OBJETO DE LA LISTA
        Dim iRcdRN As New RegContabDetaRN
        Dim iDet As SuperEntidad
        For Each xObj As SuperEntidad In ilisRes

            'SOLO CUENTAS CORRIENTES QUE TIENE DIFERENCIA DE CAMBIO
            If xObj.SumaDebeRegContabCabe <> 0 Or xObj.SumaHaberRegContabCabe <> 0 Then

                Dim idb As String = ""
                'VER SI ES COMPRA O VENTA Y MARCAR EL FLAG PARA LUEGO HAECR LOS VOUCHER
                If xObj.CodigoOrigen = "4" Or xObj.CodigoOrigen = "6" Then
                    iCompras = "1"
                End If

                If xObj.CodigoOrigen = "5" Then
                    iVentas = "1"
                End If

                'CREAMOS AL PRIMER OBJETO
                Dim iRcdEN As SuperEntidad
                iRcdEN = New SuperEntidad
                iRcdEN.ClaveRegContabCabe = iClaveRcc
                n += 1
                iRcdEN.CorrelativoRegContabDeta = (n).ToString.PadLeft(4, CType("0", Char))
                iRcdEN.PeriodoRegContabCabe = xObj.PeriodoRegContabCabe
                iRcdEN.CodigoOrigen = "3"
                iRcdEN.CodigoFile = "399"
                iRcdEN.CodigoCuentaPcge = xObj.CodigoCuentaPcge
                iRcdEN.CodigoAuxiliar = xObj.CodigoAuxiliar
                'DEBE O HABER
                'SEGUN DIFERENCIA DE CAMBIO
                If xObj.SumaHaberRegContabCabe <> 0 Then
                    iRcdEN.DebeHaberRegContabDeta = "0" 'haber
                    idb = "1"
                Else
                    iRcdEN.DebeHaberRegContabDeta = "1" 'debe
                    idb = "0"
                End If

                If xObj.SumaDebeRegContabCabe = 0 Then
                    iRcdEN.ImporteSRegContabDeta = xObj.SumaHaberRegContabCabe
                Else
                    iRcdEN.ImporteSRegContabDeta = xObj.SumaDebeRegContabCabe
                End If
                iRcdEN.ImporteDRegContabDeta = 0
                iRcdEN.ImporteERegContabDeta = 0
                iRcdEN.TipoDocumento = xObj.TipoDocumento
                iRcdEN.SerieDocumento = xObj.SerieDocumento
                iRcdEN.NumeroDocumento = xObj.NumeroDocumento
                iRcdEN.FechaDocumento = xObj.FechaDocumento
                'SEGUN MONEDA
                Select Case xObj.MonedaDocumento
                    Case "US$"
                        iRcdEN.VentaTipoCambio = xObj.VentaTipoCambio
                        iRcdEN.VentaEurTipoCambio = 0
                    Case "EUR"
                        iRcdEN.VentaTipoCambio = 0
                        iRcdEN.VentaEurTipoCambio = xObj.VentaTipoCambio
                End Select

                iRcdEN.CodigoIngEgr = ""
                iRcdEN.GlosaRegContabDeta = "diferencia de cambio"
                iRcdEN.CodigoCentroCosto = "999101"
                iRcdEN.Exporta = ""
                iRcdEN.CodigoArea = ""
                ''defecto
                iRcdEN.Cuenta1242 = ""
                iRcdEN.EstadoRegContabDeta = ""
                iRcdEN.CodigoFlujoCaja = ""
                iRcdRN.nuevoRegContabDeta(iRcdEN)

                iDet = New SuperEntidad
                iDet = iRcdEN
                iDet.CodigoOrigen = xObj.CodigoOrigen
                LisVen.Add(iDet)

                'CREAMOS AL SEGUNDO OBJETO
                iRcdEN = New SuperEntidad
                iRcdEN.ClaveRegContabCabe = iClaveRcc
                n += 1
                iRcdEN.CorrelativoRegContabDeta = (n).ToString.PadLeft(4, CType("0", Char))
                iRcdEN.PeriodoRegContabCabe = xObj.PeriodoRegContabCabe
                iRcdEN.CodigoOrigen = "3"
                iRcdEN.CodigoFile = "399"
                'PARA LA CUENTA DE GANANCIA O PERDIDA
                If xObj.CodigoOrigen = "4" Or xObj.CodigoOrigen = "6" Then
                    If xObj.SumaHaberRegContabCabe <> 0 Then
                        iRcdEN.CodigoCuentaPcge = iParEN.CuentaPerdidaDC
                    Else
                        iRcdEN.CodigoCuentaPcge = iParEN.CuentaGananciaDC
                    End If
                Else
                    If xObj.SumaHaberRegContabCabe <> 0 Then
                        iRcdEN.CodigoCuentaPcge = iParEN.CuentaPerdidaDC
                    Else
                        iRcdEN.CodigoCuentaPcge = iParEN.CuentaGananciaDC
                    End If
                End If
                iRcdEN.CodigoAuxiliar = xObj.CodigoAuxiliar
                'DEBE O HABER
                iRcdEN.DebeHaberRegContabDeta = idb
                If xObj.SumaDebeRegContabCabe = 0 Then
                    iRcdEN.ImporteSRegContabDeta = xObj.SumaHaberRegContabCabe
                Else
                    iRcdEN.ImporteSRegContabDeta = xObj.SumaDebeRegContabCabe
                End If
                iRcdEN.ImporteDRegContabDeta = 0
                iRcdEN.ImporteERegContabDeta = 0
                iRcdEN.TipoDocumento = xObj.TipoDocumento
                iRcdEN.SerieDocumento = xObj.SerieDocumento
                iRcdEN.NumeroDocumento = xObj.NumeroDocumento
                iRcdEN.FechaDocumento = xObj.FechaDocumento
                'SEGUN MONEDA
                Select Case xObj.MonedaDocumento
                    Case "US$"
                        iRcdEN.VentaTipoCambio = xObj.VentaEurTipoCambio
                        iRcdEN.VentaEurTipoCambio = 0
                    Case "EUR"
                        iRcdEN.VentaTipoCambio = 0
                        iRcdEN.VentaEurTipoCambio = xObj.VentaEurTipoCambio
                End Select

                iRcdEN.CodigoIngEgr = ""
                iRcdEN.GlosaRegContabDeta = "diferencia de cambio"
                iRcdEN.CodigoCentroCosto = "999101"
                iRcdEN.Exporta = ""
                iRcdEN.CodigoArea = ""
                ''defecto
                iRcdEN.Cuenta1242 = ""
                iRcdEN.EstadoRegContabDeta = ""
                iRcdEN.CodigoFlujoCaja = ""
                iRcdRN.nuevoRegContabDeta(iRcdEN)

                iDet = New SuperEntidad
                iDet = iRcdEN
                iDet.CodigoOrigen = xObj.CodigoOrigen
                LisVen.Add(iDet)
            End If
        Next
        '
    End Sub

    Sub ModificarTipoCambioCuentaCorrienteXMes()
        'TRAEMOS EL TIPO DE CAMBIO DEL ULTIMO DIA DEL MES DE PROCESO
        Dim iTipCamRN As New TipoCambioRN
        Dim iTipCamEN As New SuperEntidad
        iTipCamEN.AnoTipoCambio = Me.txtAno.Text.Trim
        iTipCamEN.MesTipoCambio = Me.txtCodMes.Text.Trim
        iTipCamEN = iTipCamRN.ObtenerUltimoTipoCambioDelMes(iTipCamEN)

        'TRAER TODAS LAS CUENTAS CORRIENTES DEL MES (SOLO EN DOLARES)
        Dim iCueCorRN As New CuentaCorrienteRN
        Dim iCueCorEN As New SuperEntidad
        iCueCorEN.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        iCueCorEN.CampoOrden = cam.ClaveDocuCtaCte
        Dim iLisCueCor As List(Of SuperEntidad) = iCueCorRN.ListarCuentasCorrientesXEmpresaXDolaresYPendientes(iCueCorEN)

        'PASAR CADA UNA DE ESTAS CUENTAS CORRINETES A CUENTAS CORRIENTES HISTORICO
        For Each xobj As SuperEntidad In iLisCueCor
            If xobj.MonedaDocumento <> "" Then
                xobj.VentaTipoCambio = iTipCamEN.VentaTipoCambio
                xobj.VentaEurTipoCambio = iTipCamEN.VentaEurTipoCambio
                iCueCorRN.modificarCuentaCorriente(xobj)
            End If
        Next
    End Sub

    Sub ModificarCuentaCorrienteHistorico()
        Dim iCueCorHisRN As New CuentaCorrienteHistoricoRN
        Dim iLisCueCorHis As List(Of SuperEntidad) = Me.ListarCuentaCorrienteHistoricoMes
        For Each xObj As SuperEntidad In iLisCueCorHis
            xObj.EstadoCuentaCorrienteHistorico = "1"
            iCueCorHisRN.modificarCuentaCorrienteHistoricoXClave(xObj)
        Next
    End Sub

    Sub DesdoblarVoucher()

        '  MsgBox(Me.iCompras + " " + Me.iVentas + " " + Me.LisVen.Count.ToString)

        Dim iRccRN As New RegContabCabeRN
        Dim iRccEN As New SuperEntidad
        iRccEN.ClaveRegContabCabe = Me.iClaveRcc
        iRccEN = iRccRN.buscarRegContabExisPorClave(iRccEN)
        'SE DESDOBLA EL VOUVHER SOLO SI HAY COMPRAS Y VENTAS (AMBAS)
        'SI NO SE MODIFICA LA UNICA QUE HAY EN SU GLOSA(CUENTAS POR PAGAR O CUENTAS POR COBRAR)
        If iCompras = "1" Then
            'QUIERE DECIR QUE SI HAY COMPRAS POR LO TANTO EL VOUCHER CREADO SERA CUENTAS POR PAGAR
            iRccEN.GlosaRegContabCabe = "Diferencia de cambio Cuenta por Pagar"
            iRccRN.modificarRegContab(iRccEN)
        End If

        If iCompras = "" And iVentas = "1" Then
            'QUIERE DECIR QUE SOLO HAY VENTAS POR LO TANTO EL VOUCHER CREADO SERA CUENTAS POR COBRAR
            iRccEN.GlosaRegContabCabe = "Diferencia de cambio Cuenta por Cobrar"
            iRccRN.modificarRegContab(iRccEN)
        End If

        If iCompras = "1" And iVentas = "1" Then
            'CREAMOS EL VOUCHER PARA VENTAS
            'Correlativo voucher
            Dim vou As New VoucherRN
            Dim aut As New SuperEntidad
            aut.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
            aut.AnoVoucher = iRccEN.PeriodoRegContabCabe.Substring(0, 4)
            aut.CodigoMes = iRccEN.PeriodoRegContabCabe.Substring(4, 2)
            aut.CodigoFile = "399"
            iRccEN.NumeroVoucherRegContabCabe = vou.obtenerVoucherAutogenerado(aut)
            iRccEN.GlosaRegContabCabe = "Diferencia de cambio Cuenta por Cobrar"
            iRccRN.nuevoRegContabCabe(iRccEN)



            'CAMBIAMOS LOS ASIENTOS DE VENTAS A ESTE NUEVO VOUCHER
            Dim iRcdRN As New RegContabDetaRN
            'Dim iRcdEN As New SuperEntidad
            'iRcdEN.ClaveRegContabCabe = Me.iClaveRcc
            'iRccEN.CampoOrden = cam.CodOriRC
            'Dim iLisRcd As List(Of SuperEntidad) = iRcdRN.obtenerDetalleRegContabPorClave(iRcdEN)

            'SOLO ALOS DE ORIGEN 5 CAMBIARLOS
            For Each xObj As SuperEntidad In LisVen

                If xObj.CodigoOrigen = "5" Then
                    iRcdRN.EliminarRegistroDetalleXClaveDetalle(xObj)
                    xObj.ClaveRegContabCabe = iRccEN.ClaveRegContabCabe
                    iRcdRN.nuevoRegContabDeta(xObj)
                End If
            Next
        End If
    End Sub

    Sub AprobarDiferenciaCambio()
        'PRIMERO SABER SI SE PUEDE APROBAR EL MES
        If Me.EsValidoAprobarMes = False Then Exit Sub

        'PREGUNTAR SI DESEA REALIZAR LA OPERACION
        Dim rpta As Integer = MsgBox("Solo se puede aprobar una vez,Deseas Aprobar el mes", MsgBoxStyle.YesNo)
        If rpta = MsgBoxResult.No Then Exit Sub

        'GENERAR EL REGISTRO CONTABLE CABECERA
        Me.GeneraRegistroContableCabecera()

        'GENERAR LOS REGISTROS CONTABLES DETALLE
        Me.GenerarRegistrosContablesDetalle()

        'MODIFICAR LAS CUENTAS CORRIENTES HISTORICAS A APROBADAS
        Me.ModificarCuentaCorrienteHistorico()

        'MODIFICAR EL NUEVO TIPO DE CAMBIO A LAS CUENTAS CORRIENTES
        Me.ModificarTipoCambioCuentaCorrienteXMes()

        'DESDOBLAR EL VOUCHER SI FUERA NECESARIO
        Me.DesdoblarVoucher()

        MsgBox("La aprobacion se realizo con exito")

    End Sub

    Sub DesaprobarDiferenciaCambio()
        'PRIMERO SABER SI SE PUEDE DESAPROBAR EL MES
        If Me.EsValidoDesaprobarMes = False Then Exit Sub

        'PREGUNTAR SI DESEA REALIZAR LA OPERACION
        Dim rpta As Integer = MsgBox("Deseas Desaprobar el mes", MsgBoxStyle.YesNo)
        If rpta = MsgBoxResult.No Then Exit Sub

        'ELIMINAR DETALLE DIFERENCIA DE CAMBIO
        Me.EliminarDetalleDiferenciaCambio()

        'MODIFICAR CUENTAS CORRIENTES
        Me.DevolverTipoDeCambioOriginal()

        'DESAPROBAR CUENTA CORRIENTE HISTORICO
        Me.DesaprobarCuentaCorienteHistorico()

        MsgBox("La Desaprobacion se realizo con exito")
    End Sub

    Sub Ejecutar()
        If Me.eVentana = 0 Then
            Me.DesaprobarDiferenciaCambio()
        Else
            Me.AprobarDiferenciaCambio()
        End If
    End Sub

    Sub EliminarDetalleDiferenciaCambio()
        Dim iRcdRN As New RegContabDetaRN
        Dim iRcdEN As New SuperEntidad
        iRcdEN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iRcdEN.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        iRcdEN.CodigoFile = "399"
        iRcdEN.CampoOrden = cam.ClaveRCC
        iRcdRN.EliminarVouchersPorDiferenciaCambioAutomatico(iRcdEN)
    End Sub

    Sub DevolverTipoDeCambioOriginal()
        'TRAER TODAS LAS CUENTAS CORRIENTES DEL MES (SOLO EN DOLARES)
        Dim iCueCorRN As New CuentaCorrienteRN
        Dim iCueCorEN As New SuperEntidad
        iCueCorEN.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        iCueCorEN.CampoOrden = cam.ClaveDocuCtaCte
        Dim iLisCueCor As List(Of SuperEntidad) = iCueCorRN.ListarCuentasCorrientesXEmpresaXDolaresYPendientes(iCueCorEN)

        Dim iCueCorHisRN As New CuentaCorrienteHistoricoRN
        Dim iLisCueCorHis As List(Of SuperEntidad) = Me.ListarCuentaCorrienteHistoricoMes

        'PASAR CADA UNA DE ESTAS CUENTAS CORRINETES A CUENTAS CORRIENTES HISTORICO
        Dim icc As New SuperEntidad
        For Each xobj As SuperEntidad In iLisCueCor
            For Each xobjH As SuperEntidad In iLisCueCorHis
                If xobj.ClaveDocumentoCuentaCorriente = xobjH.ClaveDocumentoCuentaCorriente Then
                    xobj.VentaTipoCambio = xobjH.VentaTipoCambio
                    xobj.VentaEurTipoCambio = xobjH.VentaEurTipoCambio
                End If
            Next
            iCueCorRN.modificarCuentaCorriente(xobj)
        Next
    End Sub

    Sub DesaprobarCuentaCorienteHistorico()
        Dim iCueCorHisRN As New CuentaCorrienteHistoricoRN
        Dim iLisCueCorHis As List(Of SuperEntidad) = Me.ListarCuentaCorrienteHistoricoMes
        For Each xObj As SuperEntidad In iLisCueCorHis
            xObj.EstadoCuentaCorrienteHistorico = "0"
            iCueCorHisRN.modificarCuentaCorrienteHistoricoXClave(xObj)
        Next
    End Sub

#End Region



#Region "Mostrar Form Lista"

    Private Sub txtCodMes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodMes.KeyDown
        If Me.txtCodMes.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarTabla
                win.tabla = "Mes"
                win.titulo = "Meses"
                win.txt1 = Me.txtCodMes
                win.txt2 = Me.txtDesMes
                win.ctrlFoco = Me.txtCodMes
                win.NuevaVentana()
            End If
        End If
    End Sub

#End Region

#Region "Buscar Por Codigo"

    Private Sub txtCodMes_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodMes.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.txtCodMes : ope.txt2 = Me.txtDesMes
        ope.MostrarCodigoDescripcionDeTabla("Mes", "Meses", e)
    End Sub

#End Region

    Private Sub WPersonalRecycla_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Me.Owner.Enabled = True
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.Ejecutar()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class