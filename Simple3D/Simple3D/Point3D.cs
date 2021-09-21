using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple3D
{
    /// <summary>
    /// Класс точки заданной в 3-х мерном пространтсве.
    /// </summary>
    class Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
         
        /// <summary>
        /// Конвертация в PointF для удобства отрисовки.
        /// </summary>
        /// <returns>PointF объект.</returns>
        public PointF ToPointF()
        {
            return new PointF(Convert.ToSingle(X), Convert.ToSingle(Y));
        }
    }
}
