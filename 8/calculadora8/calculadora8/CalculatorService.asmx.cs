using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(false)]
public class CalculatorService : System.Web.Services.WebService
{
    [WebMethod]
    public double EvaluateInfix(string expression)
    {
        return EvaluatePostfix(ConvertInfixToPostfix(expression));
    }

    [WebMethod]
    public double EvaluatePrefix(string expression)
    {
        return EvaluatePrefixExpression(expression);
    }

    private string ConvertInfixToPostfix(string expression)
    {
        Stack<char> operators = new Stack<char>();
        List<string> output = new List<string>();
        string[] tokens = expression.Split(' ');

        foreach (string token in tokens)
        {
            if (double.TryParse(token, out _))
            {
                output.Add(token);
            }
            else if (IsOperator(token))
            {
                while (operators.Count > 0 && Precedence(operators.Peek()) >= Precedence(token))
                {
                    output.Add(operators.Pop().ToString());
                }
                operators.Push(token);
            }
            else if (token == "(")
            {
                operators.Push('(');
            }
            else if (token == ")")
            {
                while (operators.Count > 0 && operators.Peek() != '(')
                {
                    output.Add(operators.Pop().ToString());
                }
                operators.Pop(); // Remove '(' from stack
            }
        }

        while (operators.Count > 0)
        {
            output.Add(operators.Pop().ToString());
        }

        return string.Join(" ", output);
    }

    private bool IsOperator(string token)
    {
        return token == "+" || token == "-" || token == "*" || token == "/";
    }

    private int Precedence(char op)
    {
        switch (op)
        {
            case '+':
            case '-':
                return 1;
            case '*':
            case '/':
                return 2;
            default:
                return 0;
        }
    }

    private double EvaluatePostfix(string postfixExpression)
    {
        Stack<double> stack = new Stack<double>();
        foreach (var token in postfixExpression.Split(' '))
        {
            if (double.TryParse(token, out double number))
            {
                stack.Push(number);
            }
            else
            {
                double b = stack.Pop();
                double a = stack.Pop();
                switch (token)
                {
                    case "+": stack.Push(a + b); break;
                    case "-": stack.Push(a - b); break;
                    case "*": stack.Push(a * b); break;
                    case "/": stack.Push(a / b); break;
                    default: throw new InvalidOperationException("Operador desconocido");
                }
            }
        }
        return stack.Pop();
    }

    private double EvaluatePrefixExpression(string prefixExpression)
    {
        Stack<double> stack = new Stack<double>();
        var tokens = prefixExpression.Split(' ').Reverse();
        foreach (var token in tokens)
        {
            if (double.TryParse(token, out double number))
            {
                stack.Push(number);
            }
            else
            {
                double a = stack.Pop();
                double b = stack.Pop();
                switch (token)
                {
                    case "+": stack.Push(a + b); break;
                    case "-": stack.Push(a - b); break;
                    case "*": stack.Push(a * b); break;
                    case "/": stack.Push(a / b); break;
                    default: throw new InvalidOperationException("Operador desconocido");
                }
            }
        }
        return stack.Pop();
    }
}
