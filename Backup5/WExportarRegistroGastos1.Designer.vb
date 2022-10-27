<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WExportarRegistroGastos1
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
        Me.DgvRegContabDeta = New System.Windows.Forms.DataGridView
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.DgvRegContabCabe = New System.Windows.Forms.DataGridView
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.tslEstadoExp = New System.Windows.Forms.ToolStripStatusLabel
        CType(Me.DgvRegContabDeta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvRegContabCabe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgvRegContabDeta
        '
        Me.DgvRegContabDeta.BackgroundColor = System.Drawing.Color.White
        Me.DgvRegContabDeta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvRegContabDeta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvRegContabDeta.Location = New System.Drawing.Point(60, 205)
        Me.DgvRegContabDeta.Name = "DgvRegContabDeta"
        Me.DgvRegContabDeta.Size = New System.Drawing.Size(150, 56)
        Me.DgvRegContabDeta.TabIndex = 110
        Me.DgvRegContabDeta.Visible = False
        '
        'dtpDesde
        '
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesde.Location = New System.Drawing.Point(95, 22)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(135, 20)
        Me.dtpDesde.TabIndex = 108
        '
        'dtpHasta
        '
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta.Location = New System.Drawing.Point(95, 57)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(135, 20)
        Me.dtpHasta.TabIndex = 107
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(38, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 106
        Me.Label3.Text = "Hasta :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 105
        Me.Label1.Text = "Desde :"
        '
        'DgvRegContabCabe
        '
        Me.DgvRegContabCabe.BackgroundColor = System.Drawing.Color.White
        Me.DgvRegContabCabe.Location = New System.Drawing.Point(60, 143)
        Me.DgvRegContabCabe.Name = "DgvRegContabCabe"
        Me.DgvRegContabCabe.ReadOnly = True
        Me.DgvRegContabCabe.Size = New System.Drawing.Size(128, 56)
        Me.DgvRegContabCabe.TabIndex = 103
        Me.DgvRegContabCabe.Visible = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Presentacion.My.Resources.Resources.action_stop
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(268, 44)
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
        Me.btnAceptar.Location = New System.Drawing.Point(268, 19)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(100, 23)
        Me.btnAceptar.TabIndex = 104
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslEstadoExp})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 100)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(399, 22)
        Me.StatusStrip1.TabIndex = 111
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tslEstadoExp
        '
        Me.tslEstadoExp.Name = "tslEstadoExp"
        Me.tslEstadoExp.Size = New System.Drawing.Size(11, 17)
        Me.tslEstadoExp.Text = "."
        '
        'WExportarRegistroGastos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(399, 122)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.DgvRegContabDeta)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.dtpDesde)
        Me.Controls.Add(Me.dtpHasta)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.DgvRegContabCabe)
        Me.MaximizeBox = False
        Me.Name = "WExportarRegistroGastos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Exportar Registro Gastos"
        CType(Me.DgvRegContabDeta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvRegContabCabe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DgvRegContabDeta As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents dtpDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents DgvRegContabCabe As System.Windows.Forms.DataGridView
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tslEstadoExp As System.Windows.Forms.ToolStripStatusLabel
End Class
