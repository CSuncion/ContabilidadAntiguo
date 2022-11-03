Option Strict Off
Imports Entidad
Imports Negocio

Public Class WDetalleRegDiario

#Region "Propietarios"
    Public wRegDia As New WEditarRegistroDiario
#End Region

    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public ent, entpar As New SuperEntidad
    Public concepto As String = ""
    Public tab As New TablaRN
    Public cta As New PlanCuentaGeRN
    Public par As New ParametroRN
    Public cam As New CamposEntidad
    Public titulo As String
    Public ticEn As New SuperEntidad
    Public tic As New TipoCambioRN
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
        '   Me.Owner.Enabled = False
        Me.HabilitarSegunCuenta()
        ' Me.txtCodPro.ReadOnly = True
        '/por defecto
        Me.Show()
    End Sub

    Sub TraerTipoCambio()
        'traer tipo de cambio
        ticEn.DatoCondicion1 = Me.dtpFecha.Value.Year.ToString + "/" + Me.dtpFecha.Value.Month.ToString + "/" + Me.dtpFecha.Value.Day.ToString
        ticEn = tic.buscarTipoCambioExisPorFecha(ticEn)
        If ticEn.AnoTipoCambio = "" Then
            MsgBox("el tipo de cambio no existe", MsgBoxStyle.Information)
            Me.txtTipCam.Text = "1.000"
        Else
            Me.txtTipCam.Text = ticEn.VentaTipoCambio.ToString
        End If

    End Sub

    Sub mostrarFechaVoucher()
        If Me.wRegDia.txtFecVau.Text <> "" Then
            Me.dtpFecha.Text = Me.wRegDia.txtFecVau.Text
        End If
    End Sub

    Sub NuevaVentana()
        Me.InicializaVentana()
        Me.Text = "Agregar Item"
        acc.LimpiarControles()
        Me.mostrarFechaVoucher()
        Me.TraerTipoCambio()
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

        Dim indFil As Integer = Me.wRegDia.dgvRegDia.CurrentRow.Index
        If indFil = Me.wRegDia.dgvRegDia.Rows.Count - 1 Then
            Me.Close()
            Exit Sub

        Else

            Me.txtCodCuen.Text = Me.wRegDia.dgvRegDia.Item(0, indFil).Value.ToString
            Me.txtNomCue.Text = Me.wRegDia.dgvRegDia.Item(1, indFil).Value.ToString
            Me.txtCodAux.Text = Me.wRegDia.dgvRegDia.Item(2, indFil).Value.ToString
            Me.txtNomAux.Text = Me.wRegDia.dgvRegDia.Item(3, indFil).Value.ToString
            'haber debe
            Dim str As String = Me.wRegDia.dgvRegDia.Item(4, indFil).Value.ToString
            If str = "Haber" Then
                Me.rbtHaber.Checked = True
            Else
                Me.rbtDebe.Checked = True
            End If
            
            Me.txtDoc.Text = Me.wRegDia.dgvRegDia.Item(7, indFil).Value.ToString
            Me.txtNomDoc.Text = Me.wRegDia.dgvRegDia.Item(8, indFil).Value.ToString
            Me.txtSer.Text = Me.wRegDia.dgvRegDia.Item(9, indFil).Value.ToString
            Me.txtNum.Text = Me.wRegDia.dgvRegDia.Item(10, indFil).Value.ToString
            Me.dtpFecha.Text = Me.wRegDia.dgvRegDia.Item(11, indFil).Value.ToString
            Me.txtTipCam.Text = Me.wRegDia.dgvRegDia.Item(12, indFil).Value.ToString
            Me.txtCodIe.Text = Me.wRegDia.dgvRegDia.Item(13, indFil).Value.ToString
            Me.txtNomIe.Text = Me.wRegDia.dgvRegDia.Item(14, indFil).Value.ToString
            Me.txtGlosa.Text = Me.wRegDia.dgvRegDia.Item(15, indFil).Value.ToString
            Me.txtCenCto.Text = Me.wRegDia.dgvRegDia.Item(16, indFil).Value.ToString
            Me.txtNomCto.Text = Me.wRegDia.dgvRegDia.Item(17, indFil).Value.ToString
            Dim mon As String = Me.wRegDia.dgvRegDia.Item(18, indFil).Value.ToString
            Select Case mon
                Case "S/."
                    Me.rbtSol.Checked = True
                Case "US$"
                    Me.rbtDol.Checked = True
            End Select

            Me.TxtCodAre.Text = Me.wRegDia.dgvRegDia.Item(19, indFil).Value.ToString
            Me.TxtNomAre.Text = Me.wRegDia.dgvRegDia.Item(20, indFil).Value.ToString
            Me.TxtCodGasRep.Text = Me.wRegDia.dgvRegDia.Item(28, indFil).Value.ToString
            Me.TxtNomGasRep.Text = Me.wRegDia.dgvRegDia.Item(29, indFil).Value.ToString

            Me.txtImpSol.Text = Me.wRegDia.dgvRegDia.Item(5, indFil).Value.ToString
            Me.txtImpDol.Text = Me.wRegDia.dgvRegDia.Item(6, indFil).Value.ToString
        End If

    End Sub


    Sub DeControlesAGrilla()
        Dim indiceFila As Integer


        Select Case Me.Text

            Case "Agregar Item"

                Me.wRegDia.dgvRegDia.Rows.Add()

                indiceFila = Me.wRegDia.dgvRegDia.Rows.Count - 2

            Case "Modificar Item"
                indiceFila = Me.wRegDia.dgvRegDia.CurrentRow.Index

            Case "Eliminar Item"
                Dim rpta As Integer = MsgBox("Deseas eliminar el item", MsgBoxStyle.YesNo)
                If rpta = MsgBoxResult.Yes Then
                    MsgBox("Item eliminado")
                    indiceFila = Me.wRegDia.dgvRegDia.CurrentRow.Index
                    Me.wRegDia.dgvRegDia.Rows.RemoveAt(indiceFila)
                    Me.Close()
                    Exit Sub
                Else
                    Me.Close()
                    Exit Sub
                End If


        End Select

        Me.wRegDia.dgvRegDia.Rows(indiceFila).Cells(0).Value = Me.txtCodCuen.Text.Trim
        Me.wRegDia.dgvRegDia.Rows(indiceFila).Cells(1).Value = Me.txtNomCue.Text.Trim
        Me.wRegDia.dgvRegDia.Rows(indiceFila).Cells(2).Value = Me.txtCodAux.Text.Trim
        Me.wRegDia.dgvRegDia.Rows(indiceFila).Cells(3).Value = Me.txtNomAux.Text.Trim
        Dim str As String = Rbt.radioActivo(Me.gbDebeHaber).Text
        Me.wRegDia.dgvRegDia.Rows(indiceFila).Cells(4).Value = str
        Me.wRegDia.dgvRegDia.Rows(indiceFila).Cells(5).Value = Me.txtImpSol.Text.Trim
        Me.wRegDia.dgvRegDia.Rows(indiceFila).Cells(6).Value = Me.txtImpDol.Text.Trim
        Me.wRegDia.dgvRegDia.Rows(indiceFila).Cells(7).Value = Me.txtDoc.Text.Trim
        Me.wRegDia.dgvRegDia.Rows(indiceFila).Cells(8).Value = Me.txtNomDoc.Text.Trim
        Me.wRegDia.dgvRegDia.Rows(indiceFila).Cells(9).Value = Me.txtSer.Text.Trim
        Me.wRegDia.dgvRegDia.Rows(indiceFila).Cells(10).Value = Me.txtNum.Text.Trim
        Me.wRegDia.dgvRegDia.Rows(indiceFila).Cells(11).Value = Me.dtpFecha.Text.Trim
        Me.wRegDia.dgvRegDia.Rows(indiceFila).Cells(12).Value = Me.txtTipCam.Text.Trim
        Me.wRegDia.dgvRegDia.Rows(indiceFila).Cells(13).Value = Me.txtCodIe.Text.Trim
        Me.wRegDia.dgvRegDia.Rows(indiceFila).Cells(14).Value = Me.txtNomIe.Text.Trim
        Me.wRegDia.dgvRegDia.Rows(indiceFila).Cells(15).Value = Me.txtGlosa.Text.Trim
        Me.wRegDia.dgvRegDia.Rows(indiceFila).Cells(16).Value = Me.txtCenCto.Text.Trim
        Me.wRegDia.dgvRegDia.Rows(indiceFila).Cells(17).Value = Me.txtNomCto.Text.Trim
        Dim mon As String = Rbt.radioActivo(Me.gbMoneda).Text
        Me.wRegDia.dgvRegDia.Rows(indiceFila).Cells(18).Value = mon
        Me.wRegDia.dgvRegDia.Rows(indiceFila).Cells(19).Value = Me.TxtCodAre.Text.Trim
        Me.wRegDia.dgvRegDia.Rows(indiceFila).Cells(20).Value = Me.TxtNomAre.Text.Trim
        Me.wRegDia.dgvRegDia.Rows(indiceFila).Cells(21).Value = ""
        Me.wRegDia.dgvRegDia.Rows(indiceFila).Cells(22).Value = ""
        Me.wRegDia.dgvRegDia.Rows(indiceFila).Cells(23).Value = ""
        Me.wRegDia.dgvRegDia.Rows(indiceFila).Cells(24).Value = ""
        Me.wRegDia.dgvRegDia.Rows(indiceFila).Cells(25).Value = ""
        Me.wRegDia.dgvRegDia.Rows(indiceFila).Cells(26).Value = ""
        Me.wRegDia.dgvRegDia.Rows(indiceFila).Cells(27).Value = ""
        Me.wRegDia.dgvRegDia.Rows(indiceFila).Cells(28).Value = Me.TxtCodGasRep.Text.Trim
        Me.wRegDia.dgvRegDia.Rows(indiceFila).Cells(29).Value = Me.TxtNomGasRep.Text.Trim
        Me.wRegDia.dgvRegDia.Rows(indiceFila).Cells(30).Value = Me.TxtCantidad.Text.Trim


    End Sub

    Sub CalcularImporteSegunMoneda()

        If Me.rbtSol.Checked = True Or Me.rbtDol.Checked = True Then
            Dim impsol As Decimal = CType(Me.txtImpSol.Text, Decimal)
            Dim impdol As Decimal = CType(Me.txtImpDol.Text, Decimal)
            Dim tc As Decimal = CType(Me.txtTipCam.Text, Decimal)

            Dim Auto As String = Rbt.radioActivo(Me.gbMoneda).Text
            Select Case Auto
                Case "S/."
                    If tc <> 0 Then
                        Me.txtImpDol.Text = Varios.numeroConDosDecimal((impsol / tc).ToString)
                    End If
                Case "US$"
                    Me.txtImpSol.Text = Varios.numeroConDosDecimal((impdol * tc).ToString)

            End Select
        End If

    End Sub

    Sub CalcularSegunTextBoxMonto(ByRef pTxt As TextBox)
        If Me.rbtSol.Checked = True Or Me.rbtDol.Checked = True Then
            Dim Auto As String = Rbt.radioActivo(Me.gbMoneda).Text
            Select Case Auto
                Case "S/."
                    If pTxt.Name = "txtImpSol" Then
                        Me.CalcularImporteSegunMoneda()
                    End If
                Case "US$"
                    If pTxt.Name = "txtImpDol" Then
                        Me.CalcularImporteSegunMoneda()
                    End If

            End Select
        End If



    End Sub

    Function EsValidoCodigoAuxiliar() As Boolean
        If Me.txtCodAux.Enabled = True Then
            If Me.txtCodAux.Text = "" Then
                MsgBox("Debe Registrar Codigo Auxiliar", MsgBoxStyle.Exclamation, "Auxiliares")
                Me.txtCodAux.Focus()
                Return False
            End If
        End If
        Return True
    End Function

