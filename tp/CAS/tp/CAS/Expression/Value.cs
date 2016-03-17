using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAS.Expression
{
    class Value
    {
        float _val = 0;
        string _spec = "";
        public Value(Value Value) { _val = Value._val; _spec = Value._spec; }
        public Value(float Value) { _val = Value; }
        public Value(int Value) { _val = (float)Value; }
        public Value(string Value) 
        {
            switch (Value)
            {
                case "PI":
                case "Pi":
                case "π": _val = 3.14159265f; _spec = "π"; break;
                case "e":
                case "℮": _val = 2.71828183f; _spec = "℮"; break;
                default: _val = System.Convert.ToSingle(Value.Replace('.', ',')); break;

            }
        }
        public float ToFloat()
        {
            return _val;
        }
        public override string ToString()
        {
            return (_spec == "") ? _val.ToString() : _spec;
        }
       
    }
}
