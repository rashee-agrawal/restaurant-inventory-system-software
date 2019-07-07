<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class printbill
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.billtblBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.startermenuDataSet = New restaurant_software_project.startermenuDataSet()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.billtblTableAdapter = New restaurant_software_project.startermenuDataSetTableAdapters.billtblTableAdapter()
        Me.startermenuDataSet1 = New restaurant_software_project.startermenuDataSet1()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.billtblBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.startermenuDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.startermenuDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'billtblBindingSource
        '
        Me.billtblBindingSource.DataMember = "billtbl"
        Me.billtblBindingSource.DataSource = Me.startermenuDataSet
        '
        'startermenuDataSet
        '
        Me.startermenuDataSet.DataSetName = "startermenuDataSet"
        Me.startermenuDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource2.Name = "DataSet1"
        ReportDataSource2.Value = Me.billtblBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "restaurant_software_project.Report2.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(633, 463)
        Me.ReportViewer1.TabIndex = 0
        '
        'billtblTableAdapter
        '
        Me.billtblTableAdapter.ClearBeforeFill = True
        '
        'startermenuDataSet1
        '
        Me.startermenuDataSet1.DataSetName = "startermenuDataSet1"
        Me.startermenuDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(0, 433)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 30)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "<<<"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'printbill
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(633, 463)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "printbill"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "printbill"
        CType(Me.billtblBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.startermenuDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.startermenuDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents billtblBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents startermenuDataSet As restaurant_software_project.startermenuDataSet
    Friend WithEvents billtblTableAdapter As restaurant_software_project.startermenuDataSetTableAdapters.billtblTableAdapter
    Friend WithEvents startermenuDataSet1 As restaurant_software_project.startermenuDataSet1
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
