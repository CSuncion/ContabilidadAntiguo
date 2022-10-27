Imports System.Data.OleDb
Imports System.Xml
Imports Entidad
Imports Negocio

Public Class WImportarBoletasVentaNuevo

    Public lista As New List(Of SuperEntidad)
    Public rCC As New RegContabCabeRN
    Public rCD As New RegContabDetaRN
    Public aux As New AuxiliarRN
    Public emp As New EmpresaRN
    Public vou As New VoucherRN
    Public par As New ParametroRN
    Public ccte As New CuentaCorrienteRN
    Public cam As New CamposEntidad
    Public acc As New Accion
    Public ent, ParEnt, entcab As New SuperEntidad
    Dim sheetNo As String

    Sub InicializaVentana()
        ''Para los eventos de controles
        'acc.listaCtrls = Me.ListaControles
        'acc.PasaFoco()
        'acc.FomatoDato()
        'acc.PasarCursor()
        'acc.Teclazo()
        'acc.Valida()
        Me.PorDefecto()
        Me.Show()
    End Sub

    Sub PorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.txtNomEmp.Text = SuperEntidad.xRazonSocial
        Me.TxtPeri.Text = SuperEntidad.xPeriodoEmpresa
        ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        ent = emp.BuscarEmpresaXCodigo(ent)

        ParEnt = par.buscarParametroExis(ParEnt)

        Me.TxtCtaPreVta.Text = ParEnt.Cuenta16PrecioVentaEmpresa  ''"1692000"
        Me.TxtCtaValVta.Text = ParEnt.Cuenta75ValorVentaEmpresa   '' "7591116"
        Me.TxtCtaValIgv.Text = ParEnt.CuentaIgvEmpresa            ''"4011111"
        Me.TxtCodOriVta.Text = ParEnt.CodigoOrigenVentas
        Me.TxtCodFilVta.Text = ParEnt.CodigoFileVentas

    End Sub

    Sub EliminarAntesDeProcesar()
        ''eLIMINAR cABECERA
        Dim iRcc As New SuperEntidad
        iRcc.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iRcc.PeriodoRegContabCabe = Me.TxtPeri.Text
        iRcc.CodigoOrigen = ParEnt.CodigoOrigenVentas
        iRcc.CodigoFile = ParEnt.CodigoFileVentas
        rCC.EliminarRegContabCabePeriodoOrigenYFile(iRcc)

        ''Eliminar DetLLE
        Dim iRcd As New SuperEntidad
        iRcd.ClaveRegContabCabe += SuperEntidad.xCodigoEmpresa
        iRcd.ClaveRegContabCabe += Me.TxtPeri.Text
        iRcd.ClaveRegContabCabe += ParEnt.CodigoOrigenVentas
        iRcd.ClaveRegContabCabe += ParEnt.CodigoFileVentas
        rCD.EliminarRegContabDetaXGastoOperativo(iRcd)

        ''Eliminar Cuenta Corriente
        Dim iCcte As New SuperEntidad
        iCcte.ClaveCuentaCorriente += SuperEntidad.xCodigoEmpresa
        iCcte.ClaveCuentaCorriente += Me.TxtPeri.Text.Trim
        iCcte.ClaveCuentaCorriente += ParEnt.CodigoOrigenVentas
        iCcte.ClaveCuentaCorriente += ParEnt.CodigoFileVentas
        ccte.EliminarCuentaCorrienteXGastoOperativo(iCcte)

    End Sub

    Function ValidarVoucher() As Boolean
        Dim iRcc As New SuperEntidad
        iRcc.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        iRcc.PeriodoRegContabCabe = Me.TxtPeri.Text
        iRcc.CodigoOrigen = Me.TxtCodOriVta.Text.Trim
        iRcc.CodigoFile = Me.TxtCodFilVta.Text.Trim
        iRcc.NumeroVoucherRegContabCabe = Me.TxtNumero.Text.Trim.PadLeft(6, CType("0", Char))
        iRcc.ClaveRegContabCabe = iRcc.CodigoEmpresa + iRcc.PeriodoRegContabCabe + iRcc.CodigoOrigen + iRcc.CodigoFile + iRcc.NumeroVoucherRegContabCabe
        entcab = rCC.BuscarRegContabCabeXClave(iRcc)
        If entcab.ClaveRegContabCabe = "" Then
            Return True
        Else
            MsgBox("Numero Voucher Ya Esta Registrado, Corrija Numero Voucher", MsgBoxStyle.Information, "Importacion")
            Me.TxtNumero.Focus()
            Return False
        End If
    End Function

    Sub Grabar()
        Dim entd As New SuperEntidad
        Dim entc As New SuperEntidad
        Dim ent As New SuperEntidad
        Dim entcc As New SuperEntidad

        'Dim wNumero As Integer = Convert.ToInt32(Me.TxtNumero.Text) - 1

        ''Eliminnado lo grabado en la cabecera y bdetalle
        Me.EliminarAntesDeProcesar()  ''  Luego Analizar

        'Buscamos si este voucher existe en la BD
        If Me.ValidarVoucher = False Then Exit Sub

        Dim wNumero As Integer = Convert.ToInt32(Me.TxtNumero.Text) - 1

        ''Empezando a Grabar
        If Me.dgvExcel.Rows.Count <> 1 Then

            For n As Integer = 0 To Me.dgvExcel.Rows.Count - 2

                entc.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
                entc.PeriodoRegContabCabe = Me.TxtPeri.Text
                entc.CodigoOrigen = ParEnt.CodigoOrigenVentas
                entc.CodigoFile = ParEnt.CodigoFileVentas

                wNumero += 1 ''Numero Voucher

                entc.NumeroVoucherRegContabCabe = CType(wNumero, String).PadLeft(6, CType("0", Char))

                entc.FechaVoucherRegContabCabe = CType(Me.dgvExcel.Item(1, n).Value.ToString, Date)
                entc.ClaveRegContabCabe = entc.CodigoEmpresa + Me.TxtPeri.Text + entc.CodigoOrigen + entc.CodigoFile + entc.NumeroVoucherRegContabCabe
                entc.CodigoAuxiliar = Me.dgvExcel.Item(6, n).Value.ToString
                entc.DescripcionAuxiliar = Me.dgvExcel.Item(5, n).Value.ToString
                entc.TipoDocumento = Me.dgvExcel.Item(7, n).Value.ToString
                If entc.TipoDocumento = "Boleta" Then
                    entc.TipoDocumento = "03"
                Else
                    entc.TipoDocumento = "01"
                End If
                entc.SerieDocumento = Me.dgvExcel.Item(8, n).Value.ToString.PadLeft(4, CType("0", Char))
                entc.NumeroDocumento = Me.dgvExcel.Item(9, n).Value.ToString.PadLeft(7, CType("0", Char))
                entc.FechaDocumento = CType(Me.dgvExcel.Item(1, n).Value.ToString, Date)
                entc.DiaVoucherRegContabCabe = entc.FechaVoucherRegContabCabe.Day.ToString.PadLeft(2, CType("0", Char))
                entc.FechaVctoDocumento = Me.dgvExcel.Item(1, n).Value.ToString
                entc.MonedaDocumento = "0" ''Me.dgvExcel.Item(17, n).Value.ToString
                entc.TipoDocumento1 = ""
                entc.SerieDocumento1 = ""
                entc.NumeroDocumento1 = ""
                entc.FechaDocumento1 = ""
                entc.MonedaDocumento1 = "0"
                entc.VentaTipoCambio = 1 ''CType(Me.dgvExcel.Item(11, n).Value.ToString, Decimal)
                entc.VentaEurTipoCambio = 1
                entc.IgvPar = ParEnt.IgvPar
                entc.PrecioVtaRegContabCabe = CType(Me.dgvExcel.Item(17, n).Value.ToString, Decimal)
                entc.IgvRegContabCabe = CType(Me.dgvExcel.Item(15, n).Value.ToString, Decimal)
                entc.ExoneradoRegContabCabe = CType(Me.dgvExcel.Item(12, n).Value.ToString, Decimal)
                ' entc.ValorVtaRegContabCabe = CType(Me.dgvExcel.Item(7, n).Value.ToString, Decimal)
                entc.ValorVtaRegContabCabe = entc.PrecioVtaRegContabCabe - entc.IgvRegContabCabe - entc.ExoneradoRegContabCabe
                entc.PrecioVtaSolRegContabCabe = CType(Me.dgvExcel.Item(17, n).Value.ToString, Decimal)
                entc.IgvSolRegContabCabe = CType(Me.dgvExcel.Item(15, n).Value.ToString, Decimal)
                entc.ExoneradoSolRegContabCabe = CType(Me.dgvExcel.Item(12, n).Value.ToString, Decimal)
                entc.ValorVtaSolRegContabCabe = entc.PrecioVtaSolRegContabCabe - entc.IgvSolRegContabCabe - entc.ExoneradoSolRegContabCabe
                If (entc.PrecioVtaSolRegContabCabe = 0) Then

                    MsgBox(entc.PrecioVtaRegContabCabe.ToString(), MsgBoxStyle.Critical)

                    entc.GlosaRegContabCabe = "ANULADO"
                Else
                    entc.GlosaRegContabCabe = "VENTA AL PUBLICO" ''Me.dgvExcel.Item(19, n).Value.ToString
                End If
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
                entc.SumaDebeRegContabCabe = entc.PrecioVtaSolRegContabCabe
                entc.SumaHaberRegContabCabe = entc.PrecioVtaSolRegContabCabe
                entc.UltimoCorrelativo = "0003"
                entc.Exporta = "1"
                entc.EstadoRegistro = "0"
                entc.EliminadoRegistro = ""
                entc.FlagDescuentoRegContabCabe = "2"
                entc.CodigoAfp = ""
                entc.ImporteDescuentoRegContabCabe = 0
                entc.DescuentoFondo = 0
                entc.DescuentoSalud = 0
                entc.DescuentoRemu = 0
                entc.CodigoCuentaBanco = Me.TxtCtaPreVta.Text ''  "1692000"  ''Cuenta del precio venta
                entc.CodigoIngEgr = ""

                ''GRABAR CABECERA REGISTRO VENTA
                rCC.nuevoRegContabCabe(entc)

                ''si Numero Documento Auxiliar es diferente blanco 
                ''Se cheka si el Auxiliar existe si no existe entonces se adicona a la tabla
                If entc.CodigoAuxiliar <> "" Then
                    ent = aux.buscarAuxiliarExisPorCodigo(entc)
                    If ent.CodigoAuxiliar = "" Then
                        ent.CodigoAuxiliar = entc.CodigoAuxiliar
                        ent.DescripcionAuxiliar = entc.DescripcionAuxiliar
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

                ''Grabar Cuenta Corriente
                entcc.PeriodoRegContabCabe = Me.TxtPeri.Text
                entcc.CodigoEmpresa = entc.CodigoEmpresa
                entcc.CodigoOrigen = entc.CodigoOrigen
                entcc.CodigoFile = entc.CodigoFile
                entcc.NumeroVoucherRegContabCabe = entc.NumeroVoucherRegContabCabe
                entcc.CodigoAuxiliar = entc.CodigoAuxiliar
                entcc.TipoDocumento = entc.TipoDocumento
                entcc.SerieDocumento = entc.SerieDocumento
                entcc.NumeroDocumento = entc.NumeroDocumento
                entcc.FechaDocumento = entc.FechaDocumento
                entcc.VentaTipoCambio = entc.VentaTipoCambio
                entcc.VentaEurTipoCambio = entc.VentaEurTipoCambio
                entcc.CodigoCuentaPcge = Me.TxtCtaPreVta.Text.Trim
                entcc.FechaVctoDocumento = entc.FechaVctoDocumento  ''FormatoFecha.AñoMesDia(Me.DtpFechaVcto.Value.Date)
                entcc.MonedaDocumento = entc.MonedaDocumento
                entcc.ImporteOriginalCuentaCorriente = entc.PrecioVtaRegContabCabe
                entcc.ImportePagadoCuentaCorriente = 0
                entcc.SaldoCuentaCorriente = entc.PrecioVtaRegContabCabe
                entcc.EstadoCuentaCorriente = "1" 'Pendiente de pago 
                ''Grabar Cuenta Corriente
                ccte.nuevoCuentaCorriente(entcc)

                ''Grabar Detalle
                ''Primero la cuenta valor venta 69 0 70 o 12 si es adelanto
                ''Esta cuenta viene en el excel
                entd.ClaveRegContabCabe = entc.ClaveRegContabCabe
                entd.ClaveRegContabDeta = entc.ClaveRegContabCabe + entc.NumeroVoucherRegContabCabe
                entd.CorrelativoRegContabDeta = "0001"
                entd.CodigoIngEgr = ""
                entd.CodigoAuxiliar = entc.CodigoAuxiliar
                entd.TipoDocumento = entc.TipoDocumento
                entd.SerieDocumento = entc.SerieDocumento
                entd.NumeroDocumento = entc.NumeroDocumento
                entd.FechaDocumento = entc.FechaDocumento
                entd.VentaTipoCambio = entc.VentaTipoCambio
                entd.VentaEurTipoCambio = entc.VentaEurTipoCambio
                ' entd.CodigoCuentaPcge = Me.TxtCtaValVta.Text
                entd.CodigoCuentaPcge = Me.dgvExcel.Item(18, n).Value.ToString
                entd.CodigoCentroCosto = "" ''Me.dgvExcel.Item(18, n).Value.ToString
                entd.DebeHaberRegContabDeta = "0" ''haber
                entd.ImporteSRegContabDeta = entc.ValorVtaSolRegContabCabe + entc.ExoneradoSolRegContabCabe
                'Importe En Dolares Segun Moneda 0 = Soles 1 = US$
                If entc.MonedaDocumento = "0" Then
                    entd.ImporteDRegContabDeta = (entc.ValorVtaRegContabCabe + entc.ExoneradoRegContabCabe) / entc.VentaTipoCambio
                Else
                    entd.ImporteDRegContabDeta = (entc.ValorVtaRegContabCabe + entc.ExoneradoRegContabCabe)
                End If
                entd.ImporteERegContabDeta = 1
                entd.GlosaRegContabDeta = entc.GlosaRegContabCabe
                entd.Cuenta1242 = entc.CodigoCuentaBanco
                entd.EstadoRegContabDeta = "0" '' Se muestra en la grila detalle
                entd.EstadoRegistro = "1"
                entd.Exporta = "1"
                entd.MontoMoneda = 0
                entd.MontoSoles = 0
                ''Graba Registro Valor Venta
                rCD.nuevoRegContabDeta(entd)

                ''primero la cuenta 40 Igv
                If entc.IgvRegContabCabe = 0 Then
                Else
                    ''primero la cuenta 40 Igv
                    entd.ClaveRegContabCabe = entc.ClaveRegContabCabe
                    entd.ClaveRegContabDeta = entc.ClaveRegContabCabe + entc.NumeroVoucherRegContabCabe
                    entd.CorrelativoRegContabDeta = "0002"
                    entd.CodigoIngEgr = ""
                    entd.CodigoAuxiliar = entc.CodigoAuxiliar
                    entd.TipoDocumento = entc.TipoDocumento
                    entd.SerieDocumento = entc.SerieDocumento
                    entd.NumeroDocumento = entc.NumeroDocumento
                    entd.FechaDocumento = entc.FechaDocumento
                    entd.VentaTipoCambio = entc.VentaTipoCambio
                    entd.VentaEurTipoCambio = entc.VentaEurTipoCambio
                    entd.CodigoCuentaPcge = Me.TxtCtaValIgv.Text
                    entd.CodigoCentroCosto = ""
                    entd.DebeHaberRegContabDeta = "0" ''haber
                    entd.ImporteSRegContabDeta = entc.IgvSolRegContabCabe
                    'Importe En Dolares Segun Moneda 0 = Soles 1 = US$
                    If entc.MonedaDocumento = "0" Then
                        entd.ImporteDRegContabDeta = (entc.IgvRegContabCabe) / entc.VentaTipoCambio
                    Else
                        entd.ImporteDRegContabDeta = entc.IgvRegContabCabe
                    End If
                    entd.ImporteERegContabDeta = 1
                    entd.GlosaRegContabDeta = entc.GlosaRegContabCabe
                    entd.Cuenta1242 = ""
                    entd.EstadoRegContabDeta = "1"
                    entd.EstadoRegistro = "1"
                    entd.Exporta = "1"
                    entd.MontoMoneda = 0
                    entd.MontoSoles = 0
                    ''Graba Registro Valor Igv
                    rCD.nuevoRegContabDeta(entd)
                End If

                ''tercero la cuenta 12 o 16
                entd.CorrelativoRegContabDeta = "0003"
                entd.ClaveRegContabCabe = entc.ClaveRegContabCabe
                entd.ClaveRegContabDeta = entc.ClaveRegContabCabe + entc.CorrelativoRegContabDeta
                entd.CodigoIngEgr = ""
                entd.CodigoAuxiliar = entc.CodigoAuxiliar
                entd.TipoDocumento = entc.TipoDocumento
                entd.SerieDocumento = entc.SerieDocumento
                entd.NumeroDocumento = entc.NumeroDocumento
                entd.FechaDocumento = entc.FechaDocumento
                entd.VentaTipoCambio = entc.VentaTipoCambio
                entd.VentaEurTipoCambio = entc.VentaEurTipoCambio
                entd.CodigoCuentaPcge = Me.TxtCtaPreVta.Text
                entd.CodigoCentroCosto = ""
                entd.DebeHaberRegContabDeta = "1" ''Debe
                entd.ImporteSRegContabDeta = entc.PrecioVtaSolRegContabCabe
                'Importe En Dolares Segun Moneda 0 = Soles 1 = US$
                If entc.MonedaDocumento = "0" Then
                    entd.ImporteDRegContabDeta = (entc.PrecioVtaRegContabCabe) / entc.VentaTipoCambio
                Else
                    entd.ImporteDRegContabDeta = entc.PrecioVtaRegContabCabe
                End If
                entd.ImporteERegContabDeta = 1
                entd.GlosaRegContabDeta = entc.GlosaRegContabCabe
                entd.Cuenta1242 = ""
                entd.EstadoRegContabDeta = "1"
                entd.EstadoRegistro = "1"
                entd.Exporta = "1"
                entd.MontoMoneda = 0
                entd.MontoSoles = 0

                ''Graba Registro Precio Venta
                rCD.nuevoRegContabDeta(entd)
            Next
            'numero voucher autogenerado
            Dim aut As New SuperEntidad
            aut.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
            aut.AnoVoucher = Me.TxtPeri.Text.Substring(0, 4)
            aut.CodigoFile = ParEnt.CodigoFileVentas
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

        End If

        MsgBox("La importacion se realizo con exito")
        Me.btnImportar.Enabled = False
    End Sub

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
            'para agregar o modificar
            If acc.CamposObligatorios = False Then
                Exit Sub
            Else
                If Me.TxtNumero.Text.Length = 0 Then
                    MsgBox("Ingrese Numero de Voucher", MsgBoxStyle.DefaultButton1, "Importacion Ventas")
                    Me.TxtNumero.Focus()
                Else
                    Me.Grabar()
                End If
            End If
            ' ''Me.Grabar()
        End If

    End Sub
End Class