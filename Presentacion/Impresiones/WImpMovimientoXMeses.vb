Imports Entidad
Imports Negocio

Public Class WImpMovimientoXMeses
    Dim cam As New CamposEntidad
    Dim ds As New DataSet1
    Dim acc As New Accion
    Dim numerodigitos As String
    Dim empresa, periodo As CrystalDecisions.CrystalReports.Engine.TextObject

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
        Me.ComboBox1.SelectedIndex = 0
        Me.txtCodMes.Focus()
        'acc.Nuevo()
    End Sub

    Sub PorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.txtNomEmp.Text = SuperEntidad.xRazonSocial
        Me.txtAno.Text = SuperEntidad.xPeriodoEmpresa.Substring(0, 4)
    End Sub

    Sub Imprimir()

        ds.RegContab.Clear()
        'Llenar Cabecera()
        periodo = CType(Me.CrMovimientoMes1.Section2.ReportObjects.Item("Periodo"), CrystalDecisions.CrystalReports.Engine.TextObject)
        periodo.Text = Me.txtDesMes.Text + " " + Me.txtAno.Text

        empresa = CType(Me.CrMovimientoMes1.Section2.ReportObjects.Item("Empresa"), CrystalDecisions.CrystalReports.Engine.TextObject)
        empresa.Text = Me.txtNomEmp.Text

        '' Traer todos los registros contables detalle del periodo elegido
        Dim iRcdRN As New RegContabDetaRN
        Dim iRcdEN As New SuperEntidad
        iRcdEN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        ' iRcdEN.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        iRcdEN.DatoFiltro1 = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        iRcdEN.DatoFiltro2 = Me.txtAno.Text.Trim + Me.TxtCodMes1.Text.Trim
        iRcdEN.CodigoOrigen = ""
        iRcdEN.CampoOrden = cam.CodCtaPcge
        'TRAER MOVIMIENTO CABECERA 
        Dim listarc As List(Of SuperEntidad) = iRcdRN.ListarRegistrosContablesDetalleXPeriodosSinExtorno(iRcdEN)

        For Each obj As SuperEntidad In listarc
            If Me.ComboBox1.Text = "Todos" Then
                Dim NewRow As DataSet1.RegContabRow
                NewRow = ds.RegContab.NewRegContabRow
                NewRow.FechaVoucherrgContab = obj.FechaVoucherRegContabCabe
                NewRow.CodigoOrigen = obj.CodigoOrigen
                NewRow.CodigoFile = obj.CodigoFile
                NewRow.NumeroVoucherRegContab = obj.NumeroVoucherRegContabCabe
                NewRow.NumeroDocumento = obj.NumeroDocumento
                NewRow.Cuenta = obj.CodigoCuentaPcge
                NewRow.nombrecuenta = obj.NombreCuentaPcge
                NewRow.CentroCosto = obj.CodigoCentroCosto
                NewRow.GlosaRegContab = obj.GlosaRegContabDeta
                If obj.DebeHaberRegContabDeta = "Debe" Then
                    NewRow.ImporteDebe = obj.ImporteSRegContabDeta
                    NewRow.ImporteHaber = 0
                Else
                    NewRow.ImporteDebe = 0
                    NewRow.ImporteHaber = obj.ImporteSRegContabDeta
                End If
                NewRow.Saldos = NewRow.ImporteDebe - NewRow.ImporteHaber
                'AGREGANDO REGISTROS AL DATATABLE
                'LLENANDO EL REGISTRO
                'AÑADIR AL DS
                ds.RegContab.Rows.Add(NewRow)
            Else
                If obj.CodigoCentroCosto <> "" Then
                    Dim NewRow As DataSet1.RegContabRow
                    NewRow = ds.RegContab.NewRegContabRow
                    NewRow.FechaVoucherrgContab = obj.FechaVoucherRegContabCabe
                    NewRow.CodigoOrigen = obj.CodigoOrigen
                    NewRow.CodigoFile = obj.CodigoFile
                    NewRow.NumeroVoucherRegContab = obj.NumeroVoucherRegContabCabe
                    NewRow.NumeroDocumento = obj.NumeroDocumento
                    NewRow.Cuenta = obj.CodigoCuentaPcge
                    NewRow.nombrecuenta = obj.NombreCuentaPcge
                    NewRow.CentroCosto = obj.CodigoCentroCosto
                    NewRow.GlosaRegContab = obj.GlosaRegContabDeta
                    If obj.DebeHaberRegContabDeta = "Debe" Then
                        NewRow.ImporteDebe = obj.ImporteSRegContabDeta
                        NewRow.ImporteHaber = 0
                    Else
                        NewRow.ImporteDebe = 0
                        NewRow.ImporteHaber = obj.ImporteSRegContabDeta
                    End If
                    NewRow.Saldos = NewRow.ImporteDebe - NewRow.ImporteHaber
                    'AGREGANDO REGISTROS AL DATATABLE
                    'LLENANDO EL REGISTRO
                    'AÑADIR AL DS
                    ds.RegContab.Rows.Add(NewRow)
                End If
            End If


        Next

        CrMovimientoMes1.SetDataSource(ds)
        'Cargamos en nuestro formulario el cr
        Me.crv1.ReportSource = CrMovimientoMes1
        'Dim win As New wImpParaEnvio
        'win.NuevaVentana(ds)
        '/
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
                win.ctrlFoco = Me.TxtCodMes1
                win.NuevaVentana()
            End If
        End If
    End Sub


    Private Sub TxtCodMes1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodMes1.KeyDown
        If Me.TxtCodMes1.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarTabla
                win.tabla = "Mes"
                win.titulo = "Meses"
                win.txt1 = Me.TxtCodMes1
                win.txt2 = Me.TxtDesMes1
                win.ctrlFoco = Me.ComboBox1
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

    Private Sub TxtCodMes1_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodMes1.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.TxtCodMes1 : ope.txt2 = Me.TxtDesMes1
        ope.MostrarCodigoDescripcionDeTabla("Mes", "Meses", e)
    End Sub


#End Region

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

    Private Sub crv1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles crv1.Load

    End Sub

    Private Sub txtCodMes_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodMes.DoubleClick
        Dim win As New WListarTabla
        win.tabla = "Mes"
        win.titulo = "Meses"
        win.txt1 = Me.txtCodMes
        win.txt2 = Me.txtDesMes
        win.ctrlFoco = Me.TxtCodMes1
        win.NuevaVentana()
    End Sub
End Class