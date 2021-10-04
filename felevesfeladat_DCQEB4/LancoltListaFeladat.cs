using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace felevesfeladat_DCQEB4
{
    class LancoltListaFeladat
    {
        public delegate void BejaroDelegalt(IFeladat feladat,int szamlalo);
        public class ListaElem
        {
            public IFeladat Tartalom { get; set; }

            public ListaElem Kovetkezo { get; set; }
        }

        public ListaElem fej;

        public void Beszuras(IFeladat feladat)
        {
            ListaElem uj = new ListaElem()
            {
                Tartalom = feladat
            };

            ListaElem p = fej;
            ListaElem e = null;

            while (p != null && p.Tartalom.szint > uj.Tartalom.szint)
            {
                e = p;
                p = p.Kovetkezo;
            }

            if (e == null) //első elem elé beszúrás
            {
                uj.Kovetkezo = fej;
                fej = uj;
            }
            else //valahova vagy utolsó elem után szúrás
            {
                uj.Kovetkezo = p;
                e.Kovetkezo = uj;
            }

        }
        public IFeladat[] tombe()
        {
            ListaElem p = fej;
            int szamlalo = 0;
            while (p!=null)
            {
                szamlalo++;
                p=p.Kovetkezo;
            }
            IFeladat[] feladatok = new IFeladat[szamlalo];
            p = fej;
            szamlalo = 0;
            while (p!=null)
            {
                feladatok[szamlalo] = p.Tartalom;
                szamlalo++;
                p = p.Kovetkezo;
            }
            return feladatok;
        }

        public void Bejaras(BejaroDelegalt metodus)
        {
            ListaElem p = fej;
            int szamlalo = 1;
            while (p != null)
            {
                metodus?.Invoke(p.Tartalom,szamlalo);
                szamlalo++;
                p = p.Kovetkezo;
            }
        }

        public void Torles(IFeladat feladat)
        {
            ListaElem p = fej;
            ListaElem e = null;
            while (p != null && !(p.Tartalom == feladat))
            {
                e = p;
                p = p.Kovetkezo;
            }
            if (p != null)
            {
                if (e == null)
                {
                    fej = p.Kovetkezo;
                }
                else
                {
                    e.Kovetkezo = p.Kovetkezo;
                }
            }
        }
    }
}
