Public Class SuperEntidad

#Region "Atributos Compartidos"
    Public Shared xCodigoUsuario As String = ""
    Public Shared xNombreGrupo As String = ""
    Public Shared xCodigoPersonal As String = ""
    Public Shared xCodigoGrupo As String = ""
    Public Shared xNombreUsuario As String = ""
    Public Shared xNombreUsuarioModifica As String = ""
    Public Shared xCodigoEmpresa As String = ""
    Public Shared xRazonSocial As String = ""
    Public Shared xNombreCortoEmpresa As String = ""
    Public Shared xPeriodoEmpresa As String = ""
    Public Shared xMesPeriodo As String = ""
    Public Shared xRucEmpresa As String = ""

#End Region

#Region "Parametros adicionales"
    Private _Vista As String
    Private _DatoEliminado As String
    Private _DatoEstado As String
    Private _CampoCondicion1 As String
    Private _DatoCondicion1 As String
    Private _CampoCondicion2 As String
    Private _DatoCondicion2 As String
    Private _CampoCondicion3 As String
    Private _DatoCondicion3 As String
    Private _CampoCondicion4 As String
    Private _DatoCondicion4 As String

    Private _CampoOrden As String
    Private _Orden As String
    Private _Filtro As String
    Private _CampoCursor As String
    Private _ColumnaBusqueda As String
    Private _CursorPorFecha As DateTime
    Private _CampoFecha As String
    Private _Desde As DateTime
    Private _Hasta As DateTime
    Private _CampoFiltro1 As String
    Private _DatoFiltro1 As String
    Private _CampoFiltro2 As String
    Private _DatoFiltro2 As String
    Private _CampoFiltro3 As String
    Private _DatoFiltro3 As String
    Private _CampoFiltro4 As String
    Private _DatoFiltro4 As String
    Private _CampoFiltro5 As String
    Private _DatoFiltro5 As String
    Private _CampoFiltro6 As String
    Private _DatoFiltro6 As String

    Private _CorrelativoFile As String
    Private _EsVerdad As Boolean
    Private _Mensaje As String

    Property DatoFiltro6() As String
        Get
            Return Me._DatoFiltro6
        End Get
        Set(ByVal value As String)
            Me._DatoFiltro6 = value
        End Set
    End Property

    Property CampoFiltro6() As String
        Get
            Return Me._CampoFiltro6
        End Get
        Set(ByVal value As String)
            Me._CampoFiltro6 = value
        End Set
    End Property


    Property DatoFiltro5() As String
        Get
            Return Me._DatoFiltro5
        End Get
        Set(ByVal value As String)
            Me._DatoFiltro5 = value
        End Set
    End Property

    Property CampoFiltro5() As String
        Get
            Return Me._CampoFiltro5
        End Get
        Set(ByVal value As String)
            Me._CampoFiltro5 = value
        End Set
    End Property

    Property DatoFiltro3() As String
        Get
            Return Me._DatoFiltro3
        End Get
        Set(ByVal value As String)
            Me._DatoFiltro3 = value
        End Set
    End Property

    Property CampoFiltro3() As String
        Get
            Return Me._CampoFiltro3
        End Get
        Set(ByVal value As String)
            Me._CampoFiltro3 = value
        End Set
    End Property


    Property DatoFiltro4() As String
        Get
            Return Me._DatoFiltro4
        End Get
        Set(ByVal value As String)
            Me._DatoFiltro4 = value
        End Set
    End Property

    Property CampoFiltro4() As String
        Get
            Return Me._CampoFiltro4
        End Get
        Set(ByVal value As String)
            Me._CampoFiltro4 = value
        End Set
    End Property


    Property EsVerdad() As Boolean
        Get
            Return Me._EsVerdad
        End Get
        Set(ByVal value As Boolean)
            Me._EsVerdad = value
        End Set
    End Property


    Property Mensaje() As String
        Get
            Return Me._Mensaje
        End Get
        Set(ByVal value As String)
            Me._Mensaje = value
        End Set
    End Property

    Property CorrelativoFile() As String
        Get
            Return Me._CorrelativoFile
        End Get
        Set(ByVal value As String)
            Me._CorrelativoFile = value
        End Set
    End Property

    Property DatoFiltro2() As String
        Get
            Return Me._DatoFiltro2
        End Get
        Set(ByVal value As String)
            Me._DatoFiltro2 = value
        End Set
    End Property

    Property CampoFiltro2() As String
        Get
            Return Me._CampoFiltro2
        End Get
        Set(ByVal value As String)
            Me._CampoFiltro2 = value
        End Set
    End Property

    Property DatoFiltro1() As String
        Get
            Return Me._DatoFiltro1
        End Get
        Set(ByVal value As String)
            Me._DatoFiltro1 = value
        End Set
    End Property

    Property CampoFiltro1() As String
        Get
            Return Me._CampoFiltro1
        End Get
        Set(ByVal value As String)
            Me._CampoFiltro1 = value
        End Set
    End Property
    Property CampoFecha() As String
        Get
            Return Me._CampoFecha
        End Get
        Set(ByVal value As String)
            Me._CampoFecha = value
        End Set
    End Property

    Property Desde() As DateTime
        Get
            Return Me._Desde
        End Get
        Set(ByVal value As DateTime)
            Me._Desde = value
        End Set
    End Property

    Property Hasta() As DateTime
        Get
            Return Me._Hasta
        End Get
        Set(ByVal value As DateTime)
            Me._Hasta = value
        End Set
    End Property


    Property Vista() As String
        Get
            Return Me._Vista
        End Get
        Set(ByVal value As String)
            Me._Vista = value
        End Set
    End Property

    Property CampoCondicion1() As String
        Get
            Return Me._CampoCondicion1
        End Get
        Set(ByVal value As String)
            Me._CampoCondicion1 = value
        End Set
    End Property

    Property DatoCondicion1() As String
        Get
            Return Me._DatoCondicion1
        End Get
        Set(ByVal value As String)
            Me._DatoCondicion1 = value
        End Set
    End Property


    Property CampoCondicion2() As String
        Get
            Return Me._CampoCondicion2
        End Get
        Set(ByVal value As String)
            Me._CampoCondicion2 = value
        End Set
    End Property

    Property DatoCondicion2() As String
        Get
            Return Me._DatoCondicion2
        End Get
        Set(ByVal value As String)
            Me._DatoCondicion2 = value
        End Set
    End Property

    Property CampoCondicion3() As String
        Get
            Return Me._CampoCondicion3
        End Get
        Set(ByVal value As String)
            Me._CampoCondicion3 = value
        End Set
    End Property

    Property DatoCondicion3() As String
        Get
            Return Me._DatoCondicion3
        End Get
        Set(ByVal value As String)
            Me._DatoCondicion3 = value
        End Set
    End Property


    Property CampoCondicion4() As String
        Get
            Return Me._CampoCondicion4
        End Get
        Set(ByVal value As String)
            Me._CampoCondicion4 = value
        End Set
    End Property

    Property DatoCondicion4() As String
        Get
            Return Me._DatoCondicion4
        End Get
        Set(ByVal value As String)
            Me._DatoCondicion4 = value
        End Set
    End Property

    Property DatoEliminado() As String
        Get
            Return Me._DatoEliminado
        End Get
        Set(ByVal value As String)
            Me._DatoEliminado = value
        End Set
    End Property

    Property DatoEstado() As String
        Get
            Return Me._DatoEstado
        End Get
        Set(ByVal value As String)
            Me._DatoEstado = value
        End Set
    End Property


    Property CursorPorFecha() As DateTime
        Get
            Return Me._CursorPorFecha
        End Get
        Set(ByVal value As DateTime)
            Me._CursorPorFecha = value
        End Set
    End Property

    Property CampoOrden() As String
        Get
            Return Me._CampoOrden
        End Get
        Set(ByVal value As String)
            Me._CampoOrden = value
        End Set
    End Property

    Property Orden() As String
        Get
            Return Me._Orden
        End Get
        Set(ByVal value As String)
            Me._Orden = value
        End Set
    End Property

    Property Filtro() As String
        Get
            Return Me._Filtro
        End Get
        Set(ByVal value As String)
            Me._Filtro = value
        End Set
    End Property

    Property CampoCursor() As String
        Get
            Return Me._CampoCursor
        End Get
        Set(ByVal value As String)
            Me._CampoCursor = value
        End Set
    End Property

    Property ColumnaBusqueda() As String
        Get
            Return Me._ColumnaBusqueda
        End Get
        Set(ByVal value As String)
            Me._ColumnaBusqueda = value
        End Set
    End Property

#End Region

#Region "Entidad Usuario"

    Private _CodigoUsuario As String
    Private _NombreUsuario As String
    Private _NombrePersonalUsuario As String
    Private _ClaveUsuario As String
    Private _EstadoUsuario As String
    Private _RespuestaUsuario As String
    Private _OperacionUsuario As String
    Private _NombreUsuarioModifica As String

    Property CodigoUsuario() As String
        Get
            Return Me._CodigoUsuario
        End Get
        Set(ByVal value As String)
            Me._CodigoUsuario = value
        End Set
    End Property

    Property NombrePersonalUsuario() As String
        Get
            Return _NombrePersonalUsuario
        End Get
        Set(ByVal value As String)
            Me._NombrePersonalUsuario = value
        End Set
    End Property

    Property NombreUsuario() As String
        Get
            Return _NombreUsuario
        End Get
        Set(ByVal value As String)
            Me._NombreUsuario = value
        End Set
    End Property

    Property ClaveUsuario() As String
        Get
            Return Me._ClaveUsuario
        End Get
        Set(ByVal value As String)
            Me._ClaveUsuario = value
        End Set
    End Property

    Property RespuestaUsuario() As String
        Get
            Return Me._RespuestaUsuario
        End Get
        Set(ByVal value As String)
            Me._RespuestaUsuario = value
        End Set
    End Property

    Property EstadoUsuario() As String
        Get
            Return Me._EstadoUsuario
        End Get
        Set(ByVal value As String)
            Me._EstadoUsuario = value
        End Set
    End Property

    Property OperacionUsuario() As String
        Get
            Return Me._OperacionUsuario
        End Get
        Set(ByVal value As String)
            Me._OperacionUsuario = value
        End Set
    End Property

#End Region

#Region "Entidad Pregunta Secreta"
    Private _CodigoPregunta As String
    Private _NombrePregunta As String

    Property CodigoPregunta() As String
        Get
            Return Me._CodigoPregunta
        End Get
        Set(ByVal value As String)
            Me._CodigoPregunta = value
        End Set
    End Property

    Property NombrePregunta() As String
        Get
            Return Me._NombrePregunta
        End Get
        Set(ByVal value As String)
            Me._NombrePregunta = value
        End Set
    End Property

#End Region

#Region "Entidad Pension"

    Private _CodigoPension As String
    Private _NombrePension As String

    Property CodigoPension() As String
        Get
            Return Me._CodigoPension
        End Get
        Set(ByVal value As String)
            Me._CodigoPension = value
        End Set
    End Property

    Property NombrePension() As String
        Get
            Return Me._NombrePension
        End Get
        Set(ByVal value As String)
            Me._NombrePension = value
        End Set
    End Property

#End Region

#Region "Entidad Centro de Costo"

    Private _CodigoCentroCosto As String = ""
    Private _NombreCentroCostro As String = ""

    Property CodigoCentroCosto() As String
        Get
            Return Me._CodigoCentroCosto
        End Get
        Set(ByVal value As String)
            Me._CodigoCentroCosto = value
        End Set
    End Property

    Property NombreCentroCosto() As String
        Get
            Return Me._NombreCentroCostro
        End Get
        Set(ByVal value As String)
            Me._NombreCentroCostro = value
        End Set
    End Property

#End Region

#Region "Entidad Axiliar"
    Private _CodigoAuxiliar As String = ""
    Private _ApellidoPaternoAuxiliar As String = ""
    Private _ApellidoMaternoAuxiliar As String = ""
    Private _PrimerNombreAuxiliar As String = ""
    Private _SegundoNombreAuxiliar As String = ""
    Private _DescripcionAuxiliar As String = ""
    Private _DireccionAuxiliar As String = ""
    Private _TelefonoAuxiliar As String = ""
    Private _CelularAuxiliar As String = ""
    Private _CorreoAuxiliar As String = ""
    Private _ReferenciaAuxiliar As String = ""
    Private _TipoAuxiliar As String = ""
    Private _TipoDocumentoAuxiliar As String = ""
    Private _PaisNoDomiciliadoAuxiliar As String = ""
    Private _NombrePaisNoDomiciliadoAuxiliar As String = ""
    Private _EstadoAuxiliar As String = ""
    Private _FechaInscripcionSnpAuxiliar As String = ""

    Property FechaInscripcionSnpAuxiliar() As String
        Get
            Return Me._FechaInscripcionSnpAuxiliar
        End Get
        Set(ByVal value As String)
            Me._FechaInscripcionSnpAuxiliar = value
        End Set
    End Property

    Property CodigoAuxiliar() As String
        Get
            Return Me._CodigoAuxiliar
        End Get
        Set(ByVal value As String)
            Me._CodigoAuxiliar = value
        End Set
    End Property

    Property ApellidoPaternoAuxiliar() As String
        Get
            Return Me._ApellidoPaternoAuxiliar
        End Get
        Set(ByVal value As String)
            Me._ApellidoPaternoAuxiliar = value
        End Set
    End Property

    Property ApellidoMaternoAuxiliar() As String
        Get
            Return Me._ApellidoMaternoAuxiliar
        End Get
        Set(ByVal value As String)
            Me._ApellidoMaternoAuxiliar = value
        End Set
    End Property


    Property PrimerNombreAuxiliar() As String
        Get
            Return Me._PrimerNombreAuxiliar
        End Get
        Set(ByVal value As String)
            Me._PrimerNombreAuxiliar = value
        End Set
    End Property


    Property SegundoNombreAuxiliar() As String
        Get
            Return Me._SegundoNombreAuxiliar
        End Get
        Set(ByVal value As String)
            Me._SegundoNombreAuxiliar = value
        End Set
    End Property

    Property DescripcionAuxiliar() As String

        Get
            Return Me._DescripcionAuxiliar
        End Get
        Set(ByVal value As String)
            Me._DescripcionAuxiliar = value
        End Set
    End Property

    Property DireccionAuxiliar() As String
        Get
            Return Me._DireccionAuxiliar
        End Get
        Set(ByVal value As String)
            Me._DireccionAuxiliar = value
        End Set
    End Property

    Property TelefonoAuxiliar() As String
        Get
            Return Me._TelefonoAuxiliar
        End Get
        Set(ByVal value As String)
            Me._TelefonoAuxiliar = value
        End Set
    End Property

    Property CelularAuxiliar() As String
        Get
            Return Me._CelularAuxiliar
        End Get
        Set(ByVal value As String)
            Me._CelularAuxiliar = value
        End Set
    End Property

    Property CorreoAuxiliar() As String
        Get
            Return Me._CorreoAuxiliar
        End Get
        Set(ByVal value As String)
            Me._CorreoAuxiliar = value
        End Set
    End Property

    Property ReferenciaAuxiliar() As String
        Get
            Return Me._ReferenciaAuxiliar
        End Get
        Set(ByVal value As String)
            Me._ReferenciaAuxiliar = value
        End Set
    End Property

    Property TipoAuxiliar() As String
        Get
            Return Me._TipoAuxiliar
        End Get
        Set(ByVal value As String)
            Me._TipoAuxiliar = value
        End Set
    End Property


    Property TipoDocumentoAuxiliar() As String
        Get
            Return Me._TipoDocumentoAuxiliar
        End Get
        Set(ByVal value As String)
            Me._TipoDocumentoAuxiliar = value
        End Set
    End Property

    Property PaisNoDomiciliadoAuxiliar() As String
        Get
            Return Me._PaisNoDomiciliadoAuxiliar
        End Get
        Set(ByVal value As String)
            Me._PaisNoDomiciliadoAuxiliar = value
        End Set
    End Property

    Property NombrePaisNoDomiciliadoAuxiliar() As String
        Get
            Return Me._NombrePaisNoDomiciliadoAuxiliar
        End Get
        Set(ByVal value As String)
            Me._NombrePaisNoDomiciliadoAuxiliar = value
        End Set
    End Property

    Property EstadoAuxiliar() As String
        Get
            Return Me._EstadoAuxiliar
        End Get
        Set(ByVal value As String)
            Me._EstadoAuxiliar = value
        End Set
    End Property

