Option Strict Off
Imports Entidad
Imports Negocio

Public Class WRegistroHonorario

    Public per As New PermisoRN
    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public rh As New RegContabCabeRN
    Public par As New ParametroRN
    Public cam As New CamposEntidad
    Public ent, entPar As New SuperEntidad
    Public periodo As String

#Region "Metodos"

    Sub NuevaVentana()
        '//
        Me.Show()
        'periodo actual
        entPar = par.buscarParametroExis(entPar)
        periodo = SuperEntidad.xPeriodoEmpresa
        ent.CampoOrden = cam.ClaveRCC
        ent.ColumnaBusqueda = "Codigo"
        Me.ActualizarVentana()
        '\\
    End Sub

    Sub permisoVentana()
        Dim nReg As Integer = Me.DgvHon.Rows.Count
        Dim lisPer As New List(Of SuperEntidad)
        Dim oPer As New SuperEntidad
        oPer.CodigoUsuario = SuperEntidad.xCodigoUsuario
        oPer.CodigoVentana = "025"
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
                Case "08" : Me.btnImprimir.Enabled = vf
            End Select
        Next
    End Sub

    Sub ActualizarVentana()
        '//
        Me.ActualizarDgvUsu()
        Dgv.actualizarBarraEstado(Me.sst1, Me.DgvHon)
        acc.EstadoBotonesPorGrilla(Me.ListaBotones, Me.DgvHon)
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvHon)
        Dgv.pintarColumnaDgv(Me.DgvHon, ent.CampoOrden)
        Me.permisoVentana()
        '\\
    End Sub

    Sub ActualizarDgvUsu()
        '//
        '/Refrescando el DataSource de DgvUsu
        'filtrar por periodo y file que no sea 302
        ent.CodigoOrigen = "6"
        ent.PeriodoRegContabCabe = periodo
        ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        ent.CodigoFile = "601"
        lista = rh.obtenerRegContabCabeExisXOrigenFileYPeriodo(ent)

        Dgv.refrescarFuenteDatosGrilla(Me.DgvHon, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvHon, cam.ClaveRCC, "Clave", 140)
        Dgv.asignarColumnaText(Me.DgvHon, cam.NomOriRC, "Origen", 110)
        Dgv.asignarColumnaText(Me.DgvHon, cam.NomFilRC, "File", 200)
        Dgv.asignarColumnaText(Me.DgvHon, cam.NumVouRCC, "Numero Vaucher", 110)
        Dgv.asignarColumnaText(Me.DgvHon, cam.FecVouRCC, "Fecha Voucher", 110)
        Dgv.asignarColumnaText(Me.DgvHon, cam.DesAux, "Personal", 260)
        Dgv.asignarColumnaText(Me.DgvHon, cam.SerDoC, "Serie", 80)
        Dgv.asignarColumnaText(Me.DgvHon, cam.NumDoc, "Numero", 100)
        Dgv.asignarColumnaText(Me.DgvHon, cam.MonDoc, "Moneda", 50)
        Dgv.AsignarColumnaTextNumerico(Me.DgvHon, cam.PreVtaRCC, "Importe", 100, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvHon, cam.ValVtaRCC, "Retencion", 100, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvHon, cam.ImpDesRegRcc, "Descuento", 100, 2)
        Dgv.asignarColumnaText(Me.DgvHon, cam.FlaDesRegRcc, "T.Dscto", 50)

        '//
    End Sub

    Sub Buscar()
        '/
        Dim win As New WBuscar
        win.wRh = Me
        Me.AddOwnedForm(win)
        win.ventanaBuscar(ent.ColumnaBusqueda)
        '/
    End Sub

    Sub Filtrar()
        '/
        Dim win As New WFitrarPeriodo
        win.wRgHonorarios = Me
        win.TipoRg = "Honorarios"
        Me.AddOwnedForm(win)
        win.nuevo()
        '/
    End Sub

    Sub adicionar()
        '//
        Dim win As New WEditarRegistroHonorario
        win.wRh = Me
        win.operacion = 0
        Me.AddOwnedForm(win)
        win.ventanaAdicionar()
        '\\
    End Sub

    Sub adicionarManual()
        '//
        Dim win As New WEditarRegistroHonorario
        win.wRh = Me
        win.operacion = 4
        Me.AddOwnedForm(win)
        win.ventanaAdicionarManual()
        '\\
    End Sub

    Sub modificar()
        'si el registro esta estornado o es un estorno entonces no se puede modificar
        If Me.EsActoEstornarRegistro = False Then Exit Sub

        '//
        Dim win As New WEditarRegistroHonorario
        win.wRh = Me
        win.operacion = 1
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvHon, cam.ClaveRCC)
        win.ventanaModificar(cod)
        '\\
    End Sub

    Sub copiar()
        '//
        Dim win As New WEditarRegistroHonorario
        win.wRh = Me
        win.operacion = 5
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvHon, cam.ClaveRCC)
        win.ventanaCopiar(cod)
        '\\
    End Sub

    Sub eliminar()
        'si el registro esta estornado o es un estorno entonces no se puede modificar
        If Me.EsActoEstornarRegistro = False Then Exit Sub

        '//
        Dim win As New WEditarRegistroHonorario
        win.wRh = Me
        win.operacion = 2
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvHon, cam.ClaveRCC)
        win.ventanaEliminar(cod)
        '\\
    End Sub

    Sub visualizar()
        '//
        Dim win As New WEditarRegistroHonorario
        win.wRh = Me
        win.operacion = 3
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvHon, cam.ClaveRCC)
        win.ventanaVisualizar(cod)
        '\\
    End Sub

    Sub imprimir()
        '//
        Dim imp As New wImpHonorarios
        imp.wRh = Me
        Me.AddOwnedForm(imp)
        imp.InicializaVentana()
        '\\
    End Sub

    Sub exportar()
        '//
        'Dim imp As New WRptPer
        'imp.ent.CampoOrden = cam.CodPer
        'imp.ent.DatoEstado = ""
        'imp.Exportar()
        '\\
    End Sub

    Sub recycla()
        'Dim win As New wPersonalRecycla
        'win.wPer = Me
        'Me.AddOwnedForm(win)
        'win.NuevaVentana()
    End Sub

    Sub Estado()
        'Dim win As New WPersonalEstado
        'win.wPer = Me
        'Me.AddOwnedForm(win)
        'Dim codPer As String = Dgv.obtenerValorCelda(Me.DgvPer, 0)
        'win.ventanaModificar(codPer)
    End Sub

    Function EsActoEstornarRegistro() As Boolean
        Dim iRccRN As New RegContabCabeRN
        Dim iRccEN As New SuperEntidad
        iRccEN.ClaveRegContabCabe = Dgv.obtenerValorCelda(Me.DgvHon, cam.ClaveRCC)
        iRccEN = iRccRN.EsActoEstornarRegistro(iRccEN)
        If iRccEN.EsVerdad = False Then
            MsgBox(iRccEN.Mensaje, MsgBoxStyle.Exclamation, "Registro contable")
        End If
        Return iRccEN.EsVerdad
    End Function

    Function EsDocumentoPagado() As Boolean
        Dim ccte As New CuentaCorrienteRN
        Dim obj As New SuperEntidad
        obj.ClaveCuentaCorriente = Dgv.obtenerValorCelda(Me.DgvHon, cam.ClaveRCC)
        obj = ccte.buscarCuentaCorrienteExisPorClaveCC(obj)

        If obj.ImportePagadoCuentaCorriente <> 0 Then
            MsgBox("Documento ya tiene pagos no se puede realizar la operacion", MsgBoxStyle.Exclamation, "Honorarios")
            Return True
        Else
            Return False
        End If

    End Function

    Sub Estornar()
        'preguntar si es acto estornar
        If Me.EsActoEstornarRegistro = False Then Exit Sub

        'ahora preguntar si este documento no ha sido pagado
        If Me.EsDocumentoPagado = True Then Exit Sub

        'preguntar si desas realizar la operacion
        Dim rpta As Integer = MsgBox("Deseas estornar este registro", MsgBoxStyle.YesNo, "Registro contable")
        If rpta = MsgBoxResult.No Then Exit Sub

        'sacar la cuenta corriente
        Me.eliminarCuentaCorriente()

        'estornar el registro
        Me.EstornarRegistroContable()

        'mensaje de operacion realizada
        MsgBox("El registro fue estornado", MsgBoxStyle.Information, "Registro contable")

        'actualizar la ventana
        Me.ActualizarVentana()

    End Sub

    Public Sub EstornarRegistroContable()
        Dim iRccRN As New RegContabCabeRN
        Dim iRccEN As New SuperEntidad
        iRccEN.ClaveRegContabCabe = Dgv.obtenerValorCelda(Me.DgvHon, cam.ClaveRCC)
        iRccRN.EstornarRegistroContable(iRccEN)
    End Sub

    Sub eliminarCuentaCorriente()
        Dim ccte As New CuentaCorrienteRN
        Dim obj As New SuperEntidad
        obj.ClaveCuentaCorriente = Dgv.obtenerValorCelda(Me.DgvHon, cam.ClaveRCC)
        ccte.eliminarCuentaCorrienteFis(obj)
    End Sub

