<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WCopiaPlanCuentas
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
        Me.txtNomEmp = New System.Windows.Forms.TextBox
        Me.txtCodEmp = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtNomEmpC = New System.Windows.Forms.TextBox
        Me.txtCodEmpC = New System.Windows.Forms.TextBox
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtNomEmp
        '
        Me.txtNomEmp.BackColor = System.Drawing.SystemColors.Control
        Me.txtNomEmp.Location = New System.Drawing.Point(144, 12)
        Me.txtNomEmp.MaxLength = 150
        Me.txtNomEmp.Name = "txtNomEmp"
        Me.txtNomEmp.ReadOnly = True
        Me.txtNomEmp.Size = New System.Drawing.Size(346, 20)
        Me.txtNomEmp.TabIndex = 109
        Me.txtNomEmp.Tag = "1"
        '
        'txtCodEmp
        '
        Me.txtCodEmp.BackColor = System.Drawing.SystemColors.Control
        Me.txtCodEmp.Location = New System.Drawing.Point(72, 12)
        Me.txtCodEmp.MaxLength = 11
        Me.txtCodEmp.Name = "txtCodEmp"
        Me.txtCodEmp.ReadOnly = True
        Me.txtCodEmp.Size = New System.Drawing.Size(71, 20)
        Me.txtCodEmp.TabIndex = 108
        Me.txtCodEmp.Tag = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(6, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 110
        Me.Label4.Text = "Empresa"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(69, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(378, 13)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "Seleccione la empresa de donde desea copiar el plan de cuentas"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtNomEmpC)
        Me.GroupBox1.Controls.Add(Me.txtCodEmpC)
        Me.GroupBox1.Location = New System.Drawing.Point(63, 61)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(442, 52)
        Me.GroupBox1.TabIndex = 112
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Empresa Copia"
        '
        'txtNomEmpC
        '
        Me.txtNomEmpC.BackColor = System.Drawing.SystemColors.Control
        Me.txtNomEmpC.Location = New System.Drawing.Point(80, 19)
        Me.txtNomEmpC.MaxLength = 150
        Me.txtNomEmpC.Name = "txtNomEmpC"
        Me.txtNomEmpC.ReadOnly = True
        Me.txtNomEmpC.Size = New System.Drawing.Size(346, 20)
        Me.txtNomEmpC.TabIndex = 111
        Me.txtNomEmpC.Tag = "1"
        '
        'txtCodEmpC
        '
        Me.txtCodEmpC.BackColor = System.Drawing.Color.White
        Me.txtCodEmpC.Location = New System.Drawing.Point(8, 19)
        Me.txtCodEmpC.MaxLength = 11
        Me.txtCodEmpC.Name = "txtCodEmpC"
        Me.txtCodEmpC.Size = New System.Drawing.Size(71, 20)
        Me.txtCodEmpC.TabIndex = 110
        Me.txtCodEmpC.Tag = "0"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Presentacion.My.Resources.Resources.action_stop
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(275, 126)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(95, 23)
        Me.btnCancelar.TabIndex = 114
        Me.btnCancelar.Tag = "27"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.Presentacion.My.Resources.Resources.apply
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(178, 126)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(98, 23)
        Me.btnAceptar.TabIndex = 113
        Me.btnAceptar.Tag = "26"
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'WCopiaPlanCuentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(523, 170)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNomEmp)
        Me.Controls.Add(Me.txtCodEmp)
        Me.Controls.Add(Me.Label4)
        Me.MaximizeBox = False
        Me.Name = "WCopiaPlanCuentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Copiar Plan de Cuentas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
      Friend WithEvents txtNomEmp As System.Windows.Forms.TextBox
      Friend WithEvents txtCodEmp As System.Windows.Forms.TextBox
      Friend WithEvents Label4 As System.Windows.Forms.Label
      Friend WithEvents Label1 As System.Windows.Forms.Label
      Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
      Friend WithEvents txtNomEmpC As System.Windows.Forms.TextBox
      Friend WithEvents txtCodEmpC As System.Windows.Forms.TextBox
      Friend WithEvents btnCancelar As System.Windows.Forms.Button
      Friend WithEvents btnAceptar As System.Windows.Forms.Button
End Class
