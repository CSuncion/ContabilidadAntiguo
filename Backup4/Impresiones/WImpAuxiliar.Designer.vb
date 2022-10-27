<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WImpAuxiliar
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
        Me.gbAuxiliar = New System.Windows.Forms.GroupBox
        Me.RbtTodos = New System.Windows.Forms.RadioButton
        Me.RbtProveedor = New System.Windows.Forms.RadioButton
        Me.RbtCliente = New System.Windows.Forms.RadioButton
        Me.rbtClieProv = New System.Windows.Forms.RadioButton
        Me.rbtPersonal = New System.Windows.Forms.RadioButton
        Me.btnEjecutar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.crRptAux1 = New Presentacion.crRptAux
        Me.crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.crRptAux2 = New Presentacion.crRptAux
        Me.GbOrden = New System.Windows.Forms.GroupBox
        Me.RbtNombre = New System.Windows.Forms.RadioButton
        Me.RbtCodigo = New System.Windows.Forms.RadioButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.gbAuxiliar.SuspendLayout()
        Me.GbOrden.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbAuxiliar
        '
        Me.gbAuxiliar.Controls.Add(Me.RbtTodos)
        Me.gbAuxiliar.Controls.Add(Me.RbtProveedor)
        Me.gbAuxiliar.Controls.Add(Me.RbtCliente)
        Me.gbAuxiliar.Controls.Add(Me.rbtClieProv)
        Me.gbAuxiliar.Controls.Add(Me.rbtPersonal)
        Me.gbAuxiliar.Location = New System.Drawing.Point(12, 3)
        Me.gbAuxiliar.Name = "gbAuxiliar"
        Me.gbAuxiliar.Size = New System.Drawing.Size(399, 44)
        Me.gbAuxiliar.TabIndex = 0
        Me.gbAuxiliar.TabStop = False
        Me.gbAuxiliar.Tag = "0"
        '
        'RbtTodos
        '
        Me.RbtTodos.AutoSize = True
        Me.RbtTodos.Location = New System.Drawing.Point(331, 15)
        Me.RbtTodos.Name = "RbtTodos"
        Me.RbtTodos.Size = New System.Drawing.Size(55, 17)
        Me.RbtTodos.TabIndex = 103
        Me.RbtTodos.Tag = "5"
        Me.RbtTodos.Text = "Todos"
        Me.RbtTodos.UseVisualStyleBackColor = True
        '
        'RbtProveedor
        '
        Me.RbtProveedor.AutoSize = True
        Me.RbtProveedor.Location = New System.Drawing.Point(251, 15)
        Me.RbtProveedor.Name = "RbtProveedor"
        Me.RbtProveedor.Size = New System.Drawing.Size(74, 17)
        Me.RbtProveedor.TabIndex = 102
        Me.RbtProveedor.Tag = "4"
        Me.RbtProveedor.Text = "Proveedor"
        Me.RbtProveedor.UseVisualStyleBackColor = True
        '
        'RbtCliente
        '
        Me.RbtCliente.AutoSize = True
        Me.RbtCliente.Location = New System.Drawing.Point(189, 15)
        Me.RbtCliente.Name = "RbtCliente"
        Me.RbtCliente.Size = New System.Drawing.Size(57, 17)
        Me.RbtCliente.TabIndex = 101
        Me.RbtCliente.Tag = "3"
        Me.RbtCliente.Text = "Cliente"
        Me.RbtCliente.UseVisualStyleBackColor = True
        '
        'rbtClieProv
        '
        Me.rbtClieProv.AutoSize = True
        Me.rbtClieProv.Location = New System.Drawing.Point(75, 15)
        Me.rbtClieProv.Name = "rbtClieProv"
        Me.rbtClieProv.Size = New System.Drawing.Size(111, 17)
        Me.rbtClieProv.TabIndex = 100
        Me.rbtClieProv.Tag = "2"
        Me.rbtClieProv.Text = "Cliente/Proveedor"
        Me.rbtClieProv.UseVisualStyleBackColor = True
        '
        'rbtPersonal
        '
        Me.rbtPersonal.AutoSize = True
        Me.rbtPersonal.Checked = True
        Me.rbtPersonal.Location = New System.Drawing.Point(6, 15)
        Me.rbtPersonal.Name = "rbtPersonal"
        Me.rbtPersonal.Size = New System.Drawing.Size(66, 17)
        Me.rbtPersonal.TabIndex = 100
        Me.rbtPersonal.TabStop = True
        Me.rbtPersonal.Tag = "1"
        Me.rbtPersonal.Text = "Personal"
        Me.rbtPersonal.UseVisualStyleBackColor = True
        '
        'btnEjecutar
        '
        Me.btnEjecutar.Image = Global.Presentacion.My.Resources.Resources.apply
        Me.btnEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEjecutar.Location = New System.Drawing.Point(578, 15)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(85, 23)
        Me.btnEjecutar.TabIndex = 2
        Me.btnEjecutar.Tag = "9"
        Me.btnEjecutar.Text = "Ejecutar"
        Me.btnEjecutar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Presentacion.My.Resources.Resources.action_stop
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(664, 15)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(85, 23)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Tag = "10"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'crv1
        '
        Me.crv1.ActiveViewIndex = 0
        Me.crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crv1.DisplayGroupTree = False
        Me.crv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crv1.Location = New System.Drawing.Point(0, 0)
        Me.crv1.Name = "crv1"
        Me.crv1.ReportSource = Me.crRptAux2
        Me.crv1.Size = New System.Drawing.Size(913, 390)
        Me.crv1.TabIndex = 10
        '
        'GbOrden
        '
        Me.GbOrden.Controls.Add(Me.RbtNombre)
        Me.GbOrden.Controls.Add(Me.RbtCodigo)
        Me.GbOrden.Location = New System.Drawing.Point(414, 3)
        Me.GbOrden.Name = "GbOrden"
        Me.GbOrden.Size = New System.Drawing.Size(158, 44)
        Me.GbOrden.TabIndex = 1
        Me.GbOrden.TabStop = False
        Me.GbOrden.Tag = "6"
        '
        'RbtNombre
        '
        Me.RbtNombre.AutoSize = True
        Me.RbtNombre.Location = New System.Drawing.Point(75, 15)
        Me.RbtNombre.Name = "RbtNombre"
        Me.RbtNombre.Size = New System.Drawing.Size(62, 17)
        Me.RbtNombre.TabIndex = 100
        Me.RbtNombre.Tag = "8"
        Me.RbtNombre.Text = "Nombre"
        Me.RbtNombre.UseVisualStyleBackColor = True
        '
        'RbtCodigo
        '
        Me.RbtCodigo.AutoSize = True
        Me.RbtCodigo.Checked = True
        Me.RbtCodigo.Location = New System.Drawing.Point(6, 15)
        Me.RbtCodigo.Name = "RbtCodigo"
        Me.RbtCodigo.Size = New System.Drawing.Size(58, 17)
        Me.RbtCodigo.TabIndex = 100
        Me.RbtCodigo.TabStop = True
        Me.RbtCodigo.Tag = "7"
        Me.RbtCodigo.Text = "Codigo"
        Me.RbtCodigo.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.crv1)
        Me.Panel1.Location = New System.Drawing.Point(1, 61)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(913, 390)
        Me.Panel1.TabIndex = 307
        '
        'WImpAuxiliar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(915, 452)
        Me.Controls.Add(Me.GbOrden)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.gbAuxiliar)
        Me.Controls.Add(Me.btnEjecutar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Name = "WImpAuxiliar"
        Me.Text = "Imprimir Auxiliares"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.gbAuxiliar.ResumeLayout(False)
        Me.gbAuxiliar.PerformLayout()
        Me.GbOrden.ResumeLayout(False)
        Me.GbOrden.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Function ListaControles() As List(Of CtrlsEdit)
        Dim lis As New List(Of CtrlsEdit)
        Dim item As New CtrlsEdit

       
        item = New CtrlsEdit
        item.Control = Me.gbAuxiliar
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
        item.Control = Me.rbtPersonal
        item.PasaFoco = "1"
        item.Formato = ""
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
        item.Control = Me.rbtClieProv
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
        item.Control = Me.RbtCliente
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
        item.Control = Me.RbtProveedor
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
        item.Control = Me.RbtTodos
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
        item.Control = Me.GbOrden
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
        item.Control = Me.RbtCodigo
        item.PasaFoco = "1"
        item.Formato = ""
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
        item.Control = Me.RbtNombre
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

    Friend WithEvents gbAuxiliar As System.Windows.Forms.GroupBox
    Friend WithEvents rbtClieProv As System.Windows.Forms.RadioButton
    Friend WithEvents rbtPersonal As System.Windows.Forms.RadioButton
    Friend WithEvents btnEjecutar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents crRptAux1 As Presentacion.crRptAux
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents crRptAux2 As Presentacion.crRptAux
    Friend WithEvents RbtCliente As System.Windows.Forms.RadioButton
    Friend WithEvents RbtTodos As System.Windows.Forms.RadioButton
    Friend WithEvents RbtProveedor As System.Windows.Forms.RadioButton
    Friend WithEvents GbOrden As System.Windows.Forms.GroupBox
    Friend WithEvents RbtNombre As System.Windows.Forms.RadioButton
    Friend WithEvents RbtCodigo As System.Windows.Forms.RadioButton
End Class
