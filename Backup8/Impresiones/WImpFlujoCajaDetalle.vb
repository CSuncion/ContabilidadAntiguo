Imports Entidad
Imports Negocio

Public Class WImpFlujoCajaDetalle

    Dim cam As New CamposEntidad
    Dim ds As New DataSet1
    Dim acc As New Accion
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
        Me.txtCodMes.Focus()
    End Sub

    Sub PorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.txtNomEmp.Text = SuperEntidad.xRazonSocial
        Me.txtAno.Text = SuperEntidad.xPeriodoEmpresa.Substring(0, 4)
    End Sub

    Sub Imprimir()

        ds.RegContab.Clear()
        'Llenar Cabecera()
        periodo = CType(Me.CrFlujoCajaDetalle1.Section2.ReportObjects.Item("Periodo"), CrystalDecisions.CrystalReports.Engine.TextObject)
        periodo.Text = "Del mes de " + Me.txtDesMes.Text + " a " + Me.TxtDesMes1.Text + " del " + Me.txtAno.Text

        empresa = CType(Me.CrFlujoCajaDetalle1.Section2.ReportObjects.Item("Empresa"), CrystalDecisions.CrystalReports.Engine.TextObject)
        empresa.Text = Me.txtNomEmp.Text


        '' Traer TODOS los detalle del registro contable
        Dim iRegConDetRN As New RegContabDetaRN
        Dim iRegConDetEN As New SuperEntidad
        iRegConDetEN.DatoFiltro1 = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        iRegConDetEN.DatoFiltro2 = Me.txtAno.Text.Trim + Me.TxtCodMes1.Text.Trim
        iRegConDetEN.DatoFiltro3 = Me.TxtCodFluDes.Text.Trim
        iRegConDetEN.DatoFiltro4 = Me.TxtCodFluHas.Text.Trim
        iRegConDetEN.CampoOrden = cam.CodFluCaj
        Dim ilisRes As New List(Of SuperEntidad)
        ilisRes = iRegConDetRN.ListarRegistrosContablesDetalleXFiltroFlujoCaja(iRegConDetEN)
        For Each obj As SuperEntidad In ilisRes

            Dim NewRow As DataSet1.RegContabRow
            NewRow = ds.RegContab.NewRegContabRow
            NewRow.CodigoOrigen = obj.CodigoOrigen
            NewRow.CodigoFile = obj.CodigoFile
            NewRow.NumeroVoucherRegContab = obj.NumeroVoucherRegContabCabe
            NewRow.FechaVoucherrgContab = obj.FechaVoucherRegContabCabe
            NewRow.Cuenta = obj.CodigoCuentaPcge
            NewRow.GlosaRegContab = obj.GlosaRegContabDeta

            'SEGUN DEBE HABER
            If obj.DebeHaberRegContabDeta = "Debe" Then
                NewRow.ImporteDebe = obj.ImporteSRegContabDeta
                NewRow.ImporteHaber = 0
            Else
                NewRow.ImporteDebe = 0
                NewRow.ImporteHaber = obj.ImporteSRegContabDeta
            End If
            NewRow.CodigoFlujoCaja = obj.CodigoFlujoCaja
            NewRow.NombreFlujoCaja = obj.NombreFlujoCaja
            'AGREGANDO REGISTROS AL DATATABLE
            'LLENANDO EL REGISTRO
            'AÑADIR AL DS
            ds.RegContab.Rows.Add(NewRow)

        Next

        Me.CrFlujoCajaDetalle1.SetDataSource(ds)
        'Cargamos en nuestro formulario el cr
        Me.crv1.ReportSource = Me.CrFlujoCajaDetalle1
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
                win.ctrlFoco = Me.TxtCodMes1
                win.NuevaVentana()
            End If
        End If
    End Sub
    Private Sub txtCodMes1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodMes1.KeyDown
        If Me.txtCodMes.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarTabla
                win.tabla = "Mes"
                win.titulo = "Meses"
                win.txt1 = Me.TxtCodMes1
                win.txt2 = Me.TxtDesMes1
                win.ctrlFoco = Me.TxtCodFluDes
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

    Private Sub txtCodMes1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodMes1.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.TxtCodMes1 : ope.txt2 = Me.TxtDesMes1
        ope.MostrarCodigoDescripcionDeTabla("Mes", "Meses", e)
    End Sub

    Public Function EsFlujoCajaDesdeValido() As Boolean
        Dim iFluCRN As New FlujoCajaRN
        Dim iFluCEN As New SuperEntidad
        iFluCEN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iFluCEN.CodigoFlujoCaja = Me.TxtCodFluDes.Text.Trim
        iFluCEN = iFluCRN.EsFlujoCajaValido(iFluCEN)
        If iFluCEN.EsVerdad = False Then
            MsgBox(iFluCEN.Mensaje, MsgBoxStyle.Exclamation, "FlujoCaja")
            Me.TxtCodFluDes.Focus()
        End If
        Me.MostarFlujoCajaDesde(iFluCEN)
        Return iFluCEN.EsVerdad
    End Function

    Sub MostarFlujoCajaDesde(ByRef pAR As SuperEntidad)
        Me.TxtCodFluDes.Text = pAR.CodigoFlujoCaja
        Me.TxtNomFluDes.Text = pAR.NombreFlujoCaja
    End Sub


    Public Function EsFlujoCajaHastaValido() As Boolean
        Dim iFluCRN As New FlujoCajaRN
        Dim iFluCEN As New SuperEntidad
        iFluCEN.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iFluCEN.CodigoFlujoCaja = Me.TxtCodFluHas.Text.Trim
        iFluCEN = iFluCRN.EsFlujoCajaValido(iFluCEN)
        If iFluCEN.EsVerdad = False Then
            MsgBox(iFluCEN.Mensaje, MsgBoxStyle.Exclamation, "FlujoCaja")
            Me.TxtCodFluHas.Focus()
        End If
        Me.MostarFlujoCajaHasta(iFluCEN)
        Return iFluCEN.EsVerdad
    End Function

    Sub MostarFlujoCajaHasta(ByRef pAR As SuperEntidad)
        Me.TxtCodFluHas.Text = pAR.CodigoFlujoCaja
        Me.TxtNomFluHas.Text = pAR.NombreFlujoCaja
    End Sub

#End Region







    Private Sub TxtCodFluDes_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodFluDes.Validating
        Me.EsFlujoCajaDesdeValido()
    End Sub

    Private Sub TxtCodFluDes_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodFluDes.KeyDown
        If e.KeyCode = Keys.F1 Then
            Dim win As New WListarFlujoCaja
            win.titulo = "Flujos Activos"
            win.tabla = "FlujoCaja"
            win.txt1 = Me.TxtCodFluDes
            win.txt2 = Me.TxtNomFluDes
            win.ctrlFoco = Me.TxtCodFluHas
            win.NuevaVentana()
        End If
    End Sub

    Private Sub TxtCodFluHas_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodFluHas.Validating
        Me.EsFlujoCajaHastaValido()
    End Sub

    Private Sub TxtCodFluHas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodFluHas.KeyDown
        If e.KeyCode = Keys.F1 Then
            Dim win As New WListarFlujoCaja
            win.titulo = "Flujos Activos"
            win.tabla = "FlujoCaja"
            win.txt1 = Me.TxtCodFluHas
            win.txt2 = Me.TxtNomFluHas
            win.ctrlFoco = Me.btnEjecutar
            win.NuevaVentana()
        End If
    End Sub
End Class