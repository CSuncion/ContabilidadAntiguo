Public Class Accion
    'Para utilizar esta clase hay que tener en encuenta algunas reglas
    '-los controles deben ser ordenados por tabindex a ecepcion de los radiobuton que se les pono de 100 para arriba
    '-Los controles deben ser ordenados por su tag sin ecepcion(el tag debe coincider con el indice que tiene el control dentro de la lista)

    'Public listaTsps As New List(Of ListaTsb)
    Public listaCtrls As New List(Of CtrlsEdit)

    'Listo
    Sub EstadoBotonesPorGrilla(ByRef lis As List(Of ListaTsb), ByRef Dgv As DataGridView)
        '//
        For Each tsb As ListaTsb In lis
            If tsb.GrillaVacia = "1" Then
                If Dgv.Rows.Count = 0 Then
                    tsb.Tsb.Enabled = False
                Else
                    tsb.Tsb.Enabled = True
                End If
            End If
        Next
        '\\
    End Sub
    'Listo
    Sub EstadoBotonesPorFillaGrilla(ByRef lis As List(Of ListaTsb), ByRef Dgv As DataGridView)
        '//
        For Each tsb As ListaTsb In lis
            If tsb.Desplaza = "1" Then
                Dim nRegs As Integer = Dgv.Rows.Count
                If nRegs = 0 Then
                    tsb.Tsb.Enabled = False
                Else
                    Dim indFil As Integer = Dgv.CurrentRow.Index
                    If tsb.indiceFila = indFil Then
                        tsb.Tsb.Enabled = False
                    Else
                        tsb.Tsb.Enabled = True
                    End If
                End If
            End If
        Next
        '\\
    End Sub
    'Listo
    Sub PasaFoco()
        '//
        For Each ctrl As CtrlsEdit In Me.listaCtrls
            If ctrl.PasaFoco = "1" Then
                AddHandler ctrl.Control.GotFocus, AddressOf ControlGanaFoco
                AddHandler ctrl.Control.LostFocus, AddressOf ControlPierdeFoco
            End If
        Next
        '\\
    End Sub
    'se va
    Sub GanaFoco()
        '//
        For Each ctrl As CtrlsEdit In Me.listaCtrls
            If ctrl.GanaFoco <> "-1" Then
                AddHandler ctrl.Control.GotFocus, AddressOf ControlGanaFoco
            End If
        Next
        '\\
    End Sub
    'listo
    Sub ControlGanaFoco(ByVal sender As Object, ByVal e As System.EventArgs)
        '//
        'Dim ind As Integer = CType(CType(sender, Control).Tag.ToString.Trim, Integer)
        'Dim cadena As String = Me.listaCtrls.Item(ind).GanaFoco

        If TypeOf (sender) Is TextBox Then
            Txt.ganaFoco(CType(sender, TextBox))
            Exit Sub
        ElseIf TypeOf (sender) Is ComboBox Then
            Cmb.ganaFoco(CType(sender, ComboBox))
            Exit Sub
        ElseIf TypeOf (sender) Is GroupBox Then
            Gb.pasarCursor(CType(sender, GroupBox))
            Exit Sub
        ElseIf TypeOf (sender) Is RadioButton Then
            Rbt.GanaFoco(CType(sender, RadioButton))
            Exit Sub
        End If
        '\\
    End Sub
    'se va
    Sub PierdeFoco()
        '//
        For Each ctrl As CtrlsEdit In Me.listaCtrls
            If ctrl.PierdeFoco = "1" Then
                AddHandler ctrl.Control.LostFocus, AddressOf ControlPierdeFoco
            End If
        Next
        '\\
    End Sub
    'listo
    Sub ControlPierdeFoco(ByVal sender As Object, ByVal e As System.EventArgs)
        '//
        If TypeOf (sender) Is TextBox Then
            Txt.pierdeFoco(CType(sender, TextBox))
            Exit Sub
        ElseIf TypeOf (sender) Is ComboBox Then
            Cmb.pierdeFoco(CType(sender, ComboBox))
            Exit Sub
        ElseIf TypeOf (sender) Is GroupBox Then
            'Gb.pasarCursor(CType(sender, GroupBox))
            Exit Sub
        ElseIf TypeOf (sender) Is RadioButton Then
            Rbt.PierdeFoco(CType(sender, RadioButton))
            Exit Sub
        End If
        '\\
    End Sub
    'listo
    Sub PasarCursor()
        '//
        For Each ctrl As CtrlsEdit In Me.listaCtrls
            If ctrl.PasarCursor = "1" Then
                AddHandler ctrl.Control.KeyDown, AddressOf PasandoCursor
            End If
        Next
        '\\
    End Sub
    'listo
    Sub PasandoCursor(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        '//
        Dim indCtrl As Integer = CType(sender, Control).TabIndex

        '/Saber que tipo de control es
        If TypeOf (sender) Is TextBox Then

            Select Case e.KeyCode

                Case Keys.Enter, Keys.Down
                    Me.buscaIndiceHaciaArriba(indCtrl)

                Case Keys.Up
                    Me.buscaIndiceHaciaAbajo(indCtrl)

                    'Case Keys.Delete 'Cuando pulsas la tecla suprimir
                    '    If CType(sender, TextBox).ReadOnly = False Then
                    '        CType(sender, TextBox).Text = ""
                    '    End If


            End Select

        ElseIf TypeOf (sender) Is ComboBox Or TypeOf (sender) Is DomainUpDown Or TypeOf (sender) Is DateTimePicker Then

            Select Case e.KeyCode

                Case Keys.Enter
                    Me.buscaIndiceHaciaArriba(indCtrl)

                Case Keys.ShiftKey
                    Me.buscaIndiceHaciaAbajo(indCtrl)

            End Select

        ElseIf TypeOf (sender) Is RadioButton Then
            indCtrl = CType(sender, RadioButton).Parent.TabIndex
            Select Case e.KeyCode

                Case Keys.Enter
                    Me.buscaIndiceHaciaArriba(indCtrl)

                Case Keys.ShiftKey
                    Me.buscaIndiceHaciaAbajo(indCtrl)

            End Select

        ElseIf TypeOf (sender) Is Button Then

            Select Case e.KeyCode

                Case Keys.Down
                    Me.buscaIndiceHaciaArriba(indCtrl)

                Case Keys.Up
                    Me.buscaIndiceHaciaAbajo(indCtrl)

            End Select

        End If
        '\\
    End Sub
    'listo
    Sub buscaIndiceHaciaArriba(ByRef indice As Integer)
        '//
        Dim ind As Integer
        ind = indice + 1
        For Each ctrl As CtrlsEdit In Me.listaCtrls
            If ctrl.Control.TabIndex = ind Then
                            If ctrl.Control.Enabled = False Or ctrl.Control.Visible = False Then
                                   Me.buscaIndiceHaciaArriba(ind)
                            Else
                                   ctrl.Control.Focus()
                            End If

            End If
        Next
        '\\
    End Sub
    'listo
    Sub buscaIndiceHaciaAbajo(ByRef indice As Integer)
        '//
        Dim ind As Integer
        ind = indice - 1
        For Each ctrl As CtrlsEdit In Me.listaCtrls
            If ctrl.Control.TabIndex = ind Then
                If ctrl.Control.Enabled = False Or ctrl.Control.Visible = False Then
                    Me.buscaIndiceHaciaAbajo(ind)
                Else
                    ctrl.Control.Focus()
                End If
            End If
        Next
        '\\
    End Sub
    'listo
    Sub LimpiarControles()
        '//
        For Each ctrl As CtrlsEdit In Me.listaCtrls
            If ctrl.Limpiar = "1" Then
                Me.Limpiando(ctrl.Control, ctrl.DatoLimpiar)
            End If
        Next
        '\\
    End Sub
    'listo
    Sub Limpiando(ByRef ctrl As Control, ByRef defecto As String)
        '//
        If TypeOf (ctrl) Is TextBox Then
            Txt.Limpiar(CType(ctrl, TextBox), defecto)
            Exit Sub
        ElseIf TypeOf (ctrl) Is ComboBox Then
            Cmb.Limpiar(CType(ctrl, ComboBox), defecto)
            Exit Sub
        ElseIf TypeOf (ctrl) Is RadioButton Then
            Rbt.Limpiar(CType(ctrl, RadioButton), defecto)
            Exit Sub
        ElseIf TypeOf (ctrl) Is DomainUpDown Then
            Dud.Limpiar(CType(ctrl, DomainUpDown), defecto)
            Exit Sub
        ElseIf TypeOf (ctrl) Is Label Then
            CType(ctrl, Label).Text = ""
            Exit Sub
        ElseIf TypeOf (ctrl) Is DateTimePicker Then
            Dtp.Limpiar(CType(ctrl, DateTimePicker), defecto)
            Exit Sub
        End If
        '\\
    End Sub
    'listo
    Function CamposObligatorios() As Boolean
        '//
        For Each ctrl As CtrlsEdit In Me.listaCtrls
            If ctrl.Obligatorio = "1" Then
                If Me.CampoObligatorio(ctrl.Control, ctrl.DatoLimpiar, ctrl.Campo) = False Then
                    Return False
                    Exit Function
                End If

            End If
        Next
        Return True
        '\\
    End Function
    'listo
    Function CampoObligatorio(ByRef ctrl As Control, ByRef defecto As String, ByRef campo As String) As Boolean
        '//
        If TypeOf (ctrl) Is TextBox Then
            Return Txt.CampoObligatorio(CType(ctrl, TextBox), defecto, campo)
            Exit Function
        ElseIf TypeOf (ctrl) Is DomainUpDown Then
            Return Dud.CampoObligatorio(CType(ctrl, DomainUpDown), defecto, campo)
            Exit Function
        ElseIf TypeOf (ctrl) Is ComboBox Then
            Return Cmb.CampoObligatorio(CType(ctrl, ComboBox), campo)
            Exit Function
        End If
        '\\
    End Function
    'listo
    Sub Teclazo()
        '//
        For Each ctrl As CtrlsEdit In Me.listaCtrls
            AddHandler ctrl.Control.KeyPress, AddressOf ValidaTecla
        Next
        '\\
    End Sub
    'listo
    Sub ValidaTecla(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim ind As Integer = CType(CType(sender, Control).Tag.ToString.Trim, Integer)
        Dim TipoValida As Integer = Me.listaCtrls.Item(ind).Teclazo
        Select Case TipoValida

            Case Validar.Tecla.kNada
                Exit Sub
            Case Validar.Tecla.kAlfaNumericoConEspacio
                Validar.kAlfaNumericoConEspacio(e)

            Case Validar.Tecla.kAlfaNumericoSinEspacio
                Validar.kAlfaNumericoSinEspacio(e)

            Case Validar.Tecla.kClave
                Validar.kClave(e)

            Case Validar.Tecla.kEmail
                Validar.kEmail(e)

            Case Validar.Tecla.kSoloLetraConEspacio
                Validar.kSoloLetraConEspacio(e)

            Case Validar.Tecla.kSoloLetraSinEspacio
                Validar.kSoloLetraSinEspacio(e)

            Case Validar.Tecla.kSoloNumeroConEspacio
                Validar.kSoloNumeroConEspacio(e)

            Case Validar.Tecla.kSoloNumeroSinEspacio
                Validar.kSoloNumeroSinEspacio(e)

            Case Validar.Tecla.kAlfaNumericoSinEspacio
                Validar.kAlfaNumericoSinEspacio(e)

            Case Validar.Tecla.kDecimal
                Validar.kDecimal(e)

            Case Validar.Tecla.kAlfaNumericoSinEspacioConGuion
                Validar.kAlfaNumericoSinEspacioConGuion(e)

            Case Validar.Tecla.kDescripcion
                Validar.kDescripcion(e)

            Case Validar.Tecla.kDireccion
                Validar.kDireccion(e)

            Case Validar.Tecla.kProyecto
                Validar.kProyecto(e)


            Case Validar.Tecla.kTipoProyecto
                Validar.kTipoProyecto(e)

            Case Validar.Tecla.kTelefono
                Validar.kTelefono(e)

        End Select
    End Sub
    'listo
    Sub Valida()
        '//
        For Each ctrl As CtrlsEdit In Me.listaCtrls
            If TypeOf (ctrl.Control) Is TextBox Then
                If CType(ctrl.Control, TextBox).ReadOnly = False Then
                    AddHandler ctrl.Control.Validating, AddressOf ValidaTexto
                End If
            Else
                AddHandler ctrl.Control.Validating, AddressOf ValidaTexto
            End If
            ' AddHandler ctrl.Control.Validating, AddressOf ValidaTexto
        Next
        '\\
    End Sub

    Sub ValidaTexto(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        'listo
        Dim ind As Integer = CType(CType(sender, Control).Tag.ToString.Trim, Integer)
        Dim TipoValida As Integer = Me.listaCtrls.Item(ind).Valida
        Dim arg As String = Me.listaCtrls.Item(ind).Campo
        Dim Numc As Integer = Me.listaCtrls.Item(ind).NumCaracter

        Select Case TipoValida

            Case Validar.texto.vNada
                Exit Sub
            Case Validar.texto.vClave
                Validar.vClave(sender, arg, e)

            Case Validar.texto.vSoloLetrasConEspacio
                Validar.vSoloLetrasConEspacio(sender, arg, e)

            Case Validar.texto.vSoloLetrasSinEspacio
                Validar.vSoloLetrasSinEspacio(sender, arg, e)

            Case Validar.texto.vSolonumerosConDosDecimales
                Validar.vSoloNumerosConDosDecimales(sender, arg, e)

            Case Validar.texto.vSolonumerosConTresDecimales
                Validar.vSoloNumerosConTresDecimales(sender, arg, e)

            Case Validar.texto.vSoloNumerosConEspacio
                Validar.vSoloNumerosConEspacio(sender, arg, e)

            Case Validar.texto.vSoloNumerosSinEspacio
                Validar.vSoloNumerosSinEspacio(sender, arg, e)

            Case Validar.texto.vSoloAlfaNumericoConEspacio
                Validar.vSoloAlfaNumericoConEspacio(sender, arg, e)

            Case Validar.texto.vSoloAlfaNumericoSinEspacio
                Validar.vSoloAlfaNumericoSinEspacio(sender, arg, e)

            Case Validar.texto.vNumeroDiasDeMes
                Validar.vNumeroDiasDeMes(sender, arg, e)

            Case Validar.texto.vSoloEnteros
                Validar.vSoloEnteros(sender, arg, e)

            Case Validar.texto.vCodigoProyecto
                Validar.vCodigoProyecto(sender, arg, e)

            Case Validar.texto.vDescripcion
                Validar.vDescripcion(sender, arg, e)

            Case Validar.texto.vDireccion
                Validar.vDireccion(sender, arg, e)

            Case Validar.texto.vAñoUtil
                Validar.vAñoUtil(sender, arg, e)

            Case Validar.texto.vNumeroSemanaAno
                Validar.vNumeroSemanaAno(sender, arg, e)

            Case Validar.texto.vRucHonorario
                Validar.vRucHonorario(sender, arg, e)

            Case Validar.texto.vRucEmpresa
                Validar.vRucEmpresa(sender, arg, e)

            Case Validar.texto.vTipoProyecto
                Validar.vTipoProyecto(sender, arg, e)

            Case Validar.texto.vTelefono
                Validar.vTelefono(sender, arg, e)

            Case Validar.texto.vCompletarCerosCadena
                Validar.vCompletarCerosCadena(sender, Numc, arg, e)

        End Select

    End Sub
    'listo
    Sub Nuevo()
        '//
        For Each ctrl As CtrlsEdit In Me.listaCtrls
            Me.ControlOperacion(ctrl.Control, ctrl.Nuevo)
        Next
        '\\
    End Sub
    'listo
    Sub Modificar()
        '//
        For Each ctrl As CtrlsEdit In Me.listaCtrls
            Me.ControlOperacion(ctrl.Control, ctrl.Modificar)
        Next
        '\\
    End Sub
    'listo
    Sub Eliminar()
        '//
        For Each ctrl As CtrlsEdit In Me.listaCtrls
            Me.ControlOperacion(ctrl.Control, ctrl.Eliminar)
        Next
        '\\
    End Sub
    'listo
    'Sub Anular()
    '    '//
    '    For Each ctrl As CtrlsEdit In Me.listaCtrls
    '        Me.ControlOperacion(ctrl.Control, ctrl.Eliminar)
    '    Next
    '    '\\
    'End Sub

    'listo
    Sub Visualizar()
        '//
        For Each ctrl As CtrlsEdit In Me.listaCtrls
            Me.ControlOperacion(ctrl.Control, ctrl.Visualizar)
        Next
        '\\
    End Sub
    'listo
    Sub ControlOperacion(ByRef ctrl As Control, ByRef act As String)
        '//
        If TypeOf (ctrl) Is TextBox Then
            Txt.HabilitarSegunOperacion(CType(ctrl, TextBox), act)
            Exit Sub
        ElseIf TypeOf (ctrl) Is ComboBox Then
            Cmb.HabilitarSegunOperacion(CType(ctrl, ComboBox), act)
            Exit Sub
        ElseIf TypeOf (ctrl) Is RadioButton Then
            Rbt.HablilitarSegunOperacion(CType(ctrl, RadioButton), act)
            Exit Sub
        ElseIf TypeOf (ctrl) Is DomainUpDown Then
            Dud.HabilitarSegunOperacion(CType(ctrl, DomainUpDown), act)
            Exit Sub
        ElseIf TypeOf (ctrl) Is DateTimePicker Then
            Dtp.HabiltaSegunOperacion(CType(ctrl, DateTimePicker), act)
            Exit Sub
        ElseIf TypeOf (ctrl) Is Button Then
            btn.HabiltaSegunOperacion(CType(ctrl, Button), act)
            Exit Sub
        End If
        '\\
    End Sub
    'listo
    'especial para campos tipo precios
    Sub FomatoDato()
        '//
        For Each ctrl As CtrlsEdit In Me.listaCtrls
            If ctrl.Formato = "1" Then
                AddHandler ctrl.Control.GotFocus, AddressOf PonerValorDefectoGotFocus
                AddHandler ctrl.Control.LostFocus, AddressOf PonerValorDefectoLostFocus
            End If
        Next
        '\\
    End Sub
    'listo
    Sub PonerValorDefectoGotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        '//
        Dim ind As Integer = CType(CType(sender, Control).Tag.ToString.Trim, Integer)
        Dim cadena As String = Me.listaCtrls.Item(ind).DatoLimpiar

        If TypeOf (sender) Is TextBox Then
            Txt.ValorDefectoGot(CType(sender, TextBox), cadena)
            Exit Sub
        ElseIf TypeOf (sender) Is DomainUpDown Then
            Dud.ValorDefectoGot(CType(sender, DomainUpDown), cadena)
            Exit Sub
        End If
        '\\
    End Sub
    'listo
    Sub PonerValorDefectoLostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        '//
        Dim ind As Integer = CType(CType(sender, Control).Tag.ToString.Trim, Integer)
        Dim cadena As String = Me.listaCtrls.Item(ind).DatoLimpiar


        If TypeOf (sender) Is TextBox Then
            Txt.ValorDefectoLost(CType(sender, TextBox), cadena)
            Exit Sub
        ElseIf TypeOf (sender) Is DomainUpDown Then
            Dud.ValorDefectoLost(CType(sender, DomainUpDown), cadena)
            Exit Sub
        End If
        '\\
    End Sub
End Class
