﻿using System.Collections.Generic;
using Runtime.Enums;
using Runtime.ShapeComponents.Parameters;
using Runtime.ShapeComponents.Parameters.Impl;

namespace Runtime.ShapeComponents.Impl
{
    public class SphereModel : ShapeModel
    {
        public SphereModel() : base(new Dictionary<EShapeParameter, IShapeParameter>
        {
            { EShapeParameter.Radius, new FloatParameter(EShapeParameter.Radius, 1f, 0.1f, 10f) },
            { EShapeParameter.LongitudeSegments, new IntParameter(EShapeParameter.LongitudeSegments, 4, 3, 100) },
            { EShapeParameter.LatitudeSegments, new IntParameter(EShapeParameter.LatitudeSegments, 4, 2, 100) }
        })
        {
        }
    }
}