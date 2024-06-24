using Runtime.Enums;
using UnityEngine;

namespace Runtime.Logic
{
    public class InputHandler : MonoBehaviour
    {
        private ShapeService _shapeService;
        private bool _test;
        
        private void Awake()
        {
            _shapeService = GetComponent<ShapeService>();
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
                _shapeService.SetShape(EShapeType.Sphere);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                _shapeService.SetShape(EShapeType.Prism);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                _shapeService.SetShape(EShapeType.Parallelepiped);
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                _shapeService.SetShape(EShapeType.Capsule);
            }
        }

        private void ChangeShapeParameter<T>(EShapeParameter parameter, T delta) where T : struct
        {
            _shapeService.CurrentShape.ChangeParameterValue(parameter, delta);
        }
    }
}