Imports Entidad
Imports Negocio

Public Class WEditarRegistroCajaBanco

#Region "Propietarios"
    Public wRcb As New WRegistroCajaBanco
#End Region

    Public ent, entD, parEn, ticEn As New SuperEntidad
    Public lista, listaD As New List(Of SuperEntidad)
    Public rcb As New RegContabCabeRN
    Public rcbd As New RegContabDetaRN
    Public ccte As New CuentaCorrienteRN
    Public par As New ParametroRN
    Public tic As New TipoCambioRN
    Public cam As New CamposEntidad
    Public tab As New TablaRN
    Public vou As New VoucherRN
    Public emp As New EmpresaRN
    Public acc As New Accion
    Public PeriodoActual As String
    Public operacion As Integer  '0=agregar , 1=modificar , 2=eliminar , 3=visualizar , 4=Manual'
    Public AplicaDiferenciaCambio As Boolean = False
    Public UltimoCorrelativo As Integer = 0
    Public EsCuadrado As Boolean = False

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
        Me.txtPeri.Text = SuperEntidad.xPeriodoEmpresa
        PeriodoActual = SuperEntidad.xPeriodoEmpresa

    End Sub

    Sub TraerTipoCambio()
        'traer tipo de cambio
        Dim fecvau As DateTime = CType(Me.txtFecVau.Text, DateTime)  ''Pantalla es como varcher y cambia datetime
        ticEn.DatoCondicion1 = fecvau.Year.ToString + "/" + fecvau.Month.ToString + "/" + fecvau.Day.ToString
        ticEn = tic.buscarTipoCambioExisPorFecha(ticEn)
        If ticEn.AnoTipoCambio = "" Then
            MsgBox("El tipo de cambio no existe", MsgBoxStyle.Information)
            Me.txtTipCam.Text = "1.000"
            Me.txtTipCam1.Text = "1.000"
        Else
            Me.txtTipCam.Text = ticEn.VentaTipoCambio.ToString
            Me.txtTipCam1.Text = ticEn.VentaEurTipoCambio.ToString
        End If
    End Sub

    Sub ventanaAdicionar()
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Agregar Registro CajaBanco"
        'poner valores defecto en montos
        acc.LimpiarControles()
        'por defecto
        Me.PorDefecto()
        Me.ImportesDebeHaber()
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtCodOri)
        'los controles que deben estar activos
        acc.Nuevo()
        '\\
    End Sub

    Sub ventanaAdicionarManual()
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Agregar Manual Registro CajaBanco"
        'poner valores defecto en montos
        acc.LimpiarControles()
        'por defecto
        Me.PorDefecto()
        'en blanco
        Me.txtPeri.Text = String.Empty
        Me.ImportesDebeHaber()
        'los controles que deben estar activos
        acc.Nuevo()
        Me.txtPeri.ReadOnly = False
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtPeri)
        '\\
    End Sub

    Sub ventanaModificar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Modificar Registro CajaBanco"
        'mostrar el registro en pantalla
        Me.obtenerRegCajaBancoEnPantalla(codigo)
        'mostrar el detalle del registro en pantalla
        Me.obtenerRegCajaBancoDetalleEnPantalla(codigo)
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtDia)
        Me.ImportesDebeHaber()
        'los controles que deben estar activos
        acc.Modificar()
        Me.HabilitarControlesSegunCuentaBanco()
        '\\
    End Sub

    Sub ventanaCopiar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Copiar Registro CajaBanco"
        'mostrar el registro en pantalla
        Me.obtenerRegCajaBancoEnPantalla(codigo)
        'mostrar el detalle del registro en pantalla
        Me.obtenerRegCajaBancoDetalleEnPantalla(codigo)
        'limpiar el correlativo voucher
        Me.txtNumVau.Text = ""
        ent.ClaveRegContabCabe = ""
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtCodOri)
        Me.ImportesDebeHaber()
        'los controles que deben estar activos
        acc.Modificar()
        'habilitar el campo file ya que en el modificar este control esta deshabilitado
        Me.txtCodOri.ReadOnly = False
        Me.txtCodFil.ReadOnly = False
        Me.HabilitarControlesSegunCuentaBanco()
        '\\
    End Sub

    Sub ventanaEliminar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Eliminar Registro CajaBanco"
        'mostrar el registro en pantalla
        Me.obtenerRegCajaBancoEnPantalla(codigo)
        'mostrar el detalle del registro en pantalla
        Me.obtenerRegCajaBancoDetalleEnPantalla(codigo)
        Me.btnAceptar.Text = "Eliminar"
        Me.btnAceptar.Focus()
        Me.ImportesDebeHaber()
        Me.btnAgreCueBco.Enabled = False
        Me.btnQuiCueBco.Enabled = False
        'los controles que deben estar activos
        acc.Eliminar()
        '\\
    End Sub


    Sub ventanaVisualizar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Visualizar Registro CajaBanco"
        'mostrar el registro en pantalla
        Me.obtenerRegCajaBancoEnPantalla(codigo)
        'mostrar el detalle del registro en pantalla
        Me.obtenerRegCajaBancoDetalleEnPantalla(codigo)
        'los controles que deben estar activos
        Me.ImportesDebeHaber()
        Me.btnAgreCueBco.Enabled = False
        Me.btnQuiCueBco.Enabled = False
        acc.Visualizar()
        '\\
    End Sub

    Sub obtenerRegCajaBancoEnPantalla(ByRef codigo As String)
        '//
        ent.ClaveRegContabCabe = codigo
        ent = rcb.buscarRegContabExisPorClave(ent)
        'preguntar si ent tiene el registro
        If ent.ClaveRegContabCabe = "" Then
            Exit Sub
        Else
            '/Pasar Datos a los controles
            Me.TxtCodEmp.Text = ent.CodigoEmpresa
            Me.txtNomEmp.Text = ent.RazonSocialEmpresa
            Me.txtPeri.Text = ent.PeriodoRegContabCabe
            Me.txtCodOri.Text = ent.CodigoOrigen
            Me.txtNomOri.Text = ent.NombreOrigen
            Me.txtCodFil.Text = ent.CodigoFile
            Me.txtNomFil.Text = ent.NombreFile
            Me.txtNumVau.Text = ent.NumeroVoucherRegContabCabe
            Me.txtDia.Text = ent.DiaVoucherRegContabCabe
            Me.txtFecVau.Text = ent.FechaVoucherRegContabCabe.Date.ToShortDateString
            Gb.pasarDato(Me.gbMoneda, ent.MonedaDocumento)
            Me.txtTipCam.Text = ent.VentaTipoCambio.ToString
            Me.txtTipCam1.Text = ent.VentaEurTipoCambio.ToString
            Me.TxtImporte.Text = Varios.numeroConDosDecimal(ent.ImporteRegContabCabe.ToString)
            Me.txtModo.Text = ent.CodigoModoPago
            Me.txtNomMod.Text = ent.NombreModoPago
            Me.txtdoc.Text = ent.TipoDocumento
            Me.TxtNomDoc.Text = ent.NombreDocumento
            Me.txtNum.Text = ent.NumeroDocumento
            Me.TxtCodCb.Text = ent.CodigoCuentaBanco
            Me.TxtBcoCb.Text = ent.BancoCuentaBanco
            Me.TxtNumCb.Text = ent.NumeroCuentaBanco
            Me.TxtCodAux.Text = ent.CodigoAuxiliar
            Me.TxtNomAux.Text = ent.DescripcionAuxiliar
            ' Me.TxtNomIe.Text = ent.NombreIngEgr
            Me.TxtGirado.Text = ent.DescripcionRegContabCabe
            Me.TxtConcepto.Text = ent.GlosaRegContabCabe
        End If
        '\\
    End Sub

    Sub obtenerRegCajaBancoDetalleEnPantalla(ByRef codigo As String)
        '/
        entD.ClaveRegContabCabe = codigo
        entD.EstadoRegContabDeta = ""  ' "0"  OJ0
        entD.CampoOrden = cam.ClaveRCD
        If Me.operacion = 1 Or Me.operacion = 5 Then
            listaD = rcbd.obtenerDetalleRegContabXClaveYEstado(entD)
        Else
            listaD = rcbd.obtenerDetalleRegContabXClaveCabe(entD)
        End If
        'listaD = rcbd.obtenerDetalleRegContabXClaveYEstado(entD)
        ' listaD = rcbd.obtenerDetalleRegContabXClaveYEstadoNew(entD)
        ' MsgBox(listaD.Count)
        'preguntamos si la lista no esta vacia
        If listaD.Count <> 0 Then
            For n As Integer = 0 To listaD.Count - 1
                Me.DgvRegCbco.Rows.Add()

                Me.DgvRegCbco.Rows(n).Cells(0).Value = listaD.Item(n).CodigoCuentaPcge
                Me.DgvRegCbco.Rows(n).Cells(1).Value = listaD.Item(n).NombreCuentaPcge
                Me.DgvRegCbco.Rows(n).Cells(2).Value = listaD.Item(n).CodigoAuxiliar
                Me.DgvRegCbco.Rows(n).Cells(3).Value = listaD.Item(n).DescripcionAuxiliar
                Me.DgvRegCbco.Rows(n).Cells(4).Value = listaD.Item(n).DebeHaberRegContabDeta
                Me.DgvRegCbco.Rows(n).Cells(5).Value = Varios.numeroConDosDecimal(listaD.Item(n).ImporteSRegContabDeta.ToString)
                Me.DgvRegCbco.Rows(n).Cells(6).Value = Varios.numeroConDosDecimal(listaD.Item(n).ImporteDRegContabDeta.ToString)
                Me.DgvRegCbco.Rows(n).Cells(7).Value = Varios.numeroConDosDecimal(listaD.Item(n).ImporteERegContabDeta.ToString)
                Me.DgvRegCbco.Rows(n).Cells(8).Value = listaD.Item(n).TipoDocumento
                Me.DgvRegCbco.Rows(n).Cells(9).Value = listaD.Item(n).NombreDocumento
                Me.DgvRegCbco.Rows(n).Cells(10).Value = listaD.Item(n).SerieDocumento
                Me.DgvRegCbco.Rows(n).Cells(11).Value = listaD.Item(n).NumeroDocumento
                Me.DgvRegCbco.Rows(n).Cells(12).Value = listaD.Item(n).FechaDocumento
                Me.DgvRegCbco.Rows(n).Cells(13).Value = listaD.Item(n).CodigoIngEgr
                Me.DgvRegCbco.Rows(n).Cells(14).Value = listaD.Item(n).NombreIngEgr
                Me.DgvRegCbco.Rows(n).Cells(15).Value = listaD.Item(n).GlosaRegContabDeta
                Me.DgvRegCbco.Rows(n).Cells(16).Value = listaD.Item(n).CodigoCentroCosto
                Me.DgvRegCbco.Rows(n).Cells(17).Value = listaD.Item(n).NombreCentroCosto
                Me.DgvRegCbco.Rows(n).Cells(18).Value = listaD.Item(n).VentaTipoCambio
                Me.DgvRegCbco.Rows(n).Cells(19).Value = listaD.Item(n).VentaEurTipoCambio
                Me.DgvRegCbco.Rows(n).Cells(20).Value = listaD.Item(n).ClaveRegContabCabe
                Me.DgvRegCbco.Rows(n).Cells(21).Value = listaD.Item(n).Exporta
                Me.DgvRegCbco.Rows(n).Cells(22).Value = Varios.numeroConDosDecimal(listaD.Item(n).MontoMoneda.ToString)
                Me.DgvRegCbco.Rows(n).Cells(23).Value = Varios.numeroConDosDecimal(listaD.Item(n).MontoSoles.ToString)
                Me.DgvRegCbco.Rows(n).Cells(24).Value = listaD.Item(n).CodigoArea
                Me.DgvRegCbco.Rows(n).Cells(25).Value = listaD.Item(n).NombreArea
                Me.DgvRegCbco.Rows(n).Cells(26).Value = listaD.Item(n).CodigoFlujoCaja
                Me.DgvRegCbco.Rows(n).Cells(27).Value = listaD.Item(n).NombreFlujoCaja

            Next

        End If
    End Sub

    Sub GrabarDetalleRegContab()

        If Me.DgvRegCbco.Rows.Count <> 1 Then
            For n As Integer = 0 To Me.DgvRegCbco.Rows.Count - 2
                'Llenando el detalle
                entD.CodigoOrigen = Me.txtCodOri.Text.Trim
                entD.ClaveRegContabCabe = ent.ClaveRegContabCabe
                entD.CorrelativoRegContabDeta = (n + 1).ToString.PadLeft(4, CType("0", Char))
                entD.CodigoCuentaPcge = Me.DgvRegCbco.Item(0, n).Value.ToString
                entD.CodigoAuxiliar = Me.DgvRegCbco.Item(2, n).Value.ToString
                entD.DebeHaberRegContabDeta = Me.DgvRegCbco.Item(4, n).Value.ToString
                entD.ImporteSRegContabDeta = CType(Me.DgvRegCbco.Item(5, n).Value.ToString, Decimal)
                entD.ImporteDRegContabDeta = CType(Me.DgvRegCbco.Item(6, n).Value.ToString, Decimal)
                entD.ImporteERegContabDeta = CType(Me.DgvRegCbco.Item(7, n).Value.ToString, Decimal)
                entD.TipoDocumento = Me.DgvRegCbco.Item(8, n).Value.ToString
                entD.SerieDocumento = Me.DgvRegCbco.Item(10, n).Value.ToString
                entD.NumeroDocumento = Me.DgvRegCbco.Item(11, n).Value.ToString
                entD.FechaDocumento = CType(Me.DgvRegCbco.Item(12, n).Value.ToString, Date)
                entD.CodigoIngEgr = Me.DgvRegCbco.Item(13, n).Value.ToString
                entD.GlosaRegContabDeta = Me.DgvRegCbco.Item(15, n).Value.ToString
                entD.CodigoCentroCosto = Me.DgvRegCbco.Item(16, n).Value.ToString
                entD.VentaTipoCambio = CType(Me.DgvRegCbco.Item(18, n).Value.ToString, Decimal)
                entD.VentaEurTipoCambio = CType(Me.DgvRegCbco.Item(19, n).Value.ToString, Decimal)
                entD.Exporta = Me.DgvRegCbco.Item(21, n).Value.ToString
                entD.MontoMoneda = CType(Me.DgvRegCbco.Item(22, n).Value.ToString, Decimal)
                entD.MontoSoles = CType(Me.DgvRegCbco.Item(23, n).Value.ToString, Decimal)
                entD.Cuenta1242 = ""
                entD.EstadoRegContabDeta = ""
                entD.CodigoArea = Me.DgvRegCbco.Item(24, n).Value.ToString
                entD.CodigoFlujoCaja = Me.DgvRegCbco.Item(26, n).Value.ToString
                rcbd.nuevoRegContabDeta(entD)
            Next
        End If
    End Sub

    Sub Aceptar()
        '//
        If Me.operacion = 1 Or Me.operacion = 2 Then
            'Volver a traer el registro 
            ent.DatoCondicion1 = ent.ClaveRegContabCabe
            ent = rcb.buscarRegContabExisPorClave(ent)
        End If
        ent.CodigoEmpresa = Me.TxtCodEmp.Text
        ent.PeriodoRegContabCabe = Me.txtPeri.Text
        ent.CodigoOrigen = Me.txtCodOri.Text
        ent.CodigoFile = Me.txtCodFil.Text
        '    ent.NumeroVoucherRegContabCabe = Me.txtNumVau.Text
        ent.DiaVoucherRegContabCabe = Me.txtDia.Text
        ent.FechaVoucherRegContabCabe = CType(Me.txtFecVau.Text, Date)
        ent.MonedaDocumento = Rbt.radioActivo(Me.gbMoneda).Text.ToString.Trim()
        ent.VentaTipoCambio = CType(Me.txtTipCam.Text, Decimal)
        ent.VentaEurTipoCambio = CType(Me.txtTipCam1.Text, Decimal)
        ent.ImporteRegContabCabe = CType(Me.TxtImporte.Text, Decimal)
        ent.CodigoModoPago = Me.txtModo.Text
        ent.TipoDocumento = Me.txtdoc.Text
        ent.NumeroDocumento = Me.TxtNum.Text
        ent.CodigoCuentaBanco = Me.TxtCodCb.Text
        ent.CodigoAuxiliar = Me.TxtCodAux.Text
        ent.DescripcionRegContabCabe = Me.TxtGirado.Text
        ent.GlosaRegContabCabe = Me.TxtConcepto.Text
        'Defecto 
        ent.EstadoRegContabCabe = "2"  ''Inicio al grabar varia con otro proceso sino se graba en negocio
        ent.RetencionRegContabCabe = ""
        ent.CodigoIngEgr = ""
        ent.SerieDocumento = ""
        ent.FechaDocumento = CType(Me.txtFecVau.Text, Date)
        ent.DetraccionRegContabCabe = ""
        ent.FechaDetraccionRegContabCabe = ""
        ent.NumeroPapeletaRegContabCabe = ""
        ent.CartaRegContabCabe = ""
        ent.VoucherIngresoRegContabCabe = ""
        ent.ImporteSolRegContabCabe = CType(Me.txtDistr.Text, Decimal) + Math.Abs(CType(Me.TxtSaldo.Text, Decimal))
        ent.SumaDebeRegContabCabe = CType(Me.txtDebeS.Text, Decimal)
        ent.SumaHaberRegContabCabe = CType(Me.txtHaberS.Text, Decimal)

        'COMO ESTA PANTALLA SI TE DEJA GRABAR SIN NINGUN DETALLE
        'EL ULTIMO CORRELATIVO  ES:
        Dim iUltCorre As Integer = Me.DgvRegCbco.Rows.Count - 1
        iUltCorre += Me.UltimoCorrelativo
        If ent.PrecioVtaRegContabCabe = 0 Then
            ent.UltimoCorrelativo = "0001"
        Else
            ent.UltimoCorrelativo = (iUltCorre).ToString.PadLeft(4, CType("0", Char))
        End If

        ent.TipoDocumento1 = ""
        ent.SerieDocumento1 = ""
        ent.NumeroDocumento1 = ""
        ent.MonedaDocumento1 = ""
        ent.FechaDocumento1 = ""
        ent.ModoCompra = ""

        ent.FechaVencimiento = CType(Me.txtFecVau.Text, Date)

        '/Se graba o0 se modifica?
        Select Case Me.operacion

            Case 0
                'Igv
                ent.IgvPar = parEn.IgvPar

                ''numero voucher autogenerado
                'Dim aut As New SuperEntidad
                'aut.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
                'aut.AnoVoucher = ent.PeriodoRegContabCabe.Substring(0, 4)
                'aut.CodigoMes = ent.PeriodoRegContabCabe.Substring(4, 2)
                'aut.CodigoFile = Me.txtCodFil.Text.Trim
                'ent.NumeroVoucherRegContabCabe = vou.obtenerVoucherAutogenerado(aut)

                ent.EstadoRegistro = "0" 'normal
                rcb.nuevoRegContabCabe(ent)
                ''Eliminamos el detalle 
                'rcbd.eliminarRegContabDeta(ent)
                Me.GrabarDetalleRegContab()
                Me.GrabarDiferenciaCambio()
                Me.pagarDocumentos()

                MsgBox("Registro Caja Banco ingresado correctamente" + Chr(13) + "Numero de Vowcher es: " + ent.NumeroVoucherRegContabCabe, MsgBoxStyle.Information)
                'Limpiar la grilla
                Me.DgvRegCbco.Rows.Clear()
                acc.LimpiarControles()
                Me.HabilitarControlesSegunCuentaBanco()
                'Me.ImportesSolesDolares()
                Txt.cursorAlUltimo(Me.txtDia)

            Case 4
                'Igv
                'ent.IgvPar = parEn.IgvPar
                ''numero voucher autogenerado
                'Dim aut As New SuperEntidad
                'aut.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
                'aut.PeriodoRegContabCabe = Me.txtPeri.Text.Trim
                'aut.AnoVoucher = aut.PeriodoRegContabCabe.Substring(0, 4)
                'aut.CodigoMes = aut.PeriodoRegContabCabe.Substring(4, 2)
                'aut.CodigoFile = Me.txtCodFil.Text.Trim
                'ent.NumeroVoucherRegContabCabe = vou.obtenerVoucherAutogenerado(aut)

                'rcb.nuevoRegContabCabe(ent)
                ''eliminamos el detalle 
                'rcbd.eliminarRegContabDeta(ent)
                'Me.GrabarDetalleRegContab()
                'MsgBox("Registro CajaBanco ingresado correctamente", MsgBoxStyle.Information)
                ''Limpiar la grilla
                'Me.DgvRegCbco.Rows.Clear()
                'acc.LimpiarControles()
                ''Me.ImportesSolesDolares()
                'Txt.cursorAlUltimo(Me.txtCodOri)

            Case 1
                'MODIFICAR LA CUENTA CORRIENTE CON EL DETALLE
                'ANTIGUO DE ESTE REGISTRO
                Me.ModificarCuentaCorriente()

                'MODIFICAR CABECERA
                rcb.modificarRegContab(ent)

                'ELIMINAMOS EL DETALLE ANTIGUO
                rcbd.eliminarRegContabDeta(ent)

                'GRABAMOS EL NUEVO DETALLE
                Me.GrabarDetalleRegContab()
                Me.GrabarDiferenciaCambio()
                Me.pagarDocumentos()
                MsgBox("Registro CajaBanco modificado correctamente", MsgBoxStyle.Information)
                Me.Close()

            Case 2

                'Actualizar Cuenta Corriente
                Me.ModificarCuentaCorriente()
                'eliminar cabecera
                rcb.eliminarRegContabFis(ent)
                'Eliminamos el detalle 
                rcbd.eliminarRegContabDeta(ent)

                'Eliminamos el detalle antiguo
                MsgBox("Registro CajaBanco Eliminado correctamente", MsgBoxStyle.Information)
                Me.Close()
            Case 5
                ent.IgvPar = parEn.IgvPar
                'numero voucher autogenerado
                'Dim aut As New SuperEntidad
                'aut.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
                'aut.AnoVoucher = ent.PeriodoRegContabCabe.Substring(0, 4)
                'aut.CodigoMes = ent.PeriodoRegContabCabe.Substring(4, 2)
                'aut.CodigoFile = Me.txtCodFil.Text.Trim
                'ent.NumeroVoucherRegContabCabe = vou.obtenerVoucherAutogenerado(aut)
                ent.EstadoRegistro = "0" 'normal
                rcb.nuevoRegContabCabe(ent)
                ''Eliminamos el detalle 
                'rcbd.eliminarRegContabDeta(ent)
                Me.GrabarDetalleRegContab()
                Me.GrabarDiferenciaCambio()
                Me.pagarDocumentos()

                MsgBox("Registro Caja Banco ingresado correctamente" + Chr(13) + "Numero de Vowcher es: " + ent.NumeroVoucherRegContabCabe, MsgBoxStyle.Information)
                'Limpiar la grilla
                Me.Close()

        End Select
        '/Actualizar y buscar el registro grabado
        Me.wRcb.ActualizarVentana()
        Select Case operacion
            Case 0, 5
                ent.ClaveRegContabCabe = ent.CodigoEmpresa + ent.PeriodoRegContabCabe + ent.CodigoOrigen + ent.CodigoFile + ent.NumeroVoucherRegContabCabe
                Dgv.obtenerCursorActual(Me.wRcb.DgvCbco, ent.ClaveRegContabCabe, Me.wRcb.lista)
            Case 1, 2, 3, 4
                Dgv.PonerFranja(Me.wRcb.DgvCbco, Me.wRcb.ifil)

        End Select

        'MOSTRAR LA IMPRESION DEL VOUCHER SOLO CUANDO ES NUEVO O MODIFICA
        If Me.operacion = 0 Or Me.operacion = 1 Or Me.operacion = 5 Then
            If ent.ImporteRegContabCabe <> 0 Then
                If ent.CodigoOrigen = "2" Then
                    'Me.wRcb.wImpVoucher1()    No Imprime Voucher si se quita si imprime  cambio 12-09-2017
                Else
                    'Me.wRcb.wImpVoucher()     No Imprime voucher si se quita si imprime cambio 12-09-2017
                End If
                'Me.wRcb.wImpVoucher()
            End If

        End If

        '\\
    End Sub

    Function EsNumeroVoucherCorrecto() As Boolean
        Dim aut As New SuperEntidad
        aut.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        aut.AnoVoucher = Me.txtPeri.Text.Trim.Substring(0, 4)
        aut.CodigoMes = Me.txtPeri.Text.Trim.Substring(4, 2)
        aut.CodigoFile = Me.txtCodFil.Text.Trim
        ent.NumeroVoucherRegContabCabe = vou.obtenerVoucherAutogenerado(aut)

        Dim RccRN As New RegContabCabeRN
        Dim RccEN As New SuperEntidad
        RccEN.ClaveRegContabCabe += Me.TxtCodEmp.Text.Trim
        RccEN.ClaveRegContabCabe += Me.txtPeri.Text.Trim
        RccEN.ClaveRegContabCabe += Me.txtCodOri.Text.Trim
        RccEN.ClaveRegContabCabe += Me.txtCodFil.Text.Trim
        RccEN.ClaveRegContabCabe += ent.NumeroVoucherRegContabCabe
        RccEN = RccRN.buscarRegContabExisPorClave(RccEN)
        If RccEN.ClaveRegContabCabe = "" Then
            Return True
        Else
            MsgBox("El correlativo " + ent.NumeroVoucherRegContabCabe + " Ya Existe", MsgBoxStyle.Information, "Diaros")
            Return False
        End If

    End Function


    Sub pagarDocumentos()
        Dim cc As New SuperEntidad

        If Me.DgvRegCbco.Rows.Count <> 1 Then
            For n As Integer = 0 To Me.DgvRegCbco.Rows.Count - 2
                'Llenando el detalle
                cc.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
                cc.CodigoAuxiliar = Me.DgvRegCbco.Item(2, n).Value.ToString
                cc.TipoDocumento = Me.DgvRegCbco.Item(8, n).Value.ToString
                cc.SerieDocumento = Me.DgvRegCbco.Item(10, n).Value.ToString
                cc.NumeroDocumento = Me.DgvRegCbco.Item(11, n).Value.ToString
                Dim iCuenta As String = Me.DgvRegCbco.Item(0, n).Value.ToString

                cc.ClaveDocumentoCuentaCorriente = cc.CodigoEmpresa + cc.CodigoAuxiliar + cc.TipoDocumento + cc.SerieDocumento + cc.NumeroDocumento
                '' Buscar Cuenta Corriente
                cc = ccte.buscarCuentaCorrienteExisPorClaveDoc(cc)
                If cc.ClaveDocumentoCuentaCorriente <> "" Then
                    If iCuenta = cc.CodigoCuentaPcge Then
                        Select Case cc.MonedaDocumento
                            Case "S/."
                                cc.ImportePagadoCuentaCorriente = cc.ImportePagadoCuentaCorriente + CType(Me.DgvRegCbco.Item(5, n).Value.ToString, Decimal)
                            Case "US$"
                                cc.ImportePagadoCuentaCorriente = cc.ImportePagadoCuentaCorriente + CType(Me.DgvRegCbco.Item(6, n).Value.ToString, Decimal)
                            Case "EUR"
                                cc.ImportePagadoCuentaCorriente = cc.ImportePagadoCuentaCorriente + CType(Me.DgvRegCbco.Item(7, n).Value.ToString, Decimal)
                        End Select

                        If cc.ImporteOriginalCuentaCorriente = cc.ImportePagadoCuentaCorriente Then
                            cc.SaldoCuentaCorriente = 0
                            cc.EstadoCuentaCorriente = "0"  ''Cancelado
                            ccte.modificarCuentaCorriente(cc)
                        Else
                            cc.SaldoCuentaCorriente = cc.ImporteOriginalCuentaCorriente - cc.ImportePagadoCuentaCorriente
                            cc.EstadoCuentaCorriente = "1"  ''Pendiente 
                            ccte.modificarCuentaCorriente(cc)
                        End If

                    End If
                    
                End If
            Next
        End If
    End Sub

    Sub ModificarCuentaCorriente()
        Dim lisRcd As New List(Of SuperEntidad)
        Dim regDet, cueCorr As New SuperEntidad

        'OBTENER LA CLAVE
        regDet.ClaveRegContabCabe += Me.TxtCodEmp.Text.Trim
        regDet.ClaveRegContabCabe += Me.txtPeri.Text.Trim
        regDet.ClaveRegContabCabe += Me.txtCodOri.Text.Trim
        regDet.ClaveRegContabCabe += Me.txtCodFil.Text.Trim
        regDet.ClaveRegContabCabe += Me.txtNumVau.Text.Trim

        'LISTAR EL DETALLE DE ESTE REGISTRO
        lisRcd = rcbd.obtenerDetalleRegContabPorClave(regDet)
        For n As Integer = 0 To lisRcd.Count - 1
            regDet = lisRcd.Item(n)
            cueCorr.ClaveDocumentoCuentaCorriente = regDet.CodigoEmpresa + regDet.CodigoAuxiliar + regDet.TipoDocumento + regDet.SerieDocumento + regDet.NumeroDocumento
            cueCorr = ccte.buscarCuentaCorrienteExisPorClaveDoc(cueCorr)
            If cueCorr.ClaveDocumentoCuentaCorriente <> "" Then
                If regDet.CodigoCuentaPcge = cueCorr.CodigoCuentaPcge Then
                    Select Case cueCorr.MonedaDocumento
                        Case "S/."
                            cueCorr.ImportePagadoCuentaCorriente = cueCorr.ImportePagadoCuentaCorriente - regDet.ImporteSRegContabDeta
                            cueCorr.SaldoCuentaCorriente = cueCorr.SaldoCuentaCorriente + regDet.ImporteSRegContabDeta
                        Case "US$"
                            cueCorr.ImportePagadoCuentaCorriente = cueCorr.ImportePagadoCuentaCorriente - regDet.ImporteDRegContabDeta
                            cueCorr.SaldoCuentaCorriente = cueCorr.SaldoCuentaCorriente + regDet.ImporteDRegContabDeta
                        Case "EUR"
                            cueCorr.ImportePagadoCuentaCorriente = cueCorr.ImportePagadoCuentaCorriente - regDet.ImporteERegContabDeta
                            cueCorr.SaldoCuentaCorriente = cueCorr.SaldoCuentaCorriente + regDet.ImporteERegContabDeta
                    End Select
                    cueCorr.EstadoCuentaCorriente = "1"
                    ccte.modificarCuentaCorriente(cueCorr)
                End If
            End If
        Next
    End Sub

    Sub GrabarDiferenciaCambio()

        If Me.AplicaDiferenciaCambio = False Then Exit Sub

        Dim xdebe As Decimal = 0
        Dim xhaber As Decimal = 0
        Dim xdif As Decimal = 0
        Dim iNumeroRegistros As Integer = Me.DgvRegCbco.Rows.Count - 1

        If Me.txtCodOri.Text = "2" Then
            For n As Integer = 0 To Me.DgvRegCbco.Rows.Count - 2

                If Me.DgvRegCbco.Item("DH", n).Value.ToString = "Haber" Then
                    xhaber = xhaber + CType(Me.DgvRegCbco.Item(5, n).Value, Decimal)
                End If

                If Me.DgvRegCbco.Item("DH", n).Value.ToString = "Debe" Then
                    xdebe = xdebe + CType(Me.DgvRegCbco.Item(5, n).Value, Decimal)
                End If

            Next
            xdif = xhaber - xdebe
            If xdif > 0 Then

                Dim obj As New SuperEntidad
                obj.ClaveRegContabCabe = ent.ClaveRegContabCabe
                obj.CorrelativoRegContabDeta = (iNumeroRegistros + 2).ToString.PadLeft(4, CType("0", Char))
                obj.CodigoCuentaPcge = parEn.CuentaPerdidaDC
                obj.CodigoAuxiliar = ""
                obj.DebeHaberRegContabDeta = "Debe"
                obj.ImporteSRegContabDeta = xdif
                obj.ImporteDRegContabDeta = 0
                obj.TipoDocumento = ""
                obj.SerieDocumento = ""
                obj.NumeroDocumento = ""
                obj.FechaDocumento = CType(Me.txtFecVau.Text, DateTime)
                obj.CodigoIngEgr = ""
                obj.GlosaRegContabDeta = "Perdida por diferencia de cambio"
                'defecto
                If Me.TxtCodEmp.Text = "001" Then
                    obj.CodigoCentroCosto = "999300"
                Else
                    obj.CodigoCentroCosto = "93000"
                End If

                obj.VentaTipoCambio = 1
                obj.Cuenta1242 = ""
                obj.CodigoArea = ""
                obj.CodigoFlujoCaja = ""
                obj.EstadoRegContabDeta = "1" ' No se en grilla
                rcbd.nuevoRegContabDeta(obj)
            End If

            If xdif < 0 Then

                Dim obj As New SuperEntidad
                obj.ClaveRegContabCabe = ent.ClaveRegContabCabe
                obj.CorrelativoRegContabDeta = (iNumeroRegistros + 2).ToString.PadLeft(4, CType("0", Char))
                obj.CodigoCuentaPcge = parEn.CuentaGananciaDC
                obj.CodigoAuxiliar = ""
                obj.DebeHaberRegContabDeta = "Haber"
                obj.ImporteSRegContabDeta = Math.Abs(xdif)
                obj.ImporteDRegContabDeta = 0
                obj.TipoDocumento = ""
                obj.SerieDocumento = ""
                obj.NumeroDocumento = ""
                obj.FechaDocumento = CType(Me.txtFecVau.Text, DateTime)
                obj.CodigoIngEgr = ""
                obj.GlosaRegContabDeta = "Ganancia por diferencia de cambio"
                'defecto
                If Me.TxtCodEmp.Text = "001" Then
                    obj.CodigoCentroCosto = "999300"
                Else
                    obj.CodigoCentroCosto = "93000"
                End If
                '  obj.CodigoCentroCosto = "999101"
                obj.VentaTipoCambio = 1
                obj.Cuenta1242 = ""
                obj.CodigoArea = ""
                obj.CodigoFlujoCaja = ""
                obj.EstadoRegContabDeta = "1" ' No se en grilla
                rcbd.nuevoRegContabDeta(obj)
            End If
        End If

        ' Ingresos
        If Me.txtCodOri.Text = "1" Then
            For n As Integer = 0 To Me.DgvRegCbco.Rows.Count - 2
                If Me.DgvRegCbco.Item("DH", n).Value.ToString = "Debe" Then
                    xdebe = xdebe + CType(Me.DgvRegCbco.Item(5, n).Value, Decimal)
                End If

                If Me.DgvRegCbco.Item("DH", n).Value.ToString = "Haber" Then
                    xhaber = xhaber + CType(Me.DgvRegCbco.Item(5, n).Value, Decimal)
                End If

            Next
            xdif = xdebe - xhaber
            If xdif > 0 Then

                Dim obj As New SuperEntidad
                obj.ClaveRegContabCabe = ent.ClaveRegContabCabe
                obj.CorrelativoRegContabDeta = (iNumeroRegistros + 2).ToString.PadLeft(4, CType("0", Char))
                obj.CodigoCuentaPcge = parEn.CuentaGananciaDC
                obj.CodigoAuxiliar = ""
                obj.DebeHaberRegContabDeta = "Haber"
                obj.ImporteSRegContabDeta = xdif
                obj.ImporteDRegContabDeta = 0
                obj.TipoDocumento = ""
                obj.SerieDocumento = ""
                obj.NumeroDocumento = ""
                obj.FechaDocumento = CType(Me.txtFecVau.Text, DateTime)
                obj.CodigoIngEgr = ""
                obj.GlosaRegContabDeta = "Ganancia por diferencia de cambio"
                'defecto
                If Me.TxtCodEmp.Text = "001" Then
                    obj.CodigoCentroCosto = "999300"
                Else
                    obj.CodigoCentroCosto = "93000"
                End If
                'obj.CodigoCentroCosto = "999101"
                obj.VentaTipoCambio = 1
                obj.Cuenta1242 = ""
                obj.CodigoArea = ""
                obj.CodigoFlujoCaja = ""
                obj.EstadoRegContabDeta = "1" ' No se en grilla
                rcbd.nuevoRegContabDeta(obj)
            End If

            If xdif < 0 Then

                Dim obj As New SuperEntidad
                obj.ClaveRegContabCabe = ent.ClaveRegContabCabe
                obj.CorrelativoRegContabDeta = (iNumeroRegistros + 2).ToString.PadLeft(4, CType("0", Char))
                obj.CodigoCuentaPcge = parEn.CuentaPerdidaDC
                obj.CodigoAuxiliar = ""
                obj.DebeHaberRegContabDeta = "Debe"
                obj.ImporteSRegContabDeta = Math.Abs(xdif)
                obj.ImporteDRegContabDeta = 0
                obj.TipoDocumento = ""
                obj.SerieDocumento = ""
                obj.NumeroDocumento = ""
                obj.FechaDocumento = CType(Me.txtFecVau.Text, DateTime)
                obj.CodigoIngEgr = ""
                obj.GlosaRegContabDeta = "Perdida por diferencia de cambio"
                'defecto
                If Me.TxtCodEmp.Text = "001" Then
                    obj.CodigoCentroCosto = "999300"
                Else
                    obj.CodigoCentroCosto = "93000"
                End If
                ' obj.CodigoCentroCosto = "999101"
                obj.VentaTipoCambio = 1
                obj.Cuenta1242 = ""
                obj.CodigoArea = ""
                obj.CodigoFlujoCaja = ""
                obj.EstadoRegContabDeta = "1" ' No se en grilla
                rcbd.nuevoRegContabDeta(obj)
            End If
        End If

    End Sub

    Sub GrabarDetalleNulo()
        Dim obj As New SuperEntidad

        obj.ClaveRegContabCabe = ent.ClaveRegContabCabe
        obj.CorrelativoRegContabDeta = (1).ToString.PadLeft(4, CType("0", Char))
        obj.CodigoCuentaPcge = ent.CodigoCuentaBanco
        obj.CodigoAuxiliar = ""
        obj.DebeHaberRegContabDeta = "Debe"
        obj.ImporteSRegContabDeta = 0
        obj.ImporteDRegContabDeta = 0
        obj.TipoDocumento = ent.TipoDocumento
        obj.SerieDocumento = ""
        obj.NumeroDocumento = ent.NumeroDocumento
        obj.FechaDocumento = ent.FechaDocumento
        obj.CodigoIngEgr = ""
        obj.GlosaRegContabDeta = ent.DescripcionRegContabCabe
        'defecto
        obj.CodigoCentroCosto = ""
        obj.VentaTipoCambio = 1
        obj.Cuenta1242 = ""
        obj.CodigoArea = ""
        obj.CodigoFlujoCaja = ""
        obj.EstadoRegContabDeta = "1" ' No se en grilla
        rcbd.nuevoRegContabDeta(obj)

    End Sub

    Sub EsDocumentoAnulado()
        Dim pv As Decimal = CType(Me.TxtImporte.Text, Decimal)
        If Me.operacion = 0 Or Me.operacion = 5 Then
            If pv = 0 Then
                Dim rpta As Integer = MsgBox("Deseas Grabar Un Documento Anulado ?", MsgBoxStyle.YesNo, "Caja y Bancos")
                If rpta = MsgBoxResult.Yes Then
                    'LIMPIAR LA GRILLA POR QUE ES UN DOCUMENTO ANULADO
                    'Y NO TIENE DETALLE
                    Me.DgvRegCbco.Rows.Clear()
                    'GRABAR
                    If Me.operacion = 0 Or Me.operacion = 5 Then
                        'Validadando el correlativo del voucher si es nuevo
                        If Me.EsNumeroVoucherCorrecto = False Then Exit Sub
                    End If
                    Me.Aceptar()
                    'Grabar Registro de cheque anulado
                    Me.GrabarDetalleNulo()
                    'Me.wRcb.wImpVoucher()

                Else
                    Exit Sub
                End If
            Else
                If Me.operacion = 0 Or Me.operacion = 5 Then
                    'Validadando el correlativo del voucher si es nuevo
                    If Me.EsNumeroVoucherCorrecto = False Then Exit Sub
                End If
                Me.Aceptar()

            End If
        Else
            If Me.operacion = 1 Then
                If pv = 0 Then
                    Me.DgvRegCbco.Rows.Clear()
                    Me.Aceptar()
                    Me.GrabarDetalleNulo()
                    'Me.wRcb.wImpVoucher()

                    'MsgBox("Importe del Documento no puede ser Cero ( 0 ) en Modificar", MsgBoxStyle.Exclamation, "Caja y Bancos")
                    Exit Sub
                Else
                    Me.Aceptar()
                End If
            Else
                Me.Aceptar()
            End If

        End If
    End Sub

    Function EsPagoCobranzaPermitida() As Boolean
        'OBTIENE EL NUMERO DE DETALLE QUE SE REGISTRO
        Dim iNumeroDetalle As Integer = Me.DgvRegCbco.Rows.Count - 1
        'CON CERO O UN DETALLE NO SE PUEDE DETERMINAR SI ES PERMITIDO 
        'EL PAGO O COBRANZA DEL DOCUMENTO POR ESO RETORNA VERDADERO
        If iNumeroDetalle = 0 Then
            Return True
        End If

        'AQUI COMO MINIMO HAY 1 O MAS DETALLES
        'OBTENER LA MONEDA DEL DOCUMENTO DE PAGO O COBRANZA
        Dim iMonedaCb As String = Rbt.radioActivo(Me.gbMoneda).Text
        'SEGUN MONEDA
        Select Case iMonedaCb
            Case "S/." : Return True

            Case "US$"
                'EL DETALLE NO DEBE CONTENER NINGUN EURO
                If Dgv.ObtenerNumeroOcurenciasDeValor(Me.DgvRegCbco, "Moneda", "EUR") = 0 Then
                    Return True
                Else
                    MsgBox("Si la moneda de pago o cobranza es dolar ningun documento a pagar o cobrar debe ser euro", MsgBoxStyle.Exclamation, "moneda")
                    Return False
                End If

            Case "EUR"
                'EL DETALLE NO DEBE CONTENER NINGUN DOLAR
                If Dgv.ObtenerNumeroOcurenciasDeValor(Me.DgvRegCbco, "Moneda", "US$") = 0 Then
                    Return True
                Else
                    MsgBox("Si la moneda de pago o cobranza es euro ningun documento a pagar o cobrar debe ser dolar", MsgBoxStyle.Exclamation, "moneda")
                    Return False
                End If

        End Select

    End Function

    Sub AfinarCentecimas()
        Me.EsCuadrado = False

        Dim iNumeroDetalle As Integer = Me.DgvRegCbco.Rows.Count - 1
        'AQUI NO HAY QUE AFINAR NADA
        If iNumeroDetalle = 0 Then
            Me.AplicaDiferenciaCambio = False
            Me.UltimoCorrelativo = 0
            If Me.TxtImporte.Text = "0.00" Then
                Me.EsCuadrado = True
            End If
            Exit Sub
        End If

        If iNumeroDetalle = 1 Then
            Me.AplicaDiferenciaCambio = False
            Me.UltimoCorrelativo = 0
            Exit Sub
        End If

        'APARTIR DE AQUI HAY UN MINIMO DE 2 DETALLES
        'NECESITAMOS SABER SI HAY DEBES Y HABERES (AMBOS)
        Dim iOcurrenciaHaberes As Integer = Dgv.ObtenerNumeroOcurenciasDeValor(Me.DgvRegCbco, "DH", "Haber")

        If iOcurrenciaHaberes = 0 Or iOcurrenciaHaberes = iNumeroDetalle Then
            Me.AplicaDiferenciaCambio = False
            Me.UltimoCorrelativo = 0
            Exit Sub
        End If

        'APARTIR DE AQUI HAY DEBES Y HABERES
        'SUMAR COLUMNAS
        Dim iMontoSoles As Decimal = Dgv.SumarColumna(Me.DgvRegCbco, "MontoSoles")
        Dim iMontoMonedaHaber As Decimal = Me.ObtenerSumaDebeHaberEnMontoMoneda("Haber")
        Dim iMontoMonedaDebe As Decimal = Me.ObtenerSumaDebeHaberEnMontoMoneda("Debe")
        Dim iMontoSolesHaber As Decimal = Me.ObtenerSumaDebeHaberEnMontoSoles("Haber")
        Dim iMontoSolesDebe As Decimal = Me.ObtenerSumaDebeHaberEnMontoSoles("Debe")
        Dim iIndiceFilaCb As Integer = Dgv.ObtenerIndiceFila(Me.DgvRegCbco, "MontoSoles", "0.00")
        Dim iImporteCb As Decimal = CType(Me.TxtImporte.Text, Decimal)
        Dim iDifDebHab As Decimal = Math.Abs(iMontoMonedaHaber - iMontoMonedaDebe)
        Dim iDifMontoSoles As Decimal = Math.Abs(iMontoSolesHaber - iMontoSolesDebe)

        'SI iImporteCb y iMontoMoneda  SON IGUALES SE ENDIENDE QUE EL USUARIO CUADRO SU CAJA Y BANCO
        If iImporteCb = iDifDebHab Then
            Me.txtDistr.Text = iDifMontoSoles.ToString
            Me.DgvRegCbco.Item("IMPORTES", iIndiceFilaCb).Value = iDifMontoSoles
            Me.TxtSaldo.Text = "0.00"
            'PONER EL MONTO SEGUN QUIEN ES EL MAYOR
            If iMontoSolesHaber > iMontoSolesDebe Then
                Me.txtHaberS.Text = iMontoSolesHaber.ToString
                Me.txtDebeS.Text = iMontoSolesHaber.ToString
            Else
                Me.txtHaberS.Text = iMontoSolesDebe.ToString
                Me.txtDebeS.Text = iMontoSolesDebe.ToString
            End If

            Me.AplicaDiferenciaCambio = True
            Me.UltimoCorrelativo = 1
        Else
            Me.AplicaDiferenciaCambio = False
            Me.UltimoCorrelativo = 0
        End If

        'VARIABLE QUE INDICA SI EL REGISTRO ESTA CUADRADO
        Dim iSumaDebe As Decimal = CType(Me.txtDebeS.Text, Decimal)
        Dim iSumaHaber As Decimal = CType(Me.txtHaberS.Text, Decimal)
        Dim iSaldo As Decimal = Math.Abs(CType(Me.TxtSaldo.Text, Decimal))
        Dim iDist As Decimal = CType(Me.txtDistr.Text, Decimal)
        If iSumaDebe = iSumaHaber Then
            If iDist > iSumaDebe Then
                Me.EsCuadrado = False
            Else
                If iDist + iSaldo = iSumaDebe Then
                    Me.EsCuadrado = True
                Else
                    Me.EsCuadrado = True
                End If
            End If
        Else
            Me.EsCuadrado = False
        End If
    End Sub

    Public Function ObtenerSumaDebeHaberEnMontoMoneda(ByVal pDebeHaber As String) As Decimal
        Dim iMonto As Decimal = 0
        For n As Integer = 0 To Me.DgvRegCbco.Rows.Count - 2
            If Me.DgvRegCbco.Item("DH", n).Value.ToString = pDebeHaber Then
                iMonto += CType(Me.DgvRegCbco.Item("MontoMoneda", n).Value, Decimal)
            End If
        Next
        Return iMonto
    End Function

    Public Function ObtenerSumaDebeHaberEnMontoSoles(ByVal pDebeHaber As String) As Decimal
        Dim iMonto As Decimal = 0
        For n As Integer = 0 To Me.DgvRegCbco.Rows.Count - 2
            If Me.DgvRegCbco.Item("DH", n).Value.ToString = pDebeHaber Then
                iMonto += CType(Me.DgvRegCbco.Item("MontoSoles", n).Value, Decimal)
            End If
        Next
        Return iMonto
    End Function

    Sub ActualizarMontosSegunAgregarCuentaBanco()
        'MONTO MONEDA Y MONTO SOLES
        Dim iMontoMoneda As String = ""
        Dim iMontoSoles As String = ""

        'OBTENER LA MONEDA DE LA CABECERA CAJA Y BANCOS
        Dim iMonedaCb As String = Rbt.radioActivo(Me.gbMoneda).Text

        'OBTENER TIPOS DE CAMBIO DE LA CABECERA
        Dim iTcDol As Decimal = CType(Me.txtTipCam.Text, Decimal)
        Dim iTcEur As Decimal = CType(Me.txtTipCam1.Text, Decimal)

        'RECORRIENDO TODOS LOS DOCUMENTOS DE LA GRILLA
        For n As Integer = 0 To Me.DgvRegCbco.Rows.Count - 2


            'OBTENER LA MONEDA DEL DOCUMENTO
            Dim iMonedaDcto As String = Me.DgvRegCbco.Rows(n).Cells("Moneda").Value.ToString

            'OBTENER LOS TRES IMPORTES DEL DOCUMENTO
            Dim iImporteSoles As Decimal = CType(Me.DgvRegCbco.Rows(n).Cells("IMPORTES").Value.ToString, Decimal)
            Dim iImporteDolares As Decimal = CType(Me.DgvRegCbco.Rows(n).Cells("ImporteD").Value.ToString, Decimal)
            Dim iImporteEuros As Decimal = CType(Me.DgvRegCbco.Rows(n).Cells("ImporteE").Value.ToString, Decimal)

            Select Case iMonedaCb

                Case "S/."

                    Select Case iMonedaDcto

                        Case "S/."
                            iMontoMoneda = iImporteSoles.ToString
                            iMontoSoles = iImporteSoles.ToString

                        Case "US$"
                            iMontoMoneda = Varios.numeroConDosDecimal((iImporteDolares * iTcDol).ToString)
                            iMontoSoles = iMontoMoneda

                        Case "EUR"
                            iMontoMoneda = Varios.numeroConDosDecimal((iImporteEuros * iTcEur).ToString)
                            iMontoSoles = iMontoMoneda

                    End Select

                Case "US$"

                    Select Case iMonedaDcto

                        Case "S/."
                            iMontoMoneda = Varios.numeroConDosDecimal((iImporteSoles / iTcDol).ToString)
                            iMontoSoles = iImporteSoles.ToString

                        Case "US$"
                            iMontoMoneda = iImporteDolares.ToString
                            iMontoSoles = Varios.numeroConDosDecimal((iImporteDolares * iTcDol).ToString)

                        Case "EUR"
                            iMontoMoneda = "1.00"
                            iMontoSoles = "1.00"

                    End Select

                Case "EUR"

                    Select Case iMonedaDcto

                        Case "S/."
                            iMontoMoneda = Varios.numeroConDosDecimal((iImporteSoles / iTcEur).ToString)
                            iMontoSoles = iImporteSoles.ToString

                        Case "US$"
                            iMontoMoneda = "1.00"
                            iMontoSoles = "1.00"

                        Case "EUR"
                            iMontoMoneda = iImporteEuros.ToString
                            iMontoSoles = Varios.numeroConDosDecimal((iImporteEuros * iTcEur).ToString)

                    End Select
            End Select

            'MODIFICANDO EL MontoMoneda y MontoSoles
            Me.DgvRegCbco.Rows(n).Cells("MontoMoneda").Value = iMontoMoneda
            Me.DgvRegCbco.Rows(n).Cells("MontoSoles").Value = iMontoSoles

        Next




    End Sub

    Sub AgregarCuentaBanco()
        'VALIDAR LOS CAMPOS OBLIGATORIOS
        If acc.CamposObligatorios = False Then Exit Sub

        'BUSCAR QUE EN EL DETALLE NO SE HA AGREGADO UNA CUENTA BANCO
        Dim iIndiceFilaCB As Integer = Dgv.ObtenerIndiceFila(Me.DgvRegCbco, "MontoSoles", "0.00")
        If iIndiceFilaCB <> -1 Then
            MsgBox("Ya existe una cuenta de banco en el detalle", MsgBoxStyle.Information, "Caja y bancos")
            Exit Sub
        End If

        'EL IMPORTE NO PUEDE SER CERO
        If Me.TxtImporte.Text = "0.00" Then
            MsgBox("El importe no puede ser cero", MsgBoxStyle.Information, "Caja y bancos")
            Me.TxtImporte.Focus()
            Exit Sub
        End If

        'MODIFICAR MONTOMONEDA Y MONTOSOLES A CADA DOCUMENTO DE LA GRILLA
        'POR QUE TAL VEZ SE CAMBIO DATOS DE LA CUENTA BANCO
        Me.ActualizarMontosSegunAgregarCuentaBanco()

        'INSERTAR EL DETALLE DE LA CUENTA BANCO
        Me.DgvRegCbco.Rows.Add()
        'INDICE DEL REGISTRO EN DONDE SE INSERTARA EL ASIENTO BANCO
        Dim iNumeroRegistros As Integer = Me.DgvRegCbco.Rows.Count - 2
        Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(0).Value = Me.TxtCodCb.Text.Trim
        Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(1).Value = Me.TxtBcoCb.Text.Trim
        Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(2).Value = ""
        Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(3).Value = ""

        'PONER DEBE O HABER
        If Me.txtCodOri.Text = "1" Then
            Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(4).Value = "Debe"
        Else
            Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(4).Value = "Haber"
        End If


        'PONER SEGUN MONEDA
        Dim IMon As String = Rbt.radioActivo(Me.gbMoneda).Text
        Select Case IMon
            Case "S/."
                Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(5).Value = Me.TxtImporte.Text
                Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(6).Value = Varios.numeroConDosDecimal((CType(Me.TxtImporte.Text, Decimal) / CType(Me.txtTipCam.Text, Decimal)).ToString)
                Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(7).Value = Varios.numeroConDosDecimal((CType(Me.TxtImporte.Text, Decimal) / CType(Me.txtTipCam1.Text, Decimal)).ToString)

            Case "US$"
                Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(5).Value = Varios.numeroConDosDecimal((CType(Me.TxtImporte.Text, Decimal) * CType(Me.txtTipCam.Text, Decimal)).ToString)
                Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(6).Value = Me.TxtImporte.Text
                Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(7).Value = "1.00"

            Case "EUR"
                Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(5).Value = Varios.numeroConDosDecimal((CType(Me.TxtImporte.Text, Decimal) * CType(Me.txtTipCam1.Text, Decimal)).ToString)
                Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(6).Value = "1.00"
                Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(7).Value = Me.TxtImporte.Text
        End Select

        Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(8).Value = Me.txtdoc.Text.Trim
        Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(9).Value = Me.TxtNomDoc.Text.Trim
        Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(10).Value = ""
        Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(11).Value = Me.TxtNum.Text.Trim
        Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(12).Value = Me.txtFecVau.Text
        Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(13).Value = Me.TxtCodAux.Text
        Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(14).Value = ""
        Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(15).Value = Me.TxtConcepto.Text.Trim
        Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(16).Value = ""
        Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(17).Value = ""
        Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(18).Value = Me.txtTipCam.Text
        Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(19).Value = Me.txtTipCam1.Text
        Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(20).Value = ""
        Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(21).Value = IMon
        Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(22).Value = "0.00"
        Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(23).Value = "0.00"
        Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(24).Value = ""
        Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(25).Value = ""
        Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(26).Value = ""
        Me.DgvRegCbco.Rows(iNumeroRegistros).Cells(27).Value = ""

        'GENERAR IMPORTES DEBE Y HABER
        Me.ImportesDebeHaber()

        'DESHABILITAR LOS CONTROLES DE LA CABECERA
        Me.HabilitarControlesSegunCuentaBanco()

    End Sub

    Sub QuitarCuentaBanco()
        'BUSCAR EL INDICE DE LA CUENTA BANCO EN EL DETALLE
        Dim iIndiceFilaCB As Integer = Dgv.ObtenerIndiceFila(Me.DgvRegCbco, "MontoSoles", "0.00")
        If iIndiceFilaCB = -1 Then
            MsgBox("No existe una cuenta de banco en el detalle", MsgBoxStyle.Information, "Caja y bancos")
        Else
            Dim rpta As Integer = MsgBox("Deseas sacar la cuenta banco del detalle", MsgBoxStyle.YesNo, "Caja y bancos")
            If rpta = MsgBoxResult.Yes Then
                Me.DgvRegCbco.Rows.RemoveAt(iIndiceFilaCB)
                'HABILITAR LOS CONTROLES DE LA CABECERA
                Me.HabilitarControlesSegunCuentaBanco()
            Else
                Exit Sub
            End If
        End If

    End Sub

    Public Sub HabilitarControlesSegunCuentaBanco()
        'BUSCAR EL INDICE DE LA CUENTA BANCO EN EL DETALLE
        Dim iIndiceFilaCB As Integer = Dgv.ObtenerIndiceFila(Me.DgvRegCbco, "MontoSoles", "0.00")
        Dim iVf As Boolean
        If iIndiceFilaCB = -1 Then
            'COMO NO ENCONTRO LA CUENTA BANCO EN EL DETALLE
            'ENTONCES SI SE PUEDE DIGITAR EN LA CABECERA
            iVf = True
        Else
            iVf = False
        End If

        'HABILITANDO CONTROLES
        Me.txtDia.Enabled = iVf
        'SEGUN MONEDA

        If iVf = True Then
            Rbt.HabilitarTodosLosRadio(Me.gbMoneda)
        Else
            Rbt.HabilitarSoloRadioActivo(Me.gbMoneda)
        End If

        Me.TxtImporte.Enabled = iVf
        Me.txtdoc.Enabled = iVf
        Me.TxtNum.Enabled = iVf
        Me.TxtCodCb.Enabled = iVf
    End Sub

    Function EsCuenta10Registrado() As Boolean
        Dim iIndiceFilaCb As Integer = Dgv.ObtenerIndiceFila(Me.DgvRegCbco, "MontoSoles", "0.00")
        If Me.TxtImporte.Text = "0.00" Then
            Return True
        End If
        If iIndiceFilaCb = -1 Then
            MsgBox("Hacer Click en el boton Agregar Cuenta Banco", MsgBoxStyle.Exclamation, "Bancos")
            Return False
        Else
            Return True
        End If
    End Function


