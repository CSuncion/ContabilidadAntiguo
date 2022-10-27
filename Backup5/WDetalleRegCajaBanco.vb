Option Strict Off
Imports Entidad
Imports Negocio

Public Class WDetalleRegCajaBanco

#Region "Propietarios"
    Public wRegCbco As New WEditarRegistroCajaBanco
#End Region

    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public ent, entpar As New SuperEntidad
    Public concepto As String = ""
    Public tab As New TablaRN
    Public tic As New TipoCambioRN
    Public ccte As New CuentaCorrienteRN
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
        Me.HabilitarSegunCuenta()
        ' Me.txtCodPro.ReadOnly = True
        '/por defecto
        Me.Show()
    End Sub

    Sub HabilitarDebeHaber()
        If Me.wRegCbco.txtCodOri.Text.Trim = "1" Then
          
            Me.rbtHaber.Checked = True
        Else
          
            Me.rbtDebe.Checked = True
        End If
    End Sub

    Sub NuevaVentana()
        Me.InicializaVentana()
        Me.Text = "Agregar Item"
        acc.LimpiarControles()
        Me.txtCodCuen.Focus()
        acc.Nuevo()
        Me.HabilitarDebeHaber()
    End Sub

    Sub ModificarVentana()
        Me.InicializaVentana()
        Me.Text = "Modificar Item"
        Me.DeGrillaAControles()
        Me.txtCodAux.Focus()
        acc.Modificar()
        Me.HabilitarDebeHaber()
    End Sub

    Sub EliminaVentana()
        'Me.Show()
        Me.InicializaVentana()
        Me.Text = "Eliminar Item"
        Me.DeGrillaAControles()
        acc.Eliminar()
        Me.HabilitarDebeHaber()
    End Sub

    Sub DeGrillaAControles()

        Dim indFil As Integer = Me.wRegCbco.DgvRegCbco.CurrentRow.Index
        If indFil = Me.wRegCbco.DgvRegCbco.Rows.Count - 1 Then
            Me.Close()
            Exit Sub
        Else
            Me.txtCodCuen.Text = Me.wRegCbco.DgvRegCbco.Item(0, indFil).Value.ToString
            Me.txtNomCue.Text = Me.wRegCbco.DgvRegCbco.Item(1, indFil).Value.ToString
            Me.txtCodAux.Text = Me.wRegCbco.DgvRegCbco.Item(2, indFil).Value.ToString
            Me.txtNomAux.Text = Me.wRegCbco.DgvRegCbco.Item(3, indFil).Value.ToString
            'haber debe
            Dim str As String = Me.wRegCbco.DgvRegCbco.Item(4, indFil).Value.ToString
            If str = "Haber" Then
                Me.rbtHaber.Checked = True
            Else
                Me.rbtDebe.Checked = True
            End If
            Me.txtImpSol.Text = Me.wRegCbco.DgvRegCbco.Item(5, indFil).Value.ToString
            Me.txtImpDol.Text = Me.wRegCbco.DgvRegCbco.Item(6, indFil).Value.ToString
            Me.TxtImpEur.Text = Me.wRegCbco.DgvRegCbco.Item(7, indFil).Value.ToString
            Me.TxtDoc.Text = Me.wRegCbco.DgvRegCbco.Item(8, indFil).Value.ToString
            Me.TxtNomDoc.Text = Me.wRegCbco.DgvRegCbco.Item(9, indFil).Value.ToString
            Me.TxtSer.Text = Me.wRegCbco.DgvRegCbco.Item(10, indFil).Value.ToString
            Me.txtNum.Text = Me.wRegCbco.DgvRegCbco.Item(11, indFil).Value.ToString
            Me.dtpFecha.Text = Me.wRegCbco.DgvRegCbco.Item(12, indFil).Value.ToString
            Me.txtCodIe.Text = Me.wRegCbco.DgvRegCbco.Item(13, indFil).Value.ToString
            Me.txtNomIe.Text = Me.wRegCbco.DgvRegCbco.Item(14, indFil).Value.ToString
            Me.txtGlosa.Text = Me.wRegCbco.DgvRegCbco.Item(15, indFil).Value.ToString
            Me.txtCenCto.Text = Me.wRegCbco.DgvRegCbco.Item(16, indFil).Value.ToString
            Me.txtNomCto.Text = Me.wRegCbco.DgvRegCbco.Item(17, indFil).Value.ToString
            Me.txtTipCam.Text = Me.wRegCbco.DgvRegCbco.Item(18, indFil).Value.ToString
            Me.TxtTipcam1.Text = Me.wRegCbco.DgvRegCbco.Item(19, indFil).Value.ToString
            Dim mon As String = Me.wRegCbco.DgvRegCbco.Item(21, indFil).Value.ToString
            Select Case mon
                Case "S/."
                    Me.rbtSol.Checked = True
                Case "US$"
                    Me.rbtDol.Checked = True
                Case "EUR"
                    Me.RbtEur.Checked = True
            End Select
            Me.TxtCodAre.Text = Me.wRegCbco.DgvRegCbco.Item(24, indFil).Value.ToString
            Me.TxtNomAre.Text = Me.wRegCbco.DgvRegCbco.Item(25, indFil).Value.ToString
            Me.TxtCodFluCaj.Text = Me.wRegCbco.DgvRegCbco.Item(26, indFil).Value.ToString
            Me.TxtNomFluCaj.Text = Me.wRegCbco.DgvRegCbco.Item(27, indFil).Value.ToString
        End If

    End Sub

    Sub DeControlesAGrilla()
        Dim indiceFila As Integer

        Select Case Me.Text

            Case "Agregar Item"

                Me.wRegCbco.DgvRegCbco.Rows.Add()

                indiceFila = Me.wRegCbco.DgvRegCbco.Rows.Count - 2

            Case "Modificar Item"
                indiceFila = Me.wRegCbco.DgvRegCbco.CurrentRow.Index

            Case "Eliminar Item"
                Dim rpta As Integer = MsgBox("Deseas eliminar el item", MsgBoxStyle.YesNo)
                If rpta = MsgBoxResult.Yes Then
                    MsgBox("Item eliminado")
                    indiceFila = Me.wRegCbco.DgvRegCbco.CurrentRow.Index
                    Me.wRegCbco.DgvRegCbco.Rows.RemoveAt(indiceFila)
                    Me.Close()
                    Exit Sub
                Else
                    Me.Close()
                    Exit Sub
                End If

        End Select

        Me.wRegCbco.DgvRegCbco.Rows(indiceFila).Cells(0).Value = Me.txtCodCuen.Text.Trim
        Me.wRegCbco.DgvRegCbco.Rows(indiceFila).Cells(1).Value = Me.txtNomCue.Text.Trim
        Me.wRegCbco.DgvRegCbco.Rows(indiceFila).Cells(2).Value = Me.txtCodAux.Text.Trim
        Me.wRegCbco.DgvRegCbco.Rows(indiceFila).Cells(3).Value = Me.txtNomAux.Text.Trim
        Dim str As String = Rbt.radioActivo(Me.gbDebeHaber).Text
        Me.wRegCbco.DgvRegCbco.Rows(indiceFila).Cells(4).Value = str
        Me.wRegCbco.DgvRegCbco.Rows(indiceFila).Cells(5).Value = Me.txtImpSol.Text.Trim
        Me.wRegCbco.DgvRegCbco.Rows(indiceFila).Cells(6).Value = Me.txtImpDol.Text.Trim
        Me.wRegCbco.DgvRegCbco.Rows(indiceFila).Cells(7).Value = Me.TxtImpEur.Text.Trim

        Me.wRegCbco.DgvRegCbco.Rows(indiceFila).Cells(8).Value = Me.TxtDoc.Text.Trim
        Me.wRegCbco.DgvRegCbco.Rows(indiceFila).Cells(9).Value = Me.TxtNomDoc.Text.Trim
        Me.wRegCbco.DgvRegCbco.Rows(indiceFila).Cells(10).Value = Me.TxtSer.Text.Trim
        Me.wRegCbco.DgvRegCbco.Rows(indiceFila).Cells(11).Value = Me.txtNum.Text.Trim
        Me.wRegCbco.DgvRegCbco.Rows(indiceFila).Cells(12).Value = Me.dtpFecha.Text.Trim
        Me.wRegCbco.DgvRegCbco.Rows(indiceFila).Cells(13).Value = Me.txtCodIe.Text.Trim
        Me.wRegCbco.DgvRegCbco.Rows(indiceFila).Cells(14).Value = Me.txtNomIe.Text.Trim
        Me.wRegCbco.DgvRegCbco.Rows(indiceFila).Cells(15).Value = Me.txtGlosa.Text.Trim
        Me.wRegCbco.DgvRegCbco.Rows(indiceFila).Cells(16).Value = Me.txtCenCto.Text.Trim
        Me.wRegCbco.DgvRegCbco.Rows(indiceFila).Cells(17).Value = Me.txtNomCto.Text.Trim
        Me.wRegCbco.DgvRegCbco.Rows(indiceFila).Cells(18).Value = Me.txtTipCam.Text.Trim
        Me.wRegCbco.DgvRegCbco.Rows(indiceFila).Cells(19).Value = Me.TxtTipcam1.Text.Trim
        Dim mon As String = Rbt.radioActivo(Me.gbMoneda).Text
        Me.wRegCbco.DgvRegCbco.Rows(indiceFila).Cells(21).Value = mon

        Me.wRegCbco.DgvRegCbco.Rows(indiceFila).Cells(24).Value = Me.TxtCodAre.Text.Trim
        Me.wRegCbco.DgvRegCbco.Rows(indiceFila).Cells(25).Value = Me.TxtNomAre.Text.Trim
        Me.wRegCbco.DgvRegCbco.Rows(indiceFila).Cells(26).Value = Me.TxtCodFluCaj.Text.Trim
        Me.wRegCbco.DgvRegCbco.Rows(indiceFila).Cells(27).Value = Me.TxtNomFluCaj.Text.Trim

        'MONTO MONEDA Y MONTO SOLES
        Dim iMontoMoneda As String = ""
        Dim iMontoSoles As String = ""

        'OBTENER LA MONEDA DE LA CABECERA CAJA Y BANCOS
        Dim iMonedaCb As String = Rbt.radioActivo(Me.wRegCbco.gbMoneda).Text
        'OBTENER LA MONEDA DEL DOCUMENTO
        Dim iMonedaDcto As String = Rbt.radioActivo(Me.gbMoneda).Text

        'OBTENER TIPOS DE CAMBIO DE LA CABECERA
        Dim iTcDol As Decimal = CType(Me.wRegCbco.txtTipCam.Text, Decimal)
        Dim iTcEur As Decimal = CType(Me.wRegCbco.txtTipCam1.Text, Decimal)

        Select Case iMonedaCb

            Case "S/."

                Select Case iMonedaDcto

                    Case "S/."
                        iMontoMoneda = Me.txtImpSol.Text
                        iMontoSoles = Me.txtImpSol.Text

                    Case "US$"
                        iMontoMoneda = Varios.numeroConDosDecimal((CType(Me.txtImpDol.Text, Decimal) * iTcDol).ToString)
                        iMontoSoles = iMontoMoneda

                    Case "EUR"
                        iMontoMoneda = Varios.numeroConDosDecimal((CType(Me.TxtImpEur.Text, Decimal) * iTcEur).ToString)
                        iMontoSoles = iMontoMoneda

                End Select

            Case "US$"

                Select Case iMonedaDcto

                    Case "S/."
                        iMontoMoneda = Varios.numeroConDosDecimal((CType(Me.txtImpSol.Text, Decimal) / iTcDol).ToString)
                        iMontoSoles = Me.txtImpSol.Text

                    Case "US$"
                        iMontoMoneda = Me.txtImpDol.Text
                        iMontoSoles = Varios.numeroConDosDecimal((CType(Me.txtImpDol.Text, Decimal) * iTcDol).ToString)

                    Case "EUR"
                        iMontoMoneda = "1"
                        iMontoSoles = "1"

                End Select

            Case "EUR"

                Select Case iMonedaDcto

                    Case "S/."
                        iMontoMoneda = Varios.numeroConDosDecimal((CType(Me.txtImpSol.Text, Decimal) / iTcEur).ToString)
                        iMontoSoles = Me.txtImpSol.Text

                    Case "US$"
                        iMontoMoneda = "1"
                        iMontoSoles = "1"

                    Case "EUR"
                        iMontoMoneda = Me.TxtImpEur.Text
                        iMontoSoles = Varios.numeroConDosDecimal((CType(Me.TxtImpEur.Text, Decimal) * iTcEur).ToString)

                End Select



        End Select

        Me.wRegCbco.DgvRegCbco.Rows(indiceFila).Cells(22).Value = iMontoMoneda
        Me.wRegCbco.DgvRegCbco.Rows(indiceFila).Cells(23).Value = iMontoSoles




    End Sub

    Sub ListarDocumentosPendientes()

        Dim liscc As New List(Of SuperEntidad)
        Dim obj As New SuperEntidad
        obj.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        obj.CodigoAuxiliar = Me.txtCodAux.Text.Trim
        liscc = ccte.obtenerCuentaCorrienteExisXEmpresaXAuxiliarYPendientes(obj)
        If liscc.Count = 0 Then
            Me.txtCenCto.Text = ""
            Me.txtNomCto.Text = ""
            Me.TxtSer.Text = ""
            Me.txtNum.Text = ""
            Me.gbDebeHaber.Focus()
        Else
            Dim win As New WListarCuentaCorriente
            win.tabla = "CuentaCorriente"
            win.titulo = "CuentaCorriente"
            win.txt1 = Me.txtCenCto
            win.txt2 = Me.TxtSer
            win.txt3 = Me.txtNum
            win.dtp1 = Me.dtpFecha
            win.txt4 = Me.txtNomCto
            win.txt5 = Me.txtImpSol

            win.ctrlFoco = Me.btnAgregar
            win.NuevaVentana()

        End If
    End Sub

    Function EsImporteEnCero() As Boolean
        Dim iMonedaDcto As String = Rbt.radioActivo(Me.gbMoneda).Text
        Select Case iMonedaDcto

            Case "S/."
                If Me.txtImpSol.Text = "0.00" Then
                    MsgBox("El importe en soles no puede ser cero", MsgBoxStyle.Exclamation, "Caja y bancos")
                    Me.txtImpSol.Focus()
                    Return False
                End If

            Case "US$"
                If Me.txtImpDol.Text = "0.00" Then
                    MsgBox("El importe en dolares no puede ser cero", MsgBoxStyle.Exclamation, "Caja y bancos")
                    Me.txtImpDol.Focus()
                    Return False
                End If

            Case "EUR"
                If Me.TxtImpEur.Text = "0.00" Then
                    MsgBox("El importe en euros no puede ser cero", MsgBoxStyle.Exclamation, "Caja y bancos")
                    Me.TxtImpEur.Focus()
                    Return False
                End If

        End Select
        Return True
    End Function

    Public Function EsCentroCostoValido() As Boolean
        Dim iCCosRN As New CentroCostoRN
        Dim iCCosEN As New SuperEntidad
        iCCosEN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iCCosEN.CodigoCentroCosto = Me.txtCenCto.Text.Trim
        iCCosEN = iCCosRN.EsCentroCostoValido(iCCosEN)
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

    Public Function EsFlujoCajaValido() As Boolean
        Dim iFluCRN As New FlujoCajaRN
        Dim iFluCEN As New SuperEntidad
        iFluCEN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iFluCEN.CodigoFlujoCaja = Me.TxtCodFluCaj.Text.Trim
        iFluCEN = iFluCRN.EsFlujoCajaValido(iFluCEN)
        If iFluCEN.EsVerdad = False Then
            MsgBox(iFluCEN.Mensaje, MsgBoxStyle.Exclamation, "FlujoCaja")
            Me.TxtCodFluCaj.Focus()
        End If
        Me.MostarFlujoCaja(iFluCEN)
        Return iFluCEN.EsVerdad
    End Function


    Sub MostarFlujoCaja(ByRef pAR As SuperEntidad)
        Me.TxtCodFluCaj.Text = pAR.CodigoFlujoCaja
        Me.TxtNomFluCaj.Text = pAR.NombreFlujoCaja
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



