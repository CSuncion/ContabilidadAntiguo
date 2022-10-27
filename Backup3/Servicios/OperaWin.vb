Imports Entidad
Imports Negocio
Public Class OperaWin
    Public txt1 As New TextBox
    Public txt2 As New TextBox
    Public txt3 As New TextBox
    Public txt4 As New TextBox
    Public txt5 As New TextBox
    Public txt6 As New TextBox
    Public txt7 As New TextBox
    Public txt8 As New TextBox
    Public Condicion As String

    Public obj, entpar As New SuperEntidad
    Dim tab As New TablaRN
    Dim usu As New UsuarioRN
    Dim par As New ParametroRN
    Dim aux As New AuxiliarRN
    Dim cbco As New CuentaBancoRN
    Dim Pcge As New PlanCuentaGeRN
    Dim Fcon As New FormatoContableRN
    Dim emp As New EmpresaRN
    Dim ccte As New CuentaCorrienteRN

    Public Sub MostrarCodigoDescripcionDeTabla(ByRef TipoTabla As String, ByVal tabla As String, ByRef e As System.ComponentModel.CancelEventArgs)
        Dim cod As String = Me.txt1.Text.Trim
        If cod = "" Then
            Exit Sub
        Else
            obj.DatoCondicion1 = TipoTabla
            obj.DatoCondicion2 = cod
            obj = tab.buscarItemTablaExisActPorTipoTablaYCodigo(obj)
            If obj.CodigoItemTabla = "" Then
                MsgBox("El codigo " + tabla + " no existe", MsgBoxStyle.Information)
                Me.txt1.Text = ""
                Me.txt2.Text = ""
                Me.txt3.Text = ""
                Me.txt1.Focus()
                e.Cancel = True
            Else
                Me.txt1.Text = obj.CodigoItemTabla
                Me.txt2.Text = obj.NombreItemTabla
                Me.txt3.Text = obj.NumDiasItemTabla
            End If
        End If
    End Sub

    'Public Sub MostrarCodigoDescripcionDePlancuentas(ByVal tabla As String, ByRef e As System.ComponentModel.CancelEventArgs)
    '    entpar = par.buscarParametroExis(entpar)
    '    Dim cod As String = Me.txt1.Text.Trim
    '    If cod = "" Then
    '        Me.txt2.Text = ""
    '        Exit Sub
    '    Else
    '        Select Case Me.Condicion
    '            Case "Todos"
    '                obj.ClaveCuentaPcge = SuperEntidad.xCodigoEmpresa + cod
    '                obj = Pcge.buscarCuentaExisPorClave(obj)
    '            Case "CuentasAnaliticas"
    '                obj.ClaveCuentaPcge = SuperEntidad.xCodigoEmpresa + cod
    '                obj.NumeroDigitosPcge = entpar.DigitosCuentaAnalitica      ''Creaar campo del numero de digitos
    '                obj = Pcge.buscarCuentaExisPorClaveyAnalitica(obj)
    '            Case "CuentasAnaliticas42A43"
    '                obj.ClaveCuentaPcge = SuperEntidad.xCodigoEmpresa + cod
    '                obj.NumeroDigitosPcge = entpar.DigitosCuentaAnalitica      ''Creaar campo del numero de digitos
    '                obj = Pcge.buscarCuentaExisPorClaveyAnalitica42A43(obj)
    '            Case "CuentasAnaliticas42A47"
    '                obj.ClaveCuentaPcge = SuperEntidad.xCodigoEmpresa + cod
    '                obj.NumeroDigitosPcge = entpar.DigitosCuentaAnalitica      ''Creaar campo del numero de digitos
    '                obj = Pcge.buscarCuentaExisPorClaveyAnalitica42A47(obj)
    '            Case "CuentasAnaliticas12A13"
    '                obj.ClaveCuentaPcge = SuperEntidad.xCodigoEmpresa + cod
    '                obj.NumeroDigitosPcge = entpar.DigitosCuentaAnalitica      ''Creaar campo del numero de digitos
    '                obj = Pcge.buscarCuentaExisPorClaveyAnalitica12A13(obj)
    '            Case "CuentasAnaliticas70"
    '                obj.ClaveCuentaPcge = SuperEntidad.xCodigoEmpresa + cod
    '                obj.NumeroDigitosPcge = entpar.DigitosCuentaAnalitica      ''Creaar campo del numero de digitos
    '                obj = Pcge.buscarCuentaExisPorClaveyAnalitica70(obj)
    '            Case "CuentasAnaliticasNoBancarias"
    '                obj.CodigoCuentaPcge = cod
    '                obj.NumeroDigitosPcge = entpar.DigitosCuentaAnalitica
    '                obj = Pcge.buscarCuentaAnaliticaNoBancaria(obj)
    '        End Select

    '        If obj.CodigoCuentaPcge = "" Then
    '            MsgBox("El codigo " + tabla + " no existe", MsgBoxStyle.Information)
    '            Me.txt1.Text = ""
    '            Me.txt2.Text = ""
    '            Me.txt1.Focus()
    '            e.Cancel = True
    '        Else
    '            Me.txt1.Text = obj.CodigoCuentaPcge
    '            Me.txt2.Text = obj.NombreCuentaPcge
    '        End If
    '    End If
    'End Sub
    Public Sub MostrarCodigoDescripcionDePlancuentas(ByVal tabla As String, ByRef e As System.ComponentModel.CancelEventArgs)
        entpar = par.buscarParametroExis(entpar)
        Dim cod As String = Me.txt1.Text.Trim
        If cod = "" Then
            Me.txt2.Text = ""
            Exit Sub
        Else
            Select Case Me.Condicion
                Case "Todos"
                    obj.ClaveCuentaPcge = SuperEntidad.xCodigoEmpresa + cod
                    obj = Pcge.buscarCuentaExisPorClave(obj)
                Case "CuentasAnaliticas"
                    obj.ClaveCuentaPcge = SuperEntidad.xCodigoEmpresa + cod
                    obj.NumeroDigitosPcge = entpar.DigitosCuentaAnalitica      ''Creaar campo del numero de digitos
                    obj = Pcge.buscarCuentaExisPorClaveyAnalitica(obj)
                Case "CuentasAnaliticas42A43"
                    obj.ClaveCuentaPcge = SuperEntidad.xCodigoEmpresa + cod
                    obj.NumeroDigitosPcge = entpar.DigitosCuentaAnalitica      ''Creaar campo del numero de digitos
                    obj = Pcge.buscarCuentaExisPorClaveyAnalitica42A43(obj)
                Case "CuentasAnaliticas42A47"
                    obj.ClaveCuentaPcge = SuperEntidad.xCodigoEmpresa + cod
                    obj.NumeroDigitosPcge = entpar.DigitosCuentaAnalitica      ''Creaar campo del numero de digitos
                    obj = Pcge.buscarCuentaExisPorClaveyAnalitica42A47(obj)
                Case "CuentasAnaliticas12A13"
                    obj.ClaveCuentaPcge = SuperEntidad.xCodigoEmpresa + cod
                    obj.NumeroDigitosPcge = entpar.DigitosCuentaAnalitica      ''Creaar campo del numero de digitos
                    obj = Pcge.buscarCuentaExisPorClaveyAnalitica12A13(obj)
                Case "CuentasAnaliticas70"
                    obj.ClaveCuentaPcge = SuperEntidad.xCodigoEmpresa + cod
                    obj.NumeroDigitosPcge = entpar.DigitosCuentaAnalitica      ''Creaar campo del numero de digitos
                    obj = Pcge.buscarCuentaExisPorClaveyAnalitica70(obj)
                Case "CuentasAnaliticasNoBancarias"
                    obj.CodigoCuentaPcge = cod
                    obj.NumeroDigitosPcge = entpar.DigitosCuentaAnalitica
                    obj = Pcge.buscarCuentaAnaliticaNoBancaria(obj)
                Case "CuentasA2Digitos"
                    obj.ClaveCuentaPcge = SuperEntidad.xCodigoEmpresa + cod
                    obj = Pcge.buscarCuentaExisPorClave(obj)
                    If obj.NumeroDigitosPcge <> "2" Then
                        obj.CodigoCuentaPcge = ""
                    End If
            End Select

            If obj.CodigoCuentaPcge = "" Then
                MsgBox("El codigo " + tabla + " no existe", MsgBoxStyle.Information)
                Me.txt1.Text = ""
                Me.txt2.Text = ""
                Me.txt1.Focus()
                e.Cancel = True
            Else
                Me.txt1.Text = obj.CodigoCuentaPcge
                Me.txt2.Text = obj.NombreCuentaPcge
            End If
        End If
    End Sub



    Public Sub MostrarCodigoDescripcionDeAuxiliar(ByRef TipoTabla As String, ByVal tabla As String, ByRef e As System.ComponentModel.CancelEventArgs)

        Dim cod As String = Me.txt1.Text.Trim
        If cod = "" Then
            Me.txt1.Text = ""
            Me.txt2.Text = ""
            Me.txt3.Text = ""
            Me.txt4.Text = ""
            Exit Sub
        Else
            obj.TipoAuxiliar = TipoTabla
            obj.CodigoAuxiliar = cod

            Select Case TipoTabla
                Case "Cliente/ClienteProveedor"
                    obj = aux.BuscarClienteYClienteProveedor(obj)
                Case "Proveedor/ClienteProveedor"
                    obj = aux.BuscarProveedorYClienteProveedor(obj)
                Case "Proveedor/ClienteProveedorActivo"
                    obj = aux.BuscarProveedorYClienteProveedorActivo(obj)
                Case "Personal"
                    obj = aux.BuscarPersonal(obj)
                Case "ClienteProveedor"
                    obj = aux.Buscarclienteproveedor(obj)
                Case "Cliente"
                    obj = aux.BuscarCliente(obj)
                Case "Proveedor"
                    obj = aux.BuscarProveedor(obj)
                Case "Auxiliar"
                    obj = aux.BuscarAuxiliar(obj)
                Case "Todos"
                    obj = aux.BuscarAuxiliarExistenteActivo(obj)
            End Select

            'If TipoTabla = "Todos" Then
            '    obj = aux.buscarAuxiliarExisPorCodigo(obj)
            'Else
            '    '   obj.TipoAuxiliar = "4"
            '    obj = aux.buscarAuxiliarExisActXTipoYCodigo(obj)
            'End If
            If obj.CodigoAuxiliar = "" Then
                MsgBox("El codigo " + tabla + " no existe", MsgBoxStyle.Information)
                Me.txt1.Text = ""
                Me.txt2.Text = ""
                Me.txt3.Text = ""
                Me.txt4.Text = ""
                Me.txt1.Focus()
                e.Cancel = True
            Else
                Me.txt1.Text = obj.CodigoAuxiliar
                Me.txt2.Text = obj.DescripcionAuxiliar
                Me.txt3.Text = obj.DescripcionAuxiliar
                Me.txt4.Text = obj.FechaInscripcionSnpAuxiliar
            End If
        End If
    End Sub


    Public Sub MostrarCodigoDescripcionDeUsuario(ByVal tabla As String, ByRef e As System.ComponentModel.CancelEventArgs)
        Dim cod As String = Me.txt1.Text.Trim
        If cod = "" Then
            Exit Sub
        Else
            obj.DatoCondicion1 = cod
            obj = usu.buscarUsuarioExisActPorCodigo(obj)
            If obj.CodigoUsuario = "" Then
                MsgBox("El codigo " + tabla + " no existe", MsgBoxStyle.Information)
                Me.txt1.Text = ""
                Me.txt2.Text = ""
                Me.txt3.Text = ""
                Me.txt1.Focus()
                e.Cancel = True
            Else
                Me.txt1.Text = obj.CodigoUsuario
                Me.txt2.Text = obj.NombrePersonalUsuario
                'Me.txt3.Text = obj.CodigoGrupo
            End If
        End If
    End Sub


    Public Sub MostrarCodigoDescripcionDeFile(ByVal tabla As String, ByRef e As System.ComponentModel.CancelEventArgs)
        Dim cod As String = Me.txt1.Text.Trim
        If cod = "" Then
            Exit Sub
        Else
            Dim iFilRN As New FilesRN
            obj.ClaveFile = SuperEntidad.xCodigoEmpresa + cod
            obj = iFilRN.buscarFilesExisPorClave(obj)
            If obj.ClaveFile = "" Then
                MsgBox("El codigo " + tabla + " no existe", MsgBoxStyle.Information)
                Me.txt1.Text = ""
                Me.txt2.Text = ""
                Me.txt3.Text = ""
                Me.txt1.Focus()
                e.Cancel = True
            Else
                Me.txt1.Text = obj.CodigoFile
                Me.txt2.Text = obj.NombreFile

            End If
        End If
    End Sub

    Public Sub MostrarCodigoDescripcionDeCuentaBanco(ByVal tabla As String, ByRef e As System.ComponentModel.CancelEventArgs)
        Dim cod As String = Me.txt1.Text.Trim
        If cod = "" Then
            Exit Sub
        Else
            'obj.CodigoCuentaBanco = cod
            obj.ClaveCuentaBanco = SuperEntidad.xCodigoEmpresa + cod
            obj = cbco.buscarCuentaBancoExisPorCodigo(obj)
            If obj.CodigoCuentaBanco = "" Then
                MsgBox("El codigo " + tabla + " no existe", MsgBoxStyle.Information)
                Me.txt1.Text = ""
                Me.txt2.Text = ""
                Me.txt3.Text = ""
                Me.txt4.Text = ""
                Me.txt1.Focus()
                e.Cancel = True
            Else
                Me.txt1.Text = obj.CodigoCuentaBanco
                Me.txt2.Text = obj.BancoCuentaBanco
                Me.txt3.Text = obj.NumeroCuentaBanco
                Me.txt4.Text = obj.MonedaCuentaBanco
            End If
        End If
    End Sub


    Public Sub MostrarCodigoDescripcionDeCuentaBancoXMoneda(ByVal tabla As String, ByRef e As System.ComponentModel.CancelEventArgs)
        Dim cod As String = Me.txt1.Text.Trim
        If cod = "" Then
            Exit Sub
        Else
            'obj.CodigoCuentaBanco = cod
            obj.ClaveCuentaBanco = SuperEntidad.xCodigoEmpresa + cod
            Select Case obj.MonedaCuentaBanco
                Case "S/." : obj.MonedaCuentaBanco = "0"
                Case "US$" : obj.MonedaCuentaBanco = "1"
            End Select

            obj = cbco.buscarCuentaBancoExisPorCodigoXMoneda(obj)
            If obj.CodigoCuentaBanco = "" Then
                MsgBox("El codigo " + tabla + " no existe", MsgBoxStyle.Information)
                Me.txt1.Text = ""
                Me.txt2.Text = ""
                Me.txt3.Text = ""
                Me.txt4.Text = ""
                Me.txt1.Focus()
                e.Cancel = True
            Else
                Me.txt1.Text = obj.CodigoCuentaBanco
                Me.txt2.Text = obj.BancoCuentaBanco
                Me.txt3.Text = obj.NumeroCuentaBanco
                Me.txt4.Text = obj.MonedaCuentaBanco
            End If
        End If
    End Sub

    Public Sub MostrarCodigoNombrePeriodoDeEmpresa(ByVal tabla As String, ByRef e As System.ComponentModel.CancelEventArgs)
        Dim cod As String = Me.txt1.Text.Trim
        If cod = "" Then
            Exit Sub
        Else
            obj.CodigoEmpresa = cod
            obj = emp.buscarEmpresaExisPorCodigo(obj)
            If obj.CodigoEmpresa = "" Then
                MsgBox("El codigo " + tabla + " no existe", MsgBoxStyle.Information)
                Me.txt1.Text = ""
                Me.txt2.Text = ""
                Me.txt3.Text = ""
                Me.txt4.Text = ""
                Me.txt1.Focus()
                e.Cancel = True
            Else
                Me.txt1.Text = obj.CodigoEmpresa
                Me.txt2.Text = obj.RazonSocialEmpresa
                Me.txt3.Text = obj.PeriodoEmpresa
                Me.txt4.Text = obj.RucEmpresa
            End If
        End If
    End Sub

    Public Sub MostrarCodigoDescripcionFormatoContable(ByVal tabla As String, ByRef e As System.ComponentModel.CancelEventArgs)
        entpar = par.buscarParametroExis(entpar)
        Dim cod As String = Me.txt1.Text.Trim
        If cod = "" Then
            Exit Sub
        Else
            
            obj.ClaveFormatoContable = cod

            obj = Fcon.buscarFormatoContableExisPorClave(obj)
         
            If obj.ClaveFormatoContable = "" Then
                MsgBox("La Clave " + tabla + " no existe", MsgBoxStyle.Information)
                Me.txt1.Text = ""
                Me.txt2.Text = ""
                Me.txt1.Focus()
                e.Cancel = True
            Else
                Me.txt1.Text = obj.ClaveFormatoContable
                Me.txt2.Text = obj.DescripcionFormatoContable
            End If
        End If
    End Sub

    Public Sub MostrarCodigoDescripcionDeCuentaCorriente(ByVal tabla As String, ByRef e As System.ComponentModel.CancelEventArgs)
        Dim cod As String = Me.txt1.Text.Trim
        If cod = "" Then
            Exit Sub
        Else
            'obj.CodigoCuentaBanco = cod
            obj.ClaveCuentaCorriente = SuperEntidad.xCodigoEmpresa + cod
            obj = ccte.buscarCuentaCorrienteExisPorClaveCC(obj)
            If obj.ClaveCuentaCorriente = "" Then
                MsgBox("El codigo " + tabla + " no existe", MsgBoxStyle.Information)
                Me.txt1.Text = ""
                Me.txt2.Text = ""
                Me.txt3.Text = ""
                'Me.txt4.Text = ""
                Me.txt1.Focus()
                e.Cancel = True
            Else
                Me.txt1.Text = obj.TipoDocumento
                Me.txt2.Text = obj.SerieDocumento
                Me.txt3.Text = obj.NumeroDocumento
                'Me.txt4.Text = obj.FechaDocumento.ToString
            End If
        End If
    End Sub

    Public Sub MostrarCodigoDescripcionDeProyectoTodosActivos(ByVal tabla As String, ByRef e As System.ComponentModel.CancelEventArgs)
        Dim proy As New ProyectoRN
        Dim cod As String = Me.txt1.Text.Trim
        If cod = "" Then
            Me.txt1.Text = ""
            Me.txt2.Text = ""
            Me.txt3.Text = ""
            Exit Sub
        Else
            obj.DatoCondicion1 = cod
            obj = proy.buscarProyectoExisActPorCodigo(obj)
            If obj.CodigoProHijo = "" Then
                MsgBox("El codigo " + tabla + " no existe o esta desactivado", MsgBoxStyle.Information)
                Me.txt1.Text = ""
                Me.txt2.Text = ""
                Me.txt3.Text = ""
                Me.txt1.Focus()
                e.Cancel = True
            Else
                Me.txt1.Text = obj.CodigoProHijo
                Me.txt2.Text = obj.DescripcionProHijo
                Me.txt3.Text = obj.TipoProHijo
            End If
        End If
    End Sub


End Class
