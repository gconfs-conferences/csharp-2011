using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAS.Expression
{
    class Sub : Exp
    {
        Exp _A, _B;
        public Sub(Exp A, Exp B) { _A = A; _B = B; }
        public override Exp Diff(string Var)
        {
            Exp _A_Simp = _A.Simplify();
            Exp _B_Simp = _B.Simplify();
            return new Sub(_A_Simp.Diff(Var), _B_Simp.Diff(Var));
        }
        public override Exp Evaluate()
        {
            return new Sub(_A, _B); ;
        }
        public override Exp Simplify()
        {
            Exp _A_Simp = _A.Simplify();
            Exp _B_Simp = _B.Simplify();
            return (_A_Simp.IsConst()) ?
                        (_B_Simp.IsConst()) ? new Cst(_A.ToValue().ToFloat() - _B.ToValue().ToFloat()) : _A_Simp - _B_Simp
                        : (_B_Simp.IsConst()) ? _A_Simp -_A_Simp : _A_Simp - _B_Simp;
        }
        public override bool IsNull()
        {
            Exp _A_Simp = _A.Simplify();
            Exp _B_Simp = _B.Simplify();
            return _A_Simp.IsNull() && _B_Simp.IsNull();
        }
        public override bool IsConst()
        {
            Exp _A_Simp = _A.Simplify();
            Exp _B_Simp = _B.Simplify();
            return _A_Simp.IsConst() && _B_Simp.IsConst();
        }
        public override string ToString()
        {
            return "(" + _A.ToString() + ") - (" + _B.ToString() + ")";
        }
        public override Value ToValue()
        {
            return new Value(_A.ToValue().ToFloat() - _B.ToValue().ToFloat());
        }
    }
}
