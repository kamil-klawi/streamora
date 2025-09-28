# Architecture

This document describes the architecture of the **Streamora** platform.

## Monorepo Structure

```
streamora/
├── .github/
│   └── workflows
│   │   └── ...
├── apps/
│	  ├── AuthService/
│	  │   ├── src/
│	  │	  │   ├── AuthService.API
│	  │	  │   ├── AuthService.Application
│	  │	  │   ├── AuthService.Domain
│	  │	  │   └── AuthService.Infrastructure
│	  │   ├── tests/
│	  │	  │   ├── AuthService.IntegrationTests/
│	  │	  │   └── AuthService.UnitTests/
│	  │	  ├── AuthService.sln
│	  │ 	└── global.json
│   └── MoviesService/
│   │   └── ...
├── backup/
│   ├── db_2025-09-28_09-12-47.sql
│   └── ...
├── database/
│   ├── migrations/
│   └── ...
├── docker/
│	  ├── frontend/
│	  │   ├── dev/
│	  │	  │   └── Dockerfile
│	  │   └── Dockerfile
│	  ├── .dockerignore
│	  ├── .env
│	  ├── .env.example
│   ├── compose.yml
│   └── compose.override.yml
├── docs/
│   ├── api-reference.md
│   └── ...
├── frontend/
│   ├── public/
│   ├── src/
│   ├── tests/
│   ├── eslint.config.js
│   ├── prettier.config.js
│   ├── stylelint.config.js
│   └── package.json
├── scripts/
│	  ├── backup.sh
│	  ├── deploy.sh
│   └── ...
├── .editorconfig
├── .gitattributes
├── .gitignore
├── CHANGELOG.md
├── LICENSE
├── Makefile
└── README.md
```

## Directory Overview

- `.github/` - Contains GitHub Actions workflows for CI
- `apps/` - Source code for backend services
- `backup/` - Database backup SQL dumps (archival)
- `database/` - Holds database migrations and seed data scripts
- `docker/` - Docker and Docker Compose configuration files
- `docs/` - Documentation files
- `frontend/` - Source code for frontend applications
- `scripts/` - Utility shell scripts for tasks like backup, deployment and database migrations
