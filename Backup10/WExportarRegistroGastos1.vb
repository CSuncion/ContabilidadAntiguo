Option Explicit On
Option Strict On
Imports Entidad
Imports Negocio
Imports System
Imports System.IO
Imports System.Threading

Public Class WExportarRegistroGastos1

    Public lista, listaD As New List(Of SuperEntidad)
    Public rc As New RegContabCabeRN
    Public rcd As New RegContabDetaRN
    Public cam As New CamposEntidad
    Public ent, entD As New SuperEntidad
    Dim numReg As Integer = 0

#Region "Metodos"

    Sub NuevaVentana()
        '//
        Me.Show()
        '\\
    End Sub

    Sub CabeRegCompras()
        '//
        '/Refrescando el DataSource de DgvUsu
        ent.DatoCondicion1 = "3"
        ent.Desde = Me.dtpDesde.Value.Date
        ent.Hasta = Me.dtpHasta.Value.Date
        ent.CampoOrden = cam.ClaveRCC 'cam.CodFilRC + "," + cam.DiaVouRC

        lista = rc.obtenerRegContabEntreFechas(ent)
        '  numReg = lista.Count
        Dgv.refrescarFuenteDatosGrilla(Me.DgvRegContabCabe, lista)
        '/Creando las columnas
        Dgv.asignarColumnaTextExp(Me.DgvRegContabCabe, cam.ClaveRCC, "Clave", 16)
        Dgv.asignarColumnaTextExp(Me.DgvRegContabCabe, cam.PeriodoRCC, "Periodo", 6)
        Dgv.asignarColumnaTextExp(Me.DgvRegContabCabe, cam.CodOriRC, "Origen", 1)
        Dgv.asignarColumnaTextExp(Me.DgvRegContabCabe, cam.CodFilRC, "File", 4)
        Dgv.asignarColumnaTextExp(Me.DgvRegContabCabe, cam.NumVouRCC, "Numero Vaucher", 6)
        Dgv.asignarColumnaTextExp(Me.DgvRegContabCabe, cam.DiaVouRCC, "Dia Voucher", 2)
        Dgv.asignarColumnaTextExp(Me.DgvRegContabCabe, cam.FecVouRCC, "Fecha Voucher", 10)
        Dgv.asignarColumnaTextExp(Me.DgvRegContabCabe, cam.GlosaRCC, "Glosa", 45)
        Dgv.asignarColumnaTextExp(Me.DgvRegContabCabe, cam.IgvPar, "ValorIgv", 8)
        '//
    End Sub

