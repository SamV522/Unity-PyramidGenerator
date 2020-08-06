using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Quaternion = UnityEngine.Quaternion;
using System;

namespace ZombieRTS
{
    public static class PyramidGenerator
    {
        public static Mesh GetMesh(Vector3 origin, Vector3 a,Vector3 d, Quaternion rotation)
        {
            Mesh mesh = new Mesh();
            mesh.Clear();
            mesh.vertices = GenerateVertices(origin, a, d, rotation);
            mesh.triangles = GetTris();
            return mesh;
        }

        public static Vector3[] GenerateVertices(Vector3 origin, Vector3 a, Vector3 d, Quaternion rotation)
        {
            Vector3[] retVerts = new Vector3[5];
            Vector3 tL = a;
            Vector3 bR = d;

            Vector3 cc = Vector3.Lerp(a, d, 0.5f);

            Vector3 tR = new Vector3(0, tL.y,0);
            Vector3 bL = new Vector3(0, bR.y, 0);
            //Debug.Log(rotation.eulerAngles.y);

            double aN = rotation.eulerAngles.y;
            Vector3 tLNoRot = new Vector3(tL.x * (float) Math.Cos(aN) + tL.z * (float) Math.Sin(aN), tL.y, -tL.x *(float) Math.Sin(aN) + tL.z * (float) Math.Cos(aN));
            Vector3 bRNoRot = new Vector3(bR.x * (float)Math.Cos(aN) + bR.z * (float)Math.Sin(aN), bR.y, -bR.x * (float)Math.Sin(aN) + bR.z * (float)Math.Cos(aN));
            tR.x = bRNoRot.x * (float)Math.Cos((double)rotation.eulerAngles.y) - tLNoRot.z* (float)Math.Sin((double)rotation.eulerAngles.y);
            tR.z = bRNoRot.x * (float)Math.Sin((double)rotation.eulerAngles.y) + tLNoRot.z * (float)Math.Cos((double)rotation.eulerAngles.y);
            bL.x = tLNoRot.x * (float)Math.Cos((double)rotation.eulerAngles.y) - bRNoRot.z * (float)Math.Sin((double)rotation.eulerAngles.y);
            bL.z = tLNoRot.x * (float)Math.Sin((double)rotation.eulerAngles.y) + bRNoRot.z * (float)Math.Cos((double)rotation.eulerAngles.y);
            var leftBottomCorner = rotation * new Vector3(bR.x, tL.y, tL.z);
            retVerts[0] = origin;
            retVerts[1] = tL;
            retVerts[2] = tR;
            retVerts[3] = bR;
            retVerts[4] = bL;

            return retVerts;
        }

        public static int[] GetTris()
        {
            return new int[] { 2, 0, 1, 3, 0, 2, 4, 0, 3, 1, 0, 4, 4, 3, 2, 2, 1, 4 };

        }
    }

}