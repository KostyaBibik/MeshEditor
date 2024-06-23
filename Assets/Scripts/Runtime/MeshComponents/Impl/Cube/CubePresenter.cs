using UnityEngine;

namespace Runtime.MeshComponents.Impl.Cube
{
    public class CubePresenter : ShapePresenter<CubeModel>
    {
        private CubeModel _cubeModel;
        private ShapeView _view;

        public CubePresenter(CubeModel cubeModel, ShapeView view)
        {
            _cubeModel = cubeModel;
            _view = view;
        }

        protected override Vector3[] GenerateVertices()
        {
            return new Vector3[] {
                // Bottom
                new Vector3(0, 0, 0),
                new Vector3(_cubeModel.Length, 0, 0),
                new Vector3(_cubeModel.Length, 0, _cubeModel.Width),
                new Vector3(0, 0, _cubeModel.Width),
                // Top
                new Vector3(0, _cubeModel.Height, 0),
                new Vector3(_cubeModel.Length, _cubeModel.Height, 0),
                new Vector3(_cubeModel.Length, _cubeModel.Height, _cubeModel.Width),
                new Vector3(0, _cubeModel.Height, _cubeModel.Width)
            };
        }

        protected override int[] GenerateTriangles()
        {
            return new int[] {
                // Bottom
                0, 2, 1,
                0, 3, 2,
                // Top
                4, 5, 6,
                4, 6, 7,
                // Front
                0, 1, 5,
                0, 5, 4,
                // Back
                2, 3, 7,
                2, 7, 6,
                // Left
                0, 4, 7,
                0, 7, 3,
                // Right
                1, 2, 6,
                1, 6, 5
            };
        }
    }
}