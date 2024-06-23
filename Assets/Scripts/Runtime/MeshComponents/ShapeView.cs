using UnityEngine;

namespace Runtime.MeshComponents
{
    public abstract class ShapeView : MonoBehaviour
    {
        protected MeshFilter meshFilter;
        protected MeshRenderer meshRenderer;
        
        private void Awake()
        {
            meshFilter = GetComponent<MeshFilter>();
            meshRenderer = GetComponent<MeshRenderer>();
        }

        private void Start()
        {
            var urpLitShader = Shader.Find("Universal Render Pipeline/Lit");
            if (urpLitShader != null)
            {
                meshRenderer.material = new Material(urpLitShader);
            }
            else
            {
                Debug.LogError("URP Lit Shader not found");
            }
        }

        public void SetMesh(Mesh mesh)
        {
            meshFilter.mesh = mesh;
        }

        public void SetColor(Color color)
        {
            if (meshRenderer != null && meshRenderer.material != null)
            {
                meshRenderer.material.color = color;
            }
        }
    }
}