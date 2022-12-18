using System;

namespace CornishRoom
{
    public class Plane : Primitive
    {
        private double epsilon;

        public Vector3D Position { get; }
        public Vector3D Normal { get; }

        public Plane(Vector3D position, Vector3D normal, Material material, double epsilon = 0.001) 
            : base(material)
        {
            this.epsilon = epsilon;

            Position = position;
            Normal = normal;
        }

        // https://www.delftstack.com/howto/cpp/intersection-of-ray-and-plane-in-cpp/
        public override Tuple<double, double> Intersect(Vector3D origin, Vector3D direction)
        {
            double denom = Normal.ComputeDotProduct(direction);
            if (Math.Abs(denom) < epsilon)
            {
                return Tuple.Create(double.MaxValue, double.MaxValue);
            }

            var ab = Position - origin;
            double t = ab.ComputeDotProduct(Normal) / denom;
            if (Math.Abs(t) >= epsilon)
            {
                return Tuple.Create(t, t);
            }

            return Tuple.Create(double.MaxValue, double.MaxValue);
        }

        public override Vector3D ComputeNormal(Vector3D point) => Normal;
    }
}
