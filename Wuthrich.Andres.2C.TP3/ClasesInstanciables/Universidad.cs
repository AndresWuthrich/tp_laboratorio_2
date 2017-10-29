using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        /// <summary>
        /// enumerado EClases
        /// </summary>
        public enum EClases
        {
            Programacion, Laboratorio, Legislacion, SPD
        }

        List<Alumno> alumnos;
        List<Jornada> jornada;
        List<Profesor> profesores;

        #region "Constructores"
        public Universidad()
        {
            alumnos = new List<Alumno>();
            jornada = new List<Jornada>();
            profesores = new List<Profesor>();
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
        public List<Profesor> Instructores
        { 
            get
            { return this.profesores; }
            set
            { this.profesores = value; }
        }
        public List<Jornada> Jornadas
        {
            get
            { return this.jornada; }
            set
            { this.jornada = value; }
        }
        public Jornada this[int i]
        { 
            get
            { return jornada[i]; }
            set
            { jornada[i] = value; }
        } 
        #endregion

        #region "Operadores"
        /// <summary>
        /// Un Universidad será igual a un alumno si el mismo está inscripto en él.
        /// </summary>
        public static bool operator ==(Universidad g, Alumno a)
        {
            if(!object.ReferenceEquals(g,null) && !object.ReferenceEquals(a,null))
                foreach (Alumno alumno in g.alumnos)
                {
                    if (a == alumno)
                        return true;
                }
            return false;
        }
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Un Universidad igual a un profesor retorna el 1er profesor capaz de dar esa clase.
        /// </summary>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            Profesor p = new Profesor();
            return p;
        }
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            if (!object.ReferenceEquals(g, null) && !object.ReferenceEquals(clase, null))

//                throw new SinProfesorException();

                //foreach (EClases c in clase)
                {
                    //if (g == clase)
                    //    return Universidad.EClases;
            }

            Profesor p = new Profesor();
            return p;
        }

        /// <summary>
        /// Un Universidad será igual a un profesor si el mismo está dando clases en él.
        /// </summary>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        public static bool operator ==(Universidad g, Profesor i)
        {
            if (!object.ReferenceEquals(g, null) && !object.ReferenceEquals(i, null))
                foreach (Profesor profesor in g.profesores)
                {
                    if (i == profesor)
                        return true;
                }
            return false;
        }

        public static Universidad operator +(Universidad g, Alumno a)
        {
            if(g != a)
                g.alumnos.Add(a);

            return g;         
        }

        public static Universidad operator +(Universidad g, Profesor i)
        {
            if(g != i)
                g.profesores.Add(i);

            return g;
        }

        public static Universidad operator +(Universidad g, EClases clase)
        {
            foreach (Profesor p in g.Instructores)
            {
                //Universidad[Jornada] j = new Universidad[Jornada]();

                //foreach(Alumno a in g.Alumnos)
                //    int i= i++;
 
                //j[0].Alumnos.Add(g.Alumnos);
                //if (p == clase)
                //{
                g.jornada.Add(new Jornada(clase, p));

                //Jornada j = new Jornada(clase, p);
                //foreach(Alumno a in g.Alumnos)
                    


                //    break;
                ////}

            }           
            return g;
        }
        #endregion

        public static bool Guardar(Universidad gim)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            xml.Guardar("Universidad.xml", gim);
                        
            return true;
        }

        public static string Leer()
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            
            Universidad gim;
            xml.Leer("Universidad.xml", out gim);
            
            Console.WriteLine("<----------------->");

            return gim.ToString();
        }
        
        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder datos = new StringBuilder();
 
            foreach (Jornada j in gim.jornada)
            {
                datos.AppendLine(j.ToString());

                datos.AppendLine("<------------------------------------------------->\n");
            }
            return datos.ToString();
        }

        public override string ToString()
        {
            return MostrarDatos(this);
        }
    }
}
