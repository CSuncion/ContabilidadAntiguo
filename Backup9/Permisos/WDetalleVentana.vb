Imports Entidad
Imports Negocio

Public Class WDetalleVentana

      Public acc As New Accion
    Public lisOpc As New List(Of SuperEntidad)
    Public vo As New VentanaOpcionRN
      Public ven As New VentanaRN
      Public opc As New OpcionRN
      Public cam As New CamposEntidad
      Public ent As New SuperEntidad
      'Public tipoTabla As String
      Public titulo As String = "Opcion"

#Region "Metodos"

      Sub NuevaVentana(ByVal codVen As String)
            'DESHABILITAR AL PROPIETARIO ACTUAL
            'Me.Owner.Enabled = False
            'MOSTRAR VALORES POR DEFECTO
            Me.ValoresPorDefecto(codVen)
            'ACTUALIZAR VENTANA
            Me.ActualizarVentana()
            'VER VENTANA
            Me.Show()
            '/
      End Sub

      Sub ValoresPorDefecto(ByVal codVen As String)
            Dim oVen As New SuperEntidad
            oVen.CodigoVentana = codVen
            oVen = ven.buscarVentanaExisPorCodigo(oVen)
            Me.txtCod.Text = oVen.CodigoVentana
            Me.txtNom.Text = oVen.NombreVentana
      End Sub

      Sub ActualizarDgvOpc()
            'TRAER TODAS LAS OPCIONES DE ESTA VENTANA
            Dim oOpc As New SuperEntidad
            oOpc.CodigoVentana = Me.txtCod.Text.Trim
            oOpc.CampoOrden = cam.CodOpc
            lisOpc = vo.obtenerVentanaOpcionesExisXVentana(oOpc)
            '/Refrescando el DataSource de DgvUsu
            Dgv.refrescarFuenteDatosGrilla(Me.DgvOpc, lisOpc)
            '/Creando las columnas
            Dgv.asignarColumnaText(Me.DgvOpc, cam.CodOpc, "Codigo", 90)
            Dgv.asignarColumnaText(Me.DgvOpc, cam.NomOpc, "Nombre", 290)
      End Sub

      Sub HabilitarBotonQuitar()
            Dim nR As Integer = Me.DgvOpc.Rows.Count
            If nR = 0 Then
                  Me.btnQuitar.Enabled = False
            Else
                  Me.btnQuitar.Enabled = True
            End If
      End Sub

      Sub ActualizarVentana()
            Me.ActualizarDgvOpc()
            Me.HabilitarBotonQuitar()
      End Sub

      Sub Agregar()
            Dim win As New WDetalleItemOpcion
            win.wDeV = Me
            Me.AddOwnedForm(win)
            win.operacion = 0
            win.ventana = Me.txtCod.Text.Trim
            win.ventanaAdicionar()
      End Sub

      Sub Quitar()
            Dim win As New WDetalleItemOpcion
            win.wDeV = Me
            Me.AddOwnedForm(win)
            win.ventana = Me.txtCod.Text.Trim
            win.operacion = 2
            '/Obtener el codigo de usuario
            Dim cod As String = Dgv.obtenerValorCelda(Me.DgvOpc, cam.CodOpc)
            win.ventanaEliminar(cod)
      End Sub


#End Region


      Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
            Me.Agregar()
      End Sub

      Private Sub btnQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitar.Click
            Me.Quitar()
      End Sub

      Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
            Me.Close()
      End Sub
End Class