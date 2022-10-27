Imports Entidad
Imports Negocio
Public Class WModificarGastoReparable
#Region "Propietarios"
    Public wVouTod As New WVouchersTodos
#End Region
    Public ent As New SuperEntidad
    Public lista As New List(Of SuperEntidad)
    Public tab As New TablaRN
    Public Rcd As New RegContabDetaRN
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
        '/Ejecucion en ventana
        Me.Owner.Enabled = False
        ' Me.ListarDistritos()
        Me.Show()
    End Sub

    Sub ventanaModificar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Modificar Gasto Reparable"
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
            Me.TxtCodGAsRep.Text = ent.CodigoGastoReparable
            Me.TxtNomGasRep.Text = ent.NombreGastoReparable
        End If
        '\\
    End Sub

    Sub Aceptar()
        '//

        If Me.operacion = 1 Or Me.operacion = 2 Then
            ent = Rcd.BuscarDetalleRegContabPorClave(ent)
        End If

        ent.CodigoGastoReparable = Me.TxtCodGAsRep.Text.Trim
        'ent.NombreGastoReparable = Me.TxtNomGasRep.Text.Trim

        '/Se graba o0 se modifica?
        Select Case Me.operacion


            Case 1
                Rcd.modificarRegContab(ent)
                Me.ModificarMovimientoDetalle()

                MsgBox("Se modifico el documento Correctamente", MsgBoxStyle.Information)
                Me.Close()


        End Select
        '/Actualizar y buscar el registro grabado
        Me.wVouTod.ActualizarDgvDeta()
        'Dgv.obtenerCursorActual(Me.wAux.DgvAux, ent.DescripcionAuxiliar, Me.wAux.lista)
        '\\
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
        iGasREN.CodigoGastoReparable = Me.TxtCodGasRep.Text.Trim
        iGasREN = iGasRRN.EsGastoReparableValido(iGasREN)
        If iGasREN.EsVerdad = False Then
            MsgBox(iGasREN.Mensaje, MsgBoxStyle.Exclamation, "Gasto")
            Me.TxtCodGasRep.Focus()
        End If
        Me.MostarGasto(iGasREN)
        Return iGasREN.EsVerdad
    End Function


    Sub MostarGasto(ByRef pAR As SuperEntidad)
        Me.TxtCodGasRep.Text = pAR.CodigoGastoReparable
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
                '   win.wVouTod = Me
                Me.AddOwnedForm(win)
                win.tabla = "GastoReparable"
                win.titulo = "Item Almacen"
                win.txt1 = Me.TxtCodGAsRep
                win.txt2 = Me.TxtNomGasRep
                win.ctrlFoco = Me.btnAgregar
                win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub TxtCodGAsRep_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodGAsRep.Validating
        Me.EsGastoValido()
    End Sub
End Class