#End Region

    Private Sub WEditarPptoInterno_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
        Me.wRegCbco.btnAgreCueBco.Focus()
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

            'NO PERMITIR IMPORTE EN CERO
            If Me.EsImporteEnCero = False Then Exit Sub

            'PASAR DATOS
            Me.DeControlesAGrilla()
            Me.wRegCbco.ImportesDebeHaber()
            If Me.Text = "Agregar Item" Then
                acc.LimpiarControles()
                Me.HabilitarDebeHaber()
                Me.txtCodCuen.Focus()
            End If
            If Me.Text = "Modificar Item" Then
                Me.Close()
            End If
            Me.gbMoneda.Enabled = True

            ''NO PERMITIR IMPORTE EN CERO
            'If Me.EsImporteEnCero = False Then Exit Sub
            ''PASAR DATOS
            'Me.DeControlesAGrilla()
            'Me.wRegCbco.ImportesDebeHaber()
            'If Me.Text = "Agregar Item" Then
            '    acc.LimpiarControles()
            '    Me.HabilitarDebeHaber()
            '    Me.txtCodCuen.Focus()
            'End If
            'If Me.Text = "Modificar Item" Then
            '    Me.Close()
            'End If
            'Me.gbMoneda.Enabled = True
        End If
    End Sub


