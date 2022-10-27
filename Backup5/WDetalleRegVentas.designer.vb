<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WDetalleRegVentas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WDetalleRegVentas))
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnAgregar = New System.Windows.Forms.Button
        Me.txtGlosa = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtImpDol = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtImpSol = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.gbDebeHaber = New System.Windows.Forms.GroupBox
        Me.rbtHaber = New System.Windows.Forms.RadioButton
        Me.rbtDebe = New System.Windows.Forms.RadioButton
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtNomCto = New System.Windows.Forms.TextBox
        Me.txtCencto = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtNomCue = New System.Windows.Forms.TextBox
        Me.txtCodCuen = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtNomIe = New System.Windows.Forms.TextBox
        Me.txtCodie = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.gbDebeHaber.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(634, 91)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(94, 23)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Tag = "13"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(543, 91)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(90, 23)
        Me.btnAgregar.TabIndex = 5
        Me.btnAgregar.Tag = "12"
        Me.btnAgregar.Text = "Aceptar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'txtGlosa
        '
        Me.txtGlosa.BackColor = System.Drawing.Color.White
        Me.txtGlosa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGlosa.Location = New System.Drawing.Point(12, 65)
        Me.txtGlosa.Name = "txtGlosa"
        Me.txtGlosa.Size = New System.Drawing.Size(429, 20)
        Me.txtGlosa.TabIndex = 3
        Me.txtGlosa.Tag = "9"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(12, 49)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(39, 13)
        Me.Label21.TabIndex = 209
        Me.Label21.Text = "Glosa"
        '
        'txtImpDol
        '
        Me.txtImpDol.Location = New System.Drawing.Point(774, 25)
        Me.txtImpDol.Name = "txtImpDol"
        Me.txtImpDol.ReadOnly = True
        Me.txtImpDol.Size = New System.Drawing.Size(92, 20)
        Me.txtImpDol.TabIndex = 208
        Me.txtImpDol.Tag = "8"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(771, 9)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(77, 13)
        Me.Label18.TabIndex = 207
        Me.Label18.Text = "Importe US$"
        '
        'txtImpSol
        '
        Me.txtImpSol.Location = New System.Drawing.Point(669, 25)
        Me.txtImpSol.Name = "txtImpSol"
        Me.txtImpSol.Size = New System.Drawing.Size(99, 20)
        Me.txtImpSol.TabIndex = 2
        Me.txtImpSol.Tag = "7"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(669, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 206
        Me.Label2.Text = "Importe S/."
        '
        'gbDebeHaber
        '
        Me.gbDebeHaber.Controls.Add(Me.rbtHaber)
        Me.gbDebeHaber.Controls.Add(Me.rbtDebe)
        Me.gbDebeHaber.Location = New System.Drawing.Point(543, 18)
        Me.gbDebeHaber.Name = "gbDebeHaber"
        Me.gbDebeHaber.Size = New System.Drawing.Size(119, 28)
        Me.gbDebeHaber.TabIndex = 196
        Me.gbDebeHaber.TabStop = False
        Me.gbDebeHaber.Tag = "4"
        '
        'rbtHaber
        '
        Me.rbtHaber.AutoSize = True
        Me.rbtHaber.Checked = True
        Me.rbtHaber.Location = New System.Drawing.Point(59, 8)
        Me.rbtHaber.Name = "rbtHaber"
        Me.rbtHaber.Size = New System.Drawing.Size(54, 17)
        Me.rbtHaber.TabIndex = 111
        Me.rbtHaber.TabStop = True
        Me.rbtHaber.Tag = "6"
        Me.rbtHaber.Text = "Haber"
        Me.rbtHaber.UseVisualStyleBackColor = True
        '
        'rbtDebe
        '
        Me.rbtDebe.AutoSize = True
        Me.rbtDebe.Location = New System.Drawing.Point(5, 8)
        Me.rbtDebe.Name = "rbtDebe"
        Me.rbtDebe.Size = New System.Drawing.Size(51, 17)
        Me.rbtDebe.TabIndex = 100
        Me.rbtDebe.Tag = "5"
        Me.rbtDebe.Text = "Debe"
        Me.rbtDebe.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(542, 7)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(31, 13)
        Me.Label14.TabIndex = 205
        Me.Label14.Text = "D/H"
        '
        'txtNomCto
        '
        Me.txtNomCto.Location = New System.Drawing.Point(338, 25)
        Me.txtNomCto.Name = "txtNomCto"
        Me.txtNomCto.ReadOnly = True
        Me.txtNomCto.Size = New System.Drawing.Size(201, 20)
        Me.txtNomCto.TabIndex = 204
        Me.txtNomCto.Tag = "3"
        '
        'txtCencto
        '
        Me.txtCencto.BackColor = System.Drawing.Color.White
        Me.txtCencto.Location = New System.Drawing.Point(270, 25)
        Me.txtCencto.MaxLength = 15
        Me.txtCencto.Name = "txtCencto"
        Me.txtCencto.Size = New System.Drawing.Size(62, 20)
        Me.txtCencto.TabIndex = 1
        Me.txtCencto.Tag = "2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(268, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 203
        Me.Label1.Text = "C.Costo"
        '
        'txtNomCue
        '
        Me.txtNomCue.Location = New System.Drawing.Point(73, 25)
        Me.txtNomCue.Name = "txtNomCue"
        Me.txtNomCue.ReadOnly = True
        Me.txtNomCue.Size = New System.Drawing.Size(193, 20)
        Me.txtNomCue.TabIndex = 194
        Me.txtNomCue.Tag = "1"
        '
        'txtCodCuen
        '
        Me.txtCodCuen.BackColor = System.Drawing.Color.White
        Me.txtCodCuen.Location = New System.Drawing.Point(12, 25)
        Me.txtCodCuen.MaxLength = 10
        Me.txtCodCuen.Name = "txtCodCuen"
        Me.txtCodCuen.Size = New System.Drawing.Size(60, 20)
        Me.txtCodCuen.TabIndex = 193
        Me.txtCodCuen.Tag = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(12, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 202
        Me.Label4.Text = "Cuenta"
        '
        'txtNomIe
        '
        Me.txtNomIe.Location = New System.Drawing.Point(543, 65)
        Me.txtNomIe.Name = "txtNomIe"
        Me.txtNomIe.ReadOnly = True
        Me.txtNomIe.Size = New System.Drawing.Size(323, 20)
        Me.txtNomIe.TabIndex = 217
        Me.txtNomIe.Tag = "11"
        '
        'txtCodie
        '
        Me.txtCodie.BackColor = System.Drawing.Color.White
        Me.txtCodie.Location = New System.Drawing.Point(447, 65)
        Me.txtCodie.Name = "txtCodie"
        Me.txtCodie.Size = New System.Drawing.Size(71, 20)
        Me.txtCodie.TabIndex = 4
        Me.txtCodie.Tag = "10"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(444, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 216
        Me.Label6.Text = "Ing/Egr"
        '
        'WDetalleRegVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(885, 122)
        Me.Controls.Add(Me.txtNomIe)
        Me.Controls.Add(Me.txtCodie)
        Me.Controls.Add(Me.Label6)
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
        Me.Name = "WDetalleRegVentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle Registro Ventas"
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


        'Dim codConc As New CtrlsEdit
        'codConc.Control = Me.txtConc
        'codConc.PasaFoco = "1"
        'codConc.Formato = "0"
        'codConc.PasarCursor = "1"
        'codConc.Limpiar = "1"
        'codConc.DatoLimpiar = ""
        'codConc.Campo = "Concepto"
        'codConc.Obligatorio = "0"
        'codConc.Teclazo = Validar.Tecla.kAlfaNumericoSinEspacio
        'codConc.Valida = Validar.texto.vSoloAlfaNumericoSinEspacio
        'codConc.Nuevo = "1"
        'codConc.Modificar = "1"
        'codConc.Eliminar = "0"
        'codConc.Visualizar = "0"
        'lis.Add(codConc)


        'Dim NomConc As New CtrlsEdit
        'NomConc.Control = Me.txtNomConc
        'NomConc.PasaFoco = "0"
        'NomConc.Formato = "0"
        'NomConc.PasarCursor = "0"
        'NomConc.Limpiar = "1"
        'NomConc.DatoLimpiar = ""
        'NomConc.Campo = "Item"
        'NomConc.Obligatorio = "0"
        'NomConc.Teclazo = Validar.Tecla.kNada
        'NomConc.Valida = Validar.texto.vNada
        'NomConc.Nuevo = "0"
        'NomConc.Modificar = "0"
        'NomConc.Eliminar = "0"
        'NomConc.Visualizar = "0"
        'lis.Add(NomConc)

        'Dim codPar As New CtrlsEdit
        'codPar.Control = Me.txtPar
        'codPar.PasaFoco = "1"
        'codPar.Formato = "0"
        'codPar.PasarCursor = "1"
        'codPar.Limpiar = "1"
        'codPar.DatoLimpiar = ""
        'codPar.Campo = "Cargo/Partida"
        'codPar.Obligatorio = "0"
        'codPar.Teclazo = Validar.Tecla.kAlfaNumericoSinEspacio
        'codPar.Valida = Validar.texto.vSoloAlfaNumericoSinEspacio
        'codPar.Nuevo = "1"
        'codPar.Modificar = "1"
        'codPar.Eliminar = "0"
        'codPar.Visualizar = "0"
        'lis.Add(codPar)


        'Dim NomPar As New CtrlsEdit
        'NomPar.Control = Me.txtNomPar
        'NomPar.PasaFoco = "0"
        'NomPar.Formato = "0"
        'NomPar.PasarCursor = "0"
        'NomPar.Limpiar = "1"
        'NomPar.DatoLimpiar = ""
        'NomPar.Campo = "Item"
        'NomPar.Obligatorio = "0"
        'NomPar.Teclazo = Validar.Tecla.kNada
        'NomPar.Valida = Validar.texto.vNada
        'NomPar.Nuevo = "0"
        'NomPar.Modificar = "0"
        'NomPar.Eliminar = "0"
        'NomPar.Visualizar = "0"
        'lis.Add(NomPar)

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
        item.Control = Me.rbtHaber
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
        item.Campo = "Ingreso/Egreso"
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


    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents txtGlosa As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtImpDol As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtImpSol As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gbDebeHaber As System.Windows.Forms.GroupBox
    Friend WithEvents rbtHaber As System.Windows.Forms.RadioButton
    Friend WithEvents rbtDebe As System.Windows.Forms.RadioButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtNomCto As System.Windows.Forms.TextBox
    Friend WithEvents txtCencto As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNomCue As System.Windows.Forms.TextBox
    Friend WithEvents txtCodCuen As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNomIe As System.Windows.Forms.TextBox
    Friend WithEvents txtCodie As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
