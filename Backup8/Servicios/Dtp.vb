Public Class Dtp

    Shared Sub Limpiar(ByRef Dtp As DateTimePicker, ByRef defecto As String)
        If defecto = "Today" Then
            Dtp.Value = Today
        End If
    End Sub

    Shared Sub HabiltaSegunOperacion(ByRef Dtp As DateTimePicker, ByRef act As String)
        If act = "1" Then
            Dtp.Enabled = True
        Else
            Dtp.Enabled = False
        End If
    End Sub


        
End Class
