using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace felevesfeladat_DCQEB4
{
    class Allatkert
    {
        public delegate void Esemeny(string szoveg);
        public LancoltListaDolgozo listaDolgozo;
        public LancoltListaFeladat listaFeladat;
        public Allatkert(string dologozokfilepath, string feladatfilepath)
        {
            listaDolgozo = IO.Dolgozobeolvasas(dologozokfilepath);
            listaFeladat = IO.Feladatbeolvasas(feladatfilepath);
        }
        public void Dolgozokfelvevese(string dolgozokfilepath)
        {
            listaDolgozo = IO.Dolgozobeolvasas(dolgozokfilepath);
        }
        public void Feladatkeresese(string feladatfilepath)
        {
            listaFeladat = IO.Feladatbeolvasas(feladatfilepath);
        }
        public Allatkert()
        {

        }
        public void Tovabbkepzes(IAllatkertiDolgozo allatkertiDolgozo,Esemeny esemeny)
        {
            esemeny?.Invoke(allatkertiDolgozo.nev + " el lett küldve továbbképzésre");
            allatkertiDolgozo.kepzettseg = 1;
        }
    }
}
