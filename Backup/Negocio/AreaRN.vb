Imports Entidad
Imports Datos

Public Class AreaRN
    Dim Cam As New CamposEntidad
    Const vista As String = "VsArea"

    Sub nuevaArea(ByRef ent As SuperEntidad)
        '//
        '/Estos Datos son por defecto cada vez que agregue un nuevo usuario
        'ent.FlagTipoCuentaPcge = "1" '/Cuando no se captura en el formulario
        'ent.EstadoCuenta = "1"
        ent.EstadoRegistro = "1"
        ent.EliminadoRegistro = "1"
        ent.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioAgrega = SuperEntidad.xNombreUsuario
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        ent.ClaveArea = ent.CodigoEmpresa + ent.CodigoArea

        Dim objAD As New AreaAD
        objAD.SpNuevoArea(ent)
        '\\
    End Sub

    Sub modificarArea(ByRef ent As SuperEntidad)
        '//
        '/Vovemos a traer el usuario actual de la b.d
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        '/Vovemos a traer el usuario actual de la b.d
        ''/Mandamos a modificar la b.d
        Dim objAD As New AreaAD
        objAD.SpModificarArea(ent)
        '\\
    End Sub

    Sub eliminarAreaLog(ByRef ent As SuperEntidad)
        '//
        '/Datos por defecto
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        ent.EliminadoRegistro = "0"
        '/Mandamos a modificar la b.d
        Dim objAD As New AreaAD
        objAD.SpModificarArea(ent)
        '\\
    End Sub

    Sub eliminarAreaFis(ByRef ent As SuperEntidad)
        '//
        '/Mandamos a modificar la b.d
        Dim objAD As New AreaAD
        objAD.SpEliminarArea(ent)
        '\\
    End Sub

    Function obtenerAreaExis(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        'ent.CampoCondicion1 = Cam.CodEmp
        'ent.DatoCondicion1 = ent.CodigoEmpresa
        Dim objAD As New AreaAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function


    Function obtenerAreaExisXEmpresa(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.CodEmp
        ent.DatoCondicion1 = ent.CodigoEmpresa
        Dim objAD As New AreaAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerAreaExisAct(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        Dim objAD As New AreaAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerAreaEli(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        Dim objAD As New AreaAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function buscarAreaExisPorClave(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaAre
        ent.DatoCondicion1 = ent.ClaveArea
        Dim objAD As New AreaAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarAreaExisPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaAre
        ent.DatoCondicion1 = ent.ClaveArea
        Dim objAD As New AreaAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarAreaActPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = Cam.ClaAre
        Dim objAD As New AreaAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarAreaEliPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaAre
        Dim objAD As New AreaAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarAreaExisPorNombre(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaAre
        Dim objAD As New AreaAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function existeAreaPorCodigo(ByRef ent As SuperEntidad) As Boolean
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = ""
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaAre
        ent.DatoCondicion1 = ent.ClaveArea    '' llenado en el formulario

        Dim AreAD As New AreaAD
        obj = AreAD.SpBuscarRegistroConUnaCondicion(ent)
        If obj.ClaveArea = "" Then
            Return False
        Else
            Return True
        End If
        '\\
    End Function


    Function ListarAreasXOrigen(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim iAreAD As New AreaAD
        Return iAreAD.ListarAreasXOrigen(ent)

    End Function

    Function EsAreaValido(ByRef pObj As SuperEntidad) As SuperEntidad
        Dim iAreEN As New SuperEntidad

        'Cuando el periodo esta en blanco
        If pObj.CodigoArea = String.Empty Then
            iAreEN.EsVerdad = True
            Return iAreEN
        End If


        'Armando clave del periodo
        iAreEN.ClaveArea += pObj.CodigoEmpresa
        iAreEN.ClaveArea += pObj.CodigoArea

        'Buscar en BD
        iAreEN = Me.buscarAreaExisPorClave(iAreEN)
        If iAreEN.ClaveArea = String.Empty Then
            iAreEN.EsVerdad = False
            iAreEN.Mensaje = "El Area que digitaste no existe"
            Return iAreEN
        End If

        If iAreEN.EstadoArea = "0" Then
            iAreEN.EsVerdad = False
            iAreEN.Mensaje = "El Area que digitaste esta Desactivado"
            Return iAreEN
        End If

        'Si todo esta OK
        iAreEN.EsVerdad = True
        iAreEN.Mensaje = String.Empty
        Return iAreEN

    End Function


End Class
