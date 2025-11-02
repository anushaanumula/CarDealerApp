# CarDealerApp

This is a small sample app with a minimal ASP.NET Core backend and a static frontend.

## Quick checklist
- Install .NET SDK (8.0 or close). Check by running `dotnet --version` in a terminal.
- Open two terminal windows: one for the backend, one for the frontend.

### 1) Run the backend (what runs the API)
In the backend terminal run:

```powershell
git clone https://github.com/anushaanumula/CarDealerApp.git
cd CarDealerApp\backend
dotnet run
```

By default the app listens on http://localhost:5055 (the actual URL is printed by `dotnet run`).

2. Open the frontend in a separate terminal / window:

```powershell
cd ..\frontend
# open frontend/index.html in your browser (double-click or use the editor)
```

The frontend is a static HTML file that calls the backend API. Make sure the backend is running before using the frontend.

## API Endpoints
All endpoints are under the base URL printed when the backend starts (example: http://localhost:5055).

HTTP Method  Endpoint         Description
GET          /cars            List all cars
GET          /cars/{id}       Get a car by ID
POST         /cars            Add a new car (body: JSON)
PUT          /cars/{id}       Update an existing car (body: JSON)
DELETE       /cars/{id}       Remove a car

Data is stored in-memory (for demo purposes). The data resets when the backend stops.

### Example requests
Using curl (replace port if different):

```powershell
# List all cars
curl http://localhost:5055/cars

# Get car with ID 1
curl http://localhost:5055/cars/1

# Create a new car
curl -X POST http://localhost:5055/cars -H "Content-Type: application/json" -d '{"make":"Toyota","model":"Camry","year":2023}'

# Update car ID 1
curl -X PUT http://localhost:5055/cars/1 -H "Content-Type: application/json" -d '{"make":"Honda","model":"Accord","year":2020}'

# Delete car ID 1
curl -X DELETE http://localhost:5055/cars/1
```

## Troubleshooting (easy fixes)
- If `dotnet run` says the port is in use, close the app that is using it (or restart your machine).
- If a git pull fails because files are locked, stop any running backend (Task Manager or `Stop-Process`) and remove `bin/` and `obj/` folders before pulling.
- If the frontend shows nothing, make sure the backend address (port) in the browser matches what `dotnet run` printed.

## Project layout (quick view)

```
CarDealerApp/
├── backend/          # .NET Web API
│   ├── Program.cs    # API code and in-memory data
│   └── backend.csproj
│
└── frontend/         # HTML + JS UI
        └── index.html
```

If you'd like, I can add a short section that shows exact sample responses from the current running backend, or I can add a GitHub Action to build the backend on each PR. Tell me which one you prefer.
