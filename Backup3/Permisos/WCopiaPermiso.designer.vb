<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WCopiaPermiso
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtNomUsuC = New System.Windows.Forms.TextBox
        Me.txtCodUsuC = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtNomUsuB = New System.Windows.Forms.TextBox
        Me.txtCodUsuB = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtNomUsuC)
        Me.GroupBox1.Controls.Add(Me.txtCodUsuC)
        Me.GroupBox1.Location = New System.Drawing.Point(69, 61)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(454, 52)
        Me.GroupBox1.TabIndex = 119
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Usuario Copia"
        '
        'txtNomUsuC
        '
        Me.txtNomUsuC.BackColor = System.Drawing.SystemColors.Control
        Me.txtNomUsuC.Location = New System.Drawing.Point(134, 19)
        Me.txtNomUsuC.MaxLength = 150
        Me.txtNomUsuC.Name = "txtNomUsuC"
        Me.txtNomUsuC.ReadOnly = True
        Me.txtNomUsuC.Size = New System.Drawing.Size(308, 20)
        Me.txtNomUsuC.TabIndex = 111
        Me.txtNomUsuC.Tag = "1"
        '
        'txtCodUsuC
        '
        Me.txtCodUsuC.BackColor = System.Drawing.Color.White
        Me.txtCodUsuC.Location = New System.Drawing.Point(8, 19)
        Me.txtCodUsuC.MaxLength = 11
        Me.txtCodUsuC.Name = "txtCodUsuC"
        Me.txtCodUsuC.Size = New System.Drawing.Size(125, 20)
        Me.txtCodUsuC.TabIndex = 0
        Me.txtCodUsuC.Tag = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(75, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(338, 13)
        Me.Label1.TabIndex = 118
        Me.Label1.Text = "Seleccione el Usuario de donde desea copiar los permisos"
        '
        'txtNomUsuB
        '
        Me.txtNomUsuB.BackColor = System.Drawing.SystemColors.Control
        Me.txtNomUsuB.Location = New System.Drawing.Point(203, 12)
        Me.txtNomUsuB.MaxLength = 150
        Me.txtNomUsuB.Name = "txtNomUsuB"
        Me.txtNomUsuB.ReadOnly = True
        Me.txtNomUsuB.Size = New System.Drawing.Size(308, 20)
        Me.txtNomUsuB.TabIndex = 116
        Me.txtNomUsuB.Tag = "1"
        '
        'txtCodUsuB
        '
        Me.txtCodUsuB.BackColor = System.Drawing.SystemColors.Control
        Me.txtCodUsuB.Location = New System.Drawing.Point(78, 12)
        Me.txtCodUsuB.MaxLength = 11
        Me.txtCodUsuB.Name = "txtCodUsuB"
        Me.txtCodUsuB.ReadOnly = True
        Me.txtCodUsuB.Size = New System.Drawing.Size(124, 20)
        Me.txtCodUsuB.TabIndex = 115
        Me.txtCodUsuB.Tag = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(12, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 117
        Me.Label4.Text = "Usuario"
        '
        'btnCancelar
        '
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(424, 119)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(99, 23)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Tag = "2"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(326, 119)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(99, 23)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Tag = "1"
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'WCopiaPermiso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(538, 152)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNomUsuB)
        Me.Controls.Add(Me.txtCodUsuB)
        Me.Controls.Add(Me.Label4)
        Me.MaximizeBox = False
        Me.Name = "WCopiaPermiso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Copiar Permisos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Function ListaControles() As List(Of CtrlsEdit)
        Dim lis As New List(Of CtrlsEdit)

        Dim cod As New CtrlsEdit
        cod.Control = Me.txtCodUsuC
        cod.PasaFoco = "1"
        cod.Formato = ""
        cod.PasarCursor = "1"
        cod.Limpiar = "1"
        cod.DatoLimpiar = ""
        cod.Campo = "Usuario copia"
        cod.Obligatorio = "1"
        cod.Teclazo = Validar.Tecla.kAlfaNumericoSinEspacio
        cod.Valida = Validar.texto.vSoloAlfaNumericoSinEspacio
        cod.Nuevo = "1"
        cod.Modificar = "0"
        cod.Eliminar = "0"
        cod.Visualizar = "0"
        lis.Add(cod)


        Dim aceptar As New CtrlsEdit
        aceptar.Control = Me.btnAceptar
        aceptar.PasaFoco = "1"
        aceptar.Formato = "0"
        aceptar.PasarCursor = "1"
        aceptar.Limpiar = "0"
        aceptar.DatoLimpiar = ""
        aceptar.Campo = ""
        aceptar.Obligatorio = "0"
        aceptar.Teclazo = Validar.Tecla.kNada
        aceptar.Valida = Validar.texto.vNada
        aceptar.Nuevo = "1"
        aceptar.Modificar = "1"
        aceptar.Eliminar = "1"
        aceptar.Visualizar = "0"
        lis.Add(aceptar)

        Return lis
    End Function
      Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
      Friend WithEvents txtNomUsuC As System.Windows.Forms.TextBox
      Friend WithEvents txtCodUsuC As System.Windows.Forms.TextBox
      Friend WithEvents Label1 As System.Windows.Forms.Label
      Friend WithEvents txtNomUsuB As System.Windows.Forms.TextBox
      Friend WithEvents txtCodUsuB As System.Windows.Forms.TextBox
      Friend WithEvents Label4 As System.Windows.Forms.Label
      Friend WithEvents btnCancelar As System.Windows.Forms.Button
      Friend WithEvents btnAceptar As System.Windows.Forms.Button
End Class
