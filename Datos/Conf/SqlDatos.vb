Imports System.Data.SqlClient

Public Class SqlDatos

    Private cn As New SqlConnection
    Private cmd As New SqlCommand

    Enum Bd
        ContabilidadEmma
        Proyectos
    End Enum

    Sub Conectar(ByVal baseDatos As Bd)

        Dim cadenaConexion As String
        'A que base datos se quiere conectar
        Select Case baseDatos
            Case Bd.ContabilidadEmma
                '//Cambiar el nombre del servidor
                'cadenaConexion = "Data Source=JAVIER-PC\MSSQLSERVER2012;Initial Catalog=" & Bd.Contabilidad.ToString & ";User ID=sa;Password=.;"
                'cadenaConexion = "Data Source=JAVIER-PC\MSSQLSERVER2014;Initial Catalog=" & Bd.ContabilidadEmma.ToString & ";User ID=sa;Password=.;"
                cadenaConexion = "Data Source=DESKTOP-VQ0I0E0\SQLEXPRESS;Initial Catalog=" & Bd.ContabilidadEmma.ToString & ";User ID=sa;Password=.;"
                'cadenaConexion = "Data Source=SRV2012R2\MSSQLSERVER2014;Initial Catalog=" & Bd.ContabilidadEmma.ToString & ";User ID=sa;Password=SubW00ferSQL;"
                'cadenaConexion = "Data Source=192.168.1.253\MSSQLSERVER2014;Initial Catalog=" & Bd.ContabilidadEmma.ToString & ";User ID=sa;Password=SubW00ferSQL;"
                cn.ConnectionString = cadenaConexion
                'Case Bd.ContabilidadWwg
                'MsgBox("Entra")
                '//Cambiar el nombre del servidor
                ' cadenaConexion = "Data Source=SRV01;Initial Catalog=" & Bd.Proyectos.ToString & ";User ID=syz;Password=1234;"
                'cn.ConnectionString = cadenaConexion
            Case Bd.Proyectos
                '//Cambiar el nombre del servidor
                'cadenaConexion = "Data Source=SRV01;Initial Catalog=" & Bd.Proyectos.ToString & ";User ID=syz;Password=1234;"
                'cn.ConnectionString = cadenaConexion
                ' cadenaConexion = "Data Source=SRV01;Initial Catalog=" & Bd.Proyectos.ToString & ";User ID=syz;Password=1234;"
                'cn.ConnectionString = cadenaConexion
        End Select
        'Abrimos la conexion6
        cn.Open()

    End Sub

    Sub ComandoProcAlm(ByRef pa As String)
        '//
        cmd.Connection = cn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = pa
        '\\
    End Sub

    Sub ComandoText(ByRef pa As String)
        '//
        cmd.Connection = cn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = pa
        '\\
    End Sub

    Sub AsignarParametro(ByRef par As SqlParameter, ByVal valor As Object)
        '//
        par.Value = valor
        cmd.Parameters.Add(par)
        '\\
    End Sub

    Sub Desconectar()
        '//
        cn.Dispose()
        cn.Close()
        cmd.Dispose()
        '\\
    End Sub

    Function ObtenerTablaRegistro() As DataTable
        '//
        Dim dt As New DataTable
        dt.Load(cmd.ExecuteReader)

        Return dt
        '\\
    End Function

    Sub EjecutarSinResultado()
        '//
        cmd.ExecuteNonQuery()
        '\\
    End Sub

    Sub QuitarParametros()
        '//
        cmd.Parameters.Clear()
        '\\
    End Sub

    Function ObtenerIDr() As IDataReader
        '//
        Dim dr As IDataReader
        dr = cmd.ExecuteReader
        Return dr
        '\\
    End Function

    Function ObtenerValor() As String
        '//
        Dim valor As String
        If cmd.ExecuteScalar Is Nothing Then
            valor = ""
        Else
            valor = cmd.ExecuteScalar.ToString
        End If
        Return valor
        '\\
    End Function

End Class
