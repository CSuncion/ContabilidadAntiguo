Imports Entidad
Imports Negocio

Public Class WCierreAnualBanco
    Dim acc As New Accion
    Dim Cam As New CamposEntidad
    Dim iLisSalBan As New List(Of SuperEntidad)
    Dim iLisCueBan As New List(Of SuperEntidad)


#Region "General"

    Sub InicializaVentana()
        '/Para los eventos de controles
        acc.listaCtrls = Me.ListaControles
        acc.PasaFoco()
        acc.FomatoDato()
        acc.PasarCursor()
        acc.Teclazo()
        acc.Valida()
        Me.Show()
        Me.PorDefecto()
        Me.btnAceptar.Focus()
    End Sub

    Sub PorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.TxtNomEmp.Text = SuperEntidad.xRazonSocial
        Me.txtAno.Text = SuperEntidad.xPeriodoEmpresa.Substring(0, 4)
        Me.txtCodMes.Text = SuperEntidad.xPeriodoEmpresa.Substring(4, 2)
    End Sub


    Function EsMesDeDiciembre() As Boolean
        If Me.txtCodMes.Text <> "12" Then
            MsgBox("Solo se puede cerrar en el mes de diciembre", MsgBoxStyle.Exclamation, "Cierre anual Cuentas Bancarias")
            Return False
        Else
            Return True
        End If
    End Function

    Sub ObtenerListasParaGrabacion()
        'TRAER LAS LISTAS DE LISTAS DE SALDOS BANCARIOS POR CUENTA
        Dim iSalBanRN As New SaldosBancariosRN
        Dim iSalBanEN As New SuperEntidad
        iSalBanEN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iSalBanEN.AnoCuentaBanco = Me.txtAno.Text.Trim
        iSalBanEN.CampoOrden = Cam.ClaSalBan
        Dim iLisLisSalBan As List(Of List(Of SuperEntidad)) = iSalBanRN.ListarSaldosBancariosParaCierreAnual(iSalBanEN)

        'TRAER LA LISTA DE CUENTAS BANCARIAS
        Dim iCueBanRN As New CuentaBancoRN
        Dim iCueBanEN As New SuperEntidad
        iCueBanEN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iCueBanEN.CampoOrden = Cam.ClaCtaBco
        Dim iLisCB As List(Of SuperEntidad) = iCueBanRN.obtenerCuentaBancoExis(iCueBanEN)

        'NUEVO AÑO PARA LOS SALDOS BANCARIOS
        Dim iAnoNuevo As String = (CType(Me.txtAno.Text.Trim, Integer) + 1).ToString

        'A CADA LISTA LIMPIAR LOS VALORES Y PONER EL SALDO DE DICIEMBRE 
        'Y ADEMAS MODIFICAR EL SALDO DE INICO DE LAS CUENTAS BANCARIAS
        For Each xLisSalBan As List(Of SuperEntidad) In iLisLisSalBan
            'OBTENEMOS LOS SALDOS DEL MES DE DICIEMBRE
            Dim iSalDicSoles As Decimal = xLisSalBan(11).SaldoMesSolCuentaBanco
            Dim iSalDicDolares As Decimal = xLisSalBan(11).SaldoMesDolCuentaBanco

            'SOLO CUANDO EL MES ES ENERO INSERTANMOS LOS VALORES DE PARTIDA
            For Each xSalCon As SuperEntidad In xLisSalBan
                xSalCon.AnoCuentaBanco = iAnoNuevo
                xSalCon.ClaveSaldosBancarios = xSalCon.ClaveCuentaBanco + xSalCon.AnoCuentaBanco + xSalCon.MesCuentaBanco
                xSalCon.IngresosSolCuentaBanco = 0
                xSalCon.IngresosDolCuentaBanco = 0
                xSalCon.IngresosEurCuentaBanco = 0
                xSalCon.IngresosSolAntCuentaBanco = 0
                xSalCon.IngresosDolAntCuentaBanco = 0
                xSalCon.IngresosEurAntCuentaBanco = 0
                xSalCon.SalidasSolCuentaBanco = 0
                xSalCon.SalidasDolCuentaBanco = 0
                xSalCon.SalidasEurCuentaBanco = 0
                xSalCon.SalidasSolAntCuentaBanco = 0
                xSalCon.SalidasDolAntCuentaBanco = 0
                xSalCon.SalidasEurAntCuentaBanco = 0
                xSalCon.SaldoMesSolCuentaBanco = 0
                xSalCon.SaldoMesDolCuentaBanco = 0
                xSalCon.SaldoMesEurCuentaBanco = 0
                xSalCon.SaldoMesSolAntCuentaBanco = 0
                xSalCon.SaldoMesDolAntCuentaBanco = 0
                xSalCon.SaldoMesEurAntCuentaBanco = 0
                If xSalCon.MesCuentaBanco = "01" Then
                    If iSalDicSoles < 0 Then
                        xSalCon.SalidasSolAntCuentaBanco = Math.Abs(iSalDicSoles)
                        xSalCon.IngresosDolAntCuentaBanco = Math.Abs(iSalDicDolares)
                    Else
                        xSalCon.SalidasSolAntCuentaBanco = iSalDicSoles
                        xSalCon.IngresosDolAntCuentaBanco = iSalDicDolares
                    End If
                    xSalCon.SaldoMesSolAntCuentaBanco = iSalDicSoles
                    xSalCon.SaldoMesSolCuentaBanco = iSalDicSoles
                    xSalCon.SaldoMesDolAntCuentaBanco = iSalDicDolares
                    xSalCon.SaldoMesDolCuentaBanco = iSalDicDolares
                Else
                    xSalCon.SaldoMesSolCuentaBanco = iSalDicSoles
                    xSalCon.SaldoMesDolCuentaBanco = iSalDicDolares
                End If
            Next

            'MODIFICAR ESTE NUEVO SALDO AL SALDO DE PARTIDA DE LA CUENTA BANCARIA
            Dim iCB As New SuperEntidad
            iCB.CodigoCuentaBanco = xLisSalBan(0).CodigoCuentaBanco
            iCB = iCueBanRN.buscarCuentaBancoExisPorCodigo(iCB, iLisCB)

            'SEGUN MONEDA
            If iCB.MonedaCuentaBanco = "S/." Then
                iCB.SaldoCuentaBanco = iSalDicSoles
            Else
                iCB.SaldoCuentaBanco = iSalDicDolares
            End If

            'ADICIONAMOS A LA LISTA DE CUENTAS BANCARIAS A MODIFICAR
            Me.iLisCueBan.Add(iCB)

            'ADICIONAMOS LOS SALDOS BANCARIOS A ADICIONAR
            Me.iLisSalBan.AddRange(xLisSalBan)
        Next
    End Sub

    Sub AdicionarSaldosBancarios()
        Dim iSalBanRN As New SaldosBancariosRN
        iSalBanRN.NuevoSaldosBancariosMasivo(Me.iLisSalBan)
    End Sub

    Sub EliminarSaldosBancarios()
        Dim iSalBanRN As New SaldosBancariosRN
        Dim iSalBanEN As New SuperEntidad
        iSalBanEN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iSalBanEN.AnoCuentaBanco = (CType(Me.txtAno.Text, Integer) + 1).ToString
        iSalBanRN.EliminarSaldosBancariosXEmpresaYAno(iSalBanEN)
    End Sub

    Sub ModificarCuentasBancarias()
        Dim iCueBanRN As New CuentaBancoRN
        iCueBanRN.modificarCuentaBancoMasivo(Me.iLisCueBan)
    End Sub

    Sub LimpiarParaNuevoProceso()
        'LIMPIAR LAS LISTAS 
        Me.iLisCueBan.Clear()
        Me.iLisSalBan.Clear()

        'ELIMINAR LOS SALDOS BANCARIOS
        Me.EliminarSaldosBancarios()
    End Sub

    Sub Aceptar()
        'VERIFICAR QUE EL USUARIO ESTE EN EL MES DE DICIEMBRE
        If Me.EsMesDeDiciembre = False Then Exit Sub

        'LIMPIAR LAS LISTAS 
        Me.LimpiarParaNuevoProceso()

        'OBTENER LAS LISTA DE GRABACIONES
        Me.ObtenerListasParaGrabacion()

        'CERRAR LAS CUENTAS BANCARIAS
        Me.AdicionarSaldosBancarios()
        Me.ModificarCuentasBancarias()

        'MENSAJE SATISFACTORIO
        MsgBox("Se cerraron las cuentas bancarias para el año " + Me.txtAno.Text, MsgBoxStyle.Information, "Bancos")
    End Sub

#End Region


    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.Aceptar()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class