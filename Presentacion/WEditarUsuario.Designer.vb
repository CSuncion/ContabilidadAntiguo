<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WEditarUsuario
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
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.txtCon = New System.Windows.Forms.TextBox
        Me.txtCla = New System.Windows.Forms.TextBox
        Me.txtNomPer = New System.Windows.Forms.TextBox
        Me.txtCodUsu = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbtDes = New System.Windows.Forms.RadioButton
        Me.rbtAct = New System.Windows.Forms.RadioButton
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Presentacion.My.Resources.Resources.action_stop
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(204, 151)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(99, 23)
        Me.btnCancelar.TabIndex = 6
        Me.btnCancelar.Tag = "8"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.Presentacion.My.Resources.Resources.apply
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(105, 151)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(99, 23)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Tag = "7"
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'txtCon
        '
        Me.txtCon.BackColor = System.Drawing.Color.White
        Me.txtCon.Location = New System.Drawing.Point(106, 86)
        Me.txtCon.MaxLength = 20
        Me.txtCon.Name = "txtCon"
        Me.txtCon.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtCon.Size = New System.Drawing.Size(253, 20)
        Me.txtCon.TabIndex = 3
        Me.txtCon.Tag = "3"
        '
        'txtCla
        '
        Me.txtCla.BackColor = System.Drawing.Color.White
        Me.txtCla.Location = New System.Drawing.Point(106, 62)
        Me.txtCla.MaxLength = 20
        Me.txtCla.Name = "txtCla"
        Me.txtCla.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtCla.Size = New System.Drawing.Size(253, 20)
        Me.txtCla.TabIndex = 2
        Me.txtCla.Tag = "2"
        '
        'txtNomPer
        '
        Me.txtNomPer.AcceptsTab = True
        Me.txtNomPer.BackColor = System.Drawing.Color.White
        Me.txtNomPer.Location = New System.Drawing.Point(105, 14)
        Me.txtNomPer.Name = "txtNomPer"
        Me.txtNomPer.Size = New System.Drawing.Size(254, 20)
        Me.txtNomPer.TabIndex = 0
        Me.txtNomPer.Tag = "0"
        '
        'txtCodUsu
        '
        Me.txtCodUsu.BackColor = System.Drawing.Color.White
        Me.txtCodUsu.Location = New System.Drawing.Point(106, 38)
        Me.txtCodUsu.MaxLength = 30
        Me.txtCodUsu.Name = "txtCodUsu"
        Me.txtCodUsu.Size = New System.Drawing.Size(253, 20)
        Me.txtCodUsu.TabIndex = 1
        Me.txtCodUsu.Tag = "1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(26, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Confirmar :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(26, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Contraseña :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(26, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Nombre :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(26, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Usuario :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(26, 116)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 103
        Me.Label6.Text = "Estado :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtDes)
        Me.GroupBox1.Controls.Add(Me.rbtAct)
        Me.GroupBox1.Location = New System.Drawing.Point(105, 107)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(254, 29)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Tag = "4"
        '
        'rbtDes
        '
        Me.rbtDes.AutoSize = True
        Me.rbtDes.Location = New System.Drawing.Point(134, 10)
        Me.rbtDes.Name = "rbtDes"
        Me.rbtDes.Size = New System.Drawing.Size(85, 17)
        Me.rbtDes.TabIndex = 100
        Me.rbtDes.Tag = "6"
        Me.rbtDes.Text = "Desactivado"
        Me.rbtDes.UseVisualStyleBackColor = True
        '
        'rbtAct
        '
        Me.rbtAct.AutoSize = True
        Me.rbtAct.Checked = True
        Me.rbtAct.Location = New System.Drawing.Point(32, 10)
        Me.rbtAct.Name = "rbtAct"
        Me.rbtAct.Size = New System.Drawing.Size(67, 17)
        Me.rbtAct.TabIndex = 100
        Me.rbtAct.TabStop = True
        Me.rbtAct.Tag = "5"
        Me.rbtAct.Text = "Activado"
        Me.rbtAct.UseVisualStyleBackColor = True
        '
        'WEditarUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(394, 188)
        Me.Controls.Add(Me.txtNomPer)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtCon)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCla)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCodUsu)
        Me.Controls.Add(Me.Label4)
        Me.MaximizeBox = False
        Me.Name = "WEditarUsuario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WEditarUsuario"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Function ListaControles() As List(Of CtrlsEdit)
        Dim lis As New List(Of CtrlsEdit)

        'txtNomCod
        Dim NomPer As New CtrlsEdit
        NomPer.Control = Me.txtNomPer
        NomPer.PasaFoco = "1"
        NomPer.Formato = "0"
        NomPer.PasarCursor = "1"
        NomPer.Limpiar = "1"
        NomPer.DatoLimpiar = ""
        NomPer.Campo = "Nombre "
        NomPer.Obligatorio = "1"
        NomPer.Teclazo = Validar.Tecla.kNada
        NomPer.Valida = Validar.texto.vNada
        NomPer.Nuevo = "1"
        NomPer.Modificar = "1"
        NomPer.Eliminar = "0"
        NomPer.Visualizar = "0"
        lis.Add(NomPer)

        'txtCodUsu
        Dim codUsu As New CtrlsEdit
        codUsu.Control = Me.txtCodUsu
        codUsu.PasaFoco = "1"
        codUsu.Formato = "0"
        codUsu.PasarCursor = "1"
        codUsu.Limpiar = "1"
        codUsu.DatoLimpiar = ""
        codUsu.Campo = "Usuario"
        codUsu.Obligatorio = "1"
        codUsu.Teclazo = Validar.Tecla.kAlfaNumericoSinEspacio
        codUsu.Valida = Validar.texto.vSoloAlfaNumericoSinEspacio
        codUsu.Nuevo = "1"
        codUsu.Modificar = "0"
        codUsu.Eliminar = "0"
        codUsu.Visualizar = "0"
        lis.Add(codUsu)

        'txtCla
        Dim cla As New CtrlsEdit
        cla.Control = Me.txtCla
        cla.PasaFoco = "1"
        cla.Formato = "0"
        cla.PasarCursor = "1"
        cla.Limpiar = "1"
        cla.DatoLimpiar = ""
        cla.Campo = "Clave"
        cla.Obligatorio = "1"
        cla.Teclazo = Validar.Tecla.kAlfaNumericoSinEspacio
        cla.Valida = Validar.texto.vClave
        cla.Nuevo = "1"
        cla.Modificar = "1"
        cla.Eliminar = "0"
        cla.Visualizar = "0"
        lis.Add(cla)

        'txtCon
        Dim con As New CtrlsEdit
        con.Control = Me.txtCon
        con.PasaFoco = "1"
        con.Formato = "0"
        con.PasarCursor = "1"
        con.Limpiar = "1"
        con.DatoLimpiar = ""
        con.Campo = "Confirmar"
        con.Obligatorio = "1"
        con.Teclazo = Validar.Tecla.kAlfaNumericoSinEspacio
        con.Valida = Validar.texto.vClave
        con.Nuevo = "1"
        con.Modificar = "1"
        con.Eliminar = "0"
        con.Visualizar = "0"
        lis.Add(con)

      
        'txtGbEstado
        Dim gbEst As New CtrlsEdit
        gbEst.Control = Me.GroupBox1
        gbEst.PasaFoco = "1"
        gbEst.Formato = ""
        gbEst.PasarCursor = "0"
        gbEst.Limpiar = "0"
        gbEst.DatoLimpiar = ""
        gbEst.Campo = ""
        gbEst.Obligatorio = "0"
        gbEst.Teclazo = Validar.Tecla.kNada
        gbEst.Valida = Validar.texto.vNada
        gbEst.Nuevo = "1"
        gbEst.Modificar = "1"
        gbEst.Eliminar = "1"
        gbEst.Visualizar = "1"
        lis.Add(gbEst)

        'rbtAct
        Dim act As New CtrlsEdit
        act.Control = Me.rbtAct
        act.PasaFoco = "1"
        act.Formato = ""
        act.PasarCursor = "1"
        act.Limpiar = "1"
        act.DatoLimpiar = "True"
        act.Campo = ""
        act.Obligatorio = "0"
        act.Teclazo = Validar.Tecla.kNada
        act.Valida = Validar.texto.vNada
        act.Nuevo = "1"
        act.Modificar = "1"
        act.Eliminar = "0"
        act.Visualizar = "0"
        lis.Add(act)

        'txtCodPer
        Dim des As New CtrlsEdit
        des.Control = Me.rbtDes
        des.PasaFoco = "1"
        des.Formato = ""
        des.PasarCursor = "1"
        des.Limpiar = "0"
        des.DatoLimpiar = ""
        des.Campo = ""
        des.Obligatorio = "0"
        des.Teclazo = Validar.Tecla.kNada
        des.Valida = Validar.texto.vNada
        des.Nuevo = "1"
        des.Modificar = "1"
        des.Eliminar = "0"
        des.Visualizar = "0"
        lis.Add(des)

        'txtbtnAceptar
        Dim aceptar As New CtrlsEdit
        aceptar.Control = Me.btnAceptar
        aceptar.PasaFoco = "1"
        aceptar.Formato = "0"
        aceptar.PasarCursor = "1"
        aceptar.Limpiar = "0"
        aceptar.DatoLimpiar = ""
        aceptar.Campo = ""
        aceptar.Obligatorio = "0"
        aceptar.Teclazo = Validar.Tecla.kNada
        aceptar.Valida = Validar.texto.vNada
        aceptar.Nuevo = "1"
        aceptar.Modificar = "1"
        aceptar.Eliminar = "1"
        aceptar.Visualizar = "0"
        lis.Add(aceptar)

        Return lis
    End Function

    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents txtCon As System.Windows.Forms.TextBox
    Friend WithEvents txtCla As System.Windows.Forms.TextBox
    Friend WithEvents txtNomPer As System.Windows.Forms.TextBox
    Friend WithEvents txtCodUsu As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtDes As System.Windows.Forms.RadioButton
    Friend WithEvents rbtAct As System.Windows.Forms.RadioButton
End Class
