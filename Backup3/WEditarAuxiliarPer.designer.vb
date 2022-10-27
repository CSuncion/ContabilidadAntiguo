<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WEditarAuxiliarPer
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.gbEstado = New System.Windows.Forms.GroupBox
        Me.RbtInactivo = New System.Windows.Forms.RadioButton
        Me.RbtActivo = New System.Windows.Forms.RadioButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.txtRefAux = New System.Windows.Forms.TextBox
        Me.txtCorAux = New System.Windows.Forms.TextBox
        Me.txtCelAux = New System.Windows.Forms.TextBox
        Me.txtTelAux = New System.Windows.Forms.TextBox
        Me.txtDirAux = New System.Windows.Forms.TextBox
        Me.txtNomAux = New System.Windows.Forms.TextBox
        Me.txtCodAux = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtApePatAux = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtApeMatAux = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TxtSegNomAux = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TxtPriNomAux = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.TxtTipDocIde = New System.Windows.Forms.TextBox
        Me.TxtNomDocIde = New System.Windows.Forms.TextBox
        Me.DtpFechaInsSnpAux = New System.Windows.Forms.DateTimePicker
        Me.Label31 = New System.Windows.Forms.Label
        Me.gbEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbEstado
        '
        Me.gbEstado.Controls.Add(Me.RbtInactivo)
        Me.gbEstado.Controls.Add(Me.RbtActivo)
        Me.gbEstado.Location = New System.Drawing.Point(175, 295)
        Me.gbEstado.Name = "gbEstado"
        Me.gbEstado.Size = New System.Drawing.Size(133, 34)
        Me.gbEstado.TabIndex = 12
        Me.gbEstado.TabStop = False
        Me.gbEstado.Tag = "14"
        '
        'RbtInactivo
        '
        Me.RbtInactivo.AutoSize = True
        Me.RbtInactivo.Location = New System.Drawing.Point(69, 12)
        Me.RbtInactivo.Name = "RbtInactivo"
        Me.RbtInactivo.Size = New System.Drawing.Size(63, 17)
        Me.RbtInactivo.TabIndex = 101
        Me.RbtInactivo.Tag = "16"
        Me.RbtInactivo.Text = "Inactivo"
        Me.RbtInactivo.UseVisualStyleBackColor = True
        '
        'RbtActivo
        '
        Me.RbtActivo.AutoSize = True
        Me.RbtActivo.Location = New System.Drawing.Point(5, 12)
        Me.RbtActivo.Name = "RbtActivo"
        Me.RbtActivo.Size = New System.Drawing.Size(55, 17)
        Me.RbtActivo.TabIndex = 100
        Me.RbtActivo.Tag = "15"
        Me.RbtActivo.Text = "Activo"
        Me.RbtActivo.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(30, 309)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 119
        Me.Label4.Text = "Estado"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Presentacion.My.Resources.Resources.action_stop
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(468, 307)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(95, 23)
        Me.btnCancelar.TabIndex = 14
        Me.btnCancelar.Tag = "18"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.Presentacion.My.Resources.Resources.apply
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(371, 307)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(98, 23)
        Me.btnAceptar.TabIndex = 13
        Me.btnAceptar.Tag = "17"
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'txtRefAux
        '
        Me.txtRefAux.BackColor = System.Drawing.Color.White
        Me.txtRefAux.Location = New System.Drawing.Point(175, 195)
        Me.txtRefAux.MaxLength = 150
        Me.txtRefAux.Name = "txtRefAux"
        Me.txtRefAux.Size = New System.Drawing.Size(523, 20)
        Me.txtRefAux.TabIndex = 9
        Me.txtRefAux.Tag = "10"
        '
        'txtCorAux
        '
        Me.txtCorAux.BackColor = System.Drawing.Color.White
        Me.txtCorAux.Location = New System.Drawing.Point(175, 170)
        Me.txtCorAux.MaxLength = 40
        Me.txtCorAux.Name = "txtCorAux"
        Me.txtCorAux.Size = New System.Drawing.Size(523, 20)
        Me.txtCorAux.TabIndex = 8
        Me.txtCorAux.Tag = "9"
        '
        'txtCelAux
        '
        Me.txtCelAux.BackColor = System.Drawing.Color.White
        Me.txtCelAux.Location = New System.Drawing.Point(500, 145)
        Me.txtCelAux.MaxLength = 10
        Me.txtCelAux.Name = "txtCelAux"
        Me.txtCelAux.Size = New System.Drawing.Size(198, 20)
        Me.txtCelAux.TabIndex = 7
        Me.txtCelAux.Tag = "8"
        '
        'txtTelAux
        '
        Me.txtTelAux.BackColor = System.Drawing.Color.White
        Me.txtTelAux.Location = New System.Drawing.Point(175, 145)
        Me.txtTelAux.MaxLength = 7
        Me.txtTelAux.Name = "txtTelAux"
        Me.txtTelAux.Size = New System.Drawing.Size(200, 20)
        Me.txtTelAux.TabIndex = 6
        Me.txtTelAux.Tag = "7"
        '
        'txtDirAux
        '
        Me.txtDirAux.BackColor = System.Drawing.Color.White
        Me.txtDirAux.Location = New System.Drawing.Point(175, 120)
        Me.txtDirAux.MaxLength = 150
        Me.txtDirAux.Name = "txtDirAux"
        Me.txtDirAux.Size = New System.Drawing.Size(523, 20)
        Me.txtDirAux.TabIndex = 5
        Me.txtDirAux.Tag = "6"
        '
        'txtNomAux
        '
        Me.txtNomAux.BackColor = System.Drawing.SystemColors.Control
        Me.txtNomAux.ForeColor = System.Drawing.Color.Black
        Me.txtNomAux.Location = New System.Drawing.Point(175, 95)
        Me.txtNomAux.MaxLength = 150
        Me.txtNomAux.Name = "txtNomAux"
        Me.txtNomAux.ReadOnly = True
        Me.txtNomAux.Size = New System.Drawing.Size(525, 20)
        Me.txtNomAux.TabIndex = 100
        Me.txtNomAux.Tag = "5"
        '
        'txtCodAux
        '
        Me.txtCodAux.BackColor = System.Drawing.Color.White
        Me.txtCodAux.Location = New System.Drawing.Point(175, 20)
        Me.txtCodAux.MaxLength = 11
        Me.txtCodAux.Name = "txtCodAux"
        Me.txtCodAux.Size = New System.Drawing.Size(133, 20)
        Me.txtCodAux.TabIndex = 0
        Me.txtCodAux.Tag = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(30, 222)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 13)
        Me.Label9.TabIndex = 103
        Me.Label9.Text = "Tipo Auxiliar"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(30, 198)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 13)
        Me.Label8.TabIndex = 100
        Me.Label8.Text = "Referencia"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(30, 173)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 101
        Me.Label7.Text = "E:MAIL"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(390, 148)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 118
        Me.Label6.Text = "Celular"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(30, 148)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 106
        Me.Label5.Text = "Teléfono"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(30, 123)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 107
        Me.Label3.Text = "Dirección"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(30, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 13)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "Nombre / Raz/Social"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(30, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 105
        Me.Label1.Text = "Ruc"
        '
        'TxtApePatAux
        '
        Me.TxtApePatAux.BackColor = System.Drawing.Color.White
        Me.TxtApePatAux.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtApePatAux.Location = New System.Drawing.Point(175, 45)
        Me.TxtApePatAux.MaxLength = 150
        Me.TxtApePatAux.Name = "TxtApePatAux"
        Me.TxtApePatAux.Size = New System.Drawing.Size(200, 20)
        Me.TxtApePatAux.TabIndex = 1
        Me.TxtApePatAux.Tag = "1"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(30, 48)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 13)
        Me.Label10.TabIndex = 120
        Me.Label10.Text = "Apellido Paterno"
        '
        'TxtApeMatAux
        '
        Me.TxtApeMatAux.BackColor = System.Drawing.Color.White
        Me.TxtApeMatAux.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtApeMatAux.Location = New System.Drawing.Point(500, 45)
        Me.TxtApeMatAux.MaxLength = 150
        Me.TxtApeMatAux.Name = "TxtApeMatAux"
        Me.TxtApeMatAux.Size = New System.Drawing.Size(200, 20)
        Me.TxtApeMatAux.TabIndex = 2
        Me.TxtApeMatAux.Tag = "2"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(390, 48)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 13)
        Me.Label11.TabIndex = 122
        Me.Label11.Text = "Apellido Materno"
        '
        'TxtSegNomAux
        '
        Me.TxtSegNomAux.BackColor = System.Drawing.Color.White
        Me.TxtSegNomAux.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSegNomAux.Location = New System.Drawing.Point(500, 70)
        Me.TxtSegNomAux.MaxLength = 150
        Me.TxtSegNomAux.Name = "TxtSegNomAux"
        Me.TxtSegNomAux.Size = New System.Drawing.Size(200, 20)
        Me.TxtSegNomAux.TabIndex = 4
        Me.TxtSegNomAux.Tag = "4"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(390, 73)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 13)
        Me.Label12.TabIndex = 126
        Me.Label12.Text = "2sdo.Nombre"
        '
        'TxtPriNomAux
        '
        Me.TxtPriNomAux.BackColor = System.Drawing.Color.White
        Me.TxtPriNomAux.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPriNomAux.Location = New System.Drawing.Point(175, 70)
        Me.TxtPriNomAux.MaxLength = 150
        Me.TxtPriNomAux.Name = "TxtPriNomAux"
        Me.TxtPriNomAux.Size = New System.Drawing.Size(200, 20)
        Me.TxtPriNomAux.TabIndex = 3
        Me.TxtPriNomAux.Tag = "3"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(30, 73)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(62, 13)
        Me.Label13.TabIndex = 124
        Me.Label13.Text = "1er.Nombre"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(175, 225)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(98, 13)
        Me.Label14.TabIndex = 127
        Me.Label14.Text = "Persona Natural"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(30, 248)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(133, 13)
        Me.Label15.TabIndex = 128
        Me.Label15.Text = "Tipo Docuemnto Identidad"
        '
        'TxtTipDocIde
        '
        Me.TxtTipDocIde.BackColor = System.Drawing.Color.White
        Me.TxtTipDocIde.Location = New System.Drawing.Point(178, 245)
        Me.TxtTipDocIde.MaxLength = 7
        Me.TxtTipDocIde.Name = "TxtTipDocIde"
        Me.TxtTipDocIde.Size = New System.Drawing.Size(62, 20)
        Me.TxtTipDocIde.TabIndex = 10
        Me.TxtTipDocIde.Tag = "11"
        '
        'TxtNomDocIde
        '
        Me.TxtNomDocIde.BackColor = System.Drawing.SystemColors.Control
        Me.TxtNomDocIde.ForeColor = System.Drawing.Color.Black
        Me.TxtNomDocIde.Location = New System.Drawing.Point(246, 245)
        Me.TxtNomDocIde.MaxLength = 150
        Me.TxtNomDocIde.Name = "TxtNomDocIde"
        Me.TxtNomDocIde.ReadOnly = True
        Me.TxtNomDocIde.Size = New System.Drawing.Size(452, 20)
        Me.TxtNomDocIde.TabIndex = 130
        Me.TxtNomDocIde.Tag = "12"
        '
        'DtpFechaInsSnpAux
        '
        Me.DtpFechaInsSnpAux.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFechaInsSnpAux.Location = New System.Drawing.Point(178, 270)
        Me.DtpFechaInsSnpAux.Name = "DtpFechaInsSnpAux"
        Me.DtpFechaInsSnpAux.Size = New System.Drawing.Size(130, 20)
        Me.DtpFechaInsSnpAux.TabIndex = 11
        Me.DtpFechaInsSnpAux.Tag = "13"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(30, 273)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(118, 13)
        Me.Label31.TabIndex = 201
        Me.Label31.Text = "Fecha Inscripcíon SNP"
        '
        'WEditarAuxiliarPer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(724, 359)
        Me.Controls.Add(Me.DtpFechaInsSnpAux)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.TxtNomDocIde)
        Me.Controls.Add(Me.TxtTipDocIde)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TxtSegNomAux)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TxtPriNomAux)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TxtApeMatAux)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TxtApePatAux)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.gbEstado)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtRefAux)
        Me.Controls.Add(Me.txtCorAux)
        Me.Controls.Add(Me.txtCelAux)
        Me.Controls.Add(Me.txtTelAux)
        Me.Controls.Add(Me.txtDirAux)
        Me.Controls.Add(Me.txtNomAux)
        Me.Controls.Add(Me.txtCodAux)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "WEditarAuxiliarPer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WEditarAuxiliarPer"
        Me.gbEstado.ResumeLayout(False)
        Me.gbEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Function ListaControles() As List(Of CtrlsEdit)
        Dim lis As New List(Of CtrlsEdit)
        Dim item As New CtrlsEdit

        item = New CtrlsEdit
        item.Control = Me.txtCodAux
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Ruc"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtApePatAux
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Paterno"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtApeMatAux
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Paterno"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtPriNomAux
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Primer Nombre"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtSegNomAux
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Segundo Nombre"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtNomAux
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Descripcion"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtDirAux
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Direccion"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtTelAux
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Telefono"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kTelefono
        item.Valida = Validar.texto.vTelefono
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtCelAux
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Celular"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtCorAux
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Email"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kEmail
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtRefAux
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Referencia"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtTipDocIde
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Tipo Documento Identidad"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtNomDocIde
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Nombre Documento Identidad"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.DtpFechaInsSnpAux
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "Today"
        item.Campo = "Fecha Inscripción"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.gbEstado
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "0"
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


        item = New CtrlsEdit
        item.Control = Me.RbtActivo
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "True"
        item.Campo = ""
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.RbtInactivo
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "0"
        item.Campo = ""
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.btnAceptar
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = ""
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

    Friend WithEvents gbEstado As System.Windows.Forms.GroupBox
    Friend WithEvents RbtInactivo As System.Windows.Forms.RadioButton
    Friend WithEvents RbtActivo As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents txtRefAux As System.Windows.Forms.TextBox
    Friend WithEvents txtCorAux As System.Windows.Forms.TextBox
    Friend WithEvents txtCelAux As System.Windows.Forms.TextBox
    Friend WithEvents txtTelAux As System.Windows.Forms.TextBox
    Friend WithEvents txtDirAux As System.Windows.Forms.TextBox
    Friend WithEvents txtNomAux As System.Windows.Forms.TextBox
    Friend WithEvents txtCodAux As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtApePatAux As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtApeMatAux As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtSegNomAux As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtPriNomAux As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtTipDocIde As System.Windows.Forms.TextBox
    Friend WithEvents TxtNomDocIde As System.Windows.Forms.TextBox
    Friend WithEvents DtpFechaInsSnpAux As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label31 As System.Windows.Forms.Label
End Class
