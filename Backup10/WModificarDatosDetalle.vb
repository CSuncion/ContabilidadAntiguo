Imports Entidad
Imports Negocio
Public Class WModificarDatosDetalle
#Region "Propietarios"
    Public wVouTod As New WVouchersTodos
#End Region
    Public ent, entpar, paren As New SuperEntidad
    Public lista As New List(Of SuperEntidad)
    Public tab As New TablaRN
    Public Rcd As New RegContabDetaRN
    Public par As New ParametroRN
    Public cta As New PlanCuentaGeRN
    Public cam As New CamposEntidad
    Public acc As New Accion
    Public operacion As Integer  '0=agregar , 1=modificar , 2=eliminar , 3=visualizar


#Region "Metodos"

    Sub InicializaVentana()
        '/Para los eventos de controles
        acc.listaCtrls = Me.ListaControles
        acc.PasaFoco()
        acc.FomatoDato()
        acc.PasarCursor()
        acc.Teclazo()
        acc.Valida()
        entpar = par.buscarParametroExis(paren)
        Me.HabilitarSegunCuenta()
        '/Ejecucion en ventana
        Me.Owner.Enabled = False
        Me.Show()
    End Sub

    Sub ventanaModificar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Modificar Datos Detalle"
        'mostrar el registro en pantalla
        Me.obtenerRegistroDetaEnPantalla(codigo)
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.TxtCodGAsRep)
        'los controles que deben estar activos
        acc.Modificar()
        '\\
    End Sub

    Sub obtenerRegistroDetaEnPantalla(ByRef codigo As String)
        '//
        ent.ClaveRegContabDeta = codigo
        ent = Rcd.BuscarDetalleRegContabPorClave(ent)
        'preguntar si ent tiene el registro
        If ent.ClaveRegContabDeta = "" Then
            Exit Sub
        Else
            '/Pasar Datos a los controles
            Me.txtDoc.Text = ent.TipoDocumento
            Me.txtNomDoc.Text = ent.NombreDocumento
            Me.txtSer.Text = ent.SerieDocumento
            Me.txtNum.Text = ent.NumeroDocumento
            Me.dtpFecha.Value = ent.FechaDocumento
            Gb.pasarDato(Me.gbMoneda, ent.Exporta)
            Me.txtImpSol.Text = Varios.numeroConDosDecimal(ent.ImporteSRegContabDeta.ToString)
            Me.txtImpDol.Text = Varios.numeroConDosDecimal(ent.ImporteDRegContabDeta.ToString)
            Me.txtCodAux.Text = ent.CodigoAuxiliar
            Me.txtNomAux.Text = ent.DescripcionAuxiliar
            Me.TxtCodCuenta.Text = ent.CodigoCuentaPcge
            Me.TxtNomCuenta.Text = ent.NombreCuentaPcge
            Me.TxtCodCenCto.Text = ent.CodigoCentroCosto
            Me.TxtNomCenCto.Text = ent.NombreCentroCosto
            Me.TxtCodGAsRep.Text = ent.CodigoGastoReparable
            Me.TxtNomGasRep.Text = ent.NombreGastoReparable
            Me.TxtCantidad.Text = Varios.numeroConDosDecimal(ent.Cantidad.ToString)
        End If
        '\\
    End Sub

    Sub Aceptar()
        '//

        If Me.operacion = 1 Or Me.operacion = 2 Then
            ent = Rcd.BuscarDetalleRegContabPorClave(ent)
        End If
        ent.CodigoCuentaPcge = Me.TxtCodCuenta.Text.Trim
        ent.CodigoCentroCosto = Me.TxtCodCenCto.Text.Trim
        ent.CodigoGastoReparable = Me.TxtCodGAsRep.Text.Trim
        ent.Cantidad = CType(Me.TxtCantidad.Text, Decimal)

        '/Se graba o0 se modifica?
        Select Case Me.operacion
            Case 1
                Rcd.modificarRegContab(ent)
                ' Me.ModificarMovimientoDetalle()
                MsgBox("Se modifico el documento Correctamente", MsgBoxStyle.Information)
                Me.Close()
        End Select
        '/Actualizar y buscar el registro grabado
        Me.wVouTod.ActualizarDgvDeta()
        ent.ClaveRegContabDeta = ent.CodigoEmpresa + ent.PeriodoRegContabCabe + ent.CodigoOrigen + ent.CodigoFile + ent.NumeroVoucherRegContabCabe + ent.CorrelativoRegContabDeta
        Dgv.obtenerCursorActual(Me.wVouTod.DgvMovDeta, ent.ClaveRegContabDeta, Me.wVouTod.lista)
        '\\
        '/Actualizar y buscar el registro grabado
        'Me.wRc.ActualizarVentana()
        'ent.ClaveRegContabCabe = ent.CodigoEmpresa + ent.PeriodoRegContabCabe + ent.CodigoOrigen + ent.CodigoFile + ent.NumeroVoucherRegContabCabe
        'Dgv.obtenerCursorActual(Me.wRc.DgvRcom, ent.ClaveRegContabCabe, Me.wRc.lista)

    End Sub

    Sub ModificarMovimientoDetalle()
        Dim iMcdRN As New MovimientoContableDetalleRN
        Dim iMcdEN As New SuperEntidad
        iMcdEN.ClaveRegContabDeta = ent.ClaveRegContabDeta
        '  Dim iListMcd As List(Of SuperEntidad) = iMcdRN.obtenerDetalleRegContabPorClave(iMcdEN)
        Dim iListMcd As List(Of SuperEntidad) = iMcdRN.obtenerDetalleRegContabPorClaveDeta(iMcdEN)

        For Each xMcd As SuperEntidad In iListMcd
            xMcd.CodigoGastoReparable = Me.TxtCodGAsRep.Text
            iMcdRN.ModificarMovimientoContableDetalle(xMcd)
        Next

    End Sub


    Public Function EsGastoValido() As Boolean
        Dim iGasRRN As New GastoReparableRN
        Dim iGasREN As New SuperEntidad
        iGasREN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iGasREN.CodigoGastoReparable = Me.TxtCodGAsRep.Text.Trim
        iGasREN = iGasRRN.EsGastoReparableValido(iGasREN)
        If iGasREN.EsVerdad = False Then
            MsgBox(iGasREN.Mensaje, MsgBoxStyle.Exclamation, "Item Almacen")
            Me.TxtCodGAsRep.Focus()
        End If
        Me.MostarGasto(iGasREN)
        Return iGasREN.EsVerdad
    End Function


    Sub MostarGasto(ByRef pAR As SuperEntidad)
        Me.TxtCodGAsRep.Text = pAR.CodigoGastoReparable
        Me.TxtNomGasRep.Text = pAR.NombreGastoReparable
    End Sub


