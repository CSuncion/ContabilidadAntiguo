Imports Entidad
Imports Negocio


Public Class WEditarPlanCuentaGe

#Region "Propietarios"
    Public wpcg As New WPlanCuentaGe
#End Region

    Dim valorRef As String

    Public ent, paren, entb As New SuperEntidad
    Public lista As New List(Of SuperEntidad)
    Public cam As New CamposEntidad
    Public tab As New TablaRN
    Public par As New ParametroRN
    Public pcg As New PlanCuentaGeRN
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
        paren = par.buscarParametroExis(paren)
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
        Me.Text = "Agregar " + Me.wpcg.titulo
        acc.LimpiarControles()
        Me.PorDefecto()
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtCodCta)
        'los controles que deben estar activos
        acc.Nuevo()
        Me.HabilitarControlesSegunAutomatica()
        Me.txtCodCta.Focus()
        '\\
    End Sub

    Sub ventanaModificar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Modificar " + Me.wpcg.titulo
        Me.PorDefecto()
        'mostrar el registro en pantalla
        Me.obtenerItemTablaEnPantalla(codigo)
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.txtNomCta)
        'los controles que deben estar activos
        acc.Modificar()
        Me.HabilitarControlesSegunAutomatica()

        '\\
    End Sub

    Sub ventanaEliminar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Eliminar " + Me.wpcg.titulo
        Me.PorDefecto()
        'mostrar el registro en pantalla
        Me.obtenerItemTablaEnPantalla(codigo)
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
        Me.Text = "Visualizar " + Me.wpcg.titulo
        Me.PorDefecto()
        'mostrar el registro en pantalla
        Me.obtenerItemTablaEnPantalla(codigo)
        'foco
        Me.btnAceptar.Focus()
        'los controles que deben estar activos
        acc.Visualizar()
        '\\
    End Sub

    Sub obtenerItemTablaEnPantalla(ByRef cod As String)
        '//
        'Buscamos el registro de codigo "Cod"
        ent.ClaveCuentaPcge = Me.wpcg.cEmp + cod
        ent = pcg.buscarCuentaExisPorClave(ent)
        'preguntar si ent tiene el registro
        If ent.ClaveCuentaPcge = "" Then
            Exit Sub
        Else
            '/Pasar Datos a los controles
            Me.txtCodCta.Text = ent.CodigoCuentaPcge
            Me.txtNomCta.Text = ent.NombreCuentaPcge
            Gb.pasarDato(Me.gbdocumento, ent.FlagDocumentoPcge)
            Gb.pasarDato(Me.gbAuxiliar, ent.FlagAuxiliarPcge)
            Gb.pasarDato(Me.gbCcosto, ent.FlagCentroCostoPcge)
            Gb.pasarDato(Me.gbalmacen, ent.FlagAlmacenPcge)
            Gb.pasarDato(Me.gbarea, ent.FlagAreaPcge)
            Gb.pasarDato(Me.gbflujo, ent.FlagFlujoCajaPcge)
            Gb.pasarDato(Me.GbAutomatica, ent.FlagAutomaticaPcge)
            Gb.pasarDato(Me.gbdiferencia, ent.FlagDifCambioPcge)
            Gb.pasarDato(Me.gbBanco, ent.FlagBancoPcge)
            Gb.pasarDato(Me.gbAsientoApertura, ent.FlagAsientoAperturaPcge)
            Gb.pasarDato(Me.gbAsientoCierre9, ent.FlagAsientoCierre9Pcge)
            Gb.pasarDato(Me.gbAsientoCierre7, ent.FlagAsientoCierre7Pcge)
            Gb.pasarDato(Me.GbMoneda, ent.FlagMonedaPcge)
            Me.TxtCtaAut1.Text = ent.CuentaAutomatica1Pcge
            Me.TxtNomCtaAut1.Text = ent.NombreCuentaAutomatica1Pcge
            Me.TxtCtaAut2.Text = ent.CuentaAutomatica2Pcge
            Me.TxtNomCtaAut2.Text = ent.NombreCuentaAutomatica2Pcge
            Me.TxtCodForCon.Text = ent.ClaveFormatoContable
            Me.TxtNomForCon.Text = ent.DescripcionFormatoContable
        End If
        '\\
    End Sub

    Sub Aceptar()
        '// Lo que esta grabado en la tabla antes de la modificacion
        Dim flagbanco As String = ""

        If Me.operacion = 1 Or Me.operacion = 2 Then
            'Volver a traer el registro 
            ent.ClaveCuentaPcge = Me.wpcg.cEmp + Me.txtCodCta.Text.Trim
            'ent.ClaveComprobante = Me.TxtCodProy.Text.Trim
            ent = pcg.buscarCuentaExisPorClave(ent)
            flagbanco = ent.FlagBancoPcge
        End If

        ent.CodigoEmpresa = Me.wpcg.cEmp
        ent.CodigoCuentaPcge = Me.txtCodCta.Text.Trim
        ent.NombreCuentaPcge = Me.txtNomCta.Text.Trim
        ent.FlagDocumentoPcge = Rbt.radioActivo(Me.gbdocumento).Text.Trim
        ent.FlagAuxiliarPcge = Rbt.radioActivo(Me.gbAuxiliar).Text.Trim
        ent.FlagCentroCostoPcge = Rbt.radioActivo(Me.gbCcosto).Text.Trim
        ent.FlagAlmacenPcge = Rbt.radioActivo(Me.gbalmacen).Text.Trim
        ent.FlagAreaPcge = Rbt.radioActivo(Me.gbarea).Text.Trim
        ent.FlagFlujoCajaPcge = Rbt.radioActivo(Me.gbflujo).Text.Trim
        ent.FlagAutomaticaPcge = Rbt.radioActivo(Me.GbAutomatica).Text.Trim
        ent.FlagDifCambioPcge = Rbt.radioActivo(Me.gbdiferencia).Text.Trim
        ent.FlagBancoPcge = Rbt.radioActivo(Me.gbBanco).Text.Trim
        ent.FlagMonedaPcge = Rbt.radioActivo(Me.GbMoneda).Text.Trim
        ent.FlagAsientoAperturaPcge = Rbt.radioActivo(Me.gbAsientoApertura).Text.Trim
        ent.FlagAsientoCierre9Pcge = Rbt.radioActivo(Me.gbAsientoCierre9).Text.Trim
        ent.FlagAsientoCierre7Pcge = Rbt.radioActivo(Me.gbAsientoCierre7).Text.Trim
        ent.CuentaAutomatica1Pcge = Me.TxtCtaAut1.Text.Trim
        ent.CuentaAutomatica2Pcge = Me.TxtCtaAut2.Text.Trim
        If Me.TxtCodForCon.Enabled = False Then
            ent.ClaveFormatoContable = ""
        Else
            ent.ClaveFormatoContable = Me.TxtCodForCon.Text.Trim
        End If
        ent.Exporta = "0"

        '/Se graba o0 se modifica?
        Select Case Me.operacion

            Case 0
             
                'Nuevo registro
                pcg.nuevaCuenta(ent)
                entb = ent

                ''Graba Cuenta Bancario si el boton es si
                Me.grabarBanco()
                ''
                MsgBox(Me.wpcg.titulo + " ingresado correctamente", MsgBoxStyle.Information, Me.wpcg.titulo)
                'Limpiamos los controles para un nuevo registro
                acc.LimpiarControles()
                Me.txtCodCta.Focus()

            Case 1
                'Modificar Registro
                If flagbanco = "Si" Then
                    If Me.rbnobco.Checked = True Then
                        'PARA SABER QUE SI PODEMOS CAMBIAR EL FALG DEL BANCO A (N0)
                        'DEBEMOS SABER SI ESTA CUENTA BANCARIA TIENE MOVIMIENTOS CONTABLES
                        'SI ES (SI) ENTONCES NO SE PUEDE MODIFICAR ESTE FLAG
                        If Me.EsCuentaBancoConTransaccion = True Then
                            Exit Sub
                        Else
                            'Elimina la cuenta de banco sin transacciones
                            Dim cb As New SuperEntidad
                            cb.ClaveCuentaBanco = SuperEntidad.xCodigoEmpresa + Me.txtCodCta.Text.Trim
                            bco.eliminarCuentaBancoFis(cb)
                            sb.eliminarSaldosBancariosFis(cb)
                        End If
                    End If
                Else
                    ''Graba Cuenta Bancario si el boton es si
                    If Me.rbsibco.Checked = True Then
                        Dim cb As New SuperEntidad
                        cb.ClaveCuentaBanco = SuperEntidad.xCodigoEmpresa + Me.txtCodCta.Text.Trim
                        bco.eliminarCuentaBancoFis(cb)
                        sb.eliminarSaldosBancariosFis(cb)
                        entb = ent
                        Me.grabarBanco()
                    End If
                    ''
                End If


                pcg.modificarCuenta(ent)
                MsgBox(Me.wpcg.titulo + " modificado correctamente", MsgBoxStyle.Information, Me.wpcg.titulo)
                Me.Close()

            Case 2

                'ANTES DE ELIMINAR SABER SI LA CUENTA TIENE MOVIMIENTOS
                If Me.EsCuentaConTransaccion = True Then
                    Exit Sub
                Else
                    'SI LA CUENTA ES BANCARIA 
                    If flagbanco = "Si" Then
                        'Elimina la cuenta de banco sin transacciones
                        Dim cb As New SuperEntidad
                        cb.ClaveCuentaBanco = SuperEntidad.xCodigoEmpresa + Me.txtCodCta.Text.Trim
                        bco.eliminarCuentaBancoFis(cb)
                        sb.eliminarSaldosBancariosFis(cb)
                    End If
                End If

                'eliminamos al usuario pero logicamente
                pcg.eliminarCuentaFis(ent)
                MsgBox(Me.wpcg.titulo + " Eliminado correctamente", MsgBoxStyle.Information, Me.wpcg.titulo)
                Me.Close()

        End Select
        '/Actualizar y buscar el registro grabado
        Me.wpcg.ActualizarVentana()
        Dgv.obtenerCursorActual(Me.wpcg.DgvPcg, ent.CodigoCuentaPcge, Me.wpcg.lista)
        '\\
    End Sub


    Sub grabarBanco()
        If Me.rbsibco.Checked = True Then
            entb.ClaveCuentaBanco = SuperEntidad.xCodigoEmpresa + Me.txtCodCta.Text.Trim
            If bco.existeCuentaBancoPorClave(entb) = False Then
                entb.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
                entb.CodigoCuentaBanco = Me.txtCodCta.Text.Trim()
                entb.BancoCuentaBanco = Me.txtNomCta.Text.Trim()
                entb.AgenciaCuentaBanco = ""
                entb.NumeroCuentaBanco = ""
                entb.MonedaCuentaBanco = Rbt.radioActivo(Me.GbMoneda).Text
                entb.TipoCuentaBanco = "0"
                entb.SaldoCuentaBanco = 0
                entb.EstadoCuentaBanco = "1"
                entb.Exporta = "0"
                bco.nuevaCuentaBanco(entb)
                Me.GenerarSaldosBancarios()
            End If
        End If
    End Sub

    Sub GenerarSaldosBancarios()
        Dim osb As New SuperEntidad
        osb.ClaveCuentaBanco = SuperEntidad.xCodigoEmpresa + Me.txtCodCta.Text.Trim
        sb.GeneraSaldosBancarios(osb)
    End Sub

    Function EsCuentaBancoConTransaccion() As Boolean
        Dim cb As New SuperEntidad
        cb.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        cb.CodigoCuentaPcge = Me.txtCodCta.Text.Trim
        'If bco.EsCuentaBancoConTransaccion(cb) = True Then
        '    MsgBox("Esta Cuenta bancaria tiene movimiento y no se puede modificar su flag", MsgBoxStyle.Exclamation, "Cuentas")
        '    Return True
        'Else
        Return False
        'End If
    End Function

    Function EsCuentaConTransaccion() As Boolean

        Dim cb As New SuperEntidad
        cb.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        cb.CodigoCuentaPcge = Me.txtCodCta.Text.Trim
        If bco.EsCuentaConTransaccion(cb) = True Then
            MsgBox("Esta Cuenta tiene movimiento y no se puede eliminar", MsgBoxStyle.Exclamation, "Cuentas")
            Return True
        Else
            Return False
        End If
    End Function

    'Function EsCuentaBancoConSaldos() As Boolean
    '    Dim cb As New SuperEntidad
    '    cb.ClaveCuentaBanco = SuperEntidad.xCodigoEmpresa + Me.txtCodCta.Text.Trim

    '    If sb.EsCuentaBancoConSaldo(cb) = True Then
    '        Return True
    '    Else
    '        Return False
    '    End If
    'End Function

    Sub HabilitarSegunCuenta()
        Dim numD As String = Me.txtCodCta.Text.Trim.Length.ToString
        If numD = paren.DigitosCuentaAnalitica Then
            Me.gbalmacen.Enabled = True
            Me.gbarea.Enabled = True
            Me.GbAutomatica.Enabled = True
            Me.gbAuxiliar.Enabled = True
            Me.gbCcosto.Enabled = True
            Me.gbdiferencia.Enabled = True
            Me.gbBanco.Enabled = True
            Me.GbMoneda.Enabled = True
            Me.gbAsientoApertura.Enabled = False
            Me.gbAsientoCierre9.Enabled = False
            Me.gbAsientoCierre7.Enabled = False
            Me.gbdocumento.Enabled = True
            Me.gbflujo.Enabled = True
            Me.TxtCtaAut1.Enabled = True
            Me.TxtCtaAut2.Enabled = True
            Me.TxtCodForCon.Enabled = True
        Else
            If numD = "2" Then
                Me.gbalmacen.Enabled = False
                Me.gbarea.Enabled = False
                Me.GbAutomatica.Enabled = False
                Me.gbAuxiliar.Enabled = False
                Me.gbCcosto.Enabled = False
                Me.gbdiferencia.Enabled = False
                Me.gbBanco.Enabled = False
                Me.GbMoneda.Enabled = False
                Me.gbdocumento.Enabled = False
                Me.gbflujo.Enabled = False
                Me.TxtCtaAut1.Enabled = False
                Me.TxtCtaAut2.Enabled = False
                Me.TxtCodForCon.Enabled = False
                Me.gbAsientoApertura.Enabled = True
                Me.gbAsientoCierre9.Enabled = True
                Me.gbAsientoCierre7.Enabled = True
            Else
                Me.gbalmacen.Enabled = False
                Me.gbarea.Enabled = False
                Me.GbAutomatica.Enabled = False
                Me.gbAuxiliar.Enabled = False
                Me.gbCcosto.Enabled = False
                Me.gbdiferencia.Enabled = False
                Me.gbBanco.Enabled = False
                Me.GbMoneda.Enabled = False
                Me.gbAsientoApertura.Enabled = False
                Me.gbAsientoCierre9.Enabled = False
                Me.gbAsientoCierre7.Enabled = False
                Me.gbdocumento.Enabled = False
                Me.gbflujo.Enabled = False
                Me.TxtCtaAut1.Enabled = False
                Me.TxtCtaAut2.Enabled = False
                Me.TxtCodForCon.Enabled = False

            End If
            
        End If

    End Sub
