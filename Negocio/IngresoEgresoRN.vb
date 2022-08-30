Imports Entidad
Imports Datos

Public Class IngresoEgresoRN
    Dim Cam As New CamposEntidad
    Const vista As String = "VsIngresoEgreso"

    Sub nuevaIngresoEgreso(ByRef ent As SuperEntidad)
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
        ent.ClaveIngresoEgreso = ent.CodigoEmpresa + ent.CodigoIngresoEgreso

        Dim objAD As New IngresoEgresoAD
        objAD.SpNuevoIngresoEgreso(ent)
        '\\
    End Sub

    Sub modificarIngresoEgreso(ByRef ent As SuperEntidad)
        '//
        '/Vovemos a traer el usuario actual de la b.d
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        '/Vovemos a traer el usuario actual de la b.d
        ''/Mandamos a modificar la b.d
        Dim objAD As New IngresoEgresoAD
        objAD.SpModificarIngresoEgreso(ent)
        '\\
    End Sub

    Sub eliminarIngresoEgresoLog(ByRef ent As SuperEntidad)
        '//
        '/Datos por defecto
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        ent.EliminadoRegistro = "0"
        '/Mandamos a modificar la b.d
        Dim objAD As New IngresoEgresoAD
        objAD.SpModificarIngresoEgreso(ent)
        '\\
    End Sub

    Sub eliminarIngresoEgresoFis(ByRef ent As SuperEntidad)
        '//
        '/Mandamos a modificar la b.d
        Dim objAD As New IngresoEgresoAD
        objAD.SpEliminarIngresoEgreso(ent)
        '\\
    End Sub

    Function obtenerIngresoEgresoExis(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        'ent.CampoCondicion1 = Cam.CodEmp
        'ent.DatoCondicion1 = ent.CodigoEmpresa
        Dim objAD As New IngresoEgresoAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function


    Function obtenerIngresoEgresoExisXEmpresa(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.CodEmp
        ent.DatoCondicion1 = ent.CodigoEmpresa
        Dim objAD As New IngresoEgresoAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerIngresoEgresoExisAct(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        Dim objAD As New IngresoEgresoAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerIngresoEgresoEli(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        Dim objAD As New IngresoEgresoAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function buscarIngresoEgresoExisPorClave(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaIngEgr
        ent.DatoCondicion1 = ent.ClaveIngresoEgreso
        Dim objAD As New IngresoEgresoAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarIngresoEgresoActPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = Cam.ClaIngEgr
        Dim objAD As New IngresoEgresoAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarIngresoEgresoEliPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaIngEgr
        Dim objAD As New IngresoEgresoAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarIngresoEgresoExisPorNombre(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaIngEgr
        Dim objAD As New IngresoEgresoAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function existeIngresoEgresoPorCodigo(ByRef ent As SuperEntidad) As Boolean
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = ""
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaIngEgr
        ent.DatoCondicion1 = ent.ClaveIngresoEgreso   '' llenado en el formulario

        Dim IngEgrAD As New IngresoEgresoAD
        obj = IngEgrAD.SpBuscarRegistroConUnaCondicion(ent)
        If obj.ClaveFlujoCaja = "" Then
            Return False
        Else
            Return True
        End If
        '\\
    End Function


    Function ListarIngresoEgresoXOrigen(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim iIngEgrAD As New IngresoEgresoAD
        Return iIngEgrAD.ListarIngresoEgresoXOrigen(ent)

    End Function

    Function EsIngresoEgresoValido(ByRef pObj As SuperEntidad) As SuperEntidad
        Dim iIngEgrEN As New SuperEntidad

        'Cuando el periodo esta en blanco
        If pObj.CodigoIngresoEgreso = String.Empty Then
            iIngEgrEN.EsVerdad = True
            Return iIngEgrEN
        End If


        'Armando clave del periodo
        iIngEgrEN.ClaveIngresoEgreso += pObj.CodigoEmpresa
        iIngEgrEN.ClaveIngresoEgreso += pObj.CodigoIngresoEgreso

        'Buscar en BD
        iIngEgrEN = Me.buscarIngresoEgresoExisPorClave(iIngEgrEN)
        If iIngEgrEN.ClaveIngresoEgreso = String.Empty Then
            iIngEgrEN.EsVerdad = False
            iIngEgrEN.Mensaje = "El Ingreso Egreso que digitaste no existe"
            Return iIngEgrEN
        End If

        If iIngEgrEN.EstadoIngresoEgreso = "0" Then
            iIngEgrEN.EsVerdad = False
            iIngEgrEN.Mensaje = "El Ingreso Egreso que digitaste esta Desactivado"
            Return iIngEgrEN
        End If

        'Si todo esta OK
        iIngEgrEN.EsVerdad = True
        iIngEgrEN.Mensaje = String.Empty
        Return iIngEgrEN

    End Function


End Class
