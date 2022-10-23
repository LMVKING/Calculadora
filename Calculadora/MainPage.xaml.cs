using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculadora
{
    public partial class MainPage : ContentPage
    {
        public double numeroUno = 0, numeroDos = 0, numRespuesta = 0;
        int operador = 4;
        bool haypunto = false, unoDecimal = false, dosDecimal = false;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Igualar_valores(String operando, int valor)
        {
            bool validadLbl = lblNumber.Text.GetType() != operador.GetType();
            bool validaSpn = spnFirst.Text.GetType() != operador.GetType();
            if (numRespuesta != 0 || ((validadLbl || validaSpn) || (validadLbl && validaSpn)))
            {
                unoDecimal = true;
            }

            if (unoDecimal)
            {
                numeroUno = double.Parse(lblNumber.Text);
            }

            else
            {
                numeroUno = int.Parse(lblNumber.Text);
                spnFirst.Text = numeroUno + " ";
                lblNumber.Text = "0";
                spnSecond.Text = operando;
                operador = valor;
                haypunto = false;
            }

        }
        private bool Hallar_Lleno()
        {
            bool estaLleno = false;
            if (spnFirst.Text == "" && spnSecond.Text == "")
            {
                estaLleno = true;


            }
            return estaLleno;
        }
        private void ingresarNumero(string numero)
        {
            if (lblNumber.Text == "0" && numero != ".")
            {
                lblNumber.Text = numero;
            }
            else
            {
                lblNumber.Text += numero;
            }
        }
        private void Btn_AC(object sender, EventArgs e)
        {
            numeroDos = 0;
            numeroUno = 0;
            numRespuesta = 0;
            haypunto = false;
            spnFirst.Text = "";
            spnSecond.Text = "";
            lblNumber.Text = "0";
            spnThird.Text = "";
        }
        private void Btn_sumar(object sender, EventArgs e)
        {
            Igualar_valores("+", 0);
            if (!Hallar_Lleno())
            {
                spnThird.Text = "";
            }
        }
        private void Click_C(object sender, EventArgs e)
        {
            if (lblNumber.Text.EndsWith("."))
            {
                haypunto = false;

            }
            if (lblNumber.Text != "0" && lblNumber.Text != "0.")
            {
                if (double.Parse(lblNumber.Text) > 10)
                {
                    lblNumber.Text = lblNumber.Text.Substring(0, lblNumber.Text.Length - 1);
                }
                else
                {
                    lblNumber.Text = "0";
                }
            }
            if (lblNumber.Text.EndsWith("."))
            {
                lblNumber.Text = lblNumber.Text.Substring(0, lblNumber.Text.Length - 1);
            }
        }
        private void Btn_restar(object sender, EventArgs e)
        {
            Igualar_valores("-", 1);
            if (!Hallar_Lleno())
            {
                spnThird.Text = "";
            }
        }
        private void Btn_por(object sender, EventArgs e)
        {
            Igualar_valores("*", 2);
            if (!Hallar_Lleno())
            {
                spnThird.Text = "";
            }
        }
        private void Btn_dividir(object sender, EventArgs e)
        {
            Igualar_valores("/", 3);
            if (!Hallar_Lleno())
            {
                spnThird.Text = "";
            }
        }
       
        private void Click_zero(object sender, EventArgs e)
        {
            if (lblNumber.Text != "0")
            {
                ingresarNumero("0");
            }
        }
        private void Click_uno(object sender, EventArgs e)
        {
            ingresarNumero("1");
        }
        private void Click_dos(object sender, EventArgs e)
        {
            ingresarNumero("2");
        }
        private void Click_tres(object sender, EventArgs e)
        {
            ingresarNumero("3");
        }
        private void Click_cuatro(object sender, EventArgs e)
        {
            ingresarNumero("4");
        }
        private void Click_cinco(object sender, EventArgs e)
        {
            ingresarNumero("5");
        }
        private void Click_seis(object sender, EventArgs e)
        {
            ingresarNumero("6");
        }
        private void Click_siete(object sender, EventArgs e)
        {
            ingresarNumero("7");
        }
        private void Click_ocho(object sender, EventArgs e)
        {
            ingresarNumero("8");
        }
        private void Click_nueve(object sender, EventArgs e)
        {
            ingresarNumero("9");
        }
        private void Click_return(object sender, EventArgs e)
        {

        }
        private void Btn_igual(object sender, EventArgs e)
        {
            if (spnFirst.Text != "" && spnSecond.Text != "")
            {
                spnThird.Text = " " + lblNumber.Text;
                if (dosDecimal)
                {
                    numeroDos = double.Parse(spnThird.Text);
                }
                else
                {
                    numeroDos = int.Parse(spnThird.Text);
                }
                if (operador == 0)
                {
                    numRespuesta = numeroUno + numeroDos;
                    lblNumber.Text = numRespuesta + "";
                }
                else if (operador == 1)
                {
                    numRespuesta = numeroUno - numeroDos;
                    lblNumber.Text = numRespuesta + "";
                }
                else if (operador == 2)
                {
                    numRespuesta = numeroUno * numeroDos;
                    lblNumber.Text = numRespuesta + "";
                }
                else
                {
                    if (numeroDos == 0)
                    {
                        numeroDos = 1;
                    }
                    numRespuesta = numeroUno / numeroDos;
                    lblNumber.Text = numRespuesta + "";
                }
                numeroUno = 0; numeroDos = 0; numRespuesta = 0;
                operador = 4; unoDecimal = false; dosDecimal = false;
            }


        }
        private void Click_punto(object sender, EventArgs e)
        {
            if (!haypunto)
            {
                ingresarNumero(".");
                haypunto = true;
            }
            if (operador == 4)
            {
                unoDecimal = true;
            }
            else
            {
                dosDecimal = true;
            }
        }
    }
}
