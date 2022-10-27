Option Strict Off
Public Class Varios
#Region "Metodos"
    Public Shared Function encriptar(ByVal t As String) As String
        Dim texto As String = t.Trim
        Dim codAscci As Integer
        Dim encriptado As String = ""
        For n As Integer = 0 To texto.Length - 1
            codAscci = Asc(texto.Substring(n, 1)) * 2 + 5
            If codAscci > 255 Then
                encriptado += "."
            Else
                encriptado += Chr(codAscci)
            End If
        Next
        Return encriptado
    End Function

    Public Shared Function desencriptar(ByVal t As String) As String
        Dim texto As String = t.Trim
        Dim codAscci As Integer
        Dim desencriptado As String = ""
        For n As Integer = 0 To texto.Length - 1
            codAscci = CType((Asc(texto.Substring(n, 1)) - 5) / 2, Integer)
            If codAscci > 255 Then
                desencriptado += "."
            Else
                desencriptado += Chr(codAscci)
            End If
        Next
        Return desencriptado
    End Function

    Public Shared Function numeroConDosDecimal(ByRef t As String) As String

        'reemplazar "." por ","
        '   t = t.Replace(".", ",")
        'una vez validado el numero darle la forma correcta
        t = Format(CType(t, Decimal), "###,###,##0.00")
        'reemplazar "," por "."
        ' t = t.Replace(",", ".")
        Return t
    End Function

    Public Shared Function numeroConTresDecimal(ByRef t As String) As String

        'reemplazar "." por ","
        '   t = t.Replace(".", ",")
        'una vez validado el numero darle la forma correcta
        t = Format(CType(t, Decimal), "###,###,##0.000")
        'reemplazar "," por "."
        ' t = t.Replace(",", ".")
        Return t
    End Function

    Public Shared Function numeroConComaDecimal(ByRef t As String) As String

        'reemplazar "." por ","
        t = t.Replace(".", ",")
        ''una vez validado el numero darle la forma correcta
        't = Format(CType(t, Double), "####0.00")
        ''reemplazar "," por "."
        ' t = t.Replace(",", ".")
        Return t
    End Function

    Shared Function verdadFalso(ByRef texto As String) As Boolean
        If texto.Trim = "1" Then
            Return True
        Else
            Return False
        End If
    End Function

    Shared Function LimiteMinMaxDeCaracteres(ByRef texto As String, ByRef min As Integer, ByRef max As Integer) As Boolean
        Dim lon As Integer = texto.Length
        If lon >= min And lon <= max Then
            Return True
        Else
            Return False
        End If
    End Function

    Shared Function LimiteMinMaxDeValores(ByRef texto As String, ByRef min As Integer, ByRef max As Integer) As Boolean
        Dim num As Integer = CType(texto.Trim, Integer)
        If num >= min And num <= max Then
            Return True
        Else
            Return False
        End If
    End Function


    Shared Function CompararCadenas(ByRef txt1 As TextBox, ByRef txt2 As TextBox, ByRef arg As String) As Boolean
        If txt1.Text.Trim = txt2.Text.Trim Then
            Return True
        Else
            MsgBox(arg + " no coinciden", MsgBoxStyle.Information)
            txt1.Text = ""
            txt2.Text = ""
            txt1.Focus()
            Return False
        End If

    End Function

    Shared Function DevuelveAnoFuturo(ByRef mesActual As String, ByRef anoActual As String, ByRef intervaloMeses As String) As String
        If mesActual = "" Or anoActual = "" Or intervaloMeses = "" Then
            Return ""
        Else
            Dim nuevoAno, sumaMes, incrementoAno, resto As Integer
            sumaMes = CType(mesActual, Integer) + CType(intervaloMeses, Integer)
            incrementoAno = sumaMes \ 12
            resto = sumaMes Mod 12
            If resto = 0 Then
                Return anoActual
            Else
                nuevoAno = CType(anoActual, Integer) + incrementoAno
                Return nuevoAno.ToString
            End If

        End If
    End Function

    Shared Function DevuelveMesFuturo(ByRef mesActual As String, ByRef anoActual As String, ByRef intervaloMeses As String) As String
        If mesActual = "" Or anoActual = "" Or intervaloMeses = "" Then
            Return ""
        Else
            Dim mesFuturo As String
            Dim nuevoMes, sumaMes As Integer
            sumaMes = CType(mesActual, Integer) + CType(intervaloMeses, Integer)
            nuevoMes = sumaMes Mod 12
            nuevoMes = nuevoMes - 1
            If nuevoMes = -1 Then
                Return mesActual
                Exit Function
            End If
            If nuevoMes = 0 Then
                Return "12"
            Else
                If nuevoMes < 10 Then
                    mesFuturo = "0" + CType(nuevoMes, String)
                    Return mesFuturo
                Else
                    mesFuturo = nuevoMes.ToString
                    Return mesFuturo
                End If
            End If

        End If
    End Function


    Shared Function AnoUtil(ByRef fechaActual As Date, ByRef anoIngresado As String) As Boolean
        Dim anoActual As String = fechaActual.Year.ToString
        If anoIngresado = "" Then
            Return True
        Else
            If anoIngresado >= anoActual Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Shared Function MesUtil(ByRef fechaActual As Date, ByRef anoIngresado As String, ByRef mesIngresado As String) As Boolean
        Dim anoActual As String = fechaActual.Year.ToString
        Dim mesActual As String = Varios.FormatoMes(fechaActual)
        If anoActual = anoIngresado Then
            If mesIngresado = "" Then
                Return True
                Exit Function

            End If
            If mesIngresado >= mesActual Then
                Return True
            Else
                Return False
            End If
        Else
            Return True
        End If

    End Function

    Shared Function FormatoMes(ByRef fecha As DateTime) As String
        Dim mes As String = fecha.Month.ToString
        If Varios.LimiteMinMaxDeValores(mes, 1, 9) = True Then
            Return "0" + mes
        Else
            Return mes
        End If

    End Function

    Shared Function FormatoMes(ByRef fecha As String) As String
        'Dim mes As String = fecha.Month.ToString
        Dim mesAc As String = CType(fecha, Integer).ToString
        If Varios.LimiteMinMaxDeValores(mesAc, 1, 9) = True Then
            Return "0" + mesAc
        Else
            Return mesAc
        End If

    End Function

    Shared Function FormatoDia(ByRef fecha As DateTime) As String
        Dim dia As String = fecha.Day.ToString
        If Varios.LimiteMinMaxDeValores(dia, 1, 9) = True Then
            Return "0" + dia
        Else
            Return dia
        End If

    End Function

    Shared Function FormatoDia(ByRef dia As String) As String
        Dim diar As String = CType(dia, Integer).ToString
        If Varios.LimiteMinMaxDeValores(diar, 1, 9) = True Then
            Return "0" + diar
        Else
            Return diar
        End If

    End Function

    Shared Function CalcularIgvCompras(ByRef Pv As String, ByRef Ex As String, ByRef IgvPar As Decimal) As String
        Dim igvCompras As String
        igvCompras = ((CType(Pv, Decimal) - CType(Ex, Decimal)) * IgvPar / (100 + IgvPar)).ToString
        igvCompras = Varios.numeroConDosDecimal(igvCompras)
        Return igvCompras
    End Function

    Shared Function CalcularValorVentaCompra(ByRef Pv As String, ByRef Ex As String, ByRef IgvCompras As String) As String
        Dim vvCompras As String
        vvCompras = (CType(Pv, Decimal) - CType(Ex, Decimal) - CType(IgvCompras, Decimal)).ToString
        vvCompras = Varios.numeroConDosDecimal(vvCompras)
        Return vvCompras
    End Function

    Shared Function CalcularGratificacion(ByRef Porcentaje As Decimal, ByRef Basico As String, ByRef comisionVta As String, ByRef HorasExtras As String, ByRef AsiFami As String, ByRef DL As String) As String
        Dim grati As Decimal
        grati = (CType(Basico, Decimal) + CType(comisionVta, Decimal) + CType(HorasExtras, Decimal) + CType(AsiFami, Decimal) + CType(DL, Decimal)) * Porcentaje / 100

        Return Varios.numeroConDosDecimal(CType(grati, String))
    End Function

    Shared Function CalcularCts(ByRef Porcentaje As Decimal, ByRef Basico As String, ByRef comisionVta As String, ByRef HorasExtras As String, ByRef AsiFami As String, ByRef DL As String, ByRef grati As String) As String
        Dim Cts As Decimal
        Cts = (CType(Basico, Decimal) + CType(comisionVta, Decimal) + CType(HorasExtras, Decimal) + CType(AsiFami, Decimal) + CType(DL, Decimal) + CType(grati, Decimal)) * Porcentaje / 100
        Return Varios.numeroConDosDecimal(Cts.ToString)
    End Function

    Shared Function CalcularEsSalud(ByRef Porcentaje As Decimal, ByRef Basico As String, ByRef comisionVta As String, ByRef HorasExtras As String, ByRef AsiFami As String, ByRef DL As String, ByRef grati As String) As String
        Dim Essalud As Decimal
        Essalud = (CType(Basico, Decimal) + CType(comisionVta, Decimal) + CType(HorasExtras, Decimal) + CType(AsiFami, Decimal) + CType(DL, Decimal) + CType(grati, Decimal)) * Porcentaje / 100
        Return Varios.numeroConDosDecimal(Essalud.ToString)
    End Function


    Shared Function ObtieneSumaDebe(ByRef dgv As DataGridView, ByVal mone As String) As Decimal
        Dim sdebe As Decimal = 0
        Dim nreg As Integer = dgv.Rows.Count
        mone = "S/."

        If nreg = 1 Then
            Return sdebe
        Else
            For n As Integer = 0 To dgv.Rows.Count - 2
                If dgv.Item("DH", n).Value.ToString = "Debe" Then
                    If mone = "S/." Then
                        sdebe = sdebe + CType(dgv.Item("IMPORTES", n).Value, Decimal)
                    Else
                        sdebe = sdebe + CType(dgv.Item("ImporteD", n).Value, Decimal)
                    End If
                End If

            Next
            Return sdebe
        End If
    End Function


    Shared Function ObtieneSumaDebe(ByRef dgv As DataGridView, ByVal mone As String, ByVal cero As Integer) As Decimal
        Dim sdebe As Decimal = 0
        Dim nreg As Integer = dgv.Rows.Count


        If nreg = 1 Then
            Return sdebe
        Else
            For n As Integer = 0 To dgv.Rows.Count - 2
                If dgv.Item("DH", n).Value.ToString = "Debe" Then
                    If mone = "S/." Then
                        sdebe = sdebe + CType(dgv.Item("IMPORTES", n).Value, Decimal)
                    Else
                        sdebe = sdebe + CType(dgv.Item("ImporteD", n).Value, Decimal)
                    End If
                End If

            Next
            Return sdebe
        End If
    End Function

    Shared Function ObtieneSumaHaber(ByRef dgv As DataGridView, ByVal mone As String) As Decimal
        Dim shaber As Decimal = 0
        Dim nreg As Integer = dgv.Rows.Count
        mone = "S/."
        If nreg = 1 Then
            Return shaber
        Else
            For n As Integer = 0 To dgv.Rows.Count - 2
                If dgv.Item("DH", n).Value.ToString = "Haber" Then
                    If mone = "S/." Then
                        shaber = shaber + CType(dgv.Item("IMPORTES", n).Value, Decimal)
                    Else
                        shaber = shaber + CType(dgv.Item("ImporteD", n).Value, Decimal)
                    End If

                End If
            Next
            Return shaber
        End If
    End Function


    Shared Function ObtieneSumaHaber(ByRef dgv As DataGridView, ByVal mone As String, ByVal cero As Integer) As Decimal
        Dim shaber As Decimal = 0
        Dim nreg As Integer = dgv.Rows.Count

        If nreg = 1 Then
            Return shaber
        Else
            For n As Integer = 0 To dgv.Rows.Count - 2
                If dgv.Item("DH", n).Value.ToString = "Haber" Then
                    If mone = "S/." Then
                        shaber = shaber + CType(dgv.Item("IMPORTES", n).Value, Decimal)
                    Else
                        shaber = shaber + CType(dgv.Item("ImporteD", n).Value, Decimal)
                    End If

                End If
            Next
            Return shaber
        End If
    End Function

    Shared Function ValidaDia(ByVal dia As String) As Boolean
        If EsFecha(dia) = False Then
            Return False
        Else
            Return True
        End If

    End Function

    Shared Function EsFecha(ByRef d As String) As Boolean
        Dim r As Date
        Try
            r = CType(d, Date)
            Return True
        Catch ex As Exception
            MsgBox("Fecha Incorrecta", MsgBoxStyle.Critical, "Fecha")
        End Try
    End Function

    Shared Function CortarCadena(ByRef pTexto As String, ByRef pLongitudCadena As Integer) As String
        Dim iLongitudActual As Integer = pTexto.Length
        If iLongitudActual <= pLongitudCadena Then
            Return pTexto
        End If
        Return pTexto.Substring(0, pLongitudCadena)

    End Function

    Shared Function CompletarCadena(ByRef pCadena As String, ByRef pNumeroCaracteres As Integer, ByRef pRelleno As String, ByRef pDir As Direccion) As String
        Dim iCadena As String = Varios.CortarCadena(pCadena, pNumeroCaracteres)
        Dim iNroCaracteres As Integer = iCadena.Length
        If iNroCaracteres < pNumeroCaracteres Then
            If pDir = Direccion.Derecha Then
                iCadena = iCadena.PadRight(pNumeroCaracteres, CType(pRelleno, Char))
            Else
                iCadena = iCadena.PadLeft(pNumeroCaracteres, CType(pRelleno, Char))
            End If
        End If
        Return iCadena

    End Function

    Shared Function ObtenerNumeroMes(ByVal pNombreMes As String) As String
        Dim iNroMes As String = ""
        Select Case pNombreMes
            Case "Apertura" : iNroMes = "00"
            Case "Enero" : iNroMes = "01"
            Case "Febrero" : iNroMes = "02"
            Case "Marzo" : iNroMes = "03"
            Case "Abril" : iNroMes = "04"
            Case "Mayo" : iNroMes = "05"
            Case "Junio" : iNroMes = "06"
            Case "Julio" : iNroMes = "07"
            Case "Agosto" : iNroMes = "08"
            Case "Setiembre" : iNroMes = "09"
            Case "Octubre" : iNroMes = "10"
            Case "Noviembre" : iNroMes = "11"
            Case "Diciembre" : iNroMes = "12"
        End Select
        Return iNroMes
    End Function

    Shared Function EsConvertibleEnDecimal(ByRef obj As Object) As Boolean
        Dim r As Object
        Try
            r = CType(obj, Decimal)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Shared Function AñoMesDiaSinBarra(ByRef fecha As DateTime) As String
        Dim ano As String = fecha.Year.ToString
        Dim mes As String = fecha.Month.ToString.PadLeft(2, CType("0", Char))
        Dim dia As String = fecha.Day.ToString.PadLeft(2, CType("0", Char))
        Return ano + mes + dia
    End Function

    Shared Function ObtenerParteNumerica(ByVal pTexto As String) As String
        pTexto = pTexto.Replace("A", "")
        pTexto = pTexto.Replace("B", "")
        pTexto = pTexto.Replace("C", "")
        pTexto = pTexto.Replace("D", "")
        Return pTexto
    End Function

    Shared Function DiaMesAño(ByRef fecha As DateTime) As String
        Dim ano As String = fecha.Year.ToString
        Dim mes As String = Varios.FormatoMes(fecha)
        Dim dia As String = Varios.FormatoDia(fecha)
        Return dia + "/" + mes + "/" + ano
    End Function

    Shared Function NumeroFormatoTxt(ByVal pMonto As Decimal, ByVal pRelleno As String, ByVal pLongitudFinal As Integer) As String
        Dim iMonto As String = pMonto.ToString
        iMonto = iMonto.Replace(".", "")
        iMonto = Varios.CompletarCadena(iMonto, pLongitudFinal, pRelleno, Varios.Direccion.Izquierda)
        Return iMonto
    End Function

    Shared Function AñoMesDia(ByRef fecha As DateTime) As String
        '/
        Dim fs As String
        'dandole el formato
        Dim año, mes, dia As String
        año = fecha.Year.ToString
        mes = fecha.Month.ToString.PadLeft(2, CType("0", Char))
        dia = fecha.Day.ToString.PadLeft(2, CType("0", Char))
        fs = año + "/" + mes + "/" + dia
        Return fs
        '/
    End Function

    Shared Function AñoMesDia(ByRef fecha As String) As String
        '/
        Dim fs As String
        'Caso si es espacio en blanco
        If fecha = "" Then
            Return ""
        Else
            'Preguntamos si el valor de fecha se puede convertir en datetime
            If Varios.EnDateTime(fecha) = True Then
                Dim fd As DateTime = CType(fecha, DateTime)
                fs = Varios.AñoMesDia(fd)
                Return fs
            Else
                Return Varios.AñoMesDia(Today)
            End If
        End If
        '/
    End Function

    Shared Function EnDateTime(ByRef obj As Object) As Boolean
        '/
        Dim r As Object
        Try
            r = CType(obj, DateTime)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Clase : EsConvertible / Funcion : EnDateTime")
            Return False
        End Try
        '/
    End Function

    Shared Function EnDecimal(ByRef obj As Object) As Boolean
        '/
        Dim r As Object
        Try
            r = CType(obj, Decimal)
            Return True
        Catch ex As Exception
            Return False
        End Try
        '/
    End Function

#End Region

#Region "Enumeraciones"
    Public Enum Direccion
        Izquierda = 0
        Derecha
    End Enum



#End Region
End Class
