<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WPermisos
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WPermisos))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnSalir = New System.Windows.Forms.Button
        Me.txtCodUsu = New System.Windows.Forms.TextBox
        Me.txtNomUsu = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.lblTitulo = New System.Windows.Forms.Label
        Me.btnQuitarTodos = New System.Windows.Forms.Button
        Me.btnQuita = New System.Windows.Forms.Button
        Me.btnAgrega = New System.Windows.Forms.Button
        Me.btnAgregaTodos = New System.Windows.Forms.Button
        Me.DgvAccD = New System.Windows.Forms.DataGridView
        Me.dgvPer = New System.Windows.Forms.DataGridView
        Me.dgvVen = New System.Windows.Forms.DataGridView
        CType(Me.DgvAccD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvVen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSalir
        '
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalir.Location = New System.Drawing.Point(529, 304)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(125, 23)
        Me.btnSalir.TabIndex = 186
        Me.btnSalir.Tag = "8"
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'txtCodUsu
        '
        Me.txtCodUsu.BackColor = System.Drawing.SystemColors.Control
        Me.txtCodUsu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodUsu.Location = New System.Drawing.Point(77, 12)
        Me.txtCodUsu.MaxLength = 30
        Me.txtCodUsu.Name = "txtCodUsu"
        Me.txtCodUsu.ReadOnly = True
        Me.txtCodUsu.Size = New System.Drawing.Size(84, 20)
        Me.txtCodUsu.TabIndex = 183
        Me.txtCodUsu.Tag = "0"
        Me.txtCodUsu.Text = "LCruz"
        '
        'txtNomUsu
        '
        Me.txtNomUsu.BackColor = System.Drawing.SystemColors.Control
        Me.txtNomUsu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNomUsu.Location = New System.Drawing.Point(163, 12)
        Me.txtNomUsu.MaxLength = 30
        Me.txtNomUsu.Name = "txtNomUsu"
        Me.txtNomUsu.ReadOnly = True
        Me.txtNomUsu.Size = New System.Drawing.Size(491, 20)
        Me.txtNomUsu.TabIndex = 182
        Me.txtNomUsu.Tag = "0"
        Me.txtNomUsu.Text = "Cruz Huamanchumo Luis Ivan"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label6.Location = New System.Drawing.Point(8, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 181
        Me.Label6.Text = "Usuario:"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "folder_closed16_h.ico")
        Me.ImageList1.Images.SetKeyName(1, "application_form.png")
        '
        'lblTitulo
        '
        Me.lblTitulo.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.White
        Me.lblTitulo.Location = New System.Drawing.Point(10, 37)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(644, 25)
        Me.lblTitulo.TabIndex = 179
        Me.lblTitulo.Text = "Dando Permisos a la ventana :Usuarios"
        Me.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnQuitarTodos
        '
        Me.btnQuitarTodos.Location = New System.Drawing.Point(443, 210)
        Me.btnQuitarTodos.Name = "btnQuitarTodos"
        Me.btnQuitarTodos.Size = New System.Drawing.Size(40, 23)
        Me.btnQuitarTodos.TabIndex = 176
        Me.btnQuitarTodos.Text = "<<"
        Me.btnQuitarTodos.UseVisualStyleBackColor = True
        '
        'btnQuita
        '
        Me.btnQuita.Location = New System.Drawing.Point(443, 187)
        Me.btnQuita.Name = "btnQuita"
        Me.btnQuita.Size = New System.Drawing.Size(40, 23)
        Me.btnQuita.TabIndex = 175
        Me.btnQuita.Text = "<"
        Me.btnQuita.UseVisualStyleBackColor = True
        '
        'btnAgrega
        '
        Me.btnAgrega.Location = New System.Drawing.Point(443, 147)
        Me.btnAgrega.Name = "btnAgrega"
        Me.btnAgrega.Size = New System.Drawing.Size(40, 23)
        Me.btnAgrega.TabIndex = 174
        Me.btnAgrega.Text = ">"
        Me.btnAgrega.UseVisualStyleBackColor = True
        '
        'btnAgregaTodos
        '
        Me.btnAgregaTodos.Location = New System.Drawing.Point(443, 123)
        Me.btnAgregaTodos.Name = "btnAgregaTodos"
        Me.btnAgregaTodos.Size = New System.Drawing.Size(40, 23)
        Me.btnAgregaTodos.TabIndex = 173
        Me.btnAgregaTodos.Text = ">>"
        Me.btnAgregaTodos.UseVisualStyleBackColor = True
        '
        'DgvAccD
        '
        Me.DgvAccD.BackgroundColor = System.Drawing.Color.White
        Me.DgvAccD.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgvAccD.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgvAccD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvAccD.GridColor = System.Drawing.Color.White
        Me.DgvAccD.Location = New System.Drawing.Point(272, 65)
        Me.DgvAccD.MultiSelect = False
        Me.DgvAccD.Name = "DgvAccD"
        Me.DgvAccD.RowHeadersVisible = False
        Me.DgvAccD.RowHeadersWidth = 10
        Me.DgvAccD.Size = New System.Drawing.Size(165, 233)
        Me.DgvAccD.TabIndex = 226
        '
        'dgvPer
        '
        Me.dgvPer.BackgroundColor = System.Drawing.Color.White
        Me.dgvPer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPer.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPer.GridColor = System.Drawing.Color.White
        Me.dgvPer.Location = New System.Drawing.Point(489, 65)
        Me.dgvPer.MultiSelect = False
        Me.dgvPer.Name = "dgvPer"
        Me.dgvPer.RowHeadersVisible = False
        Me.dgvPer.RowHeadersWidth = 10
        Me.dgvPer.Size = New System.Drawing.Size(165, 233)
        Me.dgvPer.TabIndex = 227
        '
        'dgvVen
        '
        Me.dgvVen.BackgroundColor = System.Drawing.Color.White
        Me.dgvVen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVen.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvVen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVen.GridColor = System.Drawing.Color.White
        Me.dgvVen.Location = New System.Drawing.Point(12, 65)
        Me.dgvVen.MultiSelect = False
        Me.dgvVen.Name = "dgvVen"
        Me.dgvVen.RowHeadersVisible = False
        Me.dgvVen.RowHeadersWidth = 10
        Me.dgvVen.Size = New System.Drawing.Size(254, 233)
        Me.dgvVen.TabIndex = 228
        '
        'WPermisos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(668, 339)
        Me.Controls.Add(Me.dgvVen)
        Me.Controls.Add(Me.dgvPer)
        Me.Controls.Add(Me.DgvAccD)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.txtCodUsu)
        Me.Controls.Add(Me.txtNomUsu)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.btnQuitarTodos)
        Me.Controls.Add(Me.btnQuita)
        Me.Controls.Add(Me.btnAgrega)
        Me.Controls.Add(Me.btnAgregaTodos)
        Me.MaximizeBox = False
        Me.Name = "WPermisos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Permisos"
        CType(Me.DgvAccD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvVen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
      Friend WithEvents btnSalir As System.Windows.Forms.Button
      Friend WithEvents txtCodUsu As System.Windows.Forms.TextBox
      Friend WithEvents txtNomUsu As System.Windows.Forms.TextBox
      Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents btnQuitarTodos As System.Windows.Forms.Button
      Friend WithEvents btnQuita As System.Windows.Forms.Button
      Friend WithEvents btnAgrega As System.Windows.Forms.Button
      Friend WithEvents btnAgregaTodos As System.Windows.Forms.Button
    Friend WithEvents DgvAccD As System.Windows.Forms.DataGridView
      Friend WithEvents dgvPer As System.Windows.Forms.DataGridView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents dgvVen As System.Windows.Forms.DataGridView
End Class
