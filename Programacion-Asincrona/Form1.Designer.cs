
namespace Programacion_Asincrona
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnEmpezar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnEmpezar
            // 
            this.BtnEmpezar.Location = new System.Drawing.Point(325, 342);
            this.BtnEmpezar.Name = "BtnEmpezar";
            this.BtnEmpezar.Size = new System.Drawing.Size(147, 40);
            this.BtnEmpezar.TabIndex = 0;
            this.BtnEmpezar.Text = "Empezar";
            this.BtnEmpezar.UseVisualStyleBackColor = true;
            this.BtnEmpezar.Click += new System.EventHandler(this.BtnEmpezar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Programacion_Asincrona.Properties.Resources.Loading_icon;
            this.pictureBox1.Location = new System.Drawing.Point(298, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(203, 149);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BtnEmpezar);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnEmpezar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

