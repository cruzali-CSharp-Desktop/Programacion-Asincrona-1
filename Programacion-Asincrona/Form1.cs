using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programacion_Asincrona
{
    public partial class Form1 : Form
    {

        HttpClient httpClient = new HttpClient();

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

        private async Task ProcesarImagen(string directorio, Imagen imagen)
        {
            var respuesta = await httpClient.GetAsync(imagen.Url);
            var contenido = await respuesta.Content.ReadAsByteArrayAsync();

            Bitmap bitmap;
            using (var ms = new MemoryStream(contenido))
            {
                bitmap = new Bitmap(ms);
            }

            bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
            var destino = Path.Combine(directorio, imagen.Nombre);
            bitmap.Save(destino);
        }




        private static List<Imagen> ObtenerImagenes()
        {
            var imagenes = new List<Imagen>();

            for (int i = 0; i < 7; i++)
            {
                imagenes.Add(
                    new Imagen()
                    {
                        Nombre = $"Name {i}.png",
                        Url = "https://media.istockphoto.com/id/1440246683/es/foto/blog-palabra-sobre-bloques-c%C3%BAbicos-de-madera-sobre-fondo-gris.jpg?s=2048x2048&w=is&k=20&c=J6POaWh0A_uSEykhWkQUJY9Jn7lkzC6WDirNH3jyEvY="
                    });

                imagenes.Add(
                    new Imagen()
                    {
                        Nombre = $"Name {i}.png",
                        Url = "https://media.istockphoto.com/id/1440246683/es/foto/blog-palabra-sobre-bloques-c%C3%BAbicos-de-madera-sobre-fondo-gris.jpg?s=2048x2048&w=is&k=20&c=J6POaWh0A_uSEykhWkQUJY9Jn7lkzC6WDirNH3jyEvY="
                    });

                imagenes.Add(
                        new Imagen()
                        {
                            Nombre = $"Name {i}.png",
                            Url = "https://media.istockphoto.com/id/1440246683/es/foto/blog-palabra-sobre-bloques-c%C3%BAbicos-de-madera-sobre-fondo-gris.jpg?s=2048x2048&w=is&k=20&c=J6POaWh0A_uSEykhWkQUJY9Jn7lkzC6WDirNH3jyEvY="
                        });
            }

            return imagenes;
        }


        // Eliminar los archivos de la carpeta donde se descargaron a modo de pruebas
        private void BorrarArchivos(string directorio)
        {
            var archivos = Directory.EnumerateDirectories(directorio);

            foreach (var archivo in archivos)
            {
                File.Delete(archivo);
            }
        }


        private void PrepararEjecucion(string destinoBaseParalelo, string destinoBaseSecuencial)
        {
            if (!Directory.Exists(destinoBaseParalelo))
            {
                Directory.CreateDirectory(destinoBaseParalelo);
            }

            if (!Directory.Exists(destinoBaseSecuencial))
            {
                Directory.CreateDirectory(destinoBaseSecuencial);
            }

            BorrarArchivos(destinoBaseSecuencial);
            BorrarArchivos(destinoBaseParalelo);
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

        private async void Btn2_Click(object sender, EventArgs e)
        {

            pictureBox1.Visible = true;

            var directorioActual = AppDomain.CurrentDomain.BaseDirectory;
            var destinoBaseSecuencial = Path.Combine(directorioActual, @"Imagenes\resultado-secuencial");
            var destinoBaseParalelo = Path.Combine(directorioActual, @"Imagenes\resultado-paralelo");
            PrepararEjecucion(destinoBaseParalelo, destinoBaseSecuencial);

            Console.WriteLine("Inicio");
            List<Imagen> imagenes = ObtenerImagenes();


            // Parte secuencial
            var sw = new Stopwatch();
            sw.Start();

            foreach(var imagen in imagenes)
            {
                await ProcesarImagen(destinoBaseSecuencial, imagen);
            }

            Console.WriteLine("Secuencial - duracion en segundos: {0}", sw.ElapsedMilliseconds / 1000.0);

            sw.Reset();

            sw.Start();

            var tareasEnumerable = imagenes.Select(async imagen =>
            {
                await ProcesarImagen(destinoBaseParalelo, imagen);
            });

            await Task.WhenAll(tareasEnumerable);

            Console.WriteLine("Paralelo - duracion en segundos: {0}", sw.ElapsedMilliseconds / 1000.0);

     
            sw.Stop();

            pictureBox1.Visible = false;
        }
    }
}
