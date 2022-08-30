Imports Entidad
Imports Negocio

Public Class WEditarOpcion
#Region "Propietarios"
      Public wOpc As New WOpcion
#End Region

      Public ent As New SuperEntidad
      Public lista As New List(Of SuperEntidad)
      Public cam As New CamposEntidad
      Public opc As New OpcionRN
      Public vo As New VentanaOpcionRN
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
            Me.Text = "Agregar " + Me.wOpc.titulo
            'poner el cursor de inicio
            Txt.cursorAlUltimo(Me.txtCod)
            'los controles que deben estar activos
            acc.Nuevo()
            '\\
      End Sub

      Sub ventanaModificar(ByRef codigo As String)
            '//
            Me.InicializaVentana()
            'titulo de la ventana
            Me.Text = "Modificar " + Me.wOpc.titulo
            'mostrar el registro en pantalla
            Me.obtenerItemTablaEnPantalla(codigo)
            'poner el cursor de inicio
            Txt.cursorAlUltimo(Me.txtNom)
            'los controles que deben estar activos
            acc.Modificar()
            '\\
      End Sub

      Sub ventanaEliminar(ByRef codigo As String)
            '//
            Me.InicializaVentana()
            'titulo de la ventana
            Me.Text = "Eliminar " + Me.wOpc.titulo
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
            Me.Text = "Visualizar " + Me.wOpc.titulo
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
            ent.CodigoOpcion = cod
            ent = opc.buscarOpcionExisPorCodigo(ent)
            'preguntar si ent tiene el registro
            If ent.CodigoOpcion = "" Then
                  Exit Sub
            Else
                  '/Pasar Datos a los controles
                  Me.txtCod.Text = ent.CodigoOpcion
                  Me.txtNom.Text = ent.NombreOpcion
            End If
            '\\
      End Sub

      Sub Aceptar()
            '//
            If Me.operacion = 1 Or Me.operacion = 2 Then
                  'Volver a traer el registro 
                  ent.CodigoOpcion = Me.txtCod.Text.Trim
                  ent = opc.buscarOpcionExisPorCodigo(ent)
            End If

            ent.CodigoOpcion = Me.txtCod.Text.Trim
            ent.NombreOpcion = Me.txtNom.Text.Trim

            '/Se graba o0 se modifica?
            Select Case Me.operacion

                  Case 0
                        'Nuevo registro
                        opc.nuevoOpcion(ent)
                        MsgBox(Me.wOpc.titulo + " ingresado correctamente", MsgBoxStyle.Information, Me.wOpc.titulo)
                        'Limpiamos los controles para un nuevo registro
                        acc.LimpiarControles()
                        Me.txtCod.Focus()

                  Case 1
                        'Modificar Registro
                        opc.modificarOpcion(ent)
                        MsgBox(Me.wOpc.titulo + " modificado correctamente", MsgBoxStyle.Information, Me.wOpc.titulo)
                        Me.Close()

                  Case 2
                        'Comprobar si se puede eliminar
                        If Me.EsOpcionEliminable = False Then Exit Sub

                        'eliminamos al usuario pero logicamente
                        opc.eliminarOpcionTablaFis(ent)
                        MsgBox(Me.wOpc.titulo + " Eliminado correctamente", MsgBoxStyle.Information, Me.wOpc.titulo)
                        Me.Close()

            End Select
            '/Actualizar y buscar el registro grabado
            Me.wOpc.ActualizarVentana()
            Dgv.obtenerCursorActual(Me.wOpc.DgvVen, ent.CodigoOpcion, Me.wOpc.lista)
            '\\
      End Sub

      Function EsOpcionEliminable() As Boolean
            Dim oVO As New SuperEntidad
            Dim lisVO As New List(Of SuperEntidad)
            oVO.CodigoOpcion = Me.txtCod.Text.Trim
            lisVO = vo.obtenerVentanaOpcionesExisXOpcion(oVO)

            If lisVO.Count = 0 Then
                  Return True
            Else
                  MsgBox("Esta opcion no se puede eliminar", MsgBoxStyle.Exclamation, Me.wOpc.titulo)
                  Return False
            End If

      End Function


#End Region


      Private Sub WEditarTabla_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            Me.Owner.Enabled = True
      End Sub

      Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
            'Solo para eliminar
            If Me.operacion = 2 Then
                  Dim rpta As Integer = MsgBox("Deseas eliminar este registro", MsgBoxStyle.YesNo, Me.wOpc.titulo)
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
                  Dim rpta As Integer = MsgBox("Deseas cancelar la operacion", MsgBoxStyle.YesNo, Me.wOpc.titulo)
                  If rpta = MsgBoxResult.Yes Then
                        Me.Close()
                  Else
                        Exit Sub
                  End If
            End If
      End Sub


#Region "Codigo existe"

      Private Sub txtCod_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCod.Validating
            If Me.operacion = 0 Then
                  Dim cod As String = Me.txtCod.Text.Trim
                  If cod = "" Then
                        Exit Sub
                  Else
                        Dim obj As New SuperEntidad
                        obj.CodigoOpcion = Me.txtCod.Text.Trim
                        'Se busca en toda la tabla
                        obj = opc.buscarOpcionExisPorCodigo(obj)
                        If obj.CodigoOpcion <> "" Then
                              MsgBox("Este codigo ya existe", MsgBoxStyle.Information, Me.wOpc.titulo)
                              Me.txtCod.Text = ""
                              Txt.cursorAlUltimo(Me.txtCod)
                              e.Cancel = True
                        Else
                              Exit Sub
                        End If
                  End If
            End If
      End Sub

#End Region

End Class