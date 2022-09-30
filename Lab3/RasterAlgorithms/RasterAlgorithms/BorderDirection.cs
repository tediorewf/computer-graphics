using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RasterAlgorithms
{
    public enum BorderDirection
    {
        right = 0, up = 2, left = 4, down = 6,
        upRight = 1, upLeft = 3, downRight = 7, downLeft = 5
    }

    public static class BorderDirectionMethods
    {
        public static BorderDirection Move90DegreesClockwise(this BorderDirection borderDirection)
        {
            int nextDirection = ((int)borderDirection - 2 + 8) % 8;
            return (BorderDirection)nextDirection;
        }

        public static BorderDirection MoveNext(this BorderDirection borderDirection)
        {
            int nextDirection = ((int)borderDirection + 1) % 8;
            return (BorderDirection)nextDirection;
        }

        public static Point MovePoint(this BorderDirection borderDirection, Point p)
        {
            int movedX = p.X, movedY = p.Y;
            switch (borderDirection)
            {
                case BorderDirection.right:
                    movedX += 1;
                    break;
                case BorderDirection.upRight:
                    movedX += 1;
                    movedY -= 1;
                    break;
                case BorderDirection.up:
                    movedY -= 1;
                    break;
                case BorderDirection.upLeft:
                    movedX -= 1;
                    movedY -= 1;
                    break;
                case BorderDirection.left:
                    movedX -= 1;
                    break;
                case BorderDirection.downLeft:
                    movedX -= 1;
                    movedY += 1;
                    break;
                case BorderDirection.down:
                    movedY += 1;
                    break;
                case BorderDirection.downRight:
                    movedX += 1;
                    movedY += 1;
                    break;
            }
            return new Point(movedX, movedY);
        }
    }
}
