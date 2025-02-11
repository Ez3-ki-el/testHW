# Projet de Gestion des Offres - SQLite & API Pôle Emploi

Ce projet est une application qui utilise une base de données SQLite pour stocker et gérer des informations relatives aux offres d'emploi. Actuellement, les données sont insérées ou mises à jour à partir d'un fichier JSON, et il reste à intégrer les appels API vers Pôle Emploi, en particulier la gestion de l'authentification.

## Fonctionnalités actuelles

- **Création de la base de données SQLite** : 
  Le projet crée automatiquement une base de données SQLite nommée `offreEmploi.db` à la première exécution. Si la base de données existe déjà, elle sera utilisée sans modification.

- **Gestion des Offres (Insert or Update)** :
  Le projet gère l'insertion et la mise à jour des offres dans la base de données. Si une offre existe déjà (identifiée par `IdPoleEmploi`), elle sera mise à jour, sinon elle sera ajoutée à la base de données.

- **Chargement des données depuis `offres.json`** :
  Les données sont actuellement chargées depuis un fichier `offres.json` présent à la racine du projet. Ce fichier contient une liste d'offres d'emploi avec les champs suivants :
  - `IdPoleEmploi` : Identifiant unique de l'offre
  - `Intitule` : Titre de l'offre
  - `Description` : Description de l'offre
  - `Url` : Lien vers l'offre en ligne

  Le fichier `offres.json` peut être modifié pour ajouter ou mettre à jour les offres d'emploi sans nécessiter de recompilation du projet.

- **Structure de la base de données** :
  La table `Offre` dans la base de données contient les colonnes suivantes :
  - `Id` (clé primaire, auto-incrémentée)
  - `Id_pole_emploi` (identifiant unique de l'offre)
  - `Intitule` (titre de l'offre)
  - `Description` (description de l'offre)
  - `URL` (lien vers l'offre en ligne)

## Prochaines étapes

### Intégration de l'API Pôle Emploi

Il reste à implémenter les appels API vers Pôle Emploi pour récupérer dynamiquement les offres d'emploi. La partie **authentification API** est actuellement en attente de mise en œuvre. Cela inclut l'obtention des jetons d'accès nécessaires.
Il faut également étoffer le modèle et les tables bdd en utilisant l'exemple de payload de pole-emploi et rajouter des contrôles de surface.

## Instructions pour démarrer

### Installation

1. Clonez ou téléchargez ce projet sur votre machine locale.
2. Ouvrez le projet dans votre éditeur préféré (par exemple, Visual Studio ou VSCode).
3. Assurez-vous que le fichier `offres.json` est présent à la racine du projet et contient des données valides pour les offres d'emploi.
4. Exécutez le projet via la ligne de commande ou l'IDE.

   ```bash
   dotnet run
