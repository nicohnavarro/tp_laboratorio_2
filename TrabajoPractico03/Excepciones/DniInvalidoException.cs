using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException:Exception
    {
        private string mensajeBase;

        public DniInvalidoException() : this("")
        {

        }

        public DniInvalidoException(Exception e):this("",e)
        {

        }

        public DniInvalidoException(string mensaje):this(mensaje,null)
        {
            
        }

        public DniInvalidoException(string message,Exception e):base(message,e)
        {
            this.mensajeBase = message;
        }
    }
}
