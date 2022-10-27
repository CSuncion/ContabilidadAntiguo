Imports Entidad

Imports Negocio
Public Class WEditarTabla

#Region "Propietarios"
    Public wtab As New WTabla
#End Region

    Public ent As New SuperEntidad
    Public lista As New List(Of SuperEntidad)
    Public cam As New CamposEntidad
    Public vou As New VoucherRN
    Public tab As New TablaRN
    Public acc As New Accion
    Public inicioCodigo As String


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
        'If Me.wtab.arg = "File" Then
        '    Me.txtVou.Visible = True
        '    Me.Label3.Visible = True
        'Else
        '    Me.txtVou.Text = "0"
        'End If
        'Que se muestre la leyenda solo para este arg
        If Me.wtab.arg = "Ingresos/Egresos" Then
            Me.lblInEg.Visible = True
        End If
        Me.Show()

    End Sub

    Sub ventanaAdicionar()
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Agregar " + Me.wtab.arg
        'Iniciar codigo
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
        Me.Text = "Modificar " + Me.wtab.arg
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
        Me.Text = "Eliminar " + Me.wtab.arg
        'mostrar el registro en pantalla
        Me.obtenerItemTablaEnPantalla(codigo)
        'cambiar nombre al boton
        Me.btnAceptar.Text = "Eliminar"
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
        Me.Text = "Visualizar " + Me.wtab.arg
        'mostrar el registro en pantalla
        Me.obtenerItemTablaEnPantalla(codigo)
        'los controles que deben estar activos
        acc.Visualizar()
        '\\
    End Sub

    Sub obtenerItemTablaEnPantalla(ByRef cod As String)
        '//
        'Buscamos el registro de codigo "Cod"
        ent.DatoCondicion1 = Me.wtab.tipoTabla
        ent.DatoCondicion2 = cod
        ent = tab.buscarItemTablaExisPorTipoTablaYCodigo(ent)
        'preguntar si ent tiene el registro
        If ent.CodigoItemTabla = "" Then
            Exit Sub
        Else
            '/Pasar Datos a los controles
            Me.txtCod.Text = ent.CodigoItemTabla
            Me.txtNom.Text = ent.NombreItemTabla
            'If Me.wtab.arg = "File" Then
            '    Me.txtVou.Text = ent.Voucher
            'Else
            '    Me.txtVou.Text = "0"
            'End If

        End If
        '\\
    End Sub

    Sub CrearFileVoucher()
        'Solo cuando es Nuevo o Adiciona
        If Me.Text <> "Agregar " + Me.wtab.arg Then Exit Sub
        'Solo cuano es File
        If Me.wtab.tipoTabla <> "Fil" Then Exit Sub
        'Si todo es Ok 

        Dim oVou As New SuperEntidad

        oVou.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        oVou.AnoVoucher = SuperEntidad.xPeriodoEmpresa.Substring(0, 4)
        oVou.CodigoFile = Me.txtCod.Text.Trim()
        oVou.AperturaVoucher = "000000"
        oVou.EneroVoucher = "000000"
        oVou.FebreroVoucher = "000000"
        oVou.MarzoVoucher = "000000"
        oVou.AbrilVoucher = "000000"
        oVou.MayoVoucher = "000000"
        oVou.JunioVoucher = "000000"
        oVou.JulioVoucher = "000000"
        oVou.AgostoVoucher = "000000"
        oVou.SetiembreVoucher = "000000"
        oVou.OctubreVoucher = "000000"
        oVou.NoviembreVoucher = "000000"
        oVou.DiciembreVoucher = "000000"
        oVou.CierreVoucher = "000000"
        oVou.EstadoVoucher = "1"
        oVou.Exporta = "0"
        'Grabar Automatico en Files
        vou.nuevaVoucher(oVou)
    End Sub
    Sub Aceptar()
        '//
        If Me.Text = "Modificar " + Me.wtab.arg Or Me.Text = "Eliminar " + Me.wtab.arg Then
            'Volver a traer el registro 
            ent.DatoCondicion1 = Me.wtab.tipoTabla
            ent.DatoCondicion2 = Me.txtCod.Text.Trim
            ent = tab.buscarItemTablaExisPorTipoTablaYCodigo(ent)
        End If

        ent.TipoTabla = Me.wtab.tipoTabla
        ent.CodigoItemTabla = Me.txtCod.Text.Trim
        ent.NombreItemTabla = Me.txtNom.Text.Trim
        'ent.Voucher = Me.txtVou.Text.Trim
        Me.CrearFileVoucher()

        '/Se graba o0 se modifica?
        Select Case Me.Text

            Case "Agregar " + Me.wtab.arg
                'Nuevo registro
                tab.nuevoItemTabla(ent)
                MsgBox(Me.wtab.arg + " ingresado correctamente", MsgBoxStyle.Information)
                'Limpiamos los controles para un nuevo registro
                acc.LimpiarControles()
                'If Me.wtab.arg <> "File" Then
                '    Me.txtVou.Text = "0"
                'End If
                Me.txtCod.Focus()

            Case "Modificar " + Me.wtab.arg
                'Modificar Registro
                tab.modificarItemTabla(ent)
                MsgBox(Me.wtab.arg + " modificado correctamente", MsgBoxStyle.Information)
                Me.Close()

            Case "Eliminar " + Me.wtab.arg
                'eliminamos al usuario pero logicamente
                tab.eliminarItemTablaFis(ent)
                MsgBox(Me.wtab.arg + " Eliminado correctamente", MsgBoxStyle.Information)
                Me.Close()

        End Select
        '/Actualizar y buscar el registro grabado
        Me.wtab.ActualizarVentana()
        Dgv.obtenerCursorActual(Me.wtab.DgvDis, ent.NombreItemTabla, Me.wtab.lista)
        '\\
    End Sub


#End Region



    Private Sub WEditarTabla_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Me.Text = "Eliminar " + Me.wtab.arg Then
            Me.Aceptar()
            Exit Sub
        End If

        If acc.CamposObligatorios = False Then
            Exit Sub
        Else
            Me.Aceptar()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If Me.Text = "Visualizar " + Me.wtab.arg Then
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


#Region "Codigo existe"

    Private Sub txtCod_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCod.Validating
        If Me.Text = "Agregar " + Me.wtab.arg Then
            Dim cod As String = Me.txtCod.Text.Trim
            If cod = "" Then
                Exit Sub
            Else
                Dim obj As New SuperEntidad
                obj.DatoCondicion1 = Me.wtab.tipoTabla
                obj.DatoCondicion2 = cod
                'Se busca en toda la tabla
                If tab.existeItemTablaExisPorTipoTablaYCodigo(obj) = True Then
                    MsgBox("Este codigo ya existe", MsgBoxStyle.Information)
                    Me.txtCod.Text = Me.inicioCodigo
                    'Me.txtCod.Focus()
                    Txt.cursorAlUltimo(Me.txtCod)
                    e.Cancel = True
                Else
                    Exit Sub
                End If
            End If
        End If
    End Sub

#End Region

    Private Sub WEditarTabla_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class