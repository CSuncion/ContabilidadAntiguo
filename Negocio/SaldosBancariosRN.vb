Imports Entidad
Imports Datos

Public Class SaldosBancariosRN
    Dim Cam As New CamposEntidad
    Const vista As String = "VsSaldosBancarios"

    Sub nuevaSaldosBancarios(ByRef ent As SuperEntidad)
        '//
        '/Estos Datos son por defecto cada vez que agregue un nuevo usuario
        'ent.FlagTipoCuentaPcge = "1" '/Cuando no se captura en el formulario
        ent.Exporta = "0"
        ent.EstadoCuenta = "1"
        ent.EstadoRegistro = "1"
        ent.EliminadoRegistro = "1"
        ent.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioAgrega = SuperEntidad.xNombreUsuario
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        'ent.ClaveCuentaBanco = ent.CodigoEmpresa + ent.CodigoCuentaBanco
        ent.IngresosSolCuentaBanco = 0
        ent.SalidasSolCuentaBanco = 0
        ent.SaldoMesSolCuentaBanco = 0
        ent.IngresosDolCuentaBanco = 0
        ent.SalidasDolCuentaBanco = 0
        ent.SaldoMesDolCuentaBanco = 0
        ent.IngresosSolAntCuentaBanco = 0
        ent.SalidasSolAntCuentaBanco = 0
        ent.SaldoMesSolAntCuentaBanco = 0
        ent.IngresosDolAntCuentaBanco = 0
        ent.SalidasDolAntCuentaBanco = 0
        ent.SaldoMesDolAntCuentaBanco = 0

        Dim objAD As New SaldosBancariosAD
        objAD.SpNuevoSaldosBancarios(ent)
        '\\
    End Sub

    Sub modificarSaldosBancarios(ByRef ent As SuperEntidad)
        '//
        '/Vovemos a traer el usuario actual de la b.d
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        '/Vovemos a traer el usuario actual de la b.d

        ''/Mandamos a modificar la b.d
        Dim objAD As New SaldosBancariosAD
        objAD.SpModificarSaldpsBancarios(ent)
        '\\
    End Sub

    Sub eliminarSaldosBancariosLog(ByRef ent As SuperEntidad)
        '//
        '/Datos por defecto
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        ent.EliminadoRegistro = "0"
        '/Mandamos a modificar la b.d
        Dim objAD As New SaldosBancariosAD
        objAD.SpModificarSaldpsBancarios(ent)
        '\\
    End Sub

    Sub eliminarSaldosBancariosFis(ByRef ent As SuperEntidad)
        '//
        '/Mandamos a modificar la b.d
        Dim objAD As New SaldosBancariosAD
        objAD.SpEliminarSaldosBancarios(ent)
        '\\
    End Sub

    Function obtenerSaldosBancariosExis(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.CodEmp
        ent.DatoCondicion1 = ent.CodigoEmpresa
        'ent.DatoCondicion1 = SuperEntidad.xCodigoEmpresa
        Dim objAD As New SaldosBancariosAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
        'listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerSaldosBancariosExisAct(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        Dim objAD As New SaldosBancariosAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerSaldosBancariosEli(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        Dim objAD As New SaldosBancariosAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function ObtenerSaldosBancariosExisPorEmpresa(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.CodEmp
        ent.DatoCondicion1 = ent.CodigoEmpresa
        Dim objAD As New SaldosBancariosAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function


    Function buscarSaldosBancariosExisPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaCtaBco
        ent.DatoCondicion1 = ent.ClaveCuentaBanco
        Dim objAD As New SaldosBancariosAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarSaldosBancariosActPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = Cam.CodCtaBco
        Dim objAD As New SaldosBancariosAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function


    Function buscarSaldosBancariosExisPorClave(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaSalBan
        ent.DatoCondicion1 = ent.ClaveSaldosBancarios
        Dim objAD As New SaldosBancariosAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarSaldosBancariosEliPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "0"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaCtaBco
        Dim objAD As New SaldosBancariosAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function buscarSaldosBancariosExisPorNombre(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.BcoCtaBco
        Dim objAD As New SaldosBancariosAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function existeSaldosBancariosPorCodigo(ByRef ent As SuperEntidad) As Boolean
        '//
        Dim obj As New SuperEntidad
        ent.Vista = vista
        ent.DatoEliminado = ""
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.CodCtaBco
        ent.DatoCondicion1 = ent.CodigoCuentaBanco

        Dim bcoAD As New SaldosBancariosAD
        obj = bcoAD.SpBuscarRegistroConUnaCondicion(ent)
        If obj.CodigoCuentaBanco = "" Then
            Return False
        Else
            Return True
        End If
        '\\
    End Function

    Sub GeneraSaldosBancarios(ByRef ent As SuperEntidad)
        Dim osb As New SuperEntidad
        osb.ClaveCuentaBanco = ent.ClaveCuentaBanco
        osb.AnoCuentaBanco = SuperEntidad.xPeriodoEmpresa.Substring(0, 4)

        For n As Integer = 1 To 12
            osb.MesCuentaBanco = (n).ToString.PadLeft(2, CType("0", Char))
            osb.ClaveSaldosBancarios = osb.ClaveCuentaBanco + osb.AnoCuentaBanco + osb.MesCuentaBanco
            Me.nuevaSaldosBancarios(osb)
        Next
    End Sub

    Function EsCuentaBancoConSaldo(ByRef ent As SuperEntidad) As Boolean
        '//
        Dim lis As New List(Of SuperEntidad)

        lis = Me.ObtenerSaldosBancariosExisPorCuenta(ent)
        If lis.Count = 0 Then
            Return False
        Else
            Return True
        End If
        '\\
    End Function


    Function ObtenerSaldosBancariosExisPorCuentaYMes(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim lis As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaCtaBco
        ent.DatoCondicion1 = ent.ClaveCuentaBanco
        ent.CampoCondicion2 = Cam.AnoCtaBco
        ent.DatoCondicion2 = ent.AnoCuentaBanco
        ent.CampoCondicion3 = Cam.MesCtaBco
        ent.DatoCondicion3 = ent.MesCuentaBanco
        ent.CampoOrden = Cam.ClaCtaBco

        Dim objAD As New SaldosBancariosAD
        lis = objAD.SpObtenerRegistrosConDosCondicionYMayorQue(ent)
        Return lis
        '\\
    End Function


    Function ObtenerSaldosBancariosExisPorEmpresaXAnoYMes(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim lis As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.CodEmp
        ent.DatoCondicion1 = SuperEntidad.xCodigoEmpresa
        ent.CampoCondicion2 = Cam.AnoCtaBco
        ent.DatoCondicion2 = ent.AnoCuentaBanco
        ent.CampoCondicion3 = Cam.MesCtaBco
        ent.DatoCondicion3 = ent.MesCuentaBanco
        ent.CampoOrden = Cam.ClaCtaBco

        Dim objAD As New SaldosBancariosAD
        lis = objAD.SpObtenerRegistrosConTresCondicion(ent)
        Return lis
        '\\
    End Function



    Function ObtenerSaldosBancariosExisPorCuenta(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim lis As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.ClaCtaBco
        ent.DatoCondicion1 = ent.ClaveCuentaBanco
        ent.CampoCondicion2 = Cam.AnoCtaBco
        ent.DatoCondicion2 = ent.AnoCuentaBanco
        'ent.CampoCondicion3 = Cam.MesCtaBco
        'ent.DatoCondicion3 = ent.MesCuentaBanco
        ent.CampoOrden = Cam.ClaCtaBco

        Dim objAD As New SaldosBancariosAD
        lis = objAD.SpObtenerRegistrosConDosCondicion(ent)
        Return lis
        '\\
    End Function


    Function ListarSaldosBancariosExisActPorEmpresaXAnoYMes(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//

        Dim objAD As New SaldosBancariosAD

        Return objAD.ListarSaldosBancariosExisActPorEmpresaXAnoYMes(ent)
        '\\
    End Function


    Function ListarSaldosBancariosParaCierreAnual(ByRef ent As SuperEntidad) As List(Of List(Of SuperEntidad))
        Dim objAD As New SaldosBancariosAD
        Return objAD.ListarSaldosBancariosParaCierreAnual(ent)
    End Function


    Sub NuevoSaldosBancariosMasivo(ByRef pLista As List(Of SuperEntidad))
        Dim objAD As New SaldosBancariosAD
        objAD.NuevoSaldosBancariosMasivo(pLista)
        '\\
    End Sub


    Sub EliminarSaldosBancariosXEmpresaYAno(ByRef ent As SuperEntidad)
        Dim objAD As New SaldosBancariosAD
        objAD.EliminarSaldosBancariosXEmpresaYAno(ent)
    End Sub


End Class
