using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace felevesfeladat_DCQEB4
{
    class Etetes:IFeladat
    {
        public string nev { get; set; }
        public int szint { get; set; }
        public Etetes(string nev)
        {
            this.nev = nev;
            szint = 3;
        }

        public int CompareTo(object obj)
        {
            if (szint > (obj as IFeladat).szint)
            {
                return 1;
            }
            else if (szint < (obj as IFeladat).szint)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        public override string ToString()
        {
            return "Feladat neve: " + nev + "\t" + " Feladat szintje: " + szint;
        }
    }
}
