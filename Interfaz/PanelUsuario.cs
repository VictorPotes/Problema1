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

namespace Interfaz
{
    public partial class PanelUsuario : Form
    {
        private InterfazParqueadero principal;
        public PanelUsuario(InterfazParqueadero prin)
        {
            InitializeComponent();

            principal = prin;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cedula;
            string nombre;
            string telefono;
            string color;
            string modelo;
            if (!textBox1.Text.Equals(""))
            {
                cedula = textBox1.Text;
                Usuario u = principal.buscarUsuario(cedula);
               
                if (!textBox2.Text.Equals(""))
                {
                    nombre = textBox2.Text;
                    if (!textBox3.Text.Equals(""))
                    {
                        telefono = textBox3.Text;


                            if (!textBox5.Text.Equals(""))
                            {
                                color = textBox6.Text;

                                if (!textBox6.Text.Equals(""))
                                {
                                    modelo = textBox6.Text;
                                if (u == null)
                                {
                                    
                                    u = principal.agregarUsuario(nombre, cedula, telefono);
                                    int tipoc = principal.darTipoVehiculo();
                                    MessageBox.Show("Se agregó el vehiculo al usuario con cédula: " + cedula);
                                    Vehiculo m=u.agregarVehiculo(principal.darPlaca(), tipoc);
                                    principal.agregarIngreso(m);
                                    principal.limpiar();
                                    this.Visible = false;
                                }
                                else
                                {
                                    int tipoc = principal.darTipoVehiculo();
                                    Vehiculo m = u.agregarVehiculo(principal.darPlaca(), tipoc);
                                    principal.agregarIngreso(m);
                                    MessageBox.Show("Se agregó el vehiculo al usuario con cédula: " + cedula);
                                    principal.limpiar();
                                    this.Visible = false;
                                }
                            }
                                else
                                {
                                    MessageBox.Show("Ingrese un modelo válido");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Ingrese un color válido");
                            }
                        
                    }
                    else
                    {
                        MessageBox.Show("Ingrese un teléfono válida");
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese una nombre válido");
                }
                
                
            }
            else
            {
                MessageBox.Show("Ingrese una cédula válida");
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(""))
            {
                string cedula = "";
                cedula = textBox1.Text;
                Usuario u = principal.buscarUsuario(cedula);
                if (u != null)
                {
                    Frecuente f = (mundo.Frecuente)u;
                    textBox2.Text = f.darNombre();
                    textBox2.Enabled = false;
                    textBox3.Text = f.darTelefono();
                    textBox3.Enabled = false;
                    textBox1.Enabled = false;
                }
                else
                {
                    textBox2.Enabled = true;
                    textBox3.Enabled = true;
                    textBox1.Enabled = false;

                }
            }
        }
    }
}
