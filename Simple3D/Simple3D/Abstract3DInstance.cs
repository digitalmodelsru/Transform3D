using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple3D
{    
    /// <summary>
    /// Абстрактный класс для 3D объекта.
    /// </summary>
    abstract class Abstract3DInstance
    {
        protected List<Point3D> _points= new List<Point3D>();

        /// <summary>
        /// Метод необходим для определения видимости грани.
        /// </summary>
        /// <param name="z">Z координта векторного произведния.</param>
        /// <returns>Видимость грани.</returns>
        protected bool DetectVisibility(double z)
        {
            return z >= 0;
        }

        /// <summary>
        /// Свойство возвращает список точек.
        /// </summary>
        public List<Point3D> Points => _points;

        /// <summary>
        /// Метод возвращает список ребер для отрисовки.
        /// </summary>
        /// <returns>Коллекция ребер.</returns>
        public abstract IEnumerable<Edge> Render();

        /// <summary>
        /// Метод возвращает список ребер для отрисовки с учетом перспективных преобразований.
        /// </summary>
        /// <param name="ipt">Класс который выполняет перспектиные преобразования.</param>
        /// <param name="center">Точка перспективы.</param>
        /// <returns>Коллекция ребер.</returns>
        public IEnumerable<Edge> Render(IPerspectiveTransform ipt, Point3D center)
        {
            List<Point3D> savedPoints = new List<Point3D>(_points);
            _points = _points.Select(x => ipt.Transform(x, center)).ToList();
            IEnumerable<Edge> edges = Render();
            _points = savedPoints;

            return edges;
        }

        /// <summary>
        /// Имя объекта.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        public override string ToString()
        {
            return Name;
        }
    }
}
