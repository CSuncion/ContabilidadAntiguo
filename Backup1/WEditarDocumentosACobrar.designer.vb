<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WEditarDocumentosACobrar
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label21 = New System.Windows.Forms.Label
        Me.TxtConcepto = New System.Windows.Forms.TextBox
        Me.TxtMonCb = New System.Windows.Forms.TextBox
        Me.TxtNumCb = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.TxtCodCb = New System.Windows.Forms.TextBox
        Me.TxtNum = New System.Windows.Forms.TextBox
        Me.TxtCodEmp = New System.Windows.Forms.TextBox
        Me.txtNomEmp = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtGirado = New System.Windows.Forms.TextBox
        Me.TxtNomDoc = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtImporte = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtTipCam = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtdoc = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtNomMod = New System.Windows.Forms.TextBox
        Me.txtModo = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
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
        Me.Label12 = New System.Windows.Forms.Label
        Me.TxtMontoAPagar = New System.Windows.Forms.TextBox
        Me.DgvDocPen = New System.Windows.Forms.DataGridView
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.txtNomAux = New System.Windows.Forms.TextBox
        Me.txtCodAux = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TxtMoneda = New System.Windows.Forms.TextBox
        Me.TxtTipCam1 = New System.Windows.Forms.TextBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.txtDolEur = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.TxtNomFluCaj = New System.Windows.Forms.TextBox
        Me.TxtCodFluCaj = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        CType(Me.DgvDocPen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(70, 268)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(61, 13)
        Me.Label21.TabIndex = 310
        Me.Label21.Text = "Concepto"
        '
        'TxtConcepto
        '
        Me.TxtConcepto.BackColor = System.Drawing.Color.White
        Me.TxtConcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtConcepto.Location = New System.Drawing.Point(201, 265)
        Me.TxtConcepto.MaxLength = 80
        Me.TxtConcepto.Name = "TxtConcepto"
        Me.TxtConcepto.Size = New System.Drawing.Size(627, 20)
        Me.TxtConcepto.TabIndex = 6
        Me.TxtConcepto.Tag = "10"
        '
        'TxtMonCb
        '
        Me.TxtMonCb.BackColor = System.Drawing.SystemColors.Control
        Me.TxtMonCb.Location = New System.Drawing.Point(774, 213)
        Me.TxtMonCb.Name = "TxtMonCb"
        Me.TxtMonCb.Size = New System.Drawing.Size(54, 20)
        Me.TxtMonCb.TabIndex = 331
        Me.TxtMonCb.Tag = "8"
        '
        'TxtNumCb
        '
        Me.TxtNumCb.Location = New System.Drawing.Point(588, 215)
        Me.TxtNumCb.Name = "TxtNumCb"
        Me.TxtNumCb.ReadOnly = True
        Me.TxtNumCb.Size = New System.Drawing.Size(181, 20)
        Me.TxtNumCb.TabIndex = 415
        Me.TxtNumCb.Tag = "7"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(455, 218)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(52, 13)
        Me.Label20.TabIndex = 307
        Me.Label20.Text = "Cta.Bco"
        '
        'TxtCodCb
        '
        Me.TxtCodCb.BackColor = System.Drawing.Color.White
        Me.TxtCodCb.Location = New System.Drawing.Point(509, 215)
        Me.TxtCodCb.Name = "TxtCodCb"
        Me.TxtCodCb.Size = New System.Drawing.Size(73, 20)
        Me.TxtCodCb.TabIndex = 4
        Me.TxtCodCb.Tag = "6"
        '
        'TxtNum
        '
        Me.TxtNum.BackColor = System.Drawing.Color.White
        Me.TxtNum.Location = New System.Drawing.Point(201, 215)
        Me.TxtNum.Name = "TxtNum"
        Me.TxtNum.Size = New System.Drawing.Size(115, 20)
        Me.TxtNum.TabIndex = 3
        Me.TxtNum.Tag = "5"
        '
        'TxtCodEmp
        '
        Me.TxtCodEmp.Location = New System.Drawing.Point(201, 10)
        Me.TxtCodEmp.Name = "TxtCodEmp"
        Me.TxtCodEmp.ReadOnly = True
        Me.TxtCodEmp.Size = New System.Drawing.Size(43, 20)
        Me.TxtCodEmp.TabIndex = 200
        Me.TxtCodEmp.Tag = "200"
        '
        'txtNomEmp
        '
        Me.txtNomEmp.Location = New System.Drawing.Point(263, 10)
        Me.txtNomEmp.Name = "txtNomEmp"
        Me.txtNomEmp.ReadOnly = True
        Me.txtNomEmp.Size = New System.Drawing.Size(565, 20)
        Me.txtNomEmp.TabIndex = 210
        Me.txtNomEmp.Tag = "210"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(70, 13)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(55, 13)
        Me.Label16.TabIndex = 303
        Me.Label16.Text = "Empresa"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(70, 243)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 13)
        Me.Label8.TabIndex = 301
        Me.Label8.Text = "Girado/Pagado"
        '
        'TxtGirado
        '
        Me.TxtGirado.BackColor = System.Drawing.Color.White
        Me.TxtGirado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtGirado.Location = New System.Drawing.Point(201, 240)
        Me.TxtGirado.MaxLength = 80
        Me.TxtGirado.Name = "TxtGirado"
        Me.TxtGirado.Size = New System.Drawing.Size(627, 20)
        Me.TxtGirado.TabIndex = 5
        Me.TxtGirado.Tag = "9"
        '
        'TxtNomDoc
        '
        Me.TxtNomDoc.Location = New System.Drawing.Point(588, 190)
        Me.TxtNomDoc.Name = "TxtNomDoc"
        Me.TxtNomDoc.ReadOnly = True
        Me.TxtNomDoc.Size = New System.Drawing.Size(240, 20)
        Me.TxtNomDoc.TabIndex = 410
        Me.TxtNomDoc.Tag = "4"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(70, 168)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 299
        Me.Label1.Text = "Importe Cobrado"
        '
        'TxtImporte
        '
        Me.TxtImporte.BackColor = System.Drawing.Color.White
        Me.TxtImporte.Location = New System.Drawing.Point(201, 165)
        Me.TxtImporte.MaxLength = 15
        Me.TxtImporte.Name = "TxtImporte"
        Me.TxtImporte.Size = New System.Drawing.Size(106, 20)
        Me.TxtImporte.TabIndex = 0
        Me.TxtImporte.Tag = "0"
        Me.TxtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(70, 115)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(52, 13)
        Me.Label14.TabIndex = 298
        Me.Label14.Text = "Moneda"
        '
        'txtTipCam
        '
        Me.txtTipCam.Location = New System.Drawing.Point(403, 110)
        Me.txtTipCam.Name = "txtTipCam"
        Me.txtTipCam.ReadOnly = True
        Me.txtTipCam.Size = New System.Drawing.Size(60, 20)
        Me.txtTipCam.TabIndex = 280
        Me.txtTipCam.Tag = "280"
        Me.txtTipCam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(367, 113)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 13)
        Me.Label13.TabIndex = 296
        Me.Label13.Text = "T.C."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(70, 218)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(50, 13)
        Me.Label11.TabIndex = 295
        Me.Label11.Text = "Numero"
        '
        'txtdoc
        '
        Me.txtdoc.BackColor = System.Drawing.Color.White
        Me.txtdoc.Location = New System.Drawing.Point(509, 190)
        Me.txtdoc.MaxLength = 4
        Me.txtdoc.Name = "txtdoc"
        Me.txtdoc.Size = New System.Drawing.Size(50, 20)
        Me.txtdoc.TabIndex = 2
        Me.txtdoc.Tag = "3"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(455, 193)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(24, 13)
        Me.Label10.TabIndex = 294
        Me.Label10.Text = "TD"
        '
        'txtNomMod
        '
        Me.txtNomMod.Location = New System.Drawing.Point(240, 190)
        Me.txtNomMod.Name = "txtNomMod"
        Me.txtNomMod.ReadOnly = True
        Me.txtNomMod.Size = New System.Drawing.Size(191, 20)
        Me.txtNomMod.TabIndex = 405
        Me.txtNomMod.Tag = "2"
        '
        'txtModo
        '
        Me.txtModo.BackColor = System.Drawing.Color.White
        Me.txtModo.Location = New System.Drawing.Point(201, 190)
        Me.txtModo.Name = "txtModo"
        Me.txtModo.Size = New System.Drawing.Size(38, 20)
        Me.txtModo.TabIndex = 1
        Me.txtModo.Tag = "1"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(70, 193)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 13)
        Me.Label9.TabIndex = 292
        Me.Label9.Text = "Medio de Pago"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(616, 88)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 291
        Me.Label7.Text = "Fecha"
        '
        'txtDia
        '
        Me.txtDia.BackColor = System.Drawing.SystemColors.Control
        Me.txtDia.Location = New System.Drawing.Point(532, 86)
        Me.txtDia.Name = "txtDia"
        Me.txtDia.Size = New System.Drawing.Size(73, 20)
        Me.txtDia.TabIndex = 272
        Me.txtDia.Tag = "272"
        '
        'txtFecVau
        '
        Me.txtFecVau.Location = New System.Drawing.Point(722, 85)
        Me.txtFecVau.Name = "txtFecVau"
        Me.txtFecVau.ReadOnly = True
        Me.txtFecVau.Size = New System.Drawing.Size(106, 20)
        Me.txtFecVau.TabIndex = 273
        Me.txtFecVau.Tag = "273"
        '
        'txtNumVau
        '
        Me.txtNumVau.Location = New System.Drawing.Point(201, 85)
        Me.txtNumVau.Name = "txtNumVau"
        Me.txtNumVau.ReadOnly = True
        Me.txtNumVau.Size = New System.Drawing.Size(262, 20)
        Me.txtNumVau.TabIndex = 260
        Me.txtNumVau.Tag = "260"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(70, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 13)
        Me.Label5.TabIndex = 289
        Me.Label5.Text = "Numero Voucher"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(471, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 13)
        Me.Label6.TabIndex = 288
        Me.Label6.Text = "Dia"
        '
        'txtNomFil
        '
        Me.txtNomFil.Location = New System.Drawing.Point(588, 60)
        Me.txtNomFil.Name = "txtNomFil"
        Me.txtNomFil.ReadOnly = True
        Me.txtNomFil.Size = New System.Drawing.Size(240, 20)
        Me.txtNomFil.TabIndex = 252
        Me.txtNomFil.Tag = "252"
        '
        'txtCodFil
        '
        Me.txtCodFil.BackColor = System.Drawing.SystemColors.Control
        Me.txtCodFil.Location = New System.Drawing.Point(532, 60)
        Me.txtCodFil.MaxLength = 3
        Me.txtCodFil.Name = "txtCodFil"
        Me.txtCodFil.ReadOnly = True
        Me.txtCodFil.Size = New System.Drawing.Size(50, 20)
        Me.txtCodFil.TabIndex = 250
        Me.txtCodFil.Tag = "250"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(471, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 13)
        Me.Label4.TabIndex = 286
        Me.Label4.Text = "File"
        '
        'txtCodOri
        '
        Me.txtCodOri.Location = New System.Drawing.Point(201, 60)
        Me.txtCodOri.Name = "txtCodOri"
        Me.txtCodOri.ReadOnly = True
        Me.txtCodOri.Size = New System.Drawing.Size(43, 20)
        Me.txtCodOri.TabIndex = 220
        Me.txtCodOri.Tag = "220"
        '
        'txtNomOri
        '
        Me.txtNomOri.Location = New System.Drawing.Point(245, 60)
        Me.txtNomOri.Name = "txtNomOri"
        Me.txtNomOri.ReadOnly = True
        Me.txtNomOri.Size = New System.Drawing.Size(218, 20)
        Me.txtNomOri.TabIndex = 225
        Me.txtNomOri.Tag = "225"
        '
        'txtPeri
        '
        Me.txtPeri.Location = New System.Drawing.Point(201, 35)
        Me.txtPeri.Name = "txtPeri"
        Me.txtPeri.ReadOnly = True
        Me.txtPeri.Size = New System.Drawing.Size(133, 20)
        Me.txtPeri.TabIndex = 215
        Me.txtPeri.Tag = "215"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(70, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 284
        Me.Label3.Text = "Periodo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(70, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 283
        Me.Label2.Text = "Origen"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(616, 113)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(102, 13)
        Me.Label12.TabIndex = 312
        Me.Label12.Text = "Importe A Cobrar"
        '
        'TxtMontoAPagar
        '
        Me.TxtMontoAPagar.BackColor = System.Drawing.SystemColors.Control
        Me.TxtMontoAPagar.Location = New System.Drawing.Point(722, 110)
        Me.TxtMontoAPagar.MaxLength = 15
        Me.TxtMontoAPagar.Name = "TxtMontoAPagar"
        Me.TxtMontoAPagar.ReadOnly = True
        Me.TxtMontoAPagar.Size = New System.Drawing.Size(106, 20)
        Me.TxtMontoAPagar.TabIndex = 311
        Me.TxtMontoAPagar.Tag = "311"
        Me.TxtMontoAPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DgvDocPen
        '
        Me.DgvDocPen.BackgroundColor = System.Drawing.Color.White
        Me.DgvDocPen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvDocPen.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvDocPen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDocPen.Location = New System.Drawing.Point(71, 315)
        Me.DgvDocPen.MultiSelect = False
        Me.DgvDocPen.Name = "DgvDocPen"
        Me.DgvDocPen.Size = New System.Drawing.Size(757, 142)
        Me.DgvDocPen.TabIndex = 333
        Me.DgvDocPen.Tag = "30"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Presentacion.My.Resources.Resources.action_stop
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(568, 461)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(95, 23)
        Me.btnCancelar.TabIndex = 9
        Me.btnCancelar.Tag = "14"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.Presentacion.My.Resources.Resources.apply
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(471, 461)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(98, 23)
        Me.btnAceptar.TabIndex = 8
        Me.btnAceptar.Tag = "13"
        Me.btnAceptar.Text = "Acepta"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'txtNomAux
        '
        Me.txtNomAux.BackColor = System.Drawing.SystemColors.Control
        Me.txtNomAux.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNomAux.Location = New System.Drawing.Point(308, 140)
        Me.txtNomAux.MaxLength = 200
        Me.txtNomAux.Name = "txtNomAux"
        Me.txtNomAux.ReadOnly = True
        Me.txtNomAux.Size = New System.Drawing.Size(517, 20)
        Me.txtNomAux.TabIndex = 403
        Me.txtNomAux.TabStop = False
        Me.txtNomAux.Tag = "403"
        '
        'txtCodAux
        '
        Me.txtCodAux.Location = New System.Drawing.Point(201, 140)
        Me.txtCodAux.Name = "txtCodAux"
        Me.txtCodAux.ReadOnly = True
        Me.txtCodAux.Size = New System.Drawing.Size(90, 20)
        Me.txtCodAux.TabIndex = 401
        Me.txtCodAux.Tag = "401"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(70, 143)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(46, 13)
        Me.Label15.TabIndex = 402
        Me.Label15.Text = "Cliente"
        '
        'TxtMoneda
        '
        Me.TxtMoneda.Location = New System.Drawing.Point(201, 113)
        Me.TxtMoneda.Name = "TxtMoneda"
        Me.TxtMoneda.ReadOnly = True
        Me.TxtMoneda.Size = New System.Drawing.Size(43, 20)
        Me.TxtMoneda.TabIndex = 416
        Me.TxtMoneda.Tag = "200"
        '
        'TxtTipCam1
        '
        Me.TxtTipCam1.Location = New System.Drawing.Point(300, 112)
        Me.TxtTipCam1.Name = "TxtTipCam1"
        Me.TxtTipCam1.ReadOnly = True
        Me.TxtTipCam1.Size = New System.Drawing.Size(53, 20)
        Me.TxtTipCam1.TabIndex = 418
        Me.TxtTipCam1.Tag = "18"
        Me.TxtTipCam1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label35.Location = New System.Drawing.Point(255, 115)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(39, 13)
        Me.Label35.TabIndex = 417
        Me.Label35.Text = "T.C.E"
        '
        'txtDolEur
        '
        Me.txtDolEur.Location = New System.Drawing.Point(532, 110)
        Me.txtDolEur.Name = "txtDolEur"
        Me.txtDolEur.ReadOnly = True
        Me.txtDolEur.Size = New System.Drawing.Size(61, 20)
        Me.txtDolEur.TabIndex = 420
        Me.txtDolEur.Tag = "9"
        Me.txtDolEur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(471, 115)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 13)
        Me.Label17.TabIndex = 419
        Me.Label17.Text = "T.C. d-e"
        '
        'TxtNomFluCaj
        '
        Me.TxtNomFluCaj.Location = New System.Drawing.Point(308, 290)
        Me.TxtNomFluCaj.Name = "TxtNomFluCaj"
        Me.TxtNomFluCaj.ReadOnly = True
        Me.TxtNomFluCaj.Size = New System.Drawing.Size(517, 20)
        Me.TxtNomFluCaj.TabIndex = 423
        Me.TxtNomFluCaj.Tag = "12"
        '
        'TxtCodFluCaj
        '
        Me.TxtCodFluCaj.BackColor = System.Drawing.Color.White
        Me.TxtCodFluCaj.Location = New System.Drawing.Point(199, 290)
        Me.TxtCodFluCaj.Name = "TxtCodFluCaj"
        Me.TxtCodFluCaj.Size = New System.Drawing.Size(108, 20)
        Me.TxtCodFluCaj.TabIndex = 7
        Me.TxtCodFluCaj.Tag = "11"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(70, 293)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(63, 13)
        Me.Label18.TabIndex = 422
        Me.Label18.Text = "Flujo Caja"
        '
        'WEditarDocumentosACobrar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(856, 492)
        Me.Controls.Add(Me.TxtNomFluCaj)
        Me.Controls.Add(Me.TxtCodFluCaj)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtDolEur)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.TxtTipCam1)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.TxtMoneda)
        Me.Controls.Add(Me.txtNomAux)
        Me.Controls.Add(Me.txtCodAux)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.DgvDocPen)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TxtMontoAPagar)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.TxtConcepto)
        Me.Controls.Add(Me.TxtMonCb)
        Me.Controls.Add(Me.TxtNumCb)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.TxtCodCb)
        Me.Controls.Add(Me.TxtNum)
        Me.Controls.Add(Me.TxtCodEmp)
        Me.Controls.Add(Me.txtNomEmp)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TxtGirado)
        Me.Controls.Add(Me.TxtNomDoc)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtImporte)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtTipCam)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtdoc)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtNomMod)
        Me.Controls.Add(Me.txtModo)
        Me.Controls.Add(Me.Label9)
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
        Me.MaximizeBox = False
        Me.Name = "WEditarDocumentosACobrar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Documentos A Pagar"
        CType(Me.DgvDocPen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Function ListaControles() As List(Of CtrlsEdit)
        Dim lis As New List(Of CtrlsEdit)
        Dim item As CtrlsEdit

        item = New CtrlsEdit
        item.Control = Me.TxtImporte
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
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtModo
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = "Modo Pago"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtNomMod
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
        item.Limpiar = ""
        item.DatoLimpiar = ""
        item.Campo = ""
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)


        item = New CtrlsEdit
        item.Control = Me.txtdoc
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = "Tipo Documento"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtNomDoc
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
        item.Limpiar = ""
        item.DatoLimpiar = ""
        item.Campo = ""
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtNum
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = "N°.Documento"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtCodCb
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Cuenta Banco"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtNumCb
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
        item.Limpiar = ""
        item.DatoLimpiar = ""
        item.Campo = "Nombre Cuenta Banco"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtMonCb
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
        item.Limpiar = ""
        item.DatoLimpiar = ""
        item.Campo = "Moneda Cuenta Banco"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtGirado
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = "Girado"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)


        item = New CtrlsEdit
        item.Control = Me.TxtConcepto
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = "Concepto"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtCodFluCaj
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = "Flujo Caja"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtNomFluCaj
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
        item.Limpiar = ""
        item.DatoLimpiar = ""
        item.Campo = ""
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
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
        item.DatoLimpiar = "0"
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


    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TxtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents TxtMonCb As System.Windows.Forms.TextBox
    Friend WithEvents TxtNumCb As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TxtCodCb As System.Windows.Forms.TextBox
    Friend WithEvents TxtNum As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodEmp As System.Windows.Forms.TextBox
    Friend WithEvents txtNomEmp As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtGirado As System.Windows.Forms.TextBox
    Friend WithEvents TxtNomDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtImporte As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtTipCam As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtdoc As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtNomMod As System.Windows.Forms.TextBox
    Friend WithEvents txtModo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
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
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtMontoAPagar As System.Windows.Forms.TextBox
    Friend WithEvents DgvDocPen As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents txtNomAux As System.Windows.Forms.TextBox
    Friend WithEvents txtCodAux As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtMoneda As System.Windows.Forms.TextBox
    Friend WithEvents TxtTipCam1 As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txtDolEur As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TxtNomFluCaj As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodFluCaj As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
End Class
