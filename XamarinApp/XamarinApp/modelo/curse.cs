using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinApp.modelo
{
    public class Curse
    {
        public string Name { get; set; }

        public int Duration { get; set; }

        public string Location { get; set; }


        public List<Curse> GetCurse()
        {
            List<Curse> curses = new List<Curse>()
            {
                new Curse()
                {
                    Name="Ingles A2", Duration=2, Location="Almeria"
                },
                new Curse()
                {
                    Name="Ingles B2", Duration=1, Location="Aguadulce"
                },

            };
            return curses;
        }


    }
}
