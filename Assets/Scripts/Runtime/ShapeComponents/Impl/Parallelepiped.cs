using System.Collections.Generic;
using Runtime.Enums;
using Runtime.Infrastructure.Factory.Impl;
using UnityEngine;

namespace Runtime.ShapeComponents.Impl
{
    public class Parallelepiped : Shape
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
                { EShapeParameter.Width, new FloatParameter(EShapeParameter.Width, 1f, 0.1f, 10f) },
                { EShapeParameter.Height, new FloatParameter(EShapeParameter.Height, 1f, 0.1f, 10f) },
                { EShapeParameter.Depth, new FloatParameter(EShapeParameter.Depth, 1f, 0.1f, 10f) }
            };
        }
        
        public override void GenerateMesh()
        {
            var width = parameters[EShapeParameter.Width].Value;
            var height = parameters[EShapeParameter.Height].Value;
            var depth = parameters[EShapeParameter.Depth].Value;
            meshFilter.mesh = MeshFactory.CreateParallelepiped(width, height, depth);
        }
    }
}