#End Region


    Private Sub WEditarTabla_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        'Solo para eliminar
        If Me.operacion = 2 Then
            Dim rpta As Integer = MsgBox("Deseas eliminar este registro", MsgBoxStyle.YesNo, Me.wpcg.titulo)
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
            'Validar si la cuenta analitica es automatica
            If Me.ValidarFlagAutomatica = False Then
                Me.TxtCtaAut1.Focus()
                Exit Sub
            End If
            Me.Aceptar()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        If Me.operacion = 3 Then
            Me.Close()
        Else
            Dim rpta As Integer = MsgBox("Deseas cancelar la operacion", MsgBoxStyle.YesNo, Me.wpcg.titulo)
            If rpta = MsgBoxResult.Yes Then
                Me.Close()
            Else
                Exit Sub
            End If
        End If
    End Sub

    Sub HabilitarControlesSegunAutomatica()
        '/
        'Dim sr As RadioButton
        If Me.RbSiAut.Checked = True Or Me.RbNoAut.Checked = True Then
            Dim Auto As String = Rbt.radioActivo(Me.GbAutomatica).Text
            'Habilitar los campos calculados segun la detraccion
            Select Case Auto
                Case "Si"
                    Me.TxtCtaAut1.Enabled = True
                    '  Me.TxtCtaAut2.Text = paren.CuentaAutomatica
                    Me.TxtCtaAut2.Enabled = True
                    Dim xcta As New SuperEntidad
                    xcta.ClaveCuentaPcge = SuperEntidad.xCodigoEmpresa + Me.TxtCtaAut2.Text
                    xcta = pcg.buscarCuentaExisPorClave(xcta)
                    Me.TxtNomCtaAut2.Text = xcta.NombreCuentaPcge

                Case "No"
                    Me.TxtCtaAut1.Enabled = False
                    Me.TxtCtaAut1.Text = ""
                    Me.TxtCtaAut2.Text = ""
                    Me.TxtNomCtaAut1.Text = ""
                    Me.TxtNomCtaAut2.Text = ""
            End Select
        End If
        '/

    End Sub

    Function ValidarFlagAutomatica() As Boolean
        If Me.RbSiAut.Checked = True Then
            If Me.TxtCtaAut1.Text.Trim = "" Then
                MsgBox("Colocar Cuenta Automatica", MsgBoxStyle.Critical, "Cuenta Automatica")
                Return False
            Else
                If Me.TxtCtaAut1.Text.Trim.Length.ToString = paren.DigitosCuentaAnalitica Then
                    Return True
                Else
                    MsgBox("Cuenta Automatica es de " + paren.DigitosCuentaAnalitica + " Digitos", MsgBoxStyle.Critical, "Cuenta Automatica")
                    Return False
                End If
            End If
        Else
            Return True
        End If
    End Function

