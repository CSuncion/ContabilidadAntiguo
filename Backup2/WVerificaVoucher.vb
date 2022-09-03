Imports Entidad
Imports Negocio

Public Class WVerificaVoucher
    Public acc As New Accion

    Sub NuevaVentana()
        '/Para los eventos de controles
        acc.listaCtrls = Me.ListaControles
        acc.PasaFoco()
        acc.FomatoDato()
        acc.PasarCursor()
        acc.Teclazo()
        acc.Valida()
        Me.PorDefecto()
        Me.Show()
        Me.txtCodMes.Focus()
        Me.Ejecutar()

    End Sub


    Sub PorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.txtNomEmp.Text = SuperEntidad.xRazonSocial
        Me.txtAno.Text = SuperEntidad.xPeriodoEmpresa.Substring(0, 4)
    End Sub

    Sub Ejecutar()
        Dim rcc As New RegContabCabeRN
        Dim ent As New SuperEntidad
        Dim lisrcc As New List(Of SuperEntidad)
        Dim cam As New CamposEntidad

        ent.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        ent.CampoOrden = cam.ClaveRCC

        lisrcc = rcc.ListarVoucherDescuadrado(ent)
        Dgv.refrescarFuenteDatosGrilla(Me.DgvMovCabe, lisrcc)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.ClaveRCC, "Clave", 140)
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.CodOriRC, "Origen", 50)
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.NomOriRC, "Descripción", 100)
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.CodFilRC, "File", 50)
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.NomFilRC, "Descripción", 180)
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.NumVouRCC, "Numero Voucher", 110)
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.FecVouRCC, "Fecha Voucher", 110)
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.NomTipDoc, "Documento", 130)
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.DesAux, "Auxiliar", 250)
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.SerDoC, "Serie", 70)
        Dgv.asignarColumnaText(Me.DgvMovCabe, cam.NumDoc, "Numero", 100)
        Dgv.AsignarColumnaTextNumerico(Me.DgvMovCabe, cam.PreVtaRCC, "P.Venta", 100, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvMovCabe, cam.ValVtaRCC, "V.Venta", 100, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvMovCabe, cam.IgvRCC, "Igv", 100, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvMovCabe, cam.ExoneradoRCC, "Exonedaro", 70, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvMovCabe, cam.ImpSolRCC, "Importe", 70, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvMovCabe, cam.SumDebRCC, "Suma Debe", 120, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvMovCabe, cam.SumHabRCC, "Suma Haber", 120, 2)

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
                win.ctrlFoco = Me.BtnEjecutar
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

    Private Sub BtnEjecutar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEjecutar.Click
        If acc.CamposObligatorios = False Then
            Exit Sub
        Else
            Me.Ejecutar()
            MsgBox("Proceso Termino")
        End If
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub
End Class