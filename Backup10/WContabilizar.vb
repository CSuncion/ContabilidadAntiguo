Imports Entidad
Imports Negocio

Public Class WContabilizar

    Public ent, entIng, entPptoD, parEn As New SuperEntidad
    Dim iListaResultado As New List(Of List(Of SuperEntidad))
    Public lista, listaRc, listaRd, listacont, listaMcc, listaMcd, listaSalConAdi, listaSalConMod As New List(Of SuperEntidad)
    Public rcc As New RegContabCabeRN
    Public rccm As New MovimientoContableCabeceraRN
    Public rcdm As New MovimientoContableDetalleRN
    Public rcd As New RegContabDetaRN
    Public sc As New SaldoContableRN
    Public pce As New PlanCuentaGeRN
    Public cam As New CamposEntidad
    Public par As New ParametroRN
    Public acc As New Accion
    Dim eIncremento As Integer
    Dim eProcesoActual As String = ""


    Sub InicializaVentana()
        acc.listaCtrls = Me.ListaControles
        acc.PasaFoco()
        acc.FomatoDato()
        acc.PasarCursor()
        acc.Teclazo()
        acc.Valida()
        Me.PorDefecto()
        Me.Show()
        Me.txtCodMes.Focus()
    End Sub

    Sub PorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.txtNomEmp.Text = SuperEntidad.xRazonSocial
        Me.txtAno.Text = SuperEntidad.xPeriodoEmpresa.Substring(0, 4)
        parEn = par.buscarParametroExis(parEn)
    End Sub

    Function EsValidoContabilizar() As Boolean
        'TRAER REGISTROS CONTABLES CABECERA
        ent.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        ent.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        ent.CampoOrden = cam.CodOriRC
        listaRc = rcc.obtenerRegContabCabePorPeriodo(ent)
        'PREGUNTAR SI EXISTEN REGISTROS CONTABLES PARA PROCESAR
        If listaRc.Count = 0 Then
            MsgBox("Periodo Sin Registros Contables", MsgBoxStyle.Exclamation, "Contabilizacion")
            'SALIMOS DEL PROCESO
            Return False
        End If

        ''CONSISTENCIAR QUE ORIGEN 1 O 2 TENGAN DETALLE 
        Me.ConsistenciaBancos()

        'SI LA GRILLA DGVBANCOS SE CARGA ENTONCES SALE DEL PROCESO
        If Me.dgvBancos.Rows.Count > 1 Then
            MsgBox("No se Puede Contabilizar por Existir bancos sin detalle", MsgBoxStyle.Exclamation, "Contabilizacion")
            Return False
        End If

        ''CONSISTENCIAR QUE LOS VOUCHERS ESTEN CUADRADOS DEBE Y HABER 
        Me.ConsistenciaVoucher()

        'SI LA GRILLA DGVVOUCHER SE CARGA ENTONCES SALE DEL PROCESO
        If Me.DgvVoucher.Rows.Count > 1 Then
            MsgBox("No se Puede Contabilizar por Existir Comprobantes descuadrados", MsgBoxStyle.Exclamation, "Contabilizacion")
            Return False
        End If
        'si todo esta bien
        Return True
    End Function

    Sub LimpiarParaNuevaContabilizacion()
        Me.listaRc.Clear()
        Me.listaRd.Clear()
        Me.iListaResultado.Clear()
        Me.listaMcc.Clear()
        Me.listaMcd.Clear()
        Me.listaSalConAdi.Clear()
        Me.listaSalConMod.Clear()

        'eliminar el movimiento anterior
        'PREGUNTAR SI ESTE PERIODO YA GENERO MOVIMIENTO
        If Me.existenContabilizacionXPeriodo = True Then
            'Eliminar Movimiento Cabecera
            Dim obm As New SuperEntidad
            obm.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
            rccm.EliminarMovimientoContableCabeceraFis(obm)
            'Eliminar Movimiento Detalle
            rcdm.eliminarMovimientoContableDetalle(obm)
        End If

        'poner a cero los saldos del periodo de contabilizacion
        Me.SaldosACero()

    End Sub

    Function existenContabilizacionXPeriodo() As Boolean
        Dim obm As New SuperEntidad
        Dim lis As New List(Of SuperEntidad)
        obm.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        obm.CampoOrden = cam.PeriodoRCC
        lis = rccm.obtenerMovimientoCabeceraXPeriodo(obm)

        If lis.Count = 0 Then
            Return False
        Else
            Return True
        End If

    End Function

    Sub EjecutarCabeceraMovimiento()
        'INICIA EL INCREMENTYO EN CERO
        'Me.eIncremento = 0
        Me.eProcesoActual = "Procesando Movimiento contable cabecera"

        If listaRc.Count = 0 Then
            Me.eIncremento = 5
            Me.BackgroundWorker1.ReportProgress(1)
        Else
            Dim iNroObjetos As Integer = listaRc.Count
            Dim iRazon As Integer = (iNroObjetos \ 5) + 1
            Dim iNroVueltas As Integer = iNroObjetos \ iRazon
            Dim iIncrementoFinal As Integer = 5 - iNroVueltas
            Dim iContadorObjeto As Integer = 0
            Dim iContadorVueltas As Integer = 0
            For Each obj As SuperEntidad In listaRc
                Me.listaMcc.Add(obj)

                'AQUI SE VA EJECUTANDO CADA OBJETO DE LA LISTA
                iContadorObjeto += 1
                If (iContadorObjeto Mod iRazon = 0) Then
                    iContadorVueltas += 1
                    Me.eIncremento = 1
                    Me.BackgroundWorker1.ReportProgress(1)
                End If

                If (iContadorVueltas = iNroVueltas And iContadorObjeto = iNroObjetos) Then
                    Me.eIncremento = iIncrementoFinal
                    Me.BackgroundWorker1.ReportProgress(1)
                End If
            Next
        End If

    End Sub

    Sub GrabarCabeceraMovimiento()

        'INICIA NUEVO PROCESO
        Me.eProcesoActual = "Grabando Cabecera movimiento"

        'GRABAR CABECERA
        rccm.NuevoMovimientoContableCabeceraMasivo(Me.listaMcc)

        'INCREMENTAMOS EL PROCESO
        Me.eIncremento = 5
        Me.BackgroundWorker1.ReportProgress(1)

    End Sub

    Sub EjecutarDetalleMovimiento()
        'INICIA EL INCREMENTYO EN CERO
        'Me.eIncremento = 0
        Me.eProcesoActual = "Procesando Movimiento contable detalle"

        'LLENAR LISTA REGISTROS CONTABLES DETALLE
        ent.CampoOrden = cam.ClaveRCC
        listaRd = rcd.obtenerDetalleRegContabPorPeriodoContabilizacion(ent)

        If listaRd.Count = 0 Then
            Me.eIncremento = 20
            Me.BackgroundWorker1.ReportProgress(1)
        Else
            Dim iNroObjetos As Integer = listaRd.Count
            Dim iRazon As Integer = (iNroObjetos \ 20) + 1
            Dim iNroVueltas As Integer = iNroObjetos \ iRazon
            Dim iIncrementoFinal As Integer = 20 - iNroVueltas
            Dim iContadorObjeto As Integer = 0
            Dim iContadorVueltas As Integer = 0

            'Variables
            Dim iClave As String = ""
            Dim iContador As Integer = 0

            'proceso que incrementa el progres
            For Each obj As SuperEntidad In listaRd

                If iClave <> obj.ClaveRegContabCabe Then
                    iContador = CType(obj.UltimoCorrelativo, Integer)
                    iClave = obj.ClaveRegContabCabe
                End If

                Dim iMcd As New SuperEntidad
                iMcd = rcdm.ConvertirRegistroDetalleEnMovimientoDetalle(obj)
                
                listaMcd.Add(iMcd)

                'solo genera automatica si tiene estado registro igual=0
                If obj.EstadoRegistroRcc = "0" Then
                    If obj.FlagAutomaticaPcge = "1" Then
                        'Crear Automatica1
                        Dim iMcdAut1 As New SuperEntidad
                        iMcdAut1 = rcdm.ConvertirRegistroDetalleEnMovimientoDetalle(obj)
                        iContador += 1
                        iMcdAut1.CorrelativoRegContabDeta = iContador.ToString.PadLeft(4, CType("0", Char))
                        iMcdAut1.ClaveRegContabDeta = iMcdAut1.ClaveRegContabCabe + iMcdAut1.CorrelativoRegContabDeta
                        iMcdAut1.EstadoRegContabDeta = "A"
                        iMcdAut1.CodigoCuentaPcge = obj.CuentaAutomatica1Pcge
                        listaMcd.Add(iMcdAut1)

                        'Crear Automatica2
                        Dim iMcdAut2 As New SuperEntidad
                        iMcdAut2 = rcdm.ConvertirRegistroDetalleEnMovimientoDetalle(iMcdAut1)
                        iContador += 1
                        iMcdAut2.CorrelativoRegContabDeta = iContador.ToString.PadLeft(4, CType("0", Char))
                        iMcdAut2.ClaveRegContabDeta = iMcdAut2.ClaveRegContabCabe + iMcdAut2.CorrelativoRegContabDeta
                        Select Case iMcdAut2.DebeHaberRegContabDeta
                            Case "Debe" 'Debe
                                iMcdAut2.EstadoRegContabDeta = "A"
                                iMcdAut2.CodigoCuentaPcge = obj.CuentaAutomatica2Pcge
                                iMcdAut2.DebeHaberRegContabDeta = "Haber"
                            Case "Haber" 'Haber
                                iMcdAut2.EstadoRegContabDeta = "A"
                                iMcdAut2.CodigoCuentaPcge = obj.CuentaAutomatica2Pcge
                                iMcdAut2.DebeHaberRegContabDeta = "Debe"
                        End Select
                        listaMcd.Add(iMcdAut2)
                    End If
                End If

                'AQUI SE VA EJECUTANDO CADA OBJETO DE LA LISTA
                iContadorObjeto += 1
                If (iContadorObjeto Mod iRazon = 0) Then
                    iContadorVueltas += 1
                    Me.eIncremento = 1
                    Me.BackgroundWorker1.ReportProgress(1)
                End If

                If (iContadorVueltas = iNroVueltas And iContadorObjeto = iNroObjetos) Then
                    Me.eIncremento = iIncrementoFinal
                    Me.BackgroundWorker1.ReportProgress(1)
                End If
            Next

        End If
    End Sub

    Sub GrabarDetalleMovimiento()

        'INICIA NUEVO PROCESO
        Me.eProcesoActual = "Grabando Detalle movimiento"

        'GRABAR CABECERA
        rcdm.nuevoMovimientoContableDetalleMasivo(Me.listaMcd)

        'INCREMENTAMOS EL PROCESO
        Me.eIncremento = 5
        Me.BackgroundWorker1.ReportProgress(1)

    End Sub

    Sub EjecutarListasSaldosContables(ByVal pNumeroDigitosAnalitica As Integer)
        'INICIA EL INCREMENTO EN CERO
        'Me.eIncremento = 0
        Me.eProcesoActual = "Procesando Listas de saldos contables"

        If Me.listaMcd.Count = 0 Then
            Me.eIncremento = 25
            Me.BackgroundWorker1.ReportProgress(1)
        Else
            Dim iNroObjetos As Integer = Me.listaMcd.Count
            Dim iRazon As Integer = (iNroObjetos \ 25) + 1
            Dim iNroVueltas As Integer = iNroObjetos \ iRazon
            Dim iIncrementoFinal As Integer = 25 - iNroVueltas
            Dim iContadorObjeto As Integer = 0
            Dim iContadorVueltas As Integer = 0

            'LISTA QUE TENDRAN LOS SALDOS CONTABLES DE TODAS LAS CUENTAS
            'DESDE 2 HASTA EL NUMERO DE DIGITOS QUE TIENE UNA CUENTA ANALITICA
            Dim iListaPorNumeroDigito As List(Of SuperEntidad)

            'LLENAR LA LISTA RESULTADO CON EL NUMERO DE LISTAS QUE HAY 
            'DESDE 2 HASTA EN NUMERO DE DIGITOS QUE TIENE UNA CUENTA ANALITICA
            For n As Integer = 2 To pNumeroDigitosAnalitica
                iListaPorNumeroDigito = New List(Of SuperEntidad)
                iListaResultado.Add(iListaPorNumeroDigito)
            Next

            'VARIABLE QUE CAPTURA LA CUENTA AL NUMERO DE DIGITOS EN PROCESO
            Dim iCuenta As String = String.Empty
            'VARIABLE QUE CAPTURA SI EL MOVIMIENTO DETALLE ES UN DEBE O HABER
            Dim iDebeHaber As String = String.Empty
            'VARIABLE QUE CAPTURA EL IMPORTE EN SOLES DEL MOVIMIENTO DETALLE
            Dim iImporte As Decimal = 0
            'NUMERO DE OBJETOS DE LA LISTA EN PROCESO
            Dim iNumeroObjetos As Integer = 0
            'OBJETO PARA SALDO
            Dim iObjSaldo As SuperEntidad
            'RECORRER CADA MOVIMIENTO DETALLE
            For n As Integer = 0 To Me.listaMcd.Count - 1
                'FOR PARA RECORRER SEH¡GUN NUMERO DE DIGITOS
                For m As Integer = 2 To pNumeroDigitosAnalitica
                    iCuenta = Me.listaMcd.Item(n).CodigoCuentaPcge.Substring(0, m)
                    'MsgBox(pListaMovimientoDetalle.Item(n).CodigoCuentaPcge)
                    iDebeHaber = Me.listaMcd.Item(n).DebeHaberRegContabDeta
                    iImporte = Me.listaMcd.Item(n).ImporteSRegContabDeta
                    iNumeroObjetos = iListaResultado.Item(m - 2).Count
                    'SI LA LISTA ESTA EN CERO ENTONCES METEMOS EL PRIMER OBJETO
                    If iNumeroObjetos = 0 Then
                        iObjSaldo = New SuperEntidad
                        'iObjSaldo = pListaMovimientoDetalle.Item(n)
                        iObjSaldo.CodigoCuentaPcge = iCuenta
                        If iDebeHaber = "1" Then 'debe
                            iObjSaldo.SumaDebeRegContabCabe = iImporte
                        Else
                            iObjSaldo.SumaHaberRegContabCabe = iImporte
                        End If
                        ' MsgBox(pListaMovimientoDetalle.Item(n).CodigoCuentaPcge)
                        iListaResultado.Item(m - 2).Add(iObjSaldo)
                    Else
                        Dim iRecorre As Integer = 0
                        'SI LA LISTA TIENE POR LO MENOS UN REGISTRO ENTONCES BUSCAMOS EL OBJETO
                        For Each xObj As SuperEntidad In iListaResultado.Item(m - 2)
                            If iCuenta = xObj.CodigoCuentaPcge Then
                                'PREGUNTAR SI ES UN DEBE O HABER
                                If iDebeHaber = "1" Then 'debe
                                    xObj.SumaDebeRegContabCabe += iImporte
                                Else
                                    xObj.SumaHaberRegContabCabe += iImporte
                                End If
                                Exit For
                            End If
                            'SI EN CADA PASO NO ENCUENTRA EL OBJETO 
                            iRecorre += 1
                        Next
                        'SI NO LO ENCONTRO EL OBJETO ENTONCES PONEMOS EL OBJETO
                        If iRecorre = iNumeroObjetos Then
                            iObjSaldo = New SuperEntidad
                            'iObjSaldo = pListaMovimientoDetalle.Item(n)
                            iObjSaldo.CodigoCuentaPcge = iCuenta
                            If iDebeHaber = "1" Then 'debe
                                iObjSaldo.SumaDebeRegContabCabe = iImporte
                            Else
                                iObjSaldo.SumaHaberRegContabCabe = iImporte
                            End If
                            iListaResultado.Item(m - 2).Add(iObjSaldo)
                        End If
                    End If
                Next

                'AQUI SE VA EJECUTANDO CADA OBJETO DE LA LISTA
                iContadorObjeto += 1
                If (iContadorObjeto Mod iRazon = 0) Then
                    iContadorVueltas += 1
                    Me.eIncremento = 1
                    Me.BackgroundWorker1.ReportProgress(1)
                End If

                If (iContadorVueltas = iNroVueltas And iContadorObjeto = iNroObjetos) Then
                    Me.eIncremento = iIncrementoFinal
                    Me.BackgroundWorker1.ReportProgress(1)
                End If
            Next
        End If

    End Sub

    Sub ListarSaldosContablesAdicionYModificacion()
        'INICIA EL INCREMENTYO EN CERO
        'Me.eIncremento = 0
        Me.eProcesoActual = "Procesando Saldos Contables"

        'LISTAR YTODOS LOS SALDOS CONTABLES PARA EL PERIODO
        Dim iSalCon As New SuperEntidad
        iSalCon.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iSalCon.PeriodoRegContabCabe = Me.txtAno.Text.Trim
        iSalCon.CampoOrden = cam.CodCtaPcge
        Dim iLisSalCon As List(Of SuperEntidad) = sc.obtenerSaldoContableXPeriodo(iSalCon)

        'INICIAR EL PROCESO
        If iListaResultado.Count = 0 Then
            Me.eIncremento = 20
            Me.BackgroundWorker1.ReportProgress(1)
        Else
            Dim iNroObjetos As Integer = iListaResultado.Count
            Dim iRazon As Integer = (iNroObjetos \ 20) + 1
            Dim iNroVueltas As Integer = iNroObjetos \ iRazon
            Dim iIncrementoFinal As Integer = 20 - iNroVueltas
            Dim iContadorObjeto As Integer = 0
            Dim iContadorVueltas As Integer = 0

            'RECORRER CADA SALDO PARA LUEGO MANDAR A GRABAR
            For Each xLis As List(Of SuperEntidad) In iListaResultado
                For Each xObj As SuperEntidad In xLis
                    Dim iSalEN As New SuperEntidad
                    iSalEN.ClaveSaldoContable = Me.TxtCodEmp.Text.Trim + xObj.CodigoCuentaPcge + Me.txtAno.Text.Trim
                    iSalEN = sc.buscarCuentaSaldoExisPorClave(iSalEN, iLisSalCon)

                    'SI NO EXISTE EN B.D ENTONCES SE CREA
                    If iSalEN.ClaveSaldoContable = String.Empty Then
                        iSalEN.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
                        iSalEN.CodigoCuentaPcge = xObj.CodigoCuentaPcge
                        iSalEN.MesCreadoSaldoContable = Me.txtCodMes.Text.Trim
                        iSalEN.PeriodoRegContabCabe = Me.txtAno.Text.Trim
                        iSalEN.EstadoSaldoContable = ""
                        iSalEN.Exporta = "0"
                        Me.ModificarHaberDebeSegunMes(xObj, iSalEN, Me.txtCodMes.Text.Trim)
                        iSalEN.ClaveSaldoContable = iSalEN.CodigoEmpresa + iSalEN.CodigoCuentaPcge + iSalEN.PeriodoRegContabCabe
                        Me.listaSalConAdi.Add(iSalEN)
                    Else
                        'SI EXISTE ENTONCES SOLO MODIFICA DEBES Y HABERES
                        Me.ModificarHaberDebeSegunMes(xObj, iSalEN, Me.txtCodMes.Text.Trim)
                        ''PREGUNTA MES DE CREACION DE CUENTA
                        If iSalEN.NumeroDigitosPcge = parEn.DigitosCuentaAnalitica Then
                            If Me.txtCodMes.Text.Trim < iSalEN.MesCreadoSaldoContable Then
                                iSalEN.MesCreadoSaldoContable = Me.txtCodMes.Text.Trim
                            End If
                        End If
                        Me.listaSalConMod.Add(iSalEN)
                    End If

                Next

                'AQUI SE VA EJECUTANDO CADA OBJETO DE LA LISTA
                iContadorObjeto += 1
                If (iContadorObjeto Mod iRazon = 0) Then
                    iContadorVueltas += 1
                    Me.eIncremento = 1
                    Me.BackgroundWorker1.ReportProgress(1)
                End If

                If (iContadorVueltas = iNroVueltas And iContadorObjeto = iNroObjetos) Then
                    Me.eIncremento = iIncrementoFinal
                    Me.BackgroundWorker1.ReportProgress(1)
                End If
            Next
        End If





    End Sub

    Sub GrabarSaldosContables()

        'INICIA NUEVO PROCESO
        Me.eProcesoActual = "Grabando Saldos contables"

        'GRABAR NUEVOS SALDOS CONTABLES
        sc.NuevoSaldoContableMasivo(Me.listaSalConAdi)

        'GRABAR MODIFICACION SALDO CONTABLES
        sc.ModificarSaldoContableMasivo(Me.listaSalConMod)

        'INCREMENTAMOS EL PROCESO
        Me.eIncremento = 20
        Me.BackgroundWorker1.ReportProgress(1)

    End Sub


    Sub LlenarGrilla(ByRef Dgv As DataGridView, ByVal Indice As Integer, ByVal obj As SuperEntidad)
        Dgv.Rows.Add()
        Dgv.Rows(Indice).Cells(0).Value = obj.CodigoOrigen
        Dgv.Rows(Indice).Cells(1).Value = obj.CodigoFile
        Dgv.Rows(Indice).Cells(2).Value = obj.NumeroVoucherRegContabCabe
        Dgv.Rows(Indice).Cells(3).Value = obj.ImporteRegContabCabe
    End Sub

    Sub ConsistenciaBancos()
        'INDICE DEL REGISTRO QUE LLENARA EN LA GRILLA DGVBANCOS
        Dim n As Integer = -1
        ''RECORRER LISTA REGISTROS CONTABLES CABECERA
        For Each obj As SuperEntidad In listaRc
            If (obj.CodigoOrigen = "1" Or obj.CodigoOrigen = "2") Then
                'SI ULTIMOCORRELATIVO ES '0000' QUIERE DECIR QUE NO HAY DETALLE
                'EN ESTE REGISTRO CABECERA POR LO TANTO LLENAMOS LA GRILLA DGVBANCOS
                If obj.UltimoCorrelativo = "0000" Then
                    n += 1
                    Me.LlenarGrilla(Me.dgvBancos, n, obj)
                End If
            Else
                'SI EL ORIGEN ES DIFERENTE DE 1 O 2 ENTONCES SALE DEL FOR
                Exit For
            End If
        Next

    End Sub

    Sub ConsistenciaVoucher()
        Dim lis As New List(Of SuperEntidad)
        Dim n As Integer = -1
        ''Recorrer archivo cabecera 
        For Each obj As SuperEntidad In listaRc
            If obj.EstadoRegistro = "0" Then
                Select Case obj.CodigoOrigen
                    Case "1", "2"
                        'VALIDANDO VOUCHERS DESCUADRADOS
                        If obj.SumaDebeRegContabCabe = obj.SumaHaberRegContabCabe Then
                            If obj.ImporteSolRegContabCabe <> obj.SumaDebeRegContabCabe Then
                                n = n + 1
                                Me.LlenarGrilla(Me.DgvVoucher, n, obj)
                            End If
                        Else
                            n = n + 1
                            Me.LlenarGrilla(Me.DgvVoucher, n, obj)
                        End If

                    Case "3"
                        If obj.SumaDebeRegContabCabe <> obj.SumaHaberRegContabCabe Then
                            n = n + 1
                            Me.LlenarGrilla(Me.DgvVoucher, n, obj)
                        End If

                    Case "4"

                        If obj.CodigoFile = "410" Or obj.CodigoFile = "411" Or obj.CodigoFile = "412" Then
                            If obj.SumaDebeRegContabCabe = obj.SumaHaberRegContabCabe Then
                                If obj.ImporteSolRegContabCabe <> obj.SumaDebeRegContabCabe Then
                                    n = n + 1
                                    Me.LlenarGrilla(Me.DgvVoucher, n, obj)
                                End If
                            Else
                                n = n + 1
                                Me.LlenarGrilla(Me.DgvVoucher, n, obj)
                            End If

                        End If
                End Select
            End If
        Next
    End Sub

    Function ExisenRegContabCabe() As Boolean
        Dim lis As New List(Of SuperEntidad)
        Dim obrc As New SuperEntidad
        obrc.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        obrc.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        obrc.CampoOrden = cam.CodOriRC
        lis = rcc.obtenerRegContabCabePorPeriodoParaContabilizar(obrc)

        If lis.Count = 0 Then
            MsgBox("Periodo Sin Registros Contables", MsgBoxStyle.Exclamation, "Contabilizacion")
            Return False
        Else
            Return True
        End If
    End Function

    Sub SaldosACero()
        Dim LisSal As New List(Of SuperEntidad)
        Dim oSal As New SuperEntidad
        oSal.PeriodoRegContabCabe = Me.txtAno.Text.Trim
        oSal.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        oSal.CampoOrden = cam.CodCtaPcge
        LisSal = sc.obtenerSaldoContableXPeriodo(oSal)
        For Each p As SuperEntidad In LisSal
            Select Case Me.txtCodMes.Text.Trim
                Case "00"
                    p.DebeS00SaldoContable = 0
                    p.HabeS00SaldoContable = 0
                    p.DebeD00SaldoContable = 0
                    p.HabeD00SaldoContable = 0
                Case "01"
                    p.DebeS01SaldoContable = 0
                    p.HabeS01SaldoContable = 0
                    p.DebeD01SaldoContable = 0
                    p.HabeD01SaldoContable = 0
                Case "02"
                    p.DebeS02SaldoContable = 0
                    p.HabeS02SaldoContable = 0
                    p.DebeD02SaldoContable = 0
                    p.HabeD02SaldoContable = 0
                Case "03"
                    p.DebeS03SaldoContable = 0
                    p.HabeS03SaldoContable = 0
                    p.DebeD03SaldoContable = 0
                    p.HabeD03SaldoContable = 0
                Case "04"
                    p.DebeS04SaldoContable = 0
                    p.HabeS04SaldoContable = 0
                    p.DebeD04SaldoContable = 0
                    p.HabeD04SaldoContable = 0
                Case "05"
                    p.DebeS05SaldoContable = 0
                    p.HabeS05SaldoContable = 0
                    p.DebeD05SaldoContable = 0
                    p.HabeD05SaldoContable = 0
                Case "06"
                    p.DebeS06SaldoContable = 0
                    p.HabeS06SaldoContable = 0
                    p.DebeD06SaldoContable = 0
                    p.HabeD06SaldoContable = 0
                Case "07"
                    p.DebeS07SaldoContable = 0
                    p.HabeS07SaldoContable = 0
                    p.DebeD07SaldoContable = 0
                    p.HabeD07SaldoContable = 0
                Case "08"
                    p.DebeS08SaldoContable = 0
                    p.HabeS08SaldoContable = 0
                    p.DebeD08SaldoContable = 0
                    p.HabeD08SaldoContable = 0
                Case "09"
                    p.DebeS09SaldoContable = 0
                    p.HabeS09SaldoContable = 0
                    p.DebeD09SaldoContable = 0
                    p.HabeD09SaldoContable = 0
                Case "10"
                    p.DebeS10SaldoContable = 0
                    p.HabeS10SaldoContable = 0
                    p.DebeD10SaldoContable = 0
                    p.HabeD10SaldoContable = 0
                Case "11"
                    p.DebeS11SaldoContable = 0
                    p.HabeS11SaldoContable = 0
                    p.DebeD11SaldoContable = 0
                    p.HabeD11SaldoContable = 0
                Case "12"
                    p.DebeS12SaldoContable = 0
                    p.HabeS12SaldoContable = 0
                    p.DebeD12SaldoContable = 0
                    p.HabeD12SaldoContable = 0
                Case "13"
                    p.DebeS13SaldoContable = 0
                    p.HabeS13SaldoContable = 0
                    p.DebeD13SaldoContable = 0
                    p.HabeD13SaldoContable = 0
            End Select
        Next

        'UNA VEZ ACTUALIZADA LA LISTA DE SALDOS A CERO
        'MANDAMOS A MODIFICAR TODO
        'Modificar saldo a cero (0) por mes
        sc.ModificarSaldoContableMasivo(LisSal)

    End Sub

    Sub ModificarHaberDebeSegunMes(ByRef pObjActualiza As SuperEntidad, ByRef pObjActualizado As SuperEntidad, ByVal pMes As String)
        Select Case pMes
            Case "00"
                pObjActualizado.DebeS00SaldoContable = pObjActualiza.SumaDebeRegContabCabe
                pObjActualizado.HabeS00SaldoContable = pObjActualiza.SumaHaberRegContabCabe

            Case "01"
                pObjActualizado.DebeS01SaldoContable = pObjActualiza.SumaDebeRegContabCabe
                pObjActualizado.HabeS01SaldoContable = pObjActualiza.SumaHaberRegContabCabe

            Case "02"
                pObjActualizado.DebeS02SaldoContable = pObjActualiza.SumaDebeRegContabCabe
                pObjActualizado.HabeS02SaldoContable = pObjActualiza.SumaHaberRegContabCabe

            Case "03"
                pObjActualizado.DebeS03SaldoContable = pObjActualiza.SumaDebeRegContabCabe
                pObjActualizado.HabeS03SaldoContable = pObjActualiza.SumaHaberRegContabCabe

            Case "04"
                pObjActualizado.DebeS04SaldoContable = pObjActualiza.SumaDebeRegContabCabe
                pObjActualizado.HabeS04SaldoContable = pObjActualiza.SumaHaberRegContabCabe

            Case "05"
                pObjActualizado.DebeS05SaldoContable = pObjActualiza.SumaDebeRegContabCabe
                pObjActualizado.HabeS05SaldoContable = pObjActualiza.SumaHaberRegContabCabe

            Case "06"
                pObjActualizado.DebeS06SaldoContable = pObjActualiza.SumaDebeRegContabCabe
                pObjActualizado.HabeS06SaldoContable = pObjActualiza.SumaHaberRegContabCabe

            Case "07"
                pObjActualizado.DebeS07SaldoContable = pObjActualiza.SumaDebeRegContabCabe
                pObjActualizado.HabeS07SaldoContable = pObjActualiza.SumaHaberRegContabCabe

            Case "08"
                pObjActualizado.DebeS08SaldoContable = pObjActualiza.SumaDebeRegContabCabe
                pObjActualizado.HabeS08SaldoContable = pObjActualiza.SumaHaberRegContabCabe

            Case "09"
                pObjActualizado.DebeS09SaldoContable = pObjActualiza.SumaDebeRegContabCabe
                pObjActualizado.HabeS09SaldoContable = pObjActualiza.SumaHaberRegContabCabe

            Case "10"
                pObjActualizado.DebeS10SaldoContable = pObjActualiza.SumaDebeRegContabCabe
                pObjActualizado.HabeS10SaldoContable = pObjActualiza.SumaHaberRegContabCabe

            Case "11"
                pObjActualizado.DebeS11SaldoContable = pObjActualiza.SumaDebeRegContabCabe
                pObjActualizado.HabeS11SaldoContable = pObjActualiza.SumaHaberRegContabCabe

            Case "12"
                pObjActualizado.DebeS12SaldoContable = pObjActualiza.SumaDebeRegContabCabe
                pObjActualizado.HabeS12SaldoContable = pObjActualiza.SumaHaberRegContabCabe
            Case "13"
                pObjActualizado.DebeS13SaldoContable = pObjActualiza.SumaDebeRegContabCabe
                pObjActualizado.HabeS13SaldoContable = pObjActualiza.SumaHaberRegContabCabe

        End Select


    End Sub

    Private Sub btnEjecutar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEjecutar.Click
        If acc.CamposObligatorios = False Then
            Exit Sub
        Else
            'limpiar las grillas antes de ejecutar
            Me.dgvBancos.Rows.Clear()
            Me.DgvVoucher.Rows.Clear()

            'limpiar todo lo relacionado al proceso anterior de contabilizacion
            Me.LimpiarParaNuevaContabilizacion()

            'validar los registros antes de contabilizar
            If Me.EsValidoContabilizar = False Then Exit Sub

            'deshabilitar los controles de la ventana
            Me.Enabled = False

            'si se valida ok entonces procesamos la contabilizacion
            Me.ProgressBar1.Value = 0
            Me.eIncremento = 0
            Me.BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub


