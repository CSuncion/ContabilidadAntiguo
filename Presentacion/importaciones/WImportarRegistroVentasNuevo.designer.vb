<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WImportarRegistroVentasNuevo
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
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.TxtCodEmp = New System.Windows.Forms.TextBox
        Me.txtNomEmp = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtRuta = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.TxtPeri = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.DgvPcg = New System.Windows.Forms.DataGridView
        Me.sst1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblUsu = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblRgs = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel6 = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblEmp = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblPer = New System.Windows.Forms.ToolStripStatusLabel
        Me.TxtCta70 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtCta40 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtCta12 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        CType(Me.DgvPcg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sst1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Presentacion.My.Resources.Resources.action_stop
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(259, 145)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(100, 23)
        Me.btnCancelar.TabIndex = 101
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.Presentacion.My.Resources.Resources.apply
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(157, 145)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(100, 23)
        Me.btnAceptar.TabIndex = 96
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'TxtCodEmp
        '
        Me.TxtCodEmp.Location = New System.Drawing.Point(110, 20)
        Me.TxtCodEmp.Name = "TxtCodEmp"
        Me.TxtCodEmp.ReadOnly = True
        Me.TxtCodEmp.Size = New System.Drawing.Size(37, 20)
        Me.TxtCodEmp.TabIndex = 258
        Me.TxtCodEmp.Tag = "0"
        '
        'txtNomEmp
        '
        Me.txtNomEmp.Location = New System.Drawing.Point(148, 20)
        Me.txtNomEmp.Name = "txtNomEmp"
        Me.txtNomEmp.ReadOnly = True
        Me.txtNomEmp.Size = New System.Drawing.Size(237, 20)
        Me.txtNomEmp.TabIndex = 256
        Me.txtNomEmp.Tag = "1"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(17, 23)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(48, 13)
        Me.Label16.TabIndex = 257
        Me.Label16.Text = "Empresa"
        '
        'txtRuta
        '
        Me.txtRuta.Location = New System.Drawing.Point(110, 70)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.ReadOnly = True
        Me.txtRuta.Size = New System.Drawing.Size(275, 20)
        Me.txtRuta.TabIndex = 259
        Me.txtRuta.Tag = "1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(17, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 260
        Me.Label1.Text = "Ruta Archivo"
        '
        'Button1
        '
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(399, 68)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(28, 23)
        Me.Button1.TabIndex = 261
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TxtPeri
        '
        Me.TxtPeri.Location = New System.Drawing.Point(110, 45)
        Me.TxtPeri.Name = "TxtPeri"
        Me.TxtPeri.ReadOnly = True
        Me.TxtPeri.Size = New System.Drawing.Size(133, 20)
        Me.TxtPeri.TabIndex = 262
        Me.TxtPeri.Tag = "2"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(17, 48)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(50, 13)
        Me.Label26.TabIndex = 263
        Me.Label26.Text = "Periodo"
        '
        'DgvPcg
        '
        Me.DgvPcg.BackgroundColor = System.Drawing.Color.White
        Me.DgvPcg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvPcg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPcg.Location = New System.Drawing.Point(20, 177)
        Me.DgvPcg.Name = "DgvPcg"
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DgvPcg.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvPcg.Size = New System.Drawing.Size(553, 129)
        Me.DgvPcg.TabIndex = 264
        '
        'sst1
        '
        Me.sst1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblUsu, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel5, Me.lblRgs, Me.ToolStripStatusLabel6, Me.lblEmp, Me.ToolStripStatusLabel8, Me.lblPer})
        Me.sst1.Location = New System.Drawing.Point(0, 346)
        Me.sst1.Name = "sst1"
        Me.sst1.Size = New System.Drawing.Size(585, 22)
        Me.sst1.TabIndex = 265
        Me.sst1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'lblUsu
        '
        Me.lblUsu.Name = "lblUsu"
        Me.lblUsu.Size = New System.Drawing.Size(36, 17)
        Me.lblUsu.Text = "Javier"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(12, 17)
        Me.ToolStripStatusLabel3.Text = "-"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(46, 17)
        Me.ToolStripStatusLabel5.Text = "Nº Rgs:"
        '
        'lblRgs
        '
        Me.lblRgs.Name = "lblRgs"
        Me.lblRgs.Size = New System.Drawing.Size(25, 17)
        Me.lblRgs.Text = "100"
        '
        'ToolStripStatusLabel6
        '
        Me.ToolStripStatusLabel6.Name = "ToolStripStatusLabel6"
        Me.ToolStripStatusLabel6.Size = New System.Drawing.Size(12, 17)
        Me.ToolStripStatusLabel6.Text = "-"
        '
        'lblEmp
        '
        Me.lblEmp.Name = "lblEmp"
        Me.lblEmp.Size = New System.Drawing.Size(52, 17)
        Me.lblEmp.Text = "Empresa"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(12, 17)
        Me.ToolStripStatusLabel8.Text = "-"
        '
        'lblPer
        '
        Me.lblPer.Name = "lblPer"
        Me.lblPer.Size = New System.Drawing.Size(48, 17)
        Me.lblPer.Text = "Periodo"
        '
        'TxtCta70
        '
        Me.TxtCta70.Location = New System.Drawing.Point(110, 95)
        Me.TxtCta70.Name = "TxtCta70"
        Me.TxtCta70.ReadOnly = True
        Me.TxtCta70.Size = New System.Drawing.Size(82, 20)
        Me.TxtCta70.TabIndex = 266
        Me.TxtCta70.Tag = "2"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(17, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 267
        Me.Label2.Text = "Cuenta 70"
        '
        'TxtCta40
        '
        Me.TxtCta40.Location = New System.Drawing.Point(291, 95)
        Me.TxtCta40.Name = "TxtCta40"
        Me.TxtCta40.ReadOnly = True
        Me.TxtCta40.Size = New System.Drawing.Size(94, 20)
        Me.TxtCta40.TabIndex = 268
        Me.TxtCta40.Tag = "2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(209, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 269
        Me.Label3.Text = "Cuenta 40"
        '
        'TxtCta12
        '
        Me.TxtCta12.Location = New System.Drawing.Point(110, 120)
        Me.TxtCta12.Name = "TxtCta12"
        Me.TxtCta12.ReadOnly = True
        Me.TxtCta12.Size = New System.Drawing.Size(82, 20)
        Me.TxtCta12.TabIndex = 270
        Me.TxtCta12.Tag = "2"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(17, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 271
        Me.Label4.Text = "Cuenta 12"
        '
        'WImportarRegistroVentasNuevo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(585, 368)
        Me.Controls.Add(Me.TxtCta12)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtCta40)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtCta70)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.sst1)
        Me.Controls.Add(Me.DgvPcg)
        Me.Controls.Add(Me.TxtPeri)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtRuta)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtCodEmp)
        Me.Controls.Add(Me.txtNomEmp)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.MaximizeBox = False
        Me.Name = "WImportarRegistroVentasNuevo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importar Registro Compras"
        CType(Me.DgvPcg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sst1.ResumeLayout(False)
        Me.sst1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents TxtCodEmp As System.Windows.Forms.TextBox
    Friend WithEvents txtNomEmp As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtRuta As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TxtPeri As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents DgvPcg As System.Windows.Forms.DataGridView
    Friend WithEvents sst1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblUsu As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblRgs As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel6 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblEmp As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblPer As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TxtCta70 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtCta40 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtCta12 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
