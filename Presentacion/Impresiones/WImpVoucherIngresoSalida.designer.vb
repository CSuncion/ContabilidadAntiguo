<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WImpVoucherIngresoSalida
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnIngreso = New System.Windows.Forms.Button
        Me.btnSalida = New System.Windows.Forms.Button
        Me.crv2 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.CrRptVoucher1 = New Presentacion.CrRptVoucher
        Me.CrRptVoucher2 = New Presentacion.CrRptVoucher
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'crv1
        '
        Me.crv1.ActiveViewIndex = 0
        Me.crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crv1.DisplayGroupTree = False
        Me.crv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crv1.Location = New System.Drawing.Point(0, 0)
        Me.crv1.Name = "crv1"
        Me.crv1.ReportSource = Me.CrRptVoucher1
        Me.crv1.Size = New System.Drawing.Size(810, 279)
        Me.crv1.TabIndex = 11
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.crv2)
        Me.Panel1.Controls.Add(Me.crv1)
        Me.Panel1.Location = New System.Drawing.Point(1, 44)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(810, 279)
        Me.Panel1.TabIndex = 12
        '
        'btnIngreso
        '
        Me.btnIngreso.Location = New System.Drawing.Point(143, 12)
        Me.btnIngreso.Name = "btnIngreso"
        Me.btnIngreso.Size = New System.Drawing.Size(125, 23)
        Me.btnIngreso.TabIndex = 13
        Me.btnIngreso.Text = "Voucher Ingreso"
        Me.btnIngreso.UseVisualStyleBackColor = True
        '
        'btnSalida
        '
        Me.btnSalida.Location = New System.Drawing.Point(12, 12)
        Me.btnSalida.Name = "btnSalida"
        Me.btnSalida.Size = New System.Drawing.Size(125, 23)
        Me.btnSalida.TabIndex = 14
        Me.btnSalida.Text = "Voucher Salida"
        Me.btnSalida.UseVisualStyleBackColor = True
        '
        'crv2
        '
        Me.crv2.ActiveViewIndex = 0
        Me.crv2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crv2.DisplayGroupTree = False
        Me.crv2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crv2.Location = New System.Drawing.Point(0, 0)
        Me.crv2.Name = "crv2"
        Me.crv2.ReportSource = Me.CrRptVoucher2
        Me.crv2.Size = New System.Drawing.Size(810, 279)
        Me.crv2.TabIndex = 12
        '
        'WImpVoucherIngresoSalida
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(810, 324)
        Me.Controls.Add(Me.btnSalida)
        Me.Controls.Add(Me.btnIngreso)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "WImpVoucherIngresoSalida"
        Me.Text = "Formato Contable"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub


    Friend WithEvents crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnIngreso As System.Windows.Forms.Button
    Friend WithEvents btnSalida As System.Windows.Forms.Button
    Friend WithEvents crv2 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents CrRptVoucher1 As Presentacion.CrRptVoucher
    Friend WithEvents CrRptVoucher2 As Presentacion.CrRptVoucher


End Class
