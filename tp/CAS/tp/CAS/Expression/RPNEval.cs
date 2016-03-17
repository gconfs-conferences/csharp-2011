using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAS.Expression
{
    static class RPNEval
    {
       
        public static Exp RPN_To_Exp(string RPN)
        {
            string[] elts = RPN.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
            Stack<Exp> stack = new Stack<Exp>();
            foreach (string elt in elts)
            {
                switch (elt)
                {
                    case "+": { Exp B = stack.Pop(); Exp A = stack.Pop(); stack.Push(A + B); } break;
                    case "*": { Exp B = stack.Pop(); Exp A = stack.Pop(); stack.Push(A * B); } break;
                    case "/": { Exp B = stack.Pop(); Exp A = stack.Pop(); stack.Push(A / B); } break;
                    case "-": { Exp B = stack.Pop(); Exp A = stack.Pop(); stack.Push(A - B); } break;
                    case "^": { Exp B = stack.Pop(); Exp A = stack.Pop(); stack.Push(A ^ B); } break;
                    default:
                        try
                        {
                            stack.Push(new Cst(elt));
                        }
                        catch
                        {
                            stack.Push(new Var(elt));
                        }
                        break;
                }
            }
            if (stack.Count != 1) { throw new Exception("Invalid Syntax"); }
            return stack.Pop();
        }
    }
}
