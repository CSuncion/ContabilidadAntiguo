
Imports Entidad
Imports Negocio

Public Class WListarPlanCuentaGe
    Public lista As New List(Of SuperEntidad)
    Public ent, entpar As New SuperEntidad
    Dim pcge As New PlanCuentaGeRN
    Dim par As New ParametroRN
    Public tabla As String
    Public titulo As String
    Public campoBusqueda As String
    Public txt1 As New TextBox
    Public txt2 As New TextBox
    Public cam As New CamposEntidad

    Public ctrlFoco As New Control


#Region "Metodos"

    Sub NuevaVentana()

        '//
        Me.Show()
        entpar = par.buscarParametroExis(entpar)
        'orden de la grilla por defecto -->Descripcion
        'ent.CampoOrden = cam.NomCtaPcge
        ent.CampoOrden = cam.CodCtaPcge
        'En que columna se va a buscar por defecto -->Descripcion
        'Me.campoBusqueda = "Nombre Cuenta"
        Me.campoBusqueda = "Codigo Cuenta"
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

            Case "CuentasAutomaticas"
                ent.FlagAutomaticaPcge = "1"
                lista = pcge.obtenerCuentaExisAutomaticas(ent)
            Case "CuentasAnaliticas"
                ent.NumeroDigitosPcge = entpar.DigitosCuentaAnalitica
                ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
                lista = pcge.obtenerCuentaExisAnaliticas(ent)
            Case "CuentasAnaliticas4243"
                ent.NumeroDigitosPcge = entpar.DigitosCuentaAnalitica
                ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
                lista = pcge.obtenerCuentaExisAnaliticas42A43(ent)
            Case "CuentasAnaliticas4247"
                ent.NumeroDigitosPcge = entpar.DigitosCuentaAnalitica
                ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
                lista = pcge.obtenerCuentaExisAnaliticas42A47(ent)
            Case "CuentasAnaliticas1213"
                ent.NumeroDigitosPcge = entpar.DigitosCuentaAnalitica
                ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
                lista = pcge.obtenerCuentaExisAnaliticas12A13(ent)
            Case "CuentasAnaliticas70"
                ent.NumeroDigitosPcge = entpar.DigitosCuentaAnalitica
                ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
                lista = pcge.obtenerCuentaExisAnaliticas70(ent)
            Case "CuentasAnaliticasNoBancarias"
                ent.NumeroDigitosPcge = entpar.DigitosCuentaAnalitica
                lista = pcge.ListarCuentaAnaliticaNoBancaria(ent)
            Case "CuentasADosDigitos"
                ent.NumeroDigitosPcge = "2"
                ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
                lista = pcge.obtenerCuentaExisAnaliticas(ent)
            Case "TodosMenos104"
                ent.NumeroDigitosPcge = entpar.DigitosCuentaAnalitica
                ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
                lista = pcge.obtenerCuentaExisAnaliticas(ent)
            Case "Todos"
                ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
                lista = pcge.obtenerCuentaExis(ent)
        End Select

        '/Refrescando el DataSource de DgvUsu
        Dgv.refrescarFuenteDatosGrilla(Me.DgvLista, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvLista, cam.CodCtaPcge, "Cuenta", 90)
        Dgv.asignarColumnaText(Me.DgvLista, cam.NomCtaPcge, "Nombre Cuenta", 300)
        Dgv.asignarColumnaText(Me.DgvLista, cam.FlaAlmPcge, "Almacen", 60)
        Dgv.asignarColumnaText(Me.DgvLista, cam.FlaCtoPcge, "CenCto", 60)
        Dgv.asignarColumnaText(Me.DgvLista, cam.CodEmp, "Empresa", 80)
        Dgv.asignarColumnaText(Me.DgvLista, cam.ClaCtaPcge, "Clave", 90)
        '\\
    End Sub

    Sub DevolverDatos()

        If Me.DgvLista.Rows.Count = 0 Then
            Exit Sub
        Else
            'buscas en bd el codigo con su tipo de tabla
            If Me.tabla = "Todos" Then
                ent.CodigoCuentaPcge = Dgv.obtenerValorCelda(Me.DgvLista, 0)
                ent = pcge.buscarCuentaExisPorCodigo(ent)
            Else
                ent.ClaveCuentaPcge = Dgv.obtenerValorCelda(Me.DgvLista, cam.ClaCtaPcge)
                'ent.NumeroDigitosPcge = entpar.DigitosCuentaAnalitica
                ent = pcge.buscarCuentaExisPorClaveyAnalitica(ent)
            End If

            Me.txt1.Text = ent.CodigoCuentaPcge
            Me.txt2.Text = ent.NombreCuentaPcge
            Me.ctrlFoco.Focus()
            Me.Close()
        End If

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
End Class