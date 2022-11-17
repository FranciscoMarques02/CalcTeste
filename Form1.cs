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

        public Form1()
        {
            InitializeComponent();            
        }

        //Evento sempre que um nº for clicado
        private void numeroPressionado(object sender, EventArgs e)
        {                                                                                              
            //O txbResultado.Text recebe o nº clicado 
            Button numero = (Button)sender;
            txbResultado.Text += numero.Text;            
           
            flag = true;            
        }

        //Evento quando um operador for clicado
        private void operacao(object sender, EventArgs e)
        {
            Button operador = (Button)sender;
            
            //Não permitir mais de um operador clicado entre nºs
            if (flag)
            {
                //O txbResultado.Text recebe operador clicado                 
                txbResultado.Text += operador.Text;
                
                flag = false;
            } 
            else if (txbResultado.Text != "")
            {
                var t = txbResultado.Text.ToArray();
                t[t.Length - 1] = operador.Text.ToArray()[0];

                txbResultado.Text = new string(t);
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
        }
    }
}
