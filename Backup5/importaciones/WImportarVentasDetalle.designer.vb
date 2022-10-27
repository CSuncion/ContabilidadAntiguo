<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WImportarVentasDetalle
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
        CType(Me.dgvExcel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnImportar
        '
        Me.btnImportar.Location = New System.Drawing.Point(745, 414)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(75, 23)
        Me.btnImportar.TabIndex = 24
        Me.btnImportar.Text = "Importar"
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(826, 414)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 23
        Me.btnClose.Text = "Salir"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnVisualize
        '
        Me.btnVisualize.Location = New System.Drawing.Point(664, 414)
        Me.btnVisualize.Name = "btnVisualize"
        Me.btnVisualize.Size = New System.Drawing.Size(75, 23)
        Me.btnVisualize.TabIndex = 22
        Me.btnVisualize.Text = "Visualizar"
        Me.btnVisualize.UseVisualStyleBackColor = True
        '
        'dgvExcel
        '
        Me.dgvExcel.AllowUserToDeleteRows = False
        Me.dgvExcel.BackgroundColor = System.Drawing.Color.White
        Me.dgvExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvExcel.Location = New System.Drawing.Point(93, 43)
        Me.dgvExcel.MultiSelect = False
        Me.dgvExcel.Name = "dgvExcel"
        Me.dgvExcel.ReadOnly = True
        Me.dgvExcel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvExcel.Size = New System.Drawing.Size(808, 365)
        Me.dgvExcel.TabIndex = 21
        '
        'txtLoad
        '
        Me.txtLoad.Location = New System.Drawing.Point(93, 17)
        Me.txtLoad.Name = "txtLoad"
        Me.txtLoad.ReadOnly = True
        Me.txtLoad.Size = New System.Drawing.Size(663, 20)
        Me.txtLoad.TabIndex = 20
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(762, 16)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(139, 23)
        Me.btnLoad.TabIndex = 19
        Me.btnLoad.Text = "Cargar Archivo"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'WImportarDataMesesDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(994, 442)
        Me.Controls.Add(Me.btnImportar)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnVisualize)
        Me.Controls.Add(Me.dgvExcel)
        Me.Controls.Add(Me.txtLoad)
        Me.Controls.Add(Me.btnLoad)
        Me.Name = "WImportarDataMesesDetalle"
        Me.Text = "Importar Datos Detalle"
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
End Class
