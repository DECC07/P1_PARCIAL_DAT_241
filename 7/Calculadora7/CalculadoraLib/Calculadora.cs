/*using System;
using System.Collections.Generic;

namespace CalculatorLibrary
{
    public class Calculadora
    {
        public double EvaluateInfix(string expression)
        {
            // Convertir la expresión infija a postfija usando el algoritmo de Shunting Yard
            string postfix = InfixToPostfix(expression);
            // Evaluar la expresión postfija
            return EvaluatePostfix(postfix);
        }

        private string InfixToPostfix(string expression)
        {
            Stack<char> stack = new Stack<char>();
            string postfix = "";
            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];
                if (char.IsDigit(c))
                {
                    // Manejar números de más de un dígito
                    while (i < expression.Length && char.IsDigit(expression[i]))
                    {
                        postfix += expression[i];
                        i++;
                    }
                    postfix += ' '; // Añadir un espacio para separar los números
                    i--; // Ajustar el índice después del bucle
                }
                else if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    while (stack.Count > 0 && stack.Peek() != '(')
                    {
                        postfix += stack.Pop();
                    }
                    stack.Pop(); // Eliminar '('
                }
                else if (IsOperator(c))
                {
                    while (stack.Count > 0 && Precedence(stack.Peek()) >= Precedence(c))
                    {
                        postfix += stack.Pop();
                    }
                    stack.Push(c);
                }
            }
            while (stack.Count > 0)
            {
                postfix += stack.Pop();
            }
            return postfix;
        }

        private double EvaluatePostfix(string expression)
        {
            Stack<double> stack = new Stack<double>();
            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];
                if (char.IsDigit(c))
                {
                    // Manejar números de más de un dígito
                    string number = "";
                    while (i < expression.Length && char.IsDigit(expression[i]))
                    {
                        number += expression[i];
                        i++;
                    }
                    stack.Push(double.Parse(number));
                    i--; // Ajustar el índice después del bucle
                }
                else if (IsOperator(c))
                {
                    if (stack.Count < 2)
                    {
                        throw new InvalidOperationException("Expresión postfija inválida.");
                    }
                    double operand2 = stack.Pop();
                    double operand1 = stack.Pop();
                    switch (c)
                    {
                        case '+':
                            stack.Push(operand1 + operand2);
                            break;
                        case '-':
                            stack.Push(operand1 - operand2);
                            break;
                        case '*':
                            stack.Push(operand1 * operand2);
                            break;
                        case '/':
                            stack.Push(operand1 / operand2);
                            break;
                    }
                }
            }
            if (stack.Count != 1)
            {
                throw new InvalidOperationException("Expresión postfija inválida.");
            }
            return stack.Pop();
        }

        private bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }

        private int Precedence(char c)
        {
            switch (c)
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

        public double EvaluatePrefix(string expression)
        {
            Stack<double> stack = new Stack<double>();
            for (int i = expression.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(expression[i]))
                {
                    // Manejar números de más de un dígito
                    string number = "";
                    while (i >= 0 && char.IsDigit(expression[i]))
                    {
                        number = expression[i] + number;
                        i--;
                    }
                    stack.Push(double.Parse(number));
                    i++; // Ajustar el índice después del bucle
                }
                else if (IsOperator(expression[i]))
                {
                    if (stack.Count < 2)
                    {
                        throw new InvalidOperationException("Expresión prefija inválida.");
                    }
                    double operand1 = stack.Pop();
                    double operand2 = stack.Pop();
                    switch (expression[i])
                    {
                        case '+':
                            stack.Push(operand1 + operand2);
                            break;
                        case '-':
                            stack.Push(operand1 - operand2);
                            break;
                        case '*':
                            stack.Push(operand1 * operand2);
                            break;
                        case '/':
                            stack.Push(operand1 / operand2);
                            break;
                    }
                }
            }
            if (stack.Count != 1)
            {
                throw new InvalidOperationException("Expresión prefija inválida.");
            }
            return stack.Pop();
        }
    }
}
*/
using System;
using System.Collections.Generic;