#Region "Mostrar Formulario lista"

    Private Sub txtCodMes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodMes.KeyDown
        If Me.txtCodMes.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarTabla
                win.tabla = "Mes"
                win.titulo = "Meses"
                win.txt1 = Me.txtCodMes
                win.txt2 = Me.txtDesMes
                win.NuevaVentana()
            End If
        End If
    End Sub


#End Region

#Region "Buscar por codigo"

    Private Sub txtCodMes_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodMes.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.txtCodMes : ope.txt2 = Me.txtDesMes
        ope.MostrarCodigoDescripcionDeTabla("Mes", "Meses", e)

    End Sub


#End Region


    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Me.EjecutarCabeceraMovimiento()
        Me.GrabarCabeceraMovimiento()
        Me.EjecutarDetalleMovimiento()
        Me.GrabarDetalleMovimiento()
        Me.EjecutarListasSaldosContables(CType(parEn.DigitosCuentaAnalitica, Integer))
        Me.ListarSaldosContablesAdicionYModificacion()
        Me.GrabarSaldosContables()
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        'INCREMENTANDO EL PROGRESSBAR
        Me.lblProceso.Text = Me.eProcesoActual
        Me.ProgressBar1.Increment(Me.eIncremento)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Me.Enabled = True
        Me.lblProceso.Text = "Proceso concluido"
        MsgBox("Contabilizacion se realizo Existosamente", MsgBoxStyle.Information, "Contabilizacion")
    End Sub
End Class