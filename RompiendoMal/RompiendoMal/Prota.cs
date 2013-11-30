using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace RompiendoMal
{
    class Prota
    {
        private int m_experience;
        private int m_level;
        private int m_money;
        private int m_contactos;
        private int m_wantedLevel;


        private int[] LevelLimits = {100,1000,5000,15000,35000,60000,100000};
        enum Estado {Libre, Cocinando, Vendiendo};
        Estado m_estado;

        private float tiempoOcupado;

        public Prota(int difficultyLevel)
        {
            m_experience = 0;
            m_level = 0;
            m_wantedLevel = 0;
            m_money = 5000 * (3-difficultyLevel);
            m_contactos = 3-difficultyLevel;
            m_estado = Estado.Libre;
            tiempoOcupado = 0f;
        }

        public Producto Cocina(Ingrediente ingrediente1, Ingrediente ingrediente2, Ingrediente ingrediente3, int calidadInstalaciones)
        {
            int calidadDelProducto = (ingrediente1.getCalidad() * m_level) + (ingrediente2.getCalidad() * m_level) + (ingrediente3.getCalidad() * m_level);
            int cantidadDeProducto = m_level * calidadInstalaciones;
            m_estado = Estado.Cocinando;
            tiempoOcupado = 20000;
            m_experience += calidadDelProducto * cantidadDeProducto;
             

            return new Producto(cantidadDeProducto,calidadDelProducto);
        }

        public int Vende(int calidadDelProducto)
        {
            int numeroDeVentas = calidadDelProducto * m_contactos;
            return numeroDeVentas;
        }

        public void Update(GameTime gameTime)
        {
            if (m_estado != Estado.Libre)
            {
                tiempoOcupado = MathHelper.Max(0, tiempoOcupado - gameTime.ElapsedGameTime.Milliseconds);
                if (tiempoOcupado == 0)
                {
                    m_estado = Estado.Libre;
                }
            }
        }
    }
}
