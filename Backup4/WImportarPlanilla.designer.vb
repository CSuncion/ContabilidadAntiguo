<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WImportarPlanilla
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
        Me.btnImportar = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnVisualize = New System.Windows.Forms.Button
        Me.dgvExcel = New System.Windows.Forms.DataGridView
        Me.txtLoad = New System.Windows.Forms.TextBox
        Me.btnLoad = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.TxtCodEmp = New System.Windows.Forms.TextBox
        Me.TxtPeri = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.txtNomEmp = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtCodOri = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtCodFil = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtNumero = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        CType(Me.dgvExcel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnImportar
        '
        Me.btnImportar.Location = New System.Drawing.Point(989, 478)
        Me.btnImportar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(100, 28)
        Me.btnImportar.TabIndex = 24
        Me.btnImportar.Text = "Importar"
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(1097, 478)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(100, 28)
        Me.btnClose.TabIndex = 23
        Me.btnClose.Text = "Salir"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnVisualize
        '
        Me.btnVisualize.Location = New System.Drawing.Point(881, 478)
        Me.btnVisualize.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnVisualize.Name = "btnVisualize"
        Me.btnVisualize.Size = New System.Drawing.Size(100, 28)
        Me.btnVisualize.TabIndex = 22
        Me.btnVisualize.Text = "Visualizar"
        Me.btnVisualize.UseVisualStyleBackColor = True
        '
        'dgvExcel
        '
        Me.dgvExcel.AllowUserToDeleteRows = False
        Me.dgvExcel.BackgroundColor = System.Drawing.Color.White
        Me.dgvExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvExcel.Location = New System.Drawing.Point(141, 55)
        Me.dgvExcel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvExcel.MultiSelect = False
        Me.dgvExcel.Name = "dgvExcel"
        Me.dgvExcel.ReadOnly = True
        Me.dgvExcel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvExcel.Size = New System.Drawing.Size(1077, 415)
        Me.dgvExcel.TabIndex = 21
        '
        'txtLoad
        '
        Me.txtLoad.Location = New System.Drawing.Point(124, 21)
        Me.txtLoad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtLoad.Name = "txtLoad"
        Me.txtLoad.ReadOnly = True
        Me.txtLoad.Size = New System.Drawing.Size(883, 22)
        Me.txtLoad.TabIndex = 20
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(1016, 20)
        Me.btnLoad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(185, 28)
        Me.btnLoad.TabIndex = 19
        Me.btnLoad.Text = "Cargar Archivo"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TxtCodEmp
        '
        Me.TxtCodEmp.Location = New System.Drawing.Point(201, 480)
        Me.TxtCodEmp.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCodEmp.Name = "TxtCodEmp"
        Me.TxtCodEmp.ReadOnly = True
        Me.TxtCodEmp.Size = New System.Drawing.Size(56, 22)
        Me.TxtCodEmp.TabIndex = 193
        Me.TxtCodEmp.Tag = "0"
        '
        'TxtPeri
        '
        Me.TxtPeri.Location = New System.Drawing.Point(201, 512)
        Me.TxtPeri.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtPeri.Name = "TxtPeri"
        Me.TxtPeri.ReadOnly = True
        Me.TxtPeri.Size = New System.Drawing.Size(176, 22)
        Me.TxtPeri.TabIndex = 190
        Me.TxtPeri.Tag = "2"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label26.Location = New System.Drawing.Point(120, 516)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(64, 17)
        Me.Label26.TabIndex = 192
        Me.Label26.Text = "Periodo"
        '
        'txtNomEmp
        '
        Me.txtNomEmp.Location = New System.Drawing.Point(267, 480)
        Me.txtNomEmp.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNomEmp.Name = "txtNomEmp"
        Me.txtNomEmp.ReadOnly = True
        Me.txtNomEmp.Size = New System.Drawing.Size(576, 22)
        Me.txtNomEmp.TabIndex = 189
        Me.txtNomEmp.Tag = "1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(120, 484)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 17)
        Me.Label3.TabIndex = 191
        Me.Label3.Text = "Empresa"
        '
        'TxtCodOri
        '
        Me.TxtCodOri.Location = New System.Drawing.Point(527, 512)
        Me.TxtCodOri.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCodOri.Name = "TxtCodOri"
        Me.TxtCodOri.ReadOnly = True
        Me.TxtCodOri.Size = New System.Drawing.Size(119, 22)
        Me.TxtCodOri.TabIndex = 194
        Me.TxtCodOri.Tag = "2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(404, 516)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 17)
        Me.Label1.TabIndex = 195
        Me.Label1.Text = "Origen"
        '
        'TxtCodFil
        '
        Me.TxtCodFil.Location = New System.Drawing.Point(789, 512)
        Me.TxtCodFil.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtCodFil.Name = "TxtCodFil"
        Me.TxtCodFil.ReadOnly = True
        Me.TxtCodFil.Size = New System.Drawing.Size(119, 22)
        Me.TxtCodFil.TabIndex = 196
        Me.TxtCodFil.Tag = "2"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(667, 516)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 17)
        Me.Label2.TabIndex = 197
        Me.Label2.Text = "File"
        '
        'TxtNumero
        '
        Me.TxtNumero.Location = New System.Drawing.Point(1040, 512)
        Me.TxtNumero.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.ReadOnly = True
        Me.TxtNumero.Size = New System.Drawing.Size(119, 22)
        Me.TxtNumero.TabIndex = 198
        Me.TxtNumero.Tag = "2"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(917, 516)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 17)
        Me.Label4.TabIndex = 199
        Me.Label4.Text = "Numero"
        '
        'WImportarPlanilla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1325, 549)
        Me.Controls.Add(Me.TxtNumero)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtCodFil)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtCodOri)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtCodEmp)
        Me.Controls.Add(Me.TxtPeri)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.txtNomEmp)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnImportar)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnVisualize)
        Me.Controls.Add(Me.dgvExcel)
        Me.Controls.Add(Me.txtLoad)
        Me.Controls.Add(Me.btnLoad)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "WImportarPlanilla"
        Me.Text = "WImportarDiario"
        CType(Me.dgvExcel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnImportar As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnVisualize As System.Windows.Forms.Button
    Friend WithEvents dgvExcel As System.Windows.Forms.DataGridView
    Friend WithEvents txtLoad As System.Windows.Forms.TextBox
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TxtCodEmp As System.Windows.Forms.TextBox
    Friend WithEvents TxtPeri As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtNomEmp As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtCodOri As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtCodFil As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
