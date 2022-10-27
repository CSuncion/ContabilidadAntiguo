Option Explicit On
Option Strict On
Imports Entidad
Imports Negocio
Imports System
Imports System.IO
Imports System.Threading


Public Class WExportarRegistroDiario
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
        Dim iLisRcc As List(Of SuperEntidad) = iRccRN.obtenerMovimientoDetalleXPeriodo(iRccEN)

        'ARMANDO LA RUTA DEL ARCHIVO DE TEXTO
        Dim ARCHIVO_CSV As String = Me.txtRuta.Text + "\" + Me.txtNomArchivo.Text + ".txt"

        'CREANDO EL ARCHOVO DE TEXTO EN LA RUTA INDICADA(ARCHIVO_CSV)
        Dim iArchivo As StreamWriter = New StreamWriter(ARCHIVO_CSV)

        'REPRESENTA A UNA LINEA DEL ARCHIVO DE TEXTO
        Dim linea As String = String.Empty
        Dim iCorrelativo As Integer = 0

        'RECORRIENDO CADA OBJETO COMPRA PARA LUEGO TRANSFORMARLA EN
        'UNA LINEA DE TEXTO Y AGREGARLA AL ARCHIVO
        For Each xObj As SuperEntidad In iLisRcc
            'sI ES ANULADO NO ENTRA
            If xObj.ImporteSRegContabDeta <> 0 Then

                'LIMPIAMOS LA LINEA PARA EMPEZAR DE NUEVO
                linea = String.Empty
                'PERIODO
                linea += xObj.PeriodoRegContabCabe + "00"
                linea += "|"
                'NUMERO DEL REGISTRO(LA CLAVE SERIA FILE + NUMERO)
                iCorrelativo += 1
                'YA QUE EL CAMPO NUMERO SE REPITE PARA FILES DISTINTOS
                'linea += xObj.ClaveRegContabDeta
                linea += xObj.ClaveRegContabCabe + iCorrelativo.ToString.PadLeft(5, CType("0", Char))
                linea += "|"
                'CODIGO PLAN DE CUENTAS EMPRESARIAL
                linea += "01|"
                'CODIGO DE CUENTA Y PLAN DE CUENTAS
                linea += xObj.CodigoCuentaPcge.Trim
                linea += "|"
                'FECHA FECHA VOUCHER 
                linea += xObj.FechaVoucherRegContabCabe.ToShortDateString
                linea += "|"
                'GLOSAS 
                If xObj.GlosaRegContabDeta = String.Empty Then
                    linea += "VARIOS"
                Else
                    linea += xObj.GlosaRegContabDeta
                End If

                linea += "|"
                'PARA IMPORTE DEBE Y HANER
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
                'TIPO MOPERACION
                linea += "1"
                linea += "|"
                'CENTRO COSTO
                linea += xObj.CodigoCentroCosto
                linea += "|"
                linea += "1"
                linea += "|"
                linea += " "
                linea += "|"
                linea += " "
                linea += "|"
                linea += " "
                linea += "|"

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