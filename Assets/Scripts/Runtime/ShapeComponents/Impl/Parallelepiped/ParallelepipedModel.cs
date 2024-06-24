using System.Collections.Generic;
using Runtime.Enums;
using Runtime.ShapeComponents.Parameters;
using Runtime.ShapeComponents.Parameters.Impl;
using UnityEngine;

namespace Runtime.ShapeComponents.Impl.Parallelepiped
{
    public class ParallelepipedModel : ShapeModel
    {
        public ParallelepipedModel() : base(new Dictionary<EShapeParameter, IShapeParameter>
        {
            { EShapeParameter.Width, new FloatParameter(EShapeParameter.Width, 1f, 1f, 50f) },
            { EShapeParameter.Height, new FloatParameter(EShapeParameter.Height, 1f, 1f, 50f) },
            { EShapeParameter.Depth, new FloatParameter(EShapeParameter.Depth, 1f, 1f, 50) },
            { EShapeParameter.Color, new ColorParameter(EShapeParameter.Color, Color.red) },
        })
        {
        }
    }
}