#End Region


    Private Sub WEditarPptoInterno_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
        Me.wRegDia.btnAceptar.Focus()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If acc.CamposObligatorios = False Then
            Exit Sub
        Else
            'validar cuenta documento
            If Me.ValidaCuandoNoEsCuentaDocumento = False Then Exit Sub

            Me.DeControlesAGrilla()
            Me.wRegDia.ImportesDebeHaber()
            'Me.wRegGas.ImportesSolesDolares()
            If Me.Text = "Agregar Item" Then
                'If Me.txtCodProy.Text.Trim = "" Then
                '    Exit Sub
                'Else
                acc.LimpiarControles()
                Me.mostrarFechaVoucher()
                Me.txtCodCuen.Focus()
                'End If
            End If
            If Me.Text = "Modificar Item" Then
                Me.Close()
            End If

            ' ''Validar CodigoAuxiliar
            'If Me.Text = "Agregar Item" Or Me.Text = "Modificar Item" Then
            '    If Me.EsValidoCodigoAuxiliar = False Then Exit Sub
            'End If

            'Me.DeControlesAGrilla()
            'Me.wRegDia.ImportesDebeHaber()
            ''Me.wRegGas.ImportesSolesDolares()
            'If Me.Text = "Agregar Item" Then
            '    'If Me.txtCodProy.Text.Trim = "" Then
            '    '    Exit Sub
            '    'Else
            '    acc.LimpiarControles()
            '    Me.mostrarFechaVoucher()
            '    Me.txtCodCuen.Focus()
            '    'End If
            'End If
            'If Me.Text = "Modificar Item" Then
            '    Me.Close()
            'End If

        End If

    End Sub

    Private Sub dtpFecha_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpFecha.Validating
        Me.TraerTipoCambio()
        Me.txtImpDol.Text = Varios.numeroConDosDecimal((CType(Me.txtImpSol.Text, Decimal) / CType(Me.txtTipCam.Text, Decimal)).ToString)
        'Me.ImportesSolesDolares()
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

    Public Function EsGastoReparableValido() As Boolean
        Dim iGasRRN As New GastoReparableRN
        Dim iGasREN As New SuperEntidad
        iGasREN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iGasREN.CodigoGastoReparable = Me.TxtCodGasRep.Text.Trim
        iGasREN = iGasRRN.EsGastoReparableValido(iGasREN)
        If iGasREN.EsVerdad = False Then
            MsgBox(iGasREN.Mensaje, MsgBoxStyle.Exclamation, "Gasto")
            Me.TxtCodGasRep.Focus()
        End If
        Me.MostarGastoReparable(iGasREN)
        Return iGasREN.EsVerdad
    End Function


    Sub MostarGastoReparable(ByRef pAR As SuperEntidad)
        Me.TxtCodGasRep.Text = pAR.CodigoGastoReparable
        Me.TxtNomGasRep.Text = pAR.NombreGastoReparable
    End Sub


    Function ValidaCuandoNoEsCuentaDocumento() As Boolean

        'asignar parametros
        Dim iCueCorEN As New SuperEntidad
        iCueCorEN.CodigoAuxiliar = Me.txtCodAux.Text
        iCueCorEN.TipoDocumento = Me.TxtDoc.Text
        iCueCorEN.SerieDocumento = Me.TxtSer.Text
        iCueCorEN.NumeroDocumento = Me.txtNum.Text
        iCueCorEN.CodigoCuentaPcge = Me.txtCodCuen.Text

        'ejecutar metodo
        Dim iCueCorRN As New CuentaCorrienteRN
        iCueCorEN = iCueCorRN.ValidaCuandoNoEsCuentaDocumento(iCueCorEN)

        'mensaje error
        If iCueCorEN.EsVerdad = False Then
            MsgBox(iCueCorEN.Mensaje, MsgBoxStyle.Exclamation, "Cuenta")
            Me.txtCodCuen.Focus()
        End If

        'devolver
        Return iCueCorEN.EsVerdad

    End Function



