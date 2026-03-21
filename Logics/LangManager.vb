Imports System.IO
Imports System.Globalization

''' <summary>
''' Manages language selection. Persists to ntpilot_lang.ini in the exe directory.
''' On first run, auto-detects from the system locale.
''' </summary>
Public Module LangManager

    Private Const IniFileName As String = "ntpilot_lang.ini"
    Private _currentLang As String = "en"

    Public ReadOnly SupportedLanguages As String() = {
        "en", "ja", "de", "es", "fr", "it", "ko", "pt-BR", "ru", "zh"
    }

    Public ReadOnly LanguageNames As New Dictionary(Of String, String) From {
        {"en", "English"},
        {"ja", "日本語"},
        {"de", "Deutsch"},
        {"es", "Español"},
        {"fr", "Français"},
        {"it", "Italiano"},
        {"ko", "한국어"},
        {"pt-BR", "Português (Brasil)"},
        {"ru", "Русский"},
        {"zh", "中文"}
    }

    Public ReadOnly Property CurrentLang As String
        Get
            Return _currentLang
        End Get
    End Property

    ''' <summary>Called once at startup. Loads saved language or auto-detects.</summary>
    Public Sub Initialize()
        Dim iniPath = GetIniPath()
        If File.Exists(iniPath) Then
            Try
                Dim saved = File.ReadAllText(iniPath).Trim()
                If SupportedLanguages.Contains(saved) Then
                    _currentLang = saved
                    Strings.SetLanguage(_currentLang)
                    Return
                End If
            Catch
            End Try
        End If
        _currentLang = DetectSystemLang()
        Strings.SetLanguage(_currentLang)
    End Sub

    ''' <summary>Changes the active language and saves to ini.</summary>
    Public Sub SetLanguage(lang As String)
        If Not SupportedLanguages.Contains(lang) Then lang = "en"
        _currentLang = lang
        Strings.SetLanguage(lang)
        Try
            File.WriteAllText(GetIniPath(), lang, System.Text.Encoding.UTF8)
        Catch
        End Try
    End Sub

    ''' <summary>Returns the index of the current language in SupportedLanguages.</summary>
    Public Function CurrentIndex() As Integer
        Return Array.IndexOf(SupportedLanguages, _currentLang)
    End Function

    Private Function DetectSystemLang() As String
        Dim culture = CultureInfo.CurrentUICulture
        ' Exact match (e.g. "pt-BR")
        If SupportedLanguages.Contains(culture.Name) Then Return culture.Name
        ' Two-letter match (e.g. "ja" from "ja-JP")
        Dim two = culture.TwoLetterISOLanguageName
        If SupportedLanguages.Contains(two) Then Return two
        Return "en"
    End Function

    Private Function GetIniPath() As String
        Return Path.Combine(
            Path.GetDirectoryName(Reflection.Assembly.GetExecutingAssembly().Location),
            IniFileName)
    End Function

End Module
