using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace felevesfeladat_DCQEB4
{
    class LancoltListaDolgozo
    {
        public delegate void DolgozoDelegalt(IAllatkertiDolgozo dolgozo);
        public delegate void FeladatNincsKepzett(IFeladat feladat);
        public delegate void FeladaUres(IFeladat feladat);
        public delegate void FeladatkiosztasDelegalt(IAllatkertiDolgozo dolgozo, IFeladat feladat);
        public class ListaElem
        {
            public IAllatkertiDolgozo Tartalom { get; set; }

            public ListaElem Kovetkezo { get; set; }
        }

        public ListaElem fej;

        public void Beszuras(IAllatkertiDolgozo dolgozo)
        {
            ListaElem uj = new ListaElem()
            {
                Tartalom = dolgozo
            };

            ListaElem p = fej;
            ListaElem e = null;

            while (p != null && p.Tartalom.kepzettseg > uj.Tartalom.kepzettseg)
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

        public void Bejaras(DolgozoDelegalt metodus)
        {
            ListaElem p = fej;
            while (p != null)
            {
                metodus?.Invoke(p.Tartalom);
                p = p.Kovetkezo;
            }
        }
        public void FeladatKiosztas(FeladatkiosztasDelegalt metodus,FeladatNincsKepzett feladat,DolgozoDelegalt dolgozo,FeladaUres feladaUres,LancoltListaFeladat lancoltListaFeladat)
        {
            ListaElem p = fej;
            int szamlalo = 0;
            int i = 0;
            IFeladat[] tomb = lancoltListaFeladat.tombe();
            while (p != null&&szamlalo<tomb.Length)
            {
                if (p.Tartalom.kepzettseg>4)
                {
                    p.Tartalom.kepzettseg = 4;
                    while (i != 5 && szamlalo < tomb.Length && (tomb[szamlalo].szint == p.Tartalom.kepzettseg || tomb[szamlalo].szint == p.Tartalom.kepzettseg - 1))
                    {
                        metodus?.Invoke(p.Tartalom, tomb[szamlalo]);
                        p.Tartalom.lancoltListaFeladat.Beszuras(tomb[szamlalo]);
                        szamlalo++;
                        i++;
                    }
                    p = p.Kovetkezo;
                }
                else
                {
                    if (p.Tartalom.kepzettseg<tomb[szamlalo].szint)
                    {
                        feladat?.Invoke(tomb[szamlalo]);
                        szamlalo++;
                        
                    }
                    else
                    {
                        while (i != 5 && szamlalo < tomb.Length && (tomb[szamlalo].szint == p.Tartalom.kepzettseg || tomb[szamlalo].szint == p.Tartalom.kepzettseg - 1))
                        {
                            metodus?.Invoke(p.Tartalom, tomb[szamlalo]);
                            p.Tartalom.lancoltListaFeladat.Beszuras(tomb[szamlalo]);
                            szamlalo++;
                            i++;
                        }
                        p = p.Kovetkezo;
                    }
                }
                i = 0;
            }
            while (szamlalo < tomb.Length)
            {
                feladaUres?.Invoke(tomb[szamlalo]);
                szamlalo++;
            }
            p = fej;
            while (p!=null)
            {
                if (p.Tartalom.lancoltListaFeladat.fej==null)
                {
                    dolgozo?.Invoke(p.Tartalom);
                }
                p = p.Kovetkezo;
            }
        }

        public void Torles(IAllatkertiDolgozo dolgozo)
        {
            ListaElem p = fej;
            ListaElem e = null;
            while (p != null && !(p.Tartalom == dolgozo))
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
