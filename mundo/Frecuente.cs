using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mundo
{
    [Serializable]
    public class Frecuente:Usuario
    {
        private String nombre;
        private String cedula;
        private String telefono;
        public Frecuente(String n, String c, String t)
        {
            
            nombre = n;
            cedula = c;
            telefono = t;

        }
        public String darCedula()
        {
            return cedula;
        }

        public  Vehiculo agregarVehiculo()
        {
            return null;
        }
        public string darNombre()
        {
            return nombre;
        }
        public string darTelefono()
        {
            return telefono;
        }
        public Vehiculo agregarVehiculo(string placa, string modelo, string color, int tipoVehiculo)
        {

            Vehiculo v = new Vehiculo(placa, modelo, color, tipoVehiculo);
            darVehiculos().Add(v);
            return v;
        }
    }
}
