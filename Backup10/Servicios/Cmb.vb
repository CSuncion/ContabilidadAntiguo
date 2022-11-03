Imports Entidad
Public Class Cmb
    Public Enum Elemento
        Primero = 0
        Ultimo
    End Enum

    Shared Sub CargarItems(ByRef cmb As ToolStripComboBox, ByRef lista As List(Of String))
        cmb.DropDownStyle = ComboBoxStyle.DropDownList
        'CARGAR LA LISTA DE CADENAS AL TOOLSTRIPCOMBOBOX
        For Each xStr As String In lista
            cmb.Items.Add(xStr)
        Next
        'SI EL COMBO TIENE ITEMS ENTONCES MOSTRAR AL PRIMERO
        If cmb.Items.Count <> 0 Then
            cmb.SelectedIndex = 0
        End If
    End Sub

    Shared Sub CargarItems(ByRef cmb As ToolStripComboBox, ByRef lista As List(Of String), ByVal Posicion As Elemento)
        CargarItems(cmb, lista)
        'VER LA POSICION DEL ELEMENTO QUE SE DESEA VER POR DEFECTO
        If Posicion = Elemento.Ultimo Then
            If cmb.Items.Count <> 0 Then
                cmb.SelectedIndex = cmb.Items.Count - 1
            End If
        End If
    End Sub
    'Shared Sub CargarItems(ByRef cmb As ToolStripComboBox, ByRef lista As List(Of String))
    '    cmb.DropDownStyle = ComboBoxStyle.DropDownList
    '    'CARGAR LA LISTA DE CADENAS AL TOOLSTRIPCOMBOBOX
    '    For Each xStr As String In lista
    '        cmb.Items.Add(xStr)
    '    Next
    '    'SI EL COMBO TIENE ITEMS ENTONCES MOSTRAR AL PRIMERO
    '    If cmb.Items.Count <> 0 Then
    '        cmb.SelectedIndex = 0
    '    End If
    'End Sub

    Shared Sub Cargar(ByRef cmb As ComboBox, ByRef lista As List(Of SuperEntidad), ByRef value As String, ByRef display As String)
        '//
        cmb.DropDownStyle = ComboBoxStyle.DropDownList
        cmb.DataSource = lista
        cmb.ValueMember = value
        cmb.DisplayMember = display
        '\\
    End Sub

    Shared Sub CargarDig(ByRef cmb As ComboBox, ByRef lista As List(Of SuperEntidad), ByRef value As String, ByRef display As String)
        '//
        cmb.DropDownStyle = ComboBoxStyle.DropDown
        cmb.DataSource = lista
        cmb.ValueMember = value
        cmb.DisplayMember = display
        '\\
    End Sub

    Public Shared Sub obtElemento(ByRef cmb As ComboBox, ByRef valor As String)
        Dim n As Integer
        'recorrer todos los elementos del combo
        For n = 0 To Cmb.Items.Count - 1
            Cmb.SelectedIndex = n
            'si se halla el valor buscado se sale del metodo
            If cmb.SelectedValue.ToString = valor Then
                Exit Sub
            End If
        Next
        'si no se encontro el valor el text del combo se queda en blanco
        Cmb.SelectedIndex = -1
    End Sub

    Public Shared Sub ganaFoco(ByRef obj As ComboBox)
        obj.BackColor = Drawing.Color.LightSkyBlue
        obj.FlatStyle = FlatStyle.Popup
    End Sub

    Public Shared Sub pierdeFoco(ByRef obj As ComboBox)
        obj.BackColor = Drawing.Color.White
        obj.FlatStyle = FlatStyle.Standard
    End Sub

    Shared Sub Limpiar(ByRef obj As ComboBox, ByRef defecto As String)
        'obj.SelectedText = defecto
        If obj.Items.Count = 0 Then
            Exit Sub
        Else
            obj.SelectedIndex = 0
        End If

    End Sub

    Shared Sub HabilitarSegunOperacion(ByRef obj As ComboBox, ByRef act As String)
        If act = "1" Then
            obj.Enabled = True
        Else
            obj.Enabled = False
        End If
        'obj.SelectedIndex = 0
    End Sub

    Shared Function CampoObligatorio(ByRef obj As ComboBox, ByRef mensaje As String) As Boolean
        If obj.Text.Trim = "" Then
            MsgBox("no dejar en blanco / Campo: " + mensaje, MsgBoxStyle.Critical)
            obj.Focus()
            Return False
        Else
            Return True
        End If
    End Function

End Class
