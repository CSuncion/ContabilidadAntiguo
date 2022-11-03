Option Explicit On
Option Strict On
Imports Entidad
Imports Negocio
Imports System.Threading

Public Class WActualizaCuentaCorriente
    Dim acc As New Accion
    Dim movdet As New RegContabDetaRN
    Dim bco As New CuentaBancoRN
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


    Sub ActualizandoCuentaCorriente()

        Dim iCuCoRN As New CuentaCorrienteRN
        Dim iCuCoEN As New SuperEntidad
        iCuCoEN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iCuCoEN.DatoCondicion1 = Me.txtAno.Text + "00"
        iCuCoEN.DatoCondicion2 = Me.txtAno.Text + Me.txtCodMes.Text
        iCuCoRN.ActualizarCuentasCorientes(iCuCoEN)



        'Dim lista As List(Of SuperEntidad) = iCuCoRN.ListarActualizarCuentasCorientes(iCuCoEN)

        ''/Refrescando el DataSource de DgvUsu
        'Dgv.refrescarFuenteDatosGrilla(Me.DgvPer, lista)
        ''/Creando las columnas
        'Dgv.asignarColumnaText(Me.DgvPer, cam.DesAux, "Auxiliar", 120)
        'Dgv.asignarColumnaText(Me.DgvPer, cam.CodTipDoc, "Tipo", 50)
        'Dgv.asignarColumnaText(Me.DgvPer, cam.SerDoC, "Serie", 60)
        'Dgv.asignarColumnaText(Me.DgvPer, cam.NumDoc, "Numero", 90)
        'Dgv.asignarColumnaText(Me.DgvPer, cam.CodCtaPcge, "cuenta", 90)
        'Dgv.asignarColumnaText(Me.DgvPer, cam.MonDoc, "moneda", 90)
        ''Dgv.asignarColumnaText(Me.DgvPer, cam.SalCtaBco, "Saldo", 90)
        'Dgv.asignarColumnaText(Me.DgvPer, cam.SalCtaCte, "Saldo", 90)
        'Dgv.asignarColumnaText(Me.DgvPer, cam.EstCtaCte, "Estado", 60)

        Me.tslEstadoExp.Text = "Terminado"
    End Sub


   
#End Region

    Sub hilo2()
        Me.tslEstadoExp.Text = "Esperar..."
    End Sub

    Sub Hilo1()
        Me.ActualizandoCuentaCorriente()
    End Sub

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
        Dim mih1, mih2 As Thread
        mih1 = New Thread(AddressOf Hilo1)
        mih2 = New Thread(AddressOf hilo2)
        mih1.Start()
        mih2.Start()
        ' Me.ActualizandoCuentaCorriente()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class