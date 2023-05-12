using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();

            // Pone el formulario en el centro
            this.StartPosition = FormStartPosition.Manual;
            this.DesktopLocation = new Point((Screen.PrimaryScreen.Bounds.Width / 2) - (this.Width / 2),
                                              (Screen.PrimaryScreen.Bounds.Height / 2) - (this.Height / 2));
            //Quito a mis botones los bordes
            btnH1.FlatStyle = FlatStyle.Flat;
            btnH1.FlatAppearance.BorderSize = 0;
            btnH2.FlatStyle = FlatStyle.Flat;
            btnH2.FlatAppearance.BorderSize = 0;
            btnH3.FlatStyle = FlatStyle.Flat;
            btnH3.FlatAppearance.BorderSize = 0;
            btnH4.FlatStyle = FlatStyle.Flat;
            btnH4.FlatAppearance.BorderSize = 0;
            btnH5.FlatStyle = FlatStyle.Flat;
            btnH5.FlatAppearance.BorderSize = 0;
            btnH6.FlatStyle = FlatStyle.Flat;
            btnH6.FlatAppearance.BorderSize = 0;
            btnBasurero.FlatStyle = FlatStyle.Flat;
            btnBasurero.FlatAppearance.BorderSize = 0;
            //Pongo la imagen basurero en el boton y le doy cover
            Image imagen = Image.FromFile("C:/Users/MyASUS/Documents/ITSCO/ProgramacionVisual/Calculadora/eliminar.png");
            btnBasurero.BackgroundImage = imagen;
            btnBasurero.BackgroundImageLayout = ImageLayout.Zoom;

        }

        
    }
}
