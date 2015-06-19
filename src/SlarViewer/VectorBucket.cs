using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlarViewer
{
    class VectorBucket
    {
        public List<Vector> Vectors { get; set; }

        public VectorBucket()
        {
            Vectors = new List<Vector>();
        }

        public void Add(Vector vector)
        {
            Vectors.Add(vector);
        }

        public Vector Average()
        {
            float sumX = 0.0f;
            float sumY = 0.0f;

            foreach( Vector vector in Vectors)
            {
                sumX += vector.X;
                sumY += vector.Y;
            }

            return new Vector(sumX / Vectors.Count, sumY / Vectors.Count);
        }

        public void Clear()
        {
            Vectors.Clear();
        }
    }
}
