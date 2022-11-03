Imports Entidad
Imports Negocio


Public Class WImpCuentaCorriente

#Region "Propietarios"
    Public wCtaCte As New WCuentaCorriente
#End Region

    Public ent, entCont, paren As New SuperEntidad
    Public lista, listarc As New List(Of SuperEntidad)
    Public ccte As New CuentaCorrienteRN
    Public par As New ParametroRN
    Dim cam As New CamposEntidad
    Dim ds As New DataSet1
    Dim tb As New DataTable
    Dim cr As New CrRptCuentaCorriente
    Dim acc As New Accion
    Dim numerodigitos As String
    Dim ano, mes, empresa, periodo, ruc, debe, haber, ImpDebe, ImpHaber, ImporteSol, ImporteDol, dia, numcta, moneda, tipocuenta As CrystalDecisions.CrystalReports.Engine.TextObject

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
        Me.dtpHasta.Focus()
        'acc.Nuevo()
    End Sub

    Sub PorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.txtNomEmp.Text = SuperEntidad.xRazonSocial
        paren = par.buscarParametroExis(paren)
        numerodigitos = paren.DigitosCuentaAnalitica
    End Sub

    Sub Imprimir()

        ds.RegContab.Clear()
        'Llenar Cabecera()
        empresa = CType(Me.cr.Section2.ReportObjects.Item("Empresa"), CrystalDecisions.CrystalReports.Engine.TextObject)
        empresa.Text = Me.txtNomEmp.Text

        If Rbt.radioActivo(Me.gbXPagXCob).Text = "Por Pagar" Then
            tipocuenta = CType(Me.cr.Section2.ReportObjects.Item("tipocuenta"), CrystalDecisions.CrystalReports.Engine.TextObject)
            tipocuenta.Text = "DOCUMENTOS POR PAGAR"
        Else
            tipocuenta = CType(Me.cr.Section2.ReportObjects.Item("tipocuenta"), CrystalDecisions.CrystalReports.Engine.TextObject)
            tipocuenta.Text = "DOCUMENTOS POR COBRAR"
        End If

        dia = CType(Me.cr.Section2.ReportObjects.Item("dia"), CrystalDecisions.CrystalReports.Engine.TextObject)
        dia.Text = Me.dtpHasta.Text.ToString

        ent.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        ent.FechaVctoDocumento = Varios.AñoMesDia(Me.dtpHasta.Text)
        ent.CampoOrden = cam.CodAux + "," + cam.CodTipDoc + "," + cam.SerDoC + "," + cam.NumDoc

        'TRAER MOVIMIENTO DETALLE

        If Rbt.radioActivo(Me.gbXPagXCob).Text = "Por Pagar" Then
            listarc = ccte.ReporteCuentasXPagar(ent)
        Else
            listarc = ccte.ReporteCuentasXCobrar(ent)
        End If

        For Each obj As SuperEntidad In listarc

            Dim NewRow As DataSet1.RegContabRow
            NewRow = ds.RegContab.NewRegContabRow

            'Llenar Documentos de Cuenta Corriente
            NewRow.CodigoFile = obj.CodigoFile
            NewRow.CodigoAuxiliar = obj.CodigoAuxiliar
            NewRow.DescripcionAuxiliar = obj.DescripcionAuxiliar
            NewRow.TipoDocumento = obj.TipoDocumento
            NewRow.SerieDocumento = obj.SerieDocumento
            NewRow.NumeroDocumento = obj.NumeroDocumento
            NewRow.FechaDocumento = obj.FechaDocumento.ToShortDateString.ToString
            NewRow.FechaDetraccion = CType(obj.FechaVctoDocumento, DateTime).ToShortDateString '' Fecha Vencimiento
            NewRow.MonedaDocumento = obj.MonedaDocumento

            Select Case NewRow.MonedaDocumento
                Case "S/."
                    NewRow.ImporteSol = obj.SaldoCuentaCorriente
                    NewRow.ImporteDol = 0
                Case "US$"
                    NewRow.ImporteSol = 0
                    NewRow.ImporteDol = obj.SaldoCuentaCorriente

            End Select

            'AGREGANDO REGISTROS AL DATATABLE
            'LLENANDO EL REGISTRO
            'AÑADIR AL DS
            ds.RegContab.Rows.Add(NewRow)

        Next

        cr.SetDataSource(ds)
        'Cargamos en nuestro formulario el cr
        Me.crv1.ReportSource = cr
        'Dim win As New wImpParaEnvio
        'win.NuevaVentana(ds)
        '/
    End Sub

    Private Sub btnEjecutar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEjecutar.Click
        If acc.CamposObligatorios = False Then
            Exit Sub
        Else
            Me.Imprimir()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

End Class