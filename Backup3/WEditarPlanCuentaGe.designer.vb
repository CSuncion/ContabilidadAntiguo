<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WEditarPlanCuentaGe
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
        Me.txtNomCta = New System.Windows.Forms.TextBox
        Me.txtCodCta = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.gbdocumento = New System.Windows.Forms.GroupBox
        Me.rbnodoc = New System.Windows.Forms.RadioButton
        Me.rbsidoc = New System.Windows.Forms.RadioButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.gbAuxiliar = New System.Windows.Forms.GroupBox
        Me.rbnoaux = New System.Windows.Forms.RadioButton
        Me.rbsiaux = New System.Windows.Forms.RadioButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.gbCcosto = New System.Windows.Forms.GroupBox
        Me.rbnocto = New System.Windows.Forms.RadioButton
        Me.rbsicto = New System.Windows.Forms.RadioButton
        Me.Label5 = New System.Windows.Forms.Label
        Me.gbflujo = New System.Windows.Forms.GroupBox
        Me.rbnoflu = New System.Windows.Forms.RadioButton
        Me.rbsiflu = New System.Windows.Forms.RadioButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.gbarea = New System.Windows.Forms.GroupBox
        Me.rbnoare = New System.Windows.Forms.RadioButton
        Me.rbsiare = New System.Windows.Forms.RadioButton
        Me.Label7 = New System.Windows.Forms.Label
        Me.gbalmacen = New System.Windows.Forms.GroupBox
        Me.rbnoalm = New System.Windows.Forms.RadioButton
        Me.rbsialm = New System.Windows.Forms.RadioButton
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.gbdiferencia = New System.Windows.Forms.GroupBox
        Me.rbnodif = New System.Windows.Forms.RadioButton
        Me.rbsidif = New System.Windows.Forms.RadioButton
        Me.Label10 = New System.Windows.Forms.Label
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.TxtCtaAut1 = New System.Windows.Forms.TextBox
        Me.TxtCtaAut2 = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TxtCodForCon = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TxtNomForCon = New System.Windows.Forms.TextBox
        Me.GbAutomatica = New System.Windows.Forms.GroupBox
        Me.RbNoAut = New System.Windows.Forms.RadioButton
        Me.RbSiAut = New System.Windows.Forms.RadioButton
        Me.TxtNomCtaAut1 = New System.Windows.Forms.TextBox
        Me.TxtNomCtaAut2 = New System.Windows.Forms.TextBox
        Me.gbBanco = New System.Windows.Forms.GroupBox
        Me.rbnobco = New System.Windows.Forms.RadioButton
        Me.rbsibco = New System.Windows.Forms.RadioButton
        Me.Label14 = New System.Windows.Forms.Label
        Me.GbMoneda = New System.Windows.Forms.GroupBox
        Me.RbEur = New System.Windows.Forms.RadioButton
        Me.RbDol = New System.Windows.Forms.RadioButton
        Me.RbSol = New System.Windows.Forms.RadioButton
        Me.Label15 = New System.Windows.Forms.Label
        Me.TxtCodEmp = New System.Windows.Forms.TextBox
        Me.txtNomEmp = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.gbAsientoApertura = New System.Windows.Forms.GroupBox
        Me.rbNoAsiApe = New System.Windows.Forms.RadioButton
        Me.rbSiAsiApe = New System.Windows.Forms.RadioButton
        Me.Label17 = New System.Windows.Forms.Label
        Me.gbAsientoCierre9 = New System.Windows.Forms.GroupBox
        Me.rbNoAsiCie9 = New System.Windows.Forms.RadioButton
        Me.rbSiAsiCie9 = New System.Windows.Forms.RadioButton
        Me.Label18 = New System.Windows.Forms.Label
        Me.gbAsientoCierre7 = New System.Windows.Forms.GroupBox
        Me.rbNoAsiCie7 = New System.Windows.Forms.RadioButton
        Me.rbSiAsiCie7 = New System.Windows.Forms.RadioButton
        Me.Label19 = New System.Windows.Forms.Label
        Me.gbdocumento.SuspendLayout()
        Me.gbAuxiliar.SuspendLayout()
        Me.gbCcosto.SuspendLayout()
        Me.gbflujo.SuspendLayout()
        Me.gbarea.SuspendLayout()
        Me.gbalmacen.SuspendLayout()
        Me.gbdiferencia.SuspendLayout()
        Me.GbAutomatica.SuspendLayout()
        Me.gbBanco.SuspendLayout()
        Me.GbMoneda.SuspendLayout()
        Me.gbAsientoApertura.SuspendLayout()
        Me.gbAsientoCierre9.SuspendLayout()
        Me.gbAsientoCierre7.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtNomCta
        '
        Me.txtNomCta.BackColor = System.Drawing.Color.White
        Me.txtNomCta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNomCta.Location = New System.Drawing.Point(130, 68)
        Me.txtNomCta.MaxLength = 150
        Me.txtNomCta.Name = "txtNomCta"
        Me.txtNomCta.Size = New System.Drawing.Size(477, 20)
        Me.txtNomCta.TabIndex = 1
        Me.txtNomCta.Tag = "1"
        '
        'txtCodCta
        '
        Me.txtCodCta.BackColor = System.Drawing.Color.White
        Me.txtCodCta.Location = New System.Drawing.Point(130, 45)
        Me.txtCodCta.MaxLength = 11
        Me.txtCodCta.Name = "txtCodCta"
        Me.txtCodCta.Size = New System.Drawing.Size(100, 20)
        Me.txtCodCta.TabIndex = 0
        Me.txtCodCta.Tag = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(29, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Nombre"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(29, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Codigo"
        '
        'gbdocumento
        '
        Me.gbdocumento.Controls.Add(Me.rbnodoc)
        Me.gbdocumento.Controls.Add(Me.rbsidoc)
        Me.gbdocumento.Location = New System.Drawing.Point(130, 92)
        Me.gbdocumento.Name = "gbdocumento"
        Me.gbdocumento.Size = New System.Drawing.Size(93, 35)
        Me.gbdocumento.TabIndex = 2
        Me.gbdocumento.TabStop = False
        Me.gbdocumento.Tag = "2"
        '
        'rbnodoc
        '
        Me.rbnodoc.AutoSize = True
        Me.rbnodoc.Checked = True
        Me.rbnodoc.Location = New System.Drawing.Point(50, 13)
        Me.rbnodoc.Name = "rbnodoc"
        Me.rbnodoc.Size = New System.Drawing.Size(39, 17)
        Me.rbnodoc.TabIndex = 101
        Me.rbnodoc.TabStop = True
        Me.rbnodoc.Tag = "4"
        Me.rbnodoc.Text = "No"
        Me.rbnodoc.UseVisualStyleBackColor = True
        '
        'rbsidoc
        '
        Me.rbsidoc.AutoSize = True
        Me.rbsidoc.Location = New System.Drawing.Point(10, 13)
        Me.rbsidoc.Name = "rbsidoc"
        Me.rbsidoc.Size = New System.Drawing.Size(34, 17)
        Me.rbsidoc.TabIndex = 100
        Me.rbsidoc.Tag = "3"
        Me.rbsidoc.Text = "Si"
        Me.rbsidoc.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(29, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "Documento"
        '
        'gbAuxiliar
        '
        Me.gbAuxiliar.Controls.Add(Me.rbnoaux)
        Me.gbAuxiliar.Controls.Add(Me.rbsiaux)
        Me.gbAuxiliar.Location = New System.Drawing.Point(315, 92)
        Me.gbAuxiliar.Name = "gbAuxiliar"
        Me.gbAuxiliar.Size = New System.Drawing.Size(93, 35)
        Me.gbAuxiliar.TabIndex = 3
        Me.gbAuxiliar.TabStop = False
        Me.gbAuxiliar.Tag = "5"
        '
        'rbnoaux
        '
        Me.rbnoaux.AutoSize = True
        Me.rbnoaux.Location = New System.Drawing.Point(50, 12)
        Me.rbnoaux.Name = "rbnoaux"
        Me.rbnoaux.Size = New System.Drawing.Size(39, 17)
        Me.rbnoaux.TabIndex = 103
        Me.rbnoaux.Tag = "7"
        Me.rbnoaux.Text = "No"
        Me.rbnoaux.UseVisualStyleBackColor = True
        '
        'rbsiaux
        '
        Me.rbsiaux.AutoSize = True
        Me.rbsiaux.Checked = True
        Me.rbsiaux.Location = New System.Drawing.Point(10, 11)
        Me.rbsiaux.Name = "rbsiaux"
        Me.rbsiaux.Size = New System.Drawing.Size(34, 17)
        Me.rbsiaux.TabIndex = 102
        Me.rbsiaux.TabStop = True
        Me.rbsiaux.Tag = "6"
        Me.rbsiaux.Text = "Si"
        Me.rbsiaux.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(243, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "Auxiliar"
        '
        'gbCcosto
        '
        Me.gbCcosto.Controls.Add(Me.rbnocto)
        Me.gbCcosto.Controls.Add(Me.rbsicto)
        Me.gbCcosto.Location = New System.Drawing.Point(513, 92)
        Me.gbCcosto.Name = "gbCcosto"
        Me.gbCcosto.Size = New System.Drawing.Size(93, 35)
        Me.gbCcosto.TabIndex = 4
        Me.gbCcosto.TabStop = False
        Me.gbCcosto.Tag = "8"
        '
        'rbnocto
        '
        Me.rbnocto.AutoSize = True
        Me.rbnocto.Checked = True
        Me.rbnocto.Location = New System.Drawing.Point(50, 12)
        Me.rbnocto.Name = "rbnocto"
        Me.rbnocto.Size = New System.Drawing.Size(39, 17)
        Me.rbnocto.TabIndex = 105
        Me.rbnocto.TabStop = True
        Me.rbnocto.Tag = "10"
        Me.rbnocto.Text = "No"
        Me.rbnocto.UseVisualStyleBackColor = True
        '
        'rbsicto
        '
        Me.rbsicto.AutoSize = True
        Me.rbsicto.Location = New System.Drawing.Point(10, 11)
        Me.rbsicto.Name = "rbsicto"
        Me.rbsicto.Size = New System.Drawing.Size(34, 17)
        Me.rbsicto.TabIndex = 104
        Me.rbsicto.Tag = "9"
        Me.rbsicto.Text = "Si"
        Me.rbsicto.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(429, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 13)
        Me.Label5.TabIndex = 47
        Me.Label5.Text = "Centro Costo"
        '
        'gbflujo
        '
        Me.gbflujo.Controls.Add(Me.rbnoflu)
        Me.gbflujo.Controls.Add(Me.rbsiflu)
        Me.gbflujo.Location = New System.Drawing.Point(513, 128)
        Me.gbflujo.Name = "gbflujo"
        Me.gbflujo.Size = New System.Drawing.Size(93, 35)
        Me.gbflujo.TabIndex = 7
        Me.gbflujo.TabStop = False
        Me.gbflujo.Tag = "17"
        '
        'rbnoflu
        '
        Me.rbnoflu.AutoSize = True
        Me.rbnoflu.Checked = True
        Me.rbnoflu.Location = New System.Drawing.Point(50, 12)
        Me.rbnoflu.Name = "rbnoflu"
        Me.rbnoflu.Size = New System.Drawing.Size(39, 17)
        Me.rbnoflu.TabIndex = 111
        Me.rbnoflu.TabStop = True
        Me.rbnoflu.Tag = "19"
        Me.rbnoflu.Text = "No"
        Me.rbnoflu.UseVisualStyleBackColor = True
        '
        'rbsiflu
        '
        Me.rbsiflu.AutoSize = True
        Me.rbsiflu.Location = New System.Drawing.Point(10, 11)
        Me.rbsiflu.Name = "rbsiflu"
        Me.rbsiflu.Size = New System.Drawing.Size(34, 17)
        Me.rbsiflu.TabIndex = 110
        Me.rbsiflu.Tag = "18"
        Me.rbsiflu.Text = "Si"
        Me.rbsiflu.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(429, 141)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 53
        Me.Label6.Text = "Flujo Caja"
        '
        'gbarea
        '
        Me.gbarea.Controls.Add(Me.rbnoare)
        Me.gbarea.Controls.Add(Me.rbsiare)
        Me.gbarea.Location = New System.Drawing.Point(315, 128)
        Me.gbarea.Name = "gbarea"
        Me.gbarea.Size = New System.Drawing.Size(93, 35)
        Me.gbarea.TabIndex = 6
        Me.gbarea.TabStop = False
        Me.gbarea.Tag = "14"
        '
        'rbnoare
        '
        Me.rbnoare.AutoSize = True
        Me.rbnoare.Checked = True
        Me.rbnoare.Location = New System.Drawing.Point(50, 12)
        Me.rbnoare.Name = "rbnoare"
        Me.rbnoare.Size = New System.Drawing.Size(39, 17)
        Me.rbnoare.TabIndex = 109
        Me.rbnoare.TabStop = True
        Me.rbnoare.Tag = "16"
        Me.rbnoare.Text = "No"
        Me.rbnoare.UseVisualStyleBackColor = True
        '
        'rbsiare
        '
        Me.rbsiare.AutoSize = True
        Me.rbsiare.Location = New System.Drawing.Point(10, 11)
        Me.rbsiare.Name = "rbsiare"
        Me.rbsiare.Size = New System.Drawing.Size(34, 17)
        Me.rbsiare.TabIndex = 108
        Me.rbsiare.Tag = "15"
        Me.rbsiare.Text = "Si"
        Me.rbsiare.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(244, 141)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "Area"
        '
        'gbalmacen
        '
        Me.gbalmacen.Controls.Add(Me.rbnoalm)
        Me.gbalmacen.Controls.Add(Me.rbsialm)
        Me.gbalmacen.Location = New System.Drawing.Point(130, 128)
        Me.gbalmacen.Name = "gbalmacen"
        Me.gbalmacen.Size = New System.Drawing.Size(93, 35)
        Me.gbalmacen.TabIndex = 5
        Me.gbalmacen.TabStop = False
        Me.gbalmacen.Tag = "11"
        '
        'rbnoalm
        '
        Me.rbnoalm.AutoSize = True
        Me.rbnoalm.Checked = True
        Me.rbnoalm.Location = New System.Drawing.Point(50, 13)
        Me.rbnoalm.Name = "rbnoalm"
        Me.rbnoalm.Size = New System.Drawing.Size(39, 17)
        Me.rbnoalm.TabIndex = 107
        Me.rbnoalm.TabStop = True
        Me.rbnoalm.Tag = "13"
        Me.rbnoalm.Text = "No"
        Me.rbnoalm.UseVisualStyleBackColor = True
        '
        'rbsialm
        '
        Me.rbsialm.AutoSize = True
        Me.rbsialm.Location = New System.Drawing.Point(10, 13)
        Me.rbsialm.Name = "rbsialm"
        Me.rbsialm.Size = New System.Drawing.Size(34, 17)
        Me.rbsialm.TabIndex = 106
        Me.rbsialm.Tag = "12"
        Me.rbsialm.Text = "Si"
        Me.rbsialm.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(29, 141)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 13)
        Me.Label8.TabIndex = 49
        Me.Label8.Text = "Almacen"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(29, 177)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 13)
        Me.Label9.TabIndex = 55
        Me.Label9.Text = "Automatica"
        '
        'gbdiferencia
        '
        Me.gbdiferencia.Controls.Add(Me.rbnodif)
        Me.gbdiferencia.Controls.Add(Me.rbsidif)
        Me.gbdiferencia.Location = New System.Drawing.Point(315, 164)
        Me.gbdiferencia.Name = "gbdiferencia"
        Me.gbdiferencia.Size = New System.Drawing.Size(93, 35)
        Me.gbdiferencia.TabIndex = 9
        Me.gbdiferencia.TabStop = False
        Me.gbdiferencia.Tag = "23"
        '
        'rbnodif
        '
        Me.rbnodif.AutoSize = True
        Me.rbnodif.Checked = True
        Me.rbnodif.Location = New System.Drawing.Point(50, 13)
        Me.rbnodif.Name = "rbnodif"
        Me.rbnodif.Size = New System.Drawing.Size(39, 17)
        Me.rbnodif.TabIndex = 115
        Me.rbnodif.TabStop = True
        Me.rbnodif.Tag = "25"
        Me.rbnodif.Text = "No"
        Me.rbnodif.UseVisualStyleBackColor = True
        '
        'rbsidif
        '
        Me.rbsidif.AutoSize = True
        Me.rbsidif.Location = New System.Drawing.Point(10, 12)
        Me.rbsidif.Name = "rbsidif"
        Me.rbsidif.Size = New System.Drawing.Size(34, 17)
        Me.rbsidif.TabIndex = 114
        Me.rbsidif.Tag = "24"
        Me.rbsidif.Text = "Si"
        Me.rbsidif.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(243, 177)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 13)
        Me.Label10.TabIndex = 57
        Me.Label10.Text = "Dif.Cambio"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Presentacion.My.Resources.Resources.action_stop
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(353, 359)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(100, 23)
        Me.btnCancelar.TabIndex = 19
        Me.btnCancelar.Tag = "47"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.Presentacion.My.Resources.Resources.apply
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(247, 359)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(107, 23)
        Me.btnAceptar.TabIndex = 18
        Me.btnAceptar.Tag = "46"
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(29, 282)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(45, 13)
        Me.Label11.TabIndex = 58
        Me.Label11.Text = "CtaAut1"
        '
        'TxtCtaAut1
        '
        Me.TxtCtaAut1.BackColor = System.Drawing.Color.White
        Me.TxtCtaAut1.Location = New System.Drawing.Point(130, 279)
        Me.TxtCtaAut1.MaxLength = 11
        Me.TxtCtaAut1.Name = "TxtCtaAut1"
        Me.TxtCtaAut1.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaAut1.TabIndex = 15
        Me.TxtCtaAut1.Tag = "40"
        '
        'TxtCtaAut2
        '
        Me.TxtCtaAut2.BackColor = System.Drawing.SystemColors.Control
        Me.TxtCtaAut2.Location = New System.Drawing.Point(130, 303)
        Me.TxtCtaAut2.MaxLength = 11
        Me.TxtCtaAut2.Name = "TxtCtaAut2"
        Me.TxtCtaAut2.ReadOnly = True
        Me.TxtCtaAut2.Size = New System.Drawing.Size(100, 20)
        Me.TxtCtaAut2.TabIndex = 16
        Me.TxtCtaAut2.Tag = "42"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(29, 306)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 13)
        Me.Label12.TabIndex = 60
        Me.Label12.Text = "CtaAut2"
        '
        'TxtCodForCon
        '
        Me.TxtCodForCon.BackColor = System.Drawing.Color.White
        Me.TxtCodForCon.Location = New System.Drawing.Point(130, 327)
        Me.TxtCodForCon.MaxLength = 11
        Me.TxtCodForCon.Name = "TxtCodForCon"
        Me.TxtCodForCon.Size = New System.Drawing.Size(100, 20)
        Me.TxtCodForCon.TabIndex = 17
        Me.TxtCodForCon.Tag = "44"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(29, 330)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(90, 13)
        Me.Label13.TabIndex = 62
        Me.Label13.Text = "Formato Contable"
        '
        'TxtNomForCon
        '
        Me.TxtNomForCon.BackColor = System.Drawing.SystemColors.Control
        Me.TxtNomForCon.Location = New System.Drawing.Point(232, 327)
        Me.TxtNomForCon.MaxLength = 11
        Me.TxtNomForCon.Name = "TxtNomForCon"
        Me.TxtNomForCon.ReadOnly = True
        Me.TxtNomForCon.Size = New System.Drawing.Size(375, 20)
        Me.TxtNomForCon.TabIndex = 117
        Me.TxtNomForCon.Tag = "45"
        '
        'GbAutomatica
        '
        Me.GbAutomatica.Controls.Add(Me.RbNoAut)
        Me.GbAutomatica.Controls.Add(Me.RbSiAut)
        Me.GbAutomatica.Location = New System.Drawing.Point(130, 164)
        Me.GbAutomatica.Name = "GbAutomatica"
        Me.GbAutomatica.Size = New System.Drawing.Size(93, 35)
        Me.GbAutomatica.TabIndex = 8
        Me.GbAutomatica.TabStop = False
        Me.GbAutomatica.Tag = "20"
        '
        'RbNoAut
        '
        Me.RbNoAut.AutoSize = True
        Me.RbNoAut.Checked = True
        Me.RbNoAut.Location = New System.Drawing.Point(50, 12)
        Me.RbNoAut.Name = "RbNoAut"
        Me.RbNoAut.Size = New System.Drawing.Size(39, 17)
        Me.RbNoAut.TabIndex = 111
        Me.RbNoAut.TabStop = True
        Me.RbNoAut.Tag = "22"
        Me.RbNoAut.Text = "No"
        Me.RbNoAut.UseVisualStyleBackColor = True
        '
        'RbSiAut
        '
        Me.RbSiAut.AutoSize = True
        Me.RbSiAut.Location = New System.Drawing.Point(10, 11)
        Me.RbSiAut.Name = "RbSiAut"
        Me.RbSiAut.Size = New System.Drawing.Size(34, 17)
        Me.RbSiAut.TabIndex = 110
        Me.RbSiAut.Tag = "21"
        Me.RbSiAut.Text = "Si"
        Me.RbSiAut.UseVisualStyleBackColor = True
        '
        'TxtNomCtaAut1
        '
        Me.TxtNomCtaAut1.BackColor = System.Drawing.SystemColors.Control
        Me.TxtNomCtaAut1.Location = New System.Drawing.Point(232, 279)
        Me.TxtNomCtaAut1.MaxLength = 11
        Me.TxtNomCtaAut1.Name = "TxtNomCtaAut1"
        Me.TxtNomCtaAut1.ReadOnly = True
        Me.TxtNomCtaAut1.Size = New System.Drawing.Size(375, 20)
        Me.TxtNomCtaAut1.TabIndex = 119
        Me.TxtNomCtaAut1.Tag = "41"
        '
        'TxtNomCtaAut2
        '
        Me.TxtNomCtaAut2.BackColor = System.Drawing.SystemColors.Control
        Me.TxtNomCtaAut2.Location = New System.Drawing.Point(232, 303)
        Me.TxtNomCtaAut2.MaxLength = 11
        Me.TxtNomCtaAut2.Name = "TxtNomCtaAut2"
        Me.TxtNomCtaAut2.ReadOnly = True
        Me.TxtNomCtaAut2.Size = New System.Drawing.Size(375, 20)
        Me.TxtNomCtaAut2.TabIndex = 120
        Me.TxtNomCtaAut2.Tag = "43"
        '
        'gbBanco
        '
        Me.gbBanco.Controls.Add(Me.rbnobco)
        Me.gbBanco.Controls.Add(Me.rbsibco)
        Me.gbBanco.Location = New System.Drawing.Point(513, 164)
        Me.gbBanco.Name = "gbBanco"
        Me.gbBanco.Size = New System.Drawing.Size(93, 35)
        Me.gbBanco.TabIndex = 10
        Me.gbBanco.TabStop = False
        Me.gbBanco.Tag = "26"
        '
        'rbnobco
        '
        Me.rbnobco.AutoSize = True
        Me.rbnobco.Checked = True
        Me.rbnobco.Location = New System.Drawing.Point(50, 13)
        Me.rbnobco.Name = "rbnobco"
        Me.rbnobco.Size = New System.Drawing.Size(39, 17)
        Me.rbnobco.TabIndex = 115
        Me.rbnobco.TabStop = True
        Me.rbnobco.Tag = "28"
        Me.rbnobco.Text = "No"
        Me.rbnobco.UseVisualStyleBackColor = True
        '
        'rbsibco
        '
        Me.rbsibco.AutoSize = True
        Me.rbsibco.Location = New System.Drawing.Point(10, 12)
        Me.rbsibco.Name = "rbsibco"
        Me.rbsibco.Size = New System.Drawing.Size(34, 17)
        Me.rbsibco.TabIndex = 114
        Me.rbsibco.Tag = "27"
        Me.rbsibco.Text = "Si"
        Me.rbsibco.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(429, 177)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 13)
        Me.Label14.TabIndex = 122
        Me.Label14.Text = "Cta.Banco"
        '
        'GbMoneda
        '
        Me.GbMoneda.Controls.Add(Me.RbEur)
        Me.GbMoneda.Controls.Add(Me.RbDol)
        Me.GbMoneda.Controls.Add(Me.RbSol)
        Me.GbMoneda.Location = New System.Drawing.Point(130, 200)
        Me.GbMoneda.Name = "GbMoneda"
        Me.GbMoneda.Size = New System.Drawing.Size(190, 35)
        Me.GbMoneda.TabIndex = 11
        Me.GbMoneda.TabStop = False
        Me.GbMoneda.Tag = "29"
        '
        'RbEur
        '
        Me.RbEur.AutoSize = True
        Me.RbEur.Location = New System.Drawing.Point(128, 12)
        Me.RbEur.Name = "RbEur"
        Me.RbEur.Size = New System.Drawing.Size(48, 17)
        Me.RbEur.TabIndex = 116
        Me.RbEur.Tag = "32"
        Me.RbEur.Text = "EUR"
        Me.RbEur.UseVisualStyleBackColor = True
        '
        'RbDol
        '
        Me.RbDol.AutoSize = True
        Me.RbDol.Location = New System.Drawing.Point(64, 12)
        Me.RbDol.Name = "RbDol"
        Me.RbDol.Size = New System.Drawing.Size(46, 17)
        Me.RbDol.TabIndex = 115
        Me.RbDol.Tag = "31"
        Me.RbDol.Text = "US$"
        Me.RbDol.UseVisualStyleBackColor = True
        '
        'RbSol
        '
        Me.RbSol.AutoSize = True
        Me.RbSol.Checked = True
        Me.RbSol.Location = New System.Drawing.Point(10, 12)
        Me.RbSol.Name = "RbSol"
        Me.RbSol.Size = New System.Drawing.Size(40, 17)
        Me.RbSol.TabIndex = 114
        Me.RbSol.TabStop = True
        Me.RbSol.Tag = "30"
        Me.RbSol.Text = "S/."
        Me.RbSol.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(29, 214)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(46, 13)
        Me.Label15.TabIndex = 124
        Me.Label15.Text = "Moneda"
        '
        'TxtCodEmp
        '
        Me.TxtCodEmp.Location = New System.Drawing.Point(130, 20)
        Me.TxtCodEmp.Name = "TxtCodEmp"
        Me.TxtCodEmp.ReadOnly = True
        Me.TxtCodEmp.Size = New System.Drawing.Size(43, 20)
        Me.TxtCodEmp.TabIndex = 191
        Me.TxtCodEmp.Tag = "0"
        '
        'txtNomEmp
        '
        Me.txtNomEmp.Location = New System.Drawing.Point(179, 20)
        Me.txtNomEmp.Name = "txtNomEmp"
        Me.txtNomEmp.ReadOnly = True
        Me.txtNomEmp.Size = New System.Drawing.Size(427, 20)
        Me.txtNomEmp.TabIndex = 189
        Me.txtNomEmp.Tag = "1"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(29, 20)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(48, 13)
        Me.Label16.TabIndex = 190
        Me.Label16.Text = "Empresa"
        '
        'gbAsientoApertura
        '
        Me.gbAsientoApertura.Controls.Add(Me.rbNoAsiApe)
        Me.gbAsientoApertura.Controls.Add(Me.rbSiAsiApe)
        Me.gbAsientoApertura.Location = New System.Drawing.Point(513, 201)
        Me.gbAsientoApertura.Name = "gbAsientoApertura"
        Me.gbAsientoApertura.Size = New System.Drawing.Size(93, 35)
        Me.gbAsientoApertura.TabIndex = 12
        Me.gbAsientoApertura.TabStop = False
        Me.gbAsientoApertura.Tag = "33"
        '
        'rbNoAsiApe
        '
        Me.rbNoAsiApe.AutoSize = True
        Me.rbNoAsiApe.Checked = True
        Me.rbNoAsiApe.Location = New System.Drawing.Point(50, 13)
        Me.rbNoAsiApe.Name = "rbNoAsiApe"
        Me.rbNoAsiApe.Size = New System.Drawing.Size(39, 17)
        Me.rbNoAsiApe.TabIndex = 115
        Me.rbNoAsiApe.TabStop = True
        Me.rbNoAsiApe.Tag = "35"
        Me.rbNoAsiApe.Text = "No"
        Me.rbNoAsiApe.UseVisualStyleBackColor = True
        '
        'rbSiAsiApe
        '
        Me.rbSiAsiApe.AutoSize = True
        Me.rbSiAsiApe.Location = New System.Drawing.Point(10, 12)
        Me.rbSiAsiApe.Name = "rbSiAsiApe"
        Me.rbSiAsiApe.Size = New System.Drawing.Size(34, 17)
        Me.rbSiAsiApe.TabIndex = 114
        Me.rbSiAsiApe.Tag = "34"
        Me.rbSiAsiApe.Text = "Si"
        Me.rbSiAsiApe.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(429, 214)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(85, 13)
        Me.Label17.TabIndex = 193
        Me.Label17.Text = "Asiento Apertura"
        '
        'gbAsientoCierre9
        '
        Me.gbAsientoCierre9.Controls.Add(Me.rbNoAsiCie9)
        Me.gbAsientoCierre9.Controls.Add(Me.rbSiAsiCie9)
        Me.gbAsientoCierre9.Location = New System.Drawing.Point(131, 236)
        Me.gbAsientoCierre9.Name = "gbAsientoCierre9"
        Me.gbAsientoCierre9.Size = New System.Drawing.Size(93, 35)
        Me.gbAsientoCierre9.TabIndex = 13
        Me.gbAsientoCierre9.TabStop = False
        Me.gbAsientoCierre9.Tag = "33"
        '
        'rbNoAsiCie9
        '
        Me.rbNoAsiCie9.AutoSize = True
        Me.rbNoAsiCie9.Checked = True
        Me.rbNoAsiCie9.Location = New System.Drawing.Point(50, 13)
        Me.rbNoAsiCie9.Name = "rbNoAsiCie9"
        Me.rbNoAsiCie9.Size = New System.Drawing.Size(39, 17)
        Me.rbNoAsiCie9.TabIndex = 115
        Me.rbNoAsiCie9.TabStop = True
        Me.rbNoAsiCie9.Tag = "37"
        Me.rbNoAsiCie9.Text = "No"
        Me.rbNoAsiCie9.UseVisualStyleBackColor = True
        '
        'rbSiAsiCie9
        '
        Me.rbSiAsiCie9.AutoSize = True
        Me.rbSiAsiCie9.Location = New System.Drawing.Point(10, 12)
        Me.rbSiAsiCie9.Name = "rbSiAsiCie9"
        Me.rbSiAsiCie9.Size = New System.Drawing.Size(34, 17)
        Me.rbSiAsiCie9.TabIndex = 114
        Me.rbSiAsiCie9.Tag = "36"
        Me.rbSiAsiCie9.Text = "Si"
        Me.rbSiAsiCie9.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(29, 250)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(84, 13)
        Me.Label18.TabIndex = 195
        Me.Label18.Text = "Asiento Cierre  9"
        '
        'gbAsientoCierre7
        '
        Me.gbAsientoCierre7.Controls.Add(Me.rbNoAsiCie7)
        Me.gbAsientoCierre7.Controls.Add(Me.rbSiAsiCie7)
        Me.gbAsientoCierre7.Location = New System.Drawing.Point(523, 236)
        Me.gbAsientoCierre7.Name = "gbAsientoCierre7"
        Me.gbAsientoCierre7.Size = New System.Drawing.Size(93, 35)
        Me.gbAsientoCierre7.TabIndex = 14
        Me.gbAsientoCierre7.TabStop = False
        Me.gbAsientoCierre7.Tag = "33"
        '
        'rbNoAsiCie7
        '
        Me.rbNoAsiCie7.AutoSize = True
        Me.rbNoAsiCie7.Checked = True
        Me.rbNoAsiCie7.Location = New System.Drawing.Point(50, 13)
        Me.rbNoAsiCie7.Name = "rbNoAsiCie7"
        Me.rbNoAsiCie7.Size = New System.Drawing.Size(39, 17)
        Me.rbNoAsiCie7.TabIndex = 115
        Me.rbNoAsiCie7.TabStop = True
        Me.rbNoAsiCie7.Tag = "39"
        Me.rbNoAsiCie7.Text = "No"
        Me.rbNoAsiCie7.UseVisualStyleBackColor = True
        '
        'rbSiAsiCie7
        '
        Me.rbSiAsiCie7.AutoSize = True
        Me.rbSiAsiCie7.Location = New System.Drawing.Point(10, 12)
        Me.rbSiAsiCie7.Name = "rbSiAsiCie7"
        Me.rbSiAsiCie7.Size = New System.Drawing.Size(34, 17)
        Me.rbSiAsiCie7.TabIndex = 114
        Me.rbSiAsiCie7.Tag = "38"
        Me.rbSiAsiCie7.Text = "Si"
        Me.rbSiAsiCie7.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(429, 250)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(84, 13)
        Me.Label19.TabIndex = 197
        Me.Label19.Text = "Asiento Cierre  7"
        '
        'WEditarPlanCuentaGe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(627, 410)
        Me.Controls.Add(Me.gbAsientoCierre7)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.gbAsientoCierre9)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.gbAsientoApertura)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.TxtCodEmp)
        Me.Controls.Add(Me.txtNomEmp)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.GbMoneda)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.gbBanco)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TxtNomCtaAut2)
        Me.Controls.Add(Me.TxtNomCtaAut1)
        Me.Controls.Add(Me.GbAutomatica)
        Me.Controls.Add(Me.TxtNomForCon)
        Me.Controls.Add(Me.TxtCodForCon)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TxtCtaAut2)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TxtCtaAut1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.gbdiferencia)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.gbflujo)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.gbarea)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.gbalmacen)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.gbCcosto)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.gbAuxiliar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.gbdocumento)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtNomCta)
        Me.Controls.Add(Me.txtCodCta)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "WEditarPlanCuentaGe"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WEditarPlanCuentaGe"
        Me.gbdocumento.ResumeLayout(False)
        Me.gbdocumento.PerformLayout()
        Me.gbAuxiliar.ResumeLayout(False)
        Me.gbAuxiliar.PerformLayout()
        Me.gbCcosto.ResumeLayout(False)
        Me.gbCcosto.PerformLayout()
        Me.gbflujo.ResumeLayout(False)
        Me.gbflujo.PerformLayout()
        Me.gbarea.ResumeLayout(False)
        Me.gbarea.PerformLayout()
        Me.gbalmacen.ResumeLayout(False)
        Me.gbalmacen.PerformLayout()
        Me.gbdiferencia.ResumeLayout(False)
        Me.gbdiferencia.PerformLayout()
        Me.GbAutomatica.ResumeLayout(False)
        Me.GbAutomatica.PerformLayout()
        Me.gbBanco.ResumeLayout(False)
        Me.gbBanco.PerformLayout()
        Me.GbMoneda.ResumeLayout(False)
        Me.GbMoneda.PerformLayout()
        Me.gbAsientoApertura.ResumeLayout(False)
        Me.gbAsientoApertura.PerformLayout()
        Me.gbAsientoCierre9.ResumeLayout(False)
        Me.gbAsientoCierre9.PerformLayout()
        Me.gbAsientoCierre7.ResumeLayout(False)
        Me.gbAsientoCierre7.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Function ListaControles() As List(Of CtrlsEdit)
        Dim lis As New List(Of CtrlsEdit)
        Dim item As CtrlsEdit

        item = New CtrlsEdit
        item.Control = Me.txtCodCta
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Cuenta"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloAlfaNumericoSinEspacio
        item.Nuevo = "1"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtNomCta
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Nombre"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.gbdocumento
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
        item.Control = Me.rbsidoc
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
        item.Control = Me.rbnodoc
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
        item.Control = Me.gbAuxiliar
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
        item.Control = Me.rbsiaux
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
        item.Control = Me.rbnoaux
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
        item.Control = Me.gbCcosto
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
        item.Control = Me.rbsicto
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
        item.Control = Me.rbnocto
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
        item.Control = Me.gbalmacen
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
        item.Control = Me.rbsialm
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
        item.Control = Me.rbnoalm
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
        item.Control = Me.gbarea
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
        item.Control = Me.rbsiare
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
        item.Control = Me.rbnoare
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
        item.Control = Me.gbflujo
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
        item.Control = Me.rbsiflu
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
        item.Control = Me.rbnoflu
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
        item.Control = Me.gbautomatica
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
        item.Control = Me.rbsiaut
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
        item.Control = Me.rbnoaut
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
        item.Control = Me.gbdiferencia
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
        item.Control = Me.rbsidif
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
        item.Control = Me.rbnodif
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
        item.Control = Me.gbBanco
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
        item.Control = Me.rbsibco
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
        item.Control = Me.rbnobco
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
        item.Control = Me.GbMoneda
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
        item.Control = Me.RbSol
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
        item.Control = Me.RbDol
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
        item.Control = Me.RbEur
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
        item.Control = Me.gbAsientoApertura
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
        item.Control = Me.rbSiAsiApe
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
        item.Control = Me.rbNoAsiApe
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
        item.Control = Me.gbAsientoCierre9
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
        item.Control = Me.rbSiAsiCie9
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
        item.Control = Me.rbNoAsiCie9
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
        item.Control = Me.gbAsientoCierre7
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
        item.Control = Me.rbSiAsiCie7
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
        item.Control = Me.rbNoAsiCie7
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
        item.Control = Me.TxtCtaAut1
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Automarica1"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloAlfaNumericoSinEspacio
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtNomCtaAut1
        item.PasaFoco = "0"
        item.Formato = "1"
        item.PasarCursor = "0"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Nombre Automarica1"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtCtaAut2
        item.PasaFoco = "0"
        item.Formato = "1"
        item.PasarCursor = "0"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Automarica2"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtNomCtaAut2
        item.PasaFoco = "0"
        item.Formato = "1"
        item.PasarCursor = "0"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Nombre Automarica2"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)


        item = New CtrlsEdit
        item.Control = Me.TxtCodForCon
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Codigo"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloAlfaNumericoSinEspacio
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtNomForCon
        item.PasaFoco = "0"
        item.Formato = "1"
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
    Friend WithEvents txtNomCta As System.Windows.Forms.TextBox
    Friend WithEvents txtCodCta As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gbdocumento As System.Windows.Forms.GroupBox
    Friend WithEvents rbnodoc As System.Windows.Forms.RadioButton
    Friend WithEvents rbsidoc As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gbAuxiliar As System.Windows.Forms.GroupBox
    Friend WithEvents rbnoaux As System.Windows.Forms.RadioButton
    Friend WithEvents rbsiaux As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gbCcosto As System.Windows.Forms.GroupBox
    Friend WithEvents rbnocto As System.Windows.Forms.RadioButton
    Friend WithEvents rbsicto As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents gbflujo As System.Windows.Forms.GroupBox
    Friend WithEvents rbnoflu As System.Windows.Forms.RadioButton
    Friend WithEvents rbsiflu As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents gbarea As System.Windows.Forms.GroupBox
    Friend WithEvents rbnoare As System.Windows.Forms.RadioButton
    Friend WithEvents rbsiare As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents gbalmacen As System.Windows.Forms.GroupBox
    Friend WithEvents rbnoalm As System.Windows.Forms.RadioButton
    Friend WithEvents rbsialm As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents gbdiferencia As System.Windows.Forms.GroupBox
    Friend WithEvents rbnodif As System.Windows.Forms.RadioButton
    Friend WithEvents rbsidif As System.Windows.Forms.RadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtCtaAut1 As System.Windows.Forms.TextBox
    Friend WithEvents TxtCtaAut2 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtCodForCon As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtNomForCon As System.Windows.Forms.TextBox
    Friend WithEvents GbAutomatica As System.Windows.Forms.GroupBox
    Friend WithEvents RbNoAut As System.Windows.Forms.RadioButton
    Friend WithEvents RbSiAut As System.Windows.Forms.RadioButton
    Friend WithEvents TxtNomCtaAut1 As System.Windows.Forms.TextBox
    Friend WithEvents TxtNomCtaAut2 As System.Windows.Forms.TextBox
    Friend WithEvents gbBanco As System.Windows.Forms.GroupBox
    Friend WithEvents rbnobco As System.Windows.Forms.RadioButton
    Friend WithEvents rbsibco As System.Windows.Forms.RadioButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GbMoneda As System.Windows.Forms.GroupBox
    Friend WithEvents RbDol As System.Windows.Forms.RadioButton
    Friend WithEvents RbSol As System.Windows.Forms.RadioButton
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents RbEur As System.Windows.Forms.RadioButton
    Friend WithEvents TxtCodEmp As System.Windows.Forms.TextBox
    Friend WithEvents txtNomEmp As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents gbAsientoApertura As System.Windows.Forms.GroupBox
    Friend WithEvents rbNoAsiApe As System.Windows.Forms.RadioButton
    Friend WithEvents rbSiAsiApe As System.Windows.Forms.RadioButton
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents gbAsientoCierre9 As System.Windows.Forms.GroupBox
    Friend WithEvents rbNoAsiCie9 As System.Windows.Forms.RadioButton
    Friend WithEvents rbSiAsiCie9 As System.Windows.Forms.RadioButton
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents gbAsientoCierre7 As System.Windows.Forms.GroupBox
    Friend WithEvents rbNoAsiCie7 As System.Windows.Forms.RadioButton
    Friend WithEvents rbSiAsiCie7 As System.Windows.Forms.RadioButton
    Friend WithEvents Label19 As System.Windows.Forms.Label
End Class
