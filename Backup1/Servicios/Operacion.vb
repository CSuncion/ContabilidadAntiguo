Public Class Operacion

    Public Ctrl As New List(Of Control)

    Public Sub PasarCursor_ArribaAbajo(ByRef lista As List(Of Control))
        Ctrl = lista
        For n As Integer = 0 To lista.Count - 1
            AddHandler lista.Item(n).KeyDown, AddressOf PasarCursor
        Next

    End Sub

    Public Sub ObtenerFoco(ByRef lista As List(Of Control))
        ' Ctrl = lista
        For n As Integer = 0 To lista.Count - 1
            AddHandler lista.Item(n).GotFocus, AddressOf ganaFoco
            AddHandler lista.Item(n).LostFocus, AddressOf pierdeFoco
        Next
    End Sub



    Sub PasarCursor(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        '/Obtener el TabIndex del control actual
        Dim indCtrl As Integer = CType(sender, Control).TabIndex

        '/Saber que tipo de control es
        If TypeOf (sender) Is TextBox Then

            Select Case e.KeyCode

                Case Keys.Enter, Keys.Down
                    For Each ct As Control In Ctrl
                        If ct.TabIndex = indCtrl + 1 Then
                            ct.Focus()
                        End If
                    Next

                Case Keys.Up
                    For Each ct As Control In Ctrl
                        If ct.TabIndex = indCtrl - 1 Then
                            ct.Focus()
                        End If
                    Next

                Case Keys.Delete 'Cuando pulsas la tecla suprimir
                    CType(sender, TextBox).Text = ""

            End Select

        ElseIf TypeOf (sender) Is ComboBox Or TypeOf (sender) Is DomainUpDown Or TypeOf (sender) Is DateTimePicker Then

            Select Case e.KeyCode

                Case Keys.Enter
                    For Each ct As Control In Ctrl
                        If ct.TabIndex = indCtrl + 1 Then
                            ct.Focus()
                        End If
                    Next

                Case Keys.ShiftKey

                    For Each ct As Control In Ctrl
                        If ct.TabIndex = indCtrl - 1 Then
                            ct.Focus()
                        End If
                    Next

            End Select

        ElseIf TypeOf (sender) Is RadioButton Then
            indCtrl = CType(sender, RadioButton).Parent.TabIndex
            Select Case e.KeyCode

                Case Keys.Enter

                    For Each ct As Control In Ctrl
                        If ct.TabIndex = indCtrl + 1 Then
                            ct.Focus()
                        End If
                    Next

                Case Keys.ShiftKey

                    For Each ct As Control In Ctrl
                        If ct.TabIndex = indCtrl - 1 Then
                            ct.Focus()
                        End If
                    Next

            End Select

        ElseIf TypeOf (sender) Is Button Then

            Select Case e.KeyCode

                Case Keys.Down
                    For Each ct As Control In Ctrl
                        If ct.TabIndex = indCtrl + 1 Then
                            ct.Focus()
                        End If
                    Next

                Case Keys.Up
                    For Each ct As Control In Ctrl
                        If ct.TabIndex = indCtrl - 1 Then
                            ct.Focus()
                        End If
                    Next

            End Select


        End If






    End Sub

    Sub ganaFoco(ByVal sender As Object, ByVal e As System.EventArgs)
        If TypeOf (sender) Is TextBox Then
            CType(sender, TextBox).BackColor = Drawing.Color.Gainsboro
            Txt.cursorAlUltimo(CType(sender, TextBox))
        ElseIf TypeOf (sender) Is ComboBox Then
            CType(sender, ComboBox).BackColor = Drawing.Color.Gainsboro
        ElseIf TypeOf (sender) Is RadioButton Then
            CType(sender, RadioButton).ForeColor = Drawing.Color.Blue
        ElseIf TypeOf (sender) Is GroupBox Then
            Gb.pasarCursor(CType(sender, GroupBox))
        End If

    End Sub

    Sub pierdeFoco(ByVal sender As Object, ByVal e As System.EventArgs)
        If TypeOf (sender) Is TextBox Then
            CType(sender, TextBox).BackColor = Drawing.Color.White
        ElseIf TypeOf (sender) Is ComboBox Then
            CType(sender, ComboBox).BackColor = Drawing.Color.White
        ElseIf TypeOf (sender) Is RadioButton Then
            CType(sender, RadioButton).ForeColor = Drawing.Color.Black
        ElseIf TypeOf (sender) Is GroupBox Then
            'Gb.pasarCursor(CType(sender, GroupBox))
        End If

    End Sub
End Class