#End Region

#Region "Entidad Documento identidad"
    Private _CodigoDocumentoIdentidad As String = ""
    Private _NombreDocumentoIdentidad As String = ""


    Property CodigoDocumentoIdentidad() As String
        Get
            Return Me._CodigoDocumentoIdentidad
        End Get
        Set(ByVal value As String)
            Me._CodigoDocumentoIdentidad = value
        End Set
    End Property

    Property NombreDocumentoIdentidad() As String
        Get
            Return Me._NombreDocumentoIdentidad
        End Get
        Set(ByVal value As String)
            Me._NombreDocumentoIdentidad = value
        End Set
    End Property


#End Region

#Region "Entidad Tabla"
    Private _TipoTabla As String = ""
    Private _CodigoItemTabla As String = ""
    Private _NombreItemTabla As String = ""
    Private _Voucher As String
    Private _NumeroApertura As String
    Private _NumeroEnero As String
    Private _NumeroFebrero As String
    Private _NumeroMarzo As String
    Private _NumeroAbril As String
    Private _NumeroMayo As String
    Private _NumeroJunio As String
    Private _NumeroJulio As String
    Private _NumeroAgosto As String
    Private _NumeroSetiembre As String
    Private _NumeroOctubre As String
    Private _NumeroNoviembre As String
    Private _NumeroDiciembre As String
    Private _NumeroCierre As String
    Private _NumDiasItemTabla As String = ""
    Private _EstadoItemTabla As String = ""
    Private _EliminaItemTable As String = ""
    Property TipoTabla() As String
        Get
            Return Me._TipoTabla
        End Get
        Set(ByVal value As String)
            Me._TipoTabla = value
        End Set
    End Property

    Property Voucher() As String
        Get
            Return Me._Voucher
        End Get
        Set(ByVal value As String)
            Me._Voucher = value
        End Set
    End Property

    Property NumeroApertura() As String
        Get
            Return Me._NumeroApertura
        End Get
        Set(ByVal value As String)
            Me._NumeroApertura = value
        End Set
    End Property

    Property NumeroEnero() As String
        Get
            Return Me._NumeroEnero
        End Get
        Set(ByVal value As String)
            Me._NumeroEnero = value
        End Set
    End Property


    Property NumeroFebrero() As String
        Get
            Return Me._NumeroFebrero
        End Get
        Set(ByVal value As String)
            Me._NumeroFebrero = value
        End Set
    End Property

    Property NumeroMarzo() As String
        Get
            Return Me._NumeroMarzo
        End Get
        Set(ByVal value As String)
            Me._NumeroMarzo = value
        End Set
    End Property
    Property NumeroAbril() As String
        Get
            Return Me._NumeroAbril
        End Get
        Set(ByVal value As String)
            Me._NumeroAbril = value
        End Set
    End Property

    Property NumeroMayo() As String
        Get
            Return Me._NumeroMayo
        End Get
        Set(ByVal value As String)
            Me._NumeroMayo = value
        End Set
    End Property


    Property NumeroJunio() As String
        Get
            Return Me._NumeroJunio
        End Get
        Set(ByVal value As String)
            Me._NumeroJunio = value
        End Set
    End Property

    Property NumeroJulio() As String
        Get
            Return Me._NumeroJulio
        End Get
        Set(ByVal value As String)
            Me._NumeroJulio = value
        End Set
    End Property

    Property NumeroAgosto() As String
        Get
            Return Me._NumeroAgosto
        End Get
        Set(ByVal value As String)
            Me._NumeroAgosto = value
        End Set
    End Property


    Property NumeroSetiembre() As String
        Get
            Return Me._NumeroSetiembre
        End Get
        Set(ByVal value As String)
            Me._NumeroSetiembre = value
        End Set
    End Property
    Property NumeroOctubre() As String
        Get
            Return Me._NumeroOctubre
        End Get
        Set(ByVal value As String)
            Me._NumeroOctubre = value
        End Set
    End Property

    Property NumeroNoviembre() As String
        Get
            Return Me._NumeroNoviembre
        End Get
        Set(ByVal value As String)
            Me._NumeroNoviembre = value
        End Set
    End Property

    Property NumeroDiciembre() As String
        Get
            Return Me._NumeroDiciembre
        End Get
        Set(ByVal value As String)
            Me._NumeroDiciembre = value
        End Set
    End Property

    Property NumeroCierre() As String
        Get
            Return Me._NumeroCierre
        End Get
        Set(ByVal value As String)
            Me._NumeroCierre = value
        End Set
    End Property

    Property CodigoItemTabla() As String
        Get
            Return Me._CodigoItemTabla
        End Get
        Set(ByVal value As String)
            Me._CodigoItemTabla = value
        End Set
    End Property

    Property NombreItemTabla() As String
        Get
            Return Me._NombreItemTabla
        End Get
        Set(ByVal value As String)
            Me._NombreItemTabla = value
        End Set
    End Property

    Property NumDiasItemTabla() As String
        Get
            Return Me._NumDiasItemTabla
        End Get
        Set(ByVal value As String)
            Me._NumDiasItemTabla = value
        End Set
    End Property

    Property EstadoItemTabla() As String
        Get
            Return Me._EstadoItemTabla
        End Get
        Set(ByVal value As String)
            Me._EstadoItemTabla = value
        End Set
    End Property

    Property EliminaItemTabla() As String
        Get
            Return Me._EliminaItemTable
        End Get
        Set(ByVal value As String)
            Me._EliminaItemTable = value
        End Set
    End Property




#End Region

#Region "Entidad Origen"
    Private _CodigoOrigen As String = ""
    Private _NombreOrigen As String = ""

    Property CodigoOrigen() As String
        Get
            Return Me._CodigoOrigen
        End Get
        Set(ByVal value As String)
            Me._CodigoOrigen = value
        End Set
    End Property

    Property NombreOrigen() As String
        Get
            Return Me._NombreOrigen
        End Get
        Set(ByVal value As String)
            Me._NombreOrigen = value
        End Set
    End Property

#End Region

#Region "Entidad Modo Pago"
    Private _CodigoModoPago As String = ""
    Private _NombreModoPago As String = ""

    Property CodigoModoPago() As String
        Get
            Return Me._CodigoModoPago
        End Get
        Set(ByVal value As String)
            Me._CodigoModoPago = value
        End Set
    End Property

    Property NombreModoPago() As String
        Get
            Return Me._NombreModoPago
        End Get
        Set(ByVal value As String)
            Me._NombreModoPago = value
        End Set
    End Property

#End Region

#Region "Entidad File"
    Private _CodigoFile As String = ""
    Private _NombreFile As String = ""

    Property CodigoFile() As String
        Get
            Return Me._CodigoFile
        End Get
        Set(ByVal value As String)
            Me._CodigoFile = value
        End Set
    End Property

    Property NombreFile() As String
        Get
            Return Me._NombreFile
        End Get
        Set(ByVal value As String)
            Me._NombreFile = value
        End Set
    End Property

#End Region

#Region "Entidad Files"
    Private _ClaveFile As String = ""
    Private _EstadoFile As String = ""

    Property ClaveFile() As String
        Get
            Return Me._ClaveFile
        End Get
        Set(ByVal value As String)
            Me._ClaveFile = value
        End Set
    End Property

    Property EstadoFile() As String
        Get
            Return Me._EstadoFile
        End Get
        Set(ByVal value As String)
            Me._EstadoFile = value
        End Set
    End Property

#End Region

#Region "Entidad Ingresos/Egresos"
    Private _CodigoIngEgr As String = String.Empty
    Private _NombreIngEgr As String = ""

    Property CodigoIngEgr() As String
        Get
            Return Me._CodigoIngEgr
        End Get
        Set(ByVal value As String)
            Me._CodigoIngEgr = value
        End Set
    End Property

    Property NombreIngEgr() As String
        Get
            Return Me._NombreIngEgr
        End Get
        Set(ByVal value As String)
            Me._NombreIngEgr = value
        End Set
    End Property

#End Region

#Region "Entidad Mes"
    Private _CodigoMes As String = ""
    Private _NombreMes As String = ""

    Property CodigoMes() As String
        Get
            Return Me._CodigoMes
        End Get
        Set(ByVal value As String)
            Me._CodigoMes = value
        End Set
    End Property

    Property NombreMes() As String
        Get
            Return Me._NombreMes
        End Get
        Set(ByVal value As String)
            Me._NombreMes = value
        End Set
    End Property

#End Region

#Region "Auditoria"

    Private _CodigoUsuarioAgrega As String
    Private _CodigoPersonalAgrega As String
    Private _NombreUsuarioAgrega As String
    Private _FechaAgrega As DateTime = Today
    Private _CodigoUsuarioModifica As String
    Private _CodigoPersonalModifica As String
    'Private _NombreUsuarioModifica As String
    Private _FechaModifica As DateTime = Today
    Private _EstadoRegistro As String = ""
    Private _EliminadoRegistro As String = "1"
    Private _Exporta As String = ""

    Property Exporta() As String
        Get
            Return Me._Exporta
        End Get
        Set(ByVal value As String)
            Me._Exporta = value
        End Set
    End Property

    Property CodigoPersonalAgrega() As String
        Get
            Return Me._CodigoPersonalAgrega
        End Get
        Set(ByVal value As String)
            Me._CodigoPersonalAgrega = value
        End Set
    End Property

    Property CodigoPersonalModifica() As String
        Get
            Return Me._CodigoPersonalModifica
        End Get
        Set(ByVal value As String)
            Me._CodigoPersonalModifica = value
        End Set
    End Property

    Property CodigoUsuarioAgrega() As String
        Get
            Return Me._CodigoUsuarioAgrega
        End Get
        Set(ByVal value As String)
            Me._CodigoUsuarioAgrega = value
        End Set
    End Property

    'Property NombreUsuarioAgrega() As String
    '       Get
    '              Return Me._NombreUsuarioAgrega
    '       End Get
    '       Set(ByVal value As String)
    '              Me._NombreUsuarioAgrega = value
    '       End Set
    'End Property

    Property FechaAgrega() As DateTime
        Get
            Return Me._FechaAgrega
        End Get
        Set(ByVal value As DateTime)
            Me._FechaAgrega = value
        End Set
    End Property

    Property CodigoUsuarioModifica() As String
        Get
            Return Me._CodigoUsuarioModifica
        End Get
        Set(ByVal value As String)
            Me._CodigoUsuarioModifica = value
        End Set
    End Property


    'Property NombreUsuarioModifica() As String
    '       Get
    '              Return Me._NombreUsuarioModifica
    '       End Get
    '       Set(ByVal value As String)
    '              Me._NombreUsuarioModifica = value
    '       End Set
    'End Property

    Property FechaModifica() As DateTime
        Get
            Return Me._FechaModifica
        End Get
        Set(ByVal value As DateTime)
            Me._FechaModifica = value
        End Set
    End Property

    Property EstadoRegistro() As String
        Get
            Return Me._EstadoRegistro
        End Get
        Set(ByVal value As String)
            Me._EstadoRegistro = value
        End Set
    End Property

    Property EliminadoRegistro() As String
        Get
            Return Me._EliminadoRegistro
        End Get
        Set(ByVal value As String)
            Me._EliminadoRegistro = value
        End Set
    End Property

    Property NombreUsuarioAgrega() As String
        Get
            Return Me._NombreUsuarioAgrega
        End Get
        Set(ByVal value As String)
            Me._NombreUsuarioAgrega = value
        End Set
    End Property

    Property NombreUsuarioModifica() As String
        Get
            Return Me._NombreUsuarioModifica
        End Get
        Set(ByVal value As String)
            Me._NombreUsuarioModifica = value
        End Set
    End Property

#End Region

#Region "Tipo Cambio"
    Private _FechaTipoCambio As DateTime = Today
    Private _CompraTipoCambio As Decimal
    Private _VentaTipoCambio As Decimal
    Private _CompraEurTipoCambio As Decimal
    Private _VentaEurTipoCambio As Decimal
    Private _MesTipoCambio As String = ""
    Private _AnoTipoCambio As String = ""
    Private _DolarEuroTipoCambio As Decimal

    Property DolarEuroTipoCambio() As Decimal
        Get
            Return Me._DolarEuroTipoCambio
        End Get
        Set(ByVal value As Decimal)
            Me._DolarEuroTipoCambio = value
        End Set
    End Property

    Property FechaTipoCambio() As DateTime
        Get
            Return Me._FechaTipoCambio
        End Get
        Set(ByVal value As DateTime)
            Me._FechaTipoCambio = value
        End Set
    End Property
    Property CompraTipoCambio() As Decimal
        Get
            Return Me._CompraTipoCambio
        End Get
        Set(ByVal value As Decimal)
            Me._CompraTipoCambio = value
        End Set
    End Property

    Property VentaTipoCambio() As Decimal
        Get
            Return Me._VentaTipoCambio
        End Get
        Set(ByVal value As Decimal)
            Me._VentaTipoCambio = value
        End Set
    End Property

    Property CompraEurTipoCambio() As Decimal
        Get
            Return Me._CompraEurTipoCambio
        End Get
        Set(ByVal value As Decimal)
            Me._CompraEurTipoCambio = value
        End Set
    End Property

    Property VentaEurTipoCambio() As Decimal
        Get
            Return Me._VentaEurTipoCambio
        End Get
        Set(ByVal value As Decimal)
            Me._VentaEurTipoCambio = value
        End Set
    End Property

    Property MesTipoCambio() As String
        Get
            Return Me._MesTipoCambio
        End Get
        Set(ByVal value As String)
            Me._MesTipoCambio = value
        End Set
    End Property

    Property AnoTipoCambio() As String
        Get
            Return Me._AnoTipoCambio
        End Get
        Set(ByVal value As String)
            Me._AnoTipoCambio = value
        End Set
    End Property

