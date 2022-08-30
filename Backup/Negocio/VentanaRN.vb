Imports Entidad
Imports Datos

Public Class VentanaRN

      Dim cam As New CamposEntidad
      Const vista As String = "VsVentana"

      Sub nuevoVentana(ByRef ent As SuperEntidad)
            '//
            '/
            ent.EstadoRegistro = "1"
            ent.EliminadoRegistro = "1"
            ent.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
            ent.NombreUsuarioAgrega = SuperEntidad.xNombreUsuario
            ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
            ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
            '/adiciona
            Dim tabAD As New VentanaAD
            tabAD.SpNuevoVentana(ent)
      End Sub

      Sub modificarVentana(ByRef ent As SuperEntidad)
            '//
            ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
            ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
            '/Se elimina Fisicamente el registro
            Dim tabAD As New VentanaAD
            tabAD.SpModificarVentana(ent)
      End Sub

      Sub eliminarVentanaTablaFis(ByRef ent As SuperEntidad)
            '//
            '/Se elimina logicamente el registro
            Dim tabAD As New VentanaAD
            tabAD.SpEliminarVentana(ent)
      End Sub

      Function buscarVentanaExisPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
            '//
            Dim obj As New SuperEntidad
            ent.Vista = vista
            ent.DatoEliminado = "1"
            ent.DatoEstado = ""
            ent.CampoCondicion1 = cam.CodVen
            ent.DatoCondicion1 = ent.CodigoVentana
            Dim objAD As New VentanaAD
            obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
            Return obj
            '\\
      End Function


      Function obtenerVentanaExis(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
            '//
            Dim listObj As New List(Of SuperEntidad)
            ent.Vista = vista
            ent.DatoEliminado = "1"
            ent.DatoEstado = ""
            Dim objAD As New VentanaAD
            listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
            Return listObj
            '\\
      End Function




End Class
