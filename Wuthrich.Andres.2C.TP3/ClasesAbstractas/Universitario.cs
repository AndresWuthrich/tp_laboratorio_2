using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Excepciones;

namespace ClasesAbstractas
{
    public abstract class Universitario : Persona
    {
        int legajo;

        #region "Constructores"
        public Universitario()
        { }
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Dos universitarios son iguales si, y sólo si, comparten el mismo número de legajo.
        /// </summary>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            // Controlo que ninguno de los dos universitarios no haya sido instanciado, para evitar errores.
            //bool pg1Equals = Universitario.Equals(pg1);

            if (!object.ReferenceEquals(pg1, null) && !object.ReferenceEquals(pg2, null))
            {
                if (pg1 is Universitario && pg2 is Universitario)
                    if (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI)
                        throw new AlumnoRepetidoException();
                        //return true;
            }
            return false;
        }
        #endregion

        public bool Equals(object obj)
        {
        //    if (!object.ReferenceEquals(obj, null))
                return true;
        //    return false;
        }

        protected virtual string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();
            datos.Append(base.ToString());
            datos.AppendLine("\nLEGAJO NÚMERO: " + this.legajo);
            return datos.ToString();
        }

        protected abstract string ParticiparEnClase();
    }
}