#End Region

#Region "Entidad Tipo Documento"
    Private _TipoDocumento As String = ""
    Private _TipoDocumento1 As String = ""
    Private _NombreDocumento As String = ""
    Private _NombreDocumento1 As String = ""

    Property TipoDocumento() As String
        Get
            Return Me._TipoDocumento
        End Get
        Set(ByVal value As String)
            Me._TipoDocumento = value
        End Set
    End Property

    Property TipoDocumento1() As String
        Get
            Return Me._TipoDocumento1
        End Get
        Set(ByVal value As String)
            Me._TipoDocumento1 = value
        End Set
    End Property

    Property NombreDocumento() As String
        Get
            Return Me._NombreDocumento
        End Get
        Set(ByVal value As String)
            Me._NombreDocumento = value
        End Set
    End Property

    Property NombreDocumento1() As String
        Get
            Return Me._NombreDocumento1
        End Get
        Set(ByVal value As String)
            Me._NombreDocumento1 = value
        End Set
    End Property

#End Region

#Region "Entidad Parametro"
    Private _IgvPar As Decimal
    Private _PorGastosGenerales As Decimal
    Private _PorGastosAdministrativos As Decimal
    Private _PorUtilidad As Decimal
    Private _CuentaTransferencia As String
    Private _PorRetencionHonorario As Decimal
    Private _DigitosCuentaAnalitica As String
    Private _CuentaIgv As String
    Private _CuentaValorVenta As String
    Private _CuentaPrecioVenta As String
    Private _CuentaHonorarioNeto As String
    Private _CuentaAutomatica As String
    Private _CuentaHonorarioRetencion As String
    Private _CuentaGananciaDc As String
    Private _CuentaPerdidaDc As String
    Private _PorcentajeDsctoAfp2014 As Decimal
    Private _PorcentajeDsctoAfp2015 As Decimal
    Private _PorcentajeDsctoAfp2016 As Decimal
    Private _PorcentajeDsctoSnp2014 As Decimal
    Private _PorcentajeDsctoSnp2015 As Decimal
    Private _PorcentajeDsctoSnp2016 As Decimal
    Private _CuentaAfp As String
    Private _CuentaSnp As String
    Private _CuentaClase8Cierre As String
    Private _CuentaGananciaCierre As String
    Private _CuentaPerdidaCierre As String
    Private _PorcentajeImpuestoRenta As Decimal
    Private _CodigoOrigenDiario As String
    Private _CodigoFileDiario As String
    Private _CCodigoOrigenRegistroVentas As String
    Private _CCodigoFileRegistroVentas As String
    Private _CuentaCuotaOrdinaria As String
    Private _CuentaCuotaSupervisionYProyectos As String
    Private _CuentaCuotaAgua As String
    Private _CuentaCuotaElecricidad As String
    Private _CuentaCuotaIngreso As String
    Private _CuentaCuotaExtraOrdinaria As String
    Private _CuentaCuotaMoras As String
    Private _CuentaMontoTotalCuotas As String

    Property CCodigoOrigenRegistroVentas() As String
        Get
            Return Me._CCodigoOrigenRegistroVentas
        End Get
        Set(ByVal value As String)
            Me._CCodigoOrigenRegistroVentas = value
        End Set
    End Property

    Property CCodigoFileRegistroVentas() As String
        Get
            Return Me._CCodigoFileRegistroVentas
        End Get
        Set(ByVal value As String)
            Me._CCodigoFileRegistroVentas = value
        End Set
    End Property

    Property CuentaCuotaOrdinaria() As String
        Get
            Return Me._CuentaCuotaOrdinaria
        End Get
        Set(ByVal value As String)
            Me._CuentaCuotaOrdinaria = value
        End Set
    End Property

    Property CuentaCuotaSupervisionYProyectos() As String
        Get
            Return Me._CuentaCuotaSupervisionYProyectos
        End Get
        Set(ByVal value As String)
            Me._CuentaCuotaSupervisionYProyectos = value
        End Set
    End Property

    Property CuentaCuotaAgua() As String
        Get
            Return Me._CuentaCuotaAgua
        End Get
        Set(ByVal value As String)
            Me._CuentaCuotaAgua = value
        End Set
    End Property

    Property CuentaCuotaElectricidad() As String
        Get
            Return Me._CuentaCuotaElecricidad
        End Get
        Set(ByVal value As String)
            Me._CuentaCuotaElecricidad = value
        End Set
    End Property

    Property CuentaCuotaIngreso() As String
        Get
            Return Me._CuentaCuotaIngreso
        End Get
        Set(ByVal value As String)
            Me._CuentaCuotaIngreso = value
        End Set
    End Property

    Property CuentaCuotaExtraordinaria() As String
        Get
            Return Me._CuentaCuotaExtraOrdinaria
        End Get
        Set(ByVal value As String)
            Me._CuentaCuotaExtraOrdinaria = value
        End Set
    End Property

    Property CuentaCuotaMoras() As String
        Get
            Return Me._CuentaCuotaMoras
        End Get
        Set(ByVal value As String)
            Me._CuentaCuotaMoras = value
        End Set
    End Property

    Property CuentaMontoTotalCuotas() As String
        Get
            Return Me._CuentaMontoTotalCuotas
        End Get
        Set(ByVal value As String)
            Me._CuentaMontoTotalCuotas = value
        End Set
    End Property

    Property CodigoOrigenDiario() As String
        Get
            Return Me._CodigoOrigenDiario
        End Get
        Set(ByVal value As String)
            Me._CodigoOrigenDiario = value
        End Set
    End Property

    Property CodigoFileDiario() As String
        Get
            Return Me._CodigoFileDiario
        End Get
        Set(ByVal value As String)
            Me._CodigoFileDiario = value
        End Set
    End Property

    Property PorcentajeImpuestoRenta() As Decimal
        Get
            Return Me._PorcentajeImpuestoRenta
        End Get
        Set(ByVal value As Decimal)
            Me._PorcentajeImpuestoRenta = value
        End Set
    End Property


    Property CuentaClase8Cierre() As String
        Get
            Return Me._CuentaClase8Cierre
        End Get
        Set(ByVal value As String)
            Me._CuentaClase8Cierre = value
        End Set
    End Property

    Property CuentaGananciaCierre() As String
        Get
            Return Me._CuentaGananciaCierre
        End Get
        Set(ByVal value As String)
            Me._CuentaGananciaCierre = value
        End Set
    End Property

    Property CuentaPerdidaCierre() As String
        Get
            Return Me._CuentaPerdidaCierre
        End Get
        Set(ByVal value As String)
            Me._CuentaPerdidaCierre = value
        End Set
    End Property


    Property CuentaAfp() As String
        Get
            Return Me._CuentaAfp
        End Get
        Set(ByVal value As String)
            Me._CuentaAfp = value
        End Set
    End Property

    Property CuentaSnp() As String
        Get
            Return Me._CuentaSnp
        End Get
        Set(ByVal value As String)
            Me._CuentaSnp = value
        End Set
    End Property

    Property PorcentajeDsctoAfp2014() As Decimal
        Get
            Return Me._PorcentajeDsctoAfp2014
        End Get
        Set(ByVal value As Decimal)
            Me._PorcentajeDsctoAfp2014 = value
        End Set
    End Property

    Property PorcentajeDsctoAfp2015() As Decimal
        Get
            Return Me._PorcentajeDsctoAfp2015
        End Get
        Set(ByVal value As Decimal)
            Me._PorcentajeDsctoAfp2015 = value
        End Set
    End Property

    Property PorcentajeDsctoAfp2016() As Decimal
        Get
            Return Me._PorcentajeDsctoAfp2016
        End Get
        Set(ByVal value As Decimal)
            Me._PorcentajeDsctoAfp2016 = value
        End Set
    End Property

    Property PorcentajeDsctoSnp2014() As Decimal
        Get
            Return Me._PorcentajeDsctoSnp2014
        End Get
        Set(ByVal value As Decimal)
            Me._PorcentajeDsctoSnp2014 = value
        End Set
    End Property

    Property PorcentajeDsctoSnp2015() As Decimal
        Get
            Return Me._PorcentajeDsctoSnp2015
        End Get
        Set(ByVal value As Decimal)
            Me._PorcentajeDsctoSnp2015 = value
        End Set
    End Property

    Property PorcentajeDsctoSnp2016() As Decimal
        Get
            Return Me._PorcentajeDsctoSnp2016
        End Get
        Set(ByVal value As Decimal)
            Me._PorcentajeDsctoSnp2016 = value
        End Set
    End Property

    Property CuentaAutomatica() As String
        Get
            Return Me._CuentaAutomatica
        End Get
        Set(ByVal value As String)
            Me._CuentaAutomatica = value
        End Set
    End Property

    Property CuentaHonorarioNeto() As String
        Get
            Return Me._CuentaHonorarioNeto
        End Get
        Set(ByVal value As String)
            Me._CuentaHonorarioNeto = value
        End Set
    End Property

    Property CuentaHonorarioRetencion() As String
        Get
            Return Me._CuentaHonorarioRetencion
        End Get
        Set(ByVal value As String)
            Me._CuentaHonorarioRetencion = value
        End Set
    End Property

    Property CuentaIgv() As String
        Get
            Return Me._CuentaIgv
        End Get
        Set(ByVal value As String)
            Me._CuentaIgv = value
        End Set
    End Property

    Property CuentaValorVenta() As String
        Get
            Return Me._CuentaValorVenta
        End Get
        Set(ByVal value As String)
            Me._CuentaValorVenta = value
        End Set
    End Property

    Property CuentaPrecioVenta() As String
        Get
            Return Me._CuentaPrecioVenta
        End Get
        Set(ByVal value As String)
            Me._CuentaPrecioVenta = value
        End Set
    End Property

    Property IgvPar() As Decimal
        Get
            Return Me._IgvPar
        End Get
        Set(ByVal value As Decimal)
            Me._IgvPar = value
        End Set
    End Property

    Property PorGastosGenerales() As Decimal
        Get
            Return Me._PorGastosGenerales
        End Get
        Set(ByVal value As Decimal)
            Me._PorGastosGenerales = value
        End Set
    End Property

    Property PorGastosAdministrativos() As Decimal
        Get
            Return Me._PorGastosAdministrativos
        End Get
        Set(ByVal value As Decimal)
            Me._PorGastosAdministrativos = value
        End Set
    End Property

    Property PorUtilidad() As Decimal
        Get
            Return Me._PorUtilidad
        End Get
        Set(ByVal value As Decimal)
            Me._PorUtilidad = value
        End Set
    End Property

    Property PorRetencionHonorario() As Decimal
        Get
            Return Me._PorRetencionHonorario
        End Get
        Set(ByVal value As Decimal)
            Me._PorRetencionHonorario = value
        End Set
    End Property

    Property CuentaTransferencia() As String
        Get
            Return Me._CuentaTransferencia
        End Get
        Set(ByVal value As String)
            Me._CuentaTransferencia = value
        End Set
    End Property

    Property DigitosCuentaAnalitica() As String
        Get
            Return Me._DigitosCuentaAnalitica
        End Get
        Set(ByVal value As String)
            Me._DigitosCuentaAnalitica = value
        End Set
    End Property

    Property CuentaGananciaDC() As String
        Get
            Return Me._CuentaGananciaDc
        End Get
        Set(ByVal value As String)
            Me._CuentaGananciaDc = value
        End Set
    End Property

    Property CuentaPerdidaDC() As String
        Get
            Return Me._CuentaPerdidaDc
        End Get
        Set(ByVal value As String)
            Me._CuentaPerdidaDc = value
        End Set
    End Property

#End Region

