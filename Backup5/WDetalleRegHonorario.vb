Imports Entidad
Imports Negocio

Public Class WDetalleRegHonorario
#Region "Propietarios"
    Public wRegHon As New WEditarRegistroHonorario
#End Region

    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public ent, entpar As New SuperEntidad
    Public concepto As String = ""
    Public tab As New TablaRN
    Public par As New ParametroRN
    Public cta As New PlanCuentaGeRN
    Public cam As New CamposEntidad
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
        '  Me.Owner.Enabled = False
        ' Me.txtCodPro.ReadOnly = True
        '/por defecto
        Me.Show()
    End Sub

    Sub NuevaVentana()
        Me.InicializaVentana()
        Me.Text = "Agregar Item"
        acc.LimpiarControles()
        Me.txtCodCuen.Focus()
        acc.Nuevo()
    End Sub

    Sub ModificarVentana()
        Me.InicializaVentana()
        Me.Text = "Modificar Item"
        Me.DeGrillaAControles()
        Me.txtCodCuen.Focus()
        acc.Modificar()
    End Sub

    Sub EliminaVentana()
        'Me.Show()
        Me.InicializaVentana()
        Me.Text = "Eliminar Item"
        Me.DeGrillaAControles()
        acc.Eliminar()
    End Sub

    Sub DeGrillaAControles()


        Dim indFil As Integer = Me.wRegHon.dgvRegHon.CurrentRow.Index
        If indFil = Me.wRegHon.dgvRegHon.Rows.Count - 1 Then
            Me.Close()
            Exit Sub

        Else

            Me.txtCodCuen.Text = Me.wRegHon.dgvRegHon.Item(0, indFil).Value.ToString
            Me.txtNomCue.Text = Me.wRegHon.dgvRegHon.Item(1, indFil).Value.ToString
            Me.txtCencto.Text = Me.wRegHon.dgvRegHon.Item(2, indFil).Value.ToString
            Me.txtNomCto.Text = Me.wRegHon.dgvRegHon.Item(3, indFil).Value.ToString
            'haber debe
            Dim str As String = Me.wRegHon.dgvRegHon.Item(4, indFil).Value.ToString
            If str = "Haber" Then
                Me.rbtHaber.Checked = True
            Else
                Me.rbtDebe.Checked = True
            End If
            Me.txtImpSol.Text = Me.wRegHon.dgvRegHon.Item(5, indFil).Value.ToString
            Me.txtImpDol.Text = Me.wRegHon.dgvRegHon.Item(6, indFil).Value.ToString
            Me.txtCodie.Text = Me.wRegHon.dgvRegHon.Item(7, indFil).Value.ToString
            Me.txtNomIe.Text = Me.wRegHon.dgvRegHon.Item(8, indFil).Value.ToString
            Me.txtGlosa.Text = Me.wRegHon.dgvRegHon.Item(9, indFil).Value.ToString
            Me.TxtCodAre.Text = Me.wRegHon.dgvRegHon.Item(10, indFil).Value.ToString
            Me.TxtNomAre.Text = Me.wRegHon.dgvRegHon.Item(11, indFil).Value.ToString
            '  Me.TxtCodGasRep.Text = Me.wRegHon.dgvRegHon.Item(12, indFil).Value.ToString
            ' Me.TxtNomGasRep.Text = Me.wRegHon.dgvRegHon.Item(13, indFil).Value.ToString

        End If

    End Sub


    Sub DeControlesAGrilla()
        Dim indiceFila As Integer

        Select Case Me.Text

            Case "Agregar Item"

                ''/preguntar si el item ya esta agregado en la grilla detalle
                'If Me.wRegCom.dgvRegCom.Rows.Count = 1 Then
                '    'nada
                'Else
                '    'para evitar repetir dos items con un mismo proyecto
                '    For n As Integer = 0 To Me.wRegCom.dgvRegCom.Rows.Count - 2
                '        If Me.txtCodProy.Text.Trim = Me.wRegCom.dgvRegCom.Item(2, n).Value.ToString().Trim Then
                '            MsgBox("El proyecto ya existe en el detalle", MsgBoxStyle.Information)
                '            Me.txtCodProy.Text = ""
                '            Me.txtNomProy.Text = ""
                '            Me.txtCodProy.Focus()
                '            Exit Sub
                '        End If
                '    Next

                'End If


                Me.wRegHon.dgvRegHon.Rows.Add()

                indiceFila = Me.wRegHon.dgvRegHon.Rows.Count - 2

            Case "Modificar Item"
                indiceFila = Me.wRegHon.dgvRegHon.CurrentRow.Index

            Case "Eliminar Item"
                Dim rpta As Integer = MsgBox("Deseas eliminar el item", MsgBoxStyle.YesNo)
                If rpta = MsgBoxResult.Yes Then
                    MsgBox("Item eliminado")
                    indiceFila = Me.wRegHon.dgvRegHon.CurrentRow.Index
                    Me.wRegHon.dgvRegHon.Rows.RemoveAt(indiceFila)
                    Me.Close()
                    Exit Sub
                Else
                    Me.Close()
                    Exit Sub
                End If


        End Select

        Me.wRegHon.dgvRegHon.Rows(indiceFila).Cells(0).Value = Me.txtCodCuen.Text.Trim
        Me.wRegHon.dgvRegHon.Rows(indiceFila).Cells(1).Value = Me.txtNomCue.Text.Trim
        Me.wRegHon.dgvRegHon.Rows(indiceFila).Cells(2).Value = Me.txtCencto.Text.Trim
        Me.wRegHon.dgvRegHon.Rows(indiceFila).Cells(3).Value = Me.txtNomCto.Text.Trim
        Dim str As String = Rbt.radioActivo(Me.gbDebeHaber).Text
        Me.wRegHon.dgvRegHon.Rows(indiceFila).Cells(4).Value = str
        Me.wRegHon.dgvRegHon.Rows(indiceFila).Cells(5).Value = Me.txtImpSol.Text.Trim
        Me.wRegHon.dgvRegHon.Rows(indiceFila).Cells(6).Value = Me.txtImpDol.Text.Trim
        Me.wRegHon.dgvRegHon.Rows(indiceFila).Cells(7).Value = Me.txtCodie.Text.Trim
        Me.wRegHon.dgvRegHon.Rows(indiceFila).Cells(8).Value = Me.txtNomIe.Text.Trim
        Me.wRegHon.dgvRegHon.Rows(indiceFila).Cells(9).Value = Me.txtGlosa.Text.Trim
        Me.wRegHon.dgvRegHon.Rows(indiceFila).Cells(10).Value = Me.TxtCodAre.Text.Trim
        Me.wRegHon.dgvRegHon.Rows(indiceFila).Cells(11).Value = Me.TxtNomAre.Text.Trim
        '    Me.wRegHon.dgvRegHon.Rows(indiceFila).Cells(12).Value = Me.TxtCodGasRep.Text.Trim
        '   Me.wRegHon.dgvRegHon.Rows(indiceFila).Cells(13).Value = Me.TxtNomGasRep.Text.Trim
    End Sub



    Public Function EsCentroCostoValido() As Boolean
        Dim iCCosRN As New CentroCostoRN
        Dim iCCosEN As New SuperEntidad
        iCCosEN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iCCosEN.CodigoCentroCosto = Me.txtCenCto.Text.Trim
        iCCosEN = iCCosRN.EsCentroCostoActivoValido(iCCosEN)
        If iCCosEN.EsVerdad = False Then
            MsgBox(iCCosEN.Mensaje, MsgBoxStyle.Exclamation, "Centro Costos")
            Me.txtCenCto.Focus()
        End If
        Me.MostarCentroCosto(iCCosEN)
        Me.txtImpSol.Focus()
        Return iCCosEN.EsVerdad
    End Function


    Sub MostarCentroCosto(ByRef pCC As SuperEntidad)
        Me.txtCenCto.Text = pCC.CodigoCentroCosto
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
        Me.TxtCodAre.Focus()
        Return iIngEgrEN.EsVerdad
    End Function


    Sub MostarIngresoEgreso(ByRef pIE As SuperEntidad)
        Me.txtCodIe.Text = pIE.CodigoIngresoEgreso
        Me.txtNomIe.Text = pIE.NombreIngresoEgreso
    End Sub


    Public Function EsAreaValido() As Boolean
        Dim iAreRN As New AreaRN
        Dim iAreEN As New SuperEntidad
        iAreEN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iAreEN.CodigoArea = Me.TxtCodAre.Text.Trim
        iAreEN = iAreRN.EsAreaValido(iAreEN)
        If iAreEN.EsVerdad = False Then
            MsgBox(iAreEN.Mensaje, MsgBoxStyle.Exclamation, "Area")
            Me.TxtCodAre.Focus()
        End If
        Me.MostarArea(iAreEN)
        Return iAreEN.EsVerdad
    End Function


    Sub MostarArea(ByRef pAR As SuperEntidad)
        Me.TxtCodAre.Text = pAR.CodigoArea
        Me.TxtNomAre.Text = pAR.NombreArea
    End Sub


    Public Function EsGastoValido() As Boolean
        Dim iGasRRN As New GastoReparableRN
        Dim iGasREN As New SuperEntidad
        iGasREN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iGasREN.CodigoGastoReparable = ""
        iGasREN = iGasRRN.EsGastoReparableValido(iGasREN)
        If iGasREN.EsVerdad = False Then
            MsgBox(iGasREN.Mensaje, MsgBoxStyle.Exclamation, "Gasto")
            'Me.TxtCodGasRep.Focus()
        End If
        Me.MostarGasto(iGasREN)
        Return iGasREN.EsVerdad
    End Function


    Sub MostarGasto(ByRef pAR As SuperEntidad)
        ' Me.TxtCodGasRep.Text = pAR.CodigoGastoReparable
        ' Me.TxtNomGasRep.Text = pAR.NombreGastoReparable
    End Sub


