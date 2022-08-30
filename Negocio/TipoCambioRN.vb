Imports Entidad
Imports Datos
Public Class TipoCambioRN
    Dim cam As New CamposEntidad

    Sub nuevoTipoCambio(ByRef ent As SuperEntidad)
        '//
        '/Estos Datos son por defecto cada vez que agregue un nuevo usuario
        '/Estos Datos son por defecto cada vez que agregue un nuevo usuario
       
        ent.EstadoRegistro = "1"
        ent.EliminadoRegistro = "1"
        ent.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioAgrega = SuperEntidad.xNombreUsuarioModifica
        'ent.CodigoPersonalAgrega = SuperEntidad.xCodigoPersonal
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuarioModifica
        'ent.CodigoPersonalModifica = SuperEntidad.xCodigoPersonal
        ent.AnoTipoCambio = ent.FechaTipoCambio.Year.ToString
        ent.MesTipoCambio = ent.FechaTipoCambio.Month.ToString
        Dim objAD As New TipoCambioAD
        objAD.SpNuevoTipoCambio(ent)
        '\\
    End Sub

    Sub modificarTipoCambio(ByRef ent As SuperEntidad)
        '//
        '/Vovemos a traer el usuario actual de la b.d
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuarioModifica
        '/Vovemos a traer el usuario actual de la b.d
    
        ''/Mandamos a modificar la b.d
        Dim objAD As New TipoCambioAD
        objAD.SpModificarTipoCambio(ent)
        '\\
    End Sub

    Sub EliminarTipoCambioLog(ByRef ent As SuperEntidad)
        '//
        '/Datos por defecto
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuarioModifica
        ent.EliminadoRegistro = "0"
        '/Mandamos a modificar la b.d
        Dim objAD As New TipoCambioAD
        objAD.SpModificarTipoCambio(ent)
        '\\
    End Sub

    Sub eliminarTipoCambioFis(ByRef ent As SuperEntidad)
        '//
        Dim objAD As New TipoCambioAD
        objAD.SpEliminarTipoCambio(ent)
        '\\
    End Sub

    Function obtenerTiposCambiosExis(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsTipoCambio"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        Dim objAD As New TipoCambioAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerTiposCambiosEli(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsTipoCambio"
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        Dim objAD As New TipoCambioAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function buscarTipoCambioExisPorFecha(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsTipoCambio"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.FecTipCam
        Dim objAD As New TipoCambioAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarTipoCambioEliPorFecha(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsTipoCambio"
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.FecTipCam
        Dim objAD As New TipoCambioAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function existeTipoCambioPorFecha(ByRef ent As SuperEntidad) As Boolean
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsTipoCambio"
        ent.DatoEliminado = ""
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.FecTipCam
        Dim objAD As New TipoCambioAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        If obj.AnoTipoCambio = "" Then
            Return False
        Else
            Return True
        End If
        '\\
    End Function

    Function obtenerTiposCambiosExisXPeriodo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsTipoCambio"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.AnoTipCam
        ent.DatoCondicion1 = ent.AnoTipoCambio
        ent.CampoCondicion2 = cam.MesTipCam
        ent.DatoCondicion2 = ent.MesTipoCambio
        Dim objAD As New TipoCambioAD
        listObj = objAD.SpObtenerRegistrosConDosCondicion(ent)
        Return listObj
        '\\
    End Function

    Function ObtenerUltimoTipoCambioDelMes(ByRef ent As SuperEntidad) As SuperEntidad
        Dim iTipCam As New SuperEntidad
        ent.CampoOrden = cam.FecTipCam
        ent.MesTipoCambio = CType(ent.MesTipoCambio, Integer).ToString
        Dim iLisTipCam As List(Of SuperEntidad) = Me.obtenerTiposCambiosExisXPeriodo(ent)
        Dim iNro As Integer = iLisTipCam.Count
        If iNro = 0 Then
            iTipCam.VentaTipoCambio = 1
            iTipCam.CompraTipoCambio = 1
            iTipCam.VentaEurTipoCambio = 1
            iTipCam.CompraEurTipoCambio = 1
        Else
            iTipCam.VentaTipoCambio = iLisTipCam.Item(iNro - 1).VentaTipoCambio
            iTipCam.CompraTipoCambio = iLisTipCam.Item(iNro - 1).CompraTipoCambio
            iTipCam.VentaEurTipoCambio = iLisTipCam.Item(iNro - 1).VentaEurTipoCambio
            iTipCam.CompraEurTipoCambio = iLisTipCam.Item(iNro - 1).CompraEurTipoCambio
        End If
        Return iTipCam
    End Function

    Function ObtenerUltimoDiaDelMes(ByRef ent As SuperEntidad) As SuperEntidad
        Dim iTipCam As New SuperEntidad
        ent.CampoOrden = cam.FecTipCam
        ent.MesTipoCambio = CType(ent.MesTipoCambio, Integer).ToString
        Dim iLisTipCam As List(Of SuperEntidad) = Me.obtenerTiposCambiosExisXPeriodo(ent)
        Dim iNro As Integer = iLisTipCam.Count
        If iNro = 0 Then
            iTipCam.FechaTipoCambio = CType("01/" + ent.MesCreadoSaldoContable.PadLeft(2, CType("0", Char)) + "/" + ent.AnoTipoCambio, Date)
        Else
            iTipCam.FechaTipoCambio = iLisTipCam.Item(iNro - 1).FechaTipoCambio
        End If
        Return iTipCam
    End Function


End Class
