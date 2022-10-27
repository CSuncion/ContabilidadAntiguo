Imports CrystalDecisions.CrystalReports.Engine
Imports Entidad
Imports Negocio

Public Class WImpVoucher1

#Region "Propietarios"
    Public wfcon As New WVouchersTodos
#End Region

    Public ent As New SuperEntidad
    Public listarfc As New List(Of SuperEntidad)
    Public rcc As New RegContabCabeRN
    Public rcd As New RegContabDetaRN
    Dim cam As New CamposEntidad
    Dim ds As New DataSet1
    Dim acc As New Accion
    Dim origen, nombreo, file, nombref, fecha, numero, girado, concepto, ano, mes, empresa, ctacte, banco, moneda, cheque, monto, moneda1, tipoc, ingegr, usuario As CrystalDecisions.CrystalReports.Engine.TextObject

    Sub NuevaVentanaDesdeVoucher()
        Me.Imprimir()
        Me.Show()
        '/
    End Sub

    Sub Imprimir()

        ds.RegContab.Clear()
        'Llenar Cabecera()
        empresa = CType(Me.CrRptVoucher11.Section2.ReportObjects.Item("Empresa"), CrystalDecisions.CrystalReports.Engine.TextObject)
        empresa.Text = SuperEntidad.xRazonSocial
        ' empresa.Text = SuperEntidad.xNombreCortoEmpresa

        ano = CType(Me.CrRptVoucher11.Section2.ReportObjects.Item("Ano"), CrystalDecisions.CrystalReports.Engine.TextObject)
        ano.Text = ent.FechaVoucherRegContabCabe.Year.ToString.Trim

        mes = CType(Me.CrRptVoucher11.Section2.ReportObjects.Item("Mes"), CrystalDecisions.CrystalReports.Engine.TextObject)
        mes.Text = ent.FechaVoucherRegContabCabe.Month.ToString.Trim.PadLeft(2, CType("0", Char))

        Select Case mes.Text
            Case "01"
                mes.Text = "Enero"
            Case "02"
                mes.Text = "Febrero"
            Case "03"
                mes.Text = "Marzo"
            Case "04"
                mes.Text = "Abril"
            Case "05"
                mes.Text = "Mayo"
            Case "06"
                mes.Text = "Junio"
            Case "07"
                mes.Text = "Julio"
            Case "08"
                mes.Text = "Agosto"
            Case "09"
                mes.Text = "Setiembre"
            Case "10"
                mes.Text = "Octubre"
            Case "11"
                mes.Text = "Noviembre"
            Case "12"
                mes.Text = "Diciembre"
        End Select


        origen = CType(Me.CrRptVoucher11.Section2.ReportObjects.Item("origen"), CrystalDecisions.CrystalReports.Engine.TextObject)
        origen.Text = ent.CodigoOrigen

        ingegr = CType(Me.CrRptVoucher11.Section2.ReportObjects.Item("ingegr"), CrystalDecisions.CrystalReports.Engine.TextObject)
        Select Case origen.Text
            Case "1"
                ingegr.Text = "INGRESO"

            Case "2"
                ingegr.Text = "EGRESO"

        End Select

        nombreo = CType(Me.CrRptVoucher11.Section2.ReportObjects.Item("NombreO"), CrystalDecisions.CrystalReports.Engine.TextObject)
        nombreo.Text = ent.NombreOrigen

        file = CType(Me.CrRptVoucher11.Section2.ReportObjects.Item("File"), CrystalDecisions.CrystalReports.Engine.TextObject)
        file.Text = ent.CodigoFile

        nombref = CType(Me.CrRptVoucher11.Section2.ReportObjects.Item("Nombref"), CrystalDecisions.CrystalReports.Engine.TextObject)
        nombref.Text = ent.NombreFile

        ctacte = CType(Me.CrRptVoucher11.Section2.ReportObjects.Item("CtaCte"), CrystalDecisions.CrystalReports.Engine.TextObject)
        ctacte.Text = ent.NumeroCuentaBanco

        moneda = CType(Me.CrRptVoucher11.Section2.ReportObjects.Item("moneda"), CrystalDecisions.CrystalReports.Engine.TextObject)
        moneda.Text = ent.MonedaCuentaBanco
        Select Case moneda.Text
            Case "0"
                moneda.Text = "S/."

            Case "1"
                moneda.Text = "US$"

        End Select
        moneda1 = CType(Me.CrRptVoucher11.Section2.ReportObjects.Item("moneda1"), CrystalDecisions.CrystalReports.Engine.TextObject)
        moneda1.Text = moneda.Text

        banco = CType(Me.CrRptVoucher11.Section2.ReportObjects.Item("banco"), CrystalDecisions.CrystalReports.Engine.TextObject)
        banco.Text = ent.BancoCuentaBanco

        cheque = CType(Me.CrRptVoucher11.Section2.ReportObjects.Item("cheque"), CrystalDecisions.CrystalReports.Engine.TextObject)
        cheque.Text = ent.NumeroDocumento

        monto = CType(Me.CrRptVoucher11.Section2.ReportObjects.Item("monto"), CrystalDecisions.CrystalReports.Engine.TextObject)
        monto.Text = Varios.numeroConDosDecimal(ent.ImporteRegContabCabe.ToString.Trim)

        tipoc = CType(Me.CrRptVoucher11.Section2.ReportObjects.Item("tipoc"), CrystalDecisions.CrystalReports.Engine.TextObject)
        tipoc.Text = Varios.numeroConTresDecimal(ent.VentaTipoCambio.ToString.Trim)

        fecha = CType(Me.CrRptVoucher11.Section2.ReportObjects.Item("fecha"), CrystalDecisions.CrystalReports.Engine.TextObject)
        fecha.Text = ent.FechaVoucherRegContabCabe.ToShortDateString

        numero = CType(Me.CrRptVoucher11.Section2.ReportObjects.Item("numero"), CrystalDecisions.CrystalReports.Engine.TextObject)
        numero.Text = ent.NumeroVoucherRegContabCabe

        girado = CType(Me.CrRptVoucher11.Section2.ReportObjects.Item("girado"), CrystalDecisions.CrystalReports.Engine.TextObject)
        girado.Text = ent.DescripcionRegContabCabe

        concepto = CType(Me.CrRptVoucher11.Section2.ReportObjects.Item("concepto"), CrystalDecisions.CrystalReports.Engine.TextObject)
        concepto.Text = ent.GlosaRegContabCabe


        usuario = CType(Me.CrRptVoucher11.Section5.ReportObjects.Item("usuario"), CrystalDecisions.CrystalReports.Engine.TextObject)
        usuario.Text = ent.CodigoUsuarioModifica


        'TRAER MOVIMIENTO DETALLE
        ent.CampoOrden = cam.ClaveRCC
        listarfc = rcd.obtenerDetalleRegContabPorClave(ent)

        For Each obj As SuperEntidad In listarfc

            Dim NewRow As DataSet1.RegContabRow
            NewRow = ds.RegContab.NewRegContabRow
            NewRow.Cuenta = obj.CodigoCuentaPcge
            NewRow.nombrecuenta = obj.NombreCuentaPcge
            NewRow.CodigoAuxiliar = obj.CodigoAuxiliar
            NewRow.DescripcionAuxiliar = obj.DescripcionAuxiliar
            NewRow.CentroCosto = obj.CodigoCentroCosto
            NewRow.TipoDocumento = obj.TipoDocumento
            NewRow.SerieDocumento = obj.SerieDocumento
            NewRow.NumeroDocumento = obj.NumeroDocumento
            NewRow.FechaDocumento = obj.FechaDocumento.ToString
            NewRow.GlosaRegContab = obj.GlosaRegContabDeta
            'Si Debe / Haber 
            If obj.DebeHaberRegContabDeta = "Debe" Then
                NewRow.ImporteDebe = obj.ImporteSRegContabDeta
                NewRow.ImporteHaber = 0
            Else
                NewRow.ImporteDebe = 0
                NewRow.ImporteHaber = obj.ImporteSRegContabDeta
            End If

            'AGREGANDO REGISTROS AL DATATABLE
            'LLENANDO EL REGISTRO
            'AÑADIR AL DS
            ds.RegContab.Rows.Add(NewRow)

        Next
        CrRptVoucher11.SetDataSource(ds)
        'Cargamos en nuestro formulario el cr
        Me.crv1.ReportSource = CrRptVoucher11
        'Dim win As New wImpParaEnvio
        'win.NuevaVentana(ds)
        '/
    End Sub

#Region "Mostrar Form Lista"
#End Region

#Region "Buscar Por Codigo"

#End Region


End Class