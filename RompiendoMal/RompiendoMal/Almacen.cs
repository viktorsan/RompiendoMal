using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RompiendoMal
{
    class Almacen
    {
        private int m_CalidadDelAlmacen;
        private int m_money;
        private Producto m_productoAlmacenado = new Producto(0,0);
        private List<Ingrediente> Ingredientes = new List<Ingrediente>();

        public Almacen(int difficultyLevel)
        {
            m_CalidadDelAlmacen = 1;
            m_money = 1000 * (3 - difficultyLevel);
        }

        public int getCalidad()
        {
            return m_CalidadDelAlmacen;
        }

        public Producto getProductoAlmacenado()
        {
            return m_productoAlmacenado;
        }

        public Ingrediente getIngrediente(string ing)
        {
            foreach (Ingrediente ingrediente in Ingredientes)
            {
                if (ingrediente.getNombre().Equals(ing))
                {
                    return ingrediente;
                }
            }
            return (new Ingrediente("vacio",0,0));
        }

        public int getMoney()
        {
            return m_money;
        }

        public void gastaMoney(int dinero)
        {
            m_money -= dinero;
        }

        public void MejoraAlmacen()
        {
            m_CalidadDelAlmacen = m_CalidadDelAlmacen*100;
        }

        public bool CompraIngrediente(Ingrediente ing, int precioDelIngrediente)
        {
            if (precioDelIngrediente > m_money)
            {
                return false;
            }
            else
            {
                m_money -= precioDelIngrediente;
                AlmacenaIngrediente(ing);
                return true;
            }
        }

        private void AlmacenaIngrediente(Ingrediente ing)
        {
            bool found = false;
            foreach (Ingrediente ingrediente in Ingredientes)
            {
                if (ingrediente.getNombre().Equals(ing.getNombre()))
                {
                    ingrediente.AgregaIngrediente(ing);
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Ingredientes.Add(ing);
            }
        }

        public Ingrediente UsaIngrediente(string ing)
        {
            foreach (Ingrediente ingrediente in Ingredientes)
            {
                if (ingrediente.getNombre().Equals(ing))
                {
                    if (ingrediente.UsaIngrediente() == 0)
                    {
                        Ingredientes.Remove(ingrediente);
                    }
                    return ingrediente;
                }
            }
            return null;
        }

        public void VendeProducto(int dineroGanado)
        {
            m_money += dineroGanado;
            m_productoAlmacenado.VendeProducto();
        }

        public void AlmacenaProducto(Producto nuevoProducto)
        {
            m_productoAlmacenado.AgregaProducto(nuevoProducto);
        }
    }
}
