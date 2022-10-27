Imports CrystalDecisions.CrystalReports.Engine
Imports Entidad
Imports Negocio

Public Class WimpInvBalAcumuladoRanCue

    Public ent, entCont, paren As New SuperEntidad
    Public lista, listarsc As New List(Of SuperEntidad)
    Public sc As New SaldoContableRN
    Public par As New ParametroRN
    Dim cam As New CamposEntidad
    Dim ds As New DataSet1
    Dim cr As New CrInvBalAcumulados
    Dim acc As New Accion
    Dim text11, ano, mes, digito, empresa As CrystalDecisions.CrystalReports.Engine.TextObject


    Sub InicializaVentana()
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

    End Sub

    Sub PorDefecto()
        Me.TxtCodEmp.Text = SuperEntidad.xCodigoEmpresa
        Me.txtNomEmp.Text = SuperEntidad.xRazonSocial
        Me.txtAno.Text = SuperEntidad.xPeriodoEmpresa.Substring(0, 4)
    End Sub

    'Sub Imprimir()

    '    ds.Balances.Clear()
    '    'Llenar Cabecera()
    '    empresa = CType(Me.cr.Section2.ReportObjects.Item("Empresa"), CrystalDecisions.CrystalReports.Engine.TextObject)
    '    empresa.Text = Me.txtNomEmp.Text.Trim

    '    ano = CType(Me.cr.Section2.ReportObjects.Item("Periodo"), CrystalDecisions.CrystalReports.Engine.TextObject)
    '    ano.Text = Me.txtAno.Text + Me.txtCodMes.Text

    '    mes = CType(Me.cr.Section2.ReportObjects.Item("Ruc"), CrystalDecisions.CrystalReports.Engine.TextObject)
    '    mes.Text = SuperEntidad.xRucEmpresa

    '    'Traer saldos por ano 
    '    ent.PeriodoRegContabCabe = Me.txtAno.Text.Trim
    '    ent.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
    '    ent.CampoOrden = cam.CodCtaPcge
    '    listarsc = sc.obtenerSaldoContableXPeriodo(ent)

    '    'recorrer los objetos saldos
    '    For Each obj As SuperEntidad In listarsc

    '        If obj.CodigoCuentaPcge >= Me.TxtCodCta.Text And obj.CodigoCuentaPcge <= Me.txtCodCue2.Text + "9999999" Then

    '            Dim Saldo As Decimal = 0

    '            'creando un registro para el objeto saldo
    '            Dim NewRow As DataSet1.BalancesRow
    '            NewRow = ds.Balances.NewBalancesRow

    '            'llenando datos al registro
    '            NewRow.Codigo = obj.CodigoCuentaPcge
    '            NewRow.Cuenta = obj.NombreCuentaPcge

    '            Select Case Me.txtCodMes.Text.Trim

    '                Case "00"
    '                    NewRow.MayorDebe = 0
    '                    NewRow.MayorHaber = 0
    '                    Saldo = NewRow.MayorDebe - NewRow.MayorHaber
    '                    If Saldo > 0 Then
    '                        NewRow.MayorDebe = Saldo
    '                        NewRow.MayorHaber = 0
    '                    Else
    '                        NewRow.MayorDebe = 0
    '                        NewRow.MayorHaber = Math.Abs(Saldo)
    '                    End If
    '                    NewRow.SaldoDeudor = obj.DebeS00SaldoContable
    '                    NewRow.SaldoAcreedor = obj.HabeS00SaldoContable
    '                    NewRow.InvtarioActivo = obj.DebeS00SaldoContable
    '                    NewRow.InvtarioPasivo = obj.HabeS00SaldoContable
    '                    Saldo = (NewRow.InvtarioActivo) - (NewRow.InvtarioPasivo)

    '                    If Saldo > 0 Then
    '                        NewRow.GestionDebe = Saldo
    '                        NewRow.GestionHaber = 0
    '                    Else
    '                        NewRow.GestionDebe = 0
    '                        NewRow.GestionHaber = Math.Abs(Saldo)
    '                    End If

    '                Case "01"
    '                    NewRow.MayorDebe = obj.DebeS00SaldoContable
    '                    NewRow.MayorHaber = obj.HabeS00SaldoContable
    '                    Saldo = NewRow.MayorDebe - NewRow.MayorHaber
    '                    If Saldo > 0 Then
    '                        NewRow.MayorDebe = Saldo
    '                        NewRow.MayorHaber = 0
    '                    Else
    '                        NewRow.MayorDebe = 0
    '                        NewRow.MayorHaber = Math.Abs(Saldo)
    '                    End If
    '                    NewRow.SaldoDeudor = obj.DebeS01SaldoContable
    '                    NewRow.SaldoAcreedor = obj.HabeS01SaldoContable
    '                    NewRow.InvtarioActivo = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable
    '                    NewRow.InvtarioPasivo = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable
    '                    Saldo = (NewRow.InvtarioActivo) - (NewRow.InvtarioPasivo)

    '                    If Saldo > 0 Then
    '                        NewRow.GestionDebe = Saldo
    '                        NewRow.GestionHaber = 0
    '                    Else
    '                        NewRow.GestionDebe = 0
    '                        NewRow.GestionHaber = Math.Abs(Saldo)
    '                    End If

    '                Case "02"
    '                    NewRow.MayorDebe = obj.DebeS00SaldoContable
    '                    NewRow.MayorHaber = obj.HabeS00SaldoContable
    '                    Saldo = NewRow.MayorDebe - NewRow.MayorHaber
    '                    If Saldo > 0 Then
    '                        NewRow.MayorDebe = Saldo
    '                        NewRow.MayorHaber = 0
    '                    Else
    '                        NewRow.MayorDebe = 0
    '                        NewRow.MayorHaber = Math.Abs(Saldo)
    '                    End If
    '                    NewRow.SaldoDeudor = obj.DebeS02SaldoContable
    '                    NewRow.SaldoAcreedor = obj.HabeS02SaldoContable
    '                    NewRow.InvtarioActivo = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable
    '                    NewRow.InvtarioPasivo = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable
    '                    Saldo = (NewRow.InvtarioActivo) - (NewRow.InvtarioPasivo)

    '                    If Saldo > 0 Then
    '                        NewRow.GestionDebe = Saldo
    '                        NewRow.GestionHaber = 0
    '                    Else
    '                        NewRow.GestionDebe = 0
    '                        NewRow.GestionHaber = Math.Abs(Saldo)
    '                    End If

    '                Case "03"
    '                    NewRow.MayorDebe = obj.DebeS00SaldoContable
    '                    NewRow.MayorHaber = obj.HabeS00SaldoContable
    '                    Saldo = NewRow.MayorDebe - NewRow.MayorHaber
    '                    If Saldo > 0 Then
    '                        NewRow.MayorDebe = Saldo
    '                        NewRow.MayorHaber = 0
    '                    Else
    '                        NewRow.MayorDebe = 0
    '                        NewRow.MayorHaber = Math.Abs(Saldo)
    '                    End If
    '                    NewRow.SaldoDeudor = obj.DebeS03SaldoContable
    '                    NewRow.SaldoAcreedor = obj.HabeS03SaldoContable
    '                    NewRow.InvtarioActivo = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable
    '                    NewRow.InvtarioPasivo = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable
    '                    Saldo = (NewRow.InvtarioActivo) - (NewRow.InvtarioPasivo)

    '                    If Saldo > 0 Then
    '                        NewRow.GestionDebe = Saldo
    '                        NewRow.GestionHaber = 0
    '                    Else
    '                        NewRow.GestionDebe = 0
    '                        NewRow.GestionHaber = Math.Abs(Saldo)
    '                    End If

    '                Case "04"
    '                    NewRow.MayorDebe = obj.DebeS00SaldoContable
    '                    NewRow.MayorHaber = obj.HabeS00SaldoContable
    '                    Saldo = NewRow.MayorDebe - NewRow.MayorHaber
    '                    If Saldo > 0 Then
    '                        NewRow.MayorDebe = Saldo
    '                        NewRow.MayorHaber = 0
    '                    Else
    '                        NewRow.MayorDebe = 0
    '                        NewRow.MayorHaber = Math.Abs(Saldo)
    '                    End If
    '                    NewRow.SaldoDeudor = obj.DebeS04SaldoContable
    '                    NewRow.SaldoAcreedor = obj.HabeS04SaldoContable
    '                    NewRow.InvtarioActivo = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable
    '                    NewRow.InvtarioPasivo = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable
    '                    Saldo = (NewRow.InvtarioActivo) - (NewRow.InvtarioPasivo)

    '                    If Saldo > 0 Then
    '                        NewRow.GestionDebe = Saldo
    '                        NewRow.GestionHaber = 0
    '                    Else
    '                        NewRow.GestionDebe = 0
    '                        NewRow.GestionHaber = Math.Abs(Saldo)
    '                    End If

    '                Case "05"
    '                    NewRow.MayorDebe = obj.DebeS00SaldoContable
    '                    NewRow.MayorHaber = obj.HabeS00SaldoContable
    '                    Saldo = NewRow.MayorDebe - NewRow.MayorHaber
    '                    If Saldo > 0 Then
    '                        NewRow.MayorDebe = Saldo
    '                        NewRow.MayorHaber = 0
    '                    Else
    '                        NewRow.MayorDebe = 0
    '                        NewRow.MayorHaber = Math.Abs(Saldo)
    '                    End If
    '                    NewRow.SaldoDeudor = obj.DebeS05SaldoContable
    '                    NewRow.SaldoAcreedor = obj.HabeS05SaldoContable
    '                    NewRow.InvtarioActivo = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable + obj.DebeS05SaldoContable
    '                    NewRow.InvtarioPasivo = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable + obj.HabeS05SaldoContable
    '                    Saldo = (NewRow.InvtarioActivo) - (NewRow.InvtarioPasivo)

    '                    If Saldo > 0 Then
    '                        NewRow.GestionDebe = Saldo
    '                        NewRow.GestionHaber = 0
    '                    Else
    '                        NewRow.GestionDebe = 0
    '                        NewRow.GestionHaber = Math.Abs(Saldo)
    '                    End If

    '                Case "06"
    '                    NewRow.MayorDebe = obj.DebeS00SaldoContable
    '                    NewRow.MayorHaber = obj.HabeS00SaldoContable
    '                    Saldo = NewRow.MayorDebe - NewRow.MayorHaber
    '                    If Saldo > 0 Then
    '                        NewRow.MayorDebe = Saldo
    '                        NewRow.MayorHaber = 0
    '                    Else
    '                        NewRow.MayorDebe = 0
    '                        NewRow.MayorHaber = Math.Abs(Saldo)
    '                    End If
    '                    NewRow.SaldoDeudor = obj.DebeS06SaldoContable
    '                    NewRow.SaldoAcreedor = obj.HabeS06SaldoContable
    '                    NewRow.InvtarioActivo = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable + obj.DebeS05SaldoContable + obj.DebeS06SaldoContable
    '                    NewRow.InvtarioPasivo = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable + obj.HabeS05SaldoContable + obj.HabeS06SaldoContable
    '                    Saldo = (NewRow.InvtarioActivo) - (NewRow.InvtarioPasivo)

    '                    If Saldo > 0 Then
    '                        NewRow.GestionDebe = Saldo
    '                        NewRow.GestionHaber = 0
    '                    Else
    '                        NewRow.GestionDebe = 0
    '                        NewRow.GestionHaber = Math.Abs(Saldo)
    '                    End If

    '                Case "07"
    '                    NewRow.MayorDebe = obj.DebeS00SaldoContable
    '                    NewRow.MayorHaber = obj.HabeS00SaldoContable
    '                    Saldo = NewRow.MayorDebe - NewRow.MayorHaber
    '                    If Saldo > 0 Then
    '                        NewRow.MayorDebe = Saldo
    '                        NewRow.MayorHaber = 0
    '                    Else
    '                        NewRow.MayorDebe = 0
    '                        NewRow.MayorHaber = Math.Abs(Saldo)
    '                    End If
    '                    NewRow.SaldoDeudor = obj.DebeS07SaldoContable
    '                    NewRow.SaldoAcreedor = obj.HabeS07SaldoContable
    '                    NewRow.InvtarioActivo = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable + obj.DebeS05SaldoContable + obj.DebeS06SaldoContable + obj.DebeS07SaldoContable
    '                    NewRow.InvtarioPasivo = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable + obj.HabeS05SaldoContable + obj.HabeS06SaldoContable + obj.HabeS07SaldoContable
    '                    Saldo = (NewRow.InvtarioActivo) - (NewRow.InvtarioPasivo)

    '                    If Saldo > 0 Then
    '                        NewRow.GestionDebe = Saldo
    '                        NewRow.GestionHaber = 0
    '                    Else
    '                        NewRow.GestionDebe = 0
    '                        NewRow.GestionHaber = Math.Abs(Saldo)
    '                    End If

    '                Case "08"
    '                    NewRow.MayorDebe = obj.DebeS00SaldoContable
    '                    NewRow.MayorHaber = obj.HabeS00SaldoContable
    '                    Saldo = NewRow.MayorDebe - NewRow.MayorHaber
    '                    If Saldo > 0 Then
    '                        NewRow.MayorDebe = Saldo
    '                        NewRow.MayorHaber = 0
    '                    Else
    '                        NewRow.MayorDebe = 0
    '                        NewRow.MayorHaber = Math.Abs(Saldo)
    '                    End If
    '                    NewRow.SaldoDeudor = obj.DebeS08SaldoContable
    '                    NewRow.SaldoAcreedor = obj.HabeS08SaldoContable
    '                    NewRow.InvtarioActivo = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable + obj.DebeS05SaldoContable + obj.DebeS06SaldoContable + obj.DebeS07SaldoContable + obj.DebeS08SaldoContable
    '                    NewRow.InvtarioPasivo = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable + obj.HabeS05SaldoContable + obj.HabeS06SaldoContable + obj.HabeS07SaldoContable + obj.HabeS08SaldoContable
    '                    Saldo = (NewRow.InvtarioActivo) - (NewRow.InvtarioPasivo)

    '                    If Saldo > 0 Then
    '                        NewRow.GestionDebe = Saldo
    '                        NewRow.GestionHaber = 0
    '                    Else
    '                        NewRow.GestionDebe = 0
    '                        NewRow.GestionHaber = Math.Abs(Saldo)
    '                    End If

    '                Case "09"
    '                    NewRow.MayorDebe = obj.DebeS00SaldoContable
    '                    NewRow.MayorHaber = obj.HabeS00SaldoContable
    '                    Saldo = NewRow.MayorDebe - NewRow.MayorHaber
    '                    If Saldo > 0 Then
    '                        NewRow.MayorDebe = Saldo
    '                        NewRow.MayorHaber = 0
    '                    Else
    '                        NewRow.MayorDebe = 0
    '                        NewRow.MayorHaber = Math.Abs(Saldo)
    '                    End If
    '                    NewRow.SaldoDeudor = obj.DebeS09SaldoContable
    '                    NewRow.SaldoAcreedor = obj.HabeS09SaldoContable
    '                    NewRow.InvtarioActivo = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable + obj.DebeS05SaldoContable + obj.DebeS06SaldoContable + obj.DebeS07SaldoContable + obj.DebeS08SaldoContable + obj.DebeS09SaldoContable
    '                    NewRow.InvtarioPasivo = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable + obj.HabeS05SaldoContable + obj.HabeS06SaldoContable + obj.HabeS07SaldoContable + obj.HabeS08SaldoContable + obj.HabeS09SaldoContable
    '                    Saldo = (NewRow.InvtarioActivo) - (NewRow.InvtarioPasivo)

    '                    If Saldo > 0 Then
    '                        NewRow.GestionDebe = Saldo
    '                        NewRow.GestionHaber = 0
    '                    Else
    '                        NewRow.GestionDebe = 0
    '                        NewRow.GestionHaber = Math.Abs(Saldo)
    '                    End If

    '                Case "10"
    '                    NewRow.MayorDebe = obj.DebeS00SaldoContable
    '                    NewRow.MayorHaber = obj.HabeS00SaldoContable
    '                    Saldo = NewRow.MayorDebe - NewRow.MayorHaber
    '                    If Saldo > 0 Then
    '                        NewRow.MayorDebe = Saldo
    '                        NewRow.MayorHaber = 0
    '                    Else
    '                        NewRow.MayorDebe = 0
    '                        NewRow.MayorHaber = Math.Abs(Saldo)
    '                    End If
    '                    NewRow.SaldoDeudor = obj.DebeS10SaldoContable
    '                    NewRow.SaldoAcreedor = obj.HabeS10SaldoContable
    '                    NewRow.InvtarioActivo = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable + obj.DebeS05SaldoContable + obj.DebeS06SaldoContable + obj.DebeS07SaldoContable + obj.DebeS08SaldoContable + obj.DebeS09SaldoContable + obj.DebeS10SaldoContable
    '                    NewRow.InvtarioPasivo = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable + obj.HabeS05SaldoContable + obj.HabeS06SaldoContable + obj.HabeS07SaldoContable + obj.HabeS08SaldoContable + obj.HabeS09SaldoContable + obj.HabeS10SaldoContable
    '                    Saldo = (NewRow.InvtarioActivo) - (NewRow.InvtarioPasivo)

    '                    If Saldo > 0 Then
    '                        NewRow.GestionDebe = Saldo
    '                        NewRow.GestionHaber = 0
    '                    Else
    '                        NewRow.GestionDebe = 0
    '                        NewRow.GestionHaber = Math.Abs(Saldo)
    '                    End If

    '                Case "11"
    '                    NewRow.MayorDebe = obj.DebeS00SaldoContable
    '                    NewRow.MayorHaber = obj.HabeS00SaldoContable
    '                    Saldo = NewRow.MayorDebe - NewRow.MayorHaber
    '                    If Saldo > 0 Then
    '                        NewRow.MayorDebe = Saldo
    '                        NewRow.MayorHaber = 0
    '                    Else
    '                        NewRow.MayorDebe = 0
    '                        NewRow.MayorHaber = Math.Abs(Saldo)
    '                    End If
    '                    NewRow.SaldoDeudor = obj.DebeS11SaldoContable
    '                    NewRow.SaldoAcreedor = obj.HabeS11SaldoContable
    '                    NewRow.InvtarioActivo = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable + obj.DebeS05SaldoContable + obj.DebeS06SaldoContable + obj.DebeS07SaldoContable + obj.DebeS08SaldoContable + obj.DebeS09SaldoContable + obj.DebeS10SaldoContable + obj.DebeS11SaldoContable
    '                    NewRow.InvtarioPasivo = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable + obj.HabeS05SaldoContable + obj.HabeS06SaldoContable + obj.HabeS07SaldoContable + obj.HabeS08SaldoContable + obj.HabeS09SaldoContable + obj.HabeS10SaldoContable + obj.HabeS11SaldoContable
    '                    Saldo = (NewRow.InvtarioActivo) - (NewRow.InvtarioPasivo)

    '                    If Saldo > 0 Then
    '                        NewRow.GestionDebe = Saldo
    '                        NewRow.GestionHaber = 0
    '                    Else
    '                        NewRow.GestionDebe = 0
    '                        NewRow.GestionHaber = Math.Abs(Saldo)
    '                    End If

    '                Case "12"
    '                    NewRow.MayorDebe = obj.DebeS00SaldoContable
    '                    NewRow.MayorHaber = obj.HabeS00SaldoContable
    '                    Saldo = NewRow.MayorDebe - NewRow.MayorHaber
    '                    If Saldo > 0 Then
    '                        NewRow.MayorDebe = Saldo
    '                        NewRow.MayorHaber = 0
    '                    Else
    '                        NewRow.MayorDebe = 0
    '                        NewRow.MayorHaber = Math.Abs(Saldo)
    '                    End If
    '                    NewRow.SaldoDeudor = obj.DebeS12SaldoContable
    '                    NewRow.SaldoAcreedor = obj.HabeS12SaldoContable
    '                    NewRow.InvtarioActivo = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable + obj.DebeS05SaldoContable + obj.DebeS06SaldoContable + obj.DebeS07SaldoContable + obj.DebeS08SaldoContable + obj.DebeS09SaldoContable + obj.DebeS10SaldoContable + obj.DebeS11SaldoContable + obj.DebeS12SaldoContable
    '                    NewRow.InvtarioPasivo = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable + obj.HabeS05SaldoContable + obj.HabeS06SaldoContable + obj.HabeS07SaldoContable + obj.HabeS08SaldoContable + obj.HabeS09SaldoContable + obj.HabeS10SaldoContable + obj.HabeS11SaldoContable + obj.HabeS12SaldoContable
    '                    Saldo = (NewRow.InvtarioActivo) - (NewRow.InvtarioPasivo)

    '                    If Saldo > 0 Then
    '                        NewRow.GestionDebe = Saldo
    '                        NewRow.GestionHaber = 0
    '                    Else
    '                        NewRow.GestionDebe = 0
    '                        NewRow.GestionHaber = Math.Abs(Saldo)
    '                    End If

    '            End Select

    '            'AGREGANDO REGISTROS AL DATATABLE
    '            'LLENANDO EL REGISTRO
    '            'AÑADIR AL DS              
    '            ds.Balances.Rows.Add(NewRow)

    '        End If

    '    Next

    '    cr.SetDataSource(ds)
    '    'Cargamos en nuestro formulario el cr
    '    Me.crv1.ReportSource = cr
    '    '/
    'End Sub
    Sub Imprimir()

        ds.Balances.Clear()
        'Llenar Cabecera()
        empresa = CType(Me.cr.Section2.ReportObjects.Item("Empresa"), CrystalDecisions.CrystalReports.Engine.TextObject)
        empresa.Text = Me.txtNomEmp.Text.Trim

        ano = CType(Me.cr.Section2.ReportObjects.Item("Periodo"), CrystalDecisions.CrystalReports.Engine.TextObject)
        ano.Text = Me.txtAno.Text + Me.txtCodMes.Text

        mes = CType(Me.cr.Section2.ReportObjects.Item("Ruc"), CrystalDecisions.CrystalReports.Engine.TextObject)
        mes.Text = SuperEntidad.xRucEmpresa

        'Traer saldos por ano 
        ent.PeriodoRegContabCabe = Me.txtAno.Text.Trim
        ent.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        ent.CampoOrden = cam.CodCtaPcge
        listarsc = sc.obtenerSaldoContableXPeriodo(ent)

        'recorrer los objetos saldos
        For Each obj As SuperEntidad In listarsc

            If obj.CodigoCuentaPcge >= Me.TxtCodCta.Text And obj.CodigoCuentaPcge <= Me.txtCodCue2.Text + "9999999" Then

                Dim Saldo As Decimal = 0

                'creando un registro para el objeto saldo
                Dim NewRow As DataSet1.BalancesRow
                NewRow = ds.Balances.NewBalancesRow

                'llenando datos al registro
                NewRow.Codigo = obj.CodigoCuentaPcge
                NewRow.Cuenta = obj.NombreCuentaPcge

                Select Case Me.txtCodMes.Text.Trim

                    Case "00"
                        NewRow.MayorDebe = 0
                        NewRow.MayorHaber = 0
                        Saldo = NewRow.MayorDebe - NewRow.MayorHaber
                        If Saldo > 0 Then
                            NewRow.MayorDebe = Saldo
                            NewRow.MayorHaber = 0
                        Else
                            NewRow.MayorDebe = 0
                            NewRow.MayorHaber = Math.Abs(Saldo)
                        End If
                        NewRow.SaldoDeudor = obj.DebeS00SaldoContable
                        NewRow.SaldoAcreedor = obj.HabeS00SaldoContable
                        NewRow.InvtarioActivo = obj.DebeS00SaldoContable
                        NewRow.InvtarioPasivo = obj.HabeS00SaldoContable
                        Saldo = (NewRow.InvtarioActivo) - (NewRow.InvtarioPasivo)

                        If Saldo > 0 Then
                            NewRow.GestionDebe = Saldo
                            NewRow.GestionHaber = 0
                        Else
                            NewRow.GestionDebe = 0
                            NewRow.GestionHaber = Math.Abs(Saldo)
                        End If

                    Case "01"
                        NewRow.MayorDebe = obj.DebeS00SaldoContable
                        NewRow.MayorHaber = obj.HabeS00SaldoContable
                        Saldo = NewRow.MayorDebe - NewRow.MayorHaber
                        If Saldo > 0 Then
                            NewRow.MayorDebe = Saldo
                            NewRow.MayorHaber = 0
                        Else
                            NewRow.MayorDebe = 0
                            NewRow.MayorHaber = Math.Abs(Saldo)
                        End If
                        NewRow.SaldoDeudor = obj.DebeS01SaldoContable
                        NewRow.SaldoAcreedor = obj.HabeS01SaldoContable
                        NewRow.InvtarioActivo = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable
                        NewRow.InvtarioPasivo = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable
                        Saldo = (NewRow.InvtarioActivo) - (NewRow.InvtarioPasivo)

                        If Saldo > 0 Then
                            NewRow.GestionDebe = Saldo
                            NewRow.GestionHaber = 0
                        Else
                            NewRow.GestionDebe = 0
                            NewRow.GestionHaber = Math.Abs(Saldo)
                        End If

                    Case "02"
                        NewRow.MayorDebe = obj.DebeS00SaldoContable
                        NewRow.MayorHaber = obj.HabeS00SaldoContable
                        Saldo = NewRow.MayorDebe - NewRow.MayorHaber
                        If Saldo > 0 Then
                            NewRow.MayorDebe = Saldo
                            NewRow.MayorHaber = 0
                        Else
                            NewRow.MayorDebe = 0
                            NewRow.MayorHaber = Math.Abs(Saldo)
                        End If
                        NewRow.SaldoDeudor = obj.DebeS02SaldoContable
                        NewRow.SaldoAcreedor = obj.HabeS02SaldoContable
                        NewRow.InvtarioActivo = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable
                        NewRow.InvtarioPasivo = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable
                        Saldo = (NewRow.InvtarioActivo) - (NewRow.InvtarioPasivo)

                        If Saldo > 0 Then
                            NewRow.GestionDebe = Saldo
                            NewRow.GestionHaber = 0
                        Else
                            NewRow.GestionDebe = 0
                            NewRow.GestionHaber = Math.Abs(Saldo)
                        End If

                    Case "03"
                        NewRow.MayorDebe = obj.DebeS00SaldoContable
                        NewRow.MayorHaber = obj.HabeS00SaldoContable
                        Saldo = NewRow.MayorDebe - NewRow.MayorHaber
                        If Saldo > 0 Then
                            NewRow.MayorDebe = Saldo
                            NewRow.MayorHaber = 0
                        Else
                            NewRow.MayorDebe = 0
                            NewRow.MayorHaber = Math.Abs(Saldo)
                        End If
                        NewRow.SaldoDeudor = obj.DebeS03SaldoContable
                        NewRow.SaldoAcreedor = obj.HabeS03SaldoContable
                        NewRow.InvtarioActivo = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable
                        NewRow.InvtarioPasivo = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable
                        Saldo = (NewRow.InvtarioActivo) - (NewRow.InvtarioPasivo)

                        If Saldo > 0 Then
                            NewRow.GestionDebe = Saldo
                            NewRow.GestionHaber = 0
                        Else
                            NewRow.GestionDebe = 0
                            NewRow.GestionHaber = Math.Abs(Saldo)
                        End If

                    Case "04"
                        NewRow.MayorDebe = obj.DebeS00SaldoContable
                        NewRow.MayorHaber = obj.HabeS00SaldoContable
                        Saldo = NewRow.MayorDebe - NewRow.MayorHaber
                        If Saldo > 0 Then
                            NewRow.MayorDebe = Saldo
                            NewRow.MayorHaber = 0
                        Else
                            NewRow.MayorDebe = 0
                            NewRow.MayorHaber = Math.Abs(Saldo)
                        End If
                        NewRow.SaldoDeudor = obj.DebeS04SaldoContable
                        NewRow.SaldoAcreedor = obj.HabeS04SaldoContable
                        NewRow.InvtarioActivo = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable
                        NewRow.InvtarioPasivo = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable
                        Saldo = (NewRow.InvtarioActivo) - (NewRow.InvtarioPasivo)

                        If Saldo > 0 Then
                            NewRow.GestionDebe = Saldo
                            NewRow.GestionHaber = 0
                        Else
                            NewRow.GestionDebe = 0
                            NewRow.GestionHaber = Math.Abs(Saldo)
                        End If

                    Case "05"
                        NewRow.MayorDebe = obj.DebeS00SaldoContable
                        NewRow.MayorHaber = obj.HabeS00SaldoContable
                        Saldo = NewRow.MayorDebe - NewRow.MayorHaber
                        If Saldo > 0 Then
                            NewRow.MayorDebe = Saldo
                            NewRow.MayorHaber = 0
                        Else
                            NewRow.MayorDebe = 0
                            NewRow.MayorHaber = Math.Abs(Saldo)
                        End If
                        NewRow.SaldoDeudor = obj.DebeS05SaldoContable
                        NewRow.SaldoAcreedor = obj.HabeS05SaldoContable
                        NewRow.InvtarioActivo = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable + obj.DebeS05SaldoContable
                        NewRow.InvtarioPasivo = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable + obj.HabeS05SaldoContable
                        Saldo = (NewRow.InvtarioActivo) - (NewRow.InvtarioPasivo)

                        If Saldo > 0 Then
                            NewRow.GestionDebe = Saldo
                            NewRow.GestionHaber = 0
                        Else
                            NewRow.GestionDebe = 0
                            NewRow.GestionHaber = Math.Abs(Saldo)
                        End If

                    Case "06"
                        NewRow.MayorDebe = obj.DebeS00SaldoContable
                        NewRow.MayorHaber = obj.HabeS00SaldoContable
                        Saldo = NewRow.MayorDebe - NewRow.MayorHaber
                        If Saldo > 0 Then
                            NewRow.MayorDebe = Saldo
                            NewRow.MayorHaber = 0
                        Else
                            NewRow.MayorDebe = 0
                            NewRow.MayorHaber = Math.Abs(Saldo)
                        End If
                        NewRow.SaldoDeudor = obj.DebeS06SaldoContable
                        NewRow.SaldoAcreedor = obj.HabeS06SaldoContable
                        NewRow.InvtarioActivo = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable + obj.DebeS05SaldoContable + obj.DebeS06SaldoContable
                        NewRow.InvtarioPasivo = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable + obj.HabeS05SaldoContable + obj.HabeS06SaldoContable
                        Saldo = (NewRow.InvtarioActivo) - (NewRow.InvtarioPasivo)

                        If Saldo > 0 Then
                            NewRow.GestionDebe = Saldo
                            NewRow.GestionHaber = 0
                        Else
                            NewRow.GestionDebe = 0
                            NewRow.GestionHaber = Math.Abs(Saldo)
                        End If

                    Case "07"
                        NewRow.MayorDebe = obj.DebeS00SaldoContable
                        NewRow.MayorHaber = obj.HabeS00SaldoContable
                        Saldo = NewRow.MayorDebe - NewRow.MayorHaber
                        If Saldo > 0 Then
                            NewRow.MayorDebe = Saldo
                            NewRow.MayorHaber = 0
                        Else
                            NewRow.MayorDebe = 0
                            NewRow.MayorHaber = Math.Abs(Saldo)
                        End If
                        NewRow.SaldoDeudor = obj.DebeS07SaldoContable
                        NewRow.SaldoAcreedor = obj.HabeS07SaldoContable
                        NewRow.InvtarioActivo = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable + obj.DebeS05SaldoContable + obj.DebeS06SaldoContable + obj.DebeS07SaldoContable
                        NewRow.InvtarioPasivo = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable + obj.HabeS05SaldoContable + obj.HabeS06SaldoContable + obj.HabeS07SaldoContable
                        Saldo = (NewRow.InvtarioActivo) - (NewRow.InvtarioPasivo)

                        If Saldo > 0 Then
                            NewRow.GestionDebe = Saldo
                            NewRow.GestionHaber = 0
                        Else
                            NewRow.GestionDebe = 0
                            NewRow.GestionHaber = Math.Abs(Saldo)
                        End If

                    Case "08"
                        NewRow.MayorDebe = obj.DebeS00SaldoContable
                        NewRow.MayorHaber = obj.HabeS00SaldoContable
                        Saldo = NewRow.MayorDebe - NewRow.MayorHaber
                        If Saldo > 0 Then
                            NewRow.MayorDebe = Saldo
                            NewRow.MayorHaber = 0
                        Else
                            NewRow.MayorDebe = 0
                            NewRow.MayorHaber = Math.Abs(Saldo)
                        End If
                        NewRow.SaldoDeudor = obj.DebeS08SaldoContable
                        NewRow.SaldoAcreedor = obj.HabeS08SaldoContable
                        NewRow.InvtarioActivo = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable + obj.DebeS05SaldoContable + obj.DebeS06SaldoContable + obj.DebeS07SaldoContable + obj.DebeS08SaldoContable
                        NewRow.InvtarioPasivo = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable + obj.HabeS05SaldoContable + obj.HabeS06SaldoContable + obj.HabeS07SaldoContable + obj.HabeS08SaldoContable
                        Saldo = (NewRow.InvtarioActivo) - (NewRow.InvtarioPasivo)

                        If Saldo > 0 Then
                            NewRow.GestionDebe = Saldo
                            NewRow.GestionHaber = 0
                        Else
                            NewRow.GestionDebe = 0
                            NewRow.GestionHaber = Math.Abs(Saldo)
                        End If

                    Case "09"
                        NewRow.MayorDebe = obj.DebeS00SaldoContable
                        NewRow.MayorHaber = obj.HabeS00SaldoContable
                        Saldo = NewRow.MayorDebe - NewRow.MayorHaber
                        If Saldo > 0 Then
                            NewRow.MayorDebe = Saldo
                            NewRow.MayorHaber = 0
                        Else
                            NewRow.MayorDebe = 0
                            NewRow.MayorHaber = Math.Abs(Saldo)
                        End If
                        NewRow.SaldoDeudor = obj.DebeS09SaldoContable
                        NewRow.SaldoAcreedor = obj.HabeS09SaldoContable
                        NewRow.InvtarioActivo = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable + obj.DebeS05SaldoContable + obj.DebeS06SaldoContable + obj.DebeS07SaldoContable + obj.DebeS08SaldoContable + obj.DebeS09SaldoContable
                        NewRow.InvtarioPasivo = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable + obj.HabeS05SaldoContable + obj.HabeS06SaldoContable + obj.HabeS07SaldoContable + obj.HabeS08SaldoContable + obj.HabeS09SaldoContable
                        Saldo = (NewRow.InvtarioActivo) - (NewRow.InvtarioPasivo)

                        If Saldo > 0 Then
                            NewRow.GestionDebe = Saldo
                            NewRow.GestionHaber = 0
                        Else
                            NewRow.GestionDebe = 0
                            NewRow.GestionHaber = Math.Abs(Saldo)
                        End If

                    Case "10"
                        NewRow.MayorDebe = obj.DebeS00SaldoContable
                        NewRow.MayorHaber = obj.HabeS00SaldoContable
                        Saldo = NewRow.MayorDebe - NewRow.MayorHaber
                        If Saldo > 0 Then
                            NewRow.MayorDebe = Saldo
                            NewRow.MayorHaber = 0
                        Else
                            NewRow.MayorDebe = 0
                            NewRow.MayorHaber = Math.Abs(Saldo)
                        End If
                        NewRow.SaldoDeudor = obj.DebeS10SaldoContable
                        NewRow.SaldoAcreedor = obj.HabeS10SaldoContable
                        NewRow.InvtarioActivo = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable + obj.DebeS05SaldoContable + obj.DebeS06SaldoContable + obj.DebeS07SaldoContable + obj.DebeS08SaldoContable + obj.DebeS09SaldoContable + obj.DebeS10SaldoContable
                        NewRow.InvtarioPasivo = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable + obj.HabeS05SaldoContable + obj.HabeS06SaldoContable + obj.HabeS07SaldoContable + obj.HabeS08SaldoContable + obj.HabeS09SaldoContable + obj.HabeS10SaldoContable
                        Saldo = (NewRow.InvtarioActivo) - (NewRow.InvtarioPasivo)

                        If Saldo > 0 Then
                            NewRow.GestionDebe = Saldo
                            NewRow.GestionHaber = 0
                        Else
                            NewRow.GestionDebe = 0
                            NewRow.GestionHaber = Math.Abs(Saldo)
                        End If

                    Case "11"
                        NewRow.MayorDebe = obj.DebeS00SaldoContable
                        NewRow.MayorHaber = obj.HabeS00SaldoContable
                        Saldo = NewRow.MayorDebe - NewRow.MayorHaber
                        If Saldo > 0 Then
                            NewRow.MayorDebe = Saldo
                            NewRow.MayorHaber = 0
                        Else
                            NewRow.MayorDebe = 0
                            NewRow.MayorHaber = Math.Abs(Saldo)
                        End If
                        NewRow.SaldoDeudor = obj.DebeS11SaldoContable
                        NewRow.SaldoAcreedor = obj.HabeS11SaldoContable
                        NewRow.InvtarioActivo = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable + obj.DebeS05SaldoContable + obj.DebeS06SaldoContable + obj.DebeS07SaldoContable + obj.DebeS08SaldoContable + obj.DebeS09SaldoContable + obj.DebeS10SaldoContable + obj.DebeS11SaldoContable
                        NewRow.InvtarioPasivo = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable + obj.HabeS05SaldoContable + obj.HabeS06SaldoContable + obj.HabeS07SaldoContable + obj.HabeS08SaldoContable + obj.HabeS09SaldoContable + obj.HabeS10SaldoContable + obj.HabeS11SaldoContable
                        Saldo = (NewRow.InvtarioActivo) - (NewRow.InvtarioPasivo)

                        If Saldo > 0 Then
                            NewRow.GestionDebe = Saldo
                            NewRow.GestionHaber = 0
                        Else
                            NewRow.GestionDebe = 0
                            NewRow.GestionHaber = Math.Abs(Saldo)
                        End If

                    Case "12"
                        NewRow.MayorDebe = obj.DebeS00SaldoContable
                        NewRow.MayorHaber = obj.HabeS00SaldoContable
                        Saldo = NewRow.MayorDebe - NewRow.MayorHaber
                        If Saldo > 0 Then
                            NewRow.MayorDebe = Saldo
                            NewRow.MayorHaber = 0
                        Else
                            NewRow.MayorDebe = 0
                            NewRow.MayorHaber = Math.Abs(Saldo)
                        End If
                        NewRow.SaldoDeudor = obj.DebeS12SaldoContable
                        NewRow.SaldoAcreedor = obj.HabeS12SaldoContable
                        NewRow.InvtarioActivo = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable + obj.DebeS05SaldoContable + obj.DebeS06SaldoContable + obj.DebeS07SaldoContable + obj.DebeS08SaldoContable + obj.DebeS09SaldoContable + obj.DebeS10SaldoContable + obj.DebeS11SaldoContable + obj.DebeS12SaldoContable
                        NewRow.InvtarioPasivo = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable + obj.HabeS05SaldoContable + obj.HabeS06SaldoContable + obj.HabeS07SaldoContable + obj.HabeS08SaldoContable + obj.HabeS09SaldoContable + obj.HabeS10SaldoContable + obj.HabeS11SaldoContable + obj.HabeS12SaldoContable
                        Saldo = (NewRow.InvtarioActivo) - (NewRow.InvtarioPasivo)

                        If Saldo > 0 Then
                            NewRow.GestionDebe = Saldo
                            NewRow.GestionHaber = 0
                        Else
                            NewRow.GestionDebe = 0
                            NewRow.GestionHaber = Math.Abs(Saldo)
                        End If

                End Select

                'AGREGANDO REGISTROS AL DATATABLE
                'LLENANDO EL REGISTRO
                'AÑADIR AL DS              
                ds.Balances.Rows.Add(NewRow)

            End If

        Next

        'ORDENAR LA TABLA
        MiDataTable.Ordenar(ds.Balances, "Codigo Desc")

        'CARGAR CRYSTAL
        cr.SetDataSource(ds)
        Me.crv1.ReportSource = cr
        '/
    End Sub



