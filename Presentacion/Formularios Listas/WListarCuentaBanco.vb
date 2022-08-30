Imports Entidad
Imports Negocio

Public Class WListarCuentaBanco
    Public lista As New List(Of SuperEntidad)
    Public ent As New SuperEntidad
    Dim cb As New CuentaBancoRN
    Public tabla As String
    Public titulo As String
    Public campoBusqueda As String
    Public txt1 As New TextBox
    Public txt2 As New TextBox
    Public txt3 As New TextBox
    Public txt4 As New TextBox
    Public txt5 As New TextBox
    Public cam As New CamposEntidad
    Public ctrlFoco As New Control

#Region "Metodos"

    Sub NuevaVentana()
        '//
        Me.Show()
        'orden de la grilla por defecto -->Descripcion
        ent.CampoOrden = cam.CodCtaBco
        'En que columna se va a buscar por defecto -->Descripcion
        Me.campoBusqueda = "Codigo"
        Me.Text = "Listado de " + Me.titulo
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
        ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        Select Case Me.tabla

            Case "Todos"
                lista = cb.obtenerCuentaBancoExis(ent)
            Case "PorEmpresa"
                'ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
                lista = cb.obtenerCuentaBancoExis(ent)
            Case "PorEmpresaYMoneda"

                Select Case ent.MonedaCuentaBanco
                    Case "S/." : ent.MonedaCuentaBanco = "0"
                    Case "US$" : ent.MonedaCuentaBanco = "1"
                    Case "EUR" : ent.MonedaCuentaBanco = "2"
                End Select
                lista = cb.obtenerCuentaBancoExisYMoneda(ent)
        End Select
        '/Refrescando el DataSource de DgvUsu
        Dgv.refrescarFuenteDatosGrilla(Me.DgvLista, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvLista, cam.CodCtaBco, "Codigo", 90)
        Dgv.asignarColumnaText(Me.DgvLista, cam.BcoCtaBco, "Banco", 150)
        Dgv.asignarColumnaText(Me.DgvLista, cam.NumCtaBco, "Numero Cuenta", 150)
        Dgv.asignarColumnaText(Me.DgvLista, cam.MonCtaBco, "Moneda Cuenta", 60)
        Dgv.asignarColumnaTextVis(Me.DgvLista, cam.ClaCtaBco, "Clave", 90, 1)
        '\\
    End Sub

    Sub DevolverDatos()
        If Me.DgvLista.Rows.Count = 0 Then
            Exit Sub
        Else
            'buscas en bd el codigo con su tipo de tabla
            'If Me.tabla = "Todos" Then
            ent.ClaveCuentaBanco = Dgv.obtenerValorCelda(Me.DgvLista, cam.ClaCtaBco)
            ent = cb.buscarCuentaBancoExisPorCodigo(ent)
        End If
        Me.txt1.Text = ent.CodigoCuentaBanco
        Me.txt2.Text = ent.BancoCuentaBanco
        Me.txt3.Text = ent.NumeroCuentaBanco
        Me.txt4.Text = ent.MonedaCuentaBanco
        Me.ctrlFoco.Focus()
        Me.Close()

    End Sub

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
#End Region

End Class