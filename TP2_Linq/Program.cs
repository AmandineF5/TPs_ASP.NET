using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_Linq.BO;

namespace TP2_Linq
{
    public class Program
    {
        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();
        private static string resultat;
        public static void Main(string[] args)
        {
            InitialiserDatas();
            
            // Afficher la liste des prénoms des auteurs dont le nom commence par "G"
            Console.WriteLine("#1 Afficher la liste des prénoms des auteurs dont le nom commence par G: \n");
            foreach (var item in ListeAuteurs.Where(x => x.Nom.StartsWith("G")))
            {
                resultat = item.Prenom;
                Console.WriteLine(resultat);
            }
            Console.WriteLine("**********************************");

            // Afficher l’auteur ayant écrit le plus de livres
            Console.WriteLine("#2 Afficher l’auteur ayant écrit le plus de livre: \n");
            Auteur auteurPlusDeLivre = ListeLivres.GroupBy(x => x.Auteur).OrderByDescending(x => x.Count()).First().Key;  
            Console.WriteLine(auteurPlusDeLivre.Prenom + " " + auteurPlusDeLivre.Nom);
             
            Console.WriteLine("**********************************");

            // Afficher le nombre moyen de pages par livre par auteur
            Console.WriteLine("#3 Afficher le nombre moyen de pages par livre par auteur: \n");
            double pagesMoyennes = 0;
            foreach (var item in ListeLivres.GroupBy(x => x.Auteur))
            {
                pagesMoyennes = item.Average(x => x.NbPages);
                resultat = String.Format("Nombre de pages en moyenne de {0} {1}: {2}", item.Key.Prenom, item.Key.Nom, pagesMoyennes);
                Console.WriteLine(resultat);
            }

            Console.WriteLine("**********************************");

            // Afficher le titre du livre avec le plus de pages
            Console.WriteLine("#4 Afficher le titre du livre avec le plus de pages: \n");
            Livre livrePagesMax = null;
            livrePagesMax = ListeLivres.OrderByDescending(x => x.NbPages).First();
            resultat = String.Format("{0} a le plus de pages", livrePagesMax.Titre);
            Console.WriteLine(resultat);

            Console.WriteLine("**********************************");

            // Afficher combien ont gagné les auteurs en moyenne(moyenne des factures)
            Console.WriteLine("#5 Afficher combien ont gagné les auteurs en moyenne(moyenne des factures): \n");
            decimal moyenneFactures = 0;
            moyenneFactures = ListeAuteurs.Average(x => x.Factures.Sum(y => y.Montant));
            resultat = String.Format("{0}  euros", moyenneFactures);
            Console.WriteLine(resultat);

            Console.WriteLine("**********************************");

            // Afficher les auteurs et la liste de leurs livres
            Console.WriteLine("#6 Afficher les auteurs et la liste de leurs livres: \n");
            foreach (var item in ListeLivres.GroupBy(x => x.Auteur))
            {
                foreach (var livre in item)
                {
                    resultat = String.Format("{0} {1}  -  {2}", item.Key.Nom, item.Key.Prenom, livre.Titre);
                    Console.WriteLine(resultat);
                }
            }

            Console.WriteLine("**********************************");

            // Afficher les titres de tous les livres triés par ordre alphabétique
            Console.WriteLine("#7 Afficher les titres de tous les livres triés par ordre alphabétique: \n");
            foreach (var item in ListeLivres.OrderBy(x => x.Titre)) 
            {
                resultat = item.Titre;
                Console.WriteLine(resultat);
            }
            Console.WriteLine("**********************************");

            // Afficher la liste des livres dont le nombre de pages est supérieur à la moyenne
            Console.WriteLine("#8 Afficher la liste des livres dont le nombre de pages est supérieur à la moyenne: \n");
            double moyenne = ListeLivres.Average(x => x.NbPages);
            foreach (var item in ListeLivres.Where(x => x.NbPages > moyenne))
            {
                resultat = item.Titre;
                Console.WriteLine(resultat);
            }

            Console.WriteLine("**********************************");

            // Afficher l'auteur ayant écrit le moins de livres
            Console.WriteLine("#9 Afficher l'auteur ayant écrit le moins de livres: \n");
            Auteur auteurMoinsDeLivres = ListeAuteurs.OrderBy(x => ListeLivres.Count(y => y.Auteur == x)).FirstOrDefault();
            resultat = String.Format("{0} {1}", auteurMoinsDeLivres.Nom, auteurMoinsDeLivres.Prenom);
            Console.WriteLine(resultat);

            Console.ReadKey();
        }



        private static void InitialiserDatas()
        {
            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).addFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).addFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).addFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
        }
    }
}
