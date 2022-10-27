<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WListarFormatoContable
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WListarFormatoContable))
        Me.gbBus = New System.Windows.Forms.GroupBox
        Me.txtBus = New System.Windows.Forms.TextBox
        Me.DgvLista = New System.Windows.Forms.DataGridView
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnSeleccionar = New System.Windows.Forms.Button
        Me.gbBus.SuspendLayout()
        CType(Me.DgvLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbBus
        '
        Me.gbBus.Controls.Add(Me.txtBus)
        Me.gbBus.Location = New System.Drawing.Point(12, 12)
        Me.gbBus.Name = "gbBus"
        Me.gbBus.Size = New System.Drawing.Size(452, 42)
        Me.gbBus.TabIndex = 93
        Me.gbBus.TabStop = False
        Me.gbBus.Text = "GroupBox1"
        '
        'txtBus
        '
        Me.txtBus.Location = New System.Drawing.Point(14, 16)
        Me.txtBus.Name = "txtBus"
        Me.txtBus.Size = New System.Drawing.Size(432, 20)
        Me.txtBus.TabIndex = 0
        '
        'DgvLista
        '
        Me.DgvLista.BackgroundColor = System.Drawing.Color.White
        Me.DgvLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvLista.Location = New System.Drawing.Point(13, 57)
        Me.DgvLista.Name = "DgvLista"
        Me.DgvLista.Size = New System.Drawing.Size(452, 360)
        Me.DgvLista.TabIndex = 94
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(251, 425)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(167, 23)
        Me.btnCancelar.TabIndex = 98
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnSeleccionar
        '
        Me.btnSeleccionar.Image = CType(resources.GetObject("btnSeleccionar.Image"), System.Drawing.Image)
        Me.btnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSeleccionar.Location = New System.Drawing.Point(90, 425)
        Me.btnSeleccionar.Name = "btnSeleccionar"
        Me.btnSeleccionar.Size = New System.Drawing.Size(155, 23)
        Me.btnSeleccionar.TabIndex = 97
        Me.btnSeleccionar.Text = "Seleccionar"
        Me.btnSeleccionar.UseVisualStyleBackColor = True
        '
        'WListarFormatoContable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(476, 459)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnSeleccionar)
        Me.Controls.Add(Me.DgvLista)
        Me.Controls.Add(Me.gbBus)
        Me.Name = "WListarFormatoContable"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WListarFormatoContable"
        Me.gbBus.ResumeLayout(False)
        Me.gbBus.PerformLayout()
        CType(Me.DgvLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbBus As System.Windows.Forms.GroupBox
    Friend WithEvents txtBus As System.Windows.Forms.TextBox
    Friend WithEvents DgvLista As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnSeleccionar As System.Windows.Forms.Button
End Class
