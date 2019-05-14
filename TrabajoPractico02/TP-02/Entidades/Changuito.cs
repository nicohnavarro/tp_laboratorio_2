﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Changuito
    {
        List<Producto> productos;
        int espacioDisponible;
        public enum ETipo
        {
            Dulce, Leche, Snacks, Todos
        }

        #region "Constructores"

        /// <summary>
        /// Builder
        /// </summary>
        private Changuito()
        {
            this.productos = new List<Producto>();
        }

        /// <summary>
        /// Builder with parametres
        /// </summary>
        /// <param name="espacioDisponible"></param>
        public Changuito(int espacioDisponible):this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el Changuito y TODOS los Productos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Mostrar(Changuito c, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", c.productos.Count, c.espacioDisponible);
            sb.AppendLine("");
            foreach (Producto productoAux in c.productos)
            {
                switch (tipo)
                {
                    case ETipo.Snacks:
                        if(productoAux is Snacks)
                            sb.AppendLine(productoAux.Mostrar());
                        break;
                    case ETipo.Dulce:
                        if(productoAux is Dulce)
                            sb.AppendLine(productoAux.Mostrar());
                        break;
                    case ETipo.Leche:
                        if(productoAux is Leche)
                            sb.AppendLine(productoAux.Mostrar());
                        break;
                    default:
                        sb.AppendLine(productoAux.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns></returns>
        public static Changuito operator +(Changuito c, Producto p)
        {
            bool agregar = true;
            if(c.espacioDisponible > c.productos.Count)
            {
                foreach (Producto v in c.productos)
                {
                    if (v == p)
                        agregar = false;
                }
                if(agregar)
                    c.productos.Add(p);
            }
            return c;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns></returns>
        public static Changuito operator -(Changuito c, Producto p)
        {
            foreach (Producto productoAux in c.productos)
            {
                if (productoAux == p)
                {
                    c.productos.Remove(productoAux);
                    break;
                }
            }

            return c;
        }
        #endregion
    }
}
