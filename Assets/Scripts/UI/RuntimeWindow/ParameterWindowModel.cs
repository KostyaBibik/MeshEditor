using Runtime.Enums;

namespace UI.RuntimeWindow
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
    }
}