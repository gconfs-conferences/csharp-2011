using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAS.Expression
{
    static class InfixEval
    {
        public static string Infix_To_RPN(string Infix)
        {
            Infix = Infix.Replace("(", " ( ");
            Infix = Infix.Replace(")", " ) ");
            Infix = Infix.Replace("*", " * ");
            Infix = Infix.Replace("/", " / ");
            Infix = Infix.Replace("+", " + ");
            Infix = Infix.Replace("-", " - ");
            Infix = Infix.Replace("^", " ^ ");
            string[] elts = Infix.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Stack<string> stack = new Stack<string>();
            string output = "";
            foreach (string elt in elts)
            {
                switch (elt)
                {
                    case "+":
                    case "-":
                        while (stack.Count > 0 && stack.Peek() != "(")
                        {
                            { output += " " + stack.Pop() + " "; }
                        }
                        { stack.Push(elt); }
                        break;
                    case "/":
                    case "*":
                        while (stack.Count > 0)
                        {
                            if ((stack.Peek() == "*" || stack.Peek() == "/" || stack.Peek() == "^") && stack.Peek() != "(")
                            { output += " " + stack.Pop() + " "; }
                            else { break; }
                        }
                        { stack.Push(elt); } 
                        break;
                    case "^":
                        { stack.Push(elt); } 
                        break;
                    case "(":
                        { stack.Push(elt); }
                        break;
                    case ")":
                        {
                            while (stack.Count > 0 && stack.Peek() != "(")
                            {
                                output += " " + stack.Pop() + " ";
                            }
                            if (stack.Count == 0) { throw new Exception("invalid syntax"); }
                            stack.Pop();
                        }
                        break;
                    default:
                        output += " " + elt + " ";
                        break;
                }
            }
            while (stack.Count > 0)
            {
                output += " " + stack.Pop() + " ";
            }
            return output;
        }
    }
}
