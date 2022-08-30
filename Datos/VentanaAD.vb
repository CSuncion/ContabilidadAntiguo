Imports Entidad

Public Class VentanaAD

      Private Sql As New SqlDatos
      Private Lista As New List(Of SuperEntidad)
      Private obj As New SuperEntidad
      Private Campo As New CamposEntidad
      Private Par As New ParametroSql


      Sub SetParametros(ByRef ent As SuperEntidad)
            '//
            Sql.AsignarParametro(Par.CodigoVentana, ent.CodigoVentana)
            Sql.AsignarParametro(Par.NombreVentana, ent.NombreVentana)
            'Estado
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
            Sql.AsignarParametro(Par.NombreUsuarioModifica, ent.NombreUsuarioModifica)
            Sql.AsignarParametro(Par.FechaModifica, ent.FechaModifica)
            '\\
      End Sub

      Function Objeto(ByRef iDr As IDataReader) As SuperEntidad
            '//
            Dim objEnc As New SuperEntidad
            objEnc.CodigoVentana = iDr(Campo.CodVen).ToString
            objEnc.NombreVentana = iDr(Campo.NomVen).ToString
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
            objEnc.CampoCursor = iDr(Campo.CodVen).ToString

            Return objEnc
            '\\
      End Function

      Sub SpNuevoVentana(ByRef ent As SuperEntidad)
            '//
            Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)

            Sql.ComandoProcAlm("SpNuevoVentana")
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

    Sub SpModificarVentana(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpModificarVentana")
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

    Sub SpEliminarVentana(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpEliminarVentana")
            Sql.AsignarParametro(Par.CodigoVentana, ent.CodigoVentana)
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

    Function SpObtenerRegistrosConUnaCondicionUnfiltro(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpObtenerRegistrosConUnaCondicionUnfiltro")
            '/Asignar Parametros
            Sql.AsignarParametro(Par.Vista, ent.Vista)
            Sql.AsignarParametro(Par.DatoEliminado, ent.DatoEliminado)
            Sql.AsignarParametro(Par.DatoEstado, ent.DatoEstado)
            Sql.AsignarParametro(Par.CampoCondicion1, ent.CampoCondicion1)
            Sql.AsignarParametro(Par.DatoCondicion1, ent.DatoCondicion1)
            Sql.AsignarParametro(Par.CampoFiltro1, ent.CampoFiltro1)
            Sql.AsignarParametro(Par.DatoFiltro1, ent.DatoFiltro1)
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


End Class
