Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

' ============================================================
' NavItemPanel – custom-drawn navigation item for the left panel
' ============================================================
Public Class NavItemPanel
    Inherits Panel

    Private _text As String = ""
    Private _icon As String = ""
    Private _isSelected As Boolean = False
    Private _isHovered As Boolean = False
    Private Shared ReadOnly _iconFont As New Font("Segoe UI Symbol", 11.0F)
    Private Shared ReadOnly _textFont As New Font("Segoe UI", 9.5F)
    Private Shared ReadOnly _textFontBold As New Font("Segoe UI Semibold", 9.5F)

    Public Sub New(text As String, icon As String)
        _text = text
        _icon = icon
        Height = 48
        Cursor = Cursors.Hand
        SetStyle(ControlStyles.AllPaintingInWmPaint Or
                 ControlStyles.UserPaint Or
                 ControlStyles.DoubleBuffer Or
                 ControlStyles.ResizeRedraw, True)
    End Sub

    Public Property ItemText As String
        Get
            Return _text
        End Get
        Set(v As String)
            _text = v
            Invalidate()
        End Set
    End Property

    Public Property ItemIcon As String
        Get
            Return _icon
        End Get
        Set(v As String)
            _icon = v
            Invalidate()
        End Set
    End Property

    Public Property IsSelected As Boolean
        Get
            Return _isSelected
        End Get
        Set(v As Boolean)
            _isSelected = v
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        ' Background
        Dim bg = If(_isSelected, ThemeManager.NavSelectedColor,
                    If(_isHovered, ThemeManager.NavHoverColor, ThemeManager.NavBgColor))
        Using br = New SolidBrush(bg)
            g.FillRectangle(br, ClientRectangle)
        End Using

        ' Left selection indicator
        If _isSelected Then
            Using br = New SolidBrush(ThemeManager.AccentColor)
                g.FillRectangle(br, New Rectangle(0, 10, 3, Height - 20))
            End Using
        End If

        ' Icon
        Using iconBrush = New SolidBrush(
            If(_isSelected, ThemeManager.AccentColor, ThemeManager.TextSecondaryColor))
            Dim iconSize = g.MeasureString(_icon, _iconFont)
            g.DrawString(_icon, _iconFont, iconBrush,
                New PointF(18, (Height - iconSize.Height) / 2.0F))
        End Using

        ' Label
        Using txtBrush = New SolidBrush(ThemeManager.TextPrimaryColor)
            Dim font = If(_isSelected, _textFontBold, _textFont)
            Dim txtSize = g.MeasureString(_text, font)
            g.DrawString(_text, font, txtBrush,
                New PointF(48, (Height - txtSize.Height) / 2.0F))
        End Using
    End Sub

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        _isHovered = True
        Invalidate()
        MyBase.OnMouseEnter(e)
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        _isHovered = False
        Invalidate()
        MyBase.OnMouseLeave(e)
    End Sub

End Class

' ============================================================
' TabItemPanel – horizontal tab button for the top tab strip
' ============================================================
Public Class TabItemPanel
    Inherits Panel

    Private _text As String = ""
    Private _isSelected As Boolean = False
    Private _isHovered As Boolean = False
    Private Shared ReadOnly _font As New Font("Segoe UI", 10.0F)
    Private Shared ReadOnly _fontBold As New Font("Segoe UI Semibold", 10.0F)

    Public Sub New(text As String)
        _text = text
        Height = 48
        Cursor = Cursors.Hand
        SetStyle(ControlStyles.AllPaintingInWmPaint Or
                 ControlStyles.UserPaint Or
                 ControlStyles.DoubleBuffer Or
                 ControlStyles.ResizeRedraw, True)
    End Sub

    Public Property TabText As String
        Get
            Return _text
        End Get
        Set(v As String)
            _text = v
            Invalidate()
        End Set
    End Property

    Public Property IsSelected As Boolean
        Get
            Return _isSelected
        End Get
        Set(v As Boolean)
            _isSelected = v
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        ' Background with subtle hover transition
        Dim bg As Color
        If _isSelected Then
            bg = ThemeManager.NavSelectedColor
        ElseIf _isHovered Then
            bg = ThemeManager.NavHoverColor
        Else
            bg = ThemeManager.NavBgColor
        End If
        Using br = New SolidBrush(bg)
            g.FillRectangle(br, ClientRectangle)
        End Using

        ' Bottom accent bar for selected tab (3px thick)
        If _isSelected Then
            Using br = New SolidBrush(ThemeManager.AccentColor)
                g.FillRectangle(br, New Rectangle(8, Height - 3, Width - 16, 3))
            End Using
        End If

        ' Tab text centered
        Dim font = If(_isSelected, _fontBold, _font)
        Dim color As Color
        If _isSelected Then
            color = ThemeManager.AccentColor
        ElseIf _isHovered Then
            color = ThemeManager.TextPrimaryColor
        Else
            color = ThemeManager.TextSecondaryColor
        End If
        Using br = New SolidBrush(color)
            Dim sz = g.MeasureString(_text, font)
            g.DrawString(_text, font, br,
                New PointF((Width - sz.Width) / 2.0F, (Height - sz.Height) / 2.0F))
        End Using
    End Sub

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        _isHovered = True
        Invalidate()
        MyBase.OnMouseEnter(e)
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        _isHovered = False
        Invalidate()
        MyBase.OnMouseLeave(e)
    End Sub

