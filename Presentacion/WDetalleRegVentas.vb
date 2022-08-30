Imports Entidad
Imports Negocio

Public Class WDetalleRegVentas
#Region "Propietarios"
    Public wRegVta As New WEditarRegistroVenta
#End Region

    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public ent, entpar As New SuperEntidad
    Public concepto As String = ""
    Public tab As New TablaRN
    Public cta As New PlanCuentaGeRN
    Public cam As New CamposEntidad
    Public par As New ParametroRN
    Public titulo As String


#Region "operaciones"

    Sub InicializaVentana()

        '/Para los eventos de controles
        acc.listaCtrls = Me.ListaControles
        acc.PasaFoco()
        acc.FomatoDato()
        acc.PasarCursor()
        acc.Teclazo()
        acc.Valida()
        entpar = par.buscarParametroExis(entpar)
        '/Ejecucion en ventana
        '       Me.Owner.Enabled = False
        Me.HabilitarSegunCuenta()
        ' Me.txtCodPro.ReadOnly = True
        '/por defecto
        Me.Show()
    End Sub
    Sub ParaNotaCredito()
        Dim codfil As String = Me.wRegVta.txtCodFil.Text.Trim
        If codfil = "507" Then
            Me.rbtDebe.Enabled = True
            Me.rbtDebe.Checked = True
            Me.rbtHaber.Enabled = False
        End If
    End Sub


    Sub NuevaVentana()
        Me.InicializaVentana()
        Me.Text = "Agregar Item"
        acc.LimpiarControles()
        Me.txtCodCuen.Focus()
        acc.Nuevo()
        Me.ParaNotaCredito()
    End Sub

    Sub ModificarVentana()
        Me.InicializaVentana()
        Me.Text = "Modificar Item"
        Me.DeGrillaAControles()
        Me.txtCencto.Focus()
        acc.Modificar()
        Me.ParaNotaCredito()
    End Sub

    Sub EliminaVentana()
        'Me.Show()
        Me.InicializaVentana()
        Me.Text = "Eliminar Item"
        Me.DeGrillaAControles()
        acc.Eliminar()
        Me.ParaNotaCredito()
    End Sub

    Sub DeGrillaAControles()
        Dim indFil As Integer = Me.wRegVta.dgvRegVta.CurrentRow.Index
        If indFil = Me.wRegVta.dgvRegVta.Rows.Count - 1 Then
            Me.Close()
            Exit Sub

        Else

            Me.txtCodCuen.Text = Me.wRegVta.dgvRegVta.Item(0, indFil).Value.ToString
            Me.txtNomCue.Text = Me.wRegVta.dgvRegVta.Item(1, indFil).Value.ToString
            Me.txtCencto.Text = Me.wRegVta.dgvRegVta.Item(2, indFil).Value.ToString
            Me.txtNomCto.Text = Me.wRegVta.dgvRegVta.Item(3, indFil).Value.ToString
            'haber debe
            Dim str As String = Me.wRegVta.dgvRegVta.Item(4, indFil).Value.ToString
            If str = "Haber" Then
                Me.rbtHaber.Checked = True
            Else
                Me.rbtDebe.Checked = True
            End If
            Me.txtImpSol.Text = Me.wRegVta.dgvRegVta.Item(5, indFil).Value.ToString
            Me.txtImpDol.Text = Me.wRegVta.dgvRegVta.Item(6, indFil).Value.ToString
            Me.txtGlosa.Text = Me.wRegVta.dgvRegVta.Item(7, indFil).Value.ToString
            Me.txtCodie.Text = Me.wRegVta.dgvRegVta.Item(8, indFil).Value.ToString
            Me.txtNomIe.Text = Me.wRegVta.dgvRegVta.Item(9, indFil).Value.ToString

        End If

    End Sub


    Sub DeControlesAGrilla()
        Dim indiceFila As Integer

        Select Case Me.Text

            Case "Agregar Item"
                Me.wRegVta.dgvRegVta.Rows.Add()

                indiceFila = Me.wRegVta.dgvRegVta.Rows.Count - 2

            Case "Modificar Item"
                indiceFila = Me.wRegVta.dgvRegVta.CurrentRow.Index

            Case "Eliminar Item"
                Dim rpta As Integer = MsgBox("Deseas eliminar el item", MsgBoxStyle.YesNo)
                If rpta = MsgBoxResult.Yes Then
                    MsgBox("Item eliminado")
                    indiceFila = Me.wRegVta.dgvRegVta.CurrentRow.Index
                    Me.wRegVta.dgvRegVta.Rows.RemoveAt(indiceFila)
                    Me.Close()
                    Exit Sub
                Else
                    Me.Close()
                    Exit Sub
                End If


        End Select

        Me.wRegVta.dgvRegVta.Rows(indiceFila).Cells(0).Value = Me.txtCodCuen.Text.Trim
        Me.wRegVta.dgvRegVta.Rows(indiceFila).Cells(1).Value = Me.txtNomCue.Text.Trim
        Me.wRegVta.dgvRegVta.Rows(indiceFila).Cells(2).Value = Me.txtCencto.Text.Trim
        Me.wRegVta.dgvRegVta.Rows(indiceFila).Cells(3).Value = Me.txtNomCto.Text.Trim
        Dim str As String = Rbt.radioActivo(Me.gbDebeHaber).Text
        Me.wRegVta.dgvRegVta.Rows(indiceFila).Cells(4).Value = str
        Me.wRegVta.dgvRegVta.Rows(indiceFila).Cells(5).Value = Me.txtImpSol.Text.Trim
        Me.wRegVta.dgvRegVta.Rows(indiceFila).Cells(6).Value = Me.txtImpDol.Text.Trim
        Me.wRegVta.dgvRegVta.Rows(indiceFila).Cells(7).Value = Me.txtGlosa.Text.Trim
        Me.wRegVta.dgvRegVta.Rows(indiceFila).Cells(8).Value = Me.txtCodie.Text.Trim
        Me.wRegVta.dgvRegVta.Rows(indiceFila).Cells(9).Value = Me.txtNomIe.Text.Trim
    End Sub

    Public Function EsCentroCostoValido() As Boolean
        Dim iCCosRN As New CentroCostoRN
        Dim iCCosEN As New SuperEntidad
        iCCosEN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iCCosEN.CodigoCentroCosto = Me.txtCencto.Text.Trim
        iCCosEN = iCCosRN.EsCentroCostoValido(iCCosEN)
        If iCCosEN.EsVerdad = False Then
            MsgBox(iCCosEN.Mensaje, MsgBoxStyle.Exclamation, "Centro Costos")
            Me.txtCencto.Focus()
        End If
        Me.MostarCentroCosto(iCCosEN)
        Return iCCosEN.EsVerdad
    End Function

    Sub MostarCentroCosto(ByRef pCC As SuperEntidad)
        Me.txtCencto.Text = pCC.CodigoCentroCosto
        Me.txtNomCto.Text = pCC.NombreCentroCosto
    End Sub


    Public Function EsIngresoEgresoValido() As Boolean
        Dim iIngEgrRN As New IngresoEgresoRN
        Dim iIngEgrEN As New SuperEntidad
        iIngEgrEN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iIngEgrEN.CodigoIngresoEgreso = Me.txtCodIe.Text.Trim
        iIngEgrEN = iIngEgrRN.EsIngresoEgresoValido(iIngEgrEN)
        If iIngEgrEN.EsVerdad = False Then
            MsgBox(iIngEgrEN.Mensaje, MsgBoxStyle.Exclamation, "Ingreso/Egreso")
            Me.txtCodIe.Focus()
        End If
        Me.MostarIngresoEgreso(iIngEgrEN)
        Return iIngEgrEN.EsVerdad
    End Function


    Sub MostarIngresoEgreso(ByRef pIE As SuperEntidad)
        Me.txtCodIe.Text = pIE.CodigoIngresoEgreso
        Me.txtNomIe.Text = pIE.NombreIngresoEgreso
    End Sub

