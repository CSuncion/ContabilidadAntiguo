Imports Entidad
Imports Negocio

Public Class WCambiaPeriodoEmpresa

    Public ent As New SuperEntidad
    Public lista As New List(Of SuperEntidad)
    Public emp As New EmpresaRN
    Public cam As New CamposEntidad
    Public cod As String
    Public acc As New Accion


#Region "Metodos"

    Sub NuevaVentana()
        Me.InicializaVentana()
        Txt.cursorAlUltimo(Me.txtPeriodo)
    End Sub


    Sub InicializaVentana()
        'Sub InicializaVentana()
        '/Ejecucion en ventana
        acc.listaCtrls = Me.ListaControles
        acc.PasaFoco()
        acc.FomatoDato()
        acc.PasarCursor()
        acc.Teclazo()
        acc.Valida()
        Me.PorDefecto()
        Me.Show()
    End Sub


    Sub PorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.TxtNomEmp.Text = SuperEntidad.xRazonSocial
        Me.txtCodUsu.Text = SuperEntidad.xCodigoUsuario
        Me.txtNomUsu.Text = SuperEntidad.xNombreUsuario
        Me.txtPeriodo.Text = SuperEntidad.xPeriodoEmpresa
        Me.TxtNomMes.Text = SuperEntidad.xMesPeriodo
    End Sub

    Function EsPeriodoDiferente() As Boolean
        'COMPARAR SI EL PERIODO QUE SE QUIERE CAMBIAR
        'ES DIFERENTE AL PERIODO ACTUAL
        Dim usEmEN As PermisoEmpresaEN = Me.BuscarUsuarioEmpresa

        'NUEVO PERIODO         
        Dim periodo As String = Me.txtPeriodo.Text.Trim

        If usEmEN.PeriodoPermisoEmpresa = periodo Then
            MsgBox("No puedes elegir el periodo actual", MsgBoxStyle.Exclamation, "Periodo")
            Return False
        Else
            Return True
        End If
    End Function

    Function BuscarUsuarioEmpresa() As PermisoEmpresaEN
        Dim usEmEN As New PermisoEmpresaEN
        Dim usEmRN As New PermisoEmpresaRN
        usEmEN.CodigoUsuario = Me.txtCodUsu.Text.Trim
        usEmEN.CodigoEmpresa = Me.txtCodEmp.Text.Trim
        usEmEN = usEmRN.buscarUsuarioEmpresa(usEmEN)
        Return usEmEN
    End Function


    Sub CambiarPerido()
        'peguntar si es otro periodo
        If Me.EsPeriodoDiferente = False Then Exit Sub

        'deseas realizar la operacion
        Dim rpta As Integer = MsgBox("Deseas realizar la operacion", MsgBoxStyle.YesNo, "Periodo")
        If rpta = MsgBoxResult.Yes Then
            'TRAER EL OBJETO PARA MODIFICAR SU PERIODO
            Dim usEmEN As PermisoEmpresaEN = Me.BuscarUsuarioEmpresa
            'NUEVO PERIODO
            Dim usEmRN As New PermisoEmpresaRN
            usEmEN.PeriodoPermisoEmpresa = Me.txtPeriodo.Text.Trim
            usEmRN.modificarUsuarioEmpresa(usEmEN)

            'actualizar las variables compartidas del periodo
            SuperEntidad.xPeriodoEmpresa = Me.txtPeriodo.Text.Trim
            SuperEntidad.xMesPeriodo = Me.TxtNomMes.Text.Trim

            'CERRAR TODOS LOS FORMULARIOS ACTIVOS EXCEPTO EL MENU 
            Me.CerrarVentanasActivas()

            MsgBox("El Periodo de la Empresa fue modificado correctamente", MsgBoxStyle.Information)
            Me.Close()
        End If


    End Sub


    Sub CerrarVentanasActivas()
        'LISTA CON TODOS LAS VENTANAS ACTIVAS A ECEPCION DE 
        '2 VENTANAS(ESPECIALES)
        Dim iListaVentanasActivas As New List(Of Form)
        For Each xObj As Form In My.Application.OpenForms
            If xObj.Name <> "WMenu" And xObj.Name <> "WCambiaPeriodoEmpresa" Then
                iListaVentanasActivas.Add(xObj)
            End If
        Next

        'CERRAR ESTAS VENTANAS
        For n As Integer = 0 To iListaVentanasActivas.Count - 1
            iListaVentanasActivas.Item(n).Close()
        Next

    End Sub

    Public Function EsPeriodoValido() As Boolean
        Dim iPerRN As New PeriodoRN
        Dim iPerEN As New SuperEntidad
        iPerEN.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        iPerEN.CodigoPeriodo = Me.txtPeriodo.Text.Trim
        iPerEN = iPerRN.EsPeriodoValido(iPerEN)
        If iPerEN.EsVerdad = False Then
            MsgBox(iPerEN.Mensaje, MsgBoxStyle.Exclamation, "Periodo")
            Me.txtPeriodo.Focus()
        End If
        Me.MostarPeriodo(iPerEN)
        Return iPerEN.EsVerdad
    End Function

    Sub MostarPeriodo(ByRef pPer As SuperEntidad)
        Me.txtPeriodo.Text = pPer.CodigoPeriodo
        Me.TxtNomMes.Text = pPer.NMesPeriodo
    End Sub



#End Region


    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.CambiarPerido()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Dim rpta As Integer = MsgBox("Deseas cancelar la operacion", MsgBoxStyle.YesNo)
        If rpta = MsgBoxResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub txtPeriodo_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPeriodo.Validating
        Me.EsPeriodoValido()
    End Sub

    Private Sub txtPeriodo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPeriodo.KeyDown
        If Me.txtPeriodo.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarPeriodos
                win.titulo = "Periodos Activos"
                win.ent.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
                win.tabla = "PeriodosActivos"
                win.txt1 = Me.txtPeriodo
                win.txt2 = Me.TxtNomMes
                win.ctrlFoco = Me.btnAceptar
                win.NuevaVentana()
            End If
        End If
    End Sub
End Class