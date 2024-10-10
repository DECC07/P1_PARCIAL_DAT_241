using System;
using System.Windows.Forms;
using CalculatorLibrary; // Asegúrate de tener esta directiva

namespace Calculadora7
{
    public partial class Form1 : Form
    {
        private Calculadora calculadora;

        public Form1()
        {
            InitializeComponent();
            calculadora = new Calculadora();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string infixExpression = textBox1.Text;
            double result = calculadora.EvaluateInfix(infixExpression);
            label1.Text = $"Resultado infijo: {result}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string prefixExpression = textBox2.Text;
            double result = calculadora.EvaluatePrefix(prefixExpression);
            label2.Text = $"Resultado prefijo: {result}";
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
