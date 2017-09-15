using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_5_tp_calculadora
{
    class Numero
    {
        private double numero;

        /// <summary>
        /// Getter
        /// </summary>
        public double getNumero
            {
                get
                {
                    return this.numero;
                }
            }

        /// <summary>
        /// Sobrecargas del Constructor
        /// </summary>
        public Numero()
        {
            this.numero = 0;                
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string numero)
        {
            double.TryParse(numero, out this.numero);
        }

        /// <summary>
        /// Setter
        /// </summary>
        public void setNumero(string numero)
        {
            this.numero = validarNumero(numero);            
        }

        private static double validarNumero(string numeroString) //falta validacion
        {
            double numeroIn = double.Parse(numeroString);
            return numeroIn; 
        }        
    }
}
