using ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        public Alumno():base()
        {

        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma):base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma,EEstadoCuenta estadoCuenta):this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine(base.MostrarDatos());
            sb.AppendFormat("\nEstado de Cuenta: {0}\n", this.estadoCuenta);
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        public static bool operator==(Alumno a,Universidad.EClases clase)
        {
            bool retorno = false;
            if(a.claseQueToma==clase && a.estadoCuenta!=EEstadoCuenta.Deudor)
            {
                retorno = true;
            }
            return retorno;
        }
        public static bool operator!=(Alumno a,Universidad.EClases clase)
        {
            return !(a == clase);
        }

        protected override string ParticiparEnClase()
        {
            return string.Format("TOMA CLASE DE {0}" +
                "\n<-------------------------------------------------------------->\n"
                , this.claseQueToma);
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

    }
}
