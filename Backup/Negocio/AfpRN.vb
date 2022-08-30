Imports Entidad
Imports Datos
Public Class AfpRN
    Dim cam As New CamposEntidad
    Const vista As String = "VsAfp"
#Region "Pruebas"
    Function obtenerAuxiliarPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim auxAD As New AuxiliarAD
        Return auxAD.SpObtenerAuxiliarPorCodigo(ent)
        '\\
    End Function

    Function existeCodigo(ByRef ent As SuperEntidad) As Boolean
        '//
        '/Obtenemos el usuario 
        Dim usu As New SuperEntidad
        usu = Me.obtenerAuxiliarPorCodigo(ent)
        '/Comparamos la clave ingresada con la clave del usuario obtenido
        If usu.CodigoAuxiliar = "" Then
            Return False
        Else
            Return True
        End If
        '\\
    End Function

    Function obtenerAuxiliaresTodos(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim auxAD As New AuxiliarAD
        Return auxAD.SpObtenerAuxiliaresTodos(ent)
        '\\
    End Function

    'Sub nuevoAuxiliar(ByRef ent As SuperEntidad)
    '    //
    '    /Estos Datos son por defecto cada vez que agregue un nuevo usuario
    '    ent.EstadoAuxiliar = "1"
    '    Dim auxAD As New AuxiliarAD
    '    auxAD.SpNuevoAuxiliar(ent)
    '    \\
    'End Sub

    'Sub modificarAuxiliar(ByRef ent As SuperEntidad)
    '    '//
    '    '/Mandamos a modificar la b.d
    '    Dim auxAD As New AuxiliarAD
    '    auxAD.SpModificarAuxiliar(ent)
    '    '\\
    'End Sub



    Function listarAuxiliaresPorTipo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim aux As New AuxiliarAD
        Return aux.SpListarAuxiliaresPorTipo(ent)
    End Function

#End Region

    Sub nuevoAfp(ByRef ent As SuperEntidad)
        '//
        '/Estos Datos son por defecto cada vez que agregue un nuevo usuario
        ent.EstadoRegistro = "1"
        ent.EliminadoRegistro = "1"
        ent.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioAgrega = SuperEntidad.xNombreUsuario
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuarioModifica
        Dim objAD As New AfpAD
        objAD.SpNuevoAfp(ent)
        '\\
    End Sub

    Sub modificarAfp(ByRef ent As SuperEntidad)
        '//
        '/Vovemos a traer el usuario actual de la b.d
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.CodigoPersonalModifica = SuperEntidad.xCodigoPersonal
        '/Vovemos a traer el usuario actual de la b.d

        ''/Mandamos a modificar la b.d
        Dim objAD As New AfpAD
        objAD.SpModificarAfp(ent)
        '\\
    End Sub


    Sub EliminarAfpLog(ByRef ent As SuperEntidad)
        '//
        '/Datos por defecto
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.CodigoPersonalModifica = SuperEntidad.xCodigoPersonal
        ent.EliminadoRegistro = "0"
        '/Mandamos a modificar la b.d
        Dim objAD As New AfpAD
        objAD.SpModificarAfp(ent)
        '\\
    End Sub

    Sub eliminarAfpFis(ByRef ent As SuperEntidad)
        '//
        '/Se elimina Fisicamente el registro
        Dim auxAD As New AfpAD
        auxAD.SpEliminarAfp(ent)
    End Sub

    Function obtenerAfpExis(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        Dim objAD As New AfpAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerAfpEli(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsAfp"
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        Dim objAD As New AfpAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function buscarAfpExisPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.CodAfp
        ent.DatoCondicion1 = ent.CodigoAfp
        Dim objAD As New AfpAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarAfpEliPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsAfp"
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.CodAfp
        Dim objAD As New AfpAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarAfpExisPorDescripcion(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsAfp"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.NomAfp
        Dim objAD As New AfpAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function existeAfpPorCodigo(ByRef ent As SuperEntidad) As Boolean
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsAfp"
        ent.DatoEliminado = ""
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.CodAfp
        Dim perAD As New AfpAD
        obj = perAD.SpBuscarRegistroConUnaCondicion(ent)
        If obj.CodigoAfp = "" Then
            Return False
        Else
            Return True
        End If
        '\\
    End Function

    Function ListarAfp(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New AfpAD
        Return objAD.ListarAfp(ent)
        '\\
    End Function

    Function BuscarAfp(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim objAD As New AfpAD
        Return objAD.BuscarAfp(ent)
        '\\
    End Function


    Function EsAfpValido(ByRef pObj As SuperEntidad) As SuperEntidad
        Dim iAfpEN As New SuperEntidad

        'Cuando el periodo esta en blanco
        If pObj.CodigoAfp = String.Empty Then
            iAfpEN.EsVerdad = True
            Return iAfpEN
        End If


        'Armando clave del periodo
        'iAfpEN.ClaveArea += pObj.CodigoEmpresa
        iAfpEN.CodigoAfp = pObj.CodigoAfp

        'Buscar en BD
        iAfpEN = Me.buscarAfpExisPorCodigo(iAfpEN)
        If iAfpEN.CodigoAfp = String.Empty Then
            iAfpEN.EsVerdad = False
            iAfpEN.Mensaje = "El Area que digitaste no existe"
            Return iAfpEN
        End If

        If iAfpEN.EstadoAfp = "0" Then
            iAfpEN.EsVerdad = False
            iAfpEN.Mensaje = "La Afp que digitaste esta Desactivado"
            Return iAfpEN
        End If

        'Si todo esta OK
        iAfpEN.EsVerdad = True
        iAfpEN.Mensaje = String.Empty
        Return iAfpEN

    End Function


End Class
