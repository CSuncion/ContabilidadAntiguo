Imports Entidad
Imports Datos

Public Class FileRN
    Dim Cam As New CamposEntidad
    Const vista As String = "VsFile"

    Function obtenerVoucherAutogenerado(ByRef ent As SuperEntidad) As String
        Dim objAD As New FileAD
        Return objAD.SpAutogenerarFile(ent)
    End Function


    Sub nuevaFile(ByRef ent As SuperEntidad)
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
        ent.ClaveFile = ent.CodigoEmpresa + ent.CodigoFile

        Dim objAD As New FileAD
        objAD.SpNuevoFile(ent)
        '\\
    End Sub

    Sub modificarFile(ByRef ent As SuperEntidad)
        '//
        '/Vovemos a traer el usuario actual de la b.d
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        '/Vovemos a traer el usuario actual de la b.d
        ''/Mandamos a modificar la b.d
        Dim objAD As New FileAD
        objAD.SpModificarFile(ent)
        '\\
    End Sub

    Sub eliminarFileLog(ByRef ent As SuperEntidad)
        '//
        '/Datos por defecto
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        ent.EliminadoRegistro = "0"
        '/Mandamos a modificar la b.d
        Dim objAD As New FileAD
        objAD.SpModificarFile(ent)
        '\\
    End Sub

    Sub eliminarFileFis(ByRef ent As SuperEntidad)
        '//
        '/Mandamos a modificar la b.d
        Dim objAD As New FileAD
        objAD.SpEliminarFile(ent)
        '\\
    End Sub

    Function obtenerFileExis(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.CodEmp
        ent.DatoCondicion1 = ent.CodigoEmpresa
        Dim objAD As New FilesAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerFileExisAct(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        Dim objAD As New FileAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerFileEli(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        Dim objAD As New FileAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function buscarFileExisPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaVou
        ent.DatoCondicion1 = ent.ClaveVoucher
        Dim objAD As New FileAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarFileActPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = Cam.ClaVou
        Dim objAD As New FileAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarFileEliPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaVou
        Dim objAD As New FileAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarFileExisPorNombre(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaVou
        Dim objAD As New FileAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function existeFilePorCodigo(ByRef ent As SuperEntidad) As Boolean
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = ""
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaFil
        ent.DatoCondicion1 = ent.ClaveFile    '' llenado en el formulario

        Dim bcoAD As New FilesAD
        obj = bcoAD.SpBuscarRegistroConUnaCondicion(ent)
        If obj.ClaveVoucher = "" Then
            Return False
        Else
            Return True
        End If
        '\\
    End Function

End Class
