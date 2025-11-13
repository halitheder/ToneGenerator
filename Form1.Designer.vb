<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.btnPlay = New System.Windows.Forms.Button
        Me.numFrequency = New System.Windows.Forms.NumericUpDown
        Me.numDuration = New System.Windows.Forms.NumericUpDown
        Me.trackVolume = New System.Windows.Forms.TrackBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        CType(Me.numFrequency, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDuration, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trackVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPlay
        '
        Me.btnPlay.Location = New System.Drawing.Point(511, 394)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(75, 23)
        Me.btnPlay.TabIndex = 0
        Me.btnPlay.Text = "Play"
        Me.btnPlay.UseVisualStyleBackColor = True
        '
        'numFrequency
        '
        Me.numFrequency.Location = New System.Drawing.Point(90, 12)
        Me.numFrequency.Maximum = New Decimal(New Integer() {20000, 0, 0, 0})
        Me.numFrequency.Minimum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.numFrequency.Name = "numFrequency"
        Me.numFrequency.Size = New System.Drawing.Size(98, 20)
        Me.numFrequency.TabIndex = 1
        Me.numFrequency.Value = New Decimal(New Integer() {440, 0, 0, 0})
        '
        'numDuration
        '
        Me.numDuration.Location = New System.Drawing.Point(90, 56)
        Me.numDuration.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.numDuration.Minimum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numDuration.Name = "numDuration"
        Me.numDuration.Size = New System.Drawing.Size(98, 20)
        Me.numDuration.TabIndex = 1
        Me.numDuration.Value = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'trackVolume
        '
        Me.trackVolume.Location = New System.Drawing.Point(316, 19)
        Me.trackVolume.Maximum = 100
        Me.trackVolume.Name = "trackVolume"
        Me.trackVolume.Size = New System.Drawing.Size(270, 45)
        Me.trackVolume.TabIndex = 2
        Me.trackVolume.Value = 80
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Frequency"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Duration"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(241, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Volume"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(609, 429)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.trackVolume)
        Me.Controls.Add(Me.numDuration)
        Me.Controls.Add(Me.numFrequency)
        Me.Controls.Add(Me.btnPlay)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.numFrequency, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDuration, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trackVolume, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPlay As System.Windows.Forms.Button
    Friend WithEvents numFrequency As System.Windows.Forms.NumericUpDown
    Friend WithEvents numDuration As System.Windows.Forms.NumericUpDown
    Friend WithEvents trackVolume As System.Windows.Forms.TrackBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
