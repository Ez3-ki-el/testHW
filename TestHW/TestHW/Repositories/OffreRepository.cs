using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;

using TestHW.Models;
using TestHW.Helpers;

namespace TestHW.Repositories
{
    public static class OffreRepository
    {
        /// <summary>
        /// Insertion des offres dans la table Offre
        /// </summary>
        public static void InsertOrUpdateOffresPoleEmploi(List<Offre> offres)
        {
            Console.WriteLine("Enregistrement des offres en base de données");

            using var connection = new SQLiteConnection(DatabaseHelper.ConnectionString);
            connection.Open();

            foreach (var offre in offres)
            {
                try
                {
                    // Vérification si l'offre existe déjà dans la base de données
                    if (IsOffreExisting(offre.IdPoleEmploi))
                    {
                        // Si l'offre existe, on effectue une mise à jour
                        string updateQuery = @"UPDATE Offre
                                                SET Intitule = @Intitule, Description = @Description, URL = @Url
                                                WHERE Id_pole_emploi = @Id_pole_emploi;";

                        using var command = new SQLiteCommand(updateQuery, connection);
                        // Remplissage des parametres
                        ConstructParameters(offre, command);

                        command.ExecuteNonQuery();
                        Console.WriteLine($"Offre mise à jour : {offre.IdPoleEmploi} ({offre.Intitule})");
                    }
                    else
                    {
                        // Si l'offre n'existe pas, on l'ajoute
                        string insertQuery = @"
                INSERT INTO Offre (Id_pole_emploi, Intitule, Description, URL)
                VALUES (@Id_pole_emploi, @Intitule, @Description, @Url);";

                        using var command = new SQLiteCommand(insertQuery, connection);
                        // Remplissage des parametres
                        ConstructParameters(offre, command);

                        command.ExecuteNonQuery();
                        Console.WriteLine($"Offre ajoutée : {offre.IdPoleEmploi} ({offre.Intitule})");
                    }
                }
                catch (SQLiteException ex)
                {
                    Console.WriteLine($"Erreur lors de l'ajout de {offre.IdPoleEmploi} : {ex}");
                }
            }

            Console.WriteLine("Chargement terminé !");
        }

        /// <summary>
        /// Récupération de toutes les offres en BDD
        /// </summary>
        public static List<Offre> RecupererToutesLesOffres()
        {
            var offres = new List<Offre>();

            using (var connection = new SQLiteConnection(DatabaseHelper.ConnectionString))
            {
                connection.Open();

                // Requête SQL pour récupérer toutes les offres
                string selectQuery = "SELECT Id, Id_pole_emploi, Intitule, Description, URL FROM Offre";

                // Exécuter la commande SQL
                using var command = new SQLiteCommand(selectQuery, connection);
                using var reader = command.ExecuteReader();

                // Vérifier si des résultats sont disponibles
                if (reader.HasRows)
                {
                    // Parcourir les résultats
                    while (reader.Read())
                    {
                        // Créer un nouvel objet Offre à partir des données lues
                        var offre = new Offre
                        {
                            Id = reader.GetInt32(0),
                            IdPoleEmploi = reader.GetString(1),
                            Intitule = reader.GetString(2),
                            Description = reader.GetString(3),
                            Url = reader.GetString(4)
                        };

                        // Ajouter l'offre à la liste
                        offres.Add(offre);
                    }
                }
                else
                {
                    Console.WriteLine("Aucune offre disponible.");
                }
            }

            return offres;
        }

        /// <summary>
        /// Détermine si l'offre existe déjà dans la BDD en se basant sur son idPoleEmploi
        /// </summary>
        /// <returns></returns>
        public static bool IsOffreExisting(string idPoleEmploi)
        {
            //Connexion
            using var connection = new SQLiteConnection(DatabaseHelper.ConnectionString);
            connection.Open();
            // Requête SQL pour vérifier si l'ID Pôle Emploi existe déjà dans la base
            string checkQuery = "SELECT COUNT(*) FROM Offre WHERE Id_pole_emploi = @Id_pole_emploi";
            using var command = new SQLiteCommand(checkQuery, connection);
            command.Parameters.AddWithValue("@Id_pole_emploi", idPoleEmploi);
            long count = (long)command.ExecuteScalar();
            return count > 0;  // Si le compte est supérieur à 0, l'offre existe déjà
        }


        public static void ConstructParameters(Offre offre, SQLiteCommand command)
        {
            command.Parameters.AddWithValue("@Id_pole_emploi", offre.IdPoleEmploi);
            command.Parameters.AddWithValue("@Intitule", offre.Intitule);
            command.Parameters.AddWithValue("@Description", offre.Description);
            command.Parameters.AddWithValue("@Url", offre.Url);
        }
    }
}
