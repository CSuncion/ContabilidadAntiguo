Imports Entidad
Imports Negocio


Public Class WEditarCuentaCorriente

#Region "Propietarios"
    Public wCtaCte As New WCuentaCorriente
#End Region

    Public ent, entD, parEn, ticEn As New SuperEntidad
    Public lista, listaD As New List(Of SuperEntidad)
    Public ccte As New CuentaCorrienteRN
    Public par As New ParametroRN
    Public tic As New TipoCambioRN
    Public cam As New CamposEntidad
    Public tab As New TablaRN
    Public vou As New VoucherRN
    Public emp As New EmpresaRN
    Public acc As New Accion
    Public CondicionLista As String
    Public PeriodoActual As String
    Public operacion As Integer  '0=agregar , 1=modificar , 2=eliminar , 3=visualizar , 4=Manual'

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
        '/Traer objeto parametro
        parEn = par.buscarParametroExis(parEn)
        Me.Show()
    End Sub

    Sub PorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.txtNomEmp.Text = SuperEntidad.xRazonSocial
        '/Instanciar Empresa Actual 
        '  Dim obe As New SuperEntidad
        'obe.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        'obe = emp.buscarEmpresaExisPorCodigo(obe)
        'Me.TxtPeri.Text = obe.PeriodoEmpresa
        Me.TxtPeri.Text = SuperEntidad.xPeriodoEmpresa
        PeriodoActual = SuperEntidad.xPeriodoEmpresa
        'PeriodoActual = obe.PeriodoEmpresa

        Me.TxtPorIgv.Text = parEn.IgvPar.ToString
        Me.txtCodOri.Text = "3"
        Me.txtNomOri.Text = "Diario"
        'Me.TraerTipoCambio()
    End Sub

    Sub TraerTipoCambio()
        'traer tipo de cambio
        ticEn.DatoCondicion1 = Me.dtpFecha.Value.Year.ToString + "/" + Me.dtpFecha.Value.Month.ToString + "/" + Me.dtpFecha.Value.Day.ToString
        ticEn = tic.buscarTipoCambioExisPorFecha(ticEn)
        If ticEn.AnoTipoCambio = "" Then
            MsgBox("el tipo de cambio no existe", MsgBoxStyle.Information)
            Me.txtTipCam.Text = "1.000"
        Else
            Me.txtTipCam.Text = ticEn.VentaTipoCambio.ToString
        End If
    End Sub

    Sub ventanaAdicionar()
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Agregar Cuenta Corriente"
        'poner valores defecto en montos
        acc.LimpiarControles()
        'por defecto
        Me.PorDefecto()
        'Me.ImportesSolesDolares()
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtCodFil)
        'los controles que deben estar activos
        acc.Nuevo()
        '\\
    End Sub

    Sub ventanaModificar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Modificar Cuenta Corriente"
        'mostrar el registro en pantalla
        Me.obtenerCuentaCorrienteEnPantalla(codigo)
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtPagado)
        'los controles que deben estar activos
        acc.Modificar()
        '\\
    End Sub

    Sub ventanaEliminar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Eliminar Cuenta Corriente"
        'mostrar el registro en pantalla
        Me.obtenerCuentaCorrienteEnPantalla(codigo)
        'mostrar el detalle del registro en pantalla

        Me.btnAceptar.Text = "Eliminar"
        Me.btnAceptar.Focus()
        'los controles que deben estar activos
        acc.Eliminar()
                '\\
    End Sub


    Sub ventanaVisualizar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Visualizar Registro Compra"
        'mostrar el registro en pantalla
        Me.obtenerCuentaCorrienteEnPantalla(codigo)
        'mostrar el detalle del registro en pantalla
        'los controles que deben estar activos
        acc.Visualizar()
        
        '\\
    End Sub

    Sub obtenerCuentaCorrienteEnPantalla(ByRef codigo As String)
        '//
        ent.ClaveCuentaCorriente = codigo
        ent = ccte.buscarCuentaCorrienteExisPorClaveCC(ent)
        'preguntar si ent tiene el registro
        If ent.ClaveCuentaCorriente = "" Then
            Exit Sub
        Else
            '/Pasar Datos a los controles
            Me.TxtCodEmp.Text = ent.CodigoEmpresa
            Me.txtNomEmp.Text = ent.RazonSocialEmpresa
            Me.TxtPeri.Text = ent.PeriodoRegContabCabe
            Me.TxtPorIgv.Text = Varios.numeroConDosDecimal(ent.IgvPar.ToString)
            Me.txtCodOri.Text = ent.CodigoOrigen
            Me.txtNomOri.Text = ent.NombreOrigen
            Me.txtCodFil.Text = ent.CodigoFile
            Me.txtNomFil.Text = ent.NombreFile
            Me.txtNumVau.Text = ent.NumeroVoucherRegContabCabe
            Me.txtCodAux.Text = ent.CodigoAuxiliar
            Me.txtNomAux.Text = ent.DescripcionAuxiliar
            Me.txtDoc.Text = ent.TipoDocumento
            Me.txtNomDoc.Text = ent.NombreDocumento
            Me.txtSer.Text = ent.SerieDocumento
            Me.txtNum.Text = ent.NumeroDocumento
            Me.dtpFecha.Value = ent.FechaDocumento
            Me.txtTipCam.Text = ent.VentaTipoCambio.ToString
            Gb.pasarDato(Me.gbMoneda, ent.MonedaDocumento)
            Me.txtPv.Text = Varios.numeroConDosDecimal(ent.ImporteOriginalCuentaCorriente.ToString)
            Me.txtPagado.Text = Varios.numeroConDosDecimal(ent.ImportePagadoCuentaCorriente.ToString)
            Me.txtSaldo.Text = Varios.numeroConDosDecimal(ent.SaldoCuentaCorriente.ToString)
            Me.DtpFechaVcto.Text = ent.FechaVctoDocumento
            Me.TxtCuenta.Text = ent.CodigoCuentaPcge
            Me.TxtNombreCuenta.Text = ent.NombreCuentaPcge
        End If
        '\\
    End Sub

    Sub Aceptar()
        '//
        If Me.operacion = 1 Or Me.operacion = 2 Then
            'Volver a traer el registro 
            ent.DatoCondicion1 = ent.ClaveCuentaCorriente
            ent = ccte.buscarCuentaCorrienteExisPorClaveCC(ent)
        End If

        ent.PeriodoRegContabCabe = Me.TxtPeri.Text
        ent.CodigoEmpresa = Me.TxtCodEmp.Text
        ent.CodigoOrigen = Me.txtCodOri.Text
        ent.CodigoFile = Me.txtCodFil.Text
        ent.NumeroVoucherRegContabCabe = Me.txtNumVau.Text
        ent.CodigoAuxiliar = Me.txtCodAux.Text.Trim
        ent.TipoDocumento = Me.txtDoc.Text
        ent.SerieDocumento = Me.txtSer.Text
        ent.NumeroDocumento = Me.txtNum.Text
        ent.FechaDocumento = Me.dtpFecha.Value
        ent.VentaTipoCambio = CType(Me.txtTipCam.Text, Decimal)
        'moneda
        ent.MonedaDocumento = Rbt.radioActivo(Me.gbMoneda).Text.ToString.Trim()

        ent.ImporteOriginalCuentaCorriente = CType(Me.txtPv.Text, Decimal)
        ent.ImportePagadoCuentaCorriente = CType(Me.txtPagado.Text, Decimal)
        ent.SaldoCuentaCorriente = CType(Me.txtSaldo.Text, Decimal)

        '    ent.FechaVctoDocumento = Me.DtpFechaVcto.Text
        ent.FechaVctoDocumento = Varios.AñoMesDia(Me.DtpFechaVcto.Value.Date)

        ent.CodigoCuentaPcge = Me.TxtCuenta.Text
        'ent.FechaVctoDocumento = CType(Me.DtpFechaVcto.Value, Date)

        'defecto para compras
        If ent.SaldoCuentaCorriente = 0 Then
            ent.EstadoCuentaCorriente = "0"
        Else
            ent.EstadoCuentaCorriente = "1"
        End If

        Select Case Me.operacion

            Case 0        'Nuevo
                'Igv
                ent.IgvPar = parEn.IgvPar
                'numero voucher autogenerado
                Dim aut As New SuperEntidad
                aut.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
                aut.AnoVoucher = ent.PeriodoRegContabCabe.Substring(0, 4)
                aut.CodigoMes = ent.PeriodoRegContabCabe.Substring(4, 2)
                aut.CodigoFile = Me.txtCodFil.Text.Trim
                'ent.NumeroVoucherRegContabCabe = vou.obtenerVoucherAutogenerado(aut)
                ent.NumeroVoucherRegContabCabe = Me.txtNumVau.Text.Trim
                ccte.nuevoCuentaCorriente(ent)
                MsgBox("Registro Compra ingresado correctamente", MsgBoxStyle.Information)
                'Limpiar la grilla
                'Me.dgvctegCom.Rows.Clear()
                acc.LimpiarControles()
                'Me.ImportesSolesDolares()
                Txt.cursorAlUltimo(Me.txtCodFil)
            Case 1
                'modificar cabecera
                ccte.modificarCuentaCorriente(ent)
                'Eliminamos el detalle antiguo
                'grabamos el nuevo detalle
                MsgBox("Registro Cuenta Corriente modificado correctamente", MsgBoxStyle.Information)
                Me.Close()

            Case 2
                'eliminar cabecera
                If CType(Me.txtPagado.Text, Decimal) <> 0 Then
                    MsgBox("Registro Tiene Pagos, Extorne primero los pagos", MsgBoxStyle.Exclamation, "Cuenta Corriente")
                Else
                    ccte.eliminarCuentaCorrienteFis(ent)
                    MsgBox("Registro Cuenta Corriente Eliminado correctamente", MsgBoxStyle.Information, "Cuenta Corriente")
                End If
               
                Me.Close()

        End Select
        '/Actualizar y buscar el registro grabado
        Me.wCtaCte.ActualizarVentana()
        ent.ClaveCuentaCorriente = ent.CodigoEmpresa + ent.PeriodoRegContabCabe + ent.CodigoOrigen + ent.CodigoFile + ent.NumeroVoucherRegContabCabe
        Dgv.obtenerCursorActual(Me.wCtaCte.DgvCtaCte, ent.ClaveCuentaCorriente, Me.wCtaCte.lista)
        '\\
    End Sub

