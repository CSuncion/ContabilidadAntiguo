Imports Entidad
Imports Negocio

Public Class WCierreAnual

    Public cam As New CamposEntidad
    Dim eIncremento As Integer
    Dim eProcesoActual As String = ""
    Dim eLisRcc As New List(Of SuperEntidad)
    Dim eLisRcd As New List(Of SuperEntidad)

#Region "Propietario"
    'Public wBco As New WCuentaBanco
#End Region

#Region "General"

    Sub InicializaVentana()
        Me.Show()
    End Sub

    Sub NuevaVenta()
        Me.InicializaVentana()
        Me.PorDefecto()
        Me.btnAceptar.Focus()
    End Sub

    Sub PorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.TxtNomEmp.Text = SuperEntidad.xRazonSocial
        Me.txtAno.Text = SuperEntidad.xPeriodoEmpresa.Substring(0, 4)
        Me.txtCodMes.Text = SuperEntidad.xPeriodoEmpresa.Substring(4)
        Me.txtDesMes.Text = SuperEntidad.xMesPeriodo
    End Sub

    Sub EjecutarAsientoXCuentaSaldo()

        'INICIA NUEVO PROCESO
        Me.eProcesoActual = "Procesando Asiento de cuenta a Saldo"

        'VARIABLES DE NEGOCIO
        Dim iRccRN As New RegContabCabeRN
        Dim iRcdRN As New RegContabDetaRN
        Dim iSalRN As New SaldoContableRN
        Dim iParRN As New ParametroRN
        Dim iCtaRN As New PlanCuentaGeRN

        'CARGAR EL OBJETO PARAMETRO
        Dim iParEN As New SuperEntidad
        iParEN = iParRN.buscarParametroExis(iParEN)

        'CARGAR LAS CUENTAS DE 2 DIGITOS QUE VAN A PROCESAR
        'PARA EL ASIENTO DE APERTURA
        Dim iCtaEN As New SuperEntidad
        iCtaEN.CampoOrden = cam.CodCtaPcge
        Dim iLisCta As List(Of SuperEntidad) = iCtaRN.ListarCuentasAnaliticasParaCierreAnual(iCtaEN)

        'CARGAR UNA LISTA DE TODOS LOS SALDOS CONTABLES DESDE 10 HASTA 59
        Dim iSalEN As New SuperEntidad
        iSalEN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iSalEN.NumeroDigitosPcge = iParEN.DigitosCuentaAnalitica
        iSalEN.PeriodoRegContabCabe = Me.txtAno.Text.Trim
        iSalEN.CampoOrden = cam.CodCtaPcge
        Dim iLisSal As List(Of SuperEntidad) = iSalRN.ListarSaldosContableParaCierreAnual(iSalEN)

        'DEBEMOS TRAERNOS AL MAYOR TIPO DE CAMBIO DEL MES DE PROCESO
        Dim iTipCamRN As New TipoCambioRN
        Dim iTipCamEN As New SuperEntidad
        iTipCamEN.AnoTipoCambio = Me.txtAno.Text.Trim
        iTipCamEN.MesTipoCambio = Me.txtCodMes.Text.Trim
        Dim iTipoCambio As Decimal = iTipCamRN.ObtenerUltimoTipoCambioDelMes(iTipCamEN).VentaTipoCambio

        'OBTENER AÑO  
        Dim iAnoAper As Integer = CType(Me.txtAno.Text, Integer) + 1

        'CRAENDO EL OBJETO CABECERA Y OBTENER SU NUEVO CORRELATIVO DE VOUCHER
        Dim iRccEN As New SuperEntidad
        iRccEN.AnoCuentaBanco = iAnoAper.ToString
        iRccEN.NumeroVoucherRegContabCabe = "00001"

        'OBTENER TODO EL DETALLE CUADRADO Y SU CABECERA
        iRcdRN.ObtenerCabeceraYDetalleXSaldoCierreAnual(iRccEN, Me.eLisRcd, iLisCta, iLisSal, iTipoCambio)

        'ADICIONAR EL NUEVO OBJETO CABECERA CON TODOS SUS DATOS
        Me.eLisRcc.Add(iRccEN)

        'INCREMENTAMOS EL PROCESO
        Me.eIncremento = 10
        Me.BackgroundWorker1.ReportProgress(1)
    End Sub

    Sub GrabarAsientoXCuentaSaldo()

        'INICIA NUEVO PROCESO
        Me.eProcesoActual = "Grabando Asiento de cuenta a Saldo"

        'VARIABLES DE NEGOCIO
        Dim iRccRN As New RegContabCabeRN
        Dim iRcdRN As New RegContabDetaRN

        'GRABAR CABECERA
        iRccRN.NuevoRegContabCabeMasivo(Me.eLisRcc)
        Me.eLisRcc.Clear()

        'GRABAR DETALLE
        iRcdRN.NuevoRegContabDetaMasivo(Me.eLisRcd)
        Me.eLisRcd.Clear()

        'INCREMENTAMOS EL PROCESO
        Me.eIncremento = 10
        Me.BackgroundWorker1.ReportProgress(1)

    End Sub

    Sub EjecutarAsientosXCuenta()
        Me.eProcesoActual = "Procesando Asientos de apertura cuenta a cuenta"

        'VARIABLES DE NEGOCIO
        Dim iRccRN As New RegContabCabeRN
        Dim iRcdRN As New RegContabDetaRN
        Dim iCtaRN As New PlanCuentaGeRN

        'CARGAR LAS CUENTAS DE 2 DIGITOS QUE VAN A PROCESAR
        'PARA EL ASIENTO DE APERTURA
        Dim iCtaEN As New SuperEntidad
        iCtaEN.CampoOrden = cam.CodCtaPcge
        Dim iLisCta As List(Of SuperEntidad) = iCtaRN.ListarCuentasAnaliticasParaCierreAnual(iCtaEN)

        'CARGAR UNA LISTAS DE LISTAS QUE CONTENGAN EL MOVIMIENTO DE UNA CUENTA
        'EN CADA LISTA
        Dim iRcdEN As New SuperEntidad
        iRcdEN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iRcdEN.DatoCondicion1 = Me.txtAno.Text.Trim + "00"
        iRcdEN.DatoCondicion2 = Me.txtAno.Text.Trim + "12"
        iRcdEN.CampoOrden = cam.CodCtaPcge + "," + cam.CodAux + "," + cam.CodTipDoc + "," + cam.SerDoC + "," + cam.NumDoc
        Dim iLisRcd As List(Of List(Of SuperEntidad)) = iRcdRN.ListarRegistroDetalleParaCierreAnual(iRcdEN)

        'DEBEMOS TRAERNOS AL MAYOR TIPO DE CAMBIO DEL MES DE PROCESO
        Dim iTipCamRN As New TipoCambioRN
        Dim iTipCamEN As New SuperEntidad
        iTipCamEN.AnoTipoCambio = Me.txtAno.Text.Trim
        iTipCamEN.MesTipoCambio = Me.txtCodMes.Text.Trim
        Dim iTipoCambio As Decimal = iTipCamRN.ObtenerUltimoTipoCambioDelMes(iTipCamEN).VentaTipoCambio

        'OBTENER AÑO DE APERTURA
        Dim iAnoAper As Integer = CType(Me.txtAno.Text, Integer) + 1

        'SI LA LISTA  ESTA VACIA ENTONCES  INCREMENTAMOS EN UN 60% EL PROGRESSBAR
        If iLisRcd.Count = 0 Then
            Me.eIncremento = 60
            Me.BackgroundWorker1.ReportProgress(1)
        Else
            'VARIABLES DE CONTROL DEL PROGRESSBAR
            Dim iNroObjetos As Integer = iLisRcd.Count
            Dim iRazon As Integer = (iNroObjetos \ 60) + 1
            Dim iNroVueltas As Integer = iNroObjetos \ iRazon
            Dim iIncrementoFinal As Integer = 60 - iNroVueltas
            Dim iContadorObjeto As Integer = 0
            Dim iContadorVueltas As Integer = 0

            'RECORREMOS CADA LISTA DE LISTA DE CUENTA
            For Each xLisCta As List(Of SuperEntidad) In iLisRcd

                'SACAR LA LISTA DE LA LISTAS
                Dim iLisCtaDet As New List(Of SuperEntidad)
                iLisCtaDet = xLisCta

                'PREGUNTAR SI LA CUENTA DE ESTA LISTA ES PARTE DE LAS CUENTAS
                'DE CIERRE ANUAL
                iCtaEN.CodigoCuentaPcge = iLisCtaDet(0).CodigoCuentaPcge.Substring(0, 2)
                iCtaEN = iCtaRN.buscarCuentaExisPorCodigo(iCtaEN, iLisCta)

                If iCtaEN.CodigoCuentaPcge <> "" Then

                    'AQUI LA CUENTA DE ESTA LISTA SI ES PARTE DE LAS CUENTAS DE CIERRE ANUAL
                    iLisCtaDet = iRcdRN.ListarSaldosPorAuxiliarYDocumentosSaldo(iLisCtaDet)

                    'SOLO SI HAY DETALLE AVANZA
                    If iLisCtaDet.Count <> 0 Then
                        'CREANDO EL OBJETO CABECERA Y OBTENER SU NUEVO CORRELATIVO DE VOUCHER
                        Dim iRccEN As New SuperEntidad
                        iRccEN.AnoCuentaBanco = iAnoAper.ToString
                        iRccEN.NumeroVoucherRegContabCabe = (Me.eLisRcc.Count + 2).ToString.PadLeft(5, CType("0", Char))

                        'OBTENER TODO EL DETALLE CUADRADO PARA LA CUENTA EN PROCESO
                        iRcdRN.ObtenerCabeceraYDetalleXCuentaCierreAnual(iRccEN, iLisCtaDet, iTipoCambio)

                        'ADICIONAR EL NUEVO OBJETO CABECERA CON TODOS SUS DATOS
                        Me.eLisRcc.Add(iRccEN)

                        'ADICIONAR EL NUEVO DETALLE DEL OBJETO CABECERA CON TODOS SUS DATOS
                        Me.eLisRcd.AddRange(iLisCtaDet)
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

    Sub GrabarAsientoXCuenta()
        'INICIA NUEVO PROCESO
        Me.eProcesoActual = "Grabando Asiento de cuenta"

        'VARIABLES DE NEGOCIO
        Dim iRccRN As New RegContabCabeRN
        Dim iRcdRN As New RegContabDetaRN
        Dim iVouRN As New VoucherRN

        'GRABAR EL ULTIMO NUMERO EN LA TABLA VOUCHER
        'OBTENER AÑO DE APERTURA
        Dim iAnoAper As Integer = CType(Me.txtAno.Text, Integer) + 1
        Dim ivouEN As New SuperEntidad
        ivouEN.DatoCondicion1 = Me.TxtCodEmp.Text + iAnoAper.ToString + "398"
        ivouEN = iVouRN.buscarVoucherActPorCodigo(ivouEN)
        ivouEN.AperturaVoucher = (Me.eLisRcc.Count + 1).ToString.PadLeft(5, CType("0", Char))
        iVouRN.modificarVoucher(ivouEN)

        'GRABAR CABECERA
        iRccRN.NuevoRegContabCabeMasivo(Me.eLisRcc)
        Me.eLisRcc.Clear()

        'GRABAR DETALLE
        iRcdRN.NuevoRegContabDetaMasivo(Me.eLisRcd)
        Me.eLisRcd.Clear()

        'INCREMENTAMOS EL PROCESO
        Me.eIncremento = 20
        Me.BackgroundWorker1.ReportProgress(1)

    End Sub

    Sub LimpiarAntesDeProceso()
        'ELIMINAMOS TODA LA CABECERA DE APERTURA PERO SOLO DEL FILE( 398 )
        Dim iRccRN As New RegContabCabeRN
        Dim iRccEN As New SuperEntidad
        iRccEN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        'OBTENER AÑO DE APERTURA
        Dim iAnoAper As Integer = CType(Me.txtAno.Text, Integer) + 1
        iRccEN.PeriodoRegContabCabe = iAnoAper.ToString + "00"
        iRccEN.CodigoFile = "398"
        iRccRN.EliminarRegContabCabeDeCierreAnual(iRccEN)

        'ELIMINAMOS TODO EL DETALLE DE APERTURA PERO SOLO DEL FILE( 398 )
        Dim iRcdRN As New RegContabDetaRN
        Dim iRcdEN As New SuperEntidad
        iRcdEN.ClaveRegContabCabe += iRccEN.CodigoEmpresa
        iRcdEN.ClaveRegContabCabe += iRccEN.PeriodoRegContabCabe
        iRcdEN.ClaveRegContabCabe += "3" + iRccEN.CodigoFile
        iRcdRN.EliminarRegistroDetalleParaCierreAnual(iRcdEN)

        'DESHABILITAR LA VENTANA
        Me.Enabled = False
    End Sub

    Function EsMesDeDiciembre() As Boolean
        If Me.txtCodMes.Text <> "12" Then
            MsgBox("Solo se puede cerrar en el mes de diciembre", MsgBoxStyle.Exclamation, "Cierre anual")
            Return False
        Else
            Return True
        End If
    End Function

    Function HayMesDeApertura() As Boolean
        'OBTENER AÑO  DE APERTURA
        Dim iAnoAper As Integer = CType(Me.txtAno.Text, Integer) + 1
        'PREGUNTAR SI HAY PERIODO DE APERTURA
        Dim iPerRN As New PeriodoRN
        Dim iPerEN As New SuperEntidad
        iPerEN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iPerEN.CodigoPeriodo = iAnoAper.ToString + "00"
        iPerEN = iPerRN.EsPeriodoDeApertura(iPerEN)
        If iPerEN.EsVerdad = False Then
            MsgBox(iPerEN.Mensaje, MsgBoxStyle.Exclamation, "Periodo")
        End If
        Return iPerEN.EsVerdad
    End Function

    Function HayFileDeApertura() As Boolean
        'PREGUNTAR SI HAY FILE DE APERTURA
        Dim iFilRN As New FilesRN
        Dim iFilEN As New SuperEntidad
        iFilEN.ClaveFile = SuperEntidad.xCodigoEmpresa + "398"
        iFilEN = iFilRN.HayFileDeApertura(iFilEN)
        If iFilEN.EsVerdad = False Then
            MsgBox(iFilEN.Mensaje, MsgBoxStyle.Exclamation, "File")
        End If
        Return iFilEN.EsVerdad
    End Function

    Sub Ejecutar()
        'VERIFICAR QUE EL USUARIO ESTE EN EL MES DE DICIEMBRE
        If Me.EsMesDeDiciembre = False Then Exit Sub

        'VERIFICAR QUE YA ESTE CREADO EL PERIODO DE APERTURA
        If Me.HayMesDeApertura = False Then Exit Sub

        'VERIFICAR QUE EXISTA EL FILE DE APERTURA(398)
        If Me.HayFileDeApertura = False Then Exit Sub

        'INICIAMOS EL PROCESO DE CIERRE
        Me.LimpiarAntesDeProceso()
        Me.ProgressBar1.Value = 0
        Me.eIncremento = 0
        Me.BackgroundWorker1.RunWorkerAsync()
    End Sub

#End Region


    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.Ejecutar()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        'INCREMENTANDO EL PROGRESSBAR
        Me.lblProceso.Text = Me.eProcesoActual
        Me.ProgressBar1.Increment(Me.eIncremento)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Me.Enabled = True
        Me.lblProceso.Text = "Proceso concluido"
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Me.EjecutarAsientoXCuentaSaldo()
        Me.GrabarAsientoXCuentaSaldo()
        Me.EjecutarAsientosXCuenta()
        Me.GrabarAsientoXCuenta()
    End Sub
End Class