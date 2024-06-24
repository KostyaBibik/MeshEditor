using GlobalState;
using Runtime.Enums;
using Runtime.Infrastructure.Factory.Impl;
using Runtime.ShapeComponents;
using Runtime.States;
using UnityEngine;

namespace Runtime.Logic
{
    public class ShapeService : MonoBehaviour
    {
        private GameObject _shapeGO;
        private ShapePresenter currentPresenter;
        public ShapePresenter CurrentShape => currentPresenter;
        
        private void Start()
        {
            _shapeGO = new GameObject("Shape");
            _shapeGO.AddComponent<MeshFilter>();
            var meshRenderer = _shapeGO.AddComponent<MeshRenderer>();
            
            var urpLitShader = Shader.Find("Universal Render Pipeline/Lit");
            if (urpLitShader != null)
            {
                meshRenderer.material = new Material(urpLitShader);
            }
            else
            {
                Debug.LogError("URP Lit Shader not found");
            }

            _shapeGO.transform.position = Vector3.zero;
            SetShape(EShapeType.Parallelepiped);
        }

        public void SetShape(EShapeType type)
        {
            if (currentPresenter != null && currentPresenter.View != null)
            {
                Destroy(currentPresenter.View);
            }

            currentPresenter = ShapePresenterFactory.CreatePresenter(type, _shapeGO);

            var state = new ParametersState();
            state.type = type;
            state.parameters = currentPresenter.GetParameters();
            StateManager.Instance.SetState(state);
            
            currentPresenter.UpdateView();
            currentPresenter.View.transform.rotation = Quaternion.identity;
        }

        public void RotateCurrentShape(Vector2 rotationInput, float rotationSpeed)
        {
            if (currentPresenter != null && currentPresenter.View != null)
            {
                var shapeTransform = currentPresenter.View.transform; 
                shapeTransform.Rotate(Vector3.up, rotationInput.x * rotationSpeed * Time.deltaTime, Space.World);
                shapeTransform.Rotate(Vector3.right, -rotationInput.y * rotationSpeed * Time.deltaTime, Space.World);
            }
        }
    }
}