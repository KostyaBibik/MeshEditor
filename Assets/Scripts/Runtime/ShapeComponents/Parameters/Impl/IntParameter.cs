using Runtime.Enums;
using UnityEngine;

namespace Runtime.ShapeComponents.Parameters.Impl
{
    public class IntParameter : ShapeParameter<int>
    {
        public IntParameter(EShapeParameter type, int value, int min = 0, int max = 100)
            : base(type, value)
        {
            MinValue = min;
            MaxValue = max;
        }

        public override void SetValue(int value)
        {
            Value = Mathf.Clamp(value, MinValue, MaxValue);
        }

        public override int Add(int value)
        {
            return Mathf.Clamp(Value + value, MinValue, MaxValue);
        }
    }
}