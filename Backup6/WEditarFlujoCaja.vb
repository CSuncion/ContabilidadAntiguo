Imports Entidad
Imports Negocio
Public Class WEditarFlujoCaja

#Region "Propietarios"
    Public wFlu As New WFlujoCaja
#End Region
    Public ent As New SuperEntidad
    Public lista As New List(Of SuperEntidad)
    Public tab As New TablaRN
    Public Flu As New FlujoCajaRN
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
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.txtNomEmp.Text = SuperEntidad.xRazonSocial

    End Sub

    Sub ventanaAdicionar()
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Agregar " + Me.wFlu.titulo
        acc.LimpiarControles()
        'Por Defecto
        Me.PorDefecto()
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.TxtCodFluCaj)
        'los controles que deben estar activos
        acc.Nuevo()
        '\\
    End Sub

    Sub ventanaModificar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Modificar " + Me.wFlu.titulo
        'mostrar el registro en pantalla
        Me.obtenerFlujocajaEnPantalla(codigo)
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.TxtNomFluCaj)
        'los controles que deben estar activos
        acc.Modificar()
        '\\
    End Sub

    Sub ventanaEliminar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Eliminar " + Me.wFlu.titulo
        'mostrar el registro en pantalla
        Me.obtenerFlujocajaEnPantalla(codigo)
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
        Me.Text = "Visualizar " + Me.wFlu.titulo
        'mostrar el registro en pantalla
        Me.obtenerFlujocajaEnPantalla(codigo)
        'foco
        Me.btnAceptar.Focus()
        'los controles que deben estar activos
        acc.Visualizar()
        '\\
    End Sub

    Sub obtenerFlujocajaEnPantalla(ByRef cod As String)
        '//
        'Buscamos el registro de codigo "Cod"
        ent.ClaveFlujoCaja = cod
        ent = Flu.buscarFlujoCajaExisPorClave(ent)
        'preguntar si ent tiene el registro
        If ent.CodigoEmpresa = "" Then
            Exit Sub
        Else
            '/Pasar Datos a los controles
            Me.txtCodEmp.Text = ent.CodigoEmpresa
            Me.txtNomEmp.Text = ent.RazonSocialEmpresa
            Me.TxtCodFluCaj.Text = ent.CodigoFlujoCaja
            Me.TxtNomFluCaj.Text = ent.NombreFlujoCaja
            Gb.pasarDato(Me.gbEstado, ent.EstadoFlujoCaja)
        End If
        '\\
    End Sub

    Sub Aceptar()
        '// Lo ques graba en la tabla
        If Me.operacion = 1 Or Me.operacion = 2 Then
            'Volver a traer el registro 
            ent.DatoCondicion1 = ent.ClaveFlujoCaja
            'ent.ClaveComprobante = Me.TxtCodProy.Text.Trim
            ent = Flu.buscarFlujoCajaExisPorClave(ent)
        End If
        ent.CodigoEmpresa = Me.txtCodEmp.Text.Trim()
        ent.RazonSocialEmpresa = Me.txtNomEmp.Text.Trim()
        ent.CodigoFlujoCaja = Me.TxtCodFluCaj.Text.Trim()
        ent.NombreFlujoCaja = Me.TxtNomFluCaj.Text.Trim()
        ent.EstadoFlujoCaja = Rbt.radioActivo(Me.gbEstado).Text.Trim
        ent.ClaveFlujoCaja = ent.CodigoEmpresa + ent.CodigoFlujoCaja
        ent.Exporta = "0"

        '/Se graba o0 se modifica?
        Select Case Me.operacion

            Case 0

                Flu.nuevaFlujoCaja(ent)
                MsgBox(Me.wFlu.titulo + " ingresado correctamente", MsgBoxStyle.Information, Me.wFlu.titulo)
                'Limpiamos los controles para un nuevo registro
                acc.LimpiarControles()
                Me.PorDefecto()
                Me.TxtCodFluCaj.Focus()

            Case 1
                'Modificar Registro
                Flu.modificarFlujoCaja(ent)
                MsgBox(Me.wFlu.titulo + " modificado correctamente", MsgBoxStyle.Information, Me.wFlu.titulo)
                Me.Close()

            Case 2
                'eliminamos al usuario pero logicamente
                Flu.eliminarFlujoCajaFis(ent)
                MsgBox(Me.wFlu.titulo + " Eliminado correctamente", MsgBoxStyle.Information, Me.wFlu.titulo)
                Me.Close()

        End Select
        '/Actualizar y buscar el registro grabado
        Me.wFlu.ActualizarVentana()
        Dgv.obtenerCursorActual(Me.wFlu.DgvFlu, ent.ClaveFlujoCaja, Me.wFlu.lista)
        '\\
    End Sub


#End Region

    Private Sub WEditarTabla_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        'Solo para eliminar
        If Me.operacion = 2 Then
            Dim rpta As Integer = MsgBox("Deseas eliminar este registro", MsgBoxStyle.YesNo, Me.wFlu.titulo)
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
            Dim rpta As Integer = MsgBox("Deseas cancelar la operacion", MsgBoxStyle.YesNo, Me.wFlu.titulo)
            If rpta = MsgBoxResult.Yes Then
                Me.Close()
            Else
                Exit Sub
            End If
        End If
    End Sub

#Region "Existe Codigo"

    Function ComprobarClaveFlujoCaja() As Boolean
        '/
        If Me.operacion = 0 Then 'Solo cuando Agrega

            Dim cod As String = Me.txtCodEmp.Text.Trim + Me.TxtCodFluCaj.Text.Trim
            If cod = "" Then
                Return False
            Else
                Dim obj As New SuperEntidad
                obj.ClaveFlujoCaja = cod
                'Se busca en toda la tabla
                If Flu.existeFlujoCajaPorCodigo(obj) = True Then
                    MsgBox("Este Codigo ya existe", MsgBoxStyle.Information, Me.wFlu.titulo)
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

    Private Sub TxtCodFil_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodFluCaj.Validating
        If Me.ComprobarClaveFlujoCaja() = True Then
            Me.TxtCodFluCaj.Text = ""
            Me.TxtCodFluCaj.Focus()
            e.Cancel = False
        Else
            Exit Sub
        End If
    End Sub
End Class