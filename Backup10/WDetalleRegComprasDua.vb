Imports Entidad
Imports Negocio

Public Class WDetalleRegComprasDua
#Region "Propietarios"
    Public wRegCom As New WEditarRegistroCompraDua
#End Region

    Public acc As New Accion
    Public lista As New List(Of SuperEntidad)
    Public ent, paren As New SuperEntidad
    Public concepto As String = ""
    Public tab As New TablaRN
    'Public par As New ParametroRN
    Public cam As New CamposEntidad
    Public titulo As String

#Region "operaciones"

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
        ' Me.txtCodPro.ReadOnly = True
        '/por defecto
        'paren = par.buscarParametroExis(paren)
        Me.Show()
    End Sub

    Sub ParaNotaCredito()
        Dim codfil As String = Me.wRegCom.txtCodFil.Text.Trim
        If codfil = "407" Then
            Me.rbtDebe.Enabled = False
            Me.rbtHaber.Checked = True
            Me.rbtHaber.Enabled = True
        End If
    End Sub
    Sub NuevaVentana()
        Me.InicializaVentana()
        Me.Text = "Agregar Item"
        acc.LimpiarControles()
        Me.txtCodCuen.Focus()
        acc.Nuevo()
        Me.ParaNotaCredito()
    End Sub

    Sub ModificarVentana()
        Me.InicializaVentana()
        Me.Text = "Modificar Item"
        Me.DeGrillaAControles()
        Me.txtCencto.Focus()

        acc.Modificar()
        Me.ParaNotaCredito()
    End Sub

    Sub EliminaVentana()
        'Me.Show()
        Me.InicializaVentana()
        Me.Text = "Eliminar Item"
        Me.DeGrillaAControles()

        acc.Eliminar()
        Me.ParaNotaCredito()
    End Sub

    Sub DeGrillaAControles()


        Dim indFil As Integer = Me.wRegCom.dgvRegCom.CurrentRow.Index
        If indFil = Me.wRegCom.dgvRegCom.Rows.Count - 1 Then
            Me.Close()
            Exit Sub

        Else

            Me.txtCodCuen.Text = Me.wRegCom.dgvRegCom.Item(0, indFil).Value.ToString
            Me.txtNomCue.Text = Me.wRegCom.dgvRegCom.Item(1, indFil).Value.ToString
            Me.txtCencto.Text = Me.wRegCom.dgvRegCom.Item(2, indFil).Value.ToString
            Me.txtNomCto.Text = Me.wRegCom.dgvRegCom.Item(3, indFil).Value.ToString
            'haber debe
            Dim str As String = Me.wRegCom.dgvRegCom.Item(4, indFil).Value.ToString
            If str = "Haber" Then
                Me.rbtHaber.Checked = True
            Else
                Me.rbtDebe.Checked = True
            End If
            Me.txtImpSol.Text = Me.wRegCom.dgvRegCom.Item(5, indFil).Value.ToString
            Me.txtImpDol.Text = Me.wRegCom.dgvRegCom.Item(6, indFil).Value.ToString
            Me.txtGlosa.Text = Me.wRegCom.dgvRegCom.Item(7, indFil).Value.ToString
            'Me.txtCta42.Text = Me.wRegCom.dgvRegCom.Item(8, indFil).Value.ToString
            'Me.txtNomcta42.Text = Me.wRegCom.dgvRegCom.Item(9, indFil).Value.ToString

        End If

    End Sub


    Sub DeControlesAGrilla()
        Dim indiceFila As Integer

        Select Case Me.Text

            Case "Agregar Item"

                ''/preguntar si el item ya esta agregado en la grilla detalle
                'If Me.wRegCom.dgvRegCom.Rows.Count = 1 Then
                '    'nada
                'Else
                '    'para evitar repetir dos items con un mismo proyecto
                '    For n As Integer = 0 To Me.wRegCom.dgvRegCom.Rows.Count - 2
                '        If Me.txtCodProy.Text.Trim = Me.wRegCom.dgvRegCom.Item(2, n).Value.ToString().Trim Then
                '            MsgBox("El proyecto ya existe en el detalle", MsgBoxStyle.Information)
                '            Me.txtCodProy.Text = ""
                '            Me.txtNomProy.Text = ""
                '            Me.txtCodProy.Focus()
                '            Exit Sub
                '        End If
                '    Next

                'End If


                Me.wRegCom.dgvRegCom.Rows.Add()

                indiceFila = Me.wRegCom.dgvRegCom.Rows.Count - 2

            Case "Modificar Item"
                indiceFila = Me.wRegCom.dgvRegCom.CurrentRow.Index

            Case "Eliminar Item"
                Dim rpta As Integer = MsgBox("Deseas eliminar el item", MsgBoxStyle.YesNo)
                If rpta = MsgBoxResult.Yes Then
                    MsgBox("Item eliminado")
                    indiceFila = Me.wRegCom.dgvRegCom.CurrentRow.Index
                    Me.wRegCom.dgvRegCom.Rows.RemoveAt(indiceFila)
                    Me.Close()
                    Exit Sub
                Else
                    Me.Close()
                    Exit Sub
                End If


        End Select

        Me.wRegCom.dgvRegCom.Rows(indiceFila).Cells(0).Value = Me.txtCodCuen.Text.Trim
        Me.wRegCom.dgvRegCom.Rows(indiceFila).Cells(1).Value = Me.txtNomCue.Text.Trim
        Me.wRegCom.dgvRegCom.Rows(indiceFila).Cells(2).Value = Me.txtCencto.Text.Trim
        Me.wRegCom.dgvRegCom.Rows(indiceFila).Cells(3).Value = Me.txtNomCto.Text.Trim
        Dim str As String = Rbt.radioActivo(Me.gbDebeHaber).Text
        Me.wRegCom.dgvRegCom.Rows(indiceFila).Cells(4).Value = str
        Me.wRegCom.dgvRegCom.Rows(indiceFila).Cells(5).Value = Me.txtImpSol.Text.Trim
        Me.wRegCom.dgvRegCom.Rows(indiceFila).Cells(6).Value = Me.txtImpDol.Text.Trim
        Me.wRegCom.dgvRegCom.Rows(indiceFila).Cells(7).Value = Me.txtGlosa.Text.Trim
        'Me.wRegCom.dgvRegCom.Rows(indiceFila).Cells(8).Value = Me.txtCuenta.Text.Trim
        'Me.wRegCom.dgvRegCom.Rows(indiceFila).Cells(9).Value = Me.txtNomcta42.Text.Trim
    End Sub

