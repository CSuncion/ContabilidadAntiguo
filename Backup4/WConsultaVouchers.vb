Imports Entidad
Imports Negocio

Public Class WConsultaVouchers

    Public acc As New Accion
    Public lista, lD As New List(Of SuperEntidad)
    Public mcc As New MovimientoContableCabeceraRN
    Public mcd As New MovimientoContableDetalleRN
    Public cam As New CamposEntidad
    Public ent, entPar, entDeta As New SuperEntidad
    Public par As New ParametroRN
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
        
    End Sub


    Sub ActualizarVentana()
        '//
        Me.ActualizarDgvCabe()
        'Me.ActualizarDgvDeta()
        Dgv.actualizarBarraEstado(Me.sst1, Me.DgvMovCabe)
        acc.EstadoBotonesPorGrilla(Me.ListaBotones, Me.DgvMovCabe)
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvMovCabe)
        Dgv.pintarColumnaDgv(Me.DgvMovCabe, ent.CampoOrden)
        'Me.permisoVentana()     ''OJO FALTA VER COMO FUNCIONA
        '\\
    End Sub

    Sub ActualizarDgvCabe()
        '//
        '/Refrescando el DataSource de DgvUsu
        'ent.CodigoOrigen = "4"
        ent.PeriodoRegContabCabe = periodo
        ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        lista = mcc.obtenerMovimientoCabeceraXPeriodo(ent)

        Dgv.refrescarFuenteDatosGrilla(Me.DgvMovCabe, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.ClaveRCC, "Clave", 140)
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.NomOriRC, "Origen", 100)
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.NomFilRC, "File", 130)
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.NumVouRCC, "Numero Voucher", 90)
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.FecVouRCC, "Fecha Voucher", 80)
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.DesAux, "Proveedor", 250)
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.NomTipDoc, "Documento", 60)
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.SerDoC, "Serie", 60)
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.NumDoc, "Numero", 100)
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.PreVtaRCC, "P.Venta", 100)
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.ValVtaRCC, "V.Venta", 100)
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.IgvRCC, "Igv", 100)
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.IgvPar, "%Igv", 60)
        '    Dgv.asignarColumnaTextVis(Me.DgvMovCabe, cam.ClaveRCC, "Clave", 125, 0)

        '//
    End Sub

    Sub ActualizarDgvDeta()
        '/Obtener el codigo de usuario
        Dim nReg As Integer = Me.DgvMovCabe.Rows.Count
        'If nReg = 0 Then Exit Sub
        Dim Clave As String
        Select Case nReg
            Case 0 : Clave = String.Empty
            Case 1 : Clave = Me.DgvMovCabe.Item(0, 0).Value.ToString
            Case Else : Clave = Dgv.obtenerValorCelda(Me.DgvMovCabe, cam.ClaveRCC)
        End Select

        'Si todo esta Ok
        'Dim cla As String = Dgv.obtenerValorCelda(Me.DgvMovCabe, cam.ClaveRCC)
        entDeta.ClaveRegContabCabe = Clave
        entDeta.CampoOrden = cam.ClaveRCC
        lD = mcd.obtenerMovimientoDetalleXClaveCabe(entDeta)
        Dgv.refrescarFuenteDatosGrilla(Me.DgvMovDeta, lD)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvMovDeta, cam.ClaveRCC, "Clave", 120)
        Dgv.asignarColumnaText(Me.DgvMovDeta, cam.NomOriRC, "Origen", 100)
        Dgv.asignarColumnaText(Me.DgvMovDeta, cam.NomFilRC, "File", 180)
        Dgv.asignarColumnaText(Me.DgvMovDeta, cam.NumVouRCC, "Numero Vaucher", 150)
        Dgv.asignarColumnaText(Me.DgvMovDeta, cam.FecVouRCC, "Fecha Voucher", 130)
        Dgv.asignarColumnaText(Me.DgvMovDeta, cam.DebHabRCD, "D/H", 60)
        Dgv.asignarColumnaText(Me.DgvMovDeta, cam.CodCtaPcge, "Cuenta", 60)
        Dgv.AsignarColumnaTextNumerico(Me.DgvMovDeta, cam.ImpSRCD, "Importe S/.", 200, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvMovDeta, cam.ImpDRCD, "Importe us$", 200, 2)
        Dgv.asignarColumnaText(Me.DgvMovDeta, cam.CodTipDoc, "TD", 60)
        Dgv.asignarColumnaText(Me.DgvMovDeta, cam.SerDoC, "Serie", 60)
        Dgv.asignarColumnaText(Me.DgvMovDeta, cam.NumDoc, "N°.Documento", 120)
    End Sub

    Sub Buscar()
        '//
        Dim win As New WBuscar
        win.wCv = Me
        Me.AddOwnedForm(win)
        win.ventanaBuscar(ent.ColumnaBusqueda)
        '\\
    End Sub

    Sub Filtrar()
        Dim win As New WFitrarPeriodo
        win.wConMes = Me
        win.TipoRg = "Compras"
        Me.AddOwnedForm(win)
        win.nuevo()
    End Sub

    Sub adicionar()
        '//
        'Dim win As New WEditarRegistroCompra
        'win.wRc = Me
        'win.operacion = 0
        'Me.AddOwnedForm(win)
        'win.ventanaAdicionar()
        '\\
    End Sub

    Sub adicionarManual()
        '//
        'Dim win As New WEditarRegistroCompra
        'win.wRc = Me
        'win.operacion = 4
        'Me.AddOwnedForm(win)
        'win.ventanaAdicionarManual()
        '\\
    End Sub

    Sub modificar()
        '//
        'Dim win As New WEditarRegistroCompra
        'win.wRc = Me
        'win.operacion = 1
        'Me.AddOwnedForm(win)
        ''/Obtener el codigo de usuario
        'Dim cod As String = Dgv.obtenerValorCelda(Me.DgvMovCabe, cam.ClaveRCC) ''Ojo cambiar en formularios El el campo que no se ve en la grilla
        'win.ventanaModificar(cod)
        '\\
    End Sub

    Sub eliminar()
        '//
        'Dim win As New WEditarRegistroCompra
        'win.wRc = Me
        'win.operacion = 2
        'Me.AddOwnedForm(win)
        ''/Obtener el codigo de usuario
        'Dim cod As String = Dgv.obtenerValorCelda(Me.DgvMovCabe, cam.ClaveRCC)
        'win.ventanaEliminar(cod)
        '\\
    End Sub

    Sub visualizar()
        ''//
        'Dim win As New WEditarRegistroCompra
        'win.wRc = Me
        'Me.AddOwnedForm(win)
        ''/Obtener el codigo de usuario
        'Dim cod As String = Dgv.obtenerValorCelda(Me.DgvMovCabe, cam.ClaveRCC)
        'win.ventanaVisualizar(cod)
        '\\
    End Sub

    Sub imprimir()
        ''//
        'Dim imp As New WImprimirRegCompras
        'imp.wRegCom = Me
        'Me.AddOwnedForm(imp)
        'imp.nuevaVentana()
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


