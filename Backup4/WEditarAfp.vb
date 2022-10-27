Imports Entidad
Imports Negocio
Public Class WEditarAfp
#Region "Propietarios"
    Public wAfp As New WAfp
#End Region
    Public ent As New SuperEntidad
    Public lista As New List(Of SuperEntidad)
    Public tab As New TablaRN
    Public afp As New AfpRN
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
        Me.Text = "Agregar " + Me.wAfp.titulo
        acc.LimpiarControles()
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtCodAfp)
        'los controles que deben estar activos
        acc.Nuevo()
        '\\
    End Sub

    Sub ventanaModificar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Modificar " + Me.wAfp.titulo
        'mostrar el registro en pantalla
        Me.obtenerAfpEnPantalla(codigo)
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtNomAfp)
        'los controles que deben estar activos
        acc.Modificar()
        '\\
    End Sub

    Sub ventanaEliminar(ByRef codigo As String)
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Eliminar " + Me.wAfp.titulo
        'mostrar el registro en pantalla
        Me.obtenerAfpEnPantalla(codigo)
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
        Me.Text = "Visualizar " + Me.wAfp.titulo
        'mostrar el registro en pantalla
        Me.obtenerAfpEnPantalla(codigo)
        'los controles que deben estar activos
        acc.Visualizar()
    End Sub

    Sub obtenerAfpEnPantalla(ByRef codigo As String)
        '//
        ent.CodigoAfp = codigo
        ent = afp.buscarAfpExisPorCodigo(ent)
        'preguntar si ent tiene el registro
        If ent.CodigoAfp = "" Then
            Exit Sub
        Else
            '/Pasar Datos a los controles
            Me.txtCodAfp.Text = ent.CodigoAfp
            Me.txtNomAfp.Text = ent.NombreAfp
            Me.txtPorFonAfp.Text = ent.PorCentajeFondoAfp.ToString
            Me.TxtPorSegAfp.Text = ent.PorCentajeSeguroAfp.ToString
            Me.TxtPorSobRemAfp.Text = ent.PorCentajeSobreRemuneracionAfp.ToString
            Me.TxtPorEspAfp.Text = ent.PorCentajeEspecialAfp.ToString
            Gb.pasarDato(Me.gbEstado, ent.EstadoAfp)
        End If
        '\\
    End Sub

    Sub Aceptar()
        '//

        If Me.operacion = 1 Or Me.operacion = 2 Then
            'Volver a traer el registro 
            ent.CodigoAfp = Me.txtCodAfp.Text.Trim
            ' ent.DatoCondicion1 = Me.txtCodAux.Text.Trim
            ent = afp.buscarAfpExisPorCodigo(ent)
        End If

        ent.CodigoAfp = Me.txtCodAfp.Text.Trim
        ent.NombreAfp = Me.txtNomAfp.Text.Trim
        ent.PorCentajeFondoAfp = CType(Me.txtPorFonAfp.Text.Trim, Decimal)
        ent.PorCentajeSeguroAfp = CType(Me.TxtPorSegAfp.Text.Trim, Decimal)
        ent.PorCentajeSobreRemuneracionAfp = CType(Me.TxtPorSobRemAfp.Text.Trim, Decimal)
        ent.PorCentajeEspecialAfp = CType(Me.TxtPorEspAfp.Text.Trim, Decimal)
        ent.EstadoAfp = Rbt.radioActivo(Me.gbEstado).Text.Trim
        ent.Exporta = "0"
        '/Se graba o0 se modifica?
        Select Case Me.operacion

            Case 0
                afp.nuevoAfp(ent)
                MsgBox("Afp Ingresado Correctamente", MsgBoxStyle.Information)
                'acc.LimpiarControles()
                acc.LimpiarControles()
                Txt.cursorAlUltimo(Me.txtCodAfp)

            Case 1
                afp.modificarAfp(ent)
                MsgBox("Afp Modificado Correctamente", MsgBoxStyle.Information)
                Me.Close()

            Case 2
                afp.eliminarAfpFis(ent)
                MsgBox("Afp Eliminado Correctamente", MsgBoxStyle.Information)
                Me.Close()

        End Select
        '/Actualizar y buscar el registro grabado
        Me.wAfp.ActualizarVentana()
        Dgv.obtenerCursorActual(Me.wAfp.DgvAfp, ent.NombreAfp, Me.wAfp.lista)
        '\\
    End Sub

#End Region

    Private Sub WEditarAfp_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Me.Text = "Eliminar Afp" Then
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
        If Me.Text = "Visualizar Afp" Then
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
    Private Sub txtCodAfp_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodAfp.Validated
        If Me.operacion = 0 Then
            Dim cod As String = Me.txtCodAfp.Text.Trim
            If cod = "" Then
                Exit Sub
            Else
                Dim obj As New SuperEntidad
                obj.DatoCondicion1 = cod
                'Se busca en toda la tabla Usuario
                If afp.existeAfpPorCodigo(obj) = True Then
                    MsgBox("Esta Afp Ya Existe", MsgBoxStyle.Information)
                    Me.txtCodAfp.Text = ""
                    Me.txtCodAfp.Focus()
                Else
                    Exit Sub
                End If
            End If
        End If

    End Sub

#End Region

End Class