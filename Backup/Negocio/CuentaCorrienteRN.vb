Imports Entidad
Imports Datos

Public Class CuentaCorrienteRN
    Dim cam As New CamposEntidad

    Function obtenerFileAutogeneradoManual(ByRef ent As SuperEntidad) As String
        Dim objAD As New RegContabCabeAD
        Return objAD.SpAutogenerarFileManual(ent)
    End Function


    Sub nuevoCuentaCorriente(ByRef ent As SuperEntidad)
        '//
        '/Estos Datos son por defecto cada vez que agregua un registro compras

        ent.Exporta = "0"
        ent.EstadoRegistro = "1"
        ent.EliminadoRegistro = "1"
        ent.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioAgrega = SuperEntidad.xNombreUsuario
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuarioModifica
        ent.ClaveCuentaCorriente = ent.CodigoEmpresa + ent.PeriodoRegContabCabe + ent.CodigoOrigen + ent.CodigoFile + ent.NumeroVoucherRegContabCabe
        ent.ClaveDocumentoCuentaCorriente = ent.CodigoEmpresa + ent.CodigoAuxiliar + ent.TipoDocumento + ent.SerieDocumento + ent.NumeroDocumento
        'ent.AnoMesDiasPorMes = ent.AnoDiasPorMes + "/" + ent.CodigoMes
        Dim objAD As New CuentaCorrienteAD
        objAD.SpNuevoCuentaCorriente(ent)
        '\\

    End Sub

    Sub modificarCuentaCorriente(ByRef ent As SuperEntidad)
        '//
        '/Vovemos a traer el usuario actual de la b.d
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuarioModifica
        '/Vovemos a traer el usuario actual de la b.d
        ''/Mandamos a modificar la b.d
        Dim objAD As New CuentaCorrienteAD
        objAD.SpModificarCuentaCorriente(ent)
        '\\
    End Sub

    Sub EliminarCuentaCorrienteLog(ByRef ent As SuperEntidad)
        '//
        '/Datos por defecto
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.CodigoPersonalModifica = SuperEntidad.xCodigoPersonal
        ent.EliminadoRegistro = "0"
        '/Mandamos a modificar la b.d
        Dim objAD As New CuentaCorrienteAD
        objAD.SpModificarCuentaCorriente(ent)
        '\\
    End Sub

    Sub eliminarCuentaCorrienteFis(ByRef ent As SuperEntidad)
        '//
        Dim objAD As New CuentaCorrienteAD
        objAD.SpEliminarCuentaCorriente(ent)
        '\\
    End Sub


    'Sub eliminarCuentaCorrienteFisXDocumento(ByRef ent As SuperEntidad)
    '    '//
    '    Dim objAD As New CuentaCorrienteAD
    '    objAD.SpEliminarCuentaCorrienteXDocumento(ent)
    '    '\\
    'End Sub

    Function obtenerCuentaCorriente(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsCuentaCorriente"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.CodOriRC
        ent.CampoCondicion2 = cam.CodEmp
        ent.DatoCondicion2 = SuperEntidad.xCodigoEmpresa
        Dim objAD As New CuentaCorrienteAD
        listObj = objAD.SpObtenerRegistrosConDosCondicion(ent)
        Return listObj
        '\\
    End Function


    Function obtenerCuentaCorrienteExis(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsCuentaCorriente"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        Dim objAD As New CuentaCorrienteAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerCuentaCorrienteExisXOrigenFileYPeriodo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsCuentaCorriente"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.CodOriRC
        ent.DatoCondicion1 = ent.CodigoOrigen
        ent.CampoCondicion2 = cam.PeriodoRCC
        ent.DatoCondicion2 = ent.PeriodoRegContabCabe
        ent.CampoCondicion3 = cam.CodEmp
        ent.DatoCondicion3 = ent.CodigoEmpresa
        ent.CampoCondicion4 = cam.CodFilRC
        ent.DatoCondicion4 = ent.CodigoFile
        Dim objAD As New RegContabCabeAD
        listObj = objAD.SpObtenerRegistrosConCuatroCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerCuentaCorrienteEntreFechas(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        ent.Vista = "VsCuentaCorriente"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.CodOriRC
        ent.CampoFecha = cam.FecVouRCC
        Dim objAD As New CuentaCorrienteAD
        Return objAD.SpObtenerRegistrosEntreFechas(ent)
    End Function

    Function obtenerCuentaCorrientePorPeriodo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsCuentaCorriente"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        'ent.CampoCondicion1 = cam.CodOriRC
        ent.CampoCondicion1 = cam.PeriodoRCC
        ent.DatoCondicion1 = ent.PeriodoRegContabCabe
        ent.CampoCondicion2 = cam.CodEmp
        ent.DatoCondicion2 = SuperEntidad.xCodigoEmpresa
        Dim objAD As New CuentaCorrienteAD
        listObj = objAD.SpObtenerRegistrosConDosCondicion(ent)
        Return listObj
        '\\
    End Function

    Function buscarCuentaCorrienteExisPorClaveCC(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsCuentaCorriente"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.ClaveCtaCte
        ent.DatoCondicion1 = ent.ClaveCuentaCorriente
        Dim objAD As New CuentaCorrienteAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarCuentaCorrienteExisPorClaveDoc(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsCuentaCorriente"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.ClaveDocuCtaCte
        ent.DatoCondicion1 = ent.ClaveDocumentoCuentaCorriente
        Dim objAD As New CuentaCorrienteAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function


    Function buscarCuentaCorrienteExisPorClaveDocYClaveCCte(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsCuentaCorriente"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.ClaveDocuCtaCte
        ent.DatoCondicion1 = ent.ClaveDocumentoCuentaCorriente
        ent.CampoCondicion2 = cam.ClaveCtaCte
        ent.DatoCondicion2 = ent.ClaveCuentaCorriente
        Dim objAD As New CuentaCorrienteAD
        obj = objAD.SpBuscarRegistroConDosCondicion(ent)
        Return obj
        '\\
    End Function

    Function EsDocumentoRegistrado(ByRef ent As SuperEntidad) As Boolean
        Dim obj As New SuperEntidad
        obj.ClaveDocumentoCuentaCorriente = ent.CodigoEmpresa + ent.CodigoAuxiliar + ent.TipoDocumento + ent.SerieDocumento + ent.NumeroDocumento
        obj = Me.buscarCuentaCorrienteExisPorClaveDoc(obj)
        If obj.ClaveDocumentoCuentaCorriente = "" Then
            Return False
        Else
            Return True
        End If

    End Function


    Function EsDocumentoRegistradoEnOtroRegistroC(ByRef ent As SuperEntidad) As Boolean
        Dim obj As New SuperEntidad
        obj.ClaveCuentaCorriente = ent.ClaveCuentaCorriente
        obj.ClaveDocumentoCuentaCorriente = ent.CodigoEmpresa + ent.CodigoAuxiliar + ent.TipoDocumento + ent.SerieDocumento + ent.NumeroDocumento
        obj = Me.buscarCuentaCorrienteExisPorClaveDoc(obj)
        If obj.ClaveDocumentoCuentaCorriente = "" Then
            Return False
        Else
            If obj.ClaveCuentaCorriente = ent.ClaveCuentaCorriente Then
                Return False
            Else
                Return True
            End If

        End If

    End Function

    Function obtenerCuentaCorrienteExisXEmpresaXAuxiliarYPendientes(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsCuentaCorriente"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.CodEmp
        ent.DatoCondicion1 = ent.CodigoEmpresa
        ent.CampoCondicion2 = cam.CodAux
        ent.DatoCondicion2 = ent.CodigoAuxiliar
        ent.CampoCondicion3 = cam.EstCtaCte
        ent.DatoCondicion3 = "1"
        ent.CampoOrden = cam.CodTipDoc + "," + cam.SerDoC + "," + cam.NumDoc

        Dim objAD As New CuentaCorrienteAD
        listObj = objAD.SpObtenerRegistrosConTresCondicion(ent)
        Return listObj
        '\\
    End Function


    Function obtenerCuentaCorrienteExisXEmpresaYPendientes(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsCuentaCorriente"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.CodEmp
        ent.DatoCondicion1 = ent.CodigoEmpresa
        ent.CampoCondicion2 = cam.EstCtaCte
        ent.DatoCondicion2 = "1"

        Dim objAD As New CuentaCorrienteAD
        listObj = objAD.SpObtenerRegistrosConDosCondicion(ent)
        Return listObj
        '\\
    End Function


    Function ListarDocumentosAPagarXEmpresaXAuxiliarYPendientes(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New CuentaCorrienteAD
        ent.CampoOrden = cam.CodTipDoc + "," + cam.SerDoC + "," + cam.NumDoc
        Return objAD.ListarDocumentosAPagarXEmpresaXAuxiliarYPendientes(ent)
        '\\
    End Function


    Function ListarDocumentosACobrarXEmpresaXAuxiliarYPendientes(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New CuentaCorrienteAD
        ent.CampoOrden = cam.CodTipDoc + "," + cam.SerDoC + "," + cam.NumDoc
        Return objAD.ListarDocumentosACobrarXEmpresaXAuxiliarYPendientes(ent)
        '\\
    End Function

    Function ListarDocumentosACobrarXEmpresaYPendientes(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New CuentaCorrienteAD
        ent.CampoOrden = cam.CodTipDoc + "," + cam.SerDoC + "," + cam.NumDoc
        Return objAD.ListarDocumentosACobrarXEmpresaYPendientes(ent)
        '\\
    End Function


    Function ListarDocumentosAPagarXEmpresaYPendientes(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New CuentaCorrienteAD
        ent.CampoOrden = cam.CodTipDoc + "," + cam.SerDoC + "," + cam.NumDoc
        Return objAD.ListarDocumentosAPagarXEmpresaYPendientes(ent)
        '\\
    End Function


    Function obtenerCuentaCorrienteExisXEmpresa(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsCuentaCorriente"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.CodEmp
        ent.DatoCondicion1 = ent.CodigoEmpresa

        Dim objAD As New CuentaCorrienteAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
        Return listObj
        '\\
    End Function

    Function ListarCuentasCorrientesXEmpresaXPeriodoXDolaresYPendientes(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New CuentaCorrienteAD
        Return objAD.ListarCuentasCorrientesXEmpresaXPeriodoXDolaresYPendientes(ent)
        '\\
    End Function

    Function ListarCuentasCorrientesXEmpresaXDolaresYPendientes(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New CuentaCorrienteAD
        Return objAD.ListarCuentasCorrientesXEmpresaXDolaresYPendientes(ent)
        '\\
    End Function

    Function EsDocumentoReferenciaRegistrado(ByRef ent As SuperEntidad) As SuperEntidad
        Dim obj As New SuperEntidad
        obj.ClaveDocumentoCuentaCorriente = ent.CodigoEmpresa + ent.CodigoAuxiliar + ent.TipoDocumento + ent.SerieDocumento + ent.NumeroDocumento
        obj = Me.buscarCuentaCorrienteExisPorClaveDoc(obj)
        If obj.ClaveDocumentoCuentaCorriente = "" Then
            obj.Mensaje = "No se encontro el documento referencia ,No se puede realizar la operacion"
            obj.EsVerdad = False
        Else
            'PREGUNTAR SI EL DOCUMENTO ESTA CANCELADO
            If obj.EstadoCuentaCorriente = "0" Then 'cancelado
                obj.Mensaje = "Este documento ya esta cancelado ,No se puede realizar la operacion"
                obj.EsVerdad = False
            Else
                'VER SI EL IMPORTE DE LA REBAJA ES MENOR AL DEL SALDO DEL DOCUMENTO
                'QUE SE DESEA REFENECIAR ESTA NOTA DE CREDITO
                'If ent.PrecioVtaRegContabCabe > obj.SaldoCuentaCorriente Then
                '    obj.Mensaje = "El monto de la nota de credito no puede ser mayor al saldo del docuemnto a referenciar ,No se puede realizar la operacion"
                '    obj.EsVerdad = False
                'Else
                '    obj.EsVerdad = True
                'End If
                obj.EsVerdad = True
            End If
        End If
        Return obj
    End Function

    Function ReporteCuentasXPagar(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New CuentaCorrienteAD
        Return objAD.ReporteCuentasXPagar(ent)
        '\\
    End Function

    Function ReporteCuentasXCobrar(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New CuentaCorrienteAD
        Return objAD.ReporteCuentasXCobrar(ent)
        '\\
    End Function


    Function ListarCuentasCorrientesParaDiferenciaDeCambio(ByRef ent As SuperEntidad) As List(Of SuperEntidad)

        'LISTA RESULTADO
        Dim iLisRes As New List(Of SuperEntidad)

        'TRAER LA LISTA DE CUENTAS CORRIENTES MENORES O IGUALES AL PERIODO EN PROCESO
        ent.CampoOrden = cam.ClaveDocuCtaCte
        Dim iLisCueCor As List(Of SuperEntidad) = Me.ListarCuentasCorrientesXEmpresaXDolares(ent)

        'TRAER LA LISTA DE PAGOS QUE SE PUDIERON HACER DESPUES DE ESTE PERIODO
        Dim iRcdRN As New RegContabDetaRN
        ent.CampoOrden = cam.CodEmp + "," + cam.CodAux + "," + cam.CodTipDoc + "," + cam.SerDoC + "," + cam.NumDoc
        Dim iLisPag As List(Of SuperEntidad) = iRcdRN.ListarRegistrosContablesDetalleParaDiferenciaCambio(ent)

        'TRAER LA LISTA DE LAS NOTAS DE CREDITO QUE SE PUDIERON HACER DESPUES DE ESTE PERIODO
        Dim iRccRN As New RegContabCabeRN
        ent.CampoOrden = cam.CodEmp + "," + cam.CodAux + "," + cam.CodTipDoc + "," + cam.SerDoC + "," + cam.NumDoc
        Dim iLisNotas As List(Of SuperEntidad) = iRccRN.ListarNotasCreditoParaDiferenciaCambio(ent)


        For Each xCueCor As SuperEntidad In iLisCueCor

            'RECORRER CADA DOCUMENTO DE LA CUENTA CORRIENTE EN LOS PAGOS
            'Y SI ENCUENTRA IR REDUCIENDO LOS MONTOS
            For Each xPag As SuperEntidad In iLisPag
                If xCueCor.ClaveDocumentoCuentaCorriente = xPag.CodigoEmpresa + xPag.CodigoAuxiliar + xPag.TipoDocumento + xPag.SerieDocumento + xPag.NumeroDocumento Then
                    If xCueCor.CodigoCuentaPcge = xPag.CodigoCuentaPcge Then
                        xCueCor.ImportePagadoCuentaCorriente = xCueCor.ImportePagadoCuentaCorriente - xPag.ImporteDRegContabDeta
                        xCueCor.SaldoCuentaCorriente = xCueCor.SaldoCuentaCorriente + xPag.ImporteDRegContabDeta
                        xCueCor.EstadoCuentaCorriente = "1" 'pendiente
                    End If
                End If
            Next

            'RECORRER CADA DOCUMENTO DE LA CUENTA CORRIENTE EN LAS NOTAS DE CREDITO
            'Y SI ENCUENTRA IR REDUCIENDO LOS MONTOS
            For Each xNot As SuperEntidad In iLisNotas
                If xCueCor.ClaveDocumentoCuentaCorriente = xNot.CodigoEmpresa + xNot.CodigoAuxiliar + xNot.TipoDocumento1 + xNot.SerieDocumento1 + xNot.NumeroDocumento1 Then
                    If xCueCor.CodigoCuentaPcge = xNot.CodigoCuentaBanco Then
                        'VOLVER A SU IMPORTE NORMAL (PREGUNTAR SI LA NOTA FUE DE MAYOR VALOR QUE EL SALDO DEL DOCUMENTO)
                        If xCueCor.ClaveNotaCredito = xNot.CodigoEmpresa + xNot.CodigoAuxiliar + xNot.TipoDocumento + xNot.SerieDocumento + xNot.NumeroDocumento Then
                            xCueCor.ImporteOriginalCuentaCorriente += xCueCor.ValorNotaCredito
                            xCueCor.SaldoCuentaCorriente = xCueCor.ValorNotaCredito
                        Else
                            xCueCor.ImporteOriginalCuentaCorriente += xNot.PrecioVtaRegContabCabe
                            xCueCor.SaldoCuentaCorriente = xCueCor.ImporteOriginalCuentaCorriente - xCueCor.ImportePagadoCuentaCorriente
                        End If
                        xCueCor.EstadoCuentaCorriente = "1" 'pendiente
                    End If
                End If
            Next

            'SOLO PASAN LOS PENDIENTES
            If xCueCor.EstadoCuentaCorriente = "1" Then
                iLisRes.Add(xCueCor)
            End If

        Next
        Return iLisRes
    End Function

    Function ListarActualizarCuentasCorientes(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        'cargar los saldos de documentos por cuenta
        Dim iMcdRN As New MovimientoContableDetalleRN
        Dim iLisSalAux As List(Of SuperEntidad) = iMcdRN.ListarSaldosDocumentosXCuenta(ent)

        'cargar todas las cuentas corrientes
        Dim iCuCoEN As New SuperEntidad
        iCuCoEN.CodigoEmpresa = ent.CodigoEmpresa
        iCuCoEN.CampoOrden = cam.ClaveDocuCtaCte
        Dim iLisCuCo As List(Of SuperEntidad) = Me.obtenerCuentaCorrienteExisXEmpresa(iCuCoEN)

        'variables
        Dim iEncontrado As Decimal = 0

        'ir modificando cada cuenta corriente
        For Each xcuco As SuperEntidad In iLisCuCo
            iEncontrado = 0
            For Each xSalDoc As SuperEntidad In iLisSalAux
                If xcuco.ClaveDocumentoCuentaCorriente = xSalDoc.ClaveDocumentoCuentaCorriente And xcuco.CodigoCuentaPcge = xSalDoc.CodigoCuentaPcge Then
                    Dim iSal As Decimal = 0
                    Dim iSalSoles As Decimal = Math.Abs(xSalDoc.SaldoCuentaBanco)
                    Dim iImpOri As Decimal = 0
                    'sacar el saldo segun moneda del documento
                    If xcuco.MonedaDocumento = "S/." Then
                        iSal = Math.Abs(xSalDoc.SaldoCuentaBanco)
                        'obtener el importe original
                        If xSalDoc.DebeS00SaldoContable > xSalDoc.HabeS00SaldoContable Then
                            iImpOri = xSalDoc.DebeS00SaldoContable
                        Else
                            iImpOri = xSalDoc.HabeS00SaldoContable
                        End If
                    Else
                        iSal = Math.Abs(xSalDoc.SaldoMesDolCuentaBanco)
                        'obtener el importe original
                        If xSalDoc.DebeD00SaldoContable > xSalDoc.HabeD00SaldoContable Then
                            iImpOri = xSalDoc.DebeD00SaldoContable
                        Else
                            iImpOri = xSalDoc.HabeD00SaldoContable
                        End If
                    End If

                    'actualizar a la cuenta corriente actual
                    If iSalSoles = 0 Then
                        xcuco.ImportePagadoCuentaCorriente = xcuco.ImporteOriginalCuentaCorriente
                        xcuco.SaldoCuentaCorriente = 0
                        xcuco.EstadoCuentaCorriente = "0"
                    Else
                        If iImpOri > xcuco.ImporteOriginalCuentaCorriente Then
                            iSal = Math.Abs(iSal - (iImpOri - xcuco.ImporteOriginalCuentaCorriente))
                        End If
                        xcuco.ImportePagadoCuentaCorriente = xcuco.ImporteOriginalCuentaCorriente - iSal
                        xcuco.SaldoCuentaCorriente = iSal
                        If iSal = 0 Then
                            xcuco.EstadoCuentaCorriente = "0"
                        Else
                            xcuco.EstadoCuentaCorriente = "1"
                        End If


                        'If xcuco.MonedaDocumento = "S/." Then
                        '    xcuco.ImportePagadoCuentaCorriente = xcuco.ImporteOriginalCuentaCorriente - iSal
                        '    xcuco.SaldoCuentaCorriente = iSal
                        'Else
                        '    'saldo en dolares
                        '    Dim iSalDol As Decimal = Math.Round(iSal / xcuco.VentaTipoCambio, 2)
                        '    xcuco.ImportePagadoCuentaCorriente = xcuco.ImporteOriginalCuentaCorriente - (iSalDol)
                        '    xcuco.SaldoCuentaCorriente = iSalDol
                        'End If
                    End If
                    iEncontrado = 1
                    Continue For
                End If
            Next
            If iEncontrado = 0 Then
                xcuco.ImportePagadoCuentaCorriente = xcuco.ImporteOriginalCuentaCorriente
                xcuco.SaldoCuentaCorriente = 0
                xcuco.EstadoCuentaCorriente = "0"
            End If
        Next

        ''sacar solo lo pendiente
        'Dim iL As New List(Of SuperEntidad)
        'For Each xobj As SuperEntidad In iLisCuCo
        '    If xobj.EstadoCuentaCorriente = "1" And xobj.MonedaDocumento = "US$" Then
        '        iL.Add(xobj)
        '    End If
        '    'If xobj.MonedaDocumento = "US$" Then
        '    '    iL.Add(xobj)
        '    'End If
        'Next
        'MsgBox(iL.Count.ToString)
        'Return iL
        Return iLisCuCo
    End Function

    Sub ActualizarCuentasCorientes(ByRef ent As SuperEntidad)
        'traer la lista de cuentas corrientes para actualizar
        Dim iLisCuCo As List(Of SuperEntidad) = Me.ListarActualizarCuentasCorientes(ent)

        'grabar masivo todos las cuentas corrientes
        Me.ModificarCuentaCorrienteMasivo(iLisCuCo)
    End Sub

    Function ListarCuentasCorrientesXEmpresaXDolares(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New CuentaCorrienteAD
        Return objAD.ListarCuentasCorrientesXEmpresaXDolares(ent)
        '\\
    End Function

    Sub ModificarCuentaCorrienteMasivo(ByRef pLista As List(Of SuperEntidad))
        '/Vovemos a traer el usuario actual de la b.d
        ''/Mandamos a modificar la b.d
        Dim objAD As New CuentaCorrienteAD
        objAD.SpModificarCuentaCorrienteMasivo(pLista)
        '\\
    End Sub

    Sub EliminarCuentaCorrienteXGastoOperativo(ByRef ent As SuperEntidad)
        '//
        '/Se elimina Fisicamente el registro
        Dim tabAD As New CuentaCorrienteAD
        tabAD.SpEliminarCuentaCorrienteXGastoOperativo(ent)
    End Sub

    'Public Shared Function ObtenerSaldoTotalEnSoles(ByVal pLisCueCorr As List(Of SuperEntidad)) As Decimal

    '    'valor resultado
    '    Dim iSaldoTotal As Decimal = 0

    '    'recorrer cada objeto
    '    For Each xCueCor As SuperEntidad In pLisCueCorr
    '        iSaldoTotal += CuentaCorrienteRN.ObtenerMontoEnSoles(xCueCor)
    '    Next

    '    'devolver
    '    Return iSaldoTotal
    'End Function

    Public Shared Function ObtenerSaldoTotalEnSoles(ByVal pLisCueCorr As List(Of SuperEntidad)) As Decimal

        'valor resultado
        Dim iSaldoTotal As Decimal = 0

        'recorrer cada objeto
        For Each xCueCor As SuperEntidad In pLisCueCorr
            iSaldoTotal += Math.Abs(CuentaCorrienteRN.ObtenerMontoEnSoles(xCueCor))
        Next

        'devolver
        Return iSaldoTotal
    End Function


    Public Shared Function ObtenerMontoEnSoles(ByVal pCueCor As SuperEntidad) As Decimal

        'valor resultado
        Dim iMonto As Decimal = 0

        'segun moneda
        Select Case pCueCor.MonedaDocumento
            Case "S/." : iMonto = pCueCor.SaldoCuentaCorriente
            Case "US$" : iMonto = pCueCor.SaldoCuentaCorriente * pCueCor.VentaTipoCambio
            Case "EUR" : iMonto = pCueCor.SaldoCuentaCorriente * pCueCor.VentaEurTipoCambio
        End Select

        'devolver
        Return iMonto
    End Function

    Function ListarCuentasCorrientesParaAsientoDocumentosPendientes(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New CuentaCorrienteAD
        Return objAD.ListarCuentasCorrientesParaAsientoDocumentosPendientes(ent)
        '\\
    End Function

    Public Shared Function ObtenerMontoEnDolares(ByVal pCueCor As SuperEntidad) As Decimal

        'valor resultado
        Dim iMonto As Decimal = 0

        'segun moneda
        Select Case pCueCor.MonedaDocumento
            Case "S/." : iMonto = pCueCor.SaldoCuentaCorriente / pCueCor.VentaTipoCambio
            Case "US$" : iMonto = pCueCor.SaldoCuentaCorriente
            Case "EUR" : iMonto = 1
        End Select

        'devolver
        Return iMonto
    End Function

    'Sub CancelarDocumentos(ByVal pLisDocPen As List(Of SuperEntidad))

    '    'recorrer cada objeto
    '    For Each xCueCor As SuperEntidad In pLisDocPen

    '        'modificar los datos(cancelar el documento)
    '        xCueCor.ImportePagadoCuentaCorriente = xCueCor.ImporteOriginalCuentaCorriente
    '        xCueCor.SaldoCuentaCorriente = 0
    '        xCueCor.EstadoCuentaCorriente = "0"

    '        'modificar en b.d
    '        Me.modificarCuentaCorriente(xCueCor)

    '    Next

    'End Sub

    Sub CancelarDocumentos(ByVal pLisDocPen As List(Of SuperEntidad))

        'recorrer cada objeto
        For Each xCueCor As SuperEntidad In pLisDocPen

            'modificar los datos(cancelar el documento)
            xCueCor.ImportePagadoCuentaCorriente = xCueCor.ImporteOriginalCuentaCorriente
            MsgBox(xCueCor.SaldoCuentaCorriente.ToString)
            If xCueCor.SaldoCuentaCorriente < 0 Then
                xCueCor.FlagSaldoNegativo = "1"
            Else
                xCueCor.FlagSaldoNegativo = "0"
            End If
            xCueCor.SaldoCuentaCorriente = 0
            xCueCor.EstadoCuentaCorriente = "0"

            'modificar en b.d
            Me.modificarCuentaCorriente(xCueCor)

        Next

    End Sub


    Function ValidaCuandoNoEsCuentaDocumento(ByVal pCueCor As SuperEntidad) As SuperEntidad

        'objeto resultado
        Dim iCueCorEN As New SuperEntidad

        'armar la clave documento 
        iCueCorEN.ClaveDocumentoCuentaCorriente += SuperEntidad.xCodigoEmpresa
        iCueCorEN.ClaveDocumentoCuentaCorriente += pCueCor.CodigoAuxiliar
        iCueCorEN.ClaveDocumentoCuentaCorriente += pCueCor.TipoDocumento
        iCueCorEN.ClaveDocumentoCuentaCorriente += pCueCor.SerieDocumento
        iCueCorEN.ClaveDocumentoCuentaCorriente += pCueCor.NumeroDocumento

        'buscar a este documento
        iCueCorEN = Me.buscarCuentaCorrienteExisPorClaveDoc(iCueCorEN)

        'valida cuando no existe el documento
        If iCueCorEN.ClaveDocumentoCuentaCorriente = "" Then
            iCueCorEN.EsVerdad = True
            Return iCueCorEN
        End If

        'valida que sea de la misma cuenta
        If iCueCorEN.CodigoCuentaPcge <> pCueCor.CodigoCuentaPcge Then
            iCueCorEN.EsVerdad = False
            iCueCorEN.Mensaje = "La cuenta de la provision del documento es : " + iCueCorEN.CodigoCuentaPcge
            Return iCueCorEN
        End If

        'ok
        iCueCorEN.EsVerdad = True
        Return iCueCorEN

    End Function




End Class
