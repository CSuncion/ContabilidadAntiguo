Imports Entidad
Imports Negocio

Public Class WEditarVoucher

#Region "Propietarios"
    Public wVou As New WVoucher
#End Region

    Dim valorRef As String

    Public ent, paren As New SuperEntidad
    Public lista As New List(Of SuperEntidad)
    Public cam As New CamposEntidad
    Public tab As New TablaRN
    Public vou As New VoucherRN
    Public par As New ParametroRN
    Public emp As New EmpresaRN
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
        parEn = par.buscarParametroExis(parEn)
        Me.Show()

    End Sub

    Sub PorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.txtNomEmp.Text = SuperEntidad.xRazonSocial
        ''Instanciar Empresa Actual 
        Dim obe As New SuperEntidad
        obe.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        obe = emp.buscarEmpresaExisPorCodigo(obe)
        Me.txtAno.Text = obe.PeriodoEmpresa.Substring(0, 4)
        'Me.txtAno.Text = paren.Periodo.Substring(0, 4)

    End Sub

    Sub ventanaAdicionar()
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Agregar " + Me.wVou.titulo
        acc.LimpiarControles()
        'poner el cursor de inicio
        'por defecto
        Me.PorDefecto()
        Txt.cursorAlUltimo(Me.TxtCodFil)
        'los controles que deben estar activos
        acc.Nuevo()
        '\\
    End Sub

    Sub ventanaModificar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Modificar " + Me.wVou.titulo
        'mostrar el registro en pantalla
        Me.obtenerVoucherEnPantalla(codigo)
        'poner el cursor de inicio
        Txt.cursorAlUltimo(Me.TxtApe)
        'los controles que deben estar activos
        acc.Modificar()
        '\\
    End Sub

    Sub ventanaEliminar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Eliminar " + Me.wVou.titulo
        'mostrar el registro en pantalla
        Me.obtenerVoucherEnPantalla(codigo)
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
        Me.Text = "Visualizar " + Me.wVou.titulo
        'mostrar el registro en pantalla
        Me.obtenerVoucherEnPantalla(codigo)
        'foco
        Me.btnAceptar.Focus()
        'los controles que deben estar activos
        acc.Visualizar()
        '\\
    End Sub

    Sub obtenerVoucherEnPantalla(ByRef cod As String)
        '//
        'Buscamos el registro de codigo "Cod"
        ent.ClaveVoucher = cod
        ent = vou.buscarVoucherExisPorCodigo(ent)
        'preguntar si ent tiene el registro
        If ent.ClaveVoucher = "" Then
            Exit Sub
        Else
            '/Pasar Datos a los controles
            Me.TxtCodEmp.Text = ent.CodigoEmpresa
            Me.TxtNomEmp.Text = ent.RazonSocialEmpresa
            Me.txtAno.Text = ent.AnoVoucher
            Me.TxtCodFil.Text = ent.CodigoFile
            Me.txtNomFil.Text = ent.NombreFile
            Me.TxtApe.Text = ent.AperturaVoucher
            Me.TxtEne.Text = ent.EneroVoucher
            Me.TxtFeb.Text = ent.FebreroVoucher
            Me.TxtMar.Text = ent.MarzoVoucher
            Me.TxtAbr.Text = ent.AbrilVoucher
            Me.TxtMay.Text = ent.MayoVoucher
            Me.TxtJun.Text = ent.JunioVoucher
            Me.TxtJul.Text = ent.JulioVoucher
            Me.TxtAgo.Text = ent.AgostoVoucher
            Me.TxtSet.Text = ent.SetiembreVoucher
            Me.TxtOct.Text = ent.OctubreVoucher
            Me.TxtNov.Text = ent.NoviembreVoucher
            Me.TxtDic.Text = ent.DiciembreVoucher
            Me.TxtCierre.Text = ent.CierreVoucher
            Gb.pasarDato(Me.gbEstado, ent.EstadoVoucher)
        End If
        '\\
    End Sub

    Sub Aceptar()
        '// Lo ques graba en la tabla
        If Me.operacion = 1 Or Me.operacion = 2 Then
            'Volver a traer el registro 
            ent.ClaveVoucher = ent.ClaveVoucher
            ent = vou.buscarVoucherExisPorCodigo(ent)
        End If
        ent.CodigoEmpresa = Me.TxtCodEmp.Text.Trim()
        ent.AnoVoucher = Me.txtAno.Text.Trim()
        ent.CodigoFile = Me.TxtCodFil.Text.Trim()
        ent.AperturaVoucher = Me.TxtApe.Text.Trim()
        ent.EneroVoucher = Me.TxtEne.Text.Trim()
        ent.FebreroVoucher = Me.TxtFeb.Text.Trim()
        ent.MarzoVoucher = Me.TxtMar.Text.Trim()
        ent.AbrilVoucher = Me.TxtAbr.Text.Trim()
        ent.MayoVoucher = Me.TxtMay.Text.Trim()
        ent.JunioVoucher = Me.TxtJun.Text.Trim()
        ent.JulioVoucher = Me.TxtJul.Text.Trim()
        ent.AgostoVoucher = Me.TxtAgo.Text.Trim()
        ent.SetiembreVoucher = Me.TxtSet.Text.Trim()
        ent.OctubreVoucher = Me.TxtOct.Text.Trim()
        ent.NoviembreVoucher = Me.TxtNov.Text.Trim()
        ent.DiciembreVoucher = Me.TxtDic.Text.Trim()
        ent.CierreVoucher = Me.TxtCierre.Text.Trim()
        ent.EstadoVoucher = Rbt.radioActivo(Me.gbEstado).Text.Trim
        ent.Exporta = "0"
        '/Se graba o0 se modifica?
        Select Case Me.operacion

            Case 0
                'ent.EstadoComprobante = "Activo"  ''Cuando no se ve en pantalla sino arriba
                ''Obtener codigo autogenerado
                'ent.CodigoCliente = cli.obtenerCodigoClienteAutogenerado()
                'Nuevo registro

                vou.nuevaVoucher(ent)

                MsgBox(Me.wVou.titulo + " ingresado correctamente", MsgBoxStyle.Information, Me.wVou.titulo)
                'Limpiamos los controles para un nuevo registro
                acc.LimpiarControles()
                Me.PorDefecto()
                Me.TxtCodFil.Focus()

            Case 1
                'Modificar Registro
                vou.modificarVoucher(ent)
                MsgBox(Me.wVou.titulo + " modificado correctamente", MsgBoxStyle.Information, Me.wVou.titulo)
                Me.Close()

            Case 2
                'eliminamos al usuario pero logicamente
                vou.eliminarvoucherLog(ent)
                MsgBox(Me.wVou.titulo + " Eliminado correctamente", MsgBoxStyle.Information, Me.wVou.titulo)
                Me.Close()

        End Select
        '/Actualizar y buscar el registro grabado
        Me.wVou.ActualizarVentana()
        Dgv.obtenerCursorActual(Me.wVou.DgvVou, ent.ClaveVoucher, Me.wVou.lista)
        '\\
    End Sub


