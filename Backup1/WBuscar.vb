Imports Entidad
Public Class WBuscar

#Region "Propietario de esta ventana"
    Public wUsu As WUsuario
    Public wTab As WTabla
    Public wMes As WMeses
    Public wAux As WAuxiliar
    Public wRc As WRegistroCompra
    Public wRd As WRegistroDiario
    Public wRh As WRegistroHonorario
    Public wCv As WConsultaVouchers
    Public wCvT As WVouchersTodos
    Public wTabRec As WTablaRecycla
    Public wAuxRec As WAuxiliarRecycla
    Public wTipCamRec As WTipoCambioRecycla
    Public wPcg As WPlanCuentaGe
    Public wPcgRecy As WPlanCuentaGeRecycla
    Public wEmp As WEmpresa
    Public wEmpRecy As WEmpresaRecycla
    Public wBco As WCuentaBanco
    Public wBcorec As WCuentaBancoRecycla
    Public wPcge As WPcge
    Public wPcta As WPcge
    Public wPctaRec As WPlanDeCuentasRecycla
    Public wRv As WRegistroVenta
    Public wRvEs As WRegistroVentaEspecial
    Public wVou As WVoucher
    Public wVouRec As WVoucherRecycla
    Public wCbco As WRegistroCajaBanco
    Public wTrans As WTransferencia
    Public wFcon As WFormatoContable
    Public wFconRec As WFormatoContableRecycla
    Public wSal As WSaldoContable
    Public wTc As WTipoCambio
    Public wCtaCte As WCuentaCorriente
    Public wCtaCte1 As XWDocumentosAPagar
    Public wAlm As WAlmacen
    Public wFil As WFiles
    Public WOpc As WOpcion
    Public WVen As WVentana
    Public wPer As WPeriodo
    Public wAre As WArea
    Public wFlu As WFlujoCaja
    Public wIngEgr As WIngresoEgreso
    Public wCenCto As WCentroCosto
    Public wSumIngEgr As WSumaIngEgr
    Public wAfps As WAfp
    Public wGasRep As WGastoReparable

#End Region
    Public titulo As String
    Public cam As New CamposEntidad
#Region "Metodos"

    Sub ventanaBuscar(ByRef columnaBusqueda As String)
        Me.Owner.Enabled = False
        Me.Text = "Buscar " + Me.titulo
        'Me.Text = "Buscar " + Me.Owner.Tag.ToString
        ' Me.lblCampo.Text = columnaBusqueda
        Me.GroupBox1.Text = "Criterio Busqueda/Por :" + columnaBusqueda
        Me.Show()
    End Sub

