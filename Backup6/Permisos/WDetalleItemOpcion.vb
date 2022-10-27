Imports Entidad
Imports Negocio

Public Class WDetalleItemOpcion
#Region "Propietarios"
      Public wDeV As New WDetalleVentana
#End Region

      Public ent As New SuperEntidad
      Public lista As New List(Of SuperEntidad)
      Public cam As New CamposEntidad
      Public vop As New VentanaOpcionRN
      Public opc As New OpcionRN
      Public usu As New UsuarioRN
      Public per As New PermisoRN
      Public acc As New Accion
      Public ventana As String
      Public operacion As Integer  '0=agregar , 1=modificar , 2=eliminar , 3=visualizar


#Region "Metodos"

      Sub InicializaVentana()
            '/Para los eventos de controles
            'acc.listaCtrls = Me.ListaControles
            'acc.PasaFoco()
            'acc.FomatoDato()
            'acc.PasarCursor()
            'acc.Teclazo()
            'acc.Valida()
            '/Ejecucion en ventana
            Me.Owner.Enabled = False
            Me.Show()

      End Sub

      Sub ventanaAdicionar()
            '//
            Me.InicializaVentana()
            'titulo de la ventana
            Me.Text = "Agregar " + Me.wDeV.titulo
            'poner el cursor de inicio
            Txt.cursorAlUltimo(Me.txtCod)
            'los controles que deben estar activos
            acc.Nuevo()
            '\\
      End Sub

      Sub ventanaEliminar(ByRef codigo As String)
            '//
            Me.InicializaVentana()
            'titulo de la ventana
            Me.Text = "Eliminar " + Me.wDeV.titulo
            'mostrar el registro en pantalla
            Me.obtenerItemTablaEnPantalla(codigo)
            'foco
            Me.btnAceptar.Focus()
            'los controles que deben estar activos
            acc.Eliminar()
            '\\
      End Sub

      Sub obtenerItemTablaEnPantalla(ByRef cod As String)
            '//
            'Buscamos el registro de codigo "Cod"
            ent.CodigoVentana = Me.ventana
            ent.CodigoOpcion = cod
            ent = vop.buscarVentanaOpcionExisPorVentanaYOpcion(ent)
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
            ent.CodigoVentana = Me.ventana
            ent.CodigoOpcion = Me.txtCod.Text.Trim
            ent = vop.buscarVentanaOpcionExisPorVentanaYOpcion(ent)
        End If

        ent.CodigoOpcion = Me.txtCod.Text.Trim
        ent.CodigoVentana = Me.ventana

        '/Se graba o0 se modifica?
        Select Case Me.operacion

            Case 0
                'Nuevo VentanaOpcion
                vop.nuevoVentanaOpcion(ent)

                'Agregar esta opcion en permiso
                Me.AdicionarEnPermiso()

                MsgBox(Me.wDeV.titulo + " ingresado correctamente", MsgBoxStyle.Information, Me.wDeV.titulo)
                'Limpiamos los controles para un nuevo registro
                Me.ObtenerOpcion(opc.OpcionIni)
                Me.txtCod.Focus()

            Case 2
                'eliminamos al usuario pero logicamente
                vop.eliminarVentanaOpcionFis(ent)

                'Eliminar esta opcion en permiso
                Me.EliminarEnPermiso()

                MsgBox(Me.wDeV.titulo + " Eliminado correctamente", MsgBoxStyle.Information, Me.wDeV.titulo)
                Me.Close()

        End Select
        '/Actualizar y buscar el registro grabado
        Me.wDeV.ActualizarVentana()
        Dgv.obtenerCursorActual(Me.wDeV.DgvOpc, ent.CodigoOpcion, Me.wDeV.lisOpc)
        '\\
    End Sub


      Sub ComprobarOpcion()
            'SOLO CUANDO ADICIONAS
            If Me.operacion = 0 Then
                  'VERIFICA SI EL CODIGO OPCION EXISTE EN OPCION 
                  If Me.ExisteOpcion = False Then Exit Sub

                  'VERIFICA LA DISPONIBILIDAD DE ESTA OPCION
                  If Me.EsOpcionDisponible = False Then Exit Sub

            End If
            
      End Sub

      Sub AdicionarEnPermiso()
            Dim oUsu, oPer As New SuperEntidad
            Dim lisUsu As New List(Of SuperEntidad)

            'LISTA DE TODOS LOS USUARIOS EN B.D
            oUsu.CampoOrden = cam.CodUsu
            lisUsu = usu.obtenerUsuarios(oUsu)

            'SI HAY USUARIOS LE PASAMOS ESTA OPCION EN SU PERMISO
            If lisUsu.Count <> 0 Then
                  For Each ob As SuperEntidad In lisUsu
                        'INSERTAMOS ESTE PERMISO A CADA USUARIO
                        oPer.CodigoUsuario = ob.CodigoUsuario
                        oPer.CodigoVentana = Me.ventana
                        oPer.CodigoOpcion = Me.txtCod.Text.Trim
                        per.nuevoPermiso(oPer)
                  Next
            End If
      End Sub

      Sub EliminarEnPermiso()
            Dim oUsu, oPer As New SuperEntidad
            Dim lisUsu As New List(Of SuperEntidad)

            'LISTA DE TODOS LOS USUARIOS EN B.D
            oUsu.CampoOrden = cam.CodUsu
            lisUsu = usu.obtenerUsuarios(oUsu)

            'SI HAY USUARIOS LE QUITAMOS ESTA OPCION EN SU PERMISO
            If lisUsu.Count <> 0 Then
                  For Each ob As SuperEntidad In lisUsu
                        'ELIMINAMOS ESTE PERMISO A CADA USUARIO
                        oPer.CodigoUsuario = ob.CodigoUsuario
                        oPer.CodigoVentana = Me.ventana
                        oPer.CodigoOpcion = Me.txtCod.Text.Trim
                        per.eliminarPermisoFis(oPer)
                  Next
            End If
      End Sub