#End Region

    Private Sub WEditarPptoInterno_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
        Me.wRegVta.btnAceptar.Focus()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If acc.CamposObligatorios = False Then
            Exit Sub
        Else
            Me.DeControlesAGrilla()
            Me.wRegVta.ImportesSolesDolares()
            If Me.Text = "Agregar Item" Then
                acc.LimpiarControles()
                Me.txtCodCuen.Focus()
            End If
            If Me.Text = "Modificar Item" Then
                Me.Close()
            End If

        End If

    End Sub

#Region "Mostrar Formulario lista"

    Private Sub txtCodCuen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodCuen.KeyDown
        If Me.Text = "Agregar Item" Or Me.Text = "Modificar Item" Then
            If Me.txtCodCuen.ReadOnly = False Then
                If e.KeyCode = Keys.F1 Then
                    Dim win As New WListarPlanCuentaGe
                    win.tabla = "CuentasAnaliticas"    ''va la condicion del case
                    win.titulo = "Cuentas"
                    win.txt1 = Me.txtCodCuen
                    win.txt2 = Me.txtNomCue
                    If Me.txtCencto.Enabled = True Then
                        win.ctrlFoco = Me.txtCencto
                    Else
                        Me.txtCencto.Text = ""
                        Me.txtNomCto.Text = ""
                        win.ctrlFoco = Me.txtImpSol
                    End If
                    'win.ctrlFoco = Me.txtCencto
                    win.NuevaVentana()
                End If
                If e.KeyCode = Keys.Escape Then
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub txtCencto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCencto.KeyDown
        If Me.Text = "Agregar Item" Or Me.Text = "Modificar Item" Then
            If Me.txtCencto.ReadOnly = False Then
                If e.KeyCode = Keys.F1 Then
                    Dim win As New WListarCentroCostos
                    win.titulo = "Centro Costos Activos"
                    ' win.ent.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
                    win.tabla = "CentroCosto"
                    win.txt1 = Me.txtCencto
                    win.txt2 = Me.txtNomCto
                    win.ctrlFoco = Me.txtImpSol
                    win.NuevaVentana()
                End If
            End If
        End If
    End Sub

    Private Sub txtCodie_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodie.KeyDown
        If Me.Text = "Agregar Item" Or Me.Text = "Modificar Item" Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarIngEgr
                win.titulo = "Ingresos & Egresos Activos"
                ' win.ent.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
                win.tabla = "IngresoEgreso"
                win.txt1 = Me.txtCodie
                win.txt2 = Me.txtNomIe
                win.ctrlFoco = Me.btnAgregar
                win.NuevaVentana()
            End If
        End If
    End Sub

    'Private Sub txtCta42_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If Me.Text = "Agregar Item" Or Me.Text = "Modificar Item" Then
    '        If e.KeyCode = Keys.F1 Then
    '            Dim win As New WListarTabla
    '            win.tabla = "Cuenta42"
    '            win.titulo = "Cuentas42"
    '            win.txt1 = Me.txtCta42
    '            win.txt2 = Me.txtNomCue42
    '            win.ctrlFoco = Me.btnAgregar
    '            win.NuevaVentana()
    '        End If
    '    End If
    'End Sub

