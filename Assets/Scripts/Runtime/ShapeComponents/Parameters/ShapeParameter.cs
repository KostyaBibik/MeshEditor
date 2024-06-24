using Runtime.Enums;

namespace Runtime.ShapeComponents.Parameters
{
    public abstract class ShapeParameter<T> : IShapeParameter<T> where T : struct
    {
        public EShapeParameter Type { get; private set; }
        public T Value { get; set; }
        public T MaxValue { get; set; }
        public T MinValue { get; set; }

        protected ShapeParameter(EShapeParameter type, T value)
        {
            Type = type;
            Value = value;
        }

        public abstract void SetValue(T value);
        public abstract T Add(T value);
    }
}