#End Region

    Private Sub WEditarPptoInterno_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If acc.CamposObligatorios = False Then
            Exit Sub
        Else
            Me.DeControlesAGrilla()
            Me.wRegCom.ImportesDebeHaber()
            If Me.Text = "Agregar Item" Then
                'If Me.txtCodProy.Text.Trim = "" Then
                '    Exit Sub
                'Else
                acc.LimpiarControles()
                Me.txtCodCuen.Focus()
                'End If
            End If
            If Me.Text = "Modificar Item" Then
                Me.Close()
            End If

        End If

    End Sub


#Region "Mostrar Formulario lista"

    Private Sub txtCodCuen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodCuen.KeyDown
        If Me.Text = "Agregar Item" Or Me.Text = "Modificar Item" Then
            If Me.txtCodCuen.ReadOnly = False Then
                If e.KeyCode = Keys.F1 Then
                    Dim win As New WListarPlanCuentaGe
                    win.tabla = "CuentasAnaliticas"    ''va la condicion del case
                    win.titulo = "Cuentas"
                    win.txt1 = Me.txtCodCuen
                    win.txt2 = Me.txtNomCue
                    win.ctrlFoco = Me.txtCencto
                    win.NuevaVentana()
                End If
            End If
        End If
    End Sub

    Private Sub txtCencto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCencto.KeyDown
        If Me.Text = "Agregar Item" Or Me.Text = "Modificar Item" Then
            If Me.txtCencto.ReadOnly = False Then
                If e.KeyCode = Keys.F1 Then
                    Dim win As New WListarTabla
                    win.tabla = "CentroCosto"
                    win.titulo = "Centro Costo"
                    win.txt1 = Me.txtCencto
                    win.txt2 = Me.txtNomCto
                    win.ctrlFoco = Me.gbDebeHaber
                    win.NuevaVentana()
                End If
            End If
        End If
    End Sub
#End Region

#Region "Buscar Por Codigo"

    Private Sub txtCodCue_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodCuen.Validating
        If Me.Text = "Agregar Item" Or Me.Text = "Modificar Item" Then
            Dim ope As New OperaWin : ope.txt1 = Me.txtCodCuen : ope.txt2 = Me.txtNomCue
            ope.Condicion = "CuentasAnaliticas"
            ope.MostrarCodigoDescripcionDePlancuentas("CuentasAnaliticas", e)
        End If
    End Sub

    Private Sub txtCenCto_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCencto.Validating
        If Me.Text = "Agregar Item" Or Me.Text = "Modificar Item" Then
            Dim cod As String = Me.txtCencto.Text.Trim
            If cod <> String.Empty Then
                Dim obj As New SuperEntidad
                obj.DatoCondicion1 = "Cto"
                obj.DatoCondicion2 = cod
                obj = tab.buscarItemTablaExisPorTipoTablaYCodigo(obj)
                If obj.CodigoItemTabla = String.Empty Then
                    MsgBox("El Centro Costo", MsgBoxStyle.Exclamation)
                    Me.txtCencto.Text = String.Empty
                    Me.txtNomCto.Text = String.Empty
                    Me.txtCencto.Focus()
                Else
                    Me.txtCencto.Text = obj.CodigoItemTabla
                    Me.txtNomCto.Text = obj.NombreItemTabla
                End If
            Else
                Me.txtCencto.Text = String.Empty
                Me.txtNomCto.Text = String.Empty
            End If
        End If
    End Sub
#End Region

#Region "Calculos"

    Function ImporteSegunMoneda() As Decimal

        Dim mon As String = Rbt.radioActivo(Me.wRegCom.gbMoneda).Text
        Dim tcdol As Decimal = CType(Me.wRegCom.txtTipCam.Text, Decimal)
        Dim tceur As Decimal = CType(Me.wRegCom.TxtTipCam1.Text, Decimal)
        Dim impsol As Decimal = CType(Me.txtImpSol.Text, Decimal)
        Dim imp As Decimal = 0
        Select Case mon
            Case "S/.", "US$" : imp = impsol / tcdol
            Case "EUR" : imp = impsol / tceur
        End Select
        Return imp

    End Function

    Private Sub txtImpSol_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtImpSol.Validated
        Me.txtImpDol.Text = Varios.numeroConDosDecimal(Me.ImporteSegunMoneda.ToString)
    End Sub

#End Region
End Class