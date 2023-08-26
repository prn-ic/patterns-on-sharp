namespace Prototype;

public interface IFile
{
	public IFile Clone();
	public string Name { get; set;}
	public string Content { get; set; }
	public string Extension { get; }
}

public class TxtFile : IFile
{
	public string Name { get; set; } = "Untitled";
	public string Content { get; set; } = "";
	public string Extension { get; } = "txt";
	public TxtFile() { }
	public TxtFile(string name) => Name = name;
	public TxtFile(string name, string content)
	{
		Name = name;
		Content = content;
	}
	public IFile Clone() => new TxtFile(Name + "(cp)", Content);
}

public class MdFile : IFile
{
	public string Name { get; set; } = "Untitled";
	public string Content { get; set; } = "";
	public string Extension { get; } = "md";
	public MdFile() { }
	public MdFile(string name) => Name = name;
	public MdFile(string name, string content)
	{
		Name = name;
		Content = content;
	}
	public IFile Clone() => new MdFile(Name + "(cp)", Content);
}