#End Region


    Private Sub WEditarTabla_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        'Solo para eliminar
        If Me.operacion = 2 Then
            Dim rpta As Integer = MsgBox("Deseas eliminar este registro", MsgBoxStyle.YesNo, Me.wVou.titulo)
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
            Dim rpta As Integer = MsgBox("Deseas cancelar la operacion", MsgBoxStyle.YesNo, Me.wVou.titulo)
            If rpta = MsgBoxResult.Yes Then
                Me.Close()
            Else
                Exit Sub
            End If
        End If
    End Sub





#Region "existe Voucher"
    Sub validaVoucher(ByVal ObjFoco As Control)
        'Solo para Adicionar
        If Me.operacion <> 0 Then Exit Sub
        'Si todo esta Ok
        Dim empr As String = Me.TxtCodEmp.Text.Trim
        Dim ano As String = Me.txtAno.Text.Trim
        Dim file As String = Me.TxtCodFil.Text.Trim
        If empr = "" Or ano = "" Or file = "" Then
            Exit Sub
        Else
            Dim obj As New SuperEntidad
            Dim voucher As String = empr + ano + file
            obj.ClaveVoucher = voucher
            'Se Busca en toda la tabla
            If vou.existeVoucherPorCodigo(obj) = True Then
                MsgBox("Este Voucher ya existe", MsgBoxStyle.Information)
                Me.TxtCodFil.Text = ""
                Me.txtNomFil.Text = ""

                ObjFoco.Focus()
            End If
        End If
    End Sub

#End Region


   
End Class