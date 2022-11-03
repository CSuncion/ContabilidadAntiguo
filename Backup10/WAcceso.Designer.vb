<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WAcceso
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
        Me.txtCla = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbUsu = New System.Windows.Forms.ComboBox
        Me.cmbGru = New System.Windows.Forms.ComboBox
        Me.txtNomUsu = New System.Windows.Forms.TextBox
        Me.txtUsu = New System.Windows.Forms.TextBox
        Me.txtGru = New System.Windows.Forms.TextBox
        Me.TxtCodEmp = New System.Windows.Forms.TextBox
        Me.TxtNomEmp = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnIngresar = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtCodRuc = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.ckbUsu = New System.Windows.Forms.CheckBox
        Me.ckbCla = New System.Windows.Forms.CheckBox
        Me.ckbEmp = New System.Windows.Forms.CheckBox
        Me.TxtNomMes = New System.Windows.Forms.TextBox
        Me.TxtPerEmp = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'txtCla
        '
        Me.txtCla.Location = New System.Drawing.Point(97, 62)
        Me.txtCla.MaxLength = 10
        Me.txtCla.Name = "txtCla"
        Me.txtCla.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtCla.Size = New System.Drawing.Size(252, 20)
        Me.txtCla.TabIndex = 1
        Me.txtCla.Tag = "2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(17, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 100
        Me.Label3.Text = "Contraseña"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(17, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 100
        Me.Label2.Text = "Usuario"
        '
        'cmbUsu
        '
        Me.cmbUsu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUsu.FormattingEnabled = True
        Me.cmbUsu.Location = New System.Drawing.Point(469, 39)
        Me.cmbUsu.Name = "cmbUsu"
        Me.cmbUsu.Size = New System.Drawing.Size(195, 21)
        Me.cmbUsu.TabIndex = 100
        Me.cmbUsu.Visible = False
        '
        'cmbGru
        '
        Me.cmbGru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGru.Enabled = False
        Me.cmbGru.FormattingEnabled = True
        Me.cmbGru.Location = New System.Drawing.Point(497, 12)
        Me.cmbGru.Name = "cmbGru"
        Me.cmbGru.Size = New System.Drawing.Size(195, 21)
        Me.cmbGru.TabIndex = 10
        Me.cmbGru.Visible = False
        '
        'txtNomUsu
        '
        Me.txtNomUsu.Location = New System.Drawing.Point(97, 16)
        Me.txtNomUsu.MaxLength = 100
        Me.txtNomUsu.Name = "txtNomUsu"
        Me.txtNomUsu.ReadOnly = True
        Me.txtNomUsu.Size = New System.Drawing.Size(252, 20)
        Me.txtNomUsu.TabIndex = 100
        Me.txtNomUsu.Tag = "0"
        '
        'txtUsu
        '
        Me.txtUsu.BackColor = System.Drawing.Color.White
        Me.txtUsu.Location = New System.Drawing.Point(97, 39)
        Me.txtUsu.MaxLength = 100
        Me.txtUsu.Name = "txtUsu"
        Me.txtUsu.Size = New System.Drawing.Size(252, 20)
        Me.txtUsu.TabIndex = 0
        Me.txtUsu.Tag = "1"
        '
        'txtGru
        '
        Me.txtGru.Location = New System.Drawing.Point(514, 102)
        Me.txtGru.MaxLength = 100
        Me.txtGru.Name = "txtGru"
        Me.txtGru.ReadOnly = True
        Me.txtGru.Size = New System.Drawing.Size(150, 20)
        Me.txtGru.TabIndex = 13
        Me.txtGru.Visible = False
        '
        'TxtCodEmp
        '
        Me.TxtCodEmp.BackColor = System.Drawing.Color.White
        Me.TxtCodEmp.Location = New System.Drawing.Point(97, 85)
        Me.TxtCodEmp.MaxLength = 100
        Me.TxtCodEmp.Name = "TxtCodEmp"
        Me.TxtCodEmp.Size = New System.Drawing.Size(43, 20)
        Me.TxtCodEmp.TabIndex = 2
        Me.TxtCodEmp.Tag = "3"
        '
        'TxtNomEmp
        '
        Me.TxtNomEmp.Location = New System.Drawing.Point(141, 85)
        Me.TxtNomEmp.MaxLength = 100
        Me.TxtNomEmp.Name = "TxtNomEmp"
        Me.TxtNomEmp.ReadOnly = True
        Me.TxtNomEmp.Size = New System.Drawing.Size(208, 20)
        Me.TxtNomEmp.TabIndex = 102
        Me.TxtNomEmp.Tag = "4"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(18, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 103
        Me.Label1.Text = "Empresa"
        '
        'btnCancelar
        '
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(218, 156)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(131, 23)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Tag = "9"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnIngresar
        '
        Me.btnIngresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIngresar.Location = New System.Drawing.Point(95, 156)
        Me.btnIngresar.Name = "btnIngresar"
        Me.btnIngresar.Size = New System.Drawing.Size(122, 23)
        Me.btnIngresar.TabIndex = 4
        Me.btnIngresar.Tag = "8"
        Me.btnIngresar.Text = "Ingresar"
        Me.btnIngresar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(17, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 105
        Me.Label4.Text = "Periodo"
        '
        'TxtCodRuc
        '
        Me.TxtCodRuc.Location = New System.Drawing.Point(97, 131)
        Me.TxtCodRuc.MaxLength = 10
        Me.TxtCodRuc.Name = "TxtCodRuc"
        Me.TxtCodRuc.ReadOnly = True
        Me.TxtCodRuc.Size = New System.Drawing.Size(252, 20)
        Me.TxtCodRuc.TabIndex = 106
        Me.TxtCodRuc.Tag = "7"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(18, 134)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 13)
        Me.Label5.TabIndex = 107
        Me.Label5.Text = "Ruc"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(17, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 108
        Me.Label6.Text = "Nombres"
        '
        'ckbUsu
        '
        Me.ckbUsu.AutoSize = True
        Me.ckbUsu.Location = New System.Drawing.Point(97, 186)
        Me.ckbUsu.Name = "ckbUsu"
        Me.ckbUsu.Size = New System.Drawing.Size(101, 17)
        Me.ckbUsu.TabIndex = 110
        Me.ckbUsu.Text = "Persistir Usuario"
        Me.ckbUsu.UseVisualStyleBackColor = True
        '
        'ckbCla
        '
        Me.ckbCla.AutoSize = True
        Me.ckbCla.Location = New System.Drawing.Point(96, 204)
        Me.ckbCla.Name = "ckbCla"
        Me.ckbCla.Size = New System.Drawing.Size(119, 17)
        Me.ckbCla.TabIndex = 111
        Me.ckbCla.Text = "Persistir Contraseña"
        Me.ckbCla.UseVisualStyleBackColor = True
        '
        'ckbEmp
        '
        Me.ckbEmp.AutoSize = True
        Me.ckbEmp.Location = New System.Drawing.Point(96, 222)
        Me.ckbEmp.Name = "ckbEmp"
        Me.ckbEmp.Size = New System.Drawing.Size(106, 17)
        Me.ckbEmp.TabIndex = 112
        Me.ckbEmp.Text = "Persistir Empresa"
        Me.ckbEmp.UseVisualStyleBackColor = True
        '
        'TxtNomMes
        '
        Me.TxtNomMes.Location = New System.Drawing.Point(157, 108)
        Me.TxtNomMes.MaxLength = 100
        Me.TxtNomMes.Name = "TxtNomMes"
        Me.TxtNomMes.ReadOnly = True
        Me.TxtNomMes.Size = New System.Drawing.Size(192, 20)
        Me.TxtNomMes.TabIndex = 114
        Me.TxtNomMes.Tag = "6"
        '
        'TxtPerEmp
        '
        Me.TxtPerEmp.Location = New System.Drawing.Point(97, 108)
        Me.TxtPerEmp.MaxLength = 10
        Me.TxtPerEmp.Name = "TxtPerEmp"
        Me.TxtPerEmp.Size = New System.Drawing.Size(59, 20)
        Me.TxtPerEmp.TabIndex = 3
        Me.TxtPerEmp.Tag = "5"
        '
        'WAcceso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(357, 253)
        Me.ControlBox = False
        Me.Controls.Add(Me.TxtNomMes)
        Me.Controls.Add(Me.TxtPerEmp)
        Me.Controls.Add(Me.ckbEmp)
        Me.Controls.Add(Me.ckbCla)
        Me.Controls.Add(Me.ckbUsu)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtCodRuc)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtCodEmp)
        Me.Controls.Add(Me.TxtNomEmp)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtGru)
        Me.Controls.Add(Me.txtUsu)
        Me.Controls.Add(Me.txtNomUsu)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.txtCla)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbUsu)
        Me.Controls.Add(Me.cmbGru)
        Me.Controls.Add(Me.btnIngresar)
        Me.MaximizeBox = False
        Me.Name = "WAcceso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acceso al sistema"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Function ListaControles() As List(Of CtrlsEdit)
        Dim lis As New List(Of CtrlsEdit)
        Dim item As New CtrlsEdit

        item = New CtrlsEdit
        item.Control = Me.txtNomUsu
        item.PasaFoco = "0"
        item.Formato = ""
        item.PasarCursor = "0"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = ""
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)


        item = New CtrlsEdit
        item.Control = Me.txtUsu
        item.PasaFoco = "1"
        item.Formato = ""
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Usuario"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kAlfaNumericoSinEspacio
        item.Valida = Validar.texto.vSoloAlfaNumericoSinEspacio
        item.Nuevo = "1"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

    
        item = New CtrlsEdit
        item.Control = Me.txtCla
        item.PasaFoco = "1"
        item.Formato = ""
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Clave"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kAlfaNumericoConEspacio
        item.Valida = Validar.texto.vSoloAlfaNumericoConEspacio
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtCodEmp
        item.PasaFoco = "1"
        item.Formato = ""
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Empresa"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtNomEmp
        item.PasaFoco = "0"
        item.Formato = ""
        item.PasarCursor = "0"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = ""
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtPerEmp
        item.PasaFoco = "1"
        item.Formato = ""
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Periodo"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtNomMes
        item.PasaFoco = "0"
        item.Formato = ""
        item.PasarCursor = "0"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = ""
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)


        item = New CtrlsEdit
        item.Control = Me.TxtCodRuc
        item.PasaFoco = "0"
        item.Formato = ""
        item.PasarCursor = "0"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = ""
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.btnIngresar
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
    Friend WithEvents txtCla As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbUsu As System.Windows.Forms.ComboBox
    Friend WithEvents cmbGru As System.Windows.Forms.ComboBox
    Friend WithEvents btnIngresar As System.Windows.Forms.Button
    Friend WithEvents txtNomUsu As System.Windows.Forms.TextBox
    Friend WithEvents txtUsu As System.Windows.Forms.TextBox
    Friend WithEvents txtGru As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodEmp As System.Windows.Forms.TextBox
    Friend WithEvents TxtNomEmp As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtCodRuc As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ckbUsu As System.Windows.Forms.CheckBox
    Friend WithEvents ckbCla As System.Windows.Forms.CheckBox
    Friend WithEvents ckbEmp As System.Windows.Forms.CheckBox
    Friend WithEvents TxtNomMes As System.Windows.Forms.TextBox
    Friend WithEvents TxtPerEmp As System.Windows.Forms.TextBox

End Class
