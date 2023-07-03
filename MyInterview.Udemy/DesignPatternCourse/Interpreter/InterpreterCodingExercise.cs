using System.Text;

namespace MyIntervew.Udemy.DesignPatternCourse.Interpreter;

/*
You are asked to write an expression processor for simple numeric expressions with the following constraints:

Expressions use integral values (e.g., '13' ), single-letter variables defined in Variables, as well as + and - operators only
There is no need to support braces or any other operations
    If a variable is not found in Variables  (or if we encounter a variable with >1 letter, e.g. ab), the evaluator returns 0 (zero)
In case of any parsing failure, evaluator returns 0
Example:

Calculate("1+2+3")  should return 6
Calculate("1+2+xy")  should return 0
Calculate("10-2-x")  when x=3 is in Variables  should return 5
*/

public interface IElement
{
    int Value { get; }
}

public class Integer : IElement
{
    public Integer(int value)
    {
        Value = value;
    }

    public int Value { get; }
}

public class BinaryOperation : IElement
{
    public enum Type
    {
        Addition,
        Subtraction
    }

    public Type MyType;
    public IElement Left, Right;

    public int Value
    {
        get
        {
            switch (MyType)
            {
                case Type.Addition:
                    return Left.Value + Right.Value;
                case Type.Subtraction:
                    return Left.Value - Right.Value;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}

public class Token
{
    public enum Type
    {
        Integer,
        Plus,
        Minus
    }

    public Type MyType;
    public string Text;

    public Token(Type type, string text)
    {
        MyType = type;
        Text = text;
    }

    public override string ToString()
    {
        return $"`{Text}`";
    }
}

public class Tokenizer
{
    public static List<Token> Lex(string input, Dictionary<char, int> variables)
    {
        var tokens = new List<Token>();
        for (int i = 0; i < input.Length; i++)
        {
            var endOfStr = (input.Length - i == 1);
            switch (input[i])
            {
                case '+':
                    tokens.Add(new Token(Token.Type.Plus, "+"));
                    break;
                case '-':
                    tokens.Add(new Token(Token.Type.Minus, "-"));
                    break;
                case var c when (c >= 48 && c <= 57):
                    var sbNums = new StringBuilder(input[i].ToString());
                    int j = i + 1;
                    do
                    {
                        var isLast = input.Length - i == 1;
                        if (!isLast && char.IsDigit(input[j]))
                        {
                            sbNums.Append(input[j]);
                            i++;
                            j++;
                        }
                        else
                        {
                            tokens.Add(new Token(Token.Type.Integer, sbNums.ToString()));
                            break;
                        }
                    } while (j < input.Length);

                    break;
                case var c when (c >= 97 && c <= 122):
                    if (!endOfStr && char.IsLetter(input[i + 1]))
                    {
                        throw new ArgumentException();
                    }

                    if (variables.TryGetValue(input[i], out int value))
                    {
                        tokens.Add(new Token(Token.Type.Integer, value.ToString()));
                    }
                    else
                    {
                        throw new ArgumentException();
                    }

                    break;
            }
        }

        return tokens;
    }
}

public class Parser
{
    public static IElement Parse(IReadOnlyList<Token> tokens)
    {
        var result = new BinaryOperation();
        bool haveLHS = false;
        for (int i = 0; i < tokens.Count; i++)
        {
            var token = tokens[i];

            // look at the type of token
            switch (token.MyType)
            {
                case Token.Type.Integer:
                    var integer = new Integer(int.Parse(token.Text));
                    if (!haveLHS)
                    {
                        result.Left = integer;
                        haveLHS = true;
                    }
                    else
                    {
                        result.Right = integer;
                    }

                    break;
                case Token.Type.Plus:
                    if (result.Left is not null && result.Right is not null)
                    {
                        result.Left = new Integer(result.Value) ;
                        result.Right = null;
                        haveLHS = true;
                    }

                    result.MyType = BinaryOperation.Type.Addition;
                    break;
                case Token.Type.Minus:
                    if (result.Left is not null && result.Right is not null)
                    {
                        result.Left = new Integer(result.Value) ;
                        result.Right = null;
                        haveLHS = true;
                    }

                    result.MyType = BinaryOperation.Type.Subtraction;
                    break;
                // case Token.Type.Lparen:
                //     int j = i;
                //     for (; j < tokens.Count; ++j)
                //         if (tokens[j].MyType == Token.Type.Rparen)
                //             break; // found it!
                //     // process subexpression w/o opening (
                //     var subexpression = tokens.Skip(i + 1).Take(j - i - 1).ToList();
                //     var element = Parse(subexpression);
                //     if (!haveLHS)
                //     {
                //         result.Left = element;
                //         haveLHS = true;
                //     }
                //     else result.Right = element;
                //
                //     i = j; // advance
                //     break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        return result;
    }
}

public class ExpressionProcessor
{
    public Dictionary<char, int> Variables = new()
    {
        { 'x', 100 },
        { 'z', 1000 }
    };

    public int Calculate(string expression)
    {
       
        try
        {
            var tokens = Tokenizer.Lex(expression, Variables);
            var result = Parser.Parse(tokens);
            return result.Value;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return 0;
        }
    }
}