#End Region

    Private Sub btnActualizarTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarTabla.Click
        Me.ActualizarVentana()
    End Sub

    Private Sub DgvPpto_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvMovCabe.CellEnter
        'acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvRcom)
        Me.ActualizarDgvDeta()
    End Sub

    Private Sub DgvPer_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvMovCabe.ColumnHeaderMouseClick
        ent.CampoOrden = Me.DgvMovCabe.Columns(e.ColumnIndex).Name
        ent.ColumnaBusqueda = Me.DgvMovCabe.Columns(e.ColumnIndex).HeaderText
        Me.ActualizarVentana()
    End Sub

    Private Sub btnDesplaza_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrimero.Click, btnAnterior.Click, btnSiguiente.Click, btnUltimo.Click
        Dgv.desplazamientoFila(Me.DgvMovCabe, CType(sender, ToolStripButton))
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

    'Private Sub btnImprimirUno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirUn.Click
    '    ' Me.ImprimirUno()
    'End Sub

    Private Sub DgvPpto_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvMovCabe.CellMouseDoubleClick
        'If e.RowIndex = -1 Then
        '    Exit Sub
        'Else
        '    Me.ImprimirUno()
        'End If
    End Sub


    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        Me.Filtrar()
    End Sub

    Private Sub btnAdionarManual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdionarManual.Click
        Me.adicionarManual()
    End Sub

End Class