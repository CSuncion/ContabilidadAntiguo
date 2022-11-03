Imports Entidad
Imports Negocio

Public Class WEditarFormatoContable
#Region "Propietarios"
    Public wfcon As New WFormatoContable
#End Region

    Dim valorRef As String

    Public ent As New SuperEntidad
    Public lista As New List(Of SuperEntidad)
    Public cam As New CamposEntidad
    Public tab As New TablaRN
    Public fcon As New FormatoContableRN
    Public acc As New Accion
    Public operacion As Integer  '0=agregar , 1=modificar , 2=eliminar , 3=visualizar
#Region "Metodos"
    Sub InicializaVentana()
        '/Para los eventos de controles
        acc.listaCtrls = Me.ListaControles
        acc.PasaFoco()
        acc.FomatoDato()
        acc.PasarCursor()
        acc.Teclazo()
        acc.Valida()
        '/Ejecucion en ventana
        Me.Owner.Enabled = False
        Me.Show()

    End Sub

    Sub PorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.txtNomEmp.Text = SuperEntidad.xRazonSocial

    End Sub

    Sub ventanaAdicionar()
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Agregar " + Me.wfcon.titulo
        acc.LimpiarControles()
        'por defecto
        Me.PorDefecto()
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtCodForCon)
        'los controles que deben estar activos
        acc.Nuevo()
        '\\
    End Sub

    Sub ventanaModificar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Modificar " + Me.wfcon.titulo
        'mostrar el registro en pantalla
        Me.obtenerFormatoContableEnPantalla(codigo)
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtDesForCon)
        'los controles que deben estar activos
        acc.Modificar()
        '\\
    End Sub

    Sub ventanaEliminar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Eliminar " + Me.wfcon.titulo
        'mostrar el registro en pantalla
        Me.obtenerFormatoContableEnPantalla(codigo)
        'foco
        Me.btnAceptar.Focus()
        'los controles que deben estar activos
        acc.Eliminar()
        '\\
    End Sub

    Sub ventanaVisualizar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Visualizar " + Me.wfcon.titulo
        'mostrar el registro en pantalla
        Me.obtenerFormatoContableEnPantalla(codigo)
        'foco
        Me.btnAceptar.Focus()
        'los controles que deben estar activos
        acc.Visualizar()
        '\\
    End Sub

    Sub obtenerFormatoContableEnPantalla(ByRef cod As String)
        '//
        'Buscamos el registro de codigo "Cod"
        ent.ClaveFormatoContable = cod
        ent = fcon.buscarFormatoContableExisPorClave(ent)
        'preguntar si ent tiene el registro
        If ent.ClaveFormatoContable = "" Then
            Exit Sub
        Else
            '/Pasar Datos a los controles
            Me.TxtCodEmp.Text = ent.CodigoEmpresa
            Me.txtNomEmp.Text = ent.RazonSocialEmpresa
            Me.txtCodForCon.Text = ent.CodigoFormatoContable
            Me.txtDesForCon.Text = ent.DescripcionFormatoContable
            Gb.pasarDato(Me.gbAgrupar, ent.GrupoFormatoContable)
            Gb.pasarDato(Me.GbNaturaleza, ent.NaturalezaFormatoContable)
            Gb.pasarDato(Me.GbEstado, ent.EstadoFormatoContable)
            Me.TxtDes1ForCon.Text = ent.Descripcion1FormatoContable
        End If
        '\\
    End Sub

    Sub Aceptar()
        '// Lo ques graba en la tabla
        If Me.operacion = 1 Or Me.operacion = 2 Then
            'Volver a traer el registro 
            'ent.ClaveFormatoContable = ent.ClaveFormatoContable
            'MsgBox(ent.ClaveFormatoContable)
            ent.DatoCondicion1 = ent.ClaveFormatoContable
            ent = fcon.buscarFormatoContableExisPorClave(ent)
        End If
        ent.CodigoEmpresa = Me.TxtCodEmp.Text.Trim()
        ent.CodigoFormatoContable = Me.txtCodForCon.Text.Trim()
        ent.DescripcionFormatoContable = Me.txtDesForCon.Text.Trim()
        ent.GrupoFormatoContable = Rbt.radioActivo(Me.gbAgrupar).Text.Trim
        ent.NaturalezaFormatoContable = Rbt.radioActivo(Me.GbNaturaleza).Text.Trim
        ent.EstadoFormatoContable = Rbt.radioActivo(Me.GbEstado).Text.Trim

        ent.ImporteSolesFormatoContable = 0
        ent.ImporteDolaresFormatoContable = 0
        ent.ImporteEurosFormatoContable = 0

        'ent.EstadoCuenta = Rbt.radioActivo(Me.gbEstado).Text.Trim()
        ent.Descripcion1FormatoContable = Me.TxtDes1ForCon.Text.Trim()
        ent.Exporta = "0"

        '/Se graba o0 se modifica?
        Select Case Me.operacion

            Case 0
                'ent.EstadoComprobante = "Activo"  ''Cuando no se ve en pantalla sino arriba
                ''Obtener codigo autogenerado
                'ent.CodigoCliente = cli.obtenerCodigoClienteAutogenerado()
                'Nuevo registro
                fcon.nuevaFormatoContable(ent)

                MsgBox(Me.wfcon.titulo + " ingresado correctamente", MsgBoxStyle.Information, Me.wfcon.titulo)
                'Limpiamos los controles para un nuevo registro
                acc.LimpiarControles()
                Me.txtCodForCon.Focus()

            Case 1
                'Modificar Registro
                fcon.modificarFormatoContable(ent)
                MsgBox(Me.wfcon.titulo + " modificado correctamente", MsgBoxStyle.Information, Me.wfcon.titulo)
                Me.Close()

            Case 2
                'eliminamos al usuario pero logicamente
                fcon.eliminarFormatoContableLog(ent)
                MsgBox(Me.wfcon.titulo + " Eliminado correctamente", MsgBoxStyle.Information, Me.wfcon.titulo)
                Me.Close()

        End Select
        '/Actualizar y buscar el registro grabado
        Me.wfcon.ActualizarVentana()
        Dgv.obtenerCursorActual(Me.wfcon.DgvFcon, ent.CodigoFormatoContable, Me.wfcon.lista)
        '\\
    End Sub

