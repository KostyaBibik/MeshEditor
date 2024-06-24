using System;
using System.Linq;
using GlobalState;
using Runtime.Logic;
using Runtime.ShapeComponents.Parameters;
using Runtime.States;
using UISystem;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UI.ParametersWindow
{
    [Serializable]
    public class InitParametersStage
    {
        [SerializeField] private Gradient colorGradient;
        
        private ParametersWindow _parametersWindow;
        private ShapeService _shapeService;
        
        public void Init()
        {
            _parametersWindow = UIManager.Instance.GetUIElement<ParametersWindow>();
            _shapeService = Object.FindObjectOfType<ShapeService>();
            
            StateManager.Instance.TrackStateChanging<ParametersState>(OnChangeParameters);
        }

        private void OnChangeParameters(ParametersState state)
        {
            var model = new ParameterWindowModel();
            model.parameters = state.parameters.Select(info => new ParameterInformation
            {
                name = info.Key.ToString(),
                type = info.Key,
                value = info.Value switch
                {
                    IShapeParameter<float> floatParam => floatParam.Value,
                    IShapeParameter<int> intParam => intParam.Value,
                    IShapeParameter<Color> => 0f,
                    _ => 0f
                },
                minValue = info.Value switch
                {
                    IShapeParameter<float> floatParam => floatParam.MinValue,
                    IShapeParameter<int> intParam => intParam.MinValue,
                    IShapeParameter<Color> => 0f,
                    _ => 0f
                },
                maxValue = info.Value switch
                {
                    IShapeParameter<float> floatParam => floatParam.MaxValue,
                    IShapeParameter<int> intParam => intParam.MaxValue,
                    IShapeParameter<Color> => 1f,
                    _ => 0f
                },
                onChangeValue = value =>
                {
                    if (info.Value is IShapeParameter<int>)
                    {
                        _shapeService.CurrentShape.ChangeParameterValue(info.Key, (int)value);
                    }
                    else if (info.Value is IShapeParameter<float>)
                    {
                        _shapeService.CurrentShape.ChangeParameterValue(info.Key, value);
                    }
                    else if (info.Value is IShapeParameter<Color>)
                    {
                        var color = colorGradient.Evaluate(value);
                        _shapeService.CurrentShape.ChangeParameterValue(info.Key, color);
                    }
                },
                isWholeValue = info.Value is IShapeParameter<int>
            }).ToArray();
            _parametersWindow.InvokeUpdateView(model);
            _parametersWindow.BeginShow();
        }
    }
}