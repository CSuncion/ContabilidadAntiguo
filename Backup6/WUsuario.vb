Option Strict Off
Imports Entidad
Imports Negocio

Public Class WUsuario

    Public per As New PermisoRN
    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public usu As New UsuarioRN
    Public cam As New CamposEntidad
    Public ent As New SuperEntidad

#Region "Metodos"

    Sub NuevaVentana()
        '//
        Me.Show()
        ent.CampoOrden = cam.CodUsu
        ent.ColumnaBusqueda = "Codigo"
        Me.ActualizarVentana()
        '\\
    End Sub

    Sub permisoVentana()
        Dim nReg As Integer = Me.DgvUsu.Rows.Count
        Dim lisPer As New List(Of SuperEntidad)
        Dim oPer As New SuperEntidad
        oPer.CodigoUsuario = SuperEntidad.xCodigoUsuario
        oPer.CodigoVentana = "001"
        oPer.CampoOrden = cam.CodVen
        lisPer = per.obtenerPermisosExisXUsuarioYVentana(oPer)
        'RECORRER CADA PERMISO
        For Each p As SuperEntidad In lisPer
            ' 0 : NO TIENE PERMISO ,  1 : SI TIENE PERMISO
            Dim vf As Boolean = IIf(p.OpcionPermiso = 0, False, True)
            'SOLO PARA EL ADICIONAR
            If p.CodigoOpcion = "01" Then
                Me.btnAdicionar.Enabled = vf
            End If
            'SI LA GRILLA ESTA VACIA LA ACCION QUEDA DESHABILITADA
            If nReg = 0 Then vf = False

            'PASAR vf A LOS BOTONES DE LA VENTANA
            Select Case p.CodigoOpcion
                Case "02" : Me.btnModificar.Enabled = vf
                Case "03" : Me.btnEliminar.Enabled = vf
                Case "04" : Me.btnVisualizar.Enabled = vf
                Case "11" : Me.btnAsignar.Enabled = vf
                Case "12" : Me.btnCopiar.Enabled = vf
            End Select
        Next
    End Sub

    Sub ActualizarVentana()
        '//

        Me.ActualizarDgvUsu()
        Dgv.actualizarBarraEstado(Me.sst1, Me.DgvUsu)
        acc.EstadoBotonesPorGrilla(Me.ListaBotones, Me.DgvUsu)
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvUsu)
        Dgv.pintarColumnaDgv(Me.DgvUsu, ent.CampoOrden)
        Me.permisoVentana()
        '\\
    End Sub

    Sub ActualizarDgvUsu()
        '//
        '/Refrescando el DataSource de DgvUsu
        lista = usu.obtenerUsuariosExisTot(ent)
        '/Refrescando el DataSource de DgvUsu
        Dgv.refrescarFuenteDatosGrilla(Me.DgvUsu, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvUsu, cam.CodUsu, "Usuario", 120)
        Dgv.asignarColumnaText(Me.DgvUsu, cam.NomUsu, "Apellidos y Nombres", 350)
        Dgv.asignarColumnaText(Me.DgvUsu, cam.EstReg, "Estado", 90)

        '//
    End Sub

    Sub buscarUsuario()
        '//
        Dim win As New WBuscar
        win.wUsu = Me
        Me.AddOwnedForm(win)
        win.ventanaBuscar(ent.ColumnaBusqueda)
        '\\
    End Sub

    Sub adicionar()
        '//
        Dim win As New WEditarUsuario
        win.wUsu = Me
        Me.AddOwnedForm(win)
        win.ventanaAdicionar()
        '\\
    End Sub

    Sub modificar()
        '//
        Dim win As New WEditarUsuario
        win.wUsu = Me
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim codUsu As String = Dgv.obtenerValorCelda(Me.DgvUsu, 0)
        win.ventanaModificar(codUsu)
        '\\
    End Sub

    Sub eliminar()
        '//
        Dim win As New WEditarUsuario
        win.wUsu = Me
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim codUsu As String = Dgv.obtenerValorCelda(Me.DgvUsu, 0)
        win.ventanaEliminar(codUsu)
        '\\       
    End Sub

    Sub Visualizar()
        '//
        Dim win As New WEditarUsuario
        win.wUsu = Me
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim codUsu As String = Dgv.obtenerValorCelda(Me.DgvUsu, 0)
        win.ventanaVisualizar(codUsu)
        '\\       
    End Sub


    Sub imprimir()
        '//
        'Dim imp As New WImprimirUsuarios
        'imp.wUsu = Me
        'Me.AddOwnedForm(imp)
        'imp.nuevaVentana()
        '\\
    End Sub

    Sub exportar()
        '//
        'Dim imp As New WRptUsu
        'imp.ent.DatoEstado = ""
        'imp.ent.CampoOrden = cam.CodUsu
        'imp.Exportar()
        '\\
    End Sub

    Sub AsignarPermisos()
        Dim win As New WPermisos
        win.wUsu = Me
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvUsu, cam.CodUsu)
        win.NuevaVentana(cod)
    End Sub

    Sub CopiarPermisos()
        Dim win As New WCopiaPermiso
        win.wUsu = Me
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvUsu, cam.CodUsu)
        win.NuevaVentana(cod)
    End Sub

    Sub AsignarEmpresas()
        'Preguntar si este registro existe en b.d
        Dim usuEN As SuperEntidad = Me.ObtenerUsuarioExistente
        If usuEN.CodigoUsuario = String.Empty Then
            MsgBox("El usuario no existe; Actualize su grilla", MsgBoxStyle.Information, "Usuario")
        Else
            Dim win As New WAsignarEmpresas
            win.wUsu = Me
            win.MdiParent = Me.MdiParent
            win.Tag = Me.Tag
            win.NuevaVentana(usuEN)
        End If
    End Sub

    Function ObtenerUsuarioExistente() As SuperEntidad
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvUsu, cam.CodUsu)
        Dim usuEN As New SuperEntidad
        Dim iUsuRN As New UsuarioRN
        usuEN.DatoCondicion1 = cod
        usuEN.CodigoUsuario = cod
        usuEN = iUsuRN.buscarUsuarioExisTotPorCodigo(usuEN)
        Return usuEN
    End Function

#End Region


    Private Sub btnActualizarTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarTabla.Click
        Me.ActualizarVentana()
    End Sub

    Private Sub DgvUsu_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvUsu.CellEnter
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvUsu)
    End Sub

    Private Sub DgvUsu_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvUsu.ColumnHeaderMouseClick
        ent.CampoOrden = Me.DgvUsu.Columns(e.ColumnIndex).Name
        ent.ColumnaBusqueda = Me.DgvUsu.Columns(e.ColumnIndex).HeaderText
        Me.ActualizarVentana()
    End Sub

    Private Sub btnDesplaza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrimero.Click, btnAnterior.Click, btnSiguiente.Click, btnUltimo.Click
        Dgv.desplazamientoFila(Me.DgvUsu, CType(sender, ToolStripButton))
    End Sub

    Private Sub btnRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Me.buscarUsuario()
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

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Me.Visualizar()
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Me.imprimir()
    End Sub

    Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Me.exportar()
    End Sub


    Private Sub btnAsignar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsignar.Click
        Me.AsignarPermisos()
    End Sub

    Private Sub btnCopiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopiar.Click
        Me.CopiarPermisos()
    End Sub

    Private Sub btnAsignarEmpresa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsignarEmpresa.Click
        Me.AsignarEmpresas()
    End Sub
End Class