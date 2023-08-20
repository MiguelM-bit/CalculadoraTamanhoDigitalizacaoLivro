using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcTamanhoDigitalizacaoLivro
{
    public partial class Form1 : Form
    {
        int NumerodeLivros;
        int PaginasporLivro;
        int PalavrasporPagina;
        int Caracteresporpalavra;

        int UmMB = 1024 * 1024;

        int NumeroTotaldeCaracteres;
        int NumeroTotaldeBytes;
        int NumeroTotaldeMB;

        public Form1()
        {
            InitializeComponent();
        }

        public void VerificaNum(KeyPressEventArgs e)
        {
            // Verifica se o caractere digitado não é um número ou tecla de controle
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Impede que o caractere seja inserido no TextBox
            }
        }

        private bool CamposPreenchidos()
        {
            return !string.IsNullOrEmpty(textBox1.Text) &&
                   !string.IsNullOrEmpty(textBox2.Text) &&
                   !string.IsNullOrEmpty(textBox3.Text) &&
                   !string.IsNullOrEmpty(textBox4.Text);
        }

        public void ClicouBtnCalcular()
        {
            if (CamposPreenchidos())
            {
                // Lê os valores dos campos de entrada
                NumerodeLivros = int.Parse(textBox1.Text);
                PaginasporLivro = int.Parse(textBox2.Text);
                PalavrasporPagina = int.Parse(textBox3.Text);
                Caracteresporpalavra = int.Parse(textBox4.Text);

                NumeroTotaldeCaracteres = NumerodeLivros * PaginasporLivro * PalavrasporPagina * Caracteresporpalavra;

                NumeroTotaldeBytes = NumeroTotaldeCaracteres * 2; // Considerando que cada caractere é de 2 bytes (UTF-16 encoding)

                NumeroTotaldeMB = NumeroTotaldeBytes / UmMB;

                // Exibe o resultado na label textResultado
                textResultado.Text = NumeroTotaldeMB + " MB.";
            }
            else
            {
                MessageBox.Show("Por favor, preencha todos os campos.");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            VerificaNum(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            VerificaNum(e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            VerificaNum(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            VerificaNum(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClicouBtnCalcular();
        }
    }
}
