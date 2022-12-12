using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CornishRoom
{
public class Ray
{
    public Point3D Origin {
        get;
        set;
    }
    public Point3D End {
        get;
        set;
    }

    public Ray(Point3D origin, Point3D direction)
    {
        Origin = origin;
        End = direction;
    }
}
}
