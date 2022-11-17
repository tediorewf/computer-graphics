using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffineTransformations3D
{
    public enum FacetRemovingType
    {
        ZBuffer, BackfaceCulling, None
    }

    public static class FacetRemovingTypeExtensions
    {
        public static string GetFacetRemovingName(this FacetRemovingType facetRemovingType)
        {
            switch (facetRemovingType)
            {
                case FacetRemovingType.ZBuffer:
                    return "Z-буфер";
                case FacetRemovingType.BackfaceCulling:
                    return "Отчесение по нормалям поверхностей";
                case FacetRemovingType.None:
                    return "Без отсечения (рисование ребер)";
                default:
                    throw new ArgumentException("Неизвестный тип отсечения граней");
            }
        }
    }
}
