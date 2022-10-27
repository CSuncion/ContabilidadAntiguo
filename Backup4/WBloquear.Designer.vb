<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WBloquear
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtCla = New System.Windows.Forms.TextBox
        Me.lblUsu = New System.Windows.Forms.Label
        Me.btnIngresar = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ingrese Su Clave:"
        '
        'txtCla
        '
        Me.txtCla.Location = New System.Drawing.Point(15, 45)
        Me.txtCla.Name = "txtCla"
        Me.txtCla.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtCla.Size = New System.Drawing.Size(226, 20)
        Me.txtCla.TabIndex = 1
        '
        'lblUsu
        '
        Me.lblUsu.AutoSize = True
        Me.lblUsu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsu.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblUsu.Location = New System.Drawing.Point(12, 7)
        Me.lblUsu.Name = "lblUsu"
        Me.lblUsu.Size = New System.Drawing.Size(50, 15)
        Me.lblUsu.TabIndex = 2
        Me.lblUsu.Text = "Usuario"
        '
        'btnIngresar
        '
        Me.btnIngresar.Location = New System.Drawing.Point(247, 44)
        Me.btnIngresar.Name = "btnIngresar"
        Me.btnIngresar.Size = New System.Drawing.Size(75, 23)
        Me.btnIngresar.TabIndex = 3
        Me.btnIngresar.Text = "Ingresar"
        Me.btnIngresar.UseVisualStyleBackColor = True
        '
        'WBloquear
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(349, 80)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnIngresar)
        Me.Controls.Add(Me.lblUsu)
        Me.Controls.Add(Me.txtCla)
        Me.Controls.Add(Me.Label1)
        Me.Name = "WBloquear"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bloquear Sistema"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCla As System.Windows.Forms.TextBox
    Friend WithEvents lblUsu As System.Windows.Forms.Label
    Friend WithEvents btnIngresar As System.Windows.Forms.Button
End Class
