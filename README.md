
# URL Shortener API Service

This project implements a simple URL Shortener service using ASP.NET Core 8. The service allows users to create, retrieve, update, delete short URLs, and track the access statistics for each short URL. 

## Features

- **Create a Short URL**: Shorten a long URL.
- **Retrieve a Short URL**: Retrieve the original URL from the short URL.
- **Update a Short URL**: Update an existing shortened URL.
- **Delete a Short URL**: Remove a shortened URL from the system.
- **Access Statistics**: Track and retrieve the number of times a short URL has been accessed.
- **Redirect Functionality**: Automatically redirect users to the original URL when they access the shortened URL.

## Technologies Used

- ASP.NET Core 8
- MediatR (for CQRS pattern)
- Repository pattern
- AutoMapper (for object-to-object mapping)
- Entity Framework Core (for data access)
- Swagger (for API documentation)

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or any compatible database supported by Entity Framework Core)
- [Visual Studio](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Setup

1. Clone the repository:

```bash
git clone https://github.com/your-username/url-shortener-api.git
cd url-shortener-api
```

2. Configure the connection string in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=your_server;Database=UrlShortenerDb;User Id=your_user;Password=your_password;"
}
```

3. Apply migrations and update the database:

```bash
dotnet ef database update
```

4. Build and run the application:

```bash
dotnet run
```

The application will start at `https://localhost:7071`. You can view the Swagger UI at `https://localhost:7071/swagger`.

### API Endpoints

Here are the main endpoints of the URL Shortener API:

#### 1. Create a New Short URL

- **Endpoint**: `POST /api/UrlShortener`
- **Request Body**:
  ```json
  {
    "originalUrl": "https://example.com"
  }
  ```
- **Response**: `201 Created`
  ```json
  {
    "id": 1,
    "originalUrl": "https://example.com",
    "shortenedUrl": "abc123",
    "accessCount": 0
  }
  ```

#### 2. Retrieve an Original URL from a Short URL

- **Endpoint**: `GET /api/UrlShortener/{shortenedUrl}`
- **Response**: Redirects to the original URL.

#### 3. Update an Existing Short URL

- **Endpoint**: `PUT /api/UrlShortener/{id}`
- **Request Body**:
  ```json
  {
    "id": 1,
    "originalUrl": "https://updatedexample.com",
    "shortenedUrl": "abc123"
  }
  ```
- **Response**: `204 No Content`

#### 4. Delete an Existing Short URL

- **Endpoint**: `DELETE /api/UrlShortener/{id}`
- **Response**: `204 No Content`

#### 5. Get Statistics on a Short URL

- **Endpoint**: `GET /api/UrlShortener/{shortenedUrl}/statistics`
- **Response**: `200 OK`
  ```json
  {
    "shortenedUrl": "abc123",
    "originalUrl": "https://example.com",
    "accessCount": 42
  }
  ```

### Error Handling

- **404 Not Found**: Returned when a requested resource (e.g., a shortened URL) is not found.
- **400 Bad Request**: Returned when input validation fails, such as when required fields are missing or when the ID in the route doesn't match the ID in the request body.
  
### Architecture

The project follows the **Clean Architecture** principles with the **CQRS (Command Query Responsibility Segregation)** pattern using MediatR.

#### Layers:

- **API Layer**: Controllers to handle HTTP requests.
- **Application Layer**: Business logic, including commands, queries, and their handlers.
- **Domain Layer**: Core entities and business rules.
- **Infrastructure Layer**: Data access using Entity Framework Core.

### Tracking Access Statistics

Each time a shortened URL is accessed, the access count is incremented and stored in the database. You can retrieve the statistics for any short URL using the `/statistics` endpoint.


Enjoy using the URL Shortener API!
