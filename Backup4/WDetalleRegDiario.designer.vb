<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WDetalleRegDiario
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
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtNum = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtSer = New System.Windows.Forms.TextBox
        Me.txtNomDoc = New System.Windows.Forms.TextBox
        Me.txtDoc = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtGlosa = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtImpDol = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtImpSol = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.gbDebeHaber = New System.Windows.Forms.GroupBox
        Me.rbtHaber = New System.Windows.Forms.RadioButton
        Me.rbtDebe = New System.Windows.Forms.RadioButton
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtNomAux = New System.Windows.Forms.TextBox
        Me.txtCodAux = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtNomCue = New System.Windows.Forms.TextBox
        Me.txtCodCuen = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtTipCam = New System.Windows.Forms.TextBox
        Me.txtNomIe = New System.Windows.Forms.TextBox
        Me.txtCodIe = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtNomCto = New System.Windows.Forms.TextBox
        Me.txtCenCto = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.gbMoneda = New System.Windows.Forms.GroupBox
        Me.rbtDol = New System.Windows.Forms.RadioButton
        Me.rbtSol = New System.Windows.Forms.RadioButton
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtNomAre = New System.Windows.Forms.TextBox
        Me.TxtCodAre = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnAgregar = New System.Windows.Forms.Button
        Me.btnDocu = New System.Windows.Forms.Button
        Me.TxtNomGasRep = New System.Windows.Forms.TextBox
        Me.TxtCodGasRep = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TxtCantidad = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.gbDebeHaber.SuspendLayout()
        Me.gbMoneda.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(458, 50)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 238
        Me.Label8.Text = "Fecha"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(316, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 236
        Me.Label7.Text = "Numero"
        '
        'txtNum
        '
        Me.txtNum.BackColor = System.Drawing.Color.White
        Me.txtNum.Location = New System.Drawing.Point(317, 67)
        Me.txtNum.Name = "txtNum"
        Me.txtNum.Size = New System.Drawing.Size(139, 20)
        Me.txtNum.TabIndex = 5
        Me.txtNum.Tag = "9"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(265, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 231
        Me.Label5.Text = "Serie"
        '
        'txtSer
        '
        Me.txtSer.BackColor = System.Drawing.Color.White
        Me.txtSer.Location = New System.Drawing.Point(269, 67)
        Me.txtSer.MaxLength = 15
        Me.txtSer.Name = "txtSer"
        Me.txtSer.Size = New System.Drawing.Size(42, 20)
        Me.txtSer.TabIndex = 4
        Me.txtSer.Tag = "8"
        '
        'txtNomDoc
        '
        Me.txtNomDoc.Location = New System.Drawing.Point(82, 67)
        Me.txtNomDoc.Name = "txtNomDoc"
        Me.txtNomDoc.ReadOnly = True
        Me.txtNomDoc.Size = New System.Drawing.Size(180, 20)
        Me.txtNomDoc.TabIndex = 229
        Me.txtNomDoc.Tag = "7"
        '
        'txtDoc
        '
        Me.txtDoc.BackColor = System.Drawing.Color.White
        Me.txtDoc.Location = New System.Drawing.Point(21, 67)
        Me.txtDoc.MaxLength = 15
        Me.txtDoc.Name = "txtDoc"
        Me.txtDoc.Size = New System.Drawing.Size(60, 20)
        Me.txtDoc.TabIndex = 3
        Me.txtDoc.Tag = "6"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(21, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 13)
        Me.Label3.TabIndex = 228
        Me.Label3.Text = "TD"
        '
        'txtGlosa
        '
        Me.txtGlosa.BackColor = System.Drawing.Color.White
        Me.txtGlosa.Location = New System.Drawing.Point(595, 113)
        Me.txtGlosa.Name = "txtGlosa"
        Me.txtGlosa.Size = New System.Drawing.Size(311, 20)
        Me.txtGlosa.TabIndex = 13
        Me.txtGlosa.Tag = "22"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(595, 92)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(39, 13)
        Me.Label21.TabIndex = 226
        Me.Label21.Text = "Glosa"
        '
        'txtImpDol
        '
        Me.txtImpDol.Location = New System.Drawing.Point(157, 111)
        Me.txtImpDol.Name = "txtImpDol"
        Me.txtImpDol.Size = New System.Drawing.Size(105, 20)
        Me.txtImpDol.TabIndex = 10
        Me.txtImpDol.Tag = "18"
        Me.txtImpDol.Text = "0.00"
        Me.txtImpDol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(154, 92)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(77, 13)
        Me.Label18.TabIndex = 224
        Me.Label18.Text = "Importe US$"
        '
        'txtImpSol
        '
        Me.txtImpSol.Location = New System.Drawing.Point(269, 111)
        Me.txtImpSol.Name = "txtImpSol"
        Me.txtImpSol.Size = New System.Drawing.Size(105, 20)
        Me.txtImpSol.TabIndex = 11
        Me.txtImpSol.Tag = "19"
        Me.txtImpSol.Text = "0.00"
        Me.txtImpSol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(269, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 223
        Me.Label2.Text = "Importe S/."
        '
        'gbDebeHaber
        '
        Me.gbDebeHaber.Controls.Add(Me.rbtHaber)
        Me.gbDebeHaber.Controls.Add(Me.rbtDebe)
        Me.gbDebeHaber.Location = New System.Drawing.Point(696, 60)
        Me.gbDebeHaber.Name = "gbDebeHaber"
        Me.gbDebeHaber.Size = New System.Drawing.Size(152, 28)
        Me.gbDebeHaber.TabIndex = 8
        Me.gbDebeHaber.TabStop = False
        Me.gbDebeHaber.Tag = "12"
        '
        'rbtHaber
        '
        Me.rbtHaber.AutoSize = True
        Me.rbtHaber.Location = New System.Drawing.Point(81, 8)
        Me.rbtHaber.Name = "rbtHaber"
        Me.rbtHaber.Size = New System.Drawing.Size(54, 17)
        Me.rbtHaber.TabIndex = 101
        Me.rbtHaber.Tag = "14"
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
        Me.rbtDebe.Tag = "13"
        Me.rbtDebe.Text = "Debe"
        Me.rbtDebe.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(693, 48)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(31, 13)
        Me.Label14.TabIndex = 222
        Me.Label14.Text = "H/D"
        '
        'txtNomAux
        '
        Me.txtNomAux.Location = New System.Drawing.Point(375, 25)
        Me.txtNomAux.Name = "txtNomAux"
        Me.txtNomAux.ReadOnly = True
        Me.txtNomAux.Size = New System.Drawing.Size(211, 20)
        Me.txtNomAux.TabIndex = 221
        Me.txtNomAux.Tag = "3"
        '
        'txtCodAux
        '
        Me.txtCodAux.BackColor = System.Drawing.Color.White
        Me.txtCodAux.Location = New System.Drawing.Point(269, 25)
        Me.txtCodAux.MaxLength = 15
        Me.txtCodAux.Name = "txtCodAux"
        Me.txtCodAux.Size = New System.Drawing.Size(105, 20)
        Me.txtCodAux.TabIndex = 1
        Me.txtCodAux.Tag = "2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(269, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 220
        Me.Label1.Text = "Ruc"
        '
        'txtNomCue
        '
        Me.txtNomCue.Location = New System.Drawing.Point(82, 25)
        Me.txtNomCue.Name = "txtNomCue"
        Me.txtNomCue.ReadOnly = True
        Me.txtNomCue.Size = New System.Drawing.Size(180, 20)
        Me.txtNomCue.TabIndex = 219
        Me.txtNomCue.Tag = "1"
        '
        'txtCodCuen
        '
        Me.txtCodCuen.BackColor = System.Drawing.Color.White
        Me.txtCodCuen.Location = New System.Drawing.Point(21, 25)
        Me.txtCodCuen.MaxLength = 10
        Me.txtCodCuen.Name = "txtCodCuen"
        Me.txtCodCuen.Size = New System.Drawing.Size(60, 20)
        Me.txtCodCuen.TabIndex = 0
        Me.txtCodCuen.Tag = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(21, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 218
        Me.Label4.Text = "Cuenta"
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(461, 67)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(125, 20)
        Me.dtpFecha.TabIndex = 6
        Me.dtpFecha.Tag = "10"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(595, 50)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(27, 13)
        Me.Label9.TabIndex = 240
        Me.Label9.Text = "T.C"
        '
        'txtTipCam
        '
        Me.txtTipCam.BackColor = System.Drawing.Color.White
        Me.txtTipCam.Location = New System.Drawing.Point(595, 67)
        Me.txtTipCam.Name = "txtTipCam"
        Me.txtTipCam.Size = New System.Drawing.Size(95, 20)
        Me.txtTipCam.TabIndex = 7
        Me.txtTipCam.Tag = "11"
        Me.txtTipCam.Text = "1"
        '
        'txtNomIe
        '
        Me.txtNomIe.Location = New System.Drawing.Point(448, 113)
        Me.txtNomIe.Name = "txtNomIe"
        Me.txtNomIe.ReadOnly = True
        Me.txtNomIe.Size = New System.Drawing.Size(138, 20)
        Me.txtNomIe.TabIndex = 251
        Me.txtNomIe.Tag = "21"
        '
        'txtCodIe
        '
        Me.txtCodIe.BackColor = System.Drawing.Color.White
        Me.txtCodIe.Location = New System.Drawing.Point(392, 113)
        Me.txtCodIe.Name = "txtCodIe"
        Me.txtCodIe.Size = New System.Drawing.Size(57, 20)
        Me.txtCodIe.TabIndex = 12
        Me.txtCodIe.Tag = "20"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(391, 92)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 13)
        Me.Label12.TabIndex = 250
        Me.Label12.Text = "Ing/Egr"
        '
        'txtNomCto
        '
        Me.txtNomCto.Location = New System.Drawing.Point(730, 26)
        Me.txtNomCto.Name = "txtNomCto"
        Me.txtNomCto.ReadOnly = True
        Me.txtNomCto.Size = New System.Drawing.Size(176, 20)
        Me.txtNomCto.TabIndex = 254
        Me.txtNomCto.Tag = "5"
        '
        'txtCenCto
        '
        Me.txtCenCto.BackColor = System.Drawing.Color.White
        Me.txtCenCto.Location = New System.Drawing.Point(677, 25)
        Me.txtCenCto.Name = "txtCenCto"
        Me.txtCenCto.Size = New System.Drawing.Size(50, 20)
        Me.txtCenCto.TabIndex = 2
        Me.txtCenCto.Tag = "4"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(693, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 253
        Me.Label6.Text = "C.Costo"
        '
        'gbMoneda
        '
        Me.gbMoneda.Controls.Add(Me.rbtDol)
        Me.gbMoneda.Controls.Add(Me.rbtSol)
        Me.gbMoneda.Location = New System.Drawing.Point(21, 103)
        Me.gbMoneda.Name = "gbMoneda"
        Me.gbMoneda.Size = New System.Drawing.Size(119, 28)
        Me.gbMoneda.TabIndex = 9
        Me.gbMoneda.TabStop = False
        Me.gbMoneda.Tag = "15"
        '
        'rbtDol
        '
        Me.rbtDol.AutoSize = True
        Me.rbtDol.Location = New System.Drawing.Point(54, 10)
        Me.rbtDol.Name = "rbtDol"
        Me.rbtDol.Size = New System.Drawing.Size(46, 17)
        Me.rbtDol.TabIndex = 101
        Me.rbtDol.Tag = "17"
        Me.rbtDol.Text = "US$"
        Me.rbtDol.UseVisualStyleBackColor = True
        '
        'rbtSol
        '
        Me.rbtSol.AutoSize = True
        Me.rbtSol.Checked = True
        Me.rbtSol.Location = New System.Drawing.Point(11, 10)
        Me.rbtSol.Name = "rbtSol"
        Me.rbtSol.Size = New System.Drawing.Size(40, 17)
        Me.rbtSol.TabIndex = 100
        Me.rbtSol.TabStop = True
        Me.rbtSol.Tag = "16"
        Me.rbtSol.Text = "S/."
        Me.rbtSol.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(21, 92)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 13)
        Me.Label10.TabIndex = 256
        Me.Label10.Text = "Moneda"
        '
        'TxtNomAre
        '
        Me.TxtNomAre.Location = New System.Drawing.Point(82, 152)
        Me.TxtNomAre.Name = "TxtNomAre"
        Me.TxtNomAre.ReadOnly = True
        Me.TxtNomAre.Size = New System.Drawing.Size(180, 20)
        Me.TxtNomAre.TabIndex = 259
        Me.TxtNomAre.Tag = "24"
        '
        'TxtCodAre
        '
        Me.TxtCodAre.BackColor = System.Drawing.Color.White
        Me.TxtCodAre.Location = New System.Drawing.Point(24, 152)
        Me.TxtCodAre.Name = "TxtCodAre"
        Me.TxtCodAre.Size = New System.Drawing.Size(57, 20)
        Me.TxtCodAre.TabIndex = 14
        Me.TxtCodAre.Tag = "23"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(21, 138)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 13)
        Me.Label11.TabIndex = 258
        Me.Label11.Text = "Area"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Presentacion.My.Resources.Resources.action_stop
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(826, 152)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 23)
        Me.btnCancelar.TabIndex = 18
        Me.btnCancelar.Tag = "29"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = Global.Presentacion.My.Resources.Resources.apply
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(745, 152)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(80, 23)
        Me.btnAgregar.TabIndex = 17
        Me.btnAgregar.Tag = "28"
        Me.btnAgregar.Text = "Aceptar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnDocu
        '
        Me.btnDocu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDocu.ImageKey = "(ninguno)"
        Me.btnDocu.Location = New System.Drawing.Point(595, 25)
        Me.btnDocu.Name = "btnDocu"
        Me.btnDocu.Size = New System.Drawing.Size(79, 23)
        Me.btnDocu.TabIndex = 260
        Me.btnDocu.Tag = "24"
        Me.btnDocu.Text = "Documentos"
        Me.btnDocu.UseVisualStyleBackColor = True
        '
        'TxtNomGasRep
        '
        Me.TxtNomGasRep.Location = New System.Drawing.Point(335, 154)
        Me.TxtNomGasRep.Name = "TxtNomGasRep"
        Me.TxtNomGasRep.ReadOnly = True
        Me.TxtNomGasRep.Size = New System.Drawing.Size(251, 20)
        Me.TxtNomGasRep.TabIndex = 263
        Me.TxtNomGasRep.Tag = "26"
        '
        'TxtCodGasRep
        '
        Me.TxtCodGasRep.BackColor = System.Drawing.Color.White
        Me.TxtCodGasRep.Location = New System.Drawing.Point(272, 152)
        Me.TxtCodGasRep.Name = "TxtCodGasRep"
        Me.TxtCodGasRep.Size = New System.Drawing.Size(57, 20)
        Me.TxtCodGasRep.TabIndex = 15
        Me.TxtCodGasRep.Tag = "25"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(273, 137)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 13)
        Me.Label13.TabIndex = 262
        Me.Label13.Text = "C.Almacen"
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Location = New System.Drawing.Point(598, 152)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(105, 20)
        Me.TxtCantidad.TabIndex = 16
        Me.TxtCantidad.Tag = "27"
        Me.TxtCantidad.Text = "0.00"
        Me.TxtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(595, 138)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(57, 13)
        Me.Label15.TabIndex = 265
        Me.Label15.Text = "Cantidad"
        '
        'WDetalleRegDiario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(918, 182)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TxtCantidad)
        Me.Controls.Add(Me.TxtNomGasRep)
        Me.Controls.Add(Me.TxtCodGasRep)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.btnDocu)
        Me.Controls.Add(Me.TxtNomAre)
        Me.Controls.Add(Me.TxtCodAre)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.gbMoneda)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtNomCto)
        Me.Controls.Add(Me.txtCenCto)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtNomIe)
        Me.Controls.Add(Me.txtCodIe)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtTipCam)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtNum)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtSer)
        Me.Controls.Add(Me.txtNomDoc)
        Me.Controls.Add(Me.txtDoc)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.txtGlosa)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.txtImpDol)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtImpSol)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.gbDebeHaber)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtNomAux)
        Me.Controls.Add(Me.txtCodAux)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNomCue)
        Me.Controls.Add(Me.txtCodCuen)
        Me.Controls.Add(Me.Label4)
        Me.MaximizeBox = False
        Me.Name = "WDetalleRegDiario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle Registro Diario"
        Me.gbDebeHaber.ResumeLayout(False)
        Me.gbDebeHaber.PerformLayout()
        Me.gbMoneda.ResumeLayout(False)
        Me.gbMoneda.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Function ListaControles() As List(Of CtrlsEdit)
        Dim lis As New List(Of CtrlsEdit)
        Dim item As CtrlsEdit

        item = New CtrlsEdit
        item.Control = Me.txtCodCuen
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Cuenta"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)


        item = New CtrlsEdit
        item.Control = Me.txtNomCue
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Nombre"
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
        item.Campo = "Auxiliar"
        item.Obligatorio = "0"
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
        item.Campo = "Descripcion"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtCenCto
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Centro Costo"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtNomCto
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
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Documento"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtNomDoc
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
        item.Control = Me.txtSer
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Serie Documento"
        item.Obligatorio = "0"
        '  item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
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
        item.Obligatorio = "0"
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
        item.Limpiar = "1"
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
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = "T.C"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.gbDebeHaber
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
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.rbtDebe
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
        item.Control = Me.rbtHaber
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
        item.Eliminar = "0"
        item.Visualizar = "0"
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
        item.Control = Me.txtImpDol
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "0.00"
        item.Campo = "Importe Dolares"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kDecimal
        item.Valida = Validar.texto.vSolonumerosConDosDecimales
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtImpSol
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "0.00"
        item.Campo = "Importe Soles"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kDecimal
        item.Valida = Validar.texto.vSolonumerosConDosDecimales
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtCodIe
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Ingresos/Egresos"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtNomIe
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Item"
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
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtCodAre
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Area"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtNomAre
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Item"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)


        item = New CtrlsEdit
        item.Control = Me.TxtCodGasRep
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Gasto"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtNomGasRep
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Nombre"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtCantidad
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "0.00"
        item.Campo = "Cantidad"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kDecimal
        item.Valida = Validar.texto.vSolonumerosConDosDecimales
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
        item.Eliminar = "1"
        item.Visualizar = "0"
        lis.Add(item)

        Return lis

    End Function

    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtNum As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSer As System.Windows.Forms.TextBox
    Friend WithEvents txtNomDoc As System.Windows.Forms.TextBox
    Friend WithEvents txtDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents txtGlosa As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtImpDol As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtImpSol As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gbDebeHaber As System.Windows.Forms.GroupBox
    Friend WithEvents rbtHaber As System.Windows.Forms.RadioButton
    Friend WithEvents rbtDebe As System.Windows.Forms.RadioButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtNomAux As System.Windows.Forms.TextBox
    Friend WithEvents txtCodAux As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNomCue As System.Windows.Forms.TextBox
    Friend WithEvents txtCodCuen As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTipCam As System.Windows.Forms.TextBox
    Friend WithEvents txtNomIe As System.Windows.Forms.TextBox
    Friend WithEvents txtCodIe As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtNomCto As System.Windows.Forms.TextBox
    Friend WithEvents txtCenCto As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents gbMoneda As System.Windows.Forms.GroupBox
    Friend WithEvents rbtDol As System.Windows.Forms.RadioButton
    Friend WithEvents rbtSol As System.Windows.Forms.RadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtNomAre As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodAre As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnDocu As System.Windows.Forms.Button
    Friend WithEvents TxtNomGasRep As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodGasRep As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
