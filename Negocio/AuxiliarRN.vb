Imports Entidad
Imports Datos
Public Class AuxiliarRN
    Dim cam As New CamposEntidad
    Const vista As String = "VsAuxiliar"
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

    Sub nuevoAuxiliar(ByRef ent As SuperEntidad)
        '//
        '/Estos Datos son por defecto cada vez que agregue un nuevo usuario
        ent.EstadoRegistro = "1"
        ent.EliminadoRegistro = "1"
        ent.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioAgrega = SuperEntidad.xNombreUsuario
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuarioModifica
        Dim objAD As New AuxiliarAD
        objAD.SpNuevoAuxiliar(ent)
        '\\
    End Sub

    Sub modificarAuxiliar(ByRef ent As SuperEntidad)
        '//
        '/Vovemos a traer el usuario actual de la b.d
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.CodigoPersonalModifica = SuperEntidad.xCodigoPersonal
        '/Vovemos a traer el usuario actual de la b.d

        ''/Mandamos a modificar la b.d
        Dim objAD As New AuxiliarAD
        objAD.SpModificarAuxiliar(ent)
        '\\
    End Sub


    Sub EliminarAuxiliarLog(ByRef ent As SuperEntidad)
        '//
        '/Datos por defecto
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.CodigoPersonalModifica = SuperEntidad.xCodigoPersonal
        ent.EliminadoRegistro = "0"
        '/Mandamos a modificar la b.d
        Dim objAD As New AuxiliarAD
        objAD.SpModificarAuxiliar(ent)
        '\\
    End Sub

    Sub eliminarAuxiliarFis(ByRef ent As SuperEntidad)
        '//
        '/Se elimina Fisicamente el registro
        Dim auxAD As New AuxiliarAD
        auxAD.SpEliminarAuxiliar(ent)
    End Sub

    Function obtenerAuxiliaresExis(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        Dim objAD As New AuxiliarAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerAuxiliaresEli(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsAuxiliar"
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        Dim objAD As New AuxiliarAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function buscarAuxiliarExisPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.CodAux
        ent.DatoCondicion1 = ent.CodigoAuxiliar
        Dim objAD As New AuxiliarAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarAuxiliarEliPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsAuxiliar"
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.CodAux
        Dim objAD As New AuxiliarAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarAuxiliarExisPorDescripcion(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsAuxiliar"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.DesAux
        Dim objAD As New AuxiliarAD
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


    Function ListarProveedorYClienteProveedor(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New AuxiliarAD
        Return objAD.ListarProveedorYClienteProveedor(ent)
        '\\
    End Function

    Function ListarProveedorYClienteProveedorActivos(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New AuxiliarAD
        Return objAD.ListarProveedorYClienteProveedorActivos(ent)
        '\\
    End Function

    Function ListarAuxiliaresExistentesActivos(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New AuxiliarAD
        Return objAD.ListarAuxiliaresExistentesActivos(ent)
        '\\
    End Function

    Function ListarPersonal(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New AuxiliarAD
        Return objAD.ListarPersonal(ent)
        '\\
    End Function



    Function ListarClienteProveedor(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New AuxiliarAD
        Return objAD.ListarPersonal(ent)
        '\\
    End Function

    Function ListarCliente(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New AuxiliarAD
        Return objAD.ListarCliente(ent)
        '\\
    End Function


    Function ListarProveedor(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New AuxiliarAD
        Return objAD.ListarProveedor(ent)
        '\\
    End Function


    Function BuscarClienteYClienteProveedor(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim objAD As New AuxiliarAD
        Return objAD.BuscarClienteYClienteProveedor(ent)
        '\\
    End Function


    Function BuscarProveedorYClienteProveedor(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim objAD As New AuxiliarAD
        Return objAD.BuscarProveedorYClienteProveedor(ent)
        '\\
    End Function


    Function BuscarProveedorYClienteProveedorActivo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim objAD As New AuxiliarAD
        Return objAD.BuscarProveedorYClienteProveedorActivo(ent)
        '\\
    End Function

    Function BuscarAuxiliarExistenteActivo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim objAD As New AuxiliarAD
        Return objAD.BuscarAuxiliarExistenteActivo(ent)
        '\\
    End Function


    Function BuscarPersonal(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim objAD As New AuxiliarAD
        Return objAD.BuscarPersonal(ent)
        '\\
    End Function


    Function BuscarClienteProveedor(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim objAD As New AuxiliarAD
        Return objAD.BuscarClienteProveedor(ent)
        '\\
    End Function

    Function BuscarCliente(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim objAD As New AuxiliarAD
        Return objAD.BuscarCliente(ent)
        '\\
    End Function


    Function BuscarProveedor(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim objAD As New AuxiliarAD
        Return objAD.BuscarProveedor(ent)
        '\\
    End Function

    Function BuscarAuxiliar(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim objAD As New AuxiliarAD
        Return objAD.BuscarAuxiliar(ent)
        '\\
    End Function

    Function buscarAuxiliarExisPorCodigoDeProyecto(ByRef ent As SuperEntidad) As SuperEntidad
        Dim objAD As New AuxiliarAD
        Return objAD.BuscarAuxiliarEnProyectos(ent)
    End Function


End Class
