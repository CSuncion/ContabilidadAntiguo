Imports Entidad
Imports Negocio

Public Class WImpLibroCajaBanco
    Dim cam As New CamposEntidad
    Dim ds As New DataSet1
    Dim acc As New Accion
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
    End Sub

    Sub Imprimir()

        ds.RegContab.Clear()
        'Llenar Cabecera()
        periodo = CType(Me.CrRptLibroCajaBanco1.Section2.ReportObjects.Item("Periodo"), CrystalDecisions.CrystalReports.Engine.TextObject)
        periodo.Text = Me.txtAno.Text + " - " + Me.txtCodMes.Text

        mes = CType(Me.CrRptLibroCajaBanco1.Section2.ReportObjects.Item("mes"), CrystalDecisions.CrystalReports.Engine.TextObject)
        mes.Text = Me.txtDesMes.Text.Trim


        ruc = CType(Me.CrRptLibroCajaBanco1.Section2.ReportObjects.Item("Ruc"), CrystalDecisions.CrystalReports.Engine.TextObject)
        ruc.Text = SuperEntidad.xRucEmpresa

        empresa = CType(Me.CrRptLibroCajaBanco1.Section2.ReportObjects.Item("Empresa"), CrystalDecisions.CrystalReports.Engine.TextObject)
        empresa.Text = Me.txtNomEmp.Text

        'TRAER PARAMETRO
        Dim iParRN As New ParametroRN
        Dim iParEN As New SuperEntidad
        iParEN = iParRN.buscarParametroExis(iParEN)

        'TRAER LAS CUENTAS DEL RANGO
        Dim iCueRN As New PlanCuentaGeRN
        Dim iCueEN As New SuperEntidad
        iCueEN.NumeroDigitosPcge = iParEN.DigitosCuentaAnalitica
        iCueEN.DatoCondicion1 = Me.txtCodCta1.Text.Trim
        iCueEN.DatoCondicion2 = Me.txtCodCta2.Text.Trim
        iCueEN.CampoOrden = cam.CodCtaPcge
        Dim iLisCue As List(Of SuperEntidad) = iCueRN.ListarCuentasAnaliticasXRango(iCueEN)

        ''TRAER LOS REGISTROS CONTABLES CABECERA SOLO DE CAJA Y BANCOS
        Dim iRccRN As New RegContabCabeRN
        Dim iRccEN As New SuperEntidad
        iRccEN.PeriodoRegContabCabe = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
        iRccEN.CampoOrden = cam.NumVouRCC

        Dim iScRN As New SaldoContableRN
        Dim iScEN As New SuperEntidad

        For Each xCue As SuperEntidad In iLisCue
            'TRAER MOVIMIENTO CABECERA 
            iRccEN.CodigoCuentaBanco = xCue.CodigoCuentaPcge
            Dim iLisRcc As List(Of SuperEntidad) = iRccRN.ListarRegistrosCabeceraParaLibroCajayBancoXCuenta(iRccEN)

            'SI VIENE EN BLANCO AGREGAR UN OBJETO EN BLANCO
            If iLisRcc.Count = 0 Then
                Dim iCueBla As New SuperEntidad
                iCueBla.ImporteSolRegContabCabe = 0
                iCueBla.CodigoCuentaBanco = xCue.CodigoCuentaPcge
                iCueBla.BancoCuentaBanco = xCue.NombreCuentaPcge
                iCueBla.Mensaje = "1" ' para saber si no tiene movimiento
                iLisRcc.Add(iCueBla)
            End If

            Dim icuenta As String = ""
            Dim iSalAnt As Decimal = 0
            Dim iMesAnt As String
            Dim iSumDebe As Decimal = 0
            Dim iSumHaber As Decimal = 0

            For Each obj As SuperEntidad In iLisRcc

                Dim NewRow As DataSet1.RegContabRow
                NewRow = ds.RegContab.NewRegContabRow

                If icuenta <> obj.CodigoCuentaBanco Then
                    iScEN.ClaveSaldoContable = Me.TxtCodEmp.Text.Trim + obj.CodigoCuentaBanco + Me.txtAno.Text.Trim
                    iScEN = iScRN.buscarCuentaSaldoExisPorClave(iScEN)
                    'OBTENER MES ANTERIOR
                    If Me.txtCodMes.Text.Trim = "00" Then
                        iMesAnt = "00"
                    Else
                        iMesAnt = (CType(Me.txtCodMes.Text, Integer) - 1).ToString.PadLeft(2, CType("0", Char))
                    End If

                    'OBTENER SALDO INICIAL
                    iSalAnt = iScRN.obtenerDiferenciaDebeHaberAcumulado(iScEN, iMesAnt)

                    'OBTENER IMPORTES DEBE Y HABER ACUMULADOS HASTA EL MES ANTERIOR DEL PROCESO
                    Select Case Me.txtCodMes.Text.Trim
                        Case "00"
                            iSumDebe = 0
                            iSumHaber = 0
                        Case "01"
                            iSumDebe = iScEN.DebeS00SaldoContable
                            iSumHaber = iScEN.HabeS00SaldoContable
                        Case "02"
                            iSumDebe = iScEN.DebeS00SaldoContable + iScEN.DebeS01SaldoContable
                            iSumHaber = iScEN.HabeS00SaldoContable + iScEN.HabeS01SaldoContable
                        Case "03"
                            iSumDebe = iScEN.DebeS00SaldoContable + iScEN.DebeS01SaldoContable + iScEN.DebeS02SaldoContable
                            iSumHaber = iScEN.HabeS00SaldoContable + iScEN.HabeS01SaldoContable + iScEN.HabeS02SaldoContable
                        Case "04"
                            iSumDebe = iScEN.DebeS00SaldoContable + iScEN.DebeS01SaldoContable + iScEN.DebeS02SaldoContable + iScEN.DebeS03SaldoContable
                            iSumHaber = iScEN.HabeS00SaldoContable + iScEN.HabeS01SaldoContable + iScEN.HabeS02SaldoContable + iScEN.HabeS03SaldoContable
                        Case "05"
                            iSumDebe = iScEN.DebeS00SaldoContable + iScEN.DebeS01SaldoContable + iScEN.DebeS02SaldoContable + iScEN.DebeS03SaldoContable + iScEN.DebeS04SaldoContable
                            iSumHaber = iScEN.HabeS00SaldoContable + iScEN.HabeS01SaldoContable + iScEN.HabeS02SaldoContable + iScEN.HabeS03SaldoContable + iScEN.HabeS04SaldoContable
                        Case "06"
                            iSumDebe = iScEN.DebeS00SaldoContable + iScEN.DebeS01SaldoContable + iScEN.DebeS02SaldoContable + iScEN.DebeS03SaldoContable + iScEN.DebeS04SaldoContable + iScEN.DebeS05SaldoContable
                            iSumHaber = iScEN.HabeS00SaldoContable + iScEN.HabeS01SaldoContable + iScEN.HabeS02SaldoContable + iScEN.HabeS03SaldoContable + iScEN.HabeS04SaldoContable + iScEN.HabeS05SaldoContable
                        Case "07"
                            iSumDebe = iScEN.DebeS00SaldoContable + iScEN.DebeS01SaldoContable + iScEN.DebeS02SaldoContable + iScEN.DebeS03SaldoContable + iScEN.DebeS04SaldoContable + iScEN.DebeS05SaldoContable + iScEN.DebeS06SaldoContable
                            iSumHaber = iScEN.HabeS00SaldoContable + iScEN.HabeS01SaldoContable + iScEN.HabeS02SaldoContable + iScEN.HabeS03SaldoContable + iScEN.HabeS04SaldoContable + iScEN.HabeS05SaldoContable + iScEN.HabeS06SaldoContable
                        Case "08"
                            iSumDebe = iScEN.DebeS00SaldoContable + iScEN.DebeS01SaldoContable + iScEN.DebeS02SaldoContable + iScEN.DebeS03SaldoContable + iScEN.DebeS04SaldoContable + iScEN.DebeS05SaldoContable + iScEN.DebeS06SaldoContable + iScEN.DebeS07SaldoContable
                            iSumHaber = iScEN.HabeS00SaldoContable + iScEN.HabeS01SaldoContable + iScEN.HabeS02SaldoContable + iScEN.HabeS03SaldoContable + iScEN.HabeS04SaldoContable + iScEN.HabeS05SaldoContable + iScEN.HabeS06SaldoContable + iScEN.HabeS07SaldoContable
                        Case "09"
                            iSumDebe = iScEN.DebeS00SaldoContable + iScEN.DebeS01SaldoContable + iScEN.DebeS02SaldoContable + iScEN.DebeS03SaldoContable + iScEN.DebeS04SaldoContable + iScEN.DebeS05SaldoContable + iScEN.DebeS06SaldoContable + iScEN.DebeS07SaldoContable + iScEN.DebeS08SaldoContable
                            iSumHaber = iScEN.HabeS00SaldoContable + iScEN.HabeS01SaldoContable + iScEN.HabeS02SaldoContable + iScEN.HabeS03SaldoContable + iScEN.HabeS04SaldoContable + iScEN.HabeS05SaldoContable + iScEN.HabeS06SaldoContable + iScEN.HabeS07SaldoContable + iScEN.HabeS08SaldoContable
                        Case "10"
                            iSumDebe = iScEN.DebeS00SaldoContable + iScEN.DebeS01SaldoContable + iScEN.DebeS02SaldoContable + iScEN.DebeS03SaldoContable + iScEN.DebeS04SaldoContable + iScEN.DebeS05SaldoContable + iScEN.DebeS06SaldoContable + iScEN.DebeS07SaldoContable + iScEN.DebeS08SaldoContable + iScEN.DebeS09SaldoContable
                            iSumHaber = iScEN.HabeS00SaldoContable + iScEN.HabeS01SaldoContable + iScEN.HabeS02SaldoContable + iScEN.HabeS03SaldoContable + iScEN.HabeS04SaldoContable + iScEN.HabeS05SaldoContable + iScEN.HabeS06SaldoContable + iScEN.HabeS07SaldoContable + iScEN.HabeS08SaldoContable + iScEN.HabeS09SaldoContable
                        Case "11"
                            iSumDebe = iScEN.DebeS00SaldoContable + iScEN.DebeS01SaldoContable + iScEN.DebeS02SaldoContable + iScEN.DebeS03SaldoContable + iScEN.DebeS04SaldoContable + iScEN.DebeS05SaldoContable + iScEN.DebeS06SaldoContable + iScEN.DebeS07SaldoContable + iScEN.DebeS08SaldoContable + iScEN.DebeS09SaldoContable + iScEN.DebeS10SaldoContable
                            iSumHaber = iScEN.HabeS00SaldoContable + iScEN.HabeS01SaldoContable + iScEN.HabeS02SaldoContable + iScEN.HabeS03SaldoContable + iScEN.HabeS04SaldoContable + iScEN.HabeS05SaldoContable + iScEN.HabeS06SaldoContable + iScEN.HabeS07SaldoContable + iScEN.HabeS08SaldoContable + iScEN.HabeS09SaldoContable + iScEN.HabeS10SaldoContable
                        Case "12"
                            iSumDebe = iScEN.DebeS00SaldoContable + iScEN.DebeS01SaldoContable + iScEN.DebeS02SaldoContable + iScEN.DebeS03SaldoContable + iScEN.DebeS04SaldoContable + iScEN.DebeS05SaldoContable + iScEN.DebeS06SaldoContable + iScEN.DebeS07SaldoContable + iScEN.DebeS08SaldoContable + iScEN.DebeS09SaldoContable + iScEN.DebeS10SaldoContable + iScEN.DebeS11SaldoContable
                            iSumHaber = iScEN.HabeS00SaldoContable + iScEN.HabeS01SaldoContable + iScEN.HabeS02SaldoContable + iScEN.HabeS03SaldoContable + iScEN.HabeS04SaldoContable + iScEN.HabeS05SaldoContable + iScEN.HabeS06SaldoContable + iScEN.HabeS07SaldoContable + iScEN.HabeS08SaldoContable + iScEN.HabeS09SaldoContable + iScEN.HabeS10SaldoContable + iScEN.HabeS11SaldoContable
                    End Select

                    icuenta = obj.CodigoCuentaBanco
                End If

                'LLENAR CON EL MOVIMIENTO ACUMULADO
                NewRow.ImporteSol = iSumDebe
                NewRow.ImporteDol = iSumHaber

                'PONER AL SALDO INICIAL AL DEBE O AL HABER
                If iSalAnt > 0 Then
                    NewRow.ImporteDebeAcumulado = iSalAnt
                    NewRow.ImporteHaberAcumulado = 0
                Else
                    NewRow.ImporteHaberAcumulado = Math.Abs(iSalAnt)
                    NewRow.ImporteDebeAcumulado = 0
                End If

                If obj.Mensaje = "1" Then
                    NewRow.FechaDocumento = ""
                    If iSalAnt <> 0 Then
                        NewRow.CodigoOrigen = obj.CodigoOrigen
                        NewRow.CodigoFile = obj.CodigoFile
                        NewRow.NumeroVoucherRegContab = obj.NumeroVoucherRegContabCabe
                        NewRow.GlosaRegContab = obj.GlosaRegContabCabe
                        NewRow.DescripcionAuxiliar = obj.DescripcionRegContabCabe
                        'Si Debe / Haber 
                        If obj.CodigoOrigen = "1" Then
                            NewRow.ImporteDebe = obj.ImporteSolRegContabCabe
                            NewRow.ImporteHaber = 0
                        Else
                            NewRow.ImporteDebe = 0
                            NewRow.ImporteHaber = obj.ImporteSolRegContabCabe
                        End If

                        'NewRow.Correlativo = obj.CorrelativoRegContabDeta
                        NewRow.Clave = obj.CodigoModoPago
                        NewRow.TipoDocumento = obj.TipoDocumento
                        NewRow.SerieDocumento = obj.SerieDocumento
                        NewRow.NumeroDocumento = obj.NumeroDocumento
                        NewRow.Cuenta = obj.CodigoCuentaBanco
                        NewRow.nombrecuenta = obj.BancoCuentaBanco

                        'AGREGANDO REGISTROS AL DATATABLE
                        'LLENANDO EL REGISTRO
                        'AÑADIR AL DS
                        ds.RegContab.Rows.Add(NewRow)
                    End If
                Else
                    NewRow.FechaDocumento = obj.FechaVoucherRegContabCabe.ToShortDateString
                    NewRow.CodigoOrigen = obj.CodigoOrigen
                    NewRow.CodigoFile = obj.CodigoFile
                    NewRow.NumeroVoucherRegContab = obj.NumeroVoucherRegContabCabe
                    NewRow.GlosaRegContab = obj.GlosaRegContabCabe
                    NewRow.DescripcionAuxiliar = obj.DescripcionRegContabCabe
                    'Si Debe / Haber 
                    If obj.CodigoOrigen = "1" Then
                        NewRow.ImporteDebe = obj.ImporteSolRegContabCabe
                        NewRow.ImporteHaber = 0
                    Else
                        NewRow.ImporteDebe = 0
                        NewRow.ImporteHaber = obj.ImporteSolRegContabCabe
                    End If

                    'NewRow.Correlativo = obj.CorrelativoRegContabDeta
                    NewRow.Clave = obj.CodigoModoPago
                    NewRow.TipoDocumento = obj.TipoDocumento
                    NewRow.SerieDocumento = obj.SerieDocumento
                    NewRow.NumeroDocumento = obj.NumeroDocumento
                    NewRow.Cuenta = obj.CodigoCuentaBanco
                    NewRow.nombrecuenta = obj.BancoCuentaBanco

                    'AGREGANDO REGISTROS AL DATATABLE
                    'LLENANDO EL REGISTRO
                    'AÑADIR AL DS
                    ds.RegContab.Rows.Add(NewRow)
                End If
               
            Next
        Next

        Me.CrRptLibroCajaBanco1.SetDataSource(ds)
        'Cargamos en nuestro formulario el cr
        Me.crv1.ReportSource = Me.CrRptLibroCajaBanco1
        '/
    End Sub



    '    Sub Imprimir()

    '        ds.RegContab.Clear()
    '        'Llenar Cabecera()
    '        periodo = CType(Me.CrRptLibroCajaBanco1.Section2.ReportObjects.Item("Periodo"), CrystalDecisions.CrystalReports.Engine.TextObject)
    '        periodo.Text = Me.txtAno.Text + " - " + Me.txtCodMes.Text

    '        mes = CType(Me.CrRptLibroCajaBanco1.Section2.ReportObjects.Item("mes"), CrystalDecisions.CrystalReports.Engine.TextObject)
    '        mes.Text = Me.txtDesMes.Text.Trim


    '        ruc = CType(Me.CrRptLibroCajaBanco1.Section2.ReportObjects.Item("Ruc"), CrystalDecisions.CrystalReports.Engine.TextObject)
    '        ruc.Text = SuperEntidad.xRucEmpresa

    '        empresa = CType(Me.CrRptLibroCajaBanco1.Section2.ReportObjects.Item("Empresa"), CrystalDecisions.CrystalReports.Engine.TextObject)
    '        empresa.Text = Me.txtNomEmp.Text


    '        ''TRAER LOS REGISTROS CONTABLES CABECERA SOLO DE CAJA Y BANCOS
    '        Dim iRccRN As New RegContabCabeRN
    '        Dim iRccEN As New SuperEntidad
    '        iRccEN.DatoFiltro1 = Me.txtAno.Text.Trim + Me.txtCodMes.Text.Trim
    '        iRccEN.DatoFiltro2 = Me.txtAno.Text.Trim + Me.TxtCodMes1.Text.Trim
    '        iRccEN.DatoFiltro3 = Me.txtCodCta1.Text.Trim
    '        iRccEN.DatoFiltro4 = Me.txtCodCta2.Text.Trim
    '        iRccEN.CampoOrden = cam.CodCtaBco
    '        'TRAER MOVIMIENTO CABECERA 
    '        Dim iLisRcc As List(Of SuperEntidad) = iRccRN.ListarRegistrosCabeceraParaLibroCajayBanco(iRccEN)

    '        Dim icuenta As String = ""
    '        Dim iScRN As New SaldoContableRN
    '        Dim iScEN As New SuperEntidad
    '        Dim iSalAnt As Decimal = 0
    '        Dim iMesAnt As String
    '        Dim iSumDebe As Decimal = 0
    '        Dim iSumHaber As Decimal = 0

    '        For Each obj As SuperEntidad In iLisRcc

    '            Dim NewRow As DataSet1.RegContabRow
    '            NewRow = ds.RegContab.NewRegContabRow

    '            If icuenta <> obj.CodigoCuentaBanco Then
    '                iScEN.ClaveSaldoContable = Me.TxtCodEmp.Text.Trim + obj.CodigoCuentaBanco + Me.txtAno.Text.Trim
    '                iScEN = iScRN.buscarCuentaSaldoExisPorClave(iScEN)
    '                'OBTENER MES ANTERIOR
    '                If Me.txtCodMes.Text.Trim = "00" Then
    '                    iMesAnt = "00"
    '                Else
    '                    iMesAnt = (CType(Me.txtCodMes.Text, Integer) - 1).ToString.PadLeft(2, CType("0", Char))
    '                End If

    '                'OBTENER SALDO INICIAL
    '                iSalAnt = iScRN.obtenerDiferenciaDebeHaberAcumulado(iScEN, iMesAnt)

    '                'OBTENER IMPORTES DEBE Y HABER ACUMULADOS HASTA EL MES ANTERIOR DEL PROCESO
    '                Select Case Me.txtCodMes.Text.Trim
    '                    Case "00"
    '                        iSumDebe = 0
    '                        iSumHaber = 0
    '                    Case "01"
    '                        iSumDebe = iScEN.DebeS00SaldoContable
    '                        iSumHaber = iScEN.HabeS00SaldoContable
    '                    Case "02"
    '                        iSumDebe = iScEN.DebeS00SaldoContable + iScEN.DebeS01SaldoContable
    '                        iSumHaber = iScEN.HabeS00SaldoContable + iScEN.HabeS01SaldoContable
    '                    Case "03"
    '                        iSumDebe = iScEN.DebeS00SaldoContable + iScEN.DebeS01SaldoContable + iScEN.DebeS02SaldoContable
    '                        iSumHaber = iScEN.HabeS00SaldoContable + iScEN.HabeS01SaldoContable + iScEN.HabeS02SaldoContable
    '                    Case "04"
    '                        iSumDebe = iScEN.DebeS00SaldoContable + iScEN.DebeS01SaldoContable + iScEN.DebeS02SaldoContable + iScEN.DebeS03SaldoContable
    '                        iSumHaber = iScEN.HabeS00SaldoContable + iScEN.HabeS01SaldoContable + iScEN.HabeS02SaldoContable + iScEN.HabeS03SaldoContable
    '                    Case "05"
    '                        iSumDebe = iScEN.DebeS00SaldoContable + iScEN.DebeS01SaldoContable + iScEN.DebeS02SaldoContable + iScEN.DebeS03SaldoContable + iScEN.DebeS04SaldoContable
    '                        iSumHaber = iScEN.HabeS00SaldoContable + iScEN.HabeS01SaldoContable + iScEN.HabeS02SaldoContable + iScEN.HabeS03SaldoContable + iScEN.HabeS04SaldoContable
    '                    Case "06"
    '                        iSumDebe = iScEN.DebeS00SaldoContable + iScEN.DebeS01SaldoContable + iScEN.DebeS02SaldoContable + iScEN.DebeS03SaldoContable + iScEN.DebeS04SaldoContable + iScEN.DebeS05SaldoContable
    '                        iSumHaber = iScEN.HabeS00SaldoContable + iScEN.HabeS01SaldoContable + iScEN.HabeS02SaldoContable + iScEN.HabeS03SaldoContable + iScEN.HabeS04SaldoContable + iScEN.HabeS05SaldoContable
    '                    Case "07"
    '                        iSumDebe = iScEN.DebeS00SaldoContable + iScEN.DebeS01SaldoContable + iScEN.DebeS02SaldoContable + iScEN.DebeS03SaldoContable + iScEN.DebeS04SaldoContable + iScEN.DebeS05SaldoContable + iScEN.DebeS06SaldoContable
    '                        iSumHaber = iScEN.HabeS00SaldoContable + iScEN.HabeS01SaldoContable + iScEN.HabeS02SaldoContable + iScEN.HabeS03SaldoContable + iScEN.HabeS04SaldoContable + iScEN.HabeS05SaldoContable + iScEN.HabeS06SaldoContable
    '                    Case "08"
    '                        iSumDebe = iScEN.DebeS00SaldoContable + iScEN.DebeS01SaldoContable + iScEN.DebeS02SaldoContable + iScEN.DebeS03SaldoContable + iScEN.DebeS04SaldoContable + iScEN.DebeS05SaldoContable + iScEN.DebeS06SaldoContable + iScEN.DebeS07SaldoContable
    '                        iSumHaber = iScEN.HabeS00SaldoContable + iScEN.HabeS01SaldoContable + iScEN.HabeS02SaldoContable + iScEN.HabeS03SaldoContable + iScEN.HabeS04SaldoContable + iScEN.HabeS05SaldoContable + iScEN.HabeS06SaldoContable + iScEN.HabeS07SaldoContable
    '                    Case "09"
    '                        iSumDebe = iScEN.DebeS00SaldoContable + iScEN.DebeS01SaldoContable + iScEN.DebeS02SaldoContable + iScEN.DebeS03SaldoContable + iScEN.DebeS04SaldoContable + iScEN.DebeS05SaldoContable + iScEN.DebeS06SaldoContable + iScEN.DebeS07SaldoContable + iScEN.DebeS08SaldoContable
    '                        iSumHaber = iScEN.HabeS00SaldoContable + iScEN.HabeS01SaldoContable + iScEN.HabeS02SaldoContable + iScEN.HabeS03SaldoContable + iScEN.HabeS04SaldoContable + iScEN.HabeS05SaldoContable + iScEN.HabeS06SaldoContable + iScEN.HabeS07SaldoContable + iScEN.HabeS08SaldoContable
    '                    Case "10"
    '                        iSumDebe = iScEN.DebeS00SaldoContable + iScEN.DebeS01SaldoContable + iScEN.DebeS02SaldoContable + iScEN.DebeS03SaldoContable + iScEN.DebeS04SaldoContable + iScEN.DebeS05SaldoContable + iScEN.DebeS06SaldoContable + iScEN.DebeS07SaldoContable + iScEN.DebeS08SaldoContable + iScEN.DebeS09SaldoContable
    '                        iSumHaber = iScEN.HabeS00SaldoContable + iScEN.HabeS01SaldoContable + iScEN.HabeS02SaldoContable + iScEN.HabeS03SaldoContable + iScEN.HabeS04SaldoContable + iScEN.HabeS05SaldoContable + iScEN.HabeS06SaldoContable + iScEN.HabeS07SaldoContable + iScEN.HabeS08SaldoContable + iScEN.HabeS09SaldoContable
    '                    Case "11"
    '                        iSumDebe = iScEN.DebeS00SaldoContable + iScEN.DebeS01SaldoContable + iScEN.DebeS02SaldoContable + iScEN.DebeS03SaldoContable + iScEN.DebeS04SaldoContable + iScEN.DebeS05SaldoContable + iScEN.DebeS06SaldoContable + iScEN.DebeS07SaldoContable + iScEN.DebeS08SaldoContable + iScEN.DebeS09SaldoContable + iScEN.DebeS10SaldoContable
    '                        iSumHaber = iScEN.HabeS00SaldoContable + iScEN.HabeS01SaldoContable + iScEN.HabeS02SaldoContable + iScEN.HabeS03SaldoContable + iScEN.HabeS04SaldoContable + iScEN.HabeS05SaldoContable + iScEN.HabeS06SaldoContable + iScEN.HabeS07SaldoContable + iScEN.HabeS08SaldoContable + iScEN.HabeS09SaldoContable + iScEN.HabeS10SaldoContable
    '                    Case "12"
    '                        iSumDebe = iScEN.DebeS00SaldoContable + iScEN.DebeS01SaldoContable + iScEN.DebeS02SaldoContable + iScEN.DebeS03SaldoContable + iScEN.DebeS04SaldoContable + iScEN.DebeS05SaldoContable + iScEN.DebeS06SaldoContable + iScEN.DebeS07SaldoContable + iScEN.DebeS08SaldoContable + iScEN.DebeS09SaldoContable + iScEN.DebeS10SaldoContable + iScEN.DebeS11SaldoContable
    '                        iSumHaber = iScEN.HabeS00SaldoContable + iScEN.HabeS01SaldoContable + iScEN.HabeS02SaldoContable + iScEN.HabeS03SaldoContable + iScEN.HabeS04SaldoContable + iScEN.HabeS05SaldoContable + iScEN.HabeS06SaldoContable + iScEN.HabeS07SaldoContable + iScEN.HabeS08SaldoContable + iScEN.HabeS09SaldoContable + iScEN.HabeS10SaldoContable + iScEN.HabeS11SaldoContable
    '                End Select

    '                icuenta = obj.CodigoCuentaBanco
    '            End If

    '            'LLENAR CON EL MOVIMIENTO ACUMULADO
    '            NewRow.ImporteSol = iSumDebe
    '            NewRow.ImporteDol = iSumHaber

    '            'PONER AL SALDO INICIAL AL DEBE O AL HABER
    '            If iSalAnt > 0 Then
    '                NewRow.ImporteDebeAcumulado = iSalAnt
    '                NewRow.ImporteHaberAcumulado = 0
    '            Else
    '                NewRow.ImporteHaberAcumulado = Math.Abs(iSalAnt)
    '                NewRow.ImporteDebeAcumulado = 0
    '            End If

    '            NewRow.FechaVoucherrgContab = obj.FechaVoucherRegContabCabe
    '            NewRow.CodigoOrigen = obj.CodigoOrigen
    '            NewRow.CodigoFile = obj.CodigoFile
    '            NewRow.NumeroVoucherRegContab = obj.NumeroVoucherRegContabCabe
    '            NewRow.GlosaRegContab = obj.DescripcionRegContabCabe
    '            NewRow.DescripcionAuxiliar = obj.DescripcionAuxiliar
    '            'Si Debe / Haber 
    '            If obj.CodigoOrigen = "1" Then
    '                NewRow.ImporteDebe = obj.ImporteSolRegContabCabe
    '                NewRow.ImporteHaber = 0
    '            Else
    '                NewRow.ImporteDebe = 0
    '                NewRow.ImporteHaber = obj.ImporteSolRegContabCabe
    '            End If

    '            'NewRow.Correlativo = obj.CorrelativoRegContabDeta
    '            NewRow.Clave = obj.CodigoModoPago
    '            NewRow.TipoDocumento = obj.TipoDocumento
    '            NewRow.SerieDocumento = obj.SerieDocumento
    '            NewRow.NumeroDocumento = obj.NumeroDocumento
    '            NewRow.Cuenta = obj.CodigoCuentaBanco
    '            NewRow.nombrecuenta = obj.BancoCuentaBanco

    '            'AGREGANDO REGISTROS AL DATATABLE
    '            'LLENANDO EL REGISTRO
    '            'AÑADIR AL DS
    '            ds.RegContab.Rows.Add(NewRow)
    '        Next

    '        Me.CrRptLibroCajaBanco1.SetDataSource(ds)
    '        'Cargamos en nuestro formulario el cr
    '        Me.crv1.ReportSource = Me.CrRptLibroCajaBanco1
    '        '/
    '    End Sub

