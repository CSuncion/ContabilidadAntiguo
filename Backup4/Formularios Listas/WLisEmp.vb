Option Strict On
Imports Entidad
Imports Negocio


Public Class WLisEmp

#Region "Propietarios"
      Public wAcc As New WAcceso

#End Region

#Region "Enumeraciones"

      Enum Condicion
            EmpresasDeUsuario = 0

      End Enum

#End Region

      Public lisUE As New List(Of PermisoEmpresaEN)
      Public usEmEN As New PermisoEmpresaEN
      Public usEmRN As New PermisoEmpresaRN

      Public tituloVentana As String
      Public condicionLista As Integer
      Public campoBusqueda As String

      Public ctrlValor As TextBox
      Public ctrlFoco As Control

#Region "Metodos"

      Sub NuevaVentana()
            Me.Owner.Enabled = False
            usEmEN.CampoOrden = PermisoEmpresaEN.NomCorEmp
            Me.Text = "Listado de" + Space(1) + Me.tituloVentana
            Me.campoBusqueda = "Descripcion"
            Me.ActualizarVentana()
            Me.Show()
      End Sub

      Sub ActualizarVentana()
            Me.gbBus.Text = "Criterio de busqueda/Por :" + Space(1) + Me.campoBusqueda
            Me.ActualizarDgvLista()
            Dgv.PintarColumnaDgv(Me.DgvLista, usEmEN.CampoOrden)
      End Sub

      Sub ActualizarDgvLista()
            'Ejecutar segun condicon
            Select Case Me.condicionLista

                  Case Condicion.EmpresasDeUsuario
                        lisUE = usEmRN.listarEmpresasAsignadasXUsuario(usEmEN)

            End Select

        'MsgBox(lisUE.Count.ToString)
            'Llenar la grilla

        dgv.refrescarFuenteDatosGrilla(Me.DgvLista, lisUE)
        'Creando las columnas
        Dgv.asignarColumnaText(Me.DgvLista, PermisoEmpresaEN.CodEmp, "Codigo", 60)
        Dgv.asignarColumnaText(Me.DgvLista, PermisoEmpresaEN.NomCorEmp, "Descripcion", 240)
     
      End Sub



      Sub DevolverDatos()
            If Me.DgvLista.Rows.Count = 0 Then
                  Exit Sub
            Else
                  'Cargar el codigo de la franja de esta grilla
                  Me.ctrlValor.Text = Dgv.ObtenerValorCelda(Me.DgvLista, PermisoEmpresaEN.CodEmp)
                  Me.Close()
                  Me.ctrlFoco.Focus()
            End If
      End Sub

#End Region

      Private Sub WLisUsu_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            Me.Owner.Enabled = True
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
            Dgv.BusquedaInteligenteEnColumna(Me.DgvLista, usEmEN.CampoOrden, Me.txtBus, e)
      End Sub

      Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
            Me.Close()
      End Sub

      Private Sub DgvLista_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvLista.CellDoubleClick
            Me.DevolverDatos()
      End Sub

      Private Sub DgvDis_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DgvLista.ColumnHeaderMouseClick
            usEmEN.CampoOrden = Me.DgvLista.Columns(e.ColumnIndex).Name
            Me.campoBusqueda = Me.DgvLista.Columns(e.ColumnIndex).HeaderText
            Me.ActualizarVentana()
            Txt.cursorAlUltimo(Me.txtBus)
      End Sub


End Class