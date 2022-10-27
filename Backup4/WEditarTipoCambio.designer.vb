<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WEditarTipoCambio
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker
        Me.lblFecha = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtCom = New System.Windows.Forms.TextBox
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.txtVen = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtVenE = New System.Windows.Forms.TextBox
        Me.TxtComE = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtDolEur = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(99, 30)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(113, 20)
        Me.dtpFecha.TabIndex = 0
        Me.dtpFecha.Tag = "0"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.ForeColor = System.Drawing.SystemColors.Desktop
        Me.lblFecha.Location = New System.Drawing.Point(78, 9)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(154, 13)
        Me.lblFecha.TabIndex = 50
        Me.lblFecha.Tag = "1"
        Me.lblFecha.Text = "30 De Setiembre del 2010"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(23, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Fecha:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(23, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Compra"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(23, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Venta"
        '
        'txtCom
        '
        Me.txtCom.BackColor = System.Drawing.Color.White
        Me.txtCom.Location = New System.Drawing.Point(99, 90)
        Me.txtCom.Name = "txtCom"
        Me.txtCom.Size = New System.Drawing.Size(113, 20)
        Me.txtCom.TabIndex = 1
        Me.txtCom.Tag = "2"
        Me.txtCom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.Presentacion.My.Resources.Resources.apply
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(98, 303)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(87, 23)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Tag = "7"
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Presentacion.My.Resources.Resources.action_stop
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(184, 303)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(85, 23)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Tag = "8"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'txtVen
        '
        Me.txtVen.BackColor = System.Drawing.Color.White
        Me.txtVen.Location = New System.Drawing.Point(99, 120)
        Me.txtVen.Name = "txtVen"
        Me.txtVen.Size = New System.Drawing.Size(113, 20)
        Me.txtVen.TabIndex = 2
        Me.txtVen.Tag = "3"
        Me.txtVen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(127, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "US$"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(127, 150)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "CAD"
        '
        'TxtVenE
        '
        Me.TxtVenE.BackColor = System.Drawing.Color.White
        Me.TxtVenE.Location = New System.Drawing.Point(99, 205)
        Me.TxtVenE.Name = "TxtVenE"
        Me.TxtVenE.Size = New System.Drawing.Size(113, 20)
        Me.TxtVenE.TabIndex = 4
        Me.TxtVenE.Tag = "5"
        Me.TxtVenE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtComE
        '
        Me.TxtComE.BackColor = System.Drawing.Color.White
        Me.TxtComE.Location = New System.Drawing.Point(99, 175)
        Me.TxtComE.Name = "TxtComE"
        Me.TxtComE.Size = New System.Drawing.Size(113, 20)
        Me.TxtComE.TabIndex = 3
        Me.TxtComE.Tag = "4"
        Me.TxtComE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(23, 208)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 55
        Me.Label6.Text = "Venta"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(23, 178)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 54
        Me.Label7.Text = "Compra"
        '
        'txtDolEur
        '
        Me.txtDolEur.BackColor = System.Drawing.Color.White
        Me.txtDolEur.Location = New System.Drawing.Point(99, 266)
        Me.txtDolEur.Name = "txtDolEur"
        Me.txtDolEur.Size = New System.Drawing.Size(113, 20)
        Me.txtDolEur.TabIndex = 5
        Me.txtDolEur.Tag = "6"
        Me.txtDolEur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(23, 269)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 13)
        Me.Label8.TabIndex = 58
        Me.Label8.Text = "Dolar-Euro"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(112, 250)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 13)
        Me.Label10.TabIndex = 59
        Me.Label10.Text = "US$----EUR"
        '
        'WEditarTipoCambio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(328, 344)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtDolEur)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtVenE)
        Me.Controls.Add(Me.TxtComE)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtVen)
        Me.Controls.Add(Me.txtCom)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.dtpFecha)
        Me.MaximizeBox = False
        Me.Name = "WEditarTipoCambio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WEditarTipoCambio"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

      Function ListaControles() As List(Of CtrlsEdit)
            Dim lis As New List(Of CtrlsEdit)
            Dim item As CtrlsEdit

            'txtCod
            item = New CtrlsEdit
            item.Control = Me.dtpFecha
            item.PasaFoco = "1"
            item.Formato = "0"
            item.PasarCursor = "1"
            item.Limpiar = "1"
            item.DatoLimpiar = "Today"
            item.Campo = "Fecha"
            item.Obligatorio = "0"
            item.Teclazo = Validar.Tecla.kNada
            item.Valida = Validar.texto.vNada
            item.Nuevo = "1"
            item.Modificar = "0"
            item.Eliminar = "0"
            item.Visualizar = "0"
            lis.Add(item)

            'txtCod
            item = New CtrlsEdit
            item.Control = Me.lblFecha
            item.PasaFoco = "0"
            item.Formato = "0"
            item.PasarCursor = "0"
            item.Limpiar = "1"
            item.DatoLimpiar = ""
            item.Campo = ""
            item.Obligatorio = "0"
            item.Teclazo = Validar.Tecla.kNada
            item.Valida = Validar.texto.vNada
            item.Nuevo = "0"
            item.Modificar = "0"
            item.Eliminar = "0"
            item.Visualizar = "0"
            lis.Add(item)

            'txtCod
            item = New CtrlsEdit
            item.Control = Me.txtCom
            item.PasaFoco = "1"
            item.Formato = "1"
            item.PasarCursor = "1"
            item.Limpiar = "1"
            item.DatoLimpiar = "0.000"
            item.Campo = "Compra s"
            item.Obligatorio = "1"
            item.Teclazo = Validar.Tecla.kDecimal
            item.Valida = Validar.texto.vSolonumerosConTresDecimales
            item.Nuevo = "1"
            item.Modificar = "1"
            item.Eliminar = "0"
            item.Visualizar = "0"
            lis.Add(item)


            'txtCod
            item = New CtrlsEdit
            item.Control = Me.txtVen
            item.PasaFoco = "1"
            item.Formato = "1"
            item.PasarCursor = "1"
            item.Limpiar = "1"
            item.DatoLimpiar = "0.000"
            item.Campo = "Venta s"
            item.Obligatorio = "1"
            item.Teclazo = Validar.Tecla.kDecimal
            item.Valida = Validar.texto.vSolonumerosConTresDecimales
            item.Nuevo = "1"
            item.Modificar = "1"
            item.Eliminar = "0"
            item.Visualizar = "0"
            lis.Add(item)

            item = New CtrlsEdit
            item.Control = Me.TxtComE
            item.PasaFoco = "1"
            item.Formato = "1"
            item.PasarCursor = "1"
            item.Limpiar = "1"
            item.DatoLimpiar = "0.000"
            item.Campo = "Compra eur"
            item.Obligatorio = "1"
            item.Teclazo = Validar.Tecla.kDecimal
            item.Valida = Validar.texto.vSolonumerosConTresDecimales
            item.Nuevo = "1"
            item.Modificar = "1"
            item.Eliminar = "0"
            item.Visualizar = "0"
            lis.Add(item)

            'txtCod
            item = New CtrlsEdit
            item.Control = Me.TxtVenE
            item.PasaFoco = "1"
            item.Formato = "1"
            item.PasarCursor = "1"
            item.Limpiar = "1"
            item.DatoLimpiar = "0.000"
            item.Campo = "Venta eur"
            item.Obligatorio = "1"
            item.Teclazo = Validar.Tecla.kDecimal
            item.Valida = Validar.texto.vSolonumerosConTresDecimales
            item.Nuevo = "1"
            item.Modificar = "1"
            item.Eliminar = "0"
            item.Visualizar = "0"
            lis.Add(item)

            item = New CtrlsEdit
            item.Control = Me.txtDolEur
            item.PasaFoco = "1"
            item.Formato = "1"
            item.PasarCursor = "1"
            item.Limpiar = "1"
            item.DatoLimpiar = "0.000"
            item.Campo = "Dolar-Euro"
            item.Obligatorio = "1"
            item.Teclazo = Validar.Tecla.kDecimal
            item.Valida = Validar.texto.vSolonumerosConTresDecimales
            item.Nuevo = "1"
            item.Modificar = "1"
            item.Eliminar = "0"
            item.Visualizar = "0"
            lis.Add(item)


            'txtbtnAceptar
            item = New CtrlsEdit
            item.Control = Me.btnAceptar
            item.PasaFoco = "1"
            item.Formato = "0"
            item.PasarCursor = "1"
            item.Limpiar = "0"
            item.DatoLimpiar = ""
            item.Campo = "Aceptar"
            item.Obligatorio = "0"
            item.Teclazo = Validar.Tecla.kNada
            item.Valida = Validar.texto.vNada
            item.Nuevo = "1"
            item.Modificar = "1"
            item.Eliminar = "1"
            item.Visualizar = "0"
            lis.Add(item)

            Return lis

      End Function

      Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
      Friend WithEvents lblFecha As System.Windows.Forms.Label
      Friend WithEvents Label2 As System.Windows.Forms.Label
      Friend WithEvents Label3 As System.Windows.Forms.Label
      Friend WithEvents Label4 As System.Windows.Forms.Label
      Friend WithEvents txtCom As System.Windows.Forms.TextBox
      Friend WithEvents btnAceptar As System.Windows.Forms.Button
      Friend WithEvents btnCancelar As System.Windows.Forms.Button
      Friend WithEvents txtVen As System.Windows.Forms.TextBox
      Friend WithEvents Label1 As System.Windows.Forms.Label
      Friend WithEvents Label5 As System.Windows.Forms.Label
      Friend WithEvents TxtVenE As System.Windows.Forms.TextBox
      Friend WithEvents TxtComE As System.Windows.Forms.TextBox
      Friend WithEvents Label6 As System.Windows.Forms.Label
      Friend WithEvents Label7 As System.Windows.Forms.Label
      Friend WithEvents txtDolEur As System.Windows.Forms.TextBox
      Friend WithEvents Label8 As System.Windows.Forms.Label
      Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
