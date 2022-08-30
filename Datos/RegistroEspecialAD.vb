Imports Entidad
Imports ScriptBaseDatos
Public Class RegistroEspecialAD

    Private Sql As New SqlDatos
    Private Lista As New List(Of SuperEntidad)
    Private obj As New SuperEntidad
    Private Campo As New CamposEntidad
    Private Par As New ParametroSql

    Sub SetParametros(ByRef ent As SuperEntidad)
        '//Esto va al Sql a grabar

        Sql.AsignarParametro(Par.ClaveRegContabCabe, ent.ClaveRegContabCabe)
        Sql.AsignarParametro(Par.CodigoEmpresa, ent.CodigoEmpresa)
        Sql.AsignarParametro(Par.PeriodoRegContabCabe, ent.PeriodoRegContabCabe)
        Sql.AsignarParametro(Par.CodigoOrigen, ent.CodigoOrigen)
        Sql.AsignarParametro(Par.CodigoFile, ent.CodigoFile)
        Sql.AsignarParametro(Par.NumeroVoucherRegContabCabe, ent.NumeroVoucherRegContabCabe)
        Sql.AsignarParametro(Par.MonedaVoucherRegContabCabe, ent.MonedaVoucherRegContabCabe)
        Sql.AsignarParametro(Par.DiaVoucherRegContabCabe, ent.DiaVoucherRegContabCabe)
        Sql.AsignarParametro(Par.FechaVoucherRegContabCabe, ent.FechaVoucherRegContabCabe)
        Sql.AsignarParametro(Par.CodigoAuxiliar, ent.CodigoAuxiliar)
        Sql.AsignarParametro(Par.TipoDocumento, ent.TipoDocumento)
        Sql.AsignarParametro(Par.SerieDocumento, ent.SerieDocumento)
        Sql.AsignarParametro(Par.NumeroDocumento, ent.NumeroDocumento)
        Sql.AsignarParametro(Par.FechaDocumento, ent.FechaDocumento)
        Sql.AsignarParametro(Par.FechaVencimiento, ent.FechaVencimiento)
        Select Case ent.MonedaDocumento
            Case "US$"
                ent.MonedaDocumento = "1"
            Case "S/."
                ent.MonedaDocumento = "0"
            Case "EUR"
                ent.MonedaDocumento = "2"
        End Select
        Sql.AsignarParametro(Par.MonedaDocumento, ent.MonedaDocumento)
        Sql.AsignarParametro(Par.TipoDocumento1, ent.TipoDocumento1)
        Sql.AsignarParametro(Par.SerieDocumento1, ent.SerieDocumento1)
        Sql.AsignarParametro(Par.NumeroDocumento1, ent.NumeroDocumento1)
        Sql.AsignarParametro(Par.FechaDocumento1, ent.FechaDocumento1)

        Select Case ent.MonedaDocumento1
            Case "US$"
                ent.MonedaDocumento1 = "1"
            Case "S/."
                ent.MonedaDocumento1 = "0"
        End Select
        Sql.AsignarParametro(Par.MonedaDocumento1, ent.MonedaDocumento1)
        Sql.AsignarParametro(Par.VentaTipoCambio, ent.VentaTipoCambio)
        Sql.AsignarParametro(Par.VentaEurTipoCambio, ent.VentaEurTipoCambio)
        Sql.AsignarParametro(Par.IgvPar, ent.IgvPar)
        Sql.AsignarParametro(Par.ValorVtaRegContabCabe, ent.ValorVtaRegContabCabe)
        Sql.AsignarParametro(Par.IgvRegContabCabe, ent.IgvRegContabCabe)
        Sql.AsignarParametro(Par.ExoneradoRegContabCabe, ent.ExoneradoRegContabCabe)
        Sql.AsignarParametro(Par.PrecioVtaRegContabCabe, ent.PrecioVtaRegContabCabe)
        Sql.AsignarParametro(Par.ValorVtaSolRegContabCabe, ent.ValorVtaSolRegContabCabe)
        Sql.AsignarParametro(Par.IgvSolRegContabCabe, ent.IgvSolRegContabCabe)
        Sql.AsignarParametro(Par.ExoneradoSolRegContabCabe, ent.ExoneradoSolRegContabCabe)
        Sql.AsignarParametro(Par.PrecioVtaSolRegContabCabe, ent.PrecioVtaSolRegContabCabe)
        Sql.AsignarParametro(Par.GlosaRegContabCabe, ent.GlosaRegContabCabe)
        'Retencion
        Select Case ent.RetencionRegContabCabe
            Case "Si"
                ent.RetencionRegContabCabe = "1"
            Case "No"
                ent.RetencionRegContabCabe = "0"
        End Select
        Sql.AsignarParametro(Par.RetencionRegContabCabe, ent.RetencionRegContabCabe)
        Sql.AsignarParametro(Par.CodigoCuentaBanco, ent.CodigoCuentaBanco)
        Sql.AsignarParametro(Par.ImporteRegContabCabe, ent.ImporteRegContabCabe)
        'Detraccion
        Select Case ent.DetraccionRegContabCabe
            Case "Si"
                ent.DetraccionRegContabCabe = "1"
            Case "No"
                ent.DetraccionRegContabCabe = "0"
        End Select
        Sql.AsignarParametro(Par.DetraccionRegContabCabe, ent.DetraccionRegContabCabe)
        Sql.AsignarParametro(Par.NumeroPapeletaRegContabCabe, ent.NumeroPapeletaRegContabCabe)
        Sql.AsignarParametro(Par.FechaDetraccionRegContabCabe, ent.FechaDetraccionRegContabCabe)

        Sql.AsignarParametro(Par.CodigoModoPago, ent.CodigoModoPago)
        Sql.AsignarParametro(Par.DescripcionRegContabCabe, ent.DescripcionRegContabCabe)
        Sql.AsignarParametro(Par.CartaRegContabCabe, ent.CartaRegContabCabe)
        Sql.AsignarParametro(Par.VoucherIngresoRegContabCabe, ent.VoucherIngresoRegContabCabe)
        Sql.AsignarParametro(Par.EstadoRegContabCabe, ent.EstadoRegContabCabe)
        Sql.AsignarParametro(Par.SumaDebeRegContabCabe, ent.SumaDebeRegContabCabe)
        Sql.AsignarParametro(Par.SumaHaberRegContabCabe, ent.SumaHaberRegContabCabe)
        Sql.AsignarParametro(Par.UltimoCorrelativo, ent.UltimoCorrelativo)
        Sql.AsignarParametro(Par.Exporta, ent.Exporta)
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
        '//Lo que se trae del sql
        Dim objEnc As New SuperEntidad
        objEnc.CodigoEmpresa = iDr(Campo.CodEmp).ToString
        objEnc.RazonSocialEmpresa = iDr(Campo.RazSocEmp).ToString
        objEnc.PeriodoRegContabCabe = iDr(Campo.PeriodoRCC).ToString
        objEnc.CodigoOrigen = iDr(Campo.CodOriRC).ToString
        objEnc.NombreOrigen = iDr(Campo.NomOriRC).ToString
        objEnc.CodigoFile = iDr(Campo.CodFilRC).ToString
        objEnc.NombreFile = iDr(Campo.NomFilRC).ToString
        objEnc.NumeroVoucherRegContabCabe = iDr(Campo.NumVouRCC).ToString
        objEnc.ClaveRegContabCabe = iDr(Campo.ClaveRCC).ToString
        objEnc.MonedaVoucherRegContabCabe = iDr(Campo.MonVouRCC).ToString
        objEnc.DiaVoucherRegContabCabe = iDr(Campo.DiaVouRCC).ToString
        objEnc.FechaVoucherRegContabCabe = CType(iDr(Campo.FecVouRCC), DateTime)
        objEnc.CodigoAuxiliar = iDr(Campo.CodAux).ToString
        objEnc.DescripcionAuxiliar = iDr(Campo.DesAux).ToString
        objEnc.TipoDocumento = iDr(Campo.CodTipDoc).ToString
        objEnc.NombreDocumento = iDr(Campo.NomTipDoc).ToString
        objEnc.SerieDocumento = iDr(Campo.SerDoC).ToString
        objEnc.NumeroDocumento = iDr(Campo.NumDoc).ToString
        objEnc.FechaDocumento = CType(iDr(Campo.FecDoc), DateTime)
        objEnc.FechaVencimiento = CType(iDr(Campo.Fecvcto), DateTime)
        'Moneda documento
        Select Case iDr(Campo.MonDoc).ToString
            Case "0"
                objEnc.MonedaDocumento = "S/."
            Case "1"
                objEnc.MonedaDocumento = "US$"
            Case "2"
                objEnc.MonedaDocumento = "EUR"
        End Select
        objEnc.TipoDocumento1 = iDr(Campo.CodTipDoc1).ToString
        objEnc.NombreDocumento1 = iDr(Campo.NomTipDoc1).ToString
        objEnc.SerieDocumento1 = iDr(Campo.SerDoC1).ToString
        objEnc.NumeroDocumento1 = iDr(Campo.NumDoc1).ToString
        objEnc.FechaDocumento1 = iDr(Campo.FecDoc1).ToString
        'Moneda documento
        If iDr(Campo.MonDoc1).ToString = "1" Then
            objEnc.MonedaDocumento1 = "US$"
        Else
            objEnc.MonedaDocumento1 = "S/."
        End If

        'Detraccion
        If iDr(Campo.DetraRCC).ToString = "1" Then
            objEnc.DetraccionRegContabCabe = "Si"
        Else
            objEnc.DetraccionRegContabCabe = "No"
        End If
        objEnc.VentaTipoCambio = CType(iDr(Campo.VenTipCam), Decimal)
        objEnc.VentaEurTipoCambio = CType(iDr(Campo.VenEurTipCam), Decimal)
        objEnc.IgvPar = CType(iDr(Campo.IgvPar), Decimal)
        'Retencion
        If iDr(Campo.RetenRCC).ToString = "1" Then
            objEnc.RetencionRegContabCabe = "Si"
        Else
            objEnc.RetencionRegContabCabe = "No"
        End If
        objEnc.NumeroPapeletaRegContabCabe = iDr(Campo.NumPapeRCC).ToString
        objEnc.FechaDetraccionRegContabCabe = iDr(Campo.FechDetraRCC).ToString
        objEnc.IgvPar = Math.Abs(CType(iDr(Campo.IgvPar), Decimal))
        objEnc.ValorVtaRegContabCabe = Math.Abs(CType(iDr(Campo.ValVtaRCC), Decimal))
        objEnc.IgvRegContabCabe = Math.Abs(CType(iDr(Campo.IgvRCC), Decimal))
        objEnc.ExoneradoRegContabCabe = Math.Abs(CType(iDr(Campo.ExoneradoRCC), Decimal))
        objEnc.PrecioVtaRegContabCabe = Math.Abs(CType(iDr(Campo.PreVtaRCC), Decimal))
        objEnc.ValorVtaSolRegContabCabe = Math.Abs(CType(iDr(Campo.ValVtasRCC), Decimal))
        objEnc.IgvSolRegContabCabe = Math.Abs(CType(iDr(Campo.IgvsRCC), Decimal))
        objEnc.ExoneradoSolRegContabCabe = Math.Abs(CType(iDr(Campo.ExoneradoSRCC), Decimal))
        objEnc.PrecioVtaSolRegContabCabe = Math.Abs(CType(iDr(Campo.PreVtasRCC), Decimal))
        objEnc.GlosaRegContabCabe = iDr(Campo.GlosaRCC).ToString
        objEnc.ImporteRegContabCabe = Math.Abs(CType(iDr(Campo.ImpRCC), Decimal))
        objEnc.CodigoCuentaBanco = iDr(Campo.CodCtaBco).ToString
        objEnc.NombreCuentaPcge = iDr(Campo.NomCtaPcge).ToString
        objEnc.CartaRegContabCabe = iDr(Campo.CarRCC).ToString
        objEnc.DescripcionRegContabCabe = iDr(Campo.DesRCC).ToString
        objEnc.VoucherIngresoRegContabCabe = iDr(Campo.VouIngRCC).ToString
        objEnc.SumaDebeRegContabCabe = CType(iDr(Campo.SumDebRCC), Decimal)
        objEnc.SumaHaberRegContabCabe = CType(iDr(Campo.SumHabRCC), Decimal)
        objEnc.DiferenciaDH = CType(iDr(Campo.SumDebRCC), Decimal) - CType(iDr(Campo.SumHabRCC), Decimal)
        objEnc.UltimoCorrelativo = iDr(Campo.UltCorre).ToString
        'Concepto
        'objEnc.CodigoCuentaBanco = iDr(Campo.CodCtaBco).ToString
        'objEnc.NombreConcepto = iDr(Campo.NomConc).ToString
        'objEnc.CuentaRegContab = iDr(Campo.CuenRC).ToString
        'objEnc.NombreCuentaRegContab = iDr(Campo.NomCuenRC).ToString

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
        objEnc.Exporta = iDr(Campo.Exp).ToString

        objEnc.CodigoModoPago = iDr(Campo.CodModPag).ToString
        objEnc.EstadoRegContabCabe = iDr(Campo.EstRCC).ToString
        'Adicional para exportar
        'objEnc.FechaVoucherRegistroCompra = CType(iDr(Campo.FecVouRCC), DateTime).ToShortDateString
        'objEnc.FechaDocumentoRegistroCompra = CType(iDr(Campo.FecDoc), DateTime).ToShortDateString

        'especial
        objEnc.CampoCursor = iDr(Campo.ClaveRCC).ToString
        Return objEnc
        '\\
    End Function

    Function SpAutogenerarFileManual(ByRef ent As SuperEntidad) As String
        '//
        Dim codigo As String = ""
        Try

            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpAutogenerarFileManual")
            Sql.AsignarParametro(Par.PeriodoRegContabCabe, ent.PeriodoRegContabCabe)
            Sql.AsignarParametro(Par.CodigoFile, ent.CodigoFile)

            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                codigo = iDr(0).ToString
            End While
            Return codigo
        Catch ex As Exception
            MsgBox(ex.Message) : Return codigo
        Finally
            Sql.Desconectar()
        End Try
    End Function

    Sub SpNuevoRegistroEspecial(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpNuevoRegistroEspecial")
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

    Sub SpModificarRegistroEspecial(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpModificarRegistroEspecial")
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

    Sub SpEliminarRegistroEspecial(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpEliminarRegistroEspecial")
            '/Asignar Parametro
            Sql.AsignarParametro(Par.ClaveRegContabCabe, ent.ClaveRegContabCabe)
            '/Ejecutar sin resultado
            Sql.EjecutarSinResultado()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Sql.Desconectar()
        End Try
    End Sub

    Function SpObtenerRegistrosSinCondicion(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpObtenerRegistrosSinCondicion")
            '/Asignar Parametros
            Sql.AsignarParametro(Par.Vista, ent.Vista)
            Sql.AsignarParametro(Par.DatoEliminado, ent.DatoEliminado)
            Sql.AsignarParametro(Par.DatoEstado, ent.DatoEstado)
            Sql.AsignarParametro(Par.CampoOrden, ent.CampoOrden)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function

    Function SpObtenerRegistrosConUnaCondicion(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpObtenerRegistrosConUnaCondicion")
            '/Asignar Parametros
            Sql.AsignarParametro(Par.Vista, ent.Vista)
            Sql.AsignarParametro(Par.DatoEliminado, ent.DatoEliminado)
            Sql.AsignarParametro(Par.DatoEstado, ent.DatoEstado)
            Sql.AsignarParametro(Par.CampoCondicion1, ent.CampoCondicion1)
            Sql.AsignarParametro(Par.DatoCondicion1, ent.DatoCondicion1)
            Sql.AsignarParametro(Par.CampoOrden, ent.CampoOrden)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function

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

    Function SpObtenerRegistrosConDosCondicionUnaDesigualdad(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpObtenerRegistrosConDosCondicionUnaDesigualdad")
            '/Asignar Parametros
            Sql.AsignarParametro(Par.Vista, ent.Vista)
            Sql.AsignarParametro(Par.DatoEliminado, ent.DatoEliminado)
            Sql.AsignarParametro(Par.DatoEstado, ent.DatoEstado)
            Sql.AsignarParametro(Par.CampoCondicion1, ent.CampoCondicion1)
            Sql.AsignarParametro(Par.DatoCondicion1, ent.DatoCondicion1)
            Sql.AsignarParametro(Par.CampoCondicion2, ent.CampoCondicion2)
            Sql.AsignarParametro(Par.DatoCondicion2, ent.DatoCondicion2)
            Sql.AsignarParametro(Par.CampoCondicion3, ent.CampoCondicion3)
            Sql.AsignarParametro(Par.DatoCondicion3, ent.DatoCondicion3)
            Sql.AsignarParametro(Par.CampoOrden, ent.CampoOrden)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function

    Function SpObtenerRegistrosConTresCondicion(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpObtenerRegistrosConTresCondicion")
            '/Asignar Parametros
            Sql.AsignarParametro(Par.Vista, ent.Vista)
            Sql.AsignarParametro(Par.DatoEliminado, ent.DatoEliminado)
            Sql.AsignarParametro(Par.DatoEstado, ent.DatoEstado)
            Sql.AsignarParametro(Par.CampoCondicion1, ent.CampoCondicion1)
            Sql.AsignarParametro(Par.DatoCondicion1, ent.DatoCondicion1)
            Sql.AsignarParametro(Par.CampoCondicion2, ent.CampoCondicion2)
            Sql.AsignarParametro(Par.DatoCondicion2, ent.DatoCondicion2)
            Sql.AsignarParametro(Par.CampoCondicion3, ent.CampoCondicion3)
            Sql.AsignarParametro(Par.DatoCondicion3, ent.DatoCondicion3)
            Sql.AsignarParametro(Par.CampoOrden, ent.CampoOrden)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function

    Function SpObtenerRegistrosConCuatroCondicion(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpObtenerRegistrosConCuatroCondicion")
            '/Asignar Parametros
            Sql.AsignarParametro(Par.Vista, ent.Vista)
            Sql.AsignarParametro(Par.DatoEliminado, ent.DatoEliminado)
            Sql.AsignarParametro(Par.DatoEstado, ent.DatoEstado)
            Sql.AsignarParametro(Par.CampoCondicion1, ent.CampoCondicion1)
            Sql.AsignarParametro(Par.DatoCondicion1, ent.DatoCondicion1)
            Sql.AsignarParametro(Par.CampoCondicion2, ent.CampoCondicion2)
            Sql.AsignarParametro(Par.DatoCondicion2, ent.DatoCondicion2)
            Sql.AsignarParametro(Par.CampoCondicion3, ent.CampoCondicion3)
            Sql.AsignarParametro(Par.DatoCondicion3, ent.DatoCondicion3)
            Sql.AsignarParametro(Par.CampoCondicion4, ent.CampoCondicion4)
            Sql.AsignarParametro(Par.DatoCondicion4, ent.DatoCondicion4)
            Sql.AsignarParametro(Par.CampoOrden, ent.CampoOrden)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function


    Function SpObtenerRegistrosConDosCondicion(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpObtenerRegistrosConDosCondicion")
            '/Asignar Parametros
            Sql.AsignarParametro(Par.Vista, ent.Vista)
            Sql.AsignarParametro(Par.DatoEliminado, ent.DatoEliminado)
            Sql.AsignarParametro(Par.DatoEstado, ent.DatoEstado)
            Sql.AsignarParametro(Par.CampoCondicion1, ent.CampoCondicion1)
            Sql.AsignarParametro(Par.DatoCondicion1, ent.DatoCondicion1)
            Sql.AsignarParametro(Par.CampoCondicion2, ent.CampoCondicion2)
            Sql.AsignarParametro(Par.DatoCondicion2, ent.DatoCondicion2)
            Sql.AsignarParametro(Par.CampoOrden, ent.CampoOrden)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function

    Function SpBuscarRegistroConDosCondicion(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpBuscarRegistroConDosCondicion")
            '/Asignar Parametros
            Sql.AsignarParametro(Par.Vista, ent.Vista)
            Sql.AsignarParametro(Par.DatoEliminado, ent.DatoEliminado)
            Sql.AsignarParametro(Par.DatoEstado, ent.DatoEstado)
            Sql.AsignarParametro(Par.CampoCondicion1, ent.CampoCondicion1)
            Sql.AsignarParametro(Par.DatoCondicion1, ent.DatoCondicion1)
            Sql.AsignarParametro(Par.CampoCondicion2, ent.CampoCondicion2)
            Sql.AsignarParametro(Par.DatoCondicion2, ent.DatoCondicion2)
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



    Function SpObtenerRegistrosEntreFechas(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpObtenerRegistrosEntreFechas")
            '/Asignar Parametros
            Sql.AsignarParametro(Par.Vista, ent.Vista)
            Sql.AsignarParametro(Par.DatoEliminado, ent.DatoEliminado)
            Sql.AsignarParametro(Par.DatoEstado, ent.DatoEstado)
            Sql.AsignarParametro(Par.CampoFecha, ent.CampoFecha)
            Sql.AsignarParametro(Par.Desde, ent.Desde)
            Sql.AsignarParametro(Par.Hasta, ent.Hasta)
            Sql.AsignarParametro(Par.CampoOrden, ent.CampoOrden)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function

    Function SpObtenerRegistrosContablesEntreFechas(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpObtenerRegistrosContablesEntreFechas")
            '/Asignar Parametros
            Sql.AsignarParametro(Par.Vista, ent.Vista)
            Sql.AsignarParametro(Par.DatoEliminado, ent.DatoEliminado)
            Sql.AsignarParametro(Par.DatoEstado, ent.DatoEstado)
            Sql.AsignarParametro(Par.CampoCondicion1, ent.CampoCondicion1)
            Sql.AsignarParametro(Par.DatoCondicion1, ent.DatoCondicion1)
            Sql.AsignarParametro(Par.CampoFecha, ent.CampoFecha)
            Sql.AsignarParametro(Par.Desde, ent.Desde)
            Sql.AsignarParametro(Par.Hasta, ent.Hasta)
            Sql.AsignarParametro(Par.CampoOrden, ent.CampoOrden)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function

    Function ListarIngresosyEgresosXPeriodoYEmpresa(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("VsRegContabCabe")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.PeriodoRCC, SqlSelect.Operador.Igual, ent.PeriodoRegContabCabe)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, ent.CodigoEmpresa)
            sel.CondicionIn(SqlSelect.Reservada.Y, Campo.CodOriRC, "1,2")
            sel.Orden(Campo.ClaveRCC, SqlSelect.Order.Asc)

            Sql.ComandoText(sel.Script)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function

    Function ListarIngresosyEgresosXPeriodoYEmpresaYAuxiliar(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("VsRegContabCabe")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.PeriodoRCC, SqlSelect.Operador.Igual, ent.PeriodoRegContabCabe)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, ent.CodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodAux, SqlSelect.Operador.Igual, ent.CodigoAuxiliar)
            sel.CondicionIn(SqlSelect.Reservada.Y, Campo.CodOriRC, "1,2")
            sel.Orden(Campo.ClaveRCC, SqlSelect.Order.Asc)
            Sql.ComandoText(sel.Script)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function

    Function ListarRegistrosContablesDetalleXOrigenes(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsRegContabDeta")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodAux, SqlSelect.Operador.Diferente, "")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.MonDoc, SqlSelect.Operador.Diferente, "0")
            sel.CondicionIn(SqlSelect.Reservada.Y, Campo.CodOriRC, ent.CodigoOrigen)
            sel.Orden(ent.CampoOrden, SqlSelect.Order.Asc)

            Sql.ComandoText(sel.Script)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function


End Class