# P24H2025 - Hunt To Survive AI

## Description
Ce projet est une implémentation d'une IA pour le jeu "Hunt To Survive". L'application est développée en C# (.NET 6.0) et utilise une architecture client-serveur pour communiquer avec le serveur de jeu.

## Structure du Projet
```
├── Models/              # Classes de données
│   ├── Card.cs         # Représentation des cartes du jeu
│   ├── GameState.cs    # État du jeu
│   ├── Monster.cs      # Représentation des monstres
│   └── Player.cs       # Représentation du joueur
├── Services/           # Services de l'application
│   └── GameClient.cs   # Client de communication avec le serveur
├── Strategies/         # Logique de l'IA
│   └── StrategyManager.cs  # Gestionnaire des stratégies
└── Program.cs          # Point d'entrée de l'application
```

## Fonctionnalités
- Connexion au serveur de jeu
- Gestion de l'état du jeu
- Implémentation de stratégies de jeu
- Communication en temps réel avec le serveur
- Gestion des monstres et des cartes

## Configuration
- Framework: .NET 6.0
- Configuration du serveur:
  - IP: 127.0.0.1
  - Port: 1234
  - Nom d'équipe: Talc_Islandais
  - Temps de réponse maximum: 5 secondes

## Installation
1. Cloner le repository
2. Ouvrir la solution dans Visual Studio ou votre IDE préféré
3. Restaurer les dépendances NuGet
4. Compiler le projet

## Utilisation
Lancer l'application via la commande:
```bash
dotnet run
```

## Développement
Le projet suit une architecture modulaire avec:
- Une couche de modèles pour la représentation des données
- Une couche de services pour la communication
- Une couche de stratégies pour la logique de jeu

## Licence
Ce projet est développé dans le cadre du P24H2025.