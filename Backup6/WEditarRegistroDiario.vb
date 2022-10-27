Imports Entidad
Imports Negocio

Public Class WEditarRegistroDiario

#Region "Propietarios"
    Public wRd As New WRegistroDiario
#End Region

    Public ent, entD, parEn, ticEn As New SuperEntidad
    Public lista, listaD As New List(Of SuperEntidad)
    Public rd As New RegContabCabeRN
    Public rdd As New RegContabDetaRN
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
        Me.TxtNomEmp.Text = SuperEntidad.xRazonSocial
        'Me.txtPeri.Text = SuperEntidad.xPeriodoEmpresa
        ''Instanciar Empresa Actual 
        'Dim obe As New SuperEntidad
        'obe.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        'obe = emp.buscarEmpresaExisPorCodigo(obe)
        Me.txtPeri.Text = SuperEntidad.xPeriodoEmpresa
        PeriodoActual = SuperEntidad.xPeriodoEmpresa

        Me.txtCodOri.Text = "3"
        Me.txtNomOri.Text = "Diario"
        '  Me.TraerTipoCambio()
    End Sub

    Sub ventanaAdicionar()
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Agregar Registro Diario"
        'poner valores defecto en montos
        acc.LimpiarControles()
        'por defecto
        Me.PorDefecto()
        Me.ImportesDebeHaber()
        ' Me.ImportesSolesDolares()
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtCodFil)
        'los controles que deben estar activos
        acc.Nuevo()
        '\\
    End Sub

    Sub ventanaAdicionarManual()
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Agregar Manual Registro Diario"
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
        Me.Text = "Modificar Registro Diario"
        'mostrar el registro en pantalla
        Me.obtenerRegDiarioEnPantalla(codigo)
        'mostrar el detalle del registro en pantalla
        Me.obtenerRegDiarioDetalleEnPantalla(codigo)
        Me.ImportesDebeHaber()
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtDia)
        ' Me.ImportesSolesDolares()
        ''los controles que deben estar activos
        acc.Modificar()
        '\\
    End Sub

    Sub ventanaCopiar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Copiar Registro Diario"
        'mostrar el registro en pantalla
        Me.obtenerRegDiarioEnPantalla(codigo)
        'mostrar el detalle del registro en pantalla
        Me.obtenerRegDiarioDetalleEnPantalla(codigo)
        'limpiar el correlativo voucher
        Me.txtNumVau.Text = ""
        ent.ClaveRegContabCabe = ""
        'poner el cursor de inicio
        'Txt.cursorAlUltimo(Me.txtCodFil)
        Txt.cursorAlUltimo(Me.txtDia)
        Me.ImportesDebeHaber()
        ' Me.ImportesSolesDolares()
        ''los controles que deben estar activos
        acc.Modificar()
        'habilitar el campo file ya que en el modificar este control esta deshabilitado
        Me.txtCodFil.ReadOnly = False
        '\\
    End Sub


    Sub ventanaEliminar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Eliminar Registro Diario"
        'mostrar el registro en pantalla
        Me.obtenerRegDiarioEnPantalla(codigo)
        'mostrar el detalle del registro en pantalla
        Me.obtenerRegDiarioDetalleEnPantalla(codigo)
        Me.btnAceptar.Text = "Eliminar"
        Me.ImportesDebeHaber()
        Me.btnAceptar.Focus()
        'Me.ImportesSolesDolares()
        ''los controles que deben estar activos
        acc.Eliminar()
        '\\
    End Sub


    Sub ventanaVisualizar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Visualizar Registro Diario"
        'mostrar el registro en pantalla
        Me.obtenerRegDiarioEnPantalla(codigo)
        'mostrar el detalle del registro en pantalla
        Me.obtenerRegDiarioDetalleEnPantalla(codigo)
        'los controles que deben estar activos
        ' Me.ImportesSolesDolares()
        Me.ImportesDebeHaber()
        acc.Visualizar()
        '\\
    End Sub

    Sub obtenerRegDiarioEnPantalla(ByRef codigo As String)
        '//
        ent.ClaveRegContabCabe = codigo
        ent = rd.buscarRegContabExisPorClave(ent)
        'preguntar si ent tiene el registro
        If ent.ClaveRegContabCabe = "" Then
            Exit Sub
        Else
            '/Pasar Datos a los controles
            Me.TxtCodEmp.Text = ent.CodigoEmpresa
            Me.TxtNomEmp.Text = ent.RazonSocialEmpresa
            If Me.operacion = 3 Then
                Me.txtPeri.Text = ent.PeriodoRegContabCabe
            Else
                Me.txtPeri.Text = SuperEntidad.xPeriodoEmpresa
            End If
            Me.txtCodOri.Text = ent.CodigoOrigen
            Me.txtNomOri.Text = ent.NombreOrigen
            Me.txtCodFil.Text = ent.CodigoFile
            Me.txtNomFil.Text = ent.NombreFile
            Me.txtNumVau.Text = ent.NumeroVoucherRegContabCabe
            Me.txtDia.Text = ent.DiaVoucherRegContabCabe
            Me.txtFecVau.Text = ent.FechaVoucherRegContabCabe.Date.ToShortDateString
            Me.txtGlosa.Text = ent.GlosaRegContabCabe
        End If
        '\\
    End Sub

    Sub obtenerRegDiarioDetalleEnPantalla(ByRef codigo As String)
        entD.ClaveRegContabCabe = codigo
        listaD = rdd.obtenerDetalleRegContabPorClave(entD)
        ' MsgBox(listaD.Count)
        'preguntamos si la lista no esta vacia
        If listaD.Count <> 0 Then
            For n As Integer = 0 To listaD.Count - 1
                Me.dgvRegDia.Rows.Add()

                Me.dgvRegDia.Rows(n).Cells(0).Value = listaD.Item(n).CodigoCuentaPcge
                Me.dgvRegDia.Rows(n).Cells(1).Value = listaD.Item(n).NombreCuentaPcge
                Me.dgvRegDia.Rows(n).Cells(2).Value = listaD.Item(n).CodigoAuxiliar
                Me.dgvRegDia.Rows(n).Cells(3).Value = listaD.Item(n).DescripcionAuxiliar
                Me.dgvRegDia.Rows(n).Cells(4).Value = listaD.Item(n).DebeHaberRegContabDeta
                Me.dgvRegDia.Rows(n).Cells(5).Value = listaD.Item(n).ImporteSRegContabDeta
                Me.dgvRegDia.Rows(n).Cells(6).Value = listaD.Item(n).ImporteDRegContabDeta
                Me.dgvRegDia.Rows(n).Cells(7).Value = listaD.Item(n).TipoDocumento
                Me.dgvRegDia.Rows(n).Cells(8).Value = listaD.Item(n).NombreDocumento
                Me.dgvRegDia.Rows(n).Cells(9).Value = listaD.Item(n).SerieDocumento
                Me.dgvRegDia.Rows(n).Cells(10).Value = listaD.Item(n).NumeroDocumento
                Me.dgvRegDia.Rows(n).Cells(11).Value = listaD.Item(n).FechaDocumento
                Me.dgvRegDia.Rows(n).Cells(12).Value = listaD.Item(n).VentaTipoCambio
                Me.dgvRegDia.Rows(n).Cells(13).Value = listaD.Item(n).CodigoIngEgr
                Me.dgvRegDia.Rows(n).Cells(14).Value = listaD.Item(n).NombreIngEgr
                Me.dgvRegDia.Rows(n).Cells(15).Value = listaD.Item(n).GlosaRegContabDeta
                Me.dgvRegDia.Rows(n).Cells(16).Value = listaD.Item(n).CodigoCentroCosto
                Me.dgvRegDia.Rows(n).Cells(17).Value = listaD.Item(n).NombreCentroCosto
                Me.dgvRegDia.Rows(n).Cells(18).Value = listaD.Item(n).Exporta
                Me.dgvRegDia.Rows(n).Cells(19).Value = listaD.Item(n).CodigoArea
                Me.dgvRegDia.Rows(n).Cells(20).Value = listaD.Item(n).NombreArea
                Me.dgvRegDia.Rows(n).Cells(21).Value = listaD.Item(n).CodigoPptoInterno
                Me.dgvRegDia.Rows(n).Cells(22).Value = listaD.Item(n).DescripcionProHijo
                Me.dgvRegDia.Rows(n).Cells(23).Value = listaD.Item(n).Titulo
                Me.dgvRegDia.Rows(n).Cells(24).Value = listaD.Item(n).NombreTitulo
                Me.dgvRegDia.Rows(n).Cells(25).Value = listaD.Item(n).CodigoInterno
                Me.dgvRegDia.Rows(n).Cells(26).Value = listaD.Item(n).NombreInterno
                Me.dgvRegDia.Rows(n).Cells(27).Value = listaD.Item(n).CodigoConcepto
                Me.dgvRegDia.Rows(n).Cells(28).Value = listaD.Item(n).CodigoGastoReparable
                Me.dgvRegDia.Rows(n).Cells(29).Value = listaD.Item(n).NombreGastoReparable
                Me.dgvRegDia.Rows(n).Cells(30).Value = listaD.Item(n).Cantidad
                Me.dgvRegDia.Rows(n).Cells(31).Value = listaD.Item(n).ClaveRegContabDeta
            Next

        End If
    End Sub


    Sub GrabarDetalleRegContab()

        If Me.dgvRegDia.Rows.Count <> 1 Then
            For n As Integer = 0 To Me.dgvRegDia.Rows.Count - 2
                'Llenando el detalle

                entD.ClaveRegContabCabe = ent.ClaveRegContabCabe
                entD.CorrelativoRegContabDeta = (n + 1).ToString.PadLeft(4, CType("0", Char))
                entD.PeriodoRegContabCabe = Me.txtPeri.Text.Trim
                entD.CodigoOrigen = Me.txtCodOri.Text
                entD.CodigoFile = Me.txtCodFil.Text
                entD.NumeroVoucherRegContabCabe = ent.NumeroVoucherRegContabCabe
                entD.FechaVoucherRegContabCabe = CType(Me.txtFecVau.Text, Date)
                entD.CodigoCuentaPcge = Me.dgvRegDia.Item(0, n).Value.ToString
                entD.CodigoAuxiliar = Me.dgvRegDia.Item(2, n).Value.ToString
                Dim str As String = Me.dgvRegDia.Item(4, n).Value.ToString
                If str = "Haber" Then
                    entD.DebeHaberRegContabDeta = "0"
                Else
                    entD.DebeHaberRegContabDeta = "1"
                End If
                entD.ImporteSRegContabDeta = CType(Me.dgvRegDia.Item(5, n).Value.ToString, Decimal)
                entD.ImporteDRegContabDeta = CType(Me.dgvRegDia.Item(6, n).Value.ToString, Decimal)
                entD.TipoDocumento = Me.dgvRegDia.Item(7, n).Value.ToString
                entD.SerieDocumento = Me.dgvRegDia.Item(9, n).Value.ToString
                entD.NumeroDocumento = Me.dgvRegDia.Item(10, n).Value.ToString
                entD.FechaDocumento = CType(Me.dgvRegDia.Item(11, n).Value.ToString, Date)
                entD.VentaTipoCambio = CType(Me.dgvRegDia.Item(12, n).Value.ToString, Decimal)
                entD.VentaEurTipoCambio = 0
                entD.CodigoIngEgr = Me.dgvRegDia.Item(13, n).Value.ToString
                entD.GlosaRegContabDeta = Me.dgvRegDia.Item(15, n).Value.ToString
                entD.CodigoCentroCosto = Me.dgvRegDia.Item(16, n).Value.ToString
                entD.Exporta = Me.dgvRegDia.Item(18, n).Value.ToString 'moneda documento
                entD.CodigoArea = Me.dgvRegDia.Item(19, n).Value.ToString
                entD.CodigoPptoInterno = Me.dgvRegDia.Item(21, n).Value.ToString
                entD.Titulo = Me.dgvRegDia.Item(23, n).Value.ToString
                entD.CodigoInterno = Me.dgvRegDia.Item(25, n).Value.ToString
                entD.CodigoConcepto = Me.dgvRegDia.Item(27, n).Value.ToString
                If entD.CodigoFile <> "395" Then
                    entD.CodigoGastoReparable = Me.dgvRegDia.Item(28, n).Value.ToString
                    entD.Cantidad = CType(Me.dgvRegDia.Item(30, n).Value.ToString, Decimal)
                End If
                'entD.NombreGastoReparable = Me.dgvRegDia.Item(29, n).Value.ToString
                'entD.VentaTipoCambio = Me.dgvRegDia.Item(18, n).Value.ToString
                'defecto
                entD.Cuenta1242 = ""
                'entD.CodigoCentroCosto = ""
                entD.EstadoRegContabDeta = ""
                entD.ImporteERegContabDeta = 0
                entD.CodigoFlujoCaja = ""
                rdd.nuevoRegContabDeta(entD)
            Next
        End If
    End Sub


    Sub Aceptar()
        '//
        If Me.operacion = 1 Or Me.operacion = 2 Then
            'Volver a traer el registro 
            ent.DatoCondicion1 = ent.ClaveRegContabCabe
            ent = rd.buscarRegContabExisPorClave(ent)
        End If

        ent.PeriodoRegContabCabe = Me.txtPeri.Text
        ent.CodigoEmpresa = Me.TxtCodEmp.Text
        ent.CodigoOrigen = Me.txtCodOri.Text
        ent.CodigoFile = Me.txtCodFil.Text
        '   ent.NumeroVoucherRegContabCabe = Me.txtNumVau.Text
        ent.DiaVoucherRegContabCabe = Me.txtDia.Text
        ent.FechaVoucherRegContabCabe = CType(Me.txtFecVau.Text, Date)
        ent.GlosaRegContabCabe = Me.txtGlosa.Text
        'defecto
        ent.CodigoAuxiliar = ""
        ent.TipoDocumento = ""
        ent.SerieDocumento = ""
        ent.NumeroDocumento = ""
        ent.FechaDocumento = Today.Date
        ent.VentaTipoCambio = 1
        ent.VentaEurTipoCambio = 1
        ent.CodigoModoPago = ""
        ent.CodigoCuentaBanco = ""
        ent.MonedaDocumento = "S/."
        'Igv
        ent.IgvPar = parEn.IgvPar
        ent.PrecioVtaRegContabCabe = 0
        ent.ExoneradoRegContabCabe = 0
        ent.IgvRegContabCabe = 0
        ent.ValorVtaRegContabCabe = 0
        ent.DetraccionRegContabCabe = ""
        ent.NumeroPapeletaRegContabCabe = ""
        ent.FechaDetraccionRegContabCabe = ""
        ent.RetencionRegContabCabe = ""
        ent.EstadoRegContabCabe = ""
        ent.CartaRegContabCabe = ""
        ent.DescripcionRegContabCabe = ""
        ent.VoucherIngresoRegContabCabe = ""

        ent.SumaDebeRegContabCabe = Varios.ObtieneSumaDebe(Me.dgvRegDia, ent.MonedaDocumento)
        ent.SumaHaberRegContabCabe = Varios.ObtieneSumaHaber(Me.dgvRegDia, ent.MonedaDocumento)
        ent.UltimoCorrelativo = (Me.dgvRegDia.Rows.Count - 1).ToString.PadLeft(4, CType("0", Char))

        'Datos por notas de credito
        ent.TipoDocumento1 = ""
        ent.SerieDocumento1 = ""
        ent.NumeroDocumento1 = ""
        ent.MonedaDocumento1 = ""
        ent.FechaDocumento1 = ""
        ent.FechaVencimiento = Today.Date
        ent.ModoCompra = ""

        '/Se graba o0 se modifica?
        Select Case Me.operacion

            Case 0
                'numero voucher autogenerado
                'Dim aut As New SuperEntidad
                'aut.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
                'aut.AnoVoucher = ent.PeriodoRegContabCabe.Substring(0, 4)
                'aut.CodigoMes = ent.PeriodoRegContabCabe.Substring(4, 2)
                'aut.CodigoFile = Me.txtCodFil.Text.Trim
                'ent.NumeroVoucherRegContabCabe = vou.obtenerVoucherAutogenerado(aut)
                ent.EstadoRegistro = "0" 'normal
                rd.nuevoRegContabCabe(ent)
                'eliminamos el detalle 
                rdd.eliminarRegContabDeta(ent)
                Me.GrabarDetalleRegContab()
                Me.pagarDocumentos()
                MsgBox("Registro Diario ingresado correctamente" + Chr(13) + "Numero Generado es: " + ent.NumeroVoucherRegContabCabe, MsgBoxStyle.Information)
                acc.LimpiarControles()
                'Limpiar la grilla
                Me.dgvRegDia.Rows.Clear()
                Txt.cursorAlUltimo(Me.txtDia)
            Case 4
                'numero voucher autogenerado
                Dim aut As New SuperEntidad
                aut.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
                aut.PeriodoRegContabCabe = Me.txtPeri.Text.Trim
                aut.AnoVoucher = aut.PeriodoRegContabCabe.Substring(0, 4)
                aut.CodigoMes = aut.PeriodoRegContabCabe.Substring(4, 2)
                aut.CodigoFile = Me.txtCodFil.Text.Trim
                ent.NumeroVoucherRegContabCabe = vou.obtenerVoucherAutogenerado(aut)

                rd.nuevoRegContabCabe(ent)
                'eliminamos el detalle 
                rdd.eliminarRegContabDeta(ent)
                Me.GrabarDetalleRegContab()
                MsgBox("Registro Diario ingresado correctamente", MsgBoxStyle.Information)
                acc.LimpiarControles()
                'Limpiar la grilla
                Me.dgvRegDia.Rows.Clear()
                Txt.cursorAlUltimo(Me.txtDia)

            Case 1
                'MODIFICAR LA CUENTA CORRIENTE CON EL DETALLE
                'ANTIGUO DE ESTE REGISTRO
                Me.ModificarCuentaCorriente()

                'modificar cabecera
                rd.modificarRegContab(ent)
                'Eliminamos el detalle antiguo
                rdd.eliminarRegContabDeta(ent)
                'grabamos el nuevo detalle
                Me.GrabarDetalleRegContab()
                Me.pagarDocumentos()
                MsgBox("Registro Diario modificado correctamente", MsgBoxStyle.Information)
                Me.Close()

            Case 2
                'Actualizar Cuenta Corriente
                Me.ModificarCuentaCorriente()
                'eliminar cabecera
                rd.eliminarRegContabFis(ent)
                rdd.eliminarRegContabDeta(ent)
                'Eliminamos el detalle antiguo
                ' pptoDe.eliminarPptoInternoDetalle(ent)
                '//Pregunta  pptoDe.eliminarPptoInternoDetalle(ent)
                'Me.GrabarDetalle()
                MsgBox("Registro Diario Eliminado correctamente", MsgBoxStyle.Information)
                Me.Close()
            Case 5
                'numero voucher autogenerado
                ent.EstadoRegistro = "0" 'normal
                rd.nuevoRegContabCabe(ent)
                'eliminamos el detalle 
                rdd.eliminarRegContabDeta(ent)
                Me.GrabarDetalleRegContab()
                MsgBox("Registro Diario ingresado correctamente" + Chr(13) + "Numero Generado es: " + ent.NumeroVoucherRegContabCabe, MsgBoxStyle.Information)
                Me.Close()
        End Select
        '/Actualizar y buscar el registro grabado
        Me.wRd.ActualizarVentana()
        ent.ClaveRegContabCabe = ent.CodigoEmpresa + ent.PeriodoRegContabCabe + ent.CodigoOrigen + ent.CodigoFile + ent.NumeroVoucherRegContabCabe
        Dgv.obtenerCursorActual(Me.wRd.DgvDia, ent.ClaveRegContabCabe, Me.wRd.lista)
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

        If Me.dgvRegDia.Rows.Count <> 1 Then
            For n As Integer = 0 To Me.dgvRegDia.Rows.Count - 2
                'Llenando el detalle
                cc.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
                cc.CodigoAuxiliar = Me.dgvRegDia.Item(2, n).Value.ToString
                cc.TipoDocumento = Me.dgvRegDia.Item(7, n).Value.ToString
                cc.SerieDocumento = Me.dgvRegDia.Item(9, n).Value.ToString
                cc.NumeroDocumento = Me.dgvRegDia.Item(10, n).Value.ToString
                Dim iCuenta As String = Me.dgvRegDia.Item(0, n).Value.ToString

                cc.ClaveDocumentoCuentaCorriente = cc.CodigoEmpresa + cc.CodigoAuxiliar + cc.TipoDocumento + cc.SerieDocumento + cc.NumeroDocumento
                '' Buscar Cuenta Corriente
                cc = ccte.buscarCuentaCorrienteExisPorClaveDoc(cc)
                If cc.ClaveDocumentoCuentaCorriente <> "" Then
                    If iCuenta = cc.CodigoCuentaPcge Then
                        Select Case cc.MonedaDocumento
                            Case "S/."

                                If cc.FlagSaldoNegativo = "0" Then 'no
                                    cc.ImportePagadoCuentaCorriente = cc.ImportePagadoCuentaCorriente + CType(Me.dgvRegDia.Item(5, n).Value.ToString, Decimal)
                                Else
                                    cc.ImportePagadoCuentaCorriente = cc.ImportePagadoCuentaCorriente - CType(Me.dgvRegDia.Item(5, n).Value.ToString, Decimal)
                                End If

                            Case "US$"

                                If cc.FlagSaldoNegativo = "0" Then
                                    cc.ImportePagadoCuentaCorriente = cc.ImportePagadoCuentaCorriente + CType(Me.dgvRegDia.Item(6, n).Value.ToString, Decimal)
                                Else
                                    cc.ImportePagadoCuentaCorriente = cc.ImportePagadoCuentaCorriente - CType(Me.dgvRegDia.Item(6, n).Value.ToString, Decimal)
                                End If

                            Case "EUR"

                                If cc.FlagSaldoNegativo = "0" Then
                                    cc.ImportePagadoCuentaCorriente = cc.ImportePagadoCuentaCorriente + CType(Me.dgvRegDia.Item(7, n).Value.ToString, Decimal)
                                Else
                                    cc.ImportePagadoCuentaCorriente = cc.ImportePagadoCuentaCorriente - CType(Me.dgvRegDia.Item(7, n).Value.ToString, Decimal)
                                End If

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
        lisRcd = rdd.obtenerDetalleRegContabPorClave(regDet)

        'RECORRER CADA DETALLE 
        For n As Integer = 0 To lisRcd.Count - 1
            regDet = lisRcd.Item(n)
            cueCorr.ClaveDocumentoCuentaCorriente = regDet.CodigoEmpresa + regDet.CodigoAuxiliar + regDet.TipoDocumento + regDet.SerieDocumento + regDet.NumeroDocumento
            cueCorr = ccte.buscarCuentaCorrienteExisPorClaveDoc(cueCorr)
            If cueCorr.ClaveDocumentoCuentaCorriente <> "" Then
                If regDet.CodigoCuentaPcge = cueCorr.CodigoCuentaPcge Then
                    Select Case cueCorr.MonedaDocumento
                        Case "S/."

                            If cueCorr.FlagSaldoNegativo = "0" Then
                                cueCorr.ImportePagadoCuentaCorriente = cueCorr.ImportePagadoCuentaCorriente - regDet.ImporteSRegContabDeta
                                cueCorr.SaldoCuentaCorriente = cueCorr.SaldoCuentaCorriente + regDet.ImporteSRegContabDeta
                            Else
                                cueCorr.ImportePagadoCuentaCorriente = cueCorr.ImportePagadoCuentaCorriente + regDet.ImporteSRegContabDeta
                                cueCorr.SaldoCuentaCorriente = cueCorr.SaldoCuentaCorriente - regDet.ImporteSRegContabDeta
                            End If
                            
                        Case "US$"

                            If cueCorr.FlagSaldoNegativo = "0" Then
                                cueCorr.ImportePagadoCuentaCorriente = cueCorr.ImportePagadoCuentaCorriente - regDet.ImporteDRegContabDeta
                                cueCorr.SaldoCuentaCorriente = cueCorr.SaldoCuentaCorriente + regDet.ImporteDRegContabDeta
                            Else
                                cueCorr.ImportePagadoCuentaCorriente = cueCorr.ImportePagadoCuentaCorriente + regDet.ImporteDRegContabDeta
                                cueCorr.SaldoCuentaCorriente = cueCorr.SaldoCuentaCorriente - regDet.ImporteDRegContabDeta
                            End If

                        Case "EUR"

                            If cueCorr.FlagSaldoNegativo = "0" Then
                                cueCorr.ImportePagadoCuentaCorriente = cueCorr.ImportePagadoCuentaCorriente - regDet.ImporteERegContabDeta
                                cueCorr.SaldoCuentaCorriente = cueCorr.SaldoCuentaCorriente + regDet.ImporteERegContabDeta
                            Else
                                cueCorr.ImportePagadoCuentaCorriente = cueCorr.ImportePagadoCuentaCorriente + regDet.ImporteERegContabDeta
                                cueCorr.SaldoCuentaCorriente = cueCorr.SaldoCuentaCorriente - regDet.ImporteERegContabDeta
                            End If

                    End Select
                    cueCorr.EstadoCuentaCorriente = "1"

                    '-------------------------------
                    'ACTUALIZAR EL FLAGSALDONEGATIVO
                    '-------------------------------
                    cueCorr.FlagSaldoNegativo = Me.ActualizarFalgSaldoNegativo(regDet.ClaveRegContabDeta, cueCorr)
                    ccte.modificarCuentaCorriente(cueCorr)
                End If
                
            End If
        Next
    End Sub

    Function ActualizarFalgSaldoNegativo(ByVal pClaveRegContaDeta As String, ByVal pCueCor As SuperEntidad) As String

        'valor resultado
        Dim iValor As String = "0"

        'si es la operacion de eliminar , entonces el flag es cero
        If Me.operacion = 2 Then Return iValor

        'primero si su flag esta en cero entonces sale del proceso
        If pCueCor.FlagSaldoNegativo = "0" Then Return iValor

        'primero saber si esta clave no existe en la grilla
        Dim iIndiceFila As Integer = Dgv.ObtenerIndiceFila(Me.dgvRegDia, "Column27", pClaveRegContaDeta)

        'si sale -1 quiere decir que no la encontro
        If iIndiceFila = -1 Then Return iValor

        'devolver
        Return pCueCor.FlagSaldoNegativo

    End Function