namespace CalculatorLibrary
{
    public class Calculadora
    {
        public double EvaluateInfix(string expression)
        {
            // Convertir la expresión infija a postfija usando el algoritmo de Shunting Yard
            string postfix = InfixToPostfix(expression);
            // Evaluar la expresión postfija
            return EvaluatePostfix(postfix);
        }

        private string InfixToPostfix(string expression)
        {
            Stack<char> stack = new Stack<char>();
            string postfix = "";
            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];
                if (char.IsDigit(c))
                {
                    // Manejar números de más de un dígito
                    while (i < expression.Length && char.IsDigit(expression[i]))
                    {
                        postfix += expression[i];
                        i++;
                    }
                    postfix += ' '; // Añadir un espacio para separar los números
                    i--; // Ajustar el índice después del bucle
                }
                else if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    while (stack.Count > 0 && stack.Peek() != '(')
                    {
                        postfix += stack.Pop();
                    }
                    stack.Pop(); // Eliminar '('
                }
                else if (IsOperator(c))
                {
                    while (stack.Count > 0 && Precedence(stack.Peek()) >= Precedence(c))
                    {
                        postfix += stack.Pop();
                    }
                    stack.Push(c);
                }
            }
            while (stack.Count > 0)
            {
                postfix += stack.Pop();
            }
            return postfix;
        }

        private double EvaluatePostfix(string expression)
        {
            Stack<double> stack = new Stack<double>();
            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];
                if (char.IsDigit(c))
                {
                    // Manejar números de más de un dígito
                    string number = "";
                    while (i < expression.Length && char.IsDigit(expression[i]))
                    {
                        number += expression[i];
                        i++;
                    }
                    stack.Push(double.Parse(number));
                    i--; // Ajustar el índice después del bucle
                }
                else if (IsOperator(c))
                {
                    if (stack.Count < 2)
                    {
                        throw new InvalidOperationException("Expresión postfija inválida.");
                    }
                    double operand2 = stack.Pop();
                    double operand1 = stack.Pop();
                    switch (c)
                    {
                        case '+':
                            stack.Push(operand1 + operand2);
                            break;
                        case '-':
                            stack.Push(operand1 - operand2);
                            break;
                        case '*':
                            stack.Push(operand1 * operand2);
                            break;
                        case '/':
                            stack.Push(operand1 / operand2);
                            break;
                    }
                }
            }
            if (stack.Count != 1)
            {
                throw new InvalidOperationException("Expresión postfija inválida.");
            }
            return stack.Pop();
        }

        private bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }

        private int Precedence(char c)
        {
            switch (c)
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

        public double EvaluatePrefix(string expression)
        {
            Stack<double> stack = new Stack<double>();
            for (int i = expression.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(expression[i]))
                {
                    // Manejar números de más de un dígito
                    string number = "";
                    while (i >= 0 && char.IsDigit(expression[i]))
                    {
                        number = expression[i] + number;
                        i--;
                    }
                    stack.Push(double.Parse(number));
                    i++; // Ajustar el índice después del bucle
                }
                else if (IsOperator(expression[i]))
                {
                    if (stack.Count < 2)
                    {
                        throw new InvalidOperationException("Expresión prefija inválida.");
                    }
                    double operand1 = stack.Pop();
                    double operand2 = stack.Pop();
                    switch (expression[i])
                    {
                        case '+':
                            stack.Push(operand1 + operand2);
                            break;
                        case '-':
                            stack.Push(operand1 - operand2);
                            break;
                        case '*':
                            stack.Push(operand1 * operand2);
                            break;
                        case '/':
                            stack.Push(operand1 / operand2);
                            break;
                    }
                }
            }
            if (stack.Count != 1)
            {
                throw new InvalidOperationException("Expresión prefija inválida.");
            }
            return stack.Pop();
        }
    }
}