#Region "Mostrar Formulario lista"

    Private Sub txtCodCuen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodCuen.KeyDown
        If Me.Text = "Agregar Item" Or Me.Text = "Modificar Item" Then
            If Me.txtCodCuen.ReadOnly = False Then
                If e.KeyCode = Keys.F1 Then
                    Dim win As New WListarPlanCuentaGe
                    win.tabla = "CuentasAnaliticasNoBancarias"    ''va la condicion del case
                    win.titulo = "Cuentas"
                    win.txt1 = Me.txtCodCuen
                    win.txt2 = Me.txtNomCue
                    If Me.txtCodAux.Enabled = True Then
                        win.ctrlFoco = Me.txtCodAux
                    Else
                        If Me.txtCenCto.Enabled = True Then
                            win.ctrlFoco = Me.txtCenCto
                        Else
                            Me.txtCenCto.Text = ""
                            Me.txtNomCto.Text = ""
                            If Me.TxtDoc.Enabled = True Then
                                win.ctrlFoco = Me.TxtDoc
                            Else
                                Me.TxtDoc.Text = ""
                                Me.TxtNomDoc.Text = ""
                                win.ctrlFoco = Me.txtImpSol
                            End If
                        End If
                    End If


                    'Me.HabilitarSegunCuenta()
                    'If Me.txtCodAux.Enabled = True Then
                    '    win.ctrlFoco = Me.txtCodAux
                    'Else
                    '    Me.txtCodAux.Text = ""
                    '    Me.txtNomAux.Text = ""
                    '    If Me.txtCenCto.Enabled = True Then
                    '        win.ctrlFoco = Me.txtCenCto
                    '    Else
                    '        Me.txtCenCto.Text = ""
                    '        Me.txtNomCto.Text = ""
                    '        If Me.TxtDoc.Enabled = True Then
                    '            win.ctrlFoco = Me.TxtDoc
                    '        Else
                    '            Me.TxtDoc.Text = ""
                    '            Me.TxtNomDoc.Text = ""
                    '            win.ctrlFoco = Me.txtImpSol
                    '        End If
                    '    End If
                    'End If
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
                win.wEditRegCajBcoDet = Me
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
                    win.ctrlFoco = Me.txtImpSol
                    win.NuevaVentana()
                End If
            End If
        End If
        'If Me.Text = "Agregar Item" Or Me.Text = "Modificar Item" Then
        '    If Me.txtCenCto.ReadOnly = False Then
        '        If e.KeyCode = Keys.F1 Then
        '            Dim win As New WListarTabla
        '            win.tabla = "CentroCosto"
        '            win.titulo = "Centro Costo"
        '            win.txt1 = Me.txtCenCto
        '            win.txt2 = Me.txtNomCto
        '            If Me.TxtDoc.Enabled = True Then
        '                win.ctrlFoco = Me.TxtDoc
        '            Else
        '                Me.TxtDoc.Text = ""
        '                Me.TxtNomDoc.Text = ""
        '                win.ctrlFoco = Me.gbDebeHaber
        '            End If
        '            win.NuevaVentana()
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub txtdoc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDoc.KeyDown
        If Me.Text = "Agregar Item" Or Me.Text = "Modificar Item" Then
            If Me.txtCenCto.ReadOnly = False Then
                If e.KeyCode = Keys.F1 Then
                    Dim win As New WListarTabla
                    win.tabla = "Documento"
                    win.titulo = "Documentos"
                    win.txt1 = Me.TxtDoc
                    win.txt2 = Me.TxtNomDoc
                    win.ctrlFoco = Me.TxtSer
                    win.NuevaVentana()
                End If
            End If
        End If
    End Sub

    Private Sub txtCodIe_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodIe.KeyDown
        If Me.Text = "Agregar Item" Or Me.Text = "Modificar Item" Then
            If Me.txtCodIe.ReadOnly = False Then
                If e.KeyCode = Keys.F1 Then
                    Dim win As New WListarIngEgr
                    win.titulo = "Ingresos & Egresos Activos"
                    ' win.ent.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
                    win.tabla = "IngresoEgreso"
                    win.txt1 = Me.txtCodIe
                    win.txt2 = Me.txtNomIe
                    win.ctrlFoco = Me.TxtCodAre
                    win.NuevaVentana()
                End If
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
                win.ctrlFoco = Me.TxtCodFluCaj
                win.NuevaVentana()
            End If
        End If
    End Sub


    Private Sub TxtCodFluCaj_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodFluCaj.KeyDown
        If Me.Text = "Agregar Item" Or Me.Text = "Modificar Item" Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarFlujoCaja
                win.titulo = "Flujos Activos"
                ' win.ent.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
                win.tabla = "FlujoCaja"
                win.txt1 = Me.TxtCodFluCaj
                win.txt2 = Me.TxtNomFluCaj
                win.ctrlFoco = Me.txtGlosa
                win.NuevaVentana()
            End If
        End If
    End Sub