#End Region

    Private Sub WEditarPptoInterno_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Me.Text = "Eliminar Registro CajaBanco" Then
            Me.Aceptar()
            Exit Sub
        End If
        If acc.CamposObligatorios = False Then
            Exit Sub
        Else

            'DEBE GRABAR CUENTA 10 EN EL DETALLE
            If Me.EsCuenta10Registrado = False Then Exit Sub

            'ANTES DE GRABAR DEBEMOS COMPROBAR SI LOS DOCUMENTOS A PAGAR O COBRAR SON PERMITIDOS
            'EJEMPLO (NO SE PUEDE PAGAR DOCUMENTOS EN DOLARES Y EUROS A LA VEZ, SI LA MONEDA DE
            'PAGO O COBRANZA ES DOLARES O EUROS)
            If Me.EsPagoCobranzaPermitida = False Then Exit Sub

            'AFINAR CENTECIMAS POR MOTIVOS DE DIVIDIR Y MULTIPLICAR LOS TIPOS DE CAMBIOS
            'AFECTA A LOS CONTROLES (DIST SOLES , A LA CUENTA 10 DEL DETALLE)
            'TAMBIEN ME INFORMA SI SE DEBE GENERAR LA DIFERENCIA DE CAMBIO
            'TAMBIEN PARA EL CORRELATIVO DETALLE
            Me.AfinarCentecimas()

            If Me.EsCuadrado = False Then
                MsgBox("Voucher No esta Cuadrado", MsgBoxStyle.YesNo)
                Exit Sub
            Else
                Me.EsDocumentoAnulado()
            End If

            ''SI NO ESTA CUADRADO
            'If Me.TxtSaldo.Text <> "0.00" Then
            '    Dim rpta As Integer = MsgBox("Voucher No esta Cuadrado" + Chr(13) + "Desea Grabar", MsgBoxStyle.YesNo)
            '    If rpta = MsgBoxResult.Yes Then
            '        Me.EsDocumentoAnulado()
            '    Else
            '        Exit Sub
            '    End If
            'Else
            '    Me.EsDocumentoAnulado()
            'End If


        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If Me.Text = "Visualizar Registro CajaBanco" Then
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

    Private Sub TxtFecVau_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtFecVau.Validating
        Me.TraerTipoCambio()
        Me.ImportesDebeHaber()
    End Sub

