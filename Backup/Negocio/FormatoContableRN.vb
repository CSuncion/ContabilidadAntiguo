Imports Entidad
Imports Datos
Imports LibreriaGeneral


Public Class FormatoContableRN
    Dim Cam As New CamposEntidad
    Public paren As New SuperEntidad
    Public par As New ParametroRN
    Dim PorImpuestoRenta As Decimal = 0
    Const vista As String = "VsFormatoContable"

    Sub nuevaFormatoContable(ByRef ent As SuperEntidad)
        '//
        '/Estos Datos son por defecto cada vez que agregue un nuevo usuario
        'ent.FlagTipoCuentaPcge = "1" '/Cuando no se captura en el formulario
        ent.EstadoCuenta = "1"
        ent.EstadoRegistro = "1"
        ent.EliminadoRegistro = "1"
        ent.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioAgrega = SuperEntidad.xNombreUsuario
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        ent.ClaveFormatoContable = ent.CodigoEmpresa + ent.CodigoFormatoContable

        Dim objAD As New FormatoContableAd
        objAD.SpNuevoFormatoContable(ent)
        '\\
    End Sub

    Sub modificarFormatoContable(ByRef ent As SuperEntidad)
        '//
        '/Vovemos a traer el usuario actual de la b.d
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        '/Vovemos a traer el usuario actual de la b.d

        ''/Mandamos a modificar la b.d
        Dim objAD As New FormatoContableAd
        objAD.SpModificarFormatoContable(ent)
        '\\
    End Sub

    Sub eliminarFormatoContableLog(ByRef ent As SuperEntidad)
        '//
        '/Datos por defecto
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        ent.EliminadoRegistro = "0"
        '/Mandamos a modificar la b.d
        Dim objAD As New FormatoContableAd
        objAD.SpModificarFormatoContable(ent)
        '\\
    End Sub

    Sub eliminarFormatoContableFis(ByRef ent As SuperEntidad)
        '//
        '/Mandamos a modificar la b.d
        Dim objAD As New FormatoContableAd
        objAD.SpEliminarFormatoContable(ent)
        '\\
    End Sub

    Function obtenerFormatoContableExis(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.CodEmp
        ent.DatoCondicion1 = ent.CodigoEmpresa
        Dim objAD As New FormatoContableAd
        listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerFormatoContableExisAct(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        Dim objAD As New FormatoContableAd
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerFormatoContableEli(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        Dim objAD As New FormatoContableAd
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function buscarFormatoContableExisPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.CodForCon
        ent.DatoCondicion1 = ent.CodigoFormatoContable
        Dim objAD As New FormatoContableAd
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarFormatoContableActPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = Cam.CodForCon
        Dim objAD As New FormatoContableAd
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarFormatoContableEliPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaForCon
        'ent.DatoCondicion1 = ent.ClaveFormatoContable
        Dim objAD As New FormatoContableAd
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarFormatoContableExisPorNombre(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.DesForCon
        Dim objAD As New FormatoContableAd
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function existeFormatoContablePorCodigo(ByRef ent As SuperEntidad) As Boolean
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = ""
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.CodForCon
        ent.DatoCondicion1 = ent.CodigoFormatoContable

        Dim bcoAD As New FormatoContableAd
        obj = bcoAD.SpBuscarRegistroConUnaCondicion(ent)
        If obj.CodigoFormatoContable = "" Then
            Return False
        Else
            Return True
        End If
        '\\
    End Function

    Function existeFormatoContablePorClave(ByRef ent As SuperEntidad) As Boolean
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = ""
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaForCon
        ent.DatoCondicion1 = ent.ClaveFormatoContable

        Dim bcoAD As New FormatoContableAd
        obj = bcoAD.SpBuscarRegistroConUnaCondicion(ent)
        If obj.ClaveFormatoContable = "" Then
            Return False
        Else
            Return True
        End If
        '\\
    End Function

    Function buscarFormatoContableExisPorClave(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaForCon
        ent.DatoCondicion1 = ent.ClaveFormatoContable
        Dim objAD As New FormatoContableAd
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function ListarFormatoActivo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New FormatoContableAd
        Return objAD.ListarFormatoActivo(ent)
        '\\
    End Function

    Function ListarFormatoDeBalanceGeneral(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New FormatoContableAd
        Return objAD.ListarFormatoDeBalanceGeneral(ent)
        '\\
    End Function



    Function ListarFormatoPasivo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New FormatoContableAd
        Return objAD.ListarFormatoPasivo(ent)
        '\\
    End Function

    Function ListarFormatoPasivoConBlanco(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim lis, lisRes As New List(Of SuperEntidad)
        lis = Me.ListarFormatoPasivo(ent)
        For Each xob As SuperEntidad In lis
            lisRes.Add(xob)
            If xob.GrupoFormatoContable = "Titulo" Or xob.GrupoFormatoContable = "Acumulador" Then
                Dim obj As New SuperEntidad
                obj.DescripcionFormatoContable = ""
                lisRes.Add(obj)

            End If
        Next
        Return lisRes
        '\\
    End Function


    Function ListarFormatoActivoConBlanco(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim lis, lisRes As New List(Of SuperEntidad)
        lis = Me.ListarFormatoActivo(ent)
        For Each xob As SuperEntidad In lis
            lisRes.Add(xob)
            If xob.GrupoFormatoContable = "Titulo" Or xob.GrupoFormatoContable = "Acumulador" Then
                Dim obj As New SuperEntidad
                obj.DescripcionFormatoContable = ""
                lisRes.Add(obj)

            End If
        Next
        Return lisRes
        '\\
    End Function

    Function existeFormatoContableEnEmpresa(ByRef ent As SuperEntidad) As Boolean
        '//
        Dim listObj As New List(Of SuperEntidad)
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.CodEmp
        ent.DatoCondicion1 = ent.CodigoEmpresa
        ent.CampoOrden = Cam.CodEmp
        Dim pgcAD As New FormatoContableAd
        listObj = pgcAD.SpObtenerRegistrosConUnaCondicion(ent)
        If listObj.Count = 0 Then
            Return False
        Else
            Return True
        End If
        '\\
    End Function

    Public Function ListarSaldosXFormatoContableBalanceGeneral(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim iLisRes As New List(Of SuperEntidad)

        'Traer lista formato contable de la empresa
        Dim iFc As New SuperEntidad
        iFc.CodigoEmpresa = ent.CodigoEmpresa
        iFc.CampoOrden = Cam.GruForCon + "," + Cam.CodForCon
        Dim iLisFc As List(Of SuperEntidad) = Me.ListarFormatoDeBalanceGeneral(iFc)

        'Vriables
        Dim iForCon As String = ""
        Dim iIndice As Integer = -1
        Dim iMes As String = ent.PeriodoRegContabCabe.Substring(4)
        Dim iSalConRN As New SaldoContableRN
        Dim iSalConEN As New SuperEntidad
        iSalConEN.CodigoEmpresa = ent.CodigoEmpresa
        iSalConEN.PeriodoRegContabCabe = ent.PeriodoRegContabCabe.Substring(0, 4)
        iSalConEN.CampoOrden = Cam.ClaSalCon

        For Each xFc As SuperEntidad In iLisFc
            iSalConEN.CodigoFormatoContable = xFc.CodigoFormatoContable
            Dim iLisSalCon As List(Of SuperEntidad) = iSalConRN.ListarSaldosContableXFormatoContable(iSalConEN)

            If iLisSalCon.Count <> 0 Then
                'Formato Contable con saldo
                Dim isc As New SuperEntidad
                isc.CodigoFormatoContable = xFc.CodigoFormatoContable
                isc.DescripcionFormatoContable = xFc.DescripcionFormatoContable
                isc.GrupoFormatoContable = xFc.GrupoFormatoContable

                If xFc.GrupoFormatoContable = "Activo Corriente" Then
                    For Each xsc As SuperEntidad In iLisSalCon
                        isc.SaldoCuentaBanco += iSalConRN.obtenerDiferenciaDebeHaber(xsc, iMes)  'Saldo del mes
                        isc.SaldoCuentaCorriente += iSalConRN.obtenerDiferenciaDebeHaberAcumulado(xsc, iMes) 'Saldo acumulado
                    Next
                    iLisRes.Add(isc)
                    'If isc.SaldoCuentaCorriente >= 0 Then
                    '    iLisRes.Add(isc)
                    'Else
                    '    If xFc.Descripcion1FormatoContable <> "" Then
                    '        'creando al pasivo
                    '        Dim ipas As New SuperEntidad
                    '        ipas.GrupoFormatoContable = "Pasivo Corriente"
                    '        ipas.DescripcionFormatoContable = xFc.Descripcion1FormatoContable
                    '        ipas.SaldoCuentaBanco = Math.Abs(isc.SaldoCuentaBanco)
                    '        ipas.SaldoCuentaCorriente = Math.Abs(isc.SaldoCuentaCorriente)
                    '        iLisRes.Add(ipas)
                    '        'modificando al activo
                    '        isc.SaldoCuentaCorriente = 0
                    '        iLisRes.Add(isc)
                    '    End If
                    'End If

                End If

                If xFc.GrupoFormatoContable = "Activo No Corriente" Then
                    For Each xsc As SuperEntidad In iLisSalCon
                        isc.SaldoCuentaBanco += iSalConRN.obtenerDiferenciaDebeHaber(xsc, iMes)  'Saldo del mes
                        isc.SaldoCuentaCorriente += iSalConRN.obtenerDiferenciaDebeHaberAcumulado(xsc, iMes) 'Saldo acumulado
                    Next
                    iLisRes.Add(isc)
                    'If isc.SaldoCuentaCorriente >= 0 Then
                    '    iLisRes.Add(isc)
                    'Else
                    '    If xFc.Descripcion1FormatoContable <> "" Then
                    '        'creando al pasivo
                    '        Dim ipas As New SuperEntidad
                    '        ipas.GrupoFormatoContable = "Pasivo No Corriente"
                    '        ipas.DescripcionFormatoContable = xFc.Descripcion1FormatoContable
                    '        ipas.SaldoCuentaBanco = Math.Abs(isc.SaldoCuentaBanco)
                    '        ipas.SaldoCuentaCorriente = Math.Abs(isc.SaldoCuentaCorriente)
                    '        iLisRes.Add(ipas)
                    '        'modificando al activo
                    '        isc.SaldoCuentaCorriente = 0
                    '        iLisRes.Add(isc)
                    '    End If
                    'End If
                End If

                If xFc.GrupoFormatoContable <> "Activo Corriente" And xFc.GrupoFormatoContable <> "Activo No Corriente" Then

                    For Each xsc As SuperEntidad In iLisSalCon
                        isc.SaldoCuentaBanco += iSalConRN.obtenerDiferenciaDebeHaber(xsc, iMes)  'Saldo del mes
                        isc.SaldoCuentaCorriente += iSalConRN.obtenerDiferenciaDebeHaberAcumulado(xsc, iMes) 'Saldo acumulado
                    Next
                    isc.SaldoCuentaBanco = isc.SaldoCuentaBanco * (-1)
                    isc.SaldoCuentaCorriente = isc.SaldoCuentaCorriente * (-1)
                    iLisRes.Add(isc)
                End If
            End If

            
        Next
        'Creando el objeto resultado del ejercicio
        Dim iRes As New SuperEntidad
        iRes.GrupoFormatoContable = "Patrimonio"
        iRes.DescripcionFormatoContable = "RESULTADO DEL EJERCICIO"

        ' Traendo el objeto periodo del proceso actual
        Dim iPerRN As New PeriodoRN
        Dim iPer As New SuperEntidad
        iPer.ClavePeriodo = ent.CodigoEmpresa + "-" + ent.PeriodoRegContabCabe
        iPer = iPerRN.BuscarPeriodoXClave(iPer)

        iRes.SaldoCuentaBanco = iPer.ResultadoMes 'El campo del mes del periodo
        iRes.SaldoCuentaCorriente = iPer.ResultadoAcumulado 'Acumulado del periodo
        iLisRes.Add(iRes)

        Return iLisRes
    End Function

    Function ObtenerReporteBalanceGeneral(ByVal ent As SuperEntidad) As List(Of List(Of SuperEntidad))
        'Lista de resultados
        Dim iLisRes As New List(Of List(Of SuperEntidad))

        'Obtener lista de saldos de formato contable
        Dim pListaSaldos As List(Of SuperEntidad) = Me.ListarSaldosXFormatoContableBalanceGeneral(ent)

        'Crear las 5 listas de titulos
        Dim iLisActCor As New List(Of SuperEntidad)
        Dim iLisActNCor As New List(Of SuperEntidad)
        Dim iLisPasCor As New List(Of SuperEntidad)
        Dim iLisPasNCor As New List(Of SuperEntidad)
        Dim iLisPat As New List(Of SuperEntidad)

        'Crear el primer objeto(Titulo) para cada lista
        Dim iTit As SuperEntidad
        iTit = New SuperEntidad
        iTit.DescripcionFormatoContable = "ACTIVO CORRIENTE"
        iTit.DatoCondicion1 = ""
        iTit.DatoCondicion2 = ""
        iLisActCor.Add(iTit)

        iTit = New SuperEntidad
        iTit.DescripcionFormatoContable = "ACTIVO NO CORRIENTE"
        iTit.DatoCondicion1 = ""
        iTit.DatoCondicion2 = ""
        iLisActNCor.Add(iTit)

        iTit = New SuperEntidad
        iTit.DescripcionFormatoContable = "PASIVO CORRIENTE"
        iTit.DatoCondicion1 = ""
        iTit.DatoCondicion2 = ""
        iLisPasCor.Add(iTit)

        iTit = New SuperEntidad
        iTit.DescripcionFormatoContable = "PASIVO NO CORRIENTE"
        iTit.DatoCondicion1 = ""
        iTit.DatoCondicion2 = ""
        iLisPasNCor.Add(iTit)

        iTit = New SuperEntidad
        iTit.DescripcionFormatoContable = "PATRIMONIO"
        iTit.DatoCondicion1 = ""
        iTit.DatoCondicion2 = ""
        iLisPat.Add(iTit)

        'Variables totales
        Dim iTotActCor As Decimal = 0
        Dim iTotActCorA As Decimal = 0
        Dim iTotActNCor As Decimal = 0
        Dim iTotActNCorA As Decimal = 0
        Dim iTotPasCor As Decimal = 0
        Dim iTotPasCorA As Decimal = 0
        Dim iTotPasNCor As Decimal = 0
        Dim iTotPasNCorA As Decimal = 0
        Dim iTotPat As Decimal = 0
        Dim iTotPatA As Decimal = 0

        'Cargando los formatos contables
        For Each xSal As SuperEntidad In pListaSaldos

            Dim iForCon As New SuperEntidad
            iForCon.DescripcionFormatoContable = Space(3) + xSal.DescripcionFormatoContable
            If xSal.SaldoCuentaBanco < 0 Then
                iForCon.DatoCondicion1 = "(" + Formato.NumeroConDecimal(Math.Abs(xSal.SaldoCuentaBanco).ToString, 2) + ")"
            Else
                iForCon.DatoCondicion1 = Formato.NumeroConDecimal(xSal.SaldoCuentaBanco.ToString, 2)
            End If

            If xSal.SaldoCuentaCorriente < 0 Then
                iForCon.DatoCondicion2 = "(" + Formato.NumeroConDecimal(Math.Abs(xSal.SaldoCuentaCorriente).ToString, 2) + ")"
            Else
                iForCon.DatoCondicion2 = Formato.NumeroConDecimal(xSal.SaldoCuentaCorriente.ToString, 2)
            End If

            'Acumulando totales insertar los formatos contables a su respectiva lista
            Select Case xSal.GrupoFormatoContable
                Case "Activo Corriente"
                    iTotActCor += xSal.SaldoCuentaBanco
                    iTotActCorA += xSal.SaldoCuentaCorriente
                    iLisActCor.Add(iForCon)
                Case "Activo No Corriente"
                    iTotActNCor += xSal.SaldoCuentaBanco
                    iTotActNCorA += xSal.SaldoCuentaCorriente
                    iLisActNCor.Add(iForCon)
                Case "Pasivo Corriente"
                    iTotPasCor += xSal.SaldoCuentaBanco
                    iTotPasCorA += xSal.SaldoCuentaCorriente
                    iLisPasCor.Add(iForCon)
                Case "Pasivo No Corriente"
                    iTotPasNCor += xSal.SaldoCuentaBanco
                    iTotPasNCorA += xSal.SaldoCuentaCorriente
                    iLisPasNCor.Add(iForCon)
                Case "Patrimonio"
                    iTotPat += xSal.SaldoCuentaBanco
                    iTotPatA += xSal.SaldoCuentaCorriente
                    iLisPat.Add(iForCon)
            End Select
        Next

        'Creando las lineas de subtotales
        Dim iLin As SuperEntidad
        iLin = New SuperEntidad
        iLin = Me.ObtenerLinea
        iLisActCor.Add(iLin)

        iLin = New SuperEntidad
        iLin = Me.ObtenerLinea
        iLisActNCor.Add(iLin)

        iLin = New SuperEntidad
        iLin = Me.ObtenerLinea
        iLisPasCor.Add(iLin)

        iLin = New SuperEntidad
        iLin = Me.ObtenerLinea
        iLisPasNCor.Add(iLin)

        iLin = New SuperEntidad
        iLin = Me.ObtenerLinea
        iLisPat.Add(iLin)

        'Agregando los subtotales por lista
        'Para Activo Corriente
        Dim iTotForCon As SuperEntidad
        iTotForCon = New SuperEntidad
        iTotForCon.DescripcionFormatoContable = Space(4) + "TOTAL ACTIVO CORRIENTE"
        If iTotActCor < 0 Then
            iTotForCon.DatoCondicion1 = "(" + Formato.NumeroConDecimal(Math.Abs(iTotActCor).ToString, 2) + ")"
        Else
            iTotForCon.DatoCondicion1 = Formato.NumeroConDecimal(iTotActCor.ToString, 2)
        End If

        If iTotActCorA < 0 Then
            iTotForCon.DatoCondicion2 = "(" + Formato.NumeroConDecimal(Math.Abs(iTotActCorA).ToString, 2) + ")"
        Else
            iTotForCon.DatoCondicion2 = Formato.NumeroConDecimal(iTotActCorA.ToString, 2)
        End If
        iTotForCon.DatoCondicion1 = Space(1) + iTotForCon.DatoCondicion1
        iTotForCon.DatoCondicion2 = Space(1) + iTotForCon.DatoCondicion2
        iLisActCor.Add(iTotForCon)

        'Para Activo No Corriente
        iTotForCon = New SuperEntidad
        iTotForCon.DescripcionFormatoContable = Space(4) + "TOTAL ACTIVO NO CORRIENTE"
        If iTotActNCor < 0 Then
            iTotForCon.DatoCondicion1 = "(" + Formato.NumeroConDecimal(Math.Abs(iTotActNCor).ToString, 2) + ")"
        Else
            iTotForCon.DatoCondicion1 = Formato.NumeroConDecimal(iTotActNCor.ToString, 2)
        End If

        If iTotActNCorA < 0 Then
            iTotForCon.DatoCondicion2 = "(" + Formato.NumeroConDecimal(Math.Abs(iTotActNCorA).ToString, 2) + ")"
        Else
            iTotForCon.DatoCondicion2 = Formato.NumeroConDecimal(iTotActNCorA.ToString, 2)
        End If
        iTotForCon.DatoCondicion1 = Space(1) + iTotForCon.DatoCondicion1
        iTotForCon.DatoCondicion2 = Space(1) + iTotForCon.DatoCondicion2
        iLisActNCor.Add(iTotForCon)

        'Para Pasivo Corriente
        iTotForCon = New SuperEntidad
        iTotForCon.DescripcionFormatoContable = Space(4) + "TOTAL PASIVO CORRIENTE"
        If iTotPasCor < 0 Then
            iTotForCon.DatoCondicion1 = "(" + Formato.NumeroConDecimal(Math.Abs(iTotPasCor).ToString, 2) + ")"
        Else
            iTotForCon.DatoCondicion1 = Formato.NumeroConDecimal(iTotPasCor.ToString, 2)
        End If

        If iTotPasCorA < 0 Then
            iTotForCon.DatoCondicion2 = "(" + Formato.NumeroConDecimal(Math.Abs(iTotPasCorA).ToString, 2) + ")"
        Else
            iTotForCon.DatoCondicion2 = Formato.NumeroConDecimal(iTotPasCorA.ToString, 2)
        End If
        iTotForCon.DatoCondicion1 = Space(1) + iTotForCon.DatoCondicion1
        iTotForCon.DatoCondicion2 = Space(1) + iTotForCon.DatoCondicion2
        iLisPasCor.Add(iTotForCon)

        'Para Pasivo No Corriente
        iTotForCon = New SuperEntidad
        iTotForCon.DescripcionFormatoContable = Space(4) + "TOTAL PASIVO NO CORRIENTE"
        If iTotPasNCor < 0 Then
            iTotForCon.DatoCondicion1 = "(" + Formato.NumeroConDecimal(Math.Abs(iTotPasNCor).ToString, 2) + ")"
        Else
            iTotForCon.DatoCondicion1 = Formato.NumeroConDecimal(iTotPasNCor.ToString, 2)
        End If

        If iTotPasNCorA < 0 Then
            iTotForCon.DatoCondicion2 = "(" + Formato.NumeroConDecimal(Math.Abs(iTotPasNCorA).ToString, 2) + ")"
        Else
            iTotForCon.DatoCondicion2 = Formato.NumeroConDecimal(iTotPasNCorA.ToString, 2)
        End If
        iTotForCon.DatoCondicion1 = Space(1) + iTotForCon.DatoCondicion1
        iTotForCon.DatoCondicion2 = Space(1) + iTotForCon.DatoCondicion2
        iLisPasNCor.Add(iTotForCon)

        'Para Patrimonio 
        iTotForCon = New SuperEntidad
        iTotForCon.DescripcionFormatoContable = Space(4) + "TOTAL PATRIMONIO"
        If iTotPat < 0 Then
            iTotForCon.DatoCondicion1 = "(" + Formato.NumeroConDecimal(Math.Abs(iTotPat).ToString, 2) + ")"
        Else
            iTotForCon.DatoCondicion1 = Formato.NumeroConDecimal(iTotPat.ToString, 2)
        End If

        If iTotPatA < 0 Then
            iTotForCon.DatoCondicion2 = "(" + Formato.NumeroConDecimal(Math.Abs(iTotPatA).ToString, 2) + ")"
        Else
            iTotForCon.DatoCondicion2 = Formato.NumeroConDecimal(iTotPatA.ToString, 2)
        End If
        iTotForCon.DatoCondicion1 = Space(1) + iTotForCon.DatoCondicion1
        iTotForCon.DatoCondicion2 = Space(1) + iTotForCon.DatoCondicion2
        iLisPat.Add(iTotForCon)

        'Uniedno activos y pasivos
        'Uniendo Activos
        Dim iLisAct As New List(Of SuperEntidad)
        iLisAct.AddRange(iLisActCor)
        iLisAct.AddRange(iLisActNCor)

        'Uniendo Pasivo y Patrimonio
        Dim iLisPas As New List(Of SuperEntidad)
        iLisPas.AddRange(iLisPasCor)
        iLisPas.AddRange(iLisPasNCor)
        iLisPas.AddRange(iLisPat)

        'lista para los totales finales
        Dim iLisTot As New List(Of SuperEntidad)

        'Creando las lineas de totales
        iLin = New SuperEntidad
        iLin = Me.ObtenerDobleLinea
        iLisTot.Add(iLin)

        'Agregando los totales por lista
        'Para Activo  
        iTotForCon = New SuperEntidad
        iTotForCon.DescripcionFormatoContable = "TOTAL ACTIVO"
        If (iTotActCor + iTotActNCor) < 0 Then
            iTotForCon.DatoCondicion1 = "(" + Formato.NumeroConDecimal(Math.Abs((iTotActCor + iTotActNCor)).ToString, 2) + ")"
        Else
            iTotForCon.DatoCondicion1 = Formato.NumeroConDecimal((iTotActCor + iTotActNCor).ToString, 2)
        End If

        If (iTotActCorA + iTotActNCorA) < 0 Then
            iTotForCon.DatoCondicion2 = "(" + Formato.NumeroConDecimal(Math.Abs((iTotActCorA + iTotActNCorA)).ToString, 2) + ")"
        Else
            iTotForCon.DatoCondicion2 = Formato.NumeroConDecimal((iTotActCorA + iTotActNCorA).ToString, 2)
        End If
        iTotForCon.DatoCondicion1 = Space(1) + iTotForCon.DatoCondicion1
        iTotForCon.DatoCondicion2 = Space(1) + iTotForCon.DatoCondicion2
        iLisTot.Add(iTotForCon)

        'Para Pasivo 
        iTotForCon = New SuperEntidad
        iTotForCon.DescripcionFormatoContable = "TOTAL PASIVO Y PATRIMONIO"
        If (iTotPasCor + iTotPasNCor + iTotPat) < 0 Then
            iTotForCon.DatoCondicion1 = "(" + Formato.NumeroConDecimal(Math.Abs((iTotPasCor + iTotPasNCor + iTotPat)).ToString, 2) + ")"
        Else
            iTotForCon.DatoCondicion1 = Formato.NumeroConDecimal((iTotPasCor + iTotPasNCor + iTotPat).ToString, 2)
        End If

        If (iTotPasCorA + iTotPasNCorA + iTotPatA) < 0 Then
            iTotForCon.DatoCondicion2 = "(" + Formato.NumeroConDecimal(Math.Abs((iTotPasCorA + iTotPasNCorA + iTotPatA)).ToString, 2) + ")"
        Else
            iTotForCon.DatoCondicion2 = Formato.NumeroConDecimal((iTotPasCorA + iTotPasNCorA + iTotPatA).ToString, 2)
        End If
        iTotForCon.DatoCondicion1 = Space(1) + iTotForCon.DatoCondicion1
        iTotForCon.DatoCondicion2 = Space(1) + iTotForCon.DatoCondicion2
        iLisTot.Add(iTotForCon)

        'Lista Activo y PAsivo y totales
        iLisRes.Add(iLisAct)
        iLisRes.Add(iLisPas)
        iLisRes.Add(iLisTot)

        Return iLisRes
    End Function

    Function ObtenerLinea() As SuperEntidad
        Dim iLin As New SuperEntidad
        iLin.DescripcionFormatoContable = ""
        iLin.DatoCondicion1 = "----------------"
        iLin.DatoCondicion2 = "----------------"
        Return iLin
    End Function

    Function ObtenerDobleLinea() As SuperEntidad
        Dim iLin As New SuperEntidad
        iLin.DescripcionFormatoContable = ""
        iLin.DatoCondicion1 = "================"
        iLin.DatoCondicion2 = "================"
        Return iLin
    End Function

    Function ListarFormatoDeGananciaPerdida(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New FormatoContableAd
        Return objAD.ListarFormatoDeGananciaPerdida(ent)
        '\\
    End Function

    Public Function ListarSaldosXFormatoContableDeGananciaPerdida(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim iLisRes As New List(Of SuperEntidad)

        'Traer lista formato contable de la empresa
        Dim iFc As New SuperEntidad
        iFc.CodigoEmpresa = ent.CodigoEmpresa
        iFc.CampoOrden = Cam.GruForCon + "," + Cam.CodForCon
        Dim iLisFc As List(Of SuperEntidad) = Me.ListarFormatoDeGananciaPerdida(iFc)

        'Vriables
        Dim iForCon As String = ""
        Dim iIndice As Integer = -1
        Dim iMes As String = ent.PeriodoRegContabCabe.Substring(4)
        Dim iSalConRN As New SaldoContableRN
        Dim iSalConEN As New SuperEntidad
        iSalConEN.CodigoEmpresa = ent.CodigoEmpresa
        iSalConEN.PeriodoRegContabCabe = ent.PeriodoRegContabCabe.Substring(0, 4)
        iSalConEN.CampoOrden = Cam.ClaSalCon

        For Each xFc As SuperEntidad In iLisFc
            iSalConEN.CodigoFormatoContable = xFc.CodigoFormatoContable
            Dim iLisSalCon As List(Of SuperEntidad) = iSalConRN.ListarSaldosContableXFormatoContable(iSalConEN)

            If iLisSalCon.Count <> 0 Then
                'Formato Contable con saldo
                Dim isc As New SuperEntidad
                isc.CodigoFormatoContable = xFc.CodigoFormatoContable
                isc.DescripcionFormatoContable = xFc.DescripcionFormatoContable
                isc.GrupoFormatoContable = xFc.GrupoFormatoContable
                For Each xsc As SuperEntidad In iLisSalCon
                    isc.SaldoCuentaBanco += iSalConRN.obtenerDiferenciaDebeHaber(xsc, iMes)  'Saldo del mes
                    isc.SaldoCuentaCorriente += iSalConRN.obtenerDiferenciaDebeHaberAcumulado(xsc, iMes) 'Saldo acumulado
                Next
                'poner positivo o negativo segun grupo (si es ganancia o perdida)
                If xFc.GrupoFormatoContable = "Ventas" Or xFc.GrupoFormatoContable = "Otros Ingresos" Then
                    isc.SaldoCuentaBanco = Math.Abs(isc.SaldoCuentaBanco)
                    isc.SaldoCuentaCorriente = Math.Abs(isc.SaldoCuentaCorriente)
                Else
                    isc.SaldoCuentaBanco = Math.Abs(isc.SaldoCuentaBanco) * (-1)
                    isc.SaldoCuentaCorriente = Math.Abs(isc.SaldoCuentaCorriente) * (-1)
                End If
                iLisRes.Add(isc)
            End If


        Next
        Return iLisRes
    End Function

    Function ObtenerReporteGananciaPerdida(ByVal ent As SuperEntidad) As List(Of SuperEntidad)

        paren = par.buscarParametroExis(paren)
        PorImpuestoRenta = paren.PorcentajeImpuestoRenta

        'Lista de resultados
        Dim iLisRes As New List(Of SuperEntidad)

        'Obtener lista de saldos de formato contable
        Dim pListaSaldos As List(Of SuperEntidad) = Me.ListarSaldosXFormatoContableDeGananciaPerdida(ent)

        'Crear las 5 listas de titulos
        Dim iLisVtas As New List(Of SuperEntidad)
        Dim iLisGasVtas As New List(Of SuperEntidad)
        Dim iLisOtrosGas As New List(Of SuperEntidad)
        Dim iLisOtrosIng As New List(Of SuperEntidad)
        Dim iLisOtrosEgr As New List(Of SuperEntidad)

        'Crear el primer objeto(Titulo) para cada lista
        Dim iTit As SuperEntidad
        iTit = New SuperEntidad
        iTit.DescripcionFormatoContable = "VENTAS"
        iTit.DatoCondicion1 = ""
        iTit.DatoCondicion2 = ""
        iLisVtas.Add(iTit)

        iTit = New SuperEntidad
        iTit.DescripcionFormatoContable = "GASTOS VENTAS"
        iTit.DatoCondicion1 = ""
        iTit.DatoCondicion2 = ""
        iLisGasVtas.Add(iTit)

        iTit = New SuperEntidad
        iTit.DescripcionFormatoContable = "OTROS GASTOS"
        iTit.DatoCondicion1 = ""
        iTit.DatoCondicion2 = ""
        iLisOtrosGas.Add(iTit)

        iTit = New SuperEntidad
        iTit.DescripcionFormatoContable = "OTROS INGRESOS"
        iTit.DatoCondicion1 = ""
        iTit.DatoCondicion2 = ""
        iLisOtrosIng.Add(iTit)

        iTit = New SuperEntidad
        iTit.DescripcionFormatoContable = "OTROS EGRESOS"
        iTit.DatoCondicion1 = ""
        iTit.DatoCondicion2 = ""
        iLisOtrosEgr.Add(iTit)

        'Variables totales
        Dim iTotVtas As Decimal = 0
        Dim iTotVtasA As Decimal = 0
        Dim iTotVtasGas As Decimal = 0
        Dim iTotVtasGasA As Decimal = 0
        Dim iTotOtrGas As Decimal = 0
        Dim iTotOtrGasA As Decimal = 0
        Dim iTotOtrIng As Decimal = 0
        Dim iTotOtrIngA As Decimal = 0
        Dim iTotOtrEgr As Decimal = 0
        Dim iTotOtrEgrA As Decimal = 0

        'Cargando los formatos contables
        For Each xSal As SuperEntidad In pListaSaldos

            Dim iForCon As New SuperEntidad
            iForCon.DescripcionFormatoContable = Space(3) + xSal.DescripcionFormatoContable
            If xSal.SaldoCuentaBanco < 0 Then
                iForCon.DatoCondicion1 = "(" + Formato.NumeroConDecimal(Math.Abs(xSal.SaldoCuentaBanco).ToString, 2) + ")"
            Else
                iForCon.DatoCondicion1 = Formato.NumeroConDecimal(xSal.SaldoCuentaBanco.ToString, 2)
            End If

            If xSal.SaldoCuentaCorriente < 0 Then
                iForCon.DatoCondicion2 = "(" + Formato.NumeroConDecimal(Math.Abs(xSal.SaldoCuentaCorriente).ToString, 2) + ")"
            Else
                iForCon.DatoCondicion2 = Formato.NumeroConDecimal(xSal.SaldoCuentaCorriente.ToString, 2)
            End If

            'Acumulando totales insertar los formatos contables a su respectiva lista
            Select Case xSal.GrupoFormatoContable
                Case "Ventas"
                    iTotVtas += xSal.SaldoCuentaBanco
                    iTotVtasA += xSal.SaldoCuentaCorriente
                    iLisVtas.Add(iForCon)
                Case "Gastos Ventas"
                    iTotVtasGas += xSal.SaldoCuentaBanco
                    iTotVtasGasA += xSal.SaldoCuentaCorriente
                    iLisGasVtas.Add(iForCon)
                Case "Otros Gastos"
                    iTotOtrGas += xSal.SaldoCuentaBanco
                    iTotOtrGasA += xSal.SaldoCuentaCorriente
                    iLisOtrosGas.Add(iForCon)
                Case "Otros Ingresos"
                    iTotOtrIng += xSal.SaldoCuentaBanco
                    iTotOtrIngA += xSal.SaldoCuentaCorriente
                    iLisOtrosIng.Add(iForCon)
                Case "Otros Egresos"
                    iTotOtrEgr += xSal.SaldoCuentaBanco
                    iTotOtrEgrA += xSal.SaldoCuentaCorriente
                    iLisOtrosEgr.Add(iForCon)
            End Select
        Next

        'Creando las lineas de subtotales
        Dim iLin As SuperEntidad
        iLin = New SuperEntidad
        iLin = Me.ObtenerLinea
        iLisVtas.Add(iLin)

        iLin = New SuperEntidad
        iLin = Me.ObtenerLinea
        iLisGasVtas.Add(iLin)

        iLin = New SuperEntidad
        iLin = Me.ObtenerLinea
        iLisOtrosGas.Add(iLin)

        iLin = New SuperEntidad
        iLin = Me.ObtenerLinea
        iLisOtrosIng.Add(iLin)

        iLin = New SuperEntidad
        iLin = Me.ObtenerLinea
        iLisOtrosEgr.Add(iLin)

        'Agregando los subtotales por lista
        'Para ventas
        Dim iTotForCon As SuperEntidad
        iTotForCon = New SuperEntidad
        iTotForCon.DescripcionFormatoContable = Space(4) + "TOTAL VENTAS"
        If iTotVtas < 0 Then
            iTotForCon.DatoCondicion1 = "(" + Formato.NumeroConDecimal(Math.Abs(iTotVtas).ToString, 2) + ")"
        Else
            iTotForCon.DatoCondicion1 = Formato.NumeroConDecimal(iTotVtas.ToString, 2)
        End If

        If iTotVtasA < 0 Then
            iTotForCon.DatoCondicion2 = "(" + Formato.NumeroConDecimal(Math.Abs(iTotVtasA).ToString, 2) + ")"
        Else
            iTotForCon.DatoCondicion2 = Formato.NumeroConDecimal(iTotVtasA.ToString, 2)
        End If
        iTotForCon.DatoCondicion1 = Space(1) + iTotForCon.DatoCondicion1
        iTotForCon.DatoCondicion2 = Space(1) + iTotForCon.DatoCondicion2
        iLisVtas.Add(iTotForCon)

        'Para gastos ventas
        iTotForCon = New SuperEntidad
        iTotForCon.DescripcionFormatoContable = Space(4) + "TOTAL GASTOS VENTAS"
        If iTotVtasGas < 0 Then
            iTotForCon.DatoCondicion1 = "(" + Formato.NumeroConDecimal(Math.Abs(iTotVtasGas).ToString, 2) + ")"
        Else
            iTotForCon.DatoCondicion1 = Formato.NumeroConDecimal(iTotVtasGas.ToString, 2)
        End If

        If iTotVtasGasA < 0 Then
            iTotForCon.DatoCondicion2 = "(" + Formato.NumeroConDecimal(Math.Abs(iTotVtasGasA).ToString, 2) + ")"
        Else
            iTotForCon.DatoCondicion2 = Formato.NumeroConDecimal(iTotVtasGasA.ToString, 2)
        End If
        iTotForCon.DatoCondicion1 = Space(1) + iTotForCon.DatoCondicion1
        iTotForCon.DatoCondicion2 = Space(1) + iTotForCon.DatoCondicion2
        iLisGasVtas.Add(iTotForCon)

        'Para otros gastos
        iTotForCon = New SuperEntidad
        iTotForCon.DescripcionFormatoContable = Space(4) + "TOTAL OTROS GASTOS"
        If iTotOtrGas < 0 Then
            iTotForCon.DatoCondicion1 = "(" + Formato.NumeroConDecimal(Math.Abs(iTotOtrGas).ToString, 2) + ")"
        Else
            iTotForCon.DatoCondicion1 = Formato.NumeroConDecimal(iTotOtrGas.ToString, 2)
        End If

        If iTotOtrGasA < 0 Then
            iTotForCon.DatoCondicion2 = "(" + Formato.NumeroConDecimal(Math.Abs(iTotOtrGasA).ToString, 2) + ")"
        Else
            iTotForCon.DatoCondicion2 = Formato.NumeroConDecimal(iTotOtrGasA.ToString, 2)
        End If
        iTotForCon.DatoCondicion1 = Space(1) + iTotForCon.DatoCondicion1
        iTotForCon.DatoCondicion2 = Space(1) + iTotForCon.DatoCondicion2
        iLisOtrosGas.Add(iTotForCon)

        'Para ortos ingresos
        iTotForCon = New SuperEntidad
        iTotForCon.DescripcionFormatoContable = Space(4) + "TOTAL OTROS INGRESOS"
        If iTotOtrIng < 0 Then
            iTotForCon.DatoCondicion1 = "(" + Formato.NumeroConDecimal(Math.Abs(iTotOtrIng).ToString, 2) + ")"
        Else
            iTotForCon.DatoCondicion1 = Formato.NumeroConDecimal(iTotOtrIng.ToString, 2)
        End If

        If iTotOtrIngA < 0 Then
            iTotForCon.DatoCondicion2 = "(" + Formato.NumeroConDecimal(Math.Abs(iTotOtrIngA).ToString, 2) + ")"
        Else
            iTotForCon.DatoCondicion2 = Formato.NumeroConDecimal(iTotOtrIngA.ToString, 2)
        End If
        iTotForCon.DatoCondicion1 = Space(1) + iTotForCon.DatoCondicion1
        iTotForCon.DatoCondicion2 = Space(1) + iTotForCon.DatoCondicion2
        iLisOtrosIng.Add(iTotForCon)

        'Para otros egresos
        iTotForCon = New SuperEntidad
        iTotForCon.DescripcionFormatoContable = Space(4) + "TOTAL OTROS EGRESOS"
        If iTotOtrEgr < 0 Then
            iTotForCon.DatoCondicion1 = "(" + Formato.NumeroConDecimal(Math.Abs(iTotOtrEgr).ToString, 2) + ")"
        Else
            iTotForCon.DatoCondicion1 = Formato.NumeroConDecimal(iTotOtrEgr.ToString, 2)
        End If

        If iTotOtrEgrA < 0 Then
            iTotForCon.DatoCondicion2 = "(" + Formato.NumeroConDecimal(Math.Abs(iTotOtrEgrA).ToString, 2) + ")"
        Else
            iTotForCon.DatoCondicion2 = Formato.NumeroConDecimal(iTotOtrEgrA.ToString, 2)
        End If
        iTotForCon.DatoCondicion1 = Space(1) + iTotForCon.DatoCondicion1
        iTotForCon.DatoCondicion2 = Space(1) + iTotForCon.DatoCondicion2
        iLisOtrosEgr.Add(iTotForCon)

        'Uniendo LISTAS
        'Uniendo primero lista ventas
        iLisRes.AddRange(iLisVtas)
        'uniendo gastos ventas
        iLisRes.AddRange(iLisGasVtas)
        'agregar linea
        iLin = New SuperEntidad
        iLin = Me.ObtenerLinea
        iLisRes.Add(iLin)
        'ingresar utilidad bruta
        iTotForCon = New SuperEntidad
        iTotForCon.DescripcionFormatoContable = Space(4) + "UTILIDAD BRUTA"
        Dim iUtilBru As Decimal = iTotVtas + iTotVtasGas
        Dim iUtilBruA As Decimal = iTotVtasA + iTotVtasGasA
        If iUtilBru < 0 Then
            iTotForCon.DatoCondicion1 = "(" + Formato.NumeroConDecimal(Math.Abs(iUtilBru).ToString, 2) + ")"
        Else
            iTotForCon.DatoCondicion1 = Formato.NumeroConDecimal(iUtilBru.ToString, 2)
        End If
        If iUtilBruA < 0 Then
            iTotForCon.DatoCondicion2 = "(" + Formato.NumeroConDecimal(Math.Abs(iUtilBruA).ToString, 2) + ")"
        Else
            iTotForCon.DatoCondicion2 = Formato.NumeroConDecimal((iUtilBruA).ToString, 2)
        End If
        iTotForCon.DatoCondicion1 = Space(1) + iTotForCon.DatoCondicion1
        iTotForCon.DatoCondicion2 = Space(1) + iTotForCon.DatoCondicion2
        iLisRes.Add(iTotForCon)

        'Uniendo otros gastos
        iLisRes.AddRange(iLisOtrosGas)
        'agregar linea
        iLin = New SuperEntidad
        iLin = Me.ObtenerLinea
        iLisRes.Add(iLin)
        'uniendo utilidad operacion
        iTotForCon = New SuperEntidad
        iTotForCon.DescripcionFormatoContable = Space(4) + "UTILIDAD OPERACIONES"
        Dim iUtilOpe As Decimal = iUtilBru + iTotOtrGas
        Dim iUtilOpeA As Decimal = iUtilBruA + iTotOtrGasA
        If iUtilOpe < 0 Then
            iTotForCon.DatoCondicion1 = "(" + Formato.NumeroConDecimal(Math.Abs(iUtilOpe).ToString, 2) + ")"
        Else
            iTotForCon.DatoCondicion1 = Formato.NumeroConDecimal(iUtilOpe.ToString, 2)
        End If
        If iUtilOpeA < 0 Then
            iTotForCon.DatoCondicion2 = "(" + Formato.NumeroConDecimal(Math.Abs(iUtilOpeA).ToString, 2) + ")"
        Else
            iTotForCon.DatoCondicion2 = Formato.NumeroConDecimal((iUtilOpeA).ToString, 2)
        End If
        iTotForCon.DatoCondicion1 = Space(1) + iTotForCon.DatoCondicion1
        iTotForCon.DatoCondicion2 = Space(1) + iTotForCon.DatoCondicion2
        iLisRes.Add(iTotForCon)

        'UNIENDO OTROS INGRESOS
        iLisRes.AddRange(iLisOtrosIng)
        'UNIENDO OTROS EGRESOS
        iLisRes.AddRange(iLisOtrosEgr)
        'AGREGANDO DOBLE LINEA
        iLin = New SuperEntidad
        iLin = Me.ObtenerDobleLinea
        iLisRes.Add(iLin)
        'uniendo resultado antes de impuestos
        iTotForCon = New SuperEntidad
        iTotForCon.DescripcionFormatoContable = Space(4) + "RESULTADO ANTES DE IMPUESTOS"
        Dim iResAnt As Decimal = iUtilOpe + iTotOtrIng + iTotOtrEgr
        Dim iResAntA As Decimal = iUtilOpeA + iTotOtrIngA + iTotOtrEgrA
        If iResAnt < 0 Then
            iTotForCon.DatoCondicion1 = "(" + Formato.NumeroConDecimal(Math.Abs(iResAnt).ToString, 2) + ")"
        Else
            iTotForCon.DatoCondicion1 = Formato.NumeroConDecimal(iResAnt.ToString, 2)
        End If
        If iResAntA < 0 Then
            iTotForCon.DatoCondicion2 = "(" + Formato.NumeroConDecimal(Math.Abs(iResAntA).ToString, 2) + ")"
        Else
            iTotForCon.DatoCondicion2 = Formato.NumeroConDecimal((iResAntA).ToString, 2)
        End If
        iTotForCon.DatoCondicion1 = Space(1) + iTotForCon.DatoCondicion1
        iTotForCon.DatoCondicion2 = Space(1) + iTotForCon.DatoCondicion2
        iLisRes.Add(iTotForCon)
        'AGREGANDO DOBLE LINEA
        iLin = New SuperEntidad
        iLin = Me.ObtenerDobleLinea
        iLisRes.Add(iLin)

        'Guardando Resultado  Ejercicio
        Dim iPerConRN As New PeriodoRN
        Dim iPerCon As New SuperEntidad
        iPerCon.ClavePeriodo = SuperEntidad.xCodigoEmpresa + "-" + ent.PeriodoRegContabCabe
        iPerCon = iPerConRN.BuscarPeriodoXClave(iPerCon)
        iPerCon.ResultadoMes = iResAnt
        iPerCon.ResultadoAcumulado = iResAntA
        iPerConRN.modificarPeriodo(iPerCon)

        'UNIENDO IMPUESTA A LA RENTA
        iTotForCon = New SuperEntidad
        iTotForCon.DescripcionFormatoContable = Space(4) + "IMPUESTO A LA RENTA"
        'Dim iImpRen As Decimal = iResAnt * (-30) / 100
        'Dim iImpRenA As Decimal = iResAntA * (-30) / 100

        Dim iImpRen As Decimal = iResAnt * PorImpuestoRenta * (-1) / 100
        Dim iImpRenA As Decimal = iResAntA * PorImpuestoRenta * (-1) / 100

        If iImpRen < 0 Then
            iTotForCon.DatoCondicion1 = "(" + Formato.NumeroConDecimal(Math.Abs(iImpRen).ToString, 2) + ")"
        Else
            iTotForCon.DatoCondicion1 = Formato.NumeroConDecimal(iImpRen.ToString, 2)
        End If
        If iImpRenA < 0 Then
            iTotForCon.DatoCondicion2 = "(" + Formato.NumeroConDecimal(Math.Abs(iImpRenA).ToString, 2) + ")"
        Else
            iTotForCon.DatoCondicion2 = Formato.NumeroConDecimal((iImpRenA).ToString, 2)
        End If
        iTotForCon.DatoCondicion1 = Space(1) + iTotForCon.DatoCondicion1
        iTotForCon.DatoCondicion2 = Space(1) + iTotForCon.DatoCondicion2
        iLisRes.Add(iTotForCon)
        'AGREGANDO DOBLE LINEA
        iLin = New SuperEntidad
        iLin = Me.ObtenerDobleLinea
        iLisRes.Add(iLin)
        'uniendo resultado final
        iTotForCon = New SuperEntidad
        iTotForCon.DescripcionFormatoContable = Space(4) + "RESULTADO ANTES DE IMPUESTOS"
        Dim iResAnt1 As Decimal = iResAnt + iImpRen
        Dim iResAnt1A As Decimal = iResAntA + iImpRenA
        If iResAnt1 < 0 Then
            iTotForCon.DatoCondicion1 = "(" + Formato.NumeroConDecimal(Math.Abs(iResAnt1).ToString, 2) + ")"
        Else
            iTotForCon.DatoCondicion1 = Formato.NumeroConDecimal(iResAnt1.ToString, 2)
        End If
        If iResAnt1A < 0 Then
            iTotForCon.DatoCondicion2 = "(" + Formato.NumeroConDecimal(Math.Abs(iResAnt1A).ToString, 2) + ")"
        Else
            iTotForCon.DatoCondicion2 = Formato.NumeroConDecimal((iResAnt1A).ToString, 2)
        End If
        iTotForCon.DatoCondicion1 = Space(1) + iTotForCon.DatoCondicion1
        iTotForCon.DatoCondicion2 = Space(1) + iTotForCon.DatoCondicion2
        iLisRes.Add(iTotForCon)
        'AGREGANDO DOBLE LINEA
        iLin = New SuperEntidad
        iLin = Me.ObtenerDobleLinea
        iLisRes.Add(iLin)

        Return iLisRes
    End Function

End Class
