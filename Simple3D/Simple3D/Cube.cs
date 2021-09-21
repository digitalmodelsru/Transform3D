using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple3D
{
    /// <summary>
    /// Куб.
    /// </summary>
    class Cube : Abstract3DInstance
    {
        /// <summary>
        /// создаем куб с ребром равным 1 с центром в начале координат.
        /// </summary>
        public Cube()
        {
            double s = Math.Sqrt(2) / 2;

            _points.Add(new Point3D(0, s, 0.5));
            _points.Add(new Point3D(s, 0, 0.5));
            _points.Add(new Point3D(0, -s, 0.5));
            _points.Add(new Point3D(-s, 0, 0.5));

            _points.Add(new Point3D(0, s, -0.5));
            _points.Add(new Point3D(s, 0, -0.5));
            _points.Add(new Point3D(0, -s, -0.5));
            _points.Add(new Point3D(-s, 0, -0.5));

            Name = "Куб";
        }
        
        public override IEnumerable<Edge> Render()
        {
            List<Edge> edges = new List<Edge>
            {
                new Edge(_points[0], _points[1]),
                new Edge(_points[1], _points[2]),
                new Edge(_points[2], _points[3]),
                new Edge(_points[3], _points[0]),

                new Edge(_points[4], _points[5]),
                new Edge(_points[5], _points[6]),
                new Edge(_points[6], _points[7]),
                new Edge(_points[7], _points[4]),

                new Edge(_points[0], _points[4]),
                new Edge(_points[1], _points[5]),
                new Edge(_points[2], _points[6]),
                new Edge(_points[3], _points[7])
            };

            Plane plane1, plane2;

            for (int i = 0; i < 4; i++)
            {
                plane1 = new Plane(_points[i], _points[(i + 1) % 4], _points[(i + 2) % 4]);
                plane2 = new Plane(_points[(i + 1) % 4], _points[i], _points[(i + 5) % 4 + 4]);
                edges[i].Visible = DetectVisibility(plane1.Z) || DetectVisibility(plane2.Z);

                plane1 = new Plane(_points[(i + 5) % 4 + 4], _points[(i + 4) % 4 + 4], _points[(i + 6) % 4 + 4]);
                plane2 = new Plane(_points[(i + 4) % 4 + 4], _points[(i + 5) % 4 + 4], _points[i]);
                edges[i + 4].Visible = DetectVisibility(plane1.Z) || DetectVisibility(plane2.Z);

                plane1 = new Plane(_points[i], _points[i + 4], _points[(i + 5) % 8]);
                plane2 = new Plane(_points[i + 4], _points[i], _points[(i + 7) % 8]);
                edges[i + 8].Visible = DetectVisibility(plane1.Z) || DetectVisibility(plane2.Z);
            }

            return edges;
        }        
    }
}
