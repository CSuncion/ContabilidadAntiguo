Imports Entidad
Imports Negocio

Public Class WEditarRegistroVentaEspecial


#Region "Propietarios"
    Public wRv As New WRegistroVentaEspecial
#End Region

    Public ent, entD, parEn, ticEn As New SuperEntidad
    Public lista, listaD As New List(Of SuperEntidad)
    Public rv As New RegistroEspecialRN
    Public ccte As New CuentaCorrienteRN
    Public par As New ParametroRN
    Public tic As New TipoCambioRN
    Public cam As New CamposEntidad
    Public tab As New TablaRN
    Public vou As New VoucherRN
    Public emp As New EmpresaRN
    Public acc As New Accion
    Public PeriodoActual As String
    Public operacion As Integer  '0=agregar , 1=modificar , 2=eliminar , 3=visualizar , 4=Manual , 5=Anula '

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
        'traer objeto parametro
        parEn = par.buscarParametroExis(parEn)
        Me.Show()
    End Sub

    Sub PorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.txtNomEmp.Text = SuperEntidad.xRazonSocial
        ''Instanciar Empresa Actual 
        'Dim obe As New SuperEntidad
        'obe.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        'obe = emp.buscarEmpresaExisPorCodigo(obe)
        Me.TxtPeri.Text = SuperEntidad.xPeriodoEmpresa
        PeriodoActual = SuperEntidad.xPeriodoEmpresa

        Me.TxtPorIgv.Text = parEn.IgvPar.ToString
        Me.txtCodOri.Text = "5"
        Me.txtNomOri.Text = "Ventas"
        Me.txtCodFil.Text = "550"
        Me.txtNomFil.Text = "Ventas Especiales"

        Me.TraerTipoCambio()
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
        Me.Text = "Agregar Registro Venta"
        'poner valores defecto en montos
        acc.LimpiarControles()
        'por defecto
        Me.PorDefecto()
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtDia)
        'los controles que deben estar activos
        acc.Nuevo()
        Me.HabilitarControlSegunTipoDoc03()
        '\\
    End Sub

    Sub ventanaAdicionarManual()
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Agregar Manual Registro Venta"
        'poner valores defecto en montos
        acc.LimpiarControles()
        'por defecto
        Me.PorDefecto()
        'en blanco
        Me.TxtPeri.Text = String.Empty
        'los controles que deben estar activos
        acc.Nuevo()
        Me.TxtPeri.ReadOnly = False
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.TxtPeri)
        Me.HabilitarControlSegunTipoDoc03()
        '\\
    End Sub

    Sub ventanaModificar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Modificar Registro Venta"
        'mostrar el registro en pantalla
        Me.obtenerRegVentaEnPantalla(codigo)
        'mostrar el detalle del registro en pantalla
        Me.obtenerRegVentaDetalleEnPantalla(codigo)
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtDia)
        'los controles que deben estar activos
        acc.Modificar()
        If Me.txtDoc.Text.Trim = "03" Then
            Me.txtEx.ReadOnly = True
        Else
            Me.txtEx.ReadOnly = False
        End If
        Me.HabilitarControlesSegunDetraccion()
        Me.HabilitarControlesSegunFile507()
        Me.HabilitarControlSegunTipoDoc03()
        '\\
    End Sub

    Sub ventanaEliminar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Eliminar Registro Venta"
        'mostrar el registro en pantalla
        Me.obtenerRegVentaEnPantalla(codigo)
        'mostrar el detalle del registro en pantalla
        Me.obtenerRegVentaDetalleEnPantalla(codigo)
        Me.btnAceptar.Text = "Eliminar"
        Me.btnAceptar.Focus()
        'los controles que deben estar activos
        acc.Eliminar()
        Me.HabilitarControlesSegunDetraccion()
        Me.HabilitarControlesSegunFile507()
        Me.HabilitarControlSegunTipoDoc03()
        '\\
    End Sub

    Sub ventanaVisualizar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Visualizar Registro Venta"
        'mostrar el registro en pantalla
        Me.obtenerRegVentaEnPantalla(codigo)
        'mostrar el detalle del registro en pantalla
        Me.obtenerRegVentaDetalleEnPantalla(codigo)
        'los controles que deben estar activos
        acc.Visualizar()
        Me.HabilitarControlesSegunDetraccion()
        Me.HabilitarControlesSegunFile507()
        Me.HabilitarControlSegunTipoDoc03()
        '\\
    End Sub

    Sub ventanaAnular(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Anula Registro Venta"
        'mostrar el registro en pantalla
        Me.obtenerRegVentaEnPantalla(codigo)
        'mostrar el detalle del registro en pantalla
        Me.obtenerRegVentaDetalleEnPantalla(codigo)
        Me.btnAceptar.Text = "Anular"
        Me.btnAceptar.Focus()
        'los controles que deben estar activos
        acc.Eliminar()
        Me.HabilitarControlesSegunDetraccion()
        Me.HabilitarControlesSegunFile507()
        Me.HabilitarControlSegunTipoDoc03()
        '\\
    End Sub

    Sub obtenerRegVentaEnPantalla(ByRef codigo As String)
        '//
        ent.ClaveRegContabCabe = codigo
        ent = rv.buscarRegContabExisPorClave(ent)
        'preguntar si ent tiene el registro
        If ent.ClaveRegContabCabe = "" Then
            Exit Sub
        Else
            '/Pasar Datos a los controles
            Me.TxtCodEmp.Text = ent.CodigoEmpresa
            Me.txtNomEmp.Text = ent.RazonSocialEmpresa
            Me.TxtPeri.Text = ent.PeriodoRegContabCabe
            Me.txtCodOri.Text = ent.CodigoOrigen
            Me.txtNomOri.Text = ent.NombreOrigen
            Me.txtCodFil.Text = ent.CodigoFile
            Me.txtNomFil.Text = ent.NombreFile
            Me.TxtPorIgv.Text = Varios.numeroConDosDecimal(ent.IgvPar.ToString)
            Me.txtNumVau.Text = ent.NumeroVoucherRegContabCabe
            Me.txtDia.Text = ent.DiaVoucherRegContabCabe
            Me.txtFecVau.Text = ent.FechaVoucherRegContabCabe.Date.ToShortDateString
            Me.txtCodAux.Text = ent.CodigoAuxiliar
            Me.txtNomAux.Text = ent.DescripcionAuxiliar
            Me.txtDoc.Text = ent.TipoDocumento
            Me.txtNomDoc.Text = ent.NombreDocumento
            Me.txtSer.Text = ent.SerieDocumento
            Me.txtNum.Text = ent.NumeroDocumento
            Me.TxtNum1.Text = ent.NumeroDocumento1
            Me.dtpFecha.Value = ent.FechaDocumento
            Me.txtTipCam.Text = ent.VentaTipoCambio.ToString
            Gb.pasarDato(Me.gbMoneda, ent.MonedaDocumento)
            Me.txtPv.Text = Varios.numeroConDosDecimal(ent.PrecioVtaRegContabCabe.ToString)
            Me.txtEx.Text = Varios.numeroConDosDecimal(ent.ExoneradoRegContabCabe.ToString)
            Me.txtIgv.Text = Varios.numeroConDosDecimal(ent.IgvRegContabCabe.ToString)
            Me.txtVv.Text = Varios.numeroConDosDecimal(ent.ValorVtaRegContabCabe.ToString)
            Me.txtGlosa.Text = ent.GlosaRegContabCabe
            Me.TxtCuenta.Text = ent.CodigoCuentaBanco
            Me.TxtNombreCuenta.Text = ent.NombreCuentaPcge
            Gb.pasarDato(Me.gbCancelada, ent.EstadoRegContabCabe)
        End If
        '\\
    End Sub

    Sub obtenerRegVentaDetalleEnPantalla(ByRef codigo As String)
    End Sub

    Sub GrabarDetalleRegContab()
    End Sub

    Sub Aceptar()
        '//
        If Me.operacion = 1 Or Me.operacion = 2 Then
            'Volver a traer el registro 
            ent.DatoCondicion1 = ent.ClaveRegContabCabe
            ent = rv.buscarRegContabExisPorClave(ent)
        End If
        ent.CodigoEmpresa = Me.TxtCodEmp.Text
        ent.PeriodoRegContabCabe = Me.TxtPeri.Text
        ent.CodigoOrigen = Me.txtCodOri.Text
        ent.CodigoFile = Me.txtCodFil.Text

        ent.NumeroVoucherRegContabCabe = Me.txtNumVau.Text
        ent.DiaVoucherRegContabCabe = Me.txtDia.Text
        ent.FechaVoucherRegContabCabe = CType(Me.txtFecVau.Text, Date)
        ent.CodigoAuxiliar = Me.txtCodAux.Text.Trim
        ent.TipoDocumento = Me.txtDoc.Text
        ent.SerieDocumento = Me.txtSer.Text
        ent.NumeroDocumento = Me.txtNum.Text
        ent.FechaDocumento = Me.dtpFecha.Value
        ent.VentaTipoCambio = CType(Me.txtTipCam.Text, Decimal)
        'moneda
        ent.MonedaDocumento = Rbt.radioActivo(Me.gbMoneda).Text.ToString.Trim()
        ent.PrecioVtaRegContabCabe = CType(Me.txtPv.Text, Decimal)
        ent.ExoneradoRegContabCabe = CType(Me.txtEx.Text, Decimal)
        ent.IgvRegContabCabe = CType(Me.txtIgv.Text, Decimal)
        ent.ValorVtaRegContabCabe = CType(Me.txtVv.Text, Decimal)
        ent.GlosaRegContabCabe = Me.txtGlosa.Text
        ent.DetraccionRegContabCabe = ""
        ent.NumeroPapeletaRegContabCabe = ""
        'validar fecha detraccion
        ent.FechaDetraccionRegContabCabe = ""

        ent.SumaDebeRegContabCabe = 0
        ent.SumaHaberRegContabCabe = 0
        ent.UltimoCorrelativo = ""


        ent.EstadoRegContabCabe = Rbt.radioActivo(Me.gbCancelada).Text.ToString.Trim() '' Si es cancelada

        'Segun file 407 

        ent.TipoDocumento1 = Me.txtDoc.Text.Trim
        ent.SerieDocumento1 = Me.txtSer.Text.Trim
        ent.NumeroDocumento1 = Me.TxtNum1.Text.Trim
        ent.MonedaDocumento1 = ""
        ent.CodigoCuentaBanco = Me.TxtCuenta.Text.Trim
        ent.FechaDocumento1 = ""


        ent.FechaVencimiento = Today()

        'defecto para Ventas
        ent.ImporteRegContabCabe = 0   ''Inicio al grabar varia con otro proceso sino se graba en negocio
        'ent.EstadoRegContabCabe = "1"
        ent.CodigoIngEgr = ""
        ent.RetencionRegContabCabe = ""
        'ent.CodigoCuentaBanco = ""
        ent.CodigoModoPago = ""
        ent.VoucherIngresoRegContabCabe = ""
        ent.DescripcionRegContabCabe = ""
        ent.CartaRegContabCabe = ""


        '/Se graba o0 se modifica?
        Select Case Me.operacion

            Case 0
                'Igv
                ent.IgvPar = parEn.IgvPar

                'numero voucher autogenerado por meses
                Dim aut As New SuperEntidad
                aut.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
                aut.AnoVoucher = ent.PeriodoRegContabCabe.Substring(0, 4)
                aut.CodigoMes = ent.PeriodoRegContabCabe.Substring(4, 2)
                aut.CodigoFile = Me.txtCodFil.Text.Trim
                ent.NumeroVoucherRegContabCabe = vou.obtenerVoucherAutogenerado(aut)

                rv.nuevoRegistroEspecial(ent)

                If ent.EstadoRegContabCabe = "2" Then
                    Me.GrabarCuentaCorriente()
                End If

                MsgBox("Registro Venta ingresado correctamente" + Chr(13) + "Numero de Voucher Generado:" + ent.NumeroVoucherRegContabCabe, MsgBoxStyle.Information)
                'Limpiar la grilla
                'Me.dgvRegVta.Rows.Clear()
                acc.LimpiarControles()
                Txt.cursorAlUltimo(Me.txtDia)
            Case 4
                'Igv
                ent.IgvPar = parEn.IgvPar
                'numero voucher autogenerado
                Dim aut As New SuperEntidad
                aut.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
                aut.PeriodoRegContabCabe = Me.TxtPeri.Text.Trim
                aut.AnoVoucher = aut.PeriodoRegContabCabe.Substring(0, 4)
                aut.CodigoMes = aut.PeriodoRegContabCabe.Substring(4, 2)
                aut.CodigoFile = Me.txtCodFil.Text.Trim
                ent.NumeroVoucherRegContabCabe = vou.obtenerVoucherAutogenerado(aut)

                rv.nuevoRegistroEspecial(ent)

                MsgBox("Registro Venta ingresado correctamente", MsgBoxStyle.Information)
                'Limpiar la grilla
                'Me.dgvRegVta.Rows.Clear()
                acc.LimpiarControles()
                'Me.ImportesSolesDolares()
                Txt.cursorAlUltimo(Me.txtCodFil)

            Case 1
                'modificar cabecera
                rv.modificarRegistroEspecial(ent)

                MsgBox("Registro Venta modificado correctamente", MsgBoxStyle.Information)
                Me.Close()

            Case 2
                'eliminar cabecera
                rv.eliminarRegistroEspecialFis(ent)
                'Eliminamos el detalle antiguo

                MsgBox("Registro Venta Eliminado correctamente", MsgBoxStyle.Information)
                Me.Close()
            Case 5
                'eliminar cabecera
                rv.modificarRegistroEspecial(ent)

                MsgBox("Registro Venta Anulado correctamente", MsgBoxStyle.Information)
                Me.Close()

        End Select
        '/Actualizar y buscar el registro grabado
        Me.wRv.ActualizarVentana()
        ent.ClaveRegContabCabe = ent.CodigoEmpresa + ent.PeriodoRegContabCabe + ent.CodigoOrigen + ent.CodigoFile + ent.NumeroVoucherRegContabCabe
        Dgv.obtenerCursorActual(Me.wRv.DgvRVtaEsp, ent.ClaveRegContabCabe, Me.wRv.lista)
        '\\
    End Sub

    Sub GrabarCuentaCorriente()
        ent.PeriodoRegContabCabe = Me.TxtPeri.Text
        ent.CodigoEmpresa = Me.TxtCodEmp.Text
        ent.CodigoOrigen = Me.txtCodOri.Text
        ent.CodigoFile = Me.txtCodFil.Text
        'ent.NumeroVoucherRegContabCabe = Me.txtNumVau.Text
        ent.CodigoAuxiliar = Me.txtCodAux.Text.Trim
        ent.TipoDocumento = Me.txtDoc.Text
        ent.SerieDocumento = Me.txtSer.Text.Trim.PadLeft(4, CType("0", Char))
        ent.NumeroDocumento = Me.txtNum.Text
        ent.FechaDocumento = Me.dtpFecha.Value
        ent.VentaTipoCambio = CType(Me.txtTipCam.Text, Decimal)
        ent.CodigoCuentaPcge = Me.TxtCuenta.Text.Trim
        ent.FechaVctoDocumento = ""
        'moneda
        ent.MonedaDocumento = Rbt.radioActivo(Me.gbMoneda).Text.ToString.Trim()

        ent.ImporteOriginalCuentaCorriente = CType(Me.txtPv.Text, Decimal)
        ent.ImportePagadoCuentaCorriente = 0
        ent.SaldoCuentaCorriente = CType(Me.txtPv.Text, Decimal)
        ent.EstadoCuentaCorriente = "1" 'Pendiente de pago 
        ccte.nuevoCuentaCorriente(ent)

    End Sub

    Function EsDocumentoRegistrado() As Boolean
        Dim obj As New SuperEntidad
        obj.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        obj.CodigoAuxiliar = Me.txtCodAux.Text.Trim
        obj.TipoDocumento = Me.txtDoc.Text.Trim
        obj.SerieDocumento = Me.txtSer.Text.Trim
        obj.NumeroDocumento = Me.txtNum.Text.Trim
        If ccte.EsDocumentoRegistrado(obj) = True Then
            MsgBox("Documento ya esta Registrado", MsgBoxStyle.Exclamation, "Documentos")
            Me.txtNum.Focus()
            Return True
        Else
            Return False
        End If

    End Function

    Function EsDocumentoRegistradoEnOtroRegistroC() As Boolean

        Dim obj As New SuperEntidad
        obj.ClaveCuentaCorriente = ent.ClaveRegContabCabe
        obj.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        obj.CodigoAuxiliar = Me.txtCodAux.Text.Trim
        obj.TipoDocumento = Me.txtDoc.Text.Trim
        obj.SerieDocumento = Me.txtSer.Text.Trim
        obj.NumeroDocumento = Me.txtNum.Text.Trim
        If ccte.EsDocumentoRegistradoEnOtroRegistroC(obj) = True Then
            MsgBox("Documento ya esta registrado en otro registro contable", MsgBoxStyle.Exclamation, "Documentos")
            Me.txtNum.Focus()
            Return True
        Else
            Return False
        End If

    End Function


    Function EsDocumentoPagado() As Boolean

        Dim obj As New SuperEntidad
        obj.ClaveCuentaCorriente = ent.ClaveRegContabCabe
        obj = ccte.buscarCuentaCorrienteExisPorClaveCC(obj)

        If obj.ImportePagadoCuentaCorriente <> 0 Then
            MsgBox("Documento ya tiene pagos no puede modificar", MsgBoxStyle.Exclamation, "Honorarios")
            Return True
        Else
            Return False
        End If

    End Function

    Sub eliminarCuentaCorriente()
        Dim obj As New SuperEntidad
        obj.ClaveCuentaCorriente = ent.ClaveRegContabCabe
        ccte.eliminarCuentaCorrienteFis(obj)
    End Sub

    Sub EsDocumentoAnulado()
        Dim pv As Decimal = CType(Me.txtPv.Text, Decimal)
        If Me.operacion = 0 Then
            If pv = 0 Then
                Dim rpta As Integer = MsgBox("Deseas Grabar Un Documento Anulado ?", MsgBoxStyle.YesNo, "Ventas")
                If rpta = MsgBoxResult.Yes Then
                    'Me.dgvRegVta.Rows.Clear()
                    Me.txtEx.Text = "0.00"
                    Me.txtVv.Text = "0.00"
                    Me.txtIgv.Text = "0.00"
                    Me.Aceptar()
                Else
                    Exit Sub
                End If
            Else
                Me.Aceptar()
            End If
        Else
            If Me.operacion = 1 Then
                If pv = 0 Then
                    MsgBox("Precio Venta no puede ser Cero ( 0 ) en Modificar", MsgBoxStyle.Exclamation, "Ventas")
                    Exit Sub
                Else
                    Me.Aceptar()
                End If
            Else
                'Me.dgvRegVta.Rows.Clear()
                Me.txtPv.Text = "0.00"
                Me.txtEx.Text = "0.00"
                Me.txtVv.Text = "0.00"
                Me.txtIgv.Text = "0.00"
                Me.Aceptar()
            End If

        End If
    End Sub

#End Region


    Private Sub WEditarPptoInterno_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        If Me.Text = "Eliminar Registro Venta" Then
            Me.Aceptar()
            Exit Sub
        End If
        If acc.CamposObligatorios = False Then
            Exit Sub
        Else
            Me.EsDocumentoAnulado()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If Me.Text = "Visualizar Registro Venta" Then
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

    Private Sub dtpFecha_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpFecha.Validating
        Me.TraerTipoCambio()

    End Sub

#Region "Mostrar formulario lista"
    Private Sub txtCodFil_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodFil.KeyDown
        If Me.txtCodFil.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarTabla
                win.tabla = "File"
                win.titulo = "Files"
                win.ent.DatoFiltro1 = "5"
                win.txt1 = Me.txtCodFil
                win.txt2 = Me.txtNomFil
                win.ctrlFoco = Me.txtDia
                win.NuevaVentana()
            End If
        End If

    End Sub

    Private Sub txtCodAux_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodAux.KeyDown
        If Me.txtCodAux.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarAuxiliar
                win.tabla = "Cliente/ClienteProveedor"
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
                win.tabla = "CuentasAnaliticas70"    ''va la condicion del case
                win.titulo = "Cuentas"
                win.txt1 = Me.TxtCuenta
                win.txt2 = Me.TxtNombreCuenta
                win.ctrlFoco = Me.gbCancelada
                win.NuevaVentana()
            End If
        End If
    End Sub

#End Region

#Region "Buscar por codigo"
    Private Sub txtCodFil_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodFil.Validating
        If Me.Text = "Agregar Registro Venta" Or Me.Text = "Agregar Manual Registro Venta" Then
            If Me.txtCodFil.Text.Trim <> "" Then
                Dim codOri As String = Me.txtCodFil.Text.Trim.Substring(0, 1)
                If codOri = "5" Then
                    Dim ope As New OperaWin : ope.txt1 = Me.txtCodFil : ope.txt2 = Me.txtNomFil
                    ope.MostrarCodigoDescripcionDeTabla("Fil", "File", e)
                    Me.HabilitarControlesSegunFile507()
                Else
                    MsgBox("El Codigo File no existe", MsgBoxStyle.Information)
                    Me.txtCodFil.Text = String.Empty
                    Me.txtNomFil.Text = String.Empty
                    Me.txtCodFil.Focus()
                End If
            End If
        End If

    End Sub

    Private Sub txtCodAux_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodAux.Validating
        If Me.Text = "Agregar Registro Venta" Or Me.Text = "Modificar Registro Venta" Or Me.Text = "Agregar Manual Registro Venta" Then
            Dim ope As New OperaWin : ope.txt1 = Me.txtCodAux : ope.txt2 = Me.txtNomAux
            ope.MostrarCodigoDescripcionDeAuxiliar("Cliente/ClienteProveedor", "AUXILIARES", e)
        End If
    End Sub

    Private Sub txtDoc_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDoc.Validating
        If Me.Text = "Agregar Registro Venta" Or Me.Text = "Modificar Registro Venta" Or Me.Text = "Agregar Manual Registro Venta" Then
            Dim ope As New OperaWin : ope.txt1 = Me.txtDoc : ope.txt2 = Me.txtNomDoc
            ope.MostrarCodigoDescripcionDeTabla("Doc", "Documento", e)
            Me.HabilitarControlSegunTipoDoc03()
        End If

    End Sub

    Private Sub txtCuenta_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCuenta.Validating

        Dim ope As New OperaWin : ope.txt1 = Me.TxtCuenta : ope.txt2 = Me.TxtNombreCuenta
        ope.Condicion = "CuentasAnaliticas70"
        ope.MostrarCodigoDescripcionDePlancuentas("CuentasAnaliticas70", e)

    End Sub

#End Region

#Region "Calculos"


    Private Sub txtDia_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDia.Validated
        If Me.TxtPeri.Text <> "" Then
            If Me.txtDia.Text.Trim <> "" Then
                Dim periodo As String = Me.TxtPeri.Text.Trim
                Dim dia As String = Me.txtDia.Text.Trim
                If Varios.LimiteMinMaxDeValores(dia, 1, 31) = True Then
                    dia = Varios.FormatoDia(dia)
                    Me.txtDia.Text = dia
                    Me.txtFecVau.Text = dia + "/" + periodo.Substring(4, 2) + "/" + periodo.Substring(0, 4)

                    '' Es Fecha Valida
                    If Varios.ValidaDia(Me.txtFecVau.Text) = False Then
                        Me.txtFecVau.Text = String.Empty
                        Me.txtDia.Focus()
                    End If
                Else
                    MsgBox("El dia debe estar entre en 1 y 31", MsgBoxStyle.Information)
                    Me.txtDia.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub txtDoc_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDoc.Validated

        'If Me.txtDoc.Text.Trim = "03" Then
        '    Me.txtEx.ReadOnly = True
        '    Me.txtEx.Text = Me.txtPv.Text.Trim
        'Else
        '    Me.txtEx.ReadOnly = False
        '    Me.txtEx.Text = "0.00"
        'End If

        Dim vIgv As Decimal = 0
        If Me.Text = "Agregar Registro Venta" Or Me.Text = "Agregar Manual Registro Venta" Then
            vIgv = parEn.IgvPar
        Else
            vIgv = ent.IgvPar
        End If
        Me.txtIgv.Text = Varios.CalcularIgvCompras(Me.txtPv.Text, Me.txtEx.Text, vIgv)
        Me.txtVv.Text = Varios.CalcularValorVentaCompra(Me.txtPv.Text, Me.txtEx.Text, Me.txtIgv.Text)
        'calculo distribuir
        'Me.txtDistr.Text = Varios.numeroConDosDecimal((CType(Me.txtVv.Text.Trim, Decimal) + CType(Me.txtEx.Text.Trim, Decimal)).ToString)
    End Sub

    Private Sub txtPv_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPv.Validated

        'If Me.txtDoc.Text.Trim = "03" Then
        '    Me.txtEx.Text = Me.txtPv.Text.Trim
        'End If
        Dim vIgv As Decimal = 0
        If Me.Text = "Agregar Registro Venta" Or Me.Text = "Agregar Manual Registro Venta" Then
            vIgv = parEn.IgvPar
        Else
            vIgv = ent.IgvPar
        End If
        Me.txtIgv.Text = Varios.CalcularIgvCompras(Me.txtPv.Text, Me.txtEx.Text, vIgv)
        Me.txtVv.Text = Varios.CalcularValorVentaCompra(Me.txtPv.Text, Me.txtEx.Text, Me.txtIgv.Text)
        'calculo distribuir
        'Me.txtDistr.Text = Varios.numeroConDosDecimal((CType(Me.txtVv.Text.Trim, Decimal) + CType(Me.txtEx.Text.Trim, Decimal)).ToString)

    End Sub


    Private Sub txtEx_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEx.Validated
        Dim vIgv As Decimal = 0
        If Me.Text = "Agregar Registro Venta" Or Me.Text = "Agregar Manual Registro Venta" Then
            vIgv = parEn.IgvPar
        Else
            vIgv = ent.IgvPar
        End If
        Me.txtIgv.Text = Varios.CalcularIgvCompras(Me.txtPv.Text, Me.txtEx.Text, vIgv)
        Me.txtVv.Text = Varios.CalcularValorVentaCompra(Me.txtPv.Text, Me.txtEx.Text, Me.txtIgv.Text)
        'calculo distribuir
        'Me.txtDistr.Text = Varios.numeroConDosDecimal((CType(Me.txtVv.Text.Trim, Decimal) + CType(Me.txtEx.Text.Trim, Decimal)).ToString)

    End Sub

    Sub HabilitarControlesSegunDetraccion()
        '    '/
        '    Dim detra As String = Rbt.radioActivo(Me.gbMovi).Text
        '    'Habilitar los campos calculados segun la detraccion
        '    Select Case detra
        '        Case "Si"
        '            Me.txtNumPape.Enabled = True
        '            Me.dtpFecDetra.Enabled = True
        '        Case "No"
        '            Me.txtNumPape.Enabled = False
        '            Me.dtpFecDetra.Enabled = False
        '    End Select
        '    '/
    End Sub

#End Region


    Private Sub txtPeri_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPeri.Validated
        If Me.operacion = 4 Then
            Dim p As String = Me.TxtPeri.Text.Trim
            If p <> "" Then
                If p.Length <> 6 Then
                    MsgBox("No es un periodo valido", MsgBoxStyle.Information, "")
                    Me.TxtPeri.Text = ""
                    Me.TxtPeri.Focus()
                Else
                    If p >= PeriodoActual Then
                        MsgBox("Solo se puede digitar como maximo el periodo anterior de hoy", MsgBoxStyle.Information, "")
                        Me.TxtPeri.Text = ""
                        Me.TxtPeri.Focus()
                    Else
                        'Me.txtDia.Focus()
                        Dim dia As String = Me.txtDia.Text.Trim
                        If dia <> String.Empty Then
                            dia = Varios.FormatoDia(dia)
                            Me.txtFecVau.Text = dia + "/" + Me.txtNomEmp.Text.Substring(4, 2) + "/" + Me.txtNomEmp.Text.Substring(0, 4)
                            '' Es Fecha Valida
                            If Varios.ValidaDia(Me.txtFecVau.Text) = False Then
                                Me.txtFecVau.Text = String.Empty
                                Me.TxtPeri.Focus()
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub CambiarDetraccion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.Text = "Agregar Registro Venta" Or Me.Text = "Modificar Registro Venta" Or Me.Text = "Agregar Manual Registro Venta" Then
            Me.HabilitarControlesSegunDetraccion()
        End If
    End Sub

    Sub HabilitarControlesSegunFile507()
        '/
        Dim cf As String = Me.txtCodFil.Text.Trim
        'Habilitar los campos segun radiobutton 
        If cf = "507" Then
            'Me.TxtDoc1.Enabled = True
            'Me.TxtSer1.Enabled = True
            'Me.TxtNum1.Enabled = True
            'Me.DtpFecha1.Enabled = True

        Else
            'Me.TxtDoc1.Enabled = False
            'Me.TxtSer1.Enabled = False
            'Me.TxtNum1.Enabled = False
            'Me.TxtDoc1.Text = ""
            'Me.TxtNomDoc1.Text = ""
            'Me.TxtSer1.Text = ""
            'Me.TxtNum1.Text = ""
            'Me.DtpFecha1.Enabled = False
        End If
        '/
    End Sub

    Sub HabilitarControlSegunTipoDoc03()
        '/
        Dim td As String = Me.txtDoc.Text.Trim
        'Habilitar campo segun tipo documento 
        If td = "03" Then
            Me.TxtNum1.Enabled = True
        Else
            Me.TxtNum1.Enabled = False
            Me.TxtNum1.Text = ""
        End If
        '/
    End Sub


    Private Sub txtser_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSer.Validated, txtCodAux.Validated, txtDoc.Validated, txtNum.Validated
        If Me.operacion = 0 Then
            If Me.EsDocumentoRegistrado() = True Then Exit Sub
        Else
            If Me.EsDocumentoRegistradoEnOtroRegistroC() = True Then Exit Sub
        End If

    End Sub
End Class