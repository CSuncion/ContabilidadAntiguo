Imports Entidad
Imports ScriptBaseDatos
Imports LibreriaGeneral

Public Class PermisoEmpresaAD

    'VARIABLES DE ERROR
    Public estConex As Boolean
    Public msgConex As String
    'VARIABLES DE TRABAJO 
    Private objCon As New SqlDatos
    Private lista As New List(Of PermisoEmpresaEN)
    Private obj As New PermisoEmpresaEN
    Private tabla As String = "PermisoEmpresa"
    Private vista As String = "VsPermisoEmpresa"
    Private Campo As New CamposEntidad


    Function Objeto(ByRef iDr As IDataReader) As PermisoEmpresaEN
        '/
        Dim objEnc As New PermisoEmpresaEN
        objEnc.ClavePermisoEmpresa = iDr(PermisoEmpresaEN.ClaPerEmp).ToString
        objEnc.CodigoUsuario = iDr(PermisoEmpresaEN.CodUsu).ToString
        objEnc.NombreUsuario = iDr(PermisoEmpresaEN.NomUsu).ToString
        objEnc.CodigoEmpresa = iDr(PermisoEmpresaEN.CodEmp).ToString
        objEnc.RazonSocialEmpresa = iDr(PermisoEmpresaEN.RazSocEmp).ToString
        objEnc.NombreCortoEmpresa = iDr(PermisoEmpresaEN.NomCorEmp).ToString
        objEnc.CEstadoEmpresa = iDr(PermisoEmpresaEN.CEstEmp).ToString
        objEnc.EstadoPermisoEmpresa = CType(iDr(PermisoEmpresaEN.EstPerEmp).ToString, Integer)
        objEnc.PeriodoPermisoEmpresa = iDr(PermisoEmpresaEN.PerPerEmp).ToString
        objEnc.RucEmpresa = iDr(PermisoEmpresaEN.RucEmp).ToString
        Return objEnc
        '/
    End Function


    Function ListarObjetos(ByVal sc As String) As List(Of PermisoEmpresaEN)
        '/
        Try
            objCon.Conectar(SqlDatos.Bd.ContabilidadEmma)
            objCon.ComandoText(sc)
            Dim iDr As IDataReader = objCon.ObtenerIDr
            While iDr.Read
                'Adicionando cada objeto a la Lista            
                lista.Add(Me.Objeto(iDr))
            End While

            'SI TODO VA BIEN
            Me.estConex = True
            Me.msgConex = "OK"
            Return lista
        Catch ex As Exception
            'NO SALIO BIEN
            Me.estConex = False
            Me.msgConex = ex.Message
            Return lista
        Finally
            objCon.Desconectar()
        End Try
        '/
    End Function


    Function BuscarObjeto(ByVal sc As String) As PermisoEmpresaEN
        '/
        Try
            objCon.Conectar(SqlDatos.Bd.ContabilidadEmma)
            '' Script armado
            objCon.ComandoText(sc)
            '/Obtener IDr
            Dim iDr As IDataReader = objCon.ObtenerIDr
            While iDr.Read
                obj = Me.Objeto(iDr)
            End While
            'SI TODO VA BIEN
            Me.estConex = True
            Me.msgConex = "OK"
            Return obj
        Catch ex As Exception
            'NO SALIO BIEN
            Me.estConex = False
            Me.msgConex = ex.Message
            Return obj
        Finally
            objCon.Desconectar()
        End Try
        '/
    End Function


    Sub AgregarUsuarioEmpresa(ByRef objx As PermisoEmpresaEN)
        '/
        Try
            objCon.Conectar(SqlDatos.Bd.ContabilidadEmma)

            'ARMANDO SCRIPT PARA INSERTAR
            Dim ins As New SqlInsert
            ins.Tabla(Me.tabla)
            ins.CampoValorAvanza(PermisoEmpresaEN.ClaPerEmp, objx.ClavePermisoEmpresa)
            ins.CampoValorAvanza(PermisoEmpresaEN.CodUsu, objx.CodigoUsuario)
            ins.CampoValorAvanza(PermisoEmpresaEN.CodEmp, objx.CodigoEmpresa)
            ins.CampoValorAvanza(PermisoEmpresaEN.EstPerEmp, objx.EstadoPermisoEmpresa.ToString)
            ins.CampoValorAvanza(PermisoEmpresaEN.PerPerEmp, objx.PeriodoPermisoEmpresa)
            'AUDITORIA
            ins.CampoValorAvanza(Campo.CodUsuAgr, SuperEntidad.xCodigoUsuario)
            ins.CampoValorAvanza(Campo.NomUsuAgr, SuperEntidad.xNombreUsuario)
            ins.CampoValorAvanza(Campo.FechaAgr, FormatoFecha.AñoMesDia(Today.Date))
            ins.CampoValorAvanza(Campo.CodUsuMod, SuperEntidad.xCodigoUsuario)
            ins.CampoValorAvanza(Campo.NomUsuMod, SuperEntidad.xNombreUsuario)
            ins.CampoValorTermina(Campo.FechaMod, FormatoFecha.AñoMesDia(Today.Date))


            'SCRIPT ARMADO
            objCon.ComandoText(ins.Script)

            'EJECUTAR SIN RESULTADO
            objCon.EjecutarSinResultado()

            'SI TODO VA BIEN
            Me.estConex = True
            Me.msgConex = "OK"

        Catch ex As Exception
            'NO SALIO BIEN
            Me.estConex = False
            Me.msgConex = ex.Message
        Finally
            objCon.Desconectar()
        End Try
        '/
    End Sub


    Sub ModificarUsuarioEmpresa(ByRef objx As PermisoEmpresaEN)
        '/
        Try
            objCon.Conectar(SqlDatos.Bd.ContabilidadEmma)

            'ARMANDO SCRIPT PARA ACTUALIZAR
            Dim upd As New SqlUpdate
            upd.Tabla(Me.tabla)
            upd.CampoValorAvanza(PermisoEmpresaEN.EstPerEmp, objx.EstadoPermisoEmpresa.ToString)
            upd.CampoValorAvanza(PermisoEmpresaEN.PerPerEmp, objx.PeriodoPermisoEmpresa.ToString)
            'AUDITORIA
            upd.CampoValorAvanza(Campo.CodUsuMod, SuperEntidad.xCodigoUsuario)
            upd.CampoValorAvanza(Campo.NomUsuMod, SuperEntidad.xNombreUsuario)
            upd.CampoValorTermina(Campo.FechaMod, FormatoFecha.AñoMesDia(Today.Date))

            Dim sel As New SqlSelect
            sel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoEmpresaEN.CodUsu, SqlSelect.Operador.Igual, objx.CodigoUsuario)
            sel.CondicionCV(SqlSelect.Reservada.Y, PermisoEmpresaEN.CodEmp, SqlSelect.Operador.Igual, objx.CodigoEmpresa)
            upd.CondicionUpdate(sel.Script)

            'SCRIPT ARMADO
            objCon.ComandoText(upd.Script)

            'EJECUTAR SIN RESULTADO
            objCon.EjecutarSinResultado()

            'SI TODO VA BIEN
            Me.estConex = True
            Me.msgConex = "OK"

        Catch ex As Exception
            'NO SALIO BIEN
            Me.estConex = False
            Me.msgConex = ex.Message
        Finally
            objCon.Desconectar()
        End Try
        '/
    End Sub


    Sub EliminarUsuarioEmpresa(ByRef objx As PermisoEmpresaEN)
        '/
        Try
            objCon.Conectar(SqlDatos.Bd.ContabilidadEmma)

            'ARMANDO SCRIPT PARA ACTUALIZAR
            Dim eli As New SqlDelete
            eli.Tabla(Me.tabla)

            Dim sel As New SqlSelect
            sel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoEmpresaEN.CodUsu, SqlSelect.Operador.Igual, objx.CodigoUsuario)
            sel.CondicionCV(SqlSelect.Reservada.Y, PermisoEmpresaEN.CodEmp, SqlSelect.Operador.Igual, objx.CodigoEmpresa)
            eli.CondicionDelete(sel.Script)

            'SCRIPT ARMADO
            objCon.ComandoText(eli.Script)

            'EJECUTAR SIN RESULTADO
            objCon.EjecutarSinResultado()

            'SI TODO VA BIEN
            Me.estConex = True
            Me.msgConex = "OK"

        Catch ex As Exception
            'NO SALIO BIEN
            Me.estConex = False
            Me.msgConex = ex.Message
        Finally
            objCon.Desconectar()
        End Try
        '/
    End Sub


    Sub EliminarSoloEmpresa(ByRef objx As PermisoEmpresaEN)
        '/
        Try
            objCon.Conectar(SqlDatos.Bd.ContabilidadEmma)

            'ARMANDO SCRIPT PARA ACTUALIZAR
            Dim eli As New SqlDelete
            eli.Tabla(Me.tabla)

            Dim sel As New SqlSelect
            sel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoEmpresaEN.CodEmp, SqlSelect.Operador.Igual, objx.CodigoEmpresa)
            eli.CondicionDelete(sel.Script)

            'SCRIPT ARMADO
            objCon.ComandoText(eli.Script)

            'EJECUTAR SIN RESULTADO
            objCon.EjecutarSinResultado()

            'SI TODO VA BIEN
            Me.estConex = True
            Me.msgConex = "OK"

        Catch ex As Exception
            'NO SALIO BIEN
            Me.estConex = False
            Me.msgConex = ex.Message
        Finally
            objCon.Desconectar()
        End Try
        '/
    End Sub


    Sub EliminarSoloUsuario(ByRef objx As PermisoEmpresaEN)
        '/
        Try
            objCon.Conectar(SqlDatos.Bd.ContabilidadEmma)

            'ARMANDO SCRIPT PARA ACTUALIZAR
            Dim eli As New SqlDelete
            eli.Tabla(Me.tabla)

            Dim sel As New SqlSelect
            sel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoEmpresaEN.CodUsu, SqlSelect.Operador.Igual, objx.CodigoUsuario)
            eli.CondicionDelete(sel.Script)

            'SCRIPT ARMADO
            objCon.ComandoText(eli.Script)

            'EJECUTAR SIN RESULTADO
            objCon.EjecutarSinResultado()

            'SI TODO VA BIEN
            Me.estConex = True
            Me.msgConex = "OK"

        Catch ex As Exception
            'NO SALIO BIEN
            Me.estConex = False
            Me.msgConex = ex.Message
        Finally
            objCon.Desconectar()
        End Try
        '/
    End Sub


    Function ListarEmpresasNoAutorizadasXUsuario(ByRef objx As PermisoEmpresaEN) As List(Of PermisoEmpresaEN)
        '/
        'Armando el Script para Consultar
        Dim sel As New SqlSelect
        sel.SeleccionaVista(Me.vista)
        sel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoEmpresaEN.CEstEmp, SqlSelect.Operador.Igual, "1") ' abierta
        sel.CondicionCV(SqlSelect.Reservada.Y, PermisoEmpresaEN.EstPerEmp, SqlSelect.Operador.Igual, "0") ' no tienen permiso
        sel.CondicionCV(SqlSelect.Reservada.Y, PermisoEmpresaEN.CodUsu, SqlSelect.Operador.Igual, objx.CodigoUsuario) ' usuario
        sel.Orden(objx.CampoOrden, SqlSelect.Order.Asc)
        ' Script armado
        Return Me.ListarObjetos(sel.Script)
        '/
    End Function


    Function ListarEmpresasAsignadasXUsuario(ByRef objx As PermisoEmpresaEN) As List(Of PermisoEmpresaEN)
        '/
        'Armando el Script para Consultar
        Dim sel As New SqlSelect
        sel.SeleccionaVista(Me.vista)
        sel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoEmpresaEN.CEstEmp, SqlSelect.Operador.Igual, "1") ' abierta
        sel.CondicionCV(SqlSelect.Reservada.Y, PermisoEmpresaEN.EstPerEmp, SqlSelect.Operador.Igual, "1") ' si tienen permiso
        sel.CondicionCV(SqlSelect.Reservada.Y, PermisoEmpresaEN.CodUsu, SqlSelect.Operador.Igual, objx.CodigoUsuario) ' usuario
        sel.Orden(objx.CampoOrden, SqlSelect.Order.Asc)

        ' Script armado
        Return Me.ListarObjetos(sel.Script)
        '/
    End Function


    Function BuscarPermisoEmpresaXClave(ByRef objx As PermisoEmpresaEN) As PermisoEmpresaEN
        '/
        'Armando el Script para Consultar
        Dim sel As New SqlSelect
        sel.SeleccionaVista(Me.vista)
        sel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoEmpresaEN.ClaPerEmp, SqlSelect.Operador.Igual, objx.ClavePermisoEmpresa)
        ' Script armado
        Return Me.BuscarObjeto(sel.Script)
        '/
    End Function

    Function BuscarUsuarioEmpresa(ByRef objx As PermisoEmpresaEN) As PermisoEmpresaEN
        '/
        'Armando el Script para Consultar
        Dim sel As New SqlSelect
        sel.SeleccionaVista(Me.vista)
        sel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoEmpresaEN.CodUsu, SqlSelect.Operador.Igual, objx.CodigoUsuario)
        sel.CondicionCV(SqlSelect.Reservada.Y, PermisoEmpresaEN.CodEmp, SqlSelect.Operador.Igual, objx.CodigoEmpresa)
        ' Script armado
        Return Me.BuscarObjeto(sel.Script)
        '/
    End Function


    Function BuscarEmpresaDeUsuario(ByRef objx As PermisoEmpresaEN) As PermisoEmpresaEN
        '/
        'Armando el Script para Consultar
        Dim sel As New SqlSelect
        sel.SeleccionaVista(Me.vista)
        sel.CondicionCV(SqlSelect.Reservada.Cuando, PermisoEmpresaEN.CodUsu, SqlSelect.Operador.Igual, objx.CodigoUsuario)
        sel.CondicionCV(SqlSelect.Reservada.Y, PermisoEmpresaEN.CodEmp, SqlSelect.Operador.Igual, objx.CodigoEmpresa)
        sel.CondicionCV(SqlSelect.Reservada.Y, PermisoEmpresaEN.EstPerEmp, SqlSelect.Operador.Igual, "1") ' si tienen permiso
        ' Script armado
        Return Me.BuscarObjeto(sel.Script)
        '/
    End Function



End Class
