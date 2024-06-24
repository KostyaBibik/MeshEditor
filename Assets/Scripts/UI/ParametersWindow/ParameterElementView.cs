using System;
using System.Globalization;
using TMPro;
using UISystem;
using UnityEngine.UI;

namespace UI.ParametersWindow
{
    public class ParameterElementModel
    {
        public float value;
        public float minValue;
        public float maxValue;
        public string name;
        public Action<float> onChangeSliderValue;
        public bool isWholeValue;
    }
    
    public class ParameterElementView : UIElementView<ParameterElementModel>
    {
        [AutoSetupField] private TextMeshProUGUI _name;
        [AutoSetupField] private TextMeshProUGUI _value;
        [AutoSetupField] private Slider _valueSlider;
        
        protected override void UpdateView(ParameterElementModel model)
        {
            _valueSlider.onValueChanged.RemoveAllListeners();
            
            _name.text = model.name;
            _value.text = GetText(model.value, model.isWholeValue);
            
            _valueSlider.minValue = model.minValue;
            _valueSlider.maxValue = model.maxValue;
            _valueSlider.value = model.value;
            _valueSlider.onValueChanged.AddListener(value =>
            {
                model.onChangeSliderValue.Invoke(value);
                _value.text = GetText(value, model.isWholeValue);
            });
        }

        private string GetText(float value, bool isWholeValue)
        {
            return isWholeValue
                ? value.ToString("F0", CultureInfo.CurrentCulture)
                : value.ToString("F2", CultureInfo.CurrentCulture);
        }
    }
}