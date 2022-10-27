Imports Entidad
Imports Negocio

Public Class WImpCeCoXIngresoResumen

    Dim cam As New CamposEntidad
    Dim ds As New DataSet1
    Dim acc As New Accion
    Dim ano, mes, empresa, periodo, ruc, codcc, ceco As CrystalDecisions.CrystalReports.Engine.TextObject

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
    End Sub

    Sub PorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.txtNomEmp.Text = SuperEntidad.xRazonSocial
        Me.txtAno.Text = SuperEntidad.xPeriodoEmpresa.Substring(0, 4)
    End Sub

    Sub Imprimir()

        ds.RegContab.Clear()
        'Llenar Cabecera()
        periodo = CType(Me.CrCeCoXIngresoResumen1.Section2.ReportObjects.Item("Periodo"), CrystalDecisions.CrystalReports.Engine.TextObject)
        periodo.Text = "Del mes de " + Me.txtDesMes.Text + " a " + Me.TxtDesMes1.Text + " del " + Me.txtAno.Text

        empresa = CType(Me.CrCeCoXIngresoResumen1.Section2.ReportObjects.Item("Empresa"), CrystalDecisions.CrystalReports.Engine.TextObject)
        empresa.Text = Me.txtNomEmp.Text

        codcc = CType(Me.CrCeCoXIngresoResumen1.Section2.ReportObjects.Item("codcc"), CrystalDecisions.CrystalReports.Engine.TextObject)
        codcc.Text = Me.txtCodCcDes.Text


        ceco = CType(Me.CrCeCoXIngresoResumen1.Section2.ReportObjects.Item("ceco"), CrystalDecisions.CrystalReports.Engine.TextObject)
        ceco.Text = Me.txtNomCcDes.Text


        '' Traer TODOS los detalle del registro contable
        Dim iRegConDetRN As New RegContabDetaRN
        Dim iRegConDetEN As New SuperEntidad
        iRegConDetEN.DatoFiltro1 = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        iRegConDetEN.DatoFiltro2 = Me.txtAno.Text.Trim + Me.TxtCodMes1.Text.Trim
        iRegConDetEN.CodigoCentroCosto = Me.txtCodCcDes.Text.Trim
        iRegConDetEN.CampoOrden = cam.CodIngEgr
        Dim ilisRes As New List(Of SuperEntidad)
        ilisRes = iRegConDetRN.ListarReporteCentroCostoXIngresoResumen(iRegConDetEN)

        For Each obj As SuperEntidad In ilisRes

            Dim NewRow As DataSet1.RegContabRow
            NewRow = ds.RegContab.NewRegContabRow
            NewRow.CodigoIngEgr = obj.CodigoIngEgr
            NewRow.NombreIngEgr = obj.NombreIngEgr
            NewRow.ImporteSol = obj.ImporteSRegContabDeta
            NewRow.CentroCosto = obj.CodigoCentroCosto
            NewRow.NombreDocumento = obj.NombreCentroCosto
            NewRow.PeriodoRegContab = obj.PeriodoRegContabCabe
            NewRow.CodigoOrigen = obj.CodigoIngEgr.Substring(0, 1)
            If obj.CodigoIngEgr.Substring(0, 1) = "1" Then
                NewRow.CodigoOrigen = "1:Total Ingresos"
            Else
                NewRow.CodigoOrigen = "2:Total Egresos"
            End If
            'AGREGANDO REGISTROS AL DATATABLE
            'LLENANDO EL REGISTRO
            'AÑADIR AL DS
            ds.RegContab.Rows.Add(NewRow)

        Next

        Me.CrCeCoXIngresoResumen1.SetDataSource(ds)
        'Cargamos en nuestro formulario el cr
        Me.crv1.ReportSource = Me.CrCeCoXIngresoResumen1
        'Dim win As New wImpParaEnvio
        ' win.NuevaVentana(ds)
        '/
    End Sub


    Public Function EsCentroCostoValido() As Boolean
        Dim iCCosRN As New CentroCostoRN
        Dim iCCosEN As New SuperEntidad
        iCCosEN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iCCosEN.CodigoCentroCosto = Me.txtCodCcDes.Text.Trim
        iCCosEN = iCCosRN.EsCentroCostoValido(iCCosEN)
        If iCCosEN.EsVerdad = False Then
            MsgBox(iCCosEN.Mensaje, MsgBoxStyle.Exclamation, "Centro Costos")
            Me.txtCodCcDes.Focus()
        End If
        Me.MostarCentroCosto(iCCosEN)
        Return iCCosEN.EsVerdad
    End Function

    Sub MostarCentroCosto(ByRef pCC As SuperEntidad)
        Me.txtCodCcDes.Text = pCC.CodigoCentroCosto
        Me.txtNomCcDes.Text = pCC.NombreCentroCosto
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
                win.ctrlFoco = Me.txtCodCcDes
                win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub txtCodCcDes_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodCcDes.KeyDown
        If Me.txtCodCcDes.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarCentroCostos
                win.titulo = "Centro Costos Activos"
                ' win.ent.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
                win.tabla = "CentroCosto"
                win.txt1 = Me.txtCodCcDes
                win.txt2 = Me.txtNomCcDes
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

    Private Sub txtCodCcDes_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodCcDes.Validating
        Me.EsCentroCostoValido()
    End Sub

#End Region







End Class