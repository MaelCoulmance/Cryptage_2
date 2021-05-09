using System;
using System.Collections.Generic;

namespace Cryptage.Commons.Util.Generic
{
    public static class DicoInit
    {
        // Classic dictionaries
        public static List<string> ClassicMin()
        {
            List<string> res = new List<string>();

            res.Add("a");
            res.Add("b");
            res.Add("c");
            res.Add("d");
            res.Add("e");
            res.Add("f");
            res.Add("g");
            res.Add("h");
            res.Add("i");
            res.Add("j");
            res.Add("k");
            res.Add("l");
            res.Add("m");
            res.Add("n");
            res.Add("o");
            res.Add("p");
            res.Add("q");
            res.Add("r");
            res.Add("s");
            res.Add("t");
            res.Add("u");
            res.Add("v");
            res.Add("w");
            res.Add("x");
            res.Add("y");
            res.Add("z");

            return res;
        }

        public static List<string> ClassicMaj()
        {
            List<string> tmp = ClassicMin();
            List<string> res = new List<string>();

            foreach (string s in tmp)
                res.Add(s.ToUpper());

            return res;
        }


        // Navajo dictionaries
        public static List<string> NavajoMin()
        {
            List<string> res = new List<string>();

            res.Add("Wol-la-chee");
            res.Add("Shush");
            res.Add("Moasi");
            res.Add("Be");
            res.Add("Dzeh");
            res.Add("Ma-e");
            res.Add("Klizzie");
            res.Add("Lin");
            res.Add("Tkin");
            res.Add("Tkele-cho-gi");
            res.Add("Klizzie-yazzie");
            res.Add("Dibeh-yazzie");
            res.Add("Na-as-tso-si");
            res.Add("Nesh-chee");
            res.Add("Ne-ahs-jah");
            res.Add("Bi-sodih");
            res.Add("Ca-yeilth");
            res.Add("Gah");
            res.Add("Dibeh");
            res.Add("Than-zie");
            res.Add("No-da-ih");
            res.Add("A-keh-di-glini");
            res.Add("Gloe-ih");
            res.Add("Al-an-as-dzoh");
            res.Add("Tsah-as-zih");
            res.Add("Besh-do-gliz");

            return res;
        }

        public static List<string> NavajoMaj()
        {
            List<string> tmp = NavajoMin();
            List<string> res = new List<string>();

            foreach (string s in tmp)
            {
                res.Add(s.ToUpper());
            }

            return res;
        }


        // Aero dictionaries
        public static List<string> AeroIntMin()
        {
            List<string> res = new List<string>();

            res.Add("Alfa");
            res.Add("Bravo");
            res.Add("Charlie");
            res.Add("Delta");
            res.Add("Echo");
            res.Add("Fox-Trot");
            res.Add("Golf");
            res.Add("Hotel");
            res.Add("India");
            res.Add("Juliett");
            res.Add("Kilo");
            res.Add("Lima");
            res.Add("Mike");
            res.Add("November");
            res.Add("Oscar");
            res.Add("Papa");
            res.Add("Quebec");
            res.Add("Romeo");
            res.Add("Sierra");
            res.Add("Tango");
            res.Add("Uniform");
            res.Add("Victor");
            res.Add("Whiskey");
            res.Add("X-ray");
            res.Add("Yankee");
            res.Add("Zoulou");

            return res;
        }

        public static List<string> AeroIntMaj()
        {
            List<string> tmp = AeroIntMin();
            List<string> res = new List<string>();

            foreach (string s in tmp)
            {
                res.Add(s.ToUpper());
            }

            return res;
        }

        public static List<string> AeroFrMin()
        {
            List<string> res = new List<string>();

            res.Add("Anatole");
            res.Add("Berthe");
            res.Add("Célestine");
            res.Add("Désirée");
            res.Add("Eugène");
            res.Add("François");
            res.Add("Gaston");
            res.Add("Henri");
            res.Add("Irma");
            res.Add("Joseph");
            res.Add("Kléber");
            res.Add("Louis");
            res.Add("Marcel");
            res.Add("Nicolas");
            res.Add("Oscar");
            res.Add("Pierre");
            res.Add("Quintal");
            res.Add("Raoul");
            res.Add("Suzanne");
            res.Add("Thérèse");
            res.Add("Ursule");
            res.Add("Victor");
            res.Add("William");
            res.Add("Xavier");
            res.Add("Yvonne");
            res.Add("Zoé");

            return res;
        }

        public static List<string> AeroFrMaj()
        {
            List<string> tmp = AeroFrMin();
            List<string> res = new List<string>();

            foreach (string s in tmp)
            {
                res.Add(s.ToUpper());
            }

            return res;
        }
        
        
        // Morse dictionaries
        public static List<string> Morse()
        {
            List<string> res = new List<string>();
                
            res.Add("._");
            res.Add("_...");
            res.Add("_._.");
            res.Add("_..");
            res.Add(".");
            res.Add(".._.");
            res.Add("__.");
            res.Add("....");
            res.Add("..");
            res.Add(".___");
            res.Add("_._");
            res.Add("._..");
            res.Add("__");
            res.Add("_.");
            res.Add("___");
            res.Add(".__.");
            res.Add("__._");
            res.Add("._.");
            res.Add("...");
            res.Add("_");
            res.Add(".._");
            res.Add("..._");
            res.Add(".__");
            res.Add("_.._");
            res.Add("_.__");
            res.Add("__..");
            res.Add(".____");
            res.Add("..___");
            res.Add("...__");
            res.Add("...._");
            res.Add(".....");
            res.Add("_....");
            res.Add("__...");
            res.Add("___..");
            res.Add("____.");
            res.Add("_____");

            return res;
        }

        public static List<string> ClassicDicoForMorse()
        {
            List<string> res = ClassicMaj();
                
            res.Add("0");
            res.Add("1");
            res.Add("2");
            res.Add("3");
            res.Add("4");
            res.Add("5");
            res.Add("6");
            res.Add("7");
            res.Add("8");
            res.Add("9");

            return res;
        }
    }
}
