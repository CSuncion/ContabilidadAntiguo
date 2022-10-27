Imports Entidad
Imports Negocio

Public Class WImpPlanCuentas
#Region "Propietarios"
    Public wpcta As New WPcge
#End Region

    Public ent, entCont, paren As New SuperEntidad
    Public lista, listarc As New List(Of SuperEntidad)
    Public plan As New PlanDeCuentasRN
    Public par As New ParametroRN
    Dim cam As New CamposEntidad
    Dim ds As New DataSet1
    Dim tb As New DataTable
    Dim cr As New CrRptPlanCuentas
    Dim acc As New Accion
    Dim numerodigitos As String
    Dim ano, mes, empresa, periodo, ruc, cuenta1, cuenta2 As CrystalDecisions.CrystalReports.Engine.TextObject

    Sub InicializaVentana()
        '/Para los eventos de controles
        acc.listaCtrls = Me.ListaControles
        acc.PasaFoco()
        acc.FomatoDato()
        acc.PasarCursor()
        acc.Teclazo()
        acc.Valida()
        Me.Show()
        Me.HabilitarControlesEstadoCuenta()
        Me.TxtCodCta1.Focus()
        'acc.Nuevo()
    End Sub

    Sub Imprimir()

        ds.Pcge.Clear()
        'Llenar Cabecera()
        'periodo = CType(Me.cr.Section2.ReportObjects.Item("Periodo"), CrystalDecisions.CrystalReports.Engine.TextObject)
        'periodo.Text = Me.txtAno.Text + Me.txtCodMes.Text

        'ruc = CType(Me.cr.Section2.ReportObjects.Item("Ruc"), CrystalDecisions.CrystalReports.Engine.TextObject)
        'ruc.Text = SuperEntidad.xRucEmpresa

        'empresa = CType(Me.cr.Section2.ReportObjects.Item("Empresa"), CrystalDecisions.CrystalReports.Engine.TextObject)
        'empresa.Text = Me.txtNomEmp.Text


        '' Traer TODAS las cuentas 

        Dim obPl As New SuperEntidad
        Dim cuenta1 As String = ""
        Dim cuenta2 As String = ""

        'obPl.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        obPl.CampoOrden = cam.CodCtaPcge

        Select Case Rbt.radioActivo(Me.gbTodPar).Text.Trim
            Case "Todas"
                cuenta1 = "0"
                cuenta2 = "9999999"
            Case "Parcial"
                cuenta1 = Me.TxtCodCta1.Text.Trim
                cuenta2 = Me.TxtCodCta2.Text.Trim
        End Select

        Dim clave As String = ""
        Dim claveanterior As String = ""
        Dim saldo As Decimal = 0

        lista = plan.obtenerPlanDeCuentasExis(obPl)

        For Each obj As SuperEntidad In lista

            If obj.CodigoCuentaPcge >= cuenta1 And obj.CodigoCuentaPcge <= cuenta2 Then

                Dim NewRow As DataSet1.PcgeRow
                NewRow = ds.Pcge.NewPcgeRow

                NewRow.Cuenta = obj.CodigoCuentaPcge
                NewRow.NombreCuenta = obj.NombreCuentaPcge
                NewRow.NumeroDigitos = obj.NumeroDigitosPcge
                'AGREGANDO REGISTROS AL DATATABLE
                'LLENANDO EL REGISTRO
                'AÑADIR AL DS
                ds.Pcge.Rows.Add(NewRow)

            End If
        Next

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
        Dim rpta As Integer = MsgBox("Deseas cancelar la operacion", MsgBoxStyle.YesNo, "Plan General Empresarial")
        If rpta = MsgBoxResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

#Region "Mostrar Form Lista"

    Private Sub txtCodCta1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodCta1.KeyDown
        If Me.TxtCodCta1.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarPlanCuentaGe
                win.tabla = "Todos"    ''va la condicion del case
                win.titulo = "Cuentas"
                win.txt1 = Me.TxtCodCta1
                win.txt2 = Me.TxtNomCta1
                win.ctrlFoco = Me.TxtCodCta2
                win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub txtCodCta2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodCta2.KeyDown
        If Me.TxtCodCta2.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarPlanCuentaGe
                win.tabla = "Todos"    ''va la condicion del case
                win.titulo = "Cuentas"
                win.txt1 = Me.TxtCodCta2
                win.txt2 = Me.TxtNomCta2
                win.ctrlFoco = Me.btnEjecutar
                win.NuevaVentana()
            End If
        End If
    End Sub

#End Region

#Region "Buscar Por Codigo"

    Private Sub txtCodCta1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodCta1.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.TxtCodCta1 : ope.txt2 = Me.TxtNomCta1
        ope.Condicion = "Todos"
        ope.MostrarCodigoDescripcionDePlancuentas("Todos", e)
    End Sub

    Private Sub txtCodCta21_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodCta2.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.TxtCodCta2 : ope.txt2 = Me.TxtNomCta2
        ope.Condicion = "Todos"
        ope.MostrarCodigoDescripcionDePlancuentas("Todos", e)
    End Sub

#End Region

#Region "Habilitar Control"

    Sub HabilitarControlesEstadoCuenta()

        If Me.rbtParcial.Checked = True Or Me.rbtTodos.Checked = True Then
            Dim Auto As String = Rbt.radioActivo(Me.gbTodPar).Text
            'Habilitar los campos calculados segun la detraccion
            Select Case Auto
                Case "Todas"
                    Me.TxtCodCta1.Enabled = False
                    Me.TxtCodCta1.Text = ""
                    Me.TxtNomCta1.Text = ""
                    Me.TxtCodCta2.Enabled = False
                    Me.TxtCodCta2.Text = ""
                    Me.TxtNomCta2.Text = ""
                Case "Parcial"
                    Me.TxtCodCta1.Enabled = True
                    Me.TxtNomCta1.Text = ""
                    Me.TxtCodCta2.Enabled = True
                    Me.TxtNomCta2.Text = ""
            End Select
        End If
    End Sub

#End Region
    Private Sub rbtAnaIndividual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtParcial.CheckedChanged, rbtTodos.CheckedChanged
        Me.HabilitarControlesEstadoCuenta()
    End Sub

    Private Sub TxtCodCta2_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCodCta2.Validated
        If Me.TxtCodCta1.Text.Trim <> "" Then
            Dim codOri As String = Me.TxtCodCta1.Text.Trim
            If codOri > Me.TxtCodCta2.Text.Trim Then
                MsgBox("Cuenta Hasta Debe ser Mayor o Igual" + Chr(13) + "Que Cuenta Desde", MsgBoxStyle.Exclamation)
                Me.TxtCodCta2.Text = ""
                Me.TxtNomCta2.Text = ""
                Me.TxtCodCta2.Focus()
            End If
        End If
    End Sub

End Class