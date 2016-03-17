using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAS.Expression
{
    abstract class Exp
    {
        public abstract Exp Simplify();
        public abstract Exp Diff(string Var);
        public abstract Exp Evaluate();
        public abstract Value ToValue();
        public abstract bool IsNull();
        public abstract bool IsConst();
        public virtual new string ToString(){return "";}
        public static  Exp operator +(Exp A, Exp B) { return new Add(A, B); }
        public static Exp operator -(Exp A, Exp B) { return new Sub(A, B); }
        public static Exp operator *(Exp A, Exp B) { return new Mul(A, B); }
        public static Exp operator /(Exp A, Exp B) { return new Div(A, B); }
        public static Exp operator ^(Exp A, Exp B) { return new Pow(A, B); }
        public static implicit operator Exp(float value) { return new Cst(value); }
        public static implicit operator Exp(int value) { return new Cst((float)value); }
        public static implicit operator Exp(string value) { return new Var(value); }
        public static implicit operator Exp(Value value) { return new Cst(value); }
     
    }
}
