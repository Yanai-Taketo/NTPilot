Imports System.Drawing
Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits Form

    Private components As System.ComponentModel.IContainer

    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    ' ---- Shell
    Private pnlTabStrip As Panel
    Private pnlInfoBar As Panel
    Private lblInfoStatus As Label
    Private lblInfoDetails As Label
    Private WithEvents cboLanguage As ComboBox
    Private pnlContent As Panel
    Private stsMain As StatusStrip
    Private tsslStatus As ToolStripStatusLabel

    ' ---- Pages
    Private pageStatus As Panel
    Private pageClient As Panel
    Private pageServer As Panel
    Private pageAdvanced As Panel
    Private pageConfigView As Panel

    ' ---- Status page
    Private cardService As GroupBox
    Private tblService As TableLayoutPanel
    Private lblServiceStatusLbl As Label
    Private lblServiceStatusVal As Label
    Private flpServiceBtns As FlowLayoutPanel
    Private WithEvents btnStart As Button
    Private WithEvents btnStop As Button
    Private WithEvents btnRestart As Button
    Private cardNtpStatus As GroupBox
    Private tblNtpStatus As TableLayoutPanel
    Private dgvStatus As DataGridView
    Private flpStatusBtns As FlowLayoutPanel
    Private WithEvents btnSyncNow As Button
    Private WithEvents btnRefreshStatus As Button
    Private cardPeers As GroupBox
    Private tblPeers As TableLayoutPanel
    Private dgvPeers As DataGridView

    ' ---- Client page
    Private cardClientBasic As GroupBox
    Private tblClientBasic As TableLayoutPanel
    Private chkClientEnabled As CheckBox
    Private lblSyncType As Label
    Private cboSyncType As ComboBox
    Private lblNtpServers As Label
    Private txtNtpServers As TextBox
    Private cardFlags As GroupBox
    Private tblFlags As TableLayoutPanel
    Private WithEvents chkFlag8 As CheckBox
    Private WithEvents chkFlag4 As CheckBox
    Private WithEvents chkFlag1 As CheckBox
    Private lblCombinedFlagLbl As Label
    Private lblCombinedFlagVal As Label
    Private cardPolling As GroupBox
    Private tblPolling As TableLayoutPanel
    Private lblUpdateInterval As Label
    Private nudUpdateInterval As NumericUpDown
    Private lblMinPoll As Label
    Private nudMinPoll As NumericUpDown
    Private lblMaxPoll As Label
    Private nudMaxPoll As NumericUpDown
    Private cardCrossSite As GroupBox
    Private tblCrossSite As TableLayoutPanel
    Private chkCrossSiteSync As CheckBox
    Private lblBackOffMin As Label
    Private nudBackOffMin As NumericUpDown
    Private lblBackOffMax As Label
    Private nudBackOffMax As NumericUpDown
    Private flpClientBtns As FlowLayoutPanel
    Private WithEvents btnApplyClient As Button
    Private WithEvents btnResetClient As Button

    ' ---- Server page
    Private cardServerBasic As GroupBox
    Private tblServerBasic As TableLayoutPanel
    Private chkServerEnabled As CheckBox
    Private lblAnnounceFlags As Label
    Private cboAnnounceFlags As ComboBox
    Private chkSecureOnly As CheckBox
    Private cardPhase As GroupBox
    Private tblPhase As TableLayoutPanel
    Private lblMaxPosPhase As Label
    Private nudMaxPosPhase As NumericUpDown
    Private lblMaxNegPhase As Label
    Private nudMaxNegPhase As NumericUpDown
    Private lblMaxPhaseOffset As Label
    Private nudMaxPhaseOffset As NumericUpDown
    Private cardChain As GroupBox
    Private tblChain As TableLayoutPanel
    Private lblChainEntryTimeout As Label
    Private nudChainEntryTimeout As NumericUpDown
    Private flpServerBtns As FlowLayoutPanel
    Private WithEvents btnApplyServer As Button
    Private WithEvents btnResetServer As Button

    ' ---- Advanced page
    Private cardTimeCorrection As GroupBox
    Private tblTimeCorr As TableLayoutPanel
    Private lblAdvUpdateInterval As Label
    Private nudAdvUpdateInterval As NumericUpDown
    Private lblFreqCorrectRate As Label
    Private nudFreqCorrectRate As NumericUpDown
    Private lblPhaseCorrectRate As Label
    Private nudPhaseCorrectRate As NumericUpDown
    Private lblClockHoldover As Label
    Private nudClockHoldover As NumericUpDown
    Private cardSpike As GroupBox
    Private tblSpike As TableLayoutPanel
    Private lblLargePhaseOffset As Label
    Private nudLargePhaseOffset As NumericUpDown
    Private lblSpikeWatchPeriod As Label
    Private nudSpikeWatchPeriod As NumericUpDown
    Private lblHoldPeriod As Label
    Private nudHoldPeriod As NumericUpDown
    Private cardMisc As GroupBox
    Private tblMisc As TableLayoutPanel
    Private lblLocalClockDisp As Label
    Private nudLocalClockDisp As NumericUpDown
    Private lblAuditLimit As Label
    Private nudAuditLimit As NumericUpDown
    Private cardLogging As GroupBox
    Private tblLogging As TableLayoutPanel
    Private lblFileLogName As Label
    Private txtFileLogName As TextBox
    Private WithEvents btnBrowseLog As Button
    Private lblFileLogEntries As Label
    Private nudFileLogEntries As NumericUpDown
    Private lblFileLogSize As Label
    Private nudFileLogSize As NumericUpDown
    Private flpAdvancedBtns As FlowLayoutPanel
    Private WithEvents btnApplyAdvanced As Button
    Private WithEvents btnResetAdvanced As Button

    ' ---- Advanced page helpers
    Private pnlLogPath As Panel

    ' ---- Config View page
    Private cardConfigRaw As GroupBox
    Private tblConfigRaw As TableLayoutPanel
    Private rtbConfigView As RichTextBox
    Private flpConfigBtns As FlowLayoutPanel
    Private WithEvents btnRefreshConfig As Button

    ' ---- Tooltips
    Private tipMain As System.Windows.Forms.ToolTip

    ' ================================================================
    ' InitializeComponent – flat, designer-compatible
    ' Dock=Top rule: LAST added = topmost. Add bottom→top.
    ' ================================================================

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.tipMain = New System.Windows.Forms.ToolTip(Me.components)
        Me.stsMain = New System.Windows.Forms.StatusStrip()
        Me.tsslStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.pageStatus = New System.Windows.Forms.Panel()
        Me.cardPeers = New System.Windows.Forms.GroupBox()
        Me.tblPeers = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvPeers = New System.Windows.Forms.DataGridView()
        Me.PeerServer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PeerState = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PeerStratum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PeerOffset = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PeerRootDelay = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PeerRootDisp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cardNtpStatus = New System.Windows.Forms.GroupBox()
        Me.tblNtpStatus = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvStatus = New System.Windows.Forms.DataGridView()
        Me.Key = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Value = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.flpStatusBtns = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnSyncNow = New System.Windows.Forms.Button()
        Me.btnRefreshStatus = New System.Windows.Forms.Button()
        Me.cardService = New System.Windows.Forms.GroupBox()
        Me.tblService = New System.Windows.Forms.TableLayoutPanel()
        Me.lblServiceStatusLbl = New System.Windows.Forms.Label()
        Me.lblServiceStatusVal = New System.Windows.Forms.Label()
        Me.flpServiceBtns = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnRestart = New System.Windows.Forms.Button()
        Me.pageClient = New System.Windows.Forms.Panel()
        Me.flpClientBtns = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnApplyClient = New System.Windows.Forms.Button()
        Me.btnResetClient = New System.Windows.Forms.Button()
        Me.cardCrossSite = New System.Windows.Forms.GroupBox()
        Me.tblCrossSite = New System.Windows.Forms.TableLayoutPanel()
        Me.chkCrossSiteSync = New System.Windows.Forms.CheckBox()
        Me.lblBackOffMin = New System.Windows.Forms.Label()
        Me.nudBackOffMin = New System.Windows.Forms.NumericUpDown()
        Me.lblBackOffMax = New System.Windows.Forms.Label()
        Me.nudBackOffMax = New System.Windows.Forms.NumericUpDown()
        Me.cardPolling = New System.Windows.Forms.GroupBox()
        Me.tblPolling = New System.Windows.Forms.TableLayoutPanel()
        Me.lblUpdateInterval = New System.Windows.Forms.Label()
        Me.nudUpdateInterval = New System.Windows.Forms.NumericUpDown()
        Me.lblMinPoll = New System.Windows.Forms.Label()
        Me.nudMinPoll = New System.Windows.Forms.NumericUpDown()
        Me.lblMaxPoll = New System.Windows.Forms.Label()
        Me.nudMaxPoll = New System.Windows.Forms.NumericUpDown()
        Me.cardFlags = New System.Windows.Forms.GroupBox()
        Me.tblFlags = New System.Windows.Forms.TableLayoutPanel()
        Me.chkFlag8 = New System.Windows.Forms.CheckBox()
        Me.chkFlag4 = New System.Windows.Forms.CheckBox()
        Me.chkFlag1 = New System.Windows.Forms.CheckBox()
        Me.lblCombinedFlagLbl = New System.Windows.Forms.Label()
        Me.lblCombinedFlagVal = New System.Windows.Forms.Label()
        Me.cardClientBasic = New System.Windows.Forms.GroupBox()
        Me.tblClientBasic = New System.Windows.Forms.TableLayoutPanel()
        Me.chkClientEnabled = New System.Windows.Forms.CheckBox()
        Me.lblSyncType = New System.Windows.Forms.Label()
        Me.cboSyncType = New System.Windows.Forms.ComboBox()
        Me.lblNtpServers = New System.Windows.Forms.Label()
        Me.txtNtpServers = New System.Windows.Forms.TextBox()
        Me.pageServer = New System.Windows.Forms.Panel()
        Me.flpServerBtns = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnApplyServer = New System.Windows.Forms.Button()
        Me.btnResetServer = New System.Windows.Forms.Button()
        Me.cardChain = New System.Windows.Forms.GroupBox()
        Me.tblChain = New System.Windows.Forms.TableLayoutPanel()
        Me.lblChainEntryTimeout = New System.Windows.Forms.Label()
        Me.nudChainEntryTimeout = New System.Windows.Forms.NumericUpDown()
        Me.cardPhase = New System.Windows.Forms.GroupBox()
        Me.tblPhase = New System.Windows.Forms.TableLayoutPanel()
        Me.lblMaxPosPhase = New System.Windows.Forms.Label()
        Me.nudMaxPosPhase = New System.Windows.Forms.NumericUpDown()
        Me.lblMaxNegPhase = New System.Windows.Forms.Label()
        Me.nudMaxNegPhase = New System.Windows.Forms.NumericUpDown()
        Me.lblMaxPhaseOffset = New System.Windows.Forms.Label()
        Me.nudMaxPhaseOffset = New System.Windows.Forms.NumericUpDown()
        Me.cardServerBasic = New System.Windows.Forms.GroupBox()
        Me.tblServerBasic = New System.Windows.Forms.TableLayoutPanel()
        Me.chkServerEnabled = New System.Windows.Forms.CheckBox()
        Me.lblAnnounceFlags = New System.Windows.Forms.Label()
        Me.cboAnnounceFlags = New System.Windows.Forms.ComboBox()
        Me.chkSecureOnly = New System.Windows.Forms.CheckBox()
        Me.pageAdvanced = New System.Windows.Forms.Panel()
        Me.flpAdvancedBtns = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnApplyAdvanced = New System.Windows.Forms.Button()
        Me.btnResetAdvanced = New System.Windows.Forms.Button()
        Me.cardLogging = New System.Windows.Forms.GroupBox()
        Me.tblLogging = New System.Windows.Forms.TableLayoutPanel()
        Me.lblFileLogName = New System.Windows.Forms.Label()
        Me.pnlLogPath = New System.Windows.Forms.Panel()
        Me.txtFileLogName = New System.Windows.Forms.TextBox()
        Me.btnBrowseLog = New System.Windows.Forms.Button()
        Me.lblFileLogEntries = New System.Windows.Forms.Label()
        Me.nudFileLogEntries = New System.Windows.Forms.NumericUpDown()
        Me.lblFileLogSize = New System.Windows.Forms.Label()
        Me.nudFileLogSize = New System.Windows.Forms.NumericUpDown()
        Me.cardMisc = New System.Windows.Forms.GroupBox()
        Me.tblMisc = New System.Windows.Forms.TableLayoutPanel()
        Me.lblLocalClockDisp = New System.Windows.Forms.Label()
        Me.nudLocalClockDisp = New System.Windows.Forms.NumericUpDown()
        Me.lblAuditLimit = New System.Windows.Forms.Label()
        Me.nudAuditLimit = New System.Windows.Forms.NumericUpDown()
        Me.cardSpike = New System.Windows.Forms.GroupBox()
        Me.tblSpike = New System.Windows.Forms.TableLayoutPanel()
        Me.lblLargePhaseOffset = New System.Windows.Forms.Label()
        Me.nudLargePhaseOffset = New System.Windows.Forms.NumericUpDown()
        Me.lblSpikeWatchPeriod = New System.Windows.Forms.Label()
        Me.nudSpikeWatchPeriod = New System.Windows.Forms.NumericUpDown()
        Me.lblHoldPeriod = New System.Windows.Forms.Label()
        Me.nudHoldPeriod = New System.Windows.Forms.NumericUpDown()
        Me.cardTimeCorrection = New System.Windows.Forms.GroupBox()
        Me.tblTimeCorr = New System.Windows.Forms.TableLayoutPanel()
        Me.lblAdvUpdateInterval = New System.Windows.Forms.Label()
        Me.nudAdvUpdateInterval = New System.Windows.Forms.NumericUpDown()
        Me.lblFreqCorrectRate = New System.Windows.Forms.Label()
        Me.nudFreqCorrectRate = New System.Windows.Forms.NumericUpDown()
        Me.lblPhaseCorrectRate = New System.Windows.Forms.Label()
        Me.nudPhaseCorrectRate = New System.Windows.Forms.NumericUpDown()
        Me.lblClockHoldover = New System.Windows.Forms.Label()
        Me.nudClockHoldover = New System.Windows.Forms.NumericUpDown()
        Me.pageConfigView = New System.Windows.Forms.Panel()
        Me.flpConfigBtns = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnRefreshConfig = New System.Windows.Forms.Button()
        Me.cardConfigRaw = New System.Windows.Forms.GroupBox()
        Me.tblConfigRaw = New System.Windows.Forms.TableLayoutPanel()
        Me.rtbConfigView = New System.Windows.Forms.RichTextBox()
        Me.pnlTabStrip = New System.Windows.Forms.Panel()
        Me.cboLanguage = New System.Windows.Forms.ComboBox()
        Me.pnlInfoBar = New System.Windows.Forms.Panel()
        Me.lblInfoStatus = New System.Windows.Forms.Label()
        Me.lblInfoDetails = New System.Windows.Forms.Label()
        Me.stsMain.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.pageStatus.SuspendLayout()
        Me.cardPeers.SuspendLayout()
        Me.tblPeers.SuspendLayout()
        CType(Me.dgvPeers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cardNtpStatus.SuspendLayout()
        Me.tblNtpStatus.SuspendLayout()
        CType(Me.dgvStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flpStatusBtns.SuspendLayout()
        Me.cardService.SuspendLayout()
        Me.tblService.SuspendLayout()
        Me.flpServiceBtns.SuspendLayout()
        Me.pageClient.SuspendLayout()
        Me.flpClientBtns.SuspendLayout()
        Me.cardCrossSite.SuspendLayout()
        Me.tblCrossSite.SuspendLayout()
        CType(Me.nudBackOffMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudBackOffMax, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cardPolling.SuspendLayout()
        Me.tblPolling.SuspendLayout()
        CType(Me.nudUpdateInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMinPoll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMaxPoll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cardFlags.SuspendLayout()
        Me.tblFlags.SuspendLayout()
        Me.cardClientBasic.SuspendLayout()
        Me.tblClientBasic.SuspendLayout()
        Me.pageServer.SuspendLayout()
        Me.flpServerBtns.SuspendLayout()
        Me.cardChain.SuspendLayout()
        Me.tblChain.SuspendLayout()
        CType(Me.nudChainEntryTimeout, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cardPhase.SuspendLayout()
        Me.tblPhase.SuspendLayout()
        CType(Me.nudMaxPosPhase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMaxNegPhase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMaxPhaseOffset, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cardServerBasic.SuspendLayout()
        Me.tblServerBasic.SuspendLayout()
        Me.pageAdvanced.SuspendLayout()
        Me.flpAdvancedBtns.SuspendLayout()
        Me.cardLogging.SuspendLayout()
        Me.tblLogging.SuspendLayout()
        Me.pnlLogPath.SuspendLayout()
        CType(Me.nudFileLogEntries, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudFileLogSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cardMisc.SuspendLayout()
        Me.tblMisc.SuspendLayout()
        CType(Me.nudLocalClockDisp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAuditLimit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cardSpike.SuspendLayout()
        Me.tblSpike.SuspendLayout()
        CType(Me.nudLargePhaseOffset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudSpikeWatchPeriod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudHoldPeriod, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cardTimeCorrection.SuspendLayout()
        Me.tblTimeCorr.SuspendLayout()
        CType(Me.nudAdvUpdateInterval, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudFreqCorrectRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudPhaseCorrectRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudClockHoldover, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pageConfigView.SuspendLayout()
        Me.flpConfigBtns.SuspendLayout()
        Me.cardConfigRaw.SuspendLayout()
        Me.tblConfigRaw.SuspendLayout()
        Me.pnlTabStrip.SuspendLayout()
        Me.pnlInfoBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'stsMain
        '
        Me.stsMain.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.stsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslStatus})
        Me.stsMain.Location = New System.Drawing.Point(0, 738)
        Me.stsMain.Name = "stsMain"
        Me.stsMain.Size = New System.Drawing.Size(1200, 22)
        Me.stsMain.SizingGrip = False
        Me.stsMain.TabIndex = 0
        '
        'tsslStatus
        '
        Me.tsslStatus.Name = "tsslStatus"
        Me.tsslStatus.Size = New System.Drawing.Size(1185, 15)
        Me.tsslStatus.Spring = True
        Me.tsslStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlContent
        '
        Me.pnlContent.Controls.Add(Me.pageStatus)
        Me.pnlContent.Controls.Add(Me.pageClient)
        Me.pnlContent.Controls.Add(Me.pageServer)
        Me.pnlContent.Controls.Add(Me.pageAdvanced)
        Me.pnlContent.Controls.Add(Me.pageConfigView)
        Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.Location = New System.Drawing.Point(0, 72)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Size = New System.Drawing.Size(1200, 688)
        Me.pnlContent.TabIndex = 1
        '
        'pageStatus
        '
        Me.pageStatus.AutoScroll = True
        Me.pageStatus.Controls.Add(Me.cardPeers)
        Me.pageStatus.Controls.Add(Me.cardNtpStatus)
        Me.pageStatus.Controls.Add(Me.cardService)
        Me.pageStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pageStatus.Location = New System.Drawing.Point(0, 0)
        Me.pageStatus.Name = "pageStatus"
        Me.pageStatus.Padding = New System.Windows.Forms.Padding(16, 12, 16, 48)
        Me.pageStatus.Size = New System.Drawing.Size(1200, 688)
        Me.pageStatus.TabIndex = 0
        '
        'cardPeers
        '
        Me.cardPeers.Controls.Add(Me.tblPeers)
        Me.cardPeers.Dock = System.Windows.Forms.DockStyle.Top
        Me.cardPeers.Location = New System.Drawing.Point(16, 528)
        Me.cardPeers.Name = "cardPeers"
        Me.cardPeers.Padding = New System.Windows.Forms.Padding(16, 4, 16, 20)
        Me.cardPeers.Size = New System.Drawing.Size(1142, 260)
        Me.cardPeers.TabIndex = 0
        Me.cardPeers.TabStop = False
        '
        'tblPeers
        '
        Me.tblPeers.ColumnCount = 1
        Me.tblPeers.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblPeers.Controls.Add(Me.dgvPeers, 0, 0)
        Me.tblPeers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblPeers.Location = New System.Drawing.Point(16, 29)
        Me.tblPeers.Name = "tblPeers"
        Me.tblPeers.RowCount = 1
        Me.tblPeers.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblPeers.Size = New System.Drawing.Size(1110, 211)
        Me.tblPeers.TabIndex = 0
        '
        'dgvPeers
        '
        Me.dgvPeers.AllowUserToAddRows = False
        Me.dgvPeers.AllowUserToDeleteRows = False
        Me.dgvPeers.AllowUserToResizeRows = False
        Me.dgvPeers.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPeers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvPeers.ColumnHeadersHeight = 34
        Me.dgvPeers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PeerServer, Me.PeerState, Me.PeerStratum, Me.PeerOffset, Me.PeerRootDelay, Me.PeerRootDisp})
        Me.dgvPeers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPeers.Location = New System.Drawing.Point(3, 3)
        Me.dgvPeers.MultiSelect = False
        Me.dgvPeers.Name = "dgvPeers"
        Me.dgvPeers.ReadOnly = True
        Me.dgvPeers.RowHeadersVisible = False
        Me.dgvPeers.RowHeadersWidth = 62
        Me.dgvPeers.RowTemplate.Height = 30
        Me.dgvPeers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPeers.Size = New System.Drawing.Size(1104, 205)
        Me.dgvPeers.TabIndex = 0
        '
        'PeerServer
        '
        Me.PeerServer.MinimumWidth = 60
        Me.PeerServer.Name = "PeerServer"
        Me.PeerServer.ReadOnly = True
        Me.PeerServer.Width = 150
        '
        'PeerState
        '
        Me.PeerState.MinimumWidth = 60
        Me.PeerState.Name = "PeerState"
        Me.PeerState.ReadOnly = True
        Me.PeerState.Width = 150
        '
        'PeerStratum
        '
        Me.PeerStratum.MinimumWidth = 60
        Me.PeerStratum.Name = "PeerStratum"
        Me.PeerStratum.ReadOnly = True
        Me.PeerStratum.Width = 150
        '
        'PeerOffset
        '
        Me.PeerOffset.MinimumWidth = 60
        Me.PeerOffset.Name = "PeerOffset"
        Me.PeerOffset.ReadOnly = True
        Me.PeerOffset.Width = 150
        '
        'PeerRootDelay
        '
        Me.PeerRootDelay.MinimumWidth = 60
        Me.PeerRootDelay.Name = "PeerRootDelay"
        Me.PeerRootDelay.ReadOnly = True
        Me.PeerRootDelay.Width = 150
        '
        'PeerRootDisp
        '
        Me.PeerRootDisp.MinimumWidth = 60
        Me.PeerRootDisp.Name = "PeerRootDisp"
        Me.PeerRootDisp.ReadOnly = True
        Me.PeerRootDisp.Width = 150
        '
        'cardNtpStatus
        '
        Me.cardNtpStatus.Controls.Add(Me.tblNtpStatus)
        Me.cardNtpStatus.Dock = System.Windows.Forms.DockStyle.Top
        Me.cardNtpStatus.Location = New System.Drawing.Point(16, 188)
        Me.cardNtpStatus.Name = "cardNtpStatus"
        Me.cardNtpStatus.Padding = New System.Windows.Forms.Padding(16, 4, 16, 20)
        Me.cardNtpStatus.Size = New System.Drawing.Size(1142, 340)
        Me.cardNtpStatus.TabIndex = 1
        Me.cardNtpStatus.TabStop = False
        '
        'tblNtpStatus
        '
        Me.tblNtpStatus.ColumnCount = 1
        Me.tblNtpStatus.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblNtpStatus.Controls.Add(Me.dgvStatus, 0, 0)
        Me.tblNtpStatus.Controls.Add(Me.flpStatusBtns, 0, 1)
        Me.tblNtpStatus.Dock = System.Windows.Forms.DockStyle.Top
        Me.tblNtpStatus.Location = New System.Drawing.Point(16, 29)
        Me.tblNtpStatus.Name = "tblNtpStatus"
        Me.tblNtpStatus.RowCount = 2
        Me.tblNtpStatus.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 236.0!))
        Me.tblNtpStatus.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblNtpStatus.Size = New System.Drawing.Size(1110, 291)
        Me.tblNtpStatus.TabIndex = 0
        '
        'dgvStatus
        '
        Me.dgvStatus.AllowUserToAddRows = False
        Me.dgvStatus.AllowUserToDeleteRows = False
        Me.dgvStatus.AllowUserToResizeRows = False
        Me.dgvStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvStatus.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvStatus.ColumnHeadersHeight = 34
        Me.dgvStatus.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Key, Me.Value})
        Me.dgvStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvStatus.Location = New System.Drawing.Point(3, 3)
        Me.dgvStatus.MultiSelect = False
        Me.dgvStatus.Name = "dgvStatus"
        Me.dgvStatus.ReadOnly = True
        Me.dgvStatus.RowHeadersVisible = False
        Me.dgvStatus.RowHeadersWidth = 62
        Me.dgvStatus.RowTemplate.Height = 30
        Me.dgvStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvStatus.Size = New System.Drawing.Size(1104, 230)
        Me.dgvStatus.TabIndex = 0
        '
        'Key
        '
        Me.Key.MinimumWidth = 180
        Me.Key.Name = "Key"
        Me.Key.ReadOnly = True
        Me.Key.Width = 240
        '
        'Value
        '
        Me.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Value.MinimumWidth = 8
        Me.Value.Name = "Value"
        Me.Value.ReadOnly = True
        '
        'flpStatusBtns
        '
        Me.flpStatusBtns.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpStatusBtns.AutoSize = True
        Me.flpStatusBtns.Controls.Add(Me.btnSyncNow)
        Me.flpStatusBtns.Controls.Add(Me.btnRefreshStatus)
        Me.flpStatusBtns.Location = New System.Drawing.Point(911, 239)
        Me.flpStatusBtns.Name = "flpStatusBtns"
        Me.flpStatusBtns.Size = New System.Drawing.Size(196, 36)
        Me.flpStatusBtns.TabIndex = 1
        Me.flpStatusBtns.WrapContents = False
        '
        'btnSyncNow
        '
        Me.btnSyncNow.AutoSize = True
        Me.btnSyncNow.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSyncNow.Location = New System.Drawing.Point(0, 4)
        Me.btnSyncNow.Margin = New System.Windows.Forms.Padding(0, 4, 8, 0)
        Me.btnSyncNow.MinimumSize = New System.Drawing.Size(100, 32)
        Me.btnSyncNow.Name = "btnSyncNow"
        Me.btnSyncNow.Size = New System.Drawing.Size(100, 32)
        Me.btnSyncNow.TabIndex = 0
        '
        'btnRefreshStatus
        '
        Me.btnRefreshStatus.AutoSize = True
        Me.btnRefreshStatus.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnRefreshStatus.Location = New System.Drawing.Point(108, 4)
        Me.btnRefreshStatus.Margin = New System.Windows.Forms.Padding(0, 4, 8, 0)
        Me.btnRefreshStatus.MinimumSize = New System.Drawing.Size(80, 32)
        Me.btnRefreshStatus.Name = "btnRefreshStatus"
        Me.btnRefreshStatus.Size = New System.Drawing.Size(80, 32)
        Me.btnRefreshStatus.TabIndex = 1
        '
        'cardService
        '
        Me.cardService.Controls.Add(Me.tblService)
        Me.cardService.Dock = System.Windows.Forms.DockStyle.Top
        Me.cardService.Location = New System.Drawing.Point(16, 12)
        Me.cardService.Name = "cardService"
        Me.cardService.Padding = New System.Windows.Forms.Padding(16, 4, 16, 20)
        Me.cardService.Size = New System.Drawing.Size(1142, 176)
        Me.cardService.TabIndex = 2
        Me.cardService.TabStop = False
        '
        'tblService
        '
        Me.tblService.AutoSize = True
        Me.tblService.ColumnCount = 2
        Me.tblService.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblService.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220.0!))
        Me.tblService.Controls.Add(Me.lblServiceStatusLbl, 0, 0)
        Me.tblService.Controls.Add(Me.lblServiceStatusVal, 1, 0)
        Me.tblService.Controls.Add(Me.flpServiceBtns, 0, 1)
        Me.tblService.Dock = System.Windows.Forms.DockStyle.Top
        Me.tblService.Location = New System.Drawing.Point(16, 29)
        Me.tblService.Name = "tblService"
        Me.tblService.RowCount = 2
        Me.tblService.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblService.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.tblService.Size = New System.Drawing.Size(1110, 84)
        Me.tblService.TabIndex = 0
        '
        'lblServiceStatusLbl
        '
        Me.lblServiceStatusLbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblServiceStatusLbl.Location = New System.Drawing.Point(3, 0)
        Me.lblServiceStatusLbl.Name = "lblServiceStatusLbl"
        Me.lblServiceStatusLbl.Size = New System.Drawing.Size(884, 40)
        Me.lblServiceStatusLbl.TabIndex = 0
        Me.lblServiceStatusLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblServiceStatusVal
        '
        Me.lblServiceStatusVal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblServiceStatusVal.Font = New System.Drawing.Font("Segoe UI Semibold", 9.25!)
        Me.lblServiceStatusVal.Location = New System.Drawing.Point(893, 0)
        Me.lblServiceStatusVal.Name = "lblServiceStatusVal"
        Me.lblServiceStatusVal.Size = New System.Drawing.Size(214, 40)
        Me.lblServiceStatusVal.TabIndex = 1
        Me.lblServiceStatusVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'flpServiceBtns
        '
        Me.flpServiceBtns.AutoSize = True
        Me.tblService.SetColumnSpan(Me.flpServiceBtns, 2)
        Me.flpServiceBtns.Controls.Add(Me.btnStart)
        Me.flpServiceBtns.Controls.Add(Me.btnStop)
        Me.flpServiceBtns.Controls.Add(Me.btnRestart)
        Me.flpServiceBtns.Location = New System.Drawing.Point(0, 46)
        Me.flpServiceBtns.Margin = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.flpServiceBtns.Name = "flpServiceBtns"
        Me.flpServiceBtns.Size = New System.Drawing.Size(264, 32)
        Me.flpServiceBtns.TabIndex = 2
        Me.flpServiceBtns.WrapContents = False
        '
        'btnStart
        '
        Me.btnStart.AutoSize = True
        Me.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnStart.Location = New System.Drawing.Point(0, 0)
        Me.btnStart.Margin = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.btnStart.MinimumSize = New System.Drawing.Size(80, 32)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(80, 32)
        Me.btnStart.TabIndex = 0
        '
        'btnStop
        '
        Me.btnStop.AutoSize = True
        Me.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnStop.Location = New System.Drawing.Point(88, 0)
        Me.btnStop.Margin = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.btnStop.MinimumSize = New System.Drawing.Size(80, 32)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(80, 32)
        Me.btnStop.TabIndex = 1
        '
        'btnRestart
        '
        Me.btnRestart.AutoSize = True
        Me.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnRestart.Location = New System.Drawing.Point(176, 0)
        Me.btnRestart.Margin = New System.Windows.Forms.Padding(0, 0, 8, 0)
        Me.btnRestart.MinimumSize = New System.Drawing.Size(80, 32)
        Me.btnRestart.Name = "btnRestart"
        Me.btnRestart.Size = New System.Drawing.Size(80, 32)
        Me.btnRestart.TabIndex = 2
        '
        'pageClient
        '
        Me.pageClient.AutoScroll = True
        Me.pageClient.Controls.Add(Me.flpClientBtns)
        Me.pageClient.Controls.Add(Me.cardCrossSite)
        Me.pageClient.Controls.Add(Me.cardPolling)
        Me.pageClient.Controls.Add(Me.cardFlags)
        Me.pageClient.Controls.Add(Me.cardClientBasic)
        Me.pageClient.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pageClient.Location = New System.Drawing.Point(0, 0)
        Me.pageClient.Name = "pageClient"
        Me.pageClient.Padding = New System.Windows.Forms.Padding(16, 12, 16, 48)
        Me.pageClient.Size = New System.Drawing.Size(1200, 688)
        Me.pageClient.TabIndex = 1
        '
        'flpClientBtns
        '
        Me.flpClientBtns.Controls.Add(Me.btnApplyClient)
        Me.flpClientBtns.Controls.Add(Me.btnResetClient)
        Me.flpClientBtns.Dock = System.Windows.Forms.DockStyle.Top
        Me.flpClientBtns.Location = New System.Drawing.Point(16, 954)
        Me.flpClientBtns.Margin = New System.Windows.Forms.Padding(0, 0, 0, 8)
        Me.flpClientBtns.Name = "flpClientBtns"
        Me.flpClientBtns.Size = New System.Drawing.Size(1142, 48)
        Me.flpClientBtns.TabIndex = 0
        Me.flpClientBtns.WrapContents = False
        '
        'btnApplyClient
        '
        Me.btnApplyClient.AutoSize = True
        Me.btnApplyClient.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnApplyClient.Location = New System.Drawing.Point(0, 8)
        Me.btnApplyClient.Margin = New System.Windows.Forms.Padding(0, 8, 8, 0)
        Me.btnApplyClient.MinimumSize = New System.Drawing.Size(90, 32)
        Me.btnApplyClient.Name = "btnApplyClient"
        Me.btnApplyClient.Size = New System.Drawing.Size(90, 32)
        Me.btnApplyClient.TabIndex = 0
        '
        'btnResetClient
        '
        Me.btnResetClient.AutoSize = True
        Me.btnResetClient.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnResetClient.Location = New System.Drawing.Point(98, 8)
        Me.btnResetClient.Margin = New System.Windows.Forms.Padding(0, 8, 8, 0)
        Me.btnResetClient.MinimumSize = New System.Drawing.Size(90, 32)
        Me.btnResetClient.Name = "btnResetClient"
        Me.btnResetClient.Size = New System.Drawing.Size(90, 32)
        Me.btnResetClient.TabIndex = 1
        '
        'cardCrossSite
        '
        Me.cardCrossSite.Controls.Add(Me.tblCrossSite)
        Me.cardCrossSite.Dock = System.Windows.Forms.DockStyle.Top
        Me.cardCrossSite.Location = New System.Drawing.Point(16, 730)
        Me.cardCrossSite.Name = "cardCrossSite"
        Me.cardCrossSite.Padding = New System.Windows.Forms.Padding(16, 4, 16, 20)
        Me.cardCrossSite.Size = New System.Drawing.Size(1142, 224)
        Me.cardCrossSite.TabIndex = 1
        Me.cardCrossSite.TabStop = False
        '
        'tblCrossSite
        '
        Me.tblCrossSite.AutoSize = True
        Me.tblCrossSite.ColumnCount = 2
        Me.tblCrossSite.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblCrossSite.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220.0!))
        Me.tblCrossSite.Controls.Add(Me.chkCrossSiteSync, 0, 0)
        Me.tblCrossSite.Controls.Add(Me.lblBackOffMin, 0, 1)
        Me.tblCrossSite.Controls.Add(Me.nudBackOffMin, 1, 1)
        Me.tblCrossSite.Controls.Add(Me.lblBackOffMax, 0, 2)
        Me.tblCrossSite.Controls.Add(Me.nudBackOffMax, 1, 2)
        Me.tblCrossSite.Dock = System.Windows.Forms.DockStyle.Top
        Me.tblCrossSite.Location = New System.Drawing.Point(16, 29)
        Me.tblCrossSite.Name = "tblCrossSite"
        Me.tblCrossSite.RowCount = 3
        Me.tblCrossSite.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblCrossSite.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblCrossSite.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblCrossSite.Size = New System.Drawing.Size(1110, 120)
        Me.tblCrossSite.TabIndex = 0
        '
        'chkCrossSiteSync
        '
        Me.tblCrossSite.SetColumnSpan(Me.chkCrossSiteSync, 2)
        Me.chkCrossSiteSync.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkCrossSiteSync.Location = New System.Drawing.Point(3, 3)
        Me.chkCrossSiteSync.Name = "chkCrossSiteSync"
        Me.chkCrossSiteSync.Size = New System.Drawing.Size(1104, 34)
        Me.chkCrossSiteSync.TabIndex = 0
        '
        'lblBackOffMin
        '
        Me.lblBackOffMin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblBackOffMin.Location = New System.Drawing.Point(3, 40)
        Me.lblBackOffMin.Name = "lblBackOffMin"
        Me.lblBackOffMin.Size = New System.Drawing.Size(884, 40)
        Me.lblBackOffMin.TabIndex = 1
        Me.lblBackOffMin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nudBackOffMin
        '
        Me.nudBackOffMin.Location = New System.Drawing.Point(893, 43)
        Me.nudBackOffMin.Maximum = New Decimal(New Integer() {3600, 0, 0, 0})
        Me.nudBackOffMin.Name = "nudBackOffMin"
        Me.nudBackOffMin.Size = New System.Drawing.Size(130, 32)
        Me.nudBackOffMin.TabIndex = 2
        '
        'lblBackOffMax
        '
        Me.lblBackOffMax.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblBackOffMax.Location = New System.Drawing.Point(3, 80)
        Me.lblBackOffMax.Name = "lblBackOffMax"
        Me.lblBackOffMax.Size = New System.Drawing.Size(884, 40)
        Me.lblBackOffMax.TabIndex = 3
        Me.lblBackOffMax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nudBackOffMax
        '
        Me.nudBackOffMax.Location = New System.Drawing.Point(893, 83)
        Me.nudBackOffMax.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudBackOffMax.Name = "nudBackOffMax"
        Me.nudBackOffMax.Size = New System.Drawing.Size(130, 32)
        Me.nudBackOffMax.TabIndex = 4
        '
        'cardPolling
        '
        Me.cardPolling.Controls.Add(Me.tblPolling)
        Me.cardPolling.Dock = System.Windows.Forms.DockStyle.Top
        Me.cardPolling.Location = New System.Drawing.Point(16, 506)
        Me.cardPolling.Name = "cardPolling"
        Me.cardPolling.Padding = New System.Windows.Forms.Padding(16, 4, 16, 20)
        Me.cardPolling.Size = New System.Drawing.Size(1142, 224)
        Me.cardPolling.TabIndex = 2
        Me.cardPolling.TabStop = False
        '
        'tblPolling
        '
        Me.tblPolling.AutoSize = True
        Me.tblPolling.ColumnCount = 2
        Me.tblPolling.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblPolling.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220.0!))
        Me.tblPolling.Controls.Add(Me.lblUpdateInterval, 0, 0)
        Me.tblPolling.Controls.Add(Me.nudUpdateInterval, 1, 0)
        Me.tblPolling.Controls.Add(Me.lblMinPoll, 0, 1)
        Me.tblPolling.Controls.Add(Me.nudMinPoll, 1, 1)
        Me.tblPolling.Controls.Add(Me.lblMaxPoll, 0, 2)
        Me.tblPolling.Controls.Add(Me.nudMaxPoll, 1, 2)
        Me.tblPolling.Dock = System.Windows.Forms.DockStyle.Top
        Me.tblPolling.Location = New System.Drawing.Point(16, 29)
        Me.tblPolling.Name = "tblPolling"
        Me.tblPolling.RowCount = 3
        Me.tblPolling.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblPolling.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblPolling.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblPolling.Size = New System.Drawing.Size(1110, 120)
        Me.tblPolling.TabIndex = 0
        '
        'lblUpdateInterval
        '
        Me.lblUpdateInterval.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblUpdateInterval.Location = New System.Drawing.Point(3, 0)
        Me.lblUpdateInterval.Name = "lblUpdateInterval"
        Me.lblUpdateInterval.Size = New System.Drawing.Size(884, 40)
        Me.lblUpdateInterval.TabIndex = 0
        Me.lblUpdateInterval.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nudUpdateInterval
        '
        Me.nudUpdateInterval.Location = New System.Drawing.Point(893, 3)
        Me.nudUpdateInterval.Maximum = New Decimal(New Integer() {-294967296, 0, 0, 0})
        Me.nudUpdateInterval.Name = "nudUpdateInterval"
        Me.nudUpdateInterval.Size = New System.Drawing.Size(130, 32)
        Me.nudUpdateInterval.TabIndex = 1
        Me.nudUpdateInterval.ThousandsSeparator = True
        '
        'lblMinPoll
        '
        Me.lblMinPoll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMinPoll.Location = New System.Drawing.Point(3, 40)
        Me.lblMinPoll.Name = "lblMinPoll"
        Me.lblMinPoll.Size = New System.Drawing.Size(884, 40)
        Me.lblMinPoll.TabIndex = 2
        Me.lblMinPoll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nudMinPoll
        '
        Me.nudMinPoll.Location = New System.Drawing.Point(893, 43)
        Me.nudMinPoll.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.nudMinPoll.Name = "nudMinPoll"
        Me.nudMinPoll.Size = New System.Drawing.Size(130, 32)
        Me.nudMinPoll.TabIndex = 3
        '
        'lblMaxPoll
        '
        Me.lblMaxPoll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMaxPoll.Location = New System.Drawing.Point(3, 80)
        Me.lblMaxPoll.Name = "lblMaxPoll"
        Me.lblMaxPoll.Size = New System.Drawing.Size(884, 40)
        Me.lblMaxPoll.TabIndex = 4
        Me.lblMaxPoll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nudMaxPoll
        '
        Me.nudMaxPoll.Location = New System.Drawing.Point(893, 83)
        Me.nudMaxPoll.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.nudMaxPoll.Name = "nudMaxPoll"
        Me.nudMaxPoll.Size = New System.Drawing.Size(130, 32)
        Me.nudMaxPoll.TabIndex = 5
        '
        'cardFlags
        '
        Me.cardFlags.Controls.Add(Me.tblFlags)
        Me.cardFlags.Dock = System.Windows.Forms.DockStyle.Top
        Me.cardFlags.Location = New System.Drawing.Point(16, 236)
        Me.cardFlags.Name = "cardFlags"
        Me.cardFlags.Padding = New System.Windows.Forms.Padding(16, 4, 16, 20)
        Me.cardFlags.Size = New System.Drawing.Size(1142, 270)
        Me.cardFlags.TabIndex = 3
        Me.cardFlags.TabStop = False
        '
        'tblFlags
        '
        Me.tblFlags.AutoSize = True
        Me.tblFlags.ColumnCount = 2
        Me.tblFlags.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblFlags.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220.0!))
        Me.tblFlags.Controls.Add(Me.chkFlag8, 0, 0)
        Me.tblFlags.Controls.Add(Me.chkFlag4, 0, 1)
        Me.tblFlags.Controls.Add(Me.chkFlag1, 0, 2)
        Me.tblFlags.Controls.Add(Me.lblCombinedFlagLbl, 0, 3)
        Me.tblFlags.Controls.Add(Me.lblCombinedFlagVal, 1, 3)
        Me.tblFlags.Dock = System.Windows.Forms.DockStyle.Top
        Me.tblFlags.Location = New System.Drawing.Point(16, 29)
        Me.tblFlags.Name = "tblFlags"
        Me.tblFlags.RowCount = 4
        Me.tblFlags.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblFlags.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblFlags.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblFlags.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblFlags.Size = New System.Drawing.Size(1110, 160)
        Me.tblFlags.TabIndex = 0
        '
        'chkFlag8
        '
        Me.tblFlags.SetColumnSpan(Me.chkFlag8, 2)
        Me.chkFlag8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkFlag8.Location = New System.Drawing.Point(3, 3)
        Me.chkFlag8.Name = "chkFlag8"
        Me.chkFlag8.Size = New System.Drawing.Size(1104, 34)
        Me.chkFlag8.TabIndex = 0
        '
        'chkFlag4
        '
        Me.tblFlags.SetColumnSpan(Me.chkFlag4, 2)
        Me.chkFlag4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkFlag4.Location = New System.Drawing.Point(3, 43)
        Me.chkFlag4.Name = "chkFlag4"
        Me.chkFlag4.Size = New System.Drawing.Size(1104, 34)
        Me.chkFlag4.TabIndex = 1
        '
        'chkFlag1
        '
        Me.tblFlags.SetColumnSpan(Me.chkFlag1, 2)
        Me.chkFlag1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkFlag1.Location = New System.Drawing.Point(3, 83)
        Me.chkFlag1.Name = "chkFlag1"
        Me.chkFlag1.Size = New System.Drawing.Size(1104, 34)
        Me.chkFlag1.TabIndex = 2
        '
        'lblCombinedFlagLbl
        '
        Me.lblCombinedFlagLbl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCombinedFlagLbl.Location = New System.Drawing.Point(3, 120)
        Me.lblCombinedFlagLbl.Name = "lblCombinedFlagLbl"
        Me.lblCombinedFlagLbl.Size = New System.Drawing.Size(884, 40)
        Me.lblCombinedFlagLbl.TabIndex = 3
        Me.lblCombinedFlagLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCombinedFlagVal
        '
        Me.lblCombinedFlagVal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCombinedFlagVal.Font = New System.Drawing.Font("Segoe UI Semibold", 9.25!)
        Me.lblCombinedFlagVal.Location = New System.Drawing.Point(893, 120)
        Me.lblCombinedFlagVal.Name = "lblCombinedFlagVal"
        Me.lblCombinedFlagVal.Size = New System.Drawing.Size(214, 40)
        Me.lblCombinedFlagVal.TabIndex = 4
        Me.lblCombinedFlagVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cardClientBasic
        '
        Me.cardClientBasic.Controls.Add(Me.tblClientBasic)
        Me.cardClientBasic.Dock = System.Windows.Forms.DockStyle.Top
        Me.cardClientBasic.Location = New System.Drawing.Point(16, 12)
        Me.cardClientBasic.Name = "cardClientBasic"
        Me.cardClientBasic.Padding = New System.Windows.Forms.Padding(16, 4, 16, 20)
        Me.cardClientBasic.Size = New System.Drawing.Size(1142, 224)
        Me.cardClientBasic.TabIndex = 4
        Me.cardClientBasic.TabStop = False
        '
        'tblClientBasic
        '
        Me.tblClientBasic.AutoSize = True
        Me.tblClientBasic.ColumnCount = 2
        Me.tblClientBasic.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblClientBasic.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220.0!))
        Me.tblClientBasic.Controls.Add(Me.chkClientEnabled, 0, 0)
        Me.tblClientBasic.Controls.Add(Me.lblSyncType, 0, 1)
        Me.tblClientBasic.Controls.Add(Me.cboSyncType, 1, 1)
        Me.tblClientBasic.Controls.Add(Me.lblNtpServers, 0, 2)
        Me.tblClientBasic.Controls.Add(Me.txtNtpServers, 1, 2)
        Me.tblClientBasic.Dock = System.Windows.Forms.DockStyle.Top
        Me.tblClientBasic.Location = New System.Drawing.Point(16, 29)
        Me.tblClientBasic.Name = "tblClientBasic"
        Me.tblClientBasic.RowCount = 3
        Me.tblClientBasic.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblClientBasic.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblClientBasic.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblClientBasic.Size = New System.Drawing.Size(1110, 120)
        Me.tblClientBasic.TabIndex = 0
        '
        'chkClientEnabled
        '
        Me.tblClientBasic.SetColumnSpan(Me.chkClientEnabled, 2)
        Me.chkClientEnabled.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkClientEnabled.Location = New System.Drawing.Point(3, 3)
        Me.chkClientEnabled.Name = "chkClientEnabled"
        Me.chkClientEnabled.Size = New System.Drawing.Size(1104, 34)
        Me.chkClientEnabled.TabIndex = 0
        '
        'lblSyncType
        '
        Me.lblSyncType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSyncType.Location = New System.Drawing.Point(3, 40)
        Me.lblSyncType.Name = "lblSyncType"
        Me.lblSyncType.Size = New System.Drawing.Size(884, 40)
        Me.lblSyncType.TabIndex = 1
        Me.lblSyncType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSyncType
        '
        Me.cboSyncType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSyncType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSyncType.Items.AddRange(New Object() {"NTP", "NT5DS", "AllSync", "NoSync"})
        Me.cboSyncType.Location = New System.Drawing.Point(893, 43)
        Me.cboSyncType.Name = "cboSyncType"
        Me.cboSyncType.Size = New System.Drawing.Size(150, 33)
        Me.cboSyncType.TabIndex = 2
        '
        'lblNtpServers
        '
        Me.lblNtpServers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblNtpServers.Location = New System.Drawing.Point(3, 80)
        Me.lblNtpServers.Name = "lblNtpServers"
        Me.lblNtpServers.Size = New System.Drawing.Size(884, 40)
        Me.lblNtpServers.TabIndex = 3
        Me.lblNtpServers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNtpServers
        '
        Me.txtNtpServers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNtpServers.Location = New System.Drawing.Point(893, 83)
        Me.txtNtpServers.Name = "txtNtpServers"
        Me.txtNtpServers.Size = New System.Drawing.Size(214, 32)
        Me.txtNtpServers.TabIndex = 4
        '
        'pageServer
        '
        Me.pageServer.AutoScroll = True
        Me.pageServer.Controls.Add(Me.flpServerBtns)
        Me.pageServer.Controls.Add(Me.cardChain)
        Me.pageServer.Controls.Add(Me.cardPhase)
        Me.pageServer.Controls.Add(Me.cardServerBasic)
        Me.pageServer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pageServer.Location = New System.Drawing.Point(0, 0)
        Me.pageServer.Name = "pageServer"
        Me.pageServer.Padding = New System.Windows.Forms.Padding(16, 12, 16, 48)
        Me.pageServer.Size = New System.Drawing.Size(1200, 688)
        Me.pageServer.TabIndex = 2
        '
        'flpServerBtns
        '
        Me.flpServerBtns.Controls.Add(Me.btnApplyServer)
        Me.flpServerBtns.Controls.Add(Me.btnResetServer)
        Me.flpServerBtns.Dock = System.Windows.Forms.DockStyle.Top
        Me.flpServerBtns.Location = New System.Drawing.Point(16, 592)
        Me.flpServerBtns.Name = "flpServerBtns"
        Me.flpServerBtns.Size = New System.Drawing.Size(1168, 48)
        Me.flpServerBtns.TabIndex = 0
        Me.flpServerBtns.WrapContents = False
        '
        'btnApplyServer
        '
        Me.btnApplyServer.AutoSize = True
        Me.btnApplyServer.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnApplyServer.Location = New System.Drawing.Point(0, 8)
        Me.btnApplyServer.Margin = New System.Windows.Forms.Padding(0, 8, 8, 0)
        Me.btnApplyServer.MinimumSize = New System.Drawing.Size(90, 32)
        Me.btnApplyServer.Name = "btnApplyServer"
        Me.btnApplyServer.Size = New System.Drawing.Size(90, 32)
        Me.btnApplyServer.TabIndex = 0
        '
        'btnResetServer
        '
        Me.btnResetServer.AutoSize = True
        Me.btnResetServer.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnResetServer.Location = New System.Drawing.Point(98, 8)
        Me.btnResetServer.Margin = New System.Windows.Forms.Padding(0, 8, 8, 0)
        Me.btnResetServer.MinimumSize = New System.Drawing.Size(90, 32)
        Me.btnResetServer.Name = "btnResetServer"
        Me.btnResetServer.Size = New System.Drawing.Size(90, 32)
        Me.btnResetServer.TabIndex = 1
        '
        'cardChain
        '
        Me.cardChain.Controls.Add(Me.tblChain)
        Me.cardChain.Dock = System.Windows.Forms.DockStyle.Top
        Me.cardChain.Location = New System.Drawing.Point(16, 460)
        Me.cardChain.Name = "cardChain"
        Me.cardChain.Padding = New System.Windows.Forms.Padding(16, 4, 16, 20)
        Me.cardChain.Size = New System.Drawing.Size(1168, 132)
        Me.cardChain.TabIndex = 1
        Me.cardChain.TabStop = False
        '
        'tblChain
        '
        Me.tblChain.AutoSize = True
        Me.tblChain.ColumnCount = 2
        Me.tblChain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblChain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220.0!))
        Me.tblChain.Controls.Add(Me.lblChainEntryTimeout, 0, 0)
        Me.tblChain.Controls.Add(Me.nudChainEntryTimeout, 1, 0)
        Me.tblChain.Dock = System.Windows.Forms.DockStyle.Top
        Me.tblChain.Location = New System.Drawing.Point(16, 29)
        Me.tblChain.Name = "tblChain"
        Me.tblChain.RowCount = 1
        Me.tblChain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblChain.Size = New System.Drawing.Size(1136, 40)
        Me.tblChain.TabIndex = 0
        '
        'lblChainEntryTimeout
        '
        Me.lblChainEntryTimeout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblChainEntryTimeout.Location = New System.Drawing.Point(3, 0)
        Me.lblChainEntryTimeout.Name = "lblChainEntryTimeout"
        Me.lblChainEntryTimeout.Size = New System.Drawing.Size(910, 40)
        Me.lblChainEntryTimeout.TabIndex = 0
        Me.lblChainEntryTimeout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nudChainEntryTimeout
        '
        Me.nudChainEntryTimeout.Location = New System.Drawing.Point(919, 3)
        Me.nudChainEntryTimeout.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.nudChainEntryTimeout.Name = "nudChainEntryTimeout"
        Me.nudChainEntryTimeout.Size = New System.Drawing.Size(130, 32)
        Me.nudChainEntryTimeout.TabIndex = 1
        Me.nudChainEntryTimeout.ThousandsSeparator = True
        '
        'cardPhase
        '
        Me.cardPhase.Controls.Add(Me.tblPhase)
        Me.cardPhase.Dock = System.Windows.Forms.DockStyle.Top
        Me.cardPhase.Location = New System.Drawing.Point(16, 236)
        Me.cardPhase.Name = "cardPhase"
        Me.cardPhase.Padding = New System.Windows.Forms.Padding(16, 4, 16, 20)
        Me.cardPhase.Size = New System.Drawing.Size(1168, 224)
        Me.cardPhase.TabIndex = 2
        Me.cardPhase.TabStop = False
        '
        'tblPhase
        '
        Me.tblPhase.AutoSize = True
        Me.tblPhase.ColumnCount = 2
        Me.tblPhase.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblPhase.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220.0!))
        Me.tblPhase.Controls.Add(Me.lblMaxPosPhase, 0, 0)
        Me.tblPhase.Controls.Add(Me.nudMaxPosPhase, 1, 0)
        Me.tblPhase.Controls.Add(Me.lblMaxNegPhase, 0, 1)
        Me.tblPhase.Controls.Add(Me.nudMaxNegPhase, 1, 1)
        Me.tblPhase.Controls.Add(Me.lblMaxPhaseOffset, 0, 2)
        Me.tblPhase.Controls.Add(Me.nudMaxPhaseOffset, 1, 2)
        Me.tblPhase.Dock = System.Windows.Forms.DockStyle.Top
        Me.tblPhase.Location = New System.Drawing.Point(16, 29)
        Me.tblPhase.Name = "tblPhase"
        Me.tblPhase.RowCount = 3
        Me.tblPhase.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblPhase.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblPhase.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblPhase.Size = New System.Drawing.Size(1136, 120)
        Me.tblPhase.TabIndex = 0
        '
        'lblMaxPosPhase
        '
        Me.lblMaxPosPhase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMaxPosPhase.Location = New System.Drawing.Point(3, 0)
        Me.lblMaxPosPhase.Name = "lblMaxPosPhase"
        Me.lblMaxPosPhase.Size = New System.Drawing.Size(910, 40)
        Me.lblMaxPosPhase.TabIndex = 0
        Me.lblMaxPosPhase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nudMaxPosPhase
        '
        Me.nudMaxPosPhase.Location = New System.Drawing.Point(919, 3)
        Me.nudMaxPosPhase.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.nudMaxPosPhase.Name = "nudMaxPosPhase"
        Me.nudMaxPosPhase.Size = New System.Drawing.Size(130, 32)
        Me.nudMaxPosPhase.TabIndex = 1
        Me.nudMaxPosPhase.ThousandsSeparator = True
        '
        'lblMaxNegPhase
        '
        Me.lblMaxNegPhase.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMaxNegPhase.Location = New System.Drawing.Point(3, 40)
        Me.lblMaxNegPhase.Name = "lblMaxNegPhase"
        Me.lblMaxNegPhase.Size = New System.Drawing.Size(910, 40)
        Me.lblMaxNegPhase.TabIndex = 2
        Me.lblMaxNegPhase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nudMaxNegPhase
        '
        Me.nudMaxNegPhase.Location = New System.Drawing.Point(919, 43)
        Me.nudMaxNegPhase.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.nudMaxNegPhase.Name = "nudMaxNegPhase"
        Me.nudMaxNegPhase.Size = New System.Drawing.Size(130, 32)
        Me.nudMaxNegPhase.TabIndex = 3
        Me.nudMaxNegPhase.ThousandsSeparator = True
        '
        'lblMaxPhaseOffset
        '
        Me.lblMaxPhaseOffset.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMaxPhaseOffset.Location = New System.Drawing.Point(3, 80)
        Me.lblMaxPhaseOffset.Name = "lblMaxPhaseOffset"
        Me.lblMaxPhaseOffset.Size = New System.Drawing.Size(910, 40)
        Me.lblMaxPhaseOffset.TabIndex = 4
        Me.lblMaxPhaseOffset.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nudMaxPhaseOffset
        '
        Me.nudMaxPhaseOffset.Location = New System.Drawing.Point(919, 83)
        Me.nudMaxPhaseOffset.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.nudMaxPhaseOffset.Name = "nudMaxPhaseOffset"
        Me.nudMaxPhaseOffset.Size = New System.Drawing.Size(130, 32)
        Me.nudMaxPhaseOffset.TabIndex = 5
        Me.nudMaxPhaseOffset.ThousandsSeparator = True
        '
        'cardServerBasic
        '
        Me.cardServerBasic.Controls.Add(Me.tblServerBasic)
        Me.cardServerBasic.Dock = System.Windows.Forms.DockStyle.Top
        Me.cardServerBasic.Location = New System.Drawing.Point(16, 12)
        Me.cardServerBasic.Name = "cardServerBasic"
        Me.cardServerBasic.Padding = New System.Windows.Forms.Padding(16, 4, 16, 20)
        Me.cardServerBasic.Size = New System.Drawing.Size(1168, 224)
        Me.cardServerBasic.TabIndex = 3
        Me.cardServerBasic.TabStop = False
        '
        'tblServerBasic
        '
        Me.tblServerBasic.AutoSize = True
        Me.tblServerBasic.ColumnCount = 2
        Me.tblServerBasic.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblServerBasic.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220.0!))
        Me.tblServerBasic.Controls.Add(Me.chkServerEnabled, 0, 0)
        Me.tblServerBasic.Controls.Add(Me.lblAnnounceFlags, 0, 1)
        Me.tblServerBasic.Controls.Add(Me.cboAnnounceFlags, 1, 1)
        Me.tblServerBasic.Controls.Add(Me.chkSecureOnly, 0, 2)
        Me.tblServerBasic.Dock = System.Windows.Forms.DockStyle.Top
        Me.tblServerBasic.Location = New System.Drawing.Point(16, 29)
        Me.tblServerBasic.Name = "tblServerBasic"
        Me.tblServerBasic.RowCount = 3
        Me.tblServerBasic.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblServerBasic.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblServerBasic.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblServerBasic.Size = New System.Drawing.Size(1136, 120)
        Me.tblServerBasic.TabIndex = 0
        '
        'chkServerEnabled
        '
        Me.tblServerBasic.SetColumnSpan(Me.chkServerEnabled, 2)
        Me.chkServerEnabled.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkServerEnabled.Location = New System.Drawing.Point(3, 3)
        Me.chkServerEnabled.Name = "chkServerEnabled"
        Me.chkServerEnabled.Size = New System.Drawing.Size(1130, 34)
        Me.chkServerEnabled.TabIndex = 0
        '
        'lblAnnounceFlags
        '
        Me.lblAnnounceFlags.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblAnnounceFlags.Location = New System.Drawing.Point(3, 40)
        Me.lblAnnounceFlags.Name = "lblAnnounceFlags"
        Me.lblAnnounceFlags.Size = New System.Drawing.Size(910, 40)
        Me.lblAnnounceFlags.TabIndex = 1
        Me.lblAnnounceFlags.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAnnounceFlags
        '
        Me.cboAnnounceFlags.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAnnounceFlags.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAnnounceFlags.Items.AddRange(New Object() {"0 – Default", "5 – Reliable time source (Primary DC)", "8 – Always reliable", "10 – NTP Server", "12 – NTP + Domain Controller", "13 – NTP + PDC + Domain Hierarchy"})
        Me.cboAnnounceFlags.Location = New System.Drawing.Point(919, 43)
        Me.cboAnnounceFlags.Name = "cboAnnounceFlags"
        Me.cboAnnounceFlags.Size = New System.Drawing.Size(214, 33)
        Me.cboAnnounceFlags.TabIndex = 2
        '
        'chkSecureOnly
        '
        Me.tblServerBasic.SetColumnSpan(Me.chkSecureOnly, 2)
        Me.chkSecureOnly.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkSecureOnly.Location = New System.Drawing.Point(3, 83)
        Me.chkSecureOnly.Name = "chkSecureOnly"
        Me.chkSecureOnly.Size = New System.Drawing.Size(1130, 34)
        Me.chkSecureOnly.TabIndex = 3
        '
        'pageAdvanced
        '
        Me.pageAdvanced.AutoScroll = True
        Me.pageAdvanced.Controls.Add(Me.flpAdvancedBtns)
        Me.pageAdvanced.Controls.Add(Me.cardLogging)
        Me.pageAdvanced.Controls.Add(Me.cardMisc)
        Me.pageAdvanced.Controls.Add(Me.cardSpike)
        Me.pageAdvanced.Controls.Add(Me.cardTimeCorrection)
        Me.pageAdvanced.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pageAdvanced.Location = New System.Drawing.Point(0, 0)
        Me.pageAdvanced.Name = "pageAdvanced"
        Me.pageAdvanced.Padding = New System.Windows.Forms.Padding(16, 12, 16, 48)
        Me.pageAdvanced.Size = New System.Drawing.Size(1200, 688)
        Me.pageAdvanced.TabIndex = 3
        '
        'flpAdvancedBtns
        '
        Me.flpAdvancedBtns.Controls.Add(Me.btnApplyAdvanced)
        Me.flpAdvancedBtns.Controls.Add(Me.btnResetAdvanced)
        Me.flpAdvancedBtns.Dock = System.Windows.Forms.DockStyle.Top
        Me.flpAdvancedBtns.Location = New System.Drawing.Point(16, 908)
        Me.flpAdvancedBtns.Name = "flpAdvancedBtns"
        Me.flpAdvancedBtns.Size = New System.Drawing.Size(1142, 48)
        Me.flpAdvancedBtns.TabIndex = 0
        Me.flpAdvancedBtns.WrapContents = False
        '
        'btnApplyAdvanced
        '
        Me.btnApplyAdvanced.AutoSize = True
        Me.btnApplyAdvanced.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnApplyAdvanced.Location = New System.Drawing.Point(0, 8)
        Me.btnApplyAdvanced.Margin = New System.Windows.Forms.Padding(0, 8, 8, 0)
        Me.btnApplyAdvanced.MinimumSize = New System.Drawing.Size(90, 32)
        Me.btnApplyAdvanced.Name = "btnApplyAdvanced"
        Me.btnApplyAdvanced.Size = New System.Drawing.Size(90, 32)
        Me.btnApplyAdvanced.TabIndex = 0
        '
        'btnResetAdvanced
        '
        Me.btnResetAdvanced.AutoSize = True
        Me.btnResetAdvanced.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnResetAdvanced.Location = New System.Drawing.Point(98, 8)
        Me.btnResetAdvanced.Margin = New System.Windows.Forms.Padding(0, 8, 8, 0)
        Me.btnResetAdvanced.MinimumSize = New System.Drawing.Size(90, 32)
        Me.btnResetAdvanced.Name = "btnResetAdvanced"
        Me.btnResetAdvanced.Size = New System.Drawing.Size(90, 32)
        Me.btnResetAdvanced.TabIndex = 1
        '
        'cardLogging
        '
        Me.cardLogging.Controls.Add(Me.tblLogging)
        Me.cardLogging.Dock = System.Windows.Forms.DockStyle.Top
        Me.cardLogging.Location = New System.Drawing.Point(16, 684)
        Me.cardLogging.Name = "cardLogging"
        Me.cardLogging.Padding = New System.Windows.Forms.Padding(16, 4, 16, 20)
        Me.cardLogging.Size = New System.Drawing.Size(1142, 224)
        Me.cardLogging.TabIndex = 1
        Me.cardLogging.TabStop = False
        '
        'tblLogging
        '
        Me.tblLogging.AutoSize = True
        Me.tblLogging.ColumnCount = 2
        Me.tblLogging.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblLogging.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220.0!))
        Me.tblLogging.Controls.Add(Me.lblFileLogName, 0, 0)
        Me.tblLogging.Controls.Add(Me.pnlLogPath, 1, 0)
        Me.tblLogging.Controls.Add(Me.lblFileLogEntries, 0, 1)
        Me.tblLogging.Controls.Add(Me.nudFileLogEntries, 1, 1)
        Me.tblLogging.Controls.Add(Me.lblFileLogSize, 0, 2)
        Me.tblLogging.Controls.Add(Me.nudFileLogSize, 1, 2)
        Me.tblLogging.Dock = System.Windows.Forms.DockStyle.Top
        Me.tblLogging.Location = New System.Drawing.Point(16, 29)
        Me.tblLogging.Name = "tblLogging"
        Me.tblLogging.RowCount = 3
        Me.tblLogging.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblLogging.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblLogging.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblLogging.Size = New System.Drawing.Size(1110, 120)
        Me.tblLogging.TabIndex = 0
        '
        'lblFileLogName
        '
        Me.lblFileLogName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFileLogName.Location = New System.Drawing.Point(3, 0)
        Me.lblFileLogName.Name = "lblFileLogName"
        Me.lblFileLogName.Size = New System.Drawing.Size(884, 40)
        Me.lblFileLogName.TabIndex = 0
        Me.lblFileLogName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlLogPath
        '
        Me.pnlLogPath.Controls.Add(Me.txtFileLogName)
        Me.pnlLogPath.Controls.Add(Me.btnBrowseLog)
        Me.pnlLogPath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLogPath.Location = New System.Drawing.Point(893, 3)
        Me.pnlLogPath.Name = "pnlLogPath"
        Me.pnlLogPath.Size = New System.Drawing.Size(214, 34)
        Me.pnlLogPath.TabIndex = 1
        '
        'txtFileLogName
        '
        Me.txtFileLogName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFileLogName.Location = New System.Drawing.Point(0, 0)
        Me.txtFileLogName.Name = "txtFileLogName"
        Me.txtFileLogName.Size = New System.Drawing.Size(134, 32)
        Me.txtFileLogName.TabIndex = 0
        '
        'btnBrowseLog
        '
        Me.btnBrowseLog.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnBrowseLog.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnBrowseLog.Location = New System.Drawing.Point(134, 0)
        Me.btnBrowseLog.Name = "btnBrowseLog"
        Me.btnBrowseLog.Size = New System.Drawing.Size(80, 34)
        Me.btnBrowseLog.TabIndex = 1
        '
        'lblFileLogEntries
        '
        Me.lblFileLogEntries.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFileLogEntries.Location = New System.Drawing.Point(3, 40)
        Me.lblFileLogEntries.Name = "lblFileLogEntries"
        Me.lblFileLogEntries.Size = New System.Drawing.Size(884, 40)
        Me.lblFileLogEntries.TabIndex = 2
        Me.lblFileLogEntries.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nudFileLogEntries
        '
        Me.nudFileLogEntries.Location = New System.Drawing.Point(893, 43)
        Me.nudFileLogEntries.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.nudFileLogEntries.Name = "nudFileLogEntries"
        Me.nudFileLogEntries.Size = New System.Drawing.Size(130, 32)
        Me.nudFileLogEntries.TabIndex = 3
        '
        'lblFileLogSize
        '
        Me.lblFileLogSize.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFileLogSize.Location = New System.Drawing.Point(3, 80)
        Me.lblFileLogSize.Name = "lblFileLogSize"
        Me.lblFileLogSize.Size = New System.Drawing.Size(884, 40)
        Me.lblFileLogSize.TabIndex = 4
        Me.lblFileLogSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nudFileLogSize
        '
        Me.nudFileLogSize.Location = New System.Drawing.Point(893, 83)
        Me.nudFileLogSize.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.nudFileLogSize.Name = "nudFileLogSize"
        Me.nudFileLogSize.Size = New System.Drawing.Size(130, 32)
        Me.nudFileLogSize.TabIndex = 5
        Me.nudFileLogSize.ThousandsSeparator = True
        '
        'cardMisc
        '
        Me.cardMisc.Controls.Add(Me.tblMisc)
        Me.cardMisc.Dock = System.Windows.Forms.DockStyle.Top
        Me.cardMisc.Location = New System.Drawing.Point(16, 506)
        Me.cardMisc.Name = "cardMisc"
        Me.cardMisc.Padding = New System.Windows.Forms.Padding(16, 4, 16, 20)
        Me.cardMisc.Size = New System.Drawing.Size(1142, 178)
        Me.cardMisc.TabIndex = 2
        Me.cardMisc.TabStop = False
        '
        'tblMisc
        '
        Me.tblMisc.AutoSize = True
        Me.tblMisc.ColumnCount = 2
        Me.tblMisc.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblMisc.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220.0!))
        Me.tblMisc.Controls.Add(Me.lblLocalClockDisp, 0, 0)
        Me.tblMisc.Controls.Add(Me.nudLocalClockDisp, 1, 0)
        Me.tblMisc.Controls.Add(Me.lblAuditLimit, 0, 1)
        Me.tblMisc.Controls.Add(Me.nudAuditLimit, 1, 1)
        Me.tblMisc.Dock = System.Windows.Forms.DockStyle.Top
        Me.tblMisc.Location = New System.Drawing.Point(16, 29)
        Me.tblMisc.Name = "tblMisc"
        Me.tblMisc.RowCount = 2
        Me.tblMisc.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblMisc.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblMisc.Size = New System.Drawing.Size(1110, 80)
        Me.tblMisc.TabIndex = 0
        '
        'lblLocalClockDisp
        '
        Me.lblLocalClockDisp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLocalClockDisp.Location = New System.Drawing.Point(3, 0)
        Me.lblLocalClockDisp.Name = "lblLocalClockDisp"
        Me.lblLocalClockDisp.Size = New System.Drawing.Size(884, 40)
        Me.lblLocalClockDisp.TabIndex = 0
        Me.lblLocalClockDisp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nudLocalClockDisp
        '
        Me.nudLocalClockDisp.Location = New System.Drawing.Point(893, 3)
        Me.nudLocalClockDisp.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.nudLocalClockDisp.Name = "nudLocalClockDisp"
        Me.nudLocalClockDisp.Size = New System.Drawing.Size(130, 32)
        Me.nudLocalClockDisp.TabIndex = 1
        Me.nudLocalClockDisp.ThousandsSeparator = True
        '
        'lblAuditLimit
        '
        Me.lblAuditLimit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblAuditLimit.Location = New System.Drawing.Point(3, 40)
        Me.lblAuditLimit.Name = "lblAuditLimit"
        Me.lblAuditLimit.Size = New System.Drawing.Size(884, 40)
        Me.lblAuditLimit.TabIndex = 2
        Me.lblAuditLimit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nudAuditLimit
        '
        Me.nudAuditLimit.Location = New System.Drawing.Point(893, 43)
        Me.nudAuditLimit.Maximum = New Decimal(New Integer() {-294967296, 0, 0, 0})
        Me.nudAuditLimit.Name = "nudAuditLimit"
        Me.nudAuditLimit.Size = New System.Drawing.Size(130, 32)
        Me.nudAuditLimit.TabIndex = 3
        Me.nudAuditLimit.ThousandsSeparator = True
        '
        'cardSpike
        '
        Me.cardSpike.Controls.Add(Me.tblSpike)
        Me.cardSpike.Dock = System.Windows.Forms.DockStyle.Top
        Me.cardSpike.Location = New System.Drawing.Point(16, 282)
        Me.cardSpike.Name = "cardSpike"
        Me.cardSpike.Padding = New System.Windows.Forms.Padding(16, 4, 16, 20)
        Me.cardSpike.Size = New System.Drawing.Size(1142, 224)
        Me.cardSpike.TabIndex = 3
        Me.cardSpike.TabStop = False
        '
        'tblSpike
        '
        Me.tblSpike.AutoSize = True
        Me.tblSpike.ColumnCount = 2
        Me.tblSpike.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblSpike.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220.0!))
        Me.tblSpike.Controls.Add(Me.lblLargePhaseOffset, 0, 0)
        Me.tblSpike.Controls.Add(Me.nudLargePhaseOffset, 1, 0)
        Me.tblSpike.Controls.Add(Me.lblSpikeWatchPeriod, 0, 1)
        Me.tblSpike.Controls.Add(Me.nudSpikeWatchPeriod, 1, 1)
        Me.tblSpike.Controls.Add(Me.lblHoldPeriod, 0, 2)
        Me.tblSpike.Controls.Add(Me.nudHoldPeriod, 1, 2)
        Me.tblSpike.Dock = System.Windows.Forms.DockStyle.Top
        Me.tblSpike.Location = New System.Drawing.Point(16, 29)
        Me.tblSpike.Name = "tblSpike"
        Me.tblSpike.RowCount = 3
        Me.tblSpike.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblSpike.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblSpike.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblSpike.Size = New System.Drawing.Size(1110, 120)
        Me.tblSpike.TabIndex = 0
        '
        'lblLargePhaseOffset
        '
        Me.lblLargePhaseOffset.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblLargePhaseOffset.Location = New System.Drawing.Point(3, 0)
        Me.lblLargePhaseOffset.Name = "lblLargePhaseOffset"
        Me.lblLargePhaseOffset.Size = New System.Drawing.Size(884, 40)
        Me.lblLargePhaseOffset.TabIndex = 0
        Me.lblLargePhaseOffset.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nudLargePhaseOffset
        '
        Me.nudLargePhaseOffset.Location = New System.Drawing.Point(893, 3)
        Me.nudLargePhaseOffset.Maximum = New Decimal(New Integer() {-294967296, 0, 0, 0})
        Me.nudLargePhaseOffset.Name = "nudLargePhaseOffset"
        Me.nudLargePhaseOffset.Size = New System.Drawing.Size(130, 32)
        Me.nudLargePhaseOffset.TabIndex = 1
        Me.nudLargePhaseOffset.ThousandsSeparator = True
        '
        'lblSpikeWatchPeriod
        '
        Me.lblSpikeWatchPeriod.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSpikeWatchPeriod.Location = New System.Drawing.Point(3, 40)
        Me.lblSpikeWatchPeriod.Name = "lblSpikeWatchPeriod"
        Me.lblSpikeWatchPeriod.Size = New System.Drawing.Size(884, 40)
        Me.lblSpikeWatchPeriod.TabIndex = 2
        Me.lblSpikeWatchPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nudSpikeWatchPeriod
        '
        Me.nudSpikeWatchPeriod.Location = New System.Drawing.Point(893, 43)
        Me.nudSpikeWatchPeriod.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.nudSpikeWatchPeriod.Name = "nudSpikeWatchPeriod"
        Me.nudSpikeWatchPeriod.Size = New System.Drawing.Size(130, 32)
        Me.nudSpikeWatchPeriod.TabIndex = 3
        Me.nudSpikeWatchPeriod.ThousandsSeparator = True
        '
        'lblHoldPeriod
        '
        Me.lblHoldPeriod.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblHoldPeriod.Location = New System.Drawing.Point(3, 80)
        Me.lblHoldPeriod.Name = "lblHoldPeriod"
        Me.lblHoldPeriod.Size = New System.Drawing.Size(884, 40)
        Me.lblHoldPeriod.TabIndex = 4
        Me.lblHoldPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nudHoldPeriod
        '
        Me.nudHoldPeriod.Location = New System.Drawing.Point(893, 83)
        Me.nudHoldPeriod.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.nudHoldPeriod.Name = "nudHoldPeriod"
        Me.nudHoldPeriod.Size = New System.Drawing.Size(130, 32)
        Me.nudHoldPeriod.TabIndex = 5
        Me.nudHoldPeriod.ThousandsSeparator = True
        '
        'cardTimeCorrection
        '
        Me.cardTimeCorrection.Controls.Add(Me.tblTimeCorr)
        Me.cardTimeCorrection.Dock = System.Windows.Forms.DockStyle.Top
        Me.cardTimeCorrection.Location = New System.Drawing.Point(16, 12)
        Me.cardTimeCorrection.Name = "cardTimeCorrection"
        Me.cardTimeCorrection.Padding = New System.Windows.Forms.Padding(16, 4, 16, 20)
        Me.cardTimeCorrection.Size = New System.Drawing.Size(1142, 270)
        Me.cardTimeCorrection.TabIndex = 4
        Me.cardTimeCorrection.TabStop = False
        '
        'tblTimeCorr
        '
        Me.tblTimeCorr.AutoSize = True
        Me.tblTimeCorr.ColumnCount = 2
        Me.tblTimeCorr.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblTimeCorr.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220.0!))
        Me.tblTimeCorr.Controls.Add(Me.lblAdvUpdateInterval, 0, 0)
        Me.tblTimeCorr.Controls.Add(Me.nudAdvUpdateInterval, 1, 0)
        Me.tblTimeCorr.Controls.Add(Me.lblFreqCorrectRate, 0, 1)
        Me.tblTimeCorr.Controls.Add(Me.nudFreqCorrectRate, 1, 1)
        Me.tblTimeCorr.Controls.Add(Me.lblPhaseCorrectRate, 0, 2)
        Me.tblTimeCorr.Controls.Add(Me.nudPhaseCorrectRate, 1, 2)
        Me.tblTimeCorr.Controls.Add(Me.lblClockHoldover, 0, 3)
        Me.tblTimeCorr.Controls.Add(Me.nudClockHoldover, 1, 3)
        Me.tblTimeCorr.Dock = System.Windows.Forms.DockStyle.Top
        Me.tblTimeCorr.Location = New System.Drawing.Point(16, 29)
        Me.tblTimeCorr.Name = "tblTimeCorr"
        Me.tblTimeCorr.RowCount = 4
        Me.tblTimeCorr.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblTimeCorr.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblTimeCorr.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblTimeCorr.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.tblTimeCorr.Size = New System.Drawing.Size(1110, 160)
        Me.tblTimeCorr.TabIndex = 0
        '
        'lblAdvUpdateInterval
        '
        Me.lblAdvUpdateInterval.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblAdvUpdateInterval.Location = New System.Drawing.Point(3, 0)
        Me.lblAdvUpdateInterval.Name = "lblAdvUpdateInterval"
        Me.lblAdvUpdateInterval.Size = New System.Drawing.Size(884, 40)
        Me.lblAdvUpdateInterval.TabIndex = 0
        Me.lblAdvUpdateInterval.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nudAdvUpdateInterval
        '
        Me.nudAdvUpdateInterval.Location = New System.Drawing.Point(893, 3)
        Me.nudAdvUpdateInterval.Maximum = New Decimal(New Integer() {-294967296, 0, 0, 0})
        Me.nudAdvUpdateInterval.Name = "nudAdvUpdateInterval"
        Me.nudAdvUpdateInterval.Size = New System.Drawing.Size(130, 32)
        Me.nudAdvUpdateInterval.TabIndex = 1
        Me.nudAdvUpdateInterval.ThousandsSeparator = True
        '
        'lblFreqCorrectRate
        '
        Me.lblFreqCorrectRate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblFreqCorrectRate.Location = New System.Drawing.Point(3, 40)
        Me.lblFreqCorrectRate.Name = "lblFreqCorrectRate"
        Me.lblFreqCorrectRate.Size = New System.Drawing.Size(884, 40)
        Me.lblFreqCorrectRate.TabIndex = 2
        Me.lblFreqCorrectRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nudFreqCorrectRate
        '
        Me.nudFreqCorrectRate.Location = New System.Drawing.Point(893, 43)
        Me.nudFreqCorrectRate.Maximum = New Decimal(New Integer() {-294967296, 0, 0, 0})
        Me.nudFreqCorrectRate.Name = "nudFreqCorrectRate"
        Me.nudFreqCorrectRate.Size = New System.Drawing.Size(130, 32)
        Me.nudFreqCorrectRate.TabIndex = 3
        Me.nudFreqCorrectRate.ThousandsSeparator = True
        '
        'lblPhaseCorrectRate
        '
        Me.lblPhaseCorrectRate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPhaseCorrectRate.Location = New System.Drawing.Point(3, 80)
        Me.lblPhaseCorrectRate.Name = "lblPhaseCorrectRate"
        Me.lblPhaseCorrectRate.Size = New System.Drawing.Size(884, 40)
        Me.lblPhaseCorrectRate.TabIndex = 4
        Me.lblPhaseCorrectRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nudPhaseCorrectRate
        '
        Me.nudPhaseCorrectRate.Location = New System.Drawing.Point(893, 83)
        Me.nudPhaseCorrectRate.Maximum = New Decimal(New Integer() {-294967296, 0, 0, 0})
        Me.nudPhaseCorrectRate.Name = "nudPhaseCorrectRate"
        Me.nudPhaseCorrectRate.Size = New System.Drawing.Size(130, 32)
        Me.nudPhaseCorrectRate.TabIndex = 5
        Me.nudPhaseCorrectRate.ThousandsSeparator = True
        '
        'lblClockHoldover
        '
        Me.lblClockHoldover.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblClockHoldover.Location = New System.Drawing.Point(3, 120)
        Me.lblClockHoldover.Name = "lblClockHoldover"
        Me.lblClockHoldover.Size = New System.Drawing.Size(884, 40)
        Me.lblClockHoldover.TabIndex = 6
        Me.lblClockHoldover.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nudClockHoldover
        '
        Me.nudClockHoldover.Location = New System.Drawing.Point(893, 123)
        Me.nudClockHoldover.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.nudClockHoldover.Name = "nudClockHoldover"
        Me.nudClockHoldover.Size = New System.Drawing.Size(130, 32)
        Me.nudClockHoldover.TabIndex = 7
        Me.nudClockHoldover.ThousandsSeparator = True
        '
        'pageConfigView
        '
        Me.pageConfigView.AutoScroll = True
        Me.pageConfigView.Controls.Add(Me.flpConfigBtns)
        Me.pageConfigView.Controls.Add(Me.cardConfigRaw)
        Me.pageConfigView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pageConfigView.Location = New System.Drawing.Point(0, 0)
        Me.pageConfigView.Name = "pageConfigView"
        Me.pageConfigView.Padding = New System.Windows.Forms.Padding(16, 12, 16, 48)
        Me.pageConfigView.Size = New System.Drawing.Size(1200, 688)
        Me.pageConfigView.TabIndex = 4
        '
        'flpConfigBtns
        '
        Me.flpConfigBtns.Controls.Add(Me.btnRefreshConfig)
        Me.flpConfigBtns.Dock = System.Windows.Forms.DockStyle.Top
        Me.flpConfigBtns.Location = New System.Drawing.Point(16, 474)
        Me.flpConfigBtns.Name = "flpConfigBtns"
        Me.flpConfigBtns.Size = New System.Drawing.Size(1168, 48)
        Me.flpConfigBtns.TabIndex = 0
        Me.flpConfigBtns.WrapContents = False
        '
        'btnRefreshConfig
        '
        Me.btnRefreshConfig.AutoSize = True
        Me.btnRefreshConfig.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnRefreshConfig.Location = New System.Drawing.Point(0, 8)
        Me.btnRefreshConfig.Margin = New System.Windows.Forms.Padding(0, 8, 8, 0)
        Me.btnRefreshConfig.MinimumSize = New System.Drawing.Size(90, 32)
        Me.btnRefreshConfig.Name = "btnRefreshConfig"
        Me.btnRefreshConfig.Size = New System.Drawing.Size(90, 32)
        Me.btnRefreshConfig.TabIndex = 0
        '
        'cardConfigRaw
        '
        Me.cardConfigRaw.Controls.Add(Me.tblConfigRaw)
        Me.cardConfigRaw.Dock = System.Windows.Forms.DockStyle.Top
        Me.cardConfigRaw.Location = New System.Drawing.Point(16, 12)
        Me.cardConfigRaw.Name = "cardConfigRaw"
        Me.cardConfigRaw.Padding = New System.Windows.Forms.Padding(16, 4, 16, 20)
        Me.cardConfigRaw.Size = New System.Drawing.Size(1168, 462)
        Me.cardConfigRaw.TabIndex = 1
        Me.cardConfigRaw.TabStop = False
        '
        'tblConfigRaw
        '
        Me.tblConfigRaw.ColumnCount = 1
        Me.tblConfigRaw.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblConfigRaw.Controls.Add(Me.rtbConfigView, 0, 0)
        Me.tblConfigRaw.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tblConfigRaw.Location = New System.Drawing.Point(16, 29)
        Me.tblConfigRaw.Name = "tblConfigRaw"
        Me.tblConfigRaw.RowCount = 1
        Me.tblConfigRaw.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tblConfigRaw.Size = New System.Drawing.Size(1136, 413)
        Me.tblConfigRaw.TabIndex = 0
        '
        'rtbConfigView
        '
        Me.rtbConfigView.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbConfigView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbConfigView.Font = New System.Drawing.Font("Consolas", 9.5!)
        Me.rtbConfigView.Location = New System.Drawing.Point(3, 3)
        Me.rtbConfigView.Name = "rtbConfigView"
        Me.rtbConfigView.ReadOnly = True
        Me.rtbConfigView.Size = New System.Drawing.Size(1130, 407)
        Me.rtbConfigView.TabIndex = 0
        Me.rtbConfigView.Text = ""
        Me.rtbConfigView.WordWrap = False
        '
        'pnlTabStrip
        '
        Me.pnlTabStrip.Controls.Add(Me.cboLanguage)
        Me.pnlTabStrip.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTabStrip.Location = New System.Drawing.Point(0, 0)
        Me.pnlTabStrip.Name = "pnlTabStrip"
        Me.pnlTabStrip.Size = New System.Drawing.Size(1200, 40)
        Me.pnlTabStrip.TabIndex = 3
        '
        'cboLanguage
        '
        Me.cboLanguage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboLanguage.Items.AddRange(New Object() {"English", "日本語", "Deutsch", "Español", "Français", "Italiano", "한국어", "Português (Brasil)", "Русский", "中文"})
        Me.cboLanguage.Location = New System.Drawing.Point(1820, 6)
        Me.cboLanguage.Name = "cboLanguage"
        Me.cboLanguage.Size = New System.Drawing.Size(150, 33)
        Me.cboLanguage.TabIndex = 0
        '
        'pnlInfoBar
        '
        Me.pnlInfoBar.Controls.Add(Me.lblInfoStatus)
        Me.pnlInfoBar.Controls.Add(Me.lblInfoDetails)
        Me.pnlInfoBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlInfoBar.Location = New System.Drawing.Point(0, 40)
        Me.pnlInfoBar.Name = "pnlInfoBar"
        Me.pnlInfoBar.Size = New System.Drawing.Size(1200, 32)
        Me.pnlInfoBar.TabIndex = 4
        '
        'lblInfoStatus
        '
        Me.lblInfoStatus.AutoSize = True
        Me.lblInfoStatus.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!)
        Me.lblInfoStatus.Location = New System.Drawing.Point(8, 0)
        Me.lblInfoStatus.Name = "lblInfoStatus"
        Me.lblInfoStatus.Size = New System.Drawing.Size(0, 25)
        Me.lblInfoStatus.TabIndex = 0
        Me.lblInfoStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInfoDetails
        '
        Me.lblInfoDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblInfoDetails.Location = New System.Drawing.Point(130, 0)
        Me.lblInfoDetails.Name = "lblInfoDetails"
        Me.lblInfoDetails.Size = New System.Drawing.Size(1700, 32)
        Me.lblInfoDetails.TabIndex = 1
        Me.lblInfoDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MainForm
        '
        Me.ClientSize = New System.Drawing.Size(1200, 760)
        Me.Controls.Add(Me.stsMain)
        Me.Controls.Add(Me.pnlContent)
        Me.Controls.Add(Me.pnlInfoBar)
        Me.Controls.Add(Me.pnlTabStrip)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.25!)
        Me.MinimumSize = New System.Drawing.Size(640, 480)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NTPilot"
        Me.stsMain.ResumeLayout(False)
        Me.stsMain.PerformLayout()
        Me.pnlContent.ResumeLayout(False)
        Me.pageStatus.ResumeLayout(False)
        Me.cardPeers.ResumeLayout(False)
        Me.tblPeers.ResumeLayout(False)
        CType(Me.dgvPeers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cardNtpStatus.ResumeLayout(False)
        Me.tblNtpStatus.ResumeLayout(False)
        Me.tblNtpStatus.PerformLayout()
        CType(Me.dgvStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flpStatusBtns.ResumeLayout(False)
        Me.flpStatusBtns.PerformLayout()
        Me.cardService.ResumeLayout(False)
        Me.cardService.PerformLayout()
        Me.tblService.ResumeLayout(False)
        Me.tblService.PerformLayout()
        Me.flpServiceBtns.ResumeLayout(False)
        Me.flpServiceBtns.PerformLayout()
        Me.pageClient.ResumeLayout(False)
        Me.flpClientBtns.ResumeLayout(False)
        Me.flpClientBtns.PerformLayout()
        Me.cardCrossSite.ResumeLayout(False)
        Me.cardCrossSite.PerformLayout()
        Me.tblCrossSite.ResumeLayout(False)
        CType(Me.nudBackOffMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudBackOffMax, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cardPolling.ResumeLayout(False)
        Me.cardPolling.PerformLayout()
        Me.tblPolling.ResumeLayout(False)
        CType(Me.nudUpdateInterval, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMinPoll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMaxPoll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cardFlags.ResumeLayout(False)
        Me.cardFlags.PerformLayout()
        Me.tblFlags.ResumeLayout(False)
        Me.cardClientBasic.ResumeLayout(False)
        Me.cardClientBasic.PerformLayout()
        Me.tblClientBasic.ResumeLayout(False)
        Me.tblClientBasic.PerformLayout()
        Me.pageServer.ResumeLayout(False)
        Me.flpServerBtns.ResumeLayout(False)
        Me.flpServerBtns.PerformLayout()
        Me.cardChain.ResumeLayout(False)
        Me.cardChain.PerformLayout()
        Me.tblChain.ResumeLayout(False)
        CType(Me.nudChainEntryTimeout, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cardPhase.ResumeLayout(False)
        Me.cardPhase.PerformLayout()
        Me.tblPhase.ResumeLayout(False)
        CType(Me.nudMaxPosPhase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMaxNegPhase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMaxPhaseOffset, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cardServerBasic.ResumeLayout(False)
        Me.cardServerBasic.PerformLayout()
        Me.tblServerBasic.ResumeLayout(False)
        Me.pageAdvanced.ResumeLayout(False)
        Me.flpAdvancedBtns.ResumeLayout(False)
        Me.flpAdvancedBtns.PerformLayout()
        Me.cardLogging.ResumeLayout(False)
        Me.cardLogging.PerformLayout()
        Me.tblLogging.ResumeLayout(False)
        Me.pnlLogPath.ResumeLayout(False)
        Me.pnlLogPath.PerformLayout()
        CType(Me.nudFileLogEntries, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudFileLogSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cardMisc.ResumeLayout(False)
        Me.cardMisc.PerformLayout()
        Me.tblMisc.ResumeLayout(False)
        CType(Me.nudLocalClockDisp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAuditLimit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cardSpike.ResumeLayout(False)
        Me.cardSpike.PerformLayout()
        Me.tblSpike.ResumeLayout(False)
        CType(Me.nudLargePhaseOffset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudSpikeWatchPeriod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudHoldPeriod, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cardTimeCorrection.ResumeLayout(False)
        Me.cardTimeCorrection.PerformLayout()
        Me.tblTimeCorr.ResumeLayout(False)
        CType(Me.nudAdvUpdateInterval, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudFreqCorrectRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudPhaseCorrectRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudClockHoldover, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pageConfigView.ResumeLayout(False)
        Me.flpConfigBtns.ResumeLayout(False)
        Me.flpConfigBtns.PerformLayout()
        Me.cardConfigRaw.ResumeLayout(False)
        Me.tblConfigRaw.ResumeLayout(False)
        Me.pnlTabStrip.ResumeLayout(False)
        Me.pnlInfoBar.ResumeLayout(False)
        Me.pnlInfoBar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PeerServer As DataGridViewTextBoxColumn
    Friend WithEvents PeerState As DataGridViewTextBoxColumn
    Friend WithEvents PeerStratum As DataGridViewTextBoxColumn
    Friend WithEvents PeerOffset As DataGridViewTextBoxColumn
    Friend WithEvents PeerRootDelay As DataGridViewTextBoxColumn
    Friend WithEvents PeerRootDisp As DataGridViewTextBoxColumn
    Friend WithEvents Key As DataGridViewTextBoxColumn
    Friend WithEvents Value As DataGridViewTextBoxColumn
End Class