#End Region

#Region "Mostrar formulario lista"
    Private Sub txtCodFil_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodFil.KeyDown
        If Me.txtCodFil.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListaFiles
                '  win.tabla = "File"
                win.titulo = "Files"
                win.CondicionLista = "ListarFilesXOrigen"
                ' win.ent.DatoFiltro1 = "3"
                win.ent.CodigoFile = "3"
                win.txt1 = Me.txtCodFil
                win.txt2 = Me.txtNomFil
                win.ctrlFoco = Me.txtCodAux
                win.NuevaVentana()
            End If
        End If

    End Sub

    Private Sub txtCodAux_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodAux.KeyDown
        If Me.txtCodAux.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarAuxiliar
                win.wEditCtaCte = Me
                Me.AddOwnedForm(win)
                win.tabla = "Todos"
                win.titulo = "AUXILIARES"
                win.txt1 = Me.txtCodAux
                win.txt2 = Me.txtNomAux
                win.ctrlFoco = Me.txtDoc
                win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub txtCodDoc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDoc.KeyDown
        If Me.txtDoc.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarTabla
                win.tabla = "Documento"
                win.titulo = "Documentos"
                win.txt1 = Me.txtDoc
                win.txt2 = Me.txtNomDoc
                win.ctrlFoco = Me.txtSer
                win.NuevaVentana()
            End If
        End If


    End Sub

    Private Sub txtCuenta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCuenta.KeyDown
        If Me.TxtCuenta.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarPlanCuentaGe
                win.tabla = "CuentasAnaliticas"    ''va la condicion del case
                win.titulo = "Cuentas"
                win.txt1 = Me.TxtCuenta
                win.txt2 = Me.TxtNombreCuenta
                win.ctrlFoco = Me.btnAceptar
                win.NuevaVentana()
            End If
        End If
    End Sub

