using System.Collections.Generic;
using Runtime.Enums;
using Runtime.ShapeComponents.Parameters;

namespace Runtime.ShapeComponents
{
    public class ShapeModel
    {
        public Dictionary<EShapeParameter, IShapeParameter> Parameters { get; private set; }

        public ShapeModel(Dictionary<EShapeParameter, IShapeParameter> parameters)
        {
            Parameters = parameters;
        }

        public void ChangeParameterValue<T>(EShapeParameter parameter, T delta) where T : struct
        {
            if (!Parameters.TryGetValue(parameter, out var param)) 
                return;
            
            if (param is IShapeParameter<T> shapeParam)
            {
                shapeParam.SetValue(shapeParam.Add(delta));
            }
        }

        public T GetParameterValue<T>(EShapeParameter parameter) where T : struct
        {
            if (Parameters.TryGetValue(parameter, out var param))
            {
                if (param is IShapeParameter<T> shapeParam)
                {
                    return shapeParam.Value;
                }
            }
            throw new KeyNotFoundException($"Parameter {parameter} not found in Parameters dictionary");
        }
    }
}