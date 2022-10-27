Imports CrystalDecisions.CrystalReports.Engine
Imports Entidad
Imports Negocio

Public Class WImpGanaePerdXNat
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
    Dim cr As New CrGananciaPerdida
    Dim acc As New Accion
    Dim numerodigitos As String
    Dim dia, mes, mes1, ano, empresa, empresa1, ruc, estado As CrystalDecisions.CrystalReports.Engine.TextObject

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

        ds.GananciaPerdida.Clear()

        'Llenar Cabecera()
        empresa = CType(Me.cr.Section2.ReportObjects.Item("Empresa"), CrystalDecisions.CrystalReports.Engine.TextObject)
        empresa.Text = Me.txtNomEmp.Text

        ruc = CType(Me.cr.Section2.ReportObjects.Item("ruc"), CrystalDecisions.CrystalReports.Engine.TextObject)
        ruc.Text = SuperEntidad.xRucEmpresa

        empresa1 = CType(Me.cr.Section2.ReportObjects.Item("Empresa1"), CrystalDecisions.CrystalReports.Engine.TextObject)
        empresa1.Text = Me.txtNomEmp.Text

        dia = CType(Me.cr.Section2.ReportObjects.Item("dia"), CrystalDecisions.CrystalReports.Engine.TextObject)
        Dim fecha As Date
        Dim dia1 As Integer = CType(Me.txtCodMes.Text, Integer)
        If dia1 = 12 Then
            dia.Text = "31"
        Else
            dia1 += 1
            fecha = CType("01/" & (dia1) & "/" & Me.txtAno.Text, Date)
            fecha = fecha.AddDays(-1)
            dia.Text = fecha.Day.ToString.PadLeft(2, CType("0", Char))
        End If
        mes = CType(Me.cr.Section2.ReportObjects.Item("Mes"), CrystalDecisions.CrystalReports.Engine.TextObject)
        mes.Text = Me.txtDesMes.Text


        ano = CType(Me.cr.Section2.ReportObjects.Item("Ano"), CrystalDecisions.CrystalReports.Engine.TextObject)
        ano.Text = Me.txtAno.Text

        estado = CType(Me.cr.Section2.ReportObjects.Item("estado"), CrystalDecisions.CrystalReports.Engine.TextObject)
        estado.Text = "( POR NATURALEZA )"

        '' Traer saldos por ano 
        Dim lis As New List(Of Reportes.EstadoFinanciero)
        Dim objsal As New SuperEntidad
        objsal.PeriodoRegContabCabe = Me.txtAno.Text.Trim
        objsal.CodigoMes = Me.txtCodMes.Text.Trim
        lis = sc.ObtenerGananciaPerdidaXNaturaleza(objsal)

        For Each obj As Reportes.EstadoFinanciero In lis

            Dim NewRow As DataSet1.GananciaPerdidaRow
            NewRow = ds.GananciaPerdida.NewGananciaPerdidaRow

            NewRow.Codigo = obj.codigo
            NewRow.Nombre = obj.nombre

            If obj.codigo = "" Then
                ' NewRow.MontoMes = obj.strmontomes
                If obj.nombre = "" Then
                    NewRow.MontoMes = obj.strmontomes
                    NewRow.MontoAcumulado = obj.strmontoacumulado
                Else
                    If obj.strmontomes = "" Then
                        NewRow.MontoMes = obj.strmontomes
                        NewRow.MontoAcumulado = obj.strmontoacumulado
                    Else
                        If obj.montomes < 0 Then
                            NewRow.MontoMes = "(" + Varios.numeroConDosDecimal(Math.Abs(obj.montomes).ToString) + ")"
                            NewRow.MontoAcumulado = "(" + Varios.numeroConDosDecimal(Math.Abs(obj.montoacumulado).ToString) + ")"
                        Else
                            NewRow.MontoMes = Varios.numeroConDosDecimal(obj.strmontomes)
                            NewRow.MontoAcumulado = Varios.numeroConDosDecimal(obj.strmontoacumulado)
                        End If
                    End If

                End If
            Else
                If obj.montomes < 0 Then
                    NewRow.MontoMes = "(" + Varios.numeroConDosDecimal(Math.Abs(obj.montomes).ToString) + ")"
                    NewRow.MontoAcumulado = "(" + Varios.numeroConDosDecimal(Math.Abs(obj.montoacumulado).ToString) + ")"
                Else
                    NewRow.MontoMes = Varios.numeroConDosDecimal(obj.strmontomes)
                    NewRow.MontoAcumulado = Varios.numeroConDosDecimal(obj.strmontoacumulado)
                End If
            End If

            'AGREGANDO REGISTROS AL DATATABLE
            'LLENANDO EL REGISTRO
            'AÑADIR AL DS
            ds.GananciaPerdida.Rows.Add(NewRow)

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

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class