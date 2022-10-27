Option Explicit On
Option Strict On
Imports Entidad
Imports Negocio
Imports System
Imports System.IO
Imports System.Threading
'Imports LibreriaGeneral

Public Class WExportarRegistroComprasNuevos
    Public cam As New CamposEntidad
    Public acc As New Accion


#Region "Metodos"

    Sub NuevaVentana()
        '//
        acc.listaCtrls = Me.ListaControles
        acc.PasaFoco()
        acc.FomatoDato()
        acc.PasarCursor()
        acc.Teclazo()
        acc.Valida()
        Me.Show()
        Me.ValoresPorDefecto()
        Me.txtCodMes.Focus()
        '\\
    End Sub

    Sub ValoresPorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.txtNomEmp.Text = SuperEntidad.xRazonSocial
        Me.TxtRuc.Text = SuperEntidad.xRucEmpresa
        Me.txtAno.Text = SuperEntidad.xPeriodoEmpresa.Substring(0, 4)
    End Sub

    Sub hilo2()
        Me.tslEstadoExp.Text = "Esperar..."
    End Sub

    Sub hilo1()
        'TRAER TODAS LAS COMPRAS DEL PERIODO ELEGIDO
        Dim iRccRN As New RegContabCabeRN
        Dim iRccEN As New SuperEntidad
        iRccEN.CodigoOrigen = "4" 'COMPRAS
        iRccEN.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        iRccEN.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        iRccEN.CampoOrden = cam.ClaveRCC
        'Dim iLisRcc As List(Of SuperEntidad) = iRccRN.ListarRegistroContableCabeceraXPeriodoXOrigenSinEstornar(iRccEN)
        Dim iLisRcc As List(Of SuperEntidad) = iRccRN.ListarComprasNacionalesPle(iRccEN)

        'LISTAR PAGOS DEL PERIODO
        iRccEN.CodigoOrigen = "2" 'egresos
        iRccEN.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        iRccEN.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        iRccEN.CampoOrden = cam.ClaveRCC
        Dim iLisRccPag As List(Of SuperEntidad) = iRccRN.obtenerRegContabCabeExisXOrigenYPeriodo(iRccEN)

        'ARMANDO LA RUTA DEL ARCHIVO DE TEXTO
        Dim ARCHIVO_CSV As String = Me.txtRuta.Text + "\" + Me.txtNomArchivo.Text + ".txt"

        'CREANDO EL ARCHOVO DE TEXTO EN LA RUTA INDICADA(ARCHIVO_CSV)
        Dim iArchivo As StreamWriter = New StreamWriter(ARCHIVO_CSV)

        'REPRESENTA A UNA LINEA DEL ARCHIVO DE TEXTO
        Dim linea As String = String.Empty

        'RECORRIENDO CADA OBJETO COMPRA PARA LUEGO TRANSFORMARLA EN
        'UNA LINEA DE TEXTO Y AGREGARLA AL ARCHIVO
        For Each xObj As SuperEntidad In iLisRcc
            'LIMPIAMOS LA LINEA PARA EMPEZAR DE NUEVO
            linea = String.Empty
            'PERIODO 1
            linea += xObj.PeriodoRegContabCabe + "00"
            linea += "|"
            'NUMERO DEL REGISTRO(LA CLAVE SERIA CLAVEREGCONTABCABE) 2
            linea += xObj.ClaveRegContabCabe
            linea += "|"
            'NUMERO VOUCHER 3
            linea += "M" + xObj.NumeroVoucherRegContabCabe
            linea += "|"
            'FECHA EMISION DEL COMPROBANTE 4
            linea += xObj.FechaDocumento.ToShortDateString
            linea += "|"
            'FECHA VENCIMIENTO DEL COMPROBANTE 5
            If xObj.TipoDocumento = "14" Then
                linea += xObj.FechaDocumento.ToShortDateString
            Else
                linea += " "
            End If

            linea += "|"
            'TIPO DOCUMENTO 6
            linea += xObj.TipoDocumento
            linea += "|"
            'SERIE DOCUMENTO 7
            If xObj.TipoDocumento = "05" Then
                linea += "1"
            Else
                If xObj.TipoDocumento = "10" Then
                    linea += "1683"
                Else
                    linea += xObj.SerieDocumento
                End If
            End If
            linea += "|"
            'AÑO EMISION DUA
            If xObj.TipoDocumento = "50" Then
                linea += xObj.FechaDocumento.Year.ToString
                linea += "|"
            Else
                linea += "0"
                linea += "|"
            End If
            'NUMERO DOCUMENTO 9
            If xObj.TipoDocumento = "01" Or xObj.TipoDocumento = "03" Or xObj.TipoDocumento = "06" Or xObj.TipoDocumento = "07" Or xObj.TipoDocumento = "08" Then
                linea += xObj.NumeroDocumento.Substring(8)
                linea += "|"
            Else
                If xObj.TipoDocumento = "05" Then
                    linea += xObj.NumeroDocumento.Substring(4)
                    linea += "|"
                Else
                    linea += xObj.NumeroDocumento
                    linea += "|"
                End If
                ' linea += xObj.NumeroDocumento
                ' linea += "|"
            End If
            'POSICION 10
            linea += " "
            linea += "|"
            'TIPO DOCUMENTO AUXILIAR 11
            linea += xObj.TipoDocumentoAuxiliar
            linea += "|"
            'RUC O DNI AUXILIAR 12
            linea += xObj.CodigoAuxiliar
            linea += "|"
            'NOMBRE DE AUXILIAR 13
            linea += Varios.CortarCadena(xObj.DescripcionAuxiliar, 59)
            linea += "|"
            'SEGUN MODO DE COMPRA 14
            Select Case xObj.ModoCompra
                Case "Destinadas a Vtas Gravadas Excl"
                    If xObj.CodigoFile = "407" Then
                        linea += (xObj.ValorVtaSolRegContabCabe * -1).ToString
                    Else
                        linea += xObj.ValorVtaSolRegContabCabe.ToString
                    End If
                    ' linea += xObj.ValorVtaSolRegContabCabe.ToString
                    linea += "|"
                    If xObj.CodigoFile = "407" Then
                        linea += (xObj.IgvSolRegContabCabe * -1).ToString
                    Else
                        linea += xObj.IgvSolRegContabCabe.ToString
                    End If
                    ' linea += xObj.IgvSolRegContabCabe.ToString
                    linea += "|"
                    linea += "0.00|0.00|"
                    linea += "0.00|0.00|"
                Case "Destinadas a Vtas Gravadas y No Gravadas"
                    linea += "0.00|0.00|"
                    If xObj.CodigoFile = "407" Then
                        linea += (xObj.ValorVtaSolRegContabCabe * -1).ToString
                    Else
                        linea += xObj.ValorVtaSolRegContabCabe.ToString
                    End If
                    'linea += xObj.ValorVtaSolRegContabCabe.ToString
                    linea += "|"
                    If xObj.CodigoFile = "407" Then
                        linea += (xObj.IgvSolRegContabCabe * -1).ToString
                    Else
                        linea += xObj.IgvSolRegContabCabe.ToString
                    End If
                    'linea += xObj.IgvSolRegContabCabe.ToString
                    linea += "|"
                    linea += "0.00|0.00|"
                Case "Destinadas a Vtas No Gravadas Excl"
                    linea += "0.00|0.00|"
                    linea += "0.00|0.00|"
                    If xObj.CodigoFile = "407" Then
                        linea += (xObj.ValorVtaSolRegContabCabe * -1).ToString
                    Else
                        linea += xObj.ValorVtaSolRegContabCabe.ToString
                    End If
                    'linea += xObj.ValorVtaSolRegContabCabe.ToString
                    linea += "|"
                    If xObj.CodigoFile = "407" Then
                        linea += (xObj.IgvSolRegContabCabe * -1).ToString
                    Else
                        linea += xObj.IgvSolRegContabCabe.ToString
                    End If
                    'linea += xObj.IgvSolRegContabCabe.ToString
                    linea += "|"
            End Select
            'EXONERADO 15
            If xObj.CodigoFile = "407" Then
                linea += (xObj.ExoneradoSolRegContabCabe * -1).ToString
            Else
                linea += xObj.ExoneradoSolRegContabCabe.ToString
            End If
            ' linea += xObj.ExoneradoSolRegContabCabe.ToString
            linea += "|"
            linea += "0.00|0.00|0.00|" 'Aca se adiciono bolsa plastico
            'PRECIO VENTA 23
            If xObj.CodigoFile = "407" Then
                linea += (xObj.PrecioVtaSolRegContabCabe * -1).ToString
            Else
                linea += xObj.PrecioVtaSolRegContabCabe.ToString
            End If
            'linea += xObj.PrecioVtaSolRegContabCabe.ToString
            linea += "|"
            'moneda 24
            If xObj.MonedaDocumento = "S/." Then
                linea += "PEN"
                linea += "|"
            Else
                linea += "USD"
                linea += "|"
            End If
            'TIPO CAMBIO 25
            linea += xObj.VentaTipoCambio.ToString
            linea += "|"
            'PARA NOTAS
            If xObj.TipoDocumento1.Trim = String.Empty Then
                'FECHA DOCUMENTO NOTA SI NO HAY PONER(01/01/0001) 26
                linea += "01/01/0001"
                linea += "|"
                'TIPO DOCUMENTO 27
                linea += "00"
                linea += "|"
                'SERIE DOCUEMNTO 28
                linea += "-"
                linea += "|"
                'CODIGO DEPENDENCIA ADUANERA 29
                linea += "   "
                linea += "|"
                'NUMERO DOCUMENTO 30
                linea += "-"
                linea += "|"
            Else
                'FECHA DOCUMENTO NOTA  26
                linea += xObj.FechaDocumento1
                linea += "|"
                'TIPO DOCUMENTO 27
                linea += xObj.TipoDocumento1
                linea += "|"
                'SERIE DOCUEMNTO 28
                linea += xObj.SerieDocumento1
                linea += "|"
                'CODIGO DEPENDENCIA ADUANERA 29
                linea += "   "
                linea += "|"
                'NUMERO DOCUMENTO 30
                linea += xObj.NumeroDocumento1.Substring(8)
                linea += "|"
            End If
            ''LINEA 30
            'linea += "-"
            'linea += "|"
            'DETRACION
            If xObj.DetraccionRegContabCabe = "No" Then
                'FECHA 31
                linea += "01/01/0001"
                linea += "|"
                'NUMERO 32
                linea += "0"
                linea += "|"
                'LINEA 33
                linea += " "
                linea += "|"
            Else
                'FECHA 31
                linea += xObj.FechaDetraccionRegContabCabe
                linea += "|"
                'NUMERO 32
                linea += xObj.NumeroPapeletaRegContabCabe
                linea += "|"
                'LINEA 33
                linea += "1"
                linea += "|"
            End If
            'LINEA 34
            linea += "5"
            linea += "|"
            'LINEA 35
            linea += " |"
            'LINEA 36
            If xObj.TipoDocumento = "14" Then
                linea += " "
                linea += "|"
                linea += " "
                linea += "|"
                linea += " "
                linea += "|"
            Else
                linea += "1"
                linea += "|"
                linea += "1"
                linea += "|"
                linea += "1"
                linea += "|"
            End If
            'LINEA 39
            If xObj.TipoDocumento = "04" Then
                linea += "0"
                linea += "|"
            Else
                linea += "1"
                linea += "|"
            End If
            'LINEA 40
            Dim iRccPagEN As New SuperEntidad
            iRccPagEN.ClaveDocumentoCuentaCorriente += xObj.CodigoAuxiliar
            iRccPagEN.ClaveDocumentoCuentaCorriente += xObj.TipoDocumento
            iRccPagEN.ClaveDocumentoCuentaCorriente += xObj.SerieDocumento
            iRccPagEN.ClaveDocumentoCuentaCorriente += xObj.NumeroDocumento
            iRccPagEN = RegContabCabeRN.ObtenerPrimerPagoDocumento(iRccPagEN, iLisRccPag)

            If iRccPagEN.ClaveRegContabCabe = "" Then
                linea += " "
                linea += "|"
            Else
                linea += "1"
                linea += "|"
            End If

            'LINEA 41
            If xObj.PeriodoRegContabCabe + "00" < Varios.AñoMesDiaSinBarra(xObj.FechaDocumento) Then
                If xObj.TipoDocumento = "03" Or xObj.TipoDocumento = "10" Or xObj.TipoDocumento = "15" Or xObj.TipoDocumento = "16" Then
                    linea += "0"
                Else
                    linea += "1"
                End If
                linea += "|"
            Else
                If xObj.TipoDocumento = "03" Or xObj.TipoDocumento = "10" Or xObj.TipoDocumento = "15" Or xObj.TipoDocumento = "16" Then
                    linea += "0"
                Else
                    linea += "6"
                End If
                linea += "|"
            End If
            iArchivo.WriteLine(linea)
        Next
        iArchivo.Dispose()
        iArchivo.Close()
        Me.tslEstadoExp.Text = "Proceso terminado"
    End Sub

    Sub SeleccionUbicacion()
        Dim iRuta As New FolderBrowserDialog
        If iRuta.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.txtRuta.Text = iRuta.SelectedPath
        End If
    End Sub

    Sub ArmarNombreArchivo()
        Dim iNombre As String = ""
        If Me.txtCodMes.Text.Trim <> "" Then
            iNombre += "LE"
            iNombre += Me.TxtRuc.Text.Trim
            iNombre += Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim + "00"
            iNombre += "080100001111"

            'iNombre += Me.TxtCodEmp.Text.Trim
            'iNombre += Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        End If
        Me.txtNomArchivo.Text = iNombre
    End Sub

    Function ValidarExportacion() As Boolean
        ''PRIMERO QUE EXISTA MES
        'If Me.txtCodMes.Text.Trim = "" Then
        '    MsgBox("Debes eligir un mes")
        '    Me.txtCodMes.Focus()
        '    Return False
        'End If

        'VALIDAR LA CARPETA DONDE SE GUARDAR EL ARCHIVO
        If Me.txtRuta.Text.Trim = "" Then
            MsgBox("Debes seleccionar la carpeta para tu archivo")
            Me.btnAceptar.Focus()
            Return False
        End If
        Return True
    End Function


#End Region



    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If acc.CamposObligatorios = False Then
            Exit Sub
        Else
            'VALIDAR ANTES DE EJECUTAR
            If Me.ValidarExportacion = False Then Exit Sub

            'EMPEZAR CON EL PROCESO DE EXPORTACION
            Dim mih1, mih2 As Thread
            mih1 = New Thread(AddressOf hilo1)
            mih2 = New Thread(AddressOf hilo2)
            mih1.Start()
            mih2.Start()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub


    Private Sub txtCodMes_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodMes.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.txtCodMes : ope.txt2 = Me.txtDesMes
        ope.MostrarCodigoDescripcionDeTabla("Mes", "Meses", e)
    End Sub

    Private Sub txtCodMes_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodMes.KeyDown
        If Me.txtCodMes.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarTabla
                win.tabla = "Mes"
                win.titulo = "Meses"
                win.txt1 = Me.txtCodMes
                win.txt2 = Me.txtDesMes
                win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub btnBuscarRuta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarRuta.Click
        Me.SeleccionUbicacion()
    End Sub

    Private Sub txtCodMes_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodMes.Validated
        Me.ArmarNombreArchivo()
    End Sub
End Class