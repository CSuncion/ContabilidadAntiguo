Imports Entidad
Imports Negocio

Public Class WImpAnalisisCuentas
    Public ent, entCont, paren As New SuperEntidad
    Public lista, listarc As New List(Of SuperEntidad)
    Public rcdc As New MovimientoContableCabeceraRN
    Public rcdm As New MovimientoContableDetalleRN
    Public rcds As New SaldoContableRN
    Public par As New ParametroRN
    Dim cam As New CamposEntidad
    Dim ds As New DataSet1
    Dim tb As New DataTable
    Dim cr As New CrRptAnalisisCuentas
    Dim acc As New Accion
    Dim numerodigitos As String
    Dim ano, mes, empresa, periodo, ruc As CrystalDecisions.CrystalReports.Engine.TextObject

    Sub InicializaVentana()
        '/Para los eventos de controles
        acc.listaCtrls = Me.ListaControles
        acc.PasaFoco()
        acc.FomatoDato()
        acc.PasarCursor()
        acc.Teclazo()
        acc.Valida()
        Me.Show()
        Me.PorDefecto()
        Me.txtCodMes.Focus()
        'acc.Nuevo()
    End Sub

    Sub PorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.txtNomEmp.Text = SuperEntidad.xRazonSocial
        Me.txtAno.Text = SuperEntidad.xPeriodoEmpresa.Substring(0, 4)
        paren = par.buscarParametroExis(paren)
        numerodigitos = paren.DigitosCuentaAnalitica
    End Sub

    Sub Imprimir()

        ds.RegContab.Clear()
        'Llenar Cabecera()
        periodo = CType(Me.cr.Section2.ReportObjects.Item("Periodo"), CrystalDecisions.CrystalReports.Engine.TextObject)
        periodo.Text = Me.txtAno.Text + Me.txtCodMes.Text

        ruc = CType(Me.cr.Section2.ReportObjects.Item("Ruc"), CrystalDecisions.CrystalReports.Engine.TextObject)
        ruc.Text = SuperEntidad.xRucEmpresa

        empresa = CType(Me.cr.Section2.ReportObjects.Item("Empresa"), CrystalDecisions.CrystalReports.Engine.TextObject)
        empresa.Text = Me.txtNomEmp.Text


        '' Traer TODOS los movimientos 

        'ent.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        ent.DatoCondicion3 = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        ent.DatoCondicion4 = Me.txtAno.Text.Trim + Me.txtCodMes1.Text.Trim
        ent.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        ent.CodigoCuentaPcge = Me.TxtCodCta.Text.Trim
        ' ent.CampoOrden = cam.CodCtaPcge
        ent.CampoOrden = cam.FecVouRCC
        'TRAER MOVIMIENTO CABECERA 
        'listarc = rcdm.obtenerMovimientoDetalleXPeriodoYCuenta(ent)
        listarc = rcdm.obtenerMovimientoDetalleXCuentaYEntrePeriodo(ent)

        If listarc.Count = 0 Then
            Dim iCuenta As New SuperEntidad

            iCuenta.FechaDetraccionRegContabCabe = ""
            iCuenta.CodigoOrigen = ""
            iCuenta.CodigoFile = ""
            iCuenta.NumeroVoucherRegContabCabe = ""
            iCuenta.GlosaRegContabDeta = ""
            iCuenta.ImporteSRegContabDeta = 0
            'NewRow.Correlativo = obj.CorrelativoRegContabDeta
            iCuenta.TipoDocumento = ""
            iCuenta.FechaDocumento1 = ""
            iCuenta.SerieDocumento = ""
            iCuenta.NumeroDocumento = ""
            iCuenta.CodigoAuxiliar = ""
            iCuenta.CodigoCuentaPcge = Me.TxtCodCta.Text.Trim
            iCuenta.NombreCuentaPcge = Me.TxtNomCta.Text.Trim
            listarc.Add(iCuenta)

        End If


        Dim iCue As String = ""
        Dim osal As New SuperEntidad
        'MsgBox(listarc.Count.ToString)

        For Each obj As SuperEntidad In listarc

            Dim NewRow As DataSet1.RegContabRow
            NewRow = ds.RegContab.NewRegContabRow

            If obj.CodigoCuentaPcge <> iCue Then
                osal.ClaveSaldoContable = Me.TxtCodEmp.Text.Trim + obj.CodigoCuentaPcge + Me.txtAno.Text.Trim
                osal = rcds.buscarCuentaSaldoExisPorClave(osal)
                iCue = obj.CodigoCuentaPcge
            End If
            
            'Llenar Acumulados segun mes


            Select Case Me.txtCodMes.Text.Trim
                Case "00"
                    NewRow.ImporteDebeAcumulado = 0
                    NewRow.ImporteHaberAcumulado = 0
                Case "01"
                    NewRow.ImporteDebeAcumulado = osal.DebeS00SaldoContable
                    NewRow.ImporteHaberAcumulado = osal.HabeS00SaldoContable
                Case "02"
                    NewRow.ImporteDebeAcumulado = osal.DebeS00SaldoContable + osal.DebeS01SaldoContable
                    NewRow.ImporteHaberAcumulado = osal.HabeS00SaldoContable + osal.HabeS01SaldoContable
                Case "03"
                    NewRow.ImporteDebeAcumulado = osal.DebeS00SaldoContable + osal.DebeS01SaldoContable + osal.DebeS02SaldoContable
                    NewRow.ImporteHaberAcumulado = osal.HabeS00SaldoContable + osal.HabeS01SaldoContable + osal.HabeS02SaldoContable
                Case "04"
                    NewRow.ImporteDebeAcumulado = osal.DebeS00SaldoContable + osal.DebeS01SaldoContable + osal.DebeS02SaldoContable + osal.DebeS03SaldoContable
                    NewRow.ImporteHaberAcumulado = osal.HabeS00SaldoContable + osal.HabeS01SaldoContable + osal.HabeS02SaldoContable + osal.HabeS03SaldoContable
                Case "05"
                    NewRow.ImporteDebeAcumulado = osal.DebeS00SaldoContable + osal.DebeS01SaldoContable + osal.DebeS02SaldoContable + osal.DebeS03SaldoContable + osal.DebeS04SaldoContable
                    NewRow.ImporteHaberAcumulado = osal.HabeS00SaldoContable + osal.HabeS01SaldoContable + osal.HabeS02SaldoContable + osal.HabeS03SaldoContable + osal.HabeS04SaldoContable
                Case "06"
                    NewRow.ImporteDebeAcumulado = osal.DebeS00SaldoContable + osal.DebeS01SaldoContable + osal.DebeS02SaldoContable + osal.DebeS03SaldoContable + osal.DebeS04SaldoContable + osal.DebeS05SaldoContable
                    NewRow.ImporteHaberAcumulado = osal.HabeS00SaldoContable + osal.HabeS01SaldoContable + osal.HabeS02SaldoContable + osal.HabeS03SaldoContable + osal.HabeS04SaldoContable + osal.HabeS05SaldoContable
                Case "07"
                    NewRow.ImporteDebeAcumulado = osal.DebeS00SaldoContable + osal.DebeS01SaldoContable + osal.DebeS02SaldoContable + osal.DebeS03SaldoContable + osal.DebeS04SaldoContable + osal.DebeS05SaldoContable + osal.DebeS06SaldoContable
                    NewRow.ImporteHaberAcumulado = osal.HabeS00SaldoContable + osal.HabeS01SaldoContable + osal.HabeS02SaldoContable + osal.HabeS03SaldoContable + osal.HabeS04SaldoContable + osal.HabeS05SaldoContable + osal.HabeS06SaldoContable
                Case "08"
                    NewRow.ImporteDebeAcumulado = osal.DebeS00SaldoContable + osal.DebeS01SaldoContable + osal.DebeS02SaldoContable + osal.DebeS03SaldoContable + osal.DebeS04SaldoContable + osal.DebeS05SaldoContable + osal.DebeS06SaldoContable + osal.DebeS07SaldoContable
                    NewRow.ImporteHaberAcumulado = osal.HabeS00SaldoContable + osal.HabeS01SaldoContable + osal.HabeS02SaldoContable + osal.HabeS03SaldoContable + osal.HabeS04SaldoContable + osal.HabeS05SaldoContable + osal.HabeS06SaldoContable + osal.HabeS07SaldoContable
                Case "09"
                    NewRow.ImporteDebeAcumulado = osal.DebeS00SaldoContable + osal.DebeS01SaldoContable + osal.DebeS02SaldoContable + osal.DebeS03SaldoContable + osal.DebeS04SaldoContable + osal.DebeS05SaldoContable + osal.DebeS06SaldoContable + osal.DebeS07SaldoContable + osal.DebeS08SaldoContable
                    NewRow.ImporteHaberAcumulado = osal.HabeS00SaldoContable + osal.HabeS01SaldoContable + osal.HabeS02SaldoContable + osal.HabeS03SaldoContable + osal.HabeS04SaldoContable + osal.HabeS05SaldoContable + osal.HabeS06SaldoContable + osal.HabeS07SaldoContable + osal.HabeS08SaldoContable
                Case "10"
                    NewRow.ImporteDebeAcumulado = osal.DebeS00SaldoContable + osal.DebeS01SaldoContable + osal.DebeS02SaldoContable + osal.DebeS03SaldoContable + osal.DebeS04SaldoContable + osal.DebeS05SaldoContable + osal.DebeS06SaldoContable + osal.DebeS07SaldoContable + osal.DebeS08SaldoContable + osal.DebeS09SaldoContable
                    NewRow.ImporteHaberAcumulado = osal.HabeS00SaldoContable + osal.HabeS01SaldoContable + osal.HabeS02SaldoContable + osal.HabeS03SaldoContable + osal.HabeS04SaldoContable + osal.HabeS05SaldoContable + osal.HabeS06SaldoContable + osal.HabeS07SaldoContable + osal.HabeS08SaldoContable + osal.HabeS09SaldoContable
                Case "11"
                    NewRow.ImporteDebeAcumulado = osal.DebeS00SaldoContable + osal.DebeS01SaldoContable + osal.DebeS02SaldoContable + osal.DebeS03SaldoContable + osal.DebeS04SaldoContable + osal.DebeS05SaldoContable + osal.DebeS06SaldoContable + osal.DebeS07SaldoContable + osal.DebeS08SaldoContable + osal.DebeS09SaldoContable + osal.DebeS10SaldoContable
                    NewRow.ImporteHaberAcumulado = osal.HabeS00SaldoContable + osal.HabeS01SaldoContable + osal.HabeS02SaldoContable + osal.HabeS03SaldoContable + osal.HabeS04SaldoContable + osal.HabeS05SaldoContable + osal.HabeS06SaldoContable + osal.HabeS07SaldoContable + osal.HabeS08SaldoContable + osal.HabeS09SaldoContable + osal.HabeS10SaldoContable
                Case "12"
                    NewRow.ImporteDebeAcumulado = osal.DebeS00SaldoContable + osal.DebeS01SaldoContable + osal.DebeS02SaldoContable + osal.DebeS03SaldoContable + osal.DebeS04SaldoContable + osal.DebeS05SaldoContable + osal.DebeS06SaldoContable + osal.DebeS07SaldoContable + osal.DebeS08SaldoContable + osal.DebeS09SaldoContable + osal.DebeS10SaldoContable + osal.DebeS11SaldoContable
                    NewRow.ImporteHaberAcumulado = osal.HabeS00SaldoContable + osal.HabeS01SaldoContable + osal.HabeS02SaldoContable + osal.HabeS03SaldoContable + osal.HabeS04SaldoContable + osal.HabeS05SaldoContable + osal.HabeS06SaldoContable + osal.HabeS07SaldoContable + osal.HabeS08SaldoContable + osal.HabeS09SaldoContable + osal.HabeS10SaldoContable + osal.HabeS11SaldoContable

            End Select
            If obj.CodigoOrigen = "" Then
                NewRow.FechaDetraccion = ""
            Else
                NewRow.FechaDetraccion = obj.FechaVoucherRegContabCabe.ToShortDateString
            End If

            NewRow.CodigoOrigen = obj.CodigoOrigen
            NewRow.CodigoFile = obj.CodigoFile
            NewRow.NumeroVoucherRegContab = obj.NumeroVoucherRegContabCabe
            NewRow.GlosaRegContab = obj.GlosaRegContabDeta
            'Si Debe / Haber 
            If obj.DebeHaberRegContabDeta = "Debe" Then
                NewRow.ImporteDebe = obj.ImporteSRegContabDeta
                NewRow.ImporteHaber = 0
            Else
                NewRow.ImporteDebe = 0
                NewRow.ImporteHaber = obj.ImporteSRegContabDeta
            End If

            'NewRow.Correlativo = obj.CorrelativoRegContabDeta
            NewRow.TipoDocumento = obj.TipoDocumento
            If obj.CodigoOrigen = "" Then
                NewRow.Fecha1 = ""
                NewRow.TipoLibro = ""
            Else
                NewRow.Fecha1 = obj.FechaDocumento.ToShortDateString ''Por que datatable es String
                NewRow.TipoLibro = "6"
            End If

            NewRow.SerieDocumento = obj.SerieDocumento
            NewRow.NumeroDocumento = obj.NumeroDocumento



            NewRow.CodigoAuxiliar = obj.CodigoAuxiliar
            NewRow.Cuenta = obj.CodigoCuentaPcge
            NewRow.nombrecuenta = obj.NombreCuentaPcge

            NewRow.Correlativo = obj.CorrelativoRegContabDeta


            'AGREGANDO REGISTROS AL DATATABLE
            'LLENANDO EL REGISTRO
            'AÑADIR AL DS
            ds.RegContab.Rows.Add(NewRow)

        Next

        cr.SetDataSource(ds)
        'Cargamos en nuestro formulario el cr
        Me.crv1.ReportSource = cr
        'Dim win As New wImpParaEnvio
        'win.NuevaVentana(ds)
        '/
    End Sub

    Private Sub btnEjecutar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEjecutar.Click
        If acc.CamposObligatorios = False Then
            Exit Sub
        Else
            Me.Imprimir()
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Dim rpta As Integer = MsgBox("Deseas cancelar la operacion", MsgBoxStyle.YesNo, "Matriz")
        If rpta = MsgBoxResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
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
                win.ctrlFoco = Me.txtCodMes1
                win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub txtCodMes1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodMes1.KeyDown
        If Me.txtCodMes1.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarTabla
                win.tabla = "Mes"
                win.titulo = "Meses"
                win.txt1 = Me.txtCodMes1
                win.txt2 = Me.txtDesMes1
                win.ctrlFoco = Me.TxtCodCta
                win.NuevaVentana()
            End If
        End If
    End Sub


    Private Sub txtCodCta_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodCta.KeyDown

        If Me.TxtCodCta.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarPlanCuentaGe
                win.tabla = "CuentasAnaliticas"    ''va la condicion del case
                win.titulo = "Cuentas"
                win.txt1 = Me.TxtCodCta
                win.txt2 = Me.TxtNomCta
                win.ctrlFoco = Me.btnEjecutar
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

    Private Sub txtCodMes1_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodMes1.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.txtCodMes1 : ope.txt2 = Me.txtDesMes1
        ope.MostrarCodigoDescripcionDeTabla("Mes", "Meses", e)
    End Sub

    Private Sub txtCodCta_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodCta.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.TxtCodCta : ope.txt2 = Me.TxtNomCta
        ope.Condicion = "CuentasAnaliticas"
        ope.MostrarCodigoDescripcionDePlancuentas("CuentasAnaliticas", e)
    End Sub

#End Region

    
End Class