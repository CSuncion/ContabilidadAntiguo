Option Strict Off
Imports Entidad
Imports Negocio

Public Class WMenu

    Public per As New PermisoRN

#Region "Metodos y Funciones"

    Sub nuevaVentana()
        'la ventana aparece en pantalla
        Me.Show()
        Dim win As New WAcceso
        win.nuevaVentana()
    End Sub


    Sub Permisos()
        'CARGAMOS LA LISTA DE LOS PERMISOS DE VENTANA PARA ESTE USUARIO
        Dim listaVP As New List(Of SuperEntidad)
        Dim oPer As New SuperEntidad
        oPer.CodigoUsuario = SuperEntidad.xCodigoUsuario
        listaVP = per.obtenerPermisosExisDeVentanasXUsuario(oPer)
        'RECORRER CADA PERMISO
        For Each p As SuperEntidad In listaVP
            ' 0 : NO TIENE PERMISO EN ESTA VENTANA
            Dim vf As Boolean = IIf(p.OpcionPermiso = 0, False, True)
            'PASAR vf A LOS ITEMS DEL MENU
            Select Case p.CodigoVentana
                Case "001" : Me.iTeUsuarios.Enabled = vf
                Case "002" : Me.iteFiles.Enabled = vf
                Case "003" : Me.iteDocumentos.Enabled = vf
                Case "004" : Me.IteCentroCostos.Enabled = vf
                Case "005" : Me.iteCuentas12y42.Enabled = vf
                Case "006" : Me.IteIngresoEgresos.Enabled = vf
                Case "007" : Me.iteModoDePago.Enabled = vf
                Case "008" : Me.itePcge.Enabled = vf
                Case "009" : Me.itePlanDeCuentas.Enabled = vf : Me.tsbPlanCuentas.Enabled = vf
                Case "010" : Me.iteCuentasBancarias.Enabled = vf : Me.tsbCuentasBancarias.Enabled = vf
                Case "011" : Me.iteEmpresas.Enabled = vf : Me.tsbEmpresas.Enabled = vf
                Case "012" : Me.iteAuxiliares.Enabled = vf
                Case "013" : Me.iteTipoDeCambio.Enabled = vf
                Case "014" : Me.iteCorrelativoVoucher.Enabled = vf
                Case "015" : Me.iteFormatoContable.Enabled = vf
                Case "016" : Me.itePagosDocumentosProvisionados.Enabled = vf
                Case "017" : Me.iteCobroDcumnetoProvisionado.Enabled = vf
                Case "018" : Me.iteSinProvision.Enabled = vf
                Case "019" : Me.iteExtornarCajaybancos.Enabled = vf
                Case "020" : Me.iteTransferencia.Enabled = vf
                Case "021" : Me.iteRegistroDiarios.Enabled = vf
                Case "022" : Me.iteRegistroCompras.Enabled = vf : Me.tsbRegistroCompras.Enabled = vf
                Case "023" : Me.iteRegVtasNormal.Enabled = vf : Me.tsbRegistroVentas.Enabled = vf
                Case "024" : Me.iteRegVtasEspecial.Enabled = vf
                Case "025" : Me.iteRegistroHonorarios.Enabled = vf : Me.TbsHonorario.Enabled = vf
                Case "026" : Me.iteConsultaVoucher.Enabled = vf
                Case "027" : Me.iteMayorizacion.Enabled = vf : Me.TbsContabilizar.Enabled = vf
                Case "028" : Me.iteCierreMensual.Enabled = vf
                Case "029" : Me.iteEFSituacionXFuncion.Enabled = vf
                Case "030" : Me.iteEFComprobacion.Enabled = vf
                Case "031" : Me.iteGananciasYPerdidasXFuncion.Enabled = vf
                Case "032" : Me.iteGananciasYPerdidasXNaturaleza.Enabled = vf
                Case "033" : Me.iteBalanceGeneral.Enabled = vf
                Case "034" : Me.iteAnexosAlBalance.Enabled = vf
                Case "035" : Me.iteMovDigitosDelMes.Enabled = vf
                Case "036" : Me.iteMovDigitosAcumulado.Enabled = vf
                Case "037" : Me.iteListadoCompras.Enabled = vf
                Case "038" : Me.iteListadoVentas.Enabled = vf
                Case "039" : Me.iteLibroDiario.Enabled = vf
                Case "040" : Me.iteLibroMayor.Enabled = vf
                Case "041" : Me.iteInventariosYBalances.Enabled = vf
                Case "042" : Me.iteLibroDiarioSimplificado.Enabled = vf
                Case "043" : Me.iteSaldoCuentas.Enabled = vf
                Case "044" : Me.iteAnalisisCuentas.Enabled = vf
                Case "045" : Me.iteAuxTodosLosMovimientos.Enabled = vf
                Case "046" : Me.iteAuxSoloSaldo.Enabled = vf
                Case "047" : Me.iteAuxRelacionResumen.Enabled = vf
                Case "048" : Me.iteCuentaCorriente.Enabled = vf
                Case "049" 'Me.ite.Enabled = vf
                Case "050" : Me.iteParametros.Enabled = vf
                Case "051" : Me.iteCierreMensualCuentasBancarias.Enabled = vf : Me.tsbCierreBcos.Enabled = vf
                Case "052" : Me.iteVerificaVouchers.Enabled = vf
                Case "053" : Me.tsbEstadoBancos.Enabled = vf
                Case "054" : Me.ItePeriodos.Enabled = vf
                Case "055" : Me.IteAreas.Enabled = vf
                Case "056" : Me.IteFlujoCaja.Enabled = vf
            End Select
        Next

    End Sub


    Sub CambiarEmpresa()
        ''Preguntamos si deseamos cambiar secion
        Dim Rpt As Integer = MsgBox("Desear Cambiar de Empresa", MsgBoxStyle.YesNo, "Sistema")
        ''Si le das no sale del procedimiento
        If Rpt = MsgBoxResult.No Then Exit Sub
        ''Si responde Si 
        ''Pasamos los formularios activos a frs
        Dim frs As New List(Of Form)
        For Each w As Form In My.Application.OpenForms
            ''A excepcion del wmenu
            If w.Name <> "WMenu" Then frs.Add(w)
        Next
        ''Vamos Cerrando todos los formularios activos
        For n As Integer = 0 To frs.Count - 1
            frs.Item(n).Close()

        Next
        ''Instaciamos el formulario de acceso
        Dim win As New WAcceso
        win.nuevaVentana()

    End Sub

    Sub salirDelSistema()
        '//
        Dim rpt As Integer = MsgBox("Deseas Salir del sistema", MsgBoxStyle.YesNo)
        If rpt = MsgBoxResult.Yes Then
            End
        Else
            Exit Sub
        End If
        '\\
    End Sub

