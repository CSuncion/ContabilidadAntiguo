Imports Entidad
Public Class VoucherAD
    Private Sql As New SqlDatos
    Private Lista As New List(Of SuperEntidad)
    Private obj As New SuperEntidad
    Private Campo As New CamposEntidad
    Private Par As New ParametroSql

    Sub SetParametros(ByRef ent As SuperEntidad)
        '//
        Sql.AsignarParametro(Par.ClaveVoucher, ent.ClaveVoucher)
        Sql.AsignarParametro(Par.CodigoEmpresa, ent.CodigoEmpresa)
        Sql.AsignarParametro(Par.AnoVoucher, ent.AnoVoucher)
        Sql.AsignarParametro(Par.CodigoFile, ent.CodigoFile)
        Sql.AsignarParametro(Par.AperturaVoucher, ent.AperturaVoucher)
        Sql.AsignarParametro(Par.EneroVoucher, ent.EneroVoucher)
        Sql.AsignarParametro(Par.FebreroVoucher, ent.FebreroVoucher)
        Sql.AsignarParametro(Par.MarzoVoucher, ent.MarzoVoucher)
        Sql.AsignarParametro(Par.AbrilVoucher, ent.AbrilVoucher)
        Sql.AsignarParametro(Par.MayoVoucher, ent.MayoVoucher)
        Sql.AsignarParametro(Par.JunioVoucher, ent.JunioVoucher)
        Sql.AsignarParametro(Par.JulioVoucher, ent.JulioVoucher)
        Sql.AsignarParametro(Par.AgostoVoucher, ent.AgostoVoucher)
        Sql.AsignarParametro(Par.SetiembreVoucher, ent.SetiembreVoucher)
        Sql.AsignarParametro(Par.OctubreVoucher, ent.OctubreVoucher)
        Sql.AsignarParametro(Par.NoviembreVoucher, ent.NoviembreVoucher)
        Sql.AsignarParametro(Par.DiciembreVoucher, ent.DiciembreVoucher)
        Sql.AsignarParametro(Par.CierreVoucher, ent.CierreVoucher)
        'Flag Voucher
        Select Case ent.EstadoVoucher
            Case "Activa"
                ent.EstadoVoucher = "1"
            Case "Cerrada"
                ent.EstadoVoucher = "0"
        End Select
        Sql.AsignarParametro(Par.EstadoVoucher, ent.EstadoVoucher)
        Sql.AsignarParametro(Par.Exporta, ent.Exporta)
        Sql.AsignarParametro(Par.EstadoRegistro, ent.EstadoRegistro)
        Sql.AsignarParametro(Par.EliminadoRegistro, ent.EliminadoRegistro)
        Sql.AsignarParametro(Par.CodigoUsuarioAgrega, ent.CodigoUsuarioAgrega)
        Sql.AsignarParametro(Par.NombreUsuarioAgrega, ent.NombreUsuarioAgrega)
        Sql.AsignarParametro(Par.FechaAgrega, ent.FechaAgrega)
        Sql.AsignarParametro(Par.CodigoUsuarioModifica, ent.CodigoUsuarioModifica)
        Sql.AsignarParametro(Par.nombreUsuarioModifica, ent.NombreUsuarioModifica)
        Sql.AsignarParametro(Par.FechaModifica, ent.FechaModifica)

        '\\
    End Sub

    Function Objeto(ByRef iDr As IDataReader) As SuperEntidad
        '//
        Dim objEnc As New SuperEntidad
        objEnc.ClaveVoucher = iDr(Campo.ClaVou).ToString
        objEnc.CodigoEmpresa = iDr(Campo.CodEmp).ToString
        objEnc.RazonSocialEmpresa = iDr(Campo.RazSocEmp).ToString
        objEnc.AnoVoucher = iDr(Campo.AnoVou).ToString
        objEnc.CodigoFile = iDr(Campo.CodFilRC).ToString
        objEnc.NombreFile = iDr(Campo.NomFilRC).ToString
        objEnc.AperturaVoucher = iDr(Campo.ApeVou).ToString
        objEnc.EneroVoucher = iDr(Campo.EneVou).ToString
        objEnc.FebreroVoucher = iDr(Campo.FebVou).ToString
        objEnc.MarzoVoucher = iDr(Campo.MarVou).ToString
        objEnc.AbrilVoucher = iDr(Campo.AbrVou).ToString
        objEnc.MayoVoucher = iDr(Campo.MayVou).ToString
        objEnc.JunioVoucher = iDr(Campo.JunVou).ToString
        objEnc.JulioVoucher = iDr(Campo.JulVou).ToString
        objEnc.AgostoVoucher = iDr(Campo.AgolVou).ToString
        objEnc.SetiembreVoucher = iDr(Campo.SetVou).ToString
        objEnc.OctubreVoucher = iDr(Campo.OctVou).ToString
        objEnc.NoviembreVoucher = iDr(Campo.NovVou).ToString
        objEnc.DiciembreVoucher = iDr(Campo.DicVou).ToString
        objEnc.CierreVoucher = iDr(Campo.CieVou).ToString
        If iDr(Campo.EstVoucher).ToString = "1" Then
            objEnc.EstadoVoucher = "Activa"
        Else
            objEnc.EstadoVoucher = "Cerrada"
        End If
        objEnc.Exporta = iDr(Campo.Exp).ToString
        objEnc.EstadoRegistro = iDr(Campo.EstReg).ToString
        objEnc.EliminadoRegistro = iDr(Campo.EliReg).ToString
        objEnc.CodigoUsuarioAgrega = iDr(Campo.CodUsuAgr).ToString
        objEnc.NombreUsuarioAgrega = iDr(Campo.NomUsuAgr).ToString
        objEnc.FechaAgrega = CType(iDr(Campo.FechaAgr), DateTime)
        objEnc.CodigoUsuarioModifica = iDr(Campo.CodUsuMod).ToString
        objEnc.NombreUsuarioModifica = iDr(Campo.NomUsuMod).ToString
        objEnc.FechaModifica = CType(iDr(Campo.FechaMod), DateTime)
        'especial
        objEnc.CampoCursor = iDr(Campo.ClaVou).ToString
        Return objEnc
        '\\
    End Function

    Function SpAutogenerarVoucher(ByRef ent As SuperEntidad) As String
        '//
        Dim codigo As String = ""
        Try

            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpAutogenerarVoucher")
            Sql.AsignarParametro(Par.CodigoEmpresa, ent.CodigoEmpresa)
            Sql.AsignarParametro(Par.AnoVoucher, ent.AnoVoucher)
            Sql.AsignarParametro(Par.CodigoFile, ent.CodigoFile)
            Sql.AsignarParametro(Par.CodigoMes, ent.CodigoMes)
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

    Sub SpNuevoVoucher(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpNuevoVoucher")
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

    Sub NuevoVoucherMasivo(ByRef pLista As List(Of SuperEntidad))
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpNuevoVoucher")
            For Each xVou As SuperEntidad In pLista
                xVou.CodigoUsuarioAgrega = SuperEntidad.xCodigoUsuario
                xVou.NombreUsuarioAgrega = SuperEntidad.xNombreUsuario
                xVou.CodigoUsuarioModifica = SuperEntidad.xCodigoUsuario
                xVou.NombreUsuarioModifica = SuperEntidad.xNombreUsuario
                '/Asignar Parametros
                Me.SetParametros(xVou)
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

    Sub SpModificarVoucher(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpModificarVoucher")
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

    Sub SpEliminarVoucher(ByRef ent As SuperEntidad)
        '//
        Try
            Sql.Conectar(SqlDatos.Bd.ContabilidadEmma)
            Sql.ComandoProcAlm("SpEliminarVoucher")
            '/Asignar Parametro
            Sql.AsignarParametro(Par.ClaveVoucher, ent.ClaveVoucher)
            '/Ejecutar sin resultado
            Sql.EjecutarSinResultado()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Sql.Desconectar()
        End Try
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
End Class
