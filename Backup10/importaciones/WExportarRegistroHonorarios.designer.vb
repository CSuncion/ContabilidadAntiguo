<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WExportarRegistroHonorarios
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
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.DgvRegContabDeta = New System.Windows.Forms.DataGridView
        Me.DgvRegContabCabe = New System.Windows.Forms.DataGridView
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.tslEstadoExp = New System.Windows.Forms.ToolStripStatusLabel
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtRuta = New System.Windows.Forms.TextBox
        Me.BtnBuscar = New System.Windows.Forms.Button
        Me.TxtNomArchivo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtCodEmp = New System.Windows.Forms.TextBox
        Me.txtNomEmp = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        CType(Me.DgvRegContabDeta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvRegContabCabe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtpDesde
        '
        Me.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDesde.Location = New System.Drawing.Point(105, 49)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(135, 20)
        Me.dtpDesde.TabIndex = 106
        '
        'dtpHasta
        '
        Me.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpHasta.Location = New System.Drawing.Point(105, 84)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(135, 20)
        Me.dtpHasta.TabIndex = 105
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(35, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 104
        Me.Label3.Text = "Hasta :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 103
        Me.Label1.Text = "Desde :"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Presentacion.My.Resources.Resources.action_stop
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(316, 74)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(100, 23)
        Me.btnCancelar.TabIndex = 107
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.Presentacion.My.Resources.Resources.apply
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(316, 49)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(100, 23)
        Me.btnAceptar.TabIndex = 102
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'DgvRegContabDeta
        '
        Me.DgvRegContabDeta.BackgroundColor = System.Drawing.Color.White
        Me.DgvRegContabDeta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvRegContabDeta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvRegContabDeta.Location = New System.Drawing.Point(218, 204)
        Me.DgvRegContabDeta.Name = "DgvRegContabDeta"
        Me.DgvRegContabDeta.Size = New System.Drawing.Size(36, 47)
        Me.DgvRegContabDeta.TabIndex = 109
        Me.DgvRegContabDeta.Visible = False
        '
        'DgvRegContabCabe
        '
        Me.DgvRegContabCabe.BackgroundColor = System.Drawing.Color.White
        Me.DgvRegContabCabe.Location = New System.Drawing.Point(166, 204)
        Me.DgvRegContabCabe.Name = "DgvRegContabCabe"
        Me.DgvRegContabCabe.ReadOnly = True
        Me.DgvRegContabCabe.Size = New System.Drawing.Size(32, 39)
        Me.DgvRegContabCabe.TabIndex = 108
        Me.DgvRegContabCabe.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tslEstadoExp})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 195)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(512, 22)
        Me.StatusStrip1.TabIndex = 112
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tslEstadoExp
        '
        Me.tslEstadoExp.Name = "tslEstadoExp"
        Me.tslEstadoExp.Size = New System.Drawing.Size(10, 17)
        Me.tslEstadoExp.Text = "."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(35, 125)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 113
        Me.Label2.Text = "Guardar En:"
        '
        'TxtRuta
        '
        Me.TxtRuta.Location = New System.Drawing.Point(119, 125)
        Me.TxtRuta.Name = "TxtRuta"
        Me.TxtRuta.ReadOnly = True
        Me.TxtRuta.Size = New System.Drawing.Size(297, 20)
        Me.TxtRuta.TabIndex = 114
        '
        'BtnBuscar
        '
        Me.BtnBuscar.Location = New System.Drawing.Point(423, 121)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.BtnBuscar.TabIndex = 115
        Me.BtnBuscar.Text = "..."
        Me.BtnBuscar.UseVisualStyleBackColor = True
        '
        'TxtNomArchivo
        '
        Me.TxtNomArchivo.Location = New System.Drawing.Point(143, 157)
        Me.TxtNomArchivo.Name = "TxtNomArchivo"
        Me.TxtNomArchivo.Size = New System.Drawing.Size(273, 20)
        Me.TxtNomArchivo.TabIndex = 117
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(35, 157)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 13)
        Me.Label4.TabIndex = 116
        Me.Label4.Text = "Nombre Archivo :"
        '
        'TxtCodEmp
        '
        Me.TxtCodEmp.Location = New System.Drawing.Point(105, 18)
        Me.TxtCodEmp.Name = "TxtCodEmp"
        Me.TxtCodEmp.ReadOnly = True
        Me.TxtCodEmp.Size = New System.Drawing.Size(55, 20)
        Me.TxtCodEmp.TabIndex = 254
        Me.TxtCodEmp.Tag = "0"
        '
        'txtNomEmp
        '
        Me.txtNomEmp.Location = New System.Drawing.Point(171, 18)
        Me.txtNomEmp.Name = "txtNomEmp"
        Me.txtNomEmp.ReadOnly = True
        Me.txtNomEmp.Size = New System.Drawing.Size(245, 20)
        Me.txtNomEmp.TabIndex = 252
        Me.txtNomEmp.Tag = "1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(35, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 253
        Me.Label6.Text = "Empresa"
        '
        'WExportarRegistroHonorarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(512, 217)
        Me.Controls.Add(Me.TxtCodEmp)
        Me.Controls.Add(Me.txtNomEmp)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtNomArchivo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BtnBuscar)
        Me.Controls.Add(Me.TxtRuta)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.DgvRegContabDeta)
        Me.Controls.Add(Me.DgvRegContabCabe)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.dtpDesde)
        Me.Controls.Add(Me.dtpHasta)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAceptar)
        Me.MaximizeBox = False
        Me.Name = "WExportarRegistroHonorarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Exportar Registro Honorarios"
        CType(Me.DgvRegContabDeta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvRegContabCabe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents dtpDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents DgvRegContabDeta As System.Windows.Forms.DataGridView
    Friend WithEvents DgvRegContabCabe As System.Windows.Forms.DataGridView
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tslEstadoExp As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtRuta As System.Windows.Forms.TextBox
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents TxtNomArchivo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtCodEmp As System.Windows.Forms.TextBox
    Friend WithEvents txtNomEmp As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