#Region "Mostrar Formulario lista"

    Private Sub txtCodCue_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodCuen.KeyDown
        If Me.Text = "Agregar Item" Or Me.Text = "Modificar Item" Then
            If Me.txtCodCuen.ReadOnly = False Then
                If e.KeyCode = Keys.F1 Then
                    Dim win As New WListarPlanCuentaGe
                    win.tabla = "CuentasAnaliticas"
                    win.titulo = "Cuentas"
                    win.txt1 = Me.txtCodCuen
                    win.txt2 = Me.txtNomCue
                    If Me.txtCodAux.Enabled = True Then
                        win.ctrlFoco = Me.txtCodAux
                    Else
                        Me.txtCodAux.Text = ""
                        Me.txtNomAux.Text = ""
                        win.ctrlFoco = Me.gbDebeHaber
                    End If
                    win.NuevaVentana()
                End If
                If e.KeyCode = Keys.Escape Then
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub txtCodAux_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodAux.KeyDown
        If Me.txtCodAux.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarAuxiliar
                win.wEditRegDiaDet = Me
                Me.AddOwnedForm(win)
                win.tabla = "Todos"
                win.titulo = "Auxiliares"
                win.txt1 = Me.txtCodAux
                win.txt2 = Me.txtNomAux
                win.ctrlFoco = Me.btnDocu
                win.NuevaVentana()
            End If
        End If

    End Sub

    Private Sub txtCencto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCenCto.KeyDown
        If Me.Text = "Agregar Item" Or Me.Text = "Modificar Item" Then
            If Me.txtCenCto.ReadOnly = False Then
                If e.KeyCode = Keys.F1 Then
                    Dim win As New WListarCentroCostos
                    win.titulo = "Centro Costos Activos"
                    ' win.ent.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
                    win.tabla = "CentroCosto"
                    win.txt1 = Me.txtCenCto
                    win.txt2 = Me.txtNomCto
                    win.ctrlFoco = Me.txtDoc
                    win.NuevaVentana()

                  
                End If
            End If
        End If
    End Sub

    Private Sub txtTipDoc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDoc.KeyDown
        If Me.Text = "Agregar Item" Or Me.Text = "Modificar Item" Then
            If Me.txtDoc.ReadOnly = False Then
                If e.KeyCode = Keys.F1 Then
                    Dim win As New WListarTabla
                    win.tabla = "Documento"
                    win.titulo = "Documentos"
                    win.txt1 = Me.txtDoc
                    win.txt2 = Me.txtNomDoc
                    win.ctrlFoco = Me.txtSer
                    win.NuevaVentana()
                End If
            End If
        End If
    End Sub

    Private Sub txtCodIe_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodIe.KeyDown
        If Me.Text = "Agregar Item" Or Me.Text = "Modificar Item" Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarIngEgr
                win.titulo = "Ingresos & Egresos Activos"
                ' win.ent.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
                win.tabla = "IngresoEgreso"
                win.txt1 = Me.txtCodIe
                win.txt2 = Me.txtNomIe
                win.ctrlFoco = Me.txtGlosa
                win.NuevaVentana()

                'Dim win As New WListarTabla
                'win.tabla = "Ingresos/Egresos"
                'win.titulo = "Ingresos/Egresos"
                'win.txt1 = Me.txtCodIe
                'win.txt2 = Me.txtNomIe
                'win.ctrlFoco = Me.txtGlosa
                'win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub TxtCodAre_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodAre.KeyDown
        If Me.Text = "Agregar Item" Or Me.Text = "Modificar Item" Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarAreas
                win.titulo = "Areas Activas"
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
            'If Me.wRegDia.txtCodFil.Text = "390" Then
            '    ope.Condicion = "CuentasAnaliticas"
            'Else
            '    ope.Condicion = "CuentasAnaliticasNoBancarias"
            'End If

            'If Me.wRegDia.txtPeri.Text.Substring(4, 2) = "00" Then
            '    ope.Condicion = "CuentasAnaliticas"
            'Else
            '    If Me.wRegDia.txtCodFil.Text = "390" Then
            '        ope.Condicion = "CuentasAnaliticas"
            '    Else
            '        ope.Condicion = "CuentasAnaliticasNoBancarias"
            '    End If

            'End If

            ''    ope.Condicion = "CuentasAnaliticas"

            ope.Condicion = "CuentasAnaliticas"
            ope.MostrarCodigoDescripcionDePlancuentas("CuentasAnaliticas", e)
            Me.HabilitarSegunCuenta()

        End If
    End Sub

    Private Sub txtCodAux_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodAux.Validating
        If Me.Text = "Agregar Item" Or Me.Text = "Modificar Item" Then
            Dim ope As New OperaWin : ope.txt1 = Me.txtCodAux : ope.txt2 = Me.txtNomAux
            ope.MostrarCodigoDescripcionDeAuxiliar("Todos", "Auxiliares", e)
        End If
    End Sub

    Private Sub txtCenCto_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCenCto.Validating
        Me.EsCentroCostoValido()
        'If Me.Text = "Agregar Item" Or Me.Text = "Modificar Item" Then
        '    Dim ope As New OperaWin : ope.txt1 = Me.txtCenCto : ope.txt2 = Me.txtNomCto
        '    ope.MostrarCodigoDescripcionDeTabla("Cto", "Centro Costo", e)
        'End If
    End Sub

    Private Sub txtDoc_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDoc.Validating
        If Me.Text = "Agregar Item" Or Me.Text = "Modificar Item" Then
            Dim ope As New OperaWin : ope.txt1 = Me.txtDoc : ope.txt2 = Me.txtNomDoc
            ope.MostrarCodigoDescripcionDeTabla("Doc", "Documento", e)
        End If
    End Sub

    Private Sub txtCodIe_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodIe.Validating
        Me.EsIngresoEgresoValido()
        'If Me.Text = "Agregar Item" Or Me.Text = "Modificar Item" Then
        '    Dim ope As New OperaWin : ope.txt1 = Me.txtCodIe : ope.txt2 = Me.txtNomIe
        '    ope.MostrarCodigoDescripcionDeTabla("Ies", "Ingresos/Egresos", e)
        'End If
    End Sub

    Private Sub TxtCodAre_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodAre.Validating
        Me.EsAreaValido()
    End Sub


