<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WEditarCuentaBanco
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
        Me.TxtNumCb = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtAgeCb = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.gbEstado = New System.Windows.Forms.GroupBox
        Me.rbcerrada = New System.Windows.Forms.RadioButton
        Me.rbactiva = New System.Windows.Forms.RadioButton
        Me.Label9 = New System.Windows.Forms.Label
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.txtBcoCb = New System.Windows.Forms.TextBox
        Me.txtCodCb = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.gbMoneda = New System.Windows.Forms.GroupBox
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.rbdol = New System.Windows.Forms.RadioButton
        Me.rbSol = New System.Windows.Forms.RadioButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.gbtipo = New System.Windows.Forms.GroupBox
        Me.rbcte = New System.Windows.Forms.RadioButton
        Me.rbAho = New System.Windows.Forms.RadioButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtSaldo = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtCodEmp = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtNomEmp = New System.Windows.Forms.TextBox
        Me.gbEstado.SuspendLayout()
        Me.gbMoneda.SuspendLayout()
        Me.gbtipo.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtNumCb
        '
        Me.TxtNumCb.BackColor = System.Drawing.Color.White
        Me.TxtNumCb.Location = New System.Drawing.Point(136, 116)
        Me.TxtNumCb.MaxLength = 150
        Me.TxtNumCb.Name = "TxtNumCb"
        Me.TxtNumCb.Size = New System.Drawing.Size(389, 20)
        Me.TxtNumCb.TabIndex = 3
        Me.TxtNumCb.Tag = "5"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(18, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 100
        Me.Label5.Text = "Numero Cuenta"
        '
        'TxtAgeCb
        '
        Me.TxtAgeCb.BackColor = System.Drawing.Color.White
        Me.TxtAgeCb.Location = New System.Drawing.Point(136, 92)
        Me.TxtAgeCb.MaxLength = 150
        Me.TxtAgeCb.Name = "TxtAgeCb"
        Me.TxtAgeCb.Size = New System.Drawing.Size(389, 20)
        Me.TxtAgeCb.TabIndex = 2
        Me.TxtAgeCb.Tag = "4"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(18, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 98
        Me.Label3.Text = "Agencia"
        '
        'gbEstado
        '
        Me.gbEstado.Controls.Add(Me.rbcerrada)
        Me.gbEstado.Controls.Add(Me.rbactiva)
        Me.gbEstado.Location = New System.Drawing.Point(136, 195)
        Me.gbEstado.Name = "gbEstado"
        Me.gbEstado.Size = New System.Drawing.Size(135, 32)
        Me.gbEstado.TabIndex = 7
        Me.gbEstado.TabStop = False
        Me.gbEstado.Tag = "13"
        '
        'rbcerrada
        '
        Me.rbcerrada.AutoSize = True
        Me.rbcerrada.Location = New System.Drawing.Point(71, 11)
        Me.rbcerrada.Name = "rbcerrada"
        Me.rbcerrada.Size = New System.Drawing.Size(62, 17)
        Me.rbcerrada.TabIndex = 101
        Me.rbcerrada.Tag = "15"
        Me.rbcerrada.Text = "Cerrada"
        Me.rbcerrada.UseVisualStyleBackColor = True
        '
        'rbactiva
        '
        Me.rbactiva.AutoSize = True
        Me.rbactiva.Checked = True
        Me.rbactiva.Location = New System.Drawing.Point(10, 11)
        Me.rbactiva.Name = "rbactiva"
        Me.rbactiva.Size = New System.Drawing.Size(55, 17)
        Me.rbactiva.TabIndex = 100
        Me.rbactiva.TabStop = True
        Me.rbactiva.Tag = "14"
        Me.rbactiva.Text = "Activa"
        Me.rbactiva.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(18, 210)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 97
        Me.Label9.Text = "Estado"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Presentacion.My.Resources.Resources.action_stop
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(340, 235)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(95, 23)
        Me.btnCancelar.TabIndex = 9
        Me.btnCancelar.Tag = "17"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.Presentacion.My.Resources.Resources.apply
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(243, 235)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(98, 23)
        Me.btnAceptar.TabIndex = 8
        Me.btnAceptar.Tag = "16"
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'txtBcoCb
        '
        Me.txtBcoCb.BackColor = System.Drawing.Color.White
        Me.txtBcoCb.Location = New System.Drawing.Point(136, 68)
        Me.txtBcoCb.MaxLength = 150
        Me.txtBcoCb.Name = "txtBcoCb"
        Me.txtBcoCb.Size = New System.Drawing.Size(389, 20)
        Me.txtBcoCb.TabIndex = 1
        Me.txtBcoCb.Tag = "3"
        '
        'txtCodCb
        '
        Me.txtCodCb.BackColor = System.Drawing.Color.White
        Me.txtCodCb.Location = New System.Drawing.Point(136, 44)
        Me.txtCodCb.MaxLength = 8
        Me.txtCodCb.Name = "txtCodCb"
        Me.txtCodCb.Size = New System.Drawing.Size(100, 20)
        Me.txtCodCb.TabIndex = 0
        Me.txtCodCb.Tag = "2"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(18, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 95
        Me.Label2.Text = "Banco"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(18, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 96
        Me.Label1.Text = "Codigo Cta.Bco"
        '
        'gbMoneda
        '
        Me.gbMoneda.BackColor = System.Drawing.SystemColors.Control
        Me.gbMoneda.Controls.Add(Me.RadioButton1)
        Me.gbMoneda.Controls.Add(Me.rbdol)
        Me.gbMoneda.Controls.Add(Me.rbSol)
        Me.gbMoneda.ForeColor = System.Drawing.Color.Black
        Me.gbMoneda.Location = New System.Drawing.Point(136, 136)
        Me.gbMoneda.Name = "gbMoneda"
        Me.gbMoneda.Size = New System.Drawing.Size(197, 32)
        Me.gbMoneda.TabIndex = 4
        Me.gbMoneda.TabStop = False
        Me.gbMoneda.Tag = "6"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(127, 10)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(48, 17)
        Me.RadioButton1.TabIndex = 102
        Me.RadioButton1.Tag = "8"
        Me.RadioButton1.Text = "EUR"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'rbdol
        '
        Me.rbdol.AutoSize = True
        Me.rbdol.Location = New System.Drawing.Point(65, 11)
        Me.rbdol.Name = "rbdol"
        Me.rbdol.Size = New System.Drawing.Size(46, 17)
        Me.rbdol.TabIndex = 101
        Me.rbdol.Tag = "8"
        Me.rbdol.Text = "US$"
        Me.rbdol.UseVisualStyleBackColor = True
        '
        'rbSol
        '
        Me.rbSol.AutoSize = True
        Me.rbSol.Checked = True
        Me.rbSol.Location = New System.Drawing.Point(10, 11)
        Me.rbSol.Name = "rbSol"
        Me.rbSol.Size = New System.Drawing.Size(40, 17)
        Me.rbSol.TabIndex = 100
        Me.rbSol.TabStop = True
        Me.rbSol.Tag = "7"
        Me.rbSol.Text = "S/."
        Me.rbSol.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(18, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 102
        Me.Label4.Text = "Moneda"
        '
        'gbtipo
        '
        Me.gbtipo.Controls.Add(Me.rbcte)
        Me.gbtipo.Controls.Add(Me.rbAho)
        Me.gbtipo.Location = New System.Drawing.Point(391, 136)
        Me.gbtipo.Name = "gbtipo"
        Me.gbtipo.Size = New System.Drawing.Size(134, 32)
        Me.gbtipo.TabIndex = 5
        Me.gbtipo.TabStop = False
        Me.gbtipo.Tag = "9"
        '
        'rbcte
        '
        Me.rbcte.AutoSize = True
        Me.rbcte.Checked = True
        Me.rbcte.Location = New System.Drawing.Point(71, 11)
        Me.rbcte.Name = "rbcte"
        Me.rbcte.Size = New System.Drawing.Size(57, 17)
        Me.rbcte.TabIndex = 101
        Me.rbcte.TabStop = True
        Me.rbcte.Tag = "11"
        Me.rbcte.Text = "CtaCte"
        Me.rbcte.UseVisualStyleBackColor = True
        '
        'rbAho
        '
        Me.rbAho.AutoSize = True
        Me.rbAho.Location = New System.Drawing.Point(10, 11)
        Me.rbAho.Name = "rbAho"
        Me.rbAho.Size = New System.Drawing.Size(56, 17)
        Me.rbAho.TabIndex = 100
        Me.rbAho.Tag = "10"
        Me.rbAho.Text = "Ahorro"
        Me.rbAho.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(352, 150)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(28, 13)
        Me.Label6.TabIndex = 104
        Me.Label6.Text = "Tipo"
        '
        'TxtSaldo
        '
        Me.TxtSaldo.BackColor = System.Drawing.Color.White
        Me.TxtSaldo.Location = New System.Drawing.Point(136, 175)
        Me.TxtSaldo.MaxLength = 150
        Me.TxtSaldo.Name = "TxtSaldo"
        Me.TxtSaldo.Size = New System.Drawing.Size(133, 20)
        Me.TxtSaldo.TabIndex = 6
        Me.TxtSaldo.Tag = "12"
        Me.TxtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(19, 175)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 106
        Me.Label7.Text = "Saldo"
        '
        'TxtCodEmp
        '
        Me.TxtCodEmp.BackColor = System.Drawing.SystemColors.Control
        Me.TxtCodEmp.Location = New System.Drawing.Point(137, 20)
        Me.TxtCodEmp.MaxLength = 11
        Me.TxtCodEmp.Name = "TxtCodEmp"
        Me.TxtCodEmp.ReadOnly = True
        Me.TxtCodEmp.Size = New System.Drawing.Size(100, 20)
        Me.TxtCodEmp.TabIndex = 107
        Me.TxtCodEmp.Tag = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(19, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 13)
        Me.Label8.TabIndex = 108
        Me.Label8.Text = "Empresa"
        '
        'TxtNomEmp
        '
        Me.TxtNomEmp.BackColor = System.Drawing.SystemColors.Control
        Me.TxtNomEmp.Location = New System.Drawing.Point(238, 20)
        Me.TxtNomEmp.MaxLength = 11
        Me.TxtNomEmp.Name = "TxtNomEmp"
        Me.TxtNomEmp.ReadOnly = True
        Me.TxtNomEmp.Size = New System.Drawing.Size(287, 20)
        Me.TxtNomEmp.TabIndex = 109
        Me.TxtNomEmp.Tag = "1"
        '
        'WEditarCuentaBanco
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(551, 274)
        Me.Controls.Add(Me.TxtNomEmp)
        Me.Controls.Add(Me.TxtCodEmp)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TxtSaldo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.gbtipo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.gbMoneda)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtNumCb)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtAgeCb)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.gbEstado)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtBcoCb)
        Me.Controls.Add(Me.txtCodCb)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "WEditarCuentaBanco"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cuentas Bancarias"
        Me.gbEstado.ResumeLayout(False)
        Me.gbEstado.PerformLayout()
        Me.gbMoneda.ResumeLayout(False)
        Me.gbMoneda.PerformLayout()
        Me.gbtipo.ResumeLayout(False)
        Me.gbtipo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Function ListaControles() As List(Of CtrlsEdit)
        Dim lis As New List(Of CtrlsEdit)
        Dim item As CtrlsEdit

        item = New CtrlsEdit
        item.Control = Me.TxtCodEmp
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = "Codigo"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtNomEmp
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = "Nombre"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtCodCb
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Cuenta"
        item.Obligatorio = "1"    ''Obligatorio depende del dato limpiar 
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtBcoCb
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Banco"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtAgeCb
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Agencia"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtNumCb
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Numero"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.gbMoneda
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
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.rbSol
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "True"
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
        item.Control = Me.rbdol
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "0"
        item.DatoLimpiar = "1"
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
        item.Control = Me.gbtipo
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
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.rbAho
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "0"
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
        item.Control = Me.rbcte
        item.PasaFoco = "1"
        item.Formato = "0"
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
        item.Control = Me.TxtSaldo
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "0.00"
        item.Campo = "Saldo"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kDecimalNegativo  '' Para no ingresar letras por ej.
        item.Valida = Validar.texto.vSolonumerosConDosDecimales
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
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.rbactiva
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "True"
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
        item.Control = Me.rbcerrada
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "0"
        item.DatoLimpiar = "1"
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

    Friend WithEvents TxtNumCb As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtAgeCb As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gbEstado As System.Windows.Forms.GroupBox
    Friend WithEvents rbcerrada As System.Windows.Forms.RadioButton
    Friend WithEvents rbactiva As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents txtBcoCb As System.Windows.Forms.TextBox
    Friend WithEvents txtCodCb As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gbMoneda As System.Windows.Forms.GroupBox
    Friend WithEvents rbdol As System.Windows.Forms.RadioButton
    Friend WithEvents rbSol As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gbtipo As System.Windows.Forms.GroupBox
    Friend WithEvents rbcte As System.Windows.Forms.RadioButton
    Friend WithEvents rbAho As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtSaldo As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtCodEmp As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtNomEmp As System.Windows.Forms.TextBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
End Class
