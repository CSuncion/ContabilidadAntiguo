Imports Entidad
Imports Negocio
Public Class WEditarAuxiliar
#Region "Propietarios"
    Public wAux As New WAuxiliar
#End Region
    Public ent As New SuperEntidad
    Public lista As New List(Of SuperEntidad)
    Public tab As New TablaRN
    Public aux As New AuxiliarRN
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
        Me.Text = "Agregar " + Me.wAux.titulo
        acc.LimpiarControles()
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtCodAux)
        'los controles que deben estar activos
        acc.Nuevo()
        '\\
    End Sub

    Sub ventanaModificar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Modificar " + Me.wAux.titulo
        'mostrar el registro en pantalla
        Me.obtenerAuxiliarEnPantalla(codigo)
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtNomAux)
        'los controles que deben estar activos
        acc.Modificar()
        '\\
    End Sub

    Sub ventanaEliminar(ByRef codigo As String)
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Eliminar " + Me.wAux.titulo
        'mostrar el registro en pantalla
        Me.obtenerAuxiliarEnPantalla(codigo)
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
        Me.Text = "Visualizar " + Me.wAux.titulo
        'mostrar el registro en pantalla
        Me.obtenerAuxiliarEnPantalla(codigo)
        'los controles que deben estar activos
        acc.Visualizar()
    End Sub

    Sub obtenerAuxiliarEnPantalla(ByRef codigo As String)
        '//
        ent.CodigoAuxiliar = codigo
        ent = aux.buscarAuxiliarExisPorCodigo(ent)
        'preguntar si ent tiene el registro
        If ent.CodigoAuxiliar = "" Then
            Exit Sub
        Else
            '/Pasar Datos a los controles
            Me.txtCodAux.Text = ent.CodigoAuxiliar
            Me.txtNomAux.Text = ent.DescripcionAuxiliar
            Me.txtDirAux.Text = ent.DireccionAuxiliar
            Me.txtTelAux.Text = ent.TelefonoAuxiliar
            Me.txtCelAux.Text = ent.CelularAuxiliar
            Me.txtCorAux.Text = ent.CorreoAuxiliar
            Me.txtRefAux.Text = ent.ReferenciaAuxiliar
            Gb.pasarDato(Me.gbTipAux, ent.TipoAuxiliar)
            Me.TxtTipDocIde.Text = ent.TipoDocumentoAuxiliar
            Me.TxtNomDocIde.Text = ent.NombreDocumentoIdentidad
            Me.TxtPaiNDomAux.Text = ent.PaisNoDomiciliadoAuxiliar
            Me.TxtNomPaiNDomAux.Text = ent.NombrePaisNoDomiciliadoAuxiliar
            Gb.pasarDato(Me.gbEstado, ent.EstadoAuxiliar)
        End If
        '\\
    End Sub

    Sub Aceptar()
        '//

        If Me.operacion = 1 Or Me.operacion = 2 Then
            'Volver a traer el registro 
            ent.CodigoAuxiliar = Me.txtCodAux.Text.Trim
            ' ent.DatoCondicion1 = Me.txtCodAux.Text.Trim
            ent = aux.buscarAuxiliarExisPorCodigo(ent)
        End If

        ent.CodigoAuxiliar = Me.txtCodAux.Text.Trim
        ent.DescripcionAuxiliar = Me.txtNomAux.Text.Trim
        ent.DireccionAuxiliar = Me.txtDirAux.Text.Trim
        ent.TelefonoAuxiliar = Me.txtTelAux.Text.Trim
        ent.CelularAuxiliar = Me.txtCelAux.Text.Trim
        ent.CorreoAuxiliar = Me.txtCorAux.Text.Trim
        ent.ReferenciaAuxiliar = Me.txtRefAux.Text.Trim
        ent.TipoAuxiliar = Rbt.radioActivo(Me.gbTipAux).Text.Trim
        ent.EstadoAuxiliar = Rbt.radioActivo(Me.gbEstado).Text.Trim
        ent.TipoDocumentoAuxiliar = Me.TxtTipDocIde.Text.Trim
        ent.PaisNoDomiciliadoAuxiliar = Me.TxtPaiNDomAux.Text.Trim
        ent.Exporta = "0"

        ent.ApellidoPaternoAuxiliar = ""
        ent.ApellidoMaternoAuxiliar = ""
        ent.PrimerNombreAuxiliar = ""
        ent.SegundoNombreAuxiliar = ""

        '/Se graba o0 se modifica?
        Select Case Me.operacion

            Case 0
                aux.nuevoAuxiliar(ent)
                MsgBox("Cliente - Proveedor Ingresado Correctamente", MsgBoxStyle.Information)
                'acc.LimpiarControles()
                acc.LimpiarControles()
                Txt.cursorAlUltimo(Me.txtCodAux)

            Case 1
                aux.modificarAuxiliar(ent)
                MsgBox("Cliente - Proveedor Modificado Correctamente", MsgBoxStyle.Information)
                Me.Close()

            Case 2
                aux.eliminarAuxiliarFis(ent)
                MsgBox("Cliente - Proveedor Eliminado Correctamente", MsgBoxStyle.Information)
                Me.Close()

        End Select
        '/Actualizar y buscar el registro grabado
        Me.wAux.ActualizarVentana()
        Dgv.obtenerCursorActual(Me.wAux.DgvAux, ent.DescripcionAuxiliar, Me.wAux.lista)
        '\\
    End Sub

