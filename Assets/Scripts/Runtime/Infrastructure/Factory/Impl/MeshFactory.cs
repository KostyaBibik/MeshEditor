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
            for (var lon = 0; lon < longitudeSegments; lon++)
            {
                var first = lat * (longitudeSegments + 1) + lon;
                var second = first + longitudeSegments + 1;

                triangles.Add(first);
                triangles.Add(second);
                triangles.Add(first + 1);

                triangles.Add(second);
                triangles.Add(second + 1);
                triangles.Add(first + 1);
            }

            mesh.vertices = vertices.ToArray();
            mesh.triangles = triangles.ToArray();

            mesh.RecalculateNormals();
            mesh.RecalculateBounds();

            return mesh;
        }

        public static Mesh CreateCapsule(float radius, float height, int segments)
        {
            var mesh = new Mesh();

            var nbVerticesCap = (segments + 1) * (segments + 1);
            var nbVerticesSides = segments * 2 + 2;
            var nbTrianglesCap = segments * segments * 6;
            var nbTrianglesSides = segments * 6;

            var vertices = new Vector3[nbVerticesCap * 2 + nbVerticesSides];
            var triangles = new int[(nbTrianglesCap + nbTrianglesSides) * 3];
            var normals = new Vector3[vertices.Length];
            var uvs = new Vector2[vertices.Length];

            var vert = 0;
            var tri = 0;
            var _2pi = Mathf.PI * 2f;

            // Top Hemisphere
            for (var y = 0; y <= segments; y++)
            for (var x = 0; x <= segments; x++)
            {
                var xSegment = x / (float)segments;
                var ySegment = y / (float)segments;
                var xPos = Mathf.Cos(xSegment * _2pi) * Mathf.Sin(ySegment * Mathf.PI / 2) * radius;
                var yPos = Mathf.Cos(ySegment * Mathf.PI / 2) * radius + height / 2f;
                var zPos = Mathf.Sin(xSegment * _2pi) * Mathf.Sin(ySegment * Mathf.PI / 2) * radius;

                vertices[vert] = new Vector3(xPos, yPos, zPos);
                normals[vert] = vertices[vert].normalized;
                uvs[vert] = new Vector2(xSegment, ySegment * 0.5f);
                vert++;
            }

            // Bottom Hemisphere
            for (var y = 0; y <= segments; y++)
            for (var x = 0; x <= segments; x++)
            {
                var xSegment = x / (float)segments;
                var ySegment = y / (float)segments;
                var xPos = Mathf.Cos(xSegment * _2pi) * Mathf.Sin(ySegment * Mathf.PI / 2) * radius;
                var yPos = -Mathf.Cos(ySegment * Mathf.PI / 2) * radius - height / 2f;
                var zPos = Mathf.Sin(xSegment * _2pi) * Mathf.Sin(ySegment * Mathf.PI / 2) * radius;

                vertices[vert] = new Vector3(xPos, yPos, zPos);
                normals[vert] = vertices[vert].normalized;
                uvs[vert] = new Vector2(xSegment, 0.5f + ySegment * 0.5f);
                vert++;
            }

            // Cylinder sides
            for (var i = 0; i <= segments; i++)
            {
                var xSegment = i / (float)segments;
                var xPos = Mathf.Cos(xSegment * _2pi) * radius;
                var zPos = Mathf.Sin(xSegment * _2pi) * radius;

                vertices[vert] = new Vector3(xPos, height / 2f, zPos);
                vertices[vert + 1] = new Vector3(xPos, -height / 2f, zPos);

                normals[vert] = new Vector3(xPos, 0, zPos).normalized;
                normals[vert + 1] = new Vector3(xPos, 0, zPos).normalized;

                uvs[vert] = new Vector2(xSegment, 0.5f);
                uvs[vert + 1] = new Vector2(xSegment, 1f);

                vert += 2;
            }

            var baseIndex = 0;
            for (var y = 0; y < segments; y++)
            for (var x = 0; x < segments; x++)
            {
                var current = baseIndex + x + y * (segments + 1);
                var next = current + segments + 1;

                triangles[tri++] = current;
                triangles[tri++] = next + 1;
                triangles[tri++] = next;

                triangles[tri++] = current;
                triangles[tri++] = current + 1;
                triangles[tri++] = next + 1;
            }

            baseIndex = (segments + 1) * (segments + 1);
            for (var y = 0; y < segments; y++)
            for (var x = 0; x < segments; x++)
            {
                var current = baseIndex + x + y * (segments + 1);
                var next = current + segments + 1;

                triangles[tri++] = current;
                triangles[tri++] = next;
                triangles[tri++] = next + 1;

                triangles[tri++] = current;
                triangles[tri++] = next + 1;
                triangles[tri++] = current + 1;
            }

            baseIndex = (segments + 1) * (segments + 1) * 2;
            for (var i = 0; i < segments; i++)
            {
                var current = baseIndex + i * 2;
                var next = current + 2;

                triangles[tri++] = current;
                triangles[tri++] = next;
                triangles[tri++] = current + 1;

                triangles[tri++] = current + 1;
                triangles[tri++] = next;
                triangles[tri++] = next + 1;
            }

            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.normals = normals;
            mesh.uv = uvs;

            mesh.RecalculateBounds();
            mesh.RecalculateNormals();

            return mesh;
        }

        public static Mesh CreatePrism(float radius, float height, int sides)
        {
            var mesh = new Mesh();

            var vertices = new Vector3[sides * 2 + 2];
            var triangles = new int[sides * 12];
            var normals = new Vector3[vertices.Length];
            var uvs = new Vector2[vertices.Length];

            var angleStep = 360.0f / sides;
            var vert = 0;
            var tri = 0;

            // Bottom circle
            for (var i = 0; i < sides; i++)
            {
                var angle = Mathf.Deg2Rad * i * angleStep;
                vertices[vert] = new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius);
                normals[vert] = Vector3.down; // нормали направлены вниз
                uvs[vert] = new Vector2(vertices[vert].x / (2 * radius) + 0.5f, vertices[vert].z / (2 * radius) + 0.5f);
                vert++;
            }

            vertices[vert] = Vector3.zero; // центр нижнего круга
            normals[vert] = Vector3.down; // нормали направлены вниз
            uvs[vert] = new Vector2(0.5f, 0.5f);
            var bottomCenterIndex = vert;
            vert++;

            // Top circle
            for (var i = 0; i < sides; i++)
            {
                var angle = Mathf.Deg2Rad * i * angleStep;
                vertices[vert] = new Vector3(Mathf.Cos(angle) * radius, height, Mathf.Sin(angle) * radius);
                normals[vert] = Vector3.up; // нормали направлены вверх
                uvs[vert] = new Vector2(vertices[vert].x / (2 * radius) + 0.5f, vertices[vert].z / (2 * radius) + 0.5f);
                vert++;
            }

            vertices[vert] = new Vector3(0, height, 0); // центр верхнего круга
            normals[vert] = Vector3.up; // нормали направлены вверх
            uvs[vert] = new Vector2(0.5f, 0.5f);
            var topCenterIndex = vert;
            vert++;

            // Bottom triangles
            for (var i = 0; i < sides; i++)
            {
                var next = (i + 1) % sides;
                triangles[tri++] = bottomCenterIndex;
                triangles[tri++] = i;
                triangles[tri++] = next;
            }

            // Top triangles
            for (var i = 0; i < sides; i++)
            {
                var next = (i + 1) % sides;
                triangles[tri++] = topCenterIndex;
                triangles[tri++] = next + sides + 1;
                triangles[tri++] = i + sides + 1;
            }

            // Side triangles and normals
            for (var i = 0; i < sides; i++)
            {
                var next = (i + 1) % sides;
                var current = i;
                var currentTop = i + sides + 1;
                var nextTop = next + sides + 1;

                // Side triangles
                triangles[tri++] = current;
                triangles[tri++] = nextTop;
                triangles[tri++] = next;

                triangles[tri++] = current;
                triangles[tri++] = currentTop;
                triangles[tri++] = nextTop;

                // Normals for the side
                var sideNormal = Vector3
                    .Cross(vertices[next] - vertices[current], vertices[nextTop] - vertices[current]).normalized;
                normals[current] = sideNormal;
                normals[next] = sideNormal;
                normals[currentTop] = sideNormal;
                normals[nextTop] = sideNormal;
            }

            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.normals = normals;
            mesh.uv = uvs;

            mesh.RecalculateBounds();
            mesh.RecalculateNormals();

            return mesh;
        }
    }
}