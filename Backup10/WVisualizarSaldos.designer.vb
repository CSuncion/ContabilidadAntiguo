<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WVisualizarSaldos
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtCueEmp = New System.Windows.Forms.TextBox
        Me.DgvCueEmp = New System.Windows.Forms.DataGridView
        Me.dgvSaldos = New System.Windows.Forms.DataGridView
        Me.txtNomEmp = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtCodEmp = New System.Windows.Forms.TextBox
        Me.lblCabeVou = New System.Windows.Forms.Label
        Me.lblSaldo = New System.Windows.Forms.Label
        Me.dgvDeta = New System.Windows.Forms.DataGridView
        Me.GroupBox2.SuspendLayout()
        CType(Me.DgvCueEmp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSaldos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDeta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtCueEmp)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 322)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(405, 42)
        Me.GroupBox2.TabIndex = 112
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Buscar Cuenta"
        '
        'txtCueEmp
        '
        Me.txtCueEmp.Location = New System.Drawing.Point(10, 16)
        Me.txtCueEmp.Name = "txtCueEmp"
        Me.txtCueEmp.Size = New System.Drawing.Size(389, 20)
        Me.txtCueEmp.TabIndex = 1
        '
        'DgvCueEmp
        '
        Me.DgvCueEmp.BackgroundColor = System.Drawing.Color.White
        Me.DgvCueEmp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvCueEmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvCueEmp.Location = New System.Drawing.Point(12, 36)
        Me.DgvCueEmp.Name = "DgvCueEmp"
        Me.DgvCueEmp.Size = New System.Drawing.Size(405, 281)
        Me.DgvCueEmp.TabIndex = 111
        '
        'dgvSaldos
        '
        Me.dgvSaldos.BackgroundColor = System.Drawing.Color.White
        Me.dgvSaldos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvSaldos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSaldos.Location = New System.Drawing.Point(433, 36)
        Me.dgvSaldos.MultiSelect = False
        Me.dgvSaldos.Name = "dgvSaldos"
        Me.dgvSaldos.ReadOnly = True
        Me.dgvSaldos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSaldos.Size = New System.Drawing.Size(585, 328)
        Me.dgvSaldos.TabIndex = 113
        '
        'txtNomEmp
        '
        Me.txtNomEmp.BackColor = System.Drawing.SystemColors.Control
        Me.txtNomEmp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNomEmp.Location = New System.Drawing.Point(111, 12)
        Me.txtNomEmp.MaxLength = 200
        Me.txtNomEmp.Name = "txtNomEmp"
        Me.txtNomEmp.ReadOnly = True
        Me.txtNomEmp.Size = New System.Drawing.Size(306, 20)
        Me.txtNomEmp.TabIndex = 178
        Me.txtNomEmp.Tag = "1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(10, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 177
        Me.Label1.Text = "Empresa"
        '
        'TxtCodEmp
        '
        Me.TxtCodEmp.BackColor = System.Drawing.SystemColors.Control
        Me.TxtCodEmp.Location = New System.Drawing.Point(60, 12)
        Me.TxtCodEmp.MaxLength = 11
        Me.TxtCodEmp.Name = "TxtCodEmp"
        Me.TxtCodEmp.ReadOnly = True
        Me.TxtCodEmp.Size = New System.Drawing.Size(50, 20)
        Me.TxtCodEmp.TabIndex = 176
        Me.TxtCodEmp.Tag = "0"
        '
        'lblCabeVou
        '
        Me.lblCabeVou.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblCabeVou.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCabeVou.ForeColor = System.Drawing.Color.White
        Me.lblCabeVou.Location = New System.Drawing.Point(12, 368)
        Me.lblCabeVou.Name = "lblCabeVou"
        Me.lblCabeVou.Size = New System.Drawing.Size(1006, 23)
        Me.lblCabeVou.TabIndex = 180
        Me.lblCabeVou.Text = "Label1"
        Me.lblCabeVou.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSaldo
        '
        Me.lblSaldo.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldo.ForeColor = System.Drawing.Color.White
        Me.lblSaldo.Location = New System.Drawing.Point(433, 10)
        Me.lblSaldo.Name = "lblSaldo"
        Me.lblSaldo.Size = New System.Drawing.Size(585, 23)
        Me.lblSaldo.TabIndex = 181
        Me.lblSaldo.Text = "Label1"
        Me.lblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvDeta
        '
        Me.dgvDeta.BackgroundColor = System.Drawing.Color.White
        Me.dgvDeta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvDeta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDeta.Location = New System.Drawing.Point(12, 394)
        Me.dgvDeta.Name = "dgvDeta"
        Me.dgvDeta.Size = New System.Drawing.Size(1006, 167)
        Me.dgvDeta.TabIndex = 182
        '
        'WVisualizarSaldos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1024, 565)
        Me.Controls.Add(Me.dgvDeta)
        Me.Controls.Add(Me.lblSaldo)
        Me.Controls.Add(Me.lblCabeVou)
        Me.Controls.Add(Me.txtNomEmp)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtCodEmp)
        Me.Controls.Add(Me.dgvSaldos)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.DgvCueEmp)
        Me.MaximizeBox = False
        Me.Name = "WVisualizarSaldos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Visualizar Saldos"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DgvCueEmp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSaldos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDeta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCueEmp As System.Windows.Forms.TextBox
    Friend WithEvents DgvCueEmp As System.Windows.Forms.DataGridView
    Friend WithEvents dgvSaldos As System.Windows.Forms.DataGridView
    Friend WithEvents txtNomEmp As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtCodEmp As System.Windows.Forms.TextBox
    Friend WithEvents lblCabeVou As System.Windows.Forms.Label
    Friend WithEvents lblSaldo As System.Windows.Forms.Label
    Friend WithEvents dgvDeta As System.Windows.Forms.DataGridView
End Class
