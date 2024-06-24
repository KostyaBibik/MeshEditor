using Runtime.Enums;
using UnityEngine;

namespace Runtime.ShapeComponents.Parameters.Impl
{
    public class FloatParameter : ShapeParameter<float>
    {
        private readonly float _min;
        private readonly float _max;

        public FloatParameter(EShapeParameter type, float value, float min = 0, float max = 100)
            : base(type, value)
        {
            _min = min;
            _max = max;
        }

        public override void SetValue(float value)
        {
            Value = Mathf.Clamp(value, _min, _max);
        }

        public override float Add(float value)
        {
            return Mathf.Clamp(Value + value, _min, _max);
        }
    }
}