using Runtime.Enums;
using UnityEngine;

namespace Runtime.ShapeComponents.Parameters.Impl
{
    public class IntParameter : ShapeParameter<int>
    {
        private readonly int _min;
        private readonly int _max;

        public IntParameter(EShapeParameter type, int value, int min = 0, int max = 100)
            : base(type, value)
        {
            _min = min;
            _max = max;
        }

        public override void SetValue(int value)
        {
            Value = Mathf.Clamp(value, _min, _max);
        }

        public override int Add(int value)
        {
            return Mathf.Clamp(Value + value, _min, _max);
        }
    }
}