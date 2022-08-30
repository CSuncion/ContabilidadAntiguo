Imports Entidad
Imports Datos

Public Class CuentaEmpresaRN
      Dim Cam As New CamposEntidad
      Const vista As String = "VsPlanCuentaGe"


      Sub nuevaCuenta(ByRef ent As SuperEntidad)
            '//
            '/Estos Datos son por defecto cada vez que agregue un nuevo usuario
            ent.FlagTipoCuentaPcge = "1"
            ent.EstadoCuenta = "1"
            ent.EstadoRegistro = "1"
            ent.EliminadoRegistro = "1"
            ent.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
            ent.NombreUsuarioAgrega = SuperEntidad.xNombreUsuario
            ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
            ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
            ent.NumeroDigitosPcge = ent.CodigoCuentaPcge.Length.ToString
            ent.ClaveCuentaPcge = ent.CodigoEmpresa + ent.CodigoCuentaPcge

            Dim objAD As New CuentaEmpresaAD
            objAD.SpNuevoPlanCuentaGe(ent)
            '\\
      End Sub

      Sub modificarCuenta(ByRef ent As SuperEntidad)
            '//
            '/Vovemos a traer el usuario actual de la b.d
            ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
            ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
            'ent.NumeroDigitosPcge = ent.CodigoCuentaPcge.Length.ToString
            '/Vovemos a traer el usuario actual de la b.d

            ''/Mandamos a modificar la b.d
            Dim objAD As New CuentaEmpresaAD
            objAD.SpModificarPlanCuentaGe(ent)
            '\\
      End Sub


      Sub eliminarCuentaLog(ByRef ent As SuperEntidad)
            '//
            '/Datos por defecto
            ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
            ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
            ent.EliminadoRegistro = "0"
            '/Mandamos a modificar la b.d
            Dim objAD As New CuentaEmpresaAD
            objAD.SpModificarPlanCuentaGe(ent)
            '\\
      End Sub

      Sub eliminarCuentaFis(ByRef ent As SuperEntidad)
            '//
            '/Mandamos a modificar la b.d
            Dim objAD As New CuentaEmpresaAD
            objAD.SpEliminarPlanCuentaGe(ent)
            '\\
      End Sub

      Sub eliminarCuentasPorEmpresaFis(ByRef ent As SuperEntidad)
            '//
            '/Mandamos a modificar la b.d
            Dim objAD As New CuentaEmpresaAD
            objAD.SpEliminarPlanCuentasGePorEmpresa(ent)
            '\\
      End Sub

      Function obtenerCuentaExis(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
            '//
            Dim listObj As New List(Of SuperEntidad)
            ent.Vista = vista
            ent.DatoEliminado = "1"
            ent.DatoEstado = ""
            ent.CampoCondicion1 = Cam.CodEmp
            ent.DatoCondicion1 = ent.CodigoEmpresa
            Dim objAD As New CuentaEmpresaAD
            listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
            Return listObj
            '\\
      End Function

      Function obtenerCuentaExisAutomaticas(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
            '//
            Dim listObj As New List(Of SuperEntidad)
            ent.Vista = vista
            ent.DatoEliminado = "1"
            ent.DatoEstado = ""
            ent.CampoCondicion1 = Cam.FlaAutPcge
            ent.DatoCondicion1 = ent.FlagAutomaticaPcge
            'ent.CampoCondicion2 = Cam.CodEmp
            'ent.DatoCondicion2 = ent.CodigoEmpresa
            Dim objAD As New CuentaEmpresaAD
            listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
            Return listObj
            '\\
      End Function

      Function obtenerCuentaExisAnaliticas(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
            '//
            Dim listObj As New List(Of SuperEntidad)
            ent.Vista = vista
            ent.DatoEliminado = "1"
            ent.DatoEstado = ""
            ent.CampoCondicion1 = Cam.NumDigPcge
            ent.DatoCondicion1 = ent.NumeroDigitosPcge
            Dim objAD As New CuentaEmpresaAD
            listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
            Return listObj
            '\\
      End Function

      Function obtenerCuentaExisPorEmpresa(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
            '//
            Dim listObj As New List(Of SuperEntidad)
            ent.Vista = vista
            ent.DatoEliminado = "1"
            ent.DatoEstado = ""
            ent.CampoCondicion1 = Cam.CodEmp
            ent.DatoCondicion1 = ent.CodigoEmpresa

            Dim objAD As New CuentaEmpresaAD
            listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
            Return listObj
            '\\
      End Function

      Function obtenerCuentaExisAct(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
            '//
            Dim listObj As New List(Of SuperEntidad)
            ent.Vista = vista
            ent.DatoEliminado = "1"
            ent.DatoEstado = "1"
            Dim objAD As New CuentaEmpresaAD
            listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
            Return listObj
            '\\
      End Function

      Function obtenerCuentaEli(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
            '//
            Dim listObj As New List(Of SuperEntidad)
            ent.Vista = vista
            ent.DatoEliminado = "0"
            ent.DatoEstado = ""
            Dim objAD As New CuentaEmpresaAD
            listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
            Return listObj
            '\\
      End Function

      Function buscarCuentaExisPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
            '//
            Dim obj As New SuperEntidad
            ent.Vista = vista
            ent.DatoEliminado = "1"
            ent.DatoEstado = ""
            ent.CampoCondicion1 = Cam.CodCtaPcge
            ent.DatoCondicion1 = ent.CodigoCuentaPcge
            Dim objAD As New CuentaEmpresaAD
            obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
            Return obj
            '\\
      End Function

      Function buscarCuentaExisPorClave(ByRef ent As SuperEntidad) As SuperEntidad
            '//
            Dim obj As New SuperEntidad
            ent.Vista = vista
            ent.DatoEliminado = "1"
            ent.DatoEstado = ""
            ent.CampoCondicion1 = Cam.ClaCtaPcge
            ent.DatoCondicion1 = ent.ClaveCuentaPcge
            Dim objAD As New CuentaEmpresaAD
            obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
            Return obj
            '\\
      End Function

      Function buscarCuentaExisPorCodigoyAnalitica(ByRef ent As SuperEntidad) As SuperEntidad
            '//
            Dim obj As New SuperEntidad
            ent.Vista = vista
            ent.DatoEliminado = "1"
            ent.DatoEstado = ""
            ent.CampoCondicion1 = Cam.CodCtaPcge
            ent.DatoCondicion1 = ent.CodigoCuentaPcge
            ent.CampoCondicion2 = Cam.NumDigPcge
            ent.DatoCondicion2 = "7" 'ent.FlagAutomaticaPcge se pone 7 por es el numero de digitos

            Dim objAD As New CuentaEmpresaAD
            obj = objAD.SpBuscarRegistroConDosCondicion(ent)
            Return obj
            '\\
      End Function

      Function buscarCuentaExisActPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
            '//
            Dim obj As New SuperEntidad
            ent.Vista = vista
            ent.DatoEliminado = "1"
            ent.DatoEstado = "1"
            ent.CampoCondicion1 = Cam.CodCtaPcge
            Dim objAD As New CuentaEmpresaAD
            obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
            Return obj
            '\\
      End Function

      Function buscarCuentaEliPorCodigo(ByRef ent As SuperEntidad) As SuperEntidad
            '//
            Dim obj As New SuperEntidad
            ent.Vista = vista
            ent.DatoEliminado = "0"
            ent.DatoEstado = ""
            ent.CampoCondicion1 = Cam.CodCtaPcge
            Dim objAD As New CuentaEmpresaAD
            obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
            Return obj
            '\\
      End Function

      Function buscarCuentaExisPorNombre(ByRef ent As SuperEntidad) As SuperEntidad
            '//
            Dim obj As New SuperEntidad
            ent.Vista = vista
            ent.DatoEliminado = "1"
            ent.DatoEstado = ""
            ent.CampoCondicion1 = Cam.NomCtaPcge
            Dim objAD As New CuentaEmpresaAD
            obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
            Return obj
            '\\
      End Function 'Class PlanCuentaPcgeRN

      Function existeCuentaPorCodigo(ByRef ent As SuperEntidad) As Boolean
            '//
            Dim obj As New SuperEntidad
            ent.Vista = vista
            ent.DatoEliminado = ""
            ent.DatoEstado = ""
            ent.CampoCondicion1 = Cam.CodCtaPcge
            ent.DatoCondicion1 = ent.CodigoCuentaPcge

            Dim pgcAD As New CuentaEmpresaAD
            obj = pgcAD.SpBuscarRegistroConUnaCondicion(ent)
            If obj.CodigoCuentaPcge = "" Then
                  Return False
            Else
                  Return True
            End If
            '\\
      End Function

      Function existeCuentasEnEmpresa(ByRef ent As SuperEntidad) As Boolean
            '//
            Dim listObj As New List(Of SuperEntidad)
            Dim obj As New SuperEntidad
            ent.Vista = vista
            ent.DatoEliminado = "1"
            ent.DatoEstado = ""
            ent.CampoCondicion1 = Cam.CodEmp
            ent.DatoCondicion1 = ent.CodigoEmpresa
            ent.CampoOrden = Cam.CodEmp
            Dim pgcAD As New CuentaEmpresaAD
            listObj = pgcAD.SpObtenerRegistrosConUnaCondicion(ent)
            If listObj.Count = 0 Then
                  Return False
            Else
                  Return True
            End If
            '\\
      End Function
End Class