#End Region

#Region "Buscar por codigo"
    Private Sub txtCodFil_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodFil.Validating
        If Me.operacion = 0 Or Me.operacion = 4 Or Me.operacion = 5 Then
            If Me.txtCodFil.Text.Trim <> "" Then

                Dim codOri As String = Me.txtCodFil.Text.Trim.Substring(0, 1)
                If codOri = "3" Then
                    Dim ope As New OperaWin : ope.txt1 = Me.txtCodFil : ope.txt2 = Me.txtNomFil
                    ope.MostrarCodigoDescripcionDeFile("Files", e)
                Else
                    MsgBox("El Codigo File no existe", MsgBoxStyle.Information)
                    Me.txtCodFil.Text = ""
                    Me.txtNomFil.Text = ""
                    Me.txtCodFil.Focus()
                End If
            Else
                Me.txtCodFil.Text = ""
                Me.txtNomFil.Text = ""
            End If
        End If


        'If Me.operacion = 0 Then
        '    If Me.txtCodFil.Text.Trim <> "" Then
        '        Dim codOri As String = Me.txtCodFil.Text.Trim.Substring(0, 1)
        '        If codOri = "3" Then
        '            Dim ope As New OperaWin : ope.txt1 = Me.txtCodFil : ope.txt2 = Me.txtNomFil
        '            ope.MostrarCodigoDescripcionDeTabla("Fil", "File", e)
        '        Else
        '            MsgBox("El Codigo File no existe", MsgBoxStyle.Information)
        '            Me.txtCodFil.Text = String.Empty
        '            Me.txtNomFil.Text = String.Empty
        '            Me.txtCodFil.Focus()
        '        End If
        '    End If
        'End If

    End Sub

    Private Sub txtCodAux_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodAux.Validating
        If Me.operacion = 0 Or Me.operacion = 1 Or Me.operacion = 4 Then
            Dim ope As New OperaWin : ope.txt1 = Me.txtCodAux : ope.txt2 = Me.txtNomAux
            ope.MostrarCodigoDescripcionDeAuxiliar("Todos", "AUXILIARES", e)
        End If
    End Sub

    Private Sub txtDoc_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDoc.Validating
        If Me.operacion = 0 Then
            Dim ope As New OperaWin : ope.txt1 = Me.txtDoc : ope.txt2 = Me.txtNomDoc
            ope.MostrarCodigoDescripcionDeTabla("Doc", "Documento", e)
        End If

    End Sub

    Private Sub txtCuenta_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCuenta.Validating

        Dim ope As New OperaWin : ope.txt1 = Me.TxtCuenta : ope.txt2 = Me.TxtNombreCuenta
        ope.Condicion = "CuentasAnaliticas"
        ope.MostrarCodigoDescripcionDePlancuentas("CuentasAnaliticas", e)

    End Sub


#End Region


    Private Sub WEditarPptoInterno_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Me.Text = "Eliminar Cuenta Corriente" Then
            Me.Aceptar()
            Exit Sub
        End If

        If acc.CamposObligatorios = False Then
            Exit Sub
        Else
            Me.Aceptar()
            Me.Close()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If Me.Text = "Visualizar Cuenta Corriente" Then
            Me.Close()
        Else
            Me.Close()
        End If
    End Sub


    Private Sub txtSer_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSer.Validated

    End Sub

    Private Sub txtPv_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPv.TextChanged

    End Sub
End Class