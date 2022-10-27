<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WEditarVoucher
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
        Me.TxtApe = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.gbEstado = New System.Windows.Forms.GroupBox
        Me.rbcerrada = New System.Windows.Forms.RadioButton
        Me.rbactiva = New System.Windows.Forms.RadioButton
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtNomFil = New System.Windows.Forms.TextBox
        Me.txtAno = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtCodFil = New System.Windows.Forms.TextBox
        Me.TxtEne = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtFeb = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtMar = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtJun = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtMay = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtAbr = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtCierre = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TxtDic = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TxtNov = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TxtOct = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.TxtSet = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TxtAgo = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.TxtJul = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.TxtCodEmp = New System.Windows.Forms.TextBox
        Me.TxtNomEmp = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.gbEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtApe
        '
        Me.TxtApe.BackColor = System.Drawing.Color.White
        Me.TxtApe.Location = New System.Drawing.Point(126, 85)
        Me.TxtApe.MaxLength = 5
        Me.TxtApe.Name = "TxtApe"
        Me.TxtApe.Size = New System.Drawing.Size(100, 20)
        Me.TxtApe.TabIndex = 2
        Me.TxtApe.Tag = "5"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(28, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 120
        Me.Label3.Text = "Apertura"
        '
        'gbEstado
        '
        Me.gbEstado.Controls.Add(Me.rbcerrada)
        Me.gbEstado.Controls.Add(Me.rbactiva)
        Me.gbEstado.Location = New System.Drawing.Point(126, 260)
        Me.gbEstado.Name = "gbEstado"
        Me.gbEstado.Size = New System.Drawing.Size(143, 32)
        Me.gbEstado.TabIndex = 16
        Me.gbEstado.TabStop = False
        Me.gbEstado.Tag = "19"
        '
        'rbcerrada
        '
        Me.rbcerrada.AutoSize = True
        Me.rbcerrada.Location = New System.Drawing.Point(71, 11)
        Me.rbcerrada.Name = "rbcerrada"
        Me.rbcerrada.Size = New System.Drawing.Size(62, 17)
        Me.rbcerrada.TabIndex = 101
        Me.rbcerrada.Tag = "21"
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
        Me.rbactiva.Tag = "20"
        Me.rbactiva.Text = "Activa"
        Me.rbactiva.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(28, 275)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 119
        Me.Label9.Text = "Estado"
        '
        'txtNomFil
        '
        Me.txtNomFil.BackColor = System.Drawing.SystemColors.Control
        Me.txtNomFil.Location = New System.Drawing.Point(180, 60)
        Me.txtNomFil.MaxLength = 150
        Me.txtNomFil.Name = "txtNomFil"
        Me.txtNomFil.ReadOnly = True
        Me.txtNomFil.Size = New System.Drawing.Size(311, 20)
        Me.txtNomFil.TabIndex = 108
        Me.txtNomFil.Tag = "4"
        '
        'txtAno
        '
        Me.txtAno.BackColor = System.Drawing.SystemColors.Control
        Me.txtAno.Location = New System.Drawing.Point(126, 35)
        Me.txtAno.MaxLength = 4
        Me.txtAno.Name = "txtAno"
        Me.txtAno.ReadOnly = True
        Me.txtAno.Size = New System.Drawing.Size(53, 20)
        Me.txtAno.TabIndex = 0
        Me.txtAno.Tag = "2"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(28, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 13)
        Me.Label2.TabIndex = 117
        Me.Label2.Text = "File"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(28, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 118
        Me.Label1.Text = "Año"
        '
        'TxtCodFil
        '
        Me.TxtCodFil.BackColor = System.Drawing.SystemColors.Control
        Me.TxtCodFil.Location = New System.Drawing.Point(126, 60)
        Me.TxtCodFil.MaxLength = 3
        Me.TxtCodFil.Name = "TxtCodFil"
        Me.TxtCodFil.ReadOnly = True
        Me.TxtCodFil.Size = New System.Drawing.Size(53, 20)
        Me.TxtCodFil.TabIndex = 1
        Me.TxtCodFil.Tag = "3"
        '
        'TxtEne
        '
        Me.TxtEne.BackColor = System.Drawing.Color.White
        Me.TxtEne.Location = New System.Drawing.Point(126, 110)
        Me.TxtEne.MaxLength = 5
        Me.TxtEne.Name = "TxtEne"
        Me.TxtEne.Size = New System.Drawing.Size(100, 20)
        Me.TxtEne.TabIndex = 3
        Me.TxtEne.Tag = "6"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(28, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 127
        Me.Label4.Text = "Enero"
        '
        'TxtFeb
        '
        Me.TxtFeb.BackColor = System.Drawing.Color.White
        Me.TxtFeb.Location = New System.Drawing.Point(126, 135)
        Me.TxtFeb.MaxLength = 5
        Me.TxtFeb.Name = "TxtFeb"
        Me.TxtFeb.Size = New System.Drawing.Size(100, 20)
        Me.TxtFeb.TabIndex = 4
        Me.TxtFeb.Tag = "7"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(28, 135)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 129
        Me.Label5.Text = "Febrero"
        '
        'TxtMar
        '
        Me.TxtMar.BackColor = System.Drawing.Color.White
        Me.TxtMar.Location = New System.Drawing.Point(126, 160)
        Me.TxtMar.MaxLength = 5
        Me.TxtMar.Name = "TxtMar"
        Me.TxtMar.Size = New System.Drawing.Size(100, 20)
        Me.TxtMar.TabIndex = 5
        Me.TxtMar.Tag = "8"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(28, 160)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 131
        Me.Label6.Text = "Marzo"
        '
        'TxtJun
        '
        Me.TxtJun.BackColor = System.Drawing.Color.White
        Me.TxtJun.Location = New System.Drawing.Point(126, 235)
        Me.TxtJun.MaxLength = 5
        Me.TxtJun.Name = "TxtJun"
        Me.TxtJun.Size = New System.Drawing.Size(100, 20)
        Me.TxtJun.TabIndex = 8
        Me.TxtJun.Tag = "11"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(28, 235)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 13)
        Me.Label7.TabIndex = 137
        Me.Label7.Text = "Junio"
        '
        'TxtMay
        '
        Me.TxtMay.BackColor = System.Drawing.Color.White
        Me.TxtMay.Location = New System.Drawing.Point(126, 210)
        Me.TxtMay.MaxLength = 5
        Me.TxtMay.Name = "TxtMay"
        Me.TxtMay.Size = New System.Drawing.Size(100, 20)
        Me.TxtMay.TabIndex = 7
        Me.TxtMay.Tag = "10"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(31, 210)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 13)
        Me.Label8.TabIndex = 135
        Me.Label8.Text = "Mayo"
        '
        'TxtAbr
        '
        Me.TxtAbr.BackColor = System.Drawing.Color.White
        Me.TxtAbr.Location = New System.Drawing.Point(126, 185)
        Me.TxtAbr.MaxLength = 5
        Me.TxtAbr.Name = "TxtAbr"
        Me.TxtAbr.Size = New System.Drawing.Size(100, 20)
        Me.TxtAbr.TabIndex = 6
        Me.TxtAbr.Tag = "9"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(28, 185)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(27, 13)
        Me.Label10.TabIndex = 133
        Me.Label10.Text = "Abril"
        '
        'TxtCierre
        '
        Me.TxtCierre.BackColor = System.Drawing.Color.White
        Me.TxtCierre.Location = New System.Drawing.Point(390, 235)
        Me.TxtCierre.MaxLength = 5
        Me.TxtCierre.Name = "TxtCierre"
        Me.TxtCierre.Size = New System.Drawing.Size(100, 20)
        Me.TxtCierre.TabIndex = 15
        Me.TxtCierre.Tag = "18"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(272, 235)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 13)
        Me.Label11.TabIndex = 151
        Me.Label11.Text = "Cierre"
        '
        'TxtDic
        '
        Me.TxtDic.BackColor = System.Drawing.Color.White
        Me.TxtDic.Location = New System.Drawing.Point(390, 210)
        Me.TxtDic.MaxLength = 5
        Me.TxtDic.Name = "TxtDic"
        Me.TxtDic.Size = New System.Drawing.Size(100, 20)
        Me.TxtDic.TabIndex = 14
        Me.TxtDic.Tag = "17"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(272, 210)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 13)
        Me.Label12.TabIndex = 149
        Me.Label12.Text = "Diciembre"
        '
        'TxtNov
        '
        Me.TxtNov.BackColor = System.Drawing.Color.White
        Me.TxtNov.Location = New System.Drawing.Point(390, 185)
        Me.TxtNov.MaxLength = 5
        Me.TxtNov.Name = "TxtNov"
        Me.TxtNov.Size = New System.Drawing.Size(100, 20)
        Me.TxtNov.TabIndex = 13
        Me.TxtNov.Tag = "16"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(272, 185)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 13)
        Me.Label13.TabIndex = 147
        Me.Label13.Text = "Noviembre"
        '
        'TxtOct
        '
        Me.TxtOct.BackColor = System.Drawing.Color.White
        Me.TxtOct.Location = New System.Drawing.Point(390, 160)
        Me.TxtOct.MaxLength = 5
        Me.TxtOct.Name = "TxtOct"
        Me.TxtOct.Size = New System.Drawing.Size(100, 20)
        Me.TxtOct.TabIndex = 12
        Me.TxtOct.Tag = "15"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(272, 160)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 13)
        Me.Label14.TabIndex = 145
        Me.Label14.Text = "Octubre"
        '
        'TxtSet
        '
        Me.TxtSet.BackColor = System.Drawing.Color.White
        Me.TxtSet.Location = New System.Drawing.Point(390, 135)
        Me.TxtSet.MaxLength = 5
        Me.TxtSet.Name = "TxtSet"
        Me.TxtSet.Size = New System.Drawing.Size(100, 20)
        Me.TxtSet.TabIndex = 11
        Me.TxtSet.Tag = "14"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(272, 135)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 13)
        Me.Label15.TabIndex = 143
        Me.Label15.Text = "Setiembre"
        '
        'TxtAgo
        '
        Me.TxtAgo.BackColor = System.Drawing.Color.White
        Me.TxtAgo.Location = New System.Drawing.Point(390, 110)
        Me.TxtAgo.MaxLength = 5
        Me.TxtAgo.Name = "TxtAgo"
        Me.TxtAgo.Size = New System.Drawing.Size(100, 20)
        Me.TxtAgo.TabIndex = 10
        Me.TxtAgo.Tag = "13"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(272, 110)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 13)
        Me.Label16.TabIndex = 141
        Me.Label16.Text = "Agosto"
        '
        'TxtJul
        '
        Me.TxtJul.BackColor = System.Drawing.Color.White
        Me.TxtJul.Location = New System.Drawing.Point(390, 85)
        Me.TxtJul.MaxLength = 5
        Me.TxtJul.Name = "TxtJul"
        Me.TxtJul.Size = New System.Drawing.Size(100, 20)
        Me.TxtJul.TabIndex = 9
        Me.TxtJul.Tag = "12"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(272, 85)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(28, 13)
        Me.Label17.TabIndex = 139
        Me.Label17.Text = "Julio"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Presentacion.My.Resources.Resources.action_stop
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(397, 265)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(95, 23)
        Me.btnCancelar.TabIndex = 18
        Me.btnCancelar.Tag = "23"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.Presentacion.My.Resources.Resources.apply
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(300, 265)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(98, 23)
        Me.btnAceptar.TabIndex = 17
        Me.btnAceptar.Tag = "22"
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'TxtCodEmp
        '
        Me.TxtCodEmp.BackColor = System.Drawing.SystemColors.Control
        Me.TxtCodEmp.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtCodEmp.Location = New System.Drawing.Point(126, 10)
        Me.TxtCodEmp.MaxLength = 3
        Me.TxtCodEmp.Name = "TxtCodEmp"
        Me.TxtCodEmp.ReadOnly = True
        Me.TxtCodEmp.Size = New System.Drawing.Size(53, 20)
        Me.TxtCodEmp.TabIndex = 0
        Me.TxtCodEmp.Tag = "0"
        '
        'TxtNomEmp
        '
        Me.TxtNomEmp.BackColor = System.Drawing.SystemColors.Control
        Me.TxtNomEmp.Location = New System.Drawing.Point(180, 10)
        Me.TxtNomEmp.MaxLength = 150
        Me.TxtNomEmp.Name = "TxtNomEmp"
        Me.TxtNomEmp.ReadOnly = True
        Me.TxtNomEmp.Size = New System.Drawing.Size(311, 20)
        Me.TxtNomEmp.TabIndex = 153
        Me.TxtNomEmp.Tag = "1"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(28, 15)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(48, 13)
        Me.Label18.TabIndex = 154
        Me.Label18.Text = "Empresa"
        '
        'WEditarVoucher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(516, 323)
        Me.Controls.Add(Me.TxtCodEmp)
        Me.Controls.Add(Me.TxtNomEmp)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.TxtCierre)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TxtDic)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TxtNov)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TxtOct)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TxtSet)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TxtAgo)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.TxtJul)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.TxtJun)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtMay)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TxtAbr)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TxtMar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtFeb)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtEne)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtCodFil)
        Me.Controls.Add(Me.TxtApe)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.gbEstado)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtNomFil)
        Me.Controls.Add(Me.txtAno)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "WEditarVoucher"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Numero Voucher"
        Me.gbEstado.ResumeLayout(False)
        Me.gbEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Function ListaControles() As List(Of CtrlsEdit)
        Dim lis As New List(Of CtrlsEdit)
        Dim item As CtrlsEdit

        item = New CtrlsEdit
        item.Control = Me.TxtCodEmp
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Codigo"
        item.Obligatorio = "1"    ''Obligatorio depende del dato limpiar 
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
        item.Formato = "0"
        item.PasarCursor = "0"
        item.Limpiar = "1"
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
        item.Control = Me.txtAno
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Ano"
        item.Obligatorio = "1"    ''Obligatorio depende del dato limpiar 
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtCodFil
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "File"
        item.Obligatorio = "1"    ''Obligatorio depende del dato limpiar 
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtNomFil
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
        item.Limpiar = "1"
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
        item.Control = Me.TxtApe
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "00000"
        item.Campo = "Apertura"
        item.Obligatorio = "0"    ''No Obligatorio depende del dato limpiar 
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtEne
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "00000"
        item.Campo = "Enero"
        item.Obligatorio = "0"    ''No Obligatorio depende del dato limpiar 
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtFeb
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "00000"
        item.Campo = "Febrero"
        item.Obligatorio = "0"    ''No Obligatorio depende del dato limpiar 
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtMar
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "00000"
        item.Campo = "Marzo"
        item.Obligatorio = "0"    ''No Obligatorio depende del dato limpiar 
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtAbr
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "00000"
        item.Campo = "Abril"
        item.Obligatorio = "0"    ''No Obligatorio depende del dato limpiar 
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtMay
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "00000"
        item.Campo = "Mayo"
        item.Obligatorio = "0"    ''No Obligatorio depende del dato limpiar 
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtJun
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "00000"
        item.Campo = "Junio"
        item.Obligatorio = "0"    ''No Obligatorio depende del dato limpiar 
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)


        item = New CtrlsEdit
        item.Control = Me.TxtJul
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "00000"
        item.Campo = "Julio"
        item.Obligatorio = "0"    ''No Obligatorio depende del dato limpiar 
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)


        item = New CtrlsEdit
        item.Control = Me.TxtAgo
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "00000"
        item.Campo = "Agosto"
        item.Obligatorio = "0"    ''No Obligatorio depende del dato limpiar 
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)


        item = New CtrlsEdit
        item.Control = Me.TxtSet
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "00000"
        item.Campo = "Setiembre"
        item.Obligatorio = "0"    ''No Obligatorio depende del dato limpiar 
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)


        item = New CtrlsEdit
        item.Control = Me.TxtOct
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "00000"
        item.Campo = "Octubre"
        item.Obligatorio = "0"    ''No Obligatorio depende del dato limpiar 
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtNov
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "00000"
        item.Campo = "Noviembre"
        item.Obligatorio = "0"    ''No Obligatorio depende del dato limpiar 
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtDic
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "00000"
        item.Campo = "Diciembre"
        item.Obligatorio = "0"    ''No Obligatorio depende del dato limpiar 
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtCierre
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "00000"
        item.Campo = "Cierre"
        item.Obligatorio = "0"    ''No Obligatorio depende del dato limpiar 
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
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


    Friend WithEvents TxtApe As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gbEstado As System.Windows.Forms.GroupBox
    Friend WithEvents rbcerrada As System.Windows.Forms.RadioButton
    Friend WithEvents rbactiva As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents txtNomFil As System.Windows.Forms.TextBox
    Friend WithEvents txtAno As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtCodFil As System.Windows.Forms.TextBox
    Friend WithEvents TxtEne As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtFeb As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtMar As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtJun As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtMay As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtAbr As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtCierre As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtDic As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtNov As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtOct As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtSet As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtAgo As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TxtJul As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TxtCodEmp As System.Windows.Forms.TextBox
    Friend WithEvents TxtNomEmp As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
End Class