#Region "Mostrar Form Listas"

    Private Sub txtCodForCon_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodForCon.KeyDown
        If Me.operacion = 0 Or Me.operacion = 1 Then
            If Me.TxtCodForCon.ReadOnly = False Then
                If e.KeyCode = Keys.F1 Then
                    Dim win As New WListarFormatoContable
                    'win.tabla = "CuentasAnaliticas"    ''va la condicion del case
                    win.titulo = "Codigos"
                    win.txt1 = Me.TxtCodForCon
                    win.txt2 = Me.TxtNomForCon
                    win.ctrlFoco = Me.btnAceptar
                    win.NuevaVentana()
                End If
            End If
        End If
    End Sub

    Private Sub txtCtaAut1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCtaAut1.KeyDown
        If Me.operacion = 0 Or Me.operacion = 1 Then
            If Me.TxtCtaAut1.ReadOnly = False Then
                If e.KeyCode = Keys.F1 Then
                    Dim win As New WListarPlanCuentaGe
                    win.tabla = "CuentasAnaliticas"    ''va la condicion del case
                    win.titulo = "Cuentas"
                    win.txt1 = Me.TxtCtaAut1
                    win.txt2 = Me.TxtNomCtaAut1
                    win.ctrlFoco = Me.TxtCodForCon
                    win.NuevaVentana()
                End If
            End If
        End If
    End Sub


