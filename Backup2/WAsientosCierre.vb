Imports Entidad
Imports Negocio

Public Class WAsientosCierre

    Public cam As New CamposEntidad
    Dim eIncremento As Integer
    Dim eProcesoActual As String = ""
    Dim eLisRcc As New List(Of SuperEntidad)
    Dim eLisRcd As New List(Of SuperEntidad)
    Dim eLisSal As New List(Of SuperEntidad)
    Dim eParEN As New SuperEntidad
    Dim eTipoCambio As Decimal

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

    Sub EjecutarAsientoCierreEgresos()

        'VARIABLES DE NEGOCIO
        Dim iRccRN As New RegContabCabeRN
        Dim iRcdRN As New RegContabDetaRN
        Dim iSalRN As New SaldoContableRN
        Dim iParRN As New ParametroRN
        Dim iCtaRN As New PlanCuentaGeRN

        'CARGAR EL OBJETO PARAMETRO
        eParEN = iParRN.buscarParametroExis(eParEN)

        'CARGAR LAS CUENTAS DE 2 DIGITOS QUE VAN A PROCESAR
        'PARA EL ASIENTO DE CIERRE
        Dim iCtaEN As New SuperEntidad
        iCtaEN.CampoOrden = cam.CodCtaPcge
        Dim iLisCta As List(Of SuperEntidad) = iCtaRN.ListarCuentasParaAsientoCierreClase9(iCtaEN) 'XXXXXXXXXXX

        'CARGAR UNA LISTA DE TODOS LOS SALDOS CONTABLES DE LA EMPRESA Y DEL AÑO
        Dim iSalEN As New SuperEntidad
        iSalEN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iSalEN.NumeroDigitosPcge = eParEN.DigitosCuentaAnalitica
        iSalEN.PeriodoRegContabCabe = Me.txtAno.Text.Trim
        iSalEN.CampoOrden = cam.CodCtaPcge
        eLisSal = iSalRN.ListarSaldosContableXPeriodoYAnaliticas(iSalEN)

        'DEBEMOS TRAERNOS AL MAYOR TIPO DE CAMBIO DEL MES DE PROCESO
        Dim iTipCamRN As New TipoCambioRN
        Dim iTipCamEN As New SuperEntidad
        iTipCamEN.AnoTipoCambio = Me.txtAno.Text.Trim
        iTipCamEN.MesTipoCambio = "12"
        eTipoCambio = iTipCamRN.ObtenerUltimoTipoCambioDelMes(iTipCamEN).VentaTipoCambio

        'CREANDO EL OBJETO CABECERA Y OBTENER SU NUEVO CORRELATIVO DE VOUCHER
        Dim iRccEN As New SuperEntidad
        iRccEN.AnoCuentaBanco = Me.txtAno.Text
        iRccEN.NumeroVoucherRegContabCabe = "00001"

        'OBTENER TODO EL DETALLE CUADRADO Y SU CABECERA
        iRcdRN.ObtenerCabeceraYDetalleXAsientoCierreEgreso(iRccEN, Me.eLisRcd, iLisCta, eLisSal, eTipoCambio, eParEN)

        'ADICIONAR EL NUEVO OBJETO CABECERA CON TODOS SUS DATOS
        Me.eLisRcc.Add(iRccEN)

    End Sub

    Sub EjecutarAsientoCierreIngresos()

        'VARIABLES DE NEGOCIO
        Dim iRcdRN As New RegContabDetaRN
        Dim iCtaRN As New PlanCuentaGeRN

        'CARGAR LAS CUENTAS DE 2 DIGITOS QUE VAN A PROCESAR
        'PARA EL ASIENTO DE CIERRE
        Dim iCtaEN As New SuperEntidad
        iCtaEN.CampoOrden = cam.CodCtaPcge
        Dim iLisCta As List(Of SuperEntidad) = iCtaRN.ListarCuentasParaAsientoCierreClase7(iCtaEN) 'XXXXXXXXXXX

        'CRAENDO EL OBJETO CABECERA Y OBTENER SU NUEVO CORRELATIVO DE VOUCHER
        Dim iRccEN As New SuperEntidad
        iRccEN.AnoCuentaBanco = Me.txtAno.Text
        iRccEN.NumeroVoucherRegContabCabe = "00002"

        'OBTENER TODO EL DETALLE CUADRADO Y SU CABECERA
        iRcdRN.ObtenerCabeceraYDetalleXAsientoCierreIngreso(iRccEN, Me.eLisRcd, iLisCta, eLisSal, eTipoCambio, eParEN)

        'ADICIONAR EL NUEVO OBJETO CABECERA CON TODOS SUS DATOS
        Me.eLisRcc.Add(iRccEN)

    End Sub

    Sub EjecutarAsientoCierreCuenta8()
        'VARIABLES DE NEGOCIO
        Dim iRccRN As New RegContabCabeRN
        Dim iRcdRN As New RegContabDetaRN

        'CRAENDO EL OBJETO CABECERA Y OBTENER SU NUEVO CORRELATIVO DE VOUCHER
        Dim iRccEN As New SuperEntidad
        iRccEN.AnoCuentaBanco = Me.txtAno.Text
        iRccEN.NumeroVoucherRegContabCabe = "00003"

        'OBTENER TODO EL DETALLE CUADRADO Y SU CABECERA
        iRcdRN.ObtenerCabeceraYDetalleXAsientoCierreCuenta8(iRccEN, Me.eLisRcc, Me.eLisRcd, eTipoCambio, eParEN)

        'ADICIONAR EL NUEVO OBJETO CABECERA CON TODOS SUS DATOS
        Me.eLisRcc.Add(iRccEN)
    End Sub

    Sub GrabarAsientos()

        'VARIABLES DE NEGOCIO
        Dim iRccRN As New RegContabCabeRN
        Dim iRcdRN As New RegContabDetaRN

        'GRABAR CABECERA
        iRccRN.NuevoRegContabCabeMasivo(Me.eLisRcc)
        Me.eLisRcc.Clear()

        'GRABAR DETALLE
        iRcdRN.NuevoRegContabDetaMasivo(Me.eLisRcd)
        Me.eLisRcd.Clear()

    End Sub

    Sub LimpiarAntesDeProceso()
        'ELIMINAMOS TODA LA CABECERA DE CIERRE PERO SOLO DEL FILE( 397 )
        Dim iRccRN As New RegContabCabeRN
        Dim iRccEN As New SuperEntidad
        iRccEN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        'OBTENER PERIODO CIERRE
        iRccEN.PeriodoRegContabCabe = Me.txtAno.Text + Me.txtCodMes.Text
        iRccEN.CodigoFile = "397"
        iRccRN.EliminarRegContabCabeDeCierreAnual(iRccEN)

        'ELIMINAMOS TODO EL DETALLE DE CIERRE PERO SOLO DEL FILE( 397 )
        Dim iRcdRN As New RegContabDetaRN
        Dim iRcdEN As New SuperEntidad
        iRcdEN.ClaveRegContabCabe += iRccEN.CodigoEmpresa
        iRcdEN.ClaveRegContabCabe += iRccEN.PeriodoRegContabCabe
        iRcdEN.ClaveRegContabCabe += "3" + iRccEN.CodigoFile
        iRcdRN.EliminarRegistroDetalleParaCierreAnual(iRcdEN)

        'DESHABILITAR LA VENTANA
        Me.Enabled = False
    End Sub

    Function EsMesDeCierre() As Boolean
        If Me.txtCodMes.Text <> "13" Then
            MsgBox("Solo se puede cerrar en el mes de Cierre", MsgBoxStyle.Exclamation, "Cierre")
            Return False
        Else
            Return True
        End If
    End Function

    Function HayFileDeApertura() As Boolean
        'PREGUNTAR SI HAY FILE DE APERTURA
        Dim iFilRN As New FilesRN
        Dim iFilEN As New SuperEntidad
        iFilEN.ClaveFile = SuperEntidad.xCodigoEmpresa + "397"
        iFilEN = iFilRN.HayFileDeAsientoCierre(iFilEN)
        If iFilEN.EsVerdad = False Then
            MsgBox(iFilEN.Mensaje, MsgBoxStyle.Exclamation, "File")
        End If
        Return iFilEN.EsVerdad
    End Function

    Sub Ejecutar()
        'VERIFICAR QUE EL USUARIO ESTE EN EL MES DE DICIEMBRE
        If Me.EsMesDeCierre = False Then Exit Sub

        'VERIFICAR QUE EXISTA EL FILE DE CIERRE(397)
        If Me.HayFileDeApertura = False Then Exit Sub

        'LIMPIAMOS ANTES DE PROCESAR
        Me.LimpiarAntesDeProceso()

        'GENERAR LOS 3 ASIENTOS
        Me.EjecutarAsientoCierreEgresos()
        Me.EjecutarAsientoCierreIngresos()
        Me.EjecutarAsientoCierreCuenta8()

        'GRABAR ASIENTOS
        Me.GrabarAsientos()

        'MENSAJE SATISFACTORIO
        MsgBox("Se generaron los asientos de ciere correctamente", MsgBoxStyle.Information, "Asientos de cierre")

        'salir
        Me.Close()

    End Sub

#End Region


    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.Ejecutar()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

   
End Class