using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException:Exception
    {
        public NacionalidadInvalidaException():base("La Nacionalidad No coincide con el Dni :(")
        {

        }

        public NacionalidadInvalidaException(string message):base(message)
        {

        }
    }
}
