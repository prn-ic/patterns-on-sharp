namespace Memento;

public class File
{
    private int symbols;
    private string text = "";
    private void AddSymbols(string text)
    {
        symbols += text.Length;
        Console.WriteLine($"[i] total symbols: {symbols}");
    }
    public void AddText(string text)
    {
        this.text += " " + text;
        Console.WriteLine($"[i] current text: {this.text}");
        AddSymbols(text);
    }

    public FileMemento SaveFile()
    {
        Console.WriteLine($"[+] Saving file. Total symbols: {symbols};");
        return new FileMemento(symbols, text);
    }

    public void RestoreFile(FileMemento memento)
    {
        symbols = memento.Symbols;
        text = memento.Text;
        Console.WriteLine($"[-] Restoring file. Total symbols: {symbols}; Text: {text}");
    }

}

public class FileMemento 
{
    public int Symbols { get; set; }
    public string Text { get; set; }
    public FileMemento(int symbols, string text) 
    {
        Symbols = symbols;
        Text = text;
    }
}

public class FileHistory
{
    public Stack<FileMemento> History { get; private set; }
    public FileHistory() => History = new Stack<FileMemento>();
}