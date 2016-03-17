using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAS.Expression
{
    class Ln : Exp
    {
        Exp _A;
        public Ln(Exp A) { _A = A; }
        public override Exp Diff(string Var)
        
        {
            Exp _A_Simp = _A.Simplify();
            return (1 / _A_Simp) * _A_Simp.Diff(Var);

        }
        public override Exp Evaluate()
        {
            return new Ln(_A); ;
        }
        public override Exp Simplify()
        {
            Exp _A_Simp = _A.Simplify();
            if (_A_Simp.IsConst())
            {
                if (_A_Simp.IsNull()) { return new Cst(float.NegativeInfinity); }
                if (_A_Simp.ToValue().ToFloat() == 1.0f){ return 0.0f; }
                if (_A_Simp.ToValue().ToString() == "℮") { return 1.0f; }
                if (_A_Simp.ToValue().ToFloat() > 0.0f) { return (float)Math.Log(_A_Simp.ToValue().ToFloat(), Math.E); }
            }
            return new Ln(_A_Simp);
        }
        public override Value ToValue()
        {
            return new Value(_A.ToValue().ToFloat());
        }
        public override bool IsNull()
        {
            Exp _A_Simp = _A.Simplify();
            return _A_Simp.IsConst() && _A_Simp.ToValue().ToFloat() == 1.0f;
        }
        public override bool IsConst()
        {
            Exp _A_Simp = _A.Simplify();
            return _A_Simp.IsConst();
        }
        public override string ToString()
        {
            return "ln( "+_A.ToString()+" )";
        }

    }
}
