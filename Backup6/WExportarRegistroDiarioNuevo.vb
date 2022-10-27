Option Explicit On
Option Strict On
Imports Entidad
Imports Negocio
Imports System
Imports System.IO
Imports System.Threading


Public Class WExportarRegistroDiarioNuevo
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
        'TRAER TODAS LAS COMPRAS DEL PERIODO ELEGIDO
        Dim iRccRN As New MovimientoContableDetalleRN
        Dim iRccEN As New SuperEntidad
        'iRccEN.CodigoOrigen = "4" 'COMPRAS
        iRccEN.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        iRccEN.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        iRccEN.CampoOrden = cam.ClaveRCD
        Dim iLisRcc As New List(Of SuperEntidad)
        Select Case Me.txtCodMes.Text
            Case "01"
                iRccEN.PeriodoRegContabCabe = Me.txtAno.Text.Trim
                iLisRcc = iRccRN.ListarMovimientoParaLibroDiarioEnero(iRccEN)
            Case "12"
                iRccEN.PeriodoRegContabCabe = Me.txtAno.Text.Trim
                iLisRcc = iRccRN.ListarMovimientoParaLibroDiarioDiciembre(iRccEN)
            Case Else : iLisRcc = iRccRN.obtenerMovimientoDetalleXPeriodo(iRccEN)

        End Select


        'ARMANDO LA RUTA DEL ARCHIVO DE TEXTO
        Dim ARCHIVO_CSV As String = Me.txtRuta.Text + "\" + Me.txtNomArchivo.Text + ".txt"

        'CREANDO EL ARCHOVO DE TEXTO EN LA RUTA INDICADA(ARCHIVO_CSV)
        Dim iArchivo As StreamWriter = New StreamWriter(ARCHIVO_CSV)

        'REPRESENTA A UNA LINEA DEL ARCHIVO DE TEXTO
        Dim linea As String = String.Empty
        Dim iCorrelativo As Integer = 0
        Dim iClaveCabe As String = ""

        'RECORRIENDO CADA OBJETO COMPRA PARA LUEGO TRANSFORMARLA EN
        'UNA LINEA DE TEXTO Y AGREGARLA AL ARCHIVO
        For Each xObj As SuperEntidad In iLisRcc
            'sI ES ANULADO NO ENTRA
            If xObj.ImporteSRegContabDeta <> 0 Then

                'LIMPIAMOS LA LINEA PARA EMPEZAR DE NUEVO
                linea = String.Empty
                'PERIODO
                Select Case xObj.PeriodoRegContabCabe.Substring(4)
                    Case "00" : linea += xObj.PeriodoRegContabCabe.Substring(0, 4) + "0100"
                    Case "13" : linea += xObj.PeriodoRegContabCabe.Substring(0, 4) + "1200"
                    Case Else : linea += xObj.PeriodoRegContabCabe + "00"
                End Select

                'linea += xObj.PeriodoRegContabCabe + "00"
                linea += "|"
                'YA QUE EL CAMPO NUMERO SE REPITE PARA FILES DISTINTOS
                If xObj.ClaveRegContabCabe <> iClaveCabe Then
                    iCorrelativo = 0
                    iClaveCabe = xObj.ClaveRegContabCabe
                End If
                'Campo 3
                iCorrelativo += 1
                linea += xObj.ClaveRegContabCabe + iCorrelativo.ToString.PadLeft(5, CType("0", Char))
                linea += "|"
                'NUMERO VOUCHER
                Select Case xObj.PeriodoRegContabCabe.Substring(4)
                    Case "00" : linea += "A" + iCorrelativo.ToString.PadLeft(5, CType("0", Char))
                    Case "13" : linea += "C" + iCorrelativo.ToString.PadLeft(5, CType("0", Char))
                    Case Else : linea += "M" + iCorrelativo.ToString.PadLeft(5, CType("0", Char))
                End Select
                linea += "|"
                'CODIGO PLAN DE CUENTAS EMPRESARIAL
                '  linea += "01|"
                'Campo 4
                'CODIGO DE CUENTA Y PLAN DE CUENTAS
                linea += xObj.CodigoCuentaPcge.Trim
                linea += "|"
                'Campo 5 Unidad
                linea += " |"
                'Campo 6 Centro Costo
                linea += xObj.CodigoCentroCosto.Trim
                linea += "|"
                'Campo 7 Moneda
                If xObj.Exporta = "S/." Then
                    linea += "PEN"
                Else
                    linea += "USD"
                End If
                'If xObj.MonedaDocumento = "S/." Then
                '    linea += "PEN"
                'Else
                '    linea += "USD"
                'End If
                linea += "|"
                'Campo 8 
                linea += " |"
                'Campo 9 
                linea += " |"
                'Campo 10
                If xObj.TipoDocumento = String.Empty Then
                    linea += "00"
                Else
                    If xObj.TipoDocumento = "38" Or xObj.TipoDocumento = "39" Or xObj.TipoDocumento = "32" Or xObj.TipoDocumento = "36" Or xObj.TipoDocumento = "34" Or xObj.TipoDocumento = "35" Or xObj.TipoDocumento = "21" Or xObj.TipoDocumento = "22" Or xObj.TipoDocumento = "23" Or xObj.TipoDocumento = "25" Or xObj.TipoDocumento = "33" Or xObj.TipoDocumento = "40" Or xObj.TipoDocumento = "50" Or xObj.TipoDocumento = "52" Then
                        linea += "00"
                    Else
                        linea += xObj.TipoDocumento
                    End If
                End If
                linea += "|"
                'Campo 11
                If xObj.SerieDocumento = String.Empty Then
                    If xObj.TipoDocumento = "05" Then
                        linea += "1"
                    Else
                        linea += "0820"
                    End If
                Else
                    If xObj.SerieDocumento.Length = 3 Then
                        If xObj.TipoDocumento = "05" Then
                            linea += "1"
                        Else
                            linea += "0" + xObj.SerieDocumento.ToString
                        End If
                    Else
                        If xObj.TipoDocumento = "05" Then
                            'linea += xObj.SerieDocumento.Substring(2, 1)
                            linea += "1"
                        Else
                            If xObj.TipoDocumento = "22" Then
                                linea += "0820"
                            Else
                                If xObj.TipoDocumento = "50" Then ''And xObj.SerieDocumento = "0000"
                                    linea += "244"
                                Else
                                    If xObj.TipoDocumento = "10" Then
                                        linea += "1683"
                                    Else
                                        linea += xObj.SerieDocumento
                                    End If

                                End If

                            End If
                        End If
                    End If
                End If
                linea += "|"
                'Campo 12
                If xObj.TipoDocumento = "01" Or xObj.TipoDocumento = "03" Or xObj.TipoDocumento = "07" Or xObj.TipoDocumento = "08" Or xObj.TipoDocumento = "02" Or xObj.TipoDocumento = "33" Or xObj.TipoDocumento = "34" Or xObj.TipoDocumento = "41" Or xObj.TipoDocumento = "05" Or xObj.TipoDocumento = "04" Or xObj.TipoDocumento = "23" Or xObj.TipoDocumento = "06" Or xObj.TipoDocumento = "36" Or xObj.TipoDocumento = "32" Or xObj.TipoDocumento = "40" Or xObj.TipoDocumento = "25" Then
                    If xObj.NumeroDocumento.Length = 15 Then
                        If xObj.TipoDocumento = "05" Then
                            linea += xObj.NumeroDocumento.Substring(5)
                        Else
                            If xObj.TipoDocumento = "23" And xObj.NumeroDocumento = "000000000000000" Then
                                linea += "0000001"
                            Else
                                linea += xObj.NumeroDocumento.Substring(8)
                            End If
                        End If
                    Else
                        If (xObj.TipoDocumento = "25" Or xObj.TipoDocumento = "32" Or xObj.TipoDocumento = "40" Or xObj.TipoDocumento = "41") And xObj.NumeroDocumento = String.Empty Then
                            linea += "0000001"
                        Else
                            linea += xObj.NumeroDocumento
                            'If xObj.TipoDocumento = "01" Then
                            '    linea += xObj.NumeroDocumento.Substring(0, 2)
                            'Else
                            '    linea += xObj.NumeroDocumento
                            'End If
                        End If
                    End If
                Else
                    '' If xObj.NumeroDocumento = String.Empty Then
                    '' linea += "000001"
                    '' Else
                    If xObj.TipoDocumento = "50" And (xObj.SerieDocumento = "0000" Or xObj.SerieDocumento = "0013") Then
                        linea += "00001"
                    Else
                        If xObj.TipoDocumento = "30" Then
                            '' MsgBox(xObj.TipoDocumento + "---" + xObj.NumeroDocumento)
                            linea += "000001"
                        Else
                            If xObj.TipoDocumento = "46" Then
                                If xObj.NumeroDocumento.Substring(0, 2) = "DE" Then
                                    linea += xObj.NumeroDocumento.Substring(3)
                                Else
                                    linea += xObj.NumeroDocumento
                                End If
                            Else
                                If xObj.NumeroDocumento = String.Empty Then
                                    linea += "000001"
                                Else
                                    linea += xObj.NumeroDocumento
                                End If
                            End If
                        End If
                    End If
                End If
                linea += "|"
                'linea += xObj.NumeroDocumento
                'Campo 13 FECHA FECHA VOUCHER 
                linea += xObj.FechaVoucherRegContabCabe.ToShortDateString
                linea += "|"
                'Campo 14 FECHA DOCUMENTO 
                linea += xObj.FechaDocumento.ToShortDateString
                linea += "|"
                'Campo 15 FECHA DE OTRO DOCUMENTO 
                'If xObj.FechaDocumento.ToShortDateString = "29/03/2016" Then
                '    linea += "02/01/2016"
                'Else
                '    If xObj.TipoDocumento = String.Empty Or xObj.TipoDocumento = "41" Then
                '        linea += xObj.FechaVoucherRegContabCabe.ToShortDateString
                '    Else
                '        linea += xObj.FechaDocumento.ToShortDateString
                '    End If
                'End If
                linea += xObj.FechaVoucherRegContabCabe.ToShortDateString
                linea += "|"
                'Camo 16 GLOSAS 
                If xObj.GlosaRegContabDeta = String.Empty Then
                    linea += "VARIOS"
                Else
                    linea += xObj.GlosaRegContabDeta
                End If
                linea += "|"
                'Campo 17 
                linea += " |"
                'Campo 18 PARA IMPORTE DEBE Y HANER
                If xObj.DebeHaberRegContabDeta = "Debe" Then   'Debe
                    'FECHA DOCUMENTO NOTA SI NO HAY PONER(01/01/0001)
                    linea += xObj.ImporteSRegContabDeta.ToString
                    linea += "|"
                    linea += "0.00"
                    linea += "|"
                Else
                    linea += "0.00"
                    linea += "|"
                    linea += xObj.ImporteSRegContabDeta.ToString
                    linea += "|"
                End If
                'CAMPO 20
                linea += " |"
                'CAMPO 21
                linea += "1|"
                iArchivo.WriteLine(linea)
            End If
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
            iNombre += "050100001111"
        End If
        Me.txtNomArchivo.Text = iNombre
    End Sub

    Function ValidarExportacion() As Boolean
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