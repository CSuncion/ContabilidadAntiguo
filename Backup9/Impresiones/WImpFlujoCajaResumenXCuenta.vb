Imports Entidad
Imports Negocio

Public Class WImpFlujoCajaResumenXCuenta

    Dim cam As New CamposEntidad
    Dim ds As New DataSet1
    Dim acc As New Accion
    Dim empresa, periodo, cue As CrystalDecisions.CrystalReports.Engine.TextObject

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

        ds.FlujoCaja.Clear()
        'Llenar Cabecera()
        periodo = CType(Me.CrFlujoCajaResumenXCuenta1.Section2.ReportObjects.Item("Periodo"), CrystalDecisions.CrystalReports.Engine.TextObject)
        periodo.Text = "Del mes de " + Me.txtDesMes.Text + " a " + Me.TxtDesMes1.Text + " del " + Me.txtAno.Text

        empresa = CType(Me.CrFlujoCajaResumenXCuenta1.Section2.ReportObjects.Item("Empresa"), CrystalDecisions.CrystalReports.Engine.TextObject)
        empresa.Text = Me.txtNomEmp.Text

        cue = CType(Me.CrFlujoCajaResumenXCuenta1.Section2.ReportObjects.Item("cue"), CrystalDecisions.CrystalReports.Engine.TextObject)
        cue.Text = Me.txtNomCue.Text


        '' Traer TODOS los detalle del registro contable
        Dim iRegConDetRN As New RegContabDetaRN
        Dim iRegConDetEN As New SuperEntidad
        iRegConDetEN.DatoFiltro1 = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        iRegConDetEN.DatoFiltro2 = Me.txtAno.Text.Trim + Me.TxtCodMes1.Text.Trim
        iRegConDetEN.CodigoCuentaPcge = Me.txtCodCue.Text.Trim
        iRegConDetEN.CampoOrden = cam.CodFluCaj
        Dim ilisRes As New List(Of SuperEntidad)
        ilisRes = iRegConDetRN.ListarReporteXFlujoCajaResumenXCuenta(iRegConDetEN)

        For Each obj As SuperEntidad In ilisRes

            Dim NewRow As DataSet1.FlujoCajaRow
            NewRow = ds.FlujoCaja.NewFlujoCajaRow
            NewRow.Codigo = obj.CodigoFlujoCaja
            NewRow.Nombre = obj.NombreFlujoCaja
            NewRow.IngresoSles = obj.IngresosSolCuentaBanco
            NewRow.EgresosSoles = obj.SalidasSolCuentaBanco
            'AGREGANDO REGISTROS AL DATATABLE
            'LLENANDO EL REGISTRO
            'AÑADIR AL DS
            ds.FlujoCaja.Rows.Add(NewRow)

        Next

        Me.CrFlujoCajaResumenXCuenta1.SetDataSource(ds)
        'Cargamos en nuestro formulario el cr
        Me.crv1.ReportSource = Me.CrFlujoCajaResumenXCuenta1
        'Dim win As New wImpParaEnvio
        ' win.NuevaVentana(ds)
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
                win.ctrlFoco = Me.txtCodCue
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

  

#End Region


    Private Sub txtCodCue_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodCue.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.txtCodCue : ope.txt2 = Me.txtNomCue
        ope.Condicion = "CuentasAnaliticas"
        ope.MostrarCodigoDescripcionDePlancuentas("CuentasAnaliticas", e)
    End Sub

    Private Sub txtCodCue_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodCue.KeyDown
        If Me.txtCodCue.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarPlanCuentaGe
                win.tabla = "CuentasAnaliticas"    ''va la condicion del case
                win.titulo = "Cuentas"
                win.txt1 = Me.txtCodCue
                win.txt2 = Me.txtNomCue
                win.ctrlFoco = Me.btnEjecutar
                win.NuevaVentana()
            End If
        End If
    End Sub
End Class