#End Region

#Region "Obtener Objetos"

      Sub ObtenerOpcion(ByVal oOpc As SuperEntidad)
            '/Pasar Datos a los controles
            Me.txtCod.Text = oOpc.CodigoOpcion
            Me.txtNom.Text = oOpc.NombreOpcion
      End Sub


#End Region

#Region "Listar"

      Private Sub TxtCod_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCod.KeyDown
            ' Solo caundo vas a Agregar un nuevo contrato
            If Me.operacion = 0 Then
                  If Me.txtCod.ReadOnly = False Then
                        If e.KeyCode = Keys.F1 Then
                              Dim win As New WListarOpciones
                              win.tituloWin = "Opciones"
                              win.CondicionLista = "Todos"
                              win.txt1 = Me.txtCod
                              win.txt2 = Me.txtNom
                              win.ctrlFoco = Me.btnAceptar
                              win.NuevaVentana()
                        End If
                  End If
            End If
      End Sub

#End Region

#Region "Existen Objetos"

      Function ExisteOpcion() As Boolean
            Dim oOpc As New SuperEntidad
            oOpc.CodigoOpcion = Me.txtCod.Text.Trim
            'PREGUNTAR SI EL CODIGO ESTA VACIO
            If oOpc.CodigoOpcion = "" Then
                  Me.ObtenerOpcion(opc.OpcionIni)
                  Return True
            End If
            'PREGUNTAR SI EL CODIGO EXISTE EN B.D
            oOpc = opc.buscarOpcionExisPorCodigo(oOpc)
            If oOpc.CodigoOpcion = "" Then
                  MsgBox("Esta opcion no existe", MsgBoxStyle.Exclamation, Me.wDeV.titulo)
                  Me.ObtenerOpcion(opc.OpcionIni)
                  Me.txtCod.Focus()
                  Return False
            End If
            'SI SE LLEGA HASTA AQUI ENTONCES SI SE ENCONTRO EL OBJETO
            Me.ObtenerOpcion(oOpc)
            Return True
      End Function

#End Region

#Region "Disponibilidad de codigos"

      Function EsOpcionDisponible() As Boolean
            Dim oVO As New SuperEntidad
            oVO.CodigoVentana = Me.ventana
            oVO.CodigoOpcion = Me.txtCod.Text.Trim
            'PREGUNTAR SI EL CODIGO OPCION ESTA VACIO
            If oVO.CodigoOpcion = "" Then
                  Me.ObtenerOpcion(opc.OpcionIni)
                  Return True
            End If
            'PREGUNTAR SI EL CODIGO EXISTE EN B.D
            oVO = vop.buscarVentanaOpcionExisPorVentanaYOpcion(oVO)
            If oVO.CodigoOpcion = "" Then
                  Return True
            End If
            'SI LLEGA HASTA AQUI ESTE CODIGO NO ESTA DISPONIBLE
            MsgBox("Este opcion ya existe en la ventana :" + Me.ventana)
            Me.ObtenerOpcion(opc.OpcionIni)
            Return False
      End Function

#End Region

      Private Sub WEditarTabla_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            Me.Owner.Enabled = True
      End Sub

      Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
            'Solo para eliminar
            If Me.operacion = 2 Then
                  Dim rpta As Integer = MsgBox("Deseas eliminar este registro", MsgBoxStyle.YesNo, Me.wDeV.titulo)
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
                  Dim rpta As Integer = MsgBox("Deseas cancelar la operacion", MsgBoxStyle.YesNo, Me.wDeV.titulo)
                  If rpta = MsgBoxResult.Yes Then
                        Me.Close()
                  Else
                        Exit Sub
                  End If
            End If
      End Sub

      Private Sub txtCod_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCod.Validated
            Me.ComprobarOpcion()
      End Sub
End Class