#End Region

    Private Sub WMenu_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Me.Permisos()
    End Sub


    Private Sub WMenu_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim rpt As Integer = MsgBox("Deseas Salir del sistema", MsgBoxStyle.YesNo)
        If rpt = MsgBoxResult.Yes Then
            End
        Else
            e.Cancel = True
            Exit Sub
        End If
        'Me.salirDelSistema()
    End Sub


    Private Sub Usuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iTeUsuarios.Click
        Dim win As New WUsuario
        win.NuevaVentana()
    End Sub

    Private Sub tsbPlanCtas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPlanCuentas.Click
        Dim win As New WPlanCuentaGe
        win.NuevaVentana(SuperEntidad.xCodigoEmpresa)
    End Sub

    Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
        'Dim win As New Form1
        'win.Show()
        Me.salirDelSistema()
    End Sub

    Private Sub CambioDeClave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambioDeClave.Click
        Dim win As New WCambiarClave
        win.nuevaVentana()
    End Sub

    Private Sub Personal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itePcge.Click
        Dim win As New WPcge
        win.NuevaVentana()
    End Sub


    Private Sub Auxiliares_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteAuxiliares.Click
        Dim win As New WAuxiliar
        win.NuevaVentana()
    End Sub


    Private Sub FilesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteFiles.Click
        Dim win As New WTabla
        win.tipoTabla = "Fil"
        win.Text = "Files"
        win.arg = "File"
        win.NuevaVentana()
    End Sub


    Private Sub Cuentas12y42ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteCuentas12y42.Click
        Dim win As New WTabla
        win.tipoTabla = "Cue"
        win.Text = "Cuentas 12 y 42"
        win.arg = "Cuenta 12 y 42"
        win.NuevaVentana()
    End Sub


    Private Sub CerrarSesionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarSesionToolStripMenuItem.Click
        Me.salirDelSistema()
    End Sub

    Private Sub DiasPorMesesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteTipoDeCambio.Click
        Dim win As New WTipoCambio
        win.NuevaVentana()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEstadoBancos.Click
        Dim win As New WImpEstadoBancos
        win.InicializaVentana()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRegistroCompras.Click
        Dim win As New WRegistroCompra
        win.NuevaVentana()
    End Sub

    Private Sub ImportarPersonalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim win As New WimportarAuxiliar
        win.Show()
    End Sub

    Private Sub ProyectosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteRegistroDiarios.Click
        Dim win As New WRegistroDiario
        win.NuevaVentana()
    End Sub

    Private Sub MovimientoHorasPersonalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteListadoCompras.Click
        'Dim win As New WImpRegistroCompras
        'win.InicializaVentana()
    End Sub

    Private Sub ImportarProyectosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarProyectosToolStripMenuItem.Click
        Dim win As New WImportarCuentas
        win.Show()
    End Sub

    Private Sub ParametrosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteParametros.Click
        Dim win As New WParametros
        win.ventanaModificar()
    End Sub

    Private Sub RegistroComprasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteRegistroCompras.Click
        Dim win As New WRegistroCompra
        win.NuevaVentana()
    End Sub

    Private Sub TipoDeCambioToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim win As New WTipoCambio
        win.NuevaVentana()
    End Sub


    Private Sub RegistroGastosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteRegistroHonorarios.Click
        Dim win As New WRegistroHonorario
        win.NuevaVentana()
    End Sub

    Private Sub ReporteHorasOriginalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteListadoVentas.Click
        'Dim win As New WImpResgistroVenta
        'win.InicializaVentana()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEmpresas.Click
        Dim win As New WEmpresa
        win.NuevaVentana()
    End Sub

    Private Sub ExportarRegistrosVentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteImportarRegistrosVentas.Click
        Dim win As New WImportarRegistroVentasNuevo
        win.NuevaVentana()
    End Sub

    'Private Sub ExportarRegistrosGatosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteExportarRegistroCompras.Click
    '    'Dim win As New WExportarRegistroGastos
    '    Dim win As New WExportarRegistroCompras
    '    win.NuevaVentana()
    'End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Dim win As New WBloquear
        win.nuevaVentana()
    End Sub


    Private Sub CopiaDeBaseDeDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      
    End Sub

    Private Sub CodigosInexistentesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteLibroDiario.Click
        Dim win As New WImpLibroDiario
        win.InicializaVentana()
    End Sub

    Private Sub PlanillaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteConsultaVoucher.Click
        Dim win As New WVouchersTodos
        win.NuevaVentana()
    End Sub

    Private Sub ProcesarIngresosYEgresosRealesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      
    End Sub

    Private Sub UtilidadHistoricoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteLibroMayor.Click
        Dim win As New WImpLibroMayor
        win.InicializaVentana()
    End Sub


    Private Sub ComprasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim win As New WRegistroCompra
        win.NuevaVentana()
    End Sub

    Private Sub HonorariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim win As New WRegistroHonorario
        win.NuevaVentana()
    End Sub

    Private Sub ComprasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComprasToolStripMenuItem1.Click
        Dim win As New WImportarRegistroCompras
        win.NuevaVentana()
    End Sub

    Private Sub HonorariosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HonorariosToolStripMenuItem1.Click
        Dim win As New WExportarRegistroHonorarios
        win.NuevaVentana()
    End Sub


    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteCentroCosto.Click
        Dim win As New WTabla
        win.tipoTabla = "Cto"
        win.Text = "Centro de Costo"
        win.arg = "CentroCosto"
        win.NuevaVentana()
    End Sub

    Private Sub ToolStripButton2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRegistroVentas.Click
        Dim win As New WRegistroVenta
        win.NuevaVentana()
    End Sub

    Private Sub TbsHonorario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbsHonorario.Click
        Dim win As New WRegistroHonorario
        win.NuevaVentana()
    End Sub

    Private Sub ToolStripButton3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCorrVouchers.Click
        Dim win As New WVoucher
        win.NuevaVentana()
    End Sub

    Private Sub NumeroVoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteCorrelativoVoucher.Click
        Dim win As New WVoucher
        win.NuevaVentana()
    End Sub

    Private Sub MayorizacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteMayorizacion.Click
        Dim win As New WContabilizar
        win.InicializaVentana()
    End Sub

    Private Sub TransferenciaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteTransferencia.Click
        Dim win As New WTransferencia
        win.NuevaVentana()
    End Sub

    Private Sub OrigenesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteOrigenes.Click
        Dim win As New WTabla
        win.tipoTabla = "Ori"
        win.Text = "Origines"
        win.arg = "Origen"
        win.NuevaVentana()
    End Sub

    Private Sub DocumentosToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteDocumentos.Click
        Dim win As New WTabla
        win.tipoTabla = "Doc"
        win.Text = "Documentos"
        win.arg = "Documento"
        win.NuevaVentana()

    End Sub

    Private Sub IngresosEgresosToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteIngresosEgresos.Click
        Dim win As New WTabla
        win.tipoTabla = "Ies"
        win.Text = "Ingresos y Egresos"
        win.arg = "Ingreso/Egreso"
        win.NuevaVentana()
    End Sub

    Private Sub ModoDePagoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteModoDePago.Click
        Dim win As New WTabla
        win.tipoTabla = "Mod"
        win.Text = "Modo de Pago"
        win.arg = "ModoPago"
        win.NuevaVentana()

    End Sub

    Private Sub FormatoContableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteFormatoContable.Click
        Dim win As New WFormatoContable
        win.NuevaVentana()
    End Sub

    Private Sub TbsContabilizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbsContabilizar.Click
        Dim win As New WContabilizar
        win.InicializaVentana()
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteSaldoCuentas.Click
        Dim win As New WVisualizarSaldos
        win.NuevaVentana()
    End Sub

    Private Sub DelMesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteEFSituacionXFuncion.Click
        Dim win As New WImpSituacionXFuncion
        win.InicializaVentana()
    End Sub

    Private Sub DelMesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteMovDigitosDelMes.Click
        Dim win As New WImpSaldosADigitos
        win.InicializaVentana()
    End Sub

    Private Sub AcumuladoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteMovDigitosAcumulado.Click
        Dim win As New WImpSaldosADigitosAcumulados
        win.InicializaVentana()
    End Sub

    'Private Sub BalanceGeneralToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BalanceGeneralToolStripMenuItem.Click
    '    Dim win As New wImpAnexos
    '    win.InicializaVentana()
    'End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteEmpresas.Click
        Dim win As New WEmpresa
        win.NuevaVentana()
    End Sub

    Private Sub CambiarEmpresaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambiarEmpresaToolStripMenuItem.Click
        Me.CambiarEmpresa()
    End Sub

    Private Sub BloquearSistemaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BloquearSistemaToolStripMenuItem.Click
        Dim win As New WBloquear
        win.nuevaVentana()
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim win As New WCuentaBanco
        win.NuevaVentana()
    End Sub

    Private Sub ToolStripMenuItem5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        Dim win As New WImportarTablas
        win.Show()
    End Sub

    Private Sub ToolStripMenuItem6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteAnalisisCuentas.Click
        Dim win As New WImpAnalisisCuentas
        win.InicializaVentana()
    End Sub

    Private Sub TodosLosMoviminetosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteAuxTodosLosMovimientos.Click
        Dim win As New WImpAnalisisAuxiliaresTodos
        win.InicializaVentana()
    End Sub

    Private Sub SoloSaldoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteAuxSoloSaldo.Click
        Dim win As New WImpAnalisisAuxiliaresSaldo
        win.InicializaVentana()
    End Sub

    Private Sub RelacionResumenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteAuxRelacionResumen.Click
        Dim win As New WImpAnalisisAuxiliaresResumen
        win.InicializaVentana()
    End Sub

    Private Sub CierreMensualCuentasBancariasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteCierreMensualCuentasBancarias.Click
        Dim win As New WCierreBanco
        win.InicializaVentana()
    End Sub

    Private Sub ToolStripButton1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCierreBcos.Click
        Dim win As New WCierreBanco
        win.InicializaVentana()
    End Sub

    Private Sub LibroDiarioSimplificadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteLibroDiarioSimplificado.Click
        Dim win As New WImpLibroDiarioSimplificado
        win.InicializaVentana()
    End Sub

    Private Sub CuentaCorrienteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteCuentaCorriente.Click
        Dim win As New WCuentaCorriente
        win.NuevaVentana()
    End Sub

    Private Sub PagosDocumentosProvisionadosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itePagosDocumentosProvisionados.Click
        Dim win As New WDocumentosAPagar
        win.NuevaVentana()
    End Sub

    Private Sub ExtornarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteExtornarCajaybancos.Click
        Dim win As New WEstornarIngEgr
        win.NuevaVentana()
    End Sub

    Private Sub GananciasYPerdidasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteGananciasYPerdidasXFuncion.Click
        '        Dim win As New WImpGanaePerdXFun
        '       win.InicializaVentana()
    End Sub

    Private Sub SinProvisionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteSinProvision.Click
        Dim win As New WRegistroCajaBanco
        win.NuevaVentana()
    End Sub

    Private Sub NormalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteRegVtasNormal.Click
        Dim win As New WRegistroVenta
        win.NuevaVentana()
    End Sub

    Private Sub EspecialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteRegVtasEspecial.Click
        Dim win As New WRegistroVentaEspecial
        win.NuevaVentana()
    End Sub

    Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteCobroDcumnetoProvisionado.Click
        Dim win As New WDocumentosACobrar
        win.NuevaVentana()
    End Sub

    Private Sub AlmacenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlmacenToolStripMenuItem.Click
        Dim win As New WAlmacen
        win.NuevaVentana()
    End Sub

    Private Sub VoucherMayorizadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VoucherMayorizadoToolStripMenuItem.Click
        Dim win As New WConsultaVouchers
        win.NuevaVentana()
    End Sub

    Private Sub PorFuncionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PorFuncionToolStripMenuItem.Click
        Dim win As New WImpGanaePerdXFun
        win.InicializaVentana()
    End Sub

    Private Sub PorNaturalezToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteGananciasYPerdidasXNaturaleza.Click
        Dim win As New WImpGanaePerdXNat
        win.InicializaVentana()
    End Sub

    Private Sub BalanceGeneralToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BalanceGeneralToolStripMenuItem1.Click
        Dim win As New WImpBalanceGeneral
        win.InicializaVentana()
    End Sub

    Private Sub ToolStripButton1_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCuentasBancarias.Click
        Dim win As New WCuentaBanco
        win.NuevaVentana()
    End Sub

    Private Sub VerificaVouchersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteVerificaVouchers.Click
        Dim win As New WVerificaVoucher
        win.NuevaVentana()
    End Sub

    Private Sub AcumuladoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteEFComprobacion.Click
        Dim win As New WImpbalanceComprobacion
        win.InicializaVentana()
    End Sub


    Private Sub VentanaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentanaToolStripMenuItem.Click
        Dim win As New WVentana
        win.NuevaVentana()
    End Sub

    Private Sub OpcionesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpcionesToolStripMenuItem.Click
        Dim win As New WOpcion
        win.NuevaVentana()
    End Sub

    Private Sub CambiarPeriodoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CambiarPeriodoToolStripMenuItem.Click
        Dim win As New WCambiaPeriodoEmpresa
        win.NuevaVentana()
    End Sub

    Private Sub PlanDeCuentasDeEmpresaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itePlanDeCuentas.Click
        Dim win As New WPlanCuentaGe
        win.NuevaVentana(SuperEntidad.xCodigoEmpresa)
    End Sub

    Private Sub CuentasBancariasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteCuentasBancarias.Click
        Dim win As New WCuentaBanco
        win.NuevaVentana()
    End Sub

   
    Private Sub IteDetallado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteDetallado.Click
        Dim win As New wImpTesoreriaDetallado
        win.InicializaVentana()
    End Sub

    Private Sub TesoreriaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TesoreriaToolStripMenuItem.Click

    End Sub

    Private Sub IteResumenMes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteResumenMes.Click
        Dim win As New WIngresoEgresoBanco
        win.InicializaVentana()
    End Sub

    Private Sub TipoDocumentoIdentidadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TipoDocumentoIdentidadToolStripMenuItem.Click
        Dim win As New WTabla
        win.tipoTabla = "Tdi"
        win.Text = "Tipo Documento Identidad"
        win.arg = "TipoDocumentoIdentidad"
        win.NuevaVentana()
    End Sub

    Private Sub IteFilesx_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteFilesx.Click
        Dim win As New WFiles
        win.NuevaVentana()
    End Sub

    Private Sub ItePeriodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItePeriodos.Click
        Dim win As New WPeriodo
        win.NuevaVentana()
    End Sub

    
    Private Sub IteAreas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteAreas.Click
        Dim win As New WArea
        win.NuevaVentana()
    End Sub

    Private Sub IteFlujoCaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteFlujoCaja.Click
        Dim win As New WFlujoCaja
        win.NuevaVentana()
    End Sub

    Private Sub IteIngresoEgresos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteIngresoEgresos.Click
        Dim win As New WIngresoEgreso
        win.NuevaVentana()
    End Sub

    Private Sub IteCentroCostos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteCentroCostos.Click
        Dim win As New WCentroCosto
        win.NuevaVentana()
    End Sub

    Private Sub IteCentroCostosYCuentas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteCentroCostosYCuentas.Click
        Dim win As New WImpCentroCosto
        win.InicializaVentana()
    End Sub

    Private Sub IteCenCtoCtaDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteCenCtoCtaDetalle.Click
        Dim win As New WImpCentroCostoDetalle
        win.InicializaVentana()
    End Sub

    Private Sub IteCuentasYCentroCostos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteCuentasYCentroCostos.Click
        Dim win As New WImpCuentaCentroCosto
        win.InicializaVentana()
    End Sub

    Private Sub IteArchivo1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteArchivo1.Click
        Dim win As New WExportarRegistroHonorarios1
        win.NuevaVentana()
    End Sub


    Private Sub IteExportarHonorarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteExportarHonorarios.Click
        Dim win As New WExportarRegistroHonorarios
        win.NuevaVentana()
    End Sub

    Private Sub IteImportarDataMeses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteImportarDataMeses.Click
        Dim win As New WImportarDataMesesCabecera
        win.Show()
    End Sub

    Private Sub IteImportarDataMesesDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteImportarDataMesesDetalle.Click
        Dim win As New WImportarDataMesesDetalle
        win.Show()
    End Sub

    Private Sub IteSaldoBancarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteSaldoBancarios.Click
        Dim win As New WImpSaldosBancarios
        win.InicializaVentana()
    End Sub

    Private Sub iteAnexosAlBalance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteAnexosAlBalance.Click
        Dim win As New wImpAnexos
        win.InicializaVentana()
    End Sub

    Private Sub IteImportarFormatoContable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteImportarFormatoContable.Click
        Dim win As New WImportarFormatoContable
        win.Show()
    End Sub

    Private Sub IteImportarCuentaCorriente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteImportarCuentaCorriente.Click
        Dim win As New WImportarCuentaCorriente
        win.Show()
    End Sub

    Private Sub IteSumasIngresosEgresosProyectos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteSumasIngresosEgresosProyectos.Click
        Dim win As New WSumaIngEgr
        win.NuevaVentana()
    End Sub

    Private Sub IteDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteDetalle.Click
        Dim win As New WImpCeCoXIngresoDetalle
        win.InicializaVentana()
    End Sub

    Private Sub IreResumen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IreResumen.Click
        Dim win As New WImpCeCoXIngresoResumen
        win.InicializaVentana()
    End Sub

    Private Sub IteCentroCostoConMovimiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteCentroCostoConMovimiento.Click
        Dim win As New WImpCeCoConMovi
        win.InicializaVentana()
    End Sub

    Private Sub ReportesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportesToolStripMenuItem.Click

    End Sub

    Private Sub ACTUALIZARREGISTROSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACTUALIZARREGISTROSToolStripMenuItem.Click
        Dim win As New WActualizacionRegistros
        win.Show()
    End Sub

    Private Sub IteFlujoCajaResumen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteFlujoCajaResumen.Click
        Dim win As New WImpFlujoCajaResumen
        win.InicializaVentana()
    End Sub

    Private Sub IteFlujoCajaResumenXCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteFlujoCajaResumenXCuenta.Click
        Dim win As New WImpFlujoCajaResumenXCuenta
        win.InicializaVentana()
    End Sub

    Private Sub IteFlujoCajaDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteFlujoCajaDetalle.Click
        Dim win As New WImpFlujoCajaDetalle
        win.InicializaVentana()
    End Sub

    Private Sub IteCompras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteCompras.Click
        Dim win As New WExportarRegistroCompras
        win.NuevaVentana()
    End Sub

    'Private Sub IteGastosAnalisis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteGastosAnalisis.Click
    '    'Dim win As New WImpGastoAnalisis
    '    Dim win As New WImpGastoAnalisisNuevo
    '    win.InicializaVentana()
    'End Sub

   
    Private Sub IteVerificaDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteVerificaDetalle.Click
        Dim win As New WVerificaVoucherDetalle
        win.NuevaVentana()
    End Sub

    Private Sub IteGeneraMes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteGeneraMes.Click
        Dim win As New WDifCamGenerarMes
        win.InicializaVentana()
    End Sub

    Private Sub IteReporteMes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteReporteMes.Click
        Dim win As New WImpReporteMesDifCam
        win.InicializaVentana()
    End Sub

    Private Sub IteApruebaMes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteApruebaMes.Click
        Dim win As New WDifCamApruebarMes
        win.eVentana = 1
        win.InicializaVentana()
    End Sub


    Private Sub IteAnalisisXMes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim win As New WImpGastoXMes
        win.InicializaVentana()
    End Sub

    Private Sub IteGastosCuentasXMes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteGastosCuentasXMes.Click
        Dim win As New WImpGastoXMes
        win.InicializaVentana()
    End Sub

    Private Sub ActualizaAuxiliarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActualizaAuxiliarToolStripMenuItem.Click
        Dim win As New WimportarAuxiliar1
        win.Show()
    End Sub

    Private Sub IteMovimientos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteMovimientos.Click
        ' Dim win As New WImpMovimientoMes
        Dim win As New WImpMovimientoXMeses
        win.InicializaVentana()
    End Sub

    Private Sub IteVentas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteVentas.Click
        Dim win As New WExportarRegistroVentas
        win.NuevaVentana()
    End Sub

    Private Sub iteInventariosYBalances_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteInventariosYBalances.Click
        Dim win As New WimpIventariosYBalance
        win.InicializaVentana()
    End Sub

    Private Sub ToolStripButton1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Varios.EsConvertibleEnDecimal("(12)") = True Then
            MsgBox(Varios.numeroConDosDecimal("(A)"))
        End If
    End Sub

    Private Sub IteLibroCajayBanco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteLibroCajayBanco.Click
        Dim win As New WImpLibroCajaBanco
        win.InicializaVentana()
    End Sub

    Private Sub IteAfps_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteAfps.Click
        Dim win As New WAfp
        win.NuevaVentana()
    End Sub

    Private Sub GastosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GastosToolStripMenuItem.Click

    End Sub

    Private Sub IteDiario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteDiario.Click
        Dim win As New WExportarRegistroDiario
        win.NuevaVentana()
    End Sub

    Private Sub IteMayor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteMayor.Click
        Dim win As New WExportarRegistroMayor
        win.NuevaVentana()
    End Sub

    Private Sub Movimientos1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim win As New WImpMovimientoMes
        win.InicializaVentana()
    End Sub

    Private Sub IteGastosCuentasXMesExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteGastosCuentasXMesExportar.Click
        Dim win As New WImpGastoXMesExpor
        win.InicializaVentana()
    End Sub

    Private Sub DigitacionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DigitacionToolStripMenuItem.Click

    End Sub

    Private Sub IteCierreAnual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteCierreAnual.Click
        Dim win As New WCierreAnual
        win.NuevaVenta()
    End Sub

    Private Sub IteCierreAnualBancos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteCierreAnualBancos.Click
        Dim win As New WCierreAnualBanco
        win.InicializaVentana()
    End Sub

    Private Sub IteDaoCompras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteDaoCompras.Click
        Dim win As New WExportarDaoCompras
        win.NuevaVentana()
    End Sub

    Private Sub IteDaoVentas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteDaoVentas.Click
        Dim win As New WExportarDaoVentas
        win.NuevaVentana()
    End Sub

    Private Sub ToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click

    End Sub

    Private Sub IteInvBalDelMes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteInvBalDelMes.Click
        Dim win As New WimpIventariosYBalance
        win.InicializaVentana()
    End Sub

    Private Sub IteInvBalAcumulado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteInvBalAcumulado.Click
        Dim win As New WimpInvBalAcumulado
        win.InicializaVentana()
    End Sub

    Private Sub IteGastoReparable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteGastoReparable.Click
        Dim win As New WGastoReparable
        win.NuevaVentana()
    End Sub

    Private Sub IteResumenGastosReparables_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteResumenGastosReparables.Click
        Dim win As New WImpGastoReparableResumen
        win.InicializaVentana()
    End Sub

    Private Sub IteResumenXCuentaGtoRep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteResumenXCuentaGtoRep.Click
        Dim win As New WImpGastoReparableResumenXCuenta
        win.InicializaVentana()
    End Sub

    Private Sub DetalleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteDetalleGastoReparable.Click
        Dim win As New WImpGastoReparableDetalle
        win.InicializaVentana()
    End Sub

    Private Sub IteDesaprobarMes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteDesaprobarMes.Click
        Dim win As New WDifCamApruebarMes
        win.eVentana = 0
        win.InicializaVentana()
    End Sub

    Private Sub IteComprasNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteComprasNuevo.Click
        '  Dim win As New WExportarRegistroComprasNuevos
        ' win.NuevaVentana()
    End Sub

    Private Sub IteVentasNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteVentasNuevo.Click
        Dim win As New WExportarRegistroVentasNuevo
        win.NuevaVentana()
    End Sub

    Private Sub IteDiarioNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteDiarioNuevo.Click
        Dim win As New WExportarRegistroDiarioNuevo
        win.NuevaVentana()
    End Sub

    Private Sub IteMayorNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteMayorNuevo.Click
        Dim win As New WExportarRegistroMayorNuevo
        win.NuevaVentana()
    End Sub

    Private Sub PlanDeCuentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlanDeCuentasToolStripMenuItem.Click
        Dim win As New WExportarPlanCuentaNuevo
        win.NuevaVentana()
    End Sub

    Private Sub IteAsientosDeCierre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteAsientosDeCierre.Click
        Dim win As New WAsientosCierre
        win.NuevaVenta()
    End Sub

    Private Sub ToolStripMenuItem6_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click

    End Sub

    Private Sub ToolStripButton1_Click_4(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim win As New Form1
        win.Show()
    End Sub

    Private Sub WMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    'Private Sub IteVariosMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteImportarBoletasVtaNuevo.Click
    '    Dim win As New WActualizaCuentaCorriente
    '    win.InicializaVentana()
    'End Sub

    Private Sub itePaisNoDomiciliados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles itePaisNoDomiciliados.Click
        Dim win As New WTabla
        win.tipoTabla = "Pai"
        win.Text = "Pais No Domiciliados"
        win.arg = "PaisNoDomiciliados"
        win.NuevaVentana()
    End Sub

    Private Sub iteNacionales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteNacionales.Click
        Dim win As New WExportarRegistroComprasNuevos
        win.NuevaVentana()
    End Sub

    Private Sub iteNoDomiciliados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles iteNoDomiciliados.Click
        Dim win As New WExportarRegistroComprasNoDomiciliados
        win.NuevaVentana()
    End Sub
    
    Private Sub IteAnalisisAuxiliares_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteAnalisisAuxiliares.Click
        
    End Sub

    Private Sub IteRelacionResumen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteRelacionResumen.Click
        Dim win As New WImpAnalisisAuxiliaresResumenNew
        win.InicializaVentana()
    End Sub

    Private Sub IteImportarAuxiliares_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteImportarAuxiliares.Click
        Dim win As New WimportarAuxiliar
        win.Show()
    End Sub

    Private Sub ItePasaDocumentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItePasaDocumentos.Click
        Dim win As New WImportarDocumentos
        win.Show()
    End Sub

    Private Sub IteSoloCentroCosto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteSoloCentroCosto.Click
        Dim win As New WImportarCentroCosto
        win.Show()
    End Sub

    Private Sub IteSoloFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteSoloFiles.Click
        Dim win As New WImportarVoucher
        win.Show()
    End Sub

    Private Sub IteFilesSolo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteFilesSolo.Click
        Dim win As New WImportarFiles
        win.Show()
    End Sub

    Private Sub ItemAlmacen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemAlmacen.Click
        Dim win As New WImportarAlmacen
        win.Show()
    End Sub

    Private Sub IteLibroOficial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteLibroOficial.Click
        Dim win As New WImpRegistroCompras
        win.InicializaVentana()
    End Sub

    Private Sub IteParaAnalisis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteParaAnalisis.Click
        Dim win As New WImpRegistroComprasDol
        win.InicializaVentana()
    End Sub

    Private Sub GastosReparablesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GastosReparablesToolStripMenuItem.Click

    End Sub

    Private Sub IteVentasDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteVentasDetalle.Click
        Dim win As New WImportarVentasDetalle
        win.Show()
    End Sub

    Private Sub IteVentasCabecera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteVentasCabecera.Click
        Dim win As New WImportarVentasCabecera
        win.Show()
    End Sub

    Private Sub IteExportarRegistrosAlmacen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteExportarRegistrosAlmacen.Click
        'Dim win As New WExportarRegistrosAlmacen
        'win.NuevaVentana()
    End Sub

    Private Sub IteExportarRegistroCompras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteExportarRegistroCompras.Click
        Dim win As New WExportarRegistroCompras
        win.NuevaVentana()
    End Sub

    Private Sub IteComprasAlmacen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteMovimientoAlmacen.Click
        Dim win As New WExportarRegistroComprasAlmacen
        win.NuevaVentana()
    End Sub

    Private Sub IteMovimientoAlmacen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteComprasAlmacen.Click
        Dim win As New WExportarRegistrosAlmacen
        win.NuevaVentana()
    End Sub

    Private Sub IteAcumuladoRangoCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteAcumuladoRangoCuenta.Click
        Dim win As New WimpInvBalAcumuladoRanCue
        win.InicializaVentana()
    End Sub

    Private Sub IteComprasNacionales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteComprasNacionales.Click
        Dim win As New WExportarRegistroComprasNuevos
        win.NuevaVentana()
    End Sub

    Private Sub IteComprasNoDomiciliados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteComprasNoDomiciliados.Click
        Dim win As New WExportarRegistroComprasNoDomiciliados
        win.NuevaVentana()
    End Sub

    Private Sub IteVentasElectronico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteVentasElectronico.Click
        Dim win As New WExportarRegistroVentasNuevo
        win.NuevaVentana()
    End Sub

    Private Sub IteDiarioElectronico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteDiarioElectronico.Click
        Dim win As New WExportarRegistroDiarioNuevo
        win.NuevaVentana()
    End Sub

    Private Sub IteMayorElectronico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteMayorElectronico.Click
        Dim win As New WExportarRegistroMayorNuevo
        win.NuevaVentana()
    End Sub

    Private Sub ItePlanDeCuentasElectronico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItePlanDeCuentasElectronico.Click
        Dim win As New WExportarPlanCuentaNuevo
        win.NuevaVentana()
    End Sub

    Private Sub IteExporta1ArchivoHonorarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteExporta1ArchivoHonorarios.Click
        Dim win As New WExportarRegistroHonorarios1
        win.NuevaVentana()
    End Sub

    Private Sub IteExporta2ArchivoHonorarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteExporta2ArchivoHonorarios.Click
        Dim win As New WExportarRegistroHonorarios
        win.NuevaVentana()
    End Sub

    Private Sub IteCopiaBd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteCopiaBd.Click
        Dim win As New WCopiaBd
        win.Show()
    End Sub

    Private Sub ItePorOrigenGastoReparable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItePorOrigenGastoReparable.Click
        Dim win As New WImpGastoReparableDetalleXOrigen
        win.InicializaVentana()
    End Sub

    Private Sub ToolStripButton2_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Dim win As New WRegistroCajaBanco
        win.NuevaVentana()
    End Sub

    Private Sub IteVentasLibroOficial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteVentasLibroOficial.Click
        Dim win As New WImpResgistroVenta
        win.InicializaVentana()
    End Sub

    Private Sub IteVentasParaAnalisis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteVentasParaAnalisis.Click
        Dim win As New WImpRegistroVentasDol
        win.InicializaVentana()
    End Sub

    Private Sub IteTodosLosMovimientos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteTodosLosMovimientos.Click
        Dim win As New WImpAnalisisAuxiliaresTodosNuevo
        win.InicializaVentana()
    End Sub

    Private Sub IteSoloSaldo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteSoloSaldo.Click
        Dim win As New WImpAnalisisAuxiliaresSaldoNuevo
        win.InicializaVentana()
    End Sub

    Private Sub IteRelacionResumenNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteRelacionResumenNuevo.Click
        Dim win As New WImpAnalisisAuxiliaresResumenNuevo
        win.InicializaVentana()
    End Sub

    Private Sub IteImportarBoletasVenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteImportarBoletasVenta.Click
        Dim win As New WImportarBoletasVenta
        win.InicializaVentana()
    End Sub

    Private Sub IteImportarDiario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteImportarDiario.Click
        Dim win As New WImportarDiario
        win.InicializaVentana()
    End Sub

    Private Sub IteImportarBoletasVtaNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteImportarBoletasVtaNuevo.Click
        Dim win As New WImportarBoletasVentaNuevo
        win.InicializaVentana()
    End Sub

    Private Sub IteImportarDiarioSimple_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteImportarDiarioSimple.Click
        Dim win As New WImportarPlanilla
        win.InicializaVentana()
    End Sub

    Private Sub IteConQuiebreAnalisisCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteConQuiebreAnalisisCuenta.Click
        Dim win As New WImpGastoAnalisis
        win.InicializaVentana()
    End Sub

    Private Sub IteSinQuiebreAnalisisCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteSinQuiebreAnalisisCuenta.Click
        'Dim win As New WImpGastoAnalisis
        Dim win As New WImpGastoAnalisisNuevo
        win.InicializaVentana()
    End Sub

    
    Private Sub IteImportarRegVtaFincaER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IteImportarRegVtaFincaER.Click
        If (SuperEntidad.xCodigoEmpresa <> "111") Then
            MsgBox("Empresa: " + SuperEntidad.xCodigoEmpresa + "-" + SuperEntidad.xRazonSocial + " No tiene acceso no se puede realizar la operación", MsgBoxStyle.Critical, "Aquiera los servicios")
            Return
        Else
            Dim win As New WImportarRegistroVentasFinca
            win.InicializaVentana()
        End If
    End Sub
End Class