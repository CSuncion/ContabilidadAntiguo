<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WEditarMes
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtNumDias = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtNom = New System.Windows.Forms.TextBox
        Me.txtCod = New System.Windows.Forms.TextBox
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnGrabar = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(19, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Num Dias :"
        '
        'txtNumDias
        '
        Me.txtNumDias.Location = New System.Drawing.Point(90, 63)
        Me.txtNumDias.MaxLength = 2
        Me.txtNumDias.Name = "txtNumDias"
        Me.txtNumDias.Size = New System.Drawing.Size(40, 20)
        Me.txtNumDias.TabIndex = 2
        Me.txtNumDias.Tag = "2"
        Me.txtNumDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(19, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Nombre :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(19, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo :"
        '
        'txtNom
        '
        Me.txtNom.Location = New System.Drawing.Point(90, 37)
        Me.txtNom.MaxLength = 15
        Me.txtNom.Name = "txtNom"
        Me.txtNom.Size = New System.Drawing.Size(214, 20)
        Me.txtNom.TabIndex = 1
        Me.txtNom.Tag = "1"
        '
        'txtCod
        '
        Me.txtCod.Location = New System.Drawing.Point(90, 11)
        Me.txtCod.MaxLength = 3
        Me.txtCod.Name = "txtCod"
        Me.txtCod.Size = New System.Drawing.Size(100, 20)
        Me.txtCod.TabIndex = 0
        Me.txtCod.Tag = "0"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Presentacion.My.Resources.Resources.action_stop
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(184, 93)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(96, 23)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Tag = "4"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.Image = Global.Presentacion.My.Resources.Resources.apply
        Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabar.Location = New System.Drawing.Point(89, 93)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(96, 23)
        Me.btnGrabar.TabIndex = 3
        Me.btnGrabar.Tag = "3"
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        '
        'WEditarMes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(355, 135)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNumDias)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGrabar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNom)
        Me.Controls.Add(Me.txtCod)
        Me.MaximizeBox = False
        Me.Name = "WEditarMes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WEditarMes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Function ListaControles() As List(Of CtrlsEdit)
        Dim lis As New List(Of CtrlsEdit)

        Dim codMes As New CtrlsEdit
        codMes.Control = Me.txtCod
        codMes.GanaFoco = ""
        codMes.PierdeFoco = "1"
        codMes.PasarCursor = "1"
        codMes.Limpiar = ""
        codMes.Obligatorio = "1"
        codMes.Campo = "Codigo Mes"
        codMes.Teclazo = Validar.Tecla.kAlfaNumericoSinEspacio
        codMes.Valida = Validar.texto.vSoloAlfaNumericoSinEspacio
        lis.Add(codMes)

        Dim nomMes As New CtrlsEdit
        nomMes.Control = Me.txtNom
        nomMes.GanaFoco = ""
        nomMes.PierdeFoco = "1"
        nomMes.PasarCursor = "1"
        nomMes.Limpiar = ""
        nomMes.Obligatorio = "1"
        nomMes.Campo = "Nombre Mes"
        nomMes.Teclazo = Validar.Tecla.kSoloLetraSinEspacio
        nomMes.Valida = Validar.texto.vSoloLetrasSinEspacio
        lis.Add(nomMes)

        Dim numDias As New CtrlsEdit
        numDias.Control = Me.txtNumDias
        numDias.GanaFoco = ""
        numDias.PierdeFoco = "1"
        numDias.PasarCursor = "1"
        numDias.Limpiar = ""
        numDias.Obligatorio = "1"
        numDias.Campo = "Numero de dias"
        numDias.Teclazo = Validar.Tecla.kSoloNumeroSinEspacio
        numDias.Valida = Validar.texto.vNumeroDiasDeMes
        lis.Add(numDias)

        Dim Grabar As New CtrlsEdit
        Grabar.Control = Me.btnGrabar
        Grabar.GanaFoco = "-1"
        Grabar.PierdeFoco = "-1"
        Grabar.PasarCursor = "-1"
        Grabar.Limpiar = "-1"
        Grabar.Obligatorio = "-1"
        Grabar.Campo = ""
        Grabar.Teclazo = -1
        Grabar.Valida = -1
        lis.Add(Grabar)


        Return lis




    End Function

    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNumDias As System.Windows.Forms.TextBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNom As System.Windows.Forms.TextBox
    Friend WithEvents txtCod As System.Windows.Forms.TextBox
End Class
