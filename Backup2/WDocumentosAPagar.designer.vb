<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WDocumentosAPagar
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
        Me.lblTitLetPen = New System.Windows.Forms.Label
        Me.DgvDocPen = New System.Windows.Forms.DataGridView
        Me.btnTodos = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtNomAux = New System.Windows.Forms.TextBox
        Me.btnNinguno = New System.Windows.Forms.Button
        Me.BtnAcepta = New System.Windows.Forms.Button
        Me.BtnSalir = New System.Windows.Forms.Button
        Me.txtCodAux = New System.Windows.Forms.TextBox
        Me.TxtCodEmp = New System.Windows.Forms.TextBox
        Me.txtNomEmp = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtPeri = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.gbMoneda = New System.Windows.Forms.GroupBox
        Me.RbtEur = New System.Windows.Forms.RadioButton
        Me.rbtDol = New System.Windows.Forms.RadioButton
        Me.rbtSol = New System.Windows.Forms.RadioButton
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtTipCam = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDia = New System.Windows.Forms.TextBox
        Me.txtFecVau = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtNomFil = New System.Windows.Forms.TextBox
        Me.txtCodFil = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtCodOri = New System.Windows.Forms.TextBox
        Me.txtNomOri = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtTipCam1 = New System.Windows.Forms.TextBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.txtDolEur = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.DgvDocPen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbMoneda.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitLetPen
        '
        Me.lblTitLetPen.BackColor = System.Drawing.Color.Gray
        Me.lblTitLetPen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitLetPen.ForeColor = System.Drawing.Color.White
        Me.lblTitLetPen.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTitLetPen.Location = New System.Drawing.Point(11, 193)
        Me.lblTitLetPen.Name = "lblTitLetPen"
        Me.lblTitLetPen.Size = New System.Drawing.Size(847, 22)
        Me.lblTitLetPen.TabIndex = 350
        Me.lblTitLetPen.Text = "DOCUMENTOS PENDIENTES DEL AUXILIAR:"
        Me.lblTitLetPen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.DgvDocPen.Location = New System.Drawing.Point(12, 217)
        Me.DgvDocPen.MultiSelect = False
        Me.DgvDocPen.Name = "DgvDocPen"
        Me.DgvDocPen.Size = New System.Drawing.Size(846, 203)
        Me.DgvDocPen.TabIndex = 360
        '
        'btnTodos
        '
        Me.btnTodos.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnTodos.Location = New System.Drawing.Point(13, 164)
        Me.btnTodos.Name = "btnTodos"
        Me.btnTodos.Size = New System.Drawing.Size(99, 23)
        Me.btnTodos.TabIndex = 4
        Me.btnTodos.Tag = "16"
        Me.btnTodos.Text = "Marcar Todos"
        Me.btnTodos.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(36, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 317
        Me.Label3.Text = "Proveedor"
        '
        'txtNomAux
        '
        Me.txtNomAux.BackColor = System.Drawing.SystemColors.Control
        Me.txtNomAux.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNomAux.Location = New System.Drawing.Point(207, 116)
        Me.txtNomAux.MaxLength = 200
        Me.txtNomAux.Name = "txtNomAux"
        Me.txtNomAux.ReadOnly = True
        Me.txtNomAux.Size = New System.Drawing.Size(618, 20)
        Me.txtNomAux.TabIndex = 400
        Me.txtNomAux.TabStop = False
        Me.txtNomAux.Tag = "15"
        '
        'btnNinguno
        '
        Me.btnNinguno.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnNinguno.Location = New System.Drawing.Point(117, 164)
        Me.btnNinguno.Name = "btnNinguno"
        Me.btnNinguno.Size = New System.Drawing.Size(99, 23)
        Me.btnNinguno.TabIndex = 5
        Me.btnNinguno.Tag = "17"
        Me.btnNinguno.Text = "Desmarcar Todos"
        Me.btnNinguno.UseVisualStyleBackColor = True
        '
        'BtnAcepta
        '
        Me.BtnAcepta.Image = Global.Presentacion.My.Resources.Resources.apply
        Me.BtnAcepta.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnAcepta.Location = New System.Drawing.Point(14, 427)
        Me.BtnAcepta.Name = "BtnAcepta"
        Me.BtnAcepta.Size = New System.Drawing.Size(122, 23)
        Me.BtnAcepta.TabIndex = 6
        Me.BtnAcepta.Tag = "18"
        Me.BtnAcepta.Text = "Acepta Selección"
        Me.BtnAcepta.UseVisualStyleBackColor = True
        '
        'BtnSalir
        '
        Me.BtnSalir.Image = Global.Presentacion.My.Resources.Resources.action_stop
        Me.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnSalir.Location = New System.Drawing.Point(725, 427)
        Me.BtnSalir.Name = "BtnSalir"
        Me.BtnSalir.Size = New System.Drawing.Size(134, 23)
        Me.BtnSalir.TabIndex = 7
        Me.BtnSalir.Tag = "19"
        Me.BtnSalir.Text = "Salir"
        Me.BtnSalir.UseVisualStyleBackColor = True
        '
        'txtCodAux
        '
        Me.txtCodAux.Location = New System.Drawing.Point(116, 116)
        Me.txtCodAux.Name = "txtCodAux"
        Me.txtCodAux.Size = New System.Drawing.Size(90, 20)
        Me.txtCodAux.TabIndex = 3
        Me.txtCodAux.Tag = "14"
        '
        'TxtCodEmp
        '
        Me.TxtCodEmp.Location = New System.Drawing.Point(116, 25)
        Me.TxtCodEmp.Name = "TxtCodEmp"
        Me.TxtCodEmp.ReadOnly = True
        Me.TxtCodEmp.Size = New System.Drawing.Size(43, 20)
        Me.TxtCodEmp.TabIndex = 300
        Me.TxtCodEmp.Tag = "0"
        '
        'txtNomEmp
        '
        Me.txtNomEmp.Location = New System.Drawing.Point(160, 25)
        Me.txtNomEmp.Name = "txtNomEmp"
        Me.txtNomEmp.ReadOnly = True
        Me.txtNomEmp.Size = New System.Drawing.Size(665, 20)
        Me.txtNomEmp.TabIndex = 301
        Me.txtNomEmp.Tag = "1"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(36, 28)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(55, 13)
        Me.Label16.TabIndex = 324
        Me.Label16.Text = "Empresa"
        '
        'txtPeri
        '
        Me.txtPeri.Location = New System.Drawing.Point(116, 49)
        Me.txtPeri.Name = "txtPeri"
        Me.txtPeri.ReadOnly = True
        Me.txtPeri.Size = New System.Drawing.Size(69, 20)
        Me.txtPeri.TabIndex = 321
        Me.txtPeri.Tag = "2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(36, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 322
        Me.Label1.Text = "Periodo"
        '
        'gbMoneda
        '
        Me.gbMoneda.Controls.Add(Me.RbtEur)
        Me.gbMoneda.Controls.Add(Me.rbtDol)
        Me.gbMoneda.Controls.Add(Me.rbtSol)
        Me.gbMoneda.Location = New System.Drawing.Point(675, 80)
        Me.gbMoneda.Name = "gbMoneda"
        Me.gbMoneda.Size = New System.Drawing.Size(150, 28)
        Me.gbMoneda.TabIndex = 2
        Me.gbMoneda.TabStop = False
        Me.gbMoneda.Tag = "10"
        '
        'RbtEur
        '
        Me.RbtEur.AutoSize = True
        Me.RbtEur.Location = New System.Drawing.Point(99, 9)
        Me.RbtEur.Name = "RbtEur"
        Me.RbtEur.Size = New System.Drawing.Size(48, 17)
        Me.RbtEur.TabIndex = 384
        Me.RbtEur.Tag = "13"
        Me.RbtEur.Text = "EUR"
        Me.RbtEur.UseVisualStyleBackColor = True
        '
        'rbtDol
        '
        Me.rbtDol.AutoSize = True
        Me.rbtDol.Location = New System.Drawing.Point(50, 9)
        Me.rbtDol.Name = "rbtDol"
        Me.rbtDol.Size = New System.Drawing.Size(46, 17)
        Me.rbtDol.TabIndex = 383
        Me.rbtDol.Tag = "12"
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
        Me.rbtSol.TabIndex = 382
        Me.rbtSol.TabStop = True
        Me.rbtSol.Tag = "11"
        Me.rbtSol.Text = "S/."
        Me.rbtSol.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(617, 89)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(52, 13)
        Me.Label14.TabIndex = 341
        Me.Label14.Text = "Moneda"
        '
        'txtTipCam
        '
        Me.txtTipCam.Location = New System.Drawing.Point(440, 86)
        Me.txtTipCam.Name = "txtTipCam"
        Me.txtTipCam.ReadOnly = True
        Me.txtTipCam.Size = New System.Drawing.Size(50, 20)
        Me.txtTipCam.TabIndex = 340
        Me.txtTipCam.Tag = "9"
        Me.txtTipCam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(407, 90)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 13)
        Me.Label13.TabIndex = 339
        Me.Label13.Text = "T.C."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(157, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 338
        Me.Label4.Text = "Fecha"
        '
        'txtDia
        '
        Me.txtDia.BackColor = System.Drawing.Color.White
        Me.txtDia.Location = New System.Drawing.Point(116, 86)
        Me.txtDia.Name = "txtDia"
        Me.txtDia.Size = New System.Drawing.Size(31, 20)
        Me.txtDia.TabIndex = 1
        Me.txtDia.Tag = "7"
        '
        'txtFecVau
        '
        Me.txtFecVau.Location = New System.Drawing.Point(203, 86)
        Me.txtFecVau.Name = "txtFecVau"
        Me.txtFecVau.ReadOnly = True
        Me.txtFecVau.Size = New System.Drawing.Size(81, 20)
        Me.txtFecVau.TabIndex = 337
        Me.txtFecVau.Tag = "8"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(36, 89)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(26, 13)
        Me.Label8.TabIndex = 335
        Me.Label8.Text = "Dia"
        '
        'txtNomFil
        '
        Me.txtNomFil.Location = New System.Drawing.Point(612, 49)
        Me.txtNomFil.Name = "txtNomFil"
        Me.txtNomFil.ReadOnly = True
        Me.txtNomFil.Size = New System.Drawing.Size(213, 20)
        Me.txtNomFil.TabIndex = 334
        Me.txtNomFil.Tag = "6"
        '
        'txtCodFil
        '
        Me.txtCodFil.BackColor = System.Drawing.Color.White
        Me.txtCodFil.Location = New System.Drawing.Point(546, 49)
        Me.txtCodFil.MaxLength = 3
        Me.txtCodFil.Name = "txtCodFil"
        Me.txtCodFil.Size = New System.Drawing.Size(65, 20)
        Me.txtCodFil.TabIndex = 0
        Me.txtCodFil.Tag = "5"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(513, 56)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(27, 13)
        Me.Label9.TabIndex = 333
        Me.Label9.Text = "File"
        '
        'txtCodOri
        '
        Me.txtCodOri.BackColor = System.Drawing.SystemColors.Control
        Me.txtCodOri.Location = New System.Drawing.Point(249, 49)
        Me.txtCodOri.Name = "txtCodOri"
        Me.txtCodOri.ReadOnly = True
        Me.txtCodOri.Size = New System.Drawing.Size(43, 20)
        Me.txtCodOri.TabIndex = 325
        Me.txtCodOri.Tag = "3"
        '
        'txtNomOri
        '
        Me.txtNomOri.Location = New System.Drawing.Point(293, 49)
        Me.txtNomOri.Name = "txtNomOri"
        Me.txtNomOri.ReadOnly = True
        Me.txtNomOri.Size = New System.Drawing.Size(216, 20)
        Me.txtNomOri.TabIndex = 332
        Me.txtNomOri.Tag = "4"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(199, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 13)
        Me.Label10.TabIndex = 331
        Me.Label10.Text = "Origen"
        '
        'TxtTipCam1
        '
        Me.TxtTipCam1.Location = New System.Drawing.Point(340, 86)
        Me.TxtTipCam1.Name = "TxtTipCam1"
        Me.TxtTipCam1.ReadOnly = True
        Me.TxtTipCam1.Size = New System.Drawing.Size(50, 20)
        Me.TxtTipCam1.TabIndex = 402
        Me.TxtTipCam1.Tag = "18"
        Me.TxtTipCam1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label35.Location = New System.Drawing.Point(295, 89)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(39, 13)
        Me.Label35.TabIndex = 401
        Me.Label35.Text = "T.C.E"
        '
        'txtDolEur
        '
        Me.txtDolEur.Location = New System.Drawing.Point(561, 86)
        Me.txtDolEur.Name = "txtDolEur"
        Me.txtDolEur.ReadOnly = True
        Me.txtDolEur.Size = New System.Drawing.Size(50, 20)
        Me.txtDolEur.TabIndex = 404
        Me.txtDolEur.Tag = "9"
        Me.txtDolEur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(503, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 403
        Me.Label2.Text = "T.C. d-e"
        '
        'WDocumentosAPagar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(874, 458)
        Me.Controls.Add(Me.txtDolEur)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtTipCam1)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.gbMoneda)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtTipCam)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDia)
        Me.Controls.Add(Me.txtFecVau)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtNomFil)
        Me.Controls.Add(Me.txtCodFil)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtCodOri)
        Me.Controls.Add(Me.txtNomOri)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TxtCodEmp)
        Me.Controls.Add(Me.txtNomEmp)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtPeri)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnNinguno)
        Me.Controls.Add(Me.txtNomAux)
        Me.Controls.Add(Me.txtCodAux)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnTodos)
        Me.Controls.Add(Me.lblTitLetPen)
        Me.Controls.Add(Me.BtnAcepta)
        Me.Controls.Add(Me.BtnSalir)
        Me.Controls.Add(Me.DgvDocPen)
        Me.MaximizeBox = False
        Me.Name = "WDocumentosAPagar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pagos  a Proveedores"
        CType(Me.DgvDocPen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbMoneda.ResumeLayout(False)
        Me.gbMoneda.PerformLayout()
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
            item.Control = Me.txtPeri
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
            item.PasaFoco = "1"
            item.Formato = "0"
            item.PasarCursor = "1"
            item.Limpiar = "0"
            item.DatoLimpiar = ""
            item.Campo = "Origen"
            item.Obligatorio = "0"
            item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
            item.Valida = Validar.texto.vSoloAlfaNumericoSinEspacio
            item.Nuevo = "1"
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
            item.Limpiar = "1"
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
            item.Control = Me.txtTipCam
            item.PasaFoco = "0"
            item.Formato = "1"
            item.PasarCursor = "0"
            item.Limpiar = "1"
            item.DatoLimpiar = "1.000"
            item.Campo = "TC"
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
            item.Control = Me.RbtEur
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
            item.Control = Me.txtCodAux
            item.PasaFoco = "1"
            item.Formato = "0"
            item.PasarCursor = "1"
            item.Limpiar = "1"
            item.DatoLimpiar = ""
            item.Campo = "R.u.c."
            item.Obligatorio = "1"
            item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio  'Cuando teclea
            item.Valida = Validar.texto.vSoloNumerosSinEspacio  'Cuando sale del control   
            item.Nuevo = "1"
            item.Modificar = "0"
            item.Eliminar = "0"
            item.Visualizar = "0"
            lis.Add(item)

            item = New CtrlsEdit
            item.Control = Me.txtNomAux
            item.PasaFoco = "0"
            item.Formato = "1"
            item.PasarCursor = "0"
            item.Limpiar = "1"
            item.DatoLimpiar = ""
            item.Campo = "Auxiliar"
            item.Obligatorio = "0"
            item.Teclazo = Validar.Tecla.kNada
            item.Valida = Validar.texto.vNada
            item.Nuevo = "0"
            item.Modificar = "0"
            item.Eliminar = "0"
            item.Visualizar = "0"
            lis.Add(item)


            item = New CtrlsEdit
            item.Control = Me.btnTodos
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


            item = New CtrlsEdit
            item.Control = Me.btnNinguno
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

            item = New CtrlsEdit
            item.Control = Me.BtnAcepta
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

      Friend WithEvents lblTitLetPen As System.Windows.Forms.Label
      Friend WithEvents BtnAcepta As System.Windows.Forms.Button
      Friend WithEvents BtnSalir As System.Windows.Forms.Button
      Friend WithEvents DgvDocPen As System.Windows.Forms.DataGridView
      Friend WithEvents btnTodos As System.Windows.Forms.Button
      Friend WithEvents Label3 As System.Windows.Forms.Label
      Friend WithEvents txtNomAux As System.Windows.Forms.TextBox
      Friend WithEvents btnNinguno As System.Windows.Forms.Button
      Friend WithEvents txtCodAux As System.Windows.Forms.TextBox
      Friend WithEvents TxtCodEmp As System.Windows.Forms.TextBox
      Friend WithEvents txtNomEmp As System.Windows.Forms.TextBox
      Friend WithEvents Label16 As System.Windows.Forms.Label
      Friend WithEvents txtPeri As System.Windows.Forms.TextBox
      Friend WithEvents Label1 As System.Windows.Forms.Label
      Friend WithEvents gbMoneda As System.Windows.Forms.GroupBox
      Friend WithEvents rbtDol As System.Windows.Forms.RadioButton
      Friend WithEvents rbtSol As System.Windows.Forms.RadioButton
      Friend WithEvents Label14 As System.Windows.Forms.Label
      Friend WithEvents txtTipCam As System.Windows.Forms.TextBox
      Friend WithEvents Label13 As System.Windows.Forms.Label
      Friend WithEvents Label4 As System.Windows.Forms.Label
      Friend WithEvents txtDia As System.Windows.Forms.TextBox
      Friend WithEvents txtFecVau As System.Windows.Forms.TextBox
      Friend WithEvents Label8 As System.Windows.Forms.Label
      Friend WithEvents txtNomFil As System.Windows.Forms.TextBox
      Friend WithEvents txtCodFil As System.Windows.Forms.TextBox
      Friend WithEvents Label9 As System.Windows.Forms.Label
      Friend WithEvents txtCodOri As System.Windows.Forms.TextBox
      Friend WithEvents txtNomOri As System.Windows.Forms.TextBox
      Friend WithEvents Label10 As System.Windows.Forms.Label
      Friend WithEvents RbtEur As System.Windows.Forms.RadioButton
      Friend WithEvents TxtTipCam1 As System.Windows.Forms.TextBox
      Friend WithEvents Label35 As System.Windows.Forms.Label
      Friend WithEvents txtDolEur As System.Windows.Forms.TextBox
      Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
