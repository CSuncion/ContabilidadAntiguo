Imports Entidad
Imports Negocio
Imports Comun

Public Class WGenAsiDocPen

#Region "Propietarios"
    Public wRc As New WRegistroDiario
#End Region

    Public eLisDocPen As New List(Of SuperEntidad)
    Public eNumeroCorrelativo As String = ""
    Public rc As New RegContabCabeRN
    Public cam As New CamposEntidad
    Public acc As New Accion
    Public eRccEN As New SuperEntidad


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
        Me.Show()
    End Sub

    Sub PorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.txtNomEmp.Text = SuperEntidad.xRazonSocial
        Me.TxtPeri.Text = SuperEntidad.xPeriodoEmpresa
        Me.txtCodOri.Text = "3"
        Me.txtNomOri.Text = "Diario"
    End Sub

    Sub NuevaVentana()
        '//
        Me.InicializaVentana()
        Me.PorDefecto()
        acc.LimpiarControles()
        Me.ActualizarDgvDocPen()
        acc.Nuevo()
        '\\
    End Sub

    Sub Aceptar()

        'validar que la grilla no este vacia
        If Me.ValidaCuandoNoHayDocumentos = False Then Exit Sub

        'validar campos obligatorios
        If acc.CamposObligatorios = False Then Exit Sub

        'validar voucher disponible
        If Me.EsNumeroVoucherCorrecto = False Then Exit Sub

        'deseas realizar la operacion
        Dim rpta As Integer = MsgBox("Deseas Realizar La Operacion", MsgBoxStyle.YesNo)
        If rpta = MsgBoxResult.No Then Exit Sub

        'adicionar el regcontabcabe
        Me.AdicionarRegContabCabe()

        'adicionar los regcontabdetas
        Me.AdicionarRegContabDeta()

        'pagar los documentos en cuenta corriente
        Me.CancelarDocumentos()

        'mensaje satisfactorio
        MsgBox("Asiento creado correctamente, Numero Generado es: " + Me.eRccEN.NumeroVoucherRegContabCabe, MsgBoxStyle.Information)

        'actualizar al propietario
        Me.ActualizarPropietario()

        'actualizar la grilla de los documentos filtrados
        Me.ActualizarDgvDocPen()

        'poner foco
        Me.txtCodCueDoc.Focus()

    End Sub

    Sub ActualizarListaDocumentosPendientes()

        'asignar parametros
        Dim iCueCorEN As New SuperEntidad
        iCueCorEN.DatoCondicion1 = Fecha.ObtenerAnoMesDia(Me.dtpFecDocDes.Value)
        iCueCorEN.DatoCondicion2 = Fecha.ObtenerAnoMesDia(Me.dtpFecDocHas.Value)
        iCueCorEN.DatoCondicion3 = Me.txtMonMayDoc.Text
        iCueCorEN.DatoCondicion4 = Me.txtMonMenDoc.Text
        iCueCorEN.CodigoCuentaPcge = Me.txtCodCueDoc.Text
        iCueCorEN.CampoOrden = cam.FecDoc

        'ejecutar metodo
        Dim iCueCorRN As New CuentaCorrienteRN
        Me.eLisDocPen = iCueCorRN.ListarCuentasCorrientesParaAsientoDocumentosPendientes(iCueCorEN)
    End Sub

    Sub ActualizarDgvDocPen()

        'actualizar lista documentos pendientes
        Me.ActualizarListaDocumentosPendientes()

        'refrescar grilla
        Dgv.refrescarFuenteDatosGrilla(Me.DgvDocPen, Me.eLisDocPen)

        'Creando las columnas
        Dgv.asignarColumnaText(Me.DgvDocPen, cam.CodAux, "Ruc", 95)
        Dgv.asignarColumnaText(Me.DgvDocPen, cam.DesAux, "Auxiliar", 180)
        Dgv.asignarColumnaText(Me.DgvDocPen, cam.NomTipDoc, "Documento", 80)
        Dgv.asignarColumnaText(Me.DgvDocPen, cam.SerDoC, "Serie", 50)
        Dgv.asignarColumnaText(Me.DgvDocPen, cam.NumDoc, "Numero", 110)
        Dgv.asignarColumnaText(Me.DgvDocPen, cam.FecDoc, "Fecha", 80)
        Dgv.AsignarColumnaTextNumerico(Me.DgvDocPen, cam.SalCtaCte, "Saldo", 70, 2)
        Dgv.asignarColumnaText(Me.DgvDocPen, cam.CodCtaPcge, "Cuenta", 100)


    End Sub

    Function ValidaCuandoNoHayDocumentos() As Boolean
        If Me.DgvDocPen.Rows.Count = 0 Then
            MsgBox("No hay documentos para hacer el asiento", MsgBoxStyle.Exclamation)
            Me.btnEjeFil.Focus()
            Return False
        End If
        Return True
    End Function

    Function EsNumeroVoucherCorrecto() As Boolean

        'traer el numero correlativo
        Dim iVouRN As New VoucherRN
        Dim aut As New SuperEntidad
        aut.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        aut.AnoVoucher = Me.TxtPeri.Text.Trim.Substring(0, 4)
        aut.CodigoMes = Me.TxtPeri.Text.Trim.Substring(4, 2)
        aut.CodigoFile = Me.txtCodFil.Text.Trim
        Me.eNumeroCorrelativo = iVouRN.obtenerVoucherAutogenerado(aut)

        'validar si ya existe un registro contable con ese numero voucher
        Dim RccRN As New RegContabCabeRN
        Dim RccEN As New SuperEntidad
        RccEN.ClaveRegContabCabe += Me.TxtCodEmp.Text.Trim
        RccEN.ClaveRegContabCabe += Me.TxtPeri.Text.Trim
        RccEN.ClaveRegContabCabe += Me.txtCodOri.Text.Trim
        RccEN.ClaveRegContabCabe += Me.txtCodFil.Text.Trim
        RccEN.ClaveRegContabCabe += Me.eNumeroCorrelativo
        RccEN = RccRN.buscarRegContabExisPorClave(RccEN)
        If RccEN.ClaveRegContabCabe = "" Then
            Return True
        Else
            MsgBox("El correlativo " + Me.eNumeroCorrelativo + " Ya Existe", MsgBoxStyle.Information, "Compras")
            Return False
        End If

    End Function

    Sub AdicionarRegContabCabe()

        'asignar parametros
        Dim iRccEN As New SuperEntidad
        iRccEN.PeriodoRegContabCabe = Me.TxtPeri.Text
        iRccEN.CodigoEmpresa = Me.TxtCodEmp.Text
        iRccEN.CodigoOrigen = Me.txtCodOri.Text
        iRccEN.CodigoFile = Me.txtCodFil.Text
        iRccEN.NumeroVoucherRegContabCabe = Me.eNumeroCorrelativo
        iRccEN.DiaVoucherRegContabCabe = Me.txtDia.Text
        iRccEN.FechaVoucherRegContabCabe = CType(Me.txtFecVau.Text, Date)
        iRccEN.GlosaRegContabCabe = Me.txtGlosa.Text
        iRccEN.CodigoAuxiliar = ""
        iRccEN.TipoDocumento = ""
        iRccEN.SerieDocumento = ""
        iRccEN.NumeroDocumento = ""
        iRccEN.FechaDocumento = Today.Date
        iRccEN.VentaTipoCambio = 1
        iRccEN.VentaEurTipoCambio = 1
        iRccEN.CodigoModoPago = ""
        iRccEN.CodigoCuentaBanco = ""
        iRccEN.MonedaDocumento = "S/."
        iRccEN.IgvPar = 0
        iRccEN.PrecioVtaRegContabCabe = 0
        iRccEN.ExoneradoRegContabCabe = 0
        iRccEN.IgvRegContabCabe = 0
        iRccEN.ValorVtaRegContabCabe = 0
        iRccEN.DetraccionRegContabCabe = ""
        iRccEN.NumeroPapeletaRegContabCabe = ""
        iRccEN.FechaDetraccionRegContabCabe = ""
        iRccEN.RetencionRegContabCabe = ""
        iRccEN.EstadoRegContabCabe = ""
        iRccEN.CartaRegContabCabe = ""
        iRccEN.DescripcionRegContabCabe = ""
        iRccEN.VoucherIngresoRegContabCabe = ""
        iRccEN.SumaDebeRegContabCabe = CuentaCorrienteRN.ObtenerSaldoTotalEnSoles(Me.eLisDocPen)
        iRccEN.SumaHaberRegContabCabe = iRccEN.SumaDebeRegContabCabe
        iRccEN.UltimoCorrelativo = (Me.eLisDocPen.Count * 2).ToString.PadLeft(4, CType("0", Char))
        iRccEN.TipoDocumento1 = ""
        iRccEN.SerieDocumento1 = ""
        iRccEN.NumeroDocumento1 = ""
        iRccEN.MonedaDocumento1 = ""
        iRccEN.FechaDocumento1 = ""
        iRccEN.FechaVencimiento = Today.Date
        iRccEN.ModoCompra = ""
        iRccEN.EstadoRegistro = "0" 'normal

        'ejecutar metodo
        Dim iRccRN As New RegContabCabeRN
        iRccRN.nuevoRegContabCabe(iRccEN)

        'pasamos el objeto completo
        Me.eRccEN = iRccEN

    End Sub

    Sub AdicionarRegContabDeta()

        'asignar parametros
        Dim iRccEN As SuperEntidad = Me.eRccEN
        Dim iContraCuenta As String = Me.txtCodCueCon.Text
        Dim iDHContraCuenta As String = Rbt.radioActivo(Me.gbDebHabCon).Text
        Dim iLisDocPen As List(Of SuperEntidad) = Me.eLisDocPen

        'ejecutar metodo
        Dim iRcdRN As New RegContabDetaRN
        iRcdRN.AdicionarRegContabDetasParaAsientoDocumentosPendientes(iRccEN, iContraCuenta, iDHContraCuenta, iLisDocPen)

    End Sub

    Sub CancelarDocumentos()

        'asignar parametros
        Dim iLisDocPen As List(Of SuperEntidad) = Me.eLisDocPen

        'ejecutar metodo
        Dim iCueCorRN As New CuentaCorrienteRN
        iCueCorRN.CancelarDocumentos(iLisDocPen)

    End Sub

    Sub ActualizarPropietario()

        'actualizamos a la grilla del propietario
        Me.wRc.ActualizarVentana()

        'poner el foco en el nuevo registro
        Dgv.obtenerCursorActual(Me.wRc.DgvDia, Me.eRccEN.ClaveRegContabCabe, Me.wRc.lista)

    End Sub

