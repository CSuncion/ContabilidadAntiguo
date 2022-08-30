Imports Entidad
Imports Negocio


Public Class WImpEstadoBancos
    Public ent, entCont, paren As New SuperEntidad
    Public lista, listarc As New List(Of SuperEntidad)
    Public rcc As New RegContabCabeRN
    Public rcd As New RegContabDetaRN
    Public rcdc As New MovimientoContableCabeceraRN
    Public rcdm As New MovimientoContableDetalleRN
    Public sb As New SaldosBancariosRN
    Public cbco As New CuentaBancoRN
    Public par As New ParametroRN
    Dim cam As New CamposEntidad
    Dim ds As New DataSet1
    Dim tb As New DataTable
    Dim cr As New CrRptEstadoBancos
    Dim acc As New Accion
    Dim numerodigitos As String
    Dim ano, mes, empresa, periodo, ruc, debe, haber, ImpDebe, ImpHaber, ImporteSol, ImporteDol, Codcta, Nomcta, numcta, moneda As CrystalDecisions.CrystalReports.Engine.TextObject

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
        Me.txtCodMes.Focus()
        'acc.Nuevo()
    End Sub

    Sub PorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.txtNomEmp.Text = SuperEntidad.xRazonSocial
        Me.txtAno.Text = SuperEntidad.xPeriodoEmpresa.Substring(0, 4)
        paren = par.buscarParametroExis(paren)
        numerodigitos = paren.DigitosCuentaAnalitica
    End Sub

    Sub Imprimir()

        ds.RegContab.Clear()
        'Llenar Cabecera()
        periodo = CType(Me.cr.Section2.ReportObjects.Item("Periodo"), CrystalDecisions.CrystalReports.Engine.TextObject)
        periodo.Text = Me.txtAno.Text + Me.txtCodMes.Text

        ruc = CType(Me.cr.Section2.ReportObjects.Item("Ruc"), CrystalDecisions.CrystalReports.Engine.TextObject)
        ruc.Text = SuperEntidad.xRucEmpresa

        empresa = CType(Me.cr.Section2.ReportObjects.Item("Empresa"), CrystalDecisions.CrystalReports.Engine.TextObject)
        empresa.Text = Me.txtNomEmp.Text

        numcta = CType(Me.cr.Section2.ReportObjects.Item("Numcta"), CrystalDecisions.CrystalReports.Engine.TextObject)
        numcta.Text = Me.TxtNunCta.Text

        moneda = CType(Me.cr.Section2.ReportObjects.Item("moneda"), CrystalDecisions.CrystalReports.Engine.TextObject)
        moneda.Text = Me.TxtMoneda.Text

        Codcta = CType(Me.cr.Section2.ReportObjects.Item("TxtCodCta"), CrystalDecisions.CrystalReports.Engine.TextObject)
        Codcta.Text = Me.TxtCodCb.Text

        Nomcta = CType(Me.cr.Section2.ReportObjects.Item("TxtNomCta"), CrystalDecisions.CrystalReports.Engine.TextObject)
        Nomcta.Text = Me.TxtNomCb.Text

        'debe = CType(Me.cr.Section2.ReportObjects.Item("Debe"), CrystalDecisions.CrystalReports.Engine.TextObject)
        'debe.Text = Me.debetxtAno.Text + Me.txtCodMes.Text

        ''Traer Saldo Anterior
        Dim salant As Decimal = 0
        Dim sal As Decimal = 0

        Dim omes As String = ""
        Dim oma As New SuperEntidad
        If Me.txtCodMes.Text.Trim = "01" Then
            omes = "01"
        Else
            omes = (CType(Me.txtCodMes.Text.Trim, Integer) - 1).ToString.PadLeft(2, CType("0", Char))
        End If
        oma.ClaveSaldosBancarios = SuperEntidad.xCodigoEmpresa + Me.TxtCodCb.Text.Trim + Me.txtAno.Text.Trim + omes
        oma = sb.buscarSaldosBancariosExisPorClave(oma)


        'If Me.TxtMoneda.Text.Trim = "S/." Then
        '    salant = oma.SaldoMesSolAntCuentaBanco
        'Else
        '    salant = oma.SaldoMesDolAntCuentaBanco
        'End If

        If omes = "01" Then
            Select Case Me.TxtMoneda.Text.Trim
                Case "S/."
                    If Me.txtCodMes.Text = "02" Then
                        salant = oma.SaldoMesSolCuentaBanco
                    Else
                        salant = oma.SaldoMesSolAntCuentaBanco
                    End If
                Case "US$"
                    If Me.txtCodMes.Text = "02" Then
                        salant = oma.SaldoMesDolCuentaBanco
                    Else
                        salant = oma.SaldoMesDolAntCuentaBanco
                    End If
                Case "EUR"
                    If Me.txtCodMes.Text = "02" Then
                        salant = oma.SaldoMesEurCuentaBanco
                    Else
                        salant = oma.SaldoMesEurAntCuentaBanco
                    End If

            End Select
            'If Me.TxtMoneda.Text.Trim = "S/." Then
            '    If Me.txtCodMes.Text = "02" Then
            '        salant = oma.SaldoMesSolCuentaBanco
            '    Else
            '        salant = oma.SaldoMesSolAntCuentaBanco
            '    End If

            'Else
            '    If Me.txtCodMes.Text = "02" Then
            '        salant = oma.SaldoMesDolCuentaBanco
            '    Else
            '        salant = oma.SaldoMesDolAntCuentaBanco
            '    End If

            'End If
        Else
            Select Case Me.TxtMoneda.Text.Trim
                Case "S/."
                    salant = oma.SaldoMesSolCuentaBanco
                Case "US$"
                    salant = oma.SaldoMesDolCuentaBanco
                Case "EUR"
                    salant = oma.SaldoMesEurCuentaBanco
            End Select
            '    If Me.TxtMoneda.Text.Trim = "S/." Then
            '        salant = oma.SaldoMesSolCuentaBanco

            '    Else
            '        salant = oma.SaldoMesDolCuentaBanco
            '    End If
        End If

        '' Traer TODOS los movimientos 

        ent.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        ent.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        ent.CodigoCuentaPcge = Me.TxtCodCb.Text.Trim
        ent.DatoFiltro1 = Varios.AñoMesDia(Me.dtpDesde.Text)
        ent.DatoFiltro2 = Varios.AñoMesDia(Me.dtpHasta.Text)
        ent.CampoOrden = cam.FecVouRCC + "," + cam.NumVouRCC

        'TRAER MOVIMIENTO DETALLE

        listarc = rcd.ListarRegistrosContablesDetalleXEmpresaXPeriodoXCuentaYEntreFechas(ent)

        Dim xdebeini As Decimal = 0
        Dim xhaberini As Decimal = 0

        If salant < 0 Then
            xdebeini = 0
            xhaberini = Math.Abs(salant)
            sal = xhaberini * (-1)
        Else
            xdebeini = salant
            xhaberini = 0
            sal = xdebeini
        End If

        ImporteSol = CType(Me.cr.Section2.ReportObjects.Item("TxtImporteSol"), CrystalDecisions.CrystalReports.Engine.TextObject)
        ImporteSol.Text = Varios.numeroConDosDecimal(xdebeini.ToString)
        ImporteDol = CType(Me.cr.Section2.ReportObjects.Item("TxtImporteDol"), CrystalDecisions.CrystalReports.Engine.TextObject)
        ImporteDol.Text = Varios.numeroConDosDecimal(xhaberini.ToString)

        For Each obj As SuperEntidad In listarc

            Dim NewRow As DataSet1.RegContabRow
            NewRow = ds.RegContab.NewRegContabRow

            NewRow.ImporteSol = xdebeini
            NewRow.ImporteDol = xhaberini

            'Llenar Movimiento de bancos
            NewRow.Cuenta = obj.CodigoCuentaPcge
            NewRow.nombrecuenta = obj.NombreCuentaPcge
            NewRow.FechaVoucherrgContab = obj.FechaVoucherRegContabCabe
            NewRow.NumeroDocumento = obj.NumeroDocumento
            NewRow.CodigoOrigen = obj.CodigoOrigen
            NewRow.CodigoFile = obj.CodigoFile
            NewRow.NumeroVoucherRegContab = obj.NumeroVoucherRegContabCabe
            NewRow.DescripcionAuxiliar = obj.DescripcionRegContabCabe
            NewRow.GlosaRegContab = obj.GlosaRegContabDeta
            NewRow.VentaTipoCambio = obj.VentaTipoCambio
            'Si Debe / Haber 
            If obj.DebeHaberRegContabDeta = "Debe" Then
                Select Case Me.TxtMoneda.Text
                    Case "S/."
                        NewRow.ImporteDebe = obj.ImporteSRegContabDeta
                        NewRow.ImporteHaber = 0
                    Case "US$"
                        NewRow.ImporteDebe = obj.ImporteDRegContabDeta
                        NewRow.ImporteHaber = 0
                    Case "EUR"
                        NewRow.ImporteDebe = obj.ImporteERegContabDeta
                        NewRow.ImporteHaber = 0
                End Select
                'NewRow.ImporteDebe = obj.ImporteSRegContabDeta
                'NewRow.ImporteHaber = 0
            Else
                Select Case Me.TxtMoneda.Text
                    Case "S/."
                        NewRow.ImporteDebe = 0
                        NewRow.ImporteHaber = obj.ImporteSRegContabDeta
                    Case "US$"
                        NewRow.ImporteDebe = 0
                        NewRow.ImporteHaber = obj.ImporteDRegContabDeta
                    Case "EUR"
                        NewRow.ImporteDebe = 0
                        NewRow.ImporteHaber = obj.ImporteERegContabDeta
                End Select
                'NewRow.ImporteDebe = 0
                'NewRow.ImporteHaber = obj.ImporteSRegContabDeta
            End If
            NewRow.Saldos = NewRow.ImporteDebe - NewRow.ImporteHaber + sal
            sal = NewRow.Saldos

            'AGREGANDO REGISTROS AL DATATABLE
            'LLENANDO EL REGISTRO
            'AÑADIR AL DS
            ds.RegContab.Rows.Add(NewRow)

        Next

        If sal < 0 Then
            ImpHaber = CType(Me.cr.Section4.ReportObjects.Item("ImpHaber"), CrystalDecisions.CrystalReports.Engine.TextObject)
            ImpHaber.Text = Varios.numeroConDosDecimal(Math.Abs(sal).ToString)
            ImpDebe = CType(Me.cr.Section4.ReportObjects.Item("ImpDebe"), CrystalDecisions.CrystalReports.Engine.TextObject)
            ImpDebe.Text = ""
        Else
            ImpDebe = CType(Me.cr.Section4.ReportObjects.Item("ImpDebe"), CrystalDecisions.CrystalReports.Engine.TextObject)
            ImpDebe.Text = Varios.numeroConDosDecimal(sal.ToString)
            ImpHaber = CType(Me.cr.Section4.ReportObjects.Item("ImpHaber"), CrystalDecisions.CrystalReports.Engine.TextObject)
            ImpHaber.Text = ""
        End If

        cr.SetDataSource(ds)
        'Cargamos en nuestro formulario el cr
        Me.crv1.ReportSource = cr
        'Dim win As New wImpParaEnvio
        'win.NuevaVentana(ds)
        '/
    End Sub

    Private Sub btnEjecutar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEjecutar.Click
        If acc.CamposObligatorios = False Then
            Exit Sub
        Else
            Me.Imprimir()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

