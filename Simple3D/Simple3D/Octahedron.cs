using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple3D
{
    /// <summary>
    /// Октаэдр.
    /// </summary>
    class Octahedron : Abstract3DInstance
    {
        /// <summary>
        /// Создаем октаэдр в центре с началом координат и ребром равным 1.
        /// </summary>
        public Octahedron()
        {
            double s = Math.Sqrt(2) / 2;

            _points.Add(new Point3D(s, 0, 0));
            _points.Add(new Point3D(0, s, 0));
            _points.Add(new Point3D(-s, 0, 0));
            _points.Add(new Point3D(0, -s, 0));

            _points.Add(new Point3D(0, 0, s));
            _points.Add(new Point3D(0, 0, -s));

            Name = "Октаэдр";
        }

        public override IEnumerable<Edge> Render()
        {
            List<Edge> edges = new List<Edge>
            {
                new Edge(_points[0], _points[1]),
                new Edge(_points[1], _points[2]),
                new Edge(_points[2], _points[3]),
                new Edge(_points[3], _points[0]),

                new Edge(_points[4], _points[0]),
                new Edge(_points[4], _points[1]),
                new Edge(_points[4], _points[2]),
                new Edge(_points[4], _points[3]),

                new Edge(_points[5], _points[0]),
                new Edge(_points[5], _points[1]),
                new Edge(_points[5], _points[2]),
                new Edge(_points[5], _points[3])
            };

            Plane plane1, plane2;

            for (int i = 0; i < 4; i++)
            {
                plane1 = new Plane(_points[(i + 1) % 4], _points[i], _points[4]);
                plane2 = new Plane(_points[i], _points[(i + 1) % 4], _points[5]);
                edges[i].Visible = DetectVisibility(plane1.Z) || DetectVisibility(plane2.Z);

                plane1 = new Plane(_points[i], _points[4], _points[(i + 1) % 4]);
                plane2 = new Plane(_points[4], _points[i], _points[(i + 3) % 4]);
                edges[i + 4].Visible = DetectVisibility(plane1.Z) || DetectVisibility(plane2.Z);

                plane1 = new Plane(_points[5], _points[i], _points[(i + 1) % 4]);
                plane2 = new Plane(_points[i], _points[5], _points[(i + 3) % 4]);
                edges[i + 8].Visible = DetectVisibility(plane1.Z) || DetectVisibility(plane2.Z);
            }

            return edges;
        }
    }
}
