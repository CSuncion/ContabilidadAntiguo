<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WPersonalEstado
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbtDes = New System.Windows.Forms.RadioButton
        Me.rbtAct = New System.Windows.Forms.RadioButton
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.lblPersonal = New System.Windows.Forms.Label
        Me.dtpFechIng = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtDes)
        Me.GroupBox1.Controls.Add(Me.rbtAct)
        Me.GroupBox1.Location = New System.Drawing.Point(40, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(209, 30)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'rbtDes
        '
        Me.rbtDes.AutoSize = True
        Me.rbtDes.Location = New System.Drawing.Point(107, 9)
        Me.rbtDes.Name = "rbtDes"
        Me.rbtDes.Size = New System.Drawing.Size(89, 17)
        Me.rbtDes.TabIndex = 1
        Me.rbtDes.TabStop = True
        Me.rbtDes.Text = "Deshabilitado"
        Me.rbtDes.UseVisualStyleBackColor = True
        '
        'rbtAct
        '
        Me.rbtAct.AutoSize = True
        Me.rbtAct.Location = New System.Drawing.Point(17, 9)
        Me.rbtAct.Name = "rbtAct"
        Me.rbtAct.Size = New System.Drawing.Size(55, 17)
        Me.rbtAct.TabIndex = 0
        Me.rbtAct.TabStop = True
        Me.rbtAct.Text = "Activo"
        Me.rbtAct.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(72, 96)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(147, 96)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'lblPersonal
        '
        Me.lblPersonal.AutoSize = True
        Me.lblPersonal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPersonal.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblPersonal.Location = New System.Drawing.Point(9, 9)
        Me.lblPersonal.Name = "lblPersonal"
        Me.lblPersonal.Size = New System.Drawing.Size(45, 13)
        Me.lblPersonal.TabIndex = 3
        Me.lblPersonal.Text = "Label1"
        Me.lblPersonal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpFechIng
        '
        Me.dtpFechIng.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechIng.Location = New System.Drawing.Point(91, 64)
        Me.dtpFechIng.Name = "dtpFechIng"
        Me.dtpFechIng.Size = New System.Drawing.Size(131, 20)
        Me.dtpFechIng.TabIndex = 32
        Me.dtpFechIng.Tag = "42"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(9, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Fecha Baja"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'WPersonalEstado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(278, 137)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpFechIng)
        Me.Controls.Add(Me.lblPersonal)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.Name = "WPersonalEstado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estado Personal"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtDes As System.Windows.Forms.RadioButton
    Friend WithEvents rbtAct As System.Windows.Forms.RadioButton
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblPersonal As System.Windows.Forms.Label
    Friend WithEvents dtpFechIng As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
