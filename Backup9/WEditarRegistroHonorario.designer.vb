<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WEditarRegistroHonorario
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.gbRete = New System.Windows.Forms.GroupBox
        Me.rbtReNo = New System.Windows.Forms.RadioButton
        Me.rbtReSi = New System.Windows.Forms.RadioButton
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtDist = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker
        Me.txtGlosa = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtVv = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtPv = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.gbMoneda = New System.Windows.Forms.GroupBox
        Me.rbtDol = New System.Windows.Forms.RadioButton
        Me.rbtSol = New System.Windows.Forms.RadioButton
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtTipCam = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtNum = New System.Windows.Forms.TextBox
        Me.txtSer = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtNomDoc = New System.Windows.Forms.TextBox
        Me.txtDoc = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtNomAux = New System.Windows.Forms.TextBox
        Me.txtCodAux = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
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
        Me.txtPeri = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtCodEmp = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtNomEmp = New System.Windows.Forms.TextBox
        Me.txtSalImpTotSol = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtImpTotDol = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtImpTotSol = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.btnModificar = New System.Windows.Forms.Button
        Me.btnAgregar = New System.Windows.Forms.Button
        Me.txtTipCam1 = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.dgvRegHon = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DH = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IMPORTES = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ImporteD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gbDscto = New System.Windows.Forms.GroupBox
        Me.rbtDesNo = New System.Windows.Forms.RadioButton
        Me.rbtDesSnp = New System.Windows.Forms.RadioButton
        Me.rbtDesAfp = New System.Windows.Forms.RadioButton
        Me.Label24 = New System.Windows.Forms.Label
        Me.TxtCodAfp = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.TxtNomAfp = New System.Windows.Forms.TextBox
        Me.TxtDescuento = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.txtAsigFecAux = New System.Windows.Forms.TextBox
        Me.DtpFechaVcto = New System.Windows.Forms.DateTimePicker
        Me.Label33 = New System.Windows.Forms.Label
        Me.gbRete.SuspendLayout()
        Me.gbMoneda.SuspendLayout()
        CType(Me.dgvRegHon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbDscto.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbRete
        '
        Me.gbRete.Controls.Add(Me.rbtReNo)
        Me.gbRete.Controls.Add(Me.rbtReSi)
        Me.gbRete.Location = New System.Drawing.Point(248, 216)
        Me.gbRete.Name = "gbRete"
        Me.gbRete.Size = New System.Drawing.Size(100, 30)
        Me.gbRete.TabIndex = 8
        Me.gbRete.TabStop = False
        Me.gbRete.Tag = "27"
        '
        'rbtReNo
        '
        Me.rbtReNo.AutoSize = True
        Me.rbtReNo.Checked = True
        Me.rbtReNo.Location = New System.Drawing.Point(46, 9)
        Me.rbtReNo.Name = "rbtReNo"
        Me.rbtReNo.Size = New System.Drawing.Size(39, 17)
        Me.rbtReNo.TabIndex = 100
        Me.rbtReNo.TabStop = True
        Me.rbtReNo.Tag = "29"
        Me.rbtReNo.Text = "No"
        Me.rbtReNo.UseVisualStyleBackColor = True
        '
        'rbtReSi
        '
        Me.rbtReSi.AutoSize = True
        Me.rbtReSi.Location = New System.Drawing.Point(12, 9)
        Me.rbtReSi.Name = "rbtReSi"
        Me.rbtReSi.Size = New System.Drawing.Size(34, 17)
        Me.rbtReSi.TabIndex = 100
        Me.rbtReSi.Tag = "28"
        Me.rbtReSi.Text = "Si"
        Me.rbtReSi.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(116, 227)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(65, 13)
        Me.Label22.TabIndex = 296
        Me.Label22.Text = "Retencion"
        '
        'txtDist
        '
        Me.txtDist.Location = New System.Drawing.Point(750, 253)
        Me.txtDist.Name = "txtDist"
        Me.txtDist.ReadOnly = True
        Me.txtDist.Size = New System.Drawing.Size(105, 20)
        Me.txtDist.TabIndex = 295
        Me.txtDist.Tag = "100"
        Me.txtDist.Text = "0.00"
        Me.txtDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(680, 256)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(57, 13)
        Me.Label17.TabIndex = 294
        Me.Label17.Text = "Distribuir"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(248, 165)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(102, 20)
        Me.dtpFecha.TabIndex = 4
        Me.dtpFecha.Tag = "16"
        '
        'txtGlosa
        '
        Me.txtGlosa.BackColor = System.Drawing.Color.White
        Me.txtGlosa.Location = New System.Drawing.Point(248, 253)
        Me.txtGlosa.Name = "txtGlosa"
        Me.txtGlosa.Size = New System.Drawing.Size(416, 20)
        Me.txtGlosa.TabIndex = 10
        Me.txtGlosa.Tag = "33"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(116, 256)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(39, 13)
        Me.Label21.TabIndex = 290
        Me.Label21.Text = "Glosa"
        '
        'txtVv
        '
        Me.txtVv.Location = New System.Drawing.Point(589, 224)
        Me.txtVv.Name = "txtVv"
        Me.txtVv.ReadOnly = True
        Me.txtVv.Size = New System.Drawing.Size(75, 20)
        Me.txtVv.TabIndex = 265
        Me.txtVv.Tag = "31"
        Me.txtVv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(504, 227)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 13)
        Me.Label16.TabIndex = 289
        Me.Label16.Text = "Retencion"
        '
        'txtPv
        '
        Me.txtPv.BackColor = System.Drawing.Color.White
        Me.txtPv.Location = New System.Drawing.Point(401, 224)
        Me.txtPv.Name = "txtPv"
        Me.txtPv.Size = New System.Drawing.Size(79, 20)
        Me.txtPv.TabIndex = 9
        Me.txtPv.Tag = "30"
        Me.txtPv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(353, 227)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(42, 13)
        Me.Label15.TabIndex = 288
        Me.Label15.Text = "Monto"
        '
        'gbMoneda
        '
        Me.gbMoneda.Controls.Add(Me.rbtDol)
        Me.gbMoneda.Controls.Add(Me.rbtSol)
        Me.gbMoneda.Location = New System.Drawing.Point(750, 157)
        Me.gbMoneda.Name = "gbMoneda"
        Me.gbMoneda.Size = New System.Drawing.Size(107, 28)
        Me.gbMoneda.TabIndex = 5
        Me.gbMoneda.TabStop = False
        Me.gbMoneda.Tag = "18"
        '
        'rbtDol
        '
        Me.rbtDol.AutoSize = True
        Me.rbtDol.Location = New System.Drawing.Point(50, 9)
        Me.rbtDol.Name = "rbtDol"
        Me.rbtDol.Size = New System.Drawing.Size(46, 17)
        Me.rbtDol.TabIndex = 111
        Me.rbtDol.Tag = "20"
        Me.rbtDol.Text = "US$"
        Me.rbtDol.UseVisualStyleBackColor = True
        '
        'rbtSol
        '
        Me.rbtSol.AutoSize = True
        Me.rbtSol.Checked = True
        Me.rbtSol.Location = New System.Drawing.Point(11, 9)
        Me.rbtSol.Name = "rbtSol"
        Me.rbtSol.Size = New System.Drawing.Size(40, 17)
        Me.rbtSol.TabIndex = 100
        Me.rbtSol.TabStop = True
        Me.rbtSol.Tag = "19"
        Me.rbtSol.Text = "S/."
        Me.rbtSol.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(680, 168)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(52, 13)
        Me.Label14.TabIndex = 287
        Me.Label14.Text = "Moneda"
        '
        'txtTipCam
        '
        Me.txtTipCam.Location = New System.Drawing.Point(589, 165)
        Me.txtTipCam.Name = "txtTipCam"
        Me.txtTipCam.ReadOnly = True
        Me.txtTipCam.Size = New System.Drawing.Size(73, 20)
        Me.txtTipCam.TabIndex = 286
        Me.txtTipCam.Tag = "17"
        Me.txtTipCam.Text = "1.00"
        Me.txtTipCam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(504, 168)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 13)
        Me.Label13.TabIndex = 285
        Me.Label13.Text = "T.C."
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(116, 168)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 13)
        Me.Label12.TabIndex = 284
        Me.Label12.Text = "Fecha"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(680, 140)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(50, 13)
        Me.Label11.TabIndex = 283
        Me.Label11.Text = "Numero"
        '
        'txtNum
        '
        Me.txtNum.BackColor = System.Drawing.Color.White
        Me.txtNum.Location = New System.Drawing.Point(744, 137)
        Me.txtNum.MaxLength = 15
        Me.txtNum.Name = "txtNum"
        Me.txtNum.Size = New System.Drawing.Size(113, 20)
        Me.txtNum.TabIndex = 3
        Me.txtNum.Tag = "15"
        '
        'txtSer
        '
        Me.txtSer.BackColor = System.Drawing.Color.White
        Me.txtSer.Location = New System.Drawing.Point(589, 137)
        Me.txtSer.MaxLength = 4
        Me.txtSer.Name = "txtSer"
        Me.txtSer.Size = New System.Drawing.Size(73, 20)
        Me.txtSer.TabIndex = 2
        Me.txtSer.Tag = "14"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(504, 140)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 13)
        Me.Label10.TabIndex = 282
        Me.Label10.Text = "Serie"
        '
        'txtNomDoc
        '
        Me.txtNomDoc.Location = New System.Drawing.Point(285, 137)
        Me.txtNomDoc.Name = "txtNomDoc"
        Me.txtNomDoc.ReadOnly = True
        Me.txtNomDoc.Size = New System.Drawing.Size(195, 20)
        Me.txtNomDoc.TabIndex = 281
        Me.txtNomDoc.Tag = "13"
        '
        'txtDoc
        '
        Me.txtDoc.BackColor = System.Drawing.SystemColors.Control
        Me.txtDoc.Location = New System.Drawing.Point(248, 137)
        Me.txtDoc.Name = "txtDoc"
        Me.txtDoc.ReadOnly = True
        Me.txtDoc.Size = New System.Drawing.Size(37, 20)
        Me.txtDoc.TabIndex = 280
        Me.txtDoc.Tag = "12"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(116, 140)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 13)
        Me.Label9.TabIndex = 280
        Me.Label9.Text = "Documento"
        '
        'txtNomAux
        '
        Me.txtNomAux.Location = New System.Drawing.Point(369, 108)
        Me.txtNomAux.Name = "txtNomAux"
        Me.txtNomAux.ReadOnly = True
        Me.txtNomAux.Size = New System.Drawing.Size(486, 20)
        Me.txtNomAux.TabIndex = 279
        Me.txtNomAux.Tag = "11"
        '
        'txtCodAux
        '
        Me.txtCodAux.BackColor = System.Drawing.Color.White
        Me.txtCodAux.Location = New System.Drawing.Point(248, 108)
        Me.txtCodAux.MaxLength = 11
        Me.txtCodAux.Name = "txtCodAux"
        Me.txtCodAux.Size = New System.Drawing.Size(116, 20)
        Me.txtCodAux.TabIndex = 1
        Me.txtCodAux.Tag = "10"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(116, 111)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 13)
        Me.Label8.TabIndex = 278
        Me.Label8.Text = "Personal"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(680, 83)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 277
        Me.Label7.Text = "Fecha"
        '
        'txtDia
        '
        Me.txtDia.BackColor = System.Drawing.Color.White
        Me.txtDia.Location = New System.Drawing.Point(589, 80)
        Me.txtDia.Name = "txtDia"
        Me.txtDia.Size = New System.Drawing.Size(75, 20)
        Me.txtDia.TabIndex = 0
        Me.txtDia.Tag = "8"
        '
        'txtFecVau
        '
        Me.txtFecVau.Location = New System.Drawing.Point(750, 80)
        Me.txtFecVau.Name = "txtFecVau"
        Me.txtFecVau.ReadOnly = True
        Me.txtFecVau.Size = New System.Drawing.Size(107, 20)
        Me.txtFecVau.TabIndex = 276
        Me.txtFecVau.Tag = "9"
        '
        'txtNumVau
        '
        Me.txtNumVau.Location = New System.Drawing.Point(248, 80)
        Me.txtNumVau.Name = "txtNumVau"
        Me.txtNumVau.ReadOnly = True
        Me.txtNumVau.Size = New System.Drawing.Size(233, 20)
        Me.txtNumVau.TabIndex = 267
        Me.txtNumVau.Tag = "7"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(116, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 13)
        Me.Label5.TabIndex = 275
        Me.Label5.Text = "Numero Voucher"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(504, 83)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 13)
        Me.Label6.TabIndex = 274
        Me.Label6.Text = "Dia"
        '
        'txtNomFil
        '
        Me.txtNomFil.Location = New System.Drawing.Point(627, 51)
        Me.txtNomFil.Name = "txtNomFil"
        Me.txtNomFil.ReadOnly = True
        Me.txtNomFil.Size = New System.Drawing.Size(230, 20)
        Me.txtNomFil.TabIndex = 273
        Me.txtNomFil.Tag = "6"
        '
        'txtCodFil
        '
        Me.txtCodFil.BackColor = System.Drawing.SystemColors.Control
        Me.txtCodFil.Location = New System.Drawing.Point(589, 51)
        Me.txtCodFil.MaxLength = 3
        Me.txtCodFil.Name = "txtCodFil"
        Me.txtCodFil.ReadOnly = True
        Me.txtCodFil.Size = New System.Drawing.Size(37, 20)
        Me.txtCodFil.TabIndex = 266
        Me.txtCodFil.Tag = "5"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(504, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 13)
        Me.Label4.TabIndex = 272
        Me.Label4.Text = "File"
        '
        'txtCodOri
        '
        Me.txtCodOri.Location = New System.Drawing.Point(248, 51)
        Me.txtCodOri.Name = "txtCodOri"
        Me.txtCodOri.ReadOnly = True
        Me.txtCodOri.Size = New System.Drawing.Size(43, 20)
        Me.txtCodOri.TabIndex = 271
        Me.txtCodOri.Tag = "3"
        '
        'txtNomOri
        '
        Me.txtNomOri.Location = New System.Drawing.Point(291, 51)
        Me.txtNomOri.Name = "txtNomOri"
        Me.txtNomOri.ReadOnly = True
        Me.txtNomOri.Size = New System.Drawing.Size(189, 20)
        Me.txtNomOri.TabIndex = 270
        Me.txtNomOri.Tag = "4"
        '
        'txtPeri
        '
        Me.txtPeri.Location = New System.Drawing.Point(589, 24)
        Me.txtPeri.Name = "txtPeri"
        Me.txtPeri.ReadOnly = True
        Me.txtPeri.Size = New System.Drawing.Size(133, 20)
        Me.txtPeri.TabIndex = 0
        Me.txtPeri.Tag = "2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(504, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 269
        Me.Label3.Text = "Periodo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(116, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 268
        Me.Label2.Text = "Origen"
        '
        'TxtCodEmp
        '
        Me.TxtCodEmp.Location = New System.Drawing.Point(248, 24)
        Me.TxtCodEmp.Name = "TxtCodEmp"
        Me.TxtCodEmp.ReadOnly = True
        Me.TxtCodEmp.Size = New System.Drawing.Size(42, 20)
        Me.TxtCodEmp.TabIndex = 297
        Me.TxtCodEmp.Tag = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(116, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 298
        Me.Label1.Text = "Empresa"
        '
        'TxtNomEmp
        '
        Me.TxtNomEmp.Location = New System.Drawing.Point(291, 24)
        Me.TxtNomEmp.Name = "TxtNomEmp"
        Me.TxtNomEmp.ReadOnly = True
        Me.TxtNomEmp.Size = New System.Drawing.Size(189, 20)
        Me.TxtNomEmp.TabIndex = 299
        Me.TxtNomEmp.Tag = "1"
        '
        'txtSalImpTotSol
        '
        Me.txtSalImpTotSol.BackColor = System.Drawing.Color.White
        Me.txtSalImpTotSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSalImpTotSol.Location = New System.Drawing.Point(429, 535)
        Me.txtSalImpTotSol.Name = "txtSalImpTotSol"
        Me.txtSalImpTotSol.ReadOnly = True
        Me.txtSalImpTotSol.Size = New System.Drawing.Size(81, 20)
        Me.txtSalImpTotSol.TabIndex = 306
        Me.txtSalImpTotSol.Tag = "38"
        Me.txtSalImpTotSol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(279, 538)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(144, 13)
        Me.Label19.TabIndex = 311
        Me.Label19.Text = "Saldo Importe Total S/.:"
        '
        'txtImpTotDol
        '
        Me.txtImpTotDol.BackColor = System.Drawing.Color.White
        Me.txtImpTotDol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImpTotDol.Location = New System.Drawing.Point(863, 534)
        Me.txtImpTotDol.Name = "txtImpTotDol"
        Me.txtImpTotDol.ReadOnly = True
        Me.txtImpTotDol.Size = New System.Drawing.Size(81, 20)
        Me.txtImpTotDol.TabIndex = 308
        Me.txtImpTotDol.Tag = "40"
        Me.txtImpTotDol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(750, 537)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(107, 13)
        Me.Label18.TabIndex = 310
        Me.Label18.Text = "Importe Total $/.:"
        '
        'txtImpTotSol
        '
        Me.txtImpTotSol.BackColor = System.Drawing.Color.White
        Me.txtImpTotSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImpTotSol.Location = New System.Drawing.Point(644, 534)
        Me.txtImpTotSol.Name = "txtImpTotSol"
        Me.txtImpTotSol.ReadOnly = True
        Me.txtImpTotSol.Size = New System.Drawing.Size(81, 20)
        Me.txtImpTotSol.TabIndex = 307
        Me.txtImpTotSol.Tag = "39"
        Me.txtImpTotSol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(530, 537)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(108, 13)
        Me.Label20.TabIndex = 309
        Me.Label20.Text = "Importe Total S/.:"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Presentacion.My.Resources.Resources.action_stop
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(849, 563)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(96, 23)
        Me.btnCancelar.TabIndex = 16
        Me.btnCancelar.Tag = "42"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.Presentacion.My.Resources.Resources.apply
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(754, 563)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(96, 23)
        Me.btnAceptar.TabIndex = 15
        Me.btnAceptar.Tag = "41"
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(143, 533)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(54, 23)
        Me.btnEliminar.TabIndex = 14
        Me.btnEliminar.Tag = "37"
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(84, 533)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(60, 23)
        Me.btnModificar.TabIndex = 13
        Me.btnModificar.Tag = "36"
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(26, 533)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(59, 23)
        Me.btnAgregar.TabIndex = 12
        Me.btnAgregar.Tag = "35"
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'txtTipCam1
        '
        Me.txtTipCam1.Location = New System.Drawing.Point(407, 163)
        Me.txtTipCam1.Name = "txtTipCam1"
        Me.txtTipCam1.ReadOnly = True
        Me.txtTipCam1.Size = New System.Drawing.Size(73, 20)
        Me.txtTipCam1.TabIndex = 313
        Me.txtTipCam1.Tag = "120"
        Me.txtTipCam1.Text = "1.00"
        Me.txtTipCam1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(362, 168)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(39, 13)
        Me.Label23.TabIndex = 312
        Me.Label23.Text = "T.C.E"
        '
        'dgvRegHon
        '
        Me.dgvRegHon.BackgroundColor = System.Drawing.Color.White
        Me.dgvRegHon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvRegHon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRegHon.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.DH, Me.IMPORTES, Me.ImporteD, Me.Column8, Me.Column9, Me.Column10, Me.Column5, Me.Column6, Me.Column7, Me.Column11})
        Me.dgvRegHon.Location = New System.Drawing.Point(26, 304)
        Me.dgvRegHon.Name = "dgvRegHon"
        Me.dgvRegHon.ReadOnly = True
        Me.dgvRegHon.RowHeadersWidth = 25
        Me.dgvRegHon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRegHon.Size = New System.Drawing.Size(917, 220)
        Me.dgvRegHon.TabIndex = 314
        '
        'Column1
        '
        Me.Column1.HeaderText = "Codigo Cuenta"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 102
        '
        'Column2
        '
        Me.Column2.HeaderText = "Nombre Cuenta"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 190
        '
        'Column3
        '
        Me.Column3.HeaderText = "Centro Costo"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 110
        '
        'Column4
        '
        Me.Column4.HeaderText = "Nombre C.Costo"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 200
        '
        'DH
        '
        Me.DH.HeaderText = "D/H"
        Me.DH.Name = "DH"
        Me.DH.ReadOnly = True
        Me.DH.Width = 55
        '
        'IMPORTES
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.IMPORTES.DefaultCellStyle = DataGridViewCellStyle1
        Me.IMPORTES.HeaderText = "Importe S/"
        Me.IMPORTES.Name = "IMPORTES"
        Me.IMPORTES.ReadOnly = True
        '
        'ImporteD
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ImporteD.DefaultCellStyle = DataGridViewCellStyle2
        Me.ImporteD.HeaderText = "Importe $"
        Me.ImporteD.Name = "ImporteD"
        Me.ImporteD.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "CodigoIngEgr"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.HeaderText = "Nombre Ing/Egr"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 150
        '
        'Column10
        '
        Me.Column10.HeaderText = "Glosa"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "Area"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Nombre Area"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "Codigo Rep"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column11
        '
        Me.Column11.HeaderText = "Nombre Rep"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        '
        'gbDscto
        '
        Me.gbDscto.Controls.Add(Me.rbtDesNo)
        Me.gbDscto.Controls.Add(Me.rbtDesSnp)
        Me.gbDscto.Controls.Add(Me.rbtDesAfp)
        Me.gbDscto.Location = New System.Drawing.Point(248, 188)
        Me.gbDscto.Name = "gbDscto"
        Me.gbDscto.Size = New System.Drawing.Size(233, 30)
        Me.gbDscto.TabIndex = 6
        Me.gbDscto.TabStop = False
        Me.gbDscto.Tag = "21"
        '
        'rbtDesNo
        '
        Me.rbtDesNo.AutoSize = True
        Me.rbtDesNo.Checked = True
        Me.rbtDesNo.Location = New System.Drawing.Point(163, 9)
        Me.rbtDesNo.Name = "rbtDesNo"
        Me.rbtDesNo.Size = New System.Drawing.Size(41, 17)
        Me.rbtDesNo.TabIndex = 102
        Me.rbtDesNo.TabStop = True
        Me.rbtDesNo.Tag = "24"
        Me.rbtDesNo.Text = "NO"
        Me.rbtDesNo.UseVisualStyleBackColor = True
        '
        'rbtDesSnp
        '
        Me.rbtDesSnp.AutoSize = True
        Me.rbtDesSnp.Location = New System.Drawing.Point(89, 9)
        Me.rbtDesSnp.Name = "rbtDesSnp"
        Me.rbtDesSnp.Size = New System.Drawing.Size(56, 17)
        Me.rbtDesSnp.TabIndex = 101
        Me.rbtDesSnp.Tag = "23"
        Me.rbtDesSnp.Text = "S.N.P."
        Me.rbtDesSnp.UseVisualStyleBackColor = True
        '
        'rbtDesAfp
        '
        Me.rbtDesAfp.AutoSize = True
        Me.rbtDesAfp.Location = New System.Drawing.Point(12, 9)
        Me.rbtDesAfp.Name = "rbtDesAfp"
        Me.rbtDesAfp.Size = New System.Drawing.Size(54, 17)
        Me.rbtDesAfp.TabIndex = 100
        Me.rbtDesAfp.Tag = "22"
        Me.rbtDesAfp.Text = "A.F.P."
        Me.rbtDesAfp.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label24.Location = New System.Drawing.Point(116, 199)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(79, 13)
        Me.Label24.TabIndex = 316
        Me.Label24.Text = "Aplica Dscto"
        '
        'TxtCodAfp
        '
        Me.TxtCodAfp.BackColor = System.Drawing.Color.White
        Me.TxtCodAfp.Location = New System.Drawing.Point(589, 194)
        Me.TxtCodAfp.Name = "TxtCodAfp"
        Me.TxtCodAfp.Size = New System.Drawing.Size(37, 20)
        Me.TxtCodAfp.TabIndex = 7
        Me.TxtCodAfp.Tag = "25"
        Me.TxtCodAfp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label25.Location = New System.Drawing.Point(504, 199)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(34, 13)
        Me.Label25.TabIndex = 318
        Me.Label25.Text = "A.f.p"
        '
        'TxtNomAfp
        '
        Me.TxtNomAfp.Location = New System.Drawing.Point(627, 194)
        Me.TxtNomAfp.Name = "TxtNomAfp"
        Me.TxtNomAfp.ReadOnly = True
        Me.TxtNomAfp.Size = New System.Drawing.Size(228, 20)
        Me.TxtNomAfp.TabIndex = 319
        Me.TxtNomAfp.Tag = "26"
        '
        'TxtDescuento
        '
        Me.TxtDescuento.BackColor = System.Drawing.SystemColors.Control
        Me.TxtDescuento.Location = New System.Drawing.Point(750, 224)
        Me.TxtDescuento.Name = "TxtDescuento"
        Me.TxtDescuento.Size = New System.Drawing.Size(106, 20)
        Me.TxtDescuento.TabIndex = 320
        Me.TxtDescuento.Tag = "32"
        Me.TxtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label26.Location = New System.Drawing.Point(680, 227)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(68, 13)
        Me.Label26.TabIndex = 321
        Me.Label26.Text = "Descuento"
        '
        'txtAsigFecAux
        '
        Me.txtAsigFecAux.Location = New System.Drawing.Point(863, 108)
        Me.txtAsigFecAux.Name = "txtAsigFecAux"
        Me.txtAsigFecAux.ReadOnly = True
        Me.txtAsigFecAux.Size = New System.Drawing.Size(80, 20)
        Me.txtAsigFecAux.TabIndex = 322
        Me.txtAsigFecAux.Tag = "9"
        '
        'DtpFechaVcto
        '
        Me.DtpFechaVcto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFechaVcto.Location = New System.Drawing.Point(248, 278)
        Me.DtpFechaVcto.Name = "DtpFechaVcto"
        Me.DtpFechaVcto.Size = New System.Drawing.Size(116, 20)
        Me.DtpFechaVcto.TabIndex = 11
        Me.DtpFechaVcto.Tag = "34"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label33.Location = New System.Drawing.Point(116, 279)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(116, 13)
        Me.Label33.TabIndex = 324
        Me.Label33.Text = "Fecha Cancelación"
        '
        'WEditarRegistroHonorario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(961, 594)
        Me.Controls.Add(Me.DtpFechaVcto)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.txtAsigFecAux)
        Me.Controls.Add(Me.TxtDescuento)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.TxtNomAfp)
        Me.Controls.Add(Me.TxtCodAfp)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.gbDscto)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.dgvRegHon)
        Me.Controls.Add(Me.txtTipCam1)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.txtSalImpTotSol)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtImpTotDol)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtImpTotSol)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.TxtNomEmp)
        Me.Controls.Add(Me.TxtCodEmp)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gbRete)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txtDist)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.txtGlosa)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.txtVv)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtPv)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.gbMoneda)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtTipCam)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtNum)
        Me.Controls.Add(Me.txtSer)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtNomDoc)
        Me.Controls.Add(Me.txtDoc)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtNomAux)
        Me.Controls.Add(Me.txtCodAux)
        Me.Controls.Add(Me.Label8)
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
        Me.Controls.Add(Me.txtPeri)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Name = "WEditarRegistroHonorario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro Honorarios"
        Me.gbRete.ResumeLayout(False)
        Me.gbRete.PerformLayout()
        Me.gbMoneda.ResumeLayout(False)
        Me.gbMoneda.PerformLayout()
        CType(Me.dgvRegHon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbDscto.ResumeLayout(False)
        Me.gbDscto.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Function ListaControles() As List(Of CtrlsEdit)
        Dim lis As New List(Of CtrlsEdit)
        Dim item As CtrlsEdit

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
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = "File"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "0"
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
        item.Control = Me.txtCodAux
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Proveedor"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
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
        item.Control = Me.txtDoc
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = "Documento"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtNomDoc
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
        item.Control = Me.txtSer
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Serie Documento"
        item.Obligatorio = "1"
        'item.Teclazo = Validar.Tecla.kAlfaNumericoSinEspacioConGuion
        'item.Valida = Validar.texto.vSoloAlfaNumericoConEspacio
        item.Teclazo = Validar.Tecla.kAlfaNumericoSinEspacio
        item.NumCaracter = 4
        item.Valida = Validar.texto.vCompletarCerosCadena
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtNum
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Numero Documento"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.NumCaracter = 15
        item.Valida = Validar.texto.vCompletarCerosCadena
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.dtpFecha
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "0"
        item.DatoLimpiar = "Today"
        item.Campo = "Fecha Documento"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtTipCam
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
        item.Control = Me.gbMoneda
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
        item.Control = Me.rbtSol
        item.PasaFoco = "1"
        item.Formato = ""
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "true"
        item.Campo = ""
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        'txtCodPer
        item = New CtrlsEdit
        item.Control = Me.rbtDol
        item.PasaFoco = "1"
        item.Formato = ""
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
        item.Control = Me.gbDscto
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
        item.Control = Me.rbtDesAfp
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
        item.Control = Me.rbtDesSnp
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
        item.Control = Me.rbtDesNo
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
        item.Control = Me.TxtCodAfp
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Afp"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtNomAfp
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
        item.Control = Me.gbRete
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
        item.Control = Me.rbtReSi
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
        item.Control = Me.rbtReNo
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
        item.Control = Me.txtPv
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "0.00"
        item.Campo = "Importe"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kDecimal
        item.Valida = Validar.texto.vSolonumerosConDosDecimales
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtVv
        item.PasaFoco = "0"
        item.Formato = "1"
        item.PasarCursor = "0"
        item.Limpiar = "1"
        item.DatoLimpiar = "0.00"
        item.Campo = "Retencion"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kDecimal
        item.Valida = Validar.texto.vSolonumerosConDosDecimales
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtDescuento
        item.PasaFoco = "0"
        item.Formato = "1"
        item.PasarCursor = "0"
        item.Limpiar = "1"
        item.DatoLimpiar = "0.00"
        item.Campo = "Descuento"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kDecimal
        item.Valida = Validar.texto.vSolonumerosConDosDecimales
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtGlosa
        item.PasaFoco = "1"
        item.Formato = ""
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Glosa"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kDescripcion
        item.Valida = Validar.texto.vDescripcion
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.DtpFechaVcto
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "0"
        item.DatoLimpiar = "Today"
        item.Campo = "Fecha Vencimiento"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.btnAgregar
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
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.btnModificar
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
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.btnEliminar
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
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtSalImpTotSol
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
        item.Limpiar = "1"
        item.DatoLimpiar = "0.00"
        item.Campo = "Saldo"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kDecimal
        item.Valida = Validar.texto.vSolonumerosConDosDecimales
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtImpTotSol
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
        item.Limpiar = "1"
        item.DatoLimpiar = "0.00"
        item.Campo = "Importe Total Soles"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kDecimal
        item.Valida = Validar.texto.vSolonumerosConDosDecimales
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtImpTotDol
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
        item.Limpiar = "1"
        item.DatoLimpiar = "0.00"
        item.Campo = "Importe Total Dolares"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kDecimal
        item.Valida = Validar.texto.vSolonumerosConDosDecimales
        item.Nuevo = "0"
        item.Modificar = "0"
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

    Friend WithEvents gbRete As System.Windows.Forms.GroupBox
    Friend WithEvents rbtReNo As System.Windows.Forms.RadioButton
    Friend WithEvents rbtReSi As System.Windows.Forms.RadioButton
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtDist As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtGlosa As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtVv As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtPv As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents gbMoneda As System.Windows.Forms.GroupBox
    Friend WithEvents rbtDol As System.Windows.Forms.RadioButton
    Friend WithEvents rbtSol As System.Windows.Forms.RadioButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtTipCam As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtNum As System.Windows.Forms.TextBox
    Friend WithEvents txtSer As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtNomDoc As System.Windows.Forms.TextBox
    Friend WithEvents txtDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtNomAux As System.Windows.Forms.TextBox
    Friend WithEvents txtCodAux As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
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
    Friend WithEvents txtPeri As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtCodEmp As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtNomEmp As System.Windows.Forms.TextBox
    Friend WithEvents txtSalImpTotSol As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtImpTotDol As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtImpTotSol As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents txtTipCam1 As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents dgvRegHon As System.Windows.Forms.DataGridView
    Friend WithEvents gbDscto As System.Windows.Forms.GroupBox
    Friend WithEvents rbtDesAfp As System.Windows.Forms.RadioButton
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents rbtDesNo As System.Windows.Forms.RadioButton
    Friend WithEvents TxtCodAfp As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents rbtDesSnp As System.Windows.Forms.RadioButton
    Friend WithEvents TxtNomAfp As System.Windows.Forms.TextBox
    Friend WithEvents TxtDescuento As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtAsigFecAux As System.Windows.Forms.TextBox
    Friend WithEvents DtpFechaVcto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DH As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMPORTES As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImporteD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
