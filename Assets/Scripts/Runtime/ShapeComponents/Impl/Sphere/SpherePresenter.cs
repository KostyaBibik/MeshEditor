using Runtime.Enums;
using Runtime.Infrastructure.Factory.Impl;
using UnityEngine;

namespace Runtime.ShapeComponents.Impl.Sphere
{
    public class SpherePresenter : ShapePresenter
    {
        public SpherePresenter(SphereModel model, SphereView view) : base(model, view)
        {
            UpdateView();
        }

        public override void UpdateView()
        {
            var radius = model.GetParameterValue<float>(EShapeParameter.Radius);
            var longitudeSegments = model.GetParameterValue<int>(EShapeParameter.LongitudeSegments);
            var latitudeSegments = model.GetParameterValue<int>(EShapeParameter.LatitudeSegments);

            var mesh = MeshFactory.CreateSphere(radius, longitudeSegments, latitudeSegments);
            View.SetMesh(mesh);
            
            var color = model.GetParameterValue<Color>(EShapeParameter.Color);
            View.SetColor(color);
        }
    }
}