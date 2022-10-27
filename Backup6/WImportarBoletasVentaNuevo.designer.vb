<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WImportarBoletasVentaNuevo
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
        Me.btnImportar = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnVisualize = New System.Windows.Forms.Button
        Me.dgvExcel = New System.Windows.Forms.DataGridView
        Me.txtLoad = New System.Windows.Forms.TextBox
        Me.btnLoad = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.TxtCodEmp = New System.Windows.Forms.TextBox
        Me.TxtPeri = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.txtNomEmp = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtCtaPreVta = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtCtaValVta = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtCtaValIgv = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtCodOriVta = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtCodFilVta = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtNumero = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        CType(Me.dgvExcel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnImportar
        '
        Me.btnImportar.Location = New System.Drawing.Point(748, 468)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(75, 23)
        Me.btnImportar.TabIndex = 3
        Me.btnImportar.Tag = "11"
        Me.btnImportar.Text = "Importar"
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(826, 468)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Tag = "12"
        Me.btnClose.Text = "Salir"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnVisualize
        '
        Me.btnVisualize.Location = New System.Drawing.Point(667, 468)
        Me.btnVisualize.Name = "btnVisualize"
        Me.btnVisualize.Size = New System.Drawing.Size(75, 23)
        Me.btnVisualize.TabIndex = 2
        Me.btnVisualize.Tag = "10"
        Me.btnVisualize.Text = "Visualizar"
        Me.btnVisualize.UseVisualStyleBackColor = True
        '
        'dgvExcel
        '
        Me.dgvExcel.AllowUserToDeleteRows = False
        Me.dgvExcel.BackgroundColor = System.Drawing.Color.White
        Me.dgvExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvExcel.Location = New System.Drawing.Point(93, 43)
        Me.dgvExcel.MultiSelect = False
        Me.dgvExcel.Name = "dgvExcel"
        Me.dgvExcel.ReadOnly = True
        Me.dgvExcel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvExcel.Size = New System.Drawing.Size(808, 367)
        Me.dgvExcel.TabIndex = 21
        '
        'txtLoad
        '
        Me.txtLoad.Location = New System.Drawing.Point(93, 17)
        Me.txtLoad.Name = "txtLoad"
        Me.txtLoad.ReadOnly = True
        Me.txtLoad.Size = New System.Drawing.Size(663, 20)
        Me.txtLoad.TabIndex = 20
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(762, 16)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(139, 23)
        Me.btnLoad.TabIndex = 0
        Me.btnLoad.Tag = "0"
        Me.btnLoad.Text = "Cargar Archivo"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TxtCodEmp
        '
        Me.TxtCodEmp.Location = New System.Drawing.Point(151, 416)
        Me.TxtCodEmp.Name = "TxtCodEmp"
        Me.TxtCodEmp.ReadOnly = True
        Me.TxtCodEmp.Size = New System.Drawing.Size(43, 20)
        Me.TxtCodEmp.TabIndex = 193
        Me.TxtCodEmp.Tag = "1"
        '
        'TxtPeri
        '
        Me.TxtPeri.Location = New System.Drawing.Point(151, 442)
        Me.TxtPeri.Name = "TxtPeri"
        Me.TxtPeri.ReadOnly = True
        Me.TxtPeri.Size = New System.Drawing.Size(133, 20)
        Me.TxtPeri.TabIndex = 190
        Me.TxtPeri.Tag = "5"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label26.Location = New System.Drawing.Point(90, 445)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(50, 13)
        Me.Label26.TabIndex = 192
        Me.Label26.Text = "Periodo"
        '
        'txtNomEmp
        '
        Me.txtNomEmp.Location = New System.Drawing.Point(200, 416)
        Me.txtNomEmp.Name = "txtNomEmp"
        Me.txtNomEmp.ReadOnly = True
        Me.txtNomEmp.Size = New System.Drawing.Size(337, 20)
        Me.txtNomEmp.TabIndex = 189
        Me.txtNomEmp.Tag = "2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(90, 419)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 191
        Me.Label3.Text = "Empresa"
        '
        'TxtCtaPreVta
        '
        Me.TxtCtaPreVta.Location = New System.Drawing.Point(395, 442)
        Me.TxtCtaPreVta.Name = "TxtCtaPreVta"
        Me.TxtCtaPreVta.ReadOnly = True
        Me.TxtCtaPreVta.Size = New System.Drawing.Size(90, 20)
        Me.TxtCtaPreVta.TabIndex = 194
        Me.TxtCtaPreVta.Tag = "6"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(303, 445)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 195
        Me.Label1.Text = "Cta.Precio Vta"
        '
        'TxtCtaValVta
        '
        Me.TxtCtaValVta.Location = New System.Drawing.Point(634, 442)
        Me.TxtCtaValVta.Name = "TxtCtaValVta"
        Me.TxtCtaValVta.ReadOnly = True
        Me.TxtCtaValVta.Size = New System.Drawing.Size(90, 20)
        Me.TxtCtaValVta.TabIndex = 196
        Me.TxtCtaValVta.Tag = "7"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(546, 445)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 197
        Me.Label2.Text = "Cta.Valor Vta"
        '
        'TxtCtaValIgv
        '
        Me.TxtCtaValIgv.Location = New System.Drawing.Point(811, 442)
        Me.TxtCtaValIgv.Name = "TxtCtaValIgv"
        Me.TxtCtaValIgv.ReadOnly = True
        Me.TxtCtaValIgv.Size = New System.Drawing.Size(90, 20)
        Me.TxtCtaValIgv.TabIndex = 198
        Me.TxtCtaValIgv.Tag = "8"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(740, 445)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 199
        Me.Label4.Text = "Cta.Igv"
        '
        'TxtCodOriVta
        '
        Me.TxtCodOriVta.Location = New System.Drawing.Point(634, 416)
        Me.TxtCodOriVta.Name = "TxtCodOriVta"
        Me.TxtCodOriVta.ReadOnly = True
        Me.TxtCodOriVta.Size = New System.Drawing.Size(90, 20)
        Me.TxtCodOriVta.TabIndex = 200
        Me.TxtCodOriVta.Tag = "3"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(546, 419)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 201
        Me.Label5.Text = "Origen"
        '
        'TxtCodFilVta
        '
        Me.TxtCodFilVta.Location = New System.Drawing.Point(811, 419)
        Me.TxtCodFilVta.Name = "TxtCodFilVta"
        Me.TxtCodFilVta.ReadOnly = True
        Me.TxtCodFilVta.Size = New System.Drawing.Size(90, 20)
        Me.TxtCodFilVta.TabIndex = 202
        Me.TxtCodFilVta.Tag = "4"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(740, 422)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 13)
        Me.Label6.TabIndex = 203
        Me.Label6.Text = "File"
        '
        'TxtNumero
        '
        Me.TxtNumero.Location = New System.Drawing.Point(151, 470)
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.Size = New System.Drawing.Size(90, 20)
        Me.TxtNumero.TabIndex = 1
        Me.TxtNumero.Tag = "9"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(90, 473)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 205
        Me.Label7.Text = "Numero"
        '
        'WImportarGastoOperativo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(994, 502)
        Me.Controls.Add(Me.TxtNumero)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtCodFilVta)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtCodOriVta)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtCtaValIgv)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtCtaValVta)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtCtaPreVta)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtCodEmp)
        Me.Controls.Add(Me.TxtPeri)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.txtNomEmp)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnImportar)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnVisualize)
        Me.Controls.Add(Me.dgvExcel)
        Me.Controls.Add(Me.txtLoad)
        Me.Controls.Add(Me.btnLoad)
        Me.Name = "WImportarGastoOperativo"
        Me.Text = "Importar Ventas"
        CType(Me.dgvExcel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Function ListaControles() As List(Of CtrlsEdit)
        Dim lis As New List(Of CtrlsEdit)
        Dim item As CtrlsEdit

        item = New CtrlsEdit
        item.Control = Me.TxtNumero
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Numero Voucher"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.NumCaracter = 6
        item.Valida = Validar.texto.vCompletarCerosCadena
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)
        Return lis

        item = New CtrlsEdit
        item.Control = Me.btnLoad
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

        item = New CtrlsEdit
        item.Control = Me.btnVisualize
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

        item = New CtrlsEdit
        item.Control = Me.btnImportar
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

        item = New CtrlsEdit
        item.Control = Me.btnClose
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




    End Function



    Friend WithEvents btnImportar As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnVisualize As System.Windows.Forms.Button
    Friend WithEvents dgvExcel As System.Windows.Forms.DataGridView
    Friend WithEvents txtLoad As System.Windows.Forms.TextBox
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TxtCodEmp As System.Windows.Forms.TextBox
    Friend WithEvents TxtPeri As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtNomEmp As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtCtaPreVta As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtCtaValVta As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtCtaValIgv As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtCodOriVta As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtCodFilVta As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
