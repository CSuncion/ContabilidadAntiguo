Imports ScriptBaseDatos
Imports Entidad
Public Class SaldosBancariosAD
    Private objCon As New SqlDatos
    Private Sql As New SqlDatos
    Private Lista As New List(Of SuperEntidad)
    Private obj As New SuperEntidad
    Private Campo As New CamposEntidad
    Private Par As New ParametroSql

    Sub SetParametros(ByRef ent As SuperEntidad)
        '//
        Sql.AsignarParametro(Par.ClaveSaldosBancarios, ent.ClaveSaldosBancarios)
        Sql.AsignarParametro(Par.ClaveCuentaBanco, ent.ClaveCuentaBanco)

        Sql.AsignarParametro(Par.IngresosSolCuentaBanco, ent.IngresosSolCuentaBanco)
        Sql.AsignarParametro(Par.SalidasSolCuentaBanco, ent.SalidasSolCuentaBanco)
        Sql.AsignarParametro(Par.SaldoMesSolCuentaBanco, ent.SaldoMesSolCuentaBanco)
        Sql.AsignarParametro(Par.IngresosDolCuentaBanco, ent.IngresosDolCuentaBanco)
        Sql.AsignarParametro(Par.SalidasDolCuentaBanco, ent.SalidasDolCuentaBanco)
        Sql.AsignarParametro(Par.SaldoMesDolCuentaBanco, ent.SaldoMesDolCuentaBanco)
        Sql.AsignarParametro(Par.IngresosEurCuentaBanco, ent.IngresosEurCuentaBanco)
        Sql.AsignarParametro(Par.SalidasEurCuentaBanco, ent.SalidasEurCuentaBanco)
        Sql.AsignarParametro(Par.SaldoMesEurCuentaBanco, ent.SaldoMesEurCuentaBanco)

        Sql.AsignarParametro(Par.IngresosSolAntCuentaBanco, ent.IngresosSolAntCuentaBanco)
        Sql.AsignarParametro(Par.SalidasSolAntCuentaBanco, ent.SalidasSolAntCuentaBanco)
        Sql.AsignarParametro(Par.SaldoMesSolAntCuentaBanco, ent.SaldoMesSolAntCuentaBanco)
        Sql.AsignarParametro(Par.IngresosDolAntCuentaBanco, ent.IngresosDolAntCuentaBanco)
        Sql.AsignarParametro(Par.SalidasDolAntCuentaBanco, ent.SalidasDolAntCuentaBanco)
        Sql.AsignarParametro(Par.SaldoMesDolAntCuentaBanco, ent.SaldoMesDolAntCuentaBanco)
        Sql.AsignarParametro(Par.IngresosEurAntCuentaBanco, ent.IngresosEurAntCuentaBanco)
        Sql.AsignarParametro(Par.SalidasEurAntCuentaBanco, ent.SalidasEurAntCuentaBanco)
        Sql.AsignarParametro(Par.SaldoMesEurAntCuentaBanco, ent.SaldoMesEurAntCuentaBanco)

        Sql.AsignarParametro(Par.MesCuentaBanco, ent.MesCuentaBanco)
        Sql.AsignarParametro(Par.AnoCuentaBanco, ent.AnoCuentaBanco)

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
        objEnc.ClaveSaldosBancarios = iDr(Campo.ClaSalBan).ToString
        objEnc.ClaveCuentaBanco = iDr(Campo.ClaCtaBco).ToString
        objEnc.IngresosSolCuentaBanco = CType(iDr(Campo.IngSCtaBco).ToString, Decimal)
        objEnc.SalidasSolCuentaBanco = CType(iDr(Campo.SalSCtaBco).ToString, Decimal)
        objEnc.SaldoMesSolCuentaBanco = CType(iDr(Campo.SalmSCtaBco).ToString, Decimal)
        objEnc.IngresosDolCuentaBanco = CType(iDr(Campo.IngDCtaBco).ToString, Decimal)
        objEnc.SalidasDolCuentaBanco = CType(iDr(Campo.SalDCtaBco).ToString, Decimal)
        objEnc.SaldoMesDolCuentaBanco = CType(iDr(Campo.SalmDCtaBco).ToString, Decimal)
        objEnc.IngresosEurCuentaBanco = CType(iDr(Campo.IngECtaBco).ToString, Decimal)
        objEnc.SalidasEurCuentaBanco = CType(iDr(Campo.SalECtaBco).ToString, Decimal)
        objEnc.SaldoMesEurCuentaBanco = CType(iDr(Campo.SalmECtaBco).ToString, Decimal)

        objEnc.IngresosSolAntCuentaBanco = CType(iDr(Campo.IngSAntCtaBco).ToString, Decimal)
        objEnc.SalidasSolAntCuentaBanco = CType(iDr(Campo.SalSAntCtaBco).ToString, Decimal)
        objEnc.SaldoMesSolAntCuentaBanco = CType(iDr(Campo.SalmSAntCtaBco).ToString, Decimal)
        objEnc.IngresosDolAntCuentaBanco = CType(iDr(Campo.IngDAntCtaBco).ToString, Decimal)
        objEnc.SalidasDolAntCuentaBanco = CType(iDr(Campo.SalDAntCtaBco).ToString, Decimal)
        objEnc.SaldoMesDolAntCuentaBanco = CType(iDr(Campo.SalmDAntCtaBco).ToString, Decimal)
        objEnc.IngresosEurAntCuentaBanco = CType(iDr(Campo.IngEAntCtaBco).ToString, Decimal)
        objEnc.SalidasEurAntCuentaBanco = CType(iDr(Campo.SalEAntCtaBco).ToString, Decimal)
        objEnc.SaldoMesEurAntCuentaBanco = CType(iDr(Campo.SalmEAntCtaBco).ToString, Decimal)

        objEnc.MesCuentaBanco = iDr(Campo.MesCtaBco).ToString
        objEnc.AnoCuentaBanco = iDr(Campo.AnoCtaBco).ToString
        objEnc.Exporta = iDr(Campo.Exp).ToString
        objEnc.EstadoRegistro = iDr(Campo.EstReg).ToString
        objEnc.EliminadoRegistro = iDr(Campo.EliReg).ToString
        objEnc.CodigoUsuarioAgrega = iDr(Campo.CodUsuAgr).ToString
        objEnc.NombreUsuarioAgrega = iDr(Campo.NomUsuAgr).ToString
        objEnc.FechaAgrega = CType(iDr(Campo.FechaAgr), DateTime)
        objEnc.CodigoUsuarioModifica = iDr(Campo.CodUsuMod).ToString
        objEnc.NombreUsuarioModifica = iDr(Campo.NomUsuMod).ToString
        objEnc.FechaModifica = CType(iDr(Campo.FechaMod), DateTime)
        objEnc.CodigoCuentaBanco = iDr(Campo.CodCtaBco).ToString
        objEnc.BancoCuentaBanco = iDr(Campo.BcoCtaBco).ToString
        objEnc.NumeroCuentaBanco = iDr(Campo.NumCtaBco).ToString
        objEnc.EstadoCuentaBanco = iDr(Campo.EstCtaBco).ToString


        Select Case iDr(Campo.MonCtaBco).ToString
            Case "0" : objEnc.MonedaCuentaBanco = "Soles"
            Case "1" : objEnc.MonedaCuentaBanco = "Dolares"
            Case "2" : objEnc.MonedaCuentaBanco = "Euros"

        End Select


        Select Case iDr(Campo.TipCtaBco).ToString
            Case "0" : objEnc.TipoCuentaBanco = "CtaCte"
            Case "1" : objEnc.TipoCuentaBanco = "Ahorro"
        End Select

        '    objEnc.CodigoEmpresa = iDr(Campo.CodEmp).ToString
        'especial
        objEnc.CampoCursor = iDr(Campo.ClaCtaBco).ToString
        Return objEnc
        '\\
    End Function

    Sub SpNuevoSaldosBancarios(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpNuevoSaldosBancarios")
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

    Sub SpModificarSaldpsBancarios(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpModificarSaldosBancarios")
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

    Sub SpEliminarSaldosBancarios(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpEliminarSaldosBancarios")
            '/Asignar Parametro
            Sql.AsignarParametro(Par.ClaveCuentaBanco, ent.ClaveCuentaBanco)
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


    Function SpObtenerRegistrosConDosCondicionYMayorQue(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpObtenerRegistrosConDosCondicionYMayorQue")
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


    Function ListarSaldosBancariosDesdeMes(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsSaldosBancarios")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.ClaCtaBco, SqlSelect.Operador.Igual, ent.ClaveCuentaBanco)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.AnoCtaBco, SqlSelect.Operador.Igual, ent.AnoCuentaBanco)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.MesCtaBco, SqlSelect.Operador.MayorIgual, ent.MesCuentaBanco)

            sel.Orden(Campo.MesCtaBco, SqlSelect.Order.Asc)

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


    Function ListarSaldosBancariosExisActPorEmpresaXAnoYMes(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsSaldosBancarios")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, ent.CodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.EstCtaBco, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.AnoCtaBco, SqlSelect.Operador.Igual, ent.AnoCuentaBanco)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.MesCtaBco, SqlSelect.Operador.Igual, ent.MesCuentaBanco)

            sel.Orden(Campo.MesCtaBco, SqlSelect.Order.Asc)

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


    Function ListarSaldosBancariosParaCierreAnual(ByRef ent As SuperEntidad) As List(Of List(Of SuperEntidad))
        'LISTA RESULTADO
        Dim iLisXCta As New List(Of List(Of SuperEntidad))

        'CODIGO CUENTA
        Dim iCuenta As String = ""

        'INDICE DE LA LISTA ACTUAL EN iLisXCta
        Dim iIndice As Integer = -1

        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsSaldosBancarios")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, ent.CodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.AnoCtaBco, SqlSelect.Operador.Igual, ent.AnoCuentaBanco)
            sel.Orden(ent.CampoOrden, SqlSelect.Order.Asc)
            Sql.ComandoText(sel.Script)

            'Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                Dim iSalCon As New SuperEntidad
                iSalCon = Me.Objeto(iDr)

                'SI LAS CUENTAS NO SON IGUALES ENTONCES CREAMOS UNA NUEVA LISTA
                If iSalCon.CodigoCuentaBanco <> iCuenta Then

                    'ADICIONAMOS UNA LISTA PARA LA NUEVA CUENTA
                    'Y INSERTAMOS AL PRIMER OBJETO iRcd
                    Dim iLisC As New List(Of SuperEntidad)
                    iLisC.Add(iSalCon)

                    'INSERTAMOS ESTA LISTA A LA LISTA DE CUENTAS
                    iLisXCta.Add(iLisC)

                    'OBTENEMOS EL INDICE DE LA LISTA DE CUENTA EN LA LISTA DE CUENTAS
                    iIndice += 1

                    'PASAMOS EL NUEVO CODIGO A NUESTA VARIABLE DE CUENTA
                    iCuenta = iSalCon.CodigoCuentaBanco

                Else
                    iLisXCta(iIndice).Add(iSalCon)
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


    Sub NuevoSaldosBancariosMasivo(ByRef pLista As List(Of SuperEntidad))
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpNuevoSaldosBancarios")
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


    Sub EliminarSaldosBancariosXEmpresaYAno(ByRef objx As SuperEntidad)
        '/
        Try
            objCon.Conectar(SqlDatos.Bd.ContabilidadEmma)

            'ARMANDO SCRIPT PARA ACTUALIZAR
            Dim eli As New SqlDelete
            eli.Tabla("SaldosBancarios")

            Dim iScript As String = ""
            iScript += " Where SubString(ClaveCuentaBanco,1,3)=" + objx.CodigoEmpresa
            iScript += " and AnoCuentaBanco=" + objx.AnoCuentaBanco
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


End Class
