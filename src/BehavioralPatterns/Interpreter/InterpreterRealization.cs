namespace Interpreter;

public interface IExpression
{
    string Interpret(Context context);
}

public class Context
{
    Dictionary<int, string> words = new Dictionary<int, string>();
    public string GetWordByDocumentId(int id) =>
        words[id];
    public void SetWord(int id, string word)
    {
        if (words.ContainsKey(id)) words[id] = words[id] + " " + word;
        else words.Add(id, word);
    }
}

public class TerminalExpression : IExpression
{
    int documentId;
    public TerminalExpression(int documentId) => this.documentId = documentId;
    public string Interpret(Context context) => context.GetWordByDocumentId(documentId);
}

public class DublicateWordToTheDocumentExpression : IExpression
{
    IExpression expression;
    public DublicateWordToTheDocumentExpression(IExpression expression) => this.expression = expression;
    public string Interpret(Context context) => 
        $"{expression.Interpret(context)}{expression.Interpret(context)}" ;
}

public class SetOneWordToTheDocumentExpression : IExpression
{
    IExpression expression;
    public SetOneWordToTheDocumentExpression(IExpression expression) => this.expression = expression;
    public string Interpret(Context context) =>
        "1";
}

public class MergeDocumentsExpression : IExpression
{
    IExpression leftExpression;
    IExpression rightExpression;
    public MergeDocumentsExpression(IExpression leftExpression, IExpression rightExpression)
    {
        this.leftExpression = leftExpression;
        this.rightExpression = rightExpression;
    }
    public string Interpret(Context context) =>
        $"{leftExpression.Interpret(context)} {rightExpression.Interpret(context)}";
}