#Region "Mostrar Form Lista"

    Private Sub txtCodMes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodMes.KeyDown
        If Me.txtCodMes.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarTabla
                win.tabla = "Mes"
                win.titulo = "Meses"
                win.txt1 = Me.txtCodMes
                win.txt2 = Me.txtDesMes
                win.ctrlFoco = Me.TxtCodCb
                win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub txtCodCb_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodCb.KeyDown
        If Me.TxtCodCb.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarCuentaBanco
                win.tabla = "PorEmpresa"    ''va la condicion del case
                win.titulo = "Bancos"
                win.txt1 = Me.TxtCodCb
                win.txt2 = Me.TxtNomCb
                win.txt4 = Me.TxtMoneda
                win.txt3 = Me.TxtNunCta
                win.ctrlFoco = Me.btnEjecutar
                win.NuevaVentana()
            End If
        End If

    End Sub

#End Region

#Region "Buscar Por Codigo"

    Private Sub txtCodMes_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodMes.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.txtCodMes : ope.txt2 = Me.txtDesMes
        ope.MostrarCodigoDescripcionDeTabla("Mes", "Meses", e)
    End Sub

    Private Sub txtCodCta_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodCb.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.TxtCodCb : ope.txt2 = Me.TxtNomCb : ope.txt3 = Me.TxtNunCta : ope.txt4 = Me.TxtMoneda
        ope.MostrarCodigoDescripcionDeCuentaBanco("PorEmpresa", e)
    End Sub

#End Region

End Class