#End Region

#Region "Buscar Por Codigo"

    Private Sub txtCodCue_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodCuen.Validating
        If Me.Text = "Agregar Item" Or Me.Text = "Modificar Item" Then
            Dim ope As New OperaWin : ope.txt1 = Me.txtCodCuen : ope.txt2 = Me.txtNomCue
            ope.Condicion = "CuentasAnaliticasNoBancarias"
            ope.MostrarCodigoDescripcionDePlancuentas("CuentasAnaliticas", e)

            'SI NO EXISTE LA CUENTA ENTONCES SALE
            If Me.txtCodCuen.Text = "" Then Exit Sub
            'SI HAY CUENTA
            Me.HabilitarSegunCuenta()
            '   Me.Asiento10()
            Me.CalcularImporteSegunMoneda()
        End If
    End Sub

    Private Sub txtCodAux_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodAux.Validating
        If Me.Text = "Agregar Item" Or Me.Text = "Modificar Item" Then
            Dim ope As New OperaWin : ope.txt1 = Me.txtCodAux : ope.txt2 = Me.txtNomAux
            ope.MostrarCodigoDescripcionDeAuxiliar("Todos", "Auxiliares", e)
        End If
    End Sub

    Private Sub txtCencto_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCenCto.Validating
        Me.EsCentroCostoValido()

    End Sub

    Private Sub txtDoc_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtDoc.Validating
        If Me.Text = "Agregar Item" Or Me.Text = "Modificar Item" Then
            Dim ope As New OperaWin : ope.txt1 = Me.TxtDoc : ope.txt2 = Me.TxtNomDoc
            ope.MostrarCodigoDescripcionDeTabla("Doc", "Documento", e)
        End If

    End Sub

    Private Sub txtCodIe_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodIe.Validating
        Me.EsIngresoEgresoValido()
    End Sub

    Private Sub TxtCodAre_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodAre.Validating
        Me.EsAreaValido()
    End Sub

    Private Sub TxtCodFluCaj_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodFluCaj.Validating
        Me.EsFlujoCajaValido()
    End Sub