End Class

' ============================================================
' StatusBadge – pill-shaped status indicator
' ============================================================
Public Class StatusBadge
    Inherits Panel

    Private _statusText As String = ""
    Private _statusColor As Color = Color.Gray
    Private _bgTintColor As Color = Color.Transparent
    Private Shared ReadOnly _font As New Font("Segoe UI Semibold", 10.0F)

    Public Sub New()
        Height = 48
        SetStyle(ControlStyles.AllPaintingInWmPaint Or
                 ControlStyles.UserPaint Or
                 ControlStyles.DoubleBuffer Or
                 ControlStyles.ResizeRedraw, True)
    End Sub

    Public Property StatusText As String
        Get
            Return _statusText
        End Get
        Set(v As String)
            _statusText = v
            Invalidate()
        End Set
    End Property

    Public Property StatusColor As Color
        Get
            Return _statusColor
        End Get
        Set(v As Color)
            _statusColor = v
            Invalidate()
        End Set
    End Property

    Public Property BgTintColor As Color
        Get
            Return _bgTintColor
        End Get
        Set(v As Color)
            _bgTintColor = v
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim g = e.Graphics
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        ' Clear with parent background
        Dim parentBg = If(Parent IsNot Nothing, Parent.BackColor, ThemeManager.BgColor)
        Using br = New SolidBrush(parentBg)
            g.FillRectangle(br, ClientRectangle)
        End Using

        If String.IsNullOrEmpty(_statusText) Then Return

        ' Measure text to size the pill
        Dim textSize = g.MeasureString(_statusText, _font)
        Dim dotSize As Integer = 10
        Dim pillPadH As Integer = 16
        Dim pillPadV As Integer = 6
        Dim pillWidth = CInt(dotSize + 8 + textSize.Width + pillPadH * 2)
        Dim pillHeight = CInt(textSize.Height + pillPadV * 2)
        Dim pillY = (Height - pillHeight) \ 2
        Dim pillRect = New Rectangle(8, pillY, pillWidth, pillHeight)
        Dim pillRadius As Integer = pillHeight \ 2

        ' Draw pill background
        Using path As New GraphicsPath()
            Dim d = pillRadius * 2
            path.AddArc(pillRect.X, pillRect.Y, d, d, 180, 90)
            path.AddArc(pillRect.Right - d, pillRect.Y, d, d, 270, 90)
            path.AddArc(pillRect.Right - d, pillRect.Bottom - d, d, d, 0, 90)
            path.AddArc(pillRect.X, pillRect.Bottom - d, d, d, 90, 90)
            path.CloseFigure()
            Using br = New SolidBrush(_bgTintColor)
                g.FillPath(br, path)
            End Using
            Using pen = New Pen(Color.FromArgb(40, _statusColor), 1)
                g.DrawPath(pen, path)
            End Using
        End Using

        ' Draw dot
        Dim dotX = pillRect.X + pillPadH
        Dim dotY = pillRect.Y + (pillHeight - dotSize) \ 2
        Using br = New SolidBrush(_statusColor)
            g.FillEllipse(br, dotX, dotY, dotSize, dotSize)
        End Using

        ' Draw text
        Dim textX = dotX + dotSize + 8
        Dim textY = pillRect.Y + pillPadV
        Using br = New SolidBrush(_statusColor)
            g.DrawString(_statusText, _font, br, New PointF(textX, textY))
        End Using
    End Sub

End Class
