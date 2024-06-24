using UI.ParametersWindow;
using UI.SelectShapeWindow;
using UnityEngine;

namespace Runtime.Logic
{
    public class Runtime : MonoBehaviour
    {
        [SerializeField] private InitParametersStage initParametersStage;
        [SerializeField] private InitSelectShapeWindow initSelectShapeWindow;
        
        private void Awake()
        {
            initParametersStage.Init();   
            initSelectShapeWindow.Init();
        }
    }
}