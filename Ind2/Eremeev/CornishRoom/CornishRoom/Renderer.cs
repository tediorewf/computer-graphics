using System;
using System.Collections.Generic;
using System.Drawing;

namespace CornishRoom
{
// https://habr.com/ru/post/342510/
using static ColorMethods;

public class Renderer
{
    private Vector3D origin;
    private Size imageSize;
    private List<Primitive> primitives;
    private List<Light> lights;
    private Color backgroundColor;
    private int recursionDepth;

    public Renderer(Vector3D origin, Size imageSize, List<Primitive> primitives, List<Light> lights, Color backgroundColor, int recursionDepth = 5)
    {
        this.origin = origin;
        this.imageSize = imageSize;
        this.primitives = primitives;
        this.lights = lights;
        this.backgroundColor = backgroundColor;
        this.recursionDepth = recursionDepth;
    }

    public Bitmap Render()
    {
        var drawingSurface = new Bitmap(imageSize.Width, imageSize.Height);
        using (var fastDrawingSurface = new FastBitmap(drawingSurface))
        {
            for (int x = -imageSize.Width / 2; x < imageSize.Width / 2; x += 1)
            {
                for (int y = -imageSize.Height / 2 + 1; y < imageSize.Height / 2; y += 1)
                {
                    var direction = CanvasToViewport(x, y);
                    var color = TraceRay(origin, direction, 0.001, double.MaxValue, recursionDepth);
                    int xN = imageSize.Width / 2 + x;
                    int yN = imageSize.Height / 2 - y;
                    fastDrawingSurface[xN, yN] = color;
                }
            }
        }
        return drawingSurface;
    }

    private Color TraceRay(Vector3D origin, Vector3D direction, double tMin, double tMax, int recursionDepth)
    {
        var closestIntersection = FindClosestIntersection(origin, direction, tMin, tMax);

        if (closestIntersection.Item2 != null)
        {
            var intersection = origin + direction * closestIntersection.Item1;
            var normal = closestIntersection.Item2.ComputeNormal(intersection);

            double lightning = ComputeLighting(intersection, normal, -direction, closestIntersection.Item2.Material.Specular);
            var color = Multiply(closestIntersection.Item2.Material.Diffuse, lightning);

            if (recursionDepth <= 0)
            {
                return color;
            }

            var reflected = ReflectRay(-direction, normal);

            var reflectedColor = TraceRay(intersection, reflected, tMin, tMax, recursionDepth - 1);
            var refractedColor = TraceRay(intersection, direction, 0.001, double.MaxValue, 1);

            return Add(Add(Multiply(color, 1 - closestIntersection.Item2.Material.Reflection), Multiply(reflectedColor, closestIntersection.Item2.Material.Reflection)), Multiply(refractedColor, closestIntersection.Item2.Material.Refraction));
        }

        return backgroundColor;
    }

    private Vector3D ReflectRay(Vector3D r, Vector3D n)
    => 2.0 * n * n.ComputeDotProduct(r) - r;

    private double ComputeLighting(Vector3D point, Vector3D normal, Vector3D direction, double specular)
    {
        double intensivity = 0.0;
        foreach (var light in lights)
        {
            var lightDirection = light.Position - point;

            var p = FindClosestIntersection(point, lightDirection, tMax: 1.0);
            if (p.Item2 != null)
            {
                continue;
            }

            var diffuseLight = normal.ComputeDotProduct(lightDirection);
            intensivity += light.Intensivity * diffuseLight / (normal.ComputeLength() * lightDirection.ComputeLength());

            var reflectedLightDirection = ReflectRay(lightDirection, normal);
            var reflectedLight = reflectedLightDirection.ComputeDotProduct(direction);
            intensivity += light.Intensivity * Math.Pow(reflectedLight / (reflectedLightDirection.ComputeLength() * direction.ComputeLength()), specular);
        }
        return intensivity;
    }

    private Tuple<double, Primitive> FindClosestIntersection(Vector3D origin, Vector3D direction, double tMin = 0.001, double tMax = double.MaxValue)
    {
        double closestDistance = double.MaxValue;
        Primitive closestPrimitive = null;

        foreach (var primitive in primitives)
        {
            var intersection = primitive.Intersect(origin, direction);

            if (intersection.Item1 >= tMin && intersection.Item1 <= tMax && intersection.Item1 < closestDistance)
            {
                closestDistance = intersection.Item1;
                closestPrimitive = primitive;
            }

            if (intersection.Item2 >= tMin && intersection.Item2 <= tMax && intersection.Item2 < closestDistance)
            {
                closestDistance = intersection.Item2;
                closestPrimitive = primitive;
            }
        }

        return Tuple.Create(closestDistance, closestPrimitive);
    }

    private Vector3D CanvasToViewport(double x, double y)
    => new Vector3D(x / imageSize.Width, y / imageSize.Height, 1);
}
}
