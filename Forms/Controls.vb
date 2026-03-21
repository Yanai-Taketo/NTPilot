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
    Private Shared ReadOnly _font As New Font("Segoe UI", 9.5F)
    Private Shared ReadOnly _fontBold As New Font("Segoe UI Semibold", 9.5F)

    Public Sub New(text As String)
        _text = text
        Height = 40
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
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        ' Background
        Dim bg = If(_isSelected, ThemeManager.NavSelectedColor,
                    If(_isHovered, ThemeManager.NavHoverColor, ThemeManager.NavBgColor))
        Using br = New SolidBrush(bg)
            g.FillRectangle(br, ClientRectangle)
        End Using

        ' Bottom accent bar for selected tab
        If _isSelected Then
            Using br = New SolidBrush(ThemeManager.AccentColor)
                g.FillRectangle(br, New Rectangle(0, Height - 3, Width, 3))
            End Using
        End If

        ' Tab text centered
        Dim font = If(_isSelected, _fontBold, _font)
        Dim color = If(_isSelected, ThemeManager.TextPrimaryColor, ThemeManager.TextSecondaryColor)
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
