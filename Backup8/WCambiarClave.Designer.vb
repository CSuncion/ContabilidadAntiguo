<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WCambiarClave
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
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnCambiar = New System.Windows.Forms.Button
        Me.txtClaC = New System.Windows.Forms.TextBox
        Me.txtClaN = New System.Windows.Forms.TextBox
        Me.txtCla = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Presentacion.My.Resources.Resources.action_stop
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(271, 86)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(104, 23)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnCambiar
        '
        Me.btnCambiar.Image = Global.Presentacion.My.Resources.Resources.icon_key
        Me.btnCambiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCambiar.Location = New System.Drawing.Point(169, 86)
        Me.btnCambiar.Name = "btnCambiar"
        Me.btnCambiar.Size = New System.Drawing.Size(101, 23)
        Me.btnCambiar.TabIndex = 3
        Me.btnCambiar.Text = "Cambiar"
        Me.btnCambiar.UseVisualStyleBackColor = True
        '
        'txtClaC
        '
        Me.txtClaC.Location = New System.Drawing.Point(156, 60)
        Me.txtClaC.MaxLength = 10
        Me.txtClaC.Name = "txtClaC"
        Me.txtClaC.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtClaC.Size = New System.Drawing.Size(219, 20)
        Me.txtClaC.TabIndex = 2
        '
        'txtClaN
        '
        Me.txtClaN.Location = New System.Drawing.Point(156, 38)
        Me.txtClaN.MaxLength = 10
        Me.txtClaN.Name = "txtClaN"
        Me.txtClaN.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtClaN.Size = New System.Drawing.Size(219, 20)
        Me.txtClaN.TabIndex = 1
        '
        'txtCla
        '
        Me.txtCla.Location = New System.Drawing.Point(156, 17)
        Me.txtCla.MaxLength = 10
        Me.txtCla.Name = "txtCla"
        Me.txtCla.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtCla.Size = New System.Drawing.Size(219, 20)
        Me.txtCla.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(15, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Confirmar clave nueva:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(15, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Ingrese clave nueva:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(15, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ingrese clave actual:"
        '
        'WCambiarClave
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(394, 123)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnCambiar)
        Me.Controls.Add(Me.txtClaC)
        Me.Controls.Add(Me.txtClaN)
        Me.Controls.Add(Me.txtCla)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "WCambiarClave"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnCambiar As System.Windows.Forms.Button
    Friend WithEvents txtClaC As System.Windows.Forms.TextBox
    Friend WithEvents txtClaN As System.Windows.Forms.TextBox
    Friend WithEvents txtCla As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
