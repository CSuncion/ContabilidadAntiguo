Imports System.Data.OleDb
Imports System.Xml
Imports Entidad
Imports Negocio

Public Class WImportarCuentas
    Public lista As New List(Of SuperEntidad)
    Public plc As New PlanCuentaGeRN
    Public cam As New CamposEntidad
    Public ent As New SuperEntidad
    Dim sheetNo As String

    Sub Grabar()
        Dim entd As New SuperEntidad
        If Me.dgvExcel.Rows.Count <> 1 Then
            For n As Integer = 0 To Me.dgvExcel.Rows.Count - 2
                entd.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
                entd.CodigoCuentaPcge = Me.dgvExcel.Item(0, n).Value.ToString.Trim
                entd.NombreCuentaPcge = Me.dgvExcel.Item(1, n).Value.ToString.Trim
                entd.FlagDocumentoPcge = Me.dgvExcel.Item(2, n).Value.ToString
                If entd.FlagDocumentoPcge = "" Or entd.FlagDocumentoPcge = "No" Then
                    entd.FlagDocumentoPcge = "0"
                Else
                    entd.FlagDocumentoPcge = Me.dgvExcel.Item(2, n).Value.ToString
                End If
                entd.FlagAuxiliarPcge = Me.dgvExcel.Item(3, n).Value.ToString
                If entd.FlagAuxiliarPcge = "" Or entd.FlagAuxiliarPcge = "No" Then
                    entd.FlagAuxiliarPcge = "0"
                Else
                    entd.FlagAuxiliarPcge = Me.dgvExcel.Item(3, n).Value.ToString
                End If
                entd.FlagCentroCostoPcge = Me.dgvExcel.Item(4, n).Value.ToString.Trim
                If entd.FlagCentroCostoPcge = "" Or entd.FlagCentroCostoPcge = "No" Then
                    entd.FlagCentroCostoPcge = "0"
                Else
                    entd.FlagCentroCostoPcge = Me.dgvExcel.Item(4, n).Value.ToString.Trim
                End If
                entd.FlagAlmacenPcge = Me.dgvExcel.Item(5, n).Value.ToString.Trim
                If entd.FlagAlmacenPcge = "" Or entd.FlagAlmacenPcge = "No" Then
                    entd.FlagAlmacenPcge = "0"
                Else
                    entd.FlagAlmacenPcge = Me.dgvExcel.Item(5, n).Value.ToString.Trim
                End If
                entd.FlagAreaPcge = Me.dgvExcel.Item(6, n).Value.ToString.Trim
                If entd.FlagAreaPcge = "" Or entd.FlagAreaPcge = "No" Then
                    entd.FlagAreaPcge = "0"
                Else
                    entd.FlagAreaPcge = Me.dgvExcel.Item(6, n).Value.ToString.Trim
                End If
                entd.FlagFlujoCajaPcge = Me.dgvExcel.Item(7, n).Value.ToString
                If entd.FlagFlujoCajaPcge = "" Then
                    entd.FlagFlujoCajaPcge = "0"
                Else
                    entd.FlagFlujoCajaPcge = Me.dgvExcel.Item(7, n).Value.ToString
                End If
                entd.FlagAutomaticaPcge = Me.dgvExcel.Item(8, n).Value.ToString
                If entd.FlagAutomaticaPcge = "No" Or entd.FlagAutomaticaPcge = "" Then
                    entd.FlagAutomaticaPcge = "0"
                Else
                    entd.FlagAutomaticaPcge = "1"
                End If
                entd.CuentaAutomatica1Pcge = Me.dgvExcel.Item(9, n).Value.ToString
                entd.CuentaAutomatica2Pcge = Me.dgvExcel.Item(10, n).Value.ToString
                entd.FlagBancoPcge = Me.dgvExcel.Item(12, n).Value.ToString
                If entd.FlagBancoPcge = "No" Or entd.FlagBancoPcge = "" Then
                    entd.FlagBancoPcge = "0"
                Else
                    entd.FlagBancoPcge = "1"
                End If
                entd.ClaveFormatoContable = Me.dgvExcel.Item(13, n).Value.ToString
                If entd.ClaveFormatoContable.Length = 6 Then
                    entd.ClaveFormatoContable = entd.ClaveFormatoContable
                Else
                    entd.ClaveFormatoContable = ""
                End If
                entd.NumeroDigitosPcge = Me.dgvExcel.Item(14, n).Value.ToString
                'entd.FlagAlmacenPcge = Me.dgvExcel.Item(17, n).Value.ToString
                'If entd.FlagAlmacenPcge = "1" Then
                '    entd.FlagAlmacenPcge = "1"
                'Else
                '    entd.FlagAlmacenPcge = "0"
                'End If
                entd.FlagMonedaPcge = "0"
                entd.Exporta = "0"
                entd.FlagDifCambioPcge = "0"
                'entd.FlagFlujoCajaPcge = "0"
                'entd.FlagAreaPcge = "0"
                entd.EstadoCuenta = "0"
                entd.FlagBancoPcge = "0"
                'If entd.FlagAutomaticaPcge = "1" Then
                '    MsgBox(entd.CodigoCuentaPcge + "Cta" + entd.FlagAutomaticaPcge + "Aut" + entd.CuentaAutomatica1Pcge + "cta1" + entd.CuentaAutomatica2Pcge + "cta2")
                'End If
                plc.nuevaCuenta(entd)
            Next
        End If
        MsgBox("La importacion PLAN CUENTAS se realizo con exito")
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