using System.Linq;
using UISystem;

namespace UI.RuntimeWindow
{
    public class ParametersWindow : UIWindow<ParameterWindowModel>
    {
        private ParameterElementView[] _lines;
        
        protected override void UpdateView(ParameterWindowModel model)
        {
            UpdateItemsCount(model.parameters.Length);
            UpdateContent(model.parameters);
        }
        
        private void UpdateItemsCount(int count)
        {
            if (_lines == null || !_lines.Any())
            {
                var template = gameObject.GetElement<ParameterElementView>(UIConstantDictionary.Names.DefaultTemplateTag);
                _lines = new[] { template };
            }
        
            if (count > _lines.Length)
            {
                var template = _lines.First();
                var createCount = count - _lines.Length;
                _lines = _lines.Concat(Enumerable.Range(0, createCount)
                        .Select(_ => UIManager.InstantiateElement(template)))
                    .ToArray();
            }

            for (var i = 0; i < _lines.Length; i++)
            {
                var isActive = i < count;
                _lines[i].gameObject.SetActive(isActive);
            }
        }

        private void UpdateContent(ParameterInformation[] parameters)
        {
            for (var i = 0; i < parameters.Length; i++)
            {
                var parameter = parameters[i];
                var lineElement = _lines[i];
                
            }
        }
    }
}