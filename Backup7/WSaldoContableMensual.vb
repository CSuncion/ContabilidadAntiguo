Imports Entidad
Imports Negocio

Public Class WSaldoContableMensual
#Region "Propietarios"
    Public wSal As New WSaldoContable
#End Region

    Dim valorRef As String

    Public ent, paren As New SuperEntidad
    Public lista As New List(Of SuperEntidad)
    Public cam As New CamposEntidad
    Public tab As New TablaRN
    Public sal As New SaldoContableRN
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
        paren = par.buscarParametroExis(paren)
        Me.Show()

    End Sub

    Sub PorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.TxtNomEmp.Text = SuperEntidad.xRazonSocial

    End Sub


    Sub ventanaEliminar(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Eliminar " + Me.wSal.titulo
        'mostrar el registro en pantalla
        Me.obtenerCuentaSaldoEnPantalla(codigo)
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
        Me.Text = "Visualizar " + Me.wSal.titulo
        'mostrar el registro en pantalla
        Me.obtenerCuentaSaldoEnPantalla(codigo)
        'foco
        Me.btnAceptar.Focus()
        'los controles que deben estar activos
        acc.Visualizar()
        '\\
    End Sub

    Sub obtenerCuentaSaldoEnPantalla(ByRef cod As String)
        '//
        'Buscamos el registro de codigo "Cod"
        ent.ClaveSaldoContable = cod
        ent = sal.buscarCuentaSaldoExisPorClave(ent)
        'preguntar si ent tiene el registro
        If ent.ClaveSaldoContable = "" Then
            Exit Sub
        Else
            '/Pasar Datos a los controles
            Me.TxtCodEmp.Text = ent.CodigoEmpresa
            Me.TxtNomEmp.Text = ent.RazonSocialEmpresa
            'Debe
            Me.TxtDebeApe.Text = Varios.numeroConDosDecimal(ent.DebeS00SaldoContable.ToString)
            Me.TxtDebeEne.Text = Varios.numeroConDosDecimal(ent.DebeS01SaldoContable.ToString)
            Me.TxtDebeFeb.Text = Varios.numeroConDosDecimal(ent.DebeS02SaldoContable.ToString)
            Me.TxtDebeMar.Text = Varios.numeroConDosDecimal(ent.DebeS03SaldoContable.ToString)
            Me.TxtDebeAbr.Text = Varios.numeroConDosDecimal(ent.DebeS04SaldoContable.ToString)
            Me.TxtDebeMay.Text = Varios.numeroConDosDecimal(ent.DebeS05SaldoContable.ToString)
            Me.TxtDebeJun.Text = Varios.numeroConDosDecimal(ent.DebeS06SaldoContable.ToString)
            Me.TxtDebeJul.Text = Varios.numeroConDosDecimal(ent.DebeS07SaldoContable.ToString)
            Me.TxtDebeAgo.Text = Varios.numeroConDosDecimal(ent.DebeS08SaldoContable.ToString)
            Me.TxtDebeSet.Text = Varios.numeroConDosDecimal(ent.DebeS09SaldoContable.ToString)
            Me.TxtDebeOct.Text = Varios.numeroConDosDecimal(ent.DebeS10SaldoContable.ToString)
            Me.TxtDebeNov.Text = Varios.numeroConDosDecimal(ent.DebeS11SaldoContable.ToString)
            Me.TxtDebeDic.Text = Varios.numeroConDosDecimal(ent.DebeS12SaldoContable.ToString)
            Me.TxtDebeCierre.Text = Varios.numeroConDosDecimal(ent.DebeS13SaldoContable.ToString)
            'Haber
            Me.TxtHabeApe.Text = Varios.numeroConDosDecimal(ent.HabeS00SaldoContable.ToString)
            Me.TxtHabeEne.Text = Varios.numeroConDosDecimal(ent.HabeS01SaldoContable.ToString)
            Me.TxtHabeFeb.Text = Varios.numeroConDosDecimal(ent.HabeS02SaldoContable.ToString)
            Me.TxtHabeMar.Text = Varios.numeroConDosDecimal(ent.HabeS03SaldoContable.ToString)
            Me.TxtHabeAbr.Text = Varios.numeroConDosDecimal(ent.HabeS04SaldoContable.ToString)
            Me.TxtHabeMay.Text = Varios.numeroConDosDecimal(ent.HabeS05SaldoContable.ToString)
            Me.TxtHabeJun.Text = Varios.numeroConDosDecimal(ent.HabeS06SaldoContable.ToString)
            Me.TxtHabeJul.Text = Varios.numeroConDosDecimal(ent.HabeS07SaldoContable.ToString)
            Me.TxtHabeAgo.Text = Varios.numeroConDosDecimal(ent.HabeS08SaldoContable.ToString)
            Me.TxtHabeSet.Text = Varios.numeroConDosDecimal(ent.HabeS09SaldoContable.ToString)
            Me.TxtHabeOct.Text = Varios.numeroConDosDecimal(ent.HabeS10SaldoContable.ToString)
            Me.TxtHabeNov.Text = Varios.numeroConDosDecimal(ent.HabeS11SaldoContable.ToString)
            Me.TxtHabeDic.Text = Varios.numeroConDosDecimal(ent.HabeS12SaldoContable.ToString)
            Me.TxtHabeCierre.Text = Varios.numeroConDosDecimal(ent.HabeS13SaldoContable.ToString)

            'Saldo Mes
            Me.TxtSalApe.Text = Varios.numeroConDosDecimal((ent.DebeS00SaldoContable - ent.HabeS00SaldoContable).ToString)
            Me.TxtSalEne.Text = Varios.numeroConDosDecimal((ent.DebeS01SaldoContable - ent.HabeS01SaldoContable).ToString)
            Me.TxtSalFeb.Text = Varios.numeroConDosDecimal((ent.DebeS02SaldoContable - ent.HabeS02SaldoContable).ToString)
            Me.TxtSalMar.Text = Varios.numeroConDosDecimal((ent.DebeS03SaldoContable - ent.HabeS03SaldoContable).ToString)
            Me.TxtSalAbr.Text = Varios.numeroConDosDecimal((ent.DebeS04SaldoContable - ent.HabeS04SaldoContable).ToString)
            Me.TxtSalMay.Text = Varios.numeroConDosDecimal((ent.DebeS05SaldoContable - ent.HabeS05SaldoContable).ToString)
            Me.TxtSalJun.Text = Varios.numeroConDosDecimal((ent.DebeS06SaldoContable - ent.HabeS06SaldoContable).ToString)
            Me.TxtSalJul.Text = Varios.numeroConDosDecimal((ent.DebeS07SaldoContable - ent.HabeS07SaldoContable).ToString)
            Me.TxtSalAgo.Text = Varios.numeroConDosDecimal((ent.DebeS08SaldoContable - ent.HabeS08SaldoContable).ToString)
            Me.TxtSalSet.Text = Varios.numeroConDosDecimal((ent.DebeS09SaldoContable - ent.HabeS09SaldoContable).ToString)
            Me.TxtSalOct.Text = Varios.numeroConDosDecimal((ent.DebeS10SaldoContable - ent.HabeS10SaldoContable).ToString)
            Me.TxtSalNov.Text = Varios.numeroConDosDecimal((ent.DebeD11SaldoContable - ent.HabeS11SaldoContable).ToString)
            Me.TxtSalDic.Text = Varios.numeroConDosDecimal((ent.DebeS12SaldoContable - ent.HabeS12SaldoContable).ToString)
            Me.TxtSalCierre.Text = Varios.numeroConDosDecimal((ent.DebeS13SaldoContable - ent.HabeS13SaldoContable).ToString)

            'Saldo Mayor
            Me.TxtMayApe.Text = Varios.numeroConDosDecimal(ent.HabeS00SaldoContable.ToString)
            Me.TxtMayEne.Text = Varios.numeroConDosDecimal(ent.HabeS01SaldoContable.ToString)
            Me.TxtMayFeb.Text = Varios.numeroConDosDecimal(ent.HabeS02SaldoContable.ToString)
            Me.TxtMayMar.Text = Varios.numeroConDosDecimal(ent.HabeS03SaldoContable.ToString)
            Me.TxtMayAbr.Text = Varios.numeroConDosDecimal(ent.HabeS04SaldoContable.ToString)
            Me.TxtMayMay.Text = Varios.numeroConDosDecimal(ent.HabeS05SaldoContable.ToString)
            Me.TxtMayJun.Text = Varios.numeroConDosDecimal(ent.HabeS06SaldoContable.ToString)
            Me.TxtMayJul.Text = Varios.numeroConDosDecimal(ent.HabeS07SaldoContable.ToString)
            Me.TxtMayAgo.Text = Varios.numeroConDosDecimal(ent.HabeS08SaldoContable.ToString)
            Me.TxtMaySet.Text = Varios.numeroConDosDecimal(ent.HabeS09SaldoContable.ToString)
            Me.TxtMayOct.Text = Varios.numeroConDosDecimal(ent.HabeS10SaldoContable.ToString)
            Me.TxtMayNov.Text = Varios.numeroConDosDecimal(ent.HabeS11SaldoContable.ToString)
            Me.TxtMayDic.Text = Varios.numeroConDosDecimal(ent.HabeS12SaldoContable.ToString)
            Me.TxtMayCierre.Text = Varios.numeroConDosDecimal(ent.HabeS13SaldoContable.ToString)

        End If
        '\\
    End Sub

#End Region

    Private Sub WEditarTabla_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Me.operacion = 3 Then
            Me.Close()
        Else
            Dim rpta As Integer = MsgBox("Deseas cancelar la operacion", MsgBoxStyle.YesNo, Me.wSal.titulo)
            If rpta = MsgBoxResult.Yes Then
                Me.Close()
            Else
                Exit Sub
            End If
        End If
    End Sub

End Class