#End Region


#Region "Calculos"
    Private Sub txtImpSol_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtImpSol.Validated
        'Me.txtImpDol.Text = Varios.numeroConDosDecimal((CType(Me.txtImpSol.Text, Decimal) / CType(Me.txtTipCam.Text, Decimal)).ToString)
        Me.CalcularSegunTextBoxMonto(Me.txtImpSol)
    End Sub

    Sub HabilitarSegunCuenta()

        Me.txtCodAux.Enabled = False
        Me.txtCenCto.Enabled = False
        Me.txtDoc.Enabled = False
        Me.TxtCodGasRep.Enabled = False
        '   Me.TxtCantidad.Enabled = False

        Dim ocue As New SuperEntidad
        ocue.ClaveCuentaPcge = SuperEntidad.xCodigoEmpresa + Me.txtCodCuen.Text.Trim
        ocue.NumeroDigitosPcge = entpar.DigitosCuentaAnalitica
        ocue = cta.buscarCuentaExisPorClaveyAnalitica(ocue)

        Me.txtCodAux.Enabled = CBool(IIf(ocue.FlagAuxiliarPcge = "Si", True, False))
        Me.txtCenCto.Enabled = CBool(IIf(ocue.FlagCentroCostoPcge = "Si", True, False))
        Me.txtDoc.Enabled = CBool(IIf(ocue.FlagDocumentoPcge = "Si", True, False))
        Me.TxtCodGasRep.Enabled = CBool(IIf(ocue.FlagDocumentoPcge = "Si", True, False))

        If ocue.FlagAuxiliarPcge = "Si" Then
            Me.txtCodAux.Enabled = True
            Me.txtCodAux.Focus()
        Else
            Me.txtCodAux.Enabled = False
            Me.txtCodAux.Text = ""
            Me.txtNomAux.Text = ""
            If ocue.FlagCentroCostoPcge = "Si" Then
                Me.txtCenCto.Enabled = True
                Me.txtCenCto.Focus()
            Else
                Me.txtCenCto.Text = ""
                Me.txtNomCto.Text = ""
                If ocue.FlagDocumentoPcge = "Si" Then
                    Me.txtDoc.Enabled = True
                    Me.txtDoc.Focus()
                Else
                    If ocue.FlagAlmacenPcge = "Si" Then
                        Me.TxtCodGasRep.Enabled = True
                        Me.TxtCantidad.Enabled = True
                        Me.txtDoc.Focus()
                    Else
                        Me.gbDebeHaber.Focus()
                    End If
                    '   Me.rbtDebe.Checked() = True
                End If
            End If
        End If

    End Sub

