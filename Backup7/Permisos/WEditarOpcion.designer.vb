<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WEditarOpcion
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
            Me.Label2 = New System.Windows.Forms.Label
            Me.Label1 = New System.Windows.Forms.Label
            Me.txtNom = New System.Windows.Forms.TextBox
            Me.txtCod = New System.Windows.Forms.TextBox
            Me.btnCancelar = New System.Windows.Forms.Button
            Me.btnAceptar = New System.Windows.Forms.Button
            Me.SuspendLayout()
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
            Me.Label2.Location = New System.Drawing.Point(20, 41)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(82, 13)
            Me.Label2.TabIndex = 17
            Me.Label2.Text = "Descripcion :"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
            Me.Label1.Location = New System.Drawing.Point(20, 15)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(54, 13)
            Me.Label1.TabIndex = 18
            Me.Label1.Text = "Codigo :"
            '
            'txtNom
            '
            Me.txtNom.BackColor = System.Drawing.Color.White
            Me.txtNom.Location = New System.Drawing.Point(108, 38)
            Me.txtNom.Name = "txtNom"
            Me.txtNom.Size = New System.Drawing.Size(214, 20)
            Me.txtNom.TabIndex = 14
            Me.txtNom.Tag = "1"
            '
            'txtCod
            '
            Me.txtCod.BackColor = System.Drawing.Color.White
            Me.txtCod.Location = New System.Drawing.Point(108, 12)
            Me.txtCod.Name = "txtCod"
            Me.txtCod.Size = New System.Drawing.Size(81, 20)
            Me.txtCod.TabIndex = 13
            Me.txtCod.Tag = "0"
            '
            'btnCancelar
            '

            Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnCancelar.Location = New System.Drawing.Point(203, 67)
            Me.btnCancelar.Name = "btnCancelar"
            Me.btnCancelar.Size = New System.Drawing.Size(96, 23)
            Me.btnCancelar.TabIndex = 16
            Me.btnCancelar.Tag = "3"
            Me.btnCancelar.Text = "Cancelar"
            Me.btnCancelar.UseVisualStyleBackColor = True
            '
            'btnAceptar
            '

            Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnAceptar.Location = New System.Drawing.Point(108, 67)
            Me.btnAceptar.Name = "btnAceptar"
            Me.btnAceptar.Size = New System.Drawing.Size(96, 23)
            Me.btnAceptar.TabIndex = 15
            Me.btnAceptar.Tag = "2"
            Me.btnAceptar.Text = "Aceptar"
            Me.btnAceptar.UseVisualStyleBackColor = True
            '
            'WEditarOpcion
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.BackColor = System.Drawing.SystemColors.ControlLight
            Me.ClientSize = New System.Drawing.Size(371, 113)
            Me.Controls.Add(Me.btnCancelar)
            Me.Controls.Add(Me.btnAceptar)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.txtNom)
            Me.Controls.Add(Me.txtCod)
            Me.MaximizeBox = False
            Me.Name = "WEditarOpcion"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "WEditarOpcion"
            Me.ResumeLayout(False)
            Me.PerformLayout()

      End Sub
      Function ListaControles() As List(Of CtrlsEdit)
            Dim lis As New List(Of CtrlsEdit)
            Dim item As CtrlsEdit

            item = New CtrlsEdit
            item.Control = Me.txtCod
            item.PasaFoco = "1"
            item.Formato = "0"
            item.PasarCursor = "1"
            item.Limpiar = "1"
            item.DatoLimpiar = ""
            item.Campo = "Codigo"
            item.Obligatorio = "1"
            item.Teclazo = Validar.Tecla.kNada
            item.Valida = Validar.texto.vNada
            item.Nuevo = "1"
            item.Modificar = "0"
            item.Eliminar = "0"
            item.Visualizar = "0"
            lis.Add(item)

            item = New CtrlsEdit
            item.Control = Me.txtNom
            item.PasaFoco = "1"
            item.Formato = "0"
            item.PasarCursor = "1"
            item.Limpiar = "1"
            item.DatoLimpiar = ""
            item.Campo = "Descripcion"
            item.Obligatorio = "1"
            item.Teclazo = Validar.Tecla.kNada
            item.Valida = Validar.texto.vNada
            item.Nuevo = "1"
            item.Modificar = "1"
            item.Eliminar = "0"
            item.Visualizar = "0"
            lis.Add(item)


            item = New CtrlsEdit
            item.Control = Me.btnAceptar
            item.PasaFoco = "1"
            item.Formato = "0"
            item.PasarCursor = "1"
            item.Limpiar = "0"
            item.DatoLimpiar = ""
            item.Campo = ""
            item.Obligatorio = "0"
            item.Teclazo = Validar.Tecla.kNada
            item.Valida = Validar.texto.vNada
            item.Nuevo = "1"
            item.Modificar = "1"
            item.Eliminar = "1"
            item.Visualizar = "0"
            lis.Add(item)



            Return lis




      End Function
      Friend WithEvents btnCancelar As System.Windows.Forms.Button
      Friend WithEvents btnAceptar As System.Windows.Forms.Button
      Friend WithEvents Label2 As System.Windows.Forms.Label
      Friend WithEvents Label1 As System.Windows.Forms.Label
      Friend WithEvents txtNom As System.Windows.Forms.TextBox
      Friend WithEvents txtCod As System.Windows.Forms.TextBox
End Class
