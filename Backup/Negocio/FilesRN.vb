Imports Entidad
Imports Datos

Public Class FilesRN
    Dim Cam As New CamposEntidad
    Const vista As String = "VsFiles"

    Sub nuevaFiles(ByRef ent As SuperEntidad)
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

        Dim objAD As New FilesAD
        objAD.SpNuevoFiles(ent)
        '\\
    End Sub

    Sub modificarFiles(ByRef ent As SuperEntidad)
        '//
        '/Vovemos a traer el usuario actual de la b.d
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        '/Vovemos a traer el usuario actual de la b.d
        ''/Mandamos a modificar la b.d
        Dim objAD As New FilesAD
        objAD.SpModificarFiles(ent)
        '\\
    End Sub

    Sub eliminarFilesLog(ByRef ent As SuperEntidad)
        '//
        '/Datos por defecto
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        ent.EliminadoRegistro = "0"
        '/Mandamos a modificar la b.d
        Dim objAD As New FilesAD
        objAD.SpModificarFiles(ent)
        '\\
    End Sub

    Sub eliminarFilesFis(ByRef ent As SuperEntidad)
        '//
        '/Mandamos a modificar la b.d
        Dim objAD As New FilesAD
        objAD.SpEliminarFiles(ent)
        '\\
    End Sub

    Function obtenerFilesExis(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        'ent.CampoCondicion1 = Cam.CodEmp
        'ent.DatoCondicion1 = ent.CodigoEmpresa
        Dim objAD As New FilesAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function


    Function obtenerFilesExisXEmpresa(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
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

    Function obtenerFilesExisAct(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        Dim objAD As New FilesAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerFilesEli(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        Dim objAD As New FilesAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function buscarFilesExisPorClave(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaFil
        ent.DatoCondicion1 = ent.ClaveFile
        Dim objAD As New FilesAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarFilesActPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = Cam.ClaFil
        Dim objAD As New FilesAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarFilesEliPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaFil
        Dim objAD As New FilesAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarFilesExisPorNombre(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaFil
        Dim objAD As New FilesAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function existeFilesPorCodigo(ByRef ent As SuperEntidad) As Boolean
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = ""
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaFil
        ent.DatoCondicion1 = ent.ClaveFile    '' llenado en el formulario

        Dim filAD As New FilesAD
        obj = filAD.SpBuscarRegistroConUnaCondicion(ent)
        If obj.ClaveFile = "" Then
            Return False
        Else
            Return True
        End If
        '\\
    End Function

    Function ListarFilesXOrigen(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim iFilAD As New FilesAD
        Return iFilAD.ListarFilesXOrigen(ent)

    End Function

    Function ListarFilesTodos(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim iFilAD As New FilesAD
        Return iFilAD.ListarFilesTodos(ent)

    End Function

    Function HayFileDeApertura(ByRef ent As SuperEntidad) As SuperEntidad
        Dim iFilEN As New SuperEntidad
        iFilEN = Me.buscarFilesExisPorClave(ent)
        If iFilEN.ClaveFile = "" Then
            iFilEN.EsVerdad = False
            iFilEN.Mensaje = "Debes registrar el file 398"
            Return iFilEN
        End If
        iFilEN.EsVerdad = True
        iFilEN.Mensaje = ""
        Return iFilEN
    End Function

    Function obtenerFilesExisSinVoucherXAño(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        'LISTA RESULTADO
        Dim iLisFilRes As New List(Of SuperEntidad)

        'TRAER TODOS LOS FILE DE LA EMPRESA
        Dim iLisFil As List(Of SuperEntidad) = Me.obtenerFilesExisXEmpresa(ent)

        'TRAER TODOS LOS VOUCHER X EL AÑO
        Dim iVouRN As New VoucherRN
        Dim iVouEN As New SuperEntidad
        iVouEN.CodigoEmpresa = ent.CodigoEmpresa
        iVouEN.AnoVoucher = ent.AnoVoucher
        iVouEN.CampoOrden = Cam.ClaVou
        Dim iLisVou As List(Of SuperEntidad) = iVouRN.obtenerVoucherExisXAno(iVouEN)

        'SACAR SOLO LOS FILES QUE NO TIENEN VOUCHER
        Dim iObjEnc As Integer = 0
        For Each xFil As SuperEntidad In iLisFil
            For Each xVou As SuperEntidad In iLisVou
                If xFil.CodigoFile = xVou.CodigoFile Then
                    iObjEnc = 1
                    Exit For
                End If
            Next
            'PREGUNTAR SI EL OBJETO FUE ENCONTRADO
            If iObjEnc = 0 Then
                iLisFilRes.Add(xFil)
            End If
            iObjEnc = 0
        Next
        Return iLisFilRes
    End Function


    Function HayFileDeAsientoCierre(ByRef ent As SuperEntidad) As SuperEntidad
        Dim iFilEN As New SuperEntidad
        iFilEN = Me.buscarFilesExisPorClave(ent)
        If iFilEN.ClaveFile = "" Then
            iFilEN.EsVerdad = False
            iFilEN.Mensaje = "Debes registrar el file 397"
            Return iFilEN
        End If
        iFilEN.EsVerdad = True
        iFilEN.Mensaje = ""
        Return iFilEN
    End Function


End Class
