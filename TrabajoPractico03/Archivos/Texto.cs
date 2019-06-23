using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto: IArchivo<string>
    {
        public bool Guardar(string archivo,string datos)
        {
            bool retorno = false;
            try
            {
                using (StreamWriter sw = new StreamWriter(archivo,true))
                {
                    sw.WriteLine(datos);
                    retorno= true;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                retorno= false;
            }
            return retorno;
        }

        public bool Leer(string archivos,out string datos)
        {
            bool retorno = false;
            try
            {
                datos = "";
                using (StreamReader sr = new StreamReader(archivos))
                {
                    datos = sr.ReadToEnd();
                    retorno= true;
                }
            }
            catch(ArchivosException e)
            {
                datos = e.Message;
                Console.WriteLine(e.Message);
                retorno = false;
            }
            return retorno;
        }
    }
}
