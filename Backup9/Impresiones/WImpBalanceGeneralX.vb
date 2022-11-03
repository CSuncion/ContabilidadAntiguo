Option Strict Off
Imports CrystalDecisions.CrystalReports.Engine
Imports Entidad
Imports Negocio

Public Class WImpBalanceGeneralX
#Region "Propietarios"
    Public wfcon As New WFormatoContable
#End Region



    Public ent, entCont, paren As New SuperEntidad
    Public lista, listarfc As New List(Of SuperEntidad)
    Public fcon As New FormatoContableRN
    Public rcdc As New MovimientoContableCabeceraRN
    Public rcdm As New MovimientoContableDetalleRN
    Public par As New ParametroRN
    Dim cam As New CamposEntidad
    Dim ds As New DataSet1
    Dim tb As New DataTable
    Dim cr As New CrImpBalanceGeneral
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
        'acc.Nuevo()
    End Sub

    Sub PorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.txtNomEmp.Text = SuperEntidad.xRazonSocial
        'Me.txtAno.Text = SuperEntidad.xPeriodoEmpresa.Substring(0, 4)
        paren = par.buscarParametroExis(paren)
        numerodigitos = paren.DigitosCuentaAnalitica
    End Sub

    Sub Imprimir()

        ds.BalanceGeneral.Clear()
        'Llenar Cabecera()
        'empresa = CType(Me.cr.Section2.ReportObjects.Item("Empresa"), CrystalDecisions.CrystalReports.Engine.TextObject)
        'empresa.Text = Me.txtNomEmp.Text


        ent.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        ent.CampoOrden = cam.CodForCon
        'Listar Pasivos
        Dim lispas As New List(Of SuperEntidad)
        lispas = fcon.ListarFormatoPasivoConBlanco(ent)
        'Listar Activos
        Dim lisact As New List(Of SuperEntidad)
        lisact = fcon.ListarFormatoActivoConBlanco(ent)

        'Ultima linea del Activo
        Dim ul As Integer = lisact.Count - 1

        Dim ultact As String = ""
        Dim monact As Decimal = 0

        For n As Integer = 0 To lispas.Count - 1


            Dim NewRow As DataSet1.BalanceGeneralRow
            NewRow = ds.BalanceGeneral.NewBalanceGeneralRow

            If ul - 1 >= n Then
                NewRow.NombreActivo = lisact.Item(n).DescripcionFormatoContable
                NewRow.MontoActivo = 0
                'Else
                'NewRow.NombreActivo = ""
                'NewRow.MontoActivo = ""
            End If

            If ul = n Then
                ultact = lisact.Item(n).DescripcionFormatoContable
                monact = 0
            End If

            If n = lispas.Count - 1 Then
                NewRow.NombreActivo = ultact
                NewRow.MontoActivo = monact
            End If

            NewRow.NombrePasivo = lispas.Item(n).DescripcionFormatoContable
            NewRow.MontoPasivo = 0


            If NewRow.NombreActivo = "" Then
                NewRow.MontoActivo = ""
            End If

            If NewRow.NombrePasivo = "" Then
                NewRow.MontoPasivo = ""
            End If

            ds.BalanceGeneral.Rows.Add(NewRow)


        Next

        cr.SetDataSource(ds)
        'Cargamos en nuestro formulario el cr
        Me.crv1.ReportSource = cr
        'Dim win As New wImpParaEnvio
        'win.NuevaVentana(ds)
        '/
    End Sub

#Region "Mostrar Form Lista"
#End Region
#Region "Buscar Por Codigo"

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