#Region "Entidad Reg Contab Cabe"
    Private _PeriodoRegContabCabe As String = ""
    Private _NumeroVoucherRegContabCabe As String = ""
    Private _ClaveRegContabCabe As String = ""
    Private _MonedaVoucherRegContabCabe As String = ""
    Private _DiaVoucherRegContabCabe As String = ""
    Private _FechaVoucherRegContabCabe As DateTime = Today
    Private _SerieDocumento As String = ""
    Private _NumeroDocumento As String = ""
    Private _FechaDocumento As DateTime = Today
    Private _MonedaDocumento As String = ""
    Private _SerieDocumento1 As String = ""
    Private _NumeroDocumento1 As String = ""
    Private _FechaDocumento1 As String = ""
    Private _MonedaDocumento1 As String = ""
    Private _ValorVtaRegContabCabe As Decimal = 0
    Private _IgvRegContabCabe As Decimal = 0
    Private _ExoneradoRegContabCabe As Decimal = 0
    Private _PrecioVtaRegContabCabe As Decimal = 0
    Private _ValorVtaSolRegContabCabe As Decimal = 0
    Private _IgvSolRegContabCabe As Decimal = 0
    Private _ExoneradoSolRegContabCabe As Decimal = 0
    Private _PrecioVtaSolRegContabCabe As Decimal = 0
    Private _GlosaRegContabCabe As String = ""
    Private _ImporteRegContabCabe As Decimal = 0
    Private _DetraccionRegContabCabe As String = ""
    Private _NumeroPapeletaRegContabCabe As String = ""
    Private _FechaDetraccionRegContabCabe As String = ""
    Private _RetencionRegContabCabe As String = ""
    Private _CartaRegContabCabe As String = ""
    Private _DescripcionRegContabCabe As String = ""
    Private _VoucherIngresoRegContabCabe As String = ""
    Private _EstadoRegContabCabe As String = ""
    Private _SumaDebeRegContabCabe As Decimal = 0
    Private _SumaHaberRegContabCabe As Decimal = 0
    Private _UltimoCorrelativo As String = ""
    Private _DiferenciaDH As Decimal = 0
    Private _FechaVencimiento As DateTime = Today
    Private _ImporteSolRegContabCabe As Decimal = 0
    Private _ModoCompra As String = ""
    Private _EstadoRegistroRcc As String = ""
    Private _ClaveConsultaVoucher As String = ""
    Private _FlagDescuentoRegContabCabe As String = ""
    Private _ImporteDescuentoRegContabCabe As Decimal = 0
    Private _DescuentoFondo As Decimal = 0
    Private _DescuentoSalud As Decimal = 0
    Private _DescuentoRemu As Decimal = 0
    Private _CodigoOrigenVentas As String
    Private _CodigoFileVentas As String
    Private _Cuenta16PrecioVentaEmpresa As String
    Private _Cuenta75ValorVentaEmpresa As String
    Private _CuentaIgvEmpresa As String

    Property CuentaIgvEmpresa() As String
        Get
            Return Me._CuentaIgvEmpresa
        End Get
        Set(ByVal value As String)
            Me._CuentaIgvEmpresa = value
        End Set
    End Property

    Property Cuenta16PrecioVentaEmpresa() As String
        Get
            Return Me._Cuenta16PrecioVentaEmpresa
        End Get
        Set(ByVal value As String)
            Me._Cuenta16PrecioVentaEmpresa = value
        End Set
    End Property

    Property Cuenta75ValorVentaEmpresa() As String
        Get
            Return Me._Cuenta75ValorVentaEmpresa
        End Get
        Set(ByVal value As String)
            Me._Cuenta75ValorVentaEmpresa = value
        End Set
    End Property

    Property CodigoOrigenVentas() As String
        Get
            Return Me._CodigoOrigenVentas
        End Get
        Set(ByVal value As String)
            Me._CodigoOrigenVentas = value
        End Set
    End Property


    Property CodigoFileVentas() As String
        Get
            Return Me._CodigoFileVentas
        End Get
        Set(ByVal value As String)
            Me._CodigoFileVentas = value
        End Set
    End Property

    Property DescuentoRemu() As Decimal
        Get
            Return Me._DescuentoRemu
        End Get
        Set(ByVal value As Decimal)
            Me._DescuentoRemu = value
        End Set
    End Property

    Property DescuentoSalud() As Decimal
        Get
            Return Me._DescuentoSalud
        End Get
        Set(ByVal value As Decimal)
            Me._DescuentoSalud = value
        End Set
    End Property


    Property DescuentoFondo() As Decimal
        Get
            Return Me._DescuentoFondo
        End Get
        Set(ByVal value As Decimal)
            Me._DescuentoFondo = value
        End Set
    End Property

    Property FlagDescuentoRegContabCabe() As String
        Get
            Return Me._FlagDescuentoRegContabCabe
        End Get
        Set(ByVal value As String)
            Me._FlagDescuentoRegContabCabe = value
        End Set
    End Property


    Property ImporteDescuentoRegContabCabe() As Decimal
        Get
            Return Me._ImporteDescuentoRegContabCabe
        End Get
        Set(ByVal value As Decimal)
            Me._ImporteDescuentoRegContabCabe = value
        End Set
    End Property

    Property ClaveConsultaVoucher() As String
        Get
            Return Me._ClaveConsultaVoucher
        End Get
        Set(ByVal value As String)
            Me._ClaveConsultaVoucher = value
        End Set
    End Property


    Property EstadoRegistroRcc() As String
        Get
            Return Me._EstadoRegistroRcc
        End Get
        Set(ByVal value As String)
            Me._EstadoRegistroRcc = value
        End Set
    End Property


    Property ModoCompra() As String
        Get
            Return Me._ModoCompra
        End Get
        Set(ByVal value As String)
            Me._ModoCompra = value
        End Set
    End Property


    Property ImporteSolRegContabCabe() As Decimal
        Get
            Return Me._ImporteSolRegContabCabe
        End Get
        Set(ByVal value As Decimal)
            Me._ImporteSolRegContabCabe = value
        End Set
    End Property

    Property FechaVencimiento() As DateTime
        Get
            Return Me._FechaVencimiento
        End Get
        Set(ByVal value As DateTime)
            Me._FechaVencimiento = value
        End Set
    End Property

    Property DiferenciaDH() As Decimal
        Get
            Return Me._DiferenciaDH
        End Get
        Set(ByVal value As Decimal)
            Me._DiferenciaDH = value
        End Set
    End Property


    Property SumaDebeRegContabCabe() As Decimal
        Get
            Return Me._SumaDebeRegContabCabe
        End Get
        Set(ByVal value As Decimal)
            Me._SumaDebeRegContabCabe = value
        End Set
    End Property

    Property SumaHaberRegContabCabe() As Decimal
        Get
            Return Me._SumaHaberRegContabCabe
        End Get
        Set(ByVal value As Decimal)
            Me._SumaHaberRegContabCabe = value
        End Set
    End Property

    Property UltimoCorrelativo() As String
        Get
            Return Me._UltimoCorrelativo
        End Get
        Set(ByVal value As String)
            Me._UltimoCorrelativo = value
        End Set
    End Property

    Property PeriodoRegContabCabe() As String
        Get
            Return Me._PeriodoRegContabCabe
        End Get
        Set(ByVal value As String)
            Me._PeriodoRegContabCabe = value
        End Set
    End Property

    Property NumeroVoucherRegContabCabe() As String
        Get
            Return Me._NumeroVoucherRegContabCabe
        End Get
        Set(ByVal value As String)
            Me._NumeroVoucherRegContabCabe = value
        End Set
    End Property

    Property ClaveRegContabCabe() As String
        Get
            Return Me._ClaveRegContabCabe
        End Get
        Set(ByVal value As String)
            Me._ClaveRegContabCabe = value
        End Set
    End Property

    Property MonedaVoucherRegContabCabe() As String
        Get
            Return Me._MonedaVoucherRegContabCabe
        End Get
        Set(ByVal value As String)
            Me._MonedaVoucherRegContabCabe = value
        End Set
    End Property

    Property DiaVoucherRegContabCabe() As String
        Get
            Return Me._DiaVoucherRegContabCabe
        End Get
        Set(ByVal value As String)
            Me._DiaVoucherRegContabCabe = value
        End Set
    End Property
    Property FechaVoucherRegContabCabe() As DateTime
        Get
            Return Me._FechaVoucherRegContabCabe
        End Get
        Set(ByVal value As DateTime)
            Me._FechaVoucherRegContabCabe = value
        End Set
    End Property

    Property SerieDocumento() As String
        Get
            Return Me._SerieDocumento
        End Get
        Set(ByVal value As String)
            Me._SerieDocumento = value
        End Set
    End Property

    Property NumeroDocumento() As String
        Get
            Return Me._NumeroDocumento
        End Get
        Set(ByVal value As String)
            Me._NumeroDocumento = value
        End Set
    End Property

    Property FechaDocumento() As DateTime
        Get
            Return Me._FechaDocumento
        End Get
        Set(ByVal value As DateTime)
            Me._FechaDocumento = value
        End Set
    End Property

    Property MonedaDocumento() As String
        Get
            Return Me._MonedaDocumento
        End Get
        Set(ByVal value As String)
            Me._MonedaDocumento = value
        End Set
    End Property


    Property SerieDocumento1() As String
        Get
            Return Me._SerieDocumento1
        End Get
        Set(ByVal value As String)
            Me._SerieDocumento1 = value
        End Set
    End Property

    Property NumeroDocumento1() As String
        Get
            Return Me._NumeroDocumento1
        End Get
        Set(ByVal value As String)
            Me._NumeroDocumento1 = value
        End Set
    End Property

    Property FechaDocumento1() As String
        Get
            Return Me._FechaDocumento1
        End Get
        Set(ByVal value As String)
            Me._FechaDocumento1 = value
        End Set
    End Property

    Property MonedaDocumento1() As String
        Get
            Return Me._MonedaDocumento1
        End Get
        Set(ByVal value As String)
            Me._MonedaDocumento1 = value
        End Set
    End Property

    Property ValorVtaRegContabCabe() As Decimal
        Get
            Return Me._ValorVtaRegContabCabe
        End Get
        Set(ByVal value As Decimal)
            Me._ValorVtaRegContabCabe = value
        End Set
    End Property

    Property IgvRegContabCabe() As Decimal
        Get
            Return Me._IgvRegContabCabe
        End Get
        Set(ByVal value As Decimal)
            Me._IgvRegContabCabe = value
        End Set
    End Property

    Property ExoneradoRegContabCabe() As Decimal
        Get
            Return Me._ExoneradoRegContabCabe
        End Get
        Set(ByVal value As Decimal)
            Me._ExoneradoRegContabCabe = value
        End Set
    End Property

    Property PrecioVtaRegContabCabe() As Decimal
        Get
            Return Me._PrecioVtaRegContabCabe
        End Get
        Set(ByVal value As Decimal)
            Me._PrecioVtaRegContabCabe = value
        End Set
    End Property

    Property ValorVtaSolRegContabCabe() As Decimal
        Get
            Return Me._ValorVtaSolRegContabCabe
        End Get
        Set(ByVal value As Decimal)
            Me._ValorVtaSolRegContabCabe = value
        End Set
    End Property

    Property IgvSolRegContabCabe() As Decimal
        Get
            Return Me._IgvSolRegContabCabe
        End Get
        Set(ByVal value As Decimal)
            Me._IgvSolRegContabCabe = value
        End Set
    End Property

    Property ExoneradoSolRegContabCabe() As Decimal
        Get
            Return Me._ExoneradoSolRegContabCabe
        End Get
        Set(ByVal value As Decimal)
            Me._ExoneradoSolRegContabCabe = value
        End Set
    End Property

    Property PrecioVtaSolRegContabCabe() As Decimal
        Get
            Return Me._PrecioVtaSolRegContabCabe
        End Get
        Set(ByVal value As Decimal)
            Me._PrecioVtaSolRegContabCabe = value
        End Set
    End Property

    Property GlosaRegContabCabe() As String
        Get
            Return Me._GlosaRegContabCabe
        End Get
        Set(ByVal value As String)
            Me._GlosaRegContabCabe = value
        End Set
    End Property

    Property RetencionRegContabCabe() As String
        Get
            Return Me._RetencionRegContabCabe
        End Get
        Set(ByVal value As String)
            Me._RetencionRegContabCabe = value
        End Set
    End Property

    Property ImporteRegContabCabe() As Decimal
        Get
            Return Me._ImporteRegContabCabe
        End Get
        Set(ByVal value As Decimal)
            Me._ImporteRegContabCabe = value
        End Set
    End Property
    Property DetraccionRegContabCabe() As String
        Get
            Return Me._DetraccionRegContabCabe
        End Get
        Set(ByVal value As String)
            Me._DetraccionRegContabCabe = value
        End Set
    End Property

    Property NumeroPapeletaRegContabCabe() As String
        Get
            Return Me._NumeroPapeletaRegContabCabe
        End Get
        Set(ByVal value As String)
            Me._NumeroPapeletaRegContabCabe = value
        End Set
    End Property

    Property FechaDetraccionRegContabCabe() As String
        Get
            Return Me._FechaDetraccionRegContabCabe
        End Get
        Set(ByVal value As String)
            Me._FechaDetraccionRegContabCabe = value
        End Set
    End Property

    Property CartaRegContabCabe() As String
        Get
            Return Me._CartaRegContabCabe
        End Get
        Set(ByVal value As String)
            Me._CartaRegContabCabe = value
        End Set
    End Property

    Property DescripcionRegContabCabe() As String
        Get
            Return Me._DescripcionRegContabCabe
        End Get
        Set(ByVal value As String)
            Me._DescripcionRegContabCabe = value
        End Set
    End Property


    Property VoucherIngresoRegContabCabe() As String
        Get
            Return Me._VoucherIngresoRegContabCabe
        End Get
        Set(ByVal value As String)
            Me._VoucherIngresoRegContabCabe = value
        End Set
    End Property

    Property EstadoRegContabCabe() As String
        Get
            Return Me._EstadoRegContabCabe
        End Get
        Set(ByVal value As String)
            Me._EstadoRegContabCabe = value
        End Set
    End Property

#End Region

#Region "Entidad Reg Contab Deta"
    Private _ClaveRegContabDeta As String = ""
    Private _CorrelativoRegContabDeta As String = ""
    Private _DebeHaberRegContabDeta As String = ""
    Private _ImporteSRegContabDeta As Decimal = 0
    Private _ImporteDRegContabDeta As Decimal = 0
    Private _ImporteERegContabDeta As Decimal = 0
    Private _EstadoRegContabDeta As String = ""
    Private _GlosaRegContabDeta As String = ""
    Private _MontoMoneda As Decimal = 0
    Private _MontoSoles As Decimal = 0
    Private _CodigoPptoInterno As String = ""
    Private _DescripcionPptoInterno As String = ""
    Private _Cantidad As Decimal = 0

    Property Cantidad() As Decimal
        Get
            Return Me._Cantidad
        End Get
        Set(ByVal value As Decimal)
            Me._Cantidad = value
        End Set
    End Property

    Property CodigoPptoInterno() As String
        Get
            Return Me._CodigoPptoInterno
        End Get
        Set(ByVal value As String)
            Me._CodigoPptoInterno = value
        End Set
    End Property

    Property DescripcionPptoInterno() As String
        Get
            Return Me._DescripcionPptoInterno
        End Get
        Set(ByVal value As String)
            Me._DescripcionPptoInterno = value
        End Set
    End Property



    Property MontoSoles() As Decimal
        Get
            Return Me._MontoSoles
        End Get
        Set(ByVal value As Decimal)
            Me._MontoSoles = value
        End Set
    End Property

    Property MontoMoneda() As Decimal
        Get
            Return Me._MontoMoneda
        End Get
        Set(ByVal value As Decimal)
            Me._MontoMoneda = value
        End Set
    End Property


    Property ClaveRegContabDeta() As String
        Get
            Return Me._ClaveRegContabDeta
        End Get
        Set(ByVal value As String)
            Me._ClaveRegContabDeta = value
        End Set
    End Property

    Property CorrelativoRegContabDeta() As String
        Get
            Return Me._CorrelativoRegContabDeta
        End Get
        Set(ByVal value As String)
            Me._CorrelativoRegContabDeta = value
        End Set
    End Property

    Property DebeHaberRegContabDeta() As String
        Get
            Return Me._DebeHaberRegContabDeta
        End Get
        Set(ByVal value As String)
            Me._DebeHaberRegContabDeta = value
        End Set
    End Property

    Property ImporteSRegContabDeta() As Decimal
        Get
            Return Me._ImporteSRegContabDeta
        End Get
        Set(ByVal value As Decimal)
            Me._ImporteSRegContabDeta = value
        End Set
    End Property

    Property ImporteDRegContabDeta() As Decimal
        Get
            Return Me._ImporteDRegContabDeta
        End Get
        Set(ByVal value As Decimal)
            Me._ImporteDRegContabDeta = value
        End Set
    End Property

    Property ImporteERegContabDeta() As Decimal
        Get
            Return Me._ImporteERegContabDeta
        End Get
        Set(ByVal value As Decimal)
            Me._ImporteERegContabDeta = value
        End Set
    End Property

    Property GlosaRegContabDeta() As String
        Get
            Return Me._GlosaRegContabDeta
        End Get
        Set(ByVal value As String)
            Me._GlosaRegContabDeta = value
        End Set
    End Property

    Property EstadoRegContabDeta() As String
        Get
            Return Me._EstadoRegContabDeta
        End Get
        Set(ByVal value As String)
            Me._EstadoRegContabDeta = value
        End Set
    End Property

#End Region

#Region "Entidad Cta1242"
    Private _Cuenta1242 As String = ""
    Private _NombreCuenta1242 As String = ""

    Property Cuenta1242() As String
        Get
            Return Me._Cuenta1242
        End Get
        Set(ByVal value As String)
            Me._Cuenta1242 = value
        End Set
    End Property

    Property NombreCuenta1242() As String
        Get
            Return Me._NombreCuenta1242
        End Get
        Set(ByVal value As String)
            Me._NombreCuenta1242 = value
        End Set
    End Property

