Imports Entidad
Imports ScriptBaseDatos

Public Class MovimientoContableDetalleAD

    Private Sql As New SqlDatos
    Private Lista As New List(Of SuperEntidad)
    Private obj As New SuperEntidad
    Private Campo As New CamposEntidad
    Private Par As New ParametroSql

    Sub SetParametros(ByRef ent As SuperEntidad)
        '//
        Sql.AsignarParametro(Par.ClaveRegContabDeta, ent.ClaveRegContabDeta)
        Sql.AsignarParametro(Par.ClaveRegContabCabe, ent.ClaveRegContabCabe)
        Sql.AsignarParametro(Par.CodigoEmpresa, ent.CodigoEmpresa)
        Sql.AsignarParametro(Par.CorrelativoRegContabDeta, ent.CorrelativoRegContabDeta)
        Sql.AsignarParametro(Par.CodigoIngEgr, ent.CodigoIngEgr)
        Sql.AsignarParametro(Par.CodigoAuxiliar, ent.CodigoAuxiliar)
        Sql.AsignarParametro(Par.TipoDocumento, ent.TipoDocumento)
        Sql.AsignarParametro(Par.SerieDocumento, ent.SerieDocumento)
        Sql.AsignarParametro(Par.NumeroDocumento, ent.NumeroDocumento)
        Sql.AsignarParametro(Par.FechaDocumento, ent.FechaDocumento)
        Sql.AsignarParametro(Par.VentaTipoCambio, ent.VentaTipoCambio)
        Sql.AsignarParametro(Par.CodigoCuentaPcge, ent.CodigoCuentaPcge)
        Sql.AsignarParametro(Par.CodigoCentroCosto, ent.CodigoCentroCosto)
        Select Case ent.DebeHaberRegContabDeta
            Case "Debe"
                ent.DebeHaberRegContabDeta = "1"
            Case "Haber"
                ent.DebeHaberRegContabDeta = "0"
        End Select
        Sql.AsignarParametro(Par.DebeHaberRegContabDeta, ent.DebeHaberRegContabDeta)
        Sql.AsignarParametro(Par.ImporteSRegContabDeta, ent.ImporteSRegContabDeta)
        Sql.AsignarParametro(Par.ImporteDRegContabDeta, ent.ImporteDRegContabDeta)
        Sql.AsignarParametro(Par.ImporteERegContabDeta, ent.ImporteERegContabDeta)
        Sql.AsignarParametro(Par.GlosaRegContabDeta, ent.GlosaRegContabDeta)
        Sql.AsignarParametro(Par.Cuenta1242, ent.Cuenta1242)
        Sql.AsignarParametro(Par.EstadoRegContabDeta, ent.EstadoRegContabDeta)
        Select Case ent.EstadoRegistro
            Case "Activo"
                ent.EstadoRegistro = "1"
            Case "Desactivo"
                ent.EstadoRegistro = "0"
        End Select
        Sql.AsignarParametro(Par.CodigoArea, ent.CodigoArea)
        Sql.AsignarParametro(Par.CodigoFlujoCaja, ent.CodigoFlujoCaja)
        Sql.AsignarParametro(Par.CodigoGastoReparable, ent.CodigoGastoReparable)

        Select Case ent.Exporta
            Case "S/."
                ent.Exporta = "0"
            Case "US$"
                ent.Exporta = "1"
            Case "EUR"
                ent.Exporta = "2"
        End Select
        Sql.AsignarParametro(Par.Exporta, ent.Exporta)
        Sql.AsignarParametro(Par.EstadoRegistro, ent.EstadoRegistro)
        Sql.AsignarParametro(Par.EliminadoRegistro, ent.EliminadoRegistro)
        Sql.AsignarParametro(Par.CodigoUsuarioAgrega, ent.CodigoUsuarioAgrega)
        Sql.AsignarParametro(Par.NombreUsuarioAgrega, ent.NombreUsuarioAgrega)
        Sql.AsignarParametro(Par.FechaAgrega, ent.FechaAgrega)
        Sql.AsignarParametro(Par.CodigoUsuarioModifica, ent.CodigoUsuarioModifica)
        Sql.AsignarParametro(Par.NombreUsuarioModifica, ent.NombreUsuarioModifica)
        Sql.AsignarParametro(Par.FechaModifica, ent.FechaModifica)
        Sql.AsignarParametro(Par.PeriodoRegContabCabe, ent.PeriodoRegContabCabe)
        '\\
    End Sub

    Function Objeto(ByRef iDr As IDataReader) As SuperEntidad
        '//
        Dim objEnc As New SuperEntidad
        objEnc.ClaveRegContabCabe = iDr(Campo.ClaveRCC).ToString
        objEnc.CodigoEmpresa = iDr(Campo.CodEmp).ToString
        objEnc.RazonSocialEmpresa = iDr(Campo.RazSocEmp).ToString
        objEnc.PeriodoRegContabCabe = iDr(Campo.PeriodoRCC).ToString
        objEnc.CodigoOrigen = iDr(Campo.CodOriRC).ToString
        objEnc.NombreOrigen = iDr(Campo.NomOriRC).ToString
        objEnc.CodigoFile = iDr(Campo.CodFilRC).ToString
        objEnc.NombreFile = iDr(Campo.NomFilRC).ToString
        objEnc.NumeroVoucherRegContabCabe = iDr(Campo.NumVouRCC).ToString
        objEnc.FechaVoucherRegContabCabe = CType(iDr(Campo.FecVouRCC), DateTime)
        objEnc.ClaveRegContabDeta = iDr(Campo.ClaveRCD).ToString
        objEnc.CorrelativoRegContabDeta = iDr(Campo.CorreRCD).ToString
        objEnc.CodigoAuxiliar = iDr(Campo.CodAux).ToString
        objEnc.DescripcionAuxiliar = iDr(Campo.DesAux).ToString
        objEnc.TipoDocumento = iDr(Campo.CodTipDoc).ToString
        objEnc.NombreDocumento = iDr(Campo.NomTipDoc).ToString
        objEnc.SerieDocumento = iDr(Campo.SerDoC).ToString
        objEnc.NumeroDocumento = iDr(Campo.NumDoc).ToString
        objEnc.FechaDocumento = CType(iDr(Campo.FecDoc), DateTime)
        objEnc.VentaTipoCambio = CType(iDr(Campo.VenTipCam), Decimal)
        'objEnc.IgvPar = CType(iDr(Campo.IgvPar), Decimal)
        objEnc.CodigoCuentaPcge = iDr(Campo.CodCtaPcge).ToString
        objEnc.NombreCuentaPcge = iDr(Campo.NomCtaPcge).ToString
        objEnc.CodigoCentroCosto = iDr(Campo.CodCC).ToString
        objEnc.NombreCentroCosto = iDr(Campo.NomCC).ToString


        'Debe o Haber

        'estado
        If iDr(Campo.DebHabRCD).ToString = "1" Then
            objEnc.DebeHaberRegContabDeta = "Debe"
        Else
            objEnc.DebeHaberRegContabDeta = "Haber"
        End If

        'Moneda
        If iDr(Campo.MonDoc).ToString = "1" Then
            objEnc.MonedaDocumento = "Dolares"
        Else
            objEnc.MonedaDocumento = "Soles"
        End If

        objEnc.ImporteSRegContabDeta = Math.Abs(CType(iDr(Campo.ImpSRCD), Decimal))
        objEnc.ImporteDRegContabDeta = Math.Abs(CType(iDr(Campo.ImpDRCD), Decimal))
        objEnc.ImporteERegContabDeta = Math.Abs(CType(iDr(Campo.ImpERCD), Decimal))
        objEnc.GlosaRegContabDeta = iDr(Campo.GlosaRCD).ToString
        objEnc.CodigoIngEgr = iDr(Campo.CodIngEgr).ToString
        objEnc.NombreIngEgr = iDr(Campo.NomIngEgr1).ToString
        objEnc.Cuenta1242 = iDr(Campo.CodCta1242).ToString
        objEnc.NombreCuenta1242 = iDr(Campo.NomCta1242).ToString
        objEnc.EstadoRegContabDeta = iDr(Campo.EstRCD).ToString
            ' objEnc.FlagAutomaticaPcge = iDr(Campo.FlaAutPcge).ToString
            ' objEnc.CuentaAutomatica1Pcge = iDr(Campo.CtaAut1Pcge).ToString
            ' objEnc.CuentaAutomatica2Pcge = iDr(Campo.CtaAut2Pcge).ToString
        'estado
        If iDr(Campo.EstReg).ToString = "1" Then
            objEnc.EstadoRegistro = "Activo"
        Else
            objEnc.EstadoRegistro = "Desactivo"
        End If

        objEnc.CodigoArea = iDr(Campo.CodAre).ToString
        objEnc.NombreArea = iDr(Campo.NomAre).ToString
        objEnc.CodigoFlujoCaja = iDr(Campo.CodFluCaj).ToString
        objEnc.NombreFlujoCaja = iDr(Campo.NomFluCaj).ToString
        objEnc.CodigoGastoReparable = iDr(Campo.CodGasRep).ToString
        objEnc.NombreGastoReparable = iDr(Campo.NomGasRep).ToString

        ' objEnc.Exporta = iDr(Campo.Exp).ToString

        Select Case iDr(Campo.Exp).ToString
            Case "0"
                objEnc.Exporta = "S/."
            Case "1"
                objEnc.Exporta = "US$"
            Case "2"
                objEnc.Exporta = "EUR"
        End Select

        objEnc.EliminadoRegistro = iDr(Campo.EliReg).ToString
        objEnc.CodigoUsuarioAgrega = iDr(Campo.CodUsuAgr).ToString
        objEnc.NombreUsuarioAgrega = iDr(Campo.NomUsuAgr).ToString
        objEnc.FechaAgrega = CType(iDr(Campo.FechaAgr), DateTime)
        objEnc.CodigoUsuarioModifica = iDr(Campo.CodUsuMod).ToString
        objEnc.NombreUsuarioModifica = iDr(Campo.NomUsuMod).ToString
        objEnc.FechaModifica = CType(iDr(Campo.FechaMod), DateTime)

        ' objEnc.ImporteSRegContabDeta = CType(iDr(Campo.ImpSRCD), Decimal)

        'especial
        objEnc.CampoCursor = iDr(Campo.ClaveRCD).ToString
        'objEnc.MonedaDocumento = iDr(Campo.MonDoc).ToString
        Return objEnc
        '\\
    End Function

    Sub SpNuevoMovimientoContableDetalle(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpNuevoMovimientoContableDetalle")
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


    Sub SpModificarMovimientoContableDetalle(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpModificarMovimientoContableDetalle")
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

    Sub SpEliminarMovimientoContableDetalle(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpEliminarMovimientoContableDetalle")
            '/Asignar Parametro
            Sql.AsignarParametro(Par.PeriodoRegContabCabe, ent.PeriodoRegContabCabe)
            Sql.AsignarParametro(Par.CodigoEmpresa, ent.CodigoEmpresa)
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

    Function SpObtenerRegistrosConDosCondicionDosFiltros(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpObtenerRegistrosConDosCondicionDosFiltros")
            '/Asignar Parametros
            Sql.AsignarParametro(Par.Vista, ent.Vista)
            Sql.AsignarParametro(Par.DatoEliminado, ent.DatoEliminado)
            Sql.AsignarParametro(Par.DatoEstado, ent.DatoEstado)
            Sql.AsignarParametro(Par.CampoCondicion1, ent.CampoCondicion1)
            Sql.AsignarParametro(Par.DatoCondicion1, ent.DatoCondicion1)
            Sql.AsignarParametro(Par.CampoCondicion2, ent.CampoCondicion2)
            Sql.AsignarParametro(Par.DatoCondicion2, ent.DatoCondicion2)
            Sql.AsignarParametro(Par.CampoFiltro1, ent.CampoFiltro1)
            Sql.AsignarParametro(Par.DatoFiltro1, ent.DatoFiltro1)
            Sql.AsignarParametro(Par.CampoFiltro2, ent.CampoFiltro2)
            Sql.AsignarParametro(Par.DatoFiltro2, ent.DatoFiltro2)
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


    Function SpObtenerRegistrosConDosCondicionYRango(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpObtenerRegistrosConDosCondicionYRango")
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



    Function SpObtenerRegistrosConUnaCondicionDosFiltros(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpObtenerRegistrosConUnaCondicionDosFiltros")
            '/Asignar Parametros
            Sql.AsignarParametro(Par.Vista, ent.Vista)
            Sql.AsignarParametro(Par.DatoEliminado, ent.DatoEliminado)
            Sql.AsignarParametro(Par.DatoEstado, ent.DatoEstado)
            Sql.AsignarParametro(Par.CampoCondicion1, ent.CampoCondicion1)
            Sql.AsignarParametro(Par.DatoCondicion1, ent.DatoCondicion1)
            Sql.AsignarParametro(Par.CampoFiltro1, ent.CampoFiltro1)
            Sql.AsignarParametro(Par.DatoFiltro1, ent.DatoFiltro1)
            Sql.AsignarParametro(Par.CampoFiltro2, ent.CampoFiltro2)
            Sql.AsignarParametro(Par.DatoFiltro2, ent.DatoFiltro2)
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


    Function ListarMovimientoDetalleXCuentaXAuxiliarEntrePeriodo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsmovimientocontabledetalle")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, ent.CodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodCtaPcge, SqlSelect.Operador.Igual, ent.CodigoCuentaPcge)
            sel.CondicionLike(SqlSelect.Reservada.Y, Campo.CodAux, ent.CodigoAuxiliar)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodAux, SqlSelect.Operador.Diferente, "")
            sel.CondicionBetween(SqlSelect.Reservada.Y, Campo.PeriodoRCC, ent.DatoCondicion1, ent.DatoCondicion2)
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


    Function ListarMovimientoDetalleXCuentaXAuxiliarEntrePeriodo1(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsmovimientocontabledetalle")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, ent.CodigoEmpresa)
            '  sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodCtaPcge, SqlSelect.Operador.Igual, ent.CodigoCuentaPcge)
            sel.CondicionLike(SqlSelect.Reservada.Y, Campo.CodCtaPcge, ent.CodigoCuentaPcge)
            sel.CondicionLike(SqlSelect.Reservada.Y, Campo.CodAux, ent.CodigoAuxiliar)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodAux, SqlSelect.Operador.Diferente, "")
            sel.CondicionBetween(SqlSelect.Reservada.Y, Campo.PeriodoRCC, ent.DatoCondicion1, ent.DatoCondicion2)
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




    Function ListarMovimientoContableDetalleEntrePeriodoYCuentaFiltro(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsmovimientocontabledetalle")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionBetween(SqlSelect.Reservada.Y, Campo.PeriodoRCC, ent.DatoFiltro1, ent.DatoFiltro2)
            sel.CondicionLike(SqlSelect.Reservada.Y, Campo.CodCtaPcge, ent.CodigoCuentaPcge)
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

    Function ListarMovimientoContableDetalleXPeriodoYCuenta(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsmovimientocontabledetalle")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.PeriodoRCC, SqlSelect.Operador.Igual, ent.PeriodoRegContabCabe)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodCtaPcge, SqlSelect.Operador.Igual, ent.CodigoCuentaPcge)
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


    Sub SpNuevoMovimientoContableDetalleMasivo(ByRef pLista As List(Of SuperEntidad))
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpNuevoMovimientoContableDetalle")
            For Each xMcd As SuperEntidad In pLista
                xMcd.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
                xMcd.NombreUsuarioAgrega = SuperEntidad.xNombreUsuario
                xMcd.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
                xMcd.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
                '/Asignar Parametros
                Me.SetParametros(xMcd)
                '/Ejecutar sin resultado
                Sql.EjecutarSinResultado()
                Sql.QuitarParametros()
            Next


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Sql.Desconectar()
        End Try
    End Sub

    Function ListarMovimientoDetalleParaAuxiliaresTodos(ByRef ent As SuperEntidad) As List(Of List(Of SuperEntidad))
        '//
        'lista resultado
        Dim iLisRes As New List(Of List(Of SuperEntidad))

        Try

            'ejecutar consulta
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsmovimientocontabledetalle")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, ent.CodigoEmpresa)
            'para los auxiliares
            If ent.CodigoAuxiliar = String.Empty Then
                sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodAux, SqlSelect.Operador.Diferente, String.Empty)
            Else
                sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodAux, SqlSelect.Operador.Igual, ent.CodigoAuxiliar)
            End If
            'para las cuentas
            If ent.CodigoCuentaPcge <> String.Empty Then
                sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodCtaPcge, SqlSelect.Operador.Igual, ent.CodigoCuentaPcge)
            End If
            sel.CondicionBetween(SqlSelect.Reservada.Y, Campo.PeriodoRCC, ent.DatoCondicion1, ent.DatoCondicion2)
            sel.Orden(ent.CampoOrden, SqlSelect.Order.Asc)
            Sql.ComandoText(sel.Script)

            'variables
            Dim iAuxiliar As String = ""
            Dim iIndice As Integer = -1

            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'creando un nuevo objeto para la lista
                Dim iMovEN As New SuperEntidad
                iMovEN = Me.Objeto(iDr)

                If iMovEN.CodigoAuxiliar <> iAuxiliar Then
                    Dim iLisAux As New List(Of SuperEntidad)
                    iLisAux.Add(iMovEN)
                    iLisRes.Add(iLisAux)
                    iIndice += 1
                    iAuxiliar = iMovEN.CodigoAuxiliar
                Else
                    iLisRes(iIndice).Add(iMovEN)
                End If
            End While
            Return iLisRes
        Catch ex As Exception
            MsgBox(ex.Message) : Return iLisRes
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function

    Function ListarMovimientoParaLibroDiarioEnero(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsmovimientocontabledetalle")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionIn(SqlSelect.Reservada.Y, Campo.PeriodoRCC, ent.PeriodoRegContabCabe + "00," + ent.PeriodoRegContabCabe + "01")
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

    Function ListarMovimientoParaLibroDiarioDiciembre(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsmovimientocontabledetalle")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionIn(SqlSelect.Reservada.Y, Campo.PeriodoRCC, ent.PeriodoRegContabCabe + "12," + ent.PeriodoRegContabCabe + "13")
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

    Function ListarMovimientosContablesDetalleXOrigenes(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsmovimientocontabledetalle")
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
