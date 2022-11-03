Imports Entidad
Imports Negocio

Public Class WImpCuentaCentroCosto
    Public ent, entCont, paren As New SuperEntidad
    Public lista, listarc As New List(Of SuperEntidad)
    Public rcdc As New RegContabDetaRN
    Public rcds As New SaldoContableRN
    Public par As New ParametroRN
    Dim cam As New CamposEntidad
    Dim ds As New DataSet1
    Dim tb As New DataTable
    Dim cr As New CrImpCuentaCentroCosto
    Dim acc As New Accion
    Dim numerodigitos As String
    Dim ano, mes, empresa, periodo, ruc As CrystalDecisions.CrystalReports.Engine.TextObject

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
        Me.HabilitarControlesEstadoAuxiliar()
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
        periodo.Text = "Del mes de " + Me.txtDesMes.Text + " a " + Me.TxtDesMes1.Text + " del " + Me.txtAno.Text

        empresa = CType(Me.cr.Section2.ReportObjects.Item("Empresa"), CrystalDecisions.CrystalReports.Engine.TextObject)
        empresa.Text = Me.txtNomEmp.Text


        '' Traer TODOS los detalle del registro contable
        Dim iRegConDetRN As New RegContabDetaRN
        Dim iRegConDetEN As New SuperEntidad
        iRegConDetEN.DatoFiltro1 = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        iRegConDetEN.DatoFiltro2 = Me.txtAno.Text.Trim + Me.TxtCodMes1.Text.Trim
        iRegConDetEN.DatoFiltro3 = Me.txtCodCta1.Text.Trim
        iRegConDetEN.DatoFiltro4 = Me.txtCodCta2.Text.Trim
        iRegConDetEN.CodigoCentroCosto = Me.TxtCodCto.Text.Trim
        iRegConDetEN.CampoOrden = cam.CodCtaPcge + "," + cam.CodCC + "," + cam.DebHabRCD
        Dim ilisRes As New List(Of SuperEntidad)
        ilisRes = iRegConDetRN.ListarReporteXCentroCuentasYCosto(iRegConDetEN)

        For Each obj As SuperEntidad In ilisRes

            Dim NewRow As DataSet1.RegContabRow
            NewRow = ds.RegContab.NewRegContabRow

            NewRow.CentroCosto = obj.CodigoCentroCosto
            NewRow.NombreCentroCosto = obj.NombreCentroCosto
            NewRow.Cuenta = obj.CodigoCuentaPcge
            NewRow.nombrecuenta = obj.NombreCuentaPcge
            NewRow.ImporteDebe = obj.SumaDebeRegContabCabe
            NewRow.ImporteHaber = obj.SumaHaberRegContabCabe

            'AGREGANDO REGISTROS AL DATATABLE
            'LLENANDO EL REGISTRO
            'AÑADIR AL DS
            ds.RegContab.Rows.Add(NewRow)

        Next

        cr.SetDataSource(ds)
        'Cargamos en nuestro formulario el cr
        Me.crvCtaCto.ReportSource = cr
        'Dim win As New wImpParaEnvio
        'win.NuevaVentana(ds)
        '/
    End Sub


    Sub CargarMovimientoXAuxiliar()
        Dim obMd As New SuperEntidad
        'obMd.CodigoAuxiliar = Me.TxtCodAux.Text.Trim
        obMd.DatoFiltro1 = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        obMd.DatoFiltro2 = Me.txtAno.Text.Trim + Me.TxtCodMes1.Text.Trim
        obMd.CampoOrden = cam.CodCtaPcge
        'lista = rcdm.obtenerMovimientoDetalleXAuxiliarYEntrePeriodo(obMd)

    End Sub

    Public Function EsCentroCostoValido() As Boolean
        Dim iCCosRN As New CentroCostoRN
        Dim iCCosEN As New SuperEntidad
        iCCosEN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iCCosEN.CodigoCentroCosto = Me.TxtCodCto.Text.Trim
        iCCosEN = iCCosRN.EsCentroCostoValido(iCCosEN)
        If iCCosEN.EsVerdad = False Then
            MsgBox(iCCosEN.Mensaje, MsgBoxStyle.Exclamation, "Centro Costos")
            Me.TxtCodCto.Focus()
        End If
        Me.MostarCentroCosto(iCCosEN)
        Return iCCosEN.EsVerdad
    End Function

    Sub MostarCentroCosto(ByRef pCC As SuperEntidad)
        Me.TxtCodCto.Text = pCC.CodigoCentroCosto
        Me.TxtNomCto.Text = pCC.NombreCentroCosto
    End Sub

    Private Sub btnEjecutar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEjecutar.Click
        If acc.CamposObligatorios = False Then
            Exit Sub
        Else
            Me.Imprimir()

        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Dim rpta As Integer = MsgBox("Deseas cancelar la operacion", MsgBoxStyle.YesNo, "Matriz")
        If rpta = MsgBoxResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
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
                win.ctrlFoco = Me.TxtCodMes1
                win.NuevaVentana()
            End If
        End If
    End Sub
    Private Sub txtCodMes1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodMes1.KeyDown
        If Me.txtCodMes.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarTabla
                win.tabla = "Mes"
                win.titulo = "Meses"
                win.txt1 = Me.TxtCodMes1
                win.txt2 = Me.TxtDesMes1
                win.ctrlFoco = Me.rbtAnaTodos
                win.NuevaVentana()
            End If
        End If
    End Sub




    Private Sub txtCodCto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodCto.KeyDown

        If Me.TxtCodCto.ReadOnly = False Then

            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarCentroCostos
                win.titulo = "Centro Costos Activos"
                ' win.ent.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
                win.tabla = "CentroCosto"
                win.txt1 = Me.TxtCodCto
                win.txt2 = Me.TxtNomCto
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

    Private Sub txtCodMes1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodMes1.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.TxtCodMes1 : ope.txt2 = Me.TxtDesMes1
        ope.MostrarCodigoDescripcionDeTabla("Mes", "Meses", e)
    End Sub


    Private Sub txtCodCto_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodCto.Validating
        Me.EsCentroCostoValido()
        'Dim ope As New OperaWin : ope.txt1 = Me.TxtCodCto : ope.txt2 = Me.TxtNomCto
        'ope.MostrarCodigoDescripcionDeTabla("Cto", "Centro de costo", e)
    End Sub
