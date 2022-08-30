<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WIngresoEgreso
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
        Me.tst1 = New System.Windows.Forms.ToolStrip
        Me.btnAdicionar = New System.Windows.Forms.ToolStripButton
        Me.btnModificar = New System.Windows.Forms.ToolStripButton
        Me.btnEliminar = New System.Windows.Forms.ToolStripButton
        Me.btnVisualizar = New System.Windows.Forms.ToolStripButton
        Me.btnImprimir = New System.Windows.Forms.ToolStripButton
        Me.btnExportar = New System.Windows.Forms.ToolStripButton
        Me.btnRegresar = New System.Windows.Forms.ToolStripButton
        Me.tst2 = New System.Windows.Forms.ToolStrip
        Me.btnPrimero = New System.Windows.Forms.ToolStripButton
        Me.btnAnterior = New System.Windows.Forms.ToolStripButton
        Me.btnSiguiente = New System.Windows.Forms.ToolStripButton
        Me.btnUltimo = New System.Windows.Forms.ToolStripButton
        Me.btnActualizarTabla = New System.Windows.Forms.ToolStripButton
        Me.btnBuscar = New System.Windows.Forms.ToolStripButton
        Me.DgvIngEgr = New System.Windows.Forms.DataGridView
        Me.sst1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblUsu = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblRgs = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblPer = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblEmp = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel8 = New System.Windows.Forms.ToolStripStatusLabel
        Me.tst1.SuspendLayout()
        Me.tst2.SuspendLayout()
        CType(Me.DgvIngEgr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sst1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tst1
        '
        Me.tst1.AutoSize = False
        Me.tst1.BackColor = System.Drawing.Color.White
        Me.tst1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tst1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tst1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdicionar, Me.btnModificar, Me.btnEliminar, Me.btnVisualizar, Me.btnImprimir, Me.btnExportar, Me.btnRegresar})
        Me.tst1.Location = New System.Drawing.Point(0, 0)
        Me.tst1.Name = "tst1"
        Me.tst1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tst1.ShowItemToolTips = False
        Me.tst1.Size = New System.Drawing.Size(524, 53)
        Me.tst1.TabIndex = 92
        Me.tst1.Text = "ToolStrip2"
        '
        'btnAdicionar
        '
        Me.btnAdicionar.Image = Global.Presentacion.My.Resources.Resources.add
        Me.btnAdicionar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAdicionar.Name = "btnAdicionar"
        Me.btnAdicionar.Size = New System.Drawing.Size(62, 50)
        Me.btnAdicionar.Text = "&Adicionar"
        Me.btnAdicionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnModificar
        '
        Me.btnModificar.Image = Global.Presentacion.My.Resources.Resources._0145_task_edit
        Me.btnModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(62, 50)
        Me.btnModificar.Text = "&Modificar"
        Me.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = Global.Presentacion.My.Resources.Resources.Bin__empty_
        Me.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(54, 50)
        Me.btnEliminar.Text = "&Eliminar"
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnVisualizar
        '
        Me.btnVisualizar.Image = Global.Presentacion.My.Resources.Resources.Game_11_32x32_32
        Me.btnVisualizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnVisualizar.Name = "btnVisualizar"
        Me.btnVisualizar.Size = New System.Drawing.Size(60, 50)
        Me.btnVisualizar.Text = "&Visualizar"
        Me.btnVisualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnImprimir
        '
        Me.btnImprimir.Image = Global.Presentacion.My.Resources.Resources.print
        Me.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(57, 50)
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnImprimir.Visible = False
        '
        'btnExportar
        '
        Me.btnExportar.Image = Global.Presentacion.My.Resources.Resources.table
        Me.btnExportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(54, 50)
        Me.btnExportar.Text = "&Exportar"
        Me.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnExportar.Visible = False
        '
        'btnRegresar
        '
        Me.btnRegresar.Image = Global.Presentacion.My.Resources.Resources.gnome_home
        Me.btnRegresar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRegresar.Name = "btnRegresar"
        Me.btnRegresar.Size = New System.Drawing.Size(56, 50)
        Me.btnRegresar.Text = "&Regresar"
        Me.btnRegresar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tst2
        '
        Me.tst2.AutoSize = False
        Me.tst2.BackColor = System.Drawing.Color.White
        Me.tst2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tst2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnPrimero, Me.btnAnterior, Me.btnSiguiente, Me.btnUltimo, Me.btnActualizarTabla, Me.btnBuscar})
        Me.tst2.Location = New System.Drawing.Point(0, 53)
        Me.tst2.Name = "tst2"
        Me.tst2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tst2.Size = New System.Drawing.Size(524, 27)
        Me.tst2.TabIndex = 93
        Me.tst2.Text = "ToolStrip2"
        '
        'btnPrimero
        '
        Me.btnPrimero.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPrimero.Image = Global.Presentacion.My.Resources.Resources._18
        Me.btnPrimero.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrimero.Name = "btnPrimero"
        Me.btnPrimero.Size = New System.Drawing.Size(23, 24)
        '
        'btnAnterior
        '
        Me.btnAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAnterior.Image = Global.Presentacion.My.Resources.Resources._16
        Me.btnAnterior.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(23, 24)
        '
        'btnSiguiente
        '
        Me.btnSiguiente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSiguiente.Image = Global.Presentacion.My.Resources.Resources._17
        Me.btnSiguiente.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(23, 24)
        '
        'btnUltimo
        '
        Me.btnUltimo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnUltimo.Image = Global.Presentacion.My.Resources.Resources._19
        Me.btnUltimo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnUltimo.Name = "btnUltimo"
        Me.btnUltimo.Size = New System.Drawing.Size(23, 24)
        '
        'btnActualizarTabla
        '
        Me.btnActualizarTabla.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnActualizarTabla.Image = Global.Presentacion.My.Resources.Resources._16__Refresh_
        Me.btnActualizarTabla.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnActualizarTabla.Name = "btnActualizarTabla"
        Me.btnActualizarTabla.Size = New System.Drawing.Size(23, 24)
        Me.btnActualizarTabla.Text = "Actualiza Tabla"
        '
        'btnBuscar
        '
        Me.btnBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnBuscar.Image = Global.Presentacion.My.Resources.Resources._250
        Me.btnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(23, 24)
        Me.btnBuscar.Text = "Buscar"
        '
        'DgvIngEgr
        '
        Me.DgvIngEgr.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvIngEgr.BackgroundColor = System.Drawing.Color.White
        Me.DgvIngEgr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DgvIngEgr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvIngEgr.Location = New System.Drawing.Point(1, 80)
        Me.DgvIngEgr.Name = "DgvIngEgr"
        Me.DgvIngEgr.Size = New System.Drawing.Size(523, 293)
        Me.DgvIngEgr.TabIndex = 94
        '
        'sst1
        '
        Me.sst1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblUsu, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel5, Me.lblRgs, Me.ToolStripStatusLabel7, Me.lblEmp, Me.ToolStripStatusLabel8, Me.lblPer})
        Me.sst1.Location = New System.Drawing.Point(0, 373)
        Me.sst1.Name = "sst1"
        Me.sst1.Size = New System.Drawing.Size(524, 22)
        Me.sst1.TabIndex = 95
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
        Me.lblUsu.Size = New System.Drawing.Size(36, 17)
        Me.lblUsu.Text = "Javier"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(12, 17)
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
        Me.ToolStripStatusLabel5.Size = New System.Drawing.Size(46, 17)
        Me.ToolStripStatusLabel5.Text = "Nº Rgs:"
        '
        'lblRgs
        '
        Me.lblRgs.Name = "lblRgs"
        Me.lblRgs.Size = New System.Drawing.Size(25, 17)
        Me.lblRgs.Text = "100"
        '
        'lblPer
        '
        Me.lblPer.Name = "lblPer"
        Me.lblPer.Size = New System.Drawing.Size(48, 17)
        Me.lblPer.Text = "Periodo"
        '
        'lblEmp
        '
        Me.lblEmp.Name = "lblEmp"
        Me.lblEmp.Size = New System.Drawing.Size(52, 17)
        Me.lblEmp.Text = "Empresa"
        '
        'ToolStripStatusLabel7
        '
        Me.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7"
        Me.ToolStripStatusLabel7.Size = New System.Drawing.Size(12, 17)
        Me.ToolStripStatusLabel7.Text = "-"
        '
        'ToolStripStatusLabel8
        '
        Me.ToolStripStatusLabel8.Name = "ToolStripStatusLabel8"
        Me.ToolStripStatusLabel8.Size = New System.Drawing.Size(12, 17)
        Me.ToolStripStatusLabel8.Text = "-"
        '
        'WIngresoEgreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(524, 395)
        Me.Controls.Add(Me.sst1)
        Me.Controls.Add(Me.DgvIngEgr)
        Me.Controls.Add(Me.tst2)
        Me.Controls.Add(Me.tst1)
        Me.MaximizeBox = False
        Me.Name = "WIngresoEgreso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingresos & Egresos"
        Me.tst1.ResumeLayout(False)
        Me.tst1.PerformLayout()
        Me.tst2.ResumeLayout(False)
        Me.tst2.PerformLayout()
        CType(Me.DgvIngEgr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sst1.ResumeLayout(False)
        Me.sst1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Function ListaBotones() As List(Of ListaTsb)
        Dim lis As New List(Of ListaTsb)

        Dim obj1 As New ListaTsb
        obj1.Tsb = Me.btnModificar
        obj1.GrillaVacia = "1"
        obj1.Desplaza = "0"
        obj1.indiceFila = -1
        lis.Add(obj1)

        Dim obj2 As New ListaTsb
        obj2.Tsb = Me.btnEliminar
        obj2.GrillaVacia = "1"
        obj2.Desplaza = "0"
        obj2.indiceFila = -1
        lis.Add(obj2)

        Dim obj3 As New ListaTsb
        obj3.Tsb = Me.btnImprimir
        obj3.GrillaVacia = "1"
        obj3.Desplaza = "0"
        obj3.indiceFila = -1
        lis.Add(obj3)

        Dim obj10 As New ListaTsb
        obj10.Tsb = Me.btnVisualizar
        obj10.GrillaVacia = "1"
        obj10.Desplaza = "0"
        obj10.indiceFila = -1
        lis.Add(obj10)

        Dim obj4 As New ListaTsb
        obj4.Tsb = Me.btnExportar
        obj4.GrillaVacia = "1"
        obj4.Desplaza = "0"
        obj4.indiceFila = -1
        lis.Add(obj4)

        Dim obj5 As New ListaTsb
        obj5.Tsb = Me.btnBuscar
        obj5.GrillaVacia = "1"
        obj5.Desplaza = "0"
        obj5.indiceFila = -1
        lis.Add(obj5)

        Dim obj6 As New ListaTsb
        obj6.Tsb = Me.btnPrimero
        obj6.GrillaVacia = "0"
        obj6.Desplaza = "1"
        obj6.indiceFila = 0
        lis.Add(obj6)

        Dim obj7 As New ListaTsb
        obj7.Tsb = Me.btnAnterior
        obj7.GrillaVacia = "0"
        obj7.Desplaza = "1"
        obj7.indiceFila = 0
        lis.Add(obj7)

        Dim int As Integer = Me.DgvIngEgr.Rows.Count - 1

        Dim obj8 As New ListaTsb
        obj8.Tsb = Me.btnSiguiente
        obj8.GrillaVacia = "0"
        obj8.Desplaza = "1"
        obj8.indiceFila = int
        lis.Add(obj8)

        Dim obj9 As New ListaTsb
        obj9.Tsb = Me.btnUltimo
        obj9.GrillaVacia = "0"
        obj9.Desplaza = "1"
        obj9.indiceFila = int
        lis.Add(obj9)

        Return lis

    End Function

    Friend WithEvents tst1 As System.Windows.Forms.ToolStrip
    Public WithEvents btnAdicionar As System.Windows.Forms.ToolStripButton
    Public WithEvents btnModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnVisualizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnExportar As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRegresar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tst2 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnPrimero As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnAnterior As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSiguiente As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnUltimo As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnActualizarTabla As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents DgvIngEgr As System.Windows.Forms.DataGridView
    Friend WithEvents sst1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblUsu As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblRgs As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel7 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblEmp As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel8 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblPer As System.Windows.Forms.ToolStripStatusLabel
End Class
