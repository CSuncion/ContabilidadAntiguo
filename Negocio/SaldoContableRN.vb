Imports Entidad
Imports Datos

Public Class SaldoContableRN
    Dim cam As New CamposEntidad
    Public TotalActivo As Decimal = 0
    Public TotalPasivo As Decimal = 0
    Public SubTotalPatrimonio As Decimal = 0
    Public TotalActivoAcu As Decimal = 0
    Public TotalPasivoAcu As Decimal = 0
    Public SubTotalPatrimonioAcu As Decimal = 0



      Sub nuevoSaldoContable(ByRef ent As SuperEntidad)
            'ent.AnoMesDiasPorMes = ent.AnoDiasPorMes + "/" + ent.CodigoMes
            ent.EstadoRegistro = "1"
            ent.EliminadoRegistro = "1"
            ent.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
            ent.NombreUsuarioAgrega = SuperEntidad.xNombreUsuario
            ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
            ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
            ent.ClaveSaldoContable = ent.CodigoEmpresa + ent.CodigoCuentaPcge + ent.PeriodoRegContabCabe
            Dim objAD As New SaldoContableAD
            objAD.SpNuevoSaldoContable(ent)

      End Sub

      Sub ModificarSaldoContable(ByRef ent As SuperEntidad)
            '//
            '/Vovemos a traer el usuario actual de la b.d
            ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
            ent.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
            '/Vovemos a traer el usuario actual de la b.d
            ''/Mandamos a modificar la b.d
            Dim objAD As New SaldoContableAD
            objAD.SpModificarSaldoContable(ent)
            '\\
      End Sub


    Sub EliminarCuentaSaldoLog(ByRef ent As SuperEntidad)
        '//
        '/Datos por defecto
        ent.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
        ent.CodigoPersonalModifica = SuperEntidad.xCodigoPersonal
        ent.EliminadoRegistro = "0"
        '/Mandamos a modificar la b.d
        Dim objAD As New RegContabCabeAD
        objAD.SpModificarRegContabCabe(ent)
        '\\
    End Sub

    Sub eliminarCuentaSaldoFis(ByRef ent As SuperEntidad)
        '//
        Dim objAD As New RegContabCabeAD
        objAD.SpEliminarRegcontabCabe(ent)
        '\\
    End Sub

    Function buscarCuentaSaldoExisPorClave(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Dim obj As New SuperEntidad
        ent.Vista = "VsSaldoContable"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.ClaSalCon
        ent.DatoCondicion1 = ent.ClaveSaldoContable
        Dim objAD As New SaldoContableAD
        obj = objAD.SpBuscarRegistroConUnaCondicion(ent)
        Return obj
        '\\
    End Function

    Function obtenerRegContabEntreFechas(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        ent.Vista = "VsRegContabCabe"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""
        ent.CampoCondicion1 = cam.CodOriRC
        ent.CampoFecha = cam.FecVouRCC
        Dim objAD As New RegContabCabeAD
        Return objAD.SpObtenerRegistrosContablesEntreFechas(ent)
    End Function

    Function obtenerSaldoContableXPeriodo(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '// Trae una lista segun requerimento para llenar Grilla
        Dim listObj As New List(Of SuperEntidad)
        ent.Vista = "VsSaldoContable"
        ent.DatoEliminado = "1"
        ent.DatoEstado = ""  'Activos e Inactivos

        ent.CampoCondicion1 = cam.PeriodoRCC
        ent.DatoCondicion1 = ent.PeriodoRegContabCabe 'En este caso es ano
        ent.CampoCondicion2 = cam.CodEmp
        ent.DatoCondicion2 = ent.CodigoEmpresa
        'ent.CampoOrden = cam.CodForCon + "," + cam.CodCtaPcge
        Dim objAD As New SaldoContableAD
        listObj = objAD.SpObtenerRegistrosConDosCondicion(ent)
        Return listObj
        '\\
    End Function

    Function obtenerDiferenciaDebeHaber(ByRef xobj As SuperEntidad, ByVal xmes As String) As Decimal

        Select Case xmes
            Case "00" : xobj.ImporteSolesFormatoContable = xobj.DebeS00SaldoContable - xobj.HabeS00SaldoContable
            Case "01" : xobj.ImporteSolesFormatoContable = xobj.DebeS01SaldoContable - xobj.HabeS01SaldoContable
            Case "02" : xobj.ImporteSolesFormatoContable = xobj.DebeS02SaldoContable - xobj.HabeS02SaldoContable
            Case "03" : xobj.ImporteSolesFormatoContable = xobj.DebeS03SaldoContable - xobj.HabeS03SaldoContable
            Case "04" : xobj.ImporteSolesFormatoContable = xobj.DebeS04SaldoContable - xobj.HabeS04SaldoContable
            Case "05" : xobj.ImporteSolesFormatoContable = xobj.DebeS05SaldoContable - xobj.HabeS05SaldoContable
            Case "06" : xobj.ImporteSolesFormatoContable = xobj.DebeS06SaldoContable - xobj.HabeS06SaldoContable
            Case "07" : xobj.ImporteSolesFormatoContable = xobj.DebeS07SaldoContable - xobj.HabeS07SaldoContable
            Case "08" : xobj.ImporteSolesFormatoContable = xobj.DebeS08SaldoContable - xobj.HabeS08SaldoContable
            Case "09" : xobj.ImporteSolesFormatoContable = xobj.DebeS09SaldoContable - xobj.HabeS09SaldoContable
            Case "10" : xobj.ImporteSolesFormatoContable = xobj.DebeS10SaldoContable - xobj.HabeS10SaldoContable
            Case "11" : xobj.ImporteSolesFormatoContable = xobj.DebeS11SaldoContable - xobj.HabeS11SaldoContable
            Case "12" : xobj.ImporteSolesFormatoContable = xobj.DebeS12SaldoContable - xobj.HabeS12SaldoContable

        End Select

        Return xobj.ImporteSolesFormatoContable

    End Function

    Function obtenerDiferenciaDebeHaberAcumulado(ByRef xobj As SuperEntidad, ByVal xmes As String) As Decimal
        Dim montacum As Decimal = 0

        If xmes >= "00" Then
            montacum = xobj.DebeS00SaldoContable - xobj.HabeS00SaldoContable
        End If

        If xmes >= "01" Then
            montacum += xobj.DebeS01SaldoContable - xobj.HabeS01SaldoContable
        End If

        If xmes >= "02" Then
            montacum += xobj.DebeS02SaldoContable - xobj.HabeS02SaldoContable
        End If

        If xmes >= "03" Then
            montacum += xobj.DebeS03SaldoContable - xobj.HabeS03SaldoContable
        End If

        If xmes >= "04" Then
            montacum += xobj.DebeS04SaldoContable - xobj.HabeS04SaldoContable
        End If

        If xmes >= "05" Then
            montacum += xobj.DebeS05SaldoContable - xobj.HabeS05SaldoContable
        End If

        If xmes >= "06" Then
            montacum += xobj.DebeS06SaldoContable - xobj.HabeS06SaldoContable
        End If

        If xmes >= "07" Then
            montacum += xobj.DebeS07SaldoContable - xobj.HabeS07SaldoContable
        End If

        If xmes >= "08" Then
            montacum += xobj.DebeS08SaldoContable - xobj.HabeS08SaldoContable
        End If

        If xmes >= "09" Then
            montacum += xobj.DebeS09SaldoContable - xobj.HabeS09SaldoContable
        End If

        If xmes >= "10" Then
            montacum += xobj.DebeS10SaldoContable - xobj.HabeS10SaldoContable
        End If

        If xmes >= "11" Then
            montacum += xobj.DebeS11SaldoContable - xobj.HabeS11SaldoContable
        End If

        If xmes >= "12" Then
            montacum += xobj.DebeS12SaldoContable - xobj.HabeS12SaldoContable
        End If

        Return montacum

    End Function

    Function ObtenerGananciaPerdidaXFuncion(ByRef ent As SuperEntidad) As List(Of Reportes.EstadoFinanciero)
        Dim lisres As New List(Of Reportes.EstadoFinanciero)
        'Dim res As Reportes.GananciaPerdidaXFuncion
        Dim mes As String = ent.CodigoMes

        Dim objAD As New SaldoContableAD
        Dim cta70 As New SuperEntidad
        cta70.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "70" + ent.PeriodoRegContabCabe
        cta70 = Me.buscarCuentaSaldoExisPorClave(cta70)
        Dim str70 As New Reportes.EstadoFinanciero
        If cta70.ClaveSaldoContable <> "" Then
            str70.codigo = "70"
            str70.nombre = cta70.NombreCuentaPcge
            str70.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta70, mes))
            str70.strmontomes = str70.montomes.ToString
            str70.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta70, mes))
            str70.strmontoacumulado = str70.montoacumulado.ToString
            lisres.Add(str70)
        End If

        '
        Dim cta74 As New SuperEntidad
        cta74.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "74" + ent.PeriodoRegContabCabe
        cta74 = Me.buscarCuentaSaldoExisPorClave(cta74)
        Dim str74 As New Reportes.EstadoFinanciero
        If cta74.ClaveSaldoContable <> "" Then
            str74.codigo = "74"
            str74.nombre = cta74.NombreCuentaPcge
            str74.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta74, mes)) * (-1)
            str74.strmontomes = str74.montomes.ToString
            str74.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta74, mes)) * (-1)
            str74.strmontoacumulado = str74.montoacumulado.ToString
            lisres.Add(str74)
        End If

        ''Poner linea de 70 y 74
        Dim strl74 As New Reportes.EstadoFinanciero
        strl74.codigo = ""
        strl74.nombre = ""
        strl74.montomes = 0
        strl74.strmontomes = "-----------------"
        strl74.strmontoacumulado = "-----------------"
        lisres.Add(strl74)

        'Ventas Netas
        Dim strvtan As New Reportes.EstadoFinanciero
        strvtan.codigo = ""
        strvtan.nombre = "     VENTAS NETAS"
        strvtan.montomes = str70.montomes + str74.montomes
        strvtan.strmontomes = strvtan.montomes.ToString
        strvtan.montoacumulado = str70.montoacumulado + str74.montoacumulado
        strvtan.strmontoacumulado = strvtan.montoacumulado.ToString
        lisres.Add(strvtan)

        '
        'Dim cta69 As New SuperEntidad
        'cta69.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "69" + ent.PeriodoRegContabCabe
        'cta69 = Me.buscarCuentaSaldoExisPorClave(cta69)
        'Dim str69 As New Reportes.EstadoFinanciero
        'If cta69.ClaveSaldoContable <> "" Then
        '    str69.codigo = "69"
        '    str69.nombre = cta69.NombreCuentaPcge
        '    str69.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta69, mes)) * (-1)
        '    str69.strmontomes = str69.montomes.ToString
        '    str69.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta69, mes)) * (-1)
        '    str69.strmontoacumulado = str69.montoacumulado.ToString
        '    lisres.Add(str69)
        'End If

        Dim cta69 As New SuperEntidad
        cta69.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "93" + ent.PeriodoRegContabCabe
        cta69 = Me.buscarCuentaSaldoExisPorClave(cta69)
        Dim str69 As New Reportes.EstadoFinanciero
        If cta69.ClaveSaldoContable <> "" Then
            str69.codigo = "93"
            str69.nombre = cta69.NombreCuentaPcge
            str69.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta69, mes)) * (-1)
            str69.strmontomes = str69.montomes.ToString
            str69.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta69, mes)) * (-1)
            str69.strmontoacumulado = str69.montoacumulado.ToString
            lisres.Add(str69)
        End If


        ''Poner linea de Costos 69
        Dim strl69 As New Reportes.EstadoFinanciero
        strl69.codigo = ""
        strl69.nombre = ""
        strl69.montomes = 0
        strl69.strmontomes = "-----------------"
        strl69.strmontoacumulado = "-----------------"
        lisres.Add(strl69)

        'Utilidad Bruta
        Dim strutib As New Reportes.EstadoFinanciero
        strutib.codigo = ""
        strutib.nombre = "     UTILIDAD BRUTA"
        strutib.montomes = strvtan.montomes + str69.montomes
        strutib.strmontomes = strutib.montomes.ToString
        strutib.montoacumulado = strvtan.montoacumulado + str69.montoacumulado
        strutib.strmontoacumulado = strutib.montoacumulado.ToString

        lisres.Add(strutib)

        '
        'Dim cta95 As New SuperEntidad
        'cta95.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "95" + ent.PeriodoRegContabCabe
        'cta95 = Me.buscarCuentaSaldoExisPorClave(cta95)
        'Dim str95 As New Reportes.EstadoFinanciero
        'If cta95.ClaveSaldoContable <> "" Then
        '    str95.codigo = "95"
        '    str95.nombre = cta95.NombreCuentaPcge
        '    str95.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta95, mes)) * (-1)
        '    str95.strmontomes = str95.montomes.ToString
        '    str95.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta95, mes)) * (-1)
        '    str95.strmontoacumulado = str95.montoacumulado.ToString
        '    lisres.Add(str95)
        'End If

        Dim cta95 As New SuperEntidad
        cta95.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "92" + ent.PeriodoRegContabCabe
        cta95 = Me.buscarCuentaSaldoExisPorClave(cta95)
        Dim str95 As New Reportes.EstadoFinanciero
        If cta95.ClaveSaldoContable <> "" Then
            str95.codigo = "92"
            str95.nombre = cta95.NombreCuentaPcge
            str95.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta95, mes)) * (-1)
            str95.strmontomes = str95.montomes.ToString
            str95.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta95, mes)) * (-1)
            str95.strmontoacumulado = str95.montoacumulado.ToString
            lisres.Add(str95)
        End If

        'Dim cta94 As New SuperEntidad
        'cta94.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "94" + ent.PeriodoRegContabCabe
        'cta94 = Me.buscarCuentaSaldoExisPorClave(cta94)
        'Dim str94 As New Reportes.EstadoFinanciero
        'If cta94.ClaveSaldoContable <> "" Then
        '    str94.codigo = "94"
        '    str94.nombre = cta94.NombreCuentaPcge
        '    str94.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta94, mes)) * (-1)
        '    str94.strmontomes = str94.montomes.ToString
        '    str94.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta94, mes)) * (-1)
        '    str94.strmontomes = str94.montoacumulado.ToString
        '    lisres.Add(str94)
        'End If

        Dim cta91 As New SuperEntidad
        cta91.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "91" + ent.PeriodoRegContabCabe
        cta91 = Me.buscarCuentaSaldoExisPorClave(cta91)
        Dim str91 As New Reportes.EstadoFinanciero
        If cta91.ClaveSaldoContable <> "" Then
            str91.codigo = "91"
            str91.nombre = cta91.NombreCuentaPcge
            str91.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta91, mes)) * (-1)
            str91.strmontomes = str91.montomes.ToString
            str91.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta91, mes)) * (-1)
            str91.strmontomes = str91.montoacumulado.ToString
            lisres.Add(str91)
        End If

        Dim cta94 As New SuperEntidad
        cta94.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "94" + ent.PeriodoRegContabCabe
        cta94 = Me.buscarCuentaSaldoExisPorClave(cta94)
        Dim str94 As New Reportes.EstadoFinanciero
        If cta94.ClaveSaldoContable <> "" Then
            str94.codigo = "94"
            str94.nombre = cta94.NombreCuentaPcge
            str94.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta94, mes)) * (-1)
            str94.strmontomes = str94.montomes.ToString
            str94.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta94, mes)) * (-1)
            str94.strmontomes = str94.montoacumulado.ToString
            lisres.Add(str94)
        End If


        ''Poner linea de 91
        Dim strl91 As New Reportes.EstadoFinanciero
        strl91.codigo = ""
        strl91.nombre = ""
        strl91.montomes = 0
        strl91.strmontomes = "-----------------"
        strl91.strmontoacumulado = "-----------------"
        lisres.Add(strl91)

        'Utilidad Operativa
        Dim strutio As New Reportes.EstadoFinanciero
        strutio.codigo = ""
        strutio.nombre = "     UTILIDAD DE OPERACION"
        strutio.montomes = strutib.montomes + str95.montomes + str91.montomes + str94.montomes
        strutio.strmontomes = strutio.montomes.ToString
        strutio.montoacumulado = strutib.montoacumulado + str95.montoacumulado + str91.montoacumulado + str94.montoacumulado
        strutio.strmontoacumulado = strutio.montoacumulado.ToString
        lisres.Add(strutio)

        'Otros Ingresos Egresps 
        Dim stroie As New Reportes.EstadoFinanciero
        stroie.codigo = ""
        stroie.nombre = " OTROS INGRESOS Y EGRESOS"
        stroie.montomes = 0
        stroie.strmontomes = ""
        lisres.Add(stroie)

        'iNGRESOS Financieros
        Dim cta77 As New SuperEntidad
        cta77.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "77" + ent.PeriodoRegContabCabe
        cta77 = Me.buscarCuentaSaldoExisPorClave(cta77)
        Dim str77 As New Reportes.EstadoFinanciero
        If cta77.ClaveSaldoContable <> "" Then
            str77.codigo = "77"
            str77.nombre = cta77.NombreCuentaPcge
            str77.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta77, mes))
            str77.strmontomes = str77.montomes.ToString
            str77.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta77, mes))
            str77.strmontoacumulado = str77.montoacumulado.ToString
            lisres.Add(str77)
        End If

        'Descuentos y reb.Obtenidas
        Dim cta72 As New SuperEntidad
        cta72.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "72" + ent.PeriodoRegContabCabe
        cta72 = Me.buscarCuentaSaldoExisPorClave(cta72)
        Dim str72 As New Reportes.EstadoFinanciero
        If cta72.ClaveSaldoContable <> "" Then
            str72.codigo = "72"
            str72.nombre = cta72.NombreCuentaPcge
            str72.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta72, mes))
            str72.strmontomes = str72.montomes.ToString
            str72.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta72, mes))
            str72.strmontoacumulado = str72.montoacumulado.ToString
            lisres.Add(str72)
        End If


        'Descuentos y reb.Obtenidas
        Dim cta73 As New SuperEntidad
        cta73.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "73" + ent.PeriodoRegContabCabe
        cta73 = Me.buscarCuentaSaldoExisPorClave(cta73)
        Dim str73 As New Reportes.EstadoFinanciero
        If cta73.ClaveSaldoContable <> "" Then
            str73.codigo = "73"
            str73.nombre = cta73.NombreCuentaPcge
            str73.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta73, mes))
            str73.strmontomes = str73.montomes.ToString
            str73.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta73, mes))
            str73.strmontoacumulado = str73.montoacumulado.ToString
            lisres.Add(str73)
        End If

        'Otros Ing.Gestion 
        Dim cta75 As New SuperEntidad
        cta75.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "75" + ent.PeriodoRegContabCabe
        cta75 = Me.buscarCuentaSaldoExisPorClave(cta75)
        Dim str75 As New Reportes.EstadoFinanciero
        If cta75.ClaveSaldoContable <> "" Then
            str75.codigo = "75"
            str75.nombre = cta75.NombreCuentaPcge
            str75.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta75, mes))
            str75.strmontomes = str75.montomes.ToString
            str75.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta75, mes))
            str75.strmontoacumulado = str75.montoacumulado.ToString
            lisres.Add(str75)
        End If

        'Gastos Financieros
        Dim cta97 As New SuperEntidad
        cta97.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "97" + ent.PeriodoRegContabCabe
        cta97 = Me.buscarCuentaSaldoExisPorClave(cta97)
        Dim str97 As New Reportes.EstadoFinanciero
        If cta97.ClaveSaldoContable <> "" Then
            str97.codigo = "97"
            str97.nombre = cta97.NombreCuentaPcge
            str97.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta97, mes)) * (-1)
            str97.strmontomes = str97.montomes.ToString
            str97.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta97, mes)) * (-1)
            str97.strmontoacumulado = str97.montoacumulado.ToString
            lisres.Add(str97)
        End If


        ''Ganancia x Medicion
        'Dim cta65 As New SuperEntidad
        'cta65.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "65" + ent.PeriodoRegContabCabe
        'cta65 = Me.buscarCuentaSaldoExisPorClave(cta65)
        'Dim str65 As New Reportes.EstadoFinanciero
        'If cta65.ClaveSaldoContable <> "" Then
        '    str65.codigo = "65"
        '    str65.nombre = cta65.NombreCuentaPcge
        '    str65.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta65, mes)) * (-1)
        '    str65.strmontomes = str65.montomes.ToString
        '    str65.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta65, mes)) * (-1)
        '    str65.strmontoacumulado = str65.montoacumulado.ToString
        '    lisres.Add(str65)
        'End If

        ' ''Poner linea 65
        'Dim strl65 As New Reportes.EstadoFinanciero
        'strl65.codigo = ""
        'strl65.nombre = ""
        'strl65.montomes = 0
        'strl65.strmontomes = "-----------------"
        'lisres.Add(strl65)

        'Resultados antes de impuestos y par
        Dim strraip As New Reportes.EstadoFinanciero
        strraip.codigo = ""
        strraip.nombre = "     RESULTADOS ANTES DE IMPUESTOS Y PART"
        strraip.montomes = strutio.montomes + str77.montomes + str97.montomes + str72.montomes + str73.montomes + str75.montomes
        strraip.strmontomes = strraip.montomes.ToString
        strraip.montoacumulado = strutio.montoacumulado + str77.montoacumulado + str97.montoacumulado + str72.montoacumulado + str73.montoacumulado + str75.montoacumulado
        strraip.strmontoacumulado = strraip.montoacumulado.ToString
        lisres.Add(strraip)

        'Guardando Resultado  Ejercicio
        Dim iPerConRN As New PeriodoRN
        Dim iPerCon As New SuperEntidad
        iPerCon.ClavePeriodo = SuperEntidad.xCodigoEmpresa + "-" + ent.PeriodoRegContabCabe + ent.CodigoMes
        iPerCon = iPerConRN.BuscarPeriodoXClave(iPerCon)
        iPerCon.ResultadoMes = CType(strraip.montomes.ToString, Decimal)
        iPerCon.ResultadoAcumulado = CType(strraip.montoacumulado.ToString, Decimal)
        iPerConRN.modificarPeriodo(iPerCon)

        ''Linea Final1 
        Dim strlFin1 As New Reportes.EstadoFinanciero
        strlFin1.codigo = ""
        strlFin1.nombre = ""
        strlFin1.montomes = 0
        strlFin1.strmontomes = "========="
        strlFin1.strmontoacumulado = "========="
        lisres.Add(strlFin1)

        'Impuesto a la rentam
        Dim strimre As New Reportes.EstadoFinanciero
        strimre.codigo = ""
        strimre.nombre = "     IMPUESTO A LA RENTA"
        strimre.montomes = strraip.montomes * (-30) / 100
        strimre.strmontomes = strimre.montomes.ToString
        strimre.montoacumulado = strraip.montoacumulado * (-30) / 100
        strimre.strmontomes = strimre.montoacumulado.ToString
        lisres.Add(strimre)

        ''Impuesto a la renta
        Dim strlimre As New Reportes.EstadoFinanciero
        strlimre.codigo = ""
        strlimre.nombre = ""
        strlimre.montomes = 0
        strlimre.strmontomes = "-----------------"
        strlimre.strmontoacumulado = "-----------------"
        lisres.Add(strlimre)


        'Resultado del Ejercicio 
        Dim strreej As New Reportes.EstadoFinanciero
        strreej.codigo = ""
        strreej.nombre = "     RESULTADOS ANTES DE IMPUESTOS Y PART"
        strreej.montomes = strraip.montomes + strimre.montomes
        strreej.strmontomes = strreej.montomes.ToString
        strreej.montoacumulado = strraip.montoacumulado + strimre.montoacumulado
        strreej.strmontoacumulado = strreej.montoacumulado.ToString
        lisres.Add(strreej)

        ''Linea Final 
        Dim strlFin As New Reportes.EstadoFinanciero
        strlFin.codigo = ""
        strlFin.nombre = ""
        strlFin.montomes = 0
        strlFin.strmontomes = "========="
        strlFin.strmontoacumulado = "========="
        lisres.Add(strlFin)

        Return lisres

    End Function


    Function ObtenerGananciaPerdidaXNaturaleza(ByRef ent As SuperEntidad) As List(Of Reportes.EstadoFinanciero)
        Dim lisres As New List(Of Reportes.EstadoFinanciero)
        'Dim res As Reportes.GananciaPerdidaXFuncion
        Dim mes As String = ent.CodigoMes

        Dim objAD As New SaldoContableAD
        Dim cta70 As New SuperEntidad
        cta70.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "70" + ent.PeriodoRegContabCabe
        cta70 = Me.buscarCuentaSaldoExisPorClave(cta70)
        Dim str70 As New Reportes.EstadoFinanciero
        If cta70.ClaveSaldoContable <> "" Then
            str70.codigo = "70"
            str70.nombre = cta70.NombreCuentaPcge
            str70.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta70, mes))
            str70.strmontomes = str70.montomes.ToString
            str70.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta70, mes))
            str70.strmontoacumulado = str70.montoacumulado.ToString
            lisres.Add(str70)
        End If

        '
        Dim cta74 As New SuperEntidad
        cta74.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "74" + ent.PeriodoRegContabCabe
        cta74 = Me.buscarCuentaSaldoExisPorClave(cta74)
        Dim str74 As New Reportes.EstadoFinanciero
        If cta74.ClaveSaldoContable <> "" Then
            str74.codigo = "74"
            str74.nombre = cta74.NombreCuentaPcge
            str74.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta74, mes)) * (-1)
            str74.strmontomes = str74.montomes.ToString
            str74.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta74, mes)) * (-1)
            str74.strmontoacumulado = str74.montoacumulado.ToString
            lisres.Add(str74)
        End If

        ''Poner linea de 70 y 74
        Dim strl74 As New Reportes.EstadoFinanciero
        strl74.codigo = ""
        strl74.nombre = ""
        strl74.montomes = 0
        strl74.strmontomes = "-----------------"
        lisres.Add(strl74)

        'Ventas Netas
        Dim strvtan As New Reportes.EstadoFinanciero
        strvtan.codigo = ""
        strvtan.nombre = "     VENTAS NETAS"
        strvtan.montomes = str70.montomes + str74.montomes
        strvtan.strmontomes = strvtan.montomes.ToString
        strvtan.montoacumulado = str70.montoacumulado + str74.montoacumulado
        strvtan.strmontoacumulado = strvtan.montoacumulado.ToString
        lisres.Add(strvtan)

        '
        Dim cta60 As New SuperEntidad
        cta60.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "60" + ent.PeriodoRegContabCabe
        cta60 = Me.buscarCuentaSaldoExisPorClave(cta60)
        Dim str60 As New Reportes.EstadoFinanciero
        If cta60.ClaveSaldoContable <> "" Then
            str60.codigo = "60"
            str60.nombre = cta60.NombreCuentaPcge
            str60.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta60, mes)) * (-1)
            str60.strmontomes = str60.montomes.ToString
            str60.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta60, mes)) * (-1)
            str60.strmontoacumulado = str60.montoacumulado.ToString
            lisres.Add(str60)
        End If


        'Cuenta 61
        Dim cta61 As New SuperEntidad
        cta61.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "61" + ent.PeriodoRegContabCabe
        cta61 = Me.buscarCuentaSaldoExisPorClave(cta61)
        'Cuenta 69
        Dim cta69 As New SuperEntidad
        cta69.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "69" + ent.PeriodoRegContabCabe
        cta69 = Me.buscarCuentaSaldoExisPorClave(cta69)

        Dim str61 As New Reportes.EstadoFinanciero
        If cta61.ClaveSaldoContable <> "" Then
            str61.codigo = "61-69"
            str61.nombre = cta61.NombreCuentaPcge
            'Si 61 es > 69 es positivo 
            Dim mon61 As Decimal = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta61, mes))
            Dim mon69 As Decimal = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta69, mes))
            Dim mon61a As Decimal = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta61, mes))
            Dim mon69a As Decimal = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta69, mes))
            If mon61 > mon69 Then
                str61.montomes = mon61 - mon69
            Else
                str61.montomes = mon69 - mon61
            End If

            str61.strmontomes = str61.montomes.ToString

            If mon61a > mon69a Then
                str61.montoacumulado = mon61a - mon69a
            Else
                str61.montoacumulado = mon69a - mon61a
            End If

            str61.strmontoacumulado = str61.montoacumulado.ToString
            lisres.Add(str61)
        End If

        ''Poner linea de  61-69
        Dim strl69 As New Reportes.EstadoFinanciero
        strl69.codigo = ""
        strl69.nombre = ""
        strl69.montomes = 0
        strl69.strmontomes = "-----------------"
        lisres.Add(strl69)

        'Margen Comercial
        Dim strmaco As New Reportes.EstadoFinanciero
        strmaco.codigo = "80"
        strmaco.nombre = "MARGEN COMERCIAL"
        strmaco.montomes = strvtan.montomes + str61.montomes
        strmaco.strmontomes = strmaco.montomes.ToString
        strmaco.montoacumulado = strvtan.montoacumulado + str61.montoacumulado
        strmaco.strmontoacumulado = strmaco.montoacumulado.ToString
        lisres.Add(strmaco)


        'Consumos               
        Dim strcon As New Reportes.EstadoFinanciero
        strcon.codigo = ""
        strcon.nombre = " COMSUMOS "
        strcon.montomes = 0
        strcon.strmontomes = ""
        lisres.Add(strcon)

        '
        Dim cta63 As New SuperEntidad
        cta63.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "63" + ent.PeriodoRegContabCabe
        cta63 = Me.buscarCuentaSaldoExisPorClave(cta63)
        Dim str63 As New Reportes.EstadoFinanciero
        If cta63.ClaveSaldoContable <> "" Then
            str63.codigo = "63"
            str63.nombre = cta63.NombreCuentaPcge
            str63.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta63, mes)) * (-1)
            str63.strmontomes = str63.montomes.ToString
            str63.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta63, mes)) * (-1)
            str63.strmontoacumulado = str63.montoacumulado.ToString
            lisres.Add(str63)
        End If

        ''Poner linea de  63 en la 82
        Dim strl63 As New Reportes.EstadoFinanciero
        strl63.codigo = ""
        strl63.nombre = ""
        strl63.montomes = 0
        strl63.strmontomes = "-----------------"
        lisres.Add(strl63)

        'Valor Agreagado  
        Dim strvaag As New Reportes.EstadoFinanciero
        strvaag.codigo = "82"
        strvaag.nombre = "VALOR AGREGADO"
        strvaag.montomes = strmaco.montomes + str63.montomes
        strvaag.strmontomes = strvaag.montomes.ToString
        strvaag.montoacumulado = strmaco.montoacumulado + str63.montoacumulado
        strvaag.strmontoacumulado = strvaag.montoacumulado.ToString
        lisres.Add(strvaag)


        '
        Dim cta62 As New SuperEntidad
        cta62.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "62" + ent.PeriodoRegContabCabe
        cta62 = Me.buscarCuentaSaldoExisPorClave(cta62)
        Dim str62 As New Reportes.EstadoFinanciero
        If cta62.ClaveSaldoContable <> "" Then
            str62.codigo = "62"
            str62.nombre = cta62.NombreCuentaPcge
            str62.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta63, mes)) * (-1)
            str62.strmontomes = str62.montomes.ToString
            str62.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta63, mes)) * (-1)
            str62.strmontoacumulado = str62.montoacumulado.ToString
            lisres.Add(str62)
        End If

        Dim cta64 As New SuperEntidad
        cta64.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "64" + ent.PeriodoRegContabCabe
        cta64 = Me.buscarCuentaSaldoExisPorClave(cta64)
        Dim str64 As New Reportes.EstadoFinanciero
        If cta64.ClaveSaldoContable <> "" Then
            str64.codigo = "64"
            str64.nombre = cta64.NombreCuentaPcge
            str64.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta64, mes)) * (-1)
            str64.strmontomes = str64.montomes.ToString
            str64.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta64, mes)) * (-1)
            str64.strmontoacumulado = str64.montoacumulado.ToString
            lisres.Add(str64)
        End If

        ''Poner linea de  64 en la 83
        Dim strl64 As New Reportes.EstadoFinanciero
        strl64.codigo = ""
        strl64.nombre = ""
        strl64.montomes = 0
        strl64.strmontomes = "-----------------"
        lisres.Add(strl64)

        'Valor Agreagado  
        Dim strexbr As New Reportes.EstadoFinanciero
        strexbr.codigo = "83"
        strexbr.nombre = "EXCEDENTE(INSUFICIENCIA) BRUTA EXPLOTACION"
        strexbr.montomes = strvaag.montomes + str62.montomes + str64.montomes
        strexbr.strmontomes = strexbr.montomes.ToString
        strexbr.montoacumulado = strvaag.montoacumulado + str62.montoacumulado + str64.montoacumulado
        strexbr.strmontoacumulado = strexbr.montoacumulado.ToString
        lisres.Add(strexbr)

        Dim cta65 As New SuperEntidad
        cta65.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "65" + ent.PeriodoRegContabCabe
        cta65 = Me.buscarCuentaSaldoExisPorClave(cta65)
        Dim str65 As New Reportes.EstadoFinanciero
        If cta65.ClaveSaldoContable <> "" Then
            str65.codigo = "65"
            str65.nombre = cta65.NombreCuentaPcge
            str65.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta65, mes)) * (-1)
            str65.strmontomes = str65.montomes.ToString
            str65.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta65, mes)) * (-1)
            str65.strmontoacumulado = str65.montoacumulado.ToString
            lisres.Add(str65)
        End If

        Dim cta68 As New SuperEntidad
        cta68.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "68" + ent.PeriodoRegContabCabe
        cta68 = Me.buscarCuentaSaldoExisPorClave(cta68)
        Dim str68 As New Reportes.EstadoFinanciero
        If cta68.ClaveSaldoContable <> "" Then
            str68.codigo = "68"
            str68.nombre = cta68.NombreCuentaPcge
            str68.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta68, mes)) * (-1)
            str68.strmontomes = str68.montomes.ToString
            str68.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta68, mes)) * (-1)
            str68.strmontoacumulado = str68.montoacumulado.ToString
            lisres.Add(str68)
        End If

        ''Poner linea de  68 en la 84
        Dim strl68 As New Reportes.EstadoFinanciero
        strl68.codigo = ""
        strl68.nombre = ""
        strl68.montomes = 0
        strl68.strmontomes = "-----------------"
        lisres.Add(strl68)

        'Resultado Expltacion
        Dim strreex As New Reportes.EstadoFinanciero
        strreex.codigo = "84"
        strreex.nombre = "RESULTADO DE EXPLOTACION"
        strreex.montomes = strexbr.montomes + str65.montomes + str68.montomes
        strreex.strmontomes = strreex.montomes.ToString
        strreex.montoacumulado = strexbr.montoacumulado + str65.montoacumulado + str68.montoacumulado
        strreex.strmontoacumulado = strreex.montoacumulado.ToString
        lisres.Add(strreex)

        'iNGRESOS Financieros
        Dim cta77 As New SuperEntidad
        cta77.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "77" + ent.PeriodoRegContabCabe
        cta77 = Me.buscarCuentaSaldoExisPorClave(cta77)
        Dim str77 As New Reportes.EstadoFinanciero
        If cta77.ClaveSaldoContable <> "" Then
            str77.codigo = "77"
            str77.nombre = cta77.NombreCuentaPcge
            str77.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta77, mes))
            str77.strmontomes = str77.montomes.ToString
            str77.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta77, mes))
            str77.strmontoacumulado = str77.montoacumulado.ToString
            lisres.Add(str77)
        End If

        'Cargas Financieras   
        Dim cta67 As New SuperEntidad
        cta67.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "67" + ent.PeriodoRegContabCabe
        cta67 = Me.buscarCuentaSaldoExisPorClave(cta67)
        Dim str67 As New Reportes.EstadoFinanciero
        If cta67.ClaveSaldoContable <> "" Then
            str67.codigo = "67"
            str67.nombre = cta67.NombreCuentaPcge
            str67.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta67, mes))
            str67.strmontomes = str67.montomes.ToString
            str67.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta67, mes))
            str67.strmontoacumulado = str67.montoacumulado.ToString
            lisres.Add(str67)
        End If

        'Descuentos y reb.Obtenidas
        Dim cta73 As New SuperEntidad
        cta73.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "73" + ent.PeriodoRegContabCabe
        cta73 = Me.buscarCuentaSaldoExisPorClave(cta73)
        Dim str73 As New Reportes.EstadoFinanciero
        If cta73.ClaveSaldoContable <> "" Then
            str73.codigo = "73"
            str73.nombre = cta73.NombreCuentaPcge
            str73.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta73, mes))
            str73.strmontomes = str73.montomes.ToString
            str73.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta73, mes))
            str73.strmontoacumulado = str73.montoacumulado.ToString
            lisres.Add(str73)
        End If

        'Otros Ing.Gestion 
        Dim cta75 As New SuperEntidad
        cta75.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "75" + ent.PeriodoRegContabCabe
        cta75 = Me.buscarCuentaSaldoExisPorClave(cta75)
        Dim str75 As New Reportes.EstadoFinanciero
        If cta75.ClaveSaldoContable <> "" Then
            str75.codigo = "75"
            str75.nombre = cta75.NombreCuentaPcge
            str75.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta75, mes))
            str75.strmontomes = str75.montomes.ToString
            str75.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta75, mes))
            str75.strmontoacumulado = str75.montoacumulado.ToString
            lisres.Add(str75)
        End If

        'Ganancia x Medicion
        Dim cta76 As New SuperEntidad
        cta76.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "76" + ent.PeriodoRegContabCabe
        cta76 = Me.buscarCuentaSaldoExisPorClave(cta76)
        Dim str76 As New Reportes.EstadoFinanciero
        If cta76.ClaveSaldoContable <> "" Then
            str76.codigo = "76"
            str76.nombre = cta76.NombreCuentaPcge
            str76.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta76, mes))
            str76.strmontomes = str76.montomes.ToString
            str76.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta76, mes))
            str76.strmontoacumulado = str76.montoacumulado.ToString
            lisres.Add(str76)
        End If

        ''Poner linea de  76 en la 85
        Dim strl76 As New Reportes.EstadoFinanciero
        strl76.codigo = ""
        strl76.nombre = ""
        strl76.montomes = 0
        strl76.strmontomes = "-----------------"
        lisres.Add(strl76)

        'Resultado Expltacion
        Dim strreai As New Reportes.EstadoFinanciero
        strreai.codigo = "85"
        strreai.nombre = "RESULTADO ANTES DE IMPUESTOS"
        strreai.montomes = strreex.montomes + str77.montomes + str67.montomes + str73.montomes + str75.montomes + str76.montomes
        strreai.strmontomes = strreai.montomes.ToString
        strreai.montoacumulado = strreex.montoacumulado + str77.montoacumulado + str67.montoacumulado + str73.montoacumulado + str75.montoacumulado + str76.montoacumulado
        strreai.strmontoacumulado = strreai.montoacumulado.ToString
        lisres.Add(strreai)

        ''Linea Final 
        Dim strlFin As New Reportes.EstadoFinanciero
        strlFin.codigo = ""
        strlFin.nombre = ""
        strlFin.montomes = 0
        strlFin.strmontomes = "================="
        lisres.Add(strlFin)

        Return lisres

    End Function

    Function ObtenerBalanceGeneralActivo(ByRef ent As SuperEntidad) As List(Of Reportes.EstadoFinanciero)
        Dim lisres As New List(Of Reportes.EstadoFinanciero)
        'Dim res As Reportes.GananciaPerdidaXFuncion
        Dim mes As String = ent.CodigoMes

        'Activo  Corriente    
        Dim straco As New Reportes.EstadoFinanciero
        straco.codigo = ""
        straco.nombre = "ACTIVO CORRIENTE"
        straco.montomes = 0
        straco.strmontomes = ""
        lisres.Add(straco)

        Dim objAD As New SaldoContableAD
        Dim cta10 As New SuperEntidad
        cta10.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "10" + ent.PeriodoRegContabCabe
        cta10 = Me.buscarCuentaSaldoExisPorClave(cta10)
        Dim str10 As New Reportes.EstadoFinanciero
        If cta10.ClaveSaldoContable <> "" Then
            str10.codigo = "10"
            str10.nombre = cta10.NombreCuentaPcge
            str10.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta10, mes))
            str10.strmontomes = str10.montomes.ToString
            str10.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta10, mes))
            str10.strmontoacumulado = str10.montoacumulado.ToString
            lisres.Add(str10)
        End If

        '
        Dim cta11 As New SuperEntidad
        cta11.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "11" + ent.PeriodoRegContabCabe
        cta11 = Me.buscarCuentaSaldoExisPorClave(cta11)
        Dim str11 As New Reportes.EstadoFinanciero
        If cta11.ClaveSaldoContable <> "" Then
            str11.codigo = "11"
            str11.nombre = cta11.NombreCuentaPcge
            str11.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta11, mes))
            str11.strmontomes = str11.montomes.ToString
            str11.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta11, mes))
            str11.strmontoacumulado = str11.montoacumulado.ToString
            lisres.Add(str11)
        End If

        '
        Dim cta12 As New SuperEntidad
        cta12.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "12" + ent.PeriodoRegContabCabe
        cta12 = Me.buscarCuentaSaldoExisPorClave(cta12)
        Dim str12 As New Reportes.EstadoFinanciero
        If cta12.ClaveSaldoContable <> "" Then
            str12.codigo = "12"
            str12.nombre = cta12.NombreCuentaPcge
            str12.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta12, mes))
            str12.strmontomes = str12.montomes.ToString
            str12.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta12, mes))
            str12.strmontoacumulado = str12.montoacumulado.ToString
            lisres.Add(str12)
        End If

        Dim cta13 As New SuperEntidad
        cta13.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "13" + ent.PeriodoRegContabCabe
        cta13 = Me.buscarCuentaSaldoExisPorClave(cta13)
        Dim str13 As New Reportes.EstadoFinanciero
        If cta13.ClaveSaldoContable <> "" Then
            str13.codigo = "13"
            str13.nombre = cta13.NombreCuentaPcge
            str13.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta13, mes))
            str13.strmontomes = str13.montomes.ToString
            str13.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta13, mes))
            str13.strmontoacumulado = str13.montoacumulado.ToString
            lisres.Add(str13)
        End If

        Dim cta14 As New SuperEntidad
        cta14.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "14" + ent.PeriodoRegContabCabe
        cta14 = Me.buscarCuentaSaldoExisPorClave(cta14)
        Dim str14 As New Reportes.EstadoFinanciero
        If cta14.ClaveSaldoContable <> "" Then
            str14.codigo = "14"
            str14.nombre = cta14.NombreCuentaPcge
            str14.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta14, mes))
            str14.strmontomes = str14.montomes.ToString
            str14.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta14, mes))
            str14.strmontoacumulado = str14.montoacumulado.ToString
            lisres.Add(str14)
        End If

        Dim cta16 As New SuperEntidad
        cta16.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "16" + ent.PeriodoRegContabCabe
        cta16 = Me.buscarCuentaSaldoExisPorClave(cta16)
        Dim str16 As New Reportes.EstadoFinanciero
        If cta16.ClaveSaldoContable <> "" Then
            str16.codigo = "16"
            str16.nombre = cta16.NombreCuentaPcge
            str16.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta16, mes))
            str16.strmontomes = str16.montomes.ToString
            str16.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta16, mes))
            str16.strmontoacumulado = str16.montoacumulado.ToString
            lisres.Add(str16)
        End If

        Dim cta17 As New SuperEntidad
        cta17.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "17" + ent.PeriodoRegContabCabe
        cta17 = Me.buscarCuentaSaldoExisPorClave(cta17)
        Dim str17 As New Reportes.EstadoFinanciero
        If cta17.ClaveSaldoContable <> "" Then
            str17.codigo = "17"
            str17.nombre = cta17.NombreCuentaPcge
            str17.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta17, mes))
            str17.strmontomes = str17.montomes.ToString
            str17.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta17, mes))
            str17.strmontoacumulado = str17.montoacumulado.ToString
            lisres.Add(str17)
        End If

        Dim cta18 As New SuperEntidad
        cta18.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "18" + ent.PeriodoRegContabCabe
        cta18 = Me.buscarCuentaSaldoExisPorClave(cta18)
        Dim str18 As New Reportes.EstadoFinanciero
        If cta18.ClaveSaldoContable <> "" Then
            str18.codigo = "18"
            str18.nombre = cta18.NombreCuentaPcge
            str18.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta18, mes))
            str18.strmontomes = str18.montomes.ToString
            str18.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta18, mes))
            str18.strmontoacumulado = str18.montoacumulado.ToString
            lisres.Add(str18)
        End If

        Dim cta19 As New SuperEntidad
        cta19.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "19" + ent.PeriodoRegContabCabe
        cta19 = Me.buscarCuentaSaldoExisPorClave(cta19)
        Dim str19 As New Reportes.EstadoFinanciero
        If cta19.ClaveSaldoContable <> "" Then
            str19.codigo = "19"
            str19.nombre = cta19.NombreCuentaPcge
            str19.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta19, mes))
            str19.strmontomes = str19.montomes.ToString
            str19.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta19, mes))
            str19.strmontoacumulado = str19.montoacumulado.ToString
            lisres.Add(str19)
        End If

        Dim cta20 As New SuperEntidad
        cta20.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "20" + ent.PeriodoRegContabCabe
        cta20 = Me.buscarCuentaSaldoExisPorClave(cta20)
        Dim str20 As New Reportes.EstadoFinanciero
        If cta20.ClaveSaldoContable <> "" Then
            str20.codigo = "20"
            str20.nombre = cta20.NombreCuentaPcge
            str20.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta20, mes))
            str20.strmontomes = str20.montomes.ToString
            str20.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta20, mes))
            str20.strmontoacumulado = str20.montoacumulado.ToString
            lisres.Add(str20)
        End If

        Dim cta28 As New SuperEntidad
        cta28.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "28" + ent.PeriodoRegContabCabe
        cta28 = Me.buscarCuentaSaldoExisPorClave(cta28)
        Dim str28 As New Reportes.EstadoFinanciero
        If cta28.ClaveSaldoContable <> "" Then
            str28.codigo = "28"
            str28.nombre = cta28.NombreCuentaPcge
            str28.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta28, mes))
            str28.strmontomes = str28.montomes.ToString
            str28.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta28, mes))
            str28.strmontoacumulado = str28.montoacumulado.ToString
            lisres.Add(str28)
        End If

        Dim cta29 As New SuperEntidad
        cta29.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "29" + ent.PeriodoRegContabCabe
        cta29 = Me.buscarCuentaSaldoExisPorClave(cta29)
        Dim str29 As New Reportes.EstadoFinanciero
        If cta29.ClaveSaldoContable <> "" Then
            str29.codigo = "29"
            str29.nombre = cta29.NombreCuentaPcge
            str29.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta29, mes))
            str29.strmontomes = str29.montomes.ToString
            str29.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta29, mes))
            str29.strmontoacumulado = str29.montoacumulado.ToString
            lisres.Add(str29)
        End If


        ''Poner linea de 29..
        Dim strl29 As New Reportes.EstadoFinanciero
        strl29.codigo = ""
        strl29.nombre = ""
        strl29.montomes = 0
        strl29.strmontomes = "-----------------"
        lisres.Add(strl29)

        'Total Activo Corriente
        Dim stracco As New Reportes.EstadoFinanciero
        stracco.codigo = ""
        stracco.nombre = "     TOTAL ACTIVO CORRIENTE"
        stracco.montomes = str10.montomes + str11.montomes + str12.montomes + str13.montomes + str14.montomes + str16.montomes + str17.montomes + str18.montomes + str19.montomes + str20.montomes + str28.montomes + str29.montomes
        stracco.strmontomes = stracco.montomes.ToString
        stracco.montoacumulado = str10.montoacumulado + str11.montoacumulado + str12.montoacumulado + str13.montoacumulado + str14.montoacumulado + str16.montoacumulado + str17.montoacumulado + str18.montoacumulado + str19.montoacumulado + str20.montoacumulado + str28.montoacumulado + str29.montoacumulado
        stracco.strmontoacumulado = stracco.montoacumulado.ToString
        lisres.Add(stracco)

        'Activo No Corriente    
        Dim stranc As New Reportes.EstadoFinanciero
        stranc.codigo = ""
        stranc.nombre = "ACTIVO NO CORRIENTES"
        stranc.montomes = 0
        stranc.strmontomes = ""
        lisres.Add(stranc)

        '
        Dim cta30 As New SuperEntidad
        cta30.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "30" + ent.PeriodoRegContabCabe
        cta30 = Me.buscarCuentaSaldoExisPorClave(cta30)
        Dim str30 As New Reportes.EstadoFinanciero
        If cta30.ClaveSaldoContable <> "" Then
            str30.codigo = "30"
            str30.nombre = cta30.NombreCuentaPcge
            str30.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta30, mes)) * (-1)
            str30.strmontomes = str30.montomes.ToString
            str30.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta30, mes)) * (-1)
            str30.strmontoacumulado = str30.montoacumulado.ToString
            lisres.Add(str30)
        End If

        '
        Dim cta31 As New SuperEntidad
        cta31.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "31" + ent.PeriodoRegContabCabe
        cta31 = Me.buscarCuentaSaldoExisPorClave(cta31)
        Dim str31 As New Reportes.EstadoFinanciero
        If cta31.ClaveSaldoContable <> "" Then
            str31.codigo = "31"
            str31.nombre = cta31.NombreCuentaPcge
            str31.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta31, mes)) * (-1)
            str31.strmontomes = str31.montomes.ToString
            str31.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta31, mes)) * (-1)
            str31.strmontoacumulado = str31.montoacumulado.ToString
            lisres.Add(str31)
        End If

        Dim cta32 As New SuperEntidad
        cta32.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "32" + ent.PeriodoRegContabCabe
        cta32 = Me.buscarCuentaSaldoExisPorClave(cta32)
        Dim str32 As New Reportes.EstadoFinanciero
        If cta32.ClaveSaldoContable <> "" Then
            str32.codigo = "32"
            str32.nombre = cta32.NombreCuentaPcge
            str32.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta32, mes)) * (-1)
            str32.strmontomes = str32.montomes.ToString
            str32.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta32, mes)) * (-1)
            str32.strmontoacumulado = str32.montoacumulado.ToString
            lisres.Add(str32)
        End If

        Dim cta33 As New SuperEntidad
        cta33.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "33" + ent.PeriodoRegContabCabe
        cta33 = Me.buscarCuentaSaldoExisPorClave(cta33)
        Dim str33 As New Reportes.EstadoFinanciero
        If cta33.ClaveSaldoContable <> "" Then
            str33.codigo = "33"
            str33.nombre = cta33.NombreCuentaPcge
            str33.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta33, mes)) * (-1)
            str33.strmontomes = str33.montomes.ToString
            str33.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta33, mes)) * (-1)
            str33.strmontoacumulado = str33.montoacumulado.ToString
            lisres.Add(str33)
        End If

        Dim cta391 As New SuperEntidad
        cta391.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "391" + ent.PeriodoRegContabCabe
        cta391 = Me.buscarCuentaSaldoExisPorClave(cta391)
        Dim str391 As New Reportes.EstadoFinanciero
        If cta391.ClaveSaldoContable <> "" Then
            str391.codigo = "391"
            str391.nombre = cta391.NombreCuentaPcge
            str391.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta391, mes)) * (-1)
            str391.strmontomes = str391.montomes.ToString
            str391.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta391, mes)) * (-1)
            str391.strmontoacumulado = str391.montoacumulado.ToString
            lisres.Add(str391)
        End If

        Dim cta34 As New SuperEntidad
        cta34.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "34" + ent.PeriodoRegContabCabe
        cta34 = Me.buscarCuentaSaldoExisPorClave(cta34)
        Dim str34 As New Reportes.EstadoFinanciero
        If cta34.ClaveSaldoContable <> "" Then
            str34.codigo = "34"
            str34.nombre = cta34.NombreCuentaPcge
            str34.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta34, mes)) * (-1)
            str34.strmontomes = str34.montomes.ToString
            str34.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta34, mes)) * (-1)
            str34.strmontoacumulado = str34.montoacumulado.ToString
            lisres.Add(str34)
        End If

        Dim cta392 As New SuperEntidad
        cta392.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "392" + ent.PeriodoRegContabCabe
        cta392 = Me.buscarCuentaSaldoExisPorClave(cta392)
        Dim str392 As New Reportes.EstadoFinanciero
        If cta392.ClaveSaldoContable <> "" Then
            str392.codigo = "392"
            str392.nombre = cta392.NombreCuentaPcge
            str392.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta392, mes)) * (-1)
            str392.strmontomes = str392.montomes.ToString
            str392.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta392, mes)) * (-1)
            str392.strmontoacumulado = str392.montoacumulado.ToString
            lisres.Add(str392)
        End If

        ''Poner linea de 392..
        Dim strl392 As New Reportes.EstadoFinanciero
        strl392.codigo = ""
        strl392.nombre = ""
        strl392.montomes = 0
        strl392.strmontomes = "-----------------"
        lisres.Add(strl392)

        'Total Activo Corriente
        Dim stracno As New Reportes.EstadoFinanciero
        stracno.codigo = ""
        stracno.nombre = "     TOTAL ACTIVO NOCORRIENTE"
        stracno.montomes = str30.montomes + str31.montomes + str32.montomes + str33.montomes + str391.montomes + str34.montomes + str392.montomes
        stracno.strmontomes = stracno.montomes.ToString
        stracno.montoacumulado = str30.montoacumulado + str31.montoacumulado + str32.montoacumulado + str33.montoacumulado + str391.montoacumulado + str34.montoacumulado + str392.montoacumulado
        stracno.strmontoacumulado = stracno.montoacumulado.ToString
        lisres.Add(stracno)

        ''Poner linea Activo no Corriente
        Dim strlact As New Reportes.EstadoFinanciero
        strlact.codigo = ""
        strlact.nombre = ""
        strlact.montomes = 0
        strlact.strmontomes = "-----------------"
        lisres.Add(strlact)

        'Total Activo Corriente
        Dim strtact As New Reportes.EstadoFinanciero
        strtact.codigo = ""
        strtact.nombre = "     TOTAL ACTIVO"
        strtact.montomes = stracco.montomes + stracno.montomes
        strtact.strmontomes = strtact.montomes.ToString
        strtact.montoacumulado = stracco.montoacumulado + stracno.montoacumulado
        strtact.strmontoacumulado = strtact.montoacumulado.ToString
        lisres.Add(strtact)

        Me.TotalActivo = strtact.montomes
        Me.TotalActivoAcu = strtact.montoacumulado

        ''Linea Final 
        Dim strlFin As New Reportes.EstadoFinanciero
        strlFin.codigo = ""
        strlFin.nombre = ""
        strlFin.montomes = 0
        strlFin.strmontomes = "========="
        lisres.Add(strlFin)

        Return lisres

    End Function

    Function ObtenerBalanceGeneralActivo1(ByRef ent As SuperEntidad) As List(Of Reportes.EstadoFinanciero)
        Dim lisres As New List(Of Reportes.EstadoFinanciero)
        'Dim res As Reportes.GananciaPerdidaXFuncion
        Dim mes As String = ent.CodigoMes

        'Activo  Corriente    
        Dim straco As New Reportes.EstadoFinanciero
        straco.codigo = ""
        straco.nombre = "ACTIVO CORRIENTE"
        straco.montomes = 0
        straco.strmontomes = ""
        lisres.Add(straco)

        Dim objAD As New SaldoContableAD
        Dim cta10 As New SuperEntidad
        cta10.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "10" + ent.PeriodoRegContabCabe
        cta10 = Me.buscarCuentaSaldoExisPorClave(cta10)
        Dim str10 As New Reportes.EstadoFinanciero
        If cta10.ClaveSaldoContable <> "" Then
            str10.codigo = "10"
            str10.nombre = cta10.NombreCuentaPcge
            str10.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta10, mes))
            str10.strmontomes = str10.montomes.ToString
            str10.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta10, mes))
            str10.strmontoacumulado = str10.montoacumulado.ToString
            lisres.Add(str10)
        End If


        'Cuenta 12 y 19
        Dim cta12 As New SuperEntidad
        cta12.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "12" + ent.PeriodoRegContabCabe
        cta12 = Me.buscarCuentaSaldoExisPorClave(cta12)
        Dim str12_19 As New Reportes.EstadoFinanciero
        If cta12.ClaveSaldoContable <> "" Then
            'str12_19.codigo = "12"
            'str12_19.nombre = cta12.NombreCuentaPcge
            str12_19.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta12, mes))
            'str12_19.strmontomes = str12_19.montomes.ToString
            str12_19.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta12, mes))
            'str12_19.strmontoacumulado = str12_19.montoacumulado.ToString
            'lisres.Add(str12_19)
        End If

        Dim cta19 As New SuperEntidad
        cta19.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "19" + ent.PeriodoRegContabCabe
        cta19 = Me.buscarCuentaSaldoExisPorClave(cta19)
        If cta19.ClaveSaldoContable <> "" Then
            str12_19.codigo = "-"
            str12_19.nombre = "CUENTAS POR COBRAR COMERCIALES"
            str12_19.montomes += Math.Abs(Me.obtenerDiferenciaDebeHaber(cta19, mes))
            str12_19.strmontomes = str12_19.montomes.ToString
            str12_19.montoacumulado += Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta19, mes))
            str12_19.strmontoacumulado = str12_19.montoacumulado.ToString
            lisres.Add(str12_19)
        End If

        '----------------------
        '--------------------------
        ''Dim cta13 As New SuperEntidad
        ''cta13.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "13" + ent.PeriodoRegContabCabe
        ''cta13 = Me.buscarCuentaSaldoExisPorClave(cta13)
        ''Dim str13 As New Reportes.EstadoFinanciero
        ''If cta13.ClaveSaldoContable <> "" Then
        ''    str13.codigo = "13"
        ''    str13.nombre = cta13.NombreCuentaPcge
        ''    str13.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta13, mes))
        ''    str13.strmontomes = str13.montomes.ToString
        ''    str13.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta13, mes))
        ''    str13.strmontoacumulado = str13.montoacumulado.ToString
        ''    lisres.Add(str13)
        ''End If

        'Cuenta 1411101 y 1411102 
        Dim cta1411101 As New SuperEntidad
        cta1411101.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "1411101" + ent.PeriodoRegContabCabe
        cta1411101 = Me.buscarCuentaSaldoExisPorClave(cta1411101)
        Dim str141_142 As New Reportes.EstadoFinanciero
        If cta1411101.ClaveSaldoContable <> "" Then
            'str14.codigo = "14"
            'str14.nombre = cta1411101.NombreCuentaPcge
            str141_142.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta1411101, mes))
            'str14.strmontomes = str14.montomes.ToString
            str141_142.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta1411101, mes))
            'str14.strmontoacumulado = str14.montoacumulado.ToString
            'lisres.Add(str1411101)
        End If

        Dim cta1411102 As New SuperEntidad
        cta1411102.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "1411102" + ent.PeriodoRegContabCabe
        cta1411102 = Me.buscarCuentaSaldoExisPorClave(cta1411102)
        If cta1411102.ClaveSaldoContable <> "" Then
            str141_142.codigo = "-"
            str141_142.nombre = "CUENTAS POR COBRAR ACCIONISTAS Y PERSONAL"
            str141_142.montomes += Math.Abs(Me.obtenerDiferenciaDebeHaber(cta1411102, mes))
            str141_142.strmontomes = str141_142.montomes.ToString
            str141_142.montoacumulado += Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta1411102, mes))
            str141_142.strmontoacumulado = str141_142.montoacumulado.ToString
            lisres.Add(str141_142)
        End If


        'Cuenta 161,162,164 y 168
        Dim cta161 As New SuperEntidad
        cta161.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "161" + ent.PeriodoRegContabCabe
        cta161 = Me.buscarCuentaSaldoExisPorClave(cta161)
        Dim str16_1248 As New Reportes.EstadoFinanciero
        If cta161.ClaveSaldoContable <> "" Then
            '  str16_1248.codigo = "16"
            '  str16_1248.nombre = cta16.NombreCuentaPcge
            str16_1248.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta161, mes))
            ' str16_1248.strmontomes = str16.montomes.ToString
            str16_1248.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta161, mes))
            ' str16_1248.strmontoacumulado = str16.montoacumulado.ToString
            ' lisres.Add(str16_1248)
        End If

        Dim cta162 As New SuperEntidad
        cta162.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "162" + ent.PeriodoRegContabCabe
        cta162 = Me.buscarCuentaSaldoExisPorClave(cta162)
        If cta162.ClaveSaldoContable <> "" Then
            '  str16_1248.codigo = "16"
            '  str16_1248.nombre = cta16.NombreCuentaPcge
            str16_1248.montomes += Math.Abs(Me.obtenerDiferenciaDebeHaber(cta162, mes))
            ' str16_1248.strmontomes = str16.montomes.ToString
            str16_1248.montoacumulado += Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta162, mes))
            ' str16_1248.strmontoacumulado = str16.montoacumulado.ToString
            ' lisres.Add(str16_1248)
        End If

        Dim cta164 As New SuperEntidad
        cta164.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "164" + ent.PeriodoRegContabCabe
        cta164 = Me.buscarCuentaSaldoExisPorClave(cta164)
        If cta164.ClaveSaldoContable <> "" Then
            '  str16_1248.codigo = "16"
            '  str16_1248.nombre = cta16.NombreCuentaPcge
            str16_1248.montomes += Math.Abs(Me.obtenerDiferenciaDebeHaber(cta164, mes))
            ' str16_1248.strmontomes = str16.montomes.ToString
            str16_1248.montoacumulado += Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta164, mes))
            ' str16_1248.strmontoacumulado = str16.montoacumulado.ToString
            ' lisres.Add(str16_1248)
        End If

        Dim cta168 As New SuperEntidad
        cta168.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "168" + ent.PeriodoRegContabCabe
        cta168 = Me.buscarCuentaSaldoExisPorClave(cta168)
        If cta168.ClaveSaldoContable <> "" Then
            str16_1248.codigo = "-"
            str16_1248.nombre = "CUENTAS POR COBRAR DIVERSAS"
            str16_1248.montomes += Math.Abs(Me.obtenerDiferenciaDebeHaber(cta168, mes))
            str16_1248.strmontomes = str16_1248.montomes.ToString
            str16_1248.montoacumulado += Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta168, mes))
            str16_1248.strmontoacumulado = str16_1248.montoacumulado.ToString
            lisres.Add(str16_1248)
        End If

        'Cuenta 1413101,1433101,1433201,1631101
        Dim cta1413101 As New SuperEntidad
        cta1413101.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "1413101" + ent.PeriodoRegContabCabe
        cta1413101 = Me.buscarCuentaSaldoExisPorClave(cta1413101)
        Dim str141_3132 As New Reportes.EstadoFinanciero
        If cta1413101.ClaveSaldoContable <> "" Then
            '  str141_3132.codigo = "17"
            '  str17.nombre = cta17.NombreCuentaPcge
            str141_3132.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta1413101, mes))
            'str141_3132.strmontomes = str141_3132.montomes.ToString
            str141_3132.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta1413101, mes))
            'str141_3132.strmontoacumulado = str141_3132.montoacumulado.ToString
            'lisres.Add(str141_3132)
        End If

        Dim cta1433101 As New SuperEntidad
        cta1433101.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "1433101" + ent.PeriodoRegContabCabe
        cta1433101 = Me.buscarCuentaSaldoExisPorClave(cta1433101)
        If cta1433101.ClaveSaldoContable <> "" Then
            '  str141_3132.codigo = "17"
            '  str17.nombre = cta17.NombreCuentaPcge
            str141_3132.montomes += Math.Abs(Me.obtenerDiferenciaDebeHaber(cta1433101, mes))
            'str141_3132.strmontomes = str141_3132.montomes.ToString
            str141_3132.montoacumulado += Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta1433101, mes))
            'str141_3132.strmontoacumulado = str141_3132.montoacumulado.ToString
            'lisres.Add(str141_3132)
        End If

        Dim cta1433102 As New SuperEntidad
        cta1433102.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "1433102" + ent.PeriodoRegContabCabe
        cta1433102 = Me.buscarCuentaSaldoExisPorClave(cta1433102)
        If cta1433102.ClaveSaldoContable <> "" Then
            '  str141_3132.codigo = "17"
            '  str17.nombre = cta17.NombreCuentaPcge
            str141_3132.montomes += Math.Abs(Me.obtenerDiferenciaDebeHaber(cta1433102, mes))
            'str141_3132.strmontomes = str141_3132.montomes.ToString
            str141_3132.montoacumulado += Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta1433102, mes))
            'str141_3132.strmontoacumulado = str141_3132.montoacumulado.ToString
            'lisres.Add(str141_3132)
        End If

        Dim cta1631101 As New SuperEntidad
        cta1631101.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "1631101" + ent.PeriodoRegContabCabe
        cta1631101 = Me.buscarCuentaSaldoExisPorClave(cta1631101)
        If cta1631101.ClaveSaldoContable <> "" Then
            str141_3132.codigo = "-"
            str141_3132.nombre = "CUENTAS DIFERIDAS"
            str141_3132.montomes += Math.Abs(Me.obtenerDiferenciaDebeHaber(cta1631101, mes))
            str141_3132.strmontomes = str141_3132.montomes.ToString
            str141_3132.montoacumulado += Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta1631101, mes))
            str141_3132.strmontoacumulado = str141_3132.montoacumulado.ToString
            lisres.Add(str141_3132)
        End If

        'Dim cta18 As New SuperEntidad
        'cta18.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "18" + ent.PeriodoRegContabCabe
        'cta18 = Me.buscarCuentaSaldoExisPorClave(cta18)
        'Dim str18 As New Reportes.EstadoFinanciero
        'If cta18.ClaveSaldoContable <> "" Then
        '    str18.codigo = "18"
        '    str18.nombre = cta18.NombreCuentaPcge
        '    str18.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta18, mes))
        '    str18.strmontomes = str18.montomes.ToString
        '    str18.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta18, mes))
        '    str18.strmontoacumulado = str18.montoacumulado.ToString
        '    lisres.Add(str18)
        'End If


        'Dim cta20 As New SuperEntidad
        'cta20.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "20" + ent.PeriodoRegContabCabe
        'cta20 = Me.buscarCuentaSaldoExisPorClave(cta20)
        'Dim str20 As New Reportes.EstadoFinanciero
        'If cta20.ClaveSaldoContable <> "" Then
        '    str20.codigo = "20"
        '    str20.nombre = cta20.NombreCuentaPcge
        '    str20.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta20, mes))
        '    str20.strmontomes = str20.montomes.ToString
        '    str20.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta20, mes))
        '    str20.strmontoacumulado = str20.montoacumulado.ToString
        '    lisres.Add(str20)
        'End If

        'Dim cta28 As New SuperEntidad
        'cta28.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "28" + ent.PeriodoRegContabCabe
        'cta28 = Me.buscarCuentaSaldoExisPorClave(cta28)
        'Dim str28 As New Reportes.EstadoFinanciero
        'If cta28.ClaveSaldoContable <> "" Then
        '    str28.codigo = "28"
        '    str28.nombre = cta28.NombreCuentaPcge
        '    str28.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta28, mes))
        '    str28.strmontomes = str28.montomes.ToString
        '    str28.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta28, mes))
        '    str28.strmontoacumulado = str28.montoacumulado.ToString
        '    lisres.Add(str28)
        'End If

        'Dim cta29 As New SuperEntidad
        'cta29.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "29" + ent.PeriodoRegContabCabe
        'cta29 = Me.buscarCuentaSaldoExisPorClave(cta29)
        'Dim str29 As New Reportes.EstadoFinanciero
        'If cta29.ClaveSaldoContable <> "" Then
        '    str29.codigo = "29"
        '    str29.nombre = cta29.NombreCuentaPcge
        '    str29.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta29, mes))
        '    str29.strmontomes = str29.montomes.ToString
        '    str29.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta29, mes))
        '    str29.strmontoacumulado = str29.montoacumulado.ToString
        '    lisres.Add(str29)
        'End If


        ' ''Poner linea de 29..
        'Dim strl29 As New Reportes.EstadoFinanciero
        'strl29.codigo = ""
        'strl29.nombre = ""
        'strl29.montomes = 0
        'strl29.strmontomes = "-----------------"
        'lisres.Add(strl29)

        'Total Activo Corriente
        Dim stracco As New Reportes.EstadoFinanciero
        stracco.codigo = ""
        stracco.nombre = "     TOTAL ACTIVO CORRIENTE"
        stracco.montomes = str10.montomes + str12_19.montomes + str141_142.montomes + str16_1248.montomes + str141_3132.montomes
        stracco.strmontomes = stracco.montomes.ToString
        stracco.montoacumulado = str10.montoacumulado + str12_19.montoacumulado + str141_142.montoacumulado + str16_1248.montoacumulado + str141_3132.montoacumulado
        stracco.strmontoacumulado = stracco.montoacumulado.ToString
        lisres.Add(stracco)

        'Activo No Corriente    
        Dim stranc As New Reportes.EstadoFinanciero
        stranc.codigo = ""
        stranc.nombre = "ACTIVO NO CORRIENTES"
        stranc.montomes = 0
        stranc.strmontomes = ""
        lisres.Add(stranc)


        '
        Dim cta11 As New SuperEntidad
        cta11.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "11" + ent.PeriodoRegContabCabe
        cta11 = Me.buscarCuentaSaldoExisPorClave(cta11)
        Dim str11 As New Reportes.EstadoFinanciero
        If cta11.ClaveSaldoContable <> "" Then
            str11.codigo = "11"
            str11.nombre = cta11.NombreCuentaPcge
            str11.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta11, mes))
            str11.strmontomes = str11.montomes.ToString
            str11.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta11, mes))
            str11.strmontoacumulado = str11.montoacumulado.ToString
            lisres.Add(str11)
        End If
        '
        'Dim cta30 As New SuperEntidad
        'cta30.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "30" + ent.PeriodoRegContabCabe
        'cta30 = Me.buscarCuentaSaldoExisPorClave(cta30)
        'Dim str30 As New Reportes.EstadoFinanciero
        'If cta30.ClaveSaldoContable <> "" Then
        '    str30.codigo = "30"
        '    str30.nombre = cta30.NombreCuentaPcge
        '    str30.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta30, mes)) * (-1)
        '    str30.strmontomes = str30.montomes.ToString
        '    str30.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta30, mes)) * (-1)
        '    str30.strmontoacumulado = str30.montoacumulado.ToString
        '    lisres.Add(str30)
        'End If

        ''
        'Dim cta31 As New SuperEntidad
        'cta31.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "31" + ent.PeriodoRegContabCabe
        'cta31 = Me.buscarCuentaSaldoExisPorClave(cta31)
        'Dim str31 As New Reportes.EstadoFinanciero
        'If cta31.ClaveSaldoContable <> "" Then
        '    str31.codigo = "31"
        '    str31.nombre = cta31.NombreCuentaPcge
        '    str31.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta31, mes)) * (-1)
        '    str31.strmontomes = str31.montomes.ToString
        '    str31.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta31, mes)) * (-1)
        '    str31.strmontoacumulado = str31.montoacumulado.ToString
        '    lisres.Add(str31)
        'End If

        'Dim cta32 As New SuperEntidad
        'cta32.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "32" + ent.PeriodoRegContabCabe
        'cta32 = Me.buscarCuentaSaldoExisPorClave(cta32)
        'Dim str32 As New Reportes.EstadoFinanciero
        'If cta32.ClaveSaldoContable <> "" Then
        '    str32.codigo = "32"
        '    str32.nombre = cta32.NombreCuentaPcge
        '    str32.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta32, mes)) * (-1)
        '    str32.strmontomes = str32.montomes.ToString
        '    str32.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta32, mes)) * (-1)
        '    str32.strmontoacumulado = str32.montoacumulado.ToString
        '    lisres.Add(str32)
        'End If

        Dim cta33 As New SuperEntidad
        cta33.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "33" + ent.PeriodoRegContabCabe
        cta33 = Me.buscarCuentaSaldoExisPorClave(cta33)
        Dim str33 As New Reportes.EstadoFinanciero
        If cta33.ClaveSaldoContable <> "" Then
            str33.codigo = "33"
            str33.nombre = cta33.NombreCuentaPcge
            str33.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta33, mes)) * (-1)
            str33.strmontomes = str33.montomes.ToString
            str33.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta33, mes)) * (-1)
            str33.strmontoacumulado = str33.montoacumulado.ToString
            lisres.Add(str33)
        End If


        Dim cta391 As New SuperEntidad
        cta391.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "391" + ent.PeriodoRegContabCabe
        cta391 = Me.buscarCuentaSaldoExisPorClave(cta391)
        Dim str391 As New Reportes.EstadoFinanciero
        If cta391.ClaveSaldoContable <> "" Then
            str391.codigo = "391"
            str391.nombre = cta391.NombreCuentaPcge
            str391.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta391, mes)) * (-1)
            str391.strmontomes = str391.montomes.ToString
            str391.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta391, mes)) * (-1)
            str391.strmontoacumulado = str391.montoacumulado.ToString
            lisres.Add(str391)
        End If


        Dim cta392 As New SuperEntidad
        cta392.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "392" + ent.PeriodoRegContabCabe
        cta392 = Me.buscarCuentaSaldoExisPorClave(cta392)
        Dim str392_19 As New Reportes.EstadoFinanciero
        If cta392.ClaveSaldoContable <> "" Then
            '  str392_19.codigo = "392"
            '  str392_19.nombre = cta392.NombreCuentaPcge
            str392_19.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta392, mes)) * (-1)
            ' str392_19.strmontomes = str392_19.montomes.ToString
            str392_19.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta392, mes)) * (-1)
            ' str392_19.strmontoacumulado = str392_19.montoacumulado.ToString
            ' lisres.Add(str392_19)
        End If

        Dim cta341 As New SuperEntidad
        cta341.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "341" + ent.PeriodoRegContabCabe
        cta341 = Me.buscarCuentaSaldoExisPorClave(cta341)
        If cta341.ClaveSaldoContable <> "" Then
            'str392_19.codigo = "34"
            'str392_19.nombre = cta341.NombreCuentaPcge
            str392_19.montomes += Math.Abs(Me.obtenerDiferenciaDebeHaber(cta341, mes)) * (-1)
            ' str392_19.strmontomes = str34.montomes.ToString
            str392_19.montoacumulado += Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta341, mes)) * (-1)
            'str392_19.strmontoacumulado = str34.montoacumulado.ToString
            'lisres.Add(str34)
        End If

        Dim cta349 As New SuperEntidad
        cta349.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "349" + ent.PeriodoRegContabCabe
        cta349 = Me.buscarCuentaSaldoExisPorClave(cta349)
        If cta349.ClaveSaldoContable <> "" Then
            str392_19.codigo = "-"
            str392_19.nombre = "ESTUDIOS Y PROYECTOS"
            str392_19.montomes += Math.Abs(Me.obtenerDiferenciaDebeHaber(cta349, mes)) * (-1)
            str392_19.strmontomes = str392_19.montomes.ToString
            str392_19.montoacumulado += Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta349, mes)) * (-1)
            str392_19.strmontoacumulado = str392_19.montoacumulado.ToString
            lisres.Add(str392_19)
        End If



        ''Poner linea de 392..
        Dim strl392 As New Reportes.EstadoFinanciero
        strl392.codigo = ""
        strl392.nombre = ""
        strl392.montomes = 0
        strl392.strmontomes = "-----------------"
        lisres.Add(strl392)

        'Total Activo Corriente
        Dim stracno As New Reportes.EstadoFinanciero
        stracno.codigo = ""
        stracno.nombre = "     TOTAL ACTIVO NOCORRIENTE"
        stracno.montomes = str11.montomes + str33.montomes + str391.montomes + str392_19.montomes
        stracno.strmontomes = stracno.montomes.ToString
        stracno.montoacumulado = str11.montoacumulado + str33.montoacumulado + str391.montoacumulado + str392_19.montoacumulado
        stracno.strmontoacumulado = stracno.montoacumulado.ToString
        lisres.Add(stracno)

        ''Poner linea Activo no Corriente
        Dim strlact As New Reportes.EstadoFinanciero
        strlact.codigo = ""
        strlact.nombre = ""
        strlact.montomes = 0
        strlact.strmontomes = "-----------------"
        lisres.Add(strlact)

        'Total Activo Corriente
        Dim strtact As New Reportes.EstadoFinanciero
        strtact.codigo = ""
        strtact.nombre = "     TOTAL ACTIVO"
        strtact.montomes = stracco.montomes + stracno.montomes
        strtact.strmontomes = strtact.montomes.ToString
        strtact.montoacumulado = stracco.montoacumulado + stracno.montoacumulado
        strtact.strmontoacumulado = strtact.montoacumulado.ToString
        lisres.Add(strtact)

        Me.TotalActivo = strtact.montomes
        Me.TotalActivoAcu = strtact.montoacumulado

        ''Linea Final 
        Dim strlFin As New Reportes.EstadoFinanciero
        strlFin.codigo = ""
        strlFin.nombre = ""
        strlFin.montomes = 0
        strlFin.strmontomes = "========="
        lisres.Add(strlFin)

        Return lisres

    End Function

    Function ObtenerBalanceGeneralPasivo(ByRef ent As SuperEntidad) As List(Of Reportes.EstadoFinanciero)
        Dim lisres As New List(Of Reportes.EstadoFinanciero)
        'Dim res As Reportes.GananciaPerdidaXFuncion
        Dim mes As String = ent.CodigoMes

        'Activo  Corriente    
        Dim straco As New Reportes.EstadoFinanciero
        straco.codigo = ""
        straco.nombre = "PASIVO CORRIENTE"
        straco.montomes = 0
        straco.strmontomes = ""
        lisres.Add(straco)

        Dim objAD As New SaldoContableAD
        Dim cta40 As New SuperEntidad
        cta40.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "40" + ent.PeriodoRegContabCabe
        cta40 = Me.buscarCuentaSaldoExisPorClave(cta40)
        Dim str40 As New Reportes.EstadoFinanciero
        If cta40.ClaveSaldoContable <> "" Then
            str40.codigo = "40"
            str40.nombre = cta40.NombreCuentaPcge
            str40.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta40, mes))
            str40.strmontomes = str40.montomes.ToString
            str40.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta40, mes))
            str40.strmontoacumulado = str40.montoacumulado.ToString
            lisres.Add(str40)
        End If

        '
        Dim cta41 As New SuperEntidad
        cta41.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "41" + ent.PeriodoRegContabCabe
        cta41 = Me.buscarCuentaSaldoExisPorClave(cta41)
        Dim str41 As New Reportes.EstadoFinanciero
        If cta41.ClaveSaldoContable <> "" Then
            str41.codigo = "41"
            str41.nombre = cta41.NombreCuentaPcge
            str41.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta41, mes))
            str41.strmontomes = str41.montomes.ToString
            str41.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta41, mes))
            str41.strmontoacumulado = str41.montoacumulado.ToString
            lisres.Add(str41)
        End If

        '
        Dim cta42 As New SuperEntidad
        cta42.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "42" + ent.PeriodoRegContabCabe
        cta42 = Me.buscarCuentaSaldoExisPorClave(cta42)
        Dim str42 As New Reportes.EstadoFinanciero
        If cta42.ClaveSaldoContable <> "" Then
            str42.codigo = "42"
            str42.nombre = cta42.NombreCuentaPcge
            str42.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta42, mes))
            str42.strmontomes = str42.montomes.ToString
            str42.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta42, mes))
            str42.strmontoacumulado = str42.montoacumulado.ToString
            lisres.Add(str42)
        End If

        Dim cta43 As New SuperEntidad
        cta43.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "43" + ent.PeriodoRegContabCabe
        cta43 = Me.buscarCuentaSaldoExisPorClave(cta43)
        Dim str43 As New Reportes.EstadoFinanciero
        If cta43.ClaveSaldoContable <> "" Then
            str43.codigo = "43"
            str43.nombre = cta43.NombreCuentaPcge
            str43.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta43, mes))
            str43.strmontomes = str43.montomes.ToString
            str43.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta43, mes))
            str43.strmontoacumulado = str43.montoacumulado.ToString
            lisres.Add(str43)
        End If

        Dim cta44 As New SuperEntidad
        cta44.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "44" + ent.PeriodoRegContabCabe
        cta44 = Me.buscarCuentaSaldoExisPorClave(cta44)
        Dim str44 As New Reportes.EstadoFinanciero
        If cta44.ClaveSaldoContable <> "" Then
            str44.codigo = "44"
            str44.nombre = cta44.NombreCuentaPcge
            str44.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta44, mes))
            str44.strmontomes = str44.montomes.ToString
            str44.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta44, mes))
            str44.strmontoacumulado = str44.montoacumulado.ToString
            lisres.Add(str44)
        End If

        Dim cta45 As New SuperEntidad
        cta45.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "45" + ent.PeriodoRegContabCabe
        cta45 = Me.buscarCuentaSaldoExisPorClave(cta45)
        Dim str45 As New Reportes.EstadoFinanciero
        If cta45.ClaveSaldoContable <> "" Then
            str45.codigo = "45"
            str45.nombre = cta45.NombreCuentaPcge
            str45.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta45, mes))
            str45.strmontomes = str45.montomes.ToString
            str45.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta45, mes))
            str45.strmontoacumulado = str45.montoacumulado.ToString
            lisres.Add(str45)
        End If

        Dim cta46 As New SuperEntidad
        cta46.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "46" + ent.PeriodoRegContabCabe
        cta46 = Me.buscarCuentaSaldoExisPorClave(cta46)
        Dim str46 As New Reportes.EstadoFinanciero
        If cta46.ClaveSaldoContable <> "" Then
            str46.codigo = "46"
            str46.nombre = cta46.NombreCuentaPcge
            str46.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta46, mes))
            str46.strmontomes = str46.montomes.ToString
            str46.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta46, mes))
            str46.strmontoacumulado = str46.montoacumulado.ToString
            lisres.Add(str46)
        End If

        Dim cta47 As New SuperEntidad
        cta47.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "47" + ent.PeriodoRegContabCabe
        cta47 = Me.buscarCuentaSaldoExisPorClave(cta47)
        Dim str47 As New Reportes.EstadoFinanciero
        If cta47.ClaveSaldoContable <> "" Then
            str47.codigo = "47"
            str47.nombre = cta47.NombreCuentaPcge
            str47.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta47, mes))
            str47.strmontomes = str47.montomes.ToString
            str47.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta47, mes))
            str47.strmontoacumulado = str47.montoacumulado.ToString
            lisres.Add(str47)
        End If

        Dim cta48 As New SuperEntidad
        cta48.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "48" + ent.PeriodoRegContabCabe
        cta48 = Me.buscarCuentaSaldoExisPorClave(cta48)
        Dim str48 As New Reportes.EstadoFinanciero
        If cta48.ClaveSaldoContable <> "" Then
            str48.codigo = "48"
            str48.nombre = cta48.NombreCuentaPcge
            str48.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta48, mes))
            str48.strmontomes = str48.montomes.ToString
            str48.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta48, mes))
            str48.strmontoacumulado = str48.montoacumulado.ToString
            lisres.Add(str48)
        End If

        Dim cta49 As New SuperEntidad
        cta49.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "49" + ent.PeriodoRegContabCabe
        cta49 = Me.buscarCuentaSaldoExisPorClave(cta49)
        Dim str49 As New Reportes.EstadoFinanciero
        If cta49.ClaveSaldoContable <> "" Then
            str49.codigo = "49"
            str49.nombre = cta49.NombreCuentaPcge
            str49.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta49, mes))
            str49.strmontomes = str49.montomes.ToString
            str49.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta49, mes))
            str49.strmontoacumulado = str49.montoacumulado.ToString
            lisres.Add(str49)
        End If


        ''Poner linea de 49..
        Dim strl49 As New Reportes.EstadoFinanciero
        strl49.codigo = ""
        strl49.nombre = ""
        strl49.montomes = 0
        strl49.strmontomes = "-----------------"
        lisres.Add(strl49)

        'Total pASIVO  Corriente
        Dim strpaco As New Reportes.EstadoFinanciero
        strpaco.codigo = ""
        strpaco.nombre = "     TOTAL PASIVO CORRIENTE"
        strpaco.montomes = str40.montomes + str41.montomes + str42.montomes + str43.montomes + str44.montomes + str45.montomes + str46.montomes + str47.montomes + str48.montomes + str49.montomes
        strpaco.strmontomes = strpaco.montomes.ToString
        strpaco.montoacumulado = str40.montoacumulado + str41.montoacumulado + str42.montoacumulado + str43.montoacumulado + str44.montoacumulado + str45.montoacumulado + str46.montoacumulado + str47.montoacumulado + str48.montoacumulado + str49.montoacumulado
        strpaco.strmontoacumulado = strpaco.montoacumulado.ToString
        lisres.Add(strpaco)


        'Obtener Total Pasivo
        Me.TotalPasivo = strpaco.montomes
        Me.TotalPasivoAcu = strpaco.montoacumulado

        'Pasivo No Corriente    
        Dim strpat As New Reportes.EstadoFinanciero
        strpat.codigo = ""
        strpat.nombre = "PATRIMONIO"
        strpat.montomes = 0
        strpat.strmontomes = ""
        lisres.Add(strpat)

        '

        Dim cta50 As New SuperEntidad
        cta50.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "50" + ent.PeriodoRegContabCabe
        cta50 = Me.buscarCuentaSaldoExisPorClave(cta50)
        Dim str50 As New Reportes.EstadoFinanciero
        If cta50.ClaveSaldoContable <> "" Then
            str50.codigo = "50"
            str50.nombre = cta50.NombreCuentaPcge
            str50.montomes = (Me.obtenerDiferenciaDebeHaber(cta50, mes)) * (-1)
            str50.strmontomes = str50.montomes.ToString
            str50.montoacumulado = (Me.obtenerDiferenciaDebeHaberAcumulado(cta50, mes)) * (-1)
            str50.strmontoacumulado = str50.montoacumulado.ToString
            lisres.Add(str50)
        End If

        Me.SubTotalPatrimonio += str50.montomes
        Me.SubTotalPatrimonioAcu += str50.montoacumulado

        '
        Dim cta51 As New SuperEntidad
        cta51.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "51" + ent.PeriodoRegContabCabe
        cta51 = Me.buscarCuentaSaldoExisPorClave(cta51)
        Dim str51 As New Reportes.EstadoFinanciero
        If cta51.ClaveSaldoContable <> "" Then
            str51.codigo = "51"
            str51.nombre = cta51.NombreCuentaPcge
            str51.montomes = (Me.obtenerDiferenciaDebeHaber(cta51, mes)) * (-1)
            str51.strmontomes = str51.montomes.ToString
            str51.montoacumulado = (Me.obtenerDiferenciaDebeHaberAcumulado(cta51, mes)) * (-1)
            str51.strmontoacumulado = str51.montoacumulado.ToString
            lisres.Add(str51)
        End If

        Me.SubTotalPatrimonio += str51.montomes
        Me.SubTotalPatrimonioAcu += str51.montoacumulado

        Dim cta52 As New SuperEntidad
        cta52.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "52" + ent.PeriodoRegContabCabe
        cta52 = Me.buscarCuentaSaldoExisPorClave(cta52)
        Dim str52 As New Reportes.EstadoFinanciero
        If cta52.ClaveSaldoContable <> "" Then
            str52.codigo = "52"
            str52.nombre = cta52.NombreCuentaPcge
            str52.montomes = (Me.obtenerDiferenciaDebeHaber(cta52, mes)) * (-1)
            str52.strmontomes = str52.montomes.ToString
            str52.montoacumulado = (Me.obtenerDiferenciaDebeHaberAcumulado(cta52, mes)) * (-1)
            str52.strmontoacumulado = str52.montoacumulado.ToString
            lisres.Add(str52)
        End If

        Me.SubTotalPatrimonio += str52.montomes
        Me.SubTotalPatrimonioAcu += str52.montoacumulado

        Dim cta56 As New SuperEntidad
        cta56.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "56" + ent.PeriodoRegContabCabe
        cta56 = Me.buscarCuentaSaldoExisPorClave(cta56)
        Dim str56 As New Reportes.EstadoFinanciero
        If cta56.ClaveSaldoContable <> "" Then
            str56.codigo = "56"
            str56.nombre = cta52.NombreCuentaPcge
            str56.montomes = (Me.obtenerDiferenciaDebeHaber(cta56, mes)) * (-1)
            str56.strmontomes = str56.montomes.ToString
            str56.montoacumulado = (Me.obtenerDiferenciaDebeHaberAcumulado(cta56, mes)) * (-1)
            str56.strmontoacumulado = str56.montoacumulado.ToString
            lisres.Add(str56)
        End If

        Me.SubTotalPatrimonio += str56.montomes
        Me.SubTotalPatrimonioAcu += str56.montoacumulado

        Dim cta57 As New SuperEntidad
        cta57.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "57" + ent.PeriodoRegContabCabe
        cta57 = Me.buscarCuentaSaldoExisPorClave(cta57)
        Dim str57 As New Reportes.EstadoFinanciero
        If cta57.ClaveSaldoContable <> "" Then
            str57.codigo = "57"
            str57.nombre = cta57.NombreCuentaPcge
            str57.montomes = (Me.obtenerDiferenciaDebeHaber(cta57, mes)) * (-1)
            str57.strmontomes = str57.montomes.ToString
            str57.montoacumulado = (Me.obtenerDiferenciaDebeHaberAcumulado(cta57, mes)) * (-1)
            str57.strmontoacumulado = str57.montoacumulado.ToString
            lisres.Add(str57)
        End If

        Me.SubTotalPatrimonio += str57.montomes
        Me.SubTotalPatrimonioAcu += str57.montoacumulado

        Dim cta58 As New SuperEntidad
        cta58.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "58" + ent.PeriodoRegContabCabe
        cta58 = Me.buscarCuentaSaldoExisPorClave(cta58)
        Dim str58 As New Reportes.EstadoFinanciero
        If cta58.ClaveSaldoContable <> "" Then
            str58.codigo = "58"
            str58.nombre = cta58.NombreCuentaPcge
            str58.montomes = (Me.obtenerDiferenciaDebeHaber(cta58, mes)) * (-1)
            str58.strmontomes = str58.montomes.ToString
            str58.montoacumulado = (Me.obtenerDiferenciaDebeHaberAcumulado(cta58, mes)) * (-1)
            str58.strmontoacumulado = str58.montoacumulado.ToString
            lisres.Add(str58)
        End If

        Me.SubTotalPatrimonio += str58.montomes
        Me.SubTotalPatrimonioAcu += str58.montoacumulado

        ' Leer Cuentas 591 y 592 resultados acumulados
        Dim cta591 As New SuperEntidad
        Dim cta592 As New SuperEntidad

        cta591.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "591" + ent.PeriodoRegContabCabe
        cta591 = Me.buscarCuentaSaldoExisPorClave(cta591)

        cta592.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "592" + ent.PeriodoRegContabCabe
        cta592 = Me.buscarCuentaSaldoExisPorClave(cta592)

        Dim str591_592 As New Reportes.EstadoFinanciero
        If cta591.ClaveSaldoContable <> "" Then

            str591_592.nombre = "Resultados Acumulados"
            Dim dif As Decimal = 0
            Dim difacu As Decimal = 0
            If Me.obtenerDiferenciaDebeHaberAcumulado(cta591, mes) = 0 Then
                dif = Me.obtenerDiferenciaDebeHaber(cta592, mes)
                difacu = Me.obtenerDiferenciaDebeHaberAcumulado(cta592, mes)
                str591_592.codigo = "592"
            Else
                dif = Me.obtenerDiferenciaDebeHaber(cta591, mes)
                difacu = Me.obtenerDiferenciaDebeHaberAcumulado(cta591, mes)
                str591_592.codigo = "591"
            End If
            str591_592.montomes = dif
            str591_592.strmontomes = str591_592.montomes.ToString
            str591_592.montoacumulado = difacu
            str591_592.strmontoacumulado = str591_592.montoacumulado.ToString
            lisres.Add(str591_592)
        End If

        'Obtener SubtotalPatrimono 
        Me.SubTotalPatrimonio += str591_592.montomes
        Me.SubTotalPatrimonioAcu += str591_592.montoacumulado


        'Resultado del Ejercicio
        Dim str591_592r As New Reportes.EstadoFinanciero

        str591_592r.nombre = "Resultados Del Ejercicio"
        Dim difr As Decimal = 0
        Dim difacur As Decimal = 0

        difr = Me.TotalActivo - (Me.TotalPasivo + Me.SubTotalPatrimonio)
        difacur = Me.TotalActivoAcu - (Me.TotalPasivoAcu + Me.SubTotalPatrimonioAcu)

        'MsgBox(Me.TotalActivo.ToString + "   " + Me.TotalPasivo.ToString + "   " + Me.SubTotalPatrimonio.ToString)

        If difr < 0 Then
            'difacu = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta592, mes)) * (-1)
            str591_592r.codigo = "592"
        Else
            'difacu = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta591, mes))
            str591_592r.codigo = "591"
        End If
        str591_592r.montomes = difr
        str591_592r.strmontomes = str591_592r.montomes.ToString
        str591_592r.montoacumulado = difacur
        str591_592r.strmontoacumulado = str591_592r.montoacumulado.ToString
        lisres.Add(str591_592r)


        ''Poner linea de 592..
        Dim strl591_592 As New Reportes.EstadoFinanciero
        strl591_592.codigo = ""
        strl591_592.nombre = ""
        strl591_592.montomes = 0
        strl591_592.strmontomes = "-----------------"
        lisres.Add(strl591_592)

        'Total Activo Corriente
        Dim strtopa As New Reportes.EstadoFinanciero
        strtopa.codigo = ""
        strtopa.nombre = "     TOTAL PATRIMONIO"
        strtopa.montomes = str50.montomes + str51.montomes + str52.montomes + str56.montomes + str57.montomes + str58.montomes + str591_592.montomes + str591_592r.montomes
        strtopa.strmontomes = strtopa.montomes.ToString
        strtopa.montoacumulado = str50.montoacumulado + str51.montoacumulado + str52.montoacumulado + str56.montoacumulado + str57.montoacumulado + str58.montoacumulado + str591_592.montoacumulado + str591_592r.montoacumulado
        strtopa.strmontoacumulado = strtopa.montoacumulado.ToString
        lisres.Add(strtopa)

        ''Poner linea Patrimonio
        Dim strlpat As New Reportes.EstadoFinanciero
        strlpat.codigo = ""
        strlpat.nombre = ""
        strlpat.montomes = 0
        strlpat.strmontomes = "-----------------"
        lisres.Add(strlpat)

        'Total Activo Corriente
        Dim strtopp As New Reportes.EstadoFinanciero
        strtopp.codigo = ""
        strtopp.nombre = "     TOTAL PASIVO Y PATRIMONIO"
        strtopp.montomes = strpaco.montomes + strtopa.montomes
        strtopp.strmontomes = strtopp.montomes.ToString
        strtopp.montoacumulado = strpaco.montoacumulado + strtopa.montoacumulado
        strtopp.strmontoacumulado = strtopp.montoacumulado.ToString
        lisres.Add(strtopp)

        ''Linea Final 
        Dim strlFin As New Reportes.EstadoFinanciero
        strlFin.codigo = ""
        strlFin.nombre = ""
        strlFin.montomes = 0
        strlFin.strmontomes = "========="
        lisres.Add(strlFin)

        Return lisres

    End Function

    Function ObtenerBalanceGeneralPasivo1(ByRef ent As SuperEntidad) As List(Of Reportes.EstadoFinanciero)
        Dim lisres As New List(Of Reportes.EstadoFinanciero)
        'Dim res As Reportes.GananciaPerdidaXFuncion
        Dim mes As String = ent.CodigoMes

        'Activo  Corriente    
        Dim straco As New Reportes.EstadoFinanciero
        straco.codigo = ""
        straco.nombre = "PASIVO CORRIENTE"
        straco.montomes = 0
        straco.strmontomes = ""
        lisres.Add(straco)

        Dim objAD As New SaldoContableAD
        Dim cta40 As New SuperEntidad
        cta40.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "40" + ent.PeriodoRegContabCabe
        cta40 = Me.buscarCuentaSaldoExisPorClave(cta40)
        Dim str40 As New Reportes.EstadoFinanciero
        If cta40.ClaveSaldoContable <> "" Then
            str40.codigo = "40"
            str40.nombre = cta40.NombreCuentaPcge
            str40.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta40, mes))
            str40.strmontomes = str40.montomes.ToString
            str40.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta40, mes))
            str40.strmontoacumulado = str40.montoacumulado.ToString
            lisres.Add(str40)
        End If

        '
        Dim cta4111101 As New SuperEntidad
        cta4111101.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "4111101" + ent.PeriodoRegContabCabe
        cta4111101 = Me.buscarCuentaSaldoExisPorClave(cta4111101)
        Dim str41_44 As New Reportes.EstadoFinanciero
        If cta4111101.ClaveSaldoContable <> "" Then
            'str41_44.codigo = "41"
            'str41_44.nombre = cta41.NombreCuentaPcge
            str41_44.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta4111101, mes))
            'str41_44.strmontomes = str41.montomes.ToString
            str41_44.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta4111101, mes))
            'str41_44.strmontoacumulado = str41.montoacumulado.ToString
            'lisres.Add(str41_44)
        End If

        Dim cta4114101 As New SuperEntidad
        cta4114101.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "4114101" + ent.PeriodoRegContabCabe
        cta4114101 = Me.buscarCuentaSaldoExisPorClave(cta4114101)
        If cta4114101.ClaveSaldoContable <> "" Then
            'str41_44.codigo = "41"
            'str41_44.nombre = cta41.NombreCuentaPcge
            str41_44.montomes += Math.Abs(Me.obtenerDiferenciaDebeHaber(cta4114101, mes))
            'str41_44.strmontomes = str41.montomes.ToString
            str41_44.montoacumulado += Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta4114101, mes))
            'str41_44.strmontoacumulado = str41.montoacumulado.ToString
            'lisres.Add(str41_44)
        End If

        Dim cta4115101 As New SuperEntidad
        cta4115101.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "4115101" + ent.PeriodoRegContabCabe
        cta4115101 = Me.buscarCuentaSaldoExisPorClave(cta4115101)
        If cta4115101.ClaveSaldoContable <> "" Then
            'str41_44.codigo = "41"
            'str41_44.nombre = cta41.NombreCuentaPcge
            str41_44.montomes += Math.Abs(Me.obtenerDiferenciaDebeHaber(cta4115101, mes))
            'str41_44.strmontomes = str41.montomes.ToString
            str41_44.montoacumulado += Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta4115101, mes))
            'str41_44.strmontoacumulado = str41.montoacumulado.ToString
            'lisres.Add(str41_44)
        End If

        Dim cta4131101 As New SuperEntidad
        cta4131101.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "4131101" + ent.PeriodoRegContabCabe
        cta4131101 = Me.buscarCuentaSaldoExisPorClave(cta4131101)
        If cta4131101.ClaveSaldoContable <> "" Then
            'str41_44.codigo = "41"
            'str41_44.nombre = cta41.NombreCuentaPcge
            str41_44.montomes += Math.Abs(Me.obtenerDiferenciaDebeHaber(cta4131101, mes))
            'str41_44.strmontomes = str41.montomes.ToString
            str41_44.montoacumulado += Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta4131101, mes))
            'str41_44.strmontoacumulado = str41.montoacumulado.ToString
            'lisres.Add(str41_44)
        End If

        Dim cta4191021 As New SuperEntidad
        cta4191021.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "4191021" + ent.PeriodoRegContabCabe
        cta4191021 = Me.buscarCuentaSaldoExisPorClave(cta4191021)
        If cta4191021.ClaveSaldoContable <> "" Then
            'str41_44.codigo = "41"
            'str41_44.nombre = cta41.NombreCuentaPcge
            str41_44.montomes += Math.Abs(Me.obtenerDiferenciaDebeHaber(cta4191021, mes))
            'str41_44.strmontomes = str41.montomes.ToString
            str41_44.montoacumulado += Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta4191021, mes))
            'str41_44.strmontoacumulado = str41.montoacumulado.ToString
            'lisres.Add(str41_44)
        End If

        Dim cta4412101 As New SuperEntidad
        cta4412101.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "4412101" + ent.PeriodoRegContabCabe
        cta4412101 = Me.buscarCuentaSaldoExisPorClave(cta4412101)
        If cta4412101.ClaveSaldoContable <> "" Then
            str41_44.codigo = "-"
            str41_44.nombre = "REMUNERACIONES POR PAGAR"
            str41_44.montomes += Math.Abs(Me.obtenerDiferenciaDebeHaber(cta4412101, mes))
            str41_44.strmontomes = str41_44.montomes.ToString
            str41_44.montoacumulado += Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta4412101, mes))
            str41_44.strmontoacumulado = str41_44.montoacumulado.ToString
            lisres.Add(str41_44)
        End If

        '
        Dim cta424 As New SuperEntidad
        cta424.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "424" + ent.PeriodoRegContabCabe
        cta424 = Me.buscarCuentaSaldoExisPorClave(cta424)
        Dim str42_567 As New Reportes.EstadoFinanciero
        If cta424.ClaveSaldoContable <> "" Then
            'str42_567.codigo = "42"
            'str42_567.nombre = cta424.NombreCuentaPcge
            str42_567.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta424, mes))
            'str42_567.strmontomes = str42.montomes.ToString
            str42_567.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta424, mes))
            'str42_567.strmontoacumulado = str42.montoacumulado.ToString
            'lisres.Add(str42_567)
        End If

        Dim cta4411 As New SuperEntidad
        cta4411.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "4411" + ent.PeriodoRegContabCabe
        cta4411 = Me.buscarCuentaSaldoExisPorClave(cta4411)
        If cta4411.ClaveSaldoContable <> "" Then
            'str42_567.codigo = "42"
            'str42_567.nombre = cta424.NombreCuentaPcge
            str42_567.montomes += Math.Abs(Me.obtenerDiferenciaDebeHaber(cta4411, mes))
            'str42_567.strmontomes = str42.montomes.ToString
            str42_567.montoacumulado += Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta4411, mes))
            'str42_567.strmontoacumulado = str42.montoacumulado.ToString
            'lisres.Add(str42_567)
        End If

        Dim cta4512 As New SuperEntidad
        cta4512.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "4512" + ent.PeriodoRegContabCabe
        cta4512 = Me.buscarCuentaSaldoExisPorClave(cta4512)
        If cta4512.ClaveSaldoContable <> "" Then
            'str42_567.codigo = "42"
            'str42_567.nombre = cta424.NombreCuentaPcge
            str42_567.montomes += Math.Abs(Me.obtenerDiferenciaDebeHaber(cta4512, mes))
            'str42_567.strmontomes = str42.montomes.ToString
            str42_567.montoacumulado += Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta4512, mes))
            'str42_567.strmontoacumulado = str42.montoacumulado.ToString
            'lisres.Add(str42_567)
        End If

        Dim cta467 As New SuperEntidad
        cta467.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "467" + ent.PeriodoRegContabCabe
        cta467 = Me.buscarCuentaSaldoExisPorClave(cta467)
        If cta467.ClaveSaldoContable <> "" Then
            'str42_567.codigo = "42"
            'str42_567.nombre = cta424.NombreCuentaPcge
            str42_567.montomes += Math.Abs(Me.obtenerDiferenciaDebeHaber(cta467, mes))
            'str42_567.strmontomes = str42.montomes.ToString
            str42_567.montoacumulado += Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta467, mes))
            'str42_567.strmontoacumulado = str42.montoacumulado.ToString
            'lisres.Add(str42_567)
        End If

        Dim cta471 As New SuperEntidad
        cta471.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "471" + ent.PeriodoRegContabCabe
        cta471 = Me.buscarCuentaSaldoExisPorClave(cta471)
        If cta471.ClaveSaldoContable <> "" Then
            str42_567.codigo = "-"
            str42_567.nombre = "CUENTAS POR PAGAR DIVERSAS"
            str42_567.montomes += Math.Abs(Me.obtenerDiferenciaDebeHaber(cta471, mes))
            str42_567.strmontomes = str42_567.montomes.ToString
            str42_567.montoacumulado += Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta471, mes))
            str42_567.strmontoacumulado = str42_567.montoacumulado.ToString
            lisres.Add(str42_567)
        End If



        Dim cta421 As New SuperEntidad
        cta421.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "421" + ent.PeriodoRegContabCabe
        cta421 = Me.buscarCuentaSaldoExisPorClave(cta421)
        Dim str42_123 As New Reportes.EstadoFinanciero
        If cta421.ClaveSaldoContable <> "" Then
            'str42_123.codigo = "43"
            'str42_123.nombre = cta421.NombreCuentaPcge
            str42_123.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta421, mes))
            'str42_123.strmontomes = str421.montomes.ToString
            str42_123.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta421, mes))
            'str42-123.strmontoacumulado = str43.montoacumulado.ToString)
            'lisres.Add(str42 - 123)
        End If

        Dim cta422 As New SuperEntidad
        cta422.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "422" + ent.PeriodoRegContabCabe
        cta422 = Me.buscarCuentaSaldoExisPorClave(cta422)
        If cta422.ClaveSaldoContable <> "" Then
            'str42_123.codigo = "43"
            'str42_123.nombre = cta421.NombreCuentaPcge
            str42_123.montomes += Math.Abs(Me.obtenerDiferenciaDebeHaber(cta422, mes))
            'str42_123.strmontomes = str421.montomes.ToString
            str42_123.montoacumulado += Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta422, mes))
            'str42-123.strmontoacumulado = str43.montoacumulado.ToString)
            'lisres.Add(str42 - 123)
        End If

        Dim cta423 As New SuperEntidad
        cta423.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "423" + ent.PeriodoRegContabCabe
        cta423 = Me.buscarCuentaSaldoExisPorClave(cta423)
        If cta423.ClaveSaldoContable <> "" Then
            str42_123.codigo = "-"
            str42_123.nombre = "PROVEEDORES"
            str42_123.montomes += Math.Abs(Me.obtenerDiferenciaDebeHaber(cta423, mes))
            str42_123.strmontomes = str42_123.montomes.ToString
            str42_123.montoacumulado += Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta423, mes))
            str42_123.strmontoacumulado = str42_123.montoacumulado.ToString
            lisres.Add(str42_123)
        End If

        Dim cta44 As New SuperEntidad
        cta44.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "44" + ent.PeriodoRegContabCabe
        cta44 = Me.buscarCuentaSaldoExisPorClave(cta44)
        Dim str44 As New Reportes.EstadoFinanciero
        If cta44.ClaveSaldoContable <> "" Then
            str44.codigo = "44"
            str44.nombre = cta44.NombreCuentaPcge
            str44.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta44, mes))
            str44.strmontomes = str44.montomes.ToString
            str44.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta44, mes))
            str44.strmontoacumulado = str44.montoacumulado.ToString
            lisres.Add(str44)
        End If

 
        Dim cta46 As New SuperEntidad
        cta46.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "46" + ent.PeriodoRegContabCabe
        cta46 = Me.buscarCuentaSaldoExisPorClave(cta46)
        Dim str46 As New Reportes.EstadoFinanciero
        If cta46.ClaveSaldoContable <> "" Then
            str46.codigo = "46"
            str46.nombre = cta46.NombreCuentaPcge
            str46.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta46, mes))
            str46.strmontomes = str46.montomes.ToString
            str46.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta46, mes))
            str46.strmontoacumulado = str46.montoacumulado.ToString
            lisres.Add(str46)
        End If

        Dim cta47 As New SuperEntidad
        cta47.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "47" + ent.PeriodoRegContabCabe
        cta47 = Me.buscarCuentaSaldoExisPorClave(cta47)
        Dim str47 As New Reportes.EstadoFinanciero
        If cta47.ClaveSaldoContable <> "" Then
            str47.codigo = "47"
            str47.nombre = cta47.NombreCuentaPcge
            str47.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta47, mes))
            str47.strmontomes = str47.montomes.ToString
            str47.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta47, mes))
            str47.strmontoacumulado = str47.montoacumulado.ToString
            lisres.Add(str47)
        End If

        Dim cta48 As New SuperEntidad
        cta48.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "48" + ent.PeriodoRegContabCabe
        cta48 = Me.buscarCuentaSaldoExisPorClave(cta48)
        Dim str48 As New Reportes.EstadoFinanciero
        If cta48.ClaveSaldoContable <> "" Then
            str48.codigo = "48"
            str48.nombre = cta48.NombreCuentaPcge
            str48.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta48, mes))
            str48.strmontomes = str48.montomes.ToString
            str48.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta48, mes))
            str48.strmontoacumulado = str48.montoacumulado.ToString
            lisres.Add(str48)
        End If



        ''Poner linea de 49..
        Dim strl49 As New Reportes.EstadoFinanciero
        strl49.codigo = ""
        strl49.nombre = ""
        strl49.montomes = 0
        strl49.strmontomes = "-----------------"
        lisres.Add(strl49)

        'Total pASIVO  Corriente
        Dim strpaco As New Reportes.EstadoFinanciero
        strpaco.codigo = ""
        strpaco.nombre = "     TOTAL PASIVO CORRIENTE"
        strpaco.montomes = str40.montomes + str41_44.montomes + str42_567.montomes + str42_123.montomes + str44.montomes + str46.montomes + str47.montomes + str48.montomes
        strpaco.strmontomes = strpaco.montomes.ToString
        strpaco.montoacumulado = str40.montoacumulado + str41_44.montoacumulado + str42_567.montoacumulado + str42_123.montoacumulado + str44.montoacumulado + str46.montoacumulado + str47.montoacumulado + str48.montoacumulado
        strpaco.strmontoacumulado = strpaco.montoacumulado.ToString
        lisres.Add(strpaco)

        'Obtener Total Pasivo
        Me.TotalPasivo = strpaco.montomes
        Me.TotalPasivoAcu = strpaco.montoacumulado

        Dim cta49 As New SuperEntidad
        cta49.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "49" + ent.PeriodoRegContabCabe
        cta49 = Me.buscarCuentaSaldoExisPorClave(cta49)
        Dim str49 As New Reportes.EstadoFinanciero
        If cta49.ClaveSaldoContable <> "" Then
            str49.codigo = "49"
            str49.nombre = cta49.NombreCuentaPcge
            str49.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta49, mes))
            str49.strmontomes = str49.montomes.ToString
            str49.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta49, mes))
            str49.strmontoacumulado = str49.montoacumulado.ToString
            lisres.Add(str49)
        End If

        Dim cta415 As New SuperEntidad
        cta415.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "415" + ent.PeriodoRegContabCabe
        cta415 = Me.buscarCuentaSaldoExisPorClave(cta415)
        Dim str415 As New Reportes.EstadoFinanciero
        If cta415.ClaveSaldoContable <> "" Then
            str415.codigo = "415"
            str415.nombre = cta415.NombreCuentaPcge
            str415.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta415, mes))
            str415.strmontomes = str415.montomes.ToString
            str415.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta415, mes))
            str415.strmontoacumulado = str415.montoacumulado.ToString
            lisres.Add(str415)
        End If

        Dim cta379 As New SuperEntidad
        cta379.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "379" + ent.PeriodoRegContabCabe
        cta379 = Me.buscarCuentaSaldoExisPorClave(cta379)
        Dim str379 As New Reportes.EstadoFinanciero
        If cta379.ClaveSaldoContable <> "" Then
            str379.codigo = "-"
            str379.nombre = cta379.NombreCuentaPcge
            str379.montomes = Math.Abs(Me.obtenerDiferenciaDebeHaber(cta379, mes)) * (-1)
            str379.strmontomes = str379.montomes.ToString
            str379.montoacumulado = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta379, mes)) * (-1)
            str379.strmontoacumulado = str379.montoacumulado.ToString
            lisres.Add(str379)
        End If

        'Pasivo No Corriente    
        Dim strpat As New Reportes.EstadoFinanciero
        strpat.codigo = ""
        strpat.nombre = "PATRIMONIO"
        strpat.montomes = 0
        strpat.strmontomes = ""
        lisres.Add(strpat)

        '

        '   Me.SubTotalPatrimonio += str50.montomes
        '   Me.SubTotalPatrimonioAcu += str50.montoacumulado

        Dim cta50 As New SuperEntidad
        cta50.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "50" + ent.PeriodoRegContabCabe
        cta50 = Me.buscarCuentaSaldoExisPorClave(cta50)
        Dim str50_56 As New Reportes.EstadoFinanciero
        If cta50.ClaveSaldoContable <> "" Then
            'str50_56.codigo = "50"
            'str50_56.nombre = cta50.NombreCuentaPcge
            str50_56.montomes = (Me.obtenerDiferenciaDebeHaber(cta50, mes)) * (-1)
            'str50_56.strmontomes = str50.montomes.ToString
            str50_56.montoacumulado = (Me.obtenerDiferenciaDebeHaberAcumulado(cta50, mes)) * (-1)
            'str50_56.strmontoacumulado = str50.montoacumulado.ToString
            'lisres.Add(str50_56)
        End If


        Dim cta56 As New SuperEntidad
        cta56.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "56" + ent.PeriodoRegContabCabe
        cta56 = Me.buscarCuentaSaldoExisPorClave(cta56)

        If cta56.ClaveSaldoContable <> "" Then
            str50_56.codigo = "-"
            str50_56.nombre = "CAPITAL"
            str50_56.montomes += (Me.obtenerDiferenciaDebeHaber(cta56, mes)) * (-1)
            str50_56.strmontomes = str50_56.montomes.ToString
            str50_56.montoacumulado += (Me.obtenerDiferenciaDebeHaberAcumulado(cta56, mes)) * (-1)
            str50_56.strmontoacumulado = str50_56.montoacumulado.ToString
            lisres.Add(str50_56)
        End If

        Me.SubTotalPatrimonio += str50_56.montomes
        Me.SubTotalPatrimonioAcu += str50_56.montoacumulado


        Dim cta57 As New SuperEntidad
        cta57.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "57" + ent.PeriodoRegContabCabe
        cta57 = Me.buscarCuentaSaldoExisPorClave(cta57)
        Dim str57 As New Reportes.EstadoFinanciero
        If cta57.ClaveSaldoContable <> "" Then
            str57.codigo = "57"
            str57.nombre = cta57.NombreCuentaPcge
            str57.montomes = (Me.obtenerDiferenciaDebeHaber(cta57, mes)) * (-1)
            str57.strmontomes = str57.montomes.ToString
            str57.montoacumulado = (Me.obtenerDiferenciaDebeHaberAcumulado(cta57, mes)) * (-1)
            str57.strmontoacumulado = str57.montoacumulado.ToString
            lisres.Add(str57)
        End If

        Me.SubTotalPatrimonio += str57.montomes
        Me.SubTotalPatrimonioAcu += str57.montoacumulado

        Dim cta58 As New SuperEntidad
        cta58.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "58" + ent.PeriodoRegContabCabe
        cta58 = Me.buscarCuentaSaldoExisPorClave(cta58)
        Dim str58 As New Reportes.EstadoFinanciero
        If cta58.ClaveSaldoContable <> "" Then
            str58.codigo = "58"
            str58.nombre = cta58.NombreCuentaPcge
            str58.montomes = (Me.obtenerDiferenciaDebeHaber(cta58, mes)) * (-1)
            str58.strmontomes = str58.montomes.ToString
            str58.montoacumulado = (Me.obtenerDiferenciaDebeHaberAcumulado(cta58, mes)) * (-1)
            str58.strmontoacumulado = str58.montoacumulado.ToString
            lisres.Add(str58)
        End If

        Me.SubTotalPatrimonio += str58.montomes
        Me.SubTotalPatrimonioAcu += str58.montoacumulado


        '
        Dim cta51 As New SuperEntidad
        cta51.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "51" + ent.PeriodoRegContabCabe
        cta51 = Me.buscarCuentaSaldoExisPorClave(cta51)
        Dim str51 As New Reportes.EstadoFinanciero
        If cta51.ClaveSaldoContable <> "" Then
            str51.codigo = "51"
            str51.nombre = cta51.NombreCuentaPcge
            str51.montomes = (Me.obtenerDiferenciaDebeHaber(cta51, mes)) * (-1)
            str51.strmontomes = str51.montomes.ToString
            str51.montoacumulado = (Me.obtenerDiferenciaDebeHaberAcumulado(cta51, mes)) * (-1)
            str51.strmontoacumulado = str51.montoacumulado.ToString
            lisres.Add(str51)
        End If

        Me.SubTotalPatrimonio += str51.montomes
        Me.SubTotalPatrimonioAcu += str51.montoacumulado

        Dim cta52 As New SuperEntidad
        cta52.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "52" + ent.PeriodoRegContabCabe
        cta52 = Me.buscarCuentaSaldoExisPorClave(cta52)
        Dim str52 As New Reportes.EstadoFinanciero
        If cta52.ClaveSaldoContable <> "" Then
            str52.codigo = "52"
            str52.nombre = cta52.NombreCuentaPcge
            str52.montomes = (Me.obtenerDiferenciaDebeHaber(cta52, mes)) * (-1)
            str52.strmontomes = str52.montomes.ToString
            str52.montoacumulado = (Me.obtenerDiferenciaDebeHaberAcumulado(cta52, mes)) * (-1)
            str52.strmontoacumulado = str52.montoacumulado.ToString
            lisres.Add(str52)
        End If

        Me.SubTotalPatrimonio += str52.montomes
        Me.SubTotalPatrimonioAcu += str52.montoacumulado





        ' Leer Cuentas 591 y 592 resultados acumulados
        Dim cta591 As New SuperEntidad
        Dim cta592 As New SuperEntidad

        cta591.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "591" + ent.PeriodoRegContabCabe
        cta591 = Me.buscarCuentaSaldoExisPorClave(cta591)

        cta592.ClaveSaldoContable = SuperEntidad.xCodigoEmpresa + "592" + ent.PeriodoRegContabCabe
        cta592 = Me.buscarCuentaSaldoExisPorClave(cta592)

        Dim str591_592 As New Reportes.EstadoFinanciero
        If cta591.ClaveSaldoContable <> "" Then

            str591_592.nombre = "Resultados Acumulados"
            Dim dif As Decimal = 0
            Dim difacu As Decimal = 0
            If Me.obtenerDiferenciaDebeHaberAcumulado(cta591, mes) = 0 Then
                dif = Me.obtenerDiferenciaDebeHaber(cta592, mes)
                difacu = Me.obtenerDiferenciaDebeHaberAcumulado(cta592, mes)
                str591_592.codigo = "592"
            Else
                dif = Me.obtenerDiferenciaDebeHaber(cta591, mes)
                difacu = Me.obtenerDiferenciaDebeHaberAcumulado(cta591, mes)
                str591_592.codigo = "591"
            End If
            str591_592.montomes = dif
            str591_592.strmontomes = str591_592.montomes.ToString
            str591_592.montoacumulado = difacu
            str591_592.strmontoacumulado = str591_592.montoacumulado.ToString
            lisres.Add(str591_592)
        End If

        'Obtener SubtotalPatrimono 
        Me.SubTotalPatrimonio += str591_592.montomes
        Me.SubTotalPatrimonioAcu += str591_592.montoacumulado


        'Resultado del Ejercicio
        Dim str591_592r As New Reportes.EstadoFinanciero

        str591_592r.nombre = "Resultados Del Ejercicio"
        Dim difr As Decimal = 0
        Dim difacur As Decimal = 0

        difr = Me.TotalActivo - (Me.TotalPasivo + Me.SubTotalPatrimonio)
        difacur = Me.TotalActivoAcu - (Me.TotalPasivoAcu + Me.SubTotalPatrimonioAcu)

        'MsgBox(Me.TotalActivo.ToString + "   " + Me.TotalPasivo.ToString + "   " + Me.SubTotalPatrimonio.ToString)

        If difr < 0 Then
            'difacu = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta592, mes)) * (-1)
            str591_592r.codigo = "592"
        Else
            'difacu = Math.Abs(Me.obtenerDiferenciaDebeHaberAcumulado(cta591, mes))
            str591_592r.codigo = "591"
        End If
        str591_592r.montomes = difr
        str591_592r.strmontomes = str591_592r.montomes.ToString
        str591_592r.montoacumulado = difacur
        str591_592r.strmontoacumulado = str591_592r.montoacumulado.ToString
        lisres.Add(str591_592r)


        ''Poner linea de 592..
        Dim strl591_592 As New Reportes.EstadoFinanciero
        strl591_592.codigo = ""
        strl591_592.nombre = ""
        strl591_592.montomes = 0
        strl591_592.strmontomes = "-----------------"
        lisres.Add(strl591_592)

        'Total Activo Corriente
        Dim strtopa As New Reportes.EstadoFinanciero
        strtopa.codigo = ""
        strtopa.nombre = "     TOTAL PATRIMONIO"
        strtopa.montomes = str50_56.montomes + str51.montomes + str52.montomes + str57.montomes + str58.montomes + str591_592.montomes + str591_592r.montomes
        strtopa.strmontomes = strtopa.montomes.ToString
        strtopa.montoacumulado = str50_56.montoacumulado + str51.montoacumulado + str52.montoacumulado + str57.montoacumulado + str58.montoacumulado + str591_592.montoacumulado + str591_592r.montoacumulado
        strtopa.strmontoacumulado = strtopa.montoacumulado.ToString
        lisres.Add(strtopa)

        ''Poner linea Patrimonio
        Dim strlpat As New Reportes.EstadoFinanciero
        strlpat.codigo = ""
        strlpat.nombre = ""
        strlpat.montomes = 0
        strlpat.strmontomes = "-----------------"
        lisres.Add(strlpat)

        'Total Activo Corriente
        Dim strtopp As New Reportes.EstadoFinanciero
        strtopp.codigo = ""
        strtopp.nombre = "     TOTAL PASIVO Y PATRIMONIO"
        strtopp.montomes = strpaco.montomes + strtopa.montomes
        strtopp.strmontomes = strtopp.montomes.ToString
        strtopp.montoacumulado = strpaco.montoacumulado + strtopa.montoacumulado
        strtopp.strmontoacumulado = strtopp.montoacumulado.ToString
        lisres.Add(strtopp)

        ''Linea Final 
        Dim strlFin As New Reportes.EstadoFinanciero
        strlFin.codigo = ""
        strlFin.nombre = ""
        strlFin.montomes = 0
        strlFin.strmontomes = "========="
        lisres.Add(strlFin)

        Return lisres

    End Function


    Public Function ListarSaldosContables(ByVal pNumeroDigitosAnalitica As Integer, ByVal pListaMovimientoDetalle As List(Of SuperEntidad)) As List(Of List(Of SuperEntidad))
        'LISTA QUE TENDRAN LOS SALDOS CONTABLES DE TODAS LAS CUENTAS
        'DESDE 2 HASTA EL NUMERO DE DIGITOS QUE TIENE UNA CUENTA ANALITICA
        Dim iListaResultado As New List(Of List(Of SuperEntidad))
        Dim iListaPorNumeroDigito As List(Of SuperEntidad)

        'LLENAR LA LISTA RESULTADO CON EL NUMERO DE LISTAS QUE HAY 
        'DESDE 2 HASTA EN NUMERO DE DIGITOS QUE TIENE UNA CUENTA ANALITICA
        For n As Integer = 2 To pNumeroDigitosAnalitica
            iListaPorNumeroDigito = New List(Of SuperEntidad)
            iListaResultado.Add(iListaPorNumeroDigito)
        Next


        'VARIABLE QUE CAPTURA LA CUENTA AL NUMERO DE DIGITOS EN PROCESO
        Dim iCuenta As String = String.Empty
        'VARIABLE QUE CAPTURA SI EL MOVIMIENTO DETALLE ES UN DEBE O HABER
        Dim iDebeHaber As String = String.Empty
        'VARIABLE QUE CAPTURA EL IMPORTE EN SOLES DEL MOVIMIENTO DETALLE
        Dim iImporte As Decimal = 0
        'NUMERO DE OBJETOS DE LA LISTA EN PROCESO
        Dim iNumeroObjetos As Integer = 0
        'OBJETO PARA SALDO
        Dim iObjSaldo As SuperEntidad
        'RECORRER CADA MOVIMIENTO DETALLE
        For n As Integer = 0 To pListaMovimientoDetalle.Count - 1
            'FOR PARA RECORRER SEH¡GUN NUMERO DE DIGITOS
            For m As Integer = 2 To pNumeroDigitosAnalitica
                iCuenta = pListaMovimientoDetalle.Item(n).CodigoCuentaPcge.Substring(0, m)
                'MsgBox(pListaMovimientoDetalle.Item(n).CodigoCuentaPcge)
                iDebeHaber = pListaMovimientoDetalle.Item(n).DebeHaberRegContabDeta
                iImporte = pListaMovimientoDetalle.Item(n).ImporteSRegContabDeta
                iNumeroObjetos = iListaResultado.Item(m - 2).Count
                'SI LA LISTA ESTA EN CERO ENTONCES METEMOS EL PRIMER OBJETO
                If iNumeroObjetos = 0 Then
                    iObjSaldo = New SuperEntidad
                    'iObjSaldo = pListaMovimientoDetalle.Item(n)
                    iObjSaldo.CodigoCuentaPcge = iCuenta
                    If iDebeHaber = "Debe" Then
                        iObjSaldo.SumaDebeRegContabCabe = iImporte
                    Else
                        iObjSaldo.SumaHaberRegContabCabe = iImporte
                    End If
                    ' MsgBox(pListaMovimientoDetalle.Item(n).CodigoCuentaPcge)
                    iListaResultado.Item(m - 2).Add(iObjSaldo)
                Else
                    Dim iRecorre As Integer = 0
                    'SI LA LISTA TIENE POR LO MENOS UN REGISTRO ENTONCES BUSCAMOS EL OBJETO
                    For Each xObj As SuperEntidad In iListaResultado.Item(m - 2)
                        If iCuenta = xObj.CodigoCuentaPcge Then
                            'PREGUNTAR SI ES UN DEBE O HABER
                            If iDebeHaber = "Debe" Then
                                xObj.SumaDebeRegContabCabe += iImporte
                            Else
                                xObj.SumaHaberRegContabCabe += iImporte
                            End If
                            Exit For
                        End If
                        'SI EN CADA PASO NO ENCUENTRA EL OBJETO 
                        iRecorre += 1
                    Next
                    'SI NO LO ENCONTRO EL OBJETO ENTONCES PONEMOS EL OBJETO
                    If iRecorre = iNumeroObjetos Then
                        iObjSaldo = New SuperEntidad
                        'iObjSaldo = pListaMovimientoDetalle.Item(n)
                        iObjSaldo.CodigoCuentaPcge = iCuenta
                        If iDebeHaber = "Debe" Then
                            iObjSaldo.SumaDebeRegContabCabe = iImporte
                        Else
                            iObjSaldo.SumaHaberRegContabCabe = iImporte
                        End If
                        iListaResultado.Item(m - 2).Add(iObjSaldo)
                    End If
                End If
            Next
        Next

        Return iListaResultado
    End Function

    Public Function ListarSaldosContableXFormatoContable(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim objad As New SaldoContableAD
        Return objad.ListarSaldosContableXFormatoContable(ent)
    End Function

    Public Function ListarSaldosContableXPeriodoYAnaliticas(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim objad As New SaldoContableAD
        Return objad.ListarSaldosContableXPeriodoYAnaliticas(ent)
    End Function


    Function obtenerDebeAcumulado(ByRef xobj As SuperEntidad, ByVal xmes As String) As Decimal
        Dim montacum As Decimal = 0
        If xmes >= "00" Then
            montacum = xobj.DebeS00SaldoContable
        End If

        If xmes >= "01" Then
            montacum += xobj.DebeS01SaldoContable
        End If

        If xmes >= "02" Then
            montacum += xobj.DebeS02SaldoContable
        End If

        If xmes >= "03" Then
            montacum += xobj.DebeS03SaldoContable
        End If

        If xmes >= "04" Then
            montacum += xobj.DebeS04SaldoContable
        End If

        If xmes >= "05" Then
            montacum += xobj.DebeS05SaldoContable
        End If

        If xmes >= "06" Then
            montacum += xobj.DebeS06SaldoContable
        End If

        If xmes >= "07" Then
            montacum += xobj.DebeS07SaldoContable
        End If

        If xmes >= "08" Then
            montacum += xobj.DebeS08SaldoContable
        End If

        If xmes >= "09" Then
            montacum += xobj.DebeS09SaldoContable
        End If

        If xmes >= "10" Then
            montacum += xobj.DebeS10SaldoContable
        End If

        If xmes >= "11" Then
            montacum += xobj.DebeS11SaldoContable
        End If

        If xmes >= "12" Then
            montacum += xobj.DebeS12SaldoContable
        End If
        Return montacum

    End Function


    Function obtenerHaberAcumulado(ByRef xobj As SuperEntidad, ByVal xmes As String) As Decimal
        Dim montacum As Decimal = 0
        If xmes >= "00" Then
            montacum = xobj.HabeS00SaldoContable
        End If

        If xmes >= "01" Then
            montacum += xobj.HabeS01SaldoContable
        End If

        If xmes >= "02" Then
            montacum += xobj.HabeS02SaldoContable
        End If

        If xmes >= "03" Then
            montacum += xobj.HabeS03SaldoContable
        End If

        If xmes >= "04" Then
            montacum += xobj.HabeS04SaldoContable
        End If

        If xmes >= "05" Then
            montacum += xobj.HabeS05SaldoContable
        End If

        If xmes >= "06" Then
            montacum += xobj.HabeS06SaldoContable
        End If

        If xmes >= "07" Then
            montacum += xobj.HabeS07SaldoContable
        End If

        If xmes >= "08" Then
            montacum += xobj.HabeS08SaldoContable
        End If

        If xmes >= "09" Then
            montacum += xobj.HabeS09SaldoContable
        End If

        If xmes >= "10" Then
            montacum += xobj.HabeS10SaldoContable
        End If

        If xmes >= "11" Then
            montacum += xobj.HabeS11SaldoContable
        End If

        If xmes >= "12" Then
            montacum += xobj.HabeS12SaldoContable
        End If
        Return montacum

    End Function

    Function ListarSaldosContableParaCierreAnual(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        Dim objAD As New SaldoContableAD
        Return objAD.ListarSaldosContableParaCierreAnual(ent)
        '\\
    End Function


    Function buscarCuentaSaldoExisPorClave(ByRef ent As SuperEntidad, ByRef pLista As List(Of SuperEntidad)) As SuperEntidad
        'OBJETO RESULATDO
        Dim iSalEN As New SuperEntidad

        'LISTA ACTUALIZADA SIN EL OBJETO ENCONTRADO
        Dim iLisAct As New List(Of SuperEntidad)

        'BSUCAR EL OBJETO EN LA LISTA
        For Each xSal As SuperEntidad In pLista
            If xSal.ClaveSaldoContable = ent.ClaveSaldoContable Then
                iSalEN = xSal
            Else
                iLisAct.Add(xSal)
            End If
        Next
        pLista.Clear()
        pLista = iLisAct
        Return iSalEN
    End Function

    Sub NuevoSaldoContableMasivo(ByRef pLista As List(Of SuperEntidad))
        ''/Mandamos a modificar la b.d
        Dim objAD As New SaldoContableAD
        objAD.SpNuevoSaldoContableMasivo(pLista)
        '\\
    End Sub


    Sub ModificarSaldoContableMasivo(ByRef pLista As List(Of SuperEntidad))
        ''/Mandamos a modificar la b.d
        Dim objAD As New SaldoContableAD
        objAD.SpModificarSaldoContableMasivo(pLista)
        '\\
    End Sub


    Function obtenerDiferenciaDebeHaberAcumuladoSinApertura(ByRef xobj As SuperEntidad, ByVal xmes As String) As Decimal
        Dim montacum As Decimal = 0

        If xmes >= "01" Then
            montacum += xobj.DebeS01SaldoContable - xobj.HabeS01SaldoContable
        End If

        If xmes >= "02" Then
            montacum += xobj.DebeS02SaldoContable - xobj.HabeS02SaldoContable
        End If

        If xmes >= "03" Then
            montacum += xobj.DebeS03SaldoContable - xobj.HabeS03SaldoContable
        End If

        If xmes >= "04" Then
            montacum += xobj.DebeS04SaldoContable - xobj.HabeS04SaldoContable
        End If

        If xmes >= "05" Then
            montacum += xobj.DebeS05SaldoContable - xobj.HabeS05SaldoContable
        End If

        If xmes >= "06" Then
            montacum += xobj.DebeS06SaldoContable - xobj.HabeS06SaldoContable
        End If

        If xmes >= "07" Then
            montacum += xobj.DebeS07SaldoContable - xobj.HabeS07SaldoContable
        End If

        If xmes >= "08" Then
            montacum += xobj.DebeS08SaldoContable - xobj.HabeS08SaldoContable
        End If

        If xmes >= "09" Then
            montacum += xobj.DebeS09SaldoContable - xobj.HabeS09SaldoContable
        End If

        If xmes >= "10" Then
            montacum += xobj.DebeS10SaldoContable - xobj.HabeS10SaldoContable
        End If

        If xmes >= "11" Then
            montacum += xobj.DebeS11SaldoContable - xobj.HabeS11SaldoContable
        End If

        If xmes >= "12" Then
            montacum += xobj.DebeS12SaldoContable - xobj.HabeS12SaldoContable
        End If

        Return montacum

    End Function



End Class
