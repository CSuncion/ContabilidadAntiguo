<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WImpRegistroComprasDol
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
        Me.TxtCodEmp = New System.Windows.Forms.TextBox
        Me.txtNomEmp = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnEjecutar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptRegistroComprasDol1 = New Presentacion.CrRptRegistroComprasDol
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtpFechaHas = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpFechaDes = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtCodEmp
        '
        Me.TxtCodEmp.Location = New System.Drawing.Point(67, 19)
        Me.TxtCodEmp.Name = "TxtCodEmp"
        Me.TxtCodEmp.ReadOnly = True
        Me.TxtCodEmp.Size = New System.Drawing.Size(35, 20)
        Me.TxtCodEmp.TabIndex = 100
        Me.TxtCodEmp.Tag = "0"
        '
        'txtNomEmp
        '
        Me.txtNomEmp.Location = New System.Drawing.Point(104, 19)
        Me.txtNomEmp.Name = "txtNomEmp"
        Me.txtNomEmp.ReadOnly = True
        Me.txtNomEmp.Size = New System.Drawing.Size(231, 20)
        Me.txtNomEmp.TabIndex = 101
        Me.txtNomEmp.Tag = "1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(6, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 256
        Me.Label6.Text = "Empresa"
        '
        'btnEjecutar
        '
        Me.btnEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEjecutar.Location = New System.Drawing.Point(737, 17)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(107, 23)
        Me.btnEjecutar.TabIndex = 2
        Me.btnEjecutar.Tag = "4"
        Me.btnEjecutar.Text = "Ejecutar"
        Me.btnEjecutar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(850, 17)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(104, 23)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Tag = "5"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.crv1)
        Me.Panel1.Location = New System.Drawing.Point(5, 60)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1044, 409)
        Me.Panel1.TabIndex = 258
        '
        'crv1
        '
        Me.crv1.ActiveViewIndex = 0
        Me.crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crv1.DisplayGroupTree = False
        Me.crv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crv1.Location = New System.Drawing.Point(0, 0)
        Me.crv1.Name = "crv1"
        Me.crv1.ReportSource = Me.CrRptRegistroComprasDol1
        Me.crv1.Size = New System.Drawing.Size(1044, 409)
        Me.crv1.TabIndex = 10
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpFechaHas)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtpFechaDes)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.TxtCodEmp)
        Me.GroupBox1.Controls.Add(Me.btnCancelar)
        Me.GroupBox1.Controls.Add(Me.btnEjecutar)
        Me.GroupBox1.Controls.Add(Me.txtNomEmp)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1044, 51)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Elija Filtro"
        '
        'dtpFechaHas
        '
        Me.dtpFechaHas.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaHas.Location = New System.Drawing.Point(623, 18)
        Me.dtpFechaHas.Name = "dtpFechaHas"
        Me.dtpFechaHas.Size = New System.Drawing.Size(93, 20)
        Me.dtpFechaHas.TabIndex = 1
        Me.dtpFechaHas.Tag = "3"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(547, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 260
        Me.Label1.Text = "F.Vou.Has"
        '
        'dtpFechaDes
        '
        Me.dtpFechaDes.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaDes.Location = New System.Drawing.Point(436, 19)
        Me.dtpFechaDes.Name = "dtpFechaDes"
        Me.dtpFechaDes.Size = New System.Drawing.Size(93, 20)
        Me.dtpFechaDes.TabIndex = 0
        Me.dtpFechaDes.Tag = "2"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(360, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 13)
        Me.Label12.TabIndex = 258
        Me.Label12.Text = "F.Vou.Des "
        '
        'WImpRegistroComprasDol
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1055, 471)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "WImpRegistroComprasDol"
        Me.Text = "Registro Compras Con Dolares"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Function ListaControles() As List(Of CtrlsEdit)
        Dim lis As New List(Of CtrlsEdit)
        Dim item As CtrlsEdit

        item = New CtrlsEdit
        item.Control = Me.TxtCodEmp
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
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
        item.PasarCursor = "0"
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
        item.Control = Me.dtpFechaDes
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
        item.Control = Me.dtpFechaHas
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

    Friend WithEvents TxtCodEmp As System.Windows.Forms.TextBox
    Friend WithEvents txtNomEmp As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnEjecutar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFechaDes As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaHas As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CrRptRegistroComprasDol1 As Presentacion.CrRptRegistroComprasDol
End Class
