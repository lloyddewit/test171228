﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class dlgClimaticStationMaps
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.cmdPlotOptions = New System.Windows.Forms.Button()
        Me.cmdMapOptions = New System.Windows.Forms.Button()
        Me.cmdSFOptions = New System.Windows.Forms.Button()
        Me.ucrSaveMap = New instat.ucrSave()
        Me.ucrBase = New instat.ucrButtons()
        Me.grpStation = New System.Windows.Forms.GroupBox()
        Me.lblStation = New System.Windows.Forms.Label()
        Me.ucrReceiverStation = New instat.ucrReceiverSingle()
        Me.lblFacet = New System.Windows.Forms.Label()
        Me.ucrReceiverFacet = New instat.ucrReceiverSingle()
        Me.ucrSelectorStation = New instat.ucrSelectorByDataFrameAddRemove()
        Me.lblColor = New System.Windows.Forms.Label()
        Me.lblShape = New System.Windows.Forms.Label()
        Me.lbllatitude = New System.Windows.Forms.Label()
        Me.ucrReceiverColor = New instat.ucrReceiverSingle()
        Me.lblLongitude = New System.Windows.Forms.Label()
        Me.ucrReceiverShape = New instat.ucrReceiverSingle()
        Me.ucrReceiverLatitude = New instat.ucrReceiverSingle()
        Me.ucrReceiverLongitude = New instat.ucrReceiverSingle()
        Me.grpMapOutline = New System.Windows.Forms.GroupBox()
        Me.lblFill = New System.Windows.Forms.Label()
        Me.ucrReceiverFill = New instat.ucrReceiverSingle()
        Me.ucrSelectorOutline = New instat.ucrSelectorByDataFrameAddRemove()
        Me.grpStation.SuspendLayout()
        Me.grpMapOutline.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdPlotOptions
        '
        Me.cmdPlotOptions.Location = New System.Drawing.Point(10, 263)
        Me.cmdPlotOptions.Name = "cmdPlotOptions"
        Me.cmdPlotOptions.Size = New System.Drawing.Size(103, 23)
        Me.cmdPlotOptions.TabIndex = 12
        Me.cmdPlotOptions.Text = "Plot Options"
        Me.cmdPlotOptions.UseVisualStyleBackColor = True
        '
        'cmdMapOptions
        '
        Me.cmdMapOptions.Location = New System.Drawing.Point(10, 322)
        Me.cmdMapOptions.Name = "cmdMapOptions"
        Me.cmdMapOptions.Size = New System.Drawing.Size(103, 23)
        Me.cmdMapOptions.TabIndex = 14
        Me.cmdMapOptions.Text = "Map Options"
        Me.cmdMapOptions.UseVisualStyleBackColor = True
        '
        'cmdSFOptions
        '
        Me.cmdSFOptions.Enabled = False
        Me.cmdSFOptions.Location = New System.Drawing.Point(10, 293)
        Me.cmdSFOptions.Name = "cmdSFOptions"
        Me.cmdSFOptions.Size = New System.Drawing.Size(103, 23)
        Me.cmdSFOptions.TabIndex = 13
        Me.cmdSFOptions.Text = "SF Options"
        Me.cmdSFOptions.UseVisualStyleBackColor = True
        '
        'ucrSaveMap
        '
        Me.ucrSaveMap.Location = New System.Drawing.Point(8, 356)
        Me.ucrSaveMap.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.ucrSaveMap.Name = "ucrSaveMap"
        Me.ucrSaveMap.Size = New System.Drawing.Size(244, 24)
        Me.ucrSaveMap.TabIndex = 15
        '
        'ucrBase
        '
        Me.ucrBase.Location = New System.Drawing.Point(8, 387)
        Me.ucrBase.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ucrBase.Name = "ucrBase"
        Me.ucrBase.Size = New System.Drawing.Size(410, 52)
        Me.ucrBase.TabIndex = 16
        '
        'grpStation
        '
        Me.grpStation.Controls.Add(Me.lblStation)
        Me.grpStation.Controls.Add(Me.ucrReceiverStation)
        Me.grpStation.Controls.Add(Me.lblFacet)
        Me.grpStation.Controls.Add(Me.ucrReceiverFacet)
        Me.grpStation.Controls.Add(Me.ucrSelectorStation)
        Me.grpStation.Controls.Add(Me.lblColor)
        Me.grpStation.Controls.Add(Me.lblShape)
        Me.grpStation.Controls.Add(Me.lbllatitude)
        Me.grpStation.Controls.Add(Me.ucrReceiverColor)
        Me.grpStation.Controls.Add(Me.lblLongitude)
        Me.grpStation.Controls.Add(Me.ucrReceiverShape)
        Me.grpStation.Controls.Add(Me.ucrReceiverLatitude)
        Me.grpStation.Controls.Add(Me.ucrReceiverLongitude)
        Me.grpStation.Location = New System.Drawing.Point(373, 8)
        Me.grpStation.Name = "grpStation"
        Me.grpStation.Size = New System.Drawing.Size(371, 292)
        Me.grpStation.TabIndex = 21
        Me.grpStation.TabStop = False
        Me.grpStation.Text = "Station"
        '
        'lblStation
        '
        Me.lblStation.AutoSize = True
        Me.lblStation.Location = New System.Drawing.Point(243, 17)
        Me.lblStation.Name = "lblStation"
        Me.lblStation.Size = New System.Drawing.Size(43, 13)
        Me.lblStation.TabIndex = 33
        Me.lblStation.Text = "Station "
        '
        'ucrReceiverStation
        '
        Me.ucrReceiverStation.frmParent = Me
        Me.ucrReceiverStation.Location = New System.Drawing.Point(240, 37)
        Me.ucrReceiverStation.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverStation.Name = "ucrReceiverStation"
        Me.ucrReceiverStation.Selector = Nothing
        Me.ucrReceiverStation.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverStation.strNcFilePath = ""
        Me.ucrReceiverStation.TabIndex = 32
        Me.ucrReceiverStation.ucrSelector = Nothing
        '
        'lblFacet
        '
        Me.lblFacet.AutoSize = True
        Me.lblFacet.Location = New System.Drawing.Point(240, 235)
        Me.lblFacet.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblFacet.Name = "lblFacet"
        Me.lblFacet.Size = New System.Drawing.Size(39, 13)
        Me.lblFacet.TabIndex = 31
        Me.lblFacet.Text = "Facets"
        '
        'ucrReceiverFacet
        '
        Me.ucrReceiverFacet.frmParent = Me
        Me.ucrReceiverFacet.Location = New System.Drawing.Point(241, 256)
        Me.ucrReceiverFacet.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverFacet.Name = "ucrReceiverFacet"
        Me.ucrReceiverFacet.Selector = Nothing
        Me.ucrReceiverFacet.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverFacet.strNcFilePath = ""
        Me.ucrReceiverFacet.TabIndex = 30
        Me.ucrReceiverFacet.ucrSelector = Nothing
        '
        'ucrSelectorStation
        '
        Me.ucrSelectorStation.bDropUnusedFilterLevels = False
        Me.ucrSelectorStation.bShowHiddenColumns = False
        Me.ucrSelectorStation.bUseCurrentFilter = True
        Me.ucrSelectorStation.Location = New System.Drawing.Point(8, 16)
        Me.ucrSelectorStation.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrSelectorStation.Name = "ucrSelectorStation"
        Me.ucrSelectorStation.Size = New System.Drawing.Size(210, 180)
        Me.ucrSelectorStation.TabIndex = 21
        '
        'lblColor
        '
        Me.lblColor.AutoSize = True
        Me.lblColor.Location = New System.Drawing.Point(238, 190)
        Me.lblColor.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblColor.Name = "lblColor"
        Me.lblColor.Size = New System.Drawing.Size(79, 13)
        Me.lblColor.TabIndex = 28
        Me.lblColor.Text = "Color(Optional):"
        '
        'lblShape
        '
        Me.lblShape.AutoSize = True
        Me.lblShape.Location = New System.Drawing.Point(237, 147)
        Me.lblShape.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblShape.Name = "lblShape"
        Me.lblShape.Size = New System.Drawing.Size(86, 13)
        Me.lblShape.TabIndex = 26
        Me.lblShape.Text = "Shape(Optional):"
        '
        'lbllatitude
        '
        Me.lbllatitude.AutoSize = True
        Me.lbllatitude.Location = New System.Drawing.Point(237, 108)
        Me.lbllatitude.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbllatitude.Name = "lbllatitude"
        Me.lbllatitude.Size = New System.Drawing.Size(48, 13)
        Me.lbllatitude.TabIndex = 24
        Me.lbllatitude.Text = "Latitude:"
        '
        'ucrReceiverColor
        '
        Me.ucrReceiverColor.frmParent = Me
        Me.ucrReceiverColor.Location = New System.Drawing.Point(240, 209)
        Me.ucrReceiverColor.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverColor.Name = "ucrReceiverColor"
        Me.ucrReceiverColor.Selector = Nothing
        Me.ucrReceiverColor.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverColor.strNcFilePath = ""
        Me.ucrReceiverColor.TabIndex = 29
        Me.ucrReceiverColor.ucrSelector = Nothing
        '
        'lblLongitude
        '
        Me.lblLongitude.AutoSize = True
        Me.lblLongitude.Location = New System.Drawing.Point(240, 65)
        Me.lblLongitude.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblLongitude.Name = "lblLongitude"
        Me.lblLongitude.Size = New System.Drawing.Size(57, 13)
        Me.lblLongitude.TabIndex = 22
        Me.lblLongitude.Text = "Longitude:"
        '
        'ucrReceiverShape
        '
        Me.ucrReceiverShape.frmParent = Me
        Me.ucrReceiverShape.Location = New System.Drawing.Point(240, 165)
        Me.ucrReceiverShape.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverShape.Name = "ucrReceiverShape"
        Me.ucrReceiverShape.Selector = Nothing
        Me.ucrReceiverShape.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverShape.strNcFilePath = ""
        Me.ucrReceiverShape.TabIndex = 27
        Me.ucrReceiverShape.ucrSelector = Nothing
        '
        'ucrReceiverLatitude
        '
        Me.ucrReceiverLatitude.frmParent = Me
        Me.ucrReceiverLatitude.Location = New System.Drawing.Point(240, 125)
        Me.ucrReceiverLatitude.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverLatitude.Name = "ucrReceiverLatitude"
        Me.ucrReceiverLatitude.Selector = Nothing
        Me.ucrReceiverLatitude.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverLatitude.strNcFilePath = ""
        Me.ucrReceiverLatitude.TabIndex = 25
        Me.ucrReceiverLatitude.ucrSelector = Nothing
        '
        'ucrReceiverLongitude
        '
        Me.ucrReceiverLongitude.frmParent = Me
        Me.ucrReceiverLongitude.Location = New System.Drawing.Point(240, 84)
        Me.ucrReceiverLongitude.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverLongitude.Name = "ucrReceiverLongitude"
        Me.ucrReceiverLongitude.Selector = Nothing
        Me.ucrReceiverLongitude.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverLongitude.strNcFilePath = ""
        Me.ucrReceiverLongitude.TabIndex = 23
        Me.ucrReceiverLongitude.ucrSelector = Nothing
        '
        'grpMapOutline
        '
        Me.grpMapOutline.Controls.Add(Me.lblFill)
        Me.grpMapOutline.Controls.Add(Me.ucrReceiverFill)
        Me.grpMapOutline.Controls.Add(Me.ucrSelectorOutline)
        Me.grpMapOutline.Location = New System.Drawing.Point(10, 12)
        Me.grpMapOutline.Name = "grpMapOutline"
        Me.grpMapOutline.Size = New System.Drawing.Size(357, 245)
        Me.grpMapOutline.TabIndex = 22
        Me.grpMapOutline.TabStop = False
        Me.grpMapOutline.Text = "Map Outline"
        '
        'lblFill
        '
        Me.lblFill.AutoSize = True
        Me.lblFill.Location = New System.Drawing.Point(231, 7)
        Me.lblFill.Name = "lblFill"
        Me.lblFill.Size = New System.Drawing.Size(22, 13)
        Me.lblFill.TabIndex = 4
        Me.lblFill.Text = "Fill:"
        '
        'ucrReceiverFill
        '
        Me.ucrReceiverFill.frmParent = Me
        Me.ucrReceiverFill.Location = New System.Drawing.Point(231, 25)
        Me.ucrReceiverFill.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrReceiverFill.Name = "ucrReceiverFill"
        Me.ucrReceiverFill.Selector = Nothing
        Me.ucrReceiverFill.Size = New System.Drawing.Size(120, 20)
        Me.ucrReceiverFill.strNcFilePath = ""
        Me.ucrReceiverFill.TabIndex = 5
        Me.ucrReceiverFill.ucrSelector = Nothing
        '
        'ucrSelectorOutline
        '
        Me.ucrSelectorOutline.bDropUnusedFilterLevels = False
        Me.ucrSelectorOutline.bShowHiddenColumns = False
        Me.ucrSelectorOutline.bUseCurrentFilter = True
        Me.ucrSelectorOutline.Location = New System.Drawing.Point(4, 15)
        Me.ucrSelectorOutline.Margin = New System.Windows.Forms.Padding(0)
        Me.ucrSelectorOutline.Name = "ucrSelectorOutline"
        Me.ucrSelectorOutline.Size = New System.Drawing.Size(220, 189)
        Me.ucrSelectorOutline.TabIndex = 3
        '
        'dlgClimaticStationMaps
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(756, 456)
        Me.Controls.Add(Me.grpMapOutline)
        Me.Controls.Add(Me.grpStation)
        Me.Controls.Add(Me.cmdSFOptions)
        Me.Controls.Add(Me.cmdMapOptions)
        Me.Controls.Add(Me.cmdPlotOptions)
        Me.Controls.Add(Me.ucrSaveMap)
        Me.Controls.Add(Me.ucrBase)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "dlgClimaticStationMaps"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Climatic Maps"
        Me.grpStation.ResumeLayout(False)
        Me.grpStation.PerformLayout()
        Me.grpMapOutline.ResumeLayout(False)
        Me.grpMapOutline.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ucrBase As ucrButtons
    Friend WithEvents cmdPlotOptions As Button
    Friend WithEvents ucrSaveMap As ucrSave
    Friend WithEvents cmdSFOptions As Button
    Friend WithEvents cmdMapOptions As Button
    Friend WithEvents grpStation As GroupBox
    Friend WithEvents lblStation As Label
    Friend WithEvents ucrReceiverStation As ucrReceiverSingle
    Friend WithEvents grpMapOutline As GroupBox
    Friend WithEvents lblFill As Label
    Friend WithEvents ucrReceiverFill As ucrReceiverSingle
    Friend WithEvents ucrSelectorOutline As ucrSelectorByDataFrameAddRemove
    Friend WithEvents lblFacet As Label
    Friend WithEvents ucrReceiverFacet As ucrReceiverSingle
    Friend WithEvents ucrSelectorStation As ucrSelectorByDataFrameAddRemove
    Friend WithEvents lblColor As Label
    Friend WithEvents lblShape As Label
    Friend WithEvents lbllatitude As Label
    Friend WithEvents ucrReceiverColor As ucrReceiverSingle
    Friend WithEvents lblLongitude As Label
    Friend WithEvents ucrReceiverShape As ucrReceiverSingle
    Friend WithEvents ucrReceiverLatitude As ucrReceiverSingle
    Friend WithEvents ucrReceiverLongitude As ucrReceiverSingle
End Class
