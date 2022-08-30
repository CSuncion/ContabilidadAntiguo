Imports Entidad
Imports Datos

Public Class MovimientoContableCabeceraRN
    Dim cam As New CamposEntidad

    Sub nuevoMovimientoContableCacecera(ByRef ent As SuperEntidad)
        'ent.AnoMesDiasPorMes = ent.AnoDiasPorMes + "/" + ent.CodigoMes
        Dim objAD As New MovimientoContableCabeceraAD
        objAD.SpNuevoMovimientoContableCabecera(ent)
        '\\

    End Sub

    Sub EliminarMovimientoContableCabeceraFis(ByRef ent As SuperEntidad)
        '//
        Dim objAD As New MovimientoContableCabeceraAD
        ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        objAD.SpEliminarMovimientoContableCabecera(ent)
        '\\
    End Sub

    Function obtenerRegContab(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsRegContabCabe"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.CodOriRC
        ent.CampoCondicion2 = cam.CodEmp
        ent.DatoCondicion2 = SuperEntidad.xCodigoEmpresa
        Dim objAD As New RegContabCabeAD
        listObj = objAD.SpObtenerRegistrosConDosCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerMovimientoCabeceraXPeriodo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsMovimientoContableCabecera"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.PeriodoRCC
        ent.DatoCondicion1 = ent.PeriodoRegContabCabe
        ent.CampoCondicion2 = cam.CodEmp
        ent.DatoCondicion2 = SuperEntidad.xCodigoEmpresa

        Dim objAD As New MovimientoContableCabeceraAD
        listObj = objAD.SpObtenerRegistrosConDosCondicion(ent)
        Return listObj
        '\\
    End Function
    Function obtenerRegContabCabeExisXOrigenFileYPeriodo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsRegContabCabe"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.CodOriRC
        ent.DatoCondicion1 = ent.CodigoOrigen
        ent.CampoCondicion2 = cam.PeriodoRCC
        ent.DatoCondicion2 = ent.PeriodoRegContabCabe
        ent.CampoCondicion3 = cam.CodEmp
        ent.DatoCondicion3 = ent.CodigoEmpresa
        ent.CampoCondicion4 = cam.CodFilRC
        ent.DatoCondicion4 = ent.CodigoFile
        Dim objAD As New RegContabCabeAD
        listObj = objAD.SpObtenerRegistrosConCuatroCondicion(ent)
        Return listObj
        '\\
    End Function


    Function obtenerRegContabPorTipoYPeriodoYNoFile(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsRegContabCabe"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.CodOriRC
        ent.CampoCondicion2 = cam.PeriodoRCC
        ent.CampoCondicion3 = cam.CodFilRC
        Dim objAD As New RegContabCabeAD
        listObj = objAD.SpObtenerRegistrosConDosCondicionUnaDesigualdad(ent)
        Return listObj
        '\\
    End Function

    Function obtenerRegContabPorTipoYPeriodoYFile(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsRegContabCabe"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.CodOriRC
        ent.CampoCondicion2 = cam.PeriodoRCC
        ent.CampoCondicion3 = cam.CodFilRC
        Dim objAD As New RegContabCabeAD
        listObj = objAD.SpObtenerRegistrosConTresCondicion(ent)
        Return listObj
        '\\
    End Function


    Function buscarRegContabExisPorClave(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsRegContabCabe"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.ClaveRCC
        ent.DatoCondicion1 = ent.ClaveRegContabCabe
        Dim objAD As New RegContabCabeAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    'Function obtenerRegContabEntreFechas(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
    '      ent.Vista = "VsRegContab"
    '      ent.DatoEliminado = "1"
    '      ent.DatoEstado = ""
    '      ent.CampoFecha = cam.FecVouRC
    '      Dim objAD As New RegContabAD
    '      Return objAD.SpObtenerRegistrosEntreFechas(ent)
    'End Function

    Function obtenerRegContabEntreFechas(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        ent.Vista = "VsRegContabCabe"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.CodOriRC
        ent.CampoFecha = cam.FecVouRCC
        Dim objAD As New RegContabCabeAD
        Return objAD.SpObtenerRegistrosContablesEntreFechas(ent)
    End Function

    Function obtenerRegContabPorEstadoYPeriodo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsRegContabCabe"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        ent.CampoCondicion1 = cam.EstRCC   'Por estado
        ent.CampoCondicion2 = cam.PeriodoRCC
        ent.CampoCondicion3 = cam.CodEmp
        ent.DatoCondicion3 = SuperEntidad.xCodigoEmpresa
        Dim objAD As New RegContabCabeAD
        listObj = objAD.SpObtenerRegistrosConTresCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerRegContabCabePorPeriodo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsRegContabCabe"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos
        'ent.CampoCondicion1 = cam.CodOriRC
        ent.CampoCondicion1 = cam.PeriodoRCC
        ent.DatoCondicion1 = ent.PeriodoRegContabCabe
        ent.CampoCondicion2 = cam.CodEmp
        ent.DatoCondicion2 = SuperEntidad.xCodigoEmpresa
        Dim objAD As New RegContabCabeAD
        listObj = objAD.SpObtenerRegistrosConDosCondicion(ent)
        Return listObj
        '\\
    End Function


    Sub NuevoMovimientoContableCabeceraMasivo(ByRef pLista As List(Of SuperEntidad))
        'ent.AnoMesDiasPorMes = ent.AnoDiasPorMes + "/" + ent.CodigoMes
        Dim objAD As New MovimientoContableCabeceraAD
        objAD.SpNuevoMovimientoContableCabeceraMasivo(pLista)
        '\\

    End Sub


End Class
