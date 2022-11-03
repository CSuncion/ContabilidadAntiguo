Imports Entidad
Imports Negocio
Public Class Txt
    ''' <summary>
    ''' Pone el cursor en la ultima letra escrita en el control obj
    ''' </summary>
    ''' <param name="obj">Es el control a poner el cursor</param>
    ''' <remarks></remarks>
    Public Shared Sub cursorAlUltimo(ByRef obj As TextBox)
        obj.SelectionStart = obj.Text.Length
        obj.Focus()
    End Sub

    Public Shared Sub ValorDefectoGot(ByRef obj As TextBox, ByRef defecto As String)
        If obj.Text.Trim = defecto Then
            obj.Text = ""
        End If
    End Sub

    Public Shared Sub ValorDefectoLost(ByRef obj As TextBox, ByRef defecto As String)
        'MsgBox("lost")
        If obj.Text.Trim = "" Then
            obj.Text = defecto
        End If
    End Sub


    Public Shared Sub ganaFoco(ByRef obj As TextBox)
        obj.BackColor = Drawing.Color.Gainsboro
    End Sub

    Public Shared Sub pierdeFoco(ByRef obj As TextBox)
        obj.BackColor = Drawing.Color.White
    End Sub

    Public Shared Sub Limpiar(ByRef obj As TextBox, ByRef defecto As String)
        obj.Text = defecto
    End Sub

    Public Shared Sub HabilitarSegunOperacion(ByRef obj As TextBox, ByRef act As String)
        If act = "1" Then
            obj.ReadOnly = False
        Else
            obj.ReadOnly = True
        End If
    End Sub

    Shared Function CampoObligatorio(ByRef obj As TextBox, ByRef defecto As String, ByRef mensaje As String) As Boolean
        If obj.Text.Trim = defecto Then
            MsgBox("no dejar en blanco / Campo: " + mensaje, MsgBoxStyle.Critical)
            obj.Focus()
            Return False
        Else
            Return True
        End If
    End Function

    Shared Sub MostrarCodigoDescripcionDeTabla(ByRef txtCod As TextBox, ByRef txtDes As TextBox, ByRef TipoTabla As String, ByVal tabla As String, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim cod As String = txtCod.Text.Trim
        If cod = "" Then
            Exit Sub
        Else
            Dim obj As New SuperEntidad
            Dim tab As New TablaRN
            obj.DatoCondicion1 = TipoTabla
            obj.DatoCondicion2 = cod
            obj = tab.buscarItemTablaExisActPorTipoTablaYCodigo(obj)
            If obj.CodigoItemTabla = "" Then
                MsgBox("El codigo " + tabla + " no existe", MsgBoxStyle.Information)
                txtCod.Text = ""
                txtDes.Text = ""
                e.Cancel = True
            Else
                txtCod.Text = obj.CodigoItemTabla
                txtDes.Text = obj.NombreItemTabla
            End If
        End If
    End Sub

End Class
