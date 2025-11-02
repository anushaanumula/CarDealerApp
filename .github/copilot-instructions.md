# Copilot Instructions for AI Agents

## Project Overview
This repository is a full-stack application with a .NET backend and a static frontend. The backend is located in the `backend/` directory and the frontend in `frontend/`. The backend is likely an ASP.NET Core project, while the frontend is a static HTML site.

## Architecture & Data Flow
- **Backend (`backend/`)**: Contains the main API logic. Entry point is `Program.cs`. Configuration files include `appsettings.json` and `appsettings.Development.json`.
- **Frontend (`frontend/`)**: Contains `index.html`. No build system detected; static assets only.
- **Communication**: The frontend is expected to interact with the backend via HTTP API calls. The backend may expose endpoints defined in `backend.http` for testing.

## Developer Workflows
- **Build Backend**: Use `dotnet build backend/`.
- **Run Backend**: Use `dotnet run --project backend/`.
- **Debug Backend**: Launch profiles are defined in `backend/Properties/launchSettings.json`.
- **Configuration**: Use `appsettings.json` for production and `appsettings.Development.json` for development settings.
- **Frontend**: Open `frontend/index.html` directly in a browser for static testing. No build step required.

## Conventions & Patterns
- **.NET Project Structure**: Follows standard ASP.NET Core conventions. Main logic in `Program.cs`.
- **Configuration**: Environment-specific settings are separated into different JSON files.
- **No Custom Test/Build Scripts**: All build and run commands use standard `dotnet` CLI.
- **No Detected External Integrations**: No evidence of third-party services or custom agents.

## Key Files & Directories
- `backend/Program.cs`: Main backend entry point.
- `backend/appsettings*.json`: Configuration files.
- `backend/backend.http`: HTTP request samples for API testing.
- `frontend/index.html`: Main frontend file.

## Example Commands
- Build backend: `dotnet build backend/`
- Run backend: `dotnet run --project backend/`
- Debug backend: Use launch profiles in VS Code or Visual Studio

## Guidance for AI Agents
- Prefer standard .NET CLI commands for builds and runs.
- When editing configuration, update both `appsettings.json` and `appsettings.Development.json` if relevant.
- For API changes, update `backend.http` with new sample requests.
- Keep frontend changes minimal unless adding new static assets.

---

If any conventions or workflows are unclear, please ask for clarification or provide feedback to improve these instructions.