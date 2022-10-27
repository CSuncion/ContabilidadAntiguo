Imports CrystalDecisions.CrystalReports.Engine
Imports Entidad
Imports Negocio

Public Class WImpTablaCentroCosto
#Region "Propietarios"
    Public wCenCto As New WCentroCosto
#End Region

    Public ent, entCont, paren As New SuperEntidad
    Public lista, listarfc As New List(Of SuperEntidad)
    Public fccto As New CentroCostoRN
    'Public rcdc As New MovimientoContableCabeceraRN
    'Public rcdm As New MovimientoContableDetalleRN
    Public par As New ParametroRN
    Dim cam As New CamposEntidad
    Dim ds As New DataSet1
    Dim tb As New DataTable
    Dim cr As New CrRptCentroCosto
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
        paren = par.buscarParametroExis(paren)
        numerodigitos = paren.DigitosCuentaAnalitica
    End Sub

    Sub Imprimir()

        ds.FormatoContable.Clear()
        'Llenar Cabecera()
        empresa = CType(Me.cr.Section2.ReportObjects.Item("Empresa"), CrystalDecisions.CrystalReports.Engine.TextObject)
        empresa.Text = Me.txtNomEmp.Text

        ent.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        ent.CampoOrden = cam.CodCC
        'TRAER CENTRO COSTOS
        listarfc = fccto.obtenerCentroCostoExisXEmpresa(ent)

        For Each obj As SuperEntidad In listarfc

            Dim NewRow As DataSet1.FormatoContableRow
            NewRow = ds.FormatoContable.NewFormatoContableRow

            NewRow.CodigoFC = obj.CodigoCentroCosto
            NewRow.DescripcionFC = obj.NombreCentroCosto

            'AGREGANDO REGISTROS AL DATATABLE
            'LLENANDO EL REGISTRO
            'AÑADIR AL DS
            ds.FormatoContable.Rows.Add(NewRow)


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

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub crv1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles crv1.Load

    End Sub
End Class