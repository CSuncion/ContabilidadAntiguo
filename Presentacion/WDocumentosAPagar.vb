Imports Entidad
Imports Negocio

Public Class WDocumentosAPagar

    Public ent, entpar, ticen As New SuperEntidad
    Public acc As New Accion
    Public lista, Lista1 As New List(Of SuperEntidad)
    Public cbco As New RegContabCabeRN
    Public ccte As New CuentaCorrienteRN
    Public emp As New EmpresaRN
    Public tic As New TipoCambioRN
    Public cam As New CamposEntidad
    Public titulo As String = "CajaBanco"
    Public par As New ParametroRN
    Public PeriodoActual As String
    Public MonPag As Decimal
    Public operacion As Integer  '0=agregar , 1=modificar , 2=eliminar , 3=visualizar , 4=Manual'


#Region "Metodos"

#Region "Varios"

    Sub NuevaVentana()
        '/
        acc.listaCtrls = Me.ListaControles
        acc.PasaFoco()
        acc.FomatoDato()
        acc.PasarCursor()
        acc.Teclazo()
        acc.Valida()
        Me.Show()
        Me.PorDefecto()
        entpar = par.buscarParametroExis(entpar)
        '/
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
        Me.txtCodOri.Text = "2"
        Me.txtNomOri.Text = "EGRESOS"
        Me.txtCodFil.Focus()
    End Sub

    Sub TraerTipoCambio()
        'traer tipo de cambio
        Dim fecvau As DateTime = CType(Me.txtFecVau.Text, DateTime)  ''Pantalla es como varcher y cambia datetime
        ticen.DatoCondicion1 = fecvau.Year.ToString + "/" + fecvau.Month.ToString + "/" + fecvau.Day.ToString
        ticen = tic.buscarTipoCambioExisPorFecha(ticen)
        If ticen.AnoTipoCambio = "" Then
            MsgBox("El tipo de cambio no existe", MsgBoxStyle.Information)
            Me.txtTipCam.Text = "1.000"
            Me.TxtTipCam1.Text = "1.000"
            Me.txtDolEur.Text = "1.000"
        Else
            Me.txtTipCam.Text = ticen.VentaTipoCambio.ToString
            Me.TxtTipCam1.Text = ticen.VentaEurTipoCambio.ToString
            Me.txtDolEur.Text = ticen.DolarEuroTipoCambio.ToString
        End If
    End Sub

    Sub MostrarTituloDocumentosPendientes()
        '/
        Dim titulo As String = "DOCUMENTOS PENDIENTES DEL AUXILIAR : " + Me.txtCodAux.Text.ToUpper
        'numero de letras pendientes en la grilla
        Dim numDocPen As Integer = Me.DgvDocPen.Rows.Count
        titulo = titulo + " / NUMERO : " + numDocPen.ToString
        Me.lblTitLetPen.Text = titulo
        '/
    End Sub

    Sub MostrarDocumentosDelAuxiliar()


        Dim CodAux As String = Me.txtCodAux.Text.Trim

        'SI NO SE SELECCIONO NINGUN AUXILIAR
        'SALE DEL PROCESO
        If CodAux = "" Then Exit Sub

        Dim obj As New SuperEntidad
        obj.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        obj.CodigoAuxiliar = CodAux

        'SI SE ELIGIO AL AUXILIAR DE CODIGO (11111111111)
        'ENTONCES SE DEBE MOSTRAR TODOS LOS DOCUMENTOS PENDIENTES 
        'DE TODOS LOS AUXILIARES SINO LOS DOCUMENTOS PENDIENTES
        'SOLO DE ESE AUXILIAR QUE SE ELIGIO
        If CodAux = "11111111111" Then
            lista = ccte.ListarDocumentosAPagarXEmpresaYPendientes(obj)
        Else
            lista = ccte.ListarDocumentosAPagarXEmpresaXAuxiliarYPendientes(obj)
        End If



        Dgv.refrescarFuenteDatosGrilla(Me.DgvDocPen, lista)
        '/Creando las columnas
        Dgv.asignarColumnaCheckBox(Me.DgvDocPen, "Seleccionar", "Seleccionar", 100)
        Dgv.asignarColumnaText(Me.DgvDocPen, cam.CodAux, "RUC", 90)
        Dgv.asignarColumnaText(Me.DgvDocPen, cam.DesAux, "Razon Social", 200)
        Dgv.asignarColumnaText(Me.DgvDocPen, cam.CodTipDoc, "TD", 60)
        Dgv.asignarColumnaText(Me.DgvDocPen, cam.NomTipDoc, "Nombre", 70)
        Dgv.asignarColumnaText(Me.DgvDocPen, cam.SerDoC, "Serie", 40)
        Dgv.asignarColumnaText(Me.DgvDocPen, cam.NumDoc, "Numero", 100)
        Dgv.asignarColumnaText(Me.DgvDocPen, cam.FecDoc, "Fecha", 80)
        Dgv.asignarColumnaText(Me.DgvDocPen, cam.MonDoc, "Moneda", 60)
        Dgv.AsignarColumnaTextNumerico(Me.DgvDocPen, cam.SalCtaCte, "Saldo", 90, 2)
        Dgv.asignarColumnaText(Me.DgvDocPen, cam.CodCtaPcge, "Cuenta", 60)
        Dgv.AsignarColumnaTextNumerico(Me.DgvDocPen, cam.VenTipCam, "TC $", 80, 3)
        Dgv.AsignarColumnaTextNumerico(Me.DgvDocPen, cam.VenEurTipCam, "TC Eur", 80, 3)
        Dgv.asignarColumnaText(Me.DgvDocPen, cam.ClaveCtaCte, "Clave", 150)

        Me.DgvDocPen.Focus()

        'DESMARCAR CHECK DE DGV
        Me.DesmarcarTodos()

        '' Titulo Contrato
        Me.MostrarTituloDocumentosPendientes()

        'HABILITAR BOTONES PARA CHEQUEAR
        Me.HabilitarBotonesParaCheck()

        'PONER CURSOR DESPUES DE SELECCIONAR UN CONTRATO
        If Me.btnTodos.Enabled = True Then
            Me.btnTodos.Focus()
        Else
            Me.txtCodAux.Focus()
        End If
        '/
    End Sub

    Sub HabilitarBotonesParaCheck()
        '/
        Dim numReg As Integer = Me.DgvDocPen.Rows.Count
        If numReg = 0 Then
            Me.btnTodos.Enabled = False
            Me.btnNinguno.Enabled = False
        Else
            Me.btnTodos.Enabled = True
            Me.btnNinguno.Enabled = True
        End If
        '/
    End Sub

    Function HayDocumentosXPagar() As Boolean
        Dim contador As Integer = 0
        Dim valor As String = ""
        For n As Integer = 0 To Me.DgvDocPen.Rows.Count - 1
            valor = Me.DgvDocPen.Item(0, n).Value.ToString
            If valor = "True" Then
                contador += 1
            End If
        Next
        If contador = 0 Then
            MsgBox("No hay Documentos seleccionadas , debes chequear en la columna seleccionar ", MsgBoxStyle.Exclamation, "Documentos")
            Return False
        Else
            Return True
        End If

    End Function

    Sub EnvioAlBanco()

        'DEBES ELEGIR UN AUXILIAR 
        If Me.txtCodAux.Text.Trim = "" Then
            MsgBox("Debes elegir un Auxiliar", MsgBoxStyle.Exclamation, "Auxiliares")
            Exit Sub
        End If

        'SI NO HAY LETRAS CHEQUEADAS ENTONCES TERMINA PROCESO
        If Me.HayDocumentosXPagar = False Then Exit Sub

        'LLENAR EN UNA LISTA SOLO LOS MARCADOS
        Me.LlevarDocumentosMarcados()

        'VER SI ES PERMITIDO EL PAGO
        If Me.EsPagoPermitido = False Then Exit Sub

        Me.adicionar()

    End Sub

    Sub adicionar()
        '/
        Dim win As New WEditarDocumentosAPagar
        win.wCtaCte1 = Me
        win.operacion = 0
        Me.AddOwnedForm(win)
        'Posicion de la columna de numero de letra
        win.ventanaAdicionar()

        '/
    End Sub

    Sub MarcarTodos()
        Dim n As Integer = Me.DgvDocPen.Rows.Count - 1
        If n = -1 Then
            MsgBox("No hay Documentos para marcar", MsgBoxStyle.Exclamation, "Documentos")
            Exit Sub
        End If
        For c As Integer = 0 To n
            Me.DgvDocPen.Item(0, c).Value = True
        Next
    End Sub

    Sub DesmarcarTodos()
        Dim n As Integer = Me.DgvDocPen.Rows.Count - 1
        If n = -1 Then
            MsgBox("No hay Documentos para desmarcar", MsgBoxStyle.Exclamation, "Documentos")
            Exit Sub
        End If
        'EL FOCO DEBE TENERLO UNA CELDA DE LA GRILLA
        Me.DgvDocPen.CurrentCell = Me.DgvDocPen.Item(1, 0)
        For c As Integer = 0 To n
            Me.DgvDocPen.Item(0, c).Value = False
        Next
    End Sub

    Private Sub txtDia_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDia.Validated
        If Me.txtPeri.Text <> "" Then
            If Me.txtDia.Text.Trim <> "" Then
                'Dim wmes As String
                Dim periodo As String = Me.txtPeri.Text.Trim
                Dim dia As String = Me.txtDia.Text.Trim
                If Varios.LimiteMinMaxDeValores(dia, 1, 31) = True Then
                    dia = Varios.FormatoDia(dia)
                    Me.txtDia.Text = dia
                    Me.txtFecVau.Text = dia + "/" + periodo.Substring(4, 2) + "/" + periodo.Substring(0, 4)

                    '' Es Fecha Valida
                    If Varios.ValidaDia(Me.txtFecVau.Text) = False Then
                        Me.txtFecVau.Text = String.Empty
                        Me.txtDia.Focus()
                        Exit Sub
                    End If
                    Me.TraerTipoCambio()
                Else
                    MsgBox("El dia debe estar entre en 1 y 31", MsgBoxStyle.Information)
                    Me.txtDia.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub txtCont_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodAux.Validated
        Me.MostrarDocumentosDelAuxiliar()
    End Sub

    Sub LlevarDocumentosMarcados()
        Dim valor As String = ""
        Lista1.Clear()
        For n As Integer = 0 To Me.DgvDocPen.Rows.Count - 1
            'SOLO GRABAR LAS QUE ESTAN MARCADAS
            valor = Me.DgvDocPen.Item(0, n).Value.ToString
            If valor = "True" Then
                Dim obj As New SuperEntidad
                obj.CodigoAuxiliar = Me.DgvDocPen.Item(cam.CodAux, n).Value.ToString
                obj.DescripcionAuxiliar = Me.DgvDocPen.Item(cam.DesAux, n).Value.ToString
                obj.TipoDocumento = Me.DgvDocPen.Item(cam.CodTipDoc, n).Value.ToString
                obj.NombreDocumento = Me.DgvDocPen.Item(cam.NomTipDoc, n).Value.ToString
                obj.SerieDocumento = Me.DgvDocPen.Item(cam.SerDoC, n).Value.ToString
                obj.NumeroDocumento = Me.DgvDocPen.Item(cam.NumDoc, n).Value.ToString
                obj.FechaDocumento = CType(Me.DgvDocPen.Item(cam.FecDoc, n).Value.ToString, Date)
                obj.MonedaDocumento = Me.DgvDocPen.Item(cam.MonDoc, n).Value.ToString
                obj.SaldoCuentaCorriente = CType(Me.DgvDocPen.Item(cam.SalCtaCte, n).Value, Decimal)
                obj.CodigoCuentaPcge = Me.DgvDocPen.Item(cam.CodCtaPcge, n).Value.ToString
                obj.VentaTipoCambio = CType(Me.DgvDocPen.Item(cam.VenTipCam, n).Value, Decimal)
                obj.VentaEurTipoCambio = CType(Me.DgvDocPen.Item(cam.VenEurTipCam, n).Value, Decimal)
                obj.ClaveCuentaCorriente = Me.DgvDocPen.Item(cam.ClaveCtaCte, n).Value.ToString

                'TRES VALORES ADICIONALES PARA CALCULAR EL MONTO A PAGAR

                'MONTO EN SOLES DEL DOCUMENTO AL TIPO DE CAMBIO DEL DOCUMENTO
                Select Case obj.MonedaDocumento
                    Case "S/."
                        obj.ImporteSolRegContabCabe = obj.SaldoCuentaCorriente
                    Case "US$"
                        obj.ImporteSolRegContabCabe = obj.SaldoCuentaCorriente * obj.VentaTipoCambio
                    Case "EUR"
                        obj.ImporteSolRegContabCabe = obj.SaldoCuentaCorriente * obj.VentaEurTipoCambio
                End Select


                'MONTO MONEDA Y MONTO SOLES
                Dim iMontoMoneda As String = ""
                Dim iMontoSoles As String = ""

                'OBTENER LA MONEDA DE LA CABECERA CAJA Y BANCOS
                Dim iMonedaCb As String = Rbt.radioActivo(Me.gbMoneda).Text

                'OBTENER TIPOS DE CAMBIO DE LA CABECERA
                Dim iTcDol As Decimal = CType(Me.txtTipCam.Text, Decimal)
                Dim iTcEur As Decimal = CType(Me.TxtTipCam1.Text, Decimal)

                'OBTENER LA MONEDA DEL DOCUMENTO
                Dim iMonedaDcto As String = obj.MonedaDocumento

                Select Case iMonedaCb

                    Case "S/."

                        Select Case iMonedaDcto

                            Case "S/."
                                iMontoMoneda = obj.SaldoCuentaCorriente.ToString
                                iMontoSoles = obj.SaldoCuentaCorriente.ToString

                            Case "US$"
                                iMontoMoneda = Varios.numeroConDosDecimal((obj.SaldoCuentaCorriente * iTcDol).ToString)
                                iMontoSoles = iMontoMoneda

                            Case "EUR"
                                iMontoMoneda = Varios.numeroConDosDecimal((obj.SaldoCuentaCorriente * iTcEur).ToString)
                                iMontoSoles = iMontoMoneda

                        End Select

                    Case "US$"

                        Select Case iMonedaDcto

                            Case "S/."
                                iMontoMoneda = Varios.numeroConDosDecimal((obj.SaldoCuentaCorriente / iTcDol).ToString)
                                iMontoSoles = obj.SaldoCuentaCorriente.ToString

                            Case "US$"
                                iMontoMoneda = obj.SaldoCuentaCorriente.ToString
                                iMontoSoles = Varios.numeroConDosDecimal((obj.SaldoCuentaCorriente * iTcDol).ToString)

                            Case "EUR"
                                iMontoMoneda = "1.00"
                                iMontoSoles = "1.00"

                        End Select

                    Case "EUR"

                        Select Case iMonedaDcto

                            Case "S/."
                                iMontoMoneda = Varios.numeroConDosDecimal((obj.SaldoCuentaCorriente / iTcEur).ToString)
                                iMontoSoles = obj.SaldoCuentaCorriente.ToString

                            Case "US$"
                                iMontoMoneda = "1.00"
                                iMontoSoles = "1.00"

                            Case "EUR"
                                iMontoMoneda = obj.SaldoCuentaCorriente.ToString
                                iMontoSoles = Varios.numeroConDosDecimal((obj.SaldoCuentaCorriente * iTcEur).ToString)

                        End Select
                End Select

                obj.MontoMoneda = CType(iMontoMoneda, Decimal)
                obj.MontoSoles = CType(iMontoSoles, Decimal)
                Lista1.Add(obj)

            End If
        Next
    End Sub



    Function EsPagoPermitido() As Boolean
        'AQUI COMO MINIMO HAY 1 O MAS DETALLES
        'OBTENER LA MONEDA DEL DOCUMENTO DE PAGO O COBRANZA
        Dim iMonedaCb As String = Rbt.radioActivo(Me.gbMoneda).Text
        'SEGUN MONEDA
        Select Case iMonedaCb
            Case "S/." : Return True

            Case "US$"
                'EL DETALLE NO DEBE CONTENER NINGUN EURO
                For Each xobj As SuperEntidad In Me.Lista1
                    If xobj.MonedaDocumento = "EUR" Then
                        MsgBox("Si la moneda de pago es dolar ningun documento a pagar debe ser euro", MsgBoxStyle.Exclamation, "moneda")
                        Return False
                    End If
                Next
                'SI NO ENCONTRO NINGUN EURO ENTONCES MANDA VERDADERO
                Return True

            Case "EUR"
                'EL DETALLE NO DEBE CONTENER NINGUN DOLAR
                For Each xobj As SuperEntidad In Me.Lista1
                    If xobj.MonedaDocumento = "US$" Then
                        MsgBox("Si la moneda de pago es euro ningun documento a pagar debe ser dolar", MsgBoxStyle.Exclamation, "moneda")
                        Return False
                    End If
                Next
                'SI NO ENCONTRO NINGUN EURO ENTONCES MANDA VERDADERO
                Return True

        End Select

    End Function

