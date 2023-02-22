using Steema.TeeChart.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeshVolume
{
    public class Matrix3
    {
        public float[,] M = new float[4, 4];
        public Matrix3()
        {
            Identity3();
        }

        public Point3 Spherical(float r, float theta, float phi)
        {
            Point3 pt = new Point3();
            float snt = (float)Math.Sin(theta * Math.PI / 180);
            float cnt = (float)Math.Cos(theta * Math.PI / 180);
            float snp = (float)Math.Sin(phi * Math.PI / 180);
            float cnp = (float)Math.Cos(phi * Math.PI / 180);
            pt.X = r * snt * cnp;
            pt.Y = r * cnt;
            pt.Z = -r * snt * snp;
            pt.W = 1;
            return pt;
        }

        // Axonometric projection matrix:
        public static Matrix3 Axonometric(float alpha, float beta)
        {
            Matrix3 result = new Matrix3();
            float sna = (float)Math.Sin(alpha * Math.PI / 180);
            float cna = (float)Math.Cos(alpha * Math.PI / 180);
            float snb = (float)Math.Sin(beta * Math.PI / 180);
            float cnb = (float)Math.Cos(beta * Math.PI / 180);
            result.M[0, 0] = cnb;
            result.M[0, 2] = snb;
            result.M[1, 0] = sna * snb;
            result.M[1, 1] = cna;
            result.M[1, 2] = -sna * cnb;
            result.M[2, 2] = 0;
            return result;
        }

        public static Matrix3 Translate3(float dx, float dy, float dz)
        {
            Matrix3 result = new Matrix3();
            result.M[0, 3] = dx;
            result.M[1, 3] = dy;
            result.M[2, 3] = dz;
            return result;
        }

        public Matrix3(float m00, float m01, float m02, float m03,
float m10, float m11, float m12, float m13,
float m20, float m21, float m22, float m23,
float m30, float m31, float m32, float m33)
        {
            M[0, 0] = m00;
            M[0, 1] = m01;
            M[0, 2] = m02;
            M[0, 3] = m03;
            M[1, 0] = m10;
            M[1, 1] = m11;
            M[1, 2] = m12;
            M[1, 3] = m13;
            M[2, 0] = m20;
            M[2, 1] = m21;
            M[2, 2] = m22;
            M[2, 3] = m23;
            M[3, 0] = m30;
            M[3, 1] = m31;
            M[3, 2] = m32;
            M[3, 3] = m33;
        }
        // Define a Identity matrix:

        public void Identity3()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == j)
                    {
                        M[i, j] = 1;
                    }
                    else
                    {
                        M[i, j] = 0;
                    }
                }
            }
        }
        // Multiply two matrices together:
        public static Matrix3 operator *(Matrix3 m1, Matrix3 m2)
        {
            Matrix3 result = new Matrix3();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    float element = 0;
                    for (int k = 0; k < 4; k++)
                    {
                        element += m1.M[i, k] * m2.M[k, j];
                    }
                    result.M[i, j] = element;
                }
            }
            return result;
        }
        // Apply a transformation to a vector (point):
        public float[] VectorMultiply(float[] vector)
        {
            float[] result = new float[4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result[i] += M[i, j] * vector[j];
                }
            }
            return result;
        }
    }
}
