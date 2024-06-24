using UnityEngine;

namespace Runtime.Logic
{
    public class RotationSystem : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 350f;
        
        private ShapeService _shapeService;
        
        private void Awake()
        {
            _shapeService = FindObjectOfType<ShapeService>();
        }
        
        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                var rotationInput = GetRotationInput();
                if (rotationInput != Vector2.zero)
                {
                    _shapeService.RotateCurrentShape(rotationInput, rotationSpeed);
                }
            }
        }

        private Vector2 GetRotationInput()
        {
            var horizontal = Input.GetAxis("Mouse X");
            var vertical = Input.GetAxis("Mouse Y");
            return new Vector2(horizontal, vertical);
        }
    }
}