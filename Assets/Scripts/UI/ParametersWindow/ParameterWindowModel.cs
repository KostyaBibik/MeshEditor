using System;
using Runtime.Enums;

namespace UI.ParametersWindow
{
    public class ParameterWindowModel
    {
        public ParameterInformation[] parameters;
    }

    public struct ParameterInformation
    {
        public string name;
        public EShapeParameter type;
        public float value;
        public float minValue;
        public float maxValue;
        public Action<float> onChangeValue;
        public bool isWholeValue;
    }
}