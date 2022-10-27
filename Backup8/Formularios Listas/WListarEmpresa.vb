Imports Entidad
Imports Negocio

Public Class WListarEmpresa
    Public lista As New List(Of SuperEntidad)
    Public ent As New SuperEntidad
    Dim emp As New EmpresaRN
    Public tabla As String
    Public titulo As String
    Public campoBusqueda As String
    Public txt1 As New TextBox
    Public txt2 As New TextBox
    Public txt3 As New TextBox
    Public txt4 As New TextBox
    Public cam As New CamposEntidad

    Public ctrlFoco As New Control

#Region "Metodos"

    Sub NuevaVentana()
        '//
        Me.Show()
        'orden de la grilla por defecto -->Descripcion
        ent.CampoOrden = cam.RazSocEmp
        'En que columna se va a buscar por defecto -->Descripcion
        Me.campoBusqueda = "Nombre Empresa"
        Me.Text = "Listado de " + Me.titulo
        Me.ActualizarVentana()
        '\\
    End Sub

    Sub ActualizarVentana()
        Me.gbBus.Text = "Criterio de busqueda/Por :" + Me.campoBusqueda
        Me.ActualizarDgvLista()
        Dgv.pintarColumnaDgv(Me.DgvLista, ent.CampoOrden)
    End Sub

    Sub ActualizarDgvLista()
        '//

        Select Case Me.tabla
            Case "Todos"
                'ent.DatoCondicion1 = "Cuenta"
                lista = emp.obtenerEmpresaExis(ent)

        End Select
        ''/Cargamos la tabla con el filtro del tipo de tabla
        ''If Me.tabla <> "Todos" Then
        'lista = pcge.obtenerCuentaExis(ent)
        ''End If

        '/Refrescando el DataSource de DgvUsu
        Dgv.refrescarFuenteDatosGrilla(Me.DgvLista, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvLista, cam.CodEmp, "Codigo", 90)
        Dgv.asignarColumnaText(Me.DgvLista, cam.RazSocEmp, "Nombre Empresa", 300)

        '\\
    End Sub

    Sub DevolverDatos()
        If Me.DgvLista.Rows.Count = 0 Then
            Exit Sub
        Else
            'buscas en bd el codigo con su tipo de tabla
            'If Me.tabla = "Todos" Then
            ent.CodigoEmpresa = Dgv.obtenerValorCelda(Me.DgvLista, 0)
            ent = emp.buscarEmpresaExisPorCodigo(ent)
            'Else
            'ent.DatoCondicion2 = Dgv.obtenerValorCelda(Me.DgvLista, 0)
            'ent = aux.buscarAuxiliarExisActPorCodigoYTipoAux(ent)
        End If

        Me.txt1.Text = ent.CodigoEmpresa
        Me.txt2.Text = ent.RazonSocialEmpresa
        Me.txt3.Text = ent.PeriodoEmpresa
        'Me.txt1.Focus()
        Me.ctrlFoco.Focus()
        Me.Close()
        'End If

    End Sub

    Private Sub btnSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeleccionar.Click
        Me.DevolverDatos()
    End Sub

    Private Sub txtBus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBus.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Me.DevolverDatos()
        End If
    End Sub


    Private Sub txtBus_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBus.KeyUp
        Dgv.BusquedaInteligenteEnColumna(Me.DgvLista, ent.CampoOrden, Me.txtBus, e)
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub DgvLista_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvLista.CellDoubleClick
        Me.DevolverDatos()
    End Sub


    Private Sub DgvDis_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvLista.ColumnHeaderMouseClick
        ent.CampoOrden = Me.DgvLista.Columns(e.ColumnIndex).Name
        Me.campoBusqueda = Me.DgvLista.Columns(e.ColumnIndex).HeaderText
        Me.ActualizarVentana()
    End Sub

    Private Sub WListarPcge_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
#End Region

End Class