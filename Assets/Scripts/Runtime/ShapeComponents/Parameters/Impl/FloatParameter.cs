using Runtime.Enums;
using UnityEngine;

namespace Runtime.ShapeComponents.Parameters.Impl
{
    public class FloatParameter : ShapeParameter<float>
    {
        public FloatParameter(EShapeParameter type, float value, float min = 0, float max = 100)
            : base(type, value)
        {
            MinValue = min;
            MaxValue = max;
        }

        public override void SetValue(float value)
        {
            Value = Mathf.Clamp(value, MinValue, MaxValue);
        }

        public override float Add(float value)
        {
            return Mathf.Clamp(Value + value, MinValue, MaxValue);
        }
    }
}