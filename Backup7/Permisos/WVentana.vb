Imports Entidad
Imports Negocio

Public Class WVentana

      Public acc As New Accion
      Public lista As New List(Of SuperEntidad)
      Public ven As New VentanaRN
      Public cam As New CamposEntidad
      Public ent As New SuperEntidad
      '  Public tipoTabla As String
      Public titulo As String = "Ventana"


#Region "Metodos"

      Sub NuevaVentana()
            '//
            Me.Show()
            ent.CampoOrden = cam.CodVen
            ent.ColumnaBusqueda = "Codigo"
            Me.ActualizarVentana()
            '\\
      End Sub


      Sub ActualizarVentana()
            '//
            Me.ActualizarDgvVen()
            Dgv.actualizarBarraEstado(Me.sst1, Me.DgvVen)
            acc.EstadoBotonesPorGrilla(Me.ListaBotones, Me.DgvVen)
            acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvVen)
            Dgv.pintarColumnaDgv(Me.DgvVen, ent.CampoOrden)
            '      Me.permisoVentana()
            '\\
      End Sub

      Sub ActualizarDgvVen()

            '//
            '/Refrescando el DataSource de DgvUsu
            lista = ven.obtenerVentanaExis(ent)

            '/Refrescando el DataSource de DgvUsu
            Dgv.refrescarFuenteDatosGrilla(Me.DgvVen, lista)
            '/Creando las columnas
            Dgv.asignarColumnaText(Me.DgvVen, cam.CodVen, "Codigo", 120)
            Dgv.asignarColumnaText(Me.DgvVen, cam.NomVen, "Nombre", 284)
            'Dgv.asignarColumnaText(Me.DgvDis, cam.EstReg, "Estado", 100)

            '//
      End Sub

      Sub buscar()
            '//
            Dim win As New WBuscar
            win.WVen = Me
            win.titulo = Me.titulo
            Me.AddOwnedForm(win)
            win.ventanaBuscar(ent.ColumnaBusqueda)
            '\\
      End Sub

      Sub adicionar()
            '//
            Dim win As New WEditarVentana
            win.wVen = Me
            win.operacion = 0
            Me.AddOwnedForm(win)
            win.ventanaAdicionar()
            '\\
      End Sub

      Sub modificar()
            '//
            Dim win As New WEditarVentana
            win.wVen = Me
            win.operacion = 1
            Me.AddOwnedForm(win)
            '/Obtener el codigo de usuario
            Dim cod As String = Dgv.obtenerValorCelda(Me.DgvVen, cam.CodVen)
            win.ventanaModificar(cod)
            '\\
      End Sub

      Sub eliminar()
            '//
            Dim win As New WEditarVentana
            win.wVen = Me
            win.operacion = 2
            Me.AddOwnedForm(win)
            '/Obtener el codigo de usuario
            Dim cod As String = Dgv.obtenerValorCelda(Me.DgvVen, cam.CodVen)
            win.ventanaEliminar(cod)
            '\\
      End Sub

      Sub Visualizar()
            '//
            Dim win As New WEditarVentana
            win.wVen = Me
            win.operacion = 3
            Me.AddOwnedForm(win)
            '/Obtener el codigo de usuario
            Dim cod As String = Dgv.obtenerValorCelda(Me.DgvVen, cam.CodVen)
            win.ventanaVisualizar(cod)
            '\\
      End Sub

#End Region


      Private Sub btnActualizarTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarTabla.Click
            Me.ActualizarVentana()
      End Sub

      Private Sub DgvDis_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvVen.CellEnter
            acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvVen)
      End Sub

      Private Sub DgvDis_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvVen.ColumnHeaderMouseClick
            ent.CampoOrden = Me.DgvVen.Columns(e.ColumnIndex).Name
            ent.ColumnaBusqueda = Me.DgvVen.Columns(e.ColumnIndex).HeaderText
            Me.ActualizarVentana()
      End Sub

      Private Sub btnDesplaza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrimero.Click, btnAnterior.Click, btnSiguiente.Click, btnUltimo.Click
            Dgv.desplazamientoFila(Me.DgvVen, CType(sender, ToolStripButton))
      End Sub

      Private Sub btnRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
            Me.Close()
      End Sub

      Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
            Me.buscar()
      End Sub

      Private Sub btnAdicionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdicionar.Click
            Me.adicionar()
      End Sub

      Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
            Me.modificar()
      End Sub

      Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
            Me.eliminar()
      End Sub

      Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
            '            Me.imprimir()
      End Sub

      Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
            Me.Visualizar()
      End Sub

      Private Sub btnRecycla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecycla.Click
            ' Me.recycla()
      End Sub


      Private Sub btnOpciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpciones.Click
            Dim win As New WDetalleVentana
            Dim cod As String = Dgv.obtenerValorCelda(Me.DgvVen, cam.CodVen)
            win.NuevaVentana(cod)
      End Sub
End Class