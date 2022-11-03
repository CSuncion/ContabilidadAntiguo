<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WEditarEmpresa
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
        Me.TxtNomEmpCor = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtRucEmp = New System.Windows.Forms.TextBox
        Me.TxtDirEmp = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.gbEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbEstado
        '
        Me.gbEstado.Controls.Add(Me.rbcerrada)
        Me.gbEstado.Controls.Add(Me.rbactiva)
        Me.gbEstado.Location = New System.Drawing.Point(116, 122)
        Me.gbEstado.Name = "gbEstado"
        Me.gbEstado.Size = New System.Drawing.Size(192, 27)
        Me.gbEstado.TabIndex = 5
        Me.gbEstado.TabStop = False
        Me.gbEstado.Tag = "5"
        '
        'rbcerrada
        '
        Me.rbcerrada.AutoSize = True
        Me.rbcerrada.Location = New System.Drawing.Point(89, 8)
        Me.rbcerrada.Name = "rbcerrada"
        Me.rbcerrada.Size = New System.Drawing.Size(62, 17)
        Me.rbcerrada.TabIndex = 101
        Me.rbcerrada.Tag = "7"
        Me.rbcerrada.Text = "Cerrada"
        Me.rbcerrada.UseVisualStyleBackColor = True
        '
        'rbactiva
        '
        Me.rbactiva.AutoSize = True
        Me.rbactiva.Checked = True
        Me.rbactiva.Location = New System.Drawing.Point(22, 8)
        Me.rbactiva.Name = "rbactiva"
        Me.rbactiva.Size = New System.Drawing.Size(55, 17)
        Me.rbactiva.TabIndex = 100
        Me.rbactiva.TabStop = True
        Me.rbactiva.Tag = "6"
        Me.rbactiva.Text = "Activa"
        Me.rbactiva.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(19, 129)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 79
        Me.Label9.Text = "Estado"
        '
        'txtNomEmp
        '
        Me.txtNomEmp.BackColor = System.Drawing.Color.White
        Me.txtNomEmp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNomEmp.Location = New System.Drawing.Point(116, 36)
        Me.txtNomEmp.MaxLength = 150
        Me.txtNomEmp.Name = "txtNomEmp"
        Me.txtNomEmp.Size = New System.Drawing.Size(363, 20)
        Me.txtNomEmp.TabIndex = 1
        Me.txtNomEmp.Tag = "1"
        '
        'txtCodEmp
        '
        Me.txtCodEmp.BackColor = System.Drawing.Color.White
        Me.txtCodEmp.Location = New System.Drawing.Point(116, 14)
        Me.txtCodEmp.MaxLength = 3
        Me.txtCodEmp.Name = "txtCodEmp"
        Me.txtCodEmp.Size = New System.Drawing.Size(100, 20)
        Me.txtCodEmp.TabIndex = 0
        Me.txtCodEmp.Tag = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(19, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "Razon Social"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(19, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 72
        Me.Label1.Text = "Codigo"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Presentacion.My.Resources.Resources.action_stop
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(384, 158)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(95, 23)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Tag = "9"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.Presentacion.My.Resources.Resources.apply
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(287, 158)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(98, 23)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Tag = "8"
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'TxtNomEmpCor
        '
        Me.TxtNomEmpCor.BackColor = System.Drawing.Color.White
        Me.TxtNomEmpCor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNomEmpCor.Location = New System.Drawing.Point(116, 58)
        Me.TxtNomEmpCor.MaxLength = 150
        Me.TxtNomEmpCor.Name = "TxtNomEmpCor"
        Me.TxtNomEmpCor.Size = New System.Drawing.Size(363, 20)
        Me.TxtNomEmpCor.TabIndex = 2
        Me.TxtNomEmpCor.Tag = "2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(19, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 82
        Me.Label3.Text = "Nombre Corto"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(19, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 13)
        Me.Label4.TabIndex = 84
        Me.Label4.Text = "Ruc"
        '
        'TxtRucEmp
        '
        Me.TxtRucEmp.BackColor = System.Drawing.Color.White
        Me.TxtRucEmp.Location = New System.Drawing.Point(116, 102)
        Me.TxtRucEmp.MaxLength = 11
        Me.TxtRucEmp.Name = "TxtRucEmp"
        Me.TxtRucEmp.Size = New System.Drawing.Size(100, 20)
        Me.TxtRucEmp.TabIndex = 4
        Me.TxtRucEmp.Tag = "4"
        '
        'TxtDirEmp
        '
        Me.TxtDirEmp.BackColor = System.Drawing.Color.White
        Me.TxtDirEmp.Location = New System.Drawing.Point(116, 80)
        Me.TxtDirEmp.MaxLength = 150
        Me.TxtDirEmp.Name = "TxtDirEmp"
        Me.TxtDirEmp.Size = New System.Drawing.Size(363, 20)
        Me.TxtDirEmp.TabIndex = 3
        Me.TxtDirEmp.Tag = "3"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(19, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 86
        Me.Label5.Text = "Dirección"
        '
        'WEditarEmpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(498, 190)
        Me.Controls.Add(Me.TxtDirEmp)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtRucEmp)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtNomEmpCor)
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
        Me.Name = "WEditarEmpresa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Empresas"
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
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Empresa"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtNomEmp
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Razon Social"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtNomEmpCor
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Nombre Corto"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtDirEmp
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Direccion"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtRucEmp
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Ruc"
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
    Friend WithEvents TxtNomEmpCor As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtRucEmp As System.Windows.Forms.TextBox
    Friend WithEvents TxtDirEmp As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
