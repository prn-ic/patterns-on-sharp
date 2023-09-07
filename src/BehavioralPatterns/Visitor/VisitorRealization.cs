using System.Reflection;
using System.Text;

namespace Visitor;

public interface IVisitor
{
    void Visit<T>(T visitorElement);
}

public class JsonVisitor : IVisitor
{
    public void Visit<T>(T visitorElement)
    {
        Type elementType = visitorElement.GetType();
        var fields = elementType.GetFields(
            BindingFlags.Instance | 
            BindingFlags.NonPublic | 
            BindingFlags.Public | BindingFlags.Static
        );
        StringBuilder builder = new StringBuilder("{");
        for (int i = 0; i < fields.Length; i++)
        {
            var info = fields[i].GetValue(visitorElement);
            string fieldName = fields[i].Name.Replace("<", "")
                .Replace(">", "")
                .Replace("k__BackingField", "");
            builder.Append($"\t{fieldName}: '{info}',\n");
        }

        builder.Append("} \n");

        Console.WriteLine(builder.ToString());
    }
}

public class HtmlVisitor : IVisitor
{
    public void Visit<T>(T visitorElement)
    {
        Type elementType = visitorElement.GetType();
        var fields = elementType.GetFields(
            BindingFlags.Instance | 
            BindingFlags.NonPublic | 
            BindingFlags.Public | BindingFlags.Static
        );
        StringBuilder builder = new StringBuilder("<table>");
        for (int i = 0; i < fields.Length; i++)
        {
            var info = fields[i].GetValue(visitorElement);
            string fieldName = fields[i].Name.Replace("<", "")
                .Replace(">", "")
                .Replace("k__BackingField", "");
            builder.Append("<tr><td>" + fieldName + "<td><td>" + info + "</td></tr>\n");
        }

        builder.Append("</table>");

        Console.WriteLine(builder.ToString());
    }
} 

public class TableVisitor : IVisitor
{
    public void Visit<T>(T visitorElement)
    {
        Type elementType = visitorElement.GetType();
        var fields = elementType.GetFields(
            BindingFlags.Instance | 
            BindingFlags.NonPublic | 
            BindingFlags.Public | BindingFlags.Static
        );
        StringBuilder builder = new StringBuilder();

        for (int i = 0; i < fields.Length * 17; i++)
        {
            builder.Append("=");
        }

        builder.Append("\n");

        for (int i = 0; i < fields.Length; i++)
        {
            string fieldName = fields[i].Name.Replace("<", "")
                .Replace(">", "")
                .Replace("k__BackingField", "");
            builder.Append(String.Format("||{0,-15}", fieldName));

        }

        builder.Append("|\n");
        
        for (int i = 0; i < fields.Length * 17; i++)
        {
            builder.Append("=");
        }

        builder.Append("\n");

        for (int i = 0; i < fields.Length; i++)
        {

                var info = fields[i].GetValue(visitorElement);
        
            builder.Append(String.Format("||{0, -15}", info));
        }
        
        builder.Append("|\n");
        
        for (int i = 0; i < fields.Length * 17; i++)
        {
            builder.Append("=");
        }

        builder.Append("\n");

        Console.WriteLine(builder.ToString());
    }
}


public interface IEmployee
{
    void Accept(IVisitor visitor);
}

public class CompanyStructure
{
    List<IEmployee> employees = new List<IEmployee>();
    public void Add(IEmployee element) => employees.Add(element);
    public void Remove(IEmployee element) => employees.Remove(element);
    public void Accept(IVisitor visitor)
    {
        foreach (IEmployee employee in employees)
            employee.Accept(visitor);
    }
}

public class Manager : IEmployee
{
    public string Name { get; set; }
    public int TotalWorked { get; set; }
    public void Accept(IVisitor visitor) => visitor.Visit<Manager>(this);
}

public class Washer : IEmployee
{
    public string Name { get; set; }
    public int TotalRooms { get; set; }
    public int Qualisize { get; set;}
    public void Accept(IVisitor visitor) => visitor.Visit<Washer>(this);
}