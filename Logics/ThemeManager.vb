Imports Microsoft.Win32
Imports System.Drawing
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
            Return If(IsDarkMode, Color.FromArgb(32, 32, 32), Color.FromArgb(243, 243, 243))
        End Get
    End Property

    Public ReadOnly Property NavBgColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(28, 28, 28), Color.FromArgb(232, 232, 232))
        End Get
    End Property

    Public ReadOnly Property NavSelectedColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(54, 54, 54), Color.FromArgb(255, 255, 255))
        End Get
    End Property

    Public ReadOnly Property NavHoverColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(44, 44, 44), Color.FromArgb(242, 242, 242))
        End Get
    End Property

    Public ReadOnly Property NavDividerColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(50, 50, 50), Color.FromArgb(220, 220, 220))
        End Get
    End Property

    Public ReadOnly Property CardBgColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(44, 44, 44), Color.FromArgb(255, 255, 255))
        End Get
    End Property

    Public ReadOnly Property CardBorderColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(62, 62, 62), Color.FromArgb(224, 224, 224))
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
            Return If(IsDarkMode, Color.FromArgb(96, 205, 255), Color.FromArgb(0, 120, 212))
        End Get
    End Property

    Public ReadOnly Property InputBgColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(58, 58, 58), Color.FromArgb(255, 255, 255))
        End Get
    End Property

    Public ReadOnly Property InputForeColor As Color
        Get
            Return TextPrimaryColor
        End Get
    End Property

    Public ReadOnly Property InputBorderColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(82, 82, 82), Color.FromArgb(192, 192, 192))
        End Get
    End Property

    Public ReadOnly Property GridHeaderBgColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(38, 38, 38), Color.FromArgb(240, 240, 240))
        End Get
    End Property

    Public ReadOnly Property GridRowBgColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(44, 44, 44), Color.FromArgb(255, 255, 255))
        End Get
    End Property

    Public ReadOnly Property GridAltRowBgColor As Color
        Get
            Return If(IsDarkMode, Color.FromArgb(50, 50, 50), Color.FromArgb(248, 248, 248))
        End Get
    End Property

    Public ReadOnly Property StatusRunningColor As Color
        Get
            Return Color.FromArgb(16, 185, 129)
        End Get
    End Property

    Public ReadOnly Property StatusStoppedColor As Color
        Get
            Return Color.FromArgb(239, 68, 68)
        End Get
    End Property

    Public ReadOnly Property StatusUnknownColor As Color
        Get
            Return Color.FromArgb(156, 163, 175)
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
                ctrl.Margin = New Padding(0, 0, 0, 8)
                Dim gb = DirectCast(ctrl, GroupBox)
                RemoveHandler gb.Paint, AddressOf PaintGroupBoxVSCode
                AddHandler gb.Paint, AddressOf PaintGroupBoxVSCode
                gb.Invalidate()
            Case TypeOf ctrl Is Button
                ' Keep system default for buttons (they respect OS theme)
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
                e.Graphics.DrawLine(pen, 0, y - 1, tlp.Width, y - 1)
            Next
        End Using
    End Sub

    Private Sub PaintGroupBoxVSCode(sender As Object, e As PaintEventArgs)
        Dim gb = DirectCast(sender, GroupBox)
        Dim g = e.Graphics
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        ' Cover default OS-drawn border with background
        Using br = New SolidBrush(gb.BackColor)
            g.FillRectangle(br, gb.ClientRectangle)
        End Using

        ' Section title: secondary color, semibold
        Using titleFont = New Font("Segoe UI Semibold", 9.0F)
            Using titleBrush = New SolidBrush(TextSecondaryColor)
                g.DrawString(gb.Text, titleFont, titleBrush, New PointF(0, 5))
            End Using
        End Using

        ' Thin separator below title
        Using pen = New Pen(NavDividerColor, 1)
            g.DrawLine(pen, 0, 26, gb.Width, 26)
        End Using
    End Sub

    Private Sub ApplyToDataGridView(dgv As DataGridView)
        dgv.BackgroundColor = GridRowBgColor
        dgv.GridColor = CardBorderColor
        dgv.DefaultCellStyle.BackColor = GridRowBgColor
        dgv.DefaultCellStyle.ForeColor = TextPrimaryColor
        dgv.DefaultCellStyle.SelectionBackColor = AccentColor
        dgv.DefaultCellStyle.SelectionForeColor = Color.White
        dgv.AlternatingRowsDefaultCellStyle.BackColor = GridAltRowBgColor
        dgv.AlternatingRowsDefaultCellStyle.ForeColor = TextPrimaryColor
        dgv.ColumnHeadersDefaultCellStyle.BackColor = GridHeaderBgColor
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = TextPrimaryColor
        dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 9.0F)
        dgv.EnableHeadersVisualStyles = False
    End Sub

End Module
