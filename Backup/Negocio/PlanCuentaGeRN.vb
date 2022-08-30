Imports Entidad
Imports Datos

Public Class PlanCuentaGeRN
    Dim Cam As New CamposEntidad
    Const vista As String = "VsPlanCuentaGe"

    Function EnBlanco() As SuperEntidad
        Dim obj As New SuperEntidad
        obj.ClaveCuentaPcge = ""
        obj.CodigoCuentaPcge = ""
        obj.NombreCuentaPcge = ""
        Return obj
    End Function


    Sub nuevaCuenta(ByRef ent As SuperEntidad)
        '//
        '/Estos Datos son por defecto cada vez que agregue un nuevo usuario
        ent.FlagTipoCuentaPcge = "1"
        ent.EstadoCuenta = "1"
        ent.EstadoRegistro = "1"
        ent.EliminadoRegistro = "1"
        ent.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioAgrega = SuperEntidad.xNombreUsuario
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        ent.NumeroDigitosPcge = ent.CodigoCuentaPcge.Length.ToString
        ent.ClaveCuentaPcge = ent.CodigoEmpresa + ent.CodigoCuentaPcge

        Dim objAD As New PlanCuentaGeAD
        objAD.SpNuevoPlanCuentaGe(ent)
        '\\
    End Sub

    Sub modificarCuenta(ByRef ent As SuperEntidad)
        '//
        '/Vovemos a traer el usuario actual de la b.d
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        'ent.NumeroDigitosPcge = ent.CodigoCuentaPcge.Length.ToString
        '/Vovemos a traer el usuario actual de la b.d

        ''/Mandamos a modificar la b.d
        Dim objAD As New PlanCuentaGeAD
        objAD.SpModificarPlanCuentaGe(ent)
        '\\
    End Sub


    Sub eliminarCuentaLog(ByRef ent As SuperEntidad)
        '//
        '/Datos por defecto
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        ent.EliminadoRegistro = "0"
        '/Mandamos a modificar la b.d
        Dim objAD As New PlanCuentaGeAD
        objAD.SpModificarPlanCuentaGe(ent)
        '\\
    End Sub

    Sub eliminarCuentaFis(ByRef ent As SuperEntidad)
        '//
        '/Mandamos a modificar la b.d
        Dim objAD As New PlanCuentaGeAD
        objAD.SpEliminarPlanCuentaGe(ent)
        '\\
    End Sub

    Function obtenerCuentaExis(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.CodEmp
        ent.DatoCondicion1 = ent.CodigoEmpresa
        Dim objAD As New PlanCuentaGeAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerCuentaExisAutomaticas(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.FlaAutPcge
        ent.DatoCondicion1 = ent.FlagAutomaticaPcge
        'ent.CampoCondicion2 = Cam.CodEmp
        'ent.DatoCondicion2 = ent.CodigoEmpresa
        Dim objAD As New PlanCuentaGeAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerCuentaExisAnaliticas(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.NumDigPcge
        ent.DatoCondicion1 = ent.NumeroDigitosPcge
        ent.CampoCondicion2 = Cam.CodEmp
        ent.DatoCondicion2 = ent.CodigoEmpresa
        Dim objAD As New PlanCuentaGeAD
        listObj = objAD.SpObtenerRegistrosConDosCondicion(ent)
        Return listObj
        '\\
    End Function

    'Function obtenerCuentaExisAnaliticas42(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
    '    '//
    '    Dim listObj As New List(Of SuperEntidad)
    '    ent.Vista = vista
    '    ent.DatoEliminado = "1"
    '    ent.DatoEstado = ""
    '    ent.CampoCondicion1 = Cam.NumDigPcge
    '    ent.DatoCondicion1 = ent.NumeroDigitosPcge
    '    ent.CampoCondicion2 = Cam.CodEmp
    '    ent.DatoCondicion2 = ent.CodigoEmpresa
    '    ent.CampoCondicion3 = Cam.CodCtaPcge
    '    ent.DatoCondicion3 = ent.CodigoCuentaPcge

    '    MsgBox(ent.CampoCondicion3 + "  " + ent.DatoCondicion3)

    '    Dim objAD As New PlanCuentaGeAD
    '    listObj = objAD.SpObtenerRegistrosConTresCondicion(ent)
    '    Return listObj
    '    '\\
    'End Function

    Function obtenerCuentaExisAnaliticas42A43(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        Dim cuenta1 As String = "42"
        Dim cuenta2 As String = "44"
        listObj = Me.obtenerCuentaExisAnaliticas(ent)
        'Filtrar solo de la cuenta
        Dim listobjcta As New List(Of SuperEntidad)
        For Each obj As SuperEntidad In listObj
            If obj.CodigoCuentaPcge >= cuenta1 And obj.CodigoCuentaPcge < cuenta2 Then
                listobjcta.Add(obj)
            End If
        Next
        Return listobjcta
        '\\
    End Function

    Function obtenerCuentaExisAnaliticas42A47(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        Dim cuenta1 As String = "42"
        Dim cuenta2 As String = "48"
        listObj = Me.obtenerCuentaExisAnaliticas(ent)
        'Filtrar solo de la cuenta
        Dim listobjcta As New List(Of SuperEntidad)
        For Each obj As SuperEntidad In listObj
            If obj.CodigoCuentaPcge >= cuenta1 And obj.CodigoCuentaPcge < cuenta2 Then
                listobjcta.Add(obj)
            End If
        Next
        Return listobjcta
        '\\
    End Function


    Function obtenerCuentaExisAnaliticas12A13(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        Dim cuenta1 As String = "12"
        Dim cuenta2 As String = "14"
        listObj = Me.obtenerCuentaExisAnaliticas(ent)
        'Filtrar solo de la cuenta
        Dim listobjcta As New List(Of SuperEntidad)
        For Each obj As SuperEntidad In listObj
            If obj.CodigoCuentaPcge >= cuenta1 And obj.CodigoCuentaPcge < cuenta2 Then
                listobjcta.Add(obj)
            End If
        Next
        Return listobjcta
        '\\
    End Function


    Function obtenerCuentaExisAnaliticas70(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        Dim cuenta1 As String = "70"
        Dim cuenta2 As String = "71"
        listObj = Me.obtenerCuentaExisAnaliticas(ent)
        'Filtrar solo de la cuenta
        Dim listobjcta As New List(Of SuperEntidad)
        For Each obj As SuperEntidad In listObj
            If obj.CodigoCuentaPcge >= cuenta1 And obj.CodigoCuentaPcge < cuenta2 Then
                listobjcta.Add(obj)
            End If
        Next
        Return listobjcta
        '\\
    End Function


    Function obtenerCuentaExisPorEmpresa(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.CodEmp
        ent.DatoCondicion1 = ent.CodigoEmpresa

        Dim objAD As New PlanCuentaGeAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerCuentaExisAct(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        Dim objAD As New PlanCuentaGeAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerCuentaEli(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        Dim objAD As New PlanCuentaGeAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function buscarCuentaExisPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.CodCtaPcge
        ent.DatoCondicion1 = ent.CodigoCuentaPcge
        Dim objAD As New PlanCuentaGeAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarCuentaExisPorCodigo(ByRef ent As SuperEntidad, ByVal pLista As List(Of SuperEntidad)) As SuperEntidad
        'OBJETO RESULATDO
        Dim iCtaEN As New SuperEntidad
        iCtaEN.CodigoCuentaPcge = ""

        'BSUCAR EL OBJETO EN LA LISTA
        For Each xCta As SuperEntidad In pLista
            If xCta.CodigoCuentaPcge = ent.CodigoCuentaPcge Then
                iCtaEN.CodigoCuentaPcge = xCta.CodigoCuentaPcge
                Return iCtaEN
            End If
        Next
        Return iCtaEN
    End Function

    Function buscarCuentaExisPorClave(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaCtaPcge
        ent.DatoCondicion1 = ent.ClaveCuentaPcge
        Dim objAD As New PlanCuentaGeAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarCuentaExisPorClaveyAnalitica(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaCtaPcge
        ent.DatoCondicion1 = ent.ClaveCuentaPcge
        ent.CampoCondicion2 = Cam.NumDigPcge
        ent.DatoCondicion2 = ent.NumeroDigitosPcge '"7" 'ent.FlagAutomaticaPcge se pone 7 por es el numero de digitos
        Dim objAD As New PlanCuentaGeAD
        obj = objAD.SpBuscarRegistroConDosCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarCuentaExisPorClaveyAnalitica42A43(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad

        obj = Me.buscarCuentaExisPorClaveyAnalitica(ent)

        If obj.ClaveCuentaPcge = "" Then
            Return obj
        End If

        If obj.CodigoCuentaPcge.Substring(0, 2) = "42" Or obj.CodigoCuentaPcge.Substring(0, 2) = "43" Then
            Return obj
        Else
            Return Me.EnBlanco
        End If
        '\\
    End Function

    Function buscarCuentaExisPorClaveyAnalitica42A47(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad

        obj = Me.buscarCuentaExisPorClaveyAnalitica(ent)

        If obj.ClaveCuentaPcge = "" Then
            Return obj
        End If

        If obj.CodigoCuentaPcge.Substring(0, 2) = "42" Or obj.CodigoCuentaPcge.Substring(0, 2) = "43" Or obj.CodigoCuentaPcge.Substring(0, 2) = "47" Then
            Return obj
        Else
            Return Me.EnBlanco
        End If
        '\\
    End Function

    Function buscarCuentaExisPorClaveyAnalitica12A13(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad

        obj = Me.buscarCuentaExisPorClaveyAnalitica(ent)

        If obj.ClaveCuentaPcge = "" Then
            Return obj
        End If

        If obj.CodigoCuentaPcge.Substring(0, 2) = "12" Or obj.CodigoCuentaPcge.Substring(0, 2) = "13" Then
            Return obj
        Else
            Return Me.EnBlanco
        End If
        '\\
    End Function

    Function buscarCuentaExisPorClaveyAnalitica70(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad

        obj = Me.buscarCuentaExisPorClaveyAnalitica(ent)

        If obj.ClaveCuentaPcge = "" Then
            Return obj
        End If

        If obj.CodigoCuentaPcge.Substring(0, 2) = "70" Then
            Return obj
        Else
            Return Me.EnBlanco
        End If
        '\\
    End Function

    Function buscarCuentaExisActPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = Cam.CodCtaPcge
        Dim objAD As New PlanCuentaGeAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarCuentaEliPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.CodCtaPcge
        Dim objAD As New PlanCuentaGeAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function


    Function buscarCuentaEliPorClave(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaCtaPcge
        Dim objAD As New PlanCuentaGeAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarCuentaExisPorNombre(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.NomCtaPcge
        Dim objAD As New PlanCuentaGeAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function 'Class PlanCuentaPcgeRN

    Function existeCuentaPorCodigo(ByRef ent As SuperEntidad) As Boolean
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = ""
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaCtaPcge
        ent.DatoCondicion1 = ent.ClaveCuentaPcge

        Dim pgcAD As New PlanCuentaGeAD
        obj = pgcAD.SpBuscarRegistroConUnaCondicion(ent)
        If obj.ClaveCuentaPcge = "" Then
            Return False
        Else
            Return True
        End If
        '\\
    End Function

    Function existeCuentasEnEmpresa(ByRef ent As SuperEntidad) As Boolean
        '//
        Dim listObj As New List(Of SuperEntidad)
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.CodEmp
        ent.DatoCondicion1 = ent.CodigoEmpresa
        ent.CampoOrden = Cam.CodEmp
        Dim pgcAD As New CuentaEmpresaAD
        listObj = pgcAD.SpObtenerRegistrosConUnaCondicion(ent)
        If listObj.Count = 0 Then
            Return False
        Else
            Return True
        End If
        '\\
    End Function

    Sub eliminarCuentasPorEmpresaFis(ByRef ent As SuperEntidad)
        '//
        '/Mandamos a modificar la b.d
        Dim objAD As New CuentaEmpresaAD
        objAD.SpEliminarPlanCuentasGePorEmpresa(ent)
        '\\
    End Sub


    Function buscarCuentaAnaliticaNoBancaria(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim objAD As New PlanCuentaGeAD
        Return objAD.BuscarCuentaAnaliticaNoBancaria(ent)
        '\\
    End Function


    Function ListarCuentaAnaliticaNoBancaria(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New PlanCuentaGeAD
        Return objAD.ListarCuentasAnaliticasNoBancarias(ent)
        '\\
    End Function

    Function ListarCuentasAnaliticasParaCierreAnual(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New PlanCuentaGeAD
        Return objAD.ListarCuentasAnaliticasParaCierreAnual(ent)
        '\\
    End Function



    Function ListarCuentasAnaliticasXRango(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New PlanCuentaGeAD
        Return objAD.ListarCuentasAnaliticasXRango(ent)
        '\\
    End Function


    Function ListarCuentasDesdeNumeroDigitos(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New PlanCuentaGeAD
        Return objAD.ListarCuentasDesdeNumeroDigitos(ent)
        '\\
    End Function

    Function ListarCuentasParaAsientoCierreClase9(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New PlanCuentaGeAD
        Return objAD.ListarCuentasParaAsientoCierreClase9(ent)
        '\\
    End Function

    Function ListarCuentasParaAsientoCierreClase7(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New PlanCuentaGeAD
        Return objAD.ListarCuentasParaAsientoCierreClase7(ent)
        '\\
    End Function

End Class
