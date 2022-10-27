Imports Entidad
Imports Negocio
Public Class WEditarIngresoEgreso

#Region "Propietarios"
    Public wIngEgr As New WIngresoEgreso
#End Region
    Public ent As New SuperEntidad
    Public lista As New List(Of SuperEntidad)
    Public tab As New TablaRN
    Public IngEgr As New IngresoEgresoRN
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
        Me.Show()

    End Sub


    Sub PorDefecto()
        Me.txtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.txtNomEmp.Text = SuperEntidad.xRazonSocial

    End Sub

    Sub ventanaAdicionar()
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Agregar " + Me.wIngEgr.titulo
        acc.LimpiarControles()
        'Por Defecto
        Me.PorDefecto()
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.TxtCodIngEgr)
        'los controles que deben estar activos
        acc.Nuevo()
        '\\
    End Sub

    Sub ventanaModificar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Modificar " + Me.wIngEgr.titulo
        'mostrar el registro en pantalla
        Me.obtenerIngresoEgresoEnPantalla(codigo)
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.TxtNomIngEgr)
        'los controles que deben estar activos
        acc.Modificar()
        '\\
    End Sub

    Sub ventanaEliminar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Eliminar " + Me.wIngEgr.titulo
        'mostrar el registro en pantalla
        Me.obtenerIngresoEgresoEnPantalla(codigo)
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
        Me.Text = "Visualizar " + Me.wIngEgr.titulo
        'mostrar el registro en pantalla
        Me.obtenerIngresoEgresoEnPantalla(codigo)
        'foco
        Me.btnAceptar.Focus()
        'los controles que deben estar activos
        acc.Visualizar()
        '\\
    End Sub

    Sub obtenerIngresoEgresoEnPantalla(ByRef cod As String)
        '//
        'Buscamos el registro de codigo "Cod"
        ent.ClaveIngresoEgreso = cod
        ent = IngEgr.buscarIngresoEgresoExisPorClave(ent)
        'preguntar si ent tiene el registro
        If ent.CodigoEmpresa = "" Then
            Exit Sub
        Else
            '/Pasar Datos a los controles
            Me.txtCodEmp.Text = ent.CodigoEmpresa
            Me.txtNomEmp.Text = ent.RazonSocialEmpresa
            Me.TxtCodIngEgr.Text = ent.CodigoIngresoEgreso
            Me.TxtNomIngEgr.Text = ent.NombreIngresoEgreso
            Gb.pasarDato(Me.gbEstado, ent.EstadoIngresoEgreso)
        End If
        '\\
    End Sub

    Sub Aceptar()
        '// Lo ques graba en la tabla
        If Me.operacion = 1 Or Me.operacion = 2 Then
            'Volver a traer el registro 
            ent.DatoCondicion1 = ent.ClaveIngresoEgreso
            'ent.ClaveComprobante = Me.TxtCodProy.Text.Trim
            ent = IngEgr.buscarIngresoEgresoExisPorClave(ent)
        End If
        ent.CodigoEmpresa = Me.txtCodEmp.Text.Trim()
        ent.RazonSocialEmpresa = Me.txtNomEmp.Text.Trim()
        ent.CodigoIngresoEgreso = Me.TxtCodIngEgr.Text.Trim()
        ent.NombreIngresoEgreso = Me.TxtNomIngEgr.Text.Trim()
        ent.EstadoIngresoEgreso = Rbt.radioActivo(Me.gbEstado).Text.Trim
        ent.ClaveIngresoEgreso = ent.CodigoEmpresa + ent.CodigoIngresoEgreso



        ent.Exporta = "0"

        '/Se graba o0 se modifica?
        Select Case Me.operacion

            Case 0

                IngEgr.nuevaIngresoEgreso(ent)

                MsgBox(Me.wIngEgr.titulo + " ingresado correctamente", MsgBoxStyle.Information, Me.wIngEgr.titulo)
                'Limpiamos los controles para un nuevo registro
                acc.LimpiarControles()
                Me.PorDefecto()
                Me.TxtCodIngEgr.Focus()

            Case 1
                'Modificar Registro
                IngEgr.modificarIngresoEgreso(ent)
                MsgBox(Me.wIngEgr.titulo + " modificado correctamente", MsgBoxStyle.Information, Me.wIngEgr.titulo)
                Me.Close()

            Case 2
                'eliminamos al usuario pero logicamente
                IngEgr.eliminarIngresoEgresoFis(ent)
                MsgBox(Me.wIngEgr.titulo + " Eliminado correctamente", MsgBoxStyle.Information, Me.wIngEgr.titulo)
                Me.Close()

        End Select
        '/Actualizar y buscar el registro grabado
        Me.wIngEgr.ActualizarVentana()
        Dgv.obtenerCursorActual(Me.wIngEgr.DgvIngEgr, ent.ClaveIngresoEgreso, Me.wIngEgr.lista)
        '\\
    End Sub


#End Region

    Private Sub WEditarTabla_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        'Solo para eliminar
        If Me.operacion = 2 Then
            Dim rpta As Integer = MsgBox("Deseas eliminar este registro", MsgBoxStyle.YesNo, Me.wIngEgr.titulo)
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
            Dim rpta As Integer = MsgBox("Deseas cancelar la operacion", MsgBoxStyle.YesNo, Me.wIngEgr.titulo)
            If rpta = MsgBoxResult.Yes Then
                Me.Close()
            Else
                Exit Sub
            End If
        End If
    End Sub

#Region "Existe Codigo"

    Function ComprobarClaveIngresoEgreso() As Boolean
        '/
        If Me.operacion = 0 Then 'Solo cuando Agrega

            Dim cod As String = Me.txtCodEmp.Text.Trim + Me.TxtCodIngEgr.Text.Trim
            If cod = "" Then
                Return False
            Else
                Dim obj As New SuperEntidad
                obj.ClaveIngresoEgreso = cod
                'Se busca en toda la tabla
                If IngEgr.existeIngresoEgresoPorCodigo(obj) = True Then
                    MsgBox("Este Codigo ya existe", MsgBoxStyle.Information, Me.wIngEgr.titulo)
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

    Private Sub TxtCodFil_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodIngEgr.Validating
        If Me.ComprobarClaveIngresoEgreso() = True Then
            Me.TxtCodIngEgr.Text = ""
            Me.TxtCodIngEgr.Focus()
            e.Cancel = False
        Else
            Exit Sub
        End If
    End Sub
End Class