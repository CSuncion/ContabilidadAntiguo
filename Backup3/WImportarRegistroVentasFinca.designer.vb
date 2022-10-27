<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WImportarRegistroVentasFinca
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
        Me.TxtCtaCuoOrd = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtCtaCuoSupPro = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtCodOriVta = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtCodFilVta = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtNumero = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtCtaCuoAgu = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtCtaCuoEle = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtCtaCuoIng = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtCtaCuoExt = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TxtCtaCuoMor = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        CType(Me.dgvExcel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnImportar
        '
        Me.btnImportar.Location = New System.Drawing.Point(890, 622)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(75, 23)
        Me.btnImportar.TabIndex = 3
        Me.btnImportar.Tag = "11"
        Me.btnImportar.Text = "Importar"
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(968, 622)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Tag = "12"
        Me.btnClose.Text = "Salir"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnVisualize
        '
        Me.btnVisualize.Location = New System.Drawing.Point(809, 622)
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
        Me.dgvExcel.Location = New System.Drawing.Point(10, 43)
        Me.dgvExcel.MultiSelect = False
        Me.dgvExcel.Name = "dgvExcel"
        Me.dgvExcel.ReadOnly = True
        Me.dgvExcel.RowTemplate.Height = 24
        Me.dgvExcel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvExcel.Size = New System.Drawing.Size(1084, 509)
        Me.dgvExcel.TabIndex = 21
        '
        'txtLoad
        '
        Me.txtLoad.Location = New System.Drawing.Point(10, 17)
        Me.txtLoad.Name = "txtLoad"
        Me.txtLoad.ReadOnly = True
        Me.txtLoad.Size = New System.Drawing.Size(941, 20)
        Me.txtLoad.TabIndex = 20
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(956, 15)
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
        Me.TxtCodEmp.Location = New System.Drawing.Point(70, 565)
        Me.TxtCodEmp.Name = "TxtCodEmp"
        Me.TxtCodEmp.ReadOnly = True
        Me.TxtCodEmp.Size = New System.Drawing.Size(43, 20)
        Me.TxtCodEmp.TabIndex = 193
        Me.TxtCodEmp.Tag = "1"
        '
        'TxtPeri
        '
        Me.TxtPeri.Location = New System.Drawing.Point(936, 565)
        Me.TxtPeri.Name = "TxtPeri"
        Me.TxtPeri.ReadOnly = True
        Me.TxtPeri.Size = New System.Drawing.Size(90, 20)
        Me.TxtPeri.TabIndex = 190
        Me.TxtPeri.Tag = "5"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label26.Location = New System.Drawing.Point(857, 568)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(50, 13)
        Me.Label26.TabIndex = 192
        Me.Label26.Text = "Periodo"
        '
        'txtNomEmp
        '
        Me.txtNomEmp.Location = New System.Drawing.Point(120, 565)
        Me.txtNomEmp.Name = "txtNomEmp"
        Me.txtNomEmp.ReadOnly = True
        Me.txtNomEmp.Size = New System.Drawing.Size(311, 20)
        Me.txtNomEmp.TabIndex = 189
        Me.txtNomEmp.Tag = "2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(10, 568)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 191
        Me.Label3.Text = "Empresa"
        '
        'TxtCtaPreVta
        '
        Me.TxtCtaPreVta.Location = New System.Drawing.Point(120, 596)
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
        Me.Label1.Location = New System.Drawing.Point(10, 597)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 195
        Me.Label1.Text = "Cta.Precio Vta"
        '
        'TxtCtaCuoOrd
        '
        Me.TxtCtaCuoOrd.Location = New System.Drawing.Point(340, 596)
        Me.TxtCtaCuoOrd.Name = "TxtCtaCuoOrd"
        Me.TxtCtaCuoOrd.ReadOnly = True
        Me.TxtCtaCuoOrd.Size = New System.Drawing.Size(90, 20)
        Me.TxtCtaCuoOrd.TabIndex = 196
        Me.TxtCtaCuoOrd.Tag = "7"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(230, 597)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 13)
        Me.Label2.TabIndex = 197
        Me.Label2.Text = "Cta.Cuo.Ordinaria"
        '
        'TxtCtaCuoSupPro
        '
        Me.TxtCtaCuoSupPro.Location = New System.Drawing.Point(554, 596)
        Me.TxtCtaCuoSupPro.Name = "TxtCtaCuoSupPro"
        Me.TxtCtaCuoSupPro.ReadOnly = True
        Me.TxtCtaCuoSupPro.Size = New System.Drawing.Size(90, 20)
        Me.TxtCtaCuoSupPro.TabIndex = 198
        Me.TxtCtaCuoSupPro.Tag = "8"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(447, 597)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 13)
        Me.Label4.TabIndex = 199
        Me.Label4.Text = "Cta.Cuo.Sup.Pro"
        '
        'TxtCodOriVta
        '
        Me.TxtCodOriVta.Location = New System.Drawing.Point(554, 565)
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
        Me.Label5.Location = New System.Drawing.Point(447, 568)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 201
        Me.Label5.Text = "Origen"
        '
        'TxtCodFilVta
        '
        Me.TxtCodFilVta.Location = New System.Drawing.Point(752, 565)
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
        Me.Label6.Location = New System.Drawing.Point(673, 568)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 13)
        Me.Label6.TabIndex = 203
        Me.Label6.Text = "File"
        '
        'TxtNumero
        '
        Me.TxtNumero.Location = New System.Drawing.Point(752, 624)
        Me.TxtNumero.Name = "TxtNumero"
        Me.TxtNumero.Size = New System.Drawing.Size(49, 20)
        Me.TxtNumero.TabIndex = 1
        Me.TxtNumero.Tag = "9"
        Me.TxtNumero.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(673, 628)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 205
        Me.Label7.Text = "Numero"
        Me.Label7.Visible = False
        '
        'TxtCtaCuoAgu
        '
        Me.TxtCtaCuoAgu.Location = New System.Drawing.Point(752, 596)
        Me.TxtCtaCuoAgu.Name = "TxtCtaCuoAgu"
        Me.TxtCtaCuoAgu.ReadOnly = True
        Me.TxtCtaCuoAgu.Size = New System.Drawing.Size(90, 20)
        Me.TxtCtaCuoAgu.TabIndex = 206
        Me.TxtCtaCuoAgu.Tag = "8"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(669, 597)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 13)
        Me.Label8.TabIndex = 207
        Me.Label8.Text = "Cta.Cuo.Agua"
        '
        'TxtCtaCuoEle
        '
        Me.TxtCtaCuoEle.Location = New System.Drawing.Point(936, 596)
        Me.TxtCtaCuoEle.Name = "TxtCtaCuoEle"
        Me.TxtCtaCuoEle.ReadOnly = True
        Me.TxtCtaCuoEle.Size = New System.Drawing.Size(90, 20)
        Me.TxtCtaCuoEle.TabIndex = 208
        Me.TxtCtaCuoEle.Tag = "8"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(857, 597)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 13)
        Me.Label9.TabIndex = 209
        Me.Label9.Text = "Cta.Cuo.Ele"
        '
        'TxtCtaCuoIng
        '
        Me.TxtCtaCuoIng.Location = New System.Drawing.Point(120, 624)
        Me.TxtCtaCuoIng.Name = "TxtCtaCuoIng"
        Me.TxtCtaCuoIng.ReadOnly = True
        Me.TxtCtaCuoIng.Size = New System.Drawing.Size(90, 20)
        Me.TxtCtaCuoIng.TabIndex = 210
        Me.TxtCtaCuoIng.Tag = "8"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(10, 628)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 13)
        Me.Label10.TabIndex = 211
        Me.Label10.Text = "Cta.Cuo.Ing"
        '
        'TxtCtaCuoExt
        '
        Me.TxtCtaCuoExt.Location = New System.Drawing.Point(340, 624)
        Me.TxtCtaCuoExt.Name = "TxtCtaCuoExt"
        Me.TxtCtaCuoExt.ReadOnly = True
        Me.TxtCtaCuoExt.Size = New System.Drawing.Size(90, 20)
        Me.TxtCtaCuoExt.TabIndex = 212
        Me.TxtCtaCuoExt.Tag = "8"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(234, 628)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(74, 13)
        Me.Label11.TabIndex = 213
        Me.Label11.Text = "Cta.Cuo.Ext"
        '
        'TxtCtaCuoMor
        '
        Me.TxtCtaCuoMor.Location = New System.Drawing.Point(554, 624)
        Me.TxtCtaCuoMor.Name = "TxtCtaCuoMor"
        Me.TxtCtaCuoMor.ReadOnly = True
        Me.TxtCtaCuoMor.Size = New System.Drawing.Size(90, 20)
        Me.TxtCtaCuoMor.TabIndex = 214
        Me.TxtCtaCuoMor.Tag = "8"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(447, 628)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 13)
        Me.Label12.TabIndex = 215
        Me.Label12.Text = "Cta.Cuo.Mor"
        '
        'WImportarRegistroVentasFinca
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1073, 670)
        Me.Controls.Add(Me.TxtCtaCuoMor)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TxtCtaCuoExt)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TxtCtaCuoIng)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TxtCtaCuoEle)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TxtCtaCuoAgu)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TxtNumero)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtCodFilVta)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtCodOriVta)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtCtaCuoSupPro)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtCtaCuoOrd)
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
        Me.Name = "WImportarRegistroVentasFinca"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
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
    Friend WithEvents TxtCtaCuoOrd As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtCtaCuoSupPro As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtCodOriVta As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtCodFilVta As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtCtaCuoAgu As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtCtaCuoEle As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtCtaCuoIng As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtCtaCuoExt As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtCtaCuoMor As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
End Class
