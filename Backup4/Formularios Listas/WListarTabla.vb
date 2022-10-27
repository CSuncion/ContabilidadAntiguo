Imports Entidad


Imports Negocio

Public Class WListarTabla
    Public lista As New List(Of SuperEntidad)
    Public ent As New SuperEntidad
    Dim tab As New TablaRN
    Public tabla As String
    Public tipoTabla As String 'va a salir
    Public titulo As String 'va a salir
    Public campoBusqueda As String
    Public txt1 As New TextBox
    Public txt2 As New TextBox
    Public cam As New CamposEntidad
    Public condicion As String
    Public ctrlFoco As New Control

#Region "Metodos"

    Sub NuevaVentana()
        '//
        Me.Show()
        'orden de la grilla por defecto -->Descripcion
        ent.CampoOrden = cam.NomItemTabla
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

            Case "ModoPago"
                ent.DatoCondicion1 = "Mod"
            Case "Cuenta42"
                ent.DatoCondicion1 = "Cue"
            Case "CentroCosto"
                ent.DatoCondicion1 = "Cto"
            Case "Origen"
                ent.DatoCondicion1 = "Ori"
            Case "File"
                ent.DatoCondicion1 = "Fil"
            Case "Distrito"
                ent.DatoCondicion1 = "Dis"
            Case "Area"
                ent.DatoCondicion1 = "Are"
            Case "Unidad"
                ent.DatoCondicion1 = "Uni"
            Case "TipoDocumentoIdentidad"
                ent.DatoCondicion1 = "Tdi"
            Case "PaisNoDomiciliadoAuxiliar"
                ent.DatoCondicion1 = "Pai"
            Case "CC"
                ent.DatoCondicion1 = "Cc"
            Case "Documento"
                ent.DatoCondicion1 = "Doc"
            Case "Cuenta"
                ent.DatoCondicion1 = "Cue"
            Case "ConceptoVenta"
                ent.DatoCondicion1 = "CoV"
            Case "ParaCompras"
                ent.DatoCondicion1 = "Cpt"
            Case "Ingresos/Egresos"
                ent.DatoCondicion1 = "Ies"
            Case "Mes"
                ent.DatoCondicion1 = "Mes"
            Case "Files"
                ent.DatoCondicion1 = "Fil"
            Case "Contrato Planilla/Servivio"
                ent.DatoCondicion1 = "Cps"
            Case "Contrato Servicio"
                ent.DatoCondicion1 = "Cps"
            Case "Movilizacion"
                ent.DatoCondicion1 = "Mov"
            Case "Materiales y Otros"
                ent.DatoCondicion1 = "MaO"
            Case "Reembolsables"
                ent.DatoCondicion1 = "Ree"

        End Select
        '/Cargamos la tabla con el filtro del tipo de tabla
        Select Case Me.tabla
            Case "File"
                lista = tab.obtenerItemsTablaExisActPorTipoTablayFiltroCodigo(ent)
            Case "ParaCompras"
                lista = tab.obtenerConceptosParaCompras(ent)
            Case "Contrato Planilla/Servivio"
                ent.DatoFiltro1 = "0201"
                lista = tab.obtenerItemsTablaExisPorTipoTablayFiltroCodigoDeProyecto(ent)
            Case "Contrato Servicio"
                ent.DatoFiltro1 = "0202"
                lista = tab.obtenerItemsTablaExisPorTipoTablayFiltroCodigoDeProyecto(ent)
            Case "Ingresos/Egresos"
                Select Case Me.titulo
                    Case "Ingresos"
                        ent.DatoFiltro1 = "1"
                        lista = tab.obtenerItemsTablaExisPorTipoTablayFiltroCodigo(ent)
                    Case "Egresos"
                        ent.DatoFiltro1 = "2"
                        lista = tab.obtenerItemsTablaExisPorTipoTablayFiltroCodigo(ent)
                    Case Else
                        lista = tab.obtenerItemsTablaExisActPorTipoTabla(ent)
                End Select
            Case "Origen"
                Select Case Me.condicion
                    Case "1Y2"
                        lista = tab.obtenerItemsTablaExisActPorTipoTablay1Y2(ent)
                End Select
            Case "Movilizacion", "Materiales y Otros", "Reembolsables"
                lista = tab.obtenerItemsTablaExisActPorTipoTablaDeProyecto(ent)
            Case "Files"
                lista = tab.obtenerItemsTablaExisActPorTipoTablayFiltroCodigo(ent)
            Case Else
                lista = tab.obtenerItemsTablaExisActPorTipoTabla(ent)

        End Select
        '/Refrescando el DataSource de DgvUsu
        Dgv.refrescarFuenteDatosGrilla(Me.DgvLista, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvLista, cam.CodItemTabla, "Codigo", 60)
        Dgv.asignarColumnaText(Me.DgvLista, cam.NomItemTabla, "Descripcion", 160)
        '\\
    End Sub

    Sub DevolverDatos()
        If Me.DgvLista.Rows.Count = 0 Then
            Exit Sub
        Else
            'buscas en bd el codigo con su tipo de tabla
            ent.DatoCondicion2 = Dgv.obtenerValorCelda(Me.DgvLista, 0)
            If ent.DatoCondicion1 = "Cps" Or ent.DatoCondicion1 = "Mov" Or ent.DatoCondicion1 = "MaO" Or ent.DatoCondicion1 = "Ree" Then
                ent = tab.buscarItemTablaExisPorTipoTablaYCodigoDeProyecto(ent)
            Else
                ent = tab.buscarItemTablaExisPorTipoTablaYCodigo(ent)
            End If

            Me.txt1.Text = ent.CodigoItemTabla
            Me.txt2.Text = ent.NombreItemTabla
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