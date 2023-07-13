using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

            //var nombre = await ProcesamientoLargo();

            //MessageBox.Show("Saludos " + nombre);

            var sw = new Stopwatch();
            sw.Start();

            // Se ejecuta una detrás de la otra.
            //await RealizaProcesamientoLargoA();
            //await RealizaProcesamientoLargoB();
            //await RealizaProcesamientoLargoC();

            var tareas = new List<Task>()
            {
                RealizaProcesamientoLargoA(),
                RealizaProcesamientoLargoB(),
                RealizaProcesamientoLargoC()
            };

            await Task.WhenAll(tareas);


            sw.Stop();
            var duracion = $"El programa se ejecutó en {sw.ElapsedMilliseconds / 1000.0} segundos";
            Console.WriteLine(duracion);

            //Thread.Sleep(5000); // Síncrono

            pictureBox1.Visible = false;
        }


        private async Task<string> ProcesamientoLargo()
        {
            await Task.Delay(3000); // Delay retorna un task en el futuro.
            MessageBox.Show("Ya paso");
            return "Ali C";
        }

        private async Task RealizaProcesamientoLargoA()
        {
            await Task.Delay(1000);
            Console.WriteLine("Proceso A finalizado");
        }

        private async Task RealizaProcesamientoLargoB()
        {
            await Task.Delay(1000);
            Console.WriteLine("Proceso B finalizado");
        }

        private async Task RealizaProcesamientoLargoC()
        {
            await Task.Delay(1000);
            Console.WriteLine("Proceso C finalizado");
        }



    }
}