#End Region

    Private Sub WModificarDocumento_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

#Region "Mostrar formulario Lista"

    Private Sub txtDoc_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDoc.KeyDown
        If Me.operacion = 1 Then
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

    Private Sub txtCodAux_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodAux.KeyDown
        'If Me.txtCodAux.ReadOnly = False Then
        '    If e.KeyCode = Keys.F1 Then
        '        Dim win As New WListarAuxiliar
        '        win.wVouTod = Me
        '        Me.AddOwnedForm(win)
        '        win.tabla = "Todos"
        '        win.titulo = "Auxiliares"
        '        win.txt1 = Me.txtCodAux
        '        win.txt2 = Me.txtNomAux
        '        win.ctrlFoco = Me.btnAgregar
        '        win.NuevaVentana()
        '    End If
        'End If

    End Sub


#End Region

#Region "Busca por codigo"

    Private Sub txtDoc_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDoc.Validating
        If Me.operacion = 1 Then
            Dim ope As New OperaWin : ope.txt1 = Me.txtDoc : ope.txt2 = Me.txtNomDoc
            ope.MostrarCodigoDescripcionDeTabla("Doc", "Documento", e)
        End If
    End Sub

    'Private Sub txtCodAux_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodAux.Validating
    '    If Me.operacion = 1 Then
    '        Dim ope As New OperaWin : ope.txt1 = Me.txtCodAux : ope.txt2 = Me.txtNomAux
    '        ope.MostrarCodigoDescripcionDeAuxiliar("Todos", "Auxiliares", e)
    '    End If
    'End Sub


