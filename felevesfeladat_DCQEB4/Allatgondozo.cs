﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace felevesfeladat_DCQEB4
{
    class Allatgondozo : IAllatkertiDolgozo
    {
        public string nev { get; set; }
        public int kepzettseg { get; set; }
        public LancoltListaFeladat lancoltListaFeladat { get; set; }
        public Allatgondozo(string nev, int kepzettseg = 3)
        {
            lancoltListaFeladat = new LancoltListaFeladat();
            this.nev = nev;
            if (kepzettseg < 1)
            {
                throw new Kepzettsegiszint(this.nev + "-nek a képzetségi szintje nem elég", this);
            }
            else
            {
                this.kepzettseg = kepzettseg;
            }
        }

        public int CompareTo(object obj)
        {
            if (kepzettseg > (obj as IAllatkertiDolgozo).kepzettseg)
            {
                return 1;
            }
            else if (kepzettseg < (obj as IAllatkertiDolgozo).kepzettseg)
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
            return "Dolgozo neve: " +"Állatgondozó "+ nev + "\t" + " Dolgozo kepzettsége: " + kepzettseg;
        }
    }
}
