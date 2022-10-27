
Public Class ListaTsb

    Private _Tsb As New ToolStripButton
    Private _GrillaVacia As String
    Private _Desplaza As String
    Private _IndiceFila As Integer

    Property Tsb() As ToolStripButton
        Get
            Return Me._Tsb
        End Get
        Set(ByVal value As ToolStripButton)
            Me._Tsb = value
        End Set
    End Property

    Property GrillaVacia() As String
        Get
            Return Me._GrillaVacia
        End Get
        Set(ByVal value As String)
            Me._GrillaVacia = value
        End Set
    End Property

    Property Desplaza() As String
        Get
            Return Me._Desplaza
        End Get
        Set(ByVal value As String)
            Me._Desplaza = value
        End Set
    End Property

    Property indiceFila() As Integer
        Get
            Return Me._IndiceFila
        End Get
        Set(ByVal value As Integer)
            Me._IndiceFila = value
        End Set
    End Property
End Class
