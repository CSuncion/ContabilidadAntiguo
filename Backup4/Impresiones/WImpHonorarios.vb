Imports CrystalDecisions.CrystalReports.Engine
Imports Entidad
Imports Negocio

Public Class wImpHonorarios

#Region "Propietarios"
    Public wRh As New WRegistroHonorario
#End Region

    Public ent, entCont, paren As New SuperEntidad
    Public lista, listarrc As New List(Of SuperEntidad)
    Public sc As New SaldoContableRN
    Public rc As New RegContabCabeRN
    Public rcdc As New MovimientoContableCabeceraRN
    Public rcdm As New MovimientoContableDetalleRN
    Public par As New ParametroRN
    Dim cam As New CamposEntidad
    Dim ds As New DataSet1
    Dim tb As New DataTable
    Dim acc As New Accion
    Dim numerodigitos As String
    Dim ano, mes, empresa, mes1 As CrystalDecisions.CrystalReports.Engine.TextObject

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
        Me.HabilitarControlesEstadoAuxiliar()
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
        empresa = CType(Me.CrRptHonorarios1.Section2.ReportObjects.Item("Empresa"), CrystalDecisions.CrystalReports.Engine.TextObject)
        empresa.Text = Me.txtNomEmp.Text

        ano = CType(Me.CrRptHonorarios1.Section2.ReportObjects.Item("Ano"), CrystalDecisions.CrystalReports.Engine.TextObject)
        ano.Text = Me.txtAno.Text
        mes = CType(Me.CrRptHonorarios1.Section2.ReportObjects.Item("Mes"), CrystalDecisions.CrystalReports.Engine.TextObject)
        mes.Text = Me.txtDesMes.Text

        mes1 = CType(Me.CrRptHonorarios1.Section2.ReportObjects.Item("Mes1"), CrystalDecisions.CrystalReports.Engine.TextObject)
        mes1.Text = Me.TxtDesMes1.Text
        '' Traer saldos por ano 
        ent.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        ent.CodigoOrigen = "6"
        ent.DatoCondicion1 = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        ent.DatoCondicion2 = Me.txtAno.Text.Trim + Me.TxtCodMes1.Text.Trim
        If Rbt.radioActivo(Me.gbAnaAux).Text.Trim = "Todas" Then
            ent.CodigoAuxiliar = ""
        Else
            ent.CodigoAuxiliar = Me.TxtCodAux.Text.Trim
        End If

        ent.CampoOrden = cam.CodAux

        '  listarrc = rc.obtenerRegContabCabeExisXOrigenYPeriodo(ent)
        listarrc = rc.ListarMovimientoXEmpresaXPeriodoYAuxiliar(ent)

        For Each obj As SuperEntidad In listarrc

            Dim NewRow As DataSet1.RegContabRow
            NewRow = ds.RegContab.NewRegContabRow

            NewRow.NumeroVoucherRegContab = obj.NumeroVoucherRegContabCabe
            NewRow.CodigoAuxiliar = obj.CodigoAuxiliar
            NewRow.TipoDocumento = obj.TipoDocumento
            NewRow.SerieDocumento = obj.SerieDocumento
            NewRow.NumeroDocumento = obj.NumeroDocumento
            NewRow.FechaDocumento = obj.FechaDocumento.ToShortDateString
            NewRow.DescripcionAuxiliar = obj.DescripcionAuxiliar
            If obj.MonedaDocumento = "US$" Then
                NewRow.VentaTipoCambio = obj.VentaTipoCambio
                NewRow.PrecioVtaRegContab = obj.PrecioVtaRegContabCabe
            End If
            NewRow.PrecioVtaSolRegContab = obj.PrecioVtaSolRegContabCabe
            NewRow.ValorVtaSolRegContab = obj.ValorVtaSolRegContabCabe
            'DESCUENTO AFP SNP
            Select Case obj.FlagDescuentoRegContabCabe
                Case "A.F.P."
                    NewRow.ImporteSol = obj.ImporteDescuentoRegContabCabe
                    NewRow.ImporteDol = 0
                    NewRow.IgvSolRegContab = obj.IgvSolRegContabCabe - NewRow.ImporteSol
                Case "S.N.P."
                    NewRow.ImporteSol = 0
                    NewRow.ImporteDol = obj.ImporteDescuentoRegContabCabe
                    NewRow.IgvSolRegContab = obj.IgvSolRegContabCabe - NewRow.ImporteDol
                Case Else
                    NewRow.ImporteSol = 0
                    NewRow.ImporteDol = 0
                    NewRow.IgvSolRegContab = obj.IgvSolRegContabCabe
            End Select

            'NewRow.IgvSolRegContab = obj.IgvSolRegContabCabe

            'AGREGANDO REGISTROS AL DATATABLE
            'LLENANDO EL REGISTRO
            'AÑADIR AL DS
            ds.RegContab.Rows.Add(NewRow)

        Next

        CrRptHonorarios1.SetDataSource(ds)
        'Cargamos en nuestro formulario el cr
        Me.crv1.ReportSource = CrRptHonorarios1
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
                win.ctrlFoco = Me.TxtCodMes1
                win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub TxtCodMes1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodMes1.KeyDown
        If Me.TxtCodMes1.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarTabla
                win.tabla = "Mes"
                win.titulo = "Meses"
                win.txt1 = Me.TxtCodMes1
                win.txt2 = Me.TxtDesMes1
                win.ctrlFoco = Me.rbtAnaTodos
                win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub TxtCodAux_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodAux.KeyDown
        If Me.TxtCodAux.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarAuxiliar
                win.wImpHon = Me
                Me.AddOwnedForm(win)
                win.tabla = "Todos"
                win.titulo = "Auxiliares"
                win.txt1 = Me.TxtCodAux
                win.txt2 = Me.TxtDesAux
                win.ctrlFoco = Me.btnEjecutar
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

    Private Sub TxtCodMes1_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodMes1.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.TxtCodMes1 : ope.txt2 = Me.TxtDesMes1
        ope.MostrarCodigoDescripcionDeTabla("Mes", "Meses", e)
    End Sub


    Private Sub TxtCodAux_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodAux.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.TxtCodAux : ope.txt2 = Me.TxtDesAux
        ope.MostrarCodigoDescripcionDeAuxiliar("Todos", "Auxiliares", e)
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

#Region "Habilitar Control"

    Sub HabilitarControlesEstadoAuxiliar()
        '/
        Dim AuxTodInd As String = Rbt.radioActivo(Me.gbAnaAux).Text
        'Habilitar los campos segun estado 
        Select Case AuxTodInd
            Case "Todas"
                Me.TxtCodAux.Enabled = False
                Me.TxtCodAux.Text = ""
                Me.TxtDesAux.Text = ""
            Case "Individual"
                Me.TxtCodAux.Enabled = True

        End Select
        '/
    End Sub

#End Region

    Private Sub rbtAnaTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtAnaTodos.CheckedChanged, rbtAnaIndividual.CheckedChanged
        Me.HabilitarControlesEstadoAuxiliar()
    End Sub
End Class