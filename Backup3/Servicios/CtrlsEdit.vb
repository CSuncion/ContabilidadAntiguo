Public Class CtrlsEdit

    Private _Control As Control
    Private _Campo As String
    Private _PasaFoco As String
    Private _GanaFoco As String
    Private _PierdeFoco As String
    Private _PasarCursor As String
    Private _Limpiar As String
    Private _DatoLimpiar As String
    Private _Obligatorio As String
    Private _Teclazo As Integer
    Private _Valida As Integer
    Private _Formato As String
    Private _Nuevo As String
    Private _Modificar As String
    Private _Eliminar As String
    Private _Visualizar As String
    Private _NumCaracter As Integer

    Property NumCaracter() As Integer
        Get
            Return Me._NumCaracter
        End Get
        Set(ByVal value As Integer)
            Me._NumCaracter = value
        End Set
    End Property

    Property Control() As Control
        Get
            Return Me._Control
        End Get
        Set(ByVal value As Control)
            Me._Control = value
        End Set
    End Property

    Property DatoLimpiar() As String
        Get
            Return Me._DatoLimpiar
        End Get
        Set(ByVal value As String)
            Me._DatoLimpiar = value
        End Set
    End Property

    Property Campo() As String
        Get
            Return Me._Campo
        End Get
        Set(ByVal value As String)
            Me._Campo = value
        End Set
    End Property

    Property PasaFoco() As String
        Get
            Return Me._PasaFoco
        End Get
        Set(ByVal value As String)
            Me._PasaFoco = value
        End Set
    End Property


    Property GanaFoco() As String
        Get
            Return Me._GanaFoco
        End Get
        Set(ByVal value As String)
            Me._GanaFoco = value
        End Set
    End Property

    Property PierdeFoco() As String
        Get
            Return Me._PierdeFoco
        End Get
        Set(ByVal value As String)
            Me._PierdeFoco = value
        End Set
    End Property

    Property PasarCursor() As String
        Get
            Return Me._PasarCursor
        End Get
        Set(ByVal value As String)
            Me._PasarCursor = value
        End Set
    End Property

    Property Limpiar() As String
        Get
            Return Me._Limpiar
        End Get
        Set(ByVal value As String)
            Me._Limpiar = value
        End Set
    End Property

    Property Obligatorio() As String
        Get
            Return Me._Obligatorio
        End Get
        Set(ByVal value As String)
            Me._Obligatorio = value
        End Set
    End Property

    Property Teclazo() As Integer
        Get
            Return Me._Teclazo
        End Get
        Set(ByVal value As Integer)
            Me._Teclazo = value
        End Set
    End Property

    Property Valida() As Integer
        Get
            Return Me._Valida
        End Get
        Set(ByVal value As Integer)
            Me._Valida = value
        End Set
    End Property

    Property Formato() As String
        Get
            Return Me._Formato
        End Get
        Set(ByVal value As String)
            Me._Formato = value
        End Set
    End Property

    Property Nuevo() As String
        Get
            Return Me._Nuevo
        End Get
        Set(ByVal value As String)
            Me._Nuevo = value
        End Set
    End Property

    Property Modificar() As String
        Get
            Return Me._Modificar
        End Get
        Set(ByVal value As String)
            Me._Modificar = value
        End Set
    End Property

    Property Eliminar() As String
        Get
            Return Me._Eliminar
        End Get
        Set(ByVal value As String)
            Me._Eliminar = value
        End Set
    End Property

    Property Visualizar() As String
        Get
            Return Me._Visualizar
        End Get
        Set(ByVal value As String)
            Me._Visualizar = value
        End Set
    End Property

End Class
