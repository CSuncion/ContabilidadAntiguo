Option Explicit On
Option Strict On
Imports Entidad
Imports Negocio
Imports System
Imports System.IO
Imports System.Threading


Public Class WExportarRegistroHonorarios

    Public lista, listaD As New List(Of SuperEntidad)
    Public rc As New RegContabCabeRN
    Public rcd As New RegContabDetaRN
    Public cam As New CamposEntidad
    Public ent, entD As New SuperEntidad
    Dim numReg As Integer = 0

#Region "Metodos"

    Sub NuevaVentana()
        Me.TxtNomArchivo.Text = "0601" + SuperEntidad.xPeriodoEmpresa + SuperEntidad.xRucEmpresa + ".4ta"
        Me.ValoresPorDefecto()
        '//
        Me.Show()
        '\\
    End Sub

    Sub ValoresPorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.txtNomEmp.Text = SuperEntidad.xRazonSocial
    End Sub

    Sub CabeRegCompras()
        '//
        '/Refrescando el DataSource de DgvUsu
        ent.CodigoOrigen = "6"
        ent.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        ent.DatoFiltro1 = Varios.AñoMesDia(Me.dtpDesde.Value.Date)
        ent.DatoFiltro2 = Varios.AñoMesDia(Me.dtpHasta.Value.Date)
        ent.CampoOrden = cam.ClaveRCC 'cam.CodFilRC + "," + cam.DiaVouRC

        lista = rc.ListarRegContabEntreFechasYEmpresa(ent)
       
        Dim iArchivo As New StreamWriter(Me.ObtenerRuta)
        Dim iLinea As String = String.Empty

        For Each xObj As SuperEntidad In lista

            iLinea = String.Empty
            iLinea += "06"
            iLinea += "|"
            '  iLinea += Varios.CompletarCadena(xObj.CodigoAuxiliar, 15, " ", Varios.Direccion.Derecha)
            iLinea += xObj.CodigoAuxiliar
            iLinea += "|"
            iLinea += "R"
            iLinea += "|"
            If xObj.SerieDocumento.Length = 4 Then
                If xObj.SerieDocumento.Substring(0, 1) = "E" Then
                    iLinea += xObj.SerieDocumento.Substring(0, 1) + xObj.SerieDocumento.Substring(1, 3)
                Else
                    iLinea += xObj.SerieDocumento.Substring(1, 3)
                End If
            Else
                If xObj.SerieDocumento.Length = 3 Then
                    iLinea += xObj.SerieDocumento
                Else
                    If xObj.SerieDocumento.Length = 2 Then
                        iLinea += "0" + xObj.SerieDocumento.Substring(0, 2)
                    Else
                        iLinea += "00" + xObj.SerieDocumento.Substring(0, 1)
                    End If
                End If

            End If
            'iLinea += xObj.SerieDocumento.Substring(1, 3)
            iLinea += "|"
            iLinea += xObj.NumeroDocumento.Substring(7, 8)
            iLinea += "|"
            iLinea += Varios.CompletarCadena(xObj.PrecioVtaSolRegContabCabe.ToString, 7, "0", Varios.Direccion.Izquierda)
            iLinea += "|"
            iLinea += xObj.FechaDocumento.ToShortDateString
            iLinea += "|"
            iLinea += xObj.FechaVencimiento.ToShortDateString
            iLinea += "|"

            If xObj.ValorVtaSolRegContabCabe = 0 Then
                iLinea += "0"
            Else
                iLinea += "1"
            End If

            iLinea += "|"
            iLinea += "" 'Ojo 21-05-2018
            iLinea += "|"
            iLinea += "|"

            iArchivo.WriteLine(iLinea)

        Next

        iArchivo.Close()
        Me.tslEstadoExp.Text = "Terminado"

        '//
    End Sub

#End Region

    Sub hilo2()
        Me.tslEstadoExp.Text = "Esperar..."
    End Sub

    Sub Hilo1()
        Me.CabeRegCompras()
    End Sub

    Sub SeleccionarUbicacion(ByRef pTexBox As TextBox)
        Dim iBuscarRuta As New FolderBrowserDialog
        If iBuscarRuta.ShowDialog = Windows.Forms.DialogResult.OK Then
            pTexBox.Text = iBuscarRuta.SelectedPath
        End If
    End Sub

    Function ObtenerRuta() As String
        Dim iNuevaRuta As String = Me.TxtRuta.Text.Trim
        iNuevaRuta = iNuevaRuta + "\" + Me.TxtNomArchivo.Text.Trim
        Return iNuevaRuta
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim mih1, mih2 As Thread
        mih1 = New Thread(AddressOf Hilo1)
        mih2 = New Thread(AddressOf hilo2)

        'Si tiene escrito la ruta
        If Me.EsRutaValida = False Then Return
        'Si tiene escrito el nombre 
        If Me.EsNombreArchivoValido = False Then Return


        mih1.Start()
        mih2.Start()

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub


    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Me.SeleccionarUbicacion(Me.TxtRuta)
    End Sub

    Function EsRutaValida() As Boolean

        Dim xRut As String = Me.TxtRuta.Text.Trim

        If xRut = String.Empty Then
            MsgBox("Registre La Ruta", MsgBoxStyle.Exclamation, "Honorarios")
            Return False
        Else
            Return True
        End If

    End Function

    Function EsNombreArchivoValido() As Boolean

        Dim xNomArc As String = Me.TxtNomArchivo.Text.Trim

        If xNomArc = String.Empty Then
            MsgBox("Registre El Nombre del Archivo", MsgBoxStyle.Exclamation, "Honorarios")
            Return False
        Else
            Return True
        End If

    End Function



    Private Sub WExportarRegistroHonorarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class