#End Region

    Private Sub WBuscarUsuario_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub txtBus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBus.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then Me.Close()
    End Sub

    Private Sub txtBus_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBus.KeyUp
        Dim texto As String = Me.txtBus.Text
        Select Case Me.Owner.Name.ToString
            Case "WUsuario" : Dgv.buscarEnColumna(Me.wUsu.DgvUsu, Me.wUsu.ent.CampoOrden, texto)
            Case "WTabla" : Dgv.buscarEnColumna(Me.wTab.DgvDis, Me.wTab.ent.CampoOrden, texto)
            Case "WAuxiliar" : Dgv.buscarEnColumna(Me.wAux.DgvAux, Me.wAux.ent.CampoOrden, texto)
            Case "WMes" : Dgv.buscarEnColumna(Me.wMes.DgvMes, Me.wMes.ent.CampoOrden, texto)
            Case "WRegistroCajaBanco" : Dgv.buscarEnColumna(Me.wCbco.DgvCbco, Me.wCbco.ent.CampoOrden, texto)
            Case "WRegistroCompra" : Dgv.buscarEnColumna(Me.wRc.DgvRcom, Me.wRc.ent.CampoOrden, texto)
                'Case "WRegVentas" : Dgv.buscarEnColumna(Me.wRv.DgvRVta, Me.wRv.ent.CampoOrden, texto)
            Case "WRegistroDiario" : Dgv.buscarEnColumna(Me.wRd.DgvDia, Me.wRd.ent.CampoOrden, texto)
            Case "WRegistroHonorarios" : Dgv.buscarEnColumna(Me.wRh.DgvHon, Me.wRh.ent.CampoOrden, texto)
            Case "WTablaRecycla" : Dgv.buscarEnColumna(Me.wTabRec.DgvPer, Me.wTabRec.ent.CampoOrden, texto)
            Case "WAuxiliarRecycla" : Dgv.buscarEnColumna(Me.wAuxRec.DgvPer, Me.wAuxRec.ent.CampoOrden, texto)
            Case "WTipoCambioRecycla" : Dgv.buscarEnColumna(Me.wTipCamRec.DgvPer, Me.wTipCamRec.ent.CampoOrden, texto)
            Case "WPlanCuentaGe" : Dgv.buscarEnColumna(Me.wPcg.DgvPcg, Me.wPcg.ent.CampoOrden, texto)
            Case "WPlanCuentaGeRecycla" : Dgv.buscarEnColumna(Me.wPcgRecy.DgvPcgRecy, Me.wPcgRecy.ent.CampoOrden, texto)
            Case "WPlanDeCuentas" : Dgv.buscarEnColumna(Me.wPcta.DgvPctaRec, Me.wPcta.ent.CampoOrden, texto)
            Case "WPlanDeCuentasRecycla" : Dgv.buscarEnColumna(Me.wPctaRec.DgvCta, Me.wPctaRec.ent.CampoOrden, texto)
            Case "WEmpresa" : Dgv.buscarEnColumna(Me.wEmp.DgvEmp, Me.wEmp.ent.CampoOrden, texto)
            Case "WEmpresaRecycla" : Dgv.buscarEnColumna(Me.wEmpRecy.DgvEmpRecy, Me.wEmpRecy.ent.CampoOrden, texto)
            Case "WCuentaBanco" : Dgv.buscarEnColumna(Me.wBco.DgvBco, Me.wBco.ent.CampoOrden, texto)
            Case "WCuentaBancoRecycla" : Dgv.buscarEnColumna(Me.wBcorec.DgvCBcoRec, Me.wBcorec.ent.CampoOrden, texto)
            Case "WRegistroVenta" : Dgv.buscarEnColumna(Me.wRv.DgvRVta, Me.wRv.ent.CampoOrden, texto)
            Case "WRegistroVentaEspecial" : Dgv.buscarEnColumna(Me.wRvEs.DgvRVtaEsp, Me.wBco.ent.CampoOrden, texto)
            Case "WVoucher" : Dgv.buscarEnColumna(Me.wVou.DgvVou, Me.wVou.ent.CampoOrden, texto)
            Case "WVoucherRecycla" : Dgv.buscarEnColumna(Me.wVou.DgvVou, Me.wVou.ent.CampoOrden, texto)
            Case "WTransferencia" : Dgv.buscarEnColumna(Me.wTrans.DgvTrans, Me.wTrans.ent.CampoOrden, texto)
            Case "WFormatoContable" : Dgv.buscarEnColumna(Me.wFcon.DgvFcon, Me.wFcon.ent.CampoOrden, texto)
            Case "WFormatoContableRecycla" : Dgv.buscarEnColumna(Me.wFcon.DgvFcon, Me.wFcon.ent.CampoOrden, texto)
            Case "WSaldoContable" : Dgv.buscarEnColumna(Me.wSal.DgvSaldo, Me.wSal.ent.CampoOrden, texto)
            Case "WTipoCambio" : Dgv.buscarEnColumna(Me.wTc.DgvDis, Me.wTc.ent.CampoOrden, texto)
            Case "WConsultaVouchers" : Dgv.buscarEnColumna(Me.wCv.DgvMovCabe, Me.wCv.ent.CampoOrden, texto)
            Case "WVouchersTodos"
                If Me.wCvT.ent.CampoOrden = cam.ClaveRCC Then
                    Dgv.buscarEnColumna(Me.wCvT.DgvMovCabe, cam.ClaConVou, texto)
                Else
                    Dgv.buscarEnColumna(Me.wCvT.DgvMovCabe, Me.wCvT.ent.CampoOrden, texto)
                End If
            Case "WCuentaCorriente" : Dgv.buscarEnColumna(Me.wCtaCte.DgvCtaCte, Me.wCtaCte.ent.CampoOrden, texto)
            Case "WDocumentosAPagar" : Dgv.buscarEnColumna(Me.wCtaCte1.DgvCtaCte, Me.wCtaCte1.ent.CampoOrden, texto)
            Case "WAlmacen" : Dgv.buscarEnColumna(Me.wAlm.DgvAlm, Me.wAlm.ent.CampoOrden, texto)
            Case "WFiles" : Dgv.buscarEnColumna(Me.wFil.DgvFil, Me.wFil.ent.CampoOrden, texto)
            Case "WOpcion" : Dgv.buscarEnColumna(Me.WOpc.DgvVen, Me.WOpc.ent.CampoOrden, texto)
            Case "WVentana" : Dgv.buscarEnColumna(Me.WVen.DgvVen, Me.WVen.ent.CampoOrden, texto)
            Case "WPeriodo" : Dgv.buscarEnColumna(Me.wPer.DgvPer, Me.wPer.ent.CampoOrden, texto)
            Case "WArea" : Dgv.buscarEnColumna(Me.wAre.DgvAre, Me.wAre.ent.CampoOrden, texto)
            Case "WFlujoCaja" : Dgv.buscarEnColumna(Me.wFlu.DgvFlu, Me.wFlu.ent.CampoOrden, texto)
            Case "WIngresoEgreso" : Dgv.buscarEnColumna(Me.wIngEgr.DgvIngEgr, Me.wIngEgr.ent.CampoOrden, texto)
            Case "WCentroCosto" : Dgv.buscarEnColumna(Me.wCenCto.DgvCenCto, Me.wCenCto.ent.CampoOrden, texto)
            Case "WSumaIngEgr" : Dgv.buscarEnColumna(Me.wSumIngEgr.DgvSumIngEgr, Me.wSumIngEgr.ent.CampoOrden, texto)
            Case "WAfp" : Dgv.buscarEnColumna(Me.wAfps.DgvAfp, Me.wAfps.ent.CampoOrden, texto)
            Case "WGastoReparable" : Dgv.buscarEnColumna(Me.wGasRep.DgvGasRep, Me.wGasRep.ent.CampoOrden, texto)
        End Select
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class