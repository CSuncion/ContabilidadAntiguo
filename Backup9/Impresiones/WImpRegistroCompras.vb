Imports Entidad
Imports Negocio

Public Class WImpRegistroCompras
    Public ent, entCont, paren As New SuperEntidad
    Public lista, listarc As New List(Of SuperEntidad)
    'Public sc As New SaldoContableRN
    Public rcdc As New RegContabCabeRN
    'Public rcdm As New MovimientoContableDetalleRN
    Public par As New ParametroRN
    Dim cam As New CamposEntidad
    Dim ds As New DataSet1
    Dim tb As New DataTable
    Dim cr As New CrRptRegistroCompras
    Dim acc As New Accion
    Dim numerodigitos As String
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
        numerodigitos = paren.DigitosCuentaAnalitica
    End Sub

    Sub Imprimir()

        ds.RegContab.Clear()
        'Llenar Cabecera()
        periodo = CType(Me.cr.Section2.ReportObjects.Item("Periodo"), CrystalDecisions.CrystalReports.Engine.TextObject)
        periodo.Text = Me.txtAno.Text + Me.txtCodMes.Text

        ruc = CType(Me.cr.Section2.ReportObjects.Item("Ruc"), CrystalDecisions.CrystalReports.Engine.TextObject)
        ruc.Text = SuperEntidad.xRucEmpresa

        empresa = CType(Me.cr.Section2.ReportObjects.Item("Empresa"), CrystalDecisions.CrystalReports.Engine.TextObject)
        empresa.Text = Me.txtNomEmp.Text

        'ano = CType(Me.cr.Section2.ReportObjects.Item("Ano"), CrystalDecisions.CrystalReports.Engine.TextObject)
        'ano.Text = Me.txtAno.Text
        'mes = CType(Me.cr.Section2.ReportObjects.Item("Mes"), CrystalDecisions.CrystalReports.Engine.TextObject)
        'mes.Text = Me.txtDesMes.Text

        '' Traer saldos por ano 
        ent.CodigoOrigen = "4"
        ent.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        ent.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        ent.CampoOrden = cam.CodFilRC + "," + cam.NumVouRCC
        'TRAER MOVIMIENTO CABECERA 
        listarc = rcdc.obtenerRegContabCabePorPeriodoXEmpresaSinExtorno(ent)

        For Each obj As SuperEntidad In listarc

            Dim NewRow As DataSet1.RegContabRow
            NewRow = ds.RegContab.NewRegContabRow

            NewRow.CodigoOrigen = obj.CodigoOrigen
            NewRow.CodigoFile = obj.CodigoFile
            NewRow.NumeroVoucherRegContab = obj.NumeroVoucherRegContabCabe
            NewRow.FechaDocumento = obj.FechaDocumento.ToShortDateString  ''Por que datatable es String
            NewRow.TipoDocumento = obj.TipoDocumento
            NewRow.SerieDocumento = obj.SerieDocumento
            NewRow.NumeroDocumento = obj.NumeroDocumento
            'Tipo de Auxiliar 
            NewRow.Tipo = IIf(obj.CodigoFile = "410", "0", "6").ToString
            NewRow.CodigoAuxiliar = obj.CodigoAuxiliar


            NewRow.DescripcionAuxiliar = obj.DescripcionAuxiliar
            'Segun moneda 0 = soles 1 = Dolares

            If NewRow.DescripcionAuxiliar.Length > 28 Then
                NewRow.DescripcionAuxiliar = obj.DescripcionAuxiliar.Substring(0, 28)
            Else
                NewRow.DescripcionAuxiliar = obj.DescripcionAuxiliar
            End If

            NewRow.PrecioVtaRegContab = CType(IIf(obj.MonedaDocumento = "S/.", 0, obj.PrecioVtaRegContabCabe), Decimal)

            If obj.ModoCompra = "Destinadas a Vtas Gravadas Excl" Then
                NewRow.ValorVtaSolRegContab = obj.ValorVtaSolRegContabCabe
                NewRow.IgvSolRegContab = obj.IgvSolRegContabCabe
                NewRow.ValorVtaSolRegContab1 = 0
                NewRow.IgvSolRegContab1 = 0
                NewRow.ValorVtaSolRegContab2 = 0
                NewRow.IgvSOlRegContab2 = 0
                'If NewRow.TipoDocumento = "03" Then
                '    NewRow.ValorVtaSolRegContab = obj.ExoneradoSolRegContabCabe
                'End If
            End If
            If obj.ModoCompra = "Destinadas a Vtas Gravadas y No Gravadas" Then
                NewRow.ValorVtaSolRegContab1 = obj.ValorVtaSolRegContabCabe
                NewRow.IgvSolRegContab1 = obj.IgvSolRegContabCabe
                NewRow.ValorVtaSolRegContab = 0
                NewRow.IgvSolRegContab = 0
                NewRow.ValorVtaSolRegContab2 = 0
                NewRow.IgvSOlRegContab2 = 0
            End If
            If obj.ModoCompra = "Destinadas a Vtas No Gravadas Excl" Then
                NewRow.ValorVtaSolRegContab2 = obj.ValorVtaSolRegContabCabe
                NewRow.IgvSOlRegContab2 = obj.IgvSolRegContabCabe
                NewRow.ValorVtaSolRegContab = 0
                NewRow.IgvSolRegContab = 0
                NewRow.ValorVtaSolRegContab1 = 0
                NewRow.IgvSolRegContab1 = 0
            End If
            ''  NewRow.Igv = obj.IgvSolRegContabCabe

            NewRow.ExoneradoSolRegContab = obj.ExoneradoSolRegContabCabe

            ''Igv si es 18 0 19 %
            'If obj.IgvPar = 18 Then
            '    NewRow.IgvSolRegContab = obj.IgvSolRegContabCabe
            '    'MsgBox(obj.IgvSolRegContabCabe.ToString)
            '    NewRow.Igv = 0
            'Else
            '    NewRow.IgvSolRegContab = 0
            '    NewRow.Igv = obj.IgvSolRegContabCabe
            'End If
            NewRow.PrecioVtaSolRegContab = obj.PrecioVtaSolRegContabCabe
            'Segun Nota de Credito
            If obj.CodigoFile = "407" Then
                NewRow.PrecioVtaRegContab = NewRow.PrecioVtaRegContab * (-1)
                NewRow.ValorVtaSolRegContab = NewRow.ValorVtaSolRegContab * (-1)
                NewRow.ExoneradoSolRegContab = NewRow.ExoneradoSolRegContab * (-1)
                NewRow.IgvSolRegContab = NewRow.IgvSolRegContab * (-1)
                '     NewRow.Igv = NewRow.Igv * (-1)
                NewRow.PrecioVtaSolRegContab = NewRow.PrecioVtaSolRegContab * (-1)
            End If
            'NewRow.IgvSolRegContab = obj.ValorVtaSolRegContabCabe
            'Tipo de cambio segun moneda
            NewRow.VentaTipoCambio = CType(IIf(obj.MonedaDocumento = "0", 0, obj.VentaTipoCambio), Decimal)
            NewRow.NumeroPapeleta = obj.NumeroPapeletaRegContabCabe
            NewRow.FechaDetraccion = obj.FechaDetraccionRegContabCabe
            NewRow.TipoDoc1 = obj.TipoDocumento1
            NewRow.Serie1 = obj.SerieDocumento1
            NewRow.Numero1 = obj.NumeroDocumento1
            NewRow.Fecha1 = obj.FechaDocumento1

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