using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CornishRoom
{
    public class Cube : Primitive
    {
        private double epsilon;

        public Vector3D[] Vectices { get; }

        public Cube(Vector3D[] vertices, Material material, double epsilon = 0.001) 
            : base(material)
        {
            this.epsilon = epsilon;
            Vectices = vertices;
        }

        public override Tuple<double, double> Intersect(Vector3D origin, Vector3D direction)
        {
            return Tuple.Create(double.MaxValue, double.MaxValue);
        }

        public override Vector3D ComputeNormal(Vector3D point)
        {
            throw new NotImplementedException();
        }
    }
}
