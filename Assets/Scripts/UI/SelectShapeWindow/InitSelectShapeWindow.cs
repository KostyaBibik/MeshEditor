using System;
using Runtime.Enums;
using Runtime.Logic;
using UISystem;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UI.SelectShapeWindow
{
    [Serializable]
    public class InitSelectShapeWindow
    {
        [SerializeField] private Sprite sphereIcon;
        [SerializeField] private Sprite prismIcon;
        [SerializeField] private Sprite parallelepipedIcon;
        [SerializeField] private Sprite capsuleIcon;

        private ShapeService _shapeService;
        
        public void Init()
        {
            _shapeService = Object.FindObjectOfType<ShapeService>();
            var selectShapeWindow = UIManager.Instance.GetUIElement<SelectShapeWindow>();
            
            var selectShapeModel = new SelectShapeModel();
            selectShapeModel.SelectorElements = GetSelectInformation();
            selectShapeModel.changeShaderModeCallback = OnChangeShaderMode;
            selectShapeWindow.InvokeUpdateView(selectShapeModel);
            selectShapeWindow.BeginShow();
        }

        private void OnChangeShaderMode()
        {
            _shapeService.ChangeShaderMode();
        }
        
        private SelectorInformation[] GetSelectInformation()
        {
            var selectorElements = new[]
            {
                new SelectorInformation
                {
                    type = EShapeType.Sphere,
                    icon = sphereIcon,
                    onSelectCallback = () => _shapeService.SetShape(EShapeType.Sphere)
                },
                new SelectorInformation
                {
                    type = EShapeType.Prism,
                    icon = prismIcon,
                    onSelectCallback = () => _shapeService.SetShape(EShapeType.Prism)
                },
                new SelectorInformation
                {
                    type = EShapeType.Parallelepiped,
                    icon = parallelepipedIcon,
                    onSelectCallback = () => _shapeService.SetShape(EShapeType.Parallelepiped)
                },
                new SelectorInformation
                {
                    type = EShapeType.Capsule,
                    icon = capsuleIcon,
                    onSelectCallback = () => _shapeService.SetShape(EShapeType.Capsule)
                }
            };

            return selectorElements;
        }
    }
}