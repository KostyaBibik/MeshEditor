using Runtime.Enums;
using UnityEngine;

namespace Runtime.ShapeComponents
{
    public abstract class ShapePresenter
    {
        protected ShapeModel model;
        protected ShapeView view;

        public ShapeView View => view;
        
        protected ShapePresenter(ShapeModel model, ShapeView view)
        {
            this.model = model;
            this.view = view;
        }

        public void ChangeParameterValue<T>(EShapeParameter parameter, T delta) where T : struct
        {
            model.ChangeParameterValue(parameter, delta);
            UpdateView();
        }

        public void SetColor(Color color)
        {
            view.SetColor(color);
        }

        public abstract void UpdateView();
    }
}