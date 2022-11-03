Option Strict Off
Imports CrystalDecisions.CrystalReports.Engine
Imports Entidad
Imports Negocio


Public Class WImpBalanceGeneral
#Region "Propietarios"
    Public wRh As New WRegistroHonorario
#End Region

    Public ent, entCont, paren As New SuperEntidad
    Public lista, listarrc As New List(Of SuperEntidad)
    Public sc As New SaldoContableRN
    Public par As New ParametroRN
    Dim cam As New CamposEntidad
    Dim ds, ds1 As New DataSet1

    Dim tb As New DataTable
    Dim cr As New CrBalanceGeneralTotal
    Dim cr1 As New CrImpBalanceGeneral1
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

        ds.GananciaPerdidaTotal.Clear()

        ''Llenar Cabecera()
        empresa = CType(Me.cr.Section2.ReportObjects.Item("Empresa"), CrystalDecisions.CrystalReports.Engine.TextObject)
        empresa.Text = Me.txtNomEmp.Text

        ruc = CType(Me.cr.Section2.ReportObjects.Item("ruc"), CrystalDecisions.CrystalReports.Engine.TextObject)
        ruc.Text = SuperEntidad.xRucEmpresa

        'empresa1 = CType(Me.cr.Section2.ReportObjects.Item("Empresa1"), CrystalDecisions.CrystalReports.Engine.TextObject)
        'empresa1.Text = Me.txtNomEmp.Text

        'dia = CType(Me.cr.Section2.ReportObjects.Item("dia"), CrystalDecisions.CrystalReports.Engine.TextObject)
        ''dia.Text = "31"

        dia = CType(Me.cr.Section2.ReportObjects.Item("dia"), CrystalDecisions.CrystalReports.Engine.TextObject)
        Dim fecha As Date
        Dim dia1 As Integer = CType(Me.txtCodMes.Text, Integer)
        If dia1 = 12 Or dia1 = 13 Then
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

        'estado = CType(Me.cr.Section2.ReportObjects.Item("estado"), CrystalDecisions.CrystalReports.Engine.TextObject)
        'estado.Text = "( ACTIVO )"

        '' Traer saldos por ano
        Dim iForConRN As New FormatoContableRN
        Dim iForCon As New SuperEntidad
        iForCon.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        iForCon.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        Dim iLis As List(Of List(Of SuperEntidad)) = iForConRN.ObtenerReporteBalanceGeneral(iForCon)

        Dim iLisAct As List(Of SuperEntidad) = iLis.Item(0)
        Dim iLisPas As List(Of SuperEntidad) = iLis.Item(1)
        Dim iLisTot As List(Of SuperEntidad) = iLis.Item(2)

        Dim iNumAct As Integer = iLisAct.Count
        Dim iNumPas As Integer = iLisPas.Count
        Dim iNomas As String = ""

        If iNumAct > iNumPas Then
            iNomas = "Activo"
        Else
            iNomas = "Pasivo"
        End If

        If iNomas = "Activo" Then
            For n As Integer = 0 To iNumAct - 1
                Dim NewRow As DataSet1.GananciaPerdidaTotalRow
                NewRow = ds.GananciaPerdidaTotal.NewGananciaPerdidaTotalRow
                NewRow.Codigo = ""
                NewRow.Nombre = iLisAct.Item(n).DescripcionFormatoContable
                NewRow.MontoMes = iLisAct.Item(n).DatoCondicion1
                NewRow.MontoAcumulado = iLisAct.Item(n).DatoCondicion2

                If n <= iNumPas - 1 Then
                    NewRow.Codigo1 = ""
                    NewRow.Nombre1 = iLisPas.Item(n).DescripcionFormatoContable
                    NewRow.MontoMes1 = iLisPas.Item(n).DatoCondicion1
                    NewRow.MontoAcumulado1 = iLisPas.Item(n).DatoCondicion2
                End If
                ds.GananciaPerdidaTotal.Rows.Add(NewRow)
            Next
        Else
            For n As Integer = 0 To iNumPas - 1
                Dim NewRow As DataSet1.GananciaPerdidaTotalRow
                NewRow = ds.GananciaPerdidaTotal.NewGananciaPerdidaTotalRow
                NewRow.Codigo1 = ""
                NewRow.Nombre1 = iLisPas.Item(n).DescripcionFormatoContable
                NewRow.MontoMes1 = iLisPas.Item(n).DatoCondicion1
                NewRow.MontoAcumulado1 = iLisPas.Item(n).DatoCondicion2
                If n <= iNumAct - 1 Then
                    NewRow.Codigo = ""
                    NewRow.Nombre = iLisAct.Item(n).DescripcionFormatoContable
                    NewRow.MontoMes = iLisAct.Item(n).DatoCondicion1
                    NewRow.MontoAcumulado = iLisAct.Item(n).DatoCondicion2
                End If
                ds.GananciaPerdidaTotal.Rows.Add(NewRow)
            Next
        End If

        'insertando la linea de los totales
        Dim NewRow1 As DataSet1.GananciaPerdidaTotalRow
        NewRow1 = ds.GananciaPerdidaTotal.NewGananciaPerdidaTotalRow
        NewRow1.Codigo = ""
        NewRow1.Nombre = ""
        NewRow1.MontoMes = iLisTot.Item(0).DatoCondicion1
        NewRow1.MontoAcumulado = iLisTot.Item(0).DatoCondicion2
        NewRow1.Codigo1 = ""
        NewRow1.Nombre1 = ""
        NewRow1.MontoMes1 = iLisTot.Item(0).DatoCondicion1
        NewRow1.MontoAcumulado1 = iLisTot.Item(0).DatoCondicion2
        ds.GananciaPerdidaTotal.Rows.Add(NewRow1)

        'montos totales
        NewRow1 = ds.GananciaPerdidaTotal.NewGananciaPerdidaTotalRow
        NewRow1.Codigo = ""
        NewRow1.Nombre = iLisTot.Item(1).DescripcionFormatoContable
        NewRow1.MontoMes = iLisTot.Item(1).DatoCondicion1
        NewRow1.MontoAcumulado = iLisTot.Item(1).DatoCondicion2
        NewRow1.Codigo1 = ""
        NewRow1.Nombre1 = iLisTot.Item(2).DescripcionFormatoContable
        NewRow1.MontoMes1 = iLisTot.Item(2).DatoCondicion1
        NewRow1.MontoAcumulado1 = iLisTot.Item(2).DatoCondicion2
        ds.GananciaPerdidaTotal.Rows.Add(NewRow1)

        'insertando la linea final de los totales
        NewRow1 = ds.GananciaPerdidaTotal.NewGananciaPerdidaTotalRow
        NewRow1.Codigo = ""
        NewRow1.Nombre = ""
        NewRow1.MontoMes = iLisTot.Item(0).DatoCondicion1
        NewRow1.MontoAcumulado = iLisTot.Item(0).DatoCondicion2
        NewRow1.Codigo1 = ""
        NewRow1.Nombre1 = ""
        NewRow1.MontoMes1 = iLisTot.Item(0).DatoCondicion1
        NewRow1.MontoAcumulado1 = iLisTot.Item(0).DatoCondicion2
        ds.GananciaPerdidaTotal.Rows.Add(NewRow1)


        cr.SetDataSource(ds)
        'Cargamos en nuestro formulario el cr
        Me.crv1.ReportSource = cr
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