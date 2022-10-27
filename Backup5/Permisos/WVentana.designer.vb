<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WVentana
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
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WVentana))
            Me.tst1 = New System.Windows.Forms.ToolStrip
            Me.btnAdicionar = New System.Windows.Forms.ToolStripButton
            Me.btnModificar = New System.Windows.Forms.ToolStripButton
            Me.btnEliminar = New System.Windows.Forms.ToolStripButton
            Me.btnVisualizar = New System.Windows.Forms.ToolStripButton
            Me.btnImprimir = New System.Windows.Forms.ToolStripButton
            Me.btnRegresar = New System.Windows.Forms.ToolStripButton
            Me.tst2 = New System.Windows.Forms.ToolStrip
            Me.btnPrimero = New System.Windows.Forms.ToolStripButton
            Me.btnAnterior = New System.Windows.Forms.ToolStripButton
            Me.btnSiguiente = New System.Windows.Forms.ToolStripButton
            Me.btnUltimo = New System.Windows.Forms.ToolStripButton
            Me.btnActualizarTabla = New System.Windows.Forms.ToolStripButton
            Me.btnBuscar = New System.Windows.Forms.ToolStripButton
            Me.btnRecycla = New System.Windows.Forms.ToolStripButton
            Me.DgvVen = New System.Windows.Forms.DataGridView
            Me.sst1 = New System.Windows.Forms.StatusStrip
            Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
            Me.lblUsu = New System.Windows.Forms.ToolStripStatusLabel
            Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
            Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
            Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel
            Me.lblRgs = New System.Windows.Forms.ToolStripStatusLabel
            Me.btnOpciones = New System.Windows.Forms.ToolStripButton
            Me.tst1.SuspendLayout()
            Me.tst2.SuspendLayout()
            CType(Me.DgvVen, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.sst1.SuspendLayout()
            Me.SuspendLayout()
            '
            'tst1
            '
            Me.tst1.AutoSize = False
            Me.tst1.BackColor = System.Drawing.Color.White
            Me.tst1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.tst1.ImageScalingSize = New System.Drawing.Size(20, 20)
            Me.tst1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdicionar, Me.btnModificar, Me.btnEliminar, Me.btnVisualizar, Me.btnImprimir, Me.btnRegresar})
            Me.tst1.Location = New System.Drawing.Point(0, 0)
            Me.tst1.Name = "tst1"
            Me.tst1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
            Me.tst1.ShowItemToolTips = False
            Me.tst1.Size = New System.Drawing.Size(455, 53)
            Me.tst1.TabIndex = 87
            Me.tst1.Text = "ToolStrip2"
            '
            'btnAdicionar
            '
        Me.btnAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btnAdicionar.Name = "btnAdicionar"
            Me.btnAdicionar.Size = New System.Drawing.Size(55, 50)
            Me.btnAdicionar.Text = "&Adicionar"
            Me.btnAdicionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
            '
            'btnModificar
            '
        Me.btnModificar.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btnModificar.Name = "btnModificar"
            Me.btnModificar.Size = New System.Drawing.Size(54, 50)
            Me.btnModificar.Text = "&Modificar"
            Me.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
            '
            'btnEliminar
         
            Me.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btnEliminar.Name = "btnEliminar"
            Me.btnEliminar.Size = New System.Drawing.Size(47, 50)
            Me.btnEliminar.Text = "&Eliminar"
            Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
            '
            'btnVisualizar
            '

            Me.btnVisualizar.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btnVisualizar.Name = "btnVisualizar"
            Me.btnVisualizar.Size = New System.Drawing.Size(55, 50)
            Me.btnVisualizar.Text = "&Visualizar"
            Me.btnVisualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
            '
            'btnImprimir
            '

            Me.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btnImprimir.Name = "btnImprimir"
            Me.btnImprimir.Size = New System.Drawing.Size(49, 50)
            Me.btnImprimir.Text = "&Imprimir"
            Me.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
            '
            'btnRegresar
            '

            Me.btnRegresar.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btnRegresar.Name = "btnRegresar"
            Me.btnRegresar.Size = New System.Drawing.Size(55, 50)
            Me.btnRegresar.Text = "&Regresar"
            Me.btnRegresar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
            '
            'tst2
            '
            Me.tst2.AutoSize = False
            Me.tst2.BackColor = System.Drawing.Color.White
            Me.tst2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
            Me.tst2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnPrimero, Me.btnAnterior, Me.btnSiguiente, Me.btnUltimo, Me.btnActualizarTabla, Me.btnBuscar, Me.btnRecycla, Me.btnOpciones})
            Me.tst2.Location = New System.Drawing.Point(0, 53)
            Me.tst2.Name = "tst2"
            Me.tst2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
            Me.tst2.Size = New System.Drawing.Size(455, 27)
            Me.tst2.TabIndex = 88
            Me.tst2.Text = "ToolStrip2"
            '
            'btnPrimero
            '
            Me.btnPrimero.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image

            Me.btnPrimero.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btnPrimero.Name = "btnPrimero"
            Me.btnPrimero.Size = New System.Drawing.Size(23, 24)
            '
            'btnAnterior
            '
            Me.btnAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image

            Me.btnAnterior.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btnAnterior.Name = "btnAnterior"
            Me.btnAnterior.Size = New System.Drawing.Size(23, 24)
            '
            'btnSiguiente
            '
            Me.btnSiguiente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image

            Me.btnSiguiente.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btnSiguiente.Name = "btnSiguiente"
            Me.btnSiguiente.Size = New System.Drawing.Size(23, 24)
            '
            'btnUltimo
            '
            Me.btnUltimo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image

            Me.btnUltimo.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btnUltimo.Name = "btnUltimo"
            Me.btnUltimo.Size = New System.Drawing.Size(23, 24)
            '
            'btnActualizarTabla
            '
            Me.btnActualizarTabla.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image

            Me.btnActualizarTabla.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btnActualizarTabla.Name = "btnActualizarTabla"
            Me.btnActualizarTabla.Size = New System.Drawing.Size(23, 24)
            Me.btnActualizarTabla.Text = "Actualiza Tabla"
            '
            'btnBuscar
            '
            Me.btnBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image

            Me.btnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btnBuscar.Name = "btnBuscar"
            Me.btnBuscar.Size = New System.Drawing.Size(23, 24)
            Me.btnBuscar.Text = "Buscar"
            '
            'btnRecycla
            '
            Me.btnRecycla.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image

            Me.btnRecycla.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btnRecycla.Name = "btnRecycla"
            Me.btnRecycla.Size = New System.Drawing.Size(23, 24)
            Me.btnRecycla.Text = "Papelera"
            '
            'DgvVen
            '
            Me.DgvVen.BackgroundColor = System.Drawing.Color.White
            Me.DgvVen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
            DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
            DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
            DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
            DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DgvVen.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
            Me.DgvVen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DgvVen.Location = New System.Drawing.Point(0, 80)
            Me.DgvVen.MultiSelect = False
            Me.DgvVen.Name = "DgvVen"
            Me.DgvVen.Size = New System.Drawing.Size(454, 217)
            Me.DgvVen.TabIndex = 89
            '
            'sst1
            '
            Me.sst1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblUsu, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel5, Me.lblRgs})
            Me.sst1.Location = New System.Drawing.Point(0, 298)
            Me.sst1.Name = "sst1"
            Me.sst1.Size = New System.Drawing.Size(455, 22)
            Me.sst1.TabIndex = 90
            Me.sst1.Text = "StatusStrip1"
            '
            'ToolStripStatusLabel1
            '
            Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
            Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
            '
            'lblUsu
            '
            Me.lblUsu.Name = "lblUsu"
            Me.lblUsu.Size = New System.Drawing.Size(47, 17)
            Me.lblUsu.Text = "LuisIvan"
            '
            'ToolStripStatusLabel3
            '
            Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
            Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(11, 17)
            Me.ToolStripStatusLabel3.Text = "-"
            '
            'ToolStripStatusLabel2
            '
            Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
            Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(0, 17)
            '
            'ToolStripStatusLabel5
            '
            Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
            Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(44, 17)
            Me.ToolStripStatusLabel5.Text = "Nº Rgs:"
            '
            'lblRgs
            '
            Me.lblRgs.Name = "lblRgs"
            Me.lblRgs.Size = New System.Drawing.Size(25, 17)
            Me.lblRgs.Text = "100"
            '
            'btnOpciones
            '
            Me.btnOpciones.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
            Me.btnOpciones.Image = CType(resources.GetObject("btnOpciones.Image"), System.Drawing.Image)
            Me.btnOpciones.ImageTransparentColor = System.Drawing.Color.Magenta
            Me.btnOpciones.Name = "btnOpciones"
            Me.btnOpciones.Size = New System.Drawing.Size(23, 24)
            Me.btnOpciones.Text = "Opciones"
            '
            'WVentana
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
            Me.ClientSize = New System.Drawing.Size(455, 320)
            Me.Controls.Add(Me.sst1)
            Me.Controls.Add(Me.DgvVen)
            Me.Controls.Add(Me.tst2)
            Me.Controls.Add(Me.tst1)
            Me.MaximizeBox = False
            Me.Name = "WVentana"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Ventanas"
            Me.tst1.ResumeLayout(False)
            Me.tst1.PerformLayout()
            Me.tst2.ResumeLayout(False)
            Me.tst2.PerformLayout()
            CType(Me.DgvVen, System.ComponentModel.ISupportInitialize).EndInit()
            Me.sst1.ResumeLayout(False)
            Me.sst1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

      End Sub

      Function ListaBotones() As List(Of ListaTsb)
            Dim lis As New List(Of ListaTsb)
            Dim item As ListaTsb


            item = New ListaTsb
            item.Tsb = Me.btnModificar
            item.GrillaVacia = "1"
            item.Desplaza = "0"
            item.indiceFila = -1
            lis.Add(item)

            item = New ListaTsb
            item.Tsb = Me.btnRecycla
            item.GrillaVacia = "1"
            item.Desplaza = "0"
            item.indiceFila = -1
            lis.Add(item)

            item = New ListaTsb
            item.Tsb = Me.btnEliminar
            item.GrillaVacia = "1"
            item.Desplaza = "0"
            item.indiceFila = -1
            lis.Add(item)


            item = New ListaTsb
            item.Tsb = Me.btnImprimir
            item.GrillaVacia = "1"
            item.Desplaza = "0"
            item.indiceFila = -1
            lis.Add(item)

            item = New ListaTsb
            item.Tsb = Me.btnVisualizar
            item.GrillaVacia = "1"
            item.Desplaza = "0"
            item.indiceFila = -1
            lis.Add(item)

            item = New ListaTsb
            item.Tsb = Me.btnBuscar
            item.GrillaVacia = "1"
            item.Desplaza = "0"
            item.indiceFila = -1
            lis.Add(item)

            item = New ListaTsb
            item.Tsb = Me.btnOpciones
            item.GrillaVacia = "1"
            item.Desplaza = "0"
            item.indiceFila = -1
            lis.Add(item)


            item = New ListaTsb
            item.Tsb = Me.btnPrimero
            item.GrillaVacia = "0"
            item.Desplaza = "1"
            item.indiceFila = 0
            lis.Add(item)

            item = New ListaTsb
            item.Tsb = Me.btnAnterior
            item.GrillaVacia = "0"
            item.Desplaza = "1"
            item.indiceFila = 0
            lis.Add(item)

            Dim int As Integer = Me.DgvVen.Rows.Count - 1

            item = New ListaTsb
            item.Tsb = Me.btnSiguiente
            item.GrillaVacia = "0"
            item.Desplaza = "1"
            item.indiceFila = int
            lis.Add(item)


            item = New ListaTsb
            item.Tsb = Me.btnUltimo
            item.GrillaVacia = "0"
            item.Desplaza = "1"
            item.indiceFila = int
            lis.Add(item)

            Return lis

      End Function
      Friend WithEvents tst1 As System.Windows.Forms.ToolStrip
      Public WithEvents btnAdicionar As System.Windows.Forms.ToolStripButton
      Public WithEvents btnModificar As System.Windows.Forms.ToolStripButton
      Friend WithEvents btnEliminar As System.Windows.Forms.ToolStripButton
      Friend WithEvents btnVisualizar As System.Windows.Forms.ToolStripButton
      Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripButton
      Friend WithEvents btnRegresar As System.Windows.Forms.ToolStripButton
      Friend WithEvents tst2 As System.Windows.Forms.ToolStrip
      Friend WithEvents btnPrimero As System.Windows.Forms.ToolStripButton
      Friend WithEvents btnAnterior As System.Windows.Forms.ToolStripButton
      Friend WithEvents btnSiguiente As System.Windows.Forms.ToolStripButton
      Friend WithEvents btnUltimo As System.Windows.Forms.ToolStripButton
      Friend WithEvents btnActualizarTabla As System.Windows.Forms.ToolStripButton
      Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripButton
      Friend WithEvents btnRecycla As System.Windows.Forms.ToolStripButton
      Friend WithEvents DgvVen As System.Windows.Forms.DataGridView
      Friend WithEvents sst1 As System.Windows.Forms.StatusStrip
      Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
      Friend WithEvents lblUsu As System.Windows.Forms.ToolStripStatusLabel
      Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
      Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
      Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
      Friend WithEvents lblRgs As System.Windows.Forms.ToolStripStatusLabel
      Friend WithEvents btnOpciones As System.Windows.Forms.ToolStripButton
End Class
