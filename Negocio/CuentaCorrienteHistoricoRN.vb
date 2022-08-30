Imports Entidad
Imports Datos

Public Class CuentaCorrienteHistoricoRN
    Dim cam As New CamposEntidad

    Function obtenerFileAutogeneradoManual(ByRef ent As SuperEntidad) As String
        Dim objAD As New RegContabCabeAD
        Return objAD.SpAutogenerarFileManual(ent)
    End Function


    Sub nuevoCuentaCorrienteHistorico(ByRef ent As SuperEntidad)
        '//
        '/Estos Datos son por defecto cada vez que agregua un registro compras

        ent.Exporta = "0"
        ent.EstadoRegistro = "1"
        ent.EliminadoRegistro = "1"
        ent.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioAgrega = SuperEntidad.xNombreUsuario
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuarioModifica
        'ent.AnoMesDiasPorMes = ent.AnoDiasPorMes + "/" + ent.CodigoMes
        Dim objAD As New CuentaCorrienteHistoricoAD
        objAD.SpNuevoCuentaCorrienteHistorico(ent)
        '\\

    End Sub

    Sub modificarCuentaCorrienteHistorico(ByRef ent As SuperEntidad)
        '//
        '/Vovemos a traer el usuario actual de la b.d
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuarioModifica
        '/Vovemos a traer el usuario actual de la b.d
        ''/Mandamos a modificar la b.d
        Dim objAD As New CuentaCorrienteHistoricoAD
        objAD.SpModificarCuentaCorrienteHistorico(ent)
        '\\
    End Sub

    Sub modificarCuentaCorrienteHistoricoXClave(ByRef ent As SuperEntidad)
        '//
        '/Vovemos a traer el usuario actual de la b.d
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuarioModifica
        '/Vovemos a traer el usuario actual de la b.d
        ''/Mandamos a modificar la b.d
        Dim objAD As New CuentaCorrienteHistoricoAD
        objAD.ModificarCuentaCorrienteHistoricoXClave(ent)
        '\\
    End Sub

    Sub EliminarCuentaCorrienteHistoricoLog(ByRef ent As SuperEntidad)
        '//
        '/Datos por defecto
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.CodigoPersonalModifica = SuperEntidad.xCodigoPersonal
        ent.EliminadoRegistro = "0"
        '/Mandamos a modificar la b.d
        Dim objAD As New CuentaCorrienteHistoricoAD
        objAD.SpModificarCuentaCorrienteHistorico(ent)
        '\\
    End Sub

    Sub eliminarCuentaCorrienteHistoricoFis(ByRef ent As SuperEntidad)
        '//
        Dim objAD As New CuentaCorrienteHistoricoAD
        objAD.SpEliminarCuentaCorrienteHistorico(ent)
        '\\
    End Sub

    Sub eliminarCuentaCorrienteHistoricoXMes(ByRef ent As SuperEntidad)
        '//
        Dim objAD As New CuentaCorrienteHistoricoAD
        objAD.EliminarCuentaCorrienteHistoricoXMes(ent)
        '\\
    End Sub

    Function obtenerCuentaCorrienteHistorico(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsCuentaCorrienteHistorico"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.CodOriRC
        ent.CampoCondicion2 = cam.CodEmp
        ent.DatoCondicion2 = SuperEntidad.xCodigoEmpresa
        Dim objAD As New CuentaCorrienteHistoricoAD
        listObj = objAD.SpObtenerRegistrosConDosCondicion(ent)
        Return listObj
        '\\
    End Function


    Function obtenerCuentaCorrienteHistoricoExis(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsCuentaCorrienteHistorico"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        Dim objAD As New CuentaCorrienteHistoricoAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerCuentaCorrienteHistoricoExisXOrigenFileYPeriodo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsCuentaCorrienteHistorico"
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

    Function obtenerCuentaCorrienteHistoricoEntreFechas(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        ent.Vista = "VsCuentaCorrienteHistorico"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.CodOriRC
        ent.CampoFecha = cam.FecVouRCC
        Dim objAD As New CuentaCorrienteHistoricoAD
        Return objAD.SpObtenerRegistrosEntreFechas(ent)
    End Function

    Function obtenerCuentaCorrienteHistoricoPorPeriodo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsCuentaCorrienteHistorico"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        'ent.CampoCondicion1 = cam.CodOriRC
        ent.CampoCondicion1 = cam.PeriodoRCC
        ent.DatoCondicion1 = ent.PeriodoRegContabCabe
        ent.CampoCondicion2 = cam.CodEmp
        ent.DatoCondicion2 = SuperEntidad.xCodigoEmpresa
        Dim objAD As New CuentaCorrienteHistoricoAD
        listObj = objAD.SpObtenerRegistrosConDosCondicion(ent)
        Return listObj
        '\\
    End Function

    Function buscarCuentaCorrienteHistoricoExisPorClaveCC(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsCuentaCorrienteHistorico"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.ClaveCtaCteHis
        ent.DatoCondicion1 = ent.ClaveCuentaCorrienteHistorico
        Dim objAD As New CuentaCorrienteHistoricoAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarCuentaCorrienteHistoricoExisPorClaveDoc(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsCuentaCorrienteHistorico"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.ClaveDocuCtaCte
        ent.DatoCondicion1 = ent.ClaveDocumentoCuentaCorriente
        Dim objAD As New CuentaCorrienteHistoricoAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function


    Function buscarCuentaCorrienteHistoricoExisPorClaveDocYClaveCCte(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsCuentaCorrienteHistorico"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.ClaveDocuCtaCte
        ent.DatoCondicion1 = ent.ClaveDocumentoCuentaCorriente
        ent.CampoCondicion2 = cam.ClaveCtaCteHis
        ent.DatoCondicion2 = ent.ClaveCuentaCorrienteHistorico
        Dim objAD As New CuentaCorrienteHistoricoAD
        obj = objAD.SpBuscarRegistroConDosCondicion(ent)
        Return obj
        '\\
    End Function

    Function EsDocumentoRegistrado(ByRef ent As SuperEntidad) As Boolean
        Dim obj As New SuperEntidad
        obj.ClaveDocumentoCuentaCorriente = ent.CodigoEmpresa + ent.CodigoAuxiliar + ent.TipoDocumento + ent.SerieDocumento + ent.NumeroDocumento
        obj = Me.buscarCuentaCorrienteHistoricoExisPorClaveDoc(obj)
        If obj.ClaveDocumentoCuentaCorriente = "" Then
            Return False
        Else
            Return True
        End If

    End Function


    Function EsDocumentoRegistradoEnOtroRegistroC(ByRef ent As SuperEntidad) As Boolean
        Dim obj As New SuperEntidad
        obj.ClaveCuentaCorrienteHistorico = ent.ClaveCuentaCorrienteHistorico
        obj.ClaveDocumentoCuentaCorriente = ent.CodigoEmpresa + ent.CodigoAuxiliar + ent.TipoDocumento + ent.SerieDocumento + ent.NumeroDocumento
        obj = Me.buscarCuentaCorrienteHistoricoExisPorClaveDoc(obj)
        If obj.ClaveDocumentoCuentaCorriente = "" Then
            Return False
        Else
            If obj.ClaveCuentaCorrienteHistorico = ent.ClaveCuentaCorrienteHistorico Then
                Return False
            Else
                Return True
            End If

        End If

    End Function

    Function obtenerCuentaCorrienteHistoricoExisXEmpresaXAuxiliarYPendientes(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsCuentaCorrienteHistorico"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.CodEmp
        ent.DatoCondicion1 = ent.CodigoEmpresa
        ent.CampoCondicion2 = cam.CodAux
        ent.DatoCondicion2 = ent.CodigoAuxiliar
        ent.CampoCondicion3 = cam.EstCtaCteHis
        ent.DatoCondicion3 = "1"
        ent.CampoOrden = cam.CodTipDoc + "," + cam.SerDoC + "," + cam.NumDoc

        Dim objAD As New CuentaCorrienteHistoricoAD
        listObj = objAD.SpObtenerRegistrosConTresCondicion(ent)
        Return listObj
        '\\
    End Function


    Function obtenerCuentaCorrienteHistoricoExisXEmpresaYPendientes(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsCuentaCorrienteHistorico"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.CodEmp
        ent.DatoCondicion1 = ent.CodigoEmpresa
        ent.CampoCondicion2 = cam.EstCtaCteHis
        ent.DatoCondicion2 = "1"

        Dim objAD As New CuentaCorrienteHistoricoAD
        listObj = objAD.SpObtenerRegistrosConDosCondicion(ent)
        Return listObj
        '\\
    End Function


    Function ListarDocumentosAPagarXEmpresaXAuxiliarYPendientes(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New CuentaCorrienteHistoricoAD
        ent.CampoOrden = cam.CodTipDoc + "," + cam.SerDoC + "," + cam.NumDoc
        Return objAD.ListarDocumentosAPagarXEmpresaXAuxiliarYPendientes(ent)
        '\\
    End Function


    Function ListarDocumentosACobrarXEmpresaXAuxiliarYPendientes(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New CuentaCorrienteHistoricoAD
        ent.CampoOrden = cam.CodTipDoc + "," + cam.SerDoC + "," + cam.NumDoc
        Return objAD.ListarDocumentosACobrarXEmpresaXAuxiliarYPendientes(ent)
        '\\
    End Function

    Function ListarDocumentosACobrarXEmpresaYPendientes(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New CuentaCorrienteHistoricoAD
        ent.CampoOrden = cam.CodTipDoc + "," + cam.SerDoC + "," + cam.NumDoc
        Return objAD.ListarDocumentosACobrarXEmpresaYPendientes(ent)
        '\\
    End Function


    Function ListarDocumentosAPagarXEmpresaYPendientes(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New CuentaCorrienteHistoricoAD
        ent.CampoOrden = cam.CodTipDoc + "," + cam.SerDoC + "," + cam.NumDoc
        Return objAD.ListarDocumentosAPagarXEmpresaYPendientes(ent)
        '\\
    End Function


    Function obtenerCuentaCorrienteHistoricoExisXEmpresa(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsCuentaCorrienteHistorico"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.CodEmp
        ent.DatoCondicion1 = ent.CodigoEmpresa

        Dim objAD As New CuentaCorrienteHistoricoAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
        Return listObj
        '\\
    End Function






    Function ListarCuentaCorrienteXPeriodoYNoAprobado(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New CuentaCorrienteHistoricoAD
        ent.EstadoCuentaCorrienteHistorico = "0" ' NO APROBADO
        Return objAD.ListarCuentaCorrienteHistoricoXPeriodoYEstado(ent)
        '\\
    End Function

    Function ListarCuentaCorrienteHistoricoXPeriodo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New CuentaCorrienteHistoricoAD
        Return objAD.ListarCuentaCorrienteHistoricoXPeriodo(ent)
        '\\
    End Function



    Function EsValidoGenerarMes(ByRef ent As SuperEntidad) As SuperEntidad
        Dim iCchEN As New SuperEntidad
        'TRAER LA LISTA DEL MES
        ent.CampoOrden = cam.ClaveCtaCteHis
        Dim iLisCch As List(Of SuperEntidad) = Me.ListarCuentaCorrienteHistoricoXPeriodo(ent)
        If iLisCch.Count = 0 Then
            iCchEN.EsVerdad = True
        Else
            'PREGUNTAR SOLO POR EL PRIMER OBJETO DE LA LISTA SI ESTA APROBADO O NO
            If iLisCch.Item(0).EstadoCuentaCorrienteHistorico = "1" Then 'YA ESTA APROBADO
                iCchEN.Mensaje = "Este periodo ya esta Aprobado,No se puede realizar la operacion"
                iCchEN.EsVerdad = False
            Else
                iCchEN.EsVerdad = True
            End If
        End If
        Return iCchEN
    End Function

    Function EsValidoGenerarMes(ByRef pLista As List(Of SuperEntidad)) As SuperEntidad
        Dim iCchEN As New SuperEntidad
        If pLista.Count = 0 Then
            iCchEN.EsVerdad = True
        Else
            'PREGUNTAR SOLO POR EL PRIMER OBJETO DE LA LISTA SI ESTA APROBADO O NO
            If pLista.Item(0).EstadoCuentaCorrienteHistorico = "1" Then 'YA ESTA APROBADO
                iCchEN.Mensaje = "Este periodo ya esta Aprobado,No se puede realizar la operacion"
                iCchEN.EsVerdad = False
            Else
                iCchEN.EsVerdad = True
            End If
        End If
        Return iCchEN
    End Function

    Function ReporteXMesDiferenciaCambio(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        'LISTA RESUMEN
        Dim iLisRes As New List(Of SuperEntidad)
        ent.CampoOrden = cam.ClaveDocuCtaCte
        Dim ilisCueCorHis As List(Of SuperEntidad) = Me.ListarCuentaCorrienteHistoricoXPeriodo(ent)

        'OBTENER LOS TIPOS DE CAMBIO DEL ULTIMO DIA DEL MES
        Dim iTipCamRN As New TipoCambioRN
        Dim iTipCamEN As New SuperEntidad
        iTipCamEN.AnoTipoCambio = ent.AnoTipoCambio
        iTipCamEN.MesTipoCambio = ent.MesTipoCambio
        iTipCamEN = iTipCamRN.ObtenerUltimoTipoCambioDelMes(iTipCamEN)

        'ARMANDO REPORTE DIFERENCIA DE CAMBIO
        For Each xObj As SuperEntidad In ilisCueCorHis
            Dim iRep As New SuperEntidad
            iRep.CodigoOrigen = xObj.CodigoOrigen
            iRep.CodigoAuxiliar = xObj.CodigoAuxiliar
            iRep.DescripcionAuxiliar = xObj.DescripcionAuxiliar
            iRep.TipoDocumento = xObj.TipoDocumento
            iRep.SerieDocumento = xObj.SerieDocumento
            iRep.NumeroDocumento = xObj.NumeroDocumento
            iRep.FechaDocumento = xObj.FechaDocumento
            iRep.CodigoCuentaPcge = xObj.CodigoCuentaPcge
            iRep.MonedaDocumento = xObj.MonedaDocumento
            iRep.ImporteDRegContabDeta = xObj.SaldoCuentaCorriente 'SALDO DEL DOCUEMNTO
            'Tipo de cambio segun moneda
            Select Case xObj.MonedaDocumento
                Case "US$"
                    iRep.VentaTipoCambio = xObj.VentaTipoCambio 'PARA T.C DEL DOCUEMNTO
                    If xObj.CodigoOrigen = "5" Then
                        iRep.VentaEurTipoCambio = iTipCamEN.CompraTipoCambio 'PARA EL NUEVO T.C DEL DOCUEMTO
                    Else
                        iRep.VentaEurTipoCambio = iTipCamEN.VentaTipoCambio 'PARA EL NUEVO T.C DEL DOCUEMTO
                    End If

                Case "EUR"
                    iRep.VentaTipoCambio = xObj.VentaEurTipoCambio
                    If xObj.CodigoOrigen = "5" Then
                        iRep.VentaEurTipoCambio = iTipCamEN.CompraEurTipoCambio 'PARA EL NUEVO T.C DEL DOCUEMTO
                    Else
                        iRep.VentaEurTipoCambio = iTipCamEN.VentaEurTipoCambio 'PARA EL NUEVO T.C DEL DOCUEMTO
                    End If

            End Select
            iRep.ImporteSRegContabDeta = iRep.ImporteDRegContabDeta * iRep.VentaTipoCambio 'IMPORTE SOL CON EL T.C DEL DOCUEMNTO
            iRep.ImporteSolRegContabCabe = iRep.ImporteDRegContabDeta * iRep.VentaEurTipoCambio 'IMPORTE SOL CON EL T.C NUEVO

            'SEGUN ORIGEN
            Dim iDif As Decimal = iRep.ImporteSRegContabDeta - iRep.ImporteSolRegContabCabe
            If xObj.CodigoOrigen = "4" Or xObj.CodigoOrigen = "6" Then
                If iDif > 0 Then
                    iRep.SumaDebeRegContabCabe = iDif
                    iRep.SumaHaberRegContabCabe = 0
                Else
                    iRep.SumaDebeRegContabCabe = 0
                    iRep.SumaHaberRegContabCabe = Math.Abs(iDif)
                End If
            Else
                If iDif > 0 Then
                    iRep.SumaDebeRegContabCabe = 0
                    iRep.SumaHaberRegContabCabe = iDif
                Else
                    iRep.SumaDebeRegContabCabe = Math.Abs(iDif)
                    iRep.SumaHaberRegContabCabe = 0
                End If
            End If
            iLisRes.Add(iRep)
        Next
        Return iLisRes
    End Function

    Function EsValidoAprobarMes(ByRef pLista As List(Of SuperEntidad)) As SuperEntidad
        Dim iCchEN As New SuperEntidad
        If pLista.Count = 0 Then
            iCchEN.Mensaje = "Aun no se genera el mes,No se puede realizar la operacion"
            iCchEN.EsVerdad = False
        Else
            'PREGUNTAR SOLO POR EL PRIMER OBJETO DE LA LISTA SI ESTA APROBADO O NO
            If pLista.Item(0).EstadoCuentaCorrienteHistorico = "1" Then 'SI ESTA APROBADO
                iCchEN.Mensaje = "Este periodo ya esta Aprobado,No se puede realizar la operacion"
                iCchEN.EsVerdad = False
            Else
                iCchEN.EsVerdad = True
            End If
        End If
        Return iCchEN
    End Function


    Function EsValidoDesaprobarMes(ByRef pLista As List(Of SuperEntidad)) As SuperEntidad
        Dim iCchEN As New SuperEntidad
        If pLista.Count = 0 Then
            iCchEN.Mensaje = "Aun no se genera el mes,No se puede realizar la operacion"
            iCchEN.EsVerdad = False
        Else
            'PREGUNTAR SOLO POR EL PRIMER OBJETO DE LA LISTA SI ESTA APROBADO O NO
            If pLista.Item(0).EstadoCuentaCorrienteHistorico = "0" Then 'NO ESTA APROBADO
                iCchEN.Mensaje = "Este periodo no esta Aprobado,No se puede realizar la operacion"
                iCchEN.EsVerdad = False
            Else
                iCchEN.EsVerdad = True
            End If
        End If
        Return iCchEN
    End Function

End Class
