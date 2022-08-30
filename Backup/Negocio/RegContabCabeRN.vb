Imports Entidad
Imports Datos

Public Class RegContabCabeRN
    Dim cam As New CamposEntidad

    Function obtenerFileAutogeneradoManual(ByRef ent As SuperEntidad) As String
        Dim objAD As New RegContabCabeAD
        Return objAD.SpAutogenerarFileManual(ent)
    End Function

    Sub NuevoRegContabCabeMasivo(ByRef pLista As List(Of SuperEntidad))
        Dim objAD As New RegContabCabeAD
        objAD.NuevoRegContabCabeMasivo(pLista)
    End Sub

    Sub nuevoRegContabCabe(ByRef ent As SuperEntidad)
        '//
        '/Estos Datos son por defecto cada vez que agregua un registro compras
        ent.MonedaVoucherRegContabCabe = ""
        ' ent.RetencionRegContabCabe = ""

        If ent.CodigoOrigen <> "4" Then
            ent.Exporta = "0"
        End If

        ' ent.EstadoRegistro = "0" 'normal
        ent.EliminadoRegistro = "1"
        ent.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioAgrega = SuperEntidad.xNombreUsuario
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuarioModifica
        ent.ClaveRegContabCabe = ent.CodigoEmpresa + ent.PeriodoRegContabCabe + ent.CodigoOrigen + ent.CodigoFile + ent.NumeroVoucherRegContabCabe

        If ent.MonedaDocumento = "1" Or ent.MonedaDocumento = "US$" Or ent.MonedaDocumento = "2" Or ent.MonedaDocumento = "CAD" Then
            If ent.MonedaDocumento = "1" Or ent.MonedaDocumento = "US$" Then

                ent.PrecioVtaSolRegContabCabe = ent.PrecioVtaRegContabCabe * ent.VentaTipoCambio
                ent.ExoneradoSolRegContabCabe = ent.ExoneradoRegContabCabe * ent.VentaTipoCambio
                ent.IgvSolRegContabCabe = ent.IgvRegContabCabe * ent.VentaTipoCambio
                'Honorarios 
                If ent.CodigoOrigen = "6" Then
                    'retencion
                    ent.ValorVtaSolRegContabCabe = ent.ValorVtaRegContabCabe * ent.VentaTipoCambio
                    ent.IgvSolRegContabCabe = ent.IgvRegContabCabe * ent.VentaTipoCambio
                    'ent.IgvSolRegContabCabe = ent.ValorVtaRegContabCabe * ent.VentaTipoCambio
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
        Dim objAD As New RegContabCabeAD
        objAD.SpNuevoRegContabCabe(ent)
        '\\

    End Sub

    Sub nuevoespecial(ByRef ent As SuperEntidad)
        Dim objAD As New RegContabCabeAD
        objAD.SpNuevoRegContabCabe(ent)
    End Sub

    Sub modificarRegContab(ByRef ent As SuperEntidad)
        '//
        '/Vovemos a traer el usuario actual de la b.d
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuarioModifica

        If ent.MonedaDocumento = "1" Or ent.MonedaDocumento = "US$" Or ent.MonedaDocumento = "2" Or ent.MonedaDocumento = "CAD" Then
            If ent.MonedaDocumento = "1" Or ent.MonedaDocumento = "US$" Then

                ent.PrecioVtaSolRegContabCabe = ent.PrecioVtaRegContabCabe * ent.VentaTipoCambio
                ent.ExoneradoSolRegContabCabe = ent.ExoneradoRegContabCabe * ent.VentaTipoCambio
                ent.IgvSolRegContabCabe = ent.IgvRegContabCabe * ent.VentaTipoCambio
                'Honorarios 
                If ent.CodigoOrigen = "6" Then
                    'retencion
                    ent.ValorVtaSolRegContabCabe = ent.ValorVtaRegContabCabe * ent.VentaTipoCambio
                    ent.IgvSolRegContabCabe = ent.IgvRegContabCabe * ent.VentaTipoCambio
                    'ent.IgvSolRegContabCabe = ent.ValorVtaRegContabCabe * ent.VentaTipoCambio
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
                    ent.IgvSolRegContabCabe = ent.IgvRegContabCabe * ent.VentaEurTipoCambio
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
        Dim objAD As New RegContabCabeAD
        objAD.SpModificarRegContabCabe(ent)
        '\\
    End Sub

    Sub EliminarRegContabLog(ByRef ent As SuperEntidad)
        '//
        '/Datos por defecto
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.CodigoPersonalModifica = SuperEntidad.xCodigoPersonal
        ent.EliminadoRegistro = "0"
        '/Mandamos a modificar la b.d
        Dim objAD As New RegContabCabeAD
        objAD.SpModificarRegContabCabe(ent)
        '\\
    End Sub

    Sub eliminarRegContabFis(ByRef ent As SuperEntidad)
        '//
        Dim objAD As New RegContabCabeAD
        objAD.SpEliminarRegcontabCabe(ent)
        '\\
    End Sub

    Sub EliminarRegContabCabeDeCierreAnual(ByRef ent As SuperEntidad)
        '//
        Dim objAD As New RegContabCabeAD
        objAD.EliminarRegContabCabeDeCierreAnual(ent)
        '\\
    End Sub


    Sub anularRegContabFis(ByRef ent As SuperEntidad)
        '//
        Dim objAD As New RegContabCabeAD
        objAD.SpEliminarRegcontabCabe(ent)
        '\\
    End Sub

    Function obtenerRegContab(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsRegContabCabe"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.CodOriRC
        ent.CampoCondicion2 = cam.CodEmp
        ent.DatoCondicion2 = SuperEntidad.xCodigoEmpresa
        Dim objAD As New RegContabCabeAD
        listObj = objAD.SpObtenerRegistrosConDosCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerRegContabCabeExisXOrigenYPeriodo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsRegContabCabe"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.CodOriRC
        ent.DatoCondicion1 = ent.CodigoOrigen
        ent.CampoCondicion2 = cam.PeriodoRCC
        ent.DatoCondicion2 = ent.PeriodoRegContabCabe
        ent.CampoCondicion3 = cam.CodEmp
        ent.DatoCondicion3 = ent.CodigoEmpresa
        Dim objAD As New RegContabCabeAD
        listObj = objAD.SpObtenerRegistrosConTresCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerRegContabCabeExisXOrigenFileYPeriodo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsRegContabCabe"
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
        Dim objAD As New RegContabCabeAD
        listObj = objAD.SpObtenerRegistrosConCuatroCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerRegContabCabeExisSoloBancosXPeriodo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsRegContabCabe"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.PeriodoRCC
        ent.DatoCondicion1 = ent.PeriodoRegContabCabe
        ent.CampoCondicion2 = cam.CodEmp
        ent.DatoCondicion2 = ent.CodigoEmpresa
        Dim objAD As New RegContabCabeAD
        listObj = objAD.SpObtenerRegistrosConDosCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerRegContabPorTipoYPeriodoYNoFile(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsRegContabCabe"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.CodOriRC
        ent.CampoCondicion2 = cam.PeriodoRCC
        ent.CampoCondicion3 = cam.CodFilRC
        Dim objAD As New RegContabCabeAD
        listObj = objAD.SpObtenerRegistrosConDosCondicionUnaDesigualdad(ent)
        Return listObj
        '\\
    End Function

    Function obtenerRegContabPorTipoYPeriodoYFile(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsRegContabCabe"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.CodOriRC
        ent.CampoCondicion2 = cam.PeriodoRCC
        ent.CampoCondicion3 = cam.CodFilRC
        Dim objAD As New RegContabCabeAD
        listObj = objAD.SpObtenerRegistrosConTresCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerRegContabEntreFechas(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        ent.Vista = "VsRegContabCabe"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.CodOriRC
        ent.CampoFecha = cam.FecVouRCC
        Dim objAD As New RegContabCabeAD
        Return objAD.SpObtenerRegistrosContablesEntreFechas(ent)
    End Function

    Function obtenerRegContabPorEstadoYPeriodo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsRegContabCabe"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.EstRCC   'Por estado
        ent.CampoCondicion2 = cam.PeriodoRCC
        ent.CampoCondicion3 = cam.CodEmp
        ent.DatoCondicion3 = SuperEntidad.xCodigoEmpresa
        Dim objAD As New RegContabCabeAD
        listObj = objAD.SpObtenerRegistrosConTresCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerRegContabCabePorPeriodo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsRegContabCabe"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        'ent.CampoCondicion1 = cam.CodOriRC
        ent.CampoCondicion1 = cam.PeriodoRCC
        ent.DatoCondicion1 = ent.PeriodoRegContabCabe
        ent.CampoCondicion2 = cam.CodEmp
        ent.DatoCondicion2 = SuperEntidad.xCodigoEmpresa
        Dim objAD As New RegContabCabeAD
        listObj = objAD.SpObtenerRegistrosConDosCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerRegContabCabePorPeriodoParaContabilizar(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsRegContabCabe"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        'ent.CampoCondicion1 = cam.CodOriRC
        ent.CampoCondicion1 = cam.PeriodoRCC
        ent.DatoCondicion1 = ent.PeriodoRegContabCabe
        ent.CampoCondicion2 = cam.CodEmp
        ent.DatoCondicion2 = SuperEntidad.xCodigoEmpresa
        ent.CampoCondicion3 = cam.EstRegRcc
        ent.DatoCondicion3 = "0" 'normal
        Dim objAD As New RegContabCabeAD
        listObj = objAD.SpObtenerRegistrosConTresCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerRegContabCabePorPeriodoXEmpresaSinExtorno(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsRegContabCabe"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        'ent.CampoCondicion1 = cam.CodOriRC
        ent.CampoCondicion1 = cam.PeriodoRCC
        ent.DatoCondicion1 = ent.PeriodoRegContabCabe
        ent.CampoCondicion2 = cam.CodEmp
        ent.DatoCondicion2 = SuperEntidad.xCodigoEmpresa
        ent.CampoCondicion3 = cam.EstReg
        ent.DatoCondicion3 = "0" 'normal
        ent.CampoCondicion4 = cam.CodOriRC
        ent.DatoCondicion4 = ent.CodigoOrigen
        Dim objAD As New RegContabCabeAD
        listObj = objAD.SpObtenerRegistrosConCuatroCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerRegContabPorBancoYPeriodo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsRegContabCabe"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.CodCtaBco   'Por banco
        ent.DatoCondicion1 = ent.CodigoCuentaBanco
        ent.CampoCondicion2 = cam.PeriodoRCC
        ent.CampoCondicion3 = cam.CodEmp
        ent.DatoCondicion3 = SuperEntidad.xCodigoEmpresa
        Dim objAD As New RegContabCabeAD
        listObj = objAD.SpObtenerRegistrosConTresCondicion(ent)
        Return listObj
        '\\
    End Function

    Function buscarRegContabExisPorClave(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsRegContabCabe"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.ClaveRCC
        ent.DatoCondicion1 = ent.ClaveRegContabCabe
        Dim objAD As New RegContabCabeAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function ListarIngresosyEgresosXPeriodoYEmpresa(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim objAD As New RegContabCabeAD
        Return objAD.ListarIngresosyEgresosXPeriodoYEmpresa(ent)
        '\\
    End Function

    Function ListarIngresosyEgresosXPeriodoYEmpresaYEstado(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim objAD As New RegContabCabeAD
        Return objAD.ListarIngresosyEgresosXPeriodoYEmpresaYEstado(ent)
        '\\
    End Function

    Function ListarIngresosyEgresosXPeriodoYEmpresaYAuxiliar(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim objAD As New RegContabCabeAD
        Return objAD.ListarIngresosyEgresosXPeriodoYEmpresaYAuxiliar(ent)
        '\\
    End Function

    Function ListarIngresosEgresosYDiariosXPeriodoYEmpresa(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim objAD As New RegContabCabeAD
        Return objAD.ListarIngresosEgresosYDiariosXPeriodoYEmpresa(ent)
        '\\
    End Function

    Function ListarVoucherDescuadrado(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        'Dim rcd As New RegContabDetaRN
        Dim LisRc As New List(Of SuperEntidad)
        'Dim LisRd As New List(Of SuperEntidad)
        Dim lisRes As New List(Of SuperEntidad)

        Dim debe As Decimal = 0
        Dim haber As Decimal = 0

        LisRc = Me.obtenerRegContabCabePorPeriodo(ent)

        For Each xobj As SuperEntidad In LisRc
            Select Case xobj.CodigoOrigen
                Case "1", "2"
                    If xobj.SumaDebeRegContabCabe = xobj.SumaHaberRegContabCabe Then
                        If xobj.ImporteSolRegContabCabe > xobj.SumaDebeRegContabCabe Then
                            lisRes.Add(xobj)
                        End If
                    Else
                        lisRes.Add(xobj)
                    End If

                Case "3"
                    If xobj.SumaDebeRegContabCabe <> xobj.SumaHaberRegContabCabe Then
                        lisres.Add(xobj)
                    End If

                Case "4"

                    If xobj.CodigoFile = "410" Or xobj.CodigoFile = "411" Or xobj.CodigoFile = "412" Then
                        If xobj.SumaDebeRegContabCabe = xobj.SumaHaberRegContabCabe Then
                            If xobj.ImporteSolRegContabCabe <> xobj.SumaDebeRegContabCabe Then
                               lisres.Add(xobj)
                            End If

                        End If

                    End If


            End Select
        Next

        Return lisRes

    End Function

    Function ListarEgresosTransfereciaXPeriodoYEmpresa(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim objAD As New RegContabCabeAD
        Return objAD.ListarEgresosTransfereciaXPeriodoYEmpresa(ent)
        '\\
    End Function

    Function ListarXAnoEmpresa(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim objAD As New RegContabCabeAD
        Return objAD.ListarRegistrosPorAnoYEmpresa(ent)
        '\\
    End Function

    Function EsActoEstornarRegistro(ByRef pObj As SuperEntidad) As SuperEntidad
        Dim iRccEN As New SuperEntidad

        'Buscar en BD
        iRccEN.ClaveRegContabCabe = pObj.ClaveRegContabCabe
        iRccEN = Me.buscarRegContabExisPorClave(iRccEN)
        If iRccEN.ClaveRegContabCabe = String.Empty Then
            iRccEN.EsVerdad = False
            iRccEN.Mensaje = "El registro contable no existe"
            Return iRccEN
        End If

        'solo se pueden estornar los registros que tengan 
        'su estado en 0 : Normal, 1 : Estornado , 2 : Estorno
        If iRccEN.EstadoRegistro = "1" Then
            iRccEN.EsVerdad = False
            iRccEN.Mensaje = "Este es un registro estornado, No se puede realizar la operacion"
            Return iRccEN
        End If

        If iRccEN.EstadoRegistro = "2" Then
            iRccEN.EsVerdad = False
            iRccEN.Mensaje = "Este registro es un estorno, No se puede realizar la operacion"
            Return iRccEN
        End If

        If iRccEN.PeriodoRegContabCabe <> SuperEntidad.xPeriodoEmpresa Then
            iRccEN.EsVerdad = False
            iRccEN.Mensaje = "Este registro es de otro periodo distinto al actual, No se puede realizar la operacion"
            Return iRccEN
        End If

        'Si todo esta OK
        iRccEN.EsVerdad = True
        iRccEN.Mensaje = String.Empty
        Return iRccEN

    End Function

    Function EsRegistroContableCabeExistente(ByRef pObj As SuperEntidad) As SuperEntidad
        Dim iRccEN As New SuperEntidad

        'Buscar en BD
        iRccEN.ClaveRegContabCabe = pObj.ClaveRegContabCabe
        iRccEN = Me.buscarRegContabExisPorClave(iRccEN)
        If iRccEN.ClaveRegContabCabe = String.Empty Then
            iRccEN.EsVerdad = False
            iRccEN.Mensaje = "El registro contable no existe"
            Return iRccEN
        End If



        'Si todo esta OK
        iRccEN.EsVerdad = True
        iRccEN.Mensaje = String.Empty
        Return iRccEN

    End Function

    Sub EstornarRegistroContable(ByVal pRcc As SuperEntidad)
        'traemos al registro contable cabecera
        Dim iRccEN As New SuperEntidad
        iRccEN = Me.buscarRegContabExisPorClave(pRcc)

        'pasamos el registro contable a estornado
        iRccEN.EstadoRegistro = "1"
        Me.modificarRegContab(iRccEN)

        'creando el nuevo registro de estorno
        iRccEN.NumeroVoucherRegContabCabe = iRccEN.NumeroVoucherRegContabCabe + "E"
        iRccEN.ClaveRegContabCabe = iRccEN.ClaveRegContabCabe + "E"
        iRccEN.EstadoRegistro = "2"

        'caso especial para una transferencia
        If iRccEN.EstadoRegContabCabe = "T" And iRccEN.VoucherIngresoRegContabCabe <> "" Then
            iRccEN.VoucherIngresoRegContabCabe = iRccEN.VoucherIngresoRegContabCabe + "E"
        End If
        Me.nuevoespecial(iRccEN)

        'estornar el detalle
        Dim iRcdRN As New RegContabDetaRN
        iRcdRN.EstornarRegistroContableDetaDeRegContabCabe(pRcc)
    End Sub

    Function ConvertirTextoARegistroCompraCabe(ByVal pTexto As String) As SuperEntidad
        Dim iRegConCab As New SuperEntidad
        iRegConCab.Mensaje = pTexto.Substring(0, 1) 'comodin
        iRegConCab.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iRegConCab.PeriodoRegContabCabe = pTexto.Substring(1, 6).Trim
        iRegConCab.CodigoOrigen = pTexto.Substring(7, 1).Trim
        iRegConCab.CodigoFile = pTexto.Substring(8, 3).Trim
        iRegConCab.NumeroVoucherRegContabCabe = pTexto.Substring(11, 6).Substring(1).Trim
        iRegConCab.MonedaVoucherRegContabCabe = ""
        iRegConCab.DiaVoucherRegContabCabe = pTexto.Substring(17, 2).Trim
        iRegConCab.FechaVoucherRegContabCabe = CType(pTexto.Substring(17, 10), DateTime)
        iRegConCab.CodigoAuxiliar = pTexto.Substring(27, 11).Trim
        iRegConCab.ModoCompra = "Destinadas a Vtas Gravadas Excl"
        iRegConCab.TipoDocumento = pTexto.Substring(38, 2).Trim
        iRegConCab.SerieDocumento = pTexto.Substring(40, 4).Trim.PadLeft(4, CType("0", Char))
        iRegConCab.NumeroDocumento = pTexto.Substring(44, 15).Trim.PadLeft(15, CType("0", Char))
        iRegConCab.FechaDocumento = CType(pTexto.Substring(59, 10), DateTime)
        iRegConCab.FechaVencimiento = Today
        iRegConCab.MonedaDocumento = pTexto.Substring(75, 3).Trim
        iRegConCab.TipoDocumento1 = ""
        iRegConCab.SerieDocumento1 = ""
        iRegConCab.NumeroDocumento1 = ""
        iRegConCab.FechaDocumento1 = ""
        iRegConCab.MonedaDocumento1 = "0"
        iRegConCab.VentaTipoCambio = CType(pTexto.Substring(69, 6), Decimal)
        iRegConCab.VentaEurTipoCambio = 1
        iRegConCab.IgvPar = CType(pTexto.Substring(214, 8), Decimal)
        iRegConCab.ValorVtaRegContabCabe = CType(pTexto.Substring(102, 12), Decimal)
        iRegConCab.IgvRegContabCabe = CType(pTexto.Substring(114, 12), Decimal)
        iRegConCab.ExoneradoRegContabCabe = CType(pTexto.Substring(90, 12), Decimal)
        iRegConCab.PrecioVtaRegContabCabe = CType(pTexto.Substring(78, 12), Decimal)
        iRegConCab.ValorVtaSolRegContabCabe = CType(pTexto.Substring(150, 12), Decimal)
        iRegConCab.IgvSolRegContabCabe = CType(pTexto.Substring(162, 12), Decimal)
        iRegConCab.ExoneradoSolRegContabCabe = CType(pTexto.Substring(138, 12), Decimal)
        iRegConCab.PrecioVtaSolRegContabCabe = CType(pTexto.Substring(126, 12), Decimal)
        iRegConCab.GlosaRegContabCabe = pTexto.Substring(249, 40).Trim
        iRegConCab.RetencionRegContabCabe = ""
        iRegConCab.CodigoCuentaBanco = "4212101"
        iRegConCab.CodigoIngEgr = ""
        iRegConCab.ImporteRegContabCabe = 0
        iRegConCab.ImporteSolRegContabCabe = 0
        iRegConCab.DetraccionRegContabCabe = pTexto.Substring(222, 2).Trim
        iRegConCab.NumeroPapeletaRegContabCabe = pTexto.Substring(224, 15).Trim
        iRegConCab.FechaDetraccionRegContabCabe = pTexto.Substring(239, 10).Trim
        iRegConCab.CodigoModoPago = ""
        iRegConCab.CartaRegContabCabe = ""
        iRegConCab.DescripcionRegContabCabe = ""
        iRegConCab.VoucherIngresoRegContabCabe = ""
        iRegConCab.EstadoRegContabCabe = "1"
        iRegConCab.SumaHaberRegContabCabe = iRegConCab.PrecioVtaRegContabCabe
        iRegConCab.SumaDebeRegContabCabe = iRegConCab.PrecioVtaRegContabCabe
        iRegConCab.UltimoCorrelativo = ""
        iRegConCab.Exporta = "1"
        iRegConCab.EstadoRegistro = "0"
        iRegConCab.EliminadoRegistro = "1"
        iRegConCab.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
        iRegConCab.NombreUsuarioAgrega = SuperEntidad.xNombreUsuario
        iRegConCab.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        iRegConCab.NombreUsuarioModifica = SuperEntidad.xNombreUsuarioModifica
        iRegConCab.ClaveRegContabCabe += iRegConCab.CodigoEmpresa
        iRegConCab.ClaveRegContabCabe += iRegConCab.PeriodoRegContabCabe
        iRegConCab.ClaveRegContabCabe += iRegConCab.CodigoOrigen
        iRegConCab.ClaveRegContabCabe += iRegConCab.CodigoFile
        iRegConCab.ClaveRegContabCabe += iRegConCab.NumeroVoucherRegContabCabe
        Return iRegConCab
    End Function

    Function ConvertirTextoARegistroVentaCabe(ByVal pTexto As String, ByVal wPeriodo As String, ByVal wCuenta As String) As SuperEntidad
        Dim iRegConCab As New SuperEntidad
        iRegConCab.Mensaje = pTexto.Substring(0, 1) 'comodin
        iRegConCab.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        iRegConCab.PeriodoRegContabCabe = pTexto.Substring(11, 4).Trim + pTexto.Substring(9, 2)
        iRegConCab.CodigoOrigen = "5" 'pTexto.Substring(0, 1) ' "5" 'pTexto.Substring(7, 1).Trim
        iRegConCab.CodigoFile = "511" 'iRegConCab.CodigoOrigen + pTexto.Substring(15, 2).Trim
        iRegConCab.NumeroVoucherRegContabCabe = pTexto.Substring(1, 6).Substring(1).Trim
        iRegConCab.UltimoCorrelativo = "0003"
        iRegConCab.MonedaVoucherRegContabCabe = pTexto.Substring(17, 1) '""
        iRegConCab.DiaVoucherRegContabCabe = pTexto.Substring(7, 2).Trim
        iRegConCab.FechaVoucherRegContabCabe = CType(pTexto.Substring(7, 2) + "/" + pTexto.Substring(9, 2) + "/" + pTexto.Substring(11, 4), DateTime)
        iRegConCab.CodigoAuxiliar = pTexto.Substring(81, 11).Trim
        iRegConCab.TipoDocumento = pTexto.Substring(92, 2).Trim
        iRegConCab.SerieDocumento = pTexto.Substring(94, 4).Trim.PadLeft(4, CType("0", Char))
        iRegConCab.NumeroDocumento = pTexto.Substring(98, 15).Trim.PadLeft(15, CType("0", Char))
        iRegConCab.FechaDocumento = CType(pTexto.Substring(113, 2) + "/" + pTexto.Substring(115, 2) + "/" + pTexto.Substring(117, 4), DateTime)
        iRegConCab.FechaVencimiento = iRegConCab.FechaDocumento
        iRegConCab.MonedaDocumento = pTexto.Substring(17, 1).Trim
        If iRegConCab.MonedaDocumento = "1" Then
            iRegConCab.MonedaDocumento = "0"
        End If
        iRegConCab.TipoDocumento1 = ""
        iRegConCab.SerieDocumento1 = ""
        iRegConCab.NumeroDocumento1 = ""
        iRegConCab.FechaDocumento1 = ""
        iRegConCab.MonedaDocumento1 = "0"
        iRegConCab.VentaTipoCambio = CType(pTexto.Substring(18, 6), Decimal)
        iRegConCab.VentaEurTipoCambio = 1
        iRegConCab.IgvPar = 18 'CType(pTexto.Substring(44, 6), Decimal)
        iRegConCab.ValorVtaRegContabCabe = CType(pTexto.Substring(61, 8) + "." + pTexto.Substring(69, 2), Decimal)
        iRegConCab.IgvRegContabCabe = CType(pTexto.Substring(51, 8) + "." + pTexto.Substring(59, 2), Decimal)
        iRegConCab.ExoneradoRegContabCabe = CType(pTexto.Substring(71, 8) + "." + pTexto.Substring(79, 2), Decimal)
        iRegConCab.PrecioVtaRegContabCabe = CType(pTexto.Substring(34, 8) + "." + pTexto.Substring(42, 2), Decimal)
        If iRegConCab.VentaTipoCambio = 0.0 Then
            iRegConCab.VentaTipoCambio = 1
            iRegConCab.ValorVtaSolRegContabCabe = iRegConCab.ValorVtaRegContabCabe
            iRegConCab.IgvSolRegContabCabe = iRegConCab.IgvRegContabCabe
            iRegConCab.ExoneradoSolRegContabCabe = iRegConCab.ExoneradoRegContabCabe
            iRegConCab.PrecioVtaSolRegContabCabe = iRegConCab.PrecioVtaRegContabCabe
        Else
            iRegConCab.ValorVtaSolRegContabCabe = Math.Round(iRegConCab.ValorVtaRegContabCabe * iRegConCab.VentaTipoCambio, 2)
            iRegConCab.IgvSolRegContabCabe = Math.Round(iRegConCab.IgvRegContabCabe * iRegConCab.VentaTipoCambio, 2)
            iRegConCab.ExoneradoSolRegContabCabe = Math.Round(iRegConCab.ExoneradoRegContabCabe * iRegConCab.VentaTipoCambio, 2)
            iRegConCab.PrecioVtaSolRegContabCabe = Math.Round(iRegConCab.PrecioVtaRegContabCabe * iRegConCab.VentaTipoCambio, 2)
        End If
        iRegConCab.GlosaRegContabCabe = "Ventas Del Año y Mes " + wPeriodo
        iRegConCab.RetencionRegContabCabe = ""
        iRegConCab.CodigoCuentaBanco = wCuenta ''"700101"
        iRegConCab.ImporteRegContabCabe = 0
        iRegConCab.ImporteSolRegContabCabe = 0
        iRegConCab.DetraccionRegContabCabe = "" 'pTexto.Substring(222, 2).Trim
        iRegConCab.NumeroPapeletaRegContabCabe = "" 'pTexto.Substring(224, 15).Trim
        iRegConCab.FechaDetraccionRegContabCabe = "" 'pTexto.Substring(239, 10).Trim
        iRegConCab.CodigoModoPago = ""
        iRegConCab.CartaRegContabCabe = ""
        iRegConCab.DescripcionRegContabCabe = ""
        iRegConCab.VoucherIngresoRegContabCabe = ""
        iRegConCab.EstadoRegContabCabe = "1"
        iRegConCab.SumaHaberRegContabCabe = iRegConCab.PrecioVtaRegContabCabe
        iRegConCab.SumaDebeRegContabCabe = iRegConCab.PrecioVtaRegContabCabe
        iRegConCab.CodigoIngEgr = "" 'pTexto.Substring(0, 1)
        iRegConCab.ModoCompra = "" '"Destinadas a Vtas Gravadas Excl"
        iRegConCab.FlagDescuentoRegContabCabe = ""
        iRegConCab.CodigoAfp = ""
        iRegConCab.ImporteDescuentoRegContabCabe = 0
        iRegConCab.ImporteSolRegContabCabe = 0
        iRegConCab.DescuentoFondo = 0
        iRegConCab.DescuentoSalud = 0
        iRegConCab.DescuentoRemu = 0
        iRegConCab.Exporta = "1"
        iRegConCab.EstadoRegistro = "0"
        iRegConCab.EliminadoRegistro = "1"
        iRegConCab.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
        iRegConCab.NombreUsuarioAgrega = SuperEntidad.xNombreUsuario
        iRegConCab.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        iRegConCab.NombreUsuarioModifica = SuperEntidad.xNombreUsuarioModifica
        iRegConCab.ClaveRegContabCabe += iRegConCab.CodigoEmpresa
        iRegConCab.ClaveRegContabCabe += iRegConCab.PeriodoRegContabCabe
        iRegConCab.ClaveRegContabCabe += iRegConCab.CodigoOrigen
        iRegConCab.ClaveRegContabCabe += iRegConCab.CodigoFile
        iRegConCab.ClaveRegContabCabe += iRegConCab.NumeroVoucherRegContabCabe
        If iRegConCab.PrecioVtaRegContabCabe = 0 Then
            iRegConCab.GlosaRegContabCabe = "ANULADO"
        End If
        'If iRegConCab.NumeroVoucherRegContabCabe >= "00530" Then
        '    MsgBox(iRegConCab.ClaveRegContabCabe + " - " + iRegConCab.ValorVtaSolRegContabCabe.ToString + " - " + iRegConCab.IgvSolRegContabCabe.ToString + " -" + iRegConCab.PrecioVtaSolRegContabCabe.ToString + " --  " + iRegConCab.FechaVoucherRegContabCabe.ToShortDateString + "  --  " + iRegConCab.DiaVoucherRegContabCabe, MsgBoxStyle.DefaultButton1, "Data Cabe")
        'End If

        Return iRegConCab
    End Function


    Function ListarMovimientoXEmpresaXPeriodoYAuxiliar(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim objAD As New RegContabCabeAD
        Return objAD.ListarMovimientoXEmpresaXPeriodoYAuxiliar(ent)
        '\\
    End Function

    Function obtenerRegContabTodos(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsRegContabCabe"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        Dim objAD As New RegContabCabeAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function ListarRegistroComprasEntreFechas(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim objAD As New RegContabCabeAD
        Return objAD.ListarRegistroComprasEntreFechas(ent)
        '\\
    End Function

    Function BuscarRegContabCabeXDoc(ByRef ent As SuperEntidad) As SuperEntidad
        Dim objAD As New RegContabCabeAD
        Return objAD.BuscarRegContabCabeXDoc(ent)
    End Function

    Function BuscarRegContabCabeXDocVta(ByRef ent As SuperEntidad) As SuperEntidad
        Dim objAD As New RegContabCabeAD
        Return objAD.BuscarRegContabCabeXDocVta(ent)
    End Function


    Function ListarRegistroContableCabeceraXPeriodoXOrigenSinEstornar(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim objAD As New RegContabCabeAD
        Return objAD.ListarRegistroContableCabeceraXPeriodoXOrigenSinEstornar(ent)
        '\\
    End Function

    Function ListarRegContabEntreFechasYEmpresa(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim objAD As New RegContabCabeAD
        Return objAD.ListarRegContabEntreFechasYEmpresa(ent)
        '\\
    End Function

    Function EsNumeroVoucherExistente(ByRef ent As SuperEntidad) As SuperEntidad
        Dim iRcc As New SuperEntidad
        Dim objAD As New RegContabCabeAD
        Return objAD.BuscarRegContabCabeXDoc(ent)
    End Function

    Function ListarDiarios395ParaExportar(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim objAD As New RegContabCabeAD
        Return objAD.ListarDiarios395ParaExportar(ent)
        '\\
    End Function

    Function ListarRegistrosCabeceraParaLibroCajayBanco(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim objAD As New RegContabCabeAD
        Return objAD.ListarRegistrosCabeceraParaLibroCajayBanco(ent)
        '\\
    End Function

    Function ListarRegistrosCabeceraParaLibroCajayBancoXCuenta(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim objAD As New RegContabCabeAD
        Return objAD.ListarRegistrosCabeceraParaLibroCajayBancoXCuenta(ent)
        '\\
    End Function

    Function ObtenerDescuentoHonorario(ByVal ent As SuperEntidad) As SuperEntidad
        'OBJETO RESULTADO
        Dim iRes As New SuperEntidad

        'PRIMERO VER SI APLICA DESCUENTO PÒR SU FLAG
        If ent.FlagDescuentoRegContabCabe = "NO" Then Return iRes

        'VER SI EL MONTO ES CERO
        If ent.PrecioVtaRegContabCabe = 0 Then Return iRes

        'SI NO HAY CODIGO AUXILIAR
        If ent.CodigoAuxiliar = "" Then Return iRes

        'OBTENER MONTO Y DESCUENTO ACUMULADO DEL PROVEEDOR ACTUAL
        'SOLO EN EL PERIODO DE PROCESO Y SOLO RECIBOS POR HONORARIOS
        Dim iRch As SuperEntidad = Me.ObtenerMontoYDescuentosEnSolesXProveedor(ent)

        'SUMAR CON EL NUEVO REGISTRO O EL REGISTRO MODIFICADO
        Dim iMontoTotal As Decimal = iRch.PrecioVtaRegContabCabe
        If ent.MonedaDocumento = "US$" Then
            iMontoTotal += ent.PrecioVtaRegContabCabe * ent.VentaTipoCambio
        Else
            iMontoTotal += ent.PrecioVtaRegContabCabe
        End If


        'SI EL MONTO ES INFERIOR AL 750 NO HAY DESCUENTO
        If iMontoTotal < 750 Then Return iRes

        'AQUI SI DEBE HABER UN DESCUENTO(CALCULOS EN S/)
        'CALCULAR EL DESCUENTO PARA EL FONDO
        Dim iDsctoFondo As Decimal = Math.Round(iMontoTotal * Me.ObtenerPorcentajeDescuentoFondoHonorario(ent, iMontoTotal), 2)
        iDsctoFondo -= iRch.DescuentoFondo

        'CALCULAR DESCUENTO SALUD Y REMU
        Dim iDsctoSalud As Decimal = 0
        Dim iDsctoRemu As Decimal = 0

        'VER SI HAY AFP
        If ent.CodigoAfp <> String.Empty Then
            Dim iAfpRN As New AfpRN
            Dim iAfpEN As New SuperEntidad
            iAfpEN.CodigoAfp = ent.CodigoAfp
            iAfpEN = iAfpRN.buscarAfpExisPorCodigo(iAfpEN)

            'PARA SALUD
            iDsctoSalud = Math.Round((iMontoTotal * iAfpEN.PorCentajeSeguroAfp) / 100, 2)
            iDsctoSalud -= iRch.DescuentoSalud

            'PARA REMUNERACION
            iDsctoRemu = Math.Round((iMontoTotal * iAfpEN.PorCentajeSobreRemuneracionAfp) / 100, 2)
            iDsctoRemu -= iRch.DescuentoRemu
        End If

        'HALLAR SU DESCUENTO SEGUN SU MONEDA
        If ent.MonedaDocumento = "US$" Then
            iRes.DescuentoFondo = Math.Round(iDsctoFondo / ent.VentaTipoCambio, 2)
            iRes.DescuentoSalud = Math.Round(iDsctoSalud / ent.VentaTipoCambio, 2)
            iRes.DescuentoRemu = Math.Round(iDsctoRemu / ent.VentaTipoCambio, 2)
        Else
            iRes.DescuentoFondo = iDsctoFondo
            iRes.DescuentoSalud = iDsctoSalud
            iRes.DescuentoRemu = iDsctoRemu
        End If
        Return iRes
    End Function

    Function ObtenerMontoYDescuentosEnSolesXProveedor(ByVal ent As SuperEntidad) As SuperEntidad
        'OBJETO DE RESULTADO
        Dim iRch As New SuperEntidad
        iRch.PrecioVtaRegContabCabe = 0
        iRch.DescuentoFondo = 0
        iRch.DescuentoSalud = 0
        iRch.DescuentoRemu = 0

        'TRAER TODOS LOS RECIBOS POR HONORARIOS DEL PROVEEDOR ACTUAL SOLO EN
        'EL PERIODO ACTUAL
        ent.CampoOrden = cam.ClaveRCC
        Dim iLisRch As List(Of SuperEntidad) = Me.ListarRegistrosCabeceraParaDescuentoHonorario(ent)

        'PARA SABER SI ES UNA ADICION O MODIFICACION DEL REGISTRO POR HONORARIOS
        'SOLO HAY QUE BER SI HAY NUMERO VOUCHER EN EL OBJETO ent QUE VIENE DE LA VENTANA
        If ent.NumeroVoucherRegContabCabe = "" Then
            'ES UNA ADICION
            For Each xObj As SuperEntidad In iLisRch
                'SEGUN MONEDA
                If xObj.MonedaDocumento = "US$" Then
                    iRch.PrecioVtaRegContabCabe += xObj.PrecioVtaRegContabCabe * xObj.VentaTipoCambio
                    iRch.DescuentoFondo += xObj.DescuentoFondo * xObj.VentaTipoCambio
                    iRch.DescuentoSalud += xObj.DescuentoSalud * xObj.VentaTipoCambio
                    iRch.DescuentoRemu += xObj.DescuentoRemu * xObj.VentaTipoCambio
                Else
                    iRch.PrecioVtaRegContabCabe += xObj.PrecioVtaRegContabCabe
                    iRch.DescuentoFondo += xObj.DescuentoFondo
                    iRch.DescuentoSalud += xObj.DescuentoSalud
                    iRch.DescuentoRemu += xObj.DescuentoRemu
                End If

            Next
        Else
            'ES UNA MODIFICACION
            For Each xObj As SuperEntidad In iLisRch
                If ent.NumeroVoucherRegContabCabe <> xObj.NumeroVoucherRegContabCabe Then
                    'SEGUN MONEDA
                    If xObj.MonedaDocumento = "US$" Then
                        iRch.PrecioVtaRegContabCabe += xObj.PrecioVtaRegContabCabe * xObj.VentaTipoCambio
                        iRch.DescuentoFondo += xObj.DescuentoFondo * xObj.VentaTipoCambio
                        iRch.DescuentoSalud += xObj.DescuentoSalud * xObj.VentaTipoCambio
                        iRch.DescuentoRemu += xObj.DescuentoRemu * xObj.VentaTipoCambio
                    Else
                        iRch.PrecioVtaRegContabCabe += xObj.PrecioVtaRegContabCabe
                        iRch.DescuentoFondo += xObj.DescuentoFondo
                        iRch.DescuentoSalud += xObj.DescuentoSalud
                        iRch.DescuentoRemu += xObj.DescuentoRemu
                    End If
                End If
            Next
        End If
        Return iRch
    End Function

    Function ObtenerPorcentajeDescuentoFondoHonorario(ByVal ent As SuperEntidad, ByVal pMontoTotal As Decimal) As Decimal
        'OBJETO RESULTADO
        Dim iPor As Decimal = 0

        'TRAER AL OBJETO PARAMETRO
        Dim iParRN As New ParametroRN
        Dim iParEN As New SuperEntidad
        iParEN = iParRN.buscarParametroExis(iParEN)

        'OBTENER EL AÑO DEL PERIODO
        Dim iAño As String = ent.PeriodoRegContabCabe.Substring(0, 4)

        'SEGUN AFP SNP
        Select Case ent.FlagDescuentoRegContabCabe
            Case "A.F.P."
                'VER EL AÑO DEL PERIODO
                If iAño <= "2014" Then
                    'VER EL MONTO TOTAL DE TODOS LOS HONORARIOS EN ESTE PERIODO
                    If pMontoTotal >= 750 And pMontoTotal <= 1125 Then
                        iPor = iParEN.PorcentajeDsctoAfp2014
                    Else
                        iPor = iParEN.PorcentajeDsctoAfp2016
                    End If
                    'Se adiciono ultimo
                    '   iPor = iParEN.PorcentajeDsctoAfp2014
                Else
                    If iAño = "2015" Then
                        'VER EL MONTO TOTAL DE TODOS LOS HONORARIOS EN ESTE PERIODO
                        If pMontoTotal >= 750 And pMontoTotal <= 1125 Then
                            iPor = iParEN.PorcentajeDsctoAfp2015
                        Else
                            iPor = iParEN.PorcentajeDsctoAfp2016
                        End If
                    Else
                        iPor = iParEN.PorcentajeDsctoAfp2016
                    End If
                End If

            Case "S.N.P."
                'SI LA FECJHA DE INSCRIPCION ES BLANCO EL PORCENTAJE ES CERO 0
                If ent.FechaInscripcionSnpAuxiliar = String.Empty Then
                    iPor = 0
                Else
                    'COMPARAR CON LA FECHA DE INSCRIPCION DEL AUXILIAR
                    If ent.FechaInscripcionSnpAuxiliar < "2013/07/31" Then
                        iPor = iParEN.PorcentajeDsctoSnp2016
                    Else
                        'VER EL AÑO DEL PERIODO
                        If iAño <= "2014" Then
                            'VER EL MONTO TOTAL DE TODOS LOS HONORARIOS EN ESTE PERIODO
                            If pMontoTotal >= 750 And pMontoTotal <= 1125 Then
                                iPor = iParEN.PorcentajeDsctoSnp2014
                            Else
                                iPor = iParEN.PorcentajeDsctoSnp2016
                            End If
                        Else
                            If iAño = "2015" Then
                                'VER EL MONTO TOTAL DE TODOS LOS HONORARIOS EN ESTE PERIODO
                                If pMontoTotal >= 750 And pMontoTotal <= 1125 Then
                                    iPor = iParEN.PorcentajeDsctoSnp2015
                                Else
                                    iPor = iParEN.PorcentajeDsctoSnp2016
                                End If
                            Else
                                iPor = iParEN.PorcentajeDsctoSnp2016
                            End If
                        End If
                    End If
                End If
        End Select
        Return iPor / 100
    End Function

    Function ListarRegistrosCabeceraParaDescuentoHonorario(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim objAD As New RegContabCabeAD
        Return objAD.ListarRegistrosCabeceraParaDescuentoHonorario(ent)
        '\\
    End Function

    Function ListarRegistroContableCabeceraParaDao(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim objAD As New RegContabCabeAD
        Return objAD.ListarRegistroContableCabeceraParaDao(ent)
        '\\
    End Function


    Function ListarParaDao(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim iLisDetMov As New List(Of SuperEntidad)
        iLisDetMov = Me.ListarRegistroContableCabeceraParaDao(ent)


        Dim iLisRes As New List(Of SuperEntidad)

        Dim iClave As String = String.Empty
        'OBJETO DE LA CUENTA DE 4 DIGITOS
        Dim iIndiceFila As Integer = -1

        For Each xobj As SuperEntidad In iLisDetMov
            If iClave <> xobj.CodigoAuxiliar Then
                Dim iObj As New SuperEntidad
                iObj.CodigoAuxiliar = xobj.CodigoAuxiliar
                iObj.TipoDocumentoAuxiliar = xobj.TipoDocumentoAuxiliar
                iObj.DescripcionAuxiliar = xobj.DescripcionAuxiliar
                iObj.ApellidoPaternoAuxiliar = xobj.ApellidoPaternoAuxiliar
                iObj.ApellidoMaternoAuxiliar = xobj.ApellidoMaternoAuxiliar
                iObj.PrimerNombreAuxiliar = xobj.PrimerNombreAuxiliar
                iObj.SegundoNombreAuxiliar = xobj.SegundoNombreAuxiliar
                If xobj.CodigoFile = "407" Or xobj.CodigoFile = "507" Then
                    iObj.ValorVtaSolRegContabCabe = xobj.ValorVtaSolRegContabCabe    ''* (-1)
                    iObj.ExoneradoSolRegContabCabe = xobj.ExoneradoSolRegContabCabe  ''* (-1)
                Else
                    iObj.ValorVtaSolRegContabCabe = xobj.ValorVtaSolRegContabCabe
                    iObj.ExoneradoSolRegContabCabe = xobj.ExoneradoSolRegContabCabe
                End If

                iObj.IgvSolRegContabCabe = xobj.IgvSolRegContabCabe

                iObj.PrecioVtaSolRegContabCabe = xobj.PrecioVtaSolRegContabCabe
                If xobj.MonedaDocumento = "US$" Then
                    iObj.PrecioVtaRegContabCabe = xobj.PrecioVtaRegContabCabe  'Dolares
                End If
                iObj.ValorVtaRegContabCabe = iObj.ValorVtaSolRegContabCabe + iObj.ExoneradoSolRegContabCabe

                iLisRes.Add(iObj)
                iClave = xobj.CodigoAuxiliar
                iIndiceFila += 1
            Else
                If xobj.CodigoFile = "407" Or xobj.CodigoFile = "507" Then
                    iLisRes(iIndiceFila).ValorVtaSolRegContabCabe += xobj.ValorVtaSolRegContabCabe   ''* (-1)
                    iLisRes(iIndiceFila).ExoneradoSolRegContabCabe += xobj.ExoneradoSolRegContabCabe ''* (-1)
                Else
                    iLisRes(iIndiceFila).ValorVtaSolRegContabCabe += xobj.ValorVtaSolRegContabCabe
                    iLisRes(iIndiceFila).ExoneradoSolRegContabCabe += xobj.ExoneradoSolRegContabCabe
                End If

                iLisRes(iIndiceFila).IgvSolRegContabCabe += xobj.IgvSolRegContabCabe

                iLisRes(iIndiceFila).PrecioVtaSolRegContabCabe += xobj.PrecioVtaSolRegContabCabe
                If xobj.MonedaDocumento = "US$" Then
                    iLisRes(iIndiceFila).PrecioVtaRegContabCabe += xobj.PrecioVtaRegContabCabe  'Dolares
                End If
                iLisRes(iIndiceFila).ValorVtaRegContabCabe = iLisRes(iIndiceFila).ValorVtaSolRegContabCabe + iLisRes(iIndiceFila).ExoneradoSolRegContabCabe
            End If
        Next
        Return iLisRes

    End Function
    Function ListarNotasCreditoParaDiferenciaCambio(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim objAD As New RegContabCabeAD
        Return objAD.ListarNotasCreditoParaDiferenciaCambio(ent)
        '\\
    End Function

    Function ListarComprasNacionalesPle(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        'Lista re4sultado
        Dim iLisRes As New List(Of SuperEntidad)

        'Traer todo el resgistro de compras
        Dim iLisRegCom As List(Of SuperEntidad) = Me.obtenerRegContabCabeExisXOrigenYPeriodo(ent)

        'Recorrer cada objeto
        For Each xRegCom As SuperEntidad In iLisRegCom
            If xRegCom.TipoDocumento <> "00" And xRegCom.TipoDocumento <> "46" And xRegCom.TipoDocumento <> "51" And xRegCom.TipoDocumento <> "52" And xRegCom.TipoDocumento <> "53" And xRegCom.TipoDocumento <> "91" And xRegCom.TipoDocumento <> "97" And xRegCom.TipoDocumento <> "98" Then
                iLisRes.Add(xRegCom)
            End If
        Next
        Return iLisRes
    End Function

    Shared Function ObtenerPrimerPagoDocumento(ByVal pDocumentoCompra As SuperEntidad, ByVal pListaPagos As List(Of SuperEntidad)) As SuperEntidad
        'objeto resultado
        Dim iRccEN As New SuperEntidad

        'recorre cada objeto
        For Each xRcc As SuperEntidad In pListaPagos
            If pDocumentoCompra.ClaveDocumentoCuentaCorriente = xRcc.CodigoAuxiliar + xRcc.TipoDocumento + xRcc.SerieDocumento + xRcc.NumeroDocumento Then
                iRccEN = xRcc
                Return iRccEN
            End If
        Next
        Return iRccEN
    End Function

    Function ListarComprasNoDomiciliariasPle(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        'Lista re4sultado
        Dim iLisRes As New List(Of SuperEntidad)

        'Traer todo el resgistro de compras
        Dim iLisRegCom As List(Of SuperEntidad) = Me.obtenerRegContabCabeExisXOrigenYPeriodo(ent)

        'Recorrer cada objeto
        For Each xRegCom As SuperEntidad In iLisRegCom
            If xRegCom.TipoDocumento = "00" Or xRegCom.TipoDocumento = "46" Or xRegCom.TipoDocumento = "51" Or xRegCom.TipoDocumento = "52" Or xRegCom.TipoDocumento = "53" Or xRegCom.TipoDocumento = "91" Or xRegCom.TipoDocumento = "97" Or xRegCom.TipoDocumento = "98" Then
                iLisRes.Add(xRegCom)
            End If
        Next
        Return iLisRes

    End Function

    Function ListarRegistrosCabeceraXOrigenYRangoFechaVoucher(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim objAD As New RegContabCabeAD
        Return objAD.ListarRegistrosCabeceraXOrigenYRangoFechaVoucher(ent)
        '\\
    End Function

    Sub EliminarRegContabCabePeriodoOrigenYFile(ByRef ent As SuperEntidad)
        '//
        Dim objAD As New RegContabCabeAD
        objAD.EliminarRegContabCabePeriodoOrigenYFile(ent)
        '\\
    End Sub

    Function BuscarRegContabCabeXDocSinAuxiliar(ByRef ent As SuperEntidad) As SuperEntidad
        Dim objAD As New RegContabCabeAD
        Return objAD.BuscarRegContabCabeXDocSinAuxiliar(ent)
    End Function

    Function BuscarRegContabCabeXClave(ByRef ent As SuperEntidad) As SuperEntidad
        Dim objAD As New RegContabCabeAD
        Return objAD.BuscarRegContabCabeXClave(ent)
    End Function


End Class

