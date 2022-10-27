Imports Entidad
Imports Negocio
Public Class WPersonalEstado
#Region "Propietarios"
    'Public wPer As New WPersonal
#End Region

    Public ent As New SuperEntidad
    Public lista As New List(Of SuperEntidad)
    'Public per As New PersonalRN
    'Public mov As New MovHorasRN
    Public cam As New CamposEntidad

#Region "Metodos"


    Sub InicializaVentana()
        '/Ejecucion en ventana
        Me.Owner.Enabled = False
        Me.Show()
    End Sub

    Sub ventanaModificar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        'mostrar el registro en pantalla
        Me.obtenerPersonalEnPantalla(codigo)
        '\\
    End Sub

    Sub obtenerPersonalEnPantalla(ByRef codPer As String)
        '//
        ent.DatoCondicion1 = codPer
        'ent = per.buscarPersonalExisPorCodigo(ent)
        'preguntar si ent tiene el registro
        'If ent.CodigoPersonal = "" Then
        '    Exit Sub
        'Else
        '    '/Pasar Datos a los controles
        '    Me.lblPersonal.Text = ent.CodigoPersonal + " : " + ent.NombreCompletoPersonal
        '    'Estado Uusraio
        '    'Select Case ent.EstadoRegistro
        '    '    Case "Activo"
        '    '        Me.rbtAct.Checked = True
        '    '    Case "Desactivo"
        '    '        Me.rbtDes.Checked = True
        '    'End Select
        '    Gb.pasarDato(Me.GroupBox1, ent.EstadoRegistro)
        '    Me.dtpFechIng.Text = ent.FechaBajaPersonal
        'End If
        '\\
    End Sub

    Sub Aceptar()
        '//
        'Volver a traer el registro 
        'ent.DatoCondicion1 = ent.CodigoPersonal
        'ent = per.buscarPersonalExisPorCodigo(ent)


        'Estado Usuario
        Dim str As String = Rbt.radioActivo(Me.GroupBox1).Text.ToString.Trim()
        Select Case str
            Case "Activo"
                'If ent.FechaBajaPersonal = "" Then
                '    ent.EstadoRegistro = "1"
                '    ent.FechaBajaPersonal = ""
                'Else
                '    If Me.dtpFechIng.Value > CType(ent.FechaBajaPersonal, DateTime) Then
                '        ent.EstadoRegistro = "1"
                '        ent.FechaBajaPersonal = ""
                '    Else
                '        MsgBox("la fecha de activacion debe ser mayor que la fecha de baja", MsgBoxStyle.Exclamation)
                '        Exit Sub
                '    End If



                'End If

            Case "Deshabilitado"
                ent.EstadoRegistro = "0"
                'ent.FechaBajaPersonal = Varios.FormatoDia(Me.dtpFechIng.Value.Day.ToString) + "/" + Varios.FormatoMes(Me.dtpFechIng.Value.Month.ToString) + "/" + Me.dtpFechIng.Value.Year.ToString
        End Select



        '/modificar
        'per.modificarPersonal(ent)
        MsgBox("Personal modificado correctamente", MsgBoxStyle.Information)
        Me.Close()

        '/Actualizar y buscar el registro grabado
        'Me.wPer.ActualizarVentana()
        'ent.NombreCompletoPersonal = ent.ApellidoPaternoPersonal + Space(1) + ent.ApellidoMaternoPersonal + Space(1) + ent.nombresPersonal
        'Dgv.obtenerCursorActual(Me.wPer.DgvPer, ent.NombreCompletoPersonal, Me.wPer.lista)
        '\\
    End Sub

#End Region

    Private Sub WEditarPersonal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Me.rbtAct.Checked = False Then
            Dim rpta As Integer = MsgBox("Si deshabilitas este personal se eliminaran todas sus horas desde la fecha de baja hasta ahora", MsgBoxStyle.YesNo)
            If rpta = MsgBoxResult.Yes Then
                Me.Aceptar()
                'quitar las horas despues de la fecha de baja
                'ent.CodigoPersonalMovHoras = ent.CodigoPersonal
                'ent.FechaMovHoras = Me.dtpFechIng.Value
                'mov.eliminarMovHorasFisPorHorasAdelante(ent)
            End If
        Else
            Me.Aceptar()
            Exit Sub
        End If

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Dim rpta As Integer = MsgBox("Deseas cancelar la operacion", MsgBoxStyle.YesNo)
        If rpta = MsgBoxResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub rbtAct_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtAct.CheckedChanged
        'If Me.rbtAct.Checked = True Then
        '    Me.dtpFechIng.Enabled = False
        'Else
        '    Me.dtpFechIng.Enabled = True
        'End If
    End Sub
End Class