namespace Adapter;

public interface IHdmi
{
    void TranslateVideo();
    void TranslateAudio();
}

public interface IVga
{
    void TranslateVideo();
}

public class SomeHdmiCabel : IHdmi
{
    public void TranslateVideo() =>
        Console.WriteLine("[✓](V) Транслируем видео через HDMI кабель some бирки");
    public void TranslateAudio() =>
        Console.WriteLine("[✓](A) Транслируем аудио через HDMI кабель some марки");
}

public class SomeVgaCabel : IVga
{
    public void TranslateVideo() =>
        Console.WriteLine("[✓](V) Транслируем видео через VGA кабель some марки");
}

public class VgaToHdmiAdapter : IHdmi
{
    private IVga vga;
    public VgaToHdmiAdapter(IVga vga) => this.vga = vga;
    public void TranslateVideo() => 
        Console.WriteLine("[✓](V) Транслируем видео через адаптер VGA to HDMI кабель");
    public void TranslateAudio() =>
        Console.WriteLine("[x](A) VGA to HDMI - Аудио не поддерживается");
}

public class Tv
{
    public void ShowThroughHdmi(IHdmi hdmi)
    {
        hdmi.TranslateVideo();
        hdmi.TranslateAudio();
    }
}
