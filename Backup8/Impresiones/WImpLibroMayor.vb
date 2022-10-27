Imports Entidad
Imports Negocio

Public Class WImpLibroMayor
    Public paren As New SuperEntidad
    Public par As New ParametroRN
    Dim cam As New CamposEntidad
    Dim ds As New DataSet1
    Dim acc As New Accion
    Dim ano, mes, empresa, periodo, ruc As CrystalDecisions.CrystalReports.Engine.TextObject


    Sub InicializaVentana()
        '/Para los eventos de controles
        acc.listaCtrls = Me.ListaControles
        acc.PasaFoco()
        acc.FomatoDato()
        acc.PasarCursor()
        acc.Teclazo()
        acc.Valida()
        Me.Show()
        Me.PorDefecto()
        Me.txtCodMes.Focus()
        'acc.Nuevo()
    End Sub

    Sub PorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.txtNomEmp.Text = SuperEntidad.xRazonSocial
        Me.txtAno.Text = SuperEntidad.xPeriodoEmpresa.Substring(0, 4)
        paren = par.buscarParametroExis(paren)

    End Sub

    Sub Imprimir()

        ds.RegContab.Clear()

        'Llenar Cabecera()
        periodo = CType(Me.CrRptLibroMayor1.Section2.ReportObjects.Item("Periodo"), CrystalDecisions.CrystalReports.Engine.TextObject)
        periodo.Text = Me.txtAno.Text + " - " + Me.txtCodMes.Text

        mes = CType(Me.CrRptLibroMayor1.Section2.ReportObjects.Item("mes"), CrystalDecisions.CrystalReports.Engine.TextObject)
        mes.Text = Me.txtDesMes.Text.Trim


        ruc = CType(Me.CrRptLibroMayor1.Section2.ReportObjects.Item("Ruc"), CrystalDecisions.CrystalReports.Engine.TextObject)
        ruc.Text = SuperEntidad.xRucEmpresa

        empresa = CType(Me.CrRptLibroMayor1.Section2.ReportObjects.Item("Empresa"), CrystalDecisions.CrystalReports.Engine.TextObject)
        empresa.Text = Me.txtNomEmp.Text

        'TRAER TODOS LOS SALDOS CONTABLES DE CUENTAS ANALITICAS
        Dim iSalConRN As New SaldoContableRN
        Dim iSalConEN As New SuperEntidad
        iSalConEN.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        iSalConEN.PeriodoRegContabCabe = Me.txtAno.Text.Trim
        iSalConEN.NumeroDigitosPcge = paren.DigitosCuentaAnalitica
        iSalConEN.CampoOrden = cam.CodCtaPcge
        Dim iLisSalCon As List(Of SuperEntidad) = iSalConRN.ListarSaldosContableXPeriodoYAnaliticas(iSalConEN)

        'TRAER TODO EL MOVIMIENTO DETALLE
        Dim iMovDetRN As New MovimientoContableDetalleRN
        Dim iMovDetEN As New SuperEntidad
        iMovDetEN.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        iMovDetEN.CampoOrden = cam.CodCtaPcge
        Dim iLisMovDet1 As List(Of SuperEntidad) = iMovDetRN.obtenerMovimientoDetalleXPeriodo(iMovDetEN)

        'OBJETOS DE MOVIMIENTO


        'OBTENER MES ANTERIOR AL PROCESO
        Dim iMesAnt As String
        If Me.txtCodMes.Text.Trim = "00" Then
            iMesAnt = "00"
        Else
            iMesAnt = (CType(Me.txtCodMes.Text.Trim, Integer) - 1).ToString.PadLeft(2, CType("0", Char))
        End If


        'RECORREMOS CADA OBJETO DE SALDO CONTABLE
        For Each xSalCon As SuperEntidad In iLisSalCon
            'DE CADA OBJETO SALDO CONTABLE TRAER SU MOVIMIENTO DETALLE EN EL PERIODO
            'DE PROCESO
            'iMovDetEN.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
            iMovDetEN.CodigoCuentaPcge = xSalCon.CodigoCuentaPcge
            'iMovDetEN.CampoOrden = cam.ClaveRCD
            Dim iLisMovDet As List(Of SuperEntidad) = iMovDetRN.ListarMovimientoContableDetalleXPeriodoYCuenta(iMovDetEN, iLisMovDet1)

            'OBTENER LOS IMPORTES ACUMULADOS DEBE Y HABER DE CADA OBJETO SALDO CONTABLE
            Dim iDebeAcumulado As Decimal = iSalConRN.obtenerDebeAcumulado(xSalCon, iMesAnt)
            Dim iHaberAcumulado As Decimal = iSalConRN.obtenerHaberAcumulado(xSalCon, iMesAnt)

            'SI LA LISTA ESTA VACIO ENTONCES INSERTAMOS UN OBJETO  AL DATATABLE PARA PODER MOSTRAR
            'EL SALDO ANTERIOR
            If iLisMovDet.Count = 0 Then
                'SOLO SI HAY IMPORTE ACUMULADO DE DEBE O HABER SE PASA EL
                'REGISTRO AL DATATABLE
                If iDebeAcumulado <> 0 Or iHaberAcumulado <> 0 Then
                    'CREANDO UN REGISTRO PARA EL DATATABLE
                    Dim NewRow As DataSet1.RegContabRow
                    NewRow = ds.RegContab.NewRegContabRow
                    NewRow.FechaModifica = ""
                    NewRow.CodigoOrigen = ""
                    NewRow.CodigoFile = ""
                    NewRow.NumeroVoucherRegContab = ""
                    NewRow.GlosaRegContab = ""
                    NewRow.ImporteDebe = 0
                    NewRow.ImporteHaber = 0
                    NewRow.TipoDocumento = ""
                    NewRow.FechaDocumento = ""
                    NewRow.SerieDocumento = ""
                    NewRow.NumeroDocumento = ""
                    NewRow.TipoLibro = ""
                    NewRow.CodigoAuxiliar = ""
                    NewRow.Cuenta = xSalCon.CodigoCuentaPcge
                    NewRow.nombrecuenta = xSalCon.NombreCuentaPcge
                    NewRow.ImporteDebeAcumulado = iDebeAcumulado
                    NewRow.ImporteHaberAcumulado = iHaberAcumulado
                    NewRow.Igv = NewRow.ImporteDebeAcumulado ' para totales debe
                    NewRow.IgvPar = NewRow.ImporteHaberAcumulado 'para totales haberes

                    'AGREGANDO REGISTROS AL DATATABLE
                    'LLENANDO EL REGISTRO
                    'AÑADIR AL DS
                    ds.RegContab.Rows.Add(NewRow)
                End If
            Else
                'PARA DETECTAR AL PRIMER OBJETO DE LA LISTA
                'YA QUE A ELLA SE LE VA A PSAR LOS VALORES DE Igv y IgvPar
                Dim iPrimero As Integer = 0

                'AQUI HAY VARIOS DETALLES MOVIMIENTOS ,CREAMOS UN REGISTRO POR CADA DETALLE
                For Each xMovDet As SuperEntidad In iLisMovDet
                    'CREANDO UN REGISTRO PARA EL DATATABLE
                    Dim NewRow As DataSet1.RegContabRow
                    NewRow = ds.RegContab.NewRegContabRow
                    NewRow.FechaModifica = xMovDet.FechaVoucherRegContabCabe.ToShortDateString
                    NewRow.CodigoOrigen = xMovDet.CodigoOrigen
                    NewRow.CodigoFile = xMovDet.CodigoFile
                    NewRow.NumeroVoucherRegContab = xMovDet.NumeroVoucherRegContabCabe
                    NewRow.GlosaRegContab = xMovDet.GlosaRegContabDeta
                    'Si Debe / Haber 
                    If xMovDet.DebeHaberRegContabDeta = "Debe" Then
                        NewRow.ImporteDebe = xMovDet.ImporteSRegContabDeta
                        NewRow.ImporteHaber = 0
                    Else
                        NewRow.ImporteDebe = 0
                        NewRow.ImporteHaber = xMovDet.ImporteSRegContabDeta
                    End If
                    NewRow.TipoDocumento = xMovDet.TipoDocumento
                    NewRow.FechaDocumento = xMovDet.FechaDocumento.ToShortDateString  ''Por que datatable es String
                    NewRow.SerieDocumento = xMovDet.SerieDocumento
                    NewRow.NumeroDocumento = xMovDet.NumeroDocumento
                    NewRow.TipoLibro = "6"
                    NewRow.CodigoAuxiliar = xMovDet.CodigoAuxiliar
                    NewRow.Cuenta = xMovDet.CodigoCuentaPcge
                    NewRow.nombrecuenta = xMovDet.NombreCuentaPcge
                    NewRow.ImporteDebeAcumulado = iDebeAcumulado
                    NewRow.ImporteHaberAcumulado = iHaberAcumulado

                    'SOLO SI ES EL PRIMER OBJETO DE LA LISTA
                    If iPrimero = 0 Then
                        NewRow.Igv = NewRow.ImporteDebeAcumulado ' para totales debe
                        NewRow.IgvPar = NewRow.ImporteHaberAcumulado 'para totales haberes
                    Else
                        NewRow.Igv = 0
                        NewRow.IgvPar = 0
                    End If

                    'AGREGANDO REGISTROS AL DATATABLE
                    'LLENANDO EL REGISTRO
                    'AÑADIR AL DS
                    ds.RegContab.Rows.Add(NewRow)

                    'SUMAMOS UNO AL iPrimero
                    iPrimero += 1
                Next
                iPrimero = 0
            End If
        Next

        CrRptLibroMayor1.SetDataSource(ds)
        Me.crv1.ReportSource = CrRptLibroMayor1
    End Sub

#Region "Mostrar Form Lista"

    Private Sub txtCodMes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodMes.KeyDown
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

#End Region

#Region "Buscar Por Codigo"

    Private Sub txtCodMes_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodMes.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.txtCodMes : ope.txt2 = Me.txtDesMes
        ope.MostrarCodigoDescripcionDeTabla("Mes", "Meses", e)

    End Sub

#End Region

    Private Sub btnEjecutar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEjecutar.Click
        If acc.CamposObligatorios = False Then
            Exit Sub
        Else
            Me.Imprimir()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Dim rpta As Integer = MsgBox("Deseas cancelar la operacion", MsgBoxStyle.YesNo, "Matriz")
        If rpta = MsgBoxResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub



End Class