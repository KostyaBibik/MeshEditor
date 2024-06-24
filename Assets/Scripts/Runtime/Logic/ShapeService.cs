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
        private GameObject _shapeGo;
        private ShapePresenter _currentPresenter;
        
        private Material _standardMaterial;
        private Material _wireframeMaterial;
        
        private bool _isWireframeMode;
        
        public ShapePresenter CurrentShape => _currentPresenter;

        private void Start()
        {
            _shapeGo = new GameObject("Shape");
            _shapeGo.AddComponent<MeshFilter>();
            _shapeGo.AddComponent<MeshRenderer>();
            
            var baseShader = Shader.Find("Standard");
            var wireframeShader = Shader.Find("Unlit/WireframeShader");
            
            _standardMaterial = new Material(baseShader);
            _wireframeMaterial = new Material(wireframeShader);

            _shapeGo.transform.position = Vector3.zero;
            SetShape(EShapeType.Parallelepiped);
            ChangeShaderMode();
        }

        public void SetShape(EShapeType type)
        {
            if (_currentPresenter != null && _currentPresenter.View != null)
            {
                Destroy(_currentPresenter.View);
            }

            _currentPresenter = ShapePresenterFactory.CreatePresenter(type, _shapeGo);

            var state = new ParametersState();
            state.type = type;
            state.parameters = _currentPresenter.GetParameters();
            StateManager.Instance.SetState(state);
            
            _currentPresenter.UpdateView();
            _currentPresenter.View.transform.rotation = Quaternion.identity;
        }

        public void ChangeShaderMode()
        {
            _currentPresenter.SetMaterial(_isWireframeMode ? _wireframeMaterial : _standardMaterial);

            _isWireframeMode = !_isWireframeMode;
            _currentPresenter.UpdateView();
        }
        
        public void RotateCurrentShape(Vector2 rotationInput, float rotationSpeed)
        {
            if (_currentPresenter != null && _currentPresenter.View != null)
            {
                var shapeTransform = _currentPresenter.View.transform; 
                shapeTransform.Rotate(Vector3.up, rotationInput.x * rotationSpeed * Time.deltaTime, Space.World);
                shapeTransform.Rotate(Vector3.right, -rotationInput.y * rotationSpeed * Time.deltaTime, Space.World);
            }
        }
    }
}