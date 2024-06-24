using System.Linq;
using UIKit.Elements;
using UIKit.Elements.Models;
using UISystem;

namespace UI.SelectShapeWindow
{
    public class SelectShapeWindow : UIWindow<SelectShapeModel>
    {
        [AutoSetupField] private ButtonView _changeShaderMode;
        
        private SelectShapeElementView[] _lines;
        
        protected override void UpdateView(SelectShapeModel model)
        {
            UpdateItemsCount(model.SelectorElements.Length);
            UpdateContent(model.SelectorElements);

            var btnModel = new ButtonModel();
            btnModel.ClickCallback = model.changeShaderModeCallback;
            _changeShaderMode.InvokeUpdateView(btnModel);
        }

        private void UpdateItemsCount(int count)
        {
            if (_lines == null || !_lines.Any())
            {
                var template = gameObject.GetElement<SelectShapeElementView>(UIConstantDictionary.Names.DefaultTemplateTag);
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

        private void UpdateContent(SelectorInformation[] elements)
        {
            for (var i = 0; i < elements.Length; i++)
            {
                var parameter = elements[i];
                var lineElement = _lines[i];
                var elementModel = new SelectShapeElementModel();
                
                elementModel.onClickCallback = parameter.onSelectCallback;
                elementModel.icon = parameter.icon;
                elementModel.type = elementModel.type;
                
                lineElement.InvokeUpdateView(elementModel);
                lineElement.BeginShow();
            }
        }
    }
}