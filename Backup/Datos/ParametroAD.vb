Imports Entidad
Public Class ParametroAD
    Private Sql As New SqlDatos
    Private Lista As New List(Of SuperEntidad)
    Private obj As New SuperEntidad
    Private Campo As New CamposEntidad
    Private Par As New ParametroSql
    Sub SetParametros(ByRef ent As SuperEntidad)
        '//
        Sql.AsignarParametro(Par.IgvPar, ent.IgvPar)
        Sql.AsignarParametro(Par.CuentaTransferencia, ent.CuentaTransferencia)
        Sql.AsignarParametro(Par.CuentaIgv, ent.CuentaIgv)
        Sql.AsignarParametro(Par.PorGastosAdministrativos, ent.PorGastosAdministrativos)
        Sql.AsignarParametro(Par.PorGastosGenerales, ent.PorGastosGenerales)
        Sql.AsignarParametro(Par.PorUtilidad, ent.PorUtilidad)
        Sql.AsignarParametro(Par.PorRetencionHonorario, ent.PorRetencionHonorario)
        Sql.AsignarParametro(Par.DigitosCuentaAnalitica, ent.DigitosCuentaAnalitica)
        Sql.AsignarParametro(Par.CuentaHonorarioNeto, ent.CuentaHonorarioNeto)
        Sql.AsignarParametro(Par.CuentaHonorarioRetencion, ent.CuentaHonorarioRetencion)
        Sql.AsignarParametro(Par.CuentaAutomatica, ent.CuentaAutomatica)
        Sql.AsignarParametro(Par.CuentaGananciaDC, ent.CuentaGananciaDC)
        Sql.AsignarParametro(Par.CuentaPerdidaDC, ent.CuentaPerdidaDC)
        Sql.AsignarParametro(Par.PorcentajeDsctoAfp2014, ent.PorcentajeDsctoAfp2014)
        Sql.AsignarParametro(Par.PorcentajeDsctoAfp2015, ent.PorcentajeDsctoAfp2015)
        Sql.AsignarParametro(Par.PorcentajeDsctoAfp2016, ent.PorcentajeDsctoAfp2016)
        Sql.AsignarParametro(Par.PorcentajeDsctoSnp2014, ent.PorcentajeDsctoSnp2014)
        Sql.AsignarParametro(Par.PorcentajeDsctoSnp2015, ent.PorcentajeDsctoSnp2015)
        Sql.AsignarParametro(Par.PorcentajeDsctoSnp2016, ent.PorcentajeDsctoSnp2016)
        Sql.AsignarParametro(Par.CodigoOrigenVentas, ent.CodigoOrigenVentas)
        Sql.AsignarParametro(Par.CodigoFileVentas, ent.CodigoFileVentas)
        Sql.AsignarParametro(Par.CodigoOrigenDiario, ent.CodigoOrigenDiario)
        Sql.AsignarParametro(Par.CodigoFileDiario, ent.CodigoFileDiario)
        Sql.AsignarParametro(Par.Cuenta75ValorVentaEmpresa, ent.Cuenta75ValorVentaEmpresa)
        Sql.AsignarParametro(Par.Cuenta16PrecioVentaEmpresa, ent.Cuenta16PrecioVentaEmpresa)
        Sql.AsignarParametro(Par.CuentaIgvEmpresa, ent.CuentaIgvEmpresa)
        Sql.AsignarParametro(Par.CuentaAfp, ent.CuentaAfp)
        Sql.AsignarParametro(Par.CuentaSnp, ent.CuentaSnp)
        Sql.AsignarParametro(Par.CuentaValorVenta, ent.CuentaValorVenta)
        Sql.AsignarParametro(Par.CuentaPrecioVenta, ent.CuentaPrecioVenta)
        Sql.AsignarParametro(Par.CuentaClase8Cierre, ent.CuentaClase8Cierre)
        Sql.AsignarParametro(Par.CuentaGananciaCierre, ent.CuentaGananciaCierre)
        Sql.AsignarParametro(Par.CuentaPerdidaCierre, ent.CuentaPerdidaCierre)
        Sql.AsignarParametro(Par.PorcentajeImpuestoRenta, ent.PorcentajeImpuestoRenta)
        Sql.AsignarParametro(Par.CCodigoOrigenRegistroVentasxx, ent.CCodigoOrigenRegistroVentas)
        Sql.AsignarParametro(Par.CCodigoFileRegistroVentas, ent.CCodigoFileRegistroVentas)
        Sql.AsignarParametro(Par.CuentaCuotaOrdinaria, ent.CuentaCuotaOrdinaria)
        Sql.AsignarParametro(Par.CuentaCuotaSupervisionYProyectos, ent.CuentaCuotaSupervisionYProyectos)
        Sql.AsignarParametro(Par.CuentaCuotaAgua, ent.CuentaCuotaAgua)
        Sql.AsignarParametro(Par.CuentaCuotaElectricidad, ent.CuentaCuotaElectricidad)
        Sql.AsignarParametro(Par.CuentaCuotaIngreso, ent.CuentaCuotaIngreso)
        Sql.AsignarParametro(Par.CuentaCuotaExtraordinaria, ent.CuentaCuotaExtraordinaria)
        Sql.AsignarParametro(Par.CuentaCuotaMoras, ent.CuentaCuotaMoras)
        Sql.AsignarParametro(Par.CuentaMontoTotalCuotas, ent.CuentaMontoTotalCuotas)

        Select Case ent.EstadoRegistro
            Case "Activo"
                ent.EstadoRegistro = "1"
            Case "Desactivo"
                ent.EstadoRegistro = "0"
        End Select
        Sql.AsignarParametro(Par.EstadoRegistro, ent.EstadoRegistro)
        Sql.AsignarParametro(Par.EliminadoRegistro, ent.EliminadoRegistro)
        Sql.AsignarParametro(Par.CodigoUsuarioAgrega, ent.CodigoUsuarioAgrega)
        Sql.AsignarParametro(Par.NombreUsuarioAgrega, ent.NombreUsuarioAgrega)
        Sql.AsignarParametro(Par.FechaAgrega, ent.FechaAgrega)
        Sql.AsignarParametro(Par.CodigoUsuarioModifica, ent.CodigoUsuarioModifica)
        Sql.AsignarParametro(Par.nombreUsuarioModifica, ent.NombreUsuarioModifica)
        Sql.AsignarParametro(Par.FechaModifica, ent.FechaModifica)

        '\\
    End Sub

    Function Objeto(ByRef iDr As IDataReader) As SuperEntidad
        '//
        Dim objEnc As New SuperEntidad

        objEnc.IgvPar = CType(iDr(Campo.IgvPar).ToString, Decimal)
        objEnc.CuentaTransferencia = iDr(Campo.CtaTrans).ToString
        objEnc.CuentaIgv = iDr(Campo.CtaIgv).ToString
        objEnc.PorGastosAdministrativos = CType(iDr(Campo.PorGstAdmi).ToString, Decimal)
        objEnc.PorGastosGenerales = CType(iDr(Campo.PorGstGene).ToString, Decimal)
        objEnc.PorUtilidad = CType(iDr(Campo.PorUtil).ToString, Decimal)
        objEnc.PorRetencionHonorario = CType(iDr(Campo.PorRetHon).ToString, Decimal)
        objEnc.DigitosCuentaAnalitica = iDr(Campo.DigCtaAna).ToString
        objEnc.CuentaHonorarioNeto = iDr(Campo.CtaHonNet).ToString
        objEnc.CuentaHonorarioRetencion = iDr(Campo.CtaHonRet).ToString
        objEnc.CuentaAutomatica = iDr(Campo.CtaAuto).ToString
        objEnc.CuentaGananciaDC = iDr(Campo.CtaGanDc).ToString
        objEnc.CuentaPerdidaDC = iDr(Campo.CtaPerDc).ToString
        objEnc.PorcentajeDsctoAfp2014 = CType(iDr(Campo.PorDesAfp2014).ToString, Decimal)
        objEnc.PorcentajeDsctoAfp2015 = CType(iDr(Campo.PorDesAfp2015).ToString, Decimal)
        objEnc.PorcentajeDsctoAfp2016 = CType(iDr(Campo.PorDesAfp2016).ToString, Decimal)
        objEnc.PorcentajeDsctoSnp2014 = CType(iDr(Campo.PorDesSnp2014).ToString, Decimal)
        objEnc.PorcentajeDsctoSnp2015 = CType(iDr(Campo.PorDesSnp2015).ToString, Decimal)
        objEnc.PorcentajeDsctoSnp2016 = CType(iDr(Campo.PorDesSnp2016).ToString, Decimal)
        objEnc.CuentaAfp = iDr(Campo.CtaAfp).ToString
        objEnc.CuentaSnp = iDr(Campo.CtaSnp).ToString
        objEnc.CodigoOrigenVentas = iDr(Campo.CodOriVta).ToString
        objEnc.CodigoFileVentas = iDr(Campo.CodFilVta).ToString
        objEnc.CodigoOrigenDiario = iDr(Campo.CodOriDia).ToString
        objEnc.CodigoFileDiario = iDr(Campo.CodFilDia).ToString
        objEnc.Cuenta16PrecioVentaEmpresa = iDr(Campo.Cta16PreVtaEmp).ToString
        objEnc.Cuenta75ValorVentaEmpresa = iDr(Campo.Cta75ValVtaEmp).ToString
        objEnc.CuentaIgvEmpresa = iDr(Campo.CtaIgvEmp).ToString
        objEnc.CuentaValorVenta = iDr(Campo.CtaValVta).ToString
        objEnc.CuentaPrecioVenta = iDr(Campo.CtaPreVta).ToString
        objEnc.CuentaClase8Cierre = iDr(Campo.CtaCla8Cie).ToString
        objEnc.CuentaGananciaCierre = iDr(Campo.CtaGanCie).ToString
        objEnc.CuentaPerdidaCierre = iDr(Campo.CtaPerCie).ToString
        objEnc.PorcentajeImpuestoRenta = CType(iDr(Campo.PorImpRen).ToString, Decimal)
        objEnc.CCodigoOrigenRegistroVentas = iDr(Campo.CCodOriRegVta).ToString
        objEnc.CCodigoFileRegistroVentas = iDr(Campo.CCodFilRegVta).ToString
        objEnc.CuentaMontoTotalCuotas = iDr(Campo.CtaMonTotCuo).ToString
        objEnc.CuentaCuotaOrdinaria = iDr(Campo.CtaCuoOrd).ToString
        objEnc.CuentaCuotaSupervisionYProyectos = iDr(Campo.CtaCuoSupYPro).ToString
        objEnc.CuentaCuotaAgua = iDr(Campo.CtaCuoAgu).ToString
        objEnc.CuentaCuotaElectricidad = iDr(Campo.CtaCuoEle).ToString
        objEnc.CuentaCuotaIngreso = iDr(Campo.CtaCuoIng).ToString
        objEnc.CuentaCuotaExtraordinaria = iDr(Campo.CtaCuoExt).ToString
        objEnc.CuentaCuotaMoras = iDr(Campo.CtaCuoMor).ToString

        'estado
        If iDr(Campo.EstReg).ToString = "1" Then
            objEnc.EstadoRegistro = "Activo"
        Else
            objEnc.EstadoRegistro = "Desactivo"
        End If
        objEnc.EliminadoRegistro = iDr(Campo.EliReg).ToString
        objEnc.CodigoUsuarioAgrega = iDr(Campo.CodUsuAgr).ToString
        objEnc.NombreUsuarioAgrega = iDr(Campo.NomUsuAgr).ToString
        objEnc.FechaAgrega = CType(iDr(Campo.FechaAgr), DateTime)
        objEnc.CodigoUsuarioModifica = iDr(Campo.CodUsuMod).ToString
        objEnc.NombreUsuarioModifica = iDr(Campo.NomUsuMod).ToString
        objEnc.FechaModifica = CType(iDr(Campo.FechaMod), DateTime)
        'especial
        objEnc.CampoCursor = iDr(Campo.IgvPar).ToString
        Return objEnc
        '\\
    End Function

    Sub SpModificarParametro(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpModificarParametro")
            '/Asignar Parametros
            Me.SetParametros(ent)
            '/Ejecutar sin resultado
            Sql.EjecutarSinResultado()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Sql.Desconectar()
        End Try
    End Sub

    Function SpBuscarRegistroConUnaCondicion(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpBuscarRegistroConUnaCondicion")
            '/Asignar Parametros
            Sql.AsignarParametro(Par.Vista, ent.Vista)
            Sql.AsignarParametro(Par.DatoEliminado, ent.DatoEliminado)
            Sql.AsignarParametro(Par.DatoEstado, ent.DatoEstado)
            Sql.AsignarParametro(Par.CampoCondicion1, ent.CampoCondicion1)
            Sql.AsignarParametro(Par.DatoCondicion1, ent.DatoCondicion1)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Objeto Encontrado
                obj = Me.Objeto(iDr)
            End While
            Return obj
        Catch ex As Exception
            MsgBox(ex.Message) : Return obj
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function
End Class
