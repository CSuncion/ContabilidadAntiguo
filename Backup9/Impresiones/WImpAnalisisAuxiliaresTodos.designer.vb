<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WImpAnalisisAuxiliaresTodos
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
        Me.gbAuxiliar = New System.Windows.Forms.GroupBox
        Me.rbtAuxIndividual = New System.Windows.Forms.RadioButton
        Me.rbtAuxTodos = New System.Windows.Forms.RadioButton
        Me.gbCuenta = New System.Windows.Forms.GroupBox
        Me.rbtAnaIndividual = New System.Windows.Forms.RadioButton
        Me.rbtAnaTodos = New System.Windows.Forms.RadioButton
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnEjecutar = New System.Windows.Forms.Button
        Me.TxtDesMes1 = New System.Windows.Forms.TextBox
        Me.txtDesMes = New System.Windows.Forms.TextBox
        Me.TxtDesAux = New System.Windows.Forms.TextBox
        Me.TxtCodAux = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtCodMes1 = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtCodMes = New System.Windows.Forms.TextBox
        Me.txtAno = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptAnalisisAuxiliares1 = New Presentacion.CrRptAnalisisAuxiliares
        Me.GroupBox1.SuspendLayout()
        Me.gbAuxiliar.SuspendLayout()
        Me.gbCuenta.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtNomCta
        '
        Me.TxtNomCta.Location = New System.Drawing.Point(771, 22)
        Me.TxtNomCta.Name = "TxtNomCta"
        Me.TxtNomCta.ReadOnly = True
        Me.TxtNomCta.Size = New System.Drawing.Size(159, 20)
        Me.TxtNomCta.TabIndex = 281
        Me.TxtNomCta.Tag = "11"
        '
        'TxtCodCta
        '
        Me.TxtCodCta.BackColor = System.Drawing.Color.White
        Me.TxtCodCta.Location = New System.Drawing.Point(696, 22)
        Me.TxtCodCta.Name = "TxtCodCta"
        Me.TxtCodCta.Size = New System.Drawing.Size(74, 20)
        Me.TxtCodCta.TabIndex = 3
        Me.TxtCodCta.Tag = "10"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(487, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 280
        Me.Label1.Text = "Cuenta"
        '
        'TxtCodEmp
        '
        Me.TxtCodEmp.Location = New System.Drawing.Point(76, 22)
        Me.TxtCodEmp.Name = "TxtCodEmp"
        Me.TxtCodEmp.ReadOnly = True
        Me.TxtCodEmp.Size = New System.Drawing.Size(32, 20)
        Me.TxtCodEmp.TabIndex = 276
        Me.TxtCodEmp.Tag = "0"
        '
        'txtNomEmp
        '
        Me.txtNomEmp.Location = New System.Drawing.Point(109, 22)
        Me.txtNomEmp.Name = "txtNomEmp"
        Me.txtNomEmp.ReadOnly = True
        Me.txtNomEmp.Size = New System.Drawing.Size(145, 20)
        Me.txtNomEmp.TabIndex = 277
        Me.txtNomEmp.Tag = "1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(15, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 279
        Me.Label6.Text = "Empresa"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.gbAuxiliar)
        Me.GroupBox1.Controls.Add(Me.gbCuenta)
        Me.GroupBox1.Controls.Add(Me.btnCancelar)
        Me.GroupBox1.Controls.Add(Me.btnEjecutar)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TxtNomCta)
        Me.GroupBox1.Controls.Add(Me.TxtDesMes1)
        Me.GroupBox1.Controls.Add(Me.TxtCodCta)
        Me.GroupBox1.Controls.Add(Me.txtDesMes)
        Me.GroupBox1.Controls.Add(Me.TxtDesAux)
        Me.GroupBox1.Controls.Add(Me.TxtCodAux)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TxtCodMes1)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.txtCodMes)
        Me.GroupBox1.Controls.Add(Me.txtAno)
        Me.GroupBox1.Controls.Add(Me.TxtCodEmp)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtNomEmp)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1060, 77)
        Me.GroupBox1.TabIndex = 278
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Elija Periodo"
        '
        'gbAuxiliar
        '
        Me.gbAuxiliar.Controls.Add(Me.rbtAuxIndividual)
        Me.gbAuxiliar.Controls.Add(Me.rbtAuxTodos)
        Me.gbAuxiliar.Location = New System.Drawing.Point(542, 42)
        Me.gbAuxiliar.Name = "gbAuxiliar"
        Me.gbAuxiliar.Size = New System.Drawing.Size(146, 26)
        Me.gbAuxiliar.TabIndex = 4
        Me.gbAuxiliar.TabStop = False
        Me.gbAuxiliar.Tag = "12"
        '
        'rbtAuxIndividual
        '
        Me.rbtAuxIndividual.AutoSize = True
        Me.rbtAuxIndividual.Location = New System.Drawing.Point(70, 8)
        Me.rbtAuxIndividual.Name = "rbtAuxIndividual"
        Me.rbtAuxIndividual.Size = New System.Drawing.Size(70, 17)
        Me.rbtAuxIndividual.TabIndex = 101
        Me.rbtAuxIndividual.Tag = "14"
        Me.rbtAuxIndividual.Text = "Individual"
        Me.rbtAuxIndividual.UseVisualStyleBackColor = True
        '
        'rbtAuxTodos
        '
        Me.rbtAuxTodos.AutoSize = True
        Me.rbtAuxTodos.Checked = True
        Me.rbtAuxTodos.Location = New System.Drawing.Point(14, 7)
        Me.rbtAuxTodos.Name = "rbtAuxTodos"
        Me.rbtAuxTodos.Size = New System.Drawing.Size(55, 17)
        Me.rbtAuxTodos.TabIndex = 100
        Me.rbtAuxTodos.TabStop = True
        Me.rbtAuxTodos.Tag = "13"
        Me.rbtAuxTodos.Text = "Todas"
        Me.rbtAuxTodos.UseVisualStyleBackColor = True
        '
        'gbCuenta
        '
        Me.gbCuenta.Controls.Add(Me.rbtAnaIndividual)
        Me.gbCuenta.Controls.Add(Me.rbtAnaTodos)
        Me.gbCuenta.Location = New System.Drawing.Point(542, 16)
        Me.gbCuenta.Name = "gbCuenta"
        Me.gbCuenta.Size = New System.Drawing.Size(147, 26)
        Me.gbCuenta.TabIndex = 2
        Me.gbCuenta.TabStop = False
        Me.gbCuenta.Tag = "7"
        '
        'rbtAnaIndividual
        '
        Me.rbtAnaIndividual.AutoSize = True
        Me.rbtAnaIndividual.Location = New System.Drawing.Point(70, 7)
        Me.rbtAnaIndividual.Name = "rbtAnaIndividual"
        Me.rbtAnaIndividual.Size = New System.Drawing.Size(70, 17)
        Me.rbtAnaIndividual.TabIndex = 101
        Me.rbtAnaIndividual.Tag = "9"
        Me.rbtAnaIndividual.Text = "Individual"
        Me.rbtAnaIndividual.UseVisualStyleBackColor = True
        '
        'rbtAnaTodos
        '
        Me.rbtAnaTodos.AutoSize = True
        Me.rbtAnaTodos.Checked = True
        Me.rbtAnaTodos.Location = New System.Drawing.Point(14, 7)
        Me.rbtAnaTodos.Name = "rbtAnaTodos"
        Me.rbtAnaTodos.Size = New System.Drawing.Size(55, 17)
        Me.rbtAnaTodos.TabIndex = 100
        Me.rbtAnaTodos.TabStop = True
        Me.rbtAnaTodos.Tag = "8"
        Me.rbtAnaTodos.Text = "Todas"
        Me.rbtAnaTodos.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Presentacion.My.Resources.Resources.action_stop
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(947, 45)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(107, 23)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Tag = "18"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnEjecutar
        '
        Me.btnEjecutar.Image = Global.Presentacion.My.Resources.Resources.apply
        Me.btnEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEjecutar.Location = New System.Drawing.Point(946, 20)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(107, 23)
        Me.btnEjecutar.TabIndex = 6
        Me.btnEjecutar.Tag = "17"
        Me.btnEjecutar.Text = "Ejecutar"
        Me.btnEjecutar.UseVisualStyleBackColor = True
        '
        'TxtDesMes1
        '
        Me.TxtDesMes1.BackColor = System.Drawing.SystemColors.Control
        Me.TxtDesMes1.Location = New System.Drawing.Point(365, 46)
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
        Me.txtDesMes.Location = New System.Drawing.Point(365, 20)
        Me.txtDesMes.MaxLength = 10
        Me.txtDesMes.Name = "txtDesMes"
        Me.txtDesMes.ReadOnly = True
        Me.txtDesMes.Size = New System.Drawing.Size(110, 20)
        Me.txtDesMes.TabIndex = 103
        Me.txtDesMes.Tag = "4"
        '
        'TxtDesAux
        '
        Me.TxtDesAux.Location = New System.Drawing.Point(771, 48)
        Me.TxtDesAux.Name = "TxtDesAux"
        Me.TxtDesAux.ReadOnly = True
        Me.TxtDesAux.Size = New System.Drawing.Size(159, 20)
        Me.TxtDesAux.TabIndex = 284
        Me.TxtDesAux.Tag = "16"
        '
        'TxtCodAux
        '
        Me.TxtCodAux.BackColor = System.Drawing.Color.White
        Me.TxtCodAux.Location = New System.Drawing.Point(696, 48)
        Me.TxtCodAux.Name = "TxtCodAux"
        Me.TxtCodAux.Size = New System.Drawing.Size(74, 20)
        Me.TxtCodAux.TabIndex = 5
        Me.TxtCodAux.Tag = "15"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(269, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 287
        Me.Label3.Text = "M. Hasta"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(488, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 283
        Me.Label2.Text = "Auxiliar"
        '
        'TxtCodMes1
        '
        Me.TxtCodMes1.BackColor = System.Drawing.Color.White
        Me.TxtCodMes1.Location = New System.Drawing.Point(336, 46)
        Me.TxtCodMes1.MaxLength = 10
        Me.TxtCodMes1.Name = "TxtCodMes1"
        Me.TxtCodMes1.Size = New System.Drawing.Size(28, 20)
        Me.TxtCodMes1.TabIndex = 1
        Me.TxtCodMes1.Tag = "5"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(15, 48)
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
        Me.Label19.Location = New System.Drawing.Point(269, 25)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(61, 13)
        Me.Label19.TabIndex = 229
        Me.Label19.Text = "M. Desde"
        '
        'txtCodMes
        '
        Me.txtCodMes.BackColor = System.Drawing.Color.White
        Me.txtCodMes.Location = New System.Drawing.Point(337, 20)
        Me.txtCodMes.MaxLength = 10
        Me.txtCodMes.Name = "txtCodMes"
        Me.txtCodMes.Size = New System.Drawing.Size(27, 20)
        Me.txtCodMes.TabIndex = 0
        Me.txtCodMes.Tag = "3"
        '
        'txtAno
        '
        Me.txtAno.BackColor = System.Drawing.SystemColors.Control
        Me.txtAno.Location = New System.Drawing.Point(75, 46)
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
        Me.Panel1.Location = New System.Drawing.Point(5, 88)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1062, 396)
        Me.Panel1.TabIndex = 285
        '
        'crv1
        '
        Me.crv1.ActiveViewIndex = 0
        Me.crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crv1.DisplayGroupTree = False
        Me.crv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crv1.Location = New System.Drawing.Point(0, 0)
        Me.crv1.Name = "crv1"
        Me.crv1.ReportSource = Me.CrRptAnalisisAuxiliares1
        Me.crv1.Size = New System.Drawing.Size(1062, 396)
        Me.crv1.TabIndex = 100
        '
        'WImpAnalisisAuxiliaresTodos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1071, 485)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "WImpAnalisisAuxiliaresTodos"
        Me.Text = "Auxiliares Todos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbAuxiliar.ResumeLayout(False)
        Me.gbAuxiliar.PerformLayout()
        Me.gbCuenta.ResumeLayout(False)
        Me.gbCuenta.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

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
        item.Obligatorio = "0"
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
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = "Ano"
        item.Obligatorio = "0"
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
        item.Control = Me.gbCuenta
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
        item.Control = Me.rbtAuxTodos
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
        item.Control = Me.rbtAuxIndividual
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
        item.Control = Me.TxtCodAux
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = "Auxiliar"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtDesAux
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
    Friend WithEvents TxtDesAux As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodAux As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnEjecutar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptAnalisisAuxiliares1 As Presentacion.CrRptAnalisisAuxiliares
    Friend WithEvents gbCuenta As System.Windows.Forms.GroupBox
    Friend WithEvents rbtAnaIndividual As System.Windows.Forms.RadioButton
    Friend WithEvents rbtAnaTodos As System.Windows.Forms.RadioButton
    Friend WithEvents gbAuxiliar As System.Windows.Forms.GroupBox
    Friend WithEvents rbtAuxIndividual As System.Windows.Forms.RadioButton
    Friend WithEvents rbtAuxTodos As System.Windows.Forms.RadioButton
End Class
