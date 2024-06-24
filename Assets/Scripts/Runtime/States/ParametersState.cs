using System.Collections.Generic;
using GlobalState;
using Runtime.Enums;
using Runtime.ShapeComponents.Parameters;

namespace Runtime.States
{
    public class ParametersState : State
    {
        public EShapeType type;
        public Dictionary<EShapeParameter, IShapeParameter> parameters;
        
        public override State Copy()
        {
            var instance = new ParametersState();

            instance.type = type;
            instance.parameters = parameters;
            
            return instance;
        }
    }
}