#End Region

    Private Sub WEditarTabla_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        'Solo para eliminar
        If Me.operacion = 2 Then
            Dim rpta As Integer = MsgBox("Deseas eliminar este registro", MsgBoxStyle.YesNo, Me.wfcon.titulo)
            If rpta = MsgBoxResult.Yes Then
                Me.Aceptar()
                Exit Sub
            Else
                Exit Sub
            End If
        End If
        'para agregar o modificar
        If acc.CamposObligatorios = False Then
            Exit Sub
        Else
            Me.Aceptar()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If Me.operacion = 3 Then
            Me.Close()
        Else
            Dim rpta As Integer = MsgBox("Deseas cancelar la operacion", MsgBoxStyle.YesNo, Me.wfcon.titulo)
            If rpta = MsgBoxResult.Yes Then
                Me.Close()
            Else
                Exit Sub
            End If
        End If
    End Sub

#Region "Mostrar Form Listas"
#End Region

#Region "Buscar Por Codigo"
  
#End Region

#Region "existe FormatoContable"

    Private Sub txtCodForCon_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodForCon.Validated
        'Se busca en toda la tabla CuentaBanco
        If Me.ComprobarClaveformatoContable() = True Then
            Me.txtCodForCon.Text = ""
            Me.txtCodForCon.Focus()
            'e.Cancel = True
        Else
            Exit Sub
        End If
    End Sub

#End Region

#Region "Existe Codigo"

    Function ComprobarClaveFormatoContable() As Boolean
        '/
        If Me.operacion = 0 Then 'Solo cuando Agrega

            Dim cod As String = Me.TxtCodEmp.Text.Trim + Me.txtCodForCon.Text.Trim
            If cod = "" Then
                Return False
            Else
                Dim obj As New SuperEntidad
                obj.ClaveFormatoContable = cod
                'Se busca en toda la tabla
                If fcon.existeFormatoContablePorClave(obj) = True Then
                    MsgBox("Este Codigo ya existe", MsgBoxStyle.Information, Me.wfcon.titulo)
                    Return True
                Else
                    Return False
                End If
            End If
        Else
            Return False
        End If
    End Function

#End Region

    Private Sub txtNomEmp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNomEmp.TextChanged

    End Sub
End Class