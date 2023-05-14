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

namespace Calculadora
{
    public partial class Form1 : Form
    {
        //VARIABLES GLOBALES 
        public static bool longitudCadena, sobreEscribir = false;
        public static double num1, num2, resultado;
        public static int posicion = 1, contadorClickOperadores = 1;// 1:aplasto operadores sino aplasto =
        public static string numero1 = "", numero2 = "";
        public static string cadena, operador = "";
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
            txtAbajo.ReadOnly = true;
        }

        private bool validarLongitudDeCadena()
        {
            if (txtAbajo.TextLength <= 14)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private void btnCero_Click(object sender, EventArgs e)
        {
            longitudCadena = validarLongitudDeCadena();
            cadena = txtAbajo.Text;

            if (!longitudCadena == true)
            {
                if (sobreEscribir == false)
                {
                    if ((cadena.Length == 1 && cadena == "0"))
                    {
                        // Evita imprimir esto 00  0000  0000000
                    }
                    else
                    {
                        txtAbajo.Text += "0";
                    }
                }
                else
                {
                    txtAbajo.Text = "1";
                    sobreEscribir = false;
                }
            }
            else
            {
                //La cadena esta llena
            }

        }

        private void clikEnOperadores(string operador)
        {
            numero1 = txtAbajo.Text;
            if (operador == "*")
            {
                txtArriba.Text = numero1 + " " + "*";
            }
            else if (operador == "+")
            {
                txtArriba.Text = numero1 + " " + "+";
            }
            else if (operador == "/")
            {
                txtArriba.Text = numero1 + " " + "/";
            }
            else if (operador == "-")
            {
                txtArriba.Text = numero1 + " " + "-";
            }
            sobreEscribir = true;
            posicion = 2;
        }
        private void UsuarioNoDaClikenIgual()
        {

            if (contadorClickOperadores == 1)
            {
                int longitud = txtArriba.Text.Length;
                char operadorAnti = txtArriba.Text[longitud - 1];
                ///Obtengo num1
                string temporal = txtArriba.Text.Split(' ')[0];
                num1 = Convert.ToDouble(temporal);
                ///Obtengo num2
                temporal = txtAbajo.Text;
                num2 = Convert.ToDouble(temporal);
                if (operadorAnti == '*')
                {
                    resultado = num1 * num2;
                    txtAbajo.Text = Convert.ToString(resultado);
                    posicion = 1;
                }
                else if (operadorAnti == '+')
                {
                    resultado = num1 + num2;
                    txtAbajo.Text = Convert.ToString(resultado);
                    posicion = 1;
                }
                else if (operadorAnti == '/')
                {
                    resultado = num1 / num2;
                    txtAbajo.Text = Convert.ToString(resultado);
                    posicion = 1;
                }
                else if (operadorAnti == '-')
                {
                    resultado = num1 - num2;
                    txtAbajo.Text = Convert.ToString(resultado);
                    posicion = 1;
                }
            }
            
            contadorClickOperadores++;
        }

        private void metodoSolucion()
        {
            int longitudArriba = txtArriba.Text.Length;
            char signo = txtArriba.Text[longitudArriba - 1];
            string nub1 = txtArriba.Text.Split(' ')[0];
            string nub2 = txtAbajo.Text;
            double nup1 = Convert.ToDouble(nub1);
            double nup2 = Convert.ToDouble(nub2);
            double res;
            if (signo == '*')
            {
                res = nup1 * nup2;
                txtAbajo.Text = Convert.ToString(res);
                posicion =  1;
            }else if (signo == '+')
            {
                res = nup1 + nup2;
                txtAbajo.Text = Convert.ToString(res);
                posicion = 1;
            }
            else if (signo == '/')
            {
                res = nup1 / nup2;
                txtAbajo.Text = Convert.ToString(res);
                posicion = 1;
            }
            else if (signo == '-')
            {
                res = nup1 - nup2;
                txtAbajo.Text = Convert.ToString(res);
                posicion = 1;
            }
        }
        private void btnUno_Click(object sender, EventArgs e)
        {
            longitudCadena = validarLongitudDeCadena();
            cadena = txtAbajo.Text;
            if (!longitudCadena == true)
            {
                if (sobreEscribir == false)
                {
                    if (cadena.Length == 1 && cadena == "0")
                    {
                        txtAbajo.Text = "1";
                    }
                    else
                    {
                        txtAbajo.Text += "1";
                    }
                }
                else
                {
                    txtAbajo.Text = "1";
                    sobreEscribir = false;
                }
            }
            else
            {
                //La cadena esta llena
            }
        }

        private void btnDos_Click(object sender, EventArgs e)
        {
            longitudCadena = validarLongitudDeCadena();
            cadena = txtAbajo.Text;
            if (!longitudCadena == true)
            {
                if (sobreEscribir == false)
                {
                    if (cadena.Length == 1 && cadena == "0")
                    {
                        txtAbajo.Text = "2";
                    }
                    else
                    {
                        txtAbajo.Text += "2";
                    }
                }
                else
                {
                    txtAbajo.Text = "2";
                    sobreEscribir = false;
                }
            }
            else
            {
                //La cadena esta llena
            }
        }

        private void btnTres_Click(object sender, EventArgs e)
        {
            longitudCadena = validarLongitudDeCadena();
            cadena = txtAbajo.Text;
            if (!longitudCadena == true)
            {
                if (sobreEscribir == false)
                {
                    if (cadena.Length == 1 && cadena == "0")
                    {
                        txtAbajo.Text = "3";
                    }
                    else
                    {
                        txtAbajo.Text += "3";
                    }
                }
                else
                {
                    txtAbajo.Text = "3";
                    sobreEscribir = false;
                }
            }
            else
            {
                //La cadena esta llena
            }
        }

        private void btnCuatro_Click(object sender, EventArgs e)
        {
            longitudCadena = validarLongitudDeCadena();
            cadena = txtAbajo.Text;
            if (!longitudCadena == true)
            {
                if (sobreEscribir == false)
                {
                    if (cadena.Length == 1 && cadena == "0")
                    {
                        txtAbajo.Text = "4";
                    }
                    else
                    {
                        txtAbajo.Text += "4";
                    }
                }
                else
                {
                    txtAbajo.Text = "4";
                    sobreEscribir = false;
                }
            }
            else
            {
                //La cadena esta llena
            }
        }

        private void btnCinco_Click(object sender, EventArgs e)
        {
            longitudCadena = validarLongitudDeCadena();
            cadena = txtAbajo.Text;
            if (!longitudCadena == true)
            {

                if (sobreEscribir == false)
                {
                    if (cadena.Length == 1 && cadena == "0")
                    {
                        txtAbajo.Text = "5";
                    }
                    else
                    {
                        txtAbajo.Text += "5";
                    }
                }
                else
                {
                    txtAbajo.Text = "5";
                    sobreEscribir = false;
                }

            }
            else
            {
                //La cadena esta llena
            }
        }

        private void btnSeis_Click(object sender, EventArgs e)
        {
            longitudCadena = validarLongitudDeCadena();
            cadena = txtAbajo.Text;
            if (!longitudCadena == true)
            {

                if (sobreEscribir == false)
                {
                    if (cadena.Length == 1 && cadena == "0")
                    {
                        txtAbajo.Text = "6";
                    }
                    else
                    {
                        txtAbajo.Text += "6";
                    }
                }
                else
                {
                    txtAbajo.Text = "6";
                    sobreEscribir = false;
                }


            }
            else
            {
                //La cadena esta llena
            }
        }

        private void btnSiete_Click(object sender, EventArgs e)
        {
            longitudCadena = validarLongitudDeCadena();
            cadena = txtAbajo.Text;
            if (!longitudCadena == true)
            {
                if (sobreEscribir == false)
                {
                    if (cadena.Length == 1 && cadena == "0")
                    {
                        txtAbajo.Text = "7";
                    }
                    else
                    {
                        txtAbajo.Text += "7";
                    }
                }
                else
                {
                    txtAbajo.Text = "7";
                    sobreEscribir = false;
                }
            }
            else
            {
                //La cadena esta llena
            }
        }

        private void btnOcho_Click(object sender, EventArgs e)
        {
            longitudCadena = validarLongitudDeCadena();
            cadena = txtAbajo.Text;
            if (!longitudCadena == true)
            {
                if (sobreEscribir == false)
                {
                    if (cadena.Length == 1 && cadena == "0")
                    {
                        txtAbajo.Text = "8";
                    }
                    else
                    {
                        txtAbajo.Text += "8";
                    }
                }
                else
                {
                    txtAbajo.Text = "8";
                    sobreEscribir = false;
                }

            }
            else
            {
                //La cadena esta llena
            }
        }

        private void btnNueve_Click(object sender, EventArgs e)
        {
            longitudCadena = validarLongitudDeCadena();
            cadena = txtAbajo.Text;
            if (!longitudCadena == true)
            {
                if (sobreEscribir == false)
                {
                    if (cadena.Length == 1 && cadena == "0")
                    {
                        txtAbajo.Text = "9";
                    }
                    else
                    {
                        txtAbajo.Text += "9";
                    }
                }
                else
                {
                    txtAbajo.Text = "9";
                    sobreEscribir = false;
                }

            }
            else
            {
                //La cadena esta llena
            }
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            longitudCadena = validarLongitudDeCadena();
            if (!longitudCadena == true)
            {
                cadena = txtAbajo.Text;
                if (!cadena.Contains("."))
                {
                    txtAbajo.Text += ".";
                }
            }
            else
            {
                //La cadena esta llena
            }
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnMultiplicacion_Click(object sender, EventArgs e)
        {
            if (posicion == 2)
            {
                UsuarioNoDaClikenIgual();
            }
            if (posicion == 2 && contadorClickOperadores>1)
            {
                metodoSolucion();
            }
            clikEnOperadores("*");
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            if (posicion == 2)
            {
                UsuarioNoDaClikenIgual();
            }
            if (posicion == 2 && contadorClickOperadores > 1)
            {
                metodoSolucion();
            }
            clikEnOperadores("/");
        }

        private void btnResta_Click(object sender, EventArgs e)
        {
            if (posicion == 2)
            {
                UsuarioNoDaClikenIgual();
            }
            if (posicion == 2 && contadorClickOperadores > 1)
            {
                metodoSolucion();
            }
            clikEnOperadores("-");
        }

        private void btnSuma_Click(object sender, EventArgs e)
        {
            if (posicion == 2)
            {
                UsuarioNoDaClikenIgual();
            }
            if (posicion == 2 && contadorClickOperadores > 1)
            {
                metodoSolucion();
            }
            clikEnOperadores("+");
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtAbajo.Text = "0";
            txtArriba.Text = "";
            posicion = 1;
        }
    }
}
