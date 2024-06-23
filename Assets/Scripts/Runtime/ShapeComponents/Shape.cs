using System;
using System.Collections.Generic;
using Runtime.Enums;
using UnityEngine;

namespace Runtime.ShapeComponents
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public abstract class Shape : MonoBehaviour
    {
        protected Dictionary<EShapeParameter, FloatParameter> parameters;
        
        public Color color;
        
        protected MeshRenderer meshRenderer;
        protected MeshFilter meshFilter;

        protected Mesh mesh;

        public abstract void GenerateMesh();
        protected abstract void InitializeParameters();

        protected virtual void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            meshFilter = GetComponent<MeshFilter>();
        }

        private void Start()
        {
            GenerateMesh();
        }

        public void ChangeParameterValue(EShapeParameter parameter, float delta)
        {
            if (parameters.ContainsKey(parameter))
            {
                parameters[parameter].SetValue(parameters[parameter].Value + delta);
                ApplyParameters();
            }
        }
        
        public void ApplyParameters()
        {
            GenerateMesh();
        }
        
        public void SetColor(Color newColor)
        {
            color = newColor;
            // Apply color to the mesh
        }
    }
}