Imports Entidad
Imports Negocio
Public Class WEditarFiles

#Region "Propietarios"
    Public wFil As New WFiles
#End Region

    Public ent As New SuperEntidad
    Public lista As New List(Of SuperEntidad)
    Public tab As New TablaRN
    Public fil As New FilesRN
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
        Me.Text = "Agregar " + Me.wFil.titulo
        acc.LimpiarControles()
        'Por Defecto
        Me.PorDefecto()
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.TxtCodFil)
        'los controles que deben estar activos
        acc.Nuevo()
        '\\
    End Sub

    Sub ventanaModificar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Modificar " + Me.wFil.titulo
        'mostrar el registro en pantalla
        Me.obtenerFilesEnPantalla(codigo)
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.TxtNomFil)
        'los controles que deben estar activos
        acc.Modificar()
        '\\
    End Sub

    Sub ventanaEliminar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Eliminar " + Me.wFil.titulo
        'mostrar el registro en pantalla
        Me.obtenerFilesEnPantalla(codigo)
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
        Me.Text = "Visualizar " + Me.wFil.titulo
        'mostrar el registro en pantalla
        Me.obtenerFilesEnPantalla(codigo)
        'foco
        Me.btnAceptar.Focus()
        'los controles que deben estar activos
        acc.Visualizar()
        '\\
    End Sub

    Sub obtenerFilesEnPantalla(ByRef cod As String)
        '//
        'Buscamos el registro de codigo "Cod"
        ent.ClaveFile = cod
        ent = fil.buscarFilesExisPorClave(ent)
        'preguntar si ent tiene el registro
        If ent.CodigoEmpresa = "" Then
            Exit Sub
        Else
            '/Pasar Datos a los controles
            Me.txtCodEmp.Text = ent.CodigoEmpresa
            Me.txtNomEmp.Text = ent.RazonSocialEmpresa
            Me.TxtCodFil.Text = ent.CodigoFile
            Me.TxtNomFil.Text = ent.NombreFile
            Gb.pasarDato(Me.gbEstado, ent.EstadoFile)
        End If
        '\\
    End Sub

    Sub Aceptar()
        '// Lo ques graba en la tabla
        If Me.operacion = 1 Or Me.operacion = 2 Then
            'Volver a traer el registro 
            ent.DatoCondicion1 = ent.ClaveFile
            'ent.ClaveComprobante = Me.TxtCodProy.Text.Trim
            ent = fil.buscarFilesActPorCodigo(ent)
        End If
        ent.CodigoEmpresa = Me.txtCodEmp.Text.Trim()
        ent.RazonSocialEmpresa = Me.txtNomEmp.Text.Trim()
        ent.CodigoFile = Me.TxtCodFil.Text.Trim()
        ent.NombreFile = Me.TxtNomFil.Text.Trim()
        ent.EstadoFile = Rbt.radioActivo(Me.gbEstado).Text.Trim
        ent.Exporta = "0"

        '/Se graba o0 se modifica?
        Select Case Me.operacion

            Case 0
                'Nuevo registro
                fil.nuevaFiles(ent)

                'generar Voucher
                Me.GenerarVoucher()

                MsgBox(Me.wFil.titulo + " ingresado correctamente", MsgBoxStyle.Information, Me.wFil.titulo)
                'Limpiamos los controles para un nuevo registro
                acc.LimpiarControles()
                Me.PorDefecto()
                Me.TxtCodFil.Focus()

            Case 1
                'Modificar Registro
                fil.modificarFiles(ent)
                MsgBox(Me.wFil.titulo + " modificado correctamente", MsgBoxStyle.Information, Me.wFil.titulo)
                Me.Close()

            Case 2
                'eliminamos el file
                fil.eliminarFilesFis(ent)

                'eliminamos sus voucher creados
                Me.EliminarVouchers()

                MsgBox(Me.wFil.titulo + " Eliminado correctamente", MsgBoxStyle.Information, Me.wFil.titulo)
                Me.Close()

        End Select
        '/Actualizar y buscar el registro grabado
        Me.wFil.ActualizarVentana()
        Dgv.obtenerCursorActual(Me.wFil.DgvFil, ent.ClaveFile, Me.wFil.lista)
        '\\
    End Sub

    Function TraerTodosLosAñosDiferentesDePeriodosXEmpresa() As List(Of String)
        Dim iPerRN As New PeriodoRN
        Dim iPerEN As New SuperEntidad
        iPerEN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iPerEN.CampoOrden = cam.CodPer
        Return iPerRN.ObtenerLosAnosDePeriodosXEmpresa(iPerEN)
    End Function

    Public Sub GenerarVoucher()
        Dim iVouRN As New VoucherRN
        'vamos a agregar un voucher por cada año distinto que esiste
        'en esta empresa
        For Each xAño As String In Me.TraerTodosLosAñosDiferentesDePeriodosXEmpresa
            Dim iVouEN As New SuperEntidad
            iVouEN.CodigoEmpresa = Me.txtCodEmp.Text.Trim()
            iVouEN.AnoVoucher = xAño
            iVouEN.CodigoFile = Me.TxtCodFil.Text.Trim()
            iVouEN.AperturaVoucher = "00000"
            iVouEN.EneroVoucher = "00000"
            iVouEN.FebreroVoucher = "00000"
            iVouEN.MarzoVoucher = "00000"
            iVouEN.AbrilVoucher = "00000"
            iVouEN.MayoVoucher = "00000"
            iVouEN.JunioVoucher = "00000"
            iVouEN.JulioVoucher = "00000"
            iVouEN.AgostoVoucher = "00000"
            iVouEN.SetiembreVoucher = "00000"
            iVouEN.OctubreVoucher = "00000"
            iVouEN.NoviembreVoucher = "00000"
            iVouEN.DiciembreVoucher = "00000"
            iVouEN.CierreVoucher = "00000"
            iVouEN.EstadoVoucher = "1"
            iVouEN.Exporta = "0"
            iVouRN.nuevaVoucher(iVouEN)
        Next
    End Sub

    Sub EliminarVouchers()
        'traer lista de todos los vouchers del file que se quiere eliminar
        Dim iVouRN As New VoucherRN
        Dim iVouEN As New SuperEntidad
        iVouEN.CodigoEmpresa = Me.txtCodEmp.Text.Trim
        iVouEN.CodigoFile = Me.TxtCodFil.Text.Trim
        iVouEN.CampoOrden = cam.ClaVou
        Dim ilisVou As List(Of SuperEntidad) = iVouRN.obtenerVoucherExisXEmpresaYFile(iVouEN)

        'ir eliminando cada voucher de la lista
        For Each xVou As SuperEntidad In ilisVou
            iVouRN.eliminarVoucherFis(xVou)
        Next
    End Sub

