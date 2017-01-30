using mundo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class Todos : Form
    {
        InterfazParqueadero principal;

        public Todos(InterfazParqueadero prin)
        {
            InitializeComponent();
            principal = prin;
            textBox2.ScrollBars = ScrollBars.Vertical;
            ArrayList usuarios = principal.darUsuarios();
            if (usuarios == null || usuarios.Count == 0)
            {
                textBox2.Text= "No hay ingresos asociados a ese vehículo";
            }
            else
            {
                for (int i = 0; i < usuarios.Count; i++)
                {
                    Usuario usu = (mundo.Usuario)usuarios[i];
                    ArrayList veh = usu.darVehiculos();
                    for (int j = 0; j < veh.Count; j++)
                    {
                        Vehiculo ve =(mundo.Vehiculo) veh[j];
                        ArrayList ingresos = ve.darIngresos();
                        for (int t = 0; t < ingresos.Count; t++)
                        {
                            Ingreso actual = (mundo.Ingreso)ingresos[t];
                            if(usu is Frecuente)
                            {
                                Frecuente a = (mundo.Frecuente)usu;
                                textBox2.Text = string.Concat(textBox2.Text, "Usuario con cédula ",a.darCedula(), " con el vehiculo de placas ", ve.darPlaca(), " en su ingreso en",  ": Fecha de entrada ", actual.darFechaDeIngreso(), ", Hora de entrada ", actual.darHoraDeIngreso(), ", Fecha de salida ", actual.darFechaDeSalida(), ", Hora de salida ", actual.darHoraDeSalida(), "\r\n", "\r\n");


                            }
                            else
                            {
                                textBox2.Text = string.Concat(textBox2.Text, "Usuario invitado ",i, " con el vehiculo de placas ", ve.darPlaca(), " ingresó en", ": Fecha de entrada ", actual.darFechaDeIngreso(), ", Hora de entrada ", actual.darHoraDeIngreso(), ", Fecha de salida ", actual.darFechaDeSalida(), ", Hora de salida ", actual.darHoraDeSalida(), "\r\n", "\r\n");

                            }

                        }
                    }
                    }

            }
            
        
        }
    }
}
