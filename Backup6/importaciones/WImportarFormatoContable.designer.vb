<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WImportarFormatoContable
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
        Me.txtLoad = New System.Windows.Forms.TextBox
        Me.btnLoad = New System.Windows.Forms.Button
        Me.dgvExcel = New System.Windows.Forms.DataGridView
        Me.btnImportar = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnVisualize = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        CType(Me.dgvExcel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtLoad
        '
        Me.txtLoad.Location = New System.Drawing.Point(12, 12)
        Me.txtLoad.Name = "txtLoad"
        Me.txtLoad.ReadOnly = True
        Me.txtLoad.Size = New System.Drawing.Size(670, 20)
        Me.txtLoad.TabIndex = 26
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(681, 11)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(146, 23)
        Me.btnLoad.TabIndex = 25
        Me.btnLoad.Text = "Cargar Archivo"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'dgvExcel
        '
        Me.dgvExcel.AllowUserToDeleteRows = False
        Me.dgvExcel.BackgroundColor = System.Drawing.Color.White
        Me.dgvExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvExcel.Location = New System.Drawing.Point(19, 38)
        Me.dgvExcel.MultiSelect = False
        Me.dgvExcel.Name = "dgvExcel"
        Me.dgvExcel.ReadOnly = True
        Me.dgvExcel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvExcel.Size = New System.Drawing.Size(808, 323)
        Me.dgvExcel.TabIndex = 27
        '
        'btnImportar
        '
        Me.btnImportar.Location = New System.Drawing.Point(658, 369)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(75, 23)
        Me.btnImportar.TabIndex = 30
        Me.btnImportar.Text = "Importar"
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(739, 369)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 29
        Me.btnClose.Text = "Salir"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnVisualize
        '
        Me.btnVisualize.Location = New System.Drawing.Point(577, 369)
        Me.btnVisualize.Name = "btnVisualize"
        Me.btnVisualize.Size = New System.Drawing.Size(75, 23)
        Me.btnVisualize.TabIndex = 28
        Me.btnVisualize.Text = "Visualizar"
        Me.btnVisualize.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'WImportarTablas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(847, 404)
        Me.Controls.Add(Me.btnImportar)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnVisualize)
        Me.Controls.Add(Me.dgvExcel)
        Me.Controls.Add(Me.txtLoad)
        Me.Controls.Add(Me.btnLoad)
        Me.Name = "WImportarTablas"
        Me.Text = "WImportarTablas"
        CType(Me.dgvExcel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtLoad As System.Windows.Forms.TextBox
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents dgvExcel As System.Windows.Forms.DataGridView
    Friend WithEvents btnImportar As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnVisualize As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
