Option Explicit On
Option Strict On
Imports Entidad
Imports Negocio
Imports System
Imports System.IO
Imports System.Threading


Public Class WExportarDaoCompras
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
        Me.txtMonto.Focus()
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
        Dim iRccRN As New RegContabCabeRN
        Dim iRccEN As New SuperEntidad
        iRccEN.CodigoOrigen = "4" 'COMPRAS
        iRccEN.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        iRccEN.DatoFiltro1 = Me.txtAno.Text.Trim + "01"
        iRccEN.DatoFiltro2 = Me.txtAno.Text.Trim + "12"
        iRccEN.FechaDocumento = CType("01/01/" + Me.txtAno.Text.Trim, Date)
        iRccEN.CampoOrden = cam.CodAux
        Dim iLisRcc As List(Of SuperEntidad) = iRccRN.ListarParaDao(iRccEN)

        'ARMANDO LA RUTA DEL ARCHIVO DE TEXTO
        Dim ARCHIVO_CSV As String = Me.txtRuta.Text + "\" + Me.txtNomArchivo.Text + ".txt"

        'CREANDO EL ARCHOVO DE TEXTO EN LA RUTA INDICADA(ARCHIVO_CSV)
        Dim iArchivo As StreamWriter = New StreamWriter(ARCHIVO_CSV)

        'REPRESENTA A UNA LINEA DEL ARCHIVO DE TEXTO
        Dim linea As String = String.Empty

        'RECORRIENDO CADA OBJETO COMPRA PARA LUEGO TRANSFORMARLA EN
        Dim iMontoMayor As Decimal = CType(Me.txtMonto.Text.Trim, Decimal)
        Dim iCorrelativo As Integer = 0

        'UNA LINEA DE TEXTO Y AGREGARLA AL ARCHIVO
        For Each xObj As SuperEntidad In iLisRcc
            'SOLO PASAN LOS DEL MONTO MAYOR O IGUAL DEL FROMULARIO
            If xObj.ValorVtaRegContabCabe >= iMontoMayor Then
                If xObj.CodigoAuxiliar.Length = 8 Or xObj.CodigoAuxiliar.Length = 11 Then
                    If xObj.CodigoAuxiliar.Trim = "51428110" Then
                    Else
                        'LIMPIAMOS LA LINEA PARA EMPEZAR DE NUEVO
                        linea = String.Empty
                        'PERIODO
                        iCorrelativo += 1
                        linea += iCorrelativo.ToString
                        linea += "|"
                        linea += "6"
                        linea += "|"
                        linea += SuperEntidad.xRucEmpresa
                        linea += "|"
                        linea += Me.txtAno.Text.Trim
                        linea += "|"
                        If xObj.ApellidoMaternoAuxiliar = "" Then
                            linea += "02"
                        Else
                            linea += "01"
                        End If
                        linea += "|"
                        linea += xObj.TipoDocumentoAuxiliar
                        linea += "|"
                        linea += xObj.CodigoAuxiliar
                        linea += "|"
                        linea += Math.Round(xObj.ValorVtaRegContabCabe, 0).ToString
                        linea += "|"
                        If xObj.ApellidoMaternoAuxiliar = "" Then
                            linea += "|"
                            linea += "|"
                            linea += "|"
                            linea += "|"
                            linea += xObj.DescripcionAuxiliar
                        Else
                            linea += xObj.ApellidoPaternoAuxiliar
                            linea += "|"
                            linea += xObj.ApellidoMaternoAuxiliar
                            linea += "|"
                            linea += xObj.PrimerNombreAuxiliar
                            linea += "|"
                            linea += xObj.SegundoNombreAuxiliar
                            linea += "|"

                        End If
                        linea += "|"
                        iArchivo.WriteLine(linea)
                    End If
                    
                End If
                
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
        If Me.txtMonto.Text.Trim <> "" Then
            'iNombre += "LE"
            'iNombre += SuperEntidad.xRucEmpresa
            'iNombre += Me.txtAno.Text.Trim + Me.txtMonto.Text.Trim + "00"
            'iNombre += "080100001111"
            iNombre = "Costos"
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


    'Private Sub txtCodMes_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtMonto.Validating
    '    Dim ope As New OperaWin : ope.txt1 = Me.txtMonto : ope.txt2 = Me.txtDesMes
    '    ope.MostrarCodigoDescripcionDeTabla("Mes", "Meses", e)
    'End Sub

    'Private Sub txtCodMes_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMonto.KeyDown
    '    If Me.txtMonto.ReadOnly = False Then
    '        If e.KeyCode = Keys.F1 Then
    '            Dim win As New WListarTabla
    '            win.tabla = "Mes"
    '            win.titulo = "Meses"
    '            win.txt1 = Me.txtMonto
    '            win.txt2 = Me.txtDesMes
    '            win.NuevaVentana()
    '        End If
    '    End If
    'End Sub

    Private Sub btnBuscarRuta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarRuta.Click
        Me.SeleccionUbicacion()
    End Sub

    Private Sub txtCodMes_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMonto.Validated
        Me.ArmarNombreArchivo()
    End Sub
End Class