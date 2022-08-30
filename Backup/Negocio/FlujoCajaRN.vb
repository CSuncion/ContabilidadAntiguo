Imports Entidad
Imports Datos

Public Class FlujoCajaRN
    Dim Cam As New CamposEntidad
    Const vista As String = "VsFlujoCaja"

    Sub nuevaFlujoCaja(ByRef ent As SuperEntidad)
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
        ent.ClaveFlujoCaja = ent.CodigoEmpresa + ent.CodigoFlujoCaja

        Dim objAD As New FlujoCajaAD
        objAD.SpNuevoFlujoCaja(ent)
        '\\
    End Sub

    Sub modificarFlujoCaja(ByRef ent As SuperEntidad)
        '//
        '/Vovemos a traer el usuario actual de la b.d
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        '/Vovemos a traer el usuario actual de la b.d
        ''/Mandamos a modificar la b.d
        Dim objAD As New FlujoCajaAD
        objAD.SpModificarFlujoCaja(ent)
        '\\
    End Sub

    Sub eliminarFlujoCajaLog(ByRef ent As SuperEntidad)
        '//
        '/Datos por defecto
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        ent.EliminadoRegistro = "0"
        '/Mandamos a modificar la b.d
        Dim objAD As New FlujoCajaAD
        objAD.SpModificarFlujoCaja(ent)
        '\\
    End Sub

    Sub eliminarFlujoCajaFis(ByRef ent As SuperEntidad)
        '//
        '/Mandamos a modificar la b.d
        Dim objAD As New FlujoCajaAD
        objAD.SpEliminarFlujoCaja(ent)
        '\\
    End Sub

    Function obtenerFlujoCajaExis(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        'ent.CampoCondicion1 = Cam.CodEmp
        'ent.DatoCondicion1 = ent.CodigoEmpresa
        Dim objAD As New FlujoCajaAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function


    Function obtenerFlujoCajaExisXEmpresa(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.CodEmp
        ent.DatoCondicion1 = ent.CodigoEmpresa
        Dim objAD As New FlujoCajaAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerFlujoCajaExisAct(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        Dim objAD As New FlujoCajaAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerFlujoCajaEli(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        Dim objAD As New FlujoCajaAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function buscarFlujoCajaExisPorClave(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaFluCaj
        ent.DatoCondicion1 = ent.ClaveFlujoCaja
        Dim objAD As New FlujoCajaAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarFlujoCajaActPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = Cam.ClaFluCaj
        Dim objAD As New FlujoCajaAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarFlujoCajaEliPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaFluCaj
        Dim objAD As New FlujoCajaAD
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
        ent.CampoCondicion1 = Cam.ClaFluCaj
        Dim objAD As New FlujoCajaAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function existeFlujoCajaPorCodigo(ByRef ent As SuperEntidad) As Boolean
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = ""
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaFluCaj
        ent.DatoCondicion1 = ent.ClaveFlujoCaja   '' llenado en el formulario

        Dim FluCajAD As New FlujoCajaAD
        obj = FluCajAD.SpBuscarRegistroConUnaCondicion(ent)
        If obj.ClaveFlujoCaja = "" Then
            Return False
        Else
            Return True
        End If
        '\\
    End Function


    Function ListarFlujoCajaXOrigen(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim iFluCajAD As New FlujoCajaAD
        Return iFluCajAD.ListarFlujoCajaXOrigen(ent)

    End Function

    Function EsFlujoCajaValido(ByRef pObj As SuperEntidad) As SuperEntidad
        Dim iFluCEN As New SuperEntidad

        'Cuando el periodo esta en blanco
        If pObj.CodigoFlujoCaja = String.Empty Then
            iFluCEN.EsVerdad = True
            Return iFluCEN
        End If


        'Armando clave del periodo
        iFluCEN.ClaveFlujoCaja += pObj.CodigoEmpresa
        iFluCEN.ClaveFlujoCaja += pObj.CodigoFlujoCaja

        'Buscar en BD
        iFluCEN = Me.buscarFlujoCajaExisPorClave(iFluCEN)
        If iFluCEN.ClaveFlujoCaja = String.Empty Then
            iFluCEN.EsVerdad = False
            iFluCEN.Mensaje = "El Flujo Caja que digitaste no existe"
            Return iFluCEN
        End If

        If iFluCEN.EstadoFlujoCaja = "0" Then
            iFluCEN.EsVerdad = False
            iFluCEN.Mensaje = "El Flujo Caja que digitaste esta Desactivado"
            Return iFluCEN
        End If

        'Si todo esta OK
        iFluCEN.EsVerdad = True
        iFluCEN.Mensaje = String.Empty
        Return iFluCEN

    End Function


End Class
