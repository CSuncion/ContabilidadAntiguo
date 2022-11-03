Public Class Timer
#Region "miembros de datos"
    Public Shared lapso As Integer
    Private Shared segundosTranscuridos As Integer = 0
#End Region
#Region "Metodos"

    Public Shared Function TiempoTranscurrido() As Boolean
        segundosTranscuridos += 1
        If segundosTranscuridos = lapso Then
            'dejamos las variables compartidas vacias
            lapso = Nothing
            segundosTranscuridos = Nothing
            Return True
        Else
            Return False
        End If
    End Function

#End Region
End Class
