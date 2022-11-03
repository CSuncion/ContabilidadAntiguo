<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WListarTabla
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
        Me.gbBus = New System.Windows.Forms.GroupBox
        Me.txtBus = New System.Windows.Forms.TextBox
        Me.DgvLista = New System.Windows.Forms.DataGridView
        Me.btnSeleccionar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.gbBus.SuspendLayout()
        CType(Me.DgvLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbBus
        '
        Me.gbBus.Controls.Add(Me.txtBus)
        Me.gbBus.Location = New System.Drawing.Point(6, 4)
        Me.gbBus.Name = "gbBus"
        Me.gbBus.Size = New System.Drawing.Size(282, 42)
        Me.gbBus.TabIndex = 0
        Me.gbBus.TabStop = False
        Me.gbBus.Text = "GroupBox1"
        '
        'txtBus
        '
        Me.txtBus.Location = New System.Drawing.Point(14, 16)
        Me.txtBus.Name = "txtBus"
        Me.txtBus.Size = New System.Drawing.Size(255, 20)
        Me.txtBus.TabIndex = 0
        '
        'DgvLista
        '
        Me.DgvLista.BackgroundColor = System.Drawing.Color.White
        Me.DgvLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvLista.Location = New System.Drawing.Point(6, 48)
        Me.DgvLista.Name = "DgvLista"
        Me.DgvLista.Size = New System.Drawing.Size(282, 307)
        Me.DgvLista.TabIndex = 88
        '
        'btnSeleccionar
        '
        Me.btnSeleccionar.Image = Global.Presentacion.My.Resources.Resources.apply
        Me.btnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSeleccionar.Location = New System.Drawing.Point(6, 360)
        Me.btnSeleccionar.Name = "btnSeleccionar"
        Me.btnSeleccionar.Size = New System.Drawing.Size(132, 23)
        Me.btnSeleccionar.TabIndex = 89
        Me.btnSeleccionar.Text = "Seleccionar"
        Me.btnSeleccionar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Presentacion.My.Resources.Resources.action_stop
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(138, 360)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(150, 23)
        Me.btnCancelar.TabIndex = 90
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'WListarTabla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(295, 395)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnSeleccionar)
        Me.Controls.Add(Me.DgvLista)
        Me.Controls.Add(Me.gbBus)
        Me.MaximizeBox = False
        Me.Name = "WListarTabla"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WListar"
        Me.gbBus.ResumeLayout(False)
        Me.gbBus.PerformLayout()
        CType(Me.DgvLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbBus As System.Windows.Forms.GroupBox
    Friend WithEvents txtBus As System.Windows.Forms.TextBox
    Friend WithEvents DgvLista As System.Windows.Forms.DataGridView
    Friend WithEvents btnSeleccionar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
End Class
