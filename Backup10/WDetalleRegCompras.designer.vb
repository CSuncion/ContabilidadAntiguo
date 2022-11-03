<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WDetalleRegCompras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WDetalleRegCompras))
        Me.txtNomCue = New System.Windows.Forms.TextBox
        Me.txtCodCuen = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtNomCto = New System.Windows.Forms.TextBox
        Me.txtCencto = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.gbDebeHaber = New System.Windows.Forms.GroupBox
        Me.rbtHaber = New System.Windows.Forms.RadioButton
        Me.rbtDebe = New System.Windows.Forms.RadioButton
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtImpDol = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtImpSol = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtGlosa = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtTipPro = New System.Windows.Forms.TextBox
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnAgregar = New System.Windows.Forms.Button
        Me.txtNomIe = New System.Windows.Forms.TextBox
        Me.txtCodie = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtNomAre = New System.Windows.Forms.TextBox
        Me.TxtCodAre = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TxtNomGasRep = New System.Windows.Forms.TextBox
        Me.TxtCodGasRep = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtCantidad = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.gbDebeHaber.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtNomCue
        '
        Me.txtNomCue.Location = New System.Drawing.Point(67, 25)
        Me.txtNomCue.Name = "txtNomCue"
        Me.txtNomCue.ReadOnly = True
        Me.txtNomCue.Size = New System.Drawing.Size(193, 20)
        Me.txtNomCue.TabIndex = 300
        Me.txtNomCue.Tag = "1"
        '
        'txtCodCuen
        '
        Me.txtCodCuen.BackColor = System.Drawing.Color.White
        Me.txtCodCuen.Location = New System.Drawing.Point(6, 25)
        Me.txtCodCuen.MaxLength = 10
        Me.txtCodCuen.Name = "txtCodCuen"
        Me.txtCodCuen.Size = New System.Drawing.Size(60, 20)
        Me.txtCodCuen.TabIndex = 0
        Me.txtCodCuen.Tag = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(6, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 141
        Me.Label4.Text = "Cuenta"
        '
        'txtNomCto
        '
        Me.txtNomCto.Location = New System.Drawing.Point(318, 25)
        Me.txtNomCto.Name = "txtNomCto"
        Me.txtNomCto.ReadOnly = True
        Me.txtNomCto.Size = New System.Drawing.Size(262, 20)
        Me.txtNomCto.TabIndex = 145
        Me.txtNomCto.Tag = "3"
        '
        'txtCencto
        '
        Me.txtCencto.BackColor = System.Drawing.Color.White
        Me.txtCencto.Location = New System.Drawing.Point(264, 25)
        Me.txtCencto.MaxLength = 15
        Me.txtCencto.Name = "txtCencto"
        Me.txtCencto.Size = New System.Drawing.Size(50, 20)
        Me.txtCencto.TabIndex = 1
        Me.txtCencto.Tag = "2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(262, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 144
        Me.Label1.Text = "C.Costo"
        '
        'gbDebeHaber
        '
        Me.gbDebeHaber.Controls.Add(Me.rbtHaber)
        Me.gbDebeHaber.Controls.Add(Me.rbtDebe)
        Me.gbDebeHaber.Location = New System.Drawing.Point(597, 17)
        Me.gbDebeHaber.Name = "gbDebeHaber"
        Me.gbDebeHaber.Size = New System.Drawing.Size(108, 28)
        Me.gbDebeHaber.TabIndex = 2
        Me.gbDebeHaber.TabStop = False
        Me.gbDebeHaber.Tag = "4"
        '
        'rbtHaber
        '
        Me.rbtHaber.AutoSize = True
        Me.rbtHaber.Location = New System.Drawing.Point(59, 8)
        Me.rbtHaber.Name = "rbtHaber"
        Me.rbtHaber.Size = New System.Drawing.Size(54, 17)
        Me.rbtHaber.TabIndex = 111
        Me.rbtHaber.Tag = "6"
        Me.rbtHaber.Text = "Haber"
        Me.rbtHaber.UseVisualStyleBackColor = True
        '
        'rbtDebe
        '
        Me.rbtDebe.AutoSize = True
        Me.rbtDebe.Checked = True
        Me.rbtDebe.Location = New System.Drawing.Point(5, 8)
        Me.rbtDebe.Name = "rbtDebe"
        Me.rbtDebe.Size = New System.Drawing.Size(51, 17)
        Me.rbtDebe.TabIndex = 100
        Me.rbtDebe.TabStop = True
        Me.rbtDebe.Tag = "5"
        Me.rbtDebe.Text = "Debe"
        Me.rbtDebe.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(599, 5)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(31, 13)
        Me.Label14.TabIndex = 163
        Me.Label14.Text = "D/H"
        '
        'txtImpDol
        '
        Me.txtImpDol.Location = New System.Drawing.Point(813, 25)
        Me.txtImpDol.Name = "txtImpDol"
        Me.txtImpDol.ReadOnly = True
        Me.txtImpDol.Size = New System.Drawing.Size(80, 20)
        Me.txtImpDol.TabIndex = 180
        Me.txtImpDol.Tag = "8"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(810, 9)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(77, 13)
        Me.Label18.TabIndex = 179
        Me.Label18.Text = "Importe US$"
        '
        'txtImpSol
        '
        Me.txtImpSol.Location = New System.Drawing.Point(724, 25)
        Me.txtImpSol.Name = "txtImpSol"
        Me.txtImpSol.Size = New System.Drawing.Size(80, 20)
        Me.txtImpSol.TabIndex = 3
        Me.txtImpSol.Tag = "7"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(722, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 177
        Me.Label2.Text = "Importe S/."
        '
        'txtGlosa
        '
        Me.txtGlosa.BackColor = System.Drawing.Color.White
        Me.txtGlosa.Location = New System.Drawing.Point(6, 65)
        Me.txtGlosa.MaxLength = 50
        Me.txtGlosa.Name = "txtGlosa"
        Me.txtGlosa.Size = New System.Drawing.Size(450, 20)
        Me.txtGlosa.TabIndex = 4
        Me.txtGlosa.Tag = "9"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(6, 49)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(39, 13)
        Me.Label21.TabIndex = 182
        Me.Label21.Text = "Glosa"
        '
        'txtTipPro
        '
        Me.txtTipPro.Location = New System.Drawing.Point(348, 146)
        Me.txtTipPro.Name = "txtTipPro"
        Me.txtTipPro.ReadOnly = True
        Me.txtTipPro.Size = New System.Drawing.Size(116, 20)
        Me.txtTipPro.TabIndex = 189
        Me.txtTipPro.Tag = "3"
        Me.txtTipPro.Visible = False
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(812, 101)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(81, 23)
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.Tag = "18"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(730, 101)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(81, 23)
        Me.btnAgregar.TabIndex = 9
        Me.btnAgregar.Tag = "17"
        Me.btnAgregar.Text = "Aceptar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'txtNomIe
        '
        Me.txtNomIe.Location = New System.Drawing.Point(531, 65)
        Me.txtNomIe.Name = "txtNomIe"
        Me.txtNomIe.ReadOnly = True
        Me.txtNomIe.Size = New System.Drawing.Size(362, 20)
        Me.txtNomIe.TabIndex = 214
        Me.txtNomIe.Tag = "11"
        '
        'txtCodie
        '
        Me.txtCodie.BackColor = System.Drawing.Color.White
        Me.txtCodie.Location = New System.Drawing.Point(462, 65)
        Me.txtCodie.Name = "txtCodie"
        Me.txtCodie.Size = New System.Drawing.Size(56, 20)
        Me.txtCodie.TabIndex = 5
        Me.txtCodie.Tag = "10"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(459, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 213
        Me.Label6.Text = "Ing/Egr"
        '
        'TxtNomAre
        '
        Me.TxtNomAre.Location = New System.Drawing.Point(69, 101)
        Me.TxtNomAre.Name = "TxtNomAre"
        Me.TxtNomAre.ReadOnly = True
        Me.TxtNomAre.Size = New System.Drawing.Size(191, 20)
        Me.TxtNomAre.TabIndex = 265
        Me.TxtNomAre.Tag = "13"
        '
        'TxtCodAre
        '
        Me.TxtCodAre.BackColor = System.Drawing.Color.White
        Me.TxtCodAre.Location = New System.Drawing.Point(6, 101)
        Me.TxtCodAre.Name = "TxtCodAre"
        Me.TxtCodAre.Size = New System.Drawing.Size(57, 20)
        Me.TxtCodAre.TabIndex = 6
        Me.TxtCodAre.Tag = "12"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(6, 88)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 13)
        Me.Label11.TabIndex = 264
        Me.Label11.Text = "Area"
        '
        'TxtNomGasRep
        '
        Me.TxtNomGasRep.Location = New System.Drawing.Point(327, 103)
        Me.TxtNomGasRep.Name = "TxtNomGasRep"
        Me.TxtNomGasRep.ReadOnly = True
        Me.TxtNomGasRep.Size = New System.Drawing.Size(264, 20)
        Me.TxtNomGasRep.TabIndex = 268
        Me.TxtNomGasRep.Tag = "15"
        '
        'TxtCodGasRep
        '
        Me.TxtCodGasRep.BackColor = System.Drawing.Color.White
        Me.TxtCodGasRep.Location = New System.Drawing.Point(264, 101)
        Me.TxtCodGasRep.Name = "TxtCodGasRep"
        Me.TxtCodGasRep.Size = New System.Drawing.Size(57, 20)
        Me.TxtCodGasRep.TabIndex = 7
        Me.TxtCodGasRep.Tag = "14"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(261, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 267
        Me.Label3.Text = "C.Almacen"
        '
        'TxtCantidad
        '
        Me.TxtCantidad.Location = New System.Drawing.Point(597, 104)
        Me.TxtCantidad.Name = "TxtCantidad"
        Me.TxtCantidad.Size = New System.Drawing.Size(80, 20)
        Me.TxtCantidad.TabIndex = 8
        Me.TxtCantidad.Tag = "16"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(594, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 270
        Me.Label5.Text = "Cantidad"
        '
        'WDetalleRegCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(905, 132)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtCantidad)
        Me.Controls.Add(Me.TxtNomGasRep)
        Me.Controls.Add(Me.TxtCodGasRep)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtNomAre)
        Me.Controls.Add(Me.TxtCodAre)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtNomIe)
        Me.Controls.Add(Me.txtCodie)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtTipPro)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.txtGlosa)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.txtImpDol)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtImpSol)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.gbDebeHaber)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtNomCto)
        Me.Controls.Add(Me.txtCencto)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNomCue)
        Me.Controls.Add(Me.txtCodCuen)
        Me.Controls.Add(Me.Label4)
        Me.MaximizeBox = False
        Me.Name = "WDetalleRegCompras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WDetalleRegCompras"
        Me.gbDebeHaber.ResumeLayout(False)
        Me.gbDebeHaber.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Function ListaControles() As List(Of CtrlsEdit)
        Dim lis As New List(Of CtrlsEdit)
        Dim item As CtrlsEdit

        item = New CtrlsEdit

        item.Control = Me.txtCodCuen
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Cuenta"
        item.Obligatorio = "1"
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtNomCue
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
        item.Limpiar = "1"
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
        item.Control = Me.txtCencto
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Centro Costo"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kProyecto
        item.Valida = Validar.texto.vCodigoProyecto
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtNomCto
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
        item.Limpiar = "1"
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
        item.Control = Me.gbDebeHaber
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
        item.Control = Me.rbtDebe
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
        item.Limpiar = "1"
        item.DatoLimpiar = "True"
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
        item.Control = Me.rbtHaber
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
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
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtImpDol
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
        item.Limpiar = "1"
        item.DatoLimpiar = "0.00"
        item.Campo = "Monto Total"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtGlosa
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Glosa"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtCodie
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Codigo I/E"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.txtNomIe
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Item"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtCodAre
        item.PasaFoco = "1"
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Area"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtNomAre
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Area"
        item.Obligatorio = "0"
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
        item.Formato = "0"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Codigo"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        item.Valida = Validar.texto.vSoloNumerosSinEspacio
        item.Nuevo = "1"
        item.Modificar = "1"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtNomGasRep
        item.PasaFoco = "0"
        item.Formato = "0"
        item.PasarCursor = "0"
        item.Limpiar = "1"
        item.DatoLimpiar = ""
        item.Campo = "Area"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kNada
        item.Valida = Validar.texto.vNada
        item.Nuevo = "0"
        item.Modificar = "0"
        item.Eliminar = "0"
        item.Visualizar = "0"
        lis.Add(item)

        item = New CtrlsEdit
        item.Control = Me.TxtCantidad
        item.PasaFoco = "1"
        item.Formato = "1"
        item.PasarCursor = "1"
        item.Limpiar = "1"
        item.DatoLimpiar = "0.00"
        item.Campo = "Cantidad"
        item.Obligatorio = "0"
        item.Teclazo = Validar.Tecla.kDecimal
        item.Valida = Validar.texto.vSolonumerosConDosDecimales
        item.Nuevo = "1"
        item.Modificar = "1"
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

        item = New CtrlsEdit
        item.Control = Me.btnCancelar
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

    Friend WithEvents txtNomCue As System.Windows.Forms.TextBox
    Friend WithEvents txtCodCuen As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNomCto As System.Windows.Forms.TextBox
    Friend WithEvents txtCencto As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gbDebeHaber As System.Windows.Forms.GroupBox
    Friend WithEvents rbtHaber As System.Windows.Forms.RadioButton
    Friend WithEvents rbtDebe As System.Windows.Forms.RadioButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtImpDol As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtImpSol As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtGlosa As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents txtTipPro As System.Windows.Forms.TextBox
    Friend WithEvents txtNomIe As System.Windows.Forms.TextBox
    Friend WithEvents txtCodie As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtNomAre As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodAre As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtNomGasRep As System.Windows.Forms.TextBox
    Friend WithEvents TxtCodGasRep As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