#End Region

    Private Sub WEditarPptoInterno_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Me.Text = "Eliminar Registro Gastos" Then
            Me.Aceptar()
            Exit Sub
        End If

        If acc.CamposObligatorios = False Then
            Exit Sub
        Else

            If Me.txtDebeS.Text = Me.txtHaberS.Text Then
                'Validadando el correlativo del voucher solo para adicionar
                If Me.operacion = 0 Or Me.operacion = 5 Then
                    If Me.EsNumeroVoucherCorrecto = False Then Exit Sub
                End If
                Me.Aceptar()
                Me.wRd.wImpVoucher()
            Else
                Dim rpta As Integer = MsgBox("Deseas grabar el registro sin cuadrar el haber/debe", MsgBoxStyle.YesNo)
                If rpta = MsgBoxResult.Yes Then
                    'Validadando el correlativo del voucher solo para adicionar
                    If Me.operacion = 0 Or Me.operacion = 5 Then
                        If Me.EsNumeroVoucherCorrecto = False Then Exit Sub
                    End If
                    Me.Aceptar()
                    Me.wRd.wImpVoucher()
                Else
                    Exit Sub
                End If
            End If

        End If

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If Me.Text = "Visualizar Registro Diario" Then
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


#Region "Mostrar formulario lista"
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

    End Sub

