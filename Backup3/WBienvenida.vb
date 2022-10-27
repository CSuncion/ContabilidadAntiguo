Public Class WBienvenida

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'para controlar el tiempo activo del VenBienvenida
        'tiempo en segundos
        Timer.lapso = 3
        If Timer.TiempoTranscurrido() = True Then
            Me.Timer1.Enabled = False
            Me.Dispose()
            Me.Close()
            Dim win As New WMenu
            win.nuevaVentana()
        End If
    End Sub

    
End Class