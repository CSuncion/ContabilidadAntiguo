Imports Entidad
Imports Negocio

Public Class WAsignarCuentas
#Region "Propietarios"
      Public wEmp As New WEmpresa
#End Region

      Public listaPc, listaPcE As New List(Of SuperEntidad)
      Public cue As New PlanDeCuentasRN
      Public emp As New EmpresaRN
    Public empCue As New PlanCuentaGeRN
      Public cam As New CamposEntidad
      Public ent As New SuperEntidad
      Public titulo As String = "PlanDeCuentas"
      Public cemp As String
      Dim regActual As Integer = 0

#Region "Metodos"

      Sub valoresPorDefecto(ByRef CodEmp As String)
            Dim entEmp As New SuperEntidad
            entEmp.CodigoEmpresa = CodEmp
            entEmp = emp.buscarEmpresaExisPorCodigo(entEmp)
            Me.txtCodEmp.Text = entEmp.CodigoEmpresa
            Me.txtNomEmp.Text = entEmp.RazonSocialEmpresa
      End Sub

      Sub NuevaVentana(ByVal CodEmp As String)
            '//
            Me.Owner.Enabled = False
            Me.Show()
            'visualiza el formulario
            cemp = CodEmp
            Me.valoresPorDefecto(cemp)
            Me.ActualizarDgvCueGen()
            Me.ActualizarDgvCueEmp()
            Me.HabilitarBotonesAgregar()
            Me.HabilitarBotonesQuitar()
            '\\
      End Sub

      Sub ActualizarDgvCueGen()
            '//
            '/Refrescando el DataSource de DgvUsu
            ent.CodigoEmpresa = cemp
            listaPc = cue.ObtenerCuentasDisponiblesPorEmpresa(ent)

            '/Refrescando el DataSource de DgvUsu
            Dgv.refrescarFuenteDatosGrilla(Me.DgvCueGen, listaPc)
            '/Creando las columnas
            Dgv.asignarColumnaText(Me.DgvCueGen, cam.CodCtaPcge, "Codigo", 70)
            Dgv.asignarColumnaText(Me.DgvCueGen, cam.NomCtaPcge, "Nombre", 360)
            '//
      End Sub

      Sub ActualizarDgvCueEmp()
            '/Refrescando el DataSource de DgvUsu
            ent.CodigoEmpresa = cemp
            ent.CampoOrden = cam.CodCtaPcge
            listaPcE = empCue.obtenerCuentaExisPorEmpresa(ent)

            '/Refrescando el DataSource de DgvUsu
            Dgv.refrescarFuenteDatosGrilla(Me.DgvCueEmp, listaPcE)
            '/Creando las columnas
            Dgv.asignarColumnaText(Me.DgvCueEmp, cam.CodCtaPcge, "Codigo", 70)
            Dgv.asignarColumnaText(Me.DgvCueEmp, cam.NomCtaPcge, "Nombre", 360)
            '//
      End Sub

      Sub HabilitarBotonesAgregar()
            Dim nr As Integer = Me.DgvCueGen.Rows.Count
            If nr = 0 Then
                  Me.BtnAgrega.Enabled = False
                  Me.BtnAgregaTodos.Enabled = False
            Else
                  Me.BtnAgrega.Enabled = True
                  Me.BtnAgregaTodos.Enabled = True
            End If
      End Sub

      Sub HabilitarBotonesQuitar()
            Dim nr As Integer = Me.DgvCueEmp.Rows.Count
            If nr = 0 Then
                  Me.BtnQuita.Enabled = False
                  Me.BtnQuitarTodos.Enabled = False
            Else
                  Me.BtnQuita.Enabled = True
                  Me.BtnQuitarTodos.Enabled = True
            End If
      End Sub

      Function PermitirQuitarCuenta() As Boolean
            Dim cod As String = Dgv.obtenerValorCelda(Me.DgvCueEmp, cam.CodCtaPcge)
            Dim entCue As New SuperEntidad
            entCue.CodigoCuentaPcge = cod
            If cue.existePlanDeCuentasPorCodigo(entCue) = False Then
                  Return False
            Else
                  Return True
            End If
      End Function

      Sub MantenerIndiceFilaDgv(ByRef wdgv As DataGridView)
            Dim nr As Integer = wdgv.Rows.Count

            If nr <> 0 Then
                  If Me.regActual >= nr Then
                        wdgv.CurrentCell = wdgv.Item(0, nr - 1)
                  Else
                        wdgv.CurrentCell = wdgv.Item(0, Me.regActual)
                  End If
            End If
      End Sub

    Sub Grabar(ByVal codCue As String)
        'Obtener la cuenta
        Dim entCue As New SuperEntidad
        entCue.CodigoCuentaPcge = codCue
        entCue = cue.buscarPlanDeCuentasExisPorCodigo(entCue)
        If entCue.CodigoCuentaPcge = "" Then Exit Sub

        'Grabar a plancuentage
        Dim ce As New SuperEntidad
        ce.CodigoEmpresa = cemp
        ce.CodigoCuentaPcge = entCue.CodigoCuentaPcge
        ce.NombreCuentaPcge = entCue.NombreCuentaPcge
        ce.FlagDocumentoPcge = "0"
        ce.FlagAuxiliarPcge = "0"
        ce.FlagCentroCostoPcge = "0"
        ce.FlagAlmacenPcge = "0"
        ce.FlagAreaPcge = "0"
        ce.FlagFlujoCajaPcge = "0"
        ce.FlagAutomaticaPcge = "0"
        ce.FlagDifCambioPcge = "0"
        ce.FlagBancoPcge = "0"
        ce.FlagMonedaPcge = "0"
        ce.Exporta = "0"
        ce.ClaveFormatoContable = ""
        ce.CuentaAutomatica1Pcge = ""
        ce.CuentaAutomatica2Pcge = ""
        empCue.nuevaCuenta(ce)
    End Sub

      Sub Eliminar(ByVal codCue As String)
            'eliminar a plancuentage
            Dim ce As New SuperEntidad
            ce.ClaveCuentaPcge = cemp + codCue
            empCue.eliminarCuentaFis(ce)
      End Sub

      Sub ActualizarVentanaSegunAgregar()
            'Me.regActCG = Me.DgvCueGen.CurrentRow.Index
            Me.ActualizarDgvCueGen()
            Me.MantenerIndiceFilaDgv(Me.DgvCueGen)
            Me.ActualizarDgvCueEmp()
        Dgv.obtenerCursorActual(Me.DgvCueEmp, ent.CodigoCuentaPcge, Me.listaPcE)
            Me.HabilitarBotonesAgregar()
            Me.HabilitarBotonesQuitar()
      End Sub

      Sub ActualizarVentanaSegunQuitar()
            'Me.regActCG = Me.DgvCueGen.CurrentRow.Index
            Me.ActualizarDgvCueEmp()
            Me.MantenerIndiceFilaDgv(Me.DgvCueEmp)
            Me.ActualizarDgvCueGen()
            Dgv.obtenerCursorActual(Me.DgvCueGen, ent.CodigoCuentaPcge, Me.listaPc)
            Me.HabilitarBotonesAgregar()
            Me.HabilitarBotonesQuitar()
      End Sub

      Sub AgregarUno()
            Me.regActual = Me.DgvCueGen.CurrentRow.Index
            'Obtener el codigo de la cuenta que se quiere agregar
            Dim cod As String = Dgv.obtenerValorCelda(Me.DgvCueGen, cam.CodCtaPcge)
        ent.CodigoCuentaPcge = cod
        MsgBox(cod)

            'Grabar Cuenta
            Me.Grabar(cod)
            Me.ActualizarVentanaSegunAgregar()
      End Sub

      Sub AgregarTodos()
            Dim rpta As Integer = MsgBox("Deseas agregar todas las cuentas", MsgBoxStyle.YesNo, Me.titulo)
            If rpta = MsgBoxResult.Yes Then
                  Me.regActual = Me.DgvCueGen.CurrentRow.Index
                  'Recorrer cada cuenta para ser agregada
                  For n As Integer = 0 To Me.DgvCueGen.Rows.Count - 1
                        Dim cod As String = Me.DgvCueGen.Item(cam.CodCtaPcge, n).Value.ToString
                        Me.Grabar(cod)
                  Next
                  Me.ActualizarVentanaSegunAgregar()
            Else
                  Exit Sub
            End If
      End Sub

      Sub QuitarUno()
            Me.regActual = Me.DgvCueEmp.CurrentRow.Index
            'Obtener el codigo de la cuenta que se quiere agregar
            Dim cod As String = Dgv.obtenerValorCelda(Me.DgvCueEmp, cam.CodCtaPcge)
            ent.CodigoCuentaPcge = cod
            'Grabar Cuenta
            Me.Eliminar(cod)
            Me.ActualizarVentanaSegunQuitar()
      End Sub

      Sub QuitarTodos()
            Dim rpta As Integer = MsgBox("Deseas quitar todas las cuentas de esta empresa", MsgBoxStyle.YesNo, Me.titulo)
            If rpta = MsgBoxResult.Yes Then
                  Me.regActual = Me.DgvCueEmp.CurrentRow.Index
                  'Recorrer cada cuenta para ser eliminada
                  For n As Integer = 0 To Me.DgvCueEmp.Rows.Count - 1
                        Dim cod As String = Me.DgvCueEmp.Item(cam.CodCtaPcge, n).Value.ToString
                        Me.Eliminar(cod)
                  Next
                  Me.ActualizarVentanaSegunQuitar()
            Else
                  Exit Sub
            End If
      End Sub

#End Region


      Private Sub WEditarTabla_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            Me.Owner.Enabled = True
      End Sub

      Private Sub BtnAgrega_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgrega.Click
            Me.AgregarUno()
      End Sub

      Private Sub BtnAgregaTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregaTodos.Click
            Me.AgregarTodos()
      End Sub

      Private Sub BtnQuita_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQuita.Click
            '            If Me.PermitirQuitarCuenta = False Then : Exit Sub : End If
            Me.QuitarUno()
      End Sub

      Private Sub BtnQuitarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQuitarTodos.Click
            Me.QuitarTodos()
      End Sub

      Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
            Me.Close()
      End Sub

    Private Sub txtCueDis_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCueDis.KeyUp
        Dim texto As String = Me.txtCueDis.Text.Trim
        Dgv.buscarEnColumna(Me.DgvCueGen, cam.CodCtaPcge, texto)
    End Sub

    Private Sub txtCueEmp_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCueEmp.KeyUp
        Dim texto As String = Me.txtCueEmp.Text.Trim
        Dgv.buscarEnColumna(Me.DgvCueEmp, cam.CodCtaPcge, texto)
    End Sub

End Class