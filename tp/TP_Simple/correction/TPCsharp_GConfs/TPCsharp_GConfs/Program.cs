using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO; 

namespace TPCsharp_GConfs
{

    struct Point2D
    {
        public int x;
        public int y;
    }

    class Program
    {
        static void Main(string[] args)
        {
            HelloWorld();
            // tests de fact
            Console.WriteLine("Fact(4) = "+fact(4));
            int f = 0;
            fact(5, ref f);
            Console.WriteLine("Fact(5) = "+f);
            Console.WriteLine("Fact_for (6) = " + fact_for(6));
            Console.WriteLine("Fact_while (7) = " + fact_for(7));
            // tests Point(...)
            Point2D pt, pt2;
            pt.x = 10;
            pt.y = 20;
            pt2.x = 30;
            pt2.y = 0;
            Console.Write("add (10,20) (30,0): ");
            print_pt2d(add_pt2d(pt, pt2));
            Console.Write("opp (10,20): ");
            print_pt2d(opp_pt2d(pt));
            Console.Write("dist (10,20) (30,0): ");
            Console.WriteLine(dist_pt2d(pt, pt2));
            // tests des Bonus       
            AfficherHistogramme("histo.txt", "etoiles_h.txt");
            AfficherHistogrammeHauteur("histo.txt", "etoiles_v.txt");
            RechercheChaine( "ref_mots.txt", "mots.txt","occ_mots.txt");
            RechercheChaineTexte("ref_mots2.txt", "texte.txt", "occ_texte.txt");

            Console.ReadLine();
        }

        static void HelloWorld()
        {
            Console.WriteLine("Hello world");
        }

        static int fact(int n)
        {
            if (n <= 1)
                return 1;
            else
                return n * fact(n - 1);
            /* Toutes ces lignes peuvent s'écrire en une seule:
             * return (n <= 1)? 1 : n * fact(n - 1);
             * Chercher "opérateur ternaire"
             */
        }

        static int fact_while(int n)
        {
            int res = 1;
            while (n > 1)
            {
                res *= n; // ou: res = res * i;
                n--;
            }
            return res;
        }

        static int fact_for(int n)
        {
            int res = 1;
            for (int i = 1; i <= n; i++)
                res *= i;
            return res;
        }

        static void fact(int n, ref int res)
        {
            res = fact_for(n);
        }

        static void print_pt2d(Point2D p)
        {
            Console.WriteLine("x=" + p.x.ToString() + " ; y=" + p.y.ToString());
        }

        static Point2D add_pt2d(Point2D pa, Point2D pb)
        {
            Point2D pt;
            pt.x = pa.x + pb.x;
            pt.y = pa.y + pb.y;
            return pt;
        }

        static Point2D opp_pt2d(Point2D p)
        {
            Point2D res;
            res.x = -p.x;
            res.y = -p.y;
            return res;
        }

        static void opp_pt2d(ref Point2D p)
        {
            p.x = -p.x;
            p.y = -p.y;
        }

        static Point2D sub_pt2d(Point2D pa, Point2D pb)
        {
            return add_pt2d(pa, opp_pt2d(pb));
        }

        static float dist_pt2d(Point2D pa, Point2D pb)
        {
            return (float)Math.Sqrt((pb.x - pa.x) * (pb.x - pa.x)
                           + (pb.y - pa.y) * (pb.y - pa.y));
        }

        /* BONUS! */
        static void AfficherHistogramme(string path1, string path2)
        {
            /* Il faut ajouter au début du ficher la ligne:
             * using System.IO pour accéder aux fonctions
             * de lecture/écriture d'un fichier.
             */
            try
            {
                using (StreamReader sr = new StreamReader(path1))
                {
                    using (StreamWriter sw = new StreamWriter(path2))
                    {
                        int[] histogram = new int[7]; // 7 chiffres en tout (1 .. 7).
                        while (!sr.EndOfStream)
                        {
                            int nchar = sr.Read();
                            if (nchar >= '1' && nchar <= '7')
                                histogram[nchar - '1']++;
                        }
                        for (int i = 0; i < 7; i++)
                        {
                            sw.Write("{0} :", i + 1);
                            for (int j = 0; j < histogram[i]; j++)
                                sw.Write(" *");
                            sw.WriteLine();
                        }
                        sr.Close();
                        sw.Close();
                    }
                }
            }
            catch
            {
                Console.WriteLine("Erreur d'ouverture.");
            }
        }

        static void AfficherHistogrammeHauteur(string path1, string path2)
        {
            /* Il faut ajouter au début du ficher la ligne:
             * using System.IO pour accéder aux fonctions
             * de lecture/écriture d'un fichier.
             */
            try
            {
                using (StreamReader sr = new StreamReader(path1))
                {
                    using (StreamWriter sw = new StreamWriter(path2))
                    {
                        int maxCount = 0;
                        int[] histogram = new int[7]; // 7 chiffres en tout (1 .. 7).
                        while (!sr.EndOfStream)
                        {
                            int nchar = sr.Read();
                            if (nchar >= '1' && nchar <= '7')
                            {
                                histogram[nchar - '1']++;
                                if (histogram[nchar - '1'] > maxCount)
                                    maxCount++;
                            }
                        }
                        for (int i = 1; i < 8; i++)
                            sw.Write("{0} ", i);
                        sw.WriteLine();
                        for (int i = 0; i < 7; i++)
                            sw.Write("- ");
                        sw.WriteLine();
                        for (int i = 1; i <= maxCount; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                if (histogram[j] >= i)
                                    sw.Write("* ");
                                else
                                    sw.Write("  ");
                            }
                            sw.WriteLine();
                        }
                        // on ferme tout proprement!
                        sr.Close();
                        sw.Close();
                    }
                }
            }
            catch
            {
                Console.WriteLine("Erreur d'ouverture.");
            }
        }

        static void RechercheChaine(string in1, string in2, string outfile)
        {
            try
            {
                using (StreamReader sr = new StreamReader(in1))
                {
                    using (FileStream fs = new FileStream(in2, FileMode.Open))
                    {
                        using (StreamReader sr2 = new StreamReader(fs))
                        {
                            using (StreamWriter sw = new StreamWriter(outfile))
                            {
                                while (!sr.EndOfStream)
                                {
                                    string sfound = sr.ReadLine();
                                    while (!sr2.EndOfStream)
                                        if (sr2.ReadLine() == sfound)
                                            sw.WriteLine(sfound);
                                    fs.Position = 0; // Pointe sur le début de fichier 2
                                }
                                // on ferme tout proprement!
                                sr.Close();
                                sr2.Close();
                                fs.Close();
                                sw.Close();
                            }
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Erreur d'ouverture.");
            }
        }

        static void RechercheChaineTexte(string in1, string in2, string outfile)
        {
            try
            {
                using (StreamReader sr = new StreamReader(in1))
                {
                    using (StreamReader sr2 = new StreamReader(in2))
                    {
                        using (StreamWriter sw = new StreamWriter(outfile))
                        {
                            string[] filestring = sr2.ReadToEnd().Split('\n', '\r', ' ', '(', ')', '.', '\'', ';', '{', '}');
                            while (!sr.EndOfStream)
                            {
                                string founds = sr.ReadLine();
                                for (int i = 0; i < filestring.Length; i++)
                                {
                                    if (filestring[i] == founds)
                                    {
                                        sw.WriteLine(founds);
                                        break; // On sort du for
                                    }
                                }
                            }
                            // on ferme tout proprement!
                            sr.Close();
                            sr2.Close();
                            sw.Close();
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Erreur d'ouverture.");
            }
        }

    }
}