#Region "Mostrar formulario lista"
    Private Sub txtCodOri_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodOri.KeyDown
        If Me.txtCodFil.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarTabla
                win.tabla = "Origen"
                win.titulo = "Origenes"
                win.condicion = "1Y2"
                win.ent.DatoFiltro1 = "1"
                win.txt1 = Me.txtCodOri
                win.txt2 = Me.txtNomOri
                win.ctrlFoco = Me.txtCodFil
                win.NuevaVentana()
            End If
        End If

    End Sub

    Private Sub txtCodFil_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodFil.KeyDown
        If Me.txtCodFil.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListaFiles
                win.titulo = "Files"
                win.CondicionLista = "ListarFilesXOrigen"
                win.ent.CodigoFile = Me.txtCodOri.Text
                'win.ent.DatoFiltro1 = Me.txtCodOri.Text   '' Campo que viene del pasoa anterior
                win.txt1 = Me.txtCodFil
                win.txt2 = Me.txtNomFil
                win.ctrlFoco = Me.txtDia
                win.NuevaVentana()
            End If
        End If

    End Sub

    Private Sub txtModo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtModo.KeyDown
        If Me.txtModo.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarTabla
                win.tabla = "ModoPago"
                win.titulo = "Modo de Pago"
                win.txt1 = Me.txtModo
                win.txt2 = Me.txtNomMod
                win.ctrlFoco = Me.txtdoc
                win.NuevaVentana()
            End If
        End If

    End Sub

    Private Sub txtDoc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtdoc.KeyDown
        If Me.txtdoc.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarTabla
                win.tabla = "Documento"
                win.titulo = "Documentos"
                win.txt1 = Me.txtdoc
                win.txt2 = Me.TxtNomDoc
                win.ctrlFoco = Me.txtNum
                win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub txtCodBc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodCb.KeyDown
        If Me.TxtCodCb.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarCuentaBanco
                win.tabla = "PorEmpresaYMoneda"
                win.titulo = "Cuentas Bancos"
                win.ent.MonedaCuentaBanco = Rbt.radioActivo(Me.gbMoneda).Text.ToString.Trim       ''Moneda de pantalla
                win.txt1 = Me.TxtCodCb
                win.txt2 = Me.TxtBcoCb
                win.txt3 = Me.TxtNumCb
                win.ctrlFoco = Me.TxtCodAux
                win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub txtCodAux_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodAux.KeyDown
        If Me.TxtCodAux.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarAuxiliar
                win.wEditRegCajBco = Me
                Me.AddOwnedForm(win)
                win.tabla = "Todos"
                win.titulo = "Auxiliares"
                win.txt1 = Me.TxtCodAux
                win.txt2 = Me.TxtNomAux
                If Me.operacion = 0 Then
                    win.txt3 = Me.TxtGirado
                End If
                ' win.txt3 = Me.TxtGirado
                'If Me.TxtCodAux.Text.Trim = "" Then
                '    win.ctrlFoco = Me.TxtGirado
                'Else
                '    Me.TxtGirado.ReadOnly = True
                '    win.ctrlFoco = Me.TxtConcepto
                'End If
                win.ctrlFoco = Me.TxtConcepto
                'win.ctrlFoco = Me.TxtGirado
                win.NuevaVentana()
            End If
        End If


        'If Me.TxtCodAux.ReadOnly = False Then
        '    If e.KeyCode = Keys.F1 Then
        '        Dim win As New WListarTabla
        '        win.tabla = "Ingresos/Egresos"
        '        win.titulo = "Ingresos/Egresos"
        '        win.txt1 = Me.TxtCodAux
        '        win.txt2 = Me.TxtNomIe
        '        win.ctrlFoco = Me.TxtGirado
        '        win.NuevaVentana()
        '    End If
        'End If
    End Sub


