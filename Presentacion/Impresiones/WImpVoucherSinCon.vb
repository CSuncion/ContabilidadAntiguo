Imports Entidad
Imports Negocio

Public Class WImpVoucherSinCon
#Region "Propietarios"
    Public wCvT As New WVouchersTodos
#End Region

    Public ent, entCont, paren As New SuperEntidad
    Public lista, listarc As New List(Of SuperEntidad)
    Public rcdc As New RegContabCabeRN
    Public rcdm As New RegContabDetaRN
    Public par As New ParametroRN
    Dim cam As New CamposEntidad
    Dim ds As New DataSet1
    Dim tb As New DataTable
    Dim cr As New CrRptVoucherSinCon
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
        Me.CmbTodPar.SelectedIndex = 0
        Me.HabilitarControlesSegunCombo()
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
        mes = CType(Me.cr.Section2.ReportObjects.Item("Mes"), CrystalDecisions.CrystalReports.Engine.TextObject)
        mes.Text = Me.txtDesMes.Text

        ano = CType(Me.cr.Section2.ReportObjects.Item("Ano"), CrystalDecisions.CrystalReports.Engine.TextObject)
        ano.Text = Me.txtAno.Text

        empresa = CType(Me.cr.Section2.ReportObjects.Item("Empresa"), CrystalDecisions.CrystalReports.Engine.TextObject)
        empresa.Text = Me.txtNomEmp.Text


        '' Traer TODOS los movimientos 
        ent.CodigoOrigen = ""
        ent.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        ent.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        If Me.CmbTodPar.Text = "Parcial" Then
            ent.CodigoFile = Me.TxtCodFil.Text.Trim
        End If
        ent.CampoOrden = cam.CodFilRC + "," + cam.NumVouRCC
        'TRAER MOVIMIENTO CABECERA 
        If Me.CmbTodPar.Text = "Total" Then
            listarc = rcdm.obtenerDetalleRegContabPorPeriodo(ent)
        Else
            listarc = rcdm.obtenerDetalleRegContabPorPeriodoYFile(ent)
        End If
        '  listarc = rcdm.obtenerDetalleRegContabPorPeriodo(ent)

        For Each obj As SuperEntidad In listarc

            Dim NewRow As DataSet1.RegContabRow
            NewRow = ds.RegContab.NewRegContabRow

            NewRow.ClaveRegContab = obj.ClaveRegContabCabe
            NewRow.CodigoOrigen = obj.CodigoOrigen
            NewRow.CodigoFile = obj.CodigoFile
            NewRow.NumeroVoucherRegContab = obj.NumeroVoucherRegContabCabe
            NewRow.FechaVoucherrgContab = obj.FechaVoucherRegContabCabe
            NewRow.Correlativo = obj.CorrelativoRegContabDeta
            NewRow.Cuenta = obj.CodigoCuentaPcge
            NewRow.CodigoAuxiliar = obj.CodigoAuxiliar
            NewRow.CentroCosto = obj.CodigoCentroCosto
            'NewRow.TipoLibro = "5"
            NewRow.TipoDocumento = obj.TipoDocumento
            NewRow.SerieDocumento = obj.SerieDocumento
            NewRow.NumeroDocumento = obj.NumeroDocumento
            NewRow.FechaDocumento = obj.FechaDocumento.ToShortDateString  ''Por que datatable es String
            NewRow.VentaTipoCambio = obj.VentaTipoCambio
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

        cr.SetDataSource(ds)
        'Cargamos en nuestro formulario el cr
        Me.crv1.ReportSource = cr
        'Dim win As New wImpParaEnvio
        'win.NuevaVentana(ds)
        '/
    End Sub

    Sub HabilitarControlesSegunCombo()
        '/
        'Habilitar los campos segun modo 
        If Me.CmbTodPar.Text = "Total" Then
            Me.TxtCodFil.Enabled = False
            Me.TxtCodFil.Text = String.Empty
            Me.TxtNomFil.Text = String.Empty
            Me.btnEjecutar.Focus()
        Else
            Me.TxtCodFil.Enabled = True
            Me.TxtCodFil.Focus()
        End If
        '/
    End Sub
    Sub ListarTablaMeses()
        Dim win As New WListarTabla
        win.tabla = "Mes"
        win.titulo = "Meses"
        win.txt1 = Me.txtCodMes
        win.txt2 = Me.txtDesMes
        win.ctrlFoco = Me.CmbTodPar
        win.NuevaVentana()
    End Sub
    Sub ListarTablaFiles()
        Dim win As New WListaFiles
        win.titulo = "Files"
        win.CondicionLista = "ListarFilesTodos"
        win.ent.CodigoFile = ""
        win.txt1 = Me.TxtCodFil
        win.txt2 = Me.TxtNomFil
        win.ctrlFoco = Me.btnEjecutar
        win.NuevaVentana()
    End Sub

#Region "Mostrar Form Lista"

    Private Sub txtCodMes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodMes.KeyDown
        If Me.txtCodMes.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Me.ListarTablaMeses()
                'Dim win As New WListarTabla
                'win.tabla = "Mes"
                'win.titulo = "Meses"
                'win.txt1 = Me.txtCodMes
                'win.txt2 = Me.txtDesMes
                'win.ctrlFoco = Me.CmbTodPar
                'win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub TxtCodFil_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodFil.KeyDown
        If Me.TxtCodFil.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Me.ListarTablaFiles()
                'Dim win As New WListaFiles
                'win.titulo = "Files"
                'win.CondicionLista = "ListarFilesTodos"
                'win.ent.CodigoFile = ""
                'win.txt1 = Me.TxtCodFil
                'win.txt2 = Me.TxtNomFil
                'win.ctrlFoco = Me.btnEjecutar
                'win.NuevaVentana()
            End If
        End If
    End Sub

#End Region

#Region "Buscar Por Codigo"

    Private Sub txtCodMes_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodMes.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.txtCodMes : ope.txt2 = Me.txtDesMes
        ope.MostrarCodigoDescripcionDeTabla("Mes", "Meses", e)

    End Sub

    Private Sub TxtCodFil_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodFil.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.TxtCodFil : ope.txt2 = Me.TxtNomFil
        ope.MostrarCodigoDescripcionDeFile("Files", e)
    End Sub

#End Region

    Private Sub btnEjecutar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEjecutar.Click
        If acc.CamposObligatorios = False Then
            Exit Sub
        Else
            If Me.CmbTodPar.Text = "Parcial" Then
                If Me.TxtCodFil.Text = String.Empty Then
                    MessageBox.Show("Digite File", "Listado Voucher")
                    Me.TxtCodFil.Focus()
                    Exit Sub
                End If
                Me.Imprimir()
            Else
                Me.Imprimir()
            End If
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

    Private Sub CmbTodPar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbTodPar.SelectedIndexChanged
        Me.HabilitarControlesSegunCombo()
    End Sub

    Private Sub txtCodMes_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodMes.DoubleClick
        Me.ListarTablaMeses()
    End Sub

    Private Sub TxtCodFil_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCodFil.DoubleClick
        Me.ListarTablaFiles()
    End Sub
End Class