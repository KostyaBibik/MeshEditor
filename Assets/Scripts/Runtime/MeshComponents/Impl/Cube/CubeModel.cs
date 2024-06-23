using UnityEngine;

namespace Runtime.MeshComponents.Impl.Cube
{
    public class CubeModel : IShapeModel
    {
        public float Length { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public Color Color { get; set; }
        
        public CubeModel(float length, float width, float height, Color color)
        {
            Length = length;
            Width = width;
            Height = height;
            Color = color;
        }
    }
}