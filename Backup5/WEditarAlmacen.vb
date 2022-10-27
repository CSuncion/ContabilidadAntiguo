Imports Entidad
Imports Negocio

Public Class WEditarAlmacen
#Region "Propietarios"
    Public wAlm As New WAlmacen
#End Region
    Public ent As New SuperEntidad
    Public lista As New List(Of SuperEntidad)
    Public tab As New TablaRN
    Public alm As New AlmacenRN
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

    Sub ventanaAdicionar()
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Agregar " + Me.wAlm.titulo
        acc.LimpiarControles()
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.TxtCodItem)
        'los controles que deben estar activos
        acc.Nuevo()
        '\\
    End Sub

    Sub ventanaModificar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Modificar " + Me.wAlm.titulo
        'mostrar el registro en pantalla
        Me.obtenerAlmacenEnPantalla(codigo)
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.TxtNomItem)
        'los controles que deben estar activos
        acc.Modificar()
        '\\
    End Sub

    Sub ventanaEliminar(ByRef codigo As String)
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Eliminar " + Me.wAlm.titulo
        'mostrar el registro en pantalla
        Me.obtenerAlmacenEnPantalla(codigo)
        'cambiar el nombre del boton
        Me.btnAceptar.Text = "Eliminar"
        'foco
        Me.btnAceptar.Focus()
        'los controles que deben estar activos
        acc.Eliminar()
    End Sub

    Sub ventanaVisualizar(ByRef codigo As String)
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Visualizar " + Me.wAlm.titulo
        'mostrar el registro en pantalla
        Me.obtenerAlmacenEnPantalla(codigo)
        'los controles que deben estar activos
        'foco
        Me.btnAceptar.Focus()
        acc.Visualizar()
    End Sub

    Sub obtenerAlmacenEnPantalla(ByRef codigo As String)
        '//
        ent.CodigoAlmacen = codigo
        ent = alm.buscarAlmacenExisPorCodigo(ent)
        'preguntar si ent tiene el registro
        If ent.CodigoAlmacen = "" Then
            Exit Sub
        Else
            '/Pasar Datos a los controles
            Me.TxtCodItem.Text = ent.CodigoAlmacen
            Me.TxtNomItem.Text = ent.NombreAlmacen
            Me.TxtColor.Text = ent.ColorAlmacen
            Me.TxtMedida.Text = ent.MedidasAlmacen
            Me.TxtSerie.Text = ent.SerieAlmacen
            Me.TxtMarca.Text = ent.MarcaAlmacen

        End If
        '\\
    End Sub

    Sub Aceptar()
        '//
        If Me.operacion = 1 Or Me.operacion = 2 Then
            'Volver a traer el registro 
            ent.CodigoAlmacen = Me.TxtCodItem.Text.Trim
            ' ent.DatoCondicion1 = Me.txtCodAux.Text.Trim
            ent = alm.buscarAlmacenExisPorCodigo(ent)
        End If

        ent.CodigoAlmacen = Me.TxtCodItem.Text.Trim
        ent.NombreAlmacen = Me.TxtNomItem.Text.Trim
        ent.ColorAlmacen = Me.TxtColor.Text.Trim
        ent.MedidasAlmacen = Me.TxtMedida.Text.Trim
        ent.SerieAlmacen = Me.TxtSerie.Text.Trim
        ent.MarcaAlmacen = Me.TxtMarca.Text.Trim
        ent.EstadoAlmacen = "0"
        ent.Exporta = "0"

        '/Se graba o0 se modifica?
        Select Case Me.operacion

            Case 0
                alm.nuevoAlmacen(ent)
                MsgBox("Item del Almacen Ingresado Correctamente", MsgBoxStyle.Information)
                'acc.LimpiarControles()
                acc.LimpiarControles()
                Txt.cursorAlUltimo(Me.TxtCodItem)

            Case 1
                alm.modificarAlmacen(ent)
                MsgBox("Item Modificado Correctamente", MsgBoxStyle.Information)
                Me.Close()

            Case 2
                alm.eliminarAlmacenFis(ent)
                MsgBox("Item Eliminado Correctamente", MsgBoxStyle.Information)
                Me.Close()

        End Select
        '/Actualizar y buscar el registro grabado
        Me.wAlm.ActualizarVentana()
        Dgv.obtenerCursorActual(Me.wAlm.DgvAlm, ent.NombreAlmacen, Me.wAlm.lista)
        '\\
    End Sub

#End Region

    Private Sub WEditarAuxiliar_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Me.Text = "Eliminar Persona Natural" Then
            Me.Aceptar()
            Exit Sub
        End If

        If acc.CamposObligatorios = False Then
            Exit Sub
        Else
            Me.Aceptar()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If Me.Text = "Visualizar Persona Natural" Then
            Me.Close()
        Else
            Dim rpta As Integer = MsgBox("Deseas Cancelar La Operacion", MsgBoxStyle.YesNo)
            If rpta = MsgBoxResult.Yes Then
                Me.Close()
            Else
                Exit Sub
            End If
        End If
    End Sub


#Region "Existe Codigo"
    Private Sub txtCodItem_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCodItem.Validated
        '    If Me.operacion = 0 Then
        '        Dim cod As String = Me.txtCodAux.Text.Trim
        '        If cod = "" Then
        '            Exit Sub
        '        Else
        '            Dim obj As New SuperEntidad
        '            obj.DatoCondicion1 = cod
        '            'Se busca en toda la tabla Usuario
        '            If aux.existeAuxiliarPorCodigo(obj) = True Then
        '                MsgBox("Esta Persona Natural Ya Existe", MsgBoxStyle.Information)
        '                Me.txtCodAux.Text = ""
        '                Me.txtCodAux.Focus()
        '            Else
        '                Exit Sub
        '            End If
        '        End If
        '    End If

    End Sub

#End Region

    'Private Sub txtNomItem_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtApePatAux.Validated, TxtApeMatAux.Validated, TxtPriNomAux.Validated, TxtSegNomAux.Validated
    '    Me.txtNomAux.Text = Me.TxtApePatAux.Text.Trim + Space(1) + Me.TxtApeMatAux.Text.Trim + Space(1) + Me.TxtPriNomAux.Text.Trim + Space(1) + Me.TxtSegNomAux.Text.Trim
    'End Sub

End Class