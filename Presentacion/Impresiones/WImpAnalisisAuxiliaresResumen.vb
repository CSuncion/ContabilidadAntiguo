Imports Entidad
Imports Negocio

Public Class WImpAnalisisAuxiliaresResumen
    Public ent, entCont, paren As New SuperEntidad
    Public lista, listarc As New List(Of SuperEntidad)
    Public rcdc As New MovimientoContableCabeceraRN
    Public rcdm As New MovimientoContableDetalleRN
    Public rcds As New SaldoContableRN
    Public par As New ParametroRN
    Dim cam As New CamposEntidad
    Dim ds As New DataSet1
    Dim tb As New DataTable
    Dim cr As New CrRptAnalisisAuxiliaresResumen
    Dim acc As New Accion
    Dim numerodigitos As String
    Dim ano, mes, empresa, periodo, periodo1, cuenta, ruc As CrystalDecisions.CrystalReports.Engine.TextObject


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
        periodo.Text = Me.txtAno.Text + Me.txtCodMes.Text

        periodo1 = CType(Me.cr.Section2.ReportObjects.Item("Periodo1"), CrystalDecisions.CrystalReports.Engine.TextObject)
        periodo1.Text = Me.txtAno.Text + Me.TxtCodMes1.Text

        cuenta = CType(Me.cr.Section2.ReportObjects.Item("Cuenta"), CrystalDecisions.CrystalReports.Engine.TextObject)
        cuenta.Text = Me.TxtCodCta.Text.Trim

        ruc = CType(Me.cr.Section2.ReportObjects.Item("Ruc"), CrystalDecisions.CrystalReports.Engine.TextObject)
        ruc.Text = SuperEntidad.xRucEmpresa

        empresa = CType(Me.cr.Section2.ReportObjects.Item("Empresa"), CrystalDecisions.CrystalReports.Engine.TextObject)
        empresa.Text = Me.txtNomEmp.Text


        '' Traer TODOS los movimientos 

        Dim obMd As New SuperEntidad
        obMd.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        obMd.CodigoAuxiliar = ""
        obMd.CodigoCuentaPcge = Me.TxtCodCta.Text.Trim
        obMd.DatoCondicion1 = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        obMd.DatoCondicion2 = Me.txtAno.Text.Trim + Me.TxtCodMes1.Text.Trim
        obMd.CampoOrden = cam.CodAux
        'lista = rcdm.obtenerMovimientoDetalleXCuentaAuxiliarResumenEntrePeriodo(obMd)
        lista = rcdm.obtenerMovimientoDetalleXCuentaAuxiliarResumenEntrePeriodo1(obMd)

        ' MsgBox(lista.Count.ToString)

        For Each obj As SuperEntidad In lista

            Dim NewRow As DataSet1.RegContabRow
            NewRow = ds.RegContab.NewRegContabRow

            NewRow.CodigoAuxiliar = obj.CodigoAuxiliar
            NewRow.DescripcionAuxiliar = obj.DescripcionAuxiliar
            NewRow.ImporteDol = obj.ImporteDRegContabDeta
            NewRow.Saldos = obj.ImporteSRegContabDeta

            If NewRow.Saldos <> 0 Then
                ds.RegContab.Rows.Add(NewRow)
            End If
            'AGREGANDO REGISTROS AL DATATABLE
            'LLENANDO EL REGISTRO
            'A?ADIR AL DS

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
                win.ctrlFoco = Me.TxtCodCta
                win.NuevaVentana()
            End If
        End If
    End Sub

    'Private Sub txtCodAux_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodAux.KeyDown
    '    If Me.TxtCodAux.ReadOnly = False Then
    '        If e.KeyCode = Keys.F1 Then
    '            Dim win As New WListarAuxiliar
    '            win.tabla = "Todos"
    '            win.titulo = "Auxiliares"
    '            win.txt1 = Me.TxtCodAux
    '            win.txt2 = Me.TxtDesAux
    '            win.ctrlFoco = Me.TxtCodCta
    '            win.NuevaVentana()
    '        End If
    '    End If
    'End Sub


    Private Sub txtCodCta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodCta.KeyDown

        If Me.TxtCodCta.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarPlanCuentaGe
                win.tabla = "CuentasAnaliticas"    ''va la condicion del case
                win.titulo = "Cuentas"
                win.txt1 = Me.TxtCodCta
                win.txt2 = Me.TxtNomCta
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

    'Private Sub txtCodAux_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodAux.Validating

    '    Dim ope As New OperaWin : ope.txt1 = Me.TxtCodAux : ope.txt2 = Me.TxtDesAux
    '    ope.MostrarCodigoDescripcionDeAuxiliar("Todos", "Auxiliares", e)

    'End Sub

    Private Sub txtCodCta_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodCta.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.TxtCodCta : ope.txt2 = Me.TxtNomCta
        ope.Condicion = "CuentasAnaliticas"
        ope.MostrarCodigoDescripcionDePlancuentas("CuentasAnaliticas", e)
    End Sub
#End Region

#Region "Habilitar Control"

    Sub HabilitarControlesEstadoAuxiliar()
        ''/
        'Dim AuxTodInd As String = Rbt.radioActivo(Me.gbAnaAux).Text
        ''Habilitar los campos segun estado 
        'Select Case AuxTodInd
        '    Case "Todos"
        '        Me.TxtCodAux.Enabled = False
        '        Me.TxtCodAux.Text = ""
        '        Me.TxtDesAux.Text = ""
        '    Case "Individual"
        '        Me.TxtCodAux.Enabled = True

        'End Select
        '/
    End Sub

#End Region
    'Private Sub rbtAnaIndividual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtAnaIndividual.CheckedChanged, rbtAnaTodos.CheckedChanged
    '    '    Me.HabilitarControlesEstadoAuxiliar()
    'End Sub


End Class