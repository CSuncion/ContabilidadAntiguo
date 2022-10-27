Imports CrystalDecisions.CrystalReports.Engine
Imports Entidad
Imports Negocio

Public Class wImpTesoreriaDetallado
    Public ent, entCont, paren As New SuperEntidad
    Public lista, listarsc As New List(Of SuperEntidad)
    Public rcd As New RegContabDetaRN
    Public par As New ParametroRN
    Dim cam As New CamposEntidad
    Dim ds As New DataSet1
    Dim tb As New DataTable
    Dim cr As New CrImpTesoreriaDetallado
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
        ent.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        ent.CodigoEmpresa = Me.TxtCodEmp.Text.Trim

        ent.CampoOrden = cam.CodIngEgr
        'TRAER MOVIMIENTO DETALLE
        lista = rcd.obtenerDetalleRegContabXPeriodoIngEgr(ent)

        For Each obj As SuperEntidad In lista

            Dim NewRow As DataSet1.RegContabRow
            NewRow = ds.RegContab.NewRegContabRow

            NewRow.CodigoIngEgr = obj.CodigoIngEgr
            NewRow.NombreIngEgr = obj.NombreIngEgr
            NewRow.CodigoFile = obj.CodigoFile
            NewRow.NombreFile = obj.NombreFile
            NewRow.NumeroVoucherRegContab = obj.NumeroVoucherRegContabCabe
            NewRow.FechaVoucherrgContab = obj.FechaVoucherRegContabCabe
            NewRow.Cuenta = obj.CodigoCuentaPcge
            NewRow.Girado = obj.GlosaRegContabDeta
            NewRow.VentaTipoCambio = obj.VentaTipoCambio
            NewRow.MonedaDocumento = obj.Exporta '' Moneda del Documento
            If obj.DebeHaberRegContabDeta = "Debe" Then
                NewRow.ImporteDebe = obj.ImporteSRegContabDeta
                NewRow.ImporteHaber = 0
                NewRow.ImporteSol = obj.ImporteDRegContabDeta
                NewRow.ImporteDol = 0
                'NewRow.ImporteDebeAcumulado = NewRow.ImporteDebeAcumulado + obj.ImporteSRegContabDeta
                'NewRow.ImporteHaberAcumulado = NewRow.ImporteHaberAcumulado + obj.ImporteDRegContabDeta
            Else
                NewRow.ImporteDebe = 0
                NewRow.ImporteHaber = obj.ImporteSRegContabDeta
                NewRow.ImporteSol = 0
                NewRow.ImporteDol = obj.ImporteDRegContabDeta
                'NewRow.ExoneradoSolRegContab = NewRow.ExoneradoSolRegContab + obj.ImporteSRegContabDeta
                'NewRow.IgvSolRegContab = NewRow.IgvSolRegContab + obj.ImporteDRegContabDeta
            End If
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