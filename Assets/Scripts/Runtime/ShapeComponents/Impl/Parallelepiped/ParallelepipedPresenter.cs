using Runtime.Enums;
using Runtime.Infrastructure.Factory.Impl;
using UnityEngine;

namespace Runtime.ShapeComponents.Impl.Parallelepiped
{
    public class ParallelepipedPresenter : ShapePresenter
    {
        public ParallelepipedPresenter(ShapeModel model, ShapeView view) : base(model, view)
        {
            UpdateView();
        }

        public override void UpdateView()
        {
            var width = model.GetParameterValue<float>(EShapeParameter.Width);
            var height = (int)model.GetParameterValue<float>(EShapeParameter.Height);
            var depth = (int)model.GetParameterValue<float>(EShapeParameter.Depth);
            
            var mesh = MeshFactory.CreateParallelepiped(width, height, depth);
            View.SetMesh(mesh);

            var color = model.GetParameterValue<Color>(EShapeParameter.Color);
            View.SetColor(color);
        }
    }
}