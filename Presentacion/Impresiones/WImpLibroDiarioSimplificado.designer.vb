<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WImpLibroDiarioSimplificado
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtDesMes = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtCodMes = New System.Windows.Forms.TextBox
        Me.txtAno = New System.Windows.Forms.TextBox
        Me.btnEjecutar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptLibroDiarioSimplificado1 = New Presentacion.CrRptLibroDiarioSimplificado
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtCodEmp
        '
        Me.TxtCodEmp.Location = New System.Drawing.Point(27, 29)
        Me.TxtCodEmp.Name = "TxtCodEmp"
        Me.TxtCodEmp.ReadOnly = True
        Me.TxtCodEmp.Size = New System.Drawing.Size(55, 20)
        Me.TxtCodEmp.TabIndex = 265
        Me.TxtCodEmp.Tag = "0"
        '
        'txtNomEmp
        '
        Me.txtNomEmp.Location = New System.Drawing.Point(88, 29)
        Me.txtNomEmp.Name = "txtNomEmp"
        Me.txtNomEmp.ReadOnly = True
        Me.txtNomEmp.Size = New System.Drawing.Size(231, 20)
        Me.txtNomEmp.TabIndex = 266
        Me.txtNomEmp.Tag = "1"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(24, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 268
        Me.Label6.Text = "Empresa"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDesMes)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.txtCodMes)
        Me.GroupBox1.Controls.Add(Me.txtAno)
        Me.GroupBox1.Location = New System.Drawing.Point(326, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(350, 53)
        Me.GroupBox1.TabIndex = 267
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Elija Periodo"
        '
        'txtDesMes
        '
        Me.txtDesMes.BackColor = System.Drawing.SystemColors.Control
        Me.txtDesMes.Location = New System.Drawing.Point(194, 20)
        Me.txtDesMes.MaxLength = 10
        Me.txtDesMes.Name = "txtDesMes"
        Me.txtDesMes.ReadOnly = True
        Me.txtDesMes.Size = New System.Drawing.Size(147, 20)
        Me.txtDesMes.TabIndex = 103
        Me.txtDesMes.Tag = "4"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(10, 25)
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
        Me.Label19.Size = New System.Drawing.Size(30, 13)
        Me.Label19.TabIndex = 229
        Me.Label19.Text = "Mes"
        '
        'txtCodMes
        '
        Me.txtCodMes.BackColor = System.Drawing.Color.White
        Me.txtCodMes.Location = New System.Drawing.Point(154, 20)
        Me.txtCodMes.MaxLength = 10
        Me.txtCodMes.Name = "txtCodMes"
        Me.txtCodMes.Size = New System.Drawing.Size(44, 20)
        Me.txtCodMes.TabIndex = 0
        Me.txtCodMes.Tag = "3"
        '
        'txtAno
        '
        Me.txtAno.BackColor = System.Drawing.SystemColors.Control
        Me.txtAno.Location = New System.Drawing.Point(51, 20)
        Me.txtAno.MaxLength = 4
        Me.txtAno.Name = "txtAno"
        Me.txtAno.ReadOnly = True
        Me.txtAno.Size = New System.Drawing.Size(55, 20)
        Me.txtAno.TabIndex = 102
        Me.txtAno.Tag = "2"
        '
        'btnEjecutar
        '
        Me.btnEjecutar.Image = Global.Presentacion.My.Resources.Resources.apply
        Me.btnEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEjecutar.Location = New System.Drawing.Point(682, 29)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(107, 23)
        Me.btnEjecutar.TabIndex = 1
        Me.btnEjecutar.Tag = "5"
        Me.btnEjecutar.Text = "Ejecutar"
        Me.btnEjecutar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Presentacion.My.Resources.Resources.action_stop
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(790, 29)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(104, 23)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Tag = "6"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.crv1)
        Me.Panel1.Location = New System.Drawing.Point(27, 68)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(915, 340)
        Me.Panel1.TabIndex = 269
        '
        'crv1
        '
        Me.crv1.ActiveViewIndex = 0
        Me.crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crv1.DisplayGroupTree = False
        Me.crv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crv1.Location = New System.Drawing.Point(0, 0)
        Me.crv1.Name = "crv1"
        Me.crv1.ReportSource = Me.CrRptLibroDiarioSimplificado1
        Me.crv1.Size = New System.Drawing.Size(915, 340)
        Me.crv1.TabIndex = 10
        '
        'WImpLibroDiarioSimplificado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(954, 446)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TxtCodEmp)
        Me.Controls.Add(Me.txtNomEmp)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnEjecutar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "WImpLibroDiarioSimplificado"
        Me.Text = "WImpLibroDiarioSimplificado"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
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
        item.Control = Me.txtAno
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDesMes As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtCodMes As System.Windows.Forms.TextBox
    Friend WithEvents txtAno As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptLibroDiarioSimplificado1 As Presentacion.CrRptLibroDiarioSimplificado
End Class
