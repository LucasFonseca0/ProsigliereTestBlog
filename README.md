# Blog API

This project is a simple API for managing blog posts and comments, built with .NET 8 and Entity Framework Core. The API allows creating and listing blog posts, as well as adding comments to posts.

## Prerequisites

- Docker
- Docker Compose

## Project Setup

### Clone the Repository

Clone this repository to your local machine:

```bash
git clone https://github.com/your-username/blog-api.git
cd blog-api
```

### Build and Run with Docker Compose

In the project's root directory, run the following command to build and start the containers:

```bash
docker-compose up --build
```

This will:

- Download the PostgreSQL image.
- Build the API image.
- Start both containers.

The API will be available at http://localhost:5000/Swagger and the PostgreSQL database will be accessible on port 5432.


### Running Migrations

To run the migrations in your case, use the following commands at the root of the project:

```bash
dotnet ef migrations add InitialCreate --project Infrastructure --startup-project API
dotnet ef database update --project Infrastructure --startup-project API
```

If you need further assistance or have any other questions, feel free to ask!

### Test the API

You can test all methods through Swagger at http://localhost:5000/Swagger.

- List all posts: `GET /api/posts`
- Create a new post: `POST /api/posts`
  - Request body (JSON):
    ```json
    {
      "title": "Post XPTO",
      "content": "This is the content"
    }
    ```
- Get a specific post by ID: `GET /api/posts/{id}`
- Add a comment to a post: `POST /api/posts/{id}/comments`
  - Request body (JSON):
    ```json
    {
      "content": "This is a comment."
    }
    ```

You don't need to send any of the IDs, only when linking a comment to a post.

### Running Automated Tests

To run the automated tests, use the command:

```bash
dotnet test
```

## Next Steps
If I had more time, I would:

1. Continue Creating Unit Tests for Repository and Controller: Continue implementing unit tests for the repository and controller layers, following the Arrange-Act-Assert (AAA) pattern to ensure code reliability and maintainability.
2. Separate Request and Persistence Objects: Introduce a clear separation between request objects (DTOs) and persistence objects (entities) to avoid exposing unnecessary fields and to enhance security.
3. Use AutoMapper for Object Mapping: Utilize AutoMapper to handle the mapping between DTOs and entities, reducing boilerplate code and improving maintainability.
4. Implement Unit of Work Pattern: Use the Unit of Work pattern to manage transactions and ensure that all operations within a business transaction are completed successfully before committing.
