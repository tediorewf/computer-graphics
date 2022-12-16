using System;

namespace CornishRoom
{
    public abstract class Primitive
    {
        public Material Material { get; }

        public Primitive(Material material)
        {
            Material = material;
        }

        public abstract Tuple<double, double> Intersect(Vector3D origin, Vector3D direction);

        public abstract Vector3D ComputeNormal(Vector3D point);
    }
}
