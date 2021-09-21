using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple3D
{
    /// <summary>
    /// Фабрика 3D объектов.
    /// </summary>
    class Factory3Dinstance
    {
        /// <summary>
        /// Получение 3D объекта по id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Экземпляр класса Abstract3DInstance.</returns>
        static public Abstract3DInstance GetInstance(int id)
        {
            Abstract3DInstance instance = null;

            switch (id)
            {
                case 0:
                    instance = new Cube();
                    break;
                case 1:
                    instance = new Octahedron();
                    break;
            }

            return instance;
        }
    }
}
