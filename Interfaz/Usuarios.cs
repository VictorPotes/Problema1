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
    public partial class Usuarios : Form
    {
        InterfazParqueadero principal;
        public Usuarios(InterfazParqueadero prin)
        {
            InitializeComponent();
            principal = prin;
            textBox2.ScrollBars = ScrollBars.Vertical;
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Equals(""))
            {
                textBox2.Text = "Ingrese una cédula válida";
            }
            else
            {
                Usuario usu = principal.buscarUsuario(textBox1.Text);
                if (usu == null)
                {
                    textBox2.Text = "No hay ingresos asociados a ese usuario";
                }
                else { 
                ArrayList veh = usu.darVehiculos();
                for (int j = 0; j < veh.Count; j++)
                {
                    Vehiculo ve = (mundo.Vehiculo)veh[j];
                    ArrayList ingresos = ve.darIngresos();
                    for (int t = 0; t < ingresos.Count; t++)
                    {
                        Ingreso actual = (mundo.Ingreso)ingresos[t];
                        if (usu is Frecuente)
                        {
                            Frecuente a = (mundo.Frecuente)usu;
                            textBox2.Text = string.Concat(textBox2.Text, "Usuario con cédula ", a.darCedula(), " con el vehiculo de placas ", ve.darPlaca(), " en su ingreso : Fecha de entrada ", actual.darFechaDeIngreso(), ", Hora de entrada ", actual.darHoraDeIngreso(), ", Fecha de salida ", actual.darFechaDeSalida(), ", Hora de salida ", actual.darHoraDeSalida(), "\r\n","\r\n");


                        }
                        else
                        {
                            textBox2.Text = string.Concat(textBox2.Text, "Usuario invitado", " con el vehiculo de placas ", ve.darPlaca(), " en su ingreso ", t, ": Fecha de entrada ", actual.darFechaDeIngreso(), ", Hora de entrada ", actual.darHoraDeIngreso(), ", Fecha de salida ", actual.darFechaDeSalida(), ", Hora de salida ", actual.darHoraDeSalida(), "\r\n", "\r\n");

                        }

                    }
                }
            }
        }

        }
    }
}
