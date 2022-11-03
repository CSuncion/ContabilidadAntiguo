Imports Entidad
Imports Negocio

Public Class WVerificaVoucherDetalle
    Public rc As New RegContabCabeRN
    Public rcd As New RegContabDetaRN
    Public acc As New Accion
    Public cam As New CamposEntidad

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

    Sub CuadrarAsientosMasivo()
        Dim iRcc As New SuperEntidad
        iRcc.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iRcc.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        iRcc.CampoOrden = cam.CodOriRC
        Dim iLisRcc As New List(Of SuperEntidad)
        iLisRcc = rc.obtenerRegContabCabePorPeriodo(iRcc)
        For Each xRcc As SuperEntidad In iLisRcc
            'If xRcc.CodigoOrigen = "4" Or xRcc.CodigoOrigen = "5" Or xRcc.CodigoOrigen = "6" Then

            'End If

            Dim sumadebe As Decimal = 0
            Dim sumahaber As Decimal = 0
            Dim iRcd As New SuperEntidad
            iRcd.ClaveRegContabCabe = xRcc.ClaveRegContabCabe
            Dim iLisRcd As New List(Of SuperEntidad)
            iLisRcd = rcd.obtenerDetalleRegContabPorClave(iRcd)
            For Each xobj As SuperEntidad In iLisRcd
                If xobj.DebeHaberRegContabDeta = "Debe" Then
                    sumadebe += xobj.ImporteSRegContabDeta
                Else
                    sumahaber += xobj.ImporteSRegContabDeta
                End If
            Next

            Dim iDif As Decimal = sumadebe - sumahaber
            If iDif <> 0 Then
                For Each xobj As SuperEntidad In iLisRcd
                    MsgBox(xRcc.ClaveRegContabCabe + "--" + sumadebe.ToString + "--" + sumahaber.ToString + "--" + iDif.ToString)
                    If iDif > 0 Then
                        If xobj.DebeHaberRegContabDeta = "Haber" Then
                            xobj.ImporteSRegContabDeta += iDif
                            '   rcd.EliminarRegistroDetalleXClaveDetalle(xobj)
                            '   rcd.nuevoRegContabDeta(xobj)
                            Exit For
                        End If
                    Else
                        If xobj.DebeHaberRegContabDeta = "Debe" Then
                            xobj.ImporteSRegContabDeta += Math.Abs(iDif)
                            '  rcd.EliminarRegistroDetalleXClaveDetalle(xobj)
                            '  rcd.nuevoRegContabDeta(xobj)
                            Exit For
                        End If
                    End If
                Next
            End If

            

        Next

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
            'Me.Ejecutar()
            Me.CuadrarAsientosMasivo()
            MsgBox("Proceso Termino")
        End If
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub
End Class