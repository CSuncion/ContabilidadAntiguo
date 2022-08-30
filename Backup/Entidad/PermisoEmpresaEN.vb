
Public Class PermisoEmpresaEN

#Region "Inicializa"

    Sub New()
        '/
        'Inicializa el objeto 
        Me._ClavePermisoEmpresa = String.Empty
        Me._CodigoUsuario = String.Empty
        Me._NombreUsuario = String.Empty
        Me._CodigoEmpresa = String.Empty
        Me._RazonSocialEmpresa = String.Empty
        Me._NombreCortoEmpresa = String.Empty
        Me._CEstadoEmpresa = "1" '1:Abierto  0:Cerrado
        Me._NEstadoEmpresa = String.Empty
        Me._CHistoriaEmpresa = "0" ' '1:No existe  0: si existe
        Me._NHistoriaEmpresa = String.Empty
        Me._EstadoPermisoEmpresa = 0 'Sin permiso
        Me._CMesPermisoEmpresa = String.Empty
        Me._NMesPermisoEmpresa = String.Empty
        Me._AnoPermisoEmpresa = String.Empty
        Me._PeriodoPermisoEmpresa = String.Empty
        Me._RucEmpresa = String.Empty
        '/
    End Sub

#End Region

#Region "Nombre Columnas"

    Public Const ClaPerEmp As String = "ClavePermisoEmpresa"
    Public Const CodUsu As String = "CodigoUsuario"
    Public Const NomUsu As String = "NombreUsuario"
    Public Const CodEmp As String = "CodigoEmpresa"
    Public Const RazSocEmp As String = "RazonSocialEmpresa"
    Public Const NomCorEmp As String = "NombreCortoEmpresa"
    Public Const CEstEmp As String = "EstadoEmpresa"
    Public Const NEstEmp As String = "NEstadoEmpresa"
    Public Const CHisEmp As String = "CHistoriaEmpresa"
    Public Const NHisEmp As String = "NHistoriaEmpresa"
    Public Const EstPerEmp As String = "EstadoPermisoEmpresa"
    Public Const CMesPerEmp As String = "CMesPermisoEmpresa"
    Public Const NMesPerEmp As String = "NMesPermisoEmpresa"
    Public Const AnoPerEmp As String = "AnoPermisoEmpresa"
    Public Const PerPerEmp As String = "PeriodoPermisoEmpresa"
    Public Const RucEmp As String = "RucEmpresa"

#End Region

#Region "Valor Columnas"

    Private _ClavePermisoEmpresa As String
    Private _CodigoUsuario As String
    Private _NombreUsuario As String
    Private _CodigoEmpresa As String
    Private _RazonSocialEmpresa As String
    Private _NombreCortoEmpresa As String
    Private _CEstadoEmpresa As String
    Private _NEstadoEmpresa As String
    Private _CHistoriaEmpresa As String
    Private _NHistoriaEmpresa As String
    Private _EstadoPermisoEmpresa As Integer
    Private _CMesPermisoEmpresa As String
    Private _NMesPermisoEmpresa As String
    Private _AnoPermisoEmpresa As String
    Private _PeriodoPermisoEmpresa As String
    Private _RucEmpresa As String

    Property RucEmpresa() As String
        Get
            Return Me._RucEmpresa
        End Get
        Set(ByVal value As String)
            Me._RucEmpresa = value
        End Set
    End Property

    Property PeriodoPermisoEmpresa() As String
        Get
            Return Me._PeriodoPermisoEmpresa
        End Get
        Set(ByVal value As String)
            Me._PeriodoPermisoEmpresa = value
        End Set
    End Property

    Property ClavePermisoEmpresa() As String
        Get
            Return Me._ClavePermisoEmpresa
        End Get
        Set(ByVal value As String)
            Me._ClavePermisoEmpresa = value
        End Set
    End Property


    Property AnoPermisoEmpresa() As String
        Get
            Return Me._AnoPermisoEmpresa
        End Get
        Set(ByVal value As String)
            Me._AnoPermisoEmpresa = value
        End Set
    End Property

    Property NMesPermisoEmpresa() As String
        Get
            Return Me._NMesPermisoEmpresa
        End Get
        Set(ByVal value As String)
            Me._NMesPermisoEmpresa = value
        End Set
    End Property

    Property CMesPermisoEmpresa() As String
        Get
            Return Me._CMesPermisoEmpresa
        End Get
        Set(ByVal value As String)
            Me._CMesPermisoEmpresa = value
        End Set
    End Property

    Property EstadoPermisoEmpresa() As Integer
        Get
            Return Me._EstadoPermisoEmpresa
        End Get
        Set(ByVal value As Integer)
            Me._EstadoPermisoEmpresa = value
        End Set
    End Property


    Property CodigoUsuario() As String
        Get
            Return Me._CodigoUsuario
        End Get
        Set(ByVal value As String)
            Me._CodigoUsuario = value
        End Set
    End Property

    Property NombreUsuario() As String
        Get
            Return Me._NombreUsuario
        End Get
        Set(ByVal value As String)
            Me._NombreUsuario = value
        End Set
    End Property

    Property CHistoriaEmpresa() As String
        Get
            Return Me._CHistoriaEmpresa
        End Get
        Set(ByVal value As String)
            Me._CHistoriaEmpresa = value
        End Set
    End Property

    Property NHistoriaEmpresa() As String
        Get
            Return Me._NHistoriaEmpresa
        End Get
        Set(ByVal value As String)
            Me._NHistoriaEmpresa = value
        End Set
    End Property

    Property CEstadoEmpresa() As String
        Get
            Return Me._CEstadoEmpresa
        End Get
        Set(ByVal value As String)
            Me._CEstadoEmpresa = value
        End Set
    End Property

    Property NEstadoEmpresa() As String
        Get
            Return Me._NEstadoEmpresa
        End Get
        Set(ByVal value As String)
            Me._NEstadoEmpresa = value
        End Set
    End Property

    Property RazonSocialEmpresa() As String
        Get
            Return Me._RazonSocialEmpresa
        End Get
        Set(ByVal value As String)
            Me._RazonSocialEmpresa = value
        End Set
    End Property

    Property NombreCortoEmpresa() As String
        Get
            Return Me._NombreCortoEmpresa
        End Get
        Set(ByVal value As String)
            Me._NombreCortoEmpresa = value
        End Set
    End Property

    Property CodigoEmpresa() As String
        Get
            Return Me._CodigoEmpresa
        End Get
        Set(ByVal value As String)
            Me._CodigoEmpresa = value
        End Set
    End Property

#End Region

#Region "Campos adicionales"

    Private _CampoOrden As String

    Property CampoOrden() As String
        Get
            Return Me._CampoOrden
        End Get
        Set(ByVal value As String)
            Me._CampoOrden = value
        End Set
    End Property

#End Region

End Class
