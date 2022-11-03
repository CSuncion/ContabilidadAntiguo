Imports CrystalDecisions.CrystalReports.Engine
Imports Entidad
Imports Negocio

Public Class WImpReporteMesDifCam

    Public par As New ParametroRN
    Dim cam As New CamposEntidad
    Dim ds As New DataSet1
    Dim tb As New DataTable
    Dim acc As New Accion
    Dim periodo, empresa As CrystalDecisions.CrystalReports.Engine.TextObject

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
    End Sub

    Sub Imprimir()

        ds.DiferenciaCambio.Clear()
        'Llenar Cabecera() 
        periodo = CType(Me.CrReporteMesDifCam1.Section2.ReportObjects.Item("Periodo"), CrystalDecisions.CrystalReports.Engine.TextObject)
        periodo.Text = "Del mes de " + Me.txtDesMes.Text + " del " + Me.txtAno.Text

        empresa = CType(Me.CrReporteMesDifCam1.Section2.ReportObjects.Item("Empresa"), CrystalDecisions.CrystalReports.Engine.TextObject)
        empresa.Text = Me.txtNomEmp.Text

        '' Traer EL REPORTE DE DIFERENCIA DE CAMBIO
        Dim iCueCorHisRN As New CuentaCorrienteHistoricoRN
        Dim iCueCorHisEN As New SuperEntidad
        iCueCorHisEN.AnoTipoCambio = Me.txtAno.Text.Trim
        iCueCorHisEN.MesTipoCambio = Me.txtCodMes.Text.Trim
        iCueCorHisEN.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        Dim ilisRes As New List(Of SuperEntidad)
        ilisRes = iCueCorHisRN.ReporteXMesDiferenciaCambio(iCueCorHisEN)

        For Each obj As SuperEntidad In ilisRes

            Dim NewRow As DataSet1.DiferenciaCambioRow
            NewRow = ds.DiferenciaCambio.NewDiferenciaCambioRow
            NewRow.CodigoAuxiliar = obj.CodigoAuxiliar
            NewRow.NombreAuxiliar = obj.DescripcionAuxiliar
            NewRow.NumeroDocumento = obj.NumeroDocumento
            NewRow.FechaDocumento = obj.FechaDocumento
            NewRow.CodigoCuentaPcge = obj.CodigoCuentaPcge
            NewRow.MonedaDocumento = obj.MonedaDocumento
            NewRow.ImporteDocumento = obj.ImporteDRegContabDeta
            NewRow.TipoCambioDocumento = obj.VentaTipoCambio
            NewRow.ImporteSolDocumento = obj.ImporteSRegContabDeta
            NewRow.TipoCambioActDocumento = obj.VentaEurTipoCambio
            NewRow.ImporteSolActDocumento = obj.ImporteSolRegContabCabe
            NewRow.ImporteDebe = obj.SumaDebeRegContabCabe
            NewRow.ImporteHaber = obj.SumaHaberRegContabCabe
            'LLENANDO EL REGISTRO
            'AÑADIR AL DS
            ds.DiferenciaCambio.Rows.Add(NewRow)
        Next

        Me.CrReporteMesDifCam1.SetDataSource(ds)
        'Cargamos en nuestro formulario el cr
        Me.crv1.ReportSource = Me.CrReporteMesDifCam1
       
        '/
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

#End Region

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Dim rpta As Integer = MsgBox("Deseas cancelar la operacion", MsgBoxStyle.YesNo, "Matriz")
        If rpta = MsgBoxResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btnEjecutar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEjecutar.Click

        If acc.CamposObligatorios = False Then
            Exit Sub
        Else
            Me.Imprimir()
        End If

    End Sub
End Class