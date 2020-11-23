using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    interface IManejoArchivos <T>
    {
        bool GuardarEnArchivo(string archivo, T datos);

    }
}
