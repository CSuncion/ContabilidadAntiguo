Imports Entidad
Imports Datos

Public Class PermisoRN
      Dim cam As New CamposEntidad
      Const vista As String = "VsPermiso"

      Sub nuevoPermiso(ByRef ent As SuperEntidad)
            '//
            '/
            ent.OpcionPermiso = 0 '  0=Accion disponible   , 1 : permiso
            ent.EstadoRegistro = "1"
            ent.EliminadoRegistro = "1"
            ent.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
            ent.NombreUsuarioAgrega = SuperEntidad.xNombreUsuario
            ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
            ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
            '/adiciona
            Dim tabAD As New PermisoAD
            tabAD.SpNuevoPermiso(ent)
      End Sub

      Sub modificarPermiso(ByRef ent As SuperEntidad)
            '//
            ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
            ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
            '/Se elimina Fisicamente el registro
            Dim tabAD As New PermisoAD
            tabAD.SpModificarPermiso(ent)
      End Sub

      Sub eliminarPermisoFis(ByRef ent As SuperEntidad)
            '//
            '/Se elimina logicamente el registro
            Dim tabAD As New PermisoAD
            tabAD.SpEliminarPermiso(ent)
      End Sub

      Sub eliminarPermisosDeUsuarioFis(ByRef ent As SuperEntidad)
            '//
            '/Se elimina logicamente el registro
            Dim tabAD As New PermisoAD
            tabAD.SpEliminarPermisosDeUsuario(ent)
    End Sub

  

      Function buscarPermisoExisPorUsuarioYVentanaYOpcion(ByRef ent As SuperEntidad) As SuperEntidad
            '//
            Dim obj As New SuperEntidad
            ent.Vista = vista
            ent.DatoEliminado = "1"
            ent.DatoEstado = ""
            ent.CampoCondicion1 = cam.CodUsu
            ent.DatoCondicion1 = ent.CodigoUsuario
            ent.CampoCondicion2 = cam.CodVen
            ent.DatoCondicion2 = ent.CodigoVentana
            ent.CampoCondicion3 = cam.CodOpc
            ent.DatoCondicion3 = ent.CodigoOpcion
            Dim objAD As New PermisoAD
            obj = objAD.SpBuscarRegistroConTresCondicion(ent)
            Return obj
            '\\
      End Function

      Function obtenerOpcionesDisponiblesExisXVentana(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
            '//
            Dim listObj As New List(Of SuperEntidad)
            ent.Vista = vista
            ent.DatoEliminado = "1"
            ent.DatoEstado = ""
            ent.CampoCondicion1 = cam.CodUsu
            ent.DatoCondicion1 = ent.CodigoUsuario
            ent.CampoCondicion2 = cam.CodVen
            ent.DatoCondicion2 = ent.CodigoVentana
            ent.CampoCondicion3 = cam.OpcPer
            ent.DatoCondicion3 = "0" ' 0 : Acciones disponibles  , 1 : Permisos
            Dim objAD As New PermisoAD
            listObj = objAD.SpObtenerRegistrosConTresCondicion(ent)
            Return listObj
            '\\
      End Function

      Function obtenerPermisosExisXVentana(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
            '//
            Dim listObj As New List(Of SuperEntidad)
            ent.Vista = vista
            ent.DatoEliminado = "1"
            ent.DatoEstado = ""
            ent.CampoCondicion1 = cam.CodUsu
            ent.DatoCondicion1 = ent.CodigoUsuario
            ent.CampoCondicion2 = cam.CodVen
            ent.DatoCondicion2 = ent.CodigoVentana
            ent.CampoCondicion3 = cam.OpcPer
            ent.DatoCondicion3 = "1" ' 0 : Acciones disponibles  , 1 : Permisos
            Dim objAD As New PermisoAD
            listObj = objAD.SpObtenerRegistrosConTresCondicion(ent)
            Return listObj
            '\\
      End Function

      Function obtenerPermisosExisXUsuario(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
            '//
            Dim listObj As New List(Of SuperEntidad)
            ent.Vista = vista
            ent.DatoEliminado = "1"
            ent.DatoEstado = ""
            ent.CampoCondicion1 = cam.CodUsu
            ent.DatoCondicion1 = ent.CodigoUsuario
            Dim objAD As New PermisoAD
            listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
            Return listObj
            '\\
      End Function

      Function obtenerPermisosExisXUsuarioYVentana(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
            '//
            Dim listObj As New List(Of SuperEntidad)
            ent.Vista = vista
            ent.DatoEliminado = "1"
            ent.DatoEstado = ""
            ent.CampoCondicion1 = cam.CodUsu
            ent.DatoCondicion1 = ent.CodigoUsuario
            ent.CampoCondicion2 = cam.CodVen
            ent.DatoCondicion2 = ent.CodigoVentana
            Dim objAD As New PermisoAD
            listObj = objAD.SpObtenerRegistrosConDosCondicion(ent)
            Return listObj
            '\\
      End Function


      Function obtenerPermisosExisDeVentanasXUsuario(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
            '//
            Dim listObj As New List(Of SuperEntidad)
            ent.Vista = "VsPermisoVentana"
            ent.DatoEliminado = "1"
            ent.DatoEstado = ""
            ent.CampoCondicion1 = cam.CodUsu
            ent.DatoCondicion1 = ent.CodigoUsuario
            ent.CampoOrden = cam.CodVen
            Dim objAD As New PermisoAD
            listObj = objAD.SpObtenerRegistrosConUnaCondicionEspecial(ent)
            Return listObj
            '\\
      End Function


End Class
