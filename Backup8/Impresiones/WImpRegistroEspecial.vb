Imports CrystalDecisions.CrystalReports.Engine
Imports Entidad
Imports Negocio

Public Class wImpRegistroEspecial

#Region "Propietarios"
    Public wRv As New WRegistroVentaEspecial
#End Region

    Public ent, entCont, paren As New SuperEntidad
    Public lista, listarrc As New List(Of SuperEntidad)
    Public sc As New SaldoContableRN
    Public rc As New RegistroEspecialRN
    Public rcdc As New MovimientoContableCabeceraRN
    Public rcdm As New MovimientoContableDetalleRN
    Public par As New ParametroRN
    Dim cam As New CamposEntidad
    Dim ds As New DataSet1
    Dim tb As New DataTable
    Dim cr As New CrRptRegistroEspecial
    Dim acc As New Accion
    Dim numerodigitos As String
    Dim ano, mes, empresa As CrystalDecisions.CrystalReports.Engine.TextObject

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
        empresa = CType(Me.cr.Section2.ReportObjects.Item("Empresa"), CrystalDecisions.CrystalReports.Engine.TextObject)
        empresa.Text = Me.txtNomEmp.Text

        ano = CType(Me.cr.Section2.ReportObjects.Item("Ano"), CrystalDecisions.CrystalReports.Engine.TextObject)
        ano.Text = Me.txtAno.Text
        mes = CType(Me.cr.Section2.ReportObjects.Item("Mes"), CrystalDecisions.CrystalReports.Engine.TextObject)
        mes.Text = Me.txtDesMes.Text

        '' Traer saldos por ano 
        ent.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        ent.CodigoOrigen = "5"
        ent.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        ent.CampoOrden = cam.CodAux
        'ent.CampoOrden = cam.CodAux + "," + cam.NumDoc + "," + cam.SerDoC + "," + cam.NumDoc
        'TRAER MOVIMIENTO CABECERA 
        listarrc = rc.obtenerRegContabCabeExisXOrigenYPeriodo(ent)

        For Each obj As SuperEntidad In listarrc

            Dim NewRow As DataSet1.RegContabRow
            NewRow = ds.RegContab.NewRegContabRow

            'NewRow.NumeroVoucherRegContab = obj.NumeroVoucherRegContabCabe
            NewRow.PeriodoRegContab = obj.PeriodoRegContabCabe
            NewRow.CodigoAuxiliar = obj.CodigoAuxiliar
            NewRow.DescripcionAuxiliar = obj.DescripcionAuxiliar
            NewRow.TipoDocumento = obj.TipoDocumento
            NewRow.SerieDocumento = obj.SerieDocumento
            NewRow.NumeroDocumento = obj.NumeroDocumento
            NewRow.Numero1 = obj.NumeroDocumento1
            NewRow.FechaDocumento = obj.FechaDocumento.ToShortDateString
            NewRow.MonedaDocumento = obj.MonedaDocumento
            If obj.MonedaDocumento = "US$" Then
                NewRow.VentaTipoCambio = obj.VentaTipoCambio
                NewRow.PrecioVtaRegContab = obj.PrecioVtaRegContabCabe
            End If
            NewRow.ValorVtaSolRegContab = obj.ValorVtaSolRegContabCabe
            NewRow.ExoneradoSolRegContab = obj.ExoneradoSolRegContabCabe
            NewRow.IgvSolRegContab = obj.IgvSolRegContabCabe
            NewRow.PrecioVtaSolRegContab = obj.PrecioVtaSolRegContabCabe

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
        Me.Close()
    End Sub

End Class