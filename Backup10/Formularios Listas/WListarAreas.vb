
Imports Entidad
Imports Negocio

Public Class WListarAreas
    Public lista As New List(Of SuperEntidad)
    Public ent, entpar As New SuperEntidad
    Dim AreRN As New AreaRN
    Dim par As New ParametroRN
    Public tabla As String
    Public titulo As String
    Public campoBusqueda As String
    Public txt1 As New TextBox
    Public txt2 As New TextBox
    Public cam As New CamposEntidad
    Public condicionlista As String

    Public ctrlFoco As New Control


#Region "Metodos"

    Sub NuevaVentana()

        '//
        Me.Show()

        ent.CampoOrden = cam.CodAre
        'En que columna se va a buscar por defecto -->Descripcion
        'Me.campoBusqueda = "Nombre Cuenta"
        Me.campoBusqueda = "Area"
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

            Case "Area"
                ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
                lista = AreRN.obtenerAreaExisXEmpresa(ent)

        End Select

        '/Refrescando el DataSource de DgvUsu
        Dgv.refrescarFuenteDatosGrilla(Me.DgvLista, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvLista, cam.CodAre, "Codigo", 75)
        Dgv.asignarColumnaText(Me.DgvLista, cam.NomAre, "Nombre", 250)
        Dgv.asignarColumnaTextVis(Me.DgvLista, cam.ClaAre, "Clave", 80, 0)

        '\\
    End Sub

    Sub DevolverDatos()

        If Me.DgvLista.Rows.Count = 0 Then
            Exit Sub
        Else
            'buscas en bd el codigo con su tipo de tabla
            Me.txt1.Text = Dgv.obtenerValorCelda(Me.DgvLista, cam.CodAre)
            ' Me.txt2.Text = ent.NombreMes
            Me.ctrlFoco.Focus()
            Me.Close()
        End If

    End Sub

#End Region

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
End Class