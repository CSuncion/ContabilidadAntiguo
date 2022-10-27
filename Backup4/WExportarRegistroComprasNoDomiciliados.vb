Option Explicit On
Option Strict On
Imports Entidad
Imports Negocio
Imports System
Imports System.IO
Imports System.Threading
'Imports LibreriaGeneral

Public Class WExportarRegistroComprasNoDomiciliados
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

        'LISTAR REGISTRO COMPRAS
        Dim iLisRcc As List(Of SuperEntidad) = Me.ListarRegistroCompras

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
            'TIPO DOCUMENTO 5
            linea += xObj.TipoDocumento
            linea += "|"
            'SERIE DOCUMENTO 6            
            linea += xObj.SerieDocumento
            linea += "|"
            'NUMERO DOCUMENTO 7
            If xObj.TipoDocumento = "01" Or xObj.TipoDocumento = "03" Or xObj.TipoDocumento = "07" Or xObj.TipoDocumento = "08" Then
                linea += xObj.NumeroDocumento.Substring(8)
                linea += "|"
            Else
                linea += xObj.NumeroDocumento
                linea += "|"
            End If
            'POSICION 8
            linea += xObj.ValorVtaSolRegContabCabe.ToString
            linea += "|"
            'POSICION 9
            linea += "0.00|"
            'POSICION 10
            linea += xObj.PrecioVtaSolRegContabCabe.ToString
            linea += "|"
            'TIPO DOCUMENTO 11
            linea += xObj.TipoDocumento1
            linea += "|"
            'SERIE DOCUEMNTO 12
            linea += xObj.SerieDocumento1
            linea += "|"
            'AÑO EMISION DUA 13
            If xObj.TipoDocumento = "50" Or xObj.TipoDocumento = "52" Then
                linea += xObj.FechaDocumento.Year.ToString
                linea += "|"
            Else
                linea += "0"
                linea += "|"
            End If
            'NUMERO DOCUMENTO 14
            linea += xObj.NumeroDocumento1
            linea += "|"
            'NUMERO DOCUMENTO 15
            linea += xObj.IgvSolRegContabCabe.ToString
            linea += "|"
            'moneda 16
            If xObj.MonedaDocumento = "S/." Then
                linea += "PEN"
                linea += "|"
            Else
                linea += "USD"
                linea += "|"
            End If
            'TIPO CAMBIO 17
            linea += xObj.VentaTipoCambio.ToString
            linea += "|"
            'Pais 18
            linea += xObj.PaisNoDomiciliadoAuxiliar.Trim  '"9845"  'Uruguay
            linea += "|"
            'NOMBRE DE AUXILIAR 19
            linea += Varios.CortarCadena(xObj.DescripcionAuxiliar, 59)
            linea += "|"
            'Domicilio no domiciliado 20
            linea += " |"
            'RUC O DNI AUXILIAR no domiciliado 21
            linea += xObj.CodigoAuxiliar
            linea += "|"
            'Pgos 22
            linea += " |"
            'Beneficiario no domiciliado 23
            linea += " |"
            'pais 24
            linea += " |"
            'Vinculo no domiciliado 25
            linea += " |"
            'renta  26
            linea += "0.00|"
            'deduciones  27
            linea += "0.00|"
            'renta neta  28
            linea += "0.00|"
            'tasa retencion  29
            linea += "0.00|"
            'impuesto reteido  30
            linea += "0.00|"
            'convenio  31
            linea += "00|" 'Ninguna
            'Exoneraciones Aplicada  32
            linea += " |"
            'Tipo Renta  33   OJO
            linea += "00|"
            'Modalidad del servicio  34  
            linea += " |"
            'Aplicacion Art 76°  35
            linea += "1|"
            'LINEA 36
            If xObj.PeriodoRegContabCabe + "00" < Varios.AñoMesDiaSinBarra(xObj.FechaDocumento) Then
                linea += "0"
                linea += "|"
            Else
                linea += "9"
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
            If Me.ListarRegistroCompras.Count = 0 Then
                iNombre += "LE"
                iNombre += Me.TxtRuc.Text.Trim
                iNombre += Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim + "00"
                iNombre += "080200001011"
            Else
                iNombre += "LE"
                iNombre += Me.TxtRuc.Text.Trim
                iNombre += Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim + "00"
                iNombre += "080200001111"
            End If
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

    Function ListarRegistroCompras() As List(Of SuperEntidad)
        Dim iRccRN As New RegContabCabeRN
        Dim iRccEN As New SuperEntidad

        iRccEN.CodigoOrigen = "4" 'COMPRAS
        iRccEN.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        iRccEN.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        iRccEN.CodigoIngEgr = "1" 'COMPRAS NO DOLICILIADOS
        iRccEN.CampoOrden = cam.ClaveRCC
        Return iRccRN.ListarComprasNoDomiciliariasPle(iRccEN)
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