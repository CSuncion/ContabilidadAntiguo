Imports Entidad
Imports Negocio

Public Class WListarOpciones

      Public lista As New List(Of SuperEntidad)
      Public ent As New SuperEntidad
      Public opc As New OpcionRN
      Public tituloWin As String
      Public CondicionLista As String
      Public campoBusqueda As String
      Public txt1 As New TextBox
      Public txt2 As New TextBox
      Public txt3 As New TextBox
      Public ctrlFoco As New Control
      Public cam As New CamposEntidad


#Region "Metodos"

      Sub NuevaVentana()
            '//
            Me.Show()
            'orden de la grilla por defecto -->Descripcion
            ent.CampoOrden = cam.NomOpc
            'En que columna se va a buscar por defecto -->Descripcion
            Me.campoBusqueda = "Descripcion"
            Me.Text = "Listado de " + Me.tituloWin
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
                  Case "Todos"
                        lista = opc.obtenerOpcionesExis(ent)
                  Case "PersonalActivo"
                        'lista = per.obtenerPersonalesExisAct(ent)
            End Select

            '/Refrescando el DataSource de DgvUsu
            Dgv.refrescarFuenteDatosGrilla(Me.DgvLista, lista)
            '/Creando las columnas
            Dgv.asignarColumnaText(Me.DgvLista, cam.CodOpc, "Codigo", 80)
            Dgv.asignarColumnaText(Me.DgvLista, cam.NomOpc, "Descripcion", 150)
            '\\
      End Sub

      Sub DevolverDatos()
            If Me.DgvLista.Rows.Count = 0 Then
                  Exit Sub
            Else
                  'buscas en bd el personal
                  ent.CodigoOpcion = Dgv.obtenerValorCelda(Me.DgvLista, cam.CodOpc)
                  ent = opc.buscarOpcionExisPorCodigo(ent)
                  Me.txt1.Text = ent.CodigoOpcion
                  Me.txt2.Text = ent.NombreOpcion
                  'Me.txt3.Text = ent.CodigoGrupo
                  'Me.txt1.Focus()

                  Me.Close()
                  Me.ctrlFoco.Focus()
                  Me.ctrlFoco.Focus()
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