Imports Entidad
Imports Negocio
Public Class WEditarPeriodo

#Region "Propietarios"
    Public wPer As New WPeriodo
#End Region
    Public ent As New SuperEntidad
    Public lista As New List(Of SuperEntidad)
    Public tab As New TablaRN
    Public emp As New PeriodoRN
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
        Me.Text = "Agregar " + Me.wPer.titulo
        acc.LimpiarControles()
        'poner el cursor de inicio
        Me.PorDefecto()
        Txt.cursorAlUltimo(Me.TxtPeriodo)
        'los controles que deben estar activos
        acc.Nuevo()
        '\\
    End Sub

    Sub ventanaModificar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Modificar " + Me.wPer.titulo
        'mostrar el registro en pantalla
        Me.PorDefecto()

        Me.obtenerItemTablaEnPantalla(codigo)
        'poner el cursor de inicio
        '        Txt.cursorAlUltimo(Me.cmd.gbEstado)
        'los controles que deben estar activos
        Me.gbEstado.Focus()
        acc.Modificar()
        '\\
    End Sub

    Sub ventanaEliminar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Eliminar " + Me.wPer.titulo
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
        Me.Text = "Visualizar " + Me.wPer.titulo
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
        ent.ClavePeriodo = cod
        ent = emp.BuscarPeriodoXClave(ent)
        'preguntar si ent tiene el registro
        If ent.ClavePeriodo = "" Then
            Exit Sub
        Else
            '/Pasar Datos a los controles
            Me.txtCodEmp.Text = ent.CodigoEmpresa
            Me.txtNomEmp.Text = ent.RazonSocialEmpresa
            Me.TxtPeriodo.Text = ent.CodigoPeriodo
            If ent.CEstadoPeriodo = "0" Then
                Me.rbcerrada.Checked = True
            Else
                Me.rbactiva.Checked = True
            End If
            'Gb.pasarDato(Me.gbEstado, ent.CEstadoPeriodo)
        End If
        '\\
    End Sub

    Sub Aceptar()
        '// Lo ques graba en la tabla
        If Me.operacion = 1 Or Me.operacion = 2 Then
            'Volver a traer el registro 
            ent.DatoCondicion1 = ent.ClavePeriodo
            'ent.ClaveComprobante = Me.TxtCodProy.Text.Trim
            ent = emp.BuscarPeriodoXClave(ent)
        End If
        ent.CodigoEmpresa = Me.txtCodEmp.Text.Trim()
        ent.RazonSocialEmpresa = Me.txtNomEmp.Text.Trim()
        ent.CodigoPeriodo = Me.TxtPeriodo.Text.Trim()
        ent.CMesPeriodo = ent.CodigoPeriodo.Substring(4, 2)
        ent.CEstadoPeriodo = Rbt.radioActivo(Me.gbEstado).Text.Trim
        If ent.CEstadoPeriodo = "Abierto" Then
            ent.CEstadoPeriodo = "1"
        Else
            ent.CEstadoPeriodo = "0"
        End If
        'ent.EstadoCuenta = Rbt.radioActivo(Me.gbEstado).Text.Trim()
        ent.ResultadoMes = 0
        ent.ResultadoAcumulado = 0
        ent.Exporta = "0"

        '/Se graba o0 se modifica?
        Select Case Me.operacion

            Case 0
                'CREAR TODOS LOS VOUCHERS SOLO SI ES UN NUEVO AÑO
                Me.GrabarVoucherNuevoAno()

                'Nuevo registro
                emp.nuevaPeriodo(ent)

                MsgBox(Me.wPer.titulo + " ingresado correctamente", MsgBoxStyle.Information, Me.wPer.titulo)
                'Limpiamos los controles para un nuevo registro
                acc.LimpiarControles()
                Me.TxtPeriodo.Focus()

            Case 1
                'Modificar Registro
                emp.modificarPeriodo(ent)

                MsgBox(Me.wPer.titulo + " modificado correctamente", MsgBoxStyle.Information, Me.wPer.titulo)
                Me.Close()

            Case 2
                'eliminamos al usuario pero logicamente
                emp.eliminarPeriodoFis(ent)
                MsgBox(Me.wPer.titulo + " Eliminado correctamente", MsgBoxStyle.Information, Me.wPer.titulo)
                Me.Close()

        End Select
        '/Actualizar y buscar el registro grabado
        Me.wPer.ActualizarVentana()
        Dgv.obtenerCursorActual(Me.wPer.DgvPer, ent.CodigoEmpresa + "-" + ent.CodigoPeriodo, Me.wPer.lista)
        '\\
    End Sub

    Sub GrabarVoucherNuevoAno()

        'PREGUNTAR SI EL ANNO DEL PERIODO QUE SE ESTA REGISTRANDO NO EXISTE
        Dim iPerRN As New PeriodoRN
        Dim iPerEN As New SuperEntidad
        iPerEN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iPerEN.CodigoPeriodo = Me.TxtPeriodo.Text.Trim.Substring(0, 4)
        If iPerRN.HayAnoRegistrado(iPerEN) = False Then

            'CREAMOS LOS VOUCHER A TODOS LOS FILES QUE TIENE ESTA EMPRESA
            'PARA EL NUEVO ANNO
            Dim iVouRN As New VoucherRN
            Dim iVouEN As New SuperEntidad
            iVouEN.AnoVoucher = iPerEN.CodigoPeriodo
            iVouEN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
            iVouRN.nuevosVoucherParaNuevoAño(iVouEN)
        End If
    End Sub

 
#End Region

    Private Sub WEditarTabla_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        'Solo para eliminar
        If Me.operacion = 2 Then
            'VOLVER A PREGUNTAR SI ES ACTO ELIMINAR EL PERIODO
            If Me.wPer.EsActoEliminarPeriodo = False Then Exit Sub

            'PREGUNTAR SI DESEA ELIMINAR EL PERIODO
            Dim rpta As Integer = MsgBox("Deseas eliminar este registro", MsgBoxStyle.YesNo, Me.wPer.titulo)
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
            Dim rpta As Integer = MsgBox("Deseas cancelar la operacion", MsgBoxStyle.YesNo, Me.wPer.titulo)
            If rpta = MsgBoxResult.Yes Then
                Me.Close()
            Else
                Exit Sub
            End If
        End If
    End Sub

End Class