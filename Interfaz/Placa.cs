using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mundo;
using System.Collections;

namespace Interfaz
{
    public partial class Placa : Form
    {
        InterfazParqueadero principal;
        public Placa(InterfazParqueadero prin)
        {
            InitializeComponent();
            principal = prin;
            textBox1.ScrollBars = ScrollBars.Vertical;
        }

        private void Placa_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!textBox1.Equals(""))
            {
                Vehiculo ve = principal.buscarVehiculo(textBox1.Text);
                if (ve == null)
                {
                    textBox2.Text = "No hay ingresos asociados a ese vehículo";
                }
                else
                {
                    ArrayList ingresos = ve.darIngresos();
                    for (int i = 0; i < ingresos.Count; i++)
                    {
                        Ingreso actual = (mundo.Ingreso)ingresos[i];
                        textBox2.Text= string.Concat(textBox2.Text,"Ingresó en" ,": Fecha de entrada ", actual.darFechaDeIngreso(), ", Hora de entrada ", actual.darHoraDeIngreso(), ", Fecha de salida ", actual.darFechaDeSalida(),  ", Hora de salida ", actual.darHoraDeSalida(), "\r\n", "\r\n");
                    }
                   
                }

            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
