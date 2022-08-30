Imports Entidad
Imports ScriptBaseDatos

Public Class CuentaCorrienteAD

    Private Sql As New SqlDatos
    Private Lista As New List(Of SuperEntidad)
    Private obj As New SuperEntidad
    Private Campo As New CamposEntidad
    Private Par As New ParametroSql

    Sub SetParametros(ByRef ent As SuperEntidad)
        '//Esto va al Sql a grabar

        Sql.AsignarParametro(Par.ClaveCuentaCorriente, ent.ClaveCuentaCorriente)
        Sql.AsignarParametro(Par.ClaveDocumentoCuentaCorriente, ent.ClaveDocumentoCuentaCorriente)
        Sql.AsignarParametro(Par.CodigoEmpresa, ent.CodigoEmpresa)
        Sql.AsignarParametro(Par.PeriodoRegContabCabe, ent.PeriodoRegContabCabe)
        Sql.AsignarParametro(Par.CodigoOrigen, ent.CodigoOrigen)
        Sql.AsignarParametro(Par.CodigoFile, ent.CodigoFile)
        Sql.AsignarParametro(Par.NumeroVoucherRegContabCabe, ent.NumeroVoucherRegContabCabe)
        Sql.AsignarParametro(Par.CodigoAuxiliar, ent.CodigoAuxiliar)
        Sql.AsignarParametro(Par.TipoDocumento, ent.TipoDocumento)
        Sql.AsignarParametro(Par.SerieDocumento, ent.SerieDocumento)
        Sql.AsignarParametro(Par.NumeroDocumento, ent.NumeroDocumento)
        Sql.AsignarParametro(Par.FechaDocumento, ent.FechaDocumento)
        Sql.AsignarParametro(Par.FechaVctoDocumneto, ent.FechaVctoDocumento)
        Select Case ent.MonedaDocumento
            Case "US$"
                ent.MonedaDocumento = "1"
            Case "S/."
                ent.MonedaDocumento = "0"
            Case "EUR"
                ent.MonedaDocumento = "2"
        End Select
        Sql.AsignarParametro(Par.MonedaDocumento, ent.MonedaDocumento)

        Sql.AsignarParametro(Par.VentaTipoCambio, ent.VentaTipoCambio)
        Sql.AsignarParametro(Par.VentaEurTipoCambio, ent.VentaEurTipoCambio)
        Sql.AsignarParametro(Par.VentaTipoCambioOriginal, ent.VentaTipoCambioOriginal)
        Sql.AsignarParametro(Par.VentaEurTipoCambioOriginal, ent.VentaEurTipoCambioOriginal)
        Sql.AsignarParametro(Par.IgvPar, ent.IgvPar)
        Sql.AsignarParametro(Par.ImporteOriginalCuentaCorriente, ent.ImporteOriginalCuentaCorriente)
        Sql.AsignarParametro(Par.ImportePagadoCuentaCorriente, ent.ImportePagadoCuentaCorriente)
        Sql.AsignarParametro(Par.SaldoCuentaCorriente, ent.SaldoCuentaCorriente)
        Sql.AsignarParametro(Par.CodigoCuentaPcge, ent.CodigoCuentaPcge)

        Sql.AsignarParametro(Par.EstadoCuentaCorriente, ent.EstadoCuentaCorriente)
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
        Sql.AsignarParametro(Par.ClaveNotaCredito, ent.ClaveNotaCredito)
        Sql.AsignarParametro(Par.ValorNotaCredito, ent.ValorNotaCredito)
        Sql.AsignarParametro(Par.FlagSaldoNegativo, ent.FlagSaldoNegativo)

        '\\
    End Sub

    Function Objeto(ByRef iDr As IDataReader) As SuperEntidad
        '//Lo que se trae del sql
        Dim objEnc As New SuperEntidad
        objEnc.ClaveDocumentoCuentaCorriente = iDr(Campo.ClaveDocuCtaCte).ToString
        objEnc.CodigoEmpresa = iDr(Campo.CodEmp).ToString
        objEnc.RazonSocialEmpresa = iDr(Campo.RazSocEmp).ToString
        objEnc.PeriodoRegContabCabe = iDr(Campo.PeriodoRCC).ToString
        objEnc.CodigoOrigen = iDr(Campo.CodOriRC).ToString
        objEnc.NombreOrigen = iDr(Campo.NomOriRC).ToString
        objEnc.CodigoFile = iDr(Campo.CodFilRC).ToString
        objEnc.NombreFile = iDr(Campo.NomFilRC).ToString
        objEnc.NumeroVoucherRegContabCabe = iDr(Campo.NumVouRCC).ToString
        objEnc.ClaveCuentaCorriente = iDr(Campo.ClaveCtaCte).ToString
        objEnc.CodigoAuxiliar = iDr(Campo.CodAux).ToString
        objEnc.DescripcionAuxiliar = iDr(Campo.DesAux).ToString
        objEnc.TipoDocumento = iDr(Campo.CodTipDoc).ToString
        objEnc.NombreDocumento = iDr(Campo.NomTipDoc).ToString
        objEnc.SerieDocumento = iDr(Campo.SerDoC).ToString
        objEnc.NumeroDocumento = iDr(Campo.NumDoc).ToString
        objEnc.FechaDocumento = CType(iDr(Campo.FecDoc), DateTime)
        objEnc.FechaVctoDocumento = iDr(Campo.FecVctoDoc).ToString
        'Moneda documento
        Select Case iDr(Campo.MonDoc).ToString
            Case "0"
                objEnc.MonedaDocumento = "S/."
            Case "1"
                objEnc.MonedaDocumento = "US$"
            Case "2"
                objEnc.MonedaDocumento = "EUR"
        End Select
        objEnc.VentaTipoCambio = CType(iDr(Campo.VenTipCam), Decimal)
        objEnc.VentaEurTipoCambio = CType(iDr(Campo.VenEurTipCam), Decimal)
        objEnc.VentaTipoCambioOriginal = CType(iDr(Campo.VenTipCamOri), Decimal)
        objEnc.VentaEurTipoCambioOriginal = CType(iDr(Campo.VenEurTipCamOri), Decimal)
        objEnc.IgvPar = CType(iDr(Campo.IgvPar), Decimal)
        objEnc.ImporteOriginalCuentaCorriente = Math.Abs(CType(iDr(Campo.ImpOriCtaCte), Decimal))
        objEnc.ImportePagadoCuentaCorriente = Math.Abs(CType(iDr(Campo.ImpPagCtaCte), Decimal))
        objEnc.SaldoCuentaCorriente = Math.Abs(CType(iDr(Campo.SalCtaCte), Decimal))
        objEnc.CodigoCuentaPcge = iDr(Campo.CodCtaPcge).ToString
        objEnc.NombreCuentaPcge = iDr(Campo.NomCtaPcge).ToString
        objEnc.EstadoCuentaCorriente = iDr(Campo.EstCtaCte).ToString

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
        objEnc.ClaveNotaCredito = iDr(Campo.ClaNotCre).ToString
        objEnc.ValorNotaCredito = Math.Abs(CType(iDr(Campo.ValNotCre), Decimal))
        objEnc.FlagSaldoNegativo = iDr(Campo.FlaSalNeg).ToString

        'especial
        objEnc.CampoCursor = iDr(Campo.ClaveCtaCte).ToString
        Return objEnc
        '\\
    End Function

    Sub SpNuevoCuentaCorriente(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpNuevoCuentaCorriente")
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

    Sub SpModificarCuentaCorriente(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpModificarCuentaCorriente")
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

    Sub SpEliminarCuentaCorriente(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpEliminarCuentaCorriente")
            '/Asignar Parametro
            Sql.AsignarParametro(Par.ClaveCuentaCorriente, ent.ClaveCuentaCorriente)
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


    Function ListarDocumentosAPagarXEmpresaXAuxiliarYPendientes(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsCuentaCorriente")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodAux, SqlSelect.Operador.Igual, ent.CodigoAuxiliar)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.EstCtaCte, SqlSelect.Operador.Igual, "1") 'PENDIENTES
            sel.CondicionIn(SqlSelect.Reservada.Y, Campo.CodOriRC, "4,6")
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


    Function ListarDocumentosACobrarXEmpresaXAuxiliarYPendientes(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsCuentaCorriente")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodAux, SqlSelect.Operador.Igual, ent.CodigoAuxiliar)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.EstCtaCte, SqlSelect.Operador.Igual, "1") 'PENDIENTES
            sel.CondicionIn(SqlSelect.Reservada.Y, Campo.CodOriRC, "5")
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


    Function ListarDocumentosACobrarXEmpresaYPendientes(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsCuentaCorriente")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.EstCtaCte, SqlSelect.Operador.Igual, "1") 'PENDIENTES
            sel.CondicionIn(SqlSelect.Reservada.Y, Campo.CodOriRC, "5")
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


    Function ListarDocumentosAPagarXEmpresaYPendientes(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsCuentaCorriente")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.EstCtaCte, SqlSelect.Operador.Igual, "1") 'PENDIENTES
            sel.CondicionIn(SqlSelect.Reservada.Y, Campo.CodOriRC, "4,6")
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

    Function ListarCuentasCorrientesXEmpresaXPeriodoXDolaresYPendientes(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsCuentaCorriente")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.PeriodoRCC, SqlSelect.Operador.Igual, ent.PeriodoRegContabCabe)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.EstCtaCte, SqlSelect.Operador.Igual, "1") 'PENDIENTES
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.MonDoc, SqlSelect.Operador.Diferente, "0") 'DIFERENTE DE SOLES
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



    Function ListarCuentasCorrientesXEmpresaXDolaresYPendientes(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsCuentaCorriente")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.EstCtaCte, SqlSelect.Operador.Igual, "1") 'PENDIENTES
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.MonDoc, SqlSelect.Operador.Diferente, "0") 'DIFERENTE DE SOLES
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.PeriodoRCC, SqlSelect.Operador.MenorIgual, ent.PeriodoRegContabCabe)
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

    Function ReporteCuentasXPagar(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsCuentaCorriente")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.EstCtaCte, SqlSelect.Operador.Igual, "1") 'PENDIENTES
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.FecVctoDoc, SqlSelect.Operador.Diferente, "")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.FecVctoDoc, SqlSelect.Operador.MenorIgual, ent.FechaVctoDocumento) 'DIFERENTE DE SOLES
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodOriRC, SqlSelect.Operador.Diferente, "5")
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


    Function ReporteCuentasXCobrar(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsCuentaCorriente")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.EstCtaCte, SqlSelect.Operador.Igual, "1") 'PENDIENTES
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.FecVctoDoc, SqlSelect.Operador.Diferente, "")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.FecVctoDoc, SqlSelect.Operador.MenorIgual, ent.FechaVctoDocumento) 'DIFERENTE DE SOLES
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodOriRC, SqlSelect.Operador.Igual, "5")
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


    Function ListarRegistrosContablesDetalleParaDiferenciaCambio(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New RegContabDetaAD
        Return objAD.ListarRegistrosContablesDetalleParaDiferenciaCambio(ent)
        '\\
    End Function

    Sub SpModificarCuentaCorrienteMasivo(ByRef pLista As List(Of SuperEntidad))
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpModificarCuentaCorriente")
            For Each xMcc As SuperEntidad In pLista
                xMcc.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
                xMcc.NombreUsuarioAgrega = SuperEntidad.xNombreUsuario
                xMcc.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
                xMcc.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
                '/Asignar Parametros
                Me.SetParametros(xMcc)
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

    Function ListarCuentasCorrientesXEmpresaXDolares(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsCuentaCorriente")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.MonDoc, SqlSelect.Operador.Diferente, "0") 'DIFERENTE DE SOLES
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.PeriodoRCC, SqlSelect.Operador.MenorIgual, ent.PeriodoRegContabCabe)
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

    Sub SpEliminarCuentaCorrienteXGastoOperativo(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpEliminarCuentaCorrienteXGastoOperativo")
            '/Asignar Parametro
            Sql.AsignarParametro(Par.ClaveCuentaCorriente, ent.ClaveCuentaCorriente)
            '/Ejecutar sin resultado
            Sql.EjecutarSinResultado()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Sql.Desconectar()
        End Try
    End Sub

    Function ListarCuentasCorrientesParaAsientoDocumentosPendientes(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsCuentaCorriente")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionBetween(SqlSelect.Reservada.Y, Campo.FecDoc, ent.DatoCondicion1, ent.DatoCondicion2) 'fecha doc
            sel.CondicionBetween(SqlSelect.Reservada.Y, Campo.SalCtaCte, ent.DatoCondicion3, ent.DatoCondicion4) 'saldo doc
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodCtaPcge, SqlSelect.Operador.Igual, ent.CodigoCuentaPcge)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.EstCtaCte, SqlSelect.Operador.Igual, "1") 'pendientes
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
