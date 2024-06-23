using System;
using Runtime.ShapeComponents;
using Runtime.ShapeComponents.Impl;
using UnityEngine;

namespace Runtime.Logic
{
    public class ShapeManager : MonoBehaviour
    {
        private GameObject _shapeGO;
        private Shape currentShape;
        public Shape CurrentShape => currentShape;
        
        private void Start()
        {
            _shapeGO = new GameObject("Shape");
            _shapeGO.AddComponent<MeshFilter>();
            var meshRenderer = _shapeGO.AddComponent<MeshRenderer>();
            currentShape = _shapeGO.AddComponent<Parallelepiped>();
            
            var urpLitShader = Shader.Find("Universal Render Pipeline/Lit");
            if (urpLitShader != null)
            {
                meshRenderer.material = new Material(urpLitShader);
            }
            else
            {
                Debug.LogError("URP Lit Shader not found");
            }
            
            currentShape.transform.position = Vector3.zero;
        }

        public void SetShape(Type shapeType)
        {
            Destroy(currentShape);
            currentShape = (Shape)_shapeGO.AddComponent(shapeType);
        }


        public void SetColor(Color newColor)
        {
            if (currentShape != null)
            {
                currentShape.SetColor(newColor);
            }
        }
    }
}