#End Region

#Region "Calculos"

    Private Sub txtDia_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDia.Validated
        If Me.txtPeri.Text <> "" Then
            If Me.txtDia.Text.Trim <> "" Then
                Dim periodo As String = Me.txtPeri.Text.Trim
                Dim dia As String = Me.txtDia.Text.Trim
                If Varios.LimiteMinMaxDeValores(dia, 1, 31) = True Then
                    dia = Varios.FormatoDia(dia)
                    Me.txtDia.Text = dia
                    If periodo.Substring(4, 2) = "00" Or periodo.Substring(4, 2) = "13" Then
                        If periodo.Substring(4, 2) = "00" Then
                            Me.txtFecVau.Text = dia + "/01" + "/" + periodo.Substring(0, 4)
                        Else
                            Me.txtFecVau.Text = dia + "/12" + "/" + periodo.Substring(0, 4)
                        End If
                    Else
                        Me.txtFecVau.Text = dia + "/" + periodo.Substring(4, 2) + "/" + periodo.Substring(0, 4)
                    End If

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

    Sub ImportesDebeHaber()
        'indice debe/haber 4
        'indice importe soles 5
        'indice importe dolares 6
        Me.txtHaberS.Text = "0.00"
        Me.txtDebeS.Text = "0.00"
        Me.txtHaberD.Text = "0.00"
        Me.txtDebeD.Text = "0.00"
        Dim numreg As Integer = Me.dgvRegDia.Rows.Count - 2
        Dim deha As String
        Dim impS, impD As Decimal
        For n As Integer = 0 To numreg
            deha = Me.dgvRegDia.Item(4, n).Value.ToString
            impS = CType(Me.dgvRegDia.Item(5, n).Value.ToString, Decimal)
            impD = CType(Me.dgvRegDia.Item(6, n).Value.ToString, Decimal)
            Select Case deha
                Case "Haber"
                    Me.txtHaberS.Text = (CType(Me.txtHaberS.Text, Decimal) + impS).ToString
                    Me.txtHaberD.Text = (CType(Me.txtHaberD.Text, Decimal) + impD).ToString
                Case "Debe"
                    Me.txtDebeS.Text = (CType(Me.txtDebeS.Text, Decimal) + impS).ToString
                    Me.txtDebeD.Text = (CType(Me.txtDebeD.Text, Decimal) + impD).ToString

            End Select
        Next

    End Sub


