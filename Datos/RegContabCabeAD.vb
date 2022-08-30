Imports Entidad
Imports ScriptBaseDatos
Imports LibreriaGeneral
Public Class RegContabCabeAD

    Private Sql As New SqlDatos
    Private Lista As New List(Of SuperEntidad)
    Private obj As New SuperEntidad
    Private Campo As New CamposEntidad
    Private Par As New ParametroSql
    Private objCon As New SqlDatos

    Sub SetParametros(ByRef ent As SuperEntidad)
        '//Esto va al Sql a grabar

        Sql.AsignarParametro(Par.ClaveRegContabCabe, ent.ClaveRegContabCabe)
        Sql.AsignarParametro(Par.CodigoEmpresa, ent.CodigoEmpresa)
        Sql.AsignarParametro(Par.PeriodoRegContabCabe, ent.PeriodoRegContabCabe)
        Sql.AsignarParametro(Par.CodigoOrigen, ent.CodigoOrigen)
        Sql.AsignarParametro(Par.CodigoFile, ent.CodigoFile)
        Sql.AsignarParametro(Par.NumeroVoucherRegContabCabe, ent.NumeroVoucherRegContabCabe)
        Sql.AsignarParametro(Par.MonedaVoucherRegContabCabe, ent.MonedaVoucherRegContabCabe)
        Sql.AsignarParametro(Par.DiaVoucherRegContabCabe, ent.DiaVoucherRegContabCabe)
        Sql.AsignarParametro(Par.FechaVoucherRegContabCabe, ent.FechaVoucherRegContabCabe)
        Sql.AsignarParametro(Par.CodigoAuxiliar, ent.CodigoAuxiliar)
        Select Case ent.ModoCompra
            Case "Destinadas a Vtas Gravadas Excl"
                ent.ModoCompra = "0"
            Case "Destinadas a Vtas Gravadas y No Gravadas"
                ent.ModoCompra = "1"
            Case "Destinadas a Vtas No Gravadas Excl"
                ent.ModoCompra = "2"
        End Select
        Sql.AsignarParametro(Par.ModoCompra, ent.ModoCompra)
        Sql.AsignarParametro(Par.TipoDocumento, ent.TipoDocumento)
        Sql.AsignarParametro(Par.SerieDocumento, ent.SerieDocumento)
        Sql.AsignarParametro(Par.NumeroDocumento, ent.NumeroDocumento)
        Sql.AsignarParametro(Par.FechaDocumento, ent.FechaDocumento)
        Sql.AsignarParametro(Par.FechaVencimiento, ent.FechaVencimiento)
        Select Case ent.MonedaDocumento
            Case "S/."
                ent.MonedaDocumento = "0"
            Case "US$"
                ent.MonedaDocumento = "1"
            Case "CAD"
                ent.MonedaDocumento = "2"
        End Select
        Sql.AsignarParametro(Par.MonedaDocumento, ent.MonedaDocumento)
        Sql.AsignarParametro(Par.TipoDocumento1, ent.TipoDocumento1)
        Sql.AsignarParametro(Par.SerieDocumento1, ent.SerieDocumento1)
        Sql.AsignarParametro(Par.NumeroDocumento1, ent.NumeroDocumento1)
        Sql.AsignarParametro(Par.FechaDocumento1, ent.FechaDocumento1)

        Select Case ent.MonedaDocumento1
            Case "S/."
                ent.MonedaDocumento1 = "0"
            Case "US$"
                ent.MonedaDocumento1 = "1"
        End Select
        Sql.AsignarParametro(Par.MonedaDocumento1, ent.MonedaDocumento1)
        Sql.AsignarParametro(Par.VentaTipoCambio, ent.VentaTipoCambio)
        Sql.AsignarParametro(Par.VentaEurTipoCambio, ent.VentaEurTipoCambio)
        Sql.AsignarParametro(Par.IgvPar, ent.IgvPar)
        Sql.AsignarParametro(Par.ValorVtaRegContabCabe, ent.ValorVtaRegContabCabe)
        Sql.AsignarParametro(Par.IgvRegContabCabe, ent.IgvRegContabCabe)
        Sql.AsignarParametro(Par.ExoneradoRegContabCabe, ent.ExoneradoRegContabCabe)
        Sql.AsignarParametro(Par.PrecioVtaRegContabCabe, ent.PrecioVtaRegContabCabe)
        Sql.AsignarParametro(Par.ValorVtaSolRegContabCabe, ent.ValorVtaSolRegContabCabe)
        Sql.AsignarParametro(Par.IgvSolRegContabCabe, ent.IgvSolRegContabCabe)
        Sql.AsignarParametro(Par.ExoneradoSolRegContabCabe, ent.ExoneradoSolRegContabCabe)
        Sql.AsignarParametro(Par.PrecioVtaSolRegContabCabe, ent.PrecioVtaSolRegContabCabe)
        Sql.AsignarParametro(Par.GlosaRegContabCabe, ent.GlosaRegContabCabe)
        'Retencion
        Select Case ent.RetencionRegContabCabe
            Case "Si"
                ent.RetencionRegContabCabe = "1"
            Case "No"
                ent.RetencionRegContabCabe = "0"
        End Select
        Sql.AsignarParametro(Par.RetencionRegContabCabe, ent.RetencionRegContabCabe)
        Sql.AsignarParametro(Par.CodigoCuentaBanco, ent.CodigoCuentaBanco)
        Sql.AsignarParametro(Par.CodigoIngEgr, ent.CodigoIngEgr)
        Sql.AsignarParametro(Par.ImporteRegContabCabe, ent.ImporteRegContabCabe)
        Sql.AsignarParametro(Par.ImporteSolRegContabCabe, ent.ImporteSolRegContabCabe)
        'Detraccion
        Select Case ent.DetraccionRegContabCabe
            Case "Si"
                ent.DetraccionRegContabCabe = "1"
            Case "No"
                ent.DetraccionRegContabCabe = "0"
        End Select
        Sql.AsignarParametro(Par.DetraccionRegContabCabe, ent.DetraccionRegContabCabe)
        Sql.AsignarParametro(Par.NumeroPapeletaRegContabCabe, ent.NumeroPapeletaRegContabCabe)
        Sql.AsignarParametro(Par.FechaDetraccionRegContabCabe, ent.FechaDetraccionRegContabCabe)

        Sql.AsignarParametro(Par.CodigoModoPago, ent.CodigoModoPago)
        Sql.AsignarParametro(Par.DescripcionRegContabCabe, ent.DescripcionRegContabCabe)
        Sql.AsignarParametro(Par.CartaRegContabCabe, ent.CartaRegContabCabe)
        Sql.AsignarParametro(Par.VoucherIngresoRegContabCabe, ent.VoucherIngresoRegContabCabe)
        Sql.AsignarParametro(Par.EstadoRegContabCabe, ent.EstadoRegContabCabe)
        Sql.AsignarParametro(Par.SumaDebeRegContabCabe, ent.SumaDebeRegContabCabe)
        Sql.AsignarParametro(Par.SumaHaberRegContabCabe, ent.SumaHaberRegContabCabe)
        Sql.AsignarParametro(Par.UltimoCorrelativo, ent.UltimoCorrelativo)
        Sql.AsignarParametro(Par.Exporta, ent.Exporta)
        Select Case ent.EstadoRegistro
            Case "Activo"
                ent.EstadoRegistro = "1"
            Case "Desactivo"
                ent.EstadoRegistro = "0"
        End Select
        Sql.AsignarParametro(Par.EstadoRegistro, ent.EstadoRegistro)
        Sql.AsignarParametro(Par.EliminadoRegistro, ent.EliminadoRegistro)
        Sql.AsignarParametro(Par.CodigoUsuarioAgrega, ent.CodigoUsuarioAgrega)
        Sql.AsignarParametro(Par.NombreUsuarioAgrega, ent.NombreUsuarioAgrega)
        Sql.AsignarParametro(Par.FechaAgrega, ent.FechaAgrega)
        Sql.AsignarParametro(Par.CodigoUsuarioModifica, ent.CodigoUsuarioModifica)
        Sql.AsignarParametro(Par.nombreUsuarioModifica, ent.NombreUsuarioModifica)
        Sql.AsignarParametro(Par.FechaModifica, ent.FechaModifica)
        Select Case ent.FlagDescuentoRegContabCabe
            Case "A.F.P."
                ent.FlagDescuentoRegContabCabe = "0"
            Case "S.N.P."
                ent.FlagDescuentoRegContabCabe = "1"
            Case Else
                ent.FlagDescuentoRegContabCabe = "2"
        End Select
        Sql.AsignarParametro(Par.FlagDescuentoRegContabCabe, ent.FlagDescuentoRegContabCabe)
        Sql.AsignarParametro(Par.CodigoAfp, ent.CodigoAfp)
        Sql.AsignarParametro(Par.ImporteDescuentoRegContabCabe, ent.ImporteDescuentoRegContabCabe)
        Sql.AsignarParametro(Par.DescuentoFondo, ent.DescuentoFondo)
        Sql.AsignarParametro(Par.DescuentoSalud, ent.DescuentoSalud)
        Sql.AsignarParametro(Par.DescuentoRemu, ent.DescuentoRemu)
        '\\
    End Sub

    Function Objeto(ByRef iDr As IDataReader) As SuperEntidad
        '//Lo que se trae del sql
        Dim objEnc As New SuperEntidad
        objEnc.CodigoEmpresa = iDr(Campo.CodEmp).ToString
        objEnc.RazonSocialEmpresa = iDr(Campo.RazSocEmp).ToString
        objEnc.PeriodoRegContabCabe = iDr(Campo.PeriodoRCC).ToString
        objEnc.CodigoOrigen = iDr(Campo.CodOriRC).ToString
        objEnc.NombreOrigen = iDr(Campo.NomOriRC).ToString
        objEnc.CodigoFile = iDr(Campo.CodFilRC).ToString
        objEnc.NombreFile = iDr(Campo.NomFilRC).ToString
        objEnc.NumeroVoucherRegContabCabe = iDr(Campo.NumVouRCC).ToString
        objEnc.ClaveRegContabCabe = iDr(Campo.ClaveRCC).ToString
        objEnc.MonedaVoucherRegContabCabe = iDr(Campo.MonVouRCC).ToString
        objEnc.DiaVoucherRegContabCabe = iDr(Campo.DiaVouRCC).ToString
        objEnc.FechaVoucherRegContabCabe = CType(iDr(Campo.FecVouRCC), DateTime)
        objEnc.CodigoAuxiliar = iDr(Campo.CodAux).ToString
        objEnc.DescripcionAuxiliar = iDr(Campo.DesAux).ToString
        objEnc.ApellidoPaternoAuxiliar = iDr(Campo.ApePatAux).ToString
        objEnc.ApellidoMaternoAuxiliar = iDr(Campo.ApeMatAux).ToString
        objEnc.PrimerNombreAuxiliar = iDr(Campo.PriNomAux).ToString
        objEnc.SegundoNombreAuxiliar = iDr(Campo.SegNomAux).ToString
        objEnc.PaisNoDomiciliadoAuxiliar = iDr(Campo.PaiNDomAux).ToString
        objEnc.FechaInscripcionSnpAuxiliar = iDr(Campo.FecInsSnpAux).ToString
        objEnc.TipoDocumentoAuxiliar = iDr(Campo.TipDocAux).ToString
        'Moneda documento
        Select Case iDr(Campo.ModCom).ToString
            Case "0"
                objEnc.ModoCompra = "Destinadas a Vtas Gravadas Excl"
            Case "1"
                objEnc.ModoCompra = "Destinadas a Vtas Gravadas y No Gravadas"
            Case "2"
                objEnc.ModoCompra = "Destinadas a Vtas No Gravadas Excl"
            Case Else
                objEnc.ModoCompra = ""
        End Select
        objEnc.TipoDocumento = iDr(Campo.CodTipDoc).ToString
        objEnc.NombreDocumento = iDr(Campo.NomTipDoc).ToString
        objEnc.SerieDocumento = iDr(Campo.SerDoC).ToString
        objEnc.NumeroDocumento = iDr(Campo.NumDoc).ToString
        objEnc.FechaDocumento = CType(iDr(Campo.FecDoc), DateTime)
        objEnc.FechaVencimiento = CType(iDr(Campo.Fecvcto), DateTime)
        'Moneda documento
        Select Case iDr(Campo.MonDoc).ToString
            Case "0"
                objEnc.MonedaDocumento = "S/."
            Case "1"
                objEnc.MonedaDocumento = "US$"
            Case "2"
                objEnc.MonedaDocumento = "CAD"
        End Select
        objEnc.TipoDocumento1 = iDr(Campo.CodTipDoc1).ToString
        objEnc.NombreDocumento1 = iDr(Campo.NomTipDoc1).ToString
        objEnc.SerieDocumento1 = iDr(Campo.SerDoC1).ToString
        objEnc.NumeroDocumento1 = iDr(Campo.NumDoc1).ToString
        objEnc.FechaDocumento1 = iDr(Campo.FecDoc1).ToString
        'Moneda documento
        If iDr(Campo.MonDoc1).ToString = "0" Then
            objEnc.MonedaDocumento1 = "S/."
        Else
            objEnc.MonedaDocumento1 = "US$"
        End If

        'Detraccion
        If iDr(Campo.DetraRCC).ToString = "1" Then
            objEnc.DetraccionRegContabCabe = "Si"
        Else
            objEnc.DetraccionRegContabCabe = "No"
        End If
        objEnc.VentaTipoCambio = CType(iDr(Campo.VenTipCam), Decimal)
        objEnc.VentaEurTipoCambio = CType(iDr(Campo.VenEurTipCam), Decimal)
        objEnc.IgvPar = CType(iDr(Campo.IgvPar), Decimal)
        'Retencion
        If iDr(Campo.RetenRCC).ToString = "1" Then
            objEnc.RetencionRegContabCabe = "Si"
        Else
            objEnc.RetencionRegContabCabe = "No"
        End If
        If objEnc.CodigoFile = "407" Or objEnc.CodigoFile = "507" Then
            objEnc.ExoneradoRegContabCabe = Math.Abs(CType(iDr(Campo.ExoneradoRCC), Decimal))
            objEnc.ExoneradoSolRegContabCabe = Math.Abs(CType(iDr(Campo.ExoneradoSRCC), Decimal))
        Else
            objEnc.ExoneradoRegContabCabe = CType(iDr(Campo.ExoneradoRCC), Decimal)
            objEnc.ExoneradoSolRegContabCabe = CType(iDr(Campo.ExoneradoSRCC), Decimal)
        End If
        objEnc.NumeroPapeletaRegContabCabe = iDr(Campo.NumPapeRCC).ToString
        objEnc.FechaDetraccionRegContabCabe = iDr(Campo.FechDetraRCC).ToString
        objEnc.IgvPar = Math.Abs(CType(iDr(Campo.IgvPar), Decimal))
        objEnc.ValorVtaRegContabCabe = Math.Abs(CType(iDr(Campo.ValVtaRCC), Decimal))
        objEnc.IgvRegContabCabe = Math.Abs(CType(iDr(Campo.IgvRCC), Decimal))
        objEnc.PrecioVtaRegContabCabe = Math.Abs(CType(iDr(Campo.PreVtaRCC), Decimal))
        objEnc.ValorVtaSolRegContabCabe = Math.Abs(CType(iDr(Campo.ValVtasRCC), Decimal))
        objEnc.IgvSolRegContabCabe = Math.Abs(CType(iDr(Campo.IgvsRCC), Decimal))
        objEnc.PrecioVtaSolRegContabCabe = Math.Abs(CType(iDr(Campo.PreVtasRCC), Decimal))
        objEnc.GlosaRegContabCabe = iDr(Campo.GlosaRCC).ToString
        objEnc.ImporteRegContabCabe = Math.Abs(CType(iDr(Campo.ImpRCC), Decimal))
        objEnc.ImporteSolRegContabCabe = Math.Abs(CType(iDr(Campo.ImpSolRCC), Decimal))
        objEnc.CodigoCuentaBanco = iDr(Campo.CodCtaBco).ToString
        objEnc.BancoCuentaBanco = iDr(Campo.BcoCtaBco).ToString
        objEnc.NombreCuentaPcge = iDr(Campo.NomCtaPcge).ToString
        objEnc.NumeroCuentaBanco = iDr(Campo.NumCtaBco).ToString
        objEnc.CodigoIngEgr = iDr(Campo.CodIngEgr).ToString
        objEnc.NombreIngEgr = iDr(Campo.NomIngEgr1).ToString
        'Moneda cuenta en transferencia 
        Select Case iDr(Campo.MonCtaBco).ToString
            Case "0"
                objEnc.MonedaCuentaBanco = "S/."
            Case "1"
                objEnc.MonedaCuentaBanco = "US$"
            Case "2"
                objEnc.MonedaCuentaBanco = "EUR"
        End Select
        objEnc.CartaRegContabCabe = iDr(Campo.CarRCC).ToString
        objEnc.DescripcionRegContabCabe = iDr(Campo.DesRCC).ToString
        objEnc.VoucherIngresoRegContabCabe = iDr(Campo.VouIngRCC).ToString
        objEnc.SumaDebeRegContabCabe = CType(iDr(Campo.SumDebRCC), Decimal)
        objEnc.SumaHaberRegContabCabe = CType(iDr(Campo.SumHabRCC), Decimal)
        objEnc.DiferenciaDH = CType(iDr(Campo.SumDebRCC), Decimal) - CType(iDr(Campo.SumHabRCC), Decimal)
        objEnc.UltimoCorrelativo = iDr(Campo.UltCorre).ToString
        'Concepto
        objEnc.CodigoCuentaBanco = iDr(Campo.CodCtaBco).ToString
        objEnc.NumeroCuentaBanco = iDr(Campo.NumCtaBco).ToString
        objEnc.BancoCuentaBanco = iDr(Campo.BcoCtaBco).ToString
        objEnc.MonedaCuentaBanco = iDr(Campo.MonCtaBco).ToString
        objEnc.EstadoRegistro = iDr(Campo.EstReg).ToString
        objEnc.EliminadoRegistro = iDr(Campo.EliReg).ToString
        objEnc.CodigoUsuarioAgrega = iDr(Campo.CodUsuAgr).ToString
        objEnc.NombreUsuarioAgrega = iDr(Campo.NomUsuAgr).ToString
        objEnc.FechaAgrega = CType(iDr(Campo.FechaAgr), DateTime)
        objEnc.CodigoUsuarioModifica = iDr(Campo.CodUsuMod).ToString
        objEnc.NombreUsuarioModifica = iDr(Campo.NomUsuMod).ToString
        objEnc.FechaModifica = CType(iDr(Campo.FechaMod), DateTime)
        objEnc.Exporta = iDr(Campo.Exp).ToString
        objEnc.CodigoModoPago = iDr(Campo.CodModPag).ToString
        objEnc.NombreModoPago = iDr(Campo.NomModPag).ToString
        objEnc.EstadoRegContabCabe = iDr(Campo.EstRCC).ToString
        Select Case iDr(Campo.FlaDesRegRcc).ToString
            Case "0"
                objEnc.FlagDescuentoRegContabCabe = "A.F.P."
            Case "1"
                objEnc.FlagDescuentoRegContabCabe = "S.N.P."
            Case Else
                objEnc.FlagDescuentoRegContabCabe = "NO"
        End Select
        objEnc.CodigoAfp = iDr(Campo.CodAfp).ToString
        objEnc.NombreAfp = iDr(Campo.NomAfp).ToString
        objEnc.ImporteDescuentoRegContabCabe = CType(iDr(Campo.ImpDesRegRcc), Decimal)
        objEnc.DescuentoFondo = CType(iDr(Campo.DesFon), Decimal)
        objEnc.DescuentoSalud = CType(iDr(Campo.DesSal), Decimal)
        objEnc.DescuentoRemu = CType(iDr(Campo.DesRem), Decimal)

        'especial
        objEnc.ClaveConsultaVoucher = objEnc.CodigoFile + objEnc.NumeroVoucherRegContabCabe
        objEnc.CampoCursor = iDr(Campo.ClaveRCC).ToString
        Return objEnc
        '\\
    End Function

    Function SpAutogenerarFileManual(ByRef ent As SuperEntidad) As String
        '//
        Dim codigo As String = ""
        Try

            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpAutogenerarFileManual")
            Sql.AsignarParametro(Par.PeriodoRegContabCabe, ent.PeriodoRegContabCabe)
            Sql.AsignarParametro(Par.CodigoFile, ent.CodigoFile)

            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                codigo = iDr(0).ToString
            End While
            Return codigo
        Catch ex As Exception
            MsgBox(ex.Message) : Return codigo
        Finally
            Sql.Desconectar()
        End Try
    End Function

    Sub NuevoRegContabCabeMasivo(ByRef pLista As List(Of SuperEntidad))
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpNuevoRegContabCabe")
            For Each xRcc As SuperEntidad In pLista
                xRcc.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
                xRcc.NombreUsuarioAgrega = SuperEntidad.xNombreUsuario
                xRcc.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
                xRcc.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
                '/Asignar Parametros
                Me.SetParametros(xRcc)
                '/Ejecutar sin resultado
                Sql.EjecutarSinResultado()
                Sql.QuitarParametros()
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Sql.Desconectar()
        End Try
    End Sub


    Sub SpNuevoRegContabCabe(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpNuevoRegContabCabe")
            '/Asignar Parametros
            Me.SetParametros(ent)
            '/Ejecutar sin resultado
            Sql.EjecutarSinResultado()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Sql.Desconectar()
        End Try
    End Sub

    Sub SpModificarRegContabCabe(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpModificarRegContabCabe")
            '/Asignar Parametros
            Me.SetParametros(ent)
            '/Ejecutar sin resultado
            Sql.EjecutarSinResultado()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Sql.Desconectar()
        End Try
    End Sub

    Sub SpEliminarRegcontabCabe(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpEliminarRegContabCabe")
            '/Asignar Parametro
            Sql.AsignarParametro(Par.ClaveRegContabCabe, ent.ClaveRegContabCabe)
            '/Ejecutar sin resultado
            Sql.EjecutarSinResultado()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Sql.Desconectar()
        End Try
    End Sub

    Sub EliminarRegContabCabeDeCierreAnual(ByRef objx As SuperEntidad)
        '/
        Try
            objCon.Conectar(SqlDatos.Bd.ContabilidadEmma)

            'ARMANDO SCRIPT PARA ACTUALIZAR
            Dim eli As New SqlDelete
            eli.Tabla("RegContabCabe")

            Dim sel As New SqlSelect
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, objx.CodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.PeriodoRCC, SqlSelect.Operador.Igual, objx.PeriodoRegContabCabe)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodFilRC, SqlSelect.Operador.Igual, objx.CodigoFile)
            eli.CondicionDelete(sel.Script)

            'SCRIPT ARMADO
            objCon.ComandoText(eli.Script)

            'EJECUTAR SIN RESULTADO
            objCon.EjecutarSinResultado()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            objCon.Desconectar()
        End Try
        '/
    End Sub

    Function SpObtenerRegistrosSinCondicion(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpObtenerRegistrosSinCondicion")
            '/Asignar Parametros
            Sql.AsignarParametro(Par.Vista, ent.Vista)
            Sql.AsignarParametro(Par.DatoEliminado, ent.DatoEliminado)
            Sql.AsignarParametro(Par.DatoEstado, ent.DatoEstado)
            Sql.AsignarParametro(Par.CampoOrden, ent.CampoOrden)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function

    Function SpObtenerRegistrosConUnaCondicion(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
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
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function

    Function SpBuscarRegistroConUnaCondicion(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpBuscarRegistroConUnaCondicion")
            '/Asignar Parametros
            Sql.AsignarParametro(Par.Vista, ent.Vista)
            Sql.AsignarParametro(Par.DatoEliminado, ent.DatoEliminado)
            Sql.AsignarParametro(Par.DatoEstado, ent.DatoEstado)
            Sql.AsignarParametro(Par.CampoCondicion1, ent.CampoCondicion1)
            Sql.AsignarParametro(Par.DatoCondicion1, ent.DatoCondicion1)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Objeto Encontrado
                obj = Me.Objeto(iDr)
            End While
            Return obj
        Catch ex As Exception
            MsgBox(ex.Message) : Return obj
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function

    Function SpObtenerRegistrosConDosCondicionUnaDesigualdad(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpObtenerRegistrosConDosCondicionUnaDesigualdad")
            '/Asignar Parametros
            Sql.AsignarParametro(Par.Vista, ent.Vista)
            Sql.AsignarParametro(Par.DatoEliminado, ent.DatoEliminado)
            Sql.AsignarParametro(Par.DatoEstado, ent.DatoEstado)
            Sql.AsignarParametro(Par.CampoCondicion1, ent.CampoCondicion1)
            Sql.AsignarParametro(Par.DatoCondicion1, ent.DatoCondicion1)
            Sql.AsignarParametro(Par.CampoCondicion2, ent.CampoCondicion2)
            Sql.AsignarParametro(Par.DatoCondicion2, ent.DatoCondicion2)
            Sql.AsignarParametro(Par.CampoCondicion3, ent.CampoCondicion3)
            Sql.AsignarParametro(Par.DatoCondicion3, ent.DatoCondicion3)
            Sql.AsignarParametro(Par.CampoOrden, ent.CampoOrden)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function

    Function SpObtenerRegistrosConTresCondicion(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpObtenerRegistrosConTresCondicion")
            '/Asignar Parametros
            Sql.AsignarParametro(Par.Vista, ent.Vista)
            Sql.AsignarParametro(Par.DatoEliminado, ent.DatoEliminado)
            Sql.AsignarParametro(Par.DatoEstado, ent.DatoEstado)
            Sql.AsignarParametro(Par.CampoCondicion1, ent.CampoCondicion1)
            Sql.AsignarParametro(Par.DatoCondicion1, ent.DatoCondicion1)
            Sql.AsignarParametro(Par.CampoCondicion2, ent.CampoCondicion2)
            Sql.AsignarParametro(Par.DatoCondicion2, ent.DatoCondicion2)
            Sql.AsignarParametro(Par.CampoCondicion3, ent.CampoCondicion3)
            Sql.AsignarParametro(Par.DatoCondicion3, ent.DatoCondicion3)
            Sql.AsignarParametro(Par.CampoOrden, ent.CampoOrden)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function

    Function SpObtenerRegistrosConCuatroCondicion(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpObtenerRegistrosConCuatroCondicion")
            '/Asignar Parametros
            Sql.AsignarParametro(Par.Vista, ent.Vista)
            Sql.AsignarParametro(Par.DatoEliminado, ent.DatoEliminado)
            Sql.AsignarParametro(Par.DatoEstado, ent.DatoEstado)
            Sql.AsignarParametro(Par.CampoCondicion1, ent.CampoCondicion1)
            Sql.AsignarParametro(Par.DatoCondicion1, ent.DatoCondicion1)
            Sql.AsignarParametro(Par.CampoCondicion2, ent.CampoCondicion2)
            Sql.AsignarParametro(Par.DatoCondicion2, ent.DatoCondicion2)
            Sql.AsignarParametro(Par.CampoCondicion3, ent.CampoCondicion3)
            Sql.AsignarParametro(Par.DatoCondicion3, ent.DatoCondicion3)
            Sql.AsignarParametro(Par.CampoCondicion4, ent.CampoCondicion4)
            Sql.AsignarParametro(Par.DatoCondicion4, ent.DatoCondicion4)
            Sql.AsignarParametro(Par.CampoOrden, ent.CampoOrden)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function


    Function SpObtenerRegistrosConDosCondicion(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
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
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function

    Function SpBuscarRegistroConDosCondicion(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpBuscarRegistroConDosCondicion")
            '/Asignar Parametros
            Sql.AsignarParametro(Par.Vista, ent.Vista)
            Sql.AsignarParametro(Par.DatoEliminado, ent.DatoEliminado)
            Sql.AsignarParametro(Par.DatoEstado, ent.DatoEstado)
            Sql.AsignarParametro(Par.CampoCondicion1, ent.CampoCondicion1)
            Sql.AsignarParametro(Par.DatoCondicion1, ent.DatoCondicion1)
            Sql.AsignarParametro(Par.CampoCondicion2, ent.CampoCondicion2)
            Sql.AsignarParametro(Par.DatoCondicion2, ent.DatoCondicion2)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Objeto Encontrado
                obj = Me.Objeto(iDr)
            End While
            Return obj
        Catch ex As Exception
            MsgBox(ex.Message) : Return obj
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function



    Function SpObtenerRegistrosEntreFechas(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
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
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function

    Function SpObtenerRegistrosContablesEntreFechas(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpObtenerRegistrosContablesEntreFechas")
            '/Asignar Parametros
            Sql.AsignarParametro(Par.Vista, ent.Vista)
            Sql.AsignarParametro(Par.DatoEliminado, ent.DatoEliminado)
            Sql.AsignarParametro(Par.DatoEstado, ent.DatoEstado)
            Sql.AsignarParametro(Par.CampoCondicion1, ent.CampoCondicion1)
            Sql.AsignarParametro(Par.DatoCondicion1, ent.DatoCondicion1)
            Sql.AsignarParametro(Par.CampoFecha, ent.CampoFecha)
            Sql.AsignarParametro(Par.Desde, ent.Desde)
            Sql.AsignarParametro(Par.Hasta, ent.Hasta)
            Sql.AsignarParametro(Par.CampoOrden, ent.CampoOrden)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function

    Function ListarIngresosyEgresosXPeriodoYEmpresa(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("VsRegContabCabe")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.PeriodoRCC, SqlSelect.Operador.Igual, ent.PeriodoRegContabCabe)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, ent.CodigoEmpresa)
            sel.CondicionIn(SqlSelect.Reservada.Y, Campo.CodOriRC, "1,2")
            sel.Orden(ent.CampoOrden, SqlSelect.Order.Asc)

            Sql.ComandoText(sel.Script)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function


    Function ListarIngresosyEgresosXPeriodoYEmpresaYEstado(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("VsRegContabCabe")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.EstRCC, SqlSelect.Operador.Igual, ent.EstadoRegContabCabe)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.PeriodoRCC, SqlSelect.Operador.Igual, ent.PeriodoRegContabCabe)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, ent.CodigoEmpresa)
            sel.CondicionIn(SqlSelect.Reservada.Y, Campo.CodOriRC, "1,2")
            sel.Orden(ent.CampoOrden, SqlSelect.Order.Asc)

            Sql.ComandoText(sel.Script)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function


    Function ListarIngresosyEgresosXPeriodoYEmpresaYAuxiliar(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("VsRegContabCabe")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.PeriodoRCC, SqlSelect.Operador.Igual, ent.PeriodoRegContabCabe)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodAux, SqlSelect.Operador.Igual, ent.CodigoAuxiliar)
            sel.CondicionIn(SqlSelect.Reservada.Y, Campo.CodOriRC, "1,2")
            sel.Orden(Campo.ClaveRCC, SqlSelect.Order.Asc)
            Sql.ComandoText(sel.Script)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function


    Function ListarIngresosEgresosYDiariosXPeriodoYEmpresa(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("VsRegContabCabe")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.PeriodoRCC, SqlSelect.Operador.Igual, ent.PeriodoRegContabCabe)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionIn(SqlSelect.Reservada.Y, Campo.CodOriRC, "1,2,3")
            sel.Orden(Campo.ClaveRCC, SqlSelect.Order.Asc)
            Sql.ComandoText(sel.Script)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function


    Function ListarEgresosTransfereciaXPeriodoYEmpresa(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("VsRegContabCabe")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.PeriodoRCC, SqlSelect.Operador.Igual, ent.PeriodoRegContabCabe)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.EstRCC, SqlSelect.Operador.Igual, "T")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodOriRC, SqlSelect.Operador.Igual, "2")
            sel.Orden(ent.CampoOrden, SqlSelect.Order.Asc)
            Sql.ComandoText(sel.Script)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function


    Function ListarRegistrosPorAnoYEmpresa(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("VsRegContabCabe")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionLike(SqlSelect.Reservada.Y, Campo.PeriodoRCC, "2015")
            sel.Orden(Campo.ClaveRCC, SqlSelect.Order.Asc)
            Sql.ComandoText(sel.Script)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function



    Function ListarMovimientoXEmpresaXPeriodoYAuxiliar(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("VsRegContabCabe")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodOriRC, SqlSelect.Operador.Igual, ent.CodigoOrigen)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionBetween(SqlSelect.Reservada.Y, Campo.PeriodoRCC, ent.DatoCondicion1, ent.DatoCondicion2)
            If ent.CodigoAuxiliar <> "" Then
                sel.CondicionLike(SqlSelect.Reservada.Y, Campo.CodAux, ent.CodigoAuxiliar)
            End If


            sel.Orden(Campo.ClaveRCC, SqlSelect.Order.Asc)
            Sql.ComandoText(sel.Script)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function


    Function ListarRegistroComprasEntreFechas(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("VsRegContabCabe")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, ent.CodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodOriRC, SqlSelect.Operador.Igual, "4")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionBetween(SqlSelect.Reservada.Y, Campo.FecVouRCC, ent.DatoFiltro1, ent.DatoFiltro2)

            sel.Orden(ent.CampoOrden, SqlSelect.Order.Asc)
            Sql.ComandoText(sel.Script)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function

    Function BuscarRegContabCabeXDoc(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("VsRegContabCabe")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, ent.CodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodAux, SqlSelect.Operador.Igual, ent.CodigoAuxiliar)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodTipDoc, SqlSelect.Operador.Igual, ent.TipoDocumento)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.SerDoC, SqlSelect.Operador.Igual, ent.SerieDocumento)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.NumDoc, SqlSelect.Operador.Igual, ent.NumeroDocumento)
            sel.CondicionIn(SqlSelect.Reservada.Y, Campo.CodOriRC, "4,5,6")

            Sql.ComandoText(sel.Script)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                obj = Me.Objeto(iDr)
            End While
            Return obj
        Catch ex As Exception
            MsgBox(ex.Message) : Return obj
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function

    Function BuscarRegContabCabeXDocVta(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("VsRegContabCabe")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, ent.CodigoEmpresa)
            'sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodAux, SqlSelect.Operador.Igual, ent.CodigoAuxiliar)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodTipDoc, SqlSelect.Operador.Igual, ent.TipoDocumento)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.SerDoC, SqlSelect.Operador.Igual, ent.SerieDocumento)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.NumDoc, SqlSelect.Operador.Igual, ent.NumeroDocumento)
            sel.CondicionIn(SqlSelect.Reservada.Y, Campo.CodOriRC, "4,5,6")

            Sql.ComandoText(sel.Script)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                obj = Me.Objeto(iDr)
            End While
            Return obj
        Catch ex As Exception
            MsgBox(ex.Message) : Return obj
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function


    Function ListarRegistroContableCabeceraXPeriodoXOrigenSinEstornar(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("VsRegContabCabe")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, ent.CodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodOriRC, SqlSelect.Operador.Igual, ent.CodigoOrigen)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.PeriodoRCC, SqlSelect.Operador.Igual, ent.PeriodoRegContabCabe)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.EstReg, SqlSelect.Operador.Igual, "0") 'sin estorno
            sel.Orden(ent.CampoOrden, SqlSelect.Order.Asc)
            Sql.ComandoText(sel.Script)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function


    Function ListarRegContabEntreFechasYEmpresa(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsRegContabCabe")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.EliReg, SqlSelect.Operador.Igual, "1")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodEmp, SqlSelect.Operador.Igual, ent.CodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodOriRC, SqlSelect.Operador.Igual, ent.CodigoOrigen)
            sel.CondicionBetween(SqlSelect.Reservada.Y, Campo.FecVouRCC, ent.DatoFiltro1, ent.DatoFiltro2)

            sel.Orden(ent.CampoOrden, SqlSelect.Order.Asc)

            Sql.ComandoText(sel.Script)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function

    Function ListarDiarios395ParaExportar(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("vsRegContabCabe")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, ent.CodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodFilRC, SqlSelect.Operador.Igual, "395")
            sel.CondicionBetween(SqlSelect.Reservada.Y, Campo.FecVouRCC, ent.DatoFiltro1, ent.DatoFiltro2)
            sel.Orden(ent.CampoOrden, SqlSelect.Order.Asc)
            Sql.ComandoText(sel.Script)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function
    Function ListarRegistrosCabeceraParaLibroCajayBanco(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("VsRegContabCabe")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionIn(SqlSelect.Reservada.Y, Campo.CodOriRC, "1,2")
            sel.CondicionBetween(SqlSelect.Reservada.Y, Campo.PeriodoRCC, ent.DatoFiltro1, ent.DatoFiltro2)
            sel.CondicionBetween(SqlSelect.Reservada.Y, Campo.CodCtaBco, ent.DatoFiltro3, ent.DatoFiltro4)
            sel.Orden(ent.CampoOrden, SqlSelect.Order.Asc)
            Sql.ComandoText(sel.Script)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function

    Function ListarRegistrosCabeceraParaLibroCajayBancoXCuenta(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("VsRegContabCabe")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionIn(SqlSelect.Reservada.Y, Campo.CodOriRC, "1,2")
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.PeriodoRCC, SqlSelect.Operador.Igual, ent.PeriodoRegContabCabe)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodCtaBco, SqlSelect.Operador.Igual, ent.CodigoCuentaBanco)
            sel.Orden(ent.CampoOrden, SqlSelect.Order.Asc)
            Sql.ComandoText(sel.Script)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function

    Function ListarRegistrosCabeceraParaDescuentoHonorario(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("VsRegContabCabe")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodOriRC, SqlSelect.Operador.Igual, "6") 'honorario
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.PeriodoRCC, SqlSelect.Operador.Igual, ent.PeriodoRegContabCabe)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodAux, SqlSelect.Operador.Igual, ent.CodigoAuxiliar)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.EstReg, SqlSelect.Operador.Igual, "0") 'sin estorno
            sel.Orden(ent.CampoOrden, SqlSelect.Order.Asc)
            Sql.ComandoText(sel.Script)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function


    Function ListarRegistroContableCabeceraParaDao(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("VsRegContabCabe")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, ent.CodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodOriRC, SqlSelect.Operador.Igual, ent.CodigoOrigen)
            sel.CondicionBetween(SqlSelect.Reservada.Y, Campo.PeriodoRCC, ent.DatoFiltro1, ent.DatoFiltro2)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.FecDoc, SqlSelect.Operador.MayorIgual, FormatoFecha.AñoMesDia(ent.FechaDocumento))
            '      sel.CondicionCV(SqlSelect.Reservada.Y, Campo.EstReg, SqlSelect.Operador.Igual, "0") 'sin estorno
            sel.Orden(ent.CampoOrden, SqlSelect.Order.Asc)
            Sql.ComandoText(sel.Script)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function

    Function ListarNotasCreditoParaDiferenciaCambio(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("VsRegContabCabe")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, ent.CodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.PeriodoRCC, SqlSelect.Operador.Mayor, ent.PeriodoRegContabCabe)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodTipDoc, SqlSelect.Operador.Igual, "07") 'nota de credito
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.MonDoc, SqlSelect.Operador.Igual, "1") 'dolares
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.EstReg, SqlSelect.Operador.Igual, "0") 'sin estorno
            sel.Orden(ent.CampoOrden, SqlSelect.Order.Asc)
            Sql.ComandoText(sel.Script)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function

    Function ListarRegistrosCabeceraXOrigenYRangoFechaVoucher(ByRef ent As SuperEntidad) As List(Of SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("VsRegContabCabe")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, ent.CodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodOriRC, SqlSelect.Operador.Igual, ent.CodigoOrigen)
            sel.CondicionBetween(SqlSelect.Reservada.Y, Campo.FecVouRCC, ent.DatoCondicion1, ent.DatoCondicion2)
            sel.Orden(ent.CampoOrden, SqlSelect.Order.Asc)
            Sql.ComandoText(sel.Script)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                'Adicionando cada grupo a la Lista
                Lista.Add(Me.Objeto(iDr))
            End While
            Return Lista
        Catch ex As Exception
            MsgBox(ex.Message) : Return Lista
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function

    Sub EliminarRegContabCabePeriodoOrigenYFile(ByRef objx As SuperEntidad)
        '/
        Try
            objCon.Conectar(SqlDatos.Bd.ContabilidadEmma)
            'ARMANDO SCRIPT PARA ACTUALIZAR
            Dim eli As New SqlDelete
            eli.Tabla("RegContabCabe")

            Dim sel As New SqlSelect
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, objx.CodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.PeriodoRCC, SqlSelect.Operador.Igual, objx.PeriodoRegContabCabe)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodOriRC, SqlSelect.Operador.Igual, objx.CodigoOrigen)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodFilRC, SqlSelect.Operador.Igual, objx.CodigoFile)
            eli.CondicionDelete(sel.Script)

            'SCRIPT ARMADO
            objCon.ComandoText(eli.Script)

            'EJECUTAR SIN RESULTADO
            objCon.EjecutarSinResultado()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            objCon.Desconectar()
        End Try
        '/
    End Sub

    Function BuscarRegContabCabeXDocSinAuxiliar(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("VsRegContabCabe")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, SuperEntidad.xCodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodTipDoc, SqlSelect.Operador.Igual, ent.TipoDocumento)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.SerDoC, SqlSelect.Operador.Igual, ent.SerieDocumento)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.NumDoc, SqlSelect.Operador.Igual, ent.NumeroDocumento)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodOriRC, SqlSelect.Operador.Igual, "5") 'solo venta

            Sql.ComandoText(sel.Script)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                obj = Me.Objeto(iDr)
            End While
            Return obj
        Catch ex As Exception
            MsgBox(ex.Message) : Return obj
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function

    Function BuscarRegContabCabeXClave(ByRef ent As SuperEntidad) As SuperEntidad
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Dim sel As New SqlSelect
            sel.SeleccionaVista("VsRegContabCabe")
            sel.CondicionCV(SqlSelect.Reservada.Cuando, Campo.CodEmp, SqlSelect.Operador.Igual, ent.CodigoEmpresa)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.PeriodoRCC, SqlSelect.Operador.Igual, ent.PeriodoRegContabCabe)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodOriRC, SqlSelect.Operador.Igual, ent.CodigoOrigen)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.CodFilRC, SqlSelect.Operador.Igual, ent.CodigoFile)
            sel.CondicionCV(SqlSelect.Reservada.Y, Campo.NumVouRCC, SqlSelect.Operador.Igual, ent.NumeroVoucherRegContabCabe)

            Sql.ComandoText(sel.Script)
            '/Obtener IDr
            Dim iDr As IDataReader = Sql.ObtenerIDr
            While iDr.Read
                obj = Me.Objeto(iDr)
            End While
            Return obj
        Catch ex As Exception
            MsgBox(ex.Message) : Return obj
        Finally
            Sql.Desconectar()
        End Try
        '\\
    End Function


    

End Class