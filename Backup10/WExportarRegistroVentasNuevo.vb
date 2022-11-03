Option Explicit On
Option Strict On
Imports Entidad
Imports Negocio
Imports System
Imports System.IO
Imports System.Threading


Public Class WExportarRegistroVentasNuevo
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
        Me.txtAno.Text = SuperEntidad.xPeriodoEmpresa.Substring(0, 4)
    End Sub

    Sub hilo2()
        Me.tslEstadoExp.Text = "Esperar..."
    End Sub

    Sub hilo1()
        'TRAER TODAS LAS VENTAS DEL PERIODO ELEGIDO
        Dim iRccRN As New RegContabCabeRN
        Dim iRccEN As New SuperEntidad
        iRccEN.CodigoOrigen = "5" 'VENTAS
        iRccEN.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        iRccEN.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        iRccEN.CampoOrden = cam.ClaveRCC
        Dim iLisRcc As List(Of SuperEntidad) = iRccRN.ListarRegistroContableCabeceraXPeriodoXOrigenSinEstornar(iRccEN)

        'LISTAR COBRANZAS DEL PERIODO
        iRccEN.CodigoOrigen = "1" 'iNGRESOS
        iRccEN.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        iRccEN.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        iRccEN.CampoOrden = cam.ClaveRCC
        Dim iLisRccPag As List(Of SuperEntidad) = iRccRN.obtenerRegContabCabeExisXOrigenYPeriodo(iRccEN)

        'ARMANDO LA RUTA DEL ARCHIVO DE TEXTO
        Dim ARCHIVO_CSV As String = Me.txtRuta.Text + "\" + Me.txtNomArchivo.Text + ".txt"

        'CREANDO EL ARCHIVO DE TEXTO EN LA RUTA INDICADA(ARCHIVO_CSV)
        Dim iArchivo As StreamWriter = New StreamWriter(ARCHIVO_CSV)

        'REPRESENTA A UNA LINEA DEL ARCHIVO DE TEXTO
        Dim linea As String = String.Empty

        'RECORRIENDO CADA OBJETO VENTA PARA LUEGO TRANSFORMARLA EN
        'UNA LINEA DE TEXTO Y AGREGARLA AL ARCHIVO
        For Each xObj As SuperEntidad In iLisRcc
            'LIMPIAMOS LA LINEA PARA EMPEZAR DE NUEVO
            linea = String.Empty
            'PERIODO Campo1
            linea += xObj.PeriodoRegContabCabe + "00"
            linea += "|"
            'NUMERO DEL REGISTRO(LA CLAVE SERIA CLAVEREGCONTABCABE) Campo2
            linea += xObj.ClaveRegContabCabe
            linea += "|"
            'NUMERO VOUCHER Campo3
            linea += "M" + xObj.NumeroVoucherRegContabCabe
            linea += "|"
            'FECHA EMISION DEL COMPROBANTE 4
            linea += xObj.FechaDocumento.ToShortDateString
            linea += "|"
            'FECHA VENCIMIENTO DEL COMPROBANTE 5
            linea += xObj.FechaVencimiento.ToShortDateString
            linea += "|"
            'TIPO DOCUMENTO 6
            linea += xObj.TipoDocumento
            linea += "|"
            'SERIE DOCUMENTO 7
            linea += xObj.SerieDocumento
            linea += "|"
            'NUMERO DOCUMENTO 8 
            If xObj.TipoDocumento = "01" Or xObj.TipoDocumento = "03" Or xObj.TipoDocumento = "07" Or xObj.TipoDocumento = "08" Then
                linea += xObj.NumeroDocumento.Substring(8)
                linea += "|"
                'linea += xObj.NumeroDocumento.Substring(8)
                'linea += "|"
            Else
                linea += xObj.NumeroDocumento
                linea += "|"
                'linea += xObj.NumeroDocumento
                'linea += "|"
            End If
            ''NUMERO DOCUMENTO  9
            linea += " |"
            'If xObj.TipoDocumento = "00" Or xObj.TipoDocumento = "03" Or xObj.TipoDocumento = "12" Or xObj.TipoDocumento = "87" Then
            '    linea += xObj.NumeroDocumento.Substring(8)
            '    linea += "|"
            'Else
            '    linea += " |"
            'End If
            'TIPO DOCUMENTO AUXILIAR 10
            linea += xObj.TipoDocumentoAuxiliar
            linea += "|"
            'RUC O DNI AUXILIAR 11
            linea += xObj.CodigoAuxiliar
            linea += "|"
            'NOMBRE DE AUXILIAR 12
            linea += Varios.CortarCadena(xObj.DescripcionAuxiliar, 59)
            linea += "|"
            'POSICION 13
            linea += "0.00"
            linea += "|"
            'POSICION 14
            If xObj.CodigoFile = "507" Then
                linea += (xObj.ValorVtaSolRegContabCabe * -1).ToString
            Else
                linea += xObj.ValorVtaSolRegContabCabe.ToString
            End If
            'linea += xObj.ValorVtaSolRegContabCabe.ToString
            linea += "|"
            'POSICION 15
            'If xObj.CodigoFile = "507" Then
            '    linea += (xObj.ExoneradoSolRegContabCabe * -1).ToString
            'Else
            '    linea += xObj.ExoneradoSolRegContabCabe.ToString
            'End If
            'linea += xObj.ExoneradoSolRegContabCabe.ToString
            'Campo 15
            linea += "0.00"
            linea += "|"
            'POSICION 16 IGV
            If xObj.CodigoFile = "507" Then
                linea += (xObj.IgvSolRegContabCabe * -1).ToString
            Else
                linea += xObj.IgvSolRegContabCabe.ToString
            End If
            'linea += xObj.ExoneradoSolRegContabCabe.ToString
            linea += "|"
            'POSICION 17
            linea += "0.00"
            linea += "|"
            'EONERADO 18
            If xObj.CodigoFile = "507" Then
                linea += (xObj.ExoneradoSolRegContabCabe * -1).ToString
            Else
                linea += xObj.ExoneradoSolRegContabCabe.ToString
            End If
            'linea += xObj.IgvSolRegContabCabe.ToString
            linea += "|"
            'POSICION 19
            linea += "0.00"
            linea += "|"
            'POSICION 20
            linea += "0.00"
            linea += "|"
            'POSICION 21
            linea += "0.00"
            linea += "|"
            'POSICION 22
            linea += "0.00"
            linea += "|"
            'OTROS CONCEPTOS 23 bolsa plastico
            linea += "0.00"
            linea += "|"
            'OTROS CONCEPTOS 23
            linea += "0.00"
            linea += "|"
            'PRECIO VENTA 24
            If xObj.CodigoFile = "507" Then
                linea += (xObj.PrecioVtaSolRegContabCabe * -1).ToString
            Else
                linea += xObj.PrecioVtaSolRegContabCabe.ToString
            End If
            linea += "|"
            'linea += xObj.PrecioVtaSolRegContabCabe.ToString
            'Moneda 25
            If xObj.MonedaDocumento = "S/." Then
                linea += "PEN"
                linea += "|"
            Else
                linea += "USD"
                linea += "|"
            End If

            'TIPO CAMBIO 26
            linea += xObj.VentaTipoCambio.ToString
            linea += "|"
            ''EXONERADO
            'linea += xObj.ExoneradoSolRegContabCabe.ToString
            'linea += "|"
            'linea += "0.00|0.00|"
            ''PRECIO VENTA
            'linea += xObj.PrecioVtaSolRegContabCabe.ToString
            'linea += "|"
            'SEGUN NOTA
            If xObj.FechaDocumento1 = "" Then
                'FECHA 27
                linea += "01/01/0001"
                linea += "|"
                'TIPO DOCUMENTO 28
                linea += "00"
                linea += "|"
                'SERIE DOCUEMNTO 29
                linea += "-"
                linea += "|"
                'NUMERO DOCUMENTO 39
                linea += "-"
                linea += "|"
            Else
                'FECHA 27
                linea += xObj.FechaDocumento1
                linea += "|"
                'TIPO DOCUMENTO 28
                linea += xObj.TipoDocumento1
                linea += "|"
                'SERIE DOCUEMNTO 29
                linea += xObj.SerieDocumento1
                linea += "|"
                'NUMERO DOCUMENTO 30
                linea += xObj.NumeroDocumento1.Substring(8)
                linea += "|"
            End If
            'LINEA 31
            linea += " |"
            'LINEA 32
            If xObj.TipoDocumento = "14" Then
                linea += "0"
                linea += "|"
            Else
                linea += "1"
                linea += "|"
            End If
            'LINEA 33
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
            'LINEA 34
            If xObj.CodigoFile = "507" Then
                If xObj.PrecioVtaSolRegContabCabe.ToString = "0.00" Then
                    linea += "2"
                Else
                    linea += "1"
                End If
            Else
                If xObj.PrecioVtaSolRegContabCabe.ToString = "0.00" Then
                    linea += "2"
                Else
                    linea += "1"
                End If
                ' linea += "1"
            End If
            '  linea += "1"
            linea += "|"
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
            iNombre += SuperEntidad.xRucEmpresa
            iNombre += Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim + "00"
            iNombre += "140100001111"
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