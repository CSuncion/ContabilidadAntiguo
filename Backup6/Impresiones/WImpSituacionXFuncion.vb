Imports CrystalDecisions.CrystalReports.Engine
Imports Entidad
Imports Negocio

Public Class WImpSituacionXFuncion

    Public ent, entCont, paren As New SuperEntidad
    Public lista, listarsc As New List(Of SuperEntidad)
    Public sc As New SaldoContableRN
    Public rcdc As New MovimientoContableCabeceraRN
    Public rcdm As New MovimientoContableDetalleRN
    Public par As New ParametroRN
    Dim cam As New CamposEntidad
    Dim ds As New DataSet1
    Dim tb As New DataTable
    Dim cr As New CrRptBalanceSituacion
    Dim acc As New Accion
    Dim numerodigitos As String = "2"
    Dim text11, ano, mes, digito, empresa As CrystalDecisions.CrystalReports.Engine.TextObject
    Dim res1, res2, res3, res4, sum1, sum2, sum3, sum4 As CrystalDecisions.CrystalReports.Engine.TextObject

    'Dim wtota01 As Decimal = 0
    'Dim wtota02 As Decimal = 0
    'Dim wtota03 As Decimal = 0
    'Dim wtota04 As Decimal = 0
    'Dim wtota05 As Decimal = 0
    'Dim wtota06 As Decimal = 0
    Dim wtota07 As Decimal = 0
    Dim wtota08 As Decimal = 0
    Dim wtota09 As Decimal = 0
    Dim wtota10 As Decimal = 0


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
        paren = par.buscarParametroExis(paren)
    End Sub

    Sub acumulados(ByVal Sal As Decimal, ByVal Ob As SuperEntidad, ByRef r As DataSet1.BalancesRow)
        'Dim invpas As Decimal = 0
        'Dim invact As Decimal = 0
        'Dim salacr As Decimal = 0
        'Dim saldeu As Decimal = 0
        'Dim gesdeb As Decimal = 0
        'Dim geshab As Decimal = 0
        'Dim resgan As Decimal = 0
        'Dim resper As Decimal = 0

        If Sal < 0 Then

            If Ob.CodigoCuentaPcge >= "00" And Ob.CodigoCuentaPcge < "39" Then
                r.InvtarioPasivo = Math.Abs(Sal)
                'wtota08 = wtota08 + invpas
                r.SaldoAcreedor = Math.Abs(Sal)
                'wtota04 = wtota04 + salacr
            End If

            If Ob.CodigoCuentaPcge > "38" And Ob.CodigoCuentaPcge < "51" Then
                r.InvtarioPasivo = Math.Abs(Sal)
                'wtota08 = wtota08 + invpas
                r.SaldoAcreedor = Math.Abs(Sal)
                'wtota04 = wtota04 + salacr
            End If

            If Ob.CodigoCuentaPcge = "52" Or Ob.CodigoCuentaPcge = "56" Or Ob.CodigoCuentaPcge = "57" Or Ob.CodigoCuentaPcge = "58" Then
                r.InvtarioPasivo = Math.Abs(Sal)
                'wtota08 = wtota08 + invpas
                r.SaldoAcreedor = Math.Abs(Sal)
                'wtota04 = wtota04 + salacr
            End If

            If Ob.CodigoCuentaPcge = "59" Then
                r.InvtarioPasivo = Math.Abs(Sal)
                'wtota08 = wtota08 + invpas
                r.SaldoAcreedor = Math.Abs(Sal)
                'wtota04 = wtota04 + salacr
            End If

            If Ob.CodigoCuentaPcge = "60" Or Ob.CodigoCuentaPcge = "62" Or Ob.CodigoCuentaPcge = "63" Or Ob.CodigoCuentaPcge = "64" Or Ob.CodigoCuentaPcge = "65" Or Ob.CodigoCuentaPcge = "67" Or Ob.CodigoCuentaPcge = "68" Or Ob.CodigoCuentaPcge = "71" Then
                r.GestionHaber = Math.Abs(Sal)
                'wtota06 = wtota06 + geshab
                r.SaldoAcreedor = Math.Abs(Sal)
                'wtota04 = wtota04 + salacr
            End If

            If Ob.CodigoCuentaPcge = "61" Then
                r.SaldoAcreedor = Math.Abs(Sal)
                'wtota04 = wtota04 + salacr
                r.GestionHaber = Math.Abs(Sal)
                'wtota06 = wtota06 + geshab
            End If

            If Ob.CodigoCuentaPcge = "66" Or Ob.CodigoCuentaPcge = "69" Then
                r.ResultadoGanancia = Math.Abs(Sal)
                'wtota10 = wtota10 + resgan
                r.SaldoAcreedor = Math.Abs(Sal)
                'wtota04 = wtota04 + salacr
            End If

            If Ob.CodigoCuentaPcge > "69" And Ob.CodigoCuentaPcge < "78" Then
                If Ob.CodigoCuentaPcge = "71" Then
                Else
                    r.SaldoAcreedor = Math.Abs(Sal)
                    'wtota04 = wtota04 + salacr
                    r.ResultadoGanancia = Math.Abs(Sal)
                    'wtota10 = wtota10 + resgan
                End If
                
            End If

            If Ob.CodigoCuentaPcge = "78" Or Ob.CodigoCuentaPcge = "79" Then
                r.GestionHaber = Math.Abs(Sal)
                'wtota06 = wtota06 + geshab
                r.SaldoAcreedor = Math.Abs(Sal)
                'wtota04 = wtota04 + salacr
            End If

            'If Ob.CodigoCuentaPcge = "91" Or Ob.CodigoCuentaPcge = "92" Then
            '    r.GestionHaber = Math.Abs(Sal)
            '    'wtota06 = wtota06 + geshab
            '    r.SaldoAcreedor = Math.Abs(Sal)
            '    'wtota04 = wtota04 + salacr
            'End If

            If Ob.CodigoCuentaPcge >= "87" And Ob.CodigoCuentaPcge <= "99" Then   '88
                'If Ob.CodigoCuentaPcge = "91" Or Ob.CodigoCuentaPcge = "92" Then
                'Else
                r.SaldoAcreedor = Math.Abs(Sal)
                'wtota04 = wtota04 + salacr
                r.ResultadoGanancia = Math.Abs(Sal)
                'wtota10 = wtota10 + resgan
                'End If

            End If
        Else   '' Positivos
            If Ob.CodigoCuentaPcge >= "00" And Ob.CodigoCuentaPcge < "39" Then
                r.InvtarioActivo = Sal
                'wtota07 = wtota07 + invact
                r.SaldoDeudor = Sal
                'wtota03 = wtota03 + saldeu
            End If

            If Ob.CodigoCuentaPcge > "38" And Ob.CodigoCuentaPcge < "51" Then
                r.InvtarioActivo = Sal
                'wtota07 = wtota07 + invact
                r.SaldoDeudor = Sal
                'wtota03 = wtota03 + saldeu
            End If

            If Ob.CodigoCuentaPcge = "52" Or Ob.CodigoCuentaPcge = "56" Or Ob.CodigoCuentaPcge = "57" Or Ob.CodigoCuentaPcge = "58" Then
                r.InvtarioActivo = Sal
                'wtota07 = wtota07 + invact
                r.SaldoDeudor = Sal
                'wtota03 = wtota03 + saldeu
            End If

            If Ob.CodigoCuentaPcge = "59" Then
                r.SaldoDeudor = Sal
                'wtota03 = wtota03 + saldeu
                r.InvtarioActivo = Sal
                'wtota07 = wtota07 + invact
            End If

            If Ob.CodigoCuentaPcge = "60" Or Ob.CodigoCuentaPcge = "62" Or Ob.CodigoCuentaPcge = "63" Or Ob.CodigoCuentaPcge = "64" Or Ob.CodigoCuentaPcge = "65" Or Ob.CodigoCuentaPcge = "67" Or Ob.CodigoCuentaPcge = "68" Or Ob.CodigoCuentaPcge = "71" Then
                r.GestionDebe = Sal
                'wtota05 = wtota05 + gesdeb
                r.SaldoDeudor = Sal
                'wtota03 = wtota03 + saldeu
            End If

            If Ob.CodigoCuentaPcge = "61" Then
                r.SaldoDeudor = Sal
                'wtota03 = wtota03 + saldeu
                r.GestionDebe = Sal
                'wtota05 = wtota05 + gesdeb
            End If

            If Ob.CodigoCuentaPcge = "66" Or Ob.CodigoCuentaPcge = "69" Then
                r.ResultadoPerdida = Sal
                'wtota09 = wtota09 + resper
                r.SaldoDeudor = Sal
                'wtota03 = wtota03 + saldeu
            End If

            If Ob.CodigoCuentaPcge > "69" And Ob.CodigoCuentaPcge < "78" Then
                If Ob.CodigoCuentaPcge = "71" Then
                Else
                    r.SaldoDeudor = Sal
                    'wtota03 = wtota03 + saldeu
                    r.ResultadoPerdida = Sal
                    'wtota09 = wtota09 + resper
                End If

            End If

            If Ob.CodigoCuentaPcge = "78" Or Ob.CodigoCuentaPcge = "79" Then
                r.GestionDebe = Sal
                'wtota05 = wtota05 + gesdeb
                r.SaldoDeudor = Sal
                'wtota03 = wtota03 + saldeu
            End If

            'If Ob.CodigoCuentaPcge = "91" Or Ob.CodigoCuentaPcge = "92" Then
            '    r.GestionDebe = Sal
            '    'wtota05 = wtota05 + gesdeb
            '    r.SaldoDeudor = Sal
            '    'wtota03 = wtota03 + saldeu
            'End If

            If Ob.CodigoCuentaPcge >= "87" And Ob.CodigoCuentaPcge <= "99" Then  '88
                'If Ob.CodigoCuentaPcge = "91" Or Ob.CodigoCuentaPcge = "92" Then
                'Else
                r.SaldoDeudor = Sal
                'wtota03 = wtota03 + saldeu
                r.ResultadoPerdida = Sal
                'wtota09 = wtota09 + resper
                'End If

            End If

        End If
    End Sub

    Sub Imprimir()

        ds.Balances.Clear()
        'Llenar Cabecera()
        empresa = CType(Me.cr.Section2.ReportObjects.Item("Empresa"), CrystalDecisions.CrystalReports.Engine.TextObject)
        empresa.Text = Me.txtNomEmp.Text.Trim

        ano = CType(Me.cr.Section2.ReportObjects.Item("Ano"), CrystalDecisions.CrystalReports.Engine.TextObject)
        ano.Text = Me.txtAno.Text
        mes = CType(Me.cr.Section2.ReportObjects.Item("Mes"), CrystalDecisions.CrystalReports.Engine.TextObject)
        mes.Text = Me.txtDesMes.Text

        Dim wtota07 As Decimal = 0
        Dim wtota08 As Decimal = 0
        Dim wtota09 As Decimal = 0
        Dim wtota10 As Decimal = 0

        '' Traer saldos por ano 
        ent.PeriodoRegContabCabe = Me.txtAno.Text.Trim
        ent.CodigoEmpresa = Me.TxtCodEmp.Text.Trim
        ent.CampoOrden = cam.CodCtaPcge
        'TRAER MOVIMIENTO DETALLE
        listarsc = sc.obtenerSaldoContableXPeriodo(ent)



        For Each obj As SuperEntidad In listarsc

            If numerodigitos = obj.NumeroDigitosPcge Then

                Dim invpas As Decimal = 0
                Dim invact As Decimal = 0
                Dim salacr As Decimal = 0
                Dim saldeu As Decimal = 0
                Dim gesdeb As Decimal = 0
                Dim geshab As Decimal = 0
                Dim resgan As Decimal = 0
                Dim resper As Decimal = 0

                Dim Saldo As Decimal = 0

                Dim NewRow As DataSet1.BalancesRow
                NewRow = ds.Balances.NewBalancesRow

                NewRow.Codigo = obj.CodigoCuentaPcge
                NewRow.Cuenta = obj.NombreCuentaPcge

                Select Case Me.txtCodMes.Text.Trim

                    Case "00"
                        NewRow.MayorDebe = obj.DebeS00SaldoContable
                        NewRow.MayorHaber = obj.HabeS00SaldoContable
                        Saldo = NewRow.MayorDebe - NewRow.MayorHaber
                        Me.acumulados(Saldo, obj, NewRow)

                    Case "01"
                        NewRow.MayorDebe = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable
                        NewRow.MayorHaber = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable
                        Saldo = NewRow.MayorDebe - NewRow.MayorHaber
                        Me.acumulados(Saldo, obj, NewRow)

                    Case "02"
                        NewRow.MayorDebe = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable
                        NewRow.MayorHaber = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable
                        Saldo = NewRow.MayorDebe - NewRow.MayorHaber
                        Me.acumulados(Saldo, obj, NewRow)
                    Case "03"
                        NewRow.MayorDebe = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable
                        NewRow.MayorHaber = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable
                        Saldo = NewRow.MayorDebe - NewRow.MayorHaber
                        Me.acumulados(Saldo, obj, NewRow)
                    Case "04"
                        NewRow.MayorDebe = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable
                        NewRow.MayorHaber = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable
                        Saldo = NewRow.MayorDebe - NewRow.MayorHaber
                        Me.acumulados(Saldo, obj, NewRow)
                    Case "05"
                        NewRow.MayorDebe = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable + obj.DebeS05SaldoContable
                        NewRow.MayorHaber = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable + obj.HabeS05SaldoContable
                        Saldo = NewRow.MayorDebe - NewRow.MayorHaber
                        Me.acumulados(Saldo, obj, NewRow)
                    Case "06"
                        NewRow.MayorDebe = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable + obj.DebeS05SaldoContable + obj.DebeS06SaldoContable
                        NewRow.MayorHaber = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable + obj.HabeS05SaldoContable + obj.HabeS06SaldoContable
                        Saldo = NewRow.MayorDebe - NewRow.MayorHaber
                        Me.acumulados(Saldo, obj, NewRow)
                    Case "07"
                        NewRow.MayorDebe = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable + obj.DebeS05SaldoContable + obj.DebeS06SaldoContable + obj.DebeS07SaldoContable
                        NewRow.MayorHaber = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable + obj.HabeS05SaldoContable + obj.HabeS06SaldoContable + obj.HabeS07SaldoContable
                        Saldo = NewRow.MayorDebe - NewRow.MayorHaber
                        Me.acumulados(Saldo, obj, NewRow)
                    Case "08"
                        NewRow.MayorDebe = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable + obj.DebeS05SaldoContable + obj.DebeS06SaldoContable + obj.DebeS07SaldoContable + obj.DebeS08SaldoContable
                        NewRow.MayorHaber = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable + obj.HabeS05SaldoContable + obj.HabeS06SaldoContable + obj.HabeS07SaldoContable + obj.HabeS08SaldoContable
                        Saldo = NewRow.MayorDebe - NewRow.MayorHaber
                        Me.acumulados(Saldo, obj, NewRow)
                    Case "09"
                        NewRow.MayorDebe = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable + obj.DebeS05SaldoContable + obj.DebeS06SaldoContable + obj.DebeS07SaldoContable + obj.DebeS08SaldoContable + obj.DebeS09SaldoContable
                        NewRow.MayorHaber = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable + obj.HabeS05SaldoContable + obj.HabeS06SaldoContable + obj.HabeS07SaldoContable + obj.HabeS08SaldoContable + obj.HabeS09SaldoContable
                        Saldo = NewRow.MayorDebe - NewRow.MayorHaber
                        Me.acumulados(Saldo, obj, NewRow)
                    Case "10"
                        NewRow.MayorDebe = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable + obj.DebeS05SaldoContable + obj.DebeS06SaldoContable + obj.DebeS07SaldoContable + obj.DebeS08SaldoContable + obj.DebeS09SaldoContable + obj.DebeS10SaldoContable
                        NewRow.MayorHaber = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable + obj.HabeS05SaldoContable + obj.HabeS06SaldoContable + obj.HabeS07SaldoContable + obj.HabeS08SaldoContable + obj.HabeS09SaldoContable + obj.HabeS10SaldoContable
                        Saldo = NewRow.MayorDebe - NewRow.MayorHaber
                        Me.acumulados(Saldo, obj, NewRow)
                    Case "11"
                        NewRow.MayorDebe = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable + obj.DebeS05SaldoContable + obj.DebeS06SaldoContable + obj.DebeS07SaldoContable + obj.DebeS08SaldoContable + obj.DebeS09SaldoContable + obj.DebeS10SaldoContable + obj.DebeS11SaldoContable
                        NewRow.MayorHaber = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable + obj.HabeS05SaldoContable + obj.HabeS06SaldoContable + obj.HabeS07SaldoContable + obj.HabeS08SaldoContable + obj.HabeS09SaldoContable + obj.HabeS10SaldoContable + obj.HabeS11SaldoContable
                        Saldo = NewRow.MayorDebe - NewRow.MayorHaber
                        Me.acumulados(Saldo, obj, NewRow)
                    Case "12"
                        NewRow.MayorDebe = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable + obj.DebeS05SaldoContable + obj.DebeS06SaldoContable + obj.DebeS07SaldoContable + obj.DebeS08SaldoContable + obj.DebeS09SaldoContable + obj.DebeS10SaldoContable + obj.DebeS11SaldoContable + obj.DebeS12SaldoContable
                        NewRow.MayorHaber = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable + obj.HabeS05SaldoContable + obj.HabeS06SaldoContable + obj.HabeS07SaldoContable + obj.HabeS08SaldoContable + obj.HabeS09SaldoContable + obj.HabeS10SaldoContable + obj.HabeS11SaldoContable + obj.HabeS12SaldoContable
                        Saldo = NewRow.MayorDebe - NewRow.MayorHaber
                        Me.acumulados(Saldo, obj, NewRow)
                    Case "13"
                        NewRow.MayorDebe = obj.DebeS00SaldoContable + obj.DebeS01SaldoContable + obj.DebeS02SaldoContable + obj.DebeS03SaldoContable + obj.DebeS04SaldoContable + obj.DebeS05SaldoContable + obj.DebeS06SaldoContable + obj.DebeS07SaldoContable + obj.DebeS08SaldoContable + obj.DebeS09SaldoContable + obj.DebeS10SaldoContable + obj.DebeS11SaldoContable + obj.DebeS12SaldoContable + obj.DebeS13SaldoContable
                        NewRow.MayorHaber = obj.HabeS00SaldoContable + obj.HabeS01SaldoContable + obj.HabeS02SaldoContable + obj.HabeS03SaldoContable + obj.HabeS04SaldoContable + obj.HabeS05SaldoContable + obj.HabeS06SaldoContable + obj.HabeS07SaldoContable + obj.HabeS08SaldoContable + obj.HabeS09SaldoContable + obj.HabeS10SaldoContable + obj.HabeS11SaldoContable + obj.HabeS12SaldoContable + obj.HabeS13SaldoContable
                        Saldo = NewRow.MayorDebe - NewRow.MayorHaber
                        Me.acumulados(Saldo, obj, NewRow)
                End Select
                'Suma de saldo anterior + mes actual   
                'NewRow.SumaDebe = NewRow.DebeMes + NewRow.DebeAcu
                'NewRow.SumaHaber = NewRow.HabeMes + NewRow.HabeAcu

                'AGREGANDO REGISTROS AL DATATABLE
                'LLENANDO EL REGISTRO
                'AÑADIR AL DS
                wtota07 = wtota07 + NewRow.InvtarioActivo
                wtota08 = wtota08 + NewRow.InvtarioPasivo
                wtota09 = wtota09 + NewRow.ResultadoPerdida
                wtota10 = wtota10 + NewRow.ResultadoGanancia

                ds.Balances.Rows.Add(NewRow)

            End If

        Next
        Dim wdif As Decimal = wtota07 - wtota08
        'Llenar campos de totales
        If wdif < 0 Then
            res1 = CType(Me.cr.Section4.ReportObjects.Item("Res1"), CrystalDecisions.CrystalReports.Engine.TextObject)
            res1.Text = Varios.numeroConDosDecimal(Math.Abs(wdif).ToString)
            res2 = CType(Me.cr.Section4.ReportObjects.Item("Res2"), CrystalDecisions.CrystalReports.Engine.TextObject)
            res2.Text = "0.00"
        Else
            res1 = CType(Me.cr.Section4.ReportObjects.Item("Res1"), CrystalDecisions.CrystalReports.Engine.TextObject)
            res1.Text = "0.00"
            res2 = CType(Me.cr.Section4.ReportObjects.Item("Res2"), CrystalDecisions.CrystalReports.Engine.TextObject)
            res2.Text = Varios.numeroConDosDecimal(wdif.ToString)
        End If
        Dim wdif1 As Decimal = wtota09 - wtota10
        'Llenar campos de totales
        If wdif1 < 0 Then
            res3 = CType(Me.cr.Section4.ReportObjects.Item("Res3"), CrystalDecisions.CrystalReports.Engine.TextObject)
            res3.Text = Varios.numeroConDosDecimal(Math.Abs(wdif1).ToString)
            res4 = CType(Me.cr.Section4.ReportObjects.Item("Res4"), CrystalDecisions.CrystalReports.Engine.TextObject)
            res4.Text = "0.00"
        Else
            res3 = CType(Me.cr.Section4.ReportObjects.Item("Res3"), CrystalDecisions.CrystalReports.Engine.TextObject)
            res3.Text = "0.00"
            res4 = CType(Me.cr.Section4.ReportObjects.Item("Res4"), CrystalDecisions.CrystalReports.Engine.TextObject)
            res4.Text = Varios.numeroConDosDecimal(wdif1.ToString)
        End If

        'Sumas del Cuadre
        sum1 = CType(Me.cr.Section4.ReportObjects.Item("Sum1"), CrystalDecisions.CrystalReports.Engine.TextObject)
        sum1.Text = Varios.numeroConDosDecimal((wtota07 + CType(res1.Text, Decimal)).ToString)

        sum2 = CType(Me.cr.Section4.ReportObjects.Item("Sum2"), CrystalDecisions.CrystalReports.Engine.TextObject)
        sum2.Text = Varios.numeroConDosDecimal((wtota08 + CType(res2.Text, Decimal)).ToString)

        sum3 = CType(Me.cr.Section4.ReportObjects.Item("Sum3"), CrystalDecisions.CrystalReports.Engine.TextObject)
        sum3.Text = Varios.numeroConDosDecimal((wtota09 + CType(res3.Text, Decimal)).ToString)

        sum4 = CType(Me.cr.Section4.ReportObjects.Item("Sum4"), CrystalDecisions.CrystalReports.Engine.TextObject)
        sum4.Text = Varios.numeroConDosDecimal((wtota10 + CType(res4.Text, Decimal)).ToString)

        cr.SetDataSource(ds)
        '        text11 = CType(Me.cr.Section4.ReportObjects.Item("Text11"), CrystalDecisions.CrystalReports.Engine.TextObject)
        '       text11.Text = Me.txtNomEmp.Text.Trim

        'Cargamos en nuestro formulario el cr
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




End Class