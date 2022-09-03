Imports Entidad
Imports Negocio
Public Class WListarPOX
    Public lista As New List(Of SuperEntidad)
    Public ent As New SuperEntidad
    Public pro As New ProyectoRN
    Public titulo As String
    Public CondicionLista As String
    Public campoBusqueda As String
    Public txt1 As New TextBox
    Public txt2 As New TextBox
    Public txt3 As New TextBox
    Public txt4 As New TextBox
    Public txt5 As New TextBox
    Public txt6 As New TextBox
    Public txt7 As New TextBox
    Public txt8 As New TextBox
    Public txt9 As New TextBox
    Public cam As New CamposEntidad
    Public ctrlFoco As Control

#Region "Metodos"

    Sub NuevaVentana()
        '//
        Me.Show()
        'orden de la grilla por defecto -->Descripcion
        ent.CampoOrden = cam.CodProHij
        'En que columna se va a buscar por defecto -->Descripcion
        Me.campoBusqueda = "Codigo"
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
        Select Case Me.CondicionLista
            Case "OfertaSinGenera"

                lista = pro.obtenerOfertasExisActSinGenerar(ent)
            Case "ProyectoSinGenera"
                lista = pro.obtenerProyectosExisActSinGenerar(ent)

            Case "ProyectoConGenera"
                lista = pro.obtenerProyectosExisActConGenerar(ent)

            Case "ProyectoTodos"
                lista = pro.obtenerProyectoExisAct(ent)

            Case "SoloProyectoActivos"
                lista = pro.obtenerSoloProyectoExisAct(ent)

            Case "Proyectos"
                ent.TipoProHijo = "P"
                lista = pro.obtenerProyectosExisActXTipo(ent)
            Case "Ofertas"
                ent.TipoProHijo = "O"
                lista = pro.obtenerProyectosExisActXTipo(ent)
            Case "Administrativos"
                ent.TipoProHijo = "A"
                lista = pro.obtenerProyectosExisActXTipo(ent)
            Case "SIG"
                ent.TipoProHijo = "C"
                lista = pro.obtenerProyectosExisActXTipo(ent)
            Case "Otros"
                ent.TipoProHijo = "N"
                lista = pro.obtenerProyectosExisActXTipo(ent)
            Case "SoloProyectosYOfertas"
                lista = pro.ListarSoloProyectosYOfertasActivas(ent)
        End Select

        '/Refrescando el DataSource de DgvUsu
        Dgv.refrescarFuenteDatosGrilla(Me.DgvLista, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvLista, cam.CodProHij, "Codigo", 80)
        Dgv.asignarColumnaText(Me.DgvLista, cam.DesProHij, "Descripcion", 390)

        '\\
    End Sub

    Sub DevolverDatos()
        If Me.DgvLista.Rows.Count = 0 Then
            Exit Sub
        Else
            'buscas en bd el personal
            ent.DatoCondicion1 = Dgv.obtenerValorCelda(Me.DgvLista, 0)
            ent = pro.buscarProyectoExisPorCodigo(ent)
            Me.txt1.Text = ent.CodigoProHijo
            Me.txt2.Text = ent.DescripcionProHijo
            Me.txt3.Text = ent.CodigoAuxiliar
            Me.txt4.Text = ent.DescripcionAuxiliar
            Me.txt5.Text = ent.CodigoSegmento
            Me.txt6.Text = ent.NombreSegmento
            Me.txt7.Text = ent.CodigoArea
            Me.txt8.Text = ent.NombreArea
            Me.txt9.Text = ent.TipoProHijo
            Me.ctrlFoco.Focus()
            'Me.txt1.Focus()
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