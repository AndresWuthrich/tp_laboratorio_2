using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase_5_tp_calculadora
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "TP Calculadora";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Calculadora()); 
        }
    }

}
