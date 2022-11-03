<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WAsignarEmpresas
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.txtCodUsu = New System.Windows.Forms.TextBox
        Me.txtNomUsu = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnSalir = New System.Windows.Forms.Button
        Me.btnQuitarTodos = New System.Windows.Forms.Button
        Me.btnQuita = New System.Windows.Forms.Button
        Me.btnAgrega = New System.Windows.Forms.Button
        Me.btnAgregaTodos = New System.Windows.Forms.Button
        Me.dgvAsig = New System.Windows.Forms.DataGridView
        Me.dgvNoAut = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        CType(Me.dgvAsig, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvNoAut, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCodUsu
        '
        Me.txtCodUsu.BackColor = System.Drawing.SystemColors.Control
        Me.txtCodUsu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodUsu.Location = New System.Drawing.Point(75, 12)
        Me.txtCodUsu.MaxLength = 30
        Me.txtCodUsu.Name = "txtCodUsu"
        Me.txtCodUsu.ReadOnly = True
        Me.txtCodUsu.Size = New System.Drawing.Size(84, 20)
        Me.txtCodUsu.TabIndex = 186
        Me.txtCodUsu.Tag = "0"
        Me.txtCodUsu.Text = "LCruz"
        '
        'txtNomUsu
        '
        Me.txtNomUsu.BackColor = System.Drawing.SystemColors.Control
        Me.txtNomUsu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNomUsu.Location = New System.Drawing.Point(161, 12)
        Me.txtNomUsu.MaxLength = 30
        Me.txtNomUsu.Name = "txtNomUsu"
        Me.txtNomUsu.ReadOnly = True
        Me.txtNomUsu.Size = New System.Drawing.Size(376, 20)
        Me.txtNomUsu.TabIndex = 185
        Me.txtNomUsu.Tag = "0"
        Me.txtNomUsu.Text = "Cruz Huamanchumo Luis Ivan"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(6, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 184
        Me.Label6.Text = "Usuario:"
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(412, 334)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(125, 23)
        Me.btnSalir.TabIndex = 232
        Me.btnSalir.Tag = "8"
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnQuitarTodos
        '
        Me.btnQuitarTodos.Location = New System.Drawing.Point(246, 207)
        Me.btnQuitarTodos.Name = "btnQuitarTodos"
        Me.btnQuitarTodos.Size = New System.Drawing.Size(46, 23)
        Me.btnQuitarTodos.TabIndex = 231
        Me.btnQuitarTodos.Text = "<<"
        Me.btnQuitarTodos.UseVisualStyleBackColor = True
        '
        'btnQuita
        '
        Me.btnQuita.Location = New System.Drawing.Point(246, 183)
        Me.btnQuita.Name = "btnQuita"
        Me.btnQuita.Size = New System.Drawing.Size(46, 23)
        Me.btnQuita.TabIndex = 230
        Me.btnQuita.Text = "<"
        Me.btnQuita.UseVisualStyleBackColor = True
        '
        'btnAgrega
        '
        Me.btnAgrega.Location = New System.Drawing.Point(246, 149)
        Me.btnAgrega.Name = "btnAgrega"
        Me.btnAgrega.Size = New System.Drawing.Size(46, 23)
        Me.btnAgrega.TabIndex = 229
        Me.btnAgrega.Text = ">"
        Me.btnAgrega.UseVisualStyleBackColor = True
        '
        'btnAgregaTodos
        '
        Me.btnAgregaTodos.Location = New System.Drawing.Point(246, 125)
        Me.btnAgregaTodos.Name = "btnAgregaTodos"
        Me.btnAgregaTodos.Size = New System.Drawing.Size(46, 23)
        Me.btnAgregaTodos.TabIndex = 228
        Me.btnAgregaTodos.Text = ">>"
        Me.btnAgregaTodos.UseVisualStyleBackColor = True
        '
        'dgvAsig
        '
        Me.dgvAsig.AllowUserToResizeColumns = False
        Me.dgvAsig.AllowUserToResizeRows = False
        Me.dgvAsig.BackgroundColor = System.Drawing.Color.White
        Me.dgvAsig.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAsig.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAsig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAsig.ColumnHeadersVisible = False
        Me.dgvAsig.GridColor = System.Drawing.Color.White
        Me.dgvAsig.Location = New System.Drawing.Point(302, 78)
        Me.dgvAsig.MultiSelect = False
        Me.dgvAsig.Name = "dgvAsig"
        Me.dgvAsig.RowHeadersVisible = False
        Me.dgvAsig.RowHeadersWidth = 10
        Me.dgvAsig.Size = New System.Drawing.Size(220, 197)
        Me.dgvAsig.TabIndex = 233
        '
        'dgvNoAut
        '
        Me.dgvNoAut.AllowUserToResizeColumns = False
        Me.dgvNoAut.AllowUserToResizeRows = False
        Me.dgvNoAut.BackgroundColor = System.Drawing.Color.White
        Me.dgvNoAut.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvNoAut.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvNoAut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNoAut.ColumnHeadersVisible = False
        Me.dgvNoAut.GridColor = System.Drawing.Color.White
        Me.dgvNoAut.Location = New System.Drawing.Point(18, 78)
        Me.dgvNoAut.MultiSelect = False
        Me.dgvNoAut.Name = "dgvNoAut"
        Me.dgvNoAut.RowHeadersVisible = False
        Me.dgvNoAut.RowHeadersWidth = 10
        Me.dgvNoAut.Size = New System.Drawing.Size(220, 197)
        Me.dgvNoAut.TabIndex = 233
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(18, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 13)
        Me.Label1.TabIndex = 234
        Me.Label1.Text = "Empresas no Autorizadas"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(299, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 13)
        Me.Label2.TabIndex = 235
        Me.Label2.Text = "Empresas Asignadas"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(18, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(510, 33)
        Me.Label3.TabIndex = 236
        Me.Label3.Text = "En esta pantalla se puede asignar las empresas a donde el usuario puede ingresar " & _
            ",estas empresas son " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "las que se muestran en la lista de Empresas Asignadas"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgvAsig)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnAgregaTodos)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnAgrega)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnQuita)
        Me.GroupBox1.Controls.Add(Me.btnQuitarTodos)
        Me.GroupBox1.Controls.Add(Me.dgvNoAut)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(534, 290)
        Me.GroupBox1.TabIndex = 237
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Asignar"
        '
        'WAsignarEmpresas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(550, 364)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.txtCodUsu)
        Me.Controls.Add(Me.txtNomUsu)
        Me.Controls.Add(Me.Label6)
        Me.ForeColor = System.Drawing.Color.Black
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "WAsignarEmpresas"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignar Empresas"
        CType(Me.dgvAsig, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvNoAut, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
      Friend WithEvents txtCodUsu As System.Windows.Forms.TextBox
      Friend WithEvents txtNomUsu As System.Windows.Forms.TextBox
      Friend WithEvents Label6 As System.Windows.Forms.Label
      Friend WithEvents btnSalir As System.Windows.Forms.Button
      Friend WithEvents btnQuitarTodos As System.Windows.Forms.Button
      Friend WithEvents btnQuita As System.Windows.Forms.Button
      Friend WithEvents btnAgrega As System.Windows.Forms.Button
      Friend WithEvents btnAgregaTodos As System.Windows.Forms.Button
      Friend WithEvents dgvAsig As System.Windows.Forms.DataGridView
      Friend WithEvents dgvNoAut As System.Windows.Forms.DataGridView
      Friend WithEvents Label1 As System.Windows.Forms.Label
      Friend WithEvents Label2 As System.Windows.Forms.Label
      Friend WithEvents Label3 As System.Windows.Forms.Label
      Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
