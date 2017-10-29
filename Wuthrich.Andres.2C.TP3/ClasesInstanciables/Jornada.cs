using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Archivos;

namespace ClasesInstanciables
{
    public class Jornada
    {
        List<Alumno> alumnos;
        Universidad.EClases clase;
        Profesor instructor;

        #region "Constructores"
        private Jornada()
        {
            alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.EClases clase, Profesor instructor):this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region "Propiedades"
        public List<Alumno> Alumnos
        {
            get
            { return this.alumnos; }
            set
            { this.alumnos = value; }
        }
        public Universidad.EClases Clase
        {
            get
            { return this.clase; }
            set
            { this.clase = value; }
        }
        public Profesor Instructor
        {
            get
            { return this.instructor; }
            set
            { this.instructor = value; }
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Una Jornada será igual a un alumno si el mismo participa de la clase.
        /// </summary>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        public static bool operator ==(Jornada j, Alumno a)
        {
            // Controlo que ni alumno ni clase no hayan sido instanciados, para evitar errores.
            if (!object.ReferenceEquals(j, null) && !object.ReferenceEquals(a, null))
            {
                foreach (Alumno alumno in j.alumnos)
                {
                    // Busco alumno en la clase.
                    if (a == alumno)
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Agrega alumnos a la clase, siempre y cuando no estén previamente cargados.
        /// </summary>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j != a)
                j.alumnos.Add(a);
            
            return j;
        }
        #endregion

        public static bool Guardar(Jornada jornada)
        {
            Texto j = new Texto();
            j.Guardar("Jornada.txt", jornada.ToString());

            return true;
        }

        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine("JORNADA:");
            datos.AppendLine("CLASE DE "+ this.Clase + " POR " + this.Instructor);
            datos.AppendLine("\nALUMNOS:");
            foreach (Alumno a in this.alumnos)
            {
                datos.Append(a.ToString());
            }
            return datos.ToString();
        }
    }
}