#End Region

#Region "Entidad PlanDeCuentas"
    Private _CodigoCuentaPcge As String = ""
    Private _NombreCuentaPcge As String = ""
    Private _NumeroDigitosPcge As String = ""
    Private _EstadoPlandeCuentas As String = ""

    Property CodigoCuentaPcge() As String
        Get
            Return Me._CodigoCuentaPcge
        End Get
        Set(ByVal value As String)
            Me._CodigoCuentaPcge = value
        End Set
    End Property

    Property NombreCuentaPcge() As String
        Get
            Return Me._NombreCuentaPcge
        End Get
        Set(ByVal value As String)
            Me._NombreCuentaPcge = value
        End Set
    End Property

    Property NumeroDigitosPcge() As String
        Get
            Return Me._NumeroDigitosPcge
        End Get
        Set(ByVal value As String)
            Me._NumeroDigitosPcge = value
        End Set
    End Property

    Property EstadoPlanDeCuentas() As String
        Get
            Return Me._EstadoPlandeCuentas
        End Get
        Set(ByVal value As String)
            Me._EstadoPlandeCuentas = value
        End Set
    End Property

#End Region

#Region "Entidad PlanCuentaPcge"
    Private _ClaveCuentaPcge As String = ""
    Private _FlagDocumentoPcge As String = ""
    Private _FlagAuxiliarPcge As String = ""
    Private _FlagCentroCostoPcge As String = ""
    Private _FlagAlmacenPcge As String = ""
    Private _FlagAreaPcge As String = ""
    Private _FlagFlujoCajaPcge As String = ""
    Private _FlagAutomaticaPcge As String = ""
    Private _FlagDifCambioPcge As String = ""
    Private _FlagBancoPcge As String = ""
    Private _FlagMonedaPcge As String = ""
    Private _FlagAsientoAperturaPcge As String = ""
    Private _FlagAsientoCierre9Pcge As String = ""
    Private _FlagAsientoCierre7Pcge As String = ""
    Private _FlagTipoCuentaPcge As String = ""
    Private _EstadoCuenta As String = ""
    Private _CuentaAutomatica1Pcge As String = ""
    Private _NombreCuentaAutomatica1Pcge As String = ""
    Private _CuentaAutomatica2Pcge As String = ""
    Private _NombreCuentaAutomatica2Pcge As String = ""

    Property NombreCuentaAutomatica1Pcge() As String

        Get
            Return Me._NombreCuentaAutomatica1Pcge
        End Get
        Set(ByVal value As String)
            Me._NombreCuentaAutomatica1Pcge = value
        End Set
    End Property

    Property NombreCuentaAutomatica2Pcge() As String
        Get
            Return Me._NombreCuentaAutomatica2Pcge
        End Get
        Set(ByVal value As String)
            Me._NombreCuentaAutomatica2Pcge = value
        End Set
    End Property


    Property ClaveCuentaPcge() As String
        Get
            Return Me._ClaveCuentaPcge
        End Get
        Set(ByVal value As String)
            Me._ClaveCuentaPcge = value
        End Set
    End Property

    Property FlagDocumentoPcge() As String
        Get
            Return Me._FlagDocumentoPcge
        End Get
        Set(ByVal value As String)
            Me._FlagDocumentoPcge = value
        End Set
    End Property

    Property FlagAuxiliarPcge() As String
        Get
            Return Me._FlagAuxiliarPcge
        End Get
        Set(ByVal value As String)
            Me._FlagAuxiliarPcge = value
        End Set
    End Property

    Property FlagCentroCostoPcge() As String
        Get
            Return Me._FlagCentroCostoPcge
        End Get
        Set(ByVal value As String)
            Me._FlagCentroCostoPcge = value
        End Set
    End Property

    Property FlagAlmacenPcge() As String
        Get
            Return Me._FlagAlmacenPcge
        End Get
        Set(ByVal value As String)
            Me._FlagAlmacenPcge = value
        End Set
    End Property

    Property FlagAreaPcge() As String
        Get
            Return Me._FlagAreaPcge
        End Get
        Set(ByVal value As String)
            Me._FlagAreaPcge = value
        End Set
    End Property
    Property FlagFlujoCajaPcge() As String
        Get
            Return Me._FlagFlujoCajaPcge
        End Get
        Set(ByVal value As String)
            Me._FlagFlujoCajaPcge = value
        End Set
    End Property

    Property FlagAutomaticaPcge() As String
        Get
            Return Me._FlagAutomaticaPcge
        End Get
        Set(ByVal value As String)
            Me._FlagAutomaticaPcge = value
        End Set
    End Property

    Property FlagDifCambioPcge() As String
        Get
            Return Me._FlagDifCambioPcge
        End Get
        Set(ByVal value As String)
            Me._FlagDifCambioPcge = value
        End Set
    End Property

    Property FlagBancoPcge() As String
        Get
            Return Me._FlagBancoPcge
        End Get
        Set(ByVal value As String)
            Me._FlagBancoPcge = value
        End Set
    End Property


    Property FlagMonedaPcge() As String
        Get
            Return Me._FlagMonedaPcge
        End Get
        Set(ByVal value As String)
            Me._FlagMonedaPcge = value
        End Set
    End Property


    Property FlagAsientoAperturaPcge() As String
        Get
            Return Me._FlagAsientoAperturaPcge
        End Get
        Set(ByVal value As String)
            Me._FlagAsientoAperturaPcge = value
        End Set
    End Property

    Property FlagAsientoCierre9Pcge() As String
        Get
            Return Me._FlagAsientoCierre9Pcge
        End Get
        Set(ByVal value As String)
            Me._FlagAsientoCierre9Pcge = value
        End Set
    End Property

    Property FlagAsientoCierre7Pcge() As String
        Get
            Return Me._FlagAsientoCierre7Pcge
        End Get
        Set(ByVal value As String)
            Me._FlagAsientoCierre7Pcge = value
        End Set
    End Property

    Property FlagTipoCuentaPcge() As String
        Get
            Return Me._FlagTipoCuentaPcge
        End Get
        Set(ByVal value As String)
            Me._FlagTipoCuentaPcge = value
        End Set
    End Property

    Property EstadoCuenta() As String
        Get
            Return Me._EstadoCuenta
        End Get
        Set(ByVal value As String)
            Me._EstadoCuenta = value
        End Set
    End Property

    Property CuentaAutomatica1Pcge() As String
        Get
            Return Me._CuentaAutomatica1Pcge
        End Get
        Set(ByVal value As String)
            Me._CuentaAutomatica1Pcge = value
        End Set
    End Property

    Property CuentaAutomatica2Pcge() As String
        Get
            Return Me._CuentaAutomatica2Pcge
        End Get
        Set(ByVal value As String)
            Me._CuentaAutomatica2Pcge = value
        End Set
    End Property

#End Region

#Region "Entidad Empresa"
    Private _CodigoEmpresa As String = ""
    Private _RazonSocialEmpresa As String = ""
    Private _NombreCortoEmpresa As String = ""
    Private _DireccionEmpresa As String = ""
    Private _RucEmpresa As String = ""
    Private _EstadoEmpresa As String = ""
    Private _PeriodoEmpresa As String = ""

    Property CodigoEmpresa() As String
        Get
            Return Me._CodigoEmpresa
        End Get
        Set(ByVal value As String)
            Me._CodigoEmpresa = value
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

    Property direccionEmpresa() As String
        Get
            Return Me._DireccionEmpresa
        End Get
        Set(ByVal value As String)
            Me._DireccionEmpresa = value
        End Set
    End Property

    Property RucEmpresa() As String
        Get
            Return Me._RucEmpresa
        End Get
        Set(ByVal value As String)
            Me._RucEmpresa = value
        End Set
    End Property

    Property EstadoEmpresa() As String
        Get
            Return Me._EstadoEmpresa
        End Get
        Set(ByVal value As String)
            Me._EstadoEmpresa = value
        End Set
    End Property

    Property PeriodoEmpresa() As String
        Get
            Return Me._PeriodoEmpresa
        End Get
        Set(ByVal value As String)
            Me._PeriodoEmpresa = value
        End Set
    End Property

#End Region

#Region "Entidad CuentaBanco"
    Private _ClaveCuentaBanco As String = ""
    Private _CodigoCuentaBanco As String = ""
    Private _BancoCuentaBanco As String = ""
    Private _AgenciaCuentaBanco As String = ""
    Private _NumeroCuentaBanco As String = ""
    Private _MonedaCuentaBanco As String = ""
    Private _TipoCuentaBanco As String = ""
    Private _SaldoCuentaBanco As Decimal = 0
    Private _EstadoCuentaBanco As String = ""

    Property ClaveCuentaBanco() As String
        Get
            Return Me._ClaveCuentaBanco
        End Get
        Set(ByVal value As String)
            Me._ClaveCuentaBanco = value
        End Set
    End Property

    Property CodigoCuentaBanco() As String
        Get
            Return Me._CodigoCuentaBanco
        End Get
        Set(ByVal value As String)
            Me._CodigoCuentaBanco = value
        End Set
    End Property


    Property BancoCuentaBanco() As String
        Get
            Return Me._BancoCuentaBanco
        End Get
        Set(ByVal value As String)
            Me._BancoCuentaBanco = value
        End Set
    End Property

    Property AgenciaCuentaBanco() As String
        Get
            Return Me._AgenciaCuentaBanco
        End Get
        Set(ByVal value As String)
            Me._AgenciaCuentaBanco = value
        End Set
    End Property

    Property NumeroCuentaBanco() As String
        Get
            Return Me._NumeroCuentaBanco
        End Get
        Set(ByVal value As String)
            Me._NumeroCuentaBanco = value
        End Set
    End Property

    Property MonedaCuentaBanco() As String
        Get
            Return Me._MonedaCuentaBanco
        End Get
        Set(ByVal value As String)
            Me._MonedaCuentaBanco = value
        End Set
    End Property

    Property TipoCuentaBanco() As String
        Get
            Return Me._TipoCuentaBanco
        End Get
        Set(ByVal value As String)
            Me._TipoCuentaBanco = value
        End Set
    End Property

    Property SaldoCuentaBanco() As Decimal
        Get
            Return Me._SaldoCuentaBanco
        End Get
        Set(ByVal value As Decimal)
            Me._SaldoCuentaBanco = value
        End Set
    End Property

    Property EstadoCuentaBanco() As String
        Get
            Return Me._EstadoCuentaBanco
        End Get
        Set(ByVal value As String)
            Me._EstadoCuentaBanco = value
        End Set
    End Property
#End Region

#Region "Entidad Voucher"
    Private _ClaveVoucher As String
    Private _AnoVoucher As String
    Private _AperturaVoucher As String = "00000"
    Private _EneroVoucher As String = "00000"
    Private _FebreroVoucher As String = "00000"
    Private _MarzoVoucher As String = "00000"
    Private _AbrilVoucher As String = "00000"
    Private _MayoVoucher As String = "00000"
    Private _JunioVoucher As String = "00000"
    Private _JulioVoucher As String = "00000"
    Private _AgostoVoucher As String = "00000"
    Private _SetiembreVoucher As String = "00000"
    Private _OctubreVoucher As String = "00000"
    Private _NoviembreVoucher As String = "00000"
    Private _DiciembreVoucher As String = "00000"
    Private _CierreVoucher As String = "00000"
    Private _EstadoVoucher As String = ""

    Property ClaveVoucher() As String
        Get
            Return Me._ClaveVoucher
        End Get
        Set(ByVal value As String)
            Me._ClaveVoucher = value
        End Set
    End Property

    Property AnoVoucher() As String
        Get
            Return Me._AnoVoucher
        End Get
        Set(ByVal value As String)
            Me._AnoVoucher = value
        End Set
    End Property

    Property AperturaVoucher() As String
        Get
            Return Me._AperturaVoucher
        End Get
        Set(ByVal value As String)
            Me._AperturaVoucher = value
        End Set
    End Property

    Property EneroVoucher() As String
        Get
            Return Me._EneroVoucher
        End Get
        Set(ByVal value As String)
            Me._EneroVoucher = value
        End Set
    End Property

    Property FebreroVoucher() As String
        Get
            Return Me._FebreroVoucher
        End Get
        Set(ByVal value As String)
            Me._FebreroVoucher = value
        End Set
    End Property

    Property MarzoVoucher() As String
        Get
            Return Me._MarzoVoucher
        End Get
        Set(ByVal value As String)
            Me._MarzoVoucher = value
        End Set
    End Property

    Property AbrilVoucher() As String
        Get
            Return Me._AbrilVoucher
        End Get
        Set(ByVal value As String)
            Me._AbrilVoucher = value
        End Set
    End Property

    Property MayoVoucher() As String
        Get
            Return Me._MayoVoucher
        End Get
        Set(ByVal value As String)
            Me._MayoVoucher = value
        End Set
    End Property

    Property JunioVoucher() As String
        Get
            Return Me._JunioVoucher
        End Get
        Set(ByVal value As String)
            Me._JunioVoucher = value
        End Set
    End Property

    Property JulioVoucher() As String
        Get
            Return Me._JulioVoucher
        End Get
        Set(ByVal value As String)
            Me._JulioVoucher = value
        End Set
    End Property

    Property AgostoVoucher() As String
        Get
            Return Me._AgostoVoucher
        End Get
        Set(ByVal value As String)
            Me._AgostoVoucher = value
        End Set
    End Property

    Property SetiembreVoucher() As String
        Get
            Return Me._SetiembreVoucher
        End Get
        Set(ByVal value As String)
            Me._SetiembreVoucher = value
        End Set
    End Property

    Property OctubreVoucher() As String
        Get
            Return Me._OctubreVoucher
        End Get
        Set(ByVal value As String)
            Me._OctubreVoucher = value
        End Set
    End Property

    Property NoviembreVoucher() As String
        Get
            Return Me._NoviembreVoucher
        End Get
        Set(ByVal value As String)
            Me._NoviembreVoucher = value
        End Set
    End Property

    Property DiciembreVoucher() As String
        Get
            Return Me._DiciembreVoucher
        End Get
        Set(ByVal value As String)
            Me._DiciembreVoucher = value
        End Set
    End Property

    Property CierreVoucher() As String
        Get
            Return Me._CierreVoucher
        End Get
        Set(ByVal value As String)
            Me._CierreVoucher = value
        End Set
    End Property

    Property EstadoVoucher() As String
        Get
            Return Me._EstadoVoucher
        End Get
        Set(ByVal value As String)
            Me._EstadoVoucher = value
        End Set
    End Property
#End Region