#End Region

#Region "Buscar Por Codigo"

    Private Sub txtCodCue_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodCuen.Validating
        If Me.Text = "Agregar Item" Or Me.Text = "Modificar Item" Then
            Dim ope As New OperaWin : ope.txt1 = Me.txtCodCuen : ope.txt2 = Me.txtNomCue
            ope.Condicion = "CuentasAnaliticas"
            ope.MostrarCodigoDescripcionDePlancuentas("CuentasAnaliticas", e)
            Me.HabilitarSegunCuenta()
        End If
    End Sub

    Private Sub txtCenCto_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCencto.Validating
        Me.EsCentroCostoValido()
    End Sub

    Private Sub txtCodie_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodie.Validating
        Me.EsIngresoEgresoValido()
    End Sub


#End Region

#Region "Calculos"
    Private Sub txtImpSol_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtImpSol.Validated
        Me.txtImpDol.Text = Varios.numeroConDosDecimal((CType(Me.txtImpSol.Text, Decimal) / CType(Me.wRegVta.txtTipCam.Text, Decimal)).ToString)
        Dim resta As Decimal = CType(Me.wRegVta.txtImpTotSol.Text, Decimal) - Me.wRegVta.sumaImportes

    End Sub


    Sub HabilitarSegunCuenta()

        Me.txtCenCto.Enabled = False

        Dim ocue As New SuperEntidad
        ocue.ClaveCuentaPcge = SuperEntidad.xCodigoEmpresa + Me.txtCodCuen.Text.Trim
        ocue.NumeroDigitosPcge = entpar.DigitosCuentaAnalitica
        ocue = cta.buscarCuentaExisPorClaveyAnalitica(ocue)

        Me.txtCenCto.Enabled = CBool(IIf(ocue.FlagCentroCostoPcge = "Si", True, False))

        If ocue.FlagCentroCostoPcge = "Si" Then
            Me.txtCencto.Enabled = True
            Me.txtCencto.Focus()
        Else
            Me.txtCencto.Text = ""
            Me.txtNomCto.Text = ""
            Me.txtImpSol.Focus()
        End If

    End Sub


#End Region


    
End Class