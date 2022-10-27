Imports Entidad
Imports Negocio

Public Class WEditarDatosDetraccion

#Region "Propietarios"
    Public wRc As New WRegistroCompra
#End Region

    Public ent, entD, parEn, ticEn As New SuperEntidad
    Public lista, listaD As New List(Of SuperEntidad)
    Public rc As New RegContabCabeRN
    Public par As New ParametroRN
    Public cam As New CamposEntidad
    Public tab As New TablaRN
    Public emp As New EmpresaRN
    Public acc As New Accion
    Public PeriodoActual As String
    Public operacion As Integer  '0=agregar , 1=modificar , 2=eliminar , 3=visualizar , 4=Manual ,5=copia'


#Region "Metodos"

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
        '/Traer objeto parametro
        parEn = par.buscarParametroExis(parEn)
        Me.Show()
    End Sub

    Sub PorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.txtNomEmp.Text = SuperEntidad.xRazonSocial
        Me.TxtPeri.Text = SuperEntidad.xPeriodoEmpresa
        PeriodoActual = SuperEntidad.xPeriodoEmpresa
        Me.TxtPorIgv.Text = parEn.IgvPar.ToString
        Me.txtCodOri.Text = "4"
        Me.txtNomOri.Text = "Compras"
    End Sub

    Sub ventanadatosdetraccion(ByRef codigo As String)
        '//
        Me.InicializaVentana()
        'titulo de la ventana
        Me.Text = "Modificar Registro Compra"
        'mostrar el registro en pantalla
        Me.obtenerRegCompraEnPantalla(codigo)
        'poner el cursor de inicio
        '  Txt.cursorAlUltimo(Me.gbMovi.Select)
        Me.gbMovi.Focus()
        'los controles que deben estar activos
        acc.Modificar()
        Me.HabilitarControlesSegunDetraccion()
        Me.HabilitarControlesSegunFile407()
        '\\
    End Sub

    Sub obtenerRegCompraEnPantalla(ByRef codigo As String)
        '//
        ent.ClaveRegContabCabe = codigo
        ent = rc.buscarRegContabExisPorClave(ent)
        'preguntar si ent tiene el registro
        If ent.ClaveRegContabCabe = "" Then
            Exit Sub
        Else
            '/Pasar Datos a los controles
            Me.TxtCodEmp.Text = ent.CodigoEmpresa
            Me.txtNomEmp.Text = ent.RazonSocialEmpresa
            Me.TxtPeri.Text = ent.PeriodoRegContabCabe
            Me.TxtPorIgv.Text = Varios.numeroConDosDecimal(ent.IgvPar.ToString)
            Me.txtCodOri.Text = ent.CodigoOrigen
            Me.txtNomOri.Text = ent.NombreOrigen
            Me.txtCodFil.Text = ent.CodigoFile
            Me.txtNomFil.Text = ent.NombreFile
            Me.txtNumVau.Text = ent.NumeroVoucherRegContabCabe
            Me.txtDia.Text = ent.DiaVoucherRegContabCabe
            Me.txtFecVau.Text = ent.FechaVoucherRegContabCabe.Date.ToShortDateString
            Gb.pasarDato(Me.gbMovi, ent.DetraccionRegContabCabe)
            Me.txtNumPape.Text = ent.NumeroPapeletaRegContabCabe
            Me.dtpFecDetra.Text = ent.FechaDetraccionRegContabCabe
        
        End If
        '\\
    End Sub

    Sub Aceptar()
        '//
        If Me.operacion = 1 Or Me.operacion = 2 Then
            'Volver a traer el registro 
            ent.DatoCondicion1 = ent.ClaveRegContabCabe
            ent = rc.buscarRegContabExisPorClave(ent)
        End If

        ent.PeriodoRegContabCabe = Me.TxtPeri.Text
        ent.CodigoEmpresa = Me.TxtCodEmp.Text
        ent.CodigoOrigen = Me.txtCodOri.Text
        ent.CodigoFile = Me.txtCodFil.Text
        ent.NumeroVoucherRegContabCabe = Me.txtNumVau.Text
        ent.DiaVoucherRegContabCabe = Me.txtDia.Text
        ent.FechaVoucherRegContabCabe = CType(Me.txtFecVau.Text, Date)

        ent.DetraccionRegContabCabe = Rbt.radioActivo(Me.gbMovi).Text
        ent.NumeroPapeletaRegContabCabe = Me.txtNumPape.Text.Trim
        'validar fecha detraccion
        If Me.dtpFecDetra.Enabled = True Then
            ent.FechaDetraccionRegContabCabe = Me.dtpFecDetra.Text
        Else
            ent.FechaDetraccionRegContabCabe = ""
        End If

        '/Se graba o0 se modifica?

        'modificar cabecera
        rc.modificarRegContab(ent)
        MsgBox("Registro Compra modificado correctamente", MsgBoxStyle.Information)
        Me.Close()

        '/Actualizar y buscar el registro grabado
        Me.wRc.ActualizarVentana()
        ent.ClaveRegContabCabe = ent.CodigoEmpresa + ent.PeriodoRegContabCabe + ent.CodigoOrigen + ent.CodigoFile + ent.NumeroVoucherRegContabCabe
        Dgv.obtenerCursorActual(Me.wRc.DgvRcom, ent.ClaveRegContabCabe, Me.wRc.lista)
        '\\
    End Sub