#Region "Entidad FormatoContable"
    Private _ClaveFormatoContable As String = ""
    Private _CodigoFormatoContable As String = ""
    Private _DescripcionFormatoContable As String = ""
    Private _GrupoFormatoContable As String = ""
    Private _NaturalezaFormatoContable As String = ""
    Private _ImporteSolesFormatoContable As Decimal = 0
    Private _ImporteDolaresFormatoContable As Decimal = 0
    Private _ImporteEurosFormatoContable As Decimal = 0
    Private _EstadoFormatoContable As String = ""
    Private _Descripcion1FormatoContable As String = ""

    Property ClaveFormatoContable() As String
        Get
            Return Me._ClaveFormatoContable
        End Get
        Set(ByVal value As String)
            Me._ClaveFormatoContable = value
        End Set
    End Property


    Property CodigoFormatoContable() As String
        Get
            Return Me._CodigoFormatoContable
        End Get
        Set(ByVal value As String)
            Me._CodigoFormatoContable = value
        End Set
    End Property

    Property DescripcionFormatoContable() As String
        Get
            Return Me._DescripcionFormatoContable
        End Get
        Set(ByVal value As String)
            Me._DescripcionFormatoContable = value
        End Set
    End Property

    Property GrupoFormatoContable() As String
        Get
            Return Me._GrupoFormatoContable
        End Get
        Set(ByVal value As String)
            Me._GrupoFormatoContable = value
        End Set
    End Property

    Property NaturalezaFormatoContable() As String
        Get
            Return Me._NaturalezaFormatoContable
        End Get
        Set(ByVal value As String)
            Me._NaturalezaFormatoContable = value
        End Set
    End Property

    Property ImporteSolesFormatoContable() As Decimal
        Get
            Return Me._ImporteSolesFormatoContable
        End Get
        Set(ByVal value As Decimal)
            Me._ImporteSolesFormatoContable = value
        End Set
    End Property

    Property ImporteDolaresFormatoContable() As Decimal
        Get
            Return Me._ImporteDolaresFormatoContable
        End Get
        Set(ByVal value As Decimal)
            Me._ImporteDolaresFormatoContable = value
        End Set
    End Property

    Property ImporteEurosFormatoContable() As Decimal
        Get
            Return Me._ImporteEurosFormatoContable
        End Get
        Set(ByVal value As Decimal)
            Me._ImporteEurosFormatoContable = value
        End Set
    End Property

    Property EstadoFormatoContable() As String
        Get
            Return Me._EstadoFormatoContable
        End Get
        Set(ByVal value As String)
            Me._EstadoFormatoContable = value
        End Set
    End Property

    Property Descripcion1FormatoContable() As String
        Get
            Return Me._Descripcion1FormatoContable
        End Get
        Set(ByVal value As String)
            Me._Descripcion1FormatoContable = value
        End Set
    End Property


#End Region

#Region "Entidad Saldo Contable"
      Private _ClaveSaldoContable As String
      Private _CodigoFormato As String
      Private _MesCreadoSaldoContable As String
      Private _DebeS00SaldoContable As Decimal = 0
      Private _DebeS01SaldoContable As Decimal = 0
      Private _DebeS02SaldoContable As Decimal = 0
      Private _DebeS03SaldoContable As Decimal = 0
      Private _DebeS04SaldoContable As Decimal = 0
      Private _DebeS05SaldoContable As Decimal = 0
      Private _DebeS06SaldoContable As Decimal = 0
      Private _DebeS07SaldoContable As Decimal = 0
      Private _DebeS08SaldoContable As Decimal = 0
      Private _DebeS09SaldoContable As Decimal = 0
      Private _DebeS10SaldoContable As Decimal = 0
      Private _DebeS11SaldoContable As Decimal = 0
      Private _DebeS12SaldoContable As Decimal = 0
      Private _DebeS13SaldoContable As Decimal = 0
      Private _DebeS14SaldoContable As Decimal = 0
      Private _DebeS15SaldoContable As Decimal = 0
      Private _HabeS00SaldoContable As Decimal = 0
      Private _HabeS01SaldoContable As Decimal = 0
      Private _HabeS02SaldoContable As Decimal = 0
      Private _HabeS03SaldoContable As Decimal = 0
      Private _HabeS04SaldoContable As Decimal = 0
      Private _HabeS05SaldoContable As Decimal = 0
      Private _HabeS06SaldoContable As Decimal = 0
      Private _HabeS07SaldoContable As Decimal = 0
      Private _HabeS08SaldoContable As Decimal = 0
      Private _HabeS09SaldoContable As Decimal = 0
      Private _HabeS10SaldoContable As Decimal = 0
      Private _HabeS11SaldoContable As Decimal = 0
      Private _HabeS12SaldoContable As Decimal = 0
      Private _HabeS13SaldoContable As Decimal = 0
      Private _HabeS14SaldoContable As Decimal = 0
      Private _HabeS15SaldoContable As Decimal = 0
      Private _DebeD00SaldoContable As Decimal = 0
      Private _DebeD01SaldoContable As Decimal = 0
      Private _DebeD02SaldoContable As Decimal = 0
      Private _DebeD03SaldoContable As Decimal = 0
      Private _DebeD04SaldoContable As Decimal = 0
      Private _DebeD05SaldoContable As Decimal = 0
      Private _DebeD06SaldoContable As Decimal = 0
      Private _DebeD07SaldoContable As Decimal = 0
      Private _DebeD08SaldoContable As Decimal = 0
      Private _DebeD09SaldoContable As Decimal = 0
      Private _DebeD10SaldoContable As Decimal = 0
      Private _DebeD11SaldoContable As Decimal = 0
      Private _DebeD12SaldoContable As Decimal = 0
      Private _DebeD13SaldoContable As Decimal = 0
      Private _DebeD14SaldoContable As Decimal = 0
      Private _DebeD15SaldoContable As Decimal = 0
      Private _HabeD00SaldoContable As Decimal = 0
      Private _HabeD01SaldoContable As Decimal = 0
      Private _HabeD02SaldoContable As Decimal = 0
      Private _HabeD03SaldoContable As Decimal = 0
      Private _HabeD04SaldoContable As Decimal = 0
      Private _HabeD05SaldoContable As Decimal = 0
      Private _HabeD06SaldoContable As Decimal = 0
      Private _HabeD07SaldoContable As Decimal = 0
      Private _HabeD08SaldoContable As Decimal = 0
      Private _HabeD09SaldoContable As Decimal = 0
      Private _HabeD10SaldoContable As Decimal = 0
      Private _HabeD11SaldoContable As Decimal = 0
      Private _HabeD12SaldoContable As Decimal = 0
      Private _HabeD13SaldoContable As Decimal = 0
      Private _HabeD14SaldoContable As Decimal = 0
      Private _HabeD15SaldoContable As Decimal = 0
      Private _EstadoSaldoContable As String

      Property ClaveSaldoContable() As String
            Get
                  Return Me._ClaveSaldoContable
            End Get
            Set(ByVal value As String)
                  Me._ClaveSaldoContable = value
            End Set
      End Property

      Property CodigoFormato() As String
            Get
                  Return Me._CodigoFormato
            End Get
            Set(ByVal value As String)
                  Me._CodigoFormato = value
            End Set
      End Property

      Property MesCreadoSaldoContable() As String
            Get
                  Return Me._MesCreadoSaldoContable
            End Get
            Set(ByVal value As String)
                  Me._MesCreadoSaldoContable = value
            End Set
      End Property

      Property DebeS00SaldoContable() As Decimal
            Get
                  Return Me._DebeS00SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._DebeS00SaldoContable = value
            End Set
      End Property

      Property DebeS01SaldoContable() As Decimal
            Get
                  Return Me._DebeS01SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._DebeS01SaldoContable = value
            End Set
      End Property

      Property DebeS02SaldoContable() As Decimal
            Get
                  Return Me._DebeS02SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._DebeS02SaldoContable = value
            End Set
      End Property

      Property DebeS03SaldoContable() As Decimal
            Get
                  Return Me._DebeS03SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._DebeS03SaldoContable = value
            End Set
      End Property

      Property DebeS04SaldoContable() As Decimal
            Get
                  Return Me._DebeS04SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._DebeS04SaldoContable = value
            End Set
      End Property

      Property DebeS05SaldoContable() As Decimal
            Get
                  Return Me._DebeS05SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._DebeS05SaldoContable = value
            End Set
      End Property

      Property DebeS06SaldoContable() As Decimal
            Get
                  Return Me._DebeS06SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._DebeS06SaldoContable = value
            End Set
      End Property

      Property DebeS07SaldoContable() As Decimal
            Get
                  Return Me._DebeS07SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._DebeS07SaldoContable = value
            End Set
      End Property

      Property DebeS08SaldoContable() As Decimal
            Get
                  Return Me._DebeS08SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._DebeS08SaldoContable = value
            End Set
      End Property

      Property DebeS09SaldoContable() As Decimal
            Get
                  Return Me._DebeS09SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._DebeS09SaldoContable = value
            End Set
      End Property

      Property DebeS10SaldoContable() As Decimal
            Get
                  Return Me._DebeS10SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._DebeS10SaldoContable = value
            End Set
      End Property

      Property DebeS11SaldoContable() As Decimal
            Get
                  Return Me._DebeS11SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._DebeS11SaldoContable = value
            End Set
      End Property

      Property DebeS12SaldoContable() As Decimal
            Get
                  Return Me._DebeS12SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._DebeS12SaldoContable = value
            End Set
      End Property

      Property DebeS13SaldoContable() As Decimal
            Get
                  Return Me._DebeS13SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._DebeS13SaldoContable = value
            End Set
      End Property

      Property DebeS14SaldoContable() As Decimal
            Get
                  Return Me._DebeS14SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._DebeS14SaldoContable = value
            End Set
      End Property

      Property DebeS15SaldoContable() As Decimal
            Get
                  Return Me._DebeS15SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._DebeS15SaldoContable = value
            End Set
      End Property

      Property HabeS00SaldoContable() As Decimal
            Get
                  Return Me._HabeS00SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._HabeS00SaldoContable = value
            End Set
      End Property

      Property HabeS01SaldoContable() As Decimal
            Get
                  Return Me._HabeS01SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._HabeS01SaldoContable = value
            End Set
      End Property

      Property HabeS02SaldoContable() As Decimal
            Get
                  Return Me._HabeS02SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._HabeS02SaldoContable = value
            End Set
      End Property

      Property HabeS03SaldoContable() As Decimal
            Get
                  Return Me._HabeS03SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._HabeS03SaldoContable = value
            End Set
      End Property

      Property HabeS04SaldoContable() As Decimal
            Get
                  Return Me._HabeS04SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._HabeS04SaldoContable = value
            End Set
      End Property

      Property HabeS05SaldoContable() As Decimal
            Get
                  Return Me._HabeS05SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._HabeS05SaldoContable = value
            End Set
      End Property

      Property HabeS06SaldoContable() As Decimal
            Get
                  Return Me._HabeS06SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._HabeS06SaldoContable = value
            End Set
      End Property

      Property HabeS07SaldoContable() As Decimal
            Get
                  Return Me._HabeS07SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._HabeS07SaldoContable = value
            End Set
      End Property

      Property HabeS08SaldoContable() As Decimal
            Get
                  Return Me._HabeS08SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._HabeS08SaldoContable = value
            End Set
      End Property

      Property HabeS09SaldoContable() As Decimal
            Get
                  Return Me._HabeS09SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._HabeS09SaldoContable = value
            End Set
      End Property

      Property HabeS10SaldoContable() As Decimal
            Get
                  Return Me._HabeS10SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._HabeS10SaldoContable = value
            End Set
      End Property

      Property HabeS11SaldoContable() As Decimal
            Get
                  Return Me._HabeS11SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._HabeS11SaldoContable = value
            End Set
      End Property

      Property HabeS12SaldoContable() As Decimal
            Get
                  Return Me._HabeS12SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._HabeS12SaldoContable = value
            End Set
      End Property

      Property HabeS13SaldoContable() As Decimal
            Get
                  Return Me._HabeS13SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._HabeS13SaldoContable = value
            End Set
      End Property

      Property HabeS14SaldoContable() As Decimal
            Get
                  Return Me._HabeS14SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._HabeS14SaldoContable = value
            End Set
      End Property

      Property HabeS15SaldoContable() As Decimal
            Get
                  Return Me._HabeS15SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._HabeS15SaldoContable = value
            End Set
      End Property

      Property DebeD00SaldoContable() As Decimal
            Get
                  Return Me._DebeD00SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._DebeD00SaldoContable = value
            End Set
      End Property

      Property DebeD01SaldoContable() As Decimal
            Get
                  Return Me._DebeD01SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._DebeD01SaldoContable = value
            End Set
      End Property

      Property DebeD02SaldoContable() As Decimal
            Get
                  Return Me._DebeD02SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._DebeD02SaldoContable = value
            End Set
      End Property

      Property DebeD03SaldoContable() As Decimal
            Get
                  Return Me._DebeD03SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._DebeD03SaldoContable = value
            End Set
      End Property

      Property DebeD04SaldoContable() As Decimal
            Get
                  Return Me._DebeD04SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._DebeD04SaldoContable = value
            End Set
      End Property

      Property DebeD05SaldoContable() As Decimal
            Get
                  Return Me._DebeD05SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._DebeD05SaldoContable = value
            End Set
      End Property

      Property DebeD06SaldoContable() As Decimal
            Get
                  Return Me._DebeD06SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._DebeD06SaldoContable = value
            End Set
      End Property

      Property DebeD07SaldoContable() As Decimal
            Get
                  Return Me._DebeD07SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._DebeD07SaldoContable = value
            End Set
      End Property

      Property DebeD08SaldoContable() As Decimal
            Get
                  Return Me._DebeD08SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._DebeD08SaldoContable = value
            End Set
      End Property

      Property DebeD09SaldoContable() As Decimal
            Get
                  Return Me._DebeD09SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._DebeD09SaldoContable = value
            End Set
      End Property

      Property DebeD10SaldoContable() As Decimal
            Get
                  Return Me._DebeD10SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._DebeD10SaldoContable = value
            End Set
      End Property

      Property DebeD11SaldoContable() As Decimal
            Get
                  Return Me._DebeD11SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._DebeD11SaldoContable = value
            End Set
      End Property

      Property DebeD12SaldoContable() As Decimal
            Get
                  Return Me._DebeD12SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._DebeD12SaldoContable = value
            End Set
      End Property

      Property DebeD13SaldoContable() As Decimal
            Get
                  Return Me._DebeD13SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._DebeD13SaldoContable = value
            End Set
      End Property

      Property DebeD14SaldoContable() As Decimal
            Get
                  Return Me._DebeD14SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._DebeD14SaldoContable = value
            End Set
      End Property

      Property DebeD15SaldoContable() As Decimal
            Get
                  Return Me._DebeD15SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._DebeD15SaldoContable = value
            End Set
      End Property

      Property HabeD00SaldoContable() As Decimal
            Get
                  Return Me._HabeD00SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._HabeD00SaldoContable = value
            End Set
      End Property

      Property HabeD01SaldoContable() As Decimal
            Get
                  Return Me._HabeD01SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._HabeD01SaldoContable = value
            End Set
      End Property

      Property HabeD02SaldoContable() As Decimal
            Get
                  Return Me._HabeD02SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._HabeD02SaldoContable = value
            End Set
      End Property

      Property HabeD03SaldoContable() As Decimal
            Get
                  Return Me._HabeD03SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._HabeD03SaldoContable = value
            End Set
      End Property

      Property HabeD04SaldoContable() As Decimal
            Get
                  Return Me._HabeD04SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._HabeD04SaldoContable = value
            End Set
      End Property

      Property HabeD05SaldoContable() As Decimal
            Get
                  Return Me._HabeD05SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._HabeD05SaldoContable = value
            End Set
      End Property

      Property HabeD06SaldoContable() As Decimal
            Get
                  Return Me._HabeD06SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._HabeD06SaldoContable = value
            End Set
      End Property

      Property HabeD07SaldoContable() As Decimal
            Get
                  Return Me._HabeD07SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._HabeD07SaldoContable = value
            End Set
      End Property

      Property HabeD08SaldoContable() As Decimal
            Get
                  Return Me._HabeD08SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._HabeD08SaldoContable = value
            End Set
      End Property

      Property HabeD09SaldoContable() As Decimal
            Get
                  Return Me._HabeD09SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._HabeD09SaldoContable = value
            End Set
      End Property

      Property HabeD10SaldoContable() As Decimal
            Get
                  Return Me._HabeD10SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._HabeD10SaldoContable = value
            End Set
      End Property

      Property HabeD11SaldoContable() As Decimal
            Get
                  Return Me._HabeD11SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._HabeD11SaldoContable = value
            End Set
      End Property

      Property HabeD12SaldoContable() As Decimal
            Get
                  Return Me._HabeD12SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._HabeD12SaldoContable = value
            End Set
      End Property

      Property HabeD13SaldoContable() As Decimal
            Get
                  Return Me._HabeD13SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._HabeD13SaldoContable = value
            End Set
      End Property

      Property HabeD14SaldoContable() As Decimal
            Get
                  Return Me._HabeD14SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._HabeD14SaldoContable = value
            End Set
      End Property

      Property HabeD15SaldoContable() As Decimal
            Get
                  Return Me._HabeD15SaldoContable
            End Get
            Set(ByVal value As Decimal)
                  Me._HabeD15SaldoContable = value
            End Set
      End Property

      Property EstadoSaldoContable() As String
            Get
                  Return Me._EstadoSaldoContable
            End Get
            Set(ByVal value As String)
                  Me._EstadoSaldoContable = value
            End Set
      End Property

