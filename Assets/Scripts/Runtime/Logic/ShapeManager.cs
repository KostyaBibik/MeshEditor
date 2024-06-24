using Runtime.Enums;
using Runtime.Infrastructure.Factory.Impl;
using Runtime.ShapeComponents;
using UnityEngine;

namespace Runtime.Logic
{
    public class ShapeManager : MonoBehaviour
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

            currentPresenter.UpdateView();
        }


        public void SetColor(Color newColor)
        {
            currentPresenter?.SetColor(newColor);
        }
    }
}