using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Infrastructure.Factory.Impl
{
    public static class MeshFactory
    {
        public static Mesh CreateParallelepiped(float width, float height, float depth)
        {
            var mesh = new Mesh();

            var vertices = new Vector3[8];

            var halfWidth = width / 2;
            var halfHeight = height / 2;
            var halfDepth = depth / 2;

            vertices[0] = new Vector3(-halfWidth, -halfHeight, -halfDepth);
            vertices[1] = new Vector3(halfWidth, -halfHeight, -halfDepth);
            vertices[2] = new Vector3(halfWidth, halfHeight, -halfDepth);
            vertices[3] = new Vector3(-halfWidth, halfHeight, -halfDepth);
            vertices[4] = new Vector3(-halfWidth, -halfHeight, halfDepth);
            vertices[5] = new Vector3(halfWidth, -halfHeight, halfDepth);
            vertices[6] = new Vector3(halfWidth, halfHeight, halfDepth);
            vertices[7] = new Vector3(-halfWidth, halfHeight, halfDepth);

            mesh.vertices = vertices;

            var triangles = new[]
            {
                0, 2, 1, 0, 3, 2,
                4, 5, 6, 4, 6, 7,
                0, 1, 5, 0, 5, 4,
                2, 3, 7, 2, 7, 6,
                0, 4, 7, 0, 7, 3,
                1, 2, 6, 1, 6, 5
            };

            mesh.triangles = triangles;

            mesh.RecalculateNormals();
            mesh.RecalculateBounds();

            return mesh;
        }
        
        public static Mesh CreateSphere(float radius, int longitudeSegments, int latitudeSegments)
        {
            var mesh = new Mesh();

            var vertices = new List<Vector3>();
            var triangles = new List<int>();

            var pi = Mathf.PI;
            var twoPi = pi * 2f;

            for (var lat = 0; lat <= latitudeSegments; lat++)
            {
                var theta = lat * pi / latitudeSegments;
                var sinTheta = Mathf.Sin(theta);
                var cosTheta = Mathf.Cos(theta);

                for (var lon = 0; lon <= longitudeSegments; lon++)
                {
                    var phi = lon * twoPi / longitudeSegments;
                    var sinPhi = Mathf.Sin(phi);
                    var cosPhi = Mathf.Cos(phi);

                    var x = cosPhi * sinTheta;
                    var y = cosTheta;
                    var z = sinPhi * sinTheta;

                    vertices.Add(new Vector3(x, y, z) * radius);
                }
            }

            for (var lat = 0; lat < latitudeSegments; lat++)
            {
                for (var lon = 0; lon < longitudeSegments; lon++)
                {
                    var first = (lat * (longitudeSegments + 1)) + lon;
                    var second = first + longitudeSegments + 1;

                    triangles.Add(first);
                    triangles.Add(second);
                    triangles.Add(first + 1);

                    triangles.Add(second);
                    triangles.Add(second + 1);
                    triangles.Add(first + 1);
                }
            }

            mesh.vertices = vertices.ToArray();
            mesh.triangles = triangles.ToArray();

            mesh.RecalculateNormals();
            mesh.RecalculateBounds();

            return mesh;
        }
    }
}