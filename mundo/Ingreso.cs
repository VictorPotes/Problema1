using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mundo
{
    [Serializable]
    public class Ingreso
    {
        string fechaDeIngreso;
        string horaDeIngreso;
        string fechaDeSalida;
        string horaDeSalida;
        public Ingreso(string fi, string hi, string fs, string hs)
        {
            fechaDeIngreso = fi.Substring(0, 10);
            fechaDeSalida = fs.Substring(0, 10);
            horaDeIngreso = hi;
            horaDeSalida = hs;
        }
        public string darFechaDeIngreso()
        {
            return fechaDeIngreso;
        }
        public string darFechaDeSalida()
        {
            return fechaDeSalida;
        }
        public string darHoraDeIngreso()
        {
            return horaDeIngreso;
        }
        public string darHoraDeSalida()
        {
            return horaDeSalida;
        }

    }
}
