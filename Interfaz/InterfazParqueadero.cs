using mundo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Interfaz
{
    public partial class InterfazParqueadero : Form
    {

        ParqueaderoIcesi mundo;
        PanelUsuario panelUsuario;
        public readonly string RUTA_ARCHIVO = "./dato.txt";
        public InterfazParqueadero()
        {
            InitializeComponent();
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            dateTimePicker3.Enabled = false;
            dateTimePicker4.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            if (File.Exists(RUTA_ARCHIVO))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(RUTA_ARCHIVO, FileMode.Open, FileAccess.Read, FileShare.Read);
                mundo= (ParqueaderoIcesi)formatter.Deserialize(stream);
                stream.Close();

            }
            else
            {
                mundo = new ParqueaderoIcesi();
            }
            
           

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Placa placa = new Placa(this);
            placa.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Vehiculo v = mundo.buscarVehiculo(textBox1.Text);
            if (textBox1.Text.Length==6|| textBox1.Text.Length == 5)
            {
                if (v == null)
                {
                    if (comboBox1.SelectedItem.Equals("Registrado"))
                    {
                        panelUsuario = new PanelUsuario(this);
                        panelUsuario.Visible = true;
                    }
                    else
                    {
                        string fechaIngreso = dateTimePicker1.Value.Date.ToString();
                        string horaIngreso = dateTimePicker2.Value.TimeOfDay.ToString();
                        string fechaSalida = dateTimePicker1.Value.Date.ToString();
                        string horaSalida = dateTimePicker2.Value.TimeOfDay.ToString();
                        
                        Usuario b= mundo.agregarUsuario();
                        int tipo = Vehiculo.MOTO;
                        if(comboBox2.SelectedItem.Equals("Carro")){
                            tipo = Vehiculo.CARRO;

                        }
                        Vehiculo ve= b.agregarVehiculo(textBox1.Text, tipo);
                        ve.agregarIngreso(fechaIngreso, horaIngreso, fechaSalida, horaSalida);
                        

                        MessageBox.Show("Se ha agregado el ingreso del usuario invitado");
                        textBox1.Clear();
                        textBox1.Enabled = true;
                        dateTimePicker1.ResetText();
                        dateTimePicker2.ResetText();
                        dateTimePicker3.ResetText();
                        dateTimePicker4.ResetText();
                        comboBox1.SelectedIndex = 1;
                        comboBox2.SelectedIndex = 1;
                        comboBox2.Enabled = false;
                        dateTimePicker1.Enabled=false;
                        comboBox1.Enabled = false;
                        dateTimePicker2.Enabled = false;
                        dateTimePicker3.Enabled = false;
                        dateTimePicker4.Enabled = false;

                    }
                }
                else
                {
                    string fechaIngreso = dateTimePicker1.Value.Date.ToString();
                    string horaIngreso = dateTimePicker2.Value.TimeOfDay.ToString();
                    string fechaSalida = dateTimePicker1.Value.Date.ToString();
                    string horaSalida = dateTimePicker2.Value.TimeOfDay.ToString();
                    v.agregarIngreso(fechaIngreso, horaIngreso, fechaSalida, horaSalida);
                    MessageBox.Show("Se ha agregado el ingreso del usuario invitado");
                    textBox1.Clear();
                    textBox1.Enabled = true;
                    dateTimePicker1.ResetText();
                    dateTimePicker2.ResetText();
                    dateTimePicker3.ResetText();
                    dateTimePicker4.ResetText();
                    comboBox1.SelectedIndex = 1;
                    comboBox2.SelectedIndex = 1;
                    comboBox2.Enabled = false;
                    dateTimePicker1.Enabled = false;
                    comboBox1.Enabled = false;
                    dateTimePicker2.Enabled = false;
                    dateTimePicker3.Enabled = false;
                    dateTimePicker4.Enabled = false;

                }
                
            }
            else
            {
                MessageBox.Show("Ingrese una placa válida");
            }
            
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length == 6 || textBox1.Text.Length == 5)
            {
                Vehiculo v = mundo.buscarVehiculo(textBox1.Text);
                if (v == null)
                {

                    dateTimePicker1.Enabled = true;
                    dateTimePicker2.Enabled = true;
                    dateTimePicker3.Enabled = true;
                    dateTimePicker4.Enabled = true;
                    comboBox1.Enabled = true;
                    comboBox2.Enabled = true;
                    comboBox1.SelectedIndex = 1;
                    comboBox2.SelectedItem = "Moto";
                    textBox1.Enabled = false;
                }
                else
                {
                    dateTimePicker1.Enabled = true;
                    dateTimePicker2.Enabled = true;
                    dateTimePicker3.Enabled = true;
                    dateTimePicker4.Enabled = true;
                    Usuario usu = mundo.buscarUsuarioDueñoDelVeiculoPlaca(textBox1.Text);
                    comboBox1.Enabled = true;
                    if(usu is Frecuente)
                    {
                        comboBox1.SelectedIndex = 1;
                        comboBox1.Enabled = false;
                    }
                    else
                    {
                        comboBox1.SelectedItem= "Invitado";
                        comboBox1.Enabled = false;
                    }
                    
                    comboBox2.SelectedItem = v.darTipo();
                    comboBox2.Enabled = false;
                    
                    MessageBox.Show("El vehículo ya existe, pero puede asociarle un nuevo ingreso");
                    textBox1.Enabled = false;

                }
            }
            else
            {
                MessageBox.Show("Ingrese una placa válida");
            }
        }
        public Usuario buscarUsuario(string cedul)
        {
            return mundo.buscarUsuario(cedul);
        }
       
        public Usuario agregarUsuario(string nombre, string cedula, string telefono)
        {
            return mundo.agregarUsuario(cedula, nombre, telefono);
        }
        public int darTipoVehiculo()
        {
            if (comboBox2.SelectedIndex == 0)
            {
                return Vehiculo.CARRO;
            }
            else
            {
                return Vehiculo.MOTO;
            }
        }
        public String darPlaca()
        {
            return textBox1.Text;
        }
        public void limpiar()
        {
            textBox1.Clear();
            textBox1.Enabled = true;
            dateTimePicker1.ResetText();
            dateTimePicker2.ResetText();
            dateTimePicker3.ResetText();
            dateTimePicker4.ResetText();
            comboBox1.SelectedIndex = 1;
            comboBox2.SelectedIndex = 1;
            comboBox2.Enabled = false;
            dateTimePicker1.Enabled = false;
            comboBox1.Enabled = false;
            dateTimePicker2.Enabled = false;
            dateTimePicker3.Enabled = false;
            dateTimePicker4.Enabled = false;
        }
        public Vehiculo buscarVehiculo(String placa)
        {
            return mundo.buscarVehiculo(placa);
        }
        public ArrayList darUsuarios()
        {
            return mundo.darUsuarios();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Usuarios u = new Usuarios(this);
            u.Visible = true;
        }
        public void agregarIngreso(Vehiculo v)
        {
            string fechaIngreso = dateTimePicker1.Value.Date.ToString();
            string horaIngreso = dateTimePicker2.Value.TimeOfDay.ToString();
            string fechaSalida = dateTimePicker1.Value.Date.ToString();
            string horaSalida = dateTimePicker2.Value.TimeOfDay.ToString();
            v.agregarIngreso(fechaIngreso, horaIngreso, fechaSalida, horaSalida);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Todos t = new Todos(this);
            t.Visible = true;
        }
        public void guardarInfo()
        {   
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(RUTA_ARCHIVO, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, mundo);
            stream.Close();
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
