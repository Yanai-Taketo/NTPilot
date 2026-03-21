Imports Microsoft.Win32
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

''' <summary>
''' Manages light/dark theme following the system setting.
''' Reads HKCU\...\Themes\Personalize\AppsUseLightTheme and applies
''' DWM dark title bar via DwmSetWindowAttribute.
''' </summary>
Public Module ThemeManager

    Private Const DWMWA_USE_IMMERSIVE_DARK_MODE As Integer = 20

    <DllImport("dwmapi.dll", SetLastError:=False)>
    Private Function DwmSetWindowAttribute(hwnd As IntPtr, dwAttribute As Integer,
                                           ByRef pvAttribute As Integer,
                                           cbAttribute As Integer) As Integer
    End Function

    ' ------------------------------------------------------------------ Theme detection

    Public ReadOnly Property IsDarkMode As Boolean
        Get
            Try
                Using key = Registry.CurrentUser.OpenSubKey(
                    "SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize")
                    If key Is Nothing Then Return False
                    Dim val = key.GetValue("AppsUseLightTheme")
                    Return val IsNot Nothing AndAlso CInt(val) = 0
                End Using
            Catch
                Return False
            End Try
        End Get
    End Property

    ' ------------------------------------------------------------------ Color palette

    Public ReadOnly Property BgColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(26, 26, 26), Color.FromArgb(250, 250, 250))
        End Get
    End Property

    Public ReadOnly Property NavBgColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(22, 22, 22), Color.FromArgb(240, 240, 240))
        End Get
    End Property

    Public ReadOnly Property NavSelectedColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(50, 50, 50), Color.FromArgb(255, 255, 255))
        End Get
    End Property

    Public ReadOnly Property NavHoverColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(40, 40, 40), Color.FromArgb(245, 245, 245))
        End Get
    End Property

    Public ReadOnly Property NavDividerColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(48, 48, 48), Color.FromArgb(229, 231, 235))
        End Get
    End Property

    Public ReadOnly Property CardBgColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(38, 38, 38), Color.FromArgb(255, 255, 255))
        End Get
    End Property

    Public ReadOnly Property CardBorderColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(58, 58, 58), Color.FromArgb(229, 231, 235))
        End Get
    End Property

    Public ReadOnly Property TextPrimaryColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(255, 255, 255), Color.FromArgb(26, 26, 26))
        End Get
    End Property

    Public ReadOnly Property TextSecondaryColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(152, 152, 152), Color.FromArgb(100, 100, 100))
        End Get
    End Property

    Public ReadOnly Property AccentColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(96, 165, 250), Color.FromArgb(37, 99, 235))
        End Get
    End Property

    Public ReadOnly Property InputBgColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(50, 50, 50), Color.FromArgb(255, 255, 255))
        End Get
    End Property

    Public ReadOnly Property InputForeColor As Color
        Get
            Return TextPrimaryColor
        End Get
    End Property

    Public ReadOnly Property InputBorderColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(75, 75, 75), Color.FromArgb(209, 213, 219))
        End Get
    End Property

    Public ReadOnly Property GridHeaderBgColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(34, 34, 34), Color.FromArgb(249, 250, 251))
        End Get
    End Property

    Public ReadOnly Property GridRowBgColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(38, 38, 38), Color.FromArgb(255, 255, 255))
        End Get
    End Property

    Public ReadOnly Property GridAltRowBgColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(44, 44, 44), Color.FromArgb(249, 250, 251))
        End Get
    End Property

    Public ReadOnly Property GridLineColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(48, 48, 48), Color.FromArgb(243, 244, 246))
        End Get
    End Property

    Public ReadOnly Property StatusRunningColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(74, 222, 128), Color.FromArgb(22, 163, 74))
        End Get
    End Property

    Public ReadOnly Property StatusStoppedColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(248, 113, 113), Color.FromArgb(220, 38, 38))
        End Get
    End Property

    Public ReadOnly Property StatusUnknownColor As Color
        Get
            Return Color.FromArgb(156, 163, 175)
        End Get
    End Property

    Public ReadOnly Property StatusRunningBgColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(22, 101, 52), Color.FromArgb(240, 253, 244))
        End Get
    End Property

    Public ReadOnly Property StatusStoppedBgColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(127, 29, 29), Color.FromArgb(254, 242, 242))
        End Get
    End Property

    Public ReadOnly Property StatusUnknownBgColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(55, 65, 81), Color.FromArgb(249, 250, 251))
        End Get
    End Property

    Public ReadOnly Property ButtonBgColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(55, 55, 55), Color.FromArgb(249, 250, 251))
        End Get
    End Property

    Public ReadOnly Property ButtonBorderColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(75, 75, 75), Color.FromArgb(209, 213, 219))
        End Get
    End Property

    Public ReadOnly Property ButtonHoverColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(65, 65, 65), Color.FromArgb(243, 244, 246))
        End Get
    End Property

    ' ------------------------------------------------------------------ Apply to window

    ''' <summary>Enables dark/light title bar via DWM.</summary>
    Public Sub ApplyTitleBar(hwnd As IntPtr)
        Dim isDark As Integer = If(IsDarkMode, 1, 0)
        Try
            DwmSetWindowAttribute(hwnd, DWMWA_USE_IMMERSIVE_DARK_MODE, isDark, 4)
        Catch
            ' Not available on older builds - ignore
        End Try
    End Sub

    ' ------------------------------------------------------------------ Apply to controls recursively

    ''' <summary>Applies theme colors to a form and all its child controls.</summary>
    Public Sub ApplyTheme(form As Form)
        ApplyTitleBar(form.Handle)
        ApplyToControl(form)
    End Sub

    Public Sub ApplyToControl(ctrl As Control)
        Select Case True
            Case TypeOf ctrl Is DataGridView
                ApplyToDataGridView(DirectCast(ctrl, DataGridView))
            Case TypeOf ctrl Is TableLayoutPanel
                ApplyToSettingsTlp(DirectCast(ctrl, TableLayoutPanel))
            Case TypeOf ctrl Is RichTextBox
                ctrl.BackColor = InputBgColor
                ctrl.ForeColor = TextPrimaryColor
            Case TypeOf ctrl Is TextBox
                ctrl.BackColor = InputBgColor
                ctrl.ForeColor = TextPrimaryColor
            Case TypeOf ctrl Is NumericUpDown
                ctrl.BackColor = InputBgColor
                ctrl.ForeColor = TextPrimaryColor
            Case TypeOf ctrl Is ComboBox
                ctrl.BackColor = InputBgColor
                ctrl.ForeColor = TextPrimaryColor
            Case TypeOf ctrl Is Label
                ctrl.ForeColor = TextPrimaryColor
                ctrl.BackColor = Color.Transparent
                If TypeOf ctrl.Parent Is TableLayoutPanel Then
                    Dim lbl = DirectCast(ctrl, Label)
                    lbl.TextAlign = ContentAlignment.MiddleLeft
                    lbl.Dock = DockStyle.Fill
                End If
            Case TypeOf ctrl Is CheckBox
                ctrl.ForeColor = TextPrimaryColor
                ctrl.BackColor = Color.Transparent
                If TypeOf ctrl.Parent Is TableLayoutPanel Then
                    ctrl.Dock = DockStyle.Fill
                End If
            Case TypeOf ctrl Is GroupBox
                ctrl.BackColor = BgColor
                ctrl.ForeColor = TextSecondaryColor
                ctrl.Margin = New Padding(0, 0, 0, 16)
                Dim gb = DirectCast(ctrl, GroupBox)
                RemoveHandler gb.Paint, AddressOf PaintGroupBoxCard
                AddHandler gb.Paint, AddressOf PaintGroupBoxCard
                gb.Invalidate()
            Case TypeOf ctrl Is Button
                ApplyToButton(DirectCast(ctrl, Button))
            Case Else
                If ctrl.HasChildren Then
                    If ctrl.Parent IsNot Nothing Then
                        ctrl.BackColor = ctrl.Parent.BackColor
                    End If
                End If
        End Select

        For Each child As Control In ctrl.Controls
            ApplyToControl(child)
        Next
    End Sub

    Private Sub ApplyToButton(btn As Button)
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderColor = ButtonBorderColor
        btn.FlatAppearance.BorderSize = 1
        btn.FlatAppearance.MouseOverBackColor = ButtonHoverColor
        btn.FlatAppearance.MouseDownBackColor = ButtonHoverColor
        btn.BackColor = ButtonBgColor
        btn.ForeColor = TextPrimaryColor
        btn.Cursor = Cursors.Hand

        ' Use Paint handler to draw rounded border
        RemoveHandler btn.Paint, AddressOf PaintButtonRounded
        AddHandler btn.Paint, AddressOf PaintButtonRounded
    End Sub

    Private Sub PaintButtonRounded(sender As Object, e As PaintEventArgs)
        Dim btn = DirectCast(sender, Button)
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        Dim rect = New Rectangle(0, 0, btn.Width - 1, btn.Height - 1)
        Dim radius As Integer = 6

        Using path = CreateRoundedRectPath(rect, radius)
            ' Fill background
            Dim isHovered = btn.ClientRectangle.Contains(btn.PointToClient(Control.MousePosition))
            Dim bgColor = If(isHovered, ButtonHoverColor, btn.BackColor)
            Using br = New SolidBrush(bgColor)
                g.FillPath(br, path)
            End Using

            ' Draw border
            Using pen = New Pen(ButtonBorderColor, 1)
                g.DrawPath(pen, path)
            End Using
        End Using

        ' Draw text centered
        Using br = New SolidBrush(btn.ForeColor)
            Dim sf As New StringFormat()
            sf.Alignment = StringAlignment.Center
            sf.LineAlignment = StringAlignment.Center
            g.DrawString(btn.Text, btn.Font, br, New RectangleF(0, 0, btn.Width, btn.Height), sf)
        End Using
    End Sub

    Private Function CreateRoundedRectPath(rect As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        Dim d As Integer = radius * 2
        path.AddArc(rect.X, rect.Y, d, d, 180, 90)
        path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90)
        path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90)
        path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    Private Sub ApplyToSettingsTlp(tlp As TableLayoutPanel)
        tlp.BackColor = BgColor
        ' Draw separator lines between rows for settings TLPs (2-column label+control)
        If tlp.ColumnCount = 2 Then
            RemoveHandler tlp.Paint, AddressOf PaintTlpSeparators
            AddHandler tlp.Paint, AddressOf PaintTlpSeparators
            tlp.Invalidate()
        End If
    End Sub

    Private Sub PaintTlpSeparators(sender As Object, e As PaintEventArgs)
        Dim tlp = DirectCast(sender, TableLayoutPanel)
        Dim rowHeights = tlp.GetRowHeights()
        Dim y As Integer = 0
        Using pen = New Pen(NavDividerColor, 1)
            For i As Integer = 0 To rowHeights.Length - 2
                y += rowHeights(i)
                e.Graphics.DrawLine(pen, 8, y - 1, tlp.Width - 8, y - 1)
            Next
        End Using
    End Sub

    Private Sub PaintGroupBoxCard(sender As Object, e As PaintEventArgs)
        Dim gb = DirectCast(sender, GroupBox)
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        ' Cover default OS-drawn border with background
        Using br = New SolidBrush(gb.BackColor)
            g.FillRectangle(br, gb.ClientRectangle)
        End Using

        ' Draw card background with rounded corners and border
        Dim cardRect = New Rectangle(0, 0, gb.Width - 1, gb.Height - 1)
        Dim cardRadius As Integer = 8

        Using path = CreateRoundedRectPath(cardRect, cardRadius)
            ' Card fill
            Using br = New SolidBrush(CardBgColor)
                g.FillPath(br, path)
            End Using

            ' Card border
            Using pen = New Pen(CardBorderColor, 1)
                g.DrawPath(pen, path)
            End Using
        End Using

        ' Section title: semibold, slightly larger
        Using titleFont = New Font("Segoe UI Semibold", 10.0F)
            Using titleBrush = New SolidBrush(TextSecondaryColor)
                g.DrawString(gb.Text, titleFont, titleBrush, New PointF(16, 10))
            End Using
        End Using

        ' Thin separator below title
        Using pen = New Pen(NavDividerColor, 1)
            g.DrawLine(pen, 16, 34, gb.Width - 16, 34)
        End Using
    End Sub

    Private Sub ApplyToDataGridView(dgv As DataGridView)
        dgv.BackgroundColor = GridRowBgColor
        dgv.GridColor = GridLineColor
        dgv.DefaultCellStyle.BackColor = GridRowBgColor
        dgv.DefaultCellStyle.ForeColor = TextPrimaryColor
        dgv.DefaultCellStyle.SelectionBackColor = AccentColor
        dgv.DefaultCellStyle.SelectionForeColor = Color.White
        dgv.DefaultCellStyle.Padding = New Padding(4, 2, 4, 2)
        dgv.AlternatingRowsDefaultCellStyle.BackColor = GridAltRowBgColor
        dgv.AlternatingRowsDefaultCellStyle.ForeColor = TextPrimaryColor
        dgv.ColumnHeadersDefaultCellStyle.BackColor = GridHeaderBgColor
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = TextSecondaryColor
        dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 9.0F)
        dgv.ColumnHeadersDefaultCellStyle.Padding = New Padding(4, 0, 4, 0)
        dgv.EnableHeadersVisualStyles = False
    End Sub

End Module
