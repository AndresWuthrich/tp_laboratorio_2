using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;
using Excepciones;

namespace ClasesAbstractas
{
    /// <summary>
    /// Clase Abstracta 
    /// </summary>
    public abstract class Persona
    {
        /// <summary>
        /// enumerado ENacionalidad
        /// </summary>
        public enum ENacionalidad
        {
            Argentino, Extranjero
        }

        string apellido, nombre;
        int dni;
        ENacionalidad nacionalidad;

        #region "Constructores"
        public Persona()
        { }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad):this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni; 
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region "Propiedades"
        public string Nombre
        {
            get
            { return this.nombre; }
            set
            { this.nombre = ValidarNombreApellido(value); }
        }
        public string Apellido
        {
            get
            { return this.apellido; }
            set
            { this.apellido = ValidarNombreApellido(value); }
        }
        public int DNI
        {
            get
            { return this.dni; }
            set
            { this.dni = ValidarDni(this.Nacionalidad, value); }
        }
        public ENacionalidad Nacionalidad
        {
            get
            { return this.nacionalidad; }
            set
            { this.nacionalidad = value; }
        }
        public string StringToDNI
        {
            set
            { this.dni = ValidarDni(this.Nacionalidad, value); }
        }
        #endregion
        
        #region "Validadores"
        /// <summary>
        /// Validará que el DNI esté dentro de los rangos permitidos
        /// </summary>
        private static int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                        throw new NacionalidadInvalidaException(dato.ToString());
                    break;
                case ENacionalidad.Extranjero:
                    if (dato < 89999999 || dato > 99999999)
                        throw new NacionalidadInvalidaException();
                    break;
            }
            return dato;
        }

        /// <summary>
        /// Validará que el DNI sea numérico, y luego llamará a la validación numérica
        /// </summary>
        private static int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            // Quito los . que pueda tener el número
            dato = dato.Replace(".", "");
            // Compruebo que tenga al menos 1 caracter y no más de 8, dados por el número 99.999.999
            if (dato.Length < 1 || dato.Length > 8)
                throw new DniInvalidoException(dato.ToString());
            int numeroDni;

            try
            {
                numeroDni = Int32.Parse(dato);
            }
            catch (Exception e)
            {
                throw new DniInvalidoException(dato.ToString(), e);
            }

            return Persona.ValidarDni(nacionalidad, numeroDni);
        }

        /// <summary>
        /// Validará que el nombre esté compuesto solo por caracteres latinos a-z A-Z
        /// </summary>
        private static string ValidarNombreApellido(string dato)
        {
            // Expresión regular para buscar solo caracteres de la a a la z minúsculas y mayúsculas con N repeticiones
            Regex regex = new Regex(@"[a-zA-Z]*");
            // Valido el dato
            Match match = regex.Match(dato);

            if (match.Success)
                return match.Value;
            else
                return "";
        }
        #endregion

        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre);
            datos.AppendLine("NACIONALIDAD:" + this.Nacionalidad);
            return datos.ToString();
        }
    }
}
