Imports System.Drawing.FontStyle
Public Class Eventos
    Shared Sub pasarCursor(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs, ByVal ctrlAn As Control, ByVal ctrlSi As Control)
        If TypeOf (sender) Is TextBox Then
            Select Case e.KeyCode
                Case Keys.Enter, Keys.Down
                    If ctrlSi Is Nothing Then
                        Exit Sub
                    Else
                        pasandoCursor(ctrlSi)
                    End If
                Case Keys.Up
                    If ctrlAn Is Nothing Then
                        Exit Sub
                    Else
                        pasandoCursor(ctrlAn)
                    End If
                Case Keys.Delete 'Cuando pulsas la tecla suprimir
                    CType(sender, TextBox).Text = ""
            End Select
        ElseIf TypeOf (sender) Is ComboBox Or TypeOf (sender) Is RadioButton Or TypeOf (sender) Is DateTimePicker Then
            Select Case e.KeyCode
                Case Keys.Enter
                    If ctrlSi Is Nothing Then
                        Exit Sub
                    Else
                        pasandoCursor(ctrlSi)
                    End If
                Case Keys.ShiftKey
                    If ctrlAn Is Nothing Then
                        Exit Sub
                    Else
                        pasandoCursor(ctrlAn)
                    End If
            End Select
        ElseIf TypeOf (sender) Is Button Then
            Select Case e.KeyCode
                Case Keys.ShiftKey
                    If ctrlAn Is Nothing Then
                        Exit Sub
                    Else
                        pasandoCursor(ctrlAn)
                    End If
            End Select
        End If
    End Sub

    Shared Sub pasarCursor_EnterShift(ByVal e As System.Windows.Forms.KeyEventArgs, ByVal ctrlAnterior As Control, ByVal ctrlSiguiente As Control)
        Select Case e.KeyCode
            Case Keys.Enter
                If ctrlSiguiente Is Nothing Then
                    Exit Sub
                Else
                    pasandoCursor(ctrlSiguiente)
                End If
            Case Keys.Up
                If ctrlAnterior Is Nothing Then
                    Exit Sub
                Else
                    pasandoCursor(ctrlAnterior)
                End If
        End Select
    End Sub

    Public Shared Sub pasandoCursor(ByRef obj As Control)
        'preguntar que tipo de objeto es obj
        If TypeOf (obj) Is TextBox Then
            Txt.cursorAlUltimo(CType(obj, TextBox))
        ElseIf TypeOf (obj) Is Button Then
            CType(obj, Button).Focus()
        ElseIf TypeOf (obj) Is ComboBox Then
            CType(obj, ComboBox).Focus()
        ElseIf TypeOf (obj) Is CheckBox Then
            'ExtCheckBox.pasarDato(obj)
        ElseIf TypeOf (obj) Is DateTimePicker Then
            'ExtDateTimePicker.pasarDato(obj)
        ElseIf TypeOf (obj) Is GroupBox Then
            Gb.pasarCursor(CType(obj, GroupBox))
        ElseIf TypeOf (obj) Is RadioButton Then
            'ExtGroupBox.pasarCursor(obj)
        End If
    End Sub

    Shared Sub pierdeFoco(ByVal ctrlActual As Control)
        If TypeOf (ctrlActual) Is TextBox Then
            CType(ctrlActual, TextBox).BackColor = Drawing.Color.White
        ElseIf TypeOf (ctrlActual) Is ComboBox Then
            CType(ctrlActual, ComboBox).BackColor = Drawing.Color.White
        ElseIf TypeOf (ctrlActual) Is RadioButton Then
            CType(ctrlActual, RadioButton).ForeColor = Drawing.Color.Black
            'CType(ctrlActual, RadioButton).Font = Nothing
        End If
    End Sub

    Shared Sub ganaFoco(ByVal ctrlActual As Control)
        If TypeOf (ctrlActual) Is TextBox Then
            CType(ctrlActual, TextBox).BackColor = Drawing.Color.Gainsboro
        ElseIf TypeOf (ctrlActual) Is ComboBox Then
            CType(ctrlActual, ComboBox).BackColor = Drawing.Color.Gainsboro
        ElseIf TypeOf (ctrlActual) Is RadioButton Then
            CType(ctrlActual, RadioButton).ForeColor = Drawing.Color.Blue
            'CType(ctrlActual, RadioButton).Font=  'New Font(CType(ctrlActual, RadioButton).Font, FontStyle.Underline)
        End If

    End Sub
End Class