#End Region


   
    Private Sub rbtSol_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSol.CheckedChanged
        Me.CalcularImporteSegunMoneda()
    End Sub

    Private Sub rbtDol_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtDol.CheckedChanged
        Me.CalcularImporteSegunMoneda()
    End Sub


    Private Sub txtImpDol_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtImpDol.Validated
        Me.CalcularSegunTextBoxMonto(Me.txtImpDol)
    End Sub

    Private Sub btnDocu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDocu.Click
        If Me.txtCodAux.Text.Trim <> "" Then
            Dim win As New WListarCuentaCorriente
            win.tabla = "CuentaCorriente"
            win.titulo = "Cuenta Corriente"
            win.codaux = Me.txtCodAux.Text.Trim
            win.txtBus.Focus()
            win.txt10 = Me.txtNomDoc
            win.txt2 = Me.txtDoc
            win.txt3 = Me.txtSer
            win.txt4 = Me.txtNum
            win.dtp1 = Me.dtpFecha
            win.grup = Me.gbMoneda
            win.txt7 = Me.txtTipCam
            win.txt5 = Me.txtImpSol
            win.txt9 = Me.txtImpDol
            win.ctrlFoco = Me.gbDebeHaber
            win.NuevaVentana()
        End If
    End Sub

    Private Sub TxtCodGasRep_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodGasRep.KeyDown
        If Me.Text = "Agregar Item" Or Me.Text = "Modificar Item" Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarGastoReparable
                win.titulo = "Codigo Almacen"
                win.tabla = "CodigoAlmacen"
                win.txt1 = Me.TxtCodGasRep
                win.txt2 = Me.TxtNomGasRep
                win.ctrlFoco = Me.TxtCantidad
                win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub TxtCodGasRep_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodGasRep.Validating
        Me.EsGastoReparableValido()
    End Sub
End Class