#End Region

    Private Sub WEditarAuxiliar_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Me.Text = "Eliminar Cliente - Proveedor" Then
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
        If Me.Text = "Visualizar Cliente - Proveedor" Then
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



#Region "Mostrar formulario Lista"

#End Region

#Region "Busca por codigo"

#End Region

#Region "Existe Codigo"
    Private Sub txtCodAux_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodAux.Validated
        If Me.operacion = 0 Then
            Dim cod As String = Me.txtCodAux.Text.Trim
            If cod = "" Then
                Exit Sub
            Else
                Dim obj As New SuperEntidad
                obj.DatoCondicion1 = cod
                'Se busca en toda la tabla Usuario
                If aux.existeAuxiliarPorCodigo(obj) = True Then
                    MsgBox("Este Cliente - Proveedor Ya Existe", MsgBoxStyle.Information)
                    Me.txtCodAux.Text = ""
                    Me.txtCodAux.Focus()
                Else
                    Exit Sub
                End If
            End If
        End If

    End Sub

#End Region
    


    Private Sub gbEstado_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gbEstado.Enter

    End Sub

    Private Sub TxtTipDocIde_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtTipDocIde.KeyDown
        If Me.TxtTipDocIde.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarTabla
                win.tabla = "TipoDocumentoIdentidad"
                win.titulo = "Tipo Documentos Identidad"
                win.txt1 = Me.TxtTipDocIde
                win.txt2 = Me.TxtNomDocIde
                win.ctrlFoco = Me.TxtPaiNDomAux
                win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub TxtTipDocIde_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtTipDocIde.Validating
        If Me.operacion = 0 Or Me.operacion = 1 Or Me.operacion = 4 Then
            Dim ope As New OperaWin : ope.txt1 = Me.TxtTipDocIde : ope.txt2 = Me.TxtNomDocIde
            ope.MostrarCodigoDescripcionDeTabla("Tdi", "Tipo Documento Identidad", e)
        End If
    End Sub

    Private Sub TxtPaiNDomAux_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPaiNDomAux.KeyDown
        If Me.TxtPaiNDomAux.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarTabla
                win.tabla = "PaisNoDomiciliadoAuxiliar"
                win.titulo = "Pais No Domicilido Auxiliar"
                win.txt1 = Me.TxtPaiNDomAux
                win.txt2 = Me.TxtNomPaiNDomAux
                win.ctrlFoco = Me.gbEstado
                win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub TxtPaiNDomAux_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtPaiNDomAux.Validating
        If Me.operacion = 0 Or Me.operacion = 1 Or Me.operacion = 4 Then
            Dim ope As New OperaWin : ope.txt1 = Me.TxtPaiNDomAux : ope.txt2 = Me.TxtNomPaiNDomAux
            ope.MostrarCodigoDescripcionDeTabla("Pai", "Pais No Domiciliados", e)
        End If
    End Sub
End Class