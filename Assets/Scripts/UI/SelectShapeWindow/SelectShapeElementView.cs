using System;
using Runtime.Enums;
using UIKit.Elements;
using UIKit.Elements.Models;
using UISystem;
using UnityEngine;
using UnityEngine.UI;

namespace UI.SelectShapeWindow
{
    public class SelectShapeElementModel
    {
        public Sprite icon;
        public Action onClickCallback;
        public EShapeType type;
    }
    
    public class SelectShapeElementView : UIElementView<SelectShapeElementModel>
    {
        [AutoSetupField] private ButtonView button;
        [AutoSetupField] private Image icon;
        
        protected override void UpdateView(SelectShapeElementModel model)
        {
            icon.sprite = model.icon;
            
            var btnModel = new ButtonModel();
            btnModel.ClickCallback = model.onClickCallback;
            button.InvokeUpdateView(btnModel);
        }
    }
}