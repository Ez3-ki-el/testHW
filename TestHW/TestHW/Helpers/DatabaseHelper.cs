using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;

namespace TestHW.Helpers
{
    // Décaler cette base dans un BaseRepository et faire hériter les repository de BaseRepository
    public static class DatabaseHelper
    {

        public static readonly string DbPath = "Emploi.db";
        public static readonly string ConnectionString = $"Data Source={DbPath}";


        /// <summary>
        /// Détermine si la base existe ou non
        /// </summary>
        /// <returns></returns>
        public static bool IsDataBaseExisting()
        {
            Console.WriteLine("Vérifiction du de la présence du fichier DB dans le répertoire de travail actuel : " + Directory.GetCurrentDirectory());
            return File.Exists(DbPath);
        }

        /// <summary>
        /// Création de la bdd
        /// </summary>
        public static void CreateDatabase()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();

            // todo : Déplacer la création des tables dans une méthode dédiée
            string createTableQuery = @"
            CREATE TABLE IF NOT EXISTS Offre (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Id_pole_emploi TEXT NOT NULL,
                Intitule TEXT NOT NULL,
                Description TEXT NOT NULL,
                URL TEXT NOT NULL
            );";

            using var command = new SQLiteCommand(createTableQuery, connection);
            command.ExecuteNonQuery();
            Console.WriteLine("Base de données et table créées avec succès");
        }
    }
}
