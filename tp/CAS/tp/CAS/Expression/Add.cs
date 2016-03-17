using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAS.Expression
{
    class Add : Exp
    {
        Exp _A, _B;
        public Add(Exp A, Exp B) { _A = A; _B = B; }
        public override Exp Diff(string Var)
        {
            Exp _A_Simp = _A.Simplify();
            Exp _B_Simp = _B.Simplify();
            return new Add(_A_Simp.Diff(Var), _B_Simp.Diff(Var));
        }
        public override Exp Evaluate()
        {
            return new Add(_A, _B); ;
        }
        public override Exp Simplify()
        {
            
            Exp _A_Simp = _A.Simplify();
            Exp _B_Simp = _B.Simplify();
            if (_A_Simp.IsConst())
            {
                if (_B_Simp.IsConst())
                {
                    return _A_Simp.ToValue().ToFloat() + _B_Simp.ToValue().ToFloat();
                }
                if (_A_Simp.IsNull())
                {
                    return _B_Simp;
                }
                return _A_Simp + _B_Simp;
            }
            if (_B_Simp.IsConst())
            {
                if (_B_Simp.IsNull())
                {
                    return _A_Simp;
                }
                return _A_Simp + _B_Simp;
            }
            return _A_Simp + _B_Simp;
        }
        public override Value ToValue()
        {
            return new Value(_A.ToValue().ToFloat() + _B.ToValue().ToFloat());
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
            return _A.ToString() + " + " + _B.ToString();
        }
        
    }
}
