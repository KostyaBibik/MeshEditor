using Runtime.MeshComponents;
using UnityEngine;

namespace Runtime.Infrastructure.Factory
{
    public interface IShapeFactory
    {
        IShapeModel CreateShapeModel(float length, float width, float height, Color color);
        ShapePresenter<IShapeModel> CreateShapePresenter(IShapeModel model, ShapeView view);
    }
}