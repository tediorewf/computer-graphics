﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CornishRoom
{
    public abstract class Primitive
    {
        public abstract bool Intersect(Ray ray);

        public abstract Vector3D ComputeNormal(Point3D point);
    }
}
