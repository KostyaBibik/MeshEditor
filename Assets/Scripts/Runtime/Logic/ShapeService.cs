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

        private Material standardMaterial;
        private Material wireframeMaterial;
        private bool _isWireframeMode;
        
        private void Start()
        {
            _shapeGO = new GameObject("Shape");
            _shapeGO.AddComponent<MeshFilter>();
            _shapeGO.AddComponent<MeshRenderer>();
            
            var baseShader = Shader.Find("Standard");
            var wireframeShader = Shader.Find("Unlit/WireframeShader");
            
            standardMaterial = new Material(baseShader);
            wireframeMaterial = new Material(wireframeShader);

            _shapeGO.transform.position = Vector3.zero;
            SetShape(EShapeType.Parallelepiped);
            ChangeShaderMode();
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

        public void ChangeShaderMode()
        {
            currentPresenter.SetMaterial(_isWireframeMode ? wireframeMaterial : standardMaterial);

            _isWireframeMode = !_isWireframeMode;
            currentPresenter.UpdateView();
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