Option Explicit On
Option Strict On
Imports Entidad
Imports Negocio
Imports System
Imports System.IO
Imports System.Threading

Public Class WImportarRegistroVentasNuevo
    Public ent, parEn As New SuperEntidad
    Public lista As New List(Of SuperEntidad)
    Public MovCon As New RegContabDetaRN
    Public acc As New Accion
    Public par As New ParametroRN
    Public rCC As New RegContabCabeRN
    Public rCD As New RegContabDetaRN
    Public ccte As New CuentaCorrienteRN
    Public vou As New VoucherRN

    Dim entc As New SuperEntidad
    Dim entd As New SuperEntidad
    Dim iAuxEN As New SuperEntidad
    Dim iAuxRN As New AuxiliarRN
    Dim iCcRN As New CuentaCorrienteRN
    Dim iCcEN As New SuperEntidad
    Dim eOrigen As String = "5"
    Dim eFile As String = "511"
    Dim cam As New CamposEntidad
    Dim iLisRegVta As New List(Of SuperEntidad)

#Region "Metodos"

    Sub ValoresXDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.txtNomEmp.Text = SuperEntidad.xRazonSocial
        Me.TxtPeri.Text = SuperEntidad.xPeriodoEmpresa
        Me.TxtCta70.Text = parEn.CuentaValorVenta
        Me.TxtCta40.Text = parEn.CuentaIgv
        Me.TxtCta12.Text = parEn.CuentaPrecioVenta
        'Me.ActualizarDgvTab()
    End Sub

    Sub NuevaVentana()
        '//
        parEn = par.buscarParametroExis(parEn)
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
        Dgv.asignarColumnaText(Me.DgvPcg, cam.Doc, "TD", 70)
        Dgv.asignarColumnaText(Me.DgvPcg, cam.SerDoC, "Serie", 70)
        Dgv.asignarColumnaText(Me.DgvPcg, cam.NumDoc, "N°Doc", 70)
        Dgv.AsignarColumnaTextNumerico(Me.DgvPcg, cam.VenTipCam, "TC", 50, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvPcg, cam.VenEurTipCam, "TCE", 50, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvPcg, cam.IgvPar, "%igv", 50, 2)
        Dgv.asignarColumnaText(Me.DgvPcg, cam.FecDoc, "Fecha", 70)
        Dgv.asignarColumnaText(Me.DgvPcg, cam.CodAux, "Auxiliar", 80)
        Dgv.asignarColumnaText(Me.DgvPcg, cam.ClaveRCC, "Clave C", 70)
        Dgv.asignarColumnaText(Me.DgvPcg, cam.ClaveRCD, "Clave D", 70)
        Dgv.AsignarColumnaTextNumerico(Me.DgvPcg, cam.ValVtaRCC, "Valor Vta O", 60, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvPcg, cam.ValVtasRCC, "Valor Vta", 60, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvPcg, cam.IgvRCC, "Valor Igv O", 60, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvPcg, cam.IgvsRCC, "Valor Igv", 60, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvPcg, cam.ExoneradoRCC, "Exonerado O", 60, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvPcg, cam.ExoneradoSRCC, "Exonerado", 60, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvPcg, cam.PreVtaRCC, "Precio Vta O", 60, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvPcg, cam.PreVtasRCC, "Precio Vta", 60, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvPcg, cam.ImpRCC, "Monto O", 80, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvPcg, cam.ImpSolRCC, "Monto", 80, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvPcg, cam.SumDebRCC, "Debe S", 80, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvPcg, cam.SumHabRCC, "Haber S", 80, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvPcg, cam.ImpDesRegRcc, "Descuento", 80, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvPcg, cam.DesFon, "DesFon", 80, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvPcg, cam.DesSal, "Des Sal", 80, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvPcg, cam.DesRem, "Des Rem", 80, 2)
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
        Dim wCuenta As String = Me.TxtCta12.Text.Trim

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
                            '   iLisRegVta.Add(iRcdEN)
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

        'Me.ActualizarDgvTab()
        'MsgBox("Pasa esta lista")
        'Exit Sub

        'CONTADOR DE OBJETOS
        Dim iContador As Integer = 0
        Dim wNumero As String = ""
        Dim iNroObj As Integer = iLisRegVta.Count

        'LISTA DONDE SE ARMARAN CADA REGISTRO CONTABLE Y SU DETALLE
        'UNO A UNO
        Dim iLisAsi As New List(Of SuperEntidad)

        For Each xRegCon As SuperEntidad In iLisRegVta
            wNumero = xRegCon.NumeroVoucherRegContabCabe
            entc.ClaveRegContabCabe = xRegCon.ClaveRegContabCabe
            entc.CodigoEmpresa = xRegCon.CodigoEmpresa
            entc.PeriodoRegContabCabe = xRegCon.PeriodoRegContabCabe
            entc.CodigoOrigen = xRegCon.CodigoOrigen
            entc.CodigoFile = xRegCon.CodigoFile
            entc.NumeroVoucherRegContabCabe = xRegCon.NumeroVoucherRegContabCabe
            entc.UltimoCorrelativo = xRegCon.UltimoCorrelativo
            entc.MonedaVoucherRegContabCabe = xRegCon.MonedaVoucherRegContabCabe
            entc.DiaVoucherRegContabCabe = xRegCon.DiaVoucherRegContabCabe
            entc.FechaVoucherRegContabCabe = xRegCon.FechaVoucherRegContabCabe
            entc.CodigoAuxiliar = xRegCon.CodigoAuxiliar
            entc.TipoDocumento = xRegCon.TipoDocumento
            entc.SerieDocumento = xRegCon.SerieDocumento
            entc.NumeroDocumento = xRegCon.NumeroDocumento
            entc.FechaDocumento = xRegCon.FechaDocumento
            entc.FechaVencimiento = xRegCon.FechaVencimiento
            entc.MonedaDocumento = xRegCon.MonedaDocumento
            entc.TipoDocumento1 = xRegCon.TipoDocumento1
            entc.SerieDocumento1 = xRegCon.SerieDocumento1
            entc.NumeroDocumento1 = xRegCon.NumeroDocumento1
            entc.FechaDocumento1 = xRegCon.FechaDocumento1
            entc.MonedaDocumento1 = xRegCon.MonedaDocumento1
            entc.VentaTipoCambio = xRegCon.VentaTipoCambio
            entc.VentaEurTipoCambio = xRegCon.VentaEurTipoCambio
            entc.IgvPar = xRegCon.IgvPar
            entc.ValorVtaRegContabCabe = xRegCon.ValorVtaRegContabCabe
            entc.IgvRegContabCabe = xRegCon.IgvRegContabCabe
            entc.ExoneradoRegContabCabe = xRegCon.ExoneradoRegContabCabe
            entc.PrecioVtaRegContabCabe = xRegCon.PrecioVtaRegContabCabe
            entc.ValorVtaSolRegContabCabe = xRegCon.ValorVtaSolRegContabCabe
            entc.IgvSolRegContabCabe = xRegCon.IgvSolRegContabCabe
            entc.ExoneradoSolRegContabCabe = xRegCon.ExoneradoSolRegContabCabe
            entc.PrecioVtaSolRegContabCabe = xRegCon.PrecioVtaSolRegContabCabe
            entc.GlosaRegContabCabe = xRegCon.GlosaRegContabCabe
            entc.RetencionRegContabCabe = xRegCon.RetencionRegContabCabe
            entc.CodigoCuentaBanco = xRegCon.CodigoCuentaBanco
            entc.ImporteRegContabCabe = xRegCon.ImporteRegContabCabe
            entc.ImporteSolRegContabCabe = xRegCon.ImporteSolRegContabCabe
            entc.DetraccionRegContabCabe = xRegCon.DetraccionRegContabCabe
            entc.NumeroPapeletaRegContabCabe = xRegCon.NumeroPapeletaRegContabCabe
            entc.FechaDetraccionRegContabCabe = xRegCon.FechaDetraccionRegContabCabe
            entc.CodigoModoPago = xRegCon.CodigoModoPago
            entc.CartaRegContabCabe = xRegCon.CartaRegContabCabe
            entc.DescripcionRegContabCabe = xRegCon.DescripcionRegContabCabe
            entc.VoucherIngresoRegContabCabe = xRegCon.VoucherIngresoRegContabCabe
            entc.EstadoRegContabCabe = xRegCon.EstadoRegContabCabe
            entc.SumaHaberRegContabCabe = xRegCon.SumaHaberRegContabCabe
            entc.SumaDebeRegContabCabe = xRegCon.SumaDebeRegContabCabe
            entc.CodigoIngEgr = xRegCon.CodigoIngEgr
            entc.ModoCompra = xRegCon.ModoCompra
            entc.FlagDescuentoRegContabCabe = xRegCon.FlagDescuentoRegContabCabe
            entc.CodigoAfp = xRegCon.CodigoAfp
            entc.ImporteDescuentoRegContabCabe = xRegCon.ImporteDescuentoRegContabCabe
            entc.DescuentoFondo = xRegCon.DescuentoFondo
            entc.DescuentoSalud = xRegCon.DescuentoSalud
            entc.DescuentoRemu = xRegCon.DescuentoRemu
            entc.Exporta = xRegCon.Exporta
            entc.EstadoRegistro = xRegCon.EstadoRegistro
            entc.EliminadoRegistro = xRegCon.EliminadoRegistro
            entc.CodigoUsuarioAgrega = xRegCon.CodigoUsuarioAgrega
            entc.NombreUsuarioAgrega = xRegCon.NombreUsuarioAgrega
            entc.CodigoUsuarioModifica = xRegCon.CodigoUsuarioModifica
            entc.NombreUsuarioModifica = xRegCon.NombreUsuarioModifica

            ''Grabar Cabeera
            rCC.nuevoRegContabCabe(entc)

            ''Si el Documento Esta Anulado no Graba detalle
            If entc.PrecioVtaRegContabCabe <> 0 Then



                ''Grabar Detalle
                ''primero la cuenta valor venta 70  
                entd.CorrelativoRegContabDeta = "0001"
                entd.ClaveRegContabDeta = xRegCon.ClaveRegContabCabe + entd.CorrelativoRegContabDeta
                entd.ClaveRegContabCabe = xRegCon.ClaveRegContabCabe
                entd.CodigoAuxiliar = xRegCon.CodigoAuxiliar
                entd.CodigoCentroCosto = xRegCon.CodigoCentroCosto
                entd.TipoDocumento = xRegCon.TipoDocumento
                entd.SerieDocumento = xRegCon.SerieDocumento
                entd.NumeroDocumento = xRegCon.NumeroDocumento
                entd.FechaDocumento = xRegCon.FechaDocumento
                entd.VentaTipoCambio = xRegCon.VentaTipoCambio
                entd.VentaEurTipoCambio = xRegCon.VentaEurTipoCambio
                entd.CodigoCuentaPcge = Me.TxtCta70.Text.Trim
                entd.DebeHaberRegContabDeta = "Haber" 'xRegCon.DebeHaberRegContabDeta
                entd.ImporteSRegContabDeta = xRegCon.ValorVtaSolRegContabCabe
                entd.ImporteDRegContabDeta = xRegCon.ValorVtaSolRegContabCabe
                entd.ImporteERegContabDeta = xRegCon.ImporteERegContabDeta
                entd.GlosaRegContabDeta = xRegCon.GlosaRegContabCabe
                entd.CodigoIngEgr = xRegCon.CodigoIngresoEgreso
                entd.Cuenta1242 = xRegCon.Cuenta1242
                entd.EstadoRegContabDeta = xRegCon.EstadoRegContabCabe
                entd.CodigoArea = xRegCon.CodigoArea
                entd.CodigoFlujoCaja = xRegCon.CodigoFlujoCaja
                entd.CodigoGastoReparable = xRegCon.CodigoGastoReparable
                entd.Cantidad = xRegCon.Cantidad
                entd.Exporta = xRegCon.Exporta
                entd.EstadoRegistro = xRegCon.EstadoRegistro
                entd.EliminadoRegistro = xRegCon.EliminadoRegistro
                entd.CodigoUsuarioAgrega = xRegCon.CodigoUsuarioAgrega
                entd.NombreUsuarioAgrega = xRegCon.NombreUsuarioAgrega
                entd.CodigoUsuarioModifica = xRegCon.CodigoUsuarioModifica
                entd.NombreUsuarioModifica = xRegCon.NombreUsuarioModifica
                entd.MontoMoneda = xRegCon.MontoMoneda
                entd.MontoSoles = xRegCon.MontoSoles
                entd.CodigoPptoInterno = xRegCon.CodigoPptoInterno
                entd.CodigoConcepto = xRegCon.CodigoConcepto
                entd.CodigoInterno = xRegCon.CodigoInterno
                entd.Titulo = xRegCon.Titulo

                ''Graba Registro Valor Venta
                rCD.nuevoRegContabDeta(entd)

                ''Segundo la cuenta igv 40  
                entd.CorrelativoRegContabDeta = "0002"
                entd.ClaveRegContabDeta = xRegCon.ClaveRegContabCabe + entd.CorrelativoRegContabDeta
                entd.ClaveRegContabCabe = xRegCon.ClaveRegContabCabe
                entd.CodigoAuxiliar = xRegCon.CodigoAuxiliar
                entd.CodigoCentroCosto = xRegCon.CodigoCentroCosto
                entd.TipoDocumento = xRegCon.TipoDocumento
                entd.SerieDocumento = xRegCon.SerieDocumento
                entd.NumeroDocumento = xRegCon.NumeroDocumento
                entd.FechaDocumento = xRegCon.FechaDocumento
                entd.VentaEurTipoCambio = xRegCon.VentaEurTipoCambio
                entd.VentaTipoCambio = xRegCon.VentaTipoCambio
                entd.CodigoCuentaPcge = Me.TxtCta40.Text.Trim
                entd.DebeHaberRegContabDeta = "Haber" 'xRegCon.DebeHaberRegContabDeta
                entd.ImporteSRegContabDeta = xRegCon.IgvSolRegContabCabe
                entd.ImporteDRegContabDeta = xRegCon.IgvSolRegContabCabe
                entd.ImporteERegContabDeta = xRegCon.ImporteERegContabDeta
                entd.GlosaRegContabDeta = xRegCon.GlosaRegContabCabe
                entd.CodigoIngEgr = xRegCon.CodigoIngresoEgreso
                entd.Cuenta1242 = xRegCon.Cuenta1242
                entd.EstadoRegContabDeta = xRegCon.EstadoRegContabCabe
                entd.CodigoArea = xRegCon.CodigoArea
                entd.CodigoFlujoCaja = xRegCon.CodigoFlujoCaja
                entd.CodigoGastoReparable = xRegCon.CodigoGastoReparable
                entd.Cantidad = xRegCon.Cantidad
                entd.Exporta = xRegCon.Exporta
                entd.EstadoRegistro = xRegCon.EstadoRegistro
                entd.EliminadoRegistro = xRegCon.EliminadoRegistro
                entd.CodigoUsuarioAgrega = xRegCon.CodigoUsuarioAgrega
                entd.NombreUsuarioAgrega = xRegCon.NombreUsuarioAgrega
                entd.CodigoUsuarioModifica = xRegCon.CodigoUsuarioModifica
                entd.NombreUsuarioModifica = xRegCon.NombreUsuarioModifica
                entd.MontoMoneda = xRegCon.MontoMoneda
                entd.MontoSoles = xRegCon.MontoSoles
                entd.CodigoPptoInterno = xRegCon.CodigoPptoInterno
                entd.CodigoConcepto = xRegCon.CodigoConcepto
                entd.CodigoInterno = xRegCon.CodigoInterno
                entd.Titulo = xRegCon.Titulo

                ''Graba Registro igv
                rCD.nuevoRegContabDeta(entd)

                ''Tercdro la cuenta Precio venta 12
                entd.CorrelativoRegContabDeta = "0003"
                entd.ClaveRegContabDeta = xRegCon.ClaveRegContabCabe + entd.CorrelativoRegContabDeta
                entd.ClaveRegContabCabe = xRegCon.ClaveRegContabCabe
                entd.CodigoAuxiliar = xRegCon.CodigoAuxiliar
                entd.CodigoCentroCosto = xRegCon.CodigoCentroCosto
                entd.TipoDocumento = xRegCon.TipoDocumento
                entd.SerieDocumento = xRegCon.SerieDocumento
                entd.NumeroDocumento = xRegCon.NumeroDocumento
                entd.FechaDocumento = xRegCon.FechaDocumento
                entd.VentaEurTipoCambio = xRegCon.VentaEurTipoCambio
                entd.CodigoCuentaPcge = Me.TxtCta12.Text.Trim
                entd.DebeHaberRegContabDeta = "Debe" 'xRegCon.DebeHaberRegContabDeta
                entd.ImporteSRegContabDeta = xRegCon.PrecioVtaSolRegContabCabe
                entd.ImporteDRegContabDeta = xRegCon.PrecioVtaSolRegContabCabe
                entd.ImporteERegContabDeta = xRegCon.ImporteERegContabDeta
                entd.GlosaRegContabDeta = xRegCon.GlosaRegContabCabe
                entd.CodigoIngEgr = xRegCon.CodigoIngresoEgreso
                entd.Cuenta1242 = xRegCon.Cuenta1242
                entd.EstadoRegContabDeta = xRegCon.EstadoRegContabCabe
                entd.CodigoArea = xRegCon.CodigoArea
                entd.CodigoFlujoCaja = xRegCon.CodigoFlujoCaja
                entd.CodigoGastoReparable = xRegCon.CodigoGastoReparable
                entd.Cantidad = xRegCon.Cantidad
                entd.Exporta = xRegCon.Exporta
                entd.EstadoRegistro = xRegCon.EstadoRegistro
                entd.EliminadoRegistro = xRegCon.EliminadoRegistro
                entd.CodigoUsuarioAgrega = xRegCon.CodigoUsuarioAgrega
                entd.NombreUsuarioAgrega = xRegCon.NombreUsuarioAgrega
                entd.CodigoUsuarioModifica = xRegCon.CodigoUsuarioModifica
                entd.NombreUsuarioModifica = xRegCon.NombreUsuarioModifica
                entd.MontoMoneda = xRegCon.MontoMoneda
                entd.MontoSoles = xRegCon.MontoSoles
                entd.CodigoPptoInterno = xRegCon.CodigoPptoInterno
                entd.CodigoConcepto = xRegCon.CodigoConcepto
                entd.CodigoInterno = xRegCon.CodigoInterno
                entd.Titulo = xRegCon.Titulo

                ''Graba Registro Precio Venta
                rCD.nuevoRegContabDeta(entd)

                ''Grabar Cuenta Corriente
                iCcEN.ClaveCuentaCorriente = entc.ClaveRegContabCabe
                iCcEN.ClaveDocumentoCuentaCorriente += Me.TxtCodEmp.Text
                iCcEN.ClaveDocumentoCuentaCorriente += entc.CodigoAuxiliar
                iCcEN.ClaveDocumentoCuentaCorriente += entc.TipoDocumento
                iCcEN.ClaveDocumentoCuentaCorriente += entc.SerieDocumento
                iCcEN.ClaveDocumentoCuentaCorriente += entc.NumeroDocumento
                iCcEN.CodigoEmpresa = Me.TxtCodEmp.Text
                iCcEN.PeriodoRegContabCabe = entc.PeriodoRegContabCabe
                iCcEN.CodigoOrigen = entc.CodigoOrigen
                iCcEN.CodigoFile = entc.CodigoFile
                iCcEN.NumeroVoucherRegContabCabe = entc.NumeroVoucherRegContabCabe
                iCcEN.CodigoAuxiliar = entc.CodigoAuxiliar
                iCcEN.TipoDocumento = entc.TipoDocumento
                iCcEN.SerieDocumento = entc.SerieDocumento
                iCcEN.NumeroDocumento = entc.NumeroDocumento
                iCcEN.FechaDocumento = entc.FechaDocumento
                iCcEN.MonedaDocumento = entc.MonedaDocumento
                iCcEN.FechaVctoDocumento = ""
                iCcEN.VentaTipoCambio = entc.VentaTipoCambio
                iCcEN.VentaEurTipoCambio = 1
                iCcEN.VentaTipoCambioOriginal = entc.VentaTipoCambio
                iCcEN.VentaEurTipoCambioOriginal = 1
                iCcEN.IgvPar = entc.IgvPar
                iCcEN.ImporteOriginalCuentaCorriente = entc.PrecioVtaRegContabCabe
                iCcEN.ImportePagadoCuentaCorriente = 0
                iCcEN.SaldoCuentaCorriente = entc.PrecioVtaRegContabCabe
                iCcEN.CodigoCuentaPcge = Me.TxtCta12.Text
                iCcEN.EstadoCuentaCorriente = "1" 'Pendiente de pago 
                iCcEN.ClaveNotaCredito = ""
                iCcEN.ValorNotaCredito = 0
                iCcEN.Exporta = "0"
                iCcEN.EstadoRegistro = "1"
                iCcEN.EliminadoRegistro = "1"
                iCcEN.CodigoUsuarioAgrega = entc.CodigoUsuarioAgrega
                iCcEN.NombreUsuarioAgrega = entc.NombreUsuarioAgrega
                iCcEN.CodigoUsuarioModifica = entc.CodigoUsuarioModifica
                iCcEN.NombreUsuarioModifica = entc.NombreUsuarioModifica
                ''Grabar Cuenta Corriente
                iCcRN.nuevoCuentaCorriente(iCcEN)
            End If
        Next
        'numero voucher autogenerado
        Dim aut As New SuperEntidad
        aut.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        aut.AnoVoucher = Me.TxtPeri.Text.Substring(0, 4)
        aut.CodigoFile = eFile
        aut.ClaveVoucher = aut.CodigoEmpresa
        aut.ClaveVoucher += aut.AnoVoucher
        aut.ClaveVoucher += aut.CodigoFile
        aut = vou.buscarVoucherExisPorCodigo(aut)

        Select Case Me.TxtPeri.Text.Substring(4)
            Case "01" : aut.EneroVoucher = wNumero.ToString.PadLeft(6, CType("0", Char))
            Case "02" : aut.FebreroVoucher = wNumero.ToString.PadLeft(6, CType("0", Char))
            Case "03" : aut.MarzoVoucher = wNumero.ToString.PadLeft(6, CType("0", Char))
            Case "04" : aut.AbrilVoucher = wNumero.ToString.PadLeft(6, CType("0", Char))
            Case "05" : aut.MayoVoucher = wNumero.ToString.PadLeft(6, CType("0", Char))
            Case "06" : aut.JunioVoucher = wNumero.ToString.PadLeft(6, CType("0", Char))
            Case "07" : aut.JulioVoucher = wNumero.ToString.PadLeft(6, CType("0", Char))
            Case "08" : aut.AgostoVoucher = wNumero.ToString.PadLeft(6, CType("0", Char))
            Case "09" : aut.SetiembreVoucher = wNumero.ToString.PadLeft(6, CType("0", Char))
            Case "10" : aut.OctubreVoucher = wNumero.ToString.PadLeft(6, CType("0", Char))
            Case "11" : aut.NoviembreVoucher = wNumero.ToString.PadLeft(6, CType("0", Char))
            Case "12" : aut.DiciembreVoucher = wNumero.ToString.PadLeft(6, CType("0", Char))
        End Select
        '  vou.modificarVoucher(aut)
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

    Sub EliminarAntesDeProcesar()
        ''eLIMINAR cABECERA
        Dim iRcc As New SuperEntidad
        iRcc.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iRcc.PeriodoRegContabCabe = Me.TxtPeri.Text
        iRcc.CodigoOrigen = eOrigen
        iRcc.CodigoFile = eFile
        rCC.EliminarRegContabCabePeriodoOrigenYFile(iRcc)

        ''Eliminar DetLLE
        Dim iRcd As New SuperEntidad
        iRcd.ClaveRegContabCabe += SuperEntidad.xCodigoEmpresa
        iRcd.ClaveRegContabCabe += Me.TxtPeri.Text
        iRcd.ClaveRegContabCabe += eOrigen
        iRcd.ClaveRegContabCabe += eFile
        rCD.EliminarRegContabDetaXGastoOperativo(iRcd)

        ''Eliminar Cuenta Corriente
        Dim iCcte As New SuperEntidad
        iCcte.ClaveCuentaCorriente += SuperEntidad.xCodigoEmpresa
        iCcte.ClaveCuentaCorriente += Me.TxtPeri.Text.Trim
        iCcte.ClaveCuentaCorriente += eOrigen
        iCcte.ClaveCuentaCorriente += eFile
        ccte.EliminarCuentaCorrienteXGastoOperativo(iCcte)

    End Sub

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
        'Eliminar Registros antes de procesar  Me.EliminarRegistrosContablesFueraDeRango()
        Me.EliminarAntesDeProcesar()
        Me.ImportarRegistrosVenta()
        MsgBox("Proceso de Importacion Ventas Realizado Correctamente")
    End Sub
End Class