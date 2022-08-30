Imports Entidad
Imports Negocio

Public Class WEstornarIngEgr

      Public acc As New Accion
      Public lista, lD As New List(Of SuperEntidad)
      Public rc As New RegContabCabeRN
      Public rcd As New RegContabDetaRN
      Public cc As New CuentaCorrienteRN
      Public emp As New EmpresaRN
      Public ent, entD As New SuperEntidad
      Public cam As New CamposEntidad
      Public par As New ParametroRN
      Public titulo As String
      Public periodo As String

#Region "Metodos"

      Sub InizializaVentana()
            acc.listaCtrls = Me.ListaControles
            acc.PasaFoco()
            acc.FomatoDato()
            acc.PasarCursor()
            acc.Teclazo()
            acc.Valida()
            Me.Show()
      End Sub

      Sub NuevaVentana()
            '//
            Me.InizializaVentana()
            ent.CampoOrden = cam.ClaveRCC
            ent.ColumnaBusqueda = "Clave"
        'Me.ActualizarVentana()
            Me.txtCodAux.Focus()
            '\\
      End Sub

    Sub ActualizarVentana()
        '//
        'actualizar dgvCabe
        Me.ActualizarDgvCabe()


        ''actualizar dgvDeta
        Me.ActualizarDgvDeta()
        'Me.ActualizarDgvDeta()
        Dgv.pintarColumnaDgv(Me.DgvCabe, ent.CampoOrden)
        'Me.permisoVentana()     ''OJO FALTA VER COMO FUNCIONA
        '\\
    End Sub

    Sub ActualizarDgvCabe()
        '//
        '/Refrescando el DataSource de DgvUsu
        ent.PeriodoRegContabCabe = SuperEntidad.xPeriodoEmpresa
        ent.CodigoEmpresa = SuperEntidad.xCodigoEmpresa
        ent.CodigoAuxiliar = Me.txtCodAux.Text.Trim
        If ent.CodigoAuxiliar = "" Then
            lista.Clear()
        Else
            lista = rc.ListarIngresosyEgresosXPeriodoYEmpresaYAuxiliar(ent)
        End If

        Dgv.refrescarFuenteDatosGrilla(Me.DgvCabe, lista)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvCabe, cam.ClaveRCC, "Clave", 125)
        Dgv.asignarColumnaText(Me.DgvCabe, cam.NomOriRC, "Origen", 100)
        Dgv.asignarColumnaText(Me.DgvCabe, cam.NomFilRC, "File", 130)
        Dgv.asignarColumnaText(Me.DgvCabe, cam.PeriodoRCC, "Periodo", 100)
        Dgv.asignarColumnaText(Me.DgvCabe, cam.CodEmp, "Empresa", 100)
        Dgv.asignarColumnaText(Me.DgvCabe, cam.NumVouRCC, "Numero Voucher", 120)
        Dgv.asignarColumnaText(Me.DgvCabe, cam.FecVouRCC, "Fecha Voucher", 120)
        Dgv.asignarColumnaText(Me.DgvCabe, cam.DesAux, "Proveedor", 250)
        Dgv.asignarColumnaText(Me.DgvCabe, cam.ImpRCC, "Importe", 100)
        '//
    End Sub

      Sub ActualizarDgvDeta()
            '/
        entD.ClaveRegContabCabe = Dgv.obtenerValorCelda(Me.DgvCabe, cam.ClaveRCC)
        'If entD.ClaveRegContabCabe = String.Empty Then
        '    Exit Sub
        'End If
        lD = rcd.obtenerDetalleRegContabPorClave(entD)
        ' MsgBox(listaD.Count)
        'preguntamos si la lista no esta vacia
        Dgv.refrescarFuenteDatosGrilla(Me.DgvDeta, lD)
        '/Creando las columnas
        Dgv.asignarColumnaText(Me.DgvDeta, cam.ClaveRCD, "Clave", 140)
        Dgv.asignarColumnaText(Me.DgvDeta, cam.CodCtaPcge, "Cuenta", 90)
        Dgv.asignarColumnaText(Me.DgvDeta, cam.NomCtaPcge, "Nombre Cuenta", 130)
        Dgv.asignarColumnaText(Me.DgvDeta, cam.DesAux, "Proveedor", 250)
        Dgv.asignarColumnaText(Me.DgvDeta, cam.CodTipDoc, "Tipo Dcto", 80)
        Dgv.asignarColumnaText(Me.DgvDeta, cam.NomTipDoc, "Nombre Dcto", 120)
        Dgv.asignarColumnaText(Me.DgvDeta, cam.SerDoC, "Serie", 80)
        Dgv.asignarColumnaText(Me.DgvDeta, cam.NumDoc, "Numero Dcto", 120)
        Dgv.asignarColumnaText(Me.DgvDeta, cam.DebHabRCD, "Debe/Haber", 95)
        Dgv.AsignarColumnaTextNumerico(Me.DgvDeta, cam.ImpSRCD, "ImporteSoles", 100, 2)
        Dgv.AsignarColumnaTextNumerico(Me.DgvDeta, cam.ImpDRCD, "ImporteDolares", 100, 2)
    End Sub

      Function EsEstornable() As Boolean

      End Function

      Sub ModificarCuentaCorriente()
            Dim lisRcd As New List(Of SuperEntidad)
            Dim regDet, cueCorr As New SuperEntidad
            regDet.ClaveRegContabCabe = Dgv.obtenerValorCelda(Me.DgvCabe, cam.ClaveRCC)
            lisRcd = rcd.obtenerDetalleRegContabPorClave(regDet)
            For n As Integer = 0 To lisRcd.Count - 1
                  regDet = lisRcd.Item(n)
                  cueCorr.ClaveDocumentoCuentaCorriente = regDet.CodigoEmpresa + regDet.CodigoAuxiliar + regDet.TipoDocumento + regDet.SerieDocumento + regDet.NumeroDocumento
                  cueCorr = cc.buscarCuentaCorrienteExisPorClaveDoc(cueCorr)
                  If cueCorr.ClaveDocumentoCuentaCorriente <> "" Then
                        Select Case cueCorr.MonedaDocumento
                              Case "S/."
                                    cueCorr.ImportePagadoCuentaCorriente = cueCorr.ImportePagadoCuentaCorriente - regDet.ImporteSRegContabDeta
                                    cueCorr.SaldoCuentaCorriente = cueCorr.SaldoCuentaCorriente + regDet.ImporteSRegContabDeta
                              Case "US$"
                                    cueCorr.ImportePagadoCuentaCorriente = cueCorr.ImportePagadoCuentaCorriente - regDet.ImporteDRegContabDeta
                                    cueCorr.SaldoCuentaCorriente = cueCorr.SaldoCuentaCorriente + regDet.ImporteDRegContabDeta
                              Case "EUR"
                                    cueCorr.ImportePagadoCuentaCorriente = cueCorr.ImportePagadoCuentaCorriente - regDet.ImporteERegContabDeta
                                    cueCorr.SaldoCuentaCorriente = cueCorr.SaldoCuentaCorriente + regDet.ImporteERegContabDeta
                        End Select
                        cueCorr.EstadoCuentaCorriente = "1"
                        cc.modificarCuentaCorriente(cueCorr)
                  End If
            Next
      End Sub

      Sub EliminarDetalleRegistroContable()
            Dim regdet As New SuperEntidad
            regdet.ClaveRegContabCabe = Dgv.obtenerValorCelda(Me.DgvCabe, cam.ClaveRCC)
            rcd.eliminarRegContabDeta(regdet)
      End Sub

      Sub EliminarCabeceraRegistroContable()
            Dim regCab As New SuperEntidad
            regCab.ClaveRegContabCabe = Dgv.obtenerValorCelda(Me.DgvCabe, cam.ClaveRCC)
            rc.eliminarRegContabFis(regCab)
      End Sub

    Sub Estornar()

        If Me.DgvCabe.Rows.Count = 0 Then
            MsgBox("No hay documentos a estornar")
            Exit Sub
        End If

        'PREGUNTAR SI DESEA REALIZAR LA OPERACION DE ESTORNO
        Dim rpta As Integer = MsgBox("Deseas realizar la operacion", MsgBoxStyle.YesNo, "Estornar")
        If rpta = MsgBoxResult.Yes Then
            Me.ModificarCuentaCorriente()
            Me.EliminarDetalleRegistroContable()
            Me.EliminarCabeceraRegistroContable()
            MsgBox("El estorno se realizo con exito", MsgBoxStyle.Information, "Estornar")
            Me.ActualizarVentana()
        Else
            Exit Sub
        End If
    End Sub

