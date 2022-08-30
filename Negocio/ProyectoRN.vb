Imports Entidad
Imports Datos
Public Class ProyectoRN
    Dim cam As New CamposEntidad
    Sub nuevoProyecto(ByRef ent As SuperEntidad)
        '//
        '/
        ent.OfertaGenera = "0"
        ent.ProyectoGenera = "0"
        ent.EstadoRegistro = "1"
        ent.EliminadoRegistro = "1"
        ent.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
        ent.CodigoPersonalAgrega = SuperEntidad.xCodigoPersonal
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.CodigoPersonalModifica = SuperEntidad.xCodigoPersonal
        '/adiciona
        Dim tabAD As New ProyectoAD
        tabAD.SpNuevoProyecto(ent)
    End Sub

    Sub modificarProyecto(ByRef ent As SuperEntidad)
        '//
        '/Vovemos a traer el usuario actual de la b.d
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.CodigoPersonalModifica = SuperEntidad.xCodigoPersonal
        '/Vovemos a traer el usuario actual de la b.d

        ''/Mandamos a modificar la b.d
        Dim objAD As New ProyectoAD
        objAD.SpModificarProyecto(ent)
        '\\
    End Sub

    Sub EliminarProyectoLog(ByRef ent As SuperEntidad)
        '//
        '/Datos por defecto
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.CodigoPersonalModifica = SuperEntidad.xCodigoPersonal
            ent.EliminadoRegistro = "0"
            ent.EstadoRegistro = "0"
        '/Mandamos a modificar la b.d
        Dim objAD As New ProyectoAD
        objAD.SpModificarProyecto(ent)
        '\\
    End Sub

    Sub eliminarProyectoFis(ByRef ent As SuperEntidad)
        '//
        Dim objAD As New ProyectoAD
        objAD.SpEliminarProyecto(ent)
        '\\
    End Sub

    Function obtenerProyectoExis(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsProyecto"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        Dim objAD As New ProyectoAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerProyectoEli(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsProyecto"
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        Dim objAD As New ProyectoAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function


    Function obtenerProyectoExisAct(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsProyecto"
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        Dim objAD As New ProyectoAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerSoloProyectoExisAct(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsProyecto"
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = cam.TipProHij
        ent.DatoCondicion1 = "P"
        Dim objAD As New ProyectoAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
        Return listObj
        '\\
    End Function

    Function buscarProyectoExisPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsProyecto"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.CodProHij
        Dim objAD As New ProyectoAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarProyectoExisActPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsProyecto"
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = cam.CodProHij
        Dim objAD As New ProyectoAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarProyectoElimPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsProyecto"
        ent.DatoEliminado = "0"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = cam.CodProHij
        Dim objAD As New ProyectoAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarProyectoExisActPorCodigoyTipo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsProyecto"
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = cam.CodProHij
        ent.CampoCondicion2 = cam.TipProHij
        ent.DatoCondicion2 = "P"
        Dim objAD As New ProyectoAD
        obj = objAD.SpBuscarRegistroConDosCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarProyectoPorCodigoyTipo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsProyecto"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.CodProHij
        ent.CampoCondicion2 = cam.TipProHij
        ent.DatoCondicion2 = "O"
        Dim objAD As New ProyectoAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function existeProyecto(ByRef ent As SuperEntidad) As Boolean
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsProyecto"
        ent.DatoEliminado = ""
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.CodProHij
        Dim objAD As New ProyectoAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        If obj.CodigoProHijo = "" Then
            Return False
        Else
            Return True
        End If
        '\\
    End Function

    Function esProyectoConOferta(ByRef ent As SuperEntidad) As Boolean
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsProyecto"
        ent.DatoEliminado = ""
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.CodProHij
        Dim objAD As New ProyectoAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        If obj.OfertaGenera = "0" And obj.TipoProHijo = "P" Then
            Return True
        Else
            Return False
        End If
        '\\
    End Function


    Function obtenerOfertasExisActSinGenerar(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsProyecto"
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = cam.TipProHij
        ent.CampoCondicion2 = cam.oferGene
        ent.DatoCondicion1 = "O"
        ent.DatoCondicion2 = "0"
        Dim perAD As New ProyectoAD
        listObj = perAD.SpObtenerRegistrosConDosCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerOfertasExisSinGenerar(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsProyecto"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.TipProHij
        ent.CampoCondicion2 = cam.oferGene
        ent.DatoCondicion1 = "O"
        ent.DatoCondicion2 = "0"
        Dim perAD As New ProyectoAD
        listObj = perAD.SpObtenerRegistrosConDosCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerProyectosExisSinGenerar(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsProyecto"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.TipProHij
        ent.CampoCondicion2 = cam.ProyGene
        ent.DatoCondicion1 = "P"
        ent.DatoCondicion2 = "0"
        Dim perAD As New ProyectoAD
        listObj = perAD.SpObtenerRegistrosConDosCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerProyectosExisActSinGenerar(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsProyecto"
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = cam.TipProHij
        ent.CampoCondicion2 = cam.ProyGene
        ent.DatoCondicion1 = "P"
        ent.DatoCondicion2 = "0"
        Dim perAD As New ProyectoAD
        listObj = perAD.SpObtenerRegistrosConDosCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerProyectosExisActConGenerar(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsProyecto"
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = cam.TipProHij
        ent.CampoCondicion2 = cam.ProyGene
        ent.DatoCondicion1 = "P"
        ent.DatoCondicion2 = "1"
        Dim perAD As New ProyectoAD
        listObj = perAD.SpObtenerRegistrosConDosCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerSoloHojasTiempoExis(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsProyecto"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.CodAux
        ent.DatoCondicion1 = ""
        Dim objAD As New ProyectoAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerSoloOfertasExis(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsProyecto"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.TipProHij
        ent.DatoCondicion1 = "O"
        Dim objAD As New ProyectoAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
        Return listObj
        '\\
    End Function


    Function obtenerSoloProyectosConOfertasExis(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsProyecto"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.TipProHij
        ent.CampoCondicion2 = cam.oferGene
        ent.DatoCondicion1 = "P"
        ent.DatoCondicion2 = "0"
        Dim objAD As New ProyectoAD
        listObj = objAD.SpObtenerRegistrosConDosCondicion(ent)
        Return listObj
        '\\
    End Function


    Function obtenerSoloProyectosSinOfertasExis(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsProyecto"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.TipProHij
        ent.CampoCondicion2 = cam.oferGene
        ent.DatoCondicion1 = "P"
        ent.DatoCondicion2 = "1"
        Dim objAD As New ProyectoAD
        listObj = objAD.SpObtenerRegistrosConDosCondicion(ent)
        Return listObj
        '\\
    End Function




    Function buscarOfertaSinGenerapORCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsProyecto"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.CodProHij
        ent.CampoCondicion2 = cam.TipProHij
        ent.DatoCondicion2 = "O"
        Dim objAD As New ProyectoAD
        obj = objAD.SpBuscarRegistroConDosCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarProyectoSinGeneraPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsProyecto"
        ent.DatoEliminado = ""
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.CodProHij
        ent.CampoCondicion2 = cam.TipProHij
        ent.DatoCondicion2 = "P"
        Dim objAD As New ProyectoAD
        obj = objAD.SpBuscarRegistroConDosCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarProyectoExisPorCodigoYTipo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsProyecto"
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = cam.CodProHij
        ent.CampoCondicion2 = cam.TipProHij
        ent.DatoCondicion2 = ent.TipoProHijo
        Dim objAD As New ProyectoAD
        obj = objAD.SpBuscarRegistroConDosCondicion(ent)
        Return obj
        '\\
    End Function

    Function obtenerProyectosExisActXTipo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsProyecto"
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = cam.TipProHij
        ent.DatoCondicion1 = ent.TipoProHijo
        Dim objAD As New ProyectoAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
        Return listObj
        '\\
    End Function

    Function ListarSoloProyectosYOfertasActivas(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New ProyectoAD
        Return objAD.ListarSoloProyectosYOfertasActivas(ent)
        '\\
    End Function



End Class
