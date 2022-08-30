Imports Entidad
Imports Datos
Public Class TablaRN
    Dim cam As New CamposEntidad



    Function obtenerFileAutogenerado(ByRef ent As SuperEntidad) As String
        ent.TipoTabla = "Fil"
        Dim objAD As New TablaAD
        Return objAD.SpAutogenerarFile(ent)
    End Function


    Sub nuevoItemTabla(ByRef ent As SuperEntidad)
        '//
        '/
        ent.Voucher = "000000"
        ent.EstadoRegistro = "1"
        ent.EliminadoRegistro = "1"
        ent.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        '/adiciona
        Dim tabAD As New TablaAD
        tabAD.SpNuevoItemTabla(ent)
    End Sub

    Sub modificarItemTabla(ByRef ent As SuperEntidad)
        '//
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario

        '/Se elimina Fisicamente el registro
        Dim tabAD As New TablaAD
        tabAD.SpModificarItemTabla(ent)
    End Sub

    Sub eliminarItemTablaLog(ByRef ent As SuperEntidad)
        '//
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        'ent.CodigoPersonalModifica = SuperEntidad.xCodigoPersonal
        ent.EliminadoRegistro = "0"
        '/Se elimina logicamente el registro
        Dim tabAD As New TablaAD
        tabAD.SpModificarItemTabla(ent)
    End Sub

    Sub eliminarItemTablaFis(ByRef ent As SuperEntidad)
        '//
        '/Se elimina logicamente el registro
        Dim tabAD As New TablaAD
        tabAD.SpEliminarItemTabla(ent)
    End Sub


#Region "Pruebas"
    Function obtenerItemTablaPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        Dim tab As New TablaAD
        Return tab.SpObtenerItemTablaPorCodigo(ent)
    End Function

    Function filtrarItemsTablaPorTabla(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim tab As New TablaAD
        Return tab.SpFiltrarItemsTablaPorTabla(ent)
    End Function

    Function listarItemsTablaPorTabla(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim tab As New TablaAD
        Return tab.SpListarItemsTablaPorTabla(ent)
    End Function

    Function existeItemTabla(ByRef ent As SuperEntidad) As Boolean
        Dim iTab As New SuperEntidad
        iTab = Me.obtenerItemTablaPorCodigo(ent)
        If iTab.CodigoItemTabla = "" Then
            Return False
        Else
            Return True
        End If
    End Function

#End Region

    Function buscarItemTablaExisActPorTipoTablaYCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsTablas"
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = cam.TipTabla
        ent.CampoCondicion2 = cam.CodItemTabla

        Dim objAD As New TablaAD
        obj = objAD.SpBuscarRegistroConDosCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarItemTablaExisActPorTipoTablaYNombre(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsTablas"
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = cam.TipTabla
        ent.CampoCondicion2 = cam.NomItemTabla
        Dim objAD As New TablaAD
        obj = objAD.SpBuscarRegistroConDosCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarItemTablaExisPorTipoTablaYCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsTablas"
        ent.DatoEliminado = ""
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.TipTabla
        ent.CampoCondicion2 = cam.CodItemTabla
        Dim objAD As New TablaAD
        obj = objAD.SpBuscarRegistroConDosCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarItemTablaEliPorTipoTablaYCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsTablas"
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.TipTabla
        ent.CampoCondicion2 = cam.CodItemTabla
        Dim objAD As New TablaAD
        obj = objAD.SpBuscarRegistroConDosCondicion(ent)
        Return obj
        '\\
    End Function


    Function existeItemTablaExisPorTipoTablaYCodigo(ByRef ent As SuperEntidad) As Boolean
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsTablas"
        ent.DatoEliminado = ""
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.TipTabla
        ent.CampoCondicion2 = cam.CodItemTabla
        Dim objAD As New TablaAD
        obj = objAD.SpBuscarRegistroConDosCondicion(ent)
        If obj.CodigoItemTabla = "" Then
            Return False
        Else
            Return True
        End If
        '\\
    End Function

    Function obtenerItemsTablaExisActPorTipoTabla(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsTablas"
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = cam.TipTabla
        Dim objAD As New TablaAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerItemsTablaExisActPorTipoTablayFiltroCodigo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsTablas"
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = cam.TipTabla
        ent.CampoFiltro1 = cam.CodItemTabla
        'ent.DatoFiltro1 = "02"
        Dim objAD As New TablaAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicionUnfiltro(ent)
        Return listObj
        '\\
    End Function

    Function obtenerItemsTablaExisActPorTipoTablayVoucher(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsTablas"
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = cam.TipTabla
        ent.CampoCondicion2 = cam.CodOriRC
        Dim objAD As New TablaAD
        listObj = objAD.SpObtenerRegistrosConDosCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerItemsTablaExisActPorTipoTablay1Y2(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim lista As New List(Of SuperEntidad)
        Dim listObj As New List(Of SuperEntidad)
        listObj = Me.obtenerItemsTablaExisPorTipoTabla(ent)

        For Each obj As SuperEntidad In listObj
            If obj.CodigoItemTabla = "1" Or obj.CodigoItemTabla = "2" Then
                lista.Add(obj)
            End If
        Next
        Return lista
        '\\
    End Function
    Function obtenerItemsTablaExisPorTipoTabla(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsTablas"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.TipTabla
        Dim objAD As New TablaAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerItemsTablaEliPorTipoTabla(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsTablas"
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.TipTabla
        Dim objAD As New TablaAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerItemsTablaExisPorTipoTablayFiltroCodigo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsTablas"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.TipTabla
        ent.CampoFiltro1 = cam.CodItemTabla
        Dim objAD As New TablaAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicionUnfiltro(ent)
        Return listObj
        '\\
    End Function

    Function obtenerItemsTablaEliPorTipoTablayFiltroCodigo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsTablas"
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.TipTabla
        ent.CampoFiltro1 = cam.CodItemTabla
        Dim objAD As New TablaAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicionUnfiltro(ent)
        Return listObj
        '\\
    End Function


    Function obtenerConceptosParaCompras(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        Dim objAD As New TablaAD
        listObj = objAD.ConceptosParaCompras(ent)
        Return listObj
        '\\
    End Function

    Function obtenerItemsTablaExisActPorTipoTablaDeProyecto(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsTablas"
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = cam.TipTabla
        Dim objAD As New TablaAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicionDeProyecto(ent)
        Return listObj
        '\\
    End Function

    Function obtenerItemsTablaExisPorTipoTablayFiltroCodigoDeProyecto(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsTablas"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.TipTabla
        ent.CampoFiltro1 = cam.CodItemTabla
        Dim objAD As New TablaAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicionUnfiltroDeProyecto(ent)
        Return listObj
        '\\
    End Function

    Function buscarItemTablaExisPorTipoTablaYCodigoDeProyecto(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsTablas"
        ent.DatoEliminado = ""
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.TipTabla
        ent.CampoCondicion2 = cam.CodItemTabla
        Dim objAD As New TablaAD
        obj = objAD.SpBuscarRegistroConDosCondicionDeProyecto(ent)
        Return obj
        '\\
    End Function

End Class
