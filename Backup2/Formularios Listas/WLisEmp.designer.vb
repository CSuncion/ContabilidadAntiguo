<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WLisEmp
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
            Me.btnSeleccionar = New System.Windows.Forms.Button
            Me.DgvLista = New System.Windows.Forms.DataGridView
            Me.gbBus = New System.Windows.Forms.GroupBox
            Me.txtBus = New System.Windows.Forms.TextBox
            CType(Me.DgvLista, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.gbBus.SuspendLayout()
            Me.SuspendLayout()
            '
            'btnCancelar
            '
            Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnCancelar.Location = New System.Drawing.Point(191, 391)
            Me.btnCancelar.Name = "btnCancelar"
            Me.btnCancelar.Size = New System.Drawing.Size(154, 23)
            Me.btnCancelar.TabIndex = 106
            Me.btnCancelar.Text = "Cancelar"
            Me.btnCancelar.UseVisualStyleBackColor = True
            '
            'btnSeleccionar
            '
            Me.btnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnSeleccionar.Location = New System.Drawing.Point(33, 391)
            Me.btnSeleccionar.Name = "btnSeleccionar"
            Me.btnSeleccionar.Size = New System.Drawing.Size(159, 23)
            Me.btnSeleccionar.TabIndex = 105
            Me.btnSeleccionar.Text = "Seleccionar"
            Me.btnSeleccionar.UseVisualStyleBackColor = True
            '
            'DgvLista
            '
            Me.DgvLista.BackgroundColor = System.Drawing.Color.White
            Me.DgvLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.DgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DgvLista.Location = New System.Drawing.Point(12, 49)
            Me.DgvLista.Name = "DgvLista"
            Me.DgvLista.Size = New System.Drawing.Size(356, 336)
            Me.DgvLista.TabIndex = 104
            '
            'gbBus
            '
            Me.gbBus.Controls.Add(Me.txtBus)
            Me.gbBus.Location = New System.Drawing.Point(12, 3)
            Me.gbBus.Name = "gbBus"
            Me.gbBus.Size = New System.Drawing.Size(356, 42)
            Me.gbBus.TabIndex = 103
            Me.gbBus.TabStop = False
            Me.gbBus.Text = "GroupBox1"
            '
            'txtBus
            '
            Me.txtBus.Location = New System.Drawing.Point(14, 16)
            Me.txtBus.Name = "txtBus"
            Me.txtBus.Size = New System.Drawing.Size(330, 20)
            Me.txtBus.TabIndex = 0
            '
            'WLisUsu
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BackColor = System.Drawing.SystemColors.ControlLight
            Me.ClientSize = New System.Drawing.Size(380, 428)
            Me.ControlBox = False
            Me.Controls.Add(Me.btnCancelar)
            Me.Controls.Add(Me.btnSeleccionar)
            Me.Controls.Add(Me.DgvLista)
            Me.Controls.Add(Me.gbBus)
            Me.Name = "WLisUsu"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "WLisUsu"
            CType(Me.DgvLista, System.ComponentModel.ISupportInitialize).EndInit()
            Me.gbBus.ResumeLayout(False)
            Me.gbBus.PerformLayout()
            Me.ResumeLayout(False)

      End Sub
      Friend WithEvents btnCancelar As System.Windows.Forms.Button
      Friend WithEvents btnSeleccionar As System.Windows.Forms.Button
      Friend WithEvents DgvLista As System.Windows.Forms.DataGridView
      Friend WithEvents gbBus As System.Windows.Forms.GroupBox
      Friend WithEvents txtBus As System.Windows.Forms.TextBox
End Class
