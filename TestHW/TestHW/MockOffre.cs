using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

using TestHW.Models;

namespace TestHW
{
    public static class MockOffre
    {
        private static readonly string FilePath = "offres.json";

        public static List<Offre> GetOffres()
        {
            if (File.Exists(FilePath))
            {
                try
                {
                    string json = File.ReadAllText(FilePath);
                    var offres = JsonConvert.DeserializeObject<List<Offre>>(json);
                    return offres;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur lors de la lecture du fichier JSON : {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"Le fichier {FilePath} n'existe pas.");
            }

            return new List<Offre>();
        }


        //public static List<Offre> GetOffres()
        //{
        //    return new List<Offre>()
        //    {
        //        new()
        //        {
        //            IdPoleEmploi = "11",
        //            Intitule = "aegaegaeg",
        //            Description = " Une description",
        //            Url = "www.google.com"
        //        },
        //        new()
        //        {
        //            IdPoleEmploi = "22",
        //            Intitule = "jjjjjjj",
        //            Description = " Une description",
        //            Url = "www.google.fr"
        //        },
        //        new()
        //        {
        //            IdPoleEmploi = "3",
        //            Intitule = "qqqqqqq",
        //            Description = " Une description",
        //            Url = "www.google.ca"
        //        },
        //        new()
        //        {
        //            IdPoleEmploi = "4",
        //            Intitule = "ffffffff",
        //            Description = " Une description",
        //            Url = "www.google.sd"
        //        },
        //    };
        //}

    }
}
