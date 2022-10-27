Imports Entidad
Imports Negocio

Public Class WDifCamGenerarMes
    Dim acc As New Accion
    Dim cam As New CamposEntidad
 

#Region "Propietario"
    'Public wBco As New WCuentaBanco
#End Region

#Region "General"

    Sub InicializaVentana()
        '/Para los eventos de controles
        acc.listaCtrls = Me.ListaControles
        acc.PasaFoco()
        acc.FomatoDato()
        acc.PasarCursor()
        acc.Teclazo()
        acc.Valida()
        Me.Show()
        'Me.Owner.Enabled = False
        Me.PorDefecto()
        Me.txtCodMes.Focus()
        'acc.Nuevo()
    End Sub

    Sub PorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.TxtNomEmp.Text = SuperEntidad.xRazonSocial
        Me.txtAno.Text = SuperEntidad.xPeriodoEmpresa.Substring(0, 4)
    End Sub

    Function EsValidoGenerarMes() As Boolean
        Dim iCchRN As New CuentaCorrienteHistoricoRN
        Dim iCchEN As New SuperEntidad
        iCchEN = iCchRN.EsValidoGenerarMes(Me.ListarCuentaCorrienteHistoricoMes())
        If iCchEN.EsVerdad = False Then
            MsgBox(iCchEN.Mensaje, MsgBoxStyle.Exclamation, "Diferencia cambio")
        End If
        Return iCchEN.EsVerdad
    End Function

    Function ListarCuentaCorrienteHistoricoMes() As List(Of SuperEntidad)
        Dim iCchRN As New CuentaCorrienteHistoricoRN
        Dim iCchEN As New SuperEntidad
        iCchEN.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        iCchEN.CampoOrden = cam.ClaveCtaCteHis
        Return iCchRN.ListarCuentaCorrienteHistoricoXPeriodo(iCchEN)
    End Function

    Sub EliminarCuentaCorrienteHistoricoMes()
        Dim iCchRN As New CuentaCorrienteHistoricoRN
        Dim iCchEN As New SuperEntidad
        iCchEN.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        iCchRN.eliminarCuentaCorrienteHistoricoXMes(iCchEN)
    End Sub

    Sub GenerarCuentaCorrienteHistoricoXMes()
        'TRAER TODAS LAS CUENTAS CORRIENTES DEL MES (SOLO EN DOLARES)
        Dim iCueCorRN As New CuentaCorrienteRN
        Dim iCueCorEN As New SuperEntidad
        iCueCorEN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iCueCorEN.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        Dim iLisCueCor As List(Of SuperEntidad) = iCueCorRN.ListarCuentasCorrientesParaDiferenciaDeCambio(iCueCorEN)

        'PASAR CADA UNA DE ESTAS CUENTAS CORRIENTES A CUENTAS CORRIENTES HISTORICO
        Dim iCueCorHisRN As New CuentaCorrienteHistoricoRN
        For Each xobj As SuperEntidad In iLisCueCor
            If xobj.MonedaDocumento <> "" Then
                xobj.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
                xobj.ClaveCuentaCorrienteHistorico = xobj.ClaveCuentaCorriente + xobj.PeriodoRegContabCabe
                xobj.EstadoCuentaCorrienteHistorico = "0" 'NO APROBADO
                iCueCorHisRN.nuevoCuentaCorrienteHistorico(xobj)
            End If
        Next
    End Sub

    Sub Ejecutar()
        'PRIMERO SABER SI SE PUEDE GENERAR EL MES
        If Me.EsValidoGenerarMes = False Then Exit Sub

        'SI HAY CUENTA CORRIENTE EN EL MES PREGUNTAR SI 
        'QUEREMOS VOLVER A GENERAR EL MES
        If Me.ListarCuentaCorrienteHistoricoMes().Count = 0 Then
            Me.GenerarCuentaCorrienteHistoricoXMes()
            MsgBox("Se genero el mes correctamente", MsgBoxStyle.Information, "Cuenta Corriente")
        Else
            Dim rpta As Integer = MsgBox("Este periodo ya se genero,Deseas volver a generarlo", MsgBoxStyle.YesNo)
            If rpta = MsgBoxResult.Yes Then
                Me.EliminarCuentaCorrienteHistoricoMes()
                Me.GenerarCuentaCorrienteHistoricoXMes()
                MsgBox("Se genero el mes correctamente", MsgBoxStyle.Information, "Cuenta Corriente")
            Else
                Exit Sub
            End If
        End If
    End Sub


#End Region



#Region "Mostrar Form Lista"

    Private Sub txtCodMes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodMes.KeyDown
        If Me.txtCodMes.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarTabla
                win.tabla = "Mes"
                win.titulo = "Meses"
                win.txt1 = Me.txtCodMes
                win.txt2 = Me.txtDesMes
                win.ctrlFoco = Me.txtCodMes
                win.NuevaVentana()
            End If
        End If
    End Sub

#End Region

#Region "Buscar Por Codigo"

    Private Sub txtCodMes_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodMes.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.txtCodMes : ope.txt2 = Me.txtDesMes
        ope.MostrarCodigoDescripcionDeTabla("Mes", "Meses", e)
    End Sub

#End Region

    Private Sub WPersonalRecycla_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Me.Owner.Enabled = True
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.Ejecutar()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class