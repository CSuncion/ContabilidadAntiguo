<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WEditarAfp
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
        Me.txtPorFonAfp = New System.Windows.Forms.TextBox
        Me.txtNomAfp = New System.Windows.Forms.TextBox
        Me.txtCodAfp = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.gbEstado = New System.Windows.Forms.GroupBox
        Me.RbtInactivo = New System.Windows.Forms.RadioButton
        Me.RbtActivo = New System.Windows.Forms.RadioButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtPorSegAfp = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtPorSobRemAfp = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtPorEspAfp = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.gbEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtPorFonAfp
        '
        Me.txtPorFonAfp.BackColor = System.Drawing.Color.White
        Me.txtPorFonAfp.Location = New System.Drawing.Point(167, 65)
        Me.txtPorFonAfp.MaxLength = 150
        Me.txtPorFonAfp.Name = "txtPorFonAfp"
        Me.txtPorFonAfp.Size = New System.Drawing.Size(100, 20)
        Me.txtPorFonAfp.TabIndex = 2
        Me.txtPorFonAfp.Tag = "2"
        '
        'txtNomAfp
        '
        Me.txtNomAfp.BackColor = System.Drawing.Color.White
        Me.txtNomAfp.Location = New System.Drawing.Point(167, 40)
        Me.txtNomAfp.MaxLength = 150
        Me.txtNomAfp.Name = "txtNomAfp"
        Me.txtNomAfp.Size = New System.Drawing.Size(379, 20)
        Me.txtNomAfp.TabIndex = 1
        Me.txtNomAfp.Tag = "1"
        '
        'txtCodAfp
        '
        Me.txtCodAfp.BackColor = System.Drawing.Color.White
        Me.txtCodAfp.Location = New System.Drawing.Point(167, 15)
        Me.txtCodAfp.MaxLength = 11
        Me.txtCodAfp.Name = "txtCodAfp"
        Me.txtCodAfp.Size = New System.Drawing.Size(100, 20)
        Me.txtCodAfp.TabIndex = 0
        Me.txtCodAfp.Tag = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(26, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "% Fondo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(26, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Nombre AFP"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(26, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo AFP"
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.Presentacion.My.Resources.Resources.apply
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(350, 177)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(98, 23)
        Me.btnAceptar.TabIndex = 7
        Me.btnAceptar.Tag = "9"
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Presentacion.My.Resources.Resources.action_stop
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(447, 177)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(99, 23)
        Me.btnCancelar.TabIndex = 8
        Me.btnCancelar.Tag = "10"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'gbEstado
        '
        Me.gbEstado.Controls.Add(Me.RbtInactivo)
        Me.gbEstado.Controls.Add(Me.RbtActivo)
        Me.gbEstado.Location = New System.Drawing.Point(166, 168)
        Me.gbEstado.Name = "gbEstado"
        Me.gbEstado.Size = New System.Drawing.Size(156, 34)
        Me.gbEstado.TabIndex = 6
        Me.gbEstado.TabStop = False
        Me.gbEstado.Tag = "6"
        '
        'RbtInactivo
        '
        Me.RbtInactivo.AutoSize = True
        Me.RbtInactivo.Location = New System.Drawing.Point(84, 12)
        Me.RbtInactivo.Name = "RbtInactivo"
        Me.RbtInactivo.Size = New System.Drawing.Size(63, 17)
        Me.RbtInactivo.TabIndex = 111
        Me.RbtInactivo.Tag = "8"
        Me.RbtInactivo.Text = "Inactivo"
        Me.RbtInactivo.UseVisualStyleBackColor = True
        '
        'RbtActivo
        '
        Me.RbtActivo.AutoSize = True
        Me.RbtActivo.Location = New System.Drawing.Point(10, 12)
        Me.RbtActivo.Name = "RbtActivo"
        Me.RbtActivo.Size = New System.Drawing.Size(55, 17)
        Me.RbtActivo.TabIndex = 110
        Me.RbtActivo.Tag = "7"
        Me.RbtActivo.Text = "Activo"
        Me.RbtActivo.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(26, 181)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 99
        Me.Label4.Text = "Estado"
        '
        'TxtPorSegAfp
        '
        Me.TxtPorSegAfp.BackColor = System.Drawing.Color.White
        Me.TxtPorSegAfp.Location = New System.Drawing.Point(167, 91)
        Me.TxtPorSegAfp.MaxLength = 150
        Me.TxtPorSegAfp.Name = "TxtPorSegAfp"
        Me.TxtPorSegAfp.Size = New System.Drawing.Size(100, 20)
        Me.TxtPorSegAfp.TabIndex = 3
        Me.TxtPorSegAfp.Tag = "3"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(26, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 100
        Me.Label5.Text = "% Seguro"
        '
        'TxtPorSobRemAfp
        '
        Me.TxtPorSobRemAfp.BackColor = System.Drawing.Color.White
        Me.TxtPorSobRemAfp.Location = New System.Drawing.Point(167, 116)
        Me.TxtPorSobRemAfp.MaxLength = 150
        Me.TxtPorSobRemAfp.Name = "TxtPorSobRemAfp"
        Me.TxtPorSobRemAfp.Size = New System.Drawing.Size(100, 20)
        Me.TxtPorSobRemAfp.TabIndex = 4
        Me.TxtPorSobRemAfp.Tag = "4"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(26, 116)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(118, 13)
        Me.Label6.TabIndex = 102
        Me.Label6.Text = "% Sobre Remuneración"
        '
        'TxtPorEspAfp
        '
        Me.TxtPorEspAfp.BackColor = System.Drawing.Color.White
        Me.TxtPorEspAfp.Location = New System.Drawing.Point(167, 143)
        Me.TxtPorEspAfp.MaxLength = 150
        Me.TxtPorEspAfp.Name = "TxtPorEspAfp"
        Me.TxtPorEspAfp.Size = New System.Drawing.Size(100, 20)
        Me.TxtPorEspAfp.TabIndex = 5
        Me.TxtPorEspAfp.Tag = "5"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(26, 143)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 104
        Me.Label7.Text = "% Especial Afp"
        '
        'WEditarAfp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(569, 248)
        Me.Controls.Add(Me.TxtPorEspAfp)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtPorSobRemAfp)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtPorSegAfp)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.gbEstado)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtPorFonAfp)
        Me.Controls.Add(Me.txtNomAfp)
        Me.Controls.Add(Me.txtCodAfp)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "WEditarAfp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes - Proveedores"
        Me.gbEstado.ResumeLayout(False)
        Me.gbEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Function ListaControles() As List(Of CtrlsEdit)
        Dim lis As New List(Of CtrlsEdit)
        Dim item As New CtrlsEdit

        item = New CtrlsEdit
        item.Control = Me.txtCodAfp
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Ruc"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtNomAfp
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Nombre Afp"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtPorFonAfp
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "0.000"
        item.Campo = "% Fondo"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtPorSegAfp
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "0.000"
        item.Campo = "% Seguro"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtPorSobRemAfp
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "0.000"
        item.Campo = "% Sobre Remuneracion"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtPorEspAfp
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "0.000"
        item.Campo = "% Especial Afp"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.gbEstado
        item.PasaFoco = "1"
        item.Formato = "0"
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
        item.Control = Me.RbtActivo
        item.PasaFoco = "1"
        item.Formato = "0"
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
        item.Control = Me.RbtInactivo
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "0"
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

    Friend WithEvents txtPorFonAfp As System.Windows.Forms.TextBox
    Friend WithEvents txtNomAfp As System.Windows.Forms.TextBox
    Friend WithEvents txtCodAfp As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents gbEstado As System.Windows.Forms.GroupBox
    Friend WithEvents RbtInactivo As System.Windows.Forms.RadioButton
    Friend WithEvents RbtActivo As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtPorSegAfp As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtPorSobRemAfp As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtPorEspAfp As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
