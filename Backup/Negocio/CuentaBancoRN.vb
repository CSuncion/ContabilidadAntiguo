Imports Entidad
Imports Datos

Public Class CuentaBancoRN
    Dim Cam As New CamposEntidad
    Const vista As String = "VsCuentaBanco"

    Sub nuevaCuentaBanco(ByRef ent As SuperEntidad)
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
        ent.ClaveCuentaBanco = ent.CodigoEmpresa + ent.CodigoCuentaBanco
        Dim objAD As New CuentaBancoAD
        objAD.SpNuevoCuentaBanco(ent)
        '\\
    End Sub

    Sub modificarCuentaBanco(ByRef ent As SuperEntidad)
        '//
        '/Vovemos a traer el usuario actual de la b.d
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        '/Vovemos a traer el usuario actual de la b.d

        ''/Mandamos a modificar la b.d
        Dim objAD As New CuentaBancoAD
        objAD.SpModificarCuentaBanco(ent)
        '\\
    End Sub

    Sub eliminarCuentaBancoLog(ByRef ent As SuperEntidad)
        '//
        '/Datos por defecto
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        ent.EliminadoRegistro = "0"
        '/Mandamos a modificar la b.d
        Dim objAD As New CuentaBancoAD
        objAD.SpModificarCuentaBanco(ent)
        '\\
    End Sub

    Sub eliminarCuentaBancoFis(ByRef ent As SuperEntidad)
        '//
        '/Mandamos a modificar la b.d
        Dim objAD As New CuentaBancoAD
        objAD.SpEliminarCuentaBanco(ent)
        '\\
    End Sub

    Function obtenerCuentaBancoExis(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.CodEmp
        ent.DatoCondicion1 = ent.CodigoEmpresa
        'ent.DatoCondicion1 = SuperEntidad.xCodigoEmpresa
        Dim objAD As New CuentaBancoAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
        'listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerCuentaBancoExisYMoneda(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.CodEmp
        ent.DatoCondicion1 = SuperEntidad.xCodigoEmpresa
        ent.CampoCondicion2 = Cam.MonCtaBco
        ent.DatoCondicion2 = ent.MonedaCuentaBanco

        Dim objAD As New CuentaBancoAD
        listObj = objAD.SpObtenerRegistrosConDosCondicion(ent)
        'listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function


    'Function obtenerCuentaBancoExis(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
    '    '//
    '    Dim listObj As New List(Of SuperEntidad)
    '    ent.Vista = vista
    '    ent.DatoEliminado = "1"
    '    ent.DatoEstado = ""
    '    Dim objAD As New CuentaBancoAD
    '    listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
    '    Return listObj
    '    '\\
    'End Function

    Function obtenerCuentaBancoExisAct(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        Dim objAD As New CuentaBancoAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerCuentaBancoEli(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        Dim objAD As New CuentaBancoAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function ObtenerCuentaBancoExisPorEmpresa(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.CodEmp
        ent.DatoCondicion1 = ent.CodigoEmpresa
        Dim objAD As New CuentaBancoAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarCuentaBancoExisPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaCtaBco
        ent.DatoCondicion1 = ent.ClaveCuentaBanco
        Dim objAD As New CuentaBancoAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function


    Function buscarCuentaBancoExisPorCodigoXMoneda(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaCtaBco
        ent.DatoCondicion1 = ent.ClaveCuentaBanco
        ent.CampoCondicion2 = Cam.MonCtaBco
        ent.DatoCondicion2 = ent.MonedaCuentaBanco
        Dim objAD As New CuentaBancoAD
        obj = objAD.SpBuscarRegistroConDosCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarCuentaBancoActPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = Cam.CodCtaBco
        Dim objAD As New CuentaBancoAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarCuentaBancoEliPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaCtaBco
        Dim objAD As New CuentaBancoAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarCuentaBancoExisPorNombre(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.BcoCtaBco
        Dim objAD As New CuentaBancoAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function existeCuentaBancoPorCodigo(ByRef ent As SuperEntidad) As Boolean
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = ""
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.CodCtaBco
        ent.DatoCondicion1 = ent.CodigoCuentaBanco

        Dim bcoAD As New CuentaBancoAD
        obj = bcoAD.SpBuscarRegistroConUnaCondicion(ent)
        If obj.CodigoCuentaBanco = "" Then
            Return False
        Else
            Return True
        End If
        '\\
    End Function

    Function existeCuentaBancoPorClave(ByRef ent As SuperEntidad) As Boolean
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = ""
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaCtaBco
        ent.DatoCondicion1 = ent.ClaveCuentaBanco

        Dim bcoAD As New CuentaBancoAD
        obj = bcoAD.SpBuscarRegistroConUnaCondicion(ent)
        If obj.CodigoCuentaBanco = "" Then
            Return False
        Else
            Return True
        End If
        '\\
    End Function

    Function EsCuentaBancoConTransaccion(ByRef ent As SuperEntidad) As Boolean
        '//
        Dim lis As New List(Of SuperEntidad)
        Dim rcd As New RegContabDetaRN

        lis = rcd.obtenerDetalleRegContabPorEmpresaYCuenta(ent)
        If lis.Count = 0 Then
            Return False
        Else
            Return True
        End If
        '\\
    End Function


    Function EsCuentaConTransaccion(ByRef ent As SuperEntidad) As Boolean
        '//
        Dim lis As New List(Of SuperEntidad)
        Dim rcd As New RegContabDetaRN
        ent.CampoOrden = Cam.ClaveRCC
        lis = rcd.ListarRegistrosContablesDetalleXFiltroCuenta(ent)
        If lis.Count = 0 Then
            Return False
        Else
            Return True
        End If
        '\\
    End Function


    Function AcumuladoBanco(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim rd As New RegContabDetaRN


        Dim lisdr As New List(Of SuperEntidad)
        Dim lisac As New List(Of SuperEntidad)
        ent.CampoOrden = Cam.CodCtaPcge
        '  lisdr = rd.obtenerDetalleRegContabPorPeriodoYFlagBanco(ent)
        lisdr = rd.ListarBancosParaCierreBanco(ent)
        Dim cbco As String = ""

        'RECORREMOS CADA CUENTA DE BANCO 
        For Each obj As SuperEntidad In lisdr

            If obj.CodigoCuentaPcge = cbco Then
                'SI SON IGUALES ACUMULAMOS EL MONTO 
                For Each xob As SuperEntidad In lisac
                    If xob.CodigoCuentaPcge = obj.CodigoCuentaPcge Then
                        'ImporteS Debe o Haber 
                        If obj.DebeHaberRegContabDeta = "Debe" Then
                            xob.IngresosSolCuentaBanco = xob.IngresosSolCuentaBanco + obj.ImporteSRegContabDeta
                            xob.IngresosDolCuentaBanco = xob.IngresosDolCuentaBanco + obj.ImporteDRegContabDeta

                        Else
                            xob.SalidasSolCuentaBanco = xob.SalidasSolCuentaBanco + obj.ImporteSRegContabDeta
                            xob.SalidasDolCuentaBanco = xob.SalidasDolCuentaBanco + obj.ImporteDRegContabDeta
                        End If
                    End If
                    'xob.SaldoMesSolCuentaBanco = xob.SaldoMesSolCuentaBanco + xob.IngresosSolCuentaBanco - Math.Abs(xob.SalidasSolCuentaBanco)
                    'xob.SaldoMesDolCuentaBanco = xob.SaldoMesDolCuentaBanco + xob.IngresosDolCuentaBanco - Math.Abs(xob.SalidasSolCuentaBanco)
                Next


            Else
                'SI SON DIFERENTES CREAMOS EL MES
                Dim oSB As New SuperEntidad
                oSB.CodigoCuentaPcge = obj.CodigoCuentaPcge
                If obj.DebeHaberRegContabDeta = "Debe" Then
                    oSB.IngresosSolCuentaBanco = obj.ImporteSRegContabDeta
                    oSB.IngresosDolCuentaBanco = obj.ImporteDRegContabDeta
                Else
                    oSB.SalidasSolCuentaBanco = obj.ImporteSRegContabDeta
                    oSB.SalidasDolCuentaBanco = obj.ImporteDRegContabDeta
                End If
                oSB.SaldoMesSolCuentaBanco = 0
                oSB.SaldoMesDolCuentaBanco = 0
                'AGREGAMOS ALA LISTA DE MESES
                lisac.Add(oSB)

                'CAMBIAMOS EL MES
                cbco = obj.CodigoCuentaPcge
            End If
        Next

        Return lisac


    End Function

    Function ListarSaldosBancariosDesdeMes(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim objAd As New SaldosBancariosAD
        Return objAd.ListarSaldosBancariosDesdeMes(ent)

    End Function



    Sub CierreMensual(ByRef ent As SuperEntidad)
        Dim sb As New SaldosBancariosRN
        Dim objSB As New SuperEntidad
        'Dim lisDrc As New List(Of SuperEntidad)
        Dim lisASB As New List(Of SuperEntidad) 'Lista Acumulada por cuenta banco
        Dim lisSB As New List(Of SuperEntidad) 'Lista de saldos desde el mes anterior al de proceso
        Dim xMesProceso As String = ent.PeriodoRegContabCabe.Substring(4, 2)
        Dim xMesAntProceso As String = ""
        Dim xsaldoanteriorsoles As Decimal = 0
        Dim xsaldoanteriordolares As Decimal = 0


        'Obtener mes donde se quiere traer lista de saldo bancarios 
        If xMesProceso = "01" Then
            xMesAntProceso = xMesProceso
        Else
            xMesAntProceso = (CType(xMesProceso, Integer) - 1).ToString.PadLeft(2, CType("0", Char))
        End If

        lisASB = Me.AcumuladoBanco(ent)

        ''Chequear Cuenta x Cuenta
        For Each xobj As SuperEntidad In lisASB
            Dim isalEN As New SuperEntidad
            isalEN.ClaveSaldosBancarios = SuperEntidad.xCodigoEmpresa + xobj.CodigoCuentaPcge + ent.PeriodoRegContabCabe
            isalEN = sb.buscarSaldosBancariosExisPorClave(isalEN)
            If isalEN.ClaveSaldosBancarios <> "" Then
                isalEN.IngresosSolCuentaBanco = 0
                isalEN.SalidasSolCuentaBanco = 0
                isalEN.IngresosDolCuentaBanco = 0
                isalEN.SalidasDolCuentaBanco = 0
                isalEN.SaldoMesSolCuentaBanco = 0
                isalEN.SaldoMesDolCuentaBanco = 0
                sb.modificarSaldosBancarios(isalEN)
            End If
            'Traer saldos desde un mes anterior al mes de proceso hasta Dic
            objSB.ClaveCuentaBanco = SuperEntidad.xCodigoEmpresa + xobj.CodigoCuentaPcge
            objSB.AnoCuentaBanco = ent.PeriodoRegContabCabe.Substring(0, 4)
            objSB.MesCuentaBanco = xMesAntProceso
            lisSB = Me.ListarSaldosBancariosDesdeMes(objSB)   ''Aqui estan todas los saldos bancarios

            If lisSB.Count <> 0 Then
                ''Obtener Saldo Del Mes anterior al proceso
                xsaldoanteriorsoles = 0
                xsaldoanteriordolares = 0
                If xMesProceso = "01" Then
                    xsaldoanteriorsoles = lisSB.Item(0).SaldoMesSolAntCuentaBanco
                    xsaldoanteriordolares = lisSB.Item(0).SaldoMesDolAntCuentaBanco
                Else
                    xsaldoanteriorsoles = lisSB.Item(0).SaldoMesSolCuentaBanco
                    xsaldoanteriordolares = lisSB.Item(0).SaldoMesDolCuentaBanco
                End If


                For Each sob As SuperEntidad In lisSB

                    If sob.MesCuentaBanco = xMesProceso Then
                        ''Modificar Mes de proceso
                        sob.IngresosSolCuentaBanco = xobj.IngresosSolCuentaBanco
                        sob.SalidasSolCuentaBanco = xobj.SalidasSolCuentaBanco
                        sob.IngresosDolCuentaBanco = xobj.IngresosDolCuentaBanco
                        sob.SalidasDolCuentaBanco = xobj.SalidasDolCuentaBanco
                        sob.SaldoMesSolCuentaBanco = xsaldoanteriorsoles + (xobj.IngresosSolCuentaBanco - xobj.SalidasSolCuentaBanco)
                        sob.SaldoMesDolCuentaBanco = xsaldoanteriordolares + (xobj.IngresosDolCuentaBanco - xobj.SalidasDolCuentaBanco)
                        'Capture saldo para el mes sguiente
                        xsaldoanteriorsoles = sob.SaldoMesSolCuentaBanco
                        xsaldoanteriordolares = sob.SaldoMesDolCuentaBanco
                        sb.modificarSaldosBancarios(sob) ''Actualiza mes de proceso
                    Else

                        If sob.MesCuentaBanco > xMesProceso Then
                            sob.SaldoMesSolCuentaBanco = xsaldoanteriorsoles + (sob.IngresosSolCuentaBanco - sob.SalidasSolCuentaBanco)
                            sob.SaldoMesDolCuentaBanco = xsaldoanteriordolares + (sob.IngresosDolCuentaBanco - sob.SalidasDolCuentaBanco)
                            'Capture saldo para el mes sguiente
                            xsaldoanteriorsoles = sob.SaldoMesSolCuentaBanco
                            xsaldoanteriordolares = sob.SaldoMesDolCuentaBanco
                            sb.modificarSaldosBancarios(sob)
                        End If
                    End If
                Next
            End If
        Next
    End Sub


    Function ArmarIngresoEgresoXBanco(ByRef ent As SuperEntidad, ByVal pMoneda As String) As DataTable
        Dim iTabla As New DataTable

        ''Crear las columnas estaticas
        iTabla.Columns.Add(New DataColumn("I/E"))
        iTabla.Columns.Add(New DataColumn("DESCRIPCION"))

        ''Crear Las COLUMNAS DINAMICAS (Cuenta Banco segun moneda)
        Dim iListaCuentaBanco As New List(Of SuperEntidad)
        ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iListaCuentaBanco = Me.obtenerCuentaBancoExisYMoneda(ent)

        For Each xobj As SuperEntidad In iListaCuentaBanco
            iTabla.Columns.Add(New DataColumn(xobj.CodigoCuentaBanco))
        Next

        ''Insertar registro saldo anterior
        Dim iMesAnterior As String = ""
        Dim iMesProceso As String = ent.MesCuentaBanco
        If ent.MesCuentaBanco <> "01" Then
            iMesAnterior = (CType(ent.MesCuentaBanco, Integer) - 1).ToString.PadLeft(2, CType("0", Char))
        Else
            iMesAnterior = "01"
        End If

        '' Traer saldos bancarios
        Dim sb As New SaldosBancariosRN
        Dim iRegistro As DataRow = iTabla.NewRow
        iRegistro("DESCRIPCION") = "SALDO ANTERIOR"

        For Each xobj As SuperEntidad In iListaCuentaBanco
            xobj.ClaveSaldosBancarios = SuperEntidad.xCodigoEmpresa + xobj.CodigoCuentaBanco + ent.AnoCuentaBanco + iMesAnterior
            Dim iClaveSalBco As String = xobj.ClaveCuentaBanco
            xobj = sb.buscarSaldosBancariosExisPorClave(xobj)

            If xobj.ClaveSaldosBancarios <> "" Then
                ''Segun Mes de Proceso
                If iMesProceso = "01" Then
                    Select Case pMoneda
                        Case "S/."
                            iRegistro(xobj.ClaveCuentaBanco.Substring(3)) = xobj.SaldoMesSolAntCuentaBanco
                        Case "US$"
                            iRegistro(xobj.ClaveCuentaBanco.Substring(3)) = xobj.SaldoMesDolAntCuentaBanco
                        Case "EUR"
                            iRegistro(xobj.ClaveCuentaBanco.Substring(3)) = xobj.SaldoMesEurAntCuentaBanco
                    End Select
                Else
                    Select Case pMoneda
                        Case "S/."
                            iRegistro(xobj.ClaveCuentaBanco.Substring(3)) = xobj.SaldoMesSolCuentaBanco
                        Case "US$"
                            iRegistro(xobj.ClaveCuentaBanco.Substring(3)) = xobj.SaldoMesDolCuentaBanco
                        Case "EUR"
                            iRegistro(xobj.ClaveCuentaBanco.Substring(3)) = xobj.SaldoMesEurCuentaBanco
                    End Select
                End If
            Else
                'aqui no hay saldo para esta cuenta en este periodo
                iRegistro(iClaveSalBco.Substring(3)) = "0.00"
            End If
        Next
        iTabla.Rows.Add(iRegistro)

        ''Titulo Ingresos
        iRegistro = iTabla.NewRow
        iRegistro("DESCRIPCION") = "INGRES0S"
        iTabla.Rows.Add(iRegistro)

        ''Totales Ingresos
        Dim codIng As String = ""
        Dim lisIng As New List(Of SuperEntidad)

        lisIng = Me.ListarTotalesIngresosXBanco(ent)

        For Each xobj As SuperEntidad In lisIng

            If xobj.CodigoIngEgr = codIng Then
                For Each xrow As DataRow In iTabla.Rows
                    If xrow("I/E").ToString = codIng Then
                        xrow(xobj.CodigoCuentaPcge) = xobj.ImporteRegContabCabe.ToString
                    End If
                Next
            Else
                iRegistro = iTabla.NewRow
                iRegistro("I/E") = xobj.CodigoIngEgr
                iRegistro("DESCRIPCION") = xobj.NombreIngEgr
                iRegistro(xobj.CodigoCuentaPcge) = xobj.ImporteRegContabCabe.ToString
                iTabla.Rows.Add(iRegistro)
                codIng = xobj.CodigoIngEgr
            End If
        Next

        ''Movimiento Ingresos totales
        iRegistro = iTabla.NewRow
        iRegistro("DESCRIPCION") = "TOTAL INGRESOS"

        '' Inicializar con cero (0)
        For Each xobj As SuperEntidad In iListaCuentaBanco
            iRegistro(xobj.CodigoCuentaBanco) = "0.00"
        Next

        For Each xobj As SuperEntidad In lisIng
            iRegistro(xobj.CodigoCuentaPcge) = (CType(iRegistro(xobj.CodigoCuentaPcge), Decimal) + xobj.ImporteRegContabCabe).ToString
        Next
        iTabla.Rows.Add(iRegistro)

        ''Titulo Egresos
        iRegistro = iTabla.NewRow
        iRegistro("DESCRIPCION") = "EGRESOS"
        iTabla.Rows.Add(iRegistro)

        ''Totales Egresos 
        Dim codEgr As String = ""
        Dim lisEgr As New List(Of SuperEntidad)

        lisEgr = Me.ListarTotalesEgresosXBanco(ent)

        For Each xobj As SuperEntidad In lisEgr

            If xobj.CodigoIngEgr = codIng Then
                For Each xrow As DataRow In iTabla.Rows
                    If xrow("I/E").ToString = codIng Then
                        xrow(xobj.CodigoCuentaPcge) = xobj.ImporteRegContabCabe.ToString
                    End If
                Next
            Else
                iRegistro = iTabla.NewRow
                iRegistro("I/E") = xobj.CodigoIngEgr
                iRegistro("DESCRIPCION") = xobj.NombreIngEgr
                iRegistro(xobj.CodigoCuentaPcge) = xobj.ImporteRegContabCabe.ToString
                iTabla.Rows.Add(iRegistro)
                codEgr = xobj.CodigoIngEgr
            End If
        Next

        ''Movimiento Egresos totales
        iRegistro = iTabla.NewRow
        iRegistro("DESCRIPCION") = "TOTAL EGRESOS"

        '' Inicializar con cero (0)
        For Each xobj As SuperEntidad In iListaCuentaBanco
            iRegistro(xobj.CodigoCuentaBanco) = "0.00"
        Next

        For Each xobj As SuperEntidad In lisEgr
            iRegistro(xobj.CodigoCuentaPcge) = (CType(iRegistro(xobj.CodigoCuentaPcge), Decimal) + xobj.ImporteRegContabCabe).ToString
        Next
        iTabla.Rows.Add(iRegistro)

        ''Saldo total del mes por cuenta
        iRegistro = iTabla.NewRow
        iRegistro("DESCRIPCION") = "SALDO DEL MES"

        Dim salAnt As Decimal
        Dim totIng As Decimal
        Dim totEgr As Decimal


        For Each xobj As SuperEntidad In iListaCuentaBanco
            salAnt = 0
            totIng = 0
            totEgr = 0

            For Each xrow As DataRow In iTabla.Rows

                If xrow("DESCRIPCION").ToString = "SALDO ANTERIOR" Then
                    salAnt = CType(xrow(xobj.CodigoCuentaBanco), Decimal)
                End If

                If xrow("DESCRIPCION").ToString = "TOTAL INGRESOS" Then
                    totIng = CType(xrow(xobj.CodigoCuentaBanco), Decimal)
                End If

                If xrow("DESCRIPCION").ToString = "TOTAL EGRESOS" Then
                    totEgr = CType(xrow(xobj.CodigoCuentaBanco), Decimal)
                End If
            Next

            iRegistro(xobj.CodigoCuentaBanco) = (salAnt + totIng - totEgr).ToString

        Next
        iTabla.Rows.Add(iRegistro)

        Return iTabla
    End Function


    Function ListarTotalesIngresosXBanco(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim rcd As New RegContabDetaRN
        Dim lisIng As New List(Of SuperEntidad)
        Dim lisRes As New List(Of SuperEntidad)

        ent.CampoOrden = Cam.CodIngEgr + "," + Cam.CodCtaPcge
        lisIng = rcd.obtenerDetalleRegContabXPeriodoIngYMoneda(ent)

        'PARA COMPARAR EL OBJETO
        Dim iCodIng As String = ""
        Dim iCodBco As String = ""

        'RECORREMOS CADA REGISTRO INGRESO 
        For Each obj As SuperEntidad In lisIng
            If obj.CodigoIngEgr = iCodIng And obj.CodigoCuentaPcge = iCodBco Then
                'SI SON IGUALES ACUMULAMOS EL saldo 
                For Each xob As SuperEntidad In lisRes
                    If xob.CodigoIngEgr = obj.CodigoIngEgr And xob.CodigoCuentaPcge = obj.CodigoCuentaPcge Then
                        Select Case xob.FlagMonedaPcge
                            Case "0" : xob.ImporteRegContabCabe += obj.ImporteSRegContabDeta
                            Case "1" : xob.ImporteRegContabCabe += obj.ImporteDRegContabDeta
                            Case "2" : xob.ImporteRegContabCabe += obj.ImporteERegContabDeta
                        End Select
                    End If
                Next
            Else
                'SI SON DIFERENTES CREAMOS EL primer registro
                Dim oRes As New SuperEntidad
                oRes = obj
                Select Case obj.FlagMonedaPcge
                    Case "0" : oRes.ImporteRegContabCabe = obj.ImporteSRegContabDeta
                    Case "1" : oRes.ImporteRegContabCabe = obj.ImporteDRegContabDeta
                    Case "2" : oRes.ImporteRegContabCabe = obj.ImporteERegContabDeta
                End Select

                'AGREGAMOS ALA LISTA DE MESES
                lisRes.Add(oRes)

                'CAMBIAMOS EL MES
                iCodIng = obj.CodigoIngEgr
                iCodBco = obj.CodigoCuentaPcge

            End If
        Next

        Return lisRes

    End Function

    Function ListarTotalesEgresosXBanco(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim rcd As New RegContabDetaRN
        Dim lisIng As New List(Of SuperEntidad)
        Dim lisRes As New List(Of SuperEntidad)

        ent.CampoOrden = Cam.CodIngEgr + "," + Cam.CodCtaPcge
        lisIng = rcd.obtenerDetalleRegContabXPeriodoEgrYMoneda(ent)

        'PARA COMPARAR EL OBJETO
        Dim iCodIng As String = ""
        Dim iCodBco As String = ""

        'RECORREMOS CADA REGISTRO INGRESO 
        For Each obj As SuperEntidad In lisIng
            If obj.CodigoIngEgr = iCodIng And obj.CodigoCuentaPcge = iCodBco Then
                'SI SON IGUALES ACUMULAMOS EL saldo 
                For Each xob As SuperEntidad In lisRes
                    If xob.CodigoIngEgr = obj.CodigoIngEgr And xob.CodigoCuentaPcge = obj.CodigoCuentaPcge Then
                        Select Case xob.FlagMonedaPcge
                            Case "0" : xob.ImporteRegContabCabe += obj.ImporteSRegContabDeta
                            Case "1" : xob.ImporteRegContabCabe += obj.ImporteDRegContabDeta
                            Case "2" : xob.ImporteRegContabCabe += obj.ImporteERegContabDeta
                        End Select
                    End If
                Next
            Else
                'SI SON DIFERENTES CREAMOS EL primer registro
                Dim oRes As New SuperEntidad
                oRes = obj
                Select Case obj.FlagMonedaPcge
                    Case "0" : oRes.ImporteRegContabCabe = obj.ImporteSRegContabDeta
                    Case "1" : oRes.ImporteRegContabCabe = obj.ImporteDRegContabDeta
                    Case "2" : oRes.ImporteRegContabCabe = obj.ImporteERegContabDeta
                End Select

                'AGREGAMOS ALA LISTA DE MESES
                lisRes.Add(oRes)

                'CAMBIAMOS EL MES
                iCodIng = obj.CodigoIngEgr
                iCodBco = obj.CodigoCuentaPcge

            End If
        Next

        Return lisRes

    End Function

    Sub modificarCuentaBancoMasivo(ByRef pLista As List(Of SuperEntidad))
        Dim objAD As New CuentaBancoAD
        objAD.ModificarCuentaBancoMasivo(pLista)
    End Sub

    Function buscarCuentaBancoExisPorCodigo(ByRef ent As SuperEntidad, ByRef pLista As List(Of SuperEntidad)) As SuperEntidad
        'OBJETO RESULTADO
        Dim iCueBan As New SuperEntidad

        'BUSCAR EN LA LISTA
        For Each xCueBan As SuperEntidad In pLista
            If xCueBan.CodigoCuentaBanco = ent.CodigoCuentaBanco Then
                iCueBan = xCueBan
                Return iCueBan
            End If
        Next
        Return iCueBan
    End Function

End Class
