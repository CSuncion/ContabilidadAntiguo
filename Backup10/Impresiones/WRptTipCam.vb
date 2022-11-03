Imports CrystalDecisions.CrystalReports.Engine
Imports Entidad
Imports Negocio
Public Class WRptTipCam
    Public ent As New SuperEntidad
    Dim rep As New ReportesTodosRN
    Dim cam As New CamposEntidad
    Dim ds As New DataSet1
    Dim tb As New DataTable
    Dim cr As New crRptTipCam

#Region "Metodos"

    Sub PorPantalla()
        'ent  el orden que vienen de WImprimirUsuarios
        tb = rep.ReportearTipoCambio(ent)
        'Pasando las filas de tb a nuestra tabla Usuarios que esta dentro del dsReportes
        For Each fil As DataRow In tb.Rows
            ds.TipoCambio.ImportRow(fil)
        Next
        'Asignamos a nuestro cr como fuente de datos nuestra tabla Usuarios que esta dentro del dsReportes ya cargados de datos
        cr.SetDataSource(ds)
        'Cargamos en nuestro formulario el cr
        Me.crvPer.ReportSource = cr
        'mostramos el reporte
        Me.Show()
    End Sub

    Sub PorImpresora()
        'ent  el orden que vienen de WImprimirUsuarios
        tb = rep.ReportearTipoCambio(ent)
        'Pasando las filas de tb a nuestra tabla Usuarios que esta dentro del dsReportes
        For Each fil As DataRow In tb.Rows
            ds.TipoCambio.ImportRow(fil)
        Next
        'Asignamos a nuestro cr como fuente de datos nuestra tabla Usuarios que esta dentro del dsReportes ya cargados de datos
        cr.SetDataSource(ds)
        'Cargamos en nuestro formulario el cr
        Me.crvPer.ReportSource = cr
        'mostramos el reporte
        'mostramos el cuadro de dialogo para imprimir
        Me.crvPer.PrintReport()
        'mostramos el reporte
        Me.Close()
    End Sub


    Sub Exportar()
        'ent  el orden que vienen de WImprimirUsuarios
        tb = rep.ReportearPersonales(ent)
        'Pasando las filas de tb a nuestra tabla Usuarios que esta dentro del dsReportes
        For Each fil As DataRow In tb.Rows
            'ds.Personal.ImportRow(fil)
        Next
        'Asignamos a nuestro cr como fuente de datos nuestra tabla Usuarios que esta dentro del dsReportes ya cargados de datos
        cr.SetDataSource(ds)
        'Cargamos en nuestro formulario el cr
        Me.crvPer.ReportSource = cr
        'mostramos el cuadro de dialogo para Exportar
        Me.crvPer.ExportReport()
        'mostramos el reporte
        Me.Close()
    End Sub


#End Region
End Class