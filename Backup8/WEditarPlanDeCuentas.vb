Imports Entidad
Imports Negocio

Public Class WEditarPlanDeCuentas
#Region "Propietarios"
    Public wpcta As New WPcge
#End Region

    Dim valorRef As String

    Public ent As New SuperEntidad
    Public lista As New List(Of SuperEntidad)
    Public cam As New CamposEntidad
    Public tab As New TablaRN
    Public pcta As New PlanDeCuentasRN
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
        Me.Show()

    End Sub

    Sub ventanaAdicionar()
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Agregar " + Me.wpcta.titulo
        acc.LimpiarControles()
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtCodCta)
        'los controles que deben estar activos
        acc.Nuevo()
        '\\
    End Sub

    Sub ventanaModificar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Modificar " + Me.wpcta.titulo
        'mostrar el registro en pantalla
        Me.obtenerItemTablaEnPantalla(codigo)
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtNomCta)
        'los controles que deben estar activos
        acc.Modificar()
        '\\
    End Sub

    Sub ventanaEliminar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Eliminar " + Me.wpcta.titulo
        'mostrar el registro en pantalla
        Me.obtenerItemTablaEnPantalla(codigo)
        'foco
        Me.btnAceptar.Focus()
        'los controles que deben estar activos
        acc.Eliminar()
        '\\
    End Sub

    Sub ventanaVisualizar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Visualizar " + Me.wpcta.titulo
        'mostrar el registro en pantalla
        Me.obtenerItemTablaEnPantalla(codigo)
        'foco
        Me.btnAceptar.Focus()
        'los controles que deben estar activos
        acc.Visualizar()
        '\\
    End Sub

    Sub obtenerItemTablaEnPantalla(ByRef cod As String)
        '//
        'Buscamos el registro de codigo "Cod"
        ent.CodigoCuentaPcge = cod
        ent = pcta.buscarPlanDeCuentasExisPorCodigo(ent)
        'preguntar si ent tiene el registro
        If ent.CodigoCuentaPcge = "" Then
            Exit Sub
        Else
            '/Pasar Datos a los controles
            Me.txtCodCta.Text = ent.CodigoCuentaPcge
            Me.txtNomCta.Text = ent.NombreCuentaPcge
        End If
        '\\
    End Sub

    Sub Aceptar()
        '// Lo ques graba en la tabla
        If Me.operacion = 1 Or Me.operacion = 2 Then
            'Volver a traer el registro 
            ent.DatoCondicion1 = ent.CodigoCuentaPcge
            'ent.ClaveComprobante = Me.TxtCodProy.Text.Trim
            ent = pcta.buscarPlanDeCuentasExisPorCodigo(ent)
        End If

        ent.CodigoCuentaPcge = Me.txtCodCta.Text.Trim
        ent.NombreCuentaPcge = Me.txtNomCta.Text.Trim

        'ent.NumeroDigitosPcge = Me.txtNomCta.Text.Trim
        'ent.EstadoCuenta = Rbt.radioActivo(Me.gbEstado).Text.Trim()

        ent.Exporta = "0"

        '/Se graba o0 se modifica?
        Select Case Me.operacion

            Case 0
                'ent.EstadoComprobante = "Activo"  ''Cuando no se ve en pantalla sino arriba
                ''Obtener codigo autogenerado
                'ent.CodigoCliente = cli.obtenerCodigoClienteAutogenerado()
                'Nuevo registro
                pcta.nuevaPlanDeCuentas(ent)
                MsgBox(Me.wpcta.titulo + " ingresado correctamente", MsgBoxStyle.Information, Me.wpcta.titulo)
                'Limpiamos los controles para un nuevo registro
                acc.LimpiarControles()
                Me.txtCodCta.Focus()

            Case 1
                'Modificar Registro
                pcta.modificarPlanDeCuentas(ent)
                MsgBox(Me.wpcta.titulo + " modificado correctamente", MsgBoxStyle.Information, Me.wpcta.titulo)
                Me.Close()

            Case 2
                'eliminamos al usuario pero logicamente
                pcta.eliminarPlanDeCuentasFis(ent)
                MsgBox(Me.wpcta.titulo + " Eliminado correctamente", MsgBoxStyle.Information, Me.wpcta.titulo)
                Me.Close()

        End Select
        '/Actualizar y buscar el registro grabado
        Me.wpcta.ActualizarVentana()
        Dgv.obtenerCursorActual(Me.wpcta.DgvPctaRec, ent.CodigoCuentaPcge, Me.wpcta.lista)
        '\\
    End Sub


#End Region


    Private Sub WEditarTabla_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        'Solo para eliminar
        If Me.operacion = 2 Then
            Dim rpta As Integer = MsgBox("Deseas eliminar este registro", MsgBoxStyle.YesNo, Me.wpcta.titulo)
            If rpta = MsgBoxResult.Yes Then
                Me.Aceptar()
                Exit Sub
            Else
                Exit Sub
            End If
        End If
        'para agregar o modificar
        If acc.CamposObligatorios = False Then
            Exit Sub
        Else
            Me.Aceptar()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If Me.operacion = 3 Then
            Me.Close()
        Else
            Dim rpta As Integer = MsgBox("Deseas cancelar la operacion", MsgBoxStyle.YesNo, Me.wpcta.titulo)
            If rpta = MsgBoxResult.Yes Then
                Me.Close()
            Else
                Exit Sub
            End If
        End If
    End Sub

#Region "existe CuentaPlan"

    Private Sub txtCodcta_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodCta.Validated
        'Se busca en toda la tabla Plan de Cuentas
        If Me.ComprobarClaveCuentaPlan() = True Then
            Me.txtCodCta.Text = ""
            Me.txtCodCta.Focus()
            'e.Cancel = True
        Else
            Exit Sub
        End If
    End Sub

#End Region

#Region "Existe Codigo"

    Function ComprobarClaveCuentaPlan() As Boolean
        '/
        If Me.operacion = 0 Then 'Solo cuando Agrega

            Dim cod As String = Me.txtCodCta.Text.Trim
            If cod = "" Then
                Return False
            Else
                Dim obj As New SuperEntidad
                obj.CodigoCuentaPcge = cod
                'Se busca en toda la tabla
                If pcta.existePlanDeCuentasPorCodigo(obj) = True Then
                    MsgBox("Esta Cuenta ya existe", MsgBoxStyle.Information, Me.wpcta.titulo)
                    Return True
                Else
                    Return False
                End If
            End If
        Else
            Return False
        End If
    End Function

#End Region

End Class