using System.Collections.Generic;
using Runtime.Enums;
using Runtime.ShapeComponents.Parameters;
using Runtime.ShapeComponents.Parameters.Impl;

namespace Runtime.ShapeComponents.Impl.Prism
{
    public class PrismModel : ShapeModel
    {
        public PrismModel() : base(new Dictionary<EShapeParameter, IShapeParameter>
        {
            { EShapeParameter.Radius, new FloatParameter(EShapeParameter.Radius, 1f, 0.1f, 10f) },
            { EShapeParameter.Height, new FloatParameter(EShapeParameter.Height, 1f, 0.1f, 10f) },
            { EShapeParameter.Sides, new IntParameter(EShapeParameter.Sides, 6, 3, 20) }
        })
        {
        }
    }
}