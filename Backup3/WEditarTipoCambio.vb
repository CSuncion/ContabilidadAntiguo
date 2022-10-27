Imports Entidad
Imports Negocio

Public Class WEditarTipoCambio
#Region "Propietarios"
    Public wTc As New WTipoCambio
#End Region

    Public ent As New SuperEntidad
    Public lista As New List(Of SuperEntidad)
    Public tc As New TipoCambioRN
    Public cam As New CamposEntidad
    'Public tab As New TablaRN
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
        '/Ejecucion en ventana
        Me.Owner.Enabled = False
        Me.Show()
    End Sub

    Sub ventanaAdicionar()
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Agregar Tipo Cambio"
        'limpiar
        acc.LimpiarControles()
        'poner el cursor de inicio
        Me.dtpFecha.Focus()
        'los controles que deben estar activos
        acc.Nuevo()
        '\\
    End Sub

    Sub ventanaModificar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Modificar Tipo Cambio"
        'mostrar el registro en pantalla
        Me.obtenerTipoCambioEnPantalla(codigo)
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtCom)
        'los controles que deben estar activos
        acc.Modificar()
        '\\
    End Sub

    Sub ventanaEliminar(ByRef codigo As String)
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Eliminar Tipo Cambio"
        'mostrar el registro en pantalla
        Me.obtenerTipoCambioEnPantalla(codigo)
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
        Me.Text = "Visualizar Tipo Cambio"
        'mostrar el registro en pantalla
        Me.obtenerTipoCambioEnPantalla(codigo)
        'los controles que deben estar activos
        'foco
        Me.btnAceptar.Focus()
        acc.Visualizar()
    End Sub

    Sub obtenerTipoCambioEnPantalla(ByRef cod As String)
        '//
        ent.DatoCondicion1 = cod
        ent = tc.buscarTipoCambioExisPorFecha(ent)
        'preguntar si ent tiene el registro
        If ent.AnoTipoCambio = "" Then
            Exit Sub
        Else
            '/Pasar Datos a los controles
            Me.dtpFecha.Value = ent.FechaTipoCambio
            Me.lblFecha.Text = ent.FechaTipoCambio.ToLongDateString
            Me.txtCom.Text = ent.CompraTipoCambio.ToString
            Me.txtVen.Text = ent.VentaTipoCambio.ToString
            Me.TxtComE.Text = ent.CompraEurTipoCambio.ToString
            Me.TxtVenE.Text = ent.VentaEurTipoCambio.ToString
            Me.txtDolEur.Text = ent.DolarEuroTipoCambio.ToString
        End If
        '\\
    End Sub

    Sub Aceptar()
        '//

        If Me.Text = "Modificar Tipo Cambio" Or Me.Text = "Eliminar Tipo Cambio" Then
            'Volver a traer el registro 
            Dim cod As String
            cod = ent.FechaTipoCambio.Year.ToString + "/" + ent.FechaTipoCambio.Month.ToString + "/" + ent.FechaTipoCambio.Day.ToString
            ent.DatoCondicion1 = cod
            ent = tc.buscarTipoCambioExisPorFecha(ent)
        End If
        'Pasamos los datos que vamos a cargar
        ent.FechaTipoCambio = Me.dtpFecha.Value
        ent.CompraTipoCambio = CType(Me.txtCom.Text.Trim, Decimal)
        ent.VentaTipoCambio = CType(Me.txtVen.Text.Trim, Decimal)
        ent.CompraEurTipoCambio = CType(Me.TxtComE.Text.Trim, Decimal)
        ent.VentaEurTipoCambio = CType(Me.TxtVenE.Text.Trim, Decimal)
        ent.DolarEuroTipoCambio = CType(Me.txtDolEur.Text.Trim, Decimal)

        '/Se graba o0 se modifica?
        Select Case Me.Text

            Case "Agregar Tipo Cambio"
                tc.nuevoTipoCambio(ent)
                MsgBox("Tipo Cambio ingresado correctamente", MsgBoxStyle.Information)
                acc.LimpiarControles()
                Me.dtpFecha.Focus()

            Case "Modificar Tipo Cambio"

                tc.modificarTipoCambio(ent)
                MsgBox("Tipo Cambio modificado correctamente", MsgBoxStyle.Information)
                Me.Close()

            Case "Eliminar Tipo Cambio"
                'eliminamos al usuario pero logicamente
                tc.eliminarTipoCambioFis(ent)
                MsgBox("Tipo Cambio Eliminado correctamente", MsgBoxStyle.Information)
                Me.Close()

        End Select
        '/Actualizar y buscar el registro grabado
        Me.wTc.ActualizarVentana()
        Dim fecha As String = ent.FechaTipoCambio.Day.ToString + "/" + ent.FechaTipoCambio.Month.ToString + "/" + ent.FechaTipoCambio.Year.ToString
        Dgv.obtenerCursorActual(Me.wTc.DgvDis, fecha, Me.wTc.lista)
        '\\
    End Sub

#End Region

    Private Sub WEditarTipoCambio_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Me.Text = "Eliminar Tipo Cambio" Then
            Me.Aceptar()
            Exit Sub
        End If

        If acc.CamposObligatorios = False Then
            Exit Sub
        Else
            If Me.Text = "Agregar Tipo Cambio" Then
                Dim cod As String
                cod = Me.dtpFecha.Value.Year.ToString + "/" + Me.dtpFecha.Value.Month.ToString + "/" + Me.dtpFecha.Value.Day.ToString
                ent.DatoCondicion1 = cod
                If tc.existeTipoCambioPorFecha(ent) = True Then
                    MsgBox("Esta Fecha ya existe", MsgBoxStyle.Exclamation)
                    Me.dtpFecha.Focus()
                Else

                    Me.Aceptar()
                End If
            Else
                Me.Aceptar()
            End If
        End If

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If Me.Text = "Visualizar Tipo Cambio" Then
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


#Region "Existe Codigo"

    Private Sub dtpFecha_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFecha.Validated
        'If Me.Text = "Agregar Tipo Cambio" Then
        '    Dim cod As String
        '    cod = Me.dtpFecha.Value.Year.ToString + "/" + Me.dtpFecha.Value.Month.ToString + "/" + Me.dtpFecha.Value.Day.ToString
        '    ent.DatoCondicion1 = cod
        '    If tc.existeTipoCambioPorFecha(ent) = True Then
        '        MsgBox("Esta Fecha ya existe", MsgBoxStyle.Exclamation)
        '        Me.dtpFecha.Focus()
        '    End If

        'End If

    End Sub

#End Region


#Region "Valida fechas"
    Private Sub dtpFecha_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpFecha.Validating
        'If Me.Text = "Agregar Tipo Cambio" Then
        '    If Me.dtpFecha.Value >= Today Then
        '        Me.lblFecha.Text = Me.dtpFecha.Value.ToLongDateString
        '    Else
        '        MsgBox("Se debe elegir de la fecha actual hacia adelante", MsgBoxStyle.Exclamation)
        '        Me.dtpFecha.Value = Today
        '        Me.dtpFecha.Focus()
        '        e.Cancel = True
        '    End If

        'End If

    End Sub
#End Region
End Class