#End Region

#Region "Buscar por codigo"
    Private Sub txtCodori_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodOri.Validating
        If Me.Text = "Agregar Registro CajaBanco" Or Me.Text = "Agregar Manual Registro CajaBanco" Or Me.operacion = 5 Then
            If Me.txtCodOri.Text.Trim <> "" Then
                Dim codOri As String = Me.txtCodOri.Text.Trim.Substring(0, 1)
                If codOri = "1" Or codOri = "2" Then
                    Dim ope As New OperaWin : ope.txt1 = Me.txtCodOri : ope.txt2 = Me.txtNomOri
                    ope.MostrarCodigoDescripcionDeTabla("Ori", "Origen", e)
                Else
                    MsgBox("El Codigo Origen no existe", MsgBoxStyle.Information)
                    Me.txtCodOri.Text = String.Empty
                    Me.txtNomOri.Text = String.Empty
                    Me.txtCodOri.Focus()
                End If
            End If
        End If

    End Sub

    Private Sub txtCodFil_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodFil.Validating
        If Me.operacion = 0 Or Me.operacion = 4 Or Me.operacion = 5 Then
            If Me.txtCodFil.Text.Trim <> "" Then
                Dim codfil As String = Me.txtCodFil.Text.Trim.Substring(0, 1)
                If codfil = "1" Or codfil = "2" Then
                    Dim ope As New OperaWin : ope.txt1 = Me.txtCodFil : ope.txt2 = Me.txtNomFil
                    ope.MostrarCodigoDescripcionDeFile("Files", e)
                Else
                    MsgBox("El Codigo File no existe", MsgBoxStyle.Information)
                    Me.txtCodFil.Text = String.Empty
                    Me.txtNomFil.Text = String.Empty
                    Me.txtDia.Focus()
                End If
            End If
        End If

    End Sub

    Private Sub txtModo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtModo.Validating
        If Me.Text = "Agregar Registro CajaBanco" Or Me.Text = "Modificar Registro CajaBanco" Or Me.Text = "Agregar Manual Registro CajaBanco" Or Me.operacion = 5 Then
            Dim ope As New OperaWin : ope.txt1 = Me.txtModo : ope.txt2 = Me.txtNomMod
            ope.MostrarCodigoDescripcionDeTabla("Mod", "Modo de Pago", e)
        End If

    End Sub

    Private Sub txtDoc_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtdoc.Validating
        If Me.Text = "Agregar Registro CajaBanco" Or Me.Text = "Modificar Registro CajaBanco" Or Me.Text = "Agregar Manual Registro CajaBanco" Or Me.operacion = 5 Then
            Dim ope As New OperaWin : ope.txt1 = Me.txtdoc : ope.txt2 = Me.TxtNomDoc
            ope.MostrarCodigoDescripcionDeTabla("Doc", "Documento", e)
        End If

    End Sub

    Private Sub txtCodcb_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodCb.Validating
        If Me.operacion = 0 Or Me.operacion = 1 Or Me.operacion = 4 Or Me.operacion = 5 Then
            Dim ope As New OperaWin : ope.txt1 = Me.TxtCodCb : ope.txt2 = Me.TxtBcoCb : ope.txt3 = Me.TxtNumCb
            ope.obj.MonedaCuentaBanco = Rbt.radioActivo(Me.gbMoneda).Text.Trim
            ope.MostrarCodigoDescripcionDeCuentaBancoXMoneda("De Cuenta", e)
        End If
    End Sub

    Private Sub txtCodAux_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodAux.Validating
        If Me.operacion = 0 Or Me.operacion = 4 Or Me.operacion = 5 Then
            Dim ope As New OperaWin : ope.txt1 = Me.TxtCodAux : ope.txt2 = Me.TxtNomAux : ope.txt3 = Me.TxtGirado
            ope.MostrarCodigoDescripcionDeAuxiliar("Todos", "AUXILIARES", e)
        End If

        If Me.operacion = 1 Then
            Dim ope As New OperaWin : ope.txt1 = Me.TxtCodAux : ope.txt2 = Me.TxtNomAux
            ope.MostrarCodigoDescripcionDeAuxiliar("Todos", "AUXILIARES", e)
        End If

        'If Me.operacion = 0 Or Me.operacion = 1 Or Me.operacion = 4 Or Me.operacion = 5 Then
        '    Dim ope As New OperaWin : ope.txt1 = Me.TxtCodAux : ope.txt2 = Me.TxtNomAux : ope.txt3 = Me.TxtGirado
        '    ope.MostrarCodigoDescripcionDeAuxiliar("Todos", "AUXILIARES", e)
        'End If

    End Sub