#End Region


#Region "Para Items"
    Sub NuevoItem()
        'VALIDAR PRIMERO QUE SE ESCRIBA UN FILE
        Dim iFile As String = Me.txtCodFil.Text.Trim
        If iFile = "" Then
            MsgBox("Primero debes escribir un file", MsgBoxStyle.Information, "File")
            Me.txtCodFil.Focus()
            Exit Sub
        Else
            'VALIDAR EL FILE 395 SOLO PARA LA EMPRESA 001 S&Z
            If SuperEntidad.xCodigoEmpresa = "001" And iFile = "395" Then
                Dim win1 As New WDetalleRegDiario1
                win1.wRegDia = Me
                Me.AddOwnedForm(win1)
                win1.NuevaVentana()
            Else
                Dim win1 As New WDetalleRegDiario
                win1.wRegDia = Me
                Me.AddOwnedForm(win1)
                win1.NuevaVentana()
            End If
        End If

        'Dim win1 As New WDetalleRegDiario
        'win1.wRegDia = Me
        'Me.AddOwnedForm(win1)
        'win1.NuevaVentana()
    End Sub

    Sub ModificarItem()
        'VALIDAR PRIMERO QUE SE ESCRIBA UN FILE
        Dim iFile As String = Me.txtCodFil.Text.Trim
        'VALIDAR EL FILE 395 SOLO PARA LA EMPRESA 001 S&Z
        If SuperEntidad.xCodigoEmpresa = "001" And iFile = "395" Then
            Dim win1 As New WDetalleRegDiario1
            win1.wRegDia = Me
            Me.AddOwnedForm(win1)
            win1.ModificarVentana()
        Else
            Dim win1 As New WDetalleRegDiario
            win1.wRegDia = Me
            Me.AddOwnedForm(win1)
            win1.ModificarVentana()
        End If

        'Dim win1 As New WDetalleRegDiario
        'win1.wRegDia = Me
        'Me.AddOwnedForm(win1)
        'win1.ModificarVentana()
    End Sub

    Sub EliminarItem()

        'VALIDAR PRIMERO QUE SE ESCRIBA UN FILE
        Dim iFile As String = Me.txtCodFil.Text.Trim
        'VALIDAR EL FILE 395 SOLO PARA LA EMPRESA 001 S&Z
        If SuperEntidad.xCodigoEmpresa = "001" And iFile = "395" Then
            Dim win1 As New WDetalleRegDiario1
            win1.wRegDia = Me
            Me.AddOwnedForm(win1)
            win1.EliminaVentana()
        Else
            Dim win1 As New WDetalleRegDiario
            win1.wRegDia = Me
            Me.AddOwnedForm(win1)
            win1.EliminaVentana()
        End If

        'Dim win1 As New WDetalleRegDiario
        'win1.wRegDia = Me
        'Me.AddOwnedForm(win1)
        'win1.EliminaVentana()

    End Sub


    'Public Function sumaImportes() As Decimal
    '    Dim sumImp As Decimal = 0
    '    If Me.dgvRegCom.RowCount = 1 Then
    '        Return sumImp
    '    Else

    '        For n As Integer = 0 To Me.dgvRegCom.RowCount - 2
    '            Dim valor As String = Me.dgvRegCom.Item(5, n).Value.ToString
    '            sumImp = sumImp + CType(valor, Decimal)

    '            'If valor = "" Then

    '            'End If

    '        Next
    '        Return sumImp
    '    End If

    'End Function

