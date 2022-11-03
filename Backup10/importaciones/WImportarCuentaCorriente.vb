Imports System.Data.OleDb
Imports System.Xml
Imports Entidad
Imports Negocio

Public Class WImportarCuentaCorriente

    Public lista As New List(Of SuperEntidad)
    Public rCC As New CuentaCorrienteRN
    Public cam As New CamposEntidad
    Public ent As New SuperEntidad
    Dim sheetNo As String
    Sub Grabar()
        Dim entd As New SuperEntidad
        Dim wprecio As Decimal = 0
        Dim wserie As Decimal = 0

        If Me.dgvExcel.Rows.Count <> 1 Then

            For n As Integer = 0 To Me.dgvExcel.Rows.Count - 2

                wserie = Me.dgvExcel.Item(12, n).Value.ToString.Trim.Length
                wprecio = CType(Me.dgvExcel.Item(28, n).Value.ToString.Trim, Decimal)
                If wprecio <> 0 Then
                    entd.CodigoEmpresa = Me.dgvExcel.Item(1, n).Value.ToString.Trim.PadLeft(3, CType("0", Char))
                    entd.PeriodoRegContabCabe = Me.dgvExcel.Item(2, n).Value.ToString.Trim
                    entd.CodigoOrigen = Me.dgvExcel.Item(3, n).Value.ToString.Trim
                    entd.CodigoFile = Me.dgvExcel.Item(4, n).Value.ToString.Trim
                    entd.NumeroVoucherRegContabCabe = Me.dgvExcel.Item(5, n).Value.ToString.Trim.PadLeft(5, CType("0", Char))
                    entd.CodigoAuxiliar = Me.dgvExcel.Item(10, n).Value.ToString.Trim
                    entd.TipoDocumento = Me.dgvExcel.Item(11, n).Value.ToString.Trim.PadLeft(2, CType("0", Char))
                    If wserie = 4 Then
                        entd.SerieDocumento = Me.dgvExcel.Item(12, n).Value.ToString.Trim
                    Else
                        entd.SerieDocumento = Me.dgvExcel.Item(12, n).Value.ToString.Trim.PadLeft(4, CType("0", Char))
                    End If

                    entd.NumeroDocumento = Me.dgvExcel.Item(13, n).Value.ToString.Trim.PadLeft(15, CType("0", Char))
                    entd.FechaDocumento = CType(Me.dgvExcel.Item(14, n).Value.ToString, Date)
                    entd.FechaVctoDocumento = Me.dgvExcel.Item(15, n).Value.ToString
                    entd.MonedaDocumento = Me.dgvExcel.Item(16, n).Value.ToString.Trim
                    entd.VentaTipoCambio = CType(Me.dgvExcel.Item(22, n).Value.ToString.Trim, Decimal)
                    entd.VentaTipoCambioOriginal = CType(Me.dgvExcel.Item(22, n).Value.ToString.Trim, Decimal)
                    entd.VentaEurTipoCambio = CType(Me.dgvExcel.Item(23, n).Value.ToString.Trim, Decimal)
                    entd.IgvPar = CType(Me.dgvExcel.Item(24, n).Value.ToString.Trim, Decimal)
                    entd.ImporteOriginalCuentaCorriente = CType(Me.dgvExcel.Item(28, n).Value.ToString.Trim, Decimal)
                    entd.ImportePagadoCuentaCorriente = 0
                    entd.SaldoCuentaCorriente = CType(Me.dgvExcel.Item(28, n).Value.ToString.Trim, Decimal)
                    entd.CodigoCuentaPcge = Me.dgvExcel.Item(35, n).Value.ToString.Trim

                    entd.ClaveCuentaCorriente = entd.CodigoEmpresa + entd.PeriodoRegContabCabe + entd.CodigoOrigen + entd.CodigoFile + entd.NumeroVoucherRegContabCabe
                    entd.ClaveDocumentoCuentaCorriente = entd.CodigoEmpresa + entd.CodigoAuxiliar + entd.TipoDocumento + entd.SerieDocumento + entd.NumeroDocumento
                    entd.EstadoCuentaCorriente = "1"
                    entd.EstadoRegistro = "0"
                    entd.Exporta = "1"
                    entd.ValorNotaCredito = 0
                    rCC.nuevoCuentaCorriente(entd)
                End If
            Next
        End If
        MsgBox("La importacion CUENTA CORRIENTE se realizo con exito")
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