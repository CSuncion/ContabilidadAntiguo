Imports Entidad
Imports Negocio
Public Class WEditarMes
    '#Region "Controles"
    '    Function Controles() As List(Of Control)
    '        Dim l As New List(Of Control)
    '        l.Add(Me.txtCod)
    '        l.Add(Me.txtNom)
    '        l.Add(Me.txtNumDias)
    '        l.Add(Me.btnGrabar)
    '        Return l
    '    End Function
    '#End Region
    Public acc As New Accion
    Public ent As New SuperEntidad
    Public lista As New List(Of SuperEntidad)
    Public cam As New CamposEntidad
    Public tab As New TablaRN
#Region "Propietarios"
    Public wMes As New WMeses
#End Region
#Region "Metodos"

    Sub InicializaVentana()
        ''/Para los eventos de controles
        acc.listaCtrls = Me.ListaControles
        acc.GanaFoco()
        acc.PierdeFoco()
        acc.PasarCursor()
        acc.Teclazo()
        acc.Valida()
        '/Ejecucion en ventana
        Me.Owner.Enabled = False
        Me.Show()
    End Sub

    Sub ventanaAdicionar()
        '//
        Me.InicializaVentana()
        Me.Text = "Nuevo " + Me.wMes.Text
        Txt.cursorAlUltimo(Me.txtCod)
        '\\
    End Sub

    Sub obtenerItemTablaEnPantalla(ByRef cod As String)
        '//
        ent.TipoTabla = Me.wMes.tabla
        ent.CodigoItemTabla = cod
        ent = tab.obtenerItemTablaPorCodigo(ent)
        '/Pasar Datos a los controles
        Me.txtCod.Text = ent.CodigoItemTabla
        Me.txtNom.Text = ent.NombreItemTabla
        Me.txtNumDias.Text = ent.NumDiasItemTabla
        '\\
    End Sub

    Sub ventanaModificar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        Me.Text = "Modificar " + Me.wMes.Text
        Me.obtenerItemTablaEnPantalla(codigo)
        Me.txtCod.ReadOnly = True
        Txt.cursorAlUltimo(Me.txtNom)
        '\\
    End Sub

    Sub grabar()
        '//
        ent.TipoTabla = Me.wMes.tabla
        ent.CodigoItemTabla = Me.txtCod.Text.Trim
        ent.NombreItemTabla = Me.txtNom.Text.Trim
        ent.NumDiasItemTabla = CType(CType(Me.txtNumDias.Text.Trim, Integer), String)

        '/Se graba o0 se modifica?
        Select Case Me.Text

            Case "Nuevo " + Me.wMes.Text
                tab.nuevoItemTabla(ent)
                MsgBox(Me.wMes.Text + " ingresado correctamente", MsgBoxStyle.Information)
                acc.LimpiarControles()
                Txt.cursorAlUltimo(Me.txtCod)
                '/Registrar el usuario que creo este registro

            Case "Modificar " + Me.wMes.Text
                'tab.modificarItemTabla(ent)
                MsgBox(Me.wMes.Text + " modificado correctamente", MsgBoxStyle.Information)
                Me.Close()
                '/Registrar el usuario que modifico este registro


        End Select
        '/Actualizar y buscar el registro grabado
        Me.wMes.ActualizarVentana()
        Dgv.obtenerCursorActual(Me.wMes.DgvMes, ent.NombreItemTabla, Me.wMes.lista)
        '\\
    End Sub


#End Region

    Private Sub WEditarTabla_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
        If Me.Text = "Modificar " + Me.wMes.Text Then
            Me.grabar()
            Exit Sub
        End If

        If acc.CamposObligatorios = False Then
            Exit Sub
        Else
            Me.grabar()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

#Region "Validating"

    Private Sub txtCod_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCod.Validating
        'Se ejecuta este evento solo cuando se agrega un nuevo registro
        If Me.Text = "Nuevo " + Me.wMes.Text Then
            ent.TipoTabla = Me.wMes.tabla
            ent.CodigoItemTabla = Me.txtCod.Text.Trim
            'Validar el codigo ingresado 
            If tab.existeItemTabla(ent) = True Then
                MsgBox("El codigo ya existe", MsgBoxStyle.Exclamation)
                Txt.cursorAlUltimo(Me.txtCod)
            Else
                e.Cancel = False
            End If
        End If
    End Sub

    Private Sub txtNumDias_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNumDias.Validating
        'Dim n As String = Me.txtNumDias.Text.Trim
        'If n = "" Then
        '    Exit Sub
        'Else
        '    Dim num As Integer = CType(n, Integer)
        '    If num < 32 Then
        '        e.Cancel = False
        '    Else
        '        MsgBox("no es correcto el numero de dias", MsgBoxStyle.Exclamation)
        '        Txt.cursorAlUltimo(Me.txtNumDias)
        '    End If

        'End If

    End Sub

#End Region

    '#Region "KeyPress"
    '    Private Sub txtCod_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCod.KeyPress
    '        Validar.kAlfaNumericoSinEspacio(e)
    '    End Sub

    '    Private Sub txtNom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNom.KeyPress
    '        Validar.kSoloLetraConEspacio(e)
    '    End Sub

    '    Private Sub txtNumDias_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDias.KeyPress
    '        Validar.kSoloNumeroSinEspacio(e)
    '    End Sub
    '#End Region

    
  
End Class