using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinApp.modelo
{
    public class CurseView
    {
        public List<Curse> Curses { get; set; }

        public CurseView()
        {
            Curses = new Curse().GetCurse();
        }
    }
}
