using System;
using System.Collections.Generic;
using System.Linq;

namespace AffineTransformations3D
{
public static class ListExtensionMethods
{
    public static DeptherizedPoint FetchLeftMost(this List<DeptherizedPoint> collection)
    {
        var leftMost = collection.First();
        for (int i = 1; i < collection.Count(); i++)
        {
            if (collection[i].X < leftMost.X)
            {
                leftMost = collection[i];
            }
        }
        collection.Remove(leftMost);
        return leftMost;
    }

    public static DeptherizedPoint FetchRightMost(this List<DeptherizedPoint> collection)
    {
        var rightMost = collection.First();
        for (int i = 1; i < collection.Count(); i++)
        {
            if (collection[i].X > rightMost.X)
            {
                rightMost = collection[i];
            }
        }
        collection.Remove(rightMost);
        return rightMost;
    }

    public static Point3D CommonCenter(this List<Polyhedron> polyhedrons)
    {
        double x = 0, y = 0, z = 0;
        int count = 0;
        foreach (var pol in polyhedrons)
        {
            var p = pol.Center;
            x += p.X;
            y += p.Y;
            z += p.Z;
            count ++;
        }
        x /= count;
        y /= count;
        z /= count;
        return new Point3D(x, y, z);
    }
}
}