#End Region

#Region "Buscar Por Codigo"

    Private Sub txtCodForCon_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodForCon.Validating
        If Me.operacion = 0 Or Me.operacion = 1 Then
            Dim ope As New OperaWin : ope.txt1 = Me.TxtCodForCon : ope.txt2 = Me.TxtNomForCon
            ope.MostrarCodigoDescripcionFormatoContable("Formato Contable", e)
        End If
    End Sub

    Private Sub txtCtaAut1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCtaAut1.Validating

        Dim ope As New OperaWin : ope.txt1 = Me.TxtCtaAut1 : ope.txt2 = Me.TxtNomCtaAut1
        ope.Condicion = "CuentasAnaliticas"
        ope.MostrarCodigoDescripcionDePlancuentas("CuentasAnaliticas", e)
    End Sub

#End Region

#Region "existe CuentaPlan"

    Private Sub txtCodcta_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodCta.Validated
        'Se busca en toda la tabla Plan de Cuentas
        If Me.ComprobarClaveCuentaPlan() = True Then
            Me.txtCodCta.Text = ""
            Me.txtCodCta.Focus()
            Me.HabilitarSegunCuenta()
        Else
            Me.HabilitarSegunCuenta()
            Exit Sub
        End If
    End Sub

#End Region

#Region "Existe Codigo"

    Function ComprobarClaveCuentaPlan() As Boolean
        '/
        If Me.operacion = 0 Then 'Solo cuando Agrega

            Dim cod As String = Me.txtCodCta.Text.Trim
            If cod = "" Then
                Return False
            Else
                Dim obj As New SuperEntidad
                obj.ClaveCuentaPcge = Me.wpcg.cEmp + cod
                'Se busca en toda la tabla
                If pcg.existeCuentaPorCodigo(obj) = True Then
                    MsgBox("Esta Cuenta ya existe", MsgBoxStyle.Information, Me.wpcg.titulo)
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

    Private Sub RbSiAut_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbSiAut.CheckedChanged, RbNoAut.CheckedChanged
        Me.HabilitarControlesSegunAutomatica()
    End Sub

   
    Private Sub WEditarPlanCuentaGe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class