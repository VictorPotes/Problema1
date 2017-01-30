using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mundo
{
    [Serializable]
    public class Usuario
    {
         
        //----------------------------------- COLECCIONES -------------------------------//

        /// <summary>
        /// Vehículos que tiene el F:\System\5. Integrador\Semana 2\Proyecto1 PI1\mundo\ParqueaderoIcesi.csusuario
        /// </summary>
        private ArrayList vehiculos;

        //----------------------------------- CONSTRUCTOR -------------------------------//

        /// <summary>
        /// Constructor de la clase Usuario
        /// </summary>
        public Usuario()
        {
            vehiculos = new ArrayList();
        }

        //------------------------------------- MÉTODOS ---------------------------------//


        /// <summary>
        /// Agrega un vehículo a nombre del usuario invitado actual
        /// </summary>
        /// <param name="placa">Código único con el que se identifica el vehículo</param>
        /// <param name="tipoVehiculo">Solamente pueden ser dos: 1 si es moto y 2 si es carro</param>
        /// <returns>Retorna el vehículo que se agregó, null en caso de que no se haya agregado</returns>

        public Vehiculo agregarVehiculo(string placa, int tipoVehiculo)
        {

            Vehiculo v = new Vehiculo(placa, "", "", tipoVehiculo);
            vehiculos.Add(v);
            return v;
        }

        //-------------------------------- MÉTODOS DAR Y CAMBIAR --------------------------//

        /// <summary>
        /// Da los vehículos que tiene el usuario
        /// </summary>
        /// <returns>Arreglo de vehículos del usuario</returns>

        public ArrayList darVehiculos()
        {
            return vehiculos;
        }

        /// <summary>
        /// Busca un vehículo a través de la placa
        /// </summary>
        /// <param name="placa">Código único que identifica al vehículo</param>
        /// <returns>Retorna el vehículo buscado, null en caso de que no esté registrado</returns>

        public Vehiculo buscarVehiculo(string placa)
        {
            ArrayList veh = vehiculos;
            bool encontrado = false;
            Vehiculo vehiculo = null;
            for (int j = 0; j < veh.Count && !encontrado; j++)
            {
                Vehiculo v = (mundo.Vehiculo)veh[j];
                if (v != null)
                {
                    if (v.darPlaca().Equals(placa))
                    {
                        encontrado = true;
                        vehiculo = v;
                    }
                }
            }
            return vehiculo;
        }
        
        
            
        }

    }