#End Region

    Private Sub WEditarPptoInterno_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
        Me.wRegHon.btnAceptar.Focus()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If acc.CamposObligatorios = False Then
            Exit Sub
        Else
            Me.DeControlesAGrilla()
            Me.wRegHon.ImportesSolesDolares()
            If Me.Text = "Agregar Item" Then
                'If Me.txtCodProy.Text.Trim = "" Then
                '    Exit Sub
                'Else
                acc.LimpiarControles()
                Me.txtCodCuen.Focus()
                'End If
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
                        win.ctrlFoco = Me.txtImpSol
                    End If
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

    Private Sub txtCodie_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodie.KeyDown
        If Me.Text = "Agregar Item" Or Me.Text = "Modificar Item" Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarIngEgr
                win.titulo = "Ingresos & Egresos Activos"
                ' win.ent.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
                win.tabla = "IngresoEgreso"
                win.txt1 = Me.txtCodie
                win.txt2 = Me.txtNomIe
                win.ctrlFoco = Me.TxtCodAre
                win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub TxtCodAre_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodAre.KeyDown
        If Me.Text = "Agregar Item" Or Me.Text = "Modificar Item" Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarAreas
                win.titulo = "Areas Activos"
                ' win.ent.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
                win.tabla = "Area"
                win.txt1 = Me.TxtCodAre
                win.txt2 = Me.TxtNomAre
                win.ctrlFoco = Me.btnAgregar
                win.NuevaVentana()
            End If
        End If
    End Sub

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

    Private Sub txtCodie_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodie.Validating
        Me.EsIngresoEgresoValido()
    End Sub

    Private Sub TxtCodAre_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodAre.Validating
        Me.EsAreaValido()
    End Sub
#End Region

#Region "Calculos"
    Private Sub txtImpSol_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtImpSol.Validated
        Me.txtImpDol.Text = Varios.numeroConDosDecimal((CType(Me.txtImpSol.Text, Decimal) / CType(Me.wRegHon.txtTipCam.Text, Decimal)).ToString)
        Dim resta As Decimal = CType(Me.wRegHon.txtImpTotSol.Text, Decimal) - Me.wRegHon.sumaImportes

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

    Private Sub TxtCodRep_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If Me.Text = "Agregar Item" Or Me.Text = "Modificar Item" Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarGastoReparable
                win.titulo = "Gastos Activos"
                ' win.ent.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
                win.tabla = "GastoReparable"
                '  win.txt1 = ""
                ' win.txt2 = ""
                win.ctrlFoco = Me.btnAgregar
                win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub TxtCodGasRep_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Me.EsGastoValido()
    End Sub
End Class