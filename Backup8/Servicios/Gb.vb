Public Class Gb

    Public Shared Sub pasarCursor(ByRef gb As GroupBox)
        'saber que rbt tiene el check
        Rbt.radioActivo(gb).Select()
    End Sub

    Public Shared Sub pasarDato(ByRef gb As GroupBox, ByRef dato As String)
        For n As Integer = 0 To gb.Controls.Count - 1
            If gb.Controls(n).Text.ToUpper.Trim = dato.ToUpper.Trim Then
                CType(gb.Controls(n), RadioButton).Checked = True
                Exit Sub
            End If
        Next

    End Sub

    Public Shared Sub pasarDato2(ByRef gb As GroupBox, ByRef dato As String)
        For n As Integer = 0 To gb.Controls.Count - 1
            If gb.Controls(n).Tag.ToString.Trim = dato Then
                CType(gb.Controls(n), RadioButton).Checked = True
                Exit Sub
            End If
        Next

    End Sub




End Class
