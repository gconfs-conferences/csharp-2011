using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAS.Expression
{
    class Pow : Exp
    {
        Exp _A, _B;
        public Pow(Exp A, Exp B) { _A = A; _B = B; }
        public override Exp Diff(string Var)
        {
            Exp _A_Simp = _A.Simplify();
            Exp _B_Simp = _B.Simplify();

            return new Pow(new Value("e"), (_B_Simp * new Ln(_A_Simp))) *  (_B_Simp * new Ln(_A_Simp)).Diff(Var);

        }
        public override Exp Evaluate()
        {
            return new Mul(_A, _B); ;
        }
        public override Exp Simplify()
        {
            Exp _A_Simp = _A.Simplify();
            Exp _B_Simp = _B.Simplify();
            if (_A_Simp.IsConst())
            {
                if (_A_Simp.IsNull()) { return 0; }
                if (_B_Simp.IsConst())
                {
                    if (_B_Simp.IsNull()) { return 1; }
                    return (float)System.Math.Pow( _A_Simp.ToValue().ToFloat()  ,_B_Simp.ToValue().ToFloat());
                }
                if (_A_Simp.ToValue().ToFloat() == 1.0f)
                { return 1.0f; }
                return new Pow(_A_Simp , _B_Simp);
            }
            if (_B_Simp.IsConst())
            {
                if (_B_Simp.IsNull()) { return 1; }
                if (_B_Simp.ToValue().ToFloat() == 1.0f) { return _A_Simp; }
                return new Pow(_A_Simp , _B_Simp);
            }
            return new Pow(_A_Simp , _B_Simp);
        }
        public override Value ToValue()
        {
            Exp _A_Simp = _A.Simplify();
            Exp _B_Simp = _B.Simplify();
            return new Value((float)System.Math.Pow(_A_Simp.ToValue().ToFloat(), _B_Simp.ToValue().ToFloat()));
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
            return "("+_A.ToString() + ") ^ (" + _B.ToString()+")";
        }

    }
}
