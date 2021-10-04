using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace felevesfeladat_DCQEB4
{
    static class IO
    {
        
        static public LancoltListaFeladat Feladatbeolvasas(string filenev)
        {
            StreamReader streamReader = new StreamReader(filenev);
            string file = "";
            while (!streamReader.EndOfStream)
            {
                file += streamReader.ReadLine() + "!";
            }
            streamReader.Close();
            string[] help = file.Split('!');
            LancoltListaFeladat lancoltListaFeladat = new LancoltListaFeladat();
            for (int i = 0; i < help.Length; i++)
            {
                if (help[i]=="Jegyeladás")
                {
                    lancoltListaFeladat.Beszuras(new JegyEladas(help[i]));
                }
                if (help[i] == "Ketrec tisztítás")
                {
                    lancoltListaFeladat.Beszuras(new KetrecTisztitas(help[i]));
                }
                if (help[i] == "Orvosi felügyelet")
                {
                    lancoltListaFeladat.Beszuras(new OrvosiFelugyelet(help[i]));
                }
                if (help[i] == "Beszerzés")
                {
                    lancoltListaFeladat.Beszuras(new Beszerzes(help[i]));
                }
                if (help[i] == "Etetés")
                {
                    lancoltListaFeladat.Beszuras(new Etetes(help[i]));
                }
            }
            return lancoltListaFeladat;
        }
        static public LancoltListaDolgozo Dolgozobeolvasas(string filenev)
        {
            Allatkert allatkert = new Allatkert();
            StreamReader streamReader = new StreamReader(filenev);
            string file = "";
            while (!streamReader.EndOfStream)
            {
                file += streamReader.ReadLine() + "!";
            }
            streamReader.Close();
            string[] help = file.Split(';','!');
            LancoltListaDolgozo lancoltListaDolgozo = new LancoltListaDolgozo();
            for (int i = 0; i < help.Length-1; i+=2)
            {
                if (int.Parse(help[i + 1]) >= 4 )
                {
                    try
                    {
                        lancoltListaDolgozo.Beszuras(new Orvos(help[i], int.Parse(help[i + 1])));
                    }
                    catch (Kepzettsegiszint e)
                    {
                        allatkert.Tovabbkepzes(e.allatkertiDolgozo,Program.KepzetsegNemEleg_event);
                        lancoltListaDolgozo.Beszuras(e.allatkertiDolgozo);
                    }
                }
                if (int.Parse(help[i + 1]) == 3)
                {
                    try
                    {
                        lancoltListaDolgozo.Beszuras(new Allatgondozo(help[i], int.Parse(help[i + 1])));
                    }
                    catch (Kepzettsegiszint e)
                    {
                        allatkert.Tovabbkepzes(e.allatkertiDolgozo, Program.KepzetsegNemEleg_event);
                        lancoltListaDolgozo.Beszuras(e.allatkertiDolgozo);
                    }
                }
                if (int.Parse(help[i + 1]) == 2)
                {
                    try
                    {
                        lancoltListaDolgozo.Beszuras(new Penztaros(help[i], int.Parse(help[i + 1])));
                    }
                    catch (Kepzettsegiszint e)
                    {
                        allatkert.Tovabbkepzes(e.allatkertiDolgozo, Program.KepzetsegNemEleg_event);
                        lancoltListaDolgozo.Beszuras(e.allatkertiDolgozo);
                    }
                }
                if (int.Parse(help[i + 1]) <= 1)
                {
                    try
                    {
                        lancoltListaDolgozo.Beszuras(new Gondnok(help[i], int.Parse(help[i + 1])));
                    }
                    catch (Kepzettsegiszint e)
                    {
                        allatkert.Tovabbkepzes(e.allatkertiDolgozo, Program.KepzetsegNemEleg_event);
                        lancoltListaDolgozo.Beszuras(e.allatkertiDolgozo);
                    }
                }
            }
            return lancoltListaDolgozo;
        }
    }
}