#End Region

#Region "Mostrar Form Lista"

    Private Sub txtCodAux_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCodAux.KeyDown
        If Me.txtCodAux.ReadOnly = False Then
            If e.KeyCode = Keys.F1 Then
                Dim win As New WListarAuxiliar
                win.wExtorno = Me
                Me.AddOwnedForm(win)
                win.tabla = "Todos"
                win.titulo = "Auxiliares"
                win.txt1 = Me.txtCodAux
                win.txt2 = Me.txtNomAux
                win.ctrlFoco = Me.DgvCabe
                win.NuevaVentana()
            End If
        End If
    End Sub

     

#End Region

#Region "Buscar Por Codigo"

      Private Sub txtCodAux_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodAux.Validated
            Me.ActualizarVentana()
      End Sub

      Private Sub txtCodAux_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCodAux.Validating
            Dim ope As New OperaWin : ope.txt1 = Me.txtCodAux : ope.txt2 = Me.txtNomAux
            ope.MostrarCodigoDescripcionDeAuxiliar("Auxiliar", "Auxiliar", e)
      End Sub

#End Region


      Private Sub DgvCabe_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgvCabe.CellEnter
            Me.ActualizarDgvDeta()
      End Sub

      Private Sub btnEstornar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEstornar.Click
            Me.Estornar()
      End Sub

      Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
            Me.Close()
      End Sub
End Class