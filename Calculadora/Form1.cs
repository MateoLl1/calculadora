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
        public static bool longitudCadena, sobreEscribir = false, igualActivo = false;
        public static double num1, num2, resultado;
        public static int posicion = 1, contadorClickOperadores = 1;// 1:aplasto operadores sino aplasto =
        public static string numero1 = "", numero2 = "";
        public static string cadena, operadorG = "";
        public static string guardarUno, guardarDos, guardarRes;
        public static string []  historial = { "", "", "", "", "", "" };
        public static bool reiniciar = false;
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
            operadorG = operador;
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
                char operadorAnti = operadorG[0];
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
            //char signo = txtArriba.Text[longitudArriba - 1];
            char signo = operadorG[0];
            string nub1 = txtArriba.Text.Split(' ')[0];
            string nub2 = txtAbajo.Text;
            double nup1 = Convert.ToDouble(nub1);
            double nup2 = Convert.ToDouble(nub2);
            double res;
            if (signo == '*')
            {
                res = nup1 * nup2;
                txtAbajo.Text = Convert.ToString(res);
            }
            else if (signo == '+')
            {
                res = nup1 + nup2;
                txtAbajo.Text = Convert.ToString(res);
            }
            else if (signo == '/')
            {
                res = nup1 / nup2;
                txtAbajo.Text = Convert.ToString(res);
            }
            else if (signo == '-')
            {
                res = nup1 - nup2;
                txtAbajo.Text = Convert.ToString(res);
            }
            posicion = 1;
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

        private void guardarHistorial(string num1, string num2, string res)
        {

            ///Busco saber cuales estan llenos o vacion
            int numeroVacios = 0;
            
            for (int i = 0; i <= 5; i++)
            {
                if (historial[i] == "")
                {
                    numeroVacios++;
                }
                
            }

            ///CON NUMEROVACIOS DETERMINO DONDE GUARDAR
            if (numeroVacios == 6)
            {
                btnH1.Text = num1 + " " + operadorG + " " + num2 + " = " + res;
                historial[0] = "x";
            }
            if (numeroVacios == 5)
            {
                btnH2.Text = num1 + " " + operadorG + " " + num2 + " = " + res;
                historial[1] = "x";
            }
            if (numeroVacios == 4)
            {
                btnH3.Text = num1 + " " + operadorG + " " + num2 + " = " + res;
                historial[2] = "x";
            }
            if (numeroVacios == 3)
            {
                btnH4.Text = num1 + " " + operadorG + " " + num2 + " = " + res;
                historial[3] = "x";
            }
            if (numeroVacios == 2)
            {
                btnH5.Text = num1 + " " + operadorG + " " + num2 + " = " + res;
                historial[4] = "x";
            }
            if (numeroVacios == 1)
            {
                btnH6.Text = num1 + " " + operadorG + " " + num2 + " = " + res;
                ///EMPIEZO A REESCRIBIR EL HISTORIAL
                historial[0] = "";
                historial[1] = "";
                historial[2] = "";
                historial[3] = "";
                historial[4] = "";
                historial[5] = "";
            }
           
        }
        private string traerHistorial()
        {
            return "awd";
        }

        private void btnBasurero_Click(object sender, EventArgs e)
        {
            btnH1.Text = "";
            btnH2.Text = "";
            btnH3.Text = "";
            btnH4.Text = "";
            btnH5.Text = "";
            btnH6.Text = "";
            historial[0] = "";
            historial[1] = "";
            historial[2] = "";
            historial[3] = "";
            historial[4] = "";
            historial[5] = "";
        }

        private void metodoIgual()
        {
            
            string resul;
            
            if (igualActivo==true)
            {
                txtArriba.Text = Convert.ToString(num1) + " " +operadorG;
                num1 = Convert.ToDouble(txtArriba.Text.Split(' ')[0]);
                num2 = Convert.ToDouble(txtAbajo.Text);
            }
            else
            {
                numero1 = txtArriba.Text.Split(' ')[0];
                numero2 = txtAbajo.Text;
                num1 = Convert.ToDouble(numero1);
                num2 = Convert.ToDouble(numero2);
            }
            guardarUno = Convert.ToString(num1);
            if (operadorG == "+")
            {
                txtArriba.Text = resul = $"{num1} + {num2}";
                num1 = num1 + num2;
                txtAbajo.Text = Convert.ToString(num1);
            }
            else if (operadorG == "-")
            {
                txtArriba.Text = resul = $"{num1} - {num2}";
                num1 = num1 - num2;
                txtAbajo.Text = Convert.ToString(num1);
            }
            else if (operadorG == "/")
            {
                txtArriba.Text = resul = $"{num1} / {num2}";
                num1 = num1 / num2;
                txtAbajo.Text = Convert.ToString(num1);
            }
            else if (operadorG == "*")
            {
                txtArriba.Text = resul = $"{num1} * {num2}";
                num1 = num1 * num2;
                txtAbajo.Text = Convert.ToString(num1);
            }
            guardarRes = Convert.ToString(num1);
            guardarDos = Convert.ToString(num2);
            guardarHistorial(guardarUno,guardarDos,guardarRes);
            sobreEscribir = true;
            igualActivo = true;
        }
        private void btnIgual_Click(object sender, EventArgs e)
        {
            metodoIgual();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            cadena = txtAbajo.Text;
            txtAbajo.Text = EliminarUltimoCaracter(cadena);
        }

        private void btnMultiplicacion_Click(object sender, EventArgs e)
        {
            operadorG = "*";
            if (igualActivo == true)
            {
                metodoIgual();
            }
            else
            {

                if (posicion == 2)
                {
                    UsuarioNoDaClikenIgual();
                }
                if (posicion == 2 && contadorClickOperadores > 1)
                {
                    metodoSolucion();
                }
                clikEnOperadores("*");
            }

        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            operadorG = "/";
            if (igualActivo == true)
            {
                metodoIgual();
            }
            else
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

        }

        private void btnResta_Click(object sender, EventArgs e)
        {
            operadorG = "-";
            if (igualActivo == true)
            {
                metodoIgual();
            }
            else
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
        }

        private void btnSuma_Click(object sender, EventArgs e)
        {
            operadorG = "+";
            if (igualActivo == true)
            {
                metodoIgual();
            }
            else
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
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            txtAbajo.Text = "0";
            txtArriba.Text = "";
            posicion = 1;
            igualActivo = false;
        }

        public string EliminarUltimoCaracter(string cadena)
        {
            if (cadena.Length == 0)
            {
                // Si la cadena está vacía, no se puede eliminar ningún carácter
                return cadena;
            }
            else
            {
                // Eliminar el último carácter de la cadena
                return cadena.Remove(cadena.Length - 1, 1);
            }
        }

    }
}
