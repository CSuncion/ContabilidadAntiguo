<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WEditarGastoReparable
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
        Me.gbEstado = New System.Windows.Forms.GroupBox
        Me.rbcerrada = New System.Windows.Forms.RadioButton
        Me.rbactiva = New System.Windows.Forms.RadioButton
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtNomEmp = New System.Windows.Forms.TextBox
        Me.txtCodEmp = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.TxtNomGasRep = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtCodGasRep = New System.Windows.Forms.TextBox
        Me.TxtCodAlm = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtCodUni = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.gbEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbEstado
        '
        Me.gbEstado.Controls.Add(Me.rbcerrada)
        Me.gbEstado.Controls.Add(Me.rbactiva)
        Me.gbEstado.Location = New System.Drawing.Point(95, 143)
        Me.gbEstado.Name = "gbEstado"
        Me.gbEstado.Size = New System.Drawing.Size(143, 35)
        Me.gbEstado.TabIndex = 4
        Me.gbEstado.TabStop = False
        Me.gbEstado.Tag = "6"
        '
        'rbcerrada
        '
        Me.rbcerrada.AutoSize = True
        Me.rbcerrada.Location = New System.Drawing.Point(71, 13)
        Me.rbcerrada.Name = "rbcerrada"
        Me.rbcerrada.Size = New System.Drawing.Size(62, 17)
        Me.rbcerrada.TabIndex = 101
        Me.rbcerrada.Tag = "8"
        Me.rbcerrada.Text = "Cerrada"
        Me.rbcerrada.UseVisualStyleBackColor = True
        '
        'rbactiva
        '
        Me.rbactiva.AutoSize = True
        Me.rbactiva.Checked = True
        Me.rbactiva.Location = New System.Drawing.Point(10, 13)
        Me.rbactiva.Name = "rbactiva"
        Me.rbactiva.Size = New System.Drawing.Size(55, 17)
        Me.rbactiva.TabIndex = 100
        Me.rbactiva.TabStop = True
        Me.rbactiva.Tag = "7"
        Me.rbactiva.Text = "Activa"
        Me.rbactiva.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(20, 154)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 79
        Me.Label9.Text = "Estado"
        '
        'txtNomEmp
        '
        Me.txtNomEmp.BackColor = System.Drawing.SystemColors.Control
        Me.txtNomEmp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNomEmp.Location = New System.Drawing.Point(161, 14)
        Me.txtNomEmp.MaxLength = 150
        Me.txtNomEmp.Name = "txtNomEmp"
        Me.txtNomEmp.ReadOnly = True
        Me.txtNomEmp.Size = New System.Drawing.Size(257, 20)
        Me.txtNomEmp.TabIndex = 256
        Me.txtNomEmp.Tag = "1"
        '
        'txtCodEmp
        '
        Me.txtCodEmp.BackColor = System.Drawing.SystemColors.Control
        Me.txtCodEmp.Location = New System.Drawing.Point(95, 14)
        Me.txtCodEmp.MaxLength = 3
        Me.txtCodEmp.Name = "txtCodEmp"
        Me.txtCodEmp.ReadOnly = True
        Me.txtCodEmp.Size = New System.Drawing.Size(65, 20)
        Me.txtCodEmp.TabIndex = 255
        Me.txtCodEmp.Tag = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(20, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "Codigo "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(20, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 72
        Me.Label1.Text = "Empresa"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Presentacion.My.Resources.Resources.action_stop
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(323, 185)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(95, 23)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Tag = "10"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.Presentacion.My.Resources.Resources.apply
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(226, 185)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(98, 23)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Tag = "9"
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'TxtNomGasRep
        '
        Me.TxtNomGasRep.BackColor = System.Drawing.Color.White
        Me.TxtNomGasRep.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNomGasRep.Location = New System.Drawing.Point(95, 64)
        Me.TxtNomGasRep.MaxLength = 150
        Me.TxtNomGasRep.Name = "TxtNomGasRep"
        Me.TxtNomGasRep.Size = New System.Drawing.Size(323, 20)
        Me.TxtNomGasRep.TabIndex = 1
        Me.TxtNomGasRep.Tag = "3"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(20, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 82
        Me.Label3.Text = "Nombre "
        '
        'TxtCodGasRep
        '
        Me.TxtCodGasRep.BackColor = System.Drawing.Color.White
        Me.TxtCodGasRep.Location = New System.Drawing.Point(95, 39)
        Me.TxtCodGasRep.MaxLength = 8
        Me.TxtCodGasRep.Name = "TxtCodGasRep"
        Me.TxtCodGasRep.Size = New System.Drawing.Size(65, 20)
        Me.TxtCodGasRep.TabIndex = 0
        Me.TxtCodGasRep.Tag = "2"
        '
        'TxtCodAlm
        '
        Me.TxtCodAlm.BackColor = System.Drawing.Color.White
        Me.TxtCodAlm.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCodAlm.Location = New System.Drawing.Point(95, 97)
        Me.TxtCodAlm.MaxLength = 150
        Me.TxtCodAlm.Name = "TxtCodAlm"
        Me.TxtCodAlm.Size = New System.Drawing.Size(65, 20)
        Me.TxtCodAlm.TabIndex = 2
        Me.TxtCodAlm.Tag = "4"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(20, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 258
        Me.Label4.Text = "Almacen"
        '
        'TxtCodUni
        '
        Me.TxtCodUni.BackColor = System.Drawing.Color.White
        Me.TxtCodUni.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCodUni.Location = New System.Drawing.Point(95, 125)
        Me.TxtCodUni.MaxLength = 150
        Me.TxtCodUni.Name = "TxtCodUni"
        Me.TxtCodUni.Size = New System.Drawing.Size(65, 20)
        Me.TxtCodUni.TabIndex = 3
        Me.TxtCodUni.Tag = "5"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(20, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 260
        Me.Label5.Text = "Unidad"
        '
        'WEditarGastoReparable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(437, 215)
        Me.Controls.Add(Me.TxtCodUni)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtCodAlm)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtCodGasRep)
        Me.Controls.Add(Me.TxtNomGasRep)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.gbEstado)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtNomEmp)
        Me.Controls.Add(Me.txtCodEmp)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "WEditarGastoReparable"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Flujo caja"
        Me.gbEstado.ResumeLayout(False)
        Me.gbEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Function ListaControles() As List(Of CtrlsEdit)
        Dim lis As New List(Of CtrlsEdit)
        Dim item As CtrlsEdit

        item = New CtrlsEdit
        item.Control = Me.txtCodEmp
        item.PasaFoco = "0"
        item.Formato = "1"
        item.PasarCursor = "0"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Empresa"
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
        item.Formato = "1"
        item.PasarCursor = "0"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Razon Social"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtCodGasRep
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Gasto Reparable"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)


        item = New CtrlsEdit
        item.Control = Me.TxtNomGasRep
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Nombre Gasto Reparable"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtCodAlm
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Codigo Almacen"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtCodUni
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Unidad"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
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
    Friend WithEvents gbEstado As System.Windows.Forms.GroupBox
    Friend WithEvents rbcerrada As System.Windows.Forms.RadioButton
    Friend WithEvents rbactiva As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents txtNomEmp As System.Windows.Forms.TextBox
    Friend WithEvents txtCodEmp As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtNomGasRep As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtCodGasRep As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodAlm As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtCodUni As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