#End Region





    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim numReg As Integer = Me.dgvRegDia.Rows.Count
        If numReg = 0 Or numReg = 1 Then
            Exit Sub
        Else
            Dim indFil As Integer = Me.dgvRegDia.CurrentRow.Index
            If indFil = numReg - 1 Then
                Exit Sub
            Else
                Me.EliminarItem()
            End If
        End If
    End Sub


    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Me.NuevoItem()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Dim numReg As Integer = Me.dgvRegDia.Rows.Count
        If numReg = 0 Or numReg = 1 Then
            Exit Sub
        Else
            Dim indFil As Integer = Me.dgvRegDia.CurrentRow.Index
            If indFil = numReg - 1 Then
                Exit Sub
            Else
                Me.ModificarItem()
            End If
        End If
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
                    'parEn = par.buscarParametroExis(parEn)
                    If p >= PeriodoActual Then
                        MsgBox("Solo se puede digitar como maximo el periodo anterior de hoy", MsgBoxStyle.Information, "")
                        Me.txtPeri.Text = ""
                        Me.txtPeri.Focus()
                    Else
                        Dim dia As String = Me.txtDia.Text.Trim
                        If dia <> String.Empty Then
                            dia = Varios.FormatoDia(dia)
                            'Me.txtDia.Text = dia
                            Me.txtFecVau.Text = dia + "/" + Me.txtPeri.Text.Substring(4, 2) + "/" + Me.txtPeri.Text.Substring(0, 4)
                            '' Es Fecha Valida
                            If Varios.ValidaDia(Me.txtFecVau.Text) = False Then
                                Me.txtFecVau.Text = String.Empty
                                Me.txtDia.Focus()
                            End If
                        End If

                    End If
                End If
            End If
        End If

    End Sub
End Class