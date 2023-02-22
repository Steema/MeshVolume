﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeshVolume
{
    public class Point3
    {
        public float X;
        public float Y;
        public float Z;
        public float W;
        public Point3()
        {
        }
        public Point3(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        // Apply a transformation to a point:
        public void Transform(Matrix3 m)
        {
            float[] result = m.VectorMultiply(
            new float[4] { X, Y, Z, W });
            X = result[0];
            Y = result[1];
            Z = result[2];
            W = result[3];
        }
    }
}
