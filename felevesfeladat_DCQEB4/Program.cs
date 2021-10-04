using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace felevesfeladat_DCQEB4
{
    class Program
    {
        static void Main(string[] args)
        {
            Allatkert allatkert = new Allatkert("dolgozok.csv", "feladat.csv");
            allatkert.listaDolgozo.Bejaras(ListaBejarasDolgozo_event);
            Console.WriteLine();
            allatkert.listaFeladat.Bejaras(ListaBejarasFeladat_event);
            Console.WriteLine();
            allatkert.listaDolgozo.FeladatKiosztas(FeladaKiosztas_event, FeladatNincsKepzett, DolgozoUres,FeladatUres, allatkert.listaFeladat);
            Console.ReadLine();
        }
        private static void FeladatUres(IFeladat feladat)
        {
            Console.WriteLine("FONTOS!!! " + feladat.nev + " feladat nem lett kiosztva! Mert nincs elég dolgozó!");
        }
        private static void FeladatNincsKepzett(IFeladat feladat)
        {
            Console.WriteLine("FONTOS!!! "+feladat.nev+" feladat nem lett kiosztva! Mert nincs eléggé képzett dolgozó!");
        }
        private static void DolgozoUres(IAllatkertiDolgozo allatkertiDolgozo)
        {
            Console.WriteLine("FONTOS!!! " +allatkertiDolgozo.nev+" nem kapott munkát!");
        }
        private static void ListaBejarasDolgozo_event(IAllatkertiDolgozo allatkertiDolgozo)
        {
            Console.WriteLine(allatkertiDolgozo.ToString());
        }
        private static void ListaBejarasFeladat_event(IFeladat feladat,int szamlalo)
        {
            Console.WriteLine(szamlalo+". "+feladat.ToString());
        }
        private static void FeladaKiosztas_event(IAllatkertiDolgozo dolgozo, IFeladat feladat)
        {
            Console.WriteLine(dolgozo.nev+" kapott egy "+feladat.nev+" feladatot!");
        }
        public static void KepzetsegNemEleg_event(string szoveg)
        {
            Console.WriteLine(szoveg);
        }
    }
}
