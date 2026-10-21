# Demo ASP.Net MVC 04 - Séance de cinéma 📽️

## Fonctionnalité

### Gestion des films
- Ajouter du film
- Afficher 
	- Détail d'un films
	- Liste avec pagination
- Rechercher par critere (Titre, Réal, Genre)
- Modifier les détails d'un film

### Gestion de séance
- Ajouter, Supprimer une séance
- Afficher
	- Liste par jour
	- Liste par film
- Annuler une séance

## Architecture de l'application
Application Monolithe en couche

### Description des couches

#### WebApp
Application Web en ASP.Net MVC. \
→ Controllers, Views, ViewModels/FormModels

#### BLL _(Business Logic Layer)_
Gestion des règles métiers. \
→ Services, Models

#### DAL _(Data Access Layer)_
Gestion des données (DB, WebAPI, Fichier, etc...). \
→ Repositories, Entities