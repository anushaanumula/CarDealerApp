backend
check if u have dotnet installed
git clone https://github.com/anushaanumula/CarDealerApp.git
cd CarDealerApp
cd backend
dotnet run
Now listening on: http://localhost:5055

open in browser, http://localhost:5055
HTTP Method	Endpoint	Description
GET	/cars	List all cars
GET	/cars/{id}	Get a car by ID
POST	/cars	Add a new car
PUT	/cars/{id}	Update an existing car
DELETE	/cars/{id}	Remove a car

Data is stored in-memory, so it resets when the backend stops.

Using Browser

Open http://localhost:5055/cars → lists all cars (GET endpoint)

Using Postman or any API testing tool
GET all cars
Method: GET
URL: http://localhost:5055/cars

GET one car
Method: GET
URL: http://localhost:5055/cars/1

POST new car
Method: POST
URL: http://localhost:5055/cars
Body (JSON):
{
  "make": "Ford",
  "model": "Mustang",
  "year": 2022
}

PUT update car
Method: PUT
URL: http://localhost:5055/cars/1
Body (JSON):
{
  "make": "Toyota",
  "model": "Corolla",
  "year": 2021
}



frontend
in new terminal. cd ../frontend

Make sure backend is running (dotnet run)
Open frontend/index.html in your browser
Click Load Cars → displays cars
Use Add / Update / Delete to test CRUD operations

CarDealerApp/
├── backend/          # .NET Web API
│   ├── Program.cs    # API code and in-memory data
│   └── backend.csproj
│
└── frontend/         # HTML + JS UI
    └── index.html
