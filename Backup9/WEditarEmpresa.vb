Imports Entidad
Imports Negocio
Public Class WEditarEmpresa

#Region "Propietarios"
    Public wEmp As New WEmpresa
#End Region
    Public ent As New SuperEntidad
    Public lista As New List(Of SuperEntidad)
    Public tab As New TablaRN
    Public emp As New EmpresaRN
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

    Sub ventanaAdicionar()
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Agregar " + Me.wEmp.titulo
        acc.LimpiarControles()
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtCodEmp)
        'los controles que deben estar activos
        acc.Nuevo()
        '\\
    End Sub

    Sub ventanaModificar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Modificar " + Me.wEmp.titulo
        'mostrar el registro en pantalla
        Me.obtenerItemTablaEnPantalla(codigo)
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtNomEmp)
        'los controles que deben estar activos
        acc.Modificar()
        '\\
    End Sub

    Sub ventanaEliminar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Eliminar " + Me.wEmp.titulo
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
        Me.Text = "Visualizar " + Me.wEmp.titulo
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
        ent.CodigoEmpresa = cod
        ent = emp.buscarEmpresaExisPorCodigo(ent)
        'preguntar si ent tiene el registro
        If ent.CodigoEmpresa = "" Then
            Exit Sub
        Else
            '/Pasar Datos a los controles
            Me.txtCodEmp.Text = ent.CodigoEmpresa
            Me.txtNomEmp.Text = ent.RazonSocialEmpresa
            Me.TxtNomEmpCor.Text = ent.NombreCortoEmpresa
            Me.TxtDirEmp.Text = ent.direccionEmpresa
            Me.TxtRucEmp.Text = ent.RucEmpresa
            Gb.pasarDato(Me.gbEstado, ent.EstadoEmpresa)
        End If
        '\\
    End Sub

    Sub Aceptar()
        '// Lo ques graba en la tabla
        If Me.operacion = 1 Or Me.operacion = 2 Then
            'Volver a traer el registro 
            ent.DatoCondicion1 = ent.CodigoEmpresa
            'ent.ClaveComprobante = Me.TxtCodProy.Text.Trim
            ent = emp.buscarEmpresaActPorCodigo(ent)
        End If
        ent.CodigoEmpresa = Me.txtCodEmp.Text.Trim()
        ent.RazonSocialEmpresa = Me.txtNomEmp.Text.Trim()
        ent.NombreCortoEmpresa = Me.TxtNomEmpCor.Text.Trim()
        ent.direccionEmpresa = Me.TxtDirEmp.Text.Trim()
        ent.RucEmpresa = Me.TxtRucEmp.Text.Trim()
        ent.EstadoEmpresa = Rbt.radioActivo(Me.gbEstado).Text.Trim
        'ent.EstadoCuenta = Rbt.radioActivo(Me.gbEstado).Text.Trim()
        ent.Exporta = "0"

        '/Se graba o0 se modifica?
        Select Case Me.operacion

            Case 0
                'Nuevo registro
                emp.nuevaEmpresa(ent)

                'generar permisos empresa
                Me.GenerarPermisosEmpresa()

                ''adicionar nuevo periodo
                Me.AdicionarNuevoPeriodo()

                MsgBox(Me.wEmp.titulo + " ingresado correctamente", MsgBoxStyle.Information, Me.wEmp.titulo)
                'Limpiamos los controles para un nuevo registro
                acc.LimpiarControles()
                Me.txtCodEmp.Focus()

            Case 1
                'Modificar Registro
                emp.modificarEmpresa(ent)
                MsgBox(Me.wEmp.titulo + " modificado correctamente", MsgBoxStyle.Information, Me.wEmp.titulo)
                Me.Close()

            Case 2
                'eliminamos al usuario pero logicamente
                emp.eliminarEmpresaFis(ent)

                'eliminar permisos empresa
                Me.EliminarPermisosEmpresa()

                'elimina los periodos
                Me.EliminarPeriodosEmpresa()

                MsgBox(Me.wEmp.titulo + " Eliminado correctamente", MsgBoxStyle.Information, Me.wEmp.titulo)
                Me.Close()

        End Select
        '/Actualizar y buscar el registro grabado
        Me.wEmp.ActualizarVentana()
        Dgv.obtenerCursorActual(Me.wEmp.DgvEmp, ent.CodigoEmpresa, Me.wEmp.lista)
        '\\
    End Sub

    Sub GenerarPermisosEmpresa()
        'TRAER TODOS LOS USUARIOS QUE EXISTEN EN B.D 
        Dim iUsuRN As New UsuarioRN
        Dim lisUsu As New List(Of SuperEntidad)
        Dim iUsuEN As New SuperEntidad
        iUsuEN.CampoOrden = cam.CodUsu
        lisUsu = iUsuRN.obtenerUsuarios(iUsuEN)

        'GRABAR TODAS ESTAS EMPRESAS EN USUARIOEMPRESA
        Dim emp As String = Me.txtCodEmp.Text.Trim
        Dim iPerEmpRN As New PermisoEmpresaRN
        iPerEmpRN.GenerarPermisosUsuariosXEmpresa(emp, lisUsu)
    End Sub

    Sub EliminarPermisosEmpresa()
        Dim iPerEmpEN As New PermisoEmpresaEN
        Dim iPerEmpRN As New PermisoEmpresaRN
        iPerEmpEN.CodigoEmpresa = Me.txtCodEmp.Text.Trim
        iPerEmpRN.eliminarSoloEmpresaFis(iPerEmpEN)
    End Sub

    Sub AdicionarNuevoPeriodo()
        Dim iPerRN As New PeriodoRN
        Dim iPerEN As New SuperEntidad
        iPerEN.CodigoEmpresa = Me.txtCodEmp.Text.Trim()
        iPerEN.CodigoPeriodo = SuperEntidad.xPeriodoEmpresa
        iPerEN.CMesPeriodo = iPerEN.CodigoPeriodo.Substring(4, 2)
        iPerEN.CEstadoPeriodo = "1"
        iPerEN.Exporta = "0"
        iPerRN.nuevaPeriodo(iPerEN)
    End Sub

    Sub EliminarPeriodosEmpresa()
        Dim iPerRN As New PeriodoRN
        Dim iPerEN As New SuperEntidad
        iPerEN.CodigoEmpresa = Me.txtCodEmp.Text.Trim
        iPerRN.eliminarPeriodosXEmpresaFis(iPerEN)
    End Sub


#End Region

    Private Sub WEditarTabla_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        'Solo para eliminar
        If Me.operacion = 2 Then
            Dim rpta As Integer = MsgBox("Deseas eliminar este registro", MsgBoxStyle.YesNo, Me.wEmp.titulo)
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
            Dim rpta As Integer = MsgBox("Deseas cancelar la operacion", MsgBoxStyle.YesNo, Me.wEmp.titulo)
            If rpta = MsgBoxResult.Yes Then
                Me.Close()
            Else
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txtCodEmp_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodEmp.Validating
        If Me.operacion = 0 Then
            Dim codEmp As String = Me.txtCodEmp.Text.Trim
            If codEmp = "" Then
                Exit Sub
            Else
                Dim obj As New SuperEntidad
                obj.DatoCondicion1 = codEmp
                'Se busca en toda la tabla Usuario
                Dim iEmpRN As New EmpresaRN
                If iEmpRN.existeEmpresaPorCodigo(obj) = True Then
                    MsgBox("Esta empresa ya existe", MsgBoxStyle.Information)
                    Me.txtCodEmp.Text = ""
                    Me.txtCodEmp.Focus()
                    e.Cancel = True
                Else
                    Exit Sub
                End If
            End If
        End If

    End Sub
End Class