using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;
            XmlTextWriter writer = null;
            XmlSerializer ser = null;
            try
            {
                writer = new XmlTextWriter(archivo, Encoding.UTF8);
                ser = new XmlSerializer(typeof(T));
                ser.Serialize(writer, datos);
                retorno = true;
            }
            catch(Exception e)
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

        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;
            XmlTextReader reader=null;
            XmlSerializer ser = null;
            try
            {
                reader = new XmlTextReader(archivo);
                ser = new XmlSerializer(typeof(T));
                datos = (T)ser.Deserialize(reader);
                retorno = true;
            }catch(Exception e)
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