#End Region

#Region "Calculos"

    Sub CalculoDistribucion()
        If Me.TxtImporte.Text <> "" Then
            'Cambiar txtVv por txtDistr

            Dim str As String = Rbt.radioActivo(Me.gbMoneda).Text.ToString.Trim()
            Select Case str
                Case "S/."
                    Me.txtDistr.Text = Me.TxtImporte.Text
                Case "US$"
                    Me.txtDistr.Text = Varios.numeroConDosDecimal((CType(Me.TxtImporte.Text, Decimal) * CType(Me.txtTipCam.Text, Decimal)).ToString)
                Case "EUR"
                    Me.txtDistr.Text = Varios.numeroConDosDecimal((CType(Me.TxtImporte.Text, Decimal) * CType(Me.txtTipCam1.Text, Decimal)).ToString)
            End Select
        End If
    End Sub

    Private Sub txtDia_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDia.Validated
        If Me.txtPeri.Text <> "" Then
            If Me.txtDia.Text.Trim <> "" Then
                Dim periodo As String = Me.txtPeri.Text.Trim
                Dim dia As String = Me.txtDia.Text.Trim
                If Varios.LimiteMinMaxDeValores(dia, 1, 31) = True Then
                    dia = Varios.FormatoDia(dia)
                    Me.txtDia.Text = dia
                    Me.txtFecVau.Text = dia + "/" + periodo.Substring(4, 2) + "/" + periodo.Substring(0, 4)
                    Me.TraerTipoCambio()
                    Me.ImportesDebeHaber()
                Else
                    MsgBox("El dia debe estar entre en 1 y 31", MsgBoxStyle.Information)
                    Me.txtDia.Focus()
                End If
            End If
        End If
    End Sub

    Sub ImportesDebeHaber()
        Me.CalculoDistribucion()
        'indice debe/haber 4
        'indice importe soles 5
        'indice importe dolares 6
        Me.txtHaberS.Text = "0.00"
        Me.txtDebeS.Text = "0.00"
        Me.txtHaberD.Text = "0.00"
        Me.txtDebeD.Text = "0.00"
        Dim numreg As Integer = Me.DgvRegCbco.Rows.Count - 2
        Dim deha As String
        Dim impS, impD As Decimal
        For n As Integer = 0 To numreg
            deha = Me.DgvRegCbco.Item(4, n).Value.ToString
            impS = CType(Me.DgvRegCbco.Item(5, n).Value.ToString, Decimal)
            impD = CType(Me.DgvRegCbco.Item(6, n).Value.ToString, Decimal)
            Select Case deha
                Case "Haber"
                    Me.txtHaberS.Text = (CType(Me.txtHaberS.Text, Decimal) + impS).ToString
                    Me.txtHaberD.Text = (CType(Me.txtHaberD.Text, Decimal) + impD).ToString
                Case "Debe"
                    Me.txtDebeS.Text = (CType(Me.txtDebeS.Text, Decimal) + impS).ToString
                    Me.txtDebeD.Text = (CType(Me.txtDebeD.Text, Decimal) + impD).ToString

            End Select

        Next
        'Saldo segun origen
        If Me.txtCodOri.Text = "2" Then  'Egreso
            If Me.operacion = 1 Or Me.operacion = 5 Then
                Me.TxtSaldo.Text = (CType(Me.txtDistr.Text, Decimal) - CType(Me.txtDebeS.Text, Decimal)).ToString
            Else
              Me.TxtSaldo.Text = (CType(Me.txtHaberS.Text, Decimal) - CType(Me.txtDebeS.Text, Decimal)).ToString
            End If
        Else
            If Me.operacion = 1 Or Me.operacion = 5 Then
                Me.TxtSaldo.Text = (CType(Me.txtDistr.Text, Decimal) - CType(Me.txtHaberS.Text, Decimal)).ToString
            Else
                Me.TxtSaldo.Text = (CType(Me.txtHaberS.Text, Decimal) - CType(Me.txtDebeS.Text, Decimal)).ToString
            End If
        End If
    End Sub

