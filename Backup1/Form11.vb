Imports Entidad
Imports Negocio

Public Class Form11
    Private sal As New SaldoContableRN

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim RdRN As New RegContabDetaRN
        Dim RdEN As New SuperEntidad
        RdEN.PeriodoRegContabCabe = "201300"
        Dim ilisrd As List(Of SuperEntidad) = RdRN.obtenerDetalleRegContabPorPeriodo(RdEN)
        For Each xrd As SuperEntidad In ilisrd
            If xrd.CodigoOrigen = "3" Then
                xrd.SerieDocumento = xrd.SerieDocumento.PadLeft(4, CType("0", Char))
                xrd.NumeroDocumento = xrd.NumeroDocumento.PadLeft(15, CType("0", Char))
                RdRN.modificarRegContab(xrd)

            End If
        Next

        MsgBox("Todo Ok")


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

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class