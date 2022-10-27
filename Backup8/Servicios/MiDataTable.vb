Public Class MiDataTable
    Public Shared Sub Ordenar(ByRef pTabla As DataTable, ByVal pOrden As String)
        'OBTENER LOS REGISTROS DE LA TABLA PERO ORDENADOS
        Dim iRegistrosOrdenados As DataRow() = pTabla.Select("", pOrden)

        Dim iTablaOrdenada As DataTable = pTabla.Clone

        'PASAMOS ESTOS REGISTROS A UNA TABLA
        For Each xRow As DataRow In iRegistrosOrdenados
            iTablaOrdenada.ImportRow(xRow)
        Next

        'LIMPIAMOS LA TABLA PRINCIPAL
        pTabla.Clear()

        'RECORREMOS CADA OBJETO
        For Each xRow As DataRow In iTablaOrdenada.Rows
            'PASAMOS LOS REGISTROS A LA TABLA PRINCIPAL
            pTabla.ImportRow(xRow)
        Next

    End Sub


    'Public Shared Sub Ordenar(ByRef pTabla As DataTable, ByVal pOrden As String)
    '    'OBTENER LOS REGISTROS DE LA TABLA PERO ORDENADOS
    '    Dim iRegistrosOrdenados() As DataRow = pTabla.Select("", pOrden)

    '    'PASAMOS ESTOS REGISTROS A UNA TABLA
    '    Dim iTablaOrdenada As DataTable = iRegistrosOrdenados.ConvertAl


    'End Sub

    'public static void Ordenar(DataTable pTabla, string pOrden)
    '    {
    '        //obtener los regustros de la tabla pero ordenados
    '        DataRow[] iRegistrosOrdenados = pTabla.Select("", pOrden);

    '        //pasamos estos registros a una tabla
    '        DataTable iTablaOrdenada = iRegistrosOrdenados.CopyToDataTable();

    '        //limpiamos nuestra tabla 
    '        pTabla.Clear();

    '        //recorremos cada objeto
    '        foreach (DataRow item in iTablaOrdenada.Rows)
    '        {
    '            pTabla.ImportRow(item);
    '        }
    '    }

End Class
