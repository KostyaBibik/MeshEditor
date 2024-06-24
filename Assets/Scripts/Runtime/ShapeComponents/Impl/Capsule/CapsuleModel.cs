using System.Collections.Generic;
using Runtime.Enums;
using Runtime.ShapeComponents.Parameters;
using Runtime.ShapeComponents.Parameters.Impl;
using UnityEngine;

namespace Runtime.ShapeComponents.Impl.Capsule
{
    public class CapsuleModel : ShapeModel
    {
        public CapsuleModel() : base(new Dictionary<EShapeParameter, IShapeParameter>
        {
            { EShapeParameter.Radius, new FloatParameter(EShapeParameter.Radius, 1f, 0.1f, 10f) },
            { EShapeParameter.Height, new FloatParameter(EShapeParameter.Height, 2f, 1f, 50f) },
            { EShapeParameter.Segments, new IntParameter(EShapeParameter.Segments, 16, 4, 50) },
            { EShapeParameter.Color, new ColorParameter(EShapeParameter.Color, Color.red) },
        })
        {
        }
    }
}