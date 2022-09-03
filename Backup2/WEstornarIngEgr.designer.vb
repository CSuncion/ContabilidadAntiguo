<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WEstornarIngEgr
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
        Me.DgvCabe = New System.Windows.Forms.DataGridView
        Me.DgvDeta = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtNomAux = New System.Windows.Forms.TextBox
        Me.txtCodAux = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnEstornar = New System.Windows.Forms.Button
        Me.btnSalir = New System.Windows.Forms.Button
        CType(Me.DgvCabe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvDeta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'DgvCabe
        '
        Me.DgvCabe.BackgroundColor = System.Drawing.Color.White
        Me.DgvCabe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvCabe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvCabe.Location = New System.Drawing.Point(10, 19)
        Me.DgvCabe.Name = "DgvCabe"
        Me.DgvCabe.Size = New System.Drawing.Size(797, 232)
        Me.DgvCabe.TabIndex = 95
        '
        'DgvDeta
        '
        Me.DgvDeta.BackgroundColor = System.Drawing.Color.White
        Me.DgvDeta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvDeta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvDeta.Location = New System.Drawing.Point(10, 18)
        Me.DgvDeta.Name = "DgvDeta"
        Me.DgvDeta.Size = New System.Drawing.Size(797, 151)
        Me.DgvDeta.TabIndex = 96
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DgvCabe)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(814, 257)
        Me.GroupBox1.TabIndex = 97
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ingreso y Egresos"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DgvDeta)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 325)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(814, 175)
        Me.GroupBox2.TabIndex = 98
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detalle"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtNomAux)
        Me.GroupBox3.Controls.Add(Me.txtCodAux)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(814, 50)
        Me.GroupBox3.TabIndex = 99
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Buscar Auxiliar"
        '
        'txtNomAux
        '
        Me.txtNomAux.BackColor = System.Drawing.SystemColors.Control
        Me.txtNomAux.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNomAux.Location = New System.Drawing.Point(226, 18)
        Me.txtNomAux.MaxLength = 200
        Me.txtNomAux.Name = "txtNomAux"
        Me.txtNomAux.ReadOnly = True
        Me.txtNomAux.Size = New System.Drawing.Size(581, 20)
        Me.txtNomAux.TabIndex = 403
        Me.txtNomAux.TabStop = False
        Me.txtNomAux.Tag = "1"
        '
        'txtCodAux
        '
        Me.txtCodAux.Location = New System.Drawing.Point(134, 18)
        Me.txtCodAux.Name = "txtCodAux"
        Me.txtCodAux.Size = New System.Drawing.Size(90, 20)
        Me.txtCodAux.TabIndex = 0
        Me.txtCodAux.Tag = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(13, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 13)
        Me.Label3.TabIndex = 402
        Me.Label3.Text = "Cliente/Proveedor"
        '
        'btnEstornar
        '
        Me.btnEstornar.Location = New System.Drawing.Point(22, 506)
        Me.btnEstornar.Name = "btnEstornar"
        Me.btnEstornar.Size = New System.Drawing.Size(114, 23)
        Me.btnEstornar.TabIndex = 1
        Me.btnEstornar.Tag = "2"
        Me.btnEstornar.Text = "Extornar"
        Me.btnEstornar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Location = New System.Drawing.Point(151, 506)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(114, 23)
        Me.btnSalir.TabIndex = 3
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'WEstornarIngEgr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(838, 553)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnEstornar)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.Name = "WEstornarIngEgr"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estornar Ingresos y egresos"
        CType(Me.DgvCabe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvDeta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

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

            'item = New CtrlsEdit
            'item.Control = Me.txtPeri
            'item.PasaFoco = "0"
            'item.Formato = "0"
            'item.PasarCursor = "1"
            'item.Limpiar = "0"
            'item.DatoLimpiar = ""
            'item.Campo = "Periodo"
            'item.Obligatorio = "1"
            'item.Teclazo = Validar.Tecla.kNada
            'item.Valida = Validar.texto.vNada
            'item.Nuevo = "0"
            'item.Modificar = "0"
            'item.Eliminar = "0"
            'item.Visualizar = "0"
            'lis.Add(item)

            item = New CtrlsEdit
            item.Control = Me.txtCodAux
            item.PasaFoco = "1"
            item.Formato = "0"
            item.PasarCursor = "1"
            item.Limpiar = "1"
            item.DatoLimpiar = ""
            item.Campo = "R.u.c."
            item.Obligatorio = "1"
            item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio  'Cuando teclea
            item.Valida = Validar.texto.vSoloNumerosSinEspacio  'Cuando sale del control   
            item.Nuevo = "1"
            item.Modificar = "0"
            item.Eliminar = "0"
            item.Visualizar = "0"
            lis.Add(item)

            item = New CtrlsEdit
            item.Control = Me.txtNomAux
            item.PasaFoco = "0"
            item.Formato = "1"
            item.PasarCursor = "0"
            item.Limpiar = "1"
            item.DatoLimpiar = ""
            item.Campo = "Auxiliar"
            item.Obligatorio = "0"
            item.Teclazo = Validar.Tecla.kNada
            item.Valida = Validar.texto.vNada
            item.Nuevo = "0"
            item.Modificar = "0"
            item.Eliminar = "0"
            item.Visualizar = "0"
            lis.Add(item)

            item = New CtrlsEdit
            item.Control = Me.btnEstornar
            item.PasaFoco = "1"
            item.Formato = "0"
            item.PasarCursor = "1"
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

            Return lis

      End Function
      Friend WithEvents DgvCabe As System.Windows.Forms.DataGridView
      Friend WithEvents DgvDeta As System.Windows.Forms.DataGridView
      Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
      Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
      Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
      Friend WithEvents btnEstornar As System.Windows.Forms.Button
      Friend WithEvents btnSalir As System.Windows.Forms.Button
      Friend WithEvents txtNomAux As System.Windows.Forms.TextBox
      Friend WithEvents txtCodAux As System.Windows.Forms.TextBox
      Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
