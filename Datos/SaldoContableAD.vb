Imports Entidad
Imports ScriptBaseDatos
Public Class SaldoContableAD
    Private Sql As New SqlDatos
    Private Lista As New List(Of SuperEntidad)
    Private obj As New SuperEntidad
    Private Campo As New CamposEntidad
    Private Par As New ParametroSql
    Private Vista As String = "VsSaldoContable"

    Sub SetParametros(ByRef ent As SuperEntidad)
        '//
        Sql.AsignarParametro(Par.ClaveSaldoContable, ent.ClaveSaldoContable)
        Sql.AsignarParametro(Par.CodigoEmpresa, ent.CodigoEmpresa)
        Sql.AsignarParametro(Par.CodigoCuentaPcge, ent.CodigoCuentaPcge)
        Sql.AsignarParametro(Par.MesCreadoSaldoContable, ent.MesCreadoSaldoContable)
        Sql.AsignarParametro(Par.PeriodoRegContabCabe, ent.PeriodoRegContabCabe)
        Sql.AsignarParametro(Par.DebeS00SaldoContable, ent.DebeS00SaldoContable)
        Sql.AsignarParametro(Par.DebeS01SaldoContable, ent.DebeS01SaldoContable)
        Sql.AsignarParametro(Par.DebeS02SaldoContable, ent.DebeS02SaldoContable)
        Sql.AsignarParametro(Par.DebeS03SaldoContable, ent.DebeS03SaldoContable)
        Sql.AsignarParametro(Par.DebeS04SaldoContable, ent.DebeS04SaldoContable)
        Sql.AsignarParametro(Par.DebeS05SaldoContable, ent.DebeS05SaldoContable)
        Sql.AsignarParametro(Par.DebeS06SaldoContable, ent.DebeS06SaldoContable)
        Sql.AsignarParametro(Par.DebeS07SaldoContable, ent.DebeS07SaldoContable)
        Sql.AsignarParametro(Par.DebeS08SaldoContable, ent.DebeS08SaldoContable)
        Sql.AsignarParametro(Par.DebeS09SaldoContable, ent.DebeS09SaldoContable)
        Sql.AsignarParametro(Par.DebeS10SaldoContable, ent.DebeS10SaldoContable)
        Sql.AsignarParametro(Par.DebeS11SaldoContable, ent.DebeS11SaldoContable)
        Sql.AsignarParametro(Par.DebeS12SaldoContable, ent.DebeS12SaldoContable)
        Sql.AsignarParametro(Par.DebeS13SaldoContable, ent.DebeS13SaldoContable)
        Sql.AsignarParametro(Par.DebeS14SaldoContable, ent.DebeS14SaldoContable)
        Sql.AsignarParametro(Par.DebeS15SaldoContable, ent.DebeS15SaldoContable)

        Sql.AsignarParametro(Par.HabeS00SaldoContable, ent.HabeS00SaldoContable)
        Sql.AsignarParametro(Par.HabeS01SaldoContable, ent.HabeS01SaldoContable)
        Sql.AsignarParametro(Par.HabeS02SaldoContable, ent.HabeS02SaldoContable)
        Sql.AsignarParametro(Par.HabeS03SaldoContable, ent.HabeS03SaldoContable)
        Sql.AsignarParametro(Par.HabeS04SaldoContable, ent.HabeS04SaldoContable)
        Sql.AsignarParametro(Par.HabeS05SaldoContable, ent.HabeS05SaldoContable)
        Sql.AsignarParametro(Par.HabeS06SaldoContable, ent.HabeS06SaldoContable)
        Sql.AsignarParametro(Par.HabeS07SaldoContable, ent.HabeS07SaldoContable)
        Sql.AsignarParametro(Par.HabeS08SaldoContable, ent.HabeS08SaldoContable)
        Sql.AsignarParametro(Par.HabeS09SaldoContable, ent.HabeS09SaldoContable)
        Sql.AsignarParametro(Par.HabeS10SaldoContable, ent.HabeS10SaldoContable)
        Sql.AsignarParametro(Par.HabeS11SaldoContable, ent.HabeS11SaldoContable)
        Sql.AsignarParametro(Par.HabeS12SaldoContable, ent.HabeS12SaldoContable)
        Sql.AsignarParametro(Par.HabeS13SaldoContable, ent.HabeS13SaldoContable)
        Sql.AsignarParametro(Par.HabeS14SaldoContable, ent.HabeS14SaldoContable)
        Sql.AsignarParametro(Par.HabeS15SaldoContable, ent.HabeS15SaldoContable)

        Sql.AsignarParametro(Par.DebeD00SaldoContable, ent.DebeD00SaldoContable)
        Sql.AsignarParametro(Par.DebeD01SaldoContable, ent.DebeD01SaldoContable)
        Sql.AsignarParametro(Par.DebeD02SaldoContable, ent.DebeD02SaldoContable)
        Sql.AsignarParametro(Par.DebeD03SaldoContable, ent.DebeD03SaldoContable)
        Sql.AsignarParametro(Par.DebeD04SaldoContable, ent.DebeD04SaldoContable)
        Sql.AsignarParametro(Par.DebeD05SaldoContable, ent.DebeD05SaldoContable)
        Sql.AsignarParametro(Par.DebeD06SaldoContable, ent.DebeD06SaldoContable)
        Sql.AsignarParametro(Par.DebeD07SaldoContable, ent.DebeD07SaldoContable)
        Sql.AsignarParametro(Par.DebeD08SaldoContable, ent.DebeD08SaldoContable)
        Sql.AsignarParametro(Par.DebeD09SaldoContable, ent.DebeD09SaldoContable)
        Sql.AsignarParametro(Par.DebeD10SaldoContable, ent.DebeD10SaldoContable)
        Sql.AsignarParametro(Par.DebeD11SaldoContable, ent.DebeD11SaldoContable)
        Sql.AsignarParametro(Par.DebeD12SaldoContable, ent.DebeD12SaldoContable)
        Sql.AsignarParametro(Par.DebeD13SaldoContable, ent.DebeD13SaldoContable)
        Sql.AsignarParametro(Par.DebeD14SaldoContable, ent.DebeD14SaldoContable)
        Sql.AsignarParametro(Par.DebeD15SaldoContable, ent.DebeD15SaldoContable)

        Sql.AsignarParametro(Par.HabeD00SaldoContable, ent.HabeD00SaldoContable)
        Sql.AsignarParametro(Par.HabeD01SaldoContable, ent.HabeD01SaldoContable)
        Sql.AsignarParametro(Par.HabeD02SaldoContable, ent.HabeD02SaldoContable)
        Sql.AsignarParametro(Par.HabeD03SaldoContable, ent.HabeD03SaldoContable)
        Sql.AsignarParametro(Par.HabeD04SaldoContable, ent.HabeD04SaldoContable)
        Sql.AsignarParametro(Par.HabeD05SaldoContable, ent.HabeD05SaldoContable)
        Sql.AsignarParametro(Par.HabeD06SaldoContable, ent.HabeD06SaldoContable)
        Sql.AsignarParametro(Par.HabeD07SaldoContable, ent.HabeD07SaldoContable)
        Sql.AsignarParametro(Par.HabeD08SaldoContable, ent.HabeD08SaldoContable)
        Sql.AsignarParametro(Par.HabeD09SaldoContable, ent.HabeD09SaldoContable)
        Sql.AsignarParametro(Par.HabeD10SaldoContable, ent.HabeD10SaldoContable)
        Sql.AsignarParametro(Par.HabeD11SaldoContable, ent.HabeD11SaldoContable)
        Sql.AsignarParametro(Par.HabeD12SaldoContable, ent.HabeD12SaldoContable)
        Sql.AsignarParametro(Par.HabeD13SaldoContable, ent.HabeD13SaldoContable)
        Sql.AsignarParametro(Par.HabeD14SaldoContable, ent.HabeD14SaldoContable)
        Sql.AsignarParametro(Par.HabeD15SaldoContable, ent.HabeD15SaldoContable)
        Sql.AsignarParametro(Par.EstadoSaldoContable, ent.EstadoSaldoContable)
        Sql.AsignarParametro(Par.Exporta, ent.Exporta)
        Sql.AsignarParametro(Par.EstadoRegistro, ent.EstadoRegistro)
        Sql.AsignarParametro(Par.EliminadoRegistro, ent.EliminadoRegistro)
        Sql.AsignarParametro(Par.CodigoUsuarioAgrega, ent.CodigoUsuarioAgrega)
        Sql.AsignarParametro(Par.NombreUsuarioAgrega, ent.NombreUsuarioAgrega)
        Sql.AsignarParametro(Par.FechaAgrega, ent.FechaAgrega)
        Sql.AsignarParametro(Par.CodigoUsuarioModifica, ent.CodigoUsuarioModifica)
        Sql.AsignarParametro(Par.NombreUsuarioModifica, ent.NombreUsuarioModifica)
        Sql.AsignarParametro(Par.FechaModifica, ent.FechaModifica)

        '\\
    End Sub

    Function Objeto(ByRef iDr As IDataReader) As SuperEntidad
        '//
        Dim objEnc As New SuperEntidad
        objEnc.ClaveSaldoContable = iDr(Campo.ClaSalCon).ToString
        objEnc.CodigoEmpresa = iDr(Campo.CodEmp).ToString
        objEnc.RazonSocialEmpresa = iDr(Campo.RazSocEmp).ToString
        objEnc.CodigoCuentaPcge = iDr(Campo.CodCtaPcge).ToString
        objEnc.NombreCuentaPcge = iDr(Campo.NomCtaPcge).ToString
        objEnc.NumeroDigitosPcge = iDr(Campo.NumDigPcge).ToString
        objEnc.CodigoFormatoContable = iDr(Campo.CodForCon).ToString
        objEnc.ClaveFormatoContable = iDr(Campo.ClaForCon).ToString
        objEnc.DescripcionFormatoContable = iDr(Campo.DesForCon).ToString
        objEnc.FlagAuxiliarPcge = iDr(Campo.FlaAuxPcge).ToString
        objEnc.MesCreadoSaldoContable = iDr(Campo.MesCreSalCon).ToString
        objEnc.PeriodoRegContabCabe = iDr(Campo.PeriodoRCC).ToString
        objEnc.DebeS00SaldoContable = CType(iDr(Campo.DebS00SalCon), Decimal)
        objEnc.DebeS01SaldoContable = CType(iDr(Campo.DebS01SalCon), Decimal)
        objEnc.DebeS02SaldoContable = CType(iDr(Campo.DebS02SalCon), Decimal)
        objEnc.DebeS03SaldoContable = CType(iDr(Campo.DebS03SalCon), Decimal)
        objEnc.DebeS04SaldoContable = CType(iDr(Campo.DebS04SalCon), Decimal)
        objEnc.DebeS05SaldoContable = CType(iDr(Campo.DebS05SalCon), Decimal)
        objEnc.DebeS06SaldoContable = CType(iDr(Campo.DebS06SalCon), Decimal)
        objEnc.DebeS07SaldoContable = CType(iDr(Campo.DebS07SalCon), Decimal)
        objEnc.DebeS08SaldoContable = CType(iDr(Campo.DebS08SalCon), Decimal)
        objEnc.DebeS09SaldoContable = CType(iDr(Campo.DebS09SalCon), Decimal)
        objEnc.DebeS10SaldoContable = CType(iDr(Campo.DebS10SalCon), Decimal)
        objEnc.DebeS11SaldoContable = CType(iDr(Campo.DebS11SalCon), Decimal)
        objEnc.DebeS12SaldoContable = CType(iDr(Campo.DebS12SalCon), Decimal)
        objEnc.DebeS13SaldoContable = CType(iDr(Campo.DebS13SalCon), Decimal)
        objEnc.DebeS14SaldoContable = CType(iDr(Campo.DebS14SalCon), Decimal)
        objEnc.DebeS15SaldoContable = CType(iDr(Campo.DebS15SalCon), Decimal)

        objEnc.HabeS00SaldoContable = CType(iDr(Campo.HabS00SalCon), Decimal)
        objEnc.HabeS01SaldoContable = CType(iDr(Campo.HabS01SalCon), Decimal)
        objEnc.HabeS02SaldoContable = CType(iDr(Campo.HabS02SalCon), Decimal)
        objEnc.HabeS03SaldoContable = CType(iDr(Campo.HabS03SalCon), Decimal)
        objEnc.HabeS04SaldoContable = CType(iDr(Campo.HabS04SalCon), Decimal)
        objEnc.HabeS05SaldoContable = CType(iDr(Campo.HabS05SalCon), Decimal)
        objEnc.HabeS06SaldoContable = CType(iDr(Campo.HabS06SalCon), Decimal)
        objEnc.HabeS07SaldoContable = CType(iDr(Campo.HabS07SalCon), Decimal)
        objEnc.HabeS08SaldoContable = CType(iDr(Campo.HabS08SalCon), Decimal)
        objEnc.HabeS09SaldoContable = CType(iDr(Campo.HabS09SalCon), Decimal)
        objEnc.HabeS10SaldoContable = CType(iDr(Campo.HabS10SalCon), Decimal)
        objEnc.HabeS11SaldoContable = CType(iDr(Campo.HabS11SalCon), Decimal)
        objEnc.HabeS12SaldoContable = CType(iDr(Campo.HabS12SalCon), Decimal)
        objEnc.HabeS13SaldoContable = CType(iDr(Campo.HabS13SalCon), Decimal)
        objEnc.HabeS14SaldoContable = CType(iDr(Campo.HabS14SalCon), Decimal)
        objEnc.HabeS15SaldoContable = CType(iDr(Campo.HabS15SalCon), Decimal)


        objEnc.DebeD00SaldoContable = CType(iDr(Campo.DebD00SalCon), Decimal)
        objEnc.DebeD01SaldoContable = CType(iDr(Campo.DebD01SalCon), Decimal)
        objEnc.DebeD02SaldoContable = CType(iDr(Campo.DebD02SalCon), Decimal)
        objEnc.DebeD03SaldoContable = CType(iDr(Campo.DebD03SalCon), Decimal)
        objEnc.DebeD04SaldoContable = CType(iDr(Campo.DebD04SalCon), Decimal)
        objEnc.DebeD05SaldoContable = CType(iDr(Campo.DebD05SalCon), Decimal)
        objEnc.DebeD06SaldoContable = CType(iDr(Campo.DebD06SalCon), Decimal)
        objEnc.DebeD07SaldoContable = CType(iDr(Campo.DebD07SalCon), Decimal)
        objEnc.DebeD08SaldoContable = CType(iDr(Campo.DebD08SalCon), Decimal)
        objEnc.DebeD09SaldoContable = CType(iDr(Campo.DebD09SalCon), Decimal)
        objEnc.DebeD10SaldoContable = CType(iDr(Campo.DebD10SalCon), Decimal)
        objEnc.DebeD11SaldoContable = CType(iDr(Campo.DebD11SalCon), Decimal)
        objEnc.DebeD12SaldoContable = CType(iDr(Campo.DebD12SalCon), Decimal)
        objEnc.DebeD13SaldoContable = CType(iDr(Campo.DebD13SalCon), Decimal)
        objEnc.DebeD14SaldoContable = CType(iDr(Campo.DebD14SalCon), Decimal)
        objEnc.DebeD15SaldoContable = CType(iDr(Campo.DebD15SalCon), Decimal)

        objEnc.HabeD00SaldoContable = CType(iDr(Campo.HabD00SalCon), Decimal)
        objEnc.HabeD01SaldoContable = CType(iDr(Campo.HabD01SalCon), Decimal)
        objEnc.HabeD02SaldoContable = CType(iDr(Campo.HabD02SalCon), Decimal)
        objEnc.HabeD03SaldoContable = CType(iDr(Campo.HabD03SalCon), Decimal)
        objEnc.HabeD04SaldoContable = CType(iDr(Campo.HabD04SalCon), Decimal)
        objEnc.HabeD05SaldoContable = CType(iDr(Campo.HabD05SalCon), Decimal)
        objEnc.HabeD06SaldoContable = CType(iDr(Campo.HabD06SalCon), Decimal)
        objEnc.HabeD07SaldoContable = CType(iDr(Campo.HabD07SalCon), Decimal)
        objEnc.HabeD08SaldoContable = CType(iDr(Campo.HabD08SalCon), Decimal)
        objEnc.HabeD09SaldoContable = CType(iDr(Campo.HabD09SalCon), Decimal)
        objEnc.HabeD10SaldoContable = CType(iDr(Campo.HabD10SalCon), Decimal)
        objEnc.HabeD11SaldoContable = CType(iDr(Campo.HabD11SalCon), Decimal)
        objEnc.HabeD12SaldoContable = CType(iDr(Campo.HabD12SalCon), Decimal)
        objEnc.HabeD13SaldoContable = CType(iDr(Campo.HabD13SalCon), Decimal)
        objEnc.HabeD14SaldoContable = CType(iDr(Campo.HabD14SalCon), Decimal)
        objEnc.HabeD15SaldoContable = CType(iDr(Campo.HabD15SalCon), Decimal)



        objEnc.EstadoSaldoContable = iDr(Campo.EstSalCon).ToString

        objEnc.Exporta = iDr(Campo.Exp).ToString
        objEnc.EstadoRegistro = iDr(Campo.EstReg).ToString
        objEnc.EliminadoRegistro = iDr(Campo.EliReg).ToString
        objEnc.CodigoUsuarioAgrega = iDr(Campo.CodUsuAgr).ToString
        objEnc.NombreUsuarioAgrega = iDr(Campo.NomUsuAgr).ToString
        objEnc.FechaAgrega = CType(iDr(Campo.FechaAgr), DateTime)
        objEnc.CodigoUsuarioModifica = iDr(Campo.CodUsuMod).ToString
        objEnc.NombreUsuarioModifica = iDr(Campo.NomUsuMod).ToString
        objEnc.FechaModifica = CType(iDr(Campo.FechaMod), DateTime)

        'especial
        objEnc.CampoCursor = iDr(Campo.ClaSalCon).ToString
        Return objEnc
        '\\
    End Function

    Sub SpNuevoSaldoContable(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpNuevoSaldoContable")
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

    Sub SpModificarSaldoContable(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpModificarSaldoContable")
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

    Sub SpEliminarCuentaBanco(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpEliminarCuentaBanco")
            '/Asignar Parametro
            Sql.AsignarParametro(Par.CodigoCuentaBanco, ent.CodigoCuentaBanco)
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


    Function ListarCuentasBalanceXFuncion(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista(Me.Vista)
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.PeriodoRCC, SqlSelect.Operador.Igual, ent.PeriodoRegContabCabe) 'Solo va el año
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionIn(SqlSelect.Reservada.Y, Campo.CodCtaPcge, "70,74,69,95,94,77,97,73,75,76")
            'sel.Orden(Campo.CodAux, SqlSelect.Order.Asc)

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



    Function ListarSaldosContableXFormatoContable(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista(Me.Vista)
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.PeriodoRCC, SqlSelect.Operador.Igual, ent.PeriodoRegContabCabe) 'Solo va el año
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, ent.CodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodForCon, SqlSelect.Operador.Igual, ent.CodigoFormatoContable)
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


    Function ListarSaldosContableXPeriodoYAnaliticas(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista(Me.Vista)
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, ent.CodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.PeriodoRCC, SqlSelect.Operador.Igual, ent.PeriodoRegContabCabe) 'Solo va el año
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.NumDigPcge, SqlSelect.Operador.Igual, ent.NumeroDigitosPcge)
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

    Function ListarSaldosContableParaCierreAnual(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista(Me.Vista)
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, ent.CodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.PeriodoRCC, SqlSelect.Operador.Igual, ent.PeriodoRegContabCabe) 'Solo va el año
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.NumDigPcge, SqlSelect.Operador.Igual, ent.NumeroDigitosPcge)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodCtaPcge, SqlSelect.Operador.MayorIgual, "10")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodCtaPcge, SqlSelect.Operador.Menor, "60")
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


    Sub SpNuevoSaldoContableMasivo(ByRef pLista As List(Of SuperEntidad))
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpNuevoSaldoContable")
            For Each xSal As SuperEntidad In pLista
                xSal.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
                xSal.NombreUsuarioAgrega = SuperEntidad.xNombreUsuario
                xSal.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
                xSal.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
                '/Asignar Parametros
                Me.SetParametros(xSal)
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


    Sub SpModificarSaldoContableMasivo(ByRef pLista As List(Of SuperEntidad))
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpModificarSaldoContable")
            For Each xSal As SuperEntidad In pLista
                xSal.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
                xSal.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
                '/Asignar Parametros
                Me.SetParametros(xSal)
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


End Class
