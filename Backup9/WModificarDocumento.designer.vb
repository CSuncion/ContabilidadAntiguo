<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WModificarDocumento
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
        Me.gbMoneda = New System.Windows.Forms.GroupBox
        Me.rbtDol = New System.Windows.Forms.RadioButton
        Me.rbtSol = New System.Windows.Forms.RadioButton
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtNum = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtSer = New System.Windows.Forms.TextBox
        Me.txtNomDoc = New System.Windows.Forms.TextBox
        Me.txtDoc = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtImpDol = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtImpSol = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnAgregar = New System.Windows.Forms.Button
        Me.txtNomAux = New System.Windows.Forms.TextBox
        Me.txtCodAux = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.gbMoneda.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbMoneda
        '
        Me.gbMoneda.Controls.Add(Me.rbtDol)
        Me.gbMoneda.Controls.Add(Me.rbtSol)
        Me.gbMoneda.Location = New System.Drawing.Point(12, 85)
        Me.gbMoneda.Name = "gbMoneda"
        Me.gbMoneda.Size = New System.Drawing.Size(119, 28)
        Me.gbMoneda.TabIndex = 243
        Me.gbMoneda.TabStop = False
        Me.gbMoneda.Tag = "5"
        '
        'rbtDol
        '
        Me.rbtDol.AutoSize = True
        Me.rbtDol.Location = New System.Drawing.Point(54, 10)
        Me.rbtDol.Name = "rbtDol"
        Me.rbtDol.Size = New System.Drawing.Size(46, 17)
        Me.rbtDol.TabIndex = 101
        Me.rbtDol.Tag = "7"
        Me.rbtDol.Text = "US$"
        Me.rbtDol.UseVisualStyleBackColor = True
        '
        'rbtSol
        '
        Me.rbtSol.AutoSize = True
        Me.rbtSol.Checked = True
        Me.rbtSol.Location = New System.Drawing.Point(11, 10)
        Me.rbtSol.Name = "rbtSol"
        Me.rbtSol.Size = New System.Drawing.Size(40, 17)
        Me.rbtSol.TabIndex = 100
        Me.rbtSol.TabStop = True
        Me.rbtSol.Tag = "6"
        Me.rbtSol.Text = "S/."
        Me.rbtSol.UseVisualStyleBackColor = True
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(453, 49)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(171, 20)
        Me.dtpFecha.TabIndex = 242
        Me.dtpFecha.Tag = "4"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(450, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 252
        Me.Label8.Text = "Fecha"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(307, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 251
        Me.Label7.Text = "Numero"
        '
        'txtNum
        '
        Me.txtNum.BackColor = System.Drawing.Color.White
        Me.txtNum.Location = New System.Drawing.Point(308, 49)
        Me.txtNum.Name = "txtNum"
        Me.txtNum.Size = New System.Drawing.Size(139, 20)
        Me.txtNum.TabIndex = 2
        Me.txtNum.Tag = "3"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(256, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 250
        Me.Label5.Text = "Serie"
        '
        'txtSer
        '
        Me.txtSer.BackColor = System.Drawing.Color.White
        Me.txtSer.Location = New System.Drawing.Point(260, 49)
        Me.txtSer.MaxLength = 15
        Me.txtSer.Name = "txtSer"
        Me.txtSer.Size = New System.Drawing.Size(42, 20)
        Me.txtSer.TabIndex = 1
        Me.txtSer.Tag = "2"
        '
        'txtNomDoc
        '
        Me.txtNomDoc.Location = New System.Drawing.Point(73, 49)
        Me.txtNomDoc.Name = "txtNomDoc"
        Me.txtNomDoc.ReadOnly = True
        Me.txtNomDoc.Size = New System.Drawing.Size(180, 20)
        Me.txtNomDoc.TabIndex = 249
        Me.txtNomDoc.Tag = "1"
        '
        'txtDoc
        '
        Me.txtDoc.BackColor = System.Drawing.Color.White
        Me.txtDoc.Location = New System.Drawing.Point(12, 49)
        Me.txtDoc.MaxLength = 15
        Me.txtDoc.Name = "txtDoc"
        Me.txtDoc.Size = New System.Drawing.Size(60, 20)
        Me.txtDoc.TabIndex = 0
        Me.txtDoc.Tag = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(12, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 13)
        Me.Label3.TabIndex = 248
        Me.Label3.Text = "TD"
        '
        'txtImpDol
        '
        Me.txtImpDol.Location = New System.Drawing.Point(148, 93)
        Me.txtImpDol.Name = "txtImpDol"
        Me.txtImpDol.Size = New System.Drawing.Size(105, 20)
        Me.txtImpDol.TabIndex = 244
        Me.txtImpDol.Tag = "8"
        Me.txtImpDol.Text = "0.00"
        Me.txtImpDol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(145, 74)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(77, 13)
        Me.Label18.TabIndex = 247
        Me.Label18.Text = "Importe US$"
        '
        'txtImpSol
        '
        Me.txtImpSol.Location = New System.Drawing.Point(260, 93)
        Me.txtImpSol.Name = "txtImpSol"
        Me.txtImpSol.Size = New System.Drawing.Size(105, 20)
        Me.txtImpSol.TabIndex = 245
        Me.txtImpSol.Tag = "9"
        Me.txtImpSol.Text = "0.00"
        Me.txtImpSol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(260, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 246
        Me.Label2.Text = "Importe S/."
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Presentacion.My.Resources.Resources.action_stop
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(539, 142)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(85, 23)
        Me.btnCancelar.TabIndex = 254
        Me.btnCancelar.Tag = "13"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = Global.Presentacion.My.Resources.Resources.apply
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(453, 142)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(85, 23)
        Me.btnAgregar.TabIndex = 4
        Me.btnAgregar.Tag = "12"
        Me.btnAgregar.Text = "Aceptar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'txtNomAux
        '
        Me.txtNomAux.Location = New System.Drawing.Point(121, 142)
        Me.txtNomAux.Name = "txtNomAux"
        Me.txtNomAux.ReadOnly = True
        Me.txtNomAux.Size = New System.Drawing.Size(326, 20)
        Me.txtNomAux.TabIndex = 256
        Me.txtNomAux.Tag = "11"
        '
        'txtCodAux
        '
        Me.txtCodAux.BackColor = System.Drawing.Color.White
        Me.txtCodAux.Location = New System.Drawing.Point(12, 142)
        Me.txtCodAux.MaxLength = 15
        Me.txtCodAux.Name = "txtCodAux"
        Me.txtCodAux.Size = New System.Drawing.Size(105, 20)
        Me.txtCodAux.TabIndex = 3
        Me.txtCodAux.Tag = "10"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(12, 126)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 257
        Me.Label1.Text = "Ruc"
        '
        'WModificarDocumento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(631, 186)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNomAux)
        Me.Controls.Add(Me.txtCodAux)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.gbMoneda)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtNum)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtSer)
        Me.Controls.Add(Me.txtNomDoc)
        Me.Controls.Add(Me.txtDoc)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtImpDol)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtImpSol)
        Me.Controls.Add(Me.Label2)
        Me.MaximizeBox = False
        Me.Name = "WModificarDocumento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar Documento"
        Me.gbMoneda.ResumeLayout(False)
        Me.gbMoneda.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Function ListaControles() As List(Of CtrlsEdit)
        Dim lis As New List(Of CtrlsEdit)
        Dim item As CtrlsEdit


        item = New CtrlsEdit
        item.Control = Me.txtDoc
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Documento"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtNomDoc
        item.PasaFoco = "0"
        item.Formato = "0"
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
        item.Control = Me.txtSer
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Serie Documento"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kAlfaNumericoSinEspacio
        item.NumCaracter = 4
        item.Valida = Validar.texto.vCompletarCerosCadena
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtNum
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Numero Documento"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.NumCaracter = 15
        item.Valida = Validar.texto.vCompletarCerosCadena
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.dtpFecha
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "Today"
        item.Campo = "Fecha Documento"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)


        item = New CtrlsEdit
        item.Control = Me.gbMoneda
        item.PasaFoco = "1"
        item.Formato = ""
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
        item.Control = Me.rbtSol
        item.PasaFoco = "1"
        item.Formato = ""
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "true"
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
        item.Control = Me.rbtDol
        item.PasaFoco = "1"
        item.Formato = ""
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "0"
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
        item.Control = Me.txtImpDol
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "0.00"
        item.Campo = "Importe Dolares"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kDecimal
        item.Valida = Validar.texto.vSolonumerosConDosDecimales
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtImpSol
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "0.00"
        item.Campo = "Importe Soles"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kDecimal
        item.Valida = Validar.texto.vSolonumerosConDosDecimales
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtCodAux
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Auxiliar"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)


        item = New CtrlsEdit
        item.Control = Me.txtNomAux
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Descripcion"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.btnAgregar
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

    Friend WithEvents gbMoneda As System.Windows.Forms.GroupBox
    Friend WithEvents rbtDol As System.Windows.Forms.RadioButton
    Friend WithEvents rbtSol As System.Windows.Forms.RadioButton
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtNum As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSer As System.Windows.Forms.TextBox
    Friend WithEvents txtNomDoc As System.Windows.Forms.TextBox
    Friend WithEvents txtDoc As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtImpDol As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtImpSol As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents txtNomAux As System.Windows.Forms.TextBox
    Friend WithEvents txtCodAux As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