#End Region


    Private Sub WEditarPptoInterno_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Owner.Enabled = True
    End Sub

    Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        '    If ent.DetraccionRegContabCabe = "Si" Then
        'If acc.CamposObligatorios = False Then
        '    Exit Sub
        'Else
        '    Me.Aceptar()
        'End If
        '  End If
        Me.Aceptar()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
        
    End Sub

#Region "Mostrar formulario lista"
    Private Sub txtCodFil_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodFil.KeyDown
        If Me.txtCodFil.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListaFiles
                win.titulo = "Files"
                win.CondicionLista = "ListarFilesXOrigen"
                win.ent.CodigoFile = "4"
                win.txt1 = Me.txtCodFil
                win.txt2 = Me.txtNomFil
                win.ctrlFoco = Me.txtDia
                win.NuevaVentana()
            End If
        End If

    End Sub

#End Region

#Region "Buscar por codigo"
    Private Sub txtCodFil_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodFil.Validating
        If Me.operacion = 0 Or Me.operacion = 4 Or Me.operacion = 5 Then
            If Me.txtCodFil.Text.Trim <> "" Then
                Dim codOri As String = Me.txtCodFil.Text.Trim.Substring(0, 1)
                If codOri = "4" Then
                    Dim ope As New OperaWin : ope.txt1 = Me.txtCodFil : ope.txt2 = Me.txtNomFil
                    ope.MostrarCodigoDescripcionDeFile("Files", e)
                    Me.HabilitarControlesSegunFile407()
                Else
                    MsgBox("El Codigo File no existe", MsgBoxStyle.Information)

                    Me.txtCodFil.Text = String.Empty
                    Me.txtNomFil.Text = String.Empty

                    Me.txtCodFil.Focus()
                End If
            End If
        End If

    End Sub

#End Region

#Region "Calculos"

    Private Sub txtDia_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDia.Validated
        If Me.TxtPeri.Text <> "" Then
            If Me.txtDia.Text.Trim <> "" Then
                'Dim wmes As String
                Dim periodo As String = Me.TxtPeri.Text.Trim
                Dim dia As String = Me.txtDia.Text.Trim
                If Varios.LimiteMinMaxDeValores(dia, 1, 31) = True Then
                    dia = Varios.FormatoDia(dia)
                    Me.txtDia.Text = dia


                    Me.txtFecVau.Text = dia + "/" + periodo.Substring(4, 2) + "/" + periodo.Substring(0, 4)

                    '' Es Fecha Valida
                    If Varios.ValidaDia(Me.txtFecVau.Text) = False Then
                        Me.txtFecVau.Text = String.Empty
                        Me.txtDia.Focus()
                    End If
                Else
                    MsgBox("El dia debe estar entre en 1 y 31", MsgBoxStyle.Information)
                    Me.txtDia.Focus()
                End If
            End If
        End If
    End Sub

    Sub HabilitarControlesSegunDetraccion()
        '/
        Dim detra As String = Rbt.radioActivo(Me.gbMovi).Text
        'Habilitar los campos calculados segun la detraccion
        Select Case detra
            Case "Si"
                Me.txtNumPape.Enabled = True
                Me.dtpFecDetra.Enabled = True
            Case "No"
                Me.txtNumPape.Enabled = False
                Me.txtNumPape.Text = ""
                Me.dtpFecDetra.Enabled = False
        End Select
        '/
    End Sub

    Sub HabilitarControlesSegunFile407()
        '/
        '/
    End Sub


#End Region


    Private Sub txtPeri_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPeri.Validated
        If Me.operacion = 4 Then
            Dim p As String = Me.TxtPeri.Text.Trim
            If p <> "" Then
                If p.Length <> 6 Then
                    MsgBox("No es un periodo valido", MsgBoxStyle.Information, "")
                    Me.TxtPeri.Text = ""
                    Me.TxtPeri.Focus()
                Else
                    If p >= PeriodoActual Then
                        MsgBox("Solo se puede digitar como maximo el periodo anterior de hoy", MsgBoxStyle.Information, "")
                        Me.TxtPeri.Text = ""
                        Me.TxtPeri.Focus()
                    Else
                        Dim dia As String = Me.txtDia.Text.Trim
                        If dia <> String.Empty Then
                            dia = Varios.FormatoDia(dia)
                            Me.txtFecVau.Text = dia + "/" + Me.TxtPeri.Text.Substring(4, 2) + "/" + Me.TxtPeri.Text.Substring(0, 4)
                            '' Es Fecha Valida
                            If Varios.ValidaDia(Me.txtFecVau.Text) = False Then
                                Me.txtFecVau.Text = String.Empty
                                Me.TxtPeri.Focus()
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub CambiarDetraccion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtMoSi.CheckedChanged, rbtMoNo.CheckedChanged
        If Me.Text = "Agregar Registro Compra" Or Me.Text = "Modificar Registro Compra" Or Me.Text = "Agregar Manual Registro Compra" Or Me.operacion = 5 Then
            Me.HabilitarControlesSegunDetraccion()
        End If
    End Sub
End Class