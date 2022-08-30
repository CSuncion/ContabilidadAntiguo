Imports Entidad
Imports Datos

Public Class GastoReparableRN
    Dim Cam As New CamposEntidad
    Const vista As String = "VsGastoReparable"

    Sub nuevaGastoReparable(ByRef ent As SuperEntidad)
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
        ent.ClaveGastoReparable = ent.CodigoEmpresa + ent.CodigoGastoReparable

        Dim objAD As New GastoReparableAD
        objAD.SpNuevoGastoReparable(ent)
        '\\
    End Sub

    Sub modificarGastoReparable(ByRef ent As SuperEntidad)
        '//
        '/Vovemos a traer el usuario actual de la b.d
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        '/Vovemos a traer el usuario actual de la b.d
        ''/Mandamos a modificar la b.d
        Dim objAD As New GastoReparableAD
        objAD.SpModificarGastoReparable(ent)
        '\\
    End Sub

    Sub eliminarGastoReparableLog(ByRef ent As SuperEntidad)
        '//
        '/Datos por defecto
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        ent.EliminadoRegistro = "0"
        '/Mandamos a modificar la b.d
        Dim objAD As New GastoReparableAD
        objAD.SpModificarGastoReparable(ent)
        '\\
    End Sub

    Sub eliminarGastoReparableFis(ByRef ent As SuperEntidad)
        '//
        '/Mandamos a modificar la b.d
        Dim objAD As New GastoReparableAD
        objAD.SpEliminarGastoReparable(ent)
        '\\
    End Sub

    Function obtenerGastoReparableExis(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        'ent.CampoCondicion1 = Cam.CodEmp
        'ent.DatoCondicion1 = ent.CodigoEmpresa
        Dim objAD As New GastoReparableAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function


    Function obtenerGastoReparableExisXEmpresa(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.CodEmp
        ent.DatoCondicion1 = ent.CodigoEmpresa
        Dim objAD As New GastoReparableAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerGastoReparableExisAct(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        Dim objAD As New GastoReparableAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerGastoReparableEli(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        Dim objAD As New GastoReparableAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function buscarGastoReparableExisPorClave(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaGasRep
        ent.DatoCondicion1 = ent.ClaveGastoReparable
        Dim objAD As New GastoReparableAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarGastoReparableActPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = Cam.ClaGasRep
        Dim objAD As New GastoReparableAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarGastoReparableEliPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaGasRep
        Dim objAD As New GastoReparableAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarFlujoCajaExisPorNombre(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaGasRep
        Dim objAD As New GastoReparableAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function existeGastoReparablePorCodigo(ByRef ent As SuperEntidad) As Boolean
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = ""
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaGasRep
        ent.DatoCondicion1 = ent.ClaveGastoReparable   '' llenado en el formulario

        Dim GasRepAD As New GastoReparableAD
        obj = GasRepAD.SpBuscarRegistroConUnaCondicion(ent)
        If obj.ClaveGastoReparable = "" Then
            Return False
        Else
            Return True
        End If
        '\\
    End Function


    Function ListarGastoReparableXOrigen(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim iGasRepAD As New GastoReparableAD
        Return iGasRepAD.ListarGastoReparableXOrigen(ent)

    End Function

    Function EsGastoReparableValido(ByRef pObj As SuperEntidad) As SuperEntidad
        Dim iGasRepEN As New SuperEntidad

        'Cuando el periodo esta en blanco
        If pObj.CodigoGastoReparable = String.Empty Then
            iGasRepEN.EsVerdad = True
            Return iGasRepEN
        End If


        'Armando clave del periodo
        iGasRepEN.ClaveGastoReparable += pObj.CodigoEmpresa
        iGasRepEN.ClaveGastoReparable += pObj.CodigoGastoReparable

        'Buscar en BD
        iGasRepEN = Me.buscarGastoReparableExisPorClave(iGasRepEN)
        If iGasRepEN.ClaveGastoReparable = String.Empty Then
            iGasRepEN.EsVerdad = False
            iGasRepEN.Mensaje = "El Codigo Almacen  que digitaste no existe"
            Return iGasRepEN
        End If

        If iGasRepEN.EstadoGastoReparable = "0" Then
            iGasRepEN.EsVerdad = False
            iGasRepEN.Mensaje = "El Codigo Almacen que digitaste esta Desactivado"
            Return iGasRepEN
        End If

        If iGasRepEN.CodigoGastoReparable.Length < 8 Then
            iGasRepEN.EsVerdad = False
            iGasRepEN.Mensaje = "El Codigo Almacen que digitaste debe ser Analitico"
            Return iGasRepEN
        End If

        'Si todo esta OK
        iGasRepEN.EsVerdad = True
        iGasRepEN.Mensaje = String.Empty
        Return iGasRepEN

    End Function


End Class