#End Region

#Region "Calculos"
    Private Sub txtImpSol_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtImpSol.Validated, txtTipCam.Validated, txtImpDol.Validated, TxtImpEur.Validated, TxtTipcam1.Validated
        Me.HabilitarSegunMoneda()
        Me.CalcularImporteSegunMoneda()
        'Dim tipcam As Decimal = CType(Me.txtTipCam.Text, Decimal)

        'If tipcam = 0 Then
        '    MsgBox("Tipo de cambio dede ser diferente de cero (0)", MsgBoxStyle.Exclamation, "Tipo Cambio")
        '    Me.txtTipCam.Clear()
        '    Me.txtTipCam.Focus()
        'Else
        '    Select Case Rbt.radioActivo(Me.gbMoneda).Text
        '        Case "S/."
        '            Me.txtImpDol.Text = Varios.numeroConDosDecimal((CType(Me.txtImpSol.Text, Decimal) / CType(Me.txtTipCam.Text, Decimal)).ToString)
        '        Case "US$"
        '            Me.txtImpSol.Text = Varios.numeroConDosDecimal((CType(Me.txtImpDol.Text, Decimal) * CType(Me.txtTipCam.Text, Decimal)).ToString)
        '    End Select
        'End If
    End Sub

    Sub HabilitarSegunCuenta()

        Me.txtCodAux.Enabled = False
        Me.btnDocu.Enabled = False
        Me.txtCenCto.Enabled = False
        Me.TxtDoc.Enabled = False

        Dim ocue As New SuperEntidad
        ocue.ClaveCuentaPcge = SuperEntidad.xCodigoEmpresa + Me.txtCodCuen.Text.Trim
        ocue.NumeroDigitosPcge = entpar.DigitosCuentaAnalitica
        ocue = cta.buscarCuentaExisPorClaveyAnalitica(ocue)

        Me.txtCodAux.Enabled = CBool(IIf(ocue.FlagAuxiliarPcge = "Si", True, False))
        Me.txtCenCto.Enabled = CBool(IIf(ocue.FlagCentroCostoPcge = "Si", True, False))
        Me.TxtDoc.Enabled = CBool(IIf(ocue.FlagDocumentoPcge = "Si", True, False))

        If ocue.FlagAuxiliarPcge = "Si" Then
            Me.txtCodAux.Enabled = True
            Me.btnDocu.Enabled = True
            Me.txtCodAux.Text = Me.wRegCbco.TxtCodAux.Text
            '  Me.txtGlosa.Text = Me.wRegCbco.TxtConcepto.Text
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
                    Me.TxtDoc.Enabled = True
                    Me.TxtDoc.Focus()
                Else
                    '     Me.rbtDebe.Checked() = True
                End If
            End If
        End If


    End Sub


