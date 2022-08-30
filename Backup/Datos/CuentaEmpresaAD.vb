Imports Entidad
Imports ScriptBaseDatos

Public Class CuentaEmpresaAD

    Private Sql As New SqlDatos
    Private Lista As New List(Of SuperEntidad)
    Private obj As New SuperEntidad
    Private Campo As New CamposEntidad
    Private Par As New ParametroSql

    Sub SetParametros(ByRef ent As SuperEntidad)
        '//
        Sql.AsignarParametro(Par.ClaveCuentaPcge, ent.ClaveCuentaPcge)
        Sql.AsignarParametro(Par.CodigoEmpresa, ent.CodigoEmpresa)
        Sql.AsignarParametro(Par.CodigoCuentaPcge, ent.CodigoCuentaPcge)
        Sql.AsignarParametro(Par.NombreCuentaPcge, ent.NombreCuentaPcge)
        'Flag Documento 
        Select Case ent.FlagDocumentoPcge
            Case "Si"
                ent.FlagDocumentoPcge = "1"
            Case "No"
                ent.FlagDocumentoPcge = "0"
        End Select
        Sql.AsignarParametro(Par.FlagDocumentoPcge, ent.FlagDocumentoPcge)
        'Flag Auxiliar 
        Select Case ent.FlagAuxiliarPcge
            Case "Si"
                ent.FlagAuxiliarPcge = "1"
            Case "No"
                ent.FlagAuxiliarPcge = "0"
        End Select
        Sql.AsignarParametro(Par.FlagAuxiliarPcge, ent.FlagAuxiliarPcge)
        'Flag Ccto
        Select Case ent.FlagCentroCostoPcge
            Case "Si"
                ent.FlagCentroCostoPcge = "1"
            Case "No"
                ent.FlagCentroCostoPcge = "0"
        End Select
        Sql.AsignarParametro(Par.FlagCentroCostoPcge, ent.FlagCentroCostoPcge)
        'Flag Almacen
        Select Case ent.FlagAlmacenPcge
            Case "Si"
                ent.FlagAlmacenPcge = "1"
            Case "No"
                ent.FlagAlmacenPcge = "0"
        End Select
        Sql.AsignarParametro(Par.FlagAlmacenPcge, ent.FlagAlmacenPcge)
        'Flag Area
        Select Case ent.FlagAreaPcge
            Case "Si"
                ent.FlagAreaPcge = "1"
            Case "No"
                ent.FlagAreaPcge = "0"
        End Select
        Sql.AsignarParametro(Par.FlagAreaPcge, ent.FlagAreaPcge)
        'Flag Flujo
        Select Case ent.FlagFlujoCajaPcge
            Case "Si"
                ent.FlagFlujoCajaPcge = "1"
            Case "No"
                ent.FlagFlujoCajaPcge = "0"
        End Select
        Sql.AsignarParametro(Par.FlagFlujoCajaPcge, ent.FlagFlujoCajaPcge)
        'Flag Automatica
        Select Case ent.FlagAutomaticaPcge
            Case "Si"
                ent.FlagAutomaticaPcge = "1"
            Case "No"
                ent.FlagAutomaticaPcge = "0"
        End Select
        Sql.AsignarParametro(Par.FlagAutomaticaPcge, ent.FlagAutomaticaPcge)
        'Flag DifCambio
        Select Case ent.FlagDifCambioPcge
            Case "Si"
                ent.FlagDifCambioPcge = "1"
            Case "No"
                ent.FlagDifCambioPcge = "0"
        End Select
        Sql.AsignarParametro(Par.FlagDifCambioPcge, ent.FlagDifCambioPcge)
        'Flag Tipo Cuenta
        Select Case ent.FlagTipoCuentaPcge
            Case "Si"
                ent.FlagTipoCuentaPcge = "1"
            Case "No"
                ent.FlagTipoCuentaPcge = "0"
        End Select

        Sql.AsignarParametro(Par.FlagTipoCuentaPcge, ent.FlagTipoCuentaPcge)
        'Estado Cuenta
        Select Case ent.EstadoCuenta
            Case "Activo"
                ent.EstadoCuenta = "1"
            Case "Anulado"
                ent.EstadoCuenta = "0"
        End Select
        Sql.AsignarParametro(Par.EstadoCuenta, ent.EstadoCuenta)
        Sql.AsignarParametro(Par.NumeroDigitosPcge, ent.NumeroDigitosPcge)
        Sql.AsignarParametro(Par.EstadoRegistro, ent.EstadoRegistro)
        Sql.AsignarParametro(Par.EliminadoRegistro, ent.EliminadoRegistro)
        Sql.AsignarParametro(Par.CodigoUsuarioAgrega, ent.CodigoUsuarioAgrega)
        Sql.AsignarParametro(Par.NombreUsuarioAgrega, ent.NombreUsuarioAgrega)
        Sql.AsignarParametro(Par.FechaAgrega, ent.FechaAgrega)
        Sql.AsignarParametro(Par.CodigoUsuarioModifica, ent.CodigoUsuarioModifica)
        Sql.AsignarParametro(Par.NombreUsuarioModifica, ent.NombreUsuarioModifica)
        Sql.AsignarParametro(Par.FechaModifica, ent.FechaModifica)
        Sql.AsignarParametro(Par.Exporta, ent.Exporta)

        '\\
    End Sub

    Function Objeto(ByRef iDr As IDataReader) As SuperEntidad
        '//
        Dim objEnc As New SuperEntidad
        objEnc.ClaveCuentaPcge = iDr(Campo.ClaCtaPcge).ToString
        objEnc.CodigoEmpresa = iDr(Campo.CodEmp).ToString
        objEnc.CodigoCuentaPcge = iDr(Campo.CodCtaPcge).ToString
        objEnc.NombreCuentaPcge = iDr(Campo.NomCtaPcge).ToString
        'Flag Documento
        If iDr(Campo.FlaDocPcge).ToString = "1" Then
            objEnc.FlagDocumentoPcge = "Si"
        Else
            objEnc.FlagDocumentoPcge = "No"
        End If
        'Flag Auxiliar
        If iDr(Campo.FlaAuxPcge).ToString = "1" Then
            objEnc.FlagAuxiliarPcge = "Si"
        Else
            objEnc.FlagAuxiliarPcge = "No"
        End If

        'Flag Ccosto
        If iDr(Campo.FlaCtoPcge).ToString = "1" Then
            objEnc.FlagCentroCostoPcge = "Si"
        Else
            objEnc.FlagCentroCostoPcge = "No"
        End If

        'Flag Almacen
        If iDr(Campo.FlaAlmPcge).ToString = "1" Then
            objEnc.FlagAlmacenPcge = "Si"
        Else
            objEnc.FlagAlmacenPcge = "No"
        End If

        'Flag Area
        If iDr(Campo.FlaArePcge).ToString = "1" Then
            objEnc.FlagAreaPcge = "Si"
        Else
            objEnc.FlagAreaPcge = "No"
        End If

        'objEnc.MontoComprobante = CType(iDr(Campo.MonComp).ToString, Decimal)
        'Flag Flujo
        If iDr(Campo.FlaFcaPcge).ToString = "1" Then
            objEnc.FlagFlujoCajaPcge = "Si"
        Else
            objEnc.FlagFlujoCajaPcge = "No"
        End If

        'Flag Automatica
        If iDr(Campo.FlaAutPcge).ToString = "1" Then
            objEnc.FlagAutomaticaPcge = "Si"
        Else
            objEnc.FlagAutomaticaPcge = "No"
        End If

        'Flag DifCambio
        If iDr(Campo.FlaDifPcge).ToString = "1" Then
            objEnc.FlagDifCambioPcge = "Si"
        Else
            objEnc.FlagDifCambioPcge = "No"
        End If

        'Flag EstadoCuenta
        If iDr(Campo.FlaTctPcge).ToString = "1" Then
            objEnc.FlagTipoCuentaPcge = "Si"
        Else
            objEnc.FlagTipoCuentaPcge = "No"
        End If

        'Estado Cuenta
        If iDr(Campo.EstCta).ToString = "1" Then
            objEnc.EstadoCuenta = "Activo"
        Else
            objEnc.EstadoCuenta = "Anulado"
        End If
        objEnc.NumeroDigitosPcge = iDr(Campo.NumDigPcge).ToString
        objEnc.EstadoRegistro = iDr(Campo.EstReg).ToString
        objEnc.EliminadoRegistro = iDr(Campo.EliReg).ToString
        objEnc.CodigoUsuarioAgrega = iDr(Campo.CodUsuAgr).ToString
        objEnc.NombreUsuarioAgrega = iDr(Campo.NomUsuAgr).ToString
        objEnc.FechaAgrega = CType(iDr(Campo.FechaAgr), DateTime)
        objEnc.CodigoUsuarioModifica = iDr(Campo.CodUsuMod).ToString
        objEnc.NombreUsuarioModifica = iDr(Campo.NomUsuMod).ToString
        objEnc.FechaModifica = CType(iDr(Campo.FechaMod), DateTime)
        objEnc.Exporta = iDr(Campo.Exp).ToString
        'especial
        objEnc.CampoCursor = iDr(Campo.CodCtaPcge).ToString
        Return objEnc
        '\\
    End Function

    'Function SpAutogenerarCodigoCliente() As String
    '    '//
    '    'Dim codigo As String = ""
    '    '   Try
    '    Sql.Conectar(SqlDatos.Bd.ControlLetras)
    '    Sql.ComandoProcAlm("SpAutogenerarCodigoCliente")
    '    Dim iDr As IDataReader = Sql.ObtenerIDr
    '    While iDr.Read
    '        codigo = iDr(0).ToString
    '    End While
    '    Return codigo
    '    Catch ex As Exception
    '        MsgBox(ex.Message) : Return codigo
    '    Finally
    '        Sql.Desconectar()
    '    End Try
    'End Function


    Sub SpNuevoPlanCuentaGe(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpNuevoPlanCuentaGe")
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

    Sub SpModificarPlanCuentaGe(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpModificarPlanCuentaGe")
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

    Sub SpEliminarPlanCuentaGe(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpEliminarPlanCuentaGe")
            '/Asignar Parametro
            Sql.AsignarParametro(Par.ClaveCuentaPcge, ent.ClaveCuentaPcge)
            '/Ejecutar sin resultado
            Sql.EjecutarSinResultado()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Sql.Desconectar()
        End Try
    End Sub

    Sub SpEliminarPlanCuentasGePorEmpresa(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpEliminarPlanCuentasGePorEmpresa")
            '/Asignar Parametro
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
            Sql.ComandoProcAlm("SpObtenerRegistrosConUnaCondicion")
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



    'Function SpBuscarRegistroConDosCondicion(ByRef ent As SuperEntidad) As SuperEntidad
    '    '//
    '    Try
    '        Sql.Conectar(SqlDatos.Bd.ControlLetras)
    '        Sql.ComandoProcAlm("SpBuscarRegistroConDosCondicion")
    '        '/Asignar Parametros
    '        Sql.AsignarParametro(Par.Vista, ent.Vista)
    '        Sql.AsignarParametro(Par.DatoEliminado, ent.DatoEliminado)
    '        Sql.AsignarParametro(Par.DatoEstado, ent.DatoEstado)
    '        Sql.AsignarParametro(Par.CampoCondicion1, ent.CampoCondicion1)
    '        Sql.AsignarParametro(Par.DatoCondicion1, ent.DatoCondicion1)
    '        Sql.AsignarParametro(Par.CampoCondicion2, ent.CampoCondicion2)
    '        Sql.AsignarParametro(Par.DatoCondicion2, ent.DatoCondicion2)
    '        '/Obtener IDr
    '        Dim iDr As IDataReader = Sql.ObtenerIDr
    '        While iDr.Read
    '            'Objeto Encontrado
    '            obj = Me.Objeto(iDr)
    '        End While
    '        Return obj
    '    Catch ex As Exception
    '        MsgBox(ex.Message) : Return obj
    '    Finally
    '        Sql.Desconectar()
    '    End Try
    '    '\\
    'End Function
End Class

