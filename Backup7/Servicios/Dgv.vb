Imports Entidad
Public Class Dgv

    Shared Sub enumerarFilasDGV(ByRef Dgv As DataGridView)
        Dgv.RowHeadersWidth = 60

        For G As Integer = 0 To Dgv.RowCount - 1
            Dgv.Rows(G).HeaderCell.Value = (G + 1).ToString ' para que comience en el 1
            Dgv.RowHeadersDefaultCellStyle.NullValue = False
        Next

    End Sub

    Shared Sub enumerarFilasDGV(ByRef Dgv As DataGridView, ByRef r As String)
        Dgv.RowHeadersWidth = 60
        If Dgv.RowCount = 1 Then
            Exit Sub
        Else
            For G As Integer = 0 To Dgv.RowCount - 2
                Dgv.Rows(G).HeaderCell.Value = (G + 1).ToString ' para que comience en el 1
                Dgv.RowHeadersDefaultCellStyle.NullValue = False
            Next

        End If
        
    End Sub

    Shared Sub Buscar(ByRef Dgv As DataGridView, ByRef colBus As String, ByRef texto As String)

        'OBTENEMOS EL NUMERO DE REGISTROS DE LA GRILLA
        Dim nReg As Integer = Dgv.Rows.Count

        'VARIABLE PARA TOMAR CADA VALOR DE LA CELDA DE LA COLUMNA DE BUSQUEDA
        Dim valCel As String = String.Empty

        'PASAMOS EL TEXTO DE BUSQUEDA A MAYUSCULA
        Dim valTxt As String = texto.Trim.ToUpper

        'SI NO HAY REGISTROS EN LA GRILLA -->> SALE
        'SI NO HAY COLUMNAS EN LA GRILLA -->> SALE
        If Dgv.RowCount = 0 Or Dgv.ColumnCount = 0 Then Exit Sub

        'RECORREMOS CADA CELDA DE LA COLUMNA DE BUSQUEDA
        For n As Integer = 0 To nReg - 1
            valCel = Dgv.Item(colBus, n).Value.ToString.Trim.ToUpper

            'COMPARAMOS SI SON IGUALES
            If valTxt = valCel Then
                Dgv.CurrentCell = Dgv.Item(colBus, n)
                Exit Sub
            End If
        Next
    End Sub



    Shared Sub Buscar(ByRef Dgv As DataGridView, ByRef colBus As Integer, ByRef texto As String)

        'OBTENEMOS EL NUMERO DE REGISTROS DE LA GRILLA
        Dim nReg As Integer = Dgv.Rows.Count

        'VARIABLE PARA TOMAR CADA VALOR DE LA CELDA DE LA COLUMNA DE BUSQUEDA
        Dim valCel As String = String.Empty

        'PASAMOS EL TEXTO DE BUSQUEDA A MAYUSCULA
        Dim valTxt As String = texto.Trim.ToUpper

        'SI NO HAY REGISTROS EN LA GRILLA -->> SALE
        'SI NO HAY COLUMNAS EN LA GRILLA -->> SALE
        If Dgv.RowCount = 0 Or Dgv.ColumnCount = 0 Then Exit Sub

        'RECORREMOS CADA CELDA DE LA COLUMNA DE BUSQUEDA
        For n As Integer = 0 To nReg - 1
            valCel = Dgv.Item(colBus, n).Value.ToString.Trim.ToUpper

            'COMPARAMOS SI SON IGUALES
            If valTxt = valCel Then
                Dgv.CurrentCell = Dgv.Item(colBus, n)
                Exit Sub
            End If
        Next
    End Sub




    Shared Sub refrescarFuenteDatosGrilla(ByRef Dgv As DataGridView, ByRef lista As List(Of SuperEntidad))
        '//
        Dgv.DataSource = Nothing
        Dgv.Columns.Clear()
        Dgv.AutoGenerateColumns = False
        Dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Dgv.AllowUserToResizeRows = False
        Dgv.MultiSelect = False
        Dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'Dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Dgv.AllowUserToResizeColumns = True
        Dgv.ReadOnly = False
        '/Pasamos la fuente de datos
        Dgv.DataSource = lista
        '\\
    End Sub



    Shared Sub refrescarFuenteDatosGrilla(ByRef Dgv As DataGridView, ByVal lista As Object)
        '//
        Dgv.DataSource = Nothing
        Dgv.Columns.Clear()
        Dgv.AutoGenerateColumns = False
        Dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Dgv.AllowUserToResizeRows = False
        Dgv.MultiSelect = False
        Dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'Dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Dgv.AllowUserToResizeColumns = True
        Dgv.ReadOnly = False
        '/Pasamos la fuente de datos
        Dgv.DataSource = lista
        '\\
    End Sub


    Shared Sub asignarColumnaText(ByRef Dgv As DataGridView, ByRef campoPropiedad As String, ByRef encabezado As String, ByRef Tamaño As Integer)
        '//
        Dim col As DataGridViewColumn
        col = New DataGridViewTextBoxColumn
        col.DataPropertyName = campoPropiedad
        col.Name = campoPropiedad
        col.HeaderText = encabezado
        col.Width = Tamaño
        col.ReadOnly = True
        Dgv.Columns.Add(col)
        '\\
    End Sub

    Shared Sub asignarColumnaTextVis(ByRef Dgv As DataGridView, ByRef campoPropiedad As String, ByRef encabezado As String, ByRef Tamaño As Integer, ByRef visible As Integer)
        '//
        Dim col As DataGridViewColumn
        col = New DataGridViewTextBoxColumn
        col.DataPropertyName = campoPropiedad
        col.Name = campoPropiedad
        col.HeaderText = encabezado
        col.Width = Tamaño
        If visible = 1 Then
            col.Visible = True
        Else
            col.Visible = False
        End If
        Dgv.Columns.Add(col)
        '\\
    End Sub

    Shared Sub asignarColumnaTextExp(ByRef Dgv As DataGridView, ByRef campoPropiedad As String, ByRef encabezado As String, ByRef Tamaño As Integer)
        '//
        Dim col As DataGridViewColumn
        col = New DataGridViewTextBoxColumn
        col.DataPropertyName = campoPropiedad
        col.Name = campoPropiedad
        col.HeaderText = encabezado
        col.Width = Tamaño
        col.DividerWidth = Tamaño
        Dgv.Columns.Add(col)
        '\\
    End Sub




    Shared Function obtenerNumeroRegistros(ByRef Dgv As DataGridView) As String
        '//
        Dim numRegs As Integer = Dgv.Rows.Count
        If numRegs = 0 Then
            Return "0"
        Else
            Return numRegs.ToString
        End If
        '\\
    End Function



    Shared Sub desplazamientoFila(ByRef Dgv As DataGridView, ByRef boton As ToolStripButton)
        '//
        If Dgv.Rows.Count = 0 Then
            Exit Sub
        Else
            Dim indiceFila As Integer
            indiceFila = Dgv.CurrentRow.Index
            Dim maxIndex As Integer = Dgv.RowCount - 1
            Select Case boton.Name
                Case "btnPrimero" : indiceFila = 0
                Case "btnAnterior" : indiceFila -= 1 : If indiceFila < 0 Then : indiceFila = 0 : End If
                Case "btnSiguiente" : indiceFila += 1 : If indiceFila > maxIndex Then : indiceFila = maxIndex : End If
                Case "btnUltimo" : indiceFila = maxIndex
            End Select
            Dgv.CurrentCell = Dgv.Item(0, indiceFila)
        End If
        '\\
    End Sub

    Shared Sub buscarEnColumna(ByRef Dgv As DataGridView, ByRef columnaBusqueda As String, ByRef texto As String)
        '//
        Dim itemValue As String
        If Dgv.RowCount = 0 Or Dgv.ColumnCount = 0 Then
            Exit Sub
        Else
            If texto.Trim = "" Then
                Dgv.CurrentCell = Dgv.Item(columnaBusqueda, 0)
                Exit Sub
            Else
                For n As Integer = 0 To Dgv.RowCount - 1
                    itemValue = Dgv.Item(columnaBusqueda, n).Value.ToString
                    If itemValue.Length >= texto.Trim.Length Then
                        If itemValue.Substring(0, texto.Trim.Length).ToLower = texto.Trim.ToLower Then
                            Dgv.CurrentCell = Dgv.Item(columnaBusqueda, n)
                            Exit Sub
                        End If
                    End If
                Next
            End If
        End If
        '\\
    End Sub

    Shared Sub buscarEnColumna(ByRef Dgv As DataGridView, ByRef columnaBusqueda As Integer, ByRef texto As String)
        '//
        Dim itemValue As String
        If Dgv.RowCount = 0 Then
            Exit Sub
        Else
            If texto.Trim = "" Then
                Dgv.CurrentCell = Dgv.Item(columnaBusqueda, 0)
                Exit Sub
            Else
                For n As Integer = 0 To Dgv.RowCount - 1
                    itemValue = Dgv.Item(columnaBusqueda, n).Value.ToString
                    If itemValue.Length >= texto.Trim.Length Then
                        If itemValue.Substring(0, texto.Trim.Length).ToLower = texto.Trim.ToLower Then
                            Dgv.CurrentCell = Dgv.Item(columnaBusqueda, n)
                            Exit Sub
                        End If
                    End If
                Next
            End If
        End If
        '\\
    End Sub

    Shared Sub pintarColumnaDgv(ByRef Dgv As DataGridView, ByRef nombreColumna As String)
        '//
        If Dgv.Rows.Count = 0 Then
            Exit Sub
        Else
            If Dgv.Columns(nombreColumna).SortMode = DataGridViewColumnSortMode.Automatic Then
                Dim numCol As Integer = Dgv.Columns.Count - 1
                For n As Integer = 0 To numCol
                    Dgv.Columns(n).DefaultCellStyle.BackColor = Drawing.Color.White
                Next
                Dgv.Columns(nombreColumna).DefaultCellStyle.BackColor = Drawing.Color.Gainsboro
            End If
        End If
        '\\
    End Sub

    Shared Sub pintarColumnaDgv(ByRef Dgv As DataGridView, ByRef indiceColumna As Integer)
        '//
        If Dgv.Rows.Count = 0 Then
            Exit Sub
        Else
            If Dgv.Columns(indiceColumna).SortMode = DataGridViewColumnSortMode.Automatic Then
                Dim numCol As Integer = Dgv.Columns.Count - 1
                For n As Integer = 0 To numCol
                    Dgv.Columns(n).DefaultCellStyle.BackColor = Drawing.Color.White
                Next
                Dgv.Columns(indiceColumna).DefaultCellStyle.BackColor = Drawing.Color.Gainsboro
            End If
        End If
        '\\
    End Sub

    Shared Sub estadoBotonesAccion(ByRef Dgv As DataGridView, ByRef lista As List(Of ToolStripButton))
        '//
        Dim nRegs As Integer = Dgv.Rows.Count
        '/Habilita o deshabilita los controles segun estado DgvUsu
        If nRegs = 0 Then
            habilitarBotonesAccion(lista, False)
        Else
            habilitarBotonesAccion(lista, True)
        End If
        '\\
    End Sub

    Shared Sub habilitarBotonesAccion(ByRef lista As List(Of ToolStripButton), ByRef valor As Boolean)
        '//
        Dim btn As New ToolStripButton
        For Each btn In lista
            btn.Enabled = valor
        Next
        '\\
    End Sub

    Shared Sub estadoBotonesDesplazar(ByRef Dgv As DataGridView, ByRef lista As List(Of ToolStripButton))
        '//
        Dim nRegs As Integer = Dgv.Rows.Count
        If nRegs = 0 Or nRegs = 1 Then
            habilitarBotonesDesplazar(lista, False, False)
        Else
            Dim indiceFila As Integer = Dgv.CurrentRow.Index
            Dim maxIndice As Integer = nRegs - 1
            Select Case indiceFila
                Case 0 : habilitarBotonesDesplazar(lista, False, True)
                Case maxIndice : habilitarBotonesDesplazar(lista, True, False)
                Case Else : habilitarBotonesDesplazar(lista, True, True)
            End Select
        End If
        '\\
    End Sub

    Shared Sub habilitarBotonesDesplazar(ByRef lista As List(Of ToolStripButton), ByRef valo1 As Boolean, ByRef valor2 As Boolean)
        '//
        '/btnPrimero
        lista.Item(0).Enabled = valo1
        '/btnAnterior
        lista.Item(1).Enabled = valo1
        '/btnSiguiente
        lista.Item(2).Enabled = valor2
        '/btnUltimo
        lista.Item(3).Enabled = valor2
        '\\
    End Sub

    Shared Sub obtenerCursorActual(ByRef Dgv As DataGridView, ByRef cCursor As String, ByRef lista As List(Of SuperEntidad))
        '//
        Dim n As Integer = 0
        For Each ob As SuperEntidad In lista
            If ob.CampoCursor = cCursor Then
                Dgv.CurrentCell = Dgv.Item(0, n)
                Exit Sub
            End If
            n += 1
        Next
        '\\
    End Sub

    Shared Sub actualizarBarraEstado(ByRef sts As StatusStrip, ByRef Dgv As DataGridView)
        '//
        sts.Items("lblUsu").Text = SuperEntidad.xCodigoUsuario
        'sts.Items("lblGru").Text = SuperEntidad.xNombreGrupo
        sts.Items("lblRgs").Text = obtenerNumeroRegistros(Dgv)
        sts.Items("lblEmp").Text = SuperEntidad.xRazonSocial
        sts.Items("lblPer").Text = SuperEntidad.xPeriodoEmpresa
        '\\
    End Sub

    Shared Function obtenerValorCelda(ByRef Dgv As DataGridView, ByRef indiceColumna As Integer) As String
              '//

        If Dgv.Columns.Count = 1 Or Dgv.RowCount = 0 Then Return ""

        Dim indFil As Integer = Dgv.CurrentRow.Index
        Dim valor As String = Dgv.Item(indiceColumna, indFil).Value.ToString

        Return valor
        '\\
    End Function

    Shared Function obtenerValorCelda(ByRef Dgv As DataGridView, ByRef NombreColumna As String) As String
        '//
        If Dgv.Columns.Count = 1 Or Dgv.RowCount = 0 Then Return ""
        Dim indFil As Integer = Dgv.CurrentRow.Index
        Dim valor As String = Dgv.Item(NombreColumna, indFil).Value.ToString
        Return valor
        '\\
    End Function


    Shared Sub BusquedaInteligenteEnColumna(ByRef ctrlDgv As DataGridView, ByRef columnaBusqueda As String, ByRef ctrlText As TextBox, ByVal e As System.Windows.Forms.KeyEventArgs)
        'Que tecla se presiono
        Select Case e.KeyCode
            Case Keys.Up
                Dgv.DesplazamientoFila(ctrlDgv, "btnAnterior")
                'ctrlText.Text = Dgv.ObtenerValorCelda(ctrlDgv, columnaBusqueda)
                Txt.cursorAlUltimo(ctrlText)
            Case Keys.Down
                Dgv.DesplazamientoFila(ctrlDgv, "btnSiguiente")
                'ctrlText.Text = Dgv.ObtenerValorCelda(ctrlDgv, columnaBusqueda)
                Txt.cursorAlUltimo(ctrlText)
            Case Else
                Dim texto As String = ctrlText.Text.Trim
                buscarEnColumna(ctrlDgv, columnaBusqueda, texto)
        End Select
    End Sub


    Shared Sub DesplazamientoFila(ByRef ctrlDgv As DataGridView, ByRef nombreBoton As String)
        '/
        If ctrlDgv.Rows.Count = 0 Then
            Exit Sub
        Else
            Dim indiceFila As Integer
            indiceFila = ctrlDgv.CurrentRow.Index
            Dim maxIndex As Integer = ctrlDgv.RowCount - 1
            Select Case nombreBoton
                Case "btnPrimero" : indiceFila = 0
                Case "btnAnterior" : indiceFila -= 1 : If indiceFila < 0 Then : indiceFila = 0 : End If
                Case "btnSiguiente" : indiceFila += 1 : If indiceFila > maxIndex Then : indiceFila = maxIndex : End If
                Case "btnUltimo" : indiceFila = maxIndex
            End Select
            ctrlDgv.CurrentCell = ctrlDgv.Item(0, indiceFila)
        End If
        '/
    End Sub

    Public Shared Sub AsignarColumnaTextNumerico(ByRef Dgv As DataGridView, ByRef CampoPropiedad As String, ByRef Encabezado As String, ByRef Tamaño As Integer, ByRef Decimales As Integer)
        '/
        Dim col As DataGridViewColumn
        col = New DataGridViewTextBoxColumn
        col.DataPropertyName = CampoPropiedad
        col.Name = CampoPropiedad
        col.HeaderText = Encabezado
        col.Width = Tamaño
        'Alineamos los datos hacia la derecha
        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'Validar el numero de decimales(solo de 0 a 5 decimales)
        Dim numDec As String = Decimales.ToString
        If Varios.LimiteMinMaxDeValores(numDec, 0, 5) = True Then
            col.DefaultCellStyle.Format = "N" & numDec
        End If
        col.ReadOnly = True
        Dgv.Columns.Add(col)
        '/
    End Sub

    Shared Sub asignarColumnaCheckBox(ByRef Dgv As DataGridView, ByRef campoPropiedad As String, ByRef encabezado As String, ByRef Tamaño As Integer)
        '//
        Dim col As DataGridViewColumn
        col = New DataGridViewCheckBoxColumn
        'col.DataPropertyName = campoPropiedad
        col.Name = campoPropiedad
        col.HeaderText = encabezado
        col.Width = Tamaño
        col.ReadOnly = False

        Dgv.Columns.Add(col)
        '\\
    End Sub

    Shared Sub PonerFranja(ByRef dgv As DataGridView, ByVal ifil As Integer)
        Dim nreg As Integer = dgv.Rows.Count
        If nreg = 0 Then Exit Sub
        If ifil = nreg Then
            dgv.CurrentCell = dgv.Item(0, ifil - 1)
            Exit Sub
        End If
        dgv.CurrentCell = dgv.Item(0, ifil)
    End Sub

    Shared Function ObtenerIndiceFila(ByRef dgv As DataGridView) As Integer
        Dim valor As Integer
        If dgv.Rows.Count = 0 Then
            valor = 0
        Else
            valor = dgv.CurrentRow.Index
        End If
        Return valor
    End Function


    Shared Function ObtenerNumeroOcurenciasDeValor(ByRef pDgv As DataGridView, ByVal pNombreColumna As String, ByVal pValorBusqueda As String) As Integer
        'OBTIENE EL NUMERO DE OCURRENCIAS DEL VALOR DENTRO DEL COLUMNA DE BUSQUEDA
        Dim iNumeroOcurrencias As Integer = 0

        'SE USO -2 POR QUE ESTAS GRILLAS TIENEN EL ULTIMO REGISTRO EN BLANCO(LUEGO SE ACTUALIZARA A -1)
        For n As Integer = 0 To pDgv.Rows.Count - 2
            If pDgv.Rows(n).Cells(pNombreColumna).Value.ToString = pValorBusqueda Then
                iNumeroOcurrencias += 1
            End If
        Next

        Return iNumeroOcurrencias
    End Function



    Shared Function SumarColumna(ByRef pDgv As DataGridView, ByVal pNombreColumna As String) As Decimal
        'OBTIENE LA SUMA ACUMULADA DE LA COLUMNA ESPECIFICADA
        Dim iSuma As Decimal = 0

        'SE USO -2 POR QUE ESTAS GRILLAS TIENEN EL ULTIMO REGISTRO EN BLANCO(LUEGO SE ACTUALIZARA A -1)
        For n As Integer = 0 To pDgv.Rows.Count - 2
            iSuma += CType(pDgv.Rows(n).Cells(pNombreColumna).Value.ToString, Decimal)
        Next

        Return iSuma
    End Function

    Shared Function SumarColumna(ByRef pDgv As DataGridView, ByVal pNombreColumna As String, ByVal pTodosRegsitros As String) As Decimal
        'OBTIENE LA SUMA ACUMULADA DE LA COLUMNA ESPECIFICADA
        Dim iSuma As Decimal = 0

        'SE USO -2 POR QUE ESTAS GRILLAS TIENEN EL ULTIMO REGISTRO EN BLANCO(LUEGO SE ACTUALIZARA A -1)
        For n As Integer = 0 To pDgv.Rows.Count - 1
            iSuma += CType(pDgv.Rows(n).Cells(pNombreColumna).Value.ToString, Decimal)
        Next

        Return iSuma
    End Function


    Shared Function ObtenerIndiceFila(ByRef pDgv As DataGridView, ByVal pNombreColumna As String, ByVal pValorBusqueda As String) As Integer
        'OBTIENE EL INDICE FILA DEL VALOR DENTRO DEL COLUMNA DE BUSQUEDA
        Dim iIndiceFila As Integer = -1

        'SE USO -2 POR QUE ESTAS GRILLAS TIENEN EL ULTIMO REGISTRO EN BLANCO(LUEGO SE ACTUALIZARA A -1)
        For n As Integer = 0 To pDgv.Rows.Count - 2
            If pDgv.Rows(n).Cells(pNombreColumna).Value.ToString = pValorBusqueda Then
                iIndiceFila = n
            End If
        Next

        Return iIndiceFila
    End Function

End Class
