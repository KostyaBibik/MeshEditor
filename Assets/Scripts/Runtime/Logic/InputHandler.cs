using Runtime.Enums;
using UnityEngine;

namespace Runtime.Logic
{
    public class InputHandler : MonoBehaviour
    {
        private ShapeManager _shapeManager;
        private bool _test;
        
        private void Awake()
        {
            _shapeManager = GetComponent<ShapeManager>();
        }

        private void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ChangeShapeParameter(EShapeParameter.Width, 1f);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ChangeShapeParameter(EShapeParameter.Height, 1f);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                ChangeShapeParameter(EShapeParameter.Depth, 1f);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                ChangeShapeParameter(EShapeParameter.LongitudeSegments, 1f);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                ChangeShapeParameter(EShapeParameter.LatitudeSegments, 1f);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                ChangeShapeParameter(EShapeParameter.Radius, .5f);
            } 
            else if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                ChangeShapeParameter(EShapeParameter.Segments, 1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                ChangeShapeParameter(EShapeParameter.Sides, 1);
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                _shapeManager.SetShape(EShapeType.Sphere);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                _shapeManager.SetShape(EShapeType.Prism);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                _shapeManager.SetShape(EShapeType.Parallelepiped);
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                _shapeManager.SetShape(EShapeType.Capsule);
            }
        }

        private void ChangeShapeParameter<T>(EShapeParameter parameter, T delta) where T : struct
        {
            _shapeManager.CurrentShape.ChangeParameterValue(parameter, delta);
        }
    }
}