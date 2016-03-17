using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAS.Expression
{
    class Var : Exp
    {
        string _name = "x";
        public Var(string name) { _name = name; }
        public override Exp Diff(string Var)
        {
            return (Var == _name) ? (Exp)(new Cst(1)) : new Cst(0);
        }
        public override Exp Evaluate()
        {
            return new Var(_name);
        }
        public override Exp Simplify()
        {
            return new Var(_name);
        }
        public override bool IsNull()
        {
            return false;
        }
        public override bool IsConst()
        {
            return false;
        }
        public override string ToString()
        {
            return _name;
        }
        public override Value ToValue()
        {
            return new Value(float.NaN);
        }
    }
}
