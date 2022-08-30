<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WRptTab
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
        Me.crvDis = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'crvDis
        '
        Me.crvDis.ActiveViewIndex = -1
        Me.crvDis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvDis.DisplayGroupTree = False
        Me.crvDis.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvDis.Location = New System.Drawing.Point(0, 0)
        Me.crvDis.Name = "crvDis"
        Me.crvDis.SelectionFormula = ""
        Me.crvDis.Size = New System.Drawing.Size(814, 203)
        Me.crvDis.TabIndex = 2
        Me.crvDis.ViewTimeSelectionFormula = ""
        '
        'WRptTab
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 203)
        Me.Controls.Add(Me.crvDis)
        Me.Name = "WRptTab"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WImpDis"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crvDis As CrystalDecisions.Windows.Forms.CrystalReportViewer
    '  Friend WithEvents crInfDis1 As Presentacion.crInfDis
    '  Friend WithEvents crInfDis2 As Presentacion.crInfDis
End Class
