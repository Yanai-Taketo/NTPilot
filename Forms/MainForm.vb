Imports System.Drawing
Imports System.Linq
Imports System.ServiceProcess
Imports System.Windows.Forms
Imports System.Reflection

''' <summary>
''' Main application window – compact admin tool style with top tab strip.
''' Top tab strip selects the active page; content panel shows cards.
''' </summary>
Partial Class MainForm
    Inherits Form

    Private _selectedPage As Integer = 0
    Private _statusLoaded As Boolean = False
    ' Tab items – created outside InitializeComponent (custom controls not supported by designer)
    Private tabItems(4) As TabItemPanel

    ' ------------------------------------------------------------------ Startup

    Public Sub New()
        InitializeComponent()
        InitTabItems()
    End Sub

    Private Sub InitTabItems()
        Const tabWidth As Integer = 120
        For i As Integer = 0 To 4
            tabItems(i) = New TabItemPanel("")
            tabItems(i).Width = tabWidth
            tabItems(i).Dock = DockStyle.Left
            AddHandler tabItems(i).Click, AddressOf TabItem_Clicked
        Next
        ' Dock=Left: last added = rightmost. Add 4→0 so Status(0) is leftmost.
        For i As Integer = 4 To 0 Step -1
            pnlTabStrip.Controls.Add(tabItems(i))
        Next
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Dark title bar
        ThemeManager.ApplyTitleBar(Handle)

        ' App icon – extract from the embedded EXE resource (set via ApplicationIcon in vbproj)
        Try
            Me.Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location)
        Catch
        End Try

        ' Apply language selector
        cboLanguage.SelectedIndex = LangManager.CurrentIndex()

        ApplyTheme()
        ApplyStrings()

        ' Show status page by default
        ShowPage(0)

        ' Register for system theme changes (WM_SETTINGCHANGE handled in WndProc)
    End Sub

    Private Sub MainForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If _selectedPage = 0 Then RefreshStatusPage()
    End Sub

    ' ------------------------------------------------------------------ WndProc: theme change

    Protected Overrides Sub WndProc(ByRef m As Message)
        MyBase.WndProc(m)
        ' WM_SETTINGCHANGE = 0x001A  (system settings changed, including dark mode)
        If m.Msg = &H1A Then
            ThemeManager.ApplyTitleBar(Handle)
            ApplyTheme()
        End If
    End Sub

    ' ------------------------------------------------------------------ Navigation

    Private Sub TabItem_Clicked(sender As Object, e As EventArgs)
        Dim tab = TryCast(sender, TabItemPanel)
        If tab Is Nothing Then Return
        For i As Integer = 0 To tabItems.Length - 1
            If tabItems(i) Is tab Then
                ShowPage(i)
                Return
            End If
        Next
    End Sub

    Private Sub ShowPage(index As Integer)
        _selectedPage = index
        ' Update tab selection
        For i As Integer = 0 To tabItems.Length - 1
            tabItems(i).IsSelected = (i = index)
        Next
        ' Show the correct page panel
        Dim pages() As Panel = {pageStatus, pageClient, pageServer, pageAdvanced, pageConfigView}
        For Each p In pages
            p.Visible = False
        Next
        pages(index).Visible = True
        pages(index).BringToFront()

        ' Lazy-load data on first visit
        Select Case index
            Case 0 : If Not _statusLoaded Then RefreshStatusPage()
            Case 1 : LoadClientPage()
            Case 2 : LoadServerPage()
            Case 3 : LoadAdvancedPage()
            Case 4 : LoadConfigViewPage()
        End Select
    End Sub

    ' ------------------------------------------------------------------ Theme

    Private Sub ApplyTheme()
        Me.BackColor = ThemeManager.BgColor

        ' Tab strip and info bar
        pnlTabStrip.BackColor = ThemeManager.NavBgColor
        pnlInfoBar.BackColor = ThemeManager.NavBgColor
        lblInfoStatus.BackColor = Color.Transparent
        lblInfoStatus.ForeColor = ThemeManager.TextPrimaryColor
        lblInfoDetails.BackColor = Color.Transparent
        lblInfoDetails.ForeColor = ThemeManager.TextSecondaryColor

        ' Tab items repaint
        For Each ti As TabItemPanel In tabItems
            ti.Invalidate()
        Next

        ' Language combo
        cboLanguage.BackColor = ThemeManager.InputBgColor
        cboLanguage.ForeColor = ThemeManager.InputForeColor

        ' Content area
        pnlContent.BackColor = ThemeManager.BgColor
        For Each page As Panel In {pageStatus, pageClient, pageServer, pageAdvanced, pageConfigView}
            page.BackColor = ThemeManager.BgColor
        Next

        ' All cards and their children
        ThemeManager.ApplyToControl(pageStatus)
        ThemeManager.ApplyToControl(pageClient)
        ThemeManager.ApplyToControl(pageServer)
        ThemeManager.ApplyToControl(pageAdvanced)
        ThemeManager.ApplyToControl(pageConfigView)

        ' Cards need to repaint
        For Each card As GroupBox In GetAllCards()
            card.Invalidate()
        Next

        ' Status strip
        stsMain.BackColor = ThemeManager.NavBgColor
        tsslStatus.ForeColor = ThemeManager.TextSecondaryColor
    End Sub

    Private Function GetAllCards() As IEnumerable(Of GroupBox)
        Dim result As New List(Of GroupBox)
        For Each page As Panel In {pageStatus, pageClient, pageServer, pageAdvanced, pageConfigView}
            For Each ctrl As Control In page.Controls
                If TypeOf ctrl Is GroupBox Then result.Add(DirectCast(ctrl, GroupBox))
            Next
        Next
        Return result
    End Function

    ' ------------------------------------------------------------------ Localization

    Private Sub ApplyStrings()
        ' Tab items
        tabItems(0).TabText = Strings.T("Nav.Status")
        tabItems(1).TabText = Strings.T("Nav.Client")
        tabItems(2).TabText = Strings.T("Nav.Server")
        tabItems(3).TabText = Strings.T("Nav.Advanced")
        tabItems(4).TabText = Strings.T("Nav.ConfigView")
        For Each ti As TabItemPanel In tabItems
            ti.Invalidate()
        Next

        ' Card titles
        cardService.Text = Strings.T("Status.Card.Service")
        cardNtpStatus.Text = Strings.T("Status.Card.NtpStatus")
        cardPeers.Text = Strings.T("Status.Card.Peers")
        cardClientBasic.Text = Strings.T("Client.Card.Basic")
        cardFlags.Text = Strings.T("Client.Card.Flags")
        cardPolling.Text = Strings.T("Client.Card.Polling")
        cardCrossSite.Text = Strings.T("Client.Card.CrossSite")
        cardServerBasic.Text = Strings.T("Server.Card.Basic")
        cardPhase.Text = Strings.T("Server.Card.Phase")
        cardChain.Text = Strings.T("Server.Card.Chain")
        cardTimeCorrection.Text = Strings.T("Advanced.Card.TimeCorrection")
        cardSpike.Text = Strings.T("Advanced.Card.Spike")
        cardMisc.Text = Strings.T("Advanced.Card.Misc")
        cardLogging.Text = Strings.T("Advanced.Card.Logging")
        cardConfigRaw.Text = Strings.T("ConfigView.Card.Raw")

        ' Status page labels
        lblServiceStatusLbl.Text = Strings.T("Status.ServiceStatus")
        dgvStatus.Columns("Key").HeaderText = Strings.T("Status.Col.Key")
        dgvStatus.Columns("Value").HeaderText = Strings.T("Status.Col.Value")
        dgvPeers.Columns("PeerServer").HeaderText = Strings.T("Status.Col.Server")
        dgvPeers.Columns("PeerState").HeaderText = Strings.T("Status.Col.State")
        dgvPeers.Columns("PeerStratum").HeaderText = Strings.T("Status.Col.Stratum")
        dgvPeers.Columns("PeerOffset").HeaderText = Strings.T("Status.Col.Offset")
        dgvPeers.Columns("PeerRootDelay").HeaderText = Strings.T("Status.Col.RootDelay")
        dgvPeers.Columns("PeerRootDisp").HeaderText = Strings.T("Status.Col.RootDisp")
        btnStart.Text = Strings.T("Status.BtnStart")
        btnStop.Text = Strings.T("Status.BtnStop")
        btnRestart.Text = Strings.T("Status.BtnRestart")
        btnSyncNow.Text = Strings.T("Status.BtnSyncNow")
        btnRefreshStatus.Text = Strings.T("Status.BtnRefresh")

        ' Client page labels
        chkClientEnabled.Text = Strings.T("Client.Enabled")
        lblSyncType.Text = Strings.T("Client.SyncType")
        lblNtpServers.Text = Strings.T("Client.NtpServers")
        chkFlag8.Text = Strings.T("Client.Flag8")
        chkFlag4.Text = Strings.T("Client.Flag4")
        chkFlag1.Text = Strings.T("Client.Flag1")
        lblCombinedFlagLbl.Text = Strings.T("Client.CombinedFlag")
        lblUpdateInterval.Text = Strings.T("Client.UpdateInterval")
        lblMinPoll.Text = Strings.T("Client.MinPoll")
        lblMaxPoll.Text = Strings.T("Client.MaxPoll")
        chkCrossSiteSync.Text = Strings.T("Client.CrossSiteSync")
        lblBackOffMin.Text = Strings.T("Client.BackOffMinutes")
        lblBackOffMax.Text = Strings.T("Client.BackOffMaxTimes")
        btnApplyClient.Text = Strings.T("Btn.Apply")
        btnResetClient.Text = Strings.T("Btn.Reset")

        ' Server page labels
        chkServerEnabled.Text = Strings.T("Server.Enabled")
        lblAnnounceFlags.Text = Strings.T("Server.AnnounceFlags")
        chkSecureOnly.Text = Strings.T("Server.SecureOnly")
        lblMaxPosPhase.Text = Strings.T("Server.MaxPosPhase")
        lblMaxNegPhase.Text = Strings.T("Server.MaxNegPhase")
        lblMaxPhaseOffset.Text = Strings.T("Server.MaxPhaseOffset")
        lblChainEntryTimeout.Text = Strings.T("Server.ChainEntryTimeout")
        btnApplyServer.Text = Strings.T("Btn.Apply")
        btnResetServer.Text = Strings.T("Btn.Reset")

        ' Advanced page labels
        lblAdvUpdateInterval.Text = Strings.T("Advanced.UpdateInterval")
        lblFreqCorrectRate.Text = Strings.T("Advanced.FreqCorrectRate")
        lblPhaseCorrectRate.Text = Strings.T("Advanced.PhaseCorrectRate")
        lblClockHoldover.Text = Strings.T("Advanced.ClockHoldoverPeriod")
        lblLargePhaseOffset.Text = Strings.T("Advanced.LargePhaseOffset")
        lblSpikeWatchPeriod.Text = Strings.T("Advanced.SpikeWatchPeriod")
        lblHoldPeriod.Text = Strings.T("Advanced.HoldPeriod")
        lblLocalClockDisp.Text = Strings.T("Advanced.LocalClockDispersion")
        lblAuditLimit.Text = Strings.T("Advanced.AuditLimit")
        lblFileLogName.Text = Strings.T("Advanced.FileLogName")
        lblFileLogEntries.Text = Strings.T("Advanced.FileLogEntries")
        lblFileLogSize.Text = Strings.T("Advanced.FileLogSize")
        btnBrowseLog.Text = Strings.T("Btn.Browse")
        btnApplyAdvanced.Text = Strings.T("Btn.Apply")
        btnResetAdvanced.Text = Strings.T("Btn.Reset")

        ' Config View
        btnRefreshConfig.Text = Strings.T("Btn.Refresh")

        ' Status bar
        tsslStatus.Text = Strings.T("StatusBar.Ready")

        ' Window title
        Me.Text = Strings.T("App.Title")

        ApplyTooltips()
    End Sub

    Private Sub ApplyTooltips()
        ' Client page
        tipMain.SetToolTip(chkClientEnabled, Strings.T("Tip.Client.Enabled"))
        tipMain.SetToolTip(lblSyncType, Strings.T("Tip.Client.SyncType"))
        tipMain.SetToolTip(cboSyncType, Strings.T("Tip.Client.SyncType"))
        tipMain.SetToolTip(lblNtpServers, Strings.T("Tip.Client.NtpServers"))
        tipMain.SetToolTip(txtNtpServers, Strings.T("Tip.Client.NtpServers"))
        tipMain.SetToolTip(chkFlag8, Strings.T("Tip.Client.Flag8"))
        tipMain.SetToolTip(chkFlag4, Strings.T("Tip.Client.Flag4"))
        tipMain.SetToolTip(chkFlag1, Strings.T("Tip.Client.Flag1"))
        tipMain.SetToolTip(lblUpdateInterval, Strings.T("Tip.Client.UpdateInterval"))
        tipMain.SetToolTip(nudUpdateInterval, Strings.T("Tip.Client.UpdateInterval"))
        tipMain.SetToolTip(lblMinPoll, Strings.T("Tip.Client.MinPoll"))
        tipMain.SetToolTip(nudMinPoll, Strings.T("Tip.Client.MinPoll"))
        tipMain.SetToolTip(lblMaxPoll, Strings.T("Tip.Client.MaxPoll"))
        tipMain.SetToolTip(nudMaxPoll, Strings.T("Tip.Client.MaxPoll"))
        tipMain.SetToolTip(chkCrossSiteSync, Strings.T("Tip.Client.CrossSiteSync"))
        tipMain.SetToolTip(lblBackOffMin, Strings.T("Tip.Client.BackOffMinutes"))
        tipMain.SetToolTip(nudBackOffMin, Strings.T("Tip.Client.BackOffMinutes"))
        tipMain.SetToolTip(lblBackOffMax, Strings.T("Tip.Client.BackOffMaxTimes"))
        tipMain.SetToolTip(nudBackOffMax, Strings.T("Tip.Client.BackOffMaxTimes"))
        ' Server page
        tipMain.SetToolTip(chkServerEnabled, Strings.T("Tip.Server.Enabled"))
        tipMain.SetToolTip(lblAnnounceFlags, Strings.T("Tip.Server.AnnounceFlags"))
        tipMain.SetToolTip(cboAnnounceFlags, Strings.T("Tip.Server.AnnounceFlags"))
        tipMain.SetToolTip(chkSecureOnly, Strings.T("Tip.Server.SecureOnly"))
        tipMain.SetToolTip(lblMaxPosPhase, Strings.T("Tip.Server.MaxPosPhase"))
        tipMain.SetToolTip(nudMaxPosPhase, Strings.T("Tip.Server.MaxPosPhase"))
        tipMain.SetToolTip(lblMaxNegPhase, Strings.T("Tip.Server.MaxNegPhase"))
        tipMain.SetToolTip(nudMaxNegPhase, Strings.T("Tip.Server.MaxNegPhase"))
        tipMain.SetToolTip(lblMaxPhaseOffset, Strings.T("Tip.Server.MaxPhaseOffset"))
        tipMain.SetToolTip(nudMaxPhaseOffset, Strings.T("Tip.Server.MaxPhaseOffset"))
        tipMain.SetToolTip(lblChainEntryTimeout, Strings.T("Tip.Server.ChainEntryTimeout"))
        tipMain.SetToolTip(nudChainEntryTimeout, Strings.T("Tip.Server.ChainEntryTimeout"))
        ' Advanced page
        tipMain.SetToolTip(lblAdvUpdateInterval, Strings.T("Tip.Advanced.UpdateInterval"))
        tipMain.SetToolTip(nudAdvUpdateInterval, Strings.T("Tip.Advanced.UpdateInterval"))
        tipMain.SetToolTip(lblFreqCorrectRate, Strings.T("Tip.Advanced.FreqCorrectRate"))
        tipMain.SetToolTip(nudFreqCorrectRate, Strings.T("Tip.Advanced.FreqCorrectRate"))
        tipMain.SetToolTip(lblPhaseCorrectRate, Strings.T("Tip.Advanced.PhaseCorrectRate"))
        tipMain.SetToolTip(nudPhaseCorrectRate, Strings.T("Tip.Advanced.PhaseCorrectRate"))
        tipMain.SetToolTip(lblClockHoldover, Strings.T("Tip.Advanced.ClockHoldoverPeriod"))
        tipMain.SetToolTip(nudClockHoldover, Strings.T("Tip.Advanced.ClockHoldoverPeriod"))
        tipMain.SetToolTip(lblLargePhaseOffset, Strings.T("Tip.Advanced.LargePhaseOffset"))
        tipMain.SetToolTip(nudLargePhaseOffset, Strings.T("Tip.Advanced.LargePhaseOffset"))
        tipMain.SetToolTip(lblSpikeWatchPeriod, Strings.T("Tip.Advanced.SpikeWatchPeriod"))
        tipMain.SetToolTip(nudSpikeWatchPeriod, Strings.T("Tip.Advanced.SpikeWatchPeriod"))
        tipMain.SetToolTip(lblHoldPeriod, Strings.T("Tip.Advanced.HoldPeriod"))
        tipMain.SetToolTip(nudHoldPeriod, Strings.T("Tip.Advanced.HoldPeriod"))
        tipMain.SetToolTip(lblLocalClockDisp, Strings.T("Tip.Advanced.LocalClockDispersion"))
        tipMain.SetToolTip(nudLocalClockDisp, Strings.T("Tip.Advanced.LocalClockDispersion"))
        tipMain.SetToolTip(lblAuditLimit, Strings.T("Tip.Advanced.AuditLimit"))
        tipMain.SetToolTip(nudAuditLimit, Strings.T("Tip.Advanced.AuditLimit"))
        tipMain.SetToolTip(lblFileLogName, Strings.T("Tip.Advanced.FileLogName"))
        tipMain.SetToolTip(txtFileLogName, Strings.T("Tip.Advanced.FileLogName"))
        tipMain.SetToolTip(lblFileLogEntries, Strings.T("Tip.Advanced.FileLogEntries"))
        tipMain.SetToolTip(nudFileLogEntries, Strings.T("Tip.Advanced.FileLogEntries"))
        tipMain.SetToolTip(lblFileLogSize, Strings.T("Tip.Advanced.FileLogSize"))
        tipMain.SetToolTip(nudFileLogSize, Strings.T("Tip.Advanced.FileLogSize"))
    End Sub

    ' ------------------------------------------------------------------ Language change

    Private Sub CboLanguage_Changed(sender As Object, e As EventArgs) Handles cboLanguage.SelectedIndexChanged
        Dim idx = cboLanguage.SelectedIndex
        If idx >= 0 AndAlso idx < LangManager.SupportedLanguages.Length Then
            LangManager.SetLanguage(LangManager.SupportedLanguages(idx))
            ApplyStrings()
        End If
    End Sub

    ' ------------------------------------------------------------------ Status page data

    Private Sub RefreshStatusPage()
        SetStatus(Strings.T("StatusBar.Refreshing"))
        Try
            ' Service status
            Dim svcStatus = W32TimeHelper.GetServiceStatus()
            Dim statusText As String
            Dim statusColor As Color
            Select Case svcStatus
                Case ServiceControllerStatus.Running
                    statusText = Strings.T("Status.Running")
                    statusColor = ThemeManager.StatusRunningColor
                Case ServiceControllerStatus.Stopped, ServiceControllerStatus.StopPending
                    statusText = Strings.T("Status.Stopped")
                    statusColor = ThemeManager.StatusStoppedColor
                Case Else
                    statusText = svcStatus.ToString()
                    statusColor = ThemeManager.StatusUnknownColor
            End Select
            lblServiceStatusVal.Text = "  ● " & statusText
            lblServiceStatusVal.ForeColor = statusColor

            ' Info bar: always-visible NTP status summary
            lblInfoStatus.Text = "  ● " & statusText
            lblInfoStatus.ForeColor = statusColor

            ' NTP status key-value
            dgvStatus.Rows.Clear()
            Dim statusRows = W32TimeHelper.QueryStatus()
            For Each kvp In statusRows
                dgvStatus.Rows.Add(kvp.Key, kvp.Value)
            Next

            ' Info bar details: sync source
            Dim sourceKvp = statusRows.FirstOrDefault(Function(k) k.Key.Contains("Source") OrElse k.Key.Contains("ソース"))
            lblInfoDetails.Text = If(sourceKvp.Key IsNot Nothing, "  " & sourceKvp.Value, "")
            ' Resize NTP status card to show all rows without internal scrolling
            Dim dgvH As Integer = dgvStatus.ColumnHeadersHeight
            For Each row As DataGridViewRow In dgvStatus.Rows
                dgvH += row.Height
            Next
            dgvH += 10  ' bottom border + DPI margin
            dgvStatus.ScrollBars = ScrollBars.None
            tblNtpStatus.RowStyles(0) = New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, CSng(dgvH))
            Dim btnRowH As Integer = CInt(tblNtpStatus.RowStyles(1).Height)
            tblNtpStatus.Height = dgvH + btnRowH
            ' GroupBox overhead: title height + Padding.Top + Padding.Bottom (generous margin for DPI variations)
            cardNtpStatus.Height = tblNtpStatus.Height + 60

            ' Peers
            dgvPeers.Rows.Clear()
            For Each peer In W32TimeHelper.QueryPeers()
                dgvPeers.Rows.Add(peer.Server, peer.State, peer.Stratum,
                                   peer.Offset, peer.RootDelay, peer.RootDispersion)
            Next

            _statusLoaded = True
        Catch ex As Exception
            SetStatus(ex.Message)
        Finally
            SetStatus(Strings.T("StatusBar.Ready"))
        End Try
        ' Reset scroll to top after data load (DGV focus can cause AutoScroll to jump)
        pageStatus.AutoScrollPosition = New Point(0, 0)
    End Sub

    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        RunServiceAction(AddressOf W32TimeHelper.StartService, "Start")
    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        RunServiceAction(AddressOf W32TimeHelper.StopService, "Stop")
    End Sub

    Private Sub BtnRestart_Click(sender As Object, e As EventArgs) Handles btnRestart.Click
        RunServiceAction(AddressOf W32TimeHelper.RestartService, "Restart")
    End Sub

    Private Sub RunServiceAction(action As Action, name As String)
        Try
            SetStatus(Strings.T("StatusBar.Applying"))
            action()
            Threading.Thread.Sleep(500)
            RefreshStatusPage()
        Catch ex As Exception
            MessageBox.Show(Strings.T("Msg.ServiceError") & " " & ex.Message,
                Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SetStatus(Strings.T("StatusBar.Ready"))
        End Try
    End Sub

    Private Sub BtnSyncNow_Click(sender As Object, e As EventArgs) Handles btnSyncNow.Click
        Try
            SetStatus(Strings.T("StatusBar.Applying"))
            Dim result = W32TimeHelper.ResyncForce()
            SetStatus(Strings.T("Msg.SyncStarted") & "  " & result.Trim())
            Threading.Thread.Sleep(1000)
            RefreshStatusPage()
        Catch ex As Exception
            MessageBox.Show(Strings.T("Msg.ServiceError") & " " & ex.Message,
                Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            SetStatus(Strings.T("StatusBar.Ready"))
        End Try
    End Sub

    Private Sub BtnRefreshStatus_Click(sender As Object, e As EventArgs) Handles btnRefreshStatus.Click
        _statusLoaded = False
        RefreshStatusPage()
    End Sub

    ' ------------------------------------------------------------------ Client page data

    Private Sub LoadClientPage()
        ' Enabled
        chkClientEnabled.Checked = (RegistryHelper.GetDWord(RegistryHelper.NtpClientPath, "Enabled", 1) = 1)

        ' Sync Type
        Dim syncType = RegistryHelper.GetString(RegistryHelper.ParamsPath, "Type", "NTP")
        Dim syncIdx = cboSyncType.Items.IndexOf(syncType)
        cboSyncType.SelectedIndex = If(syncIdx >= 0, syncIdx, 0)

        ' NTP Servers
        txtNtpServers.Text = RegistryHelper.GetString(RegistryHelper.ParamsPath, "NtpServer", "")

        ' Flags (parse from first server entry)
        Dim serverStr = txtNtpServers.Text
        Dim flags As Integer = 0
        Dim firstServer = serverStr.Split(" "c)(0)
        Dim commaIdx = firstServer.LastIndexOf(",")
        If commaIdx >= 0 Then
            Try
                flags = Convert.ToInt32(firstServer.Substring(commaIdx + 1), 16)
            Catch
                Integer.TryParse(firstServer.Substring(commaIdx + 1), flags)
            End Try
        End If
        chkFlag8.Checked = (flags And &H8) <> 0
        chkFlag4.Checked = (flags And &H4) <> 0
        chkFlag1.Checked = (flags And &H1) <> 0
        UpdateCombinedFlag()

        ' Polling
        nudUpdateInterval.Value = RegistryHelper.GetDWord(RegistryHelper.ConfigPath, "UpdateInterval", 100)
        nudMinPoll.Value = Math.Min(nudMinPoll.Maximum,
            RegistryHelper.GetDWord(RegistryHelper.NtpClientPath, "SpecialPollInterval", 3600))
        nudMaxPoll.Value = Math.Min(nudMaxPoll.Maximum,
            RegistryHelper.GetDWord(RegistryHelper.ConfigPath, "MaxPollInterval", 10))

        ' Cross-site
        chkCrossSiteSync.Checked = (RegistryHelper.GetDWord(RegistryHelper.ParamsPath, "CrossSiteSyncFlags", 3) <> 0)
        nudBackOffMin.Value = RegistryHelper.GetDWord(RegistryHelper.NtpClientPath, "ResolvePeerBackOffMinutes", 15)
        nudBackOffMax.Value = RegistryHelper.GetDWord(RegistryHelper.NtpClientPath, "ResolvePeerBackOffMaxTimes", 7)
    End Sub

    Private Sub FlagCheck_Changed(sender As Object, e As EventArgs) Handles chkFlag8.CheckedChanged, chkFlag4.CheckedChanged, chkFlag1.CheckedChanged
        UpdateCombinedFlag()
    End Sub

    Private Sub UpdateCombinedFlag()
        Dim combined As Integer = 0
        If chkFlag8.Checked Then combined = combined Or &H8
        If chkFlag4.Checked Then combined = combined Or &H4
        If chkFlag1.Checked Then combined = combined Or &H1
        lblCombinedFlagVal.Text = "0x" & combined.ToString("X")
    End Sub

    Private Sub BtnApplyClient_Click(sender As Object, e As EventArgs) Handles btnApplyClient.Click
        Try
            SetStatus(Strings.T("StatusBar.Applying"))
            RegistryHelper.SetDWord(RegistryHelper.NtpClientPath, "Enabled",
                If(chkClientEnabled.Checked, 1, 0))
            RegistryHelper.SetString(RegistryHelper.ParamsPath, "Type",
                If(cboSyncType.SelectedItem?.ToString(), "NTP"))

            ' Build NTP server string with combined flag appended to each server
            Dim servers = txtNtpServers.Text.Trim()
            If Not String.IsNullOrEmpty(servers) Then
                Dim combined As Integer = 0
                If chkFlag8.Checked Then combined = combined Or &H8
                If chkFlag4.Checked Then combined = combined Or &H4
                If chkFlag1.Checked Then combined = combined Or &H1
                ' Append flag to first server if no flag already set
                Dim parts = servers.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)
                Dim rebuilt As New System.Text.StringBuilder()
                For Each part In parts
                    If part.Contains(",") Then
                        rebuilt.Append(part & " ")
                    Else
                        rebuilt.Append(part & ",0x" & combined.ToString("X") & " ")
                    End If
                Next
                RegistryHelper.SetString(RegistryHelper.ParamsPath, "NtpServer", rebuilt.ToString().Trim())
            End If

            RegistryHelper.SetDWord(RegistryHelper.ConfigPath, "UpdateInterval",
                CInt(nudUpdateInterval.Value))
            RegistryHelper.SetDWord(RegistryHelper.ConfigPath, "MaxPollInterval",
                CInt(nudMaxPoll.Value))
            RegistryHelper.SetDWord(RegistryHelper.NtpClientPath, "SpecialPollInterval",
                CInt(nudMinPoll.Value))
            RegistryHelper.SetDWord(RegistryHelper.ParamsPath, "CrossSiteSyncFlags",
                If(chkCrossSiteSync.Checked, 3, 0))
            RegistryHelper.SetDWord(RegistryHelper.NtpClientPath, "ResolvePeerBackOffMinutes",
                CInt(nudBackOffMin.Value))
            RegistryHelper.SetDWord(RegistryHelper.NtpClientPath, "ResolvePeerBackOffMaxTimes",
                CInt(nudBackOffMax.Value))

            SetStatus(Strings.T("Msg.ApplySuccess"))
        Catch ex As Exception
            MessageBox.Show(Strings.T("Msg.ApplyFailed") & " " & ex.Message,
                Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            SetStatus(Strings.T("StatusBar.Ready"))
        End Try
    End Sub

    Private Sub BtnResetClient_Click(sender As Object, e As EventArgs) Handles btnResetClient.Click
        If AskResetConfirm() Then
            chkClientEnabled.Checked = True
            cboSyncType.SelectedIndex = 0
            txtNtpServers.Text = "time.windows.com,0x9"
            chkFlag8.Checked = True
            chkFlag4.Checked = False
            chkFlag1.Checked = False
            nudUpdateInterval.Value = 100
            nudMinPoll.Value = 10
            nudMaxPoll.Value = 10
            chkCrossSiteSync.Checked = True
            nudBackOffMin.Value = 15
            nudBackOffMax.Value = 7
        End If
    End Sub

    ' ------------------------------------------------------------------ Server page data

    Private Sub LoadServerPage()
        chkServerEnabled.Checked = (RegistryHelper.GetDWord(RegistryHelper.NtpServerPath, "Enabled", 0) = 1)

        ' AnnounceFlags: map registry value to combo index
        Dim af = RegistryHelper.GetDWord(RegistryHelper.ConfigPath, "AnnounceFlags", 10)
        Dim afMap() As Integer = {0, 5, 8, 10, 12, 13}
        Dim afIdx = Array.IndexOf(afMap, af)
        cboAnnounceFlags.SelectedIndex = If(afIdx >= 0, afIdx, 3) ' default 10

        chkSecureOnly.Checked = (RegistryHelper.GetDWord(RegistryHelper.NtpServerPath, "InputProvider", 0) = 0)

        ' Phase correction (stored in seconds as DWORD)
        Dim maxPos = RegistryHelper.GetDWord(RegistryHelper.ConfigPath, "MaxPosPhaseCorrection", 54000)
        Dim maxNeg = RegistryHelper.GetDWord(RegistryHelper.ConfigPath, "MaxNegPhaseCorrection", 54000)
        Dim maxPhase = RegistryHelper.GetDWord(RegistryHelper.ConfigPath, "MaxAllowedPhaseOffset", 1)
        nudMaxPosPhase.Value = Math.Min(nudMaxPosPhase.Maximum, maxPos)
        nudMaxNegPhase.Value = Math.Min(nudMaxNegPhase.Maximum, maxNeg)
        nudMaxPhaseOffset.Value = Math.Min(nudMaxPhaseOffset.Maximum, maxPhase)

        ' Chain
        nudChainEntryTimeout.Value = Math.Min(nudChainEntryTimeout.Maximum,
            RegistryHelper.GetDWord(RegistryHelper.ConfigPath, "ChainEntryTimeout", 16))
    End Sub

    Private Sub BtnApplyServer_Click(sender As Object, e As EventArgs) Handles btnApplyServer.Click
        Try
            SetStatus(Strings.T("StatusBar.Applying"))
            RegistryHelper.SetDWord(RegistryHelper.NtpServerPath, "Enabled",
                If(chkServerEnabled.Checked, 1, 0))

            Dim afMap() As Integer = {0, 5, 8, 10, 12, 13}
            Dim selectedAF = If(cboAnnounceFlags.SelectedIndex >= 0, afMap(cboAnnounceFlags.SelectedIndex), 10)
            RegistryHelper.SetDWord(RegistryHelper.ConfigPath, "AnnounceFlags", selectedAF)

            RegistryHelper.SetDWord(RegistryHelper.NtpServerPath, "InputProvider",
                If(chkSecureOnly.Checked, 0, 1))

            RegistryHelper.SetDWord(RegistryHelper.ConfigPath, "MaxPosPhaseCorrection", CInt(nudMaxPosPhase.Value))
            RegistryHelper.SetDWord(RegistryHelper.ConfigPath, "MaxNegPhaseCorrection", CInt(nudMaxNegPhase.Value))
            RegistryHelper.SetDWord(RegistryHelper.ConfigPath, "MaxAllowedPhaseOffset", CInt(nudMaxPhaseOffset.Value))
            RegistryHelper.SetDWord(RegistryHelper.ConfigPath, "ChainEntryTimeout", CInt(nudChainEntryTimeout.Value))

            SetStatus(Strings.T("Msg.ApplySuccess"))
        Catch ex As Exception
            MessageBox.Show(Strings.T("Msg.ApplyFailed") & " " & ex.Message,
                Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            SetStatus(Strings.T("StatusBar.Ready"))
        End Try
    End Sub

    Private Sub BtnResetServer_Click(sender As Object, e As EventArgs) Handles btnResetServer.Click
        If AskResetConfirm() Then
            chkServerEnabled.Checked = False
            cboAnnounceFlags.SelectedIndex = 3 ' 10 = NTP Server
            chkSecureOnly.Checked = False
            nudMaxPosPhase.Value = 54000
            nudMaxNegPhase.Value = 54000
            nudMaxPhaseOffset.Value = 1
            nudChainEntryTimeout.Value = 16
        End If
    End Sub

    ' ------------------------------------------------------------------ Advanced page data

    Private Sub LoadAdvancedPage()
        ' Time correction
        nudAdvUpdateInterval.Value = RegistryHelper.GetDWord(RegistryHelper.ConfigPath, "UpdateInterval", 100)
        nudFreqCorrectRate.Value = RegistryHelper.GetDWord(RegistryHelper.ConfigPath, "FreqCorrectRate", 4)
        nudPhaseCorrectRate.Value = RegistryHelper.GetDWord(RegistryHelper.ConfigPath, "PhaseCorrectRate", 1)
        nudClockHoldover.Value = RegistryHelper.GetDWord(RegistryHelper.ConfigPath, "ClockHoldoverPeriod", 0)

        ' Spike detection
        nudLargePhaseOffset.Value = RegistryHelper.GetDWord(RegistryHelper.ConfigPath, "LargePhaseOffset", 50000000)
        nudSpikeWatchPeriod.Value = RegistryHelper.GetDWord(RegistryHelper.ConfigPath, "SpikeWatchPeriod", 900)
        nudHoldPeriod.Value = RegistryHelper.GetDWord(RegistryHelper.ConfigPath, "HoldPeriod", 5)

        ' Misc
        nudLocalClockDisp.Value = RegistryHelper.GetDWord(RegistryHelper.ConfigPath, "LocalClockDispersion", 10)
        nudAuditLimit.Value = RegistryHelper.GetDWord(RegistryHelper.ConfigPath, "ClockAdjustmentAuditLimit", 128000)

        ' Logging
        txtFileLogName.Text = RegistryHelper.GetString(RegistryHelper.ConfigPath, "FileLogName", "")
        nudFileLogEntries.Value = RegistryHelper.GetDWord(RegistryHelper.ConfigPath, "FileLogEntries", 0)
        nudFileLogSize.Value = Math.Min(nudFileLogSize.Maximum,
            RegistryHelper.GetDWord(RegistryHelper.ConfigPath, "FileLogSize", 10000))
    End Sub

    Private Sub BtnApplyAdvanced_Click(sender As Object, e As EventArgs) Handles btnApplyAdvanced.Click
        Try
            SetStatus(Strings.T("StatusBar.Applying"))
            RegistryHelper.SetDWord(RegistryHelper.ConfigPath, "UpdateInterval", CInt(nudAdvUpdateInterval.Value))
            RegistryHelper.SetDWord(RegistryHelper.ConfigPath, "FreqCorrectRate", CInt(nudFreqCorrectRate.Value))
            RegistryHelper.SetDWord(RegistryHelper.ConfigPath, "PhaseCorrectRate", CInt(nudPhaseCorrectRate.Value))
            RegistryHelper.SetDWord(RegistryHelper.ConfigPath, "ClockHoldoverPeriod", CInt(nudClockHoldover.Value))
            RegistryHelper.SetDWord(RegistryHelper.ConfigPath, "LargePhaseOffset", CInt(nudLargePhaseOffset.Value))
            RegistryHelper.SetDWord(RegistryHelper.ConfigPath, "SpikeWatchPeriod", CInt(nudSpikeWatchPeriod.Value))
            RegistryHelper.SetDWord(RegistryHelper.ConfigPath, "HoldPeriod", CInt(nudHoldPeriod.Value))
            RegistryHelper.SetDWord(RegistryHelper.ConfigPath, "LocalClockDispersion", CInt(nudLocalClockDisp.Value))
            RegistryHelper.SetDWord(RegistryHelper.ConfigPath, "ClockAdjustmentAuditLimit", CInt(nudAuditLimit.Value))
            RegistryHelper.SetString(RegistryHelper.ConfigPath, "FileLogName", txtFileLogName.Text)
            RegistryHelper.SetDWord(RegistryHelper.ConfigPath, "FileLogEntries", CInt(nudFileLogEntries.Value))
            RegistryHelper.SetDWord(RegistryHelper.ConfigPath, "FileLogSize", CInt(nudFileLogSize.Value))
            SetStatus(Strings.T("Msg.ApplySuccess"))
        Catch ex As Exception
            MessageBox.Show(Strings.T("Msg.ApplyFailed") & " " & ex.Message,
                Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            SetStatus(Strings.T("StatusBar.Ready"))
        End Try
    End Sub

    Private Sub BtnResetAdvanced_Click(sender As Object, e As EventArgs) Handles btnResetAdvanced.Click
        If AskResetConfirm() Then
            nudAdvUpdateInterval.Value = 100
            nudFreqCorrectRate.Value = 4
            nudPhaseCorrectRate.Value = 1
            nudClockHoldover.Value = 0
            nudLargePhaseOffset.Value = 50000000
            nudSpikeWatchPeriod.Value = 900
            nudHoldPeriod.Value = 5
            nudLocalClockDisp.Value = 10
            nudAuditLimit.Value = 128000
            txtFileLogName.Text = ""
            nudFileLogEntries.Value = 0
            nudFileLogSize.Value = 10000
        End If
    End Sub

    Private Sub BtnBrowseLog_Click(sender As Object, e As EventArgs) Handles btnBrowseLog.Click
        Using dlg As New SaveFileDialog() With {
            .Title = Strings.T("Advanced.FileLogName"),
            .Filter = "Log files (*.log)|*.log|All files (*.*)|*.*",
            .FileName = txtFileLogName.Text}
            If dlg.ShowDialog() = DialogResult.OK Then
                txtFileLogName.Text = dlg.FileName
            End If
        End Using
    End Sub

    ' ------------------------------------------------------------------ Config View page data

    Private Sub LoadConfigViewPage()
        SetStatus(Strings.T("StatusBar.Refreshing"))
        rtbConfigView.Text = W32TimeHelper.QueryConfiguration()
        SetStatus(Strings.T("StatusBar.Ready"))
    End Sub

    Private Sub BtnRefreshConfig_Click(sender As Object, e As EventArgs) Handles btnRefreshConfig.Click
        LoadConfigViewPage()
    End Sub

    ' ------------------------------------------------------------------ Helpers

    Private Sub SetStatus(msg As String)
        If tsslStatus IsNot Nothing Then
            tsslStatus.Text = msg
            stsMain.Refresh()
        End If
    End Sub

    Private Function AskResetConfirm() As Boolean
        Return MessageBox.Show(Strings.T("Msg.ResetConfirm"), Me.Text,
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
    End Function

End Class
