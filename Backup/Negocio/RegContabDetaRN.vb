Imports Entidad
Imports Datos

Public Class RegContabDetaRN
    Dim cam As New CamposEntidad
    Dim vista As String = "vsregcontabdeta"

    Sub nuevoRegContabDeta(ByRef ent As SuperEntidad)
        '//
        '/
        'ent.anoRegContab = ent.PeriodoRegContab.Substring(0, 4)
        'ent.mesRegContab = ent.PeriodoRegContab.Substring(4, 2)
        If ent.CodigoOrigen = "1" Or ent.CodigoOrigen = "2" Or ent.CodigoOrigen = "3" Then
        Else
            ent.Exporta = "0"
        End If

        ent.EstadoRegistro = "1"
        ent.EliminadoRegistro = "1"
        ent.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioAgrega = SuperEntidad.xNombreUsuario
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        ent.ClaveRegContabDeta = ent.ClaveRegContabCabe + ent.CorrelativoRegContabDeta

        'cuando es nota de credito
        If ent.CodigoFile = "407" Or ent.CodigoFile = "507" Then
            ent.ImporteSRegContabDeta = -ent.ImporteSRegContabDeta
            ent.ImporteDRegContabDeta = -ent.ImporteDRegContabDeta
        End If
        '/adiciona
        Dim tabAD As New RegContabDetaAD
        tabAD.SpNuevoDetalleRegContab(ent)
    End Sub

    Sub NuevoRegContabDetaMasivo(ByRef pLista As List(Of SuperEntidad))
        Dim objAD As New RegContabDetaAD
        objAD.NuevoRegContabDetaMasivo(pLista)
    End Sub

    Sub EliminarRegistroDetalleParaCierreAnual(ByRef ent As SuperEntidad)
        Dim objAD As New RegContabDetaAD
        objAD.EliminarRegistroDetalleParaCierreAnual(ent)
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

    Function obtenerDetalleRegContabXClaveYEstado(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = Me.vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.ClaveRCC
        ent.DatoCondicion1 = ent.ClaveRegContabCabe
        ent.CampoCondicion2 = cam.EstRCD
        ent.DatoCondicion2 = ent.EstadoRegContabDeta
        ent.CampoOrden = cam.ClaveRCD
        Dim objAD As New RegContabDetaAD
        listObj = objAD.SpObtenerRegistrosConDosCondicion(ent)
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
        ent.CampoCondicion2 = cam.CodEmp
        ent.DatoCondicion2 = SuperEntidad.xCodigoEmpresa
        ent.CampoOrden = cam.CodOriRC
        Dim objAD As New RegContabDetaAD
        listObj = objAD.SpObtenerRegistrosConDosCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerDetalleRegContabPorPeriodoYFile(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = Me.vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.PeriodoRCC
        ent.DatoCondicion1 = ent.PeriodoRegContabCabe
        ent.CampoCondicion2 = cam.CodEmp
        ent.DatoCondicion2 = SuperEntidad.xCodigoEmpresa
        ent.CampoCondicion3 = cam.CodFilRC
        ent.DatoCondicion3 = ent.CodigoFile
        ent.CampoOrden = cam.CodOriRC
        Dim objAD As New RegContabDetaAD
        listObj = objAD.SpObtenerRegistrosConTresCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerDetalleRegContabPorPeriodoParaLibroDiarioYMayorTodos(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = Me.vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.PeriodoRCC
        ent.DatoCondicion1 = ent.PeriodoRegContabCabe
        ent.CampoCondicion2 = cam.CodEmp
        ent.DatoCondicion2 = SuperEntidad.xCodigoEmpresa
        Dim objAD As New RegContabDetaAD
        listObj = objAD.SpObtenerRegistrosConDosCondicion(ent)
        Return listObj
        '\\
    End Function


    Function obtenerDetalleRegContabPorPeriodoParaLibroDiarioYMayorSinExtornar(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = Me.vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.PeriodoRCC
        ent.DatoCondicion1 = ent.PeriodoRegContabCabe
        ent.CampoCondicion2 = cam.CodEmp
        ent.DatoCondicion2 = SuperEntidad.xCodigoEmpresa
        ent.CampoCondicion3 = cam.EstRCC
        ent.DatoCondicion3 = "0"  'Normal
        Dim objAD As New RegContabDetaAD
        listObj = objAD.SpObtenerRegistrosConTresCondicion(ent)
        Return listObj
        '\\
    End Function

    Sub modificarRegContab(ByRef ent As SuperEntidad)
        '//
        '/Vovemos a traer el usuario actual de la b.d
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuarioModifica
        Dim objAD As New RegContabDetaAD
        objAD.SpModificarDetalleRegContab(ent)

    End Sub

    Sub eliminarRegContabDeta(ByRef ent As SuperEntidad)
        '//
        '/Se elimina Fisicamente el registro
        Dim tabAD As New RegContabDetaAD
        tabAD.SpEliminarRegcontabDeta(ent)
    End Sub

    Sub EliminarRegistroDetalleXClaveDetalle(ByRef ent As SuperEntidad)
        '//
        '/Se elimina Fisicamente el registro
        Dim tabAD As New RegContabDetaAD
        tabAD.EliminarRegistroDetalleXClaveDetalle(ent)
    End Sub


    Function obtenerDetalleRegContabPorEmpresaYCuenta(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = Me.vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.CodEmp
        ent.DatoCondicion1 = ent.CodigoEmpresa
        ent.CampoCondicion2 = cam.CodCtaPcge
        ent.DatoCondicion2 = ent.CodigoCuentaPcge
        ent.CampoOrden = cam.ClaveRCD
        Dim objAD As New RegContabDetaAD
        listObj = objAD.SpObtenerRegistrosConDosCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerDetalleRegContabPorPeriodoYFlagBanco(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = Me.vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.PeriodoRCC
        ent.DatoCondicion1 = ent.PeriodoRegContabCabe
        ent.CampoCondicion2 = cam.CodEmp
        ent.DatoCondicion2 = SuperEntidad.xCodigoEmpresa
        ent.CampoCondicion3 = cam.FlaBcoPcge
        ent.DatoCondicion3 = "1"  ''1 = Cuenta Bancaria

        'ent.CampoOrden = cam.CodOriRC
        Dim objAD As New RegContabDetaAD
        listObj = objAD.SpObtenerRegistrosConTresCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerDetalleRegContabPorEmpresaXPeriodoYCuenta(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = Me.vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.CodEmp
        ent.DatoCondicion1 = ent.CodigoEmpresa
        ent.CampoCondicion2 = cam.CodCtaPcge
        ent.DatoCondicion2 = ent.CodigoCuentaPcge
        ent.CampoCondicion3 = cam.PeriodoRCC
        ent.DatoCondicion3 = ent.PeriodoRegContabCabe
        'ent.CampoOrden = cam.ClaveRCD
        Dim objAD As New RegContabDetaAD
        listObj = objAD.SpObtenerRegistrosConTresCondicion(ent)
        Return listObj
        '\\
    End Function

    Function BuscarDetalleRegContabPorClave(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        ent.Vista = Me.vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.ClaveRCD
        ent.DatoCondicion1 = ent.ClaveRegContabDeta
        Dim objAD As New RegContabDetaAD
        Return objAD.SpBuscarRegistroConUnaCondicion(ent)
        '\\
    End Function



    Function obtenerDetalleRegContabXClaveCabe(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = Me.vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.ClaveRCC
        ent.DatoCondicion1 = ent.ClaveRegContabCabe
        'ent.CampoCondicion2 = cam.CodEmp
        'ent.DatoCondicion2 = SuperEntidad.xCodigoEmpresa

        Dim objAD As New RegContabDetaAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
        Return listObj
        '\\
    End Function


    Function ListarRegistrosContablesDetalleXFiltroCuenta(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New RegContabDetaAD
        Return objAD.ListarRegistrosContablesDetalleXFiltroCuenta(ent)
        '\\
    End Function


    Function obtenerDetalleRegContabXPeriodoIngEgr(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista de codigo ing egr diferente de blanco 
        Dim listObj As New List(Of SuperEntidad)
        Dim objAD As New RegContabDetaAD
        listObj = objAD.ListarIngresosEgresos(ent)
        Return listObj
        '\\
    End Function

    Function obtenerDetalleRegContabXClaveYEstadoNew(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim listObj As New List(Of SuperEntidad)
        Dim objAD As New RegContabDetaAD
        listObj = objAD.obtenerDetalleRegContabXClaveYEstadoNew(ent)
        Return listObj
        '\\
    End Function

    Function obtenerDetalleRegContabXPeriodoIngYMoneda(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista de codigo ing egr diferente de blanco 
        Dim listObj As New List(Of SuperEntidad)
        Dim objAD As New RegContabDetaAD
        Dim lisRes As New List(Of SuperEntidad)

        listObj = objAD.ListarIngresosEgresos(ent)

        For Each xobj As SuperEntidad In listObj
            If xobj.CodigoIngEgr <> "" Then
                If xobj.CodigoIngEgr.Substring(0, 1) = "1" And xobj.FlagMonedaPcge = ent.MonedaCuentaBanco And xobj.FlagBancoPcge = "1" Then
                    lisRes.Add(xobj)
                End If
            End If

        Next
        Return (lisRes)
        '\\
    End Function

    Function obtenerDetalleRegContabXPeriodoEgrYMoneda(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista de codigo ing egr diferente de blanco 
        Dim listObj As New List(Of SuperEntidad)
        Dim objAD As New RegContabDetaAD
        Dim lisRes As New List(Of SuperEntidad)

        listObj = objAD.ListarIngresosEgresos(ent)

        For Each xobj As SuperEntidad In listObj
            If xobj.CodigoIngEgr <> "" Then
                If xobj.CodigoIngEgr.Substring(0, 1) = "2" And xobj.FlagMonedaPcge = ent.MonedaCuentaBanco And xobj.FlagBancoPcge = "1" Then
                    lisRes.Add(xobj)
                End If
            End If

        Next
        Return (lisRes)
        '\\
    End Function


    Sub EstornarRegistroContableDetaDeRegContabCabe(ByVal pRcc As SuperEntidad)
        'traer la lista de todo el detalle del rcc
        Dim iRcdEN As New SuperEntidad
        iRcdEN.ClaveRegContabCabe = pRcc.ClaveRegContabCabe
        iRcdEN.CampoOrden = cam.ClaveRCC
        Dim iLisRcd As List(Of SuperEntidad) = Me.obtenerDetalleRegContabPorClave(iRcdEN)

        'recorremos cada registro detalle y lo vamos estornado
        For Each xRcd As SuperEntidad In iLisRcd
            xRcd.ClaveRegContabCabe = xRcd.ClaveRegContabCabe + "E"
            'cambiar su haber debe
            If xRcd.DebeHaberRegContabDeta = "Debe" Then
                xRcd.DebeHaberRegContabDeta = "Haber"
            Else
                xRcd.DebeHaberRegContabDeta = "Debe"
            End If
            Me.nuevoRegContabDeta(xRcd)
        Next
    End Sub

    Function ListarReporteXCentroCostoYCuentas(ByRef ent As SuperEntidad) As List(Of SuperEntidad)

        Dim iLisDetCc As New List(Of SuperEntidad)
        iLisDetCc = Me.ListarRegistrosContablesDetalleXFiltroCentroCostoYCuentas(ent)


        Dim iLisRes As New List(Of SuperEntidad)

        Dim iClave As String = String.Empty
        Dim iIndiceFila As Integer = -1

        For Each xobj As SuperEntidad In iLisDetCc
            If iClave <> xobj.CodigoCentroCosto + xobj.CodigoCuentaPcge Then
                Dim iObj As New SuperEntidad
                iObj.CodigoCentroCosto = xobj.CodigoCentroCosto
                iObj.NombreCentroCosto = xobj.NombreCentroCosto
                iObj.CodigoCuentaPcge = xobj.CodigoCuentaPcge
                iObj.NombreCuentaPcge = xobj.NombreCuentaPcge
                If xobj.DebeHaberRegContabDeta = "Debe" Then
                    iObj.SumaDebeRegContabCabe = xobj.ImporteSRegContabDeta
                Else
                    iObj.SumaHaberRegContabCabe = xobj.ImporteSRegContabDeta
                End If
                iLisRes.Add(iObj)
                iClave = xobj.CodigoCentroCosto + xobj.CodigoCuentaPcge
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


    Function ListarReporteXCentroCuentasYCosto(ByRef ent As SuperEntidad) As List(Of SuperEntidad)

        Dim iLisDetCc As New List(Of SuperEntidad)
        iLisDetCc = Me.ListarRegistrosContablesDetalleXFiltroCuentasYCentroCosto(ent)


        Dim iLisRes As New List(Of SuperEntidad)

        Dim iClave As String = String.Empty
        Dim iIndiceFila As Integer = -1

        For Each xobj As SuperEntidad In iLisDetCc
            If iClave <> xobj.CodigoCuentaPcge + xobj.CodigoCentroCosto Then
                Dim iObj As New SuperEntidad
                iObj.CodigoCentroCosto = xobj.CodigoCentroCosto
                iObj.NombreCentroCosto = xobj.NombreCentroCosto
                iObj.CodigoCuentaPcge = xobj.CodigoCuentaPcge
                iObj.NombreCuentaPcge = xobj.NombreCuentaPcge
                If xobj.DebeHaberRegContabDeta = "Debe" Then
                    iObj.SumaDebeRegContabCabe = xobj.ImporteSRegContabDeta
                Else
                    iObj.SumaHaberRegContabCabe = xobj.ImporteSRegContabDeta
                End If
                iLisRes.Add(iObj)
                iClave = xobj.CodigoCuentaPcge + xobj.CodigoCentroCosto
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

    Function ListarRegistrosContablesDetalleXFiltroCentroCostoYCuentas(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New RegContabDetaAD
        Return objAD.ListarRegistrosContablesDetalleXFiltroCentroCostoYCuentas(ent)
        '\\
    End Function

    Function ListarRegistrosContablesDetalleXFiltroCentroCostoDetalle(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New RegContabDetaAD
        Return objAD.ListarRegistrosContablesDetalleXFiltroCentroCostoDetalle(ent)
        '\\
    End Function

    Function ListarRegistrosContablesDetalleXFiltroCuentasYCentroCosto(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New RegContabDetaAD
        Return objAD.ListarRegistrosContablesDetalleXFiltroCuentasYCentroCosto(ent)
        '\\
    End Function


    Function ConvertirTextoARegistroCompraDeta(ByVal pTexto As String) As SuperEntidad
        Dim iRegConDet As New SuperEntidad
        iRegConDet.Mensaje = pTexto.Substring(0, 1) ' comodin
        iRegConDet.CodigoCentroCosto = pTexto.Substring(9, 20).Trim
        iRegConDet.CodigoCuentaPcge = pTexto.Substring(1, 8).Trim
        iRegConDet.DebeHaberRegContabDeta = "Debe"
        iRegConDet.ImporteSRegContabDeta = CType(pTexto.Substring(44, 12), Decimal)
        iRegConDet.ImporteDRegContabDeta = CType(pTexto.Substring(56, 12), Decimal)
        iRegConDet.ImporteERegContabDeta = 0
        iRegConDet.GlosaRegContabDeta = pTexto.Substring(68, 40).Trim
        iRegConDet.CodigoIngEgr = pTexto.Substring(120, 3).Trim
        iRegConDet.Cuenta1242 = "4212101"
        iRegConDet.EstadoRegContabDeta = "0" 'visible
        iRegConDet.Exporta = "1"
        iRegConDet.EstadoRegistro = "0"
        iRegConDet.EliminadoRegistro = "1"
        iRegConDet.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
        iRegConDet.NombreUsuarioAgrega = SuperEntidad.xNombreUsuario
        iRegConDet.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        iRegConDet.NombreUsuarioModifica = SuperEntidad.xNombreUsuarioModifica
        iRegConDet.MontoMoneda = 0
        iRegConDet.MontoSoles = 0
        iRegConDet.CodigoArea = pTexto.Substring(116, 4).Trim
        iRegConDet.CodigoFlujoCaja = ""
        Return iRegConDet
    End Function

    Function ConvertirTextoARegistroVentaDeta(ByVal pTexto As String, ByVal wPeriodo As String) As SuperEntidad
        Dim iAuxEN As New SuperEntidad
        Dim iAuxRN As New AuxiliarRN
        Dim wOrigFile As String = "5511"
        Dim iRegConDet As New SuperEntidad
        Dim wcadena As String = String.Empty
        Dim xcadena As String = String.Empty
        Dim Periodo As String = wPeriodo
        If pTexto.Substring(0, 1) = "D" Then
            iRegConDet.Mensaje = pTexto.Substring(0, 1) ' comodin
            iRegConDet.CorrelativoRegContabDeta = pTexto.Substring(7, 4) 'Correlativo
            iRegConDet.ClaveRegContabDeta = SuperEntidad.xCodigoEmpresa + wPeriodo + wOrigFile + pTexto.Substring(1, 6) + iRegConDet.CorrelativoRegContabDeta
            iRegConDet.ClaveRegContabCabe = SuperEntidad.xCodigoEmpresa + wPeriodo + wOrigFile + pTexto.Substring(1, 6)
            iRegConDet.CodigoAuxiliar = pTexto.Substring(26, 11)
            iRegConDet.CodigoCentroCosto = "0001" ''Comun
            iRegConDet.TipoDocumento = pTexto.Substring(58, 2) 'TD
            iRegConDet.SerieDocumento = pTexto.Substring(60, 4) 'Serie
            iRegConDet.NumeroDocumento = pTexto.Substring(64, 15) 'Numero
            'iRegConDet.FechaDocumento = CType(pTexto.Substring(11, 2) + "/" + pTexto.Substring(13, 2) + "/" + pTexto.Substring(15, 4), DateTime)
            iRegConDet.VentaEurTipoCambio = 1  'Luego Validar
            iRegConDet.VentaEurTipoCambio = 0
            iRegConDet.CodigoCuentaPcge = pTexto.Substring(19, 7).Trim 'Cta 70
            iRegConDet.DebeHaberRegContabDeta = pTexto.Substring(37, 1)
            If iRegConDet.DebeHaberRegContabDeta = "2" Then
                iRegConDet.DebeHaberRegContabDeta = "0" 'Haber
            Else
                iRegConDet.DebeHaberRegContabDeta = "1" 'Debe
            End If
            iRegConDet.ImporteSRegContabDeta = CType(pTexto.Substring(38, 8) + "." + pTexto.Substring(46, 2), Decimal)
            iRegConDet.ImporteDRegContabDeta = CType(pTexto.Substring(38, 8) + "." + pTexto.Substring(46, 2), Decimal)
            iRegConDet.ImporteERegContabDeta = 0
            iRegConDet.GlosaRegContabDeta = pTexto.Substring(87).Trim
            iRegConDet.CodigoIngEgr = pTexto.Substring(0, 1)
            iRegConDet.Cuenta1242 = pTexto.Substring(0, 1)
            iRegConDet.EstadoRegContabDeta = "0" 'visible
            iRegConDet.CodigoArea = "" 'pTexto.Substring(116, 4).Trim
            iRegConDet.CodigoFlujoCaja = ""
            iRegConDet.CodigoGastoReparable = ""
            iRegConDet.Cantidad = 0
            iRegConDet.Exporta = "0"
            iRegConDet.EstadoRegistro = "1"
            iRegConDet.EliminadoRegistro = "1"
            iRegConDet.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
            iRegConDet.NombreUsuarioAgrega = SuperEntidad.xNombreUsuario
            iRegConDet.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
            iRegConDet.NombreUsuarioModifica = SuperEntidad.xNombreUsuarioModifica
            iRegConDet.MontoMoneda = 0
            iRegConDet.MontoSoles = 0
            iRegConDet.CodigoPptoInterno = ""
            iRegConDet.CodigoConcepto = ""
            iRegConDet.CodigoInterno = ""
            iRegConDet.Titulo = ""
            If iRegConDet.CodigoCuentaPcge.Substring(0, 2) = "12" Then
                iAuxEN.CodigoAuxiliar = iRegConDet.CodigoAuxiliar
                iAuxEN = iAuxRN.buscarAuxiliarExisPorCodigo(iAuxEN)
                'SI YA HAY AUXILIAR ENTONCES NO GRABA NADA
                If iAuxEN.CodigoAuxiliar = "" Then
                    'TRAEMOS AL AUXILIAR DE LA B.D DE PROYECTOS
                    iAuxEN.CodigoAuxiliar = iRegConDet.CodigoAuxiliar
                    iAuxEN.DescripcionAuxiliar = iRegConDet.GlosaRegContabDeta.Substring(0, 39)
                    iAuxEN.ApellidoPaternoAuxiliar = ""
                    iAuxEN.ApellidoMaternoAuxiliar = ""
                    iAuxEN.PrimerNombreAuxiliar = ""
                    iAuxEN.SegundoNombreAuxiliar = ""
                    iAuxEN.TipoAuxiliar = "3"
                    'iAuxEN.TipoDocumentoAuxiliar = "0"
                    iAuxEN.DireccionAuxiliar = "NUEVO"
                    If iRegConDet.CodigoAuxiliar.Length = 11 Then
                        iAuxEN.TipoDocumentoAuxiliar = "6"
                    Else
                        iAuxEN.TipoDocumentoAuxiliar = "1"
                    End If
                    iAuxEN.EstadoAuxiliar = "1"
                    iAuxEN.Exporta = "0"
                    iAuxRN.nuevoAuxiliar(iAuxEN)
                End If
            End If
            'iregcondet.CodigoCuentaPcge=ptexto.Substring(87
            Return iRegConDet
        End If
    End Function


    Function ListarRegistrosContablesDetalleXFiltroCentroCostoParaIngresoEgresoDetalle(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New RegContabDetaAD
        Return objAD.ListarRegistrosContablesDetalleXFiltroCentroCostoParaIngresoEgresoDetalle(ent)
        '\\
    End Function

    Function ListarReporteCentroCostoXIngresoDetalle(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        'TRAER LA LISTA PARA EL REPORTE DE CENTRO DE COSTO POR INGRESO/EGRESO
        Dim iLisCc As List(Of SuperEntidad) = Me.ListarRegistrosContablesDetalleXFiltroCentroCostoParaIngresoEgresoDetalle(ent)

        'VARIABLES DE TRABAJO
        Dim iCodSumIngEgr As String = ""
        Dim iCodSumIngEgrAct As String = ""
        Dim iSumIngEgrEN As New SuperEntidad
        Dim iSumIngEgrRN As New SumaIngEgrRN

        'RECORRE CADA OBJETO Y ACTUALIZAR EL CAMPO PERIODO QUE PARA ESTE REPORTE
        'SIRVE PARA EL OBJETO SUMA INGRESO/EGRESO
        For Each xRcd As SuperEntidad In iLisCc
            'SI EL DETALLE ES UNA NOTA DE CREDITO SE PONE NEGATIVO
            If xRcd.TipoDocumento = "07" Then
                xRcd.ImporteSRegContabDeta = xRcd.ImporteSRegContabDeta * (-1)
            End If

            'OBTENIENDO EL CODIGO SUMA INGRESO/EGRESO DEL OBJETO DETALLE
            iCodSumIngEgrAct = xRcd.CodigoIngEgr.Substring(0, 2)

            'COMPARA SI ES IGUAL CON EL CODIGO SUMA INGRESOEGRESO ACTUAL
            If iCodSumIngEgrAct <> iCodSumIngEgr Then
                'TRAER AL OBJETO SUMA INGRESO/EGRESO
                iSumIngEgrEN.ClaveSumaIngEgr = xRcd.CodigoEmpresa + iCodSumIngEgrAct
                iSumIngEgrEN = iSumIngEgrRN.buscarSumaIngEgrExisPorClave(iSumIngEgrEN)

                'SINO LO ENCUENTAR LO PONE A UNA BOLSA COMUN(XX : NINGUNO)
                If iSumIngEgrEN.CodigoSumaIngEgr = "" Then
                    iSumIngEgrEN.CodigoSumaIngEgr = "XX"
                    iSumIngEgrEN.NombreSumaIngEgr = "Ninguno"
                End If

                'PASAR A CODIGO SUMA INGRESO EGRESO ACTUAL
                iCodSumIngEgr = iCodSumIngEgrAct
            End If
            'ACTUALIZANDO EL OBJETO DETALLE
            xRcd.PeriodoRegContabCabe = iSumIngEgrEN.CodigoSumaIngEgr + " " + iSumIngEgrEN.NombreSumaIngEgr
        Next
        Return iLisCc
    End Function


    Function ListarReporteCentroCostoXIngresoResumen(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        'TRAER LA LISTA PARA EL REPORTE DE CENTRO DE COSTO POR INGRESO/EGRESO
        Dim iLisCc As List(Of SuperEntidad) = Me.ListarRegistrosContablesDetalleXFiltroCentroCostoParaIngresoEgresoDetalle(ent)

        'LISTA DE RESULTADOS
        Dim iLisRes As New List(Of SuperEntidad)

        'VARIABLES DE TRABAJO
        Dim iCodIngEgr As String = ""
        Dim iIndiceActual As Integer = -1
        Dim iCodSumIngEgr As String = ""
        Dim iCodSumIngEgrAct As String = ""
        Dim iSumIngEgrEN As New SuperEntidad
        Dim iSumIngEgrRN As New SumaIngEgrRN

        'RECORRE CADA OBJETO Y ACTUALIZAR EL CAMPO PERIODO QUE PARA ESTE REPORTE
        'SIRVE PARA EL OBJETO SUMA INGRESO/EGRESO
        For Each xRcd As SuperEntidad In iLisCc
            'SI EL DETALLE ES UNA NOTA DE CREDITO SE PONE NEGATIVO
            If xRcd.TipoDocumento = "07" Then
                xRcd.ImporteSRegContabDeta = xRcd.ImporteSRegContabDeta * (-1)
            End If

            'OBTENIENDO EL CODIGO SUMA INGRESO/EGRESO DEL OBJETO DETALLE
            iCodSumIngEgrAct = xRcd.CodigoIngEgr.Substring(0, 2)

            'COMPARA SI ES IGUAL CON EL CODIGO SUMA INGRESOEGRESO ACTUAL
            If iCodSumIngEgrAct <> iCodSumIngEgr Then
                'TRAER AL OBJETO SUMA INGRESO/EGRESO
                iSumIngEgrEN.ClaveSumaIngEgr = xRcd.CodigoEmpresa + iCodSumIngEgrAct
                iSumIngEgrEN = iSumIngEgrRN.buscarSumaIngEgrExisPorClave(iSumIngEgrEN)

                'SINO LO ENCUENTAR LO PONE A UNA BOLSA COMUN(XX : NINGUNO)
                If iSumIngEgrEN.CodigoSumaIngEgr = "" Then
                    iSumIngEgrEN.CodigoSumaIngEgr = "XX"
                    iSumIngEgrEN.NombreSumaIngEgr = "NINGUNO"
                End If

                'PASAR A CODIGO SUMA INGRESO EGRESO ACTUAL
                iCodSumIngEgr = iCodSumIngEgrAct
            End If
            'ACTUALIZANDO EL OBJETO DETALLE
            xRcd.PeriodoRegContabCabe = iSumIngEgrEN.CodigoSumaIngEgr + " " + iSumIngEgrEN.NombreSumaIngEgr

            'AGRUPANDO POR CODIGOINGEGR
            If xRcd.CodigoIngEgr <> iCodIngEgr Then
                Dim iRcd As New SuperEntidad
                iRcd.CodigoIngEgr = xRcd.CodigoIngEgr
                iRcd.NombreIngEgr = xRcd.NombreIngEgr
                iRcd.PeriodoRegContabCabe = xRcd.PeriodoRegContabCabe
                iRcd.ImporteSRegContabDeta = xRcd.ImporteSRegContabDeta
                iLisRes.Add(iRcd)
                iCodIngEgr = xRcd.CodigoIngEgr
                iIndiceActual += 1
            Else
                iLisRes.Item(iIndiceActual).ImporteSRegContabDeta += xRcd.ImporteSRegContabDeta
            End If
        Next
        Return iLisRes
    End Function


    Function ListarRegistrosContablesDetalleXEmpresaXPeriodoXCuentaYEntreFechas(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New RegContabDetaAD
        Return objAD.ListarRegistrosContablesDetalleXEmpresaXPeriodoXCuentaYEntreFechas(ent)
        '\\
    End Function

    Function ListarRegistrosContablesDetalleXEmpresaYEntrePeriodos(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New RegContabDetaAD
        Return objAD.ListarRegistrosContablesDetalleXEmpresaYEntrePeriodos(ent)
        '\\
    End Function

    Function ListarCentroCostosConMovimiento(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim iLisDetCc As New List(Of SuperEntidad)
        iLisDetCc = Me.ListarRegistrosContablesDetalleXEmpresaYEntrePeriodos(ent)

        Dim iLisRes As New List(Of SuperEntidad)
        Dim iCc As String = String.Empty
        Dim iIndiceFila As Integer = -1

        For Each xobj As SuperEntidad In iLisDetCc
            If iCc <> xobj.CodigoCentroCosto Then
                Dim iObj As New SuperEntidad
                iLisRes.Add(xobj)
                iCc = xobj.CodigoCentroCosto
            End If
        Next
        Return iLisRes
    End Function

    Sub eliminarRegContabDetaPorClave(ByRef ent As SuperEntidad)
        '//
        '/Se elimina Fisicamente el registro
        Dim tabAD As New RegContabDetaAD
        tabAD.EliminarRegcontabDetalle(ent)
    End Sub

    Function obtenerDetalleRegContabTodos(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = Me.vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        Dim objAD As New RegContabDetaAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function ListarReporteXFlujoCajaResumen(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        'TRAEMOS TODOS LOS REGISTROS CONTABLES DETALLE QUE SE ENCUENTARN 
        'EN EL PERIOD ESTABLECIDO, ORDENADOS POR FLUJO CAJA
        Dim iLisRcd As New List(Of SuperEntidad)
        iLisRcd = Me.ListarRegistrosContablesDetalleEntrePeriodoConFlujoCaja(ent)

        'LISTA DE RESULTADOS
        Dim iLisRes As New List(Of SuperEntidad)
        'CODIGO DEL FLUJO ACTUAL MIENTRAS RECORRE EL FOR EACH
        Dim iCodigo As String = String.Empty
        'INDICE DEL OBJETO ACTUAL MIENTRAS RECORRE EL FOR EACH 
        'PARA IR ACUMULANDO MONTOS
        Dim iIndiceFila As Integer = -1
        Dim iIngEgr As String

        'RECORRIENDO CADA OBJETO REGISTRO CONTABLE DETALLE
        For Each xobj As SuperEntidad In iLisRcd
            iIngEgr = xobj.CodigoFlujoCaja.Substring(0, 1)
            'SI EL iCodigo ES DIFERENTE AL CODIGOFLUJO DEL OBJETO ENTONCES SE 
            'CREA UN NUEVO OBJETO Y SE AGREGA A LA LISTA DE RESULTADOS
            If iCodigo <> xobj.CodigoFlujoCaja Then
                Dim iObj As New SuperEntidad
                iObj.CodigoFlujoCaja = xobj.CodigoFlujoCaja
                iObj.NombreFlujoCaja = xobj.NombreFlujoCaja
                'OBTENER EL PRIMER CARACTER DEL CODIGO ING/EGR PARA SABER 
                'SI ES INGRESO O EGRESO(1 : INGRESO , 2 : EGRESO)
                If iIngEgr = "1" Then
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS INGRESOS EN SOLES
                    iObj.IngresosSolCuentaBanco = xobj.ImporteSRegContabDeta
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS INGRESOS EN DOLARES
                    iObj.IngresosDolCuentaBanco = xobj.ImporteSRegContabDeta / ent.VentaTipoCambio
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS EGRESOS EN SOLES
                    iObj.SalidasSolCuentaBanco = 0
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS EGRESOS EN DOLARES
                    iObj.SalidasDolCuentaBanco = 0
                Else
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS INGRESOS EN SOLES
                    iObj.IngresosSolCuentaBanco = 0
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS INGRESOS EN DOLARES
                    iObj.IngresosDolCuentaBanco = 0
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS EGRESOS EN SOLES
                    iObj.SalidasSolCuentaBanco = xobj.ImporteSRegContabDeta
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS EGRESOS EN DOLARES
                    iObj.SalidasDolCuentaBanco = xobj.ImporteSRegContabDeta / ent.VentaTipoCambio
                End If
                iLisRes.Add(iObj)
                iCodigo = xobj.CodigoFlujoCaja
                iIndiceFila += 1
            Else
                If iIngEgr = "1" Then
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS INGRESOS EN SOLES
                    iLisRes.Item(iIndiceFila).IngresosSolCuentaBanco += xobj.ImporteSRegContabDeta
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS INGRESOS EN DOLARES
                    iLisRes.Item(iIndiceFila).IngresosDolCuentaBanco += xobj.ImporteSRegContabDeta / ent.VentaTipoCambio
                Else
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS EGRESOS EN SOLES
                    iLisRes.Item(iIndiceFila).SalidasSolCuentaBanco += xobj.ImporteSRegContabDeta
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS EGRESOS EN DOLARES
                    iLisRes.Item(iIndiceFila).SalidasDolCuentaBanco += xobj.ImporteSRegContabDeta / ent.VentaTipoCambio
                End If
            End If
        Next
        Return iLisRes
    End Function

    Function ListarRegistrosContablesDetalleEntrePeriodoConFlujoCaja(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New RegContabDetaAD
        Return objAD.ListarRegistrosContablesDetalleEntrePeriodoConFlujoCaja(ent)
        '\\
    End Function

    Function ListarReporteXFlujoCajaResumenXCuenta(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        'TRAEMOS TODOS LOS REGISTROS CONTABLES DETALLE QUE SE ENCUENTARN 
        'EN EL PERIOD ESTABLECIDO, ORDENADOS POR FLUJO CAJA
        Dim iLisRcd As New List(Of SuperEntidad)
        iLisRcd = Me.ListarRegistrosContablesDetalleEntrePeriodoConFlujoCajaXCuenta(ent)

        'LISTA DE RESULTADOS
        Dim iLisRes As New List(Of SuperEntidad)
        'CODIGO DEL FLUJO ACTUAL MIENTRAS RECORRE EL FOR EACH
        Dim iCodigo As String = String.Empty
        'INDICE DEL OBJETO ACTUAL MIENTRAS RECORRE EL FOR EACH 
        'PARA IR ACUMULANDO MONTOS
        Dim iIndiceFila As Integer = -1
        Dim iIngEgr As String

        'RECORRIENDO CADA OBJETO REGISTRO CONTABLE DETALLE
        For Each xobj As SuperEntidad In iLisRcd
            iIngEgr = xobj.CodigoFlujoCaja.Substring(0, 1)
            'SI EL iCodigo ES DIFERENTE AL CODIGOFLUJO DEL OBJETO ENTONCES SE 
            'CREA UN NUEVO OBJETO Y SE AGREGA A LA LISTA DE RESULTADOS
            If iCodigo <> xobj.CodigoFlujoCaja Then
                Dim iObj As New SuperEntidad
                iObj.CodigoFlujoCaja = xobj.CodigoFlujoCaja
                iObj.NombreFlujoCaja = xobj.NombreFlujoCaja
                'OBTENER EL PRIMER CARACTER DEL CODIGO ING/EGR PARA SABER 
                'SI ES INGRESO O EGRESO(1 : INGRESO , 2 : EGRESO)
                If iIngEgr = "1" Then
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS INGRESOS EN SOLES
                    iObj.IngresosSolCuentaBanco = xobj.ImporteSRegContabDeta
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS EGRESOS EN SOLES
                    iObj.SalidasSolCuentaBanco = 0
                Else
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS INGRESOS EN SOLES
                    iObj.IngresosSolCuentaBanco = 0
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS EGRESOS EN SOLES
                    iObj.SalidasSolCuentaBanco = xobj.ImporteSRegContabDeta
                End If
                iLisRes.Add(iObj)
                iCodigo = xobj.CodigoFlujoCaja
                iIndiceFila += 1
            Else
                If iIngEgr = "1" Then
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS INGRESOS EN SOLES
                    iLisRes.Item(iIndiceFila).IngresosSolCuentaBanco += xobj.ImporteSRegContabDeta
                Else
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS EGRESOS EN SOLES
                    iLisRes.Item(iIndiceFila).SalidasSolCuentaBanco += xobj.ImporteSRegContabDeta
                End If
            End If
        Next
        Return iLisRes
    End Function

    Function ListarRegistrosContablesDetalleEntrePeriodoConFlujoCajaXCuenta(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New RegContabDetaAD
        Return objAD.ListarRegistrosContablesDetalleEntrePeriodoConFlujoCajaXCuenta(ent)
        '\\
    End Function

    Function ListarRegistrosContablesDetalleXFiltroFlujoCaja(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New RegContabDetaAD
        Return objAD.ListarRegistrosContablesDetalleXFiltroFlujoCaja(ent)
        '\\
    End Function

    Function ListarRegistrosContablesDetalleXPeriodoSinExtornoYFiltroOrigen(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New RegContabDetaAD
        Return objAD.ListarRegistrosContablesDetalleXPeriodoSinExtornoYFiltroOrigen(ent)
        '\\
    End Function


    Function ListarBancosParaCierreBanco(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New RegContabDetaAD
        Return objAD.ListarBancosParaCierreBanco(ent)
        '\\
    End Function

    Function ListarRegistrosContablesDetalleXPeriodosSinExtorno(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New RegContabDetaAD
        Return objAD.ListarRegistrosContablesDetalleXPeriodosSinExtorno(ent)
        '\\
    End Function

    Function ListarRegistroDetalleParaCierreAnual(ByRef ent As SuperEntidad) As List(Of List(Of SuperEntidad))
        '//
        Dim objAD As New RegContabDetaAD
        Return objAD.ListarRegistroDetalleParaCierreAnual(ent)
        '\\
    End Function

    Function ListarSaldosPorAuxiliarYDocumentosTotal(ByVal pLista As List(Of SuperEntidad)) As List(Of SuperEntidad)
        Dim iLisRes As New List(Of SuperEntidad)

        'LISTA QUE CONTIENE TODO EL REGISTRO DETALLE DE UNA CUENTA ESPECIFICA
        Dim iLisMov As List(Of SuperEntidad) = pLista

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

    Function ListarSaldosPorAuxiliarYDocumentosSaldo(ByVal pLista As List(Of SuperEntidad)) As List(Of SuperEntidad)
        Dim iLisSalHis As List(Of SuperEntidad) = Me.ListarSaldosPorAuxiliarYDocumentosTotal(pLista)
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

            If (iDocumento = xMov.TipoDocumento + xMov.SerieDocumento + xMov.NumeroDocumento) And xMov.GlosaRegContabDeta <> "Total Auxiliar" Then
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
                        'If xMov.GlosaRegContabDeta = "Total Auxiliar" And xMov.SaldoCuentaCorriente <> 0 Then
                        '    iLisRes.Add(xMov)
                        'End If
                    Else
                        iLisDoc.Clear()
                        iLisDoc.Add(xMov)
                        'If xMov.GlosaRegContabDeta = "Total Auxiliar" And xMov.SaldoCuentaCorriente <> 0 Then
                        '    iLisRes.Add(xMov)
                        'End If
                    End If
                End If
                'iLisDoc.Add(xMov)
                iDocumento = xMov.TipoDocumento + xMov.SerieDocumento + xMov.NumeroDocumento
            End If
        Next
        Return iLisRes
    End Function

    Sub ObtenerCabeceraYDetalleXCuentaCierreAnual(ByRef pRcc As SuperEntidad, ByRef pRcd As List(Of SuperEntidad), ByVal pTipCam As Decimal)

        'ARMANDO DATOS CABECERA
        pRcc.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        pRcc.PeriodoRegContabCabe = pRcc.AnoCuentaBanco + "00"
        pRcc.CodigoOrigen = "3"
        pRcc.CodigoFile = "398"
        pRcc.UltimoCorrelativo = (pRcd.Count + 1).ToString.PadLeft(4, CType("0", Char))
        pRcc.DiaVoucherRegContabCabe = "02"
        pRcc.FechaVoucherRegContabCabe = CType("02/01/" + pRcc.AnoCuentaBanco, Date)
        pRcc.FechaDocumento = pRcc.FechaVoucherRegContabCabe
        pRcc.FechaVencimiento = pRcc.FechaVoucherRegContabCabe
        pRcc.MonedaDocumento = "0"
        pRcc.MonedaDocumento1 = "0"
        pRcc.VentaTipoCambio = pTipCam
        pRcc.VentaEurTipoCambio = 1
        pRcc.IgvPar = 0
        pRcc.GlosaRegContabCabe = "APERTURA EJERCICIO " + pRcc.AnoCuentaBanco
        pRcc.EstadoRegContabCabe = "1"
        pRcc.Exporta = "0"
        pRcc.EstadoRegistro = "0"
        pRcc.EliminadoRegistro = "1"
        pRcc.ClaveRegContabCabe += pRcc.CodigoEmpresa
        pRcc.ClaveRegContabCabe += pRcc.PeriodoRegContabCabe
        pRcc.ClaveRegContabCabe += pRcc.CodigoOrigen
        pRcc.ClaveRegContabCabe += pRcc.CodigoFile
        pRcc.ClaveRegContabCabe += pRcc.NumeroVoucherRegContabCabe

        'ARMANDO DETALLE
        Dim iCorre As Integer = 0
        For Each xRcd As SuperEntidad In pRcd
            xRcd.ClaveRegContabCabe = pRcc.ClaveRegContabCabe
            iCorre += 1
            xRcd.CorrelativoRegContabDeta = iCorre.ToString.PadLeft(4, CType("0", Char))
            xRcd.ClaveRegContabDeta = xRcd.ClaveRegContabCabe + xRcd.CorrelativoRegContabDeta

            xRcd.GlosaRegContabCabe = "APERTURA EJERCICIO " + pRcc.AnoCuentaBanco
            If xRcd.DebeHaberRegContabDeta = "Debe" Then
                pRcc.SumaDebeRegContabCabe += xRcd.ImporteSRegContabDeta
            Else
                pRcc.SumaHaberRegContabCabe += xRcd.ImporteSRegContabDeta
            End If
            xRcd.VentaTipoCambio = pTipCam
            xRcd.ImporteDRegContabDeta = xRcd.ImporteSRegContabDeta / pTipCam
            xRcd.EstadoRegistro = "1"
            xRcd.EliminadoRegistro = "1"
            pRcc.CodigoArea = xRcd.CodigoCuentaPcge
        Next

        'CREAR ULTIMO DETALLE DE CUADRE
        Dim iRcdEN As New SuperEntidad
        iRcdEN.ClaveRegContabCabe = pRcc.ClaveRegContabCabe
        iRcdEN.CorrelativoRegContabDeta = pRcc.UltimoCorrelativo
        iRcdEN.ClaveRegContabDeta = iRcdEN.ClaveRegContabCabe + iRcdEN.CorrelativoRegContabDeta
        iRcdEN.CodigoAuxiliar = "99999999999"
        iRcdEN.CodigoCuentaPcge = pRcc.CodigoArea

        'SEGUN DIFERENCIA DEBE HABER
        Dim iDifSaldo As Decimal = pRcc.SumaDebeRegContabCabe - pRcc.SumaHaberRegContabCabe
        If iDifSaldo < 0 Then
            iRcdEN.DebeHaberRegContabDeta = "Debe"
            pRcc.SumaDebeRegContabCabe += Math.Abs(iDifSaldo)
        Else
            iRcdEN.DebeHaberRegContabDeta = "Haber"
            pRcc.SumaHaberRegContabCabe += iDifSaldo
        End If

        iRcdEN.VentaTipoCambio = pTipCam
        iRcdEN.ImporteSRegContabDeta = Math.Abs(iDifSaldo)
        iRcdEN.ImporteDRegContabDeta = iRcdEN.ImporteSRegContabDeta / pTipCam
        iRcdEN.GlosaRegContabCabe = "APERTURA EJERCICIO " + pRcc.AnoCuentaBanco
        iRcdEN.Exporta = "0"
        iRcdEN.EstadoRegistro = "1"
        iRcdEN.EliminadoRegistro = "1"
        pRcd.Add(iRcdEN)

    End Sub

    Sub ObtenerCabeceraYDetalleXSaldoCierreAnual(ByRef pRcc As SuperEntidad, ByRef pRcd As List(Of SuperEntidad), ByRef pLisCta As List(Of SuperEntidad), ByRef pLisSal As List(Of SuperEntidad), ByVal pTipCam As Decimal)

        'ARMANDO DATOS CABECERA
        pRcc.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        pRcc.PeriodoRegContabCabe = pRcc.AnoCuentaBanco + "00"
        pRcc.CodigoOrigen = "3"
        pRcc.CodigoFile = "398"
        pRcc.DiaVoucherRegContabCabe = "02"
        pRcc.FechaVoucherRegContabCabe = CType("02/01/" + pRcc.AnoCuentaBanco, Date)
        pRcc.FechaDocumento = pRcc.FechaVoucherRegContabCabe
        pRcc.FechaVencimiento = pRcc.FechaVoucherRegContabCabe
        pRcc.MonedaDocumento = "0"
        pRcc.MonedaDocumento1 = "0"
        pRcc.VentaTipoCambio = pTipCam
        pRcc.VentaEurTipoCambio = 1
        pRcc.IgvPar = 0
        pRcc.GlosaRegContabCabe = "APERTURA EJERCICIO " + pRcc.AnoCuentaBanco
        pRcc.EstadoRegContabCabe = "1"
        pRcc.Exporta = "0"
        pRcc.EstadoRegistro = "0"
        pRcc.EliminadoRegistro = "1"
        pRcc.ClaveRegContabCabe += pRcc.CodigoEmpresa
        pRcc.ClaveRegContabCabe += pRcc.PeriodoRegContabCabe
        pRcc.ClaveRegContabCabe += pRcc.CodigoOrigen
        pRcc.ClaveRegContabCabe += pRcc.CodigoFile
        pRcc.ClaveRegContabCabe += pRcc.NumeroVoucherRegContabCabe

        'ARMANDO DETALLE
        Dim iSalRN As New SaldoContableRN
        Dim iCtaRN As New PlanCuentaGeRN
        Dim iCtaEN As New SuperEntidad
        Dim iCorre As Integer = 0
        For Each xSal As SuperEntidad In pLisSal

            'VERIFICAR QUE LA CUENTA TENGA SALDO
            Dim iSalDH As Decimal = iSalRN.obtenerDiferenciaDebeHaberAcumulado(xSal, "12")

            'SI ES CERO NO PASA A LA LISTA
            If iSalDH <> 0 Then

                'SI LA CUENTA PERTENECE A EL  FLAG DE ASIENTO DE APERTURA
                'PREGUNTAR SI LA CUENTA DE ESTA LISTA ES PARTE DE LAS CUENTAS
                'DE CIERRE ANUAL
                iCtaEN.CodigoCuentaPcge = xSal.CodigoCuentaPcge.Substring(0, 2)
                iCtaEN = iCtaRN.buscarCuentaExisPorCodigo(iCtaEN, pLisCta)

                If iCtaEN.CodigoCuentaPcge <> "" Then
                    Dim iRcdEN As New SuperEntidad
                    iRcdEN.ClaveRegContabCabe = pRcc.ClaveRegContabCabe
                    iCorre += 1
                    iRcdEN.CorrelativoRegContabDeta = iCorre.ToString.PadLeft(4, CType("0", Char))
                    iRcdEN.ClaveRegContabDeta = iRcdEN.ClaveRegContabCabe + iRcdEN.CorrelativoRegContabDeta
                    If xSal.FlagAuxiliarPcge = "1" Then
                        iRcdEN.CodigoAuxiliar = "99999999999"
                    End If
                    iRcdEN.CodigoCuentaPcge = xSal.CodigoCuentaPcge
                    iRcdEN.GlosaRegContabCabe = "APERTURA EJERCICIO " + pRcc.AnoCuentaBanco
                    If iSalDH > 0 Then
                        iRcdEN.DebeHaberRegContabDeta = "Debe"
                        pRcc.SumaDebeRegContabCabe += Math.Abs(iSalDH)
                    Else
                        iRcdEN.DebeHaberRegContabDeta = "Haber"
                        pRcc.SumaHaberRegContabCabe += iSalDH
                    End If
                    iRcdEN.VentaTipoCambio = pTipCam
                    iRcdEN.ImporteSRegContabDeta = Math.Abs(iSalDH)
                    iRcdEN.ImporteDRegContabDeta = Math.Abs(iSalDH) * pTipCam
                    iRcdEN.Exporta = "0"
                    iRcdEN.EstadoRegistro = "1"
                    iRcdEN.EliminadoRegistro = "1"
                    pRcd.Add(iRcdEN)
                End If
            End If
        Next
        pRcc.UltimoCorrelativo = iCorre.ToString.PadLeft(4, CType("0", Char))
    End Sub


    Function ListarRegistrosContablesDetalleParaDiferenciaCambio(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New RegContabDetaAD
        Return objAD.ListarRegistrosContablesDetalleParaDiferenciaCambio(ent)
        '\\
    End Function

    Function ListarRegistrosContablesDetalleEntrePeriodoConGastoReparable(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New RegContabDetaAD
        Return objAD.ListarRegistrosContablesDetalleEntrePeriodoConGastoReparable(ent)
        '\\
    End Function


    Function ListarReporteXGastoReparableResumen(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        'TRAEMOS TODOS LOS REGISTROS CONTABLES DETALLE QUE SE ENCUENTARN 
        'EN EL PERIOD ESTABLECIDO, ORDENADOS POR FLUJO CAJA
        Dim iLisRcd As New List(Of SuperEntidad)
        iLisRcd = Me.ListarRegistrosContablesDetalleEntrePeriodoConGastoReparable(ent)

        'LISTA DE RESULTADOS
        Dim iLisRes As New List(Of SuperEntidad)
        'CODIGO DEL FLUJO ACTUAL MIENTRAS RECORRE EL FOR EACH
        Dim iCodigo As String = String.Empty
        'INDICE DEL OBJETO ACTUAL MIENTRAS RECORRE EL FOR EACH 
        'PARA IR ACUMULANDO MONTOS
        Dim iIndiceFila As Integer = -1
        Dim iIngEgr As String

        'RECORRIENDO CADA OBJETO REGISTRO CONTABLE DETALLE
        For Each xobj As SuperEntidad In iLisRcd
            iIngEgr = xobj.CodigoGastoReparable.Substring(0, 1)
            'SI EL iCodigo ES DIFERENTE AL CODIGOFLUJO DEL OBJETO ENTONCES SE 
            'CREA UN NUEVO OBJETO Y SE AGREGA A LA LISTA DE RESULTADOS
            If iCodigo <> xobj.CodigoGastoReparable Then
                Dim iObj As New SuperEntidad
                iObj.CodigoGastoReparable = xobj.CodigoGastoReparable
                iObj.NombreGastoReparable = xobj.NombreGastoReparable
                iObj.Unidad = xobj.Unidad
                
                'OBTENER EL PRIMER CARACTER DEL CODIGO ING/EGR PARA SABER 
                'SI ES INGRESO O EGRESO(1 : INGRESO , 2 : EGRESO)
                If iIngEgr = "1" Then
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS INGRESOS EN SOLES
                    iObj.IngresosSolCuentaBanco = xobj.ImporteSRegContabDeta
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS INGRESOS EN DOLARES
                    'iObj.IngresosDolCuentaBanco = xobj.ImporteSRegContabDeta / ent.VentaTipoCambio
                    iObj.IngresosDolCuentaBanco = 0
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS EGRESOS EN SOLES
                    iObj.SalidasSolCuentaBanco = 0
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS EGRESOS EN DOLARES
                    iObj.SalidasDolCuentaBanco = 0
                    iObj.Cantidad = xobj.Cantidad
                Else
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS INGRESOS EN SOLES
                    iObj.IngresosSolCuentaBanco = 0
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS INGRESOS EN DOLARES
                    iObj.IngresosDolCuentaBanco = 0
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS EGRESOS EN SOLES
                    iObj.SalidasSolCuentaBanco = xobj.ImporteSRegContabDeta
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS EGRESOS EN DOLARES
                    'iObj.SalidasDolCuentaBanco = xobj.ImporteSRegContabDeta / ent.VentaTipoCambio
                    iObj.SalidasDolCuentaBanco = 0
                    iObj.Cantidad = xobj.Cantidad
                End If
                iLisRes.Add(iObj)
                iCodigo = xobj.CodigoGastoReparable
                iIndiceFila += 1
            Else
                If iIngEgr = "1" Then
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS INGRESOS EN SOLES
                    iLisRes.Item(iIndiceFila).IngresosSolCuentaBanco += xobj.ImporteSRegContabDeta
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS INGRESOS EN DOLARES
                    'iLisRes.Item(iIndiceFila).IngresosDolCuentaBanco += xobj.ImporteSRegContabDeta / ent.VentaTipoCambio
                    iLisRes.Item(iIndiceFila).IngresosDolCuentaBanco += 0
                    iLisRes.Item(iIndiceFila).Cantidad += xobj.Cantidad
                Else
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS EGRESOS EN SOLES
                    iLisRes.Item(iIndiceFila).SalidasSolCuentaBanco += xobj.ImporteSRegContabDeta
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS EGRESOS EN DOLARES
                    iLisRes.Item(iIndiceFila).SalidasDolCuentaBanco += 0
                    iLisRes.Item(iIndiceFila).Cantidad += xobj.Cantidad
                End If
            End If
        Next
        Return iLisRes
    End Function


    Function ListarReporteXGastoReparableResumenXCuenta(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        'TRAEMOS TODOS LOS REGISTROS CONTABLES DETALLE QUE SE ENCUENTARN 
        'EN EL PERIOD ESTABLECIDO, ORDENADOS POR FLUJO CAJA
        Dim iLisRcd As New List(Of SuperEntidad)
        iLisRcd = Me.ListarRegistrosContablesDetalleEntrePeriodoConGastoReparableXCuenta(ent)

        'LISTA DE RESULTADOS
        Dim iLisRes As New List(Of SuperEntidad)
        'CODIGO DEL FLUJO ACTUAL MIENTRAS RECORRE EL FOR EACH
        Dim iCodigo As String = String.Empty
        'INDICE DEL OBJETO ACTUAL MIENTRAS RECORRE EL FOR EACH 
        'PARA IR ACUMULANDO MONTOS
        Dim iIndiceFila As Integer = -1
        Dim iIngEgr As String

        'RECORRIENDO CADA OBJETO REGISTRO CONTABLE DETALLE
        For Each xobj As SuperEntidad In iLisRcd
            iIngEgr = xobj.CodigoGastoReparable.Substring(0, 1)
            'SI EL iCodigo ES DIFERENTE AL CODIGOFLUJO DEL OBJETO ENTONCES SE 
            'CREA UN NUEVO OBJETO Y SE AGREGA A LA LISTA DE RESULTADOS
            If iCodigo <> xobj.CodigoGastoReparable Then
                Dim iObj As New SuperEntidad
                iObj.CodigoGastoReparable = xobj.CodigoGastoReparable
                iObj.NombreGastoReparable = xobj.NombreGastoReparable
                iObj.Unidad = xobj.Unidad
                'OBTENER EL PRIMER CARACTER DEL CODIGO ING/EGR PARA SABER 
                'SI ES INGRESO O EGRESO(1 : INGRESO , 2 : EGRESO)
                If iIngEgr = "1" Then
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS INGRESOS EN SOLES
                    iObj.IngresosSolCuentaBanco = xobj.ImporteSRegContabDeta
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS EGRESOS EN SOLES
                    iObj.SalidasSolCuentaBanco = 0
                    iObj.Cantidad = xobj.Cantidad
                Else
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS INGRESOS EN SOLES
                    iObj.IngresosSolCuentaBanco = 0
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS EGRESOS EN SOLES
                    iObj.SalidasSolCuentaBanco = xobj.ImporteSRegContabDeta
                    iObj.Cantidad = xobj.Cantidad
                End If
                iLisRes.Add(iObj)
                iCodigo = xobj.CodigoGastoReparable
                iIndiceFila += 1
            Else
                If iIngEgr = "1" Then
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS INGRESOS EN SOLES
                    iLisRes.Item(iIndiceFila).IngresosSolCuentaBanco += xobj.ImporteSRegContabDeta
                    iLisRes.Item(iIndiceFila).Cantidad += xobj.Cantidad
                Else
                    'ESTE CAMPO SE USA PARA ALMACENAR LOS EGRESOS EN SOLES
                    iLisRes.Item(iIndiceFila).SalidasSolCuentaBanco += xobj.ImporteSRegContabDeta
                    iLisRes.Item(iIndiceFila).Cantidad += xobj.Cantidad
                End If
            End If
        Next
        Return iLisRes
    End Function


    Function ListarRegistrosContablesDetalleEntrePeriodoConGastoReparableXCuenta(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New RegContabDetaAD
        Return objAD.ListarRegistrosContablesDetalleEntrePeriodoConGastoReparableXCuenta(ent)
        '\\
    End Function


    Function ListarRegistrosContablesDetalleXFiltroGastoReparable(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New RegContabDetaAD
        Return objAD.ListarRegistrosContablesDetalleXFiltroGastoReparable(ent)
        '\\
    End Function


    Sub EliminarVouchersPorDiferenciaCambioAutomatico(ByVal ent As SuperEntidad)
        'TRAER LAS REGCONTABCABE DE LA DIFERENCIA DE CAMBIO
        Dim iRccRN As New RegContabCabeRN
        Dim iRcdEN As New SuperEntidad
        Dim iLisRcc As List(Of SuperEntidad) = Me.obtenerDetalleRegContabPorDiferenciaCambioAutomatico(ent)

        'ELIMINAR DETALLE DE CADA CABECERA
        For Each xRcc As SuperEntidad In iLisRcc
            iRcdEN.ClaveRegContabCabe = xRcc.ClaveRegContabCabe
            Me.EliminarRegcontabDetalleXClaveCabecera(iRcdEN)
            iRccRN.eliminarRegContabFis(xRcc)
        Next

    End Sub


    Function obtenerDetalleRegContabPorDiferenciaCambioAutomatico(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = Me.vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.CodEmp
        ent.DatoCondicion1 = ent.CodigoEmpresa
        ent.CampoCondicion2 = cam.PeriodoRCC
        ent.DatoCondicion2 = ent.PeriodoRegContabCabe
        ent.CampoCondicion3 = cam.CodFilRC
        ent.DatoCondicion3 = ent.CodigoFile
        Dim objAD As New RegContabDetaAD
        listObj = objAD.SpObtenerRegistrosConTresCondicion(ent)
        Return listObj
        '\\
    End Function


    Sub EliminarRegcontabDetalleXClaveCabecera(ByRef ent As SuperEntidad)
        Dim objAD As New RegContabDetaAD
        objAD.EliminarRegcontabDetalleXClaveCabecera(ent)
    End Sub


    Sub ObtenerCabeceraYDetalleXAsientoCierreEgreso(ByRef pRcc As SuperEntidad, ByRef pRcd As List(Of SuperEntidad), ByRef pLisCta As List(Of SuperEntidad), ByRef pLisSal As List(Of SuperEntidad), ByVal pTipCam As Decimal, ByVal pParametro As SuperEntidad)

        'ARMANDO DATOS CABECERA
        pRcc.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        pRcc.PeriodoRegContabCabe = pRcc.AnoCuentaBanco + "13"
        pRcc.CodigoOrigen = "3"
        pRcc.CodigoFile = "397"
        pRcc.DiaVoucherRegContabCabe = "31"
        pRcc.FechaVoucherRegContabCabe = CType("31/12/" + pRcc.AnoCuentaBanco, Date)
        pRcc.FechaDocumento = pRcc.FechaVoucherRegContabCabe
        pRcc.FechaVencimiento = pRcc.FechaVoucherRegContabCabe
        pRcc.MonedaDocumento = "0"
        pRcc.MonedaDocumento1 = "0"
        pRcc.VentaTipoCambio = pTipCam
        pRcc.VentaEurTipoCambio = 1
        pRcc.IgvPar = 0
        pRcc.GlosaRegContabCabe = "ASIENTO CIERRE EJERCICIO " + pRcc.AnoCuentaBanco 'XXXXXXXXXXXXXXXX
        pRcc.EstadoRegContabCabe = "1"
        pRcc.Exporta = "0"
        pRcc.EstadoRegistro = "0"
        pRcc.EliminadoRegistro = "1"
        pRcc.ClaveRegContabCabe = pRcc.CodigoEmpresa
        pRcc.ClaveRegContabCabe += pRcc.PeriodoRegContabCabe
        pRcc.ClaveRegContabCabe += pRcc.CodigoOrigen
        pRcc.ClaveRegContabCabe += pRcc.CodigoFile
        pRcc.ClaveRegContabCabe += pRcc.NumeroVoucherRegContabCabe

        'ARMANDO DETALLE
        Dim iSalRN As New SaldoContableRN
        Dim iCtaRN As New PlanCuentaGeRN
        Dim iCtaEN As New SuperEntidad
        Dim iCorre As Integer = 0
        For Each xSal As SuperEntidad In pLisSal

            'VERIFICAR QUE LA CUENTA TENGA SALDO
            Dim iSalDH As Decimal = iSalRN.obtenerDiferenciaDebeHaberAcumuladoSinApertura(xSal, "12")

            'SI ES CERO NO PASA A LA LISTA
            If iSalDH <> 0 Then

                'SI LA CUENTA PERTENECE A EL  FLAG DE ASIENTO DE CIERRE DE EGRESO
                'PREGUNTAR SI LA CUENTA DE ESTA LISTA ES PARTE DE LAS CUENTAS
                'DE CIERRE DE EGRESO
                iCtaEN.CodigoCuentaPcge = xSal.CodigoCuentaPcge.Substring(0, 2)
                iCtaEN = iCtaRN.buscarCuentaExisPorCodigo(iCtaEN, pLisCta)

                If iCtaEN.CodigoCuentaPcge <> "" Then
                    Dim iRcdEN As New SuperEntidad
                    iRcdEN.ClaveRegContabCabe = pRcc.ClaveRegContabCabe
                    iCorre += 1
                    iRcdEN.CorrelativoRegContabDeta = iCorre.ToString.PadLeft(4, CType("0", Char))
                    iRcdEN.ClaveRegContabDeta = iRcdEN.ClaveRegContabCabe + iRcdEN.CorrelativoRegContabDeta
                    If xSal.FlagAuxiliarPcge = "1" Then
                        'iRcdEN.CodigoAuxiliar = "99999999999" 'XXXXXXXXXXXXXXX
                        iRcdEN.CodigoAuxiliar = "" 'XXXXXXXXXXXXXXX
                    End If
                    iRcdEN.CodigoCuentaPcge = xSal.CodigoCuentaPcge
                    iRcdEN.GlosaRegContabCabe = "ASIENTO CIERRE EJERCICIO " + pRcc.AnoCuentaBanco 'XXXXXXXXXXXXXXX
                    iRcdEN.DebeHaberRegContabDeta = "Haber"
                    pRcc.SumaHaberRegContabCabe += Math.Abs(iSalDH)
                    iRcdEN.VentaTipoCambio = pTipCam
                    iRcdEN.ImporteSRegContabDeta = Math.Abs(iSalDH)
                    iRcdEN.ImporteDRegContabDeta = Math.Abs(iSalDH) * pTipCam
                    iRcdEN.Exporta = "0"
                    iRcdEN.EstadoRegistro = "1"
                    iRcdEN.EliminadoRegistro = "1"
                    pRcd.Add(iRcdEN)
                End If
            End If
        Next

        'ARMANDO EL DETALLE QUE CIERRA AL ASIENTO(CUENTA 8)
        Dim iRcdEN1 As New SuperEntidad
        iRcdEN1.ClaveRegContabCabe = pRcc.ClaveRegContabCabe
        iCorre += 1
        iRcdEN1.CorrelativoRegContabDeta = iCorre.ToString.PadLeft(4, CType("0", Char))
        iRcdEN1.ClaveRegContabDeta = iRcdEN1.ClaveRegContabCabe + iRcdEN1.CorrelativoRegContabDeta
        iRcdEN1.CodigoAuxiliar = "" 'XXXXXXXXXXXXXXX
        iRcdEN1.CodigoCuentaPcge = pParametro.CuentaClase8Cierre '"8" 'XXXXXXXXXXXXXXXX
        iRcdEN1.GlosaRegContabCabe = "ASIENTO CIERRE EJERCICIO" + pRcc.AnoCuentaBanco 'XXXXXXXXXXXXXXX
        iRcdEN1.DebeHaberRegContabDeta = "Debe"
        pRcc.SumaDebeRegContabCabe = pRcc.SumaHaberRegContabCabe
        iRcdEN1.VentaTipoCambio = pTipCam
        iRcdEN1.ImporteSRegContabDeta = pRcc.SumaDebeRegContabCabe
        iRcdEN1.ImporteDRegContabDeta = pRcc.SumaDebeRegContabCabe * pTipCam
        iRcdEN1.Exporta = "0"
        iRcdEN1.EstadoRegistro = "1"
        iRcdEN1.EliminadoRegistro = "1"
        pRcd.Add(iRcdEN1)

        'PASAMOS EL ULTIMO CORRELATIVO A LA CABECERA
        pRcc.UltimoCorrelativo = iCorre.ToString.PadLeft(4, CType("0", Char))
    End Sub

    Sub ObtenerCabeceraYDetalleXAsientoCierreIngreso(ByRef pRcc As SuperEntidad, ByRef pRcd As List(Of SuperEntidad), ByRef pLisCta As List(Of SuperEntidad), ByRef pLisSal As List(Of SuperEntidad), ByVal pTipCam As Decimal, ByVal pParametro As SuperEntidad)

        'ARMANDO DATOS CABECERA
        pRcc.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        pRcc.PeriodoRegContabCabe = pRcc.AnoCuentaBanco + "13"
        pRcc.CodigoOrigen = "3"
        pRcc.CodigoFile = "397"
        pRcc.DiaVoucherRegContabCabe = "31"
        pRcc.FechaVoucherRegContabCabe = CType("31/12/" + pRcc.AnoCuentaBanco, Date)
        pRcc.FechaDocumento = pRcc.FechaVoucherRegContabCabe
        pRcc.FechaVencimiento = pRcc.FechaVoucherRegContabCabe
        pRcc.MonedaDocumento = "0"
        pRcc.MonedaDocumento1 = "0"
        pRcc.VentaTipoCambio = pTipCam
        pRcc.VentaEurTipoCambio = 1
        pRcc.IgvPar = 0
        pRcc.GlosaRegContabCabe = "ASIENTO CIERRE EJERCICIO " + pRcc.AnoCuentaBanco 'XXXXXXXXXXXXXXXX
        pRcc.EstadoRegContabCabe = "1"
        pRcc.Exporta = "0"
        pRcc.EstadoRegistro = "0"
        pRcc.EliminadoRegistro = "1"
        pRcc.ClaveRegContabCabe += pRcc.CodigoEmpresa
        pRcc.ClaveRegContabCabe += pRcc.PeriodoRegContabCabe
        pRcc.ClaveRegContabCabe += pRcc.CodigoOrigen
        pRcc.ClaveRegContabCabe += pRcc.CodigoFile
        pRcc.ClaveRegContabCabe += pRcc.NumeroVoucherRegContabCabe

        'ARMANDO DETALLE
        Dim iSalRN As New SaldoContableRN
        Dim iCtaRN As New PlanCuentaGeRN
        Dim iCtaEN As New SuperEntidad
        Dim iCorre As Integer = 0
        For Each xSal As SuperEntidad In pLisSal

            'VERIFICAR QUE LA CUENTA TENGA SALDO
            Dim iSalDH As Decimal = iSalRN.obtenerDiferenciaDebeHaberAcumuladoSinApertura(xSal, "12")

            'SI ES CERO NO PASA A LA LISTA
            If iSalDH <> 0 Then

                'SI LA CUENTA PERTENECE A EL  FLAG DE ASIENTO DE CIERRE DE EGRESO
                'PREGUNTAR SI LA CUENTA DE ESTA LISTA ES PARTE DE LAS CUENTAS
                'DE CIERRE DE EGRESO
                iCtaEN.CodigoCuentaPcge = xSal.CodigoCuentaPcge.Substring(0, 2)
                iCtaEN = iCtaRN.buscarCuentaExisPorCodigo(iCtaEN, pLisCta)

                If iCtaEN.CodigoCuentaPcge <> "" Then
                    Dim iRcdEN As New SuperEntidad
                    iRcdEN.ClaveRegContabCabe = pRcc.ClaveRegContabCabe
                    iCorre += 1
                    iRcdEN.CorrelativoRegContabDeta = iCorre.ToString.PadLeft(4, CType("0", Char))
                    iRcdEN.ClaveRegContabDeta = iRcdEN.ClaveRegContabCabe + iRcdEN.CorrelativoRegContabDeta
                    If xSal.FlagAuxiliarPcge = "1" Then
                        'iRcdEN.CodigoAuxiliar = "99999999999" 'XXXXXXXXXXXXXXX
                        iRcdEN.CodigoAuxiliar = "" 'XXXXXXXXXXXXXXX
                    End If
                    iRcdEN.CodigoCuentaPcge = xSal.CodigoCuentaPcge
                    iRcdEN.GlosaRegContabCabe = "ASIENTO CIERRE EJERCICIO " + pRcc.AnoCuentaBanco 'XXXXXXXXXXXXXXX
                    iRcdEN.DebeHaberRegContabDeta = "Debe"
                    pRcc.SumaDebeRegContabCabe += Math.Abs(iSalDH)
                    iRcdEN.VentaTipoCambio = pTipCam
                    iRcdEN.ImporteSRegContabDeta = Math.Abs(iSalDH)
                    iRcdEN.ImporteDRegContabDeta = Math.Abs(iSalDH) * pTipCam
                    iRcdEN.Exporta = "0"
                    iRcdEN.EstadoRegistro = "1"
                    iRcdEN.EliminadoRegistro = "1"
                    pRcd.Add(iRcdEN)
                End If
            End If
        Next

        'ARMANDO EL DETALLE QUE CIERRA AL ASIENTO(CUENTA 8)
        Dim iRcdEN1 As New SuperEntidad
        iRcdEN1.ClaveRegContabCabe = pRcc.ClaveRegContabCabe
        iCorre += 1
        iRcdEN1.CorrelativoRegContabDeta = iCorre.ToString.PadLeft(4, CType("0", Char))
        iRcdEN1.ClaveRegContabDeta = iRcdEN1.ClaveRegContabCabe + iRcdEN1.CorrelativoRegContabDeta
        iRcdEN1.CodigoAuxiliar = "" 'XXXXXXXXXXXXXXX
        iRcdEN1.CodigoCuentaPcge = pParametro.CuentaClase8Cierre  '"8" 'XXXXXXXXXXXXXXXX
        iRcdEN1.GlosaRegContabCabe = "APERTURA EJERCICIO " + pRcc.AnoCuentaBanco 'XXXXXXXXXXXXXXX
        iRcdEN1.DebeHaberRegContabDeta = "Haber"
        pRcc.SumaHaberRegContabCabe = pRcc.SumaDebeRegContabCabe
        iRcdEN1.VentaTipoCambio = pTipCam
        iRcdEN1.ImporteSRegContabDeta = pRcc.SumaHaberRegContabCabe
        iRcdEN1.ImporteDRegContabDeta = pRcc.SumaHaberRegContabCabe * pTipCam
        iRcdEN1.Exporta = "0"
        iRcdEN1.EstadoRegistro = "1"
        iRcdEN1.EliminadoRegistro = "1"
        pRcd.Add(iRcdEN1)

        'PASAMOS EL ULTIMO CORRELATIVO A LA CABECERA
        pRcc.UltimoCorrelativo = iCorre.ToString.PadLeft(4, CType("0", Char))
    End Sub

    Sub ObtenerCabeceraYDetalleXAsientoCierreCuenta8(ByRef pRcc As SuperEntidad, ByRef pLisRcc As List(Of SuperEntidad), ByRef pRcd As List(Of SuperEntidad), ByVal pTipCam As Decimal, ByVal pParametro As SuperEntidad)

        'ARMANDO DATOS CABECERA
        pRcc.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        pRcc.PeriodoRegContabCabe = pRcc.AnoCuentaBanco + "13"
        pRcc.CodigoOrigen = "3"
        pRcc.CodigoFile = "397"
        pRcc.DiaVoucherRegContabCabe = "31"
        pRcc.FechaVoucherRegContabCabe = CType("31/12/" + pRcc.AnoCuentaBanco, Date)
        pRcc.FechaDocumento = pRcc.FechaVoucherRegContabCabe
        pRcc.FechaVencimiento = pRcc.FechaVoucherRegContabCabe
        pRcc.MonedaDocumento = "0"
        pRcc.MonedaDocumento1 = "0"
        pRcc.VentaTipoCambio = pTipCam
        pRcc.VentaEurTipoCambio = 1
        pRcc.IgvPar = 0
        pRcc.GlosaRegContabCabe = "ASIENTO CIERRE EJERCICIO " + pRcc.AnoCuentaBanco 'XXXXXXXXXXXXXXXX
        pRcc.EstadoRegContabCabe = "1"
        pRcc.Exporta = "0"
        pRcc.EstadoRegistro = "0"
        pRcc.EliminadoRegistro = "1"
        pRcc.ClaveRegContabCabe += pRcc.CodigoEmpresa
        pRcc.ClaveRegContabCabe += pRcc.PeriodoRegContabCabe
        pRcc.ClaveRegContabCabe += pRcc.CodigoOrigen
        pRcc.ClaveRegContabCabe += pRcc.CodigoFile
        pRcc.ClaveRegContabCabe += pRcc.NumeroVoucherRegContabCabe

        'ARMANDO PRIMER DETALLE        
        Dim iRcdEN As New SuperEntidad
        iRcdEN.ClaveRegContabCabe = pRcc.ClaveRegContabCabe
        iRcdEN.CorrelativoRegContabDeta = "0001"
        iRcdEN.ClaveRegContabDeta = iRcdEN.ClaveRegContabCabe + iRcdEN.CorrelativoRegContabDeta
        iRcdEN.CodigoAuxiliar = "" 'XXXXXXXXXXXXXXX
        iRcdEN.CodigoCuentaPcge = pParametro.CuentaClase8Cierre ' "8" 'XXXXXXXXXXXXXXXXX
        iRcdEN.GlosaRegContabCabe = "ASIENTRO CIERRE EJERCICIO " + pRcc.AnoCuentaBanco 'XXXXXXXXXXXXXXX
        'SEGUN SALDO
        Dim iSaldo As Decimal = pLisRcc(1).SumaDebeRegContabCabe - pLisRcc(0).SumaHaberRegContabCabe
        If iSaldo < 0 Then
            iRcdEN.DebeHaberRegContabDeta = "Debe"
        Else
            iRcdEN.DebeHaberRegContabDeta = "Haber"
        End If
        pRcc.SumaDebeRegContabCabe = Math.Abs(iSaldo)
        iRcdEN.VentaTipoCambio = pTipCam
        iRcdEN.ImporteSRegContabDeta = Math.Abs(iSaldo)
        iRcdEN.ImporteDRegContabDeta = Math.Abs(iSaldo) * pTipCam
        iRcdEN.Exporta = "0"
        iRcdEN.EstadoRegistro = "1"
        iRcdEN.EliminadoRegistro = "1"
        pRcd.Add(iRcdEN)

        'ARMANDO EL SEGUNDO DETALLE
        Dim iRcdEN1 As New SuperEntidad
        iRcdEN1.ClaveRegContabCabe = pRcc.ClaveRegContabCabe
        iRcdEN1.CorrelativoRegContabDeta = "0002"
        iRcdEN1.ClaveRegContabDeta = iRcdEN1.ClaveRegContabCabe + iRcdEN1.CorrelativoRegContabDeta
        iRcdEN1.CodigoAuxiliar = "" '"99999999999" 'XXXXXXXXXXXXXXX
        'segun saldo
        If iSaldo < 0 Then
            iRcdEN1.CodigoCuentaPcge = pParametro.CuentaGananciaCierre '  "5" 'XXXXXXXXXXXXXXXX
            iRcdEN1.DebeHaberRegContabDeta = "Haber"      'Ganancia
        Else
            iRcdEN1.CodigoCuentaPcge = pParametro.CuentaPerdidaCierre  ' "5" 'XXXXXXXXXXXXXXXX
            iRcdEN1.DebeHaberRegContabDeta = "Debe"       'Perdida
        End If


        iRcdEN1.GlosaRegContabCabe = "ASIENTO CIERRE EJERCICIO " + pRcc.AnoCuentaBanco 'XXXXXXXXXXXXXXX
        pRcc.SumaHaberRegContabCabe = Math.Abs(iSaldo)
        iRcdEN1.VentaTipoCambio = pTipCam
        iRcdEN1.ImporteSRegContabDeta = Math.Abs(iSaldo)
        iRcdEN1.ImporteDRegContabDeta = Math.Abs(iSaldo) * pTipCam
        iRcdEN1.Exporta = "0"
        iRcdEN1.EstadoRegistro = "1"
        iRcdEN1.EliminadoRegistro = "1"
        pRcd.Add(iRcdEN1)

        'PASAMOS EL ULTIMO CORRELATIVO A LA CABECERA
        pRcc.UltimoCorrelativo = "0002"
    End Sub

    Function ListarRegistrosContablesDetalleXOrigenes(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New RegContabDetaAD
        Return objAD.ListarRegistrosContablesDetalleXOrigenes(ent)
        '\\
    End Function

    Function ListarSaldosPorAuxiliarYDocumentosSaldoNew(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim iLisSalHis As List(Of SuperEntidad) = Me.ListarSaldosPorAuxiliarYDocumentosTotalNew(ent)
        Dim iLisRes As New List(Of SuperEntidad)
        Dim iLisDoc As New List(Of SuperEntidad)

        For Each xMov As SuperEntidad In iLisSalHis
            'llenando cada documento
            iLisDoc.Add(xMov)
            If xMov.GlosaRegContabDeta = "Total Auxiliar" Then
                'chequear si este total auxiliar tiene saldo
                If xMov.SaldoCuentaCorriente <> 0 Then
                    iLisRes.AddRange(Me.ObtenerDocumentosPendientesNew(iLisDoc))
                End If
                iLisDoc.Clear()
            End If
        Next
        Return iLisRes
    End Function

    Function ListarSaldosPorAuxiliarYDocumentosTotalNew(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim iLisRes As New List(Of SuperEntidad)

        '// Trae una lista por auxlliares y documentos
        ent.CampoOrden = cam.CodAux + "," + cam.CodTipDoc + "," + cam.SerDoC + "," + cam.NumDoc + "," + cam.FechaAgr
        Dim iLisMov As List(Of SuperEntidad) = Me.ListarMovimientoDetalleXCuentaXAuxiliarEntrePeriodoNew(ent)

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

    Function ListarMovimientoDetalleXCuentaXAuxiliarEntrePeriodoNew(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        Dim objAD As New RegContabDetaAD
        Return objAD.ListarMovimientoDetalleXCuentaXAuxiliarEntrePeriodoNew(ent)

        '\\
    End Function

    Function ObtenerDocumentosPendientesNew(ByRef pLisDoc As List(Of SuperEntidad)) As List(Of SuperEntidad)
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

    Function obtenerDetalleRegContabPorPeriodoContabilizacion(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = Me.vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.PeriodoRCC
        ent.DatoCondicion1 = ent.PeriodoRegContabCabe
        ent.CampoCondicion2 = cam.CodEmp
        ent.DatoCondicion2 = SuperEntidad.xCodigoEmpresa
        Dim objAD As New RegContabDetaAD
        listObj = objAD.SpObtenerRegistrosConDosCondicion(ent)
        Return listObj
        '\\
    End Function

    Function ListarRegistrosContablesDetalleParaExportarAmacen(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New RegContabDetaAD
        Return objAD.ListarRegistrosContablesDetalleParaExportarAmacen(ent)
        '\\
    End Function

    Sub EliminarRegContabDetaXGastoOperativo(ByRef ent As SuperEntidad)
        '//
        '/Se elimina Fisicamente el registro
        Dim tabAD As New RegContabDetaAD
        tabAD.SpEliminarRegContabDetaXGastoOperativo(ent)
    End Sub

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
        Dim objAD As New RegContabDetaAD
        Return objAD.ListarMovimientoDetalleXCuentaXAuxiliarEntrePeriodo1(ent)

        '\\
    End Function

    Function obtenerMovimientoDetalleXAuxiliarYEntrePeriodo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsRegContabDeta"
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
        Dim objAD As New RegContabDetaAD
        listObj = objAD.SpObtenerRegistrosConDosCondicionDosFiltros(ent)
        Return listObj
        '\\
    End Function

    Function ListarMovimientosAuxiliarPorCuentas(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim iLisRes As New List(Of SuperEntidad)

        '// Trae una lista por auxlliares y documentos
        Dim iLisMov As List(Of SuperEntidad) = Me.ListarMovimientoDetalleParaAuxiliaresTodos(ent)


        Dim xCodigoCuenta As String = ""
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
            If xMov.FlagAlmacenPcge = "0" Then 'Soles
                'Es valor es para la columna US$
                xMov.ImporteRegContabCabe = 0
            Else
                xMov.ImporteRegContabCabe = xMov.ImporteDRegContabDeta
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
                    xobj.CodigoCuentaPcge = xCodigoCuenta
                    xobj.GlosaRegContabDeta = "Total Cuenta"
                    xobj.SaldoCuentaCorriente = xSaldoAcumulado + xSaldo
                    iLisRes.Add(xobj)
                End If

            Else
                If xCodigoCuenta <> "" Then
                    Dim xobj As New SuperEntidad
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
                    xobj.CodigoCuentaPcge = xCodigoCuenta
                    xobj.GlosaRegContabDeta = "Total Cuenta"
                    xobj.SaldoCuentaCorriente = xSaldoAcumulado + xSaldo
                    iLisRes.Add(xobj)
                End If
            End If

        Next
        Return iLisRes

        '\\
    End Function

    Function ListarMovimientoDetalleParaAuxiliaresTodos(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        Dim objAD As New RegContabDetaAD
        Return objAD.ListarMovimientoDetalleParaAuxiliaresTodos(ent)

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
                    iLisRes.AddRange(Me.ObtenerDocumentosPendientesNuevo(iLisDoc))
                End If
                iLisDoc.Clear()
            End If
        Next
        Return iLisRes
    End Function

    Function ObtenerDocumentosPendientesNuevo(ByRef pLisDoc As List(Of SuperEntidad)) As List(Of SuperEntidad)
        Dim iLisRes As New List(Of SuperEntidad)
        Dim iLisDoc As New List(Of SuperEntidad)
        Dim iDocumento As String = String.Empty
        Dim iObj As New SuperEntidad


        For Each xMov As SuperEntidad In pLisDoc

            If (iDocumento = xMov.TipoDocumento + xMov.SerieDocumento + xMov.NumeroDocumento) And xMov.GlosaRegContabDeta <> "Total Auxiliar" Then
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
                If xMov.Exporta = "US$" Then 'Soles
                    'Es valor es para la columna US$
                    xMov.ImporteRegContabCabe = xMov.ImporteDRegContabDeta * (-1)
                Else
                    xMov.ImporteRegContabCabe = 0
                End If
            Else
                If xMov.MonedaDocumento = "Dolares" Or xMov.MonedaDocumento = "US$" Or xMov.MonedaDocumento = "1" Then
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

    Function ListarMovimientoDetalleXCuentaXAuxiliarEntrePeriodo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        Dim objAD As New RegContabDetaAD
        Return objAD.ListarMovimientoDetalleXCuentaXAuxiliarEntrePeriodo(ent)

        '\\
    End Function

    Sub AdicionarRegContabDetasParaAsientoDocumentosPendientes(ByVal pRccEN As SuperEntidad, ByVal pContraCuenta As String, ByVal pDHContraCuenta As String, ByVal plisDocPen As List(Of SuperEntidad))

        'obtener la lista completa del asiento para documentos pendientes
        Dim iLisRcd As List(Of SuperEntidad) = Me.ListarRegContabDetasParaAsientoDocumentosPendientes(pRccEN, pContraCuenta, pDHContraCuenta, plisDocPen)

        'adicionar masivo
        Me.NuevoRegContabDetaMasivo(iLisRcd)

    End Sub

    Function ListarRegContabDetasParaAsientoDocumentosPendientes(ByVal pRccEN As SuperEntidad, ByVal pContraCuenta As String, ByVal pDHContraCuenta As String, ByVal plisDocPen As List(Of SuperEntidad)) As List(Of SuperEntidad)

        'lista resultado
        Dim iLisRes As New List(Of SuperEntidad)

        'obtener el valor debe o haber para la linea documento
        Dim pDHDoc As String = IIf(pDHContraCuenta = "Debe", "Haber", "Debe").ToString

        'recorrer cada objeto
        For Each xCueCor As SuperEntidad In plisDocPen

            'obtener linea documento pendiente y lo agregamos a la lista resultado
            iLisRes.Add(Me.ObtenerLineaDocumentoPendiente(xCueCor, pRccEN, pDHDoc))

            'obtener linea contra documento pendiente y lo agregamos a la lista resultado
            iLisRes.Add(Me.ObtenerLineaContraDocumentoPendiente(xCueCor, pRccEN, pContraCuenta, pDHContraCuenta))

        Next

        'ahora enumerar el correlativo de los regcontabdetas
        Me.EnumerarRegContabDetas(iLisRes)

        'devolver
        Return iLisRes

    End Function

    'Function ObtenerLineaDocumentoPendiente(ByVal pCueCor As SuperEntidad, ByVal pRccEN As SuperEntidad, ByVal pDH As String) As SuperEntidad

    '    'objeto resultado
    '    Dim iRcdEN As New SuperEntidad

    '    'pasando datos
    '    iRcdEN.ClaveRegContabCabe = pRccEN.ClaveRegContabCabe
    '    iRcdEN.CorrelativoRegContabDeta = "0001"
    '    iRcdEN.PeriodoRegContabCabe = pRccEN.PeriodoRegContabCabe
    '    iRcdEN.CodigoOrigen = pRccEN.CodigoOrigen
    '    iRcdEN.CodigoFile = pRccEN.CodigoFile
    '    iRcdEN.NumeroVoucherRegContabCabe = pRccEN.NumeroVoucherRegContabCabe
    '    iRcdEN.FechaVoucherRegContabCabe = pRccEN.FechaVoucherRegContabCabe
    '    iRcdEN.CodigoCuentaPcge = pCueCor.CodigoCuentaPcge
    '    iRcdEN.CodigoAuxiliar = pCueCor.CodigoAuxiliar
    '    iRcdEN.DebeHaberRegContabDeta = pDH
    '    iRcdEN.ImporteSRegContabDeta = CuentaCorrienteRN.ObtenerMontoEnSoles(pCueCor)
    '    iRcdEN.ImporteDRegContabDeta = CuentaCorrienteRN.ObtenerMontoEnDolares(pCueCor)
    '    iRcdEN.TipoDocumento = pCueCor.TipoDocumento
    '    iRcdEN.SerieDocumento = pCueCor.SerieDocumento
    '    iRcdEN.NumeroDocumento = pCueCor.NumeroDocumento
    '    iRcdEN.FechaDocumento = pCueCor.FechaDocumento
    '    iRcdEN.VentaTipoCambio = pCueCor.VentaTipoCambio
    '    iRcdEN.VentaEurTipoCambio = 0
    '    iRcdEN.CodigoIngEgr = ""
    '    iRcdEN.GlosaRegContabDeta = ""
    '    iRcdEN.CodigoCentroCosto = ""
    '    iRcdEN.Exporta = ""
    '    iRcdEN.CodigoArea = ""
    '    iRcdEN.CodigoPptoInterno = ""
    '    iRcdEN.Titulo = ""
    '    iRcdEN.CodigoInterno = ""
    '    iRcdEN.CodigoConcepto = ""
    '    iRcdEN.CodigoGastoReparable = ""
    '    iRcdEN.Cantidad = 0
    '    iRcdEN.Cuenta1242 = ""
    '    iRcdEN.EstadoRegContabDeta = ""
    '    iRcdEN.ImporteERegContabDeta = 0
    '    iRcdEN.CodigoFlujoCaja = ""
    '    iRcdEN.EstadoRegistro = "1"
    '    iRcdEN.EliminadoRegistro = "1"
    '    iRcdEN.ClaveRegContabDeta = iRcdEN.ClaveRegContabCabe + iRcdEN.CorrelativoRegContabDeta

    '    'devolver
    '    Return iRcdEN

    'End Function

    Function ObtenerLineaDocumentoPendiente(ByVal pCueCor As SuperEntidad, ByVal pRccEN As SuperEntidad, ByVal pDH As String) As SuperEntidad

        'objeto resultado
        Dim iRcdEN As New SuperEntidad

        'pasando datos
        iRcdEN.ClaveRegContabCabe = pRccEN.ClaveRegContabCabe
        iRcdEN.CorrelativoRegContabDeta = "0001"
        iRcdEN.PeriodoRegContabCabe = pRccEN.PeriodoRegContabCabe
        iRcdEN.CodigoOrigen = pRccEN.CodigoOrigen
        iRcdEN.CodigoFile = pRccEN.CodigoFile
        iRcdEN.NumeroVoucherRegContabCabe = pRccEN.NumeroVoucherRegContabCabe
        iRcdEN.FechaVoucherRegContabCabe = pRccEN.FechaVoucherRegContabCabe
        iRcdEN.CodigoCuentaPcge = pCueCor.CodigoCuentaPcge
        iRcdEN.CodigoAuxiliar = pCueCor.CodigoAuxiliar
        iRcdEN.DebeHaberRegContabDeta = pDH
        iRcdEN.ImporteSRegContabDeta = Math.Abs(CuentaCorrienteRN.ObtenerMontoEnSoles(pCueCor))
        iRcdEN.ImporteDRegContabDeta = Math.Abs(CuentaCorrienteRN.ObtenerMontoEnDolares(pCueCor))
        iRcdEN.TipoDocumento = pCueCor.TipoDocumento
        iRcdEN.SerieDocumento = pCueCor.SerieDocumento
        iRcdEN.NumeroDocumento = pCueCor.NumeroDocumento
        iRcdEN.FechaDocumento = pCueCor.FechaDocumento
        iRcdEN.VentaTipoCambio = pCueCor.VentaTipoCambio
        iRcdEN.VentaEurTipoCambio = 0
        iRcdEN.CodigoIngEgr = ""
        iRcdEN.GlosaRegContabDeta = ""
        iRcdEN.CodigoCentroCosto = ""
        iRcdEN.Exporta = ""
        iRcdEN.CodigoArea = ""
        iRcdEN.CodigoPptoInterno = ""
        iRcdEN.Titulo = ""
        iRcdEN.CodigoInterno = ""
        iRcdEN.CodigoConcepto = ""
        iRcdEN.CodigoGastoReparable = ""
        iRcdEN.Cantidad = 0
        iRcdEN.Cuenta1242 = ""
        iRcdEN.EstadoRegContabDeta = ""
        iRcdEN.ImporteERegContabDeta = 0
        iRcdEN.CodigoFlujoCaja = ""
        iRcdEN.EstadoRegistro = "1"
        iRcdEN.EliminadoRegistro = "1"
        iRcdEN.ClaveRegContabDeta = iRcdEN.ClaveRegContabCabe + iRcdEN.CorrelativoRegContabDeta

        'devolver
        Return iRcdEN

    End Function




    'Function ObtenerLineaContraDocumentoPendiente(ByVal pCueCor As SuperEntidad, ByVal pRccEN As SuperEntidad, ByVal pContraCuenta As String, ByVal pDHContraCuenta As String) As SuperEntidad

    '    'objeto resultado
    '    Dim iRcdEN As New SuperEntidad

    '    'pasando datos
    '    iRcdEN.ClaveRegContabCabe = pRccEN.ClaveRegContabCabe
    '    iRcdEN.CorrelativoRegContabDeta = "0002"
    '    iRcdEN.PeriodoRegContabCabe = pRccEN.PeriodoRegContabCabe
    '    iRcdEN.CodigoOrigen = pRccEN.CodigoOrigen
    '    iRcdEN.CodigoFile = pRccEN.CodigoFile
    '    iRcdEN.NumeroVoucherRegContabCabe = pRccEN.NumeroVoucherRegContabCabe
    '    iRcdEN.FechaVoucherRegContabCabe = pRccEN.FechaVoucherRegContabCabe
    '    iRcdEN.CodigoCuentaPcge = pContraCuenta
    '    iRcdEN.CodigoAuxiliar = ""
    '    iRcdEN.DebeHaberRegContabDeta = pDHContraCuenta
    '    iRcdEN.ImporteSRegContabDeta = CuentaCorrienteRN.ObtenerMontoEnSoles(pCueCor)
    '    iRcdEN.ImporteDRegContabDeta = CuentaCorrienteRN.ObtenerMontoEnDolares(pCueCor)
    '    iRcdEN.TipoDocumento = ""
    '    iRcdEN.SerieDocumento = ""
    '    iRcdEN.NumeroDocumento = ""
    '    iRcdEN.FechaDocumento = DateTime.Today
    '    iRcdEN.VentaTipoCambio = pCueCor.VentaTipoCambio
    '    iRcdEN.VentaEurTipoCambio = 0
    '    iRcdEN.CodigoIngEgr = ""
    '    iRcdEN.GlosaRegContabDeta = ""
    '    iRcdEN.CodigoCentroCosto = ""
    '    iRcdEN.Exporta = ""
    '    iRcdEN.CodigoArea = ""
    '    iRcdEN.CodigoPptoInterno = ""
    '    iRcdEN.Titulo = ""
    '    iRcdEN.CodigoInterno = ""
    '    iRcdEN.CodigoConcepto = ""
    '    iRcdEN.CodigoGastoReparable = ""
    '    iRcdEN.Cantidad = 0
    '    iRcdEN.Cuenta1242 = ""
    '    iRcdEN.EstadoRegContabDeta = ""
    '    iRcdEN.ImporteERegContabDeta = 0
    '    iRcdEN.CodigoFlujoCaja = ""
    '    iRcdEN.EstadoRegistro = "1"
    '    iRcdEN.EliminadoRegistro = "1"
    '    iRcdEN.ClaveRegContabDeta = iRcdEN.ClaveRegContabCabe + iRcdEN.CorrelativoRegContabDeta

    '    'devolver
    '    Return iRcdEN

    'End Function

    Function ObtenerLineaContraDocumentoPendiente(ByVal pCueCor As SuperEntidad, ByVal pRccEN As SuperEntidad, ByVal pContraCuenta As String, ByVal pDHContraCuenta As String) As SuperEntidad

        'objeto resultado
        Dim iRcdEN As New SuperEntidad

        'pasando datos
        iRcdEN.ClaveRegContabCabe = pRccEN.ClaveRegContabCabe
        iRcdEN.CorrelativoRegContabDeta = "0002"
        iRcdEN.PeriodoRegContabCabe = pRccEN.PeriodoRegContabCabe
        iRcdEN.CodigoOrigen = pRccEN.CodigoOrigen
        iRcdEN.CodigoFile = pRccEN.CodigoFile
        iRcdEN.NumeroVoucherRegContabCabe = pRccEN.NumeroVoucherRegContabCabe
        iRcdEN.FechaVoucherRegContabCabe = pRccEN.FechaVoucherRegContabCabe
        iRcdEN.CodigoCuentaPcge = pContraCuenta
        iRcdEN.CodigoAuxiliar = ""
        iRcdEN.DebeHaberRegContabDeta = pDHContraCuenta
        iRcdEN.ImporteSRegContabDeta = Math.Abs(CuentaCorrienteRN.ObtenerMontoEnSoles(pCueCor))
        iRcdEN.ImporteDRegContabDeta = Math.Abs(CuentaCorrienteRN.ObtenerMontoEnDolares(pCueCor))
        iRcdEN.TipoDocumento = ""
        iRcdEN.SerieDocumento = ""
        iRcdEN.NumeroDocumento = ""
        iRcdEN.FechaDocumento = DateTime.Today
        iRcdEN.VentaTipoCambio = pCueCor.VentaTipoCambio
        iRcdEN.VentaEurTipoCambio = 0
        iRcdEN.CodigoIngEgr = ""
        iRcdEN.GlosaRegContabDeta = ""
        iRcdEN.CodigoCentroCosto = ""
        iRcdEN.Exporta = ""
        iRcdEN.CodigoArea = ""
        iRcdEN.CodigoPptoInterno = ""
        iRcdEN.Titulo = ""
        iRcdEN.CodigoInterno = ""
        iRcdEN.CodigoConcepto = ""
        iRcdEN.CodigoGastoReparable = ""
        iRcdEN.Cantidad = 0
        iRcdEN.Cuenta1242 = ""
        iRcdEN.EstadoRegContabDeta = ""
        iRcdEN.ImporteERegContabDeta = 0
        iRcdEN.CodigoFlujoCaja = ""
        iRcdEN.EstadoRegistro = "1"
        iRcdEN.EliminadoRegistro = "1"
        iRcdEN.ClaveRegContabDeta = iRcdEN.ClaveRegContabCabe + iRcdEN.CorrelativoRegContabDeta

        'devolver
        Return iRcdEN

    End Function



    Sub EnumerarRegContabDetas(ByRef pLisRcd As List(Of SuperEntidad))

        'correlativo
        Dim iCorrelativo As Integer = 0

        'recorrer cada objeto
        For Each xRcd As SuperEntidad In pLisRcd

            'aumentar en 1
            iCorrelativo += 1

            'actualizamos el correlativo del objeto
            xRcd.CorrelativoRegContabDeta = iCorrelativo.ToString.PadLeft(4, CType("0", Char))

            'tambien actualizamos su clave
            xRcd.ClaveRegContabDeta = xRcd.ClaveRegContabCabe + xRcd.CorrelativoRegContabDeta

        Next

    End Sub



End Class
