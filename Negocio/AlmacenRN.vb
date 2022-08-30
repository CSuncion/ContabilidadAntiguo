Imports Entidad
Imports Datos
Public Class AlmacenRN
    Dim cam As New CamposEntidad
    Const vista As String = "VsAlmacen"
#Region "Pruebas"
    Function obtenerAlmacenPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim auxAD As New AlmacenAD
        Return auxAD.SpObtenerAlmacenPorCodigo(ent)
        '\\
    End Function

    Function existeCodigo(ByRef ent As SuperEntidad) As Boolean
        '//
        '/Obtenemos el usuario 
        Dim usu As New SuperEntidad
        usu = Me.obtenerAlmacenPorCodigo(ent)
        '/Comparamos la clave ingresada con la clave del usuario obtenido
        If usu.CodigoAlmacen = "" Then
            Return False
        Else
            Return True
        End If
        '\\
    End Function

    Function obtenerAlmacenTodos(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim auxAD As New AlmacenAD
        Return auxAD.SpObtenerAlmacenTodos(ent)
        '\\
    End Function

    Function listarAlmacenPorTipo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim aux As New AlmacenAD
        Return aux.SpListarAlmacenPorTipo(ent)
    End Function

#End Region

    Sub nuevoAlmacen(ByRef ent As SuperEntidad)
        '//
        '/Estos Datos son por defecto cada vez que agregue un nuevo usuario
        ent.EstadoRegistro = "1"
        ent.EliminadoRegistro = "1"
        ent.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioAgrega = SuperEntidad.xNombreUsuario
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuarioModifica
        Dim objAD As New AlmacenAD
        objAD.SpNuevoAlmacen(ent)
        '\\
    End Sub

    Sub modificarAlmacen(ByRef ent As SuperEntidad)
        '//
        '/Vovemos a traer el usuario actual de la b.d
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.CodigoPersonalModifica = SuperEntidad.xCodigoPersonal
        '/Vovemos a traer el usuario actual de la b.d

        ''/Mandamos a modificar la b.d
        Dim objAD As New AlmacenAD
        objAD.SpModificarAlmacen(ent)
        '\\
    End Sub

    Sub EliminarAlmacenLog(ByRef ent As SuperEntidad)
        '//
        '/Datos por defecto
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.CodigoPersonalModifica = SuperEntidad.xCodigoPersonal
        ent.EliminadoRegistro = "0"
        '/Mandamos a modificar la b.d
        Dim objAD As New AlmacenAD
        objAD.SpModificarAlmacen(ent)
        '\\
    End Sub

    Sub eliminarAlmacenFis(ByRef ent As SuperEntidad)
        '//
        '/Se elimina Fisicamente el registro
        Dim auxAD As New AlmacenAD
        auxAD.SpEliminarAlmacen(ent)
    End Sub

    Function obtenerAlmacenExis(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        Dim objAD As New AlmacenAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerAlmacenEli(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        Dim objAD As New AlmacenAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function buscarAlmacenExisPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.CodAlm
        ent.DatoCondicion1 = ent.CodigoAlmacen
        Dim objAD As New AlmacenAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarAlmacenEliPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.CodAlm
        Dim objAD As New AlmacenAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarAlmacenExisPorDescripcion(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.NomAlm
        Dim objAD As New AlmacenAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarAuxiliarExisActXTipoYCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.TipAux
        ent.DatoCondicion1 = ent.TipoAuxiliar
        ent.CampoCondicion2 = cam.CodAux
        ent.DatoCondicion2 = ent.CodigoAuxiliar

        'MsgBox(ent.CampoCondicion1 + "  " + ent.DatoCondicion1 + "  " + ent.CampoCondicion2 + "  " + ent.DatoCondicion2)

        Dim objAD As New AuxiliarAD

        obj = objAD.SpBuscarRegistroConDosCondicion(ent)
        Return obj
        '\\
    End Function

    Function obtenerAuxiliaresExisActPorTipoAux(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsAuxiliar"
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = cam.TipAux
        ent.DatoCondicion1 = ent.TipoAuxiliar
        Dim objAD As New AuxiliarAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
        Return listObj
        '\\
    End Function

    Function existeAuxiliarPorCodigo(ByRef ent As SuperEntidad) As Boolean
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsAuxiliar"
        ent.DatoEliminado = ""
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.CodAux
        Dim perAD As New AuxiliarAD
        obj = perAD.SpBuscarRegistroConUnaCondicion(ent)
        If obj.CodigoAuxiliar = "" Then
            Return False
        Else
            Return True
        End If
        '\\
    End Function

    Function ListarClienteYClienteProveedor(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New AuxiliarAD
        Return objAD.ListarClienteYClienteProveedor(ent)
        '\\
    End Function

End Class
