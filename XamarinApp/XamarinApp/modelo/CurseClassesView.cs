using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinApp.modelo
{
    public class CurseClassesView
    {
        public List<CurseClasses> CursesClasses { get; set; }

        public CurseClassesView()
        {
            CursesClasses = new CurseClasses().GetCurseClasses();
        }
    }
}
