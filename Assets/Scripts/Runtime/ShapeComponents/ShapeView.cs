using UnityEngine;

namespace Runtime.ShapeComponents
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public abstract class ShapeView : MonoBehaviour
    {
        protected MeshRenderer meshRenderer;
        protected MeshFilter meshFilter;

        protected virtual void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            meshFilter = GetComponent<MeshFilter>();
        }

        public void SetMesh(Mesh mesh)
        {
            meshFilter.mesh = mesh;
        }

        public void SetColor(Color color)
        {
            if (meshRenderer != null)
            {
                meshRenderer.material.color = color;
            }
        }
    }
}