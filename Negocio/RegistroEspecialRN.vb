Imports Entidad
Imports Datos

Public Class RegistroEspecialRN
    Dim cam As New CamposEntidad
    Const vista As String = "VsRegistroEspecial"

    Function obtenerFileAutogeneradoManual(ByRef ent As SuperEntidad) As String
        Dim objAD As New RegContabCabeAD
        Return objAD.SpAutogenerarFileManual(ent)
    End Function

    Sub nuevoRegistroEspecial(ByRef ent As SuperEntidad)
        '//
        '/Estos Datos son por defecto cada vez que agregua un registro compras
        ent.MonedaVoucherRegContabCabe = ""
        ent.RetencionRegContabCabe = ""

        ent.Exporta = "0"
        ent.EstadoRegistro = "1"
        ent.EliminadoRegistro = "1"
        ent.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioAgrega = SuperEntidad.xNombreUsuario
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuarioModifica
        ent.ClaveRegContabCabe = ent.CodigoEmpresa + ent.PeriodoRegContabCabe + ent.CodigoOrigen + ent.CodigoFile + ent.NumeroVoucherRegContabCabe

        If ent.MonedaDocumento = "1" Or ent.MonedaDocumento = "US$" Or ent.MonedaDocumento = "2" Or ent.MonedaDocumento = "EUR" Then
            If ent.MonedaDocumento = "1" Or ent.MonedaDocumento = "US$" Then

                ent.PrecioVtaSolRegContabCabe = ent.PrecioVtaRegContabCabe * ent.VentaTipoCambio
                ent.ExoneradoSolRegContabCabe = ent.ExoneradoRegContabCabe * ent.VentaTipoCambio
                ent.IgvSolRegContabCabe = ent.IgvRegContabCabe * ent.VentaTipoCambio
                'Honorarios 
                If ent.CodigoOrigen = "6" Then
                    'retencion
                    ent.ValorVtaSolRegContabCabe = ent.ValorVtaRegContabCabe * ent.VentaTipoCambio
                    ent.IgvSolRegContabCabe = ent.ValorVtaRegContabCabe * ent.VentaTipoCambio
                Else
                    ent.ValorVtaSolRegContabCabe = ent.PrecioVtaSolRegContabCabe - ent.ExoneradoSolRegContabCabe - ent.IgvSolRegContabCabe
                End If
            Else

                ent.PrecioVtaSolRegContabCabe = ent.PrecioVtaRegContabCabe * ent.VentaEurTipoCambio
                ent.ExoneradoSolRegContabCabe = ent.ExoneradoRegContabCabe * ent.VentaEurTipoCambio
                ent.IgvSolRegContabCabe = ent.IgvRegContabCabe * ent.VentaEurTipoCambio
                'Honorarios 
                If ent.CodigoOrigen = "6" Then
                    'retencion
                    ent.ValorVtaSolRegContabCabe = ent.ValorVtaRegContabCabe * ent.VentaEurTipoCambio
                    ent.IgvSolRegContabCabe = ent.ValorVtaRegContabCabe * ent.VentaEurTipoCambio
                Else
                    ent.ValorVtaSolRegContabCabe = ent.PrecioVtaSolRegContabCabe - ent.ExoneradoSolRegContabCabe - ent.IgvSolRegContabCabe
                End If

            End If
            'ent.ValorVtaSolRegContab = ent.PrecioVtaSolRegContab - ent.ExoneradoSolRegContab - ent.IgvSolRegContab
        Else
            ent.PrecioVtaSolRegContabCabe = ent.PrecioVtaRegContabCabe
            ent.ExoneradoSolRegContabCabe = ent.ExoneradoRegContabCabe
            ent.IgvSolRegContabCabe = ent.IgvRegContabCabe
            ent.ValorVtaSolRegContabCabe = ent.ValorVtaRegContabCabe
        End If
        'cuando es nota de credito
        If ent.CodigoFile = "407" Or ent.CodigoFile = "507" Then
            ent.PrecioVtaRegContabCabe = -ent.PrecioVtaRegContabCabe
            ent.ExoneradoRegContabCabe = -ent.ExoneradoRegContabCabe
            ent.IgvRegContabCabe = -ent.IgvRegContabCabe
            ent.ValorVtaRegContabCabe = -ent.ValorVtaRegContabCabe
            ent.PrecioVtaSolRegContabCabe = -ent.PrecioVtaSolRegContabCabe
            ent.ExoneradoSolRegContabCabe = -ent.ExoneradoSolRegContabCabe
            ent.IgvSolRegContabCabe = -ent.IgvSolRegContabCabe
            ent.ValorVtaSolRegContabCabe = -ent.ValorVtaSolRegContabCabe
        End If
        'ent.AnoMesDiasPorMes = ent.AnoDiasPorMes + "/" + ent.CodigoMes
        Dim objAD As New RegistroEspecialAD
        objAD.SpNuevoRegistroEspecial(ent)
        '\\

    End Sub

    Sub modificarRegistroEspecial(ByRef ent As SuperEntidad)
        '//
        '/Vovemos a traer el usuario actual de la b.d
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuarioModifica

        If ent.MonedaDocumento = "1" Or ent.MonedaDocumento = "US$" Or ent.MonedaDocumento = "2" Or ent.MonedaDocumento = "EUR" Then
            If ent.MonedaDocumento = "1" Or ent.MonedaDocumento = "US$" Then

                ent.PrecioVtaSolRegContabCabe = ent.PrecioVtaRegContabCabe * ent.VentaTipoCambio
                ent.ExoneradoSolRegContabCabe = ent.ExoneradoRegContabCabe * ent.VentaTipoCambio
                ent.IgvSolRegContabCabe = ent.IgvRegContabCabe * ent.VentaTipoCambio
                'Honorarios 
                If ent.CodigoOrigen = "6" Then
                    'retencion
                    ent.ValorVtaSolRegContabCabe = ent.ValorVtaRegContabCabe * ent.VentaTipoCambio
                    ent.IgvSolRegContabCabe = ent.ValorVtaRegContabCabe * ent.VentaTipoCambio
                Else
                    ent.ValorVtaSolRegContabCabe = ent.PrecioVtaSolRegContabCabe - ent.ExoneradoSolRegContabCabe - ent.IgvSolRegContabCabe
                End If
            Else

                ent.PrecioVtaSolRegContabCabe = ent.PrecioVtaRegContabCabe * ent.VentaEurTipoCambio
                ent.ExoneradoSolRegContabCabe = ent.ExoneradoRegContabCabe * ent.VentaEurTipoCambio
                ent.IgvSolRegContabCabe = ent.IgvRegContabCabe * ent.VentaEurTipoCambio
                'Honorarios 
                If ent.CodigoOrigen = "6" Then
                    'retencion
                    ent.ValorVtaSolRegContabCabe = ent.ValorVtaRegContabCabe * ent.VentaEurTipoCambio
                    ent.IgvSolRegContabCabe = ent.ValorVtaRegContabCabe * ent.VentaEurTipoCambio
                Else
                    ent.ValorVtaSolRegContabCabe = ent.PrecioVtaSolRegContabCabe - ent.ExoneradoSolRegContabCabe - ent.IgvSolRegContabCabe
                End If

            End If
            'ent.ValorVtaSolRegContab = ent.PrecioVtaSolRegContab - ent.ExoneradoSolRegContab - ent.IgvSolRegContab
        Else
            ent.PrecioVtaSolRegContabCabe = ent.PrecioVtaRegContabCabe
            ent.ExoneradoSolRegContabCabe = ent.ExoneradoRegContabCabe
            ent.IgvSolRegContabCabe = ent.IgvRegContabCabe
            ent.ValorVtaSolRegContabCabe = ent.ValorVtaRegContabCabe
        End If
        'cuando es nota de credito
        If ent.CodigoFile = "407" Or ent.CodigoFile = "507" Then
            ent.PrecioVtaRegContabCabe = -ent.PrecioVtaRegContabCabe
            ent.ExoneradoRegContabCabe = -ent.ExoneradoRegContabCabe
            ent.IgvRegContabCabe = -ent.IgvRegContabCabe
            ent.ValorVtaRegContabCabe = -ent.ValorVtaRegContabCabe
            ent.PrecioVtaSolRegContabCabe = -ent.PrecioVtaSolRegContabCabe
            ent.ExoneradoSolRegContabCabe = -ent.ExoneradoSolRegContabCabe
            ent.IgvSolRegContabCabe = -ent.IgvSolRegContabCabe
            ent.ValorVtaSolRegContabCabe = -ent.ValorVtaSolRegContabCabe
        End If
        '/Vovemos a traer el usuario actual de la b.d
        ''/Mandamos a modificar la b.d
        Dim objAD As New RegistroEspecialAD
        objAD.SpModificarRegistroEspecial(ent)
        '\\
    End Sub

    Sub EliminarRegistroEspecialLog(ByRef ent As SuperEntidad)
        '//
        '/Datos por defecto
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.CodigoPersonalModifica = SuperEntidad.xCodigoPersonal
        ent.EliminadoRegistro = "0"
        '/Mandamos a modificar la b.d
        Dim objAD As New RegistroEspecialAD
        objAD.SpModificarRegistroEspecial(ent)
        '\\
    End Sub


    Sub eliminarRegistroEspecialFis(ByRef ent As SuperEntidad)
        '//
        Dim objAD As New RegistroEspecialAD
        objAD.SpEliminarRegistroEspecial(ent)
        '\\
    End Sub


    Sub anularRegistroEspecialFis(ByRef ent As SuperEntidad)
        '//
        Dim objAD As New RegistroEspecialAD
        objAD.SpEliminarRegistroEspecial(ent)
        '\\
    End Sub

    Function obtenerRegistroEspecial(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.CodOriRC
        ent.CampoCondicion2 = cam.CodEmp
        ent.DatoCondicion2 = SuperEntidad.xCodigoEmpresa
        Dim objAD As New RegistroEspecialAD
        listObj = objAD.SpObtenerRegistrosConDosCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerRegContabCabeExisXOrigenYPeriodo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.CodOriRC
        ent.DatoCondicion1 = ent.CodigoOrigen
        ent.CampoCondicion2 = cam.PeriodoRCC
        ent.DatoCondicion2 = ent.PeriodoRegContabCabe
        ent.CampoCondicion3 = cam.CodEmp
        ent.DatoCondicion3 = ent.CodigoEmpresa
        Dim objAD As New RegistroEspecialAD
        listObj = objAD.SpObtenerRegistrosConTresCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerRegContabCabeExisXOrigenFileYPeriodo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.CodOriRC
        ent.DatoCondicion1 = ent.CodigoOrigen
        ent.CampoCondicion2 = cam.PeriodoRCC
        ent.DatoCondicion2 = ent.PeriodoRegContabCabe
        ent.CampoCondicion3 = cam.CodEmp
        ent.DatoCondicion3 = ent.CodigoEmpresa
        ent.CampoCondicion4 = cam.CodFilRC
        ent.DatoCondicion4 = ent.CodigoFile
        Dim objAD As New RegistroEspecialAD
        listObj = objAD.SpObtenerRegistrosConCuatroCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerRegContabCabeExisSoloBancosXPeriodo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.PeriodoRCC
        ent.DatoCondicion1 = ent.PeriodoRegContabCabe
        ent.CampoCondicion2 = cam.CodEmp
        ent.DatoCondicion2 = ent.CodigoEmpresa
        Dim objAD As New RegistroEspecialAD
        listObj = objAD.SpObtenerRegistrosConDosCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerRegContabPorTipoYPeriodoYNoFile(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.CodOriRC
        ent.CampoCondicion2 = cam.PeriodoRCC
        ent.CampoCondicion3 = cam.CodFilRC
        Dim objAD As New RegistroEspecialAD
        listObj = objAD.SpObtenerRegistrosConDosCondicionUnaDesigualdad(ent)
        Return listObj
        '\\
    End Function

    Function obtenerRegContabPorTipoYPeriodoYFile(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.CodOriRC
        ent.CampoCondicion2 = cam.PeriodoRCC
        ent.CampoCondicion3 = cam.CodFilRC
        Dim objAD As New RegistroEspecialAD
        listObj = objAD.SpObtenerRegistrosConTresCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerRegContabEntreFechas(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.CodOriRC
        ent.CampoFecha = cam.FecVouRCC
        Dim objAD As New RegistroEspecialAD
        Return objAD.SpObtenerRegistrosContablesEntreFechas(ent)
    End Function

    Function obtenerRegContabPorEstadoYPeriodo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.EstRCC   'Por estado
        ent.CampoCondicion2 = cam.PeriodoRCC
        ent.CampoCondicion3 = cam.CodEmp
        ent.DatoCondicion3 = SuperEntidad.xCodigoEmpresa
        Dim objAD As New RegistroEspecialAD
        listObj = objAD.SpObtenerRegistrosConTresCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerRegContabCabePorPeriodo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        'ent.CampoCondicion1 = cam.CodOriRC
        ent.CampoCondicion1 = cam.PeriodoRCC
        ent.DatoCondicion1 = ent.PeriodoRegContabCabe
        ent.CampoCondicion2 = cam.CodEmp
        ent.DatoCondicion2 = SuperEntidad.xCodigoEmpresa
        Dim objAD As New RegistroEspecialAD
        listObj = objAD.SpObtenerRegistrosConDosCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerRegContabPorBancoYPeriodo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.CodCtaBco   'Por banco
        ent.DatoCondicion1 = ent.CodigoCuentaBanco
        ent.CampoCondicion2 = cam.PeriodoRCC
        ent.CampoCondicion3 = cam.CodEmp
        ent.DatoCondicion3 = SuperEntidad.xCodigoEmpresa
        Dim objAD As New RegistroEspecialAD
        listObj = objAD.SpObtenerRegistrosConTresCondicion(ent)
        Return listObj
        '\\
    End Function

    Function buscarRegContabExisPorClave(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.ClaveRCC
        ent.DatoCondicion1 = ent.ClaveRegContabCabe
        Dim objAD As New RegistroEspecialAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function ListarIngresosyEgresosXPeriodoYEmpresa(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim objAD As New RegistroEspecialAD
        Return objAD.ListarIngresosyEgresosXPeriodoYEmpresa(ent)
        '\\
    End Function

    Function ListarIngresosyEgresosXPeriodoYEmpresaYAuxiliar(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim objAD As New RegistroEspecialAD
        Return objAD.ListarIngresosyEgresosXPeriodoYEmpresaYAuxiliar(ent)
        '\\
    End Function
End Class

