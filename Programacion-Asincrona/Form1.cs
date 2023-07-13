using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programacion_Asincrona
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void BtnEmpezar_Click(object sender, EventArgs e)
        {
            // async void es un antipatron
            // SOLO se usa cuando estamos ante un evento como el evento Click (Fuera de estos casos no usarlo así)

            pictureBox1.Visible = true;

            // Proceso lento

            // ProcesamientoLargo(); // No espera la respuesta del Procesaminto, se pasa a la siguiente linea.

            //await ProcesamientoLargo();

            var nombre = await ProcesamientoLargo();

            MessageBox.Show("Saludos " + nombre);
            
            //Thread.Sleep(5000); // Síncrono

            pictureBox1.Visible = false;
        }


        private async Task<string> ProcesamientoLargo()
        {
            await Task.Delay(3000); // Delay retorna un task en el futuro.
            MessageBox.Show("Ya paso");
            return "Ali C";
        }
    }
}
