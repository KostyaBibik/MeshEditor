using Runtime.Enums;

namespace Runtime.ShapeComponents.Parameters
{
    public interface IShapeParameter
    {
        EShapeParameter Type { get; }
    }

    public interface IShapeParameter<T> : IShapeParameter
    {
        T Value { get; }
        T MaxValue { get; }
        T MinValue { get; }
        void SetValue(T value);
        T Add(T value);
    }
}