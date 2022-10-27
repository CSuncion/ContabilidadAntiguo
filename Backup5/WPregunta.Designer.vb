<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WPregunta
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
        Me.gbPs = New System.Windows.Forms.GroupBox
        Me.lblPregunta = New System.Windows.Forms.Label
        Me.txtRpta = New System.Windows.Forms.TextBox
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnIngresar = New System.Windows.Forms.Button
        Me.gbPs.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbPs
        '
        Me.gbPs.Controls.Add(Me.lblPregunta)
        Me.gbPs.Controls.Add(Me.txtRpta)
        Me.gbPs.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.gbPs.Location = New System.Drawing.Point(12, 12)
        Me.gbPs.Name = "gbPs"
        Me.gbPs.Size = New System.Drawing.Size(339, 65)
        Me.gbPs.TabIndex = 10
        Me.gbPs.TabStop = False
        Me.gbPs.Text = "Pregunta Secreta"
        '
        'lblPregunta
        '
        Me.lblPregunta.AutoSize = True
        Me.lblPregunta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPregunta.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPregunta.Location = New System.Drawing.Point(7, 16)
        Me.lblPregunta.Name = "lblPregunta"
        Me.lblPregunta.Size = New System.Drawing.Size(274, 15)
        Me.lblPregunta.TabIndex = 0
        Me.lblPregunta.Text = "¿Cual es tu profesor favorito que mas recuerdas?"
        '
        'txtRpta
        '
        Me.txtRpta.Location = New System.Drawing.Point(10, 34)
        Me.txtRpta.Name = "txtRpta"
        Me.txtRpta.Size = New System.Drawing.Size(316, 20)
        Me.txtRpta.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Presentacion.My.Resources.Resources.action_stop
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(257, 83)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(97, 23)
        Me.btnCancelar.TabIndex = 12
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnIngresar
        '
        Me.btnIngresar.FlatAppearance.BorderSize = 4
        Me.btnIngresar.Image = Global.Presentacion.My.Resources.Resources.icon_key
        Me.btnIngresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIngresar.Location = New System.Drawing.Point(147, 83)
        Me.btnIngresar.Name = "btnIngresar"
        Me.btnIngresar.Size = New System.Drawing.Size(111, 23)
        Me.btnIngresar.TabIndex = 11
        Me.btnIngresar.Text = "Obtener Clave"
        Me.btnIngresar.UseVisualStyleBackColor = True
        '
        'WPregunta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(367, 122)
        Me.Controls.Add(Me.gbPs)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnIngresar)
        Me.MaximizeBox = False
        Me.Name = "WPregunta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WPregunta"
        Me.gbPs.ResumeLayout(False)
        Me.gbPs.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbPs As System.Windows.Forms.GroupBox
    Friend WithEvents lblPregunta As System.Windows.Forms.Label
    Friend WithEvents txtRpta As System.Windows.Forms.TextBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnIngresar As System.Windows.Forms.Button
End Class
