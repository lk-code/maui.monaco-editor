namespace Monaco;

public static class MauiProgramExtensions
{
    public static MauiAppBuilder UseMauiMonacoEditor(this MauiAppBuilder builder)
    {
        // builder.Services.AddMauiBlazorWebView();

        //builder.Services.AddTransient<MonacoEditor>();

        return builder;
    }
}