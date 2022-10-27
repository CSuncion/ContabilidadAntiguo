<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WSelecionaAuxiliar
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
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.gbTipAux = New System.Windows.Forms.GroupBox
        Me.rbtAmb = New System.Windows.Forms.RadioButton
        Me.rbtPer = New System.Windows.Forms.RadioButton
        Me.gbTipAux.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Presentacion.My.Resources.Resources.action_stop
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(176, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(82, 23)
        Me.btnCancelar.TabIndex = 22
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.Presentacion.My.Resources.Resources.apply
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(83, 48)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(82, 23)
        Me.btnAceptar.TabIndex = 21
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'gbTipAux
        '
        Me.gbTipAux.Controls.Add(Me.rbtAmb)
        Me.gbTipAux.Controls.Add(Me.rbtPer)
        Me.gbTipAux.Location = New System.Drawing.Point(46, 7)
        Me.gbTipAux.Name = "gbTipAux"
        Me.gbTipAux.Size = New System.Drawing.Size(244, 35)
        Me.gbTipAux.TabIndex = 25
        Me.gbTipAux.TabStop = False
        Me.gbTipAux.Tag = "7"
        '
        'rbtAmb
        '
        Me.rbtAmb.AutoSize = True
        Me.rbtAmb.Location = New System.Drawing.Point(123, 13)
        Me.rbtAmb.Name = "rbtAmb"
        Me.rbtAmb.Size = New System.Drawing.Size(103, 17)
        Me.rbtAmb.TabIndex = 101
        Me.rbtAmb.Tag = "9"
        Me.rbtAmb.Text = "Persona Juridica"
        Me.rbtAmb.UseVisualStyleBackColor = True
        '
        'rbtPer
        '
        Me.rbtPer.AutoSize = True
        Me.rbtPer.Checked = True
        Me.rbtPer.Location = New System.Drawing.Point(10, 13)
        Me.rbtPer.Name = "rbtPer"
        Me.rbtPer.Size = New System.Drawing.Size(101, 17)
        Me.rbtPer.TabIndex = 100
        Me.rbtPer.TabStop = True
        Me.rbtPer.Tag = "8"
        Me.rbtPer.Text = "Persona Natural"
        Me.rbtPer.UseVisualStyleBackColor = True
        '
        'WSelecionaAuxiliar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(355, 91)
        Me.Controls.Add(Me.gbTipAux)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.MaximizeBox = False
        Me.Name = "WSelecionaAuxiliar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selecciona tipo de cliente"
        Me.gbTipAux.ResumeLayout(False)
        Me.gbTipAux.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Function ListaControles() As List(Of CtrlsEdit)
        Dim lis As New List(Of CtrlsEdit)
        Dim item As New CtrlsEdit

        item = New CtrlsEdit
        item.Control = Me.gbTipAux
        item.PasaFoco = "1"
        item.Formato = ""
        item.PasarCursor = "0"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = ""
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "1"
        item.Visualizar = "1"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.rbtPer
        item.PasaFoco = "1"
        item.Formato = ""
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "True"
        item.Campo = ""
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.rbtAmb
        item.PasaFoco = "1"
        item.Formato = ""
        item.PasarCursor = "1"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = ""
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        Return lis
    End Function

    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents gbTipAux As System.Windows.Forms.GroupBox
    Friend WithEvents rbtAmb As System.Windows.Forms.RadioButton
    Friend WithEvents rbtPer As System.Windows.Forms.RadioButton
End Class