#End Region

#Region "Habilitar Control"

    Sub HabilitarControlesEstadoAuxiliar()

        If Me.rbtAnaIndividual.Checked = True Or Me.rbtAnaTodos.Checked = True Then
            Dim Auto As String = Rbt.radioActivo(Me.gbAnaAux).Text
            'Habilitar los campos calculados segun la detraccion
            Select Case Auto
                Case "Todos"
                    Me.TxtCodCto.Enabled = False
                    Me.TxtNomCto.Text = ""
                Case "Individual"
                    Me.TxtCodCto.Enabled = True
                    Me.TxtNomCto.Text = ""
            End Select
        End If
    End Sub

#End Region

    Private Sub rbtAnaIndividual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtAnaIndividual.CheckedChanged, rbtAnaTodos.CheckedChanged
        Me.HabilitarControlesEstadoAuxiliar()
    End Sub

    Private Sub txtCodCta1_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodCta1.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.txtCodCta1 : ope.txt2 = Me.txtNomCta1
        ope.Condicion = "CuentasAnaliticas"
        ope.MostrarCodigoDescripcionDePlancuentas("CuentasAnaliticas", e)

    End Sub

    Private Sub txtCodCta1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodCta1.KeyDown
        If Me.txtCodCta1.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarPlanCuentaGe
                win.tabla = "CuentasAnaliticas"    ''va la condicion del case
                win.titulo = "Cuentas"
                win.txt1 = Me.txtCodCta1
                win.txt2 = Me.txtNomCta1
                win.ctrlFoco = Me.txtCodCta2
                win.NuevaVentana()
            End If

        End If
    End Sub

    Private Sub txtCodCta2_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodCta2.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.txtCodCta2 : ope.txt2 = Me.txtNomCta2
        ope.Condicion = "CuentasAnaliticas"
        ope.MostrarCodigoDescripcionDePlancuentas("CuentasAnaliticas", e)

    End Sub

    Private Sub txtCodCta2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodCta2.KeyDown
        If Me.txtCodCta2.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarPlanCuentaGe
                win.tabla = "CuentasAnaliticas"    ''va la condicion del case
                win.titulo = "Cuentas"
                win.txt1 = Me.txtCodCta2
                win.txt2 = Me.txtNomCta2
                win.ctrlFoco = Me.gbAnaAux
                win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub WImpCuentaCentroCosto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtCodCta2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodCta2.TextChanged

    End Sub
End Class