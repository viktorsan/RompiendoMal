using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RompiendoMal
{
    class Ingrediente
    {
        int m_calidad;
        int m_cantidad;
        string m_nombre;

        public Ingrediente(string nombre, int calidad, int cantidad)
        {
            m_calidad = calidad;
            m_cantidad = cantidad;
            m_nombre = nombre;
        }

        public string getNombre()
        {
            return m_nombre;
        }

        public int getCantidad()
        {
            return m_cantidad;
        }

        public int getCalidad()
        {
            return m_calidad;
        }

        public int UsaIngrediente()
        {
            m_cantidad--;
            return m_cantidad;
        }

        public int AgregaIngrediente(int cantidad, int calidad)
        {
            m_calidad = (m_calidad * m_cantidad) + (cantidad * calidad) / (m_cantidad + cantidad);
            m_cantidad += cantidad;
            return m_cantidad;
        }
    }
}
