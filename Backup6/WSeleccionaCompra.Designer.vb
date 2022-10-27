<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WSeleccionaCompra
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.gbTipoCompra = New System.Windows.Forms.GroupBox
        Me.rbtper = New System.Windows.Forms.RadioButton
        Me.rbtDua = New System.Windows.Forms.RadioButton
        Me.rbtImp = New System.Windows.Forms.RadioButton
        Me.rbtCom = New System.Windows.Forms.RadioButton
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.gbTipoCompra.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbTipoCompra
        '
        Me.gbTipoCompra.Controls.Add(Me.rbtper)
        Me.gbTipoCompra.Controls.Add(Me.rbtDua)
        Me.gbTipoCompra.Controls.Add(Me.rbtImp)
        Me.gbTipoCompra.Controls.Add(Me.rbtCom)
        Me.gbTipoCompra.Location = New System.Drawing.Point(12, 12)
        Me.gbTipoCompra.Name = "gbTipoCompra"
        Me.gbTipoCompra.Size = New System.Drawing.Size(326, 35)
        Me.gbTipoCompra.TabIndex = 28
        Me.gbTipoCompra.TabStop = False
        Me.gbTipoCompra.Tag = "7"
        '
        'rbtper
        '
        Me.rbtper.AutoSize = True
        Me.rbtper.Location = New System.Drawing.Point(220, 12)
        Me.rbtper.Name = "rbtper"
        Me.rbtper.Size = New System.Drawing.Size(79, 17)
        Me.rbtper.TabIndex = 103
        Me.rbtper.Tag = "9"
        Me.rbtper.Text = "Percepcion"
        Me.rbtper.UseVisualStyleBackColor = True
        '
        'rbtDua
        '
        Me.rbtDua.AutoSize = True
        Me.rbtDua.Location = New System.Drawing.Point(167, 12)
        Me.rbtDua.Name = "rbtDua"
        Me.rbtDua.Size = New System.Drawing.Size(45, 17)
        Me.rbtDua.TabIndex = 102
        Me.rbtDua.Tag = "9"
        Me.rbtDua.Text = "Dua"
        Me.rbtDua.UseVisualStyleBackColor = True
        '
        'rbtImp
        '
        Me.rbtImp.AutoSize = True
        Me.rbtImp.Location = New System.Drawing.Point(82, 12)
        Me.rbtImp.Name = "rbtImp"
        Me.rbtImp.Size = New System.Drawing.Size(80, 17)
        Me.rbtImp.TabIndex = 101
        Me.rbtImp.Tag = "9"
        Me.rbtImp.Text = "Importacion"
        Me.rbtImp.UseVisualStyleBackColor = True
        '
        'rbtCom
        '
        Me.rbtCom.AutoSize = True
        Me.rbtCom.Checked = True
        Me.rbtCom.Location = New System.Drawing.Point(10, 12)
        Me.rbtCom.Name = "rbtCom"
        Me.rbtCom.Size = New System.Drawing.Size(66, 17)
        Me.rbtCom.TabIndex = 100
        Me.rbtCom.TabStop = True
        Me.rbtCom.Tag = "8"
        Me.rbtCom.Text = "Compras"
        Me.rbtCom.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Presentacion.My.Resources.Resources.action_stop
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(188, 53)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(82, 23)
        Me.btnCancelar.TabIndex = 27
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.Presentacion.My.Resources.Resources.apply
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(103, 53)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(82, 23)
        Me.btnAceptar.TabIndex = 26
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'WSeleccionaCompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(353, 98)
        Me.ControlBox = False
        Me.Controls.Add(Me.gbTipoCompra)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "WSeleccionaCompra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WSeleccionaCompra"
        Me.gbTipoCompra.ResumeLayout(False)
        Me.gbTipoCompra.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbTipoCompra As System.Windows.Forms.GroupBox
    Friend WithEvents rbtDua As System.Windows.Forms.RadioButton
    Friend WithEvents rbtImp As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCom As System.Windows.Forms.RadioButton
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents rbtper As System.Windows.Forms.RadioButton
End Class
