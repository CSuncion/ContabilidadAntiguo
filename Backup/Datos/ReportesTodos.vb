Imports Entidad
Imports System.Data.SqlClient
Imports System.Data
Public Class ReportesTodos
    Private Sql As New SqlDatos
    Private Lista As New List(Of SuperEntidad)
    Private tab As New SuperEntidad
    Private Campo As New CamposEntidad
    Private Par As New ParametroSql

    Function ReporteNumeroPersonalActivo() As DataTable
        Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
        Sql.ComandoProcAlm("SpReportePersonalActivo")
        Return Sql.ObtenerTablaRegistro
    End Function

    Function ReportePersonalSincompletarHorasOri(ByRef ent As SuperEntidad) As DataTable
        Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
        Sql.ComandoProcAlm("SpReportePersonalSincompletarHorasOri")
        'Sql.AsignarParametro(Par.FechaMovHoras, ent.FechaMovHoras)
        Return Sql.ObtenerTablaRegistro
    End Function

    Function ReportePersonalInexistente(ByRef ent As SuperEntidad) As DataTable
        Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
        Sql.ComandoProcAlm("PersonalInexistente")
        Sql.AsignarParametro(Par.Desde, ent.Desde)
        Sql.AsignarParametro(Par.Hasta, ent.Hasta)
        Return Sql.ObtenerTablaRegistro
    End Function

    Function ReporteProyectoInexistente(ByRef ent As SuperEntidad) As DataTable
        Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
        Sql.ComandoProcAlm("ProyectoInexistente")
        Sql.AsignarParametro(Par.Desde, ent.Desde)
        Sql.AsignarParametro(Par.Hasta, ent.Hasta)
        Return Sql.ObtenerTablaRegistro
    End Function


    Function ReportePersonalSinMarcar(ByRef ent As SuperEntidad) As DataTable
        Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
        Sql.ComandoProcAlm("SpReportePersonalSinMarcar")
        'Sql.AsignarParametro(Par.FechaMovHoras, ent.FechaMovHoras)
        Return Sql.ObtenerTablaRegistro
    End Function

    Function ReporteConceptos(ByRef ent As SuperEntidad) As DataTable
        Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
        Sql.ComandoProcAlm("SpPptoInternoDetalleConceptos")
        'Sql.AsignarParametro(Par.CodigoPptoInterno, ent.CodigoPptoInterno)
        'Sql.AsignarParametro(Par.CodigoConcepto, ent.CodigoConcepto)
        Return Sql.ObtenerTablaRegistro
    End Function


    Function ReportePersonalSinMarcarOriginal(ByRef ent As SuperEntidad) As DataTable
        Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
        Sql.ComandoProcAlm("SpReportePersonalSinMarcarOri")
        'Sql.AsignarParametro(Par.FechaMovHoras, ent.FechaMovHoras)
        Return Sql.ObtenerTablaRegistro
    End Function

    Function ReporteNumeroHorasTerminadas(ByRef ent As SuperEntidad) As DataTable
        Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
        Sql.ComandoProcAlm("SpReporteHorasPorDia")
        'Sql.AsignarParametro(Par.FechaMovHoras, ent.FechaMovHoras)
        Return Sql.ObtenerTablaRegistro
    End Function

    Function ReporteNumeroHorasTerminadasOri(ByRef ent As SuperEntidad) As DataTable
        Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
        Sql.ComandoProcAlm("SpReporteHorasPorDiaOri")
        'Sql.AsignarParametro(Par.FechaMovHoras, ent.FechaMovHoras)
        Return Sql.ObtenerTablaRegistro
    End Function

    Function ReporteCostoPersonalPptoInt(ByRef ent As SuperEntidad) As DataTable
        Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
        Sql.ComandoProcAlm("SpCostosPersonalPptoInterno")
        'Sql.AsignarParametro(Par.CodigoPptoInterno, ent.CodigoPptoInterno)
        'Sql.AsignarParametro(Par.CodigoPersonal, ent.CodigoPersonal)
        Return Sql.ObtenerTablaRegistro
    End Function


    Function FiltrarTablaPorTabla(ByRef ent As SuperEntidad) As DataTable
        Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
        Sql.ComandoProcAlm("SpFiltrarItemsTablaPorTabla")
        Sql.AsignarParametro(Par.Filtro, ent.Filtro)
        Sql.AsignarParametro(Par.CampoOrden, ent.CampoOrden)
        Return Sql.ObtenerTablaRegistro
    End Function

    Function TraerIngresosRealesPorMes(ByRef ent As SuperEntidad) As DataTable
        Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
        Sql.ComandoProcAlm("SpIngresosRealesProyectoMensual")
        'Sql.AsignarParametro(Par.AnoRegContab, ent.anoRegContab)
        'Sql.AsignarParametro(Par.MesRegContab, ent.mesRegContab)
        Return Sql.ObtenerTablaRegistro
    End Function

    Function SpTraerHorasPlanillaPersonal(ByRef ent As SuperEntidad) As DataTable
        Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
        Sql.ComandoProcAlm("SpTraerHorasPlanillaPersonal")
        'Sql.AsignarParametro(Par.AnoRegContab, ent.anoRegContab)
        'Sql.AsignarParametro(Par.MesRegContab, ent.mesRegContab)
        Return Sql.ObtenerTablaRegistro
    End Function


    Function SpTraerCostosContratos(ByRef ent As SuperEntidad) As DataTable
        Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
        Sql.ComandoProcAlm("SpTraerCostosContratos")
        'Sql.AsignarParametro(Par.AnoRegContab, ent.anoRegContab)
        'Sql.AsignarParametro(Par.MesRegContab, ent.mesRegContab)
        Return Sql.ObtenerTablaRegistro
    End Function

    Function SpTraerOtrosCostos(ByRef ent As SuperEntidad) As DataTable
        Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
        Sql.ComandoProcAlm("SpTraerCostosOtrosGastos")
        'Sql.AsignarParametro(Par.AnoRegContab, ent.anoRegContab)
        'Sql.AsignarParametro(Par.MesRegContab, ent.mesRegContab)
        Return Sql.ObtenerTablaRegistro
    End Function



    Function SpObtenerRegistrosSinCondicion(ByRef ent As SuperEntidad) As DataTable
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpObtenerRegistrosSinCondicion")
            '/Asignar Parametros
            Sql.AsignarParametro(Par.Vista, ent.Vista)
            Sql.AsignarParametro(Par.DatoEliminado, ent.DatoEliminado)
            Sql.AsignarParametro(Par.DatoEstado, ent.DatoEstado)
            Sql.AsignarParametro(Par.CampoOrden, ent.CampoOrden)
            Return Sql.ObtenerTablaRegistro
        Catch ex As Exception
            MsgBox(ex.Message) : Return Sql.ObtenerTablaRegistro
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function


    Function SpObtenerRegistrosConUnaCondicion(ByRef ent As SuperEntidad) As DataTable
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpObtenerRegistrosConUnaCondicion")
            '/Asignar Parametros
            Sql.AsignarParametro(Par.Vista, ent.Vista)
            Sql.AsignarParametro(Par.DatoEliminado, ent.DatoEliminado)
            Sql.AsignarParametro(Par.DatoEstado, ent.DatoEstado)
            Sql.AsignarParametro(Par.CampoCondicion1, ent.CampoCondicion1)
            Sql.AsignarParametro(Par.DatoCondicion1, ent.DatoCondicion1)
            Sql.AsignarParametro(Par.CampoOrden, ent.CampoOrden)
            Return Sql.ObtenerTablaRegistro
        Catch ex As Exception
            MsgBox(ex.Message) : Return Sql.ObtenerTablaRegistro
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function

    Function SpObtenerRegistrosConDosCondicion(ByRef ent As SuperEntidad) As DataTable
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpObtenerRegistrosConDosCondicion")
            '/Asignar Parametros
            Sql.AsignarParametro(Par.Vista, ent.Vista)
            Sql.AsignarParametro(Par.DatoEliminado, ent.DatoEliminado)
            Sql.AsignarParametro(Par.DatoEstado, ent.DatoEstado)
            Sql.AsignarParametro(Par.CampoCondicion1, ent.CampoCondicion1)
            Sql.AsignarParametro(Par.DatoCondicion1, ent.DatoCondicion1)
            Sql.AsignarParametro(Par.CampoCondicion2, ent.CampoCondicion2)
            Sql.AsignarParametro(Par.DatoCondicion2, ent.DatoCondicion2)
            Sql.AsignarParametro(Par.CampoOrden, ent.CampoOrden)
            Return Sql.ObtenerTablaRegistro
        Catch ex As Exception
            MsgBox(ex.Message) : Return Sql.ObtenerTablaRegistro
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function


    Function SpObtenerRegistrosEntreFechas(ByRef ent As SuperEntidad) As DataTable
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpObtenerRegistrosEntreFechas")
            '/Asignar Parametros
            Sql.AsignarParametro(Par.Vista, ent.Vista)
            Sql.AsignarParametro(Par.DatoEliminado, ent.DatoEliminado)
            Sql.AsignarParametro(Par.DatoEstado, ent.DatoEstado)
            Sql.AsignarParametro(Par.CampoFecha, ent.CampoFecha)
            Sql.AsignarParametro(Par.Desde, ent.Desde)
            Sql.AsignarParametro(Par.Hasta, ent.Hasta)
            Sql.AsignarParametro(Par.CampoOrden, ent.CampoOrden)
            Return Sql.ObtenerTablaRegistro
        Catch ex As Exception
            MsgBox(ex.Message) : Return Sql.ObtenerTablaRegistro
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function

    Function SpObtenerRegistrosConUnaCondicionUnfiltro(ByRef ent As SuperEntidad) As DataTable
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpObtenerRegistrosConUnaCondicionUnfiltro")
            '/Asignar Parametros
            Sql.AsignarParametro(Par.Vista, ent.Vista)
            Sql.AsignarParametro(Par.DatoEliminado, ent.DatoEliminado)
            Sql.AsignarParametro(Par.DatoEstado, ent.DatoEstado)
            Sql.AsignarParametro(Par.CampoCondicion1, ent.CampoCondicion1)
            Sql.AsignarParametro(Par.DatoCondicion1, ent.DatoCondicion1)
            Sql.AsignarParametro(Par.CampoFiltro1, ent.CampoFiltro1)
            Sql.AsignarParametro(Par.DatoFiltro1, ent.DatoFiltro1)
            Sql.AsignarParametro(Par.CampoOrden, ent.CampoOrden)
            Return Sql.ObtenerTablaRegistro
        Catch ex As Exception
            MsgBox(ex.Message) : Return Sql.ObtenerTablaRegistro
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function

    Function SpObtenerRegistrosConUnaCondicionDosfiltros(ByRef ent As SuperEntidad) As DataTable
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpObtenerRegistrosConUnaCondicionDosFiltros")
            '/Asignar Parametros
            Sql.AsignarParametro(Par.Vista, ent.Vista)
            Sql.AsignarParametro(Par.DatoEliminado, ent.DatoEliminado)
            Sql.AsignarParametro(Par.DatoEstado, ent.DatoEstado)
            Sql.AsignarParametro(Par.CampoCondicion1, ent.CampoCondicion1)
            Sql.AsignarParametro(Par.DatoCondicion1, ent.DatoCondicion1)
            Sql.AsignarParametro(Par.CampoFiltro1, ent.CampoFiltro1)
            Sql.AsignarParametro(Par.DatoFiltro1, ent.DatoFiltro1)
            Sql.AsignarParametro(Par.CampoFiltro2, ent.CampoFiltro2)
            Sql.AsignarParametro(Par.DatoFiltro2, ent.DatoFiltro2)
            Sql.AsignarParametro(Par.CampoOrden, ent.CampoOrden)
            Return Sql.ObtenerTablaRegistro
        Catch ex As Exception
            MsgBox(ex.Message) : Return Sql.ObtenerTablaRegistro
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function




    'Function SpBuscarRegistroConDosCondicion(ByRef ent As SuperEntidad) As SuperEntidad
    '    '//
    '    Try
    '        Sql.Conectar(SqlDatos.Bd.Proyectos)
    '        Sql.ComandoProcAlm("SpBuscarRegistroConDosCondicion")
    '        '/Asignar Parametros
    '        Sql.AsignarParametro(Par.Vista, ent.Vista)
    '        Sql.AsignarParametro(Par.DatoEliminado, ent.DatoEliminado)
    '        Sql.AsignarParametro(Par.DatoEstado, ent.DatoEstado)
    '        Sql.AsignarParametro(Par.CampoCondicion1, ent.CampoCondicion1)
    '        Sql.AsignarParametro(Par.DatoCondicion1, ent.DatoCondicion1)
    '        Sql.AsignarParametro(Par.CampoCondicion2, ent.CampoCondicion2)
    '        Sql.AsignarParametro(Par.DatoCondicion2, ent.DatoCondicion2)
    '        '/Obtener IDr
    '        Dim iDr As IDataReader = Sql.ObtenerIDr
    '        While iDr.Read
    '            'Objeto Encontrado
    '            obj = Me.Objeto(iDr)
    '        End While
    '        Return obj
    '    Catch ex As Exception
    '        MsgBox(ex.Message) : Return obj
    '    Finally
    '        Sql.Desconectar()
    '    End Try
    '    '\\
    'End Function

    'Function SpBuscarRegistroConUnaCondicion(ByRef ent As SuperEntidad) As SuperEntidad
    '    '//
    '    Try
    '        Sql.Conectar(SqlDatos.Bd.Proyectos)
    '        Sql.ComandoProcAlm("SpBuscarRegistroConUnaCondicion")
    '        '/Asignar Parametros
    '        Sql.AsignarParametro(Par.Vista, ent.Vista)
    '        Sql.AsignarParametro(Par.DatoEliminado, ent.DatoEliminado)
    '        Sql.AsignarParametro(Par.DatoEstado, ent.DatoEstado)
    '        Sql.AsignarParametro(Par.CampoCondicion1, ent.CampoCondicion1)
    '        Sql.AsignarParametro(Par.DatoCondicion1, ent.DatoCondicion1)
    '        '/Obtener IDr
    '        Dim iDr As IDataReader = Sql.ObtenerIDr
    '        While iDr.Read
    '            'Objeto Encontrado
    '            obj = Me.Objeto(iDr)
    '        End While
    '        Return obj
    '    Catch ex As Exception
    '        MsgBox(ex.Message) : Return obj
    '    Finally
    '        Sql.Desconectar()
    '    End Try
    '    '\\
    'End Function


End Class
