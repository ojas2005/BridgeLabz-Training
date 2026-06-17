# Address Book API

ASP.NET Core Web API for managing address book contacts with Swagger documentation, Redis caching, and RabbitMQ messaging.

## Prerequisites

- .NET 8.0 SDK
- Redis Server (localhost:6379)
- RabbitMQ Server (localhost:5672)

## Installation

```bash
dotnet restore
```

## Running the Application

```bash
dotnet run
```

The API will be available at:
- HTTP: http://localhost:5000
- Swagger UI: http://localhost:5000/swagger

## API Endpoints

### Get All Contacts
```
GET /api/contacts
```

### Get Contact by ID
```
GET /api/contacts/{id}
```

### Create Contact
```
POST /api/contacts
Content-Type: application/json

{
  "firstName": "John",
  "lastName": "Doe",
  "address": "123 Main St",
  "city": "New York",
  "state": "NY",
  "zip": "10001",
  "phone": "555-0100",
  "email": "john@example.com"
}
```

### Update Contact
```
PUT /api/contacts/{id}
Content-Type: application/json

{
  "firstName": "John",
  "lastName": "Doe",
  "address": "456 Main St",
  "city": "New York",
  "state": "NY",
  "zip": "10002",
  "phone": "555-0101",
  "email": "john.doe@example.com"
}
```

### Delete Contact
```
DELETE /api/contacts/{id}
```

## Features

- CRUD operations for contacts
- Swagger API documentation
- Redis caching for improved performance
- RabbitMQ messaging for contact events
- Structured logging
- In-memory data storage

## Architecture

- **Program.cs**: Application setup and dependency injection
- **Controllers**: HTTP endpoints
- **Services**: Business logic and data operations
- **Models**: Data models
- **Logging**: Application logging service
- **Cache**: Redis caching service
- **Queue**: RabbitMQ messaging service
