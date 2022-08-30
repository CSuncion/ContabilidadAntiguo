Imports Entidad
Imports Datos

Public Class MovimientoContableDetalleRN
    Dim cam As New CamposEntidad
    Dim vista As String = "vsMovimientoContableDetalle"
    Sub nuevoMovimientoContableDetalle(ByRef ent As SuperEntidad)
        '//
        '/
        '/adiciona
        Dim tabAD As New MovimientoContableDetalleAD
        tabAD.SpNuevoMovimientoContableDetalle(ent)
    End Sub

    Sub ModificarMovimientoContableDetalle(ByRef ent As SuperEntidad)
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario

        '/adiciona
        Dim tabAD As New MovimientoContableDetalleAD
        tabAD.SpModificarMovimientoContableDetalle(ent)
    End Sub

    Function obtenerDetalleRegContabPorClave(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = Me.vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.ClaveRCC
        ent.DatoCondicion1 = ent.ClaveRegContabCabe
        ent.CampoOrden = cam.ClaveRCD
        Dim objAD As New RegContabDetaAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
        Return listObj
        '\\
    End Function


    Function obtenerDetalleRegContabPorClaveDeta(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = Me.vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.ClaveRCD
        ent.DatoCondicion1 = ent.ClaveRegContabDeta
        ent.CampoOrden = cam.ClaveRCD
        Dim objAD As New MovimientoContableDetalleAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
        Return listObj
        '\\
    End Function


    Function obtenerMovimientoDetalleXPeriodo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsMovimientoContableDetalle"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.PeriodoRCC
        ent.DatoCondicion1 = ent.PeriodoRegContabCabe
        ent.CampoCondicion2 = cam.CodEmp
        ent.DatoCondicion2 = SuperEntidad.xCodigoEmpresa

        Dim objAD As New MovimientoContableDetalleAD
        listObj = objAD.SpObtenerRegistrosConDosCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerMovimientoDetalleXDia(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsMovimientoContableDetalle"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.FecVouRCC
        ent.DatoCondicion1 = ent.FechaVoucherRegContabCabe.Year.ToString + "/" + ent.FechaVoucherRegContabCabe.Month.ToString + "/" + ent.FechaVoucherRegContabCabe.Day.ToString
        ent.CampoCondicion2 = cam.CodEmp
        ent.DatoCondicion2 = SuperEntidad.xCodigoEmpresa

        Dim objAD As New MovimientoContableDetalleAD
        listObj = objAD.SpObtenerRegistrosConDosCondicion(ent)
        Return listObj
        '\\
    End Function


    Function obtenerMovimientoDetalleXClaveCabe(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsMovimientoContableDetalle"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.ClaveRCC
        ent.DatoCondicion1 = ent.ClaveRegContabCabe
        'ent.CampoCondicion2 = cam.CodEmp
        'ent.DatoCondicion2 = SuperEntidad.xCodigoEmpresa

        Dim objAD As New MovimientoContableDetalleAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerDetalleRegContabPorPeriodo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = Me.vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.PeriodoRCC
        ent.DatoCondicion1 = ent.PeriodoRegContabCabe
        ent.CampoOrden = cam.CodOriRC
        Dim objAD As New RegContabDetaAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
        Return listObj
        '\\
    End Function

    Sub eliminarMovimientoContableDetalle(ByRef ent As SuperEntidad)
        '//
        '/Se elimina Fisicamente el registro
        Dim tabAD As New MovimientoContableDetalleAD
        ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        tabAD.SpEliminarMovimientoContableDetalle(ent)
    End Sub

    Function obtenerMovimientoDetalleXPeriodoYCuenta(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsMovimientoContableDetalle"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.PeriodoRCC
        ent.DatoCondicion1 = ent.PeriodoRegContabCabe
        ent.CampoCondicion2 = cam.CodEmp
        ent.DatoCondicion2 = SuperEntidad.xCodigoEmpresa
        ent.CampoCondicion3 = cam.CodCtaPcge
        ent.DatoCondicion3 = ent.CodigoCuentaPcge

        Dim objAD As New MovimientoContableDetalleAD
        listObj = objAD.SpObtenerRegistrosConTresCondicion(ent)

        Return listObj
        '\\
    End Function


    Function obtenerMovimientoDetalleXCuentaYEntrePeriodo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsMovimientoContableDetalle"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.CodCtaPcge
        ent.DatoCondicion1 = ent.CodigoCuentaPcge
        ent.CampoCondicion2 = cam.CodEmp
        ent.DatoCondicion2 = SuperEntidad.xCodigoEmpresa
        ent.CampoCondicion3 = cam.PeriodoRCC
        ent.CampoCondicion4 = cam.PeriodoRCC

        Dim objAD As New MovimientoContableDetalleAD
        listObj = objAD.SpObtenerRegistrosConDosCondicionYRango(ent)
        Return listObj
        '\\
    End Function



    Function obtenerMovimientoDetalleXAuxiliarYEntrePeriodo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsMovimientoContableDetalle"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.CodAux
        ent.DatoCondicion1 = ent.CodigoAuxiliar
        ent.CampoCondicion2 = cam.CodEmp
        ent.DatoCondicion2 = SuperEntidad.xCodigoEmpresa
        ent.CampoFiltro1 = cam.PeriodoRCC
        ent.DatoFiltro1 = ent.DatoFiltro1
        ent.CampoFiltro2 = cam.PeriodoRCC
        ent.DatoFiltro2 = ent.DatoFiltro2
        Dim objAD As New MovimientoContableDetalleAD
        listObj = objAD.SpObtenerRegistrosConDosCondicionDosFiltros(ent)
        Return listObj
        '\\
    End Function

    Function obtenerMovimientoDetalleXAuxiliarYEntrePeriodoXCuenta(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        Dim cuenta As String = ent.CodigoCuentaPcge
        listObj = Me.obtenerMovimientoDetalleXAuxiliarYEntrePeriodo(ent)
        'Filtrar solo de la cuenta
        Dim listobjcta As New List(Of SuperEntidad)
        For Each obj As SuperEntidad In listObj
            If obj.CodigoCuentaPcge = cuenta Then
                listobjcta.Add(obj)
            End If
        Next
        Return listobjcta
        '\\
    End Function

    Function obtenerMovimientoDetalleEntrePeriodoYCuenta(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsMovimientoContableDetalle"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.CodEmp
        ent.DatoCondicion1 = SuperEntidad.xCodigoEmpresa
        ent.CampoCondicion2 = cam.CodCtaPcge
        ent.DatoCondicion2 = ent.CodigoCuentaPcge
        ent.CampoFiltro1 = cam.PeriodoRCC
        ent.DatoFiltro1 = ent.DatoFiltro1
        ent.CampoFiltro2 = cam.PeriodoRCC
        ent.DatoFiltro2 = ent.DatoFiltro2
        Dim objAD As New MovimientoContableDetalleAD
        listObj = objAD.SpObtenerRegistrosConDosCondicionDosFiltros(ent)
        Return listObj
        '\\
    End Function

    Function obtenerMovimientoDetalleXAuxiliarYEntrePeriodoXCuentaSaldo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        listObj = Me.obtenerMovimientoDetalleEntrePeriodoYCuenta(ent)

        'Filtrar solo con auxilair 
        Dim listobjaux As New List(Of SuperEntidad)
        Dim lfin As New List(Of SuperEntidad)

        Dim clave As String = ""
        Dim claveanterior As String = ""
        Dim saldo As Decimal = 0
        Dim debe As Decimal = 0
        Dim haber As Decimal = 0
        Dim n As Integer = 0
        Dim m As Integer = listObj.Count

        For Each obj As SuperEntidad In listObj
            n += 1
            ' If obj.CodigoAuxiliar <> "" Then
            clave = obj.CodigoCuentaPcge + obj.CodigoAuxiliar + obj.TipoDocumento + obj.SerieDocumento + obj.NumeroDocumento
            'Si Debe / Haber 
            If clave = claveanterior Then
                listobjaux.Add(obj)
                If n = m Then
                    For Each x As SuperEntidad In listobjaux
                        If x.DebeHaberRegContabDeta = "Debe" Then
                            debe = debe + x.ImporteSRegContabDeta
                        Else
                            haber = haber + x.ImporteSRegContabDeta
                        End If
                    Next
                    saldo = debe - haber
                    'Documento para mostrar
                    If saldo <> 0 Then
                        lfin.AddRange(listobjaux)  'Llenado de documentos =s
                    End If
                End If
            Else
                For Each x As SuperEntidad In listobjaux
                    If x.DebeHaberRegContabDeta = "Debe" Then
                        debe = debe + x.ImporteSRegContabDeta
                    Else
                        haber = haber + x.ImporteSRegContabDeta
                    End If
                Next
                saldo = debe - haber
                'Documento para mostrar
                If saldo <> 0 Then
                    lfin.AddRange(listobjaux)  'Llenado de documentos =s
                End If
                'Limpia Lista y variables
                listobjaux.Clear()
                listobjaux.Add(obj)
                If n = m Then
                    If clave <> claveanterior Then
                        lfin.Add(obj)
                    End If
                End If
                debe = 0
                haber = 0
            End If

            claveanterior = clave

            'End If

        Next
        Return lfin
        '\\
    End Function

    Function ListarMovimientoDetalleXCuentaXAuxiliarEntrePeriodo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        Dim objAD As New MovimientoContableDetalleAD
        Return objAD.ListarMovimientoDetalleXCuentaXAuxiliarEntrePeriodo(ent)

        '\\
    End Function


    Function ListarSaldosPorAuxiliarYDocumentosTotal(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim iLisRes As New List(Of SuperEntidad)

        '// Trae una lista por auxlliares y documentos
        ent.CampoOrden = cam.CodAux + "," + cam.CodTipDoc + "," + cam.SerDoC + "," + cam.NumDoc
        Dim iLisMov As List(Of SuperEntidad) = Me.ListarMovimientoDetalleXCuentaXAuxiliarEntrePeriodo(ent)

        Dim xCodigoAuxiliar As String = ""
        Dim xDocumento As String = ""
        Dim xSaldo As Decimal = 0
        Dim xSaldoAcumulado As Decimal = 0
        Dim xAcumulador As Decimal = 0

        Dim iContador As Integer = 0
        Dim iNroObj As Integer = iLisMov.Count

        For Each xMov As SuperEntidad In iLisMov
            iContador += 1
            If xMov.DebeHaberRegContabDeta = "Debe" Then 'Debe
                'Este valor es para los cargos
                xMov.SumaDebeRegContabCabe = xMov.ImporteSRegContabDeta
                xMov.SumaHaberRegContabCabe = 0
            Else
                'Este valor es para los abonos
                xMov.SumaDebeRegContabCabe = 0
                xMov.SumaHaberRegContabCabe = xMov.ImporteSRegContabDeta
            End If
            'Si eldocumento es en US$ agregamos el importe al campo importedregcontabcabe, importdregcontabdeta
            If xMov.CodigoOrigen = "1" Or xMov.CodigoOrigen = "2" Or xMov.CodigoOrigen = "3" Then
                If xMov.Exporta = "US$" Or xMov.Exporta = "1" Then 'Soles
                    'Es valor es para la columna US$
                    xMov.ImporteRegContabCabe = xMov.ImporteDRegContabDeta
                Else
                    xMov.ImporteRegContabCabe = 0
                End If
            Else
                If xMov.MonedaDocumento = "Dolares" Or xMov.MonedaDocumento = "1" Then
                    xMov.ImporteRegContabCabe = xMov.ImporteDRegContabDeta
                Else
                    xMov.ImporteRegContabCabe = 0
                End If
            End If


            'Calcular saldo por auxiliar
            If xCodigoAuxiliar = xMov.CodigoAuxiliar Then

                If xDocumento = xMov.TipoDocumento + xMov.SerieDocumento + xMov.NumeroDocumento Then
                    xSaldo = xSaldo + xMov.SumaDebeRegContabCabe - xMov.SumaHaberRegContabCabe
                    xMov.SaldoCuentaCorriente = xSaldo
                    iLisRes.Add(xMov)
                Else
                    xSaldoAcumulado += xSaldo
                    xMov.SaldoCuentaCorriente = xMov.SumaDebeRegContabCabe - xMov.SumaHaberRegContabCabe
                    xSaldo = xMov.SaldoCuentaCorriente
                    iLisRes.Add(xMov)
                    xDocumento = xMov.TipoDocumento + xMov.SerieDocumento + xMov.NumeroDocumento
                End If
                If iContador = iNroObj Then
                    Dim xobj As New SuperEntidad
                    xobj.CodigoAuxiliar = xCodigoAuxiliar
                    xobj.CodigoCuentaPcge = xMov.CodigoCuentaPcge
                    xobj.GlosaRegContabDeta = "Total Auxiliar"
                    xobj.SaldoCuentaCorriente = xSaldoAcumulado + xSaldo
                    iLisRes.Add(xobj)
                End If

            Else
                If xCodigoAuxiliar <> "" Then
                    Dim xobj As New SuperEntidad
                    xobj.CodigoAuxiliar = xCodigoAuxiliar
                    xobj.CodigoCuentaPcge = xMov.CodigoCuentaPcge
                    xobj.GlosaRegContabDeta = "Total Auxiliar"
                    xobj.SaldoCuentaCorriente = xSaldoAcumulado + xSaldo
                    iLisRes.Add(xobj)
                    xSaldoAcumulado = 0
                End If
                xMov.SaldoCuentaCorriente = xMov.SumaDebeRegContabCabe - xMov.SumaHaberRegContabCabe
                xSaldo = xMov.SaldoCuentaCorriente
                iLisRes.Add(xMov)
                xCodigoAuxiliar = xMov.CodigoAuxiliar
                xDocumento = xMov.TipoDocumento + xMov.SerieDocumento + xMov.NumeroDocumento
                If iContador = iNroObj Then
                    Dim xobj As New SuperEntidad
                    xobj.CodigoAuxiliar = xCodigoAuxiliar
                    xobj.CodigoCuentaPcge = xMov.CodigoCuentaPcge
                    xobj.GlosaRegContabDeta = "Total Auxiliar"
                    xobj.SaldoCuentaCorriente = xSaldoAcumulado + xSaldo
                    iLisRes.Add(xobj)
                End If
            End If

        Next
        Return iLisRes

        '\\
    End Function

    Function ListarSaldosPorAuxiliarYDocumentosSaldo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim iLisSalHis As List(Of SuperEntidad) = Me.ListarSaldosPorAuxiliarYDocumentosTotal(ent)
        Dim iLisRes As New List(Of SuperEntidad)
        Dim iLisDoc As New List(Of SuperEntidad)

        For Each xMov As SuperEntidad In iLisSalHis
            'llenando cada documento
            iLisDoc.Add(xMov)
            If xMov.GlosaRegContabDeta = "Total Auxiliar" Then
                'chequear si este total auxiliar tiene saldo
                If xMov.SaldoCuentaCorriente <> 0 Then
                    iLisRes.AddRange(Me.ObtenerDocumentosPendientes(iLisDoc))
                End If
                iLisDoc.Clear()
            End If
        Next
        Return iLisRes
    End Function

    Function ObtenerDocumentosPendientes(ByRef pLisDoc As List(Of SuperEntidad)) As List(Of SuperEntidad)
        Dim iLisRes As New List(Of SuperEntidad)
        Dim iLisDoc As New List(Of SuperEntidad)
        Dim iDocumento As String = String.Empty
        Dim iObj As New SuperEntidad


        For Each xMov As SuperEntidad In pLisDoc

            If iDocumento = xMov.TipoDocumento + xMov.SerieDocumento + xMov.NumeroDocumento Then
                iLisDoc.Add(xMov)
            Else
                If iLisDoc.Count = 0 Then
                    iLisDoc.Add(xMov)
                Else
                    ''chequear si el documento esta pendiente
                    If iLisDoc.Item(iLisDoc.Count - 1).SaldoCuentaCorriente <> 0 Then
                        iLisRes.AddRange(iLisDoc)
                        iLisDoc.Clear()
                        iLisDoc.Add(xMov)
                        If xMov.GlosaRegContabDeta = "Total Auxiliar" And xMov.SaldoCuentaCorriente <> 0 Then
                            iLisRes.Add(xMov)
                        End If
                    Else
                        iLisDoc.Clear()
                        iLisDoc.Add(xMov)
                        If xMov.GlosaRegContabDeta = "Total Auxiliar" And xMov.SaldoCuentaCorriente <> 0 Then
                            iLisRes.Add(xMov)
                        End If
                    End If
                End If
                'iLisDoc.Add(xMov)
                iDocumento = xMov.TipoDocumento + xMov.SerieDocumento + xMov.NumeroDocumento
            End If
        Next
        Return iLisRes
    End Function

    'Function ObtenerDocumentosPendientes(ByRef pLisDoc As List(Of SuperEntidad)) As List(Of SuperEntidad)
    '    Dim iLisRes As New List(Of SuperEntidad)
    '    Dim iLisDoc As New List(Of SuperEntidad)
    '    Dim iDocumento As String = String.Empty
    '    Dim iObj As New SuperEntidad


    '    For Each xMov As SuperEntidad In pLisDoc

    '        If iDocumento = xMov.TipoDocumento + xMov.SerieDocumento + xMov.NumeroDocumento Then
    '            iLisDoc.Add(xMov)

    '        Else
    '            If iLisDoc.Count = 0 Then
    '                iLisDoc.Add(xMov)
    '            Else
    '                ''chequear si el documento esta pendiente
    '                If iLisDoc.Item(iLisDoc.Count - 1).SaldoCuentaCorriente <> 0 Then
    '                    iLisRes.AddRange(iLisDoc)
    '                    iLisDoc.Clear()
    '                    iLisDoc.Add(xMov)
    '                    If xMov.GlosaRegContabDeta = "Total Auxiliar" And xMov.SaldoCuentaCorriente <> 0 Then
    '                        iLisRes.Add(xMov)
    '                    End If
    '                Else
    '                    iLisDoc.Clear()
    '                    iLisDoc.Add(xMov)
    '                End If
    '            End If
    '            'iLisDoc.Add(xMov)
    '            iDocumento = xMov.TipoDocumento + xMov.SerieDocumento + xMov.NumeroDocumento
    '        End If
    '    Next
    '    Return iLisRes
    'End Function


    Function ListarSaldosXAuxiliar(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim iLisRes As New List(Of SuperEntidad)

        '// Trae una lista por auxlliares y documentos
        ent.CampoOrden = cam.CodAux
        Dim iLisMov As List(Of SuperEntidad) = Me.ListarMovimientoDetalleXCuentaXAuxiliarEntrePeriodo(ent)

        Dim xCodigoAuxiliar As String = ""
        Dim xIndiceObjeto As Integer = -1

        For Each xMov As SuperEntidad In iLisMov
            'Calcular saldo por auxiliar
            If xCodigoAuxiliar = xMov.CodigoAuxiliar Then
                'Modificamos el objeto
                If xMov.DebeHaberRegContabDeta = "Debe" Then 'Debe
                    'Este valor es para los cargos
                    iLisRes.Item(xIndiceObjeto).SaldoCuentaCorriente += xMov.ImporteSRegContabDeta
                Else
                    iLisRes.Item(xIndiceObjeto).SaldoCuentaCorriente -= xMov.ImporteSRegContabDeta
                End If

            Else
                If xMov.DebeHaberRegContabDeta = "Debe" Then 'Debe
                    'Este valor es para los cargos
                    xMov.SaldoCuentaCorriente = xMov.ImporteSRegContabDeta
                Else
                    xMov.SaldoCuentaCorriente = xMov.ImporteSRegContabDeta * (-1)
                End If
                iLisRes.Add(xMov)
                xIndiceObjeto += 1
                xCodigoAuxiliar = xMov.CodigoAuxiliar
            End If

        Next
        Return iLisRes

        '\\
    End Function

    Function ListarSaldosXAuxiliarConSaldo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim iLisMov As List(Of SuperEntidad) = Me.ListarSaldosXAuxiliar(ent)
        Dim iLisRes As New List(Of SuperEntidad)
        For Each xMov As SuperEntidad In iLisMov
            If xMov.SaldoCuentaCorriente <> 0 Then
                iLisRes.Add(xMov)
            End If
        Next
        Return iLisRes

    End Function


    Function obtenerMovimientoDetalleXUnAuxiliarYEntrePeriodoXCuenta(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        Dim auxiliar As String = ent.CodigoAuxiliar
        listObj = Me.obtenerMovimientoDetalleXAuxiliarYEntrePeriodoXCuentaSaldo(ent)
        'Filtrar solo de la cuenta
        Dim listobjcta As New List(Of SuperEntidad)
        For Each obj As SuperEntidad In listObj
            If obj.CodigoAuxiliar = auxiliar Then
                listobjcta.Add(obj)
            End If
        Next
        Return listobjcta
        '\\
    End Function


    Function obtenerMovimientoDetalleXCuentaAuxiliarResumenEntrePeriodo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)

        'OBTENER UNA LISTA DE CUENTA 
        Dim lisObj As New List(Of SuperEntidad)
        lisObj = Me.ListarMovimientoDetalleXCuentaXAuxiliarEntrePeriodo(ent)

        'SI LA LISTA ESTA VACIA SALE DE LA FUNCION
        If lisObj.Count = 0 Then Return lisObj

        'SI LA LISTA TIENE REGISTROS -->> CONTINUAMOS
        'LISTA PARA ACUMULAR LOS MONTOS POR MES
        Dim lisRes As New List(Of SuperEntidad)

        'PARA COMPARAR EL AUXILIAR 
        Dim cAux As String = ""

        'RECORREMOS CADA LETRA PENDIENTE
        For Each obj As SuperEntidad In lisObj
            If obj.CodigoAuxiliar = cAux Then
                'SI SON IGUALES ACUMULAMOS EL MONTO A ESE MES
                For Each xob As SuperEntidad In lisRes
                    If xob.CodigoAuxiliar = obj.CodigoAuxiliar Then
                        'ImporteSRegcontabdeta es el saldo
                        If obj.DebeHaberRegContabDeta = "Debe" Then
                            xob.ImporteSRegContabDeta = xob.ImporteSRegContabDeta + obj.ImporteSRegContabDeta

                            If obj.MonedaDocumento = "Dolares" Then
                                xob.ImporteDRegContabDeta = xob.ImporteDRegContabDeta + obj.ImporteDRegContabDeta
                            End If
                        Else
                            xob.ImporteSRegContabDeta = xob.ImporteSRegContabDeta + (-1) * obj.ImporteSRegContabDeta
                            If obj.MonedaDocumento = "Dolares" Then
                                xob.ImporteDRegContabDeta = xob.ImporteDRegContabDeta + (-1) * obj.ImporteDRegContabDeta
                            End If
                        End If
                    End If
                Next
            Else
                'SI SON DIFERENTES CREAMOS EL MES
                Dim oAux As New SuperEntidad
                oAux.CodigoAuxiliar = obj.CodigoAuxiliar
                oAux.DescripcionAuxiliar = obj.DescripcionAuxiliar
                'ImporteSRegcontabdeta es el saldo
                If obj.DebeHaberRegContabDeta = "Debe" Then
                    oAux.ImporteSRegContabDeta = obj.ImporteSRegContabDeta

                    If obj.MonedaDocumento = "Dolares" Then
                        oAux.ImporteDRegContabDeta = obj.ImporteDRegContabDeta
                    End If
                Else
                    oAux.ImporteSRegContabDeta = (-1) * obj.ImporteSRegContabDeta
                    If obj.MonedaDocumento = "Dolares" Then
                        oAux.ImporteDRegContabDeta = (-1) * obj.ImporteDRegContabDeta
                    End If

                End If

                'AGREGAMOS ALA LISTA DE MESES
                lisRes.Add(oAux)

                'CAMBIAMOS EL MES
                cAux = obj.CodigoAuxiliar
            End If
        Next

        'DEVOLVEMOS LA LISTA
        Return lisRes

    End Function

    Function obtenerMovimientoDetalleXCuentaAuxiliarResumenEntrePeriodo1(ByRef ent As SuperEntidad) As List(Of SuperEntidad)

        'OBTENER UNA LISTA DE CUENTA 
        Dim lisObj As New List(Of SuperEntidad)
        '  lisObj = Me.ListarMovimientoDetalleXCuentaXAuxiliarEntrePeriodo(ent)
        lisObj = Me.ListarMovimientoDetalleXCuentaXAuxiliarEntrePeriodo1(ent)

        'SI LA LISTA ESTA VACIA SALE DE LA FUNCION
        If lisObj.Count = 0 Then Return lisObj

        'SI LA LISTA TIENE REGISTROS -->> CONTINUAMOS
        'LISTA PARA ACUMULAR LOS MONTOS POR MES
        Dim lisRes As New List(Of SuperEntidad)

        'PARA COMPARAR EL AUXILIAR 
        Dim cAux As String = ""

        'RECORREMOS CADA LETRA PENDIENTE
        For Each obj As SuperEntidad In lisObj
            If obj.CodigoAuxiliar = cAux Then
                'SI SON IGUALES ACUMULAMOS EL MONTO A ESE MES
                For Each xob As SuperEntidad In lisRes
                    If xob.CodigoAuxiliar = obj.CodigoAuxiliar Then
                        'ImporteSRegcontabdeta es el saldo
                        If obj.DebeHaberRegContabDeta = "Debe" Then
                            xob.ImporteSRegContabDeta = xob.ImporteSRegContabDeta + obj.ImporteSRegContabDeta

                            If obj.MonedaDocumento = "Dolares" Then
                                xob.ImporteDRegContabDeta = xob.ImporteDRegContabDeta + obj.ImporteDRegContabDeta
                            End If
                        Else
                            xob.ImporteSRegContabDeta = xob.ImporteSRegContabDeta + (-1) * obj.ImporteSRegContabDeta
                            If obj.MonedaDocumento = "Dolares" Then
                                xob.ImporteDRegContabDeta = xob.ImporteDRegContabDeta + (-1) * obj.ImporteDRegContabDeta
                            End If
                        End If
                    End If
                Next
            Else
                'SI SON DIFERENTES CREAMOS EL MES
                Dim oAux As New SuperEntidad
                oAux.CodigoAuxiliar = obj.CodigoAuxiliar
                oAux.DescripcionAuxiliar = obj.DescripcionAuxiliar
                'ImporteSRegcontabdeta es el saldo
                If obj.DebeHaberRegContabDeta = "Debe" Then
                    oAux.ImporteSRegContabDeta = obj.ImporteSRegContabDeta

                    If obj.MonedaDocumento = "Dolares" Then
                        oAux.ImporteDRegContabDeta = obj.ImporteDRegContabDeta
                    End If

                Else
                    oAux.ImporteSRegContabDeta = (-1) * obj.ImporteSRegContabDeta
                    If obj.MonedaDocumento = "Dolares" Then
                        oAux.ImporteDRegContabDeta = (-1) * obj.ImporteDRegContabDeta
                    End If
                End If
                'oAux.MonedaDocumento = obj.MonedaDocumento

                'AGREGAMOS ALA LISTA DE MESES
                lisRes.Add(oAux)

                'CAMBIAMOS EL MES
                cAux = obj.CodigoAuxiliar
            End If
        Next

        'DEVOLVEMOS LA LISTA
        Return lisRes

    End Function

    Function ListarMovimientoDetalleXCuentaXAuxiliarEntrePeriodo1(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        Dim objAD As New MovimientoContableDetalleAD
        'Return objAD.ListarMovimientoDetalleXCuentaXAuxiliarEntrePeriodo(ent)
        Return objAD.ListarMovimientoDetalleXCuentaXAuxiliarEntrePeriodo1(ent)

        '\\
    End Function


    Function CuentaSimplificada(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim lisSim As New List(Of SuperEntidad)
        Dim lisMd As New List(Of SuperEntidad)
        'Dim lisSB As New List(Of SuperEntidad)

        ent.CampoOrden = cam.CodCtaPcge
        lisMd = Me.obtenerMovimientoDetalleXDia(ent)

        Dim cta As String = ""

        For n As Integer = 2 To 4
            Select Case n
                Case 2
                    For m As Integer = 0 To lisMd.Count - 1

                        If lisMd.Item(m).CodigoCuentaPcge.Substring(0, 2) = cta Then
                            'SI SON IGUALES ACUMULAMOS EL MONTO
                            For Each xob As SuperEntidad In lisSim
                                If xob.CodigoCuentaPcge = lisMd.Item(m).CodigoCuentaPcge.Substring(0, 2) Then
                                    'ImporteS Debe o Haber 
                                    If lisMd.Item(m).DebeHaberRegContabDeta = "Debe" Then
                                        xob.SumaDebeRegContabCabe = xob.SumaDebeRegContabCabe + lisMd.Item(m).ImporteSRegContabDeta
                                        'xob.sungresosDolCuentaBanco = xob.IngresosDolCuentaBanco + obj.ImporteDRegContabDeta
                                    Else
                                        xob.SumaHaberRegContabCabe = xob.SumaHaberRegContabCabe + lisMd.Item(m).ImporteSRegContabDeta
                                        'xob.SalidasDolCuentaBanco = xob.SalidasDolCuentaBanco + obj.ImporteDRegContabDeta
                                    End If
                                End If
                            Next
                        Else
                            'SI SON DIFERENTES CREAMOS la cuenta 
                            Dim oSB As New SuperEntidad
                            oSB.CodigoCuentaPcge = lisMd.Item(m).CodigoCuentaPcge.Substring(0, 2)
                            If lisMd.Item(m).DebeHaberRegContabDeta = "Debe" Then
                                oSB.SumaDebeRegContabCabe = lisMd.Item(m).ImporteSRegContabDeta
                                oSB.SumaHaberRegContabCabe = 0
                            Else
                                oSB.SumaHaberRegContabCabe = lisMd.Item(m).ImporteSRegContabDeta
                                oSB.SumaDebeRegContabCabe = 0
                            End If
                            oSB.SaldoMesSolCuentaBanco = 0
                            oSB.SaldoMesDolCuentaBanco = 0
                            'AGREGAMOS ALA LISTA DE MESES
                            lisSim.Add(oSB)
                            'CAMBIAMOS la cuenta
                            cta = lisMd.Item(m).CodigoCuentaPcge
                        End If

                    Next

                Case 3
                    cta = ""
                    For m As Integer = 0 To lisMd.Count - 1
                        If lisMd.Item(m).CodigoCuentaPcge.Substring(0, 3) = "402" Then
                            If lisMd.Item(m).CodigoCuentaPcge.Substring(0, 3) = cta Then
                                'SI SON IGUALES ACUMULAMOS EL MONTO
                                For Each xob As SuperEntidad In lisSim
                                    If xob.CodigoCuentaPcge = lisMd.Item(m).CodigoCuentaPcge.Substring(0, 3) Then
                                        'ImporteS Debe o Haber 
                                        If lisMd.Item(m).DebeHaberRegContabDeta = "Debe" Then
                                            xob.SumaDebeRegContabCabe = xob.SumaDebeRegContabCabe + lisMd.Item(m).ImporteSRegContabDeta
                                            'xob.sungresosDolCuentaBanco = xob.IngresosDolCuentaBanco + obj.ImporteDRegContabDeta
                                        Else
                                            xob.SumaHaberRegContabCabe = xob.SumaHaberRegContabCabe + lisMd.Item(m).ImporteSRegContabDeta
                                            'xob.SalidasDolCuentaBanco = xob.SalidasDolCuentaBanco + obj.ImporteDRegContabDeta
                                        End If
                                    End If
                                Next
                            Else
                                'SI SON DIFERENTES CREAMOS la cuenta 
                                Dim oSB As New SuperEntidad
                                oSB.CodigoCuentaPcge = lisMd.Item(m).CodigoCuentaPcge.Substring(0, 3)
                                If lisMd.Item(m).DebeHaberRegContabDeta = "Debe" Then
                                    oSB.SumaDebeRegContabCabe = lisMd.Item(m).ImporteSRegContabDeta
                                    oSB.SumaHaberRegContabCabe = 0
                                Else
                                    oSB.SumaHaberRegContabCabe = lisMd.Item(m).ImporteSRegContabDeta
                                    oSB.SumaDebeRegContabCabe = 0
                                End If
                                oSB.SaldoMesSolCuentaBanco = 0
                                oSB.SaldoMesDolCuentaBanco = 0
                                'AGREGAMOS ALA LISTA DE MESES
                                lisSim.Add(oSB)
                                'CAMBIAMOS la cuenta
                                cta = lisMd.Item(m).CodigoCuentaPcge
                            End If
                        End If


                    Next

                Case 4

                    cta = ""
                    For m As Integer = 0 To lisMd.Count - 1
                        If lisMd.Item(m).CodigoCuentaPcge.Substring(0, 4) = "4011" Or lisMd.Item(m).CodigoCuentaPcge.Substring(0, 4) = "4017" Then
                            If lisMd.Item(m).CodigoCuentaPcge.Substring(0, 4) = cta Then
                                'SI SON IGUALES ACUMULAMOS EL MONTO
                                For Each xob As SuperEntidad In lisSim
                                    If xob.CodigoCuentaPcge = lisMd.Item(m).CodigoCuentaPcge.Substring(0, 4) Then
                                        'ImporteS Debe o Haber 
                                        If lisMd.Item(m).DebeHaberRegContabDeta = "Debe" Then
                                            xob.SumaDebeRegContabCabe = xob.SumaDebeRegContabCabe + lisMd.Item(m).ImporteSRegContabDeta
                                            'xob.sungresosDolCuentaBanco = xob.IngresosDolCuentaBanco + obj.ImporteDRegContabDeta
                                        Else
                                            xob.SumaHaberRegContabCabe = xob.SumaHaberRegContabCabe + lisMd.Item(m).ImporteSRegContabDeta
                                            'xob.SalidasDolCuentaBanco = xob.SalidasDolCuentaBanco + obj.ImporteDRegContabDeta
                                        End If
                                    End If
                                Next
                            Else
                                'SI SON DIFERENTES CREAMOS la cuenta 
                                Dim oSB As New SuperEntidad
                                oSB.CodigoCuentaPcge = lisMd.Item(m).CodigoCuentaPcge.Substring(0, 4)
                                If lisMd.Item(m).DebeHaberRegContabDeta = "Debe" Then
                                    oSB.SumaDebeRegContabCabe = lisMd.Item(m).ImporteSRegContabDeta
                                    oSB.SumaHaberRegContabCabe = 0
                                Else
                                    oSB.SumaHaberRegContabCabe = lisMd.Item(m).ImporteSRegContabDeta
                                    oSB.SumaDebeRegContabCabe = 0
                                End If
                                oSB.SaldoMesSolCuentaBanco = 0
                                oSB.SaldoMesDolCuentaBanco = 0
                                'AGREGAMOS ALA LISTA DE MESES
                                lisSim.Add(oSB)
                                'CAMBIAMOS la cuenta
                                cta = lisMd.Item(m).CodigoCuentaPcge
                            End If
                        End If


                    Next

            End Select

        Next

        'RECORREMOS CADA CUENTA  
        Return lisSim
    End Function

    Function ListarMovimientoContableDetalleEntrePeriodoYCuentaFiltro(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        Dim objAD As New MovimientoContableDetalleAD
        Return objAD.ListarMovimientoContableDetalleEntrePeriodoYCuentaFiltro(ent)
        '\\
    End Function

    Function ReporteAnalisisGastos(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim iLisDetMov As New List(Of SuperEntidad)
        iLisDetMov = Me.ListarMovimientoContableDetalleEntrePeriodoYCuentaFiltro(ent)


        Dim iLisRes As New List(Of SuperEntidad)

        Dim iClave As String = String.Empty
        'OBJETO DE LA CUENTA DE 4 DIGITOS
        Dim iCueRN As New PlanCuentaGeRN
        Dim iCue4 As New SuperEntidad
        Dim iIndiceFila As Integer = -1

        For Each xobj As SuperEntidad In iLisDetMov
            If iClave <> xobj.CodigoCuentaPcge Then
                Dim iObj As New SuperEntidad
                iObj.CodigoCuentaPcge = xobj.CodigoCuentaPcge
                iObj.NombreCuentaPcge = xobj.NombreCuentaPcge
                If xobj.DebeHaberRegContabDeta = "Debe" Then
                    iObj.SumaDebeRegContabCabe = xobj.ImporteSRegContabDeta
                Else
                    iObj.SumaHaberRegContabCabe = xobj.ImporteSRegContabDeta
                End If
                'OBTENER EL NOMBRE DE LA CUENTA DE 4 DIGITOS
                iCue4.ClaveCuentaPcge = xobj.CodigoEmpresa + xobj.CodigoCuentaPcge.Substring(0, 4)
                iCue4 = iCueRN.buscarCuentaExisPorClave(iCue4)
                iObj.CodigoCuentaBanco = iCue4.CodigoCuentaPcge 'codigo cuenta a 4 digitos
                iObj.NombreCuenta1242 = iCue4.NombreCuentaPcge 'nombre cuenta a 4 digitos
                iLisRes.Add(iObj)
                iClave = xobj.CodigoCuentaPcge
                iIndiceFila += 1
            Else
                If xobj.DebeHaberRegContabDeta = "Debe" Then
                    iLisRes.Item(iIndiceFila).SumaDebeRegContabCabe += xobj.ImporteSRegContabDeta
                Else
                    iLisRes.Item(iIndiceFila).SumaHaberRegContabCabe += xobj.ImporteSRegContabDeta
                End If
            End If
        Next
        Return iLisRes
    End Function

    Function ReporteGastosXMes(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim iLisDetMov As New List(Of SuperEntidad)
        iLisDetMov = Me.ListarMovimientoContableDetalleEntrePeriodoYCuentaFiltro(ent)


        Dim iLisRes As New List(Of SuperEntidad)
        Dim iClave As String = String.Empty
        Dim iCueRN As New PlanCuentaGeRN
        Dim iCue4 As New SuperEntidad
        Dim iMonto As Decimal = 0
        Dim iIndiceFila As Integer = -1

        For Each xobj As SuperEntidad In iLisDetMov
            If iClave <> xobj.CodigoCuentaPcge Then
                Dim iObj As New SuperEntidad
                iObj.CodigoCuentaPcge = xobj.CodigoCuentaPcge
                iObj.NombreCuentaPcge = xobj.NombreCuentaPcge
                If xobj.DebeHaberRegContabDeta = "Debe" Then
                    iMonto = xobj.ImporteSRegContabDeta
                Else
                    iMonto = -xobj.ImporteSRegContabDeta
                End If
                'SEGUN MES
                Select Case xobj.PeriodoRegContabCabe.Substring(4, 2)
                    Case "01" : iObj.HabeS01SaldoContable = iMonto
                    Case "02" : iObj.HabeS02SaldoContable = iMonto
                    Case "03" : iObj.HabeS03SaldoContable = iMonto
                    Case "04" : iObj.HabeS04SaldoContable = iMonto
                    Case "05" : iObj.HabeS05SaldoContable = iMonto
                    Case "06" : iObj.HabeS06SaldoContable = iMonto
                    Case "07" : iObj.HabeS07SaldoContable = iMonto
                    Case "08" : iObj.HabeS08SaldoContable = iMonto
                    Case "09" : iObj.HabeS09SaldoContable = iMonto
                    Case "10" : iObj.HabeS10SaldoContable = iMonto
                    Case "11" : iObj.HabeS11SaldoContable = iMonto
                    Case "12" : iObj.HabeS12SaldoContable = iMonto
                End Select
                iObj.SaldoCuentaCorriente = iMonto
                'OBTENER EL NOMBRE DE LA CUENTA DE 4 DIGITOS
                iCue4.ClaveCuentaPcge = xobj.CodigoEmpresa + xobj.CodigoCuentaPcge.Substring(0, 4)
                iCue4 = iCueRN.buscarCuentaExisPorClave(iCue4)
                iObj.CodigoCuentaBanco = iCue4.CodigoCuentaPcge 'codigo cuenta a 4 digitos
                iObj.NombreCuenta1242 = iCue4.NombreCuentaPcge 'nombre cuenta a 4 digitos
                iLisRes.Add(iObj)
                iClave = xobj.CodigoCuentaPcge
                iIndiceFila += 1
            Else
                If xobj.DebeHaberRegContabDeta = "Debe" Then
                    iMonto = xobj.ImporteSRegContabDeta
                Else
                    iMonto = -xobj.ImporteSRegContabDeta
                End If
                'SEGUN MES
                Select Case xobj.PeriodoRegContabCabe.Substring(4, 2)
                    Case "01" : iLisRes.Item(iIndiceFila).HabeS01SaldoContable += iMonto
                    Case "02" : iLisRes.Item(iIndiceFila).HabeS02SaldoContable += iMonto
                    Case "03" : iLisRes.Item(iIndiceFila).HabeS03SaldoContable += iMonto
                    Case "04" : iLisRes.Item(iIndiceFila).HabeS04SaldoContable += iMonto
                    Case "05" : iLisRes.Item(iIndiceFila).HabeS05SaldoContable += iMonto
                    Case "06" : iLisRes.Item(iIndiceFila).HabeS06SaldoContable += iMonto
                    Case "07" : iLisRes.Item(iIndiceFila).HabeS07SaldoContable += iMonto
                    Case "08" : iLisRes.Item(iIndiceFila).HabeS08SaldoContable += iMonto
                    Case "09" : iLisRes.Item(iIndiceFila).HabeS09SaldoContable += iMonto
                    Case "10" : iLisRes.Item(iIndiceFila).HabeS10SaldoContable += iMonto
                    Case "11" : iLisRes.Item(iIndiceFila).HabeS11SaldoContable += iMonto
                    Case "12" : iLisRes.Item(iIndiceFila).HabeS12SaldoContable += iMonto
                End Select
                iLisRes.Item(iIndiceFila).SaldoCuentaCorriente += iMonto
            End If
        Next
        Return iLisRes
    End Function


    Function ListarMovimientoContableDetalleXPeriodoYCuenta(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New MovimientoContableDetalleAD
        Return objAD.ListarMovimientoContableDetalleXPeriodoYCuenta(ent)
        '\\
    End Function

    Function ListarMovimientoContableDetalleXPeriodoYCuenta(ByRef ent As SuperEntidad, ByRef pLista As List(Of SuperEntidad)) As List(Of SuperEntidad)
        Dim iLisRes As New List(Of SuperEntidad)

        For Each xMovDet As SuperEntidad In pLista
            If ent.CodigoCuentaPcge = xMovDet.CodigoCuentaPcge Then
                iLisRes.Add(xMovDet)
            End If
        Next
        Return iLisRes
    End Function


    Function ConvertirRegistroDetalleEnMovimientoDetalle(ByVal pRcd As SuperEntidad) As SuperEntidad
        Dim iMcd As New SuperEntidad
        iMcd.ClaveRegContabDeta = pRcd.ClaveRegContabDeta
        iMcd.ClaveRegContabCabe = pRcd.ClaveRegContabCabe
        iMcd.CodigoEmpresa = pRcd.CodigoEmpresa
        iMcd.CorrelativoRegContabDeta = pRcd.CorrelativoRegContabDeta
        iMcd.CodigoIngEgr = pRcd.CodigoIngEgr
        iMcd.CodigoAuxiliar = pRcd.CodigoAuxiliar
        iMcd.TipoDocumento = pRcd.TipoDocumento
        iMcd.SerieDocumento = pRcd.SerieDocumento
        iMcd.NumeroDocumento = pRcd.NumeroDocumento
        iMcd.FechaDocumento = pRcd.FechaDocumento
        iMcd.VentaTipoCambio = pRcd.VentaTipoCambio
        iMcd.CodigoCuentaPcge = pRcd.CodigoCuentaPcge
        iMcd.CodigoCentroCosto = pRcd.CodigoCentroCosto
        iMcd.DebeHaberRegContabDeta = pRcd.DebeHaberRegContabDeta
        iMcd.ImporteSRegContabDeta = pRcd.ImporteSRegContabDeta
        iMcd.ImporteDRegContabDeta = pRcd.ImporteDRegContabDeta
        iMcd.ImporteERegContabDeta = pRcd.ImporteERegContabDeta
        iMcd.GlosaRegContabDeta = pRcd.GlosaRegContabDeta
        iMcd.Cuenta1242 = pRcd.Cuenta1242
        iMcd.EstadoRegContabDeta = pRcd.EstadoRegContabDeta
        iMcd.EstadoRegistro = pRcd.EstadoRegistro
        iMcd.CodigoArea = pRcd.CodigoArea
        iMcd.CodigoFlujoCaja = pRcd.CodigoFlujoCaja
        iMcd.Exporta = pRcd.Exporta
        iMcd.EliminadoRegistro = pRcd.EliminadoRegistro
        iMcd.PeriodoRegContabCabe = pRcd.PeriodoRegContabCabe
        iMcd.CodigoGastoReparable = pRcd.CodigoGastoReparable
        Return iMcd
    End Function


    Sub nuevoMovimientoContableDetalleMasivo(ByRef pLista As List(Of SuperEntidad))
        Dim tabAD As New MovimientoContableDetalleAD
        tabAD.SpNuevoMovimientoContableDetalleMasivo(pLista)
    End Sub
    Function ListarMovimientosAuxiliarTodos(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim iLisRes As New List(Of SuperEntidad)

        '// Trae una lista por auxlliares y documentos
        Dim iLisMov As List(Of List(Of SuperEntidad)) = Me.ListarMovimientoDetalleParaAuxiliaresTodos(ent)

        'recorrer cada lista de auxiliar
        For Each xLisMovAux As List(Of SuperEntidad) In iLisMov
            Dim xCodigoCuenta As String = ""
            Dim xDocumento As String = ""
            Dim xSaldo As Decimal = 0
            Dim xSaldoAcumulado As Decimal = 0
            Dim xAcumulador As Decimal = 0

            Dim iContador As Integer = 0
            Dim iNroObj As Integer = xLisMovAux.Count

            For Each xMov As SuperEntidad In xLisMovAux
                iContador += 1
                If xMov.DebeHaberRegContabDeta = "Debe" Then 'Debe
                    'Este valor es para los cargos
                    xMov.SumaDebeRegContabCabe = xMov.ImporteSRegContabDeta
                    xMov.SumaHaberRegContabCabe = 0
                Else
                    'Este valor es para los abonos
                    xMov.SumaDebeRegContabCabe = 0
                    xMov.SumaHaberRegContabCabe = xMov.ImporteSRegContabDeta
                End If
                'Si eldocumento es en US$ agregamos el importe al campo importedregcontabcabe, importdregcontabdeta
                If xMov.CodigoOrigen = "1" Or xMov.CodigoOrigen = "2" Or xMov.CodigoOrigen = "3" Then
                    If xMov.Exporta = "US$" Or xMov.Exporta = "1" Then 'Soles
                        'Es valor es para la columna US$
                        xMov.ImporteRegContabCabe = xMov.ImporteDRegContabDeta
                    Else
                        xMov.ImporteRegContabCabe = 0
                    End If
                Else
                    If xMov.MonedaDocumento = "Dolares" Or xMov.MonedaDocumento = "1" Then
                        xMov.ImporteRegContabCabe = xMov.ImporteDRegContabDeta
                    Else
                        xMov.ImporteRegContabCabe = 0
                    End If
                End If


                'Calcular saldo por auxiliar
                If xCodigoCuenta = xMov.CodigoCuentaPcge Then

                    If xDocumento = xMov.TipoDocumento + xMov.SerieDocumento + xMov.NumeroDocumento Then
                        xSaldo = xSaldo + xMov.SumaDebeRegContabCabe - xMov.SumaHaberRegContabCabe
                        xMov.SaldoCuentaCorriente = xSaldo
                        iLisRes.Add(xMov)
                    Else
                        xSaldoAcumulado += xSaldo
                        xMov.SaldoCuentaCorriente = xMov.SumaDebeRegContabCabe - xMov.SumaHaberRegContabCabe
                        xSaldo = xMov.SaldoCuentaCorriente
                        iLisRes.Add(xMov)
                        xDocumento = xMov.TipoDocumento + xMov.SerieDocumento + xMov.NumeroDocumento
                    End If
                    If iContador = iNroObj Then
                        Dim xobj As New SuperEntidad
                        xobj.CodigoAuxiliar = xMov.CodigoAuxiliar
                        xobj.DescripcionAuxiliar = xMov.DescripcionAuxiliar
                        xobj.CodigoCuentaPcge = xCodigoCuenta
                        xobj.GlosaRegContabDeta = "Total Cuenta"
                        xobj.SaldoCuentaCorriente = xSaldoAcumulado + xSaldo
                        iLisRes.Add(xobj)
                    End If

                Else
                    If xCodigoCuenta <> "" Then
                        Dim xobj As New SuperEntidad
                        xobj.CodigoAuxiliar = xMov.CodigoAuxiliar
                        xobj.DescripcionAuxiliar = xMov.DescripcionAuxiliar
                        xobj.CodigoCuentaPcge = xCodigoCuenta
                        xobj.GlosaRegContabDeta = "Total Cuenta"
                        xobj.SaldoCuentaCorriente = xSaldoAcumulado + xSaldo
                        iLisRes.Add(xobj)
                        xSaldoAcumulado = 0
                    End If
                    xMov.SaldoCuentaCorriente = xMov.SumaDebeRegContabCabe - xMov.SumaHaberRegContabCabe
                    xSaldo = xMov.SaldoCuentaCorriente
                    iLisRes.Add(xMov)
                    xCodigoCuenta = xMov.CodigoCuentaPcge
                    xDocumento = xMov.TipoDocumento + xMov.SerieDocumento + xMov.NumeroDocumento
                    If iContador = iNroObj Then
                        Dim xobj As New SuperEntidad
                        xobj.CodigoAuxiliar = xMov.CodigoAuxiliar
                        xobj.DescripcionAuxiliar = xMov.DescripcionAuxiliar
                        xobj.CodigoCuentaPcge = xCodigoCuenta
                        xobj.GlosaRegContabDeta = "Total Cuenta"
                        xobj.SaldoCuentaCorriente = xSaldoAcumulado + xSaldo
                        iLisRes.Add(xobj)
                    End If
                End If
            Next
        Next

        Return iLisRes
        '\\
    End Function

    Function ListarMovimientoDetalleParaAuxiliaresTodos(ByRef ent As SuperEntidad) As List(Of List(Of SuperEntidad))
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        Dim objAD As New MovimientoContableDetalleAD
        Return objAD.ListarMovimientoDetalleParaAuxiliaresTodos(ent)

        '\\
    End Function

    Function ListarMovimientoParaLibroDiarioEnero(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        Dim objAD As New MovimientoContableDetalleAD
        Return objAD.ListarMovimientoParaLibroDiarioEnero(ent)

        '\\
    End Function


    Function ListarMovimientoParaLibroDiarioDiciembre(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        Dim objAD As New MovimientoContableDetalleAD
        Return objAD.ListarMovimientoParaLibroDiarioDiciembre(ent)

        '\\
    End Function


    Function ListarMovimientosContablesDetalleXOrigenes(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New MovimientoContableDetalleAD
        Return objAD.ListarMovimientosContablesDetalleXOrigenes(ent)
        '\\
    End Function


    Function ListarSaldosDocumentosXCuenta(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        'lista resultado
        Dim iLisRes As New List(Of SuperEntidad)

        'tarer todo el movimiento de auxiliares
        ent.CodigoAuxiliar = ""
        ent.CodigoCuentaPcge = ""
        ent.CampoOrden = cam.CodAux + "," + cam.CodCtaPcge + "," + cam.CodTipDoc + "," + cam.SerDoC + "," + cam.NumDoc + "," + cam.DebHabRCD
        Dim iLisLisAux As List(Of List(Of SuperEntidad)) = Me.ListarMovimientoDetalleParaAuxiliaresTodos(ent)

        'variables
        Dim iClave As String = ""
        Dim iIndice As Integer = -1

        'recorrer cada lista
        For Each xLisAux As List(Of SuperEntidad) In iLisLisAux

            For Each xMcd As SuperEntidad In xLisAux
                If xMcd.CodigoAuxiliar + xMcd.CodigoCuentaPcge + xMcd.TipoDocumento + xMcd.SerieDocumento + xMcd.NumeroDocumento <> iClave Then
                    'armando la clave para compararlo con la cuenta corriente
                    xMcd.ClaveDocumentoCuentaCorriente = xMcd.CodigoEmpresa + xMcd.CodigoAuxiliar + xMcd.TipoDocumento + xMcd.SerieDocumento + xMcd.NumeroDocumento

                    'poner el valor de inicio segun debe o haber
                    'el saldo se tratara en el campo (SaldoCuentaBanco)
                    If xMcd.DebeHaberRegContabDeta = "Debe" Then
                        xMcd.SaldoCuentaBanco = xMcd.ImporteSRegContabDeta 'saldo en soles
                        xMcd.SaldoMesDolCuentaBanco = xMcd.ImporteDRegContabDeta 'saldo en dolares
                        xMcd.DebeS00SaldoContable = xMcd.ImporteSRegContabDeta 'suma debe soles
                        xMcd.DebeD00SaldoContable = xMcd.ImporteDRegContabDeta 'suma debe dolares
                    Else
                        xMcd.SaldoCuentaBanco = -xMcd.ImporteSRegContabDeta
                        xMcd.SaldoMesDolCuentaBanco = -xMcd.ImporteDRegContabDeta
                        xMcd.HabeS00SaldoContable = xMcd.ImporteSRegContabDeta 'suma haber soles
                        xMcd.HabeD00SaldoContable = xMcd.ImporteDRegContabDeta 'suma haber dolares
                    End If
                    iLisRes.Add(xMcd)
                    iClave = xMcd.CodigoAuxiliar + xMcd.CodigoCuentaPcge + xMcd.TipoDocumento + xMcd.SerieDocumento + xMcd.NumeroDocumento
                    iIndice += 1
                Else
                    If xMcd.DebeHaberRegContabDeta = "Debe" Then
                        iLisRes(iIndice).SaldoCuentaBanco += xMcd.ImporteSRegContabDeta
                        iLisRes(iIndice).SaldoMesDolCuentaBanco += xMcd.ImporteDRegContabDeta
                        iLisRes(iIndice).DebeS00SaldoContable += xMcd.ImporteSRegContabDeta
                        iLisRes(iIndice).DebeD00SaldoContable += xMcd.ImporteDRegContabDeta
                    Else
                        iLisRes(iIndice).SaldoCuentaBanco -= xMcd.ImporteSRegContabDeta
                        iLisRes(iIndice).SaldoMesDolCuentaBanco -= xMcd.ImporteDRegContabDeta
                        iLisRes(iIndice).HabeS00SaldoContable += xMcd.ImporteSRegContabDeta
                        iLisRes(iIndice).HabeD00SaldoContable += xMcd.ImporteDRegContabDeta
                    End If
                End If
            Next

        Next
        Return iLisRes
    End Function


End Class
