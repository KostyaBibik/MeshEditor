using UnityEngine;

namespace Runtime.ShapeComponents
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public abstract class ShapeView : MonoBehaviour
    {
        private MeshRenderer _meshRenderer;
        private MeshFilter _meshFilter;

        protected virtual void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            _meshFilter = GetComponent<MeshFilter>();
        }

        public void SetMesh(Mesh mesh)
        {
            _meshFilter.mesh = mesh;
        }

        public void SetMaterial(Material material)
        {
            if (_meshRenderer != null)
            {
                _meshRenderer.material = material;
            }
        }

        public void SetColor(Color color)
        {
            if (_meshRenderer != null)
            {
                _meshRenderer.material.color = color;
            }
        }
    }
}