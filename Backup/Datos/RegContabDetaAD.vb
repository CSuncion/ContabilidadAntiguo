Imports Entidad
Imports ScriptBaseDatos

Public Class RegContabDetaAD
    Private objCon As New SqlDatos
    Private Sql As New SqlDatos
    Private Lista As New List(Of SuperEntidad)
    Private obj As New SuperEntidad
    Private Campo As New CamposEntidad
    Private Par As New ParametroSql

    Sub SetParametros(ByRef ent As SuperEntidad)
        '//
        Sql.AsignarParametro(Par.ClaveRegContabDeta, ent.ClaveRegContabDeta)
        Sql.AsignarParametro(Par.ClaveRegContabCabe, ent.ClaveRegContabCabe)
        Sql.AsignarParametro(Par.CorrelativoRegContabDeta, ent.CorrelativoRegContabDeta)
        Sql.AsignarParametro(Par.CodigoIngEgr, ent.CodigoIngEgr)
        Sql.AsignarParametro(Par.CodigoAuxiliar, ent.CodigoAuxiliar)
        Sql.AsignarParametro(Par.TipoDocumento, ent.TipoDocumento)
        Sql.AsignarParametro(Par.SerieDocumento, ent.SerieDocumento)
        Sql.AsignarParametro(Par.NumeroDocumento, ent.NumeroDocumento)
        Sql.AsignarParametro(Par.FechaDocumento, ent.FechaDocumento)
        Sql.AsignarParametro(Par.VentaTipoCambio, ent.VentaTipoCambio)
        Sql.AsignarParametro(Par.VentaEurTipoCambio, ent.VentaEurTipoCambio)
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
        '' SE usa en la moneda del documento del detalle regbcos

        Select Case ent.Exporta
            Case "S/."
                ent.Exporta = "0"
            Case "US$"
                ent.Exporta = "1"
            Case "EUR"
                ent.Exporta = "2"
        End Select

        Sql.AsignarParametro(Par.MontoMoneda, ent.MontoMoneda)
        Sql.AsignarParametro(Par.MontoSoles, ent.MontoSoles)
        Sql.AsignarParametro(Par.CodigoArea, ent.CodigoArea)
        Sql.AsignarParametro(Par.CodigoFlujoCaja, ent.CodigoFlujoCaja)
        Sql.AsignarParametro(Par.CodigoGastoReparable, ent.CodigoGastoReparable)
        Sql.AsignarParametro(Par.Cantidad, ent.Cantidad)

        Sql.AsignarParametro(Par.Exporta, ent.Exporta)
        Sql.AsignarParametro(Par.EstadoRegistro, ent.EstadoRegistro)
        Sql.AsignarParametro(Par.EliminadoRegistro, ent.EliminadoRegistro)
        Sql.AsignarParametro(Par.CodigoUsuarioAgrega, ent.CodigoUsuarioAgrega)
        Sql.AsignarParametro(Par.NombreUsuarioAgrega, ent.NombreUsuarioAgrega)
        Sql.AsignarParametro(Par.FechaAgrega, ent.FechaAgrega)
        Sql.AsignarParametro(Par.CodigoUsuarioModifica, ent.CodigoUsuarioModifica)
        Sql.AsignarParametro(Par.nombreUsuarioModifica, ent.NombreUsuarioModifica)
        Sql.AsignarParametro(Par.FechaModifica, ent.FechaModifica)
        Sql.AsignarParametro(Par.CodigoPptoInterno, ent.CodigoPptoInterno)
        Sql.AsignarParametro(Par.CodigoConcepto, ent.CodigoConcepto)
        Sql.AsignarParametro(Par.CodigoInterno, ent.CodigoInterno)
        Sql.AsignarParametro(Par.Titulo, ent.Titulo)

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
        objEnc.VentaEurTipoCambio = CType(iDr(Campo.VenEurTipCam), Decimal)
        'objEnc.IgvPar = CType(iDr(Campo.IgvPar), Decimal)
        objEnc.CodigoCuentaPcge = iDr(Campo.CodCtaPcge).ToString
        objEnc.NombreCuentaPcge = iDr(Campo.NomCtaPcge).ToString
        objEnc.CodigoCentroCosto = iDr(Campo.CodCC).ToString
        objEnc.NombreCentroCosto = iDr(Campo.NomCC).ToString
        objEnc.DescripcionRegContabCabe = iDr(Campo.DesRCC).ToString

        'Debe o Haber

        'estado
        If iDr(Campo.DebHabRCD).ToString = "1" Then
            objEnc.DebeHaberRegContabDeta = "Debe"
        Else
            objEnc.DebeHaberRegContabDeta = "Haber"
        End If


        objEnc.PrecioVtaSolRegContabCabe = Math.Abs(CType(iDr(Campo.PreVtasRCC), Decimal))
        objEnc.IgvSolRegContabCabe = Math.Abs(CType(iDr(Campo.IgvsRCC), Decimal))
        objEnc.ImporteSRegContabDeta = Math.Abs(CType(iDr(Campo.ImpSRCD), Decimal))
        'objEnc.ImporteSRegContabDeta = CType(iDr(Campo.ImpSRCD), Decimal)
        objEnc.ImporteDRegContabDeta = Math.Abs(CType(iDr(Campo.ImpDRCD), Decimal))
        objEnc.ImporteERegContabDeta = Math.Abs(CType(iDr(Campo.ImpERCD), Decimal))
        objEnc.GlosaRegContabDeta = iDr(Campo.GlosaRCD).ToString
        objEnc.CodigoIngEgr = iDr(Campo.CodIngEgr).ToString
        objEnc.NombreIngEgr = iDr(Campo.NomIngEgr1).ToString
        objEnc.Cuenta1242 = iDr(Campo.CodCta1242).ToString
        objEnc.NombreCuenta1242 = iDr(Campo.NomCta1242).ToString
        objEnc.EstadoRegContabDeta = iDr(Campo.EstRCD).ToString
        objEnc.FlagAutomaticaPcge = iDr(Campo.FlaAutPcge).ToString
        objEnc.CuentaAutomatica1Pcge = iDr(Campo.CtaAut1Pcge).ToString
        objEnc.CuentaAutomatica2Pcge = iDr(Campo.CtaAut2Pcge).ToString
        objEnc.FlagBancoPcge = iDr(Campo.FlaBcoPcge).ToString
        objEnc.FlagMonedaPcge = iDr(Campo.FlaMonPcge).ToString
        'estado
        If iDr(Campo.EstReg).ToString = "1" Then
            objEnc.EstadoRegistro = "Activo"
        Else
            objEnc.EstadoRegistro = "Desactivo"
        End If
        ''
        Select Case iDr(Campo.Exp).ToString
            Case "0"
                objEnc.Exporta = "S/."
            Case "1"
                objEnc.Exporta = "US$"
            Case "2"
                objEnc.Exporta = "EUR"
        End Select


        objEnc.MontoMoneda = Math.Abs(CType(iDr(Campo.MonMon), Decimal))
        objEnc.MontoSoles = Math.Abs(CType(iDr(Campo.MonSol), Decimal))
        objEnc.CodigoArea = iDr(Campo.CodAre).ToString
        objEnc.NombreArea = iDr(Campo.NomAre).ToString
        objEnc.CodigoFlujoCaja = iDr(Campo.CodFluCaj).ToString
        objEnc.NombreFlujoCaja = iDr(Campo.NomFluCaj).ToString
        objEnc.CodigoGastoReparable = iDr(Campo.CodGasRep).ToString
        objEnc.NombreGastoReparable = iDr(Campo.NomGasRep).ToString
        objEnc.Cantidad = Math.Abs(CType(iDr(Campo.Cant), Decimal))
        objEnc.Unidad = iDr(Campo.Uni).ToString
        'objEnc.CCodigoOrigenRegistroVentas = iDr(Campo.CCodOriRegVta).ToString
        'objEnc.CCodigoFileRegistroVentas = iDr(Campo.CCodFilRegVta).ToString
        'objEnc.CuentaCuotaOrdinaria = iDr(Campo.CtaCuoOrd).ToString
        'objEnc.CuentaCuotaSupervisionYProyectos = iDr(Campo.CtaCuoSupYPro).ToString
        'objEnc.CuentaCuotaAgua = iDr(Campo.CtaCuoAgu).ToString
        'objEnc.CuentaCuotaElectricidad = iDr(Campo.CtaCuoEle).ToString
        'objEnc.CuentaCuotaIngreso = iDr(Campo.CtaCuoIng).ToString
        'objEnc.CuentaCuotaExtraordinaria = iDr(Campo.CtaCuoExt).ToString
        'objEnc.CuentaMontoTotalCuotas = iDr(Campo.CtaMonTotCuo).ToString

        'objEnc.Exporta = iDr(Campo.Exp).ToString
        objEnc.EliminadoRegistro = iDr(Campo.EliReg).ToString
        objEnc.CodigoUsuarioAgrega = iDr(Campo.CodUsuAgr).ToString
        objEnc.NombreUsuarioAgrega = iDr(Campo.NomUsuAgr).ToString
        objEnc.FechaAgrega = CType(iDr(Campo.FechaAgr), DateTime)
        objEnc.CodigoUsuarioModifica = iDr(Campo.CodUsuMod).ToString
        objEnc.NombreUsuarioModifica = iDr(Campo.NomUsuMod).ToString
        objEnc.FechaModifica = CType(iDr(Campo.FechaMod), DateTime)

        objEnc.UltimoCorrelativo = iDr(Campo.UltCorre).ToString
        objEnc.EstadoRegistroRcc = iDr(Campo.EstRegRcc).ToString
        objEnc.CodigoPptoInterno = iDr(Campo.CodPptoInt).ToString
        ' objEnc.DescripcionProHijo = iDr(Campo.DesProHij).ToString
        objEnc.CodigoConcepto = iDr(Campo.CodConc).ToString
        objEnc.Titulo = iDr(Campo.Titulo).ToString
        objEnc.NombreTitulo = iDr(Campo.NomTitu).ToString
        objEnc.CodigoInterno = iDr(Campo.CodInt).ToString
        objEnc.NombreInterno = iDr(Campo.NomInt).ToString
        'especial
        objEnc.MonedaDocumento = iDr(Campo.MonDoc).ToString
        objEnc.CampoCursor = iDr(Campo.ClaveRCD).ToString
        Return objEnc
        '\\
    End Function

    Sub SpNuevoDetalleRegContab(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpNuevoRegContabDeta")
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

    Sub NuevoRegContabDetaMasivo(ByRef pLista As List(Of SuperEntidad))
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpNuevoRegContabDeta")
            For Each xRcd As SuperEntidad In pLista
                xRcd.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
                xRcd.NombreUsuarioAgrega = SuperEntidad.xNombreUsuario
                xRcd.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
                xRcd.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
                '/Asignar Parametros
                Me.SetParametros(xRcd)
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

    Sub SpModificarDetalleRegContab(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpModificarRegContabDeta")
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

    Sub SpEliminarRegcontabDeta(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpEliminarRegContabDeta")
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

    Sub EliminarRegistroDetalleXClaveDetalle(ByRef objx As SuperEntidad)
        '/
        Try
            objCon.Conectar(SqlDatos.Bd.ContabilidadEmma)

            'ARMANDO SCRIPT PARA ACTUALIZAR
            Dim eli As New SqlDelete
            eli.Tabla("RegContabDeta")

            Dim sel As New SqlSelect
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.ClaveRCD, SqlSelect.Operador.Igual, objx.ClaveRegContabDeta)
            eli.CondicionDelete(sel.Script)

            'SCRIPT ARMADO
            objCon.ComandoText(eli.Script)

            'EJECUTAR SIN RESULTADO
            objCon.EjecutarSinResultado()

        Catch ex As Exception
            'NO SALIO BIEN
        Finally
            objCon.Desconectar()
        End Try
        '/
    End Sub

    Sub EliminarRegistroDetalleParaCierreAnual(ByRef objx As SuperEntidad)
        '/
        Try
            objCon.Conectar(SqlDatos.Bd.ContabilidadEmma)

            'ARMANDO SCRIPT PARA ACTUALIZAR
            Dim eli As New SqlDelete
            eli.Tabla("RegContabDeta")
            'ARMANDO LA CONDICION PARA LA ELIMINACION
            Dim iScript As String = " Where SubString(ClaveRegContabCabe,1," + objx.ClaveRegContabCabe.Length.ToString + ")=" + objx.ClaveRegContabCabe
            eli.CondicionDelete(iScript)

            'SCRIPT ARMADO
            objCon.ComandoText(eli.Script)

            'EJECUTAR SIN RESULTADO
            objCon.EjecutarSinResultado()

        Catch ex As Exception
            'NO SALIO BIEN
        Finally
            objCon.Desconectar()
        End Try
        '/
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



    Function ListarRegistrosContablesDetalleXFiltroCuenta(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsRegContabDeta")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
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


    Function ListarIngresosEgresos(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsRegContabDeta")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.PeriodoRCC, SqlSelect.Operador.Igual, ent.PeriodoRegContabCabe)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodIngEgr, SqlSelect.Operador.Diferente, "")

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

    Function obtenerDetalleRegContabXClaveYEstadoNew(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsRegContabDeta")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            '  sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.ClaveRCC, SqlSelect.Operador.Igual, ent.ClaveRegContabCabe)
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


    Function ListarRegistrosContablesDetalleXFiltroCentroCostoDetalle(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsRegContabDeta")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionBetween(SqlSelect.Reservada.Y, Campo.PeriodoRCC, ent.DatoFiltro1, ent.DatoFiltro2)
            sel.CondicionBetween(SqlSelect.Reservada.Y, Campo.CodCC, ent.DatoFiltro3, ent.DatoFiltro4)
            If ent.DatoFiltro5 <> String.Empty Then
                sel.CondicionBetween(SqlSelect.Reservada.Y, Campo.CodCtaPcge, ent.DatoFiltro5, ent.DatoFiltro6)
            End If

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

    Function ListarRegistrosContablesDetalleXFiltroCuentasYCentroCosto(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsRegContabDeta")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionBetween(SqlSelect.Reservada.Y, Campo.PeriodoRCC, ent.DatoFiltro1, ent.DatoFiltro2)
            sel.CondicionBetween(SqlSelect.Reservada.Y, Campo.CodCtaPcge, ent.DatoFiltro3, ent.DatoFiltro4)
            sel.CondicionLike(SqlSelect.Reservada.Y, Campo.CodCC, ent.CodigoCentroCosto)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodCC, SqlSelect.Operador.Diferente, String.Empty)
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

    Function ListarRegistrosContablesDetalleXFiltroCentroCostoYCuentas(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsRegContabDeta")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionBetween(SqlSelect.Reservada.Y, Campo.PeriodoRCC, ent.DatoFiltro1, ent.DatoFiltro2)
            sel.CondicionBetween(SqlSelect.Reservada.Y, Campo.CodCC, ent.DatoFiltro3, ent.DatoFiltro4)
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


    Function ListarRegistrosContablesDetalleXFiltroCentroCostoParaIngresoEgresoDetalle(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsRegContabDeta")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionBetween(SqlSelect.Reservada.Y, Campo.PeriodoRCC, ent.DatoFiltro1, ent.DatoFiltro2)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodCC, SqlSelect.Operador.Igual, ent.CodigoCentroCosto)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodIngEgr, SqlSelect.Operador.Diferente, "")
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

    Function ListarRegistrosContablesDetalleXEmpresaXPeriodoXCuentaYEntreFechas(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsRegContabDeta")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.PeriodoRCC, SqlSelect.Operador.Igual, ent.PeriodoRegContabCabe)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodCtaPcge, SqlSelect.Operador.Igual, ent.CodigoCuentaPcge)
            sel.CondicionBetween(SqlSelect.Reservada.Y, Campo.FecVouRCC, ent.DatoFiltro1, ent.DatoFiltro2)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodFilRC, SqlSelect.Operador.Diferente, "390")

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

    Function ListarRegistrosContablesDetalleXEmpresaYEntrePeriodos(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsRegContabDeta")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionBetween(SqlSelect.Reservada.Y, Campo.PeriodoRCC, ent.DatoFiltro1, ent.DatoFiltro2)
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


    Sub EliminarRegcontabDetalle(ByRef objx As SuperEntidad)
        '/
        Try
            objCon.Conectar(SqlDatos.Bd.ContabilidadEmma)

            'ARMANDO SCRIPT PARA ACTUALIZAR
            Dim eli As New SqlDelete
            eli.Tabla("RegContabDeta")

            Dim sel As New SqlSelect
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.ClaveRCD, SqlSelect.Operador.Igual, objx.ClaveRegContabDeta)
            eli.CondicionDelete(sel.Script)

            'SCRIPT ARMADO
            objCon.ComandoText(eli.Script)

            'EJECUTAR SIN RESULTADO
            objCon.EjecutarSinResultado()



        Catch ex As Exception

        Finally
            objCon.Desconectar()
        End Try
        '/
    End Sub

    Function ListarRegistrosContablesDetalleEntrePeriodoConFlujoCaja(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsRegContabDeta")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionBetween(SqlSelect.Reservada.Y, Campo.PeriodoRCC, ent.DatoFiltro1, ent.DatoFiltro2)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodFluCaj, SqlSelect.Operador.Diferente, "")
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

    Function ListarRegistrosContablesDetalleEntrePeriodoConFlujoCajaXCuenta(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsRegContabDeta")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionBetween(SqlSelect.Reservada.Y, Campo.PeriodoRCC, ent.DatoFiltro1, ent.DatoFiltro2)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodCtaPcge, SqlSelect.Operador.Igual, ent.CodigoCuentaPcge)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodFluCaj, SqlSelect.Operador.Diferente, "")
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

    Function ListarRegistrosContablesDetalleXFiltroFlujoCaja(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsRegContabDeta")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionBetween(SqlSelect.Reservada.Y, Campo.PeriodoRCC, ent.DatoFiltro1, ent.DatoFiltro2)
            sel.CondicionBetween(SqlSelect.Reservada.Y, Campo.CodFluCaj, ent.DatoFiltro3, ent.DatoFiltro4)
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

    Function ListarRegistrosContablesDetalleXPeriodoSinExtornoYFiltroOrigen(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsRegContabDeta")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.PeriodoRCC, SqlSelect.Operador.Igual, ent.PeriodoRegContabCabe)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.EstRegRcc, SqlSelect.Operador.Igual, "0")
            If ent.CodigoOrigen <> "" Then
                sel.CondicionLike(SqlSelect.Reservada.Y, Campo.CodOriRC, ent.CodigoOrigen)
            End If
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


    Function ListarBancosParaCierreBanco(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsRegContabDeta")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.PeriodoRCC, SqlSelect.Operador.Igual, ent.PeriodoRegContabCabe)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.FlaBcoPcge, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodFilRC, SqlSelect.Operador.Diferente, "390")
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


    Function ListarRegistrosContablesDetalleXPeriodosSinExtorno(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsRegContabDeta")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            ' sel.CondicionCV(SqlSelect.Reservada.Y, Campo.PeriodoRCC, SqlSelect.Operador.Igual, ent.PeriodoRegContabCabe)
            sel.CondicionBetween(SqlSelect.Reservada.Y, Campo.PeriodoRCC, ent.DatoFiltro1, ent.DatoFiltro2)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.EstRegRcc, SqlSelect.Operador.Igual, "0")
            If ent.CodigoOrigen <> "" Then
                sel.CondicionLike(SqlSelect.Reservada.Y, Campo.CodOriRC, ent.CodigoOrigen)
            End If
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

    Function ListarRegistroDetalleParaCierreAnual(ByRef ent As SuperEntidad) As List(Of List(Of SuperEntidad))
        'LISTA RESULTADO
        Dim iLisXCta As New List(Of List(Of SuperEntidad))

        'CODIGO CUENTA
        Dim iCuenta As String = ""

        'INDICE DE LA LISTA ACTUAL EN iLisXCta
        Dim iIndice As Integer = -1

        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsRegContabDeta")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, ent.CodigoEmpresa)
            sel.CondicionBetween(SqlSelect.Reservada.Y, Campo.PeriodoRCC, ent.DatoCondicion1, ent.DatoCondicion2)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.EstRegRcc, SqlSelect.Operador.Igual, "0")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodAux, SqlSelect.Operador.Diferente, "")
            sel.Orden(ent.CampoOrden, SqlSelect.Order.Asc)
            Sql.ComandoText(sel.Script)

            'Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                Dim iRcd As New SuperEntidad
                iRcd = Me.Objeto(iDr)

                'SI LAS CUENTAS NO SON IGUALES ENTONCES CREAMOS UNA NUEVA LISTA
                If iRcd.CodigoCuentaPcge <> iCuenta Then

                    'ADICIONAMOS UNA LISTA PARA LA NUEVA CUENTA
                    'Y INSERTAMOS AL PRIMER OBJETO iRcd
                    Dim iLisC As New List(Of SuperEntidad)
                    iLisC.Add(iRcd)

                    'INSERTAMOS ESTA LISTA A LA LISTA DE CUENTAS
                    iLisXCta.Add(iLisC)

                    'OBTENEMOS EL INDICE DE LA LISTA DE CUENTA EN LA LISTA DE CUENTAS
                    iIndice += 1

                    'PASAMOS EL NUEVO CODIGO A NUESTA VARIABLE DE CUENTA
                    iCuenta = iRcd.CodigoCuentaPcge

                Else
                    iLisXCta(iIndice).Add(iRcd)
                End If
            End While
            Return iLisXCta
        Catch ex As Exception
            MsgBox(ex.Message) : Return iLisXCta
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function

    Function ListarRegistrosContablesDetalleParaDiferenciaCambio(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim iSel As String = "Select * From VsRegContabDeta"
            iSel += " Where CodigoEmpresa='" + ent.CodigoEmpresa + "'"
            iSel += " and CodigoOrigen in(1,2,3)"
            iSel += " and PeriodoRegContabCabe>'" + ent.PeriodoRegContabCabe + "'"
            iSel += " and SubString(PeriodoRegContabCabe,5,2)<>'00'"
            iSel += " Order By " + ent.CampoOrden
            Sql.ComandoText(iSel)
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


    Function ListarRegistrosContablesDetalleEntrePeriodoConGastoReparable(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsRegContabDeta")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionBetween(SqlSelect.Reservada.Y, Campo.PeriodoRCC, ent.DatoFiltro1, ent.DatoFiltro2)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodGasRep, SqlSelect.Operador.Diferente, "")
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


    Function ListarRegistrosContablesDetalleEntrePeriodoConGastoReparableXCuenta(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsRegContabDeta")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionBetween(SqlSelect.Reservada.Y, Campo.PeriodoRCC, ent.DatoFiltro1, ent.DatoFiltro2)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodCtaPcge, SqlSelect.Operador.Igual, ent.CodigoCuentaPcge)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodGasRep, SqlSelect.Operador.Diferente, "")
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

    Function ListarRegistrosContablesDetalleXFiltroGastoReparable(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsRegContabDeta")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionBetween(SqlSelect.Reservada.Y, Campo.PeriodoRCC, ent.DatoFiltro1, ent.DatoFiltro2)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodGasRep, SqlSelect.Operador.Diferente, "")
            'sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodGasRep.Length.ToString, SqlSelect.Operador.Mayor, "8")
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


    Sub EliminarRegcontabDetalleXClaveCabecera(ByRef objx As SuperEntidad)
        '/
        Try
            objCon.Conectar(SqlDatos.Bd.ContabilidadEmma)

            'ARMANDO SCRIPT PARA ACTUALIZAR
            Dim eli As New SqlDelete
            eli.Tabla("RegContabDeta")

            Dim sel As New SqlSelect
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.ClaveRCC, SqlSelect.Operador.Igual, objx.ClaveRegContabCabe)
            eli.CondicionDelete(sel.Script)

            'SCRIPT ARMADO
            objCon.ComandoText(eli.Script)

            'EJECUTAR SIN RESULTADO
            objCon.EjecutarSinResultado()



        Catch ex As Exception

        Finally
            objCon.Desconectar()
        End Try
        '/
    End Sub
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

    Function ListarMovimientoDetalleXCuentaXAuxiliarEntrePeriodoNew(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsRegContabDeta")
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

    Function ListarRegistrosContablesDetalleParaExportarAmacen(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsRegContabDeta")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.PeriodoRCC, SqlSelect.Operador.Igual, ent.PeriodoRegContabCabe)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodGasRep, SqlSelect.Operador.Diferente, "")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.Cant, SqlSelect.Operador.Diferente, "0")
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

    Sub SpEliminarRegContabDetaXGastoOperativo(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpEliminarRegContabDetaXGastoOperativo")
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

    Function ListarMovimientoDetalleXCuentaXAuxiliarEntrePeriodo1(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsRegContabDeta")
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

    Function ListarMovimientoDetalleParaAuxiliaresTodos(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsRegContabDeta")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, ent.CodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodAux, SqlSelect.Operador.Igual, ent.CodigoAuxiliar)
            'para las cuentas
            If ent.CodigoCuentaPcge <> String.Empty Then
                sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodCtaPcge, SqlSelect.Operador.Igual, ent.CodigoCuentaPcge)
            End If
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

    Function ListarMovimientoDetalleXCuentaXAuxiliarEntrePeriodo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsRegContabDeta")
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

End Class
