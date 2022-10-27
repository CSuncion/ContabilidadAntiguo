Option Strict Off
Imports Negocio
Imports Entidad
'Imports Microsoft.Office.Interop.Excel
Imports System.Data.DataTable


Public Class WIngresoEgresoBanco

    Public ent, entCont, paren As New SuperEntidad
    Dim cb As New CuentaBancoRN
    Dim cam As New CamposEntidad
    Dim acc As New Accion
    Dim numerodigitos As String

    Sub InicializaVentana()
        '/Para los eventos de controles
        acc.listaCtrls = Me.ListaControles
        acc.PasaFoco()
        acc.FomatoDato()
        acc.PasarCursor()
        acc.Teclazo()
        acc.Valida()
        Me.Show()
        Me.PorDefecto()
        Me.txtCodMes.Focus()
        'acc.Nuevo()
    End Sub

    Sub PorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.txtNomEmp.Text = SuperEntidad.xRazonSocial
        Me.txtAno.Text = SuperEntidad.xPeriodoEmpresa.Substring(0, 4)
        
    End Sub

    Private Sub BtnEjecutar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEjecutar.Click
        Dim iCb As New SuperEntidad
        iCb.AnoCuentaBanco = Me.txtAno.Text.Trim
        iCb.MesCuentaBanco = Me.txtCodMes.Text.Trim
        iCb.PeriodoRegContabCabe = iCb.AnoCuentaBanco + iCb.MesCuentaBanco
        Select Case Rbt.radioActivo(Me.gbMoneda).Text.ToString.Trim()
            Case "S/." : iCb.MonedaCuentaBanco = "0"
            Case "US$" : iCb.MonedaCuentaBanco = "1"
            Case "EUR" : iCb.MonedaCuentaBanco = "2"
        End Select

        Dim iMoneda As String = Rbt.radioActivo(Me.gbMoneda).Text.ToString.Trim() '' "0"

        iCb.CampoOrden = cam.CodCtaBco
        Dim itabla As New DataTable
        itabla = cb.ArmarIngresoEgresoXBanco(iCb, iMoneda)
        Me.DataGridView1.DataSource = itabla
    End Sub

#Region "Mostrar Form Lista"

    Private Sub txtCodMes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodMes.KeyDown
        If Me.txtCodMes.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarTabla
                win.tabla = "Mes"
                win.titulo = "Meses"
                win.txt1 = Me.txtCodMes
                win.txt2 = Me.txtDesMes
                win.ctrlFoco = Me.gbMoneda
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

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Dim iCb As New SuperEntidad
    '    iCb.AnoCuentaBanco = "2012"
    '    iCb.MesCuentaBanco = "01"
    '    iCb.MonedaCuentaBanco = "0"
    '    iCb.CampoOrden = cam.CodCtaBco
    '    Dim itabla As New DataTable
    '    itabla = cb.ArmarIngresoEgresoXBanco(iCb, "S/.")
    '    Me.DataGridView1.DataSource = itabla
    'End Sub

    Function GridAExcel(ByVal ElGrid As DataGridView) As Boolean

        'Creamos las variables
        Dim exApp As New Microsoft.Office.Interop.Excel.Application
        Dim exLibro As Microsoft.Office.Interop.Excel.Workbook
        Dim exHoja As Microsoft.Office.Interop.Excel.Worksheet

        Try
            'Añadimos el Libro al programa, y la hoja al libro
            exLibro = exApp.Workbooks.Add()
            exHoja = exLibro.Worksheets.Add

            ' ¿Cuantas columnas y cuantas filas?
            Dim NCol As Integer = ElGrid.ColumnCount
            Dim NRow As Integer = ElGrid.RowCount

            'Aqui recorremos todas las filas, y por cada fila todas las columnas y vamos escribiendo.
            For i As Integer = 1 To NCol
                exHoja.Cells.Item(1, i) = ElGrid.Columns(i - 1).Name.ToString
                'exHoja.Cells.Item(1, i).HorizontalAlignment = 3
            Next

            For Fila As Integer = 0 To NRow - 1
                For Col As Integer = 0 To NCol - 1
                    exHoja.Cells.Item(Fila + 2, Col + 1) = ElGrid.Rows(Fila).Cells(Col).Value
                Next
            Next
            'Titulo en negrita, Alineado al centro y que el tamaño de la columna se
            'ajuste al texto
            exHoja.Rows.Item(1).Font.Bold = 1
            exHoja.Rows.Item(1).HorizontalAlignment = 3
            exHoja.Columns.AutoFit()

            'Aplicación visible
            exApp.Application.Visible = True

            exHoja = Nothing
            exLibro = Nothing
            exApp = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error al exportar a Excel")
            'http://programaciontotal.blogspot.com
            Return False
        End Try

        Return True

    End Function

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    Private Sub BtnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExcel.Click

        Me.GridAExcel(Me.DataGridView1)

        'MsgBox("Archivo Exportado", MsgBoxStyle.Information)

        'Dim xlApp As New Microsoft.Office.Interop.Excel.Application
        'Dim xlWorkBook As New Microsoft.Office.Interop.Excel.Workbook
        'Dim xlWorkSheet As New Microsoft.Office.Interop.Excel.Worksheet
        'Dim misValue As Object = System.Reflection.Missing.Value
        'Dim i As Integer
        'Dim j As Integer

        'xlApp = New Microsoft.Office.Interop.Excel.ApplicationClass
        'xlWorkBook = xlApp.Workbooks.Add(misValue)
        'xlWorkSheet = xlWorkBook.Sheets("sheet1")

        'For i = 0 To DataGridView1.RowCount - 2
        '    For j = 0 To DataGridView1.ColumnCount - 1
        '        xlWorkSheet.Cells(i + 1, j + 1) = _
        '            DataGridView1(j, i).Value.ToString()
        '    Next
        'Next

        'xlWorkSheet.SaveAs("C:\vbexcel.xlsx")
        'xlWorkBook.Close()
        'xlApp.Quit()

        'releaseObject(xlApp)
        'releaseObject(xlWorkBook)
        'releaseObject(xlWorkSheet)

        'MsgBox("You can find the file C:\vbexcel.xlsx")

    End Sub

End Class