#End Region

#Region "Para Items"
    Sub NuevoItem()
        Dim win1 As New WDetalleRegCajaBanco
        'win1.concepto = Me.concepto
        'win1.titulo = Me.titulo
        win1.wRegCbco = Me
        win1.dtpFecha.Text = Me.txtFecVau.Text
        win1.txtTipCam.Text = Me.txtTipCam.Text
        win1.TxtTipcam1.Text = Me.txtTipCam1.Text
        win1.txtGlosa.Text = Me.TxtConcepto.Text
        'win1.r.rbtsol(gbMoneda.rbtsol.Text = Rbt.radioActivo(Me.gbMoneda).Text.ToString.Trim())
        If Rbt.radioActivo(Me.gbMoneda).Text.ToString.Trim() = "US$" Then
            'win1.gbMoneda(Rbt.radioActivo(Me.rbtDol).Checked) = True
            win1.rbtDol.Checked = True
            win1.txtImpDol.Text = Me.TxtImporte.Text
        Else
            If Rbt.radioActivo(Me.gbMoneda).Text.ToString.Trim() = "S/." Then
                win1.rbtSol.Checked = True
                win1.txtImpSol.Text = Me.TxtImporte.Text
            Else
                win1.RbtEur.Checked = True
                win1.TxtImpEur.Text = Me.TxtImporte.Text
            End If
        End If
        ' MsgBox(win1.txtImpSol.Text + " - " + win1.txtImpDol.Text + " - " + win1.TxtImpEur.Text)
        Me.AddOwnedForm(win1)
        win1.NuevaVentana()
    End Sub

    Sub ModificarItem()
        Dim win1 As New WDetalleRegCajaBanco
        ' win1.concepto = Me.concepto
        ' win1.titulo = Me.titulo
        win1.wRegCbco = Me
        Me.AddOwnedForm(win1)
        win1.ModificarVentana()
    End Sub

    Sub EliminarItem()
        Dim win1 As New WDetalleRegCajaBanco
        'win1.concepto = Me.concepto
        'win1.titulo = Me.titulo
        win1.wRegCbco = Me
        Me.AddOwnedForm(win1)
        win1.EliminaVentana()

    End Sub

    Public Function sumaImportes() As Decimal
        Dim sumImp As Decimal = 0
        If Me.DgvRegCbco.RowCount = 1 Then
            Return sumImp
        Else

            For n As Integer = 0 To Me.DgvRegCbco.RowCount - 2
                Dim valor As String = Me.DgvRegCbco.Item(5, n).Value.ToString
                sumImp = sumImp + CType(valor, Decimal)

            Next
            Return sumImp
        End If

    End Function

