using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace felevesfeladat_DCQEB4
{
    class Kepzettsegiszint:System.Exception
    {
        public string uzenet;
        public IAllatkertiDolgozo allatkertiDolgozo;
        public Kepzettsegiszint(string uzenet, IAllatkertiDolgozo allatkertiDolgozo)
        {
            this.uzenet = uzenet;
            this.allatkertiDolgozo = allatkertiDolgozo;
        }
    }
}