#End Region

#Region "Entidad SaldosBancarios"
    Private _ClaveSaldosBancarios As String
    Private _IngresosSolCuentaBanco As Decimal
    Private _SalidasSolCuentaBanco As Decimal
    Private _SaldoMesSolCuentaBanco As Decimal
    Private _IngresosDolCuentaBanco As Decimal
    Private _SalidasDolCuentaBanco As Decimal
    Private _SaldoMesDolCuentaBanco As Decimal
    Private _IngresosEurCuentaBanco As Decimal
    Private _SalidasEurCuentaBanco As Decimal
    Private _SaldoMesEurCuentaBanco As Decimal
    Private _IngresosSolAntCuentaBanco As Decimal
    Private _SalidasSolAntCuentaBanco As Decimal
    Private _SaldoMesSolAntCuentaBanco As Decimal
    Private _IngresosDolAntCuentaBanco As Decimal
    Private _SalidasDolAntCuentaBanco As Decimal
    Private _SaldoMesDolAntCuentaBanco As Decimal
    Private _IngresosEurAntCuentaBanco As Decimal
    Private _SalidasEurAntCuentaBanco As Decimal
    Private _SaldoMesEurAntCuentaBanco As Decimal
    Private _MesCuentaBanco As String
    Private _AnoCuentaBanco As String

    Property ClaveSaldosBancarios() As String
        Get
            Return Me._ClaveSaldosBancarios
        End Get
        Set(ByVal value As String)
            Me._ClaveSaldosBancarios = value
        End Set
    End Property

    Property IngresosSolCuentaBanco() As Decimal
        Get
            Return Me._IngresosSolCuentaBanco
        End Get
        Set(ByVal value As Decimal)
            Me._IngresosSolCuentaBanco = value
        End Set
    End Property

    Property SalidasSolCuentaBanco() As Decimal
        Get
            Return Me._SalidasSolCuentaBanco
        End Get
        Set(ByVal value As Decimal)
            Me._SalidasSolCuentaBanco = value
        End Set
    End Property

    Property SaldoMesSolCuentaBanco() As Decimal
        Get
            Return Me._SaldoMesSolCuentaBanco
        End Get
        Set(ByVal value As Decimal)
            Me._SaldoMesSolCuentaBanco = value
        End Set
    End Property

    Property IngresosDolCuentaBanco() As Decimal
        Get
            Return Me._IngresosDolCuentaBanco
        End Get
        Set(ByVal value As Decimal)
            Me._IngresosDolCuentaBanco = value
        End Set
    End Property

    Property SalidasDolCuentaBanco() As Decimal
        Get
            Return Me._SalidasDolCuentaBanco
        End Get
        Set(ByVal value As Decimal)
            Me._SalidasDolCuentaBanco = value
        End Set
    End Property

    Property SaldoMesDolCuentaBanco() As Decimal
        Get
            Return Me._SaldoMesDolCuentaBanco
        End Get
        Set(ByVal value As Decimal)
            Me._SaldoMesDolCuentaBanco = value
        End Set
    End Property


    Property IngresosEurCuentaBanco() As Decimal
        Get
            Return Me._IngresosEurCuentaBanco
        End Get
        Set(ByVal value As Decimal)
            Me._IngresosEurCuentaBanco = value
        End Set
    End Property

    Property SalidasEurCuentaBanco() As Decimal
        Get
            Return Me._SalidasEurAntCuentaBanco
        End Get
        Set(ByVal value As Decimal)
            Me._SalidasEurCuentaBanco = value
        End Set
    End Property

    Property SaldoMesEurCuentaBanco() As Decimal
        Get
            Return Me._SaldoMesEurCuentaBanco
        End Get
        Set(ByVal value As Decimal)
            Me._SaldoMesEurCuentaBanco = value
        End Set
    End Property

    Property IngresosSolAntCuentaBanco() As Decimal
        Get
            Return Me._IngresosSolAntCuentaBanco
        End Get
        Set(ByVal value As Decimal)
            Me._IngresosSolAntCuentaBanco = value
        End Set
    End Property

    Property SalidasSolAntCuentaBanco() As Decimal
        Get
            Return Me._SalidasSolAntCuentaBanco
        End Get
        Set(ByVal value As Decimal)
            Me._SalidasSolAntCuentaBanco = value
        End Set
    End Property

    Property SaldoMesSolAntCuentaBanco() As Decimal
        Get
            Return Me._SaldoMesSolAntCuentaBanco
        End Get
        Set(ByVal value As Decimal)
            Me._SaldoMesSolAntCuentaBanco = value
        End Set
    End Property

    Property IngresosDolAntCuentaBanco() As Decimal
        Get
            Return Me._IngresosDolAntCuentaBanco
        End Get
        Set(ByVal value As Decimal)
            Me._IngresosDolAntCuentaBanco = value
        End Set
    End Property

    Property SalidasDolAntCuentaBanco() As Decimal
        Get
            Return Me._SalidasDolAntCuentaBanco
        End Get
        Set(ByVal value As Decimal)
            Me._SalidasDolAntCuentaBanco = value
        End Set
    End Property

    Property SaldoMesDolAntCuentaBanco() As Decimal
        Get
            Return Me._SaldoMesDolAntCuentaBanco
        End Get
        Set(ByVal value As Decimal)
            Me._SaldoMesDolAntCuentaBanco = value
        End Set
    End Property



    Property IngresosEurAntCuentaBanco() As Decimal
        Get
            Return Me._IngresosEurAntCuentaBanco
        End Get
        Set(ByVal value As Decimal)
            Me._IngresosEurAntCuentaBanco = value
        End Set
    End Property

    Property SalidasEurAntCuentaBanco() As Decimal
        Get
            Return Me._SalidasEurAntCuentaBanco
        End Get
        Set(ByVal value As Decimal)
            Me._SalidasEurAntCuentaBanco = value
        End Set
    End Property

    Property SaldoMesEurAntCuentaBanco() As Decimal
        Get
            Return Me._SaldoMesEurAntCuentaBanco
        End Get
        Set(ByVal value As Decimal)
            Me._SaldoMesEurAntCuentaBanco = value
        End Set
    End Property

    Property MesCuentaBanco() As String
        Get
            Return Me._MesCuentaBanco
        End Get
        Set(ByVal value As String)
            Me._MesCuentaBanco = value
        End Set
    End Property

    Property AnoCuentaBanco() As String
        Get
            Return Me._AnoCuentaBanco
        End Get
        Set(ByVal value As String)
            Me._AnoCuentaBanco = value
        End Set
    End Property

#End Region

#Region "Entidad Cuenta Corriente"
    Private _ClaveCuentaCorriente As String
    Private _ClaveDocumentoCuentaCorriente As String
    Private _FechaVctoDocumento As String
    Private _ImporteOriginalCuentaCorriente As Decimal
    Private _ImportePagadoCuentaCorriente As Decimal
    Private _SaldoCuentaCorriente As Decimal
    Private _EstadoCuentaCorriente As String
    Private _VentaTipoCambioOriginal As Decimal
    Private _VentaEurTipoCambioOriginal As Decimal
    Private _ClaveNotaCredito As String = String.Empty
    Private _ValorNotaCredito As Decimal = 0
    Private _FlagSaldoNegativo As String = "0"

    Property FlagSaldoNegativo() As String
        Get
            Return Me._FlagSaldoNegativo
        End Get
        Set(ByVal value As String)
            Me._FlagSaldoNegativo = value
        End Set
    End Property

    Property ValorNotaCredito() As Decimal
        Get
            Return Me._ValorNotaCredito
        End Get
        Set(ByVal value As Decimal)
            Me._ValorNotaCredito = value
        End Set
    End Property

    Property ClaveNotaCredito() As String
        Get
            Return Me._ClaveNotaCredito
        End Get
        Set(ByVal value As String)
            Me._ClaveNotaCredito = value
        End Set
    End Property


    Property VentaTipoCambioOriginal() As Decimal
        Get
            Return Me._VentaTipoCambioOriginal
        End Get
        Set(ByVal value As Decimal)
            Me._VentaTipoCambioOriginal = value
        End Set
    End Property


    Property VentaEurTipoCambioOriginal() As Decimal
        Get
            Return Me._VentaEurTipoCambioOriginal
        End Get
        Set(ByVal value As Decimal)
            Me._VentaEurTipoCambioOriginal = value
        End Set
    End Property

    Property ClaveCuentaCorriente() As String
        Get
            Return Me._ClaveCuentaCorriente
        End Get
        Set(ByVal value As String)
            Me._ClaveCuentaCorriente = value
        End Set
    End Property

    Property ClaveDocumentoCuentaCorriente() As String
        Get
            Return Me._ClaveDocumentoCuentaCorriente
        End Get
        Set(ByVal value As String)
            Me._ClaveDocumentoCuentaCorriente = value
        End Set
    End Property

    Property FechaVctoDocumento() As String
        Get
            Return Me._FechaVctoDocumento
        End Get
        Set(ByVal value As String)
            Me._FechaVctoDocumento = value
        End Set
    End Property

    Property ImporteOriginalCuentaCorriente() As Decimal
        Get
            Return Me._ImporteOriginalCuentaCorriente
        End Get
        Set(ByVal value As Decimal)
            Me._ImporteOriginalCuentaCorriente = value
        End Set
    End Property


    Property ImportePagadoCuentaCorriente() As Decimal
        Get
            Return Me._ImportePagadoCuentaCorriente
        End Get
        Set(ByVal value As Decimal)
            Me._ImportePagadoCuentaCorriente = value
        End Set
    End Property

    Property SaldoCuentaCorriente() As Decimal
        Get
            Return Me._SaldoCuentaCorriente
        End Get
        Set(ByVal value As Decimal)
            Me._SaldoCuentaCorriente = value
        End Set
    End Property

    Property EstadoCuentaCorriente() As String
        Get
            Return Me._EstadoCuentaCorriente
        End Get
        Set(ByVal value As String)
            Me._EstadoCuentaCorriente = value
        End Set
    End Property

#End Region

#Region "Entidad Almacen"
    Private _CodigoAlmacen As String
    Private _NombreAlmacen As String
    Private _ColorAlmacen As String
    Private _MedidasAlmacen As String
    Private _SerieAlmacen As String
    Private _MarcaAlmacen As String
    Private _EstadoAlmacen As String

    Property CodigoAlmacen() As String
        Get
            Return Me._CodigoAlmacen
        End Get
        Set(ByVal value As String)
            Me._CodigoAlmacen = value
        End Set
    End Property

    Property NombreAlmacen() As String
        Get
            Return Me._NombreAlmacen
        End Get
        Set(ByVal value As String)
            Me._NombreAlmacen = value
        End Set
    End Property

    Property ColorAlmacen() As String
        Get
            Return Me._ColorAlmacen
        End Get
        Set(ByVal value As String)
            Me._ColorAlmacen = value
        End Set
    End Property

    Property MedidasAlmacen() As String
        Get
            Return Me._MedidasAlmacen
        End Get
        Set(ByVal value As String)
            Me._MedidasAlmacen = value
        End Set
    End Property


    Property SerieAlmacen() As String
        Get
            Return Me._SerieAlmacen
        End Get
        Set(ByVal value As String)
            Me._SerieAlmacen = value
        End Set
    End Property

    Property MarcaAlmacen() As String
        Get
            Return Me._MarcaAlmacen
        End Get
        Set(ByVal value As String)
            Me._MarcaAlmacen = value
        End Set
    End Property

    Property EstadoAlmacen() As String
        Get
            Return Me._EstadoAlmacen
        End Get
        Set(ByVal value As String)
            Me._EstadoAlmacen = value
        End Set
    End Property

#End Region

#Region "Entidad Permiso"
    Private _CodigoVentana As String = ""
    Private _NombreVentana As String = ""
    Private _CodigoOpcion As String = ""
    Private _NombreOpcion As String = ""
    Private _OpcionPermiso As Integer = 0

    Property OpcionPermiso() As Integer
        Get
            Return Me._OpcionPermiso
        End Get
        Set(ByVal value As Integer)
            Me._OpcionPermiso = value
        End Set
    End Property


    Property CodigoOpcion() As String
        Get
            Return Me._CodigoOpcion
        End Get
        Set(ByVal value As String)
            Me._CodigoOpcion = value
        End Set
    End Property

    Property NombreOpcion() As String
        Get
            Return Me._NombreOpcion
        End Get
        Set(ByVal value As String)
            Me._NombreOpcion = value
        End Set
    End Property

    Property NombreVentana() As String
        Get
            Return Me._NombreVentana
        End Get
        Set(ByVal value As String)
            Me._NombreVentana = value
        End Set
    End Property

    Property CodigoVentana() As String
        Get
            Return Me._CodigoVentana
        End Get
        Set(ByVal value As String)
            Me._CodigoVentana = value
        End Set
    End Property

