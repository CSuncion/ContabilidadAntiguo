Imports Entidad
Imports Negocio

Public Class WCopiarFormatoContable

#Region "Propietarios"
    Public wFcon As New WFormatoContable
#End Region

    Public listaPc, listaPcE As New List(Of SuperEntidad)
    '   Public cue As New PlanDeCuentasRN
    Public emp As New EmpresaRN
    Public empfcon As New FormatoContableRN
    Public cam As New CamposEntidad
    Public ent As New SuperEntidad
    Public titulo As String = "Plan De Cuentas"
    Public cemp As String

#Region "Metodos"

    Sub NuevaVentana(ByVal CodEmp As String)
        '//
        Me.Owner.Enabled = False
        Me.Show()
        'visualiza el formulario
        cemp = CodEmp
        Me.valoresPorDefecto(cemp)
        '\\
    End Sub

    Sub valoresPorDefecto(ByRef CodEmp As String)
        Dim entEmp As New SuperEntidad
        entEmp.CodigoEmpresa = CodEmp
        entEmp = emp.buscarEmpresaExisPorCodigo(entEmp)
        Me.txtCodEmp.Text = entEmp.CodigoEmpresa
        Me.txtNomEmp.Text = entEmp.RazonSocialEmpresa
    End Sub

    Sub ListarEmpresas(ByVal e As System.Windows.Forms.KeyEventArgs)
        If Me.txtCodEmpC.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarEmpresa
                win.titulo = "Empresas"
                win.tabla = "Todos"
                win.txt1 = Me.txtCodEmpC
                win.txt2 = Me.txtNomEmpC
                win.ctrlFoco = Me.btnAceptar
                win.NuevaVentana()
            End If
        End If
    End Sub

    Function ExisteEmpresa() As Boolean
        Dim obE As New SuperEntidad
        obE.CodigoEmpresa = Me.txtCodEmpC.Text.Trim
        If obE.CodigoEmpresa = "" Then
            Me.ObtenerEmpresa(obE)
            Return True
        Else
            obE = emp.buscarEmpresaExisPorCodigo(obE)
            If obE.CodigoEmpresa = "" Then
                MsgBox("La empresa no existe", MsgBoxStyle.Exclamation, Me.titulo)
                Me.ObtenerEmpresa(obE)
                Me.txtCodEmpC.Focus()
                Return False
            Else
                Me.ObtenerEmpresa(obE)
                Return True
            End If
        End If
    End Function

    Function EmpresaCopiaDiferente() As Boolean
        Dim eAct As String = Me.txtCodEmp.Text.Trim
        Dim eCop As String = Me.txtCodEmpC.Text.Trim
        If eCop = "" Then
            Return True
        Else
            If eCop = eAct Then
                MsgBox("No se puede hacer la copia de la misma empresa", MsgBoxStyle.Exclamation, Me.titulo)
                Me.ObtenerEmpresa(emp.EmpresaIni)
                Me.txtCodEmpC.Focus()
                Return False
            Else
                Return True
            End If
        End If
    End Function

    Function EmpresaCopiaConCuentas() As Boolean
        Dim obE As New SuperEntidad
        obE.CodigoEmpresa = Me.txtCodEmpC.Text.Trim
        If obE.CodigoEmpresa = "" Then
            Return True
        Else
            Dim listForCon As New List(Of SuperEntidad)
            obE.CampoOrden = cam.CodForCon
            listForCon = empfcon.obtenerFormatoContableExis(obE)
            If listForCon.Count = 0 Then
                MsgBox("Esta empresa no tiene formato contable para copiar", MsgBoxStyle.Exclamation, Me.titulo)
                Me.ObtenerEmpresa(emp.EmpresaIni)
                Me.txtCodEmpC.Focus()
                Return False
            Else
                Return True
            End If
        End If
    End Function

    Function EmpresaCopiaDisponible() As Boolean
        If Me.ExisteEmpresa = False Then Return False
        If Me.EmpresaCopiaDiferente = False Then Return False
        If Me.EmpresaCopiaConCuentas = False Then Return False
        'Si todo sale bien
        Return True
    End Function

    Function EmpresaBaseConFormatoContable() As Boolean
        Dim obE As New SuperEntidad
        obE.CodigoEmpresa = Me.txtCodEmp.Text.Trim
        If empfcon.existeformatocontableEnEmpresa(obE) = True Then
            Return True
        Else
            Return False
        End If
    End Function

    Sub ObtenerEmpresa(ByVal oEmp As SuperEntidad)
        '/Pasar Datos a los controles
        Me.txtCodEmpC.Text = oEmp.CodigoEmpresa
        Me.txtNomEmpC.Text = oEmp.RazonSocialEmpresa
    End Sub

    Sub Copia()
        'DEBE DIGITAR LA EMPRESA DE COPIA
        If Me.txtCodEmpC.Text.Trim = "" Then
            MsgBox("Digite la empresa de donde desea hacer la copia", MsgBoxStyle.Information, "Copia Plan de cuentas")
            Me.txtCodEmpC.Focus()
            Exit Sub
        End If

        'Ver la disponibilidad de la empresa copia
        If Me.EmpresaCopiaDisponible = False Then Exit Sub
        'Preguntar si la empresa a la que se quiere pasar la copia tiene cuentas registradas
        If Me.EmpresaBaseConFormatoContable() = True Then
            'Preguntar si se desea remplazar
            Dim rpta As Integer = MsgBox("La empresa de codigo : " + Me.txtCodEmp.Text.Trim + " ya tiene formato contable deseas reemplazarlas", MsgBoxStyle.YesNo, Me.titulo)
            If rpta = MsgBoxResult.Yes Then
                'Eliminar las cuentas que tiene la empresa base
                Me.EliminarCuentasEmpresaBase()
                'Adicionar las nuevas cuentas
                Me.AdicionarCuentas()
            Else
                Exit Sub
            End If
        Else
            Dim rpta As Integer = MsgBox("Deseas copiar formato contable", MsgBoxStyle.YesNo, Me.titulo)
            If rpta = MsgBoxResult.Yes Then
                'Adicionar las nuevas cuentas
                Me.AdicionarCuentas()
            Else
                Exit Sub
            End If
        End If
    End Sub

    Sub AdicionarCuentas()
        Dim lis As New List(Of SuperEntidad)
        Dim obE As New SuperEntidad
        obE.CodigoEmpresa = Me.txtCodEmpC.Text.Trim
        ' obE.CampoOrden = cam.CodCtaPcge
        obE.CampoOrden = cam.CodForCon
        lis = empfcon.obtenerFormatoContableExis(obE)
        'Recorrer las cuentas 
        For Each obj As SuperEntidad In lis
            'Solo cambiar por la empresa base
            obj.CodigoEmpresa = Me.txtCodEmp.Text.Trim
            'Grabar
            empfcon.nuevaFormatoContable(obj)
        Next
        MsgBox("La copia se realiza satisfactoriamente", MsgBoxStyle.Information, Me.titulo)
    End Sub

    Sub EliminarCuentasEmpresaBase()
        'Eliminar las cuentas de la empresa base
        Dim obE As New SuperEntidad
        obE.CodigoEmpresa = Me.txtCodEmp.Text.Trim
        empfcon.eliminarFormatoContableFis(obE)
    End Sub


#End Region

    Private Sub WEditarTabla_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub txtCodEmpC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodEmpC.KeyDown
        Me.ListarEmpresas(e)
    End Sub

    Private Sub txtCodEmpC_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodEmpC.Validated
        Me.EmpresaCopiaDisponible()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.Copia()
    End Sub
End Class