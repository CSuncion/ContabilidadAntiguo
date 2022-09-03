Option Strict Off
Imports Entidad
Imports Negocio

Public Class WVoucher

    Public per As New PermisoRN
    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public vou As New VoucherRN
    Public cam As New CamposEntidad
    Public ent As New SuperEntidad
    Public titulo As String = "Voucher"

#Region "Metodos"

    Sub NuevaVentana()
        '//
        'visualiza el formulario
        Me.Show()
        'orden por defecto
        ent.CampoOrden = cam.CodFilRC
        ent.ColumnaBusqueda = "Codigo"
        Me.CargarAños()
        Me.ActualizarVentana()
    End Sub

    Sub CargarAños()
        Dim iPerRN As New PeriodoRN
        Dim iPerEN As New SuperEntidad
        iPerEN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iPerEN.CampoOrden = cam.ClaPer
        Dim iLisAño As List(Of String) = iPerRN.ObtenerLosAnosDePeriodosXEmpresa(iPerEN)
        Cmb.CargarItems(Me.tsCmbAno, iLisAño, Cmb.Elemento.Ultimo)
    End Sub

    Sub permisoVentana()
        Dim nReg As Integer = Me.DgvVou.Rows.Count
        Dim lisPer As New List(Of SuperEntidad)
        Dim oPer As New SuperEntidad
        oPer.CodigoUsuario = SuperEntidad.xCodigoUsuario
        oPer.CodigoVentana = "014"
        oPer.CampoOrden = cam.CodVen
        lisPer = per.obtenerPermisosExisXUsuarioYVentana(oPer)
        'RECORRER CADA PERMISO
        For Each p As SuperEntidad In lisPer
            ' 0 : NO TIENE PERMISO ,  1 : SI TIENE PERMISO
            Dim vf As Boolean = IIf(p.OpcionPermiso = 0, False, True)
            'SI LA GRILLA ESTA VACIA LA ACCION QUEDA DESHABILITADA
            If nReg = 0 Then vf = False

            'PASAR vf A LOS BOTONES DE LA VENTANA
            Select Case p.CodigoOpcion
                Case "02" : Me.btnModificar.Enabled = vf
                Case "04" : Me.btnVisualizar.Enabled = vf
            End Select
        Next
    End Sub

    Sub ActualizarVentana()
        '//
        Me.ActualizarDgvTab()
        Dgv.actualizarBarraEstado(Me.sst1, Me.DgvVou)
        acc.EstadoBotonesPorGrilla(Me.ListaBotones, Me.DgvVou)
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvVou)
        Dgv.pintarColumnaDgv(Me.DgvVou, ent.CampoOrden)
        Me.permisoVentana()
        '\\
    End Sub

    Sub ActualizarDgvTab()
        '//
        '/Refrescando el DataSource de DgvUsu
        ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        ent.AnoVoucher = Me.tsCmbAno.Text
        lista = vou.obtenerVoucherExisXAno(ent)

        '/Refrescando el DataSource de DgvUsu
        Dgv.refrescarFuenteDatosGrilla(Me.DgvVou, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvVou, cam.CodFilRC, "File", 50)
        Dgv.asignarColumnaText(Me.DgvVou, cam.NomFilRC, "Nombre", 220)
        Dgv.asignarColumnaText(Me.DgvVou, cam.AnoVou, "Ano", 60)
        Dgv.asignarColumnaText(Me.DgvVou, cam.ApeVou, "Apertura", 70)
        Dgv.asignarColumnaText(Me.DgvVou, cam.EneVou, "Enero", 70)
        Dgv.asignarColumnaText(Me.DgvVou, cam.FebVou, "Febrero", 70)
        Dgv.asignarColumnaText(Me.DgvVou, cam.MarVou, "Marzo", 70)
        Dgv.asignarColumnaText(Me.DgvVou, cam.AbrVou, "Abril", 70)
        Dgv.asignarColumnaText(Me.DgvVou, cam.MayVou, "Mayo", 70)
        Dgv.asignarColumnaText(Me.DgvVou, cam.JunVou, "Junio", 70)
        Dgv.asignarColumnaText(Me.DgvVou, cam.JulVou, "Julio", 70)
        Dgv.asignarColumnaText(Me.DgvVou, cam.AgolVou, "Agosto", 70)
        Dgv.asignarColumnaText(Me.DgvVou, cam.SetVou, "Setiembre", 70)
        Dgv.asignarColumnaText(Me.DgvVou, cam.OctVou, "Octubre", 70)
        Dgv.asignarColumnaText(Me.DgvVou, cam.NovVou, "Noviembre", 70)
        Dgv.asignarColumnaText(Me.DgvVou, cam.DicVou, "Diciembre", 70)
        Dgv.asignarColumnaText(Me.DgvVou, cam.CieVou, "Cierre", 70)
        Dgv.asignarColumnaText(Me.DgvVou, cam.EstVoucher, "Estado", 70)
        Dgv.asignarColumnaTextVis(Me.DgvVou, cam.ClaVou, "clave", 70, 0)

        '//
    End Sub

    Sub buscar()
        '//
        Dim win As New WBuscar
        win.wVou = Me
        win.titulo = Me.titulo
        Me.AddOwnedForm(win)
        win.ventanaBuscar(ent.ColumnaBusqueda)
        '\\
    End Sub

    Sub adicionar()
        '//
        Dim win As New WEditarVoucher
        win.wVou = Me
        win.operacion = 0
        Me.AddOwnedForm(win)
        win.ventanaAdicionar()
        '\\
    End Sub

    Sub modificar()
        '//
        Dim win As New WEditarVoucher
        win.wVou = Me
        win.operacion = 1
        Me.AddOwnedForm(win)
        '/Obtener por clave de voucher 
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvVou, cam.ClaVou)
        win.ventanaModificar(cod)
        '\\
    End Sub

    Sub eliminar()
        '//
        Dim win As New WEditarVoucher
        win.wVou = Me
        win.operacion = 2
        Me.AddOwnedForm(win)
        '/Obtener por clave de voucher
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvVou, cam.ClaVou)
        win.ventanaEliminar(cod)
        '\\
    End Sub

    Sub Visualizar()
        '//
        Dim win As New WEditarVoucher
        win.wVou = Me
        win.operacion = 3
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvVou, cam.ClaVou)
        win.ventanaVisualizar(cod)
        '\\
    End Sub

    'Sub imprimir()
    '    '//
    '    Dim imp As New WImpTabla
    '    imp.wTab = Me
    '    Me.AddOwnedForm(imp)
    '    imp.nuevaVentana()
    '    '\\

    'End Sub


    Sub recycla()
        Dim win As New WVoucherRecycla
        win.wVou = Me
        Me.AddOwnedForm(win)
        win.NuevaVentana()
    End Sub


#End Region


    Private Sub btnAdicionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdicionar.Click
        Me.adicionar()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Me.eliminar()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Me.modificar()
    End Sub

    Private Sub btnRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Me.Close()
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Me.Visualizar()
    End Sub

    Private Sub btnRecycla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecycla.Click
        Me.recycla()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Me.buscar()
    End Sub

    Private Sub btnActualizarTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarTabla.Click
        Me.ActualizarVentana()
    End Sub

    Private Sub DgvPer_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvVou.ColumnHeaderMouseClick
        ent.CampoOrden = Me.DgvVou.Columns(e.ColumnIndex).Name
        ent.ColumnaBusqueda = Me.DgvVou.Columns(e.ColumnIndex).HeaderText
        Me.ActualizarVentana()
    End Sub

    Private Sub tsCmbAno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsCmbAno.SelectedIndexChanged
        Me.ActualizarVentana()
    End Sub
End Class