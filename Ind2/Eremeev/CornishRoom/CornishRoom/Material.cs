using System.Drawing;

namespace CornishRoom
{
public class Material
{
    public Color Diffuse {
        get;
    }
    public double Specular {
        get;
    }
    public double Reflection {
        get;
    }
    public double Refraction {
        get;
    }

    public Material(Color diffuse, double specular, double reflective, double refraction)
    {
        Diffuse = diffuse;
        Specular = specular;
        Reflection = reflective;
        Refraction = refraction;
    }
}
}
