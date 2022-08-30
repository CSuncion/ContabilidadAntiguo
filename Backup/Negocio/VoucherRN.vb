Imports Entidad
Imports Datos

Public Class VoucherRN
    Dim Cam As New CamposEntidad
    Const vista As String = "VsVoucher"

    Function obtenerVoucherAutogenerado(ByRef ent As SuperEntidad) As String
        Dim objAD As New VoucherAD
        Return objAD.SpAutogenerarVoucher(ent)
    End Function


    Sub nuevaVoucher(ByRef ent As SuperEntidad)
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
        ent.ClaveVoucher = ent.CodigoEmpresa + ent.AnoVoucher + ent.CodigoFile

        Dim objAD As New VoucherAD
        objAD.SpNuevoVoucher(ent)
        '\\
    End Sub

    Sub nuevosVoucherParaNuevoAño(ByRef ent As SuperEntidad)
        'TRAEMOS A TODOS LOS FILES DE ESTA EMPRESA
        Dim iFilRN As New FilesRN
        Dim iFilEN As New SuperEntidad
        iFilEN.CodigoEmpresa = ent.CodigoEmpresa
        iFilEN.AnoVoucher = ent.AnoVoucher
        iFilEN.CampoOrden = Cam.ClaFil
        Dim iLisFil As List(Of SuperEntidad) = iFilRN.obtenerFilesExisSinVoucherXAño(iFilEN)

        'LISTA DE LLOS NUEVOS VOUCHER PARA LUEGO GRABAR
        Dim iLisVou As New List(Of SuperEntidad)
        For Each xFil As SuperEntidad In iLisFil
            Dim iVouEN As New SuperEntidad
            iVouEN.CodigoEmpresa = ent.CodigoEmpresa
            iVouEN.AnoVoucher = ent.AnoVoucher
            iVouEN.CodigoFile = xFil.CodigoFile
            iVouEN.Exporta = "0"
            iVouEN.EstadoVoucher = "1"
            iVouEN.EstadoRegistro = "1"
            iVouEN.EliminadoRegistro = "1"
            iVouEN.ClaveVoucher = iVouEN.CodigoEmpresa + iVouEN.AnoVoucher + iVouEN.CodigoFile
            iLisVou.Add(iVouEN)
        Next
        'GRABANDO TODOS LOS OBJETOS DE LA LISTA
        Dim objAD As New VoucherAD
        objAD.NuevoVoucherMasivo(iLisVou)
    End Sub

    Sub modificarVoucher(ByRef ent As SuperEntidad)
        '//
        '/Vovemos a traer el usuario actual de la b.d
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        '/Vovemos a traer el usuario actual de la b.d
        ''/Mandamos a modificar la b.d
        Dim objAD As New VoucherAD
        objAD.SpModificarVoucher(ent)
        '\\
    End Sub

    Sub eliminarVoucherLog(ByRef ent As SuperEntidad)
        '//
        '/Datos por defecto
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        ent.EliminadoRegistro = "0"
        '/Mandamos a modificar la b.d
        Dim objAD As New VoucherAD
        objAD.SpModificarvoucher(ent)
        '\\
    End Sub

    Sub eliminarVoucherFis(ByRef ent As SuperEntidad)
        '//
        '/Mandamos a modificar la b.d
        Dim objAD As New VoucherAD
        objAD.SpEliminarVoucher(ent)
        '\\
    End Sub

    Function obtenerVoucherExis(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.CodEmp
        ent.DatoCondicion1 = ent.CodigoEmpresa
        Dim objAD As New VoucherAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerVoucherExisAct(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        Dim objAD As New VoucherAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerVoucherEli(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        Dim objAD As New VoucherAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function buscarVoucherExisPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaVou
        ent.DatoCondicion1 = ent.ClaveVoucher
        Dim objAD As New VoucherAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarVoucherActPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = Cam.ClaVou
        Dim objAD As New VoucherAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarVoucherEliPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaVou
        Dim objAD As New VoucherAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarVoucherExisPorNombre(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaVou
        Dim objAD As New VoucherAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function existeVoucherPorCodigo(ByRef ent As SuperEntidad) As Boolean
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = ""
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaVou
        ent.DatoCondicion1 = ent.ClaveVoucher    '' llenado en el formulario

        Dim bcoAD As New VoucherAD
        obj = bcoAD.SpBuscarRegistroConUnaCondicion(ent)
        If obj.ClaveVoucher = "" Then
            Return False
        Else
            Return True
        End If
        '\\
    End Function

    Function obtenerVoucherExisXEmpresaYFile(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.CodEmp
        ent.DatoCondicion1 = ent.CodigoEmpresa
        ent.CampoCondicion2 = Cam.CodFilRC
        ent.DatoCondicion2 = ent.CodigoFile
        Dim objAD As New VoucherAD
        listObj = objAD.SpObtenerRegistrosConDosCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerVoucherExisXAno(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.CodEmp
        ent.DatoCondicion1 = ent.CodigoEmpresa
        ent.CampoCondicion2 = Cam.AnoVou
        ent.DatoCondicion2 = ent.AnoVoucher
        Dim objAD As New VoucherAD
        listObj = objAD.SpObtenerRegistrosConDosCondicion(ent)
        Return listObj
        '\\
    End Function

    Function HayNumeroVoucherGeneradoEnPeriodo(ByVal ent As SuperEntidad, ByVal pNumeroMes As String) As Boolean

        'CARGAR LA LISTA DE LOS VOUCHER DEL ANO
        ent.CampoOrden = Cam.ClaVou
        Dim ilisVou As List(Of SuperEntidad) = Me.obtenerVoucherExisXAno(ent)

        'RECORREMOS SOLO EL MES EN CUESTION
        For Each xVou As SuperEntidad In ilisVou

            'SEGUN MES
            Select Case pNumeroMes
                Case "00" : If xVou.AperturaVoucher <> "00000" Then Return True
                Case "01" : If xVou.EneroVoucher <> "00000" Then Return True
                Case "02" : If xVou.FebreroVoucher <> "00000" Then Return True
                Case "03" : If xVou.MarzoVoucher <> "00000" Then Return True
                Case "04" : If xVou.AbrilVoucher <> "00000" Then Return True
                Case "05" : If xVou.MayoVoucher <> "00000" Then Return True
                Case "06" : If xVou.JunioVoucher <> "00000" Then Return True
                Case "07" : If xVou.JulioVoucher <> "00000" Then Return True
                Case "08" : If xVou.AgostoVoucher <> "00000" Then Return True
                Case "09" : If xVou.SetiembreVoucher <> "00000" Then Return True
                Case "10" : If xVou.OctubreVoucher <> "00000" Then Return True
                Case "11" : If xVou.NoviembreVoucher <> "00000" Then Return True
                Case "12" : If xVou.DiciembreVoucher <> "00000" Then Return True
            End Select
        Next
        Return False

    End Function

End Class
