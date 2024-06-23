using Runtime.Enums;
using Runtime.ShapeComponents.Impl;
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
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                _test = !_test;
                _shapeManager.SetShape(_test 
                    ? typeof(Sphere)
                    : typeof(Parallelepiped));
            }
        }

        private void ChangeShapeParameter(EShapeParameter parameter, float delta)
        {
            _shapeManager.CurrentShape.ChangeParameterValue(parameter, delta);
        }
    }
}