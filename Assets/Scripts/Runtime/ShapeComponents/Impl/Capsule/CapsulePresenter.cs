using Runtime.Enums;
using Runtime.Infrastructure.Factory.Impl;

namespace Runtime.ShapeComponents.Impl.Capsule
{
    public class CapsulePresenter : ShapePresenter
    {
        public CapsulePresenter(ShapeModel model, ShapeView view) : base(model, view)
        {
            UpdateView();
        }

        public override void UpdateView()
        {
            var radius = model.GetParameterValue<float>(EShapeParameter.Radius);
            var height = model.GetParameterValue<float>(EShapeParameter.Height);
            var segments = model.GetParameterValue<int>(EShapeParameter.Segments);
            
            var mesh = MeshFactory.CreateCapsule(radius, height, segments);
            view.SetMesh(mesh);
        }
    }
}