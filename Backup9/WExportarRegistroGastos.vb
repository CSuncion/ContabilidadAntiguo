'Option Explicit On
'Option Strict On
Imports Entidad
Imports Negocio
Imports System
Imports System.IO
Imports System.Threading


Public Class WExportarRegistroGastos

    Public cam As New CamposEntidad
    Public acc As New Accion

#Region "Metodos"

    Sub ValoresPorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.txtNomEmp.Text = SuperEntidad.xRazonSocial
    End Sub

    Sub NuevaVentana()
        acc.listaCtrls = Me.ListaControles
        acc.PasaFoco()
        acc.FomatoDato()
        acc.PasarCursor()
        acc.Teclazo()
        acc.Valida()
        Me.Show()
        Me.ValoresPorDefecto()
        Me.dtpDesde.Focus()
    End Sub

    Sub hilo2()
        Me.tslEstadoExp.Text = "Esperar..."
    End Sub

    Sub hilo1()
        'TRAER TODOS LOS DIARIOS DEL RANGO ELEGIDO Y SOLO DEL FILE 395
        Dim iRccRN As New RegContabCabeRN
        Dim iRccEN As New SuperEntidad
        iRccEN.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        iRccEN.DatoFiltro1 = Varios.AñoMesDia(Me.dtpDesde.Value.Date)
        iRccEN.DatoFiltro2 = Varios.AñoMesDia(Me.dtpHasta.Value.Date)
        iRccEN.CampoOrden = cam.ClaveRCC
        Dim iLisRcc As List(Of SuperEntidad) = iRccRN.ListarDiarios395ParaExportar(iRccEN)

        'objetos detalle
        Dim iRcdRN As New RegContabDetaRN
        Dim iRcdEN As New SuperEntidad


        'ARMANDO LA RUTA DEL ARCHIVO DE TEXTO
        Dim ARCHIVO_CSV As String = Me.txtRuta.Text + "\" + Me.txtNomArchivo.Text + ".txt"

        'CREANDO EL ARCHIVO DE TEXTO EN LA RUTA INDICADA(ARCHIVO_CSV)
        Dim iArchivo As StreamWriter = New StreamWriter(ARCHIVO_CSV)

        'REPRESENTA A UNA LINEA DEL ARCHIVO DE TEXTO
        Dim linea As String = String.Empty

        'RECORREMOS CADA OBJETO CABECERA 
        For Each xRegDia As SuperEntidad In iLisRcc
            'EL OBJETO CABECERA DEBE ESTAR CUADRADO Y DIFERENTE DE CERO
            If xRegDia.SumaDebeRegContabCabe <> 0 And (xRegDia.SumaDebeRegContabCabe = xRegDia.SumaHaberRegContabCabe) Then
                'LIMPIAMOS LA LINEA PARA EMPEZAR DE NUEVO
                linea = String.Empty

                'PASAMOS EL OBJETO CABECERA A TEXO
                linea += "C"
                'periodo
                linea += xRegDia.PeriodoRegContabCabe
                'origen
                linea += "3"
                'file
                linea += "395"
                'numero voucher
                'el numero de voucher del sistema de proyectos tiene 6 digitos y del sistema contable tiene
                '5 ,por eso se le agrega un cero adelante
                linea += "0" + xRegDia.NumeroVoucherRegContabCabe
                'clave cabecera
                linea += xRegDia.PeriodoRegContabCabe + "3395" + "0" + xRegDia.NumeroVoucherRegContabCabe
                'dia voucher
                linea += xRegDia.DiaVoucherRegContabCabe
                'fecha voucher
                linea += xRegDia.FechaVoucherRegContabCabe.ToShortDateString
                'glosa
                linea += Varios.CompletarCadena(xRegDia.GlosaRegContabCabe, 45, " ", Varios.Direccion.Derecha)
                'valor igv
                linea += Varios.CompletarCadena(xRegDia.IgvPar.ToString, 6, " ", Varios.Direccion.Derecha)

                'INSERTAMOS LA LINEA CABECERA AL ARCHIVO
                iArchivo.WriteLine(linea)

                'PASAMOS EL DETALLE DE ESTA CABECERA A TEXTO
                iRcdEN.ClaveRegContabCabe = xRegDia.ClaveRegContabCabe
                Dim iLisRcd As List(Of SuperEntidad) = iRcdRN.obtenerDetalleRegContabPorClave(iRcdEN)

                'PRIMERO DEBEMOS SABER SI EL IMPORTE DE CADA DETALLE ES POSITIVO O NEGATIVO
                'PORQUE EN CONTABILIDAD NO SE PERMITE NEGATIVO PERO EN PROYECTOS SI
                Dim iSigno As Integer = 1

                'TOMAMOS AL PRIMER OBJETO DEL DETALLE Y ANALIZARLO
                Dim iDet As SuperEntidad = iLisRcd.Item(0)
                If iDet.CodigoPptoInterno = "" Then
                    If iDet.DebeHaberRegContabDeta = "Debe" Then
                        iSigno = -1
                    End If
                Else
                    If iDet.DebeHaberRegContabDeta = "Haber" Then
                        iSigno = -1
                    End If
                End If

                'AHORA CADA DETALLE A TEXTO
                For Each xDet As SuperEntidad In iLisRcd
                    'INICIAMOS CON LA LINEA EN BLANCO
                    linea = String.Empty

                    'TRANSFORMANDO A TEXTO
                    linea += "D"
                    'clave cabecera
                    linea += Varios.CompletarCadena(xRegDia.ClaveRegContabCabe.Substring(3), 16, " ", Varios.Direccion.Derecha)
                    'fecha voucher
                    linea += Varios.CompletarCadena(xRegDia.FechaVoucherRegContabCabe.ToShortDateString, 10, " ", Varios.Direccion.Derecha)
                    'cuenta
                    linea += Varios.CompletarCadena(xDet.CodigoCuentaPcge, 8, " ", Varios.Direccion.Derecha)
                    'ppto interno
                    linea += Varios.CompletarCadena(xDet.CodigoPptoInterno, 20, " ", Varios.Direccion.Derecha)
                    'titulo
                    linea += Varios.CompletarCadena(xDet.Titulo, 4, " ", Varios.Direccion.Derecha)
                    'concepto
                    linea += Varios.CompletarCadena(xDet.CodigoConcepto, 5, " ", Varios.Direccion.Derecha)
                    'codigo interno
                    linea += Varios.CompletarCadena(xDet.CodigoInterno, 6, " ", Varios.Direccion.Derecha)
                    'debe o haber
                    linea += Varios.CompletarCadena(xDet.DebeHaberRegContabDeta, 5, " ", Varios.Direccion.Derecha)
                    'importe soles
                    linea += Varios.CompletarCadena((xDet.ImporteSRegContabDeta * iSigno).ToString, 12, " ", Varios.Direccion.Derecha)
                    'importe dolares
                    linea += Varios.CompletarCadena((xDet.ImporteDRegContabDeta * iSigno).ToString, 12, " ", Varios.Direccion.Derecha)
                    'auxiliar
                    linea += Varios.CompletarCadena(xDet.CodigoAuxiliar, 11, " ", Varios.Direccion.Derecha)
                    'tipo documento
                    linea += Varios.CompletarCadena(xDet.TipoDocumento, 2, " ", Varios.Direccion.Derecha)
                    'serie documento
                    linea += Varios.CompletarCadena(xDet.SerieDocumento, 4, " ", Varios.Direccion.Derecha)
                    'numero documento
                    linea += Varios.CompletarCadena(xDet.NumeroDocumento, 15, " ", Varios.Direccion.Derecha)
                    'fecha documento
                    linea += Varios.CompletarCadena(xDet.FechaDocumento.ToShortDateString, 10, " ", Varios.Direccion.Derecha)
                    'tipo de cambio
                    linea += Varios.CompletarCadena(xDet.VentaTipoCambio.ToString, 6, " ", Varios.Direccion.Derecha)
                    'glosa
                    linea += Varios.CompletarCadena(xDet.GlosaRegContabDeta, 40, " ", Varios.Direccion.Derecha)
                    'ingreso/egreso
                    linea += Varios.CompletarCadena(xDet.CodigoIngEgr, 3, " ", Varios.Direccion.Derecha)

                    'INSERTAMOS LA LINEA DETALLE AL ARCHIVO
                    iArchivo.WriteLine(linea)
                Next

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

    Function ValidarExportacion() As Boolean
        'PRIMERO QUE TENGA NOMBRE EL ARCHIVO
        If Me.txtNomArchivo.Text.Trim = "" Then
            MsgBox("Debes eligir un nombre al archivo")
            Me.txtNomArchivo.Focus()
            Return False
        End If

        'VALIDAR LA CARPETA DONDE SE GUARDAR EL ARCHIVO
        If Me.txtRuta.Text.Trim = "" Then
            MsgBox("Debes seleccionar la carpeta para tu archivo")
            Me.btnAceptar.Focus()
            Return False
        End If
        Return True
    End Function



#End Region

   

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        'VALOS CAMPOS OBLIGATORIOS
        If acc.CamposObligatorios = False Then Exit Sub

        'VALIDAR ANTES DE EJECUTAR
        If Me.ValidarExportacion = False Then Exit Sub

        Dim mih1, mih2 As Thread
        mih1 = New Thread(AddressOf hilo1)
        mih2 = New Thread(AddressOf hilo2)
        mih1.Start()
        mih2.Start()

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    
    Private Sub btnBuscarRuta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarRuta.Click
        Me.SeleccionUbicacion()
    End Sub
End Class