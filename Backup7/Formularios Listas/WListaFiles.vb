Imports Entidad
Imports Negocio
Public Class WListaFiles

    Public lista As New List(Of SuperEntidad)
    Public ent As New SuperEntidad
    Public fil As New FilesRN
    Public titulo As String
    Public CondicionLista As String
    Public campoBusqueda As String
    Public txt1 As New TextBox
    Public txt2 As New TextBox
    Public txt3 As New TextBox
    Public cam As New CamposEntidad
    Public ctrlFoco As New Control

#Region "Metodos"

    Sub NuevaVentana()
        '//
        Me.Show()
        'orden de la grilla por defecto -->Descripcion
        ent.CampoOrden = cam.NomFil
        'En que columna se va a buscar por defecto -->Descripcion
        Me.campoBusqueda = "Descripcion"
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
        ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa

        Select Case Me.CondicionLista
            Case "ListarFilesXOrigen"
                lista = fil.ListarFilesXOrigen(ent)
            Case "ListarFilesTodos"
                lista = fil.ListarFilesTodos(ent)
        End Select

        '/Refrescando el DataSource de DgvUsu
        Dgv.refrescarFuenteDatosGrilla(Me.DgvLista, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvLista, cam.CodFilRC, "Codigo", 90)
        Dgv.asignarColumnaText(Me.DgvLista, cam.NomFil, "Descripcion", 210)
        '\\
    End Sub

    Sub DevolverDatos()
        If Me.DgvLista.Rows.Count = 0 Then
            Exit Sub
        Else
            'buscas en bd el personal
            ent.ClaveFile = SuperEntidad.xCodigoEmpresa + Dgv.obtenerValorCelda(Me.DgvLista, 0)
            ent = fil.buscarFilesExisPorClave(ent)
            Me.txt1.Text = ent.CodigoFile
            Me.txt2.Text = ent.NombreFile
            'Me.txt3.Text = ent.CodigoGrupo
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