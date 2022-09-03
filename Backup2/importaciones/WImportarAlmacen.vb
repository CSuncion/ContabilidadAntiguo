Imports System.Data.OleDb
Imports System.Xml
Imports Entidad
Imports Negocio

Public Class WImportarAlmacen

    Public lista As New List(Of SuperEntidad)
    Public aux As New GastoReparableRN
    Public cam As New CamposEntidad
    Public ent As New SuperEntidad
    Dim sheetNo As String

    Sub Grabar()
        Dim entd As New SuperEntidad
        'Dim wFecha As DateTime

        If Me.dgvExcel.Rows.Count <> 1 Then
            For n As Integer = 0 To Me.dgvExcel.Rows.Count - 2

                If Me.dgvExcel.Item(0, n).Value.ToString <> "" Then

                    entd.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
                    entd.CodigoGastoReparable = Me.dgvExcel.Item(0, n).Value.ToString
                    entd.ClaveGastoReparable = entd.CodigoEmpresa + entd.CodigoGastoReparable
                    entd.Almacen = Me.dgvExcel.Item(1, n).Value.ToString
                    entd.NombreGastoReparable = Me.dgvExcel.Item(2, n).Value.ToString
                    entd.Unidad = Me.dgvExcel.Item(3, n).Value.ToString
                    entd.EstadoGastoReparable = "1"
                    entd.Exporta = "0"
                    aux.nuevaGastoReparable(entd)

                End If

            Next
        End If
        MsgBox("La importacion CODIGO ALMACEN se realizo con exito")
        Me.btnImportar.Enabled = False
    End Sub

    Sub LoadExcel(ByVal dgv As DataGridView, ByVal sbook As String, ByVal sSheet As String)
        '        Dim cs As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & sbook & ";" & "Extended Properties=""Excel 8.0;HDR=YES"""
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