#End Region

    Sub hilo2()
        Me.tslEstadoExp.Text = "Esperar..."
    End Sub
    Sub hilo1()
        Me.CabeRegCompras()
        'Dim var As String = ""
        ''preguntar si ya se exporto o no
        'Dim numExp As Integer = 0
        'Dim numCom As Integer = 0
        'For Each obj As SuperEntidad In Me.lista
        '      If obj.CodigoOrigen = "3" And obj.CodigoFile <> "302" Then
        '            numCom = numCom + 1
        '            If obj.Exporta = "1" Then
        '                  numExp = numExp + 1
        '            End If
        '      End If
        'Next


        'If numCom = numExp Then
        '      Dim rpta As Integer = MsgBox("Estos Registros Gastos ya se exportaron/Desea Reemplazarlas", MsgBoxStyle.YesNo)
        '      If rpta = MsgBoxResult.Yes Then
        '            var = "si"
        '      Else
        '            var = "no"
        '            Exit Sub
        '      End If

        'End If





        '        Const DELIMITADOR As String = ";"
        Dim tamaño As Integer
        ' ruta del fichero de texto
        Const ARCHIVO_CSV As String = "c:\Gestion\Gastos.txt"

        Try
            'Nuevo objeto StreamWriter, para acceder al fichero y poder guardar las líneas
            Using archivo As StreamWriter = New StreamWriter(ARCHIVO_CSV)

                ' variable para almacenar la línea actual del dataview
                Dim linea As String = String.Empty

                With Me.DgvRegContabCabe
                    ' Recorrer las filas del dataGridView
                    For fila As Integer = 0 To .RowCount - 1

                        If .Item(2, fila).Value.ToString.Trim = "3" And .Item(3, fila).Value.ToString.Trim <> "302" Then

                            numReg += 1
                            'If var = "si" Then

                            ' vaciar la línea
                            linea = String.Empty
                            linea = "C"

                            ' Recorrer la cantidad de columnas que contiene el dataGridView
                            For col As Integer = 0 To .Columns.Count - 1
                                If .Columns(col).Visible = True Then
                                    'Obtener la el tamaño de la columna
                                    tamaño = .Columns(col).DividerWidth
                                    '  MsgBox(tamaño.ToString)
                                    ' Almacenar el valor de toda la fila , y cada campo separado por el delimitador
                                    Dim valorItem As String = .Item(col, fila).Value.ToString.Trim
                                    'Dim tamItem As Integer = valorItem.Length

                                    'falta chekear
                                    If valorItem.Length > tamaño Then
                                        Dim str As String = valorItem.Substring(0, tamaño)
                                        linea = linea & str
                                    Else
                                        linea = linea & valorItem.PadRight(tamaño, CType(" ", Char))
                                    End If
                                End If

                            Next

                            ' Escribir una línea con el método WriteLine
                            With archivo
                                ' escribir la fila
                                .WriteLine(linea.ToString)


                            End With

                            'Actualizar RegCompras



                            'Cargamos el detalle de cada linea abecera

                            entD.DatoCondicion1 = Me.DgvRegContabCabe.Item(0, fila).Value.ToString.Trim
                            listaD = rcd.obtenerDetalleRegContabPorClave(entD)
                            Dgv.refrescarFuenteDatosGrilla(Me.DgvRegContabDeta, listaD)

                            Dgv.asignarColumnaTextExp(Me.DgvRegContabDeta, cam.Cuen, "Cuenta Rc", 8)
                            'Dgv.asignarColumnaTextExp(Me.DgvRegContabDeta, cam.CodPptoInt, "Codigo Ppto", 20)
                            Dgv.asignarColumnaTextExp(Me.DgvRegContabDeta, cam.Titulo, "Concepto", 4)
                            Dgv.asignarColumnaTextExp(Me.DgvRegContabDeta, cam.CodInt, "Cargo/Partida", 6)
                            Dgv.asignarColumnaTextExp(Me.DgvRegContabDeta, cam.DebHabRCD, "Debe Rc", 5)
                            Dgv.asignarColumnaTextExp(Me.DgvRegContabDeta, cam.ImpSRCD, "ImporteS Rc", 12)
                            Dgv.asignarColumnaTextExp(Me.DgvRegContabDeta, cam.ImpDRCD, "ImporteD Rc", 12)
                            Dgv.asignarColumnaTextExp(Me.DgvRegContabDeta, cam.CodAux, "Cliente/Proveedor", 11)
                            Dgv.asignarColumnaTextExp(Me.DgvRegContabDeta, cam.CodTipDoc, "Documento", 2)
                            Dgv.asignarColumnaTextExp(Me.DgvRegContabDeta, cam.SerDoC, "Serie", 4)
                            Dgv.asignarColumnaTextExp(Me.DgvRegContabDeta, cam.NumDoc, "Numero", 15)
                            Dgv.asignarColumnaTextExp(Me.DgvRegContabDeta, cam.FecDoc, "Fecha Documento", 10)
                            Dgv.asignarColumnaTextExp(Me.DgvRegContabDeta, cam.VenTipCam, "Tipo Cambio", 6)
                            Dgv.asignarColumnaTextExp(Me.DgvRegContabDeta, cam.GlosaRCD, "Glosa Rc", 40)
                            Dgv.asignarColumnaTextExp(Me.DgvRegContabDeta, cam.IgvPar, "ValorIgv", 8)
                            Dgv.asignarColumnaTextExp(Me.DgvRegContabDeta, cam.CodAre, "CodigoArea", 4)
                            Dgv.asignarColumnaTextExp(Me.DgvRegContabDeta, cam.CodIngEgr, "Ingreso/Egreso", 3)

                            For filaD As Integer = 0 To Me.DgvRegContabDeta.RowCount - 1
                                linea = String.Empty
                                linea = "D"

                                ' Recorrer la cantidad de columnas que contiene el dataGridView
                                For cold As Integer = 0 To Me.DgvRegContabDeta.Columns.Count - 1
                                    'Obtener la el tamaño de la columna
                                    tamaño = Me.DgvRegContabDeta.Columns(cold).DividerWidth
                                    ' Almacenar el valor de toda la fila , y cada campo separado por el delimitador
                                    Dim valorItem As String = Me.DgvRegContabDeta.Item(cold, filaD).Value.ToString.Trim
                                    'Dim tamItem As Integer = valorItem.Length

                                    'falta chekear
                                    If valorItem.Length > tamaño Then
                                        Dim str As String = valorItem.Substring(0, tamaño)
                                        linea = linea & str
                                    Else
                                        linea = linea & valorItem.PadRight(tamaño, CType(" ", Char))
                                    End If
                                Next

                                With archivo
                                    ' eliminar el último caracter ";" de la cadena
                                    ' linea = linea.Remove(linea.Length - 1).ToString
                                    ' escribir la fila
                                    .WriteLine(linea.ToString)
                                End With


                            Next

                            'End If

                            'If var = "" Then
                            '      ' vaciar la línea

                            '      If lista.Item(fila).Exporta = "0" Then
                            '            linea = String.Empty
                            '            linea = "C"

                            '            ' Recorrer la cantidad de columnas que contiene el dataGridView
                            '            For col As Integer = 0 To .Columns.Count - 1
                            '                  'Obtener la el tamaño de la columna
                            '                  tamaño = .Columns(col).DividerWidth
                            '                  '  MsgBox(tamaño.ToString)
                            '                  ' Almacenar el valor de toda la fila , y cada campo separado por el delimitador
                            '                  Dim valorItem As String = .Item(col, fila).Value.ToString.Trim
                            '                  'Dim tamItem As Integer = valorItem.Length

                            '                  'falta chekear
                            '                  If valorItem.Length > tamaño Then
                            '                        Dim str As String = valorItem.Substring(0, tamaño)
                            '                        linea = linea & str
                            '                  Else
                            '                        linea = linea & valorItem.PadRight(tamaño, CType(" ", Char))
                            '                  End If
                            '            Next



                            '            ' Escribir una línea con el método WriteLine
                            '            With archivo
                            '                  ' eliminar el último caracter ";" de la cadena
                            '                  '   linea = linea.Remove(linea.Length - 1).ToString
                            '                  ' escribir la fila
                            '                  .WriteLine(linea.ToString)


                            '            End With

                            '            'Actualizar RegCompras campo Exporta

                            '            ent.DatoCondicion1 = lista.Item(fila).ClaveRegContab
                            '            ent = rc.buscarRegContabExisPorClave(ent)
                            '            ent.Exporta = "1"
                            '            rc.modificarRegContab(ent)

                            '            'Cargamos el detalle de cada linea abecera

                            '            entD.DatoCondicion1 = Me.DgvRegContabCabe.Item(0, fila).Value.ToString.Trim
                            '            listaD = rcd.obtenerDetalleRegContabPorClave(entD)
                            '            Dgv.refrescarFuenteDatosGrilla(Me.DgvRegContabDeta, listaD)
                            '            Dgv.asignarColumnaTextExp(Me.DgvRegContabDeta, cam.CuenRC, "Cuenta Rc", 8)
                            '            Dgv.asignarColumnaTextExp(Me.DgvRegContabDeta, cam.CodPptoInt, "Codigo Ppto", 20)
                            '            Dgv.asignarColumnaTextExp(Me.DgvRegContabDeta, cam.Titulo, "Concepto", 4)
                            '            Dgv.asignarColumnaTextExp(Me.DgvRegContabDeta, cam.CodInt, "Cargo/Partida", 6)
                            '            Dgv.asignarColumnaTextExp(Me.DgvRegContabDeta, cam.DebHabRC, "Debe Rc", 5)
                            '            Dgv.asignarColumnaTextExp(Me.DgvRegContabDeta, cam.ImpSRC, "ImporteS Rc", 12)
                            '            Dgv.asignarColumnaTextExp(Me.DgvRegContabDeta, cam.ImpDRC, "ImporteD Rc", 12)
                            '            Dgv.asignarColumnaTextExp(Me.DgvRegContabDeta, cam.CodAux, "Cliente/Proveedor", 11)
                            '            Dgv.asignarColumnaTextExp(Me.DgvRegContabDeta, cam.TipDocRC, "Documento", 2)
                            '            Dgv.asignarColumnaTextExp(Me.DgvRegContabDeta, cam.SerDocRC, "Serie", 4)
                            '            Dgv.asignarColumnaTextExp(Me.DgvRegContabDeta, cam.NumDocRC, "Numero", 15)
                            '            Dgv.asignarColumnaTextExp(Me.DgvRegContabDeta, cam.FechDocRegCom, "Fecha Documento", 10)
                            '            Dgv.asignarColumnaTextExp(Me.DgvRegContabDeta, cam.VenTipCam, "Tipo Cambio", 6)
                            '            Dgv.asignarColumnaTextExp(Me.DgvRegContabDeta, cam.GlosaRC, "Glosa Rc", 45)
                            '            Dgv.asignarColumnaTextExp(Me.DgvRegContabDeta, cam.ImpCheRC, "ValorIgv", 8)
                            '            Dgv.asignarColumnaTextExp(Me.DgvRegContabDeta, cam.CodAre, "CodigoArea", 4)
                            '            Dgv.asignarColumnaTextExp(Me.DgvRegContabDeta, cam.CodIngEgr, "Ingreso/Egreso", 3)
                            '            For filaD As Integer = 0 To Me.DgvRegContabDeta.RowCount - 1
                            '                  linea = String.Empty
                            '                  linea = "D"

                            '                  ' Recorrer la cantidad de columnas que contiene el dataGridView
                            '                  For cold As Integer = 0 To Me.DgvRegContabDeta.Columns.Count - 1
                            '                        'Obtener la el tamaño de la columna
                            '                        tamaño = Me.DgvRegContabDeta.Columns(cold).DividerWidth
                            '                        ' Almacenar el valor de toda la fila , y cada campo separado por el delimitador
                            '                        Dim valorItem As String = Me.DgvRegContabDeta.Item(cold, filaD).Value.ToString.Trim
                            '                        'Dim tamItem As Integer = valorItem.Length

                            '                        'falta chekear
                            '                        If valorItem.Length > tamaño Then
                            '                              Dim str As String = valorItem.Substring(0, tamaño)
                            '                              linea = linea & str
                            '                        Else
                            '                              linea = linea & valorItem.PadRight(tamaño, CType(" ", Char))
                            '                        End If
                            '                  Next

                            '                  With archivo
                            '                        ' eliminar el último caracter ";" de la cadena
                            '                        '   linea = linea.Remove(linea.Length - 1).ToString
                            '                        ' escribir la fila
                            '                        .WriteLine(linea.ToString)
                            '                  End With


                            '            Next
                            '      End If

                            'End If



                            ' MsgBox(listaD.Count)
                            'preguntamos si la lista no esta vacia

                        End If

                    Next
                End With

            End Using

            ' Abrir con Process.Start el archivo de texto
            'Process.Start(ARCHIVO_CSV)
            MsgBox("La exportacion se realizo Exitosamente/Ubicacion archivo:C:\Gestion\Gastos", MsgBoxStyle.Information)
            Me.tslEstadoExp.Text = "Se exportaron " + numReg.ToString + " Registros"
            'error
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim mih1, mih2 As thread
        mih1 = New Thread(AddressOf hilo1)
        mih2 = New Thread(AddressOf hilo2)

        mih1.Start()
        mih2.Start()

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class