#End Region

#Region "Mostrar formulario lista"

    Private Sub txtCodCueDoc_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodCueDoc.KeyDown
        If Me.txtCodCueDoc.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarPlanCuentaGe
                win.tabla = "CuentasAnaliticas"
                win.titulo = "Cuentas"
                win.txt1 = Me.txtCodCueDoc
                win.txt2 = Me.txtNomCueDoc
                win.ctrlFoco = Me.btnEjeFil
                win.NuevaVentana()
            End If
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub txtCodFil_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodFil.KeyDown
        If Me.txtCodFil.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListaFiles
                win.titulo = "Files"
                win.CondicionLista = "ListarFilesXOrigen"
                win.ent.CodigoFile = "3"
                win.txt1 = Me.txtCodFil
                win.txt2 = Me.txtNomFil
                win.ctrlFoco = Me.txtDia
                win.NuevaVentana()
            End If
        End If

    End Sub

    Private Sub txtCodCueCon_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodCueCon.KeyDown
        If Me.txtCodCueCon.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarPlanCuentaGe
                win.tabla = "CuentasAnaliticas"
                win.titulo = "Cuentas"
                win.txt1 = Me.txtCodCueCon
                win.txt2 = Me.txtNomCueCon
                win.ctrlFoco = Me.gbDebHabCon
                win.NuevaVentana()
            End If
            If e.KeyCode = Keys.Escape Then
                Me.Close()
            End If
        End If
    End Sub

