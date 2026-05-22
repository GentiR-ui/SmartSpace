# SmartSpace

SmartSpace is a comprehensive full-stack web application developed as a university project at **UBT (University for Business and Technology)**. 
It is designed to fulfill all the requirements of a proper software engineering project, utilizing best practices, Domain-Driven Design (DDD), and modern architectural patterns.

A detailed explanation of all software engineering concepts applied, including DDD principles, use cases, and system architecture, can be found in the accompanying `Smartspace documentation.docx`.

## Project Architecture

The project strictly follows **Clean Architecture** and is divided into two main components:
- **Backend**: Built with .NET 9.0.
- **Frontend**: A Single Page Application (SPA) built with React and Vite.

### Backend (.NET 9.0)
The backend solution is organized into the following layers to ensure separation of concerns:
- `API`: The presentation layer containing controllers and API endpoints.
- `Application`: Contains the core business logic, interfaces, and application services.
- `Domain`: The heart of the application, encompassing domain entities (e.g., `WorkSpace`), value objects, and domain exceptions, strictly adhering to DDD principles.
- `Infrastructure`: Handles external concerns such as database access (Entity Framework Core), migrations, and external service integrations.

**Technologies Used:**
- .NET 9.0
- Entity Framework Core

### Frontend (React & Vite)
Located in the `frontend` directory, this layer provides a dynamic and responsive user interface.

**Technologies Used:**
- React 18
- TypeScript
- Vite (for fast bundling and development)
- React Router (for navigation)
- Supabase (for authentication/backend services)

## Getting Started

### Backend
1. Open a terminal in the root directory or the `API` folder.
2. Run `dotnet restore` to install dependencies.
3. Apply database migrations: `dotnet ef database update --project Infrastructure --startup-project API`.
4. Start the backend server: `dotnet run --project API`.

### Frontend
1. Open a terminal in the `frontend` folder.
2. Install dependencies by running `npm install`.
3. Start the development server with `npm run dev`.
