Imports Entidad
Imports Datos
Public Class UsuarioRN
    Dim cam As New CamposEntidad



#Region "Pruebas"
    '''' <summary>
    '''' Obtiene los usuarios que pertenecen a un grupo:
    '''' Se necesita el grupo de usuario
    '''' </summary>
    '''' <param name="ent"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Function obtenerUsuariosPorGrupo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
    '    Dim usuAD As New UsuarioAD
    '    Return usuAD.SpListarUsuariosPorGrupo(ent)
    'End Function
    ''' <summary>
    ''' Verifica si el usuario ingresa su clave correcta:
    ''' Se necesita codigo y clave de Usuario
    ''' </summary>
    ''' <param name="ent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function verificarClave(ByRef ent As SuperEntidad) As Boolean
        '//
        '/Tomamos la clave ingresada
        Dim clave As String = ent.ClaveUsuario
        '/Obtenemos el usuario 
        Dim usu As New SuperEntidad
        usu = Me.obtenerUsuarioPorCodigo(ent)
        '/Comparamos la clave ingresada con la clave del usuario obtenido
        If clave = usu.ClaveUsuario Then
            Return True
        Else
            Return False
        End If
        '\\
    End Function

    Function existeCodigo(ByRef ent As SuperEntidad) As Boolean
        '//
        '/Obtenemos el usuario 
        Dim usu As New SuperEntidad
        usu = Me.obtenerUsuarioPorCodigo(ent)
        '/Comparamos la clave ingresada con la clave del usuario obtenido
        If usu.CodigoUsuario = "" Then
            Return False
        Else
            Return True
        End If
        '\\
    End Function
    ''' <summary>
    ''' Obtiene su clave de usuario:
    ''' Se necesita el codigo y respuesta de Usuario
    ''' </summary>
    ''' <param name="ent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function obtenerClave(ByRef ent As SuperEntidad) As String
        Dim rpta As String = ent.RespuestaUsuario
        Dim usu As New SuperEntidad
        usu = Me.obtenerUsuarioPorCodigo(ent)
        If rpta.ToLower = usu.RespuestaUsuario.ToLower Then
            Return usu.ClaveUsuario
        Else
            Return ""
        End If
    End Function
    ''' <summary>
    ''' Obtiene todos los usuaruios:
    ''' Se necesita el campo por el cual se ordenan los usuarios
    ''' </summary>
    ''' <param name="ent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function obtenerUsuariosTodos(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim usuAD As New UsuarioAD
        Return usuAD.SpObtenerUsuariosTodos(ent)
        '\\
    End Function

    Function obtenerPreguntasSecretas() As List(Of SuperEntidad)
        '//
        Dim usuAD As New UsuarioAD
        Return usuAD.SpListarPreguntasSecretas
        '\\
    End Function

    ''' <summary>
    ''' Obtiene al usuario por su codigo
    ''' </summary>
    ''' <param name="ent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function obtenerUsuarioPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim usuAD As New UsuarioAD
        Return usuAD.SpObtenerUsuarioPorCodigo(ent)
        '\\
    End Function




    ''' <summary>
    ''' Modifica la clave,pregunta y respuesta de usuario
    ''' </summary>
    ''' <param name="ent"></param>
    ''' <remarks></remarks>
    Sub modificarClaveUsuario(ByRef ent As SuperEntidad)
        '//
        '/Vovemos a traer el usuario actual de la b.d
        Dim usu As New SuperEntidad
        usu = Me.obtenerUsuarioPorCodigo(ent)
        '/Pasamos los datos actualizados a la entidad usu
        usu.ClaveUsuario = ent.ClaveUsuario
        usu.CodigoPregunta = ent.CodigoPregunta
        usu.RespuestaUsuario = ent.RespuestaUsuario
        '/Mandamos a modificar la b.d
        Dim usuAD As New UsuarioAD
        usuAD.SpModificarUsuario(usu)
        '\\
    End Sub

#End Region
   

    Sub nuevoUsuario(ByRef ent As SuperEntidad)
        '//
        '/Estos Datos son por defecto cada vez que agregue un nuevo usuario
        ent.CodigoPregunta = "P04"
        ent.RespuestaUsuario = "Tobi"
        ent.EstadoRegistro = "1"
        ent.EliminadoRegistro = "1"
        ent.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioAgrega = SuperEntidad.xNombreUsuario
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        Dim usuAD As New UsuarioAD
        usuAD.SpNuevoUsuario(ent)
        '\\
    End Sub


    Sub modificarUsuario(ByRef ent As SuperEntidad)
        '//
        '/Vovemos a traer el usuario actual de la b.d
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        '/Mandamos a modificar la b.d
        Dim usuAD As New UsuarioAD
        usuAD.SpModificarUsuario(ent)
        '\\
    End Sub

    Sub EliminarUsuarioLog(ByRef ent As SuperEntidad)
        '//
        '/Datos por defecto
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.CodigoPersonalModifica = SuperEntidad.xCodigoPersonal
        ent.EliminadoRegistro = "0"
        '/Mandamos a modificar la b.d
        Dim usuAD As New UsuarioAD
        usuAD.SpModificarUsuario(ent)
        '\\
    End Sub

    Sub eliminarUsuarioFis(ByRef ent As SuperEntidad)
        '//
        Dim objAD As New UsuarioAD
        objAD.SpEliminarUsuario(ent)
        '\\
    End Sub


    Function buscarUsuarioExisTotPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsUsuarios"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.CodUsu
        Dim perAD As New UsuarioAD
        obj = perAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarUsuarioExisActPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsUsuarios"
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = cam.CodUsu
        Dim perAD As New UsuarioAD
        obj = perAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function existeUsuarioPorCodigo(ByRef ent As SuperEntidad) As Boolean
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsUsuarios"
        ent.DatoEliminado = ""
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.CodUsu
        Dim perAD As New UsuarioAD
        obj = perAD.SpBuscarRegistroConUnaCondicion(ent)
        If obj.CodigoUsuario = "" Then
            Return False
        Else
            Return True
        End If
        '\\
    End Function

    Function existeUsuarioPorCodigoPersonal(ByRef ent As SuperEntidad) As Boolean
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsUsuarios"
        ent.DatoEliminado = ""
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.CodPerUsu
        Dim perAD As New UsuarioAD
        obj = perAD.SpBuscarRegistroConUnaCondicion(ent)
        If obj.CodigoUsuario = "" Then
            Return False
        Else
            Return True
        End If
        '\\
    End Function


    Function existeUsuarioExisActPorCodigoYClave(ByRef ent As SuperEntidad) As Boolean
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsUsuarios"
        ent.DatoEliminado = ""
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.CodUsu
        ent.CampoCondicion2 = cam.ClaUsu
        Dim perAD As New UsuarioAD
        obj = perAD.SpBuscarRegistroConDosCondicion(ent)
        If obj.CodigoUsuario = "" Then
            Return False
        Else
            Return True
        End If
        '\\
    End Function

    Function obtenerUsuariosExisTot(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsUsuarios"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        Dim objAD As New UsuarioAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerUsuariosExiAct(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsUsuarios"
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoOrden = cam.CodUsu
        Dim objAD As New UsuarioAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function


    Function obtenerUsuariosExisActPorGrupo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsUsuarios"
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = cam.CodGru
        ent.CampoOrden = cam.CodUsu
        Dim objAD As New UsuarioAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
        Return listObj
        '\\
    End Function


    Function buscarUsuarioExisPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsUsuarios"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.CodUsu
        Dim perAD As New UsuarioAD
        obj = perAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function


    Function EnBlanco() As SuperEntidad
        Dim oUsu As New SuperEntidad
        oUsu.CodigoUsuario = ""
        oUsu.NombreUsuario = ""
        Return oUsu
    End Function


    Function obtenerUsuarios(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsUsuarios"
        ent.DatoEliminado = ""
        ent.DatoEstado = ""
        Dim objAD As New UsuarioAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function



End Class

