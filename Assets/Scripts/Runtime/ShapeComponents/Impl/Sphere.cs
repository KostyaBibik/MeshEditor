using System.Collections.Generic;
using Runtime.Enums;
using Runtime.Infrastructure.Factory.Impl;

namespace Runtime.ShapeComponents.Impl
{
    public class Sphere : Shape
    {
        protected new void Awake()
        {
            base.Awake();
            
            InitializeParameters();
        }

        protected override void InitializeParameters()
        {
            parameters = new Dictionary<EShapeParameter, FloatParameter>
            {
                { EShapeParameter.Radius, new FloatParameter(EShapeParameter.Radius, 1f, 0.1f, 10f) },
                { EShapeParameter.LongitudeSegments, new FloatParameter(EShapeParameter.LongitudeSegments, 4f, 3f, 100f) },
                { EShapeParameter.LatitudeSegments, new FloatParameter(EShapeParameter.LatitudeSegments, 4f, 2f, 100f) }
            };
        }
        
        public override void GenerateMesh()
        {
            var radius = parameters[EShapeParameter.Radius].Value;
            var longitudeSegments = (int)parameters[EShapeParameter.LongitudeSegments].Value;
            var latitudeSegments = (int)parameters[EShapeParameter.LatitudeSegments].Value;

            meshFilter.mesh = MeshFactory.CreateSphere(radius, longitudeSegments, latitudeSegments);
        }
    }
}