#End Region

    Public Function EsCentroCostoValido() As Boolean
        Dim iCCosRN As New CentroCostoRN
        Dim iCCosEN As New SuperEntidad
        iCCosEN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iCCosEN.CodigoCentroCosto = Me.TxtCodCenCto.Text.Trim
        iCCosEN = iCCosRN.EsCentroCostoActivoValido(iCCosEN)
        If iCCosEN.EsVerdad = False Then
            MsgBox(iCCosEN.Mensaje, MsgBoxStyle.Exclamation, "Centro Costos")
            Me.TxtCodCenCto.Focus()
        End If
        Me.MostarCentroCosto(iCCosEN)
        Return iCCosEN.EsVerdad
    End Function

    Sub MostarCentroCosto(ByRef pCC As SuperEntidad)
        Me.TxtCodCenCto.Text = pCC.CodigoCentroCosto
        Me.TxtNomCenCto.Text = pCC.NombreCentroCosto
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If acc.CamposObligatorios = False Then
            Exit Sub
        Else
            Me.Aceptar()
        End If
    End Sub

    Private Sub btnCancelar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Dim rpta As Integer = MsgBox("Deseas Cancelar La Operacion", MsgBoxStyle.YesNo)
        If rpta = MsgBoxResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub TxtCodGAsRep_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodGAsRep.KeyDown
        If Me.TxtCodGAsRep.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarGastoReparable
                win.wVouTod = Me
                Me.AddOwnedForm(win)
                win.tabla = "CodigoAlmacen"
                win.titulo = "Item Almacen"
                win.txt1 = Me.TxtCodGAsRep
                win.txt2 = Me.TxtNomGasRep
                ' win.ctrlFoco = Me.btnAgregar
                win.ctrlFoco = Me.TxtCantidad
                win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub TxtCodGAsRep_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodGAsRep.Validating
        Me.EsGastoValido()
    End Sub

    Sub HabilitarSegunCuenta()
        Dim ocue As New SuperEntidad
        ocue.ClaveCuentaPcge = SuperEntidad.xCodigoEmpresa + Me.TxtCodCuenta.Text.Trim
        ocue.NumeroDigitosPcge = entpar.DigitosCuentaAnalitica
        ocue = cta.buscarCuentaExisPorClaveyAnalitica(ocue)

        'Me.txtCencto.Enabled = IIf(ocue.FlagCentroCostoPcge = "Si", True, False)
        If ocue.FlagCentroCostoPcge = "Si" Then
            Me.TxtCodCenCto.Enabled = True
            If ocue.FlagAlmacenPcge = "Si" Then
                Me.TxtCodGAsRep.Enabled = True
                Me.TxtCantidad.Enabled = True
            End If
            Me.TxtCodCenCto.Focus()
        Else
            Me.TxtCodCenCto.Enabled = False
            Me.TxtCodCenCto.Text = ""
            Me.TxtNomCenCto.Text = ""
            If ocue.FlagAlmacenPcge = "Si" Then
                Me.TxtCodGAsRep.Enabled = True
                Me.TxtCantidad.Enabled = True
                Me.TxtCodGAsRep.Focus()
            Else
                Me.TxtCodGAsRep.Enabled = False
                Me.TxtCantidad.Enabled = False
                Me.TxtCodGAsRep.Text = ""
                Me.TxtNomGasRep.Text = ""
                Me.TxtCantidad.Text = "0"
                Me.btnAgregar.Focus()
            End If
            'Me.TxtCodGAsRep.Focus()
        End If

        'If ocue.FlagAlmacenPcge = "Si" Then
        '    Me.TxtCodGasRep.Enabled = True
        '    Me.TxtCantidad.Enabled = True
        'Else
        '    Me.TxtCodGasRep.Enabled = False
        '    Me.TxtCantidad.Enabled = False
        '    Me.TxtCodGasRep.Text = ""
        '    Me.TxtNomGasRep.Text = ""
        '    Me.TxtCantidad.Text = "0"
        'End If

    End Sub

    Private Sub WModificarDatosDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TxtCodCuenta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodCuenta.KeyDown
        If Me.TxtCodCuenta.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarPlanCuentaGe
                win.tabla = "CuentasAnaliticas"
                win.titulo = "Cuentas"
                win.txt1 = Me.TxtCodCuenta
                win.txt2 = Me.TxtNomCuenta
                win.ctrlFoco = Me.TxtCodCenCto
                win.NuevaVentana()
            End If
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub TxtCodCuenta_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodCuenta.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.TxtCodCuenta : ope.txt2 = Me.TxtNomCuenta
        ope.Condicion = "CuentasAnaliticas"
        ope.MostrarCodigoDescripcionDePlancuentas("CuentasAnaliticas", e)
        Me.HabilitarSegunCuenta()
    End Sub

    Private Sub TxtCodCenCto_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodCenCto.KeyDown
        If Me.TxtCodCenCto.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarCentroCostos
                win.titulo = "Centro Costos Activos"
                win.tabla = "CentroCosto"
                win.txt1 = Me.TxtCodCenCto
                win.txt2 = Me.TxtNomCenCto
                win.ctrlFoco = Me.TxtCodGAsRep
                win.NuevaVentana()
            End If
        End If

    End Sub

    Private Sub TxtCodCenCto_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodCenCto.Validating
        Me.EsCentroCostoValido()
    End Sub

    Private Sub TxtCodCenCto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodCenCto.TextChanged

    End Sub
End Class