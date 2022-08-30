Imports Entidad
Imports Datos

Public Class PlanDeCuentasRN
    Dim Cam As New CamposEntidad
    Const vista As String = "VsPlanDeCuentas"


    Sub nuevaPlanDeCuentas(ByRef ent As SuperEntidad)
        '//
        '/Estos Datos son por defecto cada vez que agregue un nuevo usuario
        'ent.FlagTipoCuentaPcge = "1"
        ent.EstadoPlanDeCuentas = "1"
        ent.EstadoRegistro = "1"
        ent.EliminadoRegistro = "1"
        ent.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioAgrega = SuperEntidad.xNombreUsuario
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        ent.NumeroDigitosPcge = ent.CodigoCuentaPcge.Length.ToString
        Dim objAD As New PlanDeCuentasAD
        objAD.SpNuevoPlanDeCuentas(ent)
        '\\
    End Sub

    Sub modificarPlanDeCuentas(ByRef ent As SuperEntidad)
        '//
        '/Vovemos a traer el usuario actual de la b.d
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        ent.NumeroDigitosPcge = ent.CodigoCuentaPcge.Length.ToString
        '/Vovemos a traer el usuario actual de la b.d

        ''/Mandamos a modificar la b.d
        Dim objAD As New PlanDeCuentasAD
        objAD.SpModificarPlanDeCuentas(ent)
        '\\
    End Sub

    Sub eliminarplanDeCuentasLog(ByRef ent As SuperEntidad)
        '//
        '/Datos por defecto
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        ent.EliminadoRegistro = "0"
        '/Mandamos a modificar la b.d
        Dim objAD As New PlanDeCuentasAD
        objAD.SpModificarPlanDeCuentas(ent)
        '\\
    End Sub

    Sub eliminarPlanDeCuentasFis(ByRef ent As SuperEntidad)
        '//
        '/Mandamos a modificar la b.d
        Dim objAD As New PlanDeCuentasAD
        objAD.SpEliminarPlanDeCuentas(ent)
        '\\
    End Sub

    Function ObtenerCuentasDisponiblesPorEmpresa(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        Dim objAD As New PlanDeCuentasAD
        listObj = objAD.SpCuentasDisponiblesPorEmpresa(ent)
        Return listObj
        '\\
    End Function


    Function obtenerPlanDeCuentasExis(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        Dim objAD As New PlanDeCuentasAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    'Function obtenerCuentaExisAutomaticas(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
    '    '//
    '    Dim listObj As New List(Of SuperEntidad)
    '    ent.Vista = vista
    '    ent.DatoEliminado = "1"
    '    ent.DatoEstado = ""
    '    ent.CampoCondicion1 = Cam.FlaAutPcge
    '    ent.DatoCondicion1 = ent.FlagAutomaticaPcge
    '    Dim objAD As New PlanCuentaGeAD
    '    listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
    '    Return listObj
    '    '\\
    'End Function

    Function obtenerPlanDeCuentasExisXEmpresa(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.CodEmp
        ent.DatoCondicion1 = ent.CodigoEmpresa
        Dim objAD As New PlanDeCuentasAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerPlanDeCuentasExisAct(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        Dim objAD As New PlanDeCuentasAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerplanDeCuentasEli(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        Dim objAD As New PlanDeCuentasAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function buscarPlanDeCuentasExisPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.CodCtaPcge
        ent.DatoCondicion1 = ent.CodigoCuentaPcge
        Dim objAD As New PlanDeCuentasAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarPlanDeCuentasExisPorCodigoyAnalitica(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.CodCtaPcge
        ent.DatoCondicion1 = ent.CodigoCuentaPcge
        ent.CampoCondicion2 = Cam.NumDigPcge
        ent.DatoCondicion2 = "7" 'ent.FlagAutomaticaPcge se pone 7 por es el numero de digitos

        Dim objAD As New PlanDeCuentasAD
        obj = objAD.SpBuscarRegistroConDosCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarPlanDeCuentasExisActPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = Cam.CodCtaPcge
        Dim objAD As New PlanDeCuentasAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarPlanDeCuentasEliPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.CodCtaPcge
        Dim objAD As New PlanDeCuentasAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarplanDeCuentasExisPorNombre(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.NomCtaPcge
        Dim objAD As New PlanDeCuentasAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function 'Class PlanCuentaPcgeRN

    Function existePlanDeCuentasPorCodigo(ByRef ent As SuperEntidad) As Boolean
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = ""
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.CodCtaPcge
        ent.DatoCondicion1 = ent.CodigoCuentaPcge

        Dim pcemAD As New PlanDeCuentasAD
        obj = pcemAD.SpBuscarRegistroConUnaCondicion(ent)
        If obj.CodigoCuentaPcge = "" Then
            Return False
        Else
            Return True
        End If
        '\\
    End Function

End Class