#End Region

    Private Sub btndocu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDocu.Click
        If Me.txtCodAux.Text.Trim <> "" Then
            Dim win As New WListarCuentaCorriente
            win.tabla = "CuentaCorriente"
            win.titulo = "Cuenta Corriente"
            win.codaux = Me.txtCodAux.Text.Trim
            win.txtBus.Focus()
            win.txt10 = Me.TxtNomDoc
            win.txt2 = Me.TxtDoc
            win.txt3 = Me.TxtSer
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

    Private Sub dtpFecha_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpFecha.Validating
        Me.TraerTipoCambio()
    End Sub

    Sub TraerTipoCambio()
        Dim ticEn As New SuperEntidad
        'traer tipo de cambio
        ticEn.DatoCondicion1 = Me.dtpFecha.Value.Year.ToString + "/" + Me.dtpFecha.Value.Month.ToString + "/" + Me.dtpFecha.Value.Day.ToString
        ticEn = tic.buscarTipoCambioExisPorFecha(ticEn)
        If ticEn.AnoTipoCambio = "" Then
            MsgBox("el tipo de cambio no existe", MsgBoxStyle.Information)
            Me.txtTipCam.Text = "1.000"
            Me.TxtTipcam1.Text = "1.000"
        Else
            Me.txtTipCam.Text = ticEn.VentaTipoCambio.ToString
            Me.TxtTipcam1.Text = ticEn.VentaEurTipoCambio.ToString
        End If
    End Sub

    Sub HabilitarSegunMoneda()
        If Me.rbtSol.Checked = True Or Me.rbtDol.Checked = True Or Me.RbtEur.Checked = True Then
            Dim Auto As String = Rbt.radioActivo(Me.gbMoneda).Text
            Select Case Auto
                Case "S/."
                    Me.txtImpSol.Enabled = True
                    Me.txtImpDol.Enabled = False
                    Me.TxtImpEur.Enabled = False
                Case "US$"
                    Me.txtImpSol.Enabled = False
                    Me.txtImpDol.Enabled = True
                    Me.TxtImpEur.Enabled = False
                Case "CAD"
                    Me.txtImpSol.Enabled = False
                    Me.txtImpDol.Enabled = False
                    Me.TxtImpEur.Enabled = True
            End Select
        End If

    End Sub

    Sub CalcularImporteSegunMoneda()

        If Me.rbtSol.Checked = True Or Me.rbtDol.Checked = True Or Me.RbtEur.Checked = True Then
            Dim impsol As Decimal = CType(Me.txtImpSol.Text, Decimal)
            Dim impdol As Decimal = CType(Me.txtImpDol.Text, Decimal)
            Dim impeur As Decimal = CType(Me.TxtImpEur.Text, Decimal)
            Dim tc As Decimal = CType(Me.txtTipCam.Text, Decimal)
            Dim tc1 As Decimal = CType(Me.TxtTipcam1.Text, Decimal)

            Dim Auto As String = Rbt.radioActivo(Me.gbMoneda).Text
            Select Case Auto
                Case "S/."
                    If tc <> 0 And tc1 <> 0 Then
                        Me.txtImpDol.Text = Varios.numeroConDosDecimal((impsol / tc).ToString)
                        Me.TxtImpEur.Text = Varios.numeroConDosDecimal((impsol / tc1).ToString)
                    End If
                Case "US$"
                    Me.txtImpSol.Text = Varios.numeroConDosDecimal((impdol * tc).ToString)
                    Me.TxtImpEur.Text = "1.00"

                Case "CAD"
                    Me.txtImpSol.Text = Varios.numeroConDosDecimal((impeur * tc1).ToString)
                    Me.txtImpDol.Text = "1.00"

            End Select
        End If

    End Sub

    Sub Asiento10()
        Dim cta As String = Me.txtCodCuen.Text.Trim

        If cta = "" Then Exit Sub


        If cta.Substring(0, 2) = "10" Then
            Me.TxtDoc.Text = Me.wRegCbco.txtdoc.Text.Trim
            Me.txtNum.Text = Me.wRegCbco.TxtNum.Text.Trim

            Dim mon As String = Rbt.radioActivo(Me.wRegCbco.gbMoneda).Text

            Select Case mon
                Case "S/."
                    Me.txtImpSol.Text = Me.wRegCbco.TxtImporte.Text
                    Me.rbtSol.Checked = True
                Case "US$"
                    Me.txtImpDol.Text = Me.wRegCbco.TxtImporte.Text
                    Me.rbtDol.Checked = True
                Case "CAD"
                    Me.TxtImpEur.Text = Me.wRegCbco.TxtImporte.Text
                    Me.RbtEur.Checked = True

            End Select
            If Me.wRegCbco.txtCodOri.Text = "1" Then
                Me.rbtDebe.Checked = True
            Else
                Me.rbtHaber.Checked = True
            End If
            Me.gbMoneda.Enabled = False
        Else
            Me.gbMoneda.Enabled = True

        End If

    End Sub

    Private Sub rbtSol_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtSol.CheckedChanged, rbtDol.CheckedChanged, RbtEur.CheckedChanged
        Me.HabilitarSegunMoneda()
        Me.CalcularImporteSegunMoneda()
    End Sub

    Private Sub WDetalleRegCajaBanco_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class