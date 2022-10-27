Imports Entidad
Imports Negocio

Public Class WEditarUsuario

#Region "Propietarios"
    Public wUsu As New WUsuario
#End Region

    Public ent As New SuperEntidad
    Public lista As New List(Of SuperEntidad)
    Public vo As New VentanaOpcionRN
    Public per As New PermisoRN
    Public usu As New UsuarioRN
    Public cam As New CamposEntidad
    Public acc As New Accion

#Region "Metodos"

    Sub InicializaVentana()
        '/Para los eventos de controles
        acc.listaCtrls = Me.ListaControles
        acc.PasaFoco()
        acc.FomatoDato()
        acc.PasarCursor()
        acc.Teclazo()
        acc.Valida()
        'Cargamos el como de grupo
        'Me.CargarGrupos()
        '/Ejecucion en ventana
        Me.Owner.Enabled = False
        Me.Show()
    End Sub



    'Sub CargarGrupos()
    '      '//
    '      ent.CampoOrden = cam.NomGru
    '      lista = gru.obtenerGruposExis(ent)
    '      Cmb.Cargar(Me.cmbGru, lista, cam.CodGru, cam.NomGru)
    '      '\\
    'End Sub

    Sub ventanaAdicionar()
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Nuevo Usuario"
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtNomPer)
        'los controles que deben estar activos
        'Me.lblPerfil.Visible = False
        acc.Nuevo()
        '\\
    End Sub

    Sub ventanaModificar(ByRef codigoUsuario As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Modificar Usuario"
        'mostrar el registro en pantalla
        Me.obtenerUsuarioEnPantalla(codigoUsuario)
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtCla)
        'Me.lblPerfil.Visible = False
        'los controles que deben estar activos
        acc.Modificar()
        '\\
    End Sub

    Sub ventanaEliminar(ByRef codigoUsuario As String)
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Eliminar Usuario"
        'mostrar el registro en pantalla
        Me.obtenerUsuarioEnPantalla(codigoUsuario)
        'los controles que deben estar activos
        acc.Eliminar()
    End Sub


    Sub ventanaVisualizar(ByRef codigoUsuario As String)
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Visualizar Usuario"
        'mostrar el registro en pantalla
        Me.obtenerUsuarioEnPantalla(codigoUsuario)
        'los controles que deben estar activos
        acc.Visualizar()
    End Sub

    Sub obtenerUsuarioEnPantalla(ByRef cod As String)
        '//
        'Buscamos el registro de codigo "Cod"
        ent.DatoCondicion1 = cod
        ent = usu.buscarUsuarioExisTotPorCodigo(ent)
        'preguntar si ent tiene el registro
        If ent.CodigoUsuario = "" Then
            Exit Sub
        Else
            '/Pasar Datos a los controles
            'Me.txtCodPer.Text = ent.CodigoPersonalUsuario
            'Me.txtNomPer.Text = ent.NombrePersonalUsuario
            Me.txtCodUsu.Text = ent.CodigoUsuario
            Me.txtNomPer.Text = ent.NombreUsuario
            Me.txtCla.Text = Varios.desencriptar(ent.ClaveUsuario)
            Me.txtCon.Text = Varios.desencriptar(ent.ClaveUsuario)

            'Me.cmbGru.SelectedValue = ent.CodigoGrupo
            'Me.lblPerfil.Text = ent.NombreGrupo
            'Estado Uusraio
            Select Case ent.EstadoRegistro
                Case "Activo"
                    Me.rbtAct.Checked = True
                Case "Desactivo"
                    Me.rbtDes.Checked = True
            End Select
        End If
        '\\
    End Sub

    Sub Aceptar()
        '//
        If Me.Text = "Modificar Usuario" Or Me.Text = "Eliminar Usuario" Then
            'Volver a traer el registro 
            ent.DatoCondicion1 = Me.txtCodUsu.Text.Trim
            ent = usu.buscarUsuarioExisTotPorCodigo(ent)
        End If

        'Pasamos los datos que vamos a cargar 
        ent.CodigoUsuario = Me.txtCodUsu.Text.Trim
        ent.NombreUsuario = Me.txtNomPer.Text.Trim
        ent.ClaveUsuario = Varios.encriptar(Me.txtCla.Text.Trim)
        'Estado Usuario
        Dim str As String = Rbt.radioActivo(Me.GroupBox1).Text.ToString.Trim()
        Select Case str
            Case "Activado"
                ent.EstadoRegistro = "1"
            Case "Desactivado"
                ent.EstadoRegistro = "0"
        End Select

        '/Se graba o0 se modifica?
        Select Case Me.Text

            Case "Nuevo Usuario"
                'Nuevo registro
                usu.nuevoUsuario(ent)

                'GENERAR PERMISOS EMPRESA
                Me.GenerarPermisosEmpresa()

                'GENERAR TODOS LAS ACCIONES DISPONIBLES
                Me.GenerarAccionesDisponibles()

                MsgBox("Usuario " + ent.CodigoUsuario + " Agregado correctamente", MsgBoxStyle.Information)
                'Limpiamos los controles para un nuevo registro
                acc.LimpiarControles()
                Me.txtNomPer.Focus()

            Case "Modificar Usuario"
                'Modificar Registro
                usu.modificarUsuario(ent)
                MsgBox("Usuario " + ent.CodigoUsuario + " Modificado correctamente", MsgBoxStyle.Information)
                Me.Close()
                '/Registrar el usuario que modifico este registro

            Case "Eliminar Usuario"

                'eliminamos al usuario pero logicamente
                usu.eliminarUsuarioFis(ent)

                'Eliminar permisos del usuario
                per.eliminarPermisosDeUsuarioFis(ent)

                'eliminar permisos empresa
                Me.EliminarPermisosEmpresa()

                MsgBox("Usuario " + ent.CodigoUsuario + " Eliminado correctamente", MsgBoxStyle.Information)
                Me.Close()

        End Select
        '/Actualizar y buscar el registro grabado
        Me.wUsu.ActualizarVentana()
        Dgv.obtenerCursorActual(Me.wUsu.DgvUsu, ent.CodigoUsuario, Me.wUsu.lista)
        '\\
    End Sub

    Sub GenerarPermisosEmpresa()
        'TRAER TODAS LAS EMPRESAS QUE EXISTEN EN B.D 
        Dim iEmpRN As New EmpresaRN
        Dim lisEmp As New List(Of SuperEntidad)
        Dim empEN As New SuperEntidad
        empEN.CampoOrden = cam.CodEmp
        lisEmp = iEmpRN.obtenerEmpresa(empEN)

        'GRABAR TODAS ESTAS EMPRESAS EN USUARIOEMPRESA
        Dim usu As String = Me.txtCodUsu.Text.Trim
        Dim iPerEmpRN As New PermisoEmpresaRN
        iPerEmpRN.GenerarPermisosEmpresasXUsuario(usu, lisEmp)
    End Sub

    Sub EliminarPermisosEmpresa()
        Dim iPerEmpEN As New PermisoEmpresaEN
        Dim iPerEmpRN As New PermisoEmpresaRN
        iPerEmpEN.CodigoUsuario = Me.txtCodUsu.Text.Trim
        iPerEmpRN.eliminarSoloUsuarioFis(iPerEmpEN)
    End Sub


    Sub GenerarAccionesDisponibles()
        Dim oUsu, oVO, oPer As New SuperEntidad
        Dim lisVO As New List(Of SuperEntidad)

        'TRAEMOS TODAS LAS ACCIONES DISPONIBLES
        oVO.CampoOrden = cam.CodVen
        lisVO = vo.obtenerVentanaOpcionesExis(oVO)

        If lisVO.Count <> 0 Then
            For Each ob As SuperEntidad In lisVO
                oPer.CodigoUsuario = Me.txtCodUsu.Text.Trim
                oPer.CodigoVentana = ob.CodigoVentana
                oPer.CodigoOpcion = ob.CodigoOpcion
                per.nuevoPermiso(oPer)
            Next
        End If
    End Sub