#End Region

#Region "Entidad Periodo"
    Private _ClavePeriodo As String = ""
    Private _CodigoPeriodo As String = ""
    Private _CMesPeriodo As String = ""
    Private _NMesPeriodo As String = ""
    Private _CEstadoPeriodo As String = ""
    Private _NEstadoPeriodo As String = ""
    Private _ResultadoMes As Decimal = 0
    Private _ResultadoAcumulado As Decimal = 0

    Property ClavePeriodo() As String
        Get
            Return Me._ClavePeriodo
        End Get
        Set(ByVal value As String)
            Me._ClavePeriodo = value
        End Set
    End Property

    Property CodigoPeriodo() As String
        Get
            Return Me._CodigoPeriodo
        End Get
        Set(ByVal value As String)
            Me._CodigoPeriodo = value
        End Set
    End Property


    Property CMesPeriodo() As String
        Get
            Return Me._CMesPeriodo
        End Get
        Set(ByVal value As String)
            Me._CMesPeriodo = value
        End Set
    End Property

    Property NMesPeriodo() As String
        Get
            Return Me._NMesPeriodo
        End Get
        Set(ByVal value As String)
            Me._NMesPeriodo = value
        End Set
    End Property

    Property CEstadoPeriodo() As String
        Get
            Return Me._CEstadoPeriodo
        End Get
        Set(ByVal value As String)
            Me._CEstadoPeriodo = value
        End Set
    End Property

    Property NEstadoPeriodo() As String
        Get
            Return Me._NEstadoPeriodo
        End Get
        Set(ByVal value As String)
            Me._NEstadoPeriodo = value
        End Set
    End Property

    Property ResultadoMes() As Decimal
        Get
            Return Me._ResultadoMes
        End Get
        Set(ByVal value As Decimal)
            Me._ResultadoMes = value
        End Set
    End Property

    Property ResultadoAcumulado() As Decimal
        Get
            Return Me._ResultadoAcumulado
        End Get
        Set(ByVal value As Decimal)
            Me._ResultadoAcumulado = value
        End Set
    End Property


#End Region


#Region "Entidad Area"
    Private _ClaveArea As String = ""
    Private _CodigoArea As String = ""
    Private _NombreArea As String = ""
    Private _EstadoArea As String = ""

    Property ClaveArea() As String
        Get
            Return Me._ClaveArea
        End Get
        Set(ByVal value As String)
            Me._ClaveArea = value
        End Set
    End Property

    Property CodigoArea() As String
        Get
            Return Me._CodigoArea
        End Get
        Set(ByVal value As String)
            Me._CodigoArea = value
        End Set
    End Property

    Property NombreArea() As String
        Get
            Return Me._NombreArea
        End Get
        Set(ByVal value As String)
            Me._NombreArea = value
        End Set
    End Property


    Property EstadoArea() As String
        Get
            Return Me._EstadoArea
        End Get
        Set(ByVal value As String)
            Me._EstadoArea = value
        End Set
    End Property

#End Region

#Region "Entidad FlujoCaja"
    Private _ClaveFlujoCaja As String = ""
    Private _CodigoFlujoCaja As String = ""
    Private _NombreFlujoCaja As String = ""
    Private _EstadoFlujoCaja As String = ""

    Property ClaveFlujoCaja() As String
        Get
            Return Me._ClaveFlujoCaja
        End Get
        Set(ByVal value As String)
            Me._ClaveFlujoCaja = value
        End Set
    End Property

    Property CodigoFlujoCaja() As String
        Get
            Return Me._CodigoFlujoCaja
        End Get
        Set(ByVal value As String)
            Me._CodigoFlujoCaja = value
        End Set
    End Property

    Property NombreFlujoCaja() As String
        Get
            Return Me._NombreFlujoCaja
        End Get
        Set(ByVal value As String)
            Me._NombreFlujoCaja = value
        End Set
    End Property


    Property EstadoFlujoCaja() As String
        Get
            Return Me._EstadoFlujoCaja
        End Get
        Set(ByVal value As String)
            Me._EstadoFlujoCaja = value
        End Set
    End Property

#End Region

#Region "Entidad CentroCosto"
    Private _ClaveCentroCosto As String = ""

    Private _EstadoCentroCosto As String = ""

    Property ClaveCentroCosto() As String
        Get
            Return Me._ClaveCentroCosto
        End Get
        Set(ByVal value As String)
            Me._ClaveCentroCosto = value
        End Set
    End Property

    Property EstadoCentroCosto() As String
        Get
            Return Me._EstadoCentroCosto
        End Get
        Set(ByVal value As String)
            Me._EstadoCentroCosto = value
        End Set
    End Property

#End Region

#Region "Entidad IngresoEgreso"
    Private _ClaveIngresoEgreso As String = ""
    Private _CodigoIngresoEgreso As String = ""
    Private _NombreIngresoEgreso As String = ""
    Private _EstadoIngresoEgreso As String = ""

    Property ClaveIngresoEgreso() As String
        Get
            Return Me._ClaveIngresoEgreso
        End Get
        Set(ByVal value As String)
            Me._ClaveIngresoEgreso = value
        End Set
    End Property

    Property CodigoIngresoEgreso() As String
        Get
            Return Me._CodigoIngresoEgreso
        End Get
        Set(ByVal value As String)
            Me._CodigoIngresoEgreso = value
        End Set
    End Property

    Property NombreIngresoEgreso() As String
        Get
            Return Me._NombreIngresoEgreso
        End Get
        Set(ByVal value As String)
            Me._NombreIngresoEgreso = value
        End Set
    End Property

    Property EstadoIngresoEgreso() As String
        Get
            Return Me._EstadoIngresoEgreso
        End Get
        Set(ByVal value As String)
            Me._EstadoIngresoEgreso = value
        End Set
    End Property



#End Region

#Region "Entidad SumaIngEgr"
    Private _ClaveSumaIngEgr As String = ""
    Private _CodigoSumaIngEgr As String = ""
    Private _NombreSumaIngEgr As String = ""
    Private _EstadoSumaIngEgr As String = ""

    Property ClaveSumaIngEgr() As String
        Get
            Return Me._ClaveSumaIngEgr
        End Get
        Set(ByVal value As String)
            Me._ClaveSumaIngEgr = value
        End Set
    End Property

    Property CodigoSumaIngEgr() As String
        Get
            Return Me._CodigoSumaIngEgr
        End Get
        Set(ByVal value As String)
            Me._CodigoSumaIngEgr = value
        End Set
    End Property

    Property NombreSumaIngEgr() As String
        Get
            Return Me._NombreSumaIngEgr
        End Get
        Set(ByVal value As String)
            Me._NombreSumaIngEgr = value
        End Set
    End Property


    Property EstadoSumaIngEgr() As String
        Get
            Return Me._EstadoSumaIngEgr
        End Get
        Set(ByVal value As String)
            Me._EstadoSumaIngEgr = value
        End Set
    End Property

#End Region

#Region "Entidad Cuenta Corriente Historico"
    Private _ClaveCuentaCorrienteHistorico As String = ""
    Private _EstadoCuentaCorrienteHistorico As String = ""
    
    Property ClaveCuentaCorrienteHistorico() As String
        Get
            Return Me._ClaveCuentaCorrienteHistorico
        End Get
        Set(ByVal value As String)
            Me._ClaveCuentaCorrienteHistorico = value
        End Set
    End Property

    Property EstadoCuentaCorrienteHistorico() As String
        Get
            Return Me._EstadoCuentaCorrienteHistorico
        End Get
        Set(ByVal value As String)
            Me._EstadoCuentaCorrienteHistorico = value
        End Set
    End Property

#End Region

#Region "Entidad Concepto"
    Private _Titulo As String = ""
    Private _NombreTitulo As String = ""
    Private _SubTitulo As String = ""
    Private _CodigoConcepto As String = ""
    Private _NombreConcepto As String = ""


    Property NombreTitulo() As String
        Get
            Return Me._NombreTitulo
        End Get
        Set(ByVal value As String)
            Me._NombreTitulo = value
        End Set
    End Property


    Property Titulo() As String
        Get
            Return Me._Titulo
        End Get
        Set(ByVal value As String)
            Me._Titulo = value
        End Set
    End Property

    Property SubTitulo() As String
        Get
            Return Me._SubTitulo
        End Get
        Set(ByVal value As String)
            Me._SubTitulo = value
        End Set
    End Property

    Property CodigoConcepto() As String
        Get
            Return Me._CodigoConcepto
        End Get
        Set(ByVal value As String)
            Me._CodigoConcepto = value
        End Set
    End Property

    Property NombreConcepto() As String
        Get
            Return Me._NombreConcepto
        End Get
        Set(ByVal value As String)
            Me._NombreConcepto = value
        End Set
    End Property

#End Region

#Region "Entidad Interno"
    Private _CodigoInterno As String = ""
    Private _NombreInterno As String = ""

    Property CodigoInterno() As String
        Get
            Return Me._CodigoInterno
        End Get
        Set(ByVal value As String)
            Me._CodigoInterno = value
        End Set
    End Property

    Property NombreInterno() As String
        Get
            Return Me._NombreInterno
        End Get
        Set(ByVal value As String)
            Me._NombreInterno = value
        End Set
    End Property

#End Region

#Region "Entidad pROYECTO"
    Private _CodigoProHijo As String = ""
    Private _DescripcionProHijo As String = ""
    Private _TipoProHijo As String = ""
    Private _CodigoProPadre As String = ""
    Private _DescripcionProPadre As String = ""
    Private _OfertaGenera As String = ""
    Private _ProyectoGenera As String = ""
    Private _CalculoHoras As String = ""

    Property CalculoHoras() As String
        Get
            Return Me._CalculoHoras
        End Get
        Set(ByVal value As String)
            Me._CalculoHoras = value
        End Set
    End Property

    Property ProyectoGenera() As String
        Get
            Return Me._ProyectoGenera
        End Get
        Set(ByVal value As String)
            Me._ProyectoGenera = value
        End Set
    End Property

    Property OfertaGenera() As String
        Get
            Return Me._OfertaGenera
        End Get
        Set(ByVal value As String)
            Me._OfertaGenera = value
        End Set
    End Property

    Property TipoProHijo() As String
        Get
            Return Me._TipoProHijo
        End Get
        Set(ByVal value As String)
            Me._TipoProHijo = value
        End Set
    End Property

    Property CodigoProPadre() As String
        Get
            Return Me._CodigoProPadre
        End Get
        Set(ByVal value As String)
            Me._CodigoProPadre = value
        End Set
    End Property

    Property DescripcionProPadre() As String
        Get
            Return Me._DescripcionProPadre
        End Get
        Set(ByVal value As String)
            Me._DescripcionProPadre = value
        End Set
    End Property

    Property CodigoProHijo() As String
        Get
            Return Me._CodigoProHijo
        End Get
        Set(ByVal value As String)
            Me._CodigoProHijo = value
        End Set
    End Property

    Property DescripcionProHijo() As String
        Get
            Return Me._DescripcionProHijo
        End Get
        Set(ByVal value As String)
            Me._DescripcionProHijo = value
        End Set
    End Property

#End Region

#Region "Entidad Segmento"
    Private _CodigoSegmento As String = ""
    Private _NombreSegmento As String = ""

    Property CodigoSegmento() As String
        Get
            Return Me._CodigoSegmento
        End Get
        Set(ByVal value As String)
            Me._CodigoSegmento = value
        End Set
    End Property

    Property NombreSegmento() As String
        Get
            Return Me._NombreSegmento
        End Get
        Set(ByVal value As String)
            Me._NombreSegmento = value
        End Set
    End Property

#End Region

#Region "Entidad Afp"
    Private _CodigoAfp As String = ""
    Private _NombreAfp As String
    Private _PorCentajeFondoAfp As Decimal
    Private _PorCentajeSeguroAfp As Decimal
    Private _PorCentajeSobreRemuneracion As Decimal
    Private _PorCentajeEspecialAfp As Decimal
    Private _EstadoAfp As String

    Property CodigoAfp() As String
        Get
            Return Me._CodigoAfp
        End Get
        Set(ByVal value As String)
            Me._CodigoAfp = value
        End Set
    End Property

    Property NombreAfp() As String
        Get
            Return Me._NombreAfp
        End Get
        Set(ByVal value As String)
            Me._NombreAfp = value
        End Set
    End Property

    Property PorCentajeFondoAfp() As Decimal
        Get
            Return Me._PorCentajeFondoAfp
        End Get
        Set(ByVal value As Decimal)
            Me._PorCentajeFondoAfp = value
        End Set
    End Property

    Property PorCentajeSeguroAfp() As Decimal
        Get
            Return Me._PorCentajeSeguroAfp
        End Get
        Set(ByVal value As Decimal)
            Me._PorCentajeSeguroAfp = value
        End Set
    End Property

    Property PorCentajeSobreRemuneracionAfp() As Decimal
        Get
            Return Me._PorCentajeSobreRemuneracion
        End Get
        Set(ByVal value As Decimal)
            Me._PorCentajeSobreRemuneracion = value
        End Set
    End Property

    Property PorCentajeEspecialAfp() As Decimal
        Get
            Return Me._PorCentajeEspecialAfp
        End Get
        Set(ByVal value As Decimal)
            Me._PorCentajeEspecialAfp = value
        End Set
    End Property

    Property EstadoAfp() As String
        Get
            Return Me._EstadoAfp
        End Get
        Set(ByVal value As String)
            Me._EstadoAfp = value
        End Set
    End Property

#End Region

#Region "Entidad Gasto Reparable"
    Private _ClaveGastoReparable As String = ""
    Private _CodigoGastoReparable As String = ""
    Private _NombreGastoReparable As String = ""
    Private _Almacen As String = ""
    Private _Unidad As String = ""
    Private _EstadoGastoReparable As String = ""


    Property ClaveGastoReparable() As String
        Get
            Return Me._ClaveGastoReparable
        End Get
        Set(ByVal value As String)
            Me._ClaveGastoReparable = value
        End Set
    End Property

    Property CodigoGastoReparable() As String
        Get
            Return Me._CodigoGastoReparable
        End Get
        Set(ByVal value As String)
            Me._CodigoGastoReparable = value
        End Set
    End Property

    Property NombreGastoReparable() As String
        Get
            Return Me._NombreGastoReparable
        End Get
        Set(ByVal value As String)
            Me._NombreGastoReparable = value
        End Set
    End Property

    Property Almacen() As String
        Get
            Return Me._Almacen
        End Get
        Set(ByVal value As String)
            Me._Almacen = value
        End Set
    End Property

    Property Unidad() As String
        Get
            Return Me._Unidad
        End Get
        Set(ByVal value As String)
            Me._Unidad = value
        End Set
    End Property

    Property EstadoGastoReparable() As String
        Get
            Return Me._EstadoGastoReparable
        End Get
        Set(ByVal value As String)
            Me._EstadoGastoReparable = value
        End Set
    End Property

#End Region
End Class


