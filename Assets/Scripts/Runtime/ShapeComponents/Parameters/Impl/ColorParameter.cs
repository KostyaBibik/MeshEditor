using Runtime.Enums;
using UnityEngine;

namespace Runtime.ShapeComponents.Parameters.Impl
{
    public class ColorParameter : ShapeParameter<Color>
    {
        public ColorParameter(EShapeParameter type, Color value)
            : base(type, value)
        {
        }

        public override void SetValue(Color value)
        {
            Value = value;
        }

        public override Color Add(Color value)
        {
            return Value + value; 
        }
    }
}