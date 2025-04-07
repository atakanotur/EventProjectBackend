# EventProjectBackend

**EventProjectBackend** is a .NET Web API project developed for managing events. This backend application allows users to create, update, list, and delete events.

## 🔧 Project Structure

- **Business/** – Business logic (services)
- **Core/** – Core utilities and helpers
- **DataAccess/** – Database access layer (Entity Framework)
- **Entities/** – Entity classes (DTOs / Models)
- **WebAPI/** – API Controllers and application entry point
- **EventProject.sln** – Visual Studio solution file

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/atakanotur/EventProjectBackend.git
cd EventProjectBackend
```

### 2. Install .NET SDK

The project is compatible with .NET 6+. If you haven't already, download and install the [.NET SDK](https://dotnet.microsoft.com/en-us/download).

### 3. Configure Database Connection

In the `WebAPI/appsettings.json` file, provide your own database connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=EventDb;Trusted_Connection=True;"
}
```

### 4. Create the Database

```bash
dotnet ef database update --project WebAPI
```

### 5. Run the Project

```bash
dotnet run --project WebAPI
```

The API will run at `https://localhost:5001`.

## 📬 API Endpoints

> You can test the API using tools like Swagger (if available at `https://localhost:5001/swagger`).

Basic endpoints include:

- `GET /api/events`
- `POST /api/events`
- `PUT /api/events/{id}`
- `DELETE /api/events/{id}`

## 📄 License

This project is open-source. (If no license is specified, consider applying the MIT license.)

---

Created by: [atakanotur](https://github.com/atakanotur)
