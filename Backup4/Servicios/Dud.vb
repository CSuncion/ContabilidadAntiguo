Public Class Dud

    Shared Sub Cargar(ByRef Dud As DomainUpDown, ByRef hasta As Integer)
        For n As Integer = 0 To hasta
            Dud.Items.Add(n)
        Next
        Dud.SelectedIndex = 0
        Dud.ReadOnly = True
    End Sub

    Public Shared Sub ValorDefectoGot(ByRef obj As DomainUpDown, ByRef defecto As String)
        If obj.Text.Trim = defecto Then
            obj.Text = ""
        End If
    End Sub

    Public Shared Sub ValorDefectoLost(ByRef obj As DomainUpDown, ByRef defecto As String)
        If obj.Text.Trim = "" Then
            obj.Text = defecto
        End If
    End Sub

    Shared Sub Limpiar(ByRef Dud As DomainUpDown, ByRef defecto As String)
        Dud.SelectedIndex = 0
        'Dud.SelectedIndex = 0
    End Sub

    Shared Sub HabilitarSegunOperacion(ByRef Dud As DomainUpDown, ByRef act As String)
        If act = "1" Then
            Dud.ReadOnly = False
        Else
            Dud.ReadOnly = True
        End If
    End Sub

    Shared Function CampoObligatorio(ByRef obj As DomainUpDown, ByRef defecto As String, ByRef mensaje As String) As Boolean
        If obj.Text.Trim = defecto Then
            MsgBox("no dejar en blanco / Campo: " + mensaje, MsgBoxStyle.Critical)
            obj.Focus()
            Return False
        Else
            Return True
        End If
    End Function

End Class
