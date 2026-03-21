Imports System.Windows.Forms

Module Program

    <STAThread>
    Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        LangManager.Initialize()
        Application.Run(New MainForm())
    End Sub

End Module
