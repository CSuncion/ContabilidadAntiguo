Imports System.Data.SqlClient
Public Class WCopiaBd

    ' Dim servidor As String = "JAVIER-PC\MSSQLSERVER2008" 'aqui ba el nombre del srvidor de syz
    'Dim servidor As String = "LAPTOP-GUDPF7AP\MSSQLSERVER2014" 'aqui ba el nombre del srvidor de syz
    Dim servidor As String = "SRV2012R2\MSSQLSERVER2014" 'aqui ba el nombre del srvidor de syz
    Dim bd As String = "ContabilidadEmma" 'aqui va la b.d de la empresa
    Dim ruta As String
    Dim nombreArchivo As String = "\CopiaContabilidadEmma.bak"

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sBackup As String = "backup database " & bd & " to disk='" & ruta + nombreArchivo & "' with init, format"

        Dim csb As New SqlConnectionStringBuilder
        'csb.DataSource = servidor
        'csb.InitialCatalog = bd
        csb.ConnectionString = "Data Source=SRV2012R2\MSSQLSERVER2014;Initial Catalog= ContabilidadEmma ;User ID=sa;Password=SubW00ferSQL;"
        'csb.ConnectionString = "Data Source=JAVIER-PC\MSSQLSERVER2008;Initial Catalog= ContabilidadAlfisa;User ID=sa;Password=.;"
        'csb.IntegratedSecurity = True

        Using con As New SqlConnection(csb.ConnectionString)
            Try
                con.Open()

                Dim cmdBackUp As New SqlCommand(sBackup, con)

                cmdBackUp.ExecuteNonQuery()

                MsgBox("Se ha creado un BackUp de La base de datos satisfactoria", MsgBoxStyle.Information)

                con.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message, _
                                "Error al copiar la base de datos", _
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.FolderBrowserDialog1.ShowDialog()
        Me.TextBox1.Text = Me.FolderBrowserDialog1.SelectedPath
        ruta = Me.FolderBrowserDialog1.SelectedPath
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class