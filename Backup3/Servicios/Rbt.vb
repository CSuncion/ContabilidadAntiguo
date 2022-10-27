Public Class Rbt


    Public Overloads Shared Function radioActivo(ByVal gb As GroupBox) As RadioButton
        Dim n As Integer
        For n = 0 To gb.Controls.Count - 1
            If CType(gb.Controls(n), RadioButton).Checked = True Then
                Exit For
            End If
        Next
        Return CType(gb.Controls(n), RadioButton)
    End Function

    Shared Sub GanaFoco(ByRef rbt As RadioButton)
        rbt.ForeColor = Drawing.Color.Red
        'rbt.Font = New Font
    End Sub

    Shared Sub PierdeFoco(ByRef rbt As RadioButton)
        rbt.ForeColor = Drawing.Color.Black
    End Sub

    Shared Sub Limpiar(ByRef rbt As RadioButton, ByRef defecto As String)
        rbt.Checked = CType(defecto, Boolean)
    End Sub

    Shared Sub HablilitarSegunOperacion(ByRef rbt As RadioButton, ByRef act As String)
        If act = "1" Then
            rbt.Enabled = True
        Else
            If rbt.Checked = True Then
                rbt.Enabled = True
            Else
                rbt.Enabled = False
            End If
        End If
    End Sub


    Public Shared Sub HabilitarSoloRadioActivo(ByVal gb As GroupBox)
        Dim n As Integer
        For n = 0 To gb.Controls.Count - 1
            If CType(gb.Controls(n), RadioButton).Checked = True Then
                CType(gb.Controls(n), RadioButton).Enabled = True
            Else
                CType(gb.Controls(n), RadioButton).Enabled = False
            End If
        Next
    End Sub

    Public Shared Sub HabilitarTodosLosRadio(ByVal gb As GroupBox)
        Dim n As Integer
        For n = 0 To gb.Controls.Count - 1
            CType(gb.Controls(n), RadioButton).Enabled = True
        Next
    End Sub


End Class
