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
            this.StartPosition = FormStartPosition.Manual;

            // Pone el formulario en el centro
            this.DesktopLocation = new Point((Screen.PrimaryScreen.Bounds.Width / 2) - (this.Width / 2),
                                              (Screen.PrimaryScreen.Bounds.Height / 2) - (this.Height / 2));
        
        Image imagen = Image.FromFile("C:/Users/MyASUS/Documents/ITSCO/ProgramacionVisual/Calculadora/eliminar.png");
            btnBasurero.BackgroundImage = imagen;
            btnBasurero.BackgroundImageLayout = ImageLayout.Zoom;

        }
    }
}
