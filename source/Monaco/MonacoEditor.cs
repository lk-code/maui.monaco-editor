using System;
using System.Reflection;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Storage;

namespace Monaco;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class MonacoEditor : ContentView
{
    private WebView _webView;

    public MonacoEditor()
    {
        InitializeWebView();
        this.Loaded += MonacoEditor_Loaded;
    }

    ~MonacoEditor()
    {
        this.Loaded -= MonacoEditor_Loaded;
    }

    private void InitializeWebView()
    {
        string baseDirectory = AppContext.BaseDirectory;
        string monacoBaseDirectory = Path.Combine(baseDirectory, "MonacoEditorSource");
        string webviewBaseDirectory = new Uri(monacoBaseDirectory, UriKind.Absolute).ToString() + "/";

        _webView = new WebView
        {
            Source = new HtmlWebViewSource
            {
                Html = LoadHtmlContent($"{monacoBaseDirectory}/index.html"),
                BaseUrl = webviewBaseDirectory
            }
        };

        Content = _webView;
    }

    private string LoadHtmlContent(string filePath)
    {

        try
        {
            using (var reader = new StreamReader(filePath))
            {
                return reader.ReadToEnd();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler beim Laden der Datei '{filePath}': {ex.Message}");

            return string.Empty;
        }
    }

    private void MonacoEditor_Loaded(object? sender, EventArgs e)
    {
    }
}
