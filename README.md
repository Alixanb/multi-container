# Multi-container Application

A modern web application demonstrating containerized microservices architecture with:

- **Frontend**: Vue.js 3 application with real-time data display
- **Backend**: ASP.NET Core 9.0 API
- **Database**: PostgreSQL 14 for data persistence
- **Administration**: PgAdmin for database management

The application showcases container orchestration using Docker Compose, with each service running in its own container. The frontend communicates with the backend API, which in turn interacts with the PostgreSQL database to retrieve and display messages.

## Key Features

- Containerized development environment
- Service isolation and scalability
- Database administration interface
- Environment-based configuration
- Cross-service communication

## Technologies

- Docker & Docker Compose
- Vue.js 3 with pnpm
- ASP.NET Core 9.0
- PostgreSQL 14
- Nginx (for frontend serving)

## Prérequis

- Docker et Docker Compose installés
- .NET SDK 9.0
- Node.js et pnpm

## Configuration

1. Cloner le repository
2. Créer le fichier `.env` à partir de `.env.example`:

```bash
cp .env.example .env
```

3. Modifier les variables dans `.env` selon vos besoins

## Installation et démarrage

1. Construire et démarrer les conteneurs:

```bash
docker-compose up -d
```

2. Vérifier que les services sont bien démarrés:

```bash
docker-compose ps
```

## Services disponibles

- Frontend (Vue.js): http://localhost:8081
- Backend API (ASP.NET): http://localhost:5001
- PgAdmin: http://localhost:5050
  - Email: valeur de PGADMIN_DEFAULT_EMAIL dans .env
  - Password: valeur de PGADMIN_DEFAULT_PASSWORD dans .env

## Structure du projet

```
.
├── frontend/          # Application Vue.js
├── backend/          # API ASP.NET Core
├── db/              # Scripts SQL d'initialisation
├── docker-compose.yml
└── .env
```

## Développement

- Frontend: Vue.js 3 avec pnpm
- Backend: ASP.NET Core 9.0
- Base de données: PostgreSQL 14

## Arrêt des services

```bash
docker-compose down
```

Pour supprimer aussi les volumes:

```bash
docker-compose down -v
```
