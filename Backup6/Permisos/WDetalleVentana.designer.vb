<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WDetalleVentana
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
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Me.Label1 = New System.Windows.Forms.Label
            Me.txtNom = New System.Windows.Forms.TextBox
            Me.txtCod = New System.Windows.Forms.TextBox
            Me.lblTitCon = New System.Windows.Forms.Label
            Me.DgvOpc = New System.Windows.Forms.DataGridView
            Me.btnAgregar = New System.Windows.Forms.Button
            Me.btnQuitar = New System.Windows.Forms.Button
            Me.btnSalir = New System.Windows.Forms.Button
            CType(Me.DgvOpc, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
            Me.Label1.Location = New System.Drawing.Point(12, 19)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(62, 13)
            Me.Label1.TabIndex = 16
            Me.Label1.Text = "Ventana :"
            '
            'txtNom
            '
            Me.txtNom.BackColor = System.Drawing.SystemColors.Control
            Me.txtNom.Location = New System.Drawing.Point(190, 16)
            Me.txtNom.Name = "txtNom"
            Me.txtNom.ReadOnly = True
            Me.txtNom.Size = New System.Drawing.Size(241, 20)
            Me.txtNom.TabIndex = 14
            Me.txtNom.Tag = "1"
            '
            'txtCod
            '
            Me.txtCod.BackColor = System.Drawing.SystemColors.Control
            Me.txtCod.Location = New System.Drawing.Point(80, 16)
            Me.txtCod.Name = "txtCod"
            Me.txtCod.ReadOnly = True
            Me.txtCod.Size = New System.Drawing.Size(109, 20)
            Me.txtCod.TabIndex = 13
            Me.txtCod.Tag = "0"
            '
            'lblTitCon
            '
            Me.lblTitCon.BackColor = System.Drawing.Color.Gray
            Me.lblTitCon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTitCon.ForeColor = System.Drawing.Color.White
            Me.lblTitCon.ImeMode = System.Windows.Forms.ImeMode.NoControl
            Me.lblTitCon.Location = New System.Drawing.Point(12, 42)
            Me.lblTitCon.Name = "lblTitCon"
            Me.lblTitCon.Size = New System.Drawing.Size(419, 24)
            Me.lblTitCon.TabIndex = 224
            Me.lblTitCon.Text = "OPCIONES"
            Me.lblTitCon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'DgvOpc
            '
            Me.DgvOpc.BackgroundColor = System.Drawing.Color.White
            Me.DgvOpc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DgvOpc.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
            Me.DgvOpc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DgvOpc.Location = New System.Drawing.Point(12, 69)
            Me.DgvOpc.MultiSelect = False
            Me.DgvOpc.Name = "DgvOpc"
            Me.DgvOpc.Size = New System.Drawing.Size(419, 197)
            Me.DgvOpc.TabIndex = 225
            '
            'btnAgregar
            '
            Me.btnAgregar.Location = New System.Drawing.Point(12, 270)
            Me.btnAgregar.Name = "btnAgregar"
            Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
            Me.btnAgregar.TabIndex = 226
            Me.btnAgregar.Text = "Agregar"
            Me.btnAgregar.UseVisualStyleBackColor = True
            '
            'btnQuitar
            '
            Me.btnQuitar.Location = New System.Drawing.Point(86, 270)
            Me.btnQuitar.Name = "btnQuitar"
            Me.btnQuitar.Size = New System.Drawing.Size(75, 23)
            Me.btnQuitar.TabIndex = 227
            Me.btnQuitar.Text = "Quitar"
            Me.btnQuitar.UseVisualStyleBackColor = True
            '
            'btnSalir
            '
            Me.btnSalir.Location = New System.Drawing.Point(356, 270)
            Me.btnSalir.Name = "btnSalir"
            Me.btnSalir.Size = New System.Drawing.Size(75, 23)
            Me.btnSalir.TabIndex = 228
            Me.btnSalir.Text = "Salir"
            Me.btnSalir.UseVisualStyleBackColor = True
            '
            'WDetalleVentana
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BackColor = System.Drawing.SystemColors.ControlLight
            Me.ClientSize = New System.Drawing.Size(443, 305)
            Me.Controls.Add(Me.btnSalir)
            Me.Controls.Add(Me.btnQuitar)
            Me.Controls.Add(Me.btnAgregar)
            Me.Controls.Add(Me.DgvOpc)
            Me.Controls.Add(Me.lblTitCon)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.txtNom)
            Me.Controls.Add(Me.txtCod)
            Me.MaximizeBox = False
            Me.Name = "WDetalleVentana"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Opciones de Ventana"
            CType(Me.DgvOpc, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

      End Sub
      Friend WithEvents Label1 As System.Windows.Forms.Label
      Friend WithEvents txtNom As System.Windows.Forms.TextBox
      Friend WithEvents txtCod As System.Windows.Forms.TextBox
      Friend WithEvents lblTitCon As System.Windows.Forms.Label
      Friend WithEvents DgvOpc As System.Windows.Forms.DataGridView
      Friend WithEvents btnAgregar As System.Windows.Forms.Button
      Friend WithEvents btnQuitar As System.Windows.Forms.Button
      Friend WithEvents btnSalir As System.Windows.Forms.Button
End Class
