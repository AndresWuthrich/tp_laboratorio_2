using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClasesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            Becado, Deudor, AlDia
        }

        Universidad.EClases claseQueToma;
        EEstadoCuenta estadoCuenta;

        #region "Constructores"
        public Alumno()
        { }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            :this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Un alumno es igual a un ECLase si toma esa clase y su estado de cuenta no es deudor.
        /// </summary>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            // Controlo que ni alumno ni clase no hayan sido instanciados, para evitar errores.
            if (!object.ReferenceEquals(a, null) && !object.ReferenceEquals(clase, null))
            {
                if (a.claseQueToma == clase)
                    if (!(a.estadoCuenta == EEstadoCuenta.Deudor))
                        return true;
            }
            return false;
        }
        #endregion

        protected override string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();
            datos.Append(base.MostrarDatos());
            datos.AppendLine("ESTADO DE CUENTA: " + this.estadoCuenta);
            datos.AppendLine(this.ParticiparEnClase());
            return datos.ToString(); 
        }

        protected override string ParticiparEnClase()
        {
            string datos  = ("\nTOMA CLASES DE " + this.claseQueToma);
            return datos;
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
