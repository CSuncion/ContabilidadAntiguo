<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WFitrarPeriodo
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
              Me.btnAceptar = New System.Windows.Forms.Button
              Me.Label1 = New System.Windows.Forms.Label
              Me.txtPeriodo = New System.Windows.Forms.TextBox
              Me.SuspendLayout()
              '
              'btnCancelar
              '
              Me.btnCancelar.Image = Global.Presentacion.My.Resources.Resources.action_stop
              Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
              Me.btnCancelar.Location = New System.Drawing.Point(180, 38)
              Me.btnCancelar.Name = "btnCancelar"
              Me.btnCancelar.Size = New System.Drawing.Size(100, 23)
              Me.btnCancelar.TabIndex = 109
              Me.btnCancelar.Text = "Cancelar"
              Me.btnCancelar.UseVisualStyleBackColor = True
              '
              'btnAceptar
              '
              Me.btnAceptar.Image = Global.Presentacion.My.Resources.Resources.apply
              Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
              Me.btnAceptar.Location = New System.Drawing.Point(180, 13)
              Me.btnAceptar.Name = "btnAceptar"
              Me.btnAceptar.Size = New System.Drawing.Size(100, 23)
              Me.btnAceptar.TabIndex = 108
              Me.btnAceptar.Text = "Aceptar"
              Me.btnAceptar.UseVisualStyleBackColor = True
              '
              'Label1
              '
              Me.Label1.AutoSize = True
              Me.Label1.Location = New System.Drawing.Point(8, 19)
              Me.Label1.Name = "Label1"
              Me.Label1.Size = New System.Drawing.Size(43, 13)
              Me.Label1.TabIndex = 110
              Me.Label1.Text = "Perido :"
              '
              'txtPeriodo
              '
              Me.txtPeriodo.Location = New System.Drawing.Point(57, 16)
              Me.txtPeriodo.MaxLength = 6
              Me.txtPeriodo.Name = "txtPeriodo"
              Me.txtPeriodo.Size = New System.Drawing.Size(100, 20)
              Me.txtPeriodo.TabIndex = 111
              '
              'WFitrarPeriodo
              '
              Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
              Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
              Me.BackColor = System.Drawing.SystemColors.ControlLight
              Me.ClientSize = New System.Drawing.Size(292, 75)
              Me.Controls.Add(Me.txtPeriodo)
              Me.Controls.Add(Me.Label1)
              Me.Controls.Add(Me.btnCancelar)
              Me.Controls.Add(Me.btnAceptar)
              Me.MaximizeBox = False
              Me.Name = "WFitrarPeriodo"
              Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
              Me.Text = "Filtrar por Periodo "
              Me.ResumeLayout(False)
              Me.PerformLayout()

       End Sub
       Friend WithEvents btnCancelar As System.Windows.Forms.Button
       Friend WithEvents btnAceptar As System.Windows.Forms.Button
       Friend WithEvents Label1 As System.Windows.Forms.Label
       Friend WithEvents txtPeriodo As System.Windows.Forms.TextBox
End Class
