Imports Entidad
Imports Negocio

Public Class WListarAuxiliar
    Public lista As New List(Of SuperEntidad)
    Public ent As New SuperEntidad
    Dim aux As New AuxiliarRN
    Public tabla As String
    Public titulo As String
    Public campoBusqueda As String
    Public txt1 As New TextBox
    Public txt2 As New TextBox
    Public txt3 As New TextBox
    Public txt4 As New TextBox
    Public cam As New CamposEntidad
    Public ctrlFoco As New Control

#Region "Propietarios"
    Public wEditRegCom As WEditarRegistroCompra
    Public wEditRegVta As WEditarRegistroVenta
    Public wEditRegHon As WEditarRegistroHonorario
    Public wEditRegCajBco As WEditarRegistroCajaBanco
    Public wEditRegCajBcoDet As WDetalleRegCajaBanco
    Public wDocXPag As WDocumentosAPagar
    Public wDocXCob As WDocumentosACobrar
    Public wExtorno As WEstornarIngEgr
    Public wEditRegDiaDet As WDetalleRegDiario
    Public wEditRegDiaDet1 As WDetalleRegDiario1
    Public wImpAnaAuxTod As WImpAnalisisAuxiliaresTodos
    Public wImpAnaAuxSal As WImpAnalisisAuxiliaresSaldo
    Public wImpAnaAuxSalNew As WImpAnalisisAuxiliaresSaldoNew
    Public wEditCtacte As WEditarCuentaCorriente
    Public wImpHon As wImpHonorarios
    Public wVouTod As WModificarDocumento
    Public wImpAnaAuxSalNue As WImpAnalisisAuxiliaresSaldoNuevo

#End Region

#Region "Metodos"

    Sub NuevaVentana()
        '//
        Me.Show()
        'Me.Owner.Enabled = False
        'orden de la grilla por defecto -->Descripcion
        ent.CampoOrden = cam.DesAux
        'En que columna se va a buscar por defecto -->Descripcion
        Me.campoBusqueda = "Descripcion"
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

        Select Case Me.tabla

            Case "Personal"
                lista = aux.ListarPersonal(ent)
            Case "Ambos"
                lista = aux.ListarClienteProveedor(ent)
            Case "Cliente"
                lista = aux.ListarCliente(ent)
            Case "Proveedor"
                lista = aux.ListarProveedor(ent)
            Case "Cliente/ClienteProveedor"
                lista = aux.ListarClienteYClienteProveedor(ent)
            Case "Proveedor/ClienteProveedor"
                lista = aux.ListarProveedorYClienteProveedor(ent)
            Case "Proveedor/ClienteProveedorActivos"
                lista = aux.ListarProveedorYClienteProveedorActivos(ent)
            Case "Todos"
                lista = aux.ListarAuxiliaresExistentesActivos(ent)
        End Select
        '/Refrescando el DataSource de DgvUsu
        Dgv.refrescarFuenteDatosGrilla(Me.DgvLista, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvLista, cam.CodAux, "Codigo", 90)
        Dgv.asignarColumnaText(Me.DgvLista, cam.DesAux, "Descripcion", 300)
        Dgv.asignarColumnaText(Me.DgvLista, cam.TipAux, "Tipo", 80)

        '\\
    End Sub

    Sub DevolverDatos()

        If Me.DgvLista.Rows.Count = 0 Then
            Exit Sub
        Else
            'buscas en bd el codigo con su tipo de tabla
            If Me.tabla = "Todos" Then
                ent.CodigoAuxiliar = Dgv.obtenerValorCelda(Me.DgvLista, cam.CodAux)
                ent = aux.buscarAuxiliarExisPorCodigo(ent)
            Else

                ent.CodigoAuxiliar = Dgv.obtenerValorCelda(Me.DgvLista, cam.CodAux)
                ent = aux.buscarAuxiliarExisPorCodigo(ent)
            End If
            Me.txt1.Text = ent.CodigoAuxiliar
            Me.txt2.Text = ent.DescripcionAuxiliar
            Me.txt3.Text = ent.DescripcionAuxiliar
            Me.txt4.Text = ent.FechaInscripcionSnpAuxiliar
        End If

            'Me.txt1.Focus()
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

    Private Sub WListarAuxiliar_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ' Me.Owner.Enabled = True
    End Sub
End Class