#End Region

#Region "Mostrar Form Lista"

    Private Sub txtCodAux_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodAux.KeyDown
        If Me.txtCodAux.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarAuxiliar
                win.wDocXPag = Me
                Me.AddOwnedForm(win)
                win.tabla = "Proveedor/ClienteProveedor"
                win.titulo = "AUXILIARES"
                win.txt1 = Me.txtCodAux
                win.txt2 = Me.txtNomAux
                win.ctrlFoco = Me.DgvDocPen
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
                win.ent.CodigoFile = "2"
                win.txt1 = Me.txtCodFil
                win.txt2 = Me.txtNomFil
                win.ctrlFoco = Me.txtDia
                win.NuevaVentana()
            End If
        End If

    End Sub

#End Region

#Region "Buscar Por Codigo"


    Private Sub txtCodAux_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodAux.Validating
        If Me.operacion = 0 Or Me.operacion = 1 Or Me.operacion = 4 Then
            Dim ope As New OperaWin : ope.txt1 = Me.txtCodAux : ope.txt2 = Me.txtNomAux
            ope.MostrarCodigoDescripcionDeAuxiliar("Proveedor/ClienteProveedor", "AUXILIARES", e)
            Me.DgvDocPen.Focus()

        End If
    End Sub
    Private Sub txtCodFil_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodFil.Validating
        If Me.operacion = 0 Or Me.operacion = 4 Then
            If Me.txtCodFil.Text.Trim <> "" Then
                Dim codOri As String = Me.txtCodFil.Text.Trim.Substring(0, 1)
                If codOri = "2" Then
                    Dim ope As New OperaWin : ope.txt1 = Me.txtCodFil : ope.txt2 = Me.txtNomFil
                    ope.MostrarCodigoDescripcionDeFile("Files", e)
                Else
                    MsgBox("El Codigo File no existe", MsgBoxStyle.Information)
                    Me.txtCodFil.Text = String.Empty
                    Me.txtNomFil.Text = String.Empty
                    Me.txtCodFil.Focus()
                End If
            End If
        End If

    End Sub

#End Region

#End Region

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnEjecuta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.MostrarDocumentosDelAuxiliar()
    End Sub

    Private Sub BtnAcepta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAcepta.Click
        If acc.CamposObligatorios = False Then
            Exit Sub
        Else
            Me.EnvioAlBanco()
        End If
    End Sub

    Private Sub btnTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTodos.Click
        Me.MarcarTodos()
    End Sub

    Private Sub btnNinguno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNinguno.Click
        Me.DesmarcarTodos()
    End Sub


    Private Sub txtCodAux_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodAux.TextChanged

    End Sub
End Class