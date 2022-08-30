Imports Entidad
Imports Negocio

Public Class WListarCuentaCorriente
    Public lista As New List(Of SuperEntidad)
    Public ent As New SuperEntidad
    Dim ccte As New CuentaCorrienteRN
    Public tabla As String
    Public titulo As String
    Public campoBusqueda As String
    Public txt1 As New TextBox
    Public txt2 As New TextBox
    Public txt3 As New TextBox
    Public txt4 As New TextBox
    Public txt5 As New TextBox
    Public txt6 As New TextBox
    Public txt7 As New TextBox
    Public txt8 As New TextBox
    Public txt9 As New TextBox
    Public txt10 As New TextBox
    Public grup As New GroupBox
    Public dtp1 As New DateTimePicker
    Public cam As New CamposEntidad
    Public xcampoorden As String
    Public ctrlFoco As New Control
    Public codaux As String

#Region "Metodos"

    Sub NuevaVentana()
        '//
        Me.Show()
        'orden de la grilla por defecto -->Descripcion
        xcampoorden = cam.ClaveDocuCtaCte
        'En que columna se va a buscar por defecto -->Descripcion
        Me.campoBusqueda = "Clave"
        Me.Text = "Listado de " + Me.titulo
        Me.ActualizarVentana()
        '\\
    End Sub

    Sub ActualizarVentana()
        Me.gbBus.Text = "Criterio de busqueda/Por :" + Me.campoBusqueda
        Me.ActualizarDgvLista()
        Dgv.pintarColumnaDgv(Me.DgvLista, xcampoorden)
    End Sub

    Sub ActualizarDgvLista()
        '//
        ent.CodigoAuxiliar = Me.codaux
        ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        
        '/Cargamos la tabla con el filtro del tipo de tabla
        lista = ccte.obtenerCuentaCorrienteExisXEmpresaXAuxiliarYPendientes(ent)
        'lista = ccte.obtenerCuentaCorrienteExisXEmpresaYPendientes(ent)

        '/Refrescando el DataSource de DgvUsu
        Dgv.refrescarFuenteDatosGrilla(Me.DgvLista, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvLista, cam.ClaveDocuCtaCte, "Clave", 90)
        Dgv.asignarColumnaText(Me.DgvLista, cam.CodAux, "RUC", 90)
        Dgv.asignarColumnaText(Me.DgvLista, cam.CodTipDoc, "TD", 50)
        Dgv.asignarColumnaText(Me.DgvLista, cam.SerDoC, "Serie", 50)
        Dgv.asignarColumnaText(Me.DgvLista, cam.NumDoc, "Numero", 100)
        Dgv.asignarColumnaText(Me.DgvLista, cam.FecDoc, "Fecha", 80)
        Dgv.asignarColumnaText(Me.DgvLista, cam.MonDoc, "Moneda", 50)
        Dgv.AsignarColumnaTextNumerico(Me.DgvLista, cam.VenTipCam, "T.C", 50, 3)
        Dgv.AsignarColumnaTextNumerico(Me.DgvLista, cam.ImpOriCtaCte, "Monto", 90, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvLista, cam.ImpPagCtaCte, "Pagado", 90, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvLista, cam.SalCtaCte, "Saldo", 90, 2)

        '\\
    End Sub

    Sub DevolverDatos()

        If Me.DgvLista.Rows.Count = 0 Then
            Exit Sub
        Else
            'buscas en bd el codigo con su tipo de tabla
            ent.ClaveDocumentoCuentaCorriente = Dgv.obtenerValorCelda(Me.DgvLista, cam.ClaveDocuCtaCte)
            ent = ccte.buscarCuentaCorrienteExisPorClaveDoc(ent)
        End If
        Me.txt1.Text = ent.CodigoAuxiliar
        Me.txt2.Text = ent.TipoDocumento
        Me.txt3.Text = ent.SerieDocumento
        Me.txt4.Text = ent.NumeroDocumento
        Me.dtp1.Text = ent.FechaDocumento.ToString
        Me.txt6.Text = ent.MonedaDocumento
        Me.txt7.Text = ent.VentaTipoCambio.ToString
        Me.txt8.Text = ent.SaldoCuentaCorriente.ToString
        Me.txt10.Text = ent.NombreDocumento.ToString
        Gb.pasarDato(Me.grup, ent.MonedaDocumento)
        ''Segun Moneda
        Select Case ent.MonedaDocumento
            Case "S/."
                Me.txt5.Text = ent.SaldoCuentaCorriente.ToString  '' Txt5 es importe en soles
                Me.txt9.Text = Varios.numeroConDosDecimal((ent.SaldoCuentaCorriente / ent.VentaTipoCambio).ToString)  ''  Txt9 es importe es US$
            Case "US$"
                Me.txt5.Text = Varios.numeroConDosDecimal((ent.SaldoCuentaCorriente * ent.VentaTipoCambio).ToString)
                Me.txt9.Text = ent.SaldoCuentaCorriente.ToString
        End Select

        Me.ctrlFoco.Focus()
        Me.Close()
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
        Dgv.BusquedaInteligenteEnColumna(Me.DgvLista, xcampoorden, Me.txtBus, e)
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub DgvLista_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvLista.CellDoubleClick
        Me.DevolverDatos()
    End Sub

    Private Sub DgvDis_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvLista.ColumnHeaderMouseClick
        xcampoorden = Me.DgvLista.Columns(e.ColumnIndex).Name
        Me.campoBusqueda = Me.DgvLista.Columns(e.ColumnIndex).HeaderText
        Me.ActualizarVentana()
    End Sub

End Class