Option Explicit On
Option Strict On
Imports Entidad
Imports Negocio
Imports System
Imports System.IO
Imports System.Threading


Public Class WExportarRegistrosAlmacen
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
        'TRAER TODOS LOS COMPROBANTESDETA PARA EXPORTAR AL ALMACEN
        Dim iRcdRN As New RegContabDetaRN
        Dim iRcdEN As New SuperEntidad
        iRcdEN.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        iRcdEN.CampoOrden = cam.ClaveRCC
        Dim iLisRcd As List(Of SuperEntidad) = iRcdRN.ListarRegistrosContablesDetalleParaExportarAmacen(iRcdEN)

        'ARMANDO LA RUTA DEL ARCHIVO DE TEXTO
        Dim ARCHIVO_CSV As String = Me.txtRuta.Text + "\" + Me.txtNomArchivo.Text + ".txt"

        'CREANDO EL ARCHIVO DE TEXTO EN LA RUTA INDICADA(ARCHIVO_CSV)
        Dim iArchivo As StreamWriter = New StreamWriter(ARCHIVO_CSV)

        'REPRESENTA A UNA LINEA DEL ARCHIVO DE TEXTO
        Dim linea As String = String.Empty

        'RECORRIENDO CADA OBJETO VENTA PARA LUEGO TRANSFORMARLA EN
        'UNA LINEA DE TEXTO Y AGREGARLA AL ARCHIVO
        For Each xObj As SuperEntidad In iLisRcd

            'LIMPIAMOS LA LINEA PARA EMPEZAR DE NUEVO
            linea = String.Empty

            'CODIGO ORIGEN
            linea += xObj.CodigoOrigen

            'CODIGO FILE
            '  linea += Me.ObtenerFileTxt(xObj) ojo ver esto luego
            linea += xObj.CodigoFile

            'NUMERO VOUCHER
            linea += xObj.NumeroVoucherRegContabCabe

            'FECHA VOUCHER
            linea += Varios.DiaMesAño(xObj.FechaVoucherRegContabCabe)

            'CODIGO AUXILIAR
            linea += Varios.CompletarCadena(xObj.CodigoAuxiliar, 11, " ", Varios.Direccion.Derecha)

            'TIPO DOCUMENTO
            linea += xObj.TipoDocumento

            'SERIE DOCUMENTO
            linea += xObj.SerieDocumento

            'NUMERO DOCUMENTO
            linea += Varios.CompletarCadena(xObj.NumeroDocumento, 15, "0", Varios.Direccion.Izquierda)

            'FECHA DOCUMENTO
            linea += Varios.DiaMesAño(xObj.FechaDocumento)

            'CODIGO REPARABLE
            ' linea += xObj.CodigoGastoReparable
            linea += Varios.CompletarCadena(xObj.CodigoGastoReparable, 8, " ", Varios.Direccion.Derecha)

            ''NOMBRE REPARABLE
            'linea += Varios.CompletarCadena(xObj.NombreGastoReparable, 40, " ", Varios.Direccion.Derecha)

            'UNIDAD REPARABLE
            ' linea += xObj.Unidad
            linea += Varios.CompletarCadena(xObj.Unidad, 3, " ", Varios.Direccion.Derecha)

            'CANTIDAD REPARABLE
            linea += Varios.NumeroFormatoTxt(xObj.Cantidad, "0", 10)

            'IMPORTE
            linea += Varios.NumeroFormatoTxt(xObj.ImporteSRegContabDeta, "0", 10)

            'DEBE/HABER
            linea += Varios.CortarCadena(xObj.DebeHaberRegContabDeta, 1)

            'NOMBRE REPARABLE
            linea += Varios.CompletarCadena(xObj.NombreGastoReparable, 40, " ", Varios.Direccion.Derecha)

            'AGREGAR LA LINEA AL .txt 
            iArchivo.WriteLine(linea)
        Next

        'DESTRUIR AL OBJETO ARCHIVO
        iArchivo.Dispose()
        iArchivo.Close()

        'PROCESO TERMINADO
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
            iNombre += "MALMACEN"
            ' iNombre += Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
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

    Function ObtenerFileTxt(ByVal pComDet As SuperEntidad) As String
        'VALOR RESULTADO
        Dim iValor As String = ""

        'SEGUN ORIGEN
        Select Case pComDet.CodigoOrigen
            Case "4"
                'IMPORTACIONES
                If pComDet.CodigoFile = "410" Then
                    iValor = "110"
                    Return iValor
                End If

                'NOTA CREDITO
                If pComDet.CodigoFile = "407" Then
                    iValor = "207"
                    Return iValor
                End If

                'COMPRAS NORMALES
                iValor = "101"
                Return iValor

            Case "3"

                'SEGUN DEBE O HABER
                If pComDet.DebeHaberRegContabDeta = "Debe" Then
                    iValor = "180"
                Else
                    iValor = "280"
                End If
                Return iValor

        End Select

        'devolver
        Return iValor
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