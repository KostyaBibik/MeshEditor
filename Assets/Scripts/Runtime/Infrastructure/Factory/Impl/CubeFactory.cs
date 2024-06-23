using Runtime.MeshComponents;
using Runtime.MeshComponents.Impl.Cube;
using UnityEngine;

namespace Runtime.Infrastructure.Factory.Impl
{
    public class CubeFactory : IShapeFactory
    {
        public IShapeModel CreateShapeModel(float length, float width, float height, Color color)
        {
            return new CubeModel(length, width, height, color);
        }

        public ShapePresenter<IShapeModel> CreateShapePresenter(IShapeModel model, ShapeView view)
        {
            return null;
            //return new CubePresenter(model, view);
        }
    }
}