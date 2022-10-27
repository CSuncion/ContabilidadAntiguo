Imports System.Data.OleDb
Imports System.Xml
Imports Entidad
Imports Negocio

Public Class WImportarVentasCabecera

    Public lista As New List(Of SuperEntidad)
    Public rCC As New RegContabCabeRN
    Public cam As New CamposEntidad
    Public ent As New SuperEntidad
    Dim sheetNo As String
    Sub Grabar()
        Dim entd As New SuperEntidad
        'Dim wfecha As String
        'Dim wprecio As String
        'Dim wporigv As String
        Dim wtc As String
        'Dim wsdh As String
        Dim xanoperiodo As String
        Dim xmesperiodo As String
        Dim xdebe, xImporte, xExo As String
        Dim xValVta As Decimal = 0
        If Me.dgvExcel.Rows.Count <> 1 Then

            For n As Integer = 0 To Me.dgvExcel.Rows.Count - 2

                entd.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
                entd.FechaVoucherRegContabCabe = CType(Me.dgvExcel.Item(4, n).Value.ToString, Date)
                xanoperiodo = entd.FechaVoucherRegContabCabe.Year.ToString
                xmesperiodo = entd.FechaVoucherRegContabCabe.Month.ToString.PadLeft(2, CType("0", Char))
                entd.PeriodoRegContabCabe = xanoperiodo + xmesperiodo
                entd.CodigoOrigen = Me.dgvExcel.Item(0, n).Value.ToString.Trim
                entd.CodigoFile = entd.CodigoOrigen + Me.dgvExcel.Item(1, n).Value.ToString.Trim
                entd.NumeroVoucherRegContabCabe = Me.dgvExcel.Item(3, n).Value.ToString.Trim.Substring(1)
                entd.ClaveRegContabCabe = entd.CodigoEmpresa + entd.PeriodoRegContabCabe + entd.CodigoOrigen + entd.CodigoFile + entd.NumeroVoucherRegContabCabe
                entd.UltimoCorrelativo = Me.dgvExcel.Item(8, n).Value.ToString.Trim.PadLeft(4, CType("0", Char))
                entd.MonedaVoucherRegContabCabe = ""
                entd.DiaVoucherRegContabCabe = entd.FechaVoucherRegContabCabe.Day.ToString.PadLeft(2, CType("0", Char))
                entd.CodigoAuxiliar = Me.dgvExcel.Item(19, n).Value.ToString.Trim
                entd.ImporteRegContabCabe = CType(Me.dgvExcel.Item(13, n).Value.ToString.Trim, Decimal)
                entd.TipoDocumento = Me.dgvExcel.Item(20, n).Value.ToString.Trim
                entd.SerieDocumento = Me.dgvExcel.Item(21, n).Value.ToString.Trim
                entd.NumeroDocumento = Me.dgvExcel.Item(22, n).Value.ToString.Trim.PadLeft(15, CType("0", Char))
                entd.MonedaDocumento = Me.dgvExcel.Item(17, n).Value.ToString.Trim
                If entd.MonedaDocumento = "" Or entd.MonedaDocumento = "1" Or entd.MonedaDocumento = "S" Then
                    entd.MonedaDocumento = "0"
                Else
                    entd.MonedaDocumento = "1"
                End If
                entd.FechaDocumento = CType(Me.dgvExcel.Item(5, n).Value.ToString, Date)
                entd.FechaVencimiento = CType(Me.dgvExcel.Item(5, n).Value.ToString, Date)
                wtc = Me.dgvExcel.Item(7, n).Value.ToString.Trim
                If wtc <> "" Then
                    entd.VentaTipoCambio = CType(Me.dgvExcel.Item(7, n).Value.ToString.Trim, Decimal)
                Else
                    entd.VentaTipoCambio = 1
                End If
                entd.VentaEurTipoCambio = 1
                entd.IgvPar = CType(Me.dgvExcel.Item(14, n).Value.ToString.Trim, Decimal)

                entd.PrecioVtaRegContabCabe = CType(Me.dgvExcel.Item(13, n).Value.ToString.Trim, Decimal)
                entd.IgvRegContabCabe = CType(Me.dgvExcel.Item(15, n).Value.ToString.Trim, Decimal)
                entd.ValorVtaRegContabCabe = entd.PrecioVtaRegContabCabe - entd.IgvRegContabCabe   'CType(Me.dgvExcel.Item(16, n).Value.ToString.Trim, Decimal) - CType(Me.dgvExcel.Item(18, n).Value.ToString.Trim, Decimal)
                xExo = Me.dgvExcel.Item(18, n).Value.ToString.Trim
                If xExo = String.Empty Then
                    ent.ExoneradoRegContabCabe = 0
                Else
                    ent.ExoneradoRegContabCabe = CType(Me.dgvExcel.Item(18, n).Value.ToString.Trim, Decimal)
                End If
                entd.PrecioVtaSolRegContabCabe = Math.Round(entd.PrecioVtaRegContabCabe * entd.VentaTipoCambio, 2)
                entd.IgvSolRegContabCabe = Math.Round(entd.IgvRegContabCabe * entd.VentaTipoCambio, 2)
                entd.ExoneradoSolRegContabCabe = Math.Round(entd.ExoneradoRegContabCabe * entd.VentaTipoCambio, 2)
                entd.ValorVtaSolRegContabCabe = entd.PrecioVtaSolRegContabCabe - entd.IgvSolRegContabCabe - entd.ExoneradoSolRegContabCabe
                entd.GlosaRegContabCabe = "Ventas Locales"

                If entd.CodigoFile = "407" Or entd.CodigoFile = "408" Or entd.CodigoFile = "507" Or entd.CodigoFile = "508" Then
                    entd.TipoDocumento1 = Me.dgvExcel.Item(28, n).Value.ToString.Trim
                    entd.SerieDocumento1 = Me.dgvExcel.Item(29, n).Value.ToString.Trim
                    entd.NumeroDocumento1 = Me.dgvExcel.Item(30, n).Value.ToString.Trim
                    entd.FechaDocumento1 = Me.dgvExcel.Item(31, n).Value.ToString.Trim
                Else
                    entd.TipoDocumento1 = String.Empty
                    entd.SerieDocumento1 = String.Empty
                    entd.NumeroDocumento1 = String.Empty
                    entd.FechaDocumento1 = String.Empty
                End If
                entd.CodigoCuentaBanco = "1201011" 'Me.dgvExcel.Item(41, n).Value.ToString.Trim
                xImporte = Me.dgvExcel.Item(9, n).Value.ToString.Trim
                If xImporte = String.Empty Then
                    entd.ImporteRegContabCabe = 0
                Else
                    entd.ImporteRegContabCabe = CType(Me.dgvExcel.Item(9, n).Value.ToString.Trim, Decimal)
                End If

                xdebe = Me.dgvExcel.Item(9, n).Value.ToString.Trim
                If xdebe = String.Empty Then
                    entd.ImporteSolRegContabCabe = 0
                Else
                    entd.ImporteSolRegContabCabe = CType(Me.dgvExcel.Item(9, n).Value.ToString.Trim, Decimal)
                End If
                entd.DetraccionRegContabCabe = "0"
                entd.NumeroPapeletaRegContabCabe = String.Empty
                entd.FechaDetraccionRegContabCabe = String.Empty
                entd.CodigoModoPago = String.Empty ''Me.dgvExcel.Item(40, n).Value.ToString.Trim
                entd.CartaRegContabCabe = "GHV"
                entd.DescripcionRegContabCabe = "Ventas Locales"
                entd.VoucherIngresoRegContabCabe = ""
                entd.EstadoRegContabCabe = "2"
                entd.EstadoRegistro = "0"
                If xdebe = String.Empty Then
                    entd.SumaDebeRegContabCabe = 0
                    entd.SumaHaberRegContabCabe = 0
                Else
                    entd.SumaDebeRegContabCabe = CType(Me.dgvExcel.Item(9, n).Value.ToString.Trim, Decimal)
                    entd.SumaHaberRegContabCabe = CType(Me.dgvExcel.Item(10, n).Value.ToString.Trim, Decimal)
                End If

                entd.CodigoIngEgr = ""
                entd.ModoCompra = String.Empty
                entd.FlagDescuentoRegContabCabe = String.Empty
                entd.CodigoAfp = String.Empty
                entd.ImporteDescuentoRegContabCabe = 0
                entd.DescuentoFondo = 0
                entd.DescuentoSalud = 0
                entd.DescuentoRemu = 0
                entd.Exporta = "1"
                entd.EliminadoRegistro = "1"
                rCC.nuevoRegContabCabe(entd)
            Next
        End If
        MsgBox("La importacion CABECERA se realizo con exito")
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
            Me.Grabar()
        End If

    End Sub
End Class