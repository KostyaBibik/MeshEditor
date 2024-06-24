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
        
        public void Init()
        {
            var selectShapeWindow = UIManager.Instance.GetUIElement<SelectShapeWindow>();
            
            var selectShapeModel = new SelectShapeModel();
            selectShapeModel.SelectorElements = GetSelectInformation();
            selectShapeWindow.InvokeUpdateView(selectShapeModel);
            selectShapeWindow.BeginShow();
        }

        private SelectorInformation[] GetSelectInformation()
        {
            var shapeService = Object.FindObjectOfType<ShapeService>();

            var selectorElements = new[]
            {
                new SelectorInformation
                {
                    type = EShapeType.Sphere,
                    icon = sphereIcon,
                    onSelectCallback = () => shapeService.SetShape(EShapeType.Sphere)
                },
                new SelectorInformation
                {
                    type = EShapeType.Prism,
                    icon = prismIcon,
                    onSelectCallback = () => shapeService.SetShape(EShapeType.Prism)
                },
                new SelectorInformation
                {
                    type = EShapeType.Parallelepiped,
                    icon = parallelepipedIcon,
                    onSelectCallback = () => shapeService.SetShape(EShapeType.Parallelepiped)
                },
                new SelectorInformation
                {
                    type = EShapeType.Capsule,
                    icon = capsuleIcon,
                    onSelectCallback = () => shapeService.SetShape(EShapeType.Capsule)
                }
            };

            return selectorElements;
        }
    }
}