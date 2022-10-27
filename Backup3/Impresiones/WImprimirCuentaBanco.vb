Imports Entidad
Public Class WImprimirCuentaBanco
#Region "Propietarios"
    Public wCbco As New WCuentaBanco
#End Region
    Dim cam As New CamposEntidad
    Dim tipoAux As String
#Region "Metodos"

    Sub nuevaVentana()
        '//
        Me.Owner.Enabled = False
        Me.Text = "Imprimir CuentaBanco"
        Me.InicializaVentana()
        Me.Show()
        '\\
    End Sub

    Sub InicializaVentana()
        Me.cmbFiltro.SelectedIndex = 0
        Me.cmbOrden.SelectedIndex = 0
    End Sub

    Function Filtro() As String
        Select Case Me.cmbFiltro.Text
            Case "Activos"
                Return "Activos"
            Case "Inactivos"
                Return "Inactivos"
            Case "Todos"
                Return "Todos"
            Case Else
                Return ""
        End Select
    End Function

    Function Orden() As String
        Select Case Me.cmbOrden.Text
            Case "Codigo"
                Return cam.CodCtaBco
            Case "Banco"
                Return cam.BcoCtaBco
            Case Else
                Return ""
        End Select
    End Function

    Sub PorPantalla()
        '//
        Dim win As New WRptAux
        win.ent.DatoCondicion1 = Me.Filtro
        win.ent.CampoOrden = Me.Orden
        win.PorPantalla()
        '\\
    End Sub

    Sub PorImpresora()
        '//
        Dim win As New WRptAux
        win.ent.DatoCondicion1 = Me.Filtro
        win.ent.CampoOrden = Me.Orden
        win.PorImpresora()
        '\\
    End Sub

    Sub EjecutarImpresion()
        If Me.rbtPan.Checked Then
            Me.PorPantalla()
        Else
            Me.PorImpresora()
        End If

    End Sub

#End Region


    Private Sub WImprimir_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.EjecutarImpresion()
        Me.Close()
    End Sub

End Class