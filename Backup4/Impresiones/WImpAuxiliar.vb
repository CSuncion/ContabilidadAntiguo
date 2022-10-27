Imports Entidad
Imports Negocio

Public Class WImpAuxiliar
#Region "Propietarios"
    Public wAux As New WAuxiliar
#End Region

    Public ent, entCont, paren As New SuperEntidad
    Public lista, listarc As New List(Of SuperEntidad)
    Public aux As New AuxiliarRN
    Public par As New ParametroRN
    Dim cam As New CamposEntidad
    Dim ds As New DataSet1
    Dim tb As New DataTable
    Dim cr As New crRptAux
    Dim acc As New Accion
    Dim ano, mes, empresa, periodo, ruc, cuenta1, cuenta2 As CrystalDecisions.CrystalReports.Engine.TextObject


    Sub InicializaVentana()
        '/Para los eventos de controles
        acc.listaCtrls = Me.ListaControles
        acc.PasaFoco()
        acc.FomatoDato()
        acc.PasarCursor()
        acc.Teclazo()
        acc.Valida()
        Me.Show()
        Me.gbAuxiliar.Focus()
        'acc.Nuevo()
    End Sub

    Sub Imprimir()

        ds.Auxiliar.Clear()
        'Llenar Cabecera()
        'periodo = CType(Me.cr.Section2.ReportObjects.Item("Periodo"), CrystalDecisions.CrystalReports.Engine.TextObject)
        'periodo.Text = Me.txtAno.Text + Me.txtCodMes.Text

        'ruc = CType(Me.cr.Section2.ReportObjects.Item("Ruc"), CrystalDecisions.CrystalReports.Engine.TextObject)
        'ruc.Text = SuperEntidad.xRucEmpresa

        empresa = CType(Me.cr.Section2.ReportObjects.Item("Empresa"), CrystalDecisions.CrystalReports.Engine.TextObject)
        empresa.Text = SuperEntidad.xRazonSocial


        '' Traer TODos loss auxiliares 

        Dim obaux As New SuperEntidad
        Dim tipoa As String = ""
        Dim orden As String = ""

        'obPl.CampoOrden = cam.CodAux

        Select Case Rbt.radioActivo(Me.gbAuxiliar).Text.Trim
            Case "Personal"
                tipoa = "1"
            Case "Cliente/Proveedor"
                tipoa = "2"
            Case "Cliente"
                tipoa = "3"
            Case "Proveedor"
                tipoa = "4"
            Case "Todos"
                tipoa = "5"
        End Select

        Select Case Rbt.radioActivo(Me.GbOrden).Text.Trim
            Case "Codigo"
                orden = cam.CodAux
            Case "Nombre"
                orden = cam.DesAux
        End Select

        obaux.TipoAuxiliar = tipoa
        obaux.CampoOrden = orden

        If tipoa = "5" Then
            lista = aux.obtenerAuxiliaresTodos(obaux)
        Else
            lista = aux.obtenerAuxiliaresExisActPorTipoAux(obaux)
        End If

        For Each obj As SuperEntidad In lista

            Dim NewRow As DataSet1.AuxiliarRow
            NewRow = ds.Auxiliar.NewAuxiliarRow

            NewRow.CodigoAuxiliar = obj.CodigoAuxiliar
            NewRow.DescripcionAuxiliar = obj.DescripcionAuxiliar
            NewRow.DireccionAuxiliar = obj.DireccionAuxiliar
            NewRow.CorreoAuxiliar = obj.CorreoAuxiliar
            NewRow.TelefonoAuxiliar = obj.TelefonoAuxiliar
            NewRow.CelularAuxiliar = obj.CelularAuxiliar
            NewRow.ReferenciaAuxiliar = obj.ReferenciaAuxiliar
            NewRow.TipoAuxiliar = obj.TipoAuxiliar

            'AGREGANDO REGISTROS AL DATATABLE
            'LLENANDO EL REGISTRO
            'AÑADIR AL DS
            ds.Auxiliar.Rows.Add(NewRow)

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
        Dim rpta As Integer = MsgBox("Deseas cancelar la operacion", MsgBoxStyle.YesNo, "Auxiliares")
        If rpta = MsgBoxResult.Yes Then
            Me.Close()
        Else
            Exit Sub
        End If
    End Sub

End Class