#End Region

    Private Sub btnActualizarTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarTabla.Click
        Me.ActualizarVentana()
    End Sub

    Private Sub DgvPpto_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvHon.CellEnter
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvHon)
    End Sub

    Private Sub DgvPer_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvHon.ColumnHeaderMouseClick
        ent.CampoOrden = Me.DgvHon.Columns(e.ColumnIndex).Name
        ent.ColumnaBusqueda = Me.DgvHon.Columns(e.ColumnIndex).HeaderText
        Me.ActualizarVentana()
    End Sub

    Private Sub btnDesplaza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrimero.Click, btnAnterior.Click, btnSiguiente.Click, btnUltimo.Click
        Dgv.desplazamientoFila(Me.DgvHon, CType(sender, ToolStripButton))
    End Sub

    Private Sub btnRegresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Me.Buscar()
    End Sub

    Private Sub btnAdicionar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdicionar.Click
        Me.adicionar()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        Me.modificar()
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Me.eliminar()
    End Sub

    Private Sub btnImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Me.imprimir()
    End Sub

    Private Sub btnExportar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportar.Click
        Me.exportar()
    End Sub

    Private Sub WPersonal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.NuevaVentana()
    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Me.visualizar()
    End Sub

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        Me.Filtrar()
    End Sub

    Private Sub btnAdionarManual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdionarManual.Click
        Me.adicionarManual()
    End Sub

    Private Sub btnEstornar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEstornar.Click
        Me.Estornar()
    End Sub

    Private Sub btnCopiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopiar.Click
        Me.copiar()
    End Sub
End Class














