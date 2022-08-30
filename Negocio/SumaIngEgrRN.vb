Imports Entidad
Imports Datos

Public Class SumaIngEgrRN
    Dim Cam As New CamposEntidad
    Const vista As String = "VsSumaIngEgr"

    Sub nuevaSumaIngEgr(ByRef ent As SuperEntidad)
        '//
        '/Estos Datos son por defecto cada vez que agregue un nuevo usuario
        'ent.FlagTipoCuentaPcge = "1" '/Cuando no se captura en el formulario
        'ent.EstadoCuenta = "1"
        ent.EstadoRegistro = "1"
        ent.EliminadoRegistro = "1"
        ent.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioAgrega = SuperEntidad.xNombreUsuario
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        ent.ClaveSumaIngEgr = ent.CodigoEmpresa + ent.CodigoSumaIngEgr

        Dim objAD As New SumaIngEgrAD
        objAD.SpNuevoSumaIngEgr(ent)
        '\\
    End Sub

    Sub modificarSumaIngEgr(ByRef ent As SuperEntidad)
        '//
        '/Vovemos a traer el usuario actual de la b.d
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        '/Vovemos a traer el usuario actual de la b.d
        ''/Mandamos a modificar la b.d
        Dim objAD As New SumaIngEgrAD
        objAD.SpModificarSumaIngEgr(ent)
        '\\
    End Sub

    Sub eliminarSumaIngEgrLog(ByRef ent As SuperEntidad)
        '//
        '/Datos por defecto
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        ent.EliminadoRegistro = "0"
        '/Mandamos a modificar la b.d
        Dim objAD As New SumaIngEgrAD
        objAD.SpModificarSumaIngEgr(ent)
        '\\
    End Sub

    Sub eliminarSumaIngEgrFis(ByRef ent As SuperEntidad)
        '//
        '/Mandamos a modificar la b.d
        Dim objAD As New SumaIngEgrAD
        objAD.SpEliminarSumaIngEgr(ent)
        '\\
    End Sub

    Function obtenerSumaIngEgrExis(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        'ent.CampoCondicion1 = Cam.CodEmp
        'ent.DatoCondicion1 = ent.CodigoEmpresa
        Dim objAD As New SumaIngEgrAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function


    Function obtenerSumaIngEgrExisXEmpresa(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.CodEmp
        ent.DatoCondicion1 = ent.CodigoEmpresa
        Dim objAD As New SumaIngEgrAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerSumaIngEgrExisAct(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        Dim objAD As New SumaIngEgrAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerSumaIngEgrEli(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        Dim objAD As New SumaIngEgrAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function buscarSumaIngEgrExisPorClave(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaSumIngEgr
        ent.DatoCondicion1 = ent.ClaveSumaIngEgr
        Dim objAD As New SumaIngEgrAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarSumaIngEgrActPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = Cam.ClaSumIngEgr
        Dim objAD As New SumaIngEgrAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarSumaIngEgrEliPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaSumIngEgr
        Dim objAD As New SumaIngEgrAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarSumaIngEgrExisPorNombre(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaSumIngEgr
        Dim objAD As New SumaIngEgrAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function existeSumaIngEgrPorCodigo(ByRef ent As SuperEntidad) As Boolean
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = ""
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaSumIngEgr
        ent.DatoCondicion1 = ent.ClaveSumaIngEgr   '' llenado en el formulario

        Dim SumIngEgrAD As New SumaIngEgrAD
        obj = SumIngEgrAD.SpBuscarRegistroConUnaCondicion(ent)
        If obj.ClaveSumaIngEgr = "" Then
            Return False
        Else
            Return True
        End If
        '\\
    End Function


    Function ListarSumaIngEgrXOrigen(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim iSumIngEgrAD As New SumaIngEgrAD
        Return iSumIngEgrAD.ListarSumaIngEgrXOrigen(ent)

    End Function

    Function EsSumaIngEgrValido(ByRef pObj As SuperEntidad) As SuperEntidad
        Dim iSumIngEgrEN As New SuperEntidad

        'Cuando el periodo esta en blanco
        If pObj.CodigoSumaIngEgr = String.Empty Then
            iSumIngEgrEN.EsVerdad = True
            Return iSumIngEgrEN
        End If


        'Armando clave del periodo
        iSumIngEgrEN.ClaveSumaIngEgr += pObj.CodigoEmpresa
        iSumIngEgrEN.ClaveSumaIngEgr += pObj.CodigoSumaIngEgr

        'Buscar en BD
        iSumIngEgrEN = Me.buscarSumaIngEgrExisPorClave(iSumIngEgrEN)
        If iSumIngEgrEN.ClaveSumaIngEgr = String.Empty Then
            iSumIngEgrEN.EsVerdad = False
            iSumIngEgrEN.Mensaje = "La SumaIngEgr que digitaste no existe"
            Return iSumIngEgrEN
        End If

        If iSumIngEgrEN.EstadoSumaIngEgr = "0" Then
            iSumIngEgrEN.EsVerdad = False
            iSumIngEgrEN.Mensaje = "La SumaIngEgr que digitaste esta Desactivado"
            Return iSumIngEgrEN
        End If

        'Si todo esta OK
        iSumIngEgrEN.EsVerdad = True
        iSumIngEgrEN.Mensaje = String.Empty
        Return iSumIngEgrEN

    End Function


End Class
