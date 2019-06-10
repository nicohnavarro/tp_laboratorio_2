using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T>: IArchivo<T>
    {
        public bool Guardar(string archivo,T datos)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XmlTextWriter writer = null;
            bool retorno = false;

            try
            {
                writer = new XmlTextWriter(archivo, null);
                serializer.Serialize(writer, datos);
                retorno = true;
            }
            catch(Exception e)
            {
                retorno = false;
            }
            finally
            {
                writer.Close();
            }
            return retorno;
        }

        public bool Leer(string archivo,out T datos)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XmlTextReader reader = null;
            bool retorno = false;
            try
            {
                reader = new XmlTextReader(archivo);
                datos = (T)serializer.Deserialize(reader);
                retorno = true;
            }
            catch(Exception e)
            {
                retorno = false;
                datos = default(T);
            }
            finally
            {
                reader.Close();
            }
            return retorno;
        }
    }
}
