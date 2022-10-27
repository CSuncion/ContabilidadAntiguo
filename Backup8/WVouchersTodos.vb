Imports Entidad
Imports Negocio

Public Class WVouchersTodos

    Public acc As New Accion
    Public lista, lD As New List(Of SuperEntidad)
    Public mcc As New RegContabCabeRN
    Public mcd As New RegContabDetaRN
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
        ent.CampoOrden = cam.ClaConVou

        ent.ColumnaBusqueda = "Clave"
        Me.ActualizarVentana()
        '\\
    End Sub

    Sub permisoVentana()
       
    End Sub

    Sub ActualizarVentana()
        '//
        Me.ActualizarDgvCabe()
        Me.TituloCabecera()
        'Me.ActualizarDgvDeta()
        Dgv.actualizarBarraEstado(Me.sst1, Me.DgvMovCabe)
        acc.EstadoBotonesPorGrilla(Me.ListaBotones, Me.DgvMovCabe)
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvMovCabe)
        If ent.CampoOrden = cam.ClaveRCC Then
            Dgv.pintarColumnaDgv(Me.DgvMovCabe, cam.ClaConVou)
        Else
            Dgv.pintarColumnaDgv(Me.DgvMovCabe, ent.CampoOrden)
        End If

        'Me.permisoVentana()     ''OJO FALTA VER COMO FUNCIONA
        '\\
    End Sub

    Sub ActualizarDgvCabe()
        '//
        '/Refrescando el DataSource de DgvUsu

        ent.PeriodoRegContabCabe = periodo
        ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa

        If ent.CampoOrden = cam.ClaConVou Then
            ent.CampoOrden = cam.ClaveRCC
        End If

        lista = mcc.obtenerRegContabCabePorPeriodo(ent)

        Dgv.refrescarFuenteDatosGrilla(Me.DgvMovCabe, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.ClaConVou, "Clave", 100)
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.CodOriRC, "Origen", 50)
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.NomOriRC, "Descripción", 100)
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.CodFilRC, "File", 50)
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.NomFilRC, "Descripción", 180)
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.NumVouRCC, "Numero Voucher", 110)
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.FecVouRCC, "Fecha Voucher", 110)
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.DesAux, "Auxiliar", 270)
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.NomTipDoc, "Documento", 90)
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.SerDoC, "Serie", 80)
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.NumDoc, "Numero", 100)
        Dgv.AsignarColumnaTextNumerico(Me.DgvMovCabe, cam.PreVtaRCC, "P.Venta", 100, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvMovCabe, cam.ValVtaRCC, "V.Venta", 100, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvMovCabe, cam.IgvRCC, "Igv", 100, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvMovCabe, cam.ExoneradoRCC, "Exonedaro", 70, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvMovCabe, cam.ImpSolRCC, "Importe S/", 120, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvMovCabe, cam.SumDebRCC, "Suma Debe", 110, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvMovCabe, cam.SumHabRCC, "Suma Haber", 110, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvMovCabe, cam.VenTipCam, "T.C", 100, 3)
        Dgv.asignarColumnaTextVis(Me.DgvMovCabe, cam.ClaveRCC, "Clave", 140, 0)
        '//
    End Sub


    Sub TituloCabecera()
        Dim iCabeceraVoucher As String = Dgv.obtenerValorCelda(Me.DgvMovCabe, cam.ClaveRCC)
        Me.lblCabeVou.Text = "DETALLE DEL VOUCHER : " + iCabeceraVoucher
    End Sub

    Sub ActualizarDgvDeta()
        '/Obtener el codigo de usuario
        Dim nReg As Integer = Me.DgvMovCabe.Rows.Count
        'If nReg = 0 Then Exit Sub
        Dim Clave As String
        Select Case nReg
            Case 0 : Clave = String.Empty
            Case 1 : Clave = SuperEntidad.xCodigoEmpresa + SuperEntidad.xPeriodoEmpresa + Me.DgvMovCabe.Item(0, 0).Value.ToString.Substring(0, 1) + Me.DgvMovCabe.Item(0, 0).Value.ToString
            Case Else : Clave = Dgv.obtenerValorCelda(Me.DgvMovCabe, cam.ClaveRCC)
        End Select

        'Si todo esta Ok
        'Dim cla As String = Dgv.obtenerValorCelda(Me.DgvMovCabe, cam.ClaveRCC)
        entDeta.ClaveRegContabCabe = Clave
        entDeta.CampoOrden = cam.ClaveRCC + "," + cam.ClaveRCD
        lD = mcd.obtenerDetalleRegContabXClaveCabe(entDeta)
        Dgv.refrescarFuenteDatosGrilla(Me.DgvMovDeta, lD)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvMovDeta, cam.ClaveRCC, "Clave", 140)
        Dgv.asignarColumnaText(Me.DgvMovDeta, cam.CodOriRC, "Origen", 50)
        Dgv.asignarColumnaText(Me.DgvMovDeta, cam.NomOriRC, "Descripción", 100)
        Dgv.asignarColumnaText(Me.DgvMovDeta, cam.CodFilRC, "File", 50)
        Dgv.asignarColumnaText(Me.DgvMovDeta, cam.NomFilRC, "Descripción", 180)
        Dgv.asignarColumnaText(Me.DgvMovDeta, cam.NumVouRCC, "Numero Vaucher", 110)
        Dgv.asignarColumnaText(Me.DgvMovDeta, cam.FecVouRCC, "Fecha Voucher", 110)
        Dgv.asignarColumnaText(Me.DgvMovDeta, cam.DebHabRCD, "D/H", 80)
        Dgv.asignarColumnaText(Me.DgvMovDeta, cam.CodCtaPcge, "Cuenta", 85)
        Dgv.AsignarColumnaTextNumerico(Me.DgvMovDeta, cam.ImpSRCD, "Importe S/.", 100, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvMovDeta, cam.ImpDRCD, "Importe us$", 100, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvMovDeta, cam.ImpERCD, "Importe EUR", 100, 2)
        Dgv.asignarColumnaText(Me.DgvMovDeta, cam.GlosaRCD, "Glosa", 150)
        Dgv.asignarColumnaText(Me.DgvMovDeta, cam.CodCC, "Centro Costo", 150)
        Dgv.asignarColumnaText(Me.DgvMovDeta, cam.CodAux, "Codigo Auxiliar", 150)
        Dgv.asignarColumnaText(Me.DgvMovDeta, cam.CodTipDoc, "TD", 60)
        Dgv.asignarColumnaText(Me.DgvMovDeta, cam.SerDoC, "Serie", 60)
        Dgv.asignarColumnaText(Me.DgvMovDeta, cam.NumDoc, "N°.documento", 120)
        Dgv.asignarColumnaText(Me.DgvMovDeta, cam.CodGasRep, "Codigo Item", 80)
        Dgv.asignarColumnaText(Me.DgvMovDeta, cam.NomGasRep, "Nombre_Item_Almacen", 120)
        Dgv.AsignarColumnaTextNumerico(Me.DgvMovDeta, cam.Cant, "Cantidad", 80, 2)
        Dgv.asignarColumnaTextVis(Me.DgvMovDeta, cam.ClaveRCD, "ClaveObjeto", 150, 0)

    End Sub

    Sub Buscar()
        '//
        Dim win As New WBuscar
        win.wCvT = Me
        Me.AddOwnedForm(win)
        win.ventanaBuscar(ent.ColumnaBusqueda)
        '\\
    End Sub

    Sub Filtrar()
        Dim win As New WFitrarPeriodo
        win.wConMesT = Me
        ' win.TipoRg = "Compras"
        win.TipoRg = "VouchersTodos"
        Me.AddOwnedForm(win)
        win.nuevo()
    End Sub


    Sub imprimir()
        ''//
        Dim imp As New WImpVoucherSinCon
        imp.wCvT = Me
        Me.AddOwnedForm(imp)
        imp.InicializaVentana()
        '\\
    End Sub


    Sub ImprimeVou()
        '/
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvMovCabe, cam.ClaveRCC)
        Dim ob As New SuperEntidad
        ob.ClaveRegContabCabe = cod
        ob = mcc.buscarRegContabExisPorClave(ob)
        If ob.CodigoOrigen = "2" Then
            Me.wImpVoucher1()
        Else
            Me.wImpVoucher()
        End If

    End Sub

    Sub wImpVoucher()
        Dim win As New WImpVoucher
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvMovCabe, cam.ClaveRCC)
        Dim ob As New SuperEntidad
        ob.ClaveRegContabCabe = cod
        win.ent = mcc.buscarRegContabExisPorClave(ob)
        win.NuevaVentanaDesdeVoucher()
    End Sub

    Sub wImpVoucher1()
        Dim win As New WImpVoucher1
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvMovCabe, cam.ClaveRCC)
        Dim ob As New SuperEntidad
        ob.ClaveRegContabCabe = cod
        win.ent = mcc.buscarRegContabExisPorClave(ob)
        win.NuevaVentanaDesdeVoucher()
    End Sub

    Sub ModificarDocumneto()
        Dim win As New WModificarDocumento
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvMovDeta, cam.ClaveRCD)
        win.operacion = 1
        win.wVouTod = Me
        Me.AddOwnedForm(win)
        win.ventanaModificar(cod)
    End Sub

    Sub ModificarDatosDetalle()
        Dim win As New WModificarDatosDetalle
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvMovDeta, cam.ClaveRCD)
        win.operacion = 1
        win.wVouTod = Me
        Me.AddOwnedForm(win)
        win.ventanaModificar(cod)
    End Sub


    Sub ModificarGastoReparable()
        Dim win As New WModificarGastoReparable
        '/Obtener el codigo de usuario
        Dim cod As String = Dgv.obtenerValorCelda(Me.DgvMovDeta, cam.ClaveRCD)
        win.operacion = 1
        win.wVouTod = Me
        Me.AddOwnedForm(win)
        win.ventanaModificar(cod)
    End Sub


#End Region

    Private Sub btnActualizarTabla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarTabla.Click
        Me.ActualizarVentana()
    End Sub

    Private Sub DgvPpto_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvMovCabe.CellEnter
        acc.EstadoBotonesPorFillaGrilla(Me.ListaBotones, Me.DgvMovCabe)
        Me.TituloCabecera()
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


    Private Sub btnImprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        Me.imprimir()
    End Sub

  

    Private Sub WPersonal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.NuevaVentana()
    End Sub

    

    Private Sub btnAdionarManual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoucher.Click
        '/
        ' Me.wImpVoucher()
        Me.ImprimeVou()
    End Sub

    Private Sub btnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFiltrar.Click
        Me.Filtrar()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModifDocum.Click
        Me.ModificarDocumneto()
    End Sub

    Private Sub btnModDatosDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModDatosDet.Click
        Me.ModificarDatosDetalle()
    End Sub
End Class