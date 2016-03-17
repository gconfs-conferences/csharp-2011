using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAS.Expression
{
    class Cst : Exp
    {
        Value _cstvalue = new Value(0.0f);
        public Cst(float value) { _cstvalue = new Value(value); }
        public Cst(Value value) { _cstvalue = value; }
        public Cst(string value) { _cstvalue = new Value(value); }
        public override Exp Diff(string Var)
        {
            return new Cst(0);
        }
        public override Exp Evaluate()
        {
            return new Cst(_cstvalue);
        }
        public override Exp Simplify()
        {
            return new Cst(_cstvalue);
        }
        public override bool IsNull()
        {
            return _cstvalue.ToFloat() == 0;
        }
        public override bool IsConst()
        {
            return true;
        }
        public override string ToString()
        {
            return _cstvalue.ToString() ;
        }
        public override Value ToValue()
        {
            return new Value(_cstvalue);
        }
    }
}
