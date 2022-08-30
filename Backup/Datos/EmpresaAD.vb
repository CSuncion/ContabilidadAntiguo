Imports Entidad
Imports ScriptBaseDatos
Imports LibreriaGeneral

Public Class EmpresaAD
    Private Sql As New SqlDatos
    Private Lista As New List(Of SuperEntidad)
    Private obj As New SuperEntidad
    Private Campo As New CamposEntidad
    Private Par As New ParametroSql
    Private eVista As String = "VsEmpresa"
    Private tabla As String = "Empresa"


    Sub SetParametros(ByRef ent As SuperEntidad)
        '//
        Sql.AsignarParametro(Par.CodigoEmpresa, ent.CodigoEmpresa)
        Sql.AsignarParametro(Par.RazonSocialEmpresa, ent.RazonSocialEmpresa)
        Sql.AsignarParametro(Par.NombreCortoEmpresa, ent.NombreCortoEmpresa)
        Sql.AsignarParametro(Par.DireccionEmpresa, ent.direccionEmpresa)
        Sql.AsignarParametro(Par.RucEmpresa, ent.RucEmpresa)
        'Flag Empresa 
        Select Case ent.EstadoEmpresa
            Case "Activa"
                ent.EstadoEmpresa = "1"
            Case "Cerrada"
                ent.EstadoEmpresa = "0"
        End Select
        Sql.AsignarParametro(Par.EstadoEmpresa, ent.EstadoEmpresa)
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
        objEnc.CodigoEmpresa = iDr(Campo.CodEmp).ToString
        objEnc.RazonSocialEmpresa = iDr(Campo.RazSocEmp).ToString
        objEnc.NombreCortoEmpresa = iDr(Campo.NomCorEmp).ToString
        objEnc.direccionEmpresa = iDr(Campo.DirEmp).ToString
        objEnc.RucEmpresa = iDr(Campo.RucEmp).ToString
        'Estado Empresa
        If iDr(Campo.EstEmp).ToString = "1" Then
            objEnc.EstadoEmpresa = "Activa"
        Else
            objEnc.EstadoEmpresa = "Cerrada"
        End If
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
        objEnc.CampoCursor = iDr(Campo.CodEmp).ToString
        Return objEnc
        '\\
    End Function

    Sub SpNuevoEmpresa(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpNuevoEmpresa")
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

    Sub SpModificarEmpresa(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpModificarEmpresa")
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

    Sub SpEliminarEmpresa(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpEliminarEmpresa")
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

    Function BuscarEmpresaXCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista(Me.eVista)
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, ent.CodigoEmpresa)
            Sql.ComandoText(sel.Script)
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

End Class
