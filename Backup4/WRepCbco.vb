Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports Entidad
Imports Negocio

Public Class WRepCbco
#Region "Propietarios"
    Public wCbco As New WCuentaBanco
#End Region
    Public ent As New SuperEntidad
    Dim rep As New ReportesTodosRN
    Dim cam As New CamposEntidad
    Dim ds As New DataSet1
    Dim tb As New DataTable
    Dim cr As New crRptAux
    Dim titulo As CrystalDecisions.CrystalReports.Engine.TextObject

#Region "Metodos"

    Sub PorPantalla()
        'Para el titulo del reporte
        titulo = CType(Me.cr.Section1.ReportObjects.Item("Titulo"), CrystalDecisions.CrystalReports.Engine.TextObject)
        If ent.DatoCondicion1 = "Todos" Then
            titulo.Text = "LISTADO DE CUENTAS BANCARIAS"
            tb = rep.ReportearAuxiliaresTodos(ent)
        Else
            titulo.Text = "LISTADO DE " + ent.DatoCondicion1.ToUpper
            tb = rep.ReportearAuxiliares(ent)
        End If
        'ent necesita el estado y el orden que vienen de WImprimirUsuarios

        'Pasando las filas de tb a nuestra tabla Usuarios que esta dentro del dsReportes
        For Each fil As DataRow In tb.Rows
            ds.Auxiliar.ImportRow(fil)
        Next
        'Asignamos a nuestro cr como fuente de datos nuestra tabla Usuarios que esta dentro del dsReportes ya cargados de datos
        cr.SetDataSource(ds)
        'Cargamos en nuestro formulario el cr
        Me.crvAux.ReportSource = cr
        'mostramos el reporte
        Me.Show()
    End Sub

    Sub PorImpresora()
        'Para el titulo del reporte
        titulo = CType(Me.cr.Section1.ReportObjects.Item("Titulo"), CrystalDecisions.CrystalReports.Engine.TextObject)
        If ent.DatoCondicion1 = "Todos" Then
            titulo.Text = "LISTADO DE CUENTAS BANCARIAS"
            tb = rep.ReportearAuxiliaresTodos(ent)
        Else
            titulo.Text = "LISTADO DE " + ent.DatoCondicion1.ToUpper
            tb = rep.ReportearAuxiliares(ent)
        End If
        'ent necesita el estado y el orden que vienen de WImprimirUsuarios

        'Pasando las filas de tb a nuestra tabla Usuarios que esta dentro del dsReportes
        For Each fil As DataRow In tb.Rows
            ds.Auxiliar.ImportRow(fil)
        Next
        'Asignamos a nuestro cr como fuente de datos nuestra tabla Usuarios que esta dentro del dsReportes ya cargados de datos
        cr.SetDataSource(ds)
        'Cargamos en nuestro formulario el cr
        Me.crvAux.ReportSource = cr
        'mostrar imprsora
        Me.crvAux.PrintReport()
        'mostramos el reporte
        Me.Close()
    End Sub

    Sub Exportar()
        titulo = CType(Me.cr.Section1.ReportObjects.Item("Titulo"), CrystalDecisions.CrystalReports.Engine.TextObject)
        'titulo.Text = "LISTADO DE " + Me.wAux.Text.ToUpper
        'ent necesita el estado y el orden que vienen de WImprimirUsuarios
        tb = rep.ReportearAuxiliaresTodos(ent)
        'Pasando las filas de tb a nuestra tabla Usuarios que esta dentro del dsReportes
        For Each fil As DataRow In tb.Rows
            ds.Auxiliar.ImportRow(fil)
        Next
        'Asignamos a nuestro cr como fuente de datos nuestra tabla Usuarios que esta dentro del dsReportes ya cargados de datos
        cr.SetDataSource(ds)
        'Cargamos en nuestro formulario el cr
        Me.crvAux.ReportSource = cr
        'mostramos el cuadro de dialogo para Exportar
        Me.crvAux.ExportReport()
        'cerramos el formulario
        Me.Close()
    End Sub

    'Sub Exportar()
    '    '//
    '    '/Parametros
    '    Dim param As New ParameterDiscreteValue
    '    param.Value = Me.wAux.ent.CampoOrden

    '    Dim paramList As New ParameterFields()
    '    Dim paramTemp As New ParameterField
    '    paramTemp.ParameterValueType = ParameterValueKind.NumberParameter
    '    paramTemp.Name = "@CampoOrden"
    '    paramTemp.CurrentValues.Add(param)
    '    paramList.Add(paramTemp)

    '    Me.crvAux.ParameterFieldInfo = paramList
    '    '  Me.crvPer.ReportSource = New crInfPer
    '    Me.crvAux.ExportReport()
    '    Me.Close()
    'End Sub

    'Sub PorPantalla()
    '    Dim param As New ParameterDiscreteValue
    '    param.Value = Me.wAux.ent.CampoOrden

    '    Dim paramList As New ParameterFields()
    '    Dim paramTemp As New ParameterField
    '    paramTemp.ParameterValueType = ParameterValueKind.StringParameter
    '    paramTemp.Name = "@CampoOrden"
    '    paramTemp.CurrentValues.Add(param)
    '    paramList.Add(paramTemp)

    '    Me.crvAux.ParameterFieldInfo = paramList
    '    ' Me.crvPer.ReportSource = New crInfPer
    '    Me.Show()
    'End Sub

    'Sub PorImpresora()
    '    Dim param As New ParameterDiscreteValue
    '    param.Value = Me.wAux.ent.CampoOrden

    '    Dim paramList As New ParameterFields()
    '    Dim paramTemp As New ParameterField
    '    paramTemp.ParameterValueType = ParameterValueKind.StringParameter
    '    paramTemp.Name = "@CampoOrden"
    '    paramTemp.CurrentValues.Add(param)
    '    paramList.Add(paramTemp)

    '    Me.crvAux.ParameterFieldInfo = paramList
    '    '  Me.crvPer.ReportSource = New crInfPer
    '    Me.crvAux.PrintReport()
    '    Me.Close()
    'End Sub

#End Region

    Private Sub WImpPer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

End Class