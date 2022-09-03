Imports Entidad
Imports Negocio
Public Class WEditarCuentaBanco

#Region "Propietarios"
    Public wBco As New WCuentaBanco
#End Region

    Dim valorRef As String
    Public ent As New SuperEntidad
    Public lista As New List(Of SuperEntidad)
    Public cam As New CamposEntidad
    'Public tab As New TablaRN
    Public bco As New CuentaBancoRN
    Public sb As New SaldosBancariosRN
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

   
    Sub ventanaModificar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Modificar " + Me.wBco.titulo
        'mostrar el registro en pantalla
        Me.obtenerCuentaBancoEnPantalla(codigo)
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtBcoCb)
        'los controles que deben estar activos
        acc.Modificar()
        '\\
    End Sub

    Sub ventanaEliminar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Eliminar " + Me.wBco.titulo
        'mostrar el registro en pantalla
        Me.obtenerCuentaBancoEnPantalla(codigo)
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
        Me.Text = "Visualizar " + Me.wBco.titulo
        'mostrar el registro en pantalla
        Me.obtenerCuentaBancoEnPantalla(codigo)
        'foco
        Me.btnAceptar.Focus()
        'los controles que deben estar activos
        acc.Visualizar()
        '\\
    End Sub

    Sub obtenerCuentaBancoEnPantalla(ByRef cod As String)
        '//
        'Buscamos el registro de codigo "Cod"
        ent.ClaveCuentaBanco = cod
        ent = bco.buscarCuentaBancoExisPorCodigo(ent)
        'preguntar si ent tiene el registro
        If ent.ClaveCuentaBanco = "" Then
            Exit Sub
        Else
            '/Pasar Datos a los controles
            Me.TxtCodEmp.Text = ent.CodigoEmpresa
            Me.TxtNomEmp.Text = ent.RazonSocialEmpresa
            Me.txtCodCb.Text = ent.CodigoCuentaBanco
            Me.txtBcoCb.Text = ent.BancoCuentaBanco
            Me.TxtAgeCb.Text = ent.AgenciaCuentaBanco
            Me.TxtNumCb.Text = ent.NumeroCuentaBanco
            Gb.pasarDato(Me.gbMoneda, ent.MonedaCuentaBanco)
            Gb.pasarDato(Me.gbtipo, ent.TipoCuentaBanco)
            Me.TxtSaldo.Text = ent.SaldoCuentaBanco.ToString
            Gb.pasarDato(Me.gbEstado, ent.EstadoCuentaBanco)
        End If
        '\\
    End Sub

    Sub Aceptar()
        '// Lo ques graba en la tabla
        If Me.operacion = 1 Or Me.operacion = 2 Then
            'Volver a traer el registro 
            ent = bco.buscarCuentaBancoExisPorCodigo(ent)
        End If
        ent.CodigoEmpresa = Me.TxtCodEmp.Text.Trim()
        ent.CodigoCuentaBanco = Me.txtCodCb.Text.Trim()
        ent.BancoCuentaBanco = Me.txtBcoCb.Text.Trim()
        ent.AgenciaCuentaBanco = Me.TxtAgeCb.Text.Trim()
        ent.NumeroCuentaBanco = Me.TxtNumCb.Text.Trim()
        ent.MonedaCuentaBanco = Rbt.radioActivo(Me.gbMoneda).Text.Trim
        ent.TipoCuentaBanco = Rbt.radioActivo(Me.gbtipo).Text.Trim
        ent.SaldoCuentaBanco = CType(Me.TxtSaldo.Text.Trim, Decimal)
        ent.EstadoCuentaBanco = Rbt.radioActivo(Me.gbEstado).Text.Trim

        ent.Exporta = "0"

        '/Se graba o0 se modifica?
        Select Case Me.operacion

            Case 1
                'Modificar Registro
                bco.modificarCuentaBanco(ent)
                'Modificarf Saldo
                Me.ModificaSaldos()

                MsgBox(Me.wBco.titulo + " modificado correctamente", MsgBoxStyle.Information, Me.wBco.titulo)
                Me.Close()

        End Select
        '/Actualizar y buscar el registro grabado
        Me.wBco.ActualizarVentana()
        'Dgv.obtenerCursorActual(Me.wBco.Dgvbco, ent.CodigoCuentaBanco, Me.wBco.lista)
        Dgv.obtenerCursorActual(Me.wBco.DgvBco, ent.ClaveCuentaBanco, Me.wBco.lista)
        '\\
    End Sub

    Sub ModificaSaldos()
        Dim obj As New SuperEntidad
        obj.ClaveSaldosBancarios = SuperEntidad.xCodigoEmpresa + Me.txtCodCb.Text.Trim + SuperEntidad.xPeriodoEmpresa.Substring(0, 4) + "01"
        obj = sb.buscarSaldosBancariosExisPorClave(obj)

        'Obtener saldo anterior
        Dim isalant As Decimal = 0

        Dim sal As Decimal = CType(Me.TxtSaldo.Text, Decimal)
        Dim mon As String = Rbt.radioActivo(Me.gbMoneda).Text

        If sal < 0 Then
            Select Case mon
                Case "S/."
                    obj.SalidasSolAntCuentaBanco = Math.Abs(sal)
                    isalant = obj.SaldoMesSolAntCuentaBanco
                    obj.SaldoMesSolAntCuentaBanco = sal
                Case "US$"
                    obj.SalidasDolAntCuentaBanco = Math.Abs(sal)
                    isalant = obj.SaldoMesDolAntCuentaBanco
                    obj.SaldoMesDolAntCuentaBanco = sal
                Case "EUR"
                    obj.SalidasEurAntCuentaBanco = Math.Abs(sal)
                    isalant = obj.SaldoMesEurAntCuentaBanco
                    obj.SaldoMesEurAntCuentaBanco = sal

            End Select
        Else
            Select Case mon
                Case "S/."
                    obj.IngresosSolAntCuentaBanco = sal
                    isalant = obj.SaldoMesSolAntCuentaBanco
                    obj.SaldoMesSolAntCuentaBanco = sal
                Case "US$"
                    obj.IngresosDolAntCuentaBanco = sal
                    isalant = obj.SaldoMesDolAntCuentaBanco
                    obj.SaldoMesDolAntCuentaBanco = sal
                Case "EUR"
                    obj.IngresosEurAntCuentaBanco = sal
                    isalant = obj.SaldoMesEurAntCuentaBanco
                    obj.SaldoMesEurAntCuentaBanco = sal

            End Select

        End If
        sb.modificarSaldosBancarios(obj)

        'Actualizar todos los saldos del año de este periodo
        obj.ClaveCuentaBanco = SuperEntidad.xCodigoEmpresa + Me.txtCodCb.Text.Trim
        obj.AnoCuentaBanco = SuperEntidad.xPeriodoEmpresa.Substring(0, 4)
        Dim iLisSalBan As List(Of SuperEntidad) = sb.ObtenerSaldosBancariosExisPorCuenta(obj)
        For Each xobj As SuperEntidad In iLisSalBan
            Select Case mon
                Case "S/."
                    xobj.SaldoMesSolCuentaBanco = xobj.SaldoMesSolCuentaBanco - isalant + sal
                Case "US$"
                    xobj.SaldoMesDolCuentaBanco = xobj.SaldoMesDolCuentaBanco - isalant + sal
                Case "EUR"
                    xobj.SaldoMesEurCuentaBanco = xobj.SaldoMesEurAntCuentaBanco - isalant + sal
            End Select
            sb.modificarSaldosBancarios(xobj)
        Next
    End Sub
