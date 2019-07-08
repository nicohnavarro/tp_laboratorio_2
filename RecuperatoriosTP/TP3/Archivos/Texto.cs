using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(archivo,true);
                writer.Write(datos);
                retorno = true;

            }catch(Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
            return retorno;
        }

        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(archivo);
                datos = reader.ReadToEnd();
                retorno = true;
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return retorno;
        }
    }
}
