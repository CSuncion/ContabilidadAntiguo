Imports Entidad
Imports Datos

Public Class PeriodoRN
    Dim Cam As New CamposEntidad
    Const vista As String = "VsPeriodo"

    Sub nuevaPeriodo(ByRef ent As SuperEntidad)
        '//
        '/Estos Datos son por defecto cada vez que agregue un nuevo usuario
        'ent.FlagTipoCuentaPcge = "1" '/Cuando no se captura en el formulario
        'ent.EstadoCuenta = "1"
        'ent.EstadoRegistro = "1"
        'ent.EliminadoRegistro = "1"
        ent.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioAgrega = SuperEntidad.xNombreUsuario
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        ent.ClavePeriodo = ent.CodigoEmpresa + "-" + ent.CodigoPeriodo
        Dim objAD As New PeriodoAD
        objAD.SpNuevoPeriodo(ent)
        '\\
    End Sub

    Sub modificarPeriodo(ByRef ent As SuperEntidad)
        '//
        '/Vovemos a traer el usuario actual de la b.d
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        '/Vovemos a traer el usuario actual de la b.d

        ''/Mandamos a modificar la b.d
        Dim objAD As New PeriodoAD
        objAD.SpModificarPeriodo(ent)
        '\\
    End Sub

    Sub eliminarPeriodoLog(ByRef ent As SuperEntidad)
        '//
        '/Datos por defecto
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
        ent.EliminadoRegistro = "0"
        '/Mandamos a modificar la b.d
        Dim objAD As New PeriodoAD
        objAD.SpModificarPeriodo(ent)
        '\\
    End Sub

    Sub eliminarPeriodoFis(ByRef ent As SuperEntidad)
        '//
        '/Mandamos a modificar la b.d
        Dim objAD As New PeriodoAD
        objAD.SpEliminarPeriodo(ent)
        '\\
    End Sub

    Sub eliminarPeriodosXEmpresaFis(ByRef ent As SuperEntidad)
        '//
        '/Mandamos a modificar la b.d
        Dim objAD As New PeriodoAD
        objAD.Eliminar(ent)
        '\\
    End Sub

    Function obtenerPeriodoExis(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = Cam.CodEmp
        ent.DatoCondicion1 = ent.CodigoEmpresa
        'ent.DatoCondicion1 = SuperEntidad.xCodigoEmpresa
        Dim objAD As New PeriodoAD
        listObj = objAD.SpObtenerRegistrosConUnaCondicion(ent)
        'listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerPeriodoExisAct(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = vista
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        Dim objAD As New PeriodoAD
        listObj = objAD.SpObtenerRegistrosSinCondicion(ent)
        Return listObj
        '\\
    End Function

    Function ListarPeriodosActivas(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New PeriodoAD
        Return objAD.ListarPeriodosActivas(ent)
        '\\
    End Function

    Function ListarPeriodos(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Dim objAD As New PeriodoAD
        Return objAD.ListarPeriodos(ent)
        '\\
    End Function

    Function BuscarPeriodoXClave(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim objAD As New PeriodoAD
        Return objAD.BuscarPeriodoXClave(ent)
        '\\
    End Function

    Function EsPeriodoValido(ByRef pObj As SuperEntidad) As SuperEntidad
        Dim iPerEN As New SuperEntidad

        'Cuando el periodo esta en blanco
        If pObj.CodigoPeriodo = String.Empty Then
            iPerEN.EsVerdad = True
            Return iPerEN
        End If

        'Cuando el codigo de empresa esta en blanco
        If pObj.CodigoEmpresa = String.Empty Then
            iPerEN.EsVerdad = False
            iPerEN.Mensaje = "Debes digitar una Empresa"
            Return iPerEN
        End If

        'Armando clave del periodo
        iPerEN.ClavePeriodo += pObj.CodigoEmpresa + "-"
        iPerEN.ClavePeriodo += pObj.CodigoPeriodo

        'Buscar en BD
        iPerEN = Me.BuscarPeriodoXClave(iPerEN)
        If iPerEN.ClavePeriodo = String.Empty Then
            iPerEN.EsVerdad = False
            iPerEN.Mensaje = "El periodo que digitaste no existe"
            Return iPerEN
        End If

        If iPerEN.CEstadoPeriodo = "0" Then
            iPerEN.EsVerdad = False
            iPerEN.Mensaje = "El periodo que digitaste esta cerrado"
            Return iPerEN
        End If

        'Si todo esta OK
        iPerEN.EsVerdad = True
        iPerEN.Mensaje = String.Empty
        Return iPerEN

    End Function

    Function ObtenerLosAnosDePeriodosXEmpresa(ByVal pPer As SuperEntidad) As List(Of String)

        'mi lista de resultado
        Dim iLisRes As New List(Of String)

        'traer a todos los periodos que existen en una empresa determinada
        Dim iLisPer As List(Of SuperEntidad) = Me.ListarPeriodos(pPer)

        'variables de uso
        Dim iAno As String = ""

        'de esta lista de periodos sacar todos los años diferentes que existen
        'en esta empresa
        For Each xPer As SuperEntidad In iLisPer
            'obteniendo solo el año del codigo del periodo de cada objeto
            Dim iAnoPeriodo As String = xPer.CodigoPeriodo.Substring(0, 4)
            If iAno <> iAnoPeriodo Then
                iLisRes.Add(iAnoPeriodo)
                iAno = iAnoPeriodo
            End If
        Next
        Return iLisRes
    End Function

    Function EsPeriodoDeApertura(ByRef pObj As SuperEntidad) As SuperEntidad
        Dim iPerEN As New SuperEntidad
        'Armando clave del periodo
        iPerEN.ClavePeriodo += pObj.CodigoEmpresa + "-"
        iPerEN.ClavePeriodo += pObj.CodigoPeriodo

        'Buscar en BD
        iPerEN = Me.BuscarPeriodoXClave(iPerEN)
        If iPerEN.ClavePeriodo = String.Empty Then
            iPerEN.EsVerdad = False
            iPerEN.Mensaje = "Primero debes crear el periodo de apertura"
            Return iPerEN
        End If

        'Si todo esta OK
        iPerEN.EsVerdad = True
        iPerEN.Mensaje = String.Empty
        Return iPerEN

    End Function

    Function HayAnoRegistrado(ByRef ent As SuperEntidad) As Boolean
        'TRAEMOS TODOS LOS PERIODOS DE LA EMPRESA
        ent.CampoOrden = Cam.CodPer
        Dim iLisPer As List(Of SuperEntidad) = Me.ListarPeriodos(ent)

        'RECORREMOS CADA PERIODO 
        For Each xPer As SuperEntidad In iLisPer
            If xPer.CodigoPeriodo.Substring(0, 4) = ent.CodigoPeriodo Then
                Return True
            End If
        Next
        Return False
    End Function

    Function EsActoEliminarPeriodo(ByVal ent As SuperEntidad) As SuperEntidad

        'OBJETO RESULTADO
        Dim iPerEN As New SuperEntidad

        'OBTENER EL MES DEL PERIODO
        Dim iMes As String = ent.CodigoPeriodo.Substring(4)

        'PREGUNTAMOS SI HAY ALGUN VOUCHER EN ESTE PERIODO
        'QUE TENGA ALGUN NUMERO GENERADO
        Dim iVouRN As New VoucherRN
        Dim iVouEN As New SuperEntidad
        iVouEN.CodigoEmpresa = ent.CodigoEmpresa
        iVouEN.AnoVoucher = ent.CodigoPeriodo.Substring(0, 4)
        If iVouRN.HayNumeroVoucherGeneradoEnPeriodo(iVouEN, iMes) = True Then
            iPerEN.EsVerdad = False
            iPerEN.Mensaje = "En este periodo hay correlativos generados, No se puede realizar la operacion"
            Return iPerEN
        End If

        'Ok
        iPerEN.EsVerdad = True
        iPerEN.Mensaje = ""
        Return iPerEN

    End Function

End Class
