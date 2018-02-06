using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinApp.modelo
{
    public class CurseClasses
    {

        public string NombreCurso{ get; set; }

        public int DuracionCurso { get; set; }

        public string Lugar { get; set; }

        public string URL { get; set; }

        public double Precio { get; set; }


        public List<CurseClasses> GetCurseClasses()
        {
            List<CurseClasses> curses = new List<CurseClasses>()
            {
                new CurseClasses()
                {
                    NombreCurso="Ingles A2", DuracionCurso=2, Lugar="Almeria", URL="https://images.freeimages.com/images/large-previews/bfd/clouds-1371838.jpg",Precio=120
                },
                new CurseClasses()
                {
                    NombreCurso="Ingles B2", DuracionCurso=2, Lugar="Aguadulce", URL="https://images.freeimages.com/images/large-previews/bfd/clouds-1371838.jpg",Precio=200
                },

            };
            return curses;
        }
    }
}
