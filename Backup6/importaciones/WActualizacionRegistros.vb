Imports System.Data.OleDb
Imports System.Xml
Imports Entidad
Imports Negocio

Public Class WActualizacionRegistros

    Public cam As New CamposEntidad
  

    Sub ActualizarDocumentosContables()
        ''TRAER LA LISTA DE TODO LOS REGISTROS CONTABLES CABECERA
        ''QUE EXISTEN EN LA BASE DE DATOS
        'Dim iRccRN As New RegContabCabeRN
        'Dim iRccEN As New SuperEntidad
        'iRccEN.CampoOrden = cam.ClaveRCC
        'Dim iLisRcc As List(Of SuperEntidad) = iRccRN.obtenerRegContabTodos(iRccEN)

        ''RECORRER CADA CABECERA Y MODIFICAR SU DOCUMENTO
        'For Each xObj As SuperEntidad In iLisRcc
        '    'SI NO TIENE TIPO DOCUMENTO ENTONCES TAMBIEN NO TENDRA
        '    'SERIE NI NUMERO DOCUMENTO
        '    If xObj.TipoDocumento.Trim = "" Then
        '        xObj.TipoDocumento = ""
        '        xObj.SerieDocumento = ""
        '        xObj.NumeroDocumento = ""
        '    Else
        '        xObj.SerieDocumento = xObj.SerieDocumento.PadLeft(4, CType("0", Char))
        '        xObj.NumeroDocumento = xObj.NumeroDocumento.PadLeft(15, CType("0", Char))
        '    End If
        '    iRccRN.modificarRegContab(xObj)
        'Next


        'TRAER LA LISTA DE TODO LOS REGISTROS CONTABLES DETALLE
        'QUE EXISTEN EN LA BASE DE DATOS
        Dim iRcdRN As New RegContabDetaRN
        Dim iRcdEN As New SuperEntidad
        iRcdEN.CampoOrden = cam.ClaveRCC
        Dim iLisRcd As List(Of SuperEntidad) = iRcdRN.obtenerDetalleRegContabTodos(iRcdEN)

        'RECORRER CADA CABECERA Y MODIFICAR SU DOCUMENTO
        For Each xObj As SuperEntidad In iLisRcd
            'ELIMINAMOS EL DETALLE
            iRcdRN.eliminarRegContabDetaPorClave(xObj)

            'SI NO TIENE TIPO DOCUMENTO ENTONCES TAMBIEN NO TENDRA
            'SERIE NI NUMERO DOCUMENTO
            If xObj.TipoDocumento.Trim = "" Then
                xObj.TipoDocumento = ""
                xObj.SerieDocumento = ""
                xObj.NumeroDocumento = ""
            Else
                xObj.SerieDocumento = xObj.SerieDocumento.PadLeft(4, CType("0", Char))
                xObj.NumeroDocumento = xObj.NumeroDocumento.PadLeft(15, CType("0", Char))
            End If
            iRcdRN.nuevoRegContabDeta(xObj)
        Next

        'TRAER LA LISTA DE TODO LAS CUENTAS CORRIENTES
        'QUE EXISTEN EN LA BASE DE DATOS
        Dim iCcRN As New CuentaCorrienteRN
        Dim iCcEN As New SuperEntidad
        iCcEN.CampoOrden = cam.ClaveCtaCte
        Dim iLisCc As List(Of SuperEntidad) = iCcRN.obtenerCuentaCorrienteExis(iCcEN)

        'RECORRER CADA CABECERA Y MODIFICAR SU DOCUMENTO
        For Each xObj As SuperEntidad In iLisCc
            'SI NO TIENE TIPO DOCUMENTO ENTONCES TAMBIEN NO TENDRA
            'SERIE NI NUMERO DOCUMENTO
            If xObj.TipoDocumento.Trim = "" Then
                xObj.TipoDocumento = ""
                xObj.SerieDocumento = ""
                xObj.NumeroDocumento = ""
            Else
                xObj.SerieDocumento = xObj.SerieDocumento.PadLeft(4, CType("0", Char))
                xObj.NumeroDocumento = xObj.NumeroDocumento.PadLeft(15, CType("0", Char))
                xObj.ClaveDocumentoCuentaCorriente = ""
                xObj.ClaveDocumentoCuentaCorriente += xObj.CodigoEmpresa
                xObj.ClaveDocumentoCuentaCorriente += xObj.CodigoAuxiliar
                xObj.ClaveDocumentoCuentaCorriente += xObj.TipoDocumento
                xObj.ClaveDocumentoCuentaCorriente += xObj.SerieDocumento
                xObj.ClaveDocumentoCuentaCorriente += xObj.NumeroDocumento
            End If
            iCcRN.modificarCuentaCorriente(xObj)
        Next

        MsgBox("la espera termino")

    End Sub

    Sub ActualizarPagosDocumentos()
        Dim ccte As New CuentaCorrienteRN

        'TRAER LA LISTA DE TODO LOS REGISTROS CONTABLES DETALLE
        'QUE EXISTEN EN LA BASE DE DATOS
        Dim iRcdRN As New RegContabDetaRN
        Dim iRcdEN As New SuperEntidad
        iRcdEN.CampoOrden = cam.ClaveRCC
        Dim iLisRcd As List(Of SuperEntidad) = iRcdRN.obtenerDetalleRegContabTodos(iRcdEN)

        Dim cc As New SuperEntidad

        'RECORRER CADA CABECERA Y MODIFICAR SU DOCUMENTO
        For Each xObj As SuperEntidad In iLisRcd
            If (xObj.CodigoOrigen = "1" Or xObj.CodigoOrigen = "2" Or xObj.CodigoOrigen = "3") And xObj.PeriodoRegContabCabe.Substring(4, 2) <> "00" Then
                'Llenando el detalle
                cc.CodigoEmpresa = xObj.CodigoEmpresa
                cc.CodigoAuxiliar = xObj.CodigoAuxiliar
                cc.TipoDocumento = xObj.TipoDocumento
                cc.SerieDocumento = xObj.SerieDocumento
                cc.NumeroDocumento = xObj.NumeroDocumento
                cc.ClaveDocumentoCuentaCorriente = cc.CodigoEmpresa + cc.CodigoAuxiliar + cc.TipoDocumento + cc.SerieDocumento + cc.NumeroDocumento

                '' Buscar Cuenta Corriente
                cc = ccte.buscarCuentaCorrienteExisPorClaveDoc(cc)
                If cc.ClaveDocumentoCuentaCorriente <> "" Then
                    Select Case cc.MonedaDocumento
                        Case "S/."
                            cc.ImportePagadoCuentaCorriente = cc.ImportePagadoCuentaCorriente + xObj.ImporteSRegContabDeta
                        Case "US$"
                            cc.ImportePagadoCuentaCorriente = cc.ImportePagadoCuentaCorriente + xObj.ImporteDRegContabDeta
                        Case "EUR"
                            cc.ImportePagadoCuentaCorriente = cc.ImportePagadoCuentaCorriente + xObj.ImporteERegContabDeta
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
        MsgBox("ya falta poco")

    End Sub

  

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.ActualizarDocumentosContables()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.ActualizarPagosDocumentos()
    End Sub
End Class