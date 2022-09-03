<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WEditarTabla
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
        Me.txtCod = New System.Windows.Forms.TextBox
        Me.txtNom = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.lblInEg = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtCod
        '
        Me.txtCod.BackColor = System.Drawing.Color.White
        Me.txtCod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCod.Location = New System.Drawing.Point(85, 17)
        Me.txtCod.Name = "txtCod"
        Me.txtCod.Size = New System.Drawing.Size(100, 20)
        Me.txtCod.TabIndex = 0
        Me.txtCod.Tag = "0"
        '
        'txtNom
        '
        Me.txtNom.BackColor = System.Drawing.Color.White
        Me.txtNom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNom.Location = New System.Drawing.Point(85, 43)
        Me.txtNom.Name = "txtNom"
        Me.txtNom.Size = New System.Drawing.Size(214, 20)
        Me.txtNom.TabIndex = 1
        Me.txtNom.Tag = "1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Codigo :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Nombre :"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.Presentacion.My.Resources.Resources.action_stop
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(179, 96)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(96, 23)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Tag = "3"
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.Presentacion.My.Resources.Resources.apply
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(84, 96)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(96, 23)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Tag = "2"
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'lblInEg
        '
        Me.lblInEg.AutoSize = True
        Me.lblInEg.Location = New System.Drawing.Point(191, 20)
        Me.lblInEg.Name = "lblInEg"
        Me.lblInEg.Size = New System.Drawing.Size(142, 13)
        Me.lblInEg.TabIndex = 5
        Me.lblInEg.Text = "( 1 = Ingresos , 2 = Egresos )"
        Me.lblInEg.Visible = False
        '
        'WEditarTabla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(393, 146)
        Me.Controls.Add(Me.lblInEg)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtNom)
        Me.Controls.Add(Me.txtCod)
        Me.MaximizeBox = False
        Me.Name = "WEditarTabla"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WEditarTabla"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Function ListaControles() As List(Of CtrlsEdit)
        Dim lis As New List(Of CtrlsEdit)

        Dim cod As New CtrlsEdit
        cod.Control = Me.txtCod
        cod.PasaFoco = "1"
        cod.Formato = ""
        cod.PasarCursor = "1"
        cod.Limpiar = "1"
        cod.DatoLimpiar = ""
        cod.Campo = "Codigo"
        cod.Obligatorio = "1"
        cod.Teclazo = Validar.Tecla.kAlfaNumericoSinEspacio
        cod.Valida = Validar.texto.vSoloAlfaNumericoSinEspacio
        cod.Nuevo = "1"
        cod.Modificar = "0"
        cod.Eliminar = "0"
        cod.Visualizar = "0"
        lis.Add(cod)

        Dim nom As New CtrlsEdit
        nom.Control = Me.txtNom
        nom.PasaFoco = "1"
        nom.Formato = ""
        nom.PasarCursor = "1"
        nom.Limpiar = "1"
        nom.DatoLimpiar = ""
        nom.Campo = "Descripcion"
        nom.Obligatorio = "1"
        nom.Teclazo = Validar.Tecla.kAlfaNumericoConEspacio
        nom.Valida = Validar.texto.vSoloAlfaNumericoConEspacio
        nom.Nuevo = "1"
        nom.Modificar = "1"
        nom.Eliminar = "0"
        nom.Visualizar = "0"
        lis.Add(nom)

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

      Friend WithEvents txtCod As System.Windows.Forms.TextBox
      Friend WithEvents txtNom As System.Windows.Forms.TextBox
      Friend WithEvents Label1 As System.Windows.Forms.Label
      Friend WithEvents Label2 As System.Windows.Forms.Label
      Friend WithEvents btnAceptar As System.Windows.Forms.Button
      Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblInEg As System.Windows.Forms.Label
End Class
