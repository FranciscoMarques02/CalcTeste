using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcTeste
{
    public partial class Form1 : Form
    {
        //Variável global:
        bool flag;
        string aux, b;

        public Form1()
        {
            InitializeComponent();            
        }

        //Evento sempre que um nº for clicado
        private void numeroPressionado(object sender, EventArgs e)
        {                                                                                                           
            Button numero = (Button)sender;
            this.aux += "";

            if ((numero.Text == "." && this.aux.Contains(".") == false) || numero.Text != ".")
            {
                //Se o "." for clicado antes do primeiro número ou logo após um operador
                if(numero.Text == "." && this.aux == "")
                {
                    txbResultado.Text += "0";
                }

                //O txbResultado.Text recebe o nº clicado
                txbResultado.Text += numero.Text;
                this.aux += numero.Text;
                this.b = numero.Text;
            }
                                  
            flag = true;            
        }

        //Evento quando um operador for clicado
        private void operacao(object sender, EventArgs e)
        {
            Button operador = (Button)sender;
            
            //Não permitir mais de um operador clicado entre nºs
            if (flag && this.b != ".")
            {
                //O txbResultado.Text recebe operador clicado                 
                txbResultado.Text += operador.Text;
                
                flag = false;
                this.aux = "";
            } 
            else if (txbResultado.Text != "")
            {
                var t = txbResultado.Text.ToArray();
                t[t.Length - 1] = operador.Text.ToArray()[0];

                txbResultado.Text = new string(t);
                this.aux = "";
            }
           
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            try
            {
                txbAux.Text = txbResultado.Text;
                
                //Variável "resultado" recebe o txbResultado.Text
                //em forma de expressão numérica
                DataTable dt = new DataTable();
                var resultado = dt.Compute(txbResultado.Text, "");

                double a = Math.Round(double.Parse(resultado.ToString()), 2);

                txbResultado.Text = (a.ToString()).Replace(",",".");
            }
            catch
            {
                txbResultado.Text = "ERRO";
            }
            
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txbResultado.Text = "";
            txbAux.Text = "";
            flag = false;
            this.aux = "";
            this.b = "";
        }
    }
}
