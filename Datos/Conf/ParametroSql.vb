Imports System.Data.SqlClient

Public Class ParametroSql

#Region "Parametros Adicionales"
    Public Vista As New SqlParameter("@Vista", SqlDbType.VarChar, 50, ParameterDirection.Input.ToString)
    Public DatoEliminado As New SqlParameter("@DatoEliminado", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public DatoEstado As New SqlParameter("@DatoEstado", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public CampoCondicion1 As New SqlParameter("@CampoCondicion1", SqlDbType.VarChar, 50, ParameterDirection.Input.ToString)
    Public DatoCondicion1 As New SqlParameter("@DatoCondicion1", SqlDbType.VarChar, 100, ParameterDirection.Input.ToString)
    Public CampoCondicion2 As New SqlParameter("@CampoCondicion2", SqlDbType.VarChar, 50, ParameterDirection.Input.ToString)
    Public DatoCondicion2 As New SqlParameter("@DatoCondicion2", SqlDbType.VarChar, 100, ParameterDirection.Input.ToString)
    Public CampoCondicion3 As New SqlParameter("@CampoCondicion3", SqlDbType.VarChar, 50, ParameterDirection.Input.ToString)
    Public DatoCondicion3 As New SqlParameter("@DatoCondicion3", SqlDbType.VarChar, 100, ParameterDirection.Input.ToString)
    Public CampoCondicion4 As New SqlParameter("@CampoCondicion4", SqlDbType.VarChar, 50, ParameterDirection.Input.ToString)
    Public DatoCondicion4 As New SqlParameter("@DatoCondicion4", SqlDbType.VarChar, 100, ParameterDirection.Input.ToString)
    Public CampoFiltro1 As New SqlParameter("@CampoFiltro1", SqlDbType.VarChar, 100, ParameterDirection.Input.ToString)
    Public DatoFiltro1 As New SqlParameter("@DatoFiltro1", SqlDbType.VarChar, 100, ParameterDirection.Input.ToString)
    Public CampoFiltro2 As New SqlParameter("@CampoFiltro2", SqlDbType.VarChar, 100, ParameterDirection.Input.ToString)
    Public DatoFiltro2 As New SqlParameter("@DatoFiltro2", SqlDbType.VarChar, 100, ParameterDirection.Input.ToString)
    Public CampoOrden As New SqlParameter("@CampoOrden", SqlDbType.VarChar, 200, ParameterDirection.Input.ToString)
    Public Orden As New SqlParameter("@Orden", SqlDbType.VarChar, 4, ParameterDirection.Input.ToString)
    Public Filtro As New SqlParameter("@Filtro", SqlDbType.VarChar, 15, ParameterDirection.Input.ToString)
    Public CampoFecha As New SqlParameter("@CampoFecha", SqlDbType.VarChar, 50, ParameterDirection.Input.ToString)
    Public Desde As New SqlParameter("@Desde", SqlDbType.DateTime, 50, ParameterDirection.Input.ToString)
    Public Hasta As New SqlParameter("@Hasta", SqlDbType.DateTime, 50, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa Grupo"

      Public CodigoGrupo As New SqlParameter("@CodigoGrupo", SqlDbType.Char, 3, ParameterDirection.Input.ToString)
      Public NombreGrupo As New SqlParameter("@NombreGrupo", SqlDbType.VarChar, 30, ParameterDirection.Input.ToString)
      Public PermisoPpto As New SqlParameter("@PermisoPpto", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa Usuario"

      Public CodigoUsuario As New SqlParameter("@CodigoUsuario", SqlDbType.VarChar, 30, ParameterDirection.Input.ToString)
    Public NombreUsuario As New SqlParameter("@NombreUsuario", SqlDbType.VarChar, 100, ParameterDirection.Input.ToString)
      Public ClaveUsuario As New SqlParameter("@ClaveUsuario", SqlDbType.VarChar, 10, ParameterDirection.Input.ToString)
      Public RespuestaUsuario As New SqlParameter("@RespuestaUsuario", SqlDbType.VarChar, 50, ParameterDirection.Input.ToString)
    'Public EstadoUsuario As New SqlParameter("@EstadoUsuario", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    ' Public OperacionUsuario As New SqlParameter("@OperacionUsuario", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa PreguntaSecreta"
      Public CodigoPregunta As New SqlParameter("@CodigoPregunta", SqlDbType.Char, 3, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa Auxiliar"
    Public CodigoAuxiliar As New SqlParameter("@CodigoAuxiliar", SqlDbType.VarChar, 11, ParameterDirection.Input.ToString)
    Public ApellidoPaternoAuxiliar As New SqlParameter("@ApellidoPaternoAuxiliar", SqlDbType.VarChar, 50, ParameterDirection.Input.ToString)
    Public ApellidoMaternoAuxiliar As New SqlParameter("@ApellidoMaternoAuxiliar", SqlDbType.VarChar, 50, ParameterDirection.Input.ToString)
    Public PrimerNombreAuxiliar As New SqlParameter("@PrimerNombreAuxiliar", SqlDbType.VarChar, 50, ParameterDirection.Input.ToString)
    Public SegundoNombreAuxiliar As New SqlParameter("@SegundoNombreAuxiliar", SqlDbType.VarChar, 50, ParameterDirection.Input.ToString)
    Public DescripcionAuxiliar As New SqlParameter("@DescripcionAuxiliar", SqlDbType.VarChar, 150, ParameterDirection.Input.ToString)
    Public DireccionAuxiliar As New SqlParameter("@DireccionAuxiliar", SqlDbType.VarChar, 150, ParameterDirection.Input.ToString)
    Public TelefonoAuxiliar As New SqlParameter("@TelefonoAuxiliar", SqlDbType.VarChar, 20, ParameterDirection.Input.ToString)
    Public CelularAuxiliar As New SqlParameter("@CelularAuxiliar", SqlDbType.VarChar, 10, ParameterDirection.Input.ToString)
    Public CorreoAuxiliar As New SqlParameter("@CorreoAuxiliar", SqlDbType.VarChar, 40, ParameterDirection.Input.ToString)
    Public ReferenciaAuxiliar As New SqlParameter("@ReferenciaAuxiliar", SqlDbType.VarChar, 150, ParameterDirection.Input.ToString)
    Public TipoAuxiliar As New SqlParameter("@TipoAuxiliar", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public TipoDocumentoAuxiliar As New SqlParameter("@TipoDocumentoAuxiliar", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public PaisNoDomiciliadoAuxiliar As New SqlParameter("@PaisNoDomiciliadoAuxiliar", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public EstadoAuxiliar As New SqlParameter("@EstadoAuxiliar", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public FechaInscripcionSnpAuxiliar As New SqlParameter("@FechaInscripcionSnpAuxiliar", SqlDbType.VarChar, 10, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa Registro compras"
    Public CodigoEmpresaRegistroCompra As New SqlParameter("@CodigoEmpresaRegistroCompra", SqlDbType.VarChar, 15, ParameterDirection.Input.ToString)
    Public PeriodoRegistroCompra As New SqlParameter("@PeriodoRegistroCompra", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public CodigoOrigenRegistroCompra As New SqlParameter("@CodigoOrigenRegistroCompra", SqlDbType.VarChar, 15, ParameterDirection.Input.ToString)
    Public CodigoFileRegistroCompra As New SqlParameter("@CodigoFileRegistroCompra", SqlDbType.VarChar, 15, ParameterDirection.Input.ToString)
    Public NumeroVoucherRegistroCompra As New SqlParameter("@NumeroVoucherRegistroCompra", SqlDbType.VarChar, 10, ParameterDirection.Input.ToString)
    Public DiaVoucherRegistroCompra As New SqlParameter("@DiaVoucherRegistroCompra", SqlDbType.VarChar, 2, ParameterDirection.Input.ToString)
    Public FechaVoucherRegistroCompra As New SqlParameter("@FechaVoucherRegistroCompra", SqlDbType.VarChar, 10, ParameterDirection.Input.ToString)
    Public CodigoCuentaRegistroCompra As New SqlParameter("@CodigoCuentaRegistroCompra", SqlDbType.VarChar, 15, ParameterDirection.Input.ToString)
    Public FlagPagoRegistroCompra As New SqlParameter("@FlagPagoRegistroCompra", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public MonedaPagoRegistroCompra As New SqlParameter("@MonedaPagoRegistroCompra", SqlDbType.VarChar, 5, ParameterDirection.Input.ToString)
    Public CuentaBancoRegistroCompra As New SqlParameter("@CuentaBancoRegistroCompra", SqlDbType.VarChar, 4, ParameterDirection.Input.ToString)
    Public NumeroChequeRegistroCompra As New SqlParameter("@NumeroChequeRegistroCompra", SqlDbType.VarChar, 50, ParameterDirection.Input.ToString)
    Public ImporteChequeRegistroCompra As New SqlParameter("@ImporteChequeRegistroCompra", SqlDbType.VarChar, 12, ParameterDirection.Input.ToString)
    Public FechaChequeRegistroCompra As New SqlParameter("@FechaChequeRegistroCompra", SqlDbType.VarChar, 10, ParameterDirection.Input.ToString)
    Public CodigoAuxiliarRegistroCompra As New SqlParameter("@CodigoAuxiliarRegistroCompra", SqlDbType.VarChar, 11, ParameterDirection.Input.ToString)
    Public CodigoDocumentoRegistroCompra As New SqlParameter("@CodigoDocumentoRegistroCompra", SqlDbType.VarChar, 15, ParameterDirection.Input.ToString)
    Public SerieDocumentoRegistroCompra As New SqlParameter("@SerieDocumentoRegistroCompra", SqlDbType.VarChar, 4, ParameterDirection.Input.ToString)
    Public NumeroDocumentoRegistroCompra As New SqlParameter("@NumeroDocumentoRegistroCompra", SqlDbType.VarChar, 15, ParameterDirection.Input.ToString)
    Public FechaDocumentoRegistroCompra As New SqlParameter("@FechaDocumentoRegistroCompra", SqlDbType.VarChar, 10, ParameterDirection.Input.ToString)
    Public MonedaDocumentoRegistroCompra As New SqlParameter("@MonedaDocumentoRegistroCompra", SqlDbType.VarChar, 5, ParameterDirection.Input.ToString)
    Public TipoCambioRegistroCompra As New SqlParameter("@TipoCambioRegistroCompra", SqlDbType.VarChar, 10, ParameterDirection.Input.ToString)
    Public DolaresRegistroCompra As New SqlParameter("@DolaresRegistroCompra", SqlDbType.VarChar, 10, ParameterDirection.Input.ToString)
    Public PrecioCompraDolRegistroCompra As New SqlParameter("@PrecioCompraDolRegistroCompra", SqlDbType.VarChar, 12, ParameterDirection.Input.ToString)
    Public ValorCompraDolRegistroCompra As New SqlParameter("@ValorCompraDolRegistroCompra", SqlDbType.VarChar, 12, ParameterDirection.Input.ToString)
    Public ValorIgvDolRegistroCompra As New SqlParameter("@ValorIgvDolRegistroCompra", SqlDbType.VarChar, 12, ParameterDirection.Input.ToString)
    Public ValorExoneradoDolRegistroCompra As New SqlParameter("@ValorExoneradoDolRegistroCompra", SqlDbType.VarChar, 12, ParameterDirection.Input.ToString)
    Public PrecioCompraSolRegistroCompra As New SqlParameter("@PrecioCompraSolRegistroCompra", SqlDbType.VarChar, 12, ParameterDirection.Input.ToString)
    Public ValorCompraSolRegistroCompra As New SqlParameter("@ValorCompraSolRegistroCompra", SqlDbType.VarChar, 12, ParameterDirection.Input.ToString)
    Public ValorIgvSolRegistroCompra As New SqlParameter("@ValorIgvSolRegistroCompra", SqlDbType.VarChar, 12, ParameterDirection.Input.ToString)
    Public ValorExoneradoSolRegistroCompra As New SqlParameter("@ValorExoneradoSolRegistroCompra", SqlDbType.VarChar, 12, ParameterDirection.Input.ToString)
    Public AnoCompraRegistroCompra As New SqlParameter("@AnoCompraRegistroCompra", SqlDbType.VarChar, 4, ParameterDirection.Input.ToString)
    Public MesCompraRegistroCompra As New SqlParameter("@MesCompraRegistroCompra", SqlDbType.VarChar, 2, ParameterDirection.Input.ToString)
    Public DebeHaberRegistroCompra As New SqlParameter("@DebeHaberRegistroCompra", SqlDbType.VarChar, 5, ParameterDirection.Input.ToString)
    Public GlosaRegistroCompra As New SqlParameter("@GlosaRegistroCompra", SqlDbType.VarChar, 50, ParameterDirection.Input.ToString)
    Public EstadoRegistroCompra As New SqlParameter("@EstadoRegistroCompra", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public EliminadoRegistroCompra As New SqlParameter("@EliminadoRegistroCompra", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)



#End Region

#Region "Parametros Pa Distrito"
    Public CodigoDistrito As New SqlParameter("@CodigoDistrito", SqlDbType.VarChar, 4, ParameterDirection.Input.ToString)
    'Public NombreDistrito As New SqlParameter("@ NombreDistrito", SqlDbType.VarChar, 3, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa Documento Identidad"
      Public CodigoDocumentoIdentidad As New SqlParameter("@CodigoDocumentoIdentidad", SqlDbType.VarChar, 2, ParameterDirection.Input.ToString)
      'Public NombreDistrito As New SqlParameter("@ NombreDistrito", SqlDbType.VarChar, 3, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa Origen"
    Public CodigoOrigen As New SqlParameter("@CodigoOrigen", SqlDbType.VarChar, 5, ParameterDirection.Input.ToString)
    'Public NombreDistrito As New SqlParameter("@ NombreDistrito", SqlDbType.VarChar, 3, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa File"
      Public CodigoFile As New SqlParameter("@CodigoFile", SqlDbType.VarChar, 4, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa Files"
    Public ClaveFile As New SqlParameter("@ClaveFile", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public NombreFile As New SqlParameter("@NombreFile", SqlDbType.VarChar, 100, ParameterDirection.Input.ToString)
    Public EstadoFile As New SqlParameter("@EstadoFile", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa Ingreso/Egreso"
      Public CodigoIngEgr As New SqlParameter("@CodigoIngEgr", SqlDbType.VarChar, 4, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa EstadoCivil"
      Public CodigoEstadoCivil As New SqlParameter("@CodigoEstadoCivil", SqlDbType.VarChar, 2, ParameterDirection.Input.ToString)
      'Public NombreDistrito As New SqlParameter("@ NombreDistrito", SqlDbType.VarChar, 3, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa Distrito"
    Public CodigoMes As New SqlParameter("@CodigoMes", SqlDbType.VarChar, 2, ParameterDirection.Input.ToString)
    'Public NombreDistrito As New SqlParameter("@ NombreDistrito", SqlDbType.VarChar, 3, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa Concepto"
      Public Titulo As New SqlParameter("@Titulo", SqlDbType.VarChar, 5, ParameterDirection.Input.ToString)
      Public SubTitulo As New SqlParameter("@SubTitulo", SqlDbType.VarChar, 5, ParameterDirection.Input.ToString)
      Public CodigoConcepto As New SqlParameter("@CodigoConcepto", SqlDbType.VarChar, 5, ParameterDirection.Input.ToString)
      'Public NombreDistrito As New SqlParameter("@ NombreDistrito", SqlDbType.VarChar, 3, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa Area"
    'Public CodigoArea As New SqlParameter("@CodigoArea", SqlDbType.VarChar, 5, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa Centro costo"
    'Public CodigoCentroCosto As New SqlParameter("@CodigoCentroCosto", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa Tabla"
    Public TipoTabla As New SqlParameter("@TipoTabla", SqlDbType.Char, 3, ParameterDirection.Input.ToString)
    Public CodigoItemTabla As New SqlParameter("@CodigoItemTabla", SqlDbType.VarChar, 15, ParameterDirection.Input.ToString)
    Public NombreItemTabla As New SqlParameter("@NombreItemTabla", SqlDbType.VarChar, 150, ParameterDirection.Input.ToString)
    Public Voucher As New SqlParameter("@Voucher", SqlDbType.VarChar, 15, ParameterDirection.Input.ToString)
    Public NumeroApertura As New SqlParameter("@NumeroApertura", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public NumeroEnero As New SqlParameter("@NumeroEnero", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public NumeroFebrero As New SqlParameter("@NumeroFebrero", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public NumeroMarzo As New SqlParameter("@NumeroMarzo", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public NumeroAbril As New SqlParameter("@NumeroAbril", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public NumeroMayo As New SqlParameter("@NumeroMayo", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public NumeroJunio As New SqlParameter("@NumeroJunio", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public NumeroJulio As New SqlParameter("@NumeroJulio", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public NumeroAgosto As New SqlParameter("@NumeroAgosto", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public NumeroSetiembre As New SqlParameter("@NumeroSetimbre", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public NumeroOctubre As New SqlParameter("@NumeroOctubre", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public NumeroNoviembre As New SqlParameter("@NumeroNoviembre", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public NumeroDiciembre As New SqlParameter("@NumeroDiciembre", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public NumeroCierre As New SqlParameter("@NumeroCierre", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Auditoria"
    Public CodigoUsuarioAgrega As New SqlParameter("@CodigoUsuarioAgrega", SqlDbType.VarChar, 30, ParameterDirection.Input.ToString)
    Public CodigoPersonalAgrega As New SqlParameter("@CodigoPersonalAgrega", SqlDbType.VarChar, 5, ParameterDirection.Input.ToString)
    Public FechaAgrega As New SqlParameter("@FechaAgrega", SqlDbType.DateTime, 100, ParameterDirection.Input.ToString)
    Public CodigoUsuarioModifica As New SqlParameter("@CodigoUsuarioModifica", SqlDbType.VarChar, 30, ParameterDirection.Input.ToString)
    Public FechaModifica As New SqlParameter("@FechaModifica", SqlDbType.DateTime, 100, ParameterDirection.Input.ToString)
    Public CodigoPersonalModifica As New SqlParameter("@CodigoPersonalModifica", SqlDbType.VarChar, 5, ParameterDirection.Input.ToString)
    Public FechaHoraPcCliente As New SqlParameter("@FechaHoraPcCliente", SqlDbType.DateTime, 100, ParameterDirection.Input.ToString)
    Public EstadoRegistro As New SqlParameter("@EstadoRegistro", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public EliminadoRegistro As New SqlParameter("@EliminadoRegistro", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public Exporta As New SqlParameter("@Exporta", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public NombreUsuarioAgrega As New SqlParameter("@NombreUsuarioAgrega", SqlDbType.VarChar, 100, ParameterDirection.Input.ToString)
    Public NombreUsuarioModifica As New SqlParameter("@NombreUsuarioModifica", SqlDbType.VarChar, 100, ParameterDirection.Input.ToString)
#End Region

#Region "Tipo Cambio"
    Public FechaTipoCambio As New SqlParameter("@FechaTipoCambio", SqlDbType.DateTime, 30, ParameterDirection.Input.ToString)
    Public CompraTipoCambio As New SqlParameter("@CompraTipoCambio", SqlDbType.Decimal, 8, ParameterDirection.Input.ToString)
    Public VentaTipoCambio As New SqlParameter("@VentaTipoCambio", SqlDbType.Decimal, 8, ParameterDirection.Input.ToString)
    Public CompraEurTipoCambio As New SqlParameter("@CompraEurTipoCambio", SqlDbType.Decimal, 8, ParameterDirection.Input.ToString)
    Public VentaEurTipoCambio As New SqlParameter("@VentaEurTipoCambio", SqlDbType.Decimal, 8, ParameterDirection.Input.ToString)
    Public MesTipoCambio As New SqlParameter("@MesTipoCambio", SqlDbType.VarChar, 2, ParameterDirection.Input.ToString)
    Public AnoTipoCambio As New SqlParameter("@AnoTipoCambio", SqlDbType.VarChar, 4, ParameterDirection.Input.ToString)
    Public DolarEuroTipoCambio As New SqlParameter("@DolarEuroTipoCambio", SqlDbType.Decimal, 8, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa Dias Por Mes"
      Public AnoMesDiasPorMes As New SqlParameter("@AnoMesDiasPorMes", SqlDbType.Char, 7, ParameterDirection.Input.ToString)
      Public AnoDiasPorMes As New SqlParameter("@AnoDiasPorMes", SqlDbType.VarChar, 4, ParameterDirection.Input.ToString)
      Public NumeroDiasPorMes As New SqlParameter("@NumeroDiasPorMes", SqlDbType.VarChar, 2, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa Parametro"
    Public IgvPar As New SqlParameter("@IgvPar", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public PorGastosGenerales As New SqlParameter("@PorGastosGenerales", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public PorGastosAdministrativos As New SqlParameter("@PorGastosAdministrativos", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public PorUtilidad As New SqlParameter("@PorUtilidad", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public CuentaTransferencia As New SqlParameter("@CuentaTransferencia", SqlDbType.VarChar, 8, ParameterDirection.Input.ToString)
    Public PorRetencionHonorario As New SqlParameter("@PorRetencionHonorario", SqlDbType.Decimal, 10, ParameterDirection.Input.ToString)
    Public DigitosCuentaAnalitica As New SqlParameter("@DigitosCuentaAnalitica", SqlDbType.VarChar, 2, ParameterDirection.Input.ToString)
    Public CuentaIgv As New SqlParameter("@CuentaIgv", SqlDbType.VarChar, 8, ParameterDirection.Input.ToString)
    Public CuentaHonorarioNeto As New SqlParameter("@CuentaHonorarioNeto", SqlDbType.VarChar, 8, ParameterDirection.Input.ToString)
    Public CuentaHonorarioRetencion As New SqlParameter("@CuentaHonorarioRetencion", SqlDbType.VarChar, 8, ParameterDirection.Input.ToString)
    Public CuentaAutomatica As New SqlParameter("@CuentaAutomatica", SqlDbType.VarChar, 8, ParameterDirection.Input.ToString)
    Public CuentaGananciaDC As New SqlParameter("@CuentaGananciaDC", SqlDbType.VarChar, 8, ParameterDirection.Input.ToString)
    Public CuentaPerdidaDC As New SqlParameter("@CuentaPerdidaDC", SqlDbType.VarChar, 8, ParameterDirection.Input.ToString)
    Public PorcentajeDsctoAfp2014 As New SqlParameter("@PorcentajeDsctoAfp2014", SqlDbType.Decimal, 10, ParameterDirection.Input.ToString)
    Public PorcentajeDsctoAfp2015 As New SqlParameter("@PorcentajeDsctoAfp2015", SqlDbType.Decimal, 10, ParameterDirection.Input.ToString)
    Public PorcentajeDsctoAfp2016 As New SqlParameter("@PorcentajeDsctoAfp2016", SqlDbType.Decimal, 10, ParameterDirection.Input.ToString)
    Public PorcentajeDsctoSnp2014 As New SqlParameter("@PorcentajeDsctoSnp2014", SqlDbType.Decimal, 10, ParameterDirection.Input.ToString)
    Public PorcentajeDsctoSnp2015 As New SqlParameter("@PorcentajeDsctoSnp2015", SqlDbType.Decimal, 10, ParameterDirection.Input.ToString)
    Public PorcentajeDsctoSnp2016 As New SqlParameter("@PorcentajeDsctoSnp2016", SqlDbType.Decimal, 10, ParameterDirection.Input.ToString)
    Public CuentaAfp As New SqlParameter("@CuentaAfp", SqlDbType.VarChar, 8, ParameterDirection.Input.ToString)
    Public CuentaSnp As New SqlParameter("@CuentaSnp", SqlDbType.VarChar, 8, ParameterDirection.Input.ToString)
    Public CuentaValorVenta As New SqlParameter("@CuentaValorVenta", SqlDbType.VarChar, 8, ParameterDirection.Input.ToString)
    Public CuentaPrecioVenta As New SqlParameter("@CuentaPrecioVenta", SqlDbType.VarChar, 8, ParameterDirection.Input.ToString)
    Public CuentaClase8Cierre As New SqlParameter("@CuentaClase8Cierre", SqlDbType.VarChar, 8, ParameterDirection.Input.ToString)
    Public CuentaGananciaCierre As New SqlParameter("@CuentaGananciaCierre", SqlDbType.VarChar, 8, ParameterDirection.Input.ToString)
    Public CuentaPerdidaCierre As New SqlParameter("@CuentaPerdidaCierre", SqlDbType.VarChar, 8, ParameterDirection.Input.ToString)
    Public PorcentajeImpuestoRenta As New SqlParameter("@PorcentajeImpuestoRenta", SqlDbType.Decimal, 10, ParameterDirection.Input.ToString)
    Public CodigoFileVentas As New SqlParameter("@CodigoFileVentas", SqlDbType.VarChar, 3, ParameterDirection.Input.ToString)
    Public CodigoOrigenVentas As New SqlParameter("@CodigoOrigenVentas", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public Cuenta16PrecioVentaEmpresa As New SqlParameter("@Cuenta16PrecioVentaEmpresa", SqlDbType.VarChar, 8, ParameterDirection.Input.ToString)
    Public CodigoOrigenDiario As New SqlParameter("@CodigoOrigenDiario", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public CodigoFileDiario As New SqlParameter("@CodigoFileDiario", SqlDbType.VarChar, 3, ParameterDirection.Input.ToString)
    Public Cuenta75ValorVentaEmpresa As New SqlParameter("@Cuenta75ValorVentaEmpresa", SqlDbType.VarChar, 8, ParameterDirection.Input.ToString)
    Public CuentaIgvEmpresa As New SqlParameter("@CuentaIgvEmpresa", SqlDbType.VarChar, 8, ParameterDirection.Input.ToString)
    Public CCodigoOrigenRegistroVentasxx As New SqlParameter("@CCodigoOrigenRegistroVentas", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public CCodigoFileRegistroVentas As New SqlParameter("@CCodigoFileRegistroVentas", SqlDbType.VarChar, 3, ParameterDirection.Input.ToString)
    Public CuentaCuotaOrdinaria As New SqlParameter("@CuentaCuotaOrdinaria", SqlDbType.VarChar, 8, ParameterDirection.Input.ToString)
    Public CuentaCuotaSupervisionYProyectos As New SqlParameter("@CuentaCuotaSupervisionYProyectos", SqlDbType.VarChar, 8, ParameterDirection.Input.ToString)
    Public CuentaCuotaAgua As New SqlParameter("@CuentaCuotaAgua", SqlDbType.VarChar, 8, ParameterDirection.Input.ToString)
    Public CuentaCuotaElectricidad As New SqlParameter("@CuentaCuotaElectricidad", SqlDbType.VarChar, 8, ParameterDirection.Input.ToString)
    Public CuentaCuotaIngreso As New SqlParameter("@CuentaCuotaIngreso", SqlDbType.VarChar, 8, ParameterDirection.Input.ToString)
    Public CuentaCuotaExtraordinaria As New SqlParameter("@CuentaCuotaExtraordinaria", SqlDbType.VarChar, 8, ParameterDirection.Input.ToString)
    Public CuentaCuotaMoras As New SqlParameter("@CuentaCuotaMoras", SqlDbType.VarChar, 8, ParameterDirection.Input.ToString)
    Public CuentaMontoTotalCuotas As New SqlParameter("@CuentaMontoTotalCuotas", SqlDbType.VarChar, 8, ParameterDirection.Input.ToString)

#End Region

#Region "Parametros Reg Contab Cabe"
    Public ClaveRegContabCabe As New SqlParameter("@ClaveRegContabCabe", SqlDbType.VarChar, 19, ParameterDirection.Input.ToString)
    Public PeriodoRegContabCabe As New SqlParameter("@PeriodoRegContabCabe", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public NumeroVoucherRegContabCabe As New SqlParameter("@NumeroVoucherRegContabCabe", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public MonedaVoucherRegContabCabe As New SqlParameter("@MonedaVoucherRegContabCabe", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public DiaVoucherRegContabCabe As New SqlParameter("@DiaVoucherRegContabCabe", SqlDbType.VarChar, 2, ParameterDirection.Input.ToString)
    Public FechaVoucherRegContabCabe As New SqlParameter("@FechaVoucherRegContabCabe", SqlDbType.DateTime, 100, ParameterDirection.Input.ToString)
    Public SerieDocumento As New SqlParameter("@SerieDocumento", SqlDbType.VarChar, 4, ParameterDirection.Input.ToString)
    Public NumeroDocumento As New SqlParameter("@NumeroDocumento", SqlDbType.VarChar, 15, ParameterDirection.Input.ToString)
    Public FechaDocumento As New SqlParameter("@FechaDocumento", SqlDbType.DateTime, 100, ParameterDirection.Input.ToString)
    Public FechaVencimiento As New SqlParameter("@FechaVencimiento", SqlDbType.DateTime, 100, ParameterDirection.Input.ToString)
    Public MonedaDocumento As New SqlParameter("@MonedaDocumento", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public SerieDocumento1 As New SqlParameter("@SerieDocumento1", SqlDbType.VarChar, 4, ParameterDirection.Input.ToString)
    Public NumeroDocumento1 As New SqlParameter("@NumeroDocumento1", SqlDbType.VarChar, 15, ParameterDirection.Input.ToString)
    Public FechaDocumento1 As New SqlParameter("@FechaDocumento1", SqlDbType.VarChar, 10, ParameterDirection.Input.ToString)
    Public MonedaDocumento1 As New SqlParameter("@MonedaDocumento1", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public ValorVtaRegContabCabe As New SqlParameter("@ValorVtaRegContabCabe", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public IgvRegContabCabe As New SqlParameter("@IgvRegContabCabe", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public ExoneradoRegContabCabe As New SqlParameter("@ExoneradoRegContabCabe", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public PrecioVtaRegContabCabe As New SqlParameter("@PrecioVtaRegContabCabe", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public ValorVtaSolRegContabCabe As New SqlParameter("@ValorVtaSolRegContabCabe", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public IgvSolRegContabCabe As New SqlParameter("@IgvSolRegContabCabe", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public ExoneradoSolRegContabCabe As New SqlParameter("@ExoneradoSolRegContabCabe", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public PrecioVtaSolRegContabCabe As New SqlParameter("@PrecioVtaSolRegContabCabe", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public GlosaRegContabCabe As New SqlParameter("@GlosaRegContabCabe", SqlDbType.VarChar, 50, ParameterDirection.Input.ToString)
    Public RetencionRegContabCabe As New SqlParameter("@RetencionRegContabCabe", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public ImporteRegContabCabe As New SqlParameter("@ImporteRegContabCabe", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public DetraccionRegContabCabe As New SqlParameter("@DetraccionRegContabCabe", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public NumeroPapeletaRegContabCabe As New SqlParameter("@NumeroPapeletaRegContabCabe", SqlDbType.VarChar, 15, ParameterDirection.Input.ToString)
    Public FechaDetraccionRegContabCabe As New SqlParameter("@FechaDetraccionRegContabCabe", SqlDbType.VarChar, 10, ParameterDirection.Input.ToString)
    Public CartaRegContabCabe As New SqlParameter("@CartaRegContabCabe", SqlDbType.VarChar, 100, ParameterDirection.Input.ToString)
    Public DescripcionRegContabCabe As New SqlParameter("@DescripcionRegContabCabe", SqlDbType.VarChar, 100, ParameterDirection.Input.ToString)
    Public VoucherIngresoRegContabCabe As New SqlParameter("@VoucherIngresoRegContabCabe", SqlDbType.VarChar, 50, ParameterDirection.Input.ToString)
    Public EstadoRegContabCabe As New SqlParameter("@EstadoRegContabCabe", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public SumaDebeRegContabCabe As New SqlParameter("@SumaDebeRegContabCabe", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public SumaHaberRegContabCabe As New SqlParameter("@SumaHaberRegContabCabe", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public UltimoCorrelativo As New SqlParameter("@UltimoCorrelativo", SqlDbType.VarChar, 4, ParameterDirection.Input.ToString)
    Public ImporteSolRegContabCabe As New SqlParameter("@ImporteSolRegContabCabe", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public ModoCompra As New SqlParameter("@ModoCompra", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public FlagDescuentoRegContabCabe As New SqlParameter("@FlagDescuentoRegContabCabe", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public ImporteDescuentoRegContabCabe As New SqlParameter("@ImporteDescuentoRegContabCabe", SqlDbType.Decimal, 10, ParameterDirection.Input.ToString)
    Public DescuentoFondo As New SqlParameter("@DescuentoFondo", SqlDbType.Decimal, 10, ParameterDirection.Input.ToString)
    Public DescuentoSalud As New SqlParameter("@DescuentoSalud", SqlDbType.Decimal, 10, ParameterDirection.Input.ToString)
    Public DescuentoRemu As New SqlParameter("@DescuentoRemu", SqlDbType.Decimal, 10, ParameterDirection.Input.ToString)

#End Region

#Region "Parametros Reg Contab Deta"
    Public CorrelativoRegContabDeta As New SqlParameter("@CorrelativoRegContabDeta", SqlDbType.VarChar, 4, ParameterDirection.Input.ToString)
    Public ClaveRegContabDeta As New SqlParameter("@ClaveRegContabDeta", SqlDbType.VarChar, 23, ParameterDirection.Input.ToString)
    Public DebeHaberRegContabDeta As New SqlParameter("@DebeHaberRegContabDeta", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public ImporteSRegContabDeta As New SqlParameter("@ImporteSRegContabDeta", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public ImporteDRegContabDeta As New SqlParameter("@ImporteDRegContabDeta", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public ImporteERegContabDeta As New SqlParameter("@ImporteERegContabDeta", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public GlosaRegContabDeta As New SqlParameter("@GlosaRegContabDeta", SqlDbType.VarChar, 50, ParameterDirection.Input.ToString)
    Public EstadoRegContabDeta As New SqlParameter("@EstadoRegContabDeta", SqlDbType.VarChar, 50, ParameterDirection.Input.ToString)
    Public MontoMoneda As New SqlParameter("@MontoMoneda", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public MontoSoles As New SqlParameter("@MontoSoles", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public CodigoPptoInterno As New SqlParameter("@CodigoPptoInterno", SqlDbType.VarChar, 20, ParameterDirection.Input.ToString)
    Public Cantidad As New SqlParameter("@Cantidad", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa Permisos"
    Public Sistema As New SqlParameter("@Sistema", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public perfiles As New SqlParameter("@perfiles", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public Usuarios As New SqlParameter("@Usuarios", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public Maestros As New SqlParameter("@Maestros", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public Tablas As New SqlParameter("@Tablas", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public Especialidad As New SqlParameter("@Especialidad", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public CentroCosto As New SqlParameter("@CentroCosto", SqlDbType.Char, 6, ParameterDirection.Input.ToString)
    Public TablasPersonal As New SqlParameter("@TablasPersonal", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public DocumentoIdentidad As New SqlParameter("@DocumentoIdentidad", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public EstadoCivil As New SqlParameter("@EstadoCivil", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public TipoPension As New SqlParameter("@TipoPension", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public PensionAfp As New SqlParameter("@PensionAfp", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public CarreraProfesional As New SqlParameter("@CarreraProfesional", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public Area As New SqlParameter("@Area", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public AreaFuncional As New SqlParameter("@AreaFuncional", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public Contratacion As New SqlParameter("@Contratacion", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public TablasContabilidad As New SqlParameter("@TablasContabilidad", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public Documentos As New SqlParameter("@Documentos", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public Origenes As New SqlParameter("@Origenes", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public Files As New SqlParameter("@Files", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public TipoCambio As New SqlParameter("@TipoCambio", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public Cuentas As New SqlParameter("@Cuentas", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public TablasPptoInterno As New SqlParameter("@TablasPptoInterno", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public DiasPorMes As New SqlParameter("@DiasPorMes", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public Segmentos As New SqlParameter("@Segmentos", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public Unidades As New SqlParameter("@Unidades", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public Partidas As New SqlParameter("@Partidas", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public SubPartidas As New SqlParameter("@SubPartidas", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public HonorariosProfesionales As New SqlParameter("@HonorariosProfesionales", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public Contratos As New SqlParameter("@Contratos", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public CPersonal As New SqlParameter("@CPersonal", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public CServicios As New SqlParameter("@CServicios", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public Movilizaciones As New SqlParameter("@Movilizaciones", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public MaterialesOtros As New SqlParameter("@MaterialesOtros", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public Reembolsables As New SqlParameter("@Reembolsables", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public Personal As New SqlParameter("@Personal", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public ClienteProveedores As New SqlParameter("@ClienteProveedores", SqlDbType.Char, 1, ParameterDirection.Input.ToString)

    Public Digitacion As New SqlParameter("@Digitacion", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public PptoInterno As New SqlParameter("@PptoInterno", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public ConceptoHojaTiempo As New SqlParameter("@ConceptoHojaTiempo", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public RegistroGastos As New SqlParameter("@RegistroGastos", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public RegistroCompras As New SqlParameter("@RegistroCompras", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public RegistroVentas As New SqlParameter("@RegistroVentas", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public Reportes As New SqlParameter("@Reportes", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public MovHorasPersonal As New SqlParameter("@MovHorasPersonal", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public MovHorasPersonalOri As New SqlParameter("@MovHorasPersonalOri", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public Utilitarios As New SqlParameter("@Utilitarios", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public Parametros As New SqlParameter("@Parametros", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public ExportarRegCompras As New SqlParameter("@ExportarRegCompras", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public ExportarRegVentas As New SqlParameter("@ExportarRegVentas", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public ExportarRegGastos As New SqlParameter("@ExportarRegGastos", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public ExportarNuevoPersonal As New SqlParameter("@ExportarNuevoPersonal", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public ImportarMovHoras As New SqlParameter("@ImportarMovHoras", SqlDbType.Char, 1, ParameterDirection.Input.ToString)

    Public NombreTabla As New SqlParameter("@NombreTabla", SqlDbType.VarChar, 50, ParameterDirection.Input.ToString)
    Public Agregar As New SqlParameter("@Agregar", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public Modificar As New SqlParameter("@Modificar", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public Eliminar As New SqlParameter("@Eliminar", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public Consultar As New SqlParameter("@Consultar", SqlDbType.Char, 1, ParameterDirection.Input.ToString)

    Public CopiaBD As New SqlParameter("@CopiaBD", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public CopiaPlanilla As New SqlParameter("@CopiaPlanilla", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public ModificarPlanilla As New SqlParameter("@ModificarPlanilla", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public CodigoInexistente As New SqlParameter("@CodigoInexistente", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa PlanDeCuentas"
    Public CodigoCuentaPcge As New SqlParameter("@CodigoCuentaPcge", SqlDbType.VarChar, 8, ParameterDirection.Input.ToString)
    Public NombreCuentaPcge As New SqlParameter("@NombreCuentaPcge", SqlDbType.VarChar, 80, ParameterDirection.Input.ToString)
    Public NumeroDigitosPcge As New SqlParameter("@NumeroDigitosPcge", SqlDbType.VarChar, 2, ParameterDirection.Input.ToString)
    Public EstadoPlanDeCuentas As New SqlParameter("@EstadoPlanDeCuentas", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa PlanCuentaGe"
    Public ClaveCuentaPcge As New SqlParameter("@ClaveCuentaPcge", SqlDbType.VarChar, 11, ParameterDirection.Input.ToString)
    Public FlagDocumentoPcge As New SqlParameter("@FlagDocumentoPcge", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public FlagAuxiliarPcge As New SqlParameter("@FlagAuxiliarPcge", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public FlagCentroCostoPcge As New SqlParameter("@FlagCentroCostoPcge", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public FlagAlmacenPcge As New SqlParameter("@FlagAlmacenPcge", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public FlagAreaPcge As New SqlParameter("@FlagAreaPcge", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public FlagFlujoCajaPcge As New SqlParameter("@FlagFlujoCajaPcge", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public FlagAutomaticaPcge As New SqlParameter("@FlagAutomaticaPcge", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public FlagDifCambioPcge As New SqlParameter("@FlagDifCambioPcge", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public FlagBancoPcge As New SqlParameter("@FlagBancoPcge", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public FlagMonedaPcge As New SqlParameter("@FlagMonedaPcge", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public FlagAsientoAperturaPcge As New SqlParameter("@FlagAsientoAperturaPcge", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public FlagAsientoCierre9Pcge As New SqlParameter("FlagAsientoCierre9Pcge", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public FlagAsientoCierre7Pcge As New SqlParameter("FlagAsientoCierre7Pcge", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public FlagTipoCuentaPcge As New SqlParameter("@FlagTipoCuentaPcge", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public EstadoCuenta As New SqlParameter("@EstadoCuenta", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public CuentaAutomatica1Pcge As New SqlParameter("@CuentaAutomatica1Pcge", SqlDbType.VarChar, 8, ParameterDirection.Input.ToString)
    Public CuentaAutomatica2Pcge As New SqlParameter("@CuentaAutomatica2Pcge", SqlDbType.VarChar, 8, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa Empresa"
    Public CodigoEmpresa As New SqlParameter("@CodigoEmpresa", SqlDbType.VarChar, 3, ParameterDirection.Input.ToString)
    Public RazonSocialEmpresa As New SqlParameter("@RazonSocialEmpresa", SqlDbType.VarChar, 60, ParameterDirection.Input.ToString)
    Public NombreCortoEmpresa As New SqlParameter("@NombreCortoEmpresa", SqlDbType.VarChar, 30, ParameterDirection.Input.ToString)
    Public DireccionEmpresa As New SqlParameter("@DireccionEmpresa", SqlDbType.VarChar, 80, ParameterDirection.Input.ToString)
    Public RucEmpresa As New SqlParameter("@RucEmpresa", SqlDbType.VarChar, 11, ParameterDirection.Input.ToString)
    Public EstadoEmpresa As New SqlParameter("@EstadoEmpresa", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public PeriodoEmpresa As New SqlParameter("@PeriodoEmpresa", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa CuentaBanco"
    Public ClaveCuentaBanco As New SqlParameter("@ClaveCuentaBanco", SqlDbType.VarChar, 11, ParameterDirection.Input.ToString)
    Public CodigoCuentaBanco As New SqlParameter("@CodigoCuentaBanco", SqlDbType.VarChar, 8, ParameterDirection.Input.ToString)
    Public BancoCuentaBanco As New SqlParameter("@BancoCuentaBanco", SqlDbType.VarChar, 40, ParameterDirection.Input.ToString)
    Public AgenciaCuentaBanco As New SqlParameter("@AgenciaCuentaBanco", SqlDbType.VarChar, 40, ParameterDirection.Input.ToString)
    Public NumeroCuentaBanco As New SqlParameter("@NumeroCuentaBanco", SqlDbType.VarChar, 20, ParameterDirection.Input.ToString)
    Public MonedaCuentaBanco As New SqlParameter("@MonedaCuentaBanco", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public TipoCuentaBanco As New SqlParameter("@TipoCuentaBanco", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public SaldoCuentaBanco As New SqlParameter("@SaldoCuentaBanco", SqlDbType.Decimal, 10, ParameterDirection.Input.ToString)
    Public EstadoCuentaBanco As New SqlParameter("@EstadoCuentaBanco", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa Cta1242"
    Public Cuenta1242 As New SqlParameter("@Cuenta1242", SqlDbType.VarChar, 8, ParameterDirection.Input.ToString)
    Public NombreCuenta1242 As New SqlParameter("@ NombreCuenta1242", SqlDbType.VarChar, 50, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa Tipo Documento"
    Public TipoDocumento As New SqlParameter("@TipoDocumento", SqlDbType.VarChar, 2, ParameterDirection.Input.ToString)
    Public TipoDocumento1 As New SqlParameter("@TipoDocumento1", SqlDbType.VarChar, 2, ParameterDirection.Input.ToString)
    Public NombreDocumento As New SqlParameter("@ NombreDocumento", SqlDbType.VarChar, 50, ParameterDirection.Input.ToString)
    Public NombreDocumento1 As New SqlParameter("@ NombreDocumento1", SqlDbType.VarChar, 50, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Modo Pago"
    Public CodigoModoPago As New SqlParameter("@CodigoModoPago", SqlDbType.VarChar, 3, ParameterDirection.Input.ToString)
    ' Public NombreModoPago As New SqlParameter("@ NombreCuenta1242", SqlDbType.VarChar, 50, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa Voucher"
    Public ClaveVoucher As New SqlParameter("@ClaveVoucher", SqlDbType.VarChar, 10, ParameterDirection.Input.ToString)
    Public AnoVoucher As New SqlParameter("@AnoVoucher", SqlDbType.VarChar, 4, ParameterDirection.Input.ToString)
    Public AperturaVoucher As New SqlParameter("@AperturaVoucher", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public EneroVoucher As New SqlParameter("@EneroVoucher", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public FebreroVoucher As New SqlParameter("@FebreroVoucher", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public MarzoVoucher As New SqlParameter("@MarzoVoucher", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public AbrilVoucher As New SqlParameter("@AbrilVoucher", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public MayoVoucher As New SqlParameter("@MayoVoucher", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public JunioVoucher As New SqlParameter("@JunioVoucher", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public JulioVoucher As New SqlParameter("@JulioVoucher", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public AgostoVoucher As New SqlParameter("@AgostoVoucher", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public SetiembreVoucher As New SqlParameter("@SetiembreVoucher", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public OctubreVoucher As New SqlParameter("@OctubreVoucher", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public NoviembreVoucher As New SqlParameter("@NoviembreVoucher", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public DiciembreVoucher As New SqlParameter("@DiciembreVoucher", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public CierreVoucher As New SqlParameter("@CierreVoucher", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public EstadoVoucher As New SqlParameter("@EstadoVoucher", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa FormatoContable"
    Public ClaveFormatoContable As New SqlParameter("@ClaveFormatoContable", SqlDbType.VarChar, 11, ParameterDirection.Input.ToString)
    Public CodigoFormatoContable As New SqlParameter("@CodigoFormatoContable", SqlDbType.VarChar, 8, ParameterDirection.Input.ToString)
    Public DescripcionFormatoContable As New SqlParameter("@DescripcionFormatoContable", SqlDbType.VarChar, 100, ParameterDirection.Input.ToString)
    Public GrupoFormatoContable As New SqlParameter("@GrupoFormatoContable", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public NaturalezaFormatoContable As New SqlParameter("@NaturalezaFormatoContable", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public EstadoFormatoContable As New SqlParameter("@EstadoFormatoContable", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public Descripcion1FormatoContable As New SqlParameter("@Descripcion1FormatoContable", SqlDbType.VarChar, 100, ParameterDirection.Input.ToString)
    Public ImporteSolesFormatoContable As New SqlParameter("@ImporteSolesFormatoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public ImporteDolaresFormatoContable As New SqlParameter("@ImporteDolaresFormatoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public ImporteEurosFormatoContable As New SqlParameter("@ImporteEurosFormatoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Saldo Contable"
      Public ClaveSaldoContable As New SqlParameter("@ClaveSaldoContable", SqlDbType.VarChar, 17, ParameterDirection.Input.ToString)
    Public CodigoFormato As New SqlParameter("@CodigoFormato", SqlDbType.VarChar, 10, ParameterDirection.Input.ToString)
    Public MesCreadoSaldoContable As New SqlParameter("@MesCreadoSaldoContable", SqlDbType.VarChar, 2, ParameterDirection.Input.ToString)
    Public DebeS00SaldoContable As New SqlParameter("@DebeS00SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public DebeS01SaldoContable As New SqlParameter("@DebeS01SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public DebeS02SaldoContable As New SqlParameter("@DebeS02SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public DebeS03SaldoContable As New SqlParameter("@DebeS03SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public DebeS04SaldoContable As New SqlParameter("@DebeS04SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public DebeS05SaldoContable As New SqlParameter("@DebeS05SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public DebeS06SaldoContable As New SqlParameter("@DebeS06SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public DebeS07SaldoContable As New SqlParameter("@DebeS07SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public DebeS08SaldoContable As New SqlParameter("@DebeS08SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public DebeS09SaldoContable As New SqlParameter("@DebeS09SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public DebeS10SaldoContable As New SqlParameter("@DebeS10SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public DebeS11SaldoContable As New SqlParameter("@DebeS11SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public DebeS12SaldoContable As New SqlParameter("@DebeS12SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public DebeS13SaldoContable As New SqlParameter("@DebeS13SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public DebeS14SaldoContable As New SqlParameter("@DebeS14SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public DebeS15SaldoContable As New SqlParameter("@DebeS15SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public HabeS00SaldoContable As New SqlParameter("@HabeS00SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public HabeS01SaldoContable As New SqlParameter("@HabeS01SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public HabeS02SaldoContable As New SqlParameter("@HabeS02SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public HabeS03SaldoContable As New SqlParameter("@HabeS03SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public HabeS04SaldoContable As New SqlParameter("@HabeS04SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public HabeS05SaldoContable As New SqlParameter("@HabeS05SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public HabeS06SaldoContable As New SqlParameter("@HabeS06SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public HabeS07SaldoContable As New SqlParameter("@HabeS07SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public HabeS08SaldoContable As New SqlParameter("@HabeS08SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public HabeS09SaldoContable As New SqlParameter("@HabeS09SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public HabeS10SaldoContable As New SqlParameter("@HabeS10SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public HabeS11SaldoContable As New SqlParameter("@HabeS11SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public HabeS12SaldoContable As New SqlParameter("@HabeS12SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public HabeS13SaldoContable As New SqlParameter("@HabeS13SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public HabeS14SaldoContable As New SqlParameter("@HabeS14SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public HabeS15SaldoContable As New SqlParameter("@HabeS15SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public DebeD00SaldoContable As New SqlParameter("@DebeD00SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public DebeD01SaldoContable As New SqlParameter("@DebeD01SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public DebeD02SaldoContable As New SqlParameter("@DebeD02SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public DebeD03SaldoContable As New SqlParameter("@DebeD03SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public DebeD04SaldoContable As New SqlParameter("@DebeD04SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public DebeD05SaldoContable As New SqlParameter("@DebeD05SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public DebeD06SaldoContable As New SqlParameter("@DebeD06SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public DebeD07SaldoContable As New SqlParameter("@DebeD07SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public DebeD08SaldoContable As New SqlParameter("@DebeD08SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public DebeD09SaldoContable As New SqlParameter("@DebeD09SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public DebeD10SaldoContable As New SqlParameter("@DebeD10SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public DebeD11SaldoContable As New SqlParameter("@DebeD11SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public DebeD12SaldoContable As New SqlParameter("@DebeD12SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public DebeD13SaldoContable As New SqlParameter("@DebeD13SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public DebeD14SaldoContable As New SqlParameter("@DebeD14SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public DebeD15SaldoContable As New SqlParameter("@DebeD15SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public HabeD00SaldoContable As New SqlParameter("@HabeD00SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public HabeD01SaldoContable As New SqlParameter("@HabeD01SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public HabeD02SaldoContable As New SqlParameter("@HabeD02SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public HabeD03SaldoContable As New SqlParameter("@HabeD03SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public HabeD04SaldoContable As New SqlParameter("@HabeD04SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public HabeD05SaldoContable As New SqlParameter("@HabeD05SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public HabeD06SaldoContable As New SqlParameter("@HabeD06SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public HabeD07SaldoContable As New SqlParameter("@HabeD07SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public HabeD08SaldoContable As New SqlParameter("@HabeD08SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public HabeD09SaldoContable As New SqlParameter("@HabeD09SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public HabeD10SaldoContable As New SqlParameter("@HabeD10SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public HabeD11SaldoContable As New SqlParameter("@HabeD11SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public HabeD12SaldoContable As New SqlParameter("@HabeD12SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public HabeD13SaldoContable As New SqlParameter("@HabeD13SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public HabeD14SaldoContable As New SqlParameter("@HabeD14SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public HabeD15SaldoContable As New SqlParameter("@HabeD15SaldoContable", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public EstadoSaldoContable As New SqlParameter("@EstadoSaldoContable", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa SaldosBancarios"
    Public ClaveSaldosBancarios As New SqlParameter("@ClaveSaldosbancarios", SqlDbType.VarChar, 17, ParameterDirection.Input.ToString)
    Public IngresosSolCuentaBanco As New SqlParameter("@IngresosSolCuentaBanco", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public SalidasSolCuentaBanco As New SqlParameter("@SalidasSolCuentaBanco", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public SaldoMesSolCuentaBanco As New SqlParameter("@SaldoMesSolCuentaBanco", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public IngresosDolCuentaBanco As New SqlParameter("@IngresosDolCuentaBanco", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public SalidasDolCuentaBanco As New SqlParameter("@SalidasDolCuentaBanco", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public SaldoMesDolCuentaBanco As New SqlParameter("@SaldoMesDolCuentaBanco", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public IngresosEurCuentaBanco As New SqlParameter("@IngresosEurCuentaBanco", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public SalidasEurCuentaBanco As New SqlParameter("@SalidasEurCuentaBanco", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public SaldoMesEurCuentaBanco As New SqlParameter("@SaldoMesEurCuentaBanco", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public IngresosSolAntCuentaBanco As New SqlParameter("@IngresosSolAntCuentaBanco", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public SalidasSolAntCuentaBanco As New SqlParameter("@SalidasSolAntCuentaBanco", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public SaldoMesSolAntCuentaBanco As New SqlParameter("@SaldoMesSolAntCuentaBanco", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public IngresosDolAntCuentaBanco As New SqlParameter("@IngresosDolAntCuentaBanco", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public SalidasDolAntCuentaBanco As New SqlParameter("@SalidasDolAntCuentaBanco", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public SaldoMesDolAntCuentaBanco As New SqlParameter("@SaldoMesDolAntCuentaBanco", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public IngresosEurAntCuentaBanco As New SqlParameter("@IngresosEurAntCuentaBanco", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public SalidasEurAntCuentaBanco As New SqlParameter("@SalidasEurAntCuentaBanco", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public SaldoMesEurAntCuentaBanco As New SqlParameter("@SaldoMesEurAntCuentaBanco", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public MesCuentaBanco As New SqlParameter("@MesCuentaBanco", SqlDbType.VarChar, 2, ParameterDirection.Input.ToString)
    Public AnoCuentaBanco As New SqlParameter("@AnoCuentaBanco", SqlDbType.VarChar, 4, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa CuentaCorriente"
    Public ClaveCuentaCorriente As New SqlParameter("@ClaveCuentaCorriente", SqlDbType.VarChar, 40, ParameterDirection.Input.ToString)
    Public ClaveDocumentoCuentaCorriente As New SqlParameter("@ClaveDocumentoCuentaCorriente", SqlDbType.VarChar, 40, ParameterDirection.Input.ToString)
    Public ImporteOriginalCuentaCorriente As New SqlParameter("@ImporteOriginalCuentaCorriente", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public ImportePagadoCuentaCorriente As New SqlParameter("@ImportePagadoCuentaCorriente", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public SaldoCuentaCorriente As New SqlParameter("@SaldoCuentaCorriente", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public FechaVctoDocumneto As New SqlParameter("@FechaVctoDocumento", SqlDbType.VarChar, 10, ParameterDirection.Input.ToString)
    Public EstadoCuentaCorriente As New SqlParameter("@EstadoCuentaCorriente", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public VentaTipoCambioOriginal As New SqlParameter("@VentaTipoCambioOriginal", SqlDbType.Decimal, 6, ParameterDirection.Input.ToString)
    Public VentaEurTipoCambioOriginal As New SqlParameter("@VentaEurTipoCambioOriginal", SqlDbType.Decimal, 6, ParameterDirection.Input.ToString)
    Public ClaveNotaCredito As New SqlParameter("@ClaveNotaCredito", SqlDbType.VarChar, 40, ParameterDirection.Input.ToString)
    Public ValorNotaCredito As New SqlParameter("@ValorNotaCredito", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public FlagSaldoNegativo As New SqlParameter("@FlagSaldoNegativo", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa Almacen"
    Public CodigoAlmacen As New SqlParameter("@CodigoAlmacen", SqlDbType.VarChar, 20, ParameterDirection.Input.ToString)
    Public NombreAlmacen As New SqlParameter("@NombreAlmacen", SqlDbType.VarChar, 100, ParameterDirection.Input.ToString)
    Public ColorAlmacen As New SqlParameter("@ColorAlmacen", SqlDbType.VarChar, 20, ParameterDirection.Input.ToString)
    Public MedidasAlmacen As New SqlParameter("@MedidasAlmacen", SqlDbType.VarChar, 20, ParameterDirection.Input.ToString)
    Public SerieAlmacen As New SqlParameter("@SerieAlmacen", SqlDbType.VarChar, 20, ParameterDirection.Input.ToString)
    Public MarcaAlmacen As New SqlParameter("@MarcaAlmacen", SqlDbType.VarChar, 20, ParameterDirection.Input.ToString)
    Public EstadoAlmacen As New SqlParameter("@EstadoAlmacen", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)

#End Region

#Region "Parametros Pa Permiso"
    Public CodigoVentana As New SqlParameter("@CodigoVentana", SqlDbType.VarChar, 30, ParameterDirection.Input.ToString)
    Public NombreVentana As New SqlParameter("@NombreVentana", SqlDbType.VarChar, 50, ParameterDirection.Input.ToString)
    Public CodigoOpcion As New SqlParameter("@CodigoOpcion", SqlDbType.VarChar, 2, ParameterDirection.Input.ToString)
    Public NombreOpcion As New SqlParameter("@NombreOpcion", SqlDbType.VarChar, 30, ParameterDirection.Input.ToString)
    Public OpcionPermiso As New SqlParameter("@OpcionPermiso", SqlDbType.Int, 2, ParameterDirection.Input.ToString)

#End Region

#Region "Parametros Pa Periodo"
    Public ClavePeriodo As New SqlParameter("@ClavePeriodo", SqlDbType.VarChar, 10, ParameterDirection.Input.ToString)
    Public CodigoPeriodo As New SqlParameter("@CodigoPeriodo", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public CMesPeriodo As New SqlParameter("@CMesPeriodo", SqlDbType.VarChar, 2, ParameterDirection.Input.ToString)
    Public CEstadoPeriodo As New SqlParameter("@CEstadoPeriodo", SqlDbType.Char, 1, ParameterDirection.Input.ToString)
    Public ResultadoMes As New SqlParameter("ResultadoMes", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
    Public ResultadoAcumulado As New SqlParameter("ResultadoAcumulado", SqlDbType.Decimal, 12, ParameterDirection.Input.ToString)
#End Region


#Region "Parametros Pa Area"
    Public ClaveArea As New SqlParameter("@ClaveArea", SqlDbType.VarChar, 9, ParameterDirection.Input.ToString)
    Public CodigoArea As New SqlParameter("@CodigoArea", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public NombreArea As New SqlParameter("@NombreArea", SqlDbType.VarChar, 100, ParameterDirection.Input.ToString)
    Public EstadoArea As New SqlParameter("@EstadoArea", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa FlujoCaja"
    Public ClaveFlujoCaja As New SqlParameter("@ClaveFlujoCaja", SqlDbType.VarChar, 9, ParameterDirection.Input.ToString)
    Public CodigoFlujoCaja As New SqlParameter("@CodigoFlujoCaja", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public NombreFlujoCaja As New SqlParameter("@NombreFlujoCaja", SqlDbType.VarChar, 100, ParameterDirection.Input.ToString)
    Public EstadoFlujoCaja As New SqlParameter("@EstadoFlujoCaja", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa IngresoEgreso1"
    Public ClaveIngresoEgreso As New SqlParameter("@ClaveIngresoEgreso", SqlDbType.VarChar, 9, ParameterDirection.Input.ToString)
    Public CodigoIngresoEgreso As New SqlParameter("@CodigoIngresoEgreso", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public NombreIngresoEgreso As New SqlParameter("@NombreIngresoEgreso", SqlDbType.VarChar, 100, ParameterDirection.Input.ToString)
    Public EstadoIngresoEgreso As New SqlParameter("@EstadoIngresoEgreso", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa Centro costo"
    Public ClaveCentroCosto As New SqlParameter("@ClaveCentroCosto", SqlDbType.VarChar, 9, ParameterDirection.Input.ToString)
    Public CodigoCentroCosto As New SqlParameter("@CodigoCentroCosto", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public NombreCentroCosto As New SqlParameter("@NombreCentroCosto", SqlDbType.VarChar, 100, ParameterDirection.Input.ToString)
    Public EstadoCentroCosto As New SqlParameter("@EstadoCentroCosto", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa SumaIngEgr"
    Public ClaveSumaIngEgr As New SqlParameter("@ClaveSumaIngEgr", SqlDbType.VarChar, 9, ParameterDirection.Input.ToString)
    Public CodigoSumaIngEgr As New SqlParameter("@CodigoSumaIngEgr", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    Public NombreSumaIngEgr As New SqlParameter("@NombreSumaIngEgr", SqlDbType.VarChar, 100, ParameterDirection.Input.ToString)
    Public EstadoSumaIngEgr As New SqlParameter("@EstadoSumaIngEgr", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa CuentaCorriente Historico"
    Public ClaveCuentaCorrienteHistorico As New SqlParameter("@ClaveCuentaCorrienteHistorico", SqlDbType.VarChar, 40, ParameterDirection.Input.ToString)
    Public EstadoCuentaCorrienteHistorico As New SqlParameter("@EstadoCuentaCorrienteHistorico", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa Proyecto"
    Public CodigoProHijo As New SqlParameter("@CodigoProHijo", SqlDbType.VarChar, 30, ParameterDirection.Input.ToString)
    Public DescripcionProHijo As New SqlParameter("@DescripcionProHijo", SqlDbType.VarChar, 200, ParameterDirection.Input.ToString)
    Public TipoProHijo As New SqlParameter("@TipoProHijo", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public CodigoProPadre As New SqlParameter("@CodigoProPadre", SqlDbType.VarChar, 30, ParameterDirection.Input.ToString)
    Public OfertaGenera As New SqlParameter("@OfertaGenera", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public ProyectoGenera As New SqlParameter("@ProyectoGenera", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public CalculoHoras As New SqlParameter("@CalculoHoras", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa Segmento"
    Public CodigoSegmento As New SqlParameter("@CodigoSegmento", SqlDbType.VarChar, 5, ParameterDirection.Input.ToString)
    'Public NombreDistrito As New SqlParameter("@ NombreDistrito", SqlDbType.VarChar, 3, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa Interno"
    Public CodigoInterno As New SqlParameter("@CodigoInterno", SqlDbType.VarChar, 6, ParameterDirection.Input.ToString)
    'Public NombreDistrito As New SqlParameter("@ NombreDistrito", SqlDbType.VarChar, 3, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa Afp"
    Public CodigoAfp As New SqlParameter("@CodigoAfp", SqlDbType.VarChar, 3, ParameterDirection.Input.ToString)
    Public NombreAfp As New SqlParameter("@NombreAfp", SqlDbType.VarChar, 50, ParameterDirection.Input.ToString)
    Public PorCentajeFondoAfp As New SqlParameter("@PorCentajeFondoAfp", SqlDbType.Decimal, 10, ParameterDirection.Input.ToString)
    Public PorCentajeSeguroAfp As New SqlParameter("@PorCentajeSeguroAfp", SqlDbType.Decimal, 10, ParameterDirection.Input.ToString)
    Public PorCentajeSobreRemuneracionAfp As New SqlParameter("@PorCentajeSobreRemuneracionAfp", SqlDbType.Decimal, 10, ParameterDirection.Input.ToString)
    Public PorCentajeEspecialAfp As New SqlParameter("@PorCentajeEspecialAfp", SqlDbType.Decimal, 10, ParameterDirection.Input.ToString)
    Public EstadoAfp As New SqlParameter("@EstadoAfp", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
#End Region

#Region "Parametros Pa GastoReparable"
    Public ClaveGastoReparable As New SqlParameter("@ClaveGastoReparable", SqlDbType.VarChar, 11, ParameterDirection.Input.ToString)
    Public CodigoGastoReparable As New SqlParameter("@CodigoGastoReparable", SqlDbType.VarChar, 8, ParameterDirection.Input.ToString)
    Public NombreGastoReparable As New SqlParameter("@NombreGastoReparable", SqlDbType.VarChar, 100, ParameterDirection.Input.ToString)
    Public Almacen As New SqlParameter("@Almacen", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
    Public Unidad As New SqlParameter("@Unidad", SqlDbType.VarChar, 3, ParameterDirection.Input.ToString)
    Public EstadoGastoReparable As New SqlParameter("@EstadoGastoReparable", SqlDbType.VarChar, 1, ParameterDirection.Input.ToString)
#End Region

End Class

