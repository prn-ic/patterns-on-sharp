namespace Decorator;

public abstract class Browser
{
    public string Name { get; private set;}
    public string ExtensionsPath { get; protected set; }
    public Browser(string name) => Name = name;
    public Browser(string name, string extension) 
    {
        Name = name;
        ExtensionsPath = extension;
    } 
    public abstract string GetExtensions();
}

public class ChromeBrowser : Browser
{
    public ChromeBrowser() : base("Google Chrome") { }
    public override string GetExtensions() => ExtensionsPath;
}

public class MozillaBrowser : Browser
{
    public MozillaBrowser() : base("Mozilla Firefox") { }
    public override string GetExtensions() => ExtensionsPath;
}

public class AmigoBrowser : Browser
{
    public AmigoBrowser() : base("Zalupa Ebanaya") { }
    public override string GetExtensions() => ExtensionsPath;
}

public abstract class BrowserDecorator : Browser
{
    protected Browser browserInstanse;
    public BrowserDecorator(string name, string extension, Browser browserInstanse) 
        : base(name, browserInstanse.ExtensionsPath + extension + "; ") =>
        this.browserInstanse = browserInstanse;
}

public class AdBlockExtension : BrowserDecorator
{
    public AdBlockExtension(Browser browserInstanse) 
        : base(browserInstanse.Name, "AdBlock", browserInstanse) { }
    public override string GetExtensions() => browserInstanse.ExtensionsPath;
}

public class TranslatorExtension : BrowserDecorator
{
    public TranslatorExtension(Browser browserInstanse) 
        : base(browserInstanse.Name, "Translator", browserInstanse) { }
    public override string GetExtensions() => browserInstanse.ExtensionsPath;
}