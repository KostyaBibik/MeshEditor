using UnityEngine;

namespace Runtime.MeshComponents
{
    public abstract class ShapePresenter<TModel> where TModel : IShapeModel
    {
        public TModel model { get; set; }
        public ShapeView view { get; set; }

        public void GenerateMesh(){
            var mesh = new Mesh();
            mesh.vertices = GenerateVertices();
            mesh.triangles = GenerateTriangles();
            mesh.RecalculateNormals();

            view.SetMesh(mesh);
            view.SetColor(model.Color);
        }
        
        protected abstract Vector3[] GenerateVertices();
        protected abstract int[] GenerateTriangles();
    }
}