using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace felevesfeladat_DCQEB4
{
    interface IFeladat:IComparable
    {
        string nev { get; set; }
        int szint { get; set; }
    }
}
