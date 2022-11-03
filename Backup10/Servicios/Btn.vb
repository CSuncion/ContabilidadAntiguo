Public Class Btn

    Shared Sub HabiltaSegunOperacion(ByRef Dtp As Button, ByRef act As String)
        If act = "1" Then
            Dtp.Enabled = True
        Else
            Dtp.Enabled = False
        End If
    End Sub

End Class
