using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Universitario:Persona
    {
        private int legajo;

        public override bool Equals(object obj)
        {
            bool retorno = false;
            if(obj is Universitario)
            {
                retorno = true;
            }
            return retorno;
        }

        protected virtual string MostrarDatos()
        {
            return base.ToString() + "\nLegajo Numero: " + this.legajo.ToString();
        }

        public static bool operator==(Universitario pg1,Universitario pg2)
        {
            bool retorno = false;
            if (pg1.Equals(pg2) && (pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo))
            {
                retorno = true;
            }
            else
            {
                retorno = false;
            }
            
            return retorno;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1==pg2);
        }

        protected abstract string ParticiparEnClase();

        public Universitario()
        {

        }

        public Universitario(int legajo, string nombre, string apellido, string dni,ENacionalidad nacionalidad):base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }
    }
}
