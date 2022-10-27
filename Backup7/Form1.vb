Imports Entidad
Imports Negocio

Public Class Form1
    Public cam As New CamposEntidad
    Private sal As New SaldoContableRN

    Sub Boton1()
        'traer todos los detalles pero solo de los orignes 4,5,6
        Dim iRcdRN As New RegContabDetaRN
        Dim iRcdEN As New SuperEntidad
        iRcdEN.CodigoOrigen = "4,5,6"
        iRcdEN.CampoOrden = cam.ClaveRCC
        Dim iLisRcd As List(Of SuperEntidad) = iRcdRN.ListarRegistrosContablesDetalleXOrigenes(iRcdEN)

        'recorre cada objeto
        For Each xObj As SuperEntidad In iLisRcd
            'modificar la moneda del documento del detalle con la moneda de la cabecera
            xObj.Exporta = xObj.MonedaDocumento
            iRcdRN.modificarRegContab(xObj)
        Next

        MsgBox("ok")

    End Sub

    Sub Boton2()
        'traer todos los detalles pero solo de los orignes 4,5,6
        Dim iRcdRN As New MovimientoContableDetalleRN
        Dim iRcdEN As New SuperEntidad
        iRcdEN.CodigoOrigen = "4,5,6"
        iRcdEN.CampoOrden = cam.ClaveRCC
        Dim iLisRcd As List(Of SuperEntidad) = iRcdRN.ListarMovimientosContablesDetalleXOrigenes(iRcdEN)

        'recorre cada objeto
        For Each xObj As SuperEntidad In iLisRcd
            'modificar la moneda del documento del detalle con la moneda de la cabecera
            xObj.Exporta = xObj.MonedaDocumento
            iRcdRN.ModificarMovimientoContableDetalle(xObj)
        Next

        MsgBox("ok")

    End Sub













    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Dim RdRN As New RegContabDetaRN
        'Dim RdEN As New SuperEntidad
        'RdEN.PeriodoRegContabCabe = "201300"
        'Dim ilisrd As List(Of SuperEntidad) = RdRN.obtenerDetalleRegContabPorPeriodo(RdEN)
        'For Each xrd As SuperEntidad In ilisrd
        '    If xrd.CodigoOrigen = "3" Then
        '        xrd.SerieDocumento = xrd.SerieDocumento.PadLeft(4, CType("0", Char))
        '        xrd.NumeroDocumento = xrd.NumeroDocumento.PadLeft(15, CType("0", Char))
        '        RdRN.modificarRegContab(xrd)

        '    End If
        'Next

        'MsgBox("Todo Ok")


        ''Dim fecha As String = Me.TextBox1.Text
        ''Varios.ValidaDia(fecha)
        'Dim ent As New SuperEntidad
        'ent.PeriodoRegContabCabe = "2012"
        'SuperEntidad.xCodigoEmpresa = "001"



        'Dim lis As New List(Of SuperEntidad)
        'lis = sal.ObtenerGananciaPerdidaXFuncion(ent)
        'For Each xobj As SuperEntidad In lis
        '    MsgBox(xobj.CodigoCuentaPcge)
        'Next
        'Dim x As New Reportes.EstadoFinanciero
        'MsgBox(x.montomes.ToString)

    End Sub


    Private Sub btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click
        Me.Boton1()
    End Sub

    Private Sub btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn2.Click
        Me.Boton2()
    End Sub
End Class