#Region "Mostrar Form Lista"

    Private Sub txtCodMes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodMes.KeyDown
        If Me.txtCodMes.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarTabla
                win.tabla = "Mes"
                win.titulo = "Meses"
                win.txt1 = Me.txtCodMes
                win.txt2 = Me.txtDesMes
                win.ctrlFoco = Me.txtCodCta1
                win.NuevaVentana()
            End If
        End If
    End Sub

    'Private Sub TxtCodMes1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodMes1.KeyDown
    '    If Me.txtCodMes.ReadOnly = False Then
    '        If e.KeyCode = Keys.F1 Then
    '            Dim win As New WListarTabla
    '            win.tabla = "Mes"
    '            win.titulo = "Meses"
    '            win.txt1 = Me.TxtCodMes1
    '            win.txt2 = Me.TxtDesMes1
    '            win.ctrlFoco = Me.txtCodCta1
    '            win.NuevaVentana()
    '        End If
    '    End If
    'End Sub

    Private Sub txtCodCta1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodCta1.KeyDown
        If Me.txtCodCta1.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarPlanCuentaGe
                win.tabla = "CuentasAnaliticas"    ''va la condicion del case
                win.titulo = "Cuentas"
                win.txt1 = Me.txtCodCta1
                win.txt2 = Me.txtNomCta1
                win.ctrlFoco = Me.txtCodCta2
                win.NuevaVentana()
            End If

        End If
    End Sub


    Private Sub txtCodCta2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodCta2.KeyDown
        If Me.txtCodCta2.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarPlanCuentaGe
                win.tabla = "CuentasAnaliticas"    ''va la condicion del case
                win.titulo = "Cuentas"
                win.txt1 = Me.txtCodCta2
                win.txt2 = Me.txtNomCta2
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

    'Private Sub TxtCodMes1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCodMes1.Validating
    '    Dim ope As New OperaWin : ope.txt1 = Me.TxtCodMes1 : ope.txt2 = Me.TxtDesMes1
    '    ope.MostrarCodigoDescripcionDeTabla("Mes", "Meses", e)
    'End Sub

    Private Sub txtCodCta1_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodCta1.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.txtCodCta1 : ope.txt2 = Me.txtNomCta1
        ope.Condicion = "CuentasAnaliticas"
        ope.MostrarCodigoDescripcionDePlancuentas("CuentasAnaliticas", e)
    End Sub


    Private Sub txtCodCta2_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodCta2.Validating
        Dim ope As New OperaWin : ope.txt1 = Me.txtCodCta2 : ope.txt2 = Me.txtNomCta2
        ope.Condicion = "CuentasAnaliticas"
        ope.MostrarCodigoDescripcionDePlancuentas("CuentasAnaliticas", e)
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