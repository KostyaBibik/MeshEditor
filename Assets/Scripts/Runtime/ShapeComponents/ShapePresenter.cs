using System.Collections.Generic;
using Runtime.Enums;
using Runtime.ShapeComponents.Parameters;
using UnityEngine;

namespace Runtime.ShapeComponents
{
    public abstract class ShapePresenter
    {
        protected ShapeModel model;
        protected ShapeView view;

        public ShapeView View => view;
        
        protected ShapePresenter(ShapeModel shapeModel, ShapeView shapeView)
        {
            model = shapeModel;
            view = shapeView;
        }

        public void ChangeParameterValue<T>(EShapeParameter parameter, T value) where T : struct
        {
            model.ChangeParameterValue(parameter, value);
            UpdateView();
        }

        public void SetMaterial(Material material)
        {
            View.SetMaterial(material);
        }

        public abstract void UpdateView();

        public virtual Dictionary<EShapeParameter, IShapeParameter> GetParameters()
        {
            return model.Parameters;
        }
    }
}