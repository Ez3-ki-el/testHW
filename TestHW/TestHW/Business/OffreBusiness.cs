using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestHW.Models;
using TestHW.Repositories;

namespace TestHW.Business
{
    public class OffreBusiness
    {
        /// <summary>
        /// Rempli la BDD à partir des offres retournées par l'api de pole emploi
        /// </summary>
        public void ChargerOffresPoleEmploi()
        {
            Console.WriteLine("Récupération du token d'authent");
            //var token = new PoleEmploiApiAuthorize().Connect(); // Todo chercher pour récupérer le token bearer

            Console.WriteLine("Récupération des offres pole emploi");
            //List<int> citys = new() { 35238, 33063, 75056 };
            //var offres = new PoleEmploiApiClient().GetJobOffersAsync(citys).Result;
            // Todo supprimer le mock et brancher l'API
            List<Offre> offres = MockOffre.GetOffres();

            Console.WriteLine("Remplissage de la BDD");
            OffreRepository.InsertOrUpdateOffresPoleEmploi(offres);

            Console.WriteLine("Fin du chargement pole emploi, retour au menu");
        }

        /// <summary>
        /// Affiche les offres enregistrées en BDD
        /// </summary>
        public void AfficherOffres()
        {
            Console.WriteLine("Affichage des offres en BDD");
            // Récupération de toutes les offres
            List<Offre> offres = OffreRepository.RecupererToutesLesOffres();

            if (!offres.Any())
                Console.WriteLine("Aucune offre trouvée.");
            else
            {
                // Parcours de la liste d'offres et affichage des informations
                foreach (var offre in offres)
                {
                    Console.WriteLine($"ID BDD auto incr: {offre.Id}");
                    Console.WriteLine($"ID Pôle Emploi: {offre.IdPoleEmploi}");
                    Console.WriteLine($"Intitulé: {offre.Intitule}");
                    Console.WriteLine($"Description: {offre.Description}");
                    Console.WriteLine($"URL: {offre.Url}");
                    Console.WriteLine(); // Ligne vide pour séparer les offres
                }
            }

            Console.WriteLine("Fin de l'affichage des offres, retour au menu");
        }
    }
}
