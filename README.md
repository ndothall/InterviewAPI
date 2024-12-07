📷 Interview API
A simple ASP.NET Core 8 Web API for managing camera data, featuring JWT authentication, role-based authorization, and in-memory data storage. This project demonstrates best practices for building APIs, including the use of DTOs, dependency injection, and secure authentication.

📝 Features
CRUD Operations: Manage camera data (Create, Read, Update, Delete).
JWT Authentication: Secure endpoints with JSON Web Tokens.
Role-Based Authorization: Restrict access to specific actions based on user roles (Admin, Viewer, etc.).
In-Memory Storage: Uses in-memory storage for simplicity.
Swagger Integration: API documentation and testing via Swagger UI.
🚀 Getting Started
Prerequisites
.NET 8 SDK
Visual Studio / Visual Studio Code
Git
Installation
Clone the Repository

bash
Copy code
git clone https://github.com/yourusername/interview-api.git
cd interview-api
Restore Dependencies

bash
Copy code
dotnet restore
Run the Application

bash
Copy code
dotnet run
Access Swagger UI

Open your browser and navigate to:

bash
Copy code
https://localhost:5001/swagger
🔑 Authentication
Default Users and Passwords
Username: Seth
Password: amplifund

Username: Aaron
Password: amplifund

Username: Test
Password: amplifund

Login Endpoint
http
Copy code
POST /api/authentication/login
Request Body:

json
Copy code
{
  "username": "Seth",
  "password": "amplifund"
}
Response:

json
Copy code
{
  "Token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "Role": "Admin",
  "Expires": "2024-12-06T16:30:00Z"
}
Include the token in the Authorization header to access protected endpoints:

makefile
Copy code
Authorization: Bearer <token>
📚 API Endpoints
Cameras
Method	Endpoint	Description	Authorization
GET	/api/cameras	Retrieve all cameras	Admin, Viewer
GET	/api/cameras/{id}	Retrieve a camera by ID	Admin, Viewer
POST	/api/cameras	Create a new camera	Admin
PUT	/api/cameras/{id}	Update an existing camera	Admin
DELETE	/api/cameras/{id}	Delete a camera by ID	Admin
🛠️ Technologies Used
ASP.NET Core 8
C#
JWT Authentication
Swagger (Swashbuckle)
Dependency Injection
In-Memory Data Storage
🤝 Contributing
Contributions are welcome! If you'd like to improve this project, please:

Fork the repository.
Create a new branch: git checkout -b feature/your-feature.
Commit your changes: git commit -m "Add new feature".
Push to the branch: git push origin feature/your-feature.
Submit a pull request.
