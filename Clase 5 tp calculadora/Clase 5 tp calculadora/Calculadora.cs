using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase_5_tp_calculadora
{
    /// <summary>
    /// Enumerador de operaciones (sin uso)
    /// </summary>
    enum Operacion
    {
        Suma,
        Resta,
        Multiplicacion,
        Division
    }

    public partial class Calculadora : Form
    {
        public Calculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Resuelvo operaciones
        /// </summary>
        private static double operar(Numero numero1, Numero numero2, string operador)
        {
            double resultado;
            
            switch (operador)
            {
                case "+"://Operacion.Suma:
                    resultado = numero1.getNumero + numero2.getNumero;
                    break;
                case "-": //Operacion.Resta:
                    resultado = numero1.getNumero - numero2.getNumero;
                    break;
                case "*": //Operacion.Multiplicacion:
                    resultado = numero1.getNumero * numero2.getNumero;
                    break;
                default: //Operacion.Division:
                    if (numero2.getNumero == 0)
                    {
                        resultado = 0;
                    }
                    else
                    {
                        resultado = numero1.getNumero / numero2.getNumero;
                    }
                    break;
            }
            return resultado;
        }

        /// <summary>
        /// Valido operador
        /// </summary>
        public static string validarOperador(string operador)
        {
            if (operador != "+" || operador != "-" || operador != "*" || operador != "/")
            {
                return "+";
            }
            else
            {
                return operador;
            }
        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {            
            string texto = txtNumero1.Text.Trim();
        }
        private void txtNumero2_TextChanged(object sender, EventArgs e)
        {
            string texto = txtNumero2.Text.Trim();
        }

        /// <summary>
        /// Leo operacion seleccionada
        /// </summary>
        private void cmbOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            validarOperador(cmbOperacion.Text);
        }

        /// <summary>
        /// Boton Operar
        /// </summary>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            Numero nro1 = new Numero();
            nro1.setNumero(txtNumero1.Text);
            Numero nro2 = new Numero();
            nro2.setNumero(txtNumero2.Text);

            double resul = operar(nro1, nro2,cmbOperacion.Text);
            lblResultado.Text = resul.ToString();
        }

        //private void lblResultado_Click(object sender, EventArgs e)
        //{}

        /// <summary>
        /// Limpio campos en pantalla
        /// </summary>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            cmbOperacion.Text = " ";
            lblResultado.Text = "0";
        }

        /// <summary>
        /// Load Calculadora
        /// </summary>
        private void Calculadora_Load(object sender, EventArgs e)
        {}    
    }
}
