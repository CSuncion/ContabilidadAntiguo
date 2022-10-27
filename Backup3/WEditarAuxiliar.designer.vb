<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WEditarAuxiliar
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
        Me.gbTipAux = New System.Windows.Forms.GroupBox
        Me.rbtPro = New System.Windows.Forms.RadioButton
        Me.rbtCli = New System.Windows.Forms.RadioButton
        Me.rbtAmb = New System.Windows.Forms.RadioButton
        Me.txtRefAux = New System.Windows.Forms.TextBox
        Me.txtCorAux = New System.Windows.Forms.TextBox
        Me.txtCelAux = New System.Windows.Forms.TextBox
        Me.txtTelAux = New System.Windows.Forms.TextBox
        Me.txtDirAux = New System.Windows.Forms.TextBox
        Me.txtNomAux = New System.Windows.Forms.TextBox
        Me.txtCodAux = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.gbEstado = New System.Windows.Forms.GroupBox
        Me.RbtInactivo = New System.Windows.Forms.RadioButton
        Me.RbtActivo = New System.Windows.Forms.RadioButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtNomDocIde = New System.Windows.Forms.TextBox
        Me.TxtTipDocIde = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TxtNomPaiNDomAux = New System.Windows.Forms.TextBox
        Me.TxtPaiNDomAux = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.gbTipAux.SuspendLayout()
        Me.gbEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbTipAux
        '
        Me.gbTipAux.Controls.Add(Me.rbtPro)
        Me.gbTipAux.Controls.Add(Me.rbtCli)
        Me.gbTipAux.Controls.Add(Me.rbtAmb)
        Me.gbTipAux.Location = New System.Drawing.Point(166, 160)
        Me.gbTipAux.Name = "gbTipAux"
        Me.gbTipAux.Size = New System.Drawing.Size(305, 35)
        Me.gbTipAux.TabIndex = 7
        Me.gbTipAux.TabStop = False
        Me.gbTipAux.Tag = "7"
        '
        'rbtPro
        '
        Me.rbtPro.AutoSize = True
        Me.rbtPro.Location = New System.Drawing.Point(193, 13)
        Me.rbtPro.Name = "rbtPro"
        Me.rbtPro.Size = New System.Drawing.Size(74, 17)
        Me.rbtPro.TabIndex = 103
        Me.rbtPro.Tag = "10"
        Me.rbtPro.Text = "Proveedor"
        Me.rbtPro.UseVisualStyleBackColor = True
        '
        'rbtCli
        '
        Me.rbtCli.AutoSize = True
        Me.rbtCli.Location = New System.Drawing.Point(128, 13)
        Me.rbtCli.Name = "rbtCli"
        Me.rbtCli.Size = New System.Drawing.Size(57, 17)
        Me.rbtCli.TabIndex = 102
        Me.rbtCli.Tag = "9"
        Me.rbtCli.Text = "Cliente"
        Me.rbtCli.UseVisualStyleBackColor = True
        '
        'rbtAmb
        '
        Me.rbtAmb.AutoSize = True
        Me.rbtAmb.Checked = True
        Me.rbtAmb.Location = New System.Drawing.Point(11, 13)
        Me.rbtAmb.Name = "rbtAmb"
        Me.rbtAmb.Size = New System.Drawing.Size(111, 17)
        Me.rbtAmb.TabIndex = 101
        Me.rbtAmb.TabStop = True
        Me.rbtAmb.Tag = "8"
        Me.rbtAmb.Text = "Cliente/Proveedor"
        Me.rbtAmb.UseVisualStyleBackColor = True
        '
        'txtRefAux
        '
        Me.txtRefAux.BackColor = System.Drawing.Color.White
        Me.txtRefAux.Location = New System.Drawing.Point(167, 140)
        Me.txtRefAux.MaxLength = 150
        Me.txtRefAux.Name = "txtRefAux"
        Me.txtRefAux.Size = New System.Drawing.Size(380, 20)
        Me.txtRefAux.TabIndex = 6
        Me.txtRefAux.Tag = "6"
        '
        'txtCorAux
        '
        Me.txtCorAux.BackColor = System.Drawing.Color.White
        Me.txtCorAux.Location = New System.Drawing.Point(167, 115)
        Me.txtCorAux.MaxLength = 40
        Me.txtCorAux.Name = "txtCorAux"
        Me.txtCorAux.Size = New System.Drawing.Size(380, 20)
        Me.txtCorAux.TabIndex = 5
        Me.txtCorAux.Tag = "5"
        '
        'txtCelAux
        '
        Me.txtCelAux.BackColor = System.Drawing.Color.White
        Me.txtCelAux.Location = New System.Drawing.Point(374, 90)
        Me.txtCelAux.MaxLength = 10
        Me.txtCelAux.Name = "txtCelAux"
        Me.txtCelAux.Size = New System.Drawing.Size(172, 20)
        Me.txtCelAux.TabIndex = 4
        Me.txtCelAux.Tag = "4"
        '
        'txtTelAux
        '
        Me.txtTelAux.BackColor = System.Drawing.Color.White
        Me.txtTelAux.Location = New System.Drawing.Point(167, 90)
        Me.txtTelAux.MaxLength = 7
        Me.txtTelAux.Name = "txtTelAux"
        Me.txtTelAux.Size = New System.Drawing.Size(100, 20)
        Me.txtTelAux.TabIndex = 3
        Me.txtTelAux.Tag = "3"
        '
        'txtDirAux
        '
        Me.txtDirAux.BackColor = System.Drawing.Color.White
        Me.txtDirAux.Location = New System.Drawing.Point(167, 65)
        Me.txtDirAux.MaxLength = 150
        Me.txtDirAux.Name = "txtDirAux"
        Me.txtDirAux.Size = New System.Drawing.Size(379, 20)
        Me.txtDirAux.TabIndex = 2
        Me.txtDirAux.Tag = "2"
        '
        'txtNomAux
        '
        Me.txtNomAux.BackColor = System.Drawing.Color.White
        Me.txtNomAux.Location = New System.Drawing.Point(167, 40)
        Me.txtNomAux.MaxLength = 150
        Me.txtNomAux.Name = "txtNomAux"
        Me.txtNomAux.Size = New System.Drawing.Size(379, 20)
        Me.txtNomAux.TabIndex = 1
        Me.txtNomAux.Tag = "1"
        '
        'txtCodAux
        '
        Me.txtCodAux.BackColor = System.Drawing.Color.White
        Me.txtCodAux.Location = New System.Drawing.Point(167, 15)
        Me.txtCodAux.MaxLength = 11
        Me.txtCodAux.Name = "txtCodAux"
        Me.txtCodAux.Size = New System.Drawing.Size(100, 20)
        Me.txtCodAux.TabIndex = 0
        Me.txtCodAux.Tag = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(26, 175)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Tipo Auxiliar"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(26, 140)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Referencia"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(26, 115)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "E:MAIL"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(319, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Celular"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(28, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Teléfono"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(26, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Dirección"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(26, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Nombre / Raz/Social"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(26, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ruc"
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.Presentacion.My.Resources.Resources.apply
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(350, 253)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(98, 23)
        Me.btnAceptar.TabIndex = 11
        Me.btnAceptar.Tag = "18"
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Presentacion.My.Resources.Resources.action_stop
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(447, 253)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(99, 23)
        Me.btnCancelar.TabIndex = 12
        Me.btnCancelar.Tag = "19"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'gbEstado
        '
        Me.gbEstado.Controls.Add(Me.RbtInactivo)
        Me.gbEstado.Controls.Add(Me.RbtActivo)
        Me.gbEstado.Location = New System.Drawing.Point(166, 244)
        Me.gbEstado.Name = "gbEstado"
        Me.gbEstado.Size = New System.Drawing.Size(156, 34)
        Me.gbEstado.TabIndex = 10
        Me.gbEstado.TabStop = False
        Me.gbEstado.Tag = "15"
        '
        'RbtInactivo
        '
        Me.RbtInactivo.AutoSize = True
        Me.RbtInactivo.Location = New System.Drawing.Point(84, 12)
        Me.RbtInactivo.Name = "RbtInactivo"
        Me.RbtInactivo.Size = New System.Drawing.Size(63, 17)
        Me.RbtInactivo.TabIndex = 111
        Me.RbtInactivo.Tag = "17"
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
        Me.RbtActivo.Tag = "16"
        Me.RbtActivo.Text = "Activo"
        Me.RbtActivo.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(26, 257)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 99
        Me.Label4.Text = "Estado"
        '
        'TxtNomDocIde
        '
        Me.TxtNomDocIde.BackColor = System.Drawing.SystemColors.Control
        Me.TxtNomDocIde.ForeColor = System.Drawing.Color.Black
        Me.TxtNomDocIde.Location = New System.Drawing.Point(235, 200)
        Me.TxtNomDocIde.MaxLength = 150
        Me.TxtNomDocIde.Name = "TxtNomDocIde"
        Me.TxtNomDocIde.ReadOnly = True
        Me.TxtNomDocIde.Size = New System.Drawing.Size(311, 20)
        Me.TxtNomDocIde.TabIndex = 133
        Me.TxtNomDocIde.Tag = "12"
        '
        'TxtTipDocIde
        '
        Me.TxtTipDocIde.BackColor = System.Drawing.Color.White
        Me.TxtTipDocIde.Location = New System.Drawing.Point(167, 200)
        Me.TxtTipDocIde.MaxLength = 7
        Me.TxtTipDocIde.Name = "TxtTipDocIde"
        Me.TxtTipDocIde.Size = New System.Drawing.Size(62, 20)
        Me.TxtTipDocIde.TabIndex = 8
        Me.TxtTipDocIde.Tag = "11"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(26, 203)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(133, 13)
        Me.Label15.TabIndex = 132
        Me.Label15.Text = "Tipo Docuemnto Identidad"
        '
        'TxtNomPaiNDomAux
        '
        Me.TxtNomPaiNDomAux.BackColor = System.Drawing.SystemColors.Control
        Me.TxtNomPaiNDomAux.ForeColor = System.Drawing.Color.Black
        Me.TxtNomPaiNDomAux.Location = New System.Drawing.Point(235, 225)
        Me.TxtNomPaiNDomAux.MaxLength = 150
        Me.TxtNomPaiNDomAux.Name = "TxtNomPaiNDomAux"
        Me.TxtNomPaiNDomAux.ReadOnly = True
        Me.TxtNomPaiNDomAux.Size = New System.Drawing.Size(311, 20)
        Me.TxtNomPaiNDomAux.TabIndex = 136
        Me.TxtNomPaiNDomAux.Tag = "14"
        '
        'TxtPaiNDomAux
        '
        Me.TxtPaiNDomAux.BackColor = System.Drawing.Color.White
        Me.TxtPaiNDomAux.Location = New System.Drawing.Point(166, 225)
        Me.TxtPaiNDomAux.MaxLength = 7
        Me.TxtPaiNDomAux.Name = "TxtPaiNDomAux"
        Me.TxtPaiNDomAux.Size = New System.Drawing.Size(62, 20)
        Me.TxtPaiNDomAux.TabIndex = 9
        Me.TxtPaiNDomAux.Tag = "13"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(28, 228)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(101, 13)
        Me.Label10.TabIndex = 135
        Me.Label10.Text = "Pais No Domiciliado"
        '
        'WEditarAuxiliar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(569, 285)
        Me.Controls.Add(Me.TxtNomPaiNDomAux)
        Me.Controls.Add(Me.TxtPaiNDomAux)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TxtNomDocIde)
        Me.Controls.Add(Me.TxtTipDocIde)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.gbEstado)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.gbTipAux)
        Me.Controls.Add(Me.txtRefAux)
        Me.Controls.Add(Me.txtCorAux)
        Me.Controls.Add(Me.txtCelAux)
        Me.Controls.Add(Me.txtTelAux)
        Me.Controls.Add(Me.txtDirAux)
        Me.Controls.Add(Me.txtNomAux)
        Me.Controls.Add(Me.txtCodAux)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "WEditarAuxiliar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Clientes - Proveedores"
        Me.gbTipAux.ResumeLayout(False)
        Me.gbTipAux.PerformLayout()
        Me.gbEstado.ResumeLayout(False)
        Me.gbEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Function ListaControles() As List(Of CtrlsEdit)
        Dim lis As New List(Of CtrlsEdit)
        Dim item As New CtrlsEdit

        item = New CtrlsEdit
        item.Control = Me.txtCodAux
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
        item.Control = Me.txtNomAux
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
        item.Control = Me.txtDirAux
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Direccion"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtTelAux
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Telefono"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kTelefono
        item.Valida = Validar.texto.vTelefono
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtCelAux
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Celular"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtCorAux
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Email"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kEmail
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtRefAux
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Referencia"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

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
        item.Control = Me.rbtAmb
        item.PasaFoco = "1"
        item.Formato = ""
        item.PasarCursor = "1"
        item.Limpiar = "0"
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
        item.Control = Me.rbtCli
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

        item = New CtrlsEdit
        item.Control = Me.rbtPro
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

        item = New CtrlsEdit
        item.Control = Me.TxtTipDocIde
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Tipo Documento Identidad"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtNomDocIde
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Nombre Documento Identidad"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtPaiNDomAux
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Pais No Domiciiado Auxiliar"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtNomPaiNDomAux
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Nombre Pais No Domiciiado Auxiliar"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "0"
        item.Modificar = "0"
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

    Friend WithEvents gbTipAux As System.Windows.Forms.GroupBox
    Friend WithEvents rbtPro As System.Windows.Forms.RadioButton
    Friend WithEvents rbtCli As System.Windows.Forms.RadioButton
    Friend WithEvents rbtAmb As System.Windows.Forms.RadioButton
    Friend WithEvents txtRefAux As System.Windows.Forms.TextBox
    Friend WithEvents txtCorAux As System.Windows.Forms.TextBox
    Friend WithEvents txtCelAux As System.Windows.Forms.TextBox
    Friend WithEvents txtTelAux As System.Windows.Forms.TextBox
    Friend WithEvents txtDirAux As System.Windows.Forms.TextBox
    Friend WithEvents txtNomAux As System.Windows.Forms.TextBox
    Friend WithEvents txtCodAux As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents gbEstado As System.Windows.Forms.GroupBox
    Friend WithEvents RbtInactivo As System.Windows.Forms.RadioButton
    Friend WithEvents RbtActivo As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtNomDocIde As System.Windows.Forms.TextBox
    Friend WithEvents TxtTipDocIde As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtNomPaiNDomAux As System.Windows.Forms.TextBox
    Friend WithEvents TxtPaiNDomAux As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
