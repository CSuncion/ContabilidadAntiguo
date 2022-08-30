<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WEditarFormatoContable
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
        Me.txtDesForCon = New System.Windows.Forms.TextBox
        Me.txtCodForCon = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.gbAgrupar = New System.Windows.Forms.GroupBox
        Me.rbtResul = New System.Windows.Forms.RadioButton
        Me.RbtSub = New System.Windows.Forms.RadioButton
        Me.RbtTit = New System.Windows.Forms.RadioButton
        Me.RbtPer = New System.Windows.Forms.RadioButton
        Me.RbtGan = New System.Windows.Forms.RadioButton
        Me.RbtPat = New System.Windows.Forms.RadioButton
        Me.RbtPnc = New System.Windows.Forms.RadioButton
        Me.RbtPc = New System.Windows.Forms.RadioButton
        Me.RbtAnc = New System.Windows.Forms.RadioButton
        Me.RbtAc = New System.Windows.Forms.RadioButton
        Me.Label9 = New System.Windows.Forms.Label
        Me.GbNaturaleza = New System.Windows.Forms.GroupBox
        Me.RbtAcr = New System.Windows.Forms.RadioButton
        Me.RbtDeu = New System.Windows.Forms.RadioButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtCodEmp = New System.Windows.Forms.TextBox
        Me.txtNomEmp = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.GbEstado = New System.Windows.Forms.GroupBox
        Me.RbtInactivo = New System.Windows.Forms.RadioButton
        Me.RbtActivo = New System.Windows.Forms.RadioButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtDes1ForCon = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.gbAgrupar.SuspendLayout()
        Me.GbNaturaleza.SuspendLayout()
        Me.GbEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Presentacion.My.Resources.Resources.action_stop
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(576, 257)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(121, 23)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Tag = "23"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.Presentacion.My.Resources.Resources.apply
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(458, 257)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(118, 23)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Tag = "22"
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'txtDesForCon
        '
        Me.txtDesForCon.BackColor = System.Drawing.Color.White
        Me.txtDesForCon.Location = New System.Drawing.Point(130, 68)
        Me.txtDesForCon.MaxLength = 150
        Me.txtDesForCon.Name = "txtDesForCon"
        Me.txtDesForCon.Size = New System.Drawing.Size(567, 20)
        Me.txtDesForCon.TabIndex = 1
        Me.txtDesForCon.Tag = "3"
        '
        'txtCodForCon
        '
        Me.txtCodForCon.BackColor = System.Drawing.Color.White
        Me.txtCodForCon.Location = New System.Drawing.Point(130, 43)
        Me.txtCodForCon.MaxLength = 11
        Me.txtCodForCon.Name = "txtCodForCon"
        Me.txtCodForCon.Size = New System.Drawing.Size(100, 20)
        Me.txtCodForCon.TabIndex = 0
        Me.txtCodForCon.Tag = "2"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(20, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Descripcion"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(20, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Codigo"
        '
        'gbAgrupar
        '
        Me.gbAgrupar.Controls.Add(Me.rbtResul)
        Me.gbAgrupar.Controls.Add(Me.RbtSub)
        Me.gbAgrupar.Controls.Add(Me.RbtTit)
        Me.gbAgrupar.Controls.Add(Me.RbtPer)
        Me.gbAgrupar.Controls.Add(Me.RbtGan)
        Me.gbAgrupar.Controls.Add(Me.RbtPat)
        Me.gbAgrupar.Controls.Add(Me.RbtPnc)
        Me.gbAgrupar.Controls.Add(Me.RbtPc)
        Me.gbAgrupar.Controls.Add(Me.RbtAnc)
        Me.gbAgrupar.Controls.Add(Me.RbtAc)
        Me.gbAgrupar.Location = New System.Drawing.Point(130, 93)
        Me.gbAgrupar.Name = "gbAgrupar"
        Me.gbAgrupar.Size = New System.Drawing.Size(567, 62)
        Me.gbAgrupar.TabIndex = 2
        Me.gbAgrupar.TabStop = False
        Me.gbAgrupar.Tag = "4"
        '
        'rbtResul
        '
        Me.rbtResul.AutoSize = True
        Me.rbtResul.Location = New System.Drawing.Point(238, 36)
        Me.rbtResul.Name = "rbtResul"
        Me.rbtResul.Size = New System.Drawing.Size(86, 17)
        Me.rbtResul.TabIndex = 112
        Me.rbtResul.Tag = "12"
        Me.rbtResul.Text = "Otros Gastos"
        Me.rbtResul.UseVisualStyleBackColor = True
        '
        'RbtSub
        '
        Me.RbtSub.AutoSize = True
        Me.RbtSub.Location = New System.Drawing.Point(469, 36)
        Me.RbtSub.Name = "RbtSub"
        Me.RbtSub.Size = New System.Drawing.Size(91, 17)
        Me.RbtSub.TabIndex = 108
        Me.RbtSub.Tag = "14"
        Me.RbtSub.Text = "Otros Egresos"
        Me.RbtSub.UseVisualStyleBackColor = True
        '
        'RbtTit
        '
        Me.RbtTit.AutoSize = True
        Me.RbtTit.Location = New System.Drawing.Point(345, 36)
        Me.RbtTit.Name = "RbtTit"
        Me.RbtTit.Size = New System.Drawing.Size(93, 17)
        Me.RbtTit.TabIndex = 107
        Me.RbtTit.Tag = "13"
        Me.RbtTit.Text = "Otros Ingresos"
        Me.RbtTit.UseVisualStyleBackColor = True
        '
        'RbtPer
        '
        Me.RbtPer.AutoSize = True
        Me.RbtPer.Location = New System.Drawing.Point(115, 36)
        Me.RbtPer.Name = "RbtPer"
        Me.RbtPer.Size = New System.Drawing.Size(94, 17)
        Me.RbtPer.TabIndex = 106
        Me.RbtPer.Tag = "11"
        Me.RbtPer.Text = "Gastos Ventas"
        Me.RbtPer.UseVisualStyleBackColor = True
        '
        'RbtGan
        '
        Me.RbtGan.AutoSize = True
        Me.RbtGan.Location = New System.Drawing.Point(9, 36)
        Me.RbtGan.Name = "RbtGan"
        Me.RbtGan.Size = New System.Drawing.Size(58, 17)
        Me.RbtGan.TabIndex = 105
        Me.RbtGan.Tag = "10"
        Me.RbtGan.Text = "Ventas"
        Me.RbtGan.UseVisualStyleBackColor = True
        '
        'RbtPat
        '
        Me.RbtPat.AutoSize = True
        Me.RbtPat.Location = New System.Drawing.Point(469, 13)
        Me.RbtPat.Name = "RbtPat"
        Me.RbtPat.Size = New System.Drawing.Size(74, 17)
        Me.RbtPat.TabIndex = 104
        Me.RbtPat.Tag = "9"
        Me.RbtPat.Text = "Patrimonio"
        Me.RbtPat.UseVisualStyleBackColor = True
        '
        'RbtPnc
        '
        Me.RbtPnc.AutoSize = True
        Me.RbtPnc.Location = New System.Drawing.Point(345, 12)
        Me.RbtPnc.Name = "RbtPnc"
        Me.RbtPnc.Size = New System.Drawing.Size(119, 17)
        Me.RbtPnc.TabIndex = 103
        Me.RbtPnc.Tag = "8"
        Me.RbtPnc.Text = "Pasivo No Corriente"
        Me.RbtPnc.UseVisualStyleBackColor = True
        '
        'RbtPc
        '
        Me.RbtPc.AutoSize = True
        Me.RbtPc.Location = New System.Drawing.Point(238, 13)
        Me.RbtPc.Name = "RbtPc"
        Me.RbtPc.Size = New System.Drawing.Size(102, 17)
        Me.RbtPc.TabIndex = 102
        Me.RbtPc.Tag = "7"
        Me.RbtPc.Text = "Pasivo Corriente"
        Me.RbtPc.UseVisualStyleBackColor = True
        '
        'RbtAnc
        '
        Me.RbtAnc.AutoSize = True
        Me.RbtAnc.Location = New System.Drawing.Point(115, 13)
        Me.RbtAnc.Name = "RbtAnc"
        Me.RbtAnc.Size = New System.Drawing.Size(117, 17)
        Me.RbtAnc.TabIndex = 101
        Me.RbtAnc.Tag = "6"
        Me.RbtAnc.Text = "Activo No Corriente"
        Me.RbtAnc.UseVisualStyleBackColor = True
        '
        'RbtAc
        '
        Me.RbtAc.AutoSize = True
        Me.RbtAc.Location = New System.Drawing.Point(9, 13)
        Me.RbtAc.Name = "RbtAc"
        Me.RbtAc.Size = New System.Drawing.Size(100, 17)
        Me.RbtAc.TabIndex = 100
        Me.RbtAc.Tag = "5"
        Me.RbtAc.Text = "Activo Corriente"
        Me.RbtAc.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(20, 120)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 13)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "Agrupar En"
        '
        'GbNaturaleza
        '
        Me.GbNaturaleza.Controls.Add(Me.RbtAcr)
        Me.GbNaturaleza.Controls.Add(Me.RbtDeu)
        Me.GbNaturaleza.Location = New System.Drawing.Point(130, 155)
        Me.GbNaturaleza.Name = "GbNaturaleza"
        Me.GbNaturaleza.Size = New System.Drawing.Size(224, 35)
        Me.GbNaturaleza.TabIndex = 3
        Me.GbNaturaleza.TabStop = False
        Me.GbNaturaleza.Tag = "15"
        '
        'RbtAcr
        '
        Me.RbtAcr.AutoSize = True
        Me.RbtAcr.Location = New System.Drawing.Point(115, 13)
        Me.RbtAcr.Name = "RbtAcr"
        Me.RbtAcr.Size = New System.Drawing.Size(74, 17)
        Me.RbtAcr.TabIndex = 101
        Me.RbtAcr.Tag = "17"
        Me.RbtAcr.Text = "Acreedora"
        Me.RbtAcr.UseVisualStyleBackColor = True
        '
        'RbtDeu
        '
        Me.RbtDeu.AutoSize = True
        Me.RbtDeu.Location = New System.Drawing.Point(9, 13)
        Me.RbtDeu.Name = "RbtDeu"
        Me.RbtDeu.Size = New System.Drawing.Size(66, 17)
        Me.RbtDeu.TabIndex = 100
        Me.RbtDeu.Tag = "16"
        Me.RbtDeu.Text = "Deudora"
        Me.RbtDeu.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(20, 170)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Naturaleza"
        '
        'TxtCodEmp
        '
        Me.TxtCodEmp.Location = New System.Drawing.Point(130, 18)
        Me.TxtCodEmp.Name = "TxtCodEmp"
        Me.TxtCodEmp.ReadOnly = True
        Me.TxtCodEmp.Size = New System.Drawing.Size(56, 20)
        Me.TxtCodEmp.TabIndex = 255
        Me.TxtCodEmp.Tag = "0"
        '
        'txtNomEmp
        '
        Me.txtNomEmp.Location = New System.Drawing.Point(187, 18)
        Me.txtNomEmp.Name = "txtNomEmp"
        Me.txtNomEmp.ReadOnly = True
        Me.txtNomEmp.Size = New System.Drawing.Size(510, 20)
        Me.txtNomEmp.TabIndex = 253
        Me.txtNomEmp.Tag = "1"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(20, 18)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(48, 13)
        Me.Label16.TabIndex = 254
        Me.Label16.Text = "Empresa"
        '
        'GbEstado
        '
        Me.GbEstado.Controls.Add(Me.RbtInactivo)
        Me.GbEstado.Controls.Add(Me.RbtActivo)
        Me.GbEstado.Location = New System.Drawing.Point(130, 190)
        Me.GbEstado.Name = "GbEstado"
        Me.GbEstado.Size = New System.Drawing.Size(224, 35)
        Me.GbEstado.TabIndex = 4
        Me.GbEstado.TabStop = False
        Me.GbEstado.Tag = "18"
        '
        'RbtInactivo
        '
        Me.RbtInactivo.AutoSize = True
        Me.RbtInactivo.Location = New System.Drawing.Point(115, 13)
        Me.RbtInactivo.Name = "RbtInactivo"
        Me.RbtInactivo.Size = New System.Drawing.Size(63, 17)
        Me.RbtInactivo.TabIndex = 101
        Me.RbtInactivo.Tag = "20"
        Me.RbtInactivo.Text = "Inactivo"
        Me.RbtInactivo.UseVisualStyleBackColor = True
        '
        'RbtActivo
        '
        Me.RbtActivo.AutoSize = True
        Me.RbtActivo.Location = New System.Drawing.Point(9, 13)
        Me.RbtActivo.Name = "RbtActivo"
        Me.RbtActivo.Size = New System.Drawing.Size(55, 17)
        Me.RbtActivo.TabIndex = 100
        Me.RbtActivo.Tag = "19"
        Me.RbtActivo.Text = "Activo"
        Me.RbtActivo.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(20, 205)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 257
        Me.Label4.Text = "Estado"
        '
        'TxtDes1ForCon
        '
        Me.TxtDes1ForCon.BackColor = System.Drawing.Color.White
        Me.TxtDes1ForCon.Location = New System.Drawing.Point(130, 231)
        Me.TxtDes1ForCon.MaxLength = 150
        Me.TxtDes1ForCon.Name = "TxtDes1ForCon"
        Me.TxtDes1ForCon.Size = New System.Drawing.Size(567, 20)
        Me.TxtDes1ForCon.TabIndex = 5
        Me.TxtDes1ForCon.Tag = "21"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(20, 234)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 13)
        Me.Label5.TabIndex = 259
        Me.Label5.Text = "Descripcion Alterna"
        '
        'WEditarFormatoContable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(711, 290)
        Me.Controls.Add(Me.TxtDes1ForCon)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GbEstado)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtCodEmp)
        Me.Controls.Add(Me.txtNomEmp)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.GbNaturaleza)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.gbAgrupar)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtDesForCon)
        Me.Controls.Add(Me.txtCodForCon)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "WEditarFormatoContable"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Formato Contable"
        Me.gbAgrupar.ResumeLayout(False)
        Me.gbAgrupar.PerformLayout()
        Me.GbNaturaleza.ResumeLayout(False)
        Me.GbNaturaleza.PerformLayout()
        Me.GbEstado.ResumeLayout(False)
        Me.GbEstado.PerformLayout()
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
        item.Control = Me.txtNomEmp
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
        item.Control = Me.txtCodForCon
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Formato Contable"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtDesForCon
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
        item.Control = Me.gbAgrupar
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
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.RbtAc
        item.PasaFoco = "1"
        item.Formato = ""
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "true"
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
        item.Control = Me.RbtAnc
        item.PasaFoco = "1"
        item.Formato = ""
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
        item.Control = Me.RbtPc
        item.PasaFoco = "1"
        item.Formato = ""
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
        item.Control = Me.RbtPnc
        item.PasaFoco = "1"
        item.Formato = ""
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
        item.Control = Me.RbtPat
        item.PasaFoco = "1"
        item.Formato = ""
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
        item.Control = Me.RbtGan
        item.PasaFoco = "1"
        item.Formato = ""
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
        item.Control = Me.RbtPer
        item.PasaFoco = "1"
        item.Formato = ""
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
        item.Control = Me.rbtResul
        item.PasaFoco = "1"
        item.Formato = ""
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
        item.Control = Me.RbtTit
        item.PasaFoco = "1"
        item.Formato = ""
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
        item.Control = Me.RbtSub
        item.PasaFoco = "1"
        item.Formato = ""
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
        item.Control = Me.GbNaturaleza
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
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.RbtDeu
        item.PasaFoco = "1"
        item.Formato = ""
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "true"
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
        item.Control = Me.RbtAcr
        item.PasaFoco = "1"
        item.Formato = ""
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
        item.Control = Me.GbEstado
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
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.RbtActivo
        item.PasaFoco = "1"
        item.Formato = ""
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "true"
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
        item.Formato = ""
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
        item.Control = Me.TxtDes1ForCon
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Descripcion1"
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

    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents txtDesForCon As System.Windows.Forms.TextBox
    Friend WithEvents txtCodForCon As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gbAgrupar As System.Windows.Forms.GroupBox
    Friend WithEvents RbtPnc As System.Windows.Forms.RadioButton
    Friend WithEvents RbtPc As System.Windows.Forms.RadioButton
    Friend WithEvents RbtAnc As System.Windows.Forms.RadioButton
    Friend WithEvents RbtAc As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents RbtPat As System.Windows.Forms.RadioButton
    Friend WithEvents GbNaturaleza As System.Windows.Forms.GroupBox
    Friend WithEvents RbtAcr As System.Windows.Forms.RadioButton
    Friend WithEvents RbtDeu As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtCodEmp As System.Windows.Forms.TextBox
    Friend WithEvents txtNomEmp As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GbEstado As System.Windows.Forms.GroupBox
    Friend WithEvents RbtInactivo As System.Windows.Forms.RadioButton
    Friend WithEvents RbtActivo As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents RbtPer As System.Windows.Forms.RadioButton
    Friend WithEvents RbtGan As System.Windows.Forms.RadioButton
    Friend WithEvents RbtSub As System.Windows.Forms.RadioButton
    Friend WithEvents RbtTit As System.Windows.Forms.RadioButton
    Friend WithEvents rbtResul As System.Windows.Forms.RadioButton
    Friend WithEvents TxtDes1ForCon As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
