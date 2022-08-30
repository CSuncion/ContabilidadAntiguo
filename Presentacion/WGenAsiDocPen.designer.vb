<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
 Partial Class WGenAsiDocPen
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
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtDia = New System.Windows.Forms.TextBox
        Me.txtFecVau = New System.Windows.Forms.TextBox
        Me.txtNumVau = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtNomFil = New System.Windows.Forms.TextBox
        Me.txtCodFil = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtCodOri = New System.Windows.Forms.TextBox
        Me.txtNomOri = New System.Windows.Forms.TextBox
        Me.txtNomEmp = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.TxtPeri = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.TxtCodEmp = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpFecDocDes = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.dtpFecDocHas = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtMonMayDoc = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtMonMenDoc = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtNomCueDoc = New System.Windows.Forms.TextBox
        Me.txtCodCueDoc = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.btnEjeFil = New System.Windows.Forms.Button
        Me.DgvDocPen = New System.Windows.Forms.DataGridView
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtGlosa = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtNomCueCon = New System.Windows.Forms.TextBox
        Me.txtCodCueCon = New System.Windows.Forms.TextBox
        Me.gbDebHabCon = New System.Windows.Forms.GroupBox
        Me.rbtHaber = New System.Windows.Forms.RadioButton
        Me.rbtDebe = New System.Windows.Forms.RadioButton
        CType(Me.DgvDocPen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDebHabCon.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(628, 341)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 145
        Me.Label7.Text = "Fecha"
        '
        'txtDia
        '
        Me.txtDia.BackColor = System.Drawing.Color.White
        Me.txtDia.Location = New System.Drawing.Point(568, 338)
        Me.txtDia.Name = "txtDia"
        Me.txtDia.Size = New System.Drawing.Size(37, 20)
        Me.txtDia.TabIndex = 7
        Me.txtDia.Tag = "15"
        '
        'txtFecVau
        '
        Me.txtFecVau.Location = New System.Drawing.Point(676, 338)
        Me.txtFecVau.Name = "txtFecVau"
        Me.txtFecVau.ReadOnly = True
        Me.txtFecVau.Size = New System.Drawing.Size(82, 20)
        Me.txtFecVau.TabIndex = 143
        Me.txtFecVau.Tag = "16"
        '
        'txtNumVau
        '
        Me.txtNumVau.Location = New System.Drawing.Point(179, 338)
        Me.txtNumVau.Name = "txtNumVau"
        Me.txtNumVau.ReadOnly = True
        Me.txtNumVau.Size = New System.Drawing.Size(90, 20)
        Me.txtNumVau.TabIndex = 100
        Me.txtNumVau.Tag = "14"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(30, 341)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 13)
        Me.Label5.TabIndex = 141
        Me.Label5.Text = "Numero Vaucher"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(476, 341)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(23, 13)
        Me.Label6.TabIndex = 140
        Me.Label6.Text = "Dia"
        '
        'txtNomFil
        '
        Me.txtNomFil.Location = New System.Drawing.Point(606, 312)
        Me.txtNomFil.Name = "txtNomFil"
        Me.txtNomFil.ReadOnly = True
        Me.txtNomFil.Size = New System.Drawing.Size(217, 20)
        Me.txtNomFil.TabIndex = 139
        Me.txtNomFil.Tag = "13"
        '
        'txtCodFil
        '
        Me.txtCodFil.BackColor = System.Drawing.Color.White
        Me.txtCodFil.Location = New System.Drawing.Point(568, 312)
        Me.txtCodFil.MaxLength = 3
        Me.txtCodFil.Name = "txtCodFil"
        Me.txtCodFil.Size = New System.Drawing.Size(37, 20)
        Me.txtCodFil.TabIndex = 6
        Me.txtCodFil.Tag = "12"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(476, 315)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 13)
        Me.Label4.TabIndex = 136
        Me.Label4.Text = "File"
        '
        'txtCodOri
        '
        Me.txtCodOri.Location = New System.Drawing.Point(179, 312)
        Me.txtCodOri.Name = "txtCodOri"
        Me.txtCodOri.ReadOnly = True
        Me.txtCodOri.Size = New System.Drawing.Size(43, 20)
        Me.txtCodOri.TabIndex = 135
        Me.txtCodOri.Tag = "10"
        '
        'txtNomOri
        '
        Me.txtNomOri.Location = New System.Drawing.Point(223, 312)
        Me.txtNomOri.Name = "txtNomOri"
        Me.txtNomOri.ReadOnly = True
        Me.txtNomOri.Size = New System.Drawing.Size(135, 20)
        Me.txtNomOri.TabIndex = 134
        Me.txtNomOri.Tag = "11"
        '
        'txtNomEmp
        '
        Me.txtNomEmp.Location = New System.Drawing.Point(223, 286)
        Me.txtNomEmp.Name = "txtNomEmp"
        Me.txtNomEmp.ReadOnly = True
        Me.txtNomEmp.Size = New System.Drawing.Size(224, 20)
        Me.txtNomEmp.TabIndex = 100
        Me.txtNomEmp.Tag = "8"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(30, 289)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 132
        Me.Label3.Text = "Empresa"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(30, 315)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 131
        Me.Label2.Text = "Origen"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label20.Location = New System.Drawing.Point(955, 206)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(57, 13)
        Me.Label20.TabIndex = 179
        Me.Label20.Text = "Distribuir"
        Me.Label20.Visible = False
        '
        'btnCancelar
        '
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(698, 437)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(125, 23)
        Me.btnCancelar.TabIndex = 12
        Me.btnCancelar.Tag = "24"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(568, 437)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(129, 23)
        Me.btnAceptar.TabIndex = 11
        Me.btnAceptar.Tag = "23"
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'TxtPeri
        '
        Me.TxtPeri.Location = New System.Drawing.Point(568, 286)
        Me.TxtPeri.Name = "TxtPeri"
        Me.TxtPeri.ReadOnly = True
        Me.TxtPeri.Size = New System.Drawing.Size(61, 20)
        Me.TxtPeri.TabIndex = 100
        Me.TxtPeri.Tag = "9"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(476, 289)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(43, 13)
        Me.Label26.TabIndex = 187
        Me.Label26.Text = "Periodo"
        '
        'TxtCodEmp
        '
        Me.TxtCodEmp.Location = New System.Drawing.Point(179, 286)
        Me.TxtCodEmp.Name = "TxtCodEmp"
        Me.TxtCodEmp.ReadOnly = True
        Me.TxtCodEmp.Size = New System.Drawing.Size(43, 20)
        Me.TxtCodEmp.TabIndex = 188
        Me.TxtCodEmp.Tag = "7"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkGray
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(30, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(793, 16)
        Me.Label1.TabIndex = 191
        Me.Label1.Text = "Filtro Documentos Pendientes"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFecDocDes
        '
        Me.dtpFecDocDes.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecDocDes.Location = New System.Drawing.Point(122, 37)
        Me.dtpFecDocDes.Name = "dtpFecDocDes"
        Me.dtpFecDocDes.Size = New System.Drawing.Size(103, 20)
        Me.dtpFecDocDes.TabIndex = 0
        Me.dtpFecDocDes.Tag = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(30, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 193
        Me.Label8.Text = "F.D. Desde"
        '
        'dtpFecDocHas
        '
        Me.dtpFecDocHas.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecDocHas.Location = New System.Drawing.Point(122, 63)
        Me.dtpFecDocHas.Name = "dtpFecDocHas"
        Me.dtpFecDocHas.Size = New System.Drawing.Size(103, 20)
        Me.dtpFecDocHas.TabIndex = 1
        Me.dtpFecDocHas.Tag = "1"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(30, 66)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 13)
        Me.Label9.TabIndex = 195
        Me.Label9.Text = "F.D. Hasta"
        '
        'txtMonMayDoc
        '
        Me.txtMonMayDoc.BackColor = System.Drawing.Color.White
        Me.txtMonMayDoc.Location = New System.Drawing.Point(344, 37)
        Me.txtMonMayDoc.Name = "txtMonMayDoc"
        Me.txtMonMayDoc.Size = New System.Drawing.Size(73, 20)
        Me.txtMonMayDoc.TabIndex = 2
        Me.txtMonMayDoc.Tag = "2"
        Me.txtMonMayDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(252, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 13)
        Me.Label10.TabIndex = 197
        Me.Label10.Text = "Monto. Mayor a"
        '
        'txtMonMenDoc
        '
        Me.txtMonMenDoc.BackColor = System.Drawing.Color.White
        Me.txtMonMenDoc.Location = New System.Drawing.Point(344, 63)
        Me.txtMonMenDoc.Name = "txtMonMenDoc"
        Me.txtMonMenDoc.Size = New System.Drawing.Size(73, 20)
        Me.txtMonMenDoc.TabIndex = 3
        Me.txtMonMenDoc.Tag = "3"
        Me.txtMonMenDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(252, 66)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 13)
        Me.Label11.TabIndex = 199
        Me.Label11.Text = "Monto. Menor a"
        '
        'txtNomCueDoc
        '
        Me.txtNomCueDoc.Location = New System.Drawing.Point(589, 37)
        Me.txtNomCueDoc.Name = "txtNomCueDoc"
        Me.txtNomCueDoc.ReadOnly = True
        Me.txtNomCueDoc.Size = New System.Drawing.Size(234, 20)
        Me.txtNomCueDoc.TabIndex = 221
        Me.txtNomCueDoc.Tag = "5"
        '
        'txtCodCueDoc
        '
        Me.txtCodCueDoc.BackColor = System.Drawing.Color.White
        Me.txtCodCueDoc.Location = New System.Drawing.Point(528, 37)
        Me.txtCodCueDoc.MaxLength = 10
        Me.txtCodCueDoc.Name = "txtCodCueDoc"
        Me.txtCodCueDoc.Size = New System.Drawing.Size(60, 20)
        Me.txtCodCueDoc.TabIndex = 4
        Me.txtCodCueDoc.Tag = "4"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(436, 40)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 13)
        Me.Label12.TabIndex = 222
        Me.Label12.Text = "Cuenta Doc"
        '
        'btnEjeFil
        '
        Me.btnEjeFil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEjeFil.Location = New System.Drawing.Point(601, 63)
        Me.btnEjeFil.Name = "btnEjeFil"
        Me.btnEjeFil.Size = New System.Drawing.Size(222, 23)
        Me.btnEjeFil.TabIndex = 5
        Me.btnEjeFil.Tag = "6"
        Me.btnEjeFil.Text = "Ejecutar Filtro"
        Me.btnEjeFil.UseVisualStyleBackColor = True
        '
        'DgvDocPen
        '
        Me.DgvDocPen.BackgroundColor = System.Drawing.Color.White
        Me.DgvDocPen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvDocPen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDocPen.Location = New System.Drawing.Point(33, 92)
        Me.DgvDocPen.Name = "DgvDocPen"
        Me.DgvDocPen.Size = New System.Drawing.Size(790, 158)
        Me.DgvDocPen.TabIndex = 224
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.DarkGray
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(30, 261)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(793, 16)
        Me.Label13.TabIndex = 225
        Me.Label13.Text = "Nuevos Datos Asiento"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGlosa
        '
        Me.txtGlosa.BackColor = System.Drawing.Color.White
        Me.txtGlosa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGlosa.Location = New System.Drawing.Point(179, 364)
        Me.txtGlosa.Name = "txtGlosa"
        Me.txtGlosa.Size = New System.Drawing.Size(579, 20)
        Me.txtGlosa.TabIndex = 8
        Me.txtGlosa.Tag = "17"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(30, 367)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(34, 13)
        Me.Label14.TabIndex = 227
        Me.Label14.Text = "Glosa"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(30, 393)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(75, 13)
        Me.Label15.TabIndex = 228
        Me.Label15.Text = "Contra Cuenta"
        '
        'txtNomCueCon
        '
        Me.txtNomCueCon.Location = New System.Drawing.Point(240, 390)
        Me.txtNomCueCon.Name = "txtNomCueCon"
        Me.txtNomCueCon.ReadOnly = True
        Me.txtNomCueCon.Size = New System.Drawing.Size(207, 20)
        Me.txtNomCueCon.TabIndex = 230
        Me.txtNomCueCon.Tag = "19"
        '
        'txtCodCueCon
        '
        Me.txtCodCueCon.BackColor = System.Drawing.Color.White
        Me.txtCodCueCon.Location = New System.Drawing.Point(179, 390)
        Me.txtCodCueCon.MaxLength = 10
        Me.txtCodCueCon.Name = "txtCodCueCon"
        Me.txtCodCueCon.Size = New System.Drawing.Size(60, 20)
        Me.txtCodCueCon.TabIndex = 9
        Me.txtCodCueCon.Tag = "18"
        '
        'gbDebHabCon
        '
        Me.gbDebHabCon.Controls.Add(Me.rbtHaber)
        Me.gbDebHabCon.Controls.Add(Me.rbtDebe)
        Me.gbDebHabCon.Location = New System.Drawing.Point(453, 384)
        Me.gbDebHabCon.Name = "gbDebHabCon"
        Me.gbDebHabCon.Size = New System.Drawing.Size(152, 27)
        Me.gbDebHabCon.TabIndex = 10
        Me.gbDebHabCon.TabStop = False
        Me.gbDebHabCon.Tag = "20"
        '
        'rbtHaber
        '
        Me.rbtHaber.AutoSize = True
        Me.rbtHaber.Location = New System.Drawing.Point(81, 8)
        Me.rbtHaber.Name = "rbtHaber"
        Me.rbtHaber.Size = New System.Drawing.Size(54, 17)
        Me.rbtHaber.TabIndex = 101
        Me.rbtHaber.Tag = "22"
        Me.rbtHaber.Text = "Haber"
        Me.rbtHaber.UseVisualStyleBackColor = True
        '
        'rbtDebe
        '
        Me.rbtDebe.AutoSize = True
        Me.rbtDebe.Checked = True
        Me.rbtDebe.Location = New System.Drawing.Point(21, 8)
        Me.rbtDebe.Name = "rbtDebe"
        Me.rbtDebe.Size = New System.Drawing.Size(51, 17)
        Me.rbtDebe.TabIndex = 100
        Me.rbtDebe.TabStop = True
        Me.rbtDebe.Tag = "21"
        Me.rbtDebe.Text = "Debe"
        Me.rbtDebe.UseVisualStyleBackColor = True
        '
        'WGenAsiDocPen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(857, 485)
        Me.Controls.Add(Me.gbDebHabCon)
        Me.Controls.Add(Me.txtNomCueCon)
        Me.Controls.Add(Me.txtCodCueCon)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtGlosa)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.DgvDocPen)
        Me.Controls.Add(Me.btnEjeFil)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtNomCueDoc)
        Me.Controls.Add(Me.txtCodCueDoc)
        Me.Controls.Add(Me.txtMonMenDoc)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtMonMayDoc)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.dtpFecDocHas)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dtpFecDocDes)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtCodEmp)
        Me.Controls.Add(Me.TxtPeri)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtDia)
        Me.Controls.Add(Me.txtFecVau)
        Me.Controls.Add(Me.txtNumVau)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtNomFil)
        Me.Controls.Add(Me.txtCodFil)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCodOri)
        Me.Controls.Add(Me.txtNomOri)
        Me.Controls.Add(Me.txtNomEmp)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.MaximizeBox = False
        Me.Name = "WGenAsiDocPen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Generar Asiento Documentos Pendientes"
        CType(Me.DgvDocPen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDebHabCon.ResumeLayout(False)
        Me.gbDebHabCon.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Function ListaControles() As List(Of CtrlsEdit)
        Dim lis As New List(Of CtrlsEdit)
        Dim item As CtrlsEdit

        item = New CtrlsEdit
        item.Control = Me.dtpFecDocDes
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "Today"
        item.Campo = "F.D. Desde"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.dtpFecDocHas
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "Today"
        item.Campo = "F.D. Hasta"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtMonMayDoc
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "0.00"
        item.Campo = "Monto Mayor a"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kDecimalNegativo
        item.Valida = Validar.texto.vSolonumerosConDosDecimales
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtMonMenDoc
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "0.00"
        item.Campo = "Monto Menor a"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kDecimalNegativo
        item.Valida = Validar.texto.vSolonumerosConDosDecimales
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtCodCueDoc
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = "Cuenta Documento"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtNomCueDoc
        item.PasaFoco = "0"
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
        item.Control = Me.btnEjeFil
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

        item = New CtrlsEdit
        item.Control = Me.TxtCodEmp
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = "Codigo"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtCodEmp
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = "Codigo"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtNomEmp
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = "Nombre"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtPeri
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = "Periodo"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtCodOri
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = "Origen"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtNomOri
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
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
        item.Control = Me.txtCodFil
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = "File"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kAlfaNumericoSinEspacio
        item.Valida = Validar.texto.vSoloAlfaNumericoSinEspacio
        item.Nuevo = "1"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtNomFil
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
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
        item.Control = Me.txtNumVau
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
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
        item.Control = Me.txtDia
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Dia Voucher"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtFecVau
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

        item = New CtrlsEdit
        item.Control = Me.txtGlosa
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Glosa"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtCodCueCon
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = "Contra Cuenta"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtNomCueCon
        item.PasaFoco = "0"
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
        item.Control = Me.gbDebHabCon
        item.PasaFoco = "1"
        item.Formato = ""
        item.PasarCursor = "0"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = ""
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "1"
        item.Visualizar = "1"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.rbtDebe
        item.PasaFoco = "1"
        item.Formato = ""
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
        item.Control = Me.rbtHaber
        item.PasaFoco = "1"
        item.Formato = ""
        item.PasarCursor = "1"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
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


    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDia As System.Windows.Forms.TextBox
    Friend WithEvents txtFecVau As System.Windows.Forms.TextBox
    Friend WithEvents txtNumVau As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNomFil As System.Windows.Forms.TextBox
    Friend WithEvents txtCodFil As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCodOri As System.Windows.Forms.TextBox
    Friend WithEvents txtNomOri As System.Windows.Forms.TextBox
    Friend WithEvents txtNomEmp As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TxtPeri As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TxtCodEmp As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFecDocDes As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtpFecDocHas As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtMonMayDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtMonMenDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtNomCueDoc As System.Windows.Forms.TextBox
    Friend WithEvents txtCodCueDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnEjeFil As System.Windows.Forms.Button
    Friend WithEvents DgvDocPen As System.Windows.Forms.DataGridView
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtGlosa As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtNomCueCon As System.Windows.Forms.TextBox
    Friend WithEvents txtCodCueCon As System.Windows.Forms.TextBox
    Friend WithEvents gbDebHabCon As System.Windows.Forms.GroupBox
    Friend WithEvents rbtHaber As System.Windows.Forms.RadioButton
    Friend WithEvents rbtDebe As System.Windows.Forms.RadioButton
End Class
