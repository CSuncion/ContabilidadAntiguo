Imports Entidad
Imports Datos
Imports System.Data.SqlClient
Imports System.Data
Public Class ReportesTodosRN
    Dim cam As New CamposEntidad

    Function filtrarTablaPorTabla(ByRef ent As SuperEntidad) As DataTable
        '//
        Dim perAD As New ReportesTodos
        Return perAD.FiltrarTablaPorTabla(ent)
        '\\
    End Function

    Function ReportearPersonalInexistente(ByRef ent As SuperEntidad) As DataTable
        Dim objAD As New ReportesTodos
        'modificar el detalle
        Dim dt As New DataTable
        dt = objAD.ReportePersonalInexistente(ent)
        Return dt
    End Function

    Function ReportearProyectoInexistente(ByRef ent As SuperEntidad) As DataTable
        Dim objAD As New ReportesTodos
        'modificar el detalle
        Dim dt As New DataTable
        dt = objAD.ReporteProyectoInexistente(ent)
        Return dt
    End Function


    Function ReportearDetallePptoIntrno(ByRef ent As SuperEntidad) As DataTable
        Dim objAD As New ReportesTodos
        'modificar el detalle
        Dim dt As New DataTable
        'dt = objAD.ReporteDetallePptoInterno(ent)
        Return dt
    End Function


    Function ReportearCostosPersonalPptoInt(ByRef ent As SuperEntidad) As DataTable
        Dim objAD As New ReportesTodos
        'modificar el detalle
        Dim dt As New DataTable
        dt = objAD.ReporteCostoPersonalPptoInt(ent)
        Return dt
    End Function

    Function TraerIngresosRealesPorMes(ByRef ent As SuperEntidad) As DataTable
        Dim objAD As New ReportesTodos
        'modificar el detalle
        Dim dt As New DataTable
        dt = objAD.TraerIngresosRealesPorMes(ent)
        Return dt
    End Function

    Function TraerHorasPlanillaPersonal(ByRef ent As SuperEntidad) As DataTable
        Dim objAD As New ReportesTodos
        'modificar el detalle
        Dim dt As New DataTable
        dt = objAD.SpTraerHorasPlanillaPersonal(ent)
        Return dt
    End Function

    Function TraerCostosContratos(ByRef ent As SuperEntidad) As DataTable
        Dim objAD As New ReportesTodos
        'modificar el detalle
        Dim dt As New DataTable
        dt = objAD.SpTraerCostosContratos(ent)
        Return dt
    End Function

    Function TraerOtrosCostos(ByRef ent As SuperEntidad) As DataTable
        Dim objAD As New ReportesTodos
        'modificar el detalle
        Dim dt As New DataTable
        dt = objAD.SpTraerOtrosCostos(ent)
        Return dt
    End Function



    Function ReportearDetallePptoInternoCar(ByRef ent As SuperEntidad) As DataTable
        ent.Vista = "VsPptoInternoDetalleCar"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        'ent.CampoCondicion1 = cam.CodPptoInt
        ent.CampoOrden = cam.CodInt
        Dim objAD As New ReportesTodos
        Return objAD.SpObtenerRegistrosConUnaCondicion(ent)
    End Function

    Function ReportearDetallePptoInternoCps(ByRef ent As SuperEntidad) As DataTable
        ent.Vista = "VsPptoInternoDetalleCps"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        'ent.CampoCondicion1 = cam.CodPptoInt
        ent.CampoOrden = cam.CodInt
        Dim objAD As New ReportesTodos
        Return objAD.SpObtenerRegistrosConUnaCondicion(ent)
    End Function

    Function ReportearDetallePptoInternoCpla(ByRef ent As SuperEntidad) As DataTable
        ent.Vista = "VsPptoInternoDetalleCpla"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        'ent.CampoCondicion1 = cam.CodPptoInt
        ent.CampoOrden = cam.CodInt
        Dim objAD As New ReportesTodos
        Return objAD.SpObtenerRegistrosConUnaCondicion(ent)
    End Function

    Function ReportearDetallePptoInternoCser(ByRef ent As SuperEntidad) As DataTable
        ent.Vista = "VsPptoInternoDetalleCser"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        'ent.CampoCondicion1 = cam.CodPptoInt
        ent.CampoOrden = cam.CodInt
        Dim objAD As New ReportesTodos
        Return objAD.SpObtenerRegistrosConUnaCondicion(ent)
    End Function

    Function ReportearDetallePptoInternoOtros(ByRef ent As SuperEntidad) As DataTable
        ent.Vista = "VsPptoInternoDetalleOtros"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        'ent.CampoCondicion1 = cam.CodPptoInt
        ent.CampoCondicion2 = cam.CodConc
        ent.CampoOrden = cam.CodInt
        Dim objAD As New ReportesTodos
        Return objAD.SpObtenerRegistrosConDosCondicion(ent)
    End Function



    Function ReportearPptoInternos(ByRef ent As SuperEntidad) As DataTable
        ent.Vista = "VsPptoInternos"
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        'ent.CampoCondicion1 = cam.TipTabla
        Dim objAD As New ReportesTodos
        Return objAD.SpObtenerRegistrosConUnaCondicion(ent)
    End Function

    Function ReportearPptoInternosTodos(ByRef ent As SuperEntidad) As DataTable
        ent.Vista = "VsPptoInternos"
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"

        Dim objAD As New ReportesTodos
        Return objAD.SpObtenerRegistrosSinCondicion(ent)
    End Function


    Function ReportearTablas(ByRef ent As SuperEntidad) As DataTable
        ent.Vista = "VsTablas"
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = cam.TipTabla
        Dim objAD As New ReportesTodos
        Return objAD.SpObtenerRegistrosConUnaCondicion(ent)
    End Function


    Function ReportearUsuarios(ByRef ent As SuperEntidad) As DataTable
        ent.Vista = "VsUsuarios"
        ent.DatoEliminado = "1"
        Dim objAD As New ReportesTodos
        Return objAD.SpObtenerRegistrosSinCondicion(ent)
    End Function

    Function ReportearPersonales(ByRef ent As SuperEntidad) As DataTable
        ent.Vista = "VsPersonal"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        Dim objAD As New ReportesTodos
        Return objAD.SpObtenerRegistrosSinCondicion(ent)
    End Function

    Function ReportearPersonalesExportables(ByRef ent As SuperEntidad) As DataTable
        ent.Vista = "VsPersonal"
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = cam.Exp
        ent.DatoCondicion1 = "0"
        Dim objAD As New ReportesTodos
        Return objAD.SpObtenerRegistrosConUnaCondicion(ent)
    End Function


    Function ReportearAuxiliares(ByRef ent As SuperEntidad) As DataTable
        ent.Vista = "VsAuxiliar"
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = cam.TipAux
        Dim objAD As New ReportesTodos
        Return objAD.SpObtenerRegistrosConUnaCondicion(ent)
    End Function

    Function ReportearAuxiliaresTodos(ByRef ent As SuperEntidad) As DataTable
        ent.Vista = "VsAuxiliar"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        Dim objAD As New ReportesTodos
        Return objAD.SpObtenerRegistrosSinCondicion(ent)
    End Function

    Function ReportearDiasPorMes(ByRef ent As SuperEntidad) As DataTable
        ent.Vista = "VsDiasPorMes"
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoCondicion1 = cam.AnoDiasxMes
        Dim objAD As New ReportesTodos
        Return objAD.SpObtenerRegistrosConUnaCondicion(ent)
    End Function

    Function ReportearPerfiles(ByRef ent As SuperEntidad) As DataTable
        ent.Vista = "VsGrupos"
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoOrden = cam.CodGru
        Dim objAD As New ReportesTodos
        Return objAD.SpObtenerRegistrosSinCondicion(ent)
    End Function

    Function ReportearDiasPorMesTodos(ByRef ent As SuperEntidad) As DataTable
        ent.Vista = "VsDiasPorMes"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        Dim objAD As New ReportesTodos
        Return objAD.SpObtenerRegistrosSinCondicion(ent)
    End Function

    Function ReportearTipoCambio(ByRef ent As SuperEntidad) As DataTable
        ent.Vista = "VsTipoCambio"
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ent.CampoFecha = cam.FecTipCam
        Dim objAD As New ReportesTodos
        Return objAD.SpObtenerRegistrosEntreFechas(ent)
    End Function

    Function ReportearMovHoras(ByRef ent As SuperEntidad) As DataTable
        ent.Vista = "vsMovHoras"
        ent.DatoEliminado = "1"
        ent.DatoEstado = "1"
        ' ent.CampoCondicion1 = cam.CodProMh
        Dim objAD As New ReportesTodos
        Return objAD.SpObtenerRegistrosConUnaCondicion(ent)
    End Function


    Function reporteNumeroPersonalActivo() As DataTable
        Dim objAD As New ReportesTodos
        Return objAD.ReporteNumeroPersonalActivo
    End Function

    Function ReporteNumeroHorasTerminadas(ByRef ent As SuperEntidad) As DataTable
        ' ent.CampoCondicion1 = cam.CodProMh
        Dim objAD As New ReportesTodos
        Return objAD.ReporteNumeroHorasTerminadas(ent)
    End Function

    Function ReporteNumeroHorasTerminadasOri(ByRef ent As SuperEntidad) As DataTable
        ' ent.CampoCondicion1 = cam.CodProMh
        Dim objAD As New ReportesTodos
        Return objAD.ReporteNumeroHorasTerminadasOri(ent)
    End Function

    Function ReportePersonalSincompletarHorasOri(ByRef ent As SuperEntidad) As DataTable
        ' ent.CampoCondicion1 = cam.CodProMh
        Dim objAD As New ReportesTodos
        Return objAD.ReportePersonalSincompletarHorasOri(ent)
    End Function

    Function ReportePersonalSinMarcar(ByRef ent As SuperEntidad) As DataTable
        ' ent.CampoCondicion1 = cam.CodProMh
        Dim objAD As New ReportesTodos
        Return objAD.ReportePersonalSinMarcar(ent)
    End Function

    Function ReportePersonalSinMarcarOri(ByRef ent As SuperEntidad) As DataTable
        ' ent.CampoCondicion1 = cam.CodProMh
        Dim objAD As New ReportesTodos
        Return objAD.ReportePersonalSinMarcarOriginal(ent)
    End Function


    Function ReporteRegCompras(ByRef ent As SuperEntidad) As DataTable
        ent.Vista = "VsRegContab"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.CodOriRC
        ent.DatoCondicion1 = "4"
        'ent.CampoFiltro1 = cam.AnoRC
        'ent.CampoFiltro2 = cam.MesRC
        ent.CampoOrden = cam.FecVouRCC
        Dim objAD As New ReportesTodos
        Return objAD.SpObtenerRegistrosConUnaCondicionDosfiltros(ent)
    End Function

    Function reporteConceptos(ByRef ent As SuperEntidad) As DataTable
        Dim objAD As New ReportesTodos
        Return objAD.ReporteConceptos(ent)
    End Function


    Function ReportePlanilla(ByRef ent As SuperEntidad) As DataTable
        ent.Vista = "VsPlanilla"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        'ent.CampoCondicion1 = cam.AnoPla
        'ent.CampoCondicion2 = cam.MesPla
        'ent.CampoOrden = cam.CodPer
        Dim objAD As New ReportesTodos
        Return objAD.SpObtenerRegistrosConDosCondicion(ent)
    End Function


End Class
