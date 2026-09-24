# EF Core Code First - PC Management API 🖥️

A backend project built with **ASP.NET Core Web API**, utilizing the **Entity Framework Core Code First** approach to manage computers, components, and manufacturers.

## 📂 Project Structure

The project includes the following main directories and components:

*   **Controllers/**
    *   `PcsController.cs` – Controller handling API endpoints related to PC management.
*   **DTOs/** (Data Transfer Objects)
    *   `CreatePcDto.cs` – Data model for creating a new PC.
    *   `UpdatePcDto.cs` – Data model for updating PC information.
    *   `PCResponseDto.cs` & `PCDetailsResponseDto.cs` – Response models returned by the API for individual entries and details.
*   **Data/**
    *   `AppDbContext.cs` – Main Entity Framework Core database context.
*   **Entities/** (Database Entities)
    *   `PC.cs` – Main PC entity.
    *   `Component.cs` – Computer component entity.
    *   `ComponentType.cs` – Component types (e.g., CPU, graphics card).
    *   `ComponentManufacturer.cs` – Component manufacturers.
    *   `PCComponent.cs` – Many-to-many junction table (PC-component relationship).
*   **Services/**
    *   `IPCService.cs` – Interface defining business logic for PC operations.
    *   `PCService.cs` – Business logic implementation.

## ⚙️ Configuration and Running

1. Make sure you have the [.NET SDK](https://dotnet.microsoft.com/) installed.
2. Configure the database connection string in `appsettings.json` or `appsettings.Development.json`.
3. Run the application using the terminal command[cite: 1]:
   ```bash
   dotnet run
