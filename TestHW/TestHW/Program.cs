using System;
using System.Collections.Generic;
using System.IO;

using TestHW.Business;
using TestHW.Helpers;

namespace TestHW
{
    internal class Program
    {

        static void Main(string[] args)
        {
            OffreBusiness offreBusiness = new();

            // Todo IsDataBaseExisting retourne toujours true même si je ne vois pas le fichier dans l'explorateur
            // Voir pour fix pour empêcher le create table systématique (même si il fait IF NOT EXIST)

            // Création de la BDD si besoin
            //if (DatabaseHelper.IsDataBaseExisting())
            //{
            //    Console.WriteLine("La base de données n'existe pas. Création en cours...");
            //    DatabaseHelper.CreateDatabase();
            //}

            // Création de la BDD
            DatabaseHelper.CreateDatabase();

            // Menu d'actions
            Dictionary<string, Action> actions = new()
            {
                { "1", offreBusiness.ChargerOffresPoleEmploi }, //  Rempli la BDD à partir des offres retournées par l'api de pole emploi
                { "2", offreBusiness.AfficherOffres }, // Affiche les offres présentes dans la BDD
                { "3", () => { Console.WriteLine("Fermeture du programme."); Environment.Exit(0); } }
            };

            while (true)
            {

                Console.WriteLine(
                    "1 - Charger Pôle Emploi\n" +
                    "2 - Afficher offres en bdd\n" +
                    "3 - Quitter"
                );

                var choix = Console.ReadLine();
                if (actions.TryGetValue(choix, out var action))
                {
                    action.Invoke();
                }
                else
                {
                    Console.WriteLine("Choix invalide !");
                }
            }
        }
    }
}
