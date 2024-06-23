using System;
using Runtime.Infrastructure.Factory;
using Runtime.Infrastructure.Factory.Impl;
using Runtime.MeshComponents;
using Runtime.MeshComponents.Impl;
using Runtime.MeshComponents.Impl.Cube;
using UnityEngine;

namespace Runtime.Logic
{
    public class TestUse: MonoBehaviour
    {
        private CubeView _cube;
        private ShapePresenter<IShapeModel> _cubePresenter;

        void Start()
        {
            /*GameObject cubeObject = new GameObject("Cube");
            cubeObject.AddComponent<MeshFilter>();
            cubeObject.AddComponent<MeshRenderer>();
            
            var cubeView = cubeObject.AddComponent<CubeView>();
            var factory = new CubeFactory();
            var cubeModel = factory.CreateShapeModel(2f, 1f, 3f, Color.red);
            _cubePresenter = factory.CreateShapePresenter(cubeModel, cubeView);
            
            cubeView.transform.position = Vector3.zero;*/
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var cubeModel = _cubePresenter.model;
                /*cubeModel.Length++;
                cubeModel.Width = 1f;
                cubeModel.Height++;*/
                _cubePresenter.GenerateMesh();
            }
        }
    }
}