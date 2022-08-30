Imports System.Text.RegularExpressions

Public Class Validar

#Region "Validando en el evento KeyPress"

    Enum Tecla
        kSoloLetraSinEspacio = 0
        kSoloLetraConEspacio
        kSoloNumeroSinEspacio
        kSoloNumeroConEspacio
        kAlfaNumericoSinEspacio
        kAlfaNumericoConEspacio
        kDecimalNegativo
        kDecimal
        kClave
        kEmail
        kNada
        kAlfaNumericoSinEspacioConGuion
        kDescripcion
        kDireccion
        kProyecto
        kTipoProyecto
        kTelefono
    End Enum


    Shared Sub kSoloLetraSinEspacio(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim t As String = e.KeyChar.ToString
        Dim er As New Regex("^[a-zA-Z—Ò·¡È…ÌÕÛ”˙⁄]+$")
        If er.IsMatch(t) Or e.KeyChar = ChrW(Keys.Back) Then
            Exit Sub
        Else
            e.Handled = True
        End If
    End Sub

    Shared Sub kSoloLetraConEspacio(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim t As String = e.KeyChar.ToString
        Dim er As New Regex("^[a-zA-Z—Ò·¡È…ÌÕÛ”˙⁄\s]+$")
        If er.IsMatch(t) Or e.KeyChar = ChrW(Keys.Back) Then
            Exit Sub
        Else
            e.Handled = True
        End If
    End Sub

    Shared Sub kSoloNumeroSinEspacio(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim t As String = e.KeyChar.ToString
        Dim er As New Regex("^[0-9]+$")
        If er.IsMatch(t) Or e.KeyChar = ChrW(Keys.Back) Then
            Exit Sub
        Else
            e.Handled = True
        End If
    End Sub

    Shared Sub kDecimalNegativo(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim t As String = e.KeyChar.ToString
        Dim er As New Regex("^[-0-9.]+$")
        If er.IsMatch(t) Or e.KeyChar = ChrW(Keys.Back) Then
            Exit Sub
        Else
            e.Handled = True
        End If
    End Sub

    Shared Sub kDecimal(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim t As String = e.KeyChar.ToString
        Dim er As New Regex("^[0-9.]+$")
        If er.IsMatch(t) Or e.KeyChar = ChrW(Keys.Back) Then
            Exit Sub
        Else
            e.Handled = True
        End If
    End Sub

    Shared Sub kSoloNumeroConEspacio(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim t As String = e.KeyChar.ToString
        Dim er As New Regex("^[0-9\s]+$")
        If er.IsMatch(t) Or e.KeyChar = ChrW(Keys.Back) Then
            Exit Sub
        Else
            e.Handled = True
        End If
    End Sub

    Shared Sub kAlfaNumericoSinEspacio(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim t As String = e.KeyChar.ToString
        Dim er As New Regex("^[\w]+$")
        If er.IsMatch(t) Or e.KeyChar = ChrW(Keys.Back) Then
            Exit Sub
        Else
            e.Handled = True
        End If
    End Sub

    Shared Sub kProyecto(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim t As String = e.KeyChar.ToString
        Dim er As New Regex("^[\w-/()\s]+$")
        If er.IsMatch(t) Or e.KeyChar = ChrW(Keys.Back) Then
            Exit Sub
        Else
            e.Handled = True
        End If
    End Sub

    Shared Sub kTipoProyecto(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim t As String = e.KeyChar.ToString
        Dim er As New Regex("^[acnxpoACNPO]$")
        If er.IsMatch(t) Or e.KeyChar = ChrW(Keys.Back) Then
            Exit Sub
        Else
            e.Handled = True
        End If
    End Sub



    Shared Sub kAlfaNumericoConEspacio(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim t As String = e.KeyChar.ToString
        Dim er As New Regex("^[\w\s]+$")
        If er.IsMatch(t) Or e.KeyChar = ChrW(Keys.Back) Then
            Exit Sub
        Else
            e.Handled = True
        End If
    End Sub

    Shared Sub kDireccion(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim t As String = e.KeyChar.ToString
        Dim er As New Regex("^[\w\.,-/#\s]+$")
        If er.IsMatch(t) Or e.KeyChar = ChrW(Keys.Back) Then
            Exit Sub
        Else
            e.Handled = True
        End If
    End Sub

    Shared Sub kDescripcion(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim t As String = e.KeyChar.ToString
        Dim er As New Regex("^[\w""'\.,-/&\s]+$")
        If er.IsMatch(t) Or e.KeyChar = ChrW(Keys.Back) Then
            Exit Sub
        Else
            e.Handled = True
        End If
    End Sub

    'Shared Sub kRucHonorario(ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    Dim t As String = e.KeyChar.ToString
    '    Dim er As New Regex("^[1][0]([0-9]){9}+$")
    '    If er.IsMatch(t) Or e.KeyChar = ChrW(Keys.Back) Then
    '        Exit Sub
    '    Else
    '        e.Handled = True
    '    End If
    'End Sub

    Shared Sub kAlfaNumericoSinEspacioConGuion(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim t As String = e.KeyChar.ToString
        Dim er As New Regex("^[\w-]+$")
        If er.IsMatch(t) Or e.KeyChar = ChrW(Keys.Back) Then
            Exit Sub
        Else
            e.Handled = True
        End If
    End Sub

    Shared Sub kClave(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim t As String = e.KeyChar.ToString
        Dim er As New Regex("^[a-zA-Z0-9@]+$")
        If er.IsMatch(t) Or e.KeyChar = ChrW(Keys.Back) Then
            Exit Sub
        Else
            e.Handled = True
        End If
    End Sub

    Shared Sub kEmail(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim t As String = e.KeyChar.ToString
        Dim er As New Regex("^[a-zA-Z0-9@_.]+$")
        If er.IsMatch(t) Or e.KeyChar = ChrW(Keys.Back) Then
            Exit Sub
        Else
            e.Handled = True
        End If
    End Sub

    Shared Sub kTelefono(ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim t As String = e.KeyChar.ToString
        Dim er As New Regex("^[0-9-()\s]+$")
        If er.IsMatch(t) Or e.KeyChar = ChrW(Keys.Back) Then
            Exit Sub
        Else
            e.Handled = True
        End If
    End Sub

#End Region

#Region "Validacion en el evento Validating"

    Enum texto
        vSoloLetrasSinEspacio = 0
        vSoloLetrasConEspacio
        vClave
        vSolonumerosConDosDecimales
        vSolonumerosConTresDecimales
        vSoloNumerosSinEspacio
        vSoloNumerosConEspacio
        vSoloAlfaNumericoConEspacio
        vSoloAlfaNumericoSinEspacio
        vNumeroDiasDeMes
        vNada
        vSoloEnteros
        vCodigoProyecto
        vTipoProyecto
        vDescripcion
        vDireccion
        vAÒoUtil
        vNumeroSemanaAno
        vRucHonorario
        vRucEmpresa
        vTelefono
        vCompletarCerosCadena
    End Enum

    Shared Function vacio(ByRef texto As String) As Boolean
        Dim t As String = texto.Trim
        If t = "" Then
            MsgBox("No se permite dejar en blanco", MsgBoxStyle.Exclamation)
            Return True
        Else
            Return False
        End If
    End Function



    Shared Sub vSoloLetrasSinEspacio(ByRef sender As Object, ByRef arg As String, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim obj As Control = CType(sender, Control)
        Dim t As String = obj.Text.Trim
        Dim er As New Regex("^[a-zA-ZÒ—·¡È…ÌÕÛ”˙⁄]+$")
        If t = "" Then
            e.Cancel = False
        Else
            If er.IsMatch(t) Then
                e.Cancel = False
            Else
                MsgBox("Solo se permite letras sin espacios en blanco/ Campo :" + arg, MsgBoxStyle.Exclamation)
                obj.Focus()
            End If
        End If
    End Sub
    Shared Sub vSoloLetrasConEspacio(ByRef sender As Object, ByRef arg As String, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim obj As Control = CType(sender, Control)
        Dim t As String = obj.Text.Trim
        Dim er As New Regex("^[a-zA-ZÒ—·¡È…ÌÕÛ”˙⁄\s]+$")
        If t = "" Then
            e.Cancel = False
        Else
            If er.IsMatch(t) Then
                e.Cancel = False
            Else
                MsgBox("Solo se permite letras con espacios en blanco/ Campo :" + arg, MsgBoxStyle.Exclamation)
                obj.Focus()
            End If
        End If
    End Sub
    Shared Sub vSoloAlfaNumericoSinEspacio(ByRef sender As Object, ByRef arg As String, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim obj As Control = CType(sender, Control)
        Dim t As String = obj.Text.Trim
        Dim er As New Regex("^[\w]+$")
        If t = "" Then
            e.Cancel = False
        Else
            If er.IsMatch(t) Then
                e.Cancel = False
            Else
                MsgBox("Solo se permite letras y numeros sin espacios en blanco/ Campo :" + arg, MsgBoxStyle.Exclamation)
                obj.Focus()
            End If
        End If
    End Sub

    Shared Sub vDescripcion(ByRef sender As Object, ByRef arg As String, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim obj As Control = CType(sender, Control)
        Dim t As String = obj.Text.Trim
        Dim er As New Regex("^[\w""'\.,-/&\s]+$")
        If t = "" Then
            e.Cancel = False
        Else
            If er.IsMatch(t) Then
                e.Cancel = False
            Else
                MsgBox("Solo se permite letras,numeros  el . y ' con espacios en blanco/ Campo :" + arg, MsgBoxStyle.Exclamation)
                obj.Focus()
            End If
        End If
    End Sub

    Shared Sub vDireccion(ByRef sender As Object, ByRef arg As String, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim obj As Control = CType(sender, Control)
        Dim t As String = obj.Text.Trim
        Dim er As New Regex("^[\w\.,-/#\s]+$")
        If t = "" Then
            e.Cancel = False
        Else
            If er.IsMatch(t) Then
                e.Cancel = False
            Else
                MsgBox("Solo se permite letras,numeros  el . y  con espacios en blanco/ Campo :" + arg, MsgBoxStyle.Exclamation)
                obj.Focus()
            End If
        End If
    End Sub

    Shared Sub vRucHonorario(ByRef sender As Object, ByRef arg As String, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim obj As Control = CType(sender, Control)
        Dim t As String = obj.Text.Trim
        Dim er As New Regex("^[1][0]([0-9]){9}$")
        If t = "" Then
            e.Cancel = False
        Else
            If er.IsMatch(t) Then
                e.Cancel = False
            Else
                MsgBox("Ruc Incorrecto/ Campo :" + arg, MsgBoxStyle.Exclamation)
                obj.Focus()
            End If
        End If
    End Sub

    Shared Sub vRucEmpresa(ByRef sender As Object, ByRef arg As String, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim obj As Control = CType(sender, Control)
        Dim t As String = obj.Text.Trim
        Dim er As New Regex("^[2][0]([0-9]){9}$")
        If t = "" Then
            e.Cancel = False
        Else
            If er.IsMatch(t) Then
                e.Cancel = False
            Else
                MsgBox("Ruc Incorrecto/ Campo :" + arg, MsgBoxStyle.Exclamation)
                obj.Focus()
            End If
        End If
    End Sub


    Shared Sub vCodigoProyecto(ByRef sender As Object, ByRef arg As String, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim obj As Control = CType(sender, Control)
        Dim t As String = obj.Text.Trim
        Dim er As New Regex("^[\w-/()\s]+$")
        If t = "" Then
            e.Cancel = False
        Else
            If er.IsMatch(t) Then
                e.Cancel = False
            Else
                MsgBox("Solo se permite alfanumero / y - / Campo :" + arg, MsgBoxStyle.Exclamation)
                obj.Focus()
            End If
        End If
    End Sub

    Shared Sub vTipoProyecto(ByRef sender As Object, ByRef arg As String, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim obj As Control = CType(sender, Control)
        Dim t As String = obj.Text.Trim
        Dim er As New Regex("^[acnxpoACNXPO]$")
        If t = "" Then
            e.Cancel = False
        Else
            If er.IsMatch(t) Then
                e.Cancel = False
            Else
                MsgBox("Solo se permite X,P,O,C,A,N Campo :" + arg, MsgBoxStyle.Exclamation)
                obj.Focus()
            End If
        End If
    End Sub

    Shared Sub vSoloAlfaNumericoConEspacio(ByRef sender As Object, ByRef arg As String, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim obj As Control = CType(sender, Control)
        Dim t As String = obj.Text.Trim
        Dim er As New Regex("^[\w\s]+$")
        If t = "" Then
            e.Cancel = False
        Else
            If er.IsMatch(t) Then
                e.Cancel = False
            Else
                MsgBox("Solo se permite letras y numeros con espacios en blanco/ Campo :" + arg, MsgBoxStyle.Exclamation)
                obj.Focus()
            End If
        End If
    End Sub

    Shared Function vClave(ByRef sender As Object, ByRef arg As String, ByVal e As System.ComponentModel.CancelEventArgs) As Boolean
        Dim obj As Control = CType(sender, Control)
        Dim t As String = obj.Text.Trim
        Dim er As New Regex("^[a-zA-ZÒ—0-9]+$")
        If t = "" Then
            e.Cancel = False
        Else
            If er.IsMatch(t) Then
                If Varios.LimiteMinMaxDeCaracteres(t, 6, 20) = False Then
                    MsgBox("Se debe ingresar como minimo 6 caracteres y como maximo 20/ Campo :" + arg, MsgBoxStyle.Exclamation)
                    obj.Focus()
                Else
                    e.Cancel = False
                End If
            Else
                MsgBox("Solo se permite letras minusculas y numeros sin espacios en blanco/ Campo :" + arg, MsgBoxStyle.Exclamation)
                obj.Focus()
            End If
        End If
    End Function

    Shared Sub vSoloNumerosConDosDecimales(ByRef sender As Object, ByRef arg As String, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim obj As Control = CType(sender, Control)
        Dim t As String = obj.Text.Trim

        'quitar comas
        t = t.Replace(",", "")
        ' Dim er As New Regex("^(-\d|\d)+($|\.?\d+$)")
        Dim er As New Regex("^-?\d+($|\.?\d+$)")
        If t = "" Then
            obj.Text = "0.00"
            e.Cancel = False
        Else
            If er.IsMatch(t) Then
                Dim s As String = Varios.numeroConDosDecimal(t)
                obj.Text = s
                e.Cancel = False
            Else
                MsgBox("Solo se permiten numeros con decimales,Utilize el punto para los decimales/ Campo :" + arg, MsgBoxStyle.Exclamation)
                obj.Text = ""
                obj.Focus()
                e.Cancel = True
            End If
        End If

    End Sub

    Shared Sub vSoloNumerosConTresDecimales(ByRef sender As Object, ByRef arg As String, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim obj As Control = CType(sender, Control)
        Dim t As String = obj.Text.Trim
        'quitar comas
        t = t.Replace(",", "")
        Dim er As New Regex("^-?\d+($|\.?\d+$)")
        If t = "" Then
            obj.Text = "0.000"
            e.Cancel = False
        Else
            If er.IsMatch(t) Then
                Dim s As String = Varios.numeroConTresDecimal(t)
                obj.Text = s
                e.Cancel = False
            Else
                MsgBox("Solo se permiten numeros con decimales,Utilize el punto para los decimales/ Campo :" + arg, MsgBoxStyle.Exclamation)
                obj.Text = ""
                obj.Focus()
                e.Cancel = True
            End If
        End If

    End Sub

    Shared Sub vNumeroDiasDeMes(ByRef sender As Object, ByRef arg As String, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim obj As Control = CType(sender, Control)
        Dim t As String = obj.Text.Trim
        Dim er As New Regex("^[0-9]+$")
        If t = "0" Then
            e.Cancel = False
            ' MsgBox("sale")
        Else
            If er.IsMatch(t) Then
                If Varios.LimiteMinMaxDeValores(t, 20, 31) = False Then
                    MsgBox("Se debe ingresar un numero entre 20 y 31/ Campo :" + arg, MsgBoxStyle.Exclamation)
                    obj.Focus()
                Else
                    obj.Text = CType(t, Integer).ToString
                    e.Cancel = False
                End If
            Else
                MsgBox("Solo se permite numeros/ Campo :" + arg, MsgBoxStyle.Exclamation)
                obj.Focus()
            End If
        End If
    End Sub

    Shared Sub vAÒoUtil(ByRef sender As Object, ByRef arg As String, ByVal e As System.ComponentModel.CancelEventArgs)

        Dim obj As Control = CType(sender, Control)

        Dim t As String = obj.Text.Trim
        Dim er As New Regex("^[0-9]+$")
        If t = "" Then
            e.Cancel = False
        Else
            If er.IsMatch(t) Then
                If Varios.LimiteMinMaxDeValores(t, Today.Year, 3000) = False Then
                    MsgBox("Se debe ingresar desde el aÒo actual hacia delante/ Campo :" + arg, MsgBoxStyle.Exclamation)
                    obj.Focus()
                Else
                    obj.Text = CType(t, Integer).ToString
                    e.Cancel = False
                End If
            Else
                MsgBox("Solo se permite numeros/ Campo :" + arg, MsgBoxStyle.Exclamation)
                obj.Focus()
            End If
        End If
    End Sub

    Shared Sub vNumeroSemanaAno(ByRef sender As Object, ByRef arg As String, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim obj As Control = CType(sender, Control)
        Dim t As String = obj.Text.Trim
        Dim er As New Regex("^[0-9]+$")
        If t = "0" Then
            e.Cancel = False
            ' MsgBox("sale")
        Else
            If er.IsMatch(t) Then
                If Varios.LimiteMinMaxDeValores(t, 1, 54) = False Then
                    MsgBox("Se debe ingresar un numero entre 1 y 54/ Campo :" + arg, MsgBoxStyle.Exclamation)
                    obj.Focus()
                Else
                    obj.Text = CType(t, Integer).ToString
                    e.Cancel = False
                End If
            Else
                MsgBox("Solo se permite numeros/ Campo :" + arg, MsgBoxStyle.Exclamation)
                obj.Focus()
            End If
        End If
    End Sub

    Shared Sub vTelefono(ByRef sender As Object, ByRef arg As String, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim obj As Control = CType(sender, Control)
        Dim t As String = obj.Text.Trim
        Dim er As New Regex("^[0-9-()\s]+$")
        If t = "" Then
            e.Cancel = False
        Else
            If er.IsMatch(t) Then
                e.Cancel = False
            Else
                MsgBox("Telefono Incorrecto/ Campo :" + arg, MsgBoxStyle.Exclamation)
                obj.Focus()
            End If
        End If
    End Sub

    'Shared Sub vFechaUtil(ByRef sender As Object, ByRef arg As String, ByVal e As System.ComponentModel.CancelEventArgs)
    '    Dim obj As Control = CType(sender, Control)
    '    If Varios.LimiteMinMaxDeValores(t, Today.Year, 3000) = False Then
    '        MsgBox("Se debe ingresar desde el aÒo actual hacia delante/ Campo :" + arg, MsgBoxStyle.Exclamation)
    '        obj.Focus()
    '    Else
    '        obj.Text = CType(t, Integer).ToString
    '        e.Cancel = False
    '    End If
    '    'Dim obj As Control = CType(sender, Control)

    '    'Dim t As String = obj.Text.Trim
    '    'Dim er As New Regex("^[0-9]+$")
    '    'If t = "" Then
    '    '    e.Cancel = False
    '    'Else
    '    '    If er.IsMatch(t) Then
    '    '        If Varios.LimiteMinMaxDeValores(t, Today.Year, 3000) = False Then
    '    '            MsgBox("Se debe ingresar desde el aÒo actual hacia delante/ Campo :" + arg, MsgBoxStyle.Exclamation)
    '    '            obj.Focus()
    '    '        Else
    '    '            obj.Text = CType(t, Integer).ToString
    '    '            e.Cancel = False
    '    '        End If
    '    '    Else
    '    '        MsgBox("Solo se permite numeros/ Campo :" + arg, MsgBoxStyle.Exclamation)
    '    '        obj.Focus()
    '    '    End If
    '    'End If
    'End Sub

    Shared Sub vSoloNumerosSinEspacio(ByRef sender As Object, ByRef arg As String, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim obj As Control = CType(sender, Control)
        Dim t As String = obj.Text.Trim
        Dim er As New Regex("^[0-9]+$")
        If t = "" Then
            e.Cancel = False
        Else
            If er.IsMatch(t) Then
                e.Cancel = False
            Else
                MsgBox("Solo se permite numeros sin espacios en blanco/ Campo :" + arg, MsgBoxStyle.Exclamation)
                obj.Focus()
            End If
        End If
    End Sub
    Shared Sub vSoloNumerosConEspacio(ByRef sender As Object, ByRef arg As String, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim obj As Control = CType(sender, Control)
        Dim t As String = obj.Text.Trim
        Dim er As New Regex("^[0-9\s]+$")
        If t = "" Then
            e.Cancel = False
        Else
            If er.IsMatch(t) Then
                e.Cancel = False
            Else
                MsgBox("Solo se permite numeros sin espacios en blanco/ Campo :" + arg, MsgBoxStyle.Exclamation)
                obj.Focus()
            End If
        End If
    End Sub

    Shared Sub vSoloEnteros(ByRef sender As Object, ByRef arg As String, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim obj As Control = CType(sender, Control)
        Dim t As String = obj.Text.Trim
        Dim er As New Regex("^[0-9]+$")
        If t = "" Then
            e.Cancel = False
        Else
            If er.IsMatch(t) Then
                Dim s As String = CType(t, Integer).ToString
                obj.Text = s
                e.Cancel = False
            Else
                MsgBox("Solo se permite numeros enteros/ Campo :" + arg, MsgBoxStyle.Exclamation)
                obj.Text = ""
                obj.Focus()
                e.Cancel = True
            End If
        End If
    End Sub


    Shared Function FF(ByRef texto As String) As Boolean
        Dim t As String = texto.Trim
        Dim er As New Regex("^[0-9][0-9]$")
        If t = "" Then
            Return True
        Else
            If er.IsMatch(t) Then
                If t = "00" Then
                    MsgBox("No se permite este valor:00", MsgBoxStyle.Exclamation)
                    Return False
                Else
                    Return True
                End If
            Else
                MsgBox("Debe ingresar 2 numeros, ejemplo:01", MsgBoxStyle.Exclamation)
                Return False
            End If
        End If
    End Function
    Shared Function pruebita(ByRef texto As String) As Boolean
        Dim t As String = texto.Trim
        Dim er As New Regex("^\d+\.\d$")
        If t = "" Then
            Return True
        Else
            If er.IsMatch(t) Then
                Return True
            Else
                MsgBox("Solo se permiten numeros con  2 decimales", MsgBoxStyle.Exclamation)
                Return False
            End If
        End If
    End Function

    Shared Sub vCompletarCerosCadena(ByRef sender As Object, ByRef numcaracter As Integer, ByRef arg As String, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim obj As Control = CType(sender, Control)
        Dim t As String = obj.Text.Trim
        Dim er As New Regex("^[0-9]+$")

        If t = "" Then
            e.Cancel = False
        Else
            If er.IsMatch(t) Then
                obj.Text = t.PadLeft(numcaracter, CType("0", Char))
                e.Cancel = False
            End If
        End If

    End Sub

#End Region


End Class
