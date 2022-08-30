Imports Entidad
Imports Negocio

Public Class WSelecionaAuxiliar
#Region "Propietarios"
    Public wAux As New WAuxiliar
#End Region

    Public ent As New SuperEntidad
    Public aux As New AuxiliarRN
    Public cam As New CamposEntidad
    Public titulo As String


#Region "Metodos"


    Sub InicializaVentana()
        '/Ejecucion en ventana
        Me.Owner.Enabled = False
        Me.Show()
    End Sub

    Sub Aceptar()

        Dim tip As String = Rbt.radioActivo(Me.gbTipAux).Text.Trim.ToUpper
        If tip = "PERSONA NATURAL" Then
            Dim win As New WEditarAuxiliarPer
            win.wAux = Me.wAux
            Me.wAux.titulo = "Persona Natural"
            win.operacion = 0
            Me.wAux.AddOwnedForm(win)
            win.ventanaAdicionar()
        Else
            Dim win As New WEditarAuxiliar
            win.wAux = Me.wAux
            win.wAux.titulo = "Persona Juridica"
            win.operacion = 0
            Me.wAux.AddOwnedForm(win)
            win.ventanaAdicionar()
        End If

        Me.Close()

    End Sub

#End Region

    Private Sub WEditarPersonal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Me.Owner.Enabled = True
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.Aceptar()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Dim rpta As Integer = MsgBox("Deseas cancelar la operacion", MsgBoxStyle.YesNo, "Cliente")
        If rpta = MsgBoxResult.Yes Then
            Me.Owner.Enabled = True
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

End Class