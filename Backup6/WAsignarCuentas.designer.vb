<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WAsignarCuentas
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
        Me.DgvCueGen = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.DgvCueEmp = New System.Windows.Forms.DataGridView
        Me.BtnAgregaTodos = New System.Windows.Forms.Button
        Me.BtnAgrega = New System.Windows.Forms.Button
        Me.BtnQuita = New System.Windows.Forms.Button
        Me.BtnQuitarTodos = New System.Windows.Forms.Button
        Me.txtNomEmp = New System.Windows.Forms.TextBox
        Me.txtCodEmp = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnSalir = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtCueDis = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtCueEmp = New System.Windows.Forms.TextBox
        CType(Me.DgvCueGen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvCueEmp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgvCueGen
        '
        Me.DgvCueGen.BackgroundColor = System.Drawing.Color.White
        Me.DgvCueGen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvCueGen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvCueGen.Location = New System.Drawing.Point(21, 71)
        Me.DgvCueGen.Name = "DgvCueGen"
        Me.DgvCueGen.Size = New System.Drawing.Size(364, 395)
        Me.DgvCueGen.TabIndex = 95
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 13)
        Me.Label1.TabIndex = 96
        Me.Label1.Text = "CUENTAS DISPONIBLES"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(482, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 13)
        Me.Label2.TabIndex = 98
        Me.Label2.Text = "CUENTAS EMPRESA:"
        '
        'DgvCueEmp
        '
        Me.DgvCueEmp.BackgroundColor = System.Drawing.Color.White
        Me.DgvCueEmp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvCueEmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvCueEmp.Location = New System.Drawing.Point(485, 71)
        Me.DgvCueEmp.Name = "DgvCueEmp"
        Me.DgvCueEmp.Size = New System.Drawing.Size(364, 395)
        Me.DgvCueEmp.TabIndex = 97
        '
        'BtnAgregaTodos
        '
        Me.BtnAgregaTodos.Location = New System.Drawing.Point(397, 176)
        Me.BtnAgregaTodos.Name = "BtnAgregaTodos"
        Me.BtnAgregaTodos.Size = New System.Drawing.Size(75, 39)
        Me.BtnAgregaTodos.TabIndex = 100
        Me.BtnAgregaTodos.Text = ">>"
        Me.BtnAgregaTodos.UseVisualStyleBackColor = True
        '
        'BtnAgrega
        '
        Me.BtnAgrega.Location = New System.Drawing.Point(397, 225)
        Me.BtnAgrega.Name = "BtnAgrega"
        Me.BtnAgrega.Size = New System.Drawing.Size(75, 39)
        Me.BtnAgrega.TabIndex = 101
        Me.BtnAgrega.Text = ">"
        Me.BtnAgrega.UseVisualStyleBackColor = True
        '
        'BtnQuita
        '
        Me.BtnQuita.Location = New System.Drawing.Point(397, 276)
        Me.BtnQuita.Name = "BtnQuita"
        Me.BtnQuita.Size = New System.Drawing.Size(75, 39)
        Me.BtnQuita.TabIndex = 102
        Me.BtnQuita.Text = "<"
        Me.BtnQuita.UseVisualStyleBackColor = True
        '
        'BtnQuitarTodos
        '
        Me.BtnQuitarTodos.Location = New System.Drawing.Point(397, 325)
        Me.BtnQuitarTodos.Name = "BtnQuitarTodos"
        Me.BtnQuitarTodos.Size = New System.Drawing.Size(75, 39)
        Me.BtnQuitarTodos.TabIndex = 103
        Me.BtnQuitarTodos.Text = "<<"
        Me.BtnQuitarTodos.UseVisualStyleBackColor = True
        '
        'txtNomEmp
        '
        Me.txtNomEmp.BackColor = System.Drawing.SystemColors.Control
        Me.txtNomEmp.Location = New System.Drawing.Point(156, 12)
        Me.txtNomEmp.MaxLength = 150
        Me.txtNomEmp.Name = "txtNomEmp"
        Me.txtNomEmp.ReadOnly = True
        Me.txtNomEmp.Size = New System.Drawing.Size(693, 20)
        Me.txtNomEmp.TabIndex = 105
        Me.txtNomEmp.Tag = "1"
        '
        'txtCodEmp
        '
        Me.txtCodEmp.BackColor = System.Drawing.SystemColors.Control
        Me.txtCodEmp.Location = New System.Drawing.Point(84, 12)
        Me.txtCodEmp.MaxLength = 11
        Me.txtCodEmp.Name = "txtCodEmp"
        Me.txtCodEmp.ReadOnly = True
        Me.txtCodEmp.Size = New System.Drawing.Size(71, 20)
        Me.txtCodEmp.TabIndex = 104
        Me.txtCodEmp.Tag = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(18, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 107
        Me.Label4.Text = "Empresa"
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(748, 520)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(101, 29)
        Me.btnSalir.TabIndex = 108
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtCueDis)
        Me.GroupBox1.Location = New System.Drawing.Point(21, 472)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(364, 42)
        Me.GroupBox1.TabIndex = 110
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Buscar Cuenta"
        '
        'txtCueDis
        '
        Me.txtCueDis.Location = New System.Drawing.Point(10, 16)
        Me.txtCueDis.Name = "txtCueDis"
        Me.txtCueDis.Size = New System.Drawing.Size(348, 20)
        Me.txtCueDis.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtCueEmp)
        Me.GroupBox2.Location = New System.Drawing.Point(485, 472)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(364, 42)
        Me.GroupBox2.TabIndex = 111
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Buscar Cuenta"
        '
        'txtCueEmp
        '
        Me.txtCueEmp.Location = New System.Drawing.Point(10, 16)
        Me.txtCueEmp.Name = "txtCueEmp"
        Me.txtCueEmp.Size = New System.Drawing.Size(348, 20)
        Me.txtCueEmp.TabIndex = 1
        '
        'WAsignarCuentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(876, 555)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.txtNomEmp)
        Me.Controls.Add(Me.txtCodEmp)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BtnQuitarTodos)
        Me.Controls.Add(Me.BtnQuita)
        Me.Controls.Add(Me.BtnAgrega)
        Me.Controls.Add(Me.BtnAgregaTodos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DgvCueEmp)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DgvCueGen)
        Me.Name = "WAsignarCuentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignar Cuentas"
        CType(Me.DgvCueGen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvCueEmp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
      Friend WithEvents DgvCueGen As System.Windows.Forms.DataGridView
      Friend WithEvents Label1 As System.Windows.Forms.Label
      Friend WithEvents Label2 As System.Windows.Forms.Label
      Friend WithEvents DgvCueEmp As System.Windows.Forms.DataGridView
      Friend WithEvents BtnAgregaTodos As System.Windows.Forms.Button
      Friend WithEvents BtnAgrega As System.Windows.Forms.Button
      Friend WithEvents BtnQuita As System.Windows.Forms.Button
      Friend WithEvents BtnQuitarTodos As System.Windows.Forms.Button
      Friend WithEvents txtNomEmp As System.Windows.Forms.TextBox
      Friend WithEvents txtCodEmp As System.Windows.Forms.TextBox
      Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCueDis As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCueEmp As System.Windows.Forms.TextBox
End Class
