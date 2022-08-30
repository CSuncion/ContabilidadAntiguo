<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WRptTipCam
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
        Me.crvPer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'crvPer
        '
        Me.crvPer.ActiveViewIndex = -1
        Me.crvPer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvPer.DisplayGroupTree = False
        Me.crvPer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvPer.Location = New System.Drawing.Point(0, 0)
        Me.crvPer.Name = "crvPer"
        Me.crvPer.SelectionFormula = ""
        Me.crvPer.Size = New System.Drawing.Size(292, 266)
        Me.crvPer.TabIndex = 1
        Me.crvPer.ViewTimeSelectionFormula = ""
        '
        'WRptTipCam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.crvPer)
        Me.Name = "WRptTipCam"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WRptTipCam"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crvPer As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
