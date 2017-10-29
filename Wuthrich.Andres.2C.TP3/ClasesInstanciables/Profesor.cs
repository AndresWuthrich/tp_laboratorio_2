using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClasesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {   
        Queue<Universidad.EClases> clasesDelDia;
        static Random random;

        #region "Constructores"
        public Profesor()
        { }
        static Profesor()
        {
            random = new Random();            
        }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            this.RandomClases();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Un Profesor será igual a un EClase si da esa clase.
        /// </summary>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            if (!object.ReferenceEquals(i, null) && !object.ReferenceEquals(clase, null))
            {
                foreach (Universidad.EClases c in i.clasesDelDia)
                {
                    if (clase == c)
                        return true;
                }
            }
            return false;
        }
        #endregion

        private void RandomClases()
        {
            //random;
        }

        protected override string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();
            datos.Append(base.MostrarDatos());
            datos.AppendLine(this.ParticiparEnClase());
            return datos.ToString();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine("CLASES DEL DíA:");
            foreach (Universidad.EClases c in this.clasesDelDia)
            {
                datos.Append(c.ToString());
            }
            return datos.ToString();
        }

        public override string ToString()
        {
            string datos = this.MostrarDatos();
            return datos; 
        }
    }
}
