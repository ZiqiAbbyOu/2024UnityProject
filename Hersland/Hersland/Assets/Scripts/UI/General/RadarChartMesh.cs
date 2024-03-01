using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HL.Characters;


namespace HL.UI
{
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    public class RadarChartMesh : MonoBehaviour
    {
        public float[] characterWuXingCapData = new float[5];
        public WuXing characterWuXing;
        public Transform displayChartTransform;

        private void Start()
        {
            
            //characterWuXing = GameObject.Find("Player").GetComponent<WuXing>();
            //characterWuXingCapData = characterWuXing.GetWuXingArray();
            //GenerateRadarMesh(characterWuXingCapData, 100);

        }

        private void Update()
        {
            //GenerateRadarMesh(characterWuXingCapData, 100);
        }

        public void GenerateRadarMesh(float[] data, int dataScale)
        {
            Mesh mesh = new Mesh();
            Vector3[] vertices = new Vector3[data.Length + 1];
            vertices[0] = Vector3.zero;

            float scale = displayChartTransform.localScale.x/(dataScale * 1.1f);
            float angleIncrement = 360.0f / data.Length * Mathf.Deg2Rad;
            float angleOffset = Mathf.Deg2Rad * 90f;

            for (int i = 0; i < data.Length; i++)
            {
                float angle = i * angleIncrement + angleOffset;
                vertices[i + 1] = new Vector3(
                    Mathf.Cos(angle) * data[i] * scale,
                    Mathf.Sin(angle) * data[i] * scale,
                    0);
            }

            int[] triangles = new int[data.Length * 3];
            for (int i = 0; i < data.Length; i++)
            {
                int vertexInt = i + 1;
                int nextVertexInt = i + 2;
                if (i == data.Length - 1)
                {
                    nextVertexInt = 1;
                }

                triangles[i * 3] = 0;
                triangles[i * 3 + 1] = vertexInt;
                triangles[i * 3 + 2] = nextVertexInt;
            }

            mesh.vertices = vertices;
            mesh.triangles = triangles;
            GetComponent<MeshFilter>().mesh = mesh;
            mesh.RecalculateNormals();

        }

    }
}