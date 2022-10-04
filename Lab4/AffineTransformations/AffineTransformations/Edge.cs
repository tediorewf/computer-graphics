﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AffineTransformations
{
    public class Edge
    {
        public bool Red { get; set; }
        public Point Begin { get;  set; }
        public Point End { get;  set; }

        public Edge(Point begin, Point end)
        {
            Begin = begin;
            End = end;
        }

        public void Turn90DegreesAroundCenter()
        {
            // TODO: реализовать повор на 90 градусов вокруг центра
        }

        public Point Intersect(Edge other)
        {
            var intersectionPoint = new Point();
            // TODO: реализорвать пересечение ребер
            return intersectionPoint;
        }
    }
}