#End Region

#Region "Buscar por codigo"

    Private Sub txtCodCueDoc_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodCueDoc.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.txtCodCueDoc : ope.txt2 = Me.txtNomCueDoc
        ope.Condicion = "CuentasAnaliticas"
        ope.MostrarCodigoDescripcionDePlancuentas("CuentasAnaliticas", e)
    End Sub

    Private Sub txtCodFil_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodFil.Validating
        If Me.txtCodFil.Text.Trim <> "" Then
            Dim codOri As String = Me.txtCodFil.Text.Trim.Substring(0, 1)
            If codOri = "3" Then
                Dim ope As New OperaWin : ope.txt1 = Me.txtCodFil : ope.txt2 = Me.txtNomFil
                ope.MostrarCodigoDescripcionDeFile("Files", e)
            Else
                MsgBox("El Codigo File no existe", MsgBoxStyle.Information)
                Me.txtCodFil.Text = String.Empty
                Me.txtNomFil.Text = String.Empty
                Me.txtCodFil.Focus()
            End If
        End If
    End Sub

    Private Sub txtCodCueCon_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodCueCon.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.txtCodCueCon : ope.txt2 = Me.txtNomCueCon
        ope.Condicion = "CuentasAnaliticas"
        ope.MostrarCodigoDescripcionDePlancuentas("CuentasAnaliticas", e)
    End Sub

#End Region

#Region "Calculos"

    Private Sub txtDia_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDia.Validated
        If Me.TxtPeri.Text <> "" Then
            If Me.txtDia.Text.Trim <> "" Then
                'Dim wmes As String
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

#End Region

    Private Sub WGenAsiDocPen_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.Aceptar()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnEjeFil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEjeFil.Click
        Me.ActualizarDgvDocPen()
    End Sub

   


   
  
End Class