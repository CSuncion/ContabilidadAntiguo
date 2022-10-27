<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WRepCbco
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
        Me.crvAux = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'crvAux
        '
        Me.crvAux.ActiveViewIndex = -1
        Me.crvAux.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvAux.DisplayGroupTree = False
        Me.crvAux.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvAux.Location = New System.Drawing.Point(0, 0)
        Me.crvAux.Name = "crvAux"
        Me.crvAux.SelectionFormula = ""
        Me.crvAux.Size = New System.Drawing.Size(906, 266)
        Me.crvAux.TabIndex = 2
        Me.crvAux.ViewTimeSelectionFormula = ""
        '
        'WRepCbco
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(906, 266)
        Me.Controls.Add(Me.crvAux)
        Me.Name = "WRepCbco"
        Me.Text = "WRepCbco"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crvAux As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
