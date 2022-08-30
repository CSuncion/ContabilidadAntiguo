Imports Entidad
Imports Datos

Public Class VentanaOpcionRN
      Dim cam As New CamposEntidad
      Const vista As String = "VsVentanaOpcion"

      Sub nuevoVentanaOpcion(ByRef ent As SuperEntidad)
            '//
            '/
            ent.EstadoRegistro = "1"
            ent.EliminadoRegistro = "1"
            ent.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
            ent.NombreUsuarioAgrega = SuperEntidad.xNombreUsuario
            ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
            ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
            '/adiciona
            Dim tabAD As New VentanaOpcionAD
            tabAD.SpNuevoVentanaOpcion(ent)
      End Sub

      Sub modificarVentanaOpcion(ByRef ent As SuperEntidad)
            '//
            ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
            ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
            '/Se elimina Fisicamente el registro
            Dim tabAD As New VentanaOpcionAD
            tabAD.SpModificarVentanaOpcion(ent)
      End Sub

      Sub eliminarVentanaOpcionFis(ByRef ent As SuperEntidad)
            '//
            '/Se elimina logicamente el registro
            Dim tabAD As New VentanaOpcionAD
            tabAD.SpEliminarVentanaOpcion(ent)
      End Sub

      Function buscarVentanaOpcionExisPorVentanaYOpcion(ByRef ent As SuperEntidad) As SuperEntidad
            '//
            Dim obj As New SuperEntidad
            ent.Vista = vista
            ent.DatoEliminado = "1"
            ent.DatoEstado = ""
            ent.CampoCondicion1 = cam.CodOpc
            ent.DatoCondicion1 = ent.CodigoOpcion
            ent.CampoCondicion2 = cam.CodVen
            ent.DatoCondicion2 = ent.CodigoVentana
            Dim objAD As New VentanaOpcionAD
            obj = objAD.SpBuscarRegistroConDosCondicion(ent)
            Return obj
            '\\
      End Function

      Function obtenerVentanaOpcionesExis(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
            '//
            Dim listObj As New List(Of SuperEntidad)
            ent.Vista = vista
            ent.DatoEliminado = "1"
            ent.DatoEstado = ""
            Dim objAD As New VentanaOpcionAD
            listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
            Return listObj
            '\\
      End Function

      Function obtenerVentanaOpcionesExisXVentana(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
            '//
            Dim listObj As New List(Of SuperEntidad)
            ent.Vista = vista
            ent.DatoEliminado = "1"
            ent.DatoEstado = ""
            ent.CampoCondicion1 = cam.CodVen
            ent.DatoCondicion1 = ent.CodigoVentana
            Dim objAD As New VentanaOpcionAD
            listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
            Return listObj
            '\\
      End Function

      Function obtenerVentanaOpcionesExisXOpcion(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
            '//
            Dim listObj As New List(Of SuperEntidad)
            ent.Vista = vista
            ent.DatoEliminado = "1"
            ent.DatoEstado = ""
            ent.CampoCondicion1 = cam.CodOpc
            ent.DatoCondicion1 = ent.CodigoOpcion
            Dim objAD As New VentanaOpcionAD
            listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
            Return listObj
            '\\
      End Function


End Class
