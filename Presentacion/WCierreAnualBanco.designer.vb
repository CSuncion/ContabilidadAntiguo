<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WCierreAnualBanco
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
        Me.TxtNomEmp = New System.Windows.Forms.TextBox
        Me.TxtCodEmp = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtAno = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtDesMes = New System.Windows.Forms.TextBox
        Me.txtCodMes = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'TxtNomEmp
        '
        Me.TxtNomEmp.BackColor = System.Drawing.SystemColors.Control
        Me.TxtNomEmp.Location = New System.Drawing.Point(127, 17)
        Me.TxtNomEmp.MaxLength = 11
        Me.TxtNomEmp.Name = "TxtNomEmp"
        Me.TxtNomEmp.ReadOnly = True
        Me.TxtNomEmp.Size = New System.Drawing.Size(258, 20)
        Me.TxtNomEmp.TabIndex = 84
        Me.TxtNomEmp.Tag = "1"
        '
        'TxtCodEmp
        '
        Me.TxtCodEmp.BackColor = System.Drawing.SystemColors.Control
        Me.TxtCodEmp.Location = New System.Drawing.Point(89, 17)
        Me.TxtCodEmp.MaxLength = 11
        Me.TxtCodEmp.Name = "TxtCodEmp"
        Me.TxtCodEmp.ReadOnly = True
        Me.TxtCodEmp.Size = New System.Drawing.Size(37, 20)
        Me.TxtCodEmp.TabIndex = 82
        Me.TxtCodEmp.Tag = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(27, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 83
        Me.Label2.Text = "Empresa"
        '
        'txtAno
        '
        Me.txtAno.BackColor = System.Drawing.SystemColors.Control
        Me.txtAno.Location = New System.Drawing.Point(89, 42)
        Me.txtAno.MaxLength = 11
        Me.txtAno.Name = "txtAno"
        Me.txtAno.ReadOnly = True
        Me.txtAno.Size = New System.Drawing.Size(55, 20)
        Me.txtAno.TabIndex = 78
        Me.txtAno.Tag = "2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(27, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 81
        Me.Label1.Text = "Año"
        '
        'btnCancelar
        '
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnCancelar.Location = New System.Drawing.Point(283, 73)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(102, 23)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Tag = "6"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btnAceptar.Location = New System.Drawing.Point(178, 73)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(99, 23)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Tag = "5"
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(164, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 86
        Me.Label3.Text = "Mes"
        '
        'txtDesMes
        '
        Me.txtDesMes.BackColor = System.Drawing.SystemColors.Control
        Me.txtDesMes.Location = New System.Drawing.Point(245, 42)
        Me.txtDesMes.MaxLength = 10
        Me.txtDesMes.Name = "txtDesMes"
        Me.txtDesMes.ReadOnly = True
        Me.txtDesMes.Size = New System.Drawing.Size(140, 20)
        Me.txtDesMes.TabIndex = 231
        Me.txtDesMes.Tag = "4"
        '
        'txtCodMes
        '
        Me.txtCodMes.BackColor = System.Drawing.SystemColors.Control
        Me.txtCodMes.Location = New System.Drawing.Point(200, 42)
        Me.txtCodMes.MaxLength = 10
        Me.txtCodMes.Name = "txtCodMes"
        Me.txtCodMes.Size = New System.Drawing.Size(44, 20)
        Me.txtCodMes.TabIndex = 0
        Me.txtCodMes.Tag = "3"
        '
        'WCierreAnualBanco
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(409, 112)
        Me.Controls.Add(Me.txtDesMes)
        Me.Controls.Add(Me.txtCodMes)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtNomEmp)
        Me.Controls.Add(Me.TxtCodEmp)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtAno)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.MaximizeBox = False
        Me.Name = "WCierreAnualBanco"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cierre Anual de Cuentas Bancarias"
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
        item.Obligatorio = "0"
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
        item.PasarCursor = "0"
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
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
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
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
        item.Limpiar = "0"
        item.DatoLimpiar = ""
        item.Campo = "Mes"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
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

    Friend WithEvents TxtNomEmp As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodEmp As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAno As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDesMes As System.Windows.Forms.TextBox
    Friend WithEvents txtCodMes As System.Windows.Forms.TextBox
End Class
