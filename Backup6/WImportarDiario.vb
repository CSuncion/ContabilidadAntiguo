Imports System.Data.OleDb
Imports System.Xml
Imports Entidad
Imports Negocio

Public Class WImportarDiario


    Public lista As New List(Of SuperEntidad)
    Public rCC As New RegContabCabeRN
    Public rCD As New RegContabDetaRN
    Public aux As New AuxiliarRN
    Public emp As New EmpresaRN
    Public vou As New VoucherRN
    Public par As New ParametroRN
    Public ccte As New CuentaCorrienteRN
    Public cam As New CamposEntidad
    Public ent, ParEn, entcab As New SuperEntidad
    Public acc As New Accion
    Dim sheetNo As String

    Sub InicializaVentana()
        '/Para los eventos de controles
        'acc.listaCtrls = Me.ListaControles
        'acc.PasaFoco()
        'acc.FomatoDato()
        'acc.PasarCursor()
        'acc.Teclazo()
        'acc.Valida()
        Me.PorDefecto()
        Me.Show()
        Me.TxtNumero.Focus()
    End Sub

    Sub PorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.txtNomEmp.Text = SuperEntidad.xRazonSocial
        Me.TxtPeri.Text = SuperEntidad.xPeriodoEmpresa
        ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        ent = emp.BuscarEmpresaXCodigo(ent)

        ParEn = par.buscarParametroExis(ParEn)

        Me.TxtCodOri.Text = ParEn.CodigoOrigenDiario
        Me.TxtCodFil.Text = ParEn.CodigoFileDiario
        Me.TxtNumero.Text = "000001"
    End Sub

    Sub EliminarAntesDeProcesar()
        ''eLIMINAR cABECERA
        Dim iRcc As New SuperEntidad
        iRcc.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        iRcc.PeriodoRegContabCabe = Me.TxtPeri.Text
        iRcc.CodigoOrigen = Me.TxtCodOri.Text.Trim
        iRcc.CodigoFile = Me.TxtCodFil.Text.Trim
        rCC.EliminarRegContabCabePeriodoOrigenYFile(iRcc)

        ''Eliminar DetLLE
        Dim iRcd As New SuperEntidad
        iRcd.ClaveRegContabCabe += Me.TxtCodEmp.Text.Trim
        iRcd.ClaveRegContabCabe += Me.TxtPeri.Text
        iRcd.ClaveRegContabCabe += Me.TxtCodOri.Text.Trim
        iRcd.ClaveRegContabCabe += Me.TxtCodFil.Text.Trim
        rCD.EliminarRegContabDetaXGastoOperativo(iRcd)

        ''Eliminar Cuenta Corriente
        Dim iCcte As New SuperEntidad
        iCcte.ClaveCuentaCorriente += Me.TxtCodEmp.Text.Trim
        iCcte.ClaveCuentaCorriente += Me.TxtPeri.Text.Trim
        iCcte.ClaveCuentaCorriente += Me.TxtCodOri.Text.Trim
        iCcte.ClaveCuentaCorriente += Me.TxtCodFil.Text.Trim
        ccte.EliminarCuentaCorrienteXGastoOperativo(iCcte)

    End Sub

    Function ValidarVoucher() As Boolean
        Dim iRcc As New SuperEntidad
        iRcc.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        iRcc.PeriodoRegContabCabe = Me.TxtPeri.Text
        iRcc.CodigoOrigen = Me.TxtCodOri.Text.Trim
        iRcc.CodigoFile = Me.TxtCodFil.Text.Trim
        iRcc.NumeroVoucherRegContabCabe = Me.TxtNumero.Text.Trim.PadLeft(6, CType("0", Char))
        iRcc.ClaveRegContabCabe = iRcc.CodigoEmpresa + iRcc.PeriodoRegContabCabe + iRcc.CodigoOrigen + iRcc.CodigoFile + iRcc.NumeroVoucherRegContabCabe
        entcab = rCC.BuscarRegContabCabeXClave(iRcc)
        If entcab.ClaveRegContabCabe = "" Then
            Return True
        Else
            MsgBox("Numero Voucher Ya Esta Registrado, Corrrija el Numero", MsgBoxStyle.Information, "Importacion")
            Me.TxtNumero.Focus()
            Return False
        End If
    End Function

    Sub Grabar()
        Dim entd As New SuperEntidad
        Dim entc As New SuperEntidad
        Dim ent As New SuperEntidad
        Dim entcc As New SuperEntidad

        Dim wNumero As String = ""

        ''Eliminnado lo grabado en la cabecera y bdetalle
        Me.EliminarAntesDeProcesar()

        'Validamos la Longitud del Numero Voucher
        'If Me.ValidarLongitudNumeroVoucher = False Then Exit Sub

        'Buscamos si este voucher existe en la BD
        If Me.ValidarVoucher = False Then Exit Sub

        ''Datos para todos los vouchers
        entc.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        entc.PeriodoRegContabCabe = Me.TxtPeri.Text
        entc.CodigoOrigen = Me.TxtCodOri.Text.Trim
        entc.CodigoFile = Me.TxtCodFil.Text.Trim

        Dim wCorrelativo As Integer = 0
        'Dim m As Integer = 0
        Dim wSumaDebe As Decimal = 0
        Dim wSumaHaber As Decimal = 0
        Dim wNumeroVoucherInicio As String = ""

        'wNumeroVoucherInicio = Me.dgvExcel.Item(1, 0).Value.ToString.PadLeft(6, CType("0", Char))
        wNumeroVoucherInicio = Me.TxtNumero.Text.Trim.PadLeft(6, CType("0", Char))
        ''Empezando a Grabar
        If Me.dgvExcel.Rows.Count <> 1 Then

            For n As Integer = 0 To Me.dgvExcel.Rows.Count - 2

                wCorrelativo = wCorrelativo + 1
                'entc.GlosaRegContabCabe = Me.dgvExcel.Item(3, n).Value.ToString
                'entd.NumeroVoucherRegContabCabe = Me.dgvExcel.Item(1, n).Value.ToString.PadLeft(6, CType("0", Char))
                entd.NumeroVoucherRegContabCabe = Me.TxtNumero.Text.Trim.PadLeft(6, CType("0", Char)) ''Me.dgvExcel.Item(1, n).Value.ToString.PadLeft(6, CType("0", Char))
                entc.FechaVoucherRegContabCabe = CType(Me.dgvExcel.Item(11, n).Value.ToString, Date)
                entc.ClaveRegContabCabe = entc.CodigoEmpresa + Me.TxtPeri.Text + entc.CodigoOrigen + entc.CodigoFile + entd.NumeroVoucherRegContabCabe

                If wNumeroVoucherInicio = entd.NumeroVoucherRegContabCabe Then
                    entc.GlosaRegContabCabe = Me.dgvExcel.Item(2, n).Value.ToString
                End If

                ''Grabar Detalle
                entd.CorrelativoRegContabDeta = CType(wCorrelativo, String).PadLeft(4, CType("0", Char))
                entd.ClaveRegContabCabe = entc.ClaveRegContabCabe
                entd.ClaveRegContabDeta = entc.ClaveRegContabCabe + entd.CorrelativoRegContabDeta
                entd.CodigoIngEgr = ""
                entd.NombreUsuarioModifica = Me.dgvExcel.Item(6, n).Value.ToString ''Nombre del auxiliar
                entd.CodigoAuxiliar = Me.dgvExcel.Item(5, n).Value.ToString '' entc.CodigoAuxiliar
                ''''
                ''''
                ''si Numero Documento Auxiliar es diferente blanco 
                ''Se cheka si el Auxiliar existe si no existe entonces se adicona a la tabla
                If entd.CodigoAuxiliar <> "" Then
                    ent = aux.buscarAuxiliarExisPorCodigo(entd)
                    If ent.CodigoAuxiliar = "" Then
                        ent.CodigoAuxiliar = entd.CodigoAuxiliar
                        ent.DescripcionAuxiliar = entd.NombreUsuarioModifica
                        ent.ApellidoPaternoAuxiliar = ""
                        ent.ApellidoMaternoAuxiliar = ""
                        ent.PrimerNombreAuxiliar = ""
                        ent.SegundoNombreAuxiliar = ""
                        ent.DireccionAuxiliar = "SD"
                        ent.TelefonoAuxiliar = ""
                        ent.CelularAuxiliar = ""
                        ent.CorreoAuxiliar = ""
                        ent.ReferenciaAuxiliar = ""
                        ent.TipoAuxiliar = "3"
                        If (ent.CodigoAuxiliar.Trim).Length = 8 Then
                            ent.TipoDocumentoAuxiliar = "1"
                        Else
                            If (ent.CodigoAuxiliar).Trim.Length = 11 Then
                                ent.TipoDocumentoAuxiliar = "6"
                            Else
                                ent.TipoDocumentoAuxiliar = "4"
                            End If
                        End If
                        ent.EstadoAuxiliar = "1"
                        ent.EstadoRegistro = "1"
                        ent.Exporta = "0"
                        ent.EliminadoRegistro = "1"
                        ''Grabar Auxiliar
                        aux.nuevoAuxiliar(ent)
                    End If
                End If
                ''''
                ''''

                entd.TipoDocumento = Me.dgvExcel.Item(8, n).Value.ToString
                entd.SerieDocumento = Me.dgvExcel.Item(9, n).Value.ToString
                entd.NumeroDocumento = Me.dgvExcel.Item(10, n).Value.ToString.PadLeft(15, CType("0", Char))
                entd.FechaDocumento = CType(Me.dgvExcel.Item(11, n).Value.ToString, Date)
                entd.VentaTipoCambio = CType(Me.dgvExcel.Item(12, n).Value.ToString, Decimal)
                entd.VentaEurTipoCambio = 1
                entd.CodigoCuentaPcge = Me.dgvExcel.Item(14, n).Value.ToString
                entd.CodigoCentroCosto = Me.dgvExcel.Item(7, n).Value.ToString
                entd.DebeHaberRegContabDeta = Me.dgvExcel.Item(15, n).Value.ToString   ''1 = Debe, 0 = Haber               
                entd.ImporteSRegContabDeta = CType(Me.dgvExcel.Item(16, n).Value.ToString, Decimal)
                entd.ImporteDRegContabDeta = CType(Me.dgvExcel.Item(17, n).Value.ToString, Decimal)
                entd.ImporteERegContabDeta = 1
                If wNumeroVoucherInicio = entd.NumeroVoucherRegContabCabe Then
                    If entd.DebeHaberRegContabDeta = "1" Then
                        wSumaDebe += entd.ImporteSRegContabDeta
                    Else
                        wSumaHaber += entd.ImporteSRegContabDeta
                    End If
                End If
                'If entd.DebeHaberRegContabDeta = "1" Then
                '    wSumaDebe += entd.ImporteSRegContabDeta
                'Else
                '    wSumaHaber += entd.ImporteSRegContabDeta
                'End If
                '   MsgBox(entd.CodigoCentroCosto + " - " + entd.CorrelativoRegContabDeta + " - " + entd.ImporteSRegContabDeta.ToString, MsgBoxStyle.Critical, "Ver")
                entd.GlosaRegContabDeta = Me.dgvExcel.Item(19, n).Value.ToString
                entd.Cuenta1242 = ""
                entd.EstadoRegContabDeta = "0" '' Se muestra en la grila detalle
                entd.EstadoRegistro = "1"
                entd.Exporta = "1"
                entd.MontoMoneda = CType(Me.dgvExcel.Item(20, n).Value.ToString, Decimal)
                entd.MontoSoles = 0
                ''Graba Registro Detalle
                rCD.nuevoRegContabDeta(entd)
                'Next

                If entd.NumeroVoucherRegContabCabe <> wNumeroVoucherInicio Then
                    'Me.GrabarCabecera()

                    ' wNumero += 1 ''Numero Voucher
                    '  entc.SerieDocumento = Me.dgvExcel.Item(2, n).Value.ToString.PadLeft(6, CType("0", Char))

                    '   entc.NumeroVoucherRegContabCabe = CType(wNumero, String).PadLeft(6, CType("0", Char))
                    ' entc.ClaveRegContabCabe = entd.ClaveRegContabCabe ''Me.TxtCodEmp.Text + Me.TxtPeri.Text + Me.TxtCodOri.Text + Me.TxtCodFil.Text + entd.NumeroVoucherRegContabCabe
                    entc.ClaveRegContabCabe = Me.TxtCodEmp.Text + Me.TxtPeri.Text + Me.TxtCodOri.Text + Me.TxtCodFil.Text + wNumeroVoucherInicio
                    entc.NumeroVoucherRegContabCabe = wNumeroVoucherInicio
                    ' entc.NumeroVoucherRegContabCabe = entd.NumeroVoucherRegContabCabe
                    entc.CodigoAuxiliar = " "
                    entc.DescripcionAuxiliar = ""
                    entc.TipoDocumento = ""
                    entc.SerieDocumento = ""
                    entc.NumeroDocumento = ""
                    ' entc.FechaVoucherRegContabCabe = entc.FechaVoucherRegContabCabe
                    entc.FechaDocumento = entc.FechaVoucherRegContabCabe
                    entc.DiaVoucherRegContabCabe = entc.FechaVoucherRegContabCabe.Day.ToString.PadLeft(2, CType("0", Char))
                    entc.FechaVctoDocumento = entc.FechaVoucherRegContabCabe.ToShortDateString
                    entc.MonedaDocumento = "1"
                    entc.TipoDocumento1 = ""
                    entc.SerieDocumento1 = ""
                    entc.NumeroDocumento1 = ""
                    entc.FechaDocumento1 = ""
                    entc.MonedaDocumento1 = "0"
                    entc.VentaTipoCambio = entd.VentaTipoCambio
                    entc.VentaEurTipoCambio = 1
                    entc.IgvPar = 18
                    entc.PrecioVtaRegContabCabe = 0
                    entc.IgvRegContabCabe = 0
                    entc.ExoneradoRegContabCabe = 0
                    entc.ValorVtaRegContabCabe = 0
                    entc.PrecioVtaSolRegContabCabe = 0
                    entc.IgvSolRegContabCabe = 0
                    entc.ExoneradoSolRegContabCabe = 0
                    entc.ValorVtaSolRegContabCabe = 0
                    entc.RetencionRegContabCabe = "" 'Ver
                    entc.ImporteRegContabCabe = 0
                    entc.ImporteSRegContabDeta = 0
                    entc.DetraccionRegContabCabe = ""
                    entc.NumeroPapeletaRegContabCabe = ""
                    entc.FechaDetraccionRegContabCabe = ""
                    entc.ModoCompra = ""
                    entc.Descripcion1FormatoContable = ""
                    entc.CartaRegContabCabe = ""
                    entc.VoucherIngresoRegContabCabe = ""
                    entc.EstadoRegContabCabe = "1"
                    If wSumaDebe < wSumaHaber Then
                        entc.SumaDebeRegContabCabe = wSumaDebe
                        entc.SumaHaberRegContabCabe = wSumaDebe
                    Else
                        entc.SumaDebeRegContabCabe = wSumaHaber
                        entc.SumaHaberRegContabCabe = wSumaHaber
                    End If
                    'entc.SumaDebeRegContabCabe = wSumaDebe
                    'entc.SumaHaberRegContabCabe = wSumaHaber
                    entc.UltimoCorrelativo = entd.CorrelativoRegContabDeta
                    entc.Exporta = "1"
                    entc.EstadoRegistro = "1"
                    entc.EliminadoRegistro = ""
                    entc.FlagDescuentoRegContabCabe = "2"
                    entc.CodigoAfp = ""
                    entc.ImporteDescuentoRegContabCabe = 0
                    entc.DescuentoFondo = 0
                    entc.DescuentoSalud = 0
                    entc.DescuentoRemu = 0
                    entc.CodigoCuentaBanco = "" 'Me.TxtCodOri.Text ''  "1692000"  ''Cuenta del precio venta
                    entc.CodigoIngEgr = ""
                    ''Grabar Cabeera
                    rCC.nuevoRegContabCabe(entc)
                    'Inicializa Variables
                    wNumeroVoucherInicio = entd.NumeroVoucherRegContabCabe
                    wSumaDebe = 0
                    wSumaHaber = 0
                    wCorrelativo = 0
                End If
            Next
        End If
        entc.ClaveRegContabCabe = entd.ClaveRegContabCabe ''Me.TxtCodEmp.Text + Me.TxtPeri.Text + Me.TxtCodOri.Text + Me.TxtCodFil.Text + entd.NumeroVoucherRegContabCabe
        entc.NumeroVoucherRegContabCabe = entd.NumeroVoucherRegContabCabe
        entc.CodigoAuxiliar = " "
        entc.DescripcionAuxiliar = ""
        entc.TipoDocumento = ""
        entc.SerieDocumento = ""
        entc.NumeroDocumento = ""
        entc.FechaDocumento = entd.FechaVoucherRegContabCabe
        entc.DiaVoucherRegContabCabe = entc.FechaVoucherRegContabCabe.Day.ToString.PadLeft(2, CType("0", Char))
        entc.FechaVctoDocumento = entd.FechaDocumento.ToShortDateString
        entc.MonedaDocumento = "1"
        entc.TipoDocumento1 = ""
        entc.SerieDocumento1 = ""
        entc.NumeroDocumento1 = ""
        entc.FechaDocumento1 = ""
        entc.MonedaDocumento1 = "0"
        entc.VentaTipoCambio = entd.VentaTipoCambio
        entc.VentaEurTipoCambio = 1
        entc.IgvPar = 18
        entc.PrecioVtaRegContabCabe = 0
        entc.IgvRegContabCabe = 0
        entc.ExoneradoRegContabCabe = 0
        entc.ValorVtaRegContabCabe = 0
        entc.PrecioVtaSolRegContabCabe = 0
        entc.IgvSolRegContabCabe = 0
        entc.ExoneradoSolRegContabCabe = 0
        entc.ValorVtaSolRegContabCabe = 0
        entc.RetencionRegContabCabe = "" 'Ver
        entc.ImporteRegContabCabe = 0
        entc.ImporteSRegContabDeta = 0
        entc.DetraccionRegContabCabe = ""
        entc.NumeroPapeletaRegContabCabe = ""
        entc.FechaDetraccionRegContabCabe = ""
        entc.ModoCompra = ""
        entc.Descripcion1FormatoContable = ""
        entc.CartaRegContabCabe = ""
        entc.VoucherIngresoRegContabCabe = ""
        entc.EstadoRegContabCabe = "1"
        If wSumaDebe < wSumaHaber Then
            entc.SumaDebeRegContabCabe = wSumaDebe
            entc.SumaHaberRegContabCabe = wSumaDebe
        Else
            entc.SumaDebeRegContabCabe = wSumaHaber
            entc.SumaHaberRegContabCabe = wSumaHaber
        End If
        entc.UltimoCorrelativo = entd.CorrelativoRegContabDeta
        entc.Exporta = "1"
        entc.EstadoRegistro = "1"
        entc.EliminadoRegistro = ""
        entc.FlagDescuentoRegContabCabe = "2"
        entc.CodigoAfp = ""
        entc.ImporteDescuentoRegContabCabe = 0
        entc.DescuentoFondo = 0
        entc.DescuentoSalud = 0
        entc.DescuentoRemu = 0
        entc.CodigoCuentaBanco = "" 'Me.TxtCodOri.Text ''  "1692000"  ''Cuenta del precio venta
        entc.CodigoIngEgr = ""
        ''Grabar Cabeera
        rCC.nuevoRegContabCabe(entc)
        'numero voucher autogenerado
        wNumero = entc.NumeroVoucherRegContabCabe
        Dim aut As New SuperEntidad
        aut.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        aut.AnoVoucher = Me.TxtPeri.Text.Substring(0, 4)
        aut.CodigoFile = Me.TxtCodFil.Text.Trim
        aut.ClaveVoucher = aut.CodigoEmpresa
        aut.ClaveVoucher += aut.AnoVoucher
        aut.ClaveVoucher += aut.CodigoFile
        aut = vou.buscarVoucherExisPorCodigo(aut)

        Select Case Me.TxtPeri.Text.Substring(4)
            Case "01" : aut.EneroVoucher = wNumero.ToString.PadLeft(6, CType("0", Char))
            Case "02" : aut.FebreroVoucher = wNumero.ToString.PadLeft(6, CType("0", Char))
            Case "03" : aut.MarzoVoucher = wNumero.ToString.PadLeft(6, CType("0", Char))
            Case "04" : aut.AbrilVoucher = wNumero.ToString.PadLeft(6, CType("0", Char))
            Case "05" : aut.MayoVoucher = wNumero.ToString.PadLeft(6, CType("0", Char))
            Case "06" : aut.JunioVoucher = wNumero.ToString.PadLeft(6, CType("0", Char))
            Case "07" : aut.JulioVoucher = wNumero.ToString.PadLeft(6, CType("0", Char))
            Case "08" : aut.AgostoVoucher = wNumero.ToString.PadLeft(6, CType("0", Char))
            Case "09" : aut.SetiembreVoucher = wNumero.ToString.PadLeft(6, CType("0", Char))
            Case "10" : aut.OctubreVoucher = wNumero.ToString.PadLeft(6, CType("0", Char))
            Case "11" : aut.NoviembreVoucher = wNumero.ToString.PadLeft(6, CType("0", Char))
            Case "12" : aut.DiciembreVoucher = wNumero.ToString.PadLeft(6, CType("0", Char))
        End Select
        vou.modificarVoucher(aut)

        MsgBox("La importacion se realizo con exito")
        Me.btnImportar.Enabled = False
    End Sub

    'Sub GrabarCabecera()

    '    entc.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
    '    entc.CodigoOrigen = Me.TxtCodOri.Text.Trim
    '    entc.CodigoFile = Me.TxtCodFil.Text.Trim

    '    ' wNumero += 1 ''Numero Voucher
    '    '  entc.SerieDocumento = Me.dgvExcel.Item(2, n).Value.ToString.PadLeft(6, CType("0", Char))

    '    '   entc.NumeroVoucherRegContabCabe = CType(wNumero, String).PadLeft(6, CType("0", Char))
    '    ' entc.ClaveRegContabCabe = entd.ClaveRegContabCabe ''Me.TxtCodEmp.Text + Me.TxtPeri.Text + Me.TxtCodOri.Text + Me.TxtCodFil.Text + entd.NumeroVoucherRegContabCabe
    '    entc.ClaveRegContabCabe = Me.TxtCodEmp.Text + Me.TxtPeri.Text + Me.TxtCodOri.Text + Me.TxtCodFil.Text + wNumeroVoucherInicio
    '    entc.NumeroVoucherRegContabCabe = wNumeroVoucherInicio
    '    ' entc.NumeroVoucherRegContabCabe = entd.NumeroVoucherRegContabCabe
    '    entc.CodigoAuxiliar = " "
    '    entc.DescripcionAuxiliar = ""
    '    entc.TipoDocumento = ""
    '    entc.SerieDocumento = ""
    '    entc.NumeroDocumento = ""
    '    entc.FechaDocumento = entd.FechaVoucherRegContabCabe
    '    entc.DiaVoucherRegContabCabe = entc.FechaVoucherRegContabCabe.Day.ToString.PadLeft(2, CType("0", Char))
    '    entc.FechaVctoDocumento = entd.FechaDocumento.ToShortDateString
    '    entc.MonedaDocumento = "1"
    '    entc.TipoDocumento1 = ""
    '    entc.SerieDocumento1 = ""
    '    entc.NumeroDocumento1 = ""
    '    entc.FechaDocumento1 = ""
    '    entc.MonedaDocumento1 = "0"
    '    entc.VentaTipoCambio = entd.VentaTipoCambio
    '    entc.VentaEurTipoCambio = 1
    '    entc.IgvPar = 18
    '    entc.PrecioVtaRegContabCabe = 0
    '    entc.IgvRegContabCabe = 0
    '    entc.ExoneradoRegContabCabe = 0
    '    entc.ValorVtaRegContabCabe = 0
    '    entc.PrecioVtaSolRegContabCabe = 0
    '    entc.IgvSolRegContabCabe = 0
    '    entc.ExoneradoSolRegContabCabe = 0
    '    entc.ValorVtaSolRegContabCabe = 0
    '    entc.RetencionRegContabCabe = "" 'Ver
    '    entc.ImporteRegContabCabe = 0
    '    entc.ImporteSRegContabDeta = 0
    '    entc.DetraccionRegContabCabe = ""
    '    entc.NumeroPapeletaRegContabCabe = ""
    '    entc.FechaDetraccionRegContabCabe = ""
    '    entc.ModoCompra = ""
    '    entc.Descripcion1FormatoContable = ""
    '    entc.CartaRegContabCabe = ""
    '    entc.VoucherIngresoRegContabCabe = ""
    '    entc.EstadoRegContabCabe = "1"
    '    If wSumaDebe < wSumaHaber Then
    '        entc.SumaDebeRegContabCabe = wSumaDebe
    '        entc.SumaHaberRegContabCabe = wSumaDebe
    '    Else
    '        entc.SumaDebeRegContabCabe = wSumaHaber
    '        entc.SumaHaberRegContabCabe = wSumaHaber
    '    End If
    '    'entc.SumaDebeRegContabCabe = wSumaDebe
    '    'entc.SumaHaberRegContabCabe = wSumaHaber
    '    entc.UltimoCorrelativo = entd.CorrelativoRegContabDeta
    '    entc.Exporta = "1"
    '    entc.EstadoRegistro = "1"
    '    entc.EliminadoRegistro = ""
    '    entc.FlagDescuentoRegContabCabe = "2"
    '    entc.CodigoAfp = ""
    '    entc.ImporteDescuentoRegContabCabe = 0
    '    entc.DescuentoFondo = 0
    '    entc.DescuentoSalud = 0
    '    entc.DescuentoRemu = 0
    '    entc.CodigoCuentaBanco = "" 'Me.TxtCodOri.Text ''  "1692000"  ''Cuenta del precio venta
    '    entc.CodigoIngEgr = ""
    '    ''Grabar Cabeera
    '    rCC.nuevoRegContabCabe(entc)

    'End Sub
    Sub LoadExcel(ByVal dgv As DataGridView, ByVal sbook As String, ByVal sSheet As String)
        'Dim cs As String = "Provider=Microsoft.Jet.OLEDB.12.0;" & "Data Source=" & sbook & ";" & "Extended Properties=""Excel 12.0 xml;HDR=YES"""
        Dim cs As String = "Provider=Microsoft.Ace.OLEDB.12.0;" & "Data Source=" & sbook & ";" & "Extended Properties=""Excel 12.0 xml;HDR=YES"""
        Try
            Dim cn As New OleDbConnection(cs)
            If Not System.IO.File.Exists(sbook) Then
                MsgBox("No se encontro el libro" & sbook, MsgBoxStyle.Critical)
                Exit Sub
            End If
            Dim da As New OleDbDataAdapter("Select * From [" & sSheet & "$]", cs)
            Dim ds As New DataSet
            da.Fill(ds)
            Me.dgvExcel.DataSource = ds.Tables(0)

        Catch ex As Exception
            MsgBox("Error")
        End Try
    End Sub


    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        Me.OpenFileDialog1.DefaultExt = "*.xlsx"
        Me.OpenFileDialog1.Filter = "Excel|*.xlsx"
        Me.OpenFileDialog1.Multiselect = False
        If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub
        Me.txtLoad.Text = Me.OpenFileDialog1.FileName
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnVisualize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualize.Click
        'sheetNo = InputBox("Escriba el numero de hoja (sheet) que desea visualizar en la grilla", "Carga de datos al grid", "1")
        sheetNo = InputBox("Escriba el nombre de hoja (sheet) que desea visualizar en la grilla", "Carga de datos al grid", "")
        'Me.LoadExcel(Me.dgvExcel, Me.txtLoad.Text, "sheet" + sheetNo)
        Me.LoadExcel(Me.dgvExcel, Me.txtLoad.Text, sheetNo)

        'Me.ActualizarBarraEsatado()
    End Sub

    Private Sub btnImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.Click
        If Me.dgvExcel.RowCount = 0 Then
            MsgBox("No hay registros que importar", MsgBoxStyle.Exclamation)
        Else
            Me.Grabar()
        End If

    End Sub
End Class