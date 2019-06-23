using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardarString
    {
        /// <summary>
        /// Metodo de Extension de la clase string 
        /// </summary>
        /// <param name="texto">texto a escribir</param>
        /// <param name="archivo">path del archivo</param>
        /// <returns></returns>
        public static bool Guardar(this string texto,string archivo)
        {
            bool retorno = false;
            StreamWriter sw = new StreamWriter(String.Format("{0}\\{1}", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), archivo), true);
            try
            {
               
                sw.WriteLine(texto);
                //sw.Close();
                retorno = true;
            }
            catch (Exception)
            {

                retorno = false;
            }
            finally
            {
                sw.Close();
            }
            return retorno;
        }
    }
}
