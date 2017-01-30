using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mundo
{
    [Serializable]
    public class ParqueaderoIcesi
    {
        //----------------------------------- ATRIBUTOS -------------------------------//

        /// <summary>
        /// Número de usuarios que el sistema ha registrado
        /// </summary>
        private int numeroUsuarios;

        /// <summary>
        /// Lista de usuarios y usuarios frecuentes que el sistema ha registrado
        /// </summary>
        private ArrayList usuarios = new ArrayList();


        //----------------------------------- CONSTRUCTOR -------------------------------//

        /// <summary>
        /// Constructor de la clase ParqueaderoIcesi
        /// </summary>

        public ParqueaderoIcesi()
        {
            usuarios = new ArrayList();
        }

        //------------------------------------- MÉTODOS ---------------------------------//

        public Usuario agregarUsuario(string cedula, string nombre, string telefono)
        {
            Usuario us = buscarUsuario(cedula);
            Usuario u = null;
            if (us == null)
            {
                u = new Frecuente(nombre, cedula, telefono);
                usuarios.Add(u);
            }
            else
            {
                u = us;
            }

            return u;
        }
        public Usuario agregarUsuario()
        {
            Usuario u = new Usuario();
            usuarios.Add(u);
            return u;

        }

        /// <summary>
        /// Busca un usuario en el sistema
        /// </summary>
        /// <param name="cedula">código único con el que se busca el usuario</param>
        /// <returns>Retorna el usuario, null en caso de que el usario no esté registrado</returns>

        public Usuario buscarUsuario(string cedula)
        {
            Boolean encontrado = false;
            Usuario us = null;
            for (int i = 0; i < usuarios.Count && !encontrado; i++)
            {
                Usuario a = (mundo.Usuario)usuarios[i];
                if (a is Frecuente)
                {
                    Frecuente b = (mundo.Frecuente)a;
                    if (b.darCedula().Equals(cedula))
                    {
                        encontrado = true;
                        us = b;
                    }
                }
            }
            return us;
        }


        /// <summary>
        /// Busca un vehículo a través de la placa
        /// </summary>
        /// <param name="placa">Código único con el que se busca el vehículo</param>
        /// <returns></returns>

        public Vehiculo buscarVehiculo(string placa)
        {
            bool encontrado = false;
            Vehiculo vehiculo = null;

            for (int i = 0; i < usuarios.Count && !encontrado; i++)
            {
                Usuario a = (mundo.Usuario)usuarios[i];
                Vehiculo v = a.buscarVehiculo(placa);
                if (v != null)
                {
                    vehiculo = v;
                    encontrado = true;
                }

            }
            return vehiculo;

        }

        public Usuario buscarUsuarioDueñoDelVeiculoPlaca(String placa)
        {
            bool encontrado = false;
            Usuario us = null;

            for (int i = 0; i < usuarios.Count && !encontrado; i++)
            {
                Usuario a = (mundo.Usuario)usuarios[i];
                Vehiculo v = a.buscarVehiculo(placa);
                if (v != null)
                {
                    us = a;
                    encontrado = true;
                }

            }
            return us;

        }
        public void agregarVehiculo(string cedula,string placa, string modelo, string color, int tipoVehiculo)
        {
            Usuario u = buscarUsuario(cedula);
            if (u != null&&u is Frecuente)
            {
                Frecuente f = (mundo.Frecuente)u;
                f.agregarVehiculo(placa,modelo,color,tipoVehiculo);
            }
        }
        public void agregarVehiculo(string cedula, string placa, int tipoVehiculo)
        {
            Usuario u = buscarUsuario(cedula);
            if (u != null && u is Frecuente)
            {
                
                u.agregarVehiculo(placa, tipoVehiculo);
            }
        }
        public ArrayList darUsuarios()
        {
            return usuarios;
        }
        
    }
}