#End Region

    Private Sub WEditarTabla_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        'Solo para eliminar
        If Me.operacion = 2 Then
            Dim rpta As Integer = MsgBox("Deseas eliminar este registro", MsgBoxStyle.YesNo, Me.wFil.titulo)
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
            Dim rpta As Integer = MsgBox("Deseas cancelar la operacion", MsgBoxStyle.YesNo, Me.wFil.titulo)
            If rpta = MsgBoxResult.Yes Then
                Me.Close()
            Else
                Exit Sub
            End If
        End If
    End Sub

#Region "Existe Files"
    

#End Region

#Region "Existe Codigo"

    Function ComprobarClaveFiles() As Boolean
        '/
        If Me.operacion = 0 Then 'Solo cuando Agrega

            Dim cod As String = Me.txtCodEmp.Text.Trim + Me.TxtCodFil.Text.Trim
            If cod = "" Then
                Return False
            Else
                Dim obj As New SuperEntidad
                obj.ClaveFile = cod
                'Se busca en toda la tabla
                If fil.existeFilesPorCodigo(obj) = True Then
                    MsgBox("Este Codigo ya existe", MsgBoxStyle.Information, Me.wFil.titulo)
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

    Private Sub TxtCodFil_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodFil.Validating
        If Me.ComprobarClaveFiles() = True Then
            Me.TxtCodFil.Text = ""
            Me.TxtCodFil.Focus()
            e.Cancel = False
        Else
            Exit Sub
        End If
    End Sub
End Class