using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace felevesfeladat_DCQEB4
{
    interface IAllatkertiDolgozo:IComparable
    {
        string nev {get; set;}
        int kepzettseg {get; set;}
        LancoltListaFeladat lancoltListaFeladat {get; set;}
    }
}
