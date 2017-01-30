using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mundo
{
    [Serializable]
    public class Vehiculo
    {
        //----------------------------------- ATRIBUTOS -------------------------------//

        /// <summary>
        /// Cadena de caracteres única que le pertenece al vehículo
        /// </summary>
        /// 
        private String placa;

        /// <summary>
        /// Modelo del vehículo
        /// </summary>
        private String modelo;

        /// <summary>
        /// Color del vehículo
        /// </summary>
        private String color;

        /// <summary>
        /// El tipo del vehículo puede ser una moto o un carro
        /// </summary>
        private int tipo;

        /// <summary>
        /// Los ingresos son el registro de entradas y salidas que ha tenido el vehículo en la Universidad Icesi
        /// </summary>
        private ArrayList ingresos;
        //----------------------------------- CONSTANTES -------------------------------//

        /// <summary>
        /// Constante que determina que el vehículo del usuario es una moto
        /// </summary>
        public static readonly int MOTO = 1;
        /// <summary>
        /// Constante que determina que el vehículo del usuario es un carro
        /// </summary>
        public static readonly int CARRO = 2;

        /// <summary>
        /// Constructor que se encarga de dar los valores a los atributos
        /// </summary>
        /// <param name="placa">Es la placa correspondiente al vehículo</param>
        /// <param name="modelo">Es el modelo corresponiente al vehículo</param>
        /// <param name="color">Es el color correspondiente al vehículo</param>
        /// <param name="tipo">Solamente pueden ser dos: 1 si es moto y 2 si es carro</param>
        /// <param name="tipoDueno">puede ser un Usuario o un Usuario frecuente</param>
        public Vehiculo(string p, string model, string col, int t)
        {
            ingresos = new ArrayList();
            placa = p;
            modelo = model;
            color = col;
            tipo = t;


        }

        //------------------------------ MÉTODOS DAR Y CAMBIAR --------------------------//


        /// <summary>
        /// Retorna la placa del vehículo
        /// </summary>
        /// <returns></returns>

        public string darPlaca()
        {
            return placa;
        }

        /// <summary>
        /// Retorna el tipo de vehiculo que tiene el usuario, puede ser carro o moto
        /// </summary>
        /// <returns></returns>
        public string darTipo()
        {
            if (tipo == MOTO)
            {
                return "Moto";
            }
            else
            {
                return "Carro";
            }
        }


        public Ingreso agregarIngreso(string fi, string hi, string fs, string hs)
        {
            Ingreso i = new Ingreso(fi, hi, fs, hs);
            ingresos.Add(i);
            return i;
        }


        public ArrayList darIngresos()
        {
            return ingresos;
        }
    }
}
