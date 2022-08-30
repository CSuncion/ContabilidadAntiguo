Imports Entidad
Imports ScriptBaseDatos

Public Class PeriodoAD

    Private objCon As New SqlDatos
    Private Lista As New List(Of SuperEntidad)
    Private obj As New SuperEntidad
    Private Campo As New CamposEntidad
    Private Par As New ParametroSql
    Private eVista As String = "VsPeriodo"

    Sub SetParametros(ByRef ent As SuperEntidad)
        '//
        objCon.AsignarParametro(Par.ClavePeriodo, ent.ClavePeriodo)
        objCon.AsignarParametro(Par.CodigoEmpresa, ent.CodigoEmpresa)
        objCon.AsignarParametro(Par.CodigoPeriodo, ent.CodigoPeriodo)
        objCon.AsignarParametro(Par.CMesPeriodo, ent.CMesPeriodo)
        objCon.AsignarParametro(Par.CEstadoPeriodo, ent.CEstadoPeriodo)
        objCon.AsignarParametro(Par.ResultadoMes, ent.ResultadoMes)
        objCon.AsignarParametro(Par.ResultadoAcumulado, ent.ResultadoAcumulado)
        objCon.AsignarParametro(Par.CodigoUsuarioAgrega, ent.CodigoUsuarioAgrega)
        objCon.AsignarParametro(Par.NombreUsuarioAgrega, ent.NombreUsuarioAgrega)
        objCon.AsignarParametro(Par.FechaAgrega, ent.FechaAgrega)
        objCon.AsignarParametro(Par.CodigoUsuarioModifica, ent.CodigoUsuarioModifica)
        objCon.AsignarParametro(Par.NombreUsuarioModifica, ent.NombreUsuarioModifica)
        objCon.AsignarParametro(Par.FechaModifica, ent.FechaModifica)

        '\\
    End Sub

    Function Objeto(ByRef iDr As IDataReader) As SuperEntidad
        '//
        Dim objEnc As New SuperEntidad
        objEnc.ClavePeriodo = iDr(Campo.ClaPer).ToString
        objEnc.CodigoEmpresa = iDr(Campo.CodEmp).ToString
        objEnc.RazonSocialEmpresa = iDr(Campo.RazSocEmp).ToString
        objEnc.CodigoPeriodo = iDr(Campo.CodPer).ToString
        objEnc.CMesPeriodo = iDr(Campo.CMesPer).ToString
        objEnc.NMesPeriodo = iDr(Campo.NMesPer).ToString
        objEnc.CEstadoPeriodo = iDr(Campo.CEstPer).ToString
        objEnc.NEstadoPeriodo = iDr(Campo.NEstPer).ToString
        objEnc.ResultadoMes = CType(iDr(Campo.ResMes.ToString), Decimal)
        objEnc.ResultadoAcumulado = CType(iDr(Campo.ResAcu).ToString, Decimal)
        objEnc.CodigoUsuarioAgrega = iDr(Campo.CodUsuAgr).ToString
        objEnc.NombreUsuarioAgrega = iDr(Campo.NomUsuAgr).ToString
        objEnc.FechaAgrega = CType(iDr(Campo.FechaAgr), DateTime)
        objEnc.CodigoUsuarioModifica = iDr(Campo.CodUsuMod).ToString
        objEnc.NombreUsuarioModifica = iDr(Campo.NomUsuMod).ToString
        objEnc.FechaModifica = CType(iDr(Campo.FechaMod), DateTime)

        'especial
        objEnc.CampoCursor = iDr(Campo.ClaPer).ToString
        Return objEnc
        '\\
    End Function

    Sub SpNuevoPeriodo(ByRef ent As SuperEntidad)
        '//
        Try
            objCon.Conectar(SqlDatos.Bd.ContabilidadEmma)
            objCon.ComandoProcAlm("SpNuevoPeriodo")
            '/Asignar Parametros
            Me.SetParametros(ent)
            '/Ejecutar sin resultado
            objCon.EjecutarSinResultado()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            objCon.Desconectar()
        End Try
    End Sub

    Sub SpModificarPeriodo(ByRef ent As SuperEntidad)
        '//
        Try
            objCon.Conectar(SqlDatos.Bd.ContabilidadEmma)
            objCon.ComandoProcAlm("SpModificarPeriodo")
            '/Asignar Parametros
            Me.SetParametros(ent)
            '/Ejecutar sin resultado
            objCon.EjecutarSinResultado()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            objCon.Desconectar()
        End Try
    End Sub

    Sub SpEliminarPeriodo(ByRef ent As SuperEntidad)
        '//
        Try
            objCon.Conectar(SqlDatos.Bd.ContabilidadEmma)
            objCon.ComandoProcAlm("SpEliminarPeriodo")
            '/Asignar Parametro
            objCon.AsignarParametro(Par.ClavePeriodo, ent.ClavePeriodo)
            '/Ejecutar sin resultado
            objCon.EjecutarSinResultado()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            objCon.Desconectar()
        End Try
    End Sub

    Function Eliminar(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Try
            objCon.Conectar(SqlDatos.Bd.ContabilidadEmma)

            'ARMANDO SCRIPT PARA ACTUALIZAR
            Dim eli As New SqlDelete
            eli.Tabla("Periodo")

            Dim sel As New SqlSelect
            sel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoEmpresaEN.CodEmp, SqlSelect.Operador.Igual, ent.CodigoEmpresa)
            eli.CondicionDelete(sel.Script)

            'SCRIPT ARMADO
            objCon.ComandoText(eli.Script)

            'EJECUTAR SIN RESULTADO
            objCon.EjecutarSinResultado()

            Return obj
        Catch ex As Exception
            MsgBox(ex.Message) : Return obj
        Finally
            objCon.Desconectar()
        End Try
        '\\
    End Function


    Function SpObtenerRegistrosSinCondicion(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            objCon.Conectar(SqlDatos.Bd.ContabilidadEmma)
            objCon.ComandoProcAlm("SpObtenerRegistrosSinCondicion")
            '/Asignar Parametros
            objCon.AsignarParametro(Par.Vista, ent.Vista)
            objCon.AsignarParametro(Par.DatoEliminado, ent.DatoEliminado)
            objCon.AsignarParametro(Par.DatoEstado, ent.DatoEstado)
            objCon.AsignarParametro(Par.CampoOrden, ent.CampoOrden)
            '/Obtener IDr
            Dim iDr As IDataReader = objCon.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            objCon.Desconectar()
        End Try
        '\\
    End Function

    Function SpObtenerRegistrosConUnaCondicion(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            objCon.Conectar(SqlDatos.Bd.ContabilidadEmma)
            objCon.ComandoProcAlm("SpObtenerRegistrosConUnaCondicion")
            '/Asignar Parametros
            objCon.AsignarParametro(Par.Vista, ent.Vista)
            objCon.AsignarParametro(Par.DatoEliminado, ent.DatoEliminado)
            objCon.AsignarParametro(Par.DatoEstado, ent.DatoEstado)
            objCon.AsignarParametro(Par.CampoCondicion1, ent.CampoCondicion1)
            objCon.AsignarParametro(Par.DatoCondicion1, ent.DatoCondicion1)
            objCon.AsignarParametro(Par.CampoOrden, ent.CampoOrden)
            '/Obtener IDr
            Dim iDr As IDataReader = objCon.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            objCon.Desconectar()
        End Try
        '\\
    End Function

    Function SpObtenerRegistrosConDosCondicion(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            objCon.Conectar(SqlDatos.Bd.ContabilidadEmma)
            objCon.ComandoProcAlm("SpObtenerRegistrosConDosCondicion")
            '/Asignar Parametros
            objCon.AsignarParametro(Par.Vista, ent.Vista)
            objCon.AsignarParametro(Par.DatoEliminado, ent.DatoEliminado)
            objCon.AsignarParametro(Par.DatoEstado, ent.DatoEstado)
            objCon.AsignarParametro(Par.CampoCondicion1, ent.CampoCondicion1)
            objCon.AsignarParametro(Par.DatoCondicion1, ent.DatoCondicion1)
            objCon.AsignarParametro(Par.CampoCondicion2, ent.CampoCondicion2)
            objCon.AsignarParametro(Par.DatoCondicion2, ent.DatoCondicion2)
            objCon.AsignarParametro(Par.CampoOrden, ent.CampoOrden)
            '/Obtener IDr
            Dim iDr As IDataReader = objCon.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            objCon.Desconectar()
        End Try
        '\\
    End Function

    Function SpBuscarRegistroConUnaCondicion(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Try
            objCon.Conectar(SqlDatos.Bd.ContabilidadEmma)
            objCon.ComandoProcAlm("SpBuscarRegistroConUnaCondicion")
            '/Asignar Parametros
            objCon.AsignarParametro(Par.Vista, ent.Vista)
            objCon.AsignarParametro(Par.DatoEliminado, ent.DatoEliminado)
            objCon.AsignarParametro(Par.DatoEstado, ent.DatoEstado)
            objCon.AsignarParametro(Par.CampoCondicion1, ent.CampoCondicion1)
            objCon.AsignarParametro(Par.DatoCondicion1, ent.DatoCondicion1)
            '/Obtener IDr
            Dim iDr As IDataReader = objCon.ObtenerIDr
            While iDr.Read
                'Objeto Encontrado
                obj = Me.Objeto(iDr)
            End While
            Return obj
        Catch ex As Exception
            MsgBox(ex.Message) : Return obj
        Finally
            objCon.Desconectar()
        End Try
        '\\
    End Function

    Function SpBuscarRegistroConDosCondicion(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Try
            objCon.Conectar(SqlDatos.Bd.ContabilidadEmma)
            objCon.ComandoProcAlm("SpBuscarRegistroConDosCondicion")
            '/Asignar Parametros
            objCon.AsignarParametro(Par.Vista, ent.Vista)
            objCon.AsignarParametro(Par.DatoEliminado, ent.DatoEliminado)
            objCon.AsignarParametro(Par.DatoEstado, ent.DatoEstado)
            objCon.AsignarParametro(Par.CampoCondicion1, ent.CampoCondicion1)
            objCon.AsignarParametro(Par.DatoCondicion1, ent.DatoCondicion1)
            objCon.AsignarParametro(Par.CampoCondicion2, ent.CampoCondicion2)
            objCon.AsignarParametro(Par.DatoCondicion2, ent.DatoCondicion2)
            '/Obtener IDr
            Dim iDr As IDataReader = objCon.ObtenerIDr
            While iDr.Read
                'Objeto Encontrado
                obj = Me.Objeto(iDr)
            End While
            Return obj
        Catch ex As Exception
            MsgBox(ex.Message) : Return obj
        Finally
            objCon.Desconectar()
        End Try
        '\\
    End Function

    Function ListarPeriodosActivas(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            objCon.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista(Me.eVista)
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, ent.CodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CEstPer, SqlSelect.Operador.Igual, "1")

            sel.Orden(ent.CampoOrden, SqlSelect.Order.Asc)

            objCon.ComandoText(sel.Script)
            '/Obtener IDr
            Dim iDr As IDataReader = objCon.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            objCon.Desconectar()
        End Try
        '\\
    End Function

    Function ListarPeriodos(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            objCon.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista(Me.eVista)
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, ent.CodigoEmpresa)
            sel.Orden(ent.CampoOrden, SqlSelect.Order.Asc)

            objCon.ComandoText(sel.Script)
            '/Obtener IDr
            Dim iDr As IDataReader = objCon.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            objCon.Desconectar()
        End Try
        '\\
    End Function


    Function BuscarPeriodoXClave(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Try
            objCon.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista(Me.eVista)
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.ClaPer, SqlSelect.Operador.Igual, ent.ClavePeriodo)
            objCon.ComandoText(sel.Script)
            '/Obtener IDr
            Dim iDr As IDataReader = objCon.ObtenerIDr
            While iDr.Read
                'Objeto Encontrado
                obj = Me.Objeto(iDr)
            End While
            Return obj
        Catch ex As Exception
            MsgBox(ex.Message) : Return obj
        Finally
            objCon.Desconectar()
        End Try
        '\\
    End Function


End Class
