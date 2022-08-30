Imports Entidad
Imports ScriptBaseDatos
Public Class FormatoContableAd
    Private Sql As New SqlDatos
    Private Lista As New List(Of SuperEntidad)
    Private obj As New SuperEntidad
    Private Campo As New CamposEntidad
    Private Par As New ParametroSql

    Sub SetParametros(ByRef ent As SuperEntidad)
        '//
        Sql.AsignarParametro(Par.ClaveFormatoContable, ent.ClaveFormatoContable)
        Sql.AsignarParametro(Par.CodigoEmpresa, ent.CodigoEmpresa)
        Sql.AsignarParametro(Par.CodigoFormatoContable, ent.CodigoFormatoContable)
        Sql.AsignarParametro(Par.DescripcionFormatoContable, ent.DescripcionFormatoContable)
        'Grupo
        Select Case ent.GrupoFormatoContable
            Case "Activo Corriente"
                ent.GrupoFormatoContable = "1"
            Case "Activo No Corriente"
                ent.GrupoFormatoContable = "2"
            Case "Pasivo Corriente"
                ent.GrupoFormatoContable = "3"
            Case "Pasivo No Corriente"
                ent.GrupoFormatoContable = "4"
            Case "Patrimonio"
                ent.GrupoFormatoContable = "5"
            Case "Ventas"
                ent.GrupoFormatoContable = "6"
            Case "Gastos Ventas"
                ent.GrupoFormatoContable = "7"
            Case "Otros Gastos"
                ent.GrupoFormatoContable = "8"
            Case "Otros Ingresos"
                ent.GrupoFormatoContable = "9"
            Case "Otros Egresos"
                ent.GrupoFormatoContable = "0"
            Case "Acumulador"
                ent.GrupoFormatoContable = "a"
            Case "Totales"
                ent.GrupoFormatoContable = "t"
            Case "General"
                ent.GrupoFormatoContable = "g"
        End Select
        Sql.AsignarParametro(Par.GrupoFormatoContable, ent.GrupoFormatoContable)

        'Naturaleza
        Select Case ent.NaturalezaFormatoContable
            Case "Deudora"
                ent.NaturalezaFormatoContable = "1"
            Case "Acreedora"
                ent.NaturalezaFormatoContable = "2"
        End Select
        Sql.AsignarParametro(Par.NaturalezaFormatoContable, ent.NaturalezaFormatoContable)
        Sql.AsignarParametro(Par.ImporteSolesFormatoContable, ent.ImporteSolesFormatoContable)
        Sql.AsignarParametro(Par.ImporteDolaresFormatoContable, ent.ImporteDolaresFormatoContable)
        Sql.AsignarParametro(Par.ImporteEurosFormatoContable, ent.ImporteEurosFormatoContable)

        'Estado Cuenta
        Select Case ent.EstadoFormatoContable
            Case "Activo"
                ent.EstadoFormatoContable = "1"
            Case "Inactivo"
                ent.EstadoFormatoContable = "0"
        End Select
        'Select Case ent.EstadoRegistro
        '    Case "Activo"
        '        ent.EstadoRegistro = "1"
        '    Case "Desactivo"
        '        ent.EstadoRegistro = "0"
        'End Select
        Sql.AsignarParametro(Par.EstadoFormatoContable, ent.EstadoFormatoContable)
        Sql.AsignarParametro(Par.Descripcion1FormatoContable, ent.Descripcion1FormatoContable)
        Sql.AsignarParametro(Par.Exporta, ent.Exporta)
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
        objEnc.ClaveFormatoContable = iDr(Campo.ClaForCon).ToString
        objEnc.CodigoEmpresa = iDr(Campo.CodEmp).ToString
        objEnc.RazonSocialEmpresa = iDr(Campo.RazSocEmp).ToString
        objEnc.CodigoFormatoContable = iDr(Campo.CodForCon).ToString
        objEnc.DescripcionFormatoContable = iDr(Campo.DesForCon).ToString
        'Grupo
        Select Case iDr(Campo.GruForCon).ToString
            Case "1" : objEnc.GrupoFormatoContable = "Activo Corriente"
            Case "2" : objEnc.GrupoFormatoContable = "Activo No Corriente"
            Case "3" : objEnc.GrupoFormatoContable = "Pasivo Corriente"
            Case "4" : objEnc.GrupoFormatoContable = "Pasivo No Corriente"
            Case "5" : objEnc.GrupoFormatoContable = "Patrimonio"
            Case "6" : objEnc.GrupoFormatoContable = "Ventas"
            Case "7" : objEnc.GrupoFormatoContable = "Gastos Ventas"
            Case "8" : objEnc.GrupoFormatoContable = "Otros Gastos"
            Case "9" : objEnc.GrupoFormatoContable = "Otros Ingresos"
            Case "0" : objEnc.GrupoFormatoContable = "Otros Egresos"
            Case "a" : objEnc.GrupoFormatoContable = "Acumulador"
            Case "t" : objEnc.GrupoFormatoContable = "Totales"
            Case "g" : objEnc.GrupoFormatoContable = "General"
        End Select


        Select Case iDr(Campo.NatForCon).ToString
            Case "1" : objEnc.NaturalezaFormatoContable = "Deudora"
            Case "2" : objEnc.NaturalezaFormatoContable = "Acreedora"
        End Select

        objEnc.ImporteSolesFormatoContable = CType(iDr(Campo.ImpSolForCon).ToString, Decimal)
        objEnc.ImporteDolaresFormatoContable = CType(iDr(Campo.ImpDolForCon).ToString, Decimal)
        objEnc.ImporteEurosFormatoContable = CType(iDr(Campo.ImpEurForCon).ToString, Decimal)

        'If iDr(Campo.NatForCon).ToString = "1" Then
        '    objEnc.NaturalezaFormatoContable = "Deudora"
        'Else
        '    objEnc.NaturalezaFormatoContable = "Acreedora"
        'End If

        'estado
        Select Case iDr(Campo.EstForCon).ToString

            Case "1" : objEnc.EstadoFormatoContable = "Activo"
            Case "2" : objEnc.EstadoFormatoContable = "Inactivo"
        End Select

        'objEnc.Descripcion1FormatoContable = iDr(Campo.Des1ForCon).ToString
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
        objEnc.CampoCursor = iDr(Campo.CodForCon).ToString
        Return objEnc
        '\\
    End Function

    Sub SpNuevoFormatoContable(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpNuevoFormatoContable")
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

    Sub SpModificarFormatoContable(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpModificarFormatoContable")
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

    Sub SpEliminarFormatoContable(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpEliminarFormatoContable")
            '/Asignar Parametro
            Sql.AsignarParametro(Par.ClaveFormatoContable, ent.ClaveFormatoContable)
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

    Function ListarFormatoActivo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsFormatoContable")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, ent.CodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodForCon, SqlSelect.Operador.MayorIgual, "1000")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodForCon, SqlSelect.Operador.MenorIgual, "2999")

            sel.Orden(Campo.CodForCon, SqlSelect.Order.Asc)

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


    Function ListarFormatoPasivo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsFormatoContable")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, ent.CodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodForCon, SqlSelect.Operador.MayorIgual, "4000")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodForCon, SqlSelect.Operador.MenorIgual, "6999")

            sel.Orden(Campo.CodForCon, SqlSelect.Order.Asc)

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


    Function ListarFormatoDeBalanceGeneral(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsFormatoContable")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, ent.CodigoEmpresa)
            sel.CondicionIn(SqlSelect.Reservada.Y, Campo.GruForCon, "1,2,3,4,5")
            sel.Orden(Campo.CodForCon, SqlSelect.Order.Asc)

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

    Function ListarFormatoDeGananciaPerdida(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsFormatoContable")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, ent.CodigoEmpresa)
            sel.CondicionIn(SqlSelect.Reservada.Y, Campo.GruForCon, "6,7,8,9,0")
            sel.Orden(Campo.CodForCon, SqlSelect.Order.Asc)

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