#End Region


    Private Sub WEditarTabla_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        'Solo para eliminar
        If Me.operacion = 2 Then
            Dim rpta As Integer = MsgBox("Deseas eliminar este registro", MsgBoxStyle.YesNo, Me.wBco.titulo)
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
            Dim rpta As Integer = MsgBox("Deseas cancelar la operacion", MsgBoxStyle.YesNo, Me.wBco.titulo)
            If rpta = MsgBoxResult.Yes Then
                Me.Close()
            Else
                Exit Sub
            End If
        End If
    End Sub


#Region "existe CuentaBanco"

    Private Sub txtCodCb_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodCb.Validated
        'Se busca en toda la tabla CuentaBanco
        If Me.ComprobarClaveCuentaBanco() = True Then
            Me.txtCodCb.Text = ""
            Me.txtCodCb.Focus()
            'e.Cancel = True
        Else
            Exit Sub
        End If
    End Sub

#End Region

#Region "Existe Codigo"

    Function ComprobarClaveCuentaBanco() As Boolean
        '/
        If Me.operacion = 0 Then 'Solo cuando Agrega

            Dim cod As String = Me.TxtCodEmp.Text.Trim + Me.txtCodCb.Text.Trim
            If cod = "" Then
                Return False
            Else
                Dim obj As New SuperEntidad
                obj.ClaveCuentaBanco = cod

                'Se busca en toda la tabla
                If bco.existeCuentaBancoPorClave(obj) = True Then
                    MsgBox("Cuenta Banco ya existe", MsgBoxStyle.Information, Me.wBco.titulo)
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

End Class