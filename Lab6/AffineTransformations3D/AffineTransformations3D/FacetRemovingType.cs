using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffineTransformations3D
{
    public enum FacetRemovingType
    {
        None, ZBuffer, ZBufferWithTexturing, BackfaceCulling
    }

    public static class FacetRemovingTypeExtensions
    {
        public static string GetFacetRemovingName(this FacetRemovingType facetRemovingType)
        {
            switch (facetRemovingType)
            {
                case FacetRemovingType.None:
                    return "Без отсечения (рисование ребер)";
                case FacetRemovingType.ZBuffer:
                    return "Z-буфер";
                case FacetRemovingType.ZBufferWithTexturing:
                    return "Z-буфер с текстурированием";
                case FacetRemovingType.BackfaceCulling:
                    return "Отчесение по нормалям поверхностей";
                default:
                    throw new ArgumentException("Неизвестный тип отсечения граней");
            }
        }
    }
}
