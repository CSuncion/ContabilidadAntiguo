Imports Entidad
Imports Negocio

Public Class WParametros

      Public ent As New SuperEntidad
      Public Par As New ParametroRN
      Public cam As New CamposEntidad
      Public acc As New Accion
      Public tab As New TablaRN

      Sub InicializaVentana()
            '/Para los eventos de controles
        acc.listaCtrls = Me.ListaControles
        acc.PasaFoco()
        acc.FomatoDato()
        acc.PasarCursor()
        acc.Teclazo()
        acc.Valida()
            ''/Ejecucion en ventana
            Me.Show()
      End Sub

    Sub ventanaModificar()
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Parametros"
        'mostrar el registro en pantalla
        Me.obtenerParametrosEnPantalla()
        'los controles que deben estar activos
        Txt.cursorAlUltimo(Me.txtIgv)
        acc.Modificar()

        '\\
    End Sub

    Sub obtenerParametrosEnPantalla()
        '//

        ent = Par.buscarParametroExis(ent)

        'preguntar si ent tiene el registro
        '/Pasar Datos a los controles

        Me.txtIgv.Text = ent.IgvPar.ToString
        Me.TxtCtaTrans.Text = ent.CuentaTransferencia.ToString
        Me.TxtDigitos.Text = ent.DigitosCuentaAnalitica.ToString
        Me.TxtCtaHonNet.Text = ent.CuentaHonorarioNeto.ToString
        Me.TxtCtaHonRet.Text = ent.CuentaHonorarioRetencion.ToString
        Me.TxtCtaAuto.Text = ent.CuentaAutomatica.ToString
        Me.TxtCtaIgv.Text = ent.CuentaIgv.ToString
        Me.TxtCtaGanDC.Text = ent.CuentaGananciaDC.ToString
        Me.TxtCtaPerDC.Text = ent.CuentaPerdidaDC.ToString

        'Me.txtCodPer.Text = ent.CodigoPersonal
        Me.txtPorRenHon.Text = ent.PorRetencionHonorario.ToString
        Me.TxtPorDesAfp2014.Text = ent.PorcentajeDsctoAfp2014.ToString
        Me.TxtPorDesAfp2015.Text = ent.PorcentajeDsctoAfp2015.ToString
        Me.TxtPorDesAfp2016.Text = ent.PorcentajeDsctoAfp2016.ToString
        Me.TxtPorDesSnp2014.Text = ent.PorcentajeDsctoSnp2014.ToString
        Me.TxtPorDesSnp2015.Text = ent.PorcentajeDsctoSnp2015.ToString
        Me.TxtPorDesSnp2016.Text = ent.PorcentajeDsctoSnp2016.ToString
        Me.TxtCtaAfp.Text = ent.CuentaAfp.ToString
        Me.TxtCtaSnp.Text = ent.CuentaSnp.ToString
        Me.TxtCtaValVta.Text = ent.CuentaValorVenta.ToString
        Me.TxtCtaPreVta.Text = ent.CuentaPrecioVenta.ToString
        Me.TxtCtaCla8Cierre.Text = ent.CuentaClase8Cierre.ToString
        Me.TxtCtaGanCierre.Text = ent.CuentaGananciaCierre.ToString
        Me.TxtCtaPerCierre.Text = ent.CuentaPerdidaCierre.ToString
        Me.TxtPorImpRen.Text = ent.PorcentajeImpuestoRenta.ToString
        Me.TxtCta16PreVta.Text = ent.Cuenta16PrecioVentaEmpresa.ToString
        Me.TxtCta75ValVta.Text = ent.Cuenta75ValorVentaEmpresa.ToString
        Me.TxtCta40ValIgv.Text = ent.CuentaIgvEmpresa.ToString
        Me.TxtCodOriVta.Text = ent.CodigoOrigenVentas.ToString
        Me.TxtCodFilVta.Text = ent.CodigoFileVentas.ToString
        Me.TxtCodOriDia.Text = ent.CodigoOrigenDiario.ToString
        Me.TxtCodFilDia.Text = ent.CodigoFileDiario.ToString
        ''Nuevos Campos
        Me.TxtCodOriRegVtaFER.Text = ent.CCodigoOrigenRegistroVentas
        Me.TxtNomOriRegVtaFER.Text = "Ventas"
        Me.TxtCodFilRegVtaFER.Text = ent.CCodigoFileRegistroVentas
        Me.TxtNomFilRegVtaFER.Text = "Ventas Importadas FER"
        Me.TxtCodCtaMonTotFER.Text = ent.CuentaMontoTotalCuotas
        Me.TxtCodCtaCuoOrdFER.Text = ent.CuentaCuotaOrdinaria
        Me.TxtCodCtaSupProFER.Text = ent.CuentaCuotaSupervisionYProyectos
        Me.TxtCodCtaCuoAguFER.Text = ent.CuentaCuotaAgua
        Me.TxtCodCtaCuoEleFER.Text = ent.CuentaCuotaElectricidad
        Me.TxtCodCtaCuoIngFER.Text = ent.CuentaCuotaIngreso
        Me.TxtCodCtaCuoExtFER.Text = ent.CuentaCuotaExtraordinaria
        Me.TxtCodCtaCuoMorFER.Text = ent.CuentaCuotaMoras
        '\\
    End Sub

    Sub Aceptar()
        '//

        'Volver a traer el registro 
        ent = Par.buscarParametroExis(ent)

        'Dim perAnt As String = ent.Periodo
        'Dim perAct As String = SuperEntidad.xPeriodoEmpresa
        'If perAct <> perAnt Then
        '    Me.InicializaVoucherFiles()
        'End If

        'Pasamos los datos que vamos a cargar
        '  ent.CodigoPersonal = Me.txtCodPer.Text.Trim

        ent.IgvPar = CType(Me.txtIgv.Text.Trim, Decimal)
        ent.CuentaTransferencia = Me.TxtCtaTrans.Text.Trim
        ent.DigitosCuentaAnalitica = Me.TxtDigitos.Text.Trim
        ent.CuentaHonorarioNeto = Me.TxtCtaHonNet.Text.Trim
        ent.CuentaHonorarioRetencion = Me.TxtCtaHonRet.Text.Trim
        ent.CuentaAutomatica = Me.TxtCtaAuto.Text.Trim
        ent.CuentaIgv = Me.TxtCtaIgv.Text.Trim
        ent.CuentaGananciaDC = Me.TxtCtaGanDC.Text.Trim
        ent.CuentaPerdidaDC = Me.TxtCtaPerDC.Text.Trim
        'ent.CodigoPersonal = Me.txtCodPer.Text.Trim
        ent.PorRetencionHonorario = CType(Me.txtPorRenHon.Text.Trim, Decimal)
        ent.PorcentajeDsctoAfp2014 = CType(Me.TxtPorDesAfp2014.Text.Trim, Decimal)
        ent.PorcentajeDsctoAfp2015 = CType(Me.TxtPorDesAfp2015.Text.Trim, Decimal)
        ent.PorcentajeDsctoAfp2016 = CType(Me.TxtPorDesAfp2016.Text.Trim, Decimal)
        ent.PorcentajeDsctoSnp2014 = CType(Me.TxtPorDesSnp2014.Text.Trim, Decimal)
        ent.PorcentajeDsctoSnp2015 = CType(Me.TxtPorDesSnp2015.Text.Trim, Decimal)
        ent.PorcentajeDsctoSnp2016 = CType(Me.TxtPorDesSnp2016.Text.Trim, Decimal)
        ent.CuentaAfp = Me.TxtCtaAfp.Text.Trim
        ent.CuentaSnp = Me.TxtCtaSnp.Text.Trim
        ent.CuentaValorVenta = Me.TxtCtaValVta.Text.Trim
        ent.CuentaPrecioVenta = Me.TxtCtaPreVta.Text.Trim
        ent.CuentaClase8Cierre = Me.TxtCtaCla8Cierre.Text.Trim
        ent.CuentaGananciaCierre = Me.TxtCtaGanCierre.Text.Trim
        ent.CuentaPerdidaCierre = Me.TxtCtaPerCierre.Text.Trim
        ent.PorcentajeImpuestoRenta = CType(Me.TxtPorImpRen.Text.Trim, Decimal)
        ent.CodigoOrigenVentas = Me.TxtCodOriVta.Text.Trim
        'ent = Me.TxtCodOriVta.Text.Trim
        ent.CodigoFileVentas = Me.TxtCodFilVta.Text.Trim
        ent.Cuenta16PrecioVentaEmpresa = Me.TxtCta16PreVta.Text.Trim
        ent.Cuenta75ValorVentaEmpresa = Me.TxtCta75ValVta.Text.Trim
        ent.CuentaIgvEmpresa = Me.TxtCta40ValIgv.Text.Trim
        ent.CodigoOrigenDiario = Me.TxtCodOriDia.Text.Trim
        ent.CodigoFileDiario = Me.TxtCodFilDia.Text.Trim
        ent.CCodigoOrigenRegistroVentas = Me.TxtCodOriRegVtaFER.Text.Trim
        ent.CCodigoFileRegistroVentas = Me.TxtCodFilRegVtaFER.Text.Trim
        ent.CuentaMontoTotalCuotas = Me.TxtCodCtaMonTotFER.Text.Trim
        ent.CuentaCuotaOrdinaria = Me.TxtCodCtaCuoOrdFER.Text.Trim
        ent.CuentaCuotaSupervisionYProyectos = Me.TxtCodCtaSupProFER.Text.Trim
        ent.CuentaCuotaAgua = Me.TxtCodCtaCuoAguFER.Text.Trim
        ent.CuentaCuotaElectricidad = Me.TxtCodCtaCuoEleFER.Text.Trim
        ent.CuentaCuotaIngreso = Me.TxtCodCtaCuoIngFER.Text.Trim
        ent.CuentaCuotaExtraordinaria = Me.TxtCodCtaCuoExtFER.Text.Trim
        ent.CuentaCuotaMoras = Me.TxtCodCtaCuoMorFER.Text.Trim
        'ent.PorGastosAdministrativos = CType(Me.txtGasAdm.Text.Trim, Decimal)
        'ent.PorUtilidad = CType(Me.txtUtil.Text.Trim, Decimal)
        Par.modificarParametro(ent)
        MsgBox("Parametro modificado correctamente", MsgBoxStyle.Information)
        Me.Close()
        'Me.obtenerParametrosEnPantalla()

        '\\
    End Sub

      Sub InicializaVoucherFiles()
            '/
            'Si se cambio el periodo en la pantalla entonces inicializamos los file desde 0
        'If Me.txtPeri.Text.Trim <> ent.Periodo Then
        '      Dim obj As New SuperEntidad
        '      Dim listFil As New List(Of SuperEntidad)
        '      obj.DatoCondicion1 = "Fil"
        '      obj.CampoOrden = cam.CodItemTabla
        '      listFil = tab.obtenerItemsTablaExisPorTipoTabla(obj)
        '      For Each ob As SuperEntidad In listFil
        '            ob.Voucher = "000000"
        '            tab.modificarItemTabla(ob)
        '      Next

        'End If
            '/
      End Sub

      Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If acc.CamposObligatorios = False Then
            Exit Sub
        Else
            Me.Aceptar()
        End If
        'Me.Aceptar()
    End Sub


      Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
            Dim rpta As Integer = MsgBox("Deseas cancelar la operacion", MsgBoxStyle.YesNo)
            If rpta = MsgBoxResult.Yes Then
                  Me.Close()
            Else
                  Exit Sub
            End If

      End Sub

    Private Sub txtPeri_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim perAnt As String = SuperEntidad.xPeriodoEmpresa
        Dim perAct As String = SuperEntidad.xPeriodoEmpresa
        If perAct < perAnt Then
            MsgBox("No puedes retorceder el periodo")
            'Me.txtPeri.Text = perAnt
            'Me.txtPeri.Focus()
        End If
    End Sub

    Private Sub TxtPorDesSnp2016_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPorDesSnp2016.TextChanged

    End Sub

    Private Sub TxtCodCtaMonTotFER_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodCtaMonTotFER.KeyDown
        If Me.TxtCodCtaMonTotFER.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarPlanCuentaGe
                win.tabla = "CuentasAnaliticas"    ''va la condicion del case
                win.titulo = "Cuentas"
                win.txt1 = Me.TxtCodCtaMonTotFER
                win.txt2 = Me.TxtNomCtaMonTotFER
                win.ctrlFoco = Me.TxtCodCtaCuoOrdFER
                win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub TxtCodCtaMonTotFER_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodCtaMonTotFER.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.TxtCodCtaMonTotFER : ope.txt2 = Me.TxtNomCtaMonTotFER
        ope.Condicion = "CuentasAnaliticas"
        ope.MostrarCodigoDescripcionDePlancuentas("CuentasAnaliticas", e)
    End Sub

    Private Sub TxtCodFilRegVtaFER_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodFilRegVtaFER.KeyDown
        If Me.TxtCodFilRegVtaFER.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListaFiles
                win.titulo = "Files"
                win.CondicionLista = "ListarFilesXOrigen"
                win.ent.CodigoFile = Me.TxtCodOriRegVtaFER.Text
                'win.ent.DatoFiltro1 = Me.txtCodOri.Text   '' Campo que viene del pasoa anterior
                win.txt1 = Me.TxtCodFilRegVtaFER
                win.txt2 = Me.TxtNomFilRegVtaFER
                win.ctrlFoco = Me.TxtCodCtaMonTotFER
                win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub TxtCodCtaCuoOrdFER_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodCtaCuoOrdFER.KeyDown
        If Me.TxtCodCtaCuoOrdFER.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarPlanCuentaGe
                win.tabla = "CuentasAnaliticas"    ''va la condicion del case
                win.titulo = "Cuentas"
                win.txt1 = Me.TxtCodCtaCuoOrdFER
                win.txt2 = Me.TxtNomCtaCuoOrdFER
                win.ctrlFoco = Me.TxtCodCtaSupProFER
                win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub TxtCodCtaCuoOrdFER_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodCtaCuoOrdFER.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.TxtCodCtaCuoOrdFER : ope.txt2 = Me.TxtNomCtaCuoOrdFER
        ope.Condicion = "CuentasAnaliticas"
        ope.MostrarCodigoDescripcionDePlancuentas("CuentasAnaliticas", e)
    End Sub

    Private Sub TxtCodCtaSupProFER_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodCtaSupProFER.KeyDown
        If Me.TxtCodCtaSupProFER.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarPlanCuentaGe
                win.tabla = "CuentasAnaliticas"    ''va la condicion del case
                win.titulo = "Cuentas"
                win.txt1 = Me.TxtCodCtaSupProFER
                win.txt2 = Me.TxtNomCtaSupProFER
                win.ctrlFoco = Me.TxtCodCtaCuoAguFER
                win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub TxtCodCtaSupProFER_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodCtaSupProFER.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.TxtCodCtaSupProFER : ope.txt2 = Me.TxtNomCtaSupProFER
        ope.Condicion = "CuentasAnaliticas"
        ope.MostrarCodigoDescripcionDePlancuentas("CuentasAnaliticas", e)
    End Sub

    Private Sub TxtCodCtaCuoAguFER_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodCtaCuoAguFER.KeyDown
        If Me.TxtCodCtaCuoAguFER.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarPlanCuentaGe
                win.tabla = "CuentasAnaliticas"    ''va la condicion del case
                win.titulo = "Cuentas"
                win.txt1 = Me.TxtCodCtaCuoAguFER
                win.txt2 = Me.TxtNomCtaCuoAguFER
                win.ctrlFoco = Me.TxtCodCtaCuoEleFER
                win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub TxtCodCtaCuoAguFER_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodCtaCuoAguFER.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.TxtCodCtaCuoAguFER : ope.txt2 = Me.TxtNomCtaCuoAguFER
        ope.Condicion = "CuentasAnaliticas"
        ope.MostrarCodigoDescripcionDePlancuentas("CuentasAnaliticas", e)
    End Sub

    Private Sub TxtCodCtaCuoEleFER_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodCtaCuoEleFER.KeyDown
        If Me.TxtCodCtaCuoEleFER.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarPlanCuentaGe
                win.tabla = "CuentasAnaliticas"    ''va la condicion del case
                win.titulo = "Cuentas"
                win.txt1 = Me.TxtCodCtaCuoEleFER
                win.txt2 = Me.TxtNomCtaCuoEleFER
                win.ctrlFoco = Me.TxtCodCtaCuoIngFER
                win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub TxtCodCtaCuoEleFER_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodCtaCuoEleFER.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.TxtCodCtaCuoEleFER : ope.txt2 = Me.TxtNomCtaCuoEleFER
        ope.Condicion = "CuentasAnaliticas"
        ope.MostrarCodigoDescripcionDePlancuentas("CuentasAnaliticas", e)
    End Sub

    Private Sub TxtCodCtaCuoIngFER_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodCtaCuoIngFER.KeyDown
        If Me.TxtCodCtaCuoIngFER.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarPlanCuentaGe
                win.tabla = "CuentasAnaliticas"    ''va la condicion del case
                win.titulo = "Cuentas"
                win.txt1 = Me.TxtCodCtaCuoIngFER
                win.txt2 = Me.TxtNomCtaCuoIngFER
                win.ctrlFoco = Me.TxtCodCtaCuoExtFER
                win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub TxtCodCtaCuoIngFER_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodCtaCuoIngFER.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.TxtCodCtaCuoIngFER : ope.txt2 = Me.TxtNomCtaCuoIngFER
        ope.Condicion = "CuentasAnaliticas"
        ope.MostrarCodigoDescripcionDePlancuentas("CuentasAnaliticas", e)

    End Sub

    Private Sub TxtCodCtaCuoExtFER_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodCtaCuoExtFER.KeyDown
        If Me.TxtCodCtaCuoExtFER.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarPlanCuentaGe
                win.tabla = "CuentasAnaliticas"    ''va la condicion del case
                win.titulo = "Cuentas"
                win.txt1 = Me.TxtCodCtaCuoExtFER
                win.txt2 = Me.TxtNomCtaCuoExtFER
                win.ctrlFoco = Me.TxtCodCtaCuoMorFER
                win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub TxtCodCtaCuoExtFER_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodCtaCuoExtFER.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.TxtCodCtaCuoExtFER : ope.txt2 = Me.TxtNomCtaCuoExtFER
        ope.Condicion = "CuentasAnaliticas"
        ope.MostrarCodigoDescripcionDePlancuentas("CuentasAnaliticas", e)
    End Sub

    Private Sub TxtCodCtaCuoMorFER_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodCtaCuoMorFER.KeyDown
        If Me.TxtCodCtaCuoMorFER.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarPlanCuentaGe
                win.tabla = "CuentasAnaliticas"    ''va la condicion del case
                win.titulo = "Cuentas"
                win.txt1 = Me.TxtCodCtaCuoMorFER
                win.txt2 = Me.TxtNomCtaCuoMorFER
                win.ctrlFoco = Me.btnAceptar
                win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub TxtCodCtaCuoMorFER_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodCtaCuoMorFER.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.TxtCodCtaCuoMorFER : ope.txt2 = Me.TxtNomCtaCuoMorFER
        ope.Condicion = "CuentasAnaliticas"
        ope.MostrarCodigoDescripcionDePlancuentas("CuentasAnaliticas", e)
    End Sub
End Class