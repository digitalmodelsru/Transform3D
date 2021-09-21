using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple3D
{
    /// <summary>
    /// Класс грани 3D объекта.
    /// </summary>
    class Plane
    {
        readonly Point3D _point1, _point2, _point3;

        public Plane(Point3D point1, Point3D point2, Point3D point3)
        {
            _point1 = point1;
            _point2 = point2;
            _point3 = point3;
        }

        /// <summary>
        /// Получение Z координаты векторного произведения. Необходимо для определения видимости грани.
        /// </summary>
        public double Z
        {
            get
            {
                Point3D vector1 = new Point3D(_point2.X - _point1.X, _point2.Y - _point1.Y, _point2.Z - _point1.Z);
                Point3D vector2 = new Point3D(_point3.X - _point2.X, _point3.Y - _point2.Y, _point3.Z - _point2.Z);

                return vector1.X * vector2.Y - vector1.Y * vector2.X;
            }
        }
    }
}
