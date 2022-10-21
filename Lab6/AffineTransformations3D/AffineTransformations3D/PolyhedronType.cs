using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffineTransformations3D
{
    using static RegularPolyhedrons;

    public enum PolyhedronType
    {
        Tetrahedron, Oktahedron, Geksahedron, 
        Ikosahedron, Dodahedron  // * – необязательная реализация за бонусные баллы
    }

    public static class PolyhedronTypeExtensionMethods
    {
        public static string GetPolyhedronName(this PolyhedronType polyhedronType)
        {
            switch (polyhedronType)
            {
                case PolyhedronType.Tetrahedron:
                    return "Тетраэдр";
                case PolyhedronType.Geksahedron:
                    return "Гексаэдр";
                case PolyhedronType.Oktahedron:
                    return "Октаэдр";
                case PolyhedronType.Ikosahedron:
                    return "Икосаэдр*";
                case PolyhedronType.Dodahedron:
                    return "Додекаэдр*";
                default:
                    throw new ArgumentException("Unknown polyhedron type");
            }
        }

        public static Polyhedron CreatePolyhedron(this PolyhedronType polyhedronType)
        {
            switch (polyhedronType)
            {
                case PolyhedronType.Tetrahedron:
                    return MakeTetrahedron();
                case PolyhedronType.Geksahedron:
                    return MakeGeksahedron();
                case PolyhedronType.Oktahedron:
                    return MakeOktahedron();
                case PolyhedronType.Ikosahedron:
                    return MakeIkosahedron();
                case PolyhedronType.Dodahedron:
                    return MakeDodahedron();
                default:
                    throw new ArgumentException("Unknown polyhedron type");
            }
        }
    }
}
