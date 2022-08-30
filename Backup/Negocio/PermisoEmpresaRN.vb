Imports Entidad
Imports Datos

Public Class PermisoEmpresaRN

    'VARIABLES DE ERROR
    Public estConex As Boolean
    Public msgConex As String


    Function UsuarioEmpresaEnBlanco() As PermisoEmpresaEN
        Dim objx As New PermisoEmpresaEN
        Return objx
    End Function


    Sub adicionarUsuarioEmpresa(ByRef objx As PermisoEmpresaEN)
        '/
        'DATOS POR DEFECTO
        objx.ClavePermisoEmpresa = objx.CodigoUsuario + objx.CodigoEmpresa
        objx.CMesPermisoEmpresa = Today.Month.ToString.PadLeft(2, CType("0", Char))
        objx.AnoPermisoEmpresa = Today.Year.ToString
        objx.PeriodoPermisoEmpresa = objx.AnoPermisoEmpresa + objx.CMesPermisoEmpresa
        objx.EstadoPermisoEmpresa = 0 'No autorizado

        'EJECUTAR 
        Dim objAD As New PermisoEmpresaAD
        objAD.AgregarUsuarioEmpresa(objx)

        'VALORES DE CONEXION
        Me.estConex = objAD.estConex
        Me.msgConex = objAD.msgConex
        '/
    End Sub


    Sub modificarUsuarioEmpresa(ByRef objx As PermisoEmpresaEN)
        '/
        'EJECUTAR 
        Dim objAD As New PermisoEmpresaAD
        objAD.ModificarUsuarioEmpresa(objx)
        'VALORES DE CONEXION
        Me.estConex = objAD.estConex
        Me.msgConex = objAD.msgConex
        '/
    End Sub


    Sub eliminarUsuarioEmpresaFis(ByRef objx As PermisoEmpresaEN)
        '/
        'EJECUTAR 
        Dim objAD As New PermisoEmpresaAD
        objAD.EliminarUsuarioEmpresa(objx)
        'VALORES DE CONEXION
        Me.estConex = objAD.estConex
        Me.msgConex = objAD.msgConex
        '/
    End Sub


    Sub eliminarSoloEmpresaFis(ByRef objx As PermisoEmpresaEN)
        '/
        'EJECUTAR 
        Dim objAD As New PermisoEmpresaAD
        objAD.EliminarSoloEmpresa(objx)
        'VALORES DE CONEXION
        Me.estConex = objAD.estConex
        Me.msgConex = objAD.msgConex
        '/
    End Sub


    Sub eliminarSoloUsuarioFis(ByRef objx As PermisoEmpresaEN)
        '/
        'EJECUTAR 
        Dim objAD As New PermisoEmpresaAD
        objAD.EliminarSoloUsuario(objx)
        'VALORES DE CONEXION
        Me.estConex = objAD.estConex
        Me.msgConex = objAD.msgConex
        '/
    End Sub


    Sub GenerarPermisosEmpresasXUsuario(ByRef usu As String, ByVal lisEmp As List(Of SuperEntidad))
        '
        Dim usEmEN As New PermisoEmpresaEN
        usEmEN.CodigoUsuario = usu
        'RECORREMOS CADA EMPRESA Y LA VAMOS INSERTANDO
        'EN LA TABLA USUARIOEMPRESA
        For Each xob As SuperEntidad In lisEmp
            usEmEN.CodigoEmpresa = xob.CodigoEmpresa
            Me.adicionarUsuarioEmpresa(usEmEN)
        Next
    End Sub


    Sub GenerarPermisosUsuariosXEmpresa(ByRef emp As String, ByVal lisUsu As List(Of SuperEntidad))
        '
        Dim usEmEN As New PermisoEmpresaEN
        usEmEN.CodigoEmpresa = emp
        'RECORREMOS CADA USUARIO Y LA VAMOS INSERTANDO
        'EN LA TABLA USUARIOEMPRESA
        For Each xob As SuperEntidad In lisUsu
            usEmEN.CodigoUsuario = xob.CodigoUsuario
            Me.adicionarUsuarioEmpresa(usEmEN)
        Next
    End Sub


    Sub CambiarPermisoUsuarioEmpresas(ByRef permiso As Integer, ByVal lisUsuEmp As List(Of PermisoEmpresaEN))
        For Each xob As PermisoEmpresaEN In lisUsuEmp
            xob.EstadoPermisoEmpresa = permiso
            Me.modificarUsuarioEmpresa(xob)
        Next
    End Sub


    Function listarEmpresasNoAutorizadasXUsuario(ByVal objx As PermisoEmpresaEN) As List(Of PermisoEmpresaEN)
        Dim objAD As New PermisoEmpresaAD
        Return objAD.ListarEmpresasNoAutorizadasXUsuario(objx)
    End Function


    Function listarEmpresasAsignadasXUsuario(ByVal objx As PermisoEmpresaEN) As List(Of PermisoEmpresaEN)
        Dim objAD As New PermisoEmpresaAD
        Return objAD.ListarEmpresasAsignadasXUsuario(objx)
    End Function


    Function buscarUsuarioEmpresa(ByVal objx As PermisoEmpresaEN) As PermisoEmpresaEN
        Dim objAD As New PermisoEmpresaAD
        Return objAD.BuscarUsuarioEmpresa(objx)
    End Function


    Function buscarEmpresaDeUsuario(ByVal objx As PermisoEmpresaEN) As PermisoEmpresaEN
        Dim objAD As New PermisoEmpresaAD
        Return objAD.BuscarEmpresaDeUsuario(objx)
    End Function

    Function BuscarPermisoEmpresaXClave(ByVal objx As PermisoEmpresaEN) As PermisoEmpresaEN
        Dim objAD As New PermisoEmpresaAD
        Return objAD.BuscarPermisoEmpresaXClave(objx)
    End Function


    Function EsEmpresaAsignadaDeUsuario(ByVal objx As PermisoEmpresaEN) As Boolean
        Dim objUE As PermisoEmpresaEN = Me.buscarEmpresaDeUsuario(objx)
        If objUE.CodigoUsuario = "" Then
            Return False
        Else
            Return True
        End If
    End Function

    Sub ModificarPeriodoPermisoEmpresa(ByRef pPerm As PermisoEmpresaEN)
        'Capturar el nuevo periodo
        Dim iPeriodo As String = pPerm.PeriodoPermisoEmpresa

        'Traer el permiso empresa
        pPerm.ClavePermisoEmpresa = pPerm.CodigoUsuario + pPerm.CodigoEmpresa

        pPerm = Me.BuscarPermisoEmpresaXClave(pPerm)

        'Comparar el periodo actual con el nuevo
        If pPerm.PeriodoPermisoEmpresa <> iPeriodo Then
            pPerm.AnoPermisoEmpresa = iPeriodo.Substring(0, 4)
            pPerm.CMesPermisoEmpresa = iPeriodo.Substring(4, 2)
            pPerm.PeriodoPermisoEmpresa = iPeriodo
            Me.modificarUsuarioEmpresa(pPerm)
        End If
    End Sub

End Class


