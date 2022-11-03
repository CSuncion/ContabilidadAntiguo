Option Strict Off
Imports Entidad
Imports Negocio

Public Class WRegistroDiario

    Public per As New PermisoRN
    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public rd As New RegContabCabeRN
    Public cam As New CamposEntidad
    Public ent, entpar As New SuperEntidad
    Public titulo As String = "Diario"
    Public par As New ParametroRN
    Public periodo As String

#Region "Metodos"

    Sub NuevaVentana()
        '//
        Me.Show()
        'periodo actual
        entpar = par.buscarParametroExis(entpar)
        periodo = SuperEntidad.xPeriodoEmpresa
        ent.CampoOrden = cam.ClaveRCC
        ent.ColumnaBusqueda = "Codigo"
        Me.ActualizarVentana()
        '\\
    End Sub

    Sub permisoVentana()
        Dim nReg As Integer = Me.DgvDia.Rows.Count
        Dim lisPer As New List(Of SuperEntidad)
        Dim oPer As New SuperEntidad
        oPer.CodigoUsuario = SuperEntidad.xCodigoUsuario
        oPer.CodigoVentana = "021"
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
            End Select
        Next
    End Sub

    Sub ActualizarVentana()
        '//
        Me.ActualizarDgvUsu()
        Dgv.actualizarBarraEstado(Me.sst1, Me.DgvDia)
        acc.EstadoBotonesPorGrilla(Me.ListaBotones, Me.DgvDia)
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvDia)
        Dgv.pintarColumnaDgv(Me.DgvDia, ent.CampoOrden)
        Me.permisoVentana()
        '\\
    End Sub

    Sub ActualizarDgvUsu()
        '//
        '/Refrescando el DataSource de DgvUsu
        ent.CodigoOrigen = "3"
        ent.PeriodoRegContabCabe = periodo
        ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        lista = rd.obtenerRegContabCabeExisXOrigenYPeriodo(ent)
        Dgv.refrescarFuenteDatosGrilla(Me.DgvDia, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvDia, cam.ClaveRCC, "Clave", 130)
        Dgv.asignarColumnaText(Me.DgvDia, cam.CodOriRC, "Origen", 50)
        Dgv.asignarColumnaText(Me.DgvDia, cam.NomOriRC, "Descripcion", 85)
        Dgv.asignarColumnaText(Me.DgvDia, cam.CodFilRC, "File", 50)
        Dgv.asignarColumnaText(Me.DgvDia, cam.NomFilRC, "Descripcion", 180)
        Dgv.asignarColumnaText(Me.DgvDia, cam.NumVouRCC, "Numero Voucher", 120)
        Dgv.asignarColumnaText(Me.DgvDia, cam.FecVouRCC, "Fecha Voucher", 110)
        Dgv.AsignarColumnaTextNumerico(Me.DgvDia, cam.SumDebRCC, "Debe", 120, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvDia, cam.SumHabRCC, "Haber", 120, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvDia, cam.DifDH, "Diferencia", 120, 2)
        Dgv.asignarColumnaText(Me.DgvDia, cam.GlosaRCC, "Glosa", 310)
        '//
    End Sub

    Sub Buscar()
        '//
        Dim win As New WBuscar
        win.wRd = Me
        Me.AddOwnedForm(win)
        win.ventanaBuscar(ent.ColumnaBusqueda)
        '\\
    End Sub

    Sub Filtrar()
        Dim win As New WFitrarPeriodo
        win.wRgDiario = Me
        win.TipoRg = "Diarios"
        Me.AddOwnedForm(win)
        win.nuevo()
    End Sub

    Sub adicionar()
        '//
        Dim win As New WEditarRegistroDiario
        win.wRd = Me
        win.operacion = 0
        Me.AddOwnedForm(win)
        win.ventanaAdicionar()
        '\\
    End Sub

    Sub adicionarManual()
        '//
        Dim win As New WEditarRegistroDiario
        win.wRd = Me
        win.operacion = 4
        Me.AddOwnedForm(win)
        win.ventanaAdicionarManual()
        '\\
    End Sub

    Sub modificar()
        'si el registro esta estornado o es un estorno entonces no se puede modificar
        If Me.EsActoEstornarRegistro = False Then Exit Sub

        '//
        Dim win As New WEditarRegistroDiario
        win.wRd = Me
        win.operacion = 1
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvDia, cam.ClaveRCC)
        win.ventanaModificar(cod)
        '\\
    End Sub

    Sub copiar()
        '//
        Dim win As New WEditarRegistroDiario
        win.wRd = Me
        win.operacion = 5
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvDia, cam.ClaveRCC)
        win.ventanaCopiar(cod)
        '\\
    End Sub

    Sub eliminar()
        'si el registro esta estornado o es un estorno entonces no se puede modificar
        If Me.EsActoEstornarRegistro = False Then Exit Sub

        '//
        Dim win As New WEditarRegistroDiario
        win.wRd = Me
        win.operacion = 2
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvDia, cam.ClaveRCC)
        win.ventanaEliminar(cod)
        '\\
    End Sub

    Sub visualizar()
        '//
        'si el registro esta estornado o es un estorno entonces no se puede modificar
        If Me.EsRegistroContableCabeExistente = False Then Exit Sub

        Dim win As New WEditarRegistroDiario
        win.wRd = Me
        win.operacion = 3
        Me.AddOwnedForm(win)
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvDia, cam.ClaveRCC)
        win.ventanaVisualizar(cod)
        '\\
    End Sub


    Sub wImpVoucher()
        '/
        Dim win As New WImpVoucher
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvDia, cam.ClaveRCC)
        Dim ob As New SuperEntidad
        ob.ClaveRegContabCabe = cod
        win.ent = rd.buscarRegContabExisPorClave(ob)

        win.NuevaVentanaDesdeVoucher()
    End Sub


    Sub imprimir()
        '/
        '/Obtener registro 
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvDia, cam.ClaveRCC)
        Dim ob As New SuperEntidad
        ob.ClaveRegContabCabe = cod
        ob = rd.buscarRegContabExisPorClave(ob)
        Me.wImpVoucher()
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
        iRccEN.ClaveRegContabCabe = Dgv.obtenerValorCelda(Me.DgvDia, cam.ClaveRCC)
        iRccEN = iRccRN.EsActoEstornarRegistro(iRccEN)
        If iRccEN.EsVerdad = False Then
            MsgBox(iRccEN.Mensaje, MsgBoxStyle.Exclamation, "Registro contable")
        End If
        Return iRccEN.EsVerdad
    End Function

    Function EsRegistroContableCabeExistente() As Boolean
        Dim iRccRN As New RegContabCabeRN
        Dim iRccEN As New SuperEntidad
        iRccEN.ClaveRegContabCabe = Dgv.obtenerValorCelda(Me.DgvDia, cam.ClaveRCC)
        iRccEN = iRccRN.EsRegistroContableCabeExistente(iRccEN)
        If iRccEN.EsVerdad = False Then
            MsgBox(iRccEN.Mensaje, MsgBoxStyle.Exclamation, "Registro contable")
        End If
        Return iRccEN.EsVerdad
    End Function

    Sub Estornar()
        'preguntar si es acto estornar
        If Me.EsActoEstornarRegistro = False Then Exit Sub

        'preguntar si desas realizar la operacion
        Dim rpta As Integer = MsgBox("Deseas estornar este registro", MsgBoxStyle.YesNo, "Registro contable")
        If rpta = MsgBoxResult.No Then Exit Sub

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
        iRccEN.ClaveRegContabCabe = Dgv.obtenerValorCelda(Me.DgvDia, cam.ClaveRCC)
        iRccRN.EstornarRegistroContable(iRccEN)
    End Sub

    Sub GenerarAsientoDocumentosPendientes()
        '//
        Dim win As New WGenAsiDocPen
        win.wRc = Me
        Me.AddOwnedForm(win)
        win.NuevaVentana()
        '\\
    End Sub


#End Region

    Private Sub btnActualizarTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarTabla.Click
        Me.ActualizarVentana()
    End Sub

    Private Sub DgvPpto_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvDia.CellEnter
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvDia)
    End Sub

    Private Sub DgvPer_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvDia.ColumnHeaderMouseClick
        ent.CampoOrden = Me.DgvDia.Columns(e.ColumnIndex).Name
        ent.ColumnaBusqueda = Me.DgvDia.Columns(e.ColumnIndex).HeaderText
        Me.ActualizarVentana()
    End Sub

    Private Sub btnDesplaza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrimero.Click, btnAnterior.Click, btnSiguiente.Click, btnUltimo.Click
        Dgv.desplazamientoFila(Me.DgvDia, CType(sender, ToolStripButton))
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

    Private Sub btnVoucher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoucher.Click
        Me.imprimir()
    End Sub

    Private Sub btnAsiDocPen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsiDocPen.Click
        Me.GenerarAsientoDocumentosPendientes()
    End Sub
End Class