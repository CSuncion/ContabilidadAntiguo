Imports Entidad
Imports Negocio


Public Class WImpRegistroComprasDol

   
    Dim cam As New CamposEntidad
    Dim ds As New DataSet1
    Dim tb As New DataTable
    Dim cr As New CrRptRegistroComprasDol
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
        Me.dtpFechaDes.Focus()
        'acc.Nuevo()
    End Sub

    Sub PorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.txtNomEmp.Text = SuperEntidad.xRazonSocial
    End Sub

    Sub Imprimir()

        ds.RegContab.Clear()

        'Llenar Cabecera()
        periodo = CType(Me.cr.Section2.ReportObjects.Item("Periodo"), CrystalDecisions.CrystalReports.Engine.TextObject)
        periodo.Text = "Del Dia :" + Me.dtpFechaDes.Text + " Al :" + Me.dtpFechaHas.Text

        ruc = CType(Me.cr.Section2.ReportObjects.Item("Ruc"), CrystalDecisions.CrystalReports.Engine.TextObject)
        ruc.Text = SuperEntidad.xRucEmpresa

        empresa = CType(Me.cr.Section2.ReportObjects.Item("Empresa"), CrystalDecisions.CrystalReports.Engine.TextObject)
        empresa.Text = Me.txtNomEmp.Text
      
        ''TRAER LOS REGISTROS COMPRAS POR RANGO FECHA
        Dim iRccRN As New RegContabCabeRN
        Dim iRccEN As New SuperEntidad
        iRccEN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iRccEN.CodigoOrigen = "4" 'compras
        iRccEN.DatoCondicion1 = Varios.AñoMesDia(Me.dtpFechaDes.Value)
        iRccEN.DatoCondicion2 = Varios.AñoMesDia(Me.dtpFechaHas.Value)
        iRccEN.CampoOrden = cam.CodFilRC + "," + cam.NumVouRCC
        Dim iLisRcc As List(Of SuperEntidad) = iRccRN.ListarRegistrosCabeceraXOrigenYRangoFechaVoucher(iRccEN)

        For Each obj As SuperEntidad In iLisRcc

            Dim NewRow As DataSet1.RegContabRow
            NewRow = ds.RegContab.NewRegContabRow
            NewRow.CodigoFile = obj.CodigoFile
            NewRow.NumeroVoucherRegContab = obj.NumeroVoucherRegContabCabe
            NewRow.TipoDocumento = obj.TipoDocumento
            NewRow.SerieDocumento = obj.SerieDocumento
            NewRow.NumeroDocumento = obj.NumeroDocumento
            NewRow.FechaDocumento = obj.FechaDocumento.ToShortDateString
            NewRow.CodigoAuxiliar = obj.CodigoAuxiliar
            NewRow.DescripcionAuxiliar = obj.DescripcionAuxiliar
            'solo cuando es documento es dolar
            If obj.MonedaDocumento = "US$" Then
                NewRow.VentaTipoCambio = obj.VentaTipoCambio
                If obj.CodigoFile = "407" Then
                    NewRow.ImporteDol = obj.PrecioVtaRegContabCabe * (-1)
                Else
                    NewRow.ImporteDol = obj.PrecioVtaRegContabCabe
                End If
            End If
            If obj.CodigoFile = "407" Then
                NewRow.ValorVtaSolRegContab = obj.ValorVtaSolRegContabCabe * (-1)
                NewRow.IgvSolRegContab = obj.IgvSolRegContabCabe * (-1)
                NewRow.ExoneradoSolRegContab = obj.ExoneradoSolRegContabCabe * (-1)
                NewRow.PrecioVtaSolRegContab = obj.PrecioVtaSolRegContabCabe * (-1)
            Else
                NewRow.ValorVtaSolRegContab = obj.ValorVtaSolRegContabCabe
                NewRow.IgvSolRegContab = obj.IgvSolRegContabCabe
                NewRow.ExoneradoSolRegContab = obj.ExoneradoSolRegContabCabe
                NewRow.PrecioVtaSolRegContab = obj.PrecioVtaSolRegContabCabe
            End If

            'AGREGANDO REGISTROS AL DATATABLE
            'LLENANDO EL REGISTRO
            'AÑADIR AL DS
            ds.RegContab.Rows.Add(NewRow)

        Next

        cr.SetDataSource(ds)
        'Cargamos en nuestro formulario el crcc
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
        Dim rpta As Integer = MsgBox("Deseas cancelar la operacion", MsgBoxStyle.YesNo, "Matriz")
        If rpta = MsgBoxResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub


End Class