using System;
using Runtime.Enums;
using Runtime.ShapeComponents;
using Runtime.ShapeComponents.Impl.Capsule;
using Runtime.ShapeComponents.Impl.Parallelepiped;
using Runtime.ShapeComponents.Impl.Prism;
using Runtime.ShapeComponents.Impl.Sphere;
using UnityEngine;

namespace Runtime.Infrastructure.Factory.Impl
{
    public static class ShapePresenterFactory
    {
        public static ShapePresenter CreatePresenter(EShapeType shapeType, GameObject shapeGO)
        {
            switch (shapeType)
            {
                case EShapeType.Sphere:
                {
                    var model = new SphereModel();
                    var view = shapeGO.AddComponent<SphereView>();
                    return new SpherePresenter(model, view);
                }
                case EShapeType.Parallelepiped:
                {
                    var model = new ParallelepipedModel();
                    var view = shapeGO.AddComponent<ParallelepipedView>();
                    return new ParallelepipedPresenter(model, view);
                }
                case EShapeType.Capsule:
                {
                    var model = new CapsuleModel();
                    var view = shapeGO.AddComponent<CapsuleView>();
                    return new CapsulePresenter(model, view);
                }
                case EShapeType.Prism:
                {
                    var model = new PrismModel();
                    var view = shapeGO.AddComponent<PrismView>();
                    return new PrismPresenter(model, view);
                }
                
                default:
                    throw new ArgumentException("Unknown shape type", nameof(shapeType));
            }
        }
    }
}