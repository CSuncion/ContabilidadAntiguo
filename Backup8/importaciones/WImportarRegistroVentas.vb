Option Explicit On
Option Strict On
Imports Entidad
Imports Negocio
Imports System
Imports System.IO
Imports System.Threading

Public Class WImportarRegistroVentas
    Public ent As New SuperEntidad
    Public lista As New List(Of SuperEntidad)
    Public MovCon As New RegContabDetaRN
    Public acc As New Accion


    Dim cam As New CamposEntidad
    Dim iLisRegVta As New List(Of SuperEntidad)

#Region "Metodos"
    Sub InicializaVentana()
        ''Para los eventos de controles
        'acc.listaCtrls = Me.ListaControles
        'acc.PasaFoco()
        'acc.FomatoDato()
        'acc.PasarCursor()
        'acc.Teclazo()
        'acc.Valida()
        Me.ValoresXDefecto()
        Me.Show()
    End Sub

    Sub ValoresXDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.txtNomEmp.Text = SuperEntidad.xRazonSocial
        Me.TxtPeri.Text = SuperEntidad.xPeriodoEmpresa
        'Me.ActualizarDgvTab()
    End Sub

    Sub NuevaVentana()
        '//
        Me.Show()
        Me.ValoresXDefecto()
        Me.Button1.Focus()
        '\\
    End Sub

    Sub MostrarRutaArchivo()
        Dim iArchivo As New OpenFileDialog
        iArchivo.DefaultExt = "*.txt"
        iArchivo.Filter = "Texto(*.txt)|*.txt"
        If iArchivo.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Return
        Else
            Me.txtRuta.Text = iArchivo.FileName
        End If
    End Sub

    Sub ActualizarVentana()
        '//
        Me.ActualizarDgvTab()
        Dgv.actualizarBarraEstado(Me.sst1, Me.DgvPcg)
        'acc.EstadoBotonesPorGrilla(Me.ListaBotones, Me.DgvPcg)
        'acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvPcg)
        Dgv.pintarColumnaDgv(Me.DgvPcg, ent.CampoOrden)
        '   Me.permisoVentana()
        '\\
    End Sub

    Sub ActualizarDgvTab()

        '//
        '/Refrescando el DataSource de DgvUsu
        ent.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        'lista = iLisRegVta

        '/Refrescando el DataSource de DgvUsu
        ' Dgv.refrescarFuenteDatosGrilla(Me.DgvPcg, lista)
        Dgv.refrescarFuenteDatosGrilla(Me.DgvPcg, iLisRegVta)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvPcg, cam.CodEmp, "Empresa", 30)
        Dgv.asignarColumnaText(Me.DgvPcg, cam.PeriodoRCC, "Periodo", 40)
        Dgv.asignarColumnaText(Me.DgvPcg, cam.CodOriRC, "Origen", 50)
        Dgv.asignarColumnaText(Me.DgvPcg, cam.CodFilRC, "File", 70)
        Dgv.asignarColumnaText(Me.DgvPcg, cam.NumVouRCC, "Numero", 70)
        Dgv.asignarColumnaText(Me.DgvPcg, cam.CodIngEgr, "I/E", 70)
        Dgv.asignarColumnaText(Me.DgvPcg, cam.CodCta1242, "Cta", 70)
        Dgv.asignarColumnaText(Me.DgvPcg, cam.Doc, "TD", 70)
        Dgv.asignarColumnaText(Me.DgvPcg, cam.SerDoC, "Serie", 70)
        Dgv.asignarColumnaText(Me.DgvPcg, cam.NumDoc, "N°Doc", 70)
        Dgv.asignarColumnaText(Me.DgvPcg, cam.CodCta1242, "Cta", 50)
        Dgv.asignarColumnaText(Me.DgvPcg, cam.FecDoc, "Fecha", 70)
        Dgv.asignarColumnaText(Me.DgvPcg, cam.CodAux, "Auxiliar", 80)
        Dgv.asignarColumnaText(Me.DgvPcg, cam.ClaveRCC, "Clave C", 70)
        Dgv.asignarColumnaText(Me.DgvPcg, cam.ClaveRCD, "Clave D", 70)
        Dgv.AsignarColumnaTextNumerico(Me.DgvPcg, cam.ValVtasRCC, "Valor Vta", 60, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvPcg, cam.ValVtasRCC, "Valor Vta", 60, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvPcg, cam.PreVtaRCC, "Precio Vta", 60, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvPcg, cam.ImpSRCD, "Monto", 80, 2)
        ' Dgv.asignarColumnaTextVis(Me.DgvPcg, cam.ClaveCtaCte, "Clave", 80, 0)
        '//
    End Sub

    Function ConvertirTextoARegistroVentas() As List(Of SuperEntidad)
        'CREANDO ObJETOS DE NEGOCIO
        Dim iRccRN As New RegContabCabeRN
        Dim iRcdRN As New RegContabDetaRN

        'LISTA DONDE SE ARMARAN CADA REGISTRO CONTABLE Y SU DETALLE
        'UNO A UNO
        Dim iLisRegVta As New List(Of SuperEntidad)

        'CREANDO UN OBJETO QUE LEA LINEA A LINEA EL ARCHIVO DE TEXTO ELEGIDO
        Dim iArchivo As New StreamReader(Me.txtRuta.Text.Trim)
        Dim iLineaActual As String = "x"
        Dim wLongitud As Integer = 0
        Dim iCorrelativo As Integer = 0
        Dim wPeriodo As String = Me.TxtPeri.Text.Trim
        Dim wCuenta As String

        While (iLineaActual <> "")

            iLineaActual = iArchivo.ReadLine()
            If iLineaActual <> Nothing Then
                If iLineaActual.Length <> 0 Then

                    'PREGUNTAR SI EL PRIMER CARACTER DE ESTA LINEA ACTUAL ES "C"
                    If iLineaActual.Substring(0, 1) = "C" Then
                        'CONVERTIR ESTA LINEA EN REGISTRO CONTABLE CABECERA
                        Dim iRccEN As New SuperEntidad
                        iRccEN = iRccRN.ConvertirTextoARegistroVentaCabe(iLineaActual, wPeriodo, wCuenta)
                        'PASAR ESTA CABECERA A LA LISTA iLisAsi
                        iLisRegVta.Add(iRccEN)
                    Else
                        'CONVERTIR ESTA LINEA EN REGISTRO CONTABLE DETALLE
                        Dim iRcdEN As New SuperEntidad
                        'wLongitud = iLineaActual.Trim.Length
                        'If iLineaActual.Substring(1, 6) >= "000693" Then
                        '    MsgBox(iLineaActual + " -- " + wLongitud.ToString, MsgBoxStyle.DefaultButton1, "Ver detalle")
                        'End If
                        'wLineaActual = iLineaActual.Trim.Substring(0, wLongitud)
                        'iRcdEN = iRcdRN.ConvertirTextoARegistroVentaDeta(iLineaActual)
                        iRcdEN = iRcdRN.ConvertirTextoARegistroVentaDeta(iLineaActual, wPeriodo)
                        'PASAR ESTA CABECERA A LA LISTA iLisAsi
                        If iLineaActual.Substring(0, 1) = "D" Then
                            iLisRegVta.Add(iRcdEN)
                        End If
                    End If

                End If
            End If
        End While
        Return iLisRegVta
    End Function

    Sub EliminarRegistrosContablesFueraDeRango()
        Dim iRcRN As New RegContabCabeRN
        Dim iLisRegCon As List(Of SuperEntidad) = Me.ConvertirTextoARegistroVentas
        Dim iRegCon As New SuperEntidad
        iRegCon.CodigoEmpresa = "001"
        Me.ObtenerRangoFechasDeLista(iRegCon, iLisRegCon)
        iRegCon.CampoOrden = cam.FecVouRCC
        Dim iLisRc As List(Of SuperEntidad) = iRcRN.ListarRegistroComprasEntreFechas(iRegCon)
        'VER SI EL REGISTRO CONTABLE DE LA CONTABILIDAD EXISTE EN EL TEXTO IMPORTADO
        For Each xCon As SuperEntidad In iLisRc
            Dim iRccEN As New SuperEntidad
            iRccEN.ClaveRegContabCabe = xCon.ClaveRegContabCabe
            For Each xProy As SuperEntidad In iLisRegCon
                If xProy.Mensaje = "C" Then
                    If xCon.ClaveRegContabCabe = xProy.ClaveRegContabCabe Then
                        iRccEN.Vista = "1"
                    End If
                End If
            Next
            'SE LA VISTA ES UNO QUIERE DECIR QUE EL OBJETO DE CONTABILIDAD SI EXISTE EN
            'EL TEXTO IMPORTADO,POR LO TANTO NO ELIMINA NADA
            If iRccEN.Vista <> "1" Then
                'VER SI ESTE REGISTRO ES APTO PARA PASAR A B.D
                If Me.EsActoGrabarRegistroContable(iRccEN) = True Then
                    'ELIMINANDO OBJETOS ANTERIORES , SI LOS HUBIERA
                    Me.eliminarRegistroCabecera(iRccEN)
                    Me.eliminarRegistroDetalle(iRccEN)
                    Me.eliminarCuentaCorriente(iRccEN)
                End If
            End If
        Next
    End Sub

    Sub ObtenerRangoFechasDeLista(ByRef ent As SuperEntidad, ByVal pLista As List(Of SuperEntidad))
        Dim iNumReg As Integer = pLista.Count
        If iNumReg <> 0 Then
            ent.DatoFiltro1 = Varios.AñoMesDia(pLista.Item(0).FechaVoucherRegContabCabe)
        End If

        ent.DatoFiltro2 = Varios.AñoMesDia(pLista.Item(0).FechaVoucherRegContabCabe)

        'For Each xobj As SuperEntidad In pLista
        '    If xobj.Mensaje = "C" Then
        '        ent.DatoFiltro2 = Varios.AñoMesDia(xobj.FechaVoucherRegContabCabe)
        '    End If
        'Next
    End Sub

    Sub ImportarRegistrosVenta()
        'LISTA DE REGISTROS CONTABLES CABECERA Y DETALLE
        'PRODUCTO DE LA TRANSFORMACION DEL TEXTO
        iLisRegVta = Me.ConvertirTextoARegistroVentas

        '   Me.DgvPcg.DataSource = iLisRegVta

        Me.ActualizarDgvTab()

        MsgBox("Pasa esta lista")

        Exit Sub

        'CONTADOR DE OBJETOS
        Dim iContador As Integer = 0
        Dim iNroObj As Integer = iLisRegVta.Count

        'LISTA DONDE SE ARMARAN CADA REGISTRO CONTABLE Y SU DETALLE
        'UNO A UNO
        Dim iLisAsi As New List(Of SuperEntidad)

        For Each xRegCon As SuperEntidad In iLisRegVta
            iContador += 1
            'PREGUNTAR SI EL OBJETO ES CABECERA O DETALLE
            If xRegCon.Mensaje = "C" Then
                'SI LA LISTA iLisAsi ESTA LLENA QUIERE DECIR QUE YA SE PASARON 
                'LA CABECERA Y SUS DETALLES DE UN REGISTRO POR LO TANTO COMPLETAR
                'EL ASIENTO Y GRABAR
                If iLisAsi.Count <> 0 Then
                    Dim iRccEN As SuperEntidad = iLisAsi.Item(0)
                    'VER SI ESTE REGISTRO ES APTO PARA PASAR A B.D
                    If Me.EsActoGrabarRegistroContable(iRccEN) = True Then
                        'PROCESO PARA FORMAR ASIENTOS Y GRABAR ,SIEMPRE Y CUANDO EL REGISTRO NO ESTE ESTORNADO
                        'O NO SE HALLA PAGADO EL DOCUMENTO
                        Me.CompletarAsiento(iLisAsi)
                        Me.CuadrarAsientos(iLisAsi)

                        'MsgBox(xRegCon.ClaveRegContabCabe)

                        'For Each ll As SuperEntidad In iLisAsi
                        '    MsgBox(ll.DebeHaberRegContabDeta + " --- " + ll.ImporteSRegContabDeta.ToString)

                        'Next

                        'ELIMINANDO OBJETOS ANTERIORES , SI LOS HUBIERA
                        Me.eliminarRegistroCabecera(iRccEN)
                        Me.eliminarRegistroDetalle(iRccEN)
                        Me.eliminarCuentaCorriente(iRccEN)

                        'GRABANDO CABECERA Y DETALLE
                        Me.GrabarRegistrosContables(iLisAsi)

                        'GRABAR CUENTA CORRIENTE
                        Me.GrabarCuentaCorriente(iRccEN)

                        'GRABAR AUXILIAR
                        Me.GrabarAuxiliar(iRccEN)

                    End If
                    'LIMPIAR LA LISTA A UN NUEVO CABECERA U DETALLE
                    iLisAsi.Clear()
                End If
            End If
            iLisAsi.Add(xRegCon)

            'PARA EL ULTIMO REGISTRO
            If iContador = iNroObj Then
                Dim iRccEN As SuperEntidad = iLisAsi.Item(0)
                'VER SI ESTE REGISTRO ES APTO PARA PASAR A B.D
                If Me.EsActoGrabarRegistroContable(iRccEN) = True Then
                    'PROCESO PARA FORMAR ASIENTOS Y GRABAR ,SIEMPRE Y CUANDO EL REGISTRO NO ESTE ESTORNADO
                    'O NO SE HALLA PAGADO EL DOCUMENTO
                    Me.CompletarAsiento(iLisAsi)
                    Me.CuadrarAsientos(iLisAsi)


                    'MsgBox(xRegCon.ClaveRegContabCabe)

                    'For Each ll As SuperEntidad In iLisAsi
                    '    MsgBox(ll.DebeHaberRegContabDeta + " --- " + ll.ImporteSRegContabDeta.ToString)

                    'Next



                    'ELIMINANDO OBJETOS ANTERIORES , SI LOS HUBIERA
                    Me.eliminarRegistroCabecera(iRccEN)
                    Me.eliminarRegistroDetalle(iRccEN)
                    Me.eliminarCuentaCorriente(iRccEN)

                    'GRABANDO CABECERA Y DETALLE
                    Me.GrabarRegistrosContables(iLisAsi)

                    'GRABAR CUENTA CORRIENTE
                    Me.GrabarCuentaCorriente(iRccEN)

                    'GRABAR AUXILIAR
                    Me.GrabarAuxiliar(iRccEN)
                End If
                'LIMPIAR LA LISTA A UN NUEVO CABECERA U DETALLE
                iLisAsi.Clear()
            End If
        Next

    End Sub

    Function EsActoGrabarRegistroContable(ByVal pRcc As SuperEntidad) As Boolean
        Dim iRccRN As New RegContabCabeRN
        Dim iRccEN As New SuperEntidad
        iRccEN.ClaveRegContabCabe = pRcc.ClaveRegContabCabe
        iRccEN = iRccRN.buscarRegContabExisPorClave(iRccEN)

        'SI EL OBJETO NO EXISTE ENTONCES SI SE PUEDE GRABAR
        If iRccEN.ClaveRegContabCabe = "" Then
            Return True
        Else
            'VER SI ESTE OBJETO SE EXTORNO, SI ES ASI NO SE PUEDE REEMPLAZAR
            If iRccEN.EstadoRegistro <> "0" Then
                Return False
            Else
                'AQUI EL OBJETO NO SE HA ESTORNADO PERO TALVEZ VEZ YA SE PAGO O COBRO EL DOCUMENTO
                'QUE GENERO EN CUENTA CORRIENTE
                Dim iCcRN As New CuentaCorrienteRN
                Dim iCcEN As New SuperEntidad
                iCcEN.ClaveCuentaCorriente = iRccEN.ClaveRegContabCabe
                iCcEN = iCcRN.buscarCuentaCorrienteExisPorClaveCC(iCcEN)
                If iCcEN.ClaveCuentaCorriente = "" Then
                    Return True
                Else
                    If iCcEN.ImportePagadoCuentaCorriente = 0 Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            End If
        End If
    End Function

    Sub CompletarAsiento(ByRef pLista As List(Of SuperEntidad))
        'SACAR AL OBJETO CABECERA DE LA LISTA 
        Dim iRccEN As New SuperEntidad
        iRccEN = pLista.Item(0)

        'ACTUALIZAR LOS REGISTROS DETALLE CREADOS EN PROYECTO
        For Each xDet As SuperEntidad In pLista
            If xDet.Mensaje <> "C" Then
                If iRccEN.CodigoFile = "407" Then
                    xDet.DebeHaberRegContabDeta = "0"
                Else
                    xDet.DebeHaberRegContabDeta = "1"
                End If
            End If
        Next

        'ARMANDO EL DETALLE DEL PRECIO DE VENTA
        Dim iRcdEN As SuperEntidad
        iRcdEN = New SuperEntidad
        iRcdEN.CodigoCuentaPcge = "4212101"
        iRcdEN.CodigoCentroCosto = ""
        If iRccEN.CodigoFile = "407" Then
            iRcdEN.DebeHaberRegContabDeta = "1"
        Else
            iRcdEN.DebeHaberRegContabDeta = "0"
        End If

        Dim iPv As Decimal = Math.Abs(iRccEN.PrecioVtaRegContabCabe)
        Select Case iRccEN.MonedaDocumento
            Case "S/."
                iRcdEN.ImporteSRegContabDeta = iPv
                iRcdEN.ImporteDRegContabDeta = iPv / iRccEN.VentaTipoCambio
                iRcdEN.ImporteERegContabDeta = iPv / iRccEN.VentaEurTipoCambio
            Case "US$"
                iRcdEN.ImporteSRegContabDeta = iPv * iRccEN.VentaTipoCambio
                iRcdEN.ImporteDRegContabDeta = iPv
                iRcdEN.ImporteERegContabDeta = iPv / iRccEN.VentaEurTipoCambio
            Case "EUR"
                iRcdEN.ImporteSRegContabDeta = iPv * iRccEN.VentaEurTipoCambio
                iRcdEN.ImporteDRegContabDeta = iPv / iRccEN.VentaEurTipoCambio
                iRcdEN.ImporteERegContabDeta = iPv
        End Select
        iRcdEN.ImporteSRegContabDeta = Math.Round(iRcdEN.ImporteSRegContabDeta, 2)
        iRcdEN.GlosaRegContabDeta = iRccEN.GlosaRegContabCabe
        'defecto
        iRcdEN.Cuenta1242 = ""
        iRcdEN.CodigoIngEgr = ""
        iRcdEN.EstadoRegContabDeta = "1"  ' No se muestran
        iRcdEN.CodigoArea = ""
        iRcdEN.CodigoFlujoCaja = ""
        iRcdEN.CodigoCentroCosto = ""
        pLista.Add(iRcdEN)

        'OBTENER EL EXONERADO
        If iRccEN.ExoneradoRegContabCabe < 0 Then
            iRcdEN = New SuperEntidad
            iRcdEN.CodigoCuentaPcge = pLista.Item(1).CodigoCuentaPcge
            Dim iExo As Decimal = Math.Abs(iRccEN.ExoneradoRegContabCabe)
            Select Case iRcdEN.MonedaDocumento
                Case "S/."
                    iRcdEN.ImporteSRegContabDeta = iExo
                    iRcdEN.ImporteDRegContabDeta = iExo / iRccEN.VentaTipoCambio
                    iRcdEN.ImporteERegContabDeta = iExo / iRccEN.VentaEurTipoCambio
                Case "US$"
                    iRcdEN.ImporteSRegContabDeta = iExo * iRccEN.VentaTipoCambio
                    iRcdEN.ImporteDRegContabDeta = iExo
                    iRcdEN.ImporteERegContabDeta = iExo / iRccEN.VentaEurTipoCambio
                Case "CAD"
                    iRcdEN.ImporteSRegContabDeta = iExo * iRccEN.VentaEurTipoCambio
                    iRcdEN.ImporteDRegContabDeta = iExo / iRccEN.VentaEurTipoCambio
                    iRcdEN.ImporteERegContabDeta = iExo
            End Select
            iRcdEN.ImporteSRegContabDeta = Math.Round(iRcdEN.ImporteSRegContabDeta, 2)
            iRcdEN.GlosaRegContabDeta = iRccEN.GlosaRegContabCabe
            If iRccEN.CodigoFile = "407" Then
                iRcdEN.DebeHaberRegContabDeta = "1" 'No se Muestran
            Else
                iRcdEN.DebeHaberRegContabDeta = "0" 'No se Muestran
            End If
            pLista.Add(iRcdEN)
        End If

        'SI ES UNA BOLETA ENTONCES NO HAY ASIENTO DE IGV
        If iRccEN.TipoDocumento = "03" Then Exit Sub

        'SINO ES BOLETA GRABA CUENAT IGV
        Dim iParRN As New ParametroRN
        Dim iParEN As New SuperEntidad
        iParEN = iParRN.buscarParametroExis(iParEN)
        iRcdEN = New SuperEntidad
        iRcdEN.CodigoCuentaPcge = iParEN.CuentaIgv
        Select Case iRccEN.MonedaDocumento
            Case "S/."
                iRcdEN.ImporteSRegContabDeta = iRccEN.IgvRegContabCabe
                iRcdEN.ImporteDRegContabDeta = iRccEN.IgvRegContabCabe / iRccEN.VentaTipoCambio
                iRcdEN.ImporteERegContabDeta = iRccEN.IgvRegContabCabe / iRccEN.VentaEurTipoCambio
            Case "US$"
                iRcdEN.ImporteSRegContabDeta = iRccEN.IgvRegContabCabe * iRccEN.VentaTipoCambio
                iRcdEN.ImporteDRegContabDeta = iRccEN.IgvRegContabCabe
                iRcdEN.ImporteERegContabDeta = iRccEN.IgvRegContabCabe / iRccEN.VentaEurTipoCambio
            Case "EUR"
                iRcdEN.ImporteSRegContabDeta = iRccEN.IgvRegContabCabe * iRccEN.VentaEurTipoCambio
                iRcdEN.ImporteDRegContabDeta = iRccEN.IgvRegContabCabe / iRccEN.VentaEurTipoCambio
                iRcdEN.ImporteERegContabDeta = iRccEN.IgvRegContabCabe
        End Select
        iRcdEN.ImporteSRegContabDeta = Math.Round(iRcdEN.ImporteSRegContabDeta, 2)

        If iRccEN.CodigoFile = "407" Then
            iRcdEN.DebeHaberRegContabDeta = "0" 'No se Muestran
        Else
            iRcdEN.DebeHaberRegContabDeta = "1" 'No se Muestran
        End If
        iRcdEN.EstadoRegContabDeta = "1"  ' No se muestran
        iRcdEN.CodigoArea = ""
        iRcdEN.CodigoFlujoCaja = ""
        iRcdEN.CodigoCentroCosto = ""
        iRcdEN.GlosaRegContabDeta = iRccEN.GlosaRegContabCabe
        iRcdEN.Cuenta1242 = ""
        pLista.Add(iRcdEN)
    End Sub

    Sub CuadrarAsientos(ByRef pLista As List(Of SuperEntidad))
        Dim sumadebe As Decimal = 0
        Dim sumahaber As Decimal = 0
        For Each xobj As SuperEntidad In pLista
            If xobj.DebeHaberRegContabDeta = "1" Then
                sumadebe += xobj.ImporteSRegContabDeta
            Else
                sumahaber += xobj.ImporteSRegContabDeta
            End If
        Next

        Dim iDif As Decimal = sumadebe - sumahaber
        If iDif = 0 Then Exit Sub

        For Each xobj As SuperEntidad In pLista
            If iDif > 0 Then
                If xobj.DebeHaberRegContabDeta = "0" Then
                    xobj.ImporteSRegContabDeta += iDif
                    Exit For
                End If
            Else
                If xobj.DebeHaberRegContabDeta = "1" Then
                    xobj.ImporteSRegContabDeta += Math.Abs(iDif)
                    Exit For
                End If
            End If
        Next
    End Sub

    Sub eliminarCuentaCorriente(ByVal pRcc As SuperEntidad)
        Dim ccte As New CuentaCorrienteRN
        Dim obj As New SuperEntidad
        Dim iCuCoEN As New SuperEntidad

        If pRcc.CodigoFile = "407" Then
            'TRAER EL DOCUMENTO APLICADO QUE SE ENCUENTRA EN LA CUENTA CORRIENTE
            'PARA DESCONTAR LO QUE SE REBAJO
            iCuCoEN.ClaveDocumentoCuentaCorriente += Me.TxtCodEmp.Text
            iCuCoEN.ClaveDocumentoCuentaCorriente += pRcc.CodigoAuxiliar
            iCuCoEN.ClaveDocumentoCuentaCorriente += pRcc.TipoDocumento1
            iCuCoEN.ClaveDocumentoCuentaCorriente += pRcc.SerieDocumento1
            iCuCoEN.ClaveDocumentoCuentaCorriente += pRcc.NumeroDocumento1
            iCuCoEN = ccte.buscarCuentaCorrienteExisPorClaveDoc(iCuCoEN)
            'SI NO LO ENCUENTRA NO ASE NADA
            If iCuCoEN.ClaveCuentaCorriente <> "" Then
                'VOLVER A SU IMPORTE NORMAL 
                iCuCoEN.ImporteOriginalCuentaCorriente += pRcc.PrecioVtaRegContabCabe
                iCuCoEN.SaldoCuentaCorriente = iCuCoEN.ImporteOriginalCuentaCorriente - iCuCoEN.ImportePagadoCuentaCorriente
                'PREGUNTAR SI ESTE NUEVO IMPORTE ES IGUAL AL PAGADO ENTONCES QUIERE DECIR
                'QUE ESTE DOCUEMNTO YA SE DEBE CANCELAR EN ESTA OPERACION
                If iCuCoEN.SaldoCuentaCorriente = 0 Then
                    iCuCoEN.EstadoCuentaCorriente = "0" 'CANCELADO
                Else
                    iCuCoEN.EstadoCuentaCorriente = "1" 'PENDIENTE
                End If
                ccte.modificarCuentaCorriente(iCuCoEN)
            End If
        Else
            obj.ClaveCuentaCorriente = pRcc.ClaveRegContabCabe
            ccte.eliminarCuentaCorrienteFis(obj)
        End If

    End Sub

    Sub eliminarRegistroCabecera(ByVal pRcc As SuperEntidad)
        Dim iRccRN As New RegContabCabeRN
        Dim obj As New SuperEntidad
        obj.ClaveRegContabCabe = pRcc.ClaveRegContabCabe
        iRccRN.eliminarRegContabFis(obj)
    End Sub

    Sub eliminarRegistroDetalle(ByVal pRcc As SuperEntidad)
        Dim iRccRN As New RegContabDetaRN
        Dim obj As New SuperEntidad
        obj.ClaveRegContabCabe = pRcc.ClaveRegContabCabe
        iRccRN.eliminarRegContabDeta(obj)
    End Sub

    Sub GrabarRegistrosContables(ByRef pLista As List(Of SuperEntidad))
        'OBJETOS DE NEGOCIO
        Dim iRccRN As New RegContabCabeRN
        Dim iRcdRN As New RegContabDetaRN

        'OBTENER EL CORRELATIVO PARA LA CABECERA
        Dim iCorrelativo As Integer = pLista.Count - 1

        'OBTENER CORELATIVO PARA LOS DETALLE
        Dim iCorDet As Integer = 0

        'DE LA LISTA SACAR EL PRIMER OBJETO QUE VIENE A SER EL REGISTRO CABECERA
        'POR QUE DE ACA SE PASAN ALGUNOS VALORES A LOS DETALLES
        Dim iRccEN As SuperEntidad = pLista.Item(0)

        For Each xRegCon As SuperEntidad In pLista
            If xRegCon.Mensaje = "C" Then
                iRccEN.UltimoCorrelativo = iCorrelativo.ToString.PadLeft(4, CType("0", Char))
                iRccRN.nuevoespecial(xRegCon)
            Else
                iCorDet += 1
                xRegCon.ClaveRegContabCabe = iRccEN.ClaveRegContabCabe
                xRegCon.CorrelativoRegContabDeta = iCorDet.ToString.PadLeft(4, CType("0", Char))
                xRegCon.ClaveRegContabDeta = xRegCon.ClaveRegContabCabe + xRegCon.CorrelativoRegContabDeta
                xRegCon.CodigoAuxiliar = iRccEN.CodigoAuxiliar
                xRegCon.TipoDocumento = iRccEN.TipoDocumento
                xRegCon.SerieDocumento = iRccEN.SerieDocumento
                xRegCon.NumeroDocumento = iRccEN.NumeroDocumento
                xRegCon.FechaDocumento = iRccEN.FechaDocumento
                xRegCon.VentaTipoCambio = iRccEN.VentaTipoCambio
                xRegCon.VentaEurTipoCambio = iRccEN.VentaEurTipoCambio
                iRcdRN.nuevoRegContabDeta(xRegCon)
            End If
        Next

    End Sub

    Sub GrabarCuentaCorriente(ByVal pRcc As SuperEntidad)
        Dim iCcRN As New CuentaCorrienteRN
        Dim iCuCoEN As New SuperEntidad
        Dim iCcEN As New SuperEntidad
        If pRcc.CodigoFile = "407" Then
            'ES UNA NOTA DE CREDITO POR LO TANTO VA A REBAJAR EL MONTO DEL 
            'DOCUMENTO A APLICAR
            'TRAER EL DOCUMENTO APLICADO QUE SE ENCUENTRA EN LA CUENTA CORRIENTE
            iCuCoEN.ClaveDocumentoCuentaCorriente += Me.TxtCodEmp.Text
            iCuCoEN.ClaveDocumentoCuentaCorriente += pRcc.CodigoAuxiliar
            iCuCoEN.ClaveDocumentoCuentaCorriente += pRcc.TipoDocumento1
            iCuCoEN.ClaveDocumentoCuentaCorriente += pRcc.SerieDocumento1
            iCuCoEN.ClaveDocumentoCuentaCorriente += pRcc.NumeroDocumento1
            iCuCoEN = iCcRN.buscarCuentaCorrienteExisPorClaveDoc(iCuCoEN)
            If iCuCoEN.ClaveCuentaCorriente <> "" Then
                'REBAJAR EL MONTO ORIGINAL DEL DOCUMENTO
                iCuCoEN.ImporteOriginalCuentaCorriente -= pRcc.PrecioVtaRegContabCabe
                iCuCoEN.SaldoCuentaCorriente = iCuCoEN.ImporteOriginalCuentaCorriente - iCuCoEN.ImportePagadoCuentaCorriente
                'PREGUNTAR SI ESTE NUEVO IMPORTE ES IGUAL AL PAGADO ENTONCES QUIERE DECIR
                'QUE ESTE DOCUEMNTO YA SE DEBE CANCELAR EN ESTA OPERACION
                If iCuCoEN.SaldoCuentaCorriente = 0 Then
                    iCuCoEN.EstadoCuentaCorriente = "0" 'CANCELADO
                Else
                    iCuCoEN.EstadoCuentaCorriente = "1" 'PENDIENTE
                End If
                iCcRN.modificarCuentaCorriente(iCuCoEN)
            End If
        Else
            iCcEN.PeriodoRegContabCabe = pRcc.PeriodoRegContabCabe
            iCcEN.CodigoEmpresa = Me.TxtCodEmp.Text
            iCcEN.CodigoOrigen = pRcc.CodigoOrigen
            iCcEN.CodigoFile = pRcc.CodigoFile
            iCcEN.NumeroVoucherRegContabCabe = pRcc.NumeroVoucherRegContabCabe
            iCcEN.CodigoAuxiliar = pRcc.CodigoAuxiliar
            iCcEN.TipoDocumento = pRcc.TipoDocumento
            iCcEN.SerieDocumento = pRcc.SerieDocumento
            iCcEN.NumeroDocumento = pRcc.NumeroDocumento
            iCcEN.FechaDocumento = pRcc.FechaDocumento
            iCcEN.VentaTipoCambio = pRcc.VentaTipoCambio
            iCcEN.VentaEurTipoCambio = pRcc.VentaEurTipoCambio
            iCcEN.CodigoCuentaPcge = pRcc.CodigoCuentaBanco
            iCcEN.FechaVctoDocumento = ""
            'moneda
            iCcEN.MonedaDocumento = pRcc.MonedaDocumento
            iCcEN.ImporteOriginalCuentaCorriente = pRcc.PrecioVtaRegContabCabe
            iCcEN.ImportePagadoCuentaCorriente = 0
            iCcEN.SaldoCuentaCorriente = pRcc.PrecioVtaRegContabCabe
            iCcEN.EstadoCuentaCorriente = "1" 'Pendiente de pago 
            iCcRN.nuevoCuentaCorriente(iCcEN)
        End If
    End Sub

    Sub GrabarAuxiliar(ByVal pRcc As SuperEntidad)
        'PRIMERO PREGUNTAMOS SI ESTE AUXILIAR EXISTE EN LA B.D DE CONTABILIDAD
        Dim iAuxEN As New SuperEntidad
        Dim iAuxRN As New AuxiliarRN
        iAuxEN.CodigoAuxiliar = pRcc.CodigoAuxiliar
        iAuxEN = iAuxRN.buscarAuxiliarExisPorCodigo(iAuxEN)

        'SI YA HAY AUXILIAR ENTONCES NO GRABA NADA
        If iAuxEN.CodigoAuxiliar = "" Then
            'TRAEMOS AL AUXILIAR DE LA B.D DE PROYECTOS
            iAuxEN.CodigoAuxiliar = pRcc.CodigoAuxiliar
            iAuxEN = iAuxRN.buscarAuxiliarExisPorCodigoDeProyecto(iAuxEN)
            iAuxEN.ApellidoPaternoAuxiliar = ""
            iAuxEN.ApellidoMaternoAuxiliar = ""
            iAuxEN.PrimerNombreAuxiliar = ""
            iAuxEN.SegundoNombreAuxiliar = ""
            iAuxEN.TipoDocumentoAuxiliar = "0"
            iAuxEN.TipoDocumentoAuxiliar = "6"
            iAuxEN.EstadoAuxiliar = "1"
            iAuxEN.Exporta = "0"
            iAuxRN.nuevoAuxiliar(iAuxEN)
        End If

    End Sub

    Function ValidarPeriodo() As Boolean
        Dim iLineaActual As String
        Dim wano As String = ""
        Dim wmes As String = ""
        Dim mPeriodo As String
        Dim wPerido As String = Me.TxtPeri.Text.Trim

        Dim iArchivo As New StreamReader(Me.txtRuta.Text.Trim)

        iLineaActual = iArchivo.ReadLine()
        wano = iLineaActual.Substring(11, 4)
        wmes = iLineaActual.Substring(9, 2)
        mPeriodo = wano + wmes

        If Me.TxtPeri.Text.Trim <> mPeriodo Then
            MsgBox("Achivo de Texto no pertenece al periodo Elegido", MsgBoxStyle.DefaultButton1, "Texto")
            Return False
        Else
            Return True
        End If

    End Function

#End Region

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.MostrarRutaArchivo()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        'Validar Periodo
        If Me.ValidarPeriodo = False Then
            Exit Sub
        End If

        If Me.txtRuta.Text.Trim = "" Then
            MsgBox("Debe especificar la ruta del archivo de texto")
            Exit Sub
        End If
        '  Me.EliminarRegistrosContablesFueraDeRango()
        Me.ImportarRegistrosVenta()
        MsgBox("Proceso de Importacion Ventas Realizado Correctamente")
    End Sub
End Class