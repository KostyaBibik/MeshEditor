using Runtime.Enums;
using Runtime.Infrastructure.Factory.Impl;

namespace Runtime.ShapeComponents.Impl.Prism
{
    public class PrismPresenter : ShapePresenter
    {
        public PrismPresenter(ShapeModel model, ShapeView view) : base(model, view)
        {
            UpdateView();
        }

        public override void UpdateView()
        {
            var radius = model.GetParameterValue<float>(EShapeParameter.Radius);
            var height = model.GetParameterValue<float>(EShapeParameter.Height);
            var sides = model.GetParameterValue<int>(EShapeParameter.Sides);
            
            var mesh = MeshFactory.CreatePrism(radius, height, sides);
            view.SetMesh(mesh);
        }
    }
}