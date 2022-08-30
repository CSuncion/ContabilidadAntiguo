Imports Entidad
Imports Datos

Public Class OpcionRN

      Dim cam As New CamposEntidad
      Const vista As String = "VsOpcion"

      Function OpcionIni() As SuperEntidad
            Dim ent As New SuperEntidad
            Return ent
      End Function

      Sub nuevoOpcion(ByRef ent As SuperEntidad)
            '//
            '/
            ent.EstadoRegistro = "1"
            ent.EliminadoRegistro = "1"
            ent.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
            ent.NombreUsuarioAgrega = SuperEntidad.xNombreUsuario
            ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
            ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
            '/adiciona
            Dim tabAD As New OpcionAD
            tabAD.SpNuevoOpcion(ent)
      End Sub

      Sub modificarOpcion(ByRef ent As SuperEntidad)
            '//
            ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
            ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
            '/Se elimina Fisicamente el registro
            Dim tabAD As New OpcionAD
            tabAD.SpModificarOpcion(ent)
      End Sub

      Sub eliminarOpcionTablaFis(ByRef ent As SuperEntidad)
            '//
            '/Se elimina logicamente el registro
            Dim tabAD As New OpcionAD
            tabAD.SpEliminarOpcion(ent)
      End Sub


      Function buscarOpcionExisPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
            '//
            Dim obj As New SuperEntidad
            ent.Vista = vista
            ent.DatoEliminado = "1"
            ent.DatoEstado = ""
            ent.CampoCondicion1 = cam.CodOpc
            ent.DatoCondicion1 = ent.CodigoOpcion
            Dim objAD As New OpcionAD
            obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
            Return obj
            '\\
      End Function


      Function obtenerOpcionesExis(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
            '//
            Dim listObj As New List(Of SuperEntidad)
            ent.Vista = vista
            ent.DatoEliminado = "1"
            ent.DatoEstado = ""
            Dim objAD As New OpcionAD
            listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
            Return listObj
            '\\
      End Function

      'Function obtenerOpcionesExisXVentana(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
      '      '//
      '      Dim listObj As New List(Of SuperEntidad)
      '      ent.Vista = vista
      '      ent.DatoEliminado = "1"
      '      ent.DatoEstado = ""
      '      ent.CampoCondicion1 = cam.CodVen
      '      ent.DatoCondicion1 = ent.CodigoVentana
      '      Dim objAD As New OpcionAD
      '      listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
      '      Return listObj
      '      '\\
      'End Function




End Class
