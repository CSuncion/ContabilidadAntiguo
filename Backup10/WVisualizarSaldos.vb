Imports Entidad
Imports Negocio

Public Class WVisualizarSaldos

    Public listaPc, listaPcE As New List(Of SuperEntidad)
    Public cue As New PlanDeCuentasRN
    Public emp As New EmpresaRN
    Public empCue As New PlanCuentaGeRN
    Public cam As New CamposEntidad
    Public ent As New SuperEntidad
    Public titulo As String = "PlanDeCuentas"
    Public cemp As String
    Dim regActual As Integer = 0
    Public ds As New DataSet1


    Sub NuevaVentana()
        Me.Show()
        Me.PorDefecto()
        Me.ActualizarDgvCueEmp()
        Me.CargarDgvSaldos()
        Me.CargarDetalleCuentaPorMes()
    End Sub

    Sub PorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.txtNomEmp.Text = SuperEntidad.xRazonSocial
    End Sub
    Sub ActualizarDgvCueEmp()
        '/Refrescando el DataSource de DgvUsu
        ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        ent.CampoOrden = cam.CodCtaPcge
        listaPcE = empCue.obtenerCuentaExisPorEmpresa(ent)

        '/Refrescando el DataSource de DgvUsu
        Dgv.refrescarFuenteDatosGrilla(Me.DgvCueEmp, listaPcE)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvCueEmp, cam.CodCtaPcge, "Codigo", 70)
        Dgv.asignarColumnaText(Me.DgvCueEmp, cam.NomCtaPcge, "Nombre", 360)
        '//
    End Sub

    Sub CargarDgvSaldos()
        '/

        'Limipar datatable
        ds.VistaSaldos.Clear()

        Dim ob As New SuperEntidad
        Dim sc As New SaldoContableRN

        '/Obtener el codigo de usuario
        Dim cta As String = Dgv.obtenerValorCelda(Me.DgvCueEmp, cam.CodCtaPcge)
        'MsgBox(SuperEntidad.xPeriodoEmpresa)
        ob.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + cta + SuperEntidad.xPeriodoEmpresa.Substring(0, 4)
        ob = sc.buscarCuentaSaldoExisPorClave(ob)
        Dim sa As Decimal = 0

        For n As Integer = 0 To 13


            Dim NewRow As DataSet1.VistaSaldosRow
            NewRow = ds.VistaSaldos.NewVistaSaldosRow

            Select Case n

                Case 0
                    NewRow.Mes = "Apertura"
                    NewRow.Debe = Varios.numeroConDosDecimal(ob.DebeS00SaldoContable.ToString)
                    NewRow.Haber = Varios.numeroConDosDecimal(ob.HabeS00SaldoContable.ToString)
                    NewRow.Saldo = Varios.numeroConDosDecimal((ob.DebeS00SaldoContable - ob.HabeS00SaldoContable).ToString)
                    NewRow.Mayor = Varios.numeroConDosDecimal((ob.DebeS00SaldoContable - ob.HabeS00SaldoContable).ToString)
                    sa = CType(NewRow.Mayor, Decimal)
                Case 1
                    NewRow.Mes = "Enero"
                    NewRow.Debe = Varios.numeroConDosDecimal(ob.DebeS01SaldoContable.ToString)
                    NewRow.Haber = Varios.numeroConDosDecimal(ob.HabeS01SaldoContable.ToString)
                    NewRow.Saldo = Varios.numeroConDosDecimal((ob.DebeS01SaldoContable - ob.HabeS01SaldoContable).ToString)
                    NewRow.Mayor = Varios.numeroConDosDecimal((sa + CType(NewRow.Saldo, Decimal)).ToString)
                    sa = CType(NewRow.Mayor, Decimal)

                Case 2
                    NewRow.Mes = "Febrero"
                    NewRow.Debe = Varios.numeroConDosDecimal(ob.DebeS02SaldoContable.ToString)
                    NewRow.Haber = Varios.numeroConDosDecimal(ob.HabeS02SaldoContable.ToString)
                    NewRow.Saldo = Varios.numeroConDosDecimal((ob.DebeS02SaldoContable - ob.HabeS02SaldoContable).ToString)
                    NewRow.Mayor = Varios.numeroConDosDecimal((sa + CType(NewRow.Saldo, Decimal)).ToString)
                    sa = CType(NewRow.Mayor, Decimal)


                Case 3
                    NewRow.Mes = "Marzo"
                    NewRow.Debe = Varios.numeroConDosDecimal(ob.DebeS03SaldoContable.ToString)
                    NewRow.Haber = Varios.numeroConDosDecimal(ob.HabeS03SaldoContable.ToString)
                    NewRow.Saldo = Varios.numeroConDosDecimal((ob.DebeS03SaldoContable - ob.HabeS03SaldoContable).ToString)
                    NewRow.Mayor = Varios.numeroConDosDecimal((sa + CType(NewRow.Saldo, Decimal)).ToString)
                    sa = CType(NewRow.Mayor, Decimal)


                Case 4
                    NewRow.Mes = "Abril"
                    NewRow.Debe = Varios.numeroConDosDecimal(ob.DebeS04SaldoContable.ToString)
                    NewRow.Haber = Varios.numeroConDosDecimal(ob.HabeS04SaldoContable.ToString)
                    NewRow.Saldo = Varios.numeroConDosDecimal((ob.DebeS04SaldoContable - ob.HabeS04SaldoContable).ToString)
                    NewRow.Mayor = Varios.numeroConDosDecimal((sa + CType(NewRow.Saldo, Decimal)).ToString)
                    sa = CType(NewRow.Mayor, Decimal)


                Case 5
                    NewRow.Mes = "Mayo"
                    NewRow.Debe = Varios.numeroConDosDecimal(ob.DebeS05SaldoContable.ToString)
                    NewRow.Haber = Varios.numeroConDosDecimal(ob.HabeS05SaldoContable.ToString)
                    NewRow.Saldo = Varios.numeroConDosDecimal((ob.DebeS05SaldoContable - ob.HabeS05SaldoContable).ToString)
                    NewRow.Mayor = Varios.numeroConDosDecimal((sa + CType(NewRow.Saldo, Decimal)).ToString)
                    sa = CType(NewRow.Mayor, Decimal)


                Case 6
                    NewRow.Mes = "Junio"
                    NewRow.Debe = Varios.numeroConDosDecimal(ob.DebeS06SaldoContable.ToString)
                    NewRow.Haber = Varios.numeroConDosDecimal(ob.HabeS06SaldoContable.ToString)
                    NewRow.Saldo = Varios.numeroConDosDecimal((ob.DebeS06SaldoContable - ob.HabeS06SaldoContable).ToString)
                    NewRow.Mayor = Varios.numeroConDosDecimal((sa + CType(NewRow.Saldo, Decimal)).ToString)
                    sa = CType(NewRow.Mayor, Decimal)


                Case 7
                    NewRow.Mes = "Julio"
                    NewRow.Debe = Varios.numeroConDosDecimal(ob.DebeS07SaldoContable.ToString)
                    NewRow.Haber = Varios.numeroConDosDecimal(ob.HabeS07SaldoContable.ToString)
                    NewRow.Saldo = Varios.numeroConDosDecimal((ob.DebeS07SaldoContable - ob.HabeS07SaldoContable).ToString)
                    NewRow.Mayor = Varios.numeroConDosDecimal((sa + CType(NewRow.Saldo, Decimal)).ToString)
                    sa = CType(NewRow.Mayor, Decimal)


                Case 8
                    NewRow.Mes = "Agosto"
                    NewRow.Debe = Varios.numeroConDosDecimal(ob.DebeS08SaldoContable.ToString)
                    NewRow.Haber = Varios.numeroConDosDecimal(ob.HabeS08SaldoContable.ToString)
                    NewRow.Saldo = Varios.numeroConDosDecimal((ob.DebeS08SaldoContable - ob.HabeS08SaldoContable).ToString)
                    NewRow.Mayor = Varios.numeroConDosDecimal((sa + CType(NewRow.Saldo, Decimal)).ToString)
                    sa = CType(NewRow.Mayor, Decimal)


                Case 9
                    NewRow.Mes = "Setiembre"
                    NewRow.Debe = Varios.numeroConDosDecimal(ob.DebeS09SaldoContable.ToString)
                    NewRow.Haber = Varios.numeroConDosDecimal(ob.HabeS09SaldoContable.ToString)
                    NewRow.Saldo = Varios.numeroConDosDecimal((ob.DebeS09SaldoContable - ob.HabeS09SaldoContable).ToString)
                    NewRow.Mayor = Varios.numeroConDosDecimal((sa + CType(NewRow.Saldo, Decimal)).ToString)
                    sa = CType(NewRow.Mayor, Decimal)


                Case 10
                    NewRow.Mes = "Octubre"
                    NewRow.Debe = Varios.numeroConDosDecimal(ob.DebeS10SaldoContable.ToString)
                    NewRow.Haber = Varios.numeroConDosDecimal(ob.HabeS10SaldoContable.ToString)
                    NewRow.Saldo = Varios.numeroConDosDecimal((ob.DebeS10SaldoContable - ob.HabeS10SaldoContable).ToString)
                    NewRow.Mayor = Varios.numeroConDosDecimal((sa + CType(NewRow.Saldo, Decimal)).ToString)
                    sa = CType(NewRow.Mayor, Decimal)


                Case 11
                    NewRow.Mes = "Noviembre"
                    NewRow.Debe = Varios.numeroConDosDecimal(ob.DebeS11SaldoContable.ToString)
                    NewRow.Haber = Varios.numeroConDosDecimal(ob.HabeS11SaldoContable.ToString)
                    NewRow.Saldo = Varios.numeroConDosDecimal((ob.DebeS11SaldoContable - ob.HabeS11SaldoContable).ToString)
                    NewRow.Mayor = Varios.numeroConDosDecimal((sa + CType(NewRow.Saldo, Decimal)).ToString)
                    sa = CType(NewRow.Mayor, Decimal)



                Case 12
                    NewRow.Mes = "Diciembre"
                    NewRow.Debe = Varios.numeroConDosDecimal(ob.DebeS12SaldoContable.ToString)
                    NewRow.Haber = Varios.numeroConDosDecimal(ob.HabeS12SaldoContable.ToString)
                    NewRow.Saldo = Varios.numeroConDosDecimal((ob.DebeS12SaldoContable - ob.HabeS12SaldoContable).ToString)
                    NewRow.Mayor = Varios.numeroConDosDecimal((sa + CType(NewRow.Saldo, Decimal)).ToString)
                    sa = CType(NewRow.Mayor, Decimal)

            End Select
            'AGREGANDO REGISTROS AL DATATABLE 

            'LLENANDO EL REGISTRO

            'AÑADIR AL DS
            ds.VistaSaldos.Rows.Add(NewRow)
        Next
        Me.dgvSaldos.DataSource = ds.VistaSaldos

        '/
    End Sub

    Sub TituloSaldoCuenta()
        Dim iAno As String = SuperEntidad.xPeriodoEmpresa.Substring(0, 4)
        Dim iCuenta As String = Dgv.obtenerValorCelda(Me.DgvCueEmp, cam.CodCtaPcge)
        Dim iMes As String = Dgv.obtenerValorCelda(Me.dgvSaldos, "Mes")
        Me.lblSaldo.Text = "SALDOS DE LA CUENTA : " + iCuenta + " DEL AÑO :" + iAno
    End Sub

    Sub TituloDetalleCuenta()
        Dim iNroReg As Integer = Me.dgvDeta.Rows.Count
        Dim iAno As String = SuperEntidad.xPeriodoEmpresa.Substring(0, 4)
        Dim iCuenta As String = Dgv.obtenerValorCelda(Me.DgvCueEmp, cam.CodCtaPcge)
        Dim iMes As String = Dgv.obtenerValorCelda(Me.dgvSaldos, "Mes")
        Me.lblCabeVou.Text = "DETALLE DEL VOUCHER DE LA CUENTA : " + iCuenta + " EN EL MES DE :" + iMes + " DEL AÑO :" + iAno + "/ Nro Registros : " + iNroReg.ToString
    End Sub

    Sub CargarDetalleCuentaPorMes()
        'INSTANCIAR OBJETO DE NEGOCIO
        Dim mcdRN As New MovimientoContableDetalleRN
        Dim mcdEN As New SuperEntidad

        'LLENADO LOS PARAMETROS RESPECTIVOS
        mcdEN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        mcdEN.CodigoCuentaPcge = Dgv.obtenerValorCelda(Me.DgvCueEmp, cam.CodCtaPcge)
        'OBTENER EL NUMERO DEL MES
        Dim iNroMes As String = Varios.ObtenerNumeroMes(Dgv.obtenerValorCelda(Me.dgvSaldos, "Mes"))
        mcdEN.PeriodoRegContabCabe = SuperEntidad.xPeriodoEmpresa.Substring(0, 4) + iNroMes
        'ORDEN DE LA LISTA DE DETALLE
        mcdEN.CampoOrden = cam.ClaveRCD

        'CARGAR GRILLA
        Dgv.refrescarFuenteDatosGrilla(Me.dgvDeta, mcdRN.obtenerMovimientoDetalleXPeriodoYCuenta(mcdEN))
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.dgvDeta, cam.ClaveRCC, "Clave", 130)
        Dgv.asignarColumnaText(Me.dgvDeta, cam.CodOriRC, "Origen", 40)
        Dgv.asignarColumnaText(Me.dgvDeta, cam.NomOriRC, "Descripción", 90)
        Dgv.asignarColumnaText(Me.dgvDeta, cam.CodFilRC, "File", 40)
        Dgv.asignarColumnaText(Me.dgvDeta, cam.NomFilRC, "Descripción", 180)
        Dgv.asignarColumnaText(Me.dgvDeta, cam.NumVouRCC, "N°.Vaucher", 100)
        Dgv.asignarColumnaText(Me.dgvDeta, cam.FecVouRCC, "Fecha Voucher", 110)
        Dgv.asignarColumnaText(Me.dgvDeta, cam.DebHabRCD, "D/H", 60)
        Dgv.asignarColumnaText(Me.dgvDeta, cam.CodCtaPcge, "Cuenta", 85)
        Dgv.AsignarColumnaTextNumerico(Me.dgvDeta, cam.ImpSRCD, "Importe S/.", 100, 2)
        Dgv.AsignarColumnaTextNumerico(Me.dgvDeta, cam.ImpDRCD, "Importe us$", 100, 2)
        Dgv.AsignarColumnaTextNumerico(Me.dgvDeta, cam.ImpERCD, "Importe EUR", 100, 2)
        Dgv.asignarColumnaText(Me.dgvDeta, cam.GlosaRCD, "Glosa", 150)
        Dgv.asignarColumnaText(Me.dgvDeta, cam.CodCC, "Centro Costo", 150)
        Dgv.asignarColumnaText(Me.dgvDeta, cam.CodAux, "Auxiliar", 150)

    End Sub



    Private Sub txtCueEmp_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCueEmp.KeyUp
        Dim texto As String = Me.txtCueEmp.Text.Trim
        Dgv.buscarEnColumna(Me.DgvCueEmp, cam.CodCtaPcge, texto)
    End Sub

    Private Sub dgvCueEmp_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvCueEmp.CellEnter
        Me.CargarDgvSaldos()
        Me.TituloSaldoCuenta()
    End Sub

    Private Sub dgvSaldos_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSaldos.CellEnter
        Me.CargarDetalleCuentaPorMes()
        Me.TituloDetalleCuenta()
    End Sub
End Class