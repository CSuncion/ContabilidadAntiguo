<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WImpCentroCostoDetalle
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
        Me.TxtNomCta = New System.Windows.Forms.TextBox
        Me.TxtCodCta = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtCodEmp = New System.Windows.Forms.TextBox
        Me.txtNomEmp = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TxtDesMes1 = New System.Windows.Forms.TextBox
        Me.txtDesMes = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtCodMes1 = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtCodMes = New System.Windows.Forms.TextBox
        Me.txtAno = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.gbAnaAux = New System.Windows.Forms.GroupBox
        Me.rbtAnaIndividual = New System.Windows.Forms.RadioButton
        Me.rbtAnaTodos = New System.Windows.Forms.RadioButton
        Me.btnEjecutar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.txtNomCcHas = New System.Windows.Forms.TextBox
        Me.txtNomCcDes = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCodCcHas = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtCodCcDes = New System.Windows.Forms.TextBox
        Me.txtNomCue2 = New System.Windows.Forms.TextBox
        Me.txtCodCue2 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrCentroCostoDetalle1 = New Presentacion.CrCentroCostoDetalle
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.gbAnaAux.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtNomCta
        '
        Me.TxtNomCta.Location = New System.Drawing.Point(331, 105)
        Me.TxtNomCta.Name = "TxtNomCta"
        Me.TxtNomCta.ReadOnly = True
        Me.TxtNomCta.Size = New System.Drawing.Size(221, 20)
        Me.TxtNomCta.TabIndex = 281
        Me.TxtNomCta.Tag = "15"
        '
        'TxtCodCta
        '
        Me.TxtCodCta.BackColor = System.Drawing.Color.White
        Me.TxtCodCta.Location = New System.Drawing.Point(264, 105)
        Me.TxtCodCta.Name = "TxtCodCta"
        Me.TxtCodCta.Size = New System.Drawing.Size(65, 20)
        Me.TxtCodCta.TabIndex = 5
        Me.TxtCodCta.Tag = "14"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(178, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 280
        Me.Label1.Text = "Cta Desde"
        '
        'TxtCodEmp
        '
        Me.TxtCodEmp.Location = New System.Drawing.Point(12, 23)
        Me.TxtCodEmp.Name = "TxtCodEmp"
        Me.TxtCodEmp.ReadOnly = True
        Me.TxtCodEmp.Size = New System.Drawing.Size(55, 20)
        Me.TxtCodEmp.TabIndex = 276
        Me.TxtCodEmp.Tag = "0"
        '
        'txtNomEmp
        '
        Me.txtNomEmp.Location = New System.Drawing.Point(73, 23)
        Me.txtNomEmp.Name = "txtNomEmp"
        Me.txtNomEmp.ReadOnly = True
        Me.txtNomEmp.Size = New System.Drawing.Size(231, 20)
        Me.txtNomEmp.TabIndex = 277
        Me.txtNomEmp.Tag = "1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(12, 3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 279
        Me.Label6.Text = "Empresa"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtDesMes1)
        Me.GroupBox1.Controls.Add(Me.txtDesMes)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TxtCodMes1)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.txtCodMes)
        Me.GroupBox1.Controls.Add(Me.txtAno)
        Me.GroupBox1.Location = New System.Drawing.Point(311, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(609, 53)
        Me.GroupBox1.TabIndex = 278
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Elija Periodo"
        '
        'TxtDesMes1
        '
        Me.TxtDesMes1.BackColor = System.Drawing.SystemColors.Control
        Me.TxtDesMes1.Location = New System.Drawing.Point(484, 20)
        Me.TxtDesMes1.MaxLength = 10
        Me.TxtDesMes1.Name = "TxtDesMes1"
        Me.TxtDesMes1.ReadOnly = True
        Me.TxtDesMes1.Size = New System.Drawing.Size(110, 20)
        Me.TxtDesMes1.TabIndex = 286
        Me.TxtDesMes1.Tag = "6"
        '
        'txtDesMes
        '
        Me.txtDesMes.BackColor = System.Drawing.SystemColors.Control
        Me.txtDesMes.Location = New System.Drawing.Point(240, 20)
        Me.txtDesMes.MaxLength = 10
        Me.txtDesMes.Name = "txtDesMes"
        Me.txtDesMes.ReadOnly = True
        Me.txtDesMes.Size = New System.Drawing.Size(110, 20)
        Me.txtDesMes.TabIndex = 103
        Me.txtDesMes.Tag = "4"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(354, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 287
        Me.Label3.Text = "Mes Hasta"
        '
        'TxtCodMes1
        '
        Me.TxtCodMes1.BackColor = System.Drawing.Color.White
        Me.TxtCodMes1.Location = New System.Drawing.Point(431, 20)
        Me.TxtCodMes1.MaxLength = 10
        Me.TxtCodMes1.Name = "TxtCodMes1"
        Me.TxtCodMes1.Size = New System.Drawing.Size(44, 20)
        Me.TxtCodMes1.TabIndex = 1
        Me.TxtCodMes1.Tag = "5"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(15, 25)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(29, 13)
        Me.Label20.TabIndex = 228
        Me.Label20.Text = "Año"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(115, 25)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(70, 13)
        Me.Label19.TabIndex = 229
        Me.Label19.Text = "Mes Desde"
        '
        'txtCodMes
        '
        Me.txtCodMes.BackColor = System.Drawing.Color.White
        Me.txtCodMes.Location = New System.Drawing.Point(193, 20)
        Me.txtCodMes.MaxLength = 10
        Me.txtCodMes.Name = "txtCodMes"
        Me.txtCodMes.Size = New System.Drawing.Size(44, 20)
        Me.txtCodMes.TabIndex = 0
        Me.txtCodMes.Tag = "3"
        '
        'txtAno
        '
        Me.txtAno.BackColor = System.Drawing.SystemColors.Control
        Me.txtAno.Location = New System.Drawing.Point(48, 20)
        Me.txtAno.MaxLength = 4
        Me.txtAno.Name = "txtAno"
        Me.txtAno.ReadOnly = True
        Me.txtAno.Size = New System.Drawing.Size(55, 20)
        Me.txtAno.TabIndex = 102
        Me.txtAno.Tag = "2"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.crv1)
        Me.Panel1.Location = New System.Drawing.Point(2, 144)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1064, 340)
        Me.Panel1.TabIndex = 285
        '
        'gbAnaAux
        '
        Me.gbAnaAux.Controls.Add(Me.rbtAnaIndividual)
        Me.gbAnaAux.Controls.Add(Me.rbtAnaTodos)
        Me.gbAnaAux.Location = New System.Drawing.Point(15, 95)
        Me.gbAnaAux.Name = "gbAnaAux"
        Me.gbAnaAux.Size = New System.Drawing.Size(148, 28)
        Me.gbAnaAux.TabIndex = 4
        Me.gbAnaAux.TabStop = False
        Me.gbAnaAux.Tag = "11"
        '
        'rbtAnaIndividual
        '
        Me.rbtAnaIndividual.AutoSize = True
        Me.rbtAnaIndividual.Location = New System.Drawing.Point(69, 10)
        Me.rbtAnaIndividual.Name = "rbtAnaIndividual"
        Me.rbtAnaIndividual.Size = New System.Drawing.Size(57, 17)
        Me.rbtAnaIndividual.TabIndex = 100
        Me.rbtAnaIndividual.Tag = "13"
        Me.rbtAnaIndividual.Text = "Rango"
        Me.rbtAnaIndividual.UseVisualStyleBackColor = True
        '
        'rbtAnaTodos
        '
        Me.rbtAnaTodos.AutoSize = True
        Me.rbtAnaTodos.Checked = True
        Me.rbtAnaTodos.Location = New System.Drawing.Point(6, 10)
        Me.rbtAnaTodos.Name = "rbtAnaTodos"
        Me.rbtAnaTodos.Size = New System.Drawing.Size(55, 17)
        Me.rbtAnaTodos.TabIndex = 100
        Me.rbtAnaTodos.TabStop = True
        Me.rbtAnaTodos.Tag = "12"
        Me.rbtAnaTodos.Text = "Todas"
        Me.rbtAnaTodos.UseVisualStyleBackColor = True
        '
        'btnEjecutar
        '
        Me.btnEjecutar.Image = Global.Presentacion.My.Resources.Resources.apply
        Me.btnEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEjecutar.Location = New System.Drawing.Point(806, 62)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(107, 23)
        Me.btnEjecutar.TabIndex = 7
        Me.btnEjecutar.Tag = "18"
        Me.btnEjecutar.Text = "Ejecutar"
        Me.btnEjecutar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Presentacion.My.Resources.Resources.action_stop
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(914, 62)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(104, 23)
        Me.btnCancelar.TabIndex = 8
        Me.btnCancelar.Tag = "19"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'txtNomCcHas
        '
        Me.txtNomCcHas.BackColor = System.Drawing.SystemColors.Control
        Me.txtNomCcHas.Location = New System.Drawing.Point(415, 68)
        Me.txtNomCcHas.MaxLength = 10
        Me.txtNomCcHas.Name = "txtNomCcHas"
        Me.txtNomCcHas.ReadOnly = True
        Me.txtNomCcHas.Size = New System.Drawing.Size(110, 20)
        Me.txtNomCcHas.TabIndex = 292
        Me.txtNomCcHas.Tag = "10"
        '
        'txtNomCcDes
        '
        Me.txtNomCcDes.BackColor = System.Drawing.SystemColors.Control
        Me.txtNomCcDes.Location = New System.Drawing.Point(177, 68)
        Me.txtNomCcDes.MaxLength = 10
        Me.txtNomCcDes.Name = "txtNomCcDes"
        Me.txtNomCcDes.ReadOnly = True
        Me.txtNomCcDes.Size = New System.Drawing.Size(110, 20)
        Me.txtNomCcDes.TabIndex = 290
        Me.txtNomCcDes.Tag = "8"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(291, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 293
        Me.Label2.Text = "C.C Hasta"
        '
        'txtCodCcHas
        '
        Me.txtCodCcHas.BackColor = System.Drawing.Color.White
        Me.txtCodCcHas.Location = New System.Drawing.Point(368, 68)
        Me.txtCodCcHas.MaxLength = 10
        Me.txtCodCcHas.Name = "txtCodCcHas"
        Me.txtCodCcHas.Size = New System.Drawing.Size(44, 20)
        Me.txtCodCcHas.TabIndex = 3
        Me.txtCodCcHas.Tag = "9"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(15, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 291
        Me.Label4.Text = "C.C Desde"
        '
        'txtCodCcDes
        '
        Me.txtCodCcDes.BackColor = System.Drawing.Color.White
        Me.txtCodCcDes.Location = New System.Drawing.Point(130, 68)
        Me.txtCodCcDes.MaxLength = 10
        Me.txtCodCcDes.Name = "txtCodCcDes"
        Me.txtCodCcDes.Size = New System.Drawing.Size(44, 20)
        Me.txtCodCcDes.TabIndex = 2
        Me.txtCodCcDes.Tag = "7"
        '
        'txtNomCue2
        '
        Me.txtNomCue2.Location = New System.Drawing.Point(717, 105)
        Me.txtNomCue2.Name = "txtNomCue2"
        Me.txtNomCue2.ReadOnly = True
        Me.txtNomCue2.Size = New System.Drawing.Size(221, 20)
        Me.txtNomCue2.TabIndex = 296
        Me.txtNomCue2.Tag = "17"
        '
        'txtCodCue2
        '
        Me.txtCodCue2.BackColor = System.Drawing.Color.White
        Me.txtCodCue2.Location = New System.Drawing.Point(650, 105)
        Me.txtCodCue2.Name = "txtCodCue2"
        Me.txtCodCue2.Size = New System.Drawing.Size(65, 20)
        Me.txtCodCue2.TabIndex = 6
        Me.txtCodCue2.Tag = "16"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(564, 108)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 295
        Me.Label5.Text = "Cta Hasta"
        '
        'crv1
        '
        Me.crv1.ActiveViewIndex = 0
        Me.crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crv1.DisplayGroupTree = False
        Me.crv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crv1.Location = New System.Drawing.Point(0, 0)
        Me.crv1.Name = "crv1"
        Me.crv1.ReportSource = Me.CrCentroCostoDetalle1
        Me.crv1.Size = New System.Drawing.Size(1064, 340)
        Me.crv1.TabIndex = 10
        '
        'WImpCentroCostoDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1068, 485)
        Me.Controls.Add(Me.txtNomCue2)
        Me.Controls.Add(Me.txtCodCue2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtNomCcHas)
        Me.Controls.Add(Me.gbAnaAux)
        Me.Controls.Add(Me.txtNomCcDes)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtCodCcHas)
        Me.Controls.Add(Me.TxtNomCta)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtCodCta)
        Me.Controls.Add(Me.txtCodCcDes)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtCodEmp)
        Me.Controls.Add(Me.txtNomEmp)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnEjecutar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "WImpCentroCostoDetalle"
        Me.Text = "Analisis De Auxiliares"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.gbAnaAux.ResumeLayout(False)
        Me.gbAnaAux.PerformLayout()
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
        item.Control = Me.txtAno
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = "Ano"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtCodMes
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = "Mes"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtDesMes
        item.PasaFoco = "0"
        item.Formato = "0"
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
        item.Control = Me.TxtCodMes1
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = "Mes"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtDesMes1
        item.PasaFoco = "0"
        item.Formato = "0"
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
        item.Control = Me.txtCodCcDes
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = "Cuenta"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtNomCcDes
        item.PasaFoco = "0"
        item.Formato = "0"
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
        item.Control = Me.txtCodCcHas
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = "Cuenta"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtNomCcHas
        item.PasaFoco = "0"
        item.Formato = "0"
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
        item.Control = Me.gbAnaAux
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
        item.Control = Me.rbtAnaTodos
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
        item.Control = Me.rbtAnaIndividual
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
        item.Control = Me.TxtCodCta
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = "Cuenta"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtNomCta
        item.PasaFoco = "0"
        item.Formato = "0"
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
        item.Control = Me.txtCodCue2
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = "Cuenta 2"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtNomCue2
        item.PasaFoco = "0"
        item.Formato = "0"
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
        item.Control = Me.btnEjecutar
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

    Friend WithEvents TxtNomCta As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodCta As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtCodEmp As System.Windows.Forms.TextBox
    Friend WithEvents txtNomEmp As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDesMes As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtCodMes As System.Windows.Forms.TextBox
    Friend WithEvents txtAno As System.Windows.Forms.TextBox
    Friend WithEvents TxtDesMes1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtCodMes1 As System.Windows.Forms.TextBox
    Friend WithEvents btnEjecutar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents gbAnaAux As System.Windows.Forms.GroupBox
    Friend WithEvents rbtAnaIndividual As System.Windows.Forms.RadioButton
    Friend WithEvents rbtAnaTodos As System.Windows.Forms.RadioButton
    Friend WithEvents txtNomCcHas As System.Windows.Forms.TextBox
    Friend WithEvents txtNomCcDes As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodCcHas As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCodCcDes As System.Windows.Forms.TextBox
    Friend WithEvents txtNomCue2 As System.Windows.Forms.TextBox
    Friend WithEvents txtCodCue2 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CrCentroCostoDetalle1 As Presentacion.CrCentroCostoDetalle
End Class
