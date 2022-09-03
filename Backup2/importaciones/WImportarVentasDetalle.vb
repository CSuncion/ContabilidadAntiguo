Imports System.Data.OleDb
Imports System.Xml
Imports Entidad
Imports Negocio

Public Class WImportarVentasDetalle

    Public lista As New List(Of SuperEntidad)
    Public rCD As New RegContabDetaRN
    Public cam As New CamposEntidad
    Public ent As New SuperEntidad
    Dim sheetNo As String
    Sub Grabar()
        Dim entd As New SuperEntidad
        Dim wmes As DateTime
        Dim wtc As String
        Dim wdol As String
        Dim wfecha As String
        Dim xanoperiodo, xmesperiodo, xcant As String

        If Me.dgvExcel.Rows.Count <> 1 Then

            For n As Integer = 0 To Me.dgvExcel.Rows.Count - 2
                entd.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
                wmes = CType(Me.dgvExcel.Item(5, n).Value.ToString.Trim, Date)
                xcant = Me.dgvExcel.Item(13, n).Value.ToString.Trim
                entd.FechaVoucherRegContabCabe = CType(Me.dgvExcel.Item(5, n).Value.ToString, Date)
                entd.CodigoOrigen = Me.dgvExcel.Item(0, n).Value.ToString.Trim
                entd.CodigoFile = entd.CodigoOrigen + Me.dgvExcel.Item(1, n).Value.ToString.Trim
                xanoperiodo = entd.FechaVoucherRegContabCabe.Year.ToString
                xmesperiodo = entd.FechaVoucherRegContabCabe.Month.ToString.PadLeft(2, CType("0", Char))
                ' xmesperiodo = "00"
                entd.CorrelativoRegContabDeta = Me.dgvExcel.Item(4, n).Value.ToString.Trim.PadLeft(4, CType("0", Char))
                entd.ClaveRegContabCabe = entd.CodigoEmpresa + xanoperiodo + xmesperiodo + entd.CodigoOrigen + entd.CodigoFile + Me.dgvExcel.Item(3, n).Value.ToString.Trim.Substring(1)
                entd.ClaveRegContabDeta = entd.ClaveRegContabCabe + entd.CorrelativoRegContabDeta
                entd.CodigoCuentaPcge = Me.dgvExcel.Item(7, n).Value.ToString.Trim
                entd.CodigoAuxiliar = Me.dgvExcel.Item(8, n).Value.ToString.Trim
                entd.CodigoCentroCosto = Me.dgvExcel.Item(9, n).Value.ToString.Trim
                entd.TipoDocumento = Me.dgvExcel.Item(16, n).Value.ToString.Trim
                entd.SerieDocumento = Me.dgvExcel.Item(17, n).Value.ToString.Trim
                If entd.SerieDocumento = String.Empty Then
                    entd.SerieDocumento = "0001"
                Else
                    If entd.SerieDocumento.Substring(0, 1) = "B" Or entd.SerieDocumento.Substring(0, 1) = "E" Or entd.SerieDocumento.Substring(0, 1) = "F" Then
                        entd.SerieDocumento = entd.SerieDocumento.Substring(0, 1) + "0" + entd.SerieDocumento.Substring(1, 2)
                    Else
                        entd.SerieDocumento = Me.dgvExcel.Item(17, n).Value.ToString.PadLeft(4, CType("0", Char))
                    End If
                End If
                entd.NumeroDocumento = Me.dgvExcel.Item(18, n).Value.ToString.PadLeft(15, CType("0", Char))
                wfecha = Me.dgvExcel.Item(19, n).Value.ToString
                If wfecha = String.Empty Then
                    entd.FechaDocumento = CType("01/01/2016", Date)
                Else
                    entd.FechaDocumento = CType(Me.dgvExcel.Item(19, n).Value.ToString, Date)
                End If


                wtc = Me.dgvExcel.Item(11, n).Value.ToString.Trim
                If wtc <> "" Then
                    entd.VentaTipoCambio = CType(Me.dgvExcel.Item(11, n).Value.ToString.Trim, Decimal)
                Else
                    entd.VentaTipoCambio = 1
                End If
                entd.CodigoCuentaPcge = Me.dgvExcel.Item(7, n).Value.ToString.Trim
                entd.DebeHaberRegContabDeta = Me.dgvExcel.Item(12, n).Value.ToString.Trim
                If entd.DebeHaberRegContabDeta = "D" Then
                    entd.DebeHaberRegContabDeta = "Debe"
                Else
                    entd.DebeHaberRegContabDeta = "Haber"
                End If
                entd.ImporteSRegContabDeta = CType(Me.dgvExcel.Item(14, n).Value.ToString.Trim, Decimal)
                wdol = Me.dgvExcel.Item(15, n).Value.ToString.Trim
                If wdol <> "" Then
                    entd.ImporteDRegContabDeta = CType(Me.dgvExcel.Item(15, n).Value.ToString.Trim, Decimal)
                Else
                    entd.ImporteDRegContabDeta = 0
                End If
                entd.ImporteERegContabDeta = 0
                entd.GlosaRegContabDeta = Me.dgvExcel.Item(20, n).Value.ToString.Trim
                entd.CodigoIngEgr = Me.dgvExcel.Item(22, n).Value.ToString.Trim
                entd.Cuenta1242 = "GHV"
                If entd.CodigoOrigen = "5" Then
                    If entd.CodigoCuentaPcge.Substring(0, 2) = "40" Or entd.CodigoCuentaPcge.Substring(0, 2) = "12" Or entd.CodigoCuentaPcge.Substring(0, 2) = "13" Then
                        entd.EstadoRegContabDeta = "1"
                    Else
                        entd.EstadoRegContabDeta = "0"
                    End If
                Else
                    entd.EstadoRegContabDeta = "0"
                End If
                entd.CodigoArea = Me.dgvExcel.Item(21, n).Value.ToString.Trim
                entd.CodigoFlujoCaja = "" 'Me.dgvExcel.Item(27, n).Value.ToString.Trim
                entd.VentaEurTipoCambio = 0
                entd.Cantidad = 0
                entd.Exporta = "0"
                rCD.nuevoRegContabDeta(entd)
            Next
        End If
        MsgBox("La importacion del DETALLE VENTAS se realizo con exito")
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