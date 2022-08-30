Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports Entidad
Imports Negocio
Public Class WRptTab
#Region "Propietarios"
    Public wTab As New WTabla
#End Region
    Public ent As New SuperEntidad
    Dim rep As New ReportesTodosRN
    Dim cam As New CamposEntidad
    Dim ds As New DataSet1
    Dim tb As New DataTable
    Dim cr As New crRptTab
    Dim titulo As CrystalDecisions.CrystalReports.Engine.TextObject

    Sub PorPantalla()
        'Para el titulo del reporte
        titulo = CType(Me.cr.Section1.ReportObjects.Item("Titulo"), CrystalDecisions.CrystalReports.Engine.TextObject)
        titulo.Text = "LISTADO DE " + Me.wTab.Text.ToUpper
        'ent necesita el estado y el orden que vienen de WImprimirUsuarios
        tb = rep.ReportearTablas(ent)
        'Pasando las filas de tb a nuestra tabla Usuarios que esta dentro del dsReportes
        For Each fil As DataRow In tb.Rows
            ds.FiltroTabla.ImportRow(fil)
        Next
        'Asignamos a nuestro cr como fuente de datos nuestra tabla Usuarios que esta dentro del dsReportes ya cargados de datos
        cr.SetDataSource(ds)
        'Cargamos en nuestro formulario el cr
        Me.crvDis.ReportSource = cr
        'mostramos el reporte
        Me.Show()
    End Sub

    Sub PorImpresora()
        'Para el titulo del reporte
        titulo = CType(Me.cr.Section1.ReportObjects.Item("Titulo"), CrystalDecisions.CrystalReports.Engine.TextObject)
        titulo.Text = "LISTADO DE " + Me.wTab.Text.ToUpper
        'ent necesita el estado y el orden que vienen de WImprimirUsuarios
        tb = rep.ReportearTablas(ent)
        'Pasando las filas de tb a nuestra tabla Usuarios que esta dentro del dsReportes
        For Each fil As DataRow In tb.Rows
            ds.FiltroTabla.ImportRow(fil)
        Next
        'Asignamos a nuestro cr como fuente de datos nuestra tabla Usuarios que esta dentro del dsReportes ya cargados de datos
        cr.SetDataSource(ds)
        'Cargamos en nuestro formulario el cr
        Me.crvDis.ReportSource = cr
        'mostramos el cuadro de dialogo para imprimir
        Me.crvDis.PrintReport()
        'cerramos el formulario
        Me.Close()
    End Sub

    Sub Exportar()
        'Para el titulo del reporte
        titulo = CType(Me.cr.Section1.ReportObjects.Item("Titulo"), CrystalDecisions.CrystalReports.Engine.TextObject)
        titulo.Text = "LISTADO DE " + Me.wTab.Text.ToUpper
        'ent necesita el estado y el orden que vienen de WImprimirUsuarios
        tb = rep.ReportearTablas(ent)
        'Pasando las filas de tb a nuestra tabla Usuarios que esta dentro del dsReportes
        For Each fil As DataRow In tb.Rows
            ds.FiltroTabla.ImportRow(fil)
        Next
        'Asignamos a nuestro cr como fuente de datos nuestra tabla Usuarios que esta dentro del dsReportes ya cargados de datos
        cr.SetDataSource(ds)
        'Cargamos en nuestro formulario el cr
        Me.crvDis.ReportSource = cr
        'mostramos el cuadro de dialogo para Exportar
        Me.crvDis.ExportReport()
        'cerramos el formulario
        Me.Close()
    End Sub


    Private Sub WRptTab_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class