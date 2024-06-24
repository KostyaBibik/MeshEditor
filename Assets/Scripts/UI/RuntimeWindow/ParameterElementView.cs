using UISystem;

namespace UI.RuntimeWindow
{
    public class ParameterElementModel
    {
        public float value;
        public string name;
    }
    
    public class ParameterElementView : UIElementView<ParameterElementModel>
    {
        protected override void UpdateView(ParameterElementModel model)
        {
            
        }
    }
}