#End Region

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim numReg As Integer = Me.DgvRegCbco.Rows.Count
        If numReg = 0 Or numReg = 1 Then
            Exit Sub
        Else
            Dim indFil As Integer = Me.DgvRegCbco.CurrentRow.Index
            If indFil = numReg - 1 Then
                Exit Sub
            Else
                'CHEQUEAR QUE NO SEA LA CUENTA BANCO
                Dim iValorCelda As String = Dgv.obtenerValorCelda(Me.DgvRegCbco, "MontoSoles")
                'SI ES CERO QUIERE DECIR QUE ES LA CUENTA BANCO
                If iValorCelda = "0.00" Then
                    MsgBox("No puedes eliminar el detalle de la cuenta banco", MsgBoxStyle.Exclamation, "Caja y bancos")
                Else
                    Me.EliminarItem()
                End If
            End If
        End If
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If Me.txtDebeS.Text = Me.txtDistr.Text And Me.txtHaberS.Text = Me.txtDistr.Text Then
            MsgBox("El Importe ya esta Cuadrado")
        Else
            'If CType(Me.txtDistr.Text, Decimal) < CType(Me.txtDebeS.Text, Decimal) Or CType(Me.txtDistr.Text, Decimal) < CType(Me.txtHaberS.Text, Decimal) Then
            '    MsgBox("La suma de sus importes en el detalle ha sobrepasado al Importe total en soles")
            'Else
            '    If (Me.txtDebeS.Text = "0.00" And Me.txtHaberS.Text = "0.00") And (Me.txtDebeS.Text < Me.txtDistr.Text Or Me.txtHaberS.Text < Me.txtDistr.Text) Then
            '        Me.NuevoItem()
            '    Else
            '        If CType(Me.txtDebeS.Text, Decimal) = CType(Me.txtHaberS.Text, Decimal) Then
            '            MsgBox("La suma de los importes ya estan cuadrados")
            '        Else
            '            Me.NuevoItem()
            '        End If
            '    End If
            'End If
            If (Me.txtDebeS.Text = "0.00" And Me.txtHaberS.Text = "0.00") And (Me.txtDebeS.Text < Me.txtDistr.Text Or Me.txtHaberS.Text < Me.txtDistr.Text) Then
                Me.NuevoItem()
            Else
                If CType(Me.txtDebeS.Text, Decimal) = CType(Me.txtHaberS.Text, Decimal) Then
                    MsgBox("La suma de los importes ya estan cuadrados")
                Else
                    Me.NuevoItem()
                End If
            End If
        End If
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Dim numReg As Integer = Me.DgvRegCbco.Rows.Count
        If numReg = 0 Or numReg = 1 Then
            Exit Sub
        Else
            Dim indFil As Integer = Me.DgvRegCbco.CurrentRow.Index
            If indFil = numReg - 1 Then
                Exit Sub
            Else
                'CHEQUEAR QUE NO SEA LA CUENTA BANCO
                Dim iValorCelda As String = Dgv.obtenerValorCelda(Me.DgvRegCbco, "MontoSoles")
                'SI ES CERO QUIERE DECIR QUE ES LA CUENTA BANCO
                If iValorCelda = "0.00" Then
                    MsgBox("No puedes modificar el detalle de la cuenta banco", MsgBoxStyle.Exclamation, "Caja y bancos")
                Else
                    Me.ModificarItem()
                End If

            End If
        End If
    End Sub

    Private Sub rbtSol_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles rbtSol.Validating
        Me.ImportesDebeHaber()
    End Sub

    Private Sub rbtDol_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles rbtDol.Validating
        Me.ImportesDebeHaber()
    End Sub

    Private Sub txtPeri_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPeri.Validated
        If Me.operacion = 4 Then
            Dim p As String = Me.txtPeri.Text.Trim
            If p <> "" Then
                If p.Length <> 6 Then
                    MsgBox("No es un periodo valido", MsgBoxStyle.Information, "")
                    Me.txtPeri.Text = ""
                    Me.txtPeri.Focus()
                Else
                    If p >= PeriodoActual Then
                        MsgBox("Solo se puede digitar como maximo el periodo anterior de hoy", MsgBoxStyle.Information, "")
                        Me.txtPeri.Text = ""
                        Me.txtPeri.Focus()
                    Else
                        Dim dia As String = Me.txtDia.Text.Trim
                        If dia <> String.Empty Then
                            dia = Varios.FormatoDia(dia)
                            'Me.txtDia.Text = dia
                            Me.txtFecVau.Text = dia + "/" + Me.txtNomEmp.Text.Substring(4, 2) + "/" + Me.txtNomEmp.Text.Substring(0, 4)
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub TxtImporte_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtImporte.Validated
        Me.ImportesDebeHaber()
    End Sub

    Private Sub btnAgreCueBco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgreCueBco.Click
        Me.AgregarCuentaBanco()
    End Sub

    Private Sub btnQuiCueBco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuiCueBco.Click
        Me.QuitarCuentaBanco()
    End Sub

  
End Class