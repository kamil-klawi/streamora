# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/)

## [Unreleased]

## [v0.1.0] - 2025-09-29

### Added
- Added `apps/` directory containing templates for backend services such as AuthService, UsersService and ApiGateway.
- Added `docker/` directory with Dockerfiles and docker-compose configuration files for the Auth and Users services.
- Added `start`, `stop`, `cleanup` and `init-multi-dbs` scripts.
- Added `start`, `stop` and `cleanup` commands to the Makefile.
- Added initial proxy configuration for the API Gateway.

## [v0.0.1] - 2025-09-28

### Added

- Added initial `CHANGELOG.md` with changelog template.
- Added `LICENSE` file.
- Added `README.md` with project overview.
- Added configuration files such as `.editorconfig`, `.gitattributes` and `.gitignore`.
- Added `docs/` directory containing documentation on API reference, directory structure and tech stack.
- Added `scripts/` directory with example script.
- Added `.github/` directory with example GitHub Actions workflow.
- Added `Makefile` file with example command.