#End Region


    Private Sub WEditarUsuario_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If Me.Text = "Visualizar Usuario" Then
            Me.Close()
        Else
            Dim rpta As Integer = MsgBox("Deseas cancelar la operacion", MsgBoxStyle.YesNo)
            If rpta = MsgBoxResult.Yes Then
                Me.Close()
            Else
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Me.Text = "Eliminar Usuario" Then
            Me.Aceptar()
            Exit Sub
        End If
        If acc.CamposObligatorios = False Then
            Exit Sub
        Else
            If Varios.CompararCadenas(Me.txtCla, Me.txtCon, "Las Claves") = False Then
                Exit Sub
            Else
                Me.Aceptar()
            End If
        End If
    End Sub


#Region "Validating"

    Private Sub txtCodUsu_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodUsu.Validating
        If Me.Text = "Nuevo Usuario" Then
            Dim codUsu As String = Me.txtCodUsu.Text.Trim
            If codUsu = "" Then
                Exit Sub
            Else
                Dim obj As New SuperEntidad
                obj.DatoCondicion1 = codUsu
                'Se busca en toda la tabla Usuario
                If usu.existeUsuarioPorCodigo(obj) = True Then
                    MsgBox("Este Usuario ya existe", MsgBoxStyle.Information)
                    Me.txtCodUsu.Text = ""
                    Me.txtCodUsu.Focus()
                    e.Cancel = True
                Else
                    Exit Sub
                End If
            End If
        End If

    End Sub


    'Private Sub txtCodPer_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
    '    'solo cuando se agrega 
    '    If Me.Text = "Nuevo Usuario" Then
    '        Dim codPer As String = Me.txtCodPer.Text.Trim
    '        If codPer = "" Then
    '            Exit Sub
    '        Else
    '            Dim obj As New SuperEntidad
    '            obj.DatoCondicion1 = codPer
    '            'Se busca en toda la tabla Usuario
    '            If usu.existeUsuarioPorCodigoPersonal(obj) = True Then
    '                MsgBox("Este Personal ya Tiene Usuario", MsgBoxStyle.Information)
    '                Me.txtCodPer.Text = ""
    '                Me.txtNomPer.Text = ""
    '                Me.txtCodUsu.Text = ""
    '                e.Cancel = True
    '            Else
    '                Dim ope As New OperaWin : ope.txt1 = Me.txtCodPer : ope.txt2 = Me.txtNomPer : ope.txt3 = Me.txtCodUsu
    '                ope.MostrarCodigoDescripcionDePersonal("Personal", e)
    '                Me.txtCodUsu.Focus()
    '                Exit Sub
    '            End If
    '        End If
    '    End If
    'End Sub
#End Region

#Region "Mostrar Formularios lista"

    'Private Sub txtCodPer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If Me.txtCodPer.ReadOnly = False Then
    '        If e.KeyCode = Keys.F1 Then
    '            Dim win As New WListarPersonal
    '            win.titulo = "Personal"
    '            win.CondicionLista = "PersonalActivo"
    '            win.txt1 = Me.txtCodPer
    '            win.txt2 = Me.txtNomPer
    '            win.txt3 = Me.txtCodUsu
    '            win.NuevaVentana()
    '        End If
    '    End If

    'End Sub

#End Region




  
End Class