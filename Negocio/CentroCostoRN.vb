Imports Entidad
Imports Datos

Public Class CentroCostoRN
    Dim Cam As New CamposEntidad
    Const vista As String = "VsCentroCosto"

    Sub nuevaCentroCosto(ByRef ent As SuperEntidad)
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
        ent.ClaveCentroCosto = ent.CodigoEmpresa + ent.CodigoCentroCosto

        Dim objAD As New CentroCostoAD
        objAD.SpNuevoCentroCosto(ent)
        '\\
    End Sub

    Sub modificarCentroCosto(ByRef ent As SuperEntidad)
        '//
        '/Vovemos a traer el usuario actual de la b.d
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        '/Vovemos a traer el usuario actual de la b.d
        ''/Mandamos a modificar la b.d
        Dim objAD As New CentroCostoAD
        objAD.SpModificarCentroCosto(ent)
        '\\
    End Sub

    Sub eliminarCentroCostoLog(ByRef ent As SuperEntidad)
        '//
        '/Datos por defecto
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        ent.EliminadoRegistro = "0"
        '/Mandamos a modificar la b.d
        Dim objAD As New CentroCostoAD
        objAD.SpModificarCentroCosto(ent)
        '\\
    End Sub

    Sub eliminarCentroCostoFis(ByRef ent As SuperEntidad)
        '//
        '/Mandamos a modificar la b.d
        Dim objAD As New CentroCostoAD
        objAD.SpEliminarCentroCosto(ent)
        '\\
    End Sub

    Function obtenerCentroCostoExis(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        'ent.CampoCondicion1 = Cam.CodEmp
        'ent.DatoCondicion1 = ent.CodigoEmpresa
        Dim objAD As New CentroCostoAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function


    Function obtenerCentroCostoExisXEmpresa(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.CodEmp
        ent.DatoCondicion1 = ent.CodigoEmpresa
        Dim objAD As New CentroCostoAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerCentroCostoExisAct(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        Dim objAD As New CentroCostoAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerCentroCostoEli(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        Dim objAD As New CentroCostoAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function buscarCentroCostoExisPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaCenCto
        ent.DatoCondicion1 = ent.ClaveCentroCosto
        Dim objAD As New CentroCostoAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarCentroCostoActPorClave(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = Cam.ClaCenCto
        Dim objAD As New CentroCostoAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarCentroCostoEliPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaCenCto
        Dim objAD As New CentroCostoAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarCentroCostoExisPorNombre(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaCenCto
        Dim objAD As New CentroCostoAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function existeCentroCostoPorCodigo(ByRef ent As SuperEntidad) As Boolean
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = ""
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaCenCto
        ent.DatoCondicion1 = ent.ClaveCentroCosto   '' llenado en el formulario

        Dim CenCtoAD As New CentroCostoAD
        obj = CenCtoAD.SpBuscarRegistroConUnaCondicion(ent)
        If obj.ClaveCentroCosto = "" Then
            Return False
        Else
            Return True
        End If
        '\\
    End Function


    Function ListarCentroCostoXOrigen(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim iCenCtoAD As New CentroCostoAD
        Return iCenCtoAD.ListarCentroCostoXOrigen(ent)

    End Function

    Function EsCentroCostoValido(ByRef pObj As SuperEntidad) As SuperEntidad
        Dim iCCosEN As New SuperEntidad

        'Cuando el periodo esta en blanco
        If pObj.CodigoCentroCosto = String.Empty Then
            iCCosEN.EsVerdad = True
            Return iCCosEN
        End If


        'Armando clave del periodo
        iCCosEN.ClaveCentroCosto += pObj.CodigoEmpresa
        iCCosEN.ClaveCentroCosto += pObj.CodigoCentroCosto

        'Buscar en BD
        iCCosEN = Me.buscarCentroCostoExisPorCodigo(iCCosEN)
        If iCCosEN.ClaveCentroCosto = String.Empty Then
            iCCosEN.EsVerdad = False
            iCCosEN.Mensaje = "El Centro Costo que digitaste no existe"
            Return iCCosEN
        End If

        'Si todo esta OK
        iCCosEN.EsVerdad = True
        iCCosEN.Mensaje = String.Empty
        Return iCCosEN

    End Function


    Function EsCentroCostoActivoValido(ByRef pObj As SuperEntidad) As SuperEntidad
        Dim iCCosEN As New SuperEntidad

        'Cuando el periodo esta en blanco
        If pObj.CodigoCentroCosto = String.Empty Then
            iCCosEN.EsVerdad = True
            Return iCCosEN
        End If


        'Armando clave del periodo
        iCCosEN.ClaveCentroCosto += pObj.CodigoEmpresa
        iCCosEN.ClaveCentroCosto += pObj.CodigoCentroCosto

        'Buscar en BD
        iCCosEN = Me.buscarCentroCostoExisPorCodigo(iCCosEN)
        If iCCosEN.ClaveCentroCosto = String.Empty Then
            iCCosEN.EsVerdad = False
            iCCosEN.Mensaje = "El Centro Costo que digitaste no existe"
            Return iCCosEN
        End If

        If iCCosEN.EstadoCentroCosto = "Cerrada" Then
            iCCosEN.EsVerdad = False
            iCCosEN.Mensaje = "El Centro Costo que digitaste esta Desactivado"
            Return iCCosEN
        End If

        'Si todo esta OK
        iCCosEN.EsVerdad = True
        iCCosEN.Mensaje = String.Empty
        Return iCCosEN

    End Function


End Class