#Region "Mostrar Formulario lista"

    Private Sub txtCodMes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodMes.KeyDown
        If Me.txtCodMes.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarTabla
                win.tabla = "Mes"
                win.titulo = "Meses"
                win.txt1 = Me.txtCodMes
                win.txt2 = Me.txtDesMes
                win.NuevaVentana()
            End If
        End If
    End Sub


#End Region

#Region "Buscar por codigo"

    Private Sub txtCodMes_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodMes.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.txtCodMes : ope.txt2 = Me.txtDesMes
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

    Private Sub TxtCodCta_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodCta.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.TxtCodCta : ope.txt2 = Me.TxtNomCta
        ope.Condicion = "CuentasA2Digitos"
        ope.MostrarCodigoDescripcionDePlancuentas("CuentasAnaliticas", e)
    End Sub

    Private Sub TxtCodCta_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodCta.KeyDown
        If Me.TxtCodCta.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarPlanCuentaGe
                win.tabla = "CuentasADosDigitos"    ''va la condicion del case
                win.titulo = "Cuentas"
                win.txt1 = Me.TxtCodCta
                win.txt2 = Me.TxtNomCta
                win.ctrlFoco = Me.txtCodCue2
                win.NuevaVentana()
            End If
        End If
    End Sub

    Private Sub txtCodCue2_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodCue2.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.txtCodCue2 : ope.txt2 = Me.txtNomCue2
        ope.Condicion = "CuentasA2Digitos"
        ope.MostrarCodigoDescripcionDePlancuentas("CuentasAnaliticas", e)
    End Sub

    Private Sub txtCodCue2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodCue2.KeyDown
        If Me.txtCodCue2.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarPlanCuentaGe
                win.tabla = "CuentasADosDigitos"    ''va la condicion del case
                win.titulo = "Cuentas"
                win.txt1 = Me.txtCodCue2
                win.txt2 = Me.txtNomCue2
                win.ctrlFoco = Me.btnEjecutar
                win.NuevaVentana()
            End If
        End If
    End Sub
End Class