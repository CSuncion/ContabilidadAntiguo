<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WImpPlanCuentas
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
        Me.TxtNomCta2 = New System.Windows.Forms.TextBox
        Me.TxtCodCta2 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.gbTodPar = New System.Windows.Forms.GroupBox
        Me.rbtParcial = New System.Windows.Forms.RadioButton
        Me.rbtTodos = New System.Windows.Forms.RadioButton
        Me.TxtNomCta1 = New System.Windows.Forms.TextBox
        Me.TxtCodCta1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnEjecutar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptPlanCuentas1 = New Presentacion.CrRptPlanCuentas
        Me.gbTodPar.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtNomCta2
        '
        Me.TxtNomCta2.Location = New System.Drawing.Point(290, 43)
        Me.TxtNomCta2.Name = "TxtNomCta2"
        Me.TxtNomCta2.ReadOnly = True
        Me.TxtNomCta2.Size = New System.Drawing.Size(240, 20)
        Me.TxtNomCta2.TabIndex = 297
        Me.TxtNomCta2.Tag = "6"
        '
        'TxtCodCta2
        '
        Me.TxtCodCta2.BackColor = System.Drawing.Color.White
        Me.TxtCodCta2.Location = New System.Drawing.Point(215, 43)
        Me.TxtCodCta2.Name = "TxtCodCta2"
        Me.TxtCodCta2.Size = New System.Drawing.Size(74, 20)
        Me.TxtCodCta2.TabIndex = 2
        Me.TxtCodCta2.Tag = "5"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(119, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 296
        Me.Label2.Text = "Cuenta Hasta"
        '
        'gbTodPar
        '
        Me.gbTodPar.Controls.Add(Me.rbtParcial)
        Me.gbTodPar.Controls.Add(Me.rbtTodos)
        Me.gbTodPar.Location = New System.Drawing.Point(27, 12)
        Me.gbTodPar.Name = "gbTodPar"
        Me.gbTodPar.Size = New System.Drawing.Size(82, 58)
        Me.gbTodPar.TabIndex = 0
        Me.gbTodPar.TabStop = False
        Me.gbTodPar.Tag = "0"
        Me.gbTodPar.Text = "Cuentas"
        '
        'rbtParcial
        '
        Me.rbtParcial.AutoSize = True
        Me.rbtParcial.Location = New System.Drawing.Point(6, 31)
        Me.rbtParcial.Name = "rbtParcial"
        Me.rbtParcial.Size = New System.Drawing.Size(57, 17)
        Me.rbtParcial.TabIndex = 100
        Me.rbtParcial.Tag = "2"
        Me.rbtParcial.Text = "Parcial"
        Me.rbtParcial.UseVisualStyleBackColor = True
        '
        'rbtTodos
        '
        Me.rbtTodos.AutoSize = True
        Me.rbtTodos.Checked = True
        Me.rbtTodos.Location = New System.Drawing.Point(6, 15)
        Me.rbtTodos.Name = "rbtTodos"
        Me.rbtTodos.Size = New System.Drawing.Size(55, 17)
        Me.rbtTodos.TabIndex = 100
        Me.rbtTodos.TabStop = True
        Me.rbtTodos.Tag = "1"
        Me.rbtTodos.Text = "Todas"
        Me.rbtTodos.UseVisualStyleBackColor = True
        '
        'TxtNomCta1
        '
        Me.TxtNomCta1.Location = New System.Drawing.Point(290, 20)
        Me.TxtNomCta1.Name = "TxtNomCta1"
        Me.TxtNomCta1.ReadOnly = True
        Me.TxtNomCta1.Size = New System.Drawing.Size(240, 20)
        Me.TxtNomCta1.TabIndex = 295
        Me.TxtNomCta1.Tag = "4"
        '
        'TxtCodCta1
        '
        Me.TxtCodCta1.BackColor = System.Drawing.Color.White
        Me.TxtCodCta1.Location = New System.Drawing.Point(215, 20)
        Me.TxtCodCta1.Name = "TxtCodCta1"
        Me.TxtCodCta1.Size = New System.Drawing.Size(74, 20)
        Me.TxtCodCta1.TabIndex = 1
        Me.TxtCodCta1.Tag = "3"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(119, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 294
        Me.Label1.Text = "Cuenta Desde"
        '
        'btnEjecutar
        '
        Me.btnEjecutar.Image = Global.Presentacion.My.Resources.Resources.apply
        Me.btnEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEjecutar.Location = New System.Drawing.Point(556, 18)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(114, 23)
        Me.btnEjecutar.TabIndex = 3
        Me.btnEjecutar.Tag = "7"
        Me.btnEjecutar.Text = "Ejecutar"
        Me.btnEjecutar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Presentacion.My.Resources.Resources.action_stop
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(556, 41)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(114, 23)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Tag = "8"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.crv1)
        Me.Panel1.Location = New System.Drawing.Point(2, 76)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(899, 332)
        Me.Panel1.TabIndex = 298
        '
        'crv1
        '
        Me.crv1.ActiveViewIndex = 0
        Me.crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crv1.DisplayGroupTree = False
        Me.crv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crv1.Location = New System.Drawing.Point(0, 0)
        Me.crv1.Name = "crv1"
        Me.crv1.ReportSource = Me.CrRptPlanCuentas1
        Me.crv1.Size = New System.Drawing.Size(899, 332)
        Me.crv1.TabIndex = 100
        '
        'WImpPlanCuentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(903, 410)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TxtNomCta2)
        Me.Controls.Add(Me.TxtCodCta2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.gbTodPar)
        Me.Controls.Add(Me.TxtNomCta1)
        Me.Controls.Add(Me.TxtCodCta1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnEjecutar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Name = "WImpPlanCuentas"
        Me.Text = "Plan General de Cuentas Empresarial"
        Me.gbTodPar.ResumeLayout(False)
        Me.gbTodPar.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Function ListaControles() As List(Of CtrlsEdit)
        Dim lis As New List(Of CtrlsEdit)
        Dim item As CtrlsEdit

        'item = New CtrlsEdit
        'item.Control = Me.TxtCodEmp
        'item.PasaFoco = "0"
        'item.Formato = "0"
        'item.PasarCursor = "1"
        'item.Limpiar = "0"
        'item.DatoLimpiar = ""
        'item.Campo = "Codigo"
        'item.Obligatorio = "1"
        'item.Teclazo = Validar.Tecla.kNada
        'item.Valida = Validar.texto.vNada
        'item.Nuevo = "0"
        'item.Modificar = "0"
        'item.Eliminar = "0"
        'item.Visualizar = "0"
        'lis.Add(item)

        'item = New CtrlsEdit
        'item.Control = Me.txtNomEmp
        'item.PasaFoco = "0"
        'item.Formato = "0"
        'item.PasarCursor = "1"
        'item.Limpiar = "0"
        'item.DatoLimpiar = ""
        'item.Campo = "Nombre"
        'item.Obligatorio = "1"
        'item.Teclazo = Validar.Tecla.kNada
        'item.Valida = Validar.texto.vNada
        'item.Nuevo = "0"
        'item.Modificar = "0"
        'item.Eliminar = "0"
        'item.Visualizar = "0"
        'lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.gbTodPar
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
        item.Control = Me.rbtTodos
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
        item.Control = Me.rbtParcial
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
        item.Control = Me.TxtCodCta1
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = "Cuenta"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtNomCta1
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
        item.Control = Me.TxtCodCta2
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = "Cuenta"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtNomCta2
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

    Friend WithEvents TxtNomCta2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodCta2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gbTodPar As System.Windows.Forms.GroupBox
    Friend WithEvents rbtParcial As System.Windows.Forms.RadioButton
    Friend WithEvents rbtTodos As System.Windows.Forms.RadioButton
    Friend WithEvents TxtNomCta1 As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodCta1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnEjecutar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptPlanCuentas1 As Presentacion.CrRptPlanCuentas
End Class
