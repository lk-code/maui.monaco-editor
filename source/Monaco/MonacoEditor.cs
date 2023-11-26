namespace Monaco;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class MonacoEditor : ContentView
{
    public MonacoEditor()
    {
        this.Loaded += MonacoEditor_Loaded;
    }

    ~MonacoEditor()
    {
        this.Loaded -= MonacoEditor_Loaded;
    }

    private void MonacoEditor_Loaded(object sender, EventArgs e)
    {
        // this.LoadMonaco();
    }
}