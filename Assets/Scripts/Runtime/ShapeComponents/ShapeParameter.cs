using Runtime.Enums;
using UnityEngine;

namespace Runtime.ShapeComponents
{
    public abstract class ShapeParameter
    {
        public EShapeParameter Type { get; private set; }

        protected ShapeParameter(EShapeParameter type)
        {
            Type = type;
        }

        public abstract void ApplyChange(Shape shape);
    }

    public class FloatParameter : ShapeParameter
    {
        public float Value { get; set; }
        private float min, max;

        public FloatParameter(EShapeParameter type, float value, float min = 0, float max = 100) 
            : base(type)
        {
            Value = value;
            this.min = min;
            this.max = max;
        }

        public void SetValue(float value)
        {
            Value = Mathf.Clamp(value, min, max);
        }

        public override void ApplyChange(Shape shape)
        {
            
        }
    }
}