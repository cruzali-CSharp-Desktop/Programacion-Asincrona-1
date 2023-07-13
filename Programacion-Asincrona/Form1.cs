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
            pictureBox1.Visible = true;

            // Proceso lento

            Task.Delay(5000);
            
            //Thread.Sleep(5000); // Síncrono

            pictureBox1.Visible = false;
        }
    }
}
