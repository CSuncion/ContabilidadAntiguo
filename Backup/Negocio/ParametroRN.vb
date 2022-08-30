Imports Entidad
Imports Datos
Public Class ParametroRN
    Dim cam As New CamposEntidad

    Sub modificarParametro(ByRef ent As SuperEntidad)
        '//
        '/Vovemos a traer el usuario actual de la b.d
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.CodigoPersonalModifica = SuperEntidad.xCodigoPersonal
        '/Vovemos a traer el usuario actual de la b.d
        ''/Mandamos a modificar la b.d
        Dim objAD As New ParametroAD
        objAD.SpModificarParametro(ent)
        '\\
    End Sub

    Function buscarParametroExis(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsParametro"
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = cam.EliReg
        ent.DatoCondicion1 